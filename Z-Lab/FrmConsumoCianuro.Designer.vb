<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmConsumoCianuro
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmConsumoCianuro))
        Me.Label8 = New System.Windows.Forms.Label()
        Me.LblArea = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.LblUsuario = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.DgConsumoCianuro = New System.Windows.Forms.DataGridView()
        Me.DtInicio = New System.Windows.Forms.DateTimePicker()
        Me.DtFinal = New System.Windows.Forms.DateTimePicker()
        Me.CmdBuscar = New System.Windows.Forms.Button()
        Me.CmbUbicacion = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.LblKgCN = New System.Windows.Forms.Label()
        Me.LblPromedioNacn = New System.Windows.Forms.Label()
        Me.LblNaCN = New System.Windows.Forms.Label()
        Me.LblPromedioCn = New System.Windows.Forms.Label()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DgConsumoCianuro, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Lucida Calligraphy", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(415, 21)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(309, 36)
        Me.Label8.TabIndex = 39
        Me.Label8.Text = "Consumo de Cianuro"
        '
        'LblArea
        '
        Me.LblArea.AutoSize = True
        Me.LblArea.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblArea.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.LblArea.Location = New System.Drawing.Point(417, 106)
        Me.LblArea.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblArea.Name = "LblArea"
        Me.LblArea.Size = New System.Drawing.Size(57, 17)
        Me.LblArea.TabIndex = 38
        Me.LblArea.Text = "Label6"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(227, 106)
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
        Me.LblUsuario.Location = New System.Drawing.Point(417, 74)
        Me.LblUsuario.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblUsuario.Name = "LblUsuario"
        Me.LblUsuario.Size = New System.Drawing.Size(57, 17)
        Me.LblUsuario.TabIndex = 36
        Me.LblUsuario.Text = "Label5"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(227, 74)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(80, 17)
        Me.Label3.TabIndex = 35
        Me.Label3.Text = "Id. Usuario:"
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = Global.Z_Lab.My.Resources.Resources.LogoGranColombiaGoldSmall
        Me.PictureBox2.Location = New System.Drawing.Point(807, 67)
        Me.PictureBox2.Margin = New System.Windows.Forms.Padding(4)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(276, 62)
        Me.PictureBox2.TabIndex = 34
        Me.PictureBox2.TabStop = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Location = New System.Drawing.Point(167, 54)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Size = New System.Drawing.Size(1075, 79)
        Me.GroupBox2.TabIndex = 40
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Datos de Usuario:"
        '
        'DgConsumoCianuro
        '
        Me.DgConsumoCianuro.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgConsumoCianuro.Location = New System.Drawing.Point(167, 276)
        Me.DgConsumoCianuro.Name = "DgConsumoCianuro"
        Me.DgConsumoCianuro.RowTemplate.Height = 24
        Me.DgConsumoCianuro.Size = New System.Drawing.Size(1075, 357)
        Me.DgConsumoCianuro.TabIndex = 41
        '
        'DtInicio
        '
        Me.DtInicio.Location = New System.Drawing.Point(230, 209)
        Me.DtInicio.Name = "DtInicio"
        Me.DtInicio.Size = New System.Drawing.Size(200, 22)
        Me.DtInicio.TabIndex = 42
        '
        'DtFinal
        '
        Me.DtFinal.Location = New System.Drawing.Point(451, 209)
        Me.DtFinal.Name = "DtFinal"
        Me.DtFinal.Size = New System.Drawing.Size(200, 22)
        Me.DtFinal.TabIndex = 43
        '
        'CmdBuscar
        '
        Me.CmdBuscar.Location = New System.Drawing.Point(1008, 208)
        Me.CmdBuscar.Name = "CmdBuscar"
        Me.CmdBuscar.Size = New System.Drawing.Size(75, 23)
        Me.CmdBuscar.TabIndex = 44
        Me.CmdBuscar.Text = "Buscar"
        Me.CmdBuscar.UseVisualStyleBackColor = True
        '
        'CmbUbicacion
        '
        Me.CmbUbicacion.FormattingEnabled = True
        Me.CmbUbicacion.Location = New System.Drawing.Point(698, 207)
        Me.CmbUbicacion.Name = "CmbUbicacion"
        Me.CmbUbicacion.Size = New System.Drawing.Size(253, 24)
        Me.CmbUbicacion.TabIndex = 45
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 19.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(347, 682)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(104, 38)
        Me.Label1.TabIndex = 46
        Me.Label1.Text = "Total:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(495, 650)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(76, 25)
        Me.Label2.TabIndex = 47
        Me.Label2.Text = "Kg CN"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(853, 650)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(103, 25)
        Me.Label4.TabIndex = 48
        Me.Label4.Text = "Kg NaCN"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(628, 650)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(147, 25)
        Me.Label5.TabIndex = 49
        Me.Label5.Text = "Promedio Dia."
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(1045, 650)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(147, 25)
        Me.Label6.TabIndex = 50
        Me.Label6.Text = "Promedio Dia."
        '
        'LblKgCN
        '
        Me.LblKgCN.AutoSize = True
        Me.LblKgCN.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblKgCN.Location = New System.Drawing.Point(512, 709)
        Me.LblKgCN.Name = "LblKgCN"
        Me.LblKgCN.Size = New System.Drawing.Size(54, 25)
        Me.LblKgCN.TabIndex = 51
        Me.LblKgCN.Text = "------"
        '
        'LblPromedioNacn
        '
        Me.LblPromedioNacn.AutoSize = True
        Me.LblPromedioNacn.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblPromedioNacn.Location = New System.Drawing.Point(1081, 709)
        Me.LblPromedioNacn.Name = "LblPromedioNacn"
        Me.LblPromedioNacn.Size = New System.Drawing.Size(54, 25)
        Me.LblPromedioNacn.TabIndex = 52
        Me.LblPromedioNacn.Text = "------"
        '
        'LblNaCN
        '
        Me.LblNaCN.AutoSize = True
        Me.LblNaCN.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblNaCN.Location = New System.Drawing.Point(853, 709)
        Me.LblNaCN.Name = "LblNaCN"
        Me.LblNaCN.Size = New System.Drawing.Size(54, 25)
        Me.LblNaCN.TabIndex = 53
        Me.LblNaCN.Text = "------"
        '
        'LblPromedioCn
        '
        Me.LblPromedioCn.AutoSize = True
        Me.LblPromedioCn.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblPromedioCn.Location = New System.Drawing.Point(651, 709)
        Me.LblPromedioCn.Name = "LblPromedioCn"
        Me.LblPromedioCn.Size = New System.Drawing.Size(54, 25)
        Me.LblPromedioCn.TabIndex = 54
        Me.LblPromedioCn.Text = "------"
        '
        'FrmConsumoCianuro
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightGoldenrodYellow
        Me.ClientSize = New System.Drawing.Size(1432, 784)
        Me.Controls.Add(Me.LblPromedioCn)
        Me.Controls.Add(Me.LblNaCN)
        Me.Controls.Add(Me.LblPromedioNacn)
        Me.Controls.Add(Me.LblKgCN)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.CmbUbicacion)
        Me.Controls.Add(Me.CmdBuscar)
        Me.Controls.Add(Me.DtFinal)
        Me.Controls.Add(Me.DtInicio)
        Me.Controls.Add(Me.DgConsumoCianuro)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.LblArea)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.LblUsuario)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.GroupBox2)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmConsumoCianuro"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Consumo Diario de Cianuro"
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DgConsumoCianuro, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents DgConsumoCianuro As System.Windows.Forms.DataGridView
    Friend WithEvents DtInicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents DtFinal As System.Windows.Forms.DateTimePicker
    Friend WithEvents CmdBuscar As System.Windows.Forms.Button
    Friend WithEvents CmbUbicacion As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents LblKgCN As System.Windows.Forms.Label
    Friend WithEvents LblPromedioNacn As System.Windows.Forms.Label
    Friend WithEvents LblNaCN As System.Windows.Forms.Label
    Friend WithEvents LblPromedioCn As System.Windows.Forms.Label
End Class
