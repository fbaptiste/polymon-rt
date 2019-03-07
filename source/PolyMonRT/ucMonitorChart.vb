Imports System.Diagnostics
Imports ZedGraph
Imports PolyMonRT.PolyMonTypes
Imports System.Xml
Imports System.Drawing

Public Class ucMonitorChart

#Region "Private Attributes"
    Private _ResizeFudge As Integer = 15 'how far away from bottom right ocrner of UC to be considered the size handle area
    Private _IsResizing As Boolean = False
    Private _IsInResizeZone As Boolean = False
    Private _ResizeOffsetPt As System.Drawing.Point

    Private _IsPaused As Boolean = False


    Private _PanelBrdSize As Integer = 2
    Private _PanelBrdColor As Color = Color.DarkSlateBlue


    Private _DisplayStyle As DisplayStyles = DisplayStyles.Trace
    Private _Size As System.Drawing.Size
    Private _Location As System.Drawing.Point

    Private _ChartPoints As ZedGraph.RollingPointPairList

    Private _MonitorID As Integer
    Private _IsNew As Boolean = True

    Private _PC As Object = Nothing

    Private _MonitorName As String
    Private _MonitorType As MonitorTypes
    Private _MonitorXMLParams As String = ControlChars.Tab & "<MonitorSettings/>"
    Private _RunState As RunStates

    Private _msFreq As Integer = My.Settings.DefaultTimerInterval
    Private _Retention As Integer = My.Settings.DefaultTraceRetentionPts
    Private _RangeScaling As Double = 1
    Private _RangeLegend As String = Nothing

    Private _Threshold1 As New Threshold(False, 75, Color.DarkOrange)
    Private _Threshold2 As New Threshold(False, 90, Color.Red)
    Private _TraceLine1 As ZedGraph.LineObj
    Private _TraceLine2 As ZedGraph.LineObj

    Private _DialColor As Color = Color.LightGreen
    Private _DialMinimum As Double = 0
    Private _DialMaximum As Double = 100
    Private _DialStep As Double = 10
    Private _GaugeOrientation As PolyMonTypes.GaugeOrientations = GaugeOrientations.Vertical

    Private _SamplePrevResult As Single = 0
    Private _SamplePrevDT As Date = Now()
    Private _SampleCnt As Integer = 0
    Private _SampleSum As Double = 0
    Private _SampleMin As Single = Single.PositiveInfinity
    Private _SampleMax As Single = Single.NegativeInfinity
    Private _SampleStartDT As Date = Now()
#End Region

