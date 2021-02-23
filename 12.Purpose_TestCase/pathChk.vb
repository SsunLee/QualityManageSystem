Public Class pathChk
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Shell("C:\Windows\explorer.exe " & Default_Path.Text, AppWinStyle.NormalFocus)
    End Sub

    Private Sub pathChk_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Icon = My.Resources.Qportal_Icon
        btn_Search.Text = "1회성_조회하기.xlsm"
        btn_Write.Text = "1회성_재현입력.xlsm"
    End Sub
End Class