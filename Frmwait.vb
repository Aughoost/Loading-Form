Imports System.ComponentModel
Imports System.Runtime.InteropServices
Public Class frmWait
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.WindowState = frmMain.WindowState
        Me.StartPosition = FormStartPosition.Manual
        Me.MaximumSize = Screen.FromRectangle(Me.DesktopBounds).WorkingArea.Size
        Me.Size = New Size(frmMain.Width, frmMain.Height)
        Me.Location = New Point(frmMain.Width / 2 - Me.Width / 2 + frmMain.Location.X, frmMain.Height / 2 - Me.Height / 2 + frmMain.Location.Y)
    End Sub
    '2021/13/10 di ma click
     ' Code By August 10/2021
    <StructLayout(LayoutKind.Sequential)>
    Private Structure NativeMessage
        Public handle As IntPtr
        Public msg As UInteger
        Public wParam As IntPtr
        Public lParam As IntPtr
        Public time As UInteger
        Public p As System.Drawing.Point
    End Structure
    Private Declare Auto Function PeekMessage Lib "user32.dll" (
        ByRef lpMsg As NativeMessage,
        ByVal hWnd As IntPtr,
        ByVal wMsgFilterMin As UInteger,
        ByVal wMsgFilterMax As UInteger,
        ByVal flags As UInteger
    ) As Boolean
    Private Const WM_MOUSEFIRST As UInteger = &H200
    Private Const WM_MOUSELAST As UInteger = &H20D
    Private Const PM_REMOVE As Integer = &H1

    ' Flush all pending mouse events.
    Private Sub FlushMouseMessages()
        Dim msg As NativeMessage
        ' Repeat until PeekMessage returns false.
        While (PeekMessage(msg, IntPtr.Zero, WM_MOUSEFIRST, WM_MOUSELAST, PM_REMOVE))
        End While
    End Sub

    Private Sub frmWait_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        FlushMouseMessages()
    End Sub
End Class
