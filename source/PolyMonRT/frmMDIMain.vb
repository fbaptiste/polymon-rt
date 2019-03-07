Imports System.IO
Imports System.Text
Imports System.Security.Cryptography

Public Class frmMDIMain

    Private _AliasAccount As PolyMonSecurity.AliasAccount = Nothing

#Region "Event Handlers"
    Private Sub frmMDIMain_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Impersonate a user
        If Not String.IsNullOrEmpty(My.Settings.AliasUser) Then
            ImpersonateUser(My.Settings.AliasUser, DecryptPassword(My.Settings.AliasPwdEncrypted), My.Settings.AliasDomain)
        Else
            EndImpersonateUser()
        End If

        'Change MDI Color
        For Each ctl As Control In Me.Controls
            If TypeOf ctl Is MdiClient Then
                'ctl.BackColor = System.Drawing.Color.FromArgb(110, 139, 191)
                ctl.BackColor = System.Drawing.Color.FromArgb(126, 166, 225)
            End If
        Next
    End Sub
    Private Sub frmMDIMain_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        EndImpersonateUser()
    End Sub

    Private Sub mnuNewDashboard_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miNewDashboard.Click
        Dim frmDashboard As New frmMonitorDashboard
        frmDashboard.MdiParent = Me
        frmDashboard.Show()
    End Sub
    Private Sub mnuLoadDashboard_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miLoadDashboard.Click
        Dim StartLocation As String = My.Settings.LastFileSaveLocation
        If String.IsNullOrEmpty(StartLocation) Then
            StartLocation = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
        End If
        With OpenFileDialog1
            .FileName = Nothing
            .DefaultExt = ".pxml"
            .Filter = "PolyMon Dashboards|*.pxml"
            .InitialDirectory = StartLocation
            .AddExtension = True
            .SupportMultiDottedExtensions = True
        End With
        Dim strFile As String = Nothing
        Dim fiFile As FileInfo = Nothing
        Dim res As DialogResult = Me.OpenFileDialog1.ShowDialog()
        If res = Windows.Forms.DialogResult.OK Then
            strFile = OpenFileDialog1.FileName()
            If Not String.IsNullOrEmpty(strFile) Then
                fiFile = New FileInfo(strFile)
            End If
        End If

        'Open File
        If fiFile IsNot Nothing AndAlso fiFile.Exists Then
            My.Settings.LastFileSaveLocation = fiFile.DirectoryName
            My.Settings.Save()
            Cursor.Current = Cursors.WaitCursor
            Dim frmDashboard As New frmMonitorDashboard(fiFile)
            frmDashboard.MdiParent = Me
            frmDashboard.Show()
            Cursor.Current = Cursors.Default
        End If
    End Sub

    Private Sub TileHorizontalToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TileHorizontalToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.TileHorizontal)
    End Sub
    Private Sub TileVerticalToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TileVerticalToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.TileVertical)
    End Sub
    Private Sub CascadeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CascadeToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.Cascade)
    End Sub
    Private Sub ArrangeIconsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ArrangeIconsToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.ArrangeIcons)
    End Sub
    Private Sub MinimizeAllToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MinimizeAllToolStripMenuItem.Click
        For Each ChildWin As Form In Me.MdiChildren
            ChildWin.WindowState = FormWindowState.Minimized
        Next
    End Sub
    Private Sub RestoreAllToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RestoreAllToolStripMenuItem.Click
        For Each ChildWin As Form In Me.MdiChildren
            ChildWin.WindowState = FormWindowState.Normal
        Next
    End Sub
    Private Sub CloseAllToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseAllToolStripMenuItem.Click
        For Each ChildWin As Form In Me.MdiChildren
            ChildWin.Close()
        Next
    End Sub

    Private Sub mnuAbout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutToolStripMenuItem.Click
        Dim myAbout As New frmAbout()
        myAbout.ShowDialog()
    End Sub


    Private Sub tlblUser_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tlblUser.Click
        'Change Impersonation
        Dim dlg As dlgImpersonation
        If _AliasAccount Is Nothing Then
            dlg = New dlgImpersonation()
        Else
            dlg = New dlgImpersonation(_AliasAccount.username, _AliasAccount.password, _AliasAccount.domainname)
        End If
        Dim res As DialogResult = dlg.ShowDialog()
        If res = Windows.Forms.DialogResult.OK Then
            'Cancel any current impersonation
            If _AliasAccount IsNot Nothing Then
                EndImpersonateUser()
            End If
            If dlg.UseDefaultAccount Then
                'Do not impersonate, leave as is
                My.Settings.AliasUser = Nothing
                My.Settings.AliasPwdEncrypted = Nothing
                My.Settings.AliasDomain = Nothing
                My.Settings.Save()
            Else
                If ImpersonateUser(dlg.UserName, dlg.Password, dlg.Domain) Then
                    My.Settings.AliasUser = dlg.UserName
                    My.Settings.AliasPwdEncrypted = EncryptPassword(dlg.Password)
                    My.Settings.AliasDomain = dlg.Domain
                    My.Settings.Save()
                End If
            End If
        End If

    End Sub


#End Region

#Region "Private Methods"
    Private Function EncryptPassword(ByVal Pwd As String) As String
        Dim Sec As New PolyMonSecurity.Encryption(_PwdKey, _PwdIV)
        Return Sec.Encrypt(Pwd)
    End Function
    Private Function DecryptPassword(ByVal PwdEncrypted As String) As String
        Dim Sec As New PolyMonSecurity.Encryption(_PwdKey, _PwdIV)
        Return Sec.Decrypt(PwdEncrypted)
    End Function

    Private Function ImpersonateUser(ByVal UserName As String, ByVal Pwd As String, ByVal Domain As String) As Boolean
        Try
            If Not (String.IsNullOrEmpty(UserName)) Then
                'Impersonate user
                Dim DisplayUser As String = Nothing

                If String.IsNullOrEmpty(Domain) Then
                    _AliasAccount = New PolyMonSecurity.AliasAccount(UserName, Pwd)
                    DisplayUser = UserName
                Else
                    _AliasAccount = New PolyMonSecurity.AliasAccount(UserName, Pwd, Domain)
                    DisplayUser = String.Format("{0}\{1}", Domain, UserName)
                End If
                _AliasAccount.BeginImpersonation()

                tlblUser.Text = DisplayUser
                Return True
            End If
        Catch ex As PolyMonSecurity.AliasAccount.ImpersonationException
            MsgBox("Error impersonating user:" & vbCrLf & ex.Message, MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, "Security Error")
            If _AliasAccount IsNot Nothing Then
                _AliasAccount.EndImpersonation()
                _AliasAccount = Nothing
            End If
            Return False
        Catch ex As Exception
            MsgBox("Error impersonating user:" & vbCrLf & ex.Message, MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, "Security Error")
            If _AliasAccount IsNot Nothing Then
                _AliasAccount.EndImpersonation()
                _AliasAccount = Nothing
            End If
            Return False
        End Try
    End Function
    Private Sub EndImpersonateUser()
        Try
            If _AliasAccount IsNot Nothing Then
                _AliasAccount.EndImpersonation()
                _AliasAccount = Nothing
            End If
        Catch ex As Exception
            'Do nothing
        Finally
            tlblUser.Text = My.User.Name
        End Try

    End Sub
#End Region

End Class
