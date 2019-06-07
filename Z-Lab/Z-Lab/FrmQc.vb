
Option Explicit On
Option Strict On
Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.Office.Interop
Imports System.Data.OleDb
Imports System.Windows.Forms
Imports System.Configuration

Public Class FrmQc
    Dim conn As New ADODB.Connection()
    Dim cnStr As String
    Private Sub CmdSeleccionar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdSeleccionar.Click
        Dim openFD As New OpenFileDialog()
        With openFD
            .Title = "Seleccionar archivos"
            .Filter = "Todos los archivos (*.xls)|*.xls"
            .Multiselect = False
            .InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments

            If .ShowDialog = Windows.Forms.DialogResult.OK Then


                TxtRuta.Text = .FileName
            End If
        End With
        If TxtRuta.Text = "" Then

        Else
            Try
                Dim nombreHoja As String = ObtenerNombrePrimeraHoja(TxtRuta.Text)
                ' MessageBox.Show(nombreHoja)
                Cargar(DgResultado, TxtRuta.Text, nombreHoja)

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

            With DgResultado
                ' llena el DataGridView  
                .DataSource = datos.Tables(0)

            End With
        Catch oMsg As Exception
            MsgBox(oMsg.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub cmdUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpdate.Click
        ExceldeCorreo()
    End Sub
    Private Sub actualizarfinal()
        Dim sqlConnectiondb As New System.Data.SqlClient.SqlConnection(ConfigurationManager.AppSettings("StringConexion").ToString)
        Dim cmd As New System.Data.SqlClient.SqlCommand
        cmd.CommandType = System.Data.CommandType.Text
        cmd.CommandText = "UPDATE  Assay  SET     Aufinal= Au_Gtm   WHERE Au_Gtm = '<1'   "
        cmd.Connection = sqlConnectiondb
        sqlConnectiondb.Open()
        cmd.ExecuteNonQuery()
        sqlConnectiondb.Close()
    End Sub

    Private Sub ExceldeCorreo()

        Dim AppExcel As Excel.Application
        Dim LibroExcel As Excel.Workbook
        Dim HojaExcel As Excel.Worksheet
        Dim celda As String

        cnStr = ConfigurationManager.AppSettings("StringConexionODBC").ToString

        Try
            Dim FicheroExcel As String
            Dim NombreHoja As String
            'variables de insercion
            Dim sqlConnectiondb As New System.Data.SqlClient.SqlConnection(ConfigurationManager.AppSettings("StringConexion").ToString)
            Dim cmd As New System.Data.SqlClient.SqlCommand
            cmd.CommandType = System.Data.CommandType.Text
            FicheroExcel = TxtRuta.Text
            NombreHoja = ObtenerNombrePrimeraHoja(TxtRuta.Text)
            AppExcel = New Excel.Application
            LibroExcel = AppExcel.Workbooks.Open(FicheroExcel)
            HojaExcel = CType(LibroExcel.Sheets(NombreHoja), Excel.Worksheet)
            Dim limite As Integer
            limite = 200
            'HOJA EXCEL QUE SE DESCARGA DE LA PAGINA
            If Convert.ToString(HojaExcel.Range("A6").Value) = "Analito" And Convert.ToString(HojaExcel.Range("A7").Value) = "Esquema" Then
                'Dim extension As Integer
                'extension = 11 + (Convert.ToInt16(HojaExcel.Range("A6").Value))
                For i As Integer = 11 To 11 + (Convert.ToInt16(HojaExcel.Range("S2").Value))
                    If Convert.ToString(HojaExcel.Range("A" & i).Value) <> "BLANK_PREP" Then
                        celda = "A" & i
                        conn.Open(cnStr)

                        Dim samples, idlab, AuFinal_ppm, humedad, Au_ppb, Au_Gtm, Ag_Ppm, Ag_Gt, PesoMuestra As String

                        samples = Convert.ToString(HojaExcel.Range("A" & i).Value)
                        idlab = Convert.ToString((HojaExcel.Range("B2").Value))
                        humedad = ""
                        Au_ppb = "0"
                        Au_Gtm = ""
                        Ag_Ppm = ""
                        Ag_Gt = ""
                        PesoMuestra = ""
                        AuFinal_ppm = ""
                        'columna FAA313
                        If Convert.ToString(HojaExcel.Range("C" & i).Value) <> "" Then
                            If Convert.ToString(HojaExcel.Range("C7").Value) = "GQ_H2O" Then
                                humedad = Convert.ToString(HojaExcel.Range("C" & i).Value)
                            ElseIf Convert.ToString(HojaExcel.Range("C7").Value) = "FAA313" Then
                                Au_ppb = Convert.ToString(CDbl(HojaExcel.Range("C" & i).Value) / 1000)
                            ElseIf Convert.ToString(HojaExcel.Range("C7").Value) = "FAG303" Then
                                Au_Gtm = Convert.ToString(HojaExcel.Range("C" & i).Value)
                            ElseIf Convert.ToString(HojaExcel.Range("C7").Value) = "AAS12C" Then
                                Ag_Ppm = Convert.ToString(HojaExcel.Range("C" & i).Value)
                            ElseIf Convert.ToString(HojaExcel.Range("C7").Value) = "AAS41B (*)" Then
                                Ag_Gt = Convert.ToString(HojaExcel.Range("C" & i).Value)
                            ElseIf Convert.ToString(HojaExcel.Range("C7").Value) = "PMI_CH" Then
                                PesoMuestra = Convert.ToString(HojaExcel.Range("C" & i).Value)
                            End If
                        End If

                        If Convert.ToString(HojaExcel.Range("D" & i).Value) <> "--" Then
                            If Convert.ToString(HojaExcel.Range("D7").Value) = "GQ_H2O" Then
                                humedad = Convert.ToString(HojaExcel.Range("D" & i).Value)
                            ElseIf Convert.ToString(HojaExcel.Range("D7").Value) = "FAA313" Then
                                Au_ppb = Convert.ToString(CDbl(HojaExcel.Range("D" & i).Value) / 1000)
                            ElseIf Convert.ToString(HojaExcel.Range("D7").Value) = "FAG303" Then
                                Au_Gtm = Convert.ToString(HojaExcel.Range("D" & i).Value)
                            ElseIf Convert.ToString(HojaExcel.Range("D7").Value) = "AAS12C" Then
                                Ag_Ppm = Convert.ToString(HojaExcel.Range("D" & i).Value)
                            ElseIf Convert.ToString(HojaExcel.Range("D7").Value) = "AAS41B (*)" Then
                                Ag_Gt = Convert.ToString(HojaExcel.Range("D" & i).Value)
                            ElseIf Convert.ToString(HojaExcel.Range("D7").Value) = "PMI_CH" Then
                                PesoMuestra = Convert.ToString(HojaExcel.Range("D" & i).Value)
                            End If
                        End If
                        If Convert.ToString(HojaExcel.Range("E" & i).Value) <> "--" Then
                            If Convert.ToString(HojaExcel.Range("E7").Value) = "GQ_H2O" Then
                                humedad = Convert.ToString(HojaExcel.Range("E" & i).Value)
                            ElseIf Convert.ToString(HojaExcel.Range("E7").Value) = "FAA313" Then
                                Au_ppb = Convert.ToString(CDbl(HojaExcel.Range("E" & i).Value) / 1000)
                            ElseIf Convert.ToString(HojaExcel.Range("E7").Value) = "FAG303" Then
                                Au_Gtm = Convert.ToString(HojaExcel.Range("E" & i).Value)
                            ElseIf Convert.ToString(HojaExcel.Range("E7").Value) = "AAS12C" Then
                                Ag_Ppm = Convert.ToString(HojaExcel.Range("E" & i).Value)
                            ElseIf Convert.ToString(HojaExcel.Range("E7").Value) = "AAS41B (*)" Then
                                Ag_Gt = Convert.ToString(HojaExcel.Range("E" & i).Value)
                            ElseIf Convert.ToString(HojaExcel.Range("E7").Value) = "PMI_CH" Then
                                PesoMuestra = Convert.ToString(HojaExcel.Range("E" & i).Value)
                            End If
                        End If

                        If Convert.ToString(HojaExcel.Range("F" & i).Value) <> "--" Then
                            If Convert.ToString(HojaExcel.Range("F7").Value) = "GQ_H2O" Then
                                humedad = Convert.ToString(HojaExcel.Range("F" & i).Value)
                            ElseIf Convert.ToString(HojaExcel.Range("F7").Value) = "FAA313" Then
                                Au_ppb = Convert.ToString(CDbl(HojaExcel.Range("F" & i).Value) / 1000)
                            ElseIf Convert.ToString(HojaExcel.Range("F7").Value) = "FAG303" Then
                                Au_Gtm = Convert.ToString(HojaExcel.Range("F" & i).Value)
                            ElseIf Convert.ToString(HojaExcel.Range("F7").Value) = "AAS12C" Then
                                Ag_Ppm = Convert.ToString(HojaExcel.Range("F" & i).Value)
                            ElseIf Convert.ToString(HojaExcel.Range("F7").Value) = "AAS41B (*)" Then
                                Ag_Gt = Convert.ToString(HojaExcel.Range("F" & i).Value)
                            ElseIf Convert.ToString(HojaExcel.Range("F7").Value) = "PMI_CH" Then
                                PesoMuestra = Convert.ToString(HojaExcel.Range("F" & i).Value)
                            End If
                        End If

                        If Convert.ToString(HojaExcel.Range("G" & i).Value) <> "--" Then
                            If Convert.ToString(HojaExcel.Range("G7").Value) = "GQ_H2O" Then
                                humedad = Convert.ToString(HojaExcel.Range("G" & i).Value)
                            ElseIf Convert.ToString(HojaExcel.Range("G7").Value) = "FAA313" Then
                                Au_ppb = Convert.ToString(CDbl(HojaExcel.Range("G" & i).Value) / 1000)
                            ElseIf Convert.ToString(HojaExcel.Range("G7").Value) = "FAG303" Then
                                Au_Gtm = Convert.ToString(HojaExcel.Range("G" & i).Value)
                            ElseIf Convert.ToString(HojaExcel.Range("G7").Value) = "AAS12C" Then
                                Ag_Ppm = Convert.ToString(HojaExcel.Range("G" & i).Value)
                            ElseIf Convert.ToString(HojaExcel.Range("G7").Value) = "AAS41B (*)" Then
                                Ag_Gt = Convert.ToString(HojaExcel.Range("G" & i).Value)
                            ElseIf Convert.ToString(HojaExcel.Range("G7").Value) = "PMI_CH" Then
                                PesoMuestra = Convert.ToString(HojaExcel.Range("G" & i).Value)
                            End If
                        End If

                        cmd.CommandText = "INSERT INTO MN_Assay (Muestra,Jobno, humedad , au_ppb,Au_Gtm, Ag_Ppm , Ag_Gt , PesoMuestra )VALUES('" & samples & "','" & idlab & "' , '" & humedad & "' , '" & Au_ppb & "' , '" & Au_Gtm & "' , '" & Ag_Ppm & "'  , '" & Ag_Gt & "' , '" & PesoMuestra & "'  )"

                        If 11 + (Convert.ToInt16(HojaExcel.Range("S2").Value)) = i Then
                            sqlConnectiondb.Close()
                            conn.Close()
                            MsgBox("Importacion Finalizada")
                            Exit For

                        End If
                        cmd.Connection = sqlConnectiondb
                        sqlConnectiondb.Open()
                        cmd.ExecuteNonQuery()
                        sqlConnectiondb.Close()
                        conn.Close()
                    End If
                Next
            End If


            ' PARA EL ARCHIVO QUE LLEGA EN EL CORREO DE NATALIA GARZON
            If Convert.ToString(HojaExcel.Range("B8").Value) = "MEDELLIN" And Convert.ToString(HojaExcel.Range("A12").Value) = "Elemento" Then
                For i As Integer = 17 To 200
                    celda = "A" & i
                    conn.Open(cnStr)
                    Dim samples, idlab, AuFinal_ppm, humedad, Au_ppb, Au_Gtm, Ag_Ppm, Ag_Gt, PesoMuestra As String
                    samples = Convert.ToString(HojaExcel.Range("A" & i).Value)
                    idlab = Convert.ToString((HojaExcel.Range("B5").Value))
                    humedad = ""
                    Au_ppb = "0"
                    Au_Gtm = ""
                    Ag_Ppm = ""
                    Ag_Gt = ""
                    PesoMuestra = ""
                    AuFinal_ppm = ""
                    'columna FAA313
                    If Convert.ToString(HojaExcel.Range("B" & i).Value) <> "--" Then
                        If Convert.ToString(HojaExcel.Range("B14").Value) = "GQ_H2O" Then
                            humedad = Convert.ToString(HojaExcel.Range("B" & i).Value)
                        ElseIf Convert.ToString(HojaExcel.Range("B14").Value) = "FAA313" Then
                            Au_ppb = Convert.ToString(CDbl(HojaExcel.Range("B" & i).Value) / 1000)
                        ElseIf Convert.ToString(HojaExcel.Range("B14").Value) = "FAG303" Then
                            Au_Gtm = Convert.ToString(HojaExcel.Range("B" & i).Value)
                        ElseIf Convert.ToString(HojaExcel.Range("B14").Value) = "AAS12C" Then
                            Ag_Ppm = Convert.ToString(HojaExcel.Range("B" & i).Value)
                        ElseIf Convert.ToString(HojaExcel.Range("B14").Value) = "AAS41B (*)" Then
                            Ag_Gt = Convert.ToString(HojaExcel.Range("B" & i).Value)
                        ElseIf Convert.ToString(HojaExcel.Range("B14").Value) = "PMI_CH" Then
                            PesoMuestra = Convert.ToString(HojaExcel.Range("B" & i).Value)
                        End If
                    End If


                    If Convert.ToString(HojaExcel.Range("C" & i).Value) <> "--" Then
                        If Convert.ToString(HojaExcel.Range("C14").Value) = "GQ_H2O" Then
                            humedad = Convert.ToString(HojaExcel.Range("C" & i).Value)
                        ElseIf Convert.ToString(HojaExcel.Range("C14").Value) = "FAA313" Then
                            Au_ppb = Convert.ToString(CDbl(HojaExcel.Range("C" & i).Value) / 1000)
                        ElseIf Convert.ToString(HojaExcel.Range("C14").Value) = "FAG303" Then
                            Au_Gtm = Convert.ToString(HojaExcel.Range("C" & i).Value)
                        ElseIf Convert.ToString(HojaExcel.Range("C14").Value) = "AAS12C" Then
                            Ag_Ppm = Convert.ToString(HojaExcel.Range("C" & i).Value)
                        ElseIf Convert.ToString(HojaExcel.Range("C14").Value) = "AAS41B (*)" Then
                            Ag_Gt = Convert.ToString(HojaExcel.Range("C" & i).Value)
                        ElseIf Convert.ToString(HojaExcel.Range("C14").Value) = "PMI_CH" Then
                            PesoMuestra = Convert.ToString(HojaExcel.Range("C" & i).Value)
                        End If
                    End If

                    If Convert.ToString(HojaExcel.Range("D" & i).Value) <> "--" Then
                        If Convert.ToString(HojaExcel.Range("D14").Value) = "GQ_H2O" Then
                            humedad = Convert.ToString(HojaExcel.Range("D" & i).Value)
                        ElseIf Convert.ToString(HojaExcel.Range("D14").Value) = "FAA313" Then
                            Au_ppb = Convert.ToString(CDbl(HojaExcel.Range("D" & i).Value) / 1000)
                        ElseIf Convert.ToString(HojaExcel.Range("D14").Value) = "FAG303" Then
                            Au_Gtm = Convert.ToString(HojaExcel.Range("D" & i).Value)
                        ElseIf Convert.ToString(HojaExcel.Range("D14").Value) = "AAS12C" Then
                            Ag_Ppm = Convert.ToString(HojaExcel.Range("D" & i).Value)
                        ElseIf Convert.ToString(HojaExcel.Range("D14").Value) = "AAS41B (*)" Then
                            Ag_Gt = Convert.ToString(HojaExcel.Range("D" & i).Value)
                        ElseIf Convert.ToString(HojaExcel.Range("D14").Value) = "PMI_CH" Then
                            PesoMuestra = Convert.ToString(HojaExcel.Range("D" & i).Value)
                        End If
                    End If
                    If Convert.ToString(HojaExcel.Range("E" & i).Value) <> "--" Then
                        If Convert.ToString(HojaExcel.Range("E14").Value) = "GQ_H2O" Then
                            humedad = Convert.ToString(HojaExcel.Range("E" & i).Value)
                        ElseIf Convert.ToString(HojaExcel.Range("E14").Value) = "FAA313" Then
                            Au_ppb = Convert.ToString(CDbl(HojaExcel.Range("E" & i).Value) / 1000)
                        ElseIf Convert.ToString(HojaExcel.Range("E14").Value) = "FAG303" Then
                            Au_Gtm = Convert.ToString(HojaExcel.Range("E" & i).Value)
                        ElseIf Convert.ToString(HojaExcel.Range("E14").Value) = "AAS12C" Then
                            Ag_Ppm = Convert.ToString(HojaExcel.Range("E" & i).Value)
                        ElseIf Convert.ToString(HojaExcel.Range("E14").Value) = "AAS41B (*)" Then
                            Ag_Gt = Convert.ToString(HojaExcel.Range("E" & i).Value)
                        ElseIf Convert.ToString(HojaExcel.Range("E14").Value) = "PMI_CH" Then
                            PesoMuestra = Convert.ToString(HojaExcel.Range("E" & i).Value)
                        End If
                    End If

                    If Convert.ToString(HojaExcel.Range("F" & i).Value) <> "--" Then
                        If Convert.ToString(HojaExcel.Range("F14").Value) = "GQ_H2O" Then
                            humedad = Convert.ToString(HojaExcel.Range("F" & i).Value)
                        ElseIf Convert.ToString(HojaExcel.Range("F14").Value) = "FAA313" Then
                            Au_ppb = Convert.ToString(CDbl(HojaExcel.Range("F" & i).Value) / 1000)
                        ElseIf Convert.ToString(HojaExcel.Range("F14").Value) = "FAG303" Then
                            Au_Gtm = Convert.ToString(HojaExcel.Range("F" & i).Value)
                        ElseIf Convert.ToString(HojaExcel.Range("F14").Value) = "AAS12C" Then
                            Ag_Ppm = Convert.ToString(HojaExcel.Range("F" & i).Value)
                        ElseIf Convert.ToString(HojaExcel.Range("F14").Value) = "AAS41B (*)" Then
                            Ag_Gt = Convert.ToString(HojaExcel.Range("F" & i).Value)
                        ElseIf Convert.ToString(HojaExcel.Range("F14").Value) = "PMI_CH" Then
                            PesoMuestra = Convert.ToString(HojaExcel.Range("F" & i).Value)
                        End If
                    End If

                    If Convert.ToString(HojaExcel.Range("G" & i).Value) <> "--" Then
                        If Convert.ToString(HojaExcel.Range("G14").Value) = "GQ_H2O" Then
                            humedad = Convert.ToString(HojaExcel.Range("G" & i).Value)
                        ElseIf Convert.ToString(HojaExcel.Range("G14").Value) = "FAA313" Then
                            Au_ppb = Convert.ToString(CDbl(HojaExcel.Range("G" & i).Value) / 1000)
                        ElseIf Convert.ToString(HojaExcel.Range("G14").Value) = "FAG303" Then
                            Au_Gtm = Convert.ToString(HojaExcel.Range("G" & i).Value)
                        ElseIf Convert.ToString(HojaExcel.Range("G14").Value) = "AAS12C" Then
                            Ag_Ppm = Convert.ToString(HojaExcel.Range("G" & i).Value)
                        ElseIf Convert.ToString(HojaExcel.Range("G14").Value) = "AAS41B (*)" Then
                            Ag_Gt = Convert.ToString(HojaExcel.Range("G" & i).Value)
                        ElseIf Convert.ToString(HojaExcel.Range("G14").Value) = "PMI_CH" Then
                            PesoMuestra = Convert.ToString(HojaExcel.Range("G" & i).Value)
                        End If
                    End If

                    cmd.CommandText = "INSERT INTO MN_Assay (Muestra,Jobno, humedad , au_ppb,Au_Gtm, Ag_Ppm , Ag_Gt , PesoMuestra )VALUES('" & samples & "','" & idlab & "' , '" & humedad & "' , '" & Au_ppb & "' , '" & Au_Gtm & "' , '" & Ag_Ppm & "'  , '" & Ag_Gt & "' , '" & PesoMuestra & "'  )"

                    If CStr(HojaExcel.Range("A" & i).Value) = "END/FIN" Then

                        sqlConnectiondb.Close()
                        conn.Close()
                        MsgBox("Importacion Finalizada")
                        Exit For

                    End If
                    cmd.Connection = sqlConnectiondb
                    sqlConnectiondb.Open()
                    cmd.ExecuteNonQuery()
                    sqlConnectiondb.Close()
                    conn.Close()
                Next
            End If
            LibroExcel.Close()
            AppExcel.Quit()
            Exit Sub
            'Else
            'MessageBox.Show("La orden de Envio o remision del archivo, no existe en la base de datos.")
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




    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

    End Sub
End Class