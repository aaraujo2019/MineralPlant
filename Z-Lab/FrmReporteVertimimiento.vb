Imports System.Windows.Forms
Imports System.Data
Imports System.Data.SqlClient
Public Class FrmReporteVertimimiento

    Private Sub FrmReporteVertimimiento_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click
        Dim fechainicio As Date
        Dim fechafin As Date
        fechainicio = CDate(DtInicioFl.Value)
        fechafin = CDate(DtFinalFl.Value)
        Dim dias As Double
        dias = (DtFinalFl.Value - DtInicioFl.Value).TotalDays
        If dias > 31 Then
            MsgBox("Por Favor Seleccione un rango de Fecha no superior a 30 dias.")
            Exit Sub

        End If
        ExportarVertimiento()
    End Sub
    Private Sub ExportarVertimiento()
        Dim conn As New ADODB.Connection()
        Dim RstResumen As New ADODB.Recordset()
        Dim RstResumenTenor As New ADODB.Recordset()

        Dim cnStr As String
        cnStr = "Provider=SQLNCLI10;Initial Catalog=PlantaBeneficio;Data Source=SEGSVRSQL01; User ID=sa;Password=*Bd6r4nC0l0mb1a*;"
        conn.Open(cnStr)
        Dim objExcel As Microsoft.Office.Interop.Excel.Application
        objExcel = New Microsoft.Office.Interop.Excel.Application
        Dim hoja As Microsoft.Office.Interop.Excel.Worksheet
        objExcel.Workbooks.Open("\\athenea\pampaverde\mineria\Data\DataBase\Templates\ResumenPorcentajedeVertimiento.xlsx")
        Dim recorrido As Integer


        recorrido = 2
        objExcel.Visible = False
        RstResumen = conn.Execute(" SELECT TOP (100) PERCENT Fecha, SUM(HorasOperacion) AS HorasOperacion, SUM(HorasVertimiento) AS HorasVertimiento, SUM(TonsTurno) AS ToneladasFlujometro, SUM(ToneladasVertidas)  AS ToneladasVertidas  FROM    dbo.Pb_FlowsE5   GROUP BY Fecha  Having     (Fecha >= '" & CDate(DtInicioFl.Text) & "') AND (Fecha <= '" & CDate(DtFinalFl.Text) & "')  ORDER BY Fecha ")
        With objExcel
            'concentrado de flotacion
            hoja = CType(.Sheets("Lixiviacion"), Microsoft.Office.Interop.Excel.Worksheet)
            'hoja.Cells(1, 3) = RstResumen.Fields("Ubicacion").Value
            Do While Not RstResumen.EOF

                hoja.Cells(recorrido, 1) = RstResumen.Fields("Fecha").Value
                hoja.Cells(recorrido, 2) = RstResumen.Fields("ToneladasFlujometro").Value
                hoja.Cells(recorrido, 3) = RstResumen.Fields("HorasOperacion").Value
                hoja.Cells(recorrido, 4) = RstResumen.Fields("HorasVertimiento").Value
                hoja.Cells(recorrido, 5) = RstResumen.Fields("ToneladasVertidas").Value
                'hoja.Cells(recorrido, 6) = RstResumen.Fields("ToneladasVertidas").Value
                recorrido = recorrido + 1
                RstResumen.MoveNext()
            Loop

            recorrido = 2
            objExcel.Visible = False
            RstResumen = conn.Execute(" SELECT TOP (100) PERCENT Fecha, SUM(HorasOperacion) AS HorasOperacion, SUM(HorasVertimiento) AS HorasVertimiento, SUM(TonsTurno) AS ToneladasFlujometro, SUM(ToneladasVertidas)  AS ToneladasVertidas  FROM    dbo.Pb_FlowsColasBulk   GROUP BY Fecha  Having     (Fecha >= '" & CDate(DtInicioFl.Text) & "') AND (Fecha <= '" & CDate(DtFinalFl.Text) & "')  ORDER BY Fecha ")

            'concentrado de flotacion
            hoja = CType(.Sheets("Flotacion"), Microsoft.Office.Interop.Excel.Worksheet)
            'hoja.Cells(1, 3) = RstResumen.Fields("Ubicacion").Value
            Do While Not RstResumen.EOF
                hoja.Cells(recorrido, 1) = RstResumen.Fields("Fecha").Value
                hoja.Cells(recorrido, 2) = RstResumen.Fields("ToneladasFlujometro").Value
                hoja.Cells(recorrido, 3) = RstResumen.Fields("HorasOperacion").Value
                hoja.Cells(recorrido, 4) = RstResumen.Fields("HorasVertimiento").Value
                hoja.Cells(recorrido, 5) = RstResumen.Fields("ToneladasVertidas").Value
                'hoja.Cells(recorrido, 6) = RstResumen.Fields("ToneladasVertidas").Value

                recorrido = recorrido + 1
                RstResumen.MoveNext()
            Loop



            recorrido = 2
            objExcel.Visible = False
            RstResumen = conn.Execute("SELECT TOP (100) PERCENT Fecha , SUM(TonSeca) AS TotalTonseca  FROM    dbo.PB_Conveyor   GROUP BY Fecha  Having     (Fecha >= '" & CDate(DtInicioFl.Text) & "') AND (Fecha <= '" & CDate(DtFinalFl.Text) & "')  ORDER BY Fecha ")
            'concentrado de flotacion
            hoja = CType(.Sheets("Pesometro"), Microsoft.Office.Interop.Excel.Worksheet)
            'hoja.Cells(1, 3) = RstResumen.Fields("Ubicacion").Value
            Do While Not RstResumen.EOF
                hoja.Cells(recorrido, 1) = RstResumen.Fields("Fecha").Value
                hoja.Cells(recorrido, 2) = RstResumen.Fields("TotalTonseca").Value
                recorrido = recorrido + 1
                RstResumen.MoveNext()
            Loop



            recorrido = 4
            hoja = CType(.Sheets("Resumen_Vertimiento"), Microsoft.Office.Interop.Excel.Worksheet)
            Dim fecha1, fecha2 As Date
            fecha1 = DtInicioFl.Value
            fecha2 = DtFinalFl.Value
            Do While fecha1 <= fecha2
                hoja.Cells(recorrido, 2) = fecha1
                recorrido = recorrido + 1
                fecha1 = fecha1.AddDays(1)
                'fecha2 = fecha1.AddDays(1)
            Loop

        End With
        objExcel.Visible = True
        conn.Close()
    End Sub
End Class