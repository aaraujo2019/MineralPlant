
Option Explicit On
Option Strict On
Imports System.Data
Imports System.Data.SqlClient
Imports Z_Lab.Login
Imports System.Data.OleDb
Imports System.Windows.Forms
Imports Z_Lab.FrmPrincipal
Imports System.Math
Public Class FrmBalanceMetalurgico
    Private dt As DataTable
    Dim Da As New SqlDataAdapter
    Dim Cmd As New SqlCommand
    Dim Dataset As DataSet
    ' Dim Cn1 As New SqlConnection(ConexionBd())
    Dim Cn As New SqlConnection("Server=SEGSVRSQL01;uid=sa;pwd=*Bd6r4nC0l0mb1a*;database=PlantaBeneficio")
    Dim editarfundicion As Boolean
    Dim conn As New ADODB.Connection()
    Dim rstoperacion As New ADODB.Recordset()
    Dim Rsfundicion As New ADODB.Recordset()
    Dim cnStr As String
    Private Sub Label2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label2.Click

    End Sub

    Private Sub FrmBalanceMetalurgico_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.LblUsuario.Text = FrmPrincipal.LblUserName.Text
        CargarAno()
        llenardatagridviewBalanceFisico()
        editarfundicion = False
    End Sub

    Private Sub CmdBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdBuscar.Click
        ' AND PERIODO = '" & (cmbperiodo2.Text) & "'

        cnStr = "Provider=SQLNCLI10;Initial Catalog=PlantaBeneficio;Data Source=SEGSVRSQL01; User ID=sa;Password=*Bd6r4nC0l0mb1a*;"
        conn.Open(cnStr)
        Rsfundicion = conn.Execute(" SELECT * FROM         Pb_BalanceFisico WHERE ano = '" & (cmbano.Text) & "'  AND MES = '" & (cmbmes.Text) & "'  AND PERIODO = '" & (cmbperiodo2.Text) & "'       ")
        If Rsfundicion.EOF = True Then
            MsgBox("No Existe")
            DtFecha1.Value = Today
            LblToneladas.Text = "000"
            LblAlimentoMolino.Text = "000"
            LblTenorMolino.Text = "000"
            LblTenorColas.Text = "000"
            LblOroRecuperado.Text = "000"
            LblPorcRecuperacion.Text = "000"
            LblAuFundido.Text = "000"
            LblAuBFisico.Text = "000"
            LblAuRecuperadoFisico.Text = "000"
            LblTenorCalculadoBFisico.Text = "000"
            LblRecuperacionCalculadaBFisico.Text = "000"

        Else
            'Me.DtFecha1.Value = CDate((Rsfundicion.Fields("FECHA").Value))
            LblToneladas.Text = CStr(Math.Round(CDbl(Rsfundicion.Fields("Toneladas").Value), 2))
            LblAlimentoMolino.Text = CStr(Math.Round(CDbl(Rsfundicion.Fields("OnzasAlimentadas").Value), 2))
            LblTenorMolino.Text = CStr(Math.Round(CDbl(Rsfundicion.Fields("TenorReporteDiario").Value), 2))
            LblTenorColas.Text = CStr(Math.Round(CDbl(Rsfundicion.Fields("TenorColas").Value), 2))
            LblOroRecuperado.Text = CStr(Math.Round(CDbl(Rsfundicion.Fields("OroRecuperadoRDiario").Value), 2))
            LblPorcRecuperacion.Text = CStr(Math.Round(CDbl(Rsfundicion.Fields("RecuperacionMetalurgica").Value), 2))
            LblAuFundido.Text = CStr(Math.Round(CDbl(Rsfundicion.Fields("OnzasFundidas").Value), 2))
            LblAuBFisico.Text = CStr(Math.Round(CDbl(Rsfundicion.Fields("OroProcesadoBFisico").Value), 2))
            LblAuRecuperadoFisico.Text = CStr(Math.Round(CDbl(Rsfundicion.Fields("OroRecuperadoBFisico").Value), 2))
            LblTenorCalculadoBFisico.Text = CStr(Math.Round(CDbl(Rsfundicion.Fields("TenorCalculadoBFisico").Value), 2))
            LblRecuperacionCalculadaBFisico.Text = CStr(Math.Round(CDbl(Rsfundicion.Fields("RecuperacionCalculadaBFisico").Value), 2))

        End If
        conn.Close()
    End Sub
    Private Sub CargarAno()
        With Cmd
            .CommandType = CommandType.Text
            .CommandText = " SELECT     Ano   FROM PB_Fundicion GROUP BY Ano HAVING     Ano IS NOT NULL"
            .Connection = Cn
        End With
        Da.SelectCommand = Cmd
        dt = New DataTable
        Da.Fill(dt)
        With cmbano
            .DataSource = dt
            .DisplayMember = "ano"
            .ValueMember = "ano"
        End With
    End Sub

    Private Sub DgBalance_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgBalanceFisico.CellClick
        Try
            'Aquí pongo lo que pasaría si el campo está en blanco o nulo

            If DBNull.Value.Equals(DgBalanceFisico.CurrentRow.Cells("ano").Value) Or DBNull.Value.Equals(DgBalanceFisico.CurrentRow.Cells("toneladas").Value) Or DBNull.Value.Equals(DgBalanceFisico.CurrentRow.Cells("OnzasAlimentadas").Value) Then
                DtFecha1.Value = Today
                LblToneladas.Text = "000"
                LblAlimentoMolino.Text = "000"
                LblTenorMolino.Text = "000"
                LblTenorColas.Text = "000"
                LblOroRecuperado.Text = "000"
                LblPorcRecuperacion.Text = "000"
                LblAuFundido.Text = "000"
                LblAuBFisico.Text = "000"
                LblAuRecuperadoFisico.Text = "000"
                LblTenorCalculadoBFisico.Text = "000"
                LblRecuperacionCalculadaBFisico.Text = "000"
            Else

                LblToneladas.Text = CStr(Format(Me.DgBalanceFisico.Rows(e.RowIndex).Cells("toneladas").Value(), "##,##0.0"))
                LblAlimentoMolino.Text = CStr(Format(Me.DgBalanceFisico.Rows(e.RowIndex).Cells("OnzasAlimentadas").Value(), "##,##0.0"))
                LblTenorMolino.Text = CStr(Format(Me.DgBalanceFisico.Rows(e.RowIndex).Cells("TenorReporteDiario").Value(), "##,##0.00"))
                LblTenorColas.Text = CStr(Format(Me.DgBalanceFisico.Rows(e.RowIndex).Cells("TenorColas").Value(), "##,##0.00"))
                LblOroRecuperado.Text = CStr(Format(Me.DgBalanceFisico.Rows(e.RowIndex).Cells("OroRecuperadoRDiario").Value(), "##,##0.0"))
                LblPorcRecuperacion.Text = CStr(Format(Me.DgBalanceFisico.Rows(e.RowIndex).Cells("RecuperacionMetalurgica").Value(), "##,##0.00"))
                LblAuFundido.Text = CStr(Format(Me.DgBalanceFisico.Rows(e.RowIndex).Cells("OnzasFundidas").Value(), "##,##0.0"))
                LblAuBFisico.Text = CStr(Format(Me.DgBalanceFisico.Rows(e.RowIndex).Cells("OroProcesadoBFisico").Value(), "##,##0.00"))
                LblAuRecuperadoFisico.Text = CStr(Format(Me.DgBalanceFisico.Rows(e.RowIndex).Cells("OroRecuperadoBFisico").Value(), "##,##0.00"))
                LblTenorCalculadoBFisico.Text = CStr(Format(Me.DgBalanceFisico.Rows(e.RowIndex).Cells("TenorCalculadoBFisico").Value(), "##,##0.00"))
                LblRecuperacionCalculadaBFisico.Text = CStr(Format(Me.DgBalanceFisico.Rows(e.RowIndex).Cells("RecuperacionCalculadaBFisico").Value(), "##,##0.00"))
                TxtInvFinal.Text = CStr(Format(Me.DgBalanceFisico.Rows(e.RowIndex).Cells("inventarioplanta").Value(), "##,##0.0"))
                TxtInvInicial.Text = CStr(Format(Me.DgBalanceFisico.Rows(e.RowIndex).Cells("inventarioanterior").Value(), "##,##0.0"))
                ' TxtOroEncolas.Text = CStr(Format(Me.DgBalanceFisico.Rows(e.RowIndex).Cells("OroEnColas").Value(), "##,##0.0"))
                cmbano.Text = CStr(Me.DgBalanceFisico.Rows(e.RowIndex).Cells("ano").Value())
                cmbmes.Text = CStr(Me.DgBalanceFisico.Rows(e.RowIndex).Cells("mes").Value())
                cmbperiodo2.Text = CStr(Me.DgBalanceFisico.Rows(e.RowIndex).Cells("periodo").Value())
                'TxtInvInicial.Text = CStr(Format(Me.DgBalanceFisico.Rows(e.RowIndex).Cells("inventarioanterior").Value(), "##,##0.0"))

                DtFecha1.Value = CDate(Me.DgBalanceFisico.Rows(e.RowIndex).Cells("FechaInicial").Value())
                DtFecha2.Value = CDate(Me.DgBalanceFisico.Rows(e.RowIndex).Cells("FechaFinal").Value())
                editarfundicion = True
            End If
        Catch ex As Exception
            ' Handle the exception.
            MessageBox.Show(ex.Message, Me.Text, _
  MessageBoxButtons.OK, MessageBoxIcon.Error)

            DtFecha1.Value = Today
            LblToneladas.Text = "000"
            LblAlimentoMolino.Text = "000"
            LblTenorMolino.Text = "000"
            LblTenorColas.Text = "000"
            LblOroRecuperado.Text = "000"
            LblPorcRecuperacion.Text = "000"
            LblAuFundido.Text = "000"
            LblAuBFisico.Text = "000"
            LblAuRecuperadoFisico.Text = "000"
            LblTenorCalculadoBFisico.Text = "000"
            LblRecuperacionCalculadaBFisico.Text = "000"
            TxtInvFinal.Clear()
            TxtInvInicial.Clear()
        End Try

    End Sub





    Private Sub llenardatagridviewBalanceFisico()
        'cargar DataGrid de Preparacion Daily
        Cn.Open()
        Dim ds As New DataSet
        Dim da As New SqlDataAdapter
        Dim sql As String
        sql = "SELECT     Ano, Mes, Periodo, Toneladas, TenorReporteDiario, OnzasAlimentadas, OroEnColas, TenorColas , OroRecuperadoRDiario ,RecuperacionMetalurgica , OnzasFundidas , OroProcesadoBFisico, OroRecuperadoBFisico, OroAFavorDelBalance, TenorCalculadoBFisico , RecuperacionCalculadaBFisico , inventarioplanta , inventarioanterior , FechaInicial , FechaFinal FROM         dbo.Pb_BalanceFisico ORDER BY Ano DESC, Mes, Periodo   "
        da.SelectCommand = New SqlCommand(sql, Cn)
        da.Fill(ds)
        Cn.Close()
        Dim dt As DataTable = ds.Tables(0)
        DgBalanceFisico.DataSource = dt
        'DgBalanceFisico.AutoResizeColumns()
        Me.DgBalanceFisico.RowHeadersWidth = 60
        DgBalanceFisico.Columns("OroEnColas").DefaultCellStyle.Format = "0.00"
        DgBalanceFisico.Columns("TenorColas").DefaultCellStyle.Format = "0.00"
        DgBalanceFisico.Columns("RecuperacionMetalurgica").DefaultCellStyle.Format = "0.00"
        DgBalanceFisico.Columns("RecuperacionCalculadaBFisico").DefaultCellStyle.Format = "0.00"
        DgBalanceFisico.Columns("TenorCalculadoBFisico").DefaultCellStyle.Format = "0.00"
        DgBalanceFisico.Columns("TenorReporteDiario").DefaultCellStyle.Format = "0.00"
        DgBalanceFisico.Columns("OnzasFundidas").DefaultCellStyle.Format = "0.00"
        DgBalanceFisico.Columns("Ano").HeaderText = "Año"
        DgBalanceFisico.Columns("OnzasFundidas").HeaderText = "Onzas Fundidas"
        DgBalanceFisico.Columns("mes").HeaderText = "Mes"
        DgBalanceFisico.Columns("Periodo").HeaderText = "Periodo"
        DgBalanceFisico.Columns("Toneladas").HeaderText = "Toneladas Procesadas"
        DgBalanceFisico.Columns("OnzasAlimentadas").HeaderText = "Onzas Ingresadas"
        DgBalanceFisico.Columns("OroEnColas").HeaderText = "Onzas de Au en Colas"
        DgBalanceFisico.Columns("OroRecuperadoRDiario").HeaderText = "Oro Recuperado"
        DgBalanceFisico.Columns("OroRecuperadoBFisico").HeaderText = "Oro Recuperado por Balance Fisico"
        DgBalanceFisico.Columns("OroProcesadoBFisico").HeaderText = "Oro Procesado por Balance Fisico"
        DgBalanceFisico.Columns("TenorCalculadoBFisico").HeaderText = "Tenor Calculado  Balance"
        DgBalanceFisico.Columns("TenorReporteDiario").HeaderText = "Tenor"
        DgBalanceFisico.Columns("inventarioanterior").HeaderText = "Inventario Inicial"
        DgBalanceFisico.Columns("inventarioplanta").HeaderText = "Inventario Final"
        DgBalanceFisico.Columns("RecuperacionCalculadaBFisico").HeaderText = "Recuperacion Calculada por Balance"
        DgBalanceFisico.Columns("RecuperacionMetalurgica").HeaderText = "Recuperacion Metalurgica"


        ' Dgfundicion.Columns("Espesador").HeaderText = "Espesador-Agitador"
        ' Dgfundicion.Columns("Tonsecalixi").HeaderText = "Toneladas Seca"
        ' Dgfundicion.Columns("AuFinal_ppm").HeaderText = "Tenor Gr/Ton"
        'Dgfundicion.Columns("AlimentoGr").HeaderText = "Total Gr de Au."
        Dim metrospreparacion As Decimal
        metrospreparacion = 0

        Me.DgBalanceFisico.ReadOnly = False
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim DsPriv As New DataSet
        Dim EPermisos As New SqlClient.SqlDataAdapter("SELECT Usuario, IdEvento FROM RfUserEvent" & _
" WHERE RfUserEvent.Usuario='" & LblUsuario.Text & "'  and (RfUserEvent.IdEvento  = 'Modificarfundicion'  ) ", Cn)
        EPermisos.Fill(DsPriv, "RfUserEvent")
        Dim myDataViewpermisos As DataView = New DataView(DsPriv.Tables("RfUserEvent"))

        If myDataViewpermisos.Count = 0 Then
            MsgBox("El usuario no tiene privilegios para Modificar en este Formulario. Contacte a su administrador.")
            Exit Sub
        End If
        If cmbperiodo2.Text = "" Or cmbano.Text = "" Or cmbmes.Text = "" Then
            MsgBox("Por favor Diligencie correctamente el formulario")
        Else
            Try
                Dim sqlConnectiondb As New System.Data.SqlClient.SqlConnection("Server=SEGSVRSQL01;uid=sa;pwd=*Bd6r4nC0l0mb1a*;database=PlantaBeneficio")
                Dim cmd As New System.Data.SqlClient.SqlCommand
                cmd.CommandType = System.Data.CommandType.Text

                If editarfundicion = True Then
                    'CONSULTA CUANDO EDITAR ES VERDADERO
                    cmd.CommandText = "UPDATE  Pb_BalanceFisico  SET FechaInicial = @FechaInicial,  FechaFinal= @FechaFinal  WHERE Periodo=@Periodo and ano=@ano and mes=@mes  "
                Else
                    ' consulta sql si editar es falso 
                    cmd.CommandText = "INSERT INTO Pb_BalanceFisico (FechaInicial,FechaFinal ,   ano, mes,periodo  )VALUES(@FechaInicial,@FechaFinal, @ano, @mes, @periodo )"
                End If
                cmd.Parameters.AddWithValue("@FechaInicial", CDate(DtFecha1.Text))
                cmd.Parameters.AddWithValue("@FechaFinal", CDate(DtFecha2.Text))








                cmd.Parameters.AddWithValue("@Periodo", Convert.ToString(cmbperiodo2.Text))
                'cmd.Parameters.AddWithValue("@ano", CStr(Year(DtFecha1.Value)))
                cmd.Parameters.AddWithValue("@ano", CStr(cmbano.Text))
                ' cmd.Parameters.AddWithValue("@mes", CStr(Year(DtFecha2.Value)))
                cmd.Parameters.AddWithValue("@mes ", CStr(cmbmes.Text))

                'Periodo
                ' cmd.Parameters.AddWithValue("@IdConsecutivo", Convert.ToInt32(LblIdConsecutivo.Text))
                cmd.Connection = sqlConnectiondb
                sqlConnectiondb.Open()
                cmd.ExecuteNonQuery()
                sqlConnectiondb.Close()
                MessageBox.Show("Los datos se  guardaron Correctamente.")
                'Llenar_DataGridViewDesarrollo()
                llenardatagridviewBalanceFisico()
                TxtInvFinal.Clear()
                TxtInvFinal.Clear()
                cmbano.Text = ""
                cmbmes.Text = ""
                cmbperiodo2.Text = ""
                editarfundicion = False
                'DgLecturaBandas.FirstDisplayedScrollingRowIndex = DgLecturaBandas.RowCount - 1
            Catch ex As Exception
                ' Handle the exception.
                MessageBox.Show(ex.Message, Me.Text, _
      MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        End If
    End Sub

    Private Sub GroupBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox1.Enter

    End Sub
End Class