<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCargarInstantaneas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmCargarInstantaneas))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.CmdGuardarJobno = New System.Windows.Forms.Button()
        Me.Cmbtipomuestra = New System.Windows.Forms.ComboBox()
        Me.CmdExaminar = New System.Windows.Forms.Button()
        Me.Txtruta = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.DGInstantaneas = New System.Windows.Forms.DataGridView()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.ServerTxt = New System.Windows.Forms.TextBox()
        Me.pswdTxt = New System.Windows.Forms.TextBox()
        Me.UsuarioTxt = New System.Windows.Forms.TextBox()
        Me.lsBD = New System.Windows.Forms.TextBox()
        Me.lblpuerto = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        CType(Me.DGInstantaneas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.CmdGuardarJobno)
        Me.GroupBox1.Controls.Add(Me.Cmbtipomuestra)
        Me.GroupBox1.Controls.Add(Me.CmdExaminar)
        Me.GroupBox1.Controls.Add(Me.Txtruta)
        Me.GroupBox1.Location = New System.Drawing.Point(43, 65)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(894, 100)
        Me.GroupBox1.TabIndex = 42
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Selecione el Archivo de Ecel:"
        '
        'CmdGuardarJobno
        '
        Me.CmdGuardarJobno.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdGuardarJobno.Location = New System.Drawing.Point(782, 15)
        Me.CmdGuardarJobno.Name = "CmdGuardarJobno"
        Me.CmdGuardarJobno.Size = New System.Drawing.Size(75, 70)
        Me.CmdGuardarJobno.TabIndex = 29
        Me.CmdGuardarJobno.Text = "Cargar"
        Me.CmdGuardarJobno.UseVisualStyleBackColor = True
        '
        'Cmbtipomuestra
        '
        Me.Cmbtipomuestra.Enabled = False
        Me.Cmbtipomuestra.FormattingEnabled = True
        Me.Cmbtipomuestra.Items.AddRange(New Object() {"Bandas", "Solución", "Sólido"})
        Me.Cmbtipomuestra.Location = New System.Drawing.Point(601, 41)
        Me.Cmbtipomuestra.Name = "Cmbtipomuestra"
        Me.Cmbtipomuestra.Size = New System.Drawing.Size(121, 21)
        Me.Cmbtipomuestra.TabIndex = 28
        '
        'CmdExaminar
        '
        Me.CmdExaminar.Location = New System.Drawing.Point(372, 39)
        Me.CmdExaminar.Name = "CmdExaminar"
        Me.CmdExaminar.Size = New System.Drawing.Size(75, 23)
        Me.CmdExaminar.TabIndex = 27
        Me.CmdExaminar.Text = "Seleccionar"
        Me.CmdExaminar.UseVisualStyleBackColor = True
        '
        'Txtruta
        '
        Me.Txtruta.Location = New System.Drawing.Point(38, 41)
        Me.Txtruta.Name = "Txtruta"
        Me.Txtruta.Size = New System.Drawing.Size(292, 20)
        Me.Txtruta.TabIndex = 26
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Lucida Calligraphy", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(395, 45)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(263, 17)
        Me.Label1.TabIndex = 41
        Me.Label1.Text = "Laboratorio Quimico Zandor Capital"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Lucida Calligraphy", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(336, 9)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(366, 27)
        Me.Label8.TabIndex = 40
        Me.Label8.Text = "Importar Analisis Instantaneas"
        '
        'DGInstantaneas
        '
        Me.DGInstantaneas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGInstantaneas.Location = New System.Drawing.Point(81, 218)
        Me.DGInstantaneas.Name = "DGInstantaneas"
        Me.DGInstantaneas.Size = New System.Drawing.Size(819, 150)
        Me.DGInstantaneas.TabIndex = 43
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(815, 186)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 44
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        Me.Button1.Visible = False
        '
        'ServerTxt
        '
        Me.ServerTxt.Location = New System.Drawing.Point(268, 192)
        Me.ServerTxt.Name = "ServerTxt"
        Me.ServerTxt.Size = New System.Drawing.Size(100, 20)
        Me.ServerTxt.TabIndex = 45
        Me.ServerTxt.Visible = False
        '
        'pswdTxt
        '
        Me.pswdTxt.Location = New System.Drawing.Point(535, 192)
        Me.pswdTxt.Name = "pswdTxt"
        Me.pswdTxt.Size = New System.Drawing.Size(100, 20)
        Me.pswdTxt.TabIndex = 46
        Me.pswdTxt.Visible = False
        '
        'UsuarioTxt
        '
        Me.UsuarioTxt.Location = New System.Drawing.Point(415, 192)
        Me.UsuarioTxt.Name = "UsuarioTxt"
        Me.UsuarioTxt.Size = New System.Drawing.Size(100, 20)
        Me.UsuarioTxt.TabIndex = 47
        Me.UsuarioTxt.Visible = False
        '
        'lsBD
        '
        Me.lsBD.Location = New System.Drawing.Point(665, 188)
        Me.lsBD.Name = "lsBD"
        Me.lsBD.Size = New System.Drawing.Size(100, 20)
        Me.lsBD.TabIndex = 48
        Me.lsBD.Visible = False
        '
        'lblpuerto
        '
        Me.lblpuerto.AutoSize = True
        Me.lblpuerto.Location = New System.Drawing.Point(188, 195)
        Me.lblpuerto.Name = "lblpuerto"
        Me.lblpuerto.Size = New System.Drawing.Size(31, 13)
        Me.lblpuerto.TabIndex = 49
        Me.lblpuerto.Text = "3306"
        Me.lblpuerto.Visible = False
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(81, 190)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 50
        Me.Button2.Text = "Listar"
        Me.Button2.UseVisualStyleBackColor = True
        Me.Button2.Visible = False
        '
        'FrmCargarInstantaneas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightGoldenrodYellow
        Me.ClientSize = New System.Drawing.Size(1022, 609)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.lblpuerto)
        Me.Controls.Add(Me.lsBD)
        Me.Controls.Add(Me.UsuarioTxt)
        Me.Controls.Add(Me.pswdTxt)
        Me.Controls.Add(Me.ServerTxt)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.DGInstantaneas)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label8)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmCargarInstantaneas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmCargarInstantaneas"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.DGInstantaneas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents CmdGuardarJobno As System.Windows.Forms.Button
    Friend WithEvents Cmbtipomuestra As System.Windows.Forms.ComboBox
    Friend WithEvents CmdExaminar As System.Windows.Forms.Button
    Friend WithEvents Txtruta As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents DGInstantaneas As System.Windows.Forms.DataGridView
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents ServerTxt As System.Windows.Forms.TextBox
    Friend WithEvents pswdTxt As System.Windows.Forms.TextBox
    Friend WithEvents UsuarioTxt As System.Windows.Forms.TextBox
    Friend WithEvents lsBD As System.Windows.Forms.TextBox
    Friend WithEvents lblpuerto As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
End Class
