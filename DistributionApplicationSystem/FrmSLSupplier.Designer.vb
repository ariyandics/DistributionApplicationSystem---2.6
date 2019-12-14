<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSLSupplier
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmSLSupplier))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.RptSLSupplier = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.RadioButton2 = New System.Windows.Forms.RadioButton()
        Me.RbRekap = New System.Windows.Forms.RadioButton()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Tgl2 = New System.Windows.Forms.DateTimePicker()
        Me.Tgl1 = New System.Windows.Forms.DateTimePicker()
        Me.BtnProses = New System.Windows.Forms.Button()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.cmbFilter = New System.Windows.Forms.ComboBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.BtnFindSupplier = New System.Windows.Forms.Button()
        Me.TxtNamaSupplier = New System.Windows.Forms.TextBox()
        Me.TxtKodeSupplier = New System.Windows.Forms.TextBox()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label1.Font = New System.Drawing.Font("Britannic Bold", 20.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(313, 30)
        Me.Label1.TabIndex = 172
        Me.Label1.Text = "SERVICE LEVEL SUPPLIER"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(1329, 98)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 171
        Me.PictureBox1.TabStop = False
        '
        'RptSLSupplier
        '
        Me.RptSLSupplier.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RptSLSupplier.Location = New System.Drawing.Point(0, 98)
        Me.RptSLSupplier.Name = "RptSLSupplier"
        Me.RptSLSupplier.Size = New System.Drawing.Size(1329, 520)
        Me.RptSLSupplier.TabIndex = 173
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.RadioButton2)
        Me.GroupBox1.Controls.Add(Me.RbRekap)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(4, 42)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(161, 50)
        Me.GroupBox1.TabIndex = 174
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Jenis Report"
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
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
        Me.RbRekap.Location = New System.Drawing.Point(7, 20)
        Me.RbRekap.Name = "RbRekap"
        Me.RbRekap.Size = New System.Drawing.Size(72, 20)
        Me.RbRekap.TabIndex = 0
        Me.RbRekap.TabStop = True
        Me.RbRekap.Text = "Rekap"
        Me.RbRekap.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.Tgl2)
        Me.GroupBox2.Controls.Add(Me.Tgl1)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(176, 42)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(297, 50)
        Me.GroupBox2.TabIndex = 175
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
        'BtnProses
        '
        Me.BtnProses.BackColor = System.Drawing.Color.DodgerBlue
        Me.BtnProses.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Aqua
        Me.BtnProses.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnProses.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnProses.Image = CType(resources.GetObject("BtnProses.Image"), System.Drawing.Image)
        Me.BtnProses.Location = New System.Drawing.Point(1145, 48)
        Me.BtnProses.Name = "BtnProses"
        Me.BtnProses.Size = New System.Drawing.Size(115, 43)
        Me.BtnProses.TabIndex = 176
        Me.BtnProses.Text = "Proses"
        Me.BtnProses.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnProses.UseVisualStyleBackColor = False
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox3.Controls.Add(Me.cmbFilter)
        Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(484, 42)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(153, 50)
        Me.GroupBox3.TabIndex = 177
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Filter By"
        '
        'cmbFilter
        '
        Me.cmbFilter.FormattingEnabled = True
        Me.cmbFilter.Location = New System.Drawing.Point(10, 18)
        Me.cmbFilter.Name = "cmbFilter"
        Me.cmbFilter.Size = New System.Drawing.Size(131, 21)
        Me.cmbFilter.TabIndex = 0
        '
        'GroupBox4
        '
        Me.GroupBox4.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox4.Controls.Add(Me.BtnFindSupplier)
        Me.GroupBox4.Controls.Add(Me.TxtNamaSupplier)
        Me.GroupBox4.Controls.Add(Me.TxtKodeSupplier)
        Me.GroupBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox4.Location = New System.Drawing.Point(647, 42)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(492, 50)
        Me.GroupBox4.TabIndex = 178
        Me.GroupBox4.TabStop = False
        '
        'BtnFindSupplier
        '
        Me.BtnFindSupplier.BackColor = System.Drawing.Color.Transparent
        Me.BtnFindSupplier.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnFindSupplier.ForeColor = System.Drawing.Color.Black
        Me.BtnFindSupplier.Location = New System.Drawing.Point(434, 18)
        Me.BtnFindSupplier.Name = "BtnFindSupplier"
        Me.BtnFindSupplier.Size = New System.Drawing.Size(38, 21)
        Me.BtnFindSupplier.TabIndex = 8
        Me.BtnFindSupplier.Text = "..."
        Me.BtnFindSupplier.UseVisualStyleBackColor = False
        '
        'TxtNamaSupplier
        '
        Me.TxtNamaSupplier.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNamaSupplier.Location = New System.Drawing.Point(80, 18)
        Me.TxtNamaSupplier.Name = "TxtNamaSupplier"
        Me.TxtNamaSupplier.Size = New System.Drawing.Size(348, 21)
        Me.TxtNamaSupplier.TabIndex = 7
        '
        'TxtKodeSupplier
        '
        Me.TxtKodeSupplier.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtKodeSupplier.Location = New System.Drawing.Point(6, 18)
        Me.TxtKodeSupplier.Name = "TxtKodeSupplier"
        Me.TxtKodeSupplier.Size = New System.Drawing.Size(68, 21)
        Me.TxtKodeSupplier.TabIndex = 6
        '
        'FrmSLSupplier
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1329, 618)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.BtnProses)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.RptSLSupplier)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PictureBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Name = "FrmSLSupplier"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmSLSupplier"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents RptSLSupplier As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents RadioButton2 As System.Windows.Forms.RadioButton
    Friend WithEvents RbRekap As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Tgl2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Tgl1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents BtnProses As System.Windows.Forms.Button
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents cmbFilter As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents BtnFindSupplier As System.Windows.Forms.Button
    Friend WithEvents TxtNamaSupplier As System.Windows.Forms.TextBox
    Friend WithEvents TxtKodeSupplier As System.Windows.Forms.TextBox
End Class
