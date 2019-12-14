

Partial Public Class DataSetDSI
    Partial Class DsDetailStrukDataTable

        Private Sub DsDetailStrukDataTable_ColumnChanging(ByVal sender As System.Object, ByVal e As System.Data.DataColumnChangeEventArgs) Handles Me.ColumnChanging
            If (e.Column.ColumnName = Me.nomorTransaksiColumn.ColumnName) Then
                'Add user code here
            End If

        End Sub

    End Class

    Partial Class DsDetailDataTable

    End Class

End Class
