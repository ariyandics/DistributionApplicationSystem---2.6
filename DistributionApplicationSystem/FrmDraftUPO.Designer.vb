<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmDraftUPO
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BtnProses = New System.Windows.Forms.Button()
        Me.TxtTanggal = New System.Windows.Forms.TextBox()
        Me.LblTanggal = New System.Windows.Forms.Label()
        Me.TxtNamaDC = New System.Windows.Forms.TextBox()
        Me.TxtKodeDC = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.RptDraft = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.DataSetUPO1 = New DistributionApplicationSystem.DataSetUPO()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.DataSetUPO1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(1201, 49)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 8
        Me.PictureBox1.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label1.Font = New System.Drawing.Font("Britannic Bold", 20.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(332, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(278, 30)
        Me.Label1.TabIndex = 97
        Me.Label1.Text = "DRAFT UPO OTOMATIS"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.BtnProses)
        Me.Panel1.Controls.Add(Me.TxtTanggal)
        Me.Panel1.Controls.Add(Me.LblTanggal)
        Me.Panel1.Controls.Add(Me.TxtNamaDC)
        Me.Panel1.Controls.Add(Me.TxtKodeDC)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Location = New System.Drawing.Point(2, 51)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1199, 39)
        Me.Panel1.TabIndex = 98
        '
        'BtnProses
        '
        Me.BtnProses.BackColor = System.Drawing.Color.Transparent
        Me.BtnProses.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Cyan
        Me.BtnProses.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnProses.ForeColor = System.Drawing.Color.Black
        Me.BtnProses.Location = New System.Drawing.Point(435, 6)
        Me.BtnProses.Name = "BtnProses"
        Me.BtnProses.Size = New System.Drawing.Size(95, 23)
        Me.BtnProses.TabIndex = 5
        Me.BtnProses.Text = "PROSES"
        Me.BtnProses.UseVisualStyleBackColor = False
        '
        'TxtTanggal
        '
        Me.TxtTanggal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTanggal.Location = New System.Drawing.Point(956, 8)
        Me.TxtTanggal.Name = "TxtTanggal"
        Me.TxtTanggal.Size = New System.Drawing.Size(229, 20)
        Me.TxtTanggal.TabIndex = 4
        '
        'LblTanggal
        '
        Me.LblTanggal.AutoSize = True
        Me.LblTanggal.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTanggal.Location = New System.Drawing.Point(876, 8)
        Me.LblTanggal.Name = "LblTanggal"
        Me.LblTanggal.Size = New System.Drawing.Size(74, 19)
        Me.LblTanggal.TabIndex = 3
        Me.LblTanggal.Text = "TANGGAL"
        '
        'TxtNamaDC
        '
        Me.TxtNamaDC.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNamaDC.Location = New System.Drawing.Point(167, 8)
        Me.TxtNamaDC.Name = "TxtNamaDC"
        Me.TxtNamaDC.Size = New System.Drawing.Size(257, 21)
        Me.TxtNamaDC.TabIndex = 2
        '
        'TxtKodeDC
        '
        Me.TxtKodeDC.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtKodeDC.Location = New System.Drawing.Point(93, 8)
        Me.TxtKodeDC.Name = "TxtKodeDC"
        Me.TxtKodeDC.Size = New System.Drawing.Size(68, 21)
        Me.TxtKodeDC.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(5, 8)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(76, 19)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "NAMA DC"
        '
        'RptDraft
        '
        Me.RptDraft.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RptDraft.Location = New System.Drawing.Point(0, 101)
        Me.RptDraft.Name = "RptDraft"
        Me.RptDraft.Size = New System.Drawing.Size(1201, 561)
        Me.RptDraft.TabIndex = 99
        '
        'DataSetUPO1
        '
        Me.DataSetUPO1.DataSetName = "DataSetUPO"
        Me.DataSetUPO1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'FrmDraftUPO
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1201, 659)
        Me.Controls.Add(Me.RptDraft)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PictureBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Name = "FrmDraftUPO"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmDraftUPO"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.DataSetUPO1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents TxtNamaDC As System.Windows.Forms.TextBox
    Friend WithEvents TxtKodeDC As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents LblTanggal As System.Windows.Forms.Label
    Friend WithEvents TxtTanggal As System.Windows.Forms.TextBox
    Friend WithEvents BtnProses As System.Windows.Forms.Button
    Friend WithEvents RptDraft As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents DataSetUPO1 As DistributionApplicationSystem.DataSetUPO
End Class
