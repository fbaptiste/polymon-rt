<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucLEDGauge
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
        Me.lblLegend = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.GradientPanel1 = New PolyMonControls.GradientPanel
        Me.LedGauge1 = New PolyMonControls.LEDGauge
        Me.Panel1.SuspendLayout()
        Me.GradientPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblLegend
        '
        Me.lblLegend.AutoEllipsis = True
        Me.lblLegend.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.lblLegend.Location = New System.Drawing.Point(0, 150)
        Me.lblLegend.Name = "lblLegend"
        Me.lblLegend.Size = New System.Drawing.Size(73, 23)
        Me.lblLegend.TabIndex = 1
        Me.lblLegend.Text = "Legend"
        Me.lblLegend.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.GradientPanel1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(73, 150)
        Me.Panel1.TabIndex = 3
        '
        'GradientPanel1
        '
        Me.GradientPanel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GradientPanel1.BackColor1 = System.Drawing.Color.LightSteelBlue
        Me.GradientPanel1.BackColor2 = System.Drawing.Color.DarkBlue
        Me.GradientPanel1.BorderColor = System.Drawing.Color.DodgerBlue
        Me.GradientPanel1.BorderWidth = 1
        Me.GradientPanel1.Controls.Add(Me.LedGauge1)
        Me.GradientPanel1.GradientOrientation = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.GradientPanel1.Location = New System.Drawing.Point(21, 3)
        Me.GradientPanel1.Name = "GradientPanel1"
        Me.GradientPanel1.Padding = New System.Windows.Forms.Padding(5)
        Me.GradientPanel1.Size = New System.Drawing.Size(30, 142)
        Me.GradientPanel1.TabIndex = 1
        '
        'LedGauge1
        '
        Me.LedGauge1.BackColor = System.Drawing.Color.Transparent
        Me.LedGauge1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LedGauge1.LEDCount = 15
        Me.LedGauge1.LEDOnColor0 = System.Drawing.Color.RoyalBlue
        Me.LedGauge1.LEDOrientation = PolyMonControls.LEDGauge.Orientation.Vertical
        Me.LedGauge1.Location = New System.Drawing.Point(5, 5)
        Me.LedGauge1.Name = "LedGauge1"
        Me.LedGauge1.ScaleMin = 0
        Me.LedGauge1.Size = New System.Drawing.Size(20, 132)
        Me.LedGauge1.TabIndex = 0
        Me.LedGauge1.Text = "LedGauge2"
        '
        'ucLEDGauge
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.lblLegend)
        Me.Name = "ucLEDGauge"
        Me.Size = New System.Drawing.Size(73, 173)
        Me.Panel1.ResumeLayout(False)
        Me.GradientPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblLegend As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents GradientPanel1 As PolyMonControls.GradientPanel
    Friend WithEvents LedGauge1 As PolyMonControls.LEDGauge

End Class
