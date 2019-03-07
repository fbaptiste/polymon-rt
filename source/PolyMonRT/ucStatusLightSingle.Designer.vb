<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucStatusLightSingle
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.lblLegend = New System.Windows.Forms.Label
        Me.StatusLight1 = New PolyMonControls.StatusLight
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2
        Me.SplitContainer1.IsSplitterFixed = True
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.StatusLight1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.lblLegend)
        Me.SplitContainer1.Panel2MinSize = 20
        Me.SplitContainer1.Size = New System.Drawing.Size(100, 100)
        Me.SplitContainer1.SplitterDistance = 76
        Me.SplitContainer1.TabIndex = 0
        '
        'lblLegend
        '
        Me.lblLegend.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblLegend.Location = New System.Drawing.Point(0, 0)
        Me.lblLegend.Name = "lblLegend"
        Me.lblLegend.Size = New System.Drawing.Size(100, 20)
        Me.lblLegend.TabIndex = 0
        Me.lblLegend.Text = "Legend"
        Me.lblLegend.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'StatusLight1
        '
        Me.StatusLight1.BackColor = System.Drawing.Color.Transparent
        Me.StatusLight1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.StatusLight1.Location = New System.Drawing.Point(0, 0)
        Me.StatusLight1.Name = "StatusLight1"
        Me.StatusLight1.Size = New System.Drawing.Size(100, 76)
        Me.StatusLight1.TabIndex = 0
        '
        'ucStatusLightSingle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.SplitContainer1)
        Me.MinimumSize = New System.Drawing.Size(50, 50)
        Me.Name = "ucStatusLightSingle"
        Me.Size = New System.Drawing.Size(100, 100)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents lblLegend As System.Windows.Forms.Label
    Friend WithEvents StatusLight1 As PolyMonControls.StatusLight

End Class
