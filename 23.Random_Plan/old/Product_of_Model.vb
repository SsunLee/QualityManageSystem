Imports System.Windows.Forms

Public Class Product_of_Model
    Public strPath As String = "\\10.169.88.40\Q-Portal\2.검증현황\Defect 분석\검증계획서\총시기획"

    Private Sub lnkModel_LinkClicked(sender As Object, e As Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkModel.LinkClicked, lnkPlan.LinkClicked, lnkExpert.LinkClicked, LinkLabel1.LinkClicked, lnk_AppMapp.LinkClicked

        If DirectCast(sender, Control).Name = "lnkModel" Then      ' 1) 모델 시험기획 매핑
            Dim Model_Mapping As New Func_Change : Model_Mapping.Show()
        ElseIf DirectCast(sender, Control).Name = "lnkPlan" Then         ' 시험기획서
            Diagnostics.Process.Start(strPath)
        ElseIf DirectCast(sender, Control).Name = "lnkExpert" Then      ' Expert 인원 변경점 검증 방법
            Dim Expert As New Change : Expert.Show()
        ElseIf DirectCast(sender, Control).Name = "LinkLabel1" Then      ' Expert 인원 변경점 검증 방법
            Dim FuncCo As New M_Model_Plan_Mapp : FuncCo.Show()
        ElseIf DirectCast(sender, Control).Name = "lnk_AppMapp" Then      ' 앱매핑
            Diagnostics.Process.Start("\\10.169.88.40\Q-Portal\2.검증현황\Defect 분석\검증계획서\변경점작성")
        End If
        'lnk_AppMapp
    End Sub



    Private Sub Product_of_Model_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class