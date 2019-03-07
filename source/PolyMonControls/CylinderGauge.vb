Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.ComponentModel
Imports System.ComponentModel.Design

<DefaultEvent("Click"), ToolboxBitmap(GetType(StatusLight), "CylinderGauge.bmp")> _
Public Class CylinderGauge
#Region "Defaults"
    Private Const WS_EX_TRANSPARENT As Int16 = &H20

    Private Const def_FillPerc As Integer = 50
    Private Const def_DisplayLabels As Boolean = True
    Private Const def_LabelAlign As String = "Center"
    Private Const def_FillColor As String = "DarkSlateBlue"
    Private Const def_EmptyColor As String = "LightGray"
#End Region

#Region "Private Attributes"
    Private _FillPerc As Integer = def_FillPerc
    Private _DisplayLabels As Boolean = def_DisplayLabels
    Private _FillColor As Color = System.Drawing.Color.FromName(def_FillColor)
    Private _EmptyColor As Color = System.Drawing.Color.FromName(def_EmptyColor)
    Private _LabelAlign As LabelAlignment = CType([Enum].Parse(GetType(LabelAlignment), def_LabelAlign), LabelAlignment)
#End Region

#Region "Public Enumerations"
    Public Enum LabelAlignment As Integer
        Left = 0
        Center = 1
        Right = 2
    End Enum
#End Region

#Region "Public Interface"
    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.SetStyle(ControlStyles.OptimizedDoubleBuffer, False) 'Turn double-buffering off for transparency
        Me.SetStyle(ControlStyles.AllPaintingInWmPaint, False)
        Me.SetStyle(ControlStyles.ResizeRedraw, True)
        Me.SetStyle(ControlStyles.UserPaint, True)
        Me.SetStyle(ControlStyles.SupportsTransparentBackColor, True)
        Me.SetStyle(ControlStyles.Opaque, True)
        Me.BackColor = Color.Transparent
    End Sub

    <Category("CylinderGauge"), _
        Description("Sets the % fill of the Gauge (0-100)."), _
        DefaultValue(def_FillPerc), _
        BrowsableAttribute(True)> _
    Public Property FillPercentage() As Integer
        Get
            Return _FillPerc
        End Get
        Set(ByVal value As Integer)
            _FillPerc = value
            If Me.Parent Is Nothing Then
                Me.Invalidate()
            Else
                Me.Parent.Invalidate()
            End If
        End Set
    End Property

    <Category("CylinderGauge"), _
            Description("Sets whether to show a label indicating % Fill (used in conjunction with LabelAlign setting)."), _
            DefaultValue(def_DisplayLabels), _
            BrowsableAttribute(True)> _
        Public Property DisplayLabels() As Boolean
        Get
            Return _DisplayLabels
        End Get
        Set(ByVal value As Boolean)
            _DisplayLabels = value
            If Me.Parent Is Nothing Then
                Me.Invalidate()
            Else
                Me.Parent.Invalidate()
            End If
        End Set
    End Property

    <Category("CylinderGauge"), _
        Description("If labels are displayed (DisplayLabels setting), determines alignment of labels with respect to cylinder."), _
        DefaultValue(GetType(LabelAlignment), def_LabelAlign), _
        BrowsableAttribute(True)> _
Public Property LabelAlign() As LabelAlignment
        Get
            Return _LabelAlign
        End Get
        Set(ByVal value As LabelAlignment)
            _LabelAlign = value
            If Me.Parent Is Nothing Then
                Me.Invalidate()
            Else
                Me.Parent.Invalidate()
            End If
        End Set
    End Property

    <Category("CylinderGauge"), _
        Description("Determines Color of Filled portion of the cylinder gauge."), _
        DefaultValue(GetType(Color), def_FillColor), _
        BrowsableAttribute(True)> _
    Public Property FillColor() As Color
        Get
            Return _FillColor
        End Get
        Set(ByVal value As Color)
            _FillColor = value
            If Me.Parent Is Nothing Then
                Me.Invalidate()
            Else
                Me.Parent.Invalidate()
            End If
        End Set
    End Property

    <Category("CylinderGauge"), _
        Description("Determines Color of Empty portion of the cylinder gauge."), _
        DefaultValue(GetType(Color), def_EmptyColor), _
        BrowsableAttribute(True)> _
    Public Property EmptyColor() As Color
        Get
            Return _EmptyColor
        End Get
        Set(ByVal value As Color)
            _EmptyColor = value
            If Me.Parent Is Nothing Then
                Me.Invalidate()
            Else
                Me.Parent.Invalidate()
            End If
        End Set
    End Property
