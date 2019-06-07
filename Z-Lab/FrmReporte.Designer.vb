<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmReporte
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim ReportDataSource1 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Dim ReportDataSource2 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Dim ReportDataSource3 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.PlantaBeneficioReporteOperacion = New Z_Lab.PlantaBeneficioReporteOperacion()
        Me.PB_OperationBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.PB_OperationTableAdapter = New Z_Lab.PlantaBeneficioReporteOperacionTableAdapters.PB_OperationTableAdapter()
        Me.PB_ConveyorBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.PB_ConveyorTableAdapter = New Z_Lab.PlantaBeneficioReporteOperacionTableAdapters.PB_ConveyorTableAdapter()
        Me.Amb_HorasDeOperacionBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Amb_HorasDeOperacionTableAdapter = New Z_Lab.PlantaBeneficioReporteOperacionTableAdapters.Amb_HorasDeOperacionTableAdapter()
        CType(Me.PlantaBeneficioReporteOperacion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PB_OperationBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PB_ConveyorBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Amb_HorasDeOperacionBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "DataSetOperation"
        ReportDataSource1.Value = Me.PB_OperationBindingSource
        ReportDataSource2.Name = "DataSet1"
        ReportDataSource2.Value = Me.PB_ConveyorBindingSource
        ReportDataSource3.Name = "DataSetUtilizacionPlanta"
        ReportDataSource3.Value = Me.Amb_HorasDeOperacionBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource2)
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource3)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "Z_Lab.ReporteOperacionDia.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(1137, 573)
        Me.ReportViewer1.TabIndex = 0
        '
        'PlantaBeneficioReporteOperacion
        '
        Me.PlantaBeneficioReporteOperacion.DataSetName = "PlantaBeneficioReporteOperacion"
        Me.PlantaBeneficioReporteOperacion.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'PB_OperationBindingSource
        '
        Me.PB_OperationBindingSource.DataMember = "PB_Operation"
        Me.PB_OperationBindingSource.DataSource = Me.PlantaBeneficioReporteOperacion
        '
        'PB_OperationTableAdapter
        '
        Me.PB_OperationTableAdapter.ClearBeforeFill = True
        '
        'PB_ConveyorBindingSource
        '
        Me.PB_ConveyorBindingSource.DataMember = "PB_Conveyor"
        Me.PB_ConveyorBindingSource.DataSource = Me.PlantaBeneficioReporteOperacion
        '
        'PB_ConveyorTableAdapter
        '
        Me.PB_ConveyorTableAdapter.ClearBeforeFill = True
        '
        'Amb_HorasDeOperacionBindingSource
        '
        Me.Amb_HorasDeOperacionBindingSource.DataMember = "Amb_HorasDeOperacion"
        Me.Amb_HorasDeOperacionBindingSource.DataSource = Me.PlantaBeneficioReporteOperacion
        '
        'Amb_HorasDeOperacionTableAdapter
        '
        Me.Amb_HorasDeOperacionTableAdapter.ClearBeforeFill = True
        '
        'FrmReporte
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1137, 573)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Name = "FrmReporte"
        Me.Text = "FrmReporte"
        CType(Me.PlantaBeneficioReporteOperacion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PB_OperationBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PB_ConveyorBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Amb_HorasDeOperacionBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents PB_OperationBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents PlantaBeneficioReporteOperacion As Z_Lab.PlantaBeneficioReporteOperacion
    Friend WithEvents PB_ConveyorBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Amb_HorasDeOperacionBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents PB_OperationTableAdapter As Z_Lab.PlantaBeneficioReporteOperacionTableAdapters.PB_OperationTableAdapter
    Friend WithEvents PB_ConveyorTableAdapter As Z_Lab.PlantaBeneficioReporteOperacionTableAdapters.PB_ConveyorTableAdapter
    Friend WithEvents Amb_HorasDeOperacionTableAdapter As Z_Lab.PlantaBeneficioReporteOperacionTableAdapters.Amb_HorasDeOperacionTableAdapter
End Class
