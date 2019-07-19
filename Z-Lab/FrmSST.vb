Option Explicit On
Option Strict On
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports System.Windows.Forms

Public Class FrmSST
    Private dt As DataTable
    Dim Da As New SqlDataAdapter
    Dim Cmd As New SqlCommand
    Dim Dataset As DataSet
    Dim editarinstantanea As Boolean
    Dim Cn As New SqlConnection(ConfigurationManager.ConnectionStrings.Item("StringConexion").ToString())
    Dim cnStr As String
    Dim editarsst As Boolean

    Private Sub FrmSST_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.LblUsuario.Text = FrmPrincipal.LblUserName.Text
        llenar_datagridviewSST()
        editarsst = False
    End Sub


    Private Sub Dgsst_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dgsst.CellClick
        Try

            If DBNull.Value.Equals(Dgsst.CurrentRow.Cells("fecha").Value) Then
                CmbTurno.Text = ""
                CmbUbicacion.Text = ""

                TxtSST.Clear()

                Lblidsst.Text = "00"
            Else
                DtFecha.Text = CStr(Me.Dgsst.Rows(e.RowIndex).Cells("fecha").Value())

                If IsDBNull((Me.Dgsst.Rows(e.RowIndex).Cells("ubicacion").Value())) Then
                    CmbUbicacion.Text = ""
                Else
                    CmbUbicacion.Text = CStr(Me.Dgsst.Rows(e.RowIndex).Cells("ubicacion").Value())
                End If
            End If

            If IsDBNull((Me.Dgsst.Rows(e.RowIndex).Cells("turno").Value())) Then
                CmbTurno.Text = ""
            Else
                CmbTurno.Text = CStr(Me.Dgsst.Rows(e.RowIndex).Cells("turno").Value())
            End If

            If IsDBNull((Me.Dgsst.Rows(e.RowIndex).Cells("sst").Value())) Then
                TxtSST.Text = ""
            Else
                TxtSST.Text = CStr(Me.Dgsst.Rows(e.RowIndex).Cells("sst").Value())
            End If

            editarsst = True


        Catch ex As Exception
            ' Handle the exception.
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub llenar_datagridviewSST()   'cargar DataGrid de Preparacion Daily
        Cn.Open()
        Dim ds As New DataSet
        Dim da As New SqlDataAdapter
        Dim sql As String
        sql = "SELECT     fecha, ubicacion, sst , turno    FROM PB_sst WHERE    (Fecha = '" & Convert.ToDateTime(DtFecha.Text) & "') ORDER BY turno "
        da.SelectCommand = New SqlCommand(sql, Cn)
        da.Fill(ds)
        Cn.Close()
        Dim dt As DataTable = ds.Tables(0)
        Dgsst.DataSource = dt
        Dgsst.AutoResizeColumns()
        'Me.Dgsst.Columns("id").Visible = False
        Dgsst.Columns("sst").HeaderText = "SST - mg/lt"

        Dgsst.Columns("ubicacion").HeaderText = "Ubicacion"
        Dgsst.Columns("fecha").Visible = False

        Me.Dgsst.ReadOnly = False
    End Sub

    Private Sub DtFecha_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DtFecha.ValueChanged
        llenar_datagridviewSST()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim fechainicio As Date
        Dim fechafin As Date
        fechainicio = Convert.ToDateTime(dtfechainicio.Value)
        fechafin = Convert.ToDateTime(dtfechafinal.Value)
        Dim dias As Double

        dias = (dtfechafinal.Value - dtfechainicio.Value).TotalDays
        If dias > 31 Then
            MsgBox("Por Favor Seleccione un rango de Fecha no superior a 30 dias.")
            Exit Sub
        End If

        ExportarSST()
    End Sub

    Private Sub ExportarSST()
        Cn.Open()
        Dim ds As New DataSet
        Dim da As New SqlDataAdapter
        Dim sql As String

        Dim strFechaInicio As String = System.String.Empty
        If (dtfechainicio.Text = System.String.Empty) Then
            strFechaInicio = DateTime.Now.ToString("yyyy-MM-dd")
        Else
            strFechaInicio = Convert.ToDateTime(dtfechainicio.Text).ToString("yyyy-MM-dd")
        End If

        Dim strFecha As String = System.String.Empty
        If (dtfechafinal.Text = System.String.Empty) Then
            strFecha = DateTime.Now.ToString("yyyy-MM-dd")
        Else
            strFecha = Convert.ToDateTime(dtfechafinal.Text).ToString("yyyy-MM-dd")
        End If

        Dim objExcel As Microsoft.Office.Interop.Excel.Application
        objExcel = New Microsoft.Office.Interop.Excel.Application
        Dim hoja As Microsoft.Office.Interop.Excel.Worksheet
        objExcel.Workbooks.Open("\\athenea\pampaverde\mineria\Data\DataBase\Templates\Reporte_solidosensuspencion.xlsx")
        Dim recorrido As Integer
        recorrido = 2
        objExcel.Visible = False

        sql = "SELECT   Fecha, SST , ubicacion , turno  FROM  dbo.Pb_sst where (Fecha >= '" & strFechaInicio & "') AND (Fecha <= '" & strFecha & "')  ORDER BY Fecha "
        da.SelectCommand = New SqlCommand(sql, Cn)
        da.Fill(ds)
        dt = New DataTable

        dt = ds.Tables(0)

        If dt.Rows.Count > 0 Then
            With objExcel
                recorrido = 2
                hoja = CType(.Sheets("Data"), Microsoft.Office.Interop.Excel.Worksheet)
                For index = 0 To dt.Rows.Count - 1
                    hoja.Cells(recorrido, 1) = dt.Rows(index)(0).ToString
                    hoja.Cells(recorrido, 2) = dt.Rows(index)(3).ToString
                    hoja.Cells(recorrido, 3) = dt.Rows(index)(1).ToString
                    hoja.Cells(recorrido, 4) = dt.Rows(index)(2).ToString
                    recorrido = recorrido + 1
                Next

                recorrido = 3
                hoja = CType(.Sheets("Report"), Microsoft.Office.Interop.Excel.Worksheet)
                Dim fecha1, fecha2 As Date
                fecha1 = dtfechainicio.Value
                fecha2 = dtfechafinal.Value
                Do While fecha1 <= fecha2
                    hoja.Cells(recorrido, 1) = fecha1
                    recorrido = recorrido + 1
                    fecha1 = fecha1.AddDays(1)
                Loop
            End With
            objExcel.Visible = True
            Cn.Close()
        End If
    End Sub

    Private Sub CmdGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdGuardar.Click
        Dim DsPriv As New DataSet
        Dim EPermisos As New SqlClient.SqlDataAdapter("SELECT Usuario, IdEvento FROM RfUserEvent" & " WHERE RfUserEvent.Usuario='" & LblUsuario.Text & "'  and (RfUserEvent.IdEvento  = 'ModificarBanda'  ) ", Cn)
        EPermisos.Fill(DsPriv, "RfUserEvent")
        Dim myDataViewpermisos As DataView = New DataView(DsPriv.Tables("RfUserEvent"))

        If myDataViewpermisos.Count = 0 Then
            MsgBox("El usuario no tiene privilegios para Modificar en este Formulario. Contacte a su administrador.")
            Exit Sub
        End If

        If CmbUbicacion.Text = "" Or CmbTurno.Text = "" Or TxtSST.Text = "" Then
            MsgBox("Todos los campos son obligatorios, por favor Diligencie correctamente el formulario")
        Else
            Try
                Dim sqlConnectiondb As New System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings.Item("StringConexion").ToString())
                Dim cmd As New System.Data.SqlClient.SqlCommand
                cmd.CommandType = System.Data.CommandType.Text

                If editarsst = True Then
                    'CONSULTA CUANDO EDITAR ES VERDADERO
                    cmd.CommandText = "UPDATE  Pb_SST  SET  Fecha=@Fecha,  ubicacion = @ubicacion , turno=@turno , sst=@sst WHERE idsst=@idsst  "
                Else
                    ' consulta sql si editar es falso 
                    cmd.CommandText = "INSERT INTO Pb_SST (Fecha, ubicacion,  turno, sst) VALUES (@Fecha, @ubicacion,  @turno, @sst)"
                End If

                cmd.Parameters.AddWithValue("@Fecha", Convert.ToDateTime(DtFecha.Text))
                cmd.Parameters.AddWithValue("@ubicacion", Convert.ToString(CmbUbicacion.Text))
                cmd.Parameters.AddWithValue("@turno", Convert.ToString(CmbTurno.Text))
                cmd.Parameters.AddWithValue("@sst", Convert.ToDecimal(TxtSST.Text))

                cmd.Parameters.AddWithValue("@idsst", Convert.ToInt32(Lblidsst.Text))

                cmd.Connection = sqlConnectiondb
                sqlConnectiondb.Open()
                cmd.ExecuteNonQuery()
                sqlConnectiondb.Close()
                MessageBox.Show("Los datos se  guardaron Correctamente.")
                'Llenar_DataGridViewDesarrollo()
                llenar_datagridviewSST()
                TxtSST.Clear()
                TxtSST.Focus()
                editarsst = False

            Catch ex As Exception
                ' Handle the exception.
                MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub
End Class