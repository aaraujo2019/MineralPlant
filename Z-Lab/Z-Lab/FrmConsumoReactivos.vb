Option Explicit On
Option Strict On
Imports System.Data
Imports System.Data.SqlClient
Imports System.Windows.Forms
Public Class FrmConsumoReactivos
    Private dt As DataTable
    Dim Da As New SqlDataAdapter
    Dim Cmd As New SqlCommand
    Dim Dataset As DataSet
    Dim editarreactivo As Boolean
    Dim Cn As New SqlConnection("Server=mercurio\gcg;uid=sa;pwd=BdZandor123*;database=PlantaBeneficio")
    Dim cnStr As String
    Dim conn As New ADODB.Connection()
    Dim rsreactivos As New ADODB.Recordset()
    Dim rsalida As New ADODB.Recordset()
    Dim rentrada As New ADODB.Recordset()
    Dim reactivo As String
    Private Sub FrmConsumoReactivos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CargarReactivo()
        llenar_datagridviewReactivos()
    End Sub
    Private Sub CalcularStock()

        cnStr = "Provider=SQLNCLI10;Initial Catalog=PlantaBeneficio;Data Source=mercurio; User ID=sa;Password=BdZandor123*;"
        conn.Open(cnStr)
        rsalida = conn.Execute(" SELECT * FROM         usuario WHERE (IdUsusario = '" & (LblUsuario.Text) & "')         ")
        If rsalida.EOF = True Then
            Me.LblArea.Text = "NO"
        Else
            Me.LblArea.Text = CStr((rsalida.Fields("Area").Value))
        End If
        conn.Close()



    End Sub
    Private Sub CargarReactivo()
        With Cmd
            .CommandType = CommandType.Text
            .CommandText = "SELECT     id, NombreReactivo, Visible FROM         RfReactivosPlanta where (Visible = 1) ORDER BY NombreReactivo"
            .Connection = Cn
        End With
        Da.SelectCommand = Cmd

        dt = New DataTable
        Da.Fill(dt)
        With CmbReactivo
            .DataSource = dt
            .DisplayMember = "NombreReactivo"
            .ValueMember = "NombreReactivo"
            .SelectedValue = 0
            .Text = "Seleccione"
        End With
    End Sub

    Private Sub llenar_datagridviewReactivos()
        'cargar DataGrid de Preparacion Daily
        Cn.Open()
        Dim ds As New DataSet
        Dim da As New SqlDataAdapter
        Dim sql As String
        sql = "SELECT     Fecha, NombreReactivo, Entrada, Salida, Saldo, SolTraslado, RutaSoltraslado, SolConsumo, RutaSolConsumo, SolSalida , id FROM         PB_Reactivos   WHERE        Fecha=  '" & CDate(DtFecha.Text) & "' and NombreReactivo= '" & (CmbReactivo.Text) & "'   ORDER BY Id "
        da.SelectCommand = New SqlCommand(sql, Cn)
        da.Fill(ds)
        Cn.Close()
        Dim dt As DataTable = ds.Tables(0)
        DgReactivos.DataSource = dt
        DgReactivos.AutoResizeColumns()
        ' DgReactivos.Columns("TonsHora").DefaultCellStyle.Format = "0.00"
        DgReactivos.Columns("fecha").Visible = False
        DgReactivos.Columns("id").Visible = False
        'DgReactivos.Columns("HoraInicial").HeaderText = "Hora Lectura"
        'DgReactivos.Columns("TonsHora").HeaderText = "Toneladas Procesadas"
        Me.DgReactivos.ReadOnly = False
    End Sub

    Private Sub DgReactivos_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgReactivos.CellClick
        Try
            'Aquí pongo lo que pasaría si el campo está en blanco o nulo
            If DBNull.Value.Equals(DgReactivos.CurrentRow.Cells("id").Value) Then
                Me.TxtConsumo.Clear()
                Me.TxtEntrada.Clear()
                Me.TxtSalidaConsumo.Clear()
                Me.TxtSconsumo.Clear()
                Me.TxtSTraslado.Clear()
            Else
                LblId.Text = CStr(Me.DgReactivos.Rows(e.RowIndex).Cells("ID").Value())

                CmbReactivo.Text = CStr(Me.DgReactivos.Rows(e.RowIndex).Cells("NombreReactivo").Value())

                TxtConsumo.Text = CStr(Me.DgReactivos.Rows(e.RowIndex).Cells("Salida").Value())
                TxtEntrada.Text = CStr(Me.DgReactivos.Rows(e.RowIndex).Cells("Entrada").Value())
                TxtSTraslado.Text = CStr(Me.DgReactivos.Rows(e.RowIndex).Cells("SolTraslado").Value())
                TxtSalidaConsumo.Text = CStr(Me.DgReactivos.Rows(e.RowIndex).Cells("SolConsumo").Value())
                TxtSTraslado.Text = CStr(Me.DgReactivos.Rows(e.RowIndex).Cells("SolSalida").Value())



                editarreactivo = True
            End If
        Catch ex As Exception
            ' Handle the exception.
            MessageBox.Show(ex.Message, Me.Text, _
  MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub DgPiedebanda_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgReactivos.CellDoubleClick

        If MsgBox("Esta Seguro Que Desea Eliminar El Registro Seleccionado?", vbYesNo, "") = vbYes Then
            Try
                If DBNull.Value.Equals(DgReactivos.CurrentRow.Cells("ID").Value) Then
                    Me.TxtConsumo.Clear()
                    Me.TxtEntrada.Clear()
                    Me.TxtSalidaConsumo.Clear()
                    Me.TxtSconsumo.Clear()
                    Me.TxtSTraslado.Clear()

                Else
                    Dim sqlConnectiondb As New System.Data.SqlClient.SqlConnection("Server=mercurio\gcg;uid=sa;pwd=BdZandor123*;database=PlantaBeneficio")
                    Dim cmd As New System.Data.SqlClient.SqlCommand
                    cmd.CommandType = System.Data.CommandType.Text
                    cmd.CommandText = "DELETE FROM PB_Reactivos    WHERE   ID= '" & LblId.Text & "'  "
                    cmd.Connection = sqlConnectiondb
                    sqlConnectiondb.Open()
                    cmd.ExecuteNonQuery()
                    sqlConnectiondb.Close()
                End If
                llenar_datagridviewReactivos()

                Me.TxtConsumo.Clear()
                Me.TxtEntrada.Clear()
                Me.TxtSalidaConsumo.Clear()
                Me.TxtSconsumo.Clear()
                Me.TxtSTraslado.Clear()
                editarreactivo = False
            Catch ex As Exception
                ' Handle the exception.
                MessageBox.Show(ex.Message, Me.Text, _
      MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Else
            'ACA EL CODIGO SI PULSA NO
        End If
    End Sub

    Private Sub CmdGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdGuardar.Click

        If IsDBNull(TxtEntrada.Text) And IsDBNull(TxtConsumo.Text) Then
            MsgBox("Por favor Diligencie correctamente el formulario")
            Exit Sub
        ElseIf IsNumeric(TxtEntrada.Text) And IsNumeric(TxtConsumo.Text) Then
            MsgBox("Por favor Diligencie correctamente el formulario")
            Exit Sub
        End If

        If CmbReactivo.Text = "" Or CmbReactivo.Text = "Seleccione" Then
            MsgBox("Por favor Diligencie correctamente el formulario")
        Else
            ' SELECT     NombreReactivo, SUM(Entrada) - SUM(Salida) AS exp1 FROM         dbo.PB_Reactivos GROUP BY NombreReactivo HAVING      (NombreReactivo = '" & CmbReactivo.text & "') 
            Dim totalsaldo As Double
            totalsaldo = 0
            Try
                Dim sqlConnectiondb As New System.Data.SqlClient.SqlConnection("Server=mercurio\gcg;uid=sa;pwd=BdZandor123*;database=PlantaBeneficio")
                Dim cmd As New System.Data.SqlClient.SqlCommand
                cmd.CommandType = System.Data.CommandType.Text
                If editarreactivo = True Then
                    'CONSULTA CUANDO EDITAR ES VERDADERO
                    cmd.CommandText = "UPDATE  PB_Reactivos  SET NombreReactivo = @NombreReactivo , SolTraslado=@SolTraslado,  RutaSoltraslado = @RutaSoltraslado ,  SolConsumo=@SolConsumo , SolSalida=@SolSalida , entrada=@entrada , salida=@salida WHERE id=@id  "
                    cmd.Parameters.AddWithValue("@id", Convert.ToInt16(LblId.Text))
                Else
                    ' consulta sql si editar es falso 
                    cmd.CommandText = "INSERT INTO PB_Reactivos (Fecha, NombreReactivo, Entrada, Salida, SolTraslado, RutaSoltraslado, SolConsumo, RutaSolConsumo, SolSalida, saldo)VALUES(@Fecha, @NombreReactivo, @Entrada, @Salida, @SolTraslado, @RutaSoltraslado, @SolConsumo, @RutaSolConsumo, @SolSalida , @saldo)"
                End If
                cmd.Parameters.AddWithValue("@NombreReactivo", Convert.ToString(CmbReactivo.Text))
                cmd.Parameters.AddWithValue("@SolTraslado", Convert.ToString(TxtSconsumo.Text))
                cmd.Parameters.AddWithValue("@RutaSoltraslado", Convert.ToString(LblSolTraslado.Text))
                cmd.Parameters.AddWithValue("@RutaSolConsumo", Convert.ToString(LblSolConsumo.Text))
                cmd.Parameters.AddWithValue("@SolConsumo", Convert.ToString(TxtSconsumo.Text))
                cmd.Parameters.AddWithValue("@SolSalida", Convert.ToString(TxtSalidaConsumo.Text))

                '----------------------------------------------------------------
                If IsDBNull(TxtEntrada.Text) Or TxtEntrada.Text = "" Then
                    cmd.Parameters.AddWithValue("@entrada", 0)
                Else
                    cmd.Parameters.AddWithValue("@entrada", Convert.ToDecimal(TxtEntrada.Text))
                    totalsaldo = CDbl(TxtEntrada.Text) + CDbl(LblSaldo.Text)
                End If

                If IsDBNull(TxtConsumo.Text) Or TxtConsumo.Text = "" Then
                    cmd.Parameters.AddWithValue("@salida", 0)
                Else
                    cmd.Parameters.AddWithValue("@salida", Convert.ToDecimal(TxtConsumo.Text))
                    totalsaldo = CDbl(LblSaldo.Text) - CDbl(TxtConsumo.Text)
                End If

                cmd.Parameters.AddWithValue("@fecha", CDate(DtFecha.Text))
                cmd.Parameters.AddWithValue("@saldo", totalsaldo)
                cmd.Connection = sqlConnectiondb
                sqlConnectiondb.Open()
                cmd.ExecuteNonQuery()
                sqlConnectiondb.Close()
                MessageBox.Show("Los datos se  guardaron Correctamente.")
                llenar_datagridviewReactivos()
                TxtConsumo.Clear()
                TxtEntrada.Clear()
                TxtSalidaConsumo.Clear()
                TxtSconsumo.Clear()
                TxtSTraslado.Clear()
                CalcularStock(reactivo)
                editarreactivo = False
            Catch ex As Exception                ' Handle the exception.
                MessageBox.Show(ex.Message, Me.Text, _
      MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        End If
    End Sub



    'Dim DsPriv As New DataSet
    'Dim EPermisos As New SqlClient.SqlDataAdapter("SELECT     NombreReactivo, SUM(Entrada) - SUM(Salida) AS exp1 FROM         dbo.PB_Reactivos GROUP BY NombreReactivo HAVING      (NombreReactivo = '" & CmbReactivo.Text & "') ", Cn)
    Private Sub CalcularStock(ByVal reactivo As String)
        Try


            cnStr = "Provider=SQLNCLI10;Initial Catalog=PlantaBeneficio;Data Source=mercurio; User ID=sa;Password=BdZandor123*;"
            conn.Open(cnStr)
            rsreactivos = conn.Execute(" SELECT     SUM(Entrada) - SUM(Salida) AS saldo FROM         dbo.PB_Reactivos WHERE   NombreReactivo= '" & (reactivo) & "'   ")
            If rsreactivos.EOF = True Then
                ' Me.LblArea.Text = "NO"
            Else
                If IsDBNull(rsreactivos.Fields("saldo").Value) Then
                    LblSaldo.Text = "0"
                Else
                    LblSaldo.Text = CStr(CDbl((rsreactivos.Fields("saldo").Value)))
                End If

            End If

            conn.Close()



        Catch ex As Exception
            Throw
        End Try
    End Sub

    'End Sub



    Private Sub listBox1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles LblSolConsumo.DoubleClick
        MsgBox("")
    End Sub

    Private Sub DtFecha_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DtFecha.ValueChanged
        llenar_datagridviewReactivos()
    End Sub

    Private Sub CmbReactivo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbReactivo.SelectedIndexChanged
        llenar_datagridviewReactivos()

        reactivo = CmbReactivo.Text
        LblNombreReactivo.Text = reactivo
        CalcularStock(reactivo)
    End Sub
End Class