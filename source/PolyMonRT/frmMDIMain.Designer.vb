<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMDIMain
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMDIMain))
        Me.mnuMain = New System.Windows.Forms.MenuStrip
        Me.miFileMenu = New System.Windows.Forms.ToolStripMenuItem
        Me.miLoadDashboard = New System.Windows.Forms.ToolStripMenuItem
        Me.miNewDashboard = New System.Windows.Forms.ToolStripMenuItem
        Me.miSep1 = New System.Windows.Forms.ToolStripSeparator
        Me.miSaveAll = New System.Windows.Forms.ToolStripMenuItem
        Me.WindowToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ArrangeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.TileHorizontalToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.TileVerticalToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.CascadeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ArrangeIconsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.MinimizeAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.RestoreAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.CloseAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel
        Me.tlblUser = New System.Windows.Forms.ToolStripStatusLabel
        Me.mnuMain.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'mnuMain
        '
        Me.mnuMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miFileMenu, Me.WindowToolStripMenuItem, Me.HelpToolStripMenuItem})
        Me.mnuMain.Location = New System.Drawing.Point(0, 0)
        Me.mnuMain.Name = "mnuMain"
        Me.mnuMain.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.mnuMain.Size = New System.Drawing.Size(865, 24)
        Me.mnuMain.TabIndex = 1
        Me.mnuMain.Text = "Main Menu"
        '
        'miFileMenu
        '
        Me.miFileMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miLoadDashboard, Me.miNewDashboard, Me.miSep1, Me.miSaveAll})
        Me.miFileMenu.Name = "miFileMenu"
        Me.miFileMenu.Size = New System.Drawing.Size(37, 20)
        Me.miFileMenu.Text = "&File"
        '
        'miLoadDashboard
        '
        Me.miLoadDashboard.Image = Global.PolyMonRT.My.Resources.Resources.Open
        Me.miLoadDashboard.Name = "miLoadDashboard"
        Me.miLoadDashboard.Size = New System.Drawing.Size(180, 22)
        Me.miLoadDashboard.Text = "&Open Dashboard..."
        '
        'miNewDashboard
        '
        Me.miNewDashboard.Image = Global.PolyMonRT.My.Resources.Resources._New
        Me.miNewDashboard.Name = "miNewDashboard"
        Me.miNewDashboard.Size = New System.Drawing.Size(180, 22)
        Me.miNewDashboard.Text = "&New Dashboard"
        '
        'miSep1
        '
        Me.miSep1.Name = "miSep1"
        Me.miSep1.Size = New System.Drawing.Size(177, 6)
        '
        'miSaveAll
        '
        Me.miSaveAll.Image = Global.PolyMonRT.My.Resources.Resources.SaveAll
        Me.miSaveAll.Name = "miSaveAll"
        Me.miSaveAll.Size = New System.Drawing.Size(180, 22)
        Me.miSaveAll.Text = "Save All Dashboards"
        '
        'WindowToolStripMenuItem
        '
        Me.WindowToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ArrangeToolStripMenuItem, Me.ToolStripSeparator1, Me.MinimizeAllToolStripMenuItem, Me.RestoreAllToolStripMenuItem, Me.CloseAllToolStripMenuItem})
        Me.WindowToolStripMenuItem.Name = "WindowToolStripMenuItem"
        Me.WindowToolStripMenuItem.Size = New System.Drawing.Size(63, 20)
        Me.WindowToolStripMenuItem.Text = "&Window"
        '
        'ArrangeToolStripMenuItem
        '
        Me.ArrangeToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TileHorizontalToolStripMenuItem, Me.TileVerticalToolStripMenuItem, Me.CascadeToolStripMenuItem, Me.ArrangeIconsToolStripMenuItem})
        Me.ArrangeToolStripMenuItem.Image = CType(resources.GetObject("ArrangeToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ArrangeToolStripMenuItem.Name = "ArrangeToolStripMenuItem"
        Me.ArrangeToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.ArrangeToolStripMenuItem.Text = "&Arrange"
        '
        'TileHorizontalToolStripMenuItem
        '
        Me.TileHorizontalToolStripMenuItem.Image = CType(resources.GetObject("TileHorizontalToolStripMenuItem.Image"), System.Drawing.Image)
        Me.TileHorizontalToolStripMenuItem.Name = "TileHorizontalToolStripMenuItem"
        Me.TileHorizontalToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.TileHorizontalToolStripMenuItem.Text = "Tile &Horizontal"
        '
        'TileVerticalToolStripMenuItem
        '
        Me.TileVerticalToolStripMenuItem.Image = CType(resources.GetObject("TileVerticalToolStripMenuItem.Image"), System.Drawing.Image)
        Me.TileVerticalToolStripMenuItem.Name = "TileVerticalToolStripMenuItem"
        Me.TileVerticalToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.TileVerticalToolStripMenuItem.Text = "Tile &Vertical"
        '
        'CascadeToolStripMenuItem
        '
        Me.CascadeToolStripMenuItem.Image = CType(resources.GetObject("CascadeToolStripMenuItem.Image"), System.Drawing.Image)
        Me.CascadeToolStripMenuItem.Name = "CascadeToolStripMenuItem"
        Me.CascadeToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.CascadeToolStripMenuItem.Text = "&Cascade"
        '
        'ArrangeIconsToolStripMenuItem
        '
        Me.ArrangeIconsToolStripMenuItem.Name = "ArrangeIconsToolStripMenuItem"
        Me.ArrangeIconsToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.ArrangeIconsToolStripMenuItem.Text = "&Arrange Icons"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(149, 6)
        '
        'MinimizeAllToolStripMenuItem
        '
        Me.MinimizeAllToolStripMenuItem.Name = "MinimizeAllToolStripMenuItem"
        Me.MinimizeAllToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.MinimizeAllToolStripMenuItem.Text = "&Minimize All"
        '
        'RestoreAllToolStripMenuItem
        '
        Me.RestoreAllToolStripMenuItem.Name = "RestoreAllToolStripMenuItem"
        Me.RestoreAllToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.RestoreAllToolStripMenuItem.Text = "&Restore All"
        '
        'CloseAllToolStripMenuItem
        '
        Me.CloseAllToolStripMenuItem.Image = Global.PolyMonRT.My.Resources.Resources.Delete
        Me.CloseAllToolStripMenuItem.Name = "CloseAllToolStripMenuItem"
        Me.CloseAllToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.CloseAllToolStripMenuItem.Text = "&Close All"
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AboutToolStripMenuItem})
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.HelpToolStripMenuItem.Text = "&Help"
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Image = Global.PolyMonRT.My.Resources.Resources.InfoSmall
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.AboutToolStripMenuItem.Text = "&About..."
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.tlblUser})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 503)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.StatusStrip1.Size = New System.Drawing.Size(865, 22)
        Me.StatusStrip1.TabIndex = 3
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right
        Me.ToolStripStatusLabel1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.None
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(834, 17)
        Me.ToolStripStatusLabel1.Spring = True
        Me.ToolStripStatusLabel1.Text = "ToolStripStatusLabel1"
        '
        'tlblUser
        '
        Me.tlblUser.Image = CType(resources.GetObject("tlblUser.Image"), System.Drawing.Image)
        Me.tlblUser.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.tlblUser.IsLink = True
        Me.tlblUser.LinkBehavior = System.Windows.Forms.LinkBehavior.AlwaysUnderline
        Me.tlblUser.Name = "tlblUser"
        Me.tlblUser.Size = New System.Drawing.Size(16, 17)
        Me.tlblUser.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.tlblUser.ToolTipText = "Current User"
        '
        'frmMDIMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(865, 525)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.mnuMain)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.mnuMain
        Me.Name = "frmMDIMain"
        Me.Text = "PolyMonRT"
        Me.mnuMain.ResumeLayout(False)
        Me.mnuMain.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents mnuMain As System.Windows.Forms.MenuStrip
    Friend WithEvents miFileMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miLoadDashboard As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miNewDashboard As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miSep1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents miSaveAll As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents tlblUser As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents WindowToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AboutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ArrangeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents MinimizeAllToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TileHorizontalToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TileVerticalToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CascadeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ArrangeIconsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RestoreAllToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CloseAllToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
