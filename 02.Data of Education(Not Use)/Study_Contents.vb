Imports System.Data
Imports System.Data.OleDb
Imports System.IO
Imports Microsoft.Office.Interop

Public Class Study_Contents
    '##### [교육 자료] ######
    Private DS As DataSet = New DataSet
    Private DA As OleDbDataAdapter = New OleDbDataAdapter()
    Public ordAdapter As OleDbDataAdapter = New OleDbDataAdapter()
    Private strSQL As String
    Private vConn As OleDbConnection
    Private InfoConn As OleDbConnection
    Public XML As New XML
    Public strOpenPath As String = Nothing
    Public strFilePath As String = Nothing
    Public vCon As String = Nothing
    Dim strSht As String = "Sheet1"             ' DB로 사용할 엑셀 문서의 시트 이름 

    Private Sub Study_Contents_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Icon = My.Resources.Qportal_Icon
        '## 처음 Form이 Load될 때 ! ##
        Dim szMerge As String = Nothing
        Dim szFileName As String = Nothing
        Dim blChk As Boolean = False
        Dim strFile As String = "교육관련 문서 List"      ' DB로 사용할 엑셀 문서의 파일 이름 앞부분.
        Dim szTemp As String = Nothing

        Try
            Dim XML As New XML                              ' XML.vb 파일을 사용하기 위해 선언
            XML.Folder_Path("Study_Contents", strFilePath)  ' xml에 있는 내용 중 Node이름이 "Study_Contents"인 것을 찾음. (경로가 담겨있음)
            XML = Nothing

            ' 지정 한 경로를 반복 하면서 경로와 '구분'명과 일치하는 폴더를 찾음.
            ' 찾은 경로로 진입 하여 그 안의 파일명을 찾는다.
            Dim dirA As DirectoryInfo = New DirectoryInfo(strFilePath)    ' 디렉토리 지정
            For Each dra In dirA.GetFiles()     ' For each를 통해 폴더 내의 파일을 찾음
                szTemp = dra.Name
                If InStr(Trim(dra.Name), RTrim(strFile)) And Strings.Left(szTemp, 2) <> "~$" Then  ' Consumer TC와 Kernel TC / Framework TC의 파일 Naming이 다름
                    szFileName = dra.Name
                    blChk = True
                End If
            Next

            '예외처리
            If blChk Then
                szMerge = strFilePath & "\" & szFileName
            Else
                MsgBox(strFile & " 파일이 없는 것 같습니다. " & strFilePath & " <-- 경로에 파일이 있는지, 파일명도 확인해주세요 ")
            End If


            ' 교육 자료 공유 가 처음 Load 될 때 
            Dim strExcel As String = "Provider=Microsoft.Ace.OLEDB.12.0;Data Source=" & szMerge & ";Extended Properties=""Excel 12.0;HDR=YES;"""
            InfoConn = New OleDbConnection(strExcel)    ' DB 오픈하기 위해 Connection 

            '#### 쿼리 작성 #########################################################
            Dim vSQL As String = "SELECT * " & " "
            vSQL = vSQL + "FROM [" & strSht & "$B3:G1000]" & " "
            '#######################################################################

            DA = New OleDbDataAdapter(vSQL, InfoConn)   ' DB 연결
            'Dim DS As New DataSet
            DA.Fill(DS, strSht)                         ' DB 조회 값을 DS에 담음.

            Dim Table As DataTable = DS.Tables(0)
            strFile = Nothing

            '★ [대상] 콤보박스에 값 넣는 부분
            For i As Integer = 0 To Table.Rows.Count - 1                            ' Data table Row 만큼 반복 -1은 마지막행은 Null
                If Not cb_Target.Items.Contains(Table.Rows(i)(1).ToString()) Then   ' 중복 없이 Item 추가  "Contains" <-- 중복이 아닌 경우만 
                    cb_Target.Items.Add(Table.Rows(i)(1).ToString())                ' 콤보박스에 아이템 Add 
                End If
            Next

            'Dim szTarget As String = Table.Rows(0)(1).ToString()
            'Dim szStep As String = Table.Rows(1)(1).ToString()
            'Dim szTitle As String = Table.Rows(2)(1).ToString()
            'Dim szDes As String = Table.Rows(4)(1).ToString()
            'Dim szFile_Name As String = Table.Rows(4)(2).ToString()

            ' Des_Txt.Text = Replace(strTxtDef, Chr(10), Chr(13) & Chr(10))


            'TCnameTxt.Text = Replace(szTCName, Chr(10), Chr(13) & Chr(10))
            'TCPurposeTxt.Text = Replace(szPur, Chr(10), Chr(13) & Chr(10))
            'DetectedTxt.Text = Replace(szDetect, Chr(10), Chr(13) & Chr(10))

            'txt_Base.Text = Replace(szBase, Chr(10), Chr(13) & Chr(10))
            'Txt_Semi.Text = Replace(szSemi, Chr(10), Chr(13) & Chr(10))
            'Txt_CA.Text = Replace(szCA, Chr(10), Chr(13) & Chr(10))

            'MDTxt.Text = Replace(szMD, Chr(10), Chr(13) & Chr(10))
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try



    End Sub

    Private Sub cb_Target_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cb_Target.SelectedIndexChanged
        '★ [대상]을 클릭 했을 때 [단계]에 다음 아이템이 나오 도록
        '★ 즉 2번째 박스에 값 뿌려주기 위함.
        '★ [단계] 콤보박스에 값 넣어주는 부분
        Try
            Dim Table As DataTable = DS.Tables(0)   ' DataSet을 Table에 담음.

            txt_Des.Text = ""                       ' 설명부분 초기화
            txt_FileName.Text = ""                  ' 파일이름 부분 초기화.

            cb_Step.Items.Clear()                   ' [단계] 콤보박스 값 미리 초기화
            lst_Title.Items.Clear()                 ' Title ListBox 초기화

            For i As Integer = 0 To Table.Rows.Count - 1                             ' Data table Row 만큼 반복 -1은 마지막행은 Null
                If cb_Target.Text = Table.Rows(i)(1).ToString() Then                 ' 만약, [대상] 콤보박스에서 선택한 항목과 DB의 '대상'과 같다면 
                    If Not cb_Step.Items.Contains(Table.Rows(i)(2).ToString()) Then  ' 중복 없이 Item 추가
                        cb_Step.Items.Add(Table.Rows(i)(2).ToString())
                    End If
                End If
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


    End Sub

    Private Sub cb_Step_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cb_Step.SelectedIndexChanged
        '★ 단계를 클릭 했을 때 Title 값을 뿌려주기 위함.
        '★ 즉 2번째 박스에 값 뿌려주기 위함.

        Try
            Dim Table As DataTable = DS.Tables(0)

            ' lstDep.Items.Clear()
            txt_Des.Text = ""                       ' 설명부분 초기화
            txt_FileName.Text = ""                  ' 파일이름 부분 초기화.

            lst_Title.Items.Clear()                 ' Title ListBox 초기화

            For i As Integer = 0 To Table.Rows.Count - 1            ' Data table Row 만큼 반복 -1은 마지막행은 Null
                If cb_Target.Text = Table.Rows(i)(1).ToString() And cb_Step.Text = Table.Rows(i)(2).ToString() Then ' 만약,  [대상] 콤보박스에서 선택한 항목과 DB의 '대상'과 같고, [단계] 선택항목과, db의 '단계' 내용이 같다면
                    If Not lst_Title.Items.Contains(Table.Rows(i)(3).ToString()) Then  ' 중복 없이 Item 추가
                        lst_Title.Items.Add(Table.Rows(i)(3).ToString())
                    End If
                End If
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub cb_Title_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lst_Title.SelectedIndexChanged
        '★ Title을 클릭 했을 때 상세 분류 값을 뿌려주기 위함.
        '★ 즉 2번째 박스에 값 뿌려주기 위함.

        Try
            Dim Table As DataTable = DS.Tables(0)

            txt_Des.Text = ""
            txt_FileName.Text = ""

            For i As Integer = 0 To Table.Rows.Count - 1            ' Data table Row 만큼 반복 -1은 마지막행은 Null
                If cb_Target.Text = Table.Rows(i)(1).ToString() And cb_Step.Text = Table.Rows(i)(2).ToString() And lst_Title.Text = Table.Rows(i)(3).ToString() Then
                    Dim szDes As String = Table.Rows(i)(4).ToString()
                    txt_Des.Text = Replace(szDes, Chr(10), Chr(13) & Chr(10))   ' replace(설명, char(10) <- 잘바꿈, 키보드 Enter 값)
                    txt_FileName.Text = Table.Rows(i)(5).ToString()

                End If
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    '★ 교육 자료를 실제로 열 때
    Private Sub btn_Open_Click(sender As Object, e As EventArgs) Handles btn_Open.Click
        Dim Table As DataTable = DS.Tables(0)
        Dim szFile As String = txt_FileName.Text
        Dim szPath_Temp As String = Nothing
        Dim strPathName As String = Nothing

        '★ 빈칸인, 파일명 없는 파일 열려고 했을 때의 예외 처리
        If cb_Target.Text = "" Or cb_Step.Text = "" Or lst_Title.Text = "" Then
            MsgBox("열고싶은 파일을 선택 후 열어주세요.")
            Exit Sub
        End If

        ' 해당 파일 열기
        For Each entry As String In Directory.GetDirectories(strFilePath)        ' GetDirectories(Path) <- 해당 Path에 있는 Folder 및 Files 찾음
            ' 지정 한 경로를 반복 하면서 경로와 '구분'명과 일치하는 폴더를 찾음.
            ' 찾은 경로로 진입 하여 그 안의 파일명을 찾는다.
            Dim dirA As DirectoryInfo = New DirectoryInfo(entry)    ' 디렉토리 지정
            strPathName = entry

            For Each dra In dirA.GetFiles()      ' For each를 통해 폴더 내의 파일을 찾음
                If InStr(dra.Name, szFile) Then  ' InStr <-- 유사한 단어를 포함하는 문자열 찾기
                    szPath_Temp = entry
                    szFile = dra.Name
                    Exit For
                End If
            Next
        Next

        Dim szFullPath As String = szPath_Temp & "\" & szFile       ' 경로 합쳐주기 ex [C:\Program Files & \ & abcdef.xlsx]
        Try
            Diagnostics.Process.Start(szFullPath)
        Catch ex As Exception
            MsgBox(ex.Message & vbCrLf & "파일이름이 일치하는게 없습니다." & strFilePath & " <- 경로에 실제로 파일이 있는지 봐주세요.", , "lee.sunbae@lgepartner.com")
        End Try

        'Call OpenExcelFile(szFile, strFilePath)

    End Sub
    '★ Excel File Open하는 함수 
    Sub OpenExcelFile(ByVal szFile As String, ByVal szPath As String)
        Dim strFileName As String = Nothing
        Dim szPath_Temp As String = Nothing
        Dim blChk As Boolean = False
        Dim strPathName As String = Nothing

        Try
            For Each entry As String In Directory.GetDirectories(szPath)        ' GetDirectories(Path) <- 해당 Path에 있는 Folder 및 Files 찾음
                ' 지정 한 경로를 반복 하면서 경로와 '구분'명과 일치하는 폴더를 찾음.
                ' 찾은 경로로 진입 하여 그 안의 파일명을 찾는다.
                Dim dirA As DirectoryInfo = New DirectoryInfo(entry)    ' 디렉토리 지정
                strPathName = entry

                For Each dra In dirA.GetFiles()     ' For each를 통해 폴더 내의 파일을 찾음

                    If InStr(dra.Name, szFile) Then ' Consumer TC와 Kernel TC / Framework TC의 파일 Naming이 다름
                        szPath_Temp = entry
                        szFile = dra.Name
                        Exit For
                    End If
                Next
            Next

            strFileName = szPath_Temp & "\" & szFile

            If IO.File.Exists(strFileName) Then
                blChk = True
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
                xlWorkBook = xlWorkBooks.Open(strFileName,, True)   ' True = Read Only Open
                xlApp.Visible = True
                xlWorkSheets = xlWorkBook.Sheets

                xlWorkBook = Nothing
                xlApp = Nothing

            Else
                MsgBox("파일을 열지 못했습니다.." & vbCrLf & szPath & "에서 " & szFile & "(이)가 있는지 확인 해보세요.")
                Exit Sub
            End If

            If blChk = False Then
                MsgBox("파일을 열지 못했습니다." & vbCrLf & szPath & "에서 " & szFile & "이 없거나, 권한이 없을 수 있습니다." _
                       & "권한을 요청 해주세요.")
                Exit Sub
            End If

        Catch ex As Exception
            MsgBox(ex.Message, "열려는 파일이 없습니다." & vbCrLf & strFileName & "에서 확인 해보세요.")
        End Try
    End Sub

    Private Sub requestBtn_Click(sender As Object, e As EventArgs) Handles requestBtn.Click

    End Sub
End Class