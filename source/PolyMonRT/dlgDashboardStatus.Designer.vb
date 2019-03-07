<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgDashboardStatus
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(dlgDashboardStatus))
        Me.OK_Button = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.chkIsPaused = New System.Windows.Forms.CheckBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.chkUnsavedChanges = New System.Windows.Forms.CheckBox
        Me.txtName = New System.Windows.Forms.TextBox
        Me.txtSaveFile = New System.Windows.Forms.TextBox
        Me.txtTotalMonitors = New System.Windows.Forms.TextBox
        Me.txtRunningMonitors = New System.Windows.Forms.TextBox
        Me.txtStoppedMonitors = New System.Windows.Forms.TextBox
        Me.SuspendLayout()
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.OK_Button.Location = New System.Drawing.Point(335, 266)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(67, 23)
        Me.OK_Button.TabIndex = 0
        Me.OK_Button.Text = "OK"
        '
        'Label1
        '
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(4, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(148, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(13, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(71, 23)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Name"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(4, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(148, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(13, 54)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(71, 23)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Save File"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'chkIsPaused
        '
        Me.chkIsPaused.AutoCheck = False
        Me.chkIsPaused.AutoSize = True
        Me.chkIsPaused.ForeColor = System.Drawing.Color.FromArgb(CType(CType(4, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(148, Byte), Integer))
        Me.chkIsPaused.Location = New System.Drawing.Point(16, 94)
        Me.chkIsPaused.Name = "chkIsPaused"
        Me.chkIsPaused.Size = New System.Drawing.Size(62, 17)
        Me.chkIsPaused.TabIndex = 3
        Me.chkIsPaused.Text = "Paused"
        Me.chkIsPaused.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(4, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(148, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(13, 133)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(79, 23)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "# Monitors"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(4, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(148, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(42, 159)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(79, 23)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Running"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(4, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(148, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(49, 185)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(73, 23)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "Stopped"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'chkUnsavedChanges
        '
        Me.chkUnsavedChanges.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkUnsavedChanges.AutoCheck = False
        Me.chkUnsavedChanges.AutoSize = True
        Me.chkUnsavedChanges.ForeColor = System.Drawing.Color.FromArgb(CType(CType(4, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(148, Byte), Integer))
        Me.chkUnsavedChanges.Location = New System.Drawing.Point(110, 94)
        Me.chkUnsavedChanges.Name = "chkUnsavedChanges"
        Me.chkUnsavedChanges.Size = New System.Drawing.Size(114, 17)
        Me.chkUnsavedChanges.TabIndex = 7
        Me.chkUnsavedChanges.Text = "Unsaved Changes"
        Me.chkUnsavedChanges.UseVisualStyleBackColor = True
        '
        'txtName
        '
        Me.txtName.Location = New System.Drawing.Point(90, 18)
        Me.txtName.Name = "txtName"
        Me.txtName.ReadOnly = True
        Me.txtName.Size = New System.Drawing.Size(171, 20)
        Me.txtName.TabIndex = 8
        '
        'txtSaveFile
        '
        Me.txtSaveFile.Location = New System.Drawing.Point(90, 55)
        Me.txtSaveFile.Name = "txtSaveFile"
        Me.txtSaveFile.ReadOnly = True
        Me.txtSaveFile.Size = New System.Drawing.Size(312, 20)
        Me.txtSaveFile.TabIndex = 9
        '
        'txtTotalMonitors
        '
        Me.txtTotalMonitors.Location = New System.Drawing.Point(98, 134)
        Me.txtTotalMonitors.Name = "txtTotalMonitors"
        Me.txtTotalMonitors.ReadOnly = True
        Me.txtTotalMonitors.Size = New System.Drawing.Size(83, 20)
        Me.txtTotalMonitors.TabIndex = 10
        '
        'txtRunningMonitors
        '
        Me.txtRunningMonitors.Location = New System.Drawing.Point(128, 160)
        Me.txtRunningMonitors.Name = "txtRunningMonitors"
        Me.txtRunningMonitors.ReadOnly = True
        Me.txtRunningMonitors.Size = New System.Drawing.Size(83, 20)
        Me.txtRunningMonitors.TabIndex = 11
        '
        'txtStoppedMonitors
        '
        Me.txtStoppedMonitors.Location = New System.Drawing.Point(128, 186)
        Me.txtStoppedMonitors.Name = "txtStoppedMonitors"
        Me.txtStoppedMonitors.ReadOnly = True
        Me.txtStoppedMonitors.Size = New System.Drawing.Size(83, 20)
        Me.txtStoppedMonitors.TabIndex = 12
        '
        'dlgDashboardStatus
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(417, 301)
        Me.Controls.Add(Me.OK_Button)
        Me.Controls.Add(Me.txtStoppedMonitors)
        Me.Controls.Add(Me.txtRunningMonitors)
        Me.Controls.Add(Me.txtTotalMonitors)
        Me.Controls.Add(Me.txtSaveFile)
        Me.Controls.Add(Me.txtName)
        Me.Controls.Add(Me.chkUnsavedChanges)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.chkIsPaused)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "dlgDashboardStatus"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Dashboard Info"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents chkIsPaused As System.Windows.Forms.CheckBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents chkUnsavedChanges As System.Windows.Forms.CheckBox
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents txtSaveFile As System.Windows.Forms.TextBox
    Friend WithEvents txtTotalMonitors As System.Windows.Forms.TextBox
    Friend WithEvents txtRunningMonitors As System.Windows.Forms.TextBox
    Friend WithEvents txtStoppedMonitors As System.Windows.Forms.TextBox

End Class
