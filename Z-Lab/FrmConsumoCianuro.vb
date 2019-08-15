Option Explicit On
Option Strict On
Imports System.Data
Imports System.Data.SqlClient
Imports Z_Lab.Login
Imports System.Data.OleDb
Imports System.Windows.Forms
Imports Z_Lab.FrmPrincipal
Imports System.Configuration

Public Class FrmConsumoCianuro
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
    Private Sub CmdBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdBuscar.Click
        Cn.Open()
        Dim ds As New DataSet
        Dim da As New SqlDataAdapter
        Dim sql As String
        sql = "SELECT * FROM Pb_ConsumoDeCianuro WHERE ubicacion  = '" & (CmbUbicacion.Text) & "'  AND fecha >= '" & CDate(DtInicio.Text) & "'  AND fecha <= '" & CDate(DtFinal.Text) & "'"
        da.SelectCommand = New SqlCommand(sql, Cn)
        da.Fill(ds)
        Cn.Close()
        Dim dt As DataTable = ds.Tables(0)

        If dt.Rows.Count > 0 Then
            llenardatagridviewCianuro()
            Llenar_TotalConsumoCianuro()
        Else
            MsgBox("No Existe")
            DtFinal.Value = Today
        End If
    End Sub
    Private Sub Cargarubicacion()
        With Cmd
            .CommandType = CommandType.Text
            .CommandText = " SELECT     Ubicacion   FROM Pb_ConsumoDeCianuro GROUP BY Ubicacion HAVING     Ubicacion IS NOT NULL"
            .Connection = Cn
        End With
        Da.SelectCommand = Cmd
        dt = New DataTable
        Da.Fill(dt)
        With CmbUbicacion
            .DataSource = dt
            .DisplayMember = "Ubicacion"
            .ValueMember = "Ubicacion"
        End With
    End Sub

    Private Sub llenardatagridviewCianuro()
        'cargar DataGrid de Preparacion Daily
        Cn.Open()
        Dim ds As New DataSet
        Dim da As New SqlDataAdapter
        Dim sql As String
        sql = "SELECT     Fecha, ubicacion , turno , Cianuro_Kg_Turno , Equivalente_NaCN FROM         dbo.Pb_ConsumoDeCianuro   WHERE    ubicacion=  '" & (CmbUbicacion.Text) & "' and      Fecha>=  '" & CDate(DtInicio.Text) & "' and   Fecha<=  '" & CDate(DtFinal.Text) & "' order by  Fecha, Turno "
        da.SelectCommand = New SqlCommand(sql, Cn)
        da.Fill(ds)
        Cn.Close()
        Dim dt As DataTable = ds.Tables(0)
        DgConsumoCianuro.DataSource = dt
        DgConsumoCianuro.AutoResizeColumns()
        DgConsumoCianuro.Columns("Cianuro_Kg_Turno").DefaultCellStyle.Format = "0.00"
        DgConsumoCianuro.Columns("Equivalente_NaCN").DefaultCellStyle.Format = "0.00"


        DgConsumoCianuro.Columns("Cianuro_Kg_Turno").HeaderText = "Kilogramos de Cn Turno"
        DgConsumoCianuro.Columns("Equivalente_NaCN").HeaderText = "Kilogramos de NaCn Turno"

        '---------------------------------------------------------------------------------------



        Me.DgConsumoCianuro.ReadOnly = False
    End Sub
    Private Sub Llenar_TotalConsumoCianuro()

        Dim totalkgCn, totalkgnacn As Decimal
        totalkgCn = 0
        totalkgnacn = 0
        Dim registros As Decimal
        registros = 0
        For Each dRow As DataGridViewRow In DgConsumoCianuro.Rows
            If (dRow.Cells.Item("fecha").Value) IsNot Nothing Then

                If IsDBNull(dRow.Cells.Item("fecha").Value) Then

                Else
                    totalkgCn = CDec(dRow.Cells.Item("Cianuro_Kg_Turno").Value) + totalkgCn
                    totalkgnacn = CDec(dRow.Cells.Item("Equivalente_NaCN").Value) + totalkgnacn
                End If

            End If
            registros = registros + 1
        Next dRow
        LblKgCN.Text = CStr(Format(totalkgCn, "0.00"))
        LblNaCN.Text = CStr(Format(totalkgnacn, "0.00"))
        Me.DgConsumoCianuro.ReadOnly = False
    End Sub
    Private Sub FrmConsumoCianuro_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Cargarubicacion()
    End Sub
End Class