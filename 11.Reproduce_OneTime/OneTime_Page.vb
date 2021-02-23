Imports System.IO
Imports System.Windows.Forms
Imports Microsoft.Office.Interop

Public Class One_Time_Page
    Public strFilePath As String = Nothing '"\\10.174.51.33\Q-Portal\1회성_재현전담"
    Private szFile As String = Nothing
    Private szTemp As String = Nothing
    Private szMerge As String = Nothing

    Private Sub One_Time_Page_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Icon = My.Resources.Qportal_Icon
        Dim XML As New XML
        XML.Folder_Path("OneTime", strFilePath)
        XML = Nothing
        lnk_onetime.Text = strFilePath

    End Sub

    Private Sub btn_Write_Click(sender As Object, e As EventArgs) Handles btn_Write.Click
        'Dim szFile As String = Nothing
        Dim strFileName As String = Nothing
        Dim Class1 As New Class1
        Try

            szFile = "1회성_재현입력.xlsm"
            strFileName = strFilePath & "\" & szFile

            ' 파일이 켜져있는지 확인
            If Class1.isFileOpen(strFileName) Then
                'MsgBox("파일이 열려있습니다.")   '파일을 복사하여 파일 저장 위치를 바꿔줌
                File.Copy(strFilePath, Application.StartupPath + szFile, True)
                strFileName = Application.StartupPath
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

            Else
                MsgBox("열려는 파일이 없습니다." & vbCrLf & strFilePath & "에서 " & szFile & "(이)가 있는지 확인 해보세요.")
                Exit Sub
            End If

        Catch ex As Exception
            MsgBox(ex.Message, "열려는 파일이 없습니다." & vbCrLf & strFileName & "에서 확인 해보세요.")
        End Try
    End Sub

    Private Sub btn_Search_Click(sender As Object, e As EventArgs) Handles btn_Search.Click
        'Dim szFile As String = Nothing
        Dim strFileName As String = Nothing
        Try
            szFile = "1회성_조회하기.xlsm"
            strFileName = strFilePath & "\" & szFile

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

            Else
                MsgBox("열려는 파일이 없습니다." & vbCrLf & strFilePath & "에서 " & szFile & "(이)가 있는지 확인 해보세요.")
                Exit Sub
            End If

        Catch ex As Exception
            MsgBox(ex.Message, "열려는 파일이 없습니다." & vbCrLf & strFileName & "에서 확인 해보세요.")
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' 폴더 열기
        Dim szFileOpen As String = strFilePath & "\" & "ART_Script"
        Shell("C:\Windows\explorer.exe " & szFileOpen, AppWinStyle.NormalFocus)
    End Sub

    '★ 경로 확인 부분 링크 선택 했을 때
    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnk_onetime.LinkClicked
        Diagnostics.Process.Start(lnk_onetime.Text)
    End Sub

    Private Sub requestBtn_Click(sender As Object, e As EventArgs) Handles requestBtn.Click

    End Sub

    Private Sub btn_ppt_Click(sender As Object, e As EventArgs) Handles btn_ppt.Click
        'ppt열기  ( 1회성 Issue 재현 표준 매뉴얼 )
        Dim blchk As Boolean = False
        Dim szFileName As String = Nothing
        'Dim szFullPath As String = "\\10.174.51.33\Q-Portal\2.검증현황\1회성 분석\1회성 Issue 재현 표준 매뉴얼"
        'Dim szFullPath As String = strFilePath & "\" & "1회성 Issue 재현 표준 매뉴얼"
        Dim szFullPath As String = strFilePath & "\" & "1회성 Issue 재현 표준 매뉴얼"
        Dim strFile As String = "1회성 재현인자"
        Dim dirA As DirectoryInfo = New DirectoryInfo(szFullPath)    ' 디렉토리 지정 
        For Each dra In dirA.GetFiles()     ' For each를 통해 폴더 내의 파일을 찾음 
            szTemp = dra.Name
            If InStr(Trim(dra.Name), RTrim(strFile)) And Strings.Left(szTemp, 2) <> "~$" Then  ' Consumer TC와 Kernel TC / Framework TC의 파일 Naming이 다름 
                szFileName = dra.Name
                blchk = True
                Exit For
            End If
        Next

        If blchk Then
            szMerge = szFullPath & "\" & szFileName
            Diagnostics.Process.Start(szMerge)

        Else
            MsgBox(strFile & " 파일이 없는 것 같습니다. " & szFullPath & " <-- 경로에 파일이 있는지, 파일명도 확인해주세요 ")
        End If

    End Sub
End Class