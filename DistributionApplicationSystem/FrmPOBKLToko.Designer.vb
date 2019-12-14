<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPOBKLToko
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
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ListView2 = New System.Windows.Forms.ListView()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.BtnRefreshProses = New System.Windows.Forms.Button()
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.BtnProsesPB = New System.Windows.Forms.Button()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dtPicking = New System.Windows.Forms.DateTimePicker()
        Me.BtnPrint = New System.Windows.Forms.Button()
        Me.BtnRefCetak = New System.Windows.Forms.Button()
        Me.ListView3 = New System.Windows.Forms.ListView()
        Me.Button2 = New System.Windows.Forms.Button()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label1.Font = New System.Drawing.Font("Britannic Bold", 20.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(23, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(281, 30)
        Me.Label1.TabIndex = 170
        Me.Label1.Text = "PROSES PO BKL TOKO"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(529, 50)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 169
        Me.PictureBox1.TabStop = False
        '
        'TabControl1
        '
        Me.TabControl1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(0, 52)
        Me.TabControl1.Multiline = True
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(531, 388)
        Me.TabControl1.TabIndex = 171
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.DodgerBlue
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.ListView2)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.Button1)
        Me.TabPage1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabPage1.Location = New System.Drawing.Point(4, 28)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(523, 356)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Absensi PO BKL Toko"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(275, 317)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(107, 31)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "TOTAL"
        '
        'ListView2
        '
        Me.ListView2.Location = New System.Drawing.Point(6, 6)
        Me.ListView2.Name = "ListView2"
        Me.ListView2.Size = New System.Drawing.Size(509, 299)
        Me.ListView2.TabIndex = 5
        Me.ListView2.UseCompatibleStateImageBehavior = False
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Black
        Me.Label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label2.Font = New System.Drawing.Font("Arial Rounded MT Bold", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Lime
        Me.Label2.Location = New System.Drawing.Point(390, 308)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(123, 42)
        Me.Label2.TabIndex = 4
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Button1
        '
        Me.Button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Yellow
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Location = New System.Drawing.Point(7, 308)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(108, 42)
        Me.Button1.TabIndex = 3
        Me.Button1.Text = "Refresh"
        Me.Button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button1.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.Color.DeepSkyBlue
        Me.TabPage2.Controls.Add(Me.BtnRefreshProses)
        Me.TabPage2.Controls.Add(Me.ListView1)
        Me.TabPage2.Controls.Add(Me.BtnProsesPB)
        Me.TabPage2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabPage2.Location = New System.Drawing.Point(4, 28)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(523, 356)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Proses PO BKL"
        '
        'BtnRefreshProses
        '
        Me.BtnRefreshProses.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Yellow
        Me.BtnRefreshProses.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnRefreshProses.Location = New System.Drawing.Point(301, 310)
        Me.BtnRefreshProses.Name = "BtnRefreshProses"
        Me.BtnRefreshProses.Size = New System.Drawing.Size(108, 42)
        Me.BtnRefreshProses.TabIndex = 6
        Me.BtnRefreshProses.Text = "Refresh"
        Me.BtnRefreshProses.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnRefreshProses.UseVisualStyleBackColor = True
        '
        'ListView1
        '
        Me.ListView1.AllowColumnReorder = True
        Me.ListView1.Location = New System.Drawing.Point(5, 6)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(514, 299)
        Me.ListView1.TabIndex = 5
        Me.ListView1.UseCompatibleStateImageBehavior = False
        '
        'BtnProsesPB
        '
        Me.BtnProsesPB.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Yellow
        Me.BtnProsesPB.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnProsesPB.Location = New System.Drawing.Point(411, 310)
        Me.BtnProsesPB.Name = "BtnProsesPB"
        Me.BtnProsesPB.Size = New System.Drawing.Size(108, 42)
        Me.BtnProsesPB.TabIndex = 4
        Me.BtnProsesPB.Text = "Proses"
        Me.BtnProsesPB.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnProsesPB.UseVisualStyleBackColor = True
        '
        'TabPage3
        '
        Me.TabPage3.BackColor = System.Drawing.Color.DarkTurquoise
        Me.TabPage3.Controls.Add(Me.Button2)
        Me.TabPage3.Controls.Add(Me.Label4)
        Me.TabPage3.Controls.Add(Me.dtPicking)
        Me.TabPage3.Controls.Add(Me.BtnPrint)
        Me.TabPage3.Controls.Add(Me.BtnRefCetak)
        Me.TabPage3.Controls.Add(Me.ListView3)
        Me.TabPage3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabPage3.Location = New System.Drawing.Point(4, 28)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(523, 356)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Cetak PO Supplier"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 10)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(56, 16)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "Tgl PO"
        '
        'dtPicking
        '
        Me.dtPicking.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtPicking.Location = New System.Drawing.Point(100, 5)
        Me.dtPicking.Name = "dtPicking"
        Me.dtPicking.Size = New System.Drawing.Size(121, 22)
        Me.dtPicking.TabIndex = 10
        '
        'BtnPrint
        '
        Me.BtnPrint.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Yellow
        Me.BtnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnPrint.Location = New System.Drawing.Point(411, 310)
        Me.BtnPrint.Name = "BtnPrint"
        Me.BtnPrint.Size = New System.Drawing.Size(108, 42)
        Me.BtnPrint.TabIndex = 9
        Me.BtnPrint.Text = "Print"
        Me.BtnPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnPrint.UseVisualStyleBackColor = True
        '
        'BtnRefCetak
        '
        Me.BtnRefCetak.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Yellow
        Me.BtnRefCetak.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnRefCetak.Location = New System.Drawing.Point(8, 310)
        Me.BtnRefCetak.Name = "BtnRefCetak"
        Me.BtnRefCetak.Size = New System.Drawing.Size(108, 42)
        Me.BtnRefCetak.TabIndex = 8
        Me.BtnRefCetak.Text = "Refresh"
        Me.BtnRefCetak.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnRefCetak.UseVisualStyleBackColor = True
        '
        'ListView3
        '
        Me.ListView3.AllowColumnReorder = True
        Me.ListView3.Location = New System.Drawing.Point(5, 33)
        Me.ListView3.Name = "ListView3"
        Me.ListView3.Size = New System.Drawing.Size(514, 272)
        Me.ListView3.TabIndex = 7
        Me.ListView3.UseCompatibleStateImageBehavior = False
        '
        'Button2
        '
        Me.Button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Yellow
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Location = New System.Drawing.Point(302, 310)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(108, 42)
        Me.Button2.TabIndex = 12
        Me.Button2.Text = "Print Rekap PO"
        Me.Button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button2.UseVisualStyleBackColor = True
        '
        'FrmPOBKLToko
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(529, 435)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PictureBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmPOBKLToko"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmPOBKLToko"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ListView2 As System.Windows.Forms.ListView
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents BtnRefreshProses As System.Windows.Forms.Button
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents BtnProsesPB As System.Windows.Forms.Button
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents dtPicking As System.Windows.Forms.DateTimePicker
    Friend WithEvents BtnPrint As System.Windows.Forms.Button
    Friend WithEvents BtnRefCetak As System.Windows.Forms.Button
    Friend WithEvents ListView3 As System.Windows.Forms.ListView
    Friend WithEvents Button2 As System.Windows.Forms.Button
End Class
