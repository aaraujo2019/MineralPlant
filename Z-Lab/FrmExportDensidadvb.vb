Option Explicit On
Option Strict On
Imports System.Data
Imports System.Data.SqlClient
Imports Z_Lab.FrmPrincipal
Imports System.Windows.Forms
Imports System.Configuration

Public Class FrmExportDensidadvb
    Dim Cn As New SqlConnection(ConfigurationManager.AppSettings("StringConexion").ToString)
    Private dt As DataTable
    Dim Da As New SqlDataAdapter
    Dim Cmd As New SqlCommand
    Dim Dataset As DataSet
    Dim cnStr As String
    Dim rsarea As New ADODB.Recordset()
    Dim conn As New ADODB.Connection()
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim conn As New ADODB.Connection()
        Dim RstResumen As New ADODB.Recordset()
        Dim cnStr As String
        cnStr = "Provider=SQLNCLI10;Initial Catalog=PlantaBeneficio;Data Source=SEGSVRSQL01; User ID=sa;Password=*Bd6r4nC0l0mb1a*;"

        conn.Open(cnStr)
        RstResumen = conn.Execute(" SELECT     Fecha, HoraInicio, Densidad, Ubicacion FROM         dbo.PB_Flows  INNER JOIN RfFlows ON PB_Flows.Ubicacion = RfFlows.Name  where      (Fecha >= '" & CDate(DtFechainicio.Text) & "') AND (Fecha <= '" & CDate(DTFechaFinal.Text) & "')  ORDER BY Fecha, Ubicacion ")
        'mensaje de exportacion mientras se ejecuta el codigo
        '  LblExport.Visible = True
        Try
            Dim objExcel As Microsoft.Office.Interop.Excel.Application
            objExcel = New Microsoft.Office.Interop.Excel.Application
            Dim hoja As Microsoft.Office.Interop.Excel.Worksheet
            objExcel.Workbooks.Open("\\athenea\pampaverde\MINERIA\Data\DataBase\Templates\ReporteDensidadLaboratorioMetalurgico2.xlsx")
            lblexport.Visible = True

            With objExcel
                hoja = CType(.Sheets("DatosDensidad"), Microsoft.Office.Interop.Excel.Worksheet)
                'hoja.Cells(3, 4) = DateTimePickerFechaReporte.Value
                Dim recorrido As Integer
                ' la variable recorrido indica la fila en la hoja excel.
                recorrido = 2
                objExcel.Visible = False

                Do While Not RstResumen.EOF
                    hoja.Cells(recorrido, 1) = RstResumen.Fields("Fecha").Value
                    hoja.Cells(recorrido, 2) = RstResumen.Fields("Ubicacion").Value
                    hoja.Cells(recorrido, 3) = RstResumen.Fields("HoraInicio").Value
                    hoja.Cells(recorrido, 4) = RstResumen.Fields("Densidad").Value
                    recorrido = recorrido + 1
                    RstResumen.MoveNext()
                Loop
                'LblExport.Visible = False
                objExcel.Visible = True
            End With
            lblexport.Visible = False
        Catch ex As Exception
            ' Handle the exception.
            MessageBox.Show(ex.Message, Me.Text,
  MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
End Class