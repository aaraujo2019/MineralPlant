Option Explicit On
Option Strict On
Imports System.Data
Imports System.Data.SqlClient
Imports Z_Lab.FrmPrincipal
Imports System.Windows.Forms
Imports System.Configuration

Public Class FrmMuestras
    Dim Cn As New SqlConnection(ConfigurationManager.AppSettings("StringConexion").ToString)
    Private dt As DataTable
    Dim Da As New SqlDataAdapter
    Dim Cmd As New SqlCommand
    Dim Dataset As DataSet
    Dim cnStr As String
    Dim conn As New ADODB.Connection()
    Dim rsarea As New ADODB.Recordset()
    Dim editamuestra As Boolean
    Private Sub FrmMuestras_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.LblUsuario.Text = FrmPrincipal.LblUserName.Text
        cargararea()
    End Sub



    Private Sub CargarUbicacion()
        With Cmd
            .CommandType = CommandType.Text
            '.CommandText = "SELECT        Area, Ubicacion      FROM UbicacionMuestra WHERE     area   = '" & (LblArea.Text) & "'  "
            .CommandText = "SELECT        Area, Ubicacion      FROM UbicacionMuestra   "
            .Connection = Cn
        End With
        Da.SelectCommand = Cmd
        dt = New DataTable
        Da.Fill(dt)

        With CmbUbicacion
            .DataSource = dt
            .DisplayMember = "Ubicacion"
            .ValueMember = "Ubicacion"
            .SelectedValue = 0
            .Text = "Seleccione"
        End With
    End Sub
    Private Sub Llenar_DgMuestra()
        Cn.Open()
        Dim ds As New DataSet
        Dim da As New SqlDataAdapter
        Dim sql As String
        sql = " SELECT    Muestra, Ubicacion, Toneladas , TipoMuestra, Observaciones , fecha  from MN_Muestras WHERE Fecha=  '" & CDate(DtFecha.Text) & "'  ORDER BY Ubicacion , Muestra"
        da.SelectCommand = New SqlCommand(sql, Cn)
        da.Fill(ds)
        Cn.Close()
        Dim dt As DataTable = ds.Tables(0)
        DgMuestra.DataSource = dt
        DgMuestra.AutoResizeColumns()
        Me.DgMuestra.Columns("Fecha").Visible = False
        DgMuestra.Columns("Toneladas").HeaderText = "Toneladas Humedas"
        DgMuestra.Columns("Muestra").HeaderText = "Muestra"
        DgMuestra.Columns("Ubicacion").HeaderText = "Ubicacion"
        DgMuestra.Columns("Observaciones").HeaderText = "Observaciones"
        DgMuestra.Columns("TipoMuestra").HeaderText = "TipoMuestra"

        Me.DgMuestra.ReadOnly = False
    End Sub


    Private Sub cargarComboRespuestas()
        ',cmb.Text = "Selecione un Programa"
        Dim cmb As New DataGridViewComboBoxColumn()
        cmb.Name = "Control"
        cmb.Items.Add("SI")
        cmb.Items.Add("NO")
        'cmb.Items.Add("NA")
        cmb.ValueMember = "Control"
        DgMuestra.Columns.Add(cmb)
    End Sub


    Private Sub Llenar_DgAnalisis()
        Dim ds As New DataSet
        Dim da As New SqlDataAdapter
        Dim sql As String
        Dim Cmd As New SqlCommand
        sql = "  SELECT        dbo.MN_Muestras.Muestra, dbo.MN_Muestras.Ubicacion, dbo.MN_Muestras.ToneladaSeca, dbo.MN_Assay.Humedad, dbo.MN_Assay.Aufinal, dbo.MN_Assay.Mediana, dbo.MN_Assay.Desviacion,    dbo.MN_Assay.QAQC FROM            dbo.MN_Assay INNER JOIN  dbo.MN_Muestras ON dbo.MN_Assay.Muestra = dbo.MN_Muestras.Muestra  WHERE Fecha=  '" & CDate(DtFecha.Text) & "'  ORDER BY ubicacion , Muestra "
        da.SelectCommand = New SqlCommand(sql, Cn)
        da.Fill(ds)
        Cn.Close()
        Dim dt As DataTable = ds.Tables(0)
        DgMuestra.DataSource = dt
        DgMuestra.ClearSelection()
        DgMuestra.Columns("ToneladaSeca").DefaultCellStyle.Format = "0.00"
        DgMuestra.Columns("Humedad").DefaultCellStyle.Format = "0.00"
        DgMuestra.Columns("Aufinal").DefaultCellStyle.Format = "0.00"
        DgMuestra.Columns("Mediana").DefaultCellStyle.Format = "0.00"
        DgMuestra.Columns("Desviacion").DefaultCellStyle.Format = "0.00"
        DgMuestra.Columns("ToneladaSeca").HeaderText = "Toneladas Seca"
        DgMuestra.Columns("Humedad").HeaderText = "% de Humedad"
        DgMuestra.Columns("Aufinal").HeaderText = "Tenor Lab Au"
        DgMuestra.Columns("Mediana").HeaderText = "Tenor Final Au"
        DgMuestra.AutoResizeColumns()
        Me.DgMuestra.ReadOnly = False

    End Sub


    Public Sub cargarduplicado()
        For index As Integer = 1 To 3
            Dim sqlConnectiondb As New System.Data.SqlClient.SqlConnection(ConfigurationManager.AppSettings("StringConexion").ToString)
            Dim cmd As New System.Data.SqlClient.SqlCommand
            cmd.CommandType = System.Data.CommandType.Text
            cmd.CommandText = "INSERT INTO MN_Muestras (muestra,Ubicacion,Observaciones, Fecha ,TipoMuestra , DupMuestra)VALUES(@Muestra ,@Ubicacion,@Observaciones,@Fecha,   @TipoMuestra , @DupMuestra )"
            If index = 1 Then
                cmd.Parameters.AddWithValue("@Muestra", Convert.ToString(TxtMuestra.Text) & "A")
            End If
            If index = 2 Then
                cmd.Parameters.AddWithValue("@Muestra", Convert.ToString(TxtMuestra.Text) & "B")
            End If
            If index = 3 Then
                cmd.Parameters.AddWithValue("@Muestra", Convert.ToString(TxtMuestra.Text) & "C")
            End If
            cmd.Parameters.AddWithValue("@Ubicacion", Convert.ToString(CmbUbicacion.Text))
            cmd.Parameters.AddWithValue("@Observaciones", "")
            cmd.Parameters.AddWithValue("@Fecha", CDate(DtFecha.Text))
            cmd.Parameters.AddWithValue("@TipoMuestra", "DUPLICADO")
            cmd.Parameters.AddWithValue("@DupMuestra", Convert.ToString(TxtMuestra.Text))
            cmd.Connection = sqlConnectiondb
            sqlConnectiondb.Open()
            cmd.ExecuteNonQuery()
            sqlConnectiondb.Close()
        Next
    End Sub
    Private Sub cargararea()

        cnStr = "Provider=SQLNCLI10;Initial Catalog=PlantaBeneficio;Data Source=SEGSVRSQL01; User ID=sa;Password=*Bd6r4nC0l0mb1a*;"
        conn.Open(cnStr)
        rsarea = conn.Execute(" SELECT * FROM         usuario WHERE (IdUsusario = '" & (LblUsuario.Text) & "')         ")
        If rsarea.EOF = True Then
            Me.LblArea.Text = "NO"

        Else

            Me.LblArea.Text = CStr((rsarea.Fields("Area").Value))
            CargarUbicacion()

        End If
        conn.Close()


    End Sub






    Private Sub CmdGuardar_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdGuardar.Click
        If TxtMuestra.Text = "" Or CmbUbicacion.Text = "Seleccione" Or CmbUbicacion.Text = "" Then
            MsgBox("Por Favor Diligencie los campos obligatorios.")
            Exit Sub
        End If
        Dim DsPriv As New DataSet
        Try
            Dim sqlConnectiondb As New System.Data.SqlClient.SqlConnection(ConfigurationManager.AppSettings("StringConexion").ToString)
            Dim cmd As New System.Data.SqlClient.SqlCommand
            cmd.CommandType = System.Data.CommandType.Text
            If editamuestra = True Then
                cmd.CommandText = "UPDATE  MN_Muestras  SET   Ubicacion= @Ubicacion ,  Observaciones= @Observaciones , Fecha = @Fecha , Toneladas=@Toneladas  WHERE  Muestra = @Muestra  "
            Else
                ' consulta sql si editar es falso 
                cmd.CommandText = "INSERT INTO MN_Muestras ( Muestra, Ubicacion, Observaciones, Fecha , TipoMuestra , DupMuestra ,Toneladas) VALUES ( @Muestra , @Ubicacion, @Observaciones , @Fecha , @TipoMuestra , @DupMuestra , @Toneladas)"
            End If
            cmd.Parameters.AddWithValue("@Muestra", Convert.ToString(TxtMuestra.Text))
            cmd.Parameters.AddWithValue("@Ubicacion", Convert.ToString(CmbUbicacion.Text))
            cmd.Parameters.AddWithValue("@Observaciones", Convert.ToString(TxtObservacion.Text))
            cmd.Parameters.AddWithValue("@Fecha", CDate(DtFecha.Text))
            cmd.Parameters.AddWithValue("@DupMuestra", Convert.ToString(TxtMuestra.Text))
            cmd.Parameters.AddWithValue("@TipoMuestra", "ORIGINAL")
            cmd.Parameters.AddWithValue("@Toneladas", Convert.ToString(TxtToneladas.Text))
            cmd.Connection = sqlConnectiondb
            sqlConnectiondb.Open()
            cmd.ExecuteNonQuery()
            sqlConnectiondb.Close()
            If ChkDup.Checked = True And editamuestra = False Then
                cargarduplicado()
            End If

            MessageBox.Show("Los datos se  guardaron Correctamente.")
            Llenar_DgMuestra()
            TxtMuestra.Clear()
            TxtObservacion.Clear()
            TxtToneladas.Clear()
            'CmbUbicacion.Text = "Seleccione"
            editamuestra = False
            sqlConnectiondb.Close()
        Catch ex As Exception
            ' Handle the exception.
            MessageBox.Show(ex.Message, Me.Text,
  MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub picturebox2_quitarenfoque(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox2.MouseLeave
        PictureBox2.BorderStyle = BorderStyle.None
    End Sub
    Private Sub picturebox2_enfoque(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox2.MouseHover
        PictureBox2.BorderStyle = BorderStyle.FixedSingle
        Me.ToolTip1.SetToolTip(PictureBox2, "Exportar a Excel")
    End Sub
    Private Sub picturebox1_enfoque(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PicGuardar1.MouseHover
        PicGuardar1.BorderStyle = BorderStyle.FixedSingle
        Me.ToolTip1.SetToolTip(PicGuardar1, "Guardar Cambios de Control de Calidad")
    End Sub
    Private Sub picturebox1_quitarenfoque(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PicGuardar1.MouseLeave
        PicGuardar1.BorderStyle = BorderStyle.None
    End Sub
    Private Sub ButtonCmdGuardar_msgadd(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdGuardar.MouseLeave
        Me.ToolTip1.SetToolTip(CmdGuardar, "Guardar Muestra")
    End Sub

    Private Sub picturebox1_click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PicGuardar1.MouseClick
        TxtObservacion.Focus()
        If ChkAnalisis.Checked = True Then
            For Each dRow As DataGridViewRow In DgMuestra.Rows
                If (dRow.Cells.Item("Muestra").Value) IsNot Nothing Then
                    Dim sqlConnectiondb As New System.Data.SqlClient.SqlConnection(ConfigurationManager.AppSettings("StringConexion").ToString)
                    Dim cmd As New System.Data.SqlClient.SqlCommand
                    cmd.CommandType = System.Data.CommandType.Text
                    cmd.CommandText = "UPDATE  MN_Assay  SET   QAQC= @QAQc  WHERE  Muestra = @Muestra  "
                    cmd.Parameters.AddWithValue("@Muestra", Convert.ToString(dRow.Cells.Item("Muestra").Value))
                    cmd.Parameters.AddWithValue("@QAQC", (dRow.Cells.Item("QAQC").Value))
                    cmd.Connection = sqlConnectiondb
                    sqlConnectiondb.Open()
                    cmd.ExecuteNonQuery()
                    sqlConnectiondb.Close()
                    'Else
                    ' End If
                End If
            Next dRow
            MsgBox("Actualizado")
            Llenar_DgAnalisis()
        End If

    End Sub


    Private Sub DgMuestra_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgMuestra.CellClick
        Try
            'Aquí pongo lo que pasaría si el campo está en blanco o nulo
            If ChkAnalisis.Checked = False Then

                If DBNull.Value.Equals(DgMuestra.CurrentRow.Cells("Muestra").Value) Then
                    Me.TxtMuestra.Clear()
                    Me.CmbUbicacion.Text = "Seleccione"
                    Me.TxtObservacion.Clear()
                    Me.TxtToneladas.Clear()
                Else
                    TxtMuestra.Text = CStr(Me.DgMuestra.Rows(e.RowIndex).Cells("Muestra").Value())
                    CmbUbicacion.Text = CStr(Me.DgMuestra.Rows(e.RowIndex).Cells("Ubicacion").Value())
                    TxtToneladas.Text = CStr(Me.DgMuestra.Rows(e.RowIndex).Cells("Toneladas").Value())
                    TxtObservacion.Text = CStr(Me.DgMuestra.Rows(e.RowIndex).Cells("Observaciones").Value())
                    editamuestra = True
                End If
            End If
        Catch ex As Exception
            ' Handle the exception.
            MessageBox.Show(ex.Message, Me.Text,
  MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub DgMuestras_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgMuestra.CellDoubleClick
        If MsgBox("Esta Seguro Que Desea Eliminar La Muestra Seleccionada?", vbYesNo, "") = vbYes Then
            Try ' fue adentro
                If DBNull.Value.Equals(DgMuestra.CurrentRow.Cells("Muestra").Value) Then  'Aquí pongo lo que pasaría si el campo está en blanco o nulo
                    TxtMuestra.Clear()
                    TxtObservacion.Clear()
                    CmbUbicacion.Text = "Seleccione"
                Else
                    Dim sqlConnectiondb As New System.Data.SqlClient.SqlConnection(ConfigurationManager.AppSettings("StringConexion").ToString)
                    Dim cmd As New System.Data.SqlClient.SqlCommand
                    cmd.CommandType = System.Data.CommandType.Text
                    cmd.CommandText = "DELETE FROM Muestras    WHERE Muestra=  '" & CStr(TxtMuestra.Text) & "' "
                    cmd.Connection = sqlConnectiondb
                    sqlConnectiondb.Open()
                    cmd.ExecuteNonQuery()
                    sqlConnectiondb.Close()
                End If
                Llenar_DgMuestra()
                TxtMuestra.Clear()
                TxtObservacion.Clear()
                CmbUbicacion.Text = "Seleccione"
                editamuestra = False
            Catch ex As Exception
                ' Handle the exception.
                MessageBox.Show(ex.Message, Me.Text, _
      MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Else
        End If
    End Sub


    Private Sub DtFecha_ValueChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DtFecha.ValueChanged
        Llenar_DgMuestra()
        TxtMuestra.Clear()
        TxtObservacion.Clear()
        TxtToneladas.Clear()
        ChkAnalisis.Checked = False
        CmbUbicacion.Text = "Seleccione"
    End Sub

    Private Sub DgMuestra_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgMuestra.CellContentClick

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Llenar_DgAnalisis()
    End Sub

    Private Sub ChkAnalisis_CheckedChanged(ByVal sender As Object, _
ByVal e As EventArgs) Handles ChkAnalisis.CheckedChanged
        If ChkAnalisis.Checked Then
            Llenar_DgAnalisis()
        Else
            Llenar_DgMuestra()
        End If

    End Sub


    Private Sub picturebox1_click(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PicGuardar1.MouseClick

    End Sub

    Private Sub PicGuardar1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PicGuardar1.Click

    End Sub

    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox2.Click
        If ChkAnalisis.Checked = False Then
            Dim objExcel As Microsoft.Office.Interop.Excel.Application
            objExcel = New Microsoft.Office.Interop.Excel.Application
            Dim hoja As Microsoft.Office.Interop.Excel.Worksheet
            objExcel.Workbooks.Open("\\athenea\pampaverde\mineria\Data\DataBase\Templates\GZC_ReporteDMuestrasPMineria_JFP.xlsx")
            Dim recorrido As Integer
            recorrido = 6
            objExcel.Visible = False
            For Each dRow As DataGridViewRow In DgMuestra.Rows
                If (dRow.Cells.Item("Muestra").Value) IsNot Nothing Then
                    With objExcel
                        hoja = CType(.Sheets("Muestras"), Microsoft.Office.Interop.Excel.Worksheet)
                        hoja.Cells(recorrido, 1) = Convert.ToString(dRow.Cells.Item("Muestra").Value)
                        hoja.Cells(recorrido, 2) = Convert.ToString(dRow.Cells.Item("Ubicacion").Value)
                        hoja.Cells(recorrido, 3) = Convert.ToString(dRow.Cells.Item("Toneladas").Value)
                        recorrido = recorrido + 1
                    End With
                End If
            Next dRow
            objExcel.Visible = True

        Else
            Dim objExcel As Microsoft.Office.Interop.Excel.Application
            objExcel = New Microsoft.Office.Interop.Excel.Application
            Dim hoja As Microsoft.Office.Interop.Excel.Worksheet
            objExcel.Workbooks.Open("\\athenea\pampaverde\mineria\Data\DataBase\Templates\GZC_ReporteDMuestrasPMineria_JFP.xlsx")
            Dim recorrido As Integer
            recorrido = 6
            objExcel.Visible = False
            For Each dRow As DataGridViewRow In DgMuestra.Rows
                If (dRow.Cells.Item("Muestra").Value) IsNot Nothing Then
                    With objExcel
                        hoja = CType(.Sheets("Muestras"), Microsoft.Office.Interop.Excel.Worksheet)
                        hoja.Cells(recorrido, 1) = Convert.ToString(dRow.Cells.Item("Muestra").Value)
                        hoja.Cells(recorrido, 2) = Convert.ToString(dRow.Cells.Item("Ubicacion").Value)
                        hoja.Cells(recorrido, 3) = Convert.ToString(dRow.Cells.Item("ToneladaSeca").Value)
                        hoja.Cells(recorrido, 4) = Convert.ToString(dRow.Cells.Item("Humedad").Value)
                        hoja.Cells(recorrido, 5) = Convert.ToString(dRow.Cells.Item("Aufinal").Value)
                        hoja.Cells(recorrido, 6) = Convert.ToString(dRow.Cells.Item("Mediana").Value)
                        hoja.Cells(recorrido, 7) = Convert.ToString(dRow.Cells.Item("Desviacion").Value)
                        hoja.Cells(recorrido, 8) = Convert.ToInt16(dRow.Cells.Item("QAQC").Value)
                        recorrido = recorrido + 1
                    End With
                End If

            Next dRow
            objExcel.Visible = True
        End If
    End Sub

    Private Sub GroupBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox1.Enter

    End Sub
End Class