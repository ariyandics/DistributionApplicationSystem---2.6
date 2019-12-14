<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmStockMovement
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmStockMovement))
        Me.BtnProses = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Tgl2 = New System.Windows.Forms.DateTimePicker()
        Me.Tgl1 = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.RptRegisterTO = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.RbBS = New System.Windows.Forms.RadioButton()
        Me.RbGS = New System.Windows.Forms.RadioButton()
        Me.GroupBox2.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'BtnProses
        '
        Me.BtnProses.BackColor = System.Drawing.Color.DodgerBlue
        Me.BtnProses.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Aqua
        Me.BtnProses.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnProses.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnProses.Image = CType(resources.GetObject("BtnProses.Image"), System.Drawing.Image)
        Me.BtnProses.Location = New System.Drawing.Point(807, 57)
        Me.BtnProses.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.BtnProses.Name = "BtnProses"
        Me.BtnProses.Size = New System.Drawing.Size(153, 53)
        Me.BtnProses.TabIndex = 186
        Me.BtnProses.Text = "Proses"
        Me.BtnProses.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnProses.UseVisualStyleBackColor = False
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.Tgl2)
        Me.GroupBox2.Controls.Add(Me.Tgl1)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(16, 49)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox2.Size = New System.Drawing.Size(396, 62)
        Me.GroupBox2.TabIndex = 185
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Periode"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(175, 30)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(34, 17)
        Me.Label2.TabIndex = 176
        Me.Label2.Text = "S.D"
        '
        'Tgl2
        '
        Me.Tgl2.CustomFormat = "dd-MM-yyyy"
        Me.Tgl2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Tgl2.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.Tgl2.Location = New System.Drawing.Point(227, 25)
        Me.Tgl2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Tgl2.Name = "Tgl2"
        Me.Tgl2.Size = New System.Drawing.Size(153, 26)
        Me.Tgl2.TabIndex = 1
        '
        'Tgl1
        '
        Me.Tgl1.CustomFormat = "dd-MM-yyyy"
        Me.Tgl1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Tgl1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.Tgl1.Location = New System.Drawing.Point(12, 26)
        Me.Tgl1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Tgl1.Name = "Tgl1"
        Me.Tgl1.Size = New System.Drawing.Size(153, 26)
        Me.Tgl1.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(9, 9)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(423, 39)
        Me.Label1.TabIndex = 184
        Me.Label1.Text = "INVENTORY MOVEMENT"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(1772, 122)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 183
        Me.PictureBox1.TabStop = False
        '
        'RptRegisterTO
        '
        Me.RptRegisterTO.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RptRegisterTO.Location = New System.Drawing.Point(0, 122)
        Me.RptRegisterTO.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.RptRegisterTO.Name = "RptRegisterTO"
        Me.RptRegisterTO.Size = New System.Drawing.Size(1772, 639)
        Me.RptRegisterTO.TabIndex = 200
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.RbBS)
        Me.GroupBox1.Controls.Add(Me.RbGS)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(429, 49)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox1.Size = New System.Drawing.Size(329, 59)
        Me.GroupBox1.TabIndex = 201
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Jenis Stock"
        '
        'RbBS
        '
        Me.RbBS.AutoSize = True
        Me.RbBS.Location = New System.Drawing.Point(196, 25)
        Me.RbBS.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.RbBS.Name = "RbBS"
        Me.RbBS.Size = New System.Drawing.Size(107, 22)
        Me.RbBS.TabIndex = 1
        Me.RbBS.TabStop = True
        Me.RbBS.Text = "Bad Stock"
        Me.RbBS.UseVisualStyleBackColor = True
        '
        'RbGS
        '
        Me.RbGS.AutoSize = True
        Me.RbGS.Location = New System.Drawing.Point(8, 25)
        Me.RbGS.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.RbGS.Name = "RbGS"
        Me.RbGS.Size = New System.Drawing.Size(120, 22)
        Me.RbGS.TabIndex = 0
        Me.RbGS.TabStop = True
        Me.RbGS.Text = "Good Stock"
        Me.RbGS.UseVisualStyleBackColor = True
        '
        'FrmStockMovement
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1772, 761)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.RptRegisterTO)
        Me.Controls.Add(Me.BtnProses)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PictureBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "FrmStockMovement"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmStockMovement"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BtnProses As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Tgl2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Tgl1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents RptRegisterTO As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents RbBS As System.Windows.Forms.RadioButton
    Friend WithEvents RbGS As System.Windows.Forms.RadioButton
End Class
