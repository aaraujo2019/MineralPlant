Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
'Imports Excel = Microsoft.Office.Interop.Excel
Imports System.Windows.Forms
Imports System.Windows.Forms.DataVisualization.Charting
Imports System.Math
Imports System.Drawing
Imports System.Configuration

Public Class FrmGraficosBalanceMetalurgico
    Dim Da As New SqlDataAdapter
    Dim Cmd As New SqlCommand
    Dim Dataset As DataSet
    Public cadena As String = "Provider=SQLNCLI10;Initial Catalog=PlantaBeneficio;Data Source=SEGSVRSQL01; User ID=sa;Password=*Bd6r4nC0l0mb1a*;"
    Dim Cn As New SqlConnection(ConfigurationManager.AppSettings("StringConexion").ToString)
    Public dt As DataTable
    Dim Series1 As Series
    Dim Series2 As Series
    Dim Series3 As Series
    Dim Series4 As Series
    ' Edit Controls
    Private CursorX As System.Windows.Forms.TextBox
    Private CursorY As System.Windows.Forms.TextBox
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        '¡ CursorY.Text = "HOLA"

        'MessageBox.Show(CmbPeriodoFinal.SelectedValue.ToString)
        If Cmbubicacion.Text = "" Then
            MsgBox("por favor seleccione una opcion")
            Exit Sub
        End If
        Dim tblFields As String
        PbGrafico.DataSource = Nothing
        PbGrafico.Series.Clear()
        PbGrafico.ChartAreas.Clear()
        ' Dim tblFields As String = "SELECT        Sellos, Tenor,  (SELECT        STDEV(Tenor) AS Expr1 FROM            dbo.PB_Mineras AS PB_Mineras_1 where  (Fecha >= '" & CDate(DtFechaInicial.Text) & "') and (Fecha <= '" & CDate(DtFechaFinal.Text) & "') and (Mina = '" & (Cmbubicacion.Text) & "')   ) AS desviacion, (SELECT        AVG(Tenor) AS Expr1 FROM            dbo.PB_Mineras  AS PB_Mineras_2 where  (Fecha >= '" & CDate(DtFechaInicial.Text) & "') and (Fecha <= '" & CDate(DtFechaFinal.Text) & "') and (Mina = '" & (Cmbubicacion.Text) & "')) AS Media, Mina, CONVERT(VARCHAR, Fecha, 100) AS fecha,  (SELECT        STDEV(Tenor) AS Expr1  FROM            dbo.PB_Mineras AS PB_Mineras_1 where  (Fecha >= '" & CDate(DtFechaInicial.Text) & "') and (Fecha <= '" & CDate(DtFechaFinal.Text) & "') and (Mina = '" & (Cmbubicacion.Text) & "')) +  (SELECT        AVG(Tenor) AS Expr1 FROM            dbo.PB_Mineras AS PB_Mineras_2 where  (Fecha >= '" & CDate(DtFechaInicial.Text) & "') and (Fecha <= '" & CDate(DtFechaFinal.Text) & "') and (Mina = '" & (Cmbubicacion.Text) & "')) AS maximo,  (SELECT        AVG(Tenor) AS Expr1  FROM            dbo.PB_Mineras AS PB_Mineras_2 where  (Fecha >= '" & CDate(DtFechaInicial.Text) & "') and (Fecha <= '" & CDate(DtFechaFinal.Text) & "') and (Mina = '" & (Cmbubicacion.Text) & "')) - (SELECT        STDEV(Tenor) AS Expr1  FROM            dbo.PB_Mineras AS PB_Mineras_1 where  (Fecha >= '" & CDate(DtFechaInicial.Text) & "') and (Fecha <= '" & CDate(DtFechaFinal.Text) & "') and (Mina = '" & (Cmbubicacion.Text) & "')) AS minimo FROM            dbo.PB_Mineras AS PB_Mineras where  (Fecha >= '" & CDate(DtFechaInicial.Text) & "') and (Fecha <= '" & CDate(DtFechaFinal.Text) & "') and (Mina = '" & (Cmbubicacion.Text) & "')"
        If Cmbubicacion.Text = "Alimento_Onzas_Molino" Then
            '  tblFields = "SELECT        CONVERT(VARCHAR(11), fecha, 6) AS total , Fecha , tenor , (SELECT        STDEV(Tenor) AS Expr1  FROM            dbo.Gr_TenorPromedioB12 AS Pb_TenorPromedioB12_6  WHERE        (Fecha >= '" & CDate(DtFechaInicial.Text) & "') AND (Fecha <= '" & CDate(DtFechaFinal.Text) & "')) AS desviacion ,  (SELECT        AVG(Tenor) AS Expr1 FROM            dbo.Gr_TenorPromedioB12 AS Pb_TenorPromedioB12_3   WHERE        (Fecha >= '" & CDate(DtFechaInicial.Text) & "') AND (Fecha <= '" & CDate(DtFechaFinal.Text) & "')) as media ,   (SELECT        AVG(Tenor) AS Expr1 FROM            dbo.Gr_TenorPromedioB12 AS Pb_TenorPromedioB12_3   WHERE        (Fecha >= '" & CDate(DtFechaInicial.Text) & "') AND (Fecha <= '" & CDate(DtFechaFinal.Text) & "')) -  (SELECT        STDEV(Tenor) AS Expr1 FROM            dbo.Gr_TenorPromedioB12 AS Pb_TenorPromedioB12_2   WHERE        (Fecha >= '" & CDate(DtFechaInicial.Text) & "') AND (Fecha <= '" & CDate(DtFechaFinal.Text) & "')) AS minimo , (SELECT        AVG(Tenor) AS Expr1 FROM            dbo.Gr_TenorPromedioB12 AS Pb_TenorPromedioB12_3   WHERE        (Fecha >= '" & CDate(DtFechaInicial.Text) & "') AND (Fecha <= '" & CDate(DtFechaFinal.Text) & "')) +  (SELECT        STDEV(Tenor) AS Expr1 FROM            dbo.Gr_TenorPromedioB12 AS Pb_TenorPromedioB12_2   WHERE        (Fecha >= '" & CDate(DtFechaInicial.Text) & "') AND (Fecha <= '" & CDate(DtFechaFinal.Text) & "')) AS maximo FROM Gr_TenorPromedioB12  WHERE        (Fecha >= '" & CDate(DtFechaInicial.Text) & "') AND (Fecha <= '" & CDate(DtFechaFinal.Text) & "')  "
            tblFields = " SELECT        TOP (100) PERCENT IdPeriodos, OnzasAlimentadas FROM   dbo.Pb_BalanceFisicoGraficos WHERE        (OnzasAlimentadas IS NOT NULL) and FechaInicial >= '" & CDate(CmbPeriodoInicial.SelectedValue) & "' and FechaInicial <= '" & CDate(CmbPeriodoFinal.SelectedValue) & "'  ORDER BY FechaInicial   "
        ElseIf (Cmbubicacion.Text = "Toneladas_Procesadas") Then
            tblFields = " SELECT        TOP (100) PERCENT IdPeriodos, Toneladas FROM   dbo.Pb_BalanceFisicoGraficos WHERE        (toneladas IS NOT NULL) and FechaInicial >= '" & CDate(CmbPeriodoInicial.SelectedValue) & "' and FechaInicial <= '" & CDate(CmbPeriodoFinal.SelectedValue) & "' ORDER BY FechaInicial   "
            'tblFields = "SELECT        CONVERT(VARCHAR(11), fecha, 6) AS total , Fecha , tenor , (SELECT        STDEV(Tenor) AS Expr1  FROM            dbo.gr_MerrilCrowe AS Pb_TenorPromedioB12_6  WHERE        (Fecha >= '" & CDate(DtFechaInicial.Text) & "') AND (Fecha <= '" & CDate(DtFechaFinal.Text) & "')) AS desviacion ,  (SELECT        AVG(Tenor) AS Expr1 FROM            dbo.gr_MerrilCrowe AS Pb_TenorPromedioB12_3   WHERE        (Fecha >= '" & CDate(DtFechaInicial.Text) & "') AND (Fecha <= '" & CDate(DtFechaFinal.Text) & "')) as media ,   (SELECT        AVG(Tenor) AS Expr1 FROM            dbo.gr_MerrilCrowe AS Pb_TenorPromedioB12_3   WHERE        (Fecha >= '" & CDate(DtFechaInicial.Text) & "') AND (Fecha <= '" & CDate(DtFechaFinal.Text) & "')) -  (SELECT        STDEV(Tenor) AS Expr1 FROM            dbo.gr_MerrilCrowe AS Pb_TenorPromedioB12_2   WHERE        (Fecha >= '" & CDate(DtFechaInicial.Text) & "') AND (Fecha <= '" & CDate(DtFechaFinal.Text) & "')) AS minimo , (SELECT        AVG(Tenor) AS Expr1 FROM            dbo.gr_MerrilCrowe AS Pb_TenorPromedioB12_3   WHERE        (Fecha >= '" & CDate(DtFechaInicial.Text) & "') AND (Fecha <= '" & CDate(DtFechaFinal.Text) & "')) +  (SELECT        STDEV(Tenor) AS Expr1 FROM            dbo.gr_MerrilCrowe AS Pb_TenorPromedioB12_2   WHERE        (Fecha >= '" & CDate(DtFechaInicial.Text) & "') AND (Fecha <= '" & CDate(DtFechaFinal.Text) & "')) AS maximo FROM gr_MerrilCrowe  WHERE        (Fecha >= '" & CDate(DtFechaInicial.Text) & "') AND (Fecha <= '" & CDate(DtFechaFinal.Text) & "')  "
        ElseIf (Cmbubicacion.Text = "Tenor_Molienda") Then
            tblFields = " SELECT        TOP (100) PERCENT IdPeriodos, TenorReporteDiario FROM   dbo.Pb_BalanceFisicoGraficos WHERE        (TenorReporteDiario IS NOT NULL) and FechaInicial >= '" & CDate(CmbPeriodoInicial.SelectedValue) & "' and FechaInicial <= '" & CDate(CmbPeriodoFinal.SelectedValue) & "' ORDER BY FechaInicial   "
            '  tblFields = "SELECT        CONVERT(VARCHAR(11), fecha, 6) AS total , Fecha , tenor , (SELECT        STDEV(Tenor) AS Expr1  FROM            dbo.Gr_MerrilcroweColas AS Pb_TenorPromedioB12_6  WHERE        (Fecha >= '" & CDate(DtFechaInicial.Text) & "') AND (Fecha <= '" & CDate(DtFechaFinal.Text) & "')) AS desviacion ,  (SELECT        AVG(Tenor) AS Expr1 FROM            dbo.Gr_MerrilcroweColas AS Pb_TenorPromedioB12_3   WHERE        (Fecha >= '" & CDate(DtFechaInicial.Text) & "') AND (Fecha <= '" & CDate(DtFechaFinal.Text) & "')) as media ,   (SELECT        AVG(Tenor) AS Expr1 FROM            dbo.Gr_MerrilcroweColas AS Pb_TenorPromedioB12_3   WHERE        (Fecha >= '" & CDate(DtFechaInicial.Text) & "') AND (Fecha <= '" & CDate(DtFechaFinal.Text) & "')) -  (SELECT        STDEV(Tenor) AS Expr1 FROM            dbo.Gr_MerrilcroweColas AS Pb_TenorPromedioB12_2   WHERE        (Fecha >= '" & CDate(DtFechaInicial.Text) & "') AND (Fecha <= '" & CDate(DtFechaFinal.Text) & "')) AS minimo , (SELECT        AVG(Tenor) AS Expr1 FROM            dbo.Gr_MerrilcroweColas AS Pb_TenorPromedioB12_3   WHERE        (Fecha >= '" & CDate(DtFechaInicial.Text) & "') AND (Fecha <= '" & CDate(DtFechaFinal.Text) & "')) +  (SELECT        STDEV(Tenor) AS Expr1 FROM            dbo.Gr_MerrilcroweColas AS Pb_TenorPromedioB12_2   WHERE        (Fecha >= '" & CDate(DtFechaInicial.Text) & "') AND (Fecha <= '" & CDate(DtFechaFinal.Text) & "')) AS maximo FROM Gr_MerrilcroweColas  WHERE        (Fecha >= '" & CDate(DtFechaInicial.Text) & "') AND (Fecha <= '" & CDate(DtFechaFinal.Text) & "')  "
        ElseIf (Cmbubicacion.Text = "Tenor_Colas") Then
            tblFields = " SELECT        TOP (100) PERCENT IdPeriodos, TenorColas FROM   dbo.Pb_BalanceFisicoGraficos WHERE        (TenorColas IS NOT NULL) and FechaInicial >= '" & CDate(CmbPeriodoInicial.SelectedValue) & "' and FechaInicial <= '" & CDate(CmbPeriodoFinal.SelectedValue) & "' ORDER BY FechaInicial   "
            ' tblFields = "SELECT        CONVERT(VARCHAR(11), fecha, 6) AS total , Fecha , tenor , (SELECT        STDEV(Tenor) AS Expr1  FROM            dbo.Gr_AAgitador1_Solido AS Pb_TenorPromedioB12_6  WHERE        (Fecha >= '" & CDate(DtFechaInicial.Text) & "') AND (Fecha <= '" & CDate(DtFechaFinal.Text) & "')) AS desviacion ,  (SELECT        AVG(Tenor) AS Expr1 FROM            dbo.Gr_AAgitador1_Solido AS Pb_TenorPromedioB12_3   WHERE        (Fecha >= '" & CDate(DtFechaInicial.Text) & "') AND (Fecha <= '" & CDate(DtFechaFinal.Text) & "')) as media ,   (SELECT        AVG(Tenor) AS Expr1 FROM            dbo.Gr_AAgitador1_Solido AS Pb_TenorPromedioB12_3   WHERE        (Fecha >= '" & CDate(DtFechaInicial.Text) & "') AND (Fecha <= '" & CDate(DtFechaFinal.Text) & "')) -  (SELECT        STDEV(Tenor) AS Expr1 FROM            dbo.Gr_AAgitador1_Solido AS Pb_TenorPromedioB12_2   WHERE        (Fecha >= '" & CDate(DtFechaInicial.Text) & "') AND (Fecha <= '" & CDate(DtFechaFinal.Text) & "')) AS minimo , (SELECT        AVG(Tenor) AS Expr1 FROM            dbo.Gr_AAgitador1_Solido AS Pb_TenorPromedioB12_3   WHERE        (Fecha >= '" & CDate(DtFechaInicial.Text) & "') AND (Fecha <= '" & CDate(DtFechaFinal.Text) & "')) +  (SELECT        STDEV(Tenor) AS Expr1 FROM            dbo.Gr_AAgitador1_Solido AS Pb_TenorPromedioB12_2   WHERE        (Fecha >= '" & CDate(DtFechaInicial.Text) & "') AND (Fecha <= '" & CDate(DtFechaFinal.Text) & "')) AS maximo FROM Gr_AAgitador1_Solido  WHERE        (Fecha >= '" & CDate(DtFechaInicial.Text) & "') AND (Fecha <= '" & CDate(DtFechaFinal.Text) & "')  "
        ElseIf (Cmbubicacion.Text = "Oro_Fundido") Then
            tblFields = " SELECT        TOP (100) PERCENT IdPeriodos, OnzasFundidas FROM   dbo.Pb_BalanceFisicoGraficos WHERE        (OnzasFundidas IS NOT NULL) and FechaInicial >= '" & CDate(CmbPeriodoInicial.SelectedValue) & "' and FechaInicial <= '" & CDate(CmbPeriodoFinal.SelectedValue) & "' ORDER BY FechaInicial   "
        ElseIf (Cmbubicacion.Text = "Tenor_Molienda_Calculado") Then
            tblFields = " SELECT        TOP (100) PERCENT IdPeriodos, TenorCalculadoBFisico FROM   dbo.Pb_BalanceFisicoGraficos WHERE        (TenorCalculadoBFisico IS NOT NULL) and FechaInicial >= '" & CDate(CmbPeriodoInicial.SelectedValue) & "' and FechaInicial <= '" & CDate(CmbPeriodoFinal.SelectedValue) & "' ORDER BY FechaInicial   "

            ' tblFields = "SELECT        CONVERT(VARCHAR(11), fecha, 6) AS total , Fecha , tenor , (SELECT        STDEV(Tenor) AS Expr1  FROM            dbo.Gr_ColasBulk AS Pb_TenorPromedioB12_6  WHERE        (Fecha >= '" & CDate(DtFechaInicial.Text) & "') AND (Fecha <= '" & CDate(DtFechaFinal.Text) & "')) AS desviacion ,  (SELECT        AVG(Tenor) AS Expr1 FROM            dbo.Gr_ColasBulk AS Pb_TenorPromedioB12_3   WHERE        (Fecha >= '" & CDate(DtFechaInicial.Text) & "') AND (Fecha <= '" & CDate(DtFechaFinal.Text) & "')) as media ,   (SELECT        AVG(Tenor) AS Expr1 FROM            dbo.Gr_ColasBulk AS Pb_TenorPromedioB12_3   WHERE        (Fecha >= '" & CDate(DtFechaInicial.Text) & "') AND (Fecha <= '" & CDate(DtFechaFinal.Text) & "')) -  (SELECT        STDEV(Tenor) AS Expr1 FROM            dbo.Gr_ColasBulk AS Pb_TenorPromedioB12_2   WHERE        (Fecha >= '" & CDate(DtFechaInicial.Text) & "') AND (Fecha <= '" & CDate(DtFechaFinal.Text) & "')) AS minimo , (SELECT        AVG(Tenor) AS Expr1 FROM            dbo.Gr_ColasBulk AS Pb_TenorPromedioB12_3   WHERE        (Fecha >= '" & CDate(DtFechaInicial.Text) & "') AND (Fecha <= '" & CDate(DtFechaFinal.Text) & "')) +  (SELECT        STDEV(Tenor) AS Expr1 FROM            dbo.Gr_ColasBulk AS Pb_TenorPromedioB12_2   WHERE        (Fecha >= '" & CDate(DtFechaInicial.Text) & "') AND (Fecha <= '" & CDate(DtFechaFinal.Text) & "')) AS maximo FROM Gr_ColasBulk  WHERE        (Fecha >= '" & CDate(DtFechaInicial.Text) & "') AND (Fecha <= '" & CDate(DtFechaFinal.Text) & "')  "
        ElseIf (Cmbubicacion.Text = "Recuperacion_Metalurgica") Then
            tblFields = " SELECT        TOP (100) PERCENT IdPeriodos, RecuperacionMetalurgica FROM   dbo.Pb_BalanceFisicoGraficos WHERE        (RecuperacionMetalurgica IS NOT NULL) and FechaInicial >= '" & CDate(CmbPeriodoInicial.SelectedValue) & "' and FechaInicial <= '" & CDate(CmbPeriodoFinal.SelectedValue) & "' ORDER BY FechaInicial   "
            'tblFields = "SELECT        CONVERT(VARCHAR(11), fecha, 6) AS total , Fecha , tenor , (SELECT        STDEV(Tenor) AS Expr1  FROM            dbo.Gr_ColasLixiviacionSolida AS Pb_TenorPromedioB12_6  WHERE        (Fecha >= '" & CDate(DtFechaInicial.Text) & "') AND (Fecha <= '" & CDate(DtFechaFinal.Text) & "')) AS desviacion ,  (SELECT        AVG(Tenor) AS Expr1 FROM            dbo.Gr_ColasLixiviacionSolida AS Pb_TenorPromedioB12_3   WHERE        (Fecha >= '" & CDate(DtFechaInicial.Text) & "') AND (Fecha <= '" & CDate(DtFechaFinal.Text) & "')) as media ,   (SELECT        AVG(Tenor) AS Expr1 FROM            dbo.Gr_ColasLixiviacionSolida AS Pb_TenorPromedioB12_3   WHERE        (Fecha >= '" & CDate(DtFechaInicial.Text) & "') AND (Fecha <= '" & CDate(DtFechaFinal.Text) & "')) -  (SELECT        STDEV(Tenor) AS Expr1 FROM            dbo.Gr_ColasLixiviacionSolida AS Pb_TenorPromedioB12_2   WHERE        (Fecha >= '" & CDate(DtFechaInicial.Text) & "') AND (Fecha <= '" & CDate(DtFechaFinal.Text) & "')) AS minimo , (SELECT        AVG(Tenor) AS Expr1 FROM            dbo.Gr_ColasLixiviacionSolida AS Pb_TenorPromedioB12_3   WHERE        (Fecha >= '" & CDate(DtFechaInicial.Text) & "') AND (Fecha <= '" & CDate(DtFechaFinal.Text) & "')) +  (SELECT        STDEV(Tenor) AS Expr1 FROM            dbo.Gr_ColasLixiviacionSolida AS Pb_TenorPromedioB12_2   WHERE        (Fecha >= '" & CDate(DtFechaInicial.Text) & "') AND (Fecha <= '" & CDate(DtFechaFinal.Text) & "')) AS maximo FROM Gr_ColasLixiviacionSolida  WHERE        (Fecha >= '" & CDate(DtFechaInicial.Text) & "') AND (Fecha <= '" & CDate(DtFechaFinal.Text) & "')  "
        ElseIf (Cmbubicacion.Text = "Inventario") Then
            tblFields = " SELECT        TOP (100) PERCENT IdPeriodos, inventarioplanta FROM   dbo.Pb_BalanceFisicoGraficos WHERE        (inventarioplanta IS NOT NULL) and FechaInicial >= '" & CDate(CmbPeriodoInicial.SelectedValue) & "' and FechaInicial <= '" & CDate(CmbPeriodoFinal.SelectedValue) & "' ORDER BY FechaInicial   "
            ' tblFields = "SELECT        CONVERT(VARCHAR(11), fecha, 6) AS total , Fecha , tenor , (SELECT        STDEV(Tenor) AS Expr1  FROM            dbo.Gr_ColasLixiviacionSolucion AS Pb_TenorPromedioB12_6  WHERE        (Fecha >= '" & CDate(DtFechaInicial.Text) & "') AND (Fecha <= '" & CDate(DtFechaFinal.Text) & "')) AS desviacion ,  (SELECT        AVG(Tenor) AS Expr1 FROM            dbo.Gr_ColasLixiviacionSolucion AS Pb_TenorPromedioB12_3   WHERE        (Fecha >= '" & CDate(DtFechaInicial.Text) & "') AND (Fecha <= '" & CDate(DtFechaFinal.Text) & "')) as media ,   (SELECT        AVG(Tenor) AS Expr1 FROM            dbo.Gr_ColasLixiviacionSolucion AS Pb_TenorPromedioB12_3   WHERE        (Fecha >= '" & CDate(DtFechaInicial.Text) & "') AND (Fecha <= '" & CDate(DtFechaFinal.Text) & "')) -  (SELECT        STDEV(Tenor) AS Expr1 FROM            dbo.Gr_ColasLixiviacionSolucion AS Pb_TenorPromedioB12_2   WHERE        (Fecha >= '" & CDate(DtFechaInicial.Text) & "') AND (Fecha <= '" & CDate(DtFechaFinal.Text) & "')) AS minimo , (SELECT        AVG(Tenor) AS Expr1 FROM            dbo.Gr_ColasLixiviacionSolucion AS Pb_TenorPromedioB12_3   WHERE        (Fecha >= '" & CDate(DtFechaInicial.Text) & "') AND (Fecha <= '" & CDate(DtFechaFinal.Text) & "')) +  (SELECT        STDEV(Tenor) AS Expr1 FROM            dbo.Gr_ColasLixiviacionSolucion AS Pb_TenorPromedioB12_2   WHERE        (Fecha >= '" & CDate(DtFechaInicial.Text) & "') AND (Fecha <= '" & CDate(DtFechaFinal.Text) & "')) AS maximo FROM Gr_ColasLixiviacionSolucion  WHERE        (Fecha >= '" & CDate(DtFechaInicial.Text) & "') AND (Fecha <= '" & CDate(DtFechaFinal.Text) & "')  "
        ElseIf (Cmbubicacion.Text = "Recuperacion_Metalurgica_Calculada") Then
            tblFields = " SELECT        TOP (100) PERCENT IdPeriodos, RecuperacionCalculadaBFisico FROM   dbo.Pb_BalanceFisicoGraficos WHERE        (RecuperacionCalculadaBFisico IS NOT NULL) and FechaInicial >= '" & CDate(CmbPeriodoInicial.SelectedValue) & "' and FechaInicial <= '" & CDate(CmbPeriodoFinal.SelectedValue) & "' ORDER BY FechaInicial   "
            ' tblFields = "SELECT        CONVERT(VARCHAR(11), fecha, 6) AS total , Fecha , tenor , (SELECT        STDEV(Tenor) AS Expr1  FROM            dbo.Gr_DAgitador4_Solido AS Pb_TenorPromedioB12_6  WHERE        (Fecha >= '" & CDate(DtFechaInicial.Text) & "') AND (Fecha <= '" & CDate(DtFechaFinal.Text) & "')) AS desviacion ,  (SELECT        AVG(Tenor) AS Expr1 FROM            dbo.Gr_DAgitador4_Solido AS Pb_TenorPromedioB12_3   WHERE        (Fecha >= '" & CDate(DtFechaInicial.Text) & "') AND (Fecha <= '" & CDate(DtFechaFinal.Text) & "')) as media ,   (SELECT        AVG(Tenor) AS Expr1 FROM            dbo.Gr_DAgitador4_Solido AS Pb_TenorPromedioB12_3   WHERE        (Fecha >= '" & CDate(DtFechaInicial.Text) & "') AND (Fecha <= '" & CDate(DtFechaFinal.Text) & "')) -  (SELECT        STDEV(Tenor) AS Expr1 FROM            dbo.Gr_DAgitador4_Solido AS Pb_TenorPromedioB12_2   WHERE        (Fecha >= '" & CDate(DtFechaInicial.Text) & "') AND (Fecha <= '" & CDate(DtFechaFinal.Text) & "')) AS minimo , (SELECT        AVG(Tenor) AS Expr1 FROM            dbo.Gr_DAgitador4_Solido AS Pb_TenorPromedioB12_3   WHERE        (Fecha >= '" & CDate(DtFechaInicial.Text) & "') AND (Fecha <= '" & CDate(DtFechaFinal.Text) & "')) +  (SELECT        STDEV(Tenor) AS Expr1 FROM            dbo.Gr_DAgitador4_Solido AS Pb_TenorPromedioB12_2   WHERE        (Fecha >= '" & CDate(DtFechaInicial.Text) & "') AND (Fecha <= '" & CDate(DtFechaFinal.Text) & "')) AS maximo FROM Gr_DAgitador4_Solido  WHERE        (Fecha >= '" & CDate(DtFechaInicial.Text) & "') AND (Fecha <= '" & CDate(DtFechaFinal.Text) & "')  "

        End If
        Dim conn As New OleDbConnection(cadena)
        ' Dim oCmd As New OleDbCommand(tblFields, conn)
        Dim oData As New OleDbDataAdapter(tblFields, conn)
        Dim ds As New DataSet
        conn.Open()
        oData.Fill(ds, "Table1")
        conn.Close()

        If ds.Tables("Table1").Rows.Count > 1 Then
            PbGrafico.DataSource = ds.Tables("Table1")
            Dim ChartArea1 As ChartArea = New ChartArea()
            ChartArea1.Name = "ChartArea1"
            PbGrafico.ChartAreas.Add(ChartArea1)

            Dim Series1 As Series = New Series()
            Series1 = PbGrafico.Series.Add("Series1")

            If Cmbubicacion.Text = "Alimento_Onzas_Molino" Then
                Series1.Name = "OnzasAlimentadas"
            ElseIf Cmbubicacion.Text = "Toneladas_Procesadas" Then
                Series1.Name = "Toneladas"
            ElseIf Cmbubicacion.Text = "Tenor_Molienda" Then
                Series1.Name = "TenorReporteDiario"
            ElseIf Cmbubicacion.Text = "Tenor_Molienda_Calculado" Then
                Series1.Name = "TenorCalculadoBFisico"
            ElseIf Cmbubicacion.Text = "Tenor_Colas" Then
                Series1.Name = "TenorColas"
            ElseIf Cmbubicacion.Text = "Oro_Fundido" Then
                Series1.Name = "OnzasFundidas"
            ElseIf Cmbubicacion.Text = "Recuperacion_Metalurgica" Then
                Series1.Name = "RecuperacionMetalurgica"
            ElseIf Cmbubicacion.Text = "Inventario" Then
                Series1.Name = "inventarioplanta"
            ElseIf Cmbubicacion.Text = "Recuperacion_Metalurgica_Calculada" Then
                Series1.Name = "RecuperacionCalculadaBFisico"
            Else
            End If

            If Cmbubicacion.Text = "Alimento_Onzas_Molino" Then


            ElseIf Cmbubicacion.Text = "Toneladas_Procesadas" Then


            ElseIf Cmbubicacion.Text = "Tenor_Molienda" Then
            ElseIf Cmbubicacion.Text = "Tenor_Molienda_Calculado" Then
            ElseIf Cmbubicacion.Text = "Tenor_Colas" Then
            ElseIf Cmbubicacion.Text = "Oro_Fundido" Then
            ElseIf Cmbubicacion.Text = "Recuperacion_Metalurgica" Then
            ElseIf Cmbubicacion.Text = "Inventario" Then
            ElseIf Cmbubicacion.Text = "Recuperacion_Metalurgica_Calculada" Then
            Else
                Dim Series2 As Series = New Series()
                Series2 = PbGrafico.Series.Add("Series2")
                Series2.Name = "OnzasAlimentadas"
            End If
            If Cmbubicacion.Text = "Alimento_Onzas_Molino" Then
            ElseIf Cmbubicacion.Text = "Toneladas_Procesadas" Then
            ElseIf Cmbubicacion.Text = "Tenor_Molienda" Then
            ElseIf Cmbubicacion.Text = "Tenor_Molienda_Calculado" Then
            ElseIf Cmbubicacion.Text = "Tenor_Colas" Then
            ElseIf Cmbubicacion.Text = "Oro_Fundido" Then
            ElseIf Cmbubicacion.Text = "Recuperacion_Metalurgica" Then
            ElseIf Cmbubicacion.Text = "Inventario" Then
            ElseIf Cmbubicacion.Text = "Recuperacion_Metalurgica_Calculada" Then
            Else
                Dim Series3 As Series = New Series()
                Series3 = PbGrafico.Series.Add("Series3")
                Series3.Name = "Desviacion Maxima (" & lblmaximo.Text & ")"
                ' Series3.Name = "Desviacion Maxima"
            End If

            If Cmbubicacion.Text = "Alimento_Onzas_Molino" Then
            ElseIf Cmbubicacion.Text = "Toneladas_Procesadas" Then
            ElseIf Cmbubicacion.Text = "Tenor_Molienda" Then
            ElseIf Cmbubicacion.Text = "Tenor_Colas" Then
            ElseIf Cmbubicacion.Text = "Oro_Fundido" Then
            ElseIf Cmbubicacion.Text = "Tenor_Molienda_Calculado" Then
            ElseIf Cmbubicacion.Text = "Recuperacion_Metalurgica" Then
            ElseIf Cmbubicacion.Text = "Inventario" Then
            ElseIf Cmbubicacion.Text = "Recuperacion_Metalurgica_Calculada" Then
            Else
                Dim Series4 As Series = New Series()
                Series4 = PbGrafico.Series.Add("Series4")
                Series4.Name = "Desviacion Minima(" & lblminimo.Text & ")"
            End If

            '  Series1.Name = "Tenor"
            ' Series2.Name = "Tenor Promedio (" & lblmedia.Text & ")"


            '  HighlightWeekendsWithStripLines()
            ' PbGrafico.Legends(0).Position.

            'posicion de la leyenda
            PbGrafico.Legends(0).Position.Auto = False
            PbGrafico.Legends(0).Position.X = 10
            PbGrafico.Legends(0).Position.Y = 10
            PbGrafico.Legends(0).Position.Width = 20
            PbGrafico.Legends(0).Position.Height = 8
            'òcultar(leyenda)
            ' Series3.IsVisibleInLegend = False

            'PbGrafico.Legends.p = .Legend.Position = xlLegendPositionBottom
            If ChkBarras.Checked = True Then
                PbGrafico.Series(0).ChartType = DataVisualization.Charting.SeriesChartType.Column
            Else
                PbGrafico.Series(0).ChartType = DataVisualization.Charting.SeriesChartType.Line
            End If

            '  If Cmbubicacion.Text = "Alimento_Onzas_Molino" Then
            'PbGrafico.Series(0).ChartType = DataVisualization.Charting.SeriesChartType.Line
            'Else
            'End If


            ' PbGrafico.Series(1).ChartType = DataVisualization.Charting.SeriesChartType.Line
            ' PbGrafico.Series(2).ChartType = DataVisualization.Charting.SeriesChartType.Line
            ' PbGrafico.Series(3).ChartType = DataVisualization.Charting.SeriesChartType.Line








            ' If ChkMAximo.Checked = True Then
            'PbGrafico.Series(2).Enabled = True
            'Else
            '    PbGrafico.Series(2).Enabled = False
            ' End If
            'If ChkMinimo.Checked = True Then
            'PbGrafico.Series(3).Enabled = True
            ' Else
            '     PbGrafico.Series(3).Enabled = False
            ' End If
            'If ChkPromedio.Checked = True Then
            'PbGrafico.Series(1).Enabled = True
            ' Else
            '   PbGrafico.Series(1).Enabled = False
            'End If

            PbGrafico.Series(Series1.Name).XValueMember = "IdPeriodos"

            If Cmbubicacion.Text = "Alimento_Onzas_Molino" Then
                PbGrafico.Series(Series1.Name).YValueMembers = "OnzasAlimentadas"
            ElseIf Cmbubicacion.Text = "Toneladas_Procesadas" Then
                PbGrafico.Series(Series1.Name).YValueMembers = "Toneladas"
            ElseIf Cmbubicacion.Text = "Tenor_Molienda" Then
                PbGrafico.Series(Series1.Name).YValueMembers = "TenorReporteDiario"
            ElseIf Cmbubicacion.Text = "Tenor_Molienda_Calculado" Then
                PbGrafico.Series(Series1.Name).YValueMembers = "TenorCalculadoBFisico"
            ElseIf Cmbubicacion.Text = "Tenor_Colas" Then
                PbGrafico.Series(Series1.Name).YValueMembers = "TenorColas"
            ElseIf Cmbubicacion.Text = "Oro_Fundido" Then
                PbGrafico.Series(Series1.Name).YValueMembers = "OnzasFundidas"
            ElseIf Cmbubicacion.Text = "Recuperacion_Metalurgica" Then
                PbGrafico.Series(Series1.Name).YValueMembers = "RecuperacionMetalurgica"
            ElseIf Cmbubicacion.Text = "Inventario" Then
                PbGrafico.Series(Series1.Name).YValueMembers = "inventarioplanta"
            ElseIf Cmbubicacion.Text = "Recuperacion_Metalurgica_Calculada" Then
                PbGrafico.Series(Series1.Name).YValueMembers = "RecuperacionCalculadaBFisico"
            End If

            If Cmbubicacion.Text = "Alimento_Onzas_Molino" Then
            ElseIf Cmbubicacion.Text = "Toneladas_Procesadas" Then
            ElseIf Cmbubicacion.Text = "Tenor_Molienda" Then
            ElseIf Cmbubicacion.Text = "Tenor_Colas" Then
            ElseIf Cmbubicacion.Text = "Oro_Fundido" Then
            ElseIf Cmbubicacion.Text = "Tenor_Molienda_Calculado" Then
            ElseIf Cmbubicacion.Text = "Recuperacion_Metalurgica" Then
            ElseIf Cmbubicacion.Text = "Inventario" Then
            ElseIf Cmbubicacion.Text = "Recuperacion_Metalurgica_Calculada" Then
            Else

                PbGrafico.Series(Series2.Name).YValueMembers = "media"
            End If
            If Cmbubicacion.Text = "Alimento_Onzas_Molino" Then
            ElseIf Cmbubicacion.Text = "Toneladas_Procesadas" Then
            ElseIf Cmbubicacion.Text = "Tenor_Molienda" Then
            ElseIf Cmbubicacion.Text = "Tenor_Colas" Then
            ElseIf Cmbubicacion.Text = "Oro_Fundido" Then
            ElseIf Cmbubicacion.Text = "Tenor_Molienda_Calculado" Then
            ElseIf Cmbubicacion.Text = "Recuperacion_Metalurgica" Then
            ElseIf Cmbubicacion.Text = "Inventario" Then
            ElseIf Cmbubicacion.Text = "Recuperacion_Metalurgica_Calculada" Then
            Else

                PbGrafico.Series(Series3.Name).YValueMembers = "Maximo"
            End If


            If Cmbubicacion.Text = "Alimento_Onzas_Molino" Then
            ElseIf Cmbubicacion.Text = "Toneladas_Procesadas" Then
            ElseIf Cmbubicacion.Text = "Tenor_Molienda" Then
            ElseIf Cmbubicacion.Text = "Tenor_Colas" Then
            ElseIf Cmbubicacion.Text = "Oro_Fundido" Then
            ElseIf Cmbubicacion.Text = "Tenor_Molienda_Calculado" Then
            ElseIf Cmbubicacion.Text = "Recuperacion_Metalurgica" Then
            ElseIf Cmbubicacion.Text = "Inventario" Then
            ElseIf Cmbubicacion.Text = "Recuperacion_Metalurgica_Calculada" Then
            Else
                PbGrafico.Series(Series4.Name).YValueMembers = "Minimo"
            End If


            'PbGrafico.ChartAreas("ChartArea1").AxisX.MajorGrid.
            PbGrafico.ChartAreas("ChartArea1").AxisX.Minimum = 1
            PbGrafico.ChartAreas("ChartArea1").AxisX.Maximum = ds.Tables("Table1").Rows.Count
            PbGrafico.ChartAreas("ChartArea1").AxisX.IsMarginVisible = False
            PbGrafico.ChartAreas("ChartArea1").AxisX.LabelStyle.Interval = 1
            If Cmbubicacion.Text = "Alimento_Onzas_Molino" Or Cmbubicacion.Text = "Toneladas_Procesadas" Or Cmbubicacion.Text = "Oro_Fundido" Then
                PbGrafico.ChartAreas("ChartArea1").AxisY.LabelStyle.Interval = 1000
            ElseIf Cmbubicacion.Text = "Recuperacion_Metalurgica" Or Cmbubicacion.Text = "Recuperacion_Metalurgica_Calculada" Then

                PbGrafico.ChartAreas("ChartArea1").AxisY.LabelStyle.Interval = 10

            ElseIf Cmbubicacion.Text = "Inventario" Then
                PbGrafico.ChartAreas("ChartArea1").AxisY.LabelStyle.Interval = 100
            Else
                PbGrafico.ChartAreas("ChartArea1").AxisY.LabelStyle.Interval = 1
            End If

            'temporal
            PbGrafico.Series(Series1.Name).BorderWidth = 3
            'PbGrafico.Series(Series2.Name).BorderWidth = 2
            '  PbGrafico.Series(Series3.Name).BorderWidth = 2
            ' PbGrafico.Series(Series4.Name).BorderWidth = 2
            ' PbGrafico.Series(Series3.Name).Color = Color.Green
            ' PbGrafico.Series(Series2.Name).Color = Color.Tomato
            ' temporal
            'PbGrafico.Series(Series2.Name).MarkerStyle = LineAnchorCapStyle.Diamond

            'cmbmedia.DataSource = ds.Tables("Table1")
            ' cmbmedia.DisplayMember = "Media"
            ' cmbmedia.ValueMember = "Media"
            ' cmbdesviacion.DataSource = ds.Tables("Table1")
            ' cmbdesviacion.DisplayMember = "desviacion"
            ' cmbdesviacion.ValueMember = "desviacion"
            '  CmbMinimo.DataSource = ds.Tables("Table1")
            '  CmbMinimo.DisplayMember = "minimo"
            '  CmbMinimo.ValueMember = "minimo"
            ' CmbMaximo.DataSource = ds.Tables("Table1")
            '  CmbMaximo.DisplayMember = "maximo"
            '  CmbMaximo.ValueMember = "maximo"
            PbGrafico.ChartAreas(0).RecalculateAxesScale()

            'nombre de la serie de promedio
            If Cmbubicacion.Text = "Alimento_Onzas_Molino" Then
            Else
                'Series2.Name = "Tenor Promedio (" & CStr(Round(Val(cmbmedia.Text), 2)) & ")"
            End If



            If ChkTenores.Checked = True Then
                PbGrafico.Series(Series1.Name).IsValueShownAsLabel = True 'Visualizamos las etiquetas
                PbGrafico.Series(Series1.Name).LabelForeColor = Color.Black 'Pintamos el color de la etiqueta
                PbGrafico.Series(Series1.Name).LabelFormat = "F1"
                PbGrafico.Series(Series1.Name).SmartLabelStyle.Enabled = True
                PbGrafico.Series(Series1.Name).LabelAngle = 50
            Else
                PbGrafico.Series(Series1.Name).IsValueShownAsLabel = False ' no Visualizamos las etiquetas
                PbGrafico.Series(Series1.Name).SmartLabelStyle.Enabled = False
            End If

            '   AddThresholdStripLine()
            Lblubicacion.Text = Cmbubicacion.Text


            '  estilo de la grilla del grafico
            PbGrafico.ChartAreas(0).AxisX.LineWidth = 0.2
            PbGrafico.ChartAreas(0).AxisX.MajorGrid.LineColor = Color.SlateGray
            PbGrafico.ChartAreas(0).AxisX.MajorGrid.LineDashStyle = ChartDashStyle.DashDotDot
            PbGrafico.ChartAreas(0).AxisY.LineWidth = 0.2
            PbGrafico.ChartAreas(0).AxisY.MajorGrid.LineColor = Color.SlateGray
            PbGrafico.ChartAreas(0).AxisY.MajorGrid.LineDashStyle = ChartDashStyle.DashDotDot
        Else
            Lblubicacion.Text = "No hay Registros"
        End If


        '~~> titulo del grafico
        PbGrafico.Titles.Clear()
        Dim T As Title

        If Cmbubicacion.Text = "Alimento_Onzas_Molino" Then
            T = PbGrafico.Titles.Add("Onzas Ingresadas a Molino Periodo")
        ElseIf Cmbubicacion.Text = "Toneladas_Procesadas" Then
            T = PbGrafico.Titles.Add("Toneladas procesadas por Periodo")
        ElseIf Cmbubicacion.Text = "Tenor_Molienda" Then
            T = PbGrafico.Titles.Add("Tenor alimento a Molienda  por Periodo")
        ElseIf Cmbubicacion.Text = "Tenor_Molienda_Calculado" Then
            T = PbGrafico.Titles.Add("Tenor alimento a Molienda  Calculado por Balance Fisico")
        ElseIf Cmbubicacion.Text = "Tenor_Colas" Then
            T = PbGrafico.Titles.Add("Tenor Total de Colas")
        ElseIf Cmbubicacion.Text = "Oro_Fundido" Then
            T = PbGrafico.Titles.Add("Onzas de Au Fundidas por Periodo")
        ElseIf Cmbubicacion.Text = "Recuperacion_Metalurgica" Then
            T = PbGrafico.Titles.Add("Recuperacion Metalurgica por Periodo - Plantade beneficio")
        ElseIf Cmbubicacion.Text = "Inventario" Then
            T = PbGrafico.Titles.Add("Inventario de Oro en Planta")
        ElseIf Cmbubicacion.Text = "Recuperacion_Metalurgica_Calculada" Then
            T = PbGrafico.Titles.Add("Recuperacion Metalurgica Calculada por Periodo - Plantade beneficio")
        Else
            T = PbGrafico.Titles.Add("no hay datos")
        End If

        '~~> Formatting the Title

        With T
            .ForeColor = Color.Black            '~~> Changing the Fore Color of the Title 
            .BackColor = Color.Honeydew           '~~> Changing the Back Color of the Title 
            .Font = New System.Drawing.Font("Times New Roman", 14.0F, System.Drawing.FontStyle.Bold)
            .Font = New System.Drawing.Font("Times New Roman", 14.0F, System.Drawing.FontStyle.Italic)
            .BorderColor = Color.Black          '~~> Changing the Border Color of the Title 
            .BorderDashStyle = ChartDashStyle.DashDotDot '~~> Changing the Border Dash Style of the Title 
        End With

        'PbGrafico.ChartAreas(0).AxisX.LineWidth = 5
        'PbGrafico.ChartAreas(0).AxisY.LineWidth = 5
        ' PbGrafico.ChartAreas(0).AxisX.LabelStyle.Enabled = False
        'PbGrafico.ChartAreas(0).AxisY.LabelStyle.Enabled = False
        ' PbGrafico.ChartAreas(0).AxisX.MajorGrid.Enabled = False


        'PbGrafico.ChartAreas(0).AxisY.MajorGrid.Enabled = False
        ' PbGrafico.ChartAreas(0).AxisX.MinorGrid.Enabled = False
        ' PbGrafico.ChartAreas(0).AxisY.MinorGrid.Enabled = False
        'PbGrafico.ChartAreas(0).AxisX.MajorTickMark.Enabled = False
        'PbGrafico.ChartAreas(0).AxisY.MajorTickMark.Enabled = False
        'PbGrafico.ChartAreas(0).AxisX.MinorTickMark.Enabled = False
        'PbGrafico.ChartAreas(0).AxisY.MinorTickMark.Enabled = False
        'PbGrafico.ChartAreas(0).BackColor = SystemColors.Control
        Me.Refresh()


    End Sub
    Private Sub CargarInicial()
        With Cmd
            .CommandType = CommandType.Text
            .CommandText = "SELECT        FechaInicial , IdPeriodos  FROM dbo.Pb_BalanceFisico ORDER BY FechaInicial"
            .Connection = Cn
        End With
        Da.SelectCommand = Cmd
        dt = New DataTable
        Da.Fill(dt)
        With CmbPeriodoInicial
            .DataSource = dt
            .DisplayMember = "IdPeriodos"
            .ValueMember = dt.Columns("FechaInicial").ToString()

            ' .ValueMember = "FechaInicial"

        End With


    End Sub
    Private Sub CargarFinal()
        With Cmd
            .CommandType = CommandType.Text
            .CommandText = "SELECT       FechaInicial , IdPeriodos  FROM dbo.Pb_BalanceFisico ORDER BY FechaInicial"
            .Connection = Cn
        End With
        Da.SelectCommand = Cmd
        dt = New DataTable
        Da.Fill(dt)

        With CmbPeriodoFinal
            .DataSource = dt
            .DisplayMember = "IdPeriodos"
            .ValueMember = "FechaInicial"

        End With

    End Sub
    Private Sub Chart1_GetToolTipText(ByVal sender As Object, ByVal e As System.Windows.Forms.DataVisualization.Charting.ToolTipEventArgs) Handles PbGrafico.GetToolTipText

        ' Check selected chart element and set tooltip text
        Select Case e.HitTestResult.ChartElementType
            Case ChartElementType.Axis
                e.Text = e.HitTestResult.Axis.Name
                ' Case ChartElementType.SBLargeDecrement
                '     e.Text = "A scrollbar large decrement button"
                ' Case ChartElementType.SBLargeIncrement
                '     e.Text = "A scrollbar large increment button"
                ' Case ChartElementType.SBSmallDecrement
                e.Text = "A scrollbar small decrement button"
                ' Case ChartElementType.SBSmallIncrement
                '      e.Text = "A scrollbar small increment button"
                ' Case ChartElementType.SBThumbTracker
                '   e.Text = "A scrollbar tracking thumb"
                'Case ChartElementType.SBZoomReset
                'e.Text = "The ZoomReset button of a scrollbar"
            Case ChartElementType.DataPoint
                Dim result As HitTestResult = PbGrafico.HitTest(e.X, e.Y, ChartElementType.DataPoint)
                e.Text = "Tenor : " & result.Series.Points(result.PointIndex).YValues(0).ToString
                ' e.Text = result.Series.Points(result.PointIndex).XValue.ToString & " : " & result.Series.Points(result.PointIndex).YValues(0).ToString
                ' e.Text = "Data Point " + e.HitTestResult.PointIndex.ToString()
            Case ChartElementType.Gridlines
                e.Text = "Grid Lines"
            Case ChartElementType.LegendArea
                e.Text = "Legend Area"
            Case ChartElementType.LegendItem
                e.Text = "Legend Item"
            Case ChartElementType.PlottingArea
                e.Text = "Plotting Area"

            Case ChartElementType.StripLines
                e.Text = "Strip Lines"
            Case ChartElementType.TickMarks
                e.Text = "Tick Marks"
            Case ChartElementType.Title
                e.Text = "Title"
        End Select


    End Sub





    Private Sub AddHorizRepeatingStripLines()
        ' StripLine()
        ' Instantiate new strip line 
        Dim stripLine1 As New StripLine()
        stripLine1.StripWidth = 0.1
        stripLine1.Interval = 0.1
        'stripLine1.IntervalOffset = 40
        ' Consider adding transparency so that the strip lines are lighter 
        stripLine1.BackColor = Color.FromArgb(120, Color.Red)
        ' Add the strip line to the chart 
        PbGrafico.ChartAreas(0).AxisY.StripLines.Add(stripLine1)

    End Sub

    Private Sub AddThresholdStripLine()
        Dim stripLine3 As New StripLine()

        ' Set threshold line so that it is only shown once 
        stripLine3.Interval = 0

        ' Set the threshold line to be drawn at the calculated mean of the first series 
        stripLine3.IntervalOffset = CDbl(CmbMinimo.Text)
        ' stripLine3.IntervalOffset = 100
        stripLine3.BackColor = Color.FromArgb(120, Color.Gold)
        ' stripLine3.BackColor = Color.FromArgb(120, Color.Gold)
        stripLine3.StripWidth = CDbl(cmbdesviacion.Text) * 2
        ' Set text properties for the threshold line 
        'stripLine3.Text = "Media"
        stripLine3.ForeColor = Color.Black
        ' Add strip line to the chart 
        PbGrafico.ChartAreas(0).AxisY.StripLines.Add(stripLine3)
    End Sub

    Private Sub HighlightWeekendsWithStripLines()

        ' Set strip line to highlight weekends 
        Dim stripLine2 As New StripLine()
        'stripLine2.BackColor = Color.FromArgb(100, Color.SkyBlue)
        ' stripLine2.IntervalOffset = -1.5
        ' stripLine2.IntervalOffsetType = DateTimeIntervalType.Days
        '  stripLine2.Interval = 1
        '  stripLine2.IntervalType = DateTimeIntervalType.Weeks
        ' stripLine2.StripWidth = 2
        ' stripLine2.StripWidthType = DateTimeIntervalType.Days
        ' Add strip line to the chart 
        PbGrafico.ChartAreas(0).AxisX.StripLines.Add(stripLine2)
        ' Set the axis label to show the name of the day 
        ' This is done in order to demonstrate that weekends are highlighted 
        PbGrafico.ChartAreas(0).AxisX.LabelStyle.Format = "yyyy/MM/dd"
    End Sub

    Private Sub chart1_CursorPositionChanging(ByVal sender As Object, ByVal e As System.Windows.Forms.DataVisualization.Charting.CursorEventArgs) Handles PbGrafico.CursorPositionChanged
        SetPosition(e.Axis, e.NewPosition)
    End Sub 'chart1_CursorPositionChanging





    Private Sub SetPosition(ByVal axis As Axis, ByVal position As Double)
        If Double.IsNaN(position) Then
            Return
        End If
        If axis.AxisName = AxisName.X Then
            ' Convert Double to DateTime.
            Dim dateTimeX As DateTime = DateTime.FromOADate(position)

            ' Set X cursor position to edit Control
            LblY.Text = dateTimeX.ToLongDateString()
            CursorX.Text = dateTimeX.ToLongDateString()
        Else
            ' Set Y cursor position to edit Control
            LblY.Text = position.ToString()
            CursorY.Text = position.ToString()
        End If
    End Sub 'SetPosition
    Private Sub cmbmedia_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbmedia.SelectedIndexChanged
        lblmedia.Text = cmbmedia.Text
        lblmedia.Text = Round(Val(lblmedia.Text), 2)

    End Sub

    Private Sub cmbdesviacion_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbdesviacion.SelectedIndexChanged
        lbldesviacion.Text = cmbdesviacion.Text
        lbldesviacion.Text = Round(Val(lbldesviacion.Text), 2)
        'Series3.Name = "Tenor Promedio (" & lblm.Text & ")"
    End Sub

    Private Sub CmbMaximo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbMaximo.SelectedIndexChanged
        lblmaximo.Text = CmbMaximo.Text
        lblmaximo.Text = Round(Val(CmbMaximo.Text), 2)
    End Sub

    Private Sub CmbMinimo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbMinimo.SelectedIndexChanged

        lblminimo.Text = CmbMinimo.Text
        lblminimo.Text = Round(Val(lblminimo.Text), 2)

    End Sub



    Public Sub ControlBmpToFile(ByVal control As Control, ByVal file As String)
        Dim bmp As New Bitmap(control.Width, control.Height)

        control.DrawToBitmap(bmp, control.DisplayRectangle)
        bmp.Save(file, System.Drawing.Imaging.ImageFormat.Jpeg)

    End Sub

    Private Sub FrmGraficoTenores_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.LblUsuario.Text = FrmPrincipal.LblUserName.Text
        CargarFinal()
        CargarInicial()
    End Sub


    Private Sub CmdGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdGuardar.Click
        PbGrafico.SaveImage(My.Application.Info.DirectoryPath & "\GraficoTenores" & Cmbubicacion.Text & ".png", System.Drawing.Imaging.ImageFormat.Png)
        MsgBox("O.K")
        'ControlBmpToFile(PbGrafico, "C:\Users\juan.palacio\Documents")
    End Sub

    Private Sub Cmbubicacion_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmbubicacion.SelectedIndexChanged

    End Sub

    Private Sub CmbPeriodoInicial_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbPeriodoInicial.SelectedIndexChanged

    End Sub
End Class