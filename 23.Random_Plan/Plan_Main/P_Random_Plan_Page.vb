Imports System.Diagnostics
Imports System.IO
Imports System.Windows.Forms

Public Class P_Random_Plan_Page

#Region "[Load Event] - 큐포탈 아이콘"
    Private Sub Random_Plan_Page_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Icon = My.Resources.Qportal_Icon
    End Sub
#End Region

#Region "[설명 보여주는 부분]"
    Private Sub MouseEvent_Description(sender As Object, e As EventArgs) Handles la_pro_one.MouseMove, la_pro_three.MouseMove, la_pro_four.MouseMove, la_pro_five.MouseMove, la_pro_six.MouseMove

        Select Case DirectCast(sender, Control).Name

            Case "la_pro_one"      '# 총시 변경점 등록 (Excel)
                txtDescription.Text = " 전략 프로젝트 및 중요 프로젝트만 엑셀로 등록을 합니다. " & Environment.NewLine & "변경점을 엑셀로 등록"

            Case "la_pro_two"       '# Project 기획
                txtDescription.Text = " 등록 된 변경점을 PJT(Project)에 대한 시험기획을 수립합니다."

            Case "la_pro_three"      '# 모델 기획  앱 맵핑 (Q Portal)
                txtDescription.Text = " 매 모델 시작 전 등록 된 변경점을 가지고 변경점을 APP에 할당 시켜줍니다.  "

            Case "la_pro_four"      '#  Risk Factor 작성 (Excel)
                txtDescription.Text = " 맵핑이 완료 된 상태에서 맵핑 된 데이터에 대해서 모델리더가 Risk Factor를 작성 합니다."

            Case "la_pro_five"    '# 기능/APP 검증방법 작성 (Q Portal) - Expert 인원
                txtDescription.Text = " 모델리더가 작성 한 Risk Factor와 변경점들을 보며 Expert 급 인원이 추가 검증사항을 수립 합니다."

            Case "la_pro_six"       '# 실사용 검증 방법 작성 (Excel)
                txtDescription.Text = " 각 수립 된 검증기획을 실제로 검증원이 수행 합니다."

        End Select



    End Sub
#End Region

#Region "[아이템 클릭 시 각 항목으로 이동]"
    '                                   \\10.169.88.40\Q-Portal\2.검증현황\Defect 분석\검증계획서\시험기획서
    Public strPath As String = "\\10.169.88.40\Q-Portal\2.검증현황\Defect 분석\검증계획서\시험기획서"
    Private Sub Items_Click_Events(sender As Object, e As EventArgs) Handles la_pro_one.Click, la_pro_three.Click, la_pro_four.Click, la_pro_five.Click, la_pro_six.Click

        Dim strPath As String = Nothing

        Select Case DirectCast(sender, Control).Name

            Case "la_pro_one"      '# 총시 변경점 등록 (Excel)
                Dim P_Project_Upload As New P_Project_Upload
                P_Project_Upload.Show()

            Case "la_pro_two"       '# Project 기획
                Dim frmPlan_Search As New P_Project_Plan
                frmPlan_Search.Show()

            Case "la_pro_three"      '# 모델 기획  앱 맵핑 (Q Portal)
                Dim FuncCo As New M_Model_Plan_Mapp : FuncCo.Show()  '# 매핑 예전 버전

            Case "la_pro_four"      '#  Risk Factor 작성 (Excel)
                Dim PM_Write_RiskFactor As New PM_Write_RiskFactor
                PM_Write_RiskFactor.Show()

            Case "la_pro_five"    '# 기능/APP 검증방법 작성 (Q Portal) - Expert 인원
                Dim Expert As New Change : Expert.Show()

            Case "la_pro_six"       '# 실사용 검증 방법 작성 (Excel)
                Dim PM_Write_RiskFactor As New PM_Write_RiskFactor
                PM_Write_RiskFactor.Show()

        End Select


    End Sub
#End Region

#Region "엑셀 다운로드 기능"

    Private Function DownExcel(ByRef strPath As String, ByRef strFindFile As String) As String

        '# 지정경로 안에서 '시험기획서_Access_v1.3' 찾기 후 파일 Copy
        Dim strFolder As String = Nothing
        Dim dir As DirectoryInfo = New DirectoryInfo(strPath)
        Dim strRealFile As String = Nothing : Dim strFile As String
        Dim strFullPath As String = Nothing
        For Each dr In dir.GetFiles()
            strFile = dr.Name   '# file name
            If InStr(strFile, strFindFile) And Strings.Left(strFile, 2) <> "~$" Then
                strRealFile = dr.Name
                strFullPath = dr.FullName
                Exit For
            End If
        Next

        Dim bytesRead As Integer
        Dim buffer(4096) As Byte

        '# ByteStream 으로 Application Setpup Folder에 File 저장
        Using inFile As New System.IO.FileStream(strFullPath, IO.FileMode.Open, IO.FileAccess.Read) ' 여기에 있는 파일을
            Using outFile As New System.IO.FileStream(Application.StartupPath + strRealFile, IO.FileMode.Create, IO.FileAccess.Write)   '# 원하는 경로로 
                Do
                    bytesRead = inFile.Read(buffer, 0, buffer.Length)
                    If bytesRead > 0 Then
                        outFile.Write(buffer, 0, bytesRead)
                    End If
                Loop While bytesRead > 0
            End Using
        End Using

        '# saveFileDialog 생성
        Dim dlg As New SaveFileDialog With {
            .FileName = strFindFile,
            .DefaultExt = ".xlsx",
            .Filter = "Excel File|*.xlsx",
            .Title = "엑셀 저장하기 | lee.sunbae@lgepartner.com"
        }

        Try
            If dlg.ShowDialog() = DialogResult.OK Then
                Dim openFileName As String = Nothing

                '# Save the files
                File.Copy(Application.StartupPath + strRealFile, dlg.FileName, True)

                Dim strTemp() As String : strTemp = Split(dlg.FileName, "\")
                '# saveFileDialog 에서 받아오는 String은 최종 파일 명까지 가져오기 때문에
                '# 폴더를 열어주기 위해 실제 경로만 담기 위해서 
                Array.Resize(strTemp, strTemp.Length - 1)
                strFolder = String.Join("\", strTemp)

                DownExcel = strFolder

            Else
                Debug.Print("정상")

            End If
        Catch ex As Exception
            Debug.Print("닫혔다 --> Exception으로" & ex.Message & CDate(Now))
        Finally
            DownExcel = strFolder
        End Try

        '# Return 해야 할 것은 최종 Local Path 
        Return DownExcel

    End Function



#End Region


End Class