Option Explicit On
Option Strict On
Imports System.Data.OleDb
Imports Microsoft.Office.Interop
Imports System.Windows.Forms

Imports System.Data.SqlClient
Imports System.Configuration

Public Class FrmCargarInstantaneas
    ' _______________________________

    Dim nombreHoja As String
    Dim Cn As New SqlConnection(ConfigurationManager.ConnectionStrings.Item("StringConexion").ToString())
    Dim cnStr As String
    ' Dim Cn As New MySqlConnection("Server=versionline.com;uid=versionl_jpalaci;pwd=colombia12**;database=versionl_planta")
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
                'Dim nombreHoja As String = ObtenerNombrePrimeraHoja(Txtruta.Text)
                ' MessageBox.Show(nombreHoja)
                ' Cargar(DGInstantaneas, Txtruta.Text, nombreHoja)

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
            ws = Nothing
            wb.Close()
            wb = Nothing
            Return name
        Catch ex As Exception
            Throw

        Finally
            If (Not app Is Nothing) Then _
                app.Quit()
            Runtime.InteropServices.Marshal.ReleaseComObject(app)
            app = Nothing
        End Try
    End Function



    Sub Cargar(
       ByVal dgView As DataGridView,
       ByVal SLibro As String,
       ByVal sHoja As String)

        'HDR=YES : Con encabezado  
        Dim cs As String = "Provider=Microsoft.ACE.OLEDB.15.0;" &
                           "Data Source=" & SLibro & ";" &
                           "Extended Properties=""Excel 12.0;HDR=YES"""
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

            With DGInstantaneas
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
            NombreHoja = "Hoja1"
            'NombreHoja = ObtenerNombrePrimeraHoja(Txtruta.Text)
            AppExcel = New Excel.Application
            LibroExcel = AppExcel.Workbooks.Open(FicheroExcel)
            HojaExcel = CType(LibroExcel.Sheets(NombreHoja), Excel.Worksheet)


            Dim limite As Integer
            limite = 100
            Dim fecha, hora As Date
            Dim Ordentrabajo, ubicacion, TipoMuestra As String
            TipoMuestra = "Solución"
            Ordentrabajo = Replace(Convert.ToString(HojaExcel.Range("C3").Value), " ", "")
            fecha = CDate(Convert.ToString((HojaExcel.Range("A10").Value)))
            '  Dim dou_hora As Double = 0.22916666666667
            hora = Date.FromOADate(CDbl(HojaExcel.Range("B10").Value))
            Dim HoraAux, hora2 As String

            ' MsgBox(hora.TimeOfDay.ToString)


            ' hora = String.Format("{0:HH:mm:ss}", (HojaExcel.Range("B10").Value))

            ' MsgBox(hora)

            ' hora = CStr(HojaExcel.Range("B10").Value)
            For i As Integer = 10 To 100


                celda = "A" & i

                Dim tenor As Double
                'tenor = CDbl(HojaExcel.Range("d" & i).Value)
                'hora = Replace(Convert.ToString(HojaExcel.Range("B" & i).Value), "", hora)




                If CStr(HojaExcel.Range("B" & i).Value) = "" Then
                    HoraAux = FormatDateTime(hora, DateFormat.ShortTime)
                    hora2 = (String.Format(HoraAux, "HH:mm:ss"))
                Else
                    hora = Date.FromOADate(CDbl(HojaExcel.Range("B" & i).Value))
                    'MsgBox((String.Format(CStr(hora), "HH:mm:ss")))
                    HoraAux = FormatDateTime(hora, DateFormat.ShortTime)
                    hora2 = (String.Format(HoraAux, "HH:mm:ss"))
                End If
                'Dim msg As String
                'msg = Replace(Convert.ToString(HojaExcel.Range("d" & i).Value), "<0.01", "0.01")
                'MsgBox(msg)
                If CStr(HojaExcel.Range("d" & i).Value) = "'<0.01" Or CStr(HojaExcel.Range("d" & i).Value) = "<0.01" Then
                    tenor = 0.01
                ElseIf IsNumeric(Replace(Convert.ToString(HojaExcel.Range("d" & i).Value), "<0.01", "0.01")) Then
                    tenor = CDbl(Replace(Convert.ToString(HojaExcel.Range("d" & i).Value), "<0.01", "0.01"))
                Else
                    tenor = 0

                End If

                If Replace(Convert.ToString(HojaExcel.Range("C" & i).Value), " ", "") = "CM" Then
                    ubicacion = "Cabeza Merril Crowe"
                ElseIf Replace(Convert.ToString(HojaExcel.Range("C" & i).Value), " ", "") = "CMC" Then
                    ubicacion = "Cola Merril Crowe"

                ElseIf Replace(Convert.ToString(HojaExcel.Range("C" & i).Value), " ", "") = "CAG1" Then
                    ubicacion = "Cabeza Agitador 1"

                ElseIf Replace(Convert.ToString(HojaExcel.Range("C" & i).Value), " ", "") = "DAG1" Then
                    ubicacion = "Descarga Agitador 1"

                ElseIf Replace(Convert.ToString(HojaExcel.Range("C" & i).Value), " ", "") = "DAG2" Then
                    ubicacion = "Descarga Agitador 2"
                ElseIf Replace(Convert.ToString(HojaExcel.Range("C" & i).Value), " ", "") = "DAG3" Then
                    ubicacion = "Descarga Agitador 3"

                ElseIf Replace(Convert.ToString(HojaExcel.Range("C" & i).Value), " ", "") = "E-5(descarga)" Then
                    ubicacion = "Descarga Espesador 5"
                Else


                    ubicacion = CStr(HojaExcel.Range("C" & i).Value)

                End If
                'si hay un valor diferente a numerico, entonces se toma como 0
                If IsNumeric(tenor) Then
                Else
                    tenor = 0
                End If
                If CStr(HojaExcel.Range("d" & i).Value) = "" Or IsDBNull(HojaExcel.Range("d" & i).Value) Or IsNothing((HojaExcel.Range("d" & i).Value)) Or tenor <= 0 Then


                Else

                    If (ValidaSiExiste(fecha, hora2, ubicacion)) Then
                        cmd.CommandText = "UPDATE  PB_Instantaneas  SET tenor = '" & tenor & "' WHERE fecha= '" & fecha & "'  and hora= '" & hora2 & "' and hora= '" & ubicacion & "'  "
                    Else
                        cmd.CommandText = "INSERT INTO PB_Instantaneas (Ordentrabajo,hora,ubicacion,tenor,fecha,TipoMuestra)VALUES('" & Ordentrabajo & "','" & hora2 & "','" & ubicacion & "' , '" & tenor & "' , '" & fecha & "' , '" & TipoMuestra & "' )"

                    End If
                    cmd.Connection = sqlConnectiondb
                    sqlConnectiondb.Open()
                    cmd.ExecuteNonQuery()
                    sqlConnectiondb.Close()

                    If CStr(HojaExcel.Range("D" & i).Value) = "" Then
                        MsgBox("Importacion Finalizada")
                        Exit For

                    End If
                End If

            Next
            '--------- 


            LibroExcel.Close()
            LibroExcel.Close(SaveChanges:=False)
            HojaExcel = Nothing

            AppExcel.Quit()
            AppExcel = Nothing
            LibroExcel = Nothing
            MsgBox("Importacion Finalizada")
        Catch ex As Exception
            ' MsgBox(celda)
            ' Handle the exception.
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub FrmCargarInstantaneas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


    End Sub


    Private Function ValidaSiExiste(ByVal fecha_v As Date, ByVal hora2_v As String, ByVal ubicacion_v As String) As Boolean
        Try
            Using cnn As New SqlConnection(ConfigurationManager.ConnectionStrings.Item("StringConexion").ToString())
                Dim sqlbuscar As String = String.Format("SELECT COUNT(*) FROM PB_Instantaneas WHERE fecha = @fecha and ubicacion = @ubicacion and hora = @hora")
                Dim cmd As New SqlCommand(sqlbuscar, cnn)
                cmd.Parameters.AddWithValue("@fecha", fecha_v)
                cmd.Parameters.AddWithValue("@ubicacion", ubicacion_v)
                cmd.Parameters.AddWithValue("@hora", hora2_v)
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






    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try
            ' lista todos los archivos dll del directorio windows _  
            ' SearchAllSubDirectories : incluye los Subdirectorios  
            ' SearchTopLevelOnly : para buscar solo en el nivel actual  
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''  
            For Each Archivo As String In My.Computer.FileSystem.GetFiles( _
                                    "c:\instantaneas", _
                                    FileIO.SearchOption.SearchAllSubDirectories, _
                                    "*.xlsx")
                MsgBox(Archivo)
                My.Computer.FileSystem.DeleteFile(Archivo)
                'ListBox1.Items.Add(Archivo)
            Next
            ' errores  
        Catch oe As Exception
            MsgBox(oe.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
End Class