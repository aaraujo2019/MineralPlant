Imports System.Configuration
Imports System.Data.SqlClient
Public Class ConexionBd




    Private con As SqlConnection

    Public bdcIsRespuesta As Boolean = False

    Private tabla As DataTable

    Private adaptador As SqlDataAdapter

    Private datos As DataSet



    Public Sub New()



    End Sub

    Public Sub bdcAbriConexion()

        Try

            'Si no exite alguna conexion la crea 

            If con Is Nothing Then

                con = New SqlConnection

                con.ConnectionString = ConfigurationManager.ConnectionStrings.Item("StringConexion").ToString()

                con.Open()

                bdcIsRespuesta = True

            End If

            'Si la conexion esta cerrada, abre la conexion 

            If Not con.State = ConnectionState.Open Then

                con.Open()

                bdcIsRespuesta = True

            End If

        Catch

            bdcIsRespuesta = False



        End Try

    End Sub

End Class

