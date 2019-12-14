<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMasterMaxDC
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMasterMaxDC))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cmbfilterby = New System.Windows.Forms.ComboBox()
        Me.RBAll = New System.Windows.Forms.RadioButton()
        Me.RBDept = New System.Windows.Forms.RadioButton()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TxtNamaDC = New System.Windows.Forms.TextBox()
        Me.TxtAlamatDC = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TxtKodeDC = New System.Windows.Forms.TextBox()
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.BtnSave = New System.Windows.Forms.Button()
        Me.BtnEdit = New System.Windows.Forms.Button()
        Me.TxtKodeProduk = New System.Windows.Forms.TextBox()
        Me.TxtNamaBarang = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TxtQty = New System.Windows.Forms.TextBox()
        Me.lblqty = New System.Windows.Forms.Label()
        Me.BtnCancel = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtfind = New System.Windows.Forms.TextBox()
        Me.btnPrint = New System.Windows.Forms.Button()
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
        Me.Label1.Location = New System.Drawing.Point(376, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(208, 30)
        Me.Label1.TabIndex = 166
        Me.Label1.Text = "MASTER MAX DC"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(1334, 53)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 165
        Me.PictureBox1.TabStop = False
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.cmbfilterby)
        Me.Panel1.Controls.Add(Me.RBAll)
        Me.Panel1.Controls.Add(Me.RBDept)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.TxtNamaDC)
        Me.Panel1.Controls.Add(Me.TxtAlamatDC)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.TxtKodeDC)
        Me.Panel1.Location = New System.Drawing.Point(4, 56)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1330, 62)
        Me.Panel1.TabIndex = 167
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(866, 31)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(65, 19)
        Me.Label7.TabIndex = 36
        Me.Label7.Text = "Filter By"
        '
        'cmbfilterby
        '
        Me.cmbfilterby.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbfilterby.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbfilterby.FormattingEnabled = True
        Me.cmbfilterby.Location = New System.Drawing.Point(948, 29)
        Me.cmbfilterby.Name = "cmbfilterby"
        Me.cmbfilterby.Size = New System.Drawing.Size(351, 21)
        Me.cmbfilterby.TabIndex = 35
        '
        'RBAll
        '
        Me.RBAll.AutoSize = True
        Me.RBAll.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RBAll.Location = New System.Drawing.Point(1076, 4)
        Me.RBAll.Name = "RBAll"
        Me.RBAll.Size = New System.Drawing.Size(39, 19)
        Me.RBAll.TabIndex = 34
        Me.RBAll.TabStop = True
        Me.RBAll.Text = "All"
        Me.RBAll.UseVisualStyleBackColor = True
        '
        'RBDept
        '
        Me.RBDept.AutoSize = True
        Me.RBDept.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RBDept.Location = New System.Drawing.Point(948, 4)
        Me.RBDept.Name = "RBDept"
        Me.RBDept.Size = New System.Drawing.Size(100, 19)
        Me.RBDept.TabIndex = 33
        Me.RBDept.TabStop = True
        Me.RBDept.Text = "Departement"
        Me.RBDept.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(906, 5)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(26, 19)
        Me.Label5.TabIndex = 30
        Me.Label5.Text = "By"
        '
        'TxtNamaDC
        '
        Me.TxtNamaDC.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.TxtNamaDC.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNamaDC.Location = New System.Drawing.Point(196, 6)
        Me.TxtNamaDC.Name = "TxtNamaDC"
        Me.TxtNamaDC.ReadOnly = True
        Me.TxtNamaDC.Size = New System.Drawing.Size(392, 21)
        Me.TxtNamaDC.TabIndex = 29
        '
        'TxtAlamatDC
        '
        Me.TxtAlamatDC.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.TxtAlamatDC.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtAlamatDC.Location = New System.Drawing.Point(103, 32)
        Me.TxtAlamatDC.Name = "TxtAlamatDC"
        Me.TxtAlamatDC.ReadOnly = True
        Me.TxtAlamatDC.Size = New System.Drawing.Size(485, 21)
        Me.TxtAlamatDC.TabIndex = 22
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(5, 35)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(89, 19)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "ALAMAT DC"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(5, 8)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(68, 19)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "KODE DC"
        '
        'TxtKodeDC
        '
        Me.TxtKodeDC.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.TxtKodeDC.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtKodeDC.Location = New System.Drawing.Point(103, 6)
        Me.TxtKodeDC.Name = "TxtKodeDC"
        Me.TxtKodeDC.ReadOnly = True
        Me.TxtKodeDC.Size = New System.Drawing.Size(87, 21)
        Me.TxtKodeDC.TabIndex = 10
        '
        'ListView1
        '
        Me.ListView1.Location = New System.Drawing.Point(4, 151)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(1330, 398)
        Me.ListView1.TabIndex = 168
        Me.ListView1.UseCompatibleStateImageBehavior = False
        '
        'BtnSave
        '
        Me.BtnSave.BackColor = System.Drawing.Color.Transparent
        Me.BtnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.BtnSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Aqua
        Me.BtnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSave.ForeColor = System.Drawing.Color.Black
        Me.BtnSave.Image = CType(resources.GetObject("BtnSave.Image"), System.Drawing.Image)
        Me.BtnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnSave.Location = New System.Drawing.Point(1044, 558)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(93, 41)
        Me.BtnSave.TabIndex = 189
        Me.BtnSave.Text = "&Save"
        Me.BtnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnSave.UseVisualStyleBackColor = False
        '
        'BtnEdit
        '
        Me.BtnEdit.BackColor = System.Drawing.Color.Transparent
        Me.BtnEdit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.BtnEdit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Aqua
        Me.BtnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnEdit.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnEdit.ForeColor = System.Drawing.Color.Black
        Me.BtnEdit.Image = CType(resources.GetObject("BtnEdit.Image"), System.Drawing.Image)
        Me.BtnEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnEdit.Location = New System.Drawing.Point(950, 558)
        Me.BtnEdit.Name = "BtnEdit"
        Me.BtnEdit.Size = New System.Drawing.Size(93, 41)
        Me.BtnEdit.TabIndex = 190
        Me.BtnEdit.Text = "&Edit"
        Me.BtnEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnEdit.UseVisualStyleBackColor = False
        '
        'TxtKodeProduk
        '
        Me.TxtKodeProduk.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.TxtKodeProduk.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtKodeProduk.Location = New System.Drawing.Point(132, 10)
        Me.TxtKodeProduk.Name = "TxtKodeProduk"
        Me.TxtKodeProduk.ReadOnly = True
        Me.TxtKodeProduk.Size = New System.Drawing.Size(68, 21)
        Me.TxtKodeProduk.TabIndex = 192
        '
        'TxtNamaBarang
        '
        Me.TxtNamaBarang.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.TxtNamaBarang.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNamaBarang.Location = New System.Drawing.Point(206, 10)
        Me.TxtNamaBarang.Name = "TxtNamaBarang"
        Me.TxtNamaBarang.ReadOnly = True
        Me.TxtNamaBarang.Size = New System.Drawing.Size(343, 21)
        Me.TxtNamaBarang.TabIndex = 193
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(3, 10)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(117, 19)
        Me.Label6.TabIndex = 191
        Me.Label6.Text = "NAMA BARANG"
        '
        'TxtQty
        '
        Me.TxtQty.BackColor = System.Drawing.SystemColors.Window
        Me.TxtQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtQty.Location = New System.Drawing.Point(609, 10)
        Me.TxtQty.MaxLength = 14
        Me.TxtQty.Name = "TxtQty"
        Me.TxtQty.Size = New System.Drawing.Size(123, 21)
        Me.TxtQty.TabIndex = 195
        Me.TxtQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblqty
        '
        Me.lblqty.AutoSize = True
        Me.lblqty.BackColor = System.Drawing.Color.Transparent
        Me.lblqty.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblqty.ForeColor = System.Drawing.Color.Black
        Me.lblqty.Location = New System.Drawing.Point(568, 12)
        Me.lblqty.Name = "lblqty"
        Me.lblqty.Size = New System.Drawing.Size(36, 19)
        Me.lblqty.TabIndex = 194
        Me.lblqty.Text = "QTY"
        '
        'BtnCancel
        '
        Me.BtnCancel.BackColor = System.Drawing.Color.Transparent
        Me.BtnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.BtnCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Aqua
        Me.BtnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCancel.ForeColor = System.Drawing.Color.Black
        Me.BtnCancel.Image = CType(resources.GetObject("BtnCancel.Image"), System.Drawing.Image)
        Me.BtnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnCancel.Location = New System.Drawing.Point(1138, 558)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(93, 41)
        Me.BtnCancel.TabIndex = 196
        Me.BtnCancel.Text = "&Cancel"
        Me.BtnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnCancel.UseVisualStyleBackColor = False
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Transparent
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel2.Controls.Add(Me.TxtQty)
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Controls.Add(Me.lblqty)
        Me.Panel2.Controls.Add(Me.TxtKodeProduk)
        Me.Panel2.Controls.Add(Me.TxtNamaBarang)
        Me.Panel2.Location = New System.Drawing.Point(4, 555)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(750, 43)
        Me.Panel2.TabIndex = 197
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 125)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 19)
        Me.Label2.TabIndex = 37
        Me.Label2.Text = "FIND"
        '
        'txtfind
        '
        Me.txtfind.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.txtfind.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtfind.Location = New System.Drawing.Point(69, 124)
        Me.txtfind.Name = "txtfind"
        Me.txtfind.Size = New System.Drawing.Size(525, 21)
        Me.txtfind.TabIndex = 37
        '
        'btnPrint
        '
        Me.btnPrint.BackColor = System.Drawing.Color.Transparent
        Me.btnPrint.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Aqua
        Me.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPrint.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPrint.ForeColor = System.Drawing.Color.Black
        Me.btnPrint.Image = CType(resources.GetObject("btnPrint.Image"), System.Drawing.Image)
        Me.btnPrint.Location = New System.Drawing.Point(1232, 558)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(93, 41)
        Me.btnPrint.TabIndex = 198
        Me.btnPrint.Text = "&Print"
        Me.btnPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnPrint.UseVisualStyleBackColor = False
        '
        'FrmMasterMaxDC
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1334, 605)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.txtfind)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.BtnCancel)
        Me.Controls.Add(Me.BtnSave)
        Me.Controls.Add(Me.BtnEdit)
        Me.Controls.Add(Me.ListView1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Panel2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmMasterMaxDC"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "1"
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
    Friend WithEvents TxtNamaDC As System.Windows.Forms.TextBox
    Friend WithEvents TxtAlamatDC As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxtKodeDC As System.Windows.Forms.TextBox
    Friend WithEvents RBAll As System.Windows.Forms.RadioButton
    Friend WithEvents RBDept As System.Windows.Forms.RadioButton
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents BtnSave As System.Windows.Forms.Button
    Friend WithEvents BtnEdit As System.Windows.Forms.Button
    Friend WithEvents TxtKodeProduk As System.Windows.Forms.TextBox
    Friend WithEvents TxtNamaBarang As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TxtQty As System.Windows.Forms.TextBox
    Friend WithEvents lblqty As System.Windows.Forms.Label
    Friend WithEvents cmbfilterby As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents BtnCancel As System.Windows.Forms.Button
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtfind As System.Windows.Forms.TextBox
    Friend WithEvents btnPrint As System.Windows.Forms.Button
End Class
