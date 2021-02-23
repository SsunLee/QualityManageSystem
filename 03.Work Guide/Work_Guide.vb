Imports System.Data
Imports System.Data.OleDb
Imports System.IO
Imports Microsoft.Office.Interop

Public Class Work_Guide
    Public DS As DataSet = New DataSet
    Public DA As OleDbDataAdapter = New OleDbDataAdapter()
    Public strSQL As String
    Public vConn As OleDbConnection
    'Public Main_Form As New Main_Form
    Public Property strPath As String
    Private InfoConn As OleDbConnection
    Public strFilePath As String = Nothing '"\\10.174.51.33\Q-Portal\업무관련Guide"
    ' Public strPath_Open As String = Nothing '"\\10.174.51.33\Q-Portal\업무관련Guide"
    Private strSht As String = "Sheet1"

    Private Sub Work_Guide_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Icon = My.Resources.Qportal_Icon






    End Sub
    ' #### [ 구분 선택 했을 때 다음 [검증 구분]이 나오기 위함.
    Private Sub GubunCB_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GubunCB.SelectedIndexChanged
        Try
            Dim DS As New DataSet
            DA.Fill(DS, strSht)
            Dim Table As DataTable = DS.Tables(0)

            TestGubunCB.Text = ""
            TestGubunCB.Items.Clear()      ' Data Clear
            lstDep.Items.Clear()           ' Data Clear 
            txtDes.Text = ""               ' 설명 초기화 
            txtDepth2.Text = ""

            For i As Integer = 0 To Table.Rows.Count - 1            ' Data table Row 만큼 반복 -1은 마지막행은 Null
                If GubunCB.Text = Table.Rows(i)(3).ToString() Then  ' 선택 된 App과 Row, 필트(0)은 App, (1) 은 Feature
                    Try
                        If Not TestGubunCB.Items.Contains(Table.Rows(i)(1).ToString()) Then  ' 중복 없이 Item 추가
                            TestGubunCB.Items.Add(Table.Rows(i)(1).ToString())
                        End If

                    Catch ex As Exception
                        MsgBox(ex.Message)
                    End Try
                End If
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    ' #### [ 검증 구분 선택 시 상세 분류 나오는 Code ] #####
    Private Sub TestGubunCB_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TestGubunCB.SelectedIndexChanged
        Try
            'DA = New OleDbDataAdapter("SELECT REPLACE(Description, Chr(10), Chr(13) & Chr(10)) FROM Sheet1_GM", vConn)
            'SELECT  REPLACE(Description, Chr(10), Chr(13) & Chr(10)) AS Description From Sheet1_GM
            Dim DS As New DataSet
            DA.Fill(DS, strSht)
            Dim Table As DataTable = DS.Tables(0)

            lstDep.Items.Clear()      ' Data Clear 
            FileName.Text = ""
            txtDes.Text = ""            ' 설명 초기화 
            txtDepth2.Text = ""

            For i As Integer = 0 To Table.Rows.Count - 1    ' Data table Row 만큼 반복 -1은 마지막행은 Null

                If GubunCB.Text = Table.Rows(i)(3).ToString() And TestGubunCB.Text = Table.Rows(i)(1).ToString() Then ' 선택 된 App과 Row, 필트(0)은 App, (1) 은 Feature
                    Try
                        If Not lstDep.Items.Contains(Table.Rows(i)(4).ToString()) Then  ' 중복 없이 Item 추가
                            lstDep.Items.Add(Table.Rows(i)(4).ToString())

                        End If
                    Catch ex As Exception
                        MsgBox(ex.Message)
                    End Try
                End If
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    '#### [ 상세 분류에서 원하는 항목 선택 시 설명과 파일이름 보여지는 부분 ] ######
    Private Sub lstDep_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstDep.SelectedIndexChanged
        Try
            'SELECT  REPLACE(Description, Chr(10), Chr(13) & Chr(10)) From Sheet1_GM

            Dim DS As New DataSet
            DA.Fill(DS, strSht)
            Dim Table As DataTable = DS.Tables(0)

            'lstDep.Items.Clear()      ' Data Clear 
            FileName.Text = ""
            txtDes.Text = ""            ' 설명 초기화 

            For i As Integer = 0 To Table.Rows.Count - 1    ' Data table Row 만큼 반복 -1은 마지막행은 Null

                If GubunCB.Text = Table.Rows(i)(3).ToString() And TestGubunCB.Text = Table.Rows(i)(1).ToString() _
                    And lstDep.Text = Table.Rows(i)(4).ToString() Then ' 선택 된 App과 Row, 필트(0)은 App, (1) 은 Feature
                    'SELECT  REPLACE(Description, Chr(10), Chr(13) & Chr(10)) AS Description From Sheet1_GM
                    Try 'Chr(10), Chr(13) & Chr(10)
                        Dim strTextCom = Table.Rows(i)(5).ToString()
                        strTextCom = Replace(strTextCom, Chr(10), Chr(13) & Chr(10))

                        txtDes.Text = strTextCom   ' 설명 보여줌

                        txtDepth2.Text = Table.Rows(i)(2).ToString()
                        FileName.Text = Table.Rows(i)(6).ToString() ' 파일 이름 보여줌
                    Catch ex As Exception
                        MsgBox(ex.Message)
                    End Try
                End If
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    '★ 업무가이드 TC 파일 열기
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button2.Click

        '  Dim strPath_Open As String = "\\10.174.51.33\Q-Portal\업무관련Guide"
        strSht = "Work_Noti"

        'Dim Table As DataTable = DS.Tables(0)
        Dim szFile As String = FileName.Text
        Dim szPath_Temp As String = Nothing

        '★ 파일 열 때 예외처리
        If GubunCB.Text = "" Or TestGubunCB.Text = "" Or lstDep.Text = "" Then
            MsgBox("열고 싶은 파일을 선택 후 버튼을 눌러 주세요.")
            Exit Sub
        End If

        '★ 파일명이 없는 경우는 예외처리, "-", "_"
        If Strings.Left(FileName.Text, 1) = "-" Then
            MsgBox("가이드 파일이 없는 항목입니다.")
            Exit Sub
        End If


        ' 해당 파일 열기
        ' For Each entry As String In Directory.GetDirectories(strFilePath)        ' GetDirectories(Path) <- 해당 Path에 있는 Folder 및 Files 찾음
        ' 지정 한 경로를 반복 하면서 경로와 '구분'명과 일치하는 폴더를 찾음.
        ' 찾은 경로로 진입 하여 그 안의 파일명을 찾는다.
        Dim dirA As DirectoryInfo = New DirectoryInfo(strFilePath)    ' 디렉토리 지정


        For Each dra In dirA.GetFiles()     ' For each를 통해 폴더 내의 파일을 찾음
            If InStr(dra.Name, szFile) Then
                szFile = dra.FullName
                Exit For
            End If
        Next
        'Next

        'Dim szFullPath As String = szPath_Temp & "\" & szFile
        Try
            Diagnostics.Process.Start(szFile)
        Catch ex As Exception
            MsgBox(ex.Message & vbCrLf & "파일이름이 일치하는게 없습니다." & strFilePath & " <- 경로에 실제로 파일이 있는지 봐주세요.", , "lee.sunbae@lgepartner.com")
        End Try



    End Sub
    Public Sub ReleaseComObject(ByVal obj As Object)
        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
            obj = Nothing
        Catch ex As Exception
            obj = Nothing
        End Try

    End Sub

    ' 현재 이건 안씀
    Private Sub Button1_Click_1(sender As Object, e As EventArgs)

        Dim Work_Guide_Sub As New Work_Guide_Sub    ' 자식 폼으로 값을 넘겨주기 위해 선언
        Work_Guide_Sub.PathTxt.Text = strFilePath  ' 자식 폼의 TextBox에 변수 내용을 담아 보냄

        Work_Guide_Sub.Show()   ' 자식 폼 띄우기


    End Sub

    Private Sub btn_Request_Tab2_clicked(sender As Object, e As EventArgs) Handles btn_Request_Tab2.Click
        '제안하기 폼

    End Sub

    Private Sub TabPage1_Click(sender As Object, e As EventArgs) Handles TabPage1.Enter
        '## 탭 load 시 검증 가이드 불러오도록 
        '★ 업무 가이드가 처음 Load 될 때
        Dim szMerge As String = Nothing
        Dim szFileName As String = Nothing
        Dim blChk As Boolean = False
        Dim strFile As String = "업무관련 Guide 문서 List"        ' 파일이름으로 쓸 변수 생성 
        Dim szTemp As String = Nothing
        Try

            Dim XML As New XML
            XML.Folder_Path("Guide", strFilePath)   ' Xml에 Guide로 등록되어 있는 Node 찾기.
            XML = Nothing

            ' 지정 한 경로를 반복 하면서 경로와 '구분'명과 일치하는 폴더를 찾음.
            ' 찾은 경로로 진입 하여 그 안의 파일명을 찾는다.
            Dim dirA As DirectoryInfo = New DirectoryInfo(strFilePath)    ' 디렉토리 지정
            For Each dra In dirA.GetFiles()     ' For each를 통해 폴더 내의 파일을 찾음
                szTemp = dra.Name
                If InStr(Trim(dra.Name), RTrim(strFile)) And Strings.Left(szTemp, 2) <> "~$" Then  '  Directory안에서 File 찾기(업무관련 Guide문서 List.xlsx) // "~$" 이미 열려있는 Temp파일은 제외.
                    szFileName = dra.Name
                    blChk = True
                End If
            Next

            If blChk Then
                szMerge = strFilePath & "\" & szFileName
            Else
                MsgBox(strFile & " 파일이 없는 것 같습니다. " & strFilePath & " <-- 경로에 파일이 있는지, '업무관련 Guide 문서 List' 파일명도 확인해주세요 ")
            End If

            GubunCB.Items.Clear()   ' Combobox Clear

            DS = Nothing
            DS = New DataSet

            ' 교육 자료 공유 가 처음 Load 될 때 
            Dim strExcel As String = "Provider=Microsoft.Ace.OLEDB.12.0;Data Source=" & szMerge & ";Extended Properties=""Excel 12.0;HDR=YES;"""
            InfoConn = New OleDbConnection(strExcel)


            '#### 쿼리 작성 #########################################################
            Dim vSQL As String = "SELECT * " & " "
            vSQL = vSQL + "FROM [" & strSht & "$B3:H1000]" & " "
            '#######################################################################

            DA = New OleDbDataAdapter(vSQL, InfoConn)
            'Dim DS As New DataSet
            DA.Fill(DS, strSht)

            Dim Table As DataTable = DS.Tables(0)
            strFile = Nothing

            '★ 대상 
            For i As Integer = 0 To Table.Rows.Count - 1            ' Data table Row 만큼 반복 -1은 마지막행은 Null
                If Not GubunCB.Items.Contains(Table.Rows(i)(3).ToString()) And Not IsDBNull(Table.Rows(i)(3).ToString()) Then  ' 중복 없이 Item 추가
                    GubunCB.Items.Add(Table.Rows(i)(3).ToString())
                End If
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub TabPage2_Click(sender As Object, e As EventArgs) Handles TabPage2.Enter
        '## 교육자료 
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

            DS = Nothing
            DS = New DataSet

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

            cb_Target.Items.Clear()


            '★ [대상] 콤보박스에 값 넣는 부분
            For i As Integer = 0 To Table.Rows.Count - 1                            ' Data table Row 만큼 반복 -1은 마지막행은 Null
                If Not cb_Target.Items.Contains(Table.Rows(i)(1).ToString()) Then   ' 중복 없이 Item 추가  "Contains" <-- 중복이 아닌 경우만 
                    cb_Target.Items.Add(Table.Rows(i)(1).ToString())                ' 콤보박스에 아이템 Add 
                End If
            Next

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
        '제안하기 폼

    End Sub

    Private Sub TabPage2_Click_1(sender As Object, e As EventArgs) Handles TabPage2.Click

    End Sub

    'open file
    ' Private Sub Button2_Click(sender As Object, e As EventArgs) Handles

    ' End Sub
End Class