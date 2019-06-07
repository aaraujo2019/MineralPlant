<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMuestrasInstantaneas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMuestrasInstantaneas))
        Me.Label8 = New System.Windows.Forms.Label()
        Me.LblArea = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.LblUsuario = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.DtFecha = New System.Windows.Forms.DateTimePicker()
        Me.Cmbubicacion = New System.Windows.Forms.ComboBox()
        Me.CmdGuardar = New System.Windows.Forms.Button()
        Me.TxtTenor = New System.Windows.Forms.TextBox()
        Me.CmbHora = New System.Windows.Forms.ComboBox()
        Me.DgVMuestras = New System.Windows.Forms.DataGridView()
        Me.Ubicacion = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TxtObservaciones = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Lblid = New System.Windows.Forms.Label()
        Me.cmbtipomuestra = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DgVMuestras, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Lucida Calligraphy", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(546, 9)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(199, 27)
        Me.Label8.TabIndex = 32
        Me.Label8.Text = "Muestreo Planta"
        '
        'LblArea
        '
        Me.LblArea.AutoSize = True
        Me.LblArea.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblArea.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.LblArea.Location = New System.Drawing.Point(244, 92)
        Me.LblArea.Name = "LblArea"
        Me.LblArea.Size = New System.Drawing.Size(122, 13)
        Me.LblArea.TabIndex = 31
        Me.LblArea.Text = "Laboratorio Químico"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(101, 92)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(77, 13)
        Me.Label7.TabIndex = 30
        Me.Label7.Text = "Departamento:"
        '
        'LblUsuario
        '
        Me.LblUsuario.AutoSize = True
        Me.LblUsuario.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblUsuario.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.LblUsuario.Location = New System.Drawing.Point(244, 66)
        Me.LblUsuario.Name = "LblUsuario"
        Me.LblUsuario.Size = New System.Drawing.Size(122, 13)
        Me.LblUsuario.TabIndex = 29
        Me.LblUsuario.Text = "Laboratorio Químico"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(101, 66)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(61, 13)
        Me.Label4.TabIndex = 28
        Me.Label4.Text = "Id. Usuario:"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.Z_Lab.My.Resources.Resources.LogoGranColombiaGoldSmall
        Me.PictureBox1.Location = New System.Drawing.Point(582, 61)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(207, 50)
        Me.PictureBox1.TabIndex = 27
        Me.PictureBox1.TabStop = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Location = New System.Drawing.Point(19, 50)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(822, 64)
        Me.GroupBox2.TabIndex = 33
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Datos de Usuario:"
        '
        'DtFecha
        '
        Me.DtFecha.Location = New System.Drawing.Point(104, 149)
        Me.DtFecha.Name = "DtFecha"
        Me.DtFecha.Size = New System.Drawing.Size(200, 20)
        Me.DtFecha.TabIndex = 34
        '
        'Cmbubicacion
        '
        Me.Cmbubicacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmbubicacion.FormattingEnabled = True
        Me.Cmbubicacion.Location = New System.Drawing.Point(104, 211)
        Me.Cmbubicacion.Name = "Cmbubicacion"
        Me.Cmbubicacion.Size = New System.Drawing.Size(212, 24)
        Me.Cmbubicacion.TabIndex = 1
        '
        'CmdGuardar
        '
        Me.CmdGuardar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdGuardar.Location = New System.Drawing.Point(860, 211)
        Me.CmdGuardar.Name = "CmdGuardar"
        Me.CmdGuardar.Size = New System.Drawing.Size(75, 23)
        Me.CmdGuardar.TabIndex = 36
        Me.CmdGuardar.Text = "Guardar"
        Me.CmdGuardar.UseVisualStyleBackColor = True
        '
        'TxtTenor
        '
        Me.TxtTenor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTenor.Location = New System.Drawing.Point(579, 211)
        Me.TxtTenor.Name = "TxtTenor"
        Me.TxtTenor.Size = New System.Drawing.Size(100, 22)
        Me.TxtTenor.TabIndex = 4
        '
        'CmbHora
        '
        Me.CmbHora.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbHora.FormattingEnabled = True
        Me.CmbHora.Location = New System.Drawing.Point(346, 209)
        Me.CmbHora.Name = "CmbHora"
        Me.CmbHora.Size = New System.Drawing.Size(88, 24)
        Me.CmbHora.TabIndex = 2
        '
        'DgVMuestras
        '
        Me.DgVMuestras.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgVMuestras.Location = New System.Drawing.Point(104, 263)
        Me.DgVMuestras.Name = "DgVMuestras"
        Me.DgVMuestras.Size = New System.Drawing.Size(737, 234)
        Me.DgVMuestras.TabIndex = 39
        '
        'Ubicacion
        '
        Me.Ubicacion.AutoSize = True
        Me.Ubicacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Ubicacion.Location = New System.Drawing.Point(108, 185)
        Me.Ubicacion.Name = "Ubicacion"
        Me.Ubicacion.Size = New System.Drawing.Size(93, 20)
        Me.Ubicacion.TabIndex = 40
        Me.Ubicacion.Text = "Ubicacion:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(350, 183)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 20)
        Me.Label2.TabIndex = 41
        Me.Label2.Text = "Hora:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(588, 185)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(60, 20)
        Me.Label3.TabIndex = 42
        Me.Label3.Text = "Tenor:"
        '
        'TxtObservaciones
        '
        Me.TxtObservaciones.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtObservaciones.Location = New System.Drawing.Point(702, 211)
        Me.TxtObservaciones.Multiline = True
        Me.TxtObservaciones.Name = "TxtObservaciones"
        Me.TxtObservaciones.Size = New System.Drawing.Size(137, 46)
        Me.TxtObservaciones.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(698, 185)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(115, 20)
        Me.Label1.TabIndex = 44
        Me.Label1.Text = "Comentarios:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Lucida Calligraphy", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(166, 20)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(268, 27)
        Me.Label5.TabIndex = 45
        Me.Label5.Text = "Muestras Instantaneas"
        '
        'Lblid
        '
        Me.Lblid.AutoSize = True
        Me.Lblid.Location = New System.Drawing.Point(750, 126)
        Me.Lblid.Name = "Lblid"
        Me.Lblid.Size = New System.Drawing.Size(16, 13)
        Me.Lblid.TabIndex = 46
        Me.Lblid.Text = "Id"
        '
        'cmbtipomuestra
        '
        Me.cmbtipomuestra.FormattingEnabled = True
        Me.cmbtipomuestra.Items.AddRange(New Object() {"Sólido", "Solución"})
        Me.cmbtipomuestra.Location = New System.Drawing.Point(440, 212)
        Me.cmbtipomuestra.Name = "cmbtipomuestra"
        Me.cmbtipomuestra.Size = New System.Drawing.Size(121, 21)
        Me.cmbtipomuestra.TabIndex = 3
        Me.cmbtipomuestra.Text = "Seleccione"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(436, 185)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(118, 20)
        Me.Label6.TabIndex = 48
        Me.Label6.Text = "Tipo Muestra:"
        '
        'FrmMuestras
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightGoldenrodYellow
        Me.ClientSize = New System.Drawing.Size(951, 509)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.cmbtipomuestra)
        Me.Controls.Add(Me.Lblid)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TxtObservaciones)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Ubicacion)
        Me.Controls.Add(Me.DgVMuestras)
        Me.Controls.Add(Me.CmbHora)
        Me.Controls.Add(Me.TxtTenor)
        Me.Controls.Add(Me.CmdGuardar)
        Me.Controls.Add(Me.Cmbubicacion)
        Me.Controls.Add(Me.DtFecha)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.LblArea)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.LblUsuario)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmMuestras"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Muestras Instantaneas"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DgVMuestras, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents LblArea As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents LblUsuario As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents DtFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents Cmbubicacion As System.Windows.Forms.ComboBox
    Friend WithEvents CmdGuardar As System.Windows.Forms.Button
    Friend WithEvents TxtTenor As System.Windows.Forms.TextBox
    Friend WithEvents CmbHora As System.Windows.Forms.ComboBox
    Friend WithEvents DgVMuestras As System.Windows.Forms.DataGridView
    Friend WithEvents Ubicacion As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxtObservaciones As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Lblid As System.Windows.Forms.Label
    Friend WithEvents cmbtipomuestra As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
End Class
