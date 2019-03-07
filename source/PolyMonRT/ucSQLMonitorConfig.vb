Imports System.Xml
Imports System.Data.SqlClient

Public Class ucSQLMonitorConfig
    Implements PolyMonInterfaces.IMonitorDef

    Private _IsDirty As Boolean = False


    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        txtHost.Text = Nothing
        txtDatabase.Text = Nothing
        radIntegratedLogin.Checked = True
        txtUserName.Text = Nothing
        txtUserName.Enabled = False
        txtPassword.Enabled = False
        txtStoredProc.Text = Nothing
        _IsDirty = False
    End Sub
    Public Sub New(ByVal XMLParams As System.Xml.XmlNode)
        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        txtHost.Text = Nothing
        txtDatabase.Text = Nothing
        radIntegratedLogin.Checked = True
        txtUserName.Text = Nothing
        txtUserName.Enabled = False
        txtPassword.Enabled = False
        txtStoredProc.Text = Nothing
        Deserialize(XMLParams)
        _IsDirty = False
    End Sub

    Public ReadOnly Property IsDirty() As Boolean Implements PolyMonInterfaces.IMonitorDef.IsDirty
        Get
            Return _IsDirty
        End Get
    End Property


    Public Sub Deserialize(ByVal XMLParams As System.Xml.XmlNode) Implements PolyMonInterfaces.IMonitorDef.Deserialize
        Dim nodXML As XmlNode = Nothing

        Dim Host As String = Nothing
        Dim Database As String = Nothing
        Dim IsIntegratedLogin As Boolean = False
        Dim UserName As String = Nothing
        Dim Password As String = Nothing
        Dim SP As String = Nothing

        Try
            'Host
            nodXML = XMLParams.SelectSingleNode("Host")
            Host = nodXML.InnerText


            'Database
            nodXML = XMLParams.SelectSingleNode("Database")
            Database = nodXML.InnerText

            'SP
            nodXML = XMLParams.SelectSingleNode("SP")
            SP = nodXML.InnerText

            'Integrated Login
            nodXML = XMLParams.SelectSingleNode("Login")
            If CInt(nodXML.Attributes("Integrated").Value) = 1 Then
                IsIntegratedLogin = True
            Else
                IsIntegratedLogin = False
                Dim nodXML2 As XmlNode
                nodXML2 = nodXML.SelectSingleNode("UserName")
                UserName = nodXML2.InnerText
                nodXML2 = nodXML.SelectSingleNode("Password")
                Password = nodXML2.InnerText
            End If

            'Display values on interface
            txtHost.Text = Host
            txtDatabase.Text = Database
            txtStoredProc.Text = SP
            radIntegratedLogin.Checked = IsIntegratedLogin
            txtUserName.Text = UserName
            txtPassword.Text = Password
        Catch ex As Exception
            MsgBox("Error loading SQL Monitor settings." & vbCrLf & ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Error loading SQL Monitor Definition")
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
            .WriteElementString("Database", txtDatabase.Text)
            .WriteStartElement("Login")
            If radIntegratedLogin.Checked Then
                .WriteAttributeString("Integrated", "1")
            Else
                .WriteAttributeString("Integrated", "0")
                .WriteElementString("UserName", txtUserName.Text)
                .WriteElementString("Password", txtPassword.Text)
            End If
            .WriteEndElement() 'Login

            .WriteElementString("SP", txtStoredProc.Text)
            .WriteEndElement() 'Monitor Settings
            .Close()
        End With

        Return sbXML.ToString
    End Function

    Private Sub LoginType_Changed(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radSQLLogin.CheckedChanged, radIntegratedLogin.CheckedChanged
        txtUserName.Enabled = radSQLLogin.Checked
        txtPassword.Enabled = radSQLLogin.Checked
        _IsDirty = True
    End Sub


    Private Sub txtHost_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtHost.TextChanged
        _IsDirty = True
    End Sub

    Private Sub txtDatabase_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDatabase.TextChanged
        _IsDirty = True
    End Sub

    Private Sub txtUserName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtUserName.TextChanged
        _IsDirty = True
    End Sub

    Private Sub txtPassword_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPassword.TextChanged
        _IsDirty = True
    End Sub

    Private Sub txtStoredProc_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtStoredProc.TextChanged
        _IsDirty = True
    End Sub


    Private Sub btnTest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTest.Click
        Dim SQLConn As SqlConnection = Nothing
        Dim SQLCmd As SqlCommand = Nothing
        Dim prmOutValue As SqlParameter = Nothing

        Try
            Dim cb As New SqlConnectionStringBuilder
            cb("Data Source") = txtHost.Text
            cb("Initial Catalog") = txtDatabase.Text

            If radIntegratedLogin.Checked Then
                cb("Integrated Security") = True
            Else
                cb("Integrated Security") = False
                cb("User ID") = txtUserName.Text
                cb("Password") = txtPassword.Text
            End If
            cb("Connection Timeout") = 30
            SQLConn = New SqlConnection(cb.ConnectionString)

            SQLCmd = New SqlCommand
            With SQLCmd
                .Connection = SQLConn
                .CommandType = CommandType.StoredProcedure
                .CommandText = txtStoredProc.Text
                .CommandTimeout = 60 'seconds
                prmOutValue = New SqlParameter
                With prmOutValue
                    .ParameterName = "@OutValue"
                    .SqlDbType = SqlDbType.Real
                    .Direction = ParameterDirection.Output
                End With
                .Parameters.Add(prmOutValue)
            End With

            SQLConn.Open()
            SQLCmd.ExecuteNonQuery()
            MsgBox("Succesfully called stored procedure. Returned value = " & CStr(prmOutValue.Value), MsgBoxStyle.OkOnly Or MsgBoxStyle.Information, "PolyMonRT")

        Catch ex As Exception
            MsgBox("Error running connecting to SQL Server or Running Stored Procedure" & vbCrLf & ex.Message, MsgBoxStyle.OkOnly Or MsgBoxStyle.Exclamation, "PolyMonRT")
        Finally
            SQLConn.Close()
        End Try

    End Sub
End Class
