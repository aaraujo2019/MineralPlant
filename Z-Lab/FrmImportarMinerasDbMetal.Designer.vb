<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmImportarMinerasDbMetal
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.CmdGuardarJobno = New System.Windows.Forms.Button()
        Me.Cmbtipomuestra = New System.Windows.Forms.ComboBox()
        Me.CmdExaminar = New System.Windows.Forms.Button()
        Me.Txtruta = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.DgMineras = New System.Windows.Forms.DataGridView()
        Me.GroupBox1.SuspendLayout()
        CType(Me.DgMineras, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.CmdGuardarJobno)
        Me.GroupBox1.Controls.Add(Me.Cmbtipomuestra)
        Me.GroupBox1.Controls.Add(Me.CmdExaminar)
        Me.GroupBox1.Controls.Add(Me.Txtruta)
        Me.GroupBox1.Location = New System.Drawing.Point(62, 85)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Size = New System.Drawing.Size(1192, 123)
        Me.GroupBox1.TabIndex = 45
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
        Me.Cmbtipomuestra.Enabled = False
        Me.Cmbtipomuestra.FormattingEnabled = True
        Me.Cmbtipomuestra.Items.AddRange(New Object() {"Bandas", "Solución", "Sólido"})
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
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Lucida Calligraphy", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(531, 61)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(394, 23)
        Me.Label1.TabIndex = 44
        Me.Label1.Text = "Hoja de Datos excel que exporta DbMetal"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Lucida Calligraphy", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(419, 9)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(585, 36)
        Me.Label8.TabIndex = 43
        Me.Label8.Text = "Ingreso de Tenores de Pequeña Mineria"
        '
        'DgMineras
        '
        Me.DgMineras.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgMineras.Location = New System.Drawing.Point(113, 215)
        Me.DgMineras.Name = "DgMineras"
        Me.DgMineras.RowTemplate.Height = 24
        Me.DgMineras.Size = New System.Drawing.Size(1092, 504)
        Me.DgMineras.TabIndex = 46
        '
        'FrmImportarMinerasDbMetal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightGoldenrodYellow
        Me.ClientSize = New System.Drawing.Size(1363, 750)
        Me.Controls.Add(Me.DgMineras)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label8)
        Me.Name = "FrmImportarMinerasDbMetal"
        Me.Text = "FrmImportarMinerasDbMetal"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.DgMineras, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents DgMineras As System.Windows.Forms.DataGridView
End Class
