
Option Explicit On
Option Strict On
Imports System.Data
Imports System.Data.SqlClient
Imports Z_Lab.Login
Imports System.Windows.Forms
Imports System.Configuration

Public Class FrmPrincipal
    Dim Cn As New SqlConnection(ConfigurationManager.ConnectionStrings.Item("StringConexion").ToString())
    Dim tipoflujo As String
    Private dt As DataTable
    Dim Da As New SqlDataAdapter
    Dim Cmd As New SqlCommand
    Dim Dataset As DataSet
    Private Sub AgregarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'My.Forms.FrmMuestras.ShowDialog()
    End Sub

    Private Sub FrmPrincipal_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.LblUserName.Text = Login.TxtUsuario.Text
        Me.Location = Screen.PrimaryScreen.WorkingArea.Location
        Me.Size = Screen.PrimaryScreen.WorkingArea.Size
    End Sub
    Private Sub FrmPrincipal_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing
        Application.Exit()
    End Sub

    Private Sub DespacharToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'My.Forms.FrmDespacho.ShowDialog()
    End Sub

    Private Sub AnalisisQumicosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        My.Forms.FrmQc.ShowDialog()

    End Sub

    Private Sub ResumenProyectoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        My.Forms.FmConsTotalProyecto.ShowDialog()
    End Sub

    Private Sub ReporteTenorDiaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        My.Forms.FmConsTotalProyectoFinal.ShowDialog()
    End Sub

    Private Sub ReporteAvanceMesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        My.Forms.FrmAvanceMes.ShowDialog()
    End Sub

    Private Sub MineralPlantToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MineralPlantToolStripMenuItem.Click
        If permisos("MineralPlant") = True Then
            My.Forms.FrmMineralPlant.ShowDialog()
        Else
            MsgBox("No tiene Permisos para ingresar al formulario contacte a su administrador")
        End If
    End Sub

    Private Sub PreparacionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'My.Forms.FrmLabPreparacion.ShowDialog()
    End Sub

    Private Sub RecepcionDeMuestrasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub AnalisisQuimicoAuToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub CalculoDeHumedadToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub CargarAnalisisQuimicosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        My.Forms.FrmAssayMineralPlant.ShowDialog()
    End Sub

    Private Sub CargarAnalisisQuimicosZandorToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        My.Forms.FrmAssayLabZandor.ShowDialog()
    End Sub

    Private Sub MuestreoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MuestreoToolStripMenuItem.Click
        My.Forms.FrmMuestras.ShowDialog()
    End Sub

    Private Sub MerrilCroweToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MerrilCroweToolStripMenuItem.Click
        If permisos("FrmMerrilCroweReport") = True Then
            My.Forms.FrmMerrilCroweReport.ShowDialog()
        Else
            MsgBox("No tiene Permisos para ingresar al formulario contacte a su administrador")
        End If


    End Sub

    Private Sub AlimentoMolinoB12ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AlimentoMolinoB12ToolStripMenuItem.Click

        If permisos("FrmConsultarBanda") = True Then
            My.Forms.FrmConsultarBanda.ShowDialog()
        Else
            MsgBox("No tiene Permisos para ingresar al formulario contacte a su administrador")
        End If

    End Sub

    Private Sub CargarHumedadesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        FrmCargarHumedad.ShowDialog()
    End Sub

    Private Sub IngresarDensidadToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IngresarDensidadToolStripMenuItem.Click

    End Sub

    Private Sub EspesadoresToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EspesadoresToolStripMenuItem.Click
        If permisos("FrmFlujos") = True Then
            lbltipoflujo.Text = "Espesadores"
            FrmFlujos.ShowDialog()

        Else
            MsgBox("No tiene Permisos para ingresar al formulario contacte a su administrador")
        End If




    End Sub

    Private Sub AgitadoresToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AgitadoresToolStripMenuItem.Click
        If permisos("FrmFlujos") = True Then
            lbltipoflujo.Text = "Agitadores"
            FrmFlujos.ShowDialog()

        Else
            MsgBox("No tiene Permisos para ingresar al formulario contacte a su administrador")
        End If




    End Sub

    Private Sub ConfiguracionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConfiguracionToolStripMenuItem.Click
        If permisos("FrConfFlows") = True Then
            FrConfFlows.ShowDialog()
        Else
            MsgBox("No tiene Permisos para ingresar al formulario contacte a su administrador")
        End If



    End Sub

    Private Sub DensidadesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DensidadesToolStripMenuItem.Click
        If permisos("FrmExportarFlujos") = True Then
            FrmExportarFlujos.ShowDialog()
        Else
            MsgBox("No tiene Permisos para ingresar al formulario contacte a su administrador")
        End If


    End Sub

    Private Sub PruebaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub CargarInstantaneasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        FrmCargarInstantaneas.ShowDialog()
    End Sub

    Private Sub FundiciónToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FundiciónToolStripMenuItem.Click
        If permisos("FrmFundicion") = True Then
            FrmFundicion.ShowDialog()
        Else
            MsgBox("No tiene Permisos para ingresar al formulario contacte a su administrador")
        End If
    End Sub

    Private Sub PieDeBandaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PieDeBandaToolStripMenuItem.Click
        If permisos("FrmPiedeBanda12") = True Then
            FrmPiedeBanda12.ShowDialog()
        Else
            MsgBox("No tiene Permisos para ingresar al formulario contacte a su administrador")
        End If
    End Sub


    Private Sub MuestrasInstantaneasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MuestrasInstantaneasToolStripMenuItem.Click

        If permisos("MineralPlant") = True Then
            FrmMuestrasInstantaneas.ShowDialog()
        Else
            MsgBox("No tiene Permisos para ingresar al formulario contacte a su administrador")
        End If

    End Sub

    Private Sub ImportarInstantaneasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        FrmCargarInstantaneas.ShowDialog()
    End Sub
    Private Function permisos(ByVal nombreformulario As String) As Boolean
        Dim DsPriv As New DataSet
        Dim EPermisos As New SqlClient.SqlDataAdapter("SELECT Usuario, idform FROM RfPermisoForms" & _
    " WHERE RfPermisoForms.Usuario='" & LblUserName.Text & "'  and (RfPermisoForms.idform  = '" & nombreformulario & "'  ) ", Cn)
        EPermisos.Fill(DsPriv, "RfPermisoForms")
        Dim myDataViewpermisos As DataView = New DataView(DsPriv.Tables("RfPermisoForms"))

        If myDataViewpermisos.Count = 0 Then
            'MsgBox("El usuario no tiene privilegios para Modificar en este Formulario. Contacte a su administrador.")
            permisos = False
        Else
            permisos = True
        End If
        Return (permisos)
    End Function


    Private Sub ConsumoDiarioToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConsumoDiarioToolStripMenuItem.Click
        FrmConsumoReactivos.ShowDialog()
    End Sub



    Private Sub AgregarReactivosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AgregarReactivosToolStripMenuItem.Click

    End Sub

    Private Sub GranulometríaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GranulometríaToolStripMenuItem.Click
        If permisos("FrmGranulometria") = True Then
            FrmGranulometria.ShowDialog()
        Else
            MsgBox("No tiene Permisos para ingresar al formulario contacte a su administrador")
        End If

        'permisos("FrmGranulometria")

    End Sub

    Private Sub GravedadEspecificaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GravedadEspecificaToolStripMenuItem.Click
        If permisos("FrmGravedadEspecifica") = True Then
            FrmGravedadEspecifica.ShowDialog()
        Else
            MsgBox("No tiene Permisos para ingresar al formulario contacte a su administrador")
        End If


    End Sub

    Private Sub ExportardensidadToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        If permisos("FrmReporDensidad") = True Then
            FrmReporDensidad.ShowDialog()
        Else
            MsgBox("No tiene Permisos para ingresar al formulario contacte a su administrador")
        End If

    End Sub

    Private Sub ExportFlujosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If permisos("FrmExportarFlujos") = True Then
            FrmExportarFlujos.Show()
        Else
            MsgBox("No tiene Permisos para ingresar al formulario contacte a su administrador")
        End If

    End Sub

    Private Sub CargarGravedadEspecificaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If permisos("FrmCargarGravedadEspecifica") = True Then
            FrmCargarGravedadEspecifica.Show()
        Else
            MsgBox("No tiene Permisos para ingresar al formulario contacte a su administrador")
        End If

    End Sub



    Private Sub ImportarBasculaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImportarBasculaToolStripMenuItem.Click

        If permisos("FrmImportarBasculaDbMEtal") = True Then
            FrmImportarBasculaDbMEtal.Show()
        Else
            MsgBox("No tiene Permisos para ingresar al formulario contacte a su administrador")
        End If


    End Sub

    Private Sub ReporteVertimientoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReporteVertimientoToolStripMenuItem.Click
        If permisos("FrmReporteVertimimiento") = True Then
            FrmReporteVertimimiento.Show()
        Else
            MsgBox("No tiene Permisos para ingresar al formulario contacte a su administrador")
        End If


    End Sub

    Private Sub BalanceMetalurgicoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BalanceMetalurgicoToolStripMenuItem.Click
        If permisos("FrmBalanceMetalurgico") = True Then
            FrmBalanceMetalurgico.Show()
        Else
            MsgBox("No tiene Permisos para ingresar al formulario contacte a su administrador")
        End If

    End Sub

    Private Sub ImportarAnalisisQuimicosSGSToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImportarAnalisisQuimicosSGSToolStripMenuItem.Click
        If permisos("FrmAssayMineralPlant") = True Then
            My.Forms.FrmAssayMineralPlant.ShowDialog()
        Else
            MsgBox("No tiene Permisos para ingresar al formulario contacte a su administrador")
        End If


    End Sub

    Private Sub ImportarAnalisisQuimicosZandorToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImportarAnalisisQuimicosZandorToolStripMenuItem.Click
        If permisos("FrmAssayLabZandor") = True Then
            My.Forms.FrmAssayLabZandor.ShowDialog()
        Else
            MsgBox("No tiene Permisos para ingresar al formulario contacte a su administrador")
        End If

    End Sub

    Private Sub GravedadEspecificaToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GravedadEspecificaToolStripMenuItem1.Click
        If permisos("FrmCargarGravedadEspecifica") = True Then
            FrmCargarGravedadEspecifica.ShowDialog()
        Else
            MsgBox("No tiene Permisos para ingresar al formulario contacte a su administrador")
        End If


    End Sub

    Private Sub HumedadToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HumedadToolStripMenuItem.Click
        If permisos("FrmCargarHumedad") = True Then
            FrmCargarHumedad.ShowDialog()
        Else
            MsgBox("No tiene Permisos para ingresar al formulario contacte a su administrador")
        End If


    End Sub


    Private Sub ExportarFlujosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExportarFlujosToolStripMenuItem.Click
        If permisos("FrmExportarFlujos") = True Then
            FrmExportarFlujos.Show()
        Else
            MsgBox("No tiene Permisos para ingresar al formulario contacte a su administrador")
        End If


    End Sub

    Private Sub MuestrasInstantaneasToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MuestrasInstantaneasToolStripMenuItem1.Click
        If permisos("FrmCargarInstantaneas") = True Then
            FrmCargarInstantaneas.Show()
        Else
            MsgBox("No tiene Permisos para ingresar al formulario contacte a su administrador")
        End If


    End Sub

    Private Sub GraficoTenoresToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GraficoTenoresToolStripMenuItem.Click
        If permisos("FrmGraficoTenores") = True Then
            FrmGraficoTenores.Show()
        Else
            MsgBox("No tiene Permisos para ingresar al formulario contacte a su administrador")
        End If
    End Sub

    Private Sub ConsumoDeCianuroToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConsumoDeCianuroToolStripMenuItem.Click
        If permisos("FrmConsumoCianuro") = True Then
            FrmConsumoCianuro.Show()
        Else
            MsgBox("No tiene Permisos para ingresar al formulario contacte a su administrador")
        End If

    End Sub

    Private Sub MinerasToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MinerasToolStripMenuItem1.Click
        If permisos("FrmImportarMinerasDbMetal") = True Then
            FrmImportarMinerasDbMetal.Show()
        Else
            MsgBox("No tiene Permisos para ingresar al formulario contacte a su administrador")
        End If


    End Sub

    Private Sub GraficoTenoresMinerasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GraficoTenoresMinerasToolStripMenuItem.Click
        If permisos("FrmGraficoMineras") = True Then
            FrmGraficoMineras.Show()
        Else
            MsgBox("No tiene Permisos para ingresar al formulario contacte a su administrador")
        End If


    End Sub

    Private Sub GraficoOnzasProcesosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GraficoOnzasProcesosToolStripMenuItem.Click
        If permisos("FrmGraficoOnzas") = True Then
            FrmGraficoOnzas.Show()
        Else
            MsgBox("No tiene Permisos para ingresar al formulario contacte a su administrador")
        End If


    End Sub

    Private Sub GraficosBalanceFisicoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GraficosBalanceFisicoToolStripMenuItem.Click

        If permisos("FrmGraficosBalanceMetalurgico") = True Then
            FrmGraficosBalanceMetalurgico.Show()
        Else
            MsgBox("No tiene Permisos para ingresar al formulario contacte a su administrador")
        End If

    End Sub

    Private Sub InventarioDeAuEnPlantaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InventarioDeAuEnPlantaToolStripMenuItem.Click
        If permisos("FrmInventarioAudePlanta") = True Then
            FrmInventarioAudePlanta.Show()
        Else
            MsgBox("No tiene Permisos para ingresar al formulario contacte a su administrador")
        End If
    End Sub

    Private Sub SSTSolidosEnSuspencionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SSTSolidosEnSuspencionToolStripMenuItem.Click
        If permisos("FrmImportarSST") = True Then
            FrmImportarSST.Show()
        Else
            MsgBox("No tiene Permisos para ingresar al formulario contacte a su administrador")
        End If
    End Sub

    Private Sub SSTSòlidosEnSuspensiònToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SSTSòlidosEnSuspensiònToolStripMenuItem.Click
        If permisos("FrmSST") = True Then
            FrmSST.Show()
        Else
            MsgBox("No tiene Permisos para ingresar al formulario contacte a su administrador")
        End If
    End Sub

    Private Sub GraficosEficienciaProcesosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GraficosEficienciaProcesosToolStripMenuItem.Click

        If permisos("FrmEficienciaProcesos") = True Then
            FrmEficienciaProcesos.Show()
        Else
            MsgBox("No tiene Permisos para ingresar al formulario contacte a su administrador")
        End If

    End Sub

    Private Sub IndicadoresAmbienteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IndicadoresAmbienteToolStripMenuItem.Click

        If permisos("FrmIndicadorAmbiental") = True Then
            FrmIndicadorAmbiental.Show()
        Else
            MsgBox("No tiene Permisos para ingresar al formulario contacte a su administrador")
        End If
    End Sub



    Private Sub GestionDeUsuariosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GestionDeUsuariosToolStripMenuItem.Click
        If permisos("FrmUsuarios") = True Then
            FrmUsuarios.Show()
        Else
            MsgBox("No tiene Permisos para ingresar al formulario contacte a su administrador")
        End If
    End Sub

    Private Sub DespacharMuestraLabToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DespacharMuestraLabToolStripMenuItem.Click

    End Sub

    Private Sub ReactivosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReactivosToolStripMenuItem.Click
        FrmCargarReactivos.Show()
    End Sub
End Class