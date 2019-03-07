Imports System.Xml

Public Class ucPowerShellConfig
    Implements PolyMonInterfaces.IMonitorDef

    Private _IsDirty As Boolean = False

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        txtScript.Text = Nothing
        _IsDirty = False
    End Sub
    Public Sub New(ByVal XMLParams As System.Xml.XmlNode)
        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        txtScript.Text = Nothing
        Deserialize(XMLParams)
        _IsDirty = False
    End Sub

    Public ReadOnly Property IsDirty() As Boolean Implements PolyMonInterfaces.IMonitorDef.IsDirty
        Get
            Return _IsDirty
        End Get
    End Property

    Public Sub Deserialize(ByVal XMLParams As System.Xml.XmlNode) Implements PolyMonInterfaces.IMonitorDef.Deserialize
        Try
            Dim Script As String = Nothing
            Script = ReadXMLNodeValue(XMLParams.SelectSingleNode("Script"))
            If Not String.IsNullOrEmpty(Script) Then Script = XMLDecode(Script)

            txtScript.Text = Script
        Catch ex As Exception
            MsgBox("Error loading PowerShell Monitor settings." & vbCrLf & ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Error loading PowerShell Monitor Definition")
        End Try

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
            .WriteElementString("Script", XMLEncode(txtScript.Text))
            .WriteEndElement() 'Monitor Settings
            .Close()
        End With

        Return sbXML.ToString
    End Function



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
