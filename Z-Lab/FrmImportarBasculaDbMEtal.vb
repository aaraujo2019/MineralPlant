
Option Explicit On
'Option Strict Of
Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.Office.Interop
Imports System.Data.OleDb
Imports System.Windows.Forms
Imports System.Configuration

Public Class FrmImportarBasculaDbMEtal
    Dim nombreHoja As String
    Dim conn As New ADODB.Connection()
    Dim rstlab As New ADODB.Recordset()


    Dim rst As New ADODB.Recordset()
    Dim cnStr As String
    Dim Cn As New SqlConnection(ConfigurationManager.ConnectionStrings.Item("StringConexion").ToString())
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
                Cargar(DgBascula, Txtruta.Text, nombreHoja)

            Catch ex As OleDbException
                MessageBox.Show(ex.Message)
            End Try

        End If
        'AVERIGUAR NOMBRE DE HOJA


    End Sub
    Private Function ValidaSiExiste(ByVal ID As String) As Boolean
        Try

            Using cnn As New SqlConnection(ConfigurationManager.ConnectionStrings.Item("StringConexion").ToString())
                Dim sqlbuscar As String = String.Format("SELECT COUNT(*) FROM Pb_Bascula WHERE IdDbMEtal = @IdDbMEtal ")
                Dim cmd As New SqlCommand(sqlbuscar, cnn)
                cmd.Parameters.AddWithValue("@IdDbMEtal", ID)

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

            With DgBascula                ' llena el DataGridView  
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

    Private Sub CmdGuardarTons_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdGuardarTons.Click
        Dim AppExcel As Excel.Application
        Dim LibroExcel As Excel.Workbook
        Dim HojaExcel As Excel.Worksheet
        ' Dim celda As String
        cnStr = "Provider=SQLNCLI10;Initial Catalog=GZC;Data Source=SEGSVRSQL01; User ID=sa;Password=*Bd6r4nC0l0mb1a*;"
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
            Dim PesoIngreso, PesoSalida, Peso As Double
            Dim idhora As Integer
            Dim fecha As Date
            Dim fechaestado1, fechaestado2, ubicacion As String
            Dim IdDbMEtal, NombreProyecto, NombreContenedor, Estado As String

            Dim limite As Integer
            limite = 2000
            'Replace(Convert.ToString(HojaExcel.Range("c" & i).Value), " ", "") = "7a3"
            For i As Integer = 2 To 2000
                'celda = "A" & i
                conn.Open(cnStr)

                IdDbMEtal = CStr(Convert.ToString(HojaExcel.Range("d" & i).Value))
                NombreProyecto = CStr(Convert.ToString(HojaExcel.Range("f" & i).Value))
                NombreContenedor = CStr(Convert.ToString(HojaExcel.Range("c" & i).Value))
                fecha = CDate(Replace(CStr(Convert.ToDateTime(HojaExcel.Range("a" & i).Value)), "/", "-"))
                'fecha = CStr(HojaExcel.Range("a" & i).Value)
                ubicacion = CStr(Convert.ToString(HojaExcel.Range("i" & i).Value))
                fechaestado1 = CStr(Replace((HojaExcel.Range("V" & i).Value), "/", "-"))
                fechaestado2 = CStr(Replace((HojaExcel.Range("U" & i).Value), "/", "-"))
                PesoIngreso = CDbl(HojaExcel.Range("S" & i).Value)
                PesoSalida = CDbl(HojaExcel.Range("R" & i).Value)
                idhora = Hour((HojaExcel.Range("u" & i).Value))
                Peso = CDbl(HojaExcel.Range("T" & i).Value)
                Estado = (CStr(HojaExcel.Range("q" & i).Value))
                If IdDbMEtal = "" Then

                Else
                    If (ValidaSiExiste(IdDbMEtal)) Then
                        cmd.CommandText = "UPDATE  Pb_Bascula  SET NombreProyecto = '" & NombreProyecto & "' , NombreContenedor = '" & NombreContenedor & "' , fecha = '" & fecha & "' , fechaestado1 = '" & fechaestado1 & "' , fechaestado2 = '" & fechaestado2 & "' ,Pesoingreso = '" & PesoIngreso & "' , PesoSalida = '" & PesoSalida & "', Peso = '" & Peso & "'  , IdHora = '" & idhora & "' , ubicacion = '" & ubicacion & "'  WHERE  IdDbMEtal= '" & IdDbMEtal & "'  "
                    Else
                        cmd.CommandText = "INSERT INTO Pb_Bascula(IdDbMEtal ,NombreProyecto,NombreContenedor,fecha,fechaestado1,fechaestado2,PesoSalida,PesoIngreso,Peso , IdHora , Ubicacion)VALUES('" & IdDbMEtal & "','" & NombreProyecto & "','" & NombreContenedor & "' ,'" & fecha & "','" & fechaestado1 & "','" & fechaestado2 & "','" & PesoSalida & "','" & PesoIngreso & "' ,'" & Peso & "' ,'" & idhora & "' ,'" & ubicacion & "'  )"
                    End If

                    cmd.Connection = sqlConnectiondb
                    sqlConnectiondb.Open()
                    cmd.ExecuteNonQuery()
                    sqlConnectiondb.Close()
                    conn.Close()
                End If




                If CStr(HojaExcel.Range("d" & i).Value) = "" Then
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