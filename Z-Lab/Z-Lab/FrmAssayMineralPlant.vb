Option Explicit On
Option Strict On
Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.Office.Interop
Imports System.Data.OleDb
Imports System.Windows.Forms
Imports System.Configuration

Public Class FrmAssayMineralPlant
    Dim nombreHoja As String
    Dim conn As New ADODB.Connection()
    Dim rstlab As New ADODB.Recordset()


    Dim rst As New ADODB.Recordset()
    Dim cnStr As String
    Dim Cn As New SqlConnection(ConfigurationManager.AppSettings("StringConexion").ToString)


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

    Private Sub CmdGuardarJobno_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdGuardarJobno.Click
        Dim AppExcel As Excel.Application
        Dim LibroExcel As Excel.Workbook
        Dim HojaExcel As Excel.Worksheet
        Dim celda As String
        Dim au_ppb As String
        Dim au_gtm As String
        Dim ag_ppm As String
        au_ppb = "NO"
        au_gtm = "NO"
        ag_ppm = "NO"

        cnStr = "Provider=SQLNCLI10;Initial Catalog=GZC;Data Source=mercurio; User ID=sa;Password=BdZandor123*;"
        Try
            Dim FicheroExcel As String
            Dim NombreHoja As String
            'variables de insercion
            Dim sqlConnectiondb As New System.Data.SqlClient.SqlConnection(ConfigurationManager.AppSettings("StringConexion").ToString)
            Dim cmd As New System.Data.SqlClient.SqlCommand
            cmd.CommandType = System.Data.CommandType.Text
            FicheroExcel = Txtruta.Text
            NombreHoja = ObtenerNombrePrimeraHoja(Txtruta.Text)
            AppExcel = New Excel.Application
            LibroExcel = AppExcel.Workbooks.Open(FicheroExcel)
            HojaExcel = CType(LibroExcel.Sheets(NombreHoja), Excel.Worksheet)
            'procedimento para solucion.
            If Cmbtipomuestra.Text = "Solución" Then
                If CStr(HojaExcel.Range("B12").Value) = "Ag" And CStr(HojaExcel.Range("B13").Value) = "MG/L" Then
                    ag_ppm = "OK"
                End If
                If CStr(HojaExcel.Range("C12").Value) = "Au" And CStr(HojaExcel.Range("C13").Value) = "MG/L" Then
                    au_ppb = "OK"
                End If
                If au_ppb = "OK" And ag_ppm = "OK" Then

                    ' verifica si el envio de la remision existe
                    Dim Ds As New DataSet
                    Dim DsP As New DataSet
                    Dim envio As String
                    envio = (CStr(HojaExcel.Range("B10").Value))
                    Dim Da As New SqlClient.SqlDataAdapter("SELECT * FROM PB_LabSumit  WHERE Orden ='" & envio & "'  ", Cn)

                    Da.Fill(Ds, "PB_LabSumit")
                    Dim myDataView As DataView = New DataView(Ds.Tables("PB_LabSumit"))

                    ' If myDataView.Count > 0 Then
                    ' EXISTE EL ENVIO

                    Dim limite As Integer
                    limite = 200

                    For i As Integer = 17 To 200
                        celda = "A" & i

                        'Try
                        conn.Open(cnStr)

                        Dim samples, idlab, aulab_ppb, Aglab_ppm, pesogr, AuFinal_ppm As String

                        samples = Convert.ToString(HojaExcel.Range("A" & i).Value)
                        idlab = Convert.ToString((HojaExcel.Range("B5").Value))
                        AuFinal_ppm = ""
                        'validacion para el campo Au_ppb


                        'filtros de validacion para el camp au_Gt
                        If Convert.ToString(HojaExcel.Range("B" & i).Value) = "--" Then
                            Aglab_ppm = ""

                        ElseIf Convert.ToString(HojaExcel.Range("B" & i).Value) = "<0.02" Then
                            Aglab_ppm = "0.02"
                        Else
                            Aglab_ppm = Convert.ToString(HojaExcel.Range("B" & i).Value)

                        End If

                        If Convert.ToString(HojaExcel.Range("C" & i).Value) = "--" Then
                            aulab_ppb = ""
                        ElseIf Convert.ToString(HojaExcel.Range("C" & i).Value) = "<0.03" Then
                            aulab_ppb = "0.03"
                            AuFinal_ppm = "0.03"
                        Else
                            aulab_ppb = Convert.ToString(HojaExcel.Range("C" & i).Value)
                            AuFinal_ppm = aulab_ppb
                        End If
                        If Convert.ToString(HojaExcel.Range("D" & i).Value) = "--" Then
                            pesogr = ""
                        Else
                            pesogr = Convert.ToString(HojaExcel.Range("D" & i).Value)
                        End If
                        cmd.CommandText = "INSERT INTO PB_Assay (Muestra,Jobno,Au_Ppm,AuFinal_ppm, Ag_Ppm,Peso_gr)VALUES('" & samples & "','" & idlab & "','" & aulab_ppb & "','" & AuFinal_ppm & "','" & Aglab_ppm & "', '" & pesogr & "')"
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
                    LibroExcel.Close()
                    AppExcel.Quit()
                Else
                    MsgBox("Las columnas del archivo de Analisis no estan correctamente Ordenadas, por favor verifique")

                End If
            End If



            ' procedimiento para resultados de solidos.


            If Cmbtipomuestra.Text = "Bandas" Or Cmbtipomuestra.Text = "Sólido" Then


                If CStr(HojaExcel.Range("B14").Value) = "FAA313" Then
                    au_ppb = "OK"
                End If
                If CStr(HojaExcel.Range("C14").Value) = "FAG303" Then
                    au_gtm = "OK"
                End If
                If CStr(HojaExcel.Range("D14").Value) = "Ag" And CStr(HojaExcel.Range("D13").Value) = "PPM" Then
                    ag_ppm = "OK"
                End If

                'primer tipo de remision
                If au_ppb = "OK" And au_gtm = "OK" And ag_ppm = "OK" Then


                    Dim limite As Integer
                    limite = 200

                    For i As Integer = 17 To 200
                        celda = "A" & i

                        'Try
                        conn.Open(cnStr)

                        Dim samples, idlab, aulab_ppb, aulab_gt, Aglab_ppm, pesogr, AuFinal_ppm As String
                        samples = Convert.ToString(HojaExcel.Range("A" & i).Value)
                        idlab = Convert.ToString((HojaExcel.Range("B5").Value))
                        AuFinal_ppm = ""
                        'validacion para el campo Au_ppb
                        If Convert.ToString(HojaExcel.Range("B" & i).Value) = "--" Then
                            aulab_ppb = ""
                        ElseIf Convert.ToString(HojaExcel.Range("B" & i).Value) = "<0.02" Then
                            aulab_ppb = "0.02"

                        Else
                            aulab_ppb = CStr(Convert.ToDecimal(HojaExcel.Range("B" & i).Value) / 1000)
                            AuFinal_ppm = aulab_ppb
                        End If
                        'filtros de validacion para el camp au_Gt
                        If Convert.ToString(HojaExcel.Range("C" & i).Value) = "--" Then
                            aulab_gt = ""
                        ElseIf Convert.ToString(HojaExcel.Range("C" & i).Value) = "<0.03" Then
                            aulab_gt = "0.03"
                        ElseIf Convert.ToString(HojaExcel.Range("C" & i).Value) = "<3" Then
                            aulab_gt = "0.03"
                        Else
                            aulab_gt = Convert.ToString(HojaExcel.Range("C" & i).Value)
                            AuFinal_ppm = aulab_gt
                        End If
                        If Convert.ToString((HojaExcel.Range("D" & i)).Value) = "--" Then
                            Aglab_ppm = ""
                        Else
                            Aglab_ppm = Convert.ToString((HojaExcel.Range("D" & i)).Value)
                        End If

                        If Convert.ToString(HojaExcel.Range("E" & i).Value) = "--" Then
                            pesogr = ""
                        Else
                            pesogr = Convert.ToString(HojaExcel.Range("E" & i).Value)
                        End If


                        cmd.CommandText = "INSERT INTO PB_Assay (Muestra,Jobno,Au_Ppm,Au_Gt,AuFinal_ppm, Ag_Ppm,Peso_gr)VALUES('" & samples & "','" & idlab & "','" & aulab_ppb & "','" & aulab_gt & "','" & AuFinal_ppm & "','" & Aglab_ppm & "', '" & pesogr & "')"

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
                    LibroExcel.Close()
                    AppExcel.Quit()
                    Exit Sub
                    'Else
                    'MessageBox.Show("La orden de Envio o remision del archivo, no existe en la base de datos.")



                End If


                au_ppb = "NO"
                au_gtm = "NO"
                ag_ppm = "NO"



                If CStr(HojaExcel.Range("B14").Value) = "FAA313" Then
                    au_ppb = "OK"
                End If
                If CStr(HojaExcel.Range("C14").Value) = "FAG303" Then
                    au_gtm = "OK"
                End If

                If CStr(HojaExcel.Range("D14").Value) = "PMI_CH" Then
                    ag_ppm = "OK"
                End If



                'primer tipo de remision
                If au_ppb = "OK" And au_gtm = "OK" And ag_ppm = "OK" Then



                    Dim limite As Integer
                    limite = 200

                    For i As Integer = 17 To 200
                        celda = "A" & i

                        'Try
                        conn.Open(cnStr)

                        Dim samples, idlab, aulab_ppb, pesogr, AuFinal_ppm, aulab_gt As String
                        samples = Convert.ToString(HojaExcel.Range("A" & i).Value)
                        idlab = Convert.ToString((HojaExcel.Range("B5").Value))
                        AuFinal_ppm = ""
                        'validacion para el campo Au_ppb
                        If Convert.ToString(HojaExcel.Range("B" & i).Value) = "--" Then
                            aulab_ppb = ""
                        ElseIf Convert.ToString(HojaExcel.Range("B" & i).Value) = "<0.02" Then
                            aulab_ppb = "0.02"

                        Else
                            aulab_ppb = CStr(Convert.ToDecimal(HojaExcel.Range("B" & i).Value) / 1000)
                            AuFinal_ppm = aulab_ppb
                        End If

                        'filtros de validacion para el camp au_Gt
                        If Convert.ToString(HojaExcel.Range("C" & i).Value) = "--" Then
                            aulab_gt = ""

                        ElseIf Convert.ToString(HojaExcel.Range("C" & i).Value) = "<0.03" Then
                            aulab_gt = "0.03"
                        End If

                        If Convert.ToString(HojaExcel.Range("C" & i).Value) = "<1" Then
                            aulab_gt = "<1"
                        Else
                            aulab_gt = Convert.ToString(HojaExcel.Range("C" & i).Value)
                            AuFinal_ppm = aulab_gt
                        End If


                        If Convert.ToString(HojaExcel.Range("D" & i).Value) = "--" Then
                            pesogr = ""
                        Else
                            pesogr = Convert.ToString(HojaExcel.Range("E" & i).Value)
                        End If
                        If (ValidaSiExiste(idlab, samples)) Then
                            cmd.CommandText = "UPDATE  PB_Assay  SET Au_Gt = '" & aulab_gt & "',  AuFinal_ppm= '" & AuFinal_ppm & "' , Peso_gr='" & pesogr & "' WHERE Jobno= '" & idlab & "'  and Muestra= '" & samples & "'  "
                        Else
                            cmd.CommandText = "INSERT INTO PB_Assay (Muestra,Jobno,Au_Ppm,Au_Gt,AuFinal_ppm, Peso_gr)VALUES('" & samples & "','" & idlab & "','" & aulab_ppb & "', '" & aulab_gt & "'     ,'" & AuFinal_ppm & "', '" & pesogr & "')"

                        End If


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
                    LibroExcel.Close()
                    AppExcel.Quit()
                    Exit Sub
                    'Else
                    'MessageBox.Show("La orden de Envio o remision del archivo, no existe en la base de datos.")



                End If
                au_ppb = "NO"
                au_gtm = "NO"
                ag_ppm = "NO"









                'If CStr(HojaExcel.Range("B12").Value) = "Au" And CStr(HojaExcel.Range("B13").Value) = "PPB" Then
                'au_ppb = "OK"
                ' End If
                If CStr(HojaExcel.Range("B14").Value) = "FAG303" Then
                    au_gtm = "OK"
                End If

                If CStr(HojaExcel.Range("C14").Value) = "PMI_CH" Then
                    ag_ppm = "OK"
                End If



                'primer tipo de remision
                If au_gtm = "OK" And ag_ppm = "OK" Then



                    Dim limite As Integer
                    limite = 200

                    For i As Integer = 17 To 200
                        celda = "A" & i

                        'Try
                        conn.Open(cnStr)

                        Dim samples, idlab, pesogr, AuFinal_ppm, aulab_gt As String
                        samples = Convert.ToString(HojaExcel.Range("A" & i).Value)
                        idlab = Convert.ToString((HojaExcel.Range("B5").Value))
                        AuFinal_ppm = ""
                        'validacion para el campo Au_ppb



                        If Convert.ToString(HojaExcel.Range("B" & i).Value) = "--" Then
                            aulab_gt = ""

                        ElseIf Convert.ToString(HojaExcel.Range("B" & i).Value) = "<0.03" Then
                            aulab_gt = "0.03"
                        ElseIf Convert.ToString(HojaExcel.Range("B" & i).Value) = "<3" Then
                            aulab_gt = "0.03"
                        Else
                            aulab_gt = Convert.ToString(HojaExcel.Range("B" & i).Value)
                            AuFinal_ppm = aulab_gt
                        End If


                        If Convert.ToString(HojaExcel.Range("C" & i).Value) = "--" Then
                            pesogr = ""
                        Else
                            pesogr = Convert.ToString(HojaExcel.Range("C" & i).Value)
                        End If

                        If (ValidaSiExiste(idlab, samples)) Then
                            cmd.CommandText = "UPDATE  PB_Assay  SET Au_Gt = '" & aulab_gt & "',  AuFinal_ppm= '" & AuFinal_ppm & "' , Peso_gr='" & pesogr & "' WHERE Jobno= '" & idlab & "'  and Muestra= '" & samples & "'  "

                        Else
                            cmd.CommandText = "INSERT INTO PB_Assay (Muestra,Jobno,Au_Gt,AuFinal_ppm, Peso_gr)VALUES('" & samples & "','" & idlab & "',     '" & aulab_gt & "'      ,'" & AuFinal_ppm & "', '" & pesogr & "')"
                        End If



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
                    LibroExcel.Close()
                    AppExcel.Quit()
                    Exit Sub
                    'Else
                    'MessageBox.Show("La orden de Envio o remision del archivo, no existe en la base de datos.")



                End If
                au_ppb = "NO"
                au_gtm = "NO"
                ag_ppm = "NO"

























                If CStr(HojaExcel.Range("B12").Value) = "Au" And CStr(HojaExcel.Range("B13").Value) = "G/TM" Then
                    au_gtm = "OK"
                End If
                If CStr(HojaExcel.Range("C12").Value) = "Ag" And CStr(HojaExcel.Range("C13").Value) = "PPM" Then
                    ag_ppm = "OK"
                End If

                'segundo tipo de remision
                If au_gtm = "OK" And ag_ppm = "OK" Then




                    Dim limite As Integer
                    limite = 200

                    For i As Integer = 17 To 200
                        celda = "A" & i

                        'Try
                        conn.Open(cnStr)

                        Dim samples, idlab, aulab_gt, Aglab_ppm, pesogr, AuFinal_ppm As String
                        samples = Convert.ToString(HojaExcel.Range("A" & i).Value)
                        idlab = Convert.ToString((HojaExcel.Range("B5").Value))
                        AuFinal_ppm = ""


                        'filtros de validacion para el camp au_Gt
                        If Convert.ToString(HojaExcel.Range("B" & i).Value) = "--" Then
                            aulab_gt = ""

                        Else
                            aulab_gt = Convert.ToString(HojaExcel.Range("B" & i).Value)
                            AuFinal_ppm = aulab_gt
                        End If
                        If Convert.ToString((HojaExcel.Range("C" & i)).Value) = "--" Then
                            Aglab_ppm = ""
                        Else
                            Aglab_ppm = Convert.ToString((HojaExcel.Range("C" & i)).Value)
                        End If

                        If Convert.ToString(HojaExcel.Range("D" & i).Value) = "--" Then
                            pesogr = ""
                        Else
                            pesogr = Convert.ToString(HojaExcel.Range("D" & i).Value)
                        End If
                        cmd.CommandText = "INSERT INTO PB_Assay (Muestra,Jobno,Au_Gt,AuFinal_ppm, Ag_Ppm,Peso_gr)VALUES('" & samples & "','" & idlab & "','" & aulab_gt & "','" & AuFinal_ppm & "','" & Aglab_ppm & "', '" & pesogr & "')"
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
                    LibroExcel.Close()
                    AppExcel.Quit()
                    Exit Sub

                End If
            End If
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
    Private Function ValidaSiExiste(ByVal ID As String, ByVal Muestra As String) As Boolean
        Try
            ' Dim Resultado As Boolean
            Using cnn As New SqlConnection(ConfigurationManager.AppSettings("StringConexion").ToString)
                Dim sqlbuscar As String = String.Format("SELECT COUNT(*) FROM PB_Assay WHERE Jobno = @Jobno and Muestra = @Muestra")
                Dim cmd As New SqlCommand(sqlbuscar, cnn)
                cmd.Parameters.AddWithValue("@Jobno", ID)
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
    Private Sub FrmAssayMineralPlant_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class