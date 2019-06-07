
Imports System.Configuration
Imports System.Data.SqlClient
Imports Microsoft.VisualBasic.CompilerServices

Public Class ConexionBd
    Public Sub bdcAbriConexion()
        Try
            If Object.ReferenceEquals(Me.con, Nothing) Then
                Me.con = New SqlConnection
                Me.con.ConnectionString = ConfigurationManager.AppSettings("StringConexion").ToString
                Me.con.Open()
                Me.bdcIsRespuesta = True
            End If
            If (Me.con.State <> ConnectionState.Open) Then
                Me.con.Open()
                Me.bdcIsRespuesta = True
            End If
        Catch exception1 As Exception
            ProjectData.SetProjectError(exception1)
            Me.bdcIsRespuesta = False
            ProjectData.ClearProjectError()
        End Try
    End Sub


    ' Fields
    Private con As SqlConnection
    Public bdcIsRespuesta As Boolean = False
    Private tabla As DataTable
    Private adaptador As SqlDataAdapter
    Private datos As DataSet
End Class
