Imports System.Data
Imports System.Data.OleDb
Imports System.Drawing
Imports System.IO
Imports System.Windows.Forms
Imports Microsoft.Office.Interop

Public Class VP_Report_Page
    Private DS As DataSet = New DataSet
    Private DA As OleDbDataAdapter = New OleDbDataAdapter()
    Public ordAdapter As OleDbDataAdapter = New OleDbDataAdapter()
    Private strSQL As String
    Public strFilePath As String = Nothing ' "\\10.174.51.33\Q-Portal\VP Report"
    Public szPath As String = Nothing '"\\10.174.51.33\Q-Portal\VP Report\VP모델 상세현황"
    Private vConn As OleDbConnection
    Public strFile As String = Nothing
    Private szFile As String = Nothing

    '★ 처음 로드 될 때 
    Private Sub VP_Report_Page_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Icon = My.Resources.Qportal_Icon
        Dim XML As New XML
        XML.Folder_Path("VP", strFilePath)
        XML = Nothing

        'Picture Box Control 
        'Pic_Write.Image = Image.FromFile("\\10.174.51.33\Q-Portal\VP Report\VP_Report_Info.png")
        'Pic_Search.Image = Image.FromFile("\\10.174.51.33\Q-Portal\VP Report\VP_Report_Info.png")
        ' Pic_arrow.Image = Image.FromFile("\\10.174.51.33\Q-Portal\VP Report\arrow-32-32.png")
        'TabControl1.CreateGraphics.FillRectangle(fb, Rect)

    End Sub

    '★ 1번 VP Report 조회할 때
    Private Sub btn_VPSearch_Click(sender As Object, e As EventArgs)
        'Dim szFile As String = Nothing

        'VP_Report_조회.xlsm
        'Diagnostics.Process.Start("\\10.174.51.33\Q-Portal\VP Report\VP_Report_조회.xlsm")

        Dim Class1 As New Class1
        Dim strFileName As String = Nothing
        Try
            szFile = "VP_Report_조회.xlsm"
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

    Private Sub btn_Search_Click(sender As Object, e As EventArgs)
        ' VP Report가 있는 폴더 Open
        Dim szReport_Path As String = strFilePath & "\" & "최신버전"

        Shell("C:\Windows\explorer.exe " & szReport_Path, AppWinStyle.NormalFocus)
    End Sub


    'Sub OpenExcelFile(ByVal szFile As String, ByVal szPath As String)
    '    Dim strFileName As String = Nothing
    '    Dim szPath_Temp As String = Nothing
    '    Dim blChk As Boolean = False
    '    Dim strPathName As String = Nothing
    '    Try
    '        For Each entry As String In Directory.GetDirectories(szPath)        ' GetDirectories(Path) <- 해당 Path에 있는 Folder 및 Files 찾음
    '            ' 지정 한 경로를 반복 하면서 경로와 '구분'명과 일치하는 폴더를 찾음.
    '            ' 찾은 경로로 진입 하여 그 안의 파일명을 찾는다.
    '            Dim dirA As DirectoryInfo = New DirectoryInfo(entry)    ' 디렉토리 지정
    '            strPathName = entry

    '            For Each dra In dirA.GetFiles()     ' For each를 통해 폴더 내의 파일을 찾음

    '                If InStr(dra.Name, szFile) Then ' Consumer TC와 Kernel TC / Framework TC의 파일 Naming이 다름
    '                    szPath_Temp = entry
    '                    szFile = dra.Name
    '                    Exit For
    '                End If
    '            Next
    '        Next


    '        strFileName = szPath_Temp & "\" & szFile

    '        If IO.File.Exists(strFileName) Then
    '            blChk = True
    '            'If InStr(strFile, ".xlsx") Then       ' 만약 엑셀 파일 이라면
    '            Dim Proceed As Boolean = False
    '            Dim xlApp As Excel.Application = Nothing
    '            Dim xlWorkBooks As Excel.Workbooks = Nothing
    '            Dim xlWorkBook As Excel.Workbook = Nothing
    '            Dim xlWorkSheet As Excel.Worksheet = Nothing
    '            Dim xlWorkSheets As Excel.Sheets = Nothing
    '            Dim xlCells As Excel.Range = Nothing
    '            xlApp = New Excel.Application
    '            xlApp.DisplayAlerts = False
    '            xlWorkBooks = xlApp.Workbooks
    '            xlWorkBook = xlWorkBooks.Open(strFileName,, True)   ' Read Only Open
    '            xlApp.Visible = True
    '            xlWorkSheets = xlWorkBook.Sheets

    '            xlWorkBook = Nothing
    '            xlApp = Nothing

    '        Else
    '            MsgBox("파일을 열지 못했습니다.." & vbCrLf & szPath & "에서 " & szFile & "(이)가 있는지 확인 해보세요.")
    '            Exit Sub
    '        End If

    '        If blChk = False Then
    '            MsgBox("파일을 열지 못했습니다." & vbCrLf & szPath & "에서 " & szFile & "이 없거나, 권한이 없을 수 있습니다." _
    '                   & "권한을 요청 해주세요.")
    '            Exit Sub
    '        End If

    '    Catch ex As Exception
    '        MsgBox(ex.Message, "열려는 파일이 없습니다." & vbCrLf & strFileName & "에서 확인 해보세요.")
    '    End Try
    'End Sub

    Private Sub btn_Report_Recently_Click(sender As Object, e As EventArgs) Handles btn_Report_Recently.Click

        ' VP 상세 현황 열기
        Dim szFile As String = "2017"
        szPath = strFilePath + "\" + "VP모델 상세현황"
        Try
            For Each entry As String In Directory.GetDirectories(szPath)        ' GetDirectories(Path) <- 해당 Path에 있는 Folder 및 Files 찾음
                ' 지정 한 경로를 반복 하면서 경로와 '구분'명과 일치하는 폴더를 찾음.
                ' 찾은 경로로 진입 하여 그 안의 파일명을 찾는다.
                Dim dirA As DirectoryInfo = New DirectoryInfo(entry)    ' 디렉토리 지정
                If InStr(dirA.Name, szFile) Then
                    szFile = entry
                    Exit For
                End If
            Next
            Diagnostics.Process.Start("C:\Windows\explorer.exe ", String.Format("/n, /e, {0}", szFile))

        Catch ex As Exception
            MsgBox(ex.Message, "lee.sunbae@lgepartner.com")
        End Try

    End Sub


    Private Sub btn_Older_Click(sender As Object, e As EventArgs) Handles btn_Older.Click
        Dim szFile As String = "2016"
        szPath = strFilePath + "\" + "VP모델 상세현황"
        Try
            For Each entry As String In Directory.GetDirectories(szPath)        ' GetDirectories(Path) <- 해당 Path에 있는 Folder 및 Files 찾음
                ' 지정 한 경로를 반복 하면서 경로와 '구분'명과 일치하는 폴더를 찾음.
                ' 찾은 경로로 진입 하여 그 안의 파일명을 찾는다.
                Dim dirA As DirectoryInfo = New DirectoryInfo(entry)    ' 디렉토리 지정
                If InStr(dirA.Name, szFile) Then
                    szFile = entry
                    Exit For
                End If
            Next
            Diagnostics.Process.Start("C:\Windows\explorer.exe ", String.Format("/n, /e, {0}", szFile))

        Catch ex As Exception
            MsgBox(ex.Message, "lee.sunbae@lgepartner.com")
        End Try

    End Sub

    Private Sub btn_NT_Track_now_Click(sender As Object, e As EventArgs) Handles btn_NT_Track_now.Click
        ' VP Model N/T Tracking 
        ' VP 상세 현황 열기
        Dim szFile As String = "2017"
        szPath = strFilePath + "\" + "VP Test Case현황"
        Try
            For Each entry As String In Directory.GetDirectories(szPath)        ' GetDirectories(Path) <- 해당 Path에 있는 Folder 및 Files 찾음
                ' 지정 한 경로를 반복 하면서 경로와 '구분'명과 일치하는 폴더를 찾음.
                ' 찾은 경로로 진입 하여 그 안의 파일명을 찾는다.
                Dim dirA As DirectoryInfo = New DirectoryInfo(entry)    ' 디렉토리 지정
                If InStr(dirA.Name, szFile) Then
                    szFile = entry
                    Exit For
                End If
            Next
            Diagnostics.Process.Start("C:\Windows\explorer.exe ", String.Format("/n, /e, {0}", szFile))

        Catch ex As Exception
            MsgBox(ex.Message, "lee.sunbae@lgepartner.com")
        End Try
    End Sub
    Private Sub btn_NT_Track_older_Click(sender As Object, e As EventArgs) Handles btn_NT_Track_older.Click
        ' VP Model N/T Tracking 
        Dim szFile As String = "2016"
        szPath = strFilePath + "\" + "VP Test Case현황"
        Try
            For Each entry As String In Directory.GetDirectories(szPath)        ' GetDirectories(Path) <- 해당 Path에 있는 Folder 및 Files 찾음
                ' 지정 한 경로를 반복 하면서 경로와 '구분'명과 일치하는 폴더를 찾음.
                ' 찾은 경로로 진입 하여 그 안의 파일명을 찾는다.
                Dim dirA As DirectoryInfo = New DirectoryInfo(entry)    ' 디렉토리 지정
                If InStr(dirA.Name, szFile) Then
                    szFile = entry
                    Exit For
                End If
            Next
            Diagnostics.Process.Start("C:\Windows\explorer.exe ", String.Format("/n, /e, {0}", szFile))

        Catch ex As Exception
            MsgBox(ex.Message, "lee.sunbae@lgepartner.com")
        End Try
    End Sub

    '★ LG CNS 경로 선택했을 때
    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnk_cns.LinkClicked, lnk_infiniq.LinkClicked, lnk_mstech.LinkClicked

        ' Import 해야 함 System.IO

        If DirectCast(sender, Control).Name = "lnk_cns" Then
            Diagnostics.Process.Start(lnk_cns.Text)
        ElseIf DirectCast(sender, Control).Name = "lnk_mstech" Then
            Diagnostics.Process.Start(lnk_mstech.Text)
        ElseIf DirectCast(sender, Control).Name = "lnk_infiniq" Then
            Diagnostics.Process.Start(lnk_infiniq.Text)
        End If

    End Sub

    Private Sub requestBtn_Click(sender As Object, e As EventArgs) Handles requestBtn.Click, requestBtn_detail.Click, requestBtn_run.Click, requestBtn_go.Click

    End Sub

    Private Sub Label14_Click(sender As Object, e As EventArgs)
        Dim Class1 As New Class1
        Dim strFileName As String = Nothing
        Try
            szFile = "VP_Report_조회_작업중.xlsm"
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

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'Dim szFile As String = Nothing

        'VP_Report_조회.xlsm
        'Diagnostics.Process.Start("\\10.174.51.33\Q-Portal\VP Report\VP_Report_조회.xlsm")

        Dim Class1 As New Class1
        Dim strFileName As String = Nothing
        Try
            szFile = "VP_Report_조회_작업중.xlsm"
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

    Private Sub TabControl1_draw(sender As Object, e As TabControlEventArgs) Handles TabControl1.Selected

        'Select Case e.Index
        '    Case 0
        '        e.Graphics.FillRectangle(New SolidBrush(Color.White), e.Bounds)
        '    Case 1
        '        e.Graphics.FillRectangle(New SolidBrush(Color.White), e.Bounds)
        '    Case 2
        '        e.Graphics.FillRectangle(New SolidBrush(Color.White), e.Bounds)
        '    Case 3
        '        e.Graphics.FillRectangle(New SolidBrush(Color.White), e.Bounds)
        'End Select



    End Sub

    Private Sub TabPage1_Click(sender As Object, e As EventArgs) Handles TabPage1.Click

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        '## 투입 MD 조회 
        Dim szKnowHow As String = Nothing
        szKnowHow = strFilePath + "/" + "변경점조회(검증계획,투입MD)"
        Dim szFile As String = "Random조회_전용"
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
            If class1.isFileOpen(strFileName) Then
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


End Class