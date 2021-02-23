Imports System.Windows.Forms

Public Class TC_Path
    Public Other_TC As New Other_TC
    Private Sub TC_Path_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Icon = My.Resources.Qportal_Icon


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)

        'If Default_Path.Text = Change_Path.Text Then    ' 현재 입력 되어있는 경로와 변경 하고자 하는 경로가 같으면
        '    MsgBox("이미 최신 경로 입니다.",, "lee.sunbae@lgepartner.com")
        '    Exit Sub

        'Else

        '    Try
        '        Other_TC.strFilePath = Change_Path.Text
        '        MsgBox("성공적으로 변경 됐습니다")
        '    Catch ex As Exception
        '        MsgBox(ex.Message)
        '    End Try

        'End If

    End Sub

    Private Sub Default_Path_TextChanged(sender As Object, e As EventArgs) Handles Default_Path.TextChanged, MSTech_txt.TextChanged, INFINIQ_txt.TextChanged, CNS_txt.TextChanged

    End Sub

    Private Sub Infiniq_btn_Click(sender As Object, e As EventArgs) Handles Infiniq_btn.Click, Button1.Click, Mstech_btn.Click

        If DirectCast(sender, Control).Name = "Button1" Then   ' 만약 Event를 Click 한 Handler가 FUT라면
            Shell("C:\Windows\explorer.exe " & CNS_txt.Text, AppWinStyle.NormalFocus)
        ElseIf DirectCast(sender, Control).Name = "Infiniq_btn" Then
            Shell("C:\Windows\explorer.exe " & INFINIQ_txt.Text, AppWinStyle.NormalFocus)
        ElseIf DirectCast(sender, Control).Name = "Mstech_btn" Then
            Shell("C:\Windows\explorer.exe " & MSTech_txt.Text, AppWinStyle.NormalFocus)
        End If
    End Sub
End Class