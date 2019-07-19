Option Explicit On
Option Strict On
Imports System.Data
Imports System.Data.SqlClient
Imports Z_Lab.Login
Imports System.Data.OleDb
Imports System.Windows.Forms
Imports Z_Lab.FrmPrincipal
Imports System.Configuration

Public Class FrmFundicion
    Private dt As DataTable
    Dim Da As New SqlDataAdapter
    Dim Cmd As New SqlCommand
    Dim Dataset As DataSet
    Dim Cn As New SqlConnection(ConfigurationManager.ConnectionStrings.Item("StringConexion").ToString())
    Dim editarfundicion As Boolean
    Dim conn As New ADODB.Connection()
    Dim rstoperacion As New ADODB.Recordset()
    Dim Rsfundicion As New ADODB.Recordset()
    Dim cnStr As String

    Private Sub CmdGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdGuardar.Click
        Dim DsPriv As New DataSet
        Dim EPermisos As New SqlClient.SqlDataAdapter("SELECT Usuario, IdEvento FROM RfUserEvent" & " WHERE RfUserEvent.Usuario='" & LblUsuario.Text & "'  and (RfUserEvent.IdEvento  = 'Modificarfundicion'  ) ", Cn)

        EPermisos.Fill(DsPriv, "RfUserEvent")
        Dim myDataViewpermisos As DataView = New DataView(DsPriv.Tables("RfUserEvent"))

        If myDataViewpermisos.Count = 0 Then
            MsgBox("El usuario no tiene privilegios para Modificar en este Formulario. Contacte a su administrador.")
            Exit Sub
        End If
        If TxtIdBarra.Text = "" Or TxtPesoInicial.Text = "" Then
            MsgBox("Por favor Diligencie correctamente el formulario")
        Else
            Try
                Dim sqlConnectiondb As New System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings.Item("StringConexion").ToString())
                Dim cmd As New System.Data.SqlClient.SqlCommand
                cmd.CommandType = System.Data.CommandType.Text

                If editarfundicion = True Then
                    'CONSULTA CUANDO EDITAR ES VERDADERO
                    cmd.CommandText = "UPDATE  PB_Fundicion  SET Fecha = @Fecha,  BarraNo= @BarraNo , Peso1Gr=@Peso1Gr,  Peso2Gr = @Peso2Gr , LeyAu1=@LeyAu1 , LeyAu2=@LeyAu2, LeyAg1=@LeyAg1 , LeyAg2=@LeyAg2 , Periodo=@Periodo , OrigenBarra=@OrigenBarra WHERE BarraNo=@BarraNo  "
                Else
                    ' consulta sql si editar es falso 
                    cmd.CommandText = "INSERT INTO PB_Fundicion (Fecha,BarraNo,Peso1Gr, Peso2Gr,  LeyAu1, LeyAu2, LeyAg1, LeyAg2 , Periodo , OrigenBarra )VALUES(@Fecha,@BarraNo,@Peso1Gr, @Peso2Gr,  @LeyAu1, @LeyAu2, @LeyAg1, @LeyAg2 , @Periodo ,@OrigenBarra)"
                End If
                cmd.Parameters.AddWithValue("@Fecha", Convert.ToDateTime(DtFecha.Text))
                cmd.Parameters.AddWithValue("@BarraNo", Convert.ToInt16(TxtIdBarra.Text))
                If IsDBNull(TxtPesoInicial.Text) Or TxtPesoInicial.Text = "" Then
                    cmd.Parameters.AddWithValue("@Peso1Gr", 0.0)
                Else
                    cmd.Parameters.AddWithValue("@Peso1Gr", Convert.ToDecimal(TxtPesoInicial.Text))
                End If
                If IsNothing(TxtPesoFinal.Text) Or TxtPesoFinal.Text = "" Then
                    cmd.Parameters.AddWithValue("@Peso2Gr", 0.0)
                Else
                    cmd.Parameters.AddWithValue("@Peso2Gr", Convert.ToDecimal(TxtPesoFinal.Text))
                End If
                If IsDBNull(TxtAuLey1.Text) Or TxtAuLey1.Text = "" Then
                    cmd.Parameters.AddWithValue("@LeyAu1", 0.0)
                Else
                    cmd.Parameters.AddWithValue("@LeyAu1", Convert.ToDecimal(TxtAuLey1.Text))
                End If
                If IsDBNull(TxtAuLey2.Text) Or TxtAuLey2.Text = "" Then
                    cmd.Parameters.AddWithValue("@LeyAu2", 0.0)
                Else
                    cmd.Parameters.AddWithValue("@LeyAu2", Convert.ToDecimal(TxtAuLey2.Text))
                End If

                If IsDBNull(TxtAgLey1.Text) Or TxtAgLey1.Text = "" Then
                    cmd.Parameters.AddWithValue("@LeyAg1", 0.0)
                Else
                    cmd.Parameters.AddWithValue("@LeyAg1", Convert.ToDecimal(TxtAgLey1.Text))
                End If
                If IsDBNull(TxtAgLey2.Text) Or TxtAgLey2.Text = "" Then
                    cmd.Parameters.AddWithValue("@LeyAg2", 0.0)
                Else
                    cmd.Parameters.AddWithValue("@LeyAg2", Convert.ToDecimal(TxtAgLey2.Text))
                End If
                cmd.Parameters.AddWithValue("@Periodo", Convert.ToString(cmbperiodo.Text))
                'OrigenBarra

                cmd.Parameters.AddWithValue("@OrigenBarra", Convert.ToString(CmbOrigen.Text))


                'Periodo
                ' cmd.Parameters.AddWithValue("@IdConsecutivo", Convert.ToInt32(LblIdConsecutivo.Text))
                cmd.Connection = sqlConnectiondb
                sqlConnectiondb.Open()
                cmd.ExecuteNonQuery()
                sqlConnectiondb.Close()
                MessageBox.Show("Los datos se  guardaron Correctamente.")
                'Llenar_DataGridViewDesarrollo()
                llenardatagridviewFundicion()
                TxtAgLey1.Clear()
                TxtAgLey2.Clear()
                TxtAuLey1.Clear()
                TxtAuLey2.Clear()
                TxtAgLey2.Clear()
                TxtIdBarra.Clear()
                TxtPesoInicial.Clear()
                TxtPesoFinal.Clear()
                TxtPesoInicial.Focus()
                editarfundicion = False
                'DgLecturaBandas.FirstDisplayedScrollingRowIndex = DgLecturaBandas.RowCount - 1
            Catch ex As Exception
                ' Handle the exception.
                MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        End If
    End Sub

    Private Sub DgFundicion_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dgfundicion.CellClick
        Try
            'Aquí pongo lo que pasaría si el campo está en blanco o nulo

            If DBNull.Value.Equals(Dgfundicion.CurrentRow.Cells("BarraNo").Value) Then
                Me.TxtIdBarra.Clear()
                Me.TxtPesoInicial.Clear()
                Me.TxtPesoFinal.Clear()
                Me.TxtAuLey1.Clear()
                Me.TxtAgLey1.Clear()
                Me.TxtAuLey2.Clear()
                Me.TxtAgLey2.Clear()
            Else
                TxtIdBarra.Text = CStr(Me.Dgfundicion.Rows(e.RowIndex).Cells("BarraNo").Value())
                TxtPesoInicial.Text = CStr(Me.Dgfundicion.Rows(e.RowIndex).Cells("Peso1Gr").Value())
                TxtPesoFinal.Text = CStr(Me.Dgfundicion.Rows(e.RowIndex).Cells("Peso2Gr").Value())
                TxtAuLey1.Text = CStr(Me.Dgfundicion.Rows(e.RowIndex).Cells("LeyAu1").Value())
                TxtAgLey1.Text = CStr(Me.Dgfundicion.Rows(e.RowIndex).Cells("LeyAg1").Value())
                TxtAuLey2.Text = CStr(Me.Dgfundicion.Rows(e.RowIndex).Cells("LeyAu2").Value())
                TxtAgLey2.Text = CStr(Me.Dgfundicion.Rows(e.RowIndex).Cells("LeyAg2").Value())
                cmbperiodo.Text = CStr(Me.Dgfundicion.Rows(e.RowIndex).Cells("Periodo").Value())
                CmbOrigen.Text = CStr(Me.Dgfundicion.Rows(e.RowIndex).Cells("OrigenBarra").Value())
                editarfundicion = True
            End If
        Catch ex As Exception
            ' Handle the exception.
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub




    Private Sub llenardatagridviewFundicion()
        'cargar DataGrid de Preparacion Daily
        Cn.Open()
        Dim ds As New DataSet
        Dim da As New SqlDataAdapter
        Dim sql As String
        sql = "SELECT     Fecha, BarraNo, Peso1Gr, Peso2Gr, LeyAu1, LeyAg1, ContenidoAu1, ContenidoAg1 , Base1, LeyAu2, LeyAg2, ContenidoAu2, OzTroy , ContenidoAg2 , Base2 , periodo , OrigenBarra FROM         dbo.PB_Fundicion   WHERE        Fecha=  '" & CDate(DtFecha.Text) & "' "
        da.SelectCommand = New SqlCommand(sql, Cn)
        da.Fill(ds)
        Cn.Close()
        Dim dt As DataTable = ds.Tables(0)
        Dgfundicion.DataSource = dt
        Dgfundicion.AutoResizeColumns()
        Dgfundicion.Columns("ContenidoAu1").DefaultCellStyle.Format = "0.00"
        Dgfundicion.Columns("ContenidoAu2").DefaultCellStyle.Format = "0.00"
        Dgfundicion.Columns("ContenidoAg1").DefaultCellStyle.Format = "0.00"
        Dgfundicion.Columns("ContenidoAg2").DefaultCellStyle.Format = "0.00"
        Dgfundicion.Columns("fecha").Visible = False
        Dgfundicion.Columns("Peso1Gr").HeaderText = "Peso Inicial"
        Dgfundicion.Columns("Peso2Gr").HeaderText = "Peso Final"
        Dgfundicion.Columns("LeyAu1").HeaderText = "Ley Oro"
        Dgfundicion.Columns("LeyAg1").HeaderText = "Ley Plata"
        Dgfundicion.Columns("ContenidoAu1").HeaderText = "Contenido de Oro (Gr)"
        Dgfundicion.Columns("ContenidoAg1").HeaderText = "Contenido de Plata (Gr)"
        Dgfundicion.Columns("Base1").HeaderText = "Base"
        '---------------------------------------------------------------------------------------
        Dgfundicion.Columns("LeyAu2").HeaderText = "Ley Oro"
        Dgfundicion.Columns("LeyAg2").HeaderText = "Ley Plata"
        Dgfundicion.Columns("ContenidoAu2").HeaderText = "Contenido de Oro (Gr)"
        Dgfundicion.Columns("ContenidoAg2").HeaderText = "Contenido de Plata (Gr)"
        Dgfundicion.Columns("Base2").HeaderText = "Base"
        ' Dgfundicion.Columns("Espesador").HeaderText = "Espesador-Agitador"
        ' Dgfundicion.Columns("Tonsecalixi").HeaderText = "Toneladas Seca"
        ' Dgfundicion.Columns("AuFinal_ppm").HeaderText = "Tenor Gr/Ton"
        'Dgfundicion.Columns("AlimentoGr").HeaderText = "Total Gr de Au."
        Dim metrospreparacion As Decimal
        metrospreparacion = 0

        Me.Dgfundicion.ReadOnly = False
    End Sub

    Private Sub FrmFundicion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.LblUsuario.Text = FrmPrincipal.LblUserName.Text
        CargarAno()
    End Sub




    Private Sub Llenar_TotalFundicion()
        Dim registros As Decimal
        Dim pesoinicialgr As Decimal
        Dim pesofinalgr, contenidoau1, contenidoag1, contenidoau2, contenidoag2 As Decimal

        pesoinicialgr = 0
        registros = 0
        pesofinalgr = 0
        contenidoau1 = 0
        contenidoag1 = 0
        contenidoau2 = 0
        contenidoag2 = 0
        For Each dRow As DataGridViewRow In Dgfundicion.Rows
            If (dRow.Cells.Item("Peso1Gr").Value) IsNot Nothing Then

                If Not IsDBNull(dRow.Cells.Item("Peso1Gr").Value) Then
                    pesoinicialgr = CDec(dRow.Cells.Item("Peso1Gr").Value) + pesoinicialgr
                End If

                If Not IsDBNull(dRow.Cells.Item("Peso2Gr").Value) Then
                    pesofinalgr = CDec(dRow.Cells.Item("Peso2Gr").Value) + pesofinalgr
                End If

                If Not IsDBNull(dRow.Cells.Item("ContenidoAu1").Value) Then
                    contenidoau1 = CDec(dRow.Cells.Item("ContenidoAu1").Value) + contenidoau1
                End If

                If Not IsDBNull(dRow.Cells.Item("ContenidoAg1").Value) Then
                    contenidoag1 = CDec(dRow.Cells.Item("ContenidoAg1").Value) + contenidoag1
                End If

                If Not IsDBNull(dRow.Cells.Item("ContenidoAu2").Value) Then
                    contenidoau2 = CDec(dRow.Cells.Item("ContenidoAu2").Value) + contenidoau2
                End If

                If Not IsDBNull(dRow.Cells.Item("ContenidoAg2").Value) Then
                    contenidoag2 = CDec(dRow.Cells.Item("ContenidoAg2").Value) + contenidoag2
                End If
            End If
            registros = registros + 1

        Next dRow
        If registros = 0 Then
            LblPesoIGr.Text = "0"
            LblPesoFgr.Text = "0"
            LblLeyau1.Text = "0"
            LblLeyAg1.Text = "0"
            LblLeyAu2.Text = "0"
            LblLeyAg2.Text = "0"
            LblPesoIGr.Text = "0"
            LblPesoFgr.Text = "0"
        Else
            LblPesoIGr.Text = CStr(Format(pesoinicialgr, "0.00"))
            LblPesoFgr.Text = CStr(Format(pesofinalgr, "0.00"))
            LblLeyau1.Text = CStr(Format(contenidoau1, "0.00"))
            LblLeyAg1.Text = CStr(Format(contenidoag1, "0.00"))
            LblLeyAu2.Text = CStr(Format(contenidoau2, "0.00"))
            LblLeyAg2.Text = CStr(Format(contenidoag2, "0.00"))
            LblpesoIOz.Text = CStr(Format(pesoinicialgr / 31.1035, "0.00"))
            LblPesoFOnzas.Text = CStr(Format(pesofinalgr / 31.1035, "0.00"))
            LblAuOz.Text = CStr(Format(contenidoau1 / 31.1035, "0.00"))
            LblAgOz.Text = CStr(Format(contenidoag1 / 31.1035, "0.00"))
            LblAuOzAu.Text = CStr(Format(contenidoau2 / 31.1035, "0.00"))
            LblAgOz2.Text = CStr(Format(contenidoag2 / 31.1035, "0.00"))
            'LblPesoFOnzas.Text = CStr(Format(porcsolido / registros, "0.00"))
        End If

        Me.Dgfundicion.ReadOnly = False
    End Sub

    Private Sub DtFecha_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DtFecha.ValueChanged
        llenardatagridviewFundicion()
        Llenar_TotalFundicion()
    End Sub



    Private Sub CargarAno()
        With Cmd
            .CommandType = CommandType.Text
            .CommandText = " SELECT TOP (100) PERCENT ano FROM PB_Conveyor GROUP BY ano ORDER BY ano"
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

    Private Sub CmdBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdBuscar.Click
        ' AND PERIODO = '" & (cmbperiodo2.Text) & "' 
        cnStr = ConfigurationManager.ConnectionStrings.Item("StringConexionODBC").ToString()
        conn.Open(cnStr)
        Rsfundicion = conn.Execute(" SELECT * FROM         PB_Fundicion WHERE ano = '" & (cmbano.Text) & "'  AND MES = '" & (cmbmes.Text) & "'  AND PERIODO = '" & (cmbperiodo2.Text) & "'       ")
        If Rsfundicion.EOF = True Then
            MsgBox("No Existe")
            DtFecha.Value = Today
        Else
            Me.DtFecha.Value = CDate((Rsfundicion.Fields("FECHA").Value))
        End If
        conn.Close()

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

    End Sub
End Class