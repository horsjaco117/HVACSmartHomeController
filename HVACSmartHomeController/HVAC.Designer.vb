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
        Me.SuspendLayout()
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
        'HVAC
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.SerialPortComboLabel)
        Me.Controls.Add(Me.SerialPortsComboBox)
        Me.Name = "HVAC"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents SerialPort1 As IO.Ports.SerialPort
    Friend WithEvents SerialPortsComboBox As ComboBox
    Friend WithEvents SerialPortComboLabel As Label
End Class
