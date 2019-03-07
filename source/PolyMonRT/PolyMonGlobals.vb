Class PolyMonGlobals
    'Public Static MonitorTypes As List(Of PolyMonClasses.MonitorType)

    Private Shared _MonitorTypes As List(Of PolyMonClasses.MonitorType) = Nothing

    Public Shared ReadOnly Property MonitorTypes() As List(Of PolyMonClasses.MonitorType)
        Get
            If _MonitorTypes Is Nothing Then
                _MonitorTypes = New List(Of PolyMonClasses.MonitorType)
                For Each MT As PolyMonTypes.MonitorTypes In [Enum].GetValues(GetType(PolyMonTypes.MonitorTypes))
                    _MonitorTypes.Add(New PolyMonClasses.MonitorType(MT))
                Next
            End If
            Return _MonitorTypes
        End Get
    End Property

End Class

Module PolyMonConstants
    Public Const ERRVALUE As Integer = -1
End Module