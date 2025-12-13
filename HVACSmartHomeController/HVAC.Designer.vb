<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class HVAC
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(HVAC))
        Me.SerialPort1 = New System.IO.Ports.SerialPort(Me.components)
        Me.SerialPortsComboBox = New System.Windows.Forms.ComboBox()
        Me.SerialPortComboLabel = New System.Windows.Forms.Label()
        Me.ReadTimer = New System.Windows.Forms.Timer(Me.components)
        Me.COMButton = New System.Windows.Forms.Button()
        Me.SetButton = New System.Windows.Forms.Button()
        Me.ExitButton = New System.Windows.Forms.Button()
        Me.CurrentTempTextBox = New System.Windows.Forms.TextBox()
        Me.SerialTextBox = New System.Windows.Forms.TextBox()
        Me.SetTempTextBox = New System.Windows.Forms.TextBox()
        Me.PortsComboBox = New System.Windows.Forms.ComboBox()
        Me.ConnectionStatusLabel = New System.Windows.Forms.Label()
        Me.SerialTextBoxLabel = New System.Windows.Forms.Label()
        Me.COMPortLabel = New System.Windows.Forms.Label()
        Me.TargetTempLabel = New System.Windows.Forms.Label()
        Me.CurrentTempTextBoxLabel = New System.Windows.Forms.Label()
        Me.DigitalInputsTextBox = New System.Windows.Forms.TextBox()
        Me.DigitalInputTextBoxLabel = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.CurrentTimeTextBox = New System.Windows.Forms.TextBox()
        Me.CurrentTimeLabel = New System.Windows.Forms.Label()
        Me.OperationTextBoxLabel = New System.Windows.Forms.Label()
        Me.OperationTextBox = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.FanTextBox = New System.Windows.Forms.TextBox()
        Me.FanLabel = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.HardwareTextBox = New System.Windows.Forms.TextBox()
        Me.HadwareTempTextBoxLabel = New System.Windows.Forms.Label()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.CommunicationToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.ExitToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.SaveSettingsToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.LowTempTextBox = New System.Windows.Forms.TextBox()
        Me.TargetTempLowLabel = New System.Windows.Forms.Label()
        Me.IncrementHighTempButton = New System.Windows.Forms.Button()
        Me.DecrementLowTempButton = New System.Windows.Forms.Button()
        Me.IncrementLowTempButton = New System.Windows.Forms.Button()
        Me.DecrementHighTempButton = New System.Windows.Forms.Button()
        Me.SafetyTimer = New System.Windows.Forms.Timer(Me.components)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'SerialPort1
        '
        '
        'SerialPortsComboBox
        '
        Me.SerialPortsComboBox.FormattingEnabled = True
        Me.SerialPortsComboBox.Location = New System.Drawing.Point(12, 263)
        Me.SerialPortsComboBox.Name = "SerialPortsComboBox"
        Me.SerialPortsComboBox.Size = New System.Drawing.Size(121, 28)
        Me.SerialPortsComboBox.TabIndex = 0
        '
        'SerialPortComboLabel
        '
        Me.SerialPortComboLabel.AutoSize = True
        Me.SerialPortComboLabel.Location = New System.Drawing.Point(8, 240)
        Me.SerialPortComboLabel.Name = "SerialPortComboLabel"
        Me.SerialPortComboLabel.Size = New System.Drawing.Size(78, 20)
        Me.SerialPortComboLabel.TabIndex = 1
        Me.SerialPortComboLabel.Text = "COM Port"
        '
        'ReadTimer
        '
        '
        'COMButton
        '
        Me.COMButton.Location = New System.Drawing.Point(153, 587)
        Me.COMButton.Name = "COMButton"
        Me.COMButton.Size = New System.Drawing.Size(225, 61)
        Me.COMButton.TabIndex = 2
        Me.COMButton.Text = "COM"
        Me.COMButton.UseVisualStyleBackColor = True
        '
        'SetButton
        '
        Me.SetButton.Location = New System.Drawing.Point(803, 60)
        Me.SetButton.Name = "SetButton"
        Me.SetButton.Size = New System.Drawing.Size(104, 57)
        Me.SetButton.TabIndex = 3
        Me.SetButton.Text = "Set"
        Me.SetButton.UseVisualStyleBackColor = True
        '
        'ExitButton
        '
        Me.ExitButton.Location = New System.Drawing.Point(1254, 727)
        Me.ExitButton.Name = "ExitButton"
        Me.ExitButton.Size = New System.Drawing.Size(210, 87)
        Me.ExitButton.TabIndex = 4
        Me.ExitButton.Text = "Exit"
        Me.ExitButton.UseVisualStyleBackColor = True
        '
        'CurrentTempTextBox
        '
        Me.CurrentTempTextBox.Location = New System.Drawing.Point(598, 197)
        Me.CurrentTempTextBox.Name = "CurrentTempTextBox"
        Me.CurrentTempTextBox.Size = New System.Drawing.Size(100, 26)
        Me.CurrentTempTextBox.TabIndex = 5
        '
        'SerialTextBox
        '
        Me.SerialTextBox.Location = New System.Drawing.Point(0, 75)
        Me.SerialTextBox.Multiline = True
        Me.SerialTextBox.Name = "SerialTextBox"
        Me.SerialTextBox.Size = New System.Drawing.Size(505, 123)
        Me.SerialTextBox.TabIndex = 6
        '
        'SetTempTextBox
        '
        Me.SetTempTextBox.Location = New System.Drawing.Point(598, 75)
        Me.SetTempTextBox.Name = "SetTempTextBox"
        Me.SetTempTextBox.Size = New System.Drawing.Size(100, 26)
        Me.SetTempTextBox.TabIndex = 7
        '
        'PortsComboBox
        '
        Me.PortsComboBox.FormattingEnabled = True
        Me.PortsComboBox.Location = New System.Drawing.Point(12, 587)
        Me.PortsComboBox.Name = "PortsComboBox"
        Me.PortsComboBox.Size = New System.Drawing.Size(121, 28)
        Me.PortsComboBox.TabIndex = 8
        '
        'ConnectionStatusLabel
        '
        Me.ConnectionStatusLabel.AutoSize = True
        Me.ConnectionStatusLabel.Location = New System.Drawing.Point(31, 9)
        Me.ConnectionStatusLabel.Name = "ConnectionStatusLabel"
        Me.ConnectionStatusLabel.Size = New System.Drawing.Size(72, 20)
        Me.ConnectionStatusLabel.TabIndex = 9
        Me.ConnectionStatusLabel.Text = "Filler text"
        '
        'SerialTextBoxLabel
        '
        Me.SerialTextBoxLabel.AutoSize = True
        Me.SerialTextBoxLabel.Location = New System.Drawing.Point(8, 52)
        Me.SerialTextBoxLabel.Name = "SerialTextBoxLabel"
        Me.SerialTextBoxLabel.Size = New System.Drawing.Size(88, 20)
        Me.SerialTextBoxLabel.TabIndex = 10
        Me.SerialTextBoxLabel.Text = "Serial Data"
        '
        'COMPortLabel
        '
        Me.COMPortLabel.AutoSize = True
        Me.COMPortLabel.Location = New System.Drawing.Point(12, 554)
        Me.COMPortLabel.Name = "COMPortLabel"
        Me.COMPortLabel.Size = New System.Drawing.Size(86, 20)
        Me.COMPortLabel.TabIndex = 11
        Me.COMPortLabel.Text = "COM Ports"
        '
        'TargetTempLabel
        '
        Me.TargetTempLabel.AutoSize = True
        Me.TargetTempLabel.Location = New System.Drawing.Point(594, 52)
        Me.TargetTempLabel.Name = "TargetTempLabel"
        Me.TargetTempLabel.Size = New System.Drawing.Size(187, 20)
        Me.TargetTempLabel.TabIndex = 12
        Me.TargetTempLabel.Text = "Target Temperature High"
        '
        'CurrentTempTextBoxLabel
        '
        Me.CurrentTempTextBoxLabel.AutoSize = True
        Me.CurrentTempTextBoxLabel.Location = New System.Drawing.Point(594, 174)
        Me.CurrentTempTextBoxLabel.Name = "CurrentTempTextBoxLabel"
        Me.CurrentTempTextBoxLabel.Size = New System.Drawing.Size(153, 20)
        Me.CurrentTempTextBoxLabel.TabIndex = 13
        Me.CurrentTempTextBoxLabel.Text = "CurrentTemperature"
        '
        'DigitalInputsTextBox
        '
        Me.DigitalInputsTextBox.Location = New System.Drawing.Point(12, 331)
        Me.DigitalInputsTextBox.Name = "DigitalInputsTextBox"
        Me.DigitalInputsTextBox.Size = New System.Drawing.Size(113, 26)
        Me.DigitalInputsTextBox.TabIndex = 14
        '
        'DigitalInputTextBoxLabel
        '
        Me.DigitalInputTextBoxLabel.AutoSize = True
        Me.DigitalInputTextBoxLabel.Location = New System.Drawing.Point(12, 308)
        Me.DigitalInputTextBoxLabel.Name = "DigitalInputTextBoxLabel"
        Me.DigitalInputTextBoxLabel.Size = New System.Drawing.Size(102, 20)
        Me.DigitalInputTextBoxLabel.TabIndex = 15
        Me.DigitalInputTextBoxLabel.Text = "Digital Inputs"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(1250, 684)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(57, 20)
        Me.Label2.TabIndex = 16
        Me.Label2.Text = "Label2"
        '
        'CurrentTimeTextBox
        '
        Me.CurrentTimeTextBox.Location = New System.Drawing.Point(917, 62)
        Me.CurrentTimeTextBox.Name = "CurrentTimeTextBox"
        Me.CurrentTimeTextBox.Size = New System.Drawing.Size(100, 26)
        Me.CurrentTimeTextBox.TabIndex = 17
        '
        'CurrentTimeLabel
        '
        Me.CurrentTimeLabel.AutoSize = True
        Me.CurrentTimeLabel.Location = New System.Drawing.Point(913, 30)
        Me.CurrentTimeLabel.Name = "CurrentTimeLabel"
        Me.CurrentTimeLabel.Size = New System.Drawing.Size(100, 20)
        Me.CurrentTimeLabel.TabIndex = 18
        Me.CurrentTimeLabel.Text = "Current Time"
        '
        'OperationTextBoxLabel
        '
        Me.OperationTextBoxLabel.AutoSize = True
        Me.OperationTextBoxLabel.Location = New System.Drawing.Point(913, 266)
        Me.OperationTextBoxLabel.Name = "OperationTextBoxLabel"
        Me.OperationTextBoxLabel.Size = New System.Drawing.Size(79, 20)
        Me.OperationTextBoxLabel.TabIndex = 19
        Me.OperationTextBoxLabel.Text = "Operation"
        '
        'OperationTextBox
        '
        Me.OperationTextBox.Location = New System.Drawing.Point(917, 292)
        Me.OperationTextBox.Name = "OperationTextBox"
        Me.OperationTextBox.Size = New System.Drawing.Size(100, 26)
        Me.OperationTextBox.TabIndex = 20
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(240, 331)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(172, 20)
        Me.Label1.TabIndex = 21
        Me.Label1.Text = "D2 Cooling D5 Heating"
        '
        'FanTextBox
        '
        Me.FanTextBox.Location = New System.Drawing.Point(917, 397)
        Me.FanTextBox.Name = "FanTextBox"
        Me.FanTextBox.Size = New System.Drawing.Size(100, 26)
        Me.FanTextBox.TabIndex = 22
        '
        'FanLabel
        '
        Me.FanLabel.AutoSize = True
        Me.FanLabel.Location = New System.Drawing.Point(913, 374)
        Me.FanLabel.Name = "FanLabel"
        Me.FanLabel.Size = New System.Drawing.Size(88, 20)
        Me.FanLabel.TabIndex = 23
        Me.FanLabel.Text = "Fan Status"
        '
        'PictureBox1
        '
        Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(100, 50)
        Me.PictureBox1.TabIndex = 24
        Me.PictureBox1.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = Global.HVACSmartHomeController.My.Resources.Resources.ISU_logo
        Me.PictureBox2.Location = New System.Drawing.Point(738, 628)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(275, 218)
        Me.PictureBox2.TabIndex = 25
        Me.PictureBox2.TabStop = False
        '
        'HardwareTextBox
        '
        Me.HardwareTextBox.Location = New System.Drawing.Point(917, 148)
        Me.HardwareTextBox.Name = "HardwareTextBox"
        Me.HardwareTextBox.Size = New System.Drawing.Size(100, 26)
        Me.HardwareTextBox.TabIndex = 26
        '
        'HadwareTempTextBoxLabel
        '
        Me.HadwareTempTextBoxLabel.AutoSize = True
        Me.HadwareTempTextBoxLabel.Location = New System.Drawing.Point(913, 112)
        Me.HadwareTempTextBoxLabel.Name = "HadwareTempTextBoxLabel"
        Me.HadwareTempTextBoxLabel.Size = New System.Drawing.Size(173, 20)
        Me.HadwareTempTextBoxLabel.TabIndex = 27
        Me.HadwareTempTextBoxLabel.Text = "Hardware Temperature"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CommunicationToolStripButton, Me.ExitToolStripButton, Me.SaveSettingsToolStripButton})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1620, 33)
        Me.ToolStrip1.TabIndex = 28
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'CommunicationToolStripButton
        '
        Me.CommunicationToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.CommunicationToolStripButton.Image = CType(resources.GetObject("CommunicationToolStripButton.Image"), System.Drawing.Image)
        Me.CommunicationToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.CommunicationToolStripButton.Name = "CommunicationToolStripButton"
        Me.CommunicationToolStripButton.Size = New System.Drawing.Size(34, 28)
        Me.CommunicationToolStripButton.Text = "COM Setup"
        '
        'ExitToolStripButton
        '
        Me.ExitToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ExitToolStripButton.Image = CType(resources.GetObject("ExitToolStripButton.Image"), System.Drawing.Image)
        Me.ExitToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ExitToolStripButton.Name = "ExitToolStripButton"
        Me.ExitToolStripButton.Size = New System.Drawing.Size(34, 28)
        Me.ExitToolStripButton.Text = "Exit"
        '
        'SaveSettingsToolStripButton
        '
        Me.SaveSettingsToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.SaveSettingsToolStripButton.Image = CType(resources.GetObject("SaveSettingsToolStripButton.Image"), System.Drawing.Image)
        Me.SaveSettingsToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.SaveSettingsToolStripButton.Name = "SaveSettingsToolStripButton"
        Me.SaveSettingsToolStripButton.Size = New System.Drawing.Size(34, 28)
        Me.SaveSettingsToolStripButton.Text = "ToolStripButton3"
        '
        'LowTempTextBox
        '
        Me.LowTempTextBox.Location = New System.Drawing.Point(598, 145)
        Me.LowTempTextBox.Name = "LowTempTextBox"
        Me.LowTempTextBox.Size = New System.Drawing.Size(100, 26)
        Me.LowTempTextBox.TabIndex = 29
        '
        'TargetTempLowLabel
        '
        Me.TargetTempLowLabel.AutoSize = True
        Me.TargetTempLowLabel.Location = New System.Drawing.Point(594, 122)
        Me.TargetTempLowLabel.Name = "TargetTempLowLabel"
        Me.TargetTempLowLabel.Size = New System.Drawing.Size(183, 20)
        Me.TargetTempLowLabel.TabIndex = 30
        Me.TargetTempLowLabel.Text = "Target Temperature Low"
        '
        'IncrementHighTempButton
        '
        Me.IncrementHighTempButton.Location = New System.Drawing.Point(550, 75)
        Me.IncrementHighTempButton.Name = "IncrementHighTempButton"
        Me.IncrementHighTempButton.Size = New System.Drawing.Size(42, 33)
        Me.IncrementHighTempButton.TabIndex = 31
        Me.IncrementHighTempButton.Text = "+"
        Me.IncrementHighTempButton.UseVisualStyleBackColor = True
        '
        'DecrementLowTempButton
        '
        Me.DecrementLowTempButton.Location = New System.Drawing.Point(711, 138)
        Me.DecrementLowTempButton.Name = "DecrementLowTempButton"
        Me.DecrementLowTempButton.Size = New System.Drawing.Size(43, 33)
        Me.DecrementLowTempButton.TabIndex = 32
        Me.DecrementLowTempButton.Text = "-"
        Me.DecrementLowTempButton.UseVisualStyleBackColor = True
        '
        'IncrementLowTempButton
        '
        Me.IncrementLowTempButton.Location = New System.Drawing.Point(550, 141)
        Me.IncrementLowTempButton.Name = "IncrementLowTempButton"
        Me.IncrementLowTempButton.Size = New System.Drawing.Size(36, 26)
        Me.IncrementLowTempButton.TabIndex = 33
        Me.IncrementLowTempButton.Text = "+"
        Me.IncrementLowTempButton.UseVisualStyleBackColor = True
        '
        'DecrementHighTempButton
        '
        Me.DecrementHighTempButton.Location = New System.Drawing.Point(711, 75)
        Me.DecrementHighTempButton.Name = "DecrementHighTempButton"
        Me.DecrementHighTempButton.Size = New System.Drawing.Size(36, 26)
        Me.DecrementHighTempButton.TabIndex = 34
        Me.DecrementHighTempButton.Text = "-"
        Me.DecrementHighTempButton.UseVisualStyleBackColor = True
        '
        'SafetyTimer
        '
        Me.SafetyTimer.Interval = 3000
        '
        'HVAC
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1620, 884)
        Me.Controls.Add(Me.DecrementHighTempButton)
        Me.Controls.Add(Me.IncrementLowTempButton)
        Me.Controls.Add(Me.DecrementLowTempButton)
        Me.Controls.Add(Me.IncrementHighTempButton)
        Me.Controls.Add(Me.TargetTempLowLabel)
        Me.Controls.Add(Me.LowTempTextBox)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.HadwareTempTextBoxLabel)
        Me.Controls.Add(Me.HardwareTextBox)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.FanLabel)
        Me.Controls.Add(Me.FanTextBox)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.OperationTextBox)
        Me.Controls.Add(Me.OperationTextBoxLabel)
        Me.Controls.Add(Me.CurrentTimeLabel)
        Me.Controls.Add(Me.CurrentTimeTextBox)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.DigitalInputTextBoxLabel)
        Me.Controls.Add(Me.DigitalInputsTextBox)
        Me.Controls.Add(Me.CurrentTempTextBoxLabel)
        Me.Controls.Add(Me.TargetTempLabel)
        Me.Controls.Add(Me.COMPortLabel)
        Me.Controls.Add(Me.SerialTextBoxLabel)
        Me.Controls.Add(Me.ConnectionStatusLabel)
        Me.Controls.Add(Me.PortsComboBox)
        Me.Controls.Add(Me.SetTempTextBox)
        Me.Controls.Add(Me.SerialTextBox)
        Me.Controls.Add(Me.CurrentTempTextBox)
        Me.Controls.Add(Me.ExitButton)
        Me.Controls.Add(Me.SetButton)
        Me.Controls.Add(Me.COMButton)
        Me.Controls.Add(Me.SerialPortComboLabel)
        Me.Controls.Add(Me.SerialPortsComboBox)
        Me.Name = "HVAC"
        Me.Text = "HVAC"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents SerialPort1 As IO.Ports.SerialPort
    Friend WithEvents SerialPortsComboBox As ComboBox
    Friend WithEvents SerialPortComboLabel As Label
    Friend WithEvents ReadTimer As Timer
    Friend WithEvents COMButton As Button
    Friend WithEvents SetButton As Button
    Friend WithEvents ExitButton As Button
    Friend WithEvents CurrentTempTextBox As TextBox
    Friend WithEvents SerialTextBox As TextBox
    Friend WithEvents SetTempTextBox As TextBox
    Friend WithEvents PortsComboBox As ComboBox
    Friend WithEvents ConnectionStatusLabel As Label
    Friend WithEvents SerialTextBoxLabel As Label
    Friend WithEvents COMPortLabel As Label
    Friend WithEvents TargetTempLabel As Label
    Friend WithEvents CurrentTempTextBoxLabel As Label
    Friend WithEvents DigitalInputsTextBox As TextBox
    Friend WithEvents DigitalInputTextBoxLabel As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents CurrentTimeTextBox As TextBox
    Friend WithEvents CurrentTimeLabel As Label
    Friend WithEvents OperationTextBoxLabel As Label
    Friend WithEvents OperationTextBox As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents FanTextBox As TextBox
    Friend WithEvents FanLabel As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents HardwareTextBox As TextBox
    Friend WithEvents HadwareTempTextBoxLabel As Label
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents CommunicationToolStripButton As ToolStripButton
    Friend WithEvents ExitToolStripButton As ToolStripButton
    Friend WithEvents SaveSettingsToolStripButton As ToolStripButton
    Friend WithEvents Timer1 As Timer
    Friend WithEvents LowTempTextBox As TextBox
    Friend WithEvents TargetTempLowLabel As Label
    Friend WithEvents IncrementHighTempButton As Button
    Friend WithEvents DecrementLowTempButton As Button
    Friend WithEvents IncrementLowTempButton As Button
    Friend WithEvents DecrementHighTempButton As Button
    Friend WithEvents SafetyTimer As Timer
End Class
