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

    Private Sub ReadTimer_Tick(sender As Object, e As EventArgs) Handles ReadTimer.Tick
        ReadTemperatureAndDigital() ' For every timer tick, request temperature data
    End Sub

    Sub ReadTemperatureAndDigital()
        If Not SerialPort1.IsOpen Then Exit Sub

        ' Request temperature (still works great)
        Dim cmdTemp(0) As Byte
        cmdTemp(0) = &H53
        SerialPort1.Write(cmdTemp, 0, 1)

        ' Request digital inputs — ONLY &H30, nothing else
        Dim cmdDigital(0) As Byte
        cmdDigital(0) = &H30
        SerialPort1.Write(cmdDigital, 0, 1)
    End Sub

    Private Sub SerialPort1_DataReceived(sender As Object, e As SerialDataReceivedEventArgs) Handles SerialPort1.DataReceived
        Try
            Dim bytesToRead As Integer = SerialPort1.BytesToRead
            If bytesToRead < 4 Then Exit Sub

            Dim buffer(bytesToRead - 1) As Byte
            SerialPort1.Read(buffer, 0, bytesToRead)

            ' Always show raw data
            Dim hexString As String = BitConverter.ToString(buffer).Replace("-", " ")
            Me.Invoke(Sub()
                          SerialTextBox.AppendText($"{DateTime.Now:HH:mm:ss.fff} → {hexString}{vbCrLf}")
                          SerialTextBox.SelectionStart = SerialTextBox.Text.Length
                          SerialTextBox.ScrollToCaret()
                      End Sub)

            ' === ANALOG / TEMPERATURE PACKET ===
            If buffer(0) = &H53 Then
                Dim tempRaw As Integer = buffer(1)
                Dim temperature As Single = tempRaw / 2.55F
                WriteToTextBox(CurrentTempTextBox, temperature.ToString("F1") & " °C")
                Exit Sub   ' We got temp — no need to check digital
            End If

            ' === DIGITAL INPUTS PACKET (triggered by &H30) ===
            ' The packet that comes RIGHT after sending &H30 has digital inputs in buffer(0)
            ' All other packets (like extra &H53 responses) will have buffer(0) = &H53 → ignored
            Dim digitalByte As Byte = buffer(0)   ' YES — digital inputs are in the FIRST byte!

            ' Convert to 8-bit binary string (D7 D6 D5 D4 D3 D2 D1 D0)
            Dim binary As String = Convert.ToString(digitalByte, 2).PadLeft(8, "0"c)

            ' Reverse so D0 is on the right (standard for hardware pinouts)
            Dim displayBits As String = New String(binary.Reverse().ToArray())

            ' Update your dedicated digital inputs textbox
            WriteToTextBox(DigitalInputsTextBox, displayBits)

        Catch ex As Exception
            ' Ignore overrun, etc.
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
        MsgBox("Form is loading!")
        SetDefaults() ' Serial communication defaults
        ' AutoConnect() ' Attempt automatic connection on load
        ReadTimer.Interval = 1000 ' Set timer to poll every second (adjust as needed)
        ReadTimer.Enabled = True ' Start constant reading
    End Sub
End Class

