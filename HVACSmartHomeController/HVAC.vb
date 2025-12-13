' Jacob Horsley
' RCET 0265
' Spring 2025
' URL: https://github.com/horsjaco117/ThermostatControl 
' Modified from GraphicsExamples to control a thermostat via serial communication
Option Strict On
Option Explicit On

' Serial communications imports
Imports System.IO.Ports
Imports System.Media
Imports System.Net.Configuration
Imports System.Runtime.CompilerServices
Imports System.Text.RegularExpressions
Imports System.Threading.Thread

'TODO
'ADD LATCHING TO THE COOLING AND HEATING 
'

Public Class HVAC
    'Important definitions
    Private heatLatched As Boolean = False
    Private coolLatched As Boolean = False
    Private fanLatched As Boolean = False

    ' For edge detection (previous state tracking)
    Private prevHeatBit As Boolean = False
    Private prevCoolBit As Boolean = False
    Private prevFanBit As Boolean = False

    Private Const HYSTERESIS As Single = 0.5F  ' Degrees F; adjust as needed (common values: 0.5–1.0)

    Private lastSetpoint As Single = 71.0F  ' Default

    Private Const SETTINGS_FILE As String = "HVAC Settings.txt"

    'Compliant with quiet board
    Private WithEvents DetectTimer As New Timer()
    Private previouslyAvailablePorts As New List(Of String)
    Private hardwareVerified As Boolean = False

    'Handshake verification
    Private ReadOnly ExpectedHandshakeResponse As Byte() = {
    &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0,
    &H0, &H0, &H0, &H0, &H0, &H0, &HFF, &H0, &H0, &H0,
    &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0,
    &H0, &HD0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0,
    &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0,
    &H0, &H0, &H0, &H0, &H0, &H0, &H51, &H79, &H40, &H32,
    &H2E, &H30, &H68, &HC0, &HFD, &H40, &HCC, &HC0, &HBF, &H0,
    &HFF, &H68, &HC0, &HFD, &H40, &HEE, &HC0, &HE5, &H80
}

    Private Function GetSettingsPath() As String
        Return System.IO.Path.Combine(Application.StartupPath, SETTINGS_FILE)
    End Function


    ' Serial Communications----------------------------------------------------------
    Sub SetDefaults() ' Set's default serial pieces and shows COM ports
        SerialPort1.Close()
        hardwareVerified = False  ' Add this line
        ConnectionStatusLabel.Text = "No connection"
        GetPorts()
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
        GetPorts()
        For Each port As String In PortsComboBox.Items
            PortsComboBox.SelectedItem = port
            Try
                connect()
                If SerialPort1.IsOpen Then
                    write() ' Send handshake
                    Sleep(200)
                    If IsQuietBoard() Then
                        ConnectionStatusLabel.Text = $"Connected automatically on {SerialPort1.PortName}"
                        Exit For
                    Else
                        SerialPort1.Close()
                    End If
                End If
            Catch ex As Exception
                ' Skip invalid port
            End Try
        Next

        If Not SerialPort1.IsOpen Then
            ConnectionStatusLabel.Text = "Auto-connect failed or wrong device detected. Try manual connect."
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
        'connect()
        'If SerialPort1.IsOpen Then
        '    write()  ' Send &HF0 handshake
        '    Sleep(200)
        '    If IsQuietBoard() Then
        '        ConnectionStatusLabel.Text = $"Connected manually on {SerialPort1.PortName}"
        '    Else
        '        SerialPort1.Close()
        '        ConnectionStatusLabel.Text = "Wrong device detected or no response. Disconnected."
        '    End If
        'End If
    End Sub



    Sub RequestAllAnalogInputs()
        If Not SerialPort1.IsOpen Then Exit Sub

        Dim cmd(0) As Byte
        cmd(0) = &H30        ' This command returns ALL analog channels (8 values)
        SerialPort1.Write(cmd, 0, 1)
    End Sub

    Sub ReadTemperatureAndDigital()
        If Not SerialPort1.IsOpen Then Exit Sub

        ' Request analog (this gives you TWO channels — AN0 and AN1)
        Dim cmdAnalog(0) As Byte
        cmdAnalog(0) = &H30
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
        ' IsQuietBoard()
    End Sub

    Private Sub DetectTimer_Tick(sender As Object, e As EventArgs)
        If SerialPort1.IsOpen Then
            ' Already connected to verified hardware → skip scanning
            Return
        End If

        Dim currentPorts As String() = SerialPort.GetPortNames()

        ' Detect new ports (hot-plug)
        Dim newPorts = currentPorts.Except(previouslyAvailablePorts).ToList()

        If newPorts.Count > 0 Then
            ' New device(s) detected → attempt verification on each
            For Each port In newPorts
                Try
                    PortsComboBox.SelectedItem = port
                    connect()
                    If SerialPort1.IsOpen Then
                        write()  ' Send &HF0
                        Sleep(200)
                        If IsQuietBoard() Then
                            Me.Invoke(Sub()
                                          ConnectionStatusLabel.Text = $"Auto-connected to compliant device on {SerialPort1.PortName}"
                                      End Sub)
                            previouslyAvailablePorts = currentPorts.ToList()
                            Return  ' Success: stop scanning
                        Else
                            SerialPort1.Close()
                        End If
                    End If
                Catch ex As Exception
                    ' Skip invalid/new port
                End Try
            Next
        End If

        ' Update tracked ports
        previouslyAvailablePorts = currentPorts.ToList()
    End Sub

    Private Sub SerialPort1_ErrorReceived(sender As Object, e As SerialErrorReceivedEventArgs) Handles SerialPort1.ErrorReceived
        Me.Invoke(Sub()
                      If SerialPort1.IsOpen Then
                          Try
                              SerialPort1.Close()
                          Catch
                              ' Ignore errors during close
                          End Try
                      End If
                      ConnectionStatusLabel.Text = "Connection lost (error detected)."
                      SetDefaults()  ' Reset UI and port list
                  End Sub)
    End Sub

    Private Sub SerialPort1_DataReceived(sender As Object, e As SerialDataReceivedEventArgs) Handles SerialPort1.DataReceived
        Try
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

                ' === DIGITAL INPUTS (Byte 0) – INVERTED FOR PULLED-UP INPUTS ===
                Dim digitalByte As Byte = buffer(0)
                digitalByte = Not digitalByte  ' Pressed = 1

                Dim safetyInterlock As Boolean = (digitalByte And &H1) <> 0  ' Bit 0
                Dim heatButtonNow As Boolean = (digitalByte And &H2) <> 0  ' Bit 1
                Dim fanButtonNow As Boolean = (digitalByte And &H4) <> 0  ' Bit 2
                Dim coolButtonNow As Boolean = (digitalByte And &H8) <> 0  ' Bit 3

                ' Display binary inputs
                Dim binary As String = Convert.ToString(digitalByte, 2).PadLeft(8, "0"c)
                Dim displayBits As String = New String(binary.Reverse().ToArray())
                WriteToTextBox(DigitalInputsTextBox, displayBits)

                ' === EDGE DETECTION AND SOFTWARE LATCHING ===
                If safetyInterlock Then
                    heatLatched = False
                    coolLatched = False
                    fanLatched = False
                Else
                    ' Heating toggle (clears others if turning on)
                    If heatButtonNow AndAlso Not prevHeatBit Then
                        heatLatched = Not heatLatched
                        If heatLatched Then
                            coolLatched = False
                            fanLatched = False
                        End If
                    End If

                    ' Cooling toggle (clears others if turning on)
                    If coolButtonNow AndAlso Not prevCoolBit Then
                        coolLatched = Not coolLatched
                        If coolLatched Then
                            heatLatched = False
                            fanLatched = False
                        End If
                    End If

                    ' Fan toggle (clears others if turning on)
                    If fanButtonNow AndAlso Not prevFanBit Then
                        fanLatched = Not fanLatched
                        If fanLatched Then
                            heatLatched = False
                            coolLatched = False
                        End If
                    End If
                End If

                ' Update previous states
                prevHeatBit = heatButtonNow
                prevCoolBit = coolButtonNow
                prevFanBit = fanButtonNow

                ' === TEMPERATURE CALCULATION (Bytes 1-4) ===
                Dim adcLow0 As Integer = buffer(2)
                Dim adcHigh0 As Integer = buffer(1)
                Dim adc10bit0 As Integer = (adcHigh0 << 8) Or adcLow0
                Dim currentTemp As Single = 32 + (adc10bit0 / 1023.0F) * 0.95F

                Dim adcLow1 As Integer = buffer(4)
                Dim adcHigh1 As Integer = buffer(3)  ' Assuming packet has at least 5 bytes
                Dim adc10bit1 As Integer = (adcHigh1 << 8) Or adcLow1
                Dim hardwareTemp As Single = 40 + (adc10bit1 / 1023.0F) * 0.95F

                WriteToTextBox(CurrentTempTextBox, currentTemp.ToString("F1") & " °F")
                WriteToTextBox(HardwareTextBox, hardwareTemp.ToString("F1") & " °F")

                ' === UPDATE OPERATION MODE DISPLAY ===
                Dim mode As String = "OFF"
                Dim bg As Color = SystemColors.Control
                Dim fg As Color = SystemColors.ControlText

                If safetyInterlock Then
                    mode = "SAFETY LOCKOUT"
                    bg = Color.DarkRed
                    fg = Color.White
                Else
                    If coolLatched Then
                        mode = "COOLING"
                        bg = Color.CornflowerBlue
                        fg = Color.White
                    ElseIf heatLatched Then
                        mode = "HEATING"
                        bg = Color.IndianRed
                        fg = Color.White
                        'ElseIf fanLatched Then
                        '    mode = "FAN ONLY"
                        '    bg = Color.MediumSeaGreen
                        '    fg = Color.White
                    End If
                End If

                Me.Invoke(Sub()
                              OperationTextBox.Text = mode
                              OperationTextBox.BackColor = bg
                              OperationTextBox.ForeColor = fg
                              OperationTextBox.Font = New Font("Segoe UI", 16, FontStyle.Bold)
                          End Sub)

                Dim highLimit As Single
                Dim lowLimit As Single

                ' Parse the text boxes safely
                If Single.TryParse(SetTempTextBox.Text, highLimit) AndAlso
       Single.TryParse(LowTempTextBox.Text, lowLimit) Then

                    Me.Invoke(Sub()
                                  If currentTemp > highLimit Then
                                      ' Visual alarm for High Temp
                                      CurrentTempTextBox.ForeColor = Color.Red
                                  ElseIf currentTemp < lowLimit Then
                                      ' Visual alarm for Low Temp
                                      CurrentTempTextBox.ForeColor = Color.Blue
                                  Else
                                      ' Normal Range
                                      CurrentTempTextBox.ForeColor = Color.Black
                                  End If
                              End Sub)
                End If

                ' === UPDATE FAN TEXTBOX (Manual latch only) ===
                Me.Invoke(Sub()
                              If safetyInterlock Then
                                  FanTextBox.Text = "FAN: OFF (SAFETY)"
                                  FanTextBox.BackColor = Color.DarkRed
                                  FanTextBox.ForeColor = Color.White
                              ElseIf fanLatched Then
                                  FanTextBox.Text = "FAN: ON (MANUAL)"
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
                ' Communication continues despite errors
            End Try
        Catch ioEx As System.IO.IOException
            ' Device likely disconnected
            Me.Invoke(Sub()
                          ConnectionStatusLabel.Text = "Connection lost (device removed)."
                          SetDefaults()
                      End Sub)
        Catch ex As Exception
            ' Other errors: log but continue
            Me.Invoke(Sub()
                          SerialTextBox.AppendText($"Error: {ex.Message}{vbCrLf}")
                      End Sub)
        End Try
    End Sub


    Function IsQuietBoard() As Boolean
        If hardwareVerified Then Return True  ' Already confirmed correct hardware

        ' Clear any pending data
        SerialPort1.DiscardInBuffer()

        ' Send handshake byte F0
        Dim handshake(0) As Byte
        handshake(0) = &HF0
        send(handshake)

        ' Wait up to 500 ms for response
        Dim timeout As Integer = 500
        Dim waited As Integer = 0
        Do While SerialPort1.BytesToRead < ExpectedHandshakeResponse.Length AndAlso waited < timeout
            Sleep(10)
            waited += 10
        Loop

        If SerialPort1.BytesToRead < ExpectedHandshakeResponse.Length Then
            hardwareVerified = False
            Return False
        End If

        ' Read the response
        Dim resp(ExpectedHandshakeResponse.Length - 1) As Byte
        Dim bytesRead As Integer = SerialPort1.Read(resp, 0, ExpectedHandshakeResponse.Length)

        If bytesRead <> ExpectedHandshakeResponse.Length Then
            hardwareVerified = False
            Return False
        End If

        ' Compare byte-by-byte with expected signature
        Dim match As Boolean = True
        For i As Integer = 0 To ExpectedHandshakeResponse.Length - 1
            If resp(i) <> ExpectedHandshakeResponse(i) Then
                match = False
                Exit For
            End If
        Next

        hardwareVerified = match
        Return match
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

            '    Dim data(1) As Byte
            '    data(0) = &H30 ' Invented command byte for setting temperature (adjust to actual protocol)
            '    data(1) = CByte(setpoint * 2.55F) ' Scale 0-100 to 0-255 byte
            '    send(data)
            '    ' MsgBox("Setpoint sent successfully.")
        Catch ex As Exception
            MsgBox($"Error sending setpoint: {ex.Message}")
        End Try
    End Sub

    ' Event Handlers-----------------------------------------
    Private Sub SetButton_Click(sender As Object, e As EventArgs) Handles SetButton.Click
        ' Send both thresholds when the user clicks Set

    End Sub

    ' Add this handle to autosave when user types in LowTempTextBox
    Private Sub LowTempTextBox_TextChanged(sender As Object, e As EventArgs) Handles LowTempTextBox.TextChanged
        SaveSettings()
    End Sub

    Private Sub ExitButton_Click(sender As Object, e As EventArgs) Handles ExitButton.Click
        Me.Close() ' Closes the program upon activation from button
    End Sub

    Private Sub HVAC_Load(sender As Object, e As EventArgs) Handles Me.Load
        'MsgBox("Form is loading!")

        '        CurrentTempTextBox.Text = "71.0°F"
        SetDefaults() ' Serial communication defaults
        ' AutoConnect() ' Attempt automatic connection on load
        ReadTimer.Interval = 100 ' Set timer to poll every second (adjust as needed)
        ReadTimer.Enabled = True ' Start constant reading
        Me.Font = New Font("Segoe UI", 11, FontStyle.Bold)
        Me.BackColor = Color.FromArgb(244, 121, 32)

        LoadSettings()
        IncrementTemperatureHigh(SetTempTextBox, 0)
        IncrementTemperatureLow(LowTempTextBox, 0)


        If PortsComboBoxHasSelection() Then
            connect()
            write()

        End If
        Dim start(10) As Byte
        start(0) = &H30
        start(1) = &H20
        start(2) = &H0
        start(3) = &H5F
        start(4) = &H41
        start(5) = &H19
        start(6) = &H0
        start(7) = &H42
        start(8) = &H2
        start(9) = &H80
        SerialPort1.Write(start, 0, 10)
        previouslyAvailablePorts = SerialPort.GetPortNames().ToList()

        DetectTimer.Interval = 3000  ' Check every 3 seconds
        DetectTimer.Start()
    End Sub

    Private Function PortsComboBoxHasSelection() As Boolean
        Return PortsComboBox.SelectedItem IsNot Nothing AndAlso Not String.IsNullOrEmpty(PortsComboBox.SelectedItem.ToString())
    End Function

    Private Sub SaveSettings()
        Try
            Dim lines As New List(Of String)

            ' 1. Save High Temp (SetTempTextBox)
            lines.Add(SetTempTextBox.Text.Trim())

            ' 2. Save Low Temp (LowTempTextBox) - NEW
            lines.Add(LowTempTextBox.Text.Trim())

            ' 3. Save the selected COM port
            If PortsComboBox.SelectedItem IsNot Nothing Then
                lines.Add(PortsComboBox.SelectedItem.ToString())
            Else
                lines.Add("")
            End If

            System.IO.File.WriteAllLines(GetSettingsPath(), lines)
        Catch ex As Exception
            ' Fail silently
        End Try
    End Sub

    Private Sub LoadSettings()
        Dim path As String = GetSettingsPath()
        If Not System.IO.File.Exists(path) Then Exit Sub

        Try
            Dim lines() As String = System.IO.File.ReadAllLines(path)

            ' Line 0 = High Setpoint
            If lines.Length > 0 AndAlso Not String.IsNullOrWhiteSpace(lines(0)) Then
                SetTempTextBox.Text = lines(0).Trim()
            End If

            ' Line 1 = Low Setpoint - NEW
            ' We check if the line looks like a number to avoid loading an old COM port setting into the temp box
            Dim d As Double
            If lines.Length > 1 AndAlso Double.TryParse(lines(1), d) Then
                LowTempTextBox.Text = lines(1).Trim()
            End If

            ' Line 2 = COM port (Moved from index 1 to 2)
            ' We look at the last line or index 2 to find the port
            Dim portIndex As Integer = 2
            If lines.Length > portIndex AndAlso Not String.IsNullOrWhiteSpace(lines(portIndex)) Then
                Dim savedPort As String = lines(portIndex).Trim()
                For i As Integer = 0 To PortsComboBox.Items.Count - 1
                    If PortsComboBox.Items(i).ToString() = savedPort Then
                        PortsComboBox.SelectedIndex = i
                        Exit For
                    End If
                Next
            End If

        Catch ex As Exception
            ' Corrupted file or format mismatch? Ignore.
        End Try
    End Sub

    ' New sub to send LOW setpoint to the thermostat device
    Sub SendLowSetpoint()
        Try
            Dim lowSetpoint As Integer = CInt(LowTempTextBox.Text)

            ' Basic validation: Low should not be higher than High
            Dim highSetpoint As Integer = CInt(SetTempTextBox.Text)
            If lowSetpoint >= highSetpoint Then
                MsgBox("Low threshold must be lower than High threshold.")
                Exit Sub
            End If

            'Dim data(1) As Byte
            'data(0) = &H30 ' <--- ASSUMED COMMAND for Low Temp. Change this if needed.
            'data(1) = CByte(lowSetpoint * 2.55F) ' Scale 0-100 to 0-255 byte

            'send(data)
        Catch ex As Exception
            ' Handle parsing errors if box is empty
        End Try
    End Sub
    ' Helper: check if combo box already has this port (avoids errors on missing COM ports)
    Private Function PortsBoxContains(portName As String) As Boolean
        For Each item In PortsComboBox.Items
            If item.ToString() = portName Then Return True
        Next
        Return False
    End Function

    Private Sub ExitToolStripButton_Click(sender As Object, e As EventArgs) Handles ExitToolStripButton.Click
        Me.Close()
    End Sub

    Private Sub SetTempTextBox_TextChanged(sender As Object, e As EventArgs) Handles SetTempTextBox.TextChanged
        SaveSettings()
    End Sub

    Private Sub PortsComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles PortsComboBox.SelectedIndexChanged
        SaveSettings()
    End Sub


    Private Sub CommunicationToolStripButton_Click(sender As Object, e As EventArgs) Handles CommunicationToolStripButton.Click

    End Sub

    Private Sub IncrementHighTempButton_Click(sender As Object, e As EventArgs) Handles IncrementHighTempButton.Click
        IncrementTemperatureHigh(SetTempTextBox, 0.5F)
    End Sub

    Private Sub IncrementLowTempButton_Click(sender As Object, e As EventArgs) Handles IncrementLowTempButton.Click
        IncrementTemperatureLow(LowTempTextBox, 0.5F)
    End Sub

    Private Sub DecrementLowTempButton_Click(sender As Object, e As EventArgs) Handles DecrementLowTempButton.Click
        IncrementTemperatureLow(LowTempTextBox, -0.5F)
    End Sub
    Private Sub DecrementHighTempButton_Click(sender As Object, e As EventArgs) Handles DecrementHighTempButton.Click
        IncrementTemperatureHigh(SetTempTextBox, 0.5F)
    End Sub

    Private Sub IncrementTemperatureHigh(ByVal targetTextBox As System.Windows.Forms.TextBox, ByVal change As Single)
        Dim currentTemp As Single = 0.0F

        ' 1. Safely try to parse the current value. If it fails, use the default (0.0F).
        If Not Single.TryParse(targetTextBox.Text, currentTemp) Then
            currentTemp = 90.0F ' Use a sensible default if the box is empty or invalid
        End If

        ' 2. Calculate the new temperature
        Dim newTemp As Single = currentTemp + change

        ' 3. Optional: Implement min/max limits (e.g., keep temperature between 50°F and 90°F)
        If newTemp < 50.0F Then newTemp = 50.0F
        If newTemp > 90.0F Then newTemp = 90.0F

        ' 4. Update the TextBox with the new value, formatted to one decimal place.
        WriteToTextBox(targetTextBox, newTemp.ToString("F1"))

        ' 5. Trigger the setpoint command to the hardware and save the setting
        If targetTextBox Is SetTempTextBox Then
            SendSetpoint()
        ElseIf targetTextBox Is LowTempTextBox Then
            SendLowSetpoint()
        End If

        SaveSettings()
    End Sub




    Private Sub IncrementTemperatureLow(ByVal targetTextBox As System.Windows.Forms.TextBox, ByVal change As Single)
        Dim currentTemp As Single = 0.0F

        ' 1. Safely try to parse the current value. If it fails, use the default (0.0F).
        If Not Single.TryParse(targetTextBox.Text, currentTemp) Then
            currentTemp = 70.0F ' Use a sensible default if the box is empty or invalid
        End If

        ' 2. Calculate the new temperature
        Dim newTemp As Single = currentTemp + change

        ' 3. Optional: Implement min/max limits (e.g., keep temperature between 50°F and 90°F)
        If newTemp < 50.0F Then newTemp = 50.0F
        If newTemp > 90.0F Then newTemp = 90.0F

        ' 4. Update the TextBox with the new value, formatted to one decimal place.
        WriteToTextBox(targetTextBox, newTemp.ToString("F1"))

        ' 5. Trigger the setpoint command to the hardware and save the setting
        If targetTextBox Is SetTempTextBox Then
            SendSetpoint()
        ElseIf targetTextBox Is LowTempTextBox Then
            SendLowSetpoint()
        End If

        SaveSettings()
    End Sub

End Class