Option Explicit On
'Option Strict On
Imports System.Data
Imports System.Data.SqlClient
Imports Z_Lab.FrmPrincipal
Imports System.Data.OleDb
Imports System.Windows.Forms
Imports System.Configuration

Public Class FmConsTotalProyecto
    Dim Cn As New SqlConnection(ConfigurationManager.ConnectionStrings.Item("StringConexion").ToString())
    Private dt As DataTable
    Dim Da As New SqlDataAdapter
    Dim Cmd As New SqlCommand
    Dim Dataset As DataSet
    Dim cnStr As String
    Dim rsarea As New ADODB.Recordset()
    Dim conn As New ADODB.Connection()

    Private Sub FmConsProyecto_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.LblUsuario.Text = FrmPrincipal.LblUserName.Text
        cargararea()

    End Sub
    Private Sub picturebox1_enfoque(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.MouseHover
        PictureBox1.BorderStyle = BorderStyle.FixedSingle
    End Sub
    Private Sub picturebox1_quitarenfoque(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.MouseLeave
        PictureBox1.BorderStyle = BorderStyle.None
    End Sub

    Private Sub CargarUbicacion()
        With Cmd
            .CommandType = CommandType.Text
            .CommandText = "SELECT        Area, Ubicacion      FROM UbicacionMuestra WHERE     area   = '" & (LblArea.Text) & "'  "
            .Connection = Cn
        End With
        Da.SelectCommand = Cmd
        dt = New DataTable
        Da.Fill(dt)

        With CmbProyecto
            .DataSource = dt
            .DisplayMember = "Ubicacion"
            .ValueMember = "Ubicacion"
            .SelectedValue = 0
            .Text = "Todos"
        End With
    End Sub


    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click
        Dim totaltoneladas As Double
        Dim totalgramos As Double
        Dim totalHumedas As Double
        Dim subtotalhumedas As Double
        Dim subtotalsecas As Double
        Dim subtotalTenor As Double
        Dim subtotalOz As Double
        Dim conn As New ADODB.Connection()
        Dim RstResumen As New ADODB.Recordset()
        Dim cnStr As String
        cnStr = ConfigurationManager.ConnectionStrings.Item("StringConexionODBC").ToString()
        conn.Open(cnStr)
        Dim objExcel As Microsoft.Office.Interop.Excel.Application
        objExcel = New Microsoft.Office.Interop.Excel.Application
        Dim hoja As Microsoft.Office.Interop.Excel.Worksheet
        objExcel.Workbooks.Open("\\athenea\pampaverde\mineria\Data\DataBase\Templates\PlantaBeneficio_140912_ResumenMineras_JFP.xlsx")
        Dim recorrido As Integer
        recorrido = 4
        totaltoneladas = 0
        totalgramos = 0
        totalHumedas = 0
        ' inicializar subtotales
        subtotalhumedas = 0
        subtotalsecas = 0
        subtotalTenor = 0
        subtotalOz = 0
        objExcel.Visible = False

        If CmbProyecto.Text = "Todos" Then
            RstResumen = conn.Execute(" SELECT        dbo.Muestras.Fecha, dbo.Muestras.Muestra, dbo.Muestras.Toneladas, dbo.Muestras.ToneladaSeca, dbo.Assay.Mediana, dbo.Assay.Humedad,   dbo.Muestras.Ubicacion FROM       dbo.Assay INNER JOIN dbo.Muestras ON dbo.Assay.Muestra = dbo.Muestras.Muestra WHERE     (Fecha >= '" & CDate(DtFechainicio.Text) & "') AND (Fecha <= '" & CDate(DtFechaFinal.Text) & "') AND (dbo.Muestras.TipoMuestra = N'ORIGINAL') ORDER BY dbo.Muestras.Fecha, dbo.Muestras.Ubicacion ")
        Else
            RstResumen = conn.Execute(" SELECT        dbo.Muestras.Fecha, dbo.Muestras.Muestra, dbo.Muestras.Toneladas, dbo.Muestras.ToneladaSeca, dbo.Assay.Mediana, dbo.Assay.Humedad,   dbo.Muestras.Ubicacion FROM       dbo.Assay INNER JOIN dbo.Muestras ON dbo.Assay.Muestra = dbo.Muestras.Muestra WHERE    ( dbo.Muestras.Ubicacion= '" & CStr(CmbProyecto.Text) & "') AND (Fecha >= '" & CDate(DtFechainicio.Text) & "') AND (Fecha <= '" & CDate(DtFechaFinal.Text) & "') AND (dbo.Muestras.TipoMuestra = N'ORIGINAL') ")
        End If

        With objExcel
            hoja = CType(.Sheets("ResumenMineras"), Microsoft.Office.Interop.Excel.Worksheet)
            'hoja.Cells(1, 3) = RstResumen.Fields("Ubicacion").Value
            Do While Not RstResumen.EOF
                hoja.Cells(recorrido, 1) = RstResumen.Fields("Fecha").Value
                hoja.Cells(recorrido, 2) = RstResumen.Fields("Ubicacion").Value
                hoja.Cells(recorrido, 3) = RstResumen.Fields("Muestra").Value
                hoja.Cells(recorrido, 4) = RstResumen.Fields("Toneladas").Value
                hoja.Cells(recorrido, 5) = RstResumen.Fields("Humedad").Value
                hoja.Cells(recorrido, 6) = RstResumen.Fields("ToneladaSeca").Value
                hoja.Cells(recorrido, 7) = RstResumen.Fields("Mediana").Value
                'hoja.Cells(recorrido, 6) = RstResumen.Fields("Humedad").Value
                hoja.Cells(recorrido, 8) = CStr(CDbl((RstResumen.Fields("Mediana").Value) * Convert.ToDouble(RstResumen.Fields("ToneladaSeca").Value)) / 31.1035)
                totalHumedas = totalHumedas + CDbl(RstResumen.Fields("Toneladas").Value)
                totaltoneladas = totaltoneladas + CDbl(RstResumen.Fields("ToneladaSeca").Value)
                totalgramos = totalgramos + CDbl(RstResumen.Fields("Mediana").Value) * Convert.ToDouble(RstResumen.Fields("ToneladaSeca").Value)
                recorrido = recorrido + 1
                RstResumen.MoveNext()
            Loop
        End With
        hoja.Cells(recorrido, 1) = "TOTAL"
        hoja.Cells(recorrido, 4) = CStr(totalHumedas)
        hoja.Cells(recorrido, 6) = CStr(totaltoneladas)
        hoja.Cells(recorrido, 8) = CStr(totalgramos / 30.1034)
        hoja.Cells(recorrido, 7) = CStr(totalgramos / totaltoneladas)
        hoja.Cells(recorrido, 1).Interior.Color = RGB(247, 247, 239)
        hoja.Cells(recorrido, 2).Interior.Color = RGB(247, 247, 239)
        hoja.Cells(recorrido, 3).Interior.Color = RGB(247, 247, 239)
        hoja.Cells(recorrido, 4).Interior.Color = RGB(247, 247, 239)
        hoja.Cells(recorrido, 5).Interior.Color = RGB(247, 247, 239)
        hoja.Cells(recorrido, 6).Interior.Color = RGB(247, 247, 239)
        hoja.Cells(recorrido, 7).Interior.Color = RGB(247, 247, 239)
        hoja.Cells(recorrido, 8).Interior.Color = RGB(247, 247, 239)
        hoja.Cells(recorrido, 1).Font.Bold = True
        hoja.Cells(recorrido, 2).Font.Bold = True
        hoja.Cells(recorrido, 3).Font.Bold = True
        hoja.Cells(recorrido, 4).Font.Bold = True
        hoja.Cells(recorrido, 5).Font.Bold = True
        hoja.Cells(recorrido, 6).Font.Bold = True
        hoja.Cells(recorrido, 7).Font.Bold = True
        hoja.Cells(recorrido, 8).Font.Bold = True
        hoja.Cells(recorrido, 1).Font.Underline = True 'Pone subrrayado 
        hoja.Cells(recorrido, 2).Font.Underline = True 'Pone subrrayado 
        hoja.Cells(recorrido, 3).Font.Underline = True 'Pone subrrayado 
        hoja.Cells(recorrido, 4).Font.Underline = True 'Pone subrrayado 
        hoja.Cells(recorrido, 5).Font.Underline = True 'Pone subrrayado 
        hoja.Cells(recorrido, 6).Font.Underline = True 'Pone subrrayado 
        hoja.Cells(recorrido, 7).Font.Underline = True 'Pone subrrayado 
        hoja.Cells(recorrido, 8).Font.Underline = True 'Pone subrrayado
        objExcel.Visible = True
        conn.Close()
    End Sub


    Private Sub cargararea()
        cnStr = ConfigurationManager.ConnectionStrings.Item("StringConexionODBC").ToString()
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

End Class