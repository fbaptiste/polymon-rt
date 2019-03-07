Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.ComponentModel
Imports System.ComponentModel.Design

<DefaultEvent("Click"), ToolboxBitmap(GetType(StatusLight), "StatusLight.bmp")> _
Public Class StatusLight
    Private _OffColor As Color = Color.Gray
    Private _OnColor0 As Color = Color.Green
    Private _OnColor1 As Color = Color.Orange
    Private _OnColor2 As Color = Color.Red
    Private _OffValue As Double = 0
    Private _Threshold1 As Double = 50
    Private _Threshold2 As Double = 75


    Private _ChromeWidth As Single = 8
    Private _ChromeColor As Color = Color.Silver

    Private _BorderWidth As Single = 3
    Private _RimColor As Color = Color.LightGray

    Private _Value As Double = -1

#Region "Public Interface"
    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.SetStyle(ControlStyles.OptimizedDoubleBuffer, True)
        Me.SetStyle(ControlStyles.AllPaintingInWmPaint, True)
        Me.SetStyle(ControlStyles.ResizeRedraw, True)
        Me.SetStyle(ControlStyles.UserPaint, True)

    End Sub

    <Category("StatusLight"), _
            Description("Sets the Light color when Value < OffValue"), _
            DefaultValue(GetType(System.Drawing.Color), "Gray")> _
        Public Property OffColor() As Color
        Get
            Return _OffColor
        End Get
        Set(ByVal value As Color)
            _OffColor = value
            Invalidate()
        End Set
    End Property

    <Category("StatusLight"), _
            Description("Sets the Light color when Value is in the range [OffValue, Threshold1)."), _
            DefaultValue(GetType(System.Drawing.Color), "Green")> _
    Public Property OnColor0() As Color
        Get
            Return _OnColor0
        End Get
        Set(ByVal value As Color)
            _OnColor0 = value
            Invalidate()
        End Set
    End Property

    <Category("StatusLight"), _
           Description("Sets the Light color when Value is in the range [Threshold1, Threshold2)."), _
           DefaultValue(GetType(System.Drawing.Color), "Orange")> _
   Public Property OnColor1() As Color
        Get
            Return _OnColor1
        End Get
        Set(ByVal value As Color)
            _OnColor1 = value
            Invalidate()
        End Set
    End Property

    <Category("StatusLight"), _
       Description("Sets the Light color when Value >= Threshold2."), _
       DefaultValue(GetType(System.Drawing.Color), "Red")> _
    Public Property OnColor2() As Color
        Get
            Return _OnColor2
        End Get
        Set(ByVal value As Color)
            _OnColor2 = value
            Invalidate()
        End Set
    End Property

    <Category("StatusLight"), _
       Description("Sets the threshold for turning off the light. Uses OffColor when Value < OffColor."), _
       DefaultValue(0.0#)> _
    Public Property OffValue() As Double
        Get
            Return _OffValue
        End Get
        Set(ByVal value As Double)
            _OffValue = value
            Invalidate()
        End Set
    End Property


    <Category("StatusLight"), _
       Description("Sets the threshold when Light color changes from OnColor0 to OnColor1."), _
       DefaultValue(50.0#)> _
    Public Property Threshold1() As Double
        Get
            Return _Threshold1
        End Get
        Set(ByVal value As Double)
            _Threshold1 = value
            Invalidate()
        End Set
    End Property

    <Category("StatusLight"), _
       Description("Sets the threshold when Light color changes from OnColor1 to OnColor2."), _
       DefaultValue(75.0#)> _
    Public Property Threshold2() As Double
        Get
            Return _Threshold2
        End Get
        Set(ByVal value As Double)
            _Threshold2 = value
            Invalidate()
        End Set
    End Property

    <Category("StatusLight"), _
       Description("Sets the width of the Chrome border. This size is based at 100px and is relative according to actual gauge size."), _
       DefaultValue(8.0!)> _
    Public Property ChromeWidth() As Single
        Get
            Return _ChromeWidth
        End Get
        Set(ByVal value As Single)
            _ChromeWidth = value
            Invalidate()
        End Set
    End Property

    <Category("StatusLight"), _
        Description("Sets the width of gauge rims."), _
        DefaultValue(3.0!)> _
    Public Property BorderWidth() As Single
        Get
            Return _BorderWidth
        End Get
        Set(ByVal value As Single)
            _BorderWidth = value
            Invalidate()
        End Set
    End Property

    <Category("StatusLight"), _
        Description("Sets the gauge Value."), _
        DefaultValue(-1.0#)> _
    Public Property Value() As Double
        Get
            Return _Value
        End Get
        Set(ByVal value As Double)
            _Value = value
            Invalidate()
        End Set
    End Property

    <Category("StatusLight"), _
        Description("Sets the color of the Chrome accent on the gauge."), _
        DefaultValue(GetType(System.Drawing.Color), "Silver")> _
    Public Property ChromeColor() As Color
        Get
            Return _ChromeColor
        End Get
        Set(ByVal value As Color)
            _ChromeColor = value
            Invalidate()
        End Set
    End Property

    <Category("StatusLight"), _
        Description("Sets the color of the Rim accent on the gauge."), _
        DefaultValue(GetType(System.Drawing.Color), "LightGray")> _
    Public Property RimColor() As Color
        Get
            Return _RimColor
        End Get
        Set(ByVal value As Color)
            _RimColor = value
            Invalidate()
        End Set
    End Property
#End Region


#Region "Event Handlers"

    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        MyBase.OnPaint(e)

        UpdateLayout(e.Graphics)
    End Sub
    Private Sub StatusLight_PaddingChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PaddingChanged
        Invalidate()
    End Sub
#End Region

#Region "Private Methods"
    Private Sub UpdateLayout(ByRef myG As Graphics)
        Dim ClientRect As Rectangle = Me.DisplayRectangle

        Dim C As Single = Math.Min(ClientRect.Width, ClientRect.Height) * _ChromeWidth / 100
        If _Value < _OffValue Then
            DrawLight(myG, CType(ClientRect, RectangleF), _OffColor, C, _BorderWidth)
        ElseIf _Value >= _Threshold2 Then
            DrawLight(myG, CType(ClientRect, RectangleF), _OnColor2, C, _BorderWidth)
        ElseIf _Value >= _Threshold1 Then
            DrawLight(myG, CType(ClientRect, RectangleF), _OnColor1, C, _BorderWidth)
        Else
            DrawLight(myG, CType(ClientRect, RectangleF), _OnColor0, C, _BorderWidth)
        End If
    End Sub
    Private Sub DrawLight(ByRef myG As Graphics, ByRef myRect As RectangleF, ByVal OnColor As Color, ByVal ChromeWidth As Single, ByVal BorderWidth As Single)
        myG.SmoothingMode = SmoothingMode.AntiAlias

        Dim myRectF As RectangleF = Nothing
        Dim myPen As Pen = Nothing
        Dim myBrush As LinearGradientBrush = Nothing

        'Center point of drawing surface
        Dim Cx As Single = CSng(myRect.X) + (CSng(myRect.Width) / 2)
        Dim Cy As Single = CSng(myRect.Y) + (CSng(myRect.Height) / 2)

        Dim CenterF As New PointF(Cx, Cy)

        'Determine max radius of contained circle
        Dim maxR As Single = Math.Min(CSng(myRect.Width), CSng(myRect.Height)) / 2 - 2


        'Draw Gradient Fill between two rims
        Dim BetweenColor1 As Color = Color.White
        Dim BetweenColor2 As Color = Color.Black
        Dim BetweenWidth As Single = ChromeWidth '5.0!
        Dim BetweenRadius As Single = maxR
        myRectF = WidthAdjustedRectF(CenterF, BetweenRadius, 0)
        If myRectF.Height <= 0 OrElse myRectF.Width <= 0 Then Exit Sub 'Nothing to draw - bail out.
        myBrush = New LinearGradientBrush(myRectF, BetweenColor1, BetweenColor2, 25.0!)

        Dim colorBlend As New ColorBlend()
        'colorBlend.Colors = New Color() {Color.Black, Color.Silver, Color.Silver, Color.White}
        colorBlend.Colors = New Color() {Color.Black, _ChromeColor, _ChromeColor, Color.White}
        colorBlend.Positions = New Single() {0.0!, 0.1!, 0.5!, 1.0!}
        myBrush.InterpolationColors = colorBlend

        myG.FillEllipse(myBrush, myRectF)

        'Draw Outer Rim
        Dim OuterRimColor As Color = _RimColor
        Dim OuterRimWidth As Single = BorderWidth '2.0!
        Dim OuterRimRadius As Single = maxR
        myRectF = WidthAdjustedRectF(CenterF, maxR, OuterRimWidth)
        myPen = New Pen(OuterRimColor, OuterRimWidth)
        myPen.Alignment = PenAlignment.Center
        myG.DrawEllipse(myPen, myRectF)



        'Draw Inner Rim
        Dim InnerRimColor As Color = Color.White 'OuterRimColor
        Dim InnerRimWidth As Single = BorderWidth '2.0! 'OuterRimWidth
        Dim InnerRimRadius = BetweenRadius - BetweenWidth
        myRectF = WidthAdjustedRectF(CenterF, InnerRimRadius, InnerRimWidth)
        myPen = New Pen(InnerRimColor, InnerRimWidth)
        myPen.Alignment = PenAlignment.Center
        'myG.DrawEllipse(myPen, myRectF)

        'Draw "Light" circle
        Dim LightRadius As Single = InnerRimRadius - InnerRimWidth
        myRectF = WidthAdjustedRectF(CenterF, LightRadius, 0)
        myBrush = New LinearGradientBrush(myRectF, OnColor, OnColor, 25.0!)
        colorBlend = New ColorBlend()
        colorBlend.Colors = New Color() {Color.White, Color.White, OnColor, Color.Black, Color.Black}
        colorBlend.Positions = New Single() {0.0!, 0.15!, 0.3!, 0.99!, 1.0!}
        myBrush.InterpolationColors = colorBlend
        myG.FillEllipse(myBrush, myRectF)
    End Sub
    Private Function WidthAdjustedRectF(ByVal Center As PointF, ByVal Radius As Single, ByVal BorderWidth As Single) As RectangleF
        Dim b2 As Single = BorderWidth / 2
        Dim Top As New PointF(Center.X - Radius + b2, Center.Y - Radius + b2)
        Dim Size As New SizeF(2 * Radius - BorderWidth, 2 * Radius - BorderWidth)
        Return New RectangleF(Top, Size)
    End Function
#End Region



End Class
