<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmGraficoTenores
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmGraficoTenores))
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
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.CmdGuardar = New System.Windows.Forms.Button()
        Me.Cmbubicacion = New System.Windows.Forms.ComboBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.DtFechaInicial = New System.Windows.Forms.DateTimePicker()
        Me.ChkMinimo = New System.Windows.Forms.CheckBox()
        Me.DtFechaFinal = New System.Windows.Forms.DateTimePicker()
        Me.ChkMAximo = New System.Windows.Forms.CheckBox()
        Me.ChkPromedio = New System.Windows.Forms.CheckBox()
        Me.ChkTenores = New System.Windows.Forms.CheckBox()
        Me.PbGrafico = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.lblminimo = New System.Windows.Forms.Label()
        Me.lblmaximo = New System.Windows.Forms.Label()
        Me.lbldesviacion = New System.Windows.Forms.Label()
        Me.lblmedia = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Lblubicacion = New System.Windows.Forms.Label()
        Me.lblX = New System.Windows.Forms.Label()
        Me.LblY = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.PbGrafico, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Lucida Calligraphy", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(362, 9)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(195, 27)
        Me.Label8.TabIndex = 62
        Me.Label8.Text = "Graficos Tenores"
        '
        'LblArea
        '
        Me.LblArea.AutoSize = True
        Me.LblArea.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblArea.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.LblArea.Location = New System.Drawing.Point(108, 42)
        Me.LblArea.Name = "LblArea"
        Me.LblArea.Size = New System.Drawing.Size(45, 13)
        Me.LblArea.TabIndex = 61
        Me.LblArea.Text = "Label6"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(15, 39)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(97, 16)
        Me.Label7.TabIndex = 60
        Me.Label7.Text = "Departamento:"
        '
        'LblUsuario
        '
        Me.LblUsuario.AutoSize = True
        Me.LblUsuario.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblUsuario.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.LblUsuario.Location = New System.Drawing.Point(108, 20)
        Me.LblUsuario.Name = "LblUsuario"
        Me.LblUsuario.Size = New System.Drawing.Size(45, 13)
        Me.LblUsuario.TabIndex = 59
        Me.LblUsuario.Text = "Label5"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(19, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(64, 18)
        Me.Label3.TabIndex = 58
        Me.Label3.Text = "Usuario:"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.PictureBox2)
        Me.GroupBox2.Controls.Add(Me.CmbMaximo)
        Me.GroupBox2.Controls.Add(Me.cmbdesviacion)
        Me.GroupBox2.Controls.Add(Me.cmbmedia)
        Me.GroupBox2.Controls.Add(Me.CmbMinimo)
        Me.GroupBox2.Controls.Add(Me.LblArea)
        Me.GroupBox2.Controls.Add(Me.LblUsuario)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Location = New System.Drawing.Point(14, 34)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(1075, 70)
        Me.GroupBox2.TabIndex = 63
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Datos de Usuario:"
        '
        'CmbMaximo
        '
        Me.CmbMaximo.Enabled = False
        Me.CmbMaximo.FormattingEnabled = True
        Me.CmbMaximo.Location = New System.Drawing.Point(955, 34)
        Me.CmbMaximo.Name = "CmbMaximo"
        Me.CmbMaximo.Size = New System.Drawing.Size(48, 21)
        Me.CmbMaximo.TabIndex = 71
        '
        'cmbdesviacion
        '
        Me.cmbdesviacion.Enabled = False
        Me.cmbdesviacion.FormattingEnabled = True
        Me.cmbdesviacion.Location = New System.Drawing.Point(955, 24)
        Me.cmbdesviacion.Name = "cmbdesviacion"
        Me.cmbdesviacion.Size = New System.Drawing.Size(48, 21)
        Me.cmbdesviacion.TabIndex = 66
        '
        'cmbmedia
        '
        Me.cmbmedia.Enabled = False
        Me.cmbmedia.FormattingEnabled = True
        Me.cmbmedia.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.cmbmedia.Location = New System.Drawing.Point(905, 34)
        Me.cmbmedia.Margin = New System.Windows.Forms.Padding(0)
        Me.cmbmedia.Name = "cmbmedia"
        Me.cmbmedia.Size = New System.Drawing.Size(48, 21)
        Me.cmbmedia.TabIndex = 64
        '
        'CmbMinimo
        '
        Me.CmbMinimo.Enabled = False
        Me.CmbMinimo.FormattingEnabled = True
        Me.CmbMinimo.Location = New System.Drawing.Point(879, 34)
        Me.CmbMinimo.Name = "CmbMinimo"
        Me.CmbMinimo.Size = New System.Drawing.Size(48, 21)
        Me.CmbMinimo.TabIndex = 65
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.GroupBox3)
        Me.GroupBox1.Controls.Add(Me.PbGrafico)
        Me.GroupBox1.Location = New System.Drawing.Point(9, 110)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.GroupBox1.Size = New System.Drawing.Size(1096, 473)
        Me.GroupBox1.TabIndex = 67
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "GbGraficas"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.CmdGuardar)
        Me.GroupBox3.Controls.Add(Me.Cmbubicacion)
        Me.GroupBox3.Controls.Add(Me.Button1)
        Me.GroupBox3.Controls.Add(Me.DtFechaInicial)
        Me.GroupBox3.Controls.Add(Me.ChkMinimo)
        Me.GroupBox3.Controls.Add(Me.DtFechaFinal)
        Me.GroupBox3.Controls.Add(Me.ChkMAximo)
        Me.GroupBox3.Controls.Add(Me.ChkPromedio)
        Me.GroupBox3.Controls.Add(Me.ChkTenores)
        Me.GroupBox3.Location = New System.Drawing.Point(872, 18)
        Me.GroupBox3.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Padding = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.GroupBox3.Size = New System.Drawing.Size(208, 287)
        Me.GroupBox3.TabIndex = 0
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Visualizar"
        '
        'CmdGuardar
        '
        Me.CmdGuardar.BackgroundImage = Global.Z_Lab.My.Resources.Resources.Save_Icon_icon_icons_com_69139
        Me.CmdGuardar.Location = New System.Drawing.Point(118, 241)
        Me.CmdGuardar.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.CmdGuardar.Name = "CmdGuardar"
        Me.CmdGuardar.Size = New System.Drawing.Size(64, 28)
        Me.CmdGuardar.TabIndex = 72
        Me.CmdGuardar.Text = "Guardar"
        Me.CmdGuardar.UseVisualStyleBackColor = True
        '
        'Cmbubicacion
        '
        Me.Cmbubicacion.FormattingEnabled = True
        Me.Cmbubicacion.Items.AddRange(New Object() {"Banda12", "Colas Bulk", "Colas Cianuracion_Solido", "Colas Cianuracion_Solucion", "Cabeza Merril Crowe", "Cola Merril Crowe", "Cabeza Agitadores_solido", "Descarga Agitador4_Solido", "Cabeza Agitadores_Solucion", "Descarga Agitador4_Solucion", "Concentrado_Flotacion", "Rebalse_Ciclon", "Toneladas_Banda12"})
        Me.Cmbubicacion.Location = New System.Drawing.Point(16, 152)
        Me.Cmbubicacion.Name = "Cmbubicacion"
        Me.Cmbubicacion.Size = New System.Drawing.Size(176, 21)
        Me.Cmbubicacion.TabIndex = 71
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(16, 241)
        Me.Button1.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(65, 28)
        Me.Button1.TabIndex = 65
        Me.Button1.Text = "Consultar"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'DtFechaInicial
        '
        Me.DtFechaInicial.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtFechaInicial.Location = New System.Drawing.Point(16, 179)
        Me.DtFechaInicial.Name = "DtFechaInicial"
        Me.DtFechaInicial.Size = New System.Drawing.Size(176, 20)
        Me.DtFechaInicial.TabIndex = 69
        '
        'ChkMinimo
        '
        Me.ChkMinimo.AutoSize = True
        Me.ChkMinimo.Location = New System.Drawing.Point(16, 118)
        Me.ChkMinimo.Name = "ChkMinimo"
        Me.ChkMinimo.Size = New System.Drawing.Size(90, 17)
        Me.ChkMinimo.TabIndex = 64
        Me.ChkMinimo.Text = "Tenor Minimo"
        Me.ChkMinimo.UseVisualStyleBackColor = True
        Me.ChkMinimo.Visible = False
        '
        'DtFechaFinal
        '
        Me.DtFechaFinal.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtFechaFinal.Location = New System.Drawing.Point(16, 205)
        Me.DtFechaFinal.Name = "DtFechaFinal"
        Me.DtFechaFinal.Size = New System.Drawing.Size(176, 20)
        Me.DtFechaFinal.TabIndex = 70
        '
        'ChkMAximo
        '
        Me.ChkMAximo.AutoSize = True
        Me.ChkMAximo.Location = New System.Drawing.Point(16, 84)
        Me.ChkMAximo.Name = "ChkMAximo"
        Me.ChkMAximo.Size = New System.Drawing.Size(93, 17)
        Me.ChkMAximo.TabIndex = 63
        Me.ChkMAximo.Text = "Tenor Maximo"
        Me.ChkMAximo.UseVisualStyleBackColor = True
        Me.ChkMAximo.Visible = False
        '
        'ChkPromedio
        '
        Me.ChkPromedio.AutoSize = True
        Me.ChkPromedio.Location = New System.Drawing.Point(16, 52)
        Me.ChkPromedio.Name = "ChkPromedio"
        Me.ChkPromedio.Size = New System.Drawing.Size(101, 17)
        Me.ChkPromedio.TabIndex = 62
        Me.ChkPromedio.Text = "Tenor Promedio"
        Me.ChkPromedio.UseVisualStyleBackColor = True
        '
        'ChkTenores
        '
        Me.ChkTenores.AutoSize = True
        Me.ChkTenores.Location = New System.Drawing.Point(16, 23)
        Me.ChkTenores.Name = "ChkTenores"
        Me.ChkTenores.Size = New System.Drawing.Size(65, 17)
        Me.ChkTenores.TabIndex = 53
        Me.ChkTenores.Text = "Tenores"
        Me.ChkTenores.UseVisualStyleBackColor = True
        '
        'PbGrafico
        '
        ChartArea1.Name = "ChartArea1"
        Me.PbGrafico.ChartAreas.Add(ChartArea1)
        Legend1.Name = "Legend1"
        Me.PbGrafico.Legends.Add(Legend1)
        Me.PbGrafico.Location = New System.Drawing.Point(5, 18)
        Me.PbGrafico.Name = "PbGrafico"
        Me.PbGrafico.Size = New System.Drawing.Size(854, 449)
        Me.PbGrafico.TabIndex = 59
        Me.PbGrafico.Text = "Graphics"
        '
        'lblminimo
        '
        Me.lblminimo.AutoSize = True
        Me.lblminimo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblminimo.Location = New System.Drawing.Point(766, 15)
        Me.lblminimo.Name = "lblminimo"
        Me.lblminimo.Size = New System.Drawing.Size(31, 13)
        Me.lblminimo.TabIndex = 61
        Me.lblminimo.Text = "------"
        '
        'lblmaximo
        '
        Me.lblmaximo.AutoSize = True
        Me.lblmaximo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblmaximo.Location = New System.Drawing.Point(610, 15)
        Me.lblmaximo.Name = "lblmaximo"
        Me.lblmaximo.Size = New System.Drawing.Size(31, 13)
        Me.lblmaximo.TabIndex = 60
        Me.lblmaximo.Text = "------"
        '
        'lbldesviacion
        '
        Me.lbldesviacion.AutoSize = True
        Me.lbldesviacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbldesviacion.Location = New System.Drawing.Point(470, 15)
        Me.lbldesviacion.Name = "lbldesviacion"
        Me.lbldesviacion.Size = New System.Drawing.Size(31, 13)
        Me.lbldesviacion.TabIndex = 59
        Me.lbldesviacion.Text = "------"
        '
        'lblmedia
        '
        Me.lblmedia.AutoSize = True
        Me.lblmedia.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblmedia.Location = New System.Drawing.Point(328, 15)
        Me.lblmedia.Name = "lblmedia"
        Me.lblmedia.Size = New System.Drawing.Size(31, 13)
        Me.lblmedia.TabIndex = 58
        Me.lblmedia.Text = "------"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label6.Location = New System.Drawing.Point(669, 15)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(87, 13)
        Me.Label6.TabIndex = 57
        Me.Label6.Text = "Desv. Minima:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label5.Location = New System.Drawing.Point(280, 15)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(45, 13)
        Me.Label5.TabIndex = 56
        Me.Label5.Text = "Media:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label1.Location = New System.Drawing.Point(520, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(90, 13)
        Me.Label1.TabIndex = 55
        Me.Label1.Text = "Desv. Maxima:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label2.Location = New System.Drawing.Point(394, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(74, 13)
        Me.Label2.TabIndex = 54
        Me.Label2.Text = "Desviacion:"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.Label4)
        Me.GroupBox4.Controls.Add(Me.Lblubicacion)
        Me.GroupBox4.Controls.Add(Me.Label5)
        Me.GroupBox4.Controls.Add(Me.lblmedia)
        Me.GroupBox4.Controls.Add(Me.Label2)
        Me.GroupBox4.Controls.Add(Me.lblminimo)
        Me.GroupBox4.Controls.Add(Me.lbldesviacion)
        Me.GroupBox4.Controls.Add(Me.Label6)
        Me.GroupBox4.Controls.Add(Me.lblmaximo)
        Me.GroupBox4.Controls.Add(Me.Label1)
        Me.GroupBox4.Location = New System.Drawing.Point(9, 585)
        Me.GroupBox4.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Padding = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.GroupBox4.Size = New System.Drawing.Size(994, 45)
        Me.GroupBox4.TabIndex = 68
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Indicadores"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label4.Location = New System.Drawing.Point(123, 14)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(60, 13)
        Me.Label4.TabIndex = 73
        Me.Label4.Text = "Location:"
        '
        'Lblubicacion
        '
        Me.Lblubicacion.AutoSize = True
        Me.Lblubicacion.Location = New System.Drawing.Point(187, 15)
        Me.Lblubicacion.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Lblubicacion.Name = "Lblubicacion"
        Me.Lblubicacion.Size = New System.Drawing.Size(25, 13)
        Me.Lblubicacion.TabIndex = 72
        Me.Lblubicacion.Text = "------"
        '
        'lblX
        '
        Me.lblX.AutoSize = True
        Me.lblX.Location = New System.Drawing.Point(878, 18)
        Me.lblX.Name = "lblX"
        Me.lblX.Size = New System.Drawing.Size(39, 13)
        Me.lblX.TabIndex = 70
        Me.lblX.Text = "Label6"
        Me.lblX.Visible = False
        '
        'LblY
        '
        Me.LblY.AutoSize = True
        Me.LblY.Location = New System.Drawing.Point(785, 18)
        Me.LblY.Name = "LblY"
        Me.LblY.Size = New System.Drawing.Size(39, 13)
        Me.LblY.TabIndex = 69
        Me.LblY.Text = "Label6"
        Me.LblY.Visible = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = Global.Z_Lab.My.Resources.Resources.LogoGranColombiaGoldSmall
        Me.PictureBox2.Location = New System.Drawing.Point(852, 13)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(207, 50)
        Me.PictureBox2.TabIndex = 57
        Me.PictureBox2.TabStop = False
        '
        'FrmGraficoTenores
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightGoldenrodYellow
        Me.ClientSize = New System.Drawing.Size(1102, 643)
        Me.Controls.Add(Me.lblX)
        Me.Controls.Add(Me.LblY)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.GroupBox2)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Name = "FrmGraficoTenores"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Graficos Tenores Planta"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.PbGrafico, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents LblArea As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents LblUsuario As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents cmbdesviacion As System.Windows.Forms.ComboBox
    Friend WithEvents CmbMinimo As System.Windows.Forms.ComboBox
    Friend WithEvents cmbmedia As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents ChkMinimo As System.Windows.Forms.CheckBox
    Friend WithEvents ChkMAximo As System.Windows.Forms.CheckBox
    Friend WithEvents ChkPromedio As System.Windows.Forms.CheckBox
    Friend WithEvents lblminimo As System.Windows.Forms.Label
    Friend WithEvents lblmaximo As System.Windows.Forms.Label
    Friend WithEvents lbldesviacion As System.Windows.Forms.Label
    Friend WithEvents lblmedia As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ChkTenores As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Cmbubicacion As System.Windows.Forms.ComboBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents DtFechaInicial As System.Windows.Forms.DateTimePicker
    Friend WithEvents DtFechaFinal As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblX As System.Windows.Forms.Label
    Friend WithEvents LblY As System.Windows.Forms.Label
    Friend WithEvents CmbMaximo As System.Windows.Forms.ComboBox
    Friend WithEvents CursorY As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Lblubicacion As System.Windows.Forms.Label
    Friend WithEvents PbGrafico As System.Windows.Forms.DataVisualization.Charting.Chart
    Friend WithEvents CmdGuardar As System.Windows.Forms.Button
End Class
