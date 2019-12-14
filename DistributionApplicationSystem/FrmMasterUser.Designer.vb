<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMasterUser
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMasterUser))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.BtnAdd = New System.Windows.Forms.Button()
        Me.BtCancel = New System.Windows.Forms.Button()
        Me.BtSave = New System.Windows.Forms.Button()
        Me.BtEdit = New System.Windows.Forms.Button()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.ListView2 = New System.Windows.Forms.ListView()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtfind = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.cmbdiv = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmbstatus = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.BtnFind = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtpassword = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.LblTanggal = New System.Windows.Forms.Label()
        Me.TxtNama = New System.Windows.Forms.TextBox()
        Me.TxtUser = New System.Windows.Forms.TextBox()
        Me.TreeView1 = New System.Windows.Forms.TreeView()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel2.SuspendLayout()
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
        Me.Label1.Location = New System.Drawing.Point(139, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(178, 30)
        Me.Label1.TabIndex = 93
        Me.Label1.Text = "MASTER USER"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(793, 49)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 92
        Me.PictureBox1.TabStop = False
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.Transparent
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel4.Controls.Add(Me.BtnAdd)
        Me.Panel4.Controls.Add(Me.BtCancel)
        Me.Panel4.Controls.Add(Me.BtSave)
        Me.Panel4.Controls.Add(Me.BtEdit)
        Me.Panel4.Location = New System.Drawing.Point(5, 528)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(395, 51)
        Me.Panel4.TabIndex = 131
        '
        'BtnAdd
        '
        Me.BtnAdd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Aqua
        Me.BtnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnAdd.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnAdd.Image = CType(resources.GetObject("BtnAdd.Image"), System.Drawing.Image)
        Me.BtnAdd.Location = New System.Drawing.Point(7, 3)
        Me.BtnAdd.Name = "BtnAdd"
        Me.BtnAdd.Size = New System.Drawing.Size(93, 41)
        Me.BtnAdd.TabIndex = 5
        Me.BtnAdd.Text = "&Add"
        Me.BtnAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnAdd.UseVisualStyleBackColor = True
        '
        'BtCancel
        '
        Me.BtCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Aqua
        Me.BtCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtCancel.Image = CType(resources.GetObject("BtCancel.Image"), System.Drawing.Image)
        Me.BtCancel.Location = New System.Drawing.Point(289, 3)
        Me.BtCancel.Name = "BtCancel"
        Me.BtCancel.Size = New System.Drawing.Size(93, 41)
        Me.BtCancel.TabIndex = 4
        Me.BtCancel.Text = "&Cancel"
        Me.BtCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtCancel.UseVisualStyleBackColor = True
        '
        'BtSave
        '
        Me.BtSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Aqua
        Me.BtSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtSave.Image = CType(resources.GetObject("BtSave.Image"), System.Drawing.Image)
        Me.BtSave.Location = New System.Drawing.Point(195, 3)
        Me.BtSave.Name = "BtSave"
        Me.BtSave.Size = New System.Drawing.Size(93, 41)
        Me.BtSave.TabIndex = 2
        Me.BtSave.Text = "&Save"
        Me.BtSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtSave.UseVisualStyleBackColor = True
        '
        'BtEdit
        '
        Me.BtEdit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Aqua
        Me.BtEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtEdit.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtEdit.Image = CType(resources.GetObject("BtEdit.Image"), System.Drawing.Image)
        Me.BtEdit.Location = New System.Drawing.Point(101, 3)
        Me.BtEdit.Name = "BtEdit"
        Me.BtEdit.Size = New System.Drawing.Size(93, 41)
        Me.BtEdit.TabIndex = 1
        Me.BtEdit.Text = "&Edit"
        Me.BtEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtEdit.UseVisualStyleBackColor = True
        '
        'Panel3
        '
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel3.Controls.Add(Me.ListView2)
        Me.Panel3.Location = New System.Drawing.Point(5, 240)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(395, 282)
        Me.Panel3.TabIndex = 130
        '
        'ListView2
        '
        Me.ListView2.Location = New System.Drawing.Point(7, 6)
        Me.ListView2.Name = "ListView2"
        Me.ListView2.Size = New System.Drawing.Size(381, 269)
        Me.ListView2.TabIndex = 14
        Me.ListView2.UseCompatibleStateImageBehavior = False
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Controls.Add(Me.txtfind)
        Me.Panel2.Location = New System.Drawing.Point(4, 199)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(396, 35)
        Me.Panel2.TabIndex = 129
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(3, 8)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(45, 15)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "NAMA"
        '
        'txtfind
        '
        Me.txtfind.Location = New System.Drawing.Point(58, 7)
        Me.txtfind.Name = "txtfind"
        Me.txtfind.Size = New System.Drawing.Size(322, 20)
        Me.txtfind.TabIndex = 17
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Lavender
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.cmbdiv)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.cmbstatus)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.BtnFind)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.txtpassword)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.LblTanggal)
        Me.Panel1.Controls.Add(Me.TxtNama)
        Me.Panel1.Controls.Add(Me.TxtUser)
        Me.Panel1.Location = New System.Drawing.Point(5, 51)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(395, 143)
        Me.Panel1.TabIndex = 128
        '
        'cmbdiv
        '
        Me.cmbdiv.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbdiv.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmbdiv.FormattingEnabled = True
        Me.cmbdiv.Location = New System.Drawing.Point(97, 85)
        Me.cmbdiv.Name = "cmbdiv"
        Me.cmbdiv.Size = New System.Drawing.Size(282, 21)
        Me.cmbdiv.TabIndex = 172
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(4, 88)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(48, 19)
        Me.Label5.TabIndex = 171
        Me.Label5.Text = "DIVISI"
        '
        'cmbstatus
        '
        Me.cmbstatus.BackColor = System.Drawing.Color.White
        Me.cmbstatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbstatus.FormattingEnabled = True
        Me.cmbstatus.Location = New System.Drawing.Point(97, 111)
        Me.cmbstatus.Name = "cmbstatus"
        Me.cmbstatus.Size = New System.Drawing.Size(282, 21)
        Me.cmbstatus.TabIndex = 170
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(4, 114)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(59, 19)
        Me.Label4.TabIndex = 169
        Me.Label4.Text = "STATUS"
        '
        'BtnFind
        '
        Me.BtnFind.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnFind.Font = New System.Drawing.Font("Stencil", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnFind.Image = CType(resources.GetObject("BtnFind.Image"), System.Drawing.Image)
        Me.BtnFind.Location = New System.Drawing.Point(345, 11)
        Me.BtnFind.Name = "BtnFind"
        Me.BtnFind.Size = New System.Drawing.Size(34, 21)
        Me.BtnFind.TabIndex = 168
        Me.BtnFind.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(4, 61)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(88, 19)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "PASSWORD"
        '
        'txtpassword
        '
        Me.txtpassword.Location = New System.Drawing.Point(97, 60)
        Me.txtpassword.Name = "txtpassword"
        Me.txtpassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtpassword.Size = New System.Drawing.Size(282, 20)
        Me.txtpassword.TabIndex = 14
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(4, 36)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(62, 19)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "USER ID"
        '
        'LblTanggal
        '
        Me.LblTanggal.AutoSize = True
        Me.LblTanggal.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTanggal.Location = New System.Drawing.Point(4, 11)
        Me.LblTanggal.Name = "LblTanggal"
        Me.LblTanggal.Size = New System.Drawing.Size(54, 19)
        Me.LblTanggal.TabIndex = 12
        Me.LblTanggal.Text = "NAMA"
        '
        'TxtNama
        '
        Me.TxtNama.Location = New System.Drawing.Point(97, 12)
        Me.TxtNama.Name = "TxtNama"
        Me.TxtNama.Size = New System.Drawing.Size(242, 20)
        Me.TxtNama.TabIndex = 11
        '
        'TxtUser
        '
        Me.TxtUser.Location = New System.Drawing.Point(97, 36)
        Me.TxtUser.Name = "TxtUser"
        Me.TxtUser.Size = New System.Drawing.Size(282, 20)
        Me.TxtUser.TabIndex = 5
        '
        'TreeView1
        '
        Me.TreeView1.Location = New System.Drawing.Point(406, 52)
        Me.TreeView1.Name = "TreeView1"
        Me.TreeView1.Size = New System.Drawing.Size(386, 527)
        Me.TreeView1.TabIndex = 132
        '
        'FrmMasterUser
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(793, 581)
        Me.Controls.Add(Me.TreeView1)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PictureBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.Name = "FrmMasterUser"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmMasterUser"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents BtCancel As System.Windows.Forms.Button
    Friend WithEvents BtSave As System.Windows.Forms.Button
    Friend WithEvents BtEdit As System.Windows.Forms.Button
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents ListView2 As System.Windows.Forms.ListView
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtfind As System.Windows.Forms.TextBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents TxtNama As System.Windows.Forms.TextBox
    Friend WithEvents TxtUser As System.Windows.Forms.TextBox
    Friend WithEvents BtnAdd As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtpassword As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents LblTanggal As System.Windows.Forms.Label
    Friend WithEvents BtnFind As System.Windows.Forms.Button
    Friend WithEvents cmbstatus As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TreeView1 As System.Windows.Forms.TreeView
    Friend WithEvents cmbdiv As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
End Class
