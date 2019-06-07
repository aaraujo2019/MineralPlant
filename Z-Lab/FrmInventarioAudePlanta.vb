Option Explicit On
Option Strict On
Imports System.Data
Imports System.Data.SqlClient
Imports Z_Lab.Login
Imports System.Data.OleDb
Imports System.Windows.Forms
Public Class FrmInventarioAudePlanta
    Private dt As DataTable
    Dim Da As New SqlDataAdapter
    Dim Cmd As New SqlCommand
    Dim Dataset As DataSet
    Dim editar As Boolean
    Dim Cn As New SqlConnection("Server=SEGSVRSQL01;uid=sa;pwd=*Bd6r4nC0l0mb1a*;database=PlantaBeneficio")
    Private Sub CmdGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdGuardar.Click
        Dim DsPriv As New DataSet

        Dim EPermisos As New SqlClient.SqlDataAdapter("SELECT Usuario, IdEvento FROM RfUserEvent" & _
" WHERE RfUserEvent.Usuario='" & LblUsuario.Text & "'  and (RfUserEvent.IdEvento  = 'ModificarFlujos'  ) ", Cn)
        EPermisos.Fill(DsPriv, "RfUserEvent")
        Dim myDataViewpermisos As DataView = New DataView(DsPriv.Tables("RfUserEvent"))

        If myDataViewpermisos.Count = 0 Then
            MsgBox("El usuario no tiene privilegios para Modificar en este Formulario. Contacte a su administrador.")
            Exit Sub
        End If


        If cmbubicacion.Text = "" Or txtAlturaSuperior.Text = "" Or TxtDensidad.Text = "" Then
            MsgBox("Todos los campos son obligatorios, por favor Diligencie correctamente el formulario")
        Else
            Try
                Dim sqlConnectiondb As New System.Data.SqlClient.SqlConnection("Server=SEGSVRSQL01;uid=sa;pwd=*Bd6r4nC0l0mb1a*;database=PlantaBeneficio")
                Dim cmd As New System.Data.SqlClient.SqlCommand
                cmd.CommandType = System.Data.CommandType.Text

                If editar = True Then
                    'CONSULTA CUANDO EDITAR ES VERDADERO
                    cmd.CommandText = "UPDATE  Pb_InventarioAuPlanta  SET Ubicacion = @Ubicacion , Densidad=@Densidad,  AlturaLibreSuperior = @AlturaLibreSuperior , AlturaLodos=@AlturaLodos , TenorSolucion=@TenorSolucion , TenorSolido=@TenorSolido WHERE IConsecutivo=@IConsecutivo  "
                Else
                    ' consulta sql si editar es falso 
                    cmd.CommandText = "INSERT INTO Pb_InventarioAuPlanta (IdPeriodo ,Ubicacion,Densidad,  AlturaLibreSuperior, AlturaLodos , TenorSolido ,TenorSolucion )VALUES(@IdPeriodo ,@Ubicacion,@Densidad, @AlturaLibreSuperior,  @AlturaLodos , @TenorSolido , @TenorSolucion)"
                End If
                cmd.Parameters.AddWithValue("@IdPeriodo", Convert.ToString(CmbIdPeriodo.Text))
                cmd.Parameters.AddWithValue("@IConsecutivo", Convert.ToString(Lblid.Text))
                cmd.Parameters.AddWithValue("@Ubicacion", Convert.ToString(cmbubicacion.Text))
                cmd.Parameters.AddWithValue("@Densidad", Convert.ToDecimal(TxtDensidad.Text))
                If txtausolido.Text = "" Then
                Else
                    cmd.Parameters.AddWithValue("@TenorSolido", Convert.ToDecimal(txtausolido.Text))
                End If
                If txtausolucion.Text = "" Then

                End If
                cmd.Parameters.AddWithValue("@TenorSolucion", Convert.ToDecimal(txtausolucion.Text))
                cmd.Parameters.AddWithValue("@AlturaLibreSuperior", Convert.ToDecimal(txtAlturaSuperior.Text))
                If TxtAlturaLodos.Text = "" Then
                    cmd.Parameters.AddWithValue("@AlturaLodos", 0)
                Else
                    cmd.Parameters.AddWithValue("@AlturaLodos", Convert.ToDecimal(TxtAlturaLodos.Text))
                End If

                cmd.Connection = sqlConnectiondb
                sqlConnectiondb.Open()
                cmd.ExecuteNonQuery()
                sqlConnectiondb.Close()
                MessageBox.Show("Los datos se  guardaron Correctamente.")
                'Llenar_DataGridViewDesarrollo()
                Llenar_DataGridViewInventario()
                ' TxtLecturaInicial.Text = TxtLecturaFinal.Text
                TxtDensidad.Clear()
                TxtAlturaLodos.Clear()
                txtAlturaSuperior.Clear()
                TxtDensidad.Clear()
                TxtDensidad.Focus()
                If editar = True Then
                Else

                End If

                editar = False

            Catch ex As Exception

                ' Handle the exception.
                MessageBox.Show(ex.Message, Me.Text, _
      MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        End If
    End Sub

    Private Sub DGINVENTARIO_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgInventario.CellDoubleClick

        If MsgBox("Esta Seguro Que Desea Eliminar El Registro Seleccionado?", vbYesNo, "") = vbYes Then
            Try ' fue adentro
                If DBNull.Value.Equals(DgInventario.CurrentRow.Cells("IConsecutivo").Value) Then  'Aquí pongo lo que pasaría si el campo está en blanco o nulo
                    TxtAlturaLodos.Clear()
                    txtAlturaSuperior.Clear()
                    TxtDensidad.Clear()
                Else
                    Dim sqlConnectiondb As New System.Data.SqlClient.SqlConnection("Server=SEGSVRSQL01;uid=sa;pwd=*Bd6r4nC0l0mb1a*;database=PlantaBeneficio")
                    Dim cmd As New System.Data.SqlClient.SqlCommand
                    cmd.CommandType = System.Data.CommandType.Text
                    cmd.CommandText = "DELETE FROM Pb_InventarioAuPlanta  WHERE IConsecutivo =  '" & CStr(Lblid.Text) & "'   "
                    cmd.Connection = sqlConnectiondb
                    sqlConnectiondb.Open()
                    cmd.ExecuteNonQuery()
                    sqlConnectiondb.Close()
                End If
                Llenar_DataGridViewInventario()
                TxtAlturaLodos.Clear()
                TxtDensidad.Clear()
                txtAlturaSuperior.Clear()
                editar = False
            Catch ex As Exception
                ' Handle the exception.
                MessageBox.Show(ex.Message, Me.Text, _
      MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        Else
            'ACA EL CODIGO SI PULSA NO

        End If


    End Sub




    Private Sub Llenar_DataGridViewInventario()   'cargar DataGrid de Preparacion Daily
        Cn.Open()
        Dim ds As New DataSet
        Dim da As New SqlDataAdapter
        Dim sql As String
        sql = " SELECT    IConsecutivo,   IdPeriodo, Ubicacion, Densidad, TenorSolido, AuSolidoFinal, TenorSolucion, AuSolucionFinal, AlturaLibreSuperior, AlturaLodos from    Pb_InventarioAuPlanta  WHERE IdPeriodo=  '" & (CmbIdPeriodo.Text) & "' order BY ubicacion "
        da.SelectCommand = New SqlCommand(sql, Cn)
        da.Fill(ds)
        Cn.Close()
        Dim dt As DataTable = ds.Tables(0)
        DgInventario.DataSource = dt
        DgInventario.AutoResizeColumns()
        Me.DgInventario.Columns("IConsecutivo").Visible = False
        Me.DgInventario.Columns("IdPeriodo").Visible = False
        DgInventario.Columns("AuSolidoFinal").DefaultCellStyle.Format = "00.00"
        DgInventario.Columns("TenorSolucion").DefaultCellStyle.Format = "00.00"
        DgInventario.Columns("AuSolidoFinal").DefaultCellStyle.Format = "00.00"
        DgInventario.Columns("AuSolucionFinal").DefaultCellStyle.Format = "00.00"
        DgInventario.Columns("Densidad").HeaderText = "Densidad Kg/Lt"
        DgInventario.Columns("TenorSolido").HeaderText = "Tenor Solido (ppm)"
        DgInventario.Columns("TenorSolucion").HeaderText = "Tenor Solucion (ppm)"
        DgInventario.Columns("AuSolidoFinal").HeaderText = "Oro en Sólido (Onzas)"
        DgInventario.Columns("AuSolucionFinal").HeaderText = "Oro en Solucion (Onzas)"

        Llenar_Total_INVENTARIO()
        Me.DgInventario.ReadOnly = False
    End Sub
    Private Sub Llenar_DgInventarioAuPlanta_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgInventario.CellClick
        Try
            'Aquí pongo lo que pasaría si el campo está en blanco o nulo

            If DBNull.Value.Equals(DgInventario.CurrentRow.Cells("IdPeriodo").Value) Then
                Me.TxtAlturaLodos.Clear()
                Me.txtAlturaSuperior.Clear()
                Me.TxtDensidad.Clear()
                txtausolido.Clear()
                txtausolucion.Clear()
                Me.txtAlturaSuperior.Clear()
            Else
                If DBNull.Value.Equals(DgInventario.CurrentRow.Cells("AlturaLodos").Value) Then
                Else
                    TxtAlturaLodos.Text = CStr(Me.DgInventario.Rows(e.RowIndex).Cells("AlturaLodos").Value())
                End If

                If DBNull.Value.Equals(DgInventario.CurrentRow.Cells("AlturaLibreSuperior").Value) Then
                Else
                    txtAlturaSuperior.Text = CStr(Me.DgInventario.Rows(e.RowIndex).Cells("AlturaLibreSuperior").Value())
                End If

                If DBNull.Value.Equals(DgInventario.CurrentRow.Cells("Densidad").Value) Then
                Else
                    TxtDensidad.Text = CStr(Me.DgInventario.Rows(e.RowIndex).Cells("Densidad").Value())
                End If

                If DBNull.Value.Equals(DgInventario.CurrentRow.Cells("TenorSolido").Value) Then
                Else
                    txtausolido.Text = CStr(Me.DgInventario.Rows(e.RowIndex).Cells("TenorSolido").Value())
                End If

                If DBNull.Value.Equals(DgInventario.CurrentRow.Cells("TenorSolucion").Value) Then
                Else
                    txtausolucion.Text = CStr(Me.DgInventario.Rows(e.RowIndex).Cells("TenorSolucion").Value())
                End If


                cmbubicacion.Text = CStr(Me.DgInventario.Rows(e.RowIndex).Cells("Ubicacion").Value())
                Lblid.Text = CStr(Me.DgInventario.Rows(e.RowIndex).Cells("IConsecutivo").Value())
                editar = True
            End If
        Catch ex As Exception
            ' Handle the exception.
            MessageBox.Show(ex.Message, Me.Text, _
  MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Sub CargarIdPeriodo()
        With Cmd
            .CommandType = CommandType.Text
            .CommandText = " SELECT        TOP (100) PERCENT IdPeriodos FROM            dbo.Pb_BalanceFisico  ORDER BY FechaInicial "
            .Connection = Cn
        End With
        Da.SelectCommand = Cmd
        dt = New DataTable
        Da.Fill(dt)
        With CmbIdPeriodo
            .DataSource = dt
            .DisplayMember = "IdPeriodos"
            .ValueMember = "IdPeriodos"
        End With
    End Sub

    Private Sub Cargarubicacion()
        With Cmd
            .CommandType = CommandType.Text
            .CommandText = " SELECT        TOP (100) PERCENT Nombre FROM            dbo.Pb_DimensionesTanques ORDER BY Nombre "
            .Connection = Cn
        End With
        Da.SelectCommand = Cmd
        dt = New DataTable
        Da.Fill(dt)
        With cmbubicacion
            .DataSource = dt
            .DisplayMember = "nombre"
            .ValueMember = "nombre"
        End With
    End Sub

    Private Sub CmbIdPeriodo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbIdPeriodo.SelectedIndexChanged
        Llenar_DataGridViewInventario()   'cargar DataGrid de Preparacion Daily
        Me.TxtAlturaLodos.Clear()
        Me.txtAlturaSuperior.Clear()
        Me.TxtDensidad.Clear()
        txtausolido.Clear()
        txtausolucion.Clear()
        Me.txtAlturaSuperior.Clear()

    End Sub

    Private Sub FrmInventarioAudePlanta_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.LblUsuario.Text = FrmPrincipal.LblUserName.Text
        Llenar_DataGridViewInventario()   'cargar DataGrid de Preparacion Daily
        CargarIdPeriodo()
        Cargarubicacion()
    End Sub
    Private Sub Llenar_Total_INVENTARIO()
        Dim registros As Decimal
        Dim Totalsolucion As Decimal
        Dim TotalSolido As Decimal
        Dim porcpasante As Decimal
        Dim porcsolido As Decimal
        Dim alimentogr As Decimal
        Dim tonseca As Decimal
        alimentogr = 0
        registros = 0
        TotalSolido = 0
        Totalsolucion = 0
        porcpasante = 0
        porcsolido = 0
        tonseca = 0
        For Each dRow As DataGridViewRow In DgInventario.Rows
            If (dRow.Cells.Item("UBICACION").Value) IsNot Nothing Then

                Totalsolucion = CDec(dRow.Cells.Item("AuSolucionFinal").Value) + Totalsolucion
                TotalSolido = CDec(dRow.Cells.Item("AuSolidoFinal").Value) + TotalSolido

            End If

            registros = registros + 1
        Next dRow
        If registros = 0 Then
            LblSolido.Text = "0"
            LblSolucion.Text = "0"
            Lbltotal.Text = "0"
        Else
            LblSolido.Text = CStr(Format(TotalSolido, "0.00"))
            LblSolucion.Text = CStr(Format(Totalsolucion, "0.00"))
            Lbltotal.Text = CStr(Format(TotalSolido + Totalsolucion, "0.00"))


        End If
        Me.DgInventario.ReadOnly = False
    End Sub

    Private Sub cmbubicacion_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbubicacion.SelectedIndexChanged

    End Sub
End Class