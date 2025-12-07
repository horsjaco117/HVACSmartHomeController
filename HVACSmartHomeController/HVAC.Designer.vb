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
        Me.SetButton.Location = New System.Drawing.Point(689, 75)
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
        Me.CurrentTempTextBox.Location = New System.Drawing.Point(532, 197)
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
        Me.SetTempTextBox.Location = New System.Drawing.Point(532, 75)
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
        Me.TargetTempLabel.Location = New System.Drawing.Point(528, 52)
        Me.TargetTempLabel.Name = "TargetTempLabel"
        Me.TargetTempLabel.Size = New System.Drawing.Size(150, 20)
        Me.TargetTempLabel.TabIndex = 12
        Me.TargetTempLabel.Text = "Target Temperature"
        '
        'CurrentTempTextBoxLabel
        '
        Me.CurrentTempTextBoxLabel.AutoSize = True
        Me.CurrentTempTextBoxLabel.Location = New System.Drawing.Point(528, 174)
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
        Me.Label1.Size = New System.Drawing.Size(258, 30)
        Me.Label1.TabIndex = 21
        Me.Label1.Text = "D2 Cooling D5 Heating"
        '
        'HVAC
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1620, 884)
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
End Class
