<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMstMaxToko
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMstMaxToko))
        Me.CmbFilterBy = New System.Windows.Forms.ComboBox()
        Me.TxtKodeProduk = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.BtnEdit = New System.Windows.Forms.Button()
        Me.RBAll = New System.Windows.Forms.RadioButton()
        Me.BtnSave = New System.Windows.Forms.Button()
        Me.TxtNamaBarang = New System.Windows.Forms.TextBox()
        Me.RBDept = New System.Windows.Forms.RadioButton()
        Me.TxtQty = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TxtNamaToko = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BtnFindToko = New System.Windows.Forms.Button()
        Me.TxtType = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TxtJenisToko = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TxtAlamatToko = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TxtKodeToko = New System.Windows.Forms.TextBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.lblqty = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.BtnCancel = New System.Windows.Forms.Button()
        Me.txtfind = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.BtnPrint = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'CmbFilterBy
        '
        Me.CmbFilterBy.FormattingEnabled = True
        Me.CmbFilterBy.Location = New System.Drawing.Point(955, 43)
        Me.CmbFilterBy.Name = "CmbFilterBy"
        Me.CmbFilterBy.Size = New System.Drawing.Size(254, 21)
        Me.CmbFilterBy.TabIndex = 35
        '
        'TxtKodeProduk
        '
        Me.TxtKodeProduk.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.TxtKodeProduk.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtKodeProduk.Location = New System.Drawing.Point(127, 9)
        Me.TxtKodeProduk.Name = "TxtKodeProduk"
        Me.TxtKodeProduk.ReadOnly = True
        Me.TxtKodeProduk.Size = New System.Drawing.Size(119, 21)
        Me.TxtKodeProduk.TabIndex = 203
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label1.Font = New System.Drawing.Font("Britannic Bold", 20.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(376, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(241, 30)
        Me.Label1.TabIndex = 197
        Me.Label1.Text = "MASTER MAX TOKO"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(884, 45)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(65, 19)
        Me.Label7.TabIndex = 36
        Me.Label7.Text = "Filter By"
        '
        'BtnEdit
        '
        Me.BtnEdit.BackColor = System.Drawing.Color.Transparent
        Me.BtnEdit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Aqua
        Me.BtnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnEdit.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnEdit.ForeColor = System.Drawing.Color.Black
        Me.BtnEdit.Image = CType(resources.GetObject("BtnEdit.Image"), System.Drawing.Image)
        Me.BtnEdit.Location = New System.Drawing.Point(852, 532)
        Me.BtnEdit.Name = "BtnEdit"
        Me.BtnEdit.Size = New System.Drawing.Size(91, 41)
        Me.BtnEdit.TabIndex = 201
        Me.BtnEdit.Text = "&Edit"
        Me.BtnEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnEdit.UseVisualStyleBackColor = False
        '
        'RBAll
        '
        Me.RBAll.AutoSize = True
        Me.RBAll.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RBAll.Location = New System.Drawing.Point(1061, 17)
        Me.RBAll.Name = "RBAll"
        Me.RBAll.Size = New System.Drawing.Size(39, 17)
        Me.RBAll.TabIndex = 34
        Me.RBAll.TabStop = True
        Me.RBAll.Text = "All"
        Me.RBAll.UseVisualStyleBackColor = True
        '
        'BtnSave
        '
        Me.BtnSave.BackColor = System.Drawing.Color.Transparent
        Me.BtnSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Aqua
        Me.BtnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSave.ForeColor = System.Drawing.Color.Black
        Me.BtnSave.Image = CType(resources.GetObject("BtnSave.Image"), System.Drawing.Image)
        Me.BtnSave.Location = New System.Drawing.Point(944, 532)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(91, 41)
        Me.BtnSave.TabIndex = 200
        Me.BtnSave.Text = "&Save"
        Me.BtnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnSave.UseVisualStyleBackColor = False
        '
        'TxtNamaBarang
        '
        Me.TxtNamaBarang.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.TxtNamaBarang.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNamaBarang.Location = New System.Drawing.Point(252, 9)
        Me.TxtNamaBarang.Name = "TxtNamaBarang"
        Me.TxtNamaBarang.ReadOnly = True
        Me.TxtNamaBarang.Size = New System.Drawing.Size(414, 21)
        Me.TxtNamaBarang.TabIndex = 204
        '
        'RBDept
        '
        Me.RBDept.AutoSize = True
        Me.RBDept.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RBDept.Location = New System.Drawing.Point(952, 17)
        Me.RBDept.Name = "RBDept"
        Me.RBDept.Size = New System.Drawing.Size(97, 17)
        Me.RBDept.TabIndex = 33
        Me.RBDept.TabStop = True
        Me.RBDept.Text = "Departement"
        Me.RBDept.UseVisualStyleBackColor = True
        '
        'TxtQty
        '
        Me.TxtQty.BackColor = System.Drawing.SystemColors.Window
        Me.TxtQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtQty.Location = New System.Drawing.Point(716, 11)
        Me.TxtQty.MaxLength = 14
        Me.TxtQty.Name = "TxtQty"
        Me.TxtQty.Size = New System.Drawing.Size(92, 21)
        Me.TxtQty.TabIndex = 206
        Me.TxtQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(7, 9)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(117, 19)
        Me.Label6.TabIndex = 202
        Me.Label6.Text = "NAMA BARANG"
        '
        'ListView1
        '
        Me.ListView1.Location = New System.Drawing.Point(4, 170)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(1222, 354)
        Me.ListView1.TabIndex = 199
        Me.ListView1.UseCompatibleStateImageBehavior = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(914, 15)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(25, 19)
        Me.Label5.TabIndex = 30
        Me.Label5.Text = "BY"
        '
        'TxtNamaToko
        '
        Me.TxtNamaToko.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.TxtNamaToko.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNamaToko.Location = New System.Drawing.Point(243, 3)
        Me.TxtNamaToko.Name = "TxtNamaToko"
        Me.TxtNamaToko.ReadOnly = True
        Me.TxtNamaToko.Size = New System.Drawing.Size(239, 21)
        Me.TxtNamaToko.TabIndex = 29
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.BtnFindToko)
        Me.Panel1.Controls.Add(Me.TxtType)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.TxtJenisToko)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.CmbFilterBy)
        Me.Panel1.Controls.Add(Me.RBAll)
        Me.Panel1.Controls.Add(Me.RBDept)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.TxtNamaToko)
        Me.Panel1.Controls.Add(Me.TxtAlamatToko)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.TxtKodeToko)
        Me.Panel1.Location = New System.Drawing.Point(4, 53)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1222, 84)
        Me.Panel1.TabIndex = 198
        '
        'BtnFindToko
        '
        Me.BtnFindToko.BackColor = System.Drawing.Color.Transparent
        Me.BtnFindToko.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnFindToko.ForeColor = System.Drawing.Color.Black
        Me.BtnFindToko.Location = New System.Drawing.Point(488, 3)
        Me.BtnFindToko.Name = "BtnFindToko"
        Me.BtnFindToko.Size = New System.Drawing.Size(38, 21)
        Me.BtnFindToko.TabIndex = 41
        Me.BtnFindToko.Text = "..."
        Me.BtnFindToko.UseVisualStyleBackColor = False
        '
        'TxtType
        '
        Me.TxtType.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.TxtType.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtType.Location = New System.Drawing.Point(322, 55)
        Me.TxtType.Name = "TxtType"
        Me.TxtType.ReadOnly = True
        Me.TxtType.Size = New System.Drawing.Size(104, 21)
        Me.TxtType.TabIndex = 40
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(275, 55)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(42, 19)
        Me.Label8.TabIndex = 39
        Me.Label8.Text = "TYPE"
        '
        'TxtJenisToko
        '
        Me.TxtJenisToko.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.TxtJenisToko.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtJenisToko.Location = New System.Drawing.Point(133, 55)
        Me.TxtJenisToko.Name = "TxtJenisToko"
        Me.TxtJenisToko.ReadOnly = True
        Me.TxtJenisToko.Size = New System.Drawing.Size(104, 21)
        Me.TxtJenisToko.TabIndex = 38
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(6, 58)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(87, 19)
        Me.Label2.TabIndex = 37
        Me.Label2.Text = "JENIS TOKO"
        '
        'TxtAlamatToko
        '
        Me.TxtAlamatToko.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.TxtAlamatToko.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtAlamatToko.Location = New System.Drawing.Point(133, 29)
        Me.TxtAlamatToko.Name = "TxtAlamatToko"
        Me.TxtAlamatToko.ReadOnly = True
        Me.TxtAlamatToko.Size = New System.Drawing.Size(393, 21)
        Me.TxtAlamatToko.TabIndex = 22
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(5, 32)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(109, 19)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "ALAMAT TOKO"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(5, 5)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(88, 19)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "KODE TOKO"
        '
        'TxtKodeToko
        '
        Me.TxtKodeToko.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.TxtKodeToko.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtKodeToko.Location = New System.Drawing.Point(133, 3)
        Me.TxtKodeToko.Name = "TxtKodeToko"
        Me.TxtKodeToko.ReadOnly = True
        Me.TxtKodeToko.Size = New System.Drawing.Size(104, 21)
        Me.TxtKodeToko.TabIndex = 10
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(1226, 50)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 196
        Me.PictureBox1.TabStop = False
        '
        'lblqty
        '
        Me.lblqty.AutoSize = True
        Me.lblqty.BackColor = System.Drawing.Color.Transparent
        Me.lblqty.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblqty.ForeColor = System.Drawing.Color.Black
        Me.lblqty.Location = New System.Drawing.Point(672, 11)
        Me.lblqty.Name = "lblqty"
        Me.lblqty.Size = New System.Drawing.Size(36, 19)
        Me.lblqty.TabIndex = 205
        Me.lblqty.Text = "QTY"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Transparent
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel2.Controls.Add(Me.TxtQty)
        Me.Panel2.Controls.Add(Me.TxtKodeProduk)
        Me.Panel2.Controls.Add(Me.lblqty)
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Controls.Add(Me.TxtNamaBarang)
        Me.Panel2.Location = New System.Drawing.Point(4, 530)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(826, 44)
        Me.Panel2.TabIndex = 207
        '
        'BtnCancel
        '
        Me.BtnCancel.BackColor = System.Drawing.Color.Transparent
        Me.BtnCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Aqua
        Me.BtnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCancel.ForeColor = System.Drawing.Color.Black
        Me.BtnCancel.Image = CType(resources.GetObject("BtnCancel.Image"), System.Drawing.Image)
        Me.BtnCancel.Location = New System.Drawing.Point(1036, 532)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(91, 41)
        Me.BtnCancel.TabIndex = 208
        Me.BtnCancel.Text = "&Cancel"
        Me.BtnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnCancel.UseVisualStyleBackColor = False
        '
        'txtfind
        '
        Me.txtfind.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.txtfind.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtfind.Location = New System.Drawing.Point(68, 143)
        Me.txtfind.Name = "txtfind"
        Me.txtfind.Size = New System.Drawing.Size(464, 21)
        Me.txtfind.TabIndex = 210
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(11, 144)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(41, 19)
        Me.Label9.TabIndex = 209
        Me.Label9.Text = "FIND"
        '
        'BtnPrint
        '
        Me.BtnPrint.BackColor = System.Drawing.Color.Transparent
        Me.BtnPrint.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Aqua
        Me.BtnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnPrint.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnPrint.ForeColor = System.Drawing.Color.Black
        Me.BtnPrint.Location = New System.Drawing.Point(1128, 532)
        Me.BtnPrint.Name = "BtnPrint"
        Me.BtnPrint.Size = New System.Drawing.Size(91, 41)
        Me.BtnPrint.TabIndex = 211
        Me.BtnPrint.Text = "&Print"
        Me.BtnPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnPrint.UseVisualStyleBackColor = False
        '
        'FrmMstMaxToko
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1226, 579)
        Me.Controls.Add(Me.BtnPrint)
        Me.Controls.Add(Me.txtfind)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.BtnCancel)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.BtnEdit)
        Me.Controls.Add(Me.BtnSave)
        Me.Controls.Add(Me.ListView1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Panel2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.Name = "FrmMstMaxToko"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmMstMaxToko"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CmbFilterBy As System.Windows.Forms.ComboBox
    Friend WithEvents TxtKodeProduk As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents BtnEdit As System.Windows.Forms.Button
    Friend WithEvents RBAll As System.Windows.Forms.RadioButton
    Friend WithEvents BtnSave As System.Windows.Forms.Button
    Friend WithEvents TxtNamaBarang As System.Windows.Forms.TextBox
    Friend WithEvents RBDept As System.Windows.Forms.RadioButton
    Friend WithEvents TxtQty As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TxtNamaToko As System.Windows.Forms.TextBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents TxtAlamatToko As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxtKodeToko As System.Windows.Forms.TextBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents lblqty As System.Windows.Forms.Label
    Friend WithEvents TxtType As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TxtJenisToko As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents BtnFindToko As System.Windows.Forms.Button
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents BtnCancel As System.Windows.Forms.Button
    Friend WithEvents txtfind As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents BtnPrint As System.Windows.Forms.Button
End Class
