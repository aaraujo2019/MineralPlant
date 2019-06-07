Imports Microsoft.Reporting.WinForms

Public Class FrmReporte

    Private Sub FrmReporte_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'PlantaBeneficioReporteOperacion.PB_Operation' table. You can move, or remove it, as needed.
        Me.PB_OperationTableAdapter.Fill(Me.PlantaBeneficioReporteOperacion.PB_Operation)
        'TODO: This line of code loads data into the 'PlantaBeneficioReporteOperacion.Amb_HorasDeOperacion' table. You can move, or remove it, as needed.
        Me.Amb_HorasDeOperacionTableAdapter.Fill(Me.PlantaBeneficioReporteOperacion.Amb_HorasDeOperacion)
        'TODO: This line of code loads data into the 'PlantaBeneficioReporteOperacion.Pb_FlowsColasBulk' table. You can move, or remove it, as needed.
        ' Me.Pb_FlowsColasBulkTableAdapter.Fill(Me.PlantaBeneficioReporteOperacion.Pb_FlowsColasBulk)
        'TODO: This line of code loads data into the 'PlantaBeneficioReporteOperacion.PB_Conveyor' table. You can move, or remove it, as needed.
        Me.PB_ConveyorTableAdapter.Fill(Me.PlantaBeneficioReporteOperacion.PB_Conveyor)
        'TODO: This line of code loads data into the 'PlantaBeneficioReporteOperacion.PB_Conveyor' table. You can move, or remove it, as needed.
        ' Me.PB_ConveyorTableAdapter.Fill(Me.PlantaBeneficioReporteOperacion.PB_Conveyor)
        'Me.PB_ConveyorTableAdapter.FillBy(Me.PlantaBeneficioReporteOperacion.PB_Conveyor, FrmMineralPlant.TxtTonZandor.Text)
        Dim p(0) As ReportParameter

        p(0) = New ReportParameter("Fecha", CDate(FrmMineralPlant.LblFechaReporte.Text))
        ReportViewer1.LocalReport.SetParameters(p)



        Me.ReportViewer1.RefreshReport()
        Me.ReportViewer1.RefreshReport()
    End Sub
End Class