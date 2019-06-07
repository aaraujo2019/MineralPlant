Option Explicit On
Option Strict On
Imports System.Data
Imports System.Data.SqlClient
Imports Z_Lab.Login
Imports System.Data.OleDb
Imports System.Windows.Forms
Imports System.Configuration

Public Class FrConfFlows
    Private dt As DataTable
    Dim Da As New SqlDataAdapter
    Dim Cmd As New SqlCommand
    Dim Dataset As DataSet
    Dim editarflujo As Boolean
    Dim Cn As New SqlConnection(ConfigurationManager.AppSettings("StringConexion").ToString)
    Private Sub FrConfFlows_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Llenar_DataGridViewDgFlujos()
        Me.LblUsuario.Text = FrmPrincipal.LblUserName.Text
    End Sub
    Private Sub Llenar_DataGridViewDgFlujos()   'cargar DataGrid de Preparacion Daily
        Cn.Open()
        Dim ds As New DataSet
        Dim da As New SqlDataAdapter
        Dim sql As String
        sql = " SELECT     TOP (100) PERCENT Id, Name, VolumenLt, Visible, Tipo FROM         RfFlows ORDER BY Tipo, Name "
        da.SelectCommand = New SqlCommand(sql, Cn)
        da.Fill(ds)
        Cn.Close()
        Dim dt As DataTable = ds.Tables(0)
        DgFlows.DataSource = dt
        DgFlows.AutoResizeColumns()
        Me.DgFlows.Columns("id").Visible = False
        DgFlows.Columns("Name").HeaderText = "Ubicacion"
        DgFlows.Columns("VolumenLt").HeaderText = "Volumen del Tanque de Medicion (Litros)"
        DgFlows.Columns("Visible").HeaderText = "Activado / Desactivado"
        Me.DgFlows.ReadOnly = False
    End Sub
    Private Sub DgFlujos_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgFlows.CellClick

        Try
            'Aquí pongo lo que pasaría si el campo está en blanco o nulo
            If DBNull.Value.Equals(DgFlows.CurrentRow.Cells("id").Value) Then
                Me.TxtUbicacion.Clear()
                Me.TxtVolumen.Clear()
                Me.ChkActivate.Checked = False
            Else
                Lblid.Text = CStr(Me.DgFlows.Rows(e.RowIndex).Cells("id").Value())
                Me.TxtUbicacion.Text = CStr(Me.DgFlows.Rows(e.RowIndex).Cells("name").Value())
                Me.TxtVolumen.Text = CStr(Me.DgFlows.Rows(e.RowIndex).Cells("VolumenLt").Value())
                Me.CmbTipoUbicacion.Text = CStr(Me.DgFlows.Rows(e.RowIndex).Cells("tipo").Value())
                If CBool(Me.DgFlows.Rows(e.RowIndex).Cells("Visible").Value()) = True Then
                    ChkActivate.Checked = True
                Else
                    ChkActivate.Checked = False
                End If

                editarflujo = True
            End If
        Catch ex As Exception
            ' Handle the exception.
            MessageBox.Show(ex.Message, Me.Text,
  MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim DsPriv As New DataSet
        Dim EPermisos As New SqlClient.SqlDataAdapter("SELECT Usuario, IdEvento FROM RfUserEvent" &
" WHERE RfUserEvent.Usuario='" & LblUsuario.Text & "'  and (RfUserEvent.IdEvento  = 'ConfigurarFlujos'  ) ", Cn)
        EPermisos.Fill(DsPriv, "RfUserEvent")
        Dim myDataViewpermisos As DataView = New DataView(DsPriv.Tables("RfUserEvent"))
        If myDataViewpermisos.Count = 0 Then
            MsgBox("El usuario no tiene privilegios para Modificar en este Formulario. Contacte a su administrador.")
            Exit Sub
        End If
        If TxtUbicacion.Text = "" Or TxtVolumen.Text = "" Then
            MsgBox("Todos los campos son obligatorios, por favor Diligencie correctamente el formulario")
        Else
            Try
                Dim sqlConnectiondb As New System.Data.SqlClient.SqlConnection(ConfigurationManager.AppSettings("StringConexion").ToString)
                Dim cmd As New System.Data.SqlClient.SqlCommand
                cmd.CommandType = System.Data.CommandType.Text
                If editarflujo = True Then
                    'CONSULTA CUANDO EDITAR ES VERDADERO
                    cmd.CommandText = "UPDATE  RfFlows  SET Name = @Name , VolumenLt=@VolumenLt,  Visible = @Visible , Tipo=@Tipo WHERE id=@id  "
                    cmd.Parameters.AddWithValue("@id", Convert.ToInt16(Lblid.Text))
                Else
                    ' consulta sql si editar es falso 
                    cmd.CommandText = "INSERT INTO RfFlows (Name ,VolumenLt,Visible,  Tipo)VALUES(@Name ,@VolumenLt,@Visible, @Tipo)"
                End If
                cmd.Parameters.AddWithValue("@Name", Convert.ToString(TxtUbicacion.Text))
                cmd.Parameters.AddWithValue("@VolumenLt", Convert.ToDecimal(TxtVolumen.Text))
                cmd.Parameters.AddWithValue("@Tipo", Convert.ToString(CmbTipoUbicacion.Text))

                If (ChkActivate.Checked = True) Then
                    cmd.Parameters.AddWithValue("@Visible", True)

                Else
                    cmd.Parameters.AddWithValue("@Visible", False)
                End If
                cmd.Connection = sqlConnectiondb
                sqlConnectiondb.Open()
                cmd.ExecuteNonQuery()
                sqlConnectiondb.Close()
                MessageBox.Show("Los datos se  guardaron Correctamente.")
                Llenar_DataGridViewDgFlujos()
                TxtUbicacion.Clear()
                TxtVolumen.Clear()
                ChkActivate.Checked = False
                If editarflujo = True Then

                Else

                End If
                editarflujo = False
            Catch ex As Exception
                ' Handle the exception.
                MessageBox.Show(ex.Message, Me.Text, _
      MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        End If



    End Sub
End Class