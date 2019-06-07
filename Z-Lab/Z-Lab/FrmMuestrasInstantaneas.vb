Option Explicit On
Option Strict On
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports System.Windows.Forms

Public Class FrmMuestrasInstantaneas
    Private dt As DataTable
    Dim Da As New SqlDataAdapter
    Dim Cmd As New SqlCommand
    Dim Dataset As DataSet
    Dim editarinstantanea As Boolean
    Dim Cn As New SqlConnection(ConfigurationManager.AppSettings("StringConexion").ToString)
    Dim cnStr As String
    Private Sub CmdGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdGuardar.Click

        If Cmbubicacion.Text = "" Or CmbHora.Text = "" Or cmbtipomuestra.Text = "" Or cmbtipomuestra.Text = "Seleccione" Then
            MsgBox("Todos los campos son obligatorios, por favor Diligencie correctamente el formulario")
        Else
            Try
                Dim sqlConnectiondb As New System.Data.SqlClient.SqlConnection(ConfigurationManager.AppSettings("StringConexion").ToString)
                Dim cmd As New System.Data.SqlClient.SqlCommand
                cmd.CommandType = System.Data.CommandType.Text
                If editarinstantanea = True Then
                    'CONSULTA CUANDO EDITAR ES VERDADERO
                    cmd.CommandText = "UPDATE  PB_Instantaneas  SET hora = @hora , ubicacion=@ubicacion,  tenor = @tenor ,  Observaciones=@Observaciones , TipoMuestra=@TipoMuestra WHERE id=@id  "
                    cmd.Parameters.AddWithValue("@id", Convert.ToInt16(Lblid.Text))
                Else
                    ' consulta sql si editar es falso 
                    cmd.CommandText = "INSERT INTO PB_Instantaneas (hora ,ubicacion,tenor,  fecha , Observaciones ,TipoMuestra)VALUES(@hora ,@ubicacion,@tenor, @fecha,@Observaciones, @TipoMuestra)"
                End If
                cmd.Parameters.AddWithValue("@hora", Convert.ToString(CmbHora.Text))
                cmd.Parameters.AddWithValue("@ubicacion", Convert.ToString(Cmbubicacion.Text))
                cmd.Parameters.AddWithValue("@Observaciones", Convert.ToString(TxtObservaciones.Text))
                cmd.Parameters.AddWithValue("@tenor", Convert.ToDecimal(TxtTenor.Text))
                'TipoMuestra
                cmd.Parameters.AddWithValue("@TipoMuestra", Convert.ToString(cmbtipomuestra.Text))
                cmd.Parameters.AddWithValue("@fecha", CDate(DtFecha.Text))
                cmd.Connection = sqlConnectiondb
                sqlConnectiondb.Open()
                cmd.ExecuteNonQuery()
                sqlConnectiondb.Close()
                MessageBox.Show("Los datos se  guardaron Correctamente.")
                llenar_datagridviewmuestras()
                TxtTenor.Clear()
                editarinstantanea = False
            Catch ex As Exception                ' Handle the exception.
                MessageBox.Show(ex.Message, Me.Text,
      MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        End If
    End Sub
    Private Sub llenar_datagridviewmuestras()   'cargar DataGrid de Preparacion Daily
        Cn.Open()
        Dim ds As New DataSet
        Dim da As New SqlDataAdapter
        Dim sql As String
        sql = "SELECT   id,  fecha, hora, TipoMuestra ,tipomuestra , ubicacion, tenor, Observaciones    FROM PB_Instantaneas WHERE    (Fecha = '" & CDate(DtFecha.Text) & "') ORDER BY hora "
        da.SelectCommand = New SqlCommand(sql, Cn)
        da.Fill(ds)
        Cn.Close()
        Dim dt As DataTable = ds.Tables(0)
        DgVMuestras.DataSource = dt
        DgVMuestras.AutoResizeColumns()
        Me.DgVMuestras.Columns("id").Visible = False
        DgVMuestras.Columns("hora").HeaderText = "Hora"
        DgVMuestras.Columns("TipoMuestra").HeaderText = "Tipo de Muestra"
        DgVMuestras.Columns("ubicacion").HeaderText = "Ubicacion"
        DgVMuestras.Columns("fecha").Visible = False
        DgVMuestras.Columns("tenor").HeaderText = "Tenor ppm"
        DgVMuestras.Columns("Observaciones").HeaderText = "Comentarios"
        Me.DgVMuestras.ReadOnly = False
    End Sub

    Private Sub cargarubicacion()
        With Cmd
            .CommandType = CommandType.Text
            .CommandText = "SELECT     id, Nombre, Visible FROM         dbo.RfUbicacionMuestraInstantaneas"
            .Connection = Cn
        End With
        Da.SelectCommand = Cmd

        dt = New DataTable
        Da.Fill(dt)
        With Cmbubicacion
            .DataSource = dt
            .DisplayMember = "Nombre"
            .ValueMember = "Nombre"
            .SelectedValue = 0
            .Text = "Seleccione"
        End With
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

        With CmbHora
            .DataSource = dt
            .DisplayMember = "Militar"
            .ValueMember = "Id"
        End With


    End Sub

    Private Sub DgMuestra_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgVMuestras.CellClick
        Try
            'Aquí pongo lo que pasaría si el campo está en blanco o nulo

            If DBNull.Value.Equals(DgVMuestras.CurrentRow.Cells("ubicacion").Value) Then
                Me.TxtObservaciones.Clear()
                Me.TxtTenor.Clear()
                Me.Cmbubicacion.Text = ""
            Else
                CmbHora.Text = CStr(Me.DgVMuestras.Rows(e.RowIndex).Cells("hora").Value())
                Cmbubicacion.Text = CStr(Me.DgVMuestras.Rows(e.RowIndex).Cells("Ubicacion").Value())
                cmbtipomuestra.Text = CStr(Me.DgVMuestras.Rows(e.RowIndex).Cells("TipoMuestra").Value())
                TxtTenor.Text = CStr(Me.DgVMuestras.Rows(e.RowIndex).Cells("Tenor").Value())
                Lblid.Text = CStr(Me.DgVMuestras.Rows(e.RowIndex).Cells("id").Value())
                If IsDBNull(Me.DgVMuestras.Rows(e.RowIndex).Cells("Observaciones").Value()) Then

                Else
                    TxtObservaciones.Text = CStr(Me.DgVMuestras.Rows(e.RowIndex).Cells("Observaciones").Value())
                End If

                editarinstantanea = True
            End If

        Catch ex As Exception
            ' Handle the exception.
            MessageBox.Show(ex.Message, Me.Text,
  MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub DgMuestras_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgVMuestras.CellDoubleClick

        If MsgBox("Esta Seguro Que Desea Eliminar El Registro Seleccionado?", vbYesNo, "") = vbYes Then
            Try ' fue adentro
                If DBNull.Value.Equals(DgVMuestras.CurrentRow.Cells("Id").Value) Then  'Aquí pongo lo que pasaría si el campo está en blanco o nulo
                    TxtTenor.Clear()
                    TxtObservaciones.Clear()
                Else
                    Dim sqlConnectiondb As New System.Data.SqlClient.SqlConnection(ConfigurationManager.AppSettings("StringConexion").ToString)
                    Dim cmd As New System.Data.SqlClient.SqlCommand
                    cmd.CommandType = System.Data.CommandType.Text
                    cmd.CommandText = "DELETE FROM PB_Instantaneas    WHERE id=  '" & CStr(Lblid.Text) & "' "
                    cmd.Connection = sqlConnectiondb
                    sqlConnectiondb.Open()
                    cmd.ExecuteNonQuery()
                    sqlConnectiondb.Close()
                End If
                llenar_datagridviewmuestras()
                TxtTenor.Clear()
                TxtObservaciones.Clear()
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

    Private Sub FrmMuestras_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        llenar_datagridviewmuestras()
        cargarubicacion()
        CargarlistHoraInicio()
    End Sub

    Private Sub DtFecha_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DtFecha.ValueChanged
        llenar_datagridviewmuestras()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Cmbubicacion_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmbubicacion.SelectedIndexChanged

    End Sub
End Class