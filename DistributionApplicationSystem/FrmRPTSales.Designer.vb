<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRPTSales
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmRPTSales))
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.RptSLSupplier = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.BtnFindStore = New System.Windows.Forms.Button()
        Me.TxtNamaSupplier = New System.Windows.Forms.TextBox()
        Me.TxtKodeSupplier = New System.Windows.Forms.TextBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.cmbFilter = New System.Windows.Forms.ComboBox()
        Me.BtnProses = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Tgl2 = New System.Windows.Forms.DateTimePicker()
        Me.Tgl1 = New System.Windows.Forms.DateTimePicker()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.RbDetail = New System.Windows.Forms.RadioButton()
        Me.RBDetailStruk = New System.Windows.Forms.RadioButton()
        Me.RbRekap = New System.Windows.Forms.RadioButton()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(1764, 124)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 173
        Me.PictureBox1.TabStop = False
        '
        'RptSLSupplier
        '
        Me.RptSLSupplier.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RptSLSupplier.Location = New System.Drawing.Point(0, 124)
        Me.RptSLSupplier.Margin = New System.Windows.Forms.Padding(4)
        Me.RptSLSupplier.Name = "RptSLSupplier"
        Me.RptSLSupplier.Size = New System.Drawing.Size(1764, 629)
        Me.RptSLSupplier.TabIndex = 185
        '
        'GroupBox4
        '
        Me.GroupBox4.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox4.Controls.Add(Me.BtnFindStore)
        Me.GroupBox4.Controls.Add(Me.TxtNamaSupplier)
        Me.GroupBox4.Controls.Add(Me.TxtKodeSupplier)
        Me.GroupBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox4.Location = New System.Drawing.Point(988, 55)
        Me.GroupBox4.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox4.Size = New System.Drawing.Size(599, 62)
        Me.GroupBox4.TabIndex = 191
        Me.GroupBox4.TabStop = False
        '
        'BtnFindStore
        '
        Me.BtnFindStore.BackColor = System.Drawing.Color.Transparent
        Me.BtnFindStore.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnFindStore.ForeColor = System.Drawing.Color.Black
        Me.BtnFindStore.Location = New System.Drawing.Point(535, 22)
        Me.BtnFindStore.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnFindStore.Name = "BtnFindStore"
        Me.BtnFindStore.Size = New System.Drawing.Size(51, 26)
        Me.BtnFindStore.TabIndex = 8
        Me.BtnFindStore.Text = "..."
        Me.BtnFindStore.UseVisualStyleBackColor = False
        '
        'TxtNamaSupplier
        '
        Me.TxtNamaSupplier.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNamaSupplier.Location = New System.Drawing.Point(129, 22)
        Me.TxtNamaSupplier.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtNamaSupplier.Name = "TxtNamaSupplier"
        Me.TxtNamaSupplier.Size = New System.Drawing.Size(396, 24)
        Me.TxtNamaSupplier.TabIndex = 7
        '
        'TxtKodeSupplier
        '
        Me.TxtKodeSupplier.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtKodeSupplier.Location = New System.Drawing.Point(5, 22)
        Me.TxtKodeSupplier.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtKodeSupplier.Name = "TxtKodeSupplier"
        Me.TxtKodeSupplier.Size = New System.Drawing.Size(115, 24)
        Me.TxtKodeSupplier.TabIndex = 6
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox3.Controls.Add(Me.cmbFilter)
        Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(777, 55)
        Me.GroupBox3.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox3.Size = New System.Drawing.Size(204, 62)
        Me.GroupBox3.TabIndex = 190
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Filter By"
        '
        'cmbFilter
        '
        Me.cmbFilter.FormattingEnabled = True
        Me.cmbFilter.Location = New System.Drawing.Point(13, 22)
        Me.cmbFilter.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbFilter.Name = "cmbFilter"
        Me.cmbFilter.Size = New System.Drawing.Size(173, 25)
        Me.cmbFilter.TabIndex = 0
        '
        'BtnProses
        '
        Me.BtnProses.BackColor = System.Drawing.Color.DodgerBlue
        Me.BtnProses.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Aqua
        Me.BtnProses.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnProses.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnProses.Image = CType(resources.GetObject("BtnProses.Image"), System.Drawing.Image)
        Me.BtnProses.Location = New System.Drawing.Point(1596, 63)
        Me.BtnProses.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnProses.Name = "BtnProses"
        Me.BtnProses.Size = New System.Drawing.Size(153, 53)
        Me.BtnProses.TabIndex = 189
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
        Me.GroupBox2.Location = New System.Drawing.Point(373, 55)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Size = New System.Drawing.Size(396, 62)
        Me.GroupBox2.TabIndex = 188
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
        Me.Tgl2.Margin = New System.Windows.Forms.Padding(4)
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
        Me.Tgl1.Margin = New System.Windows.Forms.Padding(4)
        Me.Tgl1.Name = "Tgl1"
        Me.Tgl1.Size = New System.Drawing.Size(153, 26)
        Me.Tgl1.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.RbDetail)
        Me.GroupBox1.Controls.Add(Me.RBDetailStruk)
        Me.GroupBox1.Controls.Add(Me.RbRekap)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(9, 55)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Size = New System.Drawing.Size(356, 62)
        Me.GroupBox1.TabIndex = 187
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Jenis Report"
        '
        'RbDetail
        '
        Me.RbDetail.AutoSize = True
        Me.RbDetail.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RbDetail.ForeColor = System.Drawing.Color.White
        Me.RbDetail.Location = New System.Drawing.Point(259, 25)
        Me.RbDetail.Margin = New System.Windows.Forms.Padding(4)
        Me.RbDetail.Name = "RbDetail"
        Me.RbDetail.Size = New System.Drawing.Size(80, 24)
        Me.RbDetail.TabIndex = 3
        Me.RbDetail.TabStop = True
        Me.RbDetail.Text = "Detail"
        Me.RbDetail.UseVisualStyleBackColor = True
        '
        'RBDetailStruk
        '
        Me.RBDetailStruk.AutoSize = True
        Me.RBDetailStruk.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RBDetailStruk.ForeColor = System.Drawing.Color.White
        Me.RBDetailStruk.Location = New System.Drawing.Point(111, 25)
        Me.RBDetailStruk.Margin = New System.Windows.Forms.Padding(4)
        Me.RBDetailStruk.Name = "RBDetailStruk"
        Me.RBDetailStruk.Size = New System.Drawing.Size(130, 24)
        Me.RBDetailStruk.TabIndex = 2
        Me.RBDetailStruk.TabStop = True
        Me.RBDetailStruk.Text = "Detail/Struk"
        Me.RBDetailStruk.UseVisualStyleBackColor = True
        '
        'RbRekap
        '
        Me.RbRekap.AutoSize = True
        Me.RbRekap.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RbRekap.ForeColor = System.Drawing.Color.White
        Me.RbRekap.Location = New System.Drawing.Point(9, 25)
        Me.RbRekap.Margin = New System.Windows.Forms.Padding(4)
        Me.RbRekap.Name = "RbRekap"
        Me.RbRekap.Size = New System.Drawing.Size(82, 24)
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
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(16, 11)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(406, 39)
        Me.Label1.TabIndex = 186
        Me.Label1.Text = "LAPORAN SALES TOKO"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'FrmRPTSales
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(1764, 753)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.BtnProses)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.RptSLSupplier)
        Me.Controls.Add(Me.PictureBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "FrmRPTSales"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmRPTSales"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents RptSLSupplier As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents BtnFindStore As System.Windows.Forms.Button
    Friend WithEvents TxtNamaSupplier As System.Windows.Forms.TextBox
    Friend WithEvents TxtKodeSupplier As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents cmbFilter As System.Windows.Forms.ComboBox
    Friend WithEvents BtnProses As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Tgl2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Tgl1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents RbRekap As System.Windows.Forms.RadioButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents RBDetailStruk As System.Windows.Forms.RadioButton
    Friend WithEvents RbDetail As System.Windows.Forms.RadioButton
End Class
