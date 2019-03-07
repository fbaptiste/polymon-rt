<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucGauge
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
        Me.Gauge1 = New AGaugeApp.AGauge
        Me.SuspendLayout()
        '
        'lblLegend
        '
        Me.lblLegend.AutoEllipsis = True
        Me.lblLegend.BackColor = System.Drawing.Color.Transparent
        Me.lblLegend.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.lblLegend.Location = New System.Drawing.Point(0, 134)
        Me.lblLegend.Name = "lblLegend"
        Me.lblLegend.Size = New System.Drawing.Size(173, 23)
        Me.lblLegend.TabIndex = 7
        Me.lblLegend.Text = "Legend"
        Me.lblLegend.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Gauge1
        '
        Me.Gauge1.BackColor = System.Drawing.Color.White
        Me.Gauge1.BaseArcColor = System.Drawing.Color.Gray
        Me.Gauge1.BaseArcRadius = 45
        Me.Gauge1.BaseArcStart = 130
        Me.Gauge1.BaseArcSweep = 280
        Me.Gauge1.BaseArcWidth = 1
        Me.Gauge1.Cap_Idx = CType(0, Byte)
        Me.Gauge1.CapColors = New System.Drawing.Color() {System.Drawing.Color.Black, System.Drawing.Color.Black, System.Drawing.Color.Black, System.Drawing.Color.Black, System.Drawing.Color.Black}
        Me.Gauge1.CapPosition = New System.Drawing.Point(10, 10)
        Me.Gauge1.CapsPosition = New System.Drawing.Point() {New System.Drawing.Point(10, 10), New System.Drawing.Point(10, 10), New System.Drawing.Point(10, 10), New System.Drawing.Point(10, 10), New System.Drawing.Point(10, 10)}
        Me.Gauge1.CapsText = New String() {"", "", "", "", ""}
        Me.Gauge1.CapText = ""
        Me.Gauge1.Center = New System.Drawing.Point(90, 80)
        Me.Gauge1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Gauge1.Location = New System.Drawing.Point(0, 0)
        Me.Gauge1.MaxValue = 100.0!
        Me.Gauge1.MinValue = 0.0!
        Me.Gauge1.Name = "Gauge1"
        Me.Gauge1.NeedleColor1 = AGaugeApp.AGauge.NeedleColorEnum.Blue
        Me.Gauge1.NeedleColor2 = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Gauge1.NeedleRadius = 60
        Me.Gauge1.NeedleType = 0
        Me.Gauge1.NeedleWidth = 3
        Me.Gauge1.Range_Idx = CType(2, Byte)
        Me.Gauge1.RangeColor = System.Drawing.Color.Red
        Me.Gauge1.RangeEnabled = True
        Me.Gauge1.RangeEndValue = 100.0!
        Me.Gauge1.RangeInnerRadius = 45
        Me.Gauge1.RangeOuterRadius = 60
        Me.Gauge1.RangesColor = New System.Drawing.Color() {System.Drawing.Color.LightGreen, System.Drawing.Color.DarkOrange, System.Drawing.Color.Red, System.Drawing.SystemColors.Control, System.Drawing.SystemColors.Control}
        Me.Gauge1.RangesEnabled = New Boolean() {True, True, True, False, False}
        Me.Gauge1.RangesEndValue = New Single() {100.0!, 80.0!, 100.0!, 0.0!, 0.0!}
        Me.Gauge1.RangesInnerRadius = New Integer() {45, 45, 45, 70, 70}
        Me.Gauge1.RangesOuterRadius = New Integer() {60, 60, 60, 80, 80}
        Me.Gauge1.RangesStartValue = New Single() {0.0!, 50.0!, 80.0!, 0.0!, 0.0!}
        Me.Gauge1.RangeStartValue = 80.0!
        Me.Gauge1.ScaleLinesInterColor = System.Drawing.Color.Black
        Me.Gauge1.ScaleLinesInterInnerRadius = 60
        Me.Gauge1.ScaleLinesInterOuterRadius = 60
        Me.Gauge1.ScaleLinesInterWidth = 0
        Me.Gauge1.ScaleLinesMajorColor = System.Drawing.Color.Black
        Me.Gauge1.ScaleLinesMajorInnerRadius = 45
        Me.Gauge1.ScaleLinesMajorOuterRadius = 56
        Me.Gauge1.ScaleLinesMajorStepValue = 10.0!
        Me.Gauge1.ScaleLinesMajorWidth = 1
        Me.Gauge1.ScaleLinesMinorColor = System.Drawing.Color.Gray
        Me.Gauge1.ScaleLinesMinorInnerRadius = 45
        Me.Gauge1.ScaleLinesMinorNumOf = 4
        Me.Gauge1.ScaleLinesMinorOuterRadius = 50
        Me.Gauge1.ScaleLinesMinorWidth = 1
        Me.Gauge1.ScaleNumbersColor = System.Drawing.Color.Black
        Me.Gauge1.ScaleNumbersFormat = "####0"
        Me.Gauge1.ScaleNumbersRadius = 70
        Me.Gauge1.ScaleNumbersRotation = 0
        Me.Gauge1.ScaleNumbersStartScaleLine = 0
        Me.Gauge1.ScaleNumbersStepScaleLines = 1
        Me.Gauge1.Size = New System.Drawing.Size(173, 157)
        Me.Gauge1.TabIndex = 6
        Me.Gauge1.Text = "AGauge1"
        Me.Gauge1.Value = 62.0!
        '
        'ucGauge
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.lblLegend)
        Me.Controls.Add(Me.Gauge1)
        Me.Name = "ucGauge"
        Me.Size = New System.Drawing.Size(173, 157)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Gauge1 As AGaugeApp.AGauge
    Friend WithEvents lblLegend As System.Windows.Forms.Label

End Class
