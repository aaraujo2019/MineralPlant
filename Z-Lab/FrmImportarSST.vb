Option Explicit On
Option Strict On
Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.Office.Interop
Imports System.Data.OleDb
Imports System.Windows.Forms
Imports System.Configuration

Public Class FrmImportarSST
    Dim nombreHoja As String
    Dim Cn As New SqlConnection(ConfigurationManager.ConnectionStrings.Item("StringConexion").ToString())
    Private Sub FrmImportarSST_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub CmdExaminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdExaminar.Click


        Dim openFD As New OpenFileDialog()
        With openFD
            .Title = "Seleccionar archivos"
            .Filter = "Todos los archivos (*.xls)|*.xls"
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
                Cargar(DgOrdenLab, Txtruta.Text, nombreHoja)

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
            ' wb.Close()
            ' wb = Nothing
            Return name
        Catch ex As Exception
            Throw

        Finally
            ' If (Not app Is Nothing) Then _
            '     app.Quit()
            ' Runtime.InteropServices.Marshal.ReleaseComObject(app)
            '  app = Nothing
        End Try
    End Function







    Sub Cargar(
       ByVal dgView As DataGridView,
       ByVal SLibro As String,
       ByVal sHoja As String)

        'HDR=YES : Con encabezado  
        Dim cs As String = "Provider=Microsoft.Jet.OLEDB.4.0;" &
                           "Data Source=" & SLibro & ";" &
                           "Extended Properties=""Excel 8.0;HDR=YES"""
        Try
            ' cadena de conexión  
            Dim cn As New OleDbConnection(cs)

            If Not System.IO.File.Exists(SLibro) Then
                MsgBox("No se encontró el Libro: " &
                        SLibro, MsgBoxStyle.Critical,
                        "Ruta inválida")
                Exit Sub
            End If

            ' se conecta con la hoja sheet 1  
            Dim dAdapter As New OleDbDataAdapter("Select * From [" & sHoja & "$]", cs)

            Dim datos As New DataSet

            ' agrega los datos  
            dAdapter.Fill(datos)

            With DgOrdenLab
                ' llena el DataGridView  
                .DataSource = datos.Tables(0)

                ' DefaultCellStyle: formato currency   
                'para los encabezados 1,2 y 3 del DataGrid  
                ' .Columns(1).DefaultCellStyle.Format = "c"
                ' .Columns(2).DefaultCellStyle.Format = "c"
                '.Columns(3).DefaultCellStyle.Format = "c"
            End With
        Catch oMsg As Exception
            MsgBox(oMsg.Message, MsgBoxStyle.Critical)
        End Try
    End Sub


    Private Function ValidaSiExiste(ByVal fecha As Date, ByVal turno As String) As Boolean
        Try

            Using cnn As New SqlConnection(ConfigurationManager.ConnectionStrings.Item("StringConexion").ToString())
                Dim sqlbuscar As String = String.Format("SELECT COUNT(*) FROM PB_SST WHERE fecha = @fecha and turno = @turno")
                Dim cmd As New SqlCommand(sqlbuscar, cnn)
                cmd.Parameters.AddWithValue("@fecha", fecha)
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

        Try

            Dim FicheroExcel As String
            Dim NombreHoja As String
            'variables de insercion
            Dim sqlConnectiondb As New System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings.Item("StringConexion").ToString())
            Dim cmd As New System.Data.SqlClient.SqlCommand
            cmd.CommandType = System.Data.CommandType.Text
            FicheroExcel = Txtruta.Text
            NombreHoja = ObtenerNombrePrimeraHoja(Txtruta.Text)
            AppExcel = New Excel.Application
            LibroExcel = AppExcel.Workbooks.Open(FicheroExcel)
            HojaExcel = CType(LibroExcel.Sheets(NombreHoja), Excel.Worksheet)

            'procedimento para solucion.

            Dim limite As Integer
            limite = 100

            For i As Integer = 38 To 100
                celda = "A" & i

                Dim SST As Double
                Dim ubicacion, idlab, turno As String
                Dim fecha As Date
                turno = "N/A"
                ubicacion = Replace(Convert.ToString(HojaExcel.Range("A" & i).Value), " ", "")
                SST = CDbl(HojaExcel.Range("b" & i).Value)



                idlab = Convert.ToString((HojaExcel.Range("B10").Value))
                fecha = CDate(HojaExcel.Range("b14").Value)
                If ubicacion = "DescargaE-4Turno7-3" Then
                    turno = "Turno1"
                ElseIf ubicacion = "DescargaE-4Turno3-11" Then
                    turno = "Turno2"
                ElseIf ubicacion = "DescargaE-4Turno11-7" Then
                    turno = "Turno3"
                End If
                If ubicacion = "" Then

                Else
                    If (ValidaSiExiste(fecha, turno)) Then
                        cmd.CommandText = "UPDATE  PB_SST SET  ubicacion = '" & ubicacion & "' , SET  sst = '" & SST & "'  WHERE fecha= '" & CDate(fecha) & "'  and turno= '" & turno & "'  "
                    Else
                        cmd.CommandText = "INSERT INTO PB_sst (ubicacion,sst,IdLab , turno , fecha)VALUES('" & ubicacion & "','" & SST & "','" & idlab & "','" & turno & "','" & fecha & "')"
                    End If

                    cmd.Connection = sqlConnectiondb
                    sqlConnectiondb.Open()
                    cmd.ExecuteNonQuery()
                    sqlConnectiondb.Close()

                End If

            Next
        Catch ex As Exception
            ' Handle the exception.
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Sub
End Class