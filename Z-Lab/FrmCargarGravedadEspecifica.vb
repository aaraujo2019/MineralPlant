Option Explicit On
Option Strict On
Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.Office.Interop
Imports System.Data.OleDb
Imports System.Windows.Forms
Public Class FrmCargarGravedadEspecifica
    Dim nombreHoja As String
    Dim conn As New ADODB.Connection()
    Dim rstlab As New ADODB.Recordset()
    Dim rst As New ADODB.Recordset()
    Dim cnStr As String
    Dim Cn As New SqlConnection("Server=SEGSVRSQL01;uid=sa;pwd=*Bd6r4nC0l0mb1a*;database=PlantaBeneficio")
    Private Sub CmdExaminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdExaminar.Click
        Dim openFD As New OpenFileDialog()
        With openFD
            .Title = "Seleccionar archivos"
            .Filter = "Todos los archivos (*.xlsx)|*.xlsx"
            .Multiselect = False
            .InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments

            If .ShowDialog = Windows.Forms.DialogResult.OK Then


                Txtruta.Text = .FileName
            End If
        End With
        If Txtruta.Text = "" Then

        Else
            Try
                Dim nombreHoja As String = ObtenerNombrePrimeraHoja(Txtruta.Text)
                ' MessageBox.Show(nombreHoja)
                Cargar(DgGravedad, Txtruta.Text, nombreHoja)

            Catch ex As OleDbException
                MessageBox.Show(ex.Message)
            End Try

        End If
        'AVERIGUAR NOMBRE DE HOJA


    End Sub

    Private Function ObtenerNombrePrimeraHoja(ByVal rutaLibro As String) As String
        Dim app As Excel.Application = Nothing


        Try
            app = New Excel.Application()
            Dim wb As Excel.Workbook = app.Workbooks.Open(rutaLibro)
            Dim ws As Excel.Worksheet = CType(wb.Worksheets.Item(1), Excel.Worksheet)
            Dim name As String = ws.Name
            'ws = Nothing
            'wb.Close()
            'wb = Nothing
            Return name
        Catch ex As Exception
            Throw

        Finally
            ' If (Not app Is Nothing) Then _
            'app.Quit()
            ' Runtime.InteropServices.Marshal.ReleaseComObject(app)
            ' app = Nothing
        End Try
    End Function







    Sub Cargar( _
       ByVal dgView As DataGridView, _
       ByVal SLibro As String, _
       ByVal sHoja As String)

        'HDR=YES : Con encabezado  
        Dim cs As String = "Provider=Microsoft.Jet.OLEDB.15.0;" & _
                           "Data Source=" & SLibro & ";" & _
                           "Extended Properties=""Excel 8.0;HDR=YES"""
        Try
            ' cadena de conexión  
            Dim cn As New OleDbConnection(cs)

            If Not System.IO.File.Exists(SLibro) Then
                MsgBox("No se encontró el Libro: " & _
                        SLibro, MsgBoxStyle.Critical, _
                        "Ruta inválida")
                Exit Sub
            End If

            ' se conecta con la hoja sheet 1  
            Dim dAdapter As New OleDbDataAdapter("Select * From [" & sHoja & "$]", cs)

            Dim datos As New DataSet

            ' agrega los datos  
            dAdapter.Fill(datos)

            With DgGravedad
                ' llena el DataGridView  
                .DataSource = datos.Tables(0)

                ' DefaultCellStyle: formato currency   
                'para los encabezados 1,2 y 3 del DataGrid  
                ' .Columns(1).DefaultCellStyle.Format = "c"
                ' .Columns(2).DefaultCellStyle.Format = "c"
                '.Columns(3).DefaultCellStyle.Format = "c"
            End With
        Catch oMsg As Exception
            ' MsgBox(oMsg.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Function ValidaSiExiste(ByVal ID As String, ByVal ubicacion As String, ByVal turno As String) As Boolean
        Try

            Using cnn As New SqlConnection("Server=SEGSVRSQL01;uid=sa;pwd=*Bd6r4nC0l0mb1a*;database=PlantaBeneficio")
                Dim sqlbuscar As String = String.Format("SELECT COUNT(*) FROM PB_GravedadEspecifica WHERE IdLab = @IdLab and Ubicacion = @ubicacion and turno = @turno  ")
                Dim cmd As New SqlCommand(sqlbuscar, cnn)
                cmd.Parameters.AddWithValue("@IdLab", ID)
                cmd.Parameters.AddWithValue("@Ubicacion", Ubicacion)
                cmd.Parameters.AddWithValue("@turno", turno)
                cnn.Open()
                Dim Count As Integer = CInt(cmd.ExecuteScalar())
                cnn.Close()
                If Count > 0 Then
                    Return True
                Else
                    Return False
                End If
            End Using
        Catch ex As Exception
            Throw
        End Try
    End Function


    Private Sub CmdGuardarJobno_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdGuardarJobno.Click
        Dim AppExcel As Excel.Application
        Dim LibroExcel As Excel.Workbook
        Dim HojaExcel As Excel.Worksheet
        Dim celda As String
        cnStr = "Provider=SQLNCLI10;Initial Catalog=GZC;Data Source=SEGSVRSQL01; User ID=sa;Password=*Bd6r4nC0l0mb1a*;"
        Try

            Dim FicheroExcel As String
            Dim NombreHoja As String
            'variables de insercion
            Dim sqlConnectiondb As New System.Data.SqlClient.SqlConnection("Server=SEGSVRSQL01;uid=sa;pwd=*Bd6r4nC0l0mb1a*;database=PlantaBeneficio")
            Dim cmd As New System.Data.SqlClient.SqlCommand
            cmd.CommandType = System.Data.CommandType.Text
            FicheroExcel = Txtruta.Text
            NombreHoja = ObtenerNombrePrimeraHoja(Txtruta.Text)
            AppExcel = New Excel.Application
            LibroExcel = AppExcel.Workbooks.Open(FicheroExcel)
            HojaExcel = CType(LibroExcel.Sheets(NombreHoja), Excel.Worksheet)

            'procedimento para solucion.
            Dim idlab As String
            Dim ubicacion, turno, horainicio, horafinal As String
            turno = "00"
            horainicio = "00:00"
            horafinal = "00:00"
            Dim fecha As Date
            fecha = CDate(DtFecha.Text)
            idlab = (Convert.ToString(HojaExcel.Range("d3").Value))


            For i As Integer = 11 To 25
                celda = "A" & i
                conn.Open(cnStr)
                Dim gravedad As String

                If CStr(HojaExcel.Range("b" & i).Value) = "Alimentación AG1" Then
                    ubicacion = "Alimento Agitador 1"
                ElseIf CStr(HojaExcel.Range("b" & i).Value) = "Espesador E-5" Then
                    ubicacion = "Espesador 5"
                Else
                    ubicacion = CStr(HojaExcel.Range("b" & i).Value)
                End If



                gravedad = CStr(Convert.ToDouble(HojaExcel.Range("d" & i).Value))
                If Replace(Convert.ToString(HojaExcel.Range("c" & i).Value), " ", "") = "7a3" Then
                    turno = "Turno1"
                    horainicio = "07:00 a.m."
                    horafinal = "03:00 p.m."
                ElseIf Replace(Convert.ToString(HojaExcel.Range("c" & i).Value), " ", "") = "3a11" Then
                    turno = "Turno2"
                    horainicio = "03:00 p.m."
                    horafinal = "11:00 p.m."

                ElseIf Replace(Convert.ToString(HojaExcel.Range("c" & i).Value), " ", "") = "11a7" Then
                    turno = "Turno3"
                    horainicio = "11:00 p.m."
                    horafinal = "07:00 a.m."
                End If
                'turno = Replace(Convert.ToString(HojaExcel.Range("c" & i).Value), " ", "")
                gravedad = CStr(HojaExcel.Range("d" & i).Value)

                If ubicacion = "" Then

                Else
                    If (ValidaSiExiste(idlab, ubicacion, turno)) Then
                        cmd.CommandText = "UPDATE  PB_GravedadEspecifica  SET GravedadEspecifica = '" & gravedad & "' WHERE IdLab= '" & idlab & "'  and turno= '" & turno & "'  and Ubicacion= '" & ubicacion & "'  "
                    Else
                        cmd.CommandText = "INSERT INTO PB_GravedadEspecifica (fecha , IdLab ,GravedadEspecifica , Ubicacion , HoraInicio , HoraFinal , Turno ) VALUES (  '" & fecha & "',  '" & idlab & "'  ,  '" & gravedad & "' ,'" & ubicacion & "' ,'" & horainicio & "' ,'" & horafinal & "' ,'" & turno & "' )"
                    End If

                    cmd.Connection = sqlConnectiondb
                    sqlConnectiondb.Open()
                    cmd.ExecuteNonQuery()
                    sqlConnectiondb.Close()
                    conn.Close()
                End If

                If CStr(HojaExcel.Range("b" & i).Value) = "" Then
                    sqlConnectiondb.Close()
                    conn.Close()
                    MsgBox("Importacion Finalizada")
                    Exit For
                    'Exit Sub
                End If

            Next
            'LibroExcel.Close()
            'AppExcel.Quit()
            'AppExcel = Nothing
            'LibroExcel = Nothing



        Catch ex As Exception
            ' Handle the exception.
            MessageBox.Show(ex.Message, Me.Text, _
  MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If conn.State <> ConnectionState.Closed Then
                conn.Close()
            End If
        End Try
    End Sub
End Class