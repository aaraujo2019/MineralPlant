<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmConsumoReactivos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmConsumoReactivos))
        Me.Label8 = New System.Windows.Forms.Label()
        Me.LblArea = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.LblUsuario = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.DtFecha = New System.Windows.Forms.DateTimePicker()
        Me.TxtEntrada = New System.Windows.Forms.TextBox()
        Me.TxtConsumo = New System.Windows.Forms.TextBox()
        Me.TxtSalidaConsumo = New System.Windows.Forms.TextBox()
        Me.TxtSTraslado = New System.Windows.Forms.TextBox()
        Me.TxtSconsumo = New System.Windows.Forms.TextBox()
        Me.CmbReactivo = New System.Windows.Forms.ComboBox()
        Me.CmdGuardar = New System.Windows.Forms.Button()
        Me.DgReactivos = New System.Windows.Forms.DataGridView()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.LblSolConsumo = New System.Windows.Forms.Label()
        Me.LblSolTraslado = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.LblId = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.LblSaldo = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.LblNombreReactivo = New System.Windows.Forms.Label()
        Me.GroupBox2.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DgReactivos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Lucida Calligraphy", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(155, 9)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(645, 27)
        Me.Label8.TabIndex = 44
        Me.Label8.Text = "Consumo de Reactivos - Planta de Beneficio MariaDama"
        '
        'LblArea
        '
        Me.LblArea.AutoSize = True
        Me.LblArea.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblArea.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.LblArea.Location = New System.Drawing.Point(270, 42)
        Me.LblArea.Name = "LblArea"
        Me.LblArea.Size = New System.Drawing.Size(45, 13)
        Me.LblArea.TabIndex = 43
        Me.LblArea.Text = "Label6"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(127, 42)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(77, 13)
        Me.Label7.TabIndex = 42
        Me.Label7.Text = "Departamento:"
        '
        'LblUsuario
        '
        Me.LblUsuario.AutoSize = True
        Me.LblUsuario.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblUsuario.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.LblUsuario.Location = New System.Drawing.Point(270, 16)
        Me.LblUsuario.Name = "LblUsuario"
        Me.LblUsuario.Size = New System.Drawing.Size(45, 13)
        Me.LblUsuario.TabIndex = 41
        Me.LblUsuario.Text = "Label5"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(127, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(61, 13)
        Me.Label4.TabIndex = 40
        Me.Label4.Text = "Id. Usuario:"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.PictureBox1)
        Me.GroupBox2.Controls.Add(Me.LblArea)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.LblUsuario)
        Me.GroupBox2.Location = New System.Drawing.Point(13, 36)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(998, 64)
        Me.GroupBox2.TabIndex = 45
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Datos de Usuario:"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.Z_Lab.My.Resources.Resources.LogoGranColombiaGoldSmall
        Me.PictureBox1.Location = New System.Drawing.Point(757, 8)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(207, 50)
        Me.PictureBox1.TabIndex = 27
        Me.PictureBox1.TabStop = False
        '
        'DtFecha
        '
        Me.DtFecha.Location = New System.Drawing.Point(28, 19)
        Me.DtFecha.Name = "DtFecha"
        Me.DtFecha.Size = New System.Drawing.Size(200, 22)
        Me.DtFecha.TabIndex = 46
        '
        'TxtEntrada
        '
        Me.TxtEntrada.Location = New System.Drawing.Point(287, 67)
        Me.TxtEntrada.Name = "TxtEntrada"
        Me.TxtEntrada.Size = New System.Drawing.Size(80, 22)
        Me.TxtEntrada.TabIndex = 47
        '
        'TxtConsumo
        '
        Me.TxtConsumo.Location = New System.Drawing.Point(373, 67)
        Me.TxtConsumo.Name = "TxtConsumo"
        Me.TxtConsumo.Size = New System.Drawing.Size(80, 22)
        Me.TxtConsumo.TabIndex = 48
        '
        'TxtSalidaConsumo
        '
        Me.TxtSalidaConsumo.Location = New System.Drawing.Point(659, 68)
        Me.TxtSalidaConsumo.Name = "TxtSalidaConsumo"
        Me.TxtSalidaConsumo.Size = New System.Drawing.Size(80, 22)
        Me.TxtSalidaConsumo.TabIndex = 49
        '
        'TxtSTraslado
        '
        Me.TxtSTraslado.Location = New System.Drawing.Point(485, 68)
        Me.TxtSTraslado.Name = "TxtSTraslado"
        Me.TxtSTraslado.Size = New System.Drawing.Size(80, 22)
        Me.TxtSTraslado.TabIndex = 50
        '
        'TxtSconsumo
        '
        Me.TxtSconsumo.Location = New System.Drawing.Point(573, 68)
        Me.TxtSconsumo.Name = "TxtSconsumo"
        Me.TxtSconsumo.Size = New System.Drawing.Size(80, 22)
        Me.TxtSconsumo.TabIndex = 51
        '
        'CmbReactivo
        '
        Me.CmbReactivo.FormattingEnabled = True
        Me.CmbReactivo.Location = New System.Drawing.Point(28, 67)
        Me.CmbReactivo.Name = "CmbReactivo"
        Me.CmbReactivo.Size = New System.Drawing.Size(200, 24)
        Me.CmbReactivo.TabIndex = 52
        '
        'CmdGuardar
        '
        Me.CmdGuardar.Location = New System.Drawing.Point(781, 64)
        Me.CmdGuardar.Name = "CmdGuardar"
        Me.CmdGuardar.Size = New System.Drawing.Size(75, 23)
        Me.CmdGuardar.TabIndex = 53
        Me.CmdGuardar.Text = "Guardar"
        Me.CmdGuardar.UseVisualStyleBackColor = True
        '
        'DgReactivos
        '
        Me.DgReactivos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgReactivos.Location = New System.Drawing.Point(41, 339)
        Me.DgReactivos.Name = "DgReactivos"
        Me.DgReactivos.Size = New System.Drawing.Size(828, 263)
        Me.DgReactivos.TabIndex = 54
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.LblSolConsumo)
        Me.GroupBox1.Controls.Add(Me.LblSolTraslado)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.DtFecha)
        Me.GroupBox1.Controls.Add(Me.CmbReactivo)
        Me.GroupBox1.Controls.Add(Me.CmdGuardar)
        Me.GroupBox1.Controls.Add(Me.TxtEntrada)
        Me.GroupBox1.Controls.Add(Me.TxtConsumo)
        Me.GroupBox1.Controls.Add(Me.TxtSconsumo)
        Me.GroupBox1.Controls.Add(Me.TxtSalidaConsumo)
        Me.GroupBox1.Controls.Add(Me.TxtSTraslado)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(13, 144)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(998, 123)
        Me.GroupBox1.TabIndex = 55
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Consumo de Reactivos por dia:"
        '
        'LblSolConsumo
        '
        Me.LblSolConsumo.AutoSize = True
        Me.LblSolConsumo.Location = New System.Drawing.Point(581, 97)
        Me.LblSolConsumo.Name = "LblSolConsumo"
        Me.LblSolConsumo.Size = New System.Drawing.Size(48, 16)
        Me.LblSolConsumo.TabIndex = 62
        Me.LblSolConsumo.Text = "Ruta2"
        '
        'LblSolTraslado
        '
        Me.LblSolTraslado.AutoSize = True
        Me.LblSolTraslado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblSolTraslado.Location = New System.Drawing.Point(494, 97)
        Me.LblSolTraslado.Name = "LblSolTraslado"
        Me.LblSolTraslado.Size = New System.Drawing.Size(50, 18)
        Me.LblSolTraslado.TabIndex = 61
        Me.LblSolTraslado.Text = "Ruta1"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Image = Global.Z_Lab.My.Resources.Resources.gradiente_cielo
        Me.Label10.Location = New System.Drawing.Point(550, 24)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(136, 16)
        Me.Label10.TabIndex = 60
        Me.Label10.Text = "Documentos Zeus:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(656, 49)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(111, 13)
        Me.Label6.TabIndex = 58
        Me.Label6.Text = "Salida x Consumo:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(370, 48)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(76, 16)
        Me.Label5.TabIndex = 57
        Me.Label5.Text = "Consumo:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(570, 48)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(74, 13)
        Me.Label3.TabIndex = 56
        Me.Label3.Text = "S.Consumo:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(482, 49)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(76, 13)
        Me.Label2.TabIndex = 55
        Me.Label2.Text = "S. Traslado:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(284, 48)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(66, 16)
        Me.Label1.TabIndex = 54
        Me.Label1.Text = "Entrada:"
        '
        'GroupBox3
        '
        Me.GroupBox3.Location = New System.Drawing.Point(13, 622)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(998, 100)
        Me.GroupBox3.TabIndex = 56
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Consumo por  Tiempos:"
        '
        'LblId
        '
        Me.LblId.AutoSize = True
        Me.LblId.Location = New System.Drawing.Point(964, 116)
        Me.LblId.Name = "LblId"
        Me.LblId.Size = New System.Drawing.Size(13, 13)
        Me.LblId.TabIndex = 57
        Me.LblId.Text = "--"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(570, 26)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(63, 24)
        Me.Label9.TabIndex = 58
        Me.Label9.Text = "Saldo:"
        '
        'LblSaldo
        '
        Me.LblSaldo.AutoSize = True
        Me.LblSaldo.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSaldo.Location = New System.Drawing.Point(656, 26)
        Me.LblSaldo.Name = "LblSaldo"
        Me.LblSaldo.Size = New System.Drawing.Size(63, 24)
        Me.LblSaldo.TabIndex = 59
        Me.LblSaldo.Text = "Saldo"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.LblNombreReactivo)
        Me.GroupBox4.Controls.Add(Me.Label12)
        Me.GroupBox4.Controls.Add(Me.Label9)
        Me.GroupBox4.Controls.Add(Me.LblSaldo)
        Me.GroupBox4.Location = New System.Drawing.Point(12, 273)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(999, 60)
        Me.GroupBox4.TabIndex = 60
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Stock"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(68, 26)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(161, 24)
        Me.Label12.TabIndex = 60
        Me.Label12.Text = "Nombre Reactivo:"
        '
        'LblNombreReactivo
        '
        Me.LblNombreReactivo.AutoSize = True
        Me.LblNombreReactivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblNombreReactivo.Location = New System.Drawing.Point(284, 26)
        Me.LblNombreReactivo.Name = "LblNombreReactivo"
        Me.LblNombreReactivo.Size = New System.Drawing.Size(71, 20)
        Me.LblNombreReactivo.TabIndex = 61
        Me.LblNombreReactivo.Text = "Nombre"
        '
        'FrmConsumoReactivos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightGoldenrodYellow
        Me.ClientSize = New System.Drawing.Size(1048, 750)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.LblId)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.DgReactivos)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.GroupBox2)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmConsumoReactivos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Consumo de Reactivos"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DgReactivos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
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
    Friend WithEvents TxtEntrada As System.Windows.Forms.TextBox
    Friend WithEvents TxtConsumo As System.Windows.Forms.TextBox
    Friend WithEvents TxtSalidaConsumo As System.Windows.Forms.TextBox
    Friend WithEvents TxtSTraslado As System.Windows.Forms.TextBox
    Friend WithEvents TxtSconsumo As System.Windows.Forms.TextBox
    Friend WithEvents CmbReactivo As System.Windows.Forms.ComboBox
    Friend WithEvents CmdGuardar As System.Windows.Forms.Button
    Friend WithEvents DgReactivos As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents LblId As System.Windows.Forms.Label
    Friend WithEvents LblSolConsumo As System.Windows.Forms.Label
    Friend WithEvents LblSolTraslado As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents LblSaldo As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents LblNombreReactivo As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
End Class
