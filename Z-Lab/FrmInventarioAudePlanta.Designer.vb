<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmInventarioAudePlanta
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmInventarioAudePlanta))
        Me.Label8 = New System.Windows.Forms.Label()
        Me.LblArea = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.LblUsuario = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.CmbMaximo = New System.Windows.Forms.ComboBox()
        Me.cmbdesviacion = New System.Windows.Forms.ComboBox()
        Me.cmbmedia = New System.Windows.Forms.ComboBox()
        Me.CmbMinimo = New System.Windows.Forms.ComboBox()
        Me.CmbIdPeriodo = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Lbltotal = New System.Windows.Forms.Label()
        Me.LblSolucion = New System.Windows.Forms.Label()
        Me.LblSolido = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtausolucion = New System.Windows.Forms.TextBox()
        Me.txtausolido = New System.Windows.Forms.TextBox()
        Me.Lblid = New System.Windows.Forms.Label()
        Me.CmdGuardar = New System.Windows.Forms.Button()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.TxtAlturaLodos = New System.Windows.Forms.TextBox()
        Me.txtAlturaSuperior = New System.Windows.Forms.TextBox()
        Me.TxtDensidad = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cmbubicacion = New System.Windows.Forms.ComboBox()
        Me.DgInventario = New System.Windows.Forms.DataGridView()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.DgInventario, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Lucida Calligraphy", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(313, 12)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(422, 36)
        Me.Label8.TabIndex = 85
        Me.Label8.Text = "Inventario de Oro en Planta"
        '
        'LblArea
        '
        Me.LblArea.AutoSize = True
        Me.LblArea.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblArea.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.LblArea.Location = New System.Drawing.Point(316, 97)
        Me.LblArea.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblArea.Name = "LblArea"
        Me.LblArea.Size = New System.Drawing.Size(57, 17)
        Me.LblArea.TabIndex = 84
        Me.LblArea.Text = "Label6"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(125, 97)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(102, 17)
        Me.Label7.TabIndex = 83
        Me.Label7.Text = "Departamento:"
        '
        'LblUsuario
        '
        Me.LblUsuario.AutoSize = True
        Me.LblUsuario.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblUsuario.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.LblUsuario.Location = New System.Drawing.Point(316, 65)
        Me.LblUsuario.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblUsuario.Name = "LblUsuario"
        Me.LblUsuario.Size = New System.Drawing.Size(57, 17)
        Me.LblUsuario.TabIndex = 82
        Me.LblUsuario.Text = "Label5"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(125, 65)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(80, 17)
        Me.Label3.TabIndex = 81
        Me.Label3.Text = "Id. Usuario:"
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = Global.Z_Lab.My.Resources.Resources.LogoGranColombiaGoldSmall
        Me.PictureBox2.Location = New System.Drawing.Point(705, 58)
        Me.PictureBox2.Margin = New System.Windows.Forms.Padding(4)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(276, 62)
        Me.PictureBox2.TabIndex = 80
        Me.PictureBox2.TabStop = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.CmbMaximo)
        Me.GroupBox2.Controls.Add(Me.cmbdesviacion)
        Me.GroupBox2.Controls.Add(Me.cmbmedia)
        Me.GroupBox2.Controls.Add(Me.CmbMinimo)
        Me.GroupBox2.Location = New System.Drawing.Point(25, 52)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Size = New System.Drawing.Size(1184, 79)
        Me.GroupBox2.TabIndex = 86
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
        'CmbIdPeriodo
        '
        Me.CmbIdPeriodo.FormattingEnabled = True
        Me.CmbIdPeriodo.Location = New System.Drawing.Point(34, 49)
        Me.CmbIdPeriodo.Name = "CmbIdPeriodo"
        Me.CmbIdPeriodo.Size = New System.Drawing.Size(383, 24)
        Me.CmbIdPeriodo.TabIndex = 89
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(31, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(149, 17)
        Me.Label1.TabIndex = 90
        Me.Label1.Text = "Seleccione el Periodo:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.CmbIdPeriodo)
        Me.GroupBox1.Location = New System.Drawing.Point(25, 154)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1184, 100)
        Me.GroupBox1.TabIndex = 91
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Periodo:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(709, 18)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(45, 18)
        Me.Label6.TabIndex = 96
        Me.Label6.Text = "Mes:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(840, 18)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(72, 18)
        Me.Label9.TabIndex = 95
        Me.Label9.Text = "Periodo:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(542, 18)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(42, 18)
        Me.Label10.TabIndex = 94
        Me.Label10.Text = "Año:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(709, 56)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(51, 17)
        Me.Label5.TabIndex = 93
        Me.Label5.Text = "Label5"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(840, 56)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(51, 17)
        Me.Label4.TabIndex = 92
        Me.Label4.Text = "Label4"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(542, 56)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(51, 17)
        Me.Label2.TabIndex = 91
        Me.Label2.Text = "Label2"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.GroupBox4)
        Me.GroupBox3.Controls.Add(Me.Label16)
        Me.GroupBox3.Controls.Add(Me.Label15)
        Me.GroupBox3.Controls.Add(Me.txtausolucion)
        Me.GroupBox3.Controls.Add(Me.txtausolido)
        Me.GroupBox3.Controls.Add(Me.Lblid)
        Me.GroupBox3.Controls.Add(Me.CmdGuardar)
        Me.GroupBox3.Controls.Add(Me.Label14)
        Me.GroupBox3.Controls.Add(Me.Label13)
        Me.GroupBox3.Controls.Add(Me.Label12)
        Me.GroupBox3.Controls.Add(Me.TxtAlturaLodos)
        Me.GroupBox3.Controls.Add(Me.txtAlturaSuperior)
        Me.GroupBox3.Controls.Add(Me.TxtDensidad)
        Me.GroupBox3.Controls.Add(Me.Label11)
        Me.GroupBox3.Controls.Add(Me.cmbubicacion)
        Me.GroupBox3.Controls.Add(Me.DgInventario)
        Me.GroupBox3.Location = New System.Drawing.Point(25, 283)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(1184, 504)
        Me.GroupBox3.TabIndex = 92
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Inventario:"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.Label22)
        Me.GroupBox4.Controls.Add(Me.Label21)
        Me.GroupBox4.Controls.Add(Me.Label20)
        Me.GroupBox4.Controls.Add(Me.Lbltotal)
        Me.GroupBox4.Controls.Add(Me.LblSolucion)
        Me.GroupBox4.Controls.Add(Me.LblSolido)
        Me.GroupBox4.Location = New System.Drawing.Point(34, 400)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(1124, 98)
        Me.GroupBox4.TabIndex = 102
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Resumen:"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(708, 18)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(173, 20)
        Me.Label22.TabIndex = 5
        Me.Label22.Text = "Total Au Inventario:"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(567, 18)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(115, 20)
        Me.Label21.TabIndex = 4
        Me.Label21.Text = "Au Solución:"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(425, 18)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(95, 20)
        Me.Label20.TabIndex = 3
        Me.Label20.Text = "Au Sólido:"
        '
        'Lbltotal
        '
        Me.Lbltotal.AutoSize = True
        Me.Lbltotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbltotal.Location = New System.Drawing.Point(758, 57)
        Me.Lbltotal.Name = "Lbltotal"
        Me.Lbltotal.Size = New System.Drawing.Size(37, 29)
        Me.Lbltotal.TabIndex = 2
        Me.Lbltotal.Text = "---"
        '
        'LblSolucion
        '
        Me.LblSolucion.AutoSize = True
        Me.LblSolucion.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSolucion.Location = New System.Drawing.Point(566, 57)
        Me.LblSolucion.Name = "LblSolucion"
        Me.LblSolucion.Size = New System.Drawing.Size(37, 29)
        Me.LblSolucion.TabIndex = 1
        Me.LblSolucion.Text = "---"
        '
        'LblSolido
        '
        Me.LblSolido.AutoSize = True
        Me.LblSolido.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSolido.Location = New System.Drawing.Point(424, 57)
        Me.LblSolido.Name = "LblSolido"
        Me.LblSolido.Size = New System.Drawing.Size(37, 29)
        Me.LblSolido.TabIndex = 0
        Me.LblSolido.Text = "---"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(866, 18)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(137, 18)
        Me.Label16.TabIndex = 101
        Me.Label16.Text = "Au Solucion Ppm"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(729, 18)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(117, 18)
        Me.Label15.TabIndex = 96
        Me.Label15.Text = "Au Solido ppm"
        '
        'txtausolucion
        '
        Me.txtausolucion.Location = New System.Drawing.Point(884, 46)
        Me.txtausolucion.Name = "txtausolucion"
        Me.txtausolucion.Size = New System.Drawing.Size(100, 22)
        Me.txtausolucion.TabIndex = 7
        '
        'txtausolido
        '
        Me.txtausolido.Location = New System.Drawing.Point(746, 47)
        Me.txtausolido.Name = "txtausolido"
        Me.txtausolido.Size = New System.Drawing.Size(100, 22)
        Me.txtausolido.TabIndex = 6
        '
        'Lblid
        '
        Me.Lblid.AutoSize = True
        Me.Lblid.Location = New System.Drawing.Point(1140, 54)
        Me.Lblid.Name = "Lblid"
        Me.Lblid.Size = New System.Drawing.Size(18, 17)
        Me.Lblid.TabIndex = 93
        Me.Lblid.Text = "--"
        '
        'CmdGuardar
        '
        Me.CmdGuardar.Location = New System.Drawing.Point(1059, 46)
        Me.CmdGuardar.Name = "CmdGuardar"
        Me.CmdGuardar.Size = New System.Drawing.Size(75, 23)
        Me.CmdGuardar.TabIndex = 98
        Me.CmdGuardar.Text = "Guardar"
        Me.CmdGuardar.UseVisualStyleBackColor = True
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(314, 18)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(83, 18)
        Me.Label14.TabIndex = 97
        Me.Label14.Text = "Densidad:"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(417, 18)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(167, 18)
        Me.Label13.TabIndex = 96
        Me.Label13.Text = "Altura Libre Superior:"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(602, 20)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(108, 18)
        Me.Label12.TabIndex = 95
        Me.Label12.Text = "Altura Lodos:"
        '
        'TxtAlturaLodos
        '
        Me.TxtAlturaLodos.Location = New System.Drawing.Point(610, 47)
        Me.TxtAlturaLodos.Name = "TxtAlturaLodos"
        Me.TxtAlturaLodos.Size = New System.Drawing.Size(100, 22)
        Me.TxtAlturaLodos.TabIndex = 5
        '
        'txtAlturaSuperior
        '
        Me.txtAlturaSuperior.Location = New System.Drawing.Point(457, 47)
        Me.txtAlturaSuperior.Name = "txtAlturaSuperior"
        Me.txtAlturaSuperior.Size = New System.Drawing.Size(100, 22)
        Me.txtAlturaSuperior.TabIndex = 4
        '
        'TxtDensidad
        '
        Me.TxtDensidad.Location = New System.Drawing.Point(317, 47)
        Me.TxtDensidad.Name = "TxtDensidad"
        Me.TxtDensidad.Size = New System.Drawing.Size(100, 22)
        Me.TxtDensidad.TabIndex = 3
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(31, 27)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(160, 17)
        Me.Label11.TabIndex = 2
        Me.Label11.Text = "Seleccione la ubicaciòn:"
        '
        'cmbubicacion
        '
        Me.cmbubicacion.FormattingEnabled = True
        Me.cmbubicacion.Location = New System.Drawing.Point(34, 47)
        Me.cmbubicacion.Name = "cmbubicacion"
        Me.cmbubicacion.Size = New System.Drawing.Size(235, 24)
        Me.cmbubicacion.TabIndex = 1
        '
        'DgInventario
        '
        Me.DgInventario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgInventario.Location = New System.Drawing.Point(21, 91)
        Me.DgInventario.Name = "DgInventario"
        Me.DgInventario.RowTemplate.Height = 24
        Me.DgInventario.Size = New System.Drawing.Size(1137, 282)
        Me.DgInventario.TabIndex = 0
        '
        'FrmInventarioAudePlanta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightGoldenrodYellow
        Me.ClientSize = New System.Drawing.Size(1469, 799)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.LblArea)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.LblUsuario)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.GroupBox2)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmInventarioAudePlanta"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Inventario de Au en Planta"
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me.DgInventario, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents CmbMaximo As System.Windows.Forms.ComboBox
    Friend WithEvents cmbdesviacion As System.Windows.Forms.ComboBox
    Friend WithEvents cmbmedia As System.Windows.Forms.ComboBox
    Friend WithEvents CmbMinimo As System.Windows.Forms.ComboBox
    Friend WithEvents CmbIdPeriodo As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents CmdGuardar As System.Windows.Forms.Button
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents TxtAlturaLodos As System.Windows.Forms.TextBox
    Friend WithEvents txtAlturaSuperior As System.Windows.Forms.TextBox
    Friend WithEvents TxtDensidad As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents cmbubicacion As System.Windows.Forms.ComboBox
    Friend WithEvents DgInventario As System.Windows.Forms.DataGridView
    Friend WithEvents Lblid As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtausolucion As System.Windows.Forms.TextBox
    Friend WithEvents txtausolido As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Lbltotal As System.Windows.Forms.Label
    Friend WithEvents LblSolucion As System.Windows.Forms.Label
    Friend WithEvents LblSolido As System.Windows.Forms.Label
End Class
