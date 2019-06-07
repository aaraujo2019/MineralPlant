<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPiedeBanda12
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmPiedeBanda12))
        Me.Label8 = New System.Windows.Forms.Label()
        Me.LblArea = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.LblUsuario = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.DtFecha = New System.Windows.Forms.DateTimePicker()
        Me.GroupBoxForm = New System.Windows.Forms.GroupBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.CmdSave = New System.Windows.Forms.Button()
        Me.TxtLecturaPeso = New System.Windows.Forms.TextBox()
        Me.Cmbhora = New System.Windows.Forms.ComboBox()
        Me.GroupBoxResumen = New System.Windows.Forms.GroupBox()
        Me.LbltotalToneladas = New System.Windows.Forms.Label()
        Me.LblTonsHora = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.LblId = New System.Windows.Forms.Label()
        Me.DgPiedeBanda = New System.Windows.Forms.DataGridView()
        Me.LblHorasOperacion = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.GroupBox2.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBoxForm.SuspendLayout()
        Me.GroupBoxResumen.SuspendLayout()
        CType(Me.DgPiedeBanda, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Lucida Calligraphy", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(272, 9)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(293, 27)
        Me.Label8.TabIndex = 38
        Me.Label8.Text = "Reporte De Pie de Banda"
        '
        'LblArea
        '
        Me.LblArea.AutoSize = True
        Me.LblArea.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblArea.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.LblArea.Location = New System.Drawing.Point(254, 78)
        Me.LblArea.Name = "LblArea"
        Me.LblArea.Size = New System.Drawing.Size(45, 13)
        Me.LblArea.TabIndex = 37
        Me.LblArea.Text = "Label6"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(111, 78)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(77, 13)
        Me.Label7.TabIndex = 36
        Me.Label7.Text = "Departamento:"
        '
        'LblUsuario
        '
        Me.LblUsuario.AutoSize = True
        Me.LblUsuario.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblUsuario.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.LblUsuario.Location = New System.Drawing.Point(254, 52)
        Me.LblUsuario.Name = "LblUsuario"
        Me.LblUsuario.Size = New System.Drawing.Size(45, 13)
        Me.LblUsuario.TabIndex = 35
        Me.LblUsuario.Text = "Label5"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(111, 52)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(61, 13)
        Me.Label4.TabIndex = 34
        Me.Label4.Text = "Id. Usuario:"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.PictureBox1)
        Me.GroupBox2.Location = New System.Drawing.Point(29, 36)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(932, 64)
        Me.GroupBox2.TabIndex = 39
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Datos de Usuario:"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.Z_Lab.My.Resources.Resources.LogoGranColombiaGoldSmall
        Me.PictureBox1.Location = New System.Drawing.Point(687, 11)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(207, 50)
        Me.PictureBox1.TabIndex = 27
        Me.PictureBox1.TabStop = False
        '
        'DtFecha
        '
        Me.DtFecha.Location = New System.Drawing.Point(85, 48)
        Me.DtFecha.Name = "DtFecha"
        Me.DtFecha.Size = New System.Drawing.Size(200, 20)
        Me.DtFecha.TabIndex = 40
        '
        'GroupBoxForm
        '
        Me.GroupBoxForm.Controls.Add(Me.Label6)
        Me.GroupBoxForm.Controls.Add(Me.Label5)
        Me.GroupBoxForm.Controls.Add(Me.Label3)
        Me.GroupBoxForm.Controls.Add(Me.CmdSave)
        Me.GroupBoxForm.Controls.Add(Me.TxtLecturaPeso)
        Me.GroupBoxForm.Controls.Add(Me.Cmbhora)
        Me.GroupBoxForm.Controls.Add(Me.DtFecha)
        Me.GroupBoxForm.Location = New System.Drawing.Point(29, 151)
        Me.GroupBoxForm.Name = "GroupBoxForm"
        Me.GroupBoxForm.Size = New System.Drawing.Size(932, 100)
        Me.GroupBoxForm.TabIndex = 41
        Me.GroupBoxForm.TabStop = False
        Me.GroupBoxForm.Text = "Datos pie de Banda"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(340, 28)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(46, 16)
        Me.Label6.TabIndex = 46
        Me.Label6.Text = "Hora:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(529, 29)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(91, 16)
        Me.Label5.TabIndex = 45
        Me.Label5.Text = "Lectura (gr):"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(82, 29)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(55, 16)
        Me.Label3.TabIndex = 44
        Me.Label3.Text = "Fecha:"
        '
        'CmdSave
        '
        Me.CmdSave.Location = New System.Drawing.Point(687, 44)
        Me.CmdSave.Name = "CmdSave"
        Me.CmdSave.Size = New System.Drawing.Size(75, 23)
        Me.CmdSave.TabIndex = 43
        Me.CmdSave.Text = "Guardar"
        Me.CmdSave.UseVisualStyleBackColor = True
        '
        'TxtLecturaPeso
        '
        Me.TxtLecturaPeso.Location = New System.Drawing.Point(532, 48)
        Me.TxtLecturaPeso.Name = "TxtLecturaPeso"
        Me.TxtLecturaPeso.Size = New System.Drawing.Size(100, 20)
        Me.TxtLecturaPeso.TabIndex = 42
        '
        'Cmbhora
        '
        Me.Cmbhora.FormattingEnabled = True
        Me.Cmbhora.Location = New System.Drawing.Point(338, 47)
        Me.Cmbhora.Name = "Cmbhora"
        Me.Cmbhora.Size = New System.Drawing.Size(121, 21)
        Me.Cmbhora.TabIndex = 41
        '
        'GroupBoxResumen
        '
        Me.GroupBoxResumen.Controls.Add(Me.LblHorasOperacion)
        Me.GroupBoxResumen.Controls.Add(Me.Label10)
        Me.GroupBoxResumen.Controls.Add(Me.LbltotalToneladas)
        Me.GroupBoxResumen.Controls.Add(Me.LblTonsHora)
        Me.GroupBoxResumen.Controls.Add(Me.Label2)
        Me.GroupBoxResumen.Controls.Add(Me.Label1)
        Me.GroupBoxResumen.Location = New System.Drawing.Point(114, 597)
        Me.GroupBoxResumen.Name = "GroupBoxResumen"
        Me.GroupBoxResumen.Size = New System.Drawing.Size(786, 100)
        Me.GroupBoxResumen.TabIndex = 43
        Me.GroupBoxResumen.TabStop = False
        Me.GroupBoxResumen.Text = "Resumen:"
        '
        'LbltotalToneladas
        '
        Me.LbltotalToneladas.AutoSize = True
        Me.LbltotalToneladas.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LbltotalToneladas.Location = New System.Drawing.Point(385, 64)
        Me.LbltotalToneladas.Name = "LbltotalToneladas"
        Me.LbltotalToneladas.Size = New System.Drawing.Size(40, 24)
        Me.LbltotalToneladas.TabIndex = 46
        Me.LbltotalToneladas.Text = "000"
        '
        'LblTonsHora
        '
        Me.LblTonsHora.AutoSize = True
        Me.LblTonsHora.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTonsHora.Location = New System.Drawing.Point(190, 64)
        Me.LblTonsHora.Name = "LblTonsHora"
        Me.LblTonsHora.Size = New System.Drawing.Size(40, 24)
        Me.LblTonsHora.TabIndex = 45
        Me.LblTonsHora.Text = "000"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(160, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(141, 20)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Toneladas Hora:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(354, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(142, 20)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Total Toneladas:"
        '
        'LblId
        '
        Me.LblId.AutoSize = True
        Me.LblId.Location = New System.Drawing.Point(884, 114)
        Me.LblId.Name = "LblId"
        Me.LblId.Size = New System.Drawing.Size(16, 13)
        Me.LblId.TabIndex = 44
        Me.LblId.Text = "Id"
        '
        'DgPiedeBanda
        '
        Me.DgPiedeBanda.AllowUserToAddRows = False
        Me.DgPiedeBanda.AllowUserToDeleteRows = False
        Me.DgPiedeBanda.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgPiedeBanda.Location = New System.Drawing.Point(29, 274)
        Me.DgPiedeBanda.Name = "DgPiedeBanda"
        Me.DgPiedeBanda.ReadOnly = True
        Me.DgPiedeBanda.RowTemplate.Height = 24
        Me.DgPiedeBanda.Size = New System.Drawing.Size(948, 266)
        Me.DgPiedeBanda.TabIndex = 45
        '
        'LblHorasOperacion
        '
        Me.LblHorasOperacion.AutoSize = True
        Me.LblHorasOperacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblHorasOperacion.Location = New System.Drawing.Point(555, 64)
        Me.LblHorasOperacion.Name = "LblHorasOperacion"
        Me.LblHorasOperacion.Size = New System.Drawing.Size(40, 24)
        Me.LblHorasOperacion.TabIndex = 48
        Me.LblHorasOperacion.Text = "000"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(524, 16)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(174, 20)
        Me.Label10.TabIndex = 47
        Me.Label10.Text = "Horas de Operacion:"
        '
        'FrmPiedeBanda12
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightGoldenrodYellow
        Me.ClientSize = New System.Drawing.Size(1028, 750)
        Me.Controls.Add(Me.DgPiedeBanda)
        Me.Controls.Add(Me.LblId)
        Me.Controls.Add(Me.GroupBoxResumen)
        Me.Controls.Add(Me.GroupBoxForm)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.LblArea)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.LblUsuario)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.GroupBox2)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmPiedeBanda12"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporte Pie de Banda"
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBoxForm.ResumeLayout(False)
        Me.GroupBoxForm.PerformLayout()
        Me.GroupBoxResumen.ResumeLayout(False)
        Me.GroupBoxResumen.PerformLayout()
        CType(Me.DgPiedeBanda, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents LblArea As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents LblUsuario As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents DtFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents GroupBoxForm As System.Windows.Forms.GroupBox
    Friend WithEvents CmdSave As System.Windows.Forms.Button
    Friend WithEvents TxtLecturaPeso As System.Windows.Forms.TextBox
    Friend WithEvents Cmbhora As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBoxResumen As System.Windows.Forms.GroupBox
    Friend WithEvents LblId As System.Windows.Forms.Label
    Friend WithEvents LbltotalToneladas As System.Windows.Forms.Label
    Friend WithEvents LblTonsHora As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents DgPiedeBanda As System.Windows.Forms.DataGridView
    Friend WithEvents LblHorasOperacion As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
End Class
