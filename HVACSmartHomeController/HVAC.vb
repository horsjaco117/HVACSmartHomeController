'Jacob Horsley
'RCET 3371
'Fall 2025
'URL:
'
Option Strict On
Option Explicit On
Imports System.IO.Ports

Public Class HVAC
    Sub connect()
        SerialPort1.Close()
        Try
            SerialPort1.BaudRate = 115200
            SerialPort1.Parity = Parity.None
            SerialPort1.StopBits = StopBits.One
            SerialPort1.DataBits = 8
            SerialPort1.PortName = CStr(SerialPortsComboBox.SelectedItem)
            SerialPort1.Open()

            '    If IsQuietBoard() Then
            '        connectionStatusLabel.text = $"Qy@ Connected on {SerialPort1.PortName}"
            '    Else
            '        SetDefaults()
            '    End If
        Catch ex As Exception
            '    MsgBox(ex.Message)
            '    SetDefaults()
        End Try
    End Sub

    Sub Send(data() As Byte)
        SerialPort1.ReadExisting()
        SerialPort1.Write(data, 0, UBound(data))
    End Sub

    Function recieve() As Byte()
        Dim data(SerialPort1.BytesToRead) As Byte
        SerialPort1.Read(data, 0, SerialPort1.BytesToRead)
        Return data
    End Function

    Sub Write()
        Dim data(0) As Byte
        data(0) = &B11110000
        SerialPort1.Write(data, 0, 1)
    End Sub

    Private Sub SerialPort1_DataReceived(sender As Object, e As SerialDataReceivedEventArgs) Handles SerialPort1.DataReceived
        Try
            Dim bytesToRead As Integer = SerialPort1.BytesToRead
            If bytesToRead < 4 Then Exit Sub

            Dim buffer(bytesToRead - 1) As Byte
            SerialPort1.Read(buffer, 0, bytesToRead)

            Dim hexString As New System.Text.StringBuilder()
            For Each b As Byte In buffer
                hexString.Append(b.ToString("X2") & " ")
            Next

            Dim leftValue As Integer = buffer(1)
            Dim rightValue As Integer = buffer(3)

            'WriteToTextBox(me.XAxisTextBox, buffer(0)ToString("X2"))
            'WriteToTextBox(me.YAxisTextBox, buffer(0)ToString("X2"))



        Catch ex As Exception

        End Try
    End Sub

    Private Sub HVAC_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
