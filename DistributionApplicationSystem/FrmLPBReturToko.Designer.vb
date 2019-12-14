<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmLPBReturToko
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
        Me.BtnFindNoLpb = New System.Windows.Forms.Button()
        Me.TxtTglRetur = New System.Windows.Forms.TextBox()
        Me.TxtTglTerima = New System.Windows.Forms.TextBox()
        Me.TxtUser = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TxtNoLPB = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.BtnFindNoRetur = New System.Windows.Forms.Button()
        Me.TxtNoReturToko = New System.Windows.Forms.TextBox()
        Me.BtnFindToko = New System.Windows.Forms.Button()
        Me.TxtNamaToko = New System.Windows.Forms.TextBox()
        Me.TxtKodeToko = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TxtTotalItem = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TxtTotalQty = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TxtTotalQtyBS = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.TxtTotalQtyGS = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.TxtAvgCost = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.TxtNetto = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.TxtTotalRetur = New System.Windows.Forms.TextBox()
        Me.BtnCancel = New System.Windows.Forms.Button()
        Me.BtnAdd = New System.Windows.Forms.Button()
        Me.BtnPrint = New System.Windows.Forms.Button()
        Me.BtnSave = New System.Windows.Forms.Button()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label1.Font = New System.Drawing.Font("Britannic Bold", 20.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(80, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(655, 30)
        Me.Label1.TabIndex = 101
        Me.Label1.Text = "LAPORAN PENERIMAAN BARANG ( LPB ) - RETUR TOKO"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(1057, 49)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 100
        Me.PictureBox1.TabStop = False
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.BtnFindNoLpb)
        Me.Panel1.Controls.Add(Me.TxtTglRetur)
        Me.Panel1.Controls.Add(Me.TxtTglTerima)
        Me.Panel1.Controls.Add(Me.TxtUser)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.TxtNoLPB)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.BtnFindNoRetur)
        Me.Panel1.Controls.Add(Me.TxtNoReturToko)
        Me.Panel1.Controls.Add(Me.BtnFindToko)
        Me.Panel1.Controls.Add(Me.TxtNamaToko)
        Me.Panel1.Controls.Add(Me.TxtKodeToko)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Location = New System.Drawing.Point(1, 52)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1072, 87)
        Me.Panel1.TabIndex = 102
        '
        'BtnFindNoLpb
        '
        Me.BtnFindNoLpb.BackColor = System.Drawing.Color.Transparent
        Me.BtnFindNoLpb.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Cyan
        Me.BtnFindNoLpb.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnFindNoLpb.ForeColor = System.Drawing.Color.Black
        Me.BtnFindNoLpb.Location = New System.Drawing.Point(352, 56)
        Me.BtnFindNoLpb.Name = "BtnFindNoLpb"
        Me.BtnFindNoLpb.Size = New System.Drawing.Size(38, 21)
        Me.BtnFindNoLpb.TabIndex = 23
        Me.BtnFindNoLpb.Text = "..."
        Me.BtnFindNoLpb.UseVisualStyleBackColor = False
        '
        'TxtTglRetur
        '
        Me.TxtTglRetur.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.TxtTglRetur.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTglRetur.Location = New System.Drawing.Point(860, 30)
        Me.TxtTglRetur.Name = "TxtTglRetur"
        Me.TxtTglRetur.ReadOnly = True
        Me.TxtTglRetur.Size = New System.Drawing.Size(185, 21)
        Me.TxtTglRetur.TabIndex = 22
        '
        'TxtTglTerima
        '
        Me.TxtTglTerima.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.TxtTglTerima.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTglTerima.Location = New System.Drawing.Point(860, 56)
        Me.TxtTglTerima.Name = "TxtTglTerima"
        Me.TxtTglTerima.ReadOnly = True
        Me.TxtTglTerima.Size = New System.Drawing.Size(185, 21)
        Me.TxtTglTerima.TabIndex = 21
        '
        'TxtUser
        '
        Me.TxtUser.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.TxtUser.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtUser.Location = New System.Drawing.Point(860, 4)
        Me.TxtUser.Name = "TxtUser"
        Me.TxtUser.ReadOnly = True
        Me.TxtUser.Size = New System.Drawing.Size(185, 21)
        Me.TxtUser.TabIndex = 20
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(762, 5)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(44, 19)
        Me.Label7.TabIndex = 19
        Me.Label7.Text = "USER"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(762, 59)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(91, 19)
        Me.Label6.TabIndex = 17
        Me.Label6.Text = "TGL TERIMA"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(5, 58)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(64, 19)
        Me.Label5.TabIndex = 16
        Me.Label5.Text = "NO. LPB"
        '
        'TxtNoLPB
        '
        Me.TxtNoLPB.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.TxtNoLPB.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNoLPB.Location = New System.Drawing.Point(133, 56)
        Me.TxtNoLPB.Name = "TxtNoLPB"
        Me.TxtNoLPB.ReadOnly = True
        Me.TxtNoLPB.Size = New System.Drawing.Size(213, 21)
        Me.TxtNoLPB.TabIndex = 15
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(762, 32)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(82, 19)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "TGL RETUR"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(5, 31)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(121, 19)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "NO.RETUR TOKO"
        '
        'BtnFindNoRetur
        '
        Me.BtnFindNoRetur.BackColor = System.Drawing.Color.Transparent
        Me.BtnFindNoRetur.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Cyan
        Me.BtnFindNoRetur.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnFindNoRetur.ForeColor = System.Drawing.Color.Black
        Me.BtnFindNoRetur.Location = New System.Drawing.Point(280, 29)
        Me.BtnFindNoRetur.Name = "BtnFindNoRetur"
        Me.BtnFindNoRetur.Size = New System.Drawing.Size(38, 21)
        Me.BtnFindNoRetur.TabIndex = 11
        Me.BtnFindNoRetur.Text = "..."
        Me.BtnFindNoRetur.UseVisualStyleBackColor = False
        '
        'TxtNoReturToko
        '
        Me.TxtNoReturToko.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.TxtNoReturToko.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNoReturToko.Location = New System.Drawing.Point(133, 29)
        Me.TxtNoReturToko.Name = "TxtNoReturToko"
        Me.TxtNoReturToko.ReadOnly = True
        Me.TxtNoReturToko.Size = New System.Drawing.Size(141, 21)
        Me.TxtNoReturToko.TabIndex = 10
        '
        'BtnFindToko
        '
        Me.BtnFindToko.BackColor = System.Drawing.Color.Transparent
        Me.BtnFindToko.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Cyan
        Me.BtnFindToko.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnFindToko.ForeColor = System.Drawing.Color.Black
        Me.BtnFindToko.Location = New System.Drawing.Point(507, 3)
        Me.BtnFindToko.Name = "BtnFindToko"
        Me.BtnFindToko.Size = New System.Drawing.Size(38, 21)
        Me.BtnFindToko.TabIndex = 9
        Me.BtnFindToko.Text = "..."
        Me.BtnFindToko.UseVisualStyleBackColor = False
        '
        'TxtNamaToko
        '
        Me.TxtNamaToko.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.TxtNamaToko.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNamaToko.Location = New System.Drawing.Point(216, 3)
        Me.TxtNamaToko.Name = "TxtNamaToko"
        Me.TxtNamaToko.ReadOnly = True
        Me.TxtNamaToko.Size = New System.Drawing.Size(285, 21)
        Me.TxtNamaToko.TabIndex = 8
        '
        'TxtKodeToko
        '
        Me.TxtKodeToko.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.TxtKodeToko.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtKodeToko.Location = New System.Drawing.Point(133, 3)
        Me.TxtKodeToko.Name = "TxtKodeToko"
        Me.TxtKodeToko.ReadOnly = True
        Me.TxtKodeToko.Size = New System.Drawing.Size(77, 21)
        Me.TxtKodeToko.TabIndex = 7
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(5, 3)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(96, 19)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "NAMA TOKO"
        '
        'ListView1
        '
        Me.ListView1.Location = New System.Drawing.Point(2, 141)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(1055, 257)
        Me.ListView1.TabIndex = 103
        Me.ListView1.UseCompatibleStateImageBehavior = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(539, 406)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(90, 19)
        Me.Label8.TabIndex = 105
        Me.Label8.Text = "TOTAL ITEM"
        '
        'TxtTotalItem
        '
        Me.TxtTotalItem.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.TxtTotalItem.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTotalItem.Location = New System.Drawing.Point(647, 404)
        Me.TxtTotalItem.Name = "TxtTotalItem"
        Me.TxtTotalItem.ReadOnly = True
        Me.TxtTotalItem.Size = New System.Drawing.Size(137, 21)
        Me.TxtTotalItem.TabIndex = 104
        Me.TxtTotalItem.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(539, 431)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(83, 19)
        Me.Label9.TabIndex = 107
        Me.Label9.Text = "TOTAL QTY"
        '
        'TxtTotalQty
        '
        Me.TxtTotalQty.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.TxtTotalQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTotalQty.Location = New System.Drawing.Point(647, 429)
        Me.TxtTotalQty.Name = "TxtTotalQty"
        Me.TxtTotalQty.ReadOnly = True
        Me.TxtTotalQty.Size = New System.Drawing.Size(137, 21)
        Me.TxtTotalQty.TabIndex = 106
        Me.TxtTotalQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(539, 456)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(104, 19)
        Me.Label10.TabIndex = 109
        Me.Label10.Text = "TOTAL QTY BS"
        '
        'TxtTotalQtyBS
        '
        Me.TxtTotalQtyBS.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.TxtTotalQtyBS.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTotalQtyBS.Location = New System.Drawing.Point(647, 454)
        Me.TxtTotalQtyBS.Name = "TxtTotalQtyBS"
        Me.TxtTotalQtyBS.ReadOnly = True
        Me.TxtTotalQtyBS.Size = New System.Drawing.Size(137, 21)
        Me.TxtTotalQtyBS.TabIndex = 108
        Me.TxtTotalQtyBS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(539, 481)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(105, 19)
        Me.Label11.TabIndex = 111
        Me.Label11.Text = "TOTAL QTY GS"
        '
        'TxtTotalQtyGS
        '
        Me.TxtTotalQtyGS.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.TxtTotalQtyGS.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTotalQtyGS.Location = New System.Drawing.Point(647, 479)
        Me.TxtTotalQtyGS.Name = "TxtTotalQtyGS"
        Me.TxtTotalQtyGS.ReadOnly = True
        Me.TxtTotalQtyGS.Size = New System.Drawing.Size(137, 21)
        Me.TxtTotalQtyGS.TabIndex = 110
        Me.TxtTotalQtyGS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(803, 407)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(76, 19)
        Me.Label12.TabIndex = 113
        Me.Label12.Text = "AVG COST"
        '
        'TxtAvgCost
        '
        Me.TxtAvgCost.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.TxtAvgCost.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtAvgCost.Location = New System.Drawing.Point(904, 404)
        Me.TxtAvgCost.Name = "TxtAvgCost"
        Me.TxtAvgCost.ReadOnly = True
        Me.TxtAvgCost.Size = New System.Drawing.Size(143, 21)
        Me.TxtAvgCost.TabIndex = 112
        Me.TxtAvgCost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(803, 431)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(55, 19)
        Me.Label13.TabIndex = 115
        Me.Label13.Text = "NETTO"
        '
        'TxtNetto
        '
        Me.TxtNetto.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.TxtNetto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNetto.Location = New System.Drawing.Point(904, 429)
        Me.TxtNetto.Name = "TxtNetto"
        Me.TxtNetto.ReadOnly = True
        Me.TxtNetto.Size = New System.Drawing.Size(143, 21)
        Me.TxtNetto.TabIndex = 114
        Me.TxtNetto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(803, 456)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(100, 19)
        Me.Label14.TabIndex = 117
        Me.Label14.Text = "TOTAL RETUR"
        '
        'TxtTotalRetur
        '
        Me.TxtTotalRetur.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.TxtTotalRetur.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTotalRetur.Location = New System.Drawing.Point(904, 454)
        Me.TxtTotalRetur.Name = "TxtTotalRetur"
        Me.TxtTotalRetur.ReadOnly = True
        Me.TxtTotalRetur.Size = New System.Drawing.Size(143, 21)
        Me.TxtTotalRetur.TabIndex = 116
        Me.TxtTotalRetur.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'BtnCancel
        '
        Me.BtnCancel.BackColor = System.Drawing.Color.Transparent
        Me.BtnCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Cyan
        Me.BtnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCancel.ForeColor = System.Drawing.Color.Black
        Me.BtnCancel.Location = New System.Drawing.Point(190, 407)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(91, 41)
        Me.BtnCancel.TabIndex = 167
        Me.BtnCancel.Text = "&Cancel"
        Me.BtnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnCancel.UseVisualStyleBackColor = False
        '
        'BtnAdd
        '
        Me.BtnAdd.BackColor = System.Drawing.Color.Transparent
        Me.BtnAdd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Cyan
        Me.BtnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnAdd.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnAdd.ForeColor = System.Drawing.Color.Black
        Me.BtnAdd.Location = New System.Drawing.Point(6, 407)
        Me.BtnAdd.Name = "BtnAdd"
        Me.BtnAdd.Size = New System.Drawing.Size(91, 41)
        Me.BtnAdd.TabIndex = 166
        Me.BtnAdd.Text = "&Add"
        Me.BtnAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnAdd.UseVisualStyleBackColor = False
        '
        'BtnPrint
        '
        Me.BtnPrint.BackColor = System.Drawing.Color.Transparent
        Me.BtnPrint.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Cyan
        Me.BtnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnPrint.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnPrint.ForeColor = System.Drawing.Color.Black
        Me.BtnPrint.Location = New System.Drawing.Point(282, 407)
        Me.BtnPrint.Name = "BtnPrint"
        Me.BtnPrint.Size = New System.Drawing.Size(91, 41)
        Me.BtnPrint.TabIndex = 163
        Me.BtnPrint.Text = "&Print"
        Me.BtnPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnPrint.UseVisualStyleBackColor = False
        '
        'BtnSave
        '
        Me.BtnSave.BackColor = System.Drawing.Color.Transparent
        Me.BtnSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Cyan
        Me.BtnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSave.ForeColor = System.Drawing.Color.Black
        Me.BtnSave.Location = New System.Drawing.Point(98, 407)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(91, 41)
        Me.BtnSave.TabIndex = 167
        Me.BtnSave.Text = "&Save"
        Me.BtnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnSave.UseVisualStyleBackColor = False
        '
        'FrmLPBReturToko
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1057, 505)
        Me.Controls.Add(Me.BtnSave)
        Me.Controls.Add(Me.BtnCancel)
        Me.Controls.Add(Me.BtnAdd)
        Me.Controls.Add(Me.BtnPrint)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.TxtTotalRetur)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.TxtNetto)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.TxtAvgCost)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.TxtTotalQtyGS)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.TxtTotalQtyBS)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.TxtTotalQty)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.TxtTotalItem)
        Me.Controls.Add(Me.ListView1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PictureBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.Name = "FrmLPBReturToko"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmLPBReturToko"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TxtNoLPB As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents BtnFindNoRetur As System.Windows.Forms.Button
    Friend WithEvents TxtNoReturToko As System.Windows.Forms.TextBox
    Friend WithEvents BtnFindToko As System.Windows.Forms.Button
    Friend WithEvents TxtNamaToko As System.Windows.Forms.TextBox
    Friend WithEvents TxtKodeToko As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtUser As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TxtTotalItem As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents TxtTotalQty As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents TxtTotalQtyBS As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents TxtTotalQtyGS As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents TxtAvgCost As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents TxtNetto As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents TxtTotalRetur As System.Windows.Forms.TextBox
    Friend WithEvents TxtTglRetur As System.Windows.Forms.TextBox
    Friend WithEvents TxtTglTerima As System.Windows.Forms.TextBox
    Friend WithEvents BtnCancel As System.Windows.Forms.Button
    Friend WithEvents BtnAdd As System.Windows.Forms.Button
    Friend WithEvents BtnPrint As System.Windows.Forms.Button
    Friend WithEvents BtnSave As System.Windows.Forms.Button
    Friend WithEvents BtnFindNoLpb As System.Windows.Forms.Button
End Class
