<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmDraftPOGO
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
        Me.btnfindnopo = New System.Windows.Forms.Button()
        Me.txtjmltoko = New System.Windows.Forms.TextBox()
        Me.txtTglPO = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.BtnFindSupplier = New System.Windows.Forms.Button()
        Me.TxtNoFaktur = New System.Windows.Forms.TextBox()
        Me.LblTanggal = New System.Windows.Forms.Label()
        Me.TxtNamaSupplier = New System.Windows.Forms.TextBox()
        Me.TxtKodeSupplier = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.listview2 = New System.Windows.Forms.ListView()
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.txtqty = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtPrice = New System.Windows.Forms.TextBox()
        Me.BtnFindProduk = New System.Windows.Forms.Button()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtNamaProduk = New System.Windows.Forms.TextBox()
        Me.txtKodeProduk = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.BtnCancel = New System.Windows.Forms.Button()
        Me.BtnAdd = New System.Windows.Forms.Button()
        Me.BtnApproval = New System.Windows.Forms.Button()
        Me.BtnEdit = New System.Windows.Forms.Button()
        Me.BtnSimpan = New System.Windows.Forms.Button()
        Me.BtnPrint = New System.Windows.Forms.Button()
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
        Me.Label1.Location = New System.Drawing.Point(280, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(175, 30)
        Me.Label1.TabIndex = 95
        Me.Label1.Text = "DRAFT PO GO"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(1035, 49)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 94
        Me.PictureBox1.TabStop = False
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.btnfindnopo)
        Me.Panel1.Controls.Add(Me.txtjmltoko)
        Me.Panel1.Controls.Add(Me.txtTglPO)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.BtnFindSupplier)
        Me.Panel1.Controls.Add(Me.TxtNoFaktur)
        Me.Panel1.Controls.Add(Me.LblTanggal)
        Me.Panel1.Controls.Add(Me.TxtNamaSupplier)
        Me.Panel1.Controls.Add(Me.TxtKodeSupplier)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Location = New System.Drawing.Point(1, 50)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1034, 55)
        Me.Panel1.TabIndex = 102
        '
        'btnfindnopo
        '
        Me.btnfindnopo.BackColor = System.Drawing.Color.Transparent
        Me.btnfindnopo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnfindnopo.ForeColor = System.Drawing.Color.Black
        Me.btnfindnopo.Location = New System.Drawing.Point(286, 3)
        Me.btnfindnopo.Name = "btnfindnopo"
        Me.btnfindnopo.Size = New System.Drawing.Size(38, 21)
        Me.btnfindnopo.TabIndex = 17
        Me.btnfindnopo.Text = "..."
        Me.btnfindnopo.UseVisualStyleBackColor = False
        '
        'txtjmltoko
        '
        Me.txtjmltoko.BackColor = System.Drawing.Color.White
        Me.txtjmltoko.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtjmltoko.Location = New System.Drawing.Point(875, 27)
        Me.txtjmltoko.Name = "txtjmltoko"
        Me.txtjmltoko.ReadOnly = True
        Me.txtjmltoko.Size = New System.Drawing.Size(147, 20)
        Me.txtjmltoko.TabIndex = 16
        Me.txtjmltoko.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTglPO
        '
        Me.txtTglPO.BackColor = System.Drawing.Color.White
        Me.txtTglPO.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTglPO.Location = New System.Drawing.Point(875, 4)
        Me.txtTglPO.Name = "txtTglPO"
        Me.txtTglPO.ReadOnly = True
        Me.txtTglPO.Size = New System.Drawing.Size(147, 20)
        Me.txtTglPO.TabIndex = 15
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(765, 29)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(107, 19)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "JUMLAH TOKO"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(765, 5)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(58, 19)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "TGL PO"
        '
        'BtnFindSupplier
        '
        Me.BtnFindSupplier.BackColor = System.Drawing.Color.Transparent
        Me.BtnFindSupplier.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnFindSupplier.ForeColor = System.Drawing.Color.Black
        Me.BtnFindSupplier.Location = New System.Drawing.Point(492, 27)
        Me.BtnFindSupplier.Name = "BtnFindSupplier"
        Me.BtnFindSupplier.Size = New System.Drawing.Size(38, 21)
        Me.BtnFindSupplier.TabIndex = 5
        Me.BtnFindSupplier.Text = "..."
        Me.BtnFindSupplier.UseVisualStyleBackColor = False
        '
        'TxtNoFaktur
        '
        Me.TxtNoFaktur.BackColor = System.Drawing.Color.White
        Me.TxtNoFaktur.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNoFaktur.Location = New System.Drawing.Point(127, 4)
        Me.TxtNoFaktur.Name = "TxtNoFaktur"
        Me.TxtNoFaktur.ReadOnly = True
        Me.TxtNoFaktur.Size = New System.Drawing.Size(153, 20)
        Me.TxtNoFaktur.TabIndex = 4
        '
        'LblTanggal
        '
        Me.LblTanggal.AutoSize = True
        Me.LblTanggal.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTanggal.Location = New System.Drawing.Point(2, 4)
        Me.LblTanggal.Name = "LblTanggal"
        Me.LblTanggal.Size = New System.Drawing.Size(55, 19)
        Me.LblTanggal.TabIndex = 3
        Me.LblTanggal.Text = "NO PO"
        '
        'TxtNamaSupplier
        '
        Me.TxtNamaSupplier.BackColor = System.Drawing.Color.White
        Me.TxtNamaSupplier.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNamaSupplier.Location = New System.Drawing.Point(201, 27)
        Me.TxtNamaSupplier.Name = "TxtNamaSupplier"
        Me.TxtNamaSupplier.ReadOnly = True
        Me.TxtNamaSupplier.Size = New System.Drawing.Size(285, 21)
        Me.TxtNamaSupplier.TabIndex = 2
        '
        'TxtKodeSupplier
        '
        Me.TxtKodeSupplier.BackColor = System.Drawing.Color.White
        Me.TxtKodeSupplier.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtKodeSupplier.Location = New System.Drawing.Point(127, 27)
        Me.TxtKodeSupplier.Name = "TxtKodeSupplier"
        Me.TxtKodeSupplier.ReadOnly = True
        Me.TxtKodeSupplier.Size = New System.Drawing.Size(68, 21)
        Me.TxtKodeSupplier.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(2, 27)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(122, 19)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "NAMA SUPPLIER"
        '
        'listview2
        '
        Me.listview2.Location = New System.Drawing.Point(0, 109)
        Me.listview2.Name = "listview2"
        Me.listview2.Size = New System.Drawing.Size(1038, 283)
        Me.listview2.TabIndex = 105
        Me.listview2.UseCompatibleStateImageBehavior = False
        '
        'ListView1
        '
        Me.ListView1.Location = New System.Drawing.Point(0, 418)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(341, 130)
        Me.ListView1.TabIndex = 106
        Me.ListView1.UseCompatibleStateImageBehavior = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(5, 395)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(87, 19)
        Me.Label3.TabIndex = 17
        Me.Label3.Text = "DATA TOKO"
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
        Me.Panel2.Location = New System.Drawing.Point(353, 418)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(682, 83)
        Me.Panel2.TabIndex = 132
        '
        'txtqty
        '
        Me.txtqty.BackColor = System.Drawing.Color.White
        Me.txtqty.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtqty.Location = New System.Drawing.Point(568, 40)
        Me.txtqty.MaxLength = 18
        Me.txtqty.Name = "txtqty"
        Me.txtqty.Size = New System.Drawing.Size(102, 21)
        Me.txtqty.TabIndex = 13
        Me.txtqty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(563, 17)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(60, 19)
        Me.Label14.TabIndex = 12
        Me.Label14.Text = "QTY PO"
        '
        'txtPrice
        '
        Me.txtPrice.BackColor = System.Drawing.Color.White
        Me.txtPrice.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPrice.Location = New System.Drawing.Point(456, 40)
        Me.txtPrice.Name = "txtPrice"
        Me.txtPrice.ReadOnly = True
        Me.txtPrice.Size = New System.Drawing.Size(102, 21)
        Me.txtPrice.TabIndex = 11
        Me.txtPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'BtnFindProduk
        '
        Me.BtnFindProduk.BackColor = System.Drawing.Color.Transparent
        Me.BtnFindProduk.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnFindProduk.ForeColor = System.Drawing.Color.Black
        Me.BtnFindProduk.Location = New System.Drawing.Point(390, 40)
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
        Me.Label13.Location = New System.Drawing.Point(452, 18)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(58, 19)
        Me.Label13.TabIndex = 10
        Me.Label13.Text = "HARGA"
        '
        'txtNamaProduk
        '
        Me.txtNamaProduk.BackColor = System.Drawing.Color.White
        Me.txtNamaProduk.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNamaProduk.Location = New System.Drawing.Point(81, 40)
        Me.txtNamaProduk.Name = "txtNamaProduk"
        Me.txtNamaProduk.ReadOnly = True
        Me.txtNamaProduk.Size = New System.Drawing.Size(303, 21)
        Me.txtNamaProduk.TabIndex = 8
        '
        'txtKodeProduk
        '
        Me.txtKodeProduk.BackColor = System.Drawing.Color.White
        Me.txtKodeProduk.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtKodeProduk.Location = New System.Drawing.Point(7, 40)
        Me.txtKodeProduk.Name = "txtKodeProduk"
        Me.txtKodeProduk.ReadOnly = True
        Me.txtKodeProduk.Size = New System.Drawing.Size(68, 21)
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
        'BtnCancel
        '
        Me.BtnCancel.BackColor = System.Drawing.Color.Transparent
        Me.BtnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCancel.ForeColor = System.Drawing.Color.Black
        Me.BtnCancel.Location = New System.Drawing.Point(811, 507)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(72, 41)
        Me.BtnCancel.TabIndex = 138
        Me.BtnCancel.Text = "&Cancel"
        Me.BtnCancel.UseVisualStyleBackColor = False
        '
        'BtnAdd
        '
        Me.BtnAdd.BackColor = System.Drawing.Color.Transparent
        Me.BtnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnAdd.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnAdd.ForeColor = System.Drawing.Color.Black
        Me.BtnAdd.Location = New System.Drawing.Point(586, 507)
        Me.BtnAdd.Name = "BtnAdd"
        Me.BtnAdd.Size = New System.Drawing.Size(72, 41)
        Me.BtnAdd.TabIndex = 137
        Me.BtnAdd.Text = "&Add"
        Me.BtnAdd.UseVisualStyleBackColor = False
        '
        'BtnApproval
        '
        Me.BtnApproval.BackColor = System.Drawing.Color.Transparent
        Me.BtnApproval.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnApproval.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnApproval.ForeColor = System.Drawing.Color.Black
        Me.BtnApproval.Location = New System.Drawing.Point(886, 507)
        Me.BtnApproval.Name = "BtnApproval"
        Me.BtnApproval.Size = New System.Drawing.Size(72, 41)
        Me.BtnApproval.TabIndex = 136
        Me.BtnApproval.Text = "Appr&oval"
        Me.BtnApproval.UseVisualStyleBackColor = False
        '
        'BtnEdit
        '
        Me.BtnEdit.BackColor = System.Drawing.Color.Transparent
        Me.BtnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnEdit.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnEdit.ForeColor = System.Drawing.Color.Black
        Me.BtnEdit.Location = New System.Drawing.Point(661, 507)
        Me.BtnEdit.Name = "BtnEdit"
        Me.BtnEdit.Size = New System.Drawing.Size(72, 41)
        Me.BtnEdit.TabIndex = 135
        Me.BtnEdit.Text = "&Edit"
        Me.BtnEdit.UseVisualStyleBackColor = False
        '
        'BtnSimpan
        '
        Me.BtnSimpan.BackColor = System.Drawing.Color.Transparent
        Me.BtnSimpan.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnSimpan.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSimpan.ForeColor = System.Drawing.Color.Black
        Me.BtnSimpan.Location = New System.Drawing.Point(736, 507)
        Me.BtnSimpan.Name = "BtnSimpan"
        Me.BtnSimpan.Size = New System.Drawing.Size(72, 41)
        Me.BtnSimpan.TabIndex = 134
        Me.BtnSimpan.Text = "&Save"
        Me.BtnSimpan.UseVisualStyleBackColor = False
        '
        'BtnPrint
        '
        Me.BtnPrint.BackColor = System.Drawing.Color.Transparent
        Me.BtnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnPrint.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnPrint.ForeColor = System.Drawing.Color.Black
        Me.BtnPrint.Location = New System.Drawing.Point(961, 507)
        Me.BtnPrint.Name = "BtnPrint"
        Me.BtnPrint.Size = New System.Drawing.Size(72, 41)
        Me.BtnPrint.TabIndex = 133
        Me.BtnPrint.Text = "&Print"
        Me.BtnPrint.UseVisualStyleBackColor = False
        '
        'FrmDraftPOGO
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1035, 551)
        Me.Controls.Add(Me.BtnCancel)
        Me.Controls.Add(Me.BtnAdd)
        Me.Controls.Add(Me.BtnApproval)
        Me.Controls.Add(Me.BtnEdit)
        Me.Controls.Add(Me.BtnSimpan)
        Me.Controls.Add(Me.BtnPrint)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.ListView1)
        Me.Controls.Add(Me.listview2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PictureBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.Name = "FrmDraftPOGO"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmDraftPOGO"
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
    Friend WithEvents txtjmltoko As System.Windows.Forms.TextBox
    Friend WithEvents txtTglPO As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents BtnFindSupplier As System.Windows.Forms.Button
    Friend WithEvents TxtNoFaktur As System.Windows.Forms.TextBox
    Friend WithEvents LblTanggal As System.Windows.Forms.Label
    Friend WithEvents TxtNamaSupplier As System.Windows.Forms.TextBox
    Friend WithEvents TxtKodeSupplier As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents listview2 As System.Windows.Forms.ListView
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents txtqty As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtPrice As System.Windows.Forms.TextBox
    Friend WithEvents BtnFindProduk As System.Windows.Forms.Button
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtNamaProduk As System.Windows.Forms.TextBox
    Friend WithEvents txtKodeProduk As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents BtnCancel As System.Windows.Forms.Button
    Friend WithEvents BtnAdd As System.Windows.Forms.Button
    Friend WithEvents BtnApproval As System.Windows.Forms.Button
    Friend WithEvents BtnEdit As System.Windows.Forms.Button
    Friend WithEvents BtnSimpan As System.Windows.Forms.Button
    Friend WithEvents BtnPrint As System.Windows.Forms.Button
    Friend WithEvents btnfindnopo As System.Windows.Forms.Button
End Class
