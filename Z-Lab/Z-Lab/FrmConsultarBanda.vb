Imports System.Windows.Forms
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration

Public Class FrmConsultarBanda
    Dim Cn As New SqlConnection(ConfigurationManager.AppSettings("StringConexion").ToString)
    Private dt As DataTable
    Dim Da As New SqlDataAdapter
    Dim Cmd As New SqlCommand
    Dim Dataset As DataSet
    Dim cnStr As String
    Dim rsarea As New ADODB.Recordset()
    Dim conn As New ADODB.Connection()
    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click
        Dim totaltoneladas As Double
        Dim totalgramos As Double
        Dim conn As New ADODB.Connection()
        Dim RstResumen As New ADODB.Recordset()
        Dim cnStr As String
        cnStr = ConfigurationManager.AppSettings("StringConexionODBC").ToString
        conn.Open(cnStr)
        Dim objExcel As Microsoft.Office.Interop.Excel.Application
        objExcel = New Microsoft.Office.Interop.Excel.Application
        Dim hoja As Microsoft.Office.Interop.Excel.Worksheet
        objExcel.Workbooks.Open("\\athenea\pampaverde\mineria\Data\DataBase\Templates\GZC_AlimentoMolienda.xlsx")
        Dim recorrido As Integer
        recorrido = 7
        totaltoneladas = 0
        totalgramos = 0
        objExcel.Visible = False
        RstResumen = conn.Execute("SELECT     Fecha, SUM(TonHumeda) AS ToneladasHumedas, SUM(TonSeca) AS ToneladaSecas, SUM(Onzas) AS TotalOnzas   FROM dbo.PB_Conveyor GROUP BY Fecha    HAVING    (Fecha >= '" & CDate(DtFechainicio.Text) & "') ")
        ' AND (Fecha <= '" & CDate(DtFechaFinal.Text) & "')
        With objExcel
            hoja = CType(.Sheets("AlimentoMolino"), Microsoft.Office.Interop.Excel.Worksheet)
            'hoja.Cells(1, 3) = RstResumen.Fields("Ubicacion").Value
            Do While Not RstResumen.EOF
                hoja.Cells(recorrido, 1) = RstResumen.Fields("Fecha").Value
                hoja.Cells(recorrido, 2) = RstResumen.Fields("ToneladasHumedas").Value
                hoja.Cells(recorrido, 3) = RstResumen.Fields("ToneladaSecas").Value
                If IsDBNull(RstResumen.Fields("TotalOnzas").Value) Then
                Else
                    hoja.Cells(recorrido, 4) = CStr((CDbl(RstResumen.Fields("TotalOnzas").Value) * 31.1035) / CDbl(RstResumen.Fields("ToneladaSecas").Value))
                End If

                'hoja.Cells(recorrido, 4) = CStr(CDbl(RstResumen.Fields("AlimentoGramos").Value) / 30.1034)
                'hoja.Cells(recorrido, 5) = RstResumen.Fields("TenorCola").Value
                hoja.Cells(recorrido, 5) = RstResumen.Fields("TotalOnzas").Value
                recorrido = recorrido + 1
                RstResumen.MoveNext()
            Loop
        End With
        objExcel.Visible = True
        conn.Close()
    End Sub

    Private Sub FrmConsultarBanda_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub picturebox1_enfoque(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.MouseHover
        PictureBox1.BorderStyle = BorderStyle.FixedSingle
    End Sub
    Private Sub picturebox1_quitarenfoque(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.MouseLeave
        PictureBox1.BorderStyle = BorderStyle.None
    End Sub
End Class