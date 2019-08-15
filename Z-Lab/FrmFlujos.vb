Option Explicit On
Option Strict On
Imports System.Data
Imports System.Data.SqlClient
Imports Z_Lab.Login
Imports System.Data.OleDb
Imports System.Windows.Forms
Imports System.Configuration

Public Class FrmFlujos
    Private dt As DataTable
    Dim Da As New SqlDataAdapter
    Dim Cmd As New SqlCommand
    Dim Dataset As DataSet
    Dim editarflujo As Boolean
    Dim Cn As New SqlConnection(ConfigurationManager.ConnectionStrings.Item("StringConexion").ToString())
    Private Sub FrmFlujos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.LblUsuario.Text = FrmPrincipal.LblUserName.Text
        Me.LblTipoFlujos.Text = FrmPrincipal.lbltipoflujo.Text
        CargarCmbFlujodeMasa()
        CargarlistHoraInicio()

    End Sub

    Private Sub CmdAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdAdd.Click
        Dim DsPriv As New DataSet

        Dim EPermisos As New SqlClient.SqlDataAdapter("SELECT Usuario, IdEvento FROM RfUserEvent" &
" WHERE RfUserEvent.Usuario='" & LblUsuario.Text & "'  and (RfUserEvent.IdEvento  = 'ModificarFlujos'  ) ", Cn)
        EPermisos.Fill(DsPriv, "RfUserEvent")
        Dim myDataViewpermisos As DataView = New DataView(DsPriv.Tables("RfUserEvent"))

        If myDataViewpermisos.Count = 0 Then
            MsgBox("El usuario no tiene privilegios para Modificar en este Formulario. Contacte a su administrador.")
            Exit Sub
        End If
        If CDbl(TxtDensidad.Text) <= 1000 Then
            MsgBox("la densidad debe tener un valor superior a 1000 gr/lt")
            Exit Sub
        End If

        If cmbubicacion.Text = "" Or CmbHoraInicio.Text = "" Or TxtDensidad.Text = "" Then
            MsgBox("Todos los campos son obligatorios, por favor Diligencie correctamente el formulario")
        Else
            Try
                Dim sqlConnectiondb As New System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings.Item("StringConexion").ToString())
                Dim cmd As New System.Data.SqlClient.SqlCommand
                cmd.CommandType = System.Data.CommandType.Text

                If editarflujo = True Then
                    'CONSULTA CUANDO EDITAR ES VERDADERO
                    cmd.CommandText = "UPDATE  PB_Flows  SET HoraInicio = @HoraInicio , Fecha=@Fecha,  Ubicacion = @Ubicacion , Densidad=@Densidad , TiempoSeg=@TiempoSeg , Observaciones=@Observaciones, Cianuro=@Cianuro , Ph=@ph WHERE IdConsecutivo=@IdConsecutivo  "
                Else
                    ' consulta sql si editar es falso 
                    cmd.CommandText = "INSERT INTO PB_Flows (ubicacion ,HoraInicio,Fecha,  TiempoSeg, Densidad, Observaciones , Cianuro , ph )VALUES(@ubicacion ,@HoraInicio,@Fecha, @tiemposeg,  @densidad , @Observaciones , @Cianuro , @ph)"
                End If
                cmd.Parameters.AddWithValue("@HoraInicio", Convert.ToString(CmbHoraInicio.Text))
                ' cmd.Parameters.AddWithValue("@HoraFinal", Convert.ToString(HoraFinal.Text))
                cmd.Parameters.AddWithValue("@Fecha", CDate(DtPFecha.Text))
                cmd.Parameters.AddWithValue("@Ubicacion", Convert.ToString(cmbubicacion.Text))
                cmd.Parameters.AddWithValue("@Densidad", Convert.ToDecimal(TxtDensidad.Text))
                If IsNumeric(TxtTiempo.Text) Then
                    cmd.Parameters.AddWithValue("@TiempoSeg", Convert.ToDecimal(TxtTiempo.Text))
                Else
                    cmd.Parameters.AddWithValue("@TiempoSeg", DBNull.Value)
                End If

                If editarflujo = True Then
                    cmd.Parameters.AddWithValue("@IdConsecutivo", Convert.ToInt32(LblIdConsecutivo.Text))
                End If
                cmd.Parameters.AddWithValue("@Observaciones", Convert.ToString(TxtObservaciones.Text))
                If IsNumeric(TxtCianuro.Text) Then
                    cmd.Parameters.AddWithValue("@Cianuro", Convert.ToString(TxtCianuro.Text))

                Else
                    cmd.Parameters.AddWithValue("@Cianuro", "")
                End If


                If IsDBNull(TxtPH.Text) Then
                    cmd.Parameters.AddWithValue("@PH", "")
                Else
                    cmd.Parameters.AddWithValue("@PH", Convert.ToString(TxtPH.Text))
                End If

                cmd.Connection = sqlConnectiondb
                sqlConnectiondb.Open()
                cmd.ExecuteNonQuery()
                sqlConnectiondb.Close()
                MessageBox.Show("Los datos se  guardaron Correctamente.")
                'Llenar_DataGridViewDesarrollo()
                Llenar_DataGridViewDgFlujos()
                ' TxtLecturaInicial.Text = TxtLecturaFinal.Text
                TxtDensidad.Clear()
                TxtTiempo.Clear()
                TxtPH.Clear()
                TxtCianuro.Clear()
                TxtObservaciones.Focus()
                If editarflujo = True Then
                Else
                    '' If ListB12Final.SelectedIndex + 1 > 23 Then
                    '  ListB12Final.SelectedIndex = 0
                    '   Else
                    '           ListB12Final.SelectedIndex = ListB12Final.SelectedIndex + 1
                    'End If
                End If

                editarflujo = False
                '    DgLecturaBandas.FirstDisplayedScrollingRowIndex = DgLecturaBandas.RowCount - 1
            Catch ex As Exception

                ' Handle the exception.
                MessageBox.Show(ex.Message, Me.Text,
      MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        End If
    End Sub

    Private Sub Llenar_DataGridViewDgFlujos()   'cargar DataGrid de Preparacion Daily
        Cn.Open()
        Dim ds As New DataSet
        Dim da As New SqlDataAdapter
        Dim sql As String
        sql = " SELECT   Fecha, Ubicacion, HoraInicio, Densidad, TiempoSeg, VolumenLt, Litrosporminuto,(Litrosporminuto)*60/1000 as McubicosHora, PorcSolidos, TonHora , PH, Cianuro , idconsecutivo , Observaciones from    PB_Flows INNER JOIN RfTime ON  PB_flows.HoraInicio = RfTime.Hora WHERE Fecha=  '" & CDate(DtPFecha.Text) & "' AND ubicacion= '" & cmbubicacion.Text & "'   ORDER BY RfTime.IdPlanta "
        da.SelectCommand = New SqlCommand(sql, Cn)
        da.Fill(ds)
        Cn.Close()
        Dim dt As DataTable = ds.Tables(0)
        DgFlujos.DataSource = dt
        DgFlujos.AutoResizeColumns()
        Me.DgFlujos.Columns("Fecha").Visible = False
        Me.DgFlujos.Columns("Idconsecutivo").Visible = False
        DgFlujos.Columns("PorcSolidos").DefaultCellStyle.Format = "00.00%"
        DgFlujos.Columns("Litrosporminuto").DefaultCellStyle.Format = "0.00"
        DgFlujos.Columns("Litrosporminuto").DefaultCellStyle.Format = "0.00"
        DgFlujos.Columns("McubicosHora").DefaultCellStyle.Format = "0.00"
        DgFlujos.Columns("PorcSolidos").HeaderText = "% Solidos"
        DgFlujos.Columns("HoraInicio").HeaderText = "Hora Inicio"
        DgFlujos.Columns("TiempoSeg").HeaderText = "Tiempo (Seg.)"
        DgFlujos.Columns("VolumenLt").HeaderText = "Volumen (Lt.)"
        DgFlujos.Columns("Litrosporminuto").HeaderText = "Litros/Min."
        'DgFlujos.Columns("M3Hora").HeaderText = "m³/hora "
        DgFlujos.Columns("TonHora").HeaderText = "Ton/Hora "
        DgFlujos.Columns("Ubicacion").HeaderText = "Ubicación"
        DgFlujos.Columns("Densidad").HeaderText = "Densidad"
        ''DgFlujos.Columns("Porc_Pasante").HeaderText = "% de Pasante 74µm"
        'DgFlujos.Columns("VolumenLt").HeaderText = "m³/hora"
        Dim metrospreparacion As Decimal
        metrospreparacion = 0
        'Llenar_TotalTenorFlotacion()
        Me.DgFlujos.ReadOnly = False
    End Sub


    Private Sub CargarCmbFlujodeMasa()
        With Cmd
            .CommandType = CommandType.Text
            .CommandText = "SELECT        TOP (100) PERCENT Id, Name, VolumenLt  FROM           rfFlows where tipo= '" & LblTipoFlujos.Text & "' and Visible='1' ORDER BY Name"
            .Connection = Cn
        End With
        Da.SelectCommand = Cmd

        dt = New DataTable
        Da.Fill(dt)
        With cmbubicacion
            .DataSource = dt
            .DisplayMember = "Name"
            .ValueMember = "Name"
            .SelectedValue = 0
            .Text = "Seleccione"
        End With

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

        With CmbHoraInicio
            .DataSource = dt
            .DisplayMember = "Hora"
            .ValueMember = "Id"
        End With


    End Sub

    Private Sub DgFlujos_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgFlujos.CellClick



        Try
            'Aquí pongo lo que pasaría si el campo está en blanco o nulo

            If DBNull.Value.Equals(DgFlujos.CurrentRow.Cells("idconsecutivo").Value) Then
                Me.TxtDensidad.Clear()
                Me.TxtTiempo.Clear()
                Me.TxtPH.Clear()
                Me.TxtCianuro.Clear()

            Else



                Me.CmbHoraInicio.Text = CStr(Me.DgFlujos.Rows(e.RowIndex).Cells("HoraInicio").Value())

                If DBNull.Value.Equals(DgFlujos.CurrentRow.Cells("densidad").Value) Then
                    TxtDensidad.Clear()
                Else
                    Me.TxtDensidad.Text = CStr(Me.DgFlujos.Rows(e.RowIndex).Cells("Densidad").Value())
                End If
                If DBNull.Value.Equals(DgFlujos.CurrentRow.Cells("TiempoSeg").Value) Then
                    TxtTiempo.Clear()
                Else
                    Me.TxtTiempo.Text = CStr(Me.DgFlujos.Rows(e.RowIndex).Cells("TiempoSeg").Value())
                End If

                If DBNull.Value.Equals(DgFlujos.CurrentRow.Cells("PH").Value) Then
                    TxtPH.Clear()
                Else
                    Me.TxtPH.Text = CStr(Me.DgFlujos.Rows(e.RowIndex).Cells("PH").Value())
                End If

                If DBNull.Value.Equals(DgFlujos.CurrentRow.Cells("Cianuro").Value) Then
                    TxtCianuro.Clear()
                Else
                    Me.TxtCianuro.Text = CStr(Me.DgFlujos.Rows(e.RowIndex).Cells("Cianuro").Value())
                End If


                Me.LblIdConsecutivo.Text = CStr(Me.DgFlujos.Rows(e.RowIndex).Cells("idconsecutivo").Value())

                editarflujo = True
            End If
        Catch ex As Exception
            ' Handle the exception.

            MessageBox.Show(ex.Message, Me.Text,
  MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub

    Private Sub DgFlujos_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgFlujos.CellDoubleClick

        If MsgBox("Esta Seguro Que Desea Eliminar El Registro Seleccionado?", vbYesNo, "") = vbYes Then
            Try
                If DBNull.Value.Equals(DgFlujos.CurrentRow.Cells("IdConsecutivo").Value) Then
                    TxtDensidad.Clear()
                    TxtCianuro.Clear()
                    TxtPH.Clear()
                    TxtTiempo.Clear()

                Else
                    Dim sqlConnectiondb As New System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings.Item("StringConexion").ToString())
                    Dim cmd As New System.Data.SqlClient.SqlCommand
                    cmd.CommandType = System.Data.CommandType.Text
                    'cmd.CommandText = "DELETE FROM PB_Flows    WHERE Fecha=  '" & CDate(DtPFecha.Text) & "' AND Ubicacion= '" & cmbubicacion.Text & "' AND HoraInicio= '" & CmbHoraInicio.Text & "' "

                    cmd.CommandText = "DELETE FROM PB_Flows    WHERE IdConsecutivo=  '" & CInt((Me.DgFlujos.Rows(e.RowIndex).Cells("idconsecutivo").Value())) & "' "
                    cmd.Connection = sqlConnectiondb
                    sqlConnectiondb.Open()
                    cmd.ExecuteNonQuery()
                    sqlConnectiondb.Close()
                End If
                Llenar_DataGridViewDgFlujos()
                ' ListHoraFinal.ClearSelected()
                TxtDensidad.Clear()
                TxtCianuro.Clear()
                TxtPH.Clear()
                TxtTiempo.Clear()
                editarflujo = False
            Catch ex As Exception
                ' Handle the exception.
                MessageBox.Show(ex.Message, Me.Text, _
      MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Else
            'ACA EL CODIGO SI PULSA NO
        End If
    End Sub

    Private Sub cmbubicacion_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbubicacion.SelectedIndexChanged
        Llenar_DataGridViewDgFlujos()
    End Sub

    Private Sub DtPFecha_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DtPFecha.ValueChanged
        Llenar_DataGridViewDgFlujos()
    End Sub

    Private Sub MaskedTextBox1_MaskInputRejected(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MaskInputRejectedEventArgs)

    End Sub

    Private Sub CmdExportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdExportar.Click
        Dim totaltoneladas As Double
        Dim totalgramos As Double
        Dim conn As New ADODB.Connection()
        Dim RstResumen As New ADODB.Recordset()
        Dim cnStr As String
        cnStr = "Provider=SQLNCLI10;Initial Catalog=PlantaBeneficio;Data Source=10.10.203.4; User ID=sa;Password=*Bd6r4nC0l0mb1a*;"
        conn.Open(cnStr)
        Dim objExcel As Microsoft.Office.Interop.Excel.Application
        objExcel = New Microsoft.Office.Interop.Excel.Application
        Dim hoja As Microsoft.Office.Interop.Excel.Worksheet
        objExcel.Workbooks.Open("\\athenea\pampaverde\MINERIA\Data\DataBase\Templates\ExportDensidad.xlsx")
        Dim recorrido As Integer
        recorrido = 2
        totaltoneladas = 0
        totalgramos = 0
        objExcel.Visible = False
        RstResumen = conn.Execute(" SELECT     Fecha, HoraInicio, Densidad, Ubicacion , M3Hora, TonHora, GravedadEspecifica , PorcSolidos , Cianuro , PH  FROM         dbo.PB_Flows  INNER JOIN RfFlows ON PB_Flows.Ubicacion = RfFlows.Name  where    (ubicacion = '" & (cmbubicacion.Text) & "') AND  (Fecha >= '" & CDate(DtFecha1.Text) & "') AND (Fecha <= '" & CDate(DtFecha2.Text) & "')  ORDER BY Fecha, Ubicacion ")
        'RstResumen = conn.Execute("SELECT     TOP (100) PERCENT dbo.PB_MerrilCrowe.Fecha, SUM(dbo.PB_MerrilCrowe.Volumen) AS VolumenTotal, SUM(dbo.PB_MerrilCrowe.Onzas) AS OnzasTotal,  AVG(dbo.PB_MerrilCrowe.TenorCabeza) AS TenorPromedio, AVG(dbo.PB_MerrilCrowe.TenorCola) AS TenorColas FROM         dbo.PB_MerrilCrowe INNER JOIN     dbo.RfTime ON dbo.PB_MerrilCrowe.HoraInicial = dbo.RfTime.Hora GROUP BY dbo.PB_MerrilCrowe.Fecha    HAVING        (Fecha >= '" & CDate(DtFechainicio.Text) & "') AND (Fecha <= '" & CDate(DtFechaFinal.Text) & "')")
        With objExcel
            hoja = CType(.Sheets("DatosDensidad"), Microsoft.Office.Interop.Excel.Worksheet)
            'hoja.Cells(1, 3) = RstResumen.Fields("Ubicacion").Value
            Do While Not RstResumen.EOF
                hoja.Cells(recorrido, 1) = RstResumen.Fields("Fecha").Value
                hoja.Cells(recorrido, 2) = RstResumen.Fields("Ubicacion").Value
                hoja.Cells(recorrido, 3) = RstResumen.Fields("HoraInicio").Value
                hoja.Cells(recorrido, 4) = RstResumen.Fields("Densidad").Value
                hoja.Cells(recorrido, 5) = RstResumen.Fields("M3Hora").Value
                hoja.Cells(recorrido, 6) = RstResumen.Fields("TonHora").Value
                hoja.Cells(recorrido, 7) = RstResumen.Fields("PorcSolidos").Value
                hoja.Cells(recorrido, 8) = RstResumen.Fields("GravedadEspecifica").Value
                hoja.Cells(recorrido, 9) = RstResumen.Fields("Cianuro").Value
                hoja.Cells(recorrido, 10) = RstResumen.Fields("PH").Value
                recorrido = recorrido + 1
                RstResumen.MoveNext()
            Loop
            'LblExport.Visible = False
            objExcel.Visible = True

        End With

        conn.Close()
    End Sub

    Private Sub GroupBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox1.Enter

    End Sub
End Class