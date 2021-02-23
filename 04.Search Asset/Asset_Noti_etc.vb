Imports System.Data
Imports System.Data.OleDb
Imports System.Xml
Imports System.Windows.Forms
Imports Microsoft.Office.Interop

Public Class Asset_Noti_etc
    Private DS As DataSet = New DataSet
    Private DA As OleDbDataAdapter = New OleDbDataAdapter()
    Public ordAdapter As OleDbDataAdapter = New OleDbDataAdapter()
    Private strSQL As String
    Public strFilePath As String = Nothing '"\\10.174.51.33\Q-Portal\호환성,시료,자산조회"
    Private vConn As OleDbConnection
    Public strFile As String = Nothing
    Public szFile As String = Nothing
    Public tt_file As String = nothing


    Private Sub Asset_Noti_etc_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Icon = My.Resources.Qportal_Icon
        ' Text Box 설명 
        Sample_Search_txt.Text = "시료 현황을 조회할 수 있습니다." & vbCrLf & "  ※ 각 업체별 현황 조회 가능"
        Asset_Search_txt.Text = "호환성 장비 보유 현황 확인 할 수 있습니다." & vbCrLf & "  ※ ex HBS-1100보유 여부, SD Card 보유 현황"
        WorkNoti_Search_txt.Text = "업체별로 뿌려진 공지사항을 확인할 수 있습니다." & vbCrLf & "  ※ 업체별 Guide 준수 요청, etc"

        Dim XML As New XML
        XML.Folder_Path("Asset", strFilePath)
        XML.Folder_Path("통합업무관리", tt_file)
        XML = Nothing

    End Sub

    '★ [시료 현황 조회] 엑셀 이미지 버튼 선택 시.
    Private Sub btn_Device_Click(sender As Object, e As EventArgs) Handles btn_Device.Click
        Dim strFileName As String = Nothing
        Try

            szFile = "시료조회.xlsm"
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
    '★ [호환성조회] 엑셀 이미지 버튼 선택 시.
    Private Sub btn_Asset_Click(sender As Object, e As EventArgs) Handles btn_Asset.Click
        Dim strFileName As String = Nothing
        Try
            szFile = "호환성 장비 List.xlsx"
            strFileName = "\\10.169.88.40\Q-Portal\1.검증정보\통합업무관리\호환성장비 List" & "\" & szFile

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
    '★ [업무공지조회] 엑셀 이미지 버튼 선택 시.
    Private Sub btn_WorkNoti_Click(sender As Object, e As EventArgs) Handles btn_WorkNoti.Click
        Dim strFileName As String = Nothing
        Dim realPath As String = "\\10.169.88.40\Q-Portal\1.검증정보\통합업무관리"
        Try
            '통합업무관리
            szFile = "업무공지조회.xlsm"
            strFileName = realPath & "\" & szFile

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
                MsgBox("열려는 파일이 없습니다." & vbCrLf & realPath & " 경로에 " & szFile & "(이)가 있는지 확인 해보세요.")
                Exit Sub
            End If

        Catch ex As Exception
            MsgBox(ex.Message, "열려는 파일이 없습니다." & vbCrLf & realPath & " 경로에 " & szFile & "(이)가 있는지 확인 해보세요.")
        End Try
    End Sub

    Private Sub requestBtn_Click(sender As Object, e As EventArgs) Handles requestBtn.Click
        '제안하기 폼

    End Sub
End Class