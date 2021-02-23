Public Class Product_of_Tester
    Public strPath As String = "\\10.169.88.40\Q-Portal\2.검증현황\Defect 분석\검증계획서\총시기획"
    Private Sub lnkPath_LinkClicked(sender As Object, e As Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkPath.LinkClicked
        Diagnostics.Process.Start(strPath)
    End Sub
End Class