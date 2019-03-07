Imports System.Drawing
Imports System.Xml

Public Class ucGauge
    Private _BackColor As Color = Color.White
    Private _BaseArcColor As System.Drawing.Color = Color.Gray
    Private _BaseArcRadius As Integer = 45
    Private _BaseArcStart As Integer = 130
    Private _BaseArcSweep As Integer = 280
    Private _BaseArcWidth As Integer = 1

    Private _Center As Point = New Point(90, 80)
    Private _MinValue As Single = 0
    Private _MaxValue As Single = 100

    Private _NeedleRadius As Integer = 50

    Private _Range0 As Range
    Private _Range1 As Range
    Private _Range2 As Range

    Private _RangeInnerRadius As Integer = 45
    Private _RangeOuterRadius As Integer = 60

    Private _ScaleLinesMajorColor As Color = Color.Black
    Private _ScaleLinesMajorInnerRadius As Integer = _RangeInnerRadius
    Private _ScaleLinesMajorOuterRadius As Integer = CInt(0.9 * _RangeOuterRadius)
    Private _ScaleLinesMajorStepValue As Single = CSng(Math.Round((_MaxValue - _MinValue) / 10, 0))
    Private _ScaleLinesMajorWidth As Integer = 1

    Private _ScaleLinesMinorColor As Color = Color.Black
    Private _ScaleLinesMinorInnerRadius As Integer = _RangeInnerRadius
    Private _ScaleLinesMinorOuterRadius As Integer = CInt(0.8 * _RangeOuterRadius)
    Private _ScaleLinesMinorNumOf As Integer = 4
    Private _ScaleLinesMinorWidth As Integer = 1

    Private _ScaleNumbersColor As Color = Color.Black
    Private _ScaleNumbersFormat As String = "0"
    Private _ScaleNumbersRadius As Integer = 70
    Private _ScaleNumbersRotation As Integer = 0
    Private _ScaleNumbersStartScaleLine As Integer = 0
    Private _ScaleNumbersStepScaleLine As Integer = 1


    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        'Set defaults
        _Range0 = New Range(Gauge1, 0, True, Color.LightGreen, 0, _MaxValue)
        _Range1 = New Range(Gauge1, 1, True, Color.DarkOrange, CSng(_MaxValue * 0.7), CSng(_MaxValue * 0.9))
        _Range2 = New Range(Gauge1, 2, True, Color.Red, CSng(_MaxValue * 0.9), _MaxValue)

        With Gauge1
            .Value = 0

            .BackColor = _BackColor
            Me.BackColor = Color.Transparent
            Me.lblLegend.BackColor = Color.Transparent

            .BaseArcColor = _BaseArcColor
            .BaseArcRadius = _BaseArcRadius
            .BaseArcStart = _BaseArcStart
            .BaseArcSweep = _BaseArcSweep
            .BaseArcWidth = _BaseArcWidth
            .Center = _Center
            .MinValue = _MinValue
            .MaxValue = _MaxValue
            .NeedleRadius = _NeedleRadius

            .Range_Idx = 0
            .RangeEnabled = _Range0.Enabled
            .RangeColor = _Range0.RangeColor
            .RangeStartValue = _Range0.StartValue
            .RangeEndValue = _Range0.EndValue
            .RangeInnerRadius = _RangeInnerRadius
            .RangeOuterRadius = _RangeOuterRadius

            .Range_Idx = 1
            .RangeEnabled = _Range1.Enabled
            .RangeColor = _Range1.RangeColor
            .RangeStartValue = _Range1.StartValue
            .RangeEndValue = _Range1.EndValue
            .RangeInnerRadius = _RangeInnerRadius
            .RangeOuterRadius = _RangeOuterRadius

            .Range_Idx = 2
            .RangeEnabled = _Range2.Enabled
            .RangeColor = _Range2.RangeColor
            .RangeStartValue = _Range2.StartValue
            .RangeEndValue = _Range2.EndValue
            .RangeInnerRadius = _RangeInnerRadius
            .RangeOuterRadius = _RangeOuterRadius

            .ScaleLinesMajorColor = _ScaleLinesMajorColor
            .ScaleLinesMajorInnerRadius = _ScaleLinesMajorInnerRadius
            .ScaleLinesMajorOuterRadius = _ScaleLinesMajorOuterRadius
            .ScaleLinesMajorStepValue = _ScaleLinesMajorStepValue
            .ScaleLinesMajorWidth = _ScaleLinesMajorWidth

            .ScaleLinesMinorColor = _ScaleLinesMinorColor
            .ScaleLinesMinorInnerRadius = _ScaleLinesMinorInnerRadius
            .ScaleLinesMinorOuterRadius = _ScaleLinesMinorOuterRadius
            .ScaleLinesMinorNumOf = _ScaleLinesMinorNumOf
            .ScaleLinesMinorWidth = _ScaleLinesMinorWidth

            .ScaleNumbersColor = _ScaleNumbersColor
            .ScaleNumbersFormat = _ScaleNumbersFormat
            .ScaleNumbersRadius = _ScaleNumbersRadius
            .ScaleNumbersRotation = _ScaleNumbersRotation
            .ScaleNumbersStartScaleLine = _ScaleNumbersStartScaleLine
            .ScaleNumbersStepScaleLines = _ScaleNumbersStepScaleLine
        End With
        lblLegend.Text = Nothing
        lblLegend.BackColor = Gauge1.BackColor
    End Sub

    Private Sub ucGauge_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        ReSizeGauge()
    End Sub

    Public Sub ReSizeGauge()
        Dim MaxDiameter As Integer = Gauge1.DisplayRectangle.Width
        If Gauge1.DisplayRectangle.Height < MaxDiameter Then MaxDiameter = Gauge1.DisplayRectangle.Height '- lblLegend.Height

        Dim GaugeThickness As Integer = 15
        Dim ExtWSpc As Integer = 20
        Dim InnerWSpc As Integer = 12

        Dim ScaleNumbersRadius As Integer = CInt(MaxDiameter / 2 - ExtWSpc)
        Dim GaugeOuterRadius As Integer = ScaleNumbersRadius - InnerWSpc
        Dim GaugeInnerRadius As Integer = GaugeOuterRadius - GaugeThickness

        With Gauge1
            .SuspendLayout()
            .Visible = False

            .Center = New System.Drawing.Point(Me.Width \ 2, Me.Height \ 2)
            .ScaleNumbersRadius = ScaleNumbersRadius

            .Range_Idx = 0
            .RangeOuterRadius = GaugeOuterRadius
            .RangeInnerRadius = GaugeInnerRadius

            .Range_Idx = 1
            .RangeOuterRadius = GaugeOuterRadius
            .RangeInnerRadius = GaugeInnerRadius

            .Range_Idx = 2
            .RangeOuterRadius = GaugeOuterRadius
            .RangeInnerRadius = GaugeInnerRadius

            .ScaleLinesMajorInnerRadius = GaugeInnerRadius
            .ScaleLinesMajorOuterRadius = GaugeOuterRadius - 4


            .ScaleLinesMinorInnerRadius = GaugeInnerRadius
            .ScaleLinesMinorOuterRadius = GaugeOuterRadius - 8

            .BaseArcRadius = GaugeInnerRadius
            .NeedleRadius = GaugeInnerRadius

            .ResumeLayout()
            .Visible = True
        End With
    End Sub

    Public Property GaugeBackColor() As Color
        Get
            Return _BackColor
        End Get
        Set(ByVal value As Color)
            Try
                Me.BackColor = value
                Me.Gauge1.BackColor = value
                Me.lblLegend.BackColor = value
                _BackColor = value
            Catch ex As Exception
                Me.BackColor = Color.White
                Me.Gauge1.BackColor = Color.White
                Me.lblLegend.BackColor = Color.White
                _BackColor = Color.White
            End Try
        End Set
    End Property
    Public Property MinValue() As Single
        Get
            Return _MinValue
        End Get
        Set(ByVal value As Single)
            _MinValue = value
            Gauge1.MinValue = value
            _Range0.StartValue = value
        End Set
    End Property
    Public Property MaxValue() As Single
        Get
            Return _MaxValue
        End Get
        Set(ByVal value As Single)
            _MaxValue = value
            Gauge1.MaxValue = value
            _Range0.EndValue = value
        End Set
    End Property
    Public Property Legend() As String
        Get
            Return lblLegend.Text
        End Get
        Set(ByVal value As String)
            lblLegend.Text = value
        End Set
    End Property
    Public Property DialColor() As Color
        Get
            Return _Range0.RangeColor
        End Get
        Set(ByVal value As Color)
            _Range0.RangeColor = value
        End Set
    End Property
    Public ReadOnly Property Range1() As Range
        Get
            Return _Range1
        End Get
    End Property
    Public ReadOnly Property Range2() As Range
        Get
            Return _Range2
        End Get
    End Property
    Public Property MajorScaleStepSize() As Single
        Get
            Return Gauge1.ScaleLinesMajorStepValue
        End Get
        Set(ByVal value As Single)
            Gauge1.ScaleLinesMajorStepValue = value
        End Set
    End Property


    Public Class Range
        Private _myGauge As AGaugeApp.AGauge
        Private _RangeID As Byte


        Public Sub New(ByRef myGauge As AGaugeApp.AGauge, ByVal RangeID As Byte)
            _myGauge = myGauge
            _RangeID = RangeID
        End Sub
        Public Sub New(ByRef myGauge As AGaugeApp.AGauge, ByVal RangeID As Byte, ByVal Enabled As Boolean, ByVal RangeColor As Color, ByVal StartValue As Single, ByVal EndValue As Single)
            _myGauge = myGauge
            _RangeID = RangeID

            With _myGauge
                .Range_Idx = _RangeID
                .RangeEnabled = Enabled
                .RangeColor = RangeColor
                .RangeStartValue = StartValue
                .RangeEndValue = EndValue
            End With
        End Sub

        Public Property Enabled() As Boolean
            Get
                _myGauge.Range_Idx = _RangeID
                Return _myGauge.RangeEnabled
            End Get
            Set(ByVal value As Boolean)
                _myGauge.Range_Idx = _RangeID
                _myGauge.RangeEnabled = value
            End Set
        End Property
        Public Property RangeColor() As Color
            Get
                _myGauge.Range_Idx = _RangeID
                Return _myGauge.RangeColor
            End Get
            Set(ByVal value As Color)
                _myGauge.Range_Idx = _RangeID
                _myGauge.RangeColor = value
            End Set
        End Property
        Public Property StartValue() As Single
            Get
                _myGauge.Range_Idx = _RangeID
                Return _myGauge.RangeStartValue
            End Get
            Set(ByVal value As Single)
                _myGauge.Range_Idx = _RangeID
                _myGauge.RangeStartValue = value
            End Set
        End Property
        Public Property EndValue() As Single
            Get
                _myGauge.Range_Idx = _RangeID
                Return _myGauge.RangeEndValue
            End Get
            Set(ByVal value As Single)
                _myGauge.Range_Idx = _RangeID
                _myGauge.RangeEndValue = value
            End Set
        End Property
    End Class


End Class
