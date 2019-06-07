Option Explicit On
Option Strict On
Imports System.Data
Imports System.Data.SqlClient
Imports Z_Lab.FrmPrincipal
Imports System.Windows.Forms
Public Class FrmReporDensidad
    Dim Cn As New SqlConnection("Server=mercurio\gcg;uid=sa;pwd=BdZandor123*;database=PlantaBeneficio")
    Private dt As DataTable
    Dim Da As New SqlDataAdapter
    Dim Cmd As New SqlCommand
    Dim Dataset As DataSet
    Dim cnStr As String
    Dim rsarea As New ADODB.Recordset()
    Dim conn As New ADODB.Connection()
    Private Sub FrmReporDensidad_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.LblUsuario.Text = FrmPrincipal.LblUserName.Text
    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click
        Dim conn As New ADODB.Connection()
        Dim RstResumen As New ADODB.Recordset()
        Dim cnStr As String
        cnStr = "Provider=SQLNCLI10;Initial Catalog=PlantaBeneficio;Data Source=mercurio; User ID=sa;Password=BdZandor123*;"

        conn.Open(cnStr)
        RstResumen = conn.Execute(" SELECT     Fecha, HoraInicio, Densidad, Ubicacion FROM         dbo.PB_Flows  INNER JOIN RfFlows ON PB_Flows.Ubicacion = RfFlows.Name  where    (Tipo >= '" & (CmbUbicacion.Text) & "') AND  (Fecha >= '" & CDate(DtFechainicio.Text) & "') AND (Fecha <= '" & CDate(DtFechaFinal.Text) & "')  ORDER BY Fecha, Ubicacion ")
        'mensaje de exportacion mientras se ejecuta el codigo
        '  LblExport.Visible = True
        Try
            Dim objExcel As Microsoft.Office.Interop.Excel.Application
            objExcel = New Microsoft.Office.Interop.Excel.Application
            Dim hoja As Microsoft.Office.Interop.Excel.Worksheet
            objExcel.Workbooks.Open("\\athenea\pampaverde\MINERIA\Data\DataBase\Templates\ReporteDensidadLaboratorioMetalurgico3.xlsx")
            With objExcel
                'hoja = CType(.Sheets("datos"), Microsoft.Office.Interop.Excel.Worksheet)
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
        Catch ex As Exception
            ' Handle the exception.
            MessageBox.Show(ex.Message, Me.Text, _
  MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub CmbProyecto_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbProyecto.SelectedIndexChanged

    End Sub
    Private Sub cargararea()
        cnStr = "Provider=SQLNCLI10;Initial Catalog=PlantaBeneficio;Data Source=mercurio; User ID=sa;Password=BdZandor123*;"
        conn.Open(cnStr)
        rsarea = conn.Execute(" SELECT * FROM         usuario WHERE (IdUsusario = '" & (LblUsuario.Text) & "')         ")
        If rsarea.EOF = True Then
            Me.LblArea.Text = "NO"
        Else
            Me.LblArea.Text = CStr((rsarea.Fields("Area").Value))
            '    CargarUbicacion()
        End If
        conn.Close()
    End Sub



End Class