Option Explicit On
Option Strict On
Imports System.Data
Imports System.Data.SqlClient
Imports Z_Lab.FrmPrincipal
Imports System.Text.RegularExpressions
Imports System.Windows.Forms

Public Class FrmDespacho

    Dim Cn As New SqlConnection("Server=mercurio\gcg;uid=sa;pwd=BdZandor123*;database=PlantaBeneficio")
    Private dt As DataTable
    Private dtenvios As DataTable
    Dim Da As New SqlDataAdapter
    Dim Cmd As New SqlCommand
    Dim Dataset As DataSet
    Dim cnStr As String
    Dim conn As New ADODB.Connection()
    Dim rsarea As New ADODB.Recordset()
    Dim rsmuestras As New ADODB.Recordset
    Dim rsdespachos As New ADODB.Recordset
    Dim rsdespachomuestras As New ADODB.Recordset
    Dim rstBusqueda As New ADODB.Recordset()
    Dim rstlabsumit As New ADODB.Recordset()
    Dim total_envios As Double
    Private Sub FrmDespacho_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.LblUsuario.Text = FrmPrincipal.LblUserName.Text
        cargararea()
        cargar_lista_ordenes()


    End Sub

    Private Sub cargararea()
        cnStr = "Provider=SQLNCLI10;Initial Catalog=PlantaBeneficio;Data Source=mercurio; User ID=sa;Password=BdZandor123*;"
        conn.Open(cnStr)
        rsarea = conn.Execute(" SELECT * FROM         usuario WHERE (IdUsusario = '" & (LblUsuario.Text) & "')         ")
        If rsarea.EOF = True Then
            Me.LblArea.Text = "NO"
        Else
            Me.LblArea.Text = CStr((rsarea.Fields("Area").Value))
        End If
        conn.Close()
    End Sub

    Private Sub cargar_Muestrasinicio()
        With Cmd
            .CommandType = CommandType.Text
            .CommandText = "SELECT   * FROM Muestras  WHERE fecha= '" & CDate(DtFecha.Text) & "'  ORDER BY Muestra "
            .Connection = Cn
        End With
        Da.SelectCommand = Cmd
        dt = New DataTable
        Da.Fill(dt)

        With CmbInicio
            .DataSource = dt
            .DisplayMember = "Muestra"
            .ValueMember = "Muestra"
            .SelectedValue = 0
            .Text = "Seleccione"
        End With


    End Sub


    Private Sub cargar_MuestrasFinal()
        With Cmd
            .CommandType = CommandType.Text
            .CommandText = "SELECT   * FROM Muestras WHERE fecha= '" & CDate(DtFecha.Text) & "' ORDER BY Muestra   "
            .Connection = Cn
        End With
        Da.SelectCommand = Cmd
        dt = New DataTable
        Da.Fill(dt)



        With CmbFinal
            .DataSource = dt
            .DisplayMember = "Muestra"
            .ValueMember = "Muestra"
            .SelectedValue = 0
            .Text = "Seleccione"
        End With


    End Sub

    Private Sub cargar_lista_ordenes()
        With Cmd
            .CommandType = CommandType.Text
            .CommandText = "SELECT        TOP (100) PERCENT IdDespacho, Fecha, Departamento, Usuario    FROM dbo.DespachoLab WHERE        Departamento = '" & (LblArea.Text) & "' ORDER BY Consec       "
            .Connection = Cn
        End With
        Da.SelectCommand = Cmd
        dtenvios = New DataTable
        Da.Fill(dtenvios)

        With cmbDespacho
            .DataSource = dtenvios
            .DisplayMember = "IdDespacho"
            .ValueMember = "IdDespacho"
            .SelectedValue = 0
            .Text = "Seleccione"
        End With

        total_envios = dtenvios.Rows.Count
    End Sub

    Private Sub cmbDespacho_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbDespacho.SelectedIndexChanged
        LblIdDespacho.Text = cmbDespacho.Text
        cargarDespacho()
        Llenar_DataGridViewDgSamplesDay()
    End Sub

    Private Sub Cmdagregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmdagregar.Click
        Dim sqlConnectiondb As New System.Data.SqlClient.SqlConnection("Server=mercurio\gcg;uid=sa;pwd=BdZandor123*;database=PlantaBeneficio")
        Dim cmd As New System.Data.SqlClient.SqlCommand
        cmd.CommandType = System.Data.CommandType.Text
        If cmbDespacho.Text = "Nuevo" Then
            Dim mc As MatchCollection = Regex.Matches(LblArea.Text, "\w+")
            Dim iniciales As String = String.Empty
            For Each m As Match In mc
                iniciales &= m.Value.ToUpper.Chars(0)
            Next
            ' consulta sql si editar es falso 
            cmd.CommandText = "INSERT INTO DespachoLab (  IdDespacho, Fecha, Departamento, Usuario) VALUES ( @IdDespacho , @Fecha, @Departamento , @Usuario)"
            cmd.Parameters.AddWithValue("@IdDespacho", iniciales + "-00" + CStr(total_envios + 1))
            ' MsgBox(iniciales + "-000" + CStr(total_envios + 1))
            LblIdDespacho.Text = iniciales + "-00" + CStr(total_envios + 1)
        Else
            'CONSULTA CUANDO EDITAR ES VERDADERO
            cmd.CommandText = "UPDATE  DespachoLab  SET     Fecha= @Fecha , Departamento = @Departamento , Usuario= @Usuario  WHERE IdDespacho= @IdDespacho   "
            cmd.Parameters.AddWithValue("@IdDespacho", Convert.ToString(cmbDespacho.Text))
            LblIdDespacho.Text = cmbDespacho.Text
        End If
        cmd.Parameters.AddWithValue("@Fecha", CDate(DtFecha.Text))
        cmd.Parameters.AddWithValue("@Departamento", Convert.ToString(LblArea.Text))
        cmd.Parameters.AddWithValue("@Usuario", Convert.ToString(LblUsuario.Text))
        cmd.Connection = sqlConnectiondb
        sqlConnectiondb.Open()
        cmd.ExecuteNonQuery()
        sqlConnectiondb.Close()

        ' cnStr = "Provider=SQLNCLI10;Initial Catalog=PlantaBeneficio;Data Source=mercurio; User ID=sa;Password=BdZandor123*;"
        ' conn.Open(cnStr)
        ' rsdespachomuestras = conn.Execute(" SELECT * FROM   DespachoMuestras WHERE (muestra >= '" & (CmbInicio.Text) & "')     AND (muestra <= '" & (CmbFinal.Text) & "')  AND (IdDespacho= '" & (LblIdDespacho.Text) & "')     ")
        ' If rsdespachomuestras.RecordCount = 0 Then

        ' conn.Close()


        '  Else
        'MsgBox("una de las muestras ya se encuentra en el despacho,  por favor revise")
        ' conn.Close()
        ' End If


        Despachar_Muestras()
        cargar_lista_ordenes()
        Llenar_DataGridViewDgSamplesDay()
        'Me.Refresh()
    End Sub















    Private Sub Despachar_Muestras()
        Try
            cnStr = "Provider=SQLNCLI10;Initial Catalog=PlantaBeneficio;Data Source=mercurio; User ID=sa;Password=BdZandor123*;"
            conn.Open(cnStr)
            rsmuestras = conn.Execute(" SELECT * FROM   muestras WHERE (muestra >= '" & (CmbInicio.Text) & "')     AND (muestra <= '" & (CmbFinal.Text) & "')     ")
            Do While Not rsmuestras.EOF
                Dim sqlConnectiondb As New System.Data.SqlClient.SqlConnection("Server=mercurio\gcg;uid=sa;pwd=BdZandor123*;database=PlantaBeneficio")
                Dim cmd As New System.Data.SqlClient.SqlCommand
                cmd.CommandType = System.Data.CommandType.Text
                cmd.CommandText = "INSERT INTO DespachoMuestras (  IdDespacho , Muestra, CodigoServicio , Elementos) VALUES ( @IdDespacho ,  @Muestra , @CodigoServicio , @Elementos)"
                cmd.Parameters.AddWithValue("@IdDespacho", LblIdDespacho.Text)
                cmd.Parameters.AddWithValue("@Muestra", CStr(rsmuestras.Fields("muestra").Value))
                If CStr(rsmuestras.Fields("TipoMuestra").Value) = "ORIGINAL" Then
                    cmd.Parameters.AddWithValue("@CodigoServicio", "PRP93 - GQ_H2O - FAG303 - AAS12C")
                    cmd.Parameters.AddWithValue("@Elementos", "Au , Ag")
                Else
                    cmd.Parameters.AddWithValue("@CodigoServicio", "LOG02 - SPL26 - PUL45 - FAG303")
                    cmd.Parameters.AddWithValue("@Elementos", "Au")
                End If
                cmd.Connection = sqlConnectiondb
                sqlConnectiondb.Open()
                cmd.ExecuteNonQuery()
                sqlConnectiondb.Close()
                rsmuestras.MoveNext()
            Loop
            conn.Close()
            MsgBox("OK")
        Catch ex As Exception
            conn.Close()
            ' Handle the exception.
            MessageBox.Show("Muestras Duplicadas", Me.Text, _
  MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Llenar_DataGridViewDgSamplesDay()
        Cn.Open()
        Dim ds As New DataSet
        Dim da As New SqlDataAdapter
        Dim sql As String
        sql = " SELECT        TOP (100) PERCENT IdDespacho, Muestra, Consec, CodigoServicio, Elementos   FROM DespachoMuestras  WHERE        IdDespacho = '" & (LblIdDespacho.Text) & "' ORDER BY Consec "
        da.SelectCommand = New SqlCommand(sql, Cn)
        da.Fill(ds)
        Cn.Close()
        Dim dt As DataTable = ds.Tables(0)
        DgMuestrasDespacho.DataSource = dt
        DgMuestrasDespacho.AutoResizeColumns()
        Me.DgMuestrasDespacho.Columns("IdDespacho").Visible = False
        DgMuestrasDespacho.Columns("Consec").Visible = False
        'DgMuestrasDespacho.Columns("IdDespacho").HeaderText = "Muestra"
        DgMuestrasDespacho.Columns("Muestra").HeaderText = "Muestra"
        ' DgMuestrasDespacho.Columns("Consec").HeaderText = "Hora Final"
        DgMuestrasDespacho.Columns("CodigoServicio").HeaderText = "Codigo de Servicio"
        DgMuestrasDespacho.Columns("Elementos").HeaderText = "Elementos"
        Me.DgMuestrasDespacho.ReadOnly = False
    End Sub

    Private Sub cargarDespacho()
        cnStr = "Provider=SQLNCLI10;Initial Catalog=PlantaBeneficio;Data Source=mercurio; User ID=sa;Password=BdZandor123*;"
        conn.Open(cnStr)
        rsdespachos = conn.Execute(" SELECT * FROM   DespachoLab WHERE (IdDespacho = '" & (LblIdDespacho.Text) & "')      ")
        If rsdespachos.EOF = True Then

        Else
            'DtFecha.Value = CDate(rsdespachos.Fields("Fecha").Value)
            LblFechaDespacho.Text = CStr(rsdespachos.Fields("Fecha").Value)
            If IsDBNull(rsdespachos.Fields("Comentarios").Value) Then
                TxtObservaciones.Text = ""
            Else
                TxtObservaciones.Text = CStr(rsdespachos.Fields("Comentarios").Value)
            End If

        End If

        conn.Close()

    End Sub

    Private Sub DtFecha_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DtFecha.ValueChanged

        cargar_MuestrasFinal()
        cargar_Muestrasinicio()

    End Sub

    Private Sub CmdBorrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdBorrar.Click
        If MsgBox("Esta Seguro Que Desea Eliminar Las Muestras del Despacho?", vbYesNo, "") = vbYes Then
            Dim sqlConnectiondb As New System.Data.SqlClient.SqlConnection("Server=mercurio\gcg;uid=sa;pwd=BdZandor123*;database=PlantaBeneficio")
            Dim cmd As New System.Data.SqlClient.SqlCommand
            cmd.CommandType = System.Data.CommandType.Text
            cmd.CommandText = "DELETE FROM DespachoMuestras    WHERE IdDespacho=  '" & LblIdDespacho.Text & "'  "
            cmd.Connection = sqlConnectiondb
            sqlConnectiondb.Open()
            cmd.ExecuteNonQuery()
            sqlConnectiondb.Close()
            Llenar_DataGridViewDgSamplesDay()
        End If

    End Sub

    Private Sub CmdExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdExport.Click
        Dim cnstr As String
        Dim contarmuestras As Integer
        contarmuestras = 0
        cnstr = "Provider=SQLNCLI10;Initial Catalog=PlantaBeneficio;Data Source=mercurio; User ID=sa;Password=BdZandor123*;"
        'mensaje de exportacion mientras se ejecuta el codigo
        Try
            conn.Open(cnstr)
            rstlabsumit = conn.Execute(" SELECT  * from DespachoMuestras WHERE IdDespacho=  '" & LblIdDespacho.Text & "' ")
            Dim objExcel As Microsoft.Office.Interop.Excel.Application
            objExcel = New Microsoft.Office.Interop.Excel.Application
            Dim hoja As Microsoft.Office.Interop.Excel.Worksheet
            objExcel.Workbooks.Open("\\athenea\pampaverde\mineria\Data\DataBase\Templates\PlantaBeneficio_140903_PeqMineria_JFP.xls")
            With objExcel
                hoja = CType(.Sheets("Despacho"), Microsoft.Office.Interop.Excel.Worksheet)
                ' hoja.Cells(8, 13) = rstlabsumit.Fields("Fecha").Value
                'hoja.Cells(7, 15) = rstlabsumit.Fields("IdDespacho").Value
                Dim recorrido As Integer

                recorrido = 43
                objExcel.Visible = False
                Dim parametromuestra As String
                Dim cantidad As Integer
                cantidad = DgMuestrasDespacho.RowCount
                If cantidad > 0 Then
                    For i As Integer = 0 To cantidad
                        hoja.Cells(recorrido, 1) = "1"
                        objExcel.ActiveCell.Offset().EntireRow.Insert()
                    Next


                End If
                For Each dRow As DataGridViewRow In DgMuestrasDespacho.Rows

                    parametromuestra = CStr(dRow.Cells.Item("Muestra").Value)
                    ' obtener con el recordset el plan mensual de cada frente de trabajo
                    If parametromuestra IsNot Nothing Then
                        hoja.Cells(recorrido, 1) = "1"
                        hoja.Cells(recorrido, 2) = dRow.Cells.Item("Muestra").Value
                        'hoja.Cells(recorrido, 7) = "ROCAS"
                        hoja.Cells(recorrido, 14) = dRow.Cells.Item("CodigoServicio").Value
                        hoja.Cells(recorrido, 13) = dRow.Cells.Item("Elementos").Value
                        hoja.Cells(recorrido, 17) = "X"
                        'objExcel.ActiveCell.Insert(42, 44)
                        'objExcel.ActiveCell.Offset().EntireRow.Insert()
                        ' objExcel.ActiveCell.Offset(recorrido + 2).EntireRow.Insert(recorrido + 2)


                    End If
                    recorrido = recorrido + 1
                Next dRow

                'LblExport.Visible = False
                rstlabsumit.Close()
                conn.Close()
                objExcel.Visible = True
            End With
        Catch ex As Exception
            ' Handle the exception.
            MessageBox.Show(ex.Message, Me.Text, _
  MessageBoxButtons.OK, MessageBoxIcon.Error)
            rstlabsumit.Close()
            conn.Close()
        End Try
    End Sub
End Class