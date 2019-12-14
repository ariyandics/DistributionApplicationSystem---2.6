<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRekapUPO
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
        Me.BtnFindNoUPO = New System.Windows.Forms.Button()
        Me.TxtNoUPO = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.BtnPreview = New System.Windows.Forms.Button()
        Me.ListView2 = New System.Windows.Forms.ListView()
        Me.BtnApprove = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.BtnPrint = New System.Windows.Forms.Button()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label1.Font = New System.Drawing.Font("Britannic Bold", 20.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(174, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(150, 30)
        Me.Label1.TabIndex = 99
        Me.Label1.Text = "REKAP UPO"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'BtnFindNoUPO
        '
        Me.BtnFindNoUPO.BackColor = System.Drawing.Color.Transparent
        Me.BtnFindNoUPO.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Cyan
        Me.BtnFindNoUPO.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnFindNoUPO.ForeColor = System.Drawing.Color.Black
        Me.BtnFindNoUPO.Location = New System.Drawing.Point(254, 55)
        Me.BtnFindNoUPO.Name = "BtnFindNoUPO"
        Me.BtnFindNoUPO.Size = New System.Drawing.Size(38, 21)
        Me.BtnFindNoUPO.TabIndex = 102
        Me.BtnFindNoUPO.Text = "..."
        Me.BtnFindNoUPO.UseVisualStyleBackColor = False
        '
        'TxtNoUPO
        '
        Me.TxtNoUPO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNoUPO.Location = New System.Drawing.Point(82, 55)
        Me.TxtNoUPO.MaxLength = 22
        Me.TxtNoUPO.Name = "TxtNoUPO"
        Me.TxtNoUPO.Size = New System.Drawing.Size(166, 21)
        Me.TxtNoUPO.TabIndex = 101
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(4, 55)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(69, 19)
        Me.Label3.TabIndex = 100
        Me.Label3.Text = "NO. UPO"
        '
        'BtnPreview
        '
        Me.BtnPreview.BackColor = System.Drawing.Color.Transparent
        Me.BtnPreview.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Cyan
        Me.BtnPreview.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnPreview.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnPreview.ForeColor = System.Drawing.Color.Black
        Me.BtnPreview.Location = New System.Drawing.Point(880, 56)
        Me.BtnPreview.Name = "BtnPreview"
        Me.BtnPreview.Size = New System.Drawing.Size(72, 21)
        Me.BtnPreview.TabIndex = 103
        Me.BtnPreview.UseVisualStyleBackColor = False
        '
        'ListView2
        '
        Me.ListView2.Location = New System.Drawing.Point(1, 85)
        Me.ListView2.Name = "ListView2"
        Me.ListView2.OwnerDraw = True
        Me.ListView2.Size = New System.Drawing.Size(955, 384)
        Me.ListView2.TabIndex = 104
        Me.ListView2.UseCompatibleStateImageBehavior = False
        '
        'BtnApprove
        '
        Me.BtnApprove.BackColor = System.Drawing.Color.Transparent
        Me.BtnApprove.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Cyan
        Me.BtnApprove.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnApprove.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnApprove.ForeColor = System.Drawing.Color.Black
        Me.BtnApprove.Location = New System.Drawing.Point(743, 475)
        Me.BtnApprove.Name = "BtnApprove"
        Me.BtnApprove.Size = New System.Drawing.Size(103, 41)
        Me.BtnApprove.TabIndex = 106
        Me.BtnApprove.Text = "Appr&oval"
        Me.BtnApprove.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnApprove.UseVisualStyleBackColor = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(956, 49)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 98
        Me.PictureBox1.TabStop = False
        '
        'BtnPrint
        '
        Me.BtnPrint.BackColor = System.Drawing.Color.Transparent
        Me.BtnPrint.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Cyan
        Me.BtnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnPrint.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnPrint.ForeColor = System.Drawing.Color.Black
        Me.BtnPrint.Location = New System.Drawing.Point(847, 475)
        Me.BtnPrint.Name = "BtnPrint"
        Me.BtnPrint.Size = New System.Drawing.Size(103, 41)
        Me.BtnPrint.TabIndex = 107
        Me.BtnPrint.Text = "&Print"
        Me.BtnPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnPrint.UseVisualStyleBackColor = False
        '
        'FrmRekapUPO
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(956, 522)
        Me.Controls.Add(Me.BtnPrint)
        Me.Controls.Add(Me.BtnApprove)
        Me.Controls.Add(Me.ListView2)
        Me.Controls.Add(Me.BtnPreview)
        Me.Controls.Add(Me.BtnFindNoUPO)
        Me.Controls.Add(Me.TxtNoUPO)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PictureBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.Name = "FrmRekapUPO"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmRekapUPO"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents BtnFindNoUPO As System.Windows.Forms.Button
    Friend WithEvents TxtNoUPO As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents BtnPreview As System.Windows.Forms.Button
    Friend WithEvents ListView2 As System.Windows.Forms.ListView
    Friend WithEvents BtnApprove As System.Windows.Forms.Button
    Friend WithEvents BtnPrint As System.Windows.Forms.Button
End Class
