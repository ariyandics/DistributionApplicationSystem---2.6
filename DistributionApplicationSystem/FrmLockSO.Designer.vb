<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmLockSO
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
        Me.BtnProses = New System.Windows.Forms.Button()
        Me.BtnPrint = New System.Windows.Forms.Button()
        Me.BtnCancel = New System.Windows.Forms.Button()
        Me.BtnAdd = New System.Windows.Forms.Button()
        Me.Listview2 = New System.Windows.Forms.ListView()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnFind = New System.Windows.Forms.Button()
        Me.CmbTipeStock = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TxtUser = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtTanggal = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.RbAllRak = New System.Windows.Forms.RadioButton()
        Me.RbALlItem = New System.Windows.Forms.RadioButton()
        Me.RbRak = New System.Windows.Forms.RadioButton()
        Me.rbItem = New System.Windows.Forms.RadioButton()
        Me.cmbJenisSO = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbTipeSO = New System.Windows.Forms.ComboBox()
        Me.txtNo = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.txtcari = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.BtnTambah = New System.Windows.Forms.Button()
        Me.BtnHapus = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BtnProses
        '
        Me.BtnProses.BackColor = System.Drawing.Color.Transparent
        Me.BtnProses.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnProses.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnProses.ForeColor = System.Drawing.Color.Black
        Me.BtnProses.Location = New System.Drawing.Point(99, 408)
        Me.BtnProses.Name = "BtnProses"
        Me.BtnProses.Size = New System.Drawing.Size(91, 41)
        Me.BtnProses.TabIndex = 181
        Me.BtnProses.Text = "&Proses"
        Me.BtnProses.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnProses.UseVisualStyleBackColor = False
        '
        'BtnPrint
        '
        Me.BtnPrint.BackColor = System.Drawing.Color.Transparent
        Me.BtnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnPrint.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnPrint.ForeColor = System.Drawing.Color.Black
        Me.BtnPrint.Location = New System.Drawing.Point(281, 408)
        Me.BtnPrint.Name = "BtnPrint"
        Me.BtnPrint.Size = New System.Drawing.Size(91, 41)
        Me.BtnPrint.TabIndex = 180
        Me.BtnPrint.Text = "&Print"
        Me.BtnPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnPrint.UseVisualStyleBackColor = False
        '
        'BtnCancel
        '
        Me.BtnCancel.BackColor = System.Drawing.Color.Transparent
        Me.BtnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCancel.ForeColor = System.Drawing.Color.Black
        Me.BtnCancel.Location = New System.Drawing.Point(190, 408)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(91, 41)
        Me.BtnCancel.TabIndex = 179
        Me.BtnCancel.Text = "&Cancel"
        Me.BtnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnCancel.UseVisualStyleBackColor = False
        '
        'BtnAdd
        '
        Me.BtnAdd.BackColor = System.Drawing.Color.Transparent
        Me.BtnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnAdd.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnAdd.ForeColor = System.Drawing.Color.Black
        Me.BtnAdd.Location = New System.Drawing.Point(8, 408)
        Me.BtnAdd.Name = "BtnAdd"
        Me.BtnAdd.Size = New System.Drawing.Size(91, 41)
        Me.BtnAdd.TabIndex = 178
        Me.BtnAdd.Text = "&Add"
        Me.BtnAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnAdd.UseVisualStyleBackColor = False
        '
        'Listview2
        '
        Me.Listview2.Location = New System.Drawing.Point(378, 96)
        Me.Listview2.Name = "Listview2"
        Me.Listview2.Size = New System.Drawing.Size(356, 357)
        Me.Listview2.TabIndex = 182
        Me.Listview2.UseCompatibleStateImageBehavior = False
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.btnFind)
        Me.Panel1.Controls.Add(Me.CmbTipeStock)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.TxtUser)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.txtTanggal)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Controls.Add(Me.cmbJenisSO)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.cmbTipeSO)
        Me.Panel1.Controls.Add(Me.txtNo)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Location = New System.Drawing.Point(9, 54)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(363, 348)
        Me.Panel1.TabIndex = 183
        '
        'btnFind
        '
        Me.btnFind.BackColor = System.Drawing.Color.Transparent
        Me.btnFind.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnFind.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFind.ForeColor = System.Drawing.Color.Black
        Me.btnFind.Location = New System.Drawing.Point(304, 60)
        Me.btnFind.Name = "btnFind"
        Me.btnFind.Size = New System.Drawing.Size(38, 20)
        Me.btnFind.TabIndex = 190
        Me.btnFind.Text = "..."
        Me.btnFind.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnFind.UseVisualStyleBackColor = False
        '
        'CmbTipeStock
        '
        Me.CmbTipeStock.BackColor = System.Drawing.Color.White
        Me.CmbTipeStock.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbTipeStock.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.CmbTipeStock.FormattingEnabled = True
        Me.CmbTipeStock.Location = New System.Drawing.Point(86, 85)
        Me.CmbTipeStock.Name = "CmbTipeStock"
        Me.CmbTipeStock.Size = New System.Drawing.Size(257, 21)
        Me.CmbTipeStock.TabIndex = 23
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(6, 88)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(74, 15)
        Me.Label7.TabIndex = 22
        Me.Label7.Text = "Tipe Stock"
        '
        'TxtUser
        '
        Me.TxtUser.BackColor = System.Drawing.Color.White
        Me.TxtUser.Location = New System.Drawing.Point(86, 35)
        Me.TxtUser.Name = "TxtUser"
        Me.TxtUser.ReadOnly = True
        Me.TxtUser.Size = New System.Drawing.Size(212, 20)
        Me.TxtUser.TabIndex = 21
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(6, 36)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(37, 15)
        Me.Label6.TabIndex = 20
        Me.Label6.Text = "User"
        '
        'txtTanggal
        '
        Me.txtTanggal.BackColor = System.Drawing.Color.White
        Me.txtTanggal.Location = New System.Drawing.Point(86, 10)
        Me.txtTanggal.Name = "txtTanggal"
        Me.txtTanggal.ReadOnly = True
        Me.txtTanggal.Size = New System.Drawing.Size(212, 20)
        Me.txtTanggal.TabIndex = 19
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(6, 11)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(59, 15)
        Me.Label5.TabIndex = 18
        Me.Label5.Text = "Tanggal"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.RbAllRak)
        Me.GroupBox1.Controls.Add(Me.RbALlItem)
        Me.GroupBox1.Controls.Add(Me.RbRak)
        Me.GroupBox1.Controls.Add(Me.rbItem)
        Me.GroupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GroupBox1.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(13, 227)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(330, 110)
        Me.GroupBox1.TabIndex = 17
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Lock By"
        '
        'RbAllRak
        '
        Me.RbAllRak.AutoSize = True
        Me.RbAllRak.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RbAllRak.Location = New System.Drawing.Point(223, 64)
        Me.RbAllRak.Name = "RbAllRak"
        Me.RbAllRak.Size = New System.Drawing.Size(76, 20)
        Me.RbAllRak.TabIndex = 3
        Me.RbAllRak.TabStop = True
        Me.RbAllRak.Text = "All Rak"
        Me.RbAllRak.UseVisualStyleBackColor = True
        '
        'RbALlItem
        '
        Me.RbALlItem.AutoSize = True
        Me.RbALlItem.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RbALlItem.Location = New System.Drawing.Point(75, 64)
        Me.RbALlItem.Name = "RbALlItem"
        Me.RbALlItem.Size = New System.Drawing.Size(77, 20)
        Me.RbALlItem.TabIndex = 2
        Me.RbALlItem.TabStop = True
        Me.RbALlItem.Text = "All Item"
        Me.RbALlItem.UseVisualStyleBackColor = True
        '
        'RbRak
        '
        Me.RbRak.AutoSize = True
        Me.RbRak.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RbRak.Location = New System.Drawing.Point(223, 28)
        Me.RbRak.Name = "RbRak"
        Me.RbRak.Size = New System.Drawing.Size(76, 20)
        Me.RbRak.TabIndex = 1
        Me.RbRak.TabStop = True
        Me.RbRak.Text = "By Rak"
        Me.RbRak.UseVisualStyleBackColor = True
        '
        'rbItem
        '
        Me.rbItem.AutoSize = True
        Me.rbItem.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbItem.Location = New System.Drawing.Point(75, 25)
        Me.rbItem.Name = "rbItem"
        Me.rbItem.Size = New System.Drawing.Size(77, 20)
        Me.rbItem.TabIndex = 0
        Me.rbItem.TabStop = True
        Me.rbItem.Text = "By Item"
        Me.rbItem.UseVisualStyleBackColor = True
        '
        'cmbJenisSO
        '
        Me.cmbJenisSO.BackColor = System.Drawing.Color.White
        Me.cmbJenisSO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbJenisSO.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmbJenisSO.FormattingEnabled = True
        Me.cmbJenisSO.Location = New System.Drawing.Point(86, 137)
        Me.cmbJenisSO.Name = "cmbJenisSO"
        Me.cmbJenisSO.Size = New System.Drawing.Size(257, 21)
        Me.cmbJenisSO.TabIndex = 16
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(6, 140)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(64, 15)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "Jenis SO"
        '
        'cmbTipeSO
        '
        Me.cmbTipeSO.BackColor = System.Drawing.Color.White
        Me.cmbTipeSO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipeSO.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmbTipeSO.FormattingEnabled = True
        Me.cmbTipeSO.Location = New System.Drawing.Point(86, 111)
        Me.cmbTipeSO.Name = "cmbTipeSO"
        Me.cmbTipeSO.Size = New System.Drawing.Size(257, 21)
        Me.cmbTipeSO.TabIndex = 14
        '
        'txtNo
        '
        Me.txtNo.BackColor = System.Drawing.Color.White
        Me.txtNo.Location = New System.Drawing.Point(86, 60)
        Me.txtNo.Name = "txtNo"
        Me.txtNo.Size = New System.Drawing.Size(212, 20)
        Me.txtNo.TabIndex = 13
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(6, 114)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(60, 15)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "Type SO"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(6, 61)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(52, 15)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "No. SO"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label1.Font = New System.Drawing.Font("Britannic Bold", 20.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(257, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(273, 30)
        Me.Label1.TabIndex = 185
        Me.Label1.Text = "LOCK STOCK OPNAME"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(1154, 50)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 184
        Me.PictureBox1.TabStop = False
        '
        'txtcari
        '
        Me.txtcari.BackColor = System.Drawing.Color.White
        Me.txtcari.Location = New System.Drawing.Point(378, 70)
        Me.txtcari.Name = "txtcari"
        Me.txtcari.Size = New System.Drawing.Size(356, 20)
        Me.txtcari.TabIndex = 24
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(375, 53)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(94, 15)
        Me.Label8.TabIndex = 24
        Me.Label8.Text = "Nama Produk"
        '
        'ListView1
        '
        Me.ListView1.Location = New System.Drawing.Point(791, 72)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(362, 381)
        Me.ListView1.TabIndex = 186
        Me.ListView1.UseCompatibleStateImageBehavior = False
        '
        'BtnTambah
        '
        Me.BtnTambah.BackColor = System.Drawing.Color.Transparent
        Me.BtnTambah.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnTambah.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnTambah.ForeColor = System.Drawing.Color.Black
        Me.BtnTambah.Location = New System.Drawing.Point(743, 157)
        Me.BtnTambah.Name = "BtnTambah"
        Me.BtnTambah.Size = New System.Drawing.Size(38, 41)
        Me.BtnTambah.TabIndex = 187
        Me.BtnTambah.Text = ">>"
        Me.BtnTambah.UseVisualStyleBackColor = False
        '
        'BtnHapus
        '
        Me.BtnHapus.BackColor = System.Drawing.Color.Transparent
        Me.BtnHapus.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnHapus.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnHapus.ForeColor = System.Drawing.Color.Black
        Me.BtnHapus.Location = New System.Drawing.Point(743, 208)
        Me.BtnHapus.Name = "BtnHapus"
        Me.BtnHapus.Size = New System.Drawing.Size(38, 41)
        Me.BtnHapus.TabIndex = 188
        Me.BtnHapus.Text = "><"
        Me.BtnHapus.UseVisualStyleBackColor = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(788, 54)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(116, 15)
        Me.Label9.TabIndex = 189
        Me.Label9.Text = "List data To Lock"
        '
        'FrmLockSO
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1154, 458)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.BtnHapus)
        Me.Controls.Add(Me.BtnTambah)
        Me.Controls.Add(Me.ListView1)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtcari)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Listview2)
        Me.Controls.Add(Me.BtnProses)
        Me.Controls.Add(Me.BtnPrint)
        Me.Controls.Add(Me.BtnCancel)
        Me.Controls.Add(Me.BtnAdd)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.Name = "FrmLockSO"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmLockSO"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BtnProses As System.Windows.Forms.Button
    Friend WithEvents BtnPrint As System.Windows.Forms.Button
    Friend WithEvents BtnCancel As System.Windows.Forms.Button
    Friend WithEvents BtnAdd As System.Windows.Forms.Button
    Friend WithEvents Listview2 As System.Windows.Forms.ListView
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents cmbTipeSO As System.Windows.Forms.ComboBox
    Friend WithEvents txtNo As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmbJenisSO As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxtUser As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtTanggal As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents RbAllRak As System.Windows.Forms.RadioButton
    Friend WithEvents RbALlItem As System.Windows.Forms.RadioButton
    Friend WithEvents RbRak As System.Windows.Forms.RadioButton
    Friend WithEvents rbItem As System.Windows.Forms.RadioButton
    Friend WithEvents CmbTipeStock As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtcari As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents BtnTambah As System.Windows.Forms.Button
    Friend WithEvents BtnHapus As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents btnFind As System.Windows.Forms.Button
End Class
