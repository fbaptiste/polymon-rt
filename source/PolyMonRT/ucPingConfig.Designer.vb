<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucPingConfig
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtHost = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.nudNumTries = New System.Windows.Forms.NumericUpDown
        Me.nudTimeout = New System.Windows.Forms.NumericUpDown
        Me.nudTTL = New System.Windows.Forms.NumericUpDown
        Me.nudDataSize = New System.Windows.Forms.NumericUpDown
        Me.radPercFail = New System.Windows.Forms.RadioButton
        Me.radAvgRTT = New System.Windows.Forms.RadioButton
        CType(Me.nudNumTries, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudTimeout, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudTTL, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudDataSize, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(4, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(148, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(9, 17)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(29, 13)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "Host"
        '
        'txtHost
        '
        Me.txtHost.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtHost.Location = New System.Drawing.Point(105, 13)
        Me.txtHost.Name = "txtHost"
        Me.txtHost.Size = New System.Drawing.Size(171, 20)
        Me.txtHost.TabIndex = 13
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(4, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(148, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(9, 45)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 13)
        Me.Label1.TabIndex = 15
        Me.Label1.Text = "# Tries"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(4, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(148, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(9, 73)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(67, 13)
        Me.Label2.TabIndex = 16
        Me.Label2.Text = "Timeout (ms)"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(4, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(148, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(9, 101)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(27, 13)
        Me.Label3.TabIndex = 17
        Me.Label3.Text = "TTL"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(4, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(148, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(9, 129)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(53, 13)
        Me.Label4.TabIndex = 18
        Me.Label4.Text = "Data Size"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(4, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(148, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(9, 157)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(71, 13)
        Me.Label5.TabIndex = 19
        Me.Label5.Text = "Return Metric"
        '
        'nudNumTries
        '
        Me.nudNumTries.Location = New System.Drawing.Point(105, 41)
        Me.nudNumTries.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudNumTries.Name = "nudNumTries"
        Me.nudNumTries.Size = New System.Drawing.Size(49, 20)
        Me.nudNumTries.TabIndex = 20
        Me.nudNumTries.Value = New Decimal(New Integer() {5, 0, 0, 0})
        '
        'nudTimeout
        '
        Me.nudTimeout.Location = New System.Drawing.Point(105, 69)
        Me.nudTimeout.Maximum = New Decimal(New Integer() {500000, 0, 0, 0})
        Me.nudTimeout.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudTimeout.Name = "nudTimeout"
        Me.nudTimeout.Size = New System.Drawing.Size(99, 20)
        Me.nudTimeout.TabIndex = 21
        Me.nudTimeout.Value = New Decimal(New Integer() {2000, 0, 0, 0})
        '
        'nudTTL
        '
        Me.nudTTL.Location = New System.Drawing.Point(105, 97)
        Me.nudTTL.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.nudTTL.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudTTL.Name = "nudTTL"
        Me.nudTTL.Size = New System.Drawing.Size(99, 20)
        Me.nudTTL.TabIndex = 22
        Me.nudTTL.Value = New Decimal(New Integer() {32, 0, 0, 0})
        '
        'nudDataSize
        '
        Me.nudDataSize.Location = New System.Drawing.Point(105, 125)
        Me.nudDataSize.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.nudDataSize.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudDataSize.Name = "nudDataSize"
        Me.nudDataSize.Size = New System.Drawing.Size(99, 20)
        Me.nudDataSize.TabIndex = 23
        Me.nudDataSize.Value = New Decimal(New Integer() {32, 0, 0, 0})
        '
        'radPercFail
        '
        Me.radPercFail.AutoSize = True
        Me.radPercFail.Location = New System.Drawing.Point(105, 157)
        Me.radPercFail.Name = "radPercFail"
        Me.radPercFail.Size = New System.Drawing.Size(90, 17)
        Me.radPercFail.TabIndex = 24
        Me.radPercFail.TabStop = True
        Me.radPercFail.Text = "% Failed Tries"
        Me.radPercFail.UseVisualStyleBackColor = True
        '
        'radAvgRTT
        '
        Me.radAvgRTT.AutoSize = True
        Me.radAvgRTT.Location = New System.Drawing.Point(105, 181)
        Me.radAvgRTT.Name = "radAvgRTT"
        Me.radAvgRTT.Size = New System.Drawing.Size(112, 17)
        Me.radAvgRTT.TabIndex = 25
        Me.radAvgRTT.TabStop = True
        Me.radAvgRTT.Text = "Average RTT (ms)"
        Me.radAvgRTT.UseVisualStyleBackColor = True
        '
        'ucPingConfig
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.radAvgRTT)
        Me.Controls.Add(Me.radPercFail)
        Me.Controls.Add(Me.nudDataSize)
        Me.Controls.Add(Me.nudTTL)
        Me.Controls.Add(Me.nudTimeout)
        Me.Controls.Add(Me.nudNumTries)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtHost)
        Me.Name = "ucPingConfig"
        Me.Size = New System.Drawing.Size(287, 207)
        CType(Me.nudNumTries, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudTimeout, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudTTL, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudDataSize, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtHost As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents nudNumTries As System.Windows.Forms.NumericUpDown
    Friend WithEvents nudTimeout As System.Windows.Forms.NumericUpDown
    Friend WithEvents nudTTL As System.Windows.Forms.NumericUpDown
    Friend WithEvents nudDataSize As System.Windows.Forms.NumericUpDown
    Friend WithEvents radPercFail As System.Windows.Forms.RadioButton
    Friend WithEvents radAvgRTT As System.Windows.Forms.RadioButton

End Class
