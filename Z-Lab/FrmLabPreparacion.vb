Option Explicit On
Option Strict On
Imports System.Data
Imports System.Data.SqlClient
Imports Z_Lab.FrmPrincipal
Imports System.Windows.Forms
Imports System.Configuration

Public Class FrmLabPreparacion
    Dim Cn As New SqlConnection(ConfigurationManager.ConnectionStrings.Item("StringConexion").ToString())
    Private dt As DataTable
    Dim Da As New SqlDataAdapter
    Dim Cmd As New SqlCommand
    Dim Dataset As DataSet
    Dim cnStr As String
    Dim conn As New ADODB.Connection()
    Dim rsarea As New ADODB.Recordset()
    Dim rsmuestra As New ADODB.Recordset()
    Private Sub FrmLabPreparacion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.LblUsuario.Text = FrmPrincipal.LblUserName.Text
        cargararea()
    End Sub
    Private Sub TxtMuestra_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtMuestra.KeyDown

        If e.KeyCode = Keys.Enter Then

            BuscarMuestra()

        End If
    End Sub

    Private Sub cargararea()

        cnStr = ConfigurationManager.ConnectionStrings.Item("StringConexionODBC").ToString()
        conn.Open(cnStr)
        rsarea = conn.Execute(" SELECT * FROM         usuario WHERE (IdUsusario = '" & (LblUsuario.Text) & "')         ")
        If rsarea.EOF = True Then
            Me.LblArea.Text = "NO"
        Else
            Me.LblArea.Text = CStr((rsarea.Fields("Area").Value))
        End If
        conn.Close()
    End Sub




    Private Sub picturebox6_enfoque(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox6.MouseHover
        PictureBox6.BorderStyle = BorderStyle.Fixed3D
        Me.ToolTip1.SetToolTip(PictureBox6, "Buscar la Muestra")
    End Sub
    Private Sub picturebox5_quitarenfoque(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtonGardar.MouseLeave
        BtonGardar.BorderStyle = BorderStyle.FixedSingle
    End Sub
    Private Sub picturebox5_enfoque(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtonGardar.MouseHover
        BtonGardar.BorderStyle = BorderStyle.Fixed3D
        Me.ToolTip1.SetToolTip(BtonGardar, "Guarda Cambios")
    End Sub
    Private Sub picturebox6_quitarenfoque(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox6.MouseLeave
        PictureBox6.BorderStyle = BorderStyle.FixedSingle
    End Sub




    Protected Sub txtBOX1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtPBandeja.TextChanged

        If Microsoft.VisualBasic.Left(TxtPBandeja.Text, 3) = "S S" Then
            Dim S As String
            S = Microsoft.VisualBasic.Left(TxtPBandeja.Text, Len(TxtPBandeja.Text) - 2)
            S = Microsoft.VisualBasic.Right(S, Len(S) - 9)
            TxtPBandeja.Text = S
            TxtPHumedo.Focus()
        End If


        'TxtPBandeja.Enabled = False
    End Sub
    Protected Sub TxtPHumedo_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtPHumedo.TextChanged

        If Microsoft.VisualBasic.Left(TxtPHumedo.Text, 3) = "S S" Then
            Dim S As String
            S = Microsoft.VisualBasic.Left(TxtPHumedo.Text, Len(TxtPHumedo.Text) - 2)
            S = Microsoft.VisualBasic.Right(S, Len(S) - 9)
            TxtPHumedo.Text = S
            Guardarpeso()
            TxtMuestra.Focus()

        End If

    End Sub

    Protected Sub TxtPSeco_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtPSeco.TextChanged
        If Microsoft.VisualBasic.Left(TxtPSeco.Text, 3) = "S S" Then
            Dim S As String
            S = Microsoft.VisualBasic.Left(TxtPSeco.Text, Len(TxtPSeco.Text) - 2)
            S = Microsoft.VisualBasic.Right(S, Len(S) - 9)
            TxtPSeco.Text = S
        End If


    End Sub




    Private Sub PictureBox3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub PictureBox4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub






    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub PictureBox6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox6.Click
        BuscarMuestra()
    End Sub

    Private Sub BtonGardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtonGardar.Click
        Guardarpeso()
    End Sub
    Private Sub Guardarpeso()

        If TxtMuestra.Text = "" Or TxtPBandeja.Text = "" Or TxtPHumedo.Text = "" Then
            MsgBox("Por Favor Diligencie los campos obligatorios.")
            Exit Sub
        End If

        Try
            Dim sqlConnectiondb As New System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings.Item("StringConexion").ToString())
            Dim cmd As New System.Data.SqlClient.SqlCommand
            cmd.CommandType = System.Data.CommandType.Text
            cmd.CommandText = "UPDATE  Lab_Muestras  SET   PesoBandejaMuestra= @PesoBandejaMuestra ,  PesoHumedoMuestra= @PesoHumedoMuestra , PesoSecoMuestra = @PesoSecoMuestra  WHERE  Muestra = @Muestra  "
            cmd.Parameters.AddWithValue("@Muestra", Convert.ToString(TxtMuestra.Text))
            cmd.Parameters.AddWithValue("@PesoBandejaMuestra", Convert.ToString(TxtPBandeja.Text))
            cmd.Parameters.AddWithValue("@PesoHumedoMuestra", Convert.ToString(TxtPHumedo.Text))
            cmd.Parameters.AddWithValue("@PesoSecoMuestra", Convert.ToString(TxtPSeco.Text))
            cmd.Connection = sqlConnectiondb
            sqlConnectiondb.Open()
            cmd.ExecuteNonQuery()
            sqlConnectiondb.Close()
            TxtPBandeja.Enabled = False
            TxtPHumedo.Enabled = False
            MsgBox("Guardado")
        Catch ex As Exception
            ' Handle the exception.
            MessageBox.Show(ex.Message, Me.Text, _
  MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Sub BuscarMuestra()
        cnStr = ConfigurationManager.ConnectionStrings.Item("StringConexionODBC").ToString()
        conn.Open(cnStr)
        rsmuestra = conn.Execute(" SELECT * FROM         Lab_Muestras WHERE (Muestra = '" & (TxtMuestra.Text) & "')         ")
        If rsmuestra.EOF = True Then
            MsgBox("La muestra no existe")
            TxtPBandeja.Clear()
            TxtPHumedo.Clear()
            TxtPSeco.Clear()
            TxtPBandeja.Enabled = False
            TxtPHumedo.Enabled = False
            LblPorHumedad.Text = "00000"
        Else
            If rsmuestra.Fields("PesoBandejaMuestra").Value IsNot DBNull.Value Then
                Me.TxtPBandeja.Text = CStr((rsmuestra.Fields("PesoBandejaMuestra").Value))
            End If
            If rsmuestra.Fields("PesoHumedoMuestra").Value IsNot DBNull.Value Then
                Me.TxtPHumedo.Text = CStr((rsmuestra.Fields("PesoHumedoMuestra").Value))
            End If
            If rsmuestra.Fields("PesoHumedoMuestra").Value IsNot DBNull.Value Then
                Me.TxtPSeco.Text = CStr((rsmuestra.Fields("PesoSecoMuestra").Value))
            End If
            If rsmuestra.Fields("PorcHumedad").Value IsNot DBNull.Value Then
                Me.LblPorHumedad.Text = CStr((rsmuestra.Fields("PorcHumedad").Value))
            Else
                LblPorHumedad.Text = "00000"
            End If

            TxtPBandeja.Enabled = True
            TxtPHumedo.Enabled = True
        End If
        conn.Close()
    End Sub


End Class