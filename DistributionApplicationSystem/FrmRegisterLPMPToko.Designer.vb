<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRegisterLPMPToko
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
        Me.TxtNamaDC = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TxtKodeDC = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.DTPTglAwal = New System.Windows.Forms.DateTimePicker()
        Me.DTPTglAkhir = New System.Windows.Forms.DateTimePicker()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.RBRupiah = New System.Windows.Forms.RadioButton()
        Me.RBPlu = New System.Windows.Forms.RadioButton()
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.BtnPriview = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
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
        Me.Label1.Location = New System.Drawing.Point(343, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(278, 30)
        Me.Label1.TabIndex = 172
        Me.Label1.Text = "REGISTER LPMP TOKO"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(1100, 50)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 171
        Me.PictureBox1.TabStop = False
        '
        'TxtNamaDC
        '
        Me.TxtNamaDC.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.TxtNamaDC.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNamaDC.Location = New System.Drawing.Point(139, 41)
        Me.TxtNamaDC.Name = "TxtNamaDC"
        Me.TxtNamaDC.ReadOnly = True
        Me.TxtNamaDC.Size = New System.Drawing.Size(258, 21)
        Me.TxtNamaDC.TabIndex = 176
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(11, 18)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(68, 19)
        Me.Label3.TabIndex = 175
        Me.Label3.Text = "KODE DC"
        '
        'TxtKodeDC
        '
        Me.TxtKodeDC.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.TxtKodeDC.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtKodeDC.Location = New System.Drawing.Point(139, 16)
        Me.TxtKodeDC.Name = "TxtKodeDC"
        Me.TxtKodeDC.ReadOnly = True
        Me.TxtKodeDC.Size = New System.Drawing.Size(141, 21)
        Me.TxtKodeDC.TabIndex = 174
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(11, 44)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(76, 19)
        Me.Label2.TabIndex = 173
        Me.Label2.Text = "NAMA DC" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(11, 70)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(68, 19)
        Me.Label4.TabIndex = 177
        Me.Label4.Text = "PERIODE"
        '
        'DTPTglAwal
        '
        Me.DTPTglAwal.Location = New System.Drawing.Point(139, 70)
        Me.DTPTglAwal.Name = "DTPTglAwal"
        Me.DTPTglAwal.Size = New System.Drawing.Size(200, 20)
        Me.DTPTglAwal.TabIndex = 178
        '
        'DTPTglAkhir
        '
        Me.DTPTglAkhir.Location = New System.Drawing.Point(386, 72)
        Me.DTPTglAkhir.Name = "DTPTglAkhir"
        Me.DTPTglAkhir.Size = New System.Drawing.Size(200, 20)
        Me.DTPTglAkhir.TabIndex = 179
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(345, 76)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(27, 13)
        Me.Label5.TabIndex = 180
        Me.Label5.Text = "S/D"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.RBRupiah)
        Me.GroupBox1.Controls.Add(Me.RBPlu)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(446, 16)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(267, 45)
        Me.GroupBox1.TabIndex = 181
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "View By"
        '
        'RBRupiah
        '
        Me.RBRupiah.AutoSize = True
        Me.RBRupiah.Location = New System.Drawing.Point(154, 19)
        Me.RBRupiah.Name = "RBRupiah"
        Me.RBRupiah.Size = New System.Drawing.Size(72, 17)
        Me.RBRupiah.TabIndex = 1
        Me.RBRupiah.TabStop = True
        Me.RBRupiah.Text = "RUPIAH"
        Me.RBRupiah.UseVisualStyleBackColor = True
        '
        'RBPlu
        '
        Me.RBPlu.AutoSize = True
        Me.RBPlu.Location = New System.Drawing.Point(28, 19)
        Me.RBPlu.Name = "RBPlu"
        Me.RBPlu.Size = New System.Drawing.Size(49, 17)
        Me.RBPlu.TabIndex = 0
        Me.RBPlu.TabStop = True
        Me.RBPlu.Text = "PLU"
        Me.RBPlu.UseVisualStyleBackColor = True
        '
        'ListView1
        '
        Me.ListView1.Location = New System.Drawing.Point(7, 178)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(1086, 241)
        Me.ListView1.TabIndex = 182
        Me.ListView1.UseCompatibleStateImageBehavior = False
        '
        'BtnPriview
        '
        Me.BtnPriview.BackColor = System.Drawing.Color.Transparent
        Me.BtnPriview.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnPriview.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnPriview.ForeColor = System.Drawing.Color.Black
        Me.BtnPriview.Location = New System.Drawing.Point(1021, 425)
        Me.BtnPriview.Name = "BtnPriview"
        Me.BtnPriview.Size = New System.Drawing.Size(72, 41)
        Me.BtnPriview.TabIndex = 183
        Me.BtnPriview.Text = "&Preview"
        Me.BtnPriview.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.TxtKodeDC)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Controls.Add(Me.TxtNamaDC)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.DTPTglAkhir)
        Me.Panel1.Controls.Add(Me.DTPTglAwal)
        Me.Panel1.Location = New System.Drawing.Point(7, 55)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1086, 115)
        Me.Panel1.TabIndex = 184
        '
        'FrmRegisterLPMPToko
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1100, 478)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.BtnPriview)
        Me.Controls.Add(Me.ListView1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PictureBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmRegisterLPMPToko"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmRegisterLPMPToko"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents TxtNamaDC As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxtKodeDC As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents DTPTglAwal As System.Windows.Forms.DateTimePicker
    Friend WithEvents DTPTglAkhir As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents RBRupiah As System.Windows.Forms.RadioButton
    Friend WithEvents RBPlu As System.Windows.Forms.RadioButton
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents BtnPriview As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
End Class
