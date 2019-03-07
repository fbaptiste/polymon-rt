Imports System.IO
Imports System.Xml

Public Class frmMonitorDashboard

#Region "Private Attributes"
    Private _IsNew As Boolean = False
    Private _IsDirty As Boolean = False
    Private _SaveFile As FileInfo = Nothing

    Private _IsDragging As Boolean = False
    Private _DragOffset As System.Drawing.Point = Nothing
    Private _DragShadow As Panel = Nothing
    Private _DragMC As ucMonitorChart = Nothing
    Private _HasMoved As Boolean = False

    Private _IsResizing As Boolean = False
    Private _ResizeMC As ucMonitorChart = Nothing
    Private _ResizeOffset As System.Drawing.Point = Nothing

    Private _IsPaused As Boolean = False

    Private pnlMain As New ScrollPanel()

    Private _NewID As Integer = 0
#End Region

#Region "Class Creation"
    Public Sub New()
        'Create a new monitor

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        InitForm()
        _SaveFile = Nothing
        IsDirty = False
        _IsNew = True

        Me.Text = "Monitor Dashboard (New)"
    End Sub
    Public Sub New(ByVal SaveFile As FileInfo)
        'Load an existing monitor definition from file

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        InitForm()
        Try
            LoadFile(SaveFile)
            _SaveFile = SaveFile
            _IsNew = False
            IsDirty = False
            Me.Text = String.Format("Monitor Dashboard ({0})", SaveFile.Name.Replace(SaveFile.Extension, Nothing))
        Catch ex As Exception
            'Load failed.
            MsgBox(ex.Message)
            _SaveFile = Nothing
            _IsNew = True
            IsDirty = False
            Me.Text = "Monitor Dashboard (New)"
        End Try
        
    End Sub
    Private Sub InitForm()
        pnlHost.Controls.Add(pnlMain)
        pnlMain.AutoScroll = True
        pnlMain.AutoSize = False
        pnlMain.BorderStyle = BorderStyle.None
        pnlMain.Dock = DockStyle.Fill
        pnlMain.AllowDrop = True
        pnlMain.AutoScrollMargin = New System.Drawing.Size(20, 20)
        AddHandler pnlMain.DragEnter, AddressOf pnlMain_DragEnter
        AddHandler pnlMain.DragDrop, AddressOf pnlMain_DragDrop
        AddHandler pnlMain.DragOver, AddressOf pnlMain_DragOver
        AddHandler pnlMain.DragLeave, AddressOf pnlMain_DragLeave
        AddHandler pnlMain.MouseUp, AddressOf pnlMain_MouseUp
        AddHandler pnlMain.MouseMove, AddressOf pnlMain_MouseMove
    End Sub
#End Region

#Region "Public Interface"
    Public Property IsDirty() As Boolean
        Get
            Return _IsDirty
        End Get
        Set(ByVal value As Boolean)
            _IsDirty = value
            If value Then
                slDirtyStatus.Text = "Save!"
                slDirtyStatus.Visible = True
            Else
                slDirtyStatus.Text = Nothing
                slDirtyStatus.Visible = False
            End If

        End Set
    End Property
    Public ReadOnly Property SaveFileInfo() As FileInfo
        Get
            Return _SaveFile
        End Get
    End Property
    Public Sub SaveSettings()
        If _IsNew Then
            'Prompt user for file location
            'Save File
            'Set _SaveFile
            IsDirty = False
        Else
            'Not a new file
            If _IsDirty Then
                'Save file if settings have changed that need to be persisted
                IsDirty = False
            Else
                'Do not save - no settings have changed that need to be changed
            End If
        End If

    End Sub
#End Region

