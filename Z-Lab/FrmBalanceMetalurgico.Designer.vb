<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmBalanceMetalurgico
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmBalanceMetalurgico))
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.cmbmes = New System.Windows.Forms.ComboBox()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.cmbano = New System.Windows.Forms.ComboBox()
        Me.DtFecha1 = New System.Windows.Forms.DateTimePicker()
        Me.DtFecha2 = New System.Windows.Forms.DateTimePicker()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.CmdBuscar = New System.Windows.Forms.Button()
        Me.cmbperiodo2 = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TxtInvInicial = New System.Windows.Forms.TextBox()
        Me.TxtInvFinal = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.LblArea = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.LblUsuario = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.LblRecuperacionCalculadaBFisico = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.LblAuRecuperadoFisico = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.LblAuBFisico = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.LblAuFundido = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.LblPorcRecuperacion = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.LblOroRecuperado = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.LblTenorColas = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.LblAlimentoMolino = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.LblToneladas = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.LblTenorMolino = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.LblTenorCalculadoBFisico = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.DgBalanceFisico = New System.Windows.Forms.DataGridView()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.DgBalanceFisico, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Controls.Add(Me.Label37)
        Me.GroupBox3.Controls.Add(Me.Label32)
        Me.GroupBox3.Controls.Add(Me.Label36)
        Me.GroupBox3.Controls.Add(Me.cmbmes)
        Me.GroupBox3.Controls.Add(Me.Label31)
        Me.GroupBox3.Controls.Add(Me.cmbano)
        Me.GroupBox3.Controls.Add(Me.DtFecha1)
        Me.GroupBox3.Controls.Add(Me.DtFecha2)
        Me.GroupBox3.Controls.Add(Me.Button1)
        Me.GroupBox3.Controls.Add(Me.Label38)
        Me.GroupBox3.Controls.Add(Me.CmdBuscar)
        Me.GroupBox3.Controls.Add(Me.cmbperiodo2)
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Controls.Add(Me.TxtInvInicial)
        Me.GroupBox3.Controls.Add(Me.TxtInvFinal)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Location = New System.Drawing.Point(25, 142)
        Me.GroupBox3.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox3.Size = New System.Drawing.Size(1333, 115)
        Me.GroupBox3.TabIndex = 87
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Consultar Periodo:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(462, 48)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(55, 17)
        Me.Label3.TabIndex = 94
        Me.Label3.Text = "Inicial:"
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label37.Location = New System.Drawing.Point(760, 45)
        Me.Label37.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(42, 17)
        Me.Label37.TabIndex = 93
        Me.Label37.Text = "Mes:"
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label32.Location = New System.Drawing.Point(8, 46)
        Me.Label32.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(104, 17)
        Me.Label32.TabIndex = 91
        Me.Label32.Text = "Fecha Inicial:"
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label36.Location = New System.Drawing.Point(652, 45)
        Me.Label36.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(41, 17)
        Me.Label36.TabIndex = 92
        Me.Label36.Text = "Año:"
        '
        'cmbmes
        '
        Me.cmbmes.FormattingEnabled = True
        Me.cmbmes.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12"})
        Me.cmbmes.Location = New System.Drawing.Point(755, 67)
        Me.cmbmes.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbmes.Name = "cmbmes"
        Me.cmbmes.Size = New System.Drawing.Size(105, 24)
        Me.cmbmes.TabIndex = 91
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.Location = New System.Drawing.Point(237, 45)
        Me.Label31.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(97, 17)
        Me.Label31.TabIndex = 90
        Me.Label31.Text = "Fecha Final:"
        '
        'cmbano
        '
        Me.cmbano.FormattingEnabled = True
        Me.cmbano.Location = New System.Drawing.Point(642, 67)
        Me.cmbano.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbano.Name = "cmbano"
        Me.cmbano.Size = New System.Drawing.Size(105, 24)
        Me.cmbano.TabIndex = 90
        '
        'DtFecha1
        '
        Me.DtFecha1.Location = New System.Drawing.Point(11, 67)
        Me.DtFecha1.Margin = New System.Windows.Forms.Padding(4)
        Me.DtFecha1.Name = "DtFecha1"
        Me.DtFecha1.Size = New System.Drawing.Size(206, 22)
        Me.DtFecha1.TabIndex = 89
        '
        'DtFecha2
        '
        Me.DtFecha2.Location = New System.Drawing.Point(240, 69)
        Me.DtFecha2.Margin = New System.Windows.Forms.Padding(4)
        Me.DtFecha2.Name = "DtFecha2"
        Me.DtFecha2.Size = New System.Drawing.Size(199, 22)
        Me.DtFecha2.TabIndex = 88
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(1219, 39)
        Me.Button1.Margin = New System.Windows.Forms.Padding(4)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(100, 50)
        Me.Button1.TabIndex = 87
        Me.Button1.Text = "Modificar"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label38.Location = New System.Drawing.Point(873, 45)
        Me.Label38.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(69, 17)
        Me.Label38.TabIndex = 85
        Me.Label38.Text = "Periodo:"
        '
        'CmdBuscar
        '
        Me.CmdBuscar.Location = New System.Drawing.Point(1079, 61)
        Me.CmdBuscar.Margin = New System.Windows.Forms.Padding(4)
        Me.CmdBuscar.Name = "CmdBuscar"
        Me.CmdBuscar.Size = New System.Drawing.Size(100, 28)
        Me.CmdBuscar.TabIndex = 86
        Me.CmdBuscar.Text = "Buscar:"
        Me.CmdBuscar.UseVisualStyleBackColor = True
        '
        'cmbperiodo2
        '
        Me.cmbperiodo2.FormattingEnabled = True
        Me.cmbperiodo2.Items.AddRange(New Object() {"PERIODO1", "PERIODO2", "PERIODO3", "PERIODO4", "PERIODO5"})
        Me.cmbperiodo2.Location = New System.Drawing.Point(876, 67)
        Me.cmbperiodo2.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbperiodo2.Name = "cmbperiodo2"
        Me.cmbperiodo2.Size = New System.Drawing.Size(105, 24)
        Me.cmbperiodo2.TabIndex = 81
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(548, 46)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 17)
        Me.Label2.TabIndex = 92
        Me.Label2.Text = "Final:"
        '
        'TxtInvInicial
        '
        Me.TxtInvInicial.Enabled = False
        Me.TxtInvInicial.Location = New System.Drawing.Point(462, 68)
        Me.TxtInvInicial.Name = "TxtInvInicial"
        Me.TxtInvInicial.Size = New System.Drawing.Size(70, 22)
        Me.TxtInvInicial.TabIndex = 89
        '
        'TxtInvFinal
        '
        Me.TxtInvFinal.Enabled = False
        Me.TxtInvFinal.Location = New System.Drawing.Point(538, 69)
        Me.TxtInvFinal.Name = "TxtInvFinal"
        Me.TxtInvFinal.Size = New System.Drawing.Size(70, 22)
        Me.TxtInvFinal.TabIndex = 90
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(482, 19)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(114, 25)
        Me.Label1.TabIndex = 91
        Me.Label1.Text = "Inventario:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Lucida Calligraphy", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(223, 15)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(822, 36)
        Me.Label8.TabIndex = 85
        Me.Label8.Text = "Balance Metalùrgico - Planta de Beneficio Maria Dama"
        '
        'LblArea
        '
        Me.LblArea.AutoSize = True
        Me.LblArea.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblArea.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.LblArea.Location = New System.Drawing.Point(347, 107)
        Me.LblArea.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblArea.Name = "LblArea"
        Me.LblArea.Size = New System.Drawing.Size(57, 17)
        Me.LblArea.TabIndex = 84
        Me.LblArea.Text = "Label6"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(156, 107)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(102, 17)
        Me.Label7.TabIndex = 83
        Me.Label7.Text = "Departamento:"
        '
        'LblUsuario
        '
        Me.LblUsuario.AutoSize = True
        Me.LblUsuario.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblUsuario.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.LblUsuario.Location = New System.Drawing.Point(347, 75)
        Me.LblUsuario.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblUsuario.Name = "LblUsuario"
        Me.LblUsuario.Size = New System.Drawing.Size(57, 17)
        Me.LblUsuario.TabIndex = 82
        Me.LblUsuario.Text = "Label5"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(156, 75)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(80, 17)
        Me.Label4.TabIndex = 81
        Me.Label4.Text = "Id. Usuario:"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.PictureBox1)
        Me.GroupBox2.Location = New System.Drawing.Point(25, 55)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Size = New System.Drawing.Size(1333, 79)
        Me.GroupBox2.TabIndex = 86
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Datos de Usuario:"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.Z_Lab.My.Resources.Resources.LogoGranColombiaGoldSmall
        Me.PictureBox1.Location = New System.Drawing.Point(916, 14)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(276, 62)
        Me.PictureBox1.TabIndex = 27
        Me.PictureBox1.TabStop = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label29)
        Me.GroupBox1.Controls.Add(Me.LblRecuperacionCalculadaBFisico)
        Me.GroupBox1.Controls.Add(Me.Label28)
        Me.GroupBox1.Controls.Add(Me.Label27)
        Me.GroupBox1.Controls.Add(Me.Label25)
        Me.GroupBox1.Controls.Add(Me.LblAuRecuperadoFisico)
        Me.GroupBox1.Controls.Add(Me.Label23)
        Me.GroupBox1.Controls.Add(Me.LblAuBFisico)
        Me.GroupBox1.Controls.Add(Me.Label21)
        Me.GroupBox1.Controls.Add(Me.LblAuFundido)
        Me.GroupBox1.Controls.Add(Me.Label19)
        Me.GroupBox1.Controls.Add(Me.LblPorcRecuperacion)
        Me.GroupBox1.Controls.Add(Me.Label17)
        Me.GroupBox1.Controls.Add(Me.LblOroRecuperado)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.LblTenorColas)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.LblAlimentoMolino)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.LblToneladas)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.LblTenorMolino)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.LblTenorCalculadoBFisico)
        Me.GroupBox1.Location = New System.Drawing.Point(36, 284)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1291, 183)
        Me.GroupBox1.TabIndex = 88
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Datos del Balance:"
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Font = New System.Drawing.Font("Bodoni MT Condensed", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.Location = New System.Drawing.Point(1139, 64)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(120, 20)
        Me.Label29.TabIndex = 116
        Me.Label29.Text = "% de Recuperacion"
        '
        'LblRecuperacionCalculadaBFisico
        '
        Me.LblRecuperacionCalculadaBFisico.AutoSize = True
        Me.LblRecuperacionCalculadaBFisico.BackColor = System.Drawing.Color.GreenYellow
        Me.LblRecuperacionCalculadaBFisico.Font = New System.Drawing.Font("Bodoni MT Condensed", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblRecuperacionCalculadaBFisico.Location = New System.Drawing.Point(1176, 89)
        Me.LblRecuperacionCalculadaBFisico.Name = "LblRecuperacionCalculadaBFisico"
        Me.LblRecuperacionCalculadaBFisico.Size = New System.Drawing.Size(45, 36)
        Me.LblRecuperacionCalculadaBFisico.TabIndex = 115
        Me.LblRecuperacionCalculadaBFisico.Text = "000"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("Arial Rounded MT Bold", 13.8!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.Location = New System.Drawing.Point(854, 38)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(181, 28)
        Me.Label28.TabIndex = 114
        Me.Label28.Text = "Balance Fisico"
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Arial Rounded MT Bold", 13.8!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.Location = New System.Drawing.Point(238, 38)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(201, 28)
        Me.Label27.TabIndex = 89
        Me.Label27.Text = "Balance Teorico"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Bodoni MT Condensed", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(911, 66)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(101, 20)
        Me.Label25.TabIndex = 113
        Me.Label25.Text = "Oro Recuperado"
        '
        'LblAuRecuperadoFisico
        '
        Me.LblAuRecuperadoFisico.AutoSize = True
        Me.LblAuRecuperadoFisico.Font = New System.Drawing.Font("Bodoni MT Condensed", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblAuRecuperadoFisico.Location = New System.Drawing.Point(933, 89)
        Me.LblAuRecuperadoFisico.Name = "LblAuRecuperadoFisico"
        Me.LblAuRecuperadoFisico.Size = New System.Drawing.Size(45, 36)
        Me.LblAuRecuperadoFisico.TabIndex = 112
        Me.LblAuRecuperadoFisico.Text = "000"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Bodoni MT Condensed", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(794, 66)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(90, 20)
        Me.Label23.TabIndex = 111
        Me.Label23.Text = "Oro Procesado"
        '
        'LblAuBFisico
        '
        Me.LblAuBFisico.AutoSize = True
        Me.LblAuBFisico.Font = New System.Drawing.Font("Bodoni MT Condensed", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblAuBFisico.Location = New System.Drawing.Point(814, 89)
        Me.LblAuBFisico.Name = "LblAuBFisico"
        Me.LblAuBFisico.Size = New System.Drawing.Size(45, 36)
        Me.LblAuBFisico.TabIndex = 110
        Me.LblAuBFisico.Text = "000"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Bodoni MT Condensed", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(689, 64)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(91, 23)
        Me.Label21.TabIndex = 109
        Me.Label21.Text = "Oro Fundido"
        '
        'LblAuFundido
        '
        Me.LblAuFundido.AutoSize = True
        Me.LblAuFundido.BackColor = System.Drawing.Color.Yellow
        Me.LblAuFundido.Font = New System.Drawing.Font("Bodoni MT Condensed", 22.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblAuFundido.Location = New System.Drawing.Point(703, 89)
        Me.LblAuFundido.Name = "LblAuFundido"
        Me.LblAuFundido.Size = New System.Drawing.Size(59, 45)
        Me.LblAuFundido.TabIndex = 108
        Me.LblAuFundido.Text = "000"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Bodoni MT Condensed", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(555, 66)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(120, 20)
        Me.Label19.TabIndex = 107
        Me.Label19.Text = "% de Recuperacion"
        '
        'LblPorcRecuperacion
        '
        Me.LblPorcRecuperacion.AutoSize = True
        Me.LblPorcRecuperacion.Font = New System.Drawing.Font("Bodoni MT Condensed", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblPorcRecuperacion.Location = New System.Drawing.Point(592, 89)
        Me.LblPorcRecuperacion.Name = "LblPorcRecuperacion"
        Me.LblPorcRecuperacion.Size = New System.Drawing.Size(45, 36)
        Me.LblPorcRecuperacion.TabIndex = 106
        Me.LblPorcRecuperacion.Text = "000"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Bodoni MT Condensed", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(439, 66)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(101, 20)
        Me.Label17.TabIndex = 105
        Me.Label17.Text = "Oro Recuperado"
        '
        'LblOroRecuperado
        '
        Me.LblOroRecuperado.AutoSize = True
        Me.LblOroRecuperado.BackColor = System.Drawing.Color.Chartreuse
        Me.LblOroRecuperado.Font = New System.Drawing.Font("Bodoni MT Condensed", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblOroRecuperado.Location = New System.Drawing.Point(459, 89)
        Me.LblOroRecuperado.Name = "LblOroRecuperado"
        Me.LblOroRecuperado.Size = New System.Drawing.Size(45, 36)
        Me.LblOroRecuperado.TabIndex = 104
        Me.LblOroRecuperado.Text = "000"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Bodoni MT Condensed", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(349, 66)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(74, 20)
        Me.Label15.TabIndex = 103
        Me.Label15.Text = "Tenor Colas"
        '
        'LblTenorColas
        '
        Me.LblTenorColas.AutoSize = True
        Me.LblTenorColas.Font = New System.Drawing.Font("Bodoni MT Condensed", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTenorColas.Location = New System.Drawing.Point(360, 89)
        Me.LblTenorColas.Name = "LblTenorColas"
        Me.LblTenorColas.Size = New System.Drawing.Size(45, 36)
        Me.LblTenorColas.TabIndex = 102
        Me.LblTenorColas.Text = "000"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Bodoni MT Condensed", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(114, 66)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(97, 20)
        Me.Label13.TabIndex = 101
        Me.Label13.Text = "Oro Alimentado"
        '
        'LblAlimentoMolino
        '
        Me.LblAlimentoMolino.AutoSize = True
        Me.LblAlimentoMolino.Font = New System.Drawing.Font("Bodoni MT Condensed", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblAlimentoMolino.Location = New System.Drawing.Point(132, 89)
        Me.LblAlimentoMolino.Name = "LblAlimentoMolino"
        Me.LblAlimentoMolino.Size = New System.Drawing.Size(45, 36)
        Me.LblAlimentoMolino.TabIndex = 100
        Me.LblAlimentoMolino.Text = "000"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Bodoni MT Condensed", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(25, 66)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(66, 20)
        Me.Label11.TabIndex = 99
        Me.Label11.Text = "Toneladas"
        '
        'LblToneladas
        '
        Me.LblToneladas.AutoSize = True
        Me.LblToneladas.Font = New System.Drawing.Font("Bodoni MT Condensed", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblToneladas.Location = New System.Drawing.Point(36, 89)
        Me.LblToneladas.Name = "LblToneladas"
        Me.LblToneladas.Size = New System.Drawing.Size(45, 36)
        Me.LblToneladas.TabIndex = 98
        Me.LblToneladas.Text = "000"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Bodoni MT Condensed", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(226, 66)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(98, 20)
        Me.Label9.TabIndex = 97
        Me.Label9.Text = "Tenor Molienda"
        '
        'LblTenorMolino
        '
        Me.LblTenorMolino.AutoSize = True
        Me.LblTenorMolino.Font = New System.Drawing.Font("Bodoni MT Condensed", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTenorMolino.Location = New System.Drawing.Point(252, 89)
        Me.LblTenorMolino.Name = "LblTenorMolino"
        Me.LblTenorMolino.Size = New System.Drawing.Size(45, 36)
        Me.LblTenorMolino.TabIndex = 96
        Me.LblTenorMolino.Text = "000"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Bodoni MT Condensed", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(1029, 66)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(104, 20)
        Me.Label6.TabIndex = 95
        Me.Label6.Text = "Tenor Calculado "
        '
        'LblTenorCalculadoBFisico
        '
        Me.LblTenorCalculadoBFisico.AutoSize = True
        Me.LblTenorCalculadoBFisico.Font = New System.Drawing.Font("Bodoni MT Condensed", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTenorCalculadoBFisico.Location = New System.Drawing.Point(1056, 89)
        Me.LblTenorCalculadoBFisico.Name = "LblTenorCalculadoBFisico"
        Me.LblTenorCalculadoBFisico.Size = New System.Drawing.Size(45, 36)
        Me.LblTenorCalculadoBFisico.TabIndex = 94
        Me.LblTenorCalculadoBFisico.Text = "000"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.DgBalanceFisico)
        Me.GroupBox4.Location = New System.Drawing.Point(36, 473)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(1291, 428)
        Me.GroupBox4.TabIndex = 89
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Resumen Balance "
        '
        'DgBalanceFisico
        '
        Me.DgBalanceFisico.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgBalanceFisico.Location = New System.Drawing.Point(29, 21)
        Me.DgBalanceFisico.Name = "DgBalanceFisico"
        Me.DgBalanceFisico.RowTemplate.Height = 24
        Me.DgBalanceFisico.Size = New System.Drawing.Size(1238, 385)
        Me.DgBalanceFisico.TabIndex = 0
        '
        'FrmBalanceMetalurgico
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightGoldenrodYellow
        Me.ClientSize = New System.Drawing.Size(1371, 923)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.LblArea)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.LblUsuario)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.GroupBox2)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmBalanceMetalurgico"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Balance Metalurgico"
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        CType(Me.DgBalanceFisico, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents CmdBuscar As System.Windows.Forms.Button
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents cmbperiodo2 As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents LblArea As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents LblUsuario As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtInvFinal As System.Windows.Forms.TextBox
    Friend WithEvents TxtInvInicial As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents LblTenorCalculadoBFisico As System.Windows.Forms.Label
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents LblRecuperacionCalculadaBFisico As System.Windows.Forms.Label
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents LblAuRecuperadoFisico As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents LblAuBFisico As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents LblAuFundido As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents LblPorcRecuperacion As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents LblOroRecuperado As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents LblTenorColas As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents LblAlimentoMolino As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents LblToneladas As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents LblTenorMolino As System.Windows.Forms.Label
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents DtFecha1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents DtFecha2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents DgBalanceFisico As System.Windows.Forms.DataGridView
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents cmbmes As System.Windows.Forms.ComboBox
    Friend WithEvents cmbano As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
End Class
