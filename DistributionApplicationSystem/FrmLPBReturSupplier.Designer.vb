<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmLPBReturSupplier
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
        Me.TxtTglRetur = New System.Windows.Forms.TextBox()
        Me.TxtUser = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.TxtTotalIncPpn = New System.Windows.Forms.TextBox()
        Me.TxtTglApprove = New System.Windows.Forms.TextBox()
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.TxtPPN = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.BtnAdd = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.BtnApproval = New System.Windows.Forms.Button()
        Me.TxtTotalRetur = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.BtnFindNoRetur = New System.Windows.Forms.Button()
        Me.TxtNoRetur = New System.Windows.Forms.TextBox()
        Me.BtnFindSupplier = New System.Windows.Forms.Button()
        Me.TxtNamaSupplier = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Txtcatatan = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.CmbTipeRetur = New System.Windows.Forms.ComboBox()
        Me.TxtKodeSupplier = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.BtnPrint = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TxtTotalQty = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TxtTotalItem = New System.Windows.Forms.TextBox()
        Me.BtnFindBrg = New System.Windows.Forms.Button()
        Me.TxtNamaBarang = New System.Windows.Forms.TextBox()
        Me.TxtKodeProduk = New System.Windows.Forms.TextBox()
        Me.TxtQty = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.BtnCancel = New System.Windows.Forms.Button()
        Me.BtnSave = New System.Windows.Forms.Button()
        Me.BtnEdit = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'TxtTglRetur
        '
        Me.TxtTglRetur.BackColor = System.Drawing.Color.White
        Me.TxtTglRetur.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTglRetur.Location = New System.Drawing.Point(133, 53)
        Me.TxtTglRetur.Name = "TxtTglRetur"
        Me.TxtTglRetur.ReadOnly = True
        Me.TxtTglRetur.Size = New System.Drawing.Size(185, 21)
        Me.TxtTglRetur.TabIndex = 22
        '
        'TxtUser
        '
        Me.TxtUser.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtUser.Location = New System.Drawing.Point(782, 3)
        Me.TxtUser.Name = "TxtUser"
        Me.TxtUser.Size = New System.Drawing.Size(185, 21)
        Me.TxtUser.TabIndex = 20
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(699, 507)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(112, 19)
        Me.Label13.TabIndex = 148
        Me.Label13.Text = "TOTAL INC PPN"
        '
        'TxtTotalIncPpn
        '
        Me.TxtTotalIncPpn.BackColor = System.Drawing.Color.White
        Me.TxtTotalIncPpn.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTotalIncPpn.Location = New System.Drawing.Point(821, 505)
        Me.TxtTotalIncPpn.Name = "TxtTotalIncPpn"
        Me.TxtTotalIncPpn.ReadOnly = True
        Me.TxtTotalIncPpn.Size = New System.Drawing.Size(143, 21)
        Me.TxtTotalIncPpn.TabIndex = 147
        Me.TxtTotalIncPpn.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtTglApprove
        '
        Me.TxtTglApprove.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTglApprove.Location = New System.Drawing.Point(782, 28)
        Me.TxtTglApprove.Name = "TxtTglApprove"
        Me.TxtTglApprove.Size = New System.Drawing.Size(185, 21)
        Me.TxtTglApprove.TabIndex = 21
        '
        'ListView1
        '
        Me.ListView1.Location = New System.Drawing.Point(-4, 164)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(973, 235)
        Me.ListView1.TabIndex = 136
        Me.ListView1.UseCompatibleStateImageBehavior = False
        '
        'TxtPPN
        '
        Me.TxtPPN.BackColor = System.Drawing.Color.White
        Me.TxtPPN.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtPPN.Location = New System.Drawing.Point(821, 480)
        Me.TxtPPN.Name = "TxtPPN"
        Me.TxtPPN.ReadOnly = True
        Me.TxtPPN.Size = New System.Drawing.Size(143, 21)
        Me.TxtPPN.TabIndex = 145
        Me.TxtPPN.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(677, 5)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(44, 19)
        Me.Label7.TabIndex = 19
        Me.Label7.Text = "USER"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(699, 483)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(57, 19)
        Me.Label12.TabIndex = 146
        Me.Label12.Text = "PPN IN"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(677, 31)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(103, 19)
        Me.Label6.TabIndex = 17
        Me.Label6.Text = "TGL APPROVE"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(699, 457)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(100, 19)
        Me.Label14.TabIndex = 150
        Me.Label14.Text = "TOTAL RETUR"
        '
        'BtnAdd
        '
        Me.BtnAdd.BackColor = System.Drawing.Color.Transparent
        Me.BtnAdd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Cyan
        Me.BtnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnAdd.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnAdd.ForeColor = System.Drawing.Color.Black
        Me.BtnAdd.Location = New System.Drawing.Point(7, 486)
        Me.BtnAdd.Name = "BtnAdd"
        Me.BtnAdd.Size = New System.Drawing.Size(103, 41)
        Me.BtnAdd.TabIndex = 153
        Me.BtnAdd.Text = "&Add"
        Me.BtnAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnAdd.UseVisualStyleBackColor = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(5, 56)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(82, 19)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "TGL RETUR"
        '
        'BtnApproval
        '
        Me.BtnApproval.BackColor = System.Drawing.Color.Transparent
        Me.BtnApproval.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Cyan
        Me.BtnApproval.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnApproval.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnApproval.ForeColor = System.Drawing.Color.Black
        Me.BtnApproval.Location = New System.Drawing.Point(423, 486)
        Me.BtnApproval.Name = "BtnApproval"
        Me.BtnApproval.Size = New System.Drawing.Size(103, 41)
        Me.BtnApproval.TabIndex = 152
        Me.BtnApproval.Text = "Appr&oval"
        Me.BtnApproval.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnApproval.UseVisualStyleBackColor = False
        '
        'TxtTotalRetur
        '
        Me.TxtTotalRetur.BackColor = System.Drawing.Color.White
        Me.TxtTotalRetur.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTotalRetur.Location = New System.Drawing.Point(821, 455)
        Me.TxtTotalRetur.Name = "TxtTotalRetur"
        Me.TxtTotalRetur.ReadOnly = True
        Me.TxtTotalRetur.Size = New System.Drawing.Size(143, 21)
        Me.TxtTotalRetur.TabIndex = 149
        Me.TxtTotalRetur.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(5, 30)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(79, 19)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "NO.RETUR"
        '
        'BtnFindNoRetur
        '
        Me.BtnFindNoRetur.BackColor = System.Drawing.Color.Transparent
        Me.BtnFindNoRetur.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Cyan
        Me.BtnFindNoRetur.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnFindNoRetur.ForeColor = System.Drawing.Color.Black
        Me.BtnFindNoRetur.Location = New System.Drawing.Point(280, 28)
        Me.BtnFindNoRetur.Name = "BtnFindNoRetur"
        Me.BtnFindNoRetur.Size = New System.Drawing.Size(38, 21)
        Me.BtnFindNoRetur.TabIndex = 11
        Me.BtnFindNoRetur.Text = "..."
        Me.BtnFindNoRetur.UseVisualStyleBackColor = False
        '
        'TxtNoRetur
        '
        Me.TxtNoRetur.BackColor = System.Drawing.Color.White
        Me.TxtNoRetur.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNoRetur.Location = New System.Drawing.Point(133, 28)
        Me.TxtNoRetur.Name = "TxtNoRetur"
        Me.TxtNoRetur.ReadOnly = True
        Me.TxtNoRetur.Size = New System.Drawing.Size(141, 21)
        Me.TxtNoRetur.TabIndex = 10
        '
        'BtnFindSupplier
        '
        Me.BtnFindSupplier.BackColor = System.Drawing.Color.Transparent
        Me.BtnFindSupplier.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Cyan
        Me.BtnFindSupplier.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnFindSupplier.ForeColor = System.Drawing.Color.Black
        Me.BtnFindSupplier.Location = New System.Drawing.Point(498, 3)
        Me.BtnFindSupplier.Name = "BtnFindSupplier"
        Me.BtnFindSupplier.Size = New System.Drawing.Size(38, 21)
        Me.BtnFindSupplier.TabIndex = 9
        Me.BtnFindSupplier.Text = "..."
        Me.BtnFindSupplier.UseVisualStyleBackColor = False
        '
        'TxtNamaSupplier
        '
        Me.TxtNamaSupplier.BackColor = System.Drawing.Color.White
        Me.TxtNamaSupplier.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNamaSupplier.Location = New System.Drawing.Point(207, 3)
        Me.TxtNamaSupplier.Name = "TxtNamaSupplier"
        Me.TxtNamaSupplier.ReadOnly = True
        Me.TxtNamaSupplier.Size = New System.Drawing.Size(285, 21)
        Me.TxtNamaSupplier.TabIndex = 8
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.Txtcatatan)
        Me.Panel1.Controls.Add(Me.Label15)
        Me.Panel1.Controls.Add(Me.Label11)
        Me.Panel1.Controls.Add(Me.CmbTipeRetur)
        Me.Panel1.Controls.Add(Me.TxtTglRetur)
        Me.Panel1.Controls.Add(Me.TxtTglApprove)
        Me.Panel1.Controls.Add(Me.TxtUser)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.BtnFindNoRetur)
        Me.Panel1.Controls.Add(Me.TxtNoRetur)
        Me.Panel1.Controls.Add(Me.BtnFindSupplier)
        Me.Panel1.Controls.Add(Me.TxtNamaSupplier)
        Me.Panel1.Controls.Add(Me.TxtKodeSupplier)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Location = New System.Drawing.Point(-5, 53)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(974, 108)
        Me.Panel1.TabIndex = 135
        '
        'Txtcatatan
        '
        Me.Txtcatatan.BackColor = System.Drawing.SystemColors.Window
        Me.Txtcatatan.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txtcatatan.Location = New System.Drawing.Point(133, 78)
        Me.Txtcatatan.Name = "Txtcatatan"
        Me.Txtcatatan.Size = New System.Drawing.Size(403, 21)
        Me.Txtcatatan.TabIndex = 26
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(5, 81)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(70, 19)
        Me.Label15.TabIndex = 25
        Me.Label15.Text = "CATATAN"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(677, 53)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(86, 19)
        Me.Label11.TabIndex = 24
        Me.Label11.Text = "TIPE RETUR"
        '
        'CmbTipeRetur
        '
        Me.CmbTipeRetur.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CmbTipeRetur.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CmbTipeRetur.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.CmbTipeRetur.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.CmbTipeRetur.FormattingEnabled = True
        Me.CmbTipeRetur.Location = New System.Drawing.Point(782, 53)
        Me.CmbTipeRetur.Name = "CmbTipeRetur"
        Me.CmbTipeRetur.Size = New System.Drawing.Size(185, 21)
        Me.CmbTipeRetur.TabIndex = 23
        '
        'TxtKodeSupplier
        '
        Me.TxtKodeSupplier.BackColor = System.Drawing.Color.White
        Me.TxtKodeSupplier.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtKodeSupplier.Location = New System.Drawing.Point(133, 3)
        Me.TxtKodeSupplier.Name = "TxtKodeSupplier"
        Me.TxtKodeSupplier.ReadOnly = True
        Me.TxtKodeSupplier.Size = New System.Drawing.Size(68, 21)
        Me.TxtKodeSupplier.TabIndex = 7
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(5, 3)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(114, 19)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "KODE SUPPLIER"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label1.Font = New System.Drawing.Font("Britannic Bold", 20.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(225, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(476, 30)
        Me.Label1.TabIndex = 134
        Me.Label1.Text = "NOTA RETUR BARANG-RETUR SUPPLIER"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(969, 49)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 133
        Me.PictureBox1.TabStop = False
        '
        'BtnPrint
        '
        Me.BtnPrint.BackColor = System.Drawing.Color.Transparent
        Me.BtnPrint.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Cyan
        Me.BtnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnPrint.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnPrint.ForeColor = System.Drawing.Color.Black
        Me.BtnPrint.Location = New System.Drawing.Point(527, 486)
        Me.BtnPrint.Name = "BtnPrint"
        Me.BtnPrint.Size = New System.Drawing.Size(103, 41)
        Me.BtnPrint.TabIndex = 151
        Me.BtnPrint.Text = "&Print"
        Me.BtnPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnPrint.UseVisualStyleBackColor = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(699, 432)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(83, 19)
        Me.Label9.TabIndex = 140
        Me.Label9.Text = "TOTAL QTY"
        '
        'TxtTotalQty
        '
        Me.TxtTotalQty.BackColor = System.Drawing.Color.White
        Me.TxtTotalQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTotalQty.Location = New System.Drawing.Point(821, 430)
        Me.TxtTotalQty.Name = "TxtTotalQty"
        Me.TxtTotalQty.ReadOnly = True
        Me.TxtTotalQty.Size = New System.Drawing.Size(143, 21)
        Me.TxtTotalQty.TabIndex = 139
        Me.TxtTotalQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(699, 407)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(90, 19)
        Me.Label8.TabIndex = 138
        Me.Label8.Text = "TOTAL ITEM"
        '
        'TxtTotalItem
        '
        Me.TxtTotalItem.BackColor = System.Drawing.Color.White
        Me.TxtTotalItem.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTotalItem.Location = New System.Drawing.Point(821, 405)
        Me.TxtTotalItem.Name = "TxtTotalItem"
        Me.TxtTotalItem.ReadOnly = True
        Me.TxtTotalItem.Size = New System.Drawing.Size(143, 21)
        Me.TxtTotalItem.TabIndex = 137
        Me.TxtTotalItem.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'BtnFindBrg
        '
        Me.BtnFindBrg.BackColor = System.Drawing.Color.Transparent
        Me.BtnFindBrg.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Cyan
        Me.BtnFindBrg.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnFindBrg.ForeColor = System.Drawing.Color.Black
        Me.BtnFindBrg.Location = New System.Drawing.Point(487, 30)
        Me.BtnFindBrg.Name = "BtnFindBrg"
        Me.BtnFindBrg.Size = New System.Drawing.Size(38, 21)
        Me.BtnFindBrg.TabIndex = 157
        Me.BtnFindBrg.Text = "..."
        Me.BtnFindBrg.UseVisualStyleBackColor = False
        '
        'TxtNamaBarang
        '
        Me.TxtNamaBarang.BackColor = System.Drawing.Color.White
        Me.TxtNamaBarang.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNamaBarang.Location = New System.Drawing.Point(150, 30)
        Me.TxtNamaBarang.Name = "TxtNamaBarang"
        Me.TxtNamaBarang.ReadOnly = True
        Me.TxtNamaBarang.Size = New System.Drawing.Size(331, 21)
        Me.TxtNamaBarang.TabIndex = 156
        '
        'TxtKodeProduk
        '
        Me.TxtKodeProduk.BackColor = System.Drawing.Color.White
        Me.TxtKodeProduk.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtKodeProduk.Location = New System.Drawing.Point(11, 30)
        Me.TxtKodeProduk.Name = "TxtKodeProduk"
        Me.TxtKodeProduk.ReadOnly = True
        Me.TxtKodeProduk.Size = New System.Drawing.Size(131, 21)
        Me.TxtKodeProduk.TabIndex = 155
        '
        'TxtQty
        '
        Me.TxtQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtQty.Location = New System.Drawing.Point(566, 28)
        Me.TxtQty.MaxLength = 22
        Me.TxtQty.Name = "TxtQty"
        Me.TxtQty.Size = New System.Drawing.Size(93, 21)
        Me.TxtQty.TabIndex = 159
        Me.TxtQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(564, 6)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(36, 19)
        Me.Label10.TabIndex = 158
        Me.Label10.Text = "QTY"
        '
        'BtnCancel
        '
        Me.BtnCancel.BackColor = System.Drawing.Color.Transparent
        Me.BtnCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Cyan
        Me.BtnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCancel.ForeColor = System.Drawing.Color.Black
        Me.BtnCancel.Location = New System.Drawing.Point(319, 486)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(103, 41)
        Me.BtnCancel.TabIndex = 160
        Me.BtnCancel.Text = "&Cancel"
        Me.BtnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnCancel.UseVisualStyleBackColor = False
        '
        'BtnSave
        '
        Me.BtnSave.BackColor = System.Drawing.Color.Transparent
        Me.BtnSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Cyan
        Me.BtnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSave.ForeColor = System.Drawing.Color.Black
        Me.BtnSave.Location = New System.Drawing.Point(215, 486)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(103, 41)
        Me.BtnSave.TabIndex = 161
        Me.BtnSave.Text = "&Save"
        Me.BtnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnSave.UseVisualStyleBackColor = False
        '
        'BtnEdit
        '
        Me.BtnEdit.BackColor = System.Drawing.Color.Transparent
        Me.BtnEdit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Cyan
        Me.BtnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnEdit.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnEdit.ForeColor = System.Drawing.Color.Black
        Me.BtnEdit.Location = New System.Drawing.Point(111, 486)
        Me.BtnEdit.Name = "BtnEdit"
        Me.BtnEdit.Size = New System.Drawing.Size(103, 41)
        Me.BtnEdit.TabIndex = 162
        Me.BtnEdit.Text = "&Edit"
        Me.BtnEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnEdit.UseVisualStyleBackColor = False
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.BtnFindBrg)
        Me.Panel2.Controls.Add(Me.TxtKodeProduk)
        Me.Panel2.Controls.Add(Me.TxtNamaBarang)
        Me.Panel2.Controls.Add(Me.TxtQty)
        Me.Panel2.Controls.Add(Me.Label10)
        Me.Panel2.Location = New System.Drawing.Point(6, 407)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(673, 73)
        Me.Panel2.TabIndex = 163
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(7, 6)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(116, 19)
        Me.Label5.TabIndex = 160
        Me.Label5.Text = "NAMA PRODUK"
        '
        'FrmLPBReturSupplier
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(969, 532)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.BtnEdit)
        Me.Controls.Add(Me.BtnSave)
        Me.Controls.Add(Me.BtnCancel)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.TxtTotalIncPpn)
        Me.Controls.Add(Me.ListView1)
        Me.Controls.Add(Me.TxtPPN)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.BtnAdd)
        Me.Controls.Add(Me.BtnApproval)
        Me.Controls.Add(Me.TxtTotalRetur)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.BtnPrint)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.TxtTotalQty)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.TxtTotalItem)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.Name = "FrmLPBReturSupplier"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmLPBReturSupplier"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TxtTglRetur As System.Windows.Forms.TextBox
    Friend WithEvents TxtUser As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents TxtTotalIncPpn As System.Windows.Forms.TextBox
    Friend WithEvents TxtTglApprove As System.Windows.Forms.TextBox
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents TxtPPN As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents BtnAdd As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents BtnApproval As System.Windows.Forms.Button
    Friend WithEvents TxtTotalRetur As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents BtnFindNoRetur As System.Windows.Forms.Button
    Friend WithEvents TxtNoRetur As System.Windows.Forms.TextBox
    Friend WithEvents BtnFindSupplier As System.Windows.Forms.Button
    Friend WithEvents TxtNamaSupplier As System.Windows.Forms.TextBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents TxtKodeSupplier As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents BtnPrint As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents TxtTotalQty As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TxtTotalItem As System.Windows.Forms.TextBox
    Friend WithEvents BtnFindBrg As System.Windows.Forms.Button
    Friend WithEvents TxtNamaBarang As System.Windows.Forms.TextBox
    Friend WithEvents TxtKodeProduk As System.Windows.Forms.TextBox
    Friend WithEvents TxtQty As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents CmbTipeRetur As System.Windows.Forms.ComboBox
    Friend WithEvents BtnCancel As System.Windows.Forms.Button
    Friend WithEvents Txtcatatan As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents BtnSave As System.Windows.Forms.Button
    Friend WithEvents BtnEdit As System.Windows.Forms.Button
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label5 As System.Windows.Forms.Label
End Class
