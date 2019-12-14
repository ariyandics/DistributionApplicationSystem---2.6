<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSumarynonrrak
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSumarynonrrak))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.RbNONRRAK = New System.Windows.Forms.RadioButton()
        Me.cbostatusnonrrak = New System.Windows.Forms.ComboBox()
        Me.cbostatusrrak = New System.Windows.Forms.ComboBox()
        Me.RbRRAK = New System.Windows.Forms.RadioButton()
        Me.RptAnggaranKas = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.BtnProses = New System.Windows.Forms.Button()
        Me.Tgl1 = New System.Windows.Forms.DateTimePicker()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Tgl2 = New System.Windows.Forms.DateTimePicker()
        Me.cbcategory = New System.Windows.Forms.ComboBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.BtnFindStore = New System.Windows.Forms.Button()
        Me.TxtNamaToko = New System.Windows.Forms.TextBox()
        Me.TxtKodeToko = New System.Windows.Forms.TextBox()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.RbNONRRAK)
        Me.GroupBox1.Controls.Add(Me.cbostatusnonrrak)
        Me.GroupBox1.Controls.Add(Me.cbostatusrrak)
        Me.GroupBox1.Controls.Add(Me.RbRRAK)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(16, 68)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Size = New System.Drawing.Size(393, 94)
        Me.GroupBox1.TabIndex = 207
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Jenis Anggaran"
        '
        'RbNONRRAK
        '
        Me.RbNONRRAK.AutoSize = True
        Me.RbNONRRAK.Location = New System.Drawing.Point(106, 27)
        Me.RbNONRRAK.Margin = New System.Windows.Forms.Padding(4)
        Me.RbNONRRAK.Name = "RbNONRRAK"
        Me.RbNONRRAK.Size = New System.Drawing.Size(116, 22)
        Me.RbNONRRAK.TabIndex = 1
        Me.RbNONRRAK.TabStop = True
        Me.RbNONRRAK.Text = "NON RRAK"
        Me.RbNONRRAK.UseVisualStyleBackColor = True
        '
        'cbostatusnonrrak
        '
        Me.cbostatusnonrrak.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbostatusnonrrak.Enabled = False
        Me.cbostatusnonrrak.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cbostatusnonrrak.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
        Me.cbostatusnonrrak.FormattingEnabled = True
        Me.cbostatusnonrrak.Items.AddRange(New Object() {"Rekap", "Detail"})
        Me.cbostatusnonrrak.Location = New System.Drawing.Point(196, 57)
        Me.cbostatusnonrrak.Name = "cbostatusnonrrak"
        Me.cbostatusnonrrak.Size = New System.Drawing.Size(177, 26)
        Me.cbostatusnonrrak.TabIndex = 209
        '
        'cbostatusrrak
        '
        Me.cbostatusrrak.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbostatusrrak.Enabled = False
        Me.cbostatusrrak.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cbostatusrrak.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
        Me.cbostatusrrak.FormattingEnabled = True
        Me.cbostatusrrak.Items.AddRange(New Object() {"Realisasi", "Estimasi"})
        Me.cbostatusrrak.Location = New System.Drawing.Point(8, 57)
        Me.cbostatusrrak.Name = "cbostatusrrak"
        Me.cbostatusrrak.Size = New System.Drawing.Size(177, 26)
        Me.cbostatusrrak.TabIndex = 208
        '
        'RbRRAK
        '
        Me.RbRRAK.AutoSize = True
        Me.RbRRAK.Location = New System.Drawing.Point(8, 27)
        Me.RbRRAK.Margin = New System.Windows.Forms.Padding(4)
        Me.RbRRAK.Name = "RbRRAK"
        Me.RbRRAK.Size = New System.Drawing.Size(74, 22)
        Me.RbRRAK.TabIndex = 0
        Me.RbRRAK.TabStop = True
        Me.RbRRAK.Text = "RRAK"
        Me.RbRRAK.UseVisualStyleBackColor = True
        '
        'RptAnggaranKas
        '
        Me.RptAnggaranKas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RptAnggaranKas.Location = New System.Drawing.Point(0, 176)
        Me.RptAnggaranKas.Margin = New System.Windows.Forms.Padding(4)
        Me.RptAnggaranKas.Name = "RptAnggaranKas"
        Me.RptAnggaranKas.Size = New System.Drawing.Size(1774, 585)
        Me.RptAnggaranKas.TabIndex = 206
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(1774, 176)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 202
        Me.PictureBox1.TabStop = False
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
        Me.Label1.Size = New System.Drawing.Size(673, 39)
        Me.Label1.TabIndex = 203
        Me.Label1.Text = "SUMMARY RRAK DAN NON RRAK TOKO"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'BtnProses
        '
        Me.BtnProses.BackColor = System.Drawing.Color.DodgerBlue
        Me.BtnProses.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Aqua
        Me.BtnProses.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnProses.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnProses.Image = CType(resources.GetObject("BtnProses.Image"), System.Drawing.Image)
        Me.BtnProses.Location = New System.Drawing.Point(1620, 108)
        Me.BtnProses.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnProses.Name = "BtnProses"
        Me.BtnProses.Size = New System.Drawing.Size(154, 53)
        Me.BtnProses.TabIndex = 205
        Me.BtnProses.Text = "Proses"
        Me.BtnProses.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnProses.UseVisualStyleBackColor = False
        '
        'Tgl1
        '
        Me.Tgl1.CustomFormat = "dd-MM-yyyy"
        Me.Tgl1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Tgl1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.Tgl1.Location = New System.Drawing.Point(17, 32)
        Me.Tgl1.Margin = New System.Windows.Forms.Padding(4)
        Me.Tgl1.Name = "Tgl1"
        Me.Tgl1.Size = New System.Drawing.Size(153, 26)
        Me.Tgl1.TabIndex = 0
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.Tgl2)
        Me.GroupBox2.Controls.Add(Me.Tgl1)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(414, 93)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Size = New System.Drawing.Size(397, 69)
        Me.GroupBox2.TabIndex = 204
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Periode"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(180, 36)
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
        Me.Tgl2.Location = New System.Drawing.Point(232, 31)
        Me.Tgl2.Margin = New System.Windows.Forms.Padding(4)
        Me.Tgl2.Name = "Tgl2"
        Me.Tgl2.Size = New System.Drawing.Size(153, 26)
        Me.Tgl2.TabIndex = 1
        '
        'cbcategory
        '
        Me.cbcategory.BackColor = System.Drawing.Color.White
        Me.cbcategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbcategory.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbcategory.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
        Me.cbcategory.FormattingEnabled = True
        Me.cbcategory.Items.AddRange(New Object() {"All", "By Toko", "OutStanding", "Approved"})
        Me.cbcategory.Location = New System.Drawing.Point(7, 30)
        Me.cbcategory.Name = "cbcategory"
        Me.cbcategory.Size = New System.Drawing.Size(139, 26)
        Me.cbcategory.TabIndex = 210
        '
        'GroupBox4
        '
        Me.GroupBox4.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox4.Controls.Add(Me.cbcategory)
        Me.GroupBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox4.Location = New System.Drawing.Point(815, 97)
        Me.GroupBox4.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox4.Size = New System.Drawing.Size(166, 65)
        Me.GroupBox4.TabIndex = 211
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Filter By"
        '
        'GroupBox5
        '
        Me.GroupBox5.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox5.Controls.Add(Me.BtnFindStore)
        Me.GroupBox5.Controls.Add(Me.TxtNamaToko)
        Me.GroupBox5.Controls.Add(Me.TxtKodeToko)
        Me.GroupBox5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox5.Location = New System.Drawing.Point(985, 97)
        Me.GroupBox5.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox5.Size = New System.Drawing.Size(629, 65)
        Me.GroupBox5.TabIndex = 212
        Me.GroupBox5.TabStop = False
        '
        'BtnFindStore
        '
        Me.BtnFindStore.BackColor = System.Drawing.Color.Transparent
        Me.BtnFindStore.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnFindStore.ForeColor = System.Drawing.Color.Black
        Me.BtnFindStore.Location = New System.Drawing.Point(560, 28)
        Me.BtnFindStore.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnFindStore.Name = "BtnFindStore"
        Me.BtnFindStore.Size = New System.Drawing.Size(51, 26)
        Me.BtnFindStore.TabIndex = 8
        Me.BtnFindStore.Text = "..."
        Me.BtnFindStore.UseVisualStyleBackColor = False
        '
        'TxtNamaToko
        '
        Me.TxtNamaToko.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNamaToko.Location = New System.Drawing.Point(131, 29)
        Me.TxtNamaToko.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtNamaToko.Name = "TxtNamaToko"
        Me.TxtNamaToko.ReadOnly = True
        Me.TxtNamaToko.Size = New System.Drawing.Size(421, 24)
        Me.TxtNamaToko.TabIndex = 7
        '
        'TxtKodeToko
        '
        Me.TxtKodeToko.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtKodeToko.Location = New System.Drawing.Point(7, 29)
        Me.TxtKodeToko.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtKodeToko.Name = "TxtKodeToko"
        Me.TxtKodeToko.ReadOnly = True
        Me.TxtKodeToko.Size = New System.Drawing.Size(115, 24)
        Me.TxtKodeToko.TabIndex = 6
        '
        'frmSumarynonrrak
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(1774, 761)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.RptAnggaranKas)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.BtnProses)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.PictureBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "frmSumarynonrrak"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmSumarynonrrak"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents RbNONRRAK As System.Windows.Forms.RadioButton
    Friend WithEvents RbRRAK As System.Windows.Forms.RadioButton
    Friend WithEvents RptAnggaranKas As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents BtnProses As System.Windows.Forms.Button
    Friend WithEvents Tgl1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Tgl2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents cbostatusrrak As System.Windows.Forms.ComboBox
    Friend WithEvents cbostatusnonrrak As System.Windows.Forms.ComboBox
    Friend WithEvents cbcategory As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents BtnFindStore As System.Windows.Forms.Button
    Friend WithEvents TxtNamaToko As System.Windows.Forms.TextBox
    Friend WithEvents TxtKodeToko As System.Windows.Forms.TextBox
End Class
