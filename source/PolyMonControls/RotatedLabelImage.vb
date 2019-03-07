Imports System.Drawing.Drawing2D
Imports System.Drawing


Public Class RotatedLabelImage

#Region "Private Attributes"
    Private _Text As String = "Label Text"
    Private _Font As Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Private _TextColor As Color = Color.Black
    Private _TextAlignment As ContentAlignment = ContentAlignment.MiddleLeft
    Private _RotationAngle As Integer = -45

    Private _TransparentColor As Color = Color.Gray
    Private _MinHeight As Integer = 0
    Private _MinWidth As Integer = 0
    Private _FillStyle As FillStyles = FillStyles.Gradient
    Private _GradientOrientation As LinearGradientMode = LinearGradientMode.Vertical
    Private _Color0 As Color = Color.White
    Private _Color1 As Color = Color.LightSkyBlue

    Private _Height As Integer = 1
    Private _Width As Integer = 1
    Private _myBitmap As New Bitmap(_Width, _Height)
#End Region


#Region "Public Enums"
    Public Enum FillStyles As Integer
        Solid = 0
        Gradient = 1
        Transparent = 2
    End Enum
#End Region

#Region "Public Interface"
    Public Sub New()

    End Sub

    Public Property Text() As String
        Get
            Return _Text
        End Get
        Set(ByVal value As String)
            _Text = value
        End Set
    End Property
    Public Property Font() As Font
        Get
            Return _Font
        End Get
        Set(ByVal value As Font)
            _Font = value
        End Set
    End Property
    Public Property TextColor() As Color
        Get
            Return _TextColor
        End Get
        Set(ByVal value As Color)
            _TextColor = value
        End Set
    End Property
    Public Property TextAlignment() As ContentAlignment
        Get
            Return _TextAlignment
        End Get
        Set(ByVal value As ContentAlignment)
            _TextAlignment = value
        End Set
    End Property
    Public Property RotationAngle() As Integer
        Get
            Return _RotationAngle
        End Get
        Set(ByVal value As Integer)
            _RotationAngle = value
        End Set
    End Property
    Public Property TransparentColor() As Color
        Get
            Return _TransparentColor
        End Get
        Set(ByVal value As Color)
            _TransparentColor = value
        End Set
    End Property

    Public Property MinHeight() As Integer
        Get
            Return _MinHeight
        End Get
        Set(ByVal value As Integer)
            _MinHeight = value
        End Set
    End Property
    Public Property MinWidth() As Integer
        Get
            Return _MinWidth
        End Get
        Set(ByVal value As Integer)
            _MinWidth = value
        End Set
    End Property

    Public Property FillStyle() As FillStyles
        Get
            Return _FillStyle
        End Get
        Set(ByVal value As FillStyles)
            _FillStyle = value
        End Set
    End Property
    Public Property FillGradientOrientation() As LinearGradientMode
        Get
            Return _GradientOrientation
        End Get
        Set(ByVal value As LinearGradientMode)
            _GradientOrientation = value
        End Set
    End Property
    Public Property FillBackColor0() As Color
        Get
            Return _Color0
        End Get
        Set(ByVal value As Color)
            _Color0 = value
        End Set
    End Property
    Public Property FillBackColor1() As Color
        Get
            Return _Color1
        End Get
        Set(ByVal value As Color)
            _Color1 = value
        End Set
    End Property

    Public ReadOnly Property Bitmap() As Bitmap
        Get
            ReDraw() 'Generate bitmap
            _myBitmap.MakeTransparent(_TransparentColor)
            Return _myBitmap
        End Get
    End Property
    Public ReadOnly Property Height() As Integer
        Get
            Return _Height
        End Get
    End Property
    Public ReadOnly Property Width() As Integer
        Get
            Return _Width
        End Get
    End Property
    Public ReadOnly Property Size() As Size
        Get
            Return New Size(_Width, _Height)
        End Get
    End Property

    Public Sub SaveToFile(ByVal FilePath As String, ByVal FileType As System.Drawing.Imaging.ImageFormat)
        ReDraw() 'Generate bitmap
        _myBitmap.MakeTransparent(_TransparentColor)
        _myBitmap.Save(FilePath, FileType)
    End Sub
