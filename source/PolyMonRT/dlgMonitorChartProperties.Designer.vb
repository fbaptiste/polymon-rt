<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgMonitorChartProperties
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(dlgMonitorChartProperties))
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.OK_Button = New System.Windows.Forms.Button
        Me.Cancel_Button = New System.Windows.Forms.Button
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.tpGeneral = New System.Windows.Forms.TabPage
        Me.lnkSetDialColor = New System.Windows.Forms.LinkLabel
        Me.pcbDialColor = New System.Windows.Forms.PictureBox
        Me.Label22 = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.nudDialStepValue = New System.Windows.Forms.NumericUpDown
        Me.Label21 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.nudDialMaximum = New System.Windows.Forms.NumericUpDown
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.nudDialMinimum = New System.Windows.Forms.NumericUpDown
        Me.Label17 = New System.Windows.Forms.Label
        Me.lnkSetT2Color = New System.Windows.Forms.LinkLabel
        Me.pcbThreshold2Color = New System.Windows.Forms.PictureBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.nudthreshold2Value = New System.Windows.Forms.NumericUpDown
        Me.Label15 = New System.Windows.Forms.Label
        Me.chkThreshold2 = New System.Windows.Forms.CheckBox
        Me.lnkSetT1Color = New System.Windows.Forms.LinkLabel
        Me.pcbThreshold1Color = New System.Windows.Forms.PictureBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.nudThreshold1Value = New System.Windows.Forms.NumericUpDown
        Me.Label10 = New System.Windows.Forms.Label
        Me.chkThreshold1 = New System.Windows.Forms.CheckBox
        Me.txtRangeLegend = New System.Windows.Forms.TextBox
        Me.nudRangeScaling = New System.Windows.Forms.NumericUpDown
        Me.nudRetentionPeriod = New System.Windows.Forms.NumericUpDown
        Me.nudPollingInterval = New System.Windows.Forms.NumericUpDown
        Me.txtName = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.tpMonitoring = New System.Windows.Forms.TabPage
        Me.pnlMonitorDef = New System.Windows.Forms.Panel
        Me.cboMonitorType = New System.Windows.Forms.ComboBox
        Me.Label24 = New System.Windows.Forms.Label
        Me.ColorDialog1 = New System.Windows.Forms.ColorDialog
        Me.Label23 = New System.Windows.Forms.Label
        Me.radGaugeVertical = New System.Windows.Forms.RadioButton
        Me.radGaugeHorizontal = New System.Windows.Forms.RadioButton
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.tpGeneral.SuspendLayout()
        CType(Me.pcbDialColor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudDialStepValue, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudDialMaximum, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudDialMinimum, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pcbThreshold2Color, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudthreshold2Value, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pcbThreshold1Color, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudThreshold1Value, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudRangeScaling, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudRetentionPeriod, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudPollingInterval, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpMonitoring.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.OK_Button, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 1, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(420, 455)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(146, 29)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.Location = New System.Drawing.Point(3, 3)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(67, 23)
        Me.OK_Button.TabIndex = 0
        Me.OK_Button.Text = "OK"
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Location = New System.Drawing.Point(76, 3)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(67, 23)
        Me.Cancel_Button.TabIndex = 1
        Me.Cancel_Button.Text = "Cancel"
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.tpGeneral)
        Me.TabControl1.Controls.Add(Me.tpMonitoring)
        Me.TabControl1.Location = New System.Drawing.Point(13, 13)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(553, 436)
        Me.TabControl1.TabIndex = 1
        '
        'tpGeneral
        '
        Me.tpGeneral.Controls.Add(Me.Panel1)
        Me.tpGeneral.Controls.Add(Me.lnkSetDialColor)
        Me.tpGeneral.Controls.Add(Me.pcbDialColor)
        Me.tpGeneral.Controls.Add(Me.Label22)
        Me.tpGeneral.Controls.Add(Me.Label20)
        Me.tpGeneral.Controls.Add(Me.nudDialStepValue)
        Me.tpGeneral.Controls.Add(Me.Label21)
        Me.tpGeneral.Controls.Add(Me.Label18)
        Me.tpGeneral.Controls.Add(Me.nudDialMaximum)
        Me.tpGeneral.Controls.Add(Me.Label19)
        Me.tpGeneral.Controls.Add(Me.Label16)
        Me.tpGeneral.Controls.Add(Me.nudDialMinimum)
        Me.tpGeneral.Controls.Add(Me.Label17)
        Me.tpGeneral.Controls.Add(Me.lnkSetT2Color)
        Me.tpGeneral.Controls.Add(Me.pcbThreshold2Color)
        Me.tpGeneral.Controls.Add(Me.Label13)
        Me.tpGeneral.Controls.Add(Me.Label14)
        Me.tpGeneral.Controls.Add(Me.nudthreshold2Value)
        Me.tpGeneral.Controls.Add(Me.Label15)
        Me.tpGeneral.Controls.Add(Me.chkThreshold2)
        Me.tpGeneral.Controls.Add(Me.lnkSetT1Color)
        Me.tpGeneral.Controls.Add(Me.pcbThreshold1Color)
        Me.tpGeneral.Controls.Add(Me.Label12)
        Me.tpGeneral.Controls.Add(Me.Label11)
        Me.tpGeneral.Controls.Add(Me.nudThreshold1Value)
        Me.tpGeneral.Controls.Add(Me.Label10)
        Me.tpGeneral.Controls.Add(Me.chkThreshold1)
        Me.tpGeneral.Controls.Add(Me.txtRangeLegend)
        Me.tpGeneral.Controls.Add(Me.nudRangeScaling)
        Me.tpGeneral.Controls.Add(Me.nudRetentionPeriod)
        Me.tpGeneral.Controls.Add(Me.nudPollingInterval)
        Me.tpGeneral.Controls.Add(Me.txtName)
        Me.tpGeneral.Controls.Add(Me.Label9)
        Me.tpGeneral.Controls.Add(Me.Label8)
        Me.tpGeneral.Controls.Add(Me.Label7)
        Me.tpGeneral.Controls.Add(Me.Label6)
        Me.tpGeneral.Controls.Add(Me.Label4)
        Me.tpGeneral.Controls.Add(Me.Label5)
        Me.tpGeneral.Controls.Add(Me.Label3)
        Me.tpGeneral.Controls.Add(Me.Label2)
        Me.tpGeneral.Controls.Add(Me.Label1)
        Me.tpGeneral.Location = New System.Drawing.Point(4, 22)
        Me.tpGeneral.Name = "tpGeneral"
        Me.tpGeneral.Padding = New System.Windows.Forms.Padding(3)
        Me.tpGeneral.Size = New System.Drawing.Size(545, 410)
        Me.tpGeneral.TabIndex = 0
        Me.tpGeneral.Text = "General"
        Me.tpGeneral.UseVisualStyleBackColor = True
        '
        'lnkSetDialColor
        '
        Me.lnkSetDialColor.AutoSize = True
        Me.lnkSetDialColor.Location = New System.Drawing.Point(125, 377)
        Me.lnkSetDialColor.Name = "lnkSetDialColor"
        Me.lnkSetDialColor.Size = New System.Drawing.Size(21, 13)
        Me.lnkSetDialColor.TabIndex = 42
        Me.lnkSetDialColor.TabStop = True
        Me.lnkSetDialColor.Text = "set"
        '
        'pcbDialColor
        '
        Me.pcbDialColor.BackColor = System.Drawing.Color.LightGreen
        Me.pcbDialColor.Location = New System.Drawing.Point(106, 378)
        Me.pcbDialColor.Name = "pcbDialColor"
        Me.pcbDialColor.Size = New System.Drawing.Size(12, 12)
        Me.pcbDialColor.TabIndex = 41
        Me.pcbDialColor.TabStop = False
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.ForeColor = System.Drawing.Color.FromArgb(CType(CType(4, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(148, Byte), Integer))
        Me.Label22.Location = New System.Drawing.Point(7, 377)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(66, 13)
        Me.Label22.TabIndex = 40
        Me.Label22.Text = "Gauge Color"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.Green
        Me.Label20.Location = New System.Drawing.Point(193, 347)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(92, 13)
        Me.Label20.TabIndex = 39
        Me.Label20.Text = "(in unscaled units)"
        '
        'nudDialStepValue
        '
        Me.nudDialStepValue.DecimalPlaces = 3
        Me.nudDialStepValue.Location = New System.Drawing.Point(106, 345)
        Me.nudDialStepValue.Maximum = New Decimal(New Integer() {100000000, 0, 0, 0})
        Me.nudDialStepValue.Name = "nudDialStepValue"
        Me.nudDialStepValue.Size = New System.Drawing.Size(84, 20)
        Me.nudDialStepValue.TabIndex = 38
        Me.nudDialStepValue.Value = New Decimal(New Integer() {100, 0, 0, 0})
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.ForeColor = System.Drawing.Color.FromArgb(CType(CType(4, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(148, Byte), Integer))
        Me.Label21.Location = New System.Drawing.Point(7, 348)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(64, 13)
        Me.Label21.TabIndex = 37
        Me.Label21.Text = "Gauge Step"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.Green
        Me.Label18.Location = New System.Drawing.Point(193, 318)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(92, 13)
        Me.Label18.TabIndex = 36
        Me.Label18.Text = "(in unscaled units)"
        '
        'nudDialMaximum
        '
        Me.nudDialMaximum.DecimalPlaces = 3
        Me.nudDialMaximum.Location = New System.Drawing.Point(106, 316)
        Me.nudDialMaximum.Maximum = New Decimal(New Integer() {100000000, 0, 0, 0})
        Me.nudDialMaximum.Name = "nudDialMaximum"
        Me.nudDialMaximum.Size = New System.Drawing.Size(84, 20)
        Me.nudDialMaximum.TabIndex = 35
        Me.nudDialMaximum.Value = New Decimal(New Integer() {100, 0, 0, 0})
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.ForeColor = System.Drawing.Color.FromArgb(CType(CType(4, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(148, Byte), Integer))
        Me.Label19.Location = New System.Drawing.Point(7, 319)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(86, 13)
        Me.Label19.TabIndex = 34
        Me.Label19.Text = "Gauge Maximum"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.Green
        Me.Label16.Location = New System.Drawing.Point(193, 289)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(92, 13)
        Me.Label16.TabIndex = 33
        Me.Label16.Text = "(in unscaled units)"
        '
        'nudDialMinimum
        '
        Me.nudDialMinimum.DecimalPlaces = 3
        Me.nudDialMinimum.Location = New System.Drawing.Point(106, 287)
        Me.nudDialMinimum.Maximum = New Decimal(New Integer() {100000000, 0, 0, 0})
        Me.nudDialMinimum.Name = "nudDialMinimum"
        Me.nudDialMinimum.Size = New System.Drawing.Size(84, 20)
        Me.nudDialMinimum.TabIndex = 32
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.ForeColor = System.Drawing.Color.FromArgb(CType(CType(4, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(148, Byte), Integer))
        Me.Label17.Location = New System.Drawing.Point(7, 290)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(83, 13)
        Me.Label17.TabIndex = 31
        Me.Label17.Text = "Gauge Minimum"
        '
        'lnkSetT2Color
        '
        Me.lnkSetT2Color.AutoSize = True
        Me.lnkSetT2Color.Location = New System.Drawing.Point(352, 221)
        Me.lnkSetT2Color.Name = "lnkSetT2Color"
        Me.lnkSetT2Color.Size = New System.Drawing.Size(21, 13)
        Me.lnkSetT2Color.TabIndex = 27
        Me.lnkSetT2Color.TabStop = True
        Me.lnkSetT2Color.Text = "set"
        '
        'pcbThreshold2Color
        '
        Me.pcbThreshold2Color.BackColor = System.Drawing.Color.Red
        Me.pcbThreshold2Color.Location = New System.Drawing.Point(335, 221)
        Me.pcbThreshold2Color.Name = "pcbThreshold2Color"
        Me.pcbThreshold2Color.Size = New System.Drawing.Size(12, 12)
        Me.pcbThreshold2Color.TabIndex = 26
        Me.pcbThreshold2Color.TabStop = False
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.ForeColor = System.Drawing.Color.FromArgb(CType(CType(4, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(148, Byte), Integer))
        Me.Label13.Location = New System.Drawing.Point(295, 221)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(31, 13)
        Me.Label13.TabIndex = 25
        Me.Label13.Text = "Color"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.Green
        Me.Label14.Location = New System.Drawing.Point(428, 194)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(92, 13)
        Me.Label14.TabIndex = 24
        Me.Label14.Text = "(in unscaled units)"
        '
        'nudthreshold2Value
        '
        Me.nudthreshold2Value.DecimalPlaces = 3
        Me.nudthreshold2Value.Location = New System.Drawing.Point(335, 192)
        Me.nudthreshold2Value.Maximum = New Decimal(New Integer() {100000000, 0, 0, 0})
        Me.nudthreshold2Value.Name = "nudthreshold2Value"
        Me.nudthreshold2Value.Size = New System.Drawing.Size(84, 20)
        Me.nudthreshold2Value.TabIndex = 23
        Me.nudthreshold2Value.Value = New Decimal(New Integer() {1000, 0, 0, 0})
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.ForeColor = System.Drawing.Color.FromArgb(CType(CType(4, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(148, Byte), Integer))
        Me.Label15.Location = New System.Drawing.Point(295, 195)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(34, 13)
        Me.Label15.TabIndex = 22
        Me.Label15.Text = "Value"
        '
        'chkThreshold2
        '
        Me.chkThreshold2.AutoSize = True
        Me.chkThreshold2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(4, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(148, Byte), Integer))
        Me.chkThreshold2.Location = New System.Drawing.Point(274, 172)
        Me.chkThreshold2.Name = "chkThreshold2"
        Me.chkThreshold2.Size = New System.Drawing.Size(82, 17)
        Me.chkThreshold2.TabIndex = 21
        Me.chkThreshold2.Text = "Threshold 2"
        Me.chkThreshold2.UseVisualStyleBackColor = True
        '
        'lnkSetT1Color
        '
        Me.lnkSetT1Color.AutoSize = True
        Me.lnkSetT1Color.Location = New System.Drawing.Point(88, 221)
        Me.lnkSetT1Color.Name = "lnkSetT1Color"
        Me.lnkSetT1Color.Size = New System.Drawing.Size(21, 13)
        Me.lnkSetT1Color.TabIndex = 20
        Me.lnkSetT1Color.TabStop = True
        Me.lnkSetT1Color.Text = "set"
        '
        'pcbThreshold1Color
        '
        Me.pcbThreshold1Color.BackColor = System.Drawing.Color.DarkOrange
        Me.pcbThreshold1Color.Location = New System.Drawing.Point(71, 221)
        Me.pcbThreshold1Color.Name = "pcbThreshold1Color"
        Me.pcbThreshold1Color.Size = New System.Drawing.Size(12, 12)
        Me.pcbThreshold1Color.TabIndex = 19
        Me.pcbThreshold1Color.TabStop = False
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.ForeColor = System.Drawing.Color.FromArgb(CType(CType(4, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(148, Byte), Integer))
        Me.Label12.Location = New System.Drawing.Point(31, 221)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(31, 13)
        Me.Label12.TabIndex = 18
        Me.Label12.Text = "Color"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Green
        Me.Label11.Location = New System.Drawing.Point(164, 194)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(92, 13)
        Me.Label11.TabIndex = 17
        Me.Label11.Text = "(in unscaled units)"
        '
        'nudThreshold1Value
        '
        Me.nudThreshold1Value.DecimalPlaces = 3
        Me.nudThreshold1Value.Location = New System.Drawing.Point(71, 192)
        Me.nudThreshold1Value.Maximum = New Decimal(New Integer() {100000000, 0, 0, 0})
        Me.nudThreshold1Value.Name = "nudThreshold1Value"
        Me.nudThreshold1Value.Size = New System.Drawing.Size(84, 20)
        Me.nudThreshold1Value.TabIndex = 16
        Me.nudThreshold1Value.Value = New Decimal(New Integer() {1000, 0, 0, 0})
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(4, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(148, Byte), Integer))
        Me.Label10.Location = New System.Drawing.Point(31, 195)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(34, 13)
        Me.Label10.TabIndex = 15
        Me.Label10.Text = "Value"
        '
        'chkThreshold1
        '
        Me.chkThreshold1.AutoSize = True
        Me.chkThreshold1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(4, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(148, Byte), Integer))
        Me.chkThreshold1.Location = New System.Drawing.Point(10, 172)
        Me.chkThreshold1.Name = "chkThreshold1"
        Me.chkThreshold1.Size = New System.Drawing.Size(82, 17)
        Me.chkThreshold1.TabIndex = 14
        Me.chkThreshold1.Text = "Threshold 1"
        Me.chkThreshold1.UseVisualStyleBackColor = True
        '
        'txtRangeLegend
        '
        Me.txtRangeLegend.Location = New System.Drawing.Point(113, 126)
        Me.txtRangeLegend.Name = "txtRangeLegend"
        Me.txtRangeLegend.Size = New System.Drawing.Size(165, 20)
        Me.txtRangeLegend.TabIndex = 13
        '
        'nudRangeScaling
        '
        Me.nudRangeScaling.DecimalPlaces = 5
        Me.nudRangeScaling.Location = New System.Drawing.Point(113, 100)
        Me.nudRangeScaling.Maximum = New Decimal(New Integer() {100000000, 0, 0, 0})
        Me.nudRangeScaling.Name = "nudRangeScaling"
        Me.nudRangeScaling.Size = New System.Drawing.Size(82, 20)
        Me.nudRangeScaling.TabIndex = 12
        Me.nudRangeScaling.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'nudRetentionPeriod
        '
        Me.nudRetentionPeriod.Location = New System.Drawing.Point(113, 74)
        Me.nudRetentionPeriod.Maximum = New Decimal(New Integer() {600, 0, 0, 0})
        Me.nudRetentionPeriod.Name = "nudRetentionPeriod"
        Me.nudRetentionPeriod.Size = New System.Drawing.Size(82, 20)
        Me.nudRetentionPeriod.TabIndex = 11
        Me.nudRetentionPeriod.Value = New Decimal(New Integer() {180, 0, 0, 0})
        '
        'nudPollingInterval
        '
        Me.nudPollingInterval.Location = New System.Drawing.Point(113, 48)
        Me.nudPollingInterval.Maximum = New Decimal(New Integer() {100000000, 0, 0, 0})
        Me.nudPollingInterval.Name = "nudPollingInterval"
        Me.nudPollingInterval.Size = New System.Drawing.Size(82, 20)
        Me.nudPollingInterval.TabIndex = 10
        Me.nudPollingInterval.Value = New Decimal(New Integer() {1000, 0, 0, 0})
        '
        'txtName
        '
        Me.txtName.Location = New System.Drawing.Point(113, 22)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(194, 20)
        Me.txtName.TabIndex = 9
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Green
        Me.Label9.Location = New System.Drawing.Point(287, 128)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(114, 13)
        Me.Label9.TabIndex = 8
        Me.Label9.Text = "(Y-Axis/Gauge legend)"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(4, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(148, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(7, 129)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(78, 13)
        Me.Label8.TabIndex = 7
        Me.Label8.Text = "Range Legend"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Green
        Me.Label7.Location = New System.Drawing.Point(200, 102)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(177, 13)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "(Report results divided by this value)"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(4, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(148, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(7, 103)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(77, 13)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "Range Scaling"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Green
        Me.Label4.Location = New System.Drawing.Point(200, 76)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(65, 13)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "(data points)"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(4, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(148, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(7, 77)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(86, 13)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "Retention Period"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Green
        Me.Label3.Location = New System.Drawing.Point(200, 50)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(69, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "(milliseconds)"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(4, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(148, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(7, 51)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(75, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Polling interval"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(4, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(148, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(7, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(35, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Name"
        '
        'tpMonitoring
        '
        Me.tpMonitoring.Controls.Add(Me.pnlMonitorDef)
        Me.tpMonitoring.Controls.Add(Me.cboMonitorType)
        Me.tpMonitoring.Controls.Add(Me.Label24)
        Me.tpMonitoring.Location = New System.Drawing.Point(4, 22)
        Me.tpMonitoring.Name = "tpMonitoring"
        Me.tpMonitoring.Padding = New System.Windows.Forms.Padding(3)
        Me.tpMonitoring.Size = New System.Drawing.Size(545, 410)
        Me.tpMonitoring.TabIndex = 2
        Me.tpMonitoring.Text = "Monitoring"
        Me.tpMonitoring.UseVisualStyleBackColor = True
        '
        'pnlMonitorDef
        '
        Me.pnlMonitorDef.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlMonitorDef.AutoScroll = True
        Me.pnlMonitorDef.Location = New System.Drawing.Point(20, 51)
        Me.pnlMonitorDef.Name = "pnlMonitorDef"
        Me.pnlMonitorDef.Size = New System.Drawing.Size(508, 342)
        Me.pnlMonitorDef.TabIndex = 21
        '
        'cboMonitorType
        '
        Me.cboMonitorType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMonitorType.FormattingEnabled = True
        Me.cboMonitorType.Location = New System.Drawing.Point(100, 15)
        Me.cboMonitorType.Name = "cboMonitorType"
        Me.cboMonitorType.Size = New System.Drawing.Size(143, 21)
        Me.cboMonitorType.TabIndex = 20
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.ForeColor = System.Drawing.Color.FromArgb(CType(CType(4, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(148, Byte), Integer))
        Me.Label24.Location = New System.Drawing.Point(17, 18)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(69, 13)
        Me.Label24.TabIndex = 19
        Me.Label24.Text = "Monitor Type"
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.ForeColor = System.Drawing.Color.FromArgb(CType(CType(4, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(148, Byte), Integer))
        Me.Label23.Location = New System.Drawing.Point(5, 14)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(125, 13)
        Me.Label23.TabIndex = 43
        Me.Label23.Text = "Linear Gauge Orientation"
        '
        'radGaugeVertical
        '
        Me.radGaugeVertical.AutoSize = True
        Me.radGaugeVertical.ForeColor = System.Drawing.Color.FromArgb(CType(CType(4, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(148, Byte), Integer))
        Me.radGaugeVertical.Location = New System.Drawing.Point(137, 13)
        Me.radGaugeVertical.Name = "radGaugeVertical"
        Me.radGaugeVertical.Size = New System.Drawing.Size(60, 17)
        Me.radGaugeVertical.TabIndex = 44
        Me.radGaugeVertical.TabStop = True
        Me.radGaugeVertical.Text = "Vertical"
        Me.radGaugeVertical.UseVisualStyleBackColor = True
        '
        'radGaugeHorizontal
        '
        Me.radGaugeHorizontal.AutoSize = True
        Me.radGaugeHorizontal.ForeColor = System.Drawing.Color.FromArgb(CType(CType(4, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(148, Byte), Integer))
        Me.radGaugeHorizontal.Location = New System.Drawing.Point(137, 36)
        Me.radGaugeHorizontal.Name = "radGaugeHorizontal"
        Me.radGaugeHorizontal.Size = New System.Drawing.Size(72, 17)
        Me.radGaugeHorizontal.TabIndex = 45
        Me.radGaugeHorizontal.TabStop = True
        Me.radGaugeHorizontal.Text = "Horizontal"
        Me.radGaugeHorizontal.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Label23)
        Me.Panel1.Controls.Add(Me.radGaugeHorizontal)
        Me.Panel1.Controls.Add(Me.radGaugeVertical)
        Me.Panel1.Location = New System.Drawing.Point(311, 276)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(228, 100)
        Me.Panel1.TabIndex = 46
        '
        'dlgMonitorChartProperties
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(578, 496)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "dlgMonitorChartProperties"
        Me.ShowInTaskbar = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Monitor Properties"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.tpGeneral.ResumeLayout(False)
        Me.tpGeneral.PerformLayout()
        CType(Me.pcbDialColor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudDialStepValue, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudDialMaximum, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudDialMinimum, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pcbThreshold2Color, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudthreshold2Value, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pcbThreshold1Color, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudThreshold1Value, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudRangeScaling, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudRetentionPeriod, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudPollingInterval, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpMonitoring.ResumeLayout(False)
        Me.tpMonitoring.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents tpGeneral As System.Windows.Forms.TabPage
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tpMonitoring As System.Windows.Forms.TabPage
    Friend WithEvents txtRangeLegend As System.Windows.Forms.TextBox
    Friend WithEvents nudRangeScaling As System.Windows.Forms.NumericUpDown
    Friend WithEvents nudRetentionPeriod As System.Windows.Forms.NumericUpDown
    Friend WithEvents nudPollingInterval As System.Windows.Forms.NumericUpDown
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents nudThreshold1Value As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents chkThreshold1 As System.Windows.Forms.CheckBox
    Friend WithEvents ColorDialog1 As System.Windows.Forms.ColorDialog
    Friend WithEvents lnkSetT2Color As System.Windows.Forms.LinkLabel
    Friend WithEvents pcbThreshold2Color As System.Windows.Forms.PictureBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents nudthreshold2Value As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents chkThreshold2 As System.Windows.Forms.CheckBox
    Friend WithEvents lnkSetT1Color As System.Windows.Forms.LinkLabel
    Friend WithEvents pcbThreshold1Color As System.Windows.Forms.PictureBox
    Friend WithEvents cboMonitorType As System.Windows.Forms.ComboBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents pnlMonitorDef As System.Windows.Forms.Panel
    Friend WithEvents lnkSetDialColor As System.Windows.Forms.LinkLabel
    Friend WithEvents pcbDialColor As System.Windows.Forms.PictureBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents nudDialStepValue As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents nudDialMaximum As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents nudDialMinimum As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents radGaugeHorizontal As System.Windows.Forms.RadioButton
    Friend WithEvents radGaugeVertical As System.Windows.Forms.RadioButton

End Class
