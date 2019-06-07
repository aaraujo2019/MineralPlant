Option Explicit On
Option Strict On
Imports System.Data
Imports System.Data.SqlClient
Imports System.Windows.Forms

Public Class Login
    Dim Cn As New SqlConnection("Server=SEGSVRSQL01;uid=sa;pwd=*Bd6r4nC0l0mb1a*;database=PlantaBeneficio")
    Private dt As DataTable
    Dim Da As New SqlDataAdapter
    Dim Cmd As New SqlCommand
    Dim Dataset As DataSet




    Private Sub Login_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Cmdlogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmdlogin.Click


        inciarsesion()


    End Sub

    Private Sub TxtPassword_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtPassword.KeyDown

        If e.KeyCode = Keys.Enter Then

            inciarsesion()

        End If

    End Sub






    Public Sub inciarsesion()

        Try
            Dim Ds As New DataSet
            Dim DsP As New DataSet
            Dim Da As New SqlClient.SqlDataAdapter("SELECT * FROM usuario " & _
            " WHERE idUsusario='" & Me.TxtUsuario.Text.Trim & "' and Password='" & Me.TxtPassword.Text.Trim & "'", Cn)

            Da.Fill(Ds, "RfWorker")
            Dim myDataView As DataView = New DataView(Ds.Tables("RfWorker"))
            Dim Permisos As New SqlClient.SqlDataAdapter("SELECT Usuario, IdForm FROM RfPermisoForms " & _
            " WHERE Usuario='" & TxtUsuario.Text & "'  and (IdForm = 'MineralPlant' ) ", Cn)

            If myDataView.Count > 0 Then

                Me.Visible = False
                My.Forms.FrmPrincipal.ShowDialog()

            Else
                MessageBox.Show("El usuario no existe o la contraseña es incorrecta.")
                Exit Sub
            End If

            Cn.Close()
        Catch ex As Exception
            ' Handle the exception.
            MessageBox.Show(ex.Message, Me.Text, _
  MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub




    Private Sub txtpassword_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Asc(e.KeyChar) = 13 Then
            inciarsesion()
        End If
    End Sub

    Private Sub txtNombre_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Asc(e.KeyChar) = 13 Then
            TxtPassword.Focus()
        End If
    End Sub



    Private Sub Cmdcancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmdcancel.Click
        Me.Close()
    End Sub

    Private Sub GroupBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox1.Enter

    End Sub
End Class