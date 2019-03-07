Imports System.Drawing.Drawing2D
Imports System.Drawing
Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System
Imports System.Drawing.Design
Imports System.Reflection
Imports System.Windows.Forms
Imports System.Windows.Forms.Design

<ToolboxBitmap(GetType(RotatedLabel), "RotatedLabel")> _
Public Class RotatedLabel

#Region "Default Values"
    Private Const def_Text As String = "Label Text"
    Private Const def_TextColor As String = "Black"
    Private Const def_TextAlignment As String = "MiddleCenter"
    Private Const def_RotationAngle As Integer = 45

    Private Const def_MinHeight As Integer = 0
    Private Const def_MinWidth As Integer = 0
    Private Const def_FillStyle As String = "Gradient"
    Private Const def_GradientOrientation As String = "Vertical"
    Private Const def_Color0 As String = "Gold"
    Private Const def_Color1 As String = "DarkGoldenrod"

    Private Const def_Height As Integer = 50
    Private Const def_Width As Integer = 50
#End Region


#Region "Private Attributes"
    Private Const WS_EX_TRANSPARENT As Int16 = &H20

    Private _Text As String = def_Text
    Private _TextColor As Color = System.Drawing.Color.FromName(def_TextColor)
    Private _TextAlignment As ContentAlignment = CType([Enum].Parse(GetType(ContentAlignment), def_TextAlignment), ContentAlignment)
    Private _RotationAngle As Integer = def_RotationAngle

    Private _MinHeight As Integer = def_MinHeight
    Private _MinWidth As Integer = def_MinWidth
    Private _FillStyle As FillStyles = CType([Enum].Parse(GetType(FillStyles), def_FillStyle), FillStyles)
    Private _GradientOrientation As LinearGradientMode = CType([Enum].Parse(GetType(LinearGradientMode), def_GradientOrientation), LinearGradientMode)
    Private _Color0 As Color = System.Drawing.Color.FromName(def_Color0)
    Private _Color1 As Color = System.Drawing.Color.FromName(def_Color1)

    Private _Height As Integer = def_Height
    Private _Width As Integer = def_Width
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
        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.SetStyle(ControlStyles.OptimizedDoubleBuffer, False) 'Turn double-buffering off
        Me.SetStyle(ControlStyles.AllPaintingInWmPaint, True)
        Me.SetStyle(ControlStyles.ResizeRedraw, True)
        Me.SetStyle(ControlStyles.UserPaint, True)
        Me.SetStyle(ControlStyles.SupportsTransparentBackColor, True)
        Me.SetStyle(ControlStyles.Opaque, True)
        Me.BackColor = Color.Transparent
    End Sub

    <DefaultValue(def_Text)> _
    Public Overrides Property Text() As String
        Get
            Return _Text
        End Get
        Set(ByVal value As String)
            _Text = value
            Me.Refresh()
        End Set
    End Property

    <Category("Appearance"), _
        Description("Sets the Text alignment of the rotated label."), _
        DefaultValue(GetType(ContentAlignment), def_TextAlignment)> _
    Public Property TextAlignment() As ContentAlignment
        Get
            Return _TextAlignment
        End Get
        Set(ByVal value As ContentAlignment)
            _TextAlignment = value
            Me.Refresh()
        End Set
    End Property


    <Category("LabelExt"), _
        Description("Sets the rotation angle of the label."), _
        DefaultValue(def_RotationAngle), _
        RefreshProperties(RefreshProperties.All), _
        BrowsableAttribute(True), EditorAttribute(GetType(AngleEditor), GetType(System.Drawing.Design.UITypeEditor)) _
> _
Public Property RotationAngle() As Integer
        Get
            Return _RotationAngle
        End Get
        Set(ByVal value As Integer)
            If value = -_RotationAngle Then
                'Seems to be a bug in the refresh somewhere
                'Refresh does not happen correctly when New Angle=-Current Angle
                'Weird...
                Me.SuspendLayout()
                _RotationAngle = _RotationAngle + 1
                Me.Refresh()
                _RotationAngle = value
                Me.Refresh()
                Me.ResumeLayout()
            Else
                _RotationAngle = value
                Me.Refresh()
            End If
        End Set
    End Property

    <Category("LabelExt"), _
        Description("Sets the minimum height of the label. Actual height may be greater depending on font attributes."), _
        DefaultValue(def_MinHeight)> _
    Public Property MinHeight() As Integer
        Get
            Return _MinHeight
        End Get
        Set(ByVal value As Integer)
            _MinHeight = value
            Me.Refresh()
        End Set
    End Property

    <Category("LabelExt"), _
        Description("Sets the minimum width of the label. Actual width may be greater depending on label text and font attributes."), _
        DefaultValue(def_MinWidth)> _
    Public Property MinWidth() As Integer
        Get
            Return _MinWidth
        End Get
        Set(ByVal value As Integer)
            _MinWidth = value
            Me.Refresh()
        End Set
    End Property

    <Category("LabelExt"), _
        Description("Sets the label fill style. Gradient fill uses the FillBackColor0, FillBackColor1 and FillGradient Orientations. A Solid fill uses the FillBackColor0 value only."), _
        DefaultValue(GetType(FillStyles), def_FillStyle)> _
    Public Property FillStyle() As FillStyles
        Get
            Return _FillStyle
        End Get
        Set(ByVal value As FillStyles)
            _FillStyle = value
            Me.Refresh()
        End Set
    End Property

    <Category("LabelExt"), _
        Description("Sets the Gradient fill orientation when FillStyle=Gradient."), _
        DefaultValue(GetType(LinearGradientMode), def_GradientOrientation)> _
    Public Property FillGradientOrientation() As LinearGradientMode
        Get
            Return _GradientOrientation
        End Get
        Set(ByVal value As LinearGradientMode)
            _GradientOrientation = value
            Me.Refresh()
        End Set
    End Property

    <Category("LabelExt"), _
        Description("Sets the Background color of the label is FillStyle=Solid or the Start color if FillStyle=Gradient. Ignored if FillStyle=Transparent."), _
        DefaultValue(GetType(Color), def_Color0)> _
    Public Property FillBackColor0() As Color
        Get
            Return _Color0
        End Get
        Set(ByVal value As Color)
            _Color0 = value
            Me.Refresh()
        End Set
    End Property

    <Category("LabelExt"), _
        Description("Sets the End color of the label background when FillStyle=Gradient."), _
        DefaultValue(GetType(Color), def_Color1)> _
    Public Property FillBackColor1() As Color
        Get
            Return _Color1
        End Get
        Set(ByVal value As Color)
            _Color1 = value
            Me.Refresh()
        End Set
    End Property


#End Region

    Private _Size As Size = New Size(0, 0)
    Public Property mySize() As Size
        Get
            Return _Size
        End Get
        Set(ByVal value As Size)
            _Size = value
        End Set
    End Property


#Region "Event Overrides"
    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        MyBase.OnPaint(e)
        ReDraw(e.Graphics)
    End Sub

    Protected Overrides Sub OnFontChanged(ByVal e As System.EventArgs)
        MyBase.OnFontChanged(e)
        Invalidate()
    End Sub
    Protected Overrides Sub OnForeColorChanged(ByVal e As System.EventArgs)
        MyBase.OnForeColorChanged(e)
        Invalidate()
    End Sub
    Protected Overrides Sub OnPaddingChanged(ByVal e As System.EventArgs)
        MyBase.OnPaddingChanged(e)
        Invalidate()
    End Sub
    Protected Overrides ReadOnly Property CreateParams() As System.Windows.Forms.CreateParams
        Get
            Dim cp As CreateParams = MyBase.CreateParams
            cp.ExStyle = cp.ExStyle Or WS_EX_TRANSPARENT
            Return cp
        End Get
    End Property
#End Region

#Region "Private Implementations"
    Private Sub ReDraw(ByRef myG As Graphics)
        Dim TextHeight As Single = myG.MeasureString(_Text, Me.Font).Height
        Dim TextWidth As Single = myG.MeasureString(_Text, Me.Font).Width

        Dim myWidth As Single = myG.MeasureString(_Text, Me.Font).Width
        Dim myHeight As Single = myG.MeasureString(_Text, Me.Font).Height

        ''Take Padding into account
        myHeight += Me.Padding.Top + Me.Padding.Bottom
        myWidth += Me.Padding.Left + Me.Padding.Right

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
        Dim Angle As Integer = _RotationAngle
        Dim angleRadian As Double = ((Angle Mod 360) / 180) * Math.PI

        If (Angle >= 0 AndAlso Angle < 90) Or (Angle < -270 AndAlso Angle >= -360) Then
            'Q1
            myBounds = New System.Windows.Media.TranslateTransform(CInt(Math.Sin(angleRadian) * myHeight), 0).TransformBounds(myBounds)
        ElseIf (Angle >= 90 AndAlso Angle < 180) Or (Angle < -180 AndAlso Angle >= -270) Then
            'Q2
            myBounds = New System.Windows.Media.TranslateTransform(myWidth, CInt(myHeight - (Math.Sin(angleRadian) * myHeight))).TransformBounds(myBounds)
        ElseIf (Angle >= 180 AndAlso Angle < 270) Or (Angle < -90 AndAlso Angle >= -180) Then
            'Q3
            myBounds = New System.Windows.Media.TranslateTransform(myWidth + CInt(Math.Sin(angleRadian) * myHeight), myHeight).TransformBounds(myBounds)
        Else
            'Q4
            myBounds = New System.Windows.Media.TranslateTransform(0, myHeight - CInt(Math.Cos(angleRadian) * myHeight)).TransformBounds(myBounds)
        End If

        'Rotate rectangle
        myBounds = New System.Windows.Media.RotateTransform(CInt(Angle)).TransformBounds(myBounds)

        'Retrieve Height and Width of bounding rectangle (add 1 px to each axis so we can later shift by 1 px to avoid clipping any corners)
        _Height = CInt(Math.Ceiling(myBounds.Height)) + 1
        _Width = CInt(Math.Ceiling(myBounds.Width)) + 1


        'Resize Area
        Me.Size = New Size(_Width, _Height)

        'Now draw Gradient, Border, Text
        myG.SmoothingMode = Drawing2D.SmoothingMode.HighQuality

        'Translate graphics area so rotation will not clip the bounding rect
        If (Angle >= 0 AndAlso Angle < 90) Or (Angle < -270 AndAlso Angle >= -360) Then
            'Q1
            myG.TranslateTransform(CInt(Math.Sin(angleRadian) * myHeight), 0)
        ElseIf (Angle >= 90 AndAlso Angle < 180) Or (Angle < -180 AndAlso Angle >= -270) Then
            'Q2
            myG.TranslateTransform(_Width, CInt(myHeight - (Math.Sin(angleRadian) * myHeight)))
        ElseIf (Angle >= 180 AndAlso Angle < 270) Or (Angle < -90 AndAlso Angle >= -180) Then
            'Q3
            myG.TranslateTransform(_Width + CInt(Math.Sin(angleRadian) * myHeight), _Height)
        Else
            'Q4
            myG.TranslateTransform(0, _Height - CInt(Math.Cos(angleRadian) * myHeight))
        End If

        'Finally Shift 1px right and 1px up to avoid clipping
        myG.TranslateTransform(1, -1)

        'Rotate graphics area
        myG.RotateTransform(CInt(Angle))

        'Draw Gradient Fill/Solid Fill/Trasparent background
        Dim FillRect As RectangleF
        Select Case Me.FillStyle
            Case FillStyles.Transparent
                FillRect = New RectangleF(0, 0, myWidthMax, myHeightMax)
                myG.SmoothingMode = SmoothingMode.None
                myG.FillRectangle(New SolidBrush(Color.Transparent), FillRect)
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

        'Take into account padding
        TextOffsetH += Me.Padding.Left
        TextOffsetV += Me.Padding.Top

        myG.DrawString(_Text, Me.Font, myTextBrush, TextOffsetH, TextOffsetV)

        myG.ResetTransform()
        myG.Dispose()
    End Sub
#End Region

End Class

<System.Security.Permissions.PermissionSetAttribute(System.Security.Permissions.SecurityAction.Demand, Name:="FullTrust")> _
Public Class AngleEditor
    Inherits System.Drawing.Design.UITypeEditor

    Public Sub New()
    End Sub

    ' Indicates whether the UITypeEditor provides a form-based (modal) dialog, 
    ' drop down dialog, or no UI outside of the properties window.
    Public Overloads Overrides Function GetEditStyle(ByVal context As System.ComponentModel.ITypeDescriptorContext) As System.Drawing.Design.UITypeEditorEditStyle
        Return UITypeEditorEditStyle.DropDown
        'Return UITypeEditorEditStyle.None
    End Function

    ' Displays the UI for value selection.
    Public Overloads Overrides Function EditValue(ByVal context As System.ComponentModel.ITypeDescriptorContext, ByVal provider As System.IServiceProvider, ByVal value As Object) As Object
        ' Return the value if the value is not of type Int32, Double and Single.
        If value.GetType() IsNot GetType(Double) AndAlso value.GetType() IsNot GetType(Single) AndAlso value.GetType() IsNot GetType(Integer) Then
            Return value
        End If
        ' Uses the IWindowsFormsEditorService to display a 
        ' drop-down UI in the Properties window.
        Dim edSvc As IWindowsFormsEditorService = CType(provider.GetService(GetType(IWindowsFormsEditorService)), IWindowsFormsEditorService)
        If (edSvc IsNot Nothing) Then
            ' Display an angle selection control and retrieve the value.
            Dim angleControl As New AngleControl(System.Convert.ToSingle(value))
            edSvc.DropDownControl(angleControl)

            ' Return the value in the appropraite data format.
            If value Is GetType(Double) Then
                Return angleControl.angle
            ElseIf value Is GetType(Single) Then
                Return System.Convert.ToSingle(angleControl.angle)
            ElseIf value Is GetType(Integer) Then
                Return System.Convert.ToInt32(angleControl.angle)
            End If
        End If
        Return value
    End Function

    ' Draws a representation of the property's value.
    Public Overloads Overrides Sub PaintValue(ByVal e As System.Drawing.Design.PaintValueEventArgs)
        Dim normalX As Integer = CInt(e.Bounds.Width / 2)
        Dim normalY As Integer = CInt(e.Bounds.Height / 2)

        ' Fill background and ellipse and center point.
        e.Graphics.FillRectangle(New SolidBrush(Color.DarkBlue), e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height)
        e.Graphics.FillEllipse(New SolidBrush(Color.White), e.Bounds.X + 1, e.Bounds.Y + 1, e.Bounds.Width - 3, e.Bounds.Height - 3)
        e.Graphics.FillEllipse(New SolidBrush(Color.SlateGray), normalX + e.Bounds.X - 1, normalY + e.Bounds.Y - 1, 3, 3)

        ' Draw line along the current angle.
        Dim radians As Double = System.Convert.ToDouble(e.Value) * Math.PI / System.Convert.ToDouble(180)
        e.Graphics.DrawLine(New Pen(New SolidBrush(Color.Red), 1), normalX + e.Bounds.X, normalY + e.Bounds.Y, e.Bounds.X + (normalX + System.Convert.ToInt32(System.Convert.ToDouble(normalX) * Math.Cos(radians))), e.Bounds.Y + (normalY + System.Convert.ToInt32(System.Convert.ToDouble(normalY) * Math.Sin(radians))))
    End Sub

    ' Indicates whether the UITypeEditor supports painting a 
    ' representation of a property's value.
    Public Overloads Overrides Function GetPaintValueSupported(ByVal context As System.ComponentModel.ITypeDescriptorContext) As Boolean
        Return True
    End Function
End Class

