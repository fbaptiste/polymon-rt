Imports System.Xml

Public Class ucPingConfig
    Implements PolyMonInterfaces.IMonitorDef

    Private _IsDirty As Boolean = False


    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        txtHost.Text = Nothing
        nudNumTries.Value = 5
        nudTimeout.Value = 2000
        nudTTL.Value = 32
        nudDataSize.Value = 32
        radPercFail.Checked = True
        _IsDirty = False
    End Sub
    Public Sub New(ByVal XMLParams As System.Xml.XmlNode)
        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        txtHost.Text = Nothing
        nudNumTries.Value = 5
        nudTimeout.Value = 2000
        nudTTL.Value = 32
        nudDataSize.Value = 32
        Deserialize(XMLParams)
        radPercFail.Checked = True
        _IsDirty = False
    End Sub

    Public ReadOnly Property IsDirty() As Boolean Implements PolyMonInterfaces.IMonitorDef.IsDirty
        Get
            Return _IsDirty
        End Get
    End Property


    Public Sub Deserialize(ByVal XMLParams As System.Xml.XmlNode) Implements PolyMonInterfaces.IMonitorDef.Deserialize
        Dim nodXML As XmlNode = Nothing
        Dim NodeValue As String = Nothing
        Dim Host As String
        Dim NumTries As Integer
        Dim Timeout As Integer
        Dim TTL As Integer
        Dim DataSize As Integer
        Dim ReturnPercFail As Boolean

        Try
            'Host
            nodXML = XMLParams.SelectSingleNode("Host")
            Host = nodXML.InnerText


            'NumTries
            nodXML = XMLParams.SelectSingleNode("NumTries")
            NodeValue = nodXML.InnerText
            If String.IsNullOrEmpty(NodeValue) OrElse Not (IsNumeric(NodeValue)) OrElse (CInt(NodeValue) < 1) Then
                NumTries = 5
            Else
                NumTries = CInt(NodeValue)
            End If


            'Timeout
            nodXML = XMLParams.SelectSingleNode("Timeout")
            NodeValue = nodXML.InnerText
            If String.IsNullOrEmpty(NodeValue) OrElse Not (IsNumeric(NodeValue)) OrElse (CInt(NodeValue) < 0) Then
                Timeout = 2000
            Else
                Timeout = CInt(NodeValue)
            End If

            'TTL
            nodXML = XMLParams.SelectSingleNode("TTL")
            NodeValue = nodXML.InnerText
            If String.IsNullOrEmpty(NodeValue) OrElse Not (IsNumeric(NodeValue)) OrElse (CInt(NodeValue) < 1) Then
                TTL = 32
            Else
                TTL = CInt(NodeValue)
            End If

            'DataSize
            nodXML = XMLParams.SelectSingleNode("DataSize")
            NodeValue = nodXML.InnerText
            If String.IsNullOrEmpty(NodeValue) OrElse Not (IsNumeric(NodeValue)) OrElse (CInt(NodeValue) < 1) Then
                DataSize = 32
            Else
                DataSize = CInt(NodeValue)
            End If

            'ReturnPercFail
            nodXML = XMLParams.SelectSingleNode("ReturnPercFail")
            NodeValue = nodXML.InnerText
            If String.IsNullOrEmpty(NodeValue) OrElse Not (IsNumeric(NodeValue)) Then
                ReturnPercFail = False
            Else
                ReturnPercFail = CBool(NodeValue)
            End If

            'And update GUI
            txtHost.Text = Host
            nudNumTries.Value = NumTries
            nudTimeout.Value = Timeout
            nudTTL.Value = TTL
            nudDataSize.Value = DataSize
            radPercFail.Checked = ReturnPercFail
            radAvgRTT.Checked = Not (ReturnPercFail)
        Catch ex As Exception
            MsgBox("Error loading Ping Monitor settings." & vbCrLf & ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Error loading Ping Monitor Definition")
        End Try

        'Reset IsDirty flag
        _IsDirty = False
    End Sub


    Public Function Serialize() As String Implements PolyMonInterfaces.IMonitorDef.Serialize
        Dim xmlSettings As New XmlWriterSettings
        xmlSettings.Indent = True
        xmlSettings.OmitXmlDeclaration = True
        xmlSettings.NewLineOnAttributes = False
        xmlSettings.IndentChars = ControlChars.Tab

        Dim xw As XmlWriter = Nothing
        Dim sbXML As New System.Text.StringBuilder
        xw = XmlWriter.Create(sbXML, xmlSettings)

        With xw
            .WriteStartElement("MonitorSettings")
            .WriteElementString("Host", txtHost.Text)
            .WriteElementString("NumTries", CStr(nudNumTries.Value))
            .WriteElementString("Timeout", CStr(nudTimeout.Value))
            .WriteElementString("TTL", CStr(nudTTL.Value))
            .WriteElementString("DataSize", CStr(nudDataSize.Value))
            If radPercFail.Checked Then
                .WriteElementString("ReturnPercFail", "1")
            Else
                .WriteElementString("ReturnPercFail", "0")
            End If
            .WriteEndElement() 'Monitor Settings
            .Close()
        End With

        Return sbXML.ToString
    End Function

    Private Sub ValuesChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtHost.TextChanged, nudNumTries.ValueChanged, nudTimeout.ValueChanged, nudTTL.ValueChanged, nudDataSize.ValueChanged, radPercFail.CheckedChanged, radAvgRTT.CheckedChanged
        _IsDirty = True
    End Sub


End Class
