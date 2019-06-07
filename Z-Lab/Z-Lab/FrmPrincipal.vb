
Option Explicit On
Option Strict On
Imports System.Data
Imports System.Data.SqlClient
Imports Z_Lab.Login
Imports System.Windows.Forms
Imports System.Configuration

Public Class FrmPrincipal
    Dim Cn As New SqlConnection(ConfigurationManager.AppSettings("StringConexion").ToString)
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

    Private Sub CargarAnalisisQuimicosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CargarAnalisisQuimicosToolStripMenuItem.Click
        My.Forms.FrmAssayMineralPlant.ShowDialog()
    End Sub

    Private Sub CargarAnalisisQuimicosZandorToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CargarAnalisisQuimicosZandorToolStripMenuItem.Click
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

    Private Sub CargarHumedadesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CargarHumedadesToolStripMenuItem.Click
        FrmCargarHumedad.ShowDialog()
    End Sub

    Private Sub IngresarDensidadToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IngresarDensidadToolStripMenuItem.Click

    End Sub

    Private Sub EspesadoresToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EspesadoresToolStripMenuItem.Click
        lbltipoflujo.Text = "Espesadores"
        FrmFlujos.ShowDialog()


    End Sub

    Private Sub AgitadoresToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AgitadoresToolStripMenuItem.Click
        lbltipoflujo.Text = "Agitadores"
        FrmFlujos.ShowDialog()


    End Sub

    Private Sub ConfiguracionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConfiguracionToolStripMenuItem.Click
        FrConfFlows.ShowDialog()

    End Sub

    Private Sub DensidadesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DensidadesToolStripMenuItem.Click
        FrmExportarFlujos.ShowDialog()
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

    Private Sub ImportarInstantaneasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImportarInstantaneasToolStripMenuItem.Click
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
        permisos("FrmGranulometria")
        FrmGranulometria.ShowDialog()
    End Sub

    Private Sub GravedadEspecificaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GravedadEspecificaToolStripMenuItem.Click
        FrmGravedadEspecifica.ShowDialog()
    End Sub

    Private Sub ExportardensidadToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        FrmReporDensidad.ShowDialog()
    End Sub

    Private Sub ExportFlujosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExportFlujosToolStripMenuItem.Click
        FrmExportarFlujos.Show()
    End Sub

    Private Sub CargarGravedadEspecificaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CargarGravedadEspecificaToolStripMenuItem.Click
        FrmCargarGravedadEspecifica.Show()
    End Sub

    Private Sub ImportarSinExcelToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImportarSinExcelToolStripMenuItem.Click
        FrmImportarSinExcel.Show()
    End Sub
End Class