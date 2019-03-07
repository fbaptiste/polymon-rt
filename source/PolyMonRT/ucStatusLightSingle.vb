Public Class ucStatusLightSingle

    Public Property GaugeValue() As Double
        Get
            Return StatusLight1.Value
        End Get
        Set(ByVal value As Double)
            StatusLight1.Value = value
        End Set
    End Property
    Public Property OnColor0() As Color
        Get
            Return StatusLight1.OnColor0
        End Get
        Set(ByVal value As Color)
            StatusLight1.OnColor0 = value
        End Set
    End Property
    Public Property OnColor1() As Color
        Get
            Return StatusLight1.OnColor1
        End Get
        Set(ByVal value As Color)
            StatusLight1.OnColor1 = value
        End Set
    End Property
    Public Property OnColor2() As Color
        Get
            Return StatusLight1.OnColor2
        End Get
        Set(ByVal value As Color)
            StatusLight1.OnColor2 = value
        End Set
    End Property
    Public Property Threshold1() As Double
        Get
            Return StatusLight1.Threshold1
        End Get
        Set(ByVal value As Double)
            StatusLight1.Threshold1 = value
        End Set
    End Property
    Public Property Threshold2() As Double
        Get
            Return StatusLight1.Threshold2
        End Get
        Set(ByVal value As Double)
            StatusLight1.Threshold2 = value
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

End Class
