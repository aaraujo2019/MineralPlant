<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmGraficoMineras
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend1 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmGraficoMineras))
        Me.lblX = New System.Windows.Forms.Label()
        Me.LblY = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.LblArea = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.LblUsuario = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.CmbMaximo = New System.Windows.Forms.ComboBox()
        Me.cmbdesviacion = New System.Windows.Forms.ComboBox()
        Me.cmbmedia = New System.Windows.Forms.ComboBox()
        Me.CmbMinimo = New System.Windows.Forms.ComboBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.ChkDetalleTenor = New System.Windows.Forms.CheckBox()
        Me.Cmbmina = New System.Windows.Forms.ComboBox()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.DtFechaInicial = New System.Windows.Forms.DateTimePicker()
        Me.ChkMaximo = New System.Windows.Forms.CheckBox()
        Me.DtFechaFinal = New System.Windows.Forms.DateTimePicker()
        Me.ChkMinimo = New System.Windows.Forms.CheckBox()
        Me.ChkPromedio = New System.Windows.Forms.CheckBox()
        Me.Chktenores = New System.Windows.Forms.CheckBox()
        Me.PbGrafico = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Lblubicacion = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblmedia = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblminimo = New System.Windows.Forms.Label()
        Me.lbldesviacion = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lblmaximo = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.PbGrafico, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox5.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblX
        '
        Me.lblX.AutoSize = True
        Me.lblX.Location = New System.Drawing.Point(1129, 16)
        Me.lblX.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblX.Name = "lblX"
        Me.lblX.Size = New System.Drawing.Size(51, 17)
        Me.lblX.TabIndex = 79
        Me.lblX.Text = "Label6"
        Me.lblX.Visible = False
        '
        'LblY
        '
        Me.LblY.AutoSize = True
        Me.LblY.Location = New System.Drawing.Point(1006, 16)
        Me.LblY.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblY.Name = "LblY"
        Me.LblY.Size = New System.Drawing.Size(51, 17)
        Me.LblY.TabIndex = 78
        Me.LblY.Text = "Label6"
        Me.LblY.Visible = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Lucida Calligraphy", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(341, 3)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(339, 36)
        Me.Label8.TabIndex = 76
        Me.Label8.Text = "Grafico Tenores Minas"
        '
        'LblArea
        '
        Me.LblArea.AutoSize = True
        Me.LblArea.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblArea.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.LblArea.Location = New System.Drawing.Point(344, 88)
        Me.LblArea.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblArea.Name = "LblArea"
        Me.LblArea.Size = New System.Drawing.Size(57, 17)
        Me.LblArea.TabIndex = 75
        Me.LblArea.Text = "Label6"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(153, 88)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(102, 17)
        Me.Label7.TabIndex = 74
        Me.Label7.Text = "Departamento:"
        '
        'LblUsuario
        '
        Me.LblUsuario.AutoSize = True
        Me.LblUsuario.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblUsuario.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.LblUsuario.Location = New System.Drawing.Point(344, 56)
        Me.LblUsuario.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblUsuario.Name = "LblUsuario"
        Me.LblUsuario.Size = New System.Drawing.Size(57, 17)
        Me.LblUsuario.TabIndex = 73
        Me.LblUsuario.Text = "Label5"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(153, 56)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(80, 17)
        Me.Label3.TabIndex = 72
        Me.Label3.Text = "Id. Usuario:"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.CmbMaximo)
        Me.GroupBox2.Controls.Add(Me.cmbdesviacion)
        Me.GroupBox2.Controls.Add(Me.cmbmedia)
        Me.GroupBox2.Controls.Add(Me.CmbMinimo)
        Me.GroupBox2.Location = New System.Drawing.Point(53, 43)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Size = New System.Drawing.Size(1184, 79)
        Me.GroupBox2.TabIndex = 77
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Datos de Usuario:"
        '
        'CmbMaximo
        '
        Me.CmbMaximo.Enabled = False
        Me.CmbMaximo.FormattingEnabled = True
        Me.CmbMaximo.Location = New System.Drawing.Point(813, 23)
        Me.CmbMaximo.Margin = New System.Windows.Forms.Padding(4)
        Me.CmbMaximo.Name = "CmbMaximo"
        Me.CmbMaximo.Size = New System.Drawing.Size(63, 24)
        Me.CmbMaximo.TabIndex = 71
        '
        'cmbdesviacion
        '
        Me.cmbdesviacion.Enabled = False
        Me.cmbdesviacion.FormattingEnabled = True
        Me.cmbdesviacion.Location = New System.Drawing.Point(813, 11)
        Me.cmbdesviacion.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbdesviacion.Name = "cmbdesviacion"
        Me.cmbdesviacion.Size = New System.Drawing.Size(63, 24)
        Me.cmbdesviacion.TabIndex = 66
        '
        'cmbmedia
        '
        Me.cmbmedia.Enabled = False
        Me.cmbmedia.FormattingEnabled = True
        Me.cmbmedia.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.cmbmedia.Location = New System.Drawing.Point(746, 23)
        Me.cmbmedia.Margin = New System.Windows.Forms.Padding(0)
        Me.cmbmedia.Name = "cmbmedia"
        Me.cmbmedia.Size = New System.Drawing.Size(63, 24)
        Me.cmbmedia.TabIndex = 64
        '
        'CmbMinimo
        '
        Me.CmbMinimo.Enabled = False
        Me.CmbMinimo.FormattingEnabled = True
        Me.CmbMinimo.Location = New System.Drawing.Point(712, 23)
        Me.CmbMinimo.Margin = New System.Windows.Forms.Padding(4)
        Me.CmbMinimo.Name = "CmbMinimo"
        Me.CmbMinimo.Size = New System.Drawing.Size(63, 24)
        Me.CmbMinimo.TabIndex = 65
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.GroupBox4)
        Me.GroupBox1.Controls.Add(Me.PbGrafico)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 129)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1461, 582)
        Me.GroupBox1.TabIndex = 81
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "GbGraficas"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.ChkDetalleTenor)
        Me.GroupBox4.Controls.Add(Me.Button2)
        Me.GroupBox4.Controls.Add(Me.Cmbmina)
        Me.GroupBox4.Controls.Add(Me.Button3)
        Me.GroupBox4.Controls.Add(Me.DtFechaInicial)
        Me.GroupBox4.Controls.Add(Me.ChkMaximo)
        Me.GroupBox4.Controls.Add(Me.DtFechaFinal)
        Me.GroupBox4.Controls.Add(Me.ChkMinimo)
        Me.GroupBox4.Controls.Add(Me.ChkPromedio)
        Me.GroupBox4.Controls.Add(Me.Chktenores)
        Me.GroupBox4.Location = New System.Drawing.Point(1161, 22)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(279, 418)
        Me.GroupBox4.TabIndex = 0
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Visualizar"
        '
        'ChkDetalleTenor
        '
        Me.ChkDetalleTenor.AutoSize = True
        Me.ChkDetalleTenor.Location = New System.Drawing.Point(7, 119)
        Me.ChkDetalleTenor.Name = "ChkDetalleTenor"
        Me.ChkDetalleTenor.Size = New System.Drawing.Size(154, 21)
        Me.ChkDetalleTenor.TabIndex = 73
        Me.ChkDetalleTenor.Text = "Detallado - Muestra"
        Me.ChkDetalleTenor.UseVisualStyleBackColor = True
        '
        'Cmbmina
        '
        Me.Cmbmina.FormattingEnabled = True
        Me.Cmbmina.Items.AddRange(New Object() {"Banda12", "Colas Bulk", "Colas Cianuracion_Solido", "Colas Cianuracion_Solucion", "Cabeza Merril Crowe", "Cola Merril Crowe", "Cabeza Agitadores_solido", "Descarga Agitador4_Solido", "Cabeza Agitadores_Solucion", "Descarga Agitador4_Solucion"})
        Me.Cmbmina.Location = New System.Drawing.Point(9, 237)
        Me.Cmbmina.Margin = New System.Windows.Forms.Padding(4)
        Me.Cmbmina.Name = "Cmbmina"
        Me.Cmbmina.Size = New System.Drawing.Size(233, 24)
        Me.Cmbmina.TabIndex = 71
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(15, 345)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(75, 23)
        Me.Button3.TabIndex = 65
        Me.Button3.Text = "Consultar"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'DtFechaInicial
        '
        Me.DtFechaInicial.Location = New System.Drawing.Point(9, 269)
        Me.DtFechaInicial.Margin = New System.Windows.Forms.Padding(4)
        Me.DtFechaInicial.Name = "DtFechaInicial"
        Me.DtFechaInicial.Size = New System.Drawing.Size(233, 22)
        Me.DtFechaInicial.TabIndex = 69
        '
        'ChkMaximo
        '
        Me.ChkMaximo.AutoSize = True
        Me.ChkMaximo.Location = New System.Drawing.Point(7, 193)
        Me.ChkMaximo.Margin = New System.Windows.Forms.Padding(4)
        Me.ChkMaximo.Name = "ChkMaximo"
        Me.ChkMaximo.Size = New System.Drawing.Size(116, 21)
        Me.ChkMaximo.TabIndex = 64
        Me.ChkMaximo.Text = "Tenor Minimo"
        Me.ChkMaximo.UseVisualStyleBackColor = True
        Me.ChkMaximo.Visible = False
        '
        'DtFechaFinal
        '
        Me.DtFechaFinal.Location = New System.Drawing.Point(9, 299)
        Me.DtFechaFinal.Margin = New System.Windows.Forms.Padding(4)
        Me.DtFechaFinal.Name = "DtFechaFinal"
        Me.DtFechaFinal.Size = New System.Drawing.Size(233, 22)
        Me.DtFechaFinal.TabIndex = 70
        '
        'ChkMinimo
        '
        Me.ChkMinimo.AutoSize = True
        Me.ChkMinimo.Location = New System.Drawing.Point(7, 164)
        Me.ChkMinimo.Margin = New System.Windows.Forms.Padding(4)
        Me.ChkMinimo.Name = "ChkMinimo"
        Me.ChkMinimo.Size = New System.Drawing.Size(119, 21)
        Me.ChkMinimo.TabIndex = 63
        Me.ChkMinimo.Text = "Tenor Maximo"
        Me.ChkMinimo.UseVisualStyleBackColor = True
        Me.ChkMinimo.Visible = False
        '
        'ChkPromedio
        '
        Me.ChkPromedio.AutoSize = True
        Me.ChkPromedio.Location = New System.Drawing.Point(7, 91)
        Me.ChkPromedio.Margin = New System.Windows.Forms.Padding(4)
        Me.ChkPromedio.Name = "ChkPromedio"
        Me.ChkPromedio.Size = New System.Drawing.Size(132, 21)
        Me.ChkPromedio.TabIndex = 62
        Me.ChkPromedio.Text = "Tenor Promedio"
        Me.ChkPromedio.UseVisualStyleBackColor = True
        '
        'Chktenores
        '
        Me.Chktenores.AutoSize = True
        Me.Chktenores.Location = New System.Drawing.Point(7, 55)
        Me.Chktenores.Margin = New System.Windows.Forms.Padding(4)
        Me.Chktenores.Name = "Chktenores"
        Me.Chktenores.Size = New System.Drawing.Size(83, 21)
        Me.Chktenores.TabIndex = 53
        Me.Chktenores.Text = "Tenores"
        Me.Chktenores.UseVisualStyleBackColor = True
        '
        'PbGrafico
        '
        ChartArea1.Name = "ChartArea1"
        Me.PbGrafico.ChartAreas.Add(ChartArea1)
        Legend1.Name = "Legend1"
        Me.PbGrafico.Legends.Add(Legend1)
        Me.PbGrafico.Location = New System.Drawing.Point(7, 22)
        Me.PbGrafico.Margin = New System.Windows.Forms.Padding(4)
        Me.PbGrafico.Name = "PbGrafico"
        Me.PbGrafico.Size = New System.Drawing.Size(1113, 553)
        Me.PbGrafico.TabIndex = 59
        Me.PbGrafico.Text = "Graphics"
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.Label4)
        Me.GroupBox5.Controls.Add(Me.Lblubicacion)
        Me.GroupBox5.Controls.Add(Me.Label5)
        Me.GroupBox5.Controls.Add(Me.lblmedia)
        Me.GroupBox5.Controls.Add(Me.Label2)
        Me.GroupBox5.Controls.Add(Me.lblminimo)
        Me.GroupBox5.Controls.Add(Me.lbldesviacion)
        Me.GroupBox5.Controls.Add(Me.Label6)
        Me.GroupBox5.Controls.Add(Me.lblmaximo)
        Me.GroupBox5.Controls.Add(Me.Label1)
        Me.GroupBox5.Location = New System.Drawing.Point(12, 717)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(1325, 55)
        Me.GroupBox5.TabIndex = 82
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Indicadores"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label4.Location = New System.Drawing.Point(164, 17)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(75, 17)
        Me.Label4.TabIndex = 73
        Me.Label4.Text = "Location:"
        '
        'Lblubicacion
        '
        Me.Lblubicacion.AutoSize = True
        Me.Lblubicacion.Location = New System.Drawing.Point(249, 18)
        Me.Lblubicacion.Name = "Lblubicacion"
        Me.Lblubicacion.Size = New System.Drawing.Size(38, 17)
        Me.Lblubicacion.TabIndex = 72
        Me.Lblubicacion.Text = "------"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label5.Location = New System.Drawing.Point(373, 18)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(56, 17)
        Me.Label5.TabIndex = 56
        Me.Label5.Text = "Media:"
        '
        'lblmedia
        '
        Me.lblmedia.AutoSize = True
        Me.lblmedia.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblmedia.Location = New System.Drawing.Point(437, 18)
        Me.lblmedia.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblmedia.Name = "lblmedia"
        Me.lblmedia.Size = New System.Drawing.Size(44, 17)
        Me.lblmedia.TabIndex = 58
        Me.lblmedia.Text = "------"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label2.Location = New System.Drawing.Point(526, 18)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(92, 17)
        Me.Label2.TabIndex = 54
        Me.Label2.Text = "Desviacion:"
        '
        'lblminimo
        '
        Me.lblminimo.AutoSize = True
        Me.lblminimo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblminimo.Location = New System.Drawing.Point(1021, 18)
        Me.lblminimo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblminimo.Name = "lblminimo"
        Me.lblminimo.Size = New System.Drawing.Size(44, 17)
        Me.lblminimo.TabIndex = 61
        Me.lblminimo.Text = "------"
        '
        'lbldesviacion
        '
        Me.lbldesviacion.AutoSize = True
        Me.lbldesviacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbldesviacion.Location = New System.Drawing.Point(626, 18)
        Me.lbldesviacion.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbldesviacion.Name = "lbldesviacion"
        Me.lbldesviacion.Size = New System.Drawing.Size(44, 17)
        Me.lbldesviacion.TabIndex = 59
        Me.lbldesviacion.Text = "------"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label6.Location = New System.Drawing.Point(892, 18)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(109, 17)
        Me.Label6.TabIndex = 57
        Me.Label6.Text = "Desv. Minima:"
        '
        'lblmaximo
        '
        Me.lblmaximo.AutoSize = True
        Me.lblmaximo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblmaximo.Location = New System.Drawing.Point(813, 18)
        Me.lblmaximo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblmaximo.Name = "lblmaximo"
        Me.lblmaximo.Size = New System.Drawing.Size(44, 17)
        Me.lblmaximo.TabIndex = 60
        Me.lblmaximo.Text = "------"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label1.Location = New System.Drawing.Point(693, 18)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(112, 17)
        Me.Label1.TabIndex = 55
        Me.Label1.Text = "Desv. Maxima:"
        '
        'Button2
        '
        Me.Button2.BackgroundImage = Global.Z_Lab.My.Resources.Resources.Save_Icon_icon_icons_com_69139
        Me.Button2.Location = New System.Drawing.Point(130, 345)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(72, 23)
        Me.Button2.TabIndex = 72
        Me.Button2.Text = "Guardar"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = Global.Z_Lab.My.Resources.Resources.LogoGranColombiaGoldSmall
        Me.PictureBox2.Location = New System.Drawing.Point(733, 49)
        Me.PictureBox2.Margin = New System.Windows.Forms.Padding(4)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(276, 62)
        Me.PictureBox2.TabIndex = 71
        Me.PictureBox2.TabStop = False
        '
        'FrmGraficoMineras
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightGoldenrodYellow
        Me.ClientSize = New System.Drawing.Size(1469, 784)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.lblX)
        Me.Controls.Add(Me.LblY)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.LblArea)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.LblUsuario)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.GroupBox2)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmGraficoMineras"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Grafico tenor de Minas"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me.PbGrafico, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblX As System.Windows.Forms.Label
    Friend WithEvents LblY As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents LblArea As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents LblUsuario As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents CmbMaximo As System.Windows.Forms.ComboBox
    Friend WithEvents cmbdesviacion As System.Windows.Forms.ComboBox
    Friend WithEvents cmbmedia As System.Windows.Forms.ComboBox
    Friend WithEvents CmbMinimo As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Cmbmina As System.Windows.Forms.ComboBox
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents DtFechaInicial As System.Windows.Forms.DateTimePicker
    Friend WithEvents ChkMaximo As System.Windows.Forms.CheckBox
    Friend WithEvents DtFechaFinal As System.Windows.Forms.DateTimePicker
    Friend WithEvents ChkMinimo As System.Windows.Forms.CheckBox
    Friend WithEvents ChkPromedio As System.Windows.Forms.CheckBox
    Friend WithEvents Chktenores As System.Windows.Forms.CheckBox
    Friend WithEvents PbGrafico As System.Windows.Forms.DataVisualization.Charting.Chart
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Lblubicacion As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblmedia As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblminimo As System.Windows.Forms.Label
    Friend WithEvents lbldesviacion As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lblmaximo As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ChkDetalleTenor As System.Windows.Forms.CheckBox
End Class
