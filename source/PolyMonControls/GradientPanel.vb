Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.Drawing
Imports System.Drawing.Drawing2D

<Designer("System.Windows.Forms.Design.ParentControlDesigner,System.Design", GetType(IDesigner)), _
ToolboxBitmap(GetType(GradientPanel), "GradientPanel.bmp")> _
Public Class GradientPanel
    Private _BorderWidth As Integer = 2
    Private _BorderRadius As Integer = 5
    Private _BorderColor As Color = Color.Red
    Private _BackColor1 As Color = Color.Red
    Private _BackColor2 As Color = Color.Gold
    Private _FillStyle As FillStyles = FillStyles.Gradient
    Private _GradientOrientation As LinearGradientMode = LinearGradientMode.Horizontal

    Public Enum GradientOrientations As Integer
        Horizontal = 0
        Vertical = 1
    End Enum

    Public Enum FillStyles As Integer
        Solid = 0
        Gradient = 1
    End Enum

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.SetStyle(ControlStyles.OptimizedDoubleBuffer, True)
        Me.SetStyle(ControlStyles.AllPaintingInWmPaint, True)
        Me.SetStyle(ControlStyles.ResizeRedraw, True)
        Me.SetStyle(ControlStyles.UserPaint, True)
    End Sub

    <Category("GradientPanel"), _
        Description("Sets the width of the panel border."), _
        DefaultValue(2)> _
    Public Property BorderWidth() As Integer
        Get
            Return _BorderWidth
        End Get
        Set(ByVal value As Integer)
            _BorderWidth = value
            Invalidate()
        End Set
    End Property

    <Category("GradientPanel"), _
        Description("Sets how rounded the corners of the panel border should be."), _
        DefaultValue(5)> _
    Public Property BorderRadius() As Integer
        Get
            Return _BorderRadius
        End Get
        Set(ByVal value As Integer)
            _BorderRadius = value
            Dim ClientRect As Rectangle = Me.ClientRectangle
            If ClientRect.Height < (_BorderRadius + _BorderWidth) * 2 Then
                _BorderRadius = ClientRect.Height \ 2 - _BorderWidth
            End If
            If ClientRect.Width < (_BorderRadius + _BorderWidth) * 2 Then
                _BorderRadius = ClientRect.Width \ 2 - _BorderWidth
            End If
            Invalidate()
        End Set
    End Property

    <Category("GradientPanel"), _
        Description("Sets the border color."), _
        DefaultValue(GetType(System.Drawing.Color), "Red")> _
    Public Property BorderColor() As Color
        Get
            Return _BorderColor
        End Get
        Set(ByVal value As Color)
            _BorderColor = value
            Invalidate()
        End Set
    End Property

    <Category("GradientPanel"), _
        Description("Sets the background fill style."), _
        DefaultValue(GetType(FillStyles), "Gradient")> _
    Public Property FillStyle() As FillStyles
        Get
            Return _FillStyle
        End Get
        Set(ByVal value As FillStyles)
            _FillStyle = value
            Invalidate()
        End Set
    End Property

    <Category("GradientPanel"), _
        Description("Sets the first color of the panel background (used in conjunction with BackColor2 for a gradient fill."), _
        DefaultValue(GetType(System.Drawing.Color), "Red")> _
    Public Property BackColor1() As Color
        Get
            Return _BackColor1
        End Get
        Set(ByVal value As Color)
            _BackColor1 = value
            Invalidate()
        End Set
    End Property

    <Category("GradientPanel"), _
        Description("Sets the second color of the panel background (only used for a Gradient type fill)."), _
        DefaultValue(GetType(System.Drawing.Color), "Gold")> _
    Public Property BackColor2() As Color
        Get
            Return _BackColor2
        End Get
        Set(ByVal value As Color)
            _BackColor2 = value
            Invalidate()
        End Set
    End Property


    <Category("GradientPanel"), _
        Description("Sets the orientation of the gradient fill."), _
        DefaultValue(GetType(Orientation), "LinearGradientMode.Horizontal")> _
   Public Property GradientOrientation() As LinearGradientMode
        Get
            Return _GradientOrientation
        End Get
        Set(ByVal value As LinearGradientMode)
            _GradientOrientation = value
            Invalidate()
        End Set
    End Property

    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        MyBase.OnPaint(e)

        UpdateLayout(e.Graphics)
    End Sub

    Private Sub UpdateLayout(ByRef myG As Graphics)
        myG.SmoothingMode = SmoothingMode.AntiAlias

        'Create Border Polygon
        Dim Size As Single = _BorderRadius * 2
        Dim gp As New GraphicsPath
        Dim ClientRect As Rectangle = Me.ClientRectangle

        Dim RectX As Single = CSng(Math.Floor(CSng(ClientRect.X) + (CSng(_BorderWidth) / 2)))
        Dim RectY As Single = CSng(Math.Floor(CSng(ClientRect.Y) + (CSng(_BorderWidth) / 2)))
        Dim RectWidth As Single = CSng(Math.Ceiling(CSng(ClientRect.Width) - (2.0! * CSng(_BorderWidth))))
        Dim RectHeight As Single = CSng(Math.Ceiling(CSng(ClientRect.Height) - (2.0! * CSng(_BorderWidth))))
        If _BorderRadius = 0 Then
            'No Rounding
            gp.AddLine(RectX, RectY, RectX + RectWidth, RectY)
            gp.AddLine(RectX + RectWidth, RectY, RectX + RectWidth, RectY + RectHeight)
            gp.AddLine(RectX + RectWidth, RectY + RectHeight, RectX, RectY + RectHeight)
            gp.AddLine(RectX, RectY + RectHeight, RectX, RectY)
            gp.CloseFigure()
        Else
            'Apply Rounding
            gp.AddArc(RectX, RectY, Size, Size, 180, 90)
            gp.AddArc((RectX + (RectWidth - Size)), RectY, Size, Size, 270, 90)
            gp.AddArc((RectX + (RectWidth - Size)), (RectY + (RectHeight - Size)), Size, Size, 360, 90)
            gp.AddArc(RectX, (RectY + (RectHeight - Size)), Size, Size, 90, 90)
            gp.CloseFigure()
        End If


        'Fill Gauge Polygon
        If _FillStyle = FillStyles.Gradient Then
            Dim myBrush As LinearGradientBrush
            myBrush = New LinearGradientBrush(New Rectangle(CInt(RectX), CInt(RectY), _
                                                               CInt(RectWidth), CInt(RectHeight)), _
                                                               Me._BackColor1, Me._BackColor2, Me._GradientOrientation)
            myG.FillPath(myBrush, gp)
        Else
            myG.FillPath(New SolidBrush(Me._BackColor1), gp)
        End If

        'Draw Border
        If _BorderWidth > 0 Then

            Dim myPen As New Pen(_BorderColor, _BorderWidth)
            myPen.Alignment = PenAlignment.Inset
            myG.DrawPath(myPen, gp)
        End If
    End Sub
End Class
