Option Explicit On
Option Strict On
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports System.Windows.Forms
Public Class FrmUsuarios
    Private dt As DataTable
    Dim Da As New SqlDataAdapter
    Dim Cmd As New SqlCommand
    Dim Dataset As DataSet
    Dim editarinstantanea As Boolean
    Dim Cn As New SqlConnection(ConfigurationManager.ConnectionStrings.Item("StringConexion").ToString())
    Dim cnStr As String
    Dim EditarUsuarios As Boolean
    Private Sub FrmUsuarios_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.LblUsuario.Text = FrmPrincipal.LblUserName.Text
        EditarUsuarios = True
        llenar_datagridviewUsuarios()
    End Sub

    Private Sub llenar_datagridviewUsuarios()   'cargar DataGrid de Preparacion Daily
        Cn.Open()
        Dim ds As New DataSet
        Dim da As New SqlDataAdapter
        Dim sql As String
        sql = "SELECT        Usuario, Nombre, Cargo, email, Password, Area, Status FROM RfWorker "
        da.SelectCommand = New SqlCommand(sql, Cn)
        da.Fill(ds)
        Cn.Close()
        Dim dt As DataTable = ds.Tables(0)
        DgUsuarios.DataSource = dt
        DgUsuarios.AutoResizeColumns()

        Me.DgUsuarios.ReadOnly = False
    End Sub


    Private Sub CmdGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdGuardar.Click

        If TxtUsuarioName.Text = "" Or TxtUsuarioCargo.Text = "" Or TxtPassword.Text = "" Then
            MsgBox("Todos los campos son obligatorios, por favor Diligencie correctamente el formulario")
        Else
            Try
                Dim sqlConnectiondb As New System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings.Item("StringConexion").ToString())
                Dim cmd As New System.Data.SqlClient.SqlCommand
                cmd.CommandType = System.Data.CommandType.Text

                If EditarUsuarios = True Then
                    'CONSULTA CUANDO EDITAR ES VERDADERO
                    cmd.CommandText = "UPDATE  RfWorker  SET  Nombre = @Nombre , Cargo=@Cargo , Area=@Area WHERE  Usuario=@Usuario  "
                Else
                    ' consulta sql si editar es falso 
                    cmd.CommandText = "INSERT INTO RfWorker (Usuario, Nombre,  Cargo, email , Password , Area) VALUES (@Usuario, @Nombre,  @Cargo, @email , @Password , @Area)"
                End If

                cmd.Parameters.AddWithValue("@Usuario", Convert.ToString(txtidusuario.Text))
                cmd.Parameters.AddWithValue("@Nombre", Convert.ToString(TxtUsuarioName.Text))
                cmd.Parameters.AddWithValue("@Cargo", Convert.ToString(TxtUsuarioCargo.Text))
                cmd.Parameters.AddWithValue("@email", Convert.ToString(TxtEmail.Text))
                cmd.Parameters.AddWithValue("@Password", Convert.ToString(TxtPassword.Text))
                cmd.Parameters.AddWithValue("@Area", Convert.ToString(CmbUsuarioDpto.Text))



                cmd.Connection = sqlConnectiondb
                sqlConnectiondb.Open()
                cmd.ExecuteNonQuery()
                sqlConnectiondb.Close()
                MessageBox.Show("Los datos se  guardaron Correctamente.")
                'Llenar_DataGridViewDesarrollo()
                llenar_datagridviewUsuarios()
                TxtEmail.Clear()
                txtidusuario.Focus()
                TxtPassword.Focus()
                TxtUsuarioCargo.Focus()
                TxtUsuarioName.Focus()
                EditarUsuarios = False

            Catch ex As Exception
                ' Handle the exception.
                MessageBox.Show(ex.Message, Me.Text, _
      MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        End If
    End Sub
End Class