#Region "Form Events"
    Private Sub miNewMonitor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbNewMonitor.Click
        'Add a monitor panel
        Me.Cursor = Cursors.WaitCursor
        AddNewMonitorChart()
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub tbPauseResume_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbPauseResume.Click
        Me.Cursor = Cursors.WaitCursor
        SetPauseState(Not _IsPaused)
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub SaveDashboard(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbSave.Click, tbSaveMain.ButtonClick
        If _IsNew Then
            Dim StartLocation As String = My.Settings.LastFileSaveLocation
            If String.IsNullOrEmpty(StartLocation) Then
                StartLocation = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
            End If
            With SaveFileDialog1
                .DefaultExt = ".pxml"
                .Filter = "PolyMon Dashboards|*.pxml"
                .InitialDirectory = StartLocation
                .AddExtension = True
                .CreatePrompt = False
                .SupportMultiDottedExtensions = True
            End With

            Dim strFile As String = Nothing
            Dim fiFile As FileInfo
            Dim res As DialogResult = Me.SaveFileDialog1.ShowDialog()
            If res = Windows.Forms.DialogResult.OK Then
                Cursor.Current = Cursors.WaitCursor

                strFile = SaveFileDialog1.FileName
                fiFile = New FileInfo(strFile)
                My.Settings.LastFileSaveLocation = fiFile.Directory.ToString()
                My.Settings.Save()
                SaveFileDialog1.FileName = Nothing
                Try
                    'Serialize dashboard data
                    Dim xml As String = Serialize()

                    'Save file
                    Dim sw As New StreamWriter(strFile, False)
                    sw.Write(xml)
                    sw.Close()

                    Me.Text = fiFile.Name.Replace(fiFile.Extension, Nothing)
                    _IsNew = False
                    IsDirty = False
                    _SaveFile = fiFile
                Catch ex As Exception
                    MsgBox(ex.ToString())
                Finally
                    Cursor.Current = Cursors.Default
                End Try
            End If
        Else
            'Overwrite existing file
            Try
                Cursor.Current = Cursors.WaitCursor
                'Serialize dashboard data
                Dim xml As String = Serialize()

                'Save file
                Dim sw As New StreamWriter(_SaveFile.FullName, False)
                sw.Write(xml)
                sw.Close()

                _IsNew = False
                IsDirty = False
            Catch ex As Exception
                MsgBox(ex.ToString())
            Finally
                Cursor.Current = Cursors.Default
            End Try
        End If

    End Sub
    Private Sub tbSaveAs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbSaveAs.Click
        Dim StartLocation As String = My.Settings.LastFileSaveLocation
        If String.IsNullOrEmpty(StartLocation) Then
            StartLocation = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        End If
        With SaveFileDialog1
            .DefaultExt = ".pxml"
            .Filter = "PolyMon Dashboards|*.pxml"
            .InitialDirectory = StartLocation
            .AddExtension = True
            .CreatePrompt = False
            .SupportMultiDottedExtensions = True
        End With

        Dim strFile As String = Nothing
        Dim fiFile As FileInfo
        Dim res As DialogResult = Me.SaveFileDialog1.ShowDialog()
        If res = Windows.Forms.DialogResult.OK Then
            strFile = SaveFileDialog1.FileName
            fiFile = New FileInfo(strFile)
            My.Settings.LastFileSaveLocation = fiFile.Directory.ToString()
            SaveFileDialog1.FileName = Nothing
            Try
                Me.Cursor = Cursors.WaitCursor

                'Serialize dashboard data
                Dim xml As String = Serialize()

                'Save file
                Dim sw As New StreamWriter(strFile, False)
                sw.Write(xml)
                sw.Close()

                Me.Text = fiFile.Name.Replace(fiFile.Extension, Nothing)
                _IsNew = False
                IsDirty = False
                _SaveFile = fiFile
            Catch ex As Exception
                MsgBox(ex.ToString())
            Finally
                Me.Cursor = Cursors.Default
            End Try
        End If
    End Sub
    Private Sub tbInfo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbInfo.Click
        Dim dlgInfo As New dlgDashboardStatus
        With dlgInfo
            If _IsNew OrElse _SaveFile Is Nothing Then
                .DashboardName = "(New)"
                .SaveFile = "(Not Saved)"
            Else
                .DashboardName = _SaveFile.Name.Replace(_SaveFile.Extension, Nothing)
                .SaveFile = _SaveFile.FullName
            End If
            .IsPaused = _IsPaused
            .UnsavedChanges = _IsDirty
            .TotalMonitors = Format(pnlMain.Controls.Count, "###,##0")
            Dim Running As Integer = 0
            Dim Stopped As Integer = 0
            For Each MC As ucMonitorChart In pnlMain.Controls
                If MC.RunState = PolyMonTypes.RunStates.Running Then Running += 1 Else Stopped += 1
            Next
            If _IsPaused Then
                .RunningMonitors = Format(Running, "###,##0") & " (Paused)"
            Else
                .RunningMonitors = Format(Running, "###,##0")
            End If
            .StoppedMonitors = Format(Stopped, "###,##0")

            .ShowDialog()
        End With
    End Sub
    Private Sub frmMonitorDashboard_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If IsDirty Then
            Dim prompt As String = Nothing
            If SaveFileInfo Is Nothing Then
                prompt = String.Format("The dashboard (Untitled) has unsaved changes.{0}Are you sure you want to close it without saving?", vbCrLf)
            Else
                prompt = String.Format("The dashboard {0} has unsaved changes. {1}Are you sure you want to close it without saving?", SaveFileInfo.Name.Replace(SaveFileInfo.Extension, Nothing), vbCrLf)
            End If

            Dim res As MsgBoxResult = MsgBox(prompt, MsgBoxStyle.Question Or MsgBoxStyle.YesNo, "Closing Unsaved Dashboard...")
            If res <> MsgBoxResult.Yes Then
                e.Cancel = True
            End If
        End If
    End Sub
#End Region

#Region "Move & Resize Methods/Handlers"
    Private Sub MoveMonitorStart(ByVal sender As ucMonitorChart, ByVal e As System.Windows.Forms.MouseEventArgs)
        _IsDragging = True
        _DragMC = sender
        _DragMC.BringToFront()
        _DragOffset = New System.Drawing.Point(e.X, e.Y)
        _DragShadow = New Panel
        pnlMain.Controls.Add(_DragShadow)
        _DragShadow.BorderStyle = BorderStyle.None
        _DragShadow.BackColor = pnlMain.BackColor
        _DragShadow.Size = sender.Size
        _DragShadow.Location = sender.Location
        _DragShadow.DoDragDrop(_DragMC, DragDropEffects.Move)
    End Sub
    Private Sub MoveMonitorEnd(ByVal sender As ucMonitorChart, ByVal e As System.Windows.Forms.MouseEventArgs)
        pnlMain.Controls.Remove(_DragShadow)
        _IsDragging = False
        _DragMC = Nothing
        _DragShadow = Nothing
    End Sub

    Private Sub pnlMain_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs)
        If _DragMC IsNot Nothing Then
            e.Effect = DragDropEffects.Move
            _IsDragging = True
            _HasMoved = False
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub
    Private Sub pnlMain_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs)
        pnlMain.Controls.Remove(_DragShadow)
        _IsDragging = False
        _DragMC = Nothing
        _DragShadow = Nothing
        If _HasMoved Then IsDirty = True
        _HasMoved = False
    End Sub
    Private Sub pnlMain_DragOver(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs)
        If _DragMC IsNot Nothing Then
            Dim newX As Integer = e.X - _DragOffset.X
            Dim newY As Integer = e.Y - _DragOffset.Y


            'Make sure control is not dragged off-screen top and left
            Dim newClientLocation As System.Drawing.Point = pnlMain.PointToClient(New System.Drawing.Point(newX, newY))
            If newClientLocation.X < 0 Then newClientLocation.X = 0
            If newClientLocation.Y < 0 Then newClientLocation.Y = 0

            'Next snap to close by control X/Y coordinates if within threshold or to grid otherwise (if option enabled)
            Dim CtlTX As Integer = My.Settings.MonitorDashboard_ProximitySnapThresholdX
            Dim CtlTY As Integer = My.Settings.MonitorDashboard_ProximitySnapThresholdY
            Dim GridTX As Integer = My.Settings.MonitorDashboard_GridSnapThresholdX
            Dim GridTY As Integer = My.Settings.MonitorDashboard_GridSnapThresholdY
            Dim oldClientLocation = newClientLocation

            If My.Settings.MonitorDashboard_ProximitySnap Then
                newClientLocation = FindClosestMCPt_TopLeft(pnlMain, _DragMC, newClientLocation, CtlTX, CtlTY)
            End If

            If My.Settings.MonitorDashboard_GridSnap Then
                If oldClientLocation.X = newClientLocation.X Then
                    'Did not "snap" to a nearby control on X axis
                    'Snap to grid instead on X axis
                    newClientLocation.X = RoundToSignificance(newClientLocation.X, GridTX)
                End If
                If oldClientLocation.Y = newClientLocation.Y Then
                    'Did not "snap" to a nearby control on Y axis
                    'Snap to grid instead on Y axis
                    newClientLocation.Y = RoundToSignificance(newClientLocation.Y, GridTY)
                End If
            End If
            _DragMC.Location = newClientLocation
            _HasMoved = True
        End If
    End Sub
    Private Sub pnlMain_DragLeave(ByVal sender As Object, ByVal e As System.EventArgs)
        'Cancel Drag operation
        If _DragMC IsNot Nothing Then
            _DragMC.Location = _DragShadow.Location 'Reset to original location
            pnlMain.Controls.Remove(_DragShadow)
            _DragMC = Nothing
            _DragShadow = Nothing
            _IsDragging = False
            _HasMoved = False
        End If
    End Sub
    Private Sub pnlMain_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        If _IsResizing Then
            'User has completed resize operation
            Me.Cursor = Cursors.Default
            _ResizeMC.ResumeLayout()
            '_ResizeMC.ResizeGauge()
            _ResizeMC.BorderStyle = BorderStyle.None
            _IsResizing = False
            _ResizeMC = Nothing
            _ResizeOffset = Nothing
            IsDirty = True
        End If
        pnlMain.Capture = False
    End Sub
    Private Sub pnlMain_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        If _IsResizing Then
            'Find location of Top,Left of control (Panel coordinates)
            Dim Origin As System.Drawing.Point = _ResizeMC.Location

            'Find location of cursor
            Dim CurLoc As System.Drawing.Point = e.Location

            'Find real bot right position (using offset)
            Dim botrightPt As New System.Drawing.Point(CurLoc.X + _ResizeOffset.X, CurLoc.Y + _ResizeOffset.Y)

            'Proximity/Grid snapping
            Dim CtlTX As Integer = My.Settings.MonitorDashboard_ProximitySnapThresholdX
            Dim CtlTY As Integer = My.Settings.MonitorDashboard_ProximitySnapThresholdY
            Dim GridTX As Integer = My.Settings.MonitorDashboard_GridSnapThresholdX
            Dim GridTY As Integer = My.Settings.MonitorDashboard_GridSnapThresholdY

            Dim newPt As System.Drawing.Point = botrightPt

            If My.Settings.MonitorDashboard_ProximitySnap Then
                newPt = FindClosestMCPt_BottomRight(pnlMain, _ResizeMC, botrightPt, CtlTX, CtlTY)
            End If

            If My.Settings.MonitorDashboard_GridSnap Then
                If botrightPt.X = newPt.X Then
                    'Did not "snap" to a nearby control on X axis
                    'Snap to grid instead on X axis
                    newPt.X = RoundToSignificance(botrightPt.X, GridTX)
                End If
                If botrightPt.Y = newPt.Y Then
                    'Did not "snap" to a nearby control on Y axis
                    'Snap to grid instead on Y axis
                    newPt.Y = RoundToSignificance(botrightPt.Y, GridTY)
                End If
            End If


            Dim NewWidth As Integer = Math.Abs(newPt.X - Origin.X)
            Dim NewHeight As Integer = Math.Abs(newPt.Y - Origin.Y)

            'Resize control
            _ResizeMC.Size = New System.Drawing.Size(NewWidth, NewHeight)
            _ResizeMC.BorderStyle = BorderStyle.FixedSingle
            IsDirty = True
        End If
    End Sub

    Private Sub ResizeZoneEnter(ByVal sender As ucMonitorChart)
        Me.Cursor = Cursors.SizeNWSE
    End Sub
    Private Sub ResizeZoneLeave(ByVal sender As ucMonitorChart)
        If Not (_IsResizing) Then Me.Cursor = Cursors.Default
    End Sub
    Private Sub ResizeZoneMouseDown(ByVal sender As ucMonitorChart, ByVal Offset As System.Drawing.Point)
        If sender.IsInResizeZone Then
            'User is resizing control
            Me.Cursor = Cursors.SizeNWSE
            pnlMain.Capture = True
            _ResizeMC = sender
            _ResizeMC.SuspendLayout()
            _ResizeOffset = Offset
            _IsResizing = True
        End If
    End Sub

    Private Sub DeleteMonitor(ByVal MC As ucMonitorChart)
        'Remove monitor
        MC.TimerSample.Stop()
        pnlMain.Controls.Remove(MC)
        MC = Nothing

        IsDirty = True
    End Sub
    Private Sub MonitorIsDirty(ByVal MC As ucMonitorChart)
        IsDirty = True
    End Sub
