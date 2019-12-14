<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmNotifToko
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
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.DgSO = New System.Windows.Forms.DataGridView()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.BtAdd = New System.Windows.Forms.Button()
        Me.BtSave = New System.Windows.Forms.Button()
        Me.BtCancel = New System.Windows.Forms.Button()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.btFindtoko = New System.Windows.Forms.Button()
        Me.cbuntuk = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtjudul = New System.Windows.Forms.TextBox()
        Me.Dtaktif = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtpesan = New System.Windows.Forms.TextBox()
        Me.txtdari = New System.Windows.Forms.TextBox()
        Me.Labelx = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtcari = New System.Windows.Forms.TextBox()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        CType(Me.DgSO, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(1741, 62)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 246
        Me.PictureBox1.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(13, 9)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(297, 39)
        Me.Label1.TabIndex = 247
        Me.Label1.Text = "Pesan Untuk Toko"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel4
        '
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel4.Controls.Add(Me.DgSO)
        Me.Panel4.Location = New System.Drawing.Point(643, 128)
        Me.Panel4.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(1087, 346)
        Me.Panel4.TabIndex = 254
        '
        'DgSO
        '
        Me.DgSO.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgSO.Location = New System.Drawing.Point(3, 3)
        Me.DgSO.Name = "DgSO"
        Me.DgSO.RowTemplate.Height = 24
        Me.DgSO.Size = New System.Drawing.Size(1076, 333)
        Me.DgSO.TabIndex = 0
        '
        'Panel3
        '
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel3.Controls.Add(Me.BtAdd)
        Me.Panel3.Controls.Add(Me.BtSave)
        Me.Panel3.Controls.Add(Me.BtCancel)
        Me.Panel3.Location = New System.Drawing.Point(0, 397)
        Me.Panel3.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(638, 77)
        Me.Panel3.TabIndex = 252
        '
        'BtAdd
        '
        Me.BtAdd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Cyan
        Me.BtAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtAdd.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtAdd.Location = New System.Drawing.Point(104, 12)
        Me.BtAdd.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.BtAdd.Name = "BtAdd"
        Me.BtAdd.Size = New System.Drawing.Size(149, 50)
        Me.BtAdd.TabIndex = 0
        Me.BtAdd.Text = "&ADD"
        Me.BtAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtAdd.UseVisualStyleBackColor = True
        '
        'BtSave
        '
        Me.BtSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Cyan
        Me.BtSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtSave.Location = New System.Drawing.Point(255, 12)
        Me.BtSave.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.BtSave.Name = "BtSave"
        Me.BtSave.Size = New System.Drawing.Size(149, 50)
        Me.BtSave.TabIndex = 2
        Me.BtSave.Text = "&POST"
        Me.BtSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtSave.UseVisualStyleBackColor = True
        '
        'BtCancel
        '
        Me.BtCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Cyan
        Me.BtCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtCancel.Location = New System.Drawing.Point(406, 12)
        Me.BtCancel.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.BtCancel.Name = "BtCancel"
        Me.BtCancel.Size = New System.Drawing.Size(149, 50)
        Me.BtCancel.TabIndex = 3
        Me.BtCancel.Text = "&CANCEL"
        Me.BtCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtCancel.UseVisualStyleBackColor = True
        '
        'Panel5
        '
        Me.Panel5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel5.Controls.Add(Me.btFindtoko)
        Me.Panel5.Controls.Add(Me.cbuntuk)
        Me.Panel5.Controls.Add(Me.Label2)
        Me.Panel5.Controls.Add(Me.Label4)
        Me.Panel5.Controls.Add(Me.txtjudul)
        Me.Panel5.Controls.Add(Me.Dtaktif)
        Me.Panel5.Controls.Add(Me.Label3)
        Me.Panel5.Controls.Add(Me.txtpesan)
        Me.Panel5.Controls.Add(Me.txtdari)
        Me.Panel5.Controls.Add(Me.Labelx)
        Me.Panel5.Location = New System.Drawing.Point(0, 62)
        Me.Panel5.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(638, 331)
        Me.Panel5.TabIndex = 251
        '
        'btFindtoko
        '
        Me.btFindtoko.BackColor = System.Drawing.Color.Transparent
        Me.btFindtoko.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btFindtoko.ForeColor = System.Drawing.Color.Black
        Me.btFindtoko.Location = New System.Drawing.Point(571, 45)
        Me.btFindtoko.Margin = New System.Windows.Forms.Padding(4)
        Me.btFindtoko.Name = "btFindtoko"
        Me.btFindtoko.Size = New System.Drawing.Size(51, 26)
        Me.btFindtoko.TabIndex = 262
        Me.btFindtoko.Text = "..."
        Me.btFindtoko.UseVisualStyleBackColor = False
        '
        'cbuntuk
        '
        Me.cbuntuk.FormattingEnabled = True
        Me.cbuntuk.Items.AddRange(New Object() {"ALL TOKO", "RH", "AC", "Other"})
        Me.cbuntuk.Location = New System.Drawing.Point(130, 45)
        Me.cbuntuk.Name = "cbuntuk"
        Me.cbuntuk.Size = New System.Drawing.Size(430, 24)
        Me.cbuntuk.TabIndex = 261
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 44)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(96, 18)
        Me.Label2.TabIndex = 260
        Me.Label2.Text = "Untuk Toko"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(12, 75)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(64, 18)
        Me.Label4.TabIndex = 258
        Me.Label4.Text = "Subject"
        '
        'txtjudul
        '
        Me.txtjudul.Location = New System.Drawing.Point(130, 75)
        Me.txtjudul.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtjudul.Name = "txtjudul"
        Me.txtjudul.Size = New System.Drawing.Size(492, 22)
        Me.txtjudul.TabIndex = 257
        '
        'Dtaktif
        '
        Me.Dtaktif.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.Dtaktif.Location = New System.Drawing.Point(130, 286)
        Me.Dtaktif.Margin = New System.Windows.Forms.Padding(4)
        Me.Dtaktif.Name = "Dtaktif"
        Me.Dtaktif.Size = New System.Drawing.Size(153, 22)
        Me.Dtaktif.TabIndex = 256
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(15, 287)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(104, 18)
        Me.Label3.TabIndex = 255
        Me.Label3.Text = "Periode Aktif"
        '
        'txtpesan
        '
        Me.txtpesan.Location = New System.Drawing.Point(130, 101)
        Me.txtpesan.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtpesan.Multiline = True
        Me.txtpesan.Name = "txtpesan"
        Me.txtpesan.Size = New System.Drawing.Size(492, 178)
        Me.txtpesan.TabIndex = 26
        '
        'txtdari
        '
        Me.txtdari.Location = New System.Drawing.Point(130, 18)
        Me.txtdari.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtdari.Name = "txtdari"
        Me.txtdari.ReadOnly = True
        Me.txtdari.Size = New System.Drawing.Size(492, 22)
        Me.txtdari.TabIndex = 0
        '
        'Labelx
        '
        Me.Labelx.AutoSize = True
        Me.Labelx.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Labelx.Location = New System.Drawing.Point(12, 18)
        Me.Labelx.Name = "Labelx"
        Me.Labelx.Size = New System.Drawing.Size(39, 18)
        Me.Labelx.TabIndex = 25
        Me.Labelx.Text = "Dari"
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel2.Controls.Add(Me.Label7)
        Me.Panel2.Controls.Add(Me.txtcari)
        Me.Panel2.Location = New System.Drawing.Point(643, 62)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1086, 63)
        Me.Panel2.TabIndex = 255
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Franklin Gothic Medium", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(21, 20)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(47, 21)
        Me.Label7.TabIndex = 44
        Me.Label7.Text = "Judul"
        '
        'txtcari
        '
        Me.txtcari.Location = New System.Drawing.Point(74, 19)
        Me.txtcari.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtcari.Name = "txtcari"
        Me.txtcari.Size = New System.Drawing.Size(704, 22)
        Me.txtcari.TabIndex = 0
        '
        'FrmNotifToko
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(1741, 478)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel5)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PictureBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Name = "FrmNotifToko"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmNotifToko"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        CType(Me.DgSO, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents BtAdd As System.Windows.Forms.Button
    Friend WithEvents BtSave As System.Windows.Forms.Button
    Friend WithEvents BtCancel As System.Windows.Forms.Button
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents txtpesan As System.Windows.Forms.TextBox
    Friend WithEvents txtdari As System.Windows.Forms.TextBox
    Friend WithEvents Labelx As System.Windows.Forms.Label
    Friend WithEvents Dtaktif As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents DgSO As System.Windows.Forms.DataGridView
    Friend WithEvents cbuntuk As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtjudul As System.Windows.Forms.TextBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtcari As System.Windows.Forms.TextBox
    Friend WithEvents btFindtoko As System.Windows.Forms.Button
End Class
