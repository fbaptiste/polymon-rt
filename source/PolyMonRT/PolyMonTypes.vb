Public Class PolyMonTypes
    'MONITORHOOK: Handle new Monitor types here
    Public Enum MonitorTypes As Integer
        PerfMon = 1
        SQLMonitor = 2
        Ping = 3
        PowerShell = 4
    End Enum

    Public Enum RunStates As Integer
        Running = 0
        Stopped = 1
    End Enum

    Public Enum DisplayStyles As Integer
        Trace = 1
        Gauge = 2
        LED = 3
        StatusLightSingle = 4
        Cylinder = 5
    End Enum

    Public Enum GaugeOrientations As Integer
        Vertical = 0
        Horizontal = 1
    End Enum
End Class
