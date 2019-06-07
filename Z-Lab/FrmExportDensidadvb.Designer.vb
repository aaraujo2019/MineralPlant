<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmExportDensidadvb
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmExportDensidadvb))
        Me.Button1 = New System.Windows.Forms.Button()
        Me.DtFechainicio = New System.Windows.Forms.DateTimePicker()
        Me.DTFechaFinal = New System.Windows.Forms.DateTimePicker()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.LblArea = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.LblUsuario = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.lblexport = New System.Windows.Forms.Label()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(724, 141)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Exportar"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'DtFechainicio
        '
        Me.DtFechainicio.Location = New System.Drawing.Point(247, 144)
        Me.DtFechainicio.Name = "DtFechainicio"
        Me.DtFechainicio.Size = New System.Drawing.Size(200, 20)
        Me.DtFechainicio.TabIndex = 2
        '
        'DTFechaFinal
        '
        Me.DTFechaFinal.Location = New System.Drawing.Point(476, 144)
        Me.DTFechaFinal.Name = "DTFechaFinal"
        Me.DTFechaFinal.Size = New System.Drawing.Size(200, 20)
        Me.DTFechaFinal.TabIndex = 3
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Lucida Calligraphy", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(226, 13)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(254, 27)
        Me.Label8.TabIndex = 39
        Me.Label8.Text = "Exportar Densidades:"
        '
        'LblArea
        '
        Me.LblArea.AutoSize = True
        Me.LblArea.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblArea.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.LblArea.Location = New System.Drawing.Point(228, 82)
        Me.LblArea.Name = "LblArea"
        Me.LblArea.Size = New System.Drawing.Size(45, 13)
        Me.LblArea.TabIndex = 38
        Me.LblArea.Text = "Label6"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(85, 82)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(77, 13)
        Me.Label7.TabIndex = 37
        Me.Label7.Text = "Departamento:"
        '
        'LblUsuario
        '
        Me.LblUsuario.AutoSize = True
        Me.LblUsuario.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblUsuario.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.LblUsuario.Location = New System.Drawing.Point(228, 56)
        Me.LblUsuario.Name = "LblUsuario"
        Me.LblUsuario.Size = New System.Drawing.Size(45, 13)
        Me.LblUsuario.TabIndex = 36
        Me.LblUsuario.Text = "Label5"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(85, 56)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(61, 13)
        Me.Label3.TabIndex = 35
        Me.Label3.Text = "Id. Usuario:"
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = Global.Z_Lab.My.Resources.Resources.LogoGranColombiaGoldSmall
        Me.PictureBox2.Location = New System.Drawing.Point(592, 50)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(207, 50)
        Me.PictureBox2.TabIndex = 34
        Me.PictureBox2.TabStop = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Location = New System.Drawing.Point(40, 40)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(806, 64)
        Me.GroupBox2.TabIndex = 40
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Datos de Usuario:"
        '
        'lblexport
        '
        Me.lblexport.AutoSize = True
        Me.lblexport.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblexport.Location = New System.Drawing.Point(646, 206)
        Me.lblexport.Name = "lblexport"
        Me.lblexport.Size = New System.Drawing.Size(153, 25)
        Me.lblexport.TabIndex = 41
        Me.lblexport.Text = "Exportando..."
        Me.lblexport.Visible = False
        '
        'FrmExportDensidadvb
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightGoldenrodYellow
        Me.ClientSize = New System.Drawing.Size(888, 262)
        Me.Controls.Add(Me.lblexport)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.LblArea)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.LblUsuario)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.DTFechaFinal)
        Me.Controls.Add(Me.DtFechainicio)
        Me.Controls.Add(Me.Button1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmExportDensidadvb"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Consulta Densidades"
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents DtFechainicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents DTFechaFinal As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents LblArea As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents LblUsuario As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents lblexport As System.Windows.Forms.Label
End Class
