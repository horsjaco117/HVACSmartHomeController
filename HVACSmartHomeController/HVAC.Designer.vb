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
        Me.COMButton.Location = New System.Drawing.Point(528, 106)
        Me.COMButton.Name = "COMButton"
        Me.COMButton.Size = New System.Drawing.Size(225, 61)
        Me.COMButton.TabIndex = 2
        Me.COMButton.Text = "COM"
        Me.COMButton.UseVisualStyleBackColor = True
        '
        'SetButton
        '
        Me.SetButton.Location = New System.Drawing.Point(528, 183)
        Me.SetButton.Name = "SetButton"
        Me.SetButton.Size = New System.Drawing.Size(225, 103)
        Me.SetButton.TabIndex = 3
        Me.SetButton.Text = "Set"
        Me.SetButton.UseVisualStyleBackColor = True
        '
        'ExitButton
        '
        Me.ExitButton.Location = New System.Drawing.Point(553, 331)
        Me.ExitButton.Name = "ExitButton"
        Me.ExitButton.Size = New System.Drawing.Size(210, 87)
        Me.ExitButton.TabIndex = 4
        Me.ExitButton.Text = "Exit"
        Me.ExitButton.UseVisualStyleBackColor = True
        '
        'CurrentTempTextBox
        '
        Me.CurrentTempTextBox.Location = New System.Drawing.Point(400, 315)
        Me.CurrentTempTextBox.Name = "CurrentTempTextBox"
        Me.CurrentTempTextBox.Size = New System.Drawing.Size(100, 26)
        Me.CurrentTempTextBox.TabIndex = 5
        '
        'SerialTextBox
        '
        Me.SerialTextBox.Location = New System.Drawing.Point(0, 75)
        Me.SerialTextBox.Multiline = True
        Me.SerialTextBox.Name = "SerialTextBox"
        Me.SerialTextBox.Size = New System.Drawing.Size(240, 26)
        Me.SerialTextBox.TabIndex = 6
        '
        'SetTempTextBox
        '
        Me.SetTempTextBox.Location = New System.Drawing.Point(413, 237)
        Me.SetTempTextBox.Name = "SetTempTextBox"
        Me.SetTempTextBox.Size = New System.Drawing.Size(100, 26)
        Me.SetTempTextBox.TabIndex = 7
        '
        'PortsComboBox
        '
        Me.PortsComboBox.FormattingEnabled = True
        Me.PortsComboBox.Location = New System.Drawing.Point(362, 106)
        Me.PortsComboBox.Name = "PortsComboBox"
        Me.PortsComboBox.Size = New System.Drawing.Size(121, 28)
        Me.PortsComboBox.TabIndex = 8
        '
        'ConnectionStatusLabel
        '
        Me.ConnectionStatusLabel.AutoSize = True
        Me.ConnectionStatusLabel.Location = New System.Drawing.Point(31, 9)
        Me.ConnectionStatusLabel.Name = "ConnectionStatusLabel"
        Me.ConnectionStatusLabel.Size = New System.Drawing.Size(108, 30)
        Me.ConnectionStatusLabel.TabIndex = 9
        Me.ConnectionStatusLabel.Text = "Filler text"
        '
        'HVAC
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
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
End Class
