Option Explicit On
Option Strict On
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports System.Windows.Forms

Public Class FrmGravedadEspecifica
    Private dt As DataTable
    Dim Da As New SqlDataAdapter
    Dim Cmd As New SqlCommand
    Dim Dataset As DataSet
    Dim editarinstantanea As Boolean
    Dim Cn As New SqlConnection(ConfigurationManager.ConnectionStrings.Item("StringConexion").ToString())
    Dim cnStr As String
    Private Sub FrmGravedadEspecifica_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        llenar_datagridviewGravedad()
        CargarlistHoraInicio()
    End Sub
    Private Sub llenar_datagridviewGravedad()   'cargar DataGrid de Preparacion Daily
        Cn.Open()
        Dim ds As New DataSet
        Dim da As New SqlDataAdapter
        Dim sql As String
        sql = "SELECT    Id,  Fecha, IdLab, GravedadEspecifica, Ubicacion, HoraInicio, HoraFinal, Turno    FROM dbo.PB_GravedadEspecifica WHERE    (Fecha = '" & CDate(DtFecha.Text) & "') ORDER BY HoraInicio "
        da.SelectCommand = New SqlCommand(sql, Cn)
        da.Fill(ds)
        Cn.Close()
        Dim dt As DataTable = ds.Tables(0)
        DgGravedad.DataSource = dt
        DgGravedad.AutoResizeColumns()
        Me.DgGravedad.Columns("id").Visible = False

        DgGravedad.Columns("HoraInicio").HeaderText = "Hora Inicio"
        DgGravedad.Columns("HoraFinal").HeaderText = "Hora final"
        DgGravedad.Columns("ubicacion").HeaderText = "Ubicacion"
        DgGravedad.Columns("fecha").Visible = False
        DgGravedad.Columns("GravedadEspecifica").HeaderText = "Gravedad Especifica"
        DgGravedad.Columns("GravedadEspecifica").DefaultCellStyle.Format = "0.00"
        Me.DgGravedad.ReadOnly = False
    End Sub



    Private Sub DtFecha_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DtFecha.ValueChanged
        llenar_datagridviewGravedad()

    End Sub

    Private Sub CmdGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdGuardar.Click

        If Cmbubicacion.Text = "" Or CmbHorainicio.Text = "" Or CmbHoraFinal.Text = "" Or Cmbubicacion.Text = "Seleccione" Or TxtGravedad.Text = "" Then
            MsgBox("Todos los campos son obligatorios, por favor Diligencie correctamente el formulario")
        Else
            Try
                Dim sqlConnectiondb As New System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings.Item("StringConexion").ToString())
                Dim cmd As New System.Data.SqlClient.SqlCommand
                cmd.CommandType = System.Data.CommandType.Text
                If editarinstantanea = True Then
                    'CONSULTA CUANDO EDITAR ES VERDADERO
                    cmd.CommandText = "UPDATE  PB_GravedadEspecifica  SET horaInicio = @horaInicio , horaFinal=@horaFinal,  ubicacion = @ubicacion ,  GravedadEspecifica=@GravedadEspecifica , fecha=@fecha WHERE id=@id  "
                    cmd.Parameters.AddWithValue("@id", Convert.ToInt16(Lblid.Text))
                Else
                    ' consulta sql si editar es falso 
                    cmd.CommandText = "INSERT INTO PB_GravedadEspecifica (horaInicio ,horaFinal,ubicacion,  GravedadEspecifica , fecha)VALUES(@horaInicio ,@horaFinal,@ubicacion, @GravedadEspecifica,@fecha)"
                End If
                cmd.Parameters.AddWithValue("@horaInicio", Convert.ToString(CmbHorainicio.Text))
                cmd.Parameters.AddWithValue("@horaFinal", Convert.ToString(CmbHoraFinal.Text))
                cmd.Parameters.AddWithValue("@ubicacion", Convert.ToString(Cmbubicacion.Text))
                cmd.Parameters.AddWithValue("@GravedadEspecifica", Convert.ToString(TxtGravedad.Text))
                cmd.Parameters.AddWithValue("@fecha", CDate(DtFecha.Text))
                cmd.Connection = sqlConnectiondb
                sqlConnectiondb.Open()
                cmd.ExecuteNonQuery()
                sqlConnectiondb.Close()
                MessageBox.Show("Los datos se  guardaron Correctamente.")
                llenar_datagridviewGravedad()
                TxtGravedad.Clear()

                editarinstantanea = False
            Catch ex As Exception                ' Handle the exception.
                MessageBox.Show(ex.Message, Me.Text,
      MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        End If

    End Sub


    Private Sub CargarlistHoraInicio()
        With Cmd
            .CommandType = CommandType.Text
            .CommandText = "SELECT        Id, Hora, Militar, Tipo FROM            RfTime  ORDER BY Orden"
            .Connection = Cn
        End With
        Da.SelectCommand = Cmd

        dt = New DataTable
        Da.Fill(dt)

        With CmbHorainicio
            .DataSource = dt
            .DisplayMember = "Militar"
            .ValueMember = "Id"
        End With
        With CmbHoraFinal
            .DataSource = dt
            .DisplayMember = "Militar"
            .ValueMember = "Id"
        End With

    End Sub
    Private Sub DgMuestra_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgGravedad.CellClick
        Try
            'Aquí pongo lo que pasaría si el campo está en blanco o nulo

            If DBNull.Value.Equals(DgGravedad.CurrentRow.Cells("ubicacion").Value) Then
                Me.CmbHoraFinal.Text = ""
                Me.CmbHorainicio.Text = ""
                Me.TxtGravedad.Clear()
            Else
                CmbHorainicio.Text = CStr(Me.DgGravedad.Rows(e.RowIndex).Cells("HoraInicio").Value())
                CmbHoraFinal.Text = CStr(Me.DgGravedad.Rows(e.RowIndex).Cells("HoraFinal").Value())
                Cmbubicacion.Text = CStr(Me.DgGravedad.Rows(e.RowIndex).Cells("Ubicacion").Value())
                TxtGravedad.Text = CStr(Me.DgGravedad.Rows(e.RowIndex).Cells("GravedadEspecifica").Value())
                Lblid.Text = CStr(Me.DgGravedad.Rows(e.RowIndex).Cells("id").Value())

                editarinstantanea = True
            End If

        Catch ex As Exception
            ' Handle the exception.
            MessageBox.Show(ex.Message, Me.Text,
  MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub DgMuestras_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgGravedad.CellDoubleClick

        If MsgBox("Esta Seguro Que Desea Eliminar El Registro Seleccionado?", vbYesNo, "") = vbYes Then
            Try ' fue adentro
                If DBNull.Value.Equals(DgGravedad.CurrentRow.Cells("Id").Value) Then  'Aquí pongo lo que pasaría si el campo está en blanco o nulo
                    TxtGravedad.Clear()
                    CmbHorainicio.Text = ""
                    CmbHoraFinal.Text = ""
                    Cmbubicacion.Text = ""
                Else
                    Dim sqlConnectiondb As New System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings.Item("StringConexion").ToString())
                    Dim cmd As New System.Data.SqlClient.SqlCommand
                    cmd.CommandType = System.Data.CommandType.Text
                    cmd.CommandText = "DELETE FROM Pb_gravedadespecifica    WHERE id=  '" & CStr(Lblid.Text) & "' "
                    cmd.Connection = sqlConnectiondb
                    sqlConnectiondb.Open()
                    cmd.ExecuteNonQuery()
                    sqlConnectiondb.Close()
                End If
                llenar_datagridviewGravedad()
                TxtGravedad.Clear()
                CmbHoraFinal.Text = ""
                CmbHorainicio.Text = ""
                Cmbubicacion.Text = ""
                editarinstantanea = False
            Catch ex As Exception
                ' Handle the exception.
                MessageBox.Show(ex.Message, Me.Text, _
      MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        Else
            'ACA EL CODIGO SI PULSA NO

        End If


    End Sub
End Class