Imports System.Windows.Forms

Public Class dlgMonitorChartProperties

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        cboMonitorType.Items.Clear()
        cboMonitorType.DisplayMember = "MonitorTypeName"

        cboMonitorType.DataSource = PolyMonGlobals.MonitorTypes

        If cboMonitorType.Items.Count > 0 Then cboMonitorType.SelectedIndex = 0
        nudRetentionPeriod.Maximum = My.Settings.MaxRetentionPts

    End Sub

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Public Property MonitorXMLParams() As String
        Get
            If pnlMonitorDef.Controls.Count = 0 Then
                'Return an empty Monitor Def XML object
                Return "<MonitorSettings/>"
            Else
                Return CType(pnlMonitorDef.Controls(0), PolyMonInterfaces.IMonitorDef).Serialize()
            End If
        End Get
        Set(ByVal value As String)
            If pnlMonitorDef.Controls.Count > 0 Then
                Dim xmlDoc As New System.Xml.XmlDocument
                xmlDoc.LoadXml(value)
                CType(pnlMonitorDef.Controls(0), PolyMonInterfaces.IMonitorDef).Deserialize(xmlDoc.DocumentElement)
            End If
        End Set
    End Property

    Public Property MonitorName() As String
        Get
            Return txtName.Text
        End Get
        Set(ByVal value As String)
            txtName.Text = value
        End Set
    End Property
    Public ReadOnly Property IsMonitorDefDirty() As Boolean
        Get
            Dim isDirty As Boolean = False
            If pnlMonitorDef.Controls.Count > 0 Then
                Dim MDef As PolyMonInterfaces.IMonitorDef
                MDef = CType(pnlMonitorDef.Controls.Item(0), PolyMonInterfaces.IMonitorDef)
                isDirty = MDef.IsDirty
            End If
            Return isDirty
        End Get
    End Property
    Public Property MonitorType() As PolyMonTypes.MonitorTypes
        Get
            If cboMonitorType.SelectedItem Is Nothing Then
                Return Nothing
            Else
                Return CType(cboMonitorType.SelectedItem, PolyMonClasses.MonitorType).MonitorType
            End If
        End Get
        Set(ByVal value As PolyMonTypes.MonitorTypes)
            If value = Nothing Then
                cboMonitorType.SelectedIndex = -1
                SetMonitorType(Nothing)
            Else
                Dim Found As Boolean = False
                For Each item As PolyMonClasses.MonitorType In cboMonitorType.Items
                    If item.MonitorTypeName = value.ToString Then
                        cboMonitorType.SelectedItem = item
                        Found = True
                    End If
                Next
                If Found Then
                    Dim MT As PolyMonClasses.MonitorType = CType(cboMonitorType.SelectedItem, PolyMonClasses.MonitorType)
                    SetMonitorType(MT)
                Else
                    cboMonitorType.SelectedIndex = -1
                    SetMonitorType(Nothing)
                End If
            End If
        End Set
    End Property
    Public Property PollingInterval() As Integer
        Get
            Return CInt(nudPollingInterval.Value)
        End Get
        Set(ByVal value As Integer)
            nudPollingInterval.Value = value
        End Set
    End Property
    Public Property RetentionPeriod() As Integer
        Get
            Return CInt(nudRetentionPeriod.Value)
        End Get
        Set(ByVal value As Integer)
            nudRetentionPeriod.Value = value
        End Set
    End Property
    Public Property RangeScaling() As Double
        Get
            Return CDbl(nudRangeScaling.Value)
        End Get
        Set(ByVal value As Double)
            nudRangeScaling.Value = CDec(value)
        End Set
    End Property
    Public Property RangeLegend() As String
        Get
            Return txtRangeLegend.Text
        End Get
        Set(ByVal value As String)
            txtRangeLegend.Text = value
        End Set
    End Property
    Public Property T1Enabled() As Boolean
        Get
            Return chkThreshold1.Checked
        End Get
        Set(ByVal value As Boolean)
            chkThreshold1.Checked = value
        End Set
    End Property
    Public Property T2Enabled() As Boolean
        Get
            Return chkThreshold2.Checked
        End Get
        Set(ByVal value As Boolean)
            chkThreshold2.Checked = value
        End Set
    End Property
    Public Property T1Value() As Double
        Get
            Return nudThreshold1Value.Value
        End Get
        Set(ByVal value As Double)
            nudThreshold1Value.Value = CDec(value)
        End Set
    End Property
    Public Property T2Value() As Double
        Get
            Return nudthreshold2Value.Value
        End Get
        Set(ByVal value As Double)
            nudthreshold2Value.Value = CDec(value)
        End Set
    End Property
    Public Property T1Color() As System.Drawing.Color
        Get
            Return pcbThreshold1Color.BackColor
        End Get
        Set(ByVal value As System.Drawing.Color)
            pcbThreshold1Color.BackColor = value
        End Set
    End Property
    Public Property T2Color() As System.Drawing.Color
        Get
            Return pcbThreshold2Color.BackColor
        End Get
        Set(ByVal value As System.Drawing.Color)
            pcbThreshold2Color.BackColor = value
        End Set
    End Property
    Public Property DialMinimum() As Double
        Get
            Return nudDialMinimum.Value
        End Get
        Set(ByVal value As Double)
            nudDialMinimum.Value = CDec(value)
        End Set
    End Property
    Public Property DialMaximum() As Double
        Get
            Return nudDialMaximum.Value
        End Get
        Set(ByVal value As Double)
            nudDialMaximum.Value = CDec(value)
        End Set
    End Property
    Public Property DialStep() As Double
        Get
            Return nudDialStepValue.Value
        End Get
        Set(ByVal value As Double)
            nudDialStepValue.Value = CDec(value)
        End Set
    End Property
    Public Property DialColor() As System.Drawing.Color
        Get
            Return pcbDialColor.BackColor
        End Get
        Set(ByVal value As System.Drawing.Color)
            pcbDialColor.BackColor = value
        End Set
    End Property


    Public Property GaugeOrientation() As PolyMonTypes.GaugeOrientations
        Get
            If radGaugeVertical.Checked Then
                Return PolyMonTypes.GaugeOrientations.Vertical
            Else
                Return PolyMonTypes.GaugeOrientations.Horizontal
            End If
        End Get
        Set(ByVal value As PolyMonTypes.GaugeOrientations)
            If value = PolyMonTypes.GaugeOrientations.Horizontal Then
                radGaugeHorizontal.Checked = True
            Else
                radGaugeVertical.Checked = True
            End If
        End Set
    End Property




    Private Sub SetMonitorType(ByVal MT As PolyMonClasses.MonitorType)
        'Clear out existing controls in pnlMonitorDef
        While pnlMonitorDef.Controls.Count > 0
            Dim ctl As Control = pnlMonitorDef.Controls(0)
            pnlMonitorDef.Controls.Remove(ctl)
            ctl = Nothing
        End While

        If MT Is Nothing Then Exit Sub

        'MONITORHOOK: Handle new Monitor types here
        'Then add Monitor type param interface
        Select Case MT.MonitorType
            Case PolyMonTypes.MonitorTypes.PerfMon
                Dim defPerfMon As New ucPerfMonConfig
                pnlMonitorDef.Controls.Add(defPerfMon)
                defPerfMon.Dock = DockStyle.Fill
            Case PolyMonTypes.MonitorTypes.SQLMonitor
                Dim defSQLMon As New ucSQLMonitorConfig
                pnlMonitorDef.Controls.Add(defSQLMon)
                defSQLMon.Dock = DockStyle.Fill
            Case PolyMonTypes.MonitorTypes.Ping
                Dim defPingMon As New ucPingConfig
                pnlMonitorDef.Controls.Add(defPingMon)
                defPingMon.Dock = DockStyle.Fill
            Case PolyMonTypes.MonitorTypes.PowerShell
                Dim defPowerShell As New ucPowerShellConfig
                pnlMonitorDef.Controls.Add(defPowerShell)
                defPowerShell.Dock = DockStyle.Fill
            Case Else
                'Do nothing
        End Select
    End Sub



    Private Sub cboMonitorType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboMonitorType.SelectedIndexChanged
        Dim MT As PolyMonClasses.MonitorType = CType(cboMonitorType.SelectedItem, PolyMonClasses.MonitorType)
        SetMonitorType(MT)
    End Sub

    Private Sub lnkSetT1Color_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkSetT1Color.LinkClicked
        ColorDialog1.Color = Me.pcbThreshold1Color.BackColor
        Dim res As DialogResult = ColorDialog1.ShowDialog()
        If res = Windows.Forms.DialogResult.OK Then
            Me.pcbThreshold1Color.BackColor = ColorDialog1.Color
        End If
    End Sub

    Private Sub lnkSetT2Color_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkSetT2Color.LinkClicked
        ColorDialog1.Color = Me.pcbThreshold2Color.BackColor
        Dim res As DialogResult = ColorDialog1.ShowDialog()
        If res = Windows.Forms.DialogResult.OK Then
            Me.pcbThreshold2Color.BackColor = ColorDialog1.Color
        End If
    End Sub

    Private Sub lnkSetDialColor_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkSetDialColor.LinkClicked
        ColorDialog1.Color = Me.pcbDialColor.BackColor
        Dim res As DialogResult = ColorDialog1.ShowDialog()
        If res = Windows.Forms.DialogResult.OK Then
            Me.pcbDialColor.BackColor = ColorDialog1.Color
        End If
    End Sub
End Class
