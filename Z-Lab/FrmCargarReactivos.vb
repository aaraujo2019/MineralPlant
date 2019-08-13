Option Explicit On
Option Strict On
Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.Office.Interop
Imports System.Data.OleDb
Imports System.Windows.Forms
Imports System.Configuration

Public Class FrmCargarReactivos
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
            .Filter = "Archivos de Excel (*.xls)|*.xls|(*.xlsx)|*.xlsx"
            .Multiselect = False
            .InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments

            If .ShowDialog = Windows.Forms.DialogResult.OK Then
                Txtruta.Text = .FileName
            End If
        End With
        If Txtruta.Text <> String.Empty Then
            Try
                Dim nombreHoja As String = ObtenerNombrePrimeraHoja(Txtruta.Text)
                Cargar(DgOrdenLab, Txtruta.Text, nombreHoja)

            Catch ex As OleDbException
                MessageBox.Show(ex.Message)
            End Try

        End If
    End Sub

    Private Function ObtenerNombrePrimeraHoja(ByVal rutaLibro As String) As String
        Dim app As Excel.Application = Nothing

        Try
            app = New Excel.Application()
            Dim wb As Excel.Workbook = app.Workbooks.Open(rutaLibro)
            Dim ws As Excel.Worksheet = CType(wb.Worksheets.Item(1), Excel.Worksheet)
            Dim name As String = ws.Name
            Return name
        Catch ex As Exception
            Throw
        End Try
    End Function

    Sub Cargar(ByVal dgView As DataGridView, ByVal SLibro As String, ByVal sHoja As String)
        Dim cs As String = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" & SLibro & "; Extended Properties=""Excel 8.0;HDR=YES"""
        Try
            Dim cn As New OleDbConnection(cs)

            If Not IO.File.Exists(SLibro) Then
                MsgBox("No se encontró el Libro: " & SLibro, MsgBoxStyle.Critical, "Ruta inválida")
                Exit Sub
            End If

            Dim dAdapter As New OleDbDataAdapter("Select * From [" & sHoja & "$]", cs)
            Dim datos As New DataSet

            dAdapter.Fill(datos)
            With DgOrdenLab
                .DataSource = datos.Tables(0)
            End With
        Catch oMsg As Exception
            MsgBox(oMsg.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Function ValidaSiExiste(ByVal pCodigo As String) As Boolean
        Try
            Using cnn As New SqlConnection(ConfigurationManager.ConnectionStrings.Item("StringConexion").ToString())
                Dim sqlbuscar As String = String.Format("SELECT COUNT(*) FROM RfReactivosPlanta WHERE Codigo = @pCodigo")
                Dim cmd As New SqlCommand(sqlbuscar, cnn)
                cmd.Parameters.AddWithValue("@pCodigo", pCodigo)
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

        Try
            Dim FicheroExcel As String
            Dim NombreHoja As String
            Dim sqlConnectiondb As New SqlConnection(ConfigurationManager.ConnectionStrings.Item("StringConexion").ToString())

            If Txtruta.Text <> String.Empty Then
                Dim cmd As New SqlCommand
                cmd.CommandType = CommandType.Text
                FicheroExcel = Txtruta.Text
                NombreHoja = ObtenerNombrePrimeraHoja(Txtruta.Text)
                AppExcel = New Excel.Application
                LibroExcel = AppExcel.Workbooks.Open(FicheroExcel)
                HojaExcel = CType(LibroExcel.Sheets(NombreHoja), Excel.Worksheet)

                For i As Integer = 2 To 200
                    Dim codigo As Integer
                    Dim nombreRea, ccosto As String
                    Dim visible As Boolean

                    codigo = CInt(HojaExcel.Range("A" & i).Value)
                    nombreRea = CType(IIf(HojaExcel.Range("B" & i).Value Is Nothing, String.Empty, HojaExcel.Range("B" & i).Value), String)
                    ccosto = CType(IIf(HojaExcel.Range("C" & i).Value Is Nothing, String.Empty, HojaExcel.Range("C" & i).Value), String)
                    visible = CType(IIf(HojaExcel.Range("D" & i).Value Is Nothing, False, HojaExcel.Range("D" & i).Value), Boolean)

                    If codigo <> 0 Then
                        If (ValidaSiExiste(codigo.ToString)) Then
                            cmd.CommandText = "UPDATE  RfReactivosPlanta  SET NombreReactivo = '" & nombreRea & "'," &
                                              " CentroCosto = '" & ccosto & "', " &
                                              " Visible = '" & visible & "' " &
                                              "WHERE Codigo = '" & codigo & "'"
                        Else
                            cmd.CommandText = "INSERT INTO RfReactivosPlanta (Codigo, NombreReactivo, CentroCosto, Visible)VALUES('" & codigo & "','" & nombreRea & "','" & ccosto & "','" & visible & "')"
                        End If

                        cmd.Connection = sqlConnectiondb
                        sqlConnectiondb.Open()
                        cmd.ExecuteNonQuery()
                        sqlConnectiondb.Close()
                    End If

                    If CStr(HojaExcel.Range("A" & i).Value) = Nothing Then
                        sqlConnectiondb.Close()
                        MessageBox.Show("Importacion Finalizada", "Confirmación transacción", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        DgOrdenLab.DataSource = Nothing
                        Txtruta.Text = String.Empty
                        Exit For
                    End If

                Next
            Else
                MessageBox.Show("Por favor seleccione un archivo de carga de reactivos par continuar", "Carga de Reactivos", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class