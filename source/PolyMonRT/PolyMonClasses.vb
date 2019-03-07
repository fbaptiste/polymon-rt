Namespace PolyMonClasses
    Public Class MonitorType
        Private _MonitorType As PolyMonTypes.MonitorTypes
        Private _MonitorTypeName As String

        Public Sub New(ByVal MonitorType As PolyMonTypes.MonitorTypes)
            _MonitorType = MonitorType

            _MonitorTypeName = MonitorType.ToString()
        End Sub
        Public ReadOnly Property MonitorType() As PolyMonTypes.MonitorTypes
            Get
                Return _MonitorType
            End Get
        End Property
        Public ReadOnly Property MonitorTypeName() As String
            Get
                Return _MonitorTypeName
            End Get
        End Property
    End Class
End Namespace
