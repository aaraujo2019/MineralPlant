<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmAssayLabZandor
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmAssayLabZandor))
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.CmdGuardarJobno = New System.Windows.Forms.Button()
        Me.Cmbtipomuestra = New System.Windows.Forms.ComboBox()
        Me.CmdExaminar = New System.Windows.Forms.Button()
        Me.Txtruta = New System.Windows.Forms.TextBox()
        Me.DgOrdenLab = New System.Windows.Forms.DataGridView()
        Me.GroupBox1.SuspendLayout()
        CType(Me.DgOrdenLab, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Lucida Calligraphy", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(397, 39)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(427, 36)
        Me.Label8.TabIndex = 34
        Me.Label8.Text = "Ingreso de Analisis Quimicos"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Lucida Calligraphy", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(431, 84)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(338, 23)
        Me.Label1.TabIndex = 35
        Me.Label1.Text = "Laboratorio Quimico Zandor Capital"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.CmdGuardarJobno)
        Me.GroupBox1.Controls.Add(Me.Cmbtipomuestra)
        Me.GroupBox1.Controls.Add(Me.CmdExaminar)
        Me.GroupBox1.Controls.Add(Me.Txtruta)
        Me.GroupBox1.Location = New System.Drawing.Point(16, 170)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Size = New System.Drawing.Size(1192, 123)
        Me.GroupBox1.TabIndex = 36
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Selecione el Archivo de Ecel:"
        '
        'CmdGuardarJobno
        '
        Me.CmdGuardarJobno.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdGuardarJobno.Location = New System.Drawing.Point(1043, 18)
        Me.CmdGuardarJobno.Margin = New System.Windows.Forms.Padding(4)
        Me.CmdGuardarJobno.Name = "CmdGuardarJobno"
        Me.CmdGuardarJobno.Size = New System.Drawing.Size(100, 86)
        Me.CmdGuardarJobno.TabIndex = 29
        Me.CmdGuardarJobno.Text = "Cargar"
        Me.CmdGuardarJobno.UseVisualStyleBackColor = True
        '
        'Cmbtipomuestra
        '
        Me.Cmbtipomuestra.FormattingEnabled = True
        Me.Cmbtipomuestra.Items.AddRange(New Object() {"Solución", "Sólido"})
        Me.Cmbtipomuestra.Location = New System.Drawing.Point(801, 50)
        Me.Cmbtipomuestra.Margin = New System.Windows.Forms.Padding(4)
        Me.Cmbtipomuestra.Name = "Cmbtipomuestra"
        Me.Cmbtipomuestra.Size = New System.Drawing.Size(160, 24)
        Me.Cmbtipomuestra.TabIndex = 28
        '
        'CmdExaminar
        '
        Me.CmdExaminar.Location = New System.Drawing.Point(496, 48)
        Me.CmdExaminar.Margin = New System.Windows.Forms.Padding(4)
        Me.CmdExaminar.Name = "CmdExaminar"
        Me.CmdExaminar.Size = New System.Drawing.Size(100, 28)
        Me.CmdExaminar.TabIndex = 27
        Me.CmdExaminar.Text = "Seleccionar"
        Me.CmdExaminar.UseVisualStyleBackColor = True
        '
        'Txtruta
        '
        Me.Txtruta.Location = New System.Drawing.Point(51, 50)
        Me.Txtruta.Margin = New System.Windows.Forms.Padding(4)
        Me.Txtruta.Name = "Txtruta"
        Me.Txtruta.Size = New System.Drawing.Size(388, 22)
        Me.Txtruta.TabIndex = 26
        '
        'DgOrdenLab
        '
        Me.DgOrdenLab.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgOrdenLab.Location = New System.Drawing.Point(21, 335)
        Me.DgOrdenLab.Margin = New System.Windows.Forms.Padding(4)
        Me.DgOrdenLab.Name = "DgOrdenLab"
        Me.DgOrdenLab.Size = New System.Drawing.Size(1325, 374)
        Me.DgOrdenLab.TabIndex = 37
        '
        'FrmAssayLabZandor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightGoldenrodYellow
        Me.ClientSize = New System.Drawing.Size(1363, 750)
        Me.Controls.Add(Me.DgOrdenLab)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label8)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "FrmAssayLabZandor"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Analisis Quimico Laboratorio Quimico Zandor Capital"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.DgOrdenLab, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents CmdGuardarJobno As System.Windows.Forms.Button
    Friend WithEvents Cmbtipomuestra As System.Windows.Forms.ComboBox
    Friend WithEvents CmdExaminar As System.Windows.Forms.Button
    Friend WithEvents Txtruta As System.Windows.Forms.TextBox
    Friend WithEvents DgOrdenLab As System.Windows.Forms.DataGridView
End Class