#End Region

#Region "Private Methods"
    Private Sub SetPauseState(ByVal IsPaused As Boolean)
        _IsPaused = IsPaused
        If IsPaused Then
            tbPauseResume.Image = My.Resources.Play
            slStatus.Text = "Paused"
        Else
            tbPauseResume.Image = My.Resources.Pause
            slStatus.Text = "Ready"
        End If
        For Each ctl As Control In pnlMain.Controls
            If TypeOf (ctl) Is ucMonitorChart Then
                CType(ctl, ucMonitorChart).IsPaused = IsPaused
            End If
        Next

        IsDirty = True
    End Sub

    Private Sub LoadFile(ByVal SaveFile As FileInfo)
        pnlMain.SuspendLayout()
        Dim xmlDoc As New XmlDocument
        Try
            For Each MC As ucMonitorChart In pnlMain.Controls
                DeleteMonitor(MC)
            Next
            xmlDoc.Load(SaveFile.FullName)

            Dim nodRoot As XmlNode = xmlDoc.DocumentElement
            Dim nodXML As XmlNode = Nothing

            Dim isPaused As Boolean = False
            nodXML = nodRoot.SelectSingleNode("IsPaused")
            If nodXML IsNot Nothing Then
                isPaused = CBool(nodXML.InnerText)
            End If
            SetPauseState(isPaused)

            'Now load each monitor
            For Each nodMonitor As XmlNode In nodRoot.SelectNodes("Monitor")
                _NewID = CInt(nodMonitor.Attributes("ID").Value)
                AddNewMonitorChart(nodMonitor)
            Next
            CorrectChartPositions()
            pnlMain.ResumeLayout()
            pnlMain.Refresh()
            _SaveFile = SaveFile
            IsDirty = False
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            xmlDoc = Nothing
        End Try
    End Sub

    Private Function AddNewMonitorChart() As ucMonitorChart
        _NewID += 1
        Dim MC As New ucMonitorChart(_NewID, _IsPaused)
        AddHandler MC.MoveMonitorStart, AddressOf MoveMonitorStart
        AddHandler MC.MoveMonitorEnd, AddressOf MoveMonitorEnd
        AddHandler MC.ResizeZoneEnter, AddressOf ResizeZoneEnter
        AddHandler MC.ResizeZoneLeave, AddressOf ResizeZoneLeave
        AddHandler MC.ResizeZoneMouseDown, AddressOf ResizeZoneMouseDown
        AddHandler MC.DeleteMonitor, AddressOf DeleteMonitor
        AddHandler MC.IsDirty, AddressOf MonitorIsDirty
        AddHandler MC.Cloning, AddressOf Cloning

        DefaultPositionControlInContainer(CType(MC, Control), pnlMain)

        pnlMain.Controls.Add(MC)
        'Move new control to front
        MC.BringToFront()
        MC.AutoSize = False

        IsDirty = True

        Return MC
    End Function
    Private Function AddNewMonitorChart(ByVal xmlDef As XmlNode) As ucMonitorChart
        Dim MC As New ucMonitorChart(xmlDef, _IsPaused)

        AddHandler MC.MoveMonitorStart, AddressOf MoveMonitorStart
        AddHandler MC.MoveMonitorEnd, AddressOf MoveMonitorEnd
        AddHandler MC.ResizeZoneEnter, AddressOf ResizeZoneEnter
        AddHandler MC.ResizeZoneLeave, AddressOf ResizeZoneLeave
        AddHandler MC.ResizeZoneMouseDown, AddressOf ResizeZoneMouseDown
        AddHandler MC.DeleteMonitor, AddressOf DeleteMonitor
        AddHandler MC.IsDirty, AddressOf MonitorIsDirty
        AddHandler MC.Cloning, AddressOf Cloning

        pnlMain.Controls.Add(MC)
        'Move new control to front
        MC.BringToFront()
        MC.AutoSize = False

        Return MC
    End Function

    Private Sub Cloning(ByVal MC As ucMonitorChart, ByVal strXMLDef As String)
        'Need to create a new monitor, but change it's name first 
        'and move it slightly from where it is currently located
        'Also assign a new MonitorID to it.
        Dim xmlDoc As New XmlDocument
        xmlDoc.LoadXml(strXMLDef)
        Dim nodRoot As XmlNode = xmlDoc.DocumentElement
        _NewID += 1

        nodRoot.SelectSingleNode("/Monitor").Attributes("ID").Value = CStr(_NewID)
        nodRoot.SelectSingleNode("/Monitor/MonitorName").InnerXml = "Copy of " & nodRoot.SelectSingleNode("/Monitor/MonitorName").InnerXml
        nodRoot.SelectSingleNode("/Monitor/Location").Attributes("X").Value = CStr(CInt(nodRoot.SelectSingleNode("/Monitor/Location").Attributes("X").Value) + 20)
        nodRoot.SelectSingleNode("/Monitor/Location").Attributes("Y").Value = CStr(CInt(nodRoot.SelectSingleNode("/Monitor/Location").Attributes("Y").Value) + 20)

        'Now clone it
        AddNewMonitorChart(nodRoot)
    End Sub

    Private Function Serialize() As String
        Dim xmlSettings As New XmlWriterSettings
        xmlSettings.Indent = True
        xmlSettings.OmitXmlDeclaration = True
        xmlSettings.NewLineOnAttributes = False
        xmlSettings.IndentChars = ControlChars.Tab

        Dim xw As XmlWriter = Nothing
        Dim sbXML As New System.Text.StringBuilder
        xw = XmlWriter.Create(sbXML, xmlSettings)

        With xw
            .WriteStartElement("Dashboard")

            .WriteElementString("IsPaused", _IsPaused.ToString())

            For Each MC As ucMonitorChart In pnlMain.Controls
                .WriteRaw(vbCrLf & MC.Serialize() & vbCrLf & vbCrLf)
            Next

            .WriteEndElement() 'Dashboard

            .Close()
        End With

        Return sbXML.ToString
    End Function
