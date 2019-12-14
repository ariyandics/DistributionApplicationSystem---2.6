<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSJReturToko
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
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TxtTglRetur = New System.Windows.Forms.TextBox()
        Me.TxtUser = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.BtnFindNoRetur = New System.Windows.Forms.Button()
        Me.TxtNoReturToko = New System.Windows.Forms.TextBox()
        Me.BtnFindToko = New System.Windows.Forms.Button()
        Me.TxtNamaToko = New System.Windows.Forms.TextBox()
        Me.TxtKodeToko = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.TxtTotalRetur = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.TxtNetto = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.TxtAvgCost = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.TxtTotalQtyGS = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TxtTotalQtyBS = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TxtTotalQty = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TxtTotalItem = New System.Windows.Forms.TextBox()
        Me.BtnPrint = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ListView1
        '
        Me.ListView1.Location = New System.Drawing.Point(0, 119)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(1055, 278)
        Me.ListView1.TabIndex = 107
        Me.ListView1.UseCompatibleStateImageBehavior = False
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.TxtTglRetur)
        Me.Panel1.Controls.Add(Me.TxtUser)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.BtnFindNoRetur)
        Me.Panel1.Controls.Add(Me.TxtNoReturToko)
        Me.Panel1.Controls.Add(Me.BtnFindToko)
        Me.Panel1.Controls.Add(Me.TxtNamaToko)
        Me.Panel1.Controls.Add(Me.TxtKodeToko)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Location = New System.Drawing.Point(0, 50)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1072, 63)
        Me.Panel1.TabIndex = 106
        '
        'TxtTglRetur
        '
        Me.TxtTglRetur.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.TxtTglRetur.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTglRetur.Location = New System.Drawing.Point(860, 30)
        Me.TxtTglRetur.Name = "TxtTglRetur"
        Me.TxtTglRetur.ReadOnly = True
        Me.TxtTglRetur.Size = New System.Drawing.Size(185, 21)
        Me.TxtTglRetur.TabIndex = 22
        '
        'TxtUser
        '
        Me.TxtUser.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.TxtUser.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtUser.Location = New System.Drawing.Point(860, 4)
        Me.TxtUser.Name = "TxtUser"
        Me.TxtUser.ReadOnly = True
        Me.TxtUser.Size = New System.Drawing.Size(185, 21)
        Me.TxtUser.TabIndex = 20
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(762, 5)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(44, 19)
        Me.Label7.TabIndex = 19
        Me.Label7.Text = "USER"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(762, 32)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(82, 19)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "TGL RETUR"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(5, 31)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(121, 19)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "NO.RETUR TOKO"
        '
        'BtnFindNoRetur
        '
        Me.BtnFindNoRetur.BackColor = System.Drawing.Color.Transparent
        Me.BtnFindNoRetur.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Cyan
        Me.BtnFindNoRetur.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnFindNoRetur.ForeColor = System.Drawing.Color.Black
        Me.BtnFindNoRetur.Location = New System.Drawing.Point(280, 29)
        Me.BtnFindNoRetur.Name = "BtnFindNoRetur"
        Me.BtnFindNoRetur.Size = New System.Drawing.Size(38, 21)
        Me.BtnFindNoRetur.TabIndex = 11
        Me.BtnFindNoRetur.Text = "..."
        Me.BtnFindNoRetur.UseVisualStyleBackColor = False
        '
        'TxtNoReturToko
        '
        Me.TxtNoReturToko.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.TxtNoReturToko.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNoReturToko.Location = New System.Drawing.Point(133, 29)
        Me.TxtNoReturToko.Name = "TxtNoReturToko"
        Me.TxtNoReturToko.ReadOnly = True
        Me.TxtNoReturToko.Size = New System.Drawing.Size(141, 21)
        Me.TxtNoReturToko.TabIndex = 10
        '
        'BtnFindToko
        '
        Me.BtnFindToko.BackColor = System.Drawing.Color.Transparent
        Me.BtnFindToko.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Cyan
        Me.BtnFindToko.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnFindToko.ForeColor = System.Drawing.Color.Black
        Me.BtnFindToko.Location = New System.Drawing.Point(507, 3)
        Me.BtnFindToko.Name = "BtnFindToko"
        Me.BtnFindToko.Size = New System.Drawing.Size(38, 21)
        Me.BtnFindToko.TabIndex = 9
        Me.BtnFindToko.Text = "..."
        Me.BtnFindToko.UseVisualStyleBackColor = False
        '
        'TxtNamaToko
        '
        Me.TxtNamaToko.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.TxtNamaToko.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNamaToko.Location = New System.Drawing.Point(216, 3)
        Me.TxtNamaToko.Name = "TxtNamaToko"
        Me.TxtNamaToko.ReadOnly = True
        Me.TxtNamaToko.Size = New System.Drawing.Size(285, 21)
        Me.TxtNamaToko.TabIndex = 8
        '
        'TxtKodeToko
        '
        Me.TxtKodeToko.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.TxtKodeToko.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtKodeToko.Location = New System.Drawing.Point(133, 3)
        Me.TxtKodeToko.Name = "TxtKodeToko"
        Me.TxtKodeToko.ReadOnly = True
        Me.TxtKodeToko.Size = New System.Drawing.Size(77, 21)
        Me.TxtKodeToko.TabIndex = 7
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(5, 3)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(96, 19)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "NAMA TOKO"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label1.Font = New System.Drawing.Font("Britannic Bold", 20.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(69, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(523, 30)
        Me.Label1.TabIndex = 105
        Me.Label1.Text = "FORM SJ PENARIKAN BARANG RETUR TOKO"
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
        Me.PictureBox1.TabIndex = 104
        Me.PictureBox1.TabStop = False
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(799, 455)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(100, 19)
        Me.Label14.TabIndex = 131
        Me.Label14.Text = "TOTAL RETUR"
        '
        'TxtTotalRetur
        '
        Me.TxtTotalRetur.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.TxtTotalRetur.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTotalRetur.Location = New System.Drawing.Point(900, 453)
        Me.TxtTotalRetur.Name = "TxtTotalRetur"
        Me.TxtTotalRetur.ReadOnly = True
        Me.TxtTotalRetur.Size = New System.Drawing.Size(143, 21)
        Me.TxtTotalRetur.TabIndex = 130
        Me.TxtTotalRetur.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(799, 430)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(55, 19)
        Me.Label13.TabIndex = 129
        Me.Label13.Text = "NETTO"
        '
        'TxtNetto
        '
        Me.TxtNetto.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.TxtNetto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNetto.Location = New System.Drawing.Point(900, 428)
        Me.TxtNetto.Name = "TxtNetto"
        Me.TxtNetto.ReadOnly = True
        Me.TxtNetto.Size = New System.Drawing.Size(143, 21)
        Me.TxtNetto.TabIndex = 128
        Me.TxtNetto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(799, 406)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(76, 19)
        Me.Label12.TabIndex = 127
        Me.Label12.Text = "AVG COST"
        '
        'TxtAvgCost
        '
        Me.TxtAvgCost.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.TxtAvgCost.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtAvgCost.Location = New System.Drawing.Point(900, 403)
        Me.TxtAvgCost.Name = "TxtAvgCost"
        Me.TxtAvgCost.ReadOnly = True
        Me.TxtAvgCost.Size = New System.Drawing.Size(143, 21)
        Me.TxtAvgCost.TabIndex = 126
        Me.TxtAvgCost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(535, 480)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(105, 19)
        Me.Label11.TabIndex = 125
        Me.Label11.Text = "TOTAL QTY GS"
        '
        'TxtTotalQtyGS
        '
        Me.TxtTotalQtyGS.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.TxtTotalQtyGS.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTotalQtyGS.Location = New System.Drawing.Point(643, 478)
        Me.TxtTotalQtyGS.Name = "TxtTotalQtyGS"
        Me.TxtTotalQtyGS.ReadOnly = True
        Me.TxtTotalQtyGS.Size = New System.Drawing.Size(137, 21)
        Me.TxtTotalQtyGS.TabIndex = 124
        Me.TxtTotalQtyGS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(535, 455)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(104, 19)
        Me.Label10.TabIndex = 123
        Me.Label10.Text = "TOTAL QTY BS"
        '
        'TxtTotalQtyBS
        '
        Me.TxtTotalQtyBS.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.TxtTotalQtyBS.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTotalQtyBS.Location = New System.Drawing.Point(643, 453)
        Me.TxtTotalQtyBS.Name = "TxtTotalQtyBS"
        Me.TxtTotalQtyBS.ReadOnly = True
        Me.TxtTotalQtyBS.Size = New System.Drawing.Size(137, 21)
        Me.TxtTotalQtyBS.TabIndex = 122
        Me.TxtTotalQtyBS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(535, 430)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(83, 19)
        Me.Label9.TabIndex = 121
        Me.Label9.Text = "TOTAL QTY"
        '
        'TxtTotalQty
        '
        Me.TxtTotalQty.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.TxtTotalQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTotalQty.Location = New System.Drawing.Point(643, 428)
        Me.TxtTotalQty.Name = "TxtTotalQty"
        Me.TxtTotalQty.ReadOnly = True
        Me.TxtTotalQty.Size = New System.Drawing.Size(137, 21)
        Me.TxtTotalQty.TabIndex = 120
        Me.TxtTotalQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(535, 405)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(90, 19)
        Me.Label8.TabIndex = 119
        Me.Label8.Text = "TOTAL ITEM"
        '
        'TxtTotalItem
        '
        Me.TxtTotalItem.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.TxtTotalItem.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTotalItem.Location = New System.Drawing.Point(643, 403)
        Me.TxtTotalItem.Name = "TxtTotalItem"
        Me.TxtTotalItem.ReadOnly = True
        Me.TxtTotalItem.Size = New System.Drawing.Size(137, 21)
        Me.TxtTotalItem.TabIndex = 118
        Me.TxtTotalItem.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'BtnPrint
        '
        Me.BtnPrint.BackColor = System.Drawing.Color.Transparent
        Me.BtnPrint.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Cyan
        Me.BtnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnPrint.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnPrint.ForeColor = System.Drawing.Color.Black
        Me.BtnPrint.Location = New System.Drawing.Point(11, 403)
        Me.BtnPrint.Name = "BtnPrint"
        Me.BtnPrint.Size = New System.Drawing.Size(91, 41)
        Me.BtnPrint.TabIndex = 164
        Me.BtnPrint.Text = "&Print"
        Me.BtnPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnPrint.UseVisualStyleBackColor = False
        '
        'FrmSJReturToko
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1051, 504)
        Me.Controls.Add(Me.BtnPrint)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.TxtTotalRetur)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.TxtNetto)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.TxtAvgCost)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.TxtTotalQtyGS)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.TxtTotalQtyBS)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.TxtTotalQty)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.TxtTotalItem)
        Me.Controls.Add(Me.ListView1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PictureBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.Name = "FrmSJReturToko"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmSJReturToko"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents TxtTglRetur As System.Windows.Forms.TextBox
    Friend WithEvents TxtUser As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents BtnFindNoRetur As System.Windows.Forms.Button
    Friend WithEvents TxtNoReturToko As System.Windows.Forms.TextBox
    Friend WithEvents BtnFindToko As System.Windows.Forms.Button
    Friend WithEvents TxtNamaToko As System.Windows.Forms.TextBox
    Friend WithEvents TxtKodeToko As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents TxtTotalRetur As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents TxtNetto As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents TxtAvgCost As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents TxtTotalQtyGS As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents TxtTotalQtyBS As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents TxtTotalQty As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TxtTotalItem As System.Windows.Forms.TextBox
    Friend WithEvents BtnPrint As System.Windows.Forms.Button
End Class
