Imports System.Windows.Forms

Public Class Login
    'Public strpw As String = "lge1234"

    'Public INFINIQ As String = "admin_infiniq"
    'Public MSTECH As String = "admin_mstech"
    'Public LGCNS As String = "admin_lgcns"

    Public strpw As String = ""

    Public INFINIQ As String = ""
    Public MSTECH As String = ""
    Public LGCNS As String = ""

    Public icount As Integer = 0
    Private Sub request_pw_LinkClicked(sender As Object, e As Windows.Forms.LinkLabelLinkClickedEventArgs) Handles request_pw.LinkClicked
        Dim Outl As Object
        Outl = CreateObject("Outlook.Application")
        If Outl IsNot Nothing Then
            Dim omsg As Object
            omsg = Outl.CreateItem(0)
            omsg.To = "lee.sunbae@lgepartner.com"
            'omsg.bcc = "yusuf@gmail.com"
            'omsg.subject = "Hello"
            'omsg.body = "godmorning"
            'omsg.Attachments.Add("c:\HP\opcserver.txt")
            'set message properties here...'
            omsg.Display(True) 'will display message to user
        End If
    End Sub

    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        password.Text = ""  ' The password character is an asterisk.
        password.PasswordChar = "*"  ' The control will allow no more than 14 characters.
        password.MaxLength = 14
        ChkLabel.Text = "Hint : l*****4"
        'ChkLabel.Visible = False

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim blChk As Boolean = False

        If INFINIQ = ID.Text Or MSTECH = ID.Text Or LGCNS = ID.Text Then
            blChk = True
        End If


        If strpw = password.Text And blChk = True Then   ' 암호가 맞다면 
            Dim AdminMain As New AdminMain
            AdminMain.Show()
            Close()
        ElseIf icount = 10 Then

        Else
            icount = icount + 1
            MsgBox("아이디 또는 비밀번호를 " & icount & "회 틀렸습니다.")
            ChkLabel.Text = "아이디 또는 비밀번호를 다시 확인하세요." & vbCrLf & "등록되지 않은 아이디이거나, 아이디 또는 비밀번호를 잘못 입력하셨습니다."
            ChkLabel.Visible = True
        End If


    End Sub

    Private Sub password_KeyPress(sender As Object, e As KeyPressEventArgs) Handles password.KeyPress, ID.KeyPress
        If e.KeyChar = Convert.ToChar(13) Then
            Call Button1_Click(sender, e)
        End If
    End Sub

    Private Sub password_KeyDown(sender As Object, e As KeyEventArgs) Handles password.KeyDown
        'Select Case e.KeyCode
        '    Case Keys.CapsLock
        '        If Keyboard.CapsLock Then
        '            ToolTip1.Text = "CapsLock On"
        '        Else
        '            ToolTip1.Text = "CapsLock Off"
        '        End If
        'End Select
    End Sub

End Class



