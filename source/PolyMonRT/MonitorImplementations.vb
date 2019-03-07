Imports System.Xml
Imports System.Data.SqlClient
Imports System.Net.NetworkInformation
Imports System.Collections.ObjectModel
Imports System.Management.Automation
Imports System.Management.Automation.Runspaces
Imports System.Text
Imports System.IO


Namespace PolyMonMonitors
    Public Class PerfMon
        Implements PolyMonInterfaces.IMonitorSampler

        Private _PC As PerformanceCounter = Nothing
        Private _XMLParams As System.Xml.XmlNode = Nothing
        Private _Host As String = Nothing
        Private _Category As String = Nothing
        Private _Counter As String = Nothing
        Private _Instance As String = Nothing

        Public Sub New()

        End Sub
        Public Sub New(ByVal XMLPararameters As XmlNode)
            XMLParams = XMLPararameters
        End Sub

        Public Function GetSample() As Double Implements PolyMonInterfaces.IMonitorSampler.GetSample
            If _PC Is Nothing Then
                Return ERRVALUE
            Else
                Try
                    Return _PC.NextValue
                Catch ex As Exception
                    Return ERRVALUE
                End Try
            End If
        End Function

        Public Property XMLParams() As System.Xml.XmlNode Implements PolyMonInterfaces.IMonitorSampler.XMLParams
            Get
                Return _XMLParams
            End Get
            Set(ByVal value As System.Xml.XmlNode)
                Try
                    _Host = value.SelectSingleNode("Host").InnerText
                    _Category = value.SelectSingleNode("Category").InnerText
                    _Counter = value.SelectSingleNode("Counter").InnerText
                    _Instance = value.SelectSingleNode("Instance").InnerText

                    _PC = New PerformanceCounter(_Category, _Counter, _Instance, _Host)

                    _XMLParams = value
                Catch ex As Exception
                    _XMLParams = Nothing
                End Try
            End Set
        End Property
    End Class

    Public Class SQLMonitor
        Implements PolyMonInterfaces.IMonitorSampler

        Private _Host As String = Nothing
        Private _Database As String = Nothing
        Private _SP As String = Nothing
        Private _IsIntegratedLogin As Boolean = False
        Private _UserName As String = Nothing
        Private _Password As String = Nothing
        Private _XMLParams As XmlNode = Nothing

        Private _SQLConn As SqlConnection = Nothing
        Private _SQLCmd As SqlCommand = Nothing
        Private _prmOutValue As SqlParameter = Nothing

        Public Sub New()

        End Sub
        Public Sub New(ByVal XMLPararameters As XmlNode)
            XMLParams = XMLPararameters
        End Sub

        Public Function GetSample() As Double Implements PolyMonInterfaces.IMonitorSampler.GetSample
            If _SQLConn Is Nothing OrElse _SQLCmd Is Nothing OrElse _prmOutValue Is Nothing Then
                Return ERRVALUE
            Else
                Try
                    If _SQLConn.State <> ConnectionState.Open Then _SQLConn.Open()
                    _SQLCmd.ExecuteNonQuery()
                    Return CDbl(_prmOutValue.Value)
                Catch ex As Exception
                    Return ERRVALUE
                Finally
                    _SQLConn.Close()
                End Try
            End If

        End Function

        Public Property XMLParams() As System.Xml.XmlNode Implements PolyMonInterfaces.IMonitorSampler.XMLParams
            Get
                Return _XMLParams
            End Get
            Set(ByVal value As System.Xml.XmlNode)
                Try
                    _XMLParams = value

                    Dim nodXML As XmlNode

                    'Host
                    nodXML = XMLParams.SelectSingleNode("Host")
                    _Host = nodXML.InnerText


                    'Database
                    nodXML = XMLParams.SelectSingleNode("Database")
                    _Database = nodXML.InnerText

                    'SP
                    nodXML = XMLParams.SelectSingleNode("SP")
                    _SP = nodXML.InnerText

                    'Integrated Login
                    nodXML = XMLParams.SelectSingleNode("Login")
                    If CInt(nodXML.Attributes("Integrated").Value) = 1 Then
                        _IsIntegratedLogin = True
                    Else
                        _IsIntegratedLogin = False
                        Dim nodXML2 As XmlNode
                        nodXML2 = nodXML.SelectSingleNode("UserName")
                        _UserName = nodXML2.InnerText
                        nodXML2 = nodXML.SelectSingleNode("Password")
                        _Password = nodXML2.InnerText
                    End If



                    'Try to define connection and command
                    Try
                        Dim cb As New SqlConnectionStringBuilder
                        cb("Data Source") = _Host
                        cb("Initial Catalog") = _Database

                        If _IsIntegratedLogin Then
                            cb("Integrated Security") = True
                        Else
                            cb("Integrated Security") = False
                            cb("User ID") = _UserName
                            cb("Password") = _Password
                        End If
                        cb("Connection Timeout") = 30
                        _SQLConn = New SqlConnection(cb.ConnectionString)

                        _SQLCmd = New SqlCommand
                        With _SQLCmd
                            .Connection = _SQLConn
                            .CommandType = CommandType.StoredProcedure
                            .CommandText = _SP
                            .CommandTimeout = 60 'seconds
                            _prmOutValue = New SqlParameter
                            With _prmOutValue
                                .ParameterName = "@OutValue"
                                .SqlDbType = SqlDbType.Real
                                .Direction = ParameterDirection.Output
                            End With
                            .Parameters.Add(_prmOutValue)
                        End With
                    Catch ex As Exception
                        _SQLConn = Nothing
                        _SQLCmd = Nothing
                    End Try
                Catch ex As Exception
                    _XMLParams = Nothing
                End Try
            End Set
        End Property
    End Class

    Public Class PingMonitor
        Implements PolyMonInterfaces.IMonitorSampler

        Private _Host As String = Nothing
        Private _NumTries As Integer = 5
        Private _Timeout As Integer = 2000
        Private _TTL As Integer = 32
        Private _DataSize As Integer = 32
        Private _ReturnPercFail As Boolean = True

        Private _XMLParams As XmlNode = Nothing

        Public Sub New()

        End Sub
        Public Sub New(ByVal XMLPararameters As XmlNode)
            XMLParams = XMLPararameters
        End Sub

        Public Function GetSample() As Double Implements PolyMonInterfaces.IMonitorSampler.GetSample
            Dim PercOK As Double = 0
            Dim AvgRTT As Double = 0

            If _Host Is Nothing Then
                PercOK = 0
                AvgRTT = -1
            Else
                Try
                    Dim iTry As Integer = 1

                    Dim PSender As New Ping
                    Dim POptions As New PingOptions
                    Dim PReply As PingReply
                    Dim Data As String = New String(CChar("a"), _DataSize)

                    Dim Buffer As Byte() = System.Text.Encoding.ASCII.GetBytes(Data)

                    POptions.Ttl = _TTL

                    Dim CumPingTime As Long = 0
                    Dim TotalPingsOK As Integer
                    Dim TotalPingsFail As Integer = 0

                    For iTry = 1 To _NumTries
                        'PingResult = My.Computer.Network.Ping(Host, Timeout)
                        PReply = PSender.Send(_Host, _Timeout, Buffer, POptions)

                        If Not (PReply.Status = IPStatus.Success) Then
                            TotalPingsFail += 1
                        Else
                            TotalPingsOK += 1
                            CumPingTime += PReply.RoundtripTime
                        End If
                    Next

                    'Percentage OK
                    PercOK = CDbl((TotalPingsOK / (TotalPingsOK + TotalPingsFail))) * 100

                    'Avg RTT
                    If TotalPingsOK = 0 Then
                        'No succesful ping...
                        AvgRTT = -1
                    Else
                        AvgRTT = CDbl(CumPingTime / TotalPingsOK)
                    End If
                Catch ex As Exception
                    PercOK = 0
                    AvgRTT = -1
                End Try
            End If

            'Finally return Monitor Value
            If _ReturnPercFail Then
                Return 100 - PercOK 'Return % Failed Tries
            Else
                Return AvgRTT
            End If
        End Function

        Public Property XMLParams() As System.Xml.XmlNode Implements PolyMonInterfaces.IMonitorSampler.XMLParams
            Get
                Return _XMLParams
            End Get
            Set(ByVal value As System.Xml.XmlNode)
                Try
                    _XMLParams = value

                    Dim nodXML As XmlNode
                    Dim NodeValue As String = Nothing

                    'Host
                    nodXML = XMLParams.SelectSingleNode("Host")
                    _Host = nodXML.InnerText


                    'NumTries
                    nodXML = XMLParams.SelectSingleNode("NumTries")
                    NodeValue = nodXML.InnerText
                    If String.IsNullOrEmpty(NodeValue) OrElse Not (IsNumeric(NodeValue)) OrElse (CInt(NodeValue) < 1) Then
                        _NumTries = 5
                    Else
                        _NumTries = CInt(NodeValue)
                    End If


                    'Timeout
                    nodXML = XMLParams.SelectSingleNode("Timeout")
                    NodeValue = nodXML.InnerText
                    If String.IsNullOrEmpty(NodeValue) OrElse Not (IsNumeric(NodeValue)) OrElse (CInt(NodeValue) < 0) Then
                        _Timeout = 2000
                    Else
                        _Timeout = CInt(NodeValue)
                    End If

                    'TTL
                    nodXML = XMLParams.SelectSingleNode("TTL")
                    NodeValue = nodXML.InnerText
                    If String.IsNullOrEmpty(NodeValue) OrElse Not (IsNumeric(NodeValue)) OrElse (CInt(NodeValue) < 1) Then
                        _TTL = 32
                    Else
                        _TTL = CInt(NodeValue)
                    End If

                    'DataSize
                    nodXML = XMLParams.SelectSingleNode("DataSize")
                    NodeValue = nodXML.InnerText
                    If String.IsNullOrEmpty(NodeValue) OrElse Not (IsNumeric(NodeValue)) OrElse (CInt(NodeValue) < 1) Then
                        _DataSize = 32
                    Else
                        _DataSize = CInt(NodeValue)
                    End If

                    'ReturnPercOK
                    nodXML = XMLParams.SelectSingleNode("ReturnPercFail")
                    NodeValue = nodXML.InnerText
                    If String.IsNullOrEmpty(NodeValue) OrElse Not (IsNumeric(NodeValue)) Then
                        _ReturnPercFail = False
                    Else
                        _ReturnPercFail = CBool(NodeValue)
                    End If

                Catch ex As Exception
                    _XMLParams = Nothing
                End Try
            End Set
        End Property
    End Class

    Public Class PowerShellMonitor
        Implements PolyMonInterfaces.IMonitorSampler

        Private _XMLParams As XmlNode = Nothing
        Private _PSRunSpace As Runspace = Nothing
        Private _Script As String = Nothing
        Private _PolyMonRTCounter As New RTCounter

        Public Sub New()

        End Sub
        Public Sub New(ByVal XMLParameters As XmlNode)
            XMLParams = XMLParameters
        End Sub

        Public Function GetSample() As Double Implements PolyMonInterfaces.IMonitorSampler.GetSample
            If _XMLParams Is Nothing OrElse String.IsNullOrEmpty(_XMLParams.InnerText) Then
                Return -1
            Else
                Try
                    If _PSRunSpace Is Nothing Then
                        _PSRunSpace = Runspaces.RunspaceFactory.CreateRunspace()
                        _PSRunSpace.Open()
                        _PSRunSpace.SessionStateProxy.SetVariable("PolyMonRT", _PolyMonRTCounter)
                    End If
                    Dim myPipeLine As Pipeline

                    If String.IsNullOrEmpty(_Script) Then
                        _Script = ReadXMLNodeValue(_XMLParams.SelectSingleNode("Script"))
                        If Not String.IsNullOrEmpty(_Script) Then
                            _Script = XMLDecode(_Script)
                        Else
                            Return -1
                        End If
                    End If

                    myPipeLine = _PSRunSpace.CreatePipeline(_Script)
                    myPipeLine.Invoke()

                    Return _PolyMonRTCounter.Counter
                Catch ex As Exception
                    Return -1
                Finally
                    'Do no dispose the RunSpace as it will be re-used at next call.
                    'If myRunspace IsNot Nothing Then
                    '    If myRunspace.RunspaceStateInfo.State <> Runspaces.RunspaceState.Closed Then myRunspace.Close()
                    '    myRunspace.Dispose()
                    'End If
                End Try
            End If
        End Function

        Public Class RTCounter
            Private _Counter As Double

            Public Sub New()
                _Counter = -1
            End Sub

            Public Property Counter() As Double
                Get
                    Return _Counter
                End Get
                Set(ByVal value As Double)
                    _Counter = value
                End Set
            End Property
        End Class

        Public Property XMLParams() As System.Xml.XmlNode Implements PolyMonInterfaces.IMonitorSampler.XMLParams
            Get
                Return _XMLParams
            End Get
            Set(ByVal value As System.Xml.XmlNode)
                Try
                    _XMLParams = value
                Catch ex As Exception
                    _XMLParams = Nothing
                End Try
            End Set
        End Property

        Private Function ReadXMLNodeValue(ByVal myXMLNode As XmlNode) As String
            If myXMLNode Is Nothing Then
                Return Nothing
            Else
                If myXMLNode Is Nothing OrElse myXMLNode.InnerXml = Nothing Then
                    Return Nothing
                Else
                    Return myXMLNode.InnerXml.Trim()
                End If
            End If
        End Function

        Private Function XMLEncode(ByVal XMLString As String) As String
            Dim tmpStr As String = XMLString

            tmpStr = tmpStr.Replace("&", "&amp;")
            tmpStr = tmpStr.Replace("<", "&lt;")
            tmpStr = tmpStr.Replace(">", "&gt;")
            tmpStr = tmpStr.Replace("""", "&quot;")
            tmpStr = tmpStr.Replace("'", "&apos;")

            Return tmpStr
        End Function

        Private Function XMLDecode(ByVal XMLString As String) As String
            Dim tmpStr As String = XMLString

            tmpStr = tmpStr.Replace("&amp;", "&")
            tmpStr = tmpStr.Replace("&lt;", "<")
            tmpStr = tmpStr.Replace("&gt;", ">")
            tmpStr = tmpStr.Replace("&quot;", """")
            tmpStr = tmpStr.Replace("&apos;", "'")

            Return tmpStr
        End Function
    End Class
End Namespace