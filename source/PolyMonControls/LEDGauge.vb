Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.ComponentModel
Imports System.ComponentModel.Design

<DefaultEvent("Click"), ToolboxBitmap(GetType(LEDGauge), "LEDGauge.bmp")> _
Public Class LEDGauge

#Region "Default Values"
    Private Const def_IsTransparent As Boolean = True
    Private Const def_LEDCount As Integer = 10
    Private Const def_ScaleMin As Integer = 0
    Private Const def_ScaleMax As Double = 100
    Private Const def_Value As Double = 85
    Private Const def_LEDGap As Integer = 2
    Private Const def_LEDOrientation As String = "Horizontal"

    Private Const def_LEDBorderColor As String = "Blue"

    Private Const def_LEDBorderThickness As Integer = 0

    Private Const def_LEDOffColor As String = "White"
    Private Const def_LEDColor0 As String = "Gold"
    Private Const def_LEDColor1 As String = "Orange"
    Private Const def_LEDColor2 As String = "Red"
    Private Const def_LEDValue1 As Double = 45
    Private Const def_LEDValue2 As Double = 75

    Private Const def_LEDFillStyle As String = "Gradient"

    Private def_Size As New Size(120, 20)
#End Region

#Region "Private Attributes"
    Private Const WS_EX_TRANSPARENT As Int16 = &H20

    Private _IsTransparent As Boolean = def_IsTransparent
    Private _LEDCount As Integer = def_LEDCount
    Private _ScaleMin As Double = def_ScaleMin
    Private _ScaleMax As Double = def_ScaleMax
    Private _Value As Double = def_Value
    Private _LEDGap As Integer = def_LEDGap
    Private _LEDOrientation As Orientation = CType([Enum].Parse(GetType(Orientation), def_LEDOrientation), Orientation)
    Private _LEDBorderColor As Color = System.Drawing.Color.FromName(def_LEDBorderColor)
    Private _LEDBorderThickness As Integer = def_LEDBorderThickness
    Private _LEDOffColor As Color = System.Drawing.Color.FromName(def_LEDOffColor)
    Private _LEDColor0 As Color = System.Drawing.Color.FromName(def_LEDColor0)
    Private _LEDColor1 As Color = System.Drawing.Color.FromName(def_LEDColor1)
    Private _LEDColor2 As Color = System.Drawing.Color.FromName(def_LEDColor2)
    Private _LEDValue1 As Double = def_LEDValue1
    Private _LEDValue2 As Double = def_LEDValue2
    Private _LEDFillStyle As FillStyles = CType([Enum].Parse(GetType(FillStyles), def_LEDFillStyle), FillStyles)

    Private _StepSize As Double
    Private _LEDs As List(Of LED)
#End Region

#Region "Overrides"
    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        MyBase.OnPaint(e)
        UpdateLayout(e.Graphics)
    End Sub
    Protected Overrides ReadOnly Property CreateParams() As System.Windows.Forms.CreateParams
        Get
            Dim cp As CreateParams = MyBase.CreateParams
            cp.ExStyle() = cp.ExStyle() Or WS_EX_TRANSPARENT
            Return cp
        End Get
    End Property
    Protected Overrides Sub OnPaddingChanged(ByVal e As System.EventArgs)
        Invalidate()
    End Sub
#End Region

#Region "Public Enumerations"
    Public Enum Orientation As Integer
        Horizontal = 0
        Vertical = 1
    End Enum
    Public Enum FillStyles As Integer
        Solid = 0
        Gradient = 1
    End Enum
#End Region

#Region "Public Interface"
    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.SetStyle(ControlStyles.OptimizedDoubleBuffer, False) 'Cannot Double Buffer when using transparency which is default mode
        Me.SetStyle(ControlStyles.AllPaintingInWmPaint, True)
        Me.SetStyle(ControlStyles.ResizeRedraw, True)
        Me.SetStyle(ControlStyles.UserPaint, True)
        Me.SetStyle(ControlStyles.SupportsTransparentBackColor, True)
        Me.SetStyle(ControlStyles.Opaque, True)

        Me.SetStyle(ControlStyles.OptimizedDoubleBuffer, False) 'Turn double-buffering off
        Me.SetStyle(ControlStyles.AllPaintingInWmPaint, True)
        Me.SetStyle(ControlStyles.ResizeRedraw, True)
        Me.SetStyle(ControlStyles.UserPaint, True)
        Me.SetStyle(ControlStyles.SupportsTransparentBackColor, True)
        Me.SetStyle(ControlStyles.Opaque, True)
        Me.BackColor = Color.Transparent

        Me.Size = def_Size
    End Sub

    <Category("LEDGauge"), _
        Description("Sets whether to draw control using a transparent background. If set to True, BackGround color is ignored."), _
        DefaultValue(def_IsTransparent)> _
    Public Property IsTransparentBackground() As Boolean
        Get
            Return _IsTransparent
        End Get
        Set(ByVal value As Boolean)
            _IsTransparent = value
            Me.SetStyle(ControlStyles.Opaque, _IsTransparent)
            Me.SetStyle(ControlStyles.SupportsTransparentBackColor, _IsTransparent)
            Me.SetStyle(ControlStyles.OptimizedDoubleBuffer, Not (_IsTransparent))
            If _IsTransparent AndAlso Me.BackColor = Color.Transparent Then Me.BackColor = Color.White
            Me.UpdateStyles()
        End Set
    End Property

    <Category("LEDGauge"), _
        Description("Sets the orientation display of the LED Gauge."), _
        DefaultValue(GetType(Orientation), "Horizontal")> _
    Public Property LEDOrientation() As Orientation
        Get
            Return _LEDOrientation
        End Get
        Set(ByVal value As Orientation)
            _LEDOrientation = value
            Invalidate()
        End Set
    End Property

    <Category("LEDGauge"), _
        Description("Sets the number of LEDs this gauge uses."), _
        DefaultValue(def_LEDCount)> _
    Public Property LEDCount() As Integer
        Get
            Return _LEDCount
        End Get
        Set(ByVal value As Integer)
            _LEDCount = value
            Invalidate()
        End Set
    End Property

    <Category("LEDGauge"), _
        Description("Sets the Minimum value of the gauge."), _
        DefaultValue(def_ScaleMin)> _
    Public Property ScaleMin() As Double
        Get
            Return _ScaleMin
        End Get
        Set(ByVal value As Double)
            _ScaleMin = value
            Invalidate()
        End Set
    End Property

    <Category("LEDGauge"), _
        Description("Sets the Maximum value of the gauge."), _
        DefaultValue(def_ScaleMax)> _
    Public Property ScaleMax() As Double
        Get
            Return _ScaleMax
        End Get
        Set(ByVal value As Double)
            _ScaleMax = value
            Invalidate()
        End Set
    End Property

    <Category("LEDGauge"), _
        Description("Sets the Value of the gauge."), _
        DefaultValue(def_Value)> _
    Public Property Value() As Double
        Get
            Return _Value
        End Get
        Set(ByVal value As Double)
            _Value = value
            Invalidate()
        End Set
    End Property

    <Category("LEDGauge"), _
        Description("Sets the gap in pixels between LED's."), _
        DefaultValue(def_LEDGap)> _
    Public Property LEDSpacing() As Integer
        Get
            Return _LEDGap
        End Get
        Set(ByVal value As Integer)
            If value < 0 Then value = 0
            _LEDGap = value
            Invalidate()
        End Set
    End Property


    <Category("LEDGauge"), _
        Description("Sets the border color of the LEDs."), _
        DefaultValue(GetType(System.Drawing.Color), def_LEDBorderColor)> _
    Public Property LEDBorderColor() As Color
        Get
            Return _LEDBorderColor
        End Get
        Set(ByVal value As Color)
            _LEDBorderColor = value
            Invalidate()
        End Set
    End Property

    <Category("LEDGauge"), _
        Description("Sets the thickness of the individual LED borders. Set to 0 to hide borders."), _
        DefaultValue(def_LEDBorderThickness)> _
    Public Property LEDBorderThickness() As Integer
        Get
            Return _LEDBorderThickness
        End Get
        Set(ByVal value As Integer)
            _LEDBorderThickness = value
            Invalidate()
        End Set
    End Property

    <Category("LEDGauge"), _
        Description("Indicates whether a gradient fill should be used for LEDs."), _
        DefaultValue(GetType(FillStyles), def_LEDFillStyle)> _
    Public Property LEDFillStyle() As FillStyles
        Get
            Return _LEDFillStyle
        End Get
        Set(ByVal value As FillStyles)
            _LEDFillStyle = value
            Invalidate()
        End Set
    End Property

    <Category("LEDGauge"), _
        Description("Sets the color of the OFF state of the LEDs."), _
        DefaultValue(GetType(System.Drawing.Color), def_LEDOffColor)> _
    Public Property LEDOffColor() As Color
        Get
            Return _LEDOffColor
        End Get
        Set(ByVal value As Color)
            If value = Color.Transparent Then
                Throw New Exception("Transparent color is not supported in this property.")
                Exit Property
            End If
            _LEDOffColor = value
            Invalidate()
        End Set
    End Property

    <Category("LEDGauge"), _
        Description("Sets the color of the ON state of the LEDs for values less than Threshold1."), _
        DefaultValue(GetType(System.Drawing.Color), def_LEDColor0)> _
    Public Property LEDOnColor0() As Color
        Get
            Return _LEDColor0
        End Get
        Set(ByVal value As Color)
            If value = Color.Transparent Then
                Throw New Exception("Transparent color is not supported in this property.")
                Exit Property
            End If
            _LEDColor0 = value
            Invalidate()
        End Set
    End Property

    <Category("LEDGauge"), _
        Description("Sets the color of the ON state of the LEDs for values greater than (or equal to) Threshold1 and less than Threshold2."), _
        DefaultValue(GetType(System.Drawing.Color), def_LEDColor1)> _
    Public Property LEDOnColor1() As Color
        Get
            Return _LEDColor1
        End Get
        Set(ByVal value As Color)
            If value = Color.Transparent Then
                Throw New Exception("Transparent color is not supported in this property.")
                Exit Property
            End If
            _LEDColor1 = value
            Invalidate()
        End Set
    End Property

    <Category("LEDGauge"), _
        Description("Sets the color of the ON state of the LEDs for values greater than (or equal to) Threshold2."), _
        DefaultValue(GetType(System.Drawing.Color), def_LEDColor2)> _
    Public Property LEDOnColor2() As Color
        Get
            Return _LEDColor2
        End Get
        Set(ByVal value As Color)
            If value = Color.Transparent Then Exit Property
            _LEDColor2 = value
            Invalidate()
        End Set
    End Property

    <Category("LEDGauge"), _
        Description("Sets the value for Threshold1 used for color coding LED's. (See ONColor0-ONColor2)."), _
        DefaultValue(def_LEDValue1)> _
    Public Property Threshold1() As Double
        Get
            Return _LEDValue1
        End Get
        Set(ByVal value As Double)
            _LEDValue1 = value
            Invalidate()
        End Set
    End Property

    <Category("LEDGauge"), _
        Description("Sets the value for Threshold2 used for color coding LED's. (See ONColor0-ONColor2)."), _
        DefaultValue(def_LEDValue2)> _
    Public Property Threshold2() As Double
        Get
            Return _LEDValue2
        End Get
        Set(ByVal value As Double)
            _LEDValue2 = value
            Invalidate()
        End Set
    End Property

#End Region

#Region "Private Implementations"
    Private Sub UpdateLayout(ByRef myG As Graphics)
        'Update gauge layout

        'Set Visible Rectangle Region
        Dim PaddingLeft As Single = Padding.Left
        Dim PaddingRight As Single = Padding.Right
        Dim PaddingTop As Single = Padding.Top
        Dim PaddingBottom As Single = Padding.Bottom

        Dim X0 As Single = PaddingLeft
        Dim Y0 As Single = PaddingTop
        Dim VHeight As Single = Me.ClientRectangle.Height - (PaddingTop + PaddingBottom)
        Dim VWidth As Single = Me.ClientRectangle.Width - (PaddingLeft + PaddingRight)

        'Calculate Step Size
        _StepSize = (_ScaleMax - _ScaleMin) / _LEDCount

        If _LEDOrientation = Orientation.Horizontal Then
            'Horizontal Orientation

            Dim LEDHeight As Single = VHeight
            Dim LEDWidth As Single
            LEDWidth = (VWidth - CSng((_LEDCount - 1) * _LEDGap)) / CSng(_LEDCount)
            Dim LEDSize As SizeF = New SizeF(LEDWidth, LEDHeight)

            'Define LED's
            _LEDs = New List(Of LED)
            For i As Integer = 0 To _LEDCount - 1
                Dim NewX As Single = X0 + (CSng(i) * (LEDWidth + _LEDGap))
                _LEDs.Add(New LED(myG, False, New PointF(NewX, Y0), LEDSize, _LEDOffColor, LEDColor(i), _LEDFillStyle, _LEDBorderColor, _LEDBorderThickness))
            Next

            'Now draw LEDs onto screen
            For Each LED As LED In _LEDs
                LED.DrawLED()
            Next
        Else
            'Vertical Orientation

            Dim LEDWidth As Single = VWidth

            Dim LEDHeight As Single
            LEDHeight = (VHeight - CSng((_LEDCount - 1) * _LEDGap)) / CSng(_LEDCount)
            Dim LEDSize As SizeF = New SizeF(LEDWidth, LEDHeight)

            Y0 = Y0 + VHeight


            'Define LED's
            _LEDs = New List(Of LED)
            For i As Integer = 0 To _LEDCount - 1
                Dim NewY As Single = Y0 - (CSng(i) + 1) * LEDHeight - CSng(i) * _LEDGap
                _LEDs.Add(New LED(myG, False, New PointF(X0, NewY), LEDSize, _LEDOffColor, LEDColor(i), _LEDFillStyle, _LEDBorderColor, _LEDBorderThickness))
            Next

            'Now draw LEDs onto screen
            For Each LED As LED In _LEDs
                LED.DrawLED()
            Next
        End If

        'Update LED state to on/off
        If _Value < _ScaleMin Then
            _Value = 0
        ElseIf _Value > _ScaleMax Then
            _Value = _ScaleMax
        End If

        'Turn LED's on/off
        For i As Integer = 0 To LEDCount - 1
            _LEDs(i).LEDState = LightLED(i, _Value)
        Next
    End Sub

    Private Function LEDColor(ByVal LEDIndex As Integer) As Color
        Dim ScaledLEDMaxValue As Double
        ScaledLEDMaxValue = _ScaleMin + CDbl((LEDIndex + 1)) * _StepSize
        If ScaledLEDMaxValue >= _LEDValue2 Then
            Return _LEDColor2
        ElseIf ScaledLEDMaxValue >= _LEDValue1 Then
            Return _LEDColor1
        Else
            Return _LEDColor0
        End If
    End Function
    Private Function LightLED(ByVal LEDIndex As Integer, ByVal Value As Double) As Boolean
        'Calculate if value falls within specified LED
        Try
            Dim ScaledLEDMinValue As Double
            ScaledLEDMinValue = (_ScaleMin + CDbl((LEDIndex + 1)) * _StepSize) - _StepSize
            If Value > ScaledLEDMinValue Then Return True Else Return False
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Class LED
        Private _Location As PointF
        Private _Size As SizeF
        Private _OffColor As Color
        Private _OnColor As Color
        Private _BorderColor As Color
        Private _BorderThickness As Integer
        Private _Graphics As Graphics = Nothing
        Private _CurrState As Boolean = False
        Private _LEDFillStyle As FillStyles = FillStyles.Gradient

        Private _BorderPen As Pen

        Public Sub New(ByRef myGraphics As Graphics, ByVal myCurrState As Boolean, ByVal myLocation As PointF, ByVal mySize As SizeF, ByVal myOffColor As Color, ByVal myOnColor As Color, ByVal LEDFillStyle As FillStyles, ByVal myBorderColor As Color, ByVal myBorderThickness As Integer)
            _Location = myLocation
            _Size = mySize
            _OffColor = myOffColor
            _OnColor = myOnColor
            _BorderColor = myBorderColor
            _BorderThickness = myBorderThickness
            _Graphics = myGraphics
            _CurrState = myCurrState
            _LEDFillStyle = LEDFillStyle

            _BorderPen = New Pen(_BorderColor, _BorderThickness)
            _BorderPen.Alignment = Drawing2D.PenAlignment.Inset
        End Sub

        Public Property Location() As PointF
            Get
                Return _Location
            End Get
            Set(ByVal value As PointF)
                _Location = value
            End Set
        End Property
        Public Property Size() As SizeF
            Get
                Return _Size
            End Get
            Set(ByVal value As SizeF)
                _Size = value
            End Set
        End Property
        Public Property OffColor() As Color
            Get
                Return _OffColor
            End Get
            Set(ByVal value As Color)
                _OffColor = value
                DrawLED()
            End Set
        End Property
        Public Property OnColor() As Color
            Get
                Return _OnColor
            End Get
            Set(ByVal value As Color)
                _OnColor = value
                DrawLED()
            End Set
        End Property
        Public Property BorderColor() As Color
            Get
                Return _BorderColor
            End Get
            Set(ByVal value As Color)
                _BorderColor = value
                _BorderPen = New Pen(value, _BorderThickness)
                _BorderPen.Alignment = Drawing2D.PenAlignment.Inset
            End Set
        End Property
        Public Property BorderThickness() As Integer
            Get
                Return _BorderThickness
            End Get
            Set(ByVal value As Integer)
                _BorderThickness = value
                _BorderPen = New Pen(_BorderColor, value)
                _BorderPen.Alignment = Drawing2D.PenAlignment.Inset
            End Set
        End Property

        Public ReadOnly Property RectBorder() As RectangleF
            Get
                Return New RectangleF(_Location, _Size)
            End Get
        End Property
        Public ReadOnly Property RectInternal() As RectangleF
            Get
                Return New RectangleF(_Location.X + CSng(_BorderThickness), _
                                     _Location.Y + CSng(_BorderThickness), _
                                     _Size.Width - 2.0! * CSng(_BorderThickness), _
                                     _Size.Height - 2.0! * CSng(_BorderThickness))
            End Get
        End Property

        Public Sub DrawLED()

            LEDState = _CurrState
            If _BorderThickness > 0 Then
                _Graphics.DrawRectangle(_BorderPen, RectBorder.X, RectBorder.Y, RectBorder.Width, RectBorder.Height)
            End If
        End Sub
        Public Property LEDState() As Boolean
            Get
                Return _CurrState
            End Get
            Set(ByVal value As Boolean)
                If value Then
                    Try
                        If _LEDFillStyle = FillStyles.Gradient Then
                            Dim rect As RectangleF = RectInternal

                            Dim pts(3) As PointF
                            pts(0) = New PointF(rect.X, rect.Y)
                            pts(3) = New PointF(rect.X + rect.Width, rect.Y)
                            pts(2) = New PointF(rect.X + rect.Width, rect.Y + rect.Height)
                            pts(1) = New PointF(rect.X, rect.Y + rect.Height)

                            Dim brush As New PathGradientBrush(pts)
                            brush.SurroundColors = New Color() {_OnColor}
                            brush.CenterColor = Color.White
                            brush.CenterPoint = New PointF(rect.X, rect.Y)
                            _Graphics.FillPolygon(brush, pts)
                        Else
                            _Graphics.FillRectangle(New SolidBrush(_OnColor), RectInternal)
                        End If
                    Catch ex As Exception
                        Exit Property
                    End Try
                    If _LEDFillStyle = FillStyles.Gradient Then
                        Dim rect As RectangleF = RectInternal

                        Dim pts(3) As PointF
                        pts(0) = New PointF(rect.X, rect.Y)
                        pts(3) = New PointF(rect.X + rect.Width, rect.Y)
                        pts(2) = New PointF(rect.X + rect.Width, rect.Y + rect.Height)
                        pts(1) = New PointF(rect.X, rect.Y + rect.Height)

                        Dim brush As New PathGradientBrush(pts)
                        brush.SurroundColors = New Color() {_OnColor}
                        brush.CenterColor = Color.White
                        brush.CenterPoint = New PointF(rect.X, rect.Y)
                        _Graphics.FillPolygon(brush, pts)
                    Else
                        _Graphics.FillRectangle(New SolidBrush(_OnColor), RectInternal)
                    End If
                Else
                    _Graphics.FillRectangle(New SolidBrush(_OffColor), RectInternal)
                End If
            End Set
        End Property
    End Class
#End Region

End Class
