Namespace PolyMonInterfaces
    Public Interface IMonitorDef
        Sub Deserialize(ByVal XMLParams As System.Xml.XmlNode)
        Function Serialize() As String
        ReadOnly Property IsDirty() As Boolean
    End Interface

    Public Interface IMonitorSampler
        Function GetSample() As Double
        Property XMLParams() As System.Xml.XmlNode
    End Interface
End Namespace


