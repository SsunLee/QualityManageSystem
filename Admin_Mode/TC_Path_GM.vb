Imports System.Windows.Forms

Public Class TC_Path_GM
    Public Other_TC As New Other_TC
    'Public Other_TC As New Other_TC
    Private Sub TC_Path_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    '  Private Sub Infiniq_btn_Click(sender As Object, e As EventArgs)
    ' If DirectCast(sender, Control).Name = "Button1" Then   ' 만약 Event를 Click 한 Handler가 FUT라면
    '        Shell("C:\Windows\explorer.exe " & CNS_txt.Text, AppWinStyle.NormalFocus)
    'End If
    'End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If DirectCast(sender, Control).Name = "Button1" Then   ' 만약 Event를 Click 한 Handler가 FUT라면
            Shell("C:\Windows\explorer.exe " & txtGuide.Text, AppWinStyle.NormalFocus)
        End If
    End Sub
End Class