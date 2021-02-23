

Imports System.Windows.Forms

Public Class PN_MAIN

#Region "큐포탈 처음 실행 시 "
    Private Sub PN_2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Icon = My.Resources.Qportal_Icon
    End Sub
#End Region

#Region "마우스 갖다대면 설명 보여주는 부분"

    Private Sub MouseMoveDes(sender As Object, e As EventArgs) Handles la_mod_one.MouseMove, la_mod_two.MouseMove, la_mod_three.MouseMove, la_mod_four.MouseMove

        Select Case DirectCast(sender, Control).Name
            Case "la_mod_one"      '# 모델 기획  앱 맵핑 (Q Portal)
                txtDescription.Text = " 모델 변경 점 등록 합니다. "
            Case "la_mod_two"      '# 모델 기획  앱 맵핑 (Q Portal)
                txtDescription.Text = " 매 모델 시작 전 등록 된 변경점을 가지고 변경점을 APP에 할당 시켜줍니다.  "
            Case "la_mod_three"      '#  Risk Factor 작성 (Excel)
                txtDescription.Text = " 맵핑이 완료 된 상태에서 맵핑 된 데이터에 대해서 모델리더가 Risk Factor를 작성 합니다."
            Case "la_mod_four"    '# 기능/APP 검증방법 작성 (Q Portal) - Expert 인원
                txtDescription.Text = " 모델리더가 작성 한 Risk Factor와 변경점들을 보며 Expert 급 인원이 추가 검증사항을 수립 합니다."
            Case "la_mod_five"       '# 실사용 검증 방법 작성 (Excel)
                txtDescription.Text = " 각 수립 된 검증기획을 실제로 검증원이 수행 합니다."
            Case Else
                txtDescription.Text = "기능의 이름부분에 마우스를 갖다 대면 설명을 보여줍니다."
        End Select
    End Sub

#End Region

#Region "항목 클릭 시 항목 열리게 하는 부분"
    Private Sub Items_Click_Events(sender As Object, e As EventArgs) Handles la_mod_one.Click, la_mod_two.Click, la_mod_three.Click, la_mod_four.Click, la_mod_five.Click

        Dim strPath As String = Nothing

        Select Case DirectCast(sender, Control).Name

            Case "la_mod_one"  '# 변경점 등록하기
                Dim M_Model_Plan_U As New pl_updown
                M_Model_Plan_U.Show()

            Case "la_mod_two"      '# 모델 기획  앱 맵핑 (Q Portal)
                Dim FuncCo As New M_Model_Plan_Mapp : FuncCo.Show()  '# 매핑 예전 버전

            Case "la_mod_three"      '#  Risk Factor 작성 (Excel)
                Dim PM_Write_RiskFactor As New pl_Export_Upload
                PM_Write_RiskFactor.Show()

            Case "la_mod_four"    '# 기능/APP 검증방법 작성 (Q Portal) - Expert 인원
                Dim Expert As New Change : Expert.Show()

            Case "la_mod_five"       '# 실사용 검증 방법 작성 (Excel)
                Dim PM_Write_RiskFactor As New PM_Write_RiskFactor
                PM_Write_RiskFactor.Show()

        End Select


    End Sub
#End Region


End Class