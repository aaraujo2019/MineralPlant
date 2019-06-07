Option Explicit On
Option Strict On
Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.Office.Interop
Imports System.Data.OleDb
Imports System.Windows.Forms
Public Class FrmCargarHumedad
    Dim nombreHoja As String
    Dim conn As New ADODB.Connection()
    Dim rstlab As New ADODB.Recordset()


    Dim rst As New ADODB.Recordset()
    Dim cnStr As String
    Dim Cn As New SqlConnection("Server=mercurio\gcg;uid=sa;pwd=BdZandor123*;database=PlantaBeneficio")



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







    Sub Cargar( _
       ByVal dgView As DataGridView, _
       ByVal SLibro As String, _
       ByVal sHoja As String)

        'HDR=YES : Con encabezado  
        Dim cs As String = "Provider=Microsoft.Jet.OLEDB.4.0;" & _
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




    Private Sub FrmCargarHumedad_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
    Private Function ValidaSiExiste(ByVal ID As String, ByVal Muestra As String) As Boolean
        Try

            Using cnn As New SqlConnection("Server=mercurio\gcg;uid=sa;pwd=BdZandor123*;database=PlantaBeneficio")
                Dim sqlbuscar As String = String.Format("SELECT COUNT(*) FROM PB_HumedadBanda WHERE IdLab = @IdLab and Muestra = @Muestra")
                Dim cmd As New SqlCommand(sqlbuscar, cnn)
                cmd.Parameters.AddWithValue("@IdLab", ID)
                cmd.Parameters.AddWithValue("@Muestra", Muestra)
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
        cnStr = "Provider=SQLNCLI10;Initial Catalog=GZC;Data Source=mercurio; User ID=sa;Password=BdZandor123*;"
        Try

            Dim FicheroExcel As String
            Dim NombreHoja As String
            'variables de insercion
            Dim sqlConnectiondb As New System.Data.SqlClient.SqlConnection("Server=mercurio\gcg;uid=sa;pwd=BdZandor123*;database=PlantaBeneficio")
            Dim cmd As New System.Data.SqlClient.SqlCommand
            cmd.CommandType = System.Data.CommandType.Text
            FicheroExcel = Txtruta.Text
            NombreHoja = ObtenerNombrePrimeraHoja(Txtruta.Text)
            AppExcel = New Excel.Application
            LibroExcel = AppExcel.Workbooks.Open(FicheroExcel)
            HojaExcel = CType(LibroExcel.Sheets(NombreHoja), Excel.Worksheet)

            'procedimento para solucion.

            Dim limite As Integer
            limite = 200

            For i As Integer = 46 To 200
                celda = "A" & i
                conn.Open(cnStr)
                Dim humedad As Double
                Dim samples, idlab As String
                samples = Replace(Convert.ToString(HojaExcel.Range("A" & i).Value), " ", "")
                humedad = CDbl(HojaExcel.Range("d" & i).Value)
                idlab = Convert.ToString((HojaExcel.Range("B11").Value))
                If samples = "" Then

                Else
                    If (ValidaSiExiste(idlab, samples)) Then
                        cmd.CommandText = "UPDATE  PB_HumedadBanda  SET humedad = '" & humedad & "' WHERE IdLab= '" & idlab & "'  and Muestra= '" & samples & "'  "
                    Else
                        cmd.CommandText = "INSERT INTO PB_HumedadBanda (Muestra,Humedad,IdLab)VALUES('" & samples & "','" & humedad & "','" & idlab & "')"
                    End If

                    cmd.Connection = sqlConnectiondb
                    sqlConnectiondb.Open()
                    cmd.ExecuteNonQuery()
                    sqlConnectiondb.Close()
                    conn.Close()
                End If




                If CStr(HojaExcel.Range("A" & i).Value) = "" Then
                    sqlConnectiondb.Close()
                    conn.Close()
                    MsgBox("Importacion Finalizada")
                    Exit For

                End If

            Next
            'LibroExcel.Close()
            ' AppExcel.Quit()
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