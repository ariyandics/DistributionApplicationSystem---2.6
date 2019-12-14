<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmEditUPO
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
        Me.BtnFindNoUPO = New System.Windows.Forms.Button()
        Me.TxtNoUPO = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.BtnFindSupplier = New System.Windows.Forms.Button()
        Me.TxtTanggal = New System.Windows.Forms.TextBox()
        Me.LblTanggal = New System.Windows.Forms.Label()
        Me.TxtNamaSupplier = New System.Windows.Forms.TextBox()
        Me.TxtKodeSupplier = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ListView2 = New System.Windows.Forms.ListView()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.TxtUKoreksi = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TxtUSystem = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TxtNamaBarang = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.BtnCancel = New System.Windows.Forms.Button()
        Me.BtnEdit = New System.Windows.Forms.Button()
        Me.BtnSave = New System.Windows.Forms.Button()
        Me.txtfind = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label1.Font = New System.Drawing.Font("Britannic Bold", 20.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(304, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(177, 30)
        Me.Label1.TabIndex = 99
        Me.Label1.Text = "KOREKSI UPO"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(1051, 49)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 98
        Me.PictureBox1.TabStop = False
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.BtnFindNoUPO)
        Me.Panel1.Controls.Add(Me.TxtNoUPO)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.BtnFindSupplier)
        Me.Panel1.Controls.Add(Me.TxtTanggal)
        Me.Panel1.Controls.Add(Me.LblTanggal)
        Me.Panel1.Controls.Add(Me.TxtNamaSupplier)
        Me.Panel1.Controls.Add(Me.TxtKodeSupplier)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Location = New System.Drawing.Point(2, 55)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1049, 64)
        Me.Panel1.TabIndex = 100
        '
        'BtnFindNoUPO
        '
        Me.BtnFindNoUPO.BackColor = System.Drawing.Color.Transparent
        Me.BtnFindNoUPO.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Cyan
        Me.BtnFindNoUPO.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnFindNoUPO.ForeColor = System.Drawing.Color.Black
        Me.BtnFindNoUPO.Location = New System.Drawing.Point(299, 8)
        Me.BtnFindNoUPO.Name = "BtnFindNoUPO"
        Me.BtnFindNoUPO.Size = New System.Drawing.Size(38, 21)
        Me.BtnFindNoUPO.TabIndex = 9
        Me.BtnFindNoUPO.Text = "..."
        Me.BtnFindNoUPO.UseVisualStyleBackColor = False
        '
        'TxtNoUPO
        '
        Me.TxtNoUPO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNoUPO.Location = New System.Drawing.Point(127, 8)
        Me.TxtNoUPO.Name = "TxtNoUPO"
        Me.TxtNoUPO.Size = New System.Drawing.Size(166, 21)
        Me.TxtNoUPO.TabIndex = 8
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(2, 8)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(69, 19)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "NO. UPO"
        '
        'BtnFindSupplier
        '
        Me.BtnFindSupplier.BackColor = System.Drawing.Color.Transparent
        Me.BtnFindSupplier.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Cyan
        Me.BtnFindSupplier.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnFindSupplier.ForeColor = System.Drawing.Color.Black
        Me.BtnFindSupplier.Location = New System.Drawing.Point(492, 33)
        Me.BtnFindSupplier.Name = "BtnFindSupplier"
        Me.BtnFindSupplier.Size = New System.Drawing.Size(38, 21)
        Me.BtnFindSupplier.TabIndex = 5
        Me.BtnFindSupplier.Text = "..."
        Me.BtnFindSupplier.UseVisualStyleBackColor = False
        '
        'TxtTanggal
        '
        Me.TxtTanggal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTanggal.Location = New System.Drawing.Point(816, 8)
        Me.TxtTanggal.Name = "TxtTanggal"
        Me.TxtTanggal.Size = New System.Drawing.Size(226, 20)
        Me.TxtTanggal.TabIndex = 4
        '
        'LblTanggal
        '
        Me.LblTanggal.AutoSize = True
        Me.LblTanggal.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTanggal.Location = New System.Drawing.Point(738, 8)
        Me.LblTanggal.Name = "LblTanggal"
        Me.LblTanggal.Size = New System.Drawing.Size(74, 19)
        Me.LblTanggal.TabIndex = 3
        Me.LblTanggal.Text = "TANGGAL"
        '
        'TxtNamaSupplier
        '
        Me.TxtNamaSupplier.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNamaSupplier.Location = New System.Drawing.Point(201, 33)
        Me.TxtNamaSupplier.Name = "TxtNamaSupplier"
        Me.TxtNamaSupplier.Size = New System.Drawing.Size(285, 21)
        Me.TxtNamaSupplier.TabIndex = 2
        '
        'TxtKodeSupplier
        '
        Me.TxtKodeSupplier.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtKodeSupplier.Location = New System.Drawing.Point(127, 33)
        Me.TxtKodeSupplier.Name = "TxtKodeSupplier"
        Me.TxtKodeSupplier.Size = New System.Drawing.Size(68, 21)
        Me.TxtKodeSupplier.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(2, 33)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(122, 19)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "NAMA SUPPLIER"
        '
        'ListView2
        '
        Me.ListView2.Location = New System.Drawing.Point(2, 152)
        Me.ListView2.Name = "ListView2"
        Me.ListView2.Size = New System.Drawing.Size(1049, 337)
        Me.ListView2.TabIndex = 101
        Me.ListView2.UseCompatibleStateImageBehavior = False
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.SystemColors.Control
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel4.Controls.Add(Me.TxtUKoreksi)
        Me.Panel4.Controls.Add(Me.Label6)
        Me.Panel4.Controls.Add(Me.TxtUSystem)
        Me.Panel4.Controls.Add(Me.Label5)
        Me.Panel4.Controls.Add(Me.TxtNamaBarang)
        Me.Panel4.Controls.Add(Me.Label4)
        Me.Panel4.Location = New System.Drawing.Point(2, 494)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(624, 55)
        Me.Panel4.TabIndex = 131
        '
        'TxtUKoreksi
        '
        Me.TxtUKoreksi.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtUKoreksi.Location = New System.Drawing.Point(493, 23)
        Me.TxtUKoreksi.MaxLength = 14
        Me.TxtUKoreksi.Name = "TxtUKoreksi"
        Me.TxtUKoreksi.Size = New System.Drawing.Size(120, 21)
        Me.TxtUKoreksi.TabIndex = 14
        Me.TxtUKoreksi.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(489, 4)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(84, 19)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "U. KOREKSI"
        '
        'TxtUSystem
        '
        Me.TxtUSystem.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtUSystem.Location = New System.Drawing.Point(343, 23)
        Me.TxtUSystem.Name = "TxtUSystem"
        Me.TxtUSystem.Size = New System.Drawing.Size(120, 21)
        Me.TxtUSystem.TabIndex = 12
        Me.TxtUSystem.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(339, 4)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(81, 19)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "U. SYSTEM"
        '
        'TxtNamaBarang
        '
        Me.TxtNamaBarang.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNamaBarang.Location = New System.Drawing.Point(8, 23)
        Me.TxtNamaBarang.Name = "TxtNamaBarang"
        Me.TxtNamaBarang.Size = New System.Drawing.Size(331, 21)
        Me.TxtNamaBarang.TabIndex = 10
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(4, 4)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(116, 19)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "NAMA PRODUK"
        '
        'BtnCancel
        '
        Me.BtnCancel.BackColor = System.Drawing.Color.Transparent
        Me.BtnCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Cyan
        Me.BtnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCancel.Location = New System.Drawing.Point(956, 498)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(91, 42)
        Me.BtnCancel.TabIndex = 4
        Me.BtnCancel.Text = "&Cancel"
        Me.BtnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnCancel.UseVisualStyleBackColor = False
        '
        'BtnEdit
        '
        Me.BtnEdit.BackColor = System.Drawing.Color.Transparent
        Me.BtnEdit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Cyan
        Me.BtnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnEdit.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnEdit.Location = New System.Drawing.Point(772, 498)
        Me.BtnEdit.Name = "BtnEdit"
        Me.BtnEdit.Size = New System.Drawing.Size(91, 42)
        Me.BtnEdit.TabIndex = 1
        Me.BtnEdit.Text = "&Edit"
        Me.BtnEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnEdit.UseVisualStyleBackColor = False
        '
        'BtnSave
        '
        Me.BtnSave.BackColor = System.Drawing.Color.Transparent
        Me.BtnSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Cyan
        Me.BtnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSave.Location = New System.Drawing.Point(864, 498)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(91, 42)
        Me.BtnSave.TabIndex = 2
        Me.BtnSave.Text = "&Save"
        Me.BtnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnSave.UseVisualStyleBackColor = False
        '
        'txtfind
        '
        Me.txtfind.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtfind.Location = New System.Drawing.Point(131, 125)
        Me.txtfind.Name = "txtfind"
        Me.txtfind.Size = New System.Drawing.Size(359, 21)
        Me.txtfind.TabIndex = 16
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(6, 127)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(103, 19)
        Me.Label7.TabIndex = 15
        Me.Label7.Text = "FIND PRODUK"
        '
        'FrmEditUPO
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1051, 553)
        Me.Controls.Add(Me.txtfind)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.ListView2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.BtnCancel)
        Me.Controls.Add(Me.BtnSave)
        Me.Controls.Add(Me.BtnEdit)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.Name = "FrmEditUPO"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmEditUPO"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents BtnFindSupplier As System.Windows.Forms.Button
    Friend WithEvents TxtTanggal As System.Windows.Forms.TextBox
    Friend WithEvents LblTanggal As System.Windows.Forms.Label
    Friend WithEvents TxtNamaSupplier As System.Windows.Forms.TextBox
    Friend WithEvents TxtKodeSupplier As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents BtnFindNoUPO As System.Windows.Forms.Button
    Friend WithEvents TxtNoUPO As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ListView2 As System.Windows.Forms.ListView
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents BtnCancel As System.Windows.Forms.Button
    Friend WithEvents BtnSave As System.Windows.Forms.Button
    Friend WithEvents BtnEdit As System.Windows.Forms.Button
    Friend WithEvents TxtUKoreksi As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TxtUSystem As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TxtNamaBarang As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtfind As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
End Class
