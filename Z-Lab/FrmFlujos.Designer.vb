﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmFlujos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmFlujos))
        Me.Label8 = New System.Windows.Forms.Label()
        Me.LblArea = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.LblUsuario = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.DgFlujos = New System.Windows.Forms.DataGridView()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.TxtCianuro = New System.Windows.Forms.TextBox()
        Me.TxtPH = New System.Windows.Forms.TextBox()
        Me.TxtTiempo = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.TxtObservaciones = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TxtDensidad = New System.Windows.Forms.MaskedTextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.CmdAdd = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CmbHoraInicio = New System.Windows.Forms.ComboBox()
        Me.cmbubicacion = New System.Windows.Forms.ComboBox()
        Me.DtPFecha = New System.Windows.Forms.DateTimePicker()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.LblIdConsecutivo = New System.Windows.Forms.Label()
        Me.LblTipoFlujos = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.CmdExportar = New System.Windows.Forms.Button()
        Me.DtFecha2 = New System.Windows.Forms.DateTimePicker()
        Me.DtFecha1 = New System.Windows.Forms.DateTimePicker()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        CType(Me.DgFlujos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Lucida Calligraphy", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(385, 11)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(293, 36)
        Me.Label8.TabIndex = 39
        Me.Label8.Text = "Medicion de Flujos:"
        '
        'LblArea
        '
        Me.LblArea.AutoSize = True
        Me.LblArea.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblArea.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.LblArea.Location = New System.Drawing.Point(388, 96)
        Me.LblArea.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblArea.Name = "LblArea"
        Me.LblArea.Size = New System.Drawing.Size(57, 17)
        Me.LblArea.TabIndex = 38
        Me.LblArea.Text = "Label6"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(197, 96)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(102, 17)
        Me.Label7.TabIndex = 37
        Me.Label7.Text = "Departamento:"
        '
        'LblUsuario
        '
        Me.LblUsuario.AutoSize = True
        Me.LblUsuario.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblUsuario.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.LblUsuario.Location = New System.Drawing.Point(388, 64)
        Me.LblUsuario.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblUsuario.Name = "LblUsuario"
        Me.LblUsuario.Size = New System.Drawing.Size(57, 17)
        Me.LblUsuario.TabIndex = 36
        Me.LblUsuario.Text = "Label5"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(197, 64)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(80, 17)
        Me.Label3.TabIndex = 35
        Me.Label3.Text = "Id. Usuario:"
        '
        'GroupBox2
        '
        Me.GroupBox2.Location = New System.Drawing.Point(137, 46)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Size = New System.Drawing.Size(1075, 79)
        Me.GroupBox2.TabIndex = 40
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Datos de Usuario:"
        '
        'DgFlujos
        '
        Me.DgFlujos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgFlujos.Location = New System.Drawing.Point(63, 359)
        Me.DgFlujos.Margin = New System.Windows.Forms.Padding(4)
        Me.DgFlujos.Name = "DgFlujos"
        Me.DgFlujos.Size = New System.Drawing.Size(1256, 300)
        Me.DgFlujos.TabIndex = 51
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.TxtCianuro)
        Me.GroupBox1.Controls.Add(Me.TxtPH)
        Me.GroupBox1.Controls.Add(Me.TxtTiempo)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.TxtObservaciones)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.TxtDensidad)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.CmdAdd)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.CmbHoraInicio)
        Me.GroupBox1.Controls.Add(Me.cmbubicacion)
        Me.GroupBox1.Location = New System.Drawing.Point(16, 217)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Size = New System.Drawing.Size(1343, 123)
        Me.GroupBox1.TabIndex = 52
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Datos:"
        '
        'TxtCianuro
        '
        Me.TxtCianuro.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.TxtCianuro.Location = New System.Drawing.Point(888, 64)
        Me.TxtCianuro.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtCianuro.Name = "TxtCianuro"
        Me.TxtCianuro.Size = New System.Drawing.Size(117, 30)
        Me.TxtCianuro.TabIndex = 5
        '
        'TxtPH
        '
        Me.TxtPH.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.TxtPH.Location = New System.Drawing.Point(761, 63)
        Me.TxtPH.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtPH.Name = "TxtPH"
        Me.TxtPH.Size = New System.Drawing.Size(92, 30)
        Me.TxtPH.TabIndex = 4
        '
        'TxtTiempo
        '
        Me.TxtTiempo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.TxtTiempo.Location = New System.Drawing.Point(627, 64)
        Me.TxtTiempo.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtTiempo.Name = "TxtTiempo"
        Me.TxtTiempo.Size = New System.Drawing.Size(116, 30)
        Me.TxtTiempo.TabIndex = 3
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(1043, 18)
        Me.Label14.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(141, 25)
        Me.Label14.TabIndex = 69
        Me.Label14.Text = "Comentarios:"
        '
        'TxtObservaciones
        '
        Me.TxtObservaciones.Location = New System.Drawing.Point(1044, 63)
        Me.TxtObservaciones.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtObservaciones.Multiline = True
        Me.TxtObservaciones.Name = "TxtObservaciones"
        Me.TxtObservaciones.Size = New System.Drawing.Size(160, 52)
        Me.TxtObservaciones.TabIndex = 6
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.ForeColor = System.Drawing.SystemColors.ControlDark
        Me.Label13.Location = New System.Drawing.Point(924, 46)
        Me.Label13.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(57, 17)
        Me.Label13.TabIndex = 67
        Me.Label13.Text = "Cianuro"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(877, 18)
        Me.Label12.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(129, 25)
        Me.Label12.TabIndex = 66
        Me.Label12.Text = "Dosificación"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(779, 18)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(48, 25)
        Me.Label10.TabIndex = 63
        Me.Label10.Text = "PH:"
        '
        'TxtDensidad
        '
        Me.TxtDensidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtDensidad.Location = New System.Drawing.Point(467, 64)
        Me.TxtDensidad.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtDensidad.Mask = "9999"
        Me.TxtDensidad.Name = "TxtDensidad"
        Me.TxtDensidad.Size = New System.Drawing.Size(119, 30)
        Me.TxtDensidad.TabIndex = 3
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlDark
        Me.Label6.Location = New System.Drawing.Point(647, 48)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(72, 17)
        Me.Label6.TabIndex = 60
        Me.Label6.Text = "Segundos"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(621, 20)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(91, 25)
        Me.Label5.TabIndex = 59
        Me.Label5.Text = "Tiempo:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(312, 20)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(65, 25)
        Me.Label4.TabIndex = 58
        Me.Label4.Text = "Hora:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(461, 20)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(110, 25)
        Me.Label2.TabIndex = 57
        Me.Label2.Text = "Densidad:"
        '
        'CmdAdd
        '
        Me.CmdAdd.Location = New System.Drawing.Point(1229, 32)
        Me.CmdAdd.Margin = New System.Windows.Forms.Padding(4)
        Me.CmdAdd.Name = "CmdAdd"
        Me.CmdAdd.Size = New System.Drawing.Size(100, 66)
        Me.CmdAdd.TabIndex = 7
        Me.CmdAdd.Text = "Agregar"
        Me.CmdAdd.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(3, 20)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(152, 31)
        Me.Label1.TabIndex = 56
        Me.Label1.Text = "Ubicación:"
        '
        'CmbHoraInicio
        '
        Me.CmbHoraInicio.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbHoraInicio.FormattingEnabled = True
        Me.CmbHoraInicio.Location = New System.Drawing.Point(307, 64)
        Me.CmbHoraInicio.Margin = New System.Windows.Forms.Padding(4)
        Me.CmbHoraInicio.Name = "CmbHoraInicio"
        Me.CmbHoraInicio.Size = New System.Drawing.Size(140, 33)
        Me.CmbHoraInicio.TabIndex = 2
        '
        'cmbubicacion
        '
        Me.cmbubicacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbubicacion.FormattingEnabled = True
        Me.cmbubicacion.Location = New System.Drawing.Point(4, 64)
        Me.cmbubicacion.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbubicacion.Name = "cmbubicacion"
        Me.cmbubicacion.Size = New System.Drawing.Size(281, 33)
        Me.cmbubicacion.TabIndex = 1
        '
        'DtPFecha
        '
        Me.DtPFecha.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DtPFecha.Location = New System.Drawing.Point(137, 174)
        Me.DtPFecha.Margin = New System.Windows.Forms.Padding(4)
        Me.DtPFecha.Name = "DtPFecha"
        Me.DtPFecha.Size = New System.Drawing.Size(271, 22)
        Me.DtPFecha.TabIndex = 53
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(137, 140)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(86, 29)
        Me.Label9.TabIndex = 54
        Me.Label9.Text = "Fecha:"
        '
        'LblIdConsecutivo
        '
        Me.LblIdConsecutivo.AutoSize = True
        Me.LblIdConsecutivo.Location = New System.Drawing.Point(1129, 186)
        Me.LblIdConsecutivo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblIdConsecutivo.Name = "LblIdConsecutivo"
        Me.LblIdConsecutivo.Size = New System.Drawing.Size(19, 17)
        Me.LblIdConsecutivo.TabIndex = 55
        Me.LblIdConsecutivo.Text = "Id"
        '
        'LblTipoFlujos
        '
        Me.LblTipoFlujos.AutoSize = True
        Me.LblTipoFlujos.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTipoFlujos.ForeColor = System.Drawing.Color.Blue
        Me.LblTipoFlujos.Location = New System.Drawing.Point(769, 4)
        Me.LblTipoFlujos.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblTipoFlujos.Name = "LblTipoFlujos"
        Me.LblTipoFlujos.Size = New System.Drawing.Size(95, 42)
        Me.LblTipoFlujos.TabIndex = 56
        Me.LblTipoFlujos.Text = "Tipo"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.CmdExportar)
        Me.GroupBox3.Controls.Add(Me.DtFecha2)
        Me.GroupBox3.Controls.Add(Me.DtFecha1)
        Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(25, 672)
        Me.GroupBox3.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox3.Size = New System.Drawing.Size(1343, 63)
        Me.GroupBox3.TabIndex = 57
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Exportar"
        '
        'CmdExportar
        '
        Me.CmdExportar.Location = New System.Drawing.Point(752, 27)
        Me.CmdExportar.Margin = New System.Windows.Forms.Padding(4)
        Me.CmdExportar.Name = "CmdExportar"
        Me.CmdExportar.Size = New System.Drawing.Size(100, 28)
        Me.CmdExportar.TabIndex = 2
        Me.CmdExportar.Text = "Exportar"
        Me.CmdExportar.UseVisualStyleBackColor = True
        '
        'DtFecha2
        '
        Me.DtFecha2.Location = New System.Drawing.Point(457, 31)
        Me.DtFecha2.Margin = New System.Windows.Forms.Padding(4)
        Me.DtFecha2.Name = "DtFecha2"
        Me.DtFecha2.Size = New System.Drawing.Size(265, 23)
        Me.DtFecha2.TabIndex = 1
        '
        'DtFecha1
        '
        Me.DtFecha1.Location = New System.Drawing.Point(117, 31)
        Me.DtFecha1.Margin = New System.Windows.Forms.Padding(4)
        Me.DtFecha1.Name = "DtFecha1"
        Me.DtFecha1.Size = New System.Drawing.Size(265, 23)
        Me.DtFecha1.TabIndex = 0
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = Global.Z_Lab.My.Resources.Resources.LogoGranColombiaGoldSmall
        Me.PictureBox2.Location = New System.Drawing.Point(777, 57)
        Me.PictureBox2.Margin = New System.Windows.Forms.Padding(4)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(276, 62)
        Me.PictureBox2.TabIndex = 34
        Me.PictureBox2.TabStop = False
        '
        'FrmFlujos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightGoldenrodYellow
        Me.ClientSize = New System.Drawing.Size(1363, 750)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.LblTipoFlujos)
        Me.Controls.Add(Me.LblIdConsecutivo)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.DtPFecha)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.DgFlujos)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.LblArea)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.LblUsuario)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.GroupBox2)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "FrmFlujos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Flujos"
        CType(Me.DgFlujos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
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
    Friend WithEvents DgFlujos As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CmdAdd As System.Windows.Forms.Button
    Friend WithEvents CmbHoraInicio As System.Windows.Forms.ComboBox
    Friend WithEvents cmbubicacion As System.Windows.Forms.ComboBox
    Friend WithEvents DtPFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents LblIdConsecutivo As System.Windows.Forms.Label
    Friend WithEvents TxtDensidad As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents LblTipoFlujos As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents TxtObservaciones As System.Windows.Forms.TextBox
    Friend WithEvents TxtCianuro As System.Windows.Forms.TextBox
    Friend WithEvents TxtPH As System.Windows.Forms.TextBox
    Friend WithEvents TxtTiempo As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents CmdExportar As System.Windows.Forms.Button
    Friend WithEvents DtFecha2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents DtFecha1 As System.Windows.Forms.DateTimePicker
End Class
