Imports System.IO
Imports Excel = Microsoft.Office.Interop.Excel
Imports System.Windows.Forms



Public Class Random_Analysis
    Public strFilePath As String = Nothing ' "\\10.174.51.33\Q-Portal\1.랜덤_분석전용"
    Public szKnowHow As String = Nothing 'strFilePath & "\Random Know-How"
    Public szKnowHow_byModel As String = Nothing 'strFilePath & "\모델별 Random Know-How"


    Private Sub btn_Random_Click(sender As Object, e As EventArgs) Handles btn_Random.Click
        szKnowHow = strFilePath + "/" + "변경점조회(검증계획,투입MD)"
        Dim szFile As String = "Random조회_전용"
        Call OpenExcelFile(szKnowHow, szFile)

    End Sub

    Private Sub btn_Open_QMTT_Click(sender As Object, e As EventArgs) Handles btn_Open_QMTT.Click
        ' 랜덤노하우 QMTT 열기
        szKnowHow = strFilePath + "/" + "Leakage분석(RandomKnow-How)"
        Dim szFile As String = "Random_Know-How_QM_TT1_"
        Call OpenExcelFile(szKnowHow, szFile)
    End Sub

    Sub OpenExcelFile(ByVal szFilePath As String, ByVal szFile As String)
        Dim strFileName As String = Nothing
        Dim class1 As New Class1


        Try
            ' 찾은 경로로 진입 하여 그 안의 파일명을 찾는다.
            Dim dirA As DirectoryInfo = New DirectoryInfo(szFilePath)    ' 디렉토리 지정
            For Each dra In dirA.GetFiles()     ' For each를 통해 폴더 내의 파일을 찾음
                If InStr(dra.Name, szFile) Then  ' Consumer TC와 Kernel TC / Framework TC의 파일 Naming이 다름
                    szFile = dra.Name
                    Exit For
                End If
            Next

            strFileName = szFilePath & "\" & szFile

            ' 파일이 켜져있는지 확인
            If Class1.isFileOpen(strFileName) Then
                'MsgBox("파일이 열려있습니다.")   '파일을 복사하여 파일 저장 위치를 바꿔줌
                File.Copy(szFilePath, Application.StartupPath + szFile, True)
                strFilePath = Application.StartupPath
            End If



            If IO.File.Exists(strFileName) Then
                'If InStr(strFile, ".xlsx") Then       ' 만약 엑셀 파일 이라면
                Dim Proceed As Boolean = False
                Dim xlApp As Excel.Application = Nothing
                Dim xlWorkBooks As Excel.Workbooks = Nothing
                Dim xlWorkBook As Excel.Workbook = Nothing
                Dim xlWorkSheet As Excel.Worksheet = Nothing
                Dim xlWorkSheets As Excel.Sheets = Nothing
                Dim xlCells As Excel.Range = Nothing
                xlApp = New Excel.Application
                xlApp.DisplayAlerts = False
                xlWorkBooks = xlApp.Workbooks
                xlWorkBook = xlWorkBooks.Open(strFileName,, True)   ' Read Only Open
                xlApp.Visible = True
                xlWorkSheets = xlWorkBook.Sheets

                xlWorkBook = Nothing
                xlApp = Nothing

            Else
                MsgBox("열려는 파일이 없습니다." & vbCrLf & szFilePath & "에서 " & szFile & "(이)가 있는지 확인 해보세요.")
                Exit Sub
            End If

        Catch ex As Exception
            MsgBox(ex.Message, "열려는 파일이 없습니다." & vbCrLf & strFileName & "에서 확인 해보세요.")
        End Try
    End Sub

    Private Sub Random_Analysis_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Icon = My.Resources.Qportal_Icon
        Random_Search_txt.Text = "1) Random 투입 MD 현황 확인 (앱 검증 계획서 MD조회" & vbCrLf _
                                 & vbCrLf & "2) Random 계획 내역 조회(랜덤에 대한 계획수립 이력 조회)"

        Dim XML As New XML
        XML.Folder_Path("Defect", strFilePath)
        XML = Nothing


    End Sub

    Private Sub btn_Model_Click(sender As Object, e As EventArgs) Handles btn_Model.Click
        szKnowHow_byModel = strFilePath + "\" + "Defect분석(모델별RandomKnow-How)"
        Try
            Shell("C:\Windows\explorer.exe " & szKnowHow_byModel, AppWinStyle.NormalFocus)
        Catch ex As Exception
            MsgBox(ex.Message, "lee.sunbae@lgepartner.com")
        End Try
    End Sub

    Private Sub requestBtn_Click(sender As Object, e As EventArgs) Handles requestBtn.Click

    End Sub
End Class