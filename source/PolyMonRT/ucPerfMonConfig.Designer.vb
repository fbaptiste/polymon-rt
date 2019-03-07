<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucPerfMonConfig
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
        Me.txtHost = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.cboCategory = New System.Windows.Forms.ComboBox
        Me.cboCounter = New System.Windows.Forms.ComboBox
        Me.cboInstance = New System.Windows.Forms.ComboBox
        Me.txtHelp = New System.Windows.Forms.RichTextBox
        Me.pnlHelp = New System.Windows.Forms.Panel
        Me.pnlHelp.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtHost
        '
        Me.txtHost.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtHost.Location = New System.Drawing.Point(115, 6)
        Me.txtHost.Name = "txtHost"
        Me.txtHost.Size = New System.Drawing.Size(190, 20)
        Me.txtHost.TabIndex = 3
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(4, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(148, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(19, 107)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(48, 13)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "Instance"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(4, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(148, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(19, 9)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(29, 13)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Host"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(4, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(148, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(19, 74)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(44, 13)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "Counter"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(4, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(148, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(19, 41)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(49, 13)
        Me.Label8.TabIndex = 11
        Me.Label8.Text = "Category"
        '
        'cboCategory
        '
        Me.cboCategory.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCategory.FormattingEnabled = True
        Me.cboCategory.Location = New System.Drawing.Point(115, 38)
        Me.cboCategory.Name = "cboCategory"
        Me.cboCategory.Size = New System.Drawing.Size(190, 21)
        Me.cboCategory.Sorted = True
        Me.cboCategory.TabIndex = 14
        '
        'cboCounter
        '
        Me.cboCounter.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboCounter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCounter.FormattingEnabled = True
        Me.cboCounter.Location = New System.Drawing.Point(115, 71)
        Me.cboCounter.Name = "cboCounter"
        Me.cboCounter.Size = New System.Drawing.Size(190, 21)
        Me.cboCounter.Sorted = True
        Me.cboCounter.TabIndex = 15
        '
        'cboInstance
        '
        Me.cboInstance.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboInstance.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboInstance.FormattingEnabled = True
        Me.cboInstance.Location = New System.Drawing.Point(115, 104)
        Me.cboInstance.Name = "cboInstance"
        Me.cboInstance.Size = New System.Drawing.Size(190, 21)
        Me.cboInstance.Sorted = True
        Me.cboInstance.TabIndex = 16
        '
        'txtHelp
        '
        Me.txtHelp.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtHelp.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtHelp.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHelp.ForeColor = System.Drawing.Color.MidnightBlue
        Me.txtHelp.Location = New System.Drawing.Point(5, 5)
        Me.txtHelp.Margin = New System.Windows.Forms.Padding(0)
        Me.txtHelp.Name = "txtHelp"
        Me.txtHelp.ReadOnly = True
        Me.txtHelp.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical
        Me.txtHelp.Size = New System.Drawing.Size(271, 89)
        Me.txtHelp.TabIndex = 17
        Me.txtHelp.Text = ""
        '
        'pnlHelp
        '
        Me.pnlHelp.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlHelp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlHelp.Controls.Add(Me.txtHelp)
        Me.pnlHelp.Location = New System.Drawing.Point(22, 137)
        Me.pnlHelp.Name = "pnlHelp"
        Me.pnlHelp.Padding = New System.Windows.Forms.Padding(5)
        Me.pnlHelp.Size = New System.Drawing.Size(283, 101)
        Me.pnlHelp.TabIndex = 18
        '
        'ucPerfMonConfig
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.pnlHelp)
        Me.Controls.Add(Me.cboInstance)
        Me.Controls.Add(Me.cboCounter)
        Me.Controls.Add(Me.cboCategory)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtHost)
        Me.Name = "ucPerfMonConfig"
        Me.Size = New System.Drawing.Size(315, 241)
        Me.pnlHelp.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtHost As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cboCategory As System.Windows.Forms.ComboBox
    Friend WithEvents cboCounter As System.Windows.Forms.ComboBox
    Friend WithEvents cboInstance As System.Windows.Forms.ComboBox
    Friend WithEvents txtHelp As System.Windows.Forms.RichTextBox
    Friend WithEvents pnlHelp As System.Windows.Forms.Panel

End Class
