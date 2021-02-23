Imports System.Windows.Forms

Public Class New_RandomPlan_Page




    Private Sub New_RandomPlan_Page_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Icon = My.Resources.Qportal_Icon
    End Sub

    Private Sub NewPlanLinkClicked(sender As Object, e As Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lab_app_change.LinkClicked, lnkProject.LinkClicked, lnkModel.LinkClicked, lnkPlan.LinkClicked, lnkExpert.LinkClicked, lnkPath.LinkClicked
        ' Link 눌렀을 때 
        Dim strPath As String = "\\10.169.88.40\Q-Portal\2.검증현황\Defect 분석\검증계획서\총시기획"

        If DirectCast(sender, Control).Name = "lab_app_change" Then  ' 1) 변경점 등록
            Diagnostics.Process.Start(strPath)
        ElseIf DirectCast(sender, Control).Name = "lnkProject" Then      ' 2) Project 시험기획
            Dim SW As New SW_Validation_Master_Plan : SW.Show()
        ElseIf DirectCast(sender, Control).Name = "lnkModel" Then      ' 1) 모델 시험기획 매핑
            Dim Model_Mapping As New Func_Change : Model_Mapping.Show()
        ElseIf DirectCast(sender, Control).Name = "lnkPlan" Then         ' 시험기획서
            Diagnostics.Process.Start(strPath)
        ElseIf DirectCast(sender, Control).Name = "lnkExpert" Then      ' Expert 인원 변경점 검증 방법
            Dim Expert As New Change : Expert.Show()
        ElseIf DirectCast(sender, Control).Name = "lnkPath" Then        '  시험기획서
            Diagnostics.Process.Start(strPath)
        End If





    End Sub
End Class