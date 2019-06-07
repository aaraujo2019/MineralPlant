Option Explicit On
Option Strict On
Imports System.Data
Imports System.Data.SqlClient

Imports System.Data.OleDb
Imports System.Windows.Forms

Public Class FrmGranulometria
    Private dt As DataTable
    Dim Da As New SqlDataAdapter
    Dim Cmd As New SqlCommand
    Dim Dataset As DataSet
    Dim Cn As New SqlConnection("Server=mercurio\gcg;uid=sa;pwd=BdZandor123*;database=PlantaBeneficio")
    Dim editargranulometria As Boolean
    Dim cnStr As String

    Private Sub FrmGranulometria_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.LblUsuario.Text = FrmPrincipal.LblUserName.Text
        CargarlistHoraInicio()
        llenardatagridviewgranulometria()
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
            .DisplayMember = "Hora"
            .ValueMember = "Id"
        End With


    End Sub

    Private Sub CmdGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdGuardar.Click
        Dim DsPriv As New DataSet
        Dim EPermisos As New SqlClient.SqlDataAdapter("SELECT Usuario, IdEvento FROM RfUserEvent" & _
" WHERE RfUserEvent.Usuario='" & LblUsuario.Text & "'  and (RfUserEvent.IdEvento  = 'ModificarGranulometria'  ) ", Cn)
        EPermisos.Fill(DsPriv, "RfUserEvent")
        Dim myDataViewpermisos As DataView = New DataView(DsPriv.Tables("RfUserEvent"))


        If myDataViewpermisos.Count = 0 Then
            MsgBox("El usuario no tiene privilegios para Modificar en este Formulario. Contacte a su administrador.")
            Exit Sub
        End If

        If CmbUbicacion.Text = "" Or TxtMalla200.Text = "" Or TxtMallaMenos200.Text = "" Then
            MsgBox("Todos los campos son obligatorios, por favor Diligencie correctamente el formulario")
        Else

            If CDbl(TxtMalla200.Text) + CDbl(TxtMallaMenos200.Text) = 100 Then

            Else
                MsgBox("El porcentaje de granulometría debe ser 100% total")
                Exit Sub
            End If

            Try
                Dim sqlConnectiondb As New System.Data.SqlClient.SqlConnection("Server=mercurio\gcg;uid=sa;pwd=BdZandor123*;database=PlantaBeneficio")
                Dim cmd As New System.Data.SqlClient.SqlCommand
                cmd.CommandType = System.Data.CommandType.Text

                If editargranulometria = True Then
                    'CONSULTA CUANDO EDITAR ES VERDADERO
                    cmd.CommandText = "UPDATE  Pb_Granulometria  SET Fecha = @Fecha , Ubicacion=@Ubicacion , Malla200 = @Malla200 , Mallamenos200 = @Mallamenos200 , HoraInicio=@HoraInicio WHERE Id=@Id  "
                Else
                    ' consulta sql si editar es falso 
                    cmd.CommandText = "INSERT INTO Pb_Granulometria (Fecha , Ubicacion , Malla200 ,  Mallamenos200 , HoraInicio ) VALUES( @Fecha , @Ubicacion, @Malla200,  @Mallamenos200, @HoraInicio)"
                End If
                cmd.Parameters.AddWithValue("@HoraInicio", Convert.ToString(CmbHora.Text))
                ' cmd.Parameters.AddWithValue("@HoraFinal", Convert.ToString(HoraFinal.Text))
                cmd.Parameters.AddWithValue("@Fecha", CDate(dtfecha.Text))
                cmd.Parameters.AddWithValue("@Ubicacion", Convert.ToString(CmbUbicacion.Text))


                If IsNumeric(TxtMalla200.Text) Then
                    cmd.Parameters.AddWithValue("@Malla200", Convert.ToDecimal(TxtMalla200.Text))
                Else
                    cmd.Parameters.AddWithValue("@Malla200", DBNull.Value)
                End If
                If IsNumeric(TxtMalla200.Text) Then
                    cmd.Parameters.AddWithValue("@Mallamenos200", Convert.ToDecimal(TxtMallaMenos200.Text))
                Else
                    cmd.Parameters.AddWithValue("@Mallamenos200", DBNull.Value)
                End If


                If editargranulometria = True Then
                    cmd.Parameters.AddWithValue("@id", Convert.ToInt16(LblIdConsecutivo.Text))
                End If

                cmd.Connection = sqlConnectiondb
                sqlConnectiondb.Open()
                cmd.ExecuteNonQuery()
                sqlConnectiondb.Close()
                MessageBox.Show("Los datos se  guardaron Correctamente.")
                'Llenar_DataGridViewDesarrollo()
                llenardatagridviewgranulometria()
                ' TxtLecturaInicial.Text = TxtLecturaFinal.Text
                TxtMalla200.Clear()
                TxtMallaMenos200.Clear()
                CmbUbicacion.Text = ""

                TxtMalla200.Focus()
                If editargranulometria = True Then
                Else
                    '' If ListB12Final.SelectedIndex + 1 > 23 Then
                    '  ListB12Final.SelectedIndex = 0
                    '   Else
                    '           ListB12Final.SelectedIndex = ListB12Final.SelectedIndex + 1
                    'End If
                End If

                editargranulometria = False
                '    DgLecturaBandas.FirstDisplayedScrollingRowIndex = DgLecturaBandas.RowCount - 1
            Catch ex As Exception

                ' Handle the exception.
                MessageBox.Show(ex.Message, Me.Text, _
      MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        End If
    End Sub
    Private Sub DgGranulometria_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgGranulometrico.CellDoubleClick

        If MsgBox("Esta Seguro Que Desea Eliminar El Registro Seleccionado?", vbYesNo, "") = vbYes Then
            Try
                If DBNull.Value.Equals(DgGranulometrico.CurrentRow.Cells("id").Value) Then
                    TxtMalla200.Clear()
                    TxtMalla200.Clear()
                    CmbUbicacion.Text = ""
                Else
                    Dim sqlConnectiondb As New System.Data.SqlClient.SqlConnection("Server=mercurio\gcg;uid=sa;pwd=BdZandor123*;database=PlantaBeneficio")
                    Dim cmd As New System.Data.SqlClient.SqlCommand
                    cmd.CommandType = System.Data.CommandType.Text
                    cmd.CommandText = "DELETE FROM Pb_Granulometria    WHERE id=  '" & CInt((Me.DgGranulometrico.Rows(e.RowIndex).Cells("id").Value())) & "' "
                    cmd.Connection = sqlConnectiondb
                    sqlConnectiondb.Open()
                    cmd.ExecuteNonQuery()
                    sqlConnectiondb.Close()
                End If
                llenardatagridviewgranulometria()
                TxtMalla200.Clear()
                TxtMalla200.Clear()
                CmbUbicacion.Text = ""
                editargranulometria = False
            Catch ex As Exception
                ' Handle the exception.
                MessageBox.Show(ex.Message, Me.Text, _
      MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Else
            'ACA EL CODIGO SI PULSA NO
        End If
    End Sub

    Private Sub llenardatagridviewgranulometria()   'cargar DataGrid de Preparacion Daily
        Cn.Open()
        Dim ds As New DataSet
        Dim da As New SqlDataAdapter
        Dim sql As String
        sql = " SELECT   HoraInicio, Fecha , Ubicacion , Malla200 , Mallamenos200,  Id  from    Pb_Granulometria  WHERE Fecha =  '" & CDate(dtfecha.Text) & "'    ORDER BY Ubicacion "
        da.SelectCommand = New SqlCommand(sql, Cn)
        da.Fill(ds)
        Cn.Close()
        Dim dt As DataTable = ds.Tables(0)
        DgGranulometrico.DataSource = dt
        DgGranulometrico.AutoResizeColumns()
        Me.DgGranulometrico.Columns("Fecha").Visible = False
        Me.DgGranulometrico.Columns("id").Visible = False
        DgGranulometrico.Columns("Malla200").DefaultCellStyle.Format = "0.00"
        DgGranulometrico.Columns("Mallamenos200").DefaultCellStyle.Format = "0.00"
        DgGranulometrico.Columns("HoraInicio").HeaderText = "Hora Inicio"
        DgGranulometrico.Columns("Malla200").HeaderText = "Malla +200"
        DgGranulometrico.Columns("Mallamenos200").HeaderText = "Malla -200"
        DgGranulometrico.DefaultCellStyle.Font = New Font("Microsoft Sans Serif", 15)
        Me.DgGranulometrico.ReadOnly = False
    End Sub


    Private Sub DgGranulometrico_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgGranulometrico.CellClick
        Try
            'Aquí pongo lo que pasaría si el campo está en blanco o nulo
            If DBNull.Value.Equals(DgGranulometrico.CurrentRow.Cells("id").Value) Then
                Me.TxtMalla200.Clear()
                Me.TxtMallaMenos200.Clear()
                Me.CmbUbicacion.Text = ""
            Else
                Me.CmbHora.Text = CStr(Me.DgGranulometrico.Rows(e.RowIndex).Cells("HoraInicio").Value())
                Me.CmbUbicacion.Text = CStr(Me.DgGranulometrico.Rows(e.RowIndex).Cells("ubicacion").Value())
                If DBNull.Value.Equals(DgGranulometrico.CurrentRow.Cells("Malla200").Value) Then
                    TxtMalla200.Clear()
                Else
                    Me.TxtMalla200.Text = CStr(Me.DgGranulometrico.Rows(e.RowIndex).Cells("Malla200").Value())
                End If
                If DBNull.Value.Equals(DgGranulometrico.CurrentRow.Cells("Mallamenos200").Value) Then
                    TxtMallaMenos200.Clear()
                Else
                    Me.TxtMallaMenos200.Text = CStr(Me.DgGranulometrico.Rows(e.RowIndex).Cells("Mallamenos200").Value())
                End If

                Me.LblIdConsecutivo.Text = CStr(Me.DgGranulometrico.Rows(e.RowIndex).Cells("id").Value())
                editargranulometria = True
            End If
        Catch ex As Exception
            ' Handle the exception.

            MessageBox.Show(ex.Message, Me.Text, _
  MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub



    Private Sub dtfecha_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtfecha.ValueChanged
        llenardatagridviewgranulometria()
        llenardatagridviewgranulometria()
        TxtMalla200.Clear()
        TxtMalla200.Clear()
        CmbUbicacion.Text = ""
    End Sub
End Class