<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRRAK
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
        Me.btnFindToko = New System.Windows.Forms.Button()
        Me.txtnamatoko = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TxtKodetoko = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.CbJenis = New System.Windows.Forms.ComboBox()
        Me.BtnNoRRAK = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtNoRRAK = New System.Windows.Forms.TextBox()
        Me.BtnTampil = New System.Windows.Forms.Button()
        Me.DgSO = New System.Windows.Forms.DataGridView()
        Me.BtnEdit = New System.Windows.Forms.Button()
        Me.BtnSave = New System.Windows.Forms.Button()
        Me.BtnCancel = New System.Windows.Forms.Button()
        Me.BtnApproval = New System.Windows.Forms.Button()
        Me.txtjenis = New System.Windows.Forms.TextBox()
        Me.txttotal = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.BtnPrint = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txttotselisih = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtket = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtvia = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtkesalahanrrak = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtpengembalian = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.DgSO, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnFindToko
        '
        Me.btnFindToko.BackColor = System.Drawing.Color.Transparent
        Me.btnFindToko.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnFindToko.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFindToko.ForeColor = System.Drawing.Color.Black
        Me.btnFindToko.Location = New System.Drawing.Point(641, 17)
        Me.btnFindToko.Margin = New System.Windows.Forms.Padding(4)
        Me.btnFindToko.Name = "btnFindToko"
        Me.btnFindToko.Size = New System.Drawing.Size(51, 25)
        Me.btnFindToko.TabIndex = 22
        Me.btnFindToko.Text = "..."
        Me.btnFindToko.UseVisualStyleBackColor = False
        '
        'txtnamatoko
        '
        Me.txtnamatoko.Location = New System.Drawing.Point(203, 17)
        Me.txtnamatoko.Margin = New System.Windows.Forms.Padding(4)
        Me.txtnamatoko.Name = "txtnamatoko"
        Me.txtnamatoko.Size = New System.Drawing.Size(431, 22)
        Me.txtnamatoko.TabIndex = 21
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(7, 17)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(57, 24)
        Me.Label2.TabIndex = 20
        Me.Label2.Text = "TOKO"
        '
        'TxtKodetoko
        '
        Me.TxtKodetoko.Location = New System.Drawing.Point(84, 17)
        Me.TxtKodetoko.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtKodetoko.Name = "TxtKodetoko"
        Me.TxtKodetoko.Size = New System.Drawing.Size(112, 22)
        Me.TxtKodetoko.TabIndex = 19
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(17, 11)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(218, 39)
        Me.Label1.TabIndex = 168
        Me.Label1.Text = "RRAK TOKO"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(1332, 62)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 167
        Me.PictureBox1.TabStop = False
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.CbJenis)
        Me.Panel1.Controls.Add(Me.BtnNoRRAK)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.btnFindToko)
        Me.Panel1.Controls.Add(Me.txtNoRRAK)
        Me.Panel1.Controls.Add(Me.txtnamatoko)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.TxtKodetoko)
        Me.Panel1.Location = New System.Drawing.Point(1, 63)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1327, 66)
        Me.Panel1.TabIndex = 169
        '
        'CbJenis
        '
        Me.CbJenis.FormattingEnabled = True
        Me.CbJenis.Location = New System.Drawing.Point(761, 17)
        Me.CbJenis.Margin = New System.Windows.Forms.Padding(4)
        Me.CbJenis.Name = "CbJenis"
        Me.CbJenis.Size = New System.Drawing.Size(199, 24)
        Me.CbJenis.TabIndex = 173
        '
        'BtnNoRRAK
        '
        Me.BtnNoRRAK.BackColor = System.Drawing.Color.Transparent
        Me.BtnNoRRAK.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnNoRRAK.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnNoRRAK.ForeColor = System.Drawing.Color.Black
        Me.BtnNoRRAK.Location = New System.Drawing.Point(1263, 17)
        Me.BtnNoRRAK.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnNoRRAK.Name = "BtnNoRRAK"
        Me.BtnNoRRAK.Size = New System.Drawing.Size(51, 25)
        Me.BtnNoRRAK.TabIndex = 172
        Me.BtnNoRRAK.Text = "..."
        Me.BtnNoRRAK.UseVisualStyleBackColor = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(1015, 17)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(42, 24)
        Me.Label3.TabIndex = 171
        Me.Label3.Text = "NO."
        '
        'txtNoRRAK
        '
        Me.txtNoRRAK.Location = New System.Drawing.Point(1068, 17)
        Me.txtNoRRAK.Margin = New System.Windows.Forms.Padding(4)
        Me.txtNoRRAK.Name = "txtNoRRAK"
        Me.txtNoRRAK.Size = New System.Drawing.Size(185, 22)
        Me.txtNoRRAK.TabIndex = 170
        '
        'BtnTampil
        '
        Me.BtnTampil.BackColor = System.Drawing.Color.Transparent
        Me.BtnTampil.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnTampil.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnTampil.ForeColor = System.Drawing.Color.Black
        Me.BtnTampil.Location = New System.Drawing.Point(15, 585)
        Me.BtnTampil.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnTampil.Name = "BtnTampil"
        Me.BtnTampil.Size = New System.Drawing.Size(126, 50)
        Me.BtnTampil.TabIndex = 173
        Me.BtnTampil.Text = "Pre&view"
        Me.BtnTampil.UseVisualStyleBackColor = False
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
        Me.DgSO.Location = New System.Drawing.Point(0, 137)
        Me.DgSO.Margin = New System.Windows.Forms.Padding(4)
        Me.DgSO.Name = "DgSO"
        Me.DgSO.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders
        Me.DgSO.Size = New System.Drawing.Size(1332, 434)
        Me.DgSO.TabIndex = 236
        '
        'BtnEdit
        '
        Me.BtnEdit.BackColor = System.Drawing.Color.Transparent
        Me.BtnEdit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Cyan
        Me.BtnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnEdit.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnEdit.ForeColor = System.Drawing.Color.Black
        Me.BtnEdit.Location = New System.Drawing.Point(149, 586)
        Me.BtnEdit.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnEdit.Name = "BtnEdit"
        Me.BtnEdit.Size = New System.Drawing.Size(114, 50)
        Me.BtnEdit.TabIndex = 240
        Me.BtnEdit.Text = "&Edit"
        Me.BtnEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnEdit.UseVisualStyleBackColor = False
        '
        'BtnSave
        '
        Me.BtnSave.BackColor = System.Drawing.Color.Transparent
        Me.BtnSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Cyan
        Me.BtnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSave.ForeColor = System.Drawing.Color.Black
        Me.BtnSave.Location = New System.Drawing.Point(265, 586)
        Me.BtnSave.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(114, 50)
        Me.BtnSave.TabIndex = 239
        Me.BtnSave.Text = "&Save"
        Me.BtnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnSave.UseVisualStyleBackColor = False
        '
        'BtnCancel
        '
        Me.BtnCancel.BackColor = System.Drawing.Color.Transparent
        Me.BtnCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Cyan
        Me.BtnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCancel.ForeColor = System.Drawing.Color.Black
        Me.BtnCancel.Location = New System.Drawing.Point(497, 586)
        Me.BtnCancel.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(122, 50)
        Me.BtnCancel.TabIndex = 238
        Me.BtnCancel.Text = "&Cancel"
        Me.BtnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnCancel.UseVisualStyleBackColor = False
        '
        'BtnApproval
        '
        Me.BtnApproval.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.BtnApproval.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Cyan
        Me.BtnApproval.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnApproval.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnApproval.ForeColor = System.Drawing.Color.Black
        Me.BtnApproval.Location = New System.Drawing.Point(646, 586)
        Me.BtnApproval.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnApproval.Name = "BtnApproval"
        Me.BtnApproval.Size = New System.Drawing.Size(137, 49)
        Me.BtnApproval.TabIndex = 237
        Me.BtnApproval.Text = "Appr&oval"
        Me.BtnApproval.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnApproval.UseVisualStyleBackColor = False
        '
        'txtjenis
        '
        Me.txtjenis.Location = New System.Drawing.Point(1112, 28)
        Me.txtjenis.Margin = New System.Windows.Forms.Padding(4)
        Me.txtjenis.Name = "txtjenis"
        Me.txtjenis.Size = New System.Drawing.Size(185, 22)
        Me.txtjenis.TabIndex = 241
        Me.txtjenis.Visible = False
        '
        'txttotal
        '
        Me.txttotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txttotal.Location = New System.Drawing.Point(1131, 586)
        Me.txttotal.Margin = New System.Windows.Forms.Padding(4)
        Me.txttotal.Name = "txttotal"
        Me.txttotal.Size = New System.Drawing.Size(185, 24)
        Me.txttotal.TabIndex = 242
        Me.txttotal.Text = "0"
        Me.txttotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(1053, 585)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(51, 24)
        Me.Label5.TabIndex = 244
        Me.Label5.Text = "Total"
        '
        'BtnPrint
        '
        Me.BtnPrint.BackColor = System.Drawing.Color.Transparent
        Me.BtnPrint.Enabled = False
        Me.BtnPrint.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Cyan
        Me.BtnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnPrint.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnPrint.ForeColor = System.Drawing.Color.Black
        Me.BtnPrint.Location = New System.Drawing.Point(381, 586)
        Me.BtnPrint.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnPrint.Name = "BtnPrint"
        Me.BtnPrint.Size = New System.Drawing.Size(114, 50)
        Me.BtnPrint.TabIndex = 259
        Me.BtnPrint.Text = "&Print"
        Me.BtnPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnPrint.UseVisualStyleBackColor = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(964, 618)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(140, 24)
        Me.Label4.TabIndex = 261
        Me.Label4.Text = "Selisih Realisasi"
        Me.Label4.Visible = False
        '
        'txttotselisih
        '
        Me.txttotselisih.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txttotselisih.Location = New System.Drawing.Point(1131, 618)
        Me.txttotselisih.Margin = New System.Windows.Forms.Padding(4)
        Me.txttotselisih.Name = "txttotselisih"
        Me.txttotselisih.Size = New System.Drawing.Size(185, 24)
        Me.txttotselisih.TabIndex = 260
        Me.txttotselisih.Text = "0"
        Me.txttotselisih.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txttotselisih.Visible = False
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.GroupBox1.Controls.Add(Me.txtket)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.txtvia)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.txtkesalahanrrak)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.txtpengembalian)
        Me.GroupBox1.Location = New System.Drawing.Point(4, 654)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1327, 116)
        Me.GroupBox1.TabIndex = 267
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Visible = False
        '
        'txtket
        '
        Me.txtket.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtket.Enabled = False
        Me.txtket.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtket.Location = New System.Drawing.Point(10, 32)
        Me.txtket.Margin = New System.Windows.Forms.Padding(4)
        Me.txtket.Multiline = True
        Me.txtket.Name = "txtket"
        Me.txtket.Size = New System.Drawing.Size(865, 70)
        Me.txtket.TabIndex = 269
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Calibri", 10.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(7, 4)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(192, 23)
        Me.Label9.TabIndex = 274
        Me.Label9.Text = "Keterangan Untuk Toko"
        '
        'txtvia
        '
        Me.txtvia.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtvia.Location = New System.Drawing.Point(1127, 44)
        Me.txtvia.Margin = New System.Windows.Forms.Padding(4)
        Me.txtvia.Name = "txtvia"
        Me.txtvia.Size = New System.Drawing.Size(185, 24)
        Me.txtvia.TabIndex = 268
        Me.txtvia.Text = "Transfer/Cash"
        Me.txtvia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(954, 78)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(146, 24)
        Me.Label8.TabIndex = 272
        Me.Label8.Text = "Kesalahan RRAK"
        '
        'txtkesalahanrrak
        '
        Me.txtkesalahanrrak.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtkesalahanrrak.Location = New System.Drawing.Point(1127, 78)
        Me.txtkesalahanrrak.Margin = New System.Windows.Forms.Padding(4)
        Me.txtkesalahanrrak.Name = "txtkesalahanrrak"
        Me.txtkesalahanrrak.Size = New System.Drawing.Size(185, 24)
        Me.txtkesalahanrrak.TabIndex = 271
        Me.txtkesalahanrrak.Text = "0"
        Me.txtkesalahanrrak.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(1063, 44)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(37, 24)
        Me.Label7.TabIndex = 269
        Me.Label7.Text = "Via"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(971, 15)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(129, 24)
        Me.Label6.TabIndex = 268
        Me.Label6.Text = "Pengembalian"
        '
        'txtpengembalian
        '
        Me.txtpengembalian.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtpengembalian.Location = New System.Drawing.Point(1127, 16)
        Me.txtpengembalian.Margin = New System.Windows.Forms.Padding(4)
        Me.txtpengembalian.Name = "txtpengembalian"
        Me.txtpengembalian.Size = New System.Drawing.Size(185, 24)
        Me.txtpengembalian.TabIndex = 267
        Me.txtpengembalian.Text = "0"
        Me.txtpengembalian.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Cyan
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.Black
        Me.Button1.Location = New System.Drawing.Point(791, 586)
        Me.Button1.Margin = New System.Windows.Forms.Padding(4)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(137, 49)
        Me.Button1.TabIndex = 268
        Me.Button1.Text = "&Pembatalan"
        Me.Button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button1.UseVisualStyleBackColor = False
        '
        'FrmRRAK
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(1332, 782)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txttotselisih)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txttotal)
        Me.Controls.Add(Me.txtjenis)
        Me.Controls.Add(Me.BtnEdit)
        Me.Controls.Add(Me.BtnApproval)
        Me.Controls.Add(Me.DgSO)
        Me.Controls.Add(Me.BtnCancel)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.BtnSave)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.BtnTampil)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.BtnPrint)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmRRAK"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmRRAK"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.DgSO, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnFindToko As System.Windows.Forms.Button
    Friend WithEvents txtnamatoko As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtKodetoko As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents BtnTampil As System.Windows.Forms.Button
    Friend WithEvents BtnNoRRAK As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtNoRRAK As System.Windows.Forms.TextBox
    Friend WithEvents DgSO As System.Windows.Forms.DataGridView
    Friend WithEvents BtnEdit As System.Windows.Forms.Button
    Friend WithEvents BtnSave As System.Windows.Forms.Button
    Friend WithEvents BtnCancel As System.Windows.Forms.Button
    Friend WithEvents BtnApproval As System.Windows.Forms.Button
    Friend WithEvents txtjenis As System.Windows.Forms.TextBox
    Friend WithEvents CbJenis As System.Windows.Forms.ComboBox
    Friend WithEvents txttotal As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents BtnPrint As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txttotselisih As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtpengembalian As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtkesalahanrrak As System.Windows.Forms.TextBox
    Friend WithEvents txtvia As System.Windows.Forms.TextBox
    Friend WithEvents txtket As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
