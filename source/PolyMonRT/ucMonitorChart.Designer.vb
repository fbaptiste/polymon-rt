<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucMonitorChart
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
        Me.components = New System.ComponentModel.Container
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.miMonitorOptions = New System.Windows.Forms.ToolStripDropDownButton
        Me.miStyle = New System.Windows.Forms.ToolStripMenuItem
        Me.miStyleChart = New System.Windows.Forms.ToolStripMenuItem
        Me.miStyleGauge = New System.Windows.Forms.ToolStripMenuItem
        Me.miStyleLED = New System.Windows.Forms.ToolStripMenuItem
        Me.miStyleStatusLight = New System.Windows.Forms.ToolStripMenuItem
        Me.miStyleCylinder = New System.Windows.Forms.ToolStripMenuItem
        Me.miStartStopSampling = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.miProperties = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.miClone = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
        Me.miClearResults = New System.Windows.Forms.ToolStripMenuItem
        Me.miDeleteMonitor = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuStats_Min = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuStats_Avg = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuStats_Max = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuStats_Elapsed = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuStats_NumSamples = New System.Windows.Forms.ToolStripMenuItem
        Me.tbtnStartStop = New System.Windows.Forms.ToolStripButton
        Me.tlblMonitorName = New System.Windows.Forms.ToolStripLabel
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.tslStatus = New System.Windows.Forms.ToolStripStatusLabel
        Me.TimerSample = New System.Windows.Forms.Timer(Me.components)
        Me.zgTrace = New ZedGraph.ZedGraphControl
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.CylinderGauge1 = New PolyMonRT.ucCylinderGauge
        Me.StatusLight1 = New PolyMonRT.ucStatusLightSingle
        Me.LEDGauge1 = New PolyMonRT.ucLEDGauge
        Me.gaugeSample = New PolyMonRT.ucGauge
        Me.ToolStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.AutoSize = False
        Me.ToolStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(126, Byte), Integer), CType(CType(166, Byte), Integer), CType(CType(225, Byte), Integer))
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miMonitorOptions, Me.tbtnStartStop, Me.tlblMonitorName})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.ToolStrip1.Size = New System.Drawing.Size(380, 25)
        Me.ToolStrip1.TabIndex = 1
        '
        'miMonitorOptions
        '
        Me.miMonitorOptions.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.miMonitorOptions.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.miMonitorOptions.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miStyle, Me.miStartStopSampling, Me.ToolStripSeparator1, Me.miProperties, Me.ToolStripSeparator2, Me.miClone, Me.ToolStripSeparator3, Me.miClearResults, Me.miDeleteMonitor, Me.ToolStripSeparator4, Me.ToolStripSeparator5, Me.ToolStripMenuItem1, Me.mnuStats_Min, Me.mnuStats_Avg, Me.mnuStats_Max, Me.mnuStats_Elapsed, Me.mnuStats_NumSamples})
        Me.miMonitorOptions.Image = Global.PolyMonRT.My.Resources.Resources.Gear
        Me.miMonitorOptions.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.miMonitorOptions.Name = "miMonitorOptions"
        Me.miMonitorOptions.Size = New System.Drawing.Size(29, 22)
        Me.miMonitorOptions.Text = "Monitor Options"
        Me.miMonitorOptions.ToolTipText = "Monitor Options"
        '
        'miStyle
        '
        Me.miStyle.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miStyleChart, Me.miStyleGauge, Me.miStyleLED, Me.miStyleStatusLight, Me.miStyleCylinder})
        Me.miStyle.Image = Global.PolyMonRT.My.Resources.Resources.Chart1
        Me.miStyle.Name = "miStyle"
        Me.miStyle.Size = New System.Drawing.Size(153, 22)
        Me.miStyle.Text = "St&yle"
        Me.miStyle.ToolTipText = "Choose Display Style"
        '
        'miStyleChart
        '
        Me.miStyleChart.Name = "miStyleChart"
        Me.miStyleChart.Size = New System.Drawing.Size(179, 22)
        Me.miStyleChart.Text = "&Trace"
        Me.miStyleChart.ToolTipText = "Trace Style"
        '
        'miStyleGauge
        '
        Me.miStyleGauge.Name = "miStyleGauge"
        Me.miStyleGauge.Size = New System.Drawing.Size(179, 22)
        Me.miStyleGauge.Text = "&Dial Gauge"
        Me.miStyleGauge.ToolTipText = "Dial Gauge Style"
        '
        'miStyleLED
        '
        Me.miStyleLED.Name = "miStyleLED"
        Me.miStyleLED.Size = New System.Drawing.Size(179, 22)
        Me.miStyleLED.Text = "&LED Gauge"
        Me.miStyleLED.ToolTipText = "LED Gauge Style"
        '
        'miStyleStatusLight
        '
        Me.miStyleStatusLight.Name = "miStyleStatusLight"
        Me.miStyleStatusLight.Size = New System.Drawing.Size(179, 22)
        Me.miStyleStatusLight.Text = "&Status Light (Single)"
        '
        'miStyleCylinder
        '
        Me.miStyleCylinder.Name = "miStyleCylinder"
        Me.miStyleCylinder.Size = New System.Drawing.Size(179, 22)
        Me.miStyleCylinder.Text = "Cylinder Gauge"
        '
        'miStartStopSampling
        '
        Me.miStartStopSampling.Image = Global.PolyMonRT.My.Resources.Resources.Pause
        Me.miStartStopSampling.Name = "miStartStopSampling"
        Me.miStartStopSampling.Size = New System.Drawing.Size(153, 22)
        Me.miStartStopSampling.Text = "&Start/Stop"
        Me.miStartStopSampling.ToolTipText = "Start/Stop monitoring"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(150, 6)
        '
        'miProperties
        '
        Me.miProperties.Image = Global.PolyMonRT.My.Resources.Resources.Properties
        Me.miProperties.Name = "miProperties"
        Me.miProperties.Size = New System.Drawing.Size(153, 22)
        Me.miProperties.Text = "&Properties"
        Me.miProperties.ToolTipText = "Modify Monitor Properties"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(150, 6)
        '
        'miClone
        '
        Me.miClone.Name = "miClone"
        Me.miClone.Size = New System.Drawing.Size(153, 22)
        Me.miClone.Text = "&Clone Monitor"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(150, 6)
        '
        'miClearResults
        '
        Me.miClearResults.Name = "miClearResults"
        Me.miClearResults.Size = New System.Drawing.Size(153, 22)
        Me.miClearResults.Text = "Clear Results"
        Me.miClearResults.ToolTipText = "Clear all results"
        '
        'miDeleteMonitor
        '
        Me.miDeleteMonitor.Image = Global.PolyMonRT.My.Resources.Resources.Delete
        Me.miDeleteMonitor.Name = "miDeleteMonitor"
        Me.miDeleteMonitor.Size = New System.Drawing.Size(153, 22)
        Me.miDeleteMonitor.Text = "Delete Monitor"
        Me.miDeleteMonitor.ToolTipText = "Delete this monitor"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(150, 6)
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(150, 6)
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.ToolStripMenuItem1.ForeColor = System.Drawing.Color.DarkBlue
        Me.ToolStripMenuItem1.Image = Global.PolyMonRT.My.Resources.Resources.Stats
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(153, 22)
        Me.ToolStripMenuItem1.Text = "Monitor Stats"
        '
        'mnuStats_Min
        '
        Me.mnuStats_Min.ForeColor = System.Drawing.Color.FromArgb(CType(CType(4, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(148, Byte), Integer))
        Me.mnuStats_Min.Name = "mnuStats_Min"
        Me.mnuStats_Min.Size = New System.Drawing.Size(153, 22)
        Me.mnuStats_Min.Text = "Min:"
        '
        'mnuStats_Avg
        '
        Me.mnuStats_Avg.ForeColor = System.Drawing.Color.FromArgb(CType(CType(4, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(148, Byte), Integer))
        Me.mnuStats_Avg.Name = "mnuStats_Avg"
        Me.mnuStats_Avg.Size = New System.Drawing.Size(153, 22)
        Me.mnuStats_Avg.Text = "Avg:"
        '
        'mnuStats_Max
        '
        Me.mnuStats_Max.ForeColor = System.Drawing.Color.FromArgb(CType(CType(4, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(148, Byte), Integer))
        Me.mnuStats_Max.Name = "mnuStats_Max"
        Me.mnuStats_Max.Size = New System.Drawing.Size(153, 22)
        Me.mnuStats_Max.Text = "Max:"
        '
        'mnuStats_Elapsed
        '
        Me.mnuStats_Elapsed.ForeColor = System.Drawing.Color.FromArgb(CType(CType(4, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(148, Byte), Integer))
        Me.mnuStats_Elapsed.Name = "mnuStats_Elapsed"
        Me.mnuStats_Elapsed.Size = New System.Drawing.Size(153, 22)
        Me.mnuStats_Elapsed.Text = "Elapsed:"
        '
        'mnuStats_NumSamples
        '
        Me.mnuStats_NumSamples.ForeColor = System.Drawing.Color.FromArgb(CType(CType(4, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(148, Byte), Integer))
        Me.mnuStats_NumSamples.Name = "mnuStats_NumSamples"
        Me.mnuStats_NumSamples.Size = New System.Drawing.Size(153, 22)
        Me.mnuStats_NumSamples.Text = "# Samples:"
        '
        'tbtnStartStop
        '
        Me.tbtnStartStop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tbtnStartStop.Image = Global.PolyMonRT.My.Resources.Resources.Play
        Me.tbtnStartStop.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tbtnStartStop.Name = "tbtnStartStop"
        Me.tbtnStartStop.Size = New System.Drawing.Size(23, 22)
        Me.tbtnStartStop.Text = "ToolStripButton1"
        Me.tbtnStartStop.ToolTipText = "Start/Stop Monitor"
        '
        'tlblMonitorName
        '
        Me.tlblMonitorName.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tlblMonitorName.Font = New System.Drawing.Font("Arial Narrow", 10.0!, System.Drawing.FontStyle.Bold)
        Me.tlblMonitorName.ForeColor = System.Drawing.Color.FromArgb(CType(CType(4, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(148, Byte), Integer))
        Me.tlblMonitorName.Name = "tlblMonitorName"
        Me.tlblMonitorName.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never
        Me.tlblMonitorName.Size = New System.Drawing.Size(82, 22)
        Me.tlblMonitorName.Text = "Monitor Name"
        Me.tlblMonitorName.ToolTipText = "Monitor Name"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.AllowMerge = False
        Me.StatusStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(126, Byte), Integer), CType(CType(166, Byte), Integer), CType(CType(225, Byte), Integer))
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tslStatus})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 208)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.StatusStrip1.Size = New System.Drawing.Size(380, 22)
        Me.StatusStrip1.Stretch = False
        Me.StatusStrip1.TabIndex = 2
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'tslStatus
        '
        Me.tslStatus.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.tslStatus.Name = "tslStatus"
        Me.tslStatus.Size = New System.Drawing.Size(4, 17)
        '
        'TimerSample
        '
        '
        'zgTrace
        '
        Me.zgTrace.BackColor = System.Drawing.Color.Transparent
        Me.zgTrace.Location = New System.Drawing.Point(281, 19)
        Me.zgTrace.Name = "zgTrace"
        Me.zgTrace.ScrollGrace = 0
        Me.zgTrace.ScrollMaxX = 0
        Me.zgTrace.ScrollMaxY = 0
        Me.zgTrace.ScrollMaxY2 = 0
        Me.zgTrace.ScrollMinX = 0
        Me.zgTrace.ScrollMinY = 0
        Me.zgTrace.ScrollMinY2 = 0
        Me.zgTrace.Size = New System.Drawing.Size(139, 112)
        Me.zgTrace.TabIndex = 4
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.CylinderGauge1)
        Me.Panel1.Controls.Add(Me.StatusLight1)
        Me.Panel1.Controls.Add(Me.LEDGauge1)
        Me.Panel1.Controls.Add(Me.zgTrace)
        Me.Panel1.Controls.Add(Me.gaugeSample)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 25)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(380, 183)
        Me.Panel1.TabIndex = 8
        '
        'CylinderGauge1
        '
        Me.CylinderGauge1.GaugeValue = 0
        Me.CylinderGauge1.Legend = "Legend"
        Me.CylinderGauge1.Location = New System.Drawing.Point(193, 19)
        Me.CylinderGauge1.Max = 100
        Me.CylinderGauge1.Min = 0
        Me.CylinderGauge1.Name = "CylinderGauge1"
        Me.CylinderGauge1.OnColor0 = System.Drawing.Color.DodgerBlue
        Me.CylinderGauge1.OnColor1 = System.Drawing.Color.DodgerBlue
        Me.CylinderGauge1.OnColor2 = System.Drawing.Color.DodgerBlue
        Me.CylinderGauge1.Size = New System.Drawing.Size(87, 67)
        Me.CylinderGauge1.TabIndex = 8
        Me.CylinderGauge1.Threshold1 = 0
        Me.CylinderGauge1.Threshold2 = 0
        '
        'StatusLight1
        '
        Me.StatusLight1.GaugeValue = -1
        Me.StatusLight1.Legend = "Legend"
        Me.StatusLight1.Location = New System.Drawing.Point(193, 95)
        Me.StatusLight1.MinimumSize = New System.Drawing.Size(50, 50)
        Me.StatusLight1.Name = "StatusLight1"
        Me.StatusLight1.OnColor0 = System.Drawing.Color.Green
        Me.StatusLight1.OnColor1 = System.Drawing.Color.Orange
        Me.StatusLight1.OnColor2 = System.Drawing.Color.Red
        Me.StatusLight1.Size = New System.Drawing.Size(72, 72)
        Me.StatusLight1.TabIndex = 7
        Me.StatusLight1.Threshold1 = 50
        Me.StatusLight1.Threshold2 = 75
        '
        'LEDGauge1
        '
        Me.LEDGauge1.GaugeValue = 85
        Me.LEDGauge1.LEDCount = 15
        Me.LEDGauge1.Legend = "Legend"
        Me.LEDGauge1.Location = New System.Drawing.Point(22, 15)
        Me.LEDGauge1.Name = "LEDGauge1"
        Me.LEDGauge1.OnColor0 = System.Drawing.Color.RoyalBlue
        Me.LEDGauge1.OnColor1 = System.Drawing.Color.Orange
        Me.LEDGauge1.OnColor2 = System.Drawing.Color.Red
        Me.LEDGauge1.Orientation = PolyMonControls.LEDGauge.Orientation.Vertical
        Me.LEDGauge1.ScaleMax = 100
        Me.LEDGauge1.ScaleMin = 0
        Me.LEDGauge1.Size = New System.Drawing.Size(73, 173)
        Me.LEDGauge1.TabIndex = 6
        Me.LEDGauge1.Threshold1 = 45
        Me.LEDGauge1.Threshold2 = 75
        '
        'gaugeSample
        '
        Me.gaugeSample.BackColor = System.Drawing.Color.White
        Me.gaugeSample.DialColor = System.Drawing.Color.LightGreen
        Me.gaugeSample.GaugeBackColor = System.Drawing.Color.White
        Me.gaugeSample.Legend = ""
        Me.gaugeSample.Location = New System.Drawing.Point(69, 15)
        Me.gaugeSample.MajorScaleStepSize = 10.0!
        Me.gaugeSample.MaxValue = 100.0!
        Me.gaugeSample.MinimumSize = New System.Drawing.Size(140, 120)
        Me.gaugeSample.MinValue = 0.0!
        Me.gaugeSample.Name = "gaugeSample"
        Me.gaugeSample.Size = New System.Drawing.Size(140, 120)
        Me.gaugeSample.TabIndex = 5
        '
        'ucMonitorChart
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Transparent
        Me.CausesValidation = False
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.DoubleBuffered = True
        Me.Margin = New System.Windows.Forms.Padding(0)
        Me.MinimumSize = New System.Drawing.Size(380, 230)
        Me.Name = "ucMonitorChart"
        Me.Size = New System.Drawing.Size(380, 230)
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents miMonitorOptions As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents miStyle As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miStartStopSampling As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents TimerSample As System.Windows.Forms.Timer
    Friend WithEvents tslStatus As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents miStyleChart As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miStyleGauge As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miClearResults As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents miProperties As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents miDeleteMonitor As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tlblMonitorName As System.Windows.Forms.ToolStripLabel
    Friend WithEvents zgTrace As ZedGraph.ZedGraphControl
    Friend WithEvents gaugeSample As PolyMonRT.ucGauge
    Friend WithEvents miClone As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents miStyleLED As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuStats_Min As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuStats_Avg As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuStats_Max As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuStats_Elapsed As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuStats_NumSamples As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tbtnStartStop As System.Windows.Forms.ToolStripButton
    Friend WithEvents miStyleStatusLight As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents LEDGauge1 As PolyMonRT.ucLEDGauge
    Friend WithEvents StatusLight1 As PolyMonRT.ucStatusLightSingle
    Friend WithEvents CylinderGauge1 As PolyMonRT.ucCylinderGauge
    Friend WithEvents miStyleCylinder As System.Windows.Forms.ToolStripMenuItem

End Class
