Option Explicit On
Option Strict On
Imports System.Windows.Forms

Imports System.Data.OleDb
Imports Microsoft.Office.Interop

Imports MySql.Data.MySqlClient
Imports System.Data.SqlClient
Public Class FrmImportarSinExcel
    Dim MysqlConn As MySqlConnection
    Friend conexion As MySqlConnection
    Dim nombreHoja As String
    Dim conn As New ADODB.Connection()
    Dim rstlab As New ADODB.Recordset()

    Dim Cn As New SqlConnection("Server=mercurio\gcg;uid=sa;pwd=BdZandor123*;database=PlantaBeneficio")
    Dim rst As New ADODB.Recordset()
    Dim cnStr As String
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Cursor.Current = Cursors.WaitCursor
        Dim xDataSet As DataSet = Nothing
        'xDataSet = DirectCast(DataGridView1.DataSource, DataSet)
        xDataSet = CType(DataGridView1.DataSource, DataSet)
        DataTableToExcel(xDataSet.Tables(0), "C:\Users\juan.palacio\Downloads\Agitadores Agosto 10.xlsx")
        Cursor.Current = Cursors.Default
    End Sub
    Public Sub DataTableToExcel(ByVal pDataTable As DataTable, ByVal xRuta As String)
        If (DataGridView1 Is Nothing) Then
            Return
            FileOpen(1, xRuta, OpenMode.Output)

            Dim sb As String = ""
            Dim dc As DataColumn
            For Each dc In pDataTable.Columns
                sb &= Trim(dc.Caption) & Microsoft.VisualBasic.ControlChars.Tab
            Next
            PrintLine(1, sb)

            Dim i As Integer = 0
            Dim dr As DataRow
            For Each dr In pDataTable.Rows
                i = 0 : sb = ""
                For Each dc In pDataTable.Columns
                    If Not IsDBNull(dr(i)) Then
                        If IsDate(dr(i)) Then
                            sb &= Replace(Convert.ToString(Microsoft.VisualBasic.Format(dr(i), "dd/MM/yyyy")), Microsoft.VisualBasic.ControlChars.CrLf, "") & Microsoft.VisualBasic.ControlChars.Tab
                        Else
                            sb &= Replace(Trim(CStr(dr(i))), Microsoft.VisualBasic.ControlChars.CrLf, "") & Microsoft.VisualBasic.ControlChars.Tab
                        End If
                    Else
                        sb &= Microsoft.VisualBasic.ControlChars.Tab
                    End If
                    i += 1
                Next

                PrintLine(1, sb)
            Next
            FileClose(1)

            'Dim vCultura As System.Globalization.CultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture        
            'System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.CreateSpecificCulture("es-SV")

            'Dim p As System.Diagnostics.Process = New System.Diagnostics.Process
            'p.EnableRaisingEvents = False
            'p.Start("Excel.exe", xRuta)

            'System.Threading.Thread.CurrentThread.CurrentCulture = vCultura

        End If
    End Sub

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

    Private Sub CmdGuardarJobno_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdGuardarJobno.Click

    End Sub
End Class