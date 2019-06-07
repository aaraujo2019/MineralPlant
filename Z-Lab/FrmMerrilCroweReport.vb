Imports System.Windows.Forms
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration

Public Class FrmMerrilCroweReport
    Dim Cn As New SqlConnection(ConfigurationManager.AppSettings("StringConexion").ToString)
    Private dt As DataTable
    Dim Da As New SqlDataAdapter
    Dim Cmd As New SqlCommand
    Dim Dataset As DataSet
    Dim cnStr As String
    Dim rsarea As New ADODB.Recordset()
    Dim conn As New ADODB.Connection()
    Private Sub FrmMerrilCroweReport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub picturebox1_enfoque(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.MouseHover
        PictureBox1.BorderStyle = BorderStyle.FixedSingle
    End Sub
    Private Sub picturebox1_quitarenfoque(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.MouseLeave
        PictureBox1.BorderStyle = BorderStyle.None
    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click
        Dim totaltoneladas As Double
        Dim totalgramos As Double
        Dim conn As New ADODB.Connection()
        Dim RstResumen As New ADODB.Recordset()
        Dim cnStr As String
        cnStr = "Provider=SQLNCLI10;Initial Catalog=PlantaBeneficio;Data Source=SEGSVRSQL01; User ID=sa;Password=*Bd6r4nC0l0mb1a*;"
        conn.Open(cnStr)
        Dim objExcel As Microsoft.Office.Interop.Excel.Application
        objExcel = New Microsoft.Office.Interop.Excel.Application
        Dim hoja As Microsoft.Office.Interop.Excel.Worksheet
        objExcel.Workbooks.Open("\\athenea\pampaverde\mineria\Data\DataBase\Templates\GZC_MerrilCrowe.xlsx")
        Dim recorrido As Integer
        recorrido = 7
        totaltoneladas = 0
        totalgramos = 0
        objExcel.Visible = False
        RstResumen = conn.Execute("SELECT     TOP (100) PERCENT dbo.PB_MerrilCrowe.Fecha, SUM(dbo.PB_MerrilCrowe.Volumen) AS VolumenTotal, SUM(dbo.PB_MerrilCrowe.Onzas) AS OnzasTotal,  AVG(dbo.PB_MerrilCrowe.TenorCabeza) AS TenorPromedio, AVG(dbo.PB_MerrilCrowe.TenorCola) AS TenorColas FROM         dbo.PB_MerrilCrowe INNER JOIN     dbo.RfTime ON dbo.PB_MerrilCrowe.HoraInicial = dbo.RfTime.Hora GROUP BY dbo.PB_MerrilCrowe.Fecha    HAVING        (Fecha >= '" & CDate(DtFechainicio.Text) & "') AND (Fecha <= '" & CDate(DtFechaFinal.Text) & "')")
        With objExcel
            hoja = CType(.Sheets("MerrilCrowe"), Microsoft.Office.Interop.Excel.Worksheet)
            'hoja.Cells(1, 3) = RstResumen.Fields("Ubicacion").Value
            Do While Not RstResumen.EOF
                hoja.Cells(recorrido, 1) = RstResumen.Fields("Fecha").Value
                hoja.Cells(recorrido, 2) = RstResumen.Fields("VolumenTotal").Value
                hoja.Cells(recorrido, 3) = RstResumen.Fields("TenorPromedio").Value
                hoja.Cells(recorrido, 4) = RstResumen.Fields("TenorColas").Value
                'hoja.Cells(recorrido, 4) = CStr(CDbl(RstResumen.Fields("AlimentoGramos").Value) / 30.1034)
                'hoja.Cells(recorrido, 5) = RstResumen.Fields("TenorCola").Value
                hoja.Cells(recorrido, 5) = RstResumen.Fields("OnzasTotal").Value
                recorrido = recorrido + 1
                RstResumen.MoveNext()
            Loop
        End With
        objExcel.Visible = True
        conn.Close()
    End Sub
End Class