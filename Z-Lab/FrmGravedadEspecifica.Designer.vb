<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmGravedadEspecifica
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmGravedadEspecifica))
        Me.Label5 = New System.Windows.Forms.Label()
        Me.LblArea = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.LblUsuario = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Ubicacion = New System.Windows.Forms.Label()
        Me.CmbHorainicio = New System.Windows.Forms.ComboBox()
        Me.TxtGravedad = New System.Windows.Forms.TextBox()
        Me.CmdGuardar = New System.Windows.Forms.Button()
        Me.Cmbubicacion = New System.Windows.Forms.ComboBox()
        Me.DtFecha = New System.Windows.Forms.DateTimePicker()
        Me.CmbHoraFinal = New System.Windows.Forms.ComboBox()
        Me.DgGravedad = New System.Windows.Forms.DataGridView()
        Me.Lblid = New System.Windows.Forms.Label()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DgGravedad, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Lucida Calligraphy", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(369, 20)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(235, 27)
        Me.Label5.TabIndex = 53
        Me.Label5.Text = "Gravedad especifica"
        '
        'LblArea
        '
        Me.LblArea.AutoSize = True
        Me.LblArea.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblArea.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.LblArea.Location = New System.Drawing.Point(276, 92)
        Me.LblArea.Name = "LblArea"
        Me.LblArea.Size = New System.Drawing.Size(122, 13)
        Me.LblArea.TabIndex = 50
        Me.LblArea.Text = "Laboratorio Químico"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(133, 92)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(77, 13)
        Me.Label7.TabIndex = 49
        Me.Label7.Text = "Departamento:"
        '
        'LblUsuario
        '
        Me.LblUsuario.AutoSize = True
        Me.LblUsuario.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblUsuario.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.LblUsuario.Location = New System.Drawing.Point(276, 66)
        Me.LblUsuario.Name = "LblUsuario"
        Me.LblUsuario.Size = New System.Drawing.Size(122, 13)
        Me.LblUsuario.TabIndex = 48
        Me.LblUsuario.Text = "Laboratorio Químico"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(133, 66)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(61, 13)
        Me.Label4.TabIndex = 47
        Me.Label4.Text = "Id. Usuario:"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.Z_Lab.My.Resources.Resources.LogoGranColombiaGoldSmall
        Me.PictureBox1.Location = New System.Drawing.Point(614, 61)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(207, 50)
        Me.PictureBox1.TabIndex = 46
        Me.PictureBox1.TabStop = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Location = New System.Drawing.Point(51, 50)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(822, 64)
        Me.GroupBox2.TabIndex = 52
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Datos de Usuario:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(404, 157)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(84, 16)
        Me.Label6.TabIndex = 65
        Me.Label6.Text = "Hora Final:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(507, 157)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(158, 16)
        Me.Label3.TabIndex = 63
        Me.Label3.Text = "Gravedad Especifica:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(289, 157)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(87, 16)
        Me.Label2.TabIndex = 62
        Me.Label2.Text = "Hora Inicio:"
        '
        'Ubicacion
        '
        Me.Ubicacion.AutoSize = True
        Me.Ubicacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Ubicacion.Location = New System.Drawing.Point(48, 157)
        Me.Ubicacion.Name = "Ubicacion"
        Me.Ubicacion.Size = New System.Drawing.Size(82, 16)
        Me.Ubicacion.TabIndex = 61
        Me.Ubicacion.Text = "Ubicacion:"
        '
        'CmbHorainicio
        '
        Me.CmbHorainicio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbHorainicio.FormattingEnabled = True
        Me.CmbHorainicio.Location = New System.Drawing.Point(293, 192)
        Me.CmbHorainicio.Name = "CmbHorainicio"
        Me.CmbHorainicio.Size = New System.Drawing.Size(88, 24)
        Me.CmbHorainicio.TabIndex = 55
        '
        'TxtGravedad
        '
        Me.TxtGravedad.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtGravedad.Location = New System.Drawing.Point(542, 196)
        Me.TxtGravedad.Name = "TxtGravedad"
        Me.TxtGravedad.Size = New System.Drawing.Size(100, 22)
        Me.TxtGravedad.TabIndex = 57
        '
        'CmdGuardar
        '
        Me.CmdGuardar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdGuardar.Location = New System.Drawing.Point(746, 192)
        Me.CmdGuardar.Name = "CmdGuardar"
        Me.CmdGuardar.Size = New System.Drawing.Size(75, 23)
        Me.CmdGuardar.TabIndex = 60
        Me.CmdGuardar.Text = "Guardar"
        Me.CmdGuardar.UseVisualStyleBackColor = True
        '
        'Cmbubicacion
        '
        Me.Cmbubicacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmbubicacion.FormattingEnabled = True
        Me.Cmbubicacion.Items.AddRange(New Object() {"Alimento Agitador 1", "Colas Espesador 5", "Colas de Flotacion", "Espesador 5", "Rebalse Ciclón"})
        Me.Cmbubicacion.Location = New System.Drawing.Point(51, 194)
        Me.Cmbubicacion.Name = "Cmbubicacion"
        Me.Cmbubicacion.Size = New System.Drawing.Size(212, 24)
        Me.Cmbubicacion.TabIndex = 54
        '
        'DtFecha
        '
        Me.DtFecha.Location = New System.Drawing.Point(51, 132)
        Me.DtFecha.Name = "DtFecha"
        Me.DtFecha.Size = New System.Drawing.Size(200, 20)
        Me.DtFecha.TabIndex = 59
        '
        'CmbHoraFinal
        '
        Me.CmbHoraFinal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbHoraFinal.FormattingEnabled = True
        Me.CmbHoraFinal.Location = New System.Drawing.Point(413, 194)
        Me.CmbHoraFinal.Name = "CmbHoraFinal"
        Me.CmbHoraFinal.Size = New System.Drawing.Size(88, 24)
        Me.CmbHoraFinal.TabIndex = 66
        '
        'DgGravedad
        '
        Me.DgGravedad.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgGravedad.Location = New System.Drawing.Point(51, 238)
        Me.DgGravedad.Name = "DgGravedad"
        Me.DgGravedad.Size = New System.Drawing.Size(770, 247)
        Me.DgGravedad.TabIndex = 67
        '
        'Lblid
        '
        Me.Lblid.AutoSize = True
        Me.Lblid.Location = New System.Drawing.Point(808, 117)
        Me.Lblid.Name = "Lblid"
        Me.Lblid.Size = New System.Drawing.Size(13, 13)
        Me.Lblid.TabIndex = 68
        Me.Lblid.Text = "--"
        '
        'FrmGravedadEspecifica
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightGoldenrodYellow
        Me.ClientSize = New System.Drawing.Size(951, 509)
        Me.Controls.Add(Me.Lblid)
        Me.Controls.Add(Me.DgGravedad)
        Me.Controls.Add(Me.CmbHoraFinal)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Ubicacion)
        Me.Controls.Add(Me.CmbHorainicio)
        Me.Controls.Add(Me.TxtGravedad)
        Me.Controls.Add(Me.CmdGuardar)
        Me.Controls.Add(Me.Cmbubicacion)
        Me.Controls.Add(Me.DtFecha)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.LblArea)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.LblUsuario)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmGravedadEspecifica"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Gravedad Especifica"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DgGravedad, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Ubicacion As System.Windows.Forms.Label
    Friend WithEvents CmbHorainicio As System.Windows.Forms.ComboBox
    Friend WithEvents TxtGravedad As System.Windows.Forms.TextBox
    Friend WithEvents CmdGuardar As System.Windows.Forms.Button
    Friend WithEvents Cmbubicacion As System.Windows.Forms.ComboBox
    Friend WithEvents DtFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents CmbHoraFinal As System.Windows.Forms.ComboBox
    Friend WithEvents DgGravedad As System.Windows.Forms.DataGridView
    Friend WithEvents Lblid As System.Windows.Forms.Label
End Class
