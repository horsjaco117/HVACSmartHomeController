' Jacob Horsley
' RCET 0265
' Spring 2025
' URL: https://github.com/horsjaco117/ThermostatControl 
' Modified from GraphicsExamples to control a thermostat via serial communication
Option Strict On
Option Explicit On

Imports System.Media
Imports System.Threading.Thread
Imports System.Runtime.CompilerServices
' Serial communications imports
Imports System.IO.Ports
Imports System.Net.Configuration

Public Class HVAC


    ' Serial Communications----------------------------------------------------------
    Sub SetDefaults() ' Set's default serial pieces and shows COM ports
        SerialPort1.Close() ' Closes the COM ports but adds settings
        ConnectionStatusLabel.Text = "No connection" ' No connect until port chosen
        GetPorts() ' Shows available ports
    End Sub

    Sub GetPorts()
        Dim ports() = SerialPort.GetPortNames() ' Available ports (note: fixed to SerialPort.GetPortNames)

        PortsComboBox.Items.Clear() ' Clears the ports

        For Each port In ports ' For every port available add it to the combobox
            PortsComboBox.Items.Add(port)
        Next

        Try
            PortsComboBox.SelectedIndex = 0
        Catch ex As Exception
            ' No results
        End Try
    End Sub

    Sub AutoConnect()
        GetPorts() ' Get available ports
        For Each port As String In PortsComboBox.Items
            PortsComboBox.SelectedItem = port
            Try
                connect()
                write() ' Send handshake
                Sleep(200) ' Brief delay to allow response
                If SerialPort1.IsOpen AndAlso IsQuietBoard() Then
                    ConnectionStatusLabel.Text = $"Connected automatically on {SerialPort1.PortName}"
                    Exit For ' Successful connection, stop trying other ports
                Else
                    SerialPort1.Close()
                End If
            Catch ex As Exception
                ' Skip invalid port
            End Try
        Next
        If Not SerialPort1.IsOpen Then
            ConnectionStatusLabel.Text = "Auto-connect failed. Try manual connect."
        End If
    End Sub

    Sub connect()
        SerialPort1.Close() ' Closes the ports 
        Try  ' All these are serial port settings. 
            SerialPort1.BaudRate = 115200
            SerialPort1.Parity = Parity.None
            SerialPort1.StopBits = StopBits.One
            SerialPort1.DataBits = 8
            SerialPort1.PortName = CStr(PortsComboBox.SelectedItem)
            SerialPort1.Open()
        Catch ex As Exception
            MsgBox(ex.Message)
            SetDefaults()
        End Try
    End Sub

    Sub send(data() As Byte)
        SerialPort1.ReadExisting()
        SerialPort1.Write(data, 0, UBound(data) + 1) ' Fixed to include full array length
    End Sub

    Function recieve() As Byte() ' For every byte received it will be displayed as the data variable
        Dim data(SerialPort1.BytesToRead - 1) As Byte ' Fixed indexing
        SerialPort1.Read(data, 0, SerialPort1.BytesToRead)
        Return data
    End Function

    ' Write handshake
    Sub write() ' This write sub is especially for handshaking
        Dim data(0) As Byte
        data(0) = &B11110000
        SerialPort1.Write(data, 0, 1)
    End Sub

    Private Sub COMButton_Click(sender As Object, e As EventArgs) Handles COMButton.Click
        ' Establishes the com between the device (manual connect fallback)
        connect()
        write()
    End Sub



    Sub RequestAllAnalogInputs()
        If Not SerialPort1.IsOpen Then Exit Sub

        Dim cmd(0) As Byte
        cmd(0) = &H51        ' This command returns ALL analog channels (8 values)
        SerialPort1.Write(cmd, 0, 1)
    End Sub

    Sub ReadTemperatureAndDigital()
        If Not SerialPort1.IsOpen Then Exit Sub

        ' Request analog (this gives you TWO channels — AN0 and AN1)
        Dim cmdAnalog(0) As Byte
        cmdAnalog(0) = &H53
        SerialPort1.Write(cmdAnalog, 0, 1)

        ' Request digital inputs
        Dim cmdDigital(0) As Byte
        cmdDigital(0) = &H30
        SerialPort1.Write(cmdDigital, 0, 1)
    End Sub

    ' Add this at the very top of your class (with the other fields)
    Private ReadAnalogNext As Boolean = True   ' True = send &H53, False = send &H30

    Private Sub ReadTimer_Tick(sender As Object, e As EventArgs) Handles ReadTimer.Tick
        If Not SerialPort1.IsOpen Then Exit Sub

        ' ONLY send &H30 — this gives us BOTH digital + analog in one packet!
        Dim cmd(0) As Byte
        cmd(0) = &H30
        SerialPort1.Write(cmd, 0, 1)
        CurrentTimeTextBox.Text = DateTime.Now.ToString("hh:mm:ss tt")
    End Sub

    Private Sub SerialPort1_DataReceived(sender As Object, e As SerialDataReceivedEventArgs) Handles SerialPort1.DataReceived
        Try
            Dim bytesToRead As Integer = SerialPort1.BytesToRead
            If bytesToRead < 4 Then Exit Sub

            Dim buffer(bytesToRead - 1) As Byte
            SerialPort1.Read(buffer, 0, bytesToRead)

            ' Show raw packet
            Dim hex As String = BitConverter.ToString(buffer).Replace("-", " ")
            Me.Invoke(Sub()
                          SerialTextBox.AppendText($"{DateTime.Now:HH:mm:ss.fff} → {hex}{vbCrLf}")
                          SerialTextBox.SelectionStart = SerialTextBox.Text.Length
                          SerialTextBox.ScrollToCaret()
                      End Sub)

            ' === DIGITAL INPUTS (Byte 0) – INVERTED FOR PULLED-UP BUTTONS ===
            Dim digitalByte As Byte = buffer(0)
            digitalByte = Not digitalByte  ' ← Inverted (pressed = 0)

            Dim binary As String = Convert.ToString(digitalByte, 2).PadLeft(8, "0"c)
            Dim displayBits As String = New String(binary.Reverse().ToArray())
            WriteToTextBox(DigitalInputsTextBox, displayBits)

            ' === 10-BIT ADC → TEMPERATURE ===
            Dim adcLow As Integer = buffer(0)
            Dim adcHigh As Integer = buffer(1)
            Dim adc10bit As Integer = (adcHigh << 8) Or adcLow
            Dim currentTemp As Single = 32 + (adc10bit / 1023.0F) * 1.475F

            Dim adcLow1 As Integer = buffer(2)
            Dim adcHigh1 As Integer = buffer(3)
            Dim adc10bit1 As Integer = (adcHigh1 << 8) Or adcLow1
            Dim hardwareTemp As Single = 32 + (adc10bit1 / 1023.0F) * 1.475F

            WriteToTextBox(CurrentTempTextBox, currentTemp.ToString("F1") & " °F")
            WriteToTextBox(HardwareTextBox, hardwareTemp.ToString("F1") & " °F")

            ' === OPERATION MODE (Heat = Bit 2, Cool = Bit 5) ===
            Dim heatOn As Boolean = (digitalByte And &H4) <> 0   ' Bit 2 pressed = 0 after invert
            Dim coolOn As Boolean = (digitalByte And &H20) <> 0   ' Bit 5 pressed = 0 after invert

            Dim mode As String = "OFF"
            Dim bg As Color = SystemColors.Control
            Dim fg As Color = SystemColors.ControlText

            If coolOn Then
                mode = "COOLING"
                bg = Color.CornflowerBlue
                fg = Color.White
            ElseIf heatOn Then
                mode = "HEATING"
                bg = Color.IndianRed
                fg = Color.White
            End If

            Me.Invoke(Sub()
                          OperationTextBox.Text = mode
                          OperationTextBox.BackColor = bg
                          OperationTextBox.ForeColor = fg
                          OperationTextBox.Font = New Font("Segoe UI", 16, FontStyle.Bold)
                      End Sub)

            ' === FAN CONTROL (±5°F from setpoint) ===
            Dim setpoint As Single
            If Not Single.TryParse(SetTempTextBox.Text.Replace("°F", "").Trim, setpoint) Then
                setpoint = 71.0F
            End If

            Dim diff As Single = Math.Abs(currentTemp - setpoint)
            Dim fanOn As Boolean = diff > 5.0F

            Me.Invoke(Sub()
                          If fanOn Then
                              FanTextBox.Text = "FAN: ON"
                              FanTextBox.BackColor = Color.LimeGreen
                              FanTextBox.ForeColor = Color.White
                          Else
                              FanTextBox.Text = "FAN: OFF"
                              FanTextBox.BackColor = SystemColors.Control
                              FanTextBox.ForeColor = SystemColors.ControlText
                          End If
                          FanTextBox.Font = New Font("Segoe UI", 16, FontStyle.Bold)
                      End Sub)

        Catch ex As Exception
            ' Never stops communication
        End Try
    End Sub


    Function IsQuietBoard() As Boolean
        Dim data(0) As Byte
        data(0) = &B11110000
        send(data)
        Sleep(100) ' Wait for potential response
        If SerialPort1.BytesToRead > 0 Then
            Dim resp() As Byte = recieve()
            ' Assume response byte 0 is &HAA for successful handshake (adjust based on actual device response)
            If resp.Length > 0 AndAlso resp(0) = &HAA Then
                Return True
            End If
        End If
        Return False
    End Function


    Public Sub WriteToTextBox(ByVal targetTextBox As System.Windows.Forms.TextBox, ByVal content As String)
        ' Check if the call is coming from a different thread than the one that created the control
        If targetTextBox.InvokeRequired Then
            ' If it is, use Invoke to marshal the call back to the UI thread
            targetTextBox.Invoke(New Action(Sub()
                                                targetTextBox.Text = content
                                            End Sub))
        Else
            ' If it is the UI thread, update directly
            targetTextBox.Text = content
        End If
    End Sub

    ' New sub to send setpoint to the thermostat device
    Sub SendSetpoint()
        Try
            Dim setpoint As Integer = CInt(SetTempTextBox.Text) ' Get user-entered setpoint
            If setpoint < 0 Or setpoint > 100 Then ' Example validation
                MsgBox("Setpoint must be between 0 and 100.")
                Exit Sub
            End If

            Dim data(1) As Byte
            data(0) = &H60 ' Invented command byte for setting temperature (adjust to actual protocol)
            data(1) = CByte(setpoint * 2.55F) ' Scale 0-100 to 0-255 byte
            send(data)
            MsgBox("Setpoint sent successfully.")
        Catch ex As Exception
            MsgBox($"Error sending setpoint: {ex.Message}")
        End Try
    End Sub

    ' Event Handlers-----------------------------------------
    Private Sub SetButton_Click(sender As Object, e As EventArgs) Handles SetButton.Click
        SendSetpoint() ' Send the setpoint when button clicked
    End Sub

    Private Sub ExitButton_Click(sender As Object, e As EventArgs) Handles ExitButton.Click
        Me.Close() ' Closes the program upon activation from button
    End Sub

    Private Sub HVAC_Load(sender As Object, e As EventArgs) Handles Me.Load
        'MsgBox("Form is loading!")

        CurrentTempTextBox.Text = "71.0°F"
        SetDefaults() ' Serial communication defaults
        ' AutoConnect() ' Attempt automatic connection on load
        ReadTimer.Interval = 10 ' Set timer to poll every second (adjust as needed)
        ReadTimer.Enabled = True ' Start constant reading
        Me.Font = New Font("Segoe UI", 11, FontStyle.Bold)
        Me.BackColor = Color.FromArgb(244, 121, 32)
    End Sub


End Class
