﻿Option Explicit On
Option Strict On
Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.Office.Interop
Imports System.Data.OleDb
Imports System.Windows.Forms
Imports System.Configuration

Public Class FrmImportarMinerasDbMetal
    Dim nombreHoja As String
    Dim Cn As New SqlConnection(ConfigurationManager.ConnectionStrings.Item("StringConexion").ToString())
    Private Sub FrmImportarMinerasDbMetal_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

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
                '        Cargar(DgOrdenLab, Txtruta.Text, nombreHoja)

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

            With DgMineras
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
    Private Function ValidaSiExiste(ByVal Consecutivo As String) As Boolean
        Try

            Using cnn As New SqlConnection(ConfigurationManager.ConnectionStrings.Item("StringConexion").ToString())
                Dim sqlbuscar As String = String.Format("SELECT COUNT(*) FROM PB_Mineras WHERE Consecutivo = @Consecutivo")
                Dim cmd As New SqlCommand(sqlbuscar, cnn)
                cmd.Parameters.AddWithValue("@Consecutivo", Consecutivo)
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
            Dim Consecutivo, Sello1, Sello2, Sello3, Sello4, Sello5, Sello6, Mina, muestra As String
            Dim fecha As Date
            Dim Tenor, TenorAg, Humedad, TonHumedas As Double
            Dim limite As Integer
            limite = 2000
            For i As Integer = 2 To 10000
                celda = "A" & i

                'Dim samples, idlab As String
                Consecutivo = Replace(Convert.ToString(HojaExcel.Range("C" & i).Value), " ", "")
                Sello1 = Replace(Convert.ToString(HojaExcel.Range("F" & i).Value), " ", "")
                Sello2 = Replace(Convert.ToString(HojaExcel.Range("G" & i).Value), " ", "")
                Sello3 = Replace(Convert.ToString(HojaExcel.Range("H" & i).Value), " ", "")
                Sello4 = Replace(Convert.ToString(HojaExcel.Range("I" & i).Value), " ", "")
                Sello5 = Replace(Convert.ToString(HojaExcel.Range("J" & i).Value), " ", "")
                Sello6 = Replace(Convert.ToString(HojaExcel.Range("K" & i).Value), " ", "")
                muestra = Replace(Convert.ToString(HojaExcel.Range("l" & i).Value), " ", "")
                Mina = Convert.ToString(HojaExcel.Range("O" & i).Value)

                Humedad = CDbl(HojaExcel.Range("V" & i).Value)
                TonHumedas = CDbl(HojaExcel.Range("P" & i).Value)
                Tenor = CDbl(HojaExcel.Range("R" & i).Value)
                TenorAg = CDbl(HojaExcel.Range("U" & i).Value)
                'idlab = Convert.ToString((HojaExcel.Range("B11").Value))
                fecha = CDate(HojaExcel.Range("E" & i).Value)

                If Consecutivo = "" Then
                Else
                    If (ValidaSiExiste(Consecutivo)) Then
                        cmd.CommandText = "UPDATE  PB_Mineras  SET fecha = '" & fecha & "' , sello1 = '" & Sello1 & "' , sello2 = '" & Sello2 & "' , sello3 = '" & Sello3 & "' , sello4 = '" & Sello4 & "' , sello5 = '" & Sello5 & "' , sello6 = '" & Sello6 & "'  , muestra = '" & muestra & "' , mina = '" & Mina & "' , TonHumedas = '" & TonHumedas & "' , tenor = '" & Tenor & "' , tenorag = '" & TenorAg & "'  , humedad = '" & Humedad & "' WHERE CONSECUTIVO= '" & Consecutivo & "'   "
                    Else
                        cmd.CommandText = "INSERT INTO PB_Mineras (fecha , sello1 , sello2 ,sello3 , sello4 , sello5 , sello6 , muestra ,mina ,tonhumedas , tenor , tenorag , Consecutivo , humedad )VALUES('" & fecha & "','" & Sello1 & "','" & Sello2 & "'  ,'" & Sello3 & "' ,'" & Sello4 & "' ,'" & Sello5 & "' ,'" & Sello6 & "' ,'" & muestra & "' ,'" & Mina & "' ,'" & TonHumedas & "' ,'" & Tenor & "' ,'" & TenorAg & "','" & Consecutivo & "' , '" & Humedad & "' )"
                    End If
                    cmd.Connection = sqlConnectiondb
                    sqlConnectiondb.Open()
                    cmd.ExecuteNonQuery()
                    sqlConnectiondb.Close()
                End If

                If CStr(HojaExcel.Range("C" & i).Value) = "" Then
                    sqlConnectiondb.Close()
                    MsgBox("Importacion Finalizada")
                    Exit For

                End If

            Next
            LibroExcel.Close()
            AppExcel.Quit()
            AppExcel = Nothing
            LibroExcel = Nothing



        Catch ex As Exception
            ' Handle the exception.
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class