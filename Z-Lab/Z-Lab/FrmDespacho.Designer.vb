<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmDespacho
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmDespacho))
        Me.cmbDespacho = New System.Windows.Forms.ComboBox()
        Me.DtFecha = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.DgMuestrasDespacho = New System.Windows.Forms.DataGridView()
        Me.CmbInicio = New System.Windows.Forms.ComboBox()
        Me.CmbFinal = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.CmdExport = New System.Windows.Forms.Button()
        Me.CmdBorrar = New System.Windows.Forms.Button()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.LblFechaDespacho = New System.Windows.Forms.Label()
        Me.LblIdDespacho = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TxtObservaciones = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Cmdagregar = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.LblArea = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.LblUsuario = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        CType(Me.DgMuestrasDespacho, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmbDespacho
        '
        Me.cmbDespacho.FormattingEnabled = True
        Me.cmbDespacho.Location = New System.Drawing.Point(60, 75)
        Me.cmbDespacho.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cmbDespacho.Name = "cmbDespacho"
        Me.cmbDespacho.Size = New System.Drawing.Size(249, 24)
        Me.cmbDespacho.TabIndex = 0
        Me.ToolTip1.SetToolTip(Me.cmbDespacho, "Seleccione de la Lista el Despacho que Quiere Visualizar.")
        '
        'DtFecha
        '
        Me.DtFecha.Location = New System.Drawing.Point(52, 234)
        Me.DtFecha.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.DtFecha.Name = "DtFecha"
        Me.DtFecha.Size = New System.Drawing.Size(265, 22)
        Me.DtFecha.TabIndex = 1
        Me.ToolTip1.SetToolTip(Me.DtFecha, "Seleccione Fecha en la que se Ingresaron Muestras.")
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(52, 214)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(134, 17)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Fecha de Muestreo:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(56, 55)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(93, 17)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "ID Despacho:"
        '
        'DgMuestrasDespacho
        '
        Me.DgMuestrasDespacho.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgMuestrasDespacho.Location = New System.Drawing.Point(57, 314)
        Me.DgMuestrasDespacho.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.DgMuestrasDespacho.Name = "DgMuestrasDespacho"
        Me.DgMuestrasDespacho.Size = New System.Drawing.Size(647, 171)
        Me.DgMuestrasDespacho.TabIndex = 5
        '
        'CmbInicio
        '
        Me.CmbInicio.FormattingEnabled = True
        Me.CmbInicio.Location = New System.Drawing.Point(351, 238)
        Me.CmbInicio.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.CmbInicio.Name = "CmbInicio"
        Me.CmbInicio.Size = New System.Drawing.Size(160, 24)
        Me.CmbInicio.TabIndex = 6
        Me.ToolTip1.SetToolTip(Me.CmbInicio, "Seleccione Intervalo Inicial")
        '
        'CmbFinal
        '
        Me.CmbFinal.FormattingEnabled = True
        Me.CmbFinal.Location = New System.Drawing.Point(543, 238)
        Me.CmbFinal.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.CmbFinal.Name = "CmbFinal"
        Me.CmbFinal.Size = New System.Drawing.Size(160, 24)
        Me.CmbFinal.TabIndex = 7
        Me.ToolTip1.SetToolTip(Me.CmbFinal, "Seleccione Intervalo Final.")
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(544, 218)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(49, 17)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Hasta:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.CmdExport)
        Me.GroupBox1.Controls.Add(Me.CmdBorrar)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.LblFechaDespacho)
        Me.GroupBox1.Controls.Add(Me.LblIdDespacho)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.TxtObservaciones)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Cmdagregar)
        Me.GroupBox1.Controls.Add(Me.DgMuestrasDespacho)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.CmbFinal)
        Me.GroupBox1.Controls.Add(Me.DtFecha)
        Me.GroupBox1.Controls.Add(Me.CmbInicio)
        Me.GroupBox1.Controls.Add(Me.cmbDespacho)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Location = New System.Drawing.Point(59, 124)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox1.Size = New System.Drawing.Size(1075, 544)
        Me.GroupBox1.TabIndex = 11
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Muestras Despachadas:"
        '
        'CmdExport
        '
        Me.CmdExport.Location = New System.Drawing.Point(959, 314)
        Me.CmdExport.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.CmdExport.Name = "CmdExport"
        Me.CmdExport.Size = New System.Drawing.Size(100, 28)
        Me.CmdExport.TabIndex = 22
        Me.CmdExport.Text = "Exportar"
        Me.ToolTip1.SetToolTip(Me.CmdExport, "Exportar Remision de Envio de Muestras.")
        Me.CmdExport.UseVisualStyleBackColor = True
        '
        'CmdBorrar
        '
        Me.CmdBorrar.Location = New System.Drawing.Point(604, 495)
        Me.CmdBorrar.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.CmdBorrar.Name = "CmdBorrar"
        Me.CmdBorrar.Size = New System.Drawing.Size(100, 28)
        Me.CmdBorrar.TabIndex = 21
        Me.CmdBorrar.Text = "Borrar"
        Me.CmdBorrar.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Lucida Calligraphy", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(47, 175)
        Me.Label11.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(213, 27)
        Me.Label11.TabIndex = 20
        Me.Label11.Text = "Agregar Muestras:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(539, 55)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(139, 17)
        Me.Label9.TabIndex = 19
        Me.Label9.Text = "Fecha de Despacho:"
        '
        'LblFechaDespacho
        '
        Me.LblFechaDespacho.AutoSize = True
        Me.LblFechaDespacho.Location = New System.Drawing.Point(539, 85)
        Me.LblFechaDespacho.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblFechaDespacho.Name = "LblFechaDespacho"
        Me.LblFechaDespacho.Size = New System.Drawing.Size(51, 17)
        Me.LblFechaDespacho.TabIndex = 18
        Me.LblFechaDespacho.Text = "Label9"
        '
        'LblIdDespacho
        '
        Me.LblIdDespacho.AutoSize = True
        Me.LblIdDespacho.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblIdDespacho.Location = New System.Drawing.Point(349, 75)
        Me.LblIdDespacho.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblIdDespacho.Name = "LblIdDespacho"
        Me.LblIdDespacho.Size = New System.Drawing.Size(101, 25)
        Me.LblIdDespacho.TabIndex = 17
        Me.LblIdDespacho.Text = "Despacho"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(351, 218)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(53, 17)
        Me.Label10.TabIndex = 15
        Me.Label10.Text = "Desde:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(724, 218)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(91, 17)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "Comentarios:"
        '
        'TxtObservaciones
        '
        Me.TxtObservaciones.Location = New System.Drawing.Point(728, 234)
        Me.TxtObservaciones.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TxtObservaciones.Multiline = True
        Me.TxtObservaciones.Name = "TxtObservaciones"
        Me.TxtObservaciones.Size = New System.Drawing.Size(196, 48)
        Me.TxtObservaciones.TabIndex = 12
        Me.ToolTip1.SetToolTip(Me.TxtObservaciones, "Ingrese Comentarios.")
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(60, 281)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(140, 17)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Listado de Muestras:"
        '
        'Cmdagregar
        '
        Me.Cmdagregar.Location = New System.Drawing.Point(959, 231)
        Me.Cmdagregar.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Cmdagregar.Name = "Cmdagregar"
        Me.Cmdagregar.Size = New System.Drawing.Size(100, 28)
        Me.Cmdagregar.TabIndex = 10
        Me.Cmdagregar.Text = "Agregar"
        Me.ToolTip1.SetToolTip(Me.Cmdagregar, "Agregar Intervalo de Muestras a Despacho.")
        Me.Cmdagregar.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Lucida Calligraphy", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(307, 5)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(345, 36)
        Me.Label8.TabIndex = 25
        Me.Label8.Text = "Despacho de Muestras:"
        '
        'LblArea
        '
        Me.LblArea.AutoSize = True
        Me.LblArea.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblArea.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.LblArea.Location = New System.Drawing.Point(309, 90)
        Me.LblArea.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblArea.Name = "LblArea"
        Me.LblArea.Size = New System.Drawing.Size(57, 17)
        Me.LblArea.TabIndex = 24
        Me.LblArea.Text = "Label6"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(119, 90)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(102, 17)
        Me.Label7.TabIndex = 23
        Me.Label7.Text = "Departamento:"
        '
        'LblUsuario
        '
        Me.LblUsuario.AutoSize = True
        Me.LblUsuario.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblUsuario.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.LblUsuario.Location = New System.Drawing.Point(309, 58)
        Me.LblUsuario.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblUsuario.Name = "LblUsuario"
        Me.LblUsuario.Size = New System.Drawing.Size(57, 17)
        Me.LblUsuario.TabIndex = 22
        Me.LblUsuario.Text = "Label5"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(119, 58)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(80, 17)
        Me.Label3.TabIndex = 21
        Me.Label3.Text = "Id. Usuario:"
        '
        'GroupBox2
        '
        Me.GroupBox2.Location = New System.Drawing.Point(59, 38)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox2.Size = New System.Drawing.Size(1075, 79)
        Me.GroupBox2.TabIndex = 26
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Datos de Usuario:"
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = Global.Z_Lab.My.Resources.Resources.LogoGranColombiaGoldSmall
        Me.PictureBox2.Location = New System.Drawing.Point(699, 50)
        Me.PictureBox2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(276, 62)
        Me.PictureBox2.TabIndex = 20
        Me.PictureBox2.TabStop = False
        '
        'FrmDespacho
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightGoldenrodYellow
        Me.ClientSize = New System.Drawing.Size(1172, 681)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.LblArea)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.LblUsuario)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "FrmDespacho"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Despacho de Muestras a Laboratorio"
        CType(Me.DgMuestrasDespacho, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmbDespacho As System.Windows.Forms.ComboBox
    Friend WithEvents DtFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents DgMuestrasDespacho As System.Windows.Forms.DataGridView
    Friend WithEvents CmbInicio As System.Windows.Forms.ComboBox
    Friend WithEvents CmbFinal As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents LblArea As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents LblUsuario As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TxtObservaciones As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Cmdagregar As System.Windows.Forms.Button
    Friend WithEvents LblIdDespacho As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents LblFechaDespacho As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents CmdBorrar As System.Windows.Forms.Button
    Friend WithEvents CmdExport As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
End Class
