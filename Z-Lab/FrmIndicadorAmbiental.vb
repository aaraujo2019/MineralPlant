Option Explicit On
Option Strict On
Imports System.Data
Imports System.Data.SqlClient
Imports Z_Lab.Login
Imports System.Data.OleDb
Imports System.Windows.Forms
Imports Z_Lab.FrmPrincipal

Public Class FrmIndicadorAmbiental
    Private dt As DataTable
    Dim Da As New SqlDataAdapter
    Dim Cmd As New SqlCommand
    Dim Dataset As DataSet
    Dim Cn As New SqlConnection("Server=SEGSVRSQL01;uid=sa;pwd=*Bd6r4nC0l0mb1a*;database=PlantaBeneficio")
    Dim editarfundicion As Boolean
    Dim conn As New ADODB.Connection()
    Dim rstoperacion As New ADODB.Recordset()
    Dim Rsfundicion As New ADODB.Recordset()
    Dim cnStr As String
    Private Sub LblUsuario_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub FrmIndicadorAmbiental_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.LblUsuario.Text = FrmPrincipal.LblUserName.Text
        Me.LblArea.Text = FrmPrincipal.LblUserName.Text
        'Me.LblTipoFlujos.Text = FrmPrincipal.lbltipoflujo.Text
    End Sub

    Private Sub BtnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBuscar.Click
        llenardatagridviewToneladas()
        Llenar_TotalToneladasDia()
    End Sub

    Private Sub llenardatagridviewToneladas()
        'cargar DataGrid de Preparacion Daily
        Cn.Open()
        Dim ds As New DataSet
        Dim da As New SqlDataAdapter
        Dim sql As String
        sql = "SELECT     Fecha,  TonHumeda , ToneladaSeca FROM         Amb_TonProcesadas   WHERE         Fecha>=  '" & Convert.ToDateTime(DtInicio.Text) & "' and   Fecha<=  '" & Convert.ToDateTime(DtFinal.Text) & "' order by  Fecha"
        da.SelectCommand = New SqlCommand(sql, Cn)
        da.Fill(ds)
        Cn.Close()
        Dim dt As DataTable = ds.Tables(0)
        DgToneladas.DataSource = dt
        DgToneladas.AutoResizeColumns()
        DgToneladas.Columns("TonHumeda").DefaultCellStyle.Format = "0.00"
        DgToneladas.Columns("ToneladaSeca").DefaultCellStyle.Format = "0.00"

        DgToneladas.Columns("TonHumeda").HeaderText = "Tonelada Humeda"
        DgToneladas.Columns("ToneladaSeca").HeaderText = "Tonelada Seca"

        '---------------------------------------------------------------------------------------



        Me.DgToneladas.ReadOnly = False
    End Sub

    Private Sub llenardatagridviewFlujometroRelaveras()
        'cargar DataGrid de Preparacion Daily
        Cn.Open()
        Dim ds As New DataSet
        Dim da As New SqlDataAdapter
        Dim sql As String
        sql = "SELECT     Fecha,  M3_Dia , lt_segundo FROM Am_FlujometroBulk_litrosporsegundo   WHERE         Fecha>=  '" & CDate(DtinicioRelavera.Text) & "' and   Fecha<=  '" & CDate(DtFinalRelavera.Text) & "' order by  Fecha"
        da.SelectCommand = New SqlCommand(sql, Cn)
        da.Fill(ds)
        Cn.Close()
        Dim dt As DataTable = ds.Tables(0)
        DgRelaveras.DataSource = dt
        DgRelaveras.AutoResizeColumns()
        DgRelaveras.Columns("M3_Dia").DefaultCellStyle.Format = "0.00"
        DgRelaveras.Columns("lt_segundo").DefaultCellStyle.Format = "0.00"
        DgRelaveras.Columns("M3_Dia").HeaderText = "Metros Cubicos Dia"
        DgRelaveras.Columns("lt_segundo").HeaderText = "Litros por Segundo"
        Me.DgRelaveras.ReadOnly = False
    End Sub

    Private Sub llenardatagridviewFlujometroE5()
        'cargar DataGrid de Preparacion Daily
        Cn.Open()
        Dim ds As New DataSet
        Dim da As New SqlDataAdapter
        Dim sql As String
        sql = "SELECT     Fecha,  M3_Dia , lt_segundo FROM Am_FlujometroEsp5_litrosporsegundo   WHERE         Fecha>=  '" & CDate(DtInicioE5.Text) & "' and   Fecha<=  '" & CDate(DtFinalE5.Text) & "' order by  Fecha"
        da.SelectCommand = New SqlCommand(sql, Cn)
        da.Fill(ds)
        Cn.Close()
        Dim dt As DataTable = ds.Tables(0)
        DgE5.DataSource = dt
        DgE5.AutoResizeColumns()
        DgE5.Columns("M3_Dia").DefaultCellStyle.Format = "0.00"
        DgE5.Columns("lt_segundo").DefaultCellStyle.Format = "0.00"
        DgE5.Columns("M3_Dia").HeaderText = "Metros Cubicos Dia"
        DgE5.Columns("lt_segundo").HeaderText = "Litros por Segundo"
        Me.DgE5.ReadOnly = False
    End Sub

    Private Sub llenardatagridviewStari()
        'cargar DataGrid de Preparacion Daily
        Cn.Open()
        Dim ds As New DataSet
        Dim da As New SqlDataAdapter
        Dim sql As String
        sql = "SELECT      Fecha, HoraInicio, Densidad, Cianuro FROM Amb_MonitoreoStari   WHERE         Fecha>=  '" & CDate(DtInicioMonitoreo.Text) & "' and   Fecha<=  '" & CDate(DtFinalMonitreo.Text) & "' order by  Fecha"
        da.SelectCommand = New SqlCommand(sql, Cn)
        da.Fill(ds)
        Cn.Close()
        Dim dt As DataTable = ds.Tables(0)
        DgMonitoreoStari.DataSource = dt
        DgMonitoreoStari.AutoResizeColumns()
        DgMonitoreoStari.Columns("Cianuro").DefaultCellStyle.Format = "0.00"
        DgMonitoreoStari.Columns("HoraInicio").HeaderText = "Horas de Monitoreo"
        DgMonitoreoStari.Columns("Cianuro").HeaderText = "Conc. de Cianuro ppm"
        Me.DgMonitoreoStari.ReadOnly = False
    End Sub



    Private Sub llenardatagridviewSalidaStari()
        'cargar DataGrid de Preparacion Daily
        Cn.Open()
        Dim ds As New DataSet
        Dim da As New SqlDataAdapter
        Dim sql As String
        sql = "SELECT      Fecha, HoraInicio, Densidad, Cianuro FROM Amb_SalidaStari   WHERE         Fecha>=  '" & CDate(DtFecha1Strari.Text) & "' and   Fecha<=  '" & CDate(DtFecha2Stari.Text) & "' order by  Fecha"
        da.SelectCommand = New SqlCommand(sql, Cn)
        da.Fill(ds)
        Cn.Close()
        Dim dt As DataTable = ds.Tables(0)
        DgSalidaStari.DataSource = dt
        DgSalidaStari.AutoResizeColumns()
        DgSalidaStari.Columns("Cianuro").DefaultCellStyle.Format = "0.00"
        DgSalidaStari.Columns("HoraInicio").HeaderText = "Horas de Monitoreo"
        DgSalidaStari.Columns("Cianuro").HeaderText = "Conc. de Cianuro ppm"
        Me.DgSalidaStari.ReadOnly = False
    End Sub

    Private Sub llenardatagridviewConsumoAgua()
        'cargar DataGrid de Preparacion Daily
        Cn.Open()
        Dim ds As New DataSet
        Dim da As New SqlDataAdapter
        Dim sql As String
        sql = "SELECT      Fecha, ConsumoTotalAgua FROM PB_Operation   WHERE         Fecha>=  '" & CDate(DtFechaIniciaconsumo.Text) & "' and   Fecha<=  '" & CDate(DtFechaFinalConsumo.Text) & "'  and        (ConsumoTotalAgua >= 0) order by  Fecha"
        da.SelectCommand = New SqlCommand(sql, Cn)
        da.Fill(ds)
        Cn.Close()
        Dim dt As DataTable = ds.Tables(0)
        DgConsumoAgua.DataSource = dt
        DgConsumoAgua.AutoResizeColumns()
        'DgSalidaStari.Columns("Cianuro").DefaultCellStyle.Format = "0.00"
        'DgSalidaStari.Columns("HoraInicio").HeaderText = "Horas de Monitoreo"
        'DgSalidaStari.Columns("Cianuro").HeaderText = "Conc. de Cianuro ppm"
        Me.DgConsumoAgua.ReadOnly = False
    End Sub


    Private Sub llenardatagridviewHorasDeoperacion()
        'cargar DataGrid de Preparacion Daily
        Cn.Open()
        Dim ds As New DataSet
        Dim da As New SqlDataAdapter
        Dim sql As String
        sql = "SELECT     Fecha,  TotalHorasDia FROM Amb_HorasDeOperacion   WHERE         Fecha>=  '" & CDate(DtInicioHoras.Text) & "' and   Fecha<=  '" & CDate(DtFinalHOras.Text) & "' order by  Fecha"
        da.SelectCommand = New SqlCommand(sql, Cn)
        da.Fill(ds)
        Cn.Close()
        Dim dt As DataTable = ds.Tables(0)
        DgHorasdoperacione.DataSource = dt
        DgHorasdoperacione.AutoResizeColumns()
        DgHorasdoperacione.Columns("TotalHorasDia").DefaultCellStyle.Format = "0.00"
        DgHorasdoperacione.Columns("TotalHorasDia").HeaderText = "Horas de Operacion Alimento a Molino"
        Me.DgHorasdoperacione.ReadOnly = False
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        llenardatagridviewFlujometroRelaveras()
        Llenar_TotalRelavera()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        llenardatagridviewHorasDeoperacion()
        Llenar_TotalHorometroMolino()
    End Sub

    Private Sub Llenar_TotalHorometroMolino()

        Dim horasoperacion As Decimal
        horasoperacion = 0
        Dim registros As Decimal
        registros = 0
        For Each dRow As DataGridViewRow In DgHorasdoperacione.Rows
            If (dRow.Cells.Item("fecha").Value) IsNot Nothing Then

                If IsDBNull(dRow.Cells.Item("TotalHorasDia").Value) Then

                Else
                    horasoperacion = CDec(dRow.Cells.Item("TotalHorasDia").Value) + horasoperacion
                    registros = registros + 1
                End If

            End If

        Next dRow
        LblHorasMolienda.Text = CStr(Format(horasoperacion, "0.00"))
        LbldiasOpe.Text = CStr(Format(registros, "0.00"))
        Me.DgHorasdoperacione.ReadOnly = False
    End Sub
    Private Sub Llenar_TotalRelavera()

        Dim metroscubicos As Decimal
        metroscubicos = 0
        Dim registros As Decimal
        registros = 0
        For Each dRow As DataGridViewRow In DgRelaveras.Rows
            If (dRow.Cells.Item("fecha").Value) IsNot Nothing Then

                If IsDBNull(dRow.Cells.Item("M3_Dia").Value) Then

                Else
                    metroscubicos = CDec(dRow.Cells.Item("M3_Dia").Value) + metroscubicos
                    registros = registros + 1
                End If

            End If

        Next dRow
        LblTotalm3.Text = CStr(Format(metroscubicos, "0.00"))
        LblDiasFlujo.Text = CStr(Format(registros, "0.00"))
        LbldFlujos.Text = CStr(Format(metroscubicos / registros, "0.00"))

        Me.DgHorasdoperacione.ReadOnly = False
    End Sub

    Private Sub Llenar_TotalFlujoe5()

        Dim metroscubicos As Decimal
        metroscubicos = 0
        Dim registros As Decimal
        registros = 0
        For Each dRow As DataGridViewRow In DgE5.Rows
            If (dRow.Cells.Item("fecha").Value) IsNot Nothing Then

                If IsDBNull(dRow.Cells.Item("M3_Dia").Value) Then

                Else
                    metroscubicos = CDec(dRow.Cells.Item("M3_Dia").Value) + metroscubicos
                    registros = registros + 1
                End If

            End If

        Next dRow
        LblM3E5.Text = CStr(Format(metroscubicos, "0.00"))
        LblDiasE5.Text = CStr(Format(registros, "0.00"))
        LblPrmedioE5.Text = CStr(Format(metroscubicos / registros, "0.00"))

        Me.DgHorasdoperacione.ReadOnly = False
    End Sub




    Private Sub Llenar_TotalToneladasDia()

        Dim tonseca As Decimal
        tonseca = 0
        Dim registros As Decimal
        registros = 0
        For Each dRow As DataGridViewRow In DgToneladas.Rows
            If (dRow.Cells.Item("fecha").Value) IsNot Nothing Then

                If IsDBNull(dRow.Cells.Item("ToneladaSeca").Value) Then

                Else
                    tonseca = CDec(dRow.Cells.Item("ToneladaSeca").Value) + tonseca
                    registros = registros + 1
                End If

            End If

        Next dRow
        LblTotalToneladas.Text = CStr(Format(tonseca, "0.00"))
        lbldiaston.Text = CStr(Format(registros, "0.00"))
        lblpromediotondia.Text = CStr(Format(tonseca / registros, "0.00"))

        Me.DgToneladas.ReadOnly = False
    End Sub

    Private Sub Llenar_TotalConsumoAgua()

        Dim metroscubicos As Decimal
        metroscubicos = 0
        Dim registros As Decimal
        registros = 0
        For Each dRow As DataGridViewRow In DgConsumoAgua.Rows
            If (dRow.Cells.Item("fecha").Value) IsNot Nothing Then

                If IsDBNull(dRow.Cells.Item("ConsumoTotalAgua").Value) Then

                Else
                    metroscubicos = CDec(dRow.Cells.Item("ConsumoTotalAgua").Value) + metroscubicos
                    registros = registros + 1
                End If

            End If

        Next dRow
        lbltotalconsumoagua.Text = CStr(Format(metroscubicos, "0.00"))
        lbldiasconsumoagua.Text = CStr(Format(registros, "0.00"))
        lblpromedioconsumoagua.Text = CStr(Format(metroscubicos / registros, "0.00"))

        Me.DgConsumoAgua.ReadOnly = False
    End Sub


    Private Sub Label13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LblTotalm3.Click

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        llenardatagridviewFlujometroE5()
        Llenar_TotalFlujoe5()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        llenardatagridviewStari()
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        llenardatagridviewSalidaStari()
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        llenardatagridviewConsumoAgua()
        Llenar_TotalConsumoAgua()
    End Sub
End Class