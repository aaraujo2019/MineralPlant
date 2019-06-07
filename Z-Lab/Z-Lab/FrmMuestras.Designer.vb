<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMuestras
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMuestras))
        Me.Label4 = New System.Windows.Forms.Label()
        Me.LblUsuario = New System.Windows.Forms.Label()
        Me.LblArea = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.PicGuardar1 = New System.Windows.Forms.PictureBox()
        Me.ChkAnalisis = New System.Windows.Forms.CheckBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TxtToneladas = New System.Windows.Forms.TextBox()
        Me.ChkDup = New System.Windows.Forms.CheckBox()
        Me.DgMuestra = New System.Windows.Forms.DataGridView()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TxtMuestra = New System.Windows.Forms.TextBox()
        Me.CmbUbicacion = New System.Windows.Forms.ComboBox()
        Me.DtFecha = New System.Windows.Forms.DateTimePicker()
        Me.CmdGuardar = New System.Windows.Forms.Button()
        Me.TxtObservacion = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PicGuardar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DgMuestra, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(101, 52)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(61, 13)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "Id. Usuario:"
        '
        'LblUsuario
        '
        Me.LblUsuario.AutoSize = True
        Me.LblUsuario.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblUsuario.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.LblUsuario.Location = New System.Drawing.Point(244, 52)
        Me.LblUsuario.Name = "LblUsuario"
        Me.LblUsuario.Size = New System.Drawing.Size(45, 13)
        Me.LblUsuario.TabIndex = 12
        Me.LblUsuario.Text = "Label5"
        '
        'LblArea
        '
        Me.LblArea.AutoSize = True
        Me.LblArea.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblArea.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.LblArea.Location = New System.Drawing.Point(244, 78)
        Me.LblArea.Name = "LblArea"
        Me.LblArea.Size = New System.Drawing.Size(45, 13)
        Me.LblArea.TabIndex = 14
        Me.LblArea.Text = "Label6"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(101, 78)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(77, 13)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = "Departamento:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Lucida Calligraphy", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(242, 9)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(347, 27)
        Me.Label8.TabIndex = 15
        Me.Label8.Text = "Muestras Tomadas por Fecha:"
        '
        'GroupBox2
        '
        Me.GroupBox2.Location = New System.Drawing.Point(56, 36)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(705, 64)
        Me.GroupBox2.TabIndex = 19
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Datos de Usuario:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.PictureBox2)
        Me.GroupBox1.Controls.Add(Me.PicGuardar1)
        Me.GroupBox1.Controls.Add(Me.ChkAnalisis)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.TxtToneladas)
        Me.GroupBox1.Controls.Add(Me.ChkDup)
        Me.GroupBox1.Controls.Add(Me.DgMuestra)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.TxtMuestra)
        Me.GroupBox1.Controls.Add(Me.CmbUbicacion)
        Me.GroupBox1.Controls.Add(Me.DtFecha)
        Me.GroupBox1.Controls.Add(Me.CmdGuardar)
        Me.GroupBox1.Controls.Add(Me.TxtObservacion)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Location = New System.Drawing.Point(56, 144)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(705, 390)
        Me.GroupBox1.TabIndex = 21
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Datos de Muestreo"
        '
        'PictureBox2
        '
        Me.PictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(562, 359)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(23, 25)
        Me.PictureBox2.TabIndex = 22
        Me.PictureBox2.TabStop = False
        Me.PictureBox2.Tag = ""
        '
        'PicGuardar1
        '
        Me.PicGuardar1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PicGuardar1.Image = CType(resources.GetObject("PicGuardar1.Image"), System.Drawing.Image)
        Me.PicGuardar1.Location = New System.Drawing.Point(524, 359)
        Me.PicGuardar1.Name = "PicGuardar1"
        Me.PicGuardar1.Size = New System.Drawing.Size(23, 25)
        Me.PicGuardar1.TabIndex = 21
        Me.PicGuardar1.TabStop = False
        '
        'ChkAnalisis
        '
        Me.ChkAnalisis.AutoSize = True
        Me.ChkAnalisis.Location = New System.Drawing.Point(21, 367)
        Me.ChkAnalisis.Name = "ChkAnalisis"
        Me.ChkAnalisis.Size = New System.Drawing.Size(80, 17)
        Me.ChkAnalisis.TabIndex = 20
        Me.ChkAnalisis.Text = "Ver Analisis"
        Me.ChkAnalisis.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(388, 65)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(71, 13)
        Me.Label6.TabIndex = 19
        Me.Label6.Text = "Toneladas H."
        '
        'TxtToneladas
        '
        Me.TxtToneladas.Location = New System.Drawing.Point(391, 83)
        Me.TxtToneladas.Name = "TxtToneladas"
        Me.TxtToneladas.Size = New System.Drawing.Size(79, 20)
        Me.TxtToneladas.TabIndex = 3
        Me.ToolTip1.SetToolTip(Me.TxtToneladas, "Toneladas humedas Registradas en Bascula.")
        '
        'ChkDup
        '
        Me.ChkDup.AutoSize = True
        Me.ChkDup.Location = New System.Drawing.Point(156, 90)
        Me.ChkDup.Name = "ChkDup"
        Me.ChkDup.Size = New System.Drawing.Size(15, 14)
        Me.ChkDup.TabIndex = 17
        Me.ChkDup.UseVisualStyleBackColor = True
        '
        'DgMuestra
        '
        Me.DgMuestra.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgMuestra.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.DgMuestra.Location = New System.Drawing.Point(6, 161)
        Me.DgMuestra.Name = "DgMuestra"
        Me.DgMuestra.RowTemplate.Height = 24
        Me.DgMuestra.Size = New System.Drawing.Size(594, 191)
        Me.DgMuestra.TabIndex = 3
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(134, 68)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(58, 13)
        Me.Label5.TabIndex = 16
        Me.Label5.Text = "Duplicado:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(18, 68)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Muestra:"
        '
        'TxtMuestra
        '
        Me.TxtMuestra.Location = New System.Drawing.Point(21, 84)
        Me.TxtMuestra.Name = "TxtMuestra"
        Me.TxtMuestra.Size = New System.Drawing.Size(108, 20)
        Me.TxtMuestra.TabIndex = 1
        Me.ToolTip1.SetToolTip(Me.TxtMuestra, "Numero de Ticket o Sello")
        '
        'CmbUbicacion
        '
        Me.CmbUbicacion.FormattingEnabled = True
        Me.CmbUbicacion.Location = New System.Drawing.Point(203, 83)
        Me.CmbUbicacion.Name = "CmbUbicacion"
        Me.CmbUbicacion.Size = New System.Drawing.Size(164, 21)
        Me.CmbUbicacion.TabIndex = 2
        Me.ToolTip1.SetToolTip(Me.CmbUbicacion, "Proyecto / Operador Minero")
        '
        'DtFecha
        '
        Me.DtFecha.Location = New System.Drawing.Point(21, 28)
        Me.DtFecha.Name = "DtFecha"
        Me.DtFecha.Size = New System.Drawing.Size(200, 20)
        Me.DtFecha.TabIndex = 0
        Me.ToolTip1.SetToolTip(Me.DtFecha, "Seleccione la Fecha.")
        '
        'CmdGuardar
        '
        Me.CmdGuardar.Location = New System.Drawing.Point(624, 85)
        Me.CmdGuardar.Name = "CmdGuardar"
        Me.CmdGuardar.Size = New System.Drawing.Size(75, 23)
        Me.CmdGuardar.TabIndex = 4
        Me.CmdGuardar.Text = "Guardar"
        Me.CmdGuardar.UseVisualStyleBackColor = True
        '
        'TxtObservacion
        '
        Me.TxtObservacion.Location = New System.Drawing.Point(484, 84)
        Me.TxtObservacion.Multiline = True
        Me.TxtObservacion.Name = "TxtObservacion"
        Me.TxtObservacion.Size = New System.Drawing.Size(116, 66)
        Me.TxtObservacion.TabIndex = 4
        Me.ToolTip1.SetToolTip(Me.TxtObservacion, "Observaciones Sobre la Muestra")
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(200, 68)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(111, 13)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Ubicacion / Proyecto:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(484, 65)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(70, 13)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Observacion:"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.Z_Lab.My.Resources.Resources.LogoGranColombiaGoldSmall
        Me.PictureBox1.Location = New System.Drawing.Point(536, 46)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(207, 50)
        Me.PictureBox1.TabIndex = 9
        Me.PictureBox1.TabStop = False
        '
        'FrmMuestras
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightGoldenrodYellow
        Me.ClientSize = New System.Drawing.Size(840, 578)
        Me.Controls.Add(Me.GroupBox1)
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
        Me.Text = "Toma de Muestras"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PicGuardar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DgMuestra, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents LblUsuario As System.Windows.Forms.Label
    Friend WithEvents LblArea As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TxtToneladas As System.Windows.Forms.TextBox
    Friend WithEvents ChkDup As System.Windows.Forms.CheckBox
    Friend WithEvents DgMuestra As System.Windows.Forms.DataGridView
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtMuestra As System.Windows.Forms.TextBox
    Friend WithEvents CmbUbicacion As System.Windows.Forms.ComboBox
    Friend WithEvents DtFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents CmdGuardar As System.Windows.Forms.Button
    Friend WithEvents TxtObservacion As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ChkAnalisis As System.Windows.Forms.CheckBox
    Friend WithEvents PicGuardar1 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
End Class
