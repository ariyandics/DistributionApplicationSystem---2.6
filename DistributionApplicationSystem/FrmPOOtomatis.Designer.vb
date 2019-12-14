<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPOOtomatis
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
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.cbpartial = New System.Windows.Forms.CheckBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.TxtExtTime = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.DtKirim = New System.Windows.Forms.DateTimePicker()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtTglProses = New System.Windows.Forms.TextBox()
        Me.txtTglPO = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TglExpired = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.BtnFindNoUPO = New System.Windows.Forms.Button()
        Me.TxtNoUPO = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.BtnFindSupplier = New System.Windows.Forms.Button()
        Me.TxtNoFaktur = New System.Windows.Forms.TextBox()
        Me.LblTanggal = New System.Windows.Forms.Label()
        Me.TxtNamaSupplier = New System.Windows.Forms.TextBox()
        Me.TxtKodeSupplier = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.listview2 = New System.Windows.Forms.ListView()
        Me.txtharga = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtdiscount = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txthargadiscount = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtppn = New System.Windows.Forms.TextBox()
        Me.labelppn = New System.Windows.Forms.Label()
        Me.txtIncPPN = New System.Windows.Forms.TextBox()
        Me.lblincppn = New System.Windows.Forms.Label()
        Me.txttotal = New System.Windows.Forms.TextBox()
        Me.lbltotal = New System.Windows.Forms.Label()
        Me.BtnSave = New System.Windows.Forms.Button()
        Me.BtnPrint = New System.Windows.Forms.Button()
        Me.btnedit = New System.Windows.Forms.Button()
        Me.BtnApproval = New System.Windows.Forms.Button()
        Me.BtnCancel = New System.Windows.Forms.Button()
        Me.btnUpdHarga = New System.Windows.Forms.Button()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(1099, 49)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 99
        Me.PictureBox1.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label1.Font = New System.Drawing.Font("Britannic Bold", 20.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(286, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(384, 30)
        Me.Label1.TabIndex = 100
        Me.Label1.Text = "PURCHASE ORDER ( Otomatis )"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.cbpartial)
        Me.Panel1.Controls.Add(Me.Label12)
        Me.Panel1.Controls.Add(Me.TxtExtTime)
        Me.Panel1.Controls.Add(Me.Label11)
        Me.Panel1.Controls.Add(Me.DtKirim)
        Me.Panel1.Controls.Add(Me.Label10)
        Me.Panel1.Controls.Add(Me.txtTglProses)
        Me.Panel1.Controls.Add(Me.txtTglPO)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.TglExpired)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.BtnFindNoUPO)
        Me.Panel1.Controls.Add(Me.TxtNoUPO)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.BtnFindSupplier)
        Me.Panel1.Controls.Add(Me.TxtNoFaktur)
        Me.Panel1.Controls.Add(Me.LblTanggal)
        Me.Panel1.Controls.Add(Me.TxtNamaSupplier)
        Me.Panel1.Controls.Add(Me.TxtKodeSupplier)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Location = New System.Drawing.Point(1, 51)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1098, 114)
        Me.Panel1.TabIndex = 101
        '
        'cbpartial
        '
        Me.cbpartial.AutoSize = True
        Me.cbpartial.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbpartial.Location = New System.Drawing.Point(299, 82)
        Me.cbpartial.Name = "cbpartial"
        Me.cbpartial.Size = New System.Drawing.Size(96, 23)
        Me.cbpartial.TabIndex = 22
        Me.cbpartial.Text = "Partial PO"
        Me.cbpartial.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(206, 84)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(42, 19)
        Me.Label12.TabIndex = 21
        Me.Label12.Text = "HARI"
        '
        'TxtExtTime
        '
        Me.TxtExtTime.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtExtTime.Location = New System.Drawing.Point(127, 82)
        Me.TxtExtTime.Name = "TxtExtTime"
        Me.TxtExtTime.Size = New System.Drawing.Size(68, 20)
        Me.TxtExtTime.TabIndex = 20
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(2, 82)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(68, 19)
        Me.Label11.TabIndex = 19
        Me.Label11.Text = "EXT. DAY"
        '
        'DtKirim
        '
        Me.DtKirim.CustomFormat = "dd-MM-yyyy"
        Me.DtKirim.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtKirim.Location = New System.Drawing.Point(874, 34)
        Me.DtKirim.Name = "DtKirim"
        Me.DtKirim.Size = New System.Drawing.Size(210, 20)
        Me.DtKirim.TabIndex = 18
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(774, 35)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(78, 19)
        Me.Label10.TabIndex = 17
        Me.Label10.Text = "TGL KIRIM"
        '
        'txtTglProses
        '
        Me.txtTglProses.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTglProses.Location = New System.Drawing.Point(874, 82)
        Me.txtTglProses.Name = "txtTglProses"
        Me.txtTglProses.Size = New System.Drawing.Size(210, 20)
        Me.txtTglProses.TabIndex = 16
        '
        'txtTglPO
        '
        Me.txtTglPO.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTglPO.Location = New System.Drawing.Point(874, 58)
        Me.txtTglPO.Name = "txtTglPO"
        Me.txtTglPO.Size = New System.Drawing.Size(210, 20)
        Me.txtTglPO.TabIndex = 15
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(774, 84)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(91, 19)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "TGL PROSES"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(774, 59)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(58, 19)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "TGL PO"
        '
        'TglExpired
        '
        Me.TglExpired.CustomFormat = "dd-MM-yyyy"
        Me.TglExpired.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.TglExpired.Location = New System.Drawing.Point(874, 8)
        Me.TglExpired.Name = "TglExpired"
        Me.TglExpired.Size = New System.Drawing.Size(210, 20)
        Me.TglExpired.TabIndex = 11
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(774, 9)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(95, 19)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "TGL EXPIRED"
        '
        'BtnFindNoUPO
        '
        Me.BtnFindNoUPO.BackColor = System.Drawing.Color.Transparent
        Me.BtnFindNoUPO.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Cyan
        Me.BtnFindNoUPO.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnFindNoUPO.ForeColor = System.Drawing.Color.Black
        Me.BtnFindNoUPO.Location = New System.Drawing.Point(299, 8)
        Me.BtnFindNoUPO.Name = "BtnFindNoUPO"
        Me.BtnFindNoUPO.Size = New System.Drawing.Size(38, 21)
        Me.BtnFindNoUPO.TabIndex = 9
        Me.BtnFindNoUPO.Text = "..."
        Me.BtnFindNoUPO.UseVisualStyleBackColor = False
        '
        'TxtNoUPO
        '
        Me.TxtNoUPO.BackColor = System.Drawing.Color.White
        Me.TxtNoUPO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNoUPO.Location = New System.Drawing.Point(127, 8)
        Me.TxtNoUPO.Name = "TxtNoUPO"
        Me.TxtNoUPO.ReadOnly = True
        Me.TxtNoUPO.Size = New System.Drawing.Size(166, 21)
        Me.TxtNoUPO.TabIndex = 8
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(2, 8)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(69, 19)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "NO. UPO"
        '
        'BtnFindSupplier
        '
        Me.BtnFindSupplier.BackColor = System.Drawing.Color.Transparent
        Me.BtnFindSupplier.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Cyan
        Me.BtnFindSupplier.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnFindSupplier.ForeColor = System.Drawing.Color.Black
        Me.BtnFindSupplier.Location = New System.Drawing.Point(492, 33)
        Me.BtnFindSupplier.Name = "BtnFindSupplier"
        Me.BtnFindSupplier.Size = New System.Drawing.Size(38, 21)
        Me.BtnFindSupplier.TabIndex = 5
        Me.BtnFindSupplier.Text = "..."
        Me.BtnFindSupplier.UseVisualStyleBackColor = False
        '
        'TxtNoFaktur
        '
        Me.TxtNoFaktur.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNoFaktur.Location = New System.Drawing.Point(127, 58)
        Me.TxtNoFaktur.Name = "TxtNoFaktur"
        Me.TxtNoFaktur.Size = New System.Drawing.Size(211, 20)
        Me.TxtNoFaktur.TabIndex = 4
        '
        'LblTanggal
        '
        Me.LblTanggal.AutoSize = True
        Me.LblTanggal.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTanggal.Location = New System.Drawing.Point(2, 58)
        Me.LblTanggal.Name = "LblTanggal"
        Me.LblTanggal.Size = New System.Drawing.Size(55, 19)
        Me.LblTanggal.TabIndex = 3
        Me.LblTanggal.Text = "NO PO"
        '
        'TxtNamaSupplier
        '
        Me.TxtNamaSupplier.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNamaSupplier.Location = New System.Drawing.Point(201, 33)
        Me.TxtNamaSupplier.Name = "TxtNamaSupplier"
        Me.TxtNamaSupplier.Size = New System.Drawing.Size(285, 21)
        Me.TxtNamaSupplier.TabIndex = 2
        '
        'TxtKodeSupplier
        '
        Me.TxtKodeSupplier.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtKodeSupplier.Location = New System.Drawing.Point(127, 33)
        Me.TxtKodeSupplier.Name = "TxtKodeSupplier"
        Me.TxtKodeSupplier.Size = New System.Drawing.Size(68, 21)
        Me.TxtKodeSupplier.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(2, 33)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(122, 19)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "NAMA SUPPLIER"
        '
        'listview2
        '
        Me.listview2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.listview2.Location = New System.Drawing.Point(0, 171)
        Me.listview2.Name = "listview2"
        Me.listview2.Size = New System.Drawing.Size(1099, 305)
        Me.listview2.TabIndex = 102
        Me.listview2.UseCompatibleStateImageBehavior = False
        '
        'txtharga
        '
        Me.txtharga.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtharga.Location = New System.Drawing.Point(937, 481)
        Me.txtharga.Name = "txtharga"
        Me.txtharga.Size = New System.Drawing.Size(160, 20)
        Me.txtharga.TabIndex = 18
        Me.txtharga.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(744, 483)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(189, 19)
        Me.Label7.TabIndex = 17
        Me.Label7.Text = "TOTAL HARGA PEMBELIAN"
        '
        'txtdiscount
        '
        Me.txtdiscount.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtdiscount.Location = New System.Drawing.Point(937, 504)
        Me.txtdiscount.Name = "txtdiscount"
        Me.txtdiscount.Size = New System.Drawing.Size(160, 20)
        Me.txtdiscount.TabIndex = 104
        Me.txtdiscount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(744, 506)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(126, 19)
        Me.Label8.TabIndex = 103
        Me.Label8.Text = "TOTAL DISCOUNT"
        '
        'txthargadiscount
        '
        Me.txthargadiscount.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txthargadiscount.Location = New System.Drawing.Point(937, 527)
        Me.txthargadiscount.Name = "txthargadiscount"
        Me.txthargadiscount.Size = New System.Drawing.Size(160, 20)
        Me.txthargadiscount.TabIndex = 106
        Me.txthargadiscount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(744, 529)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(169, 19)
        Me.Label9.TabIndex = 105
        Me.Label9.Text = "TTL SETELAH DISCOUNT"
        '
        'txtppn
        '
        Me.txtppn.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtppn.Location = New System.Drawing.Point(937, 550)
        Me.txtppn.Name = "txtppn"
        Me.txtppn.Size = New System.Drawing.Size(160, 20)
        Me.txtppn.TabIndex = 108
        Me.txtppn.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'labelppn
        '
        Me.labelppn.AutoSize = True
        Me.labelppn.BackColor = System.Drawing.Color.Transparent
        Me.labelppn.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labelppn.Location = New System.Drawing.Point(744, 552)
        Me.labelppn.Name = "labelppn"
        Me.labelppn.Size = New System.Drawing.Size(57, 19)
        Me.labelppn.TabIndex = 107
        Me.labelppn.Text = "PPN IN"
        '
        'txtIncPPN
        '
        Me.txtIncPPN.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIncPPN.Location = New System.Drawing.Point(937, 573)
        Me.txtIncPPN.Name = "txtIncPPN"
        Me.txtIncPPN.Size = New System.Drawing.Size(160, 20)
        Me.txtIncPPN.TabIndex = 110
        Me.txtIncPPN.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblincppn
        '
        Me.lblincppn.AutoSize = True
        Me.lblincppn.BackColor = System.Drawing.Color.Transparent
        Me.lblincppn.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblincppn.Location = New System.Drawing.Point(744, 575)
        Me.lblincppn.Name = "lblincppn"
        Me.lblincppn.Size = New System.Drawing.Size(112, 19)
        Me.lblincppn.TabIndex = 109
        Me.lblincppn.Text = "TOTAL INC PPN"
        '
        'txttotal
        '
        Me.txttotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txttotal.Location = New System.Drawing.Point(937, 596)
        Me.txttotal.Name = "txttotal"
        Me.txttotal.Size = New System.Drawing.Size(160, 20)
        Me.txttotal.TabIndex = 112
        Me.txttotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lbltotal
        '
        Me.lbltotal.AutoSize = True
        Me.lbltotal.BackColor = System.Drawing.Color.Transparent
        Me.lbltotal.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltotal.Location = New System.Drawing.Point(744, 598)
        Me.lbltotal.Name = "lbltotal"
        Me.lbltotal.Size = New System.Drawing.Size(176, 19)
        Me.lbltotal.TabIndex = 111
        Me.lbltotal.Text = "TOTAL FAKTUR SUPPLIER"
        '
        'BtnSave
        '
        Me.BtnSave.BackColor = System.Drawing.Color.Transparent
        Me.BtnSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Cyan
        Me.BtnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSave.ForeColor = System.Drawing.Color.Black
        Me.BtnSave.Location = New System.Drawing.Point(110, 483)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(106, 41)
        Me.BtnSave.TabIndex = 114
        Me.BtnSave.Text = "&Save"
        Me.BtnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnSave.UseVisualStyleBackColor = False
        '
        'BtnPrint
        '
        Me.BtnPrint.BackColor = System.Drawing.Color.Transparent
        Me.BtnPrint.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Cyan
        Me.BtnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnPrint.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnPrint.ForeColor = System.Drawing.Color.Black
        Me.BtnPrint.Location = New System.Drawing.Point(431, 483)
        Me.BtnPrint.Name = "BtnPrint"
        Me.BtnPrint.Size = New System.Drawing.Size(106, 41)
        Me.BtnPrint.TabIndex = 113
        Me.BtnPrint.Text = "&Print"
        Me.BtnPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnPrint.UseVisualStyleBackColor = False
        '
        'btnedit
        '
        Me.btnedit.BackColor = System.Drawing.Color.Transparent
        Me.btnedit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Cyan
        Me.btnedit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnedit.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnedit.ForeColor = System.Drawing.Color.Black
        Me.btnedit.Location = New System.Drawing.Point(3, 483)
        Me.btnedit.Name = "btnedit"
        Me.btnedit.Size = New System.Drawing.Size(106, 41)
        Me.btnedit.TabIndex = 115
        Me.btnedit.Text = "&Edit"
        Me.btnedit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnedit.UseVisualStyleBackColor = False
        '
        'BtnApproval
        '
        Me.BtnApproval.BackColor = System.Drawing.Color.Transparent
        Me.BtnApproval.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Cyan
        Me.BtnApproval.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnApproval.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnApproval.ForeColor = System.Drawing.Color.Black
        Me.BtnApproval.Location = New System.Drawing.Point(324, 483)
        Me.BtnApproval.Name = "BtnApproval"
        Me.BtnApproval.Size = New System.Drawing.Size(106, 41)
        Me.BtnApproval.TabIndex = 116
        Me.BtnApproval.Text = "&Approval"
        Me.BtnApproval.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnApproval.UseVisualStyleBackColor = False
        '
        'BtnCancel
        '
        Me.BtnCancel.BackColor = System.Drawing.Color.Transparent
        Me.BtnCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Cyan
        Me.BtnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCancel.ForeColor = System.Drawing.Color.Black
        Me.BtnCancel.Location = New System.Drawing.Point(217, 483)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(106, 41)
        Me.BtnCancel.TabIndex = 117
        Me.BtnCancel.Text = "&Cancel"
        Me.BtnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnCancel.UseVisualStyleBackColor = False
        '
        'btnUpdHarga
        '
        Me.btnUpdHarga.BackColor = System.Drawing.Color.Transparent
        Me.btnUpdHarga.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Cyan
        Me.btnUpdHarga.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnUpdHarga.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUpdHarga.ForeColor = System.Drawing.Color.Black
        Me.btnUpdHarga.Location = New System.Drawing.Point(538, 483)
        Me.btnUpdHarga.Name = "btnUpdHarga"
        Me.btnUpdHarga.Size = New System.Drawing.Size(106, 41)
        Me.btnUpdHarga.TabIndex = 145
        Me.btnUpdHarga.Text = "Cop&y PO"
        Me.btnUpdHarga.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnUpdHarga.UseVisualStyleBackColor = False
        '
        'FrmPOOtomatis
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1099, 621)
        Me.Controls.Add(Me.btnUpdHarga)
        Me.Controls.Add(Me.BtnCancel)
        Me.Controls.Add(Me.BtnApproval)
        Me.Controls.Add(Me.btnedit)
        Me.Controls.Add(Me.BtnSave)
        Me.Controls.Add(Me.BtnPrint)
        Me.Controls.Add(Me.txttotal)
        Me.Controls.Add(Me.lbltotal)
        Me.Controls.Add(Me.txtIncPPN)
        Me.Controls.Add(Me.lblincppn)
        Me.Controls.Add(Me.txtppn)
        Me.Controls.Add(Me.labelppn)
        Me.Controls.Add(Me.txthargadiscount)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtdiscount)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtharga)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.listview2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PictureBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.Name = "FrmPOOtomatis"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmPOOtomatis"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TglExpired As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents BtnFindNoUPO As System.Windows.Forms.Button
    Friend WithEvents TxtNoUPO As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents BtnFindSupplier As System.Windows.Forms.Button
    Friend WithEvents TxtNoFaktur As System.Windows.Forms.TextBox
    Friend WithEvents LblTanggal As System.Windows.Forms.Label
    Friend WithEvents TxtNamaSupplier As System.Windows.Forms.TextBox
    Friend WithEvents TxtKodeSupplier As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents listview2 As System.Windows.Forms.ListView
    Friend WithEvents txtharga As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtdiscount As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txthargadiscount As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtppn As System.Windows.Forms.TextBox
    Friend WithEvents labelppn As System.Windows.Forms.Label
    Friend WithEvents txtIncPPN As System.Windows.Forms.TextBox
    Friend WithEvents lblincppn As System.Windows.Forms.Label
    Friend WithEvents txttotal As System.Windows.Forms.TextBox
    Friend WithEvents lbltotal As System.Windows.Forms.Label
    Friend WithEvents BtnSave As System.Windows.Forms.Button
    Friend WithEvents BtnPrint As System.Windows.Forms.Button
    Friend WithEvents btnedit As System.Windows.Forms.Button
    Friend WithEvents BtnApproval As System.Windows.Forms.Button
    Friend WithEvents txtTglProses As System.Windows.Forms.TextBox
    Friend WithEvents txtTglPO As System.Windows.Forms.TextBox
    Friend WithEvents BtnCancel As System.Windows.Forms.Button
    Friend WithEvents DtKirim As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents btnUpdHarga As System.Windows.Forms.Button
    Friend WithEvents TxtExtTime As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents cbpartial As System.Windows.Forms.CheckBox
End Class
