Public Class ucCylinderGauge
    Private _Value As Double = 0
    Private _Min As Double = 0
    Private _Max As Double = 100
    Private _OnColor0 As Color = Color.DodgerBlue
    Private _OnColor1 As Color = Color.Orange
    Private _OnColor2 As Color = Color.Red
    Private _Threshold1 As Double
    Private _Threshold2 As Double

    Public Property GaugeValue() As Double
        Get
            Return _Value
        End Get
        Set(ByVal value As Double)
            _Value = value
            RefreshGauge()
        End Set
    End Property

    Private Sub RefreshGauge()
        Dim FillPerc As Double

        If _Value >= _Max Then
            FillPerc = 100
        ElseIf _Value <= _Min Then
            FillPerc = 0
        Else
            If _Min >= _Max Then
                FillPerc = 0
            Else
                FillPerc = 100 * _Value / (_Max - _Min)
            End If
        End If
        CylinderGauge1.FillPercentage = CInt(FillPerc)
        If _Value <= Threshold1 Then
            CylinderGauge1.FillColor = OnColor0
        ElseIf _Value > _Threshold2 Then
            CylinderGauge1.FillColor = OnColor2
        Else
            CylinderGauge1.FillColor = OnColor1
        End If
    End Sub

    Public Property Min() As Double
        Get
            Return _Min
        End Get
        Set(ByVal value As Double)
            _Min = value
            RefreshGauge()
        End Set
    End Property
    Public Property Max() As Double
        Get
            Return _Max
        End Get
        Set(ByVal value As Double)
            _Max = value
            RefreshGauge()
        End Set
    End Property
    Public Property OnColor0() As Color
        Get
            Return _OnColor0
        End Get
        Set(ByVal value As Color)
            _OnColor0 = value
            RefreshGauge()
        End Set
    End Property
    Public Property OnColor1() As Color
        Get
            Return _OnColor1
        End Get
        Set(ByVal value As Color)
            _OnColor1 = value
            RefreshGauge()
        End Set
    End Property
    Public Property OnColor2() As Color
        Get
            Return _OnColor2
        End Get
        Set(ByVal value As Color)
            _OnColor2 = value
            RefreshGauge()
        End Set
    End Property
    Public Property Threshold1() As Double
        Get
            Return _Threshold1
        End Get
        Set(ByVal value As Double)
            _Threshold1 = value
            RefreshGauge()
        End Set
    End Property
    Public Property Threshold2() As Double
        Get
            Return _Threshold2
        End Get
        Set(ByVal value As Double)
            _Threshold2 = value
            RefreshGauge()
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
