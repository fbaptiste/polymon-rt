Public Class ucLEDGauge
    Private _GaugeThickness As Integer = 30 'px

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Orientation = PolyMonControls.LEDGauge.Orientation.Vertical 'Default to Vertical orientation
    End Sub
    Public Property ScaleMin() As Double
        Get
            Return LedGauge1.ScaleMin
        End Get
        Set(ByVal value As Double)
            LedGauge1.ScaleMin = value
        End Set
    End Property
    Public Property ScaleMax() As Double
        Get
            Return LedGauge1.ScaleMax
        End Get
        Set(ByVal value As Double)
            LedGauge1.ScaleMax = value
        End Set
    End Property
    Public Property GaugeValue() As Double
        Get
            Return LedGauge1.Value
        End Get
        Set(ByVal value As Double)
            LedGauge1.Value = value
        End Set
    End Property
    Public Property OnColor0() As Color
        Get
            Return LedGauge1.LEDOnColor0
        End Get
        Set(ByVal value As Color)
            LedGauge1.LEDOnColor0 = value
        End Set
    End Property
    Public Property OnColor1() As Color
        Get
            Return LedGauge1.LEDOnColor1
        End Get
        Set(ByVal value As Color)
            LedGauge1.LEDOnColor1 = value
        End Set
    End Property
    Public Property OnColor2() As Color
        Get
            Return LedGauge1.LEDOnColor2
        End Get
        Set(ByVal value As Color)
            LedGauge1.LEDOnColor2 = value
        End Set
    End Property
    Public Property Threshold1() As Double
        Get
            Return LedGauge1.Threshold1
        End Get
        Set(ByVal value As Double)
            LedGauge1.Threshold1 = value
        End Set
    End Property
    Public Property Threshold2() As Double
        Get
            Return LedGauge1.Threshold2
        End Get
        Set(ByVal value As Double)
            LedGauge1.Threshold2 = value
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
    Public Property LEDCount() As Integer
        Get
            Return LedGauge1.LEDCount
        End Get
        Set(ByVal value As Integer)
            LedGauge1.LEDCount = value
        End Set
    End Property
    Public Property Orientation() As PolyMonControls.LEDGauge.Orientation
        Get
            Return LedGauge1.LEDOrientation
        End Get
        Set(ByVal value As PolyMonControls.LEDGauge.Orientation)
            LedGauge1.LEDOrientation = value

            If value = PolyMonControls.LEDGauge.Orientation.Horizontal Then
                'Horizontal Gauge
                GradientPanel1.Height = _GaugeThickness
                GradientPanel1.Width = Panel1.ClientSize.Width '- Panel1.Padding.Left - Panel1.Padding.Right

                Dim X As Integer
                Dim Y As Integer

                X = 0 '(Panel1.ClientSize.Width - GradientPanel1.Width) \ 2
                Y = (Panel1.ClientSize.Height - GradientPanel1.Height) '\ 2
                GradientPanel1.Location = New Point(X, Y)

                LedGauge1.Dock = DockStyle.Fill

                GradientPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right Or AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
            Else
                'Vertical Gauge
                'Horizontal Gauge
                GradientPanel1.Height = Panel1.ClientSize.Height '- Panel1.Padding.Top - Panel1.Padding.Bottom
                GradientPanel1.Width = _GaugeThickness

                Dim X As Integer
                Dim Y As Integer

                X = (Panel1.ClientSize.Width - GradientPanel1.Width) \ 2
                Y = 0 'Panel1.ClientSize.Height - GradientPanel1.Height) \ 2
                GradientPanel1.Location = New Point(X, Y)

                LedGauge1.Dock = DockStyle.Fill

                GradientPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
            End If

        End Set
    End Property

End Class
