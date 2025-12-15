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
        Me.SerialPort1 = New System.IO.Ports.SerialPort(Me.components)
        Me.ReadTimer = New System.Windows.Forms.Timer(Me.components)
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
        Me.CurrentTimeTextBox = New System.Windows.Forms.TextBox()
        Me.CurrentTimeLabel = New System.Windows.Forms.Label()
        Me.OperationTextBoxLabel = New System.Windows.Forms.Label()
        Me.OperationTextBox = New System.Windows.Forms.TextBox()
        Me.FanTextBox = New System.Windows.Forms.TextBox()
        Me.FanLabel = New System.Windows.Forms.Label()
        Me.HardwareTextBox = New System.Windows.Forms.TextBox()
        Me.HadwareTempTextBoxLabel = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.LowTempTextBox = New System.Windows.Forms.TextBox()
        Me.TargetTempLowLabel = New System.Windows.Forms.Label()
        Me.IncrementHighTempButton = New System.Windows.Forms.Button()
        Me.DecrementLowTempButton = New System.Windows.Forms.Button()
        Me.IncrementLowTempButton = New System.Windows.Forms.Button()
        Me.DecrementHighTempButton = New System.Windows.Forms.Button()
        Me.SafetyTimer = New System.Windows.Forms.Timer(Me.components)
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.SerialTimer = New System.Windows.Forms.Timer(Me.components)
        Me.ClockTextBox = New System.Windows.Forms.TextBox()
        Me.ClockLabel = New System.Windows.Forms.Label()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SerialPort1
        '
        '
        'ReadTimer
        '
        '
        'SetButton
        '
        Me.SetButton.Location = New System.Drawing.Point(738, 786)
        Me.SetButton.Name = "SetButton"
        Me.SetButton.Size = New System.Drawing.Size(104, 57)
        Me.SetButton.TabIndex = 3
        Me.SetButton.Text = "Set"
        Me.SetButton.UseVisualStyleBackColor = True
        '
        'ExitButton
        '
        Me.ExitButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ExitButton.Location = New System.Drawing.Point(807, 512)
        Me.ExitButton.Name = "ExitButton"
        Me.ExitButton.Size = New System.Drawing.Size(210, 87)
        Me.ExitButton.TabIndex = 4
        Me.ExitButton.Text = "Exit"
        Me.ExitButton.UseVisualStyleBackColor = True
        '
        'CurrentTempTextBox
        '
        Me.CurrentTempTextBox.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CurrentTempTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 25.0!)
        Me.CurrentTempTextBox.Location = New System.Drawing.Point(373, 280)
        Me.CurrentTempTextBox.Name = "CurrentTempTextBox"
        Me.CurrentTempTextBox.Size = New System.Drawing.Size(149, 64)
        Me.CurrentTempTextBox.TabIndex = 5
        '
        'SerialTextBox
        '
        Me.SerialTextBox.Location = New System.Drawing.Point(748, 637)
        Me.SerialTextBox.Multiline = True
        Me.SerialTextBox.Name = "SerialTextBox"
        Me.SerialTextBox.Size = New System.Drawing.Size(70, 57)
        Me.SerialTextBox.TabIndex = 6
        '
        'SetTempTextBox
        '
        Me.SetTempTextBox.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SetTempTextBox.Location = New System.Drawing.Point(373, 423)
        Me.SetTempTextBox.Name = "SetTempTextBox"
        Me.SetTempTextBox.Size = New System.Drawing.Size(100, 26)
        Me.SetTempTextBox.TabIndex = 7
        '
        'PortsComboBox
        '
        Me.PortsComboBox.FormattingEnabled = True
        Me.PortsComboBox.Location = New System.Drawing.Point(722, 801)
        Me.PortsComboBox.Name = "PortsComboBox"
        Me.PortsComboBox.Size = New System.Drawing.Size(121, 28)
        Me.PortsComboBox.TabIndex = 8
        '
        'ConnectionStatusLabel
        '
        Me.ConnectionStatusLabel.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ConnectionStatusLabel.AutoSize = True
        Me.ConnectionStatusLabel.Location = New System.Drawing.Point(12, 9)
        Me.ConnectionStatusLabel.Name = "ConnectionStatusLabel"
        Me.ConnectionStatusLabel.Size = New System.Drawing.Size(72, 20)
        Me.ConnectionStatusLabel.TabIndex = 9
        Me.ConnectionStatusLabel.Text = "Filler text"
        '
        'SerialTextBoxLabel
        '
        Me.SerialTextBoxLabel.AutoSize = True
        Me.SerialTextBoxLabel.Location = New System.Drawing.Point(734, 628)
        Me.SerialTextBoxLabel.Name = "SerialTextBoxLabel"
        Me.SerialTextBoxLabel.Size = New System.Drawing.Size(88, 20)
        Me.SerialTextBoxLabel.TabIndex = 10
        Me.SerialTextBoxLabel.Text = "Serial Data"
        '
        'COMPortLabel
        '
        Me.COMPortLabel.AutoSize = True
        Me.COMPortLabel.Location = New System.Drawing.Point(722, 768)
        Me.COMPortLabel.Name = "COMPortLabel"
        Me.COMPortLabel.Size = New System.Drawing.Size(86, 20)
        Me.COMPortLabel.TabIndex = 11
        Me.COMPortLabel.Text = "COM Ports"
        '
        'TargetTempLabel
        '
        Me.TargetTempLabel.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TargetTempLabel.AutoSize = True
        Me.TargetTempLabel.Location = New System.Drawing.Point(369, 400)
        Me.TargetTempLabel.Name = "TargetTempLabel"
        Me.TargetTempLabel.Size = New System.Drawing.Size(187, 20)
        Me.TargetTempLabel.TabIndex = 12
        Me.TargetTempLabel.Text = "Target Temperature High"
        '
        'CurrentTempTextBoxLabel
        '
        Me.CurrentTempTextBoxLabel.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CurrentTempTextBoxLabel.AutoSize = True
        Me.CurrentTempTextBoxLabel.Location = New System.Drawing.Point(369, 257)
        Me.CurrentTempTextBoxLabel.Name = "CurrentTempTextBoxLabel"
        Me.CurrentTempTextBoxLabel.Size = New System.Drawing.Size(153, 20)
        Me.CurrentTempTextBoxLabel.TabIndex = 13
        Me.CurrentTempTextBoxLabel.Text = "CurrentTemperature"
        '
        'DigitalInputsTextBox
        '
        Me.DigitalInputsTextBox.Location = New System.Drawing.Point(748, 716)
        Me.DigitalInputsTextBox.Name = "DigitalInputsTextBox"
        Me.DigitalInputsTextBox.Size = New System.Drawing.Size(113, 26)
        Me.DigitalInputsTextBox.TabIndex = 14
        '
        'DigitalInputTextBoxLabel
        '
        Me.DigitalInputTextBoxLabel.AutoSize = True
        Me.DigitalInputTextBoxLabel.Location = New System.Drawing.Point(748, 693)
        Me.DigitalInputTextBoxLabel.Name = "DigitalInputTextBoxLabel"
        Me.DigitalInputTextBoxLabel.Size = New System.Drawing.Size(102, 20)
        Me.DigitalInputTextBoxLabel.TabIndex = 15
        Me.DigitalInputTextBoxLabel.Text = "Digital Inputs"
        '
        'CurrentTimeTextBox
        '
        Me.CurrentTimeTextBox.Location = New System.Drawing.Point(836, 765)
        Me.CurrentTimeTextBox.Name = "CurrentTimeTextBox"
        Me.CurrentTimeTextBox.Size = New System.Drawing.Size(100, 26)
        Me.CurrentTimeTextBox.TabIndex = 17
        '
        'CurrentTimeLabel
        '
        Me.CurrentTimeLabel.AutoSize = True
        Me.CurrentTimeLabel.Location = New System.Drawing.Point(832, 733)
        Me.CurrentTimeLabel.Name = "CurrentTimeLabel"
        Me.CurrentTimeLabel.Size = New System.Drawing.Size(100, 20)
        Me.CurrentTimeLabel.TabIndex = 18
        Me.CurrentTimeLabel.Text = "Current Time"
        '
        'OperationTextBoxLabel
        '
        Me.OperationTextBoxLabel.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.OperationTextBoxLabel.AutoSize = True
        Me.OperationTextBoxLabel.Location = New System.Drawing.Point(757, 136)
        Me.OperationTextBoxLabel.Name = "OperationTextBoxLabel"
        Me.OperationTextBoxLabel.Size = New System.Drawing.Size(79, 20)
        Me.OperationTextBoxLabel.TabIndex = 19
        Me.OperationTextBoxLabel.Text = "Operation"
        '
        'OperationTextBox
        '
        Me.OperationTextBox.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.OperationTextBox.Location = New System.Drawing.Point(761, 162)
        Me.OperationTextBox.Name = "OperationTextBox"
        Me.OperationTextBox.Size = New System.Drawing.Size(100, 26)
        Me.OperationTextBox.TabIndex = 20
        '
        'FanTextBox
        '
        Me.FanTextBox.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FanTextBox.Location = New System.Drawing.Point(761, 223)
        Me.FanTextBox.Name = "FanTextBox"
        Me.FanTextBox.Size = New System.Drawing.Size(100, 26)
        Me.FanTextBox.TabIndex = 22
        '
        'FanLabel
        '
        Me.FanLabel.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FanLabel.AutoSize = True
        Me.FanLabel.Location = New System.Drawing.Point(757, 200)
        Me.FanLabel.Name = "FanLabel"
        Me.FanLabel.Size = New System.Drawing.Size(88, 20)
        Me.FanLabel.TabIndex = 23
        Me.FanLabel.Text = "Fan Status"
        '
        'HardwareTextBox
        '
        Me.HardwareTextBox.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.HardwareTextBox.Location = New System.Drawing.Point(373, 582)
        Me.HardwareTextBox.Name = "HardwareTextBox"
        Me.HardwareTextBox.Size = New System.Drawing.Size(100, 26)
        Me.HardwareTextBox.TabIndex = 26
        '
        'HadwareTempTextBoxLabel
        '
        Me.HadwareTempTextBoxLabel.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.HadwareTempTextBoxLabel.AutoSize = True
        Me.HadwareTempTextBoxLabel.Location = New System.Drawing.Point(369, 546)
        Me.HadwareTempTextBoxLabel.Name = "HadwareTempTextBoxLabel"
        Me.HadwareTempTextBoxLabel.Size = New System.Drawing.Size(173, 20)
        Me.HadwareTempTextBoxLabel.TabIndex = 27
        Me.HadwareTempTextBoxLabel.Text = "Hardware Temperature"
        '
        'LowTempTextBox
        '
        Me.LowTempTextBox.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LowTempTextBox.Location = New System.Drawing.Point(373, 493)
        Me.LowTempTextBox.Name = "LowTempTextBox"
        Me.LowTempTextBox.Size = New System.Drawing.Size(100, 26)
        Me.LowTempTextBox.TabIndex = 29
        '
        'TargetTempLowLabel
        '
        Me.TargetTempLowLabel.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TargetTempLowLabel.AutoSize = True
        Me.TargetTempLowLabel.Location = New System.Drawing.Point(369, 470)
        Me.TargetTempLowLabel.Name = "TargetTempLowLabel"
        Me.TargetTempLowLabel.Size = New System.Drawing.Size(183, 20)
        Me.TargetTempLowLabel.TabIndex = 30
        Me.TargetTempLowLabel.Text = "Target Temperature Low"
        '
        'IncrementHighTempButton
        '
        Me.IncrementHighTempButton.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.IncrementHighTempButton.Location = New System.Drawing.Point(325, 423)
        Me.IncrementHighTempButton.Name = "IncrementHighTempButton"
        Me.IncrementHighTempButton.Size = New System.Drawing.Size(42, 33)
        Me.IncrementHighTempButton.TabIndex = 31
        Me.IncrementHighTempButton.Text = "+"
        Me.IncrementHighTempButton.UseVisualStyleBackColor = True
        '
        'DecrementLowTempButton
        '
        Me.DecrementLowTempButton.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DecrementLowTempButton.Location = New System.Drawing.Point(486, 486)
        Me.DecrementLowTempButton.Name = "DecrementLowTempButton"
        Me.DecrementLowTempButton.Size = New System.Drawing.Size(43, 33)
        Me.DecrementLowTempButton.TabIndex = 32
        Me.DecrementLowTempButton.Text = "-"
        Me.DecrementLowTempButton.UseVisualStyleBackColor = True
        '
        'IncrementLowTempButton
        '
        Me.IncrementLowTempButton.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.IncrementLowTempButton.Location = New System.Drawing.Point(325, 489)
        Me.IncrementLowTempButton.Name = "IncrementLowTempButton"
        Me.IncrementLowTempButton.Size = New System.Drawing.Size(36, 26)
        Me.IncrementLowTempButton.TabIndex = 33
        Me.IncrementLowTempButton.Text = "+"
        Me.IncrementLowTempButton.UseVisualStyleBackColor = True
        '
        'DecrementHighTempButton
        '
        Me.DecrementHighTempButton.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DecrementHighTempButton.Location = New System.Drawing.Point(486, 423)
        Me.DecrementHighTempButton.Name = "DecrementHighTempButton"
        Me.DecrementHighTempButton.Size = New System.Drawing.Size(36, 26)
        Me.DecrementHighTempButton.TabIndex = 34
        Me.DecrementHighTempButton.Text = "-"
        Me.DecrementHighTempButton.UseVisualStyleBackColor = True
        '
        'SafetyTimer
        '
        Me.SafetyTimer.Interval = 30000
        '
        'PictureBox2
        '
        Me.PictureBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox2.Image = Global.HVACSmartHomeController.My.Resources.Resources.ISU_logo
        Me.PictureBox2.Location = New System.Drawing.Point(726, 628)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(275, 218)
        Me.PictureBox2.TabIndex = 25
        Me.PictureBox2.TabStop = False
        '
        'SerialTimer
        '
        '
        'ClockTextBox
        '
        Me.ClockTextBox.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ClockTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 30.0!)
        Me.ClockTextBox.Location = New System.Drawing.Point(234, 174)
        Me.ClockTextBox.Name = "ClockTextBox"
        Me.ClockTextBox.Size = New System.Drawing.Size(492, 75)
        Me.ClockTextBox.TabIndex = 36
        '
        'ClockLabel
        '
        Me.ClockLabel.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ClockLabel.AutoSize = True
        Me.ClockLabel.Location = New System.Drawing.Point(406, 138)
        Me.ClockLabel.Name = "ClockLabel"
        Me.ClockLabel.Size = New System.Drawing.Size(48, 20)
        Me.ClockLabel.TabIndex = 37
        Me.ClockLabel.Text = "Clock"
        '
        'HVAC
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1079, 883)
        Me.Controls.Add(Me.ClockLabel)
        Me.Controls.Add(Me.ClockTextBox)
        Me.Controls.Add(Me.DecrementHighTempButton)
        Me.Controls.Add(Me.IncrementLowTempButton)
        Me.Controls.Add(Me.DecrementLowTempButton)
        Me.Controls.Add(Me.IncrementHighTempButton)
        Me.Controls.Add(Me.TargetTempLowLabel)
        Me.Controls.Add(Me.LowTempTextBox)
        Me.Controls.Add(Me.HadwareTempTextBoxLabel)
        Me.Controls.Add(Me.HardwareTextBox)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.FanLabel)
        Me.Controls.Add(Me.FanTextBox)
        Me.Controls.Add(Me.OperationTextBox)
        Me.Controls.Add(Me.OperationTextBoxLabel)
        Me.Controls.Add(Me.CurrentTimeLabel)
        Me.Controls.Add(Me.CurrentTimeTextBox)
        Me.Controls.Add(Me.DigitalInputTextBoxLabel)
        Me.Controls.Add(Me.DigitalInputsTextBox)
        Me.Controls.Add(Me.CurrentTempTextBoxLabel)
        Me.Controls.Add(Me.TargetTempLabel)
        Me.Controls.Add(Me.COMPortLabel)
        Me.Controls.Add(Me.SerialTextBoxLabel)
        Me.Controls.Add(Me.ConnectionStatusLabel)
        Me.Controls.Add(Me.PortsComboBox)
        Me.Controls.Add(Me.SetTempTextBox)
        Me.Controls.Add(Me.CurrentTempTextBox)
        Me.Controls.Add(Me.ExitButton)
        Me.Controls.Add(Me.SetButton)
        Me.Controls.Add(Me.SerialTextBox)
        Me.Name = "HVAC"
        Me.Text = "Horsley HVAC"
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents SerialPort1 As IO.Ports.SerialPort
    Friend WithEvents ReadTimer As Timer
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
    Friend WithEvents CurrentTimeTextBox As TextBox
    Friend WithEvents CurrentTimeLabel As Label
    Friend WithEvents OperationTextBoxLabel As Label
    Friend WithEvents OperationTextBox As TextBox
    Friend WithEvents FanTextBox As TextBox
    Friend WithEvents FanLabel As Label
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents HardwareTextBox As TextBox
    Friend WithEvents HadwareTempTextBoxLabel As Label
    Friend WithEvents Timer1 As Timer
    Friend WithEvents LowTempTextBox As TextBox
    Friend WithEvents TargetTempLowLabel As Label
    Friend WithEvents IncrementHighTempButton As Button
    Friend WithEvents DecrementLowTempButton As Button
    Friend WithEvents IncrementLowTempButton As Button
    Friend WithEvents DecrementHighTempButton As Button
    Friend WithEvents SafetyTimer As Timer
    Friend WithEvents SerialTimer As Timer
    Friend WithEvents ClockTextBox As TextBox
    Friend WithEvents ClockLabel As Label
End Class
