Public Class FrmError

    Private Sub FrmError_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Label1.Text = "ERROR!!!!!! QTY SCAN MELEBIHI PICKING LIST"
        'Label1.BackColor = Color.White
        Me.BackColor = Color.Black
        Me.Label1.Left = (Me.Width - Me.Label1.Width) / 2
        Me.Label1.Top = (Me.Height - Me.Label1.Height) / 2
        Label1.ForeColor = Color.Red


    End Sub
End Class