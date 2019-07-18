Option Explicit On
Option Strict On
Imports System.Data
Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports Microsoft.Office.Interop
Imports System.Data.OleDb
Imports System.IO
Imports System.Configuration

Public Class FrmConsumoReactivos
    Dim nombreHoja As String
    Private dt As DataTable
    Dim Da As New SqlDataAdapter
    Dim Cmd As New SqlCommand
    Dim Dataset As DataSet
    Dim editarreactivo As Boolean
    Dim Cn As New SqlConnection(ConfigurationManager.ConnectionStrings.Item("StringConexion").ToString())
    Dim cnStr As String
    Dim conn As New ADODB.Connection()
    Dim rsreactivos As New ADODB.Recordset()
    Dim rsalida As New ADODB.Recordset()
    Dim rentrada As New ADODB.Recordset()
    Dim reactivo As String
    Dim nombreArchivo As String
    Private Sub FrmConsumoReactivos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CargarReactivo()
        llenar_datagridviewReactivos()
    End Sub
    Private Sub CalcularStock()

        cnStr = ConfigurationManager.ConnectionStrings.Item("StringConexionODBC").ToString()
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
        sql = "SELECT     Fecha, NombreReactivo, Entrada, Salida, Saldo, SolTraslado, SolSalida ,  SolConsumo , RutaSoltraslado, RutaSolConsumo , id FROM         PB_Reactivos   WHERE        Fecha=  '" & CDate(DtFecha.Text) & "' and NombreReactivo= '" & (CmbReactivo.Text) & "'   ORDER BY Id "
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
            MessageBox.Show(ex.Message, Me.Text,
  MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub Dgreactivos_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgReactivos.CellDoubleClick

        If MsgBox("Esta Seguro Que Desea Eliminar El Registro Seleccionado?", vbYesNo, "") = vbYes Then
            Try
                If DBNull.Value.Equals(DgReactivos.CurrentRow.Cells("ID").Value) Then
                    Me.TxtConsumo.Clear()
                    Me.TxtEntrada.Clear()
                    Me.TxtSalidaConsumo.Clear()
                    Me.TxtSconsumo.Clear()
                    Me.TxtSTraslado.Clear()

                Else
                    Dim sqlConnectiondb As New System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings.Item("StringConexion").ToString())
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
                MessageBox.Show(ex.Message, Me.Text,
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
            ' ElseIf IsNumeric(TxtEntrada.Text) And IsNumeric(TxtConsumo.Text) Then
            '    MsgBox("Por favor Diligencie correctamente el formulario")
            ' Exit Sub
        End If

        If CmbReactivo.Text = "" Or CmbReactivo.Text = "Seleccione" Then
            MsgBox("Por favor Diligencie correctamente el formulario")
        Else
            ' SELECT     NombreReactivo, SUM(Entrada) - SUM(Salida) AS exp1 FROM         dbo.PB_Reactivos GROUP BY NombreReactivo HAVING      (NombreReactivo = '" & CmbReactivo.text & "') 
            Dim totalsaldo As Double
            totalsaldo = 0
            Try
                Dim sqlConnectiondb As New System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings.Item("StringConexion").ToString())
                Dim cmd As New System.Data.SqlClient.SqlCommand
                cmd.CommandType = System.Data.CommandType.Text
                If editarreactivo = True Then
                    'CONSULTA CUANDO EDITAR ES VERDADERO
                    cmd.CommandText = "UPDATE  PB_Reactivos  SET NombreReactivo = @NombreReactivo , SolTraslado=@SolTraslado,  RutaSoltraslado = @RutaSoltraslado ,  SolConsumo=@SolConsumo , SolSalida=@SolSalida , entrada=@entrada , salida=@salida , RutaSolSalida=@RutaSolSalida WHERE id=@id  "
                    cmd.Parameters.AddWithValue("@id", Convert.ToInt16(LblId.Text))
                Else
                    ' consulta sql si editar es falso 
                    cmd.CommandText = "INSERT INTO PB_Reactivos (Fecha, NombreReactivo, Entrada, Salida, SolTraslado, RutaSoltraslado, SolConsumo, RutaSolConsumo, SolSalida, saldo , RutaSolSalida)VALUES(@Fecha, @NombreReactivo, @Entrada, @Salida, @SolTraslado, @RutaSoltraslado, @SolConsumo, @RutaSolConsumo, @SolSalida , @saldo , @RutaSolSalida)"
                End If
                cmd.Parameters.AddWithValue("@NombreReactivo", Convert.ToString(CmbReactivo.Text))
                cmd.Parameters.AddWithValue("@SolTraslado", Convert.ToString(TxtSconsumo.Text))
                cmd.Parameters.AddWithValue("@RutaSoltraslado", Convert.ToString(LblSolTraslado.Text))
                cmd.Parameters.AddWithValue("@SolSalida", Convert.ToString(TxtSalidaConsumo.Text))
                cmd.Parameters.AddWithValue("@RutaSolConsumo", Convert.ToString(LblSolConsumo.Text))
                cmd.Parameters.AddWithValue("@SolConsumo", Convert.ToString(TxtSconsumo.Text))
                cmd.Parameters.AddWithValue("@RutaSolSalida", Convert.ToString(LblSaConsumo.Text))

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
                LblSolConsumo.Text = "N/A"
                LblSolTraslado.Text = "N/A"
                LblSaConsumo.Text = "N/A"
                BtnConsumo.Enabled = False
                BtonTraslado.Enabled = False
                BtnSalconsumo.Enabled = False
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


            cnStr = ConfigurationManager.ConnectionStrings.Item("StringConexionODBC").ToString()
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

    End Sub

    Private Sub DtFecha_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DtFecha.ValueChanged
        llenar_datagridviewReactivos()
    End Sub

    Private Sub CmbReactivo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbReactivo.SelectedIndexChanged
        llenar_datagridviewReactivos()
        reactivo = CmbReactivo.Text
        LblNombreReactivo.Text = reactivo
        CalcularStock(reactivo)
        'limpiar
        TxtConsumo.Clear()
        TxtEntrada.Clear()
        TxtSalidaConsumo.Clear()
        TxtSconsumo.Clear()
        TxtSTraslado.Clear()
        CalcularStock(reactivo)
        editarreactivo = False
        LblSolConsumo.Text = "N/A"
        LblSolTraslado.Text = "N/A"
        LblSaConsumo.Text = "N/A"
        BtnConsumo.Enabled = False
        BtonTraslado.Enabled = False
        BtnSalconsumo.Enabled = False
    End Sub

    Private Sub LblSolConsumo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LblSolConsumo.Click

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim openFD As New OpenFileDialog()
        With openFD
            .Title = "Seleccionar archivos"
            ' .Filter = "Todos los archivos (*.pdf)"
            .Multiselect = False
            .InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments

            If .ShowDialog = Windows.Forms.DialogResult.OK Then
                LblSolTraslado.Text = .FileName
                BtonTraslado.Text = .FileName
                ' nombreArchivo = Path.GetFileName(LblSolConsumo.Text)
            End If
        End With
        If LblSolTraslado.Text = "N/A" Then

        Else
            Try
                ' Dim nombreHoja As String = ObtenerNombrePrimeraHoja(Txtruta.Text)
                ' MessageBox.Show(nombreHoja)

                Dim vOrigen As String = LblSolTraslado.Text
                Dim vDestino As String = "\\athenea\Compartidos.MariaDama\OPERACIONES\REACTIVOS\ZEUS\TRASLADOS\" & CStr(Path.GetFileName(LblSolTraslado.Text))
                System.IO.File.Copy(vOrigen, vDestino, True)
                LblSolTraslado.BorderStyle = BorderStyle.FixedSingle
                ' Cargar(DgOrdenLab, LblSolConsumo.Text, nombreHoja)
                BtonTraslado.Enabled = True
                LblSolTraslado.Text = vDestino
                BtonTraslado.Text = "Abrir"
            Catch ex As OleDbException
                MessageBox.Show(ex.Message)
            End Try

        End If
        'AVERIGUAR NOMBRE DE HOJA

    End Sub



    Private Sub BtonTraslado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtonTraslado.Click
        System.Diagnostics.Process.Start(LblSolTraslado.Text)
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        Dim openFD As New OpenFileDialog()
        With openFD
            .Title = "Seleccionar archivos"
            ' .Filter = "Todos los archivos (*.pdf)"
            .Multiselect = False
            .InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments

            If .ShowDialog = Windows.Forms.DialogResult.OK Then
                LblSolConsumo.Text = .FileName
                BtnConsumo.Text = .FileName
                ' nombreArchivo = Path.GetFileName(LblSolConsumo.Text)
            End If
        End With
        If LblSolConsumo.Text = "N/A" Then

        Else
            Try
                Dim vOrigen As String = LblSolConsumo.Text
                Dim vDestino As String = "\\athenea\Compartidos.MariaDama\OPERACIONES\REACTIVOS\ZEUS\CONSUMOS\" & CStr(Path.GetFileName(LblSolConsumo.Text))
                System.IO.File.Copy(vOrigen, vDestino, True)
                LblSolTraslado.BorderStyle = BorderStyle.FixedSingle
                ' Cargar(DgOrdenLab, LblSolConsumo.Text, nombreHoja)
                BtonTraslado.Enabled = True
                LblSolConsumo.Text = vDestino
                BtnConsumo.Text = "Abrir"
            Catch ex As OleDbException
                MessageBox.Show(ex.Message)
            End Try

        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click

        Dim openFD As New OpenFileDialog()
        With openFD
            .Title = "Seleccionar archivos"
            ' .Filter = "Todos los archivos (*.pdf)"
            .Multiselect = False
            .InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments

            If .ShowDialog = Windows.Forms.DialogResult.OK Then
                LblSaConsumo.Text = .FileName
                BtnSalconsumo.Text = "Abrir"
                ' nombreArchivo = Path.GetFileName(LblSolConsumo.Text)
            End If
        End With
        If LblSaConsumo.Text = "N/A" Then
        Else
            Try
                Dim vOrigen As String = LblSaConsumo.Text
                Dim vDestino As String = "\\athenea\Compartidos.MariaDama\OPERACIONES\REACTIVOS\ZEUS\SALIDAS\" & CStr(Path.GetFileName(LblSaConsumo.Text))
                System.IO.File.Copy(vOrigen, vDestino, True)
                LblSaConsumo.BorderStyle = BorderStyle.FixedSingle
                ' Cargar(DgOrdenLab, LblSolConsumo.Text, nombreHoja)
                BtnSalconsumo.Enabled = True
                LblSaConsumo.Text = vDestino
                BtnSalconsumo.Text = "Abrir"
            Catch ex As OleDbException
                MessageBox.Show(ex.Message)
            End Try

        End If
    End Sub

    Private Sub BtnConsumo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnConsumo.Click
        System.Diagnostics.Process.Start(LblSolConsumo.Text)
    End Sub

    Private Sub BtnSalconsumo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSalconsumo.Click
        System.Diagnostics.Process.Start(LblSaConsumo.Text)
    End Sub
End Class