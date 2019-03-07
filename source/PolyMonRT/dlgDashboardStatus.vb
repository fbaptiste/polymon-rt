Imports System.Windows.Forms

Public Class dlgDashboardStatus
    Public WriteOnly Property DashboardName() As String
        Set(ByVal value As String)
            txtName.Text = value
        End Set
    End Property
    Public WriteOnly Property SaveFile() As String
        Set(ByVal value As String)
            txtSaveFile.Text = value
        End Set
    End Property
    Public WriteOnly Property IsPaused() As Boolean
        Set(ByVal value As Boolean)
            chkIsPaused.Checked = value
        End Set
    End Property
    Public WriteOnly Property UnsavedChanges() As Boolean
        Set(ByVal value As Boolean)
            chkUnsavedChanges.Checked = value
        End Set
    End Property
    Public WriteOnly Property TotalMonitors() As String
        Set(ByVal value As String)
            txtTotalMonitors.Text = value
        End Set
    End Property
    Public WriteOnly Property RunningMonitors() As String
        Set(ByVal value As String)
            txtRunningMonitors.Text = value
        End Set
    End Property
    Public WriteOnly Property StoppedMonitors() As String
        Set(ByVal value As String)
            txtStoppedMonitors.Text = value
        End Set
    End Property

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub


End Class
