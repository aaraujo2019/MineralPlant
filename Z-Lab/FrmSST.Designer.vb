<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSST
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmSST))
        Me.Label5 = New System.Windows.Forms.Label()
        Me.LblArea = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.LblUsuario = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.DtFecha = New System.Windows.Forms.DateTimePicker()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.CmbTurno = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.CmdGuardar = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.CmbUbicacion = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TxtSST = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.dtfechafinal = New System.Windows.Forms.DateTimePicker()
        Me.dtfechainicio = New System.Windows.Forms.DateTimePicker()
        Me.Dgsst = New System.Windows.Forms.DataGridView()
        Me.Lblidsst = New System.Windows.Forms.Label()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.Dgsst, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Lucida Calligraphy", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(260, 23)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(306, 27)
        Me.Label5.TabIndex = 54
        Me.Label5.Text = "SST - Sòlidos en Suspensiòn"
        '
        'LblArea
        '
        Me.LblArea.AutoSize = True
        Me.LblArea.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblArea.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.LblArea.Location = New System.Drawing.Point(270, 97)
        Me.LblArea.Name = "LblArea"
        Me.LblArea.Size = New System.Drawing.Size(122, 13)
        Me.LblArea.TabIndex = 51
        Me.LblArea.Text = "Laboratorio Químico"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(128, 97)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(77, 13)
        Me.Label7.TabIndex = 50
        Me.Label7.Text = "Departamento:"
        '
        'LblUsuario
        '
        Me.LblUsuario.AutoSize = True
        Me.LblUsuario.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblUsuario.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.LblUsuario.Location = New System.Drawing.Point(270, 71)
        Me.LblUsuario.Name = "LblUsuario"
        Me.LblUsuario.Size = New System.Drawing.Size(122, 13)
        Me.LblUsuario.TabIndex = 49
        Me.LblUsuario.Text = "Laboratorio Químico"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(128, 71)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(61, 13)
        Me.Label4.TabIndex = 48
        Me.Label4.Text = "Id. Usuario:"
        '
        'GroupBox2
        '
        Me.GroupBox2.Location = New System.Drawing.Point(45, 55)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(822, 64)
        Me.GroupBox2.TabIndex = 53
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Datos de Usuario:"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.Z_Lab.My.Resources.Resources.LogoGranColombiaGoldSmall
        Me.PictureBox1.Location = New System.Drawing.Point(608, 66)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(207, 50)
        Me.PictureBox1.TabIndex = 47
        Me.PictureBox1.TabStop = False
        '
        'DtFecha
        '
        Me.DtFecha.Location = New System.Drawing.Point(32, 33)
        Me.DtFecha.Name = "DtFecha"
        Me.DtFecha.Size = New System.Drawing.Size(200, 20)
        Me.DtFecha.TabIndex = 55
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.CmbTurno)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.CmdGuardar)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.CmbUbicacion)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.TxtSST)
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Controls.Add(Me.dtfechafinal)
        Me.GroupBox1.Controls.Add(Me.dtfechainicio)
        Me.GroupBox1.Controls.Add(Me.Dgsst)
        Me.GroupBox1.Controls.Add(Me.DtFecha)
        Me.GroupBox1.Location = New System.Drawing.Point(45, 175)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.GroupBox1.Size = New System.Drawing.Size(822, 324)
        Me.GroupBox1.TabIndex = 56
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Sòlidos en suspensiòn"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(561, 15)
        Me.Label6.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(31, 13)
        Me.Label6.TabIndex = 60
        Me.Label6.Text = "SST:"
        '
        'CmbTurno
        '
        Me.CmbTurno.FormattingEnabled = True
        Me.CmbTurno.Items.AddRange(New Object() {"Turno1", "Turno2", "Turno3"})
        Me.CmbTurno.Location = New System.Drawing.Point(431, 32)
        Me.CmbTurno.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.CmbTurno.Name = "CmbTurno"
        Me.CmbTurno.Size = New System.Drawing.Size(96, 21)
        Me.CmbTurno.TabIndex = 63
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(429, 15)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(38, 13)
        Me.Label3.TabIndex = 59
        Me.Label3.Text = "Turno:"
        '
        'CmdGuardar
        '
        Me.CmdGuardar.Location = New System.Drawing.Point(687, 32)
        Me.CmdGuardar.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.CmdGuardar.Name = "CmdGuardar"
        Me.CmdGuardar.Size = New System.Drawing.Size(56, 19)
        Me.CmdGuardar.TabIndex = 62
        Me.CmdGuardar.Text = "Guardar"
        Me.CmdGuardar.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(234, 15)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(58, 13)
        Me.Label2.TabIndex = 58
        Me.Label2.Text = "Ubicacion:"
        '
        'CmbUbicacion
        '
        Me.CmbUbicacion.FormattingEnabled = True
        Me.CmbUbicacion.Items.AddRange(New Object() {"Descarga Espesador 4", "Rebalse Espesador 4", "Celda #1", "Derecha Bascula", "Izquierda Bascula", "Clasificador"})
        Me.CmbUbicacion.Location = New System.Drawing.Point(236, 31)
        Me.CmbUbicacion.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.CmbUbicacion.Name = "CmbUbicacion"
        Me.CmbUbicacion.Size = New System.Drawing.Size(165, 21)
        Me.CmbUbicacion.TabIndex = 61
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(30, 15)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 13)
        Me.Label1.TabIndex = 57
        Me.Label1.Text = "Fecha:"
        '
        'TxtSST
        '
        Me.TxtSST.Location = New System.Drawing.Point(563, 32)
        Me.TxtSST.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.TxtSST.Name = "TxtSST"
        Me.TxtSST.Size = New System.Drawing.Size(95, 20)
        Me.TxtSST.TabIndex = 60
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(456, 270)
        Me.Button1.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(56, 19)
        Me.Button1.TabIndex = 59
        Me.Button1.Text = "Exportar"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'dtfechafinal
        '
        Me.dtfechafinal.Location = New System.Drawing.Point(227, 271)
        Me.dtfechafinal.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.dtfechafinal.Name = "dtfechafinal"
        Me.dtfechafinal.Size = New System.Drawing.Size(151, 20)
        Me.dtfechafinal.TabIndex = 58
        Me.dtfechafinal.Value = New Date(2017, 10, 6, 0, 0, 0, 0)
        '
        'dtfechainicio
        '
        Me.dtfechainicio.Location = New System.Drawing.Point(20, 271)
        Me.dtfechainicio.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.dtfechainicio.Name = "dtfechainicio"
        Me.dtfechainicio.Size = New System.Drawing.Size(151, 20)
        Me.dtfechainicio.TabIndex = 57
        Me.dtfechainicio.Value = New Date(2017, 10, 6, 0, 0, 0, 0)
        '
        'Dgsst
        '
        Me.Dgsst.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Dgsst.Location = New System.Drawing.Point(20, 58)
        Me.Dgsst.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Dgsst.Name = "Dgsst"
        Me.Dgsst.RowTemplate.Height = 24
        Me.Dgsst.Size = New System.Drawing.Size(724, 189)
        Me.Dgsst.TabIndex = 56
        '
        'Lblidsst
        '
        Me.Lblidsst.AutoSize = True
        Me.Lblidsst.Location = New System.Drawing.Point(733, 158)
        Me.Lblidsst.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Lblidsst.Name = "Lblidsst"
        Me.Lblidsst.Size = New System.Drawing.Size(19, 13)
        Me.Lblidsst.TabIndex = 64
        Me.Lblidsst.Text = "00"
        '
        'FrmSST
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightGoldenrodYellow
        Me.ClientSize = New System.Drawing.Size(951, 509)
        Me.Controls.Add(Me.Lblidsst)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.LblArea)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.LblUsuario)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Name = "FrmSST"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "SST - Sólidos en Suspensión"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.Dgsst, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents LblArea As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents LblUsuario As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents DtFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Dgsst As System.Windows.Forms.DataGridView
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents dtfechafinal As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtfechainicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents CmbTurno As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents CmdGuardar As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents CmbUbicacion As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtSST As System.Windows.Forms.TextBox
    Friend WithEvents Lblidsst As System.Windows.Forms.Label
End Class
