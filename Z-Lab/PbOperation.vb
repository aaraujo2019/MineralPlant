Partial Class PbOperation
    Partial Class PB_OperationDataTable

        Private Sub PB_OperationDataTable_ColumnChanging(ByVal sender As System.Object, ByVal e As System.Data.DataColumnChangeEventArgs) Handles Me.ColumnChanging
            If (e.Column.ColumnName = Me.ConsumoEnergiaColumn.ColumnName) Then
                'Add user code here
            End If

        End Sub

    End Class

End Class