' Provides a user interface for adjusting an angle value.
Friend Class AngleControl
    Inherits System.Windows.Forms.UserControl

    ' Stores the angle.
    Public _Angle As Single

    ' Stores the rotation offset.
    Private rotation As Integer = 0
    ' Control state tracking variables.
    Private dbx As Integer = -10
    Private dby As Integer = -10
    Private overButton As Integer = -1

    Public Sub New(ByVal initial_angle As Single)
        Me.Angle = initial_angle
        Me.SetStyle(ControlStyles.AllPaintingInWmPaint, True)
        Me.SetStyle(ControlStyles.OptimizedDoubleBuffer, True)
    End Sub

    Public Property Angle() As Single
        Get
            Return _Angle
        End Get
        Set(ByVal value As Single)
            _Angle = value
        End Set
    End Property

    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        ' Set angle origin point at center of control.
        Dim originX As Integer = CInt(Me.Width / 2)
        Dim originY As Integer = CInt(Me.Height / 2)

        ' Fill background and ellipse and center point.
        e.Graphics.FillRectangle(New SolidBrush(Color.DarkBlue), 0, 0, Me.Width, Me.Height)
        e.Graphics.FillEllipse(New SolidBrush(Color.White), 1, 1, Me.Width - 3, Me.Height - 3)
        e.Graphics.FillEllipse(New SolidBrush(Color.SlateGray), originX - 1, originY - 1, 3, 3)

        ' Draw angle markers.
        Dim startangle As Integer = (270 - rotation) Mod 360
        e.Graphics.DrawString(startangle.ToString(), New Font("Arial", 8), New SolidBrush(Color.DarkGray), CSng(Me.Width) / 2 - 10.0!, 10.0!)
        startangle = (startangle + 90) Mod 360
        e.Graphics.DrawString(startangle.ToString(), New Font("Arial", 8), New SolidBrush(Color.DarkGray), CSng(Me.Width) - 18.0!, CSng(Me.Height) / 2.0! - 6.0!)
        startangle = (startangle + 90) Mod 360
        e.Graphics.DrawString(startangle.ToString(), New Font("Arial", 8), New SolidBrush(Color.DarkGray), CSng(Me.Width) / 2.0! - 6.0!, CSng(Me.Height) - 18.0!)
        startangle = (startangle + 90) Mod 360
        e.Graphics.DrawString(startangle.ToString(), New Font("Arial", 8), New SolidBrush(Color.DarkGray), 10.0!, CSng(Me.Height) / 2.0! - 6.0!)

        ' Draw line along the current angle.   
        Dim radians As Double = ((angle + rotation + 360) Mod 360) * Math.PI / System.Convert.ToDouble(180)
        e.Graphics.DrawLine(New Pen(New SolidBrush(Color.Red), 1), originX, originY, originX + System.Convert.ToInt32(System.Convert.ToDouble(originX) * Math.Cos(radians)), originY + System.Convert.ToInt32(System.Convert.ToDouble(originY) * Math.Sin(radians)))

        ' Output angle information.
        e.Graphics.FillRectangle(New SolidBrush(Color.Gray), Me.Width - 84, 3, 82, 13)
        e.Graphics.DrawString("Angle: " + angle.ToString("F4"), New Font("Arial", 8), New SolidBrush(Color.Yellow), Me.Width - 84, 2)
        ' Draw square at mouse position of last angle adjustment.
        e.Graphics.DrawRectangle(New Pen(New SolidBrush(Color.Black), 1), dbx - 2, dby - 2, 4, 4)
        ' Draw rotation adjustment buttons.
        If overButton = 1 Then
            e.Graphics.FillRectangle(New SolidBrush(Color.Green), Me.Width - 28, Me.Height - 14, 12, 12)
            e.Graphics.FillRectangle(New SolidBrush(Color.Gray), 2, Me.Height - 13, 110, 12)
            e.Graphics.DrawString("Rotate 90 degrees left", New Font("Arial", 8), New SolidBrush(Color.White), 2, Me.Height - 14)
        Else
            e.Graphics.FillRectangle(New SolidBrush(Color.DarkGreen), Me.Width - 28, Me.Height - 14, 12, 12)
        End If
        If overButton = 2 Then
            e.Graphics.FillRectangle(New SolidBrush(Color.Green), Me.Width - 14, Me.Height - 14, 12, 12)
            e.Graphics.FillRectangle(New SolidBrush(Color.Gray), 2, Me.Height - 13, 116, 12)
            e.Graphics.DrawString("Rotate 90 degrees right", New Font("Arial", 8), New SolidBrush(Color.White), 2, Me.Height - 14)
        Else
            e.Graphics.FillRectangle(New SolidBrush(Color.DarkGreen), Me.Width - 14, Me.Height - 14, 12, 12)
        End If
        e.Graphics.DrawEllipse(New Pen(New SolidBrush(Color.White), 1), Me.Width - 11, Me.Height - 11, 6, 6)
        e.Graphics.DrawEllipse(New Pen(New SolidBrush(Color.White), 1), Me.Width - 25, Me.Height - 11, 6, 6)
        If overButton = 1 Then
            e.Graphics.FillRectangle(New SolidBrush(Color.Green), Me.Width - 25, Me.Height - 6, 4, 4)
        Else
            e.Graphics.FillRectangle(New SolidBrush(Color.DarkGreen), Me.Width - 25, Me.Height - 6, 4, 4)
        End If
        If overButton = 2 Then
            e.Graphics.FillRectangle(New SolidBrush(Color.Green), Me.Width - 8, Me.Height - 6, 4, 4)
        Else
            e.Graphics.FillRectangle(New SolidBrush(Color.DarkGreen), Me.Width - 8, Me.Height - 6, 4, 4)
        End If
        e.Graphics.FillPolygon(New SolidBrush(Color.White), New Point() {New Point(Me.Width - 7, Me.Height - 8), New Point(Me.Width - 3, Me.Height - 8), New Point(Me.Width - 5, Me.Height - 4)})
        e.Graphics.FillPolygon(New SolidBrush(Color.White), New Point() {New Point(Me.Width - 26, Me.Height - 8), New Point(Me.Width - 21, Me.Height - 8), New Point(Me.Width - 25, Me.Height - 4)})
    End Sub

    Protected Overrides Sub OnMouseDown(ByVal e As System.Windows.Forms.MouseEventArgs)
        ' Handle rotation adjustment button clicks.
        If e.X >= Me.Width - 28 AndAlso e.X <= Me.Width - 2 AndAlso e.Y >= Me.Height - 14 AndAlso e.Y <= Me.Height - 2 Then
            If e.X <= Me.Width - 16 Then
                rotation -= 90
            ElseIf e.X >= Me.Width - 14 Then
                rotation += 90
            End If
            If rotation < 0 Then
                rotation += 360
            End If
            rotation = rotation Mod 360
            dbx = -10
            dby = -10
        Else
            UpdateAngle(e.X, e.Y)
        End If
        Me.Refresh()
    End Sub

    Protected Overrides Sub OnMouseMove(ByVal e As System.Windows.Forms.MouseEventArgs)
        If e.Button = System.Windows.Forms.MouseButtons.Left Then
            UpdateAngle(e.X, e.Y)
            overButton = -1
        ElseIf e.X >= Me.Width - 28 AndAlso e.X <= Me.Width - 16 AndAlso e.Y >= Me.Height - 14 AndAlso e.Y <= Me.Height - 2 Then
            overButton = 1
        ElseIf e.X >= Me.Width - 14 AndAlso e.X <= Me.Width - 2 AndAlso e.Y >= Me.Height - 14 AndAlso e.Y <= Me.Height - 2 Then
            overButton = 2
        Else
            overButton = -1
        End If
        Me.Refresh()
    End Sub

    Private Sub UpdateAngle(ByVal mx As Integer, ByVal my As Integer)
        ' Store mouse coordinates.
        dbx = mx
        dby = my

        ' Translate y coordinate input to GetAngle function to correct for ellipsoid distortion.
        Dim widthToHeightRatio As Double = System.Convert.ToDouble(Me.Width) / System.Convert.ToDouble(Me.Height)
        Dim tmy As Integer
        If my = 0 Then
            tmy = my
        ElseIf my < Me.Height / 2 Then
            tmy = CInt(Me.Height / 2 - Fix((Me.Height / 2 - my) * widthToHeightRatio))
        Else
            tmy = CInt(Me.Height / 2 + Fix(System.Convert.ToDouble(my - Me.Height / 2) * widthToHeightRatio))
        End If
        ' Retrieve updated angle based on rise over run.
        Angle = CSng((GetAngle(CInt(Me.Width / 2), CInt(Me.Height / 2), mx, tmy) - rotation) Mod 360)
    End Sub

    Private Function GetAngle(ByVal x1 As Integer, ByVal y1 As Integer, ByVal x2 As Integer, ByVal y2 As Integer) As Double
        Dim degrees As Double

        ' Avoid divide by zero run values.
        If x2 - x1 = 0 Then
            If y2 > y1 Then
                degrees = 90
            Else
                degrees = 270
            End If
        Else
            ' Calculate angle from offset.
            Dim riseoverrun As Double = System.Convert.ToDouble(y2 - y1) / System.Convert.ToDouble(x2 - x1)
            Dim radians As Double = Math.Atan(riseoverrun)
            degrees = radians * (System.Convert.ToDouble(180) / Math.PI)

            ' Handle quadrant specific transformations.           
            If x2 - x1 < 0 OrElse y2 - y1 < 0 Then
                degrees += 180
            End If
            If x2 - x1 > 0 AndAlso y2 - y1 < 0 Then
                degrees -= 180
            End If
            If degrees < 0 Then
                degrees += 360
            End If
        End If
        Return degrees
    End Function
End Class




