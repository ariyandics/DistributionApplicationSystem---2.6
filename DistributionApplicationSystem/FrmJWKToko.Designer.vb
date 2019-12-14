<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmJWKToko
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmJWKToko))
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DgJWK = New System.Windows.Forms.DataGridView()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.BtCancel = New System.Windows.Forms.Button()
        Me.BtPrint = New System.Windows.Forms.Button()
        Me.BtSave = New System.Windows.Forms.Button()
        Me.BtEdit = New System.Windows.Forms.Button()
        Me.BtAdd = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.RtAlamat = New System.Windows.Forms.RichTextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.TxtNamaSupp = New System.Windows.Forms.TextBox()
        Me.TxtKdsupp = New System.Windows.Forms.TextBox()
        Me.txtNamaToko = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DgJWK, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(739, 53)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 89
        Me.PictureBox1.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label1.Font = New System.Drawing.Font("Britannic Bold", 20.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(195, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(255, 30)
        Me.Label1.TabIndex = 90
        Me.Label1.Text = "JADWAL PICKING DC"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'DgJWK
        '
        Me.DgJWK.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgJWK.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DgJWK.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Navy
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgJWK.DefaultCellStyle = DataGridViewCellStyle2
        Me.DgJWK.Location = New System.Drawing.Point(7, 180)
        Me.DgJWK.Name = "DgJWK"
        Me.DgJWK.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders
        Me.DgJWK.Size = New System.Drawing.Size(727, 252)
        Me.DgJWK.TabIndex = 137
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.Transparent
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel4.Controls.Add(Me.BtCancel)
        Me.Panel4.Controls.Add(Me.BtPrint)
        Me.Panel4.Controls.Add(Me.BtSave)
        Me.Panel4.Controls.Add(Me.BtEdit)
        Me.Panel4.Controls.Add(Me.BtAdd)
        Me.Panel4.Location = New System.Drawing.Point(7, 438)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(727, 51)
        Me.Panel4.TabIndex = 136
        '
        'BtCancel
        '
        Me.BtCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Aqua
        Me.BtCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtCancel.Image = CType(resources.GetObject("BtCancel.Image"), System.Drawing.Image)
        Me.BtCancel.Location = New System.Drawing.Point(416, 3)
        Me.BtCancel.Name = "BtCancel"
        Me.BtCancel.Size = New System.Drawing.Size(97, 41)
        Me.BtCancel.TabIndex = 4
        Me.BtCancel.Text = "&Cancel"
        Me.BtCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtCancel.UseVisualStyleBackColor = True
        '
        'BtPrint
        '
        Me.BtPrint.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Aqua
        Me.BtPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtPrint.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtPrint.Image = CType(resources.GetObject("BtPrint.Image"), System.Drawing.Image)
        Me.BtPrint.Location = New System.Drawing.Point(514, 3)
        Me.BtPrint.Name = "BtPrint"
        Me.BtPrint.Size = New System.Drawing.Size(97, 41)
        Me.BtPrint.TabIndex = 3
        Me.BtPrint.Text = "&Print"
        Me.BtPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtPrint.UseVisualStyleBackColor = True
        '
        'BtSave
        '
        Me.BtSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Aqua
        Me.BtSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtSave.Image = CType(resources.GetObject("BtSave.Image"), System.Drawing.Image)
        Me.BtSave.Location = New System.Drawing.Point(318, 3)
        Me.BtSave.Name = "BtSave"
        Me.BtSave.Size = New System.Drawing.Size(97, 41)
        Me.BtSave.TabIndex = 2
        Me.BtSave.Text = "&Save"
        Me.BtSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtSave.UseVisualStyleBackColor = True
        '
        'BtEdit
        '
        Me.BtEdit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Aqua
        Me.BtEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtEdit.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtEdit.Image = CType(resources.GetObject("BtEdit.Image"), System.Drawing.Image)
        Me.BtEdit.Location = New System.Drawing.Point(220, 3)
        Me.BtEdit.Name = "BtEdit"
        Me.BtEdit.Size = New System.Drawing.Size(97, 41)
        Me.BtEdit.TabIndex = 1
        Me.BtEdit.Text = "&Edit"
        Me.BtEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtEdit.UseVisualStyleBackColor = True
        '
        'BtAdd
        '
        Me.BtAdd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Aqua
        Me.BtAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtAdd.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtAdd.Image = CType(resources.GetObject("BtAdd.Image"), System.Drawing.Image)
        Me.BtAdd.Location = New System.Drawing.Point(122, 3)
        Me.BtAdd.Name = "BtAdd"
        Me.BtAdd.Size = New System.Drawing.Size(97, 41)
        Me.BtAdd.TabIndex = 0
        Me.BtAdd.Text = "&Add"
        Me.BtAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtAdd.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.RtAlamat)
        Me.Panel1.Controls.Add(Me.Label20)
        Me.Panel1.Controls.Add(Me.TxtNamaSupp)
        Me.Panel1.Controls.Add(Me.TxtKdsupp)
        Me.Panel1.Location = New System.Drawing.Point(7, 55)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(727, 93)
        Me.Panel1.TabIndex = 135
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(8, 5)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(64, 15)
        Me.Label2.TabIndex = 170
        Me.Label2.Text = "Kode DC"
        '
        'RtAlamat
        '
        Me.RtAlamat.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RtAlamat.ForeColor = System.Drawing.Color.Black
        Me.RtAlamat.Location = New System.Drawing.Point(127, 29)
        Me.RtAlamat.Name = "RtAlamat"
        Me.RtAlamat.Size = New System.Drawing.Size(590, 55)
        Me.RtAlamat.TabIndex = 127
        Me.RtAlamat.Text = ""
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.BackColor = System.Drawing.Color.Transparent
        Me.Label20.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.Black
        Me.Label20.Location = New System.Drawing.Point(8, 33)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(76, 15)
        Me.Label20.TabIndex = 128
        Me.Label20.Text = "Alamat DC"
        '
        'TxtNamaSupp
        '
        Me.TxtNamaSupp.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNamaSupp.Location = New System.Drawing.Point(211, 3)
        Me.TxtNamaSupp.Name = "TxtNamaSupp"
        Me.TxtNamaSupp.Size = New System.Drawing.Size(506, 20)
        Me.TxtNamaSupp.TabIndex = 169
        '
        'TxtKdsupp
        '
        Me.TxtKdsupp.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtKdsupp.Location = New System.Drawing.Point(127, 3)
        Me.TxtKdsupp.Name = "TxtKdsupp"
        Me.TxtKdsupp.Size = New System.Drawing.Size(77, 20)
        Me.TxtKdsupp.TabIndex = 168
        '
        'txtNamaToko
        '
        Me.txtNamaToko.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNamaToko.Location = New System.Drawing.Point(136, 154)
        Me.txtNamaToko.Name = "txtNamaToko"
        Me.txtNamaToko.Size = New System.Drawing.Size(290, 20)
        Me.txtNamaToko.TabIndex = 171
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(17, 159)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(79, 15)
        Me.Label3.TabIndex = 171
        Me.Label3.Text = "Nama Toko"
        '
        'FrmJWKToko
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(739, 492)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtNamaToko)
        Me.Controls.Add(Me.DgJWK)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PictureBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmJWKToko"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmJWKToko"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DgJWK, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DgJWK As System.Windows.Forms.DataGridView
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents BtCancel As System.Windows.Forms.Button
    Friend WithEvents BtPrint As System.Windows.Forms.Button
    Friend WithEvents BtSave As System.Windows.Forms.Button
    Friend WithEvents BtEdit As System.Windows.Forms.Button
    Friend WithEvents BtAdd As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents RtAlamat As System.Windows.Forms.RichTextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents TxtNamaSupp As System.Windows.Forms.TextBox
    Friend WithEvents TxtKdsupp As System.Windows.Forms.TextBox
    Friend WithEvents txtNamaToko As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
End Class
