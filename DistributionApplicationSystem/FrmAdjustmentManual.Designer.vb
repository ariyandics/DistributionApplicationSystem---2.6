<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmAdjustmentManual
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.BtnSave = New System.Windows.Forms.Button()
        Me.BtnPrint = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TxtSelQty = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.BtnEdit = New System.Windows.Forms.Button()
        Me.TxtTtlItem = New System.Windows.Forms.TextBox()
        Me.BtnAdd = New System.Windows.Forms.Button()
        Me.TxtTglApprove = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.TxtUser = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.BtnCancel = New System.Windows.Forms.Button()
        Me.TxtNamaBarang = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TxtJenisStock = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.BtnFindNoAdj = New System.Windows.Forms.Button()
        Me.BtnFindNo = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TxtNoLock = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TxtTglSo = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TxtNoAdj = New System.Windows.Forms.TextBox()
        Me.TxtSelRp = New System.Windows.Forms.TextBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DgSO = New System.Windows.Forms.DataGridView()
        Me.BtnApprove = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DgSO, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BtnSave
        '
        Me.BtnSave.BackColor = System.Drawing.Color.Transparent
        Me.BtnSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Cyan
        Me.BtnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSave.ForeColor = System.Drawing.Color.Black
        Me.BtnSave.Location = New System.Drawing.Point(214, 472)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(102, 41)
        Me.BtnSave.TabIndex = 207
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
        Me.BtnPrint.Location = New System.Drawing.Point(523, 472)
        Me.BtnPrint.Name = "BtnPrint"
        Me.BtnPrint.Size = New System.Drawing.Size(102, 41)
        Me.BtnPrint.TabIndex = 199
        Me.BtnPrint.Text = "&Print"
        Me.BtnPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnPrint.UseVisualStyleBackColor = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(681, 500)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(129, 19)
        Me.Label9.TabIndex = 196
        Me.Label9.Text = "TOTA SELISIH QTY"
        '
        'TxtSelQty
        '
        Me.TxtSelQty.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.TxtSelQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSelQty.Location = New System.Drawing.Point(826, 497)
        Me.TxtSelQty.Name = "TxtSelQty"
        Me.TxtSelQty.ReadOnly = True
        Me.TxtSelQty.Size = New System.Drawing.Size(153, 21)
        Me.TxtSelQty.TabIndex = 195
        Me.TxtSelQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(681, 473)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(90, 19)
        Me.Label8.TabIndex = 194
        Me.Label8.Text = "TOTAL ITEM"
        '
        'BtnEdit
        '
        Me.BtnEdit.BackColor = System.Drawing.Color.Transparent
        Me.BtnEdit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Cyan
        Me.BtnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnEdit.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnEdit.ForeColor = System.Drawing.Color.Black
        Me.BtnEdit.Location = New System.Drawing.Point(111, 472)
        Me.BtnEdit.Name = "BtnEdit"
        Me.BtnEdit.Size = New System.Drawing.Size(102, 41)
        Me.BtnEdit.TabIndex = 208
        Me.BtnEdit.Text = "&Edit"
        Me.BtnEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnEdit.UseVisualStyleBackColor = False
        '
        'TxtTtlItem
        '
        Me.TxtTtlItem.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.TxtTtlItem.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTtlItem.Location = New System.Drawing.Point(826, 471)
        Me.TxtTtlItem.Name = "TxtTtlItem"
        Me.TxtTtlItem.ReadOnly = True
        Me.TxtTtlItem.Size = New System.Drawing.Size(153, 21)
        Me.TxtTtlItem.TabIndex = 193
        Me.TxtTtlItem.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'BtnAdd
        '
        Me.BtnAdd.BackColor = System.Drawing.Color.Transparent
        Me.BtnAdd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Cyan
        Me.BtnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnAdd.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnAdd.ForeColor = System.Drawing.Color.Black
        Me.BtnAdd.Location = New System.Drawing.Point(8, 472)
        Me.BtnAdd.Name = "BtnAdd"
        Me.BtnAdd.Size = New System.Drawing.Size(102, 41)
        Me.BtnAdd.TabIndex = 200
        Me.BtnAdd.Text = "&Add"
        Me.BtnAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnAdd.UseVisualStyleBackColor = False
        '
        'TxtTglApprove
        '
        Me.TxtTglApprove.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.TxtTglApprove.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTglApprove.Location = New System.Drawing.Point(815, 30)
        Me.TxtTglApprove.Name = "TxtTglApprove"
        Me.TxtTglApprove.ReadOnly = True
        Me.TxtTglApprove.Size = New System.Drawing.Size(153, 21)
        Me.TxtTglApprove.TabIndex = 21
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(681, 526)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(127, 19)
        Me.Label14.TabIndex = 198
        Me.Label14.Text = "TOTAL SELISIH RP"
        '
        'TxtUser
        '
        Me.TxtUser.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.TxtUser.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtUser.Location = New System.Drawing.Point(815, 4)
        Me.TxtUser.Name = "TxtUser"
        Me.TxtUser.ReadOnly = True
        Me.TxtUser.Size = New System.Drawing.Size(153, 21)
        Me.TxtUser.TabIndex = 20
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(703, 5)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(44, 19)
        Me.Label7.TabIndex = 19
        Me.Label7.Text = "USER"
        '
        'BtnCancel
        '
        Me.BtnCancel.BackColor = System.Drawing.Color.Transparent
        Me.BtnCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Cyan
        Me.BtnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCancel.ForeColor = System.Drawing.Color.Black
        Me.BtnCancel.Location = New System.Drawing.Point(317, 472)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(102, 41)
        Me.BtnCancel.TabIndex = 206
        Me.BtnCancel.Text = "&Cancel"
        Me.BtnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnCancel.UseVisualStyleBackColor = False
        '
        'TxtNamaBarang
        '
        Me.TxtNamaBarang.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.TxtNamaBarang.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNamaBarang.Location = New System.Drawing.Point(138, 151)
        Me.TxtNamaBarang.Name = "TxtNamaBarang"
        Me.TxtNamaBarang.ReadOnly = True
        Me.TxtNamaBarang.Size = New System.Drawing.Size(389, 21)
        Me.TxtNamaBarang.TabIndex = 203
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(6, 151)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(117, 19)
        Me.Label5.TabIndex = 201
        Me.Label5.Text = "NAMA BARANG"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(5, 61)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(127, 19)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "NO ADJUSTMENT"
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.TxtJenisStock)
        Me.Panel1.Controls.Add(Me.Label10)
        Me.Panel1.Controls.Add(Me.BtnFindNoAdj)
        Me.Panel1.Controls.Add(Me.BtnFindNo)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.TxtNoLock)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.TxtTglSo)
        Me.Panel1.Controls.Add(Me.TxtTglApprove)
        Me.Panel1.Controls.Add(Me.TxtUser)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.TxtNoAdj)
        Me.Panel1.Location = New System.Drawing.Point(0, 55)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(983, 90)
        Me.Panel1.TabIndex = 191
        '
        'TxtJenisStock
        '
        Me.TxtJenisStock.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.TxtJenisStock.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtJenisStock.Location = New System.Drawing.Point(815, 57)
        Me.TxtJenisStock.Name = "TxtJenisStock"
        Me.TxtJenisStock.ReadOnly = True
        Me.TxtJenisStock.Size = New System.Drawing.Size(153, 21)
        Me.TxtJenisStock.TabIndex = 216
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(703, 60)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(93, 19)
        Me.Label10.TabIndex = 215
        Me.Label10.Text = "JENIS STOCK"
        '
        'BtnFindNoAdj
        '
        Me.BtnFindNoAdj.BackColor = System.Drawing.Color.Transparent
        Me.BtnFindNoAdj.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Cyan
        Me.BtnFindNoAdj.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnFindNoAdj.ForeColor = System.Drawing.Color.Black
        Me.BtnFindNoAdj.Location = New System.Drawing.Point(283, 59)
        Me.BtnFindNoAdj.Name = "BtnFindNoAdj"
        Me.BtnFindNoAdj.Size = New System.Drawing.Size(38, 21)
        Me.BtnFindNoAdj.TabIndex = 214
        Me.BtnFindNoAdj.Text = "..."
        Me.BtnFindNoAdj.UseVisualStyleBackColor = False
        '
        'BtnFindNo
        '
        Me.BtnFindNo.BackColor = System.Drawing.Color.Transparent
        Me.BtnFindNo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Cyan
        Me.BtnFindNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnFindNo.ForeColor = System.Drawing.Color.Black
        Me.BtnFindNo.Location = New System.Drawing.Point(283, 6)
        Me.BtnFindNo.Name = "BtnFindNo"
        Me.BtnFindNo.Size = New System.Drawing.Size(38, 21)
        Me.BtnFindNo.TabIndex = 213
        Me.BtnFindNo.Text = "..."
        Me.BtnFindNo.UseVisualStyleBackColor = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(5, 8)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(93, 19)
        Me.Label4.TabIndex = 26
        Me.Label4.Text = "NO LOCK SO"
        '
        'TxtNoLock
        '
        Me.TxtNoLock.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.TxtNoLock.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNoLock.Location = New System.Drawing.Point(136, 6)
        Me.TxtNoLock.Name = "TxtNoLock"
        Me.TxtNoLock.ReadOnly = True
        Me.TxtNoLock.Size = New System.Drawing.Size(141, 21)
        Me.TxtNoLock.TabIndex = 25
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(5, 34)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(96, 19)
        Me.Label2.TabIndex = 24
        Me.Label2.Text = "TGL LOCK SO"
        '
        'TxtTglSo
        '
        Me.TxtTglSo.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.TxtTglSo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTglSo.Location = New System.Drawing.Point(136, 32)
        Me.TxtTglSo.Name = "TxtTglSo"
        Me.TxtTglSo.ReadOnly = True
        Me.TxtTglSo.Size = New System.Drawing.Size(141, 21)
        Me.TxtTglSo.TabIndex = 23
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(703, 33)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(89, 19)
        Me.Label6.TabIndex = 17
        Me.Label6.Text = "TGL ADJUST"
        '
        'TxtNoAdj
        '
        Me.TxtNoAdj.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.TxtNoAdj.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNoAdj.Location = New System.Drawing.Point(136, 59)
        Me.TxtNoAdj.Name = "TxtNoAdj"
        Me.TxtNoAdj.ReadOnly = True
        Me.TxtNoAdj.Size = New System.Drawing.Size(141, 21)
        Me.TxtNoAdj.TabIndex = 10
        '
        'TxtSelRp
        '
        Me.TxtSelRp.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.TxtSelRp.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSelRp.Location = New System.Drawing.Point(826, 523)
        Me.TxtSelRp.Name = "TxtSelRp"
        Me.TxtSelRp.ReadOnly = True
        Me.TxtSelRp.Size = New System.Drawing.Size(153, 21)
        Me.TxtSelRp.TabIndex = 197
        Me.TxtSelRp.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(983, 49)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 211
        Me.PictureBox1.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label1.Font = New System.Drawing.Font("Britannic Bold", 20.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(343, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(361, 30)
        Me.Label1.TabIndex = 212
        Me.Label1.Text = "ADJUSTMENT STOCK OPNAME"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'DgSO
        '
        Me.DgSO.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgSO.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DgSO.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Navy
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgSO.DefaultCellStyle = DataGridViewCellStyle2
        Me.DgSO.Location = New System.Drawing.Point(0, 178)
        Me.DgSO.Name = "DgSO"
        Me.DgSO.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders
        Me.DgSO.Size = New System.Drawing.Size(983, 286)
        Me.DgSO.TabIndex = 235
        '
        'BtnApprove
        '
        Me.BtnApprove.BackColor = System.Drawing.Color.Transparent
        Me.BtnApprove.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Cyan
        Me.BtnApprove.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnApprove.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnApprove.ForeColor = System.Drawing.Color.Black
        Me.BtnApprove.Location = New System.Drawing.Point(420, 472)
        Me.BtnApprove.Name = "BtnApprove"
        Me.BtnApprove.Size = New System.Drawing.Size(102, 41)
        Me.BtnApprove.TabIndex = 236
        Me.BtnApprove.Text = "Appro&val"
        Me.BtnApprove.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnApprove.UseVisualStyleBackColor = False
        '
        'FrmAdjustmentManual
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(983, 550)
        Me.Controls.Add(Me.BtnApprove)
        Me.Controls.Add(Me.DgSO)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.BtnSave)
        Me.Controls.Add(Me.BtnPrint)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.TxtSelQty)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.BtnEdit)
        Me.Controls.Add(Me.TxtTtlItem)
        Me.Controls.Add(Me.BtnAdd)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.BtnCancel)
        Me.Controls.Add(Me.TxtNamaBarang)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.TxtSelRp)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmAdjustmentManual"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmAdjustmentManual"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DgSO, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BtnSave As System.Windows.Forms.Button
    Friend WithEvents BtnPrint As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents TxtSelQty As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents BtnEdit As System.Windows.Forms.Button
    Friend WithEvents TxtTtlItem As System.Windows.Forms.TextBox
    Friend WithEvents BtnAdd As System.Windows.Forms.Button
    Friend WithEvents TxtTglApprove As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents TxtUser As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents BtnCancel As System.Windows.Forms.Button
    Friend WithEvents TxtNamaBarang As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TxtNoAdj As System.Windows.Forms.TextBox
    Friend WithEvents TxtSelRp As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtTglSo As System.Windows.Forms.TextBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents BtnFindNo As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TxtNoLock As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DgSO As System.Windows.Forms.DataGridView
    Friend WithEvents BtnApprove As System.Windows.Forms.Button
    Friend WithEvents BtnFindNoAdj As System.Windows.Forms.Button
    Friend WithEvents TxtJenisStock As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
End Class
