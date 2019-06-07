Option Explicit On
Option Strict On
Imports System.Data
Imports System.Data.SqlClient
Imports Z_Lab.Login
Imports System.Data.OleDb
Imports System.Windows.Forms
Imports System.Net.Mail

Public Class FrmMineralPlant
    Private dt As DataTable
    Dim Da As New SqlDataAdapter
    Dim Cmd As New SqlCommand
    Dim Dataset As DataSet
    Dim Cn As New SqlConnection("Server=SEGSVRSQL01;uid=sa;pwd=*Bd6r4nC0l0mb1a*;database=PlantaBeneficio")
    Dim editarlix As Boolean
    Dim editamuestra As Boolean
    Dim editaroperacion As Boolean
    Dim editarflujoe5 As Boolean
    Dim editaflujoflotacion As Boolean
    Dim editarbanda As Boolean
    Dim editaMerril As Boolean
    Dim editahorometro As Boolean
    Dim editahorometroknelson As Boolean
    Dim editaflujoRebalse As Boolean
    Dim conn As New ADODB.Connection()
    Dim rstoperacion As New ADODB.Recordset()
    Dim rstoperacionrep As New ADODB.Recordset()
    Dim rstLeaching As New ADODB.Recordset()
    Dim rstcolasflotacion As New ADODB.Recordset()
    Dim rstcolaslixiviacionS As New ADODB.Recordset()
    Dim rstcolaslixiviacionL As New ADODB.Recordset()
    Dim rstcolasflotacionSolu As New ADODB.Recordset()
    Dim rstcolaslixiviacionSolu As New ADODB.Recordset()
    Dim rsarea As New ADODB.Recordset()
    Dim rstmineras As New ADODB.Recordset()
    Dim rstoperationContract As New ADODB.Recordset()
    Dim rstAlimentoMerril As New ADODB.Recordset()
    Dim rstColasMerril As New ADODB.Recordset()
    Dim colassolucion As Decimal
    Dim colassolido As Decimal
    Dim rstConveyor As New ADODB.Recordset()
    Dim rstenorpromedio As New ADODB.Recordset()
    Dim rstenorpromedio2 As New ADODB.Recordset()
    Dim rstenor As New ADODB.Recordset()
    Dim rstenorzandor As New ADODB.Recordset()
    Dim rstenormineras As New ADODB.Recordset()
    Dim cnStr As String
    Private Sub FrmMineralPlant_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.LblUsuario.Text = FrmPrincipal.LblUserName.Text
            LblFechaReporte.Text = CStr(Format(DateTimePickerFechaReporte.Value, "yyyy-MM-dd"))
            cargararea()
            CargarlistHoraInicio()
            CargarlistHoraFinal()
            CargarCmbubicacion()
            ' CargarCmbFlujodeMasa()
            Llenar_DataGridViewDgSamplesDay()
            Llenar_DataGridViewDgMerrilCrowe()
            Llenar_DgHorometroKnelson()
            Llenar_DataGridViewDgFlujometroE5()
            Llenar_DataGridViewDgFlujometroFlotacion()
            CargarCmbOrigenConcentradodeFlotacion()
            Llenar_DataGridViewDgFlujometroRebalse()
        Catch ex As Exception
            ' Handle the exception.
            MessageBox.Show(ex.Message, Me.Text, _
  MessageBoxButtons.OK, MessageBoxIcon.Error)
            conn.Close()
        End Try
    End Sub


    Private Sub cargararea()
        cnStr = "Provider=SQLNCLI10;Initial Catalog=PlantaBeneficio;Data Source=SEGSVRSQL01; User ID=sa;Password=*Bd6r4nC0l0mb1a*;"
        conn.Open(cnStr)
        rsarea = conn.Execute(" SELECT * FROM         usuario WHERE (IdUsusario = '" & (LblUsuario.Text) & "')         ")
        If rsarea.EOF = True Then
            Me.LblArea.Text = "NO"
        Else
            Me.LblArea.Text = CStr((rsarea.Fields("Area").Value))
        End If
        conn.Close()
    End Sub

    Private Sub CmdSaveMuestras_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdSaveMuestras.Click
        'Consultar si el usuario posee permisos de escritura sobre el formulario
        Dim DsPriv As New DataSet
        Dim EPermisos As New SqlClient.SqlDataAdapter("SELECT Usuario, IdEvento FROM RfUserEvent" & _
" WHERE RfUserEvent.Usuario='" & LblUsuario.Text & "'  and (RfUserEvent.IdEvento  = 'ModificarMuestrasLab'  ) ", Cn)
        EPermisos.Fill(DsPriv, "RfUserEvent")
        Dim myDataViewpermisos As DataView = New DataView(DsPriv.Tables("RfUserEvent"))

        If myDataViewpermisos.Count = 0 Then
            MsgBox("El usuario no tiene privilegios para Modificar en este Formulario. Contacte a su administrador.")
            Exit Sub
        End If

        If TxtSample.Text = "" Or ListHFrom.Text = "" Or ListHTo.Text = "" Or CmbLocation.Text = "Seleccione" Or CmbSampleType.Text = "" Then
            MsgBox("Todos los campos son obligatorios, por favor Diligencie correctamente el formulario")
        Else
            Try
                Dim sqlConnectiondb As New System.Data.SqlClient.SqlConnection("Server=SEGSVRSQL01;uid=sa;pwd=*Bd6r4nC0l0mb1a*;database=PlantaBeneficio")
                Dim cmd As New System.Data.SqlClient.SqlCommand
                cmd.CommandType = System.Data.CommandType.Text
                If editamuestra = True Then
                    'CONSULTA CUANDO EDITAR ES VERDADERO
                    cmd.CommandText = "UPDATE  PB_Samples  SET   HoraInicial= @HoraInicial ,  HoraFinal= @HoraFinal ,  Ubicacion = @Ubicacion  , Dup = @Dup , TipoMuestra = @TipoMuestra , Comments= @Comments  WHERE  Muestra = @Muestra and Fecha=@Fecha "
                Else
                    ' consulta sql si editar es falso 
                    cmd.CommandText = "INSERT INTO PB_Samples (Muestra,HoraInicial,HoraFinal, Fecha,Ubicacion,TipoMuestra, Dup , Comments)VALUES(@Muestra ,@HoraInicial,@HoraFinal,@Fecha,@Ubicacion,@TipoMuestra , @Dup , @Comments)"
                End If
                cmd.Parameters.AddWithValue("@Muestra", Convert.ToString(TxtSample.Text))
                cmd.Parameters.AddWithValue("@HoraInicial", Convert.ToString(ListHFrom.Text))
                cmd.Parameters.AddWithValue("@HoraFinal", Convert.ToString(ListHTo.Text))
                cmd.Parameters.AddWithValue("@Fecha", CDate(DateTimePickerFechaReporte.Text))
                cmd.Parameters.AddWithValue("@Ubicacion", Convert.ToString(CmbLocation.Text))
                cmd.Parameters.AddWithValue("@TipoMuestra", Convert.ToString(CmbSampleType.Text))
                cmd.Parameters.AddWithValue("@Dup", Convert.ToString(TxtDuplicado.Text))
                cmd.Parameters.AddWithValue("@Comments", Convert.ToString(TxtCommentSamples.Text))
                cmd.Connection = sqlConnectiondb
                sqlConnectiondb.Open()
                cmd.ExecuteNonQuery()
                sqlConnectiondb.Close()
                If ChkDup.Checked Then
                    CargarDuplicado()
                End If
                MessageBox.Show("Los datos se  guardaron Correctamente.")
                Llenar_DataGridViewDgSamplesDay()
                ListHFrom.ClearSelected()
                ListHTo.ClearSelected()
                CmbLocation.ResetText()
                CmbSampleType.ResetText()
                TxtDuplicado.Clear()
                TxtSample.Clear()
                TxtCommentSamples.Clear()
                ChkDup.Checked = False
                Chk24hmuestras.Checked = False
                editamuestra = False
                DgSamplesDay.FirstDisplayedScrollingRowIndex = DgSamplesDay.RowCount - 1
            Catch ex As Exception
                ' Handle the exception.
                MessageBox.Show(ex.Message, Me.Text, _
      MessageBoxButtons.OK, MessageBoxIcon.Error)

            End Try

        End If
    End Sub

    Private Sub DateTimePickerFechaReporte_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateTimePickerFechaReporte.ValueChanged
        'Format(fechacreacion, "yyyy/MM/dd")
        LblFechaReporte.Text = CStr(Format(DateTimePickerFechaReporte.Value, "yyyy-MM-dd"))
        limpiarcampos()
        ChkTenor.Checked = False
        ChkTenorFLixi.Checked = False
        ChkTenorBanda.Checked = False
        ChkTenorBanda.Checked = False
        ChkResumerril.Checked = False
        ' Llenar_DataGridViewDgLixiviacion()
        Llenar_DataGridViewDgSamplesDay()
        Llenar_DataGridViewDgLecturaBandas()
        Llenar_DataGridViewDgMerrilCrowe()
        Llenar_DataGridViewDgHorometro()
        Llenar_DgHorometroKnelson()
        cargarOperacion()
        Llenar_DataGridViewDgFlujometroE5()
        Llenar_DataGridViewDgFlujometroFlotacion()
        Llenar_TotalHorometroMolino()
        Llenar_TotalHorometroKnelson()
        Llenar_DataGridViewDgFlujometroRebalse()
    End Sub

    Private Sub limpiarcampos()
        TxtSample.Clear()
        CmbLocation.Text = "Seleccione"
        CmbSampleType.Text = "Seleccione"
        TxtDuplicado.Clear()
        TxtCommentSamples.Clear()
        TxtLinicialHorometro.Clear()
        TxtLfinalHorometro.Clear()
        'CmbFlujodeMasa.Text = "Seleccione"
        TxtDensidad.Clear()
        TxtPorc_Pasante.Clear()
        TxtGravedad.Clear()
        TxtMCubicosH.Clear()
        TxtLixiConcentrado.Clear()
        TxtLecturaInicial.Clear()
        TxtLecturaFinal.Clear()
        txtToneladas.Clear()
        TxtPercHumedad.Clear()
        TxtInicioMC.Clear()
        TxTFinalMC.Clear()
        TxtFinalE5.Clear()
        TxtDensidadE5.Clear()
        TxtInicioE5.Clear()
        TxtHorasOperacione5.Clear()
        TxtInicioFl.Clear()
        TxtFinalFl.Clear()
        TxtDensidadFl.Clear()
        TxtHorasFl.Clear()


        editamuestra = False
        editarlix = False
        editarbanda = False
        editaMerril = False
        editahorometro = False
        editarflujoe5 = False
        editaflujoflotacion = False
    End Sub

    Private Sub CargarlistHoraInicio()
        With Cmd
            .CommandType = CommandType.Text
            .CommandText = "SELECT        Id, Hora, Militar, Tipo FROM            RfTime  ORDER BY Orden"
            .Connection = Cn
        End With
        Da.SelectCommand = Cmd
        dt = New DataTable
        Da.Fill(dt)
        With ListHoraInicio
            .DataSource = dt
            .DisplayMember = "Hora"
            .ValueMember = "Id"
        End With

        With ListHFrom
            .DataSource = dt
            .DisplayMember = "Hora"
            .ValueMember = "Id"
        End With


        With ListB12Inicio
            .DataSource = dt
            .DisplayMember = "Hora"
            .ValueMember = "Id"
        End With

        With CmbHoraInicio
            .DataSource = dt
            .DisplayMember = "Hora"
            .ValueMember = "Id"
        End With

        With ListMCInicio
            .DataSource = dt
            .DisplayMember = "Hora"
            .ValueMember = "Id"
        End With
        ListHoraInicio.ClearSelected()
    End Sub

    Private Sub cargarOperacion()

        Try
            cnStr = "Provider=SQLNCLI10;Initial Catalog=PlantaBeneficio;Data Source=SEGSVRSQL01; User ID=sa;Password=*Bd6r4nC0l0mb1a*;"
            conn.Open(cnStr)
            rstoperacion = conn.Execute(" SELECT * FROM         PB_Operation WHERE (Fecha = '" & CDate(DateTimePickerFechaReporte.Text) & "')         ")
            If rstoperacion.EOF = True Then
                editaroperacion = False
                CmbConcentradoFlotacion.Text = "Seleccione"
                Txtconsumo.Clear()
                TxtTonHora.Clear()
                TxtHoras.Clear()
                TxtMtto.Clear()
                TxtOperacion.Clear()
                TxtTonHumedasZC.Clear()
                TxtTonhumedasPM.Clear()
                TxtStockZCGruesos.Clear()
                TxtStockZCFinos.Clear()
                TxtStockPMFinos.Clear()
                TxtTonZandor.Clear()
                TxtTonMinera.Clear()
                CmbParada.Text = ""
            Else
                Txtconsumo.Text = CStr((rstoperacion.Fields("LecturaFlujoAgua").Value))
                TxtTonHora.Text = CStr((rstoperacion.Fields("TonHora").Value))
                TxtHoras.Text = CStr((rstoperacion.Fields("OperacionHorasDia").Value))
                TxtMtto.Text = CStr((rstoperacion.Fields("DetencionMtto").Value))
                TxtOperacion.Text = CStr((rstoperacion.Fields("DetencionOperacion").Value))
                'toneladas bascula
                TxtTonHumedasZC.Text = CStr((rstoperacion.Fields("TonHumedasZC").Value))
                TxtTonhumedasPM.Text = CStr((rstoperacion.Fields("TonhumedasPM").Value))
                TxtStockZCGruesos.Text = CStr((rstoperacion.Fields("StockZCGruesos").Value))
                TxtStockZCFinos.Text = CStr((rstoperacion.Fields("StockZCFinos").Value))
                TxtStockPMFinos.Text = CStr((rstoperacion.Fields("StockPMFinos").Value))
                TxtTonZandor.Text = CStr((rstoperacion.Fields("TonMolidasZandor").Value))
                TxtTonMinera.Text = CStr((rstoperacion.Fields("TonMolidasMineras").Value))
                CmbConcentradoFlotacion.Text = CStr((rstoperacion.Fields("OrigenconcentradoFlotacion").Value))
                ' fundicion
                If IsDBNull((rstoperacion.Fields("MotivoParada").Value)) Then
                    CmbParada.Text = ""
                Else
                    CmbParada.Text = CStr((rstoperacion.Fields("MotivoParada").Value))
                End If

                editaroperacion = True
            End If
            rstoperacion.Close()
            conn.Close()
        Catch ex As Exception
            ' Handle the exception.
            MessageBox.Show(ex.Message, Me.Text, _
  MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If conn.State <> ConnectionState.Closed Then
                conn.Close()
            End If
        End Try

    End Sub

    Private Sub CargarlistHoraFinal()
        With Cmd
            .CommandType = CommandType.Text
            .CommandText = "SELECT        Id, Hora, Militar, Tipo FROM            RfTime ORDER BY Orden"
            .Connection = Cn
        End With
        Da.SelectCommand = Cmd
        dt = New DataTable
        Da.Fill(dt)

        With ListHoraFinal
            .DataSource = dt
            .DisplayMember = "Hora"
            .ValueMember = "Id"
        End With

        With ListB12Final
            .DataSource = dt
            .DisplayMember = "Hora"
            .ValueMember = "Id"
        End With

        With ListHTo
            .DataSource = dt
            .DisplayMember = "Hora"
            .ValueMember = "Id"
        End With

        With CmbHoraFinal
            .DataSource = dt
            .DisplayMember = "Hora"
            .ValueMember = "Id"
        End With

        With ListMCFinal
            .DataSource = dt
            .DisplayMember = "Hora"
            .ValueMember = "Id"
        End With
        ListHoraFinal.ClearSelected()
    End Sub



    Private Sub CargarCmbFlujodeMasa()
        With Cmd
            .CommandType = CommandType.Text
            .CommandText = "SELECT        TOP (100) PERCENT Id, Name, VolumenLt  FROM           RfFlujoMass ORDER BY Name"
            .Connection = Cn
        End With
        Da.SelectCommand = Cmd

        dt = New DataTable
        Da.Fill(dt)
        With CmbFlujodeMasa
            .DataSource = dt
            .DisplayMember = "Name"
            .ValueMember = "Name"
            .SelectedValue = 0
            .Text = "Seleccione"
        End With

    End Sub
    Private Sub CargarCmbOrigenConcentradodeFlotacion()
        With Cmd

            .CommandType = CommandType.Text
            .CommandText = "  SELECT        TOP (100) PERCENT Name FROM     dbo.RfFlows WHERE        (Tipo = N'Espesadores') AND (Visible = 1) ORDER BY Name"
            .Connection = Cn
        End With
        Da.SelectCommand = Cmd

        dt = New DataTable
        Da.Fill(dt)
        With CmbConcentradoFlotacion
            .DataSource = dt
            .DisplayMember = "Name"
            .ValueMember = "Name"
            .SelectedValue = 0
            .Text = "Seleccione"
        End With

    End Sub


    Private Sub CargarCmbubicacion()
        With Cmd
            .CommandType = CommandType.Text
            .CommandText = "SELECT        TipoMuestra, Nombre, TipoEstado  FROM           RfLocationBenefitPlant ORDER BY Nombre"
            .Connection = Cn
        End With
        Da.SelectCommand = Cmd
        dt = New DataTable
        Da.Fill(dt)
        With CmbLocation
            .DataSource = dt
            .DisplayMember = "Nombre"
            .ValueMember = "Nombre"
            .Text = "Seleccione"
        End With
    End Sub

    Private Sub Cargar_FormOperacion()
        With Cmd
            .CommandType = CommandType.Text
            .CommandText = "SELECT        Fecha , ConsumoEnergia, TonHora, OperacionHorasDia,DetencionMtto,DetencionOperacion  FROM           PB_Operation  WHERE Fecha=  '" & CDate(DateTimePickerFechaReporte.Text) & "' "
            .Connection = Cn
        End With
        Da.SelectCommand = Cmd
        dt = New DataTable
        Da.Fill(dt)

        With Txtconsumo
            .Text = "ConsumoEnergia"
        End With

    End Sub


    Private Sub Llenar_TenorDataGridViewDgAlimentoFlotacion_Solido()
        'cargar DataGrid de Preparacion Daily
        Cn.Open()
        Dim ds As New DataSet
        Dim da As New SqlDataAdapter
        Dim sql As String
        sql = "SELECT        HoraInicial, HoraFinal, Espesador, AuFinal_ppm, TonSeca as Tonsecalixi,  AlimentoGr FROM            vw_PB_AlimentoFlotacion WHERE        Fecha=  '" & CDate(DateTimePickerFechaReporte.Text) & "' "
        da.SelectCommand = New SqlCommand(sql, Cn)
        da.Fill(ds)
        Cn.Close()
        Dim dt As DataTable = ds.Tables(0)
        DgLixiviacion.DataSource = dt
        DgLixiviacion.AutoResizeColumns()
        DgLixiviacion.Columns("Tonsecalixi").DefaultCellStyle.Format = "0.00"
        DgLixiviacion.Columns("AlimentoGr").DefaultCellStyle.Format = "0.00"
        DgLixiviacion.Columns("HoraInicial").HeaderText = "Hora Inincio"
        DgLixiviacion.Columns("HoraFinal").HeaderText = "Hora Final"
        DgLixiviacion.Columns("Espesador").HeaderText = "Espesador-Agitador"
        DgLixiviacion.Columns("Tonsecalixi").HeaderText = "Toneladas Seca"
        DgLixiviacion.Columns("AuFinal_ppm").HeaderText = "Tenor Gr/Ton"
        DgLixiviacion.Columns("AlimentoGr").HeaderText = "Total Gr de Au."
        Dim metrospreparacion As Decimal
        metrospreparacion = 0
        Llenar_TotalTenorFlotacion()
        Me.DgLixiviacion.ReadOnly = False
    End Sub




    Private Sub Llenar_TenorDataGridViewDgAgitadores_Solido()
        'cargar DataGrid de Preparacion Daily
        Cn.Open()
        Dim ds As New DataSet
        Dim da As New SqlDataAdapter
        Dim sql As String
        sql = "SELECT        HoraInicial, HoraFinal, Espesador, AuFinal_ppm, Tonsecalixi, AuSolido as AlimentoGr FROM            vw_PB_AlimentoAgitadores_Solido WHERE        Fecha=  '" & CDate(DateTimePickerFechaReporte.Text) & "' "
        da.SelectCommand = New SqlCommand(sql, Cn)
        da.Fill(ds)
        Cn.Close()
        Dim dt As DataTable = ds.Tables(0)
        DgLixiviacion.DataSource = dt
        DgLixiviacion.AutoResizeColumns()
        DgLixiviacion.Columns("Tonsecalixi").DefaultCellStyle.Format = "0.00"
        DgLixiviacion.Columns("AlimentoGr").DefaultCellStyle.Format = "0.00"
        DgLixiviacion.Columns("HoraInicial").HeaderText = "Hora Inincio"
        DgLixiviacion.Columns("HoraFinal").HeaderText = "Hora Final"
        DgLixiviacion.Columns("Espesador").HeaderText = "Espesador-Agitador"
        DgLixiviacion.Columns("Tonsecalixi").HeaderText = "Toneladas Seca"
        DgLixiviacion.Columns("AuFinal_ppm").HeaderText = "Tenor Gr/Ton"
        DgLixiviacion.Columns("AlimentoGr").HeaderText = "Total Gr de Au."
        Dim metrospreparacion As Decimal
        metrospreparacion = 0
        Llenar_TotalTenorFlotacion()
        Me.DgLixiviacion.ReadOnly = False
    End Sub


    Private Sub Llenar_TenorDataGridViewDgColasAgitadores_Solido()
        Try
            'cargar DataGrid de Preparacion Daily
            Cn.Open()
            Dim ds As New DataSet
            Dim da As New SqlDataAdapter
            Dim sql As String
            sql = "SELECT        HoraInicial, HoraFinal, Espesador, AuFinal_ppm, Tonsecalixi, AuSolido as  AlimentoGr FROM            vw_PB_ColasAgitadores_Solido WHERE        Fecha=  '" & CDate(DateTimePickerFechaReporte.Text) & "' "
            da.SelectCommand = New SqlCommand(sql, Cn)
            da.Fill(ds)
            Cn.Close()
            Dim dt As DataTable = ds.Tables(0)
            DgLixiviacion.DataSource = dt
            DgLixiviacion.AutoResizeColumns()
            DgLixiviacion.Columns("Tonsecalixi").DefaultCellStyle.Format = "0.00"
            DgLixiviacion.Columns("AlimentoGr").DefaultCellStyle.Format = "0.00"
            DgLixiviacion.Columns("HoraInicial").HeaderText = "Hora Inincio"
            DgLixiviacion.Columns("HoraFinal").HeaderText = "Hora Final"
            DgLixiviacion.Columns("Espesador").HeaderText = "Espesador-Agitador"
            DgLixiviacion.Columns("Tonsecalixi").HeaderText = "Toneladas Seca"
            DgLixiviacion.Columns("AuFinal_ppm").HeaderText = "Tenor Gr/Ton"
            DgLixiviacion.Columns("AlimentoGr").HeaderText = "Total Gr de Au."
            Dim metrospreparacion As Decimal
            metrospreparacion = 0
            Llenar_TotalTenorFlotacion()
            Me.DgLixiviacion.ReadOnly = False
        Catch ex As Exception
            ' Handle the exception.
            MessageBox.Show(ex.Message, Me.Text, _
  MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub Llenar_TotalTenorFlotacion()
        Dim registros As Decimal
        Dim totaldensidad As Decimal
        Dim porcpasante As Decimal
        Dim porcsolido As Decimal
        Dim alimentogr As Decimal
        Dim tonseca As Decimal
        alimentogr = 0
        registros = 0
        totaldensidad = 0
        porcpasante = 0
        porcsolido = 0
        tonseca = 0
        For Each dRow As DataGridViewRow In DgLixiviacion.Rows
            If (dRow.Cells.Item("HoraInicial").Value) IsNot Nothing Then
                If ChkTenorFLixi.Checked = True Or ChKFlotaLixiSolucion.Checked = True Then
                    alimentogr = CDec(dRow.Cells.Item("AlimentoGr").Value) + alimentogr
                    tonseca = CDec(dRow.Cells.Item("Tonsecalixi").Value) + tonseca
                Else
                    totaldensidad = CDec(dRow.Cells.Item("Densidad").Value) + totaldensidad
                    porcpasante = CDec(dRow.Cells.Item("Porc_Pasante").Value) + porcpasante
                    porcsolido = CDec(dRow.Cells.Item("Porc_PesoSolido").Value) + porcsolido
                End If
            End If
            registros = registros + 1
        Next dRow
        If registros = 0 Then
            LblDensidad.Text = "0"
            LblPasante.Text = "0"
            LblPorSolido.Text = "0"
        Else
            LblDensidad.Text = CStr(Format(totaldensidad / registros, "0.00"))
            LblPasante.Text = CStr(Format(porcpasante / registros, "0.00"))
            LblPorSolido.Text = CStr(Format(porcsolido / registros, "0.00"))
            If ChkTenorFLixi.Checked = True Or ChKFlotaLixiSolucion.Checked = True Then
                LblTonseca.Text = CStr(Format(tonseca, "0.00"))
                If tonseca = 0 Then
                Else
                    LblTenorEspe.Text = CStr(Format(alimentogr / tonseca, "0.00"))
                    LblOnzasEspe.Text = CStr(Format(alimentogr / 31.1035, "0.00"))
                End If
            Else
                LblTonseca.Text = "----"
                LblTenorEspe.Text = "----"
                LblOnzasEspe.Text = "----"
            End If
        End If
        Me.DgLixiviacion.ReadOnly = False
    End Sub


    Private Sub Llenar_TenorDataGridViewDgColasEspesador5_Solido()
        'cargar DataGrid de Preparacion Daily
        Cn.Open()
        Dim ds As New DataSet
        Dim da As New SqlDataAdapter
        Dim sql As String
        sql = "SELECT        HoraInicial, HoraFinal, Espesador, AuFinal_ppm, Tonsecalixi, AlimentoGr FROM            dbo.vw_PB_ColasLixiviacion_Solido WHERE        Fecha=  '" & CDate(DateTimePickerFechaReporte.Text) & "' "
        da.SelectCommand = New SqlCommand(sql, Cn)
        da.Fill(ds)
        Cn.Close()
        Dim dt As DataTable = ds.Tables(0)
        DgLixiviacion.DataSource = dt
        DgLixiviacion.AutoResizeColumns()
        DgLixiviacion.Columns("Tonsecalixi").DefaultCellStyle.Format = "0.00"
        DgLixiviacion.Columns("AlimentoGr").DefaultCellStyle.Format = "0.00"
        DgLixiviacion.Columns("HoraInicial").HeaderText = "Hora Inincio"
        DgLixiviacion.Columns("HoraFinal").HeaderText = "Hora Final"
        DgLixiviacion.Columns("Espesador").HeaderText = "Espesador-Agitador"
        DgLixiviacion.Columns("Tonsecalixi").HeaderText = "Toneladas Seca"
        DgLixiviacion.Columns("AuFinal_ppm").HeaderText = "Tenor Gr/Ton"
        DgLixiviacion.Columns("AlimentoGr").HeaderText = "Total Gr de Au."
        Dim metrospreparacion As Decimal
        metrospreparacion = 0
        Llenar_TotalTenorFlotacion()
        Me.DgLixiviacion.ReadOnly = False
    End Sub

    Private Sub Llenar_TenorDataGridViewDgColasFlotacion_Solido()
        'cargar DataGrid de Preparacion Daily
        Cn.Open()
        Dim ds As New DataSet
        Dim da As New SqlDataAdapter
        Dim sql As String
        sql = "SELECT        HoraInicial, HoraFinal, Espesador, AuFinal_ppm, Tonsecalixi,  AlimentoGr FROM            vw_PB_ColasFlotacion WHERE        Fecha=  '" & CDate(DateTimePickerFechaReporte.Text) & "' "
        da.SelectCommand = New SqlCommand(sql, Cn)
        da.Fill(ds)
        Cn.Close()
        Dim dt As DataTable = ds.Tables(0)
        DgLixiviacion.DataSource = dt
        DgLixiviacion.AutoResizeColumns()
        DgLixiviacion.Columns("Tonsecalixi").DefaultCellStyle.Format = "0.00"
        DgLixiviacion.Columns("AlimentoGr").DefaultCellStyle.Format = "0.00"
        DgLixiviacion.Columns("HoraInicial").HeaderText = "Hora Inincio"
        DgLixiviacion.Columns("HoraFinal").HeaderText = "Hora Final"
        DgLixiviacion.Columns("Espesador").HeaderText = "Espesador-Agitador"
        DgLixiviacion.Columns("Tonsecalixi").HeaderText = "Toneladas Seca"
        DgLixiviacion.Columns("AuFinal_ppm").HeaderText = "Tenor Gr/Ton"
        DgLixiviacion.Columns("AlimentoGr").HeaderText = "Total Gr de Au."
        Dim metrospreparacion As Decimal
        metrospreparacion = 0
        Llenar_TotalTenorFlotacion()
        Me.DgLixiviacion.ReadOnly = False
    End Sub



    Private Sub Llenar_TenorDataGridViewDgColasAgitadores_Solucion()
        'cargar DataGrid de Preparacion Daily
        Cn.Open()
        Dim ds As New DataSet
        Dim da As New SqlDataAdapter
        Dim sql As String
        sql = "SELECT        HoraInicial, HoraFinal, Espesador, AuFinal_ppm, Tonsecalixi, AuSolido as AlimentoGr FROM            vw_PB_ColasAgitadores_Solucion WHERE        Fecha=  '" & CDate(DateTimePickerFechaReporte.Text) & "' "
        da.SelectCommand = New SqlCommand(sql, Cn)
        da.Fill(ds)
        Cn.Close()
        Dim dt As DataTable = ds.Tables(0)
        DgLixiviacion.DataSource = dt
        DgLixiviacion.AutoResizeColumns()
        DgLixiviacion.Columns("Tonsecalixi").DefaultCellStyle.Format = "0.00"
        DgLixiviacion.Columns("AlimentoGr").DefaultCellStyle.Format = "0.00"
        DgLixiviacion.Columns("HoraInicial").HeaderText = "Hora Inincio"
        DgLixiviacion.Columns("HoraFinal").HeaderText = "Hora Final"
        DgLixiviacion.Columns("Espesador").HeaderText = "Espesador-Agitador"
        DgLixiviacion.Columns("Tonsecalixi").HeaderText = "Toneladas Seca"
        DgLixiviacion.Columns("AuFinal_ppm").HeaderText = "Tenor Gr/Ton"
        DgLixiviacion.Columns("AlimentoGr").HeaderText = "Total Gr de Au."
        Dim metrospreparacion As Decimal
        metrospreparacion = 0
        Llenar_TotalTenorFlotacion()
        Me.DgLixiviacion.ReadOnly = False
    End Sub


    Private Sub Llenar_TenorDataGridViewDgColasEspesador5_Solucion()
        'cargar DataGrid de Preparacion Daily
        Cn.Open()
        Dim ds As New DataSet
        Dim da As New SqlDataAdapter
        Dim sql As String
        sql = "SELECT        HoraInicial, HoraFinal, Espesador, AuFinal_ppm, Tonsecalixi, OroSolucion as AlimentoGr FROM            dbo.vw_PB_ColasLixiviacion_Solucion WHERE        Fecha=  '" & CDate(DateTimePickerFechaReporte.Text) & "' "
        da.SelectCommand = New SqlCommand(sql, Cn)
        da.Fill(ds)
        Cn.Close()
        Dim dt As DataTable = ds.Tables(0)
        DgLixiviacion.DataSource = dt
        DgLixiviacion.AutoResizeColumns()
        DgLixiviacion.Columns("Tonsecalixi").DefaultCellStyle.Format = "0.00"
        DgLixiviacion.Columns("AlimentoGr").DefaultCellStyle.Format = "0.00"
        DgLixiviacion.Columns("HoraInicial").HeaderText = "Hora Inincio"
        DgLixiviacion.Columns("HoraFinal").HeaderText = "Hora Final"
        DgLixiviacion.Columns("Espesador").HeaderText = "Espesador-Agitador"
        DgLixiviacion.Columns("Tonsecalixi").HeaderText = "Toneladas Seca"
        DgLixiviacion.Columns("AuFinal_ppm").HeaderText = "Tenor Gr/Ton"
        DgLixiviacion.Columns("AlimentoGr").HeaderText = "Total Gr de Au."
        Dim metrospreparacion As Decimal
        metrospreparacion = 0
        Llenar_TotalTenorFlotacion()
        Me.DgLixiviacion.ReadOnly = False
    End Sub

    Private Sub Llenar_DataGridViewDgLixiviacion()   'cargar DataGrid de Preparacion Daily
        Cn.Open()
        Dim ds As New DataSet
        Dim da As New SqlDataAdapter
        Dim sql As String
        sql = " SELECT   Fecha,HoraInicial,HoraFinal, Espesador, Densidad, Porc_Pasante, Porc_PesoSolido , SGmineral, VolumenLt , TonConcentrado from    PB_Leaching INNER JOIN RfTime ON  PB_Leaching.HoraInicial = RfTime.Hora WHERE Fecha=  '" & CDate(DateTimePickerFechaReporte.Text) & "' AND Espesador= '" & CmbFlujodeMasa.Text & "'   ORDER BY RfTime.IdPlanta "
        da.SelectCommand = New SqlCommand(sql, Cn)
        da.Fill(ds)
        Cn.Close()
        Dim dt As DataTable = ds.Tables(0)
        DgLixiviacion.DataSource = dt
        DgLixiviacion.AutoResizeColumns()
        Me.DgLixiviacion.Columns("Fecha").Visible = False
        DgLixiviacion.Columns("Porc_PesoSolido").DefaultCellStyle.Format = "00%"
        DgLixiviacion.Columns("HoraInicial").HeaderText = "Hora Inincio"
        DgLixiviacion.Columns("HoraFinal").HeaderText = "Hora Final"
        DgLixiviacion.Columns("Espesador").HeaderText = "Espesador-Agitador"
        DgLixiviacion.Columns("Densidad").HeaderText = "Densidad"
        DgLixiviacion.Columns("Porc_Pasante").HeaderText = "% de Pasante 74µm"
        DgLixiviacion.Columns("VolumenLt").HeaderText = "m³/hora"
        Dim metrospreparacion As Decimal
        metrospreparacion = 0
        Llenar_TotalTenorFlotacion()
        Me.DgLixiviacion.ReadOnly = False
    End Sub



    Private Sub Llenar_DataGridViewDgLecturaBandas()
        'cargar DataGrid de Preparacion Daily
        Cn.Open()
        Dim ds As New DataSet
        Dim da As New SqlDataAdapter
        Dim sql As String
        sql = "SELECT        TOP (100) PERCENT dbo.PB_Conveyor.HoraInicial, dbo.PB_Conveyor.HoraFinal, dbo.PB_Conveyor.LecturaInicial, dbo.PB_Conveyor.LecturaFinal , dbo.PB_Conveyor.TonHumeda, dbo.PB_Conveyor.Porc_Humedad ,  dbo.PB_Conveyor.TonSeca , dbo.PB_Conveyor.muestra ,  dbo.PB_Conveyor.Tenor_au , dbo.PB_Conveyor.Onzas , dbo.pb_conveyor.IdConsecutivo FROM      dbo.PB_Conveyor INNER JOIN       dbo.RfTime ON dbo.PB_Conveyor.HoraInicial = dbo.RfTime.Hora WHERE    (dbo.PB_Conveyor.Fecha = '" & CDate(DateTimePickerFechaReporte.Text) & "') ORDER BY dbo.PB_Conveyor.LecturaInicial "
        da.SelectCommand = New SqlCommand(sql, Cn)
        da.Fill(ds)
        Cn.Close()
        Dim dt As DataTable = ds.Tables(0)
        DgLecturaBandas.DataSource = dt
        DgLecturaBandas.AutoResizeColumns()
        DgLecturaBandas.Columns("TonHumeda").DefaultCellStyle.Format = "0.00"
        DgLecturaBandas.Columns("TonSeca").DefaultCellStyle.Format = "0.00"
        DgLecturaBandas.Columns("Onzas").DefaultCellStyle.Format = "0.00"
        DgLecturaBandas.Columns("HoraInicial").HeaderText = "Hora Inicio"
        DgLecturaBandas.Columns("HoraFinal").HeaderText = "Hora Final"
        DgLecturaBandas.Columns("LecturaInicial").HeaderText = "Lectura Inicial"
        DgLecturaBandas.Columns("LecturaFinal").HeaderText = "Lectura Final"
        DgLecturaBandas.Columns("Porc_Humedad").HeaderText = "% de Humedad"
        DgLecturaBandas.Columns("TonHumeda").HeaderText = "Toneladas Humedas"
        DgLecturaBandas.Columns("Tonseca").HeaderText = "Tondeladas Seca"
        DgLecturaBandas.Columns("Onzas").HeaderText = "Onzas"
        DgLecturaBandas.Columns("IdConsecutivo").Visible = False
        Llenar_TotalBandas()
        Me.DgLecturaBandas.ReadOnly = False
    End Sub

    Private Sub Llenar_DataGridViewDgMerrilCrowe()
        Cn.Open()
        Dim ds As New DataSet
        Dim da As New SqlDataAdapter
        Dim sql As String
        sql = "SELECT        TOP (100) PERCENT HoraInicial, HoraFinal, LecturaInicial, LecturaFinal, Volumen ,fecha, TenorCabeza, TenorCola , onzas  FROM      PB_MerrilCrowe INNER JOIN       dbo.RfTime ON dbo.PB_MerrilCrowe.HoraInicial = dbo.RfTime.Hora WHERE    (dbo.PB_MerrilCrowe.Fecha = '" & CDate(DateTimePickerFechaReporte.Text) & "') ORDER BY dbo.RfTime.IdPlanta "
        da.SelectCommand = New SqlCommand(sql, Cn)
        da.Fill(ds)
        Cn.Close()
        Dim dt As DataTable = ds.Tables(0)
        DgMerrilCrowe.DataSource = dt
        DgMerrilCrowe.AutoResizeColumns()
        '    If IsDBNull(DgMerrilCrowe.Columns("Volumen")) Then

        '  Else
        DgMerrilCrowe.Columns("Volumen").DefaultCellStyle.Format = "0.00"
        '  End If
        'DgMerrilCrowe.Columns("Volumen").DefaultCellStyle.Format = "0.00"
        DgMerrilCrowe.Columns("Onzas").DefaultCellStyle.Format = "0.00"
        DgMerrilCrowe.Columns("Fecha").HeaderText = "Fecha"
        DgMerrilCrowe.Columns("Fecha").Visible = False
        DgMerrilCrowe.Columns("HoraInicial").HeaderText = "Hora Inicio"
        DgMerrilCrowe.Columns("HoraFinal").HeaderText = "Hora Final"
        DgMerrilCrowe.Columns("LecturaInicial").HeaderText = "Lectura Inicial"
        DgMerrilCrowe.Columns("LecturaFinal").HeaderText = "Lectura Final"
        DgMerrilCrowe.Columns("Volumen").HeaderText = "Volumen m³/h"
        DgMerrilCrowe.Columns("Onzas").HeaderText = "Onzas Precipitadas"
        Llenar_TotalMerril()
        Me.DgMerrilCrowe.ReadOnly = False
    End Sub

    Private Sub Llenar_DataGridViewDgHorometro()
        Cn.Open()
        Dim ds As New DataSet
        Dim da As New SqlDataAdapter
        Dim sql As String
        sql = "SELECT         HoromInicial, HoromFinal , fecha , HorasOperacionTurno , turno FROM      Pb_HorasMolienda  WHERE    (dbo.Pb_HorasMolienda.Fecha = '" & CDate(DateTimePickerFechaReporte.Text) & "') ORDER BY dbo.Pb_HorasMolienda.Turno "
        da.SelectCommand = New SqlCommand(sql, Cn)
        da.Fill(ds)
        Cn.Close()
        Dim dt As DataTable = ds.Tables(0)
        DgHorometro.DataSource = dt
        DgHorometro.AutoResizeColumns()
        DgHorometro.Columns("HoromInicial").HeaderText = "Lectura Inicial"
        DgHorometro.Columns("Fecha").Visible = False
        DgHorometro.Columns("HoromFinal").HeaderText = "Lectura Final"
        DgHorometro.Columns("HorasOperacionTurno").HeaderText = "Horas Turno"

        Me.DgHorometro.ReadOnly = False
    End Sub

    Private Sub Llenar_DgHorometroKnelson()
        Cn.Open()
        Dim ds As New DataSet
        Dim da As New SqlDataAdapter
        Dim sql As String
        sql = "SELECT         HoromInicial, HoromFinal , fecha , HorasOperacionTurno , turno FROM      Pb_HorasKNelson WHERE    (dbo.Pb_HorasKNelson.Fecha = '" & CDate(DateTimePickerFechaReporte.Text) & "') ORDER BY dbo.Pb_HorasKNelson.Turno "
        da.SelectCommand = New SqlCommand(sql, Cn)
        da.Fill(ds)
        Cn.Close()
        Dim dt As DataTable = ds.Tables(0)
        DgHorometroKnelson.DataSource = dt
        DgHorometroKnelson.AutoResizeColumns()
        DgHorometroKnelson.Columns("HoromInicial").HeaderText = "Lectura Inicial"
        DgHorometroKnelson.Columns("Fecha").Visible = False
        DgHorometroKnelson.Columns("HoromFinal").HeaderText = "Lectura Final"
        DgHorometroKnelson.Columns("HorasOperacionTurno").HeaderText = "Horas Turno"

        Me.DgHorometroKnelson.ReadOnly = False
    End Sub

    Private Sub Llenar_DataGridViewDgMerrilCrowe_Tenor()
        Cn.Open()
        Dim ds As New DataSet
        Dim da As New SqlDataAdapter
        Dim sql As String
        sql = "SELECT     Fecha, HoraInicial, HoraFinal, Volumen, AuFinal_ppm, AlimentoGr, Turno   FROM dbo.vw_AlimentoMerrilCrowe WHERE     (dbo.vw_AlimentoMerrilCrowe.Fecha = '" & CDate(DateTimePickerFechaReporte.Text) & "') "
        da.SelectCommand = New SqlCommand(sql, Cn)
        da.Fill(ds)
        Cn.Close()
        Dim dt As DataTable = ds.Tables(0)
        DgMerrilCrowe.DataSource = dt
        DgMerrilCrowe.AutoResizeColumns()
        DgMerrilCrowe.Columns("Fecha").Visible = False
        DgMerrilCrowe.Columns("Volumen").DefaultCellStyle.Format = "0.00"
        DgMerrilCrowe.Columns("HoraInicial").HeaderText = "Hora Inicio"
        DgMerrilCrowe.Columns("HoraFinal").HeaderText = "Hora Final"
        DgMerrilCrowe.Columns("AuFinal_ppm").HeaderText = "Tenor"
        DgMerrilCrowe.Columns("Volumen").HeaderText = "Volumen m³/h"
        Llenar_TotalMerril()
        Me.DgMerrilCrowe.ReadOnly = False
    End Sub

    Private Sub Llenar_DataGridViewDgSamplesDay()
        Cn.Open()
        Dim ds As New DataSet
        Dim da As New SqlDataAdapter
        Dim sql As String
        sql = " SELECT    Muestra, Fecha, HoraInicial,HoraFinal, Ubicacion,TipoMuestra, Dup , Comments  from PB_Samples WHERE Fecha=  '" & CDate(DateTimePickerFechaReporte.Value) & "'  ORDER BY TipoMuestra , Muestra"
        da.SelectCommand = New SqlCommand(sql, Cn)
        da.Fill(ds)
        Cn.Close()
        Dim dt As DataTable = ds.Tables(0)
        DgSamplesDay.DataSource = dt
        DgSamplesDay.AutoResizeColumns()
        DgSamplesDay.Columns("Fecha").Visible = False
        DgSamplesDay.Columns("Muestra").HeaderText = "Muestra"
        DgSamplesDay.Columns("HoraInicial").HeaderText = "Hora Inincio"
        DgSamplesDay.Columns("HoraFinal").HeaderText = "Hora Final"
        DgSamplesDay.Columns("Ubicacion").HeaderText = "Ubicacion"
        DgSamplesDay.Columns("TipoMuestra").HeaderText = "Tipo de Muestra"
        DgSamplesDay.Columns("Dup").HeaderText = "Duplicado de"
        Me.DgSamplesDay.ReadOnly = False
    End Sub

    Private Sub Llenar_TenorDataGridViewDgSamplesDay()
        Cn.Open()
        Dim ds As New DataSet
        Dim da As New SqlDataAdapter
        Dim sql As String
        sql = " SELECT        TOP (100) PERCENT PB_Samples.Muestra, dbo.PB_Samples.Fecha, PB_Samples.HoraInicial, PB_Samples.HoraFinal, PB_Samples.Ubicacion,    PB_Samples.TipoMuestra,  PB_Assay.AuFinal_ppm, PB_Assay.Ag_Ppm, PB_Assay.Peso_gr ,  PB_Samples.Dup , pb_samples.Comments FROM     PB_Samples INNER JOIN           PB_Assay ON PB_Samples.Muestra = PB_Assay.Muestra WHERE        (PB_Samples.Fecha = '" & CDate(DateTimePickerFechaReporte.Text) & "') AND Pb_Assay.Activado='SI' ORDER BY PB_Samples.TipoMuestra, PB_Samples.Muestra"
        da.SelectCommand = New SqlCommand(sql, Cn)
        da.Fill(ds)
        Cn.Close()
        Dim dt As DataTable = ds.Tables(0)
        DgSamplesDay.DataSource = dt
        DgSamplesDay.AutoResizeColumns()
        Me.DgSamplesDay.Columns("Fecha").Visible = False
        DgSamplesDay.Columns("Muestra").HeaderText = "Muestra"
        DgSamplesDay.Columns("HoraInicial").HeaderText = "Hora Inincio"
        DgSamplesDay.Columns("HoraFinal").HeaderText = "Hora Final"
        DgSamplesDay.Columns("Ubicacion").HeaderText = "Ubicacion"
        DgSamplesDay.Columns("TipoMuestra").HeaderText = "Tipo de Muestra"
        DgSamplesDay.Columns("AuFinal_ppm").HeaderText = "Au (ppm)"
        DgSamplesDay.Columns("Ag_Ppm").HeaderText = "Ag (ppm)"
        Me.DgSamplesDay.ReadOnly = False
    End Sub
    Private Sub Llenar_DataGridViewDgFlujometroE5()
        'cargar DataGrid de Preparacion Daily
        Cn.Open()
        Dim ds As New DataSet
        Dim da As New SqlDataAdapter
        Dim sql As String
        sql = "SELECT        TOP (100) PERCENT dbo.Pb_FlowsE5.LecturaInicial, dbo.Pb_FlowsE5.LecturaFinal , dbo.Pb_FlowsE5.Densidad,HorasOperacion , HorasVertimiento ,dbo.pb_flowse5.gespecifica , dbo.pb_flowse5.FlujoM3 , dbo.pb_flowse5.TonsTurno , dbo.pb_flowse5.ToneladasVertidas , dbo.Pb_FlowsE5.Turno  FROM      dbo.Pb_FlowsE5  WHERE    (dbo.Pb_FlowsE5.Fecha = '" & CDate(DateTimePickerFechaReporte.Text) & "') ORDER BY dbo.Pb_FlowsE5.turno "
        da.SelectCommand = New SqlCommand(sql, Cn)
        da.Fill(ds)
        Cn.Close()
        Dim dt As DataTable = ds.Tables(0)
        DgFlujoE5.DataSource = dt
        DgFlujoE5.AutoResizeColumns()
        DgFlujoE5.Columns("flujom3").DefaultCellStyle.Format = "0.00"
        DgFlujoE5.Columns("gespecifica").DefaultCellStyle.Format = "0.00"
        DgFlujoE5.Columns("TonsTurno").DefaultCellStyle.Format = "0.00"
        DgFlujoE5.Columns("ToneladasVertidas").DefaultCellStyle.Format = "0.00"
        DgFlujoE5.Columns("HorasVertimiento").DefaultCellStyle.Format = "0.00"
        DgFlujoE5.Columns("LecturaInicial").HeaderText = "Lectura Inicial"
        DgFlujoE5.Columns("LecturaFinal").HeaderText = "Lectura Final"
        DgFlujoE5.Columns("Horasoperacion").HeaderText = "Horas de Operacion"
        DgFlujoE5.Columns("Gespecifica").HeaderText = "Gravedad Especifica"
        DgFlujoE5.Columns("FlujoM3").HeaderText = "M3 / Turno"
        DgFlujoE5.Columns("ToneladasVertidas").HeaderText = "Toneladas Vertidas"
        DgFlujoE5.Columns("HorasVertimiento").HeaderText = "Horas de Vertimiento"

        DgFlujoE5.Columns("TonsTurno").HeaderText = "Toneladas"
        Llenar_TotalFlujoE5()
        Me.DgFlujoE5.ReadOnly = False
    End Sub

    Private Sub Llenar_DataGridViewDgFlujometroFlotacion()
        'cargar DataGrid de Preparacion Daily
        Cn.Open()
        Dim ds As New DataSet
        Dim da As New SqlDataAdapter
        Dim sql As String
        sql = "SELECT        TOP (100) PERCENT dbo.Pb_FlowsColasBulk.LecturaInicial, dbo.Pb_FlowsColasBulk.LecturaFinal , dbo.Pb_FlowsColasBulk.Densidad,HorasOperacion, HorasVertimiento ,dbo.Pb_FlowsColasBulk.gespecifica , dbo.Pb_FlowsColasBulk.FlujoM3 , dbo.Pb_FlowsColasBulk.TonsTurno,dbo.Pb_FlowsColasBulk.ToneladasVertidas , dbo.Pb_FlowsColasBulk.Turno  FROM      dbo.Pb_FlowsColasBulk  WHERE    (dbo.Pb_FlowsColasBulk.Fecha = '" & CDate(DateTimePickerFechaReporte.Text) & "') ORDER BY dbo.Pb_FlowsColasBulk.turno "
        da.SelectCommand = New SqlCommand(sql, Cn)
        da.Fill(ds)
        Cn.Close()
        Dim dt As DataTable = ds.Tables(0)
        DgColasFlotacion.DataSource = dt
        DgColasFlotacion.AutoResizeColumns()
        DgColasFlotacion.Columns("flujom3").DefaultCellStyle.Format = "0.00"
        DgColasFlotacion.Columns("gespecifica").DefaultCellStyle.Format = "0.00"
        DgColasFlotacion.Columns("TonsTurno").DefaultCellStyle.Format = "0.00"
        DgColasFlotacion.Columns("ToneladasVertidas").DefaultCellStyle.Format = "0.00"
        DgColasFlotacion.Columns("LecturaInicial").HeaderText = "Lectura Inicial"
        DgColasFlotacion.Columns("LecturaFinal").HeaderText = "Lectura Final"
        DgColasFlotacion.Columns("Horasoperacion").HeaderText = "Horas de Operacion"
        DgColasFlotacion.Columns("HorasVertimiento").HeaderText = "Horas de Operacion"
        DgColasFlotacion.Columns("Gespecifica").HeaderText = "Gravedad Especifica"
        DgColasFlotacion.Columns("FlujoM3").HeaderText = "M3 / Turno"
        DgColasFlotacion.Columns("HorasVertimiento").HeaderText = "Horas de Vertimiento"
        DgColasFlotacion.Columns("ToneladasVertidas").HeaderText = "Toneladas Vertidas"
        DgColasFlotacion.Columns("TonsTurno").HeaderText = "Toneladas"
        Llenar_TotalFlujoFlotacion()
        Me.DgColasFlotacion.ReadOnly = False
    End Sub



    Private Sub Llenar_DataGridViewDgFlujometroRebalse()
        'cargar DataGrid de Preparacion Daily
        Cn.Open()
        Dim ds As New DataSet
        Dim da As New SqlDataAdapter
        Dim sql As String
        sql = "SELECT        TOP (100) PERCENT dbo.Pb_FlowsRebalseCiclon.LecturaInicial, dbo.Pb_FlowsRebalseCiclon.LecturaFinal , dbo.Pb_FlowsRebalseCiclon.Densidad , Turno , FlujoM3 , TonsTurno FROM      dbo.Pb_FlowsRebalseCiclon  WHERE    (dbo.Pb_FlowsRebalseCiclon.Fecha = '" & CDate(DateTimePickerFechaReporte.Text) & "') ORDER BY dbo.Pb_FlowsRebalseCiclon.turno "
        da.SelectCommand = New SqlCommand(sql, Cn)
        da.Fill(ds)
        Cn.Close()
        Dim dt As DataTable = ds.Tables(0)
        DgFlujoHidrociclones.DataSource = dt
        DgFlujoHidrociclones.AutoResizeColumns()
        DgFlujoHidrociclones.Columns("flujom3").DefaultCellStyle.Format = "0.00"

        DgFlujoHidrociclones.Columns("TonsTurno").DefaultCellStyle.Format = "0.00"

        DgFlujoHidrociclones.Columns("LecturaInicial").HeaderText = "Lectura Inicial"
        DgFlujoHidrociclones.Columns("LecturaFinal").HeaderText = "Lectura Final"
        DgFlujoHidrociclones.Columns("FlujoM3").HeaderText = "M3 / Turno"
        DgFlujoHidrociclones.Columns("TonsTurno").HeaderText = "Toneladas"
        'Llenar_TotalFlujoFlotacion()
        Me.DgFlujoHidrociclones.ReadOnly = False
    End Sub

    Private Sub Llenar_TenorDataGridViewDgLecturaBandas()
        Cn.Open()
        Dim ds As New DataSet
        Dim da As New SqlDataAdapter
        Dim sql As String
        sql = " SELECT        TOP (100) PERCENT vw_PB_AlimentoMolienda.HoraInicial, vw_PB_AlimentoMolienda.HoraFinal, vw_PB_AlimentoMolienda.LecturaInicial, vw_PB_AlimentoMolienda.LecturaFinal , vw_PB_AlimentoMolienda.TonsecaManual , vw_PB_AlimentoMolienda.TonHumedaManual ,   vw_PB_AlimentoMolienda.Au_Media,  vw_PB_AlimentoMolienda.Ag_Ppm,  vw_PB_AlimentoMolienda.Au_AlimentoGr FROM     vw_PB_AlimentoMolienda  WHERE        (vw_PB_AlimentoMolienda.Fecha = '" & CDate(DateTimePickerFechaReporte.Text) & "')  "
        da.SelectCommand = New SqlCommand(sql, Cn)
        da.Fill(ds)
        Cn.Close()
        Dim dt As DataTable = ds.Tables(0)
        DgLecturaBandas.DataSource = dt
        DgLecturaBandas.AutoResizeColumns()
        Me.DgLecturaBandas.ReadOnly = False
        Llenar_TotalBandas()
    End Sub
    Private Sub CargarDuplicado()
        Dim sqlConnectiondb As New System.Data.SqlClient.SqlConnection("Server=SEGSVRSQL01;uid=sa;pwd=*Bd6r4nC0l0mb1a*;database=PlantaBeneficio")
        Dim cmd As New System.Data.SqlClient.SqlCommand
        cmd.CommandType = System.Data.CommandType.Text
        cmd.CommandText = "INSERT INTO PB_Samples (Muestra,HoraInicial,HoraFinal, Fecha,Ubicacion,TipoMuestra, Dup, DupMuestra)VALUES(@Muestra ,@HoraInicial,@HoraFinal,@Fecha,@Ubicacion,@TipoMuestra , @Dup,@DupMuestra)"
        cmd.Parameters.AddWithValue("@Muestra", Convert.ToString(TxtSample.Text) & "A")
        cmd.Parameters.AddWithValue("@HoraInicial", Convert.ToString(ListHFrom.Text))
        cmd.Parameters.AddWithValue("@HoraFinal", Convert.ToString(ListHTo.Text))
        cmd.Parameters.AddWithValue("@Fecha", CDate(DateTimePickerFechaReporte.Text))
        cmd.Parameters.AddWithValue("@Ubicacion", Convert.ToString(CmbLocation.Text))
        cmd.Parameters.AddWithValue("@TipoMuestra", Convert.ToString(CmbSampleType.Text))
        cmd.Parameters.AddWithValue("@Dup", Convert.ToString(TxtSample.Text))
        cmd.Parameters.AddWithValue("@DupMuestra", "DUPLICADO")
        cmd.Connection = sqlConnectiondb
        sqlConnectiondb.Open()
        cmd.ExecuteNonQuery()
        sqlConnectiondb.Close()
    End Sub
    Private Sub Llenar_TotalBandas()
        Dim registros As Decimal
        Dim TotalTonseca As Decimal
        Dim TotalHumeda As Decimal
        Dim porchumedad As Decimal
        Dim alimentogr As Decimal
        Dim totalonzas As Decimal
        TotalHumeda = 0
        TotalTonseca = 0
        registros = 0
        porchumedad = 0
        alimentogr = 0
        totalonzas = 0
        For Each dRow As DataGridViewRow In DgLecturaBandas.Rows
            If (dRow.Cells.Item("Tonseca").Value) IsNot Nothing Then


                If IsDBNull(dRow.Cells.Item("Onzas").Value) Then

                Else
                    totalonzas = CDec(dRow.Cells.Item("onzas").Value) + totalonzas
                End If

                If IsDBNull(dRow.Cells.Item("Tonseca").Value) Then

                Else
                    TotalTonseca = CDec(dRow.Cells.Item("Tonseca").Value) + TotalTonseca
                End If

                ' If ChkTenorBanda.Checked = True Then

                ' If IsDBNull(dRow.Cells.Item("TonHumedaManual").Value) Or IsDBNull(dRow.Cells.Item("Au_AlimentoGr").Value) Then

                'Else
                ' alimentogr = CDec(dRow.Cells.Item("Au_AlimentoGr").Value) + alimentogr
                ' End If
                'Else

                If IsDBNull(dRow.Cells.Item("TonHumeda").Value) Then
                Else
                    TotalHumeda = CDec(dRow.Cells.Item("TonHumeda").Value) + TotalHumeda
                End If

                porchumedad = CDec(dRow.Cells.Item("Porc_Humedad").Value) + porchumedad
            End If
            ' End If
            registros = registros + 1
        Next dRow
        LblTotalSeca.Text = CStr(Format(TotalTonseca, "0.00"))
        LbltotalHumeda.Text = CStr(Format(TotalHumeda, "0.00"))
        LblOnzas.Text = CStr(Format(totalonzas, "0.00"))
        If registros = 0 Then
            LblHumedad.Text = "0"
        Else
            LblHumedad.Text = CStr(Format((porchumedad / registros), "0.00"))
            ' If ChkTenorBanda.Checked = True Then
            LblAlimento.Text = CStr(Format(alimentogr, "0.00"))

            ' If TotalTonseca = 0 Then
            'LblTenor.Text = "0"
            ' Else
            LblTenor.Text = CStr(Format((totalonzas * 31.1035) / TotalTonseca, "0.00"))
            'End If

            '   Else
            '  LblAlimento.Text = "----"
            ' LblTenor.Text = "----"
            'LblOnzas.Text = "----"
        End If
        ' End If
        Me.DgLecturaBandas.ReadOnly = False
    End Sub

    Private Sub Llenar_TotalFlujoE5()
        Dim TotalTons As Decimal
        TotalTons = 0
        Dim densidadpromedio As Decimal
        Dim flujo As Decimal
        Dim horasoperacion As Decimal
        flujo = 0
        horasoperacion = 0
        densidadpromedio = 0
        Dim registros As Decimal
        registros = 0
        For Each dRow As DataGridViewRow In DgFlujoE5.Rows
            If (dRow.Cells.Item("LecturaInicial").Value) IsNot Nothing Then


                If IsDBNull(dRow.Cells.Item("TonsTurno").Value) Then

                Else
                    TotalTons = CDec(dRow.Cells.Item("TonsTurno").Value) + TotalTons
                End If

                If IsDBNull(dRow.Cells.Item("HorasOperacion").Value) Then

                Else
                    horasoperacion = CDec(dRow.Cells.Item("HorasOperacion").Value) + horasoperacion
                End If


                If IsDBNull(dRow.Cells.Item("Densidad").Value) Then
                Else
                    densidadpromedio = CDec(dRow.Cells.Item("Densidad").Value) + densidadpromedio
                End If

            End If
            registros = registros + 1
        Next dRow
        LblTonsE5.Text = CStr(Format(TotalTons, "0.00"))

        LblHorasE5.Text = CStr(Format(horasoperacion, "0.00"))

        If registros <= 0 Then
            LblDensidadE5.Text = "0"
        Else
            LblDensidadE5.Text = CStr(Format((densidadpromedio / registros), "0.00"))
        End If
        ' End If
        Me.DgFlujoE5.ReadOnly = False
    End Sub


    Private Sub Llenar_TotalHorometroMolino()

        Dim horasoperacion As Decimal
        horasoperacion = 0
        Dim registros As Decimal
        registros = 0
        For Each dRow As DataGridViewRow In DgHorometro.Rows
            If (dRow.Cells.Item("HorasOperacionTurno").Value) IsNot Nothing Then

                If IsDBNull(dRow.Cells.Item("HorasOperacionTurno").Value) Then

                Else
                    horasoperacion = CDec(dRow.Cells.Item("HorasOperacionTurno").Value) + horasoperacion
                End If

            End If
            registros = registros + 1
        Next dRow
        LblHorasMolienda.Text = CStr(Format(horasoperacion, "0.00"))
        Me.DgHorometro.ReadOnly = False
    End Sub
    Private Sub Llenar_TotalHorometroKnelson()

        Dim horasoperacion As Decimal
        horasoperacion = 0
        Dim registros As Decimal
        registros = 0
        For Each dRow As DataGridViewRow In DgHorometroKnelson.Rows
            If (dRow.Cells.Item("HorasOperacionTurno").Value) IsNot Nothing Then

                If IsDBNull(dRow.Cells.Item("HorasOperacionTurno").Value) Then
                Else
                    horasoperacion = CDec(dRow.Cells.Item("HorasOperacionTurno").Value) + horasoperacion
                End If
            End If
            registros = registros + 1
        Next dRow
        LblHorasConcentrador.Text = CStr(Format(horasoperacion, "0.00"))
        Me.DgHorometroKnelson.ReadOnly = False
    End Sub
    Private Sub Llenar_TotalFlujoFlotacion()
        Dim TotalTons As Decimal
        TotalTons = 0
        Dim densidadpromedio As Decimal
        Dim flujo As Decimal
        Dim horasoperacion As Decimal
        flujo = 0
        horasoperacion = 0
        densidadpromedio = 0
        Dim registros As Decimal
        registros = 0
        For Each dRow As DataGridViewRow In DgColasFlotacion.Rows
            If (dRow.Cells.Item("LecturaInicial").Value) IsNot Nothing Then


                If IsDBNull(dRow.Cells.Item("TonsTurno").Value) Then

                Else
                    TotalTons = CDec(dRow.Cells.Item("TonsTurno").Value) + TotalTons
                End If

                If IsDBNull(dRow.Cells.Item("HorasOperacion").Value) Then

                Else
                    horasoperacion = CDec(dRow.Cells.Item("HorasOperacion").Value) + horasoperacion
                End If


                If IsDBNull(dRow.Cells.Item("Densidad").Value) Then
                Else
                    densidadpromedio = CDec(dRow.Cells.Item("Densidad").Value) + densidadpromedio
                End If

            End If
            registros = registros + 1
        Next dRow
        LbltonsFlotacion.Text = CStr(Format(TotalTons, "0.00"))

        LblHorasFlotacion.Text = CStr(Format(horasoperacion, "0.00"))

        If registros <= 0 Then
            LbldensidadFlotacion.Text = "0"
        Else
            LbldensidadFlotacion.Text = CStr(Format((densidadpromedio / registros), "0.00"))
        End If
        ' End If
        Me.DgColasFlotacion.ReadOnly = False
    End Sub


    Private Sub Llenar_TotalMerril()
        Dim registros As Decimal
        Dim TotalTon As Decimal
        ' Dim Tenor As Decimal
        Dim onzas As Decimal
        TotalTon = 0
        registros = 0
        onzas = 0

        For Each dRow As DataGridViewRow In DgMerrilCrowe.Rows
            If (dRow.Cells.Item("Volumen").Value) IsNot Nothing Then

                If IsDBNull(dRow.Cells.Item("Volumen").Value) Then

                Else
                    TotalTon = CDec(dRow.Cells.Item("Volumen").Value) + TotalTon

                End If

                If IsDBNull(dRow.Cells.Item("Onzas").Value) Then

                Else

                    onzas = CDec(dRow.Cells.Item("Onzas").Value) + onzas
                End If

                '''' If ChkResumerril.Checked = True Then
                'alimentogr = CDec(dRow.Cells.Item("AlimentoGr").Value) + alimentogr
                '   onzas = CDec(alimentogr / 31.1035)
                '  Tenor = alimentogr / TotalTon
                ' Else
                ' alimentogr = 0
                ' onzas = 0
                'Tenor = 0

                ' End If
            End If
            registros = registros + 1
        Next dRow
        'Tenor = CDec((onzas * 31.1035) / TotalTon)
        LbltonMerril.Text = CStr(Format(TotalTon, "0.00"))
        LblTenorMerril.Text = CStr(Format((onzas * 31.1035) / TotalTon, "0.00"))
        LblOzMerril.Text = CStr(Format(onzas, "0.00"))
        If registros = 0 Then
            LbltonMerril.Text = "0"
            LblTenorMerril.Text = "0"
            LblOzMerril.Text = "0"
        Else
            'LblHumedad.Text = CStr(Format((porchumedad / registros), "0.00"))

        End If


        Me.DgMerrilCrowe.ReadOnly = False
    End Sub


    Private Sub Chk24hmuestras_CheckedChanged(ByVal sender As Object, _
ByVal e As EventArgs)
        If Chk24hmuestras.Checked Then
            ListHFrom.Text = "07:00 a.m."
            ListHTo.Text = "07:00 a.m."
            ListHFrom.Enabled = False
            ListHTo.Enabled = False
        Else
            ListHFrom.Enabled = True
            ListHTo.Enabled = True
        End If

    End Sub


    Private Sub ChkMerril_Change(ByVal sender As Object, ByVal e As EventArgs) Handles ChkResumerril.CheckedChanged
        If ChkResumerril.Checked Then
            Llenar_DataGridViewDgMerrilCrowe_Tenor()
            Llenar_TotalMerril()
        Else
            Llenar_DataGridViewDgMerrilCrowe()
            Llenar_TotalMerril()
        End If

    End Sub


    Private Sub ChKFlotaLixiSolucion_CheckedChanged(ByVal sender As Object, _
ByVal e As EventArgs) Handles ChKFlotaLixiSolucion.CheckedChanged

        If ChkTenorFLixi.Checked = True Then
            MsgBox("No es Posible Mostrar 2 Tenores. Por Favor Quitar 1 la Seleccion")
            ChKFlotaLixiSolucion.Checked = False
            Exit Sub
        End If

        If ChKFlotaLixiSolucion.Checked And CmbFlujodeMasa.Text = "Colas Espesador 5" Then
            Llenar_TenorDataGridViewDgColasEspesador5_Solucion()
        ElseIf ChKFlotaLixiSolucion.Checked = True And CmbFlujodeMasa.Text = "Alimento Agitadores" Then
            Llenar_TenorDataGridViewDgColasAgitadores_Solucion()
        ElseIf ChKFlotaLixiSolucion.Checked = True And CmbFlujodeMasa.Text = "Alimento Flotacion" Then
            'no tiene tenor soluciones
        ElseIf ChKFlotaLixiSolucion.Checked = True And CmbFlujodeMasa.Text = "Colas Agitadores" Then
            Llenar_TenorDataGridViewDgColasAgitadores_Solucion()
        ElseIf ChKFlotaLixiSolucion.Checked = True And CmbFlujodeMasa.Text = "Colas Flotacion" Then
            Llenar_TenorDataGridViewDgColasAgitadores_Solucion()
        Else
            Llenar_DataGridViewDgLixiviacion()
        End If
    End Sub

    Private Sub ChkTenorFLixi_CheckedChanged(ByVal sender As Object, _
ByVal e As EventArgs) Handles ChkTenorFLixi.CheckedChanged


        If ChKFlotaLixiSolucion.Checked = True Then
            MsgBox("No es Posible Mostrar 2 Tenores. Por Favor Quitar 1 la Seleccion")
            ChkTenorFLixi.Checked = False
            Exit Sub
        End If
        If ChkTenorFLixi.Checked = True And CmbFlujodeMasa.Text = "Colas Espesador 5" Then
            Llenar_TenorDataGridViewDgColasEspesador5_Solido()
        ElseIf CmbFlujodeMasa.Text = "Alimento Agitadores" And ChkTenorFLixi.Checked = True Then

            Llenar_TenorDataGridViewDgAgitadores_Solido()
        ElseIf CmbFlujodeMasa.Text = "Alimento Flotacion" And ChkTenorFLixi.Checked = True Then
            Llenar_TenorDataGridViewDgAlimentoFlotacion_Solido()
        ElseIf ChkTenorFLixi.Checked = True And CmbFlujodeMasa.Text = "Colas Agitadores" Then
            Llenar_TenorDataGridViewDgColasAgitadores_Solido()
        ElseIf ChkTenorFLixi.Checked = True And CmbFlujodeMasa.Text = "Colas Flotacion" Then
            Llenar_TenorDataGridViewDgColasFlotacion_Solido()
        Else
            Llenar_DataGridViewDgLixiviacion()
        End If
    End Sub

    Private Sub ChkTenorBanda_CheckedChanged(ByVal sender As Object, _
ByVal e As EventArgs) Handles ChkTenorBanda.CheckedChanged
        If ChkTenorBanda.Checked Then
            Llenar_TenorDataGridViewDgLecturaBandas()
        Else
            Llenar_DataGridViewDgLecturaBandas()
        End If

    End Sub


    Private Sub Llenar_DgHorometroKnelson_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgHorometroKnelson.CellClick
        Try
            'Aquí pongo lo que pasaría si el campo está en blanco o nulo

            If DBNull.Value.Equals(DgHorometroKnelson.CurrentRow.Cells("fecha").Value) Then
                Me.TxtHKNelsonI.Clear()
                Me.TxtHKNelsonF.Clear()
                Me.CmbKNelsonTurn.Text = "Seleccione"


            Else
                TxtHKNelsonI.Text = CStr(Me.DgHorometroKnelson.Rows(e.RowIndex).Cells("HoromInicial").Value())
                TxtHKNelsonF.Text = CStr(Me.DgHorometroKnelson.Rows(e.RowIndex).Cells("HoromFinal").Value())
                CmbKNelsonTurn.Text = CStr(Me.DgHorometroKnelson.Rows(e.RowIndex).Cells("Turno").Value())
                editahorometroknelson = True
            End If
        Catch ex As Exception
            ' Handle the exception.
            MessageBox.Show(ex.Message, Me.Text, _
  MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub dghorometroKnelson_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgHorometroKnelson.CellDoubleClick

        If MsgBox("Esta Seguro Que Desea Eliminar El Registro Seleccionado?", vbYesNo, "") = vbYes Then
            Try ' fue adentro
                If DBNull.Value.Equals(DgHorometroKnelson.CurrentRow.Cells("fecha").Value) Then  'Aquí pongo lo que pasaría si el campo está en blanco o nulo
                    TxtHKNelsonI.Clear()
                    TxtHKNelsonF.Clear()
                    CmbKNelsonTurn.Text = ""
                Else
                    Dim sqlConnectiondb As New System.Data.SqlClient.SqlConnection("Server=SEGSVRSQL01;uid=sa;pwd=*Bd6r4nC0l0mb1a*;database=PlantaBeneficio")
                    Dim cmd As New System.Data.SqlClient.SqlCommand
                    cmd.CommandType = System.Data.CommandType.Text
                    cmd.CommandText = "DELETE FROM Pb_HorasKNelson    WHERE fecha=  '" & CDate(DateTimePickerFechaReporte.Text) & "' and turno=  '" & CStr(CmbKNelsonTurn.Text) & "'  "
                    cmd.Connection = sqlConnectiondb
                    sqlConnectiondb.Open()
                    cmd.ExecuteNonQuery()
                    sqlConnectiondb.Close()
                End If
                Llenar_DgHorometroKnelson()
                TxtHKNelsonI.Clear()
                TxtHKNelsonF.Clear()
                editahorometroknelson = False
            Catch ex As Exception
                ' Handle the exception.
                MessageBox.Show(ex.Message, Me.Text, _
      MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        Else
            'ACA EL CODIGO SI PULSA NO

        End If


    End Sub

    Private Sub DgSamplesDay_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
        Try
            'Aquí pongo lo que pasaría si el campo está en blanco o nulo

            If DBNull.Value.Equals(DgSamplesDay.CurrentRow.Cells("Muestra").Value) Then
                Me.TxtSample.Clear()
                Me.ListHFrom.ClearSelected()
                Me.ListHTo.ClearSelected()
                Me.CmbLocation.Text = "Seleccione"
                Me.CmbSampleType.Text = "Seleccione"
                TxtCommentSamples.Clear()
                Me.TxtDuplicado.Text = ""
            Else
                TxtSample.Text = CStr(Me.DgSamplesDay.Rows(e.RowIndex).Cells("Muestra").Value())
                ListHFrom.Text = CStr(Me.DgSamplesDay.Rows(e.RowIndex).Cells("HoraInicial").Value())
                ListHTo.Text = CStr(Me.DgSamplesDay.Rows(e.RowIndex).Cells("Horafinal").Value())
                CmbLocation.Text = CStr(Me.DgSamplesDay.Rows(e.RowIndex).Cells("Ubicacion").Value())
                CmbSampleType.Text = CStr(Me.DgSamplesDay.Rows(e.RowIndex).Cells("TipoMuestra").Value())
                TxtDuplicado.Text = CStr(Me.DgSamplesDay.Rows(e.RowIndex).Cells("Dup").Value())
                TxtCommentSamples.Text = CStr(Me.DgSamplesDay.Rows(e.RowIndex).Cells("Comments").Value())
                editamuestra = True
            End If
        Catch ex As Exception
            ' Handle the exception.
            MessageBox.Show(ex.Message, Me.Text, _
  MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub DgLixiviacion_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgLixiviacion.CellClick
        Try
            'Aquí pongo lo que pasaría si el campo está en blanco o nulo
            If DBNull.Value.Equals(DgLixiviacion.CurrentRow.Cells("Densidad").Value) Then
                TxtDensidad.Clear()
                ListHoraInicio.ClearSelected()
                ListHoraFinal.ClearSelected()
                TxtPorc_Pasante.Clear()
                TxtGravedad.Clear()
            Else
                TxtDensidad.Text = CStr(Me.DgLixiviacion.Rows(e.RowIndex).Cells("Densidad").Value())
                ListHoraInicio.Text = CStr(Me.DgLixiviacion.Rows(e.RowIndex).Cells("HoraInicial").Value())
                ListHoraFinal.Text = CStr(Me.DgLixiviacion.Rows(e.RowIndex).Cells("HoraFinal").Value())
                CmbFlujodeMasa.Text = CStr(Me.DgLixiviacion.Rows(e.RowIndex).Cells("Espesador").Value())
                TxtGravedad.Text = CStr(Me.DgLixiviacion.Rows(e.RowIndex).Cells("SGmineral").Value())
                TxtMCubicosH.Text = CStr(Me.DgLixiviacion.Rows(e.RowIndex).Cells("VolumenLt").Value())
                TxtLixiConcentrado.Text = CStr(Me.DgLixiviacion.Rows(e.RowIndex).Cells("TonConcentrado").Value())
                If DBNull.Value.Equals(DgLixiviacion.CurrentRow.Cells("Porc_Pasante").Value) Then
                    TxtPorc_Pasante.Clear()
                Else
                    TxtPorc_Pasante.Text = CStr(Me.DgLixiviacion.Rows(e.RowIndex).Cells("Porc_Pasante").Value())
                End If
                editarlix = True
            End If

        Catch ex As Exception
            ' Handle the exception.
            MessageBox.Show(ex.Message, Me.Text, _
  MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub




    Private Sub DgLecturaBandas_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgLecturaBandas.CellClick
        Try
            If ChkTenorBanda.Checked = True Then
            Else
                If DBNull.Value.Equals(DgLecturaBandas.CurrentRow.Cells("HoraInicial").Value) Then
                    ListB12Inicio.ClearSelected()
                    ListB12Final.ClearSelected()
                    TxtLecturaInicial.Clear()
                    TxtLecturaFinal.Clear()
                    TxtPercHumedad.Clear()
                    LblIdConsecutivo.Text = "Id"
                Else
                    ListB12Inicio.Text = CStr(Me.DgLecturaBandas.Rows(e.RowIndex).Cells("HoraInicial").Value())
                    ListB12Final.Text = CStr(Me.DgLecturaBandas.Rows(e.RowIndex).Cells("HoraFinal").Value())
                    TxtLecturaInicial.Text = CStr(Me.DgLecturaBandas.Rows(e.RowIndex).Cells("LecturaInicial").Value())
                    TxtLecturaFinal.Text = CStr(Me.DgLecturaBandas.Rows(e.RowIndex).Cells("LecturaFinal").Value())
                    TxtPercHumedad.Text = CStr(Me.DgLecturaBandas.Rows(e.RowIndex).Cells("Porc_Humedad").Value())
                    LblIdConsecutivo.Text = CStr(Me.DgLecturaBandas.Rows(e.RowIndex).Cells("IdConsecutivo").Value())
                    If IsDBNull((Me.DgLecturaBandas.Rows(e.RowIndex).Cells("TonHumeda").Value())) Then
                        txtToneladas.Text = ""
                    Else
                        txtToneladas.Text = CStr(Me.DgLecturaBandas.Rows(e.RowIndex).Cells("TonHumeda").Value())
                    End If
                End If
                If IsDBNull((Me.DgLecturaBandas.Rows(e.RowIndex).Cells("Muestra").Value())) Then
                    TxtMuestraBanda.Text = ""
                Else
                    TxtMuestraBanda.Text = CStr(Me.DgLecturaBandas.Rows(e.RowIndex).Cells("Muestra").Value())
                End If
            End If

            editarbanda = True


        Catch ex As Exception
            ' Handle the exception.
            MessageBox.Show(ex.Message, Me.Text, _
  MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub




    Private Sub DgMerrilCrowe_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgMerrilCrowe.CellClick
        Try
            If DBNull.Value.Equals(DgMerrilCrowe.CurrentRow.Cells("HoraInicial").Value) Then
                ListMCInicio.ClearSelected()
                ListMCFinal.ClearSelected()
                TxtInicioMC.Clear()
                TxTFinalMC.Clear()
            Else
                ListMCInicio.Text = CStr(Me.DgMerrilCrowe.Rows(e.RowIndex).Cells("HoraInicial").Value())
                ListMCFinal.Text = CStr(Me.DgMerrilCrowe.Rows(e.RowIndex).Cells("HoraFinal").Value())
                TxtInicioMC.Text = CStr(Me.DgMerrilCrowe.Rows(e.RowIndex).Cells("LecturaInicial").Value())
                TxTFinalMC.Text = CStr(Me.DgMerrilCrowe.Rows(e.RowIndex).Cells("LecturaFinal").Value())
                editaMerril = True
            End If
        Catch ex As Exception
            ' Handle the exception.
            MessageBox.Show(ex.Message, Me.Text, _
  MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub



    Private Sub DgLixiviacion_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgLixiviacion.CellDoubleClick

        If MsgBox("Esta Seguro Que Desea Eliminar El Registro Seleccionado?", vbYesNo, "") = vbYes Then
            Try
                If DBNull.Value.Equals(DgLixiviacion.CurrentRow.Cells("HoraInicial").Value) Then
                    TxtDensidad.Clear()
                    ListHoraInicio.ClearSelected()
                    ListHoraFinal.ClearSelected()
                    TxtGravedad.Clear()
                Else
                    Dim sqlConnectiondb As New System.Data.SqlClient.SqlConnection("Server=SEGSVRSQL01;uid=sa;pwd=*Bd6r4nC0l0mb1a*;database=PlantaBeneficio")
                    Dim cmd As New System.Data.SqlClient.SqlCommand
                    cmd.CommandType = System.Data.CommandType.Text
                    cmd.CommandText = "DELETE FROM PB_Leaching    WHERE Fecha=  '" & CDate(DateTimePickerFechaReporte.Text) & "' AND Espesador= '" & CmbFlujodeMasa.Text & "' AND HoraInicial= '" & ListHoraInicio.Text & "' "
                    cmd.Connection = sqlConnectiondb
                    sqlConnectiondb.Open()
                    cmd.ExecuteNonQuery()
                    sqlConnectiondb.Close()
                End If
                Llenar_DataGridViewDgLixiviacion()
                ListHoraFinal.ClearSelected()
                TxtDensidad.Clear()
                editarlix = False
            Catch ex As Exception
                ' Handle the exception.
                MessageBox.Show(ex.Message, Me.Text, _
      MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Else
            'ACA EL CODIGO SI PULSA NO
        End If
    End Sub



    Private Sub DgMerrilCrowe_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgMerrilCrowe.CellDoubleClick
        If MsgBox("Esta Seguro Que Desea Eliminar El Registro Seleccionado?", vbYesNo, "") = vbYes Then
            Try
                If DBNull.Value.Equals(DgMerrilCrowe.CurrentRow.Cells("LecturaInicial").Value) Then
                    TxtInicioMC.Clear()
                    TxTFinalMC.Clear()
                    ListMCInicio.ClearSelected()
                    ListMCFinal.ClearSelected()
                Else
                    Dim sqlConnectiondb As New System.Data.SqlClient.SqlConnection("Server=SEGSVRSQL01;uid=sa;pwd=*Bd6r4nC0l0mb1a*;database=PlantaBeneficio")
                    Dim cmd As New System.Data.SqlClient.SqlCommand
                    cmd.CommandType = System.Data.CommandType.Text
                    cmd.CommandText = "DELETE FROM PB_MerrilCrowe    WHERE HoraInicial =  '" & CStr(ListMCInicio.Text) & "'    AND Fecha = '" & Format(CDate(DateTimePickerFechaReporte.Value), "yyyy/MM/dd") & "'   "
                    cmd.Parameters.AddWithValue("@Fecha", CDate(DateTimePickerFechaReporte.Value))
                    cmd.Connection = sqlConnectiondb
                    sqlConnectiondb.Open()
                    cmd.ExecuteNonQuery()
                    sqlConnectiondb.Close()
                End If
                Llenar_DataGridViewDgMerrilCrowe()
                ListMCInicio.ClearSelected()
                ListMCFinal.ClearSelected()
                TxtInicioMC.Clear()
                TxTFinalMC.Clear()
                editaMerril = False
            Catch ex As Exception
                ' Handle the exception.
                MessageBox.Show(ex.Message, Me.Text, _
      MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Else
            'ACA EL CODIGO SI PULSA NO
        End If

    End Sub

    Private Sub DgHorometro_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgHorometro.CellClick
        Try
            'Aquí pongo lo que pasaría si el campo está en blanco o nulo

            If DBNull.Value.Equals(DgHorometro.CurrentRow.Cells("fecha").Value) Then
                Me.TxtLinicialHorometro.Clear()
                Me.TxtLfinalHorometro.Clear()
                Me.Cmbturno.Text = "Seleccione"


            Else
                TxtLinicialHorometro.Text = CStr(Me.DgHorometro.Rows(e.RowIndex).Cells("HoromInicial").Value())
                TxtLfinalHorometro.Text = CStr(Me.DgHorometro.Rows(e.RowIndex).Cells("HoromFinal").Value())
                Cmbturno.Text = CStr(Me.DgHorometro.Rows(e.RowIndex).Cells("Turno").Value())
                editahorometro = True
            End If
        Catch ex As Exception
            ' Handle the exception.
            MessageBox.Show(ex.Message, Me.Text, _
  MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub dghorometro_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgHorometro.CellDoubleClick

        If MsgBox("Esta Seguro Que Desea Eliminar El Registro Seleccionado?", vbYesNo, "") = vbYes Then
            Try ' fue adentro
                If DBNull.Value.Equals(DgHorometro.CurrentRow.Cells("fecha").Value) Then  'Aquí pongo lo que pasaría si el campo está en blanco o nulo
                    TxtLinicialHorometro.Clear()
                    TxtLfinalHorometro.Clear()
                    Cmbturno.Text = ""
                Else
                    Dim sqlConnectiondb As New System.Data.SqlClient.SqlConnection("Server=SEGSVRSQL01;uid=sa;pwd=*Bd6r4nC0l0mb1a*;database=PlantaBeneficio")
                    Dim cmd As New System.Data.SqlClient.SqlCommand
                    cmd.CommandType = System.Data.CommandType.Text
                    cmd.CommandText = "DELETE FROM Pb_HorasMolienda    WHERE fecha=  '" & CDate(DateTimePickerFechaReporte.Text) & "' and turno=  '" & CStr(Cmbturno.Text) & "'  "
                    cmd.Connection = sqlConnectiondb
                    sqlConnectiondb.Open()
                    cmd.ExecuteNonQuery()
                    sqlConnectiondb.Close()
                End If
                Llenar_DataGridViewDgHorometro()

                editahorometro = False
            Catch ex As Exception
                ' Handle the exception.
                MessageBox.Show(ex.Message, Me.Text, _
      MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        Else
            'ACA EL CODIGO SI PULSA NO

        End If


    End Sub


    Private Sub DgSamplesDay_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)

        If MsgBox("Esta Seguro Que Desea Eliminar El Registro Seleccionado?", vbYesNo, "") = vbYes Then
            Try ' fue adentro
                If DBNull.Value.Equals(DgSamplesDay.CurrentRow.Cells("Muestra").Value) Then  'Aquí pongo lo que pasaría si el campo está en blanco o nulo
                    TxtDuplicado.Clear()
                    ListHFrom.ClearSelected()
                    ListHTo.ClearSelected()
                Else
                    Dim sqlConnectiondb As New System.Data.SqlClient.SqlConnection("Server=SEGSVRSQL01;uid=sa;pwd=*Bd6r4nC0l0mb1a*;database=PlantaBeneficio")
                    Dim cmd As New System.Data.SqlClient.SqlCommand
                    cmd.CommandType = System.Data.CommandType.Text
                    cmd.CommandText = "DELETE FROM PB_Samples    WHERE Muestra=  '" & CStr(TxtSample.Text) & "' "
                    cmd.Connection = sqlConnectiondb
                    sqlConnectiondb.Open()
                    cmd.ExecuteNonQuery()
                    sqlConnectiondb.Close()
                End If
                Llenar_DataGridViewDgSamplesDay()
                ListHFrom.ClearSelected()
                ListHTo.ClearSelected()
                CmbLocation.Text = "Seleccione"
                CmbSampleType.Text = "Seleccione"
                TxtDuplicado.Clear()
                TxtSample.Clear()
                editamuestra = False
            Catch ex As Exception
                ' Handle the exception.
                MessageBox.Show(ex.Message, Me.Text, _
      MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        Else
            'ACA EL CODIGO SI PULSA NO

        End If


    End Sub


    Private Sub DgLecturaBandas_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgLecturaBandas.CellDoubleClick
        If MsgBox("Esta Seguro Que Desea Eliminar El Registro Seleccionado?", vbYesNo, "") = vbYes Then
            Try
                'Aquí pongo lo que pasaría si el campo está en blanco o nulo

                If DBNull.Value.Equals(DgLecturaBandas.CurrentRow.Cells("LecturaInicial").Value) Then
                    TxtLecturaInicial.Clear()
                    TxtLecturaFinal.Clear()
                    TxtPercHumedad.Clear()
                    TxtMuestraBanda.Clear()

                    ListB12Inicio.ClearSelected()
                    ListB12Final.ClearSelected()
                Else
                    Dim sqlConnectiondb As New System.Data.SqlClient.SqlConnection("Server=SEGSVRSQL01;uid=sa;pwd=*Bd6r4nC0l0mb1a*;database=PlantaBeneficio")
                    Dim cmd As New System.Data.SqlClient.SqlCommand
                    cmd.CommandType = System.Data.CommandType.Text
                    'cmd.CommandText = "DELETE FROM PB_Conveyor    WHERE LecturaInicial=  '" & CDec(DgLecturaBandas.CurrentRow.Cells("LecturaInicial").Value) & "' "
                    cmd.CommandText = "DELETE FROM PB_Conveyor    WHERE IdConsecutivo=  '" & CInt(DgLecturaBandas.CurrentRow.Cells("IdConsecutivo").Value) & "' "
                    cmd.Connection = sqlConnectiondb
                    sqlConnectiondb.Open()
                    cmd.ExecuteNonQuery()
                    sqlConnectiondb.Close()
                End If

                Llenar_DataGridViewDgLecturaBandas()
                ListB12Inicio.ClearSelected()
                ListB12Final.ClearSelected()
                TxtLecturaInicial.Clear()
                CmbSampleType.Text = "Seleccione"
                TxtDuplicado.Clear()
                TxtLecturaFinal.Clear()
                TxtPercHumedad.Clear()
                editarbanda = False
            Catch ex As Exception
                ' Handle the exception.
                MessageBox.Show(ex.Message, Me.Text, _
      MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        Else
            'ACA EL CODIGO SI PULSA NO


        End If

    End Sub


    Private Sub Llenar_DatagridViewE5_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgFlujoE5.CellClick
        Try
            'Aquí pongo lo que pasaría si el campo está en blanco o nulo

            If DBNull.Value.Equals(DgFlujoE5.CurrentRow.Cells("LecturaInicial").Value) Then
                Me.TxtInicioE5.Clear()
                Me.TxtFinalE5.Clear()
                Me.TxtDensidadE5.Clear()
                Me.TxtHorasOperacione5.Clear()
                Me.CmbTurnoE5.Text = "Seleccione"
                Me.TxtHVertCep5.Clear()

            Else
                TxtInicioE5.Text = CStr(Me.DgFlujoE5.Rows(e.RowIndex).Cells("LecturaInicial").Value())
                TxtFinalE5.Text = CStr(Me.DgFlujoE5.Rows(e.RowIndex).Cells("LecturaFinal").Value())
                TxtDensidadE5.Text = CStr(Me.DgFlujoE5.Rows(e.RowIndex).Cells("Densidad").Value())
                TxtHorasOperacione5.Text = CStr(Me.DgFlujoE5.Rows(e.RowIndex).Cells("HorasOperacion").Value())
                CmbTurnoE5.Text = CStr(Me.DgFlujoE5.Rows(e.RowIndex).Cells("Turno").Value())
                TxtHVertCep5.Text = CStr(Me.DgFlujoE5.Rows(e.RowIndex).Cells("HorasVertimiento").Value())
                editarflujoe5 = True
            End If
        Catch ex As Exception
            ' Handle the exception.
            MessageBox.Show(ex.Message, Me.Text, _
  MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub



    Private Sub DgFlujometroE5_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgFlujoE5.CellDoubleClick

        If MsgBox("Esta Seguro Que Desea Eliminar El Registro Seleccionado?", vbYesNo, "") = vbYes Then
            Try ' fue adentro
                If DBNull.Value.Equals(DgFlujoE5.CurrentRow.Cells("LecturaInicial").Value) Then  'Aquí pongo lo que pasaría si el campo está en blanco o nulo
                    Me.TxtInicioE5.Clear()
                    Me.TxtFinalE5.Clear()
                    Me.TxtDensidadE5.Clear()
                    Me.TxtHorasOperacione5.Clear()
                    Me.CmbTurnoE5.Text = "Seleccione"
                Else
                    Dim sqlConnectiondb As New System.Data.SqlClient.SqlConnection("Server=SEGSVRSQL01;uid=sa;pwd=*Bd6r4nC0l0mb1a*;database=PlantaBeneficio")
                    Dim cmd As New System.Data.SqlClient.SqlCommand
                    cmd.CommandType = System.Data.CommandType.Text
                    cmd.CommandText = "DELETE FROM Pb_FlowsE5    WHERE fecha=  '" & CDate(DateTimePickerFechaReporte.Text) & "' and turno=  '" & CStr(CmbTurnoE5.Text) & "'  "
                    cmd.Connection = sqlConnectiondb
                    sqlConnectiondb.Open()
                    cmd.ExecuteNonQuery()
                    sqlConnectiondb.Close()
                End If
                Llenar_DataGridViewDgFlujometroE5()
                Me.TxtInicioE5.Clear()
                Me.TxtFinalE5.Clear()
                Me.TxtDensidadE5.Clear()
                Me.TxtHorasOperacione5.Clear()
                Me.CmbTurnoE5.Text = "Seleccione"
                TxtInicioE5.Focus()
                editarflujoe5 = False
            Catch ex As Exception
                ' Handle the exception.
                MessageBox.Show(ex.Message, Me.Text, _
      MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        Else
            'ACA EL CODIGO SI PULSA NO

        End If


    End Sub

    Private Sub Llenar_DatagridviewColasFlotacion_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgColasFlotacion.CellClick
        Try
            If DBNull.Value.Equals(DgColasFlotacion.CurrentRow.Cells("LecturaInicial").Value) Then
                Me.TxtInicioFl.Clear()
                Me.TxtFinalFl.Clear()
                Me.TxtDensidadFl.Clear()
                Me.TxtHorasFl.Clear()
                Me.TxtHVertimientoFl.Clear()
                Me.CmbTurnoFl.Text = "Seleccione"
            Else
                TxtInicioFl.Text = CStr(Me.DgColasFlotacion.Rows(e.RowIndex).Cells("LecturaInicial").Value())
                TxtFinalFl.Text = CStr(Me.DgColasFlotacion.Rows(e.RowIndex).Cells("LecturaFinal").Value())
                TxtDensidadFl.Text = CStr(Me.DgColasFlotacion.Rows(e.RowIndex).Cells("Densidad").Value())
                TxtHorasFl.Text = CStr(Me.DgColasFlotacion.Rows(e.RowIndex).Cells("HorasOperacion").Value())
                TxtHVertimientoFl.Text = CStr(Me.DgColasFlotacion.Rows(e.RowIndex).Cells("HorasVertimiento").Value())
                CmbTurnoFl.Text = CStr(Me.DgColasFlotacion.Rows(e.RowIndex).Cells("Turno").Value())
                editaflujoflotacion = True
            End If
        Catch ex As Exception
            ' Handle the exception.
            MessageBox.Show(ex.Message, Me.Text, _
  MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub


    Private Sub DgFlujometroColasFlotacion_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgColasFlotacion.CellDoubleClick

        If MsgBox("Esta Seguro Que Desea Eliminar El Registro Seleccionado?", vbYesNo, "") = vbYes Then
            Try ' fue adentro
                If DBNull.Value.Equals(DgColasFlotacion.CurrentRow.Cells("LecturaInicial").Value) Then  'Aquí pongo lo que pasaría si el campo está en blanco o nulo
                    Me.TxtInicioFl.Clear()
                    Me.TxtFinalFl.Clear()
                    Me.TxtDensidadFl.Clear()
                    Me.TxtHorasFl.Clear()
                    Me.CmbTurnoFl.Text = "Seleccione"
                Else
                    Dim sqlConnectiondb As New System.Data.SqlClient.SqlConnection("Server=SEGSVRSQL01;uid=sa;pwd=*Bd6r4nC0l0mb1a*;database=PlantaBeneficio")
                    Dim cmd As New System.Data.SqlClient.SqlCommand
                    cmd.CommandType = System.Data.CommandType.Text
                    cmd.CommandText = "DELETE FROM Pb_FlowsColasBulk    WHERE fecha=  '" & CDate(DateTimePickerFechaReporte.Text) & "' and turno=  '" & CStr(CmbTurnoFl.Text) & "'  "
                    cmd.Connection = sqlConnectiondb
                    sqlConnectiondb.Open()
                    cmd.ExecuteNonQuery()
                    sqlConnectiondb.Close()
                End If
                Llenar_DataGridViewDgFlujometroFlotacion()
                Me.TxtInicioFl.Clear()
                Me.TxtFinalFl.Clear()
                Me.TxtDensidadFl.Clear()
                Me.TxtHorasFl.Clear()
                Me.CmbTurnoFl.Text = "Seleccione"
                TxtInicioFl.Focus()
                editaflujoflotacion = False
            Catch ex As Exception
                ' Handle the exception.
                MessageBox.Show(ex.Message, Me.Text, _
      MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        Else
            'ACA EL CODIGO SI PULSA NO

        End If
    End Sub

    Private Sub DgFlujometroRebalseCiclon_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgFlujoHidrociclones.CellDoubleClick

        If MsgBox("Esta Seguro Que Desea Eliminar El Registro Seleccionado?", vbYesNo, "") = vbYes Then
            Try ' fue adentro
                If DBNull.Value.Equals(DgFlujoHidrociclones.CurrentRow.Cells("LecturaInicial").Value) Then  'Aquí pongo lo que pasaría si el campo está en blanco o nulo
                    Me.TxtInicioHidro.Clear()
                    Me.TxtFinalHidro.Clear()
                    Me.TxtDensidadHidro.Clear()
                    Me.CmbTurnoRciclon.Text = "Seleccione"
                Else
                    Dim sqlConnectiondb As New System.Data.SqlClient.SqlConnection("Server=SEGSVRSQL01;uid=sa;pwd=*Bd6r4nC0l0mb1a*;database=PlantaBeneficio")
                    Dim cmd As New System.Data.SqlClient.SqlCommand
                    cmd.CommandType = System.Data.CommandType.Text
                    cmd.CommandText = "DELETE FROM Pb_FlowsRebalseCiclon    WHERE fecha=  '" & CDate(DateTimePickerFechaReporte.Text) & "' and turno=  '" & CStr(CmbTurnoRciclon.Text) & "'  "
                    cmd.Connection = sqlConnectiondb
                    sqlConnectiondb.Open()
                    cmd.ExecuteNonQuery()
                    sqlConnectiondb.Close()
                End If
                Llenar_DataGridViewDgFlujometroRebalse()
                Me.TxtInicioHidro.Clear()
                Me.TxtFinalHidro.Clear()
                Me.TxtDensidadHidro.Clear()
                'Me.TxtHorasFl.Clear()
                Me.CmbTurnoRciclon.Text = "Seleccione"
                TxtInicioHidro.Focus()
                editaflujoRebalse = False
            Catch ex As Exception
                ' Handle the exception.
                MessageBox.Show(ex.Message, Me.Text, _
      MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        Else
            'ACA EL CODIGO SI PULSA NO

        End If
    End Sub


    Private Sub Llenar_DatagridviewRebalseCiclon_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgFlujoHidrociclones.CellClick
        Try
            If DBNull.Value.Equals(DgFlujoHidrociclones.CurrentRow.Cells("LecturaInicial").Value) Then
                Me.TxtInicioHidro.Clear()
                Me.TxtFinalHidro.Clear()
                Me.TxtDensidadHidro.Clear()
                Me.CmbTurnoRciclon.Text = "Seleccione"
            Else
                TxtInicioHidro.Text = CStr(Me.DgFlujoHidrociclones.Rows(e.RowIndex).Cells("LecturaInicial").Value())
                TxtFinalHidro.Text = CStr(Me.DgFlujoHidrociclones.Rows(e.RowIndex).Cells("LecturaFinal").Value())
                TxtDensidadHidro.Text = CStr(Me.DgFlujoHidrociclones.Rows(e.RowIndex).Cells("Densidad").Value())
                CmbTurnoRciclon.Text = CStr(Me.DgFlujoHidrociclones.Rows(e.RowIndex).Cells("Turno").Value())
                editaflujoRebalse = True
            End If
        Catch ex As Exception
            ' Handle the exception.
            MessageBox.Show(ex.Message, Me.Text, _
  MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub





    Private Sub picturebox1_enfoque(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox2.MouseHover
        PictureBox2.BorderStyle = BorderStyle.FixedSingle
    End Sub
    Private Sub picturebox1_quitarenfoque(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox2.MouseLeave
        PictureBox2.BorderStyle = BorderStyle.None
    End Sub

    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox2.Click
        Dim cnstr As String
        cnstr = "Provider=SQLNCLI10;Initial Catalog=PlantaBeneficio;Data Source=SEGSVRSQL01; User ID=sa;Password=*Bd6r4nC0l0mb1a*;"
        'mensaje de exportacion mientras se ejecuta el codigo
        LblExport.Visible = True
        Try
            Dim objExcel As Microsoft.Office.Interop.Excel.Application
            objExcel = New Microsoft.Office.Interop.Excel.Application
            Dim hoja As Microsoft.Office.Interop.Excel.Worksheet
            objExcel.Workbooks.Open("\\athenea\pampaverde\mineria\Data\DataBase\Templates\GZC_TemplateExportSamplesAssay.xlsx")
            With objExcel
                hoja = CType(.Sheets("Report"), Microsoft.Office.Interop.Excel.Worksheet)
                hoja.Cells(3, 4) = DateTimePickerFechaReporte.Value
                Dim recorrido As Integer
                ' la variable recorrido indica la fila en la hoja excel.
                recorrido = 7
                objExcel.Visible = False
                Dim parametromuestra As String
                For Each dRow As DataGridViewRow In DgSamplesDay.Rows
                    parametromuestra = CStr(dRow.Cells.Item("Muestra").Value)
                    ' obtener con el recordset el plan mensual de cada frente de trabajo
                    If parametromuestra IsNot Nothing Then
                        hoja.Cells(recorrido, 1) = dRow.Cells.Item("HoraInicial").Value
                        hoja.Cells(recorrido, 2) = dRow.Cells.Item("HoraFinal").Value
                        hoja.Cells(recorrido, 3) = dRow.Cells.Item("Muestra").Value
                        hoja.Cells(recorrido, 4) = dRow.Cells.Item("Ubicacion").Value
                        hoja.Cells(recorrido, 5) = dRow.Cells.Item("TipoMuestra").Value
                        If ChkTenor.Checked Then
                            hoja.Cells(recorrido, 6) = dRow.Cells.Item("AuFinal_ppm").Value
                            hoja.Cells(recorrido, 7) = dRow.Cells.Item("Ag_Ppm").Value
                            hoja.Cells(recorrido, 8) = dRow.Cells.Item("Peso_gr").Value
                        Else
                            hoja.Cells(recorrido, 6) = "--"
                            hoja.Cells(recorrido, 7) = "--"
                            hoja.Cells(recorrido, 8) = "--"
                        End If
                    End If
                    recorrido = recorrido + 1
                Next dRow
                LblExport.Visible = False
                objExcel.Visible = True
            End With
        Catch ex As Exception
            ' Handle the exception.
            MessageBox.Show(ex.Message, Me.Text, _
  MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ChkTenor_CheckedChanged(ByVal sender As Object, _
ByVal e As EventArgs) Handles ChkTenor.CheckedChanged
        If ChkTenor.Checked Then
            Llenar_TenorDataGridViewDgSamplesDay()
        Else
            Llenar_DataGridViewDgSamplesDay()
        End If

    End Sub

    Private Sub ChkTimeView_CheckedChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkTimeView.CheckedChanged

        If ChkTimeView.Checked Then
            CmbHoraInicio.Visible = True
            CmbHoraFinal.Visible = True

        Else
            CmbHoraInicio.Visible = False
            CmbHoraFinal.Visible = False

        End If


    End Sub

    Private Sub CmbFlujodeMasa_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbFlujodeMasa.SelectedIndexChanged
        ChkTenorFLixi.Checked = False
        ChKFlotaLixiSolucion.Checked = False
        Llenar_DataGridViewDgLixiviacion()
    End Sub

    Private Sub CmdGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdGuardar.Click

        Dim DsPriv As New DataSet
        Dim EPermisos As New SqlClient.SqlDataAdapter("SELECT Usuario, IdEvento FROM RfUserEvent" & _
" WHERE RfUserEvent.Usuario='" & LblUsuario.Text & "'  and (RfUserEvent.IdEvento  = 'ModificarMineralPlant'  ) ", Cn)
        EPermisos.Fill(DsPriv, "RfUserEvent")
        Dim myDataViewpermisos As DataView = New DataView(DsPriv.Tables("RfUserEvent"))
        If myDataViewpermisos.Count = 0 Then
            MsgBox("El usuario no tiene privilegios para Modificar en este Formulario. Contacte a su administrador.")
            Exit Sub
        End If

        If TxtDensidad.Text = "" Or ListHoraInicio.Text = "" Or ListHoraFinal.Text = "" Or CmbFlujodeMasa.Text = "Seleccione" Then
            MsgBox("Todos los campos son obligatorios, por favor Diligencie correctamente el formulario")

        Else
            Try
                Dim sqlConnectiondb As New System.Data.SqlClient.SqlConnection("Server=SEGSVRSQL01;uid=sa;pwd=*Bd6r4nC0l0mb1a*;database=PlantaBeneficio")
                Dim cmd As New System.Data.SqlClient.SqlCommand
                cmd.CommandType = System.Data.CommandType.Text
                If editarlix = True Then
                    'CONSULTA CUANDO EDITAR ES VERDADERO
                    cmd.CommandText = "UPDATE  PB_Leaching  SET   HoraFinal= @HoraFinal , Densidad = @Densidad , Porc_Pasante=@Porc_Pasante , SGmineral=@SGmineral , VolumenLt=@VolumenLt ,  TonConcentrado= @TonConcentrado WHERE  Espesador = @Espesador AND Fecha = @Fecha  AND  HoraInicial = @HoraInicial "
                Else
                    ' consulta sql si editar es falso 
                    cmd.CommandText = "INSERT INTO PB_Leaching (Fecha,HoraInicial,HoraFinal, Espesador,  Densidad, Porc_Pasante, SGmineral, VolumenLt , TonConcentrado)VALUES(@Fecha ,@HoraInicial,@HoraFinal,@Espesador,@Densidad, @Porc_Pasante, @SGmineral, @VolumenLt, @TonConcentrado)"
                End If
                cmd.Parameters.AddWithValue("@Fecha", CDate(DateTimePickerFechaReporte.Text))
                cmd.Parameters.AddWithValue("@HoraInicial", Convert.ToString(ListHoraInicio.Text))
                cmd.Parameters.AddWithValue("@HoraFinal", Convert.ToString(ListHoraFinal.Text))
                cmd.Parameters.AddWithValue("@Espesador", Convert.ToString(CmbFlujodeMasa.Text))

                If TxtPorc_Pasante.Text = "" Then
                    cmd.Parameters.AddWithValue("@Porc_Pasante", 0)
                Else
                    cmd.Parameters.AddWithValue("@Porc_Pasante", Convert.ToDecimal(TxtPorc_Pasante.Text))
                End If

                If TxtGravedad.Text = "" Or CDbl(TxtGravedad.Text) = 0 Then
                    cmd.Parameters.AddWithValue("@SGmineral", 3)
                Else
                    cmd.Parameters.AddWithValue("@SGmineral", Convert.ToDecimal(TxtGravedad.Text))
                End If
                If CDbl(TxtDensidad.Text) <= 0 Then
                    cmd.Parameters.AddWithValue("@Densidad", 1)
                Else
                    cmd.Parameters.AddWithValue("@Densidad", Convert.ToDecimal(TxtDensidad.Text))
                End If


                cmd.Parameters.AddWithValue("@VolumenLt", Convert.ToDecimal(TxtMCubicosH.Text))
                cmd.Parameters.AddWithValue("@TonConcentrado", Convert.ToDecimal(TxtLixiConcentrado.Text))
                cmd.Connection = sqlConnectiondb
                sqlConnectiondb.Open()
                cmd.ExecuteNonQuery()
                sqlConnectiondb.Close()
                MessageBox.Show("Los datos se  guardaron Correctamente.")
                Llenar_DataGridViewDgLixiviacion()
                ListHoraInicio.Text = ListHoraFinal.Text
                TxtDensidad.Focus()
                If editarlix = True Then

                Else
                    If ListHoraFinal.SelectedIndex + 3 > 23 Then

                        ListHoraFinal.SelectedIndex = 2
                    Else
                        ListHoraFinal.SelectedIndex = ListHoraFinal.SelectedIndex + 3
                    End If
                End If

                TxtDensidad.Clear()
                TxtLixiConcentrado.Clear()
                editarlix = False
                DgLixiviacion.FirstDisplayedScrollingRowIndex = DgLixiviacion.RowCount - 1
            Catch ex As Exception
                ' Handle the exception.
                MessageBox.Show(ex.Message, Me.Text, _
      MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub CmdSaveBanda_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdSaveBanda.Click
        Dim DsPriv As New DataSet
        Dim EPermisos As New SqlClient.SqlDataAdapter("SELECT Usuario, IdEvento FROM RfUserEvent" & _
" WHERE RfUserEvent.Usuario='" & LblUsuario.Text & "'  and (RfUserEvent.IdEvento  = 'ModificarBanda'  ) ", Cn)
        EPermisos.Fill(DsPriv, "RfUserEvent")
        Dim myDataViewpermisos As DataView = New DataView(DsPriv.Tables("RfUserEvent"))

        If myDataViewpermisos.Count = 0 Then
            MsgBox("El usuario no tiene privilegios para Modificar en este Formulario. Contacte a su administrador.")
            Exit Sub
        End If
        If ListB12Inicio.Text = "" Or ListB12Final.Text = "" Or TxtLecturaInicial.Text = "" Or TxtLecturaFinal.Text = "" Then
            MsgBox("Todos los campos son obligatorios, por favor Diligencie correctamente el formulario")
        Else
            Try
                Dim sqlConnectiondb As New System.Data.SqlClient.SqlConnection("Server=SEGSVRSQL01;uid=sa;pwd=*Bd6r4nC0l0mb1a*;database=PlantaBeneficio")
                Dim cmd As New System.Data.SqlClient.SqlCommand
                cmd.CommandType = System.Data.CommandType.Text

                If editarbanda = True Then
                    'CONSULTA CUANDO EDITAR ES VERDADERO
                    cmd.CommandText = "UPDATE  PB_Conveyor  SET HoraInicial = @HoraInicial,  HoraFinal= @HoraFinal , Fecha=@Fecha,  LecturaFinal = @LecturaFinal , Porc_Humedad=@Porc_Humedad , TonHumedaManual=@TonHumedaManual, Muestra=@Muestra WHERE IdConsecutivo=@IdConsecutivo  "
                Else
                    ' consulta sql si editar es falso 
                    cmd.CommandText = "INSERT INTO PB_Conveyor (HoraInicial,HoraFinal,Fecha, LecturaInicial,  LecturaFinal, Porc_Humedad, TonHumedaManual, Muestra)VALUES(@HoraInicial,@HoraFinal,@Fecha, @LecturaInicial,  @LecturaFinal, @Porc_Humedad, @TonHumedaManual, @Muestra)"
                End If
                cmd.Parameters.AddWithValue("@HoraInicial", Convert.ToString(ListB12Inicio.Text))
                cmd.Parameters.AddWithValue("@HoraFinal", Convert.ToString(ListB12Final.Text))
                cmd.Parameters.AddWithValue("@Fecha", CDate(DateTimePickerFechaReporte.Text))
                cmd.Parameters.AddWithValue("@LecturaInicial", Convert.ToDecimal(TxtLecturaInicial.Text))
                cmd.Parameters.AddWithValue("@LecturaFinal", Convert.ToDecimal(TxtLecturaFinal.Text))
                cmd.Parameters.AddWithValue("@Porc_Humedad", Convert.ToDecimal(TxtPercHumedad.Text))
                cmd.Parameters.AddWithValue("@TonHumedaManual", Convert.ToDecimal(txtToneladas.Text))
                cmd.Parameters.AddWithValue("@IdConsecutivo", Convert.ToInt32(LblIdConsecutivo.Text))
                cmd.Parameters.AddWithValue("@Muestra", Convert.ToString(TxtMuestraBanda.Text))
                cmd.Connection = sqlConnectiondb
                sqlConnectiondb.Open()
                cmd.ExecuteNonQuery()
                sqlConnectiondb.Close()
                MessageBox.Show("Los datos se  guardaron Correctamente.")
                'Llenar_DataGridViewDesarrollo()
                Llenar_DataGridViewDgLecturaBandas()
                TxtLecturaInicial.Text = TxtLecturaFinal.Text
                TxtMuestraBanda.Clear()
                ListB12Inicio.Text = ListB12Final.Text
                TxtLecturaFinal.Focus()
                If editarbanda = True Then
                Else
                    If ListB12Final.SelectedIndex + 1 > 23 Then
                        ListB12Final.SelectedIndex = 0
                    Else
                        ListB12Final.SelectedIndex = ListB12Final.SelectedIndex + 1
                    End If
                End If
                TxtLecturaFinal.Clear()
                TxtPercHumedad.Clear()
                txtToneladas.Clear()
                editarbanda = False
                DgLecturaBandas.FirstDisplayedScrollingRowIndex = DgLecturaBandas.RowCount - 1
            Catch ex As Exception
                ' Handle the exception.
                MessageBox.Show(ex.Message, Me.Text, _
      MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        End If

    End Sub

    Private Sub CmdReporteMineras_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdReporteMineras.Click
        Dim fechainicio As Date
        Dim fechafin As Date
        fechainicio = CDate(DtFechaInicio.Value)
        fechafin = CDate(DtFechaFinal.Value)
        Dim dias As Double
        dias = (DtFechaFinal.Value - DtFechaInicio.Value).TotalDays
        If dias > 31 Then
            MsgBox("Por Favor Seleccione un rango de Fecha no superior a 30 dias.")
            Exit Sub
        End If

        Try
            Dim fechactual As Date
            cnStr = "Provider=SQLNCLI10;Initial Catalog=PlantaBeneficio;Data Source=SEGSVRSQL01; User ID=sa;Password=*Bd6r4nC0l0mb1a*;"
            conn.Open(cnStr)
            Dim objExcel As Microsoft.Office.Interop.Excel.Application
            objExcel = New Microsoft.Office.Interop.Excel.Application
            Dim hoja As Microsoft.Office.Interop.Excel.Worksheet
            objExcel.Workbooks.Open("\\athenea\pampaverde\mineria\Data\DataBase\Templates\PlantaBeneficio_140123_TemplateMinerasReportDaily.xlsx")
            Dim recorrido As Integer
            Dim columna As Integer
            Dim totaltoneladas As Decimal = 0
            Dim totalonzas As Decimal = 0
            LblExportar.Visible = True
            recorrido = 3
            objExcel.Visible = False
            rstoperacionrep = conn.Execute("  SELECT        Fecha, ConsumoEnergia, TonHora, OperacionHorasDia, DetencionMtto, DetencionOperacion, TonMolidasZandor, TonMolidasMineras FROM            dbo.PB_Operation  WHERE (   PB_Operation.Fecha >= '" & Format(fechainicio, "yyyy/MM/dd") & "' )and  (PB_Operation.Fecha <= '" & Format(fechafin, "yyyy/MM/dd") & "')   ")
            With objExcel
                hoja = CType(.Sheets("Report"), Microsoft.Office.Interop.Excel.Worksheet)
                Do While Not rstoperacionrep.EOF
                    columna = 2
                    rstoperationContract = conn.Execute(" SELECT        TOP (100) PERCENT Id, Name, enabled   FROM dbo.RfOperationContracts                WHERE Enabled = 1 ORDER BY Name ")
                    hoja.Cells(recorrido, 1) = CDate(rstoperacionrep.Fields("Fecha").Value)
                    totaltoneladas = 0
                    totalonzas = 0
                    Do While Not rstoperationContract.EOF
                        Dim nombremina As String
                        nombremina = CStr(rstoperationContract.Fields("name").Value)
                        fechactual = CDate(rstoperacionrep.Fields("Fecha").Value)
                        If recorrido = 3 Then
                            hoja.Cells(1, columna) = CStr(rstoperationContract.Fields("name").Value)
                            hoja.Cells(2, columna) = "Toneladas"
                            hoja.Cells(2, columna + 1) = "Tenor"
                            hoja.Cells(2, columna + 2) = "Onzas"
                        End If
                        rstmineras = conn.Execute("  SELECT       Fecha, Mina, NombreMina,  SUM(TonMineralS) AS TotalSeca , TenorPromedio FROM            dbo.vw_Pb_PequenaMinera  GROUP BY Fecha, NombreMina, Mina, TenorPromedio HAVING           (   dbo.vw_Pb_PequenaMinera.Fecha = '" & Format(fechactual, "yyyy/MM/dd") & "' )  and (NombreMina= '" & nombremina & "' )   ")
                        If rstmineras.EOF = True And rstmineras.BOF = True Then
                            'no hay mineral
                            hoja.Cells(recorrido, columna) = 0
                            columna = columna + 1
                            hoja.Cells(recorrido, columna) = 0
                            columna = columna + 1
                            hoja.Cells(recorrido, columna) = 0
                            columna = columna + 1
                        Else
                            'si hay mineral
                            hoja.Cells(recorrido, columna) = rstmineras.Fields("TotalSeca").Value
                            columna = columna + 1
                            hoja.Cells(recorrido, columna) = rstmineras.Fields("TenorPromedio").Value
                            columna = columna + 1
                            hoja.Cells(recorrido, columna) = (CDec(rstmineras.Fields("TenorPromedio").Value) * CDec(rstmineras.Fields("TotalSeca").Value)) / 31.1035
                            columna = columna + 1
                            totaltoneladas = totaltoneladas + CDec(rstmineras.Fields("TotalSeca").Value)
                            totalonzas = CDec(totalonzas + ((CDec(rstmineras.Fields("TenorPromedio").Value) * CDec(rstmineras.Fields("TotalSeca").Value)) / 31.1035))

                        End If
                        rstoperationContract.MoveNext()
                    Loop
                    hoja.Cells(recorrido, columna + 1) = totaltoneladas
                    hoja.Cells(recorrido, columna + 2) = totalonzas
                    recorrido = recorrido + 1
                    rstoperacionrep.MoveNext()
                Loop
            End With
            objExcel.Visible = True
            conn.Close()
            LblExportar.Visible = False
        Catch ex As Exception
            ' Handle the exception.
            MessageBox.Show(ex.Message, Me.Text, _
  MessageBoxButtons.OK, MessageBoxIcon.Error)
            conn.Close()
            LblExportar.Visible = False
        End Try
    End Sub

    Private Sub CmdExportDaily_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdExportDaily.Click
        Dim fechainicio As Date
        Dim fechafin As Date
        fechainicio = CDate(DtFechaInicio.Value)
        fechafin = CDate(DtFechaFinal.Value)
        Dim dias As Double
        dias = (DtFechaFinal.Value - DtFechaInicio.Value).TotalDays
        If dias > 31 Then
            MsgBox("Por Favor Seleccione un rango de Fecha no superior a 30 dias.")
            Exit Sub
        End If
        exportarsolidos()



    End Sub
    Private Sub exportarsolidos()
        Dim totaltoneladas As Double
        Dim totalgramos As Double
        Dim conn As New ADODB.Connection()
        Dim RstResumen As New ADODB.Recordset()
        Dim RstResumenTenor As New ADODB.Recordset()
        Dim RstResumenTenorsolucion As New ADODB.Recordset()
        Dim cnStr As String
        cnStr = "Provider=SQLNCLI10;Initial Catalog=PlantaBeneficio;Data Source=SEGSVRSQL01; User ID=sa;Password=*Bd6r4nC0l0mb1a*;"
        conn.Open(cnStr)
        Dim objExcel As Microsoft.Office.Interop.Excel.Application
        objExcel = New Microsoft.Office.Interop.Excel.Application
        Dim hoja As Microsoft.Office.Interop.Excel.Worksheet
        objExcel.Workbooks.Open("\\athenea\pampaverde\mineria\Data\DataBase\Templates\BALANCEPLANTA.xlsx")
        Dim recorrido As Integer
        recorrido = 2
        totaltoneladas = 0
        totalgramos = 0
        objExcel.Visible = False
        RstResumen = conn.Execute(" SELECT Fecha, Turno, ToneladasTurno, PromedioDensidad, PromedioGravedad FROM  dbo.Pb_ConcentradoFlotacion where     (Fecha >= '" & CDate(DtFechaInicio.Text) & "') AND (Fecha <= '" & CDate(DtFechaFinal.Text) & "')  ORDER BY Fecha ")
        RstResumenTenor = conn.Execute(" SELECT     Fecha, Turno, AuFinal_ppm FROM         dbo.Pb_ConcentradoFlotacionTenor where     (Fecha >= '" & CDate(DtFechaInicio.Text) & "') AND (Fecha <= '" & CDate(DtFechaFinal.Text) & "')  ORDER BY Fecha ")
        'RstR = conn.Execute(" SELECT     Fecha, Turno, AuFinal_ppm FROM         dbo.Pb_ConcentradoFlotacionTenor where     (Fecha >= '" & CDate(DtFechaInicio.Text) & "') AND (Fecha <= '" & CDate(DtFechaFinal.Text) & "')  ORDER BY Fecha ")
        'RstResumenTenorSolucion = conn.Execute("SELECT     TOP (100) PERCENT dbo.PB_MerrilCrowe.Fecha, SUM(dbo.PB_MerrilCrowe.Volumen) AS VolumenTotal, SUM(dbo.PB_MerrilCrowe.Onzas) AS OnzasTotal,  AVG(dbo.PB_MerrilCrowe.TenorCabeza) AS TenorPromedio, AVG(dbo.PB_MerrilCrowe.TenorCola) AS TenorColas FROM         dbo.PB_MerrilCrowe INNER JOIN     dbo.RfTime ON dbo.PB_MerrilCrowe.HoraInicial = dbo.RfTime.Hora GROUP BY dbo.PB_MerrilCrowe.Fecha    HAVING        (Fecha >= '" & CDate(DtFechainicio.Text) & "') AND (Fecha <= '" & CDate(DtFechaFinal.Text) & "')")
        With objExcel
            'concentrado de flotacion
            hoja = CType(.Sheets("ConcentradoFlotacion"), Microsoft.Office.Interop.Excel.Worksheet)
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
            hoja = CType(.Sheets("TenorFlotacion"), Microsoft.Office.Interop.Excel.Worksheet)
            Do While Not RstResumenTenor.EOF
                hoja.Cells(recorrido, 1) = RstResumenTenor.Fields("Fecha").Value
                hoja.Cells(recorrido, 2) = RstResumenTenor.Fields("Turno").Value
                hoja.Cells(recorrido, 3) = RstResumenTenor.Fields("AuFinal_ppm").Value
                recorrido = recorrido + 1
                RstResumenTenor.MoveNext()
            Loop


            'agitador 1
            RstResumen = conn.Execute(" SELECT Fecha, Turno, ToneladasTurno, PromedioDensidad, PromedioGravedad FROM  dbo.Pb_ConcentradoAAG1 where     (Fecha >= '" & CDate(DtFechaInicio.Text) & "') AND (Fecha <= '" & CDate(DtFechaFinal.Text) & "')  ORDER BY Fecha ")
            RstResumenTenor = conn.Execute(" SELECT     Fecha, Turno, AuFinal_ppm FROM         dbo.Pb_AlimentoAG1Solido where     (Fecha >= '" & CDate(DtFechaInicio.Text) & "') AND (Fecha <= '" & CDate(DtFechaFinal.Text) & "')  ORDER BY Fecha ")
            RstResumenTenorsolucion = conn.Execute(" SELECT     Fecha, Turno, AuFinal_ppm FROM         dbo.Pb_AlimentoAG1Solido where     (Fecha >= '" & CDate(DtFechaInicio.Text) & "') AND (Fecha <= '" & CDate(DtFechaFinal.Text) & "')  ORDER BY Fecha ")

            recorrido = 2
            'concentrado de flotacion
            hoja = CType(.Sheets("AlimentoAgitador1"), Microsoft.Office.Interop.Excel.Worksheet)
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
            hoja = CType(.Sheets("AlimentoAgitadorSolido"), Microsoft.Office.Interop.Excel.Worksheet)
            Do While Not RstResumenTenor.EOF
                hoja.Cells(recorrido, 1) = RstResumenTenor.Fields("Fecha").Value
                hoja.Cells(recorrido, 2) = RstResumenTenor.Fields("Turno").Value
                hoja.Cells(recorrido, 3) = RstResumenTenor.Fields("AuFinal_ppm").Value
                recorrido = recorrido + 1
                RstResumenTenor.MoveNext()
            Loop

            recorrido = 2
            hoja = CType(.Sheets("AlimentoAgitadorSolucion"), Microsoft.Office.Interop.Excel.Worksheet)
            Do While Not RstResumenTenorsolucion.EOF
                hoja.Cells(recorrido, 1) = RstResumenTenorsolucion.Fields("Fecha").Value
                hoja.Cells(recorrido, 2) = RstResumenTenorsolucion.Fields("Turno").Value
                hoja.Cells(recorrido, 3) = RstResumenTenorsolucion.Fields("AuFinal_ppm").Value
                recorrido = recorrido + 1
                RstResumenTenorsolucion.MoveNext()
            Loop



            'espesador5 solido
            RstResumen = conn.Execute(" SELECT Fecha, Turno, ToneladasTurno, PromedioDensidad, PromedioGravedad FROM  dbo.Pb_ConcentradoEsp5 where     (Fecha >= '" & CDate(DtFechaInicio.Text) & "') AND (Fecha <= '" & CDate(DtFechaFinal.Text) & "')  ORDER BY Fecha ")
            RstResumenTenor = conn.Execute(" SELECT     Fecha, Turno, AuFinal_ppm FROM         dbo.PB_ColasESp5SolidoTenor where     (Fecha >= '" & CDate(DtFechaInicio.Text) & "') AND (Fecha <= '" & CDate(DtFechaFinal.Text) & "')  ORDER BY Fecha ")
            RstResumenTenorsolucion = conn.Execute(" SELECT     Fecha, Turno, AuFinal_ppm FROM         dbo.PB_ColasEsp5Solucion where     (Fecha >= '" & CDate(DtFechaInicio.Text) & "') AND (Fecha <= '" & CDate(DtFechaFinal.Text) & "')  ORDER BY Fecha ")


            recorrido = 2
            'concentrado de flotacion
            hoja = CType(.Sheets("Cesp5"), Microsoft.Office.Interop.Excel.Worksheet)
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
            hoja = CType(.Sheets("TenorSolidoCesp5"), Microsoft.Office.Interop.Excel.Worksheet)
            Do While Not RstResumenTenor.EOF
                hoja.Cells(recorrido, 1) = RstResumenTenor.Fields("Fecha").Value
                hoja.Cells(recorrido, 2) = RstResumenTenor.Fields("Turno").Value
                hoja.Cells(recorrido, 3) = RstResumenTenor.Fields("AuFinal_ppm").Value
                recorrido = recorrido + 1
                RstResumenTenor.MoveNext()
            Loop


            recorrido = 2
            hoja = CType(.Sheets("TenorSolucionEsp5"), Microsoft.Office.Interop.Excel.Worksheet)
            'hoja.Cells(1, 3) = RstResumen.Fields("Ubicacion").Value
            Do While Not RstResumenTenorsolucion.EOF
                hoja.Cells(recorrido, 1) = RstResumenTenorsolucion.Fields("Fecha").Value
                hoja.Cells(recorrido, 2) = RstResumenTenorsolucion.Fields("Turno").Value
                hoja.Cells(recorrido, 3) = RstResumenTenorsolucion.Fields("AuFinal_ppm").Value
                recorrido = recorrido + 1
                RstResumenTenorsolucion.MoveNext()
            Loop


            ' descarga agitador 3

            'RstResumen = conn.Execute(" SELECT Fecha, Turno, ToneladasTurno, PromedioDensidad, PromedioGravedad FROM  dbo.Pb_ConcentradoEsp5 where     (Fecha >= '" & CDate(DtFechaInicio.Text) & "') AND (Fecha <= '" & CDate(DtFechaFinal.Text) & "')  ORDER BY Fecha ")
            RstResumenTenor = conn.Execute(" SELECT     Fecha, Turno, AuFinal_ppm FROM         dbo.PB_DescargaAgitadorSolido where     (Fecha >= '" & CDate(DtFechaInicio.Text) & "') AND (Fecha <= '" & CDate(DtFechaFinal.Text) & "')  ORDER BY Fecha ")
            RstResumenTenorsolucion = conn.Execute(" SELECT     Fecha, Turno, AuFinal_ppm FROM         dbo.PB_DescargaAgitadorSolucion where     (Fecha >= '" & CDate(DtFechaInicio.Text) & "') AND (Fecha <= '" & CDate(DtFechaFinal.Text) & "')  ORDER BY Fecha ")



            recorrido = 2
            hoja = CType(.Sheets("DescargaAgitadorSolido"), Microsoft.Office.Interop.Excel.Worksheet)
            Do While Not RstResumenTenor.EOF
                hoja.Cells(recorrido, 1) = RstResumenTenor.Fields("Fecha").Value
                hoja.Cells(recorrido, 2) = RstResumenTenor.Fields("Turno").Value
                hoja.Cells(recorrido, 3) = RstResumenTenor.Fields("AuFinal_ppm").Value
                recorrido = recorrido + 1
                RstResumenTenor.MoveNext()
            Loop


            recorrido = 2
            hoja = CType(.Sheets("DescargaAgitadorSolucion"), Microsoft.Office.Interop.Excel.Worksheet)
            'hoja.Cells(1, 3) = RstResumen.Fields("Ubicacion").Value
            Do While Not RstResumenTenorsolucion.EOF
                hoja.Cells(recorrido, 1) = RstResumenTenorsolucion.Fields("Fecha").Value
                hoja.Cells(recorrido, 2) = RstResumenTenorsolucion.Fields("Turno").Value
                hoja.Cells(recorrido, 3) = RstResumenTenorsolucion.Fields("AuFinal_ppm").Value
                recorrido = recorrido + 1
                RstResumenTenorsolucion.MoveNext()
            Loop


            RstResumen = conn.Execute(" SELECT Fecha, TotalOnzas , OrigenBarra FROM  dbo.Pb_FundicionTotal where     (Fecha >= '" & CDate(DtFechaInicio.Text) & "') AND (Fecha <= '" & CDate(DtFechaFinal.Text) & "')  ORDER BY Fecha ")
            'FUNDICION
            recorrido = 2
            hoja = CType(.Sheets("Fundicion"), Microsoft.Office.Interop.Excel.Worksheet)
            Do While Not RstResumen.EOF
                hoja.Cells(recorrido, 1) = RstResumen.Fields("Fecha").Value
                hoja.Cells(recorrido, 2) = RstResumen.Fields("origenbarra").Value
                hoja.Cells(recorrido, 3) = RstResumen.Fields("totalonzas").Value
                recorrido = recorrido + 1
                RstResumen.MoveNext()
            Loop


            ' descarga agitador 4

            '****RstResumen = conn.Execute(" SELECT Fecha, Turno, ToneladasTurno, PromedioDensidad, PromedioGravedad FROM  dbo.Pb_ConcentradoEsp5 where     (Fecha >= '" & CDate(DtFechaInicio.Text) & "') AND (Fecha <= '" & CDate(DtFechaFinal.Text) & "')  ORDER BY Fecha ")
            '  RstResumenTenor = conn.Execute(" SELECT     Fecha, Turno, AuFinal_ppm FROM         dbo.PB_DescargaAG4Solido where     (Fecha >= '" & CDate(DtFechaInicio.Text) & "') AND (Fecha <= '" & CDate(DtFechaFinal.Text) & "')  ORDER BY Fecha ")
            ' RstResumenTenorsolucion = conn.Execute(" SELECT     Fecha, Turno, AuFinal_ppm FROM         dbo.PB_DescargaAG4Solucion where     (Fecha >= '" & CDate(DtFechaInicio.Text) & "') AND (Fecha <= '" & CDate(DtFechaFinal.Text) & "')  ORDER BY Fecha ")

            'recorrido = 2
            'hoja = CType(.Sheets("TenorSolidoAg3"), Microsoft.Office.Interop.Excel.Worksheet)
            'Do While Not RstResumenTenor.EOF
            'hoja.Cells(recorrido, 1) = RstResumenTenor.Fields("Fecha").Value
            'hoja.Cells(recorrido, 2) = RstResumenTenor.Fields("Turno").Value
            'hoja.Cells(recorrido, 3) = RstResumenTenor.Fields("AuFinal_ppm").Value
            ' recorrido = recorrido + 1
            ' RstResumenTenor.MoveNext()
            ' Loop
            ' recorrido = 2
            'hoja = CType(.Sheets("TenorSolucionAg3"), Microsoft.Office.Interop.Excel.Worksheet)
            'hoja.Cells(1, 3) = RstResumen.Fields("Ubicacion").Value
            ' Do While Not RstResumenTenorsolucion.EOF
            'hoja.Cells(recorrido, 1) = RstResumenTenorsolucion.Fields("Fecha").Value
            'hoja.Cells(recorrido, 2) = RstResumenTenorsolucion.Fields("Turno").Value
            ' hoja.Cells(recorrido, 3) = RstResumenTenorsolucion.Fields("AuFinal_ppm").Value
            'recorrido = recorrido + 1
            'RstResumenTenorsolucion.MoveNext()
            'Loop
            'merrilcrowe
            '* RstResumenTenor = conn.Execute(" SELECT     Fecha, Turno, AuFinal_ppm FROM         dbo.PB_DescargaAG3Solido where     (Fecha >= '" & CDate(DtFechaInicio.Text) & "') AND (Fecha <= '" & CDate(DtFechaFinal.Text) & "')  ORDER BY Fecha ")
            RstResumenTenorsolucion = conn.Execute("SELECT Fecha , Turno , Volumen , TenorCabeza , TenorCola , OnzasCabeza , OnzasCola  FROM         Pb_MerrilCroweBalance where     (Fecha >= '" & CDate(DtFechaInicio.Text) & "') AND (Fecha <= '" & CDate(DtFechaFinal.Text) & "')  ORDER BY Fecha ")
            recorrido = 2
            hoja = CType(.Sheets("MerrilCrowe"), Microsoft.Office.Interop.Excel.Worksheet)
            Do While Not RstResumenTenorsolucion.EOF
                hoja.Cells(recorrido, 1) = RstResumenTenorsolucion.Fields("Fecha").Value
                hoja.Cells(recorrido, 2) = RstResumenTenorsolucion.Fields("Turno").Value
                hoja.Cells(recorrido, 3) = RstResumenTenorsolucion.Fields("Volumen").Value
                hoja.Cells(recorrido, 4) = RstResumenTenorsolucion.Fields("TenorCabeza").Value
                hoja.Cells(recorrido, 5) = RstResumenTenorsolucion.Fields("TenorCola").Value
                hoja.Cells(recorrido, 6) = RstResumenTenorsolucion.Fields("OnzasCabeza").Value
                hoja.Cells(recorrido, 7) = RstResumenTenorsolucion.Fields("OnzasCola").Value
                recorrido = recorrido + 1
                RstResumenTenorsolucion.MoveNext()
            Loop
            'banda 12 
            RstResumenTenorsolucion = conn.Execute("SELECT  Fecha, turno , PromedioTenorTurno , ToneladaSeca , ToneladaHumeda , PromedioHumedad   FROM   Pb_TenorPromedioB12 where     (Fecha >= '" & CDate(DtFechaInicio.Text) & "') AND (Fecha <= '" & CDate(DtFechaFinal.Text) & "')  ORDER BY Fecha ")
            recorrido = 2
            hoja = CType(.Sheets("TenorB12"), Microsoft.Office.Interop.Excel.Worksheet)
            Do While Not RstResumenTenorsolucion.EOF
                hoja.Cells(recorrido, 1) = RstResumenTenorsolucion.Fields("Fecha").Value
                hoja.Cells(recorrido, 2) = RstResumenTenorsolucion.Fields("Turno").Value
                hoja.Cells(recorrido, 3) = RstResumenTenorsolucion.Fields("PromedioTenorTurno").Value
                hoja.Cells(recorrido, 5) = RstResumenTenorsolucion.Fields("ToneladaSeca").Value
                hoja.Cells(recorrido, 6) = RstResumenTenorsolucion.Fields("ToneladaHumeda").Value
                hoja.Cells(recorrido, 7) = RstResumenTenorsolucion.Fields("PromedioHumedad").Value
                recorrido = recorrido + 1
                RstResumenTenorsolucion.MoveNext()
            Loop

            'Colas Bulk 
            RstResumenTenorsolucion = conn.Execute("SELECT  Fecha, turno , AuFinal_ppm  FROM   PB_ColasBulk where     (Fecha >= '" & CDate(DtFechaInicio.Text) & "') AND (Fecha <= '" & CDate(DtFechaFinal.Text) & "')  ORDER BY Fecha ")
            recorrido = 2
            hoja = CType(.Sheets("TenorColasBulk"), Microsoft.Office.Interop.Excel.Worksheet)
            Do While Not RstResumenTenorsolucion.EOF
                hoja.Cells(recorrido, 1) = RstResumenTenorsolucion.Fields("Fecha").Value
                hoja.Cells(recorrido, 2) = RstResumenTenorsolucion.Fields("Turno").Value
                hoja.Cells(recorrido, 3) = RstResumenTenorsolucion.Fields("AuFinal_ppm").Value
                recorrido = recorrido + 1
                RstResumenTenorsolucion.MoveNext()
            Loop


            RstResumenTenor = conn.Execute(" SELECT     Fecha, Turno, AuFinal_ppm FROM         dbo.Pb_RebalseCiclon_Tenor where     (Fecha >= '" & CDate(DtFechaInicio.Text) & "') AND (Fecha <= '" & CDate(DtFechaFinal.Text) & "')  ORDER BY Fecha ")
            '   RstResumenTenorsolucion = conn.Execute(" SELECT     Fecha, Turno, AuFinal_ppm FROM         dbo.PB_DescargaAgitadorSolucion where     (Fecha >= '" & CDate(DtFechaInicio.Text) & "') AND (Fecha <= '" & CDate(DtFechaFinal.Text) & "')  ORDER BY Fecha ")



            recorrido = 2
            hoja = CType(.Sheets("RebalseCiclon"), Microsoft.Office.Interop.Excel.Worksheet)
            Do While Not RstResumenTenor.EOF
                hoja.Cells(recorrido, 1) = RstResumenTenor.Fields("Fecha").Value
                hoja.Cells(recorrido, 2) = RstResumenTenor.Fields("Turno").Value
                hoja.Cells(recorrido, 3) = RstResumenTenor.Fields("AuFinal_ppm").Value
                recorrido = recorrido + 1
                RstResumenTenor.MoveNext()
            Loop

            RstResumen = conn.Execute(" SELECT Fecha, DetencionMtto, DetencionOperacion FROM  dbo.PB_Operation where     (Fecha >= '" & CDate(DtFechaInicio.Text) & "') AND (Fecha <= '" & CDate(DtFechaFinal.Text) & "')  ORDER BY Fecha ")
            recorrido = 2
            hoja = CType(.Sheets("Operacion"), Microsoft.Office.Interop.Excel.Worksheet)
            Do While Not RstResumen.EOF
                hoja.Cells(recorrido, 1) = RstResumen.Fields("Fecha").Value
                hoja.Cells(recorrido, 2) = RstResumen.Fields("DetencionMtto").Value
                hoja.Cells(recorrido, 3) = RstResumen.Fields("DetencionOperacion").Value
                recorrido = recorrido + 1
                RstResumen.MoveNext()
            Loop



            recorrido = 5
            hoja = CType(.Sheets("Report"), Microsoft.Office.Interop.Excel.Worksheet)
            Dim fecha1, fecha2 As Date
            fecha1 = DtFechaInicio.Value
            fecha2 = DtFechaFinal.Value
            Do While fecha1 <= fecha2
                hoja.Cells(recorrido, 2) = fecha1
                recorrido = recorrido + 1
                fecha1 = fecha1.AddDays(1)
                'fecha2 = fecha1.AddDays(1)
            Loop
            'LblExport.Visible = False

            ' objExcel.Sheets("TenorColasBulk").visible = False
            'objExcel.Sheets("Hoja").visible = True
            objExcel.Visible = True
        End With

        conn.Close()


    End Sub
    Private Sub CmdSaveMC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdSaveMC.Click
        Dim DsPriv As New DataSet
        Dim EPermisos As New SqlClient.SqlDataAdapter("SELECT Usuario, IdEvento FROM RfUserEvent" & _
" WHERE RfUserEvent.Usuario='" & LblUsuario.Text & "'  and (RfUserEvent.IdEvento  = 'ModificarMerrilCrowe'  ) ", Cn)
        EPermisos.Fill(DsPriv, "RfUserEvent")
        Dim myDataViewpermisos As DataView = New DataView(DsPriv.Tables("RfUserEvent"))
        If myDataViewpermisos.Count = 0 Then
            MsgBox("El usuario no tiene privilegios para Modificar en este Formulario. Contacte a su administrador.")
            Exit Sub
        End If
        If ListMCInicio.Text = "" Or ListMCFinal.Text = "" Or TxtInicioMC.Text = "" Or TxTFinalMC.Text = "" Then
            MsgBox("Todos los campos son obligatorios, por favor Diligencie correctamente el formulario")
        Else
            Try
                Dim sqlConnectiondb As New System.Data.SqlClient.SqlConnection("Server=SEGSVRSQL01;uid=sa;pwd=*Bd6r4nC0l0mb1a*;database=PlantaBeneficio")
                Dim cmd As New System.Data.SqlClient.SqlCommand
                cmd.CommandType = System.Data.CommandType.Text
                If editaMerril = True Then
                    'CONSULTA CUANDO EDITAR ES VERDADERO
                    cmd.CommandText = "UPDATE  PB_MerrilCrowe  SET LecturaInicial = @LecturaInicial,  HoraFinal= @HoraFinal ,   LecturaFinal = @LecturaFinal   WHERE HoraInicial=@HoraInicial and Fecha=@Fecha  "
                Else
                    ' consulta sql si editar es falso 
                    cmd.CommandText = "INSERT INTO PB_MerrilCrowe (HoraInicial,HoraFinal,Fecha, LecturaInicial,  LecturaFinal)VALUES(@HoraInicial,@HoraFinal,@Fecha, @LecturaInicial,  @LecturaFinal)"
                End If
                cmd.Parameters.AddWithValue("@HoraInicial", Convert.ToString(ListMCInicio.Text))
                cmd.Parameters.AddWithValue("@HoraFinal", Convert.ToString(ListMCFinal.Text))
                cmd.Parameters.AddWithValue("@Fecha", CDate(DateTimePickerFechaReporte.Text))
                cmd.Parameters.AddWithValue("@LecturaInicial", CDbl(TxtInicioMC.Text))
                cmd.Parameters.AddWithValue("@LecturaFinal", CDbl(TxTFinalMC.Text))
                cmd.Connection = sqlConnectiondb
                sqlConnectiondb.Open()
                cmd.ExecuteNonQuery()
                sqlConnectiondb.Close()
                MessageBox.Show("Los datos se  guardaron Correctamente.")
                Llenar_DataGridViewDgMerrilCrowe()
                TxtInicioMC.Text = TxTFinalMC.Text
                ListMCInicio.Text = ListMCFinal.Text

                TxTFinalMC.Focus()
                If editaMerril = True Then

                Else
                    If ListMCFinal.SelectedIndex + 8 > 23 Then

                        ListMCFinal.SelectedIndex = 7
                    Else
                        ListMCFinal.SelectedIndex = ListMCFinal.SelectedIndex + 8
                    End If
                End If
                TxTFinalMC.Clear()
                editaMerril = False
                DgMerrilCrowe.FirstDisplayedScrollingRowIndex = DgMerrilCrowe.RowCount - 1
            Catch ex As Exception
                ' Handle the exception.
                MessageBox.Show(ex.Message, Me.Text, _
      MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        End If
    End Sub

    Private Sub CmdOperacionEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdOperacionEdit.Click
        editaroperacion = True
    End Sub

    Private Sub CmdOperacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdOperacion.Click
        Dim DsPriv As New DataSet
        Dim EPermisos As New SqlClient.SqlDataAdapter("SELECT Usuario, IdEvento FROM RfUserEvent" & _
" WHERE RfUserEvent.Usuario='" & LblUsuario.Text & "'  and (RfUserEvent.IdEvento  = 'ModificarMineralPlant'  ) ", Cn)
        EPermisos.Fill(DsPriv, "RfUserEvent")
        Dim myDataViewpermisos As DataView = New DataView(DsPriv.Tables("RfUserEvent"))
        If myDataViewpermisos.Count = 0 Then
            MsgBox("El usuario no tiene privilegios para Modificar en este Formulario. Contacte a su administrador.")
            Exit Sub
        End If
        Try
            Dim fechaestimada As Date
            fechaestimada = DateTimePickerFechaReporte.Value
            Dim sqlConnectiondb As New System.Data.SqlClient.SqlConnection("Server=SEGSVRSQL01;uid=sa;pwd=*Bd6r4nC0l0mb1a*;database=PlantaBeneficio")
            Dim cmd As New System.Data.SqlClient.SqlCommand
            cmd.CommandType = System.Data.CommandType.Text
            If editaroperacion = True Then
                cmd.CommandText = "UPDATE PB_Operation SET  [OrigenconcentradoFlotacion] = @OrigenconcentradoFlotacion ,  [LecturaFlujoAgua] = @LecturaFlujoAgua , [TonHora] = @TonHora , [OperacionHorasDia] =@OperacionHorasDia , [DetencionMtto] = @DetencionMtto, [DetencionOperacion]=@DetencionOperacion,  [TonHumedasZC]=@TonHumedasZC, [TonhumedasPM]=@TonhumedasPM, [StockZCGruesos]=@StockZCGruesos, [StockZCFinos]=@StockZCFinos, [StockPMFinos]=@StockPMFinos, [TonMolidasZandor]=@TonMolidasZandor , [TonMolidasMineras]=@TonMolidasMineras ,[MotivoParada]=@MotivoParada   WHERE [Fecha] =   '" & Format(fechaestimada, "yyyy/MM/dd") & "'   "
            Else
                cmd.CommandText = "INSERT INTO PB_Operation (OrigenconcentradoFlotacion ,Fecha,LecturaFlujoAgua,TonHora, OperacionHorasDia,  DetencionMtto, DetencionOperacion, TonHumedasZC, TonhumedasPM, StockZCGruesos, StockZCFinos, StockPMFinos, TonMolidasZandor ,TonMolidasMineras, MotivoParada)VALUES( @OrigenconcentradoFlotacion, @Fecha,@LecturaFlujoAgua,@TonHora, @OperacionHorasDia,  @DetencionMtto, @DetencionOperacion, @TonHumedasZC, @TonhumedasPM, @StockZCGruesos, @StockZCFinos, @StockPMFinos , @TonMolidasZandor , @TonMolidasMineras, @MotivoParada)"
            End If
            cmd.Parameters.AddWithValue("@OrigenconcentradoFlotacion", Convert.ToString(CmbConcentradoFlotacion.Text))
            cmd.Parameters.AddWithValue("@Fecha", Convert.ToDateTime(DateTimePickerFechaReporte.Value))
            cmd.Parameters.AddWithValue("@LecturaFlujoAgua", Convert.ToDecimal(Txtconsumo.Text))
            cmd.Parameters.AddWithValue("@TonHora", Convert.ToString(TxtTonHora.Text))
            cmd.Parameters.AddWithValue("@OperacionHorasDia", Convert.ToString(TxtHoras.Text))
            cmd.Parameters.AddWithValue("@DetencionMtto", Convert.ToString(TxtMtto.Text))
            cmd.Parameters.AddWithValue("@DetencionOperacion", Convert.ToString(TxtOperacion.Text))
            'inventario mineral
            cmd.Parameters.AddWithValue("@TonHumedasZC", Convert.ToString(TxtTonHumedasZC.Text))
            cmd.Parameters.AddWithValue("@TonhumedasPM", Convert.ToString(TxtTonhumedasPM.Text))
            cmd.Parameters.AddWithValue("@StockZCGruesos", Convert.ToString(TxtStockZCGruesos.Text))
            cmd.Parameters.AddWithValue("@StockZCFinos", Convert.ToString(TxtStockZCFinos.Text))
            cmd.Parameters.AddWithValue("@StockPMFinos", Convert.ToString(TxtStockPMFinos.Text))
            cmd.Parameters.AddWithValue("@TonMolidasZandor", Convert.ToString(TxtTonZandor.Text))
            cmd.Parameters.AddWithValue("@TonMolidasMineras", Convert.ToString(TxtTonMinera.Text))
            ' fundicion
            cmd.Parameters.AddWithValue("@MotivoParada", Convert.ToString(CmbParada.Text))
            cmd.Connection = sqlConnectiondb
            sqlConnectiondb.Open()
            cmd.ExecuteNonQuery()
            sqlConnectiondb.Close()
            Call FrmMineralPlant_Load(Nothing, Nothing)
            editaroperacion = False
            MessageBox.Show("Los datos se han guardado Correctamente.")
        Catch ex As Exception
            ' Handle the exception.
            MessageBox.Show(ex.Message, Me.Text, _
  MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub



    Private Sub ChkResumerril_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkResumerril.CheckedChanged

    End Sub

    Private Sub DgLecturaBandas_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgLecturaBandas.CellContentClick

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim ToAddress As String
        ToAddress = "juan.palacio@grancolombiagold.com.co"
        Dim FromAddress As String
        FromAddress = "planta.beneficio@grancolombiagold.com.co"
        Dim MessageSubject As String
        MessageSubject = "Reporte Diario"
        Dim MessageBody As String
        MessageBody = "Ensayos diarios"
        Dim MessageHead As String = "<html><head>"
        MessageHead = MessageHead & "<style>"
        MessageHead = MessageHead & "body {background-color:#F7F7F7; color:#000; font-family:arial,verdana,sans-serif; font-size:12px;}"
        MessageHead = MessageHead & "</style></head><body>"

        Dim MessageFoot As String = "</body></html>"

        MessageBody = MessageHead & MessageBody & MessageFoot

        Dim ReturnMessage As String = ""
        Dim mm As New MailMessage(FromAddress, ToAddress)
        Dim smtp As New SmtpClient("smtp.gmail.com")
        ' Dim SMTP As New SmtpClient("outmail.profilter.co.uk")
        smtp.EnableSsl = False
        smtp.Credentials = New System.Net.NetworkCredential("juanfernandopalacioa", "colombia12*")
        smtp.Port = 25
        mm.Subject = MessageSubject
        mm.Body = MessageBody
        mm.IsBodyHtml = True

        Try
            smtp.Host = "smtp.gmail.com"  'ADD HOST IP
            smtp.Send(mm)

            ReturnMessage = "Email has been dispatched"

        Catch ex As Exception
            ReturnMessage = "We're sorry, there has been an error: " & ex.Message
        End Try

        'SendEmail = ReturnMessage




    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Try
            Dim SmtpServer As New SmtpClient()
            Dim mail As New MailMessage()
            SmtpServer.Credentials = New  _
  Net.NetworkCredential("planta.beneficio@grancolombiagold.com.co", "colombia12*")
            SmtpServer.Port = 587
            SmtpServer.Host = "smtp-mail.outlook.com"
            mail = New MailMessage()
            mail.From = New MailAddress("planta.beneficio@grancolombiagold.com.co")
            mail.To.Add("juan.palacio@grancolombiagold.com.co")
            mail.Subject = "Test Mail"
            mail.Body = "This is for testing SMTP mail from GMAIL"
            SmtpServer.Send(mail)
            MsgBox("mail send")
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'create the mail message
        Dim mail As New MailMessage()

        'set the addresses
        mail.From = New MailAddress("me@mycompany.com")
        mail.To.Add("juan.palacio@grancolombiagold.com.co")

        'set the content
        mail.Subject = "This is an email"
        mail.Body = "this is a sample body with html in it. <b>This is bold</b> <font color=#336699>This is blue</font>"
        mail.IsBodyHtml = True

        'send the message
        Dim smtp As New SmtpClient("127.0.0.1")
        smtp.Send(mail)
    End Sub

    Private Sub TabPage5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabPage5.Click

    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim DsPriv As New DataSet
        Dim EPermisos As New SqlClient.SqlDataAdapter("SELECT Usuario, IdEvento FROM RfUserEvent" & _
" WHERE RfUserEvent.Usuario='" & LblUsuario.Text & "'  and (RfUserEvent.IdEvento  = 'ModificarHorometro'  ) ", Cn)
        EPermisos.Fill(DsPriv, "RfUserEvent")
        Dim myDataViewpermisos As DataView = New DataView(DsPriv.Tables("RfUserEvent"))
        If myDataViewpermisos.Count = 0 Then
            MsgBox("El usuario no tiene privilegios para Modificar en este Formulario. Contacte a su administrador.")
            Exit Sub
        End If
        If TxtLinicialHorometro.Text = "" Or TxtLfinalHorometro.Text = "" Then
            MsgBox("Todos los campos son obligatorios, por favor Diligencie correctamente el formulario")
        Else
            Try
                Dim sqlConnectiondb As New System.Data.SqlClient.SqlConnection("Server=SEGSVRSQL01;uid=sa;pwd=*Bd6r4nC0l0mb1a*;database=PlantaBeneficio")
                Dim cmd As New System.Data.SqlClient.SqlCommand
                cmd.CommandType = System.Data.CommandType.Text
                If editahorometro = True Then
                    'CONSULTA CUANDO EDITAR ES VERDADERO
                    cmd.CommandText = "UPDATE  Pb_HorasMolienda  SET HoromInicial = @HoromInicial,  HoromFinal= @HoromFinal   WHERE Turno=@Turno and Fecha=@Fecha  "
                Else
                    ' consulta sql si editar es falso 
                    cmd.CommandText = "INSERT INTO Pb_HorasMolienda (HoromInicial,HoromFinal,Fecha, Turno)VALUES(@HoromInicial,@HoromFinal,@Fecha, @Turno)"
                End If
                cmd.Parameters.AddWithValue("@HoromInicial", Convert.ToDecimal(TxtLinicialHorometro.Text))
                cmd.Parameters.AddWithValue("@HoromFinal", Convert.ToDecimal(TxtLfinalHorometro.Text))
                cmd.Parameters.AddWithValue("@Fecha", CDate(DateTimePickerFechaReporte.Text))
                cmd.Parameters.AddWithValue("@Turno", Convert.ToString(Cmbturno.Text))
                cmd.Connection = sqlConnectiondb
                sqlConnectiondb.Open()
                cmd.ExecuteNonQuery()
                sqlConnectiondb.Close()
                MessageBox.Show("Los datos se  guardaron Correctamente.")
                Llenar_DataGridViewDgHorometro()
                Llenar_TotalHorometroMolino()
                TxtLinicialHorometro.Clear()
                TxtLfinalHorometro.Clear()
                TxtLinicialHorometro.Focus()
                editahorometro = False
            Catch ex As Exception
                ' Handle the exception.
                MessageBox.Show(ex.Message, Me.Text, _
      MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        End If

    End Sub

    Private Sub Button2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim DsPriv As New DataSet
        Dim EPermisos As New SqlClient.SqlDataAdapter("SELECT Usuario, IdEvento FROM RfUserEvent" & _
" WHERE RfUserEvent.Usuario='" & LblUsuario.Text & "'  and (RfUserEvent.IdEvento  = 'ModificarHorometro'  ) ", Cn)
        EPermisos.Fill(DsPriv, "RfUserEvent")
        Dim myDataViewpermisos As DataView = New DataView(DsPriv.Tables("RfUserEvent"))
        If myDataViewpermisos.Count = 0 Then
            MsgBox("El usuario no tiene privilegios para Modificar en este Formulario. Contacte a su administrador.")
            Exit Sub
        End If
        If TxtHKNelsonI.Text = "" Or TxtHKNelsonF.Text = "" Then
            MsgBox("Todos los campos son obligatorios, por favor Diligencie correctamente el formulario")
        Else
            Try
                Dim sqlConnectiondb As New System.Data.SqlClient.SqlConnection("Server=SEGSVRSQL01;uid=sa;pwd=*Bd6r4nC0l0mb1a*;database=PlantaBeneficio")
                Dim cmd As New System.Data.SqlClient.SqlCommand
                cmd.CommandType = System.Data.CommandType.Text
                If editahorometroknelson = True Then
                    'CONSULTA CUANDO EDITAR ES VERDADERO
                    cmd.CommandText = "UPDATE  Pb_HorasKNelson  SET HoromInicial = @HoromInicial,  HoromFinal= @HoromFinal   WHERE Turno=@Turno and Fecha=@Fecha  "
                Else
                    ' consulta sql si editar es falso 
                    cmd.CommandText = "INSERT INTO Pb_HorasKNelson (HoromInicial,HoromFinal,Fecha, Turno)VALUES(@HoromInicial,@HoromFinal,@Fecha, @Turno)"
                End If
                cmd.Parameters.AddWithValue("@HoromInicial", Convert.ToDecimal(TxtHKNelsonI.Text))
                cmd.Parameters.AddWithValue("@HoromFinal", Convert.ToDecimal(TxtHKNelsonF.Text))
                cmd.Parameters.AddWithValue("@Fecha", CDate(DateTimePickerFechaReporte.Text))
                cmd.Parameters.AddWithValue("@Turno", Convert.ToString(CmbKNelsonTurn.Text))
                cmd.Connection = sqlConnectiondb
                sqlConnectiondb.Open()
                cmd.ExecuteNonQuery()
                sqlConnectiondb.Close()
                MessageBox.Show("Los datos se  guardaron Correctamente.")
                Llenar_DgHorometroKnelson()
                Llenar_TotalHorometroKnelson()
                TxtHKNelsonI.Clear()
                TxtHKNelsonF.Clear()

                TxtHKNelsonI.Focus()
                editahorometroknelson = False

            Catch ex As Exception
                ' Handle the exception.
                MessageBox.Show(ex.Message, Me.Text, _
      MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        End If
    End Sub



    Private Sub Button3_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim DsPriv As New DataSet
        Dim EPermisos As New SqlClient.SqlDataAdapter("SELECT Usuario, IdEvento FROM RfUserEvent" & _
" WHERE RfUserEvent.Usuario='" & LblUsuario.Text & "'  and (RfUserEvent.IdEvento  = 'ModificarHorometro'  ) ", Cn)
        EPermisos.Fill(DsPriv, "RfUserEvent")
        Dim myDataViewpermisos As DataView = New DataView(DsPriv.Tables("RfUserEvent"))
        If myDataViewpermisos.Count = 0 Then
            MsgBox("El usuario no tiene privilegios para Modificar en este Formulario. Contacte a su administrador.")
            Exit Sub
        End If
        If TxtInicioE5.Text = "" Or TxtFinalE5.Text = "" Or TxtHorasOperacione5.Text = "" Or TxtHorasOperacione5.Text = "0" Then
            MsgBox("Todos los campos son obligatorios, por favor Diligencie correctamente el formulario")
        Else
            Try
                Dim sqlConnectiondb As New System.Data.SqlClient.SqlConnection("Server=SEGSVRSQL01;uid=sa;pwd=*Bd6r4nC0l0mb1a*;database=PlantaBeneficio")
                Dim cmd As New System.Data.SqlClient.SqlCommand
                cmd.CommandType = System.Data.CommandType.Text
                If editarflujoe5 = True Then
                    'CONSULTA CUANDO EDITAR ES VERDADERO
                    cmd.CommandText = "UPDATE  Pb_FlowsE5  SET LecturaInicial = @LecturaInicial,  LecturaFinal= @lecturafinal , densidad = @densidad , HorasOperacion=@HorasOperacion , HorasVertimiento=@HorasVertimiento  WHERE Turno=@Turno and Fecha=@Fecha  "
                Else
                    ' consulta sql si editar es falso 
                    cmd.CommandText = "INSERT INTO Pb_flowse5 (LecturaInicial,LecturaFinal, densidad , HorasOperacion ,Fecha, Turno , HorasVertimiento)VALUES(@LecturaInicial, @LecturaFinal , @Densidad , @HorasOperacion ,@Fecha, @Turno , @HorasVertimiento )"
                End If
                cmd.Parameters.AddWithValue("@LecturaInicial", Convert.ToDecimal(TxtInicioE5.Text))
                cmd.Parameters.AddWithValue("@LecturaFinal", Convert.ToDecimal(TxtFinalE5.Text))
                cmd.Parameters.AddWithValue("@densidad", Convert.ToDecimal(TxtDensidadE5.Text))
                cmd.Parameters.AddWithValue("@HorasOperacion", Convert.ToDecimal(TxtHorasOperacione5.Text))
                cmd.Parameters.AddWithValue("@HorasVertimiento", Convert.ToDecimal(TxtHVertCep5.Text))
                cmd.Parameters.AddWithValue("@Fecha", CDate(DateTimePickerFechaReporte.Text))
                cmd.Parameters.AddWithValue("@Turno", Convert.ToString(CmbTurnoE5.Text))
                cmd.Connection = sqlConnectiondb
                sqlConnectiondb.Open()
                cmd.ExecuteNonQuery()
                sqlConnectiondb.Close()
                MessageBox.Show("Los datos se  guardaron Correctamente.")
                Llenar_DataGridViewDgFlujometroE5()
                TxtInicioE5.Clear()
                TxtFinalE5.Clear()
                TxtHVertCep5.Clear()
                TxtInicioE5.Focus()
                editarflujoe5 = False

            Catch ex As Exception
                ' Handle the exception.
                MessageBox.Show(ex.Message, Me.Text, _
      MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        End If
    End Sub

    Private Sub DateTimePicker1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DtInicioE5.ValueChanged

    End Sub

    Private Sub CmdExportarFlowsE5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdExportarFlowsE5.Click
        Dim fechainicio As Date
        Dim fechafin As Date
        fechainicio = CDate(DtInicioE5.Value)
        fechafin = CDate(DtFinalE5.Value)
        Dim dias As Double
        dias = (DtFinalE5.Value - DtInicioE5.Value).TotalDays
        If dias > 31 Then
            MsgBox("Por Favor Seleccione un rango de Fecha no superior a 30 dias.")
            Exit Sub

        End If
        exportarflujoE5()
    End Sub
    Private Sub exportarColasFlotacion()
        Dim conn As New ADODB.Connection()
        Dim RstResumen As New ADODB.Recordset()
        Dim RstResumenTenor As New ADODB.Recordset()

        Dim cnStr As String
        cnStr = "Provider=SQLNCLI10;Initial Catalog=PlantaBeneficio;Data Source=SEGSVRSQL01; User ID=sa;Password=*Bd6r4nC0l0mb1a*;"
        conn.Open(cnStr)
        Dim objExcel As Microsoft.Office.Interop.Excel.Application
        objExcel = New Microsoft.Office.Interop.Excel.Application
        Dim hoja As Microsoft.Office.Interop.Excel.Worksheet
        objExcel.Workbooks.Open("\\athenea\pampaverde\mineria\Data\DataBase\Templates\FlujometroColasBulk.xlsx")
        Dim recorrido As Integer
        recorrido = 2
        objExcel.Visible = False
        RstResumen = conn.Execute(" SELECT  Turno, FlujoM3, TonsTurno, HorasOperacion, Densidad, Fecha , ToneladasVertidas FROM  dbo.Pb_FlowsColasBulk where     (Fecha >= '" & CDate(DtInicioFl.Text) & "') AND (Fecha <= '" & CDate(DtFinalFl.Text) & "')  ORDER BY Fecha ")
        With objExcel
            'concentrado de flotacion
            hoja = CType(.Sheets("Data"), Microsoft.Office.Interop.Excel.Worksheet)
            'hoja.Cells(1, 3) = RstResumen.Fields("Ubicacion").Value
            Do While Not RstResumen.EOF
                hoja.Cells(recorrido, 1) = RstResumen.Fields("Fecha").Value
                hoja.Cells(recorrido, 2) = RstResumen.Fields("Turno").Value
                hoja.Cells(recorrido, 3) = RstResumen.Fields("Densidad").Value
                hoja.Cells(recorrido, 4) = RstResumen.Fields("HorasOperacion").Value
                hoja.Cells(recorrido, 5) = RstResumen.Fields("Tonsturno").Value
                hoja.Cells(recorrido, 7) = RstResumen.Fields("ToneladasVertidas").Value
                recorrido = recorrido + 1
                RstResumen.MoveNext()
            Loop

            recorrido = 2
            objExcel.Visible = False
            RstResumen = conn.Execute(" SELECT  fecha, turno, AuFinal_ppm FROM  dbo.PB_ColasBulk where     (Fecha >= '" & CDate(DtInicioFl.Text) & "') AND (Fecha <= '" & CDate(DtFinalFl.Text) & "')  ORDER BY Fecha ")

            'concentrado de flotacion
            hoja = CType(.Sheets("tenor"), Microsoft.Office.Interop.Excel.Worksheet)
            'hoja.Cells(1, 3) = RstResumen.Fields("Ubicacion").Value
            Do While Not RstResumen.EOF
                hoja.Cells(recorrido, 1) = RstResumen.Fields("Fecha").Value
                hoja.Cells(recorrido, 2) = RstResumen.Fields("Turno").Value
                hoja.Cells(recorrido, 3) = RstResumen.Fields("AuFinal_ppm").Value

                recorrido = recorrido + 1
                RstResumen.MoveNext()
            Loop


            recorrido = 3
            hoja = CType(.Sheets("Report"), Microsoft.Office.Interop.Excel.Worksheet)
            Dim fecha1, fecha2 As Date
            fecha1 = DtInicioFl.Value
            fecha2 = DtFinalFl.Value
            Do While fecha1 <= fecha2
                hoja.Cells(recorrido, 1) = fecha1
                recorrido = recorrido + 1
                fecha1 = fecha1.AddDays(1)
                'fecha2 = fecha1.AddDays(1)
            Loop

        End With
        objExcel.Visible = True
        conn.Close()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim DsPriv As New DataSet
        Dim EPermisos As New SqlClient.SqlDataAdapter("SELECT Usuario, IdEvento FROM RfUserEvent" & _
" WHERE RfUserEvent.Usuario='" & LblUsuario.Text & "'  and (RfUserEvent.IdEvento  = 'ModificarHorometro'  ) ", Cn)
        EPermisos.Fill(DsPriv, "RfUserEvent")
        Dim myDataViewpermisos As DataView = New DataView(DsPriv.Tables("RfUserEvent"))
        If myDataViewpermisos.Count = 0 Then
            MsgBox("El usuario no tiene privilegios para Modificar en este Formulario. Contacte a su administrador.")
            Exit Sub
        End If


        If TxtInicioFl.Text = "" Or TxtFinalFl.Text = "" Or TxtHorasFl.Text = "" Or TxtHorasFl.Text = "0" Or TxtDensidadFl.Text = "" Then
            MsgBox("Todos los campos son obligatorios, por favor Diligencie correctamente el formulario")
        Else
            Try
                Dim sqlConnectiondb As New System.Data.SqlClient.SqlConnection("Server=SEGSVRSQL01;uid=sa;pwd=*Bd6r4nC0l0mb1a*;database=PlantaBeneficio")
                Dim cmd As New System.Data.SqlClient.SqlCommand
                cmd.CommandType = System.Data.CommandType.Text
                If editaflujoflotacion = True Then
                    'CONSULTA CUANDO EDITAR ES VERDADERO
                    cmd.CommandText = "UPDATE  Pb_FlowsColasBulk  SET LecturaInicial = @LecturaInicial,  LecturaFinal= @lecturafinal , densidad = @densidad , HorasOperacion=@HorasOperacion , HorasVertimiento=@HorasVertimiento WHERE Turno=@Turno and Fecha=@Fecha  "
                Else
                    ' consulta sql si editar es falso 
                    cmd.CommandText = "INSERT INTO Pb_FlowsColasBulk (LecturaInicial,LecturaFinal, densidad , HorasOperacion ,Fecha, Turno , HorasVertimiento)VALUES(@LecturaInicial, @LecturaFinal , @Densidad , @HorasOperacion ,@Fecha, @Turno ,@HorasVertimiento)"
                End If
                cmd.Parameters.AddWithValue("@LecturaInicial", Convert.ToDecimal(TxtInicioFl.Text))
                cmd.Parameters.AddWithValue("@LecturaFinal", Convert.ToDecimal(TxtFinalFl.Text))
                cmd.Parameters.AddWithValue("@densidad", Convert.ToDecimal(TxtDensidadFl.Text))
                cmd.Parameters.AddWithValue("@HorasOperacion", Convert.ToDecimal(TxtHorasFl.Text))
                cmd.Parameters.AddWithValue("@HorasVertimiento", Convert.ToDecimal(TxtHVertimientoFl.Text))
                cmd.Parameters.AddWithValue("@Fecha", CDate(DateTimePickerFechaReporte.Text))
                cmd.Parameters.AddWithValue("@Turno", Convert.ToString(CmbTurnoFl.Text))
                cmd.Connection = sqlConnectiondb
                sqlConnectiondb.Open()
                cmd.ExecuteNonQuery()
                sqlConnectiondb.Close()
                MessageBox.Show("Los datos se  guardaron Correctamente.")
                Llenar_DataGridViewDgFlujometroFlotacion()
                TxtInicioFl.Text = TxtFinalFl.Text
                TxtFinalFl.Clear()
                TxtDensidadFl.Clear()
                TxtHVertimientoFl.Clear()
                TxtHorasFl.Clear()
                TxtInicioFl.Focus()
                editaflujoflotacion = False

            Catch ex As Exception
                ' Handle the exception.
                MessageBox.Show(ex.Message, Me.Text, _
      MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        End If
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
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
        exportarColasFlotacion()
    End Sub
    Private Sub exportarflujoE5()
        Dim conn As New ADODB.Connection()
        Dim RstResumen As New ADODB.Recordset()
        Dim RstResumenTenor As New ADODB.Recordset()

        Dim cnStr As String
        cnStr = "Provider=SQLNCLI10;Initial Catalog=PlantaBeneficio;Data Source=SEGSVRSQL01; User ID=sa;Password=*Bd6r4nC0l0mb1a*;"
        conn.Open(cnStr)
        Dim objExcel As Microsoft.Office.Interop.Excel.Application
        objExcel = New Microsoft.Office.Interop.Excel.Application
        Dim hoja As Microsoft.Office.Interop.Excel.Worksheet
        objExcel.Workbooks.Open("\\athenea\pampaverde\mineria\Data\DataBase\Templates\FlujometroE5.xlsx")
        Dim recorrido As Integer
        recorrido = 2
        objExcel.Visible = False
        RstResumen = conn.Execute(" SELECT  Turno, FlujoM3, TonsTurno, HorasOperacion, Densidad, Fecha , ToneladasVertidas FROM  dbo.Pb_FlowsE5 where     (Fecha >= '" & CDate(DtInicioE5.Text) & "') AND (Fecha <= '" & CDate(DtFinalE5.Text) & "')  ORDER BY Fecha ")
        With objExcel
            'concentrado de flotacion
            hoja = CType(.Sheets("Data"), Microsoft.Office.Interop.Excel.Worksheet)
            'hoja.Cells(1, 3) = RstResumen.Fields("Ubicacion").Value
            Do While Not RstResumen.EOF
                hoja.Cells(recorrido, 1) = RstResumen.Fields("Fecha").Value
                hoja.Cells(recorrido, 2) = RstResumen.Fields("Turno").Value
                hoja.Cells(recorrido, 3) = RstResumen.Fields("Densidad").Value
                hoja.Cells(recorrido, 4) = RstResumen.Fields("HorasOperacion").Value
                hoja.Cells(recorrido, 5) = RstResumen.Fields("Tonsturno").Value
                hoja.Cells(recorrido, 7) = RstResumen.Fields("ToneladasVertidas").Value
                recorrido = recorrido + 1
                RstResumen.MoveNext()
            Loop


            recorrido = 3
            hoja = CType(.Sheets("Report"), Microsoft.Office.Interop.Excel.Worksheet)
            Dim fecha1, fecha2 As Date
            fecha1 = DtInicioE5.Value
            fecha2 = DtFinalE5.Value
            Do While fecha1 <= fecha2
                hoja.Cells(recorrido, 1) = fecha1
                recorrido = recorrido + 1
                fecha1 = fecha1.AddDays(1)
                'fecha2 = fecha1.AddDays(1)
            Loop

        End With
        objExcel.Visible = True
        conn.Close()
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Dim fechainicio As Date
        Dim fechafin As Date
        fechainicio = CDate(DtInicioB12.Value)
        fechafin = CDate(DtFinalB12.Value)
        Dim dias As Double
        dias = (DtFinalB12.Value - DtInicioB12.Value).TotalDays
        If dias > 31 Then
            MsgBox("Por Favor Seleccione un rango de Fecha no superior a 30 dias.")
            Exit Sub

        End If
        exportarBanda12()
    End Sub

    Private Sub exportarBanda12()
        Dim conn As New ADODB.Connection()
        Dim RstResumen As New ADODB.Recordset()
        Dim RstResumenTenor As New ADODB.Recordset()

        Dim cnStr As String
        cnStr = "Provider=SQLNCLI10;Initial Catalog=PlantaBeneficio;Data Source=SEGSVRSQL01; User ID=sa;Password=*Bd6r4nC0l0mb1a*;"
        conn.Open(cnStr)
        Dim objExcel As Microsoft.Office.Interop.Excel.Application
        objExcel = New Microsoft.Office.Interop.Excel.Application
        Dim hoja As Microsoft.Office.Interop.Excel.Worksheet
        objExcel.Workbooks.Open("\\athenea\pampaverde\mineria\Data\DataBase\Templates\Banda12Resumen.xlsx")
        Dim recorrido As Integer
        recorrido = 2
        objExcel.Visible = False
        RstResumen = conn.Execute(" SELECT   Fecha, ToneladaSeca ,PromedioHumedad , PromedioTenorTurno, Turno   FROM  dbo.Pb_TenorPromedioB12 where     (Fecha >= '" & CDate(DtInicioB12.Text) & "') AND (Fecha <= '" & CDate(DtFinalB12.Text) & "')  ORDER BY Fecha ")
        With objExcel
            'concentrado de flotacion
            hoja = CType(.Sheets("Data"), Microsoft.Office.Interop.Excel.Worksheet)
            'hoja.Cells(1, 3) = RstResumen.Fields("Ubicacion").Value
            Do While Not RstResumen.EOF
                hoja.Cells(recorrido, 1) = RstResumen.Fields("Fecha").Value
                hoja.Cells(recorrido, 2) = RstResumen.Fields("Turno").Value
                hoja.Cells(recorrido, 3) = RstResumen.Fields("ToneladaSeca").Value
                hoja.Cells(recorrido, 4) = RstResumen.Fields("PromedioHumedad").Value
                hoja.Cells(recorrido, 5) = RstResumen.Fields("PromedioTenorTurno").Value
                recorrido = recorrido + 1
                RstResumen.MoveNext()
            Loop

            recorrido = 5
            hoja = CType(.Sheets("Report"), Microsoft.Office.Interop.Excel.Worksheet)
            Dim fecha1, fecha2 As Date
            fecha1 = DtInicioB12.Value
            fecha2 = DtFinalB12.Value
            Do While fecha1 <= fecha2
                hoja.Cells(recorrido, 1) = fecha1
                recorrido = recorrido + 1
                fecha1 = fecha1.AddDays(1)
                'fecha2 = fecha1.AddDays(1)
            Loop

        End With
        objExcel.Visible = True
        conn.Close()
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        Dim fechainicio As Date
        Dim fechafin As Date
        fechainicio = CDate(DtInicioMerril.Value)
        fechafin = CDate(DtFinalMerril.Value)
        Dim dias As Double
        dias = (DtFinalMerril.Value - DtInicioMerril.Value).TotalDays
        If dias > 31 Then
            MsgBox("Por Favor Seleccione un rango de Fecha no superior a 30 dias.")
            Exit Sub

        End If
        ExportarMerrilCrowe()
    End Sub


    Private Sub ExportarMerrilCrowe()
        Dim conn As New ADODB.Connection()
        Dim RstResumen As New ADODB.Recordset()
        Dim RstResumenTenor As New ADODB.Recordset()

        Dim cnStr As String
        cnStr = "Provider=SQLNCLI10;Initial Catalog=PlantaBeneficio;Data Source=SEGSVRSQL01; User ID=sa;Password=*Bd6r4nC0l0mb1a*;"
        conn.Open(cnStr)
        Dim objExcel As Microsoft.Office.Interop.Excel.Application
        objExcel = New Microsoft.Office.Interop.Excel.Application
        Dim hoja As Microsoft.Office.Interop.Excel.Worksheet
        objExcel.Workbooks.Open("\\athenea\pampaverde\mineria\Data\DataBase\Templates\MerrilCroweResumen.xlsx")
        Dim recorrido As Integer
        recorrido = 2
        objExcel.Visible = False
        RstResumen = conn.Execute(" SELECT   Fecha, Volumen, TenorCabeza, TenorCola, Turno  FROM  dbo.Pb_MerrilCroweBalance where     (Fecha >= '" & CDate(DtInicioMerril.Text) & "') AND (Fecha <= '" & CDate(DtFinalMerril.Text) & "')  ORDER BY Fecha ")
        With objExcel
            'concentrado de flotacion
            hoja = CType(.Sheets("Data"), Microsoft.Office.Interop.Excel.Worksheet)
            'hoja.Cells(1, 3) = RstResumen.Fields("Ubicacion").Value
            Do While Not RstResumen.EOF
                hoja.Cells(recorrido, 1) = RstResumen.Fields("Fecha").Value
                hoja.Cells(recorrido, 2) = RstResumen.Fields("Turno").Value
                hoja.Cells(recorrido, 3) = RstResumen.Fields("Volumen").Value
                hoja.Cells(recorrido, 4) = RstResumen.Fields("TenorCabeza").Value
                hoja.Cells(recorrido, 5) = RstResumen.Fields("TenorCola").Value
                recorrido = recorrido + 1
                RstResumen.MoveNext()
            Loop
            recorrido = 6
            hoja = CType(.Sheets("Report"), Microsoft.Office.Interop.Excel.Worksheet)
            Dim fecha1, fecha2 As Date
            fecha1 = DtInicioMerril.Value
            fecha2 = DtFinalMerril.Value
            Do While fecha1 <= fecha2
                hoja.Cells(recorrido, 1) = fecha1
                recorrido = recorrido + 1
                fecha1 = fecha1.AddDays(1)
                'fecha2 = fecha1.AddDays(1)
            Loop

        End With
        objExcel.Visible = True
        conn.Close()
    End Sub


    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        Dim DsPriv As New DataSet
        Dim EPermisos As New SqlClient.SqlDataAdapter("SELECT Usuario, IdEvento FROM RfUserEvent" & _
" WHERE RfUserEvent.Usuario='" & LblUsuario.Text & "'  and (RfUserEvent.IdEvento  = 'ModificarHorometro'  ) ", Cn)
        EPermisos.Fill(DsPriv, "RfUserEvent")
        Dim myDataViewpermisos As DataView = New DataView(DsPriv.Tables("RfUserEvent"))
        If myDataViewpermisos.Count = 0 Then
            MsgBox("El usuario no tiene privilegios para Modificar en este Formulario. Contacte a su administrador.")
            Exit Sub
        End If


        If TxtInicioHidro.Text = "" Or TxtFinalHidro.Text = "" Or TxtDensidadHidro.Text = "" Then
            MsgBox("Todos los campos son obligatorios, por favor Diligencie correctamente el formulario")
        Else
            Try
                Dim sqlConnectiondb As New System.Data.SqlClient.SqlConnection("Server=SEGSVRSQL01;uid=sa;pwd=*Bd6r4nC0l0mb1a*;database=PlantaBeneficio")
                Dim cmd As New System.Data.SqlClient.SqlCommand
                cmd.CommandType = System.Data.CommandType.Text
                If editaflujoRebalse = True Then
                    'CONSULTA CUANDO EDITAR ES VERDADERO
                    cmd.CommandText = "UPDATE  Pb_FlowsRebalseCiclon  SET LecturaInicial = @LecturaInicial,  LecturaFinal= @lecturafinal , densidad = @densidad  WHERE Turno=@Turno and Fecha=@Fecha  "
                Else
                    ' consulta sql si editar es falso 
                    cmd.CommandText = "INSERT INTO Pb_FlowsRebalseCiclon (LecturaInicial,LecturaFinal, densidad  ,Fecha, Turno )VALUES(@LecturaInicial, @LecturaFinal , @Densidad , @Fecha, @Turno )"
                End If
                cmd.Parameters.AddWithValue("@LecturaInicial", Convert.ToDecimal(TxtInicioHidro.Text))
                cmd.Parameters.AddWithValue("@LecturaFinal", Convert.ToDecimal(TxtFinalHidro.Text))
                cmd.Parameters.AddWithValue("@densidad", Convert.ToDecimal(TxtDensidadHidro.Text))
                'cmd.Parameters.AddWithValue("@HorasOperacion", Convert.ToDecimal(TxtHorasFl.Text))
                'cmd.Parameters.AddWithValue("@HorasVertimiento", Convert.ToDecimal(TxtHVertimientoFl.Text))
                cmd.Parameters.AddWithValue("@Fecha", CDate(DateTimePickerFechaReporte.Text))
                cmd.Parameters.AddWithValue("@Turno", Convert.ToString(CmbTurnoRciclon.Text))
                cmd.Connection = sqlConnectiondb
                sqlConnectiondb.Open()
                cmd.ExecuteNonQuery()
                sqlConnectiondb.Close()
                MessageBox.Show("Los datos se  guardaron Correctamente.")
                Llenar_DataGridViewDgFlujometroRebalse()
                TxtInicioHidro.Text = TxtFinalHidro.Text
                TxtFinalHidro.Clear()
                TxtDensidadHidro.Clear()
                TxtInicioHidro.Focus()
                editaflujoRebalse = False

            Catch ex As Exception
                ' Handle the exception.
                MessageBox.Show(ex.Message, Me.Text, _
      MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        End If
    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        My.Forms.FrmReporte.ShowDialog()
    End Sub
End Class