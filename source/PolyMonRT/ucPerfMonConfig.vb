Imports System.Xml

Public Class ucPerfMonConfig
    Implements PolyMonInterfaces.IMonitorDef


    Private _IsDirty As Boolean = False

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        _IsDirty = False
    End Sub
    Public Sub New(ByVal XMLParams As System.Xml.XmlNode)
        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Deserialize(XMLParams)
        _IsDirty = False
    End Sub
    Public ReadOnly Property IsDirty() As Boolean Implements PolyMonInterfaces.IMonitorDef.IsDirty
        Get
            Return _IsDirty
        End Get
    End Property
    Public Sub Deserialize(ByVal XMLParams As XmlNode) Implements PolyMonInterfaces.IMonitorDef.Deserialize
        Dim nodXML As XmlNode = Nothing

        Dim Host As String = Nothing
        Dim Category As String = Nothing
        Dim Counter As String = Nothing
        Dim Instance As String = Nothing

        'Host
        nodXML = XMLParams.SelectSingleNode("Host")
        Host = nodXML.InnerText


        'Category
        nodXML = XMLParams.SelectSingleNode("Category")
        Category = nodXML.InnerText

        'Counter
        nodXML = XMLParams.SelectSingleNode("Counter")
        Counter = nodXML.InnerText

        'Instance
        nodXML = XMLParams.SelectSingleNode("Instance")
        Instance = nodXML.InnerText

        'Display values on interface
        Try
            txtHost.Text = Host
            If Not (String.IsNullOrEmpty(Host)) Then
                RefreshCategories(Host)
                If Not (String.IsNullOrEmpty(Category)) Then
                    cboCategory.Text = Category
                    RefreshCounterLists(Host, Category)
                    If Not (String.IsNullOrEmpty(Counter)) Then
                        cboCounter.Text = Counter
                        If cboInstance.Enabled AndAlso Not (String.IsNullOrEmpty(Instance)) Then
                            cboInstance.Text = Instance
                        End If
                    End If 'Non-Empty Counter
                End If 'Non-Empty Category
            End If 'Non-Empty Host

        Catch ex As Exception
            MsgBox("The specified performance Host, Counter and/or Instance are invalid." & vbCrLf & ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Error loading PerfMon Definition")
        End Try

        'Reset IsDirty flag
        _IsDirty = False
    End Sub
    Public Function Serialize() As String Implements PolyMonInterfaces.IMonitorDef.Serialize
        Dim xmlSettings As New XmlWriterSettings
        xmlSettings.Indent = True
        xmlSettings.OmitXmlDeclaration = True
        xmlSettings.NewLineOnAttributes = False
        xmlSettings.IndentChars = ControlChars.Tab

        Dim xw As XmlWriter = Nothing
        Dim sbXML As New System.Text.StringBuilder
        xw = XmlWriter.Create(sbXML, xmlSettings)

        With xw
            .WriteStartElement("MonitorSettings")
            .WriteElementString("Host", txtHost.Text)
            .WriteElementString("Category", cboCategory.Text)
            .WriteElementString("Counter", cboCounter.Text)
            .WriteElementString("Instance", cboInstance.Text)
            .WriteEndElement()
            .Close()
        End With

        Return sbXML.ToString
    End Function

    Private Sub txtHost_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtHost.TextChanged
        _IsDirty = True
    End Sub

    Private Sub cboCategory_DropDown(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCategory.DropDown
        Static PrevHost As String = Nothing

        Try
            Cursor.Current = Cursors.WaitCursor

            Dim CurrHost As String = txtHost.Text
            Dim Refresh As Boolean = True
            Dim ClearItems As Boolean = True

            If String.IsNullOrEmpty(CurrHost) Then
                'No current host was supplied - just clear items
                ClearItems = True
                Refresh = False
            ElseIf String.IsNullOrEmpty(PrevHost) Then
                'Current host supplied but not same as before
                ClearItems = True
                Refresh = True
            ElseIf String.Compare(PrevHost.Trim(), CurrHost.Trim(), True) <> 0 Then
                'Not same host as before
                ClearItems = True
                Refresh = True
            Else
                'Same host as before
                ClearItems = False
                Refresh = False
            End If

            If ClearItems Then cboCategory.Items.Clear()
            If Refresh Then
                'Bring back categories for the specified host
                RefreshCategories(CurrHost)
            End If
            PrevHost = CurrHost
            cboCounter.Items.Clear()
            cboInstance.Items.Clear()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, "Error loading PerfMon Categories")
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub
    Private Sub cboCounter_DropDown(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCounter.DropDown
        Dim Host As String = txtHost.Text
        Dim Category As String = cboCategory.Text

        Try
            Cursor.Current = Cursors.WaitCursor
            If String.IsNullOrEmpty(Host) OrElse String.IsNullOrEmpty(Category) Then
                cboCounter.Items.Clear()
                cboInstance.Items.Clear()
            Else
                RefreshCounterLists(Host, Category)
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, "Error loading PerfMon Counters")
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub RefreshCategories(ByVal Host As String)
        Try
            cboCategory.Items.Clear()

            Dim PerfCat As PerformanceCounterCategory

            If String.IsNullOrEmpty(Host) OrElse Host.ToUpper.Contains("LOCALHOST") Then
                For Each PerfCat In System.Diagnostics.PerformanceCounterCategory.GetCategories()
                    cboCategory.Items.Add(PerfCat.CategoryName)
                Next
            Else
                For Each PerfCat In System.Diagnostics.PerformanceCounterCategory.GetCategories(Host)
                    cboCategory.Items.Add(PerfCat.CategoryName)
                Next
            End If
        Catch ex As Exception
            MsgBox("Cannot refresh Category list: " & vbCrLf & ex.Message, MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, "PolyMon")
        End Try
    End Sub
    Private Sub RefreshCounterLists(ByVal Host As String, ByVal Category As String)
        Dim PerfCat = New PerformanceCounterCategory(Category, Host)
        cboCounter.Items.Clear()
        cboInstance.Items.Clear()

        If PerfCat.CategoryType = PerformanceCounterCategoryType.SingleInstance Then
            cboInstance.Enabled = False

            Dim PerfCounter As PerformanceCounter
            For Each PerfCounter In PerfCat.GetCounters()
                cboCounter.Items.Add(PerfCounter.CounterName)
            Next
        Else
            cboInstance.Enabled = True

            Dim PerfInstance As String = ""
            For Each PerfInstance In PerfCat.GetInstanceNames()
                cboInstance.Items.Add(PerfInstance)
            Next

            Dim PerfCounter As PerformanceCounter
            For Each PerfCounter In PerfCat.GetCounters(PerfInstance)
                cboCounter.Items.Add(PerfCounter.CounterName)
            Next
        End If

    End Sub

    Private Sub cboCategory_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCategory.SelectedIndexChanged
        _IsDirty = True

        'Display Help for Category
        Try
            Dim PC As PerformanceCounterCategory
            PC = New PerformanceCounterCategory(cboCategory.Text, txtHost.Text)
            txtHelp.Text = PC.CategoryHelp
        Catch ex As Exception
            txtHelp.Text = Nothing
        End Try


    End Sub
    Private Sub cboCounter_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCounter.SelectedIndexChanged
        _IsDirty = True

        'Display Help for Counter
        Try
            Dim Cat As PerformanceCounterCategory = Nothing
            Dim Counter As PerformanceCounter = Nothing
            Cat = New PerformanceCounterCategory(cboCategory.Text, txtHost.Text)
            Select Case Cat.CategoryType
                Case PerformanceCounterCategoryType.SingleInstance
                    Counter = New PerformanceCounter(cboCategory.Text, cboCounter.Text, Nothing, txtHost.Text)
                    txtHelp.Text = Counter.CounterHelp
                Case PerformanceCounterCategoryType.MultiInstance
                    'Get an instance for this counter
                    Dim Instance As String = Cat.GetInstanceNames(0)
                    Counter = New PerformanceCounter(cboCategory.Text, cboCounter.Text, Instance, txtHost.Text)
                    txtHelp.Text = Counter.CounterHelp
                Case Else
                    txtHelp.Text = Nothing
            End Select
           
        Catch ex As Exception
            txtHelp.Text = Nothing
        End Try
    End Sub
    Private Sub cboInstance_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboInstance.SelectedIndexChanged
        _IsDirty = True
    End Sub

    Private Sub txtHelp_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs)
        'To work around bug where text disappears from text box when mouse enters/leaves
        txtHelp.Invalidate()
    End Sub

    Private Sub txtHelp_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs)
        'To work around bug where text disappears from text box when mouse enters/leaves
        txtHelp.Invalidate()
    End Sub


End Class
