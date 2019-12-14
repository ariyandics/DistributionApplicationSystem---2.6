<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmUnPaket
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
        Me.LblTglMutasi = New System.Windows.Forms.Label()
        Me.BtnFindNo = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtnoMutasi = New System.Windows.Forms.TextBox()
        Me.ListView2 = New System.Windows.Forms.ListView()
        Me.txtHppAll = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtHpp = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.txtqty = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.BtnFindProduk = New System.Windows.Forms.Button()
        Me.txtNamaProduk = New System.Windows.Forms.TextBox()
        Me.txtKodeProduk = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.BtnCancel = New System.Windows.Forms.Button()
        Me.BtnAdd = New System.Windows.Forms.Button()
        Me.BtnApproval = New System.Windows.Forms.Button()
        Me.BtnEdit = New System.Windows.Forms.Button()
        Me.BtnSimpan = New System.Windows.Forms.Button()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(155, 30)
        Me.Label1.TabIndex = 97
        Me.Label1.Text = "UNPACKAGE"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(720, 49)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 96
        Me.PictureBox1.TabStop = False
        '
        'LblTglMutasi
        '
        Me.LblTglMutasi.AutoSize = True
        Me.LblTglMutasi.BackColor = System.Drawing.Color.Transparent
        Me.LblTglMutasi.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTglMutasi.Location = New System.Drawing.Point(522, 57)
        Me.LblTglMutasi.Name = "LblTglMutasi"
        Me.LblTglMutasi.Size = New System.Drawing.Size(177, 19)
        Me.LblTglMutasi.TabIndex = 140
        Me.LblTglMutasi.Text = "TGL MUTASI : 2018-10-01"
        '
        'BtnFindNo
        '
        Me.BtnFindNo.BackColor = System.Drawing.Color.Transparent
        Me.BtnFindNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnFindNo.ForeColor = System.Drawing.Color.Black
        Me.BtnFindNo.Location = New System.Drawing.Point(263, 55)
        Me.BtnFindNo.Name = "BtnFindNo"
        Me.BtnFindNo.Size = New System.Drawing.Size(38, 21)
        Me.BtnFindNo.TabIndex = 139
        Me.BtnFindNo.Text = "..."
        Me.BtnFindNo.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(4, 56)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(88, 19)
        Me.Label2.TabIndex = 138
        Me.Label2.Text = "NO MUTASI"
        '
        'txtnoMutasi
        '
        Me.txtnoMutasi.BackColor = System.Drawing.Color.White
        Me.txtnoMutasi.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtnoMutasi.Location = New System.Drawing.Point(95, 55)
        Me.txtnoMutasi.MaxLength = 22
        Me.txtnoMutasi.Name = "txtnoMutasi"
        Me.txtnoMutasi.Size = New System.Drawing.Size(162, 21)
        Me.txtnoMutasi.TabIndex = 141
        Me.txtnoMutasi.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ListView2
        '
        Me.ListView2.Location = New System.Drawing.Point(0, 83)
        Me.ListView2.Name = "ListView2"
        Me.ListView2.Size = New System.Drawing.Size(721, 243)
        Me.ListView2.TabIndex = 142
        Me.ListView2.UseCompatibleStateImageBehavior = False
        '
        'txtHppAll
        '
        Me.txtHppAll.BackColor = System.Drawing.Color.White
        Me.txtHppAll.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHppAll.Location = New System.Drawing.Point(572, 412)
        Me.txtHppAll.MaxLength = 22
        Me.txtHppAll.Name = "txtHppAll"
        Me.txtHppAll.Size = New System.Drawing.Size(138, 21)
        Me.txtHppAll.TabIndex = 152
        Me.txtHppAll.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(568, 389)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(141, 19)
        Me.Label4.TabIndex = 151
        Me.Label4.Text = "TOTAL HPP MUTASI"
        '
        'txtHpp
        '
        Me.txtHpp.BackColor = System.Drawing.Color.White
        Me.txtHpp.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHpp.Location = New System.Drawing.Point(572, 357)
        Me.txtHpp.MaxLength = 22
        Me.txtHpp.Name = "txtHpp"
        Me.txtHpp.Size = New System.Drawing.Size(138, 21)
        Me.txtHpp.TabIndex = 144
        Me.txtHpp.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(568, 334)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(142, 19)
        Me.Label3.TabIndex = 143
        Me.Label3.Text = "TOTAL HPP / PAKET"
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel2.Controls.Add(Me.txtqty)
        Me.Panel2.Controls.Add(Me.Label14)
        Me.Panel2.Controls.Add(Me.BtnFindProduk)
        Me.Panel2.Controls.Add(Me.txtNamaProduk)
        Me.Panel2.Controls.Add(Me.txtKodeProduk)
        Me.Panel2.Controls.Add(Me.Label12)
        Me.Panel2.Location = New System.Drawing.Point(8, 333)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(513, 62)
        Me.Panel2.TabIndex = 150
        '
        'txtqty
        '
        Me.txtqty.BackColor = System.Drawing.Color.White
        Me.txtqty.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtqty.Location = New System.Drawing.Point(409, 27)
        Me.txtqty.MaxLength = 22
        Me.txtqty.Name = "txtqty"
        Me.txtqty.Size = New System.Drawing.Size(88, 21)
        Me.txtqty.TabIndex = 13
        Me.txtqty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(405, 4)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(36, 19)
        Me.Label14.TabIndex = 12
        Me.Label14.Text = "QTY"
        '
        'BtnFindProduk
        '
        Me.BtnFindProduk.BackColor = System.Drawing.Color.Transparent
        Me.BtnFindProduk.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnFindProduk.ForeColor = System.Drawing.Color.Black
        Me.BtnFindProduk.Location = New System.Drawing.Point(346, 27)
        Me.BtnFindProduk.Name = "BtnFindProduk"
        Me.BtnFindProduk.Size = New System.Drawing.Size(38, 21)
        Me.BtnFindProduk.TabIndex = 9
        Me.BtnFindProduk.Text = "..."
        Me.BtnFindProduk.UseVisualStyleBackColor = False
        '
        'txtNamaProduk
        '
        Me.txtNamaProduk.BackColor = System.Drawing.Color.White
        Me.txtNamaProduk.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNamaProduk.Location = New System.Drawing.Point(82, 27)
        Me.txtNamaProduk.Name = "txtNamaProduk"
        Me.txtNamaProduk.Size = New System.Drawing.Size(258, 21)
        Me.txtNamaProduk.TabIndex = 8
        '
        'txtKodeProduk
        '
        Me.txtKodeProduk.BackColor = System.Drawing.Color.White
        Me.txtKodeProduk.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtKodeProduk.Location = New System.Drawing.Point(7, 27)
        Me.txtKodeProduk.Name = "txtKodeProduk"
        Me.txtKodeProduk.Size = New System.Drawing.Size(68, 21)
        Me.txtKodeProduk.TabIndex = 7
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(4, 4)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(116, 19)
        Me.Label12.TabIndex = 6
        Me.Label12.Text = "NAMA PRODUK"
        '
        'BtnCancel
        '
        Me.BtnCancel.BackColor = System.Drawing.Color.Transparent
        Me.BtnCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Cyan
        Me.BtnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCancel.ForeColor = System.Drawing.Color.Black
        Me.BtnCancel.Location = New System.Drawing.Point(316, 398)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(102, 41)
        Me.BtnCancel.TabIndex = 149
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
        Me.BtnAdd.Location = New System.Drawing.Point(7, 398)
        Me.BtnAdd.Name = "BtnAdd"
        Me.BtnAdd.Size = New System.Drawing.Size(102, 41)
        Me.BtnAdd.TabIndex = 148
        Me.BtnAdd.Text = "&Add"
        Me.BtnAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnAdd.UseVisualStyleBackColor = False
        '
        'BtnApproval
        '
        Me.BtnApproval.BackColor = System.Drawing.Color.Transparent
        Me.BtnApproval.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Cyan
        Me.BtnApproval.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnApproval.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnApproval.ForeColor = System.Drawing.Color.Black
        Me.BtnApproval.Location = New System.Drawing.Point(419, 398)
        Me.BtnApproval.Name = "BtnApproval"
        Me.BtnApproval.Size = New System.Drawing.Size(102, 41)
        Me.BtnApproval.TabIndex = 147
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
        Me.BtnEdit.Location = New System.Drawing.Point(110, 398)
        Me.BtnEdit.Name = "BtnEdit"
        Me.BtnEdit.Size = New System.Drawing.Size(102, 41)
        Me.BtnEdit.TabIndex = 146
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
        Me.BtnSimpan.Location = New System.Drawing.Point(213, 398)
        Me.BtnSimpan.Name = "BtnSimpan"
        Me.BtnSimpan.Size = New System.Drawing.Size(102, 41)
        Me.BtnSimpan.TabIndex = 145
        Me.BtnSimpan.Text = "&Save"
        Me.BtnSimpan.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnSimpan.UseVisualStyleBackColor = False
        '
        'FrmUnPaket
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(720, 441)
        Me.Controls.Add(Me.txtHppAll)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtHpp)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.BtnCancel)
        Me.Controls.Add(Me.BtnAdd)
        Me.Controls.Add(Me.BtnApproval)
        Me.Controls.Add(Me.BtnEdit)
        Me.Controls.Add(Me.BtnSimpan)
        Me.Controls.Add(Me.ListView2)
        Me.Controls.Add(Me.LblTglMutasi)
        Me.Controls.Add(Me.BtnFindNo)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtnoMutasi)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PictureBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.Name = "FrmUnPaket"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmUnPaket"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents LblTglMutasi As System.Windows.Forms.Label
    Friend WithEvents BtnFindNo As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtnoMutasi As System.Windows.Forms.TextBox
    Friend WithEvents ListView2 As System.Windows.Forms.ListView
    Friend WithEvents txtHppAll As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtHpp As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents txtqty As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents BtnFindProduk As System.Windows.Forms.Button
    Friend WithEvents txtNamaProduk As System.Windows.Forms.TextBox
    Friend WithEvents txtKodeProduk As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents BtnCancel As System.Windows.Forms.Button
    Friend WithEvents BtnAdd As System.Windows.Forms.Button
    Friend WithEvents BtnApproval As System.Windows.Forms.Button
    Friend WithEvents BtnEdit As System.Windows.Forms.Button
    Friend WithEvents BtnSimpan As System.Windows.Forms.Button
End Class
