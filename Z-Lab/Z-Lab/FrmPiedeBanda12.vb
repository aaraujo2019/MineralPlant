Option Explicit On
Option Strict On
Imports System.Data
Imports System.Data.SqlClient
Imports Z_Lab.Login
Imports System.Data.OleDb
Imports System.Windows.Forms
Imports Z_Lab.FrmPrincipal

Public Class FrmPiedeBanda12
    Private dt As DataTable
    Dim Da As New SqlDataAdapter
    Dim Cmd As New SqlCommand
    Dim Dataset As DataSet
    Dim Cn As New SqlConnection("Server=mercurio\gcg;uid=sa;pwd=BdZandor123*;database=PlantaBeneficio")
    Dim editarpiedebanda As Boolean
    Dim conn As New ADODB.Connection()
    Dim rstoperacion As New ADODB.Recordset()
    Dim cnStr As String
    Private Sub FrmPiedeBanda12_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CargarlistHoraInicio()
        LenardatagridviewPiedeBanda()
        Llenar_TotalPiedeBanda12()
    End Sub

    Private Sub CargarlistHoraInicio()
        With Cmd
            .CommandType = CommandType.Text
            .CommandText = "SELECT        Id, Hora, Militar, Tipo FROM            RfTime  ORDER BY Idplanta"
            .Connection = Cn
        End With
        Da.SelectCommand = Cmd

        dt = New DataTable
        Da.Fill(dt)

        With Cmbhora
            .DataSource = dt
            .DisplayMember = "Hora"
            .ValueMember = "Id"
        End With



    End Sub


    Private Sub LenardatagridviewPiedeBanda()
        'cargar DataGrid de Preparacion Daily
        Cn.Open()
        Dim ds As New DataSet
        Dim da As New SqlDataAdapter
        Dim sql As String
        sql = "SELECT     Fecha, HoraInicial, Lectura, TonsHora , id  FROM         PB_PieDeBanda12   WHERE        Fecha=  '" & CDate(DtFecha.Text) & "' ORDER BY ID "
        da.SelectCommand = New SqlCommand(sql, Cn)
        da.Fill(ds)
        Cn.Close()
        Dim dt As DataTable = ds.Tables(0)
        DgPiedeBanda.DataSource = dt
        DgPiedeBanda.AutoResizeColumns()
        DgPiedeBanda.Columns("TonsHora").DefaultCellStyle.Format = "0.00"
        DgPiedeBanda.Columns("fecha").Visible = False
        DgPiedeBanda.Columns("id").Visible = False
        DgPiedeBanda.Columns("HoraInicial").HeaderText = "Hora Lectura"
        DgPiedeBanda.Columns("TonsHora").HeaderText = "Toneladas Procesadas"
        Me.DgPiedeBanda.ReadOnly = False
    End Sub


    Private Sub DtFecha_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DtFecha.ValueChanged
        LenardatagridviewPiedeBanda()
        Llenar_TotalPiedeBanda12()
    End Sub

    Private Sub CmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdSave.Click
        'Dim DsPriv As New DataSet
        '   Dim EPermisos As New SqlClient.SqlDataAdapter("SELECT Usuario, IdEvento FROM RfUserEvent" & _
        '" WHERE RfUserEvent.Usuario='" & LblUsuario.Text & "'  and (RfUserEvent.IdEvento  = 'Modificarfundicion'  ) ", Cn)
        ' EPermisos.Fill(DsPriv, "RfUserEvent")
        ' Dim myDataViewpermisos As DataView = New DataView(DsPriv.Tables("RfUserEvent"))

        ' If myDataViewpermisos.Count = 0 Then
        'MsgBox("El usuario no tiene privilegios para Modificar en este Formulario. Contacte a su administrador.")
        'Exit Sub
        ' End If
        If TxtLecturaPeso.Text = "" Then
            MsgBox("Por favor Diligencie correctamente el formulario")
        Else
            Try
                Dim sqlConnectiondb As New System.Data.SqlClient.SqlConnection("Server=mercurio\gcg;uid=sa;pwd=BdZandor123*;database=PlantaBeneficio")
                Dim cmd As New System.Data.SqlClient.SqlCommand
                cmd.CommandType = System.Data.CommandType.Text

                If editarpiedebanda = True Then
                    'CONSULTA CUANDO EDITAR ES VERDADERO
                    cmd.CommandText = "UPDATE  PB_PieDeBanda12  SET Fecha = @Fecha,  HoraInicial= @HoraInicial , Lectura=@Lectura WHERE ID=@ID  "
                    cmd.Parameters.AddWithValue("@ID", Convert.ToInt32(LblId.Text))
                Else
                    ' consulta sql si editar es falso 
                    cmd.CommandText = "INSERT INTO PB_PieDeBanda12 (Fecha,HoraInicial,Lectura)VALUES(@Fecha,@HoraInicial,@Lectura)"
                End If
                cmd.Parameters.AddWithValue("@Fecha", CDate(DtFecha.Text))
                cmd.Parameters.AddWithValue("@HoraInicial", Convert.ToString(Cmbhora.Text))
                If IsDBNull(TxtLecturaPeso.Text) Then
                    cmd.Parameters.AddWithValue("@Lectura", 0.0)
                Else
                    cmd.Parameters.AddWithValue("@Lectura", Convert.ToDecimal(TxtLecturaPeso.Text))
                End If
                cmd.Connection = sqlConnectiondb
                sqlConnectiondb.Open()
                cmd.ExecuteNonQuery()
                sqlConnectiondb.Close()
                MessageBox.Show("Los datos se  guardaron Correctamente.")
                LenardatagridviewPiedeBanda()
                TxtLecturaPeso.Clear()
                TxtLecturaPeso.Focus()
                editarpiedebanda = False
                'DgLecturaBandas.FirstDisplayedScrollingRowIndex = DgLecturaBandas.RowCount - 1
            Catch ex As Exception
                ' Handle the exception.
                MessageBox.Show(ex.Message, Me.Text, _
      MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        End If
    End Sub

    Private Sub DgPiedeBanda12_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgPiedeBanda.CellClick
        Try
            'Aquí pongo lo que pasaría si el campo está en blanco o nulo
            If DBNull.Value.Equals(DgPiedeBanda.CurrentRow.Cells("Lectura").Value) Then
                Me.TxtLecturaPeso.Clear()
            Else
                LblId.Text = CStr(Me.DgPiedeBanda.Rows(e.RowIndex).Cells("ID").Value())
                TxtLecturaPeso.Text = CStr(Me.DgPiedeBanda.Rows(e.RowIndex).Cells("Lectura").Value())
                Cmbhora.Text = CStr(Me.DgPiedeBanda.Rows(e.RowIndex).Cells("HoraInicial").Value())
                TxtLecturaPeso.Text = CStr(Me.DgPiedeBanda.Rows(e.RowIndex).Cells("Lectura").Value())
                editarpiedebanda = True
            End If
        Catch ex As Exception
            ' Handle the exception.
            MessageBox.Show(ex.Message, Me.Text, _
  MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub






    Private Sub Llenar_TotalPiedeBanda12()
        Dim registros As Decimal
        Dim pesototal As Decimal
      
        pesototal = 0
        registros = 0

        For Each dRow As DataGridViewRow In DgPiedeBanda.Rows
            If (dRow.Cells.Item("HoraInicial").Value) IsNot Nothing Then

                If IsDBNull(dRow.Cells.Item("TonsHora").Value) Then
                Else
                    pesototal = CDec(dRow.Cells.Item("TonsHora").Value) + pesototal
                End If


            End If
            registros = registros + 1
        Next dRow
        If registros = 0 Then
            LbltotalToneladas.Text = "0"
            LblTonsHora.Text = "0"
            LblHorasOperacion.Text = "0"
        Else
            LblTonsHora.Text = CStr(Format(pesototal / registros, "0.00"))
            LbltotalToneladas.Text = CStr(Format(pesototal, "0.00"))
            LblHorasOperacion.Text = CStr(Format(registros, "0.00"))
        End If

        Me.DgPiedeBanda.ReadOnly = False
    End Sub







    Private Sub GroupBoxForm_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBoxForm.Enter

    End Sub
End Class