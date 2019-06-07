Option Explicit On
Option Strict On
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports Z_Lab.FrmPrincipal
Public Class FrmAvanceMes
    Dim Cn As New SqlConnection(ConfigurationManager.AppSettings("StringConexion").ToString)
    Private dt As DataTable
    Dim Da As New SqlDataAdapter
    Dim Cmd As New SqlCommand
    Dim Dataset As DataSet
    Dim cnStr As String
    Dim rsarea As New ADODB.Recordset()
    Dim conn As New ADODB.Connection()
    Private Sub FrmAvanceMes_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        CargarAnio()
        Cargarmes()
    End Sub
    Private Sub Cargarmes()
        With Cmd
            .CommandType = CommandType.Text
            .CommandText = "SELECT        TOP (100) PERCENT Mes   FROM dbo.ReporteMensualMineras GROUP BY Mes ORDER BY Mes  "
            .Connection = Cn
        End With
        Da.SelectCommand = Cmd
        dt = New DataTable
        Da.Fill(dt)

        With CmbMes
            .DataSource = dt
            .DisplayMember = "Mes"
            .ValueMember = "Mes"
            .SelectedValue = 0
            '.Text = "Todos"
        End With
    End Sub
    Private Sub CargarAnio()
        With Cmd
            .CommandType = CommandType.Text
            .CommandText = "SELECT        TOP (100) PERCENT Anio      FROM dbo.ReporteMensualMineras GROUP BY Anio ORDER BY Anio  "
            .Connection = Cn
        End With
        Da.SelectCommand = Cmd
        dt = New DataTable
        Da.Fill(dt)

        With CmbAnio
            .DataSource = dt
            .DisplayMember = "Anio"
            .ValueMember = "Anio"
            .SelectedValue = 0
            '.Text = "Todos"
        End With
    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click

    End Sub
End Class