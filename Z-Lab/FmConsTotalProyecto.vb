Option Explicit On
'Option Strict On
Imports System.Data
Imports System.Data.SqlClient
Imports Z_Lab.FrmPrincipal
Imports System.Windows.Forms
Imports System.Configuration

Public Class FmConsTotalProyectoFinal
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
        Dim conn As New ADODB.Connection()
        Dim RstResumen As New ADODB.Recordset()
        Dim cnStr As String
        cnStr = ConfigurationManager.ConnectionStrings.Item("StringConexionODBC").ToString()
        conn.Open(cnStr)
        Dim objExcel As Microsoft.Office.Interop.Excel.Application
        objExcel = New Microsoft.Office.Interop.Excel.Application
        Dim hoja As Microsoft.Office.Interop.Excel.Worksheet
        objExcel.Workbooks.Open("\\athenea\pampaverde\mineria\Data\DataBase\Templates\PlantaBeneficio_141509_TotalMineras_JFP.xlsx")
        Dim recorrido As Integer
        recorrido = 5
        totaltoneladas = 0
        totalgramos = 0
        objExcel.Visible = False

        If CmbProyecto.Text = "Todos" Then
            RstResumen = conn.Execute(" SELECT        TOP (100) PERCENT Fecha, Ubicacion, SUM(AlimentoGr) / SUM(ToneladaSeca) AS TenorDia, SUM(ToneladaSeca) AS ToneladasSecas, SUM(AlimentoGr) AS AlimentoGramos    FROM dbo.AlimentoGr GROUP BY Fecha, Ubicacion HAVING        (Fecha >= '" & CDate(DtFechainicio.Text) & "') AND (Fecha <= '" & CDate(DtFechaFinal.Text) & "')  ORDER BY Fecha, Ubicacion ")
        Else
            RstResumen = conn.Execute(" SELECT        TOP (100) PERCENT Fecha, Ubicacion, SUM(AlimentoGr) / SUM(ToneladaSeca) AS TenorDia, SUM(ToneladaSeca) AS ToneladasSecas, SUM(AlimentoGr) AS AlimentoGramos    FROM dbo.AlimentoGr GROUP BY Fecha, Ubicacion HAVING        (Fecha >= '" & CDate(DtFechainicio.Text) & "') AND (Fecha <= '" & CDate(DtFechaFinal.Text) & "') AND (Ubicacion = '" & (CmbProyecto.Text) & "') ORDER BY Fecha, Ubicacion ")
        End If

        With objExcel
            hoja = CType(.Sheets("ResumenTotal"), Microsoft.Office.Interop.Excel.Worksheet)
            'hoja.Cells(1, 3) = RstResumen.Fields("Ubicacion").Value
            Do While Not RstResumen.EOF
                hoja.Cells(recorrido, 1) = RstResumen.Fields("Fecha").Value
                hoja.Cells(recorrido, 2) = RstResumen.Fields("Ubicacion").Value
                hoja.Cells(recorrido, 3) = RstResumen.Fields("ToneladasSecas").Value
                hoja.Cells(recorrido, 4) = CStr(CDbl(RstResumen.Fields("AlimentoGramos").Value) / 30.1034)
                hoja.Cells(recorrido, 5) = RstResumen.Fields("TenorDia").Value
                ' hoja.Cells(recorrido, 7) = CStr(CDbl(RstResumen.Fields("Mediana").Value) * Convert.ToDouble(RstResumen.Fields("ToneladaSeca").Value) / 31.1035)
                totaltoneladas = totaltoneladas + CDbl(RstResumen.Fields("ToneladasSecas").Value)
                totalgramos = totalgramos + CDbl(RstResumen.Fields("AlimentoGramos").Value)
                recorrido = recorrido + 1
                RstResumen.MoveNext()
            Loop
        End With
        hoja.Cells(recorrido, 1) = "TOTAL"
        hoja.Cells(recorrido, 3) = CStr(totaltoneladas)
        hoja.Cells(recorrido, 4) = CStr(totalgramos / 30.1034)
        hoja.Cells(recorrido, 5) = CStr(totalgramos / totaltoneladas)
        hoja.Cells(recorrido, 1).Interior.Color = RGB(247, 247, 239)
        hoja.Cells(recorrido, 2).Interior.Color = RGB(247, 247, 239)
        hoja.Cells(recorrido, 3).Interior.Color = RGB(247, 247, 239)
        hoja.Cells(recorrido, 4).Interior.Color = RGB(247, 247, 239)
        hoja.Cells(recorrido, 5).Interior.Color = RGB(247, 247, 239)
        hoja.Cells(recorrido, 6).Interior.Color = RGB(247, 247, 239)
        hoja.Cells(recorrido, 7).Interior.Color = RGB(247, 247, 239)
        hoja.Cells(recorrido, 1).Font.Bold = True
        hoja.Cells(recorrido, 2).Font.Bold = True
        hoja.Cells(recorrido, 3).Font.Bold = True
        hoja.Cells(recorrido, 4).Font.Bold = True
        hoja.Cells(recorrido, 5).Font.Bold = True
        hoja.Cells(recorrido, 6).Font.Bold = True
        hoja.Cells(recorrido, 7).Font.Bold = True
        hoja.Cells(recorrido, 1).Font.Underline = True 'Pone subrrayado 
        hoja.Cells(recorrido, 2).Font.Underline = True 'Pone subrrayado 
        hoja.Cells(recorrido, 3).Font.Underline = True 'Pone subrrayado 
        hoja.Cells(recorrido, 4).Font.Underline = True 'Pone subrrayado 
        hoja.Cells(recorrido, 5).Font.Underline = True 'Pone subrrayado 
        hoja.Cells(recorrido, 6).Font.Underline = True 'Pone subrrayado 
        hoja.Cells(recorrido, 7).Font.Underline = True 'Pone subrrayado 
        objExcel.Visible = True
        conn.Close()
    End Sub

    Private Sub CmbProyecto_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbProyecto.SelectedIndexChanged

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