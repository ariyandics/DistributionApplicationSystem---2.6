<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPrintKartuStok
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmPrintKartuStok))
        Me.RptKSToko = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.txtnamaproduk = New System.Windows.Forms.TextBox()
        Me.txtnamaToko = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btFindProduk = New System.Windows.Forms.Button()
        Me.txtkdProduk = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.BtnFindStore = New System.Windows.Forms.Button()
        Me.TxtKodeToko = New System.Windows.Forms.TextBox()
        Me.BtnProses = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Tgl2 = New System.Windows.Forms.DateTimePicker()
        Me.Tgl1 = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'RptKSToko
        '
        Me.RptKSToko.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RptKSToko.Location = New System.Drawing.Point(0, 175)
        Me.RptKSToko.Margin = New System.Windows.Forms.Padding(4)
        Me.RptKSToko.Name = "RptKSToko"
        Me.RptKSToko.Size = New System.Drawing.Size(1765, 579)
        Me.RptKSToko.TabIndex = 199
        '
        'GroupBox4
        '
        Me.GroupBox4.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox4.Controls.Add(Me.txtnamaproduk)
        Me.GroupBox4.Controls.Add(Me.txtnamaToko)
        Me.GroupBox4.Controls.Add(Me.Label4)
        Me.GroupBox4.Controls.Add(Me.btFindProduk)
        Me.GroupBox4.Controls.Add(Me.txtkdProduk)
        Me.GroupBox4.Controls.Add(Me.Label3)
        Me.GroupBox4.Controls.Add(Me.BtnFindStore)
        Me.GroupBox4.Controls.Add(Me.TxtKodeToko)
        Me.GroupBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox4.Location = New System.Drawing.Point(417, 53)
        Me.GroupBox4.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox4.Size = New System.Drawing.Size(923, 96)
        Me.GroupBox4.TabIndex = 198
        Me.GroupBox4.TabStop = False
        '
        'txtnamaproduk
        '
        Me.txtnamaproduk.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtnamaproduk.Location = New System.Drawing.Point(521, 56)
        Me.txtnamaproduk.Margin = New System.Windows.Forms.Padding(4)
        Me.txtnamaproduk.Name = "txtnamaproduk"
        Me.txtnamaproduk.ReadOnly = True
        Me.txtnamaproduk.Size = New System.Drawing.Size(385, 24)
        Me.txtnamaproduk.TabIndex = 14
        '
        'txtnamaToko
        '
        Me.txtnamaToko.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtnamaToko.Location = New System.Drawing.Point(58, 57)
        Me.txtnamaToko.Margin = New System.Windows.Forms.Padding(4)
        Me.txtnamaToko.Name = "txtnamaToko"
        Me.txtnamaToko.ReadOnly = True
        Me.txtnamaToko.Size = New System.Drawing.Size(385, 24)
        Me.txtnamaToko.TabIndex = 13
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(455, 26)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(59, 17)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "Produk"
        '
        'btFindProduk
        '
        Me.btFindProduk.BackColor = System.Drawing.Color.Transparent
        Me.btFindProduk.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btFindProduk.ForeColor = System.Drawing.Color.Black
        Me.btFindProduk.Location = New System.Drawing.Point(659, 24)
        Me.btFindProduk.Margin = New System.Windows.Forms.Padding(4)
        Me.btFindProduk.Name = "btFindProduk"
        Me.btFindProduk.Size = New System.Drawing.Size(51, 26)
        Me.btFindProduk.TabIndex = 11
        Me.btFindProduk.Text = "..."
        Me.btFindProduk.UseVisualStyleBackColor = False
        '
        'txtkdProduk
        '
        Me.txtkdProduk.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtkdProduk.Location = New System.Drawing.Point(521, 24)
        Me.txtkdProduk.Margin = New System.Windows.Forms.Padding(4)
        Me.txtkdProduk.Name = "txtkdProduk"
        Me.txtkdProduk.ReadOnly = True
        Me.txtkdProduk.Size = New System.Drawing.Size(130, 24)
        Me.txtkdProduk.TabIndex = 10
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(7, 27)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(44, 17)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Toko"
        '
        'BtnFindStore
        '
        Me.BtnFindStore.BackColor = System.Drawing.Color.Transparent
        Me.BtnFindStore.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnFindStore.ForeColor = System.Drawing.Color.Black
        Me.BtnFindStore.Location = New System.Drawing.Point(196, 25)
        Me.BtnFindStore.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnFindStore.Name = "BtnFindStore"
        Me.BtnFindStore.Size = New System.Drawing.Size(51, 26)
        Me.BtnFindStore.TabIndex = 8
        Me.BtnFindStore.Text = "..."
        Me.BtnFindStore.UseVisualStyleBackColor = False
        '
        'TxtKodeToko
        '
        Me.TxtKodeToko.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtKodeToko.Location = New System.Drawing.Point(58, 25)
        Me.TxtKodeToko.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtKodeToko.Name = "TxtKodeToko"
        Me.TxtKodeToko.ReadOnly = True
        Me.TxtKodeToko.Size = New System.Drawing.Size(130, 24)
        Me.TxtKodeToko.TabIndex = 6
        '
        'BtnProses
        '
        Me.BtnProses.BackColor = System.Drawing.Color.DodgerBlue
        Me.BtnProses.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Aqua
        Me.BtnProses.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnProses.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnProses.Image = CType(resources.GetObject("BtnProses.Image"), System.Drawing.Image)
        Me.BtnProses.Location = New System.Drawing.Point(1349, 61)
        Me.BtnProses.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnProses.Name = "BtnProses"
        Me.BtnProses.Size = New System.Drawing.Size(153, 53)
        Me.BtnProses.TabIndex = 196
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
        Me.GroupBox2.Location = New System.Drawing.Point(15, 53)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Size = New System.Drawing.Size(396, 62)
        Me.GroupBox2.TabIndex = 195
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
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(13, 9)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(341, 39)
        Me.Label1.TabIndex = 193
        Me.Label1.Text = "KARTU STOK TOKO"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(1765, 175)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 192
        Me.PictureBox1.TabStop = False
        '
        'FrmPrintKartuStok
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1765, 754)
        Me.Controls.Add(Me.RptKSToko)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.BtnProses)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Name = "FrmPrintKartuStok"
        Me.Text = "FrmPrintKartuStok"
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents RptKSToko As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents BtnFindStore As System.Windows.Forms.Button
    Friend WithEvents TxtKodeToko As System.Windows.Forms.TextBox
    Friend WithEvents BtnProses As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Tgl2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Tgl1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btFindProduk As System.Windows.Forms.Button
    Friend WithEvents txtkdProduk As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtnamaproduk As System.Windows.Forms.TextBox
    Friend WithEvents txtnamaToko As System.Windows.Forms.TextBox
End Class
