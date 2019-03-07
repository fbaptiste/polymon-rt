<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMonitorDashboard
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMonitorDashboard))
        Me.tlbMain = New System.Windows.Forms.ToolStrip
        Me.tbInfo = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.tbSaveMain = New System.Windows.Forms.ToolStripSplitButton
        Me.tbSave = New System.Windows.Forms.ToolStripMenuItem
        Me.tbSaveAs = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.tbNewMonitor = New System.Windows.Forms.ToolStripButton
        Me.tbPauseResume = New System.Windows.Forms.ToolStripButton
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.slDirtyStatus = New System.Windows.Forms.ToolStripStatusLabel
        Me.slStatus = New System.Windows.Forms.ToolStripStatusLabel
        Me.pnlHost = New System.Windows.Forms.Panel
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog
        Me.tlbMain.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'tlbMain
        '
        Me.tlbMain.AllowMerge = False
        Me.tlbMain.BackColor = System.Drawing.SystemColors.Menu
        Me.tlbMain.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.tlbMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tbInfo, Me.ToolStripSeparator2, Me.tbSaveMain, Me.ToolStripSeparator1, Me.tbNewMonitor, Me.tbPauseResume})
        Me.tlbMain.Location = New System.Drawing.Point(0, 0)
        Me.tlbMain.Name = "tlbMain"
        Me.tlbMain.Padding = New System.Windows.Forms.Padding(10, 0, 1, 0)
        Me.tlbMain.Size = New System.Drawing.Size(532, 25)
        Me.tlbMain.TabIndex = 0
        Me.tlbMain.Text = "Save"
        '
        'tbInfo
        '
        Me.tbInfo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tbInfo.Image = Global.PolyMonRT.My.Resources.Resources.InfoSmall
        Me.tbInfo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tbInfo.Name = "tbInfo"
        Me.tbInfo.Size = New System.Drawing.Size(23, 22)
        Me.tbInfo.Text = "Dashboard Info"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'tbSaveMain
        '
        Me.tbSaveMain.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tbSaveMain.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tbSave, Me.tbSaveAs})
        Me.tbSaveMain.Image = Global.PolyMonRT.My.Resources.Resources.Save
        Me.tbSaveMain.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tbSaveMain.Name = "tbSaveMain"
        Me.tbSaveMain.Size = New System.Drawing.Size(32, 22)
        Me.tbSaveMain.Text = "Save"
        '
        'tbSave
        '
        Me.tbSave.Image = Global.PolyMonRT.My.Resources.Resources.Save
        Me.tbSave.Name = "tbSave"
        Me.tbSave.Size = New System.Drawing.Size(123, 22)
        Me.tbSave.Text = "Save"
        Me.tbSave.ToolTipText = "Save"
        '
        'tbSaveAs
        '
        Me.tbSaveAs.Name = "tbSaveAs"
        Me.tbSaveAs.Size = New System.Drawing.Size(123, 22)
        Me.tbSaveAs.Text = "Save As..."
        Me.tbSaveAs.ToolTipText = "Save As..."
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'tbNewMonitor
        '
        Me.tbNewMonitor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tbNewMonitor.Image = Global.PolyMonRT.My.Resources.Resources.NewMonitor
        Me.tbNewMonitor.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tbNewMonitor.Name = "tbNewMonitor"
        Me.tbNewMonitor.Size = New System.Drawing.Size(23, 22)
        Me.tbNewMonitor.Text = "New Monitor"
        Me.tbNewMonitor.ToolTipText = "Create a new Monitor Chart"
        '
        'tbPauseResume
        '
        Me.tbPauseResume.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.tbPauseResume.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tbPauseResume.Image = Global.PolyMonRT.My.Resources.Resources.Pause
        Me.tbPauseResume.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tbPauseResume.Name = "tbPauseResume"
        Me.tbPauseResume.Size = New System.Drawing.Size(23, 22)
        Me.tbPauseResume.Text = "Pause/Resume All Dashboard Monitors"
        Me.tbPauseResume.ToolTipText = "Pause/Resume All Dashboard Monitors"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.AllowMerge = False
        Me.StatusStrip1.BackColor = System.Drawing.SystemColors.Menu
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.slDirtyStatus, Me.slStatus})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 404)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(532, 22)
        Me.StatusStrip1.SizingGrip = False
        Me.StatusStrip1.TabIndex = 1
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'slDirtyStatus
        '
        Me.slDirtyStatus.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right
        Me.slDirtyStatus.Name = "slDirtyStatus"
        Me.slDirtyStatus.Size = New System.Drawing.Size(4, 17)
        '
        'slStatus
        '
        Me.slStatus.BackColor = System.Drawing.SystemColors.Menu
        Me.slStatus.Name = "slStatus"
        Me.slStatus.Size = New System.Drawing.Size(513, 17)
        Me.slStatus.Spring = True
        Me.slStatus.Text = "Ready"
        Me.slStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pnlHost
        '
        Me.pnlHost.BackColor = System.Drawing.Color.FromArgb(CType(CType(203, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.pnlHost.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlHost.Location = New System.Drawing.Point(0, 25)
        Me.pnlHost.Name = "pnlHost"
        Me.pnlHost.Size = New System.Drawing.Size(532, 379)
        Me.pnlHost.TabIndex = 2
        '
        'frmMonitorDashboard
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(532, 426)
        Me.Controls.Add(Me.pnlHost)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.tlbMain)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmMonitorDashboard"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show
        Me.Text = "Dashboard"
        Me.tlbMain.ResumeLayout(False)
        Me.tlbMain.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tlbMain As System.Windows.Forms.ToolStrip
    Friend WithEvents tbNewMonitor As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents tbSaveMain As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents tbSave As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tbSaveAs As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tbPauseResume As System.Windows.Forms.ToolStripButton
    Friend WithEvents pnlHost As System.Windows.Forms.Panel
    Friend WithEvents slDirtyStatus As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents tbInfo As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents slStatus As System.Windows.Forms.ToolStripStatusLabel
End Class
