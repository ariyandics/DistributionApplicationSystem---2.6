<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmAdjreason
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TxtJenisStock = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.BtnFindNoAdj = New System.Windows.Forms.Button()
        Me.TxtTglApprove = New System.Windows.Forms.TextBox()
        Me.TxtUser = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TxtNoAdj = New System.Windows.Forms.TextBox()
        Me.DgSO = New System.Windows.Forms.DataGridView()
        Me.BtnApprove = New System.Windows.Forms.Button()
        Me.BtnSave = New System.Windows.Forms.Button()
        Me.BtnPrint = New System.Windows.Forms.Button()
        Me.BtnEdit = New System.Windows.Forms.Button()
        Me.BtnCancel = New System.Windows.Forms.Button()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.DgSO, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label1.Font = New System.Drawing.Font("Britannic Bold", 20.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(21, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(269, 30)
        Me.Label1.TabIndex = 214
        Me.Label1.Text = "ADJUSTMENT REASON"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(997, 49)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 213
        Me.PictureBox1.TabStop = False
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.TxtJenisStock)
        Me.Panel1.Controls.Add(Me.Label10)
        Me.Panel1.Controls.Add(Me.BtnFindNoAdj)
        Me.Panel1.Controls.Add(Me.TxtTglApprove)
        Me.Panel1.Controls.Add(Me.TxtUser)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.TxtNoAdj)
        Me.Panel1.Location = New System.Drawing.Point(0, 51)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(997, 72)
        Me.Panel1.TabIndex = 215
        '
        'TxtJenisStock
        '
        Me.TxtJenisStock.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.TxtJenisStock.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtJenisStock.Location = New System.Drawing.Point(815, 35)
        Me.TxtJenisStock.Name = "TxtJenisStock"
        Me.TxtJenisStock.ReadOnly = True
        Me.TxtJenisStock.Size = New System.Drawing.Size(153, 21)
        Me.TxtJenisStock.TabIndex = 216
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(703, 38)
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
        Me.BtnFindNoAdj.Location = New System.Drawing.Point(283, 9)
        Me.BtnFindNoAdj.Name = "BtnFindNoAdj"
        Me.BtnFindNoAdj.Size = New System.Drawing.Size(38, 21)
        Me.BtnFindNoAdj.TabIndex = 214
        Me.BtnFindNoAdj.Text = "..."
        Me.BtnFindNoAdj.UseVisualStyleBackColor = False
        '
        'TxtTglApprove
        '
        Me.TxtTglApprove.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.TxtTglApprove.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTglApprove.Location = New System.Drawing.Point(136, 35)
        Me.TxtTglApprove.Name = "TxtTglApprove"
        Me.TxtTglApprove.ReadOnly = True
        Me.TxtTglApprove.Size = New System.Drawing.Size(141, 21)
        Me.TxtTglApprove.TabIndex = 21
        '
        'TxtUser
        '
        Me.TxtUser.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.TxtUser.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtUser.Location = New System.Drawing.Point(815, 9)
        Me.TxtUser.Name = "TxtUser"
        Me.TxtUser.ReadOnly = True
        Me.TxtUser.Size = New System.Drawing.Size(153, 21)
        Me.TxtUser.TabIndex = 20
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(703, 10)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(44, 19)
        Me.Label7.TabIndex = 19
        Me.Label7.Text = "USER"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(3, 38)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(99, 19)
        Me.Label6.TabIndex = 17
        Me.Label6.Text = "TGL POSTING"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(5, 11)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(127, 19)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "NO ADJUSTMENT"
        '
        'TxtNoAdj
        '
        Me.TxtNoAdj.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.TxtNoAdj.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNoAdj.Location = New System.Drawing.Point(136, 9)
        Me.TxtNoAdj.Name = "TxtNoAdj"
        Me.TxtNoAdj.ReadOnly = True
        Me.TxtNoAdj.Size = New System.Drawing.Size(141, 21)
        Me.TxtNoAdj.TabIndex = 10
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
        Me.DgSO.Location = New System.Drawing.Point(0, 134)
        Me.DgSO.Name = "DgSO"
        Me.DgSO.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders
        Me.DgSO.Size = New System.Drawing.Size(997, 383)
        Me.DgSO.TabIndex = 236
        '
        'BtnApprove
        '
        Me.BtnApprove.BackColor = System.Drawing.Color.Transparent
        Me.BtnApprove.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Cyan
        Me.BtnApprove.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnApprove.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnApprove.ForeColor = System.Drawing.Color.Black
        Me.BtnApprove.Location = New System.Drawing.Point(785, 523)
        Me.BtnApprove.Name = "BtnApprove"
        Me.BtnApprove.Size = New System.Drawing.Size(102, 41)
        Me.BtnApprove.TabIndex = 240
        Me.BtnApprove.Text = "P&osting"
        Me.BtnApprove.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnApprove.UseVisualStyleBackColor = False
        '
        'BtnSave
        '
        Me.BtnSave.BackColor = System.Drawing.Color.Transparent
        Me.BtnSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Cyan
        Me.BtnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSave.ForeColor = System.Drawing.Color.Black
        Me.BtnSave.Location = New System.Drawing.Point(579, 523)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(102, 41)
        Me.BtnSave.TabIndex = 238
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
        Me.BtnPrint.Location = New System.Drawing.Point(888, 523)
        Me.BtnPrint.Name = "BtnPrint"
        Me.BtnPrint.Size = New System.Drawing.Size(102, 41)
        Me.BtnPrint.TabIndex = 237
        Me.BtnPrint.Text = "&Print"
        Me.BtnPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnPrint.UseVisualStyleBackColor = False
        '
        'BtnEdit
        '
        Me.BtnEdit.BackColor = System.Drawing.Color.Transparent
        Me.BtnEdit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Cyan
        Me.BtnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnEdit.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnEdit.ForeColor = System.Drawing.Color.Black
        Me.BtnEdit.Location = New System.Drawing.Point(476, 523)
        Me.BtnEdit.Name = "BtnEdit"
        Me.BtnEdit.Size = New System.Drawing.Size(102, 41)
        Me.BtnEdit.TabIndex = 239
        Me.BtnEdit.Text = "&Edit"
        Me.BtnEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnEdit.UseVisualStyleBackColor = False
        '
        'BtnCancel
        '
        Me.BtnCancel.BackColor = System.Drawing.Color.Transparent
        Me.BtnCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Cyan
        Me.BtnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCancel.ForeColor = System.Drawing.Color.Black
        Me.BtnCancel.Location = New System.Drawing.Point(682, 523)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(102, 41)
        Me.BtnCancel.TabIndex = 241
        Me.BtnCancel.Text = "&Cancel"
        Me.BtnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnCancel.UseVisualStyleBackColor = False
        '
        'FrmAdjreason
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(997, 567)
        Me.Controls.Add(Me.BtnCancel)
        Me.Controls.Add(Me.BtnApprove)
        Me.Controls.Add(Me.BtnSave)
        Me.Controls.Add(Me.BtnPrint)
        Me.Controls.Add(Me.BtnEdit)
        Me.Controls.Add(Me.DgSO)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PictureBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.Name = "FrmAdjreason"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmAdjreason"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.DgSO, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents TxtJenisStock As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents BtnFindNoAdj As System.Windows.Forms.Button
    Friend WithEvents TxtTglApprove As System.Windows.Forms.TextBox
    Friend WithEvents TxtUser As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxtNoAdj As System.Windows.Forms.TextBox
    Friend WithEvents DgSO As System.Windows.Forms.DataGridView
    Friend WithEvents BtnApprove As System.Windows.Forms.Button
    Friend WithEvents BtnSave As System.Windows.Forms.Button
    Friend WithEvents BtnPrint As System.Windows.Forms.Button
    Friend WithEvents BtnEdit As System.Windows.Forms.Button
    Friend WithEvents BtnCancel As System.Windows.Forms.Button
End Class