#End Region

#Region "Private Methods"

    Protected Overrides ReadOnly Property CreateParams() As System.Windows.Forms.CreateParams
        Get
            Dim cp As CreateParams = MyBase.CreateParams
            cp.ExStyle = cp.ExStyle Or WS_EX_TRANSPARENT
            Return cp
        End Get
    End Property
    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        MyBase.OnPaint(e)

        Dim myG As Graphics = e.Graphics
        myG.SmoothingMode = SmoothingMode.HighQuality

        Dim MiddleLabel As String = String.Format("{0}%", FillPercentage)

        Dim FillPerc As Integer = CInt(Math.Min(100, Math.Abs(100 - FillPercentage)))

        Dim TextWidth As Single = myG.MeasureString("999%", Me.Font).Width
        Dim TextHeight As Single = myG.MeasureString("999%", Me.Font).Height

        Dim height As Single = Me.Height
        Dim width As Single = 0
        If DisplayLabels Then
            Select Case LabelAlign
                Case LabelAlignment.Left, LabelAlignment.Right
                    width = Me.Width - TextWidth - 5
                Case LabelAlignment.Center
                    width = Me.Width
            End Select
        Else
            width = Me.Width
        End If

        If width < 0 Then width = 5
        If height < 0 Then height = 5


        Dim BottomColor As Color = FillColor
        Dim TopColor As Color = EmptyColor

        'Calculated Colors
        Dim BorderColor As Color = TopColor
        Dim DimBottomColor As Color = Color.FromArgb(Math.Min(255, BottomColor.R + 180), Math.Min(255, BottomColor.G + 180), Math.Min(255, BottomColor.B + 180))
        Dim DimTopColor As Color = Color.FromArgb(Math.Min(255, TopColor.R + 180), Math.Min(255, TopColor.G + 180), Math.Min(255, TopColor.B + 180))
        Dim LessDimTopColor As Color = Color.FromArgb(Math.Min(255, TopColor.R + 96), Math.Min(255, TopColor.G + 96), Math.Min(255, TopColor.B + 96))
        Dim LessDimBottomColor As Color = Color.FromArgb(Math.Min(255, BottomColor.R + 96), Math.Min(255, BottomColor.G + 96), Math.Min(255, BottomColor.B + 96))
        Dim BottomBorderColor As Color = Color.FromArgb(Math.Max(0, BottomColor.R - 50), Math.Max(0, BottomColor.G - 50), Math.Max(0, BottomColor.B - 50))
        Dim TopBorderColor As Color = Color.FromArgb(Math.Max(0, TopColor.R - 50), Math.Max(0, TopColor.G - 50), Math.Max(0, TopColor.B - 50))
        Dim BorderPen As New Pen(BorderColor)


        If FillPerc > 0 And FillPerc < 100 Then
            'Top Rectangle
            Dim TopX As Single
            If DisplayLabels Then
                Select Case LabelAlign
                    Case LabelAlignment.Left
                        TopX = TextWidth + 2
                    Case LabelAlignment.Right
                        TopX = 0
                    Case LabelAlignment.Center
                        TopX = 0
                End Select
            Else
                TopX = 0
            End If

            Dim TopY As Single = height / 10.0!
            Dim TopHeight As Single = FillPerc * (height - height / 5) / 100
            Dim TopWidth As Single = width - 1

            'Bottom Rectangle
            Dim BottomX As Single = TopX
            Dim BottomY As Single = TopY + TopHeight
            Dim BottomHeight As Single = (height - height / 5) - TopHeight
            Dim BottomWidth As Single = TopWidth

            Dim BottomGradientBrush As New LinearGradientBrush(New RectangleF(BottomX, BottomY, BottomWidth + 50, BottomHeight), DimBottomColor, BottomColor, 0.0F)
            Dim TopGradientBrush As New LinearGradientBrush(New RectangleF(TopX, TopY, TopWidth + 50, TopHeight), DimTopColor, TopColor, 0.0F)
            Dim TopEllipseGradientBrush As New LinearGradientBrush(New RectangleF(TopX, 0, TopWidth - 1, height), LessDimTopColor, TopColor, 0.0F)

            'Fill Main Bodies
            myG.FillRectangle(TopGradientBrush, New RectangleF(TopX, TopY, TopWidth - 1, TopHeight))
            myG.FillRectangle(BottomGradientBrush, New RectangleF(BottomX, BottomY, BottomWidth - 1, BottomHeight))

            'Fill Top Ellipse
            myG.FillEllipse(TopEllipseGradientBrush, New RectangleF(TopX, 0, TopWidth - 1, height / 5))

            'Fill Bottom Ellipse
            myG.FillEllipse(BottomGradientBrush, New RectangleF(TopX, height - height / 5 - 1, TopWidth - 1, height / 5))

            'Fill Middle Ellipse
            myG.FillEllipse(TopGradientBrush, New RectangleF(TopX, BottomY - height / 10 - 1, TopWidth - 1, height / 5))

            'Left/Right cylinder border
            myG.DrawLine(BorderPen, New PointF(TopX, height / 10), New PointF(TopX, height - height / 10))
            myG.DrawLine(BorderPen, New PointF(TopX + TopWidth - 1, height / 10), New PointF(TopX + TopWidth - 1, height - height / 10))

            'Top Ellipse Border
            myG.DrawEllipse(BorderPen, New RectangleF(TopX, 0, TopWidth - 1, height / 5))

            'Bottom Ellipse Border
            myG.DrawArc(BorderPen, New RectangleF(TopX, height - height / 5 - 1, TopWidth - 1, height / 5), 0.0F, 180.0F)

            'Middle Ellpise Border
            myG.DrawArc(BorderPen, New RectangleF(TopX, BottomY - height / 10 - 1, TopWidth - 1, height / 5), 0.0F, 180.0F)

            'Text Label - Middle
            If DisplayLabels Then
                Select Case LabelAlign
                    Case LabelAlignment.Left
                        myG.DrawString(MiddleLabel, Me.Font, New SolidBrush(Me.ForeColor), 0, BottomY)
                    Case LabelAlignment.Center
                        myG.DrawString(MiddleLabel, Me.Font, New SolidBrush(Me.ForeColor), (width - TextWidth) / 2, BottomY + height / 10 - TextHeight - 2)
                    Case LabelAlignment.Right
                        myG.DrawString(MiddleLabel, Me.Font, New SolidBrush(Me.ForeColor), width + 3, BottomY)
                End Select
            End If

        Else
            If FillPerc = 100 Then
                'All Empty
                Dim TopX As Single
                If DisplayLabels Then
                    Select Case LabelAlign
                        Case LabelAlignment.Left
                            TopX = TextWidth + 2
                        Case LabelAlignment.Right
                            TopX = 0
                        Case LabelAlignment.Center
                            TopX = 0
                    End Select
                Else
                    TopX = 0
                End If

                Dim TopY As Single = height / 10.0!
                Dim TopHeight As Single = (height - height / 5)
                Dim TopWidth As Single = width - 1

                Dim TopGradientBrush As New LinearGradientBrush(New RectangleF(TopX, TopY, TopWidth + 50, TopHeight), DimTopColor, TopColor, 0.0F)
                Dim TopEllipseGradientBrush As New LinearGradientBrush(New RectangleF(TopX, 0, TopWidth - 1, height), LessDimTopColor, TopColor, 0.0F)

                'Fill Main Bodies
                myG.FillRectangle(TopGradientBrush, New RectangleF(TopX, TopY, TopWidth - 1, TopHeight))


                'Fill Top Ellipse
                myG.FillEllipse(TopEllipseGradientBrush, New RectangleF(TopX, 0, TopWidth - 1, height / 5))

                'Fill Bottom Ellipse
                myG.FillEllipse(TopGradientBrush, New RectangleF(TopX, height - height / 5 - 1, TopWidth - 1, height / 5))

                'Left/Right cylinder border
                myG.DrawLine(BorderPen, New PointF(TopX, height / 10), New PointF(TopX, height - height / 10))
                myG.DrawLine(BorderPen, New PointF(TopX + TopWidth - 1, height / 10), New PointF(TopX + TopWidth - 1, height - height / 10))

                'Top Ellipse Border
                myG.DrawEllipse(BorderPen, New RectangleF(TopX, 0, TopWidth - 1, height / 5))

                'Bottom Ellipse Border
                myG.DrawArc(BorderPen, New RectangleF(TopX, height - height / 5 - 1, TopWidth - 1, height / 5), 0.0F, 180.0F)

                'Text Label - Middle
                If DisplayLabels Then
                    Select Case LabelAlign
                        Case LabelAlignment.Left
                            myG.DrawString(MiddleLabel, Me.Font, New SolidBrush(Me.ForeColor), 0, TopY + TopHeight - TextHeight)
                        Case LabelAlignment.Center
                            myG.DrawString(MiddleLabel, Me.Font, New SolidBrush(Me.ForeColor), (width - TextWidth) / 2, TopY + TopHeight + height / 10 - TextHeight - 2)
                        Case LabelAlignment.Right
                            myG.DrawString(MiddleLabel, Me.Font, New SolidBrush(Me.ForeColor), width + 3, TopY + TopHeight - TextHeight)
                    End Select
                End If

            Else
                'All Full
                'All Empty
                Dim TopX As Single
                If DisplayLabels Then
                    Select Case LabelAlign
                        Case LabelAlignment.Left
                            TopX = TextWidth + 2
                        Case LabelAlignment.Right
                            TopX = 0
                        Case LabelAlignment.Center
                            TopX = 0
                    End Select
                Else
                    TopX = 0
                End If

                Dim TopY As Single = height / 10.0!
                Dim TopHeight As Single = (height - height / 5)
                Dim TopWidth As Single = width - 1

                Dim TopGradientBrush As New LinearGradientBrush(New RectangleF(TopX, TopY, TopWidth + 50, TopHeight), DimBottomColor, BottomColor, 0.0F)
                Dim TopEllipseGradientBrush As New LinearGradientBrush(New RectangleF(TopX, 0, TopWidth - 1, height), LessDimBottomColor, BottomColor, 0.0F)

                'Fill Main Bodies
                myG.FillRectangle(TopGradientBrush, New RectangleF(TopX, TopY, TopWidth - 1, TopHeight))


                'Fill Top Ellipse
                myG.FillEllipse(TopEllipseGradientBrush, New RectangleF(TopX, 0, TopWidth - 1, height / 5))

                'Fill Bottom Ellipse
                myG.FillEllipse(TopGradientBrush, New RectangleF(TopX, height - height / 5 - 1, TopWidth - 1, height / 5))

                'Left/Right cylinder border
                myG.DrawLine(BorderPen, New PointF(TopX, height / 10), New PointF(TopX, height - height / 10))
                myG.DrawLine(BorderPen, New PointF(TopX + TopWidth - 1, height / 10), New PointF(TopX + TopWidth - 1, height - height / 10))

                'Top Ellipse Border
                myG.DrawEllipse(BorderPen, New RectangleF(TopX, 0, TopWidth - 1, height / 5))

                'Bottom Ellipse Border
                myG.DrawArc(BorderPen, New RectangleF(TopX, height - height / 5 - 1, TopWidth - 1, height / 5), 0.0F, 180.0F)

                'Text Label - Middle
                If DisplayLabels Then
                    Select Case LabelAlign
                        Case LabelAlignment.Left
                            myG.DrawString(MiddleLabel, Me.Font, New SolidBrush(Me.ForeColor), 0, TopY)
                        Case LabelAlignment.Center
                            myG.DrawString(MiddleLabel, Me.Font, New SolidBrush(Me.ForeColor), (width - TextWidth) / 2, TopY + height / 10 - TextHeight - 2)
                        Case LabelAlignment.Right
                            myG.DrawString(MiddleLabel, Me.Font, New SolidBrush(Me.ForeColor), width + 3, TopY)
                    End Select
                End If

                'Text Label - Middle
                'If DisplayLabels Then myG.DrawString(MiddleLabel, Me.Font, New SolidBrush(Me.ForeColor), width + 3, BottomY)
            End If
        End If



    End Sub
#End Region
End Class
