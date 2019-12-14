<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRptTIToko
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmRptTIToko))
        Me.RptTiToko = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.BtnFindStore = New System.Windows.Forms.Button()
        Me.TxtNamaToko = New System.Windows.Forms.TextBox()
        Me.TxtKodeToko = New System.Windows.Forms.TextBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.cmbFilter = New System.Windows.Forms.ComboBox()
        Me.BtnProses = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Tgl2 = New System.Windows.Forms.DateTimePicker()
        Me.Tgl1 = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'RptTiToko
        '
        Me.RptTiToko.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RptTiToko.Location = New System.Drawing.Point(0, 124)
        Me.RptTiToko.Margin = New System.Windows.Forms.Padding(4)
        Me.RptTiToko.Name = "RptTiToko"
        Me.RptTiToko.Size = New System.Drawing.Size(1740, 606)
        Me.RptTiToko.TabIndex = 212
        '
        'GroupBox4
        '
        Me.GroupBox4.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox4.Controls.Add(Me.BtnFindStore)
        Me.GroupBox4.Controls.Add(Me.TxtNamaToko)
        Me.GroupBox4.Controls.Add(Me.TxtKodeToko)
        Me.GroupBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox4.Location = New System.Drawing.Point(643, 55)
        Me.GroupBox4.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox4.Size = New System.Drawing.Size(599, 62)
        Me.GroupBox4.TabIndex = 211
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
        'TxtNamaToko
        '
        Me.TxtNamaToko.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNamaToko.Location = New System.Drawing.Point(129, 22)
        Me.TxtNamaToko.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtNamaToko.Name = "TxtNamaToko"
        Me.TxtNamaToko.Size = New System.Drawing.Size(396, 24)
        Me.TxtNamaToko.TabIndex = 7
        '
        'TxtKodeToko
        '
        Me.TxtKodeToko.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtKodeToko.Location = New System.Drawing.Point(5, 22)
        Me.TxtKodeToko.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtKodeToko.Name = "TxtKodeToko"
        Me.TxtKodeToko.Size = New System.Drawing.Size(115, 24)
        Me.TxtKodeToko.TabIndex = 6
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox3.Controls.Add(Me.cmbFilter)
        Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(429, 55)
        Me.GroupBox3.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox3.Size = New System.Drawing.Size(204, 62)
        Me.GroupBox3.TabIndex = 210
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
        Me.BtnProses.Location = New System.Drawing.Point(1251, 63)
        Me.BtnProses.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnProses.Name = "BtnProses"
        Me.BtnProses.Size = New System.Drawing.Size(153, 53)
        Me.BtnProses.TabIndex = 209
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
        Me.GroupBox2.Location = New System.Drawing.Point(24, 55)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Size = New System.Drawing.Size(397, 62)
        Me.GroupBox2.TabIndex = 208
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Periode"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(172, 32)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(34, 17)
        Me.Label2.TabIndex = 177
        Me.Label2.Text = "S.D"
        '
        'Tgl2
        '
        Me.Tgl2.CustomFormat = "dd-MM-yyyy"
        Me.Tgl2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Tgl2.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.Tgl2.Location = New System.Drawing.Point(213, 25)
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
        Me.Label1.Location = New System.Drawing.Point(16, 11)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(266, 39)
        Me.Label1.TabIndex = 207
        Me.Label1.Text = "Transfer In Toko"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(1740, 124)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 206
        Me.PictureBox1.TabStop = False
        '
        'FrmRptTIToko
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1740, 730)
        Me.Controls.Add(Me.RptTiToko)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.BtnProses)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Name = "FrmRptTIToko"
        Me.Text = "FrmPrintTIToko"
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents RptTiToko As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents BtnFindStore As System.Windows.Forms.Button
    Friend WithEvents TxtNamaToko As System.Windows.Forms.TextBox
    Friend WithEvents TxtKodeToko As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents cmbFilter As System.Windows.Forms.ComboBox
    Friend WithEvents BtnProses As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Tgl2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Tgl1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
End Class