#End Region

#Region "Private Implementations"
    Private Sub ReDraw()
        Dim myG As Graphics
        myG = Graphics.FromImage(New Bitmap(1, 1))

        Dim TextHeight As Single = myG.MeasureString(_Text, _Font).Height
        Dim TextWidth As Single = myG.MeasureString(_Text, _Font).Width

        Dim myWidth As Single = myG.MeasureString(_Text, _Font).Width
        Dim myHeight As Single = myG.MeasureString(_Text, _Font).Height
        Dim VOffset As Single
        Dim HOffset As Single

        If myHeight < _MinHeight Then
            VOffset = (_MinHeight - myHeight) / 2
            myHeight = _MinHeight
        End If
        If myWidth < _MinWidth Then
            HOffset = (_MinWidth - myWidth) / 2
            myWidth = _MinWidth
        End If
        Dim myWidthMax As Integer = CInt(Math.Ceiling(myWidth))
        Dim myHeightMax As Integer = CInt(Math.Ceiling(myHeight))


        'Determine final width/height of rectangle that will encapsulate the drawing area
        Dim myBounds As New System.Windows.Rect(0, 0, myWidthMax, myHeightMax)
        Dim myTransf As System.Windows.Media.Transform = Nothing
        Dim angleRadian As Double = ((_RotationAngle Mod 360) / 180) * Math.PI

        If (_RotationAngle >= 0 AndAlso _RotationAngle < 90) Or (_RotationAngle < -270 AndAlso _RotationAngle >= -360) Then
            'Q1
            myBounds = New System.Windows.Media.TranslateTransform(CInt(Math.Sin(angleRadian) * myHeight), 0).TransformBounds(myBounds)
        ElseIf (_RotationAngle >= 90 AndAlso _RotationAngle < 180) Or (_RotationAngle < -180 AndAlso _RotationAngle >= -270) Then
            'Q2
            myBounds = New System.Windows.Media.TranslateTransform(myWidth, CInt(myHeight - (Math.Sin(angleRadian) * myHeight))).TransformBounds(myBounds)
        ElseIf (_RotationAngle >= 180 AndAlso _RotationAngle < 270) Or (_RotationAngle < -90 AndAlso _RotationAngle >= -180) Then
            'Q3
            myBounds = New System.Windows.Media.TranslateTransform(myWidth + CInt(Math.Sin(angleRadian) * myHeight), myHeight).TransformBounds(myBounds)
        Else
            'Q4
            myBounds = New System.Windows.Media.TranslateTransform(0, myHeight - CInt(Math.Cos(angleRadian) * myHeight)).TransformBounds(myBounds)
        End If

        'Rotate rectangle
        myBounds = New System.Windows.Media.RotateTransform(CInt(_RotationAngle)).TransformBounds(myBounds)

        'Retrieve Height and Width of bounding rectangle
        _Height = CInt(Math.Ceiling(myBounds.Height))
        _Width = CInt(Math.Ceiling(myBounds.Width))

        'Create new bitmap with appropriate dimensions
        _myBitmap = New Bitmap(_Width, _Height)
        myG = Graphics.FromImage(_myBitmap)


        'Initialize bitmap
        Dim backRect As Rectangle = New Rectangle(0, 0, _Width, _Height)
        myG.SmoothingMode = SmoothingMode.None


        'Now draw Gradient, Border, Text
        myG.SmoothingMode = Drawing2D.SmoothingMode.HighQuality

        'Translate graphics area so rotation will not clip the bounding rect
        If (_RotationAngle >= 0 AndAlso _RotationAngle < 90) Or (_RotationAngle < -270 AndAlso _RotationAngle >= -360) Then
            'Q1
            myG.TranslateTransform(CInt(Math.Sin(angleRadian) * myHeight), 0)
        ElseIf (_RotationAngle >= 90 AndAlso _RotationAngle < 180) Or (_RotationAngle < -180 AndAlso _RotationAngle >= -270) Then
            'Q2
            myG.TranslateTransform(_Width, CInt(myHeight - (Math.Sin(angleRadian) * myHeight)))
        ElseIf (_RotationAngle >= 180 AndAlso _RotationAngle < 270) Or (_RotationAngle < -90 AndAlso _RotationAngle >= -180) Then
            'Q3
            myG.TranslateTransform(_Width + CInt(Math.Sin(angleRadian) * myHeight), _Height)
        Else
            'Q4
            myG.TranslateTransform(0, _Height - CInt(Math.Cos(angleRadian) * myHeight))
        End If

        'Rotate graphics area
        myG.RotateTransform(CInt(_RotationAngle))

        'Draw Gradient Fill/Solid Fill/Trasparent background
        Dim FillRect As RectangleF
        Select Case Me.FillStyle
            Case FillStyles.Transparent
                FillRect = New RectangleF(0, 0, myWidthMax, myHeightMax)
                myG.SmoothingMode = SmoothingMode.None
                myG.FillRectangle(New SolidBrush(Me.TransparentColor), FillRect)
            Case FillStyles.Solid
                If Me.RotationAngle = 0 OrElse RotationAngle Mod 90 = 0 Then
                    myG.SmoothingMode = SmoothingMode.None
                Else
                    myG.SmoothingMode = SmoothingMode.HighQuality
                End If
                FillRect = New RectangleF(0, 0, myWidthMax, myHeightMax)
                myG.FillRectangle(New SolidBrush(Me.FillBackColor0), FillRect)
            Case FillStyles.Gradient
                FillRect = New RectangleF(0, 0, myWidthMax, myHeightMax)
                Dim FillRectBrush As New RectangleF(0, 0, myWidthMax, myHeightMax)
                Dim myFillBrush As New LinearGradientBrush(FillRectBrush, Me.FillBackColor0, Me.FillBackColor1, Me.FillGradientOrientation)
                If Me.RotationAngle = 0 OrElse RotationAngle Mod 90 = 0 Then
                    myG.SmoothingMode = SmoothingMode.None
                Else
                    myG.SmoothingMode = SmoothingMode.HighQuality
                End If

                myG.FillRectangle(myFillBrush, FillRect)
        End Select


        'Draw Text (using Text alignment options)
        Dim TextOffsetH As Single
        Dim TextOffsetV As Single

        Select Case _TextAlignment
            Case ContentAlignment.BottomCenter
                TextOffsetV = myHeight - VOffset
                TextOffsetH = HOffset
            Case ContentAlignment.BottomLeft
                TextOffsetV = myHeight - VOffset
                TextOffsetH = 0
            Case ContentAlignment.BottomRight
                TextOffsetV = myHeight - VOffset
                TextOffsetH = myWidth - TextWidth
            Case ContentAlignment.MiddleCenter
                TextOffsetV = VOffset
                TextOffsetH = HOffset
            Case ContentAlignment.MiddleLeft
                TextOffsetV = VOffset
                TextOffsetH = 0
            Case ContentAlignment.MiddleRight
                TextOffsetV = VOffset
                TextOffsetH = myWidth - TextWidth
            Case ContentAlignment.TopCenter
                TextOffsetV = 0
                TextOffsetH = HOffset
            Case ContentAlignment.TopLeft
                TextOffsetV = 0
                TextOffsetH = 0
            Case ContentAlignment.TopRight
                TextOffsetV = 0
                TextOffsetH = myWidth - TextWidth
        End Select
        Dim myTextBrush As Brush = New SolidBrush(_TextColor)
        myG.SmoothingMode = SmoothingMode.None
        If Me.FillStyle = FillStyles.Transparent Then
            myG.TextRenderingHint = Drawing.Text.TextRenderingHint.SingleBitPerPixelGridFit
        Else
            myG.TextRenderingHint = Drawing.Text.TextRenderingHint.ClearTypeGridFit
        End If

        myG.DrawString(_Text, _Font, myTextBrush, TextOffsetH, TextOffsetV)


        myG.ResetTransform()
    End Sub
#End Region

End Class
