
Option Explicit On
Option Strict On
Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.Office.Interop
Imports System.Data.OleDb
Imports System.Windows.Forms
Imports System.Configuration

Public Class FrmAssayLabZandor
    Dim nombreHoja As String
    Dim conn As New ADODB.Connection()
    Dim rstlab As New ADODB.Recordset()


    Dim rst As New ADODB.Recordset()
    Dim cnStr As String
    Dim Cn As New SqlConnection(ConfigurationManager.AppSettings("StringConexion").ToString)


    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click

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
            'wb.Close()
            ' wb = Nothing
            Return name
        Catch ex As Exception
            Throw

        Finally
            'If (Not app Is Nothing) Then _
            'app.Quit()
            'Runtime.InteropServices.Marshal.ReleaseComObject(app)
            'app = Nothing
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


    Private Sub cargarsolidos()
        Dim AppExcel As Excel.Application
        Dim LibroExcel As Excel.Workbook
        Dim HojaExcel As Excel.Worksheet
        Dim celda As String
        cnStr = "Provider=SQLNCLI10;Initial Catalog=PlantaBeneficio;Data Source=SEGSVRSQL01; User ID=sa;Password=*Bd6r4nC0l0mb1a*;"
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
            Dim idlab As String
            Dim turno, horainicio, horafinal As String
            turno = "00"
            horainicio = "00:00"
            horafinal = "00:00"

            idlab = (Convert.ToString(HojaExcel.Range("b6").Value))
            Dim limite As Integer
            limite = 200

            For i As Integer = 46 To 200
                celda = "A" & i
                conn.Open(cnStr)


                Dim Au_Ppm, Au_Gt, Au_final, muestra As String
                Au_Gt = ""
                muestra = CStr(HojaExcel.Range("a" & i).Value)
                If CStr(HojaExcel.Range("c" & i).Value) = "<0.2" Then
                    Au_Ppm = "0.2"
                Else
                    Au_Ppm = CStr(HojaExcel.Range("C" & i).Value)
                End If

                If CStr(HojaExcel.Range("d" & i).Value) = "" Then
                    Au_final = Au_Ppm
                Else
                    Au_Gt = CStr(HojaExcel.Range("D" & i).Value)
                    Au_final = Au_Gt
                End If

                If CStr(HojaExcel.Range("c" & i).Value) = "" Then
                    Exit Sub
                End If

                If (ValidaSiExiste(idlab, muestra)) Then
                    cmd.CommandText = "UPDATE  PB_Assay  SET Jobno = '" & idlab & "'   , Au_Ppm= '" & Au_Ppm & "' , Au_Gt= '" & Au_Gt & "' , AuFinal_ppm= '" & Au_final & "' WHERE Jobno= '" & idlab & "'  and muestra= '" & muestra & "'   "
                Else
                    cmd.CommandText = "INSERT INTO PB_Assay ( Jobno ,Au_Ppm , Au_Gt , AuFinal_ppm , muestra ) VALUES (  '" & idlab & "',  '" & Au_Ppm & "'  ,  '" & Au_Gt & "' ,'" & Au_final & "' ,'" & muestra & "'  )"
                End If
                cmd.Connection = sqlConnectiondb
                sqlConnectiondb.Open()
                cmd.ExecuteNonQuery()
                sqlConnectiondb.Close()
                conn.Close()





                If CStr(HojaExcel.Range("c" & i).Value) = "" Then
                    sqlConnectiondb.Close()
                    conn.Close()
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
            MessageBox.Show(ex.Message, Me.Text,
  MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If conn.State <> ConnectionState.Closed Then
                conn.Close()
            End If
        End Try
    End Sub


    Private Sub cargarsoluciones()
        Dim Fechamuestra As String
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

        cnStr = "Provider=SQLNCLI10;Initial Catalog=PlantaBeneficio;Data Source=SEGSVRSQL01; User ID=sa;Password=*Bd6r4nC0l0mb1a*;"

        'campos de tabla muestra
        Dim horainicio As String
        Dim horafinal As String
        'Dim fecha As Date
        Dim DUP As String
        Dim comments As String

        Dim ubicacion As String
        Dim tipomuestra As String
        horainicio = "07:00 a.m."
        horafinal = "07:00 a.m."
        ubicacion = "No location"
        tipomuestra = "Líquido"
        DUP = ""
        comments = ""
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
                Fechamuestra = CStr(HojaExcel.Range("B14").Value)

                If CStr(HojaExcel.Range("B12").Value) = "Ag" And CStr(HojaExcel.Range("B13").Value) = "MG/L" Then

                    ag_ppm = "OK"
                End If
                If CStr(HojaExcel.Range("B34").Value) = "Au" Then
                    au_ppb = "OK"
                End If


                If au_ppb = "OK" And CStr(HojaExcel.Range("A34").Value) = "Elemento" Then

                    ' verifica si el envio de la remision existe
                    Dim Ds As New DataSet
                    Dim DsP As New DataSet
                    Dim envio As String
                    envio = (CStr(HojaExcel.Range("B10").Value))
                    Dim Da As New SqlClient.SqlDataAdapter("SELECT * FROM PB_LabSumit  WHERE Orden ='" & envio & "'  ", Cn)
                    Da.Fill(Ds, "PB_LabSumit")
                    Dim myDataView As DataView = New DataView(Ds.Tables("PB_LabSumit"))
                    Dim limite As Integer
                    limite = 200
                    For i As Integer = 38 To 200
                        celda = "A" & i
                        conn.Open(cnStr)
                        Dim samples, idlab, aulab_ppb, Aglab_ppm, pesogr, AuFinal_ppm As String
                        samples = Replace(Convert.ToString(HojaExcel.Range("A" & i).Value), " ", "")
                        idlab = Convert.ToString((HojaExcel.Range("B10").Value))
                        AuFinal_ppm = ""
                        'validacion para el campo Au_ppb
                        If samples = "CM7-3" Then
                            horainicio = "07:00 a.m."
                            horafinal = "03:00 p.m."
                            ubicacion = "Cabeza Merril Crowe"
                        ElseIf samples = "CMC7-3" Then
                            horainicio = "07:00 a.m."
                            horafinal = "03:00 p.m."
                            ubicacion = "Colas Merril Crowe"
                        ElseIf samples = "CESP57-3" Then
                            horainicio = "07:00 a.m."
                            horafinal = "03:00 p.m."
                            ubicacion = "Colas Espesador 5"
                        ElseIf samples = "CM3-11" Then
                            horainicio = "03:00 p.m."
                            horafinal = "11:00 p.m."
                            ubicacion = "Cabeza Merril Crowe"
                        ElseIf samples = "CMC3-11" Then
                            horainicio = "03:00 p.m."
                            horafinal = "11:00 p.m."
                            ubicacion = "Colas Merril Crowe"
                        ElseIf samples = "CESP53-11" Then
                            horainicio = "03:00 p.m."
                            horafinal = "11:00 p.m."
                            ubicacion = "Colas Espesador 5"
                        ElseIf samples = "CM11-7" Then
                            horainicio = "11:00 p.m."
                            horafinal = "07:00 a.m."
                            ubicacion = "Cabeza Merril Crowe"
                        ElseIf samples = "CMC11-7" Then
                            horainicio = "11:00 p.m."
                            horafinal = "07:00 a.m."
                            ubicacion = "Colas Merril Crowe"
                        ElseIf samples = "CESP511-7" Then
                            horainicio = "11:00 p.m."
                            horafinal = "07:00 a.m."
                            ubicacion = "Colas Espesador 5"
                        ElseIf samples = "CAG-124H" Then
                            horainicio = "07:00 a.m."
                            horafinal = "07:00 a.m."
                            ubicacion = "Cabeza Agitadores 1"
                        ElseIf samples = "DAG-124H" Or samples = "DAG124H" Then
                            horainicio = "07:00 a.m."
                            horafinal = "07:00 a.m."
                            ubicacion = "Descarga Agitadores 1"
                        ElseIf samples = "CAG-224H" Or samples = "CAG224H" Then
                            horainicio = "07:00 a.m."
                            horafinal = "07:00 a.m."
                            ubicacion = "Cabeza Agitadores 2"

                        ElseIf samples = "CAG-324H" Or samples = "CAG324H" Then
                            horainicio = "07:00 a.m."
                            horafinal = "07:00 a.m."
                            ubicacion = "Cabeza Agitadores 3"
                        ElseIf samples = "DAG-324H" Or samples = "DAG324H" Then
                            horainicio = "07:00 a.m."
                            horafinal = "07:00 a.m."
                            ubicacion = "Descarga Agitadores 3"
                        ElseIf samples = "DAG24H" Or samples = "DAG-24H" Then
                            horainicio = "07:00 a.m."
                            horafinal = "07:00 a.m."
                            ubicacion = "Descarga Agitadores 1"
                        ElseIf samples = "DAG-224H" Or samples = "DAG224H" Then
                            horainicio = "07:00 a.m."
                            horafinal = "07:00 a.m."
                            ubicacion = "Descarga Agitadores 2"
                        ElseIf samples = "CAG24H" Or samples = "CAG-24H" Then
                            horainicio = "07:00 a.m."
                            horafinal = "07:00 a.m."
                            ubicacion = "Cabeza Agitadores 1"
                        ElseIf samples = "CAG-17-3" Then
                            horainicio = "07:00 a.m."
                            horafinal = "03:00 p.m."
                            ubicacion = "Cabeza Agitadores 1"
                        ElseIf samples = "CAG-13-11" Then
                            horainicio = "03:00 p.m."
                            horafinal = "11:00 p.m."
                            ubicacion = "Cabeza Agitadores 1"
                        ElseIf samples = "CAG-111-7" Then
                            horainicio = "11:00 p.m."
                            horafinal = "07:00 a.m."
                            ubicacion = "Cabeza Agitadores 1"

                        ElseIf samples = "CAG-27-3" Or samples = "CAG273" Then
                            horainicio = "07:00 a.m."
                            horafinal = "03:00 p.m."
                            ubicacion = "Cabeza Agitadores 2"
                        ElseIf samples = "CAG-23-11" Or samples = "CAG2311" Then
                            horainicio = "03:00 p.m."
                            horafinal = "11:00 p.m."
                            ubicacion = "Cabeza Agitadores 2"
                        ElseIf samples = "CAG-211-7" Or samples = "CAG2117" Then
                            horainicio = "11:00 p.m."
                            horafinal = "07:00 a.m."
                            ubicacion = "Cabeza Agitadores 2"



                        ElseIf samples = "DAG-37-3" Then
                            horainicio = "07:00 a.m."
                            horafinal = "03:00 p.m."
                            ubicacion = "Descarga Agitadores 3"
                        ElseIf samples = "DAG-33-11" Then
                            horainicio = "03:00 p.m."
                            horafinal = "11:00 p.m."
                            ubicacion = "Descarga Agitadores 3"
                        ElseIf samples = "DAG-311-7" Then
                            horainicio = "11:00 p.m."
                            horafinal = "07:00 a.m."
                            ubicacion = "Descarga Agitadores 3"

                        ElseIf samples = "DAG-47-3" Then
                            horainicio = "07:00 a.m."
                            horafinal = "03:00 p.m."
                            ubicacion = "Descarga Agitadores 4"
                        ElseIf samples = "DAG-43-11" Then
                            horainicio = "03:00 p.m."
                            horafinal = "11:00 p.m."
                            ubicacion = "Descarga Agitadores 4"
                        ElseIf samples = "DAG-411-7" Then
                            horainicio = "11:00 p.m."
                            horafinal = "07:00 a.m."
                            ubicacion = "Descarga Agitadores 4"

                        ElseIf samples = "" Then
                            ' MsgBox("Samples no")
                        End If
                        If samples = "" Or Replace(Convert.ToString(HojaExcel.Range("B" & i).Value), " ", "") = "---" Or Strings.Left(samples, 3) = "STD" Then

                        Else
                            cmd.CommandText = "INSERT INTO PB_Samples (Muestra,HoraInicial,HoraFinal,Fecha, Ubicacion,TipoMuestra ,Dup ,Comments)VALUES('" & samples + Fechamuestra & "','" & horainicio & "','" & horafinal & "','" & Fechamuestra & "','" & ubicacion & "', '" & tipomuestra & "','" & DUP & "','" & comments & "')"
                            'filtros de validacion para el camp au_Gt
                            cmd.Connection = sqlConnectiondb
                            sqlConnectiondb.Open()
                            cmd.ExecuteNonQuery()
                        End If

                        sqlConnectiondb.Close()
                        conn.Close()


                        Aglab_ppm = ""
                        pesogr = ""
                        aulab_ppb = Convert.ToString(HojaExcel.Range("B" & i).Value)
                        If Replace(Convert.ToString(HojaExcel.Range("B" & i).Value), " ", "") = "<0.01" Then
                            aulab_ppb = "0.01"

                        ElseIf Replace(Convert.ToString(HojaExcel.Range("B" & i).Value), " ", "") = "---" Then
                            aulab_ppb = ""

                        End If

                        AuFinal_ppm = aulab_ppb

                        conn.Open(cnStr)
                        cmd.CommandText = "INSERT INTO PB_Assay (Muestra,Jobno,Au_Ppm,AuFinal_ppm, Ag_Ppm,Peso_gr)VALUES('" & samples + Fechamuestra & "','" & idlab & "','" & aulab_ppb & "','" & AuFinal_ppm & "','" & Aglab_ppm & "', '" & pesogr & "')"



                        If CStr(HojaExcel.Range("A" & i).Value) = "" Then
                            sqlConnectiondb.Close()
                            conn.Close()
                            MsgBox("Importacion Finalizada")

                            'LibroExcel.Close()
                            AppExcel.Quit()
                            AppExcel = Nothing
                            LibroExcel = Nothing
                            Exit For

                        End If
                        cmd.Connection = sqlConnectiondb
                        sqlConnectiondb.Open()
                        cmd.ExecuteNonQuery()
                        sqlConnectiondb.Close()
                        conn.Close()
                    Next


                Else
                    MsgBox("Las columnas del archivo de Analisis no estan correctamente Ordenadas, por favor verifique")

                End If
            End If

        Catch ex As Exception
            ' Handle the exception.
            MessageBox.Show(ex.Message, Me.Text,
  MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If conn.State <> ConnectionState.Closed Then
                conn.Close()
            End If
        End Try

    End Sub
    Private Function ValidaSiExiste(ByVal Idlab As String, ByVal muestra As String) As Boolean
        Try

            Using cnn As New SqlConnection(ConfigurationManager.AppSettings("StringConexion").ToString)
                Dim sqlbuscar As String = String.Format("SELECT COUNT(*) FROM PB_Assay WHERE Jobno = @IdLab and muestra = @muestra  ")
                Dim cmd As New SqlCommand(sqlbuscar, cnn)
                cmd.Parameters.AddWithValue("@IdLab", Idlab)
                cmd.Parameters.AddWithValue("@muestra", muestra)
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
        If Cmbtipomuestra.Text = "Solución" Then
            cargarsoluciones()
            MsgBox("Finalizado")
        End If

        If Cmbtipomuestra.Text = "Sólido" Then
            cargarsolidos()
            MsgBox("Finalizado")
        End If

    End Sub

    Private Sub FrmAssayLabZandor_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class