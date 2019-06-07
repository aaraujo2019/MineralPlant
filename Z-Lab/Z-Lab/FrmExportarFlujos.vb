Imports System.Windows.Forms
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration

Public Class FrmExportarFlujos
    Dim Cn As New SqlConnection(ConfigurationManager.AppSettings("StringConexion").ToString)
    Private dt As DataTable
    Dim Da As New SqlDataAdapter
    Dim Cmd As New SqlCommand
    Dim Dataset As DataSet
    Dim cnStr As String
    Dim rsarea As New ADODB.Recordset()
    Dim conn As New ADODB.Connection()

    Private Sub exportarsolidos()
        Dim totaltoneladas As Double
        Dim totalgramos As Double
        Dim conn As New ADODB.Connection()
        Dim RstResumen As New ADODB.Recordset()
        Dim RstResumenTenor As New ADODB.Recordset()
        Dim cnStr As String
        cnStr = ConfigurationManager.AppSettings("StringConexionODBC").ToString
        conn.Open(cnStr)
        Dim objExcel As Microsoft.Office.Interop.Excel.Application
        objExcel = New Microsoft.Office.Interop.Excel.Application
        Dim hoja As Microsoft.Office.Interop.Excel.Worksheet
        objExcel.Workbooks.Open("\\athenea\pampaverde\MINERIA\Data\DataBase\Templates\GZC_ReportFlujos.xlsx")
        Dim recorrido As Integer
        recorrido = 2
        totaltoneladas = 0
        totalgramos = 0
        objExcel.Visible = False
        If CmbUbicacionflujo.Text = "ESPESADOR4" Then
            RstResumen = conn.Execute(" SELECT Fecha, Turno, ToneladasTurno, PromedioDensidad, PromedioGravedad FROM  dbo.Pb_ConcentradoFlotacion where     (Fecha >= '" & CDate(DtFechainicio.Text) & "') AND (Fecha <= '" & CDate(DtFechaFinal.Text) & "')  ORDER BY Fecha ")
            RstResumenTenor = conn.Execute(" SELECT     Fecha, Turno, AuFinal_ppm FROM         dbo.Pb_ConcentradoFlotacionTenor where     (Fecha >= '" & CDate(DtFechainicio.Text) & "') AND (Fecha <= '" & CDate(DtFechaFinal.Text) & "')  ORDER BY Fecha ")
        ElseIf CmbUbicacionflujo.Text = "ESPESADOR5" Then
            RstResumen = conn.Execute(" SELECT Fecha, Turno, ToneladasTurno, PromedioDensidad, PromedioGravedad FROM  dbo.Pb_ConcentradoEsp5 where     (Fecha >= '" & CDate(DtFechainicio.Text) & "') AND (Fecha <= '" & CDate(DtFechaFinal.Text) & "')  ORDER BY Fecha ")
            RstResumenTenor = conn.Execute(" SELECT     Fecha, Turno, AuFinal_ppm FROM         dbo.PB_ColasESp5SolidoTenor where     (Fecha >= '" & CDate(DtFechainicio.Text) & "') AND (Fecha <= '" & CDate(DtFechaFinal.Text) & "')  ORDER BY Fecha ")
        ElseIf CmbUbicacionflujo.Text = "AGITADOR1" Then
            RstResumen = conn.Execute(" SELECT Fecha, Turno, ToneladasTurno, PromedioDensidad, PromedioGravedad FROM  dbo.Pb_ConcentradoAAG1 where     (Fecha >= '" & CDate(DtFechainicio.Text) & "') AND (Fecha <= '" & CDate(DtFechaFinal.Text) & "')  ORDER BY Fecha ")
            RstResumenTenor = conn.Execute(" SELECT     Fecha, Turno, AuFinal_ppm FROM         dbo.Pb_AlimentoAG1Solido where     (Fecha >= '" & CDate(DtFechainicio.Text) & "') AND (Fecha <= '" & CDate(DtFechaFinal.Text) & "')  ORDER BY Fecha ")
        End If

        'RstResumen = conn.Execute("SELECT     TOP (100) PERCENT dbo.PB_MerrilCrowe.Fecha, SUM(dbo.PB_MerrilCrowe.Volumen) AS VolumenTotal, SUM(dbo.PB_MerrilCrowe.Onzas) AS OnzasTotal,  AVG(dbo.PB_MerrilCrowe.TenorCabeza) AS TenorPromedio, AVG(dbo.PB_MerrilCrowe.TenorCola) AS TenorColas FROM         dbo.PB_MerrilCrowe INNER JOIN     dbo.RfTime ON dbo.PB_MerrilCrowe.HoraInicial = dbo.RfTime.Hora GROUP BY dbo.PB_MerrilCrowe.Fecha    HAVING        (Fecha >= '" & CDate(DtFechainicio.Text) & "') AND (Fecha <= '" & CDate(DtFechaFinal.Text) & "')")
        With objExcel
            hoja = CType(.Sheets("Flujos"), Microsoft.Office.Interop.Excel.Worksheet)
            'hoja.Cells(1, 3) = RstResumen.Fields("Ubicacion").Value
            Do While Not RstResumen.EOF
                hoja.Cells(recorrido, 1) = RstResumen.Fields("Fecha").Value
                hoja.Cells(recorrido, 2) = RstResumen.Fields("Turno").Value
                hoja.Cells(recorrido, 3) = RstResumen.Fields("ToneladasTurno").Value
                hoja.Cells(recorrido, 4) = RstResumen.Fields("PromedioDensidad").Value
                hoja.Cells(recorrido, 5) = RstResumen.Fields("PromedioGravedad").Value
                recorrido = recorrido + 1
                RstResumen.MoveNext()
            Loop

            recorrido = 2
            hoja = CType(.Sheets("Tenor"), Microsoft.Office.Interop.Excel.Worksheet)
            Do While Not RstResumenTenor.EOF
                hoja.Cells(recorrido, 1) = RstResumenTenor.Fields("Fecha").Value
                hoja.Cells(recorrido, 2) = RstResumenTenor.Fields("Turno").Value
                hoja.Cells(recorrido, 3) = RstResumenTenor.Fields("AuFinal_ppm").Value
                recorrido = recorrido + 1
                RstResumenTenor.MoveNext()
            Loop




            recorrido = 5
            hoja = CType(.Sheets("Resumen"), Microsoft.Office.Interop.Excel.Worksheet)
            Dim fecha1, fecha2 As Date
            fecha1 = DtFechainicio.Value
            fecha2 = DtFechaFinal.Value

            Do While fecha1 <= fecha2

                hoja.Cells(recorrido, 1) = fecha1

                recorrido = recorrido + 1

                fecha1 = fecha1.AddDays(1)
                'fecha2 = fecha1.AddDays(1)

            Loop




            'LblExport.Visible = False
            objExcel.Visible = True
        End With

        conn.Close()


    End Sub


    Private Sub picturebox1_enfoque(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.MouseHover
        PictureBox1.BorderStyle = BorderStyle.FixedSingle
    End Sub
    Private Sub picturebox1_quitarenfoque(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.MouseLeave
        PictureBox1.BorderStyle = BorderStyle.None
    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click
        exportarsolidos()
    End Sub
End Class