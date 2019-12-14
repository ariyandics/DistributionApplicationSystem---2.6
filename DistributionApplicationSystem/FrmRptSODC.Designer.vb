<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRptSODC
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmRptSODC))
        Me.RptRegisterTO = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.BtnProses = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Tgl2 = New System.Windows.Forms.DateTimePicker()
        Me.Tgl1 = New System.Windows.Forms.DateTimePicker()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.RadioButton2 = New System.Windows.Forms.RadioButton()
        Me.RbRekap = New System.Windows.Forms.RadioButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.cmbFilter = New System.Windows.Forms.ComboBox()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'RptRegisterTO
        '
        Me.RptRegisterTO.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RptRegisterTO.Location = New System.Drawing.Point(0, 101)
        Me.RptRegisterTO.Name = "RptRegisterTO"
        Me.RptRegisterTO.Size = New System.Drawing.Size(1329, 517)
        Me.RptRegisterTO.TabIndex = 196
        '
        'BtnProses
        '
        Me.BtnProses.BackColor = System.Drawing.Color.DodgerBlue
        Me.BtnProses.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Aqua
        Me.BtnProses.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnProses.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnProses.Image = CType(resources.GetObject("BtnProses.Image"), System.Drawing.Image)
        Me.BtnProses.Location = New System.Drawing.Point(690, 50)
        Me.BtnProses.Name = "BtnProses"
        Me.BtnProses.Size = New System.Drawing.Size(115, 43)
        Me.BtnProses.TabIndex = 195
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
        Me.GroupBox2.Location = New System.Drawing.Point(179, 44)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(297, 50)
        Me.GroupBox2.TabIndex = 194
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Periode"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(131, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(28, 13)
        Me.Label2.TabIndex = 176
        Me.Label2.Text = "S.D"
        '
        'Tgl2
        '
        Me.Tgl2.CustomFormat = "dd-MM-yyyy"
        Me.Tgl2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Tgl2.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.Tgl2.Location = New System.Drawing.Point(170, 20)
        Me.Tgl2.Name = "Tgl2"
        Me.Tgl2.Size = New System.Drawing.Size(116, 22)
        Me.Tgl2.TabIndex = 1
        '
        'Tgl1
        '
        Me.Tgl1.CustomFormat = "dd-MM-yyyy"
        Me.Tgl1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Tgl1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.Tgl1.Location = New System.Drawing.Point(9, 21)
        Me.Tgl1.Name = "Tgl1"
        Me.Tgl1.Size = New System.Drawing.Size(116, 22)
        Me.Tgl1.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.RadioButton2)
        Me.GroupBox1.Controls.Add(Me.RbRekap)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(7, 44)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(161, 50)
        Me.GroupBox1.TabIndex = 193
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Jenis Report"
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton2.ForeColor = System.Drawing.Color.White
        Me.RadioButton2.Location = New System.Drawing.Point(87, 20)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(67, 20)
        Me.RadioButton2.TabIndex = 1
        Me.RadioButton2.TabStop = True
        Me.RadioButton2.Text = "Detail"
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'RbRekap
        '
        Me.RbRekap.AutoSize = True
        Me.RbRekap.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RbRekap.ForeColor = System.Drawing.Color.White
        Me.RbRekap.Location = New System.Drawing.Point(7, 20)
        Me.RbRekap.Name = "RbRekap"
        Me.RbRekap.Size = New System.Drawing.Size(72, 20)
        Me.RbRekap.TabIndex = 0
        Me.RbRekap.TabStop = True
        Me.RbRekap.Text = "Rekap"
        Me.RbRekap.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label1.Font = New System.Drawing.Font("Britannic Bold", 20.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(7, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(242, 30)
        Me.Label1.TabIndex = 192
        Me.Label1.Text = "STOCK OPNAME DC"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(1329, 101)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 191
        Me.PictureBox1.TabStop = False
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox3.Controls.Add(Me.cmbFilter)
        Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(486, 44)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(189, 50)
        Me.GroupBox3.TabIndex = 197
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Filter By"
        '
        'cmbFilter
        '
        Me.cmbFilter.FormattingEnabled = True
        Me.cmbFilter.Location = New System.Drawing.Point(10, 18)
        Me.cmbFilter.Name = "cmbFilter"
        Me.cmbFilter.Size = New System.Drawing.Size(173, 21)
        Me.cmbFilter.TabIndex = 0
        '
        'FrmRptSODC
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1329, 618)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.RptRegisterTO)
        Me.Controls.Add(Me.BtnProses)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PictureBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Name = "FrmRptSODC"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmRptSODC"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents RptRegisterTO As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents BtnProses As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Tgl2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Tgl1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents RadioButton2 As System.Windows.Forms.RadioButton
    Friend WithEvents RbRekap As System.Windows.Forms.RadioButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents cmbFilter As System.Windows.Forms.ComboBox
End Class
