<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmAssayMineralPlant
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmAssayMineralPlant))
        Me.DgOrdenLab = New System.Windows.Forms.DataGridView()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.CmdGuardarJobno = New System.Windows.Forms.Button()
        Me.Cmbtipomuestra = New System.Windows.Forms.ComboBox()
        Me.CmdExaminar = New System.Windows.Forms.Button()
        Me.Txtruta = New System.Windows.Forms.TextBox()
        CType(Me.DgOrdenLab, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'DgOrdenLab
        '
        Me.DgOrdenLab.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgOrdenLab.Location = New System.Drawing.Point(14, 244)
        Me.DgOrdenLab.Name = "DgOrdenLab"
        Me.DgOrdenLab.Size = New System.Drawing.Size(994, 304)
        Me.DgOrdenLab.TabIndex = 23
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Lucida Calligraphy", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(308, 46)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(330, 27)
        Me.Label8.TabIndex = 33
        Me.Label8.Text = "Ingreso de Analisis Quimicos"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.CmdGuardarJobno)
        Me.GroupBox1.Controls.Add(Me.Cmbtipomuestra)
        Me.GroupBox1.Controls.Add(Me.CmdExaminar)
        Me.GroupBox1.Controls.Add(Me.Txtruta)
        Me.GroupBox1.Location = New System.Drawing.Point(32, 111)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(894, 100)
        Me.GroupBox1.TabIndex = 34
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
        'FrmAssayMineralPlant
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightGoldenrodYellow
        Me.ClientSize = New System.Drawing.Size(1022, 609)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.DgOrdenLab)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "FrmAssayMineralPlant"
        Me.Text = "Ingreso de Analisis Quimicos"
        CType(Me.DgOrdenLab, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DgOrdenLab As System.Windows.Forms.DataGridView
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents CmdGuardarJobno As System.Windows.Forms.Button
    Friend WithEvents Cmbtipomuestra As System.Windows.Forms.ComboBox
    Friend WithEvents CmdExaminar As System.Windows.Forms.Button
    Friend WithEvents Txtruta As System.Windows.Forms.TextBox
End Class
