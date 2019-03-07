Imports System.Windows.Forms

Public Class dlgImpersonation

#Region "Public Interface"
    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        chkUseCurrentUser.Checked = True
    End Sub
    Public Sub New(ByVal UserName As String, ByVal Pwd As String, ByVal Domain As String)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        chkUseCurrentUser.Checked = False
        txtUserName.Text = UserName
        txtPwd.Text = Pwd
        txtPwdVerify.Text = Pwd
        txtDomain.Text = Domain
    End Sub
    Public Property UseDefaultAccount() As Boolean
        Get
            Return chkUseCurrentUser.Checked
        End Get
        Set(ByVal value As Boolean)
            chkUseCurrentUser.Checked = True
        End Set
    End Property
    Public Property UserName() As String
        Get
            Return txtUserName.Text
        End Get
        Set(ByVal value As String)
            txtUserName.Text = value
        End Set
    End Property
    Public Property Password() As String
        Get
            If String.Compare(txtPwd.Text, txtPwdVerify.Text, False) = 0 Then
                Return txtPwd.Text
            Else
                Return Nothing
            End If
        End Get
        Set(ByVal value As String)
            txtPwd.Text = value
            txtPwdVerify.Text = value
        End Set
    End Property
    Public Property Domain() As String
        Get
            Return txtDomain.Text
        End Get
        Set(ByVal value As String)
            txtDomain.Text = value
        End Set
    End Property
#End Region

#Region "Event Handlers"
    Private Sub chkUseCurrentUser_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkUseCurrentUser.CheckedChanged
        pnlAlias.Enabled = Not (chkUseCurrentUser.Checked)
    End Sub

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        If Not (chkUseCurrentUser.Checked) AndAlso String.Compare(txtPwd.Text, txtPwdVerify.Text, False) <> 0 Then
            MsgBox("Passwords do not match. Please re-enter them.", MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, "Password Mismatch Error")
            txtPwd.Text = Nothing
            txtPwdVerify.Text = Nothing
            txtPwd.Focus()
            Exit Sub
        End If
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub
    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
#End Region

End Class