#Region "Class Creation"
    Public Sub New(ByVal MonitorID As Integer, ByVal StartPaused As Boolean)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        RunState = RunStates.Stopped
        IsPaused = StartPaused
        _MonitorID = MonitorID
        _IsNew = True
        InitControl()
    End Sub
    Public Sub New(ByVal MonitorXML As System.Xml.XmlNode, ByVal StartPaused As Boolean)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        RunState = RunStates.Stopped
        IsPaused = StartPaused
        _IsNew = False
        InitControl()

        LoadSettings(MonitorXML)
    End Sub
    Private Sub LoadSettings(ByVal MonitorDefXML As System.Xml.XmlNode)
        'Deserialize XML into class attributes
        Deserialize(MonitorDefXML)

        'Next update display accordingly
        RefreshMonitorSettings()
    End Sub

    Private Sub RefreshMonitorSettings()
        'Monitor Name
        tlblMonitorName.Text = _MonitorName

        'Monitor XML Params
        Dim xmlDoc As New System.Xml.XmlDocument
        xmlDoc.LoadXml(_MonitorXMLParams)

        'MONITORHOOK: Handle new Monitor types here
        'Monitor Type
        Select Case _MonitorType
            Case MonitorTypes.PerfMon
                _PC = New PolyMonMonitors.PerfMon(xmlDoc.DocumentElement)
            Case MonitorTypes.SQLMonitor
                _PC = New PolyMonMonitors.SQLMonitor(xmlDoc.DocumentElement)
            Case MonitorTypes.Ping
                _PC = New PolyMonMonitors.SQLMonitor(xmlDoc.DocumentElement)
            Case MonitorTypes.PowerShell
                _PC = New PolyMonMonitors.PowerShellMonitor(xmlDoc.DocumentElement)
        End Select

        'Polling Interval
        TimerSample.Interval = _msFreq

        'Retention Period
        ChangeChartCapacity(_Retention)


        'Range Legend
        gaugeSample.Legend = _RangeLegend
        LEDGauge1.Legend = _RangeLegend
        StatusLight1.Legend = _RangeLegend
        CylinderGauge1.Legend = _RangeLegend
        zgTrace.GraphPane.XAxis.Title.Text = _RangeLegend


        'Gauge Color
        gaugeSample.DialColor = _DialColor
        LEDGauge1.OnColor0 = _DialColor
        StatusLight1.OnColor0 = _DialColor
        CylinderGauge1.OnColor0 = _DialColor

        'Gauge Min Value
        gaugeSample.MinValue = CSng(_DialMinimum)
        LEDGauge1.ScaleMin = _DialMinimum
        CylinderGauge1.Min = _DialMinimum

        'Gauge Max Value
        gaugeSample.MaxValue = CSng(_DialMaximum)
        LEDGauge1.ScaleMax = _DialMaximum
        CylinderGauge1.Max = _DialMaximum

        'GaugeOrientation
        If _GaugeOrientation = GaugeOrientations.Vertical Then
            LEDGauge1.Orientation = PolyMonControls.LEDGauge.Orientation.Vertical
        Else
            LEDGauge1.Orientation = PolyMonControls.LEDGauge.Orientation.Horizontal
        End If

        'Dial Step
        gaugeSample.MajorScaleStepSize = CSng(_DialStep)

        'Threshold 1
        gaugeSample.Range1.RangeColor = _Threshold1.Color
        gaugeSample.Range1.Enabled = _Threshold1.Enabled
        gaugeSample.Range1.StartValue = CSng(_Threshold1.Value)
        If _Threshold2.Enabled Then
            gaugeSample.Range1.EndValue = CSng(_Threshold2.Value)
        Else
            gaugeSample.Range1.EndValue = CSng(_DialMaximum)
        End If

        'Threshold 2
        gaugeSample.Range2.RangeColor = _Threshold2.Color
        gaugeSample.Range2.Enabled = _Threshold2.Enabled
        gaugeSample.Range2.StartValue = CSng(_Threshold2.Value)
        gaugeSample.Range2.EndValue = CSng(_DialMaximum)

        'LED/Cylinder/Status Light thresholds
        If _Threshold1.Enabled Then
            LEDGauge1.Threshold1 = _Threshold1.Value
            LEDGauge1.OnColor1 = _Threshold1.Color

            StatusLight1.Threshold1 = _Threshold1.Value
            StatusLight1.OnColor1 = _Threshold1.Color

            CylinderGauge1.Threshold1 = _Threshold1.Value
            CylinderGauge1.OnColor1 = _Threshold1.Color
        Else
            LEDGauge1.OnColor1 = _DialColor
            StatusLight1.OnColor1 = _DialColor
            CylinderGauge1.OnColor1 = _DialColor
        End If
        If _Threshold2.Enabled Then
            LEDGauge1.Threshold2 = _Threshold2.Value
            LEDGauge1.OnColor2 = _Threshold2.Color

            StatusLight1.Threshold2 = _Threshold2.Value
            StatusLight1.OnColor2 = _Threshold2.Color

            CylinderGauge1.Threshold2 = _Threshold2.Value
            CylinderGauge1.OnColor2 = _Threshold2.Color
        Else
            LEDGauge1.OnColor2 = _Threshold1.Color
            StatusLight1.OnColor2 = _Threshold1.Color
            CylinderGauge1.OnColor2 = _Threshold1.Color
        End If



        'Add Threshold lines to Trace chart
        AddTraceThresholdLines(_Threshold1.Enabled, _Threshold1.Color, _Threshold1.Value, _Threshold2.Enabled, _Threshold2.Color, _Threshold2.Value)




        'Display Style
        DisplayStyle = Me._DisplayStyle

        'Location
        Me.Location = New Point(_Location.X, _Location.Y)

        'Width
        Me.Size = New Size(_Size.Width, _Size.Height)

        'RunState
        RunState = Me._RunState

    End Sub
   

    Private Sub InitControl()
        Me.Width = My.Settings.DefaultMCChartStyleWidth
        Me.Height = My.Settings.DefaultMCChartStyleHeight
        DisplayStyle = DisplayStyles.Trace 'default to Trace style

        Me.MinimumSize = New Size(60, ToolStrip1.Height + StatusStrip1.Height + 50)

        'Setup Timer
        TimerSample.Interval = _msFreq
        RunState = RunStates.Stopped


        'Set up Chart controls
        _ChartPoints = New RollingPointPairList(_Retention)

        With zgTrace
            .Dock = DockStyle.Fill
            .BorderStyle = Windows.Forms.BorderStyle.None
            .GraphPane.Border.IsVisible = False
            .BackColor = Color.Transparent
            .GraphPane.Chart.Fill.Color = System.Drawing.Color.FromArgb(CType(CType(203, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(252, Byte), Integer))
            .GraphPane.Chart.Fill.Type = FillType.Solid
            .GraphPane.Fill.Color = System.Drawing.Color.FromArgb(CType(CType(203, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(252, Byte), Integer))
            .GraphPane.Fill.Type = FillType.Solid

            .GraphPane.Title.Text = Nothing
            .GraphPane.Title.IsVisible = False

            .GraphPane.XAxis.Type = ZedGraph.AxisType.Date
            .GraphPane.XAxis.Scale.Format = "HH:mm:ss"
            .GraphPane.XAxis.Title.Text = ""
            .GraphPane.XAxis.Title.FontSpec.IsAntiAlias = True
            .GraphPane.XAxis.Title.FontSpec.Size = 20
            .GraphPane.XAxis.Title.FontSpec.IsBold = False

            .GraphPane.YAxis.Title.Text = ""

            .GraphPane.Legend.IsVisible = False

            Dim SampleCurve As LineItem = .GraphPane.AddCurve("Trace", _ChartPoints, Color.Blue)
            SampleCurve.Symbol.IsVisible = False

            'Draw Threshold Lines
            AddTraceThresholdLines(_Threshold1.Enabled, _Threshold1.Color, _Threshold1.Value, _Threshold2.Enabled, _Threshold2.Color, _Threshold2.Value)

            zgTrace.GraphPane.BaseDimension = 5.5

            .AxisChange()
        End With

        With gaugeSample
            .Dock = DockStyle.Fill
            .MinValue = CSng(_DialMinimum)
            .MaxValue = CSng(_DialMaximum)
            .MajorScaleStepSize = CSng(_DialStep)
            .Legend = _RangeLegend
            .GaugeBackColor = System.Drawing.Color.FromArgb(CType(CType(203, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(252, Byte), Integer))
            .Refresh()
        End With

        With LEDGauge1
            .Dock = DockStyle.Fill
            .ScaleMin = _DialMinimum
            .ScaleMax = _DialMaximum
            .Legend = _RangeLegend
            If _GaugeOrientation = GaugeOrientations.Horizontal Then
                .Orientation = PolyMonControls.LEDGauge.Orientation.Horizontal
            Else
                .Orientation = PolyMonControls.LEDGauge.Orientation.Vertical
            End If
        End With

        With StatusLight1
            .Dock = DockStyle.Fill
            .Legend = _RangeLegend
        End With

        With CylinderGauge1
            .Dock = DockStyle.Fill
            .Legend = _RangeLegend
        End With
        ResetStats()
    End Sub
#End Region

#Region "Public Interface"
    Public Property RunState() As RunStates
        Get
            Return _RunState
        End Get
        Set(ByVal value As RunStates)
            If Not (_IsPaused) Then
                _RunState = value
                Select Case value
                    Case RunStates.Running
                        'Run first sample and start timer
                        TimerSample.Start()

                        'Menu
                        miStartStopSampling.Text = "&Stop"
                        miStartStopSampling.Image = My.Resources._Stop

                        'Toolbar
                        tbtnStartStop.Image = My.Resources._Stop
                        tbtnStartStop.ToolTipText = "Click to Stop monitoring"

                    Case RunStates.Stopped
                        'Stop timer
                        TimerSample.Stop()

                        'Menu
                        miStartStopSampling.Text = "&Start"
                        miStartStopSampling.Image = My.Resources.Play

                        'Toolbar
                        tbtnStartStop.Image = My.Resources.Play
                        tbtnStartStop.ToolTipText = "Click to Start monitoring"
                End Select
            Else
                'Monitoring is Paused at the dashboard level. Do not 
                'respond tho this request
            End If
        End Set
    End Property
    Public Property IsPaused() As Boolean
        Get
            Return _IsPaused
        End Get
        Set(ByVal value As Boolean)
            _IsPaused = value
            If _IsPaused Then
                'In pause mode, sampling is halted and users cannot start/stop sampling
                TimerSample.Stop()

                'Menu
                miStartStopSampling.Text = "Paused"
                miStartStopSampling.Image = My.Resources.Pause
                miStartStopSampling.Enabled = False


                'Toolbar
                tbtnStartStop.Image = My.Resources.Pause
                tbtnStartStop.Enabled = False
                tbtnStartStop.ToolTipText = "Paused at dashboard level"
            Else
                'Unpause
                _IsPaused = False

                'Restore previous run state
                RunState = _RunState


                'Toolbar
                tbtnStartStop.Enabled = True
                miStartStopSampling.Enabled = True
            End If
        End Set
    End Property

    Public ReadOnly Property IsInResizeZone() As Boolean
        Get
            Return _IsInResizeZone
        End Get
    End Property
    Public Property DisplayStyle() As DisplayStyles
        Get
            Return _DisplayStyle
        End Get
        Set(ByVal value As DisplayStyles)
            SetDisplayStyle(value)
        End Set
    End Property

    Public Function Serialize() As String
        Dim xmlSettings As New XmlWriterSettings
        xmlSettings.Indent = True
        xmlSettings.OmitXmlDeclaration = True
        xmlSettings.NewLineOnAttributes = False
        xmlSettings.IndentChars = ControlChars.Tab

        Dim xw As XmlWriter = Nothing
        Dim sbXML As New System.Text.StringBuilder
        xw = XmlWriter.Create(sbXML, xmlSettings)

        With xw
            .WriteStartElement("Monitor")
            .WriteAttributeString("ID", _MonitorID.ToString)


            .WriteElementString("MonitorName", _MonitorName)
            .WriteElementString("MonitorType", _MonitorType.ToString())
            .WriteElementString("RunState", _RunState.ToString)

            .WriteStartElement("Polling")
            .WriteAttributeString("msFreq", _msFreq.ToString())
            .WriteAttributeString("Retention", _Retention.ToString())
            .WriteEndElement() 'Polling

            .WriteStartElement("Range")
            .WriteAttributeString("Scaling", _RangeScaling.ToString())
            .WriteAttributeString("Legend", _RangeLegend)
            .WriteEndElement() 'Range

            .WriteStartElement("Threshold1")
            .WriteAttributeString("Enabled", _Threshold1.Enabled.ToString())
            .WriteAttributeString("Value", _Threshold1.Value.ToString())
            .WriteAttributeString("Color", _Threshold1.Color.ToArgb.ToString())
            .WriteEndElement() 'Threshold1

            .WriteStartElement("Threshold2")
            .WriteAttributeString("Enabled", _Threshold2.Enabled.ToString())
            .WriteAttributeString("Value", _Threshold2.Value.ToString())
            .WriteAttributeString("Color", _Threshold2.Color.ToArgb.ToString())
            .WriteEndElement() 'Threshold2

            .WriteStartElement("Gauge")
            .WriteAttributeString("DialColor", _DialColor.ToArgb().ToString())
            .WriteAttributeString("Orientation", _GaugeOrientation.ToString())
            .WriteAttributeString("DialMinimum", _DialMinimum.ToString())
            .WriteAttributeString("DialMaximum", _DialMaximum.ToString())
            .WriteAttributeString("DialStep", _DialStep.ToString())
            .WriteEndElement() 'Gauge

            .WriteElementString("DisplayStyle", _DisplayStyle.ToString())

            .WriteStartElement("Location")
            .WriteAttributeString("X", Me.Location.X.ToString())
            .WriteAttributeString("Y", Me.Location.Y.ToString())
            .WriteEndElement() 'Location

            .WriteStartElement("Size")
            .WriteAttributeString("Height", Me.Height.ToString())
            .WriteAttributeString("Width", Me.Width.ToString())
            .WriteEndElement() 'Size

            'Insert MonitorSettings XML here
            .WriteRaw(vbCrLf)
            .WriteRaw(_MonitorXMLParams)
            .WriteRaw(vbCrLf)
            .WriteEndElement() 'Monitor

            .Close()
        End With

        Return sbXML.ToString
    End Function
    Private Sub Deserialize(ByVal xmlDef As XmlNode)
        Dim Val As String = Nothing

        'MonitorID
        _MonitorID = CInt(ReadAttributeValue(xmlDef, "ID"))

        'Monitor Name
        _MonitorName = ReadNodeValue(xmlDef.SelectSingleNode("MonitorName"))

        'Monitor Type
        Val = ReadNodeValue(xmlDef.SelectSingleNode("MonitorType"))
        If String.IsNullOrEmpty(Val) Then
            _MonitorType = 0
        Else
            If [Enum].IsDefined(GetType(PolyMonTypes.MonitorTypes), Val) Then
                _MonitorType = CType([Enum].Parse(GetType(PolyMonTypes.MonitorTypes), Val), PolyMonTypes.MonitorTypes)
            Else
                _MonitorType = 0
            End If
        End If

        'Run State
        Val = ReadNodeValue(xmlDef.SelectSingleNode("RunState"))
        If String.IsNullOrEmpty(Val) Then
            _RunState = RunStates.Stopped
        Else
            If [Enum].IsDefined(GetType(PolyMonTypes.RunStates), Val) Then
                _RunState = CType([Enum].Parse(GetType(PolyMonTypes.RunStates), Val), PolyMonTypes.RunStates)
            Else
                _RunState = RunStates.Stopped
            End If
        End If

        'Polling Frequency
        Val = ReadAttributeValue(xmlDef.SelectSingleNode("Polling"), "msFreq")
        If (Not String.IsNullOrEmpty(Val)) AndAlso IsNumeric(Val) AndAlso CInt(Val) > 0 Then
            _msFreq = CInt(Val)
        End If

        'Polling Retention
        Val = ReadAttributeValue(xmlDef.SelectSingleNode("Polling"), "Retention")
        If (Not String.IsNullOrEmpty(Val)) AndAlso IsNumeric(Val) AndAlso CInt(Val) > 0 AndAlso CInt(Val) < My.Settings.MaxRetentionPts Then
            _Retention = CInt(Val)
        End If

        'Range Scaling
        Val = ReadAttributeValue(xmlDef.SelectSingleNode("Range"), "Scaling")
        If (Not String.IsNullOrEmpty(Val)) AndAlso IsNumeric(Val) AndAlso CDbl(Val) > 0 Then
            _RangeScaling = CDbl(Val)
        End If

        'Range Legend
        _RangeLegend = ReadAttributeValue(xmlDef.SelectSingleNode("Range"), "Legend")

        'Threshold 1 - Enabled
        Val = ReadAttributeValue(xmlDef.SelectSingleNode("Threshold1"), "Enabled")
        If Not (String.IsNullOrEmpty(Val)) Then
            Try
                _Threshold1.Enabled = CBool(Val)
            Catch ex As Exception
                'let default take over
            End Try
        End If

        'Threshold 2 - Enabled
        Val = ReadAttributeValue(xmlDef.SelectSingleNode("Threshold2"), "Enabled")
        If Not (String.IsNullOrEmpty(Val)) Then
            Try
                _Threshold2.Enabled = CBool(Val)
            Catch ex As Exception
                'Let default take over
            End Try
        End If

        'Threshold 1 - Value
        Val = ReadAttributeValue(xmlDef.SelectSingleNode("Threshold1"), "Value")
        If (Not String.IsNullOrEmpty(Val)) AndAlso IsNumeric(Val) Then
            _Threshold1.Value = CDbl(Val)
        End If

        'Threshold 2 - Value
        Val = ReadAttributeValue(xmlDef.SelectSingleNode("Threshold2"), "Value")
        If (Not String.IsNullOrEmpty(Val)) AndAlso IsNumeric(Val) Then
            _Threshold2.Value = CDbl(Val)
        End If

        'Threshold 1 - Color
        Val = ReadAttributeValue(xmlDef.SelectSingleNode("Threshold1"), "Color")
        If (Not String.IsNullOrEmpty(Val)) AndAlso IsNumeric(Val) Then
            Try
                _Threshold1.Color = System.Drawing.Color.FromArgb(CInt(Val))
            Catch ex As Exception
                'Let default take over
            End Try
        End If

        'Threshold 2 - Color
        Val = ReadAttributeValue(xmlDef.SelectSingleNode("Threshold2"), "Color")
        If (Not String.IsNullOrEmpty(Val)) AndAlso IsNumeric(Val) Then
            Try
                _Threshold2.Color = System.Drawing.Color.FromArgb(CInt(Val))
            Catch ex As Exception
                'Let default take over
            End Try
        End If

        'Gauge - DialColor
        Val = ReadAttributeValue(xmlDef.SelectSingleNode("Gauge"), "DialColor")
        If (Not String.IsNullOrEmpty(Val)) AndAlso IsNumeric(Val) Then
            Try
                _DialColor = System.Drawing.Color.FromArgb(CInt(Val))
            Catch ex As Exception
                'Let default take over
            End Try
        End If

        'Gauge - Orientation
        Val = ReadAttributeValue(xmlDef.SelectSingleNode("Gauge"), "Orientation")
        If String.IsNullOrEmpty(Val) Then
            _GaugeOrientation = GaugeOrientations.Vertical
        Else
            If [Enum].IsDefined(GetType(PolyMonTypes.GaugeOrientations), Val) Then
                _GaugeOrientation = CType([Enum].Parse(GetType(PolyMonTypes.GaugeOrientations), Val), PolyMonTypes.GaugeOrientations)
            Else
                _GaugeOrientation = GaugeOrientations.Vertical
            End If
        End If

        'Gauge - DialMinimum
        Val = ReadAttributeValue(xmlDef.SelectSingleNode("Gauge"), "DialMinimum")
        If (Not String.IsNullOrEmpty(Val)) AndAlso IsNumeric(Val) Then
            _DialMinimum = CDbl(Val)
        End If

        'Gauge - DialMaximum
        Val = ReadAttributeValue(xmlDef.SelectSingleNode("Gauge"), "DialMaximum")
        If (Not String.IsNullOrEmpty(Val)) AndAlso IsNumeric(Val) Then
            _DialMaximum = CDbl(Val)
        End If

        'Gauge - DialStep
        Val = ReadAttributeValue(xmlDef.SelectSingleNode("Gauge"), "DialStep")
        If (Not String.IsNullOrEmpty(Val)) AndAlso IsNumeric(Val) Then
            _DialStep = CDbl(Val)
        End If

        'DisplayStyle
        Val = ReadNodeValue(xmlDef.SelectSingleNode("DisplayStyle"))
        If String.IsNullOrEmpty(Val) Then
            _DisplayStyle = DisplayStyles.Trace
        Else
            If [Enum].IsDefined(GetType(PolyMonTypes.DisplayStyles), Val) Then
                _DisplayStyle = CType([Enum].Parse(GetType(PolyMonTypes.DisplayStyles), Val), PolyMonTypes.DisplayStyles)
            Else
                _DisplayStyle = DisplayStyles.Trace
            End If
        End If

        'Location - X
        Val = ReadAttributeValue(xmlDef.SelectSingleNode("Location"), "X")
        If (Not String.IsNullOrEmpty(Val)) AndAlso IsNumeric(Val) Then
            _Location.X = CInt(Val)
        End If

        'Location - Y
        Val = ReadAttributeValue(xmlDef.SelectSingleNode("Location"), "Y")
        If (Not String.IsNullOrEmpty(Val)) AndAlso IsNumeric(Val) Then
            _Location.Y = CInt(Val)
        End If

        'Size - Width
        Val = ReadAttributeValue(xmlDef.SelectSingleNode("Size"), "Width")
        If (Not String.IsNullOrEmpty(Val)) AndAlso IsNumeric(Val) Then
            _Size.Width = CInt(Val)
        End If

        'Size - Height
        Val = ReadAttributeValue(xmlDef.SelectSingleNode("Size"), "Height")
        If (Not String.IsNullOrEmpty(Val)) AndAlso IsNumeric(Val) Then
            _Size.Height = CInt(Val)
        End If

        'Monitor Settings
        _MonitorXMLParams = xmlDef.SelectSingleNode("MonitorSettings").OuterXml
    End Sub
#End Region

#Region "Public Events"
    Public Event MoveMonitorStart(ByVal sender As ucMonitorChart, ByVal e As System.Windows.Forms.MouseEventArgs)
    Public Event MoveMonitorEnd(ByVal sender As ucMonitorChart, ByVal e As System.Windows.Forms.MouseEventArgs)
    Public Event MonitorMove(ByVal sender As ucMonitorChart, ByVal e As System.Windows.Forms.MouseEventArgs)

    Public Event ResizeZoneEnter(ByVal sender As ucMonitorChart)
    Public Event ResizeZoneLeave(ByVal sender As ucMonitorChart)
    Public Event ResizeZoneMouseDown(ByVal sender As ucMonitorChart, ByVal Offset As System.Drawing.Point)

    Public Event DeleteMonitor(ByVal sender As ucMonitorChart)

    Public Event IsDirty(ByVal sender As ucMonitorChart)

    Public Event Cloning(ByVal sender As ucMonitorChart, ByVal strXMLDef As String)


    Private Sub Header_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ToolStrip1.MouseDown, tlblMonitorName.MouseDown
        RaiseEvent MoveMonitorStart(Me, e)
    End Sub
    Private Sub Header_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ToolStrip1.MouseMove, tlblMonitorName.MouseMove
        RaiseEvent MonitorMove(Me, e)
    End Sub
    Private Sub Header_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ToolStrip1.MouseUp, tlblMonitorName.MouseUp
        RaiseEvent MoveMonitorEnd(Me, e)
    End Sub
#End Region

#Region "Private Events"
    Private Sub TimerSample_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles TimerSample.Tick
        Dim DT As Date 'Current Sample Time
        Dim Result As Single 'Current Sample Value

        GetSample(DT, Result)

        'Perform any modifications to result here
        '(e.g. display average, difference from last sample, etc)
        'TODO: Implement different sample transformation mechanisms

        _SampleCnt += 1
        _SampleSum += CDbl(Result)
        If _SampleCnt = 1 Then _SampleStartDT = DT

        If Result > _SampleMax Then _SampleMax = Result
        If Result < _SampleMin Then _SampleMin = Result
        Dim AvgResult As Single = CSng(_SampleSum / _SampleCnt)


        'Update Display
        DisplayStats(_SampleCnt, DT, _SampleStartDT, Result, _SampleMin, _SampleMax, AvgResult)

        _ChartPoints.Add(DT.ToOADate(), Result)
        If zgTrace.GraphPane.YAxis.Scale.MaxAuto = False Then
            If Result > zgTrace.GraphPane.YAxis.Scale.Max Then
                zgTrace.GraphPane.YAxis.Scale.Max = 1.1 * Result
            End If
        End If
        Select Case DisplayStyle
            Case DisplayStyles.Trace
                zgTrace.AxisChange()
                zgTrace.Invalidate()
            Case DisplayStyles.Gauge
                gaugeSample.Gauge1.Value = Result
            Case DisplayStyles.LED
                LEDGauge1.GaugeValue = Result
            Case DisplayStyles.StatusLightSingle
                StatusLight1.GaugeValue = Result
            Case DisplayStyles.Cylinder
                CylinderGauge1.GaugeValue = Result
        End Select

        _SamplePrevResult = Result
        _SamplePrevDT = DT
    End Sub

    Private Sub StartStopSampling_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miStartStopSampling.Click, tbtnStartStop.Click
        'Me.Cursor = Cursors.WaitCursor
        If _IsPaused Then
            'Cannot change status since monitoring is paused at the dashboard level
        Else
            If RunState = RunStates.Running Then
                RunState = RunStates.Stopped
            Else
                RunState = RunStates.Running
            End If
        End If
        'Me.Cursor = Cursors.Default
    End Sub

 

    Private Sub StatusStrip1_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles StatusStrip1.MouseMove
        'Mouse is moving within strip.
        'If it is located close enough to the lower right (grip) edge, 
        'raise event indicating mouse is in Resizing grip zone if this is the first time we have raised this event


        If Math.Abs(StatusStrip1.PointToClient(MousePosition).X - Me.StatusStrip1.Width) < _ResizeFudge Then
            'Mouse is moving within resize zone
            If Not _IsInResizeZone Then
                _IsInResizeZone = True
                '''''Me.BorderStyle = Windows.Forms.BorderStyle.FixedSingle
                RaiseEvent ResizeZoneEnter(Me)
            End If
        Else
            'Mouse is moving outside of resize zone
            If _IsInResizeZone Then
                _IsInResizeZone = False
                '''''Me.BorderStyle = Windows.Forms.BorderStyle.FixedSingle
                RaiseEvent ResizeZoneLeave(Me)
            End If
        End If

    End Sub





    Private Sub StatusStrip1_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles StatusStrip1.MouseLeave
        If _IsInResizeZone Then
            'User has left resize zone
            _IsInResizeZone = False
            Me.BorderStyle = Windows.Forms.BorderStyle.None
            RaiseEvent ResizeZoneLeave(Me)
        End If
    End Sub
    Private Sub StatusStrip1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles StatusStrip1.MouseDown
        If _IsInResizeZone Then
            'User wants to resize control
            Dim CtlMousePos As System.Drawing.Point = e.Location
            Me.BorderStyle = Windows.Forms.BorderStyle.FixedSingle
            RaiseEvent ResizeZoneMouseDown(Me, New System.Drawing.Point(Math.Abs(StatusStrip1.Width - CtlMousePos.X), Math.Abs(StatusStrip1.Height - CtlMousePos.Y)))
        End If
    End Sub


    Private Sub miClone_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miClone.Click
        'Clone Monitor
        Dim myXML As String = Serialize()
        RaiseEvent Cloning(Me, myXML)
    End Sub
    Private Sub miStyleLED_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miStyleLED.Click
        DisplayStyle = DisplayStyles.LED
    End Sub
    Private Sub miStyleChart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miStyleChart.Click
        DisplayStyle = DisplayStyles.Trace
    End Sub
    Private Sub miStyleGauge_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miStyleGauge.Click
        DisplayStyle = DisplayStyles.Gauge
    End Sub
    Private Sub miStyleStatusLight_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miStyleStatusLight.Click
        DisplayStyle = DisplayStyles.StatusLightSingle
    End Sub
    Private Sub miStyleCylinder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miStyleCylinder.Click
        DisplayStyle = DisplayStyles.Cylinder
    End Sub
    Private Sub miProperties_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miProperties.Click
        Dim dlg As New dlgMonitorChartProperties()
        With dlg
            .MonitorName = _MonitorName
            .PollingInterval = _msFreq
            .RetentionPeriod = _Retention
            .RangeScaling = _RangeScaling
            .RangeLegend = _RangeLegend
            .MonitorType = _MonitorType
            .MonitorXMLParams = _MonitorXMLParams

            .T1Enabled = _Threshold1.Enabled
            .T1Value = _Threshold1.Value
            .T1Color = _Threshold1.Color

            .T2Enabled = _Threshold2.Enabled
            .T2Value = _Threshold2.Value
            .T2Color = _Threshold2.Color

            .DialColor = _DialColor
            .GaugeOrientation = _GaugeOrientation
            .DialMinimum = _DialMinimum
            .DialMaximum = _DialMaximum
            .DialStep = _DialStep
        End With
        Dim ret As DialogResult = dlg.ShowDialog()
        If ret = DialogResult.OK Then
            'Cursor.Current = Cursors.WaitCursor

            'Monitor Name
            _MonitorName = dlg.MonitorName
            tlblMonitorName.Text = _MonitorName

            'Monitor Params
            _MonitorXMLParams = dlg.MonitorXMLParams
            Dim xmlDoc As New System.Xml.XmlDocument
            xmlDoc.LoadXml(dlg.MonitorXMLParams)
            Me.Refresh()

            'MONITORHOOK: Handle new Monitor types here
            'Monitor Type
            _MonitorType = dlg.MonitorType
            Select Case dlg.MonitorType
                Case MonitorTypes.PerfMon
                    _PC = New PolyMonMonitors.PerfMon(xmlDoc.DocumentElement)
                Case MonitorTypes.SQLMonitor
                    _PC = New PolyMonMonitors.SQLMonitor(xmlDoc.DocumentElement)
                Case MonitorTypes.Ping
                    _PC = New PolyMonMonitors.PingMonitor(xmlDoc.DocumentElement)
                Case MonitorTypes.PowerShell
                    _PC = New PolyMonMonitors.PowerShellMonitor(xmlDoc.DocumentElement)
            End Select

            'Polling Interval
            _msFreq = dlg.PollingInterval
            TimerSample.Interval = _msFreq

            'Retention Period
            _Retention = dlg.RetentionPeriod
            ChangeChartCapacity(dlg.RetentionPeriod)

            'Range Scaling
            _RangeScaling = dlg.RangeScaling

            'Range Legend
            _RangeLegend = dlg.RangeLegend
            gaugeSample.Legend = dlg.RangeLegend
            zgTrace.GraphPane.XAxis.Title.Text = dlg.RangeLegend
            LEDGauge1.Legend = dlg.RangeLegend
            StatusLight1.Legend = dlg.RangeLegend
            CylinderGauge1.Legend = dlg.RangeLegend

            'Threshold 1
            _Threshold1.Enabled = dlg.T1Enabled
            _Threshold1.Value = dlg.T1Value
            _Threshold1.Color = dlg.T1Color
            gaugeSample.Range1.RangeColor = dlg.T1Color
            gaugeSample.Range1.Enabled = dlg.T1Enabled
            gaugeSample.Range1.StartValue = CSng(dlg.T1Value)
            If dlg.T2Enabled Then
                gaugeSample.Range1.EndValue = CSng(dlg.T2Value)
            Else
                gaugeSample.Range1.EndValue = CSng(dlg.DialMaximum)
            End If

            'Threshold 2
            _Threshold2.Enabled = dlg.T2Enabled
            _Threshold2.Value = dlg.T2Value
            _Threshold2.Color = dlg.T2Color
            gaugeSample.Range2.RangeColor = dlg.T2Color
            gaugeSample.Range2.Enabled = dlg.T2Enabled
            gaugeSample.Range2.StartValue = CSng(dlg.T2Value)
            gaugeSample.Range2.EndValue = CSng(dlg.DialMaximum)

            'Gauge Color
            _DialColor = dlg.DialColor
            gaugeSample.DialColor = dlg.DialColor
            LEDGauge1.OnColor0 = dlg.DialColor
            StatusLight1.OnColor0 = dlg.DialColor
            CylinderGauge1.OnColor0 = dlg.DialColor

            'Gauge Orientation
            _GaugeOrientation = dlg.GaugeOrientation
            If _GaugeOrientation = GaugeOrientations.Vertical Then
                LEDGauge1.Orientation = PolyMonControls.LEDGauge.Orientation.Vertical
            Else
                LEDGauge1.Orientation = PolyMonControls.LEDGauge.Orientation.Horizontal
            End If

            'LEDGauge/StatusLight/Cylinder Thresholds
            If dlg.T1Enabled Then
                LEDGauge1.Threshold1 = dlg.T1Value
                LEDGauge1.OnColor1 = dlg.T1Color

                StatusLight1.Threshold1 = dlg.T1Value
                StatusLight1.OnColor1 = dlg.T1Color

                CylinderGauge1.Threshold1 = dlg.T1Value
                CylinderGauge1.OnColor1 = dlg.T1Color
            Else
                LEDGauge1.OnColor1 = LEDGauge1.OnColor0
                StatusLight1.OnColor1 = StatusLight1.OnColor0
                CylinderGauge1.OnColor1 = CylinderGauge1.OnColor0
            End If
            If dlg.T2Enabled Then
                LEDGauge1.Threshold2 = dlg.T2Value
                LEDGauge1.OnColor2 = dlg.T2Color

                StatusLight1.Threshold2 = dlg.T2Value
                StatusLight1.OnColor2 = dlg.T2Color

                CylinderGauge1.Threshold2 = dlg.T2Value
                CylinderGauge1.OnColor2 = dlg.T2Color
            Else
                LEDGauge1.OnColor2 = LEDGauge1.OnColor1
                StatusLight1.OnColor2 = LEDGauge1.OnColor1
                CylinderGauge1.OnColor2 = CylinderGauge1.OnColor1
            End If


            'Add Threshold lines to Trace chart
            AddTraceThresholdLines(_Threshold1.Enabled, _Threshold1.Color, _Threshold1.Value, _Threshold2.Enabled, _Threshold2.Color, _Threshold2.Value)



            'Gauge Min Value
            _DialMinimum = dlg.DialMinimum
            gaugeSample.MinValue = CSng(dlg.DialMinimum)
            LEDGauge1.ScaleMin = dlg.DialMinimum
            CylinderGauge1.Min = dlg.DialMinimum

            'Gauge Max Value
            _DialMaximum = dlg.DialMaximum
            gaugeSample.MaxValue = CSng(dlg.DialMaximum)
            LEDGauge1.ScaleMax = dlg.DialMaximum
            CylinderGauge1.Max = dlg.DialMaximum

            'Dial Step
            _DialStep = dlg.DialStep
            gaugeSample.MajorScaleStepSize = CSng(dlg.DialStep)
            LEDGauge1.LEDCount = CInt(Math.Ceiling((dlg.DialMaximum - dlg.DialMinimum) / dlg.DialStep))

            If dlg.IsMonitorDefDirty Then
                ClearSampleData()
            End If

            'Cursor.Current = Cursors.Default
        End If
    End Sub
    Private Sub miClearResults_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miClearResults.Click
        ClearSampleData()
    End Sub
    Private Sub miDeleteMonitor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miDeleteMonitor.Click
        RaiseEvent DeleteMonitor(Me)
    End Sub
#End Region

#Region "Private Methods"
    Private Sub SetDisplayStyle(ByVal Style As DisplayStyles)
        Select Case Style
            Case DisplayStyles.Trace
                _DisplayStyle = DisplayStyles.Trace
                zgTrace.AxisChange()
                zgTrace.Visible = True
                zgTrace.Invalidate()
                gaugeSample.Visible = False
                LEDGauge1.Visible = False
                StatusLight1.Visible = False
                CylinderGauge1.Visible = False
            Case DisplayStyles.Gauge
                _DisplayStyle = DisplayStyles.Gauge
                zgTrace.Visible = False
                gaugeSample.Visible = True
                LEDGauge1.Visible = False
                StatusLight1.Visible = False
                CylinderGauge1.Visible = False
            Case DisplayStyles.LED
                _DisplayStyle = DisplayStyles.LED
                zgTrace.Visible = False
                gaugeSample.Visible = False
                LEDGauge1.Visible = True
                StatusLight1.Visible = False
                CylinderGauge1.Visible = False
            Case DisplayStyles.StatusLightSingle
                _DisplayStyle = DisplayStyles.StatusLightSingle
                zgTrace.Visible = False
                gaugeSample.Visible = False
                LEDGauge1.Visible = False
                StatusLight1.Visible = True
                CylinderGauge1.Visible = False
            Case DisplayStyles.Cylinder
                _DisplayStyle = DisplayStyles.Cylinder
                zgTrace.Visible = False
                gaugeSample.Visible = False
                LEDGauge1.Visible = False
                StatusLight1.Visible = False
                CylinderGauge1.Visible = True
        End Select
    End Sub
    Private Sub ChangeChartCapacity(ByVal NewCap As Integer)
        If _ChartPoints.Capacity = NewCap Then
            'Do nothing, stayed the same
        ElseIf _ChartPoints.Capacity > NewCap Then
            'Decreasing capacity
            Dim tmpPts As New ZedGraph.RollingPointPairList(_ChartPoints.Count)
            For i As Integer = 0 To _ChartPoints.Count - 1
                tmpPts.Add(_ChartPoints(i))
            Next
            _ChartPoints = New ZedGraph.RollingPointPairList(NewCap)
            If tmpPts.Count <= NewCap Then
                'No data loss
                For i As Integer = 0 To tmpPts.Count - 1
                    _ChartPoints.Add(tmpPts.Item(i))
                Next
            Else
                'Need to lose data at the start of the list
                For i As Integer = tmpPts.Count - NewCap To NewCap - 1
                    _ChartPoints.Add(tmpPts.Item(i))
                Next
            End If
            zgTrace.GraphPane.CurveList("Trace").Points = _ChartPoints
        Else
            'Increasing capacity
            Dim tmpPts As New ZedGraph.RollingPointPairList(_ChartPoints.Count)
            For i As Integer = 0 To _ChartPoints.Count - 1
                tmpPts.Add(_ChartPoints(i))
            Next
            _ChartPoints = New ZedGraph.RollingPointPairList(NewCap)
            For i = 0 To tmpPts.Count - 1
                _ChartPoints.Add(tmpPts.Item(i))
            Next
            zgTrace.GraphPane.CurveList("Trace").Points = _ChartPoints
        End If
    End Sub
    Private Sub AddTraceThresholdLines(ByVal Line1Enabled As Boolean, ByVal Line1Color As Color, ByVal Line1Value As Double, ByVal Line2Enabled As Boolean, ByVal Line2Color As Color, ByVal Line2Value As Double)
        'First remove the lines from the graph
        With zgTrace
            .GraphPane.GraphObjList.Clear()

            'Add Line 1
            If Line1Enabled Then
                _TraceLine1 = New ZedGraph.LineObj(Line1Color, 0.0F, Line1Value, 1.0F, Line1Value)
                _TraceLine1.IsClippedToChartRect = True
                _TraceLine1.ZOrder = ZOrder.A_InFront
                _TraceLine1.Location.CoordinateFrame = CoordType.XChartFractionYScale
                _TraceLine1.Line.Style = Drawing2D.DashStyle.Solid
                _TraceLine1.IsVisible = True
                .GraphPane.GraphObjList.Add(_TraceLine1)
            End If

            'Add Line 2
            If Line2Enabled Then
                _TraceLine2 = New ZedGraph.LineObj(Line2Color, 0.0F, Line2Value, 1.0F, Line2Value)
                _TraceLine2.IsClippedToChartRect = True
                _TraceLine2.ZOrder = ZOrder.A_InFront
                _TraceLine2.Location.CoordinateFrame = CoordType.XChartFractionYScale
                _TraceLine2.Line.Style = Drawing2D.DashStyle.Solid
                _TraceLine2.IsVisible = True
                .GraphPane.GraphObjList.Add(_TraceLine2)
            End If

            If Line1Enabled OrElse Line2Enabled Then
                .GraphPane.YAxis.Scale.MaxAuto = True
                .AxisChange()
                Dim MaxVal As Double = .GraphPane.YAxis.Scale.Max

                .GraphPane.YAxis.Scale.MaxAuto = False
                If Line1Enabled AndAlso Line1Value > MaxVal Then MaxVal = Line1Value
                If Line2Enabled AndAlso Line2Value > MaxVal Then MaxVal = Line2Value
                .GraphPane.YAxis.Scale.Max = 1.1 * MaxVal
            Else
                .GraphPane.YAxis.Scale.MaxAuto = True
            End If

            .AxisChange()
            .Refresh()
        End With
    End Sub
    Private Sub DisplayStats(ByVal NumSamples As Integer, ByVal CurrDT As Date, ByVal StartDT As Date, ByVal CurrValue As Single, ByVal MinValue As Single, ByVal MaxValue As Single, ByVal AvgValue As Single)
        tslStatus.Text = SampleCustomFmt(CurrValue)

        mnuStats_Min.Text = "Min: " & SampleCustomFmt(MinValue)
        mnuStats_Avg.Text = "Max: " & SampleCustomFmt(MaxValue)
        mnuStats_Max.Text = "Avg: " & SampleCustomFmt(AvgValue)
        mnuStats_Elapsed.Text = "Elapsed: " & CStr(DateDiff(DateInterval.Second, StartDT, CurrDT)) & " s"
        mnuStats_NumSamples.Text = "# Samples: " & NumSamples.ToString()
    End Sub
    Private Function SampleCustomFmt(ByVal Value As Single) As String
        'if number has more than 3 significant digits do not show decimals
        Dim NumSig As Integer = Format(Value, "#").Length
        Dim NumDecs As Integer = 4 - NumSig
        If NumDecs < 0 Then NumDecs = 0
        Return FormatNumber(Value, NumDecs, TriState.True, TriState.False, TriState.False)
    End Function
    Private Sub ResetStats()
        _SamplePrevResult = 0
        _SamplePrevDT = Now()
        _SampleCnt = 0
        _SampleSum = 0
        _SampleMin = Single.PositiveInfinity
        _SampleMax = Single.NegativeInfinity
        _SampleStartDT = Now()

        tslStatus.Text = Nothing

        mnuStats_Min.Text = "Min: "
        mnuStats_Max.Text = "Max: "
        mnuStats_Avg.Text = "Avg: "
        mnuStats_Elapsed.Text = "Elapsed: "
        mnuStats_NumSamples.Text = "# Samples: "
    End Sub
    Private Sub ClearSampleData()
        'Reset Trace data points
        _ChartPoints.Clear()
        zgTrace.AxisChange()
        zgTrace.Refresh()
        'Reset stats
        ResetStats()
    End Sub
    Private Function ReadNodeValue(ByVal Node As XmlNode) As String
        If Node Is Nothing Then
            Return Nothing
        Else
            Return Node.InnerText
        End If
    End Function
    Private Function ReadAttributeValue(ByVal Node As XmlNode, ByVal Attribute As String) As String
        If Node Is Nothing Then
            Return Nothing
        Else
            Dim Att As XmlAttribute = Node.Attributes(Attribute)
            If Att Is Nothing Then
                Return Nothing
            Else
                Return Att.Value.ToString()
            End If
        End If
    End Function
#End Region

#Region "Sampling Methods"
    Public Sub GetSample(ByRef DT As Date, ByRef Result As Single)
        If _PC IsNot Nothing Then
            If _RangeScaling = 0 Then
                Result = CSng(CType(_PC, PolyMonInterfaces.IMonitorSampler).GetSample())
            Else
                Result = CSng(CDbl(CType(_PC, PolyMonInterfaces.IMonitorSampler).GetSample()) / CDbl(_RangeScaling))
            End If
            DT = Now()
        Else
            DT = Now()
            Result = ERRVALUE
        End If
    End Sub
#End Region

#Region "Helper Classes"
    Public Class Threshold
        Private _Enabled As Boolean
        Private _Value As Double
        Private _Color As System.Drawing.Color
        Public Sub New()
            _Enabled = False
        End Sub
        Public Sub New(ByVal Enabled As Boolean, ByVal Value As Double, ByVal Color As System.Drawing.Color)
            _Enabled = Enabled
            _Value = Value
            _Color = Color
        End Sub
        Public Property Enabled() As Boolean
            Get
                Return _Enabled
            End Get
            Set(ByVal value As Boolean)
                _Enabled = value
            End Set
        End Property
        Public Property Value() As Double
            Get
                Return _Value
            End Get
            Set(ByVal value As Double)
                _Value = value
            End Set
        End Property
        Public Property Color() As System.Drawing.Color
            Get
                Return _Color
            End Get
            Set(ByVal value As System.Drawing.Color)
                _Color = value
            End Set
        End Property
    End Class
#End Region


End Class 'UCMonitorChart

Public Class BorderPanel
    Inherits Panel

    Private _BrdWidth As Integer
    Private _BrdColor As Color

    Public Sub New(ByVal BrdWidth As Integer, ByVal BrdColor As Color)
        MyBase.New()
        _BrdWidth = BrdWidth
        _BrdColor = BrdColor
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        MyBase.OnPaint(e)
        Dim borderWidth As Integer = _BrdWidth
        Dim borderColor As Color = _BrdColor
        ControlPaint.DrawBorder(e.Graphics, e.ClipRectangle, borderColor, borderWidth, ButtonBorderStyle.Solid, borderColor, borderWidth, ButtonBorderStyle.Solid, borderColor, borderWidth, ButtonBorderStyle.Solid, borderColor, borderWidth, ButtonBorderStyle.Solid)
    End Sub

End Class 'BorderPanel