#End Region

#Region "Helper Methods"
    Private Function FindClosestMCPt_TopLeft(ByRef Pnl As ScrollPanel, ByVal CurrCtl As Control, ByVal CurrPt As System.Drawing.Point, ByVal tX As Integer, ByVal tY As Integer) As System.Drawing.Point
        Dim ClosestDist As Integer = System.Int32.MaxValue
        Dim Dist As Integer = 0

        'Determine if there is another control whose X value is within tX of this one's
        'If so, snap X coordinate to it
        Dim ClosestPtX As Integer = CurrPt.X
        ClosestDist = System.Int32.MaxValue
        For Each ctl As Control In Pnl.Controls
            If Not (ctl Is CurrCtl) Then
                'Use top left corner of MC
                Dim cPt As System.Drawing.Point = ctl.Location

                Dist = Math.Abs(cPt.X - CurrPt.X)
                If Dist < ClosestDist Then
                    'Found something nearer than before.
                    'But is it within tX pixels?
                    If Math.Abs(cPt.X - CurrPt.X) <= tX Then
                        'Yes it is, so use this as current closest X coordinate
                        ClosestPtX = cPt.X
                        ClosestDist = Dist
                    End If
                End If
            End If
        Next

        'Determine if there is another control whose Y value is within tY of this one's
        'If so, snap Y coordinate to it
        Dim ClosestPtY As Integer = CurrPt.Y
        ClosestDist = System.Int32.MaxValue
        For Each ctl As Control In Pnl.Controls
            If Not (ctl Is CurrCtl) Then
                'Use top left corner of MC
                Dim cPt As System.Drawing.Point = ctl.Location

                Dist = Math.Abs(cPt.Y - CurrPt.Y)
                If Dist < ClosestDist Then
                    'Found something nearer than before.
                    'But is it within tY pixels?
                    If Math.Abs(cPt.Y - CurrPt.Y) <= tY Then
                        'Yes it is, so use this as current closest Y coordinate
                        ClosestPtY = cPt.Y
                        ClosestDist = Dist
                    End If
                End If
            End If
        Next

        Return New System.Drawing.Point(ClosestPtX, ClosestPtY)
    End Function
    Private Function FindClosestMCPt_BottomRight(ByRef Pnl As ScrollPanel, ByVal CurrCtl As Control, ByVal CurrPt As System.Drawing.Point, ByVal tX As Integer, ByVal tY As Integer) As System.Drawing.Point
        Dim ClosestDist As Integer = System.Int32.MaxValue
        Dim Dist As Integer = 0

        'Determine if there is another control whose X value is within tX of this one's
        'If so, snap X coordinate to it
        Dim ClosestPtX As Integer = CurrPt.X
        ClosestDist = System.Int32.MaxValue
        For Each ctl As Control In Pnl.Controls
            If Not (ctl Is CurrCtl) Then
                'Use bottom right corner of MC
                Dim cPt As System.Drawing.Point = ctl.Location
                cPt.Offset(ctl.Width, ctl.Height)

                Dist = Math.Abs(cPt.X - CurrPt.X)
                If Dist < ClosestDist Then
                    'Found something nearer than before.
                    'But is it within tX pixels?
                    If Math.Abs(cPt.X - CurrPt.X) <= tX Then
                        'Yes it is, so use this as current closest X coordinate
                        ClosestPtX = cPt.X
                        ClosestDist = Dist
                    End If
                End If
            End If
        Next

        'Determine if there is another control whose Y value is within tY of this one's
        'If so, snap Y coordinate to it
        Dim ClosestPtY As Integer = CurrPt.Y
        ClosestDist = System.Int32.MaxValue
        For Each ctl As Control In Pnl.Controls
            If Not (ctl Is CurrCtl) Then
                'Use bottom right corner of MC
                Dim cPt As System.Drawing.Point = ctl.Location
                cPt.Offset(ctl.Width, ctl.Height)

                Dist = Math.Abs(cPt.Y - CurrPt.Y)
                If Dist < ClosestDist Then
                    'Found something nearer than before.
                    'But is it within tY pixels?
                    If Math.Abs(cPt.Y - CurrPt.Y) <= tY Then
                        'Yes it is, so use this as current closest Y coordinate
                        ClosestPtY = cPt.Y
                        ClosestDist = Dist
                    End If
                End If
            End If
        Next

        Return New System.Drawing.Point(ClosestPtX, ClosestPtY)
    End Function
    Private Function NudgePtInPanel(ByRef Pnl As ScrollPanel, ByVal StartPt As System.Drawing.Point, ByVal tX As Integer, ByVal tY As Integer) As System.Drawing.Point
        'Find a start location for control in specified panel
        For Each ctl As Control In Pnl.Controls
            If ctl.Location.X = StartPt.X AndAlso ctl.Location.Y = StartPt.Y Then
                'Nudge over and down pixels by pixel count determined by current Proximity snap settings and try again
                StartPt.Offset(20, 50)
                StartPt = NudgePtInPanel(Pnl, StartPt, tX, tY)
            End If
        Next
        Return StartPt
    End Function
    Private Sub DefaultPositionControlInContainer(ByRef Ctl As Control, ByRef Pnl As ScrollPanel)
        Dim NewX As Integer = CInt(Pnl.Width / 2 - Ctl.Width / 2)
        Dim NewY As Integer = CInt(Pnl.Height / 2 - Ctl.Height / 2)

        Dim NewLoc As New System.Drawing.Point(NewX, NewY)
        'then nudge it away from any existing controls.
        'Nudge amount needs to take into account the proximity snap settings
        Dim tX As Integer = 20
        Dim tY As Integer = 50

        If tX <= My.Settings.MonitorDashboard_ProximitySnapThresholdX Then tX = My.Settings.MonitorDashboard_ProximitySnapThresholdX + 1
        If tY <= My.Settings.MonitorDashboard_ProximitySnapThresholdY Then tY = My.Settings.MonitorDashboard_ProximitySnapThresholdY + 1
        NewLoc = NudgePtInPanel(Pnl, NewLoc, tX, tY)

        Ctl.Location = NewLoc
    End Sub
    Private Sub CorrectChartPositions()
        Dim MinX As Integer = Integer.MaxValue
        Dim MinY As Integer = Integer.MaxValue

        For Each ctl As ucMonitorChart In pnlMain.Controls
            If ctl.Location.X < MinX Then MinX = ctl.Location.X
            If ctl.Location.Y < MinY Then MinY = ctl.Location.Y
        Next

        If MinX < 0 OrElse MinY < 0 Then
            'Need to shift everything over to the right by that min amount

            For Each ctl As ucMonitorChart In pnlMain.Controls
                Dim NewX As Integer = 0
                Dim NewY As Integer = 0
                If MinX < 0 Then
                    NewX = ctl.Location.X + Math.Abs(MinX) + 10
                Else
                    NewX = ctl.Location.X
                End If
                If MinY < 0 Then
                    NewY = ctl.Location.Y + Math.Abs(MinY) + 10
                Else
                    NewY = ctl.Location.Y
                End If
                ctl.Location = New Point(NewX, NewY)
            Next
        End If
    End Sub
    Public Function RoundToSignificance(ByVal number As Integer, ByVal significance As Integer) As Integer
        'Round number up or down to the nearest multiple of significance    
        Return CInt(Math.Round(CDbl(number / significance), 0) * significance)
    End Function
#End Region

End Class

Public Class ScrollPanel
    Inherits Panel

    Private _Location As System.Drawing.Point

    Public Sub New()
        MyBase.New()

    End Sub

    Protected Overrides Function ScrollToControl(ByVal activeControl As System.Windows.Forms.Control) As System.Drawing.Point
        Return Me.AutoScrollPosition
    End Function

End Class