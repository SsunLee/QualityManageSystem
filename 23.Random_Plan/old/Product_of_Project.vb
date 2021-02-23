Imports System.Windows.Forms

Public Class Product_of_Project
    Public strPath As String = "\\10.169.88.40\Q-Portal\2.검증현황\Defect 분석\검증계획서\총시기획"
    Private Sub lab_app_change_LinkClicked(sender As Object, e As Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lab_app_change.LinkClicked, lnkProject.LinkClicked

        ' Link 눌렀을 때 
        If DirectCast(sender, Control).Name = "lab_app_change" Then  ' 1) 변경점 등록
            Diagnostics.Process.Start(strPath)
        ElseIf DirectCast(sender, Control).Name = "lnkProject" Then      ' 2) Project 시험기획
            Dim SW As New SW_Validation_Master_Plan : SW.Show()
        End If

    End Sub

End Class