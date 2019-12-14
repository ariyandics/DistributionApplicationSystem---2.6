<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPOManual
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.cbpartial = New System.Windows.Forms.CheckBox()
        Me.txtketerangan = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.TxtExtTime = New System.Windows.Forms.TextBox()
        Me.btnFindNoPO = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TxtPKP = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TglProses = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TglExpired = New System.Windows.Forms.DateTimePicker()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TglPO = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.BtnFindSupplier = New System.Windows.Forms.Button()
        Me.TxtNoFaktur = New System.Windows.Forms.TextBox()
        Me.LblTanggal = New System.Windows.Forms.Label()
        Me.TxtNamaSupplier = New System.Windows.Forms.TextBox()
        Me.TxtKodeSupplier = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ListView2 = New System.Windows.Forms.ListView()
        Me.BtnApproval = New System.Windows.Forms.Button()
        Me.BtnEdit = New System.Windows.Forms.Button()
        Me.BtnSimpan = New System.Windows.Forms.Button()
        Me.BtnPrint = New System.Windows.Forms.Button()
        Me.BtnAdd = New System.Windows.Forms.Button()
        Me.BtnCancel = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.txtqty = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtPrice = New System.Windows.Forms.TextBox()
        Me.BtnFindProduk = New System.Windows.Forms.Button()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtNamaProduk = New System.Windows.Forms.TextBox()
        Me.txtKodeProduk = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txttotal = New System.Windows.Forms.TextBox()
        Me.lbltotal = New System.Windows.Forms.Label()
        Me.txtIncPPN = New System.Windows.Forms.TextBox()
        Me.lblincppn = New System.Windows.Forms.Label()
        Me.txtppn = New System.Windows.Forms.TextBox()
        Me.labelppn = New System.Windows.Forms.Label()
        Me.txthargadiscount = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtdiscount = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtharga = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.btnUpdHarga = New System.Windows.Forms.Button()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label1.Font = New System.Drawing.Font("Britannic Bold", 20.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(221, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(361, 30)
        Me.Label1.TabIndex = 102
        Me.Label1.Text = "PURCHASE ORDER ( Manual )"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(1096, 49)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 101
        Me.PictureBox1.TabStop = False
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.cbpartial)
        Me.Panel1.Controls.Add(Me.txtketerangan)
        Me.Panel1.Controls.Add(Me.Label16)
        Me.Panel1.Controls.Add(Me.Label15)
        Me.Panel1.Controls.Add(Me.TxtExtTime)
        Me.Panel1.Controls.Add(Me.btnFindNoPO)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.TxtPKP)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.TglProses)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.TglExpired)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.TglPO)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.BtnFindSupplier)
        Me.Panel1.Controls.Add(Me.TxtNoFaktur)
        Me.Panel1.Controls.Add(Me.LblTanggal)
        Me.Panel1.Controls.Add(Me.TxtNamaSupplier)
        Me.Panel1.Controls.Add(Me.TxtKodeSupplier)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Location = New System.Drawing.Point(0, 50)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1279, 115)
        Me.Panel1.TabIndex = 103
        '
        'cbpartial
        '
        Me.cbpartial.AutoSize = True
        Me.cbpartial.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbpartial.Location = New System.Drawing.Point(288, 85)
        Me.cbpartial.Name = "cbpartial"
        Me.cbpartial.Size = New System.Drawing.Size(96, 23)
        Me.cbpartial.TabIndex = 28
        Me.cbpartial.Text = "Partial PO"
        Me.cbpartial.UseVisualStyleBackColor = True
        '
        'txtketerangan
        '
        Me.txtketerangan.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtketerangan.Location = New System.Drawing.Point(127, 58)
        Me.txtketerangan.MaxLength = 50
        Me.txtketerangan.Name = "txtketerangan"
        Me.txtketerangan.Size = New System.Drawing.Size(403, 20)
        Me.txtketerangan.TabIndex = 27
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(2, 57)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(103, 19)
        Me.Label16.TabIndex = 26
        Me.Label16.Text = "KETERANGAN"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(199, 86)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(42, 19)
        Me.Label15.TabIndex = 25
        Me.Label15.Text = "HARI"
        '
        'TxtExtTime
        '
        Me.TxtExtTime.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtExtTime.Location = New System.Drawing.Point(127, 85)
        Me.TxtExtTime.Name = "TxtExtTime"
        Me.TxtExtTime.Size = New System.Drawing.Size(68, 21)
        Me.TxtExtTime.TabIndex = 24
        '
        'btnFindNoPO
        '
        Me.btnFindNoPO.BackColor = System.Drawing.Color.Transparent
        Me.btnFindNoPO.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Cyan
        Me.btnFindNoPO.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFindNoPO.ForeColor = System.Drawing.Color.Black
        Me.btnFindNoPO.Location = New System.Drawing.Point(287, 5)
        Me.btnFindNoPO.Name = "btnFindNoPO"
        Me.btnFindNoPO.Size = New System.Drawing.Size(38, 21)
        Me.btnFindNoPO.TabIndex = 23
        Me.btnFindNoPO.Text = "..."
        Me.btnFindNoPO.UseVisualStyleBackColor = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(4, 85)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(72, 19)
        Me.Label8.TabIndex = 21
        Me.Label8.Text = "EXT TIME"
        '
        'TxtPKP
        '
        Me.TxtPKP.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtPKP.Location = New System.Drawing.Point(874, 82)
        Me.TxtPKP.Name = "TxtPKP"
        Me.TxtPKP.Size = New System.Drawing.Size(68, 21)
        Me.TxtPKP.TabIndex = 20
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(774, 82)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(85, 19)
        Me.Label7.TabIndex = 19
        Me.Label7.Text = "PKP /NPKP"
        '
        'TglProses
        '
        Me.TglProses.CustomFormat = "dd-MM-yyyy , HH:mm:ss"
        Me.TglProses.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.TglProses.Location = New System.Drawing.Point(874, 56)
        Me.TglProses.Name = "TglProses"
        Me.TglProses.Size = New System.Drawing.Size(211, 20)
        Me.TglProses.TabIndex = 15
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(774, 58)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(91, 19)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "TGL PROSES"
        '
        'TglExpired
        '
        Me.TglExpired.CustomFormat = "dd-MM-yyyy"
        Me.TglExpired.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.TglExpired.Location = New System.Drawing.Point(874, 5)
        Me.TglExpired.Name = "TglExpired"
        Me.TglExpired.Size = New System.Drawing.Size(211, 20)
        Me.TglExpired.TabIndex = 13
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(774, 7)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(95, 19)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "TGL EXPIRED"
        '
        'TglPO
        '
        Me.TglPO.CustomFormat = "dd-MM-yyyy"
        Me.TglPO.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.TglPO.Location = New System.Drawing.Point(874, 31)
        Me.TglPO.Name = "TglPO"
        Me.TglPO.Size = New System.Drawing.Size(211, 20)
        Me.TglPO.TabIndex = 11
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(774, 33)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(58, 19)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "TGL PO"
        '
        'BtnFindSupplier
        '
        Me.BtnFindSupplier.BackColor = System.Drawing.Color.Transparent
        Me.BtnFindSupplier.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Cyan
        Me.BtnFindSupplier.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnFindSupplier.ForeColor = System.Drawing.Color.Black
        Me.BtnFindSupplier.Location = New System.Drawing.Point(492, 31)
        Me.BtnFindSupplier.Name = "BtnFindSupplier"
        Me.BtnFindSupplier.Size = New System.Drawing.Size(38, 21)
        Me.BtnFindSupplier.TabIndex = 5
        Me.BtnFindSupplier.Text = "..."
        Me.BtnFindSupplier.UseVisualStyleBackColor = False
        '
        'TxtNoFaktur
        '
        Me.TxtNoFaktur.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNoFaktur.Location = New System.Drawing.Point(127, 5)
        Me.TxtNoFaktur.Name = "TxtNoFaktur"
        Me.TxtNoFaktur.Size = New System.Drawing.Size(154, 20)
        Me.TxtNoFaktur.TabIndex = 4
        '
        'LblTanggal
        '
        Me.LblTanggal.AutoSize = True
        Me.LblTanggal.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTanggal.Location = New System.Drawing.Point(2, 5)
        Me.LblTanggal.Name = "LblTanggal"
        Me.LblTanggal.Size = New System.Drawing.Size(55, 19)
        Me.LblTanggal.TabIndex = 3
        Me.LblTanggal.Text = "NO PO"
        '
        'TxtNamaSupplier
        '
        Me.TxtNamaSupplier.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNamaSupplier.Location = New System.Drawing.Point(201, 31)
        Me.TxtNamaSupplier.Name = "TxtNamaSupplier"
        Me.TxtNamaSupplier.Size = New System.Drawing.Size(285, 21)
        Me.TxtNamaSupplier.TabIndex = 2
        '
        'TxtKodeSupplier
        '
        Me.TxtKodeSupplier.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtKodeSupplier.Location = New System.Drawing.Point(127, 31)
        Me.TxtKodeSupplier.Name = "TxtKodeSupplier"
        Me.TxtKodeSupplier.Size = New System.Drawing.Size(68, 21)
        Me.TxtKodeSupplier.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(2, 31)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(122, 19)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "NAMA SUPPLIER"
        '
        'ListView2
        '
        Me.ListView2.Location = New System.Drawing.Point(0, 171)
        Me.ListView2.Name = "ListView2"
        Me.ListView2.Size = New System.Drawing.Size(1095, 329)
        Me.ListView2.TabIndex = 104
        Me.ListView2.UseCompatibleStateImageBehavior = False
        '
        'BtnApproval
        '
        Me.BtnApproval.BackColor = System.Drawing.Color.Transparent
        Me.BtnApproval.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Cyan
        Me.BtnApproval.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnApproval.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnApproval.ForeColor = System.Drawing.Color.Black
        Me.BtnApproval.Location = New System.Drawing.Point(417, 594)
        Me.BtnApproval.Name = "BtnApproval"
        Me.BtnApproval.Size = New System.Drawing.Size(102, 41)
        Me.BtnApproval.TabIndex = 128
        Me.BtnApproval.Text = "Appr&oval"
        Me.BtnApproval.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnApproval.UseVisualStyleBackColor = False
        '
        'BtnEdit
        '
        Me.BtnEdit.BackColor = System.Drawing.Color.Transparent
        Me.BtnEdit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Cyan
        Me.BtnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnEdit.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnEdit.ForeColor = System.Drawing.Color.Black
        Me.BtnEdit.Location = New System.Drawing.Point(108, 594)
        Me.BtnEdit.Name = "BtnEdit"
        Me.BtnEdit.Size = New System.Drawing.Size(102, 41)
        Me.BtnEdit.TabIndex = 127
        Me.BtnEdit.Text = "&Edit"
        Me.BtnEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnEdit.UseVisualStyleBackColor = False
        '
        'BtnSimpan
        '
        Me.BtnSimpan.BackColor = System.Drawing.Color.Transparent
        Me.BtnSimpan.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Cyan
        Me.BtnSimpan.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnSimpan.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSimpan.ForeColor = System.Drawing.Color.Black
        Me.BtnSimpan.Location = New System.Drawing.Point(211, 594)
        Me.BtnSimpan.Name = "BtnSimpan"
        Me.BtnSimpan.Size = New System.Drawing.Size(102, 41)
        Me.BtnSimpan.TabIndex = 126
        Me.BtnSimpan.Text = "&Save"
        Me.BtnSimpan.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnSimpan.UseVisualStyleBackColor = False
        '
        'BtnPrint
        '
        Me.BtnPrint.BackColor = System.Drawing.Color.Transparent
        Me.BtnPrint.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Cyan
        Me.BtnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnPrint.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnPrint.ForeColor = System.Drawing.Color.Black
        Me.BtnPrint.Location = New System.Drawing.Point(520, 594)
        Me.BtnPrint.Name = "BtnPrint"
        Me.BtnPrint.Size = New System.Drawing.Size(102, 41)
        Me.BtnPrint.TabIndex = 125
        Me.BtnPrint.Text = "&Print"
        Me.BtnPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnPrint.UseVisualStyleBackColor = False
        '
        'BtnAdd
        '
        Me.BtnAdd.BackColor = System.Drawing.Color.Transparent
        Me.BtnAdd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Cyan
        Me.BtnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnAdd.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnAdd.ForeColor = System.Drawing.Color.Black
        Me.BtnAdd.Location = New System.Drawing.Point(5, 594)
        Me.BtnAdd.Name = "BtnAdd"
        Me.BtnAdd.Size = New System.Drawing.Size(102, 41)
        Me.BtnAdd.TabIndex = 129
        Me.BtnAdd.Text = "&Add"
        Me.BtnAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnAdd.UseVisualStyleBackColor = False
        '
        'BtnCancel
        '
        Me.BtnCancel.BackColor = System.Drawing.Color.Transparent
        Me.BtnCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Cyan
        Me.BtnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCancel.ForeColor = System.Drawing.Color.Black
        Me.BtnCancel.Location = New System.Drawing.Point(314, 594)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(102, 41)
        Me.BtnCancel.TabIndex = 130
        Me.BtnCancel.Text = "&Cancel"
        Me.BtnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnCancel.UseVisualStyleBackColor = False
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel2.Controls.Add(Me.txtqty)
        Me.Panel2.Controls.Add(Me.Label14)
        Me.Panel2.Controls.Add(Me.txtPrice)
        Me.Panel2.Controls.Add(Me.BtnFindProduk)
        Me.Panel2.Controls.Add(Me.Label13)
        Me.Panel2.Controls.Add(Me.txtNamaProduk)
        Me.Panel2.Controls.Add(Me.txtKodeProduk)
        Me.Panel2.Controls.Add(Me.Label12)
        Me.Panel2.Location = New System.Drawing.Point(5, 505)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(719, 83)
        Me.Panel2.TabIndex = 131
        '
        'txtqty
        '
        Me.txtqty.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtqty.Location = New System.Drawing.Point(602, 40)
        Me.txtqty.MaxLength = 22
        Me.txtqty.Name = "txtqty"
        Me.txtqty.Size = New System.Drawing.Size(102, 21)
        Me.txtqty.TabIndex = 13
        Me.txtqty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(598, 17)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(60, 19)
        Me.Label14.TabIndex = 12
        Me.Label14.Text = "QTY PO"
        '
        'txtPrice
        '
        Me.txtPrice.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPrice.Location = New System.Drawing.Point(491, 40)
        Me.txtPrice.Name = "txtPrice"
        Me.txtPrice.Size = New System.Drawing.Size(102, 21)
        Me.txtPrice.TabIndex = 11
        Me.txtPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'BtnFindProduk
        '
        Me.BtnFindProduk.BackColor = System.Drawing.Color.Transparent
        Me.BtnFindProduk.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnFindProduk.ForeColor = System.Drawing.Color.Black
        Me.BtnFindProduk.Location = New System.Drawing.Point(432, 40)
        Me.BtnFindProduk.Name = "BtnFindProduk"
        Me.BtnFindProduk.Size = New System.Drawing.Size(38, 21)
        Me.BtnFindProduk.TabIndex = 9
        Me.BtnFindProduk.Text = "..."
        Me.BtnFindProduk.UseVisualStyleBackColor = False
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(487, 17)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(58, 19)
        Me.Label13.TabIndex = 10
        Me.Label13.Text = "HARGA"
        '
        'txtNamaProduk
        '
        Me.txtNamaProduk.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNamaProduk.Location = New System.Drawing.Point(121, 40)
        Me.txtNamaProduk.Name = "txtNamaProduk"
        Me.txtNamaProduk.Size = New System.Drawing.Size(305, 21)
        Me.txtNamaProduk.TabIndex = 8
        '
        'txtKodeProduk
        '
        Me.txtKodeProduk.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtKodeProduk.Location = New System.Drawing.Point(7, 40)
        Me.txtKodeProduk.Name = "txtKodeProduk"
        Me.txtKodeProduk.Size = New System.Drawing.Size(108, 21)
        Me.txtKodeProduk.TabIndex = 7
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(4, 17)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(116, 19)
        Me.Label12.TabIndex = 6
        Me.Label12.Text = "NAMA PRODUK"
        '
        'txttotal
        '
        Me.txttotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txttotal.Location = New System.Drawing.Point(930, 618)
        Me.txttotal.Name = "txttotal"
        Me.txttotal.Size = New System.Drawing.Size(160, 20)
        Me.txttotal.TabIndex = 143
        Me.txttotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lbltotal
        '
        Me.lbltotal.AutoSize = True
        Me.lbltotal.BackColor = System.Drawing.Color.Transparent
        Me.lbltotal.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltotal.Location = New System.Drawing.Point(737, 620)
        Me.lbltotal.Name = "lbltotal"
        Me.lbltotal.Size = New System.Drawing.Size(176, 19)
        Me.lbltotal.TabIndex = 142
        Me.lbltotal.Text = "TOTAL FAKTUR SUPPLIER"
        '
        'txtIncPPN
        '
        Me.txtIncPPN.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIncPPN.Location = New System.Drawing.Point(930, 595)
        Me.txtIncPPN.Name = "txtIncPPN"
        Me.txtIncPPN.Size = New System.Drawing.Size(160, 20)
        Me.txtIncPPN.TabIndex = 141
        Me.txtIncPPN.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblincppn
        '
        Me.lblincppn.AutoSize = True
        Me.lblincppn.BackColor = System.Drawing.Color.Transparent
        Me.lblincppn.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblincppn.Location = New System.Drawing.Point(737, 597)
        Me.lblincppn.Name = "lblincppn"
        Me.lblincppn.Size = New System.Drawing.Size(112, 19)
        Me.lblincppn.TabIndex = 140
        Me.lblincppn.Text = "TOTAL INC PPN"
        '
        'txtppn
        '
        Me.txtppn.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtppn.Location = New System.Drawing.Point(930, 572)
        Me.txtppn.Name = "txtppn"
        Me.txtppn.Size = New System.Drawing.Size(160, 20)
        Me.txtppn.TabIndex = 139
        Me.txtppn.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'labelppn
        '
        Me.labelppn.AutoSize = True
        Me.labelppn.BackColor = System.Drawing.Color.Transparent
        Me.labelppn.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labelppn.Location = New System.Drawing.Point(737, 574)
        Me.labelppn.Name = "labelppn"
        Me.labelppn.Size = New System.Drawing.Size(57, 19)
        Me.labelppn.TabIndex = 138
        Me.labelppn.Text = "PPN IN"
        '
        'txthargadiscount
        '
        Me.txthargadiscount.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txthargadiscount.Location = New System.Drawing.Point(930, 549)
        Me.txthargadiscount.Name = "txthargadiscount"
        Me.txthargadiscount.Size = New System.Drawing.Size(160, 20)
        Me.txthargadiscount.TabIndex = 137
        Me.txthargadiscount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(737, 551)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(169, 19)
        Me.Label9.TabIndex = 136
        Me.Label9.Text = "TTL SETELAH DISCOUNT"
        '
        'txtdiscount
        '
        Me.txtdiscount.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtdiscount.Location = New System.Drawing.Point(930, 526)
        Me.txtdiscount.Name = "txtdiscount"
        Me.txtdiscount.Size = New System.Drawing.Size(160, 20)
        Me.txtdiscount.TabIndex = 135
        Me.txtdiscount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(737, 528)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(126, 19)
        Me.Label10.TabIndex = 134
        Me.Label10.Text = "TOTAL DISCOUNT"
        '
        'txtharga
        '
        Me.txtharga.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtharga.Location = New System.Drawing.Point(930, 503)
        Me.txtharga.Name = "txtharga"
        Me.txtharga.Size = New System.Drawing.Size(160, 20)
        Me.txtharga.TabIndex = 133
        Me.txtharga.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(737, 505)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(189, 19)
        Me.Label11.TabIndex = 132
        Me.Label11.Text = "TOTAL HARGA PEMBELIAN"
        '
        'btnUpdHarga
        '
        Me.btnUpdHarga.BackColor = System.Drawing.Color.Transparent
        Me.btnUpdHarga.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Cyan
        Me.btnUpdHarga.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnUpdHarga.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUpdHarga.ForeColor = System.Drawing.Color.Black
        Me.btnUpdHarga.Location = New System.Drawing.Point(623, 594)
        Me.btnUpdHarga.Name = "btnUpdHarga"
        Me.btnUpdHarga.Size = New System.Drawing.Size(102, 41)
        Me.btnUpdHarga.TabIndex = 144
        Me.btnUpdHarga.Text = "Cop&y PO"
        Me.btnUpdHarga.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnUpdHarga.UseVisualStyleBackColor = False
        '
        'FrmPOManual
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1096, 645)
        Me.Controls.Add(Me.btnUpdHarga)
        Me.Controls.Add(Me.txttotal)
        Me.Controls.Add(Me.lbltotal)
        Me.Controls.Add(Me.txtIncPPN)
        Me.Controls.Add(Me.lblincppn)
        Me.Controls.Add(Me.txtppn)
        Me.Controls.Add(Me.labelppn)
        Me.Controls.Add(Me.txthargadiscount)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtdiscount)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.txtharga)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.BtnCancel)
        Me.Controls.Add(Me.BtnAdd)
        Me.Controls.Add(Me.BtnApproval)
        Me.Controls.Add(Me.BtnEdit)
        Me.Controls.Add(Me.BtnSimpan)
        Me.Controls.Add(Me.BtnPrint)
        Me.Controls.Add(Me.ListView2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PictureBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.Name = "FrmPOManual"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmPOManual"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TglExpired As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TglPO As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents BtnFindSupplier As System.Windows.Forms.Button
    Friend WithEvents TxtNoFaktur As System.Windows.Forms.TextBox
    Friend WithEvents LblTanggal As System.Windows.Forms.Label
    Friend WithEvents TxtNamaSupplier As System.Windows.Forms.TextBox
    Friend WithEvents TxtKodeSupplier As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TxtPKP As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents ListView2 As System.Windows.Forms.ListView
    Friend WithEvents BtnApproval As System.Windows.Forms.Button
    Friend WithEvents BtnEdit As System.Windows.Forms.Button
    Friend WithEvents BtnSimpan As System.Windows.Forms.Button
    Friend WithEvents BtnPrint As System.Windows.Forms.Button
    Friend WithEvents BtnAdd As System.Windows.Forms.Button
    Friend WithEvents BtnCancel As System.Windows.Forms.Button
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents txtPrice As System.Windows.Forms.TextBox
    Friend WithEvents BtnFindProduk As System.Windows.Forms.Button
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtNamaProduk As System.Windows.Forms.TextBox
    Friend WithEvents txtKodeProduk As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txttotal As System.Windows.Forms.TextBox
    Friend WithEvents lbltotal As System.Windows.Forms.Label
    Friend WithEvents txtIncPPN As System.Windows.Forms.TextBox
    Friend WithEvents lblincppn As System.Windows.Forms.Label
    Friend WithEvents txtppn As System.Windows.Forms.TextBox
    Friend WithEvents labelppn As System.Windows.Forms.Label
    Friend WithEvents txthargadiscount As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtdiscount As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtharga As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtqty As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents btnFindNoPO As System.Windows.Forms.Button
    Friend WithEvents TglProses As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnUpdHarga As System.Windows.Forms.Button
    Friend WithEvents TxtExtTime As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtketerangan As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents cbpartial As System.Windows.Forms.CheckBox
End Class
