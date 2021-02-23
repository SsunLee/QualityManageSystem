Imports System.Data
Imports System.Data.OleDb
Imports System.IO
Imports System.Windows.Forms
Imports Microsoft.Office.Interop

Public Class Other_TC
    Public DA_m As OleDbDataAdapter = New OleDbDataAdapter()
    Public DS_m As DataSet = New DataSet


    Public DS As DataSet = New DataSet
    Private DA As OleDbDataAdapter = New OleDbDataAdapter()
    Private DAUP As OleDbDataAdapter = New OleDbDataAdapter()
    Public ordAdapter As OleDbDataAdapter = New OleDbDataAdapter()
    Private strSQL As String
    Private vConn As OleDbConnection
    Public strFile As String = Nothing
    Public strFileName As String = Nothing '
    Public strFilePath As String = Nothing '"\\10.174.51.33\Q-Portal\별도TC,자체TC_통합"
    Public szFilePath_framework As String = Nothing '"\\10.174.51.33\Q-Portal\별도TC,자체TC_통합"
    Public strSht As String

    ' 목적T/C (자체 T/C)
    Public szFilePath As String = Nothing
    Public szPath_CNS As String = Nothing '"\\10.174.51.33\Q-Portal\자산_Device_수평전개_Guide\자체관리 TC\CNS"
    Public szPath_INFINIQ As String = Nothing '"\\10.174.51.33\Q-Portal\자산_Device_수평전개_Guide\자체관리 TC\인피닉"
    Public szPath_MSTech As String = Nothing '"\\10.174.51.33\Q-Portal\자산_Device_수평전개_Guide\자체관리 TC\엠스텍"

    'Public Main_Form As New Main_Form
    Public strOpenPath As String = Nothing
    Private strPathName As String = Nothing
    ' Public strFile As String = Nothing

    Private Sub Other_TC_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Icon = My.Resources.Qportal_Icon
        DaeCB.Text = "여기를 선택 해주세요"

        strSht = "Other_TC"

        '#### 쿼리 작성 #########################################################
        Dim vSQL As String = "SELECT * " & " "
        vSQL = vSQL + "FROM [" & strSht & "]" & " "
        '#######################################################################

        Try
            ' XML에서 Admin vCon 가져옴
            Dim xml As New XML
            Dim vCon As String = Nothing
            xml.vCon_Call(vCon)
            xml.Folder_Path("TC", strFilePath)
            xml = Nothing

            vConn = New OleDbConnection(vCon)
            DA = New OleDbDataAdapter(vSQL, vConn)

            'Dim DS As New DataSet
            DA.Fill(DS, strSht)

            Dim Table_Word As DataTable = DS.Tables(0)

            If Table_Word.Rows.Count = 0 Then
                MsgBox("검색결과가 없습니다.")
            End If

            For i As Integer = 0 To Table_Word.Rows.Count - 1            ' Data table Row 만큼 반복 -1은 마지막행은 Null
                If Not DaeCB.Items.Contains(Table_Word.Rows(i).Item("대분류")) Then  ' 중복 없이 Item 추가
                    DaeCB.Items.Add(Table_Word.Rows(i).Item("대분류"))
                End If
            Next




        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        szPath_CNS = strFilePath + "\목적 TC\CNS"
        szPath_INFINIQ = strFilePath + "\목적 TC\인피닉"
        szPath_MSTech = strFilePath + "\목적 TC\엠스텍"



        Dim blChk As Boolean = False
        Dim strFile_chk As String = "재발방지체크리스트"

        Try
            Dim strFilePath_check As String = Nothing
            Dim szFileName_check As String = Nothing

            Dim XML As New XML
            XML.Folder_Path("Share", strFilePath_check)
            XML = Nothing

            ' 지정 한 경로를 반복 하면서 경로와 '구분'명과 일치하는 폴더를 찾음.
            ' 찾은 경로로 진입 하여 그 안의 파일명을 찾는다.
            Dim dirA As DirectoryInfo = New DirectoryInfo(strFilePath_check)    ' 디렉토리 지정
            For Each dra In dirA.GetFiles()     ' For each를 통해 폴더 내의 파일을 찾음
                If InStr(Trim(dra.Name), RTrim(strFile_chk)) Then  ' Consumer TC와 Kernel TC / Framework TC의 파일 Naming이 다름
                    szFileName_check = dra.Name
                    blChk = True
                End If
            Next

            If blChk Then
                szMerge = strFilePath_check & "\" & szFileName_check
            Else
                MsgBox(strFile & " 파일이 없는 것 같습니다. " & strFilePath_check & " <-- 경로에 파일이 있는지, '재발방지체크리스트' 파일명도 확인해주세요 ")
            End If

            Dim strExcel As String = "Provider=Microsoft.Ace.OLEDB.12.0;Data Source=" & szMerge & ";Extended Properties=""Excel 12.0;HDR=YES;"""
            InfoConn = New OleDbConnection(strExcel)
            Dim strSht_info As String = "TC Info"

            '#### 쿼리 작성 #########################################################
            vSQL = "SELECT * " & " "
            vSQL = vSQL + "FROM [" & strSht_info & "$]" & " "
            '#######################################################################
            Diagnostics.Debug.Print(strSht_info & Environment.NewLine)
            Diagnostics.Debug.Print(szMerge)

            DA = New OleDbDataAdapter(vSQL, InfoConn)
            DA.Fill(DSS, strSht_info)

            Dim Table As DataTable = DSS.Tables(0)
            strFile = Nothing

            Dim szTCName As String = Table.Rows(0)(1).ToString()
            Dim szPur As String = Table.Rows(1)(1).ToString()
            Dim szDetect As String = Table.Rows(2)(1).ToString()
            Dim szBase As String = Table.Rows(4)(1).ToString()
            Dim szSemi As String = Table.Rows(4)(2).ToString()
            Dim szCA As String = Table.Rows(4)(3).ToString()
            Dim szMD As String = Table.Rows(5)(1).ToString()

            ' Des_Txt.Text = Replace(strTxtDef, Chr(10), Chr(13) & Chr(10))

            txt_TCName.Text = Replace(szTCName, Chr(10), Chr(13) & Chr(10))     ' # TC Name
            txt_TCPurpose.Text = Replace(szPur, Chr(10), Chr(13) & Chr(10))         ' # TC 목적
            DetectedTxt.Text = Replace(szDetect, Chr(10), Chr(13) & Chr(10))        ' # 검증항목

            txt_Base.Text = Replace(szBase, Chr(10), Chr(13) & Chr(10))
            Txt_Semi.Text = Replace(szSemi, Chr(10), Chr(13) & Chr(10))
            Txt_CA.Text = Replace(szCA, Chr(10), Chr(13) & Chr(10))

            txt_MD.Text = Replace(szMD, Chr(10), Chr(13) & Chr(10))

        Catch ex As Exception
            MessageBox.Show(ex.Message, "lee.sunbae@lgepartner.com")
        End Try










    End Sub

    Private Sub TCName_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Mid_CB.SelectedIndexChanged


        Dim Table As DataTable = DS.Tables(0)

        Min_CB.Items.Clear()
        Min_CB.Text = ""

        TCnameTxt.Text = ""      ' TC명 
        TCPurposeTxt.Text = ""   ' 목적
        DetectedTxt_.Text = ""    ' 검증 항목
        PriTxt.Text = ""         ' 등급 별 진행 기준
        MDTxt.Text = ""          ' 투입 MD


        For i As Integer = 0 To Table.Rows.Count - 1            ' Data table Row 만큼 반복 -1은 마지막행은 Null
            If DaeCB.Text = Table.Rows(i)(1).ToString() And Mid_CB.Text = Table.Rows(i)(2).ToString() Then
                If Not Min_CB.Items.Contains(Table.Rows(i)(3).ToString()) Then  ' 중복 없이 Item 추가
                    Min_CB.Items.Add(Table.Rows(i)(3).ToString())
                End If
            End If
        Next

    End Sub

    Private Sub Min_CB_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Min_CB.SelectedIndexChanged
        '마지막 선택 시  TC Info에 정보를 띄워주는 역할
        Dim blChkGubun As Boolean = False


        Dim Table As DataTable = DS.Tables(0)

        strFile = Nothing

        For i As Integer = 0 To Table.Rows.Count - 1            ' Data table Row 만큼 반복 -1은 마지막행은 Null
            If DaeCB.Text = Table.Rows(i)(1).ToString() And Mid_CB.Text = Table.Rows(i)(2).ToString() And Min_CB.Text = Table.Rows(i)(3).ToString() Then
                TCnameTxt.Text = Table.Rows(i)(4).ToString()
                TCPurposeTxt.Text = Table.Rows(i)(5).ToString()
                DetectedTxt_.Text = Table.Rows(i)(6).ToString()
                PriTxt.Text = Table.Rows(i)(7).ToString()
                MDTxt.Text = Table.Rows(i)(8).ToString()
                strFile = Table.Rows(i)(9).ToString()
                Exit For
            End If
        Next

        If Mid_CB.Text = "CNS" Or Mid_CB.Text = "엠스텍" Or Mid_CB.Text = "인피닉" Then
            szFilePath_framework = strFilePath + "\목적 TC" + "\" + Mid_CB.Text

            blChkGubun = True

            For Each entry As String In Directory.GetDirectories(szFilePath_framework)        ' GetDirectories(Path) <- 해당 Path에 있는 Folder 및 Files 찾음
                ' 지정 한 경로를 반복 하면서 경로와 '구분'명과 일치하는 폴더를 찾음.
                ' 찾은 경로로 진입 하여 그 안의 파일명을 찾는다.
                Dim dirA As DirectoryInfo = New DirectoryInfo(entry)    ' 디렉토리 지정
                strPathName = entry

                For Each dra In dirA.GetFiles()     ' For each를 통해 폴더 내의 파일을 찾음

                    If Trim(dra.Name) = RTrim(strFile) Then  ' Consumer TC와 Kernel TC / Framework TC의 파일 Naming이 다름
                        szFilePath_framework = entry

                    End If
                Next
            Next
        End If


        '★ DATA GRID VIEW 에 데이터 그려주는 부분 =============================================================
        Dim DataSet_History As New DataSet

        DataGridView1.DataSource = Nothing
        DataSet_History.Clear()

        Try
            Dim szMerge As String
            'DataSet_History = Nothing
            ' 만약 False라고 하면 목적T/C가 아닌 경우 이기 때문에 경로를 재 지정 

            If blChkGubun = False Then
                szFilePath = ""
                szFilePath = strFilePath + "\" + "별도TC,자체TC_통합"
                szMerge = szFilePath & "\" & strFile
            Else
                szMerge = szFilePath_framework & "\" & strFile
            End If


            Dim strExcel As String = "Provider=Microsoft.Ace.OLEDB.12.0;Data Source=" & szMerge & ";Extended Properties=""Excel 12.0;HDR=YES;"""
            vConn = New OleDbConnection(strExcel)

            strSht = "History"

            DAUP = New OleDbDataAdapter("Select * from [" & strSht & "$B4:G20]", vConn)
            DAUP.Fill(DataSet_History, strSht)

            Dim Table_Man As DataTable = DataSet_History.Tables(strSht)

            If Table_Man.Rows.Count = 0 Then
                MsgBox("조회할 내용이 없습니다.",, "lee.sunbae@lgepartner.com")
                Exit Sub
            End If

            DataGridView1.DataSource = DataSet_History.Tables(strSht)


        Catch ex As Exception
            'MsgBox("Test Case에 History 시트가 없습니다. 추가해주세요 ")
            MessageBox.Show("Test Case에 History 시트가 없습니다. 추가해주세요 " & Environment.NewLine & ex.Message, "lee.sunbae", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try


        ' 기본 값과 셋팅 설정
        With DataGridView1
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .MultiSelect = False
            .AutoResizeColumns()
            '.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells ' Column size Auto
            .AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells       ' Row Size Auto
            .DefaultCellStyle.WrapMode = DataGridViewTriState.True  ' Data Grid View Multi Line

            .AllowUserToResizeColumns = True
            .AllowUserToResizeRows = True
        End With

    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim TC_Path As New TC_Path

        TC_Path.Default_Path.Text = strFilePath

        TC_Path.CNS_txt.Text = szPath_CNS
        TC_Path.INFINIQ_txt.Text = szPath_INFINIQ
        TC_Path.MSTech_txt.Text = szPath_MSTech

        TC_Path.Show()

    End Sub

    Private Sub Gubun_CB_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DaeCB.SelectedIndexChanged


        'DaeCB
        Mid_CB.Items.Clear()     ' 중분류
        Min_CB.Items.Clear()     ' 소분류

        Mid_CB.Text = ""
        Min_CB.Text = ""
        TCnameTxt.Text = ""      ' TC명 
        TCPurposeTxt.Text = ""   ' 목적
        DetectedTxt_.Text = ""    ' 검증 항목
        PriTxt.Text = ""         ' 등급 별 진행 기준
        MDTxt.Text = ""          ' 투입 MD

        Dim strSelect As String = DaeCB.Text



        Try

            'Dim DS As New DataSet
            ' DA.Fill(DS, strSht)
            Dim Table As DataTable = DS.Tables(0)

            For i As Integer = 0 To Table.Rows.Count - 1            ' Data table Row 만큼 반복 -1은 마지막행은 Null
                If DaeCB.Text = Table.Rows(i)(1).ToString() Then  ' 선택 된 App과 Row, 필트(0)은 App, (1) 은 Feature
                    Try
                        If Not Mid_CB.Items.Contains(Table.Rows(i)(2).ToString()) Then  ' 중복 없이 Item 추가
                            Mid_CB.Items.Add(Table.Rows(i)(2).ToString())
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
    '파일 여는 부분

#Region "파일 열기 버튼 클릭"
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim strPath_Open As String = Nothing


        Try
            ' 파일의 경로 지정
            ' strSht = "Work_Noti"
            szFilePath = ""
            If Mid_CB.Text = "CNS" Or Mid_CB.Text = "엠스텍" Or Mid_CB.Text = "인피닉" Then
                szFilePath = strFilePath + "\목적 TC\" + Mid_CB.Text
            ElseIf Mid_CB.Text = "엠스텍_APP" Or Mid_CB.Text = "인피닉_APP" Then  ' 앱게이팅이면 181115
                szFilePath = strFilePath + "\목적 TC\" + Mid_CB.Text
            Else
                szFilePath = strFilePath + "\" + "별도TC,자체TC_통합"
            End If

            'Dim strFileName As String = strFilePath & "\" & strFile

            For Each entry As String In Directory.GetDirectories(szFilePath)        ' GetDirectories(Path) <- 해당 Path에 있는 Folder 및 Files 찾음
                ' 지정 한 경로를 반복 하면서 경로와 '구분'명과 일치하는 폴더를 찾음.
                ' 찾은 경로로 진입 하여 그 안의 파일명을 찾는다.
                Dim dirA As DirectoryInfo = New DirectoryInfo(entry)    ' 디렉토리 지정
                strPathName = entry

                For Each dra In dirA.GetFiles()     ' For each를 통해 폴더 내의 파일을 찾음

                    If Trim(dra.Name) = RTrim(strFile) Then  ' Consumer TC와 Kernel TC / Framework TC의 파일 Naming이 다름
                        szFilePath = entry
                    End If
                Next
            Next

            strFileName = szFilePath & "\" & strFile

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
                MsgBox("열려는 파일이 없습니다." & vbCrLf & szFilePath & "에서 " & strFile & "(이)가 있는지 확인 해보세요.")
                Exit Sub
            End If

        Catch ex As Exception
            MsgBox(ex.Message, "열려는 파일이 없습니다." & vbCrLf & szFilePath & "에서 확인 해보세요.")
        End Try
    End Sub
#End Region


    Private Sub requestBtn_Click(sender As Object, e As EventArgs) Handles requestBtn.Click

    End Sub


    Public DSS As DataSet = New DataSet
    Public DAA As OleDbDataAdapter = New OleDbDataAdapter()
    Private InfoConn As OleDbConnection
    Private szMerge As String = Nothing

    Private Sub TabPage2_Click(sender As Object, e As EventArgs) Handles TabPage2.Enter
        '## 처음 load 했을 때
        Size = New Drawing.Size(731, 606)


    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        ' 재발방지체크리스트 열기
        Dim strFileName As String = Nothing
        Try
            ' szFile = "재발방지체크리스트"
            'strFileName = strFilePath & "\" & szFile

            If File.Exists(szMerge) Then
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
                xlWorkBook = xlWorkBooks.Open(szMerge,, True)   ' Read Only Open
                xlApp.Visible = True
                xlWorkSheets = xlWorkBook.Sheets

            Else
                MsgBox("열려는 파일이 없습니다." & vbCrLf & strFilePath & "에서 " & szMerge & "(이)가 있는지 확인 해보세요.")
                Exit Sub
            End If

        Catch ex As Exception
            MsgBox(ex.Message, "열려는 파일이 없습니다." & vbCrLf & szMerge & "에서 확인 해보세요.")
        End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

    End Sub

    Private Sub TabPage1_Click(sender As Object, e As EventArgs) Handles TabPage1.Enter

        Size = New Drawing.Size(1246, 606)

    End Sub

#Region "마스터 티씨 부분"
    Public strCon_m As String = Nothing
    Public strFilePath_m As String = Nothing
    Public strFileName_m As String = Nothing
    Public vConn_m As OleDbConnection

    Private Sub TabPage3_Click(sender As Object, e As EventArgs) Handles TabPage3.Enter
        Dim strSht_m As String = "Summary"
        '#### 쿼리 작성 ###################################################
        Dim vSQL_m As String = "SELECT * " & " "
        vSQL_m = vSQL_m + "FROM [" & strSht_m & "$]" & " "
        vSQL_m = vSQL_m + "Where [구분] > '' "
        '###############################################################
        Size = New Drawing.Size(903, 606)

        Dim xml As New XML
        xml.Folder_Path("MasterNonTC", strFilePath_m)
        xml = Nothing

        Dim szFilePath_m As String = strFilePath_m + "\DB"
        strFileName_m = "NonFunction 가이드.xlsx"

        Dim strOpenPath_m As String = Nothing

        strOpenPath_m = szFilePath_m + "\" + strFileName_m
        strCon_m = "Provider=Microsoft.Ace.OLEDB.12.0;Data Source=" & strOpenPath_m & ";Extended Properties=""Excel 12.0;HDR=YES;"""


        vConn_m = New OleDbConnection(strCon_m)

        Dim DA_m As OleDbDataAdapter
        DA_m = New OleDbDataAdapter(vSQL_m, vConn_m)


        DA_m.Fill(DS_m, strSht_m)

        Dim Table_Word_m As DataTable = DS_m.Tables(0)

        If Table_Word_m.Rows.Count = 0 Then
            MsgBox("검색결과가 없습니다.")
        End If

        Table_Word_m = Table_Word_m.DefaultView.ToTable(True, "구분")
        GubunCB.DataSource = Table_Word_m
        With GubunCB
            .DisplayMember = "구분"
            .ValueMember = "구분"
        End With


    End Sub

    Private Sub GubunCB_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GubunCB.SelectedIndexChanged
        Try
            '## 구분 선택 - ex Non-Function
            Dim Table_m As DataTable = DS_m.Tables(0)

            TestGubunCB.Text = ""
            TestGubunCB.Items.Clear()      ' Data Clear
            lstDep.Items.Clear()           ' Data Clear 

            DetectedTxt_m.Text = ""               ' 설명 초기화 
            TCPurposeTxt_m.Text = ""
            PriTxt_m.Text = ""
            MDTxt_m.Text = ""

            For i As Integer = 0 To Table_m.Rows.Count - 1            ' Data table Row 만큼 반복 -1은 마지막행은 Null
                If GubunCB.Text = Table_m.Rows(i)(0).ToString() Then  ' 선택 된 App과 Row, 필트(0)은 App, (1) 은 Feature
                    Try
                        If Not TestGubunCB.Items.Contains(Table_m.Rows(i)(1).ToString()) Then  ' 중복 없이 Item 추가
                            TestGubunCB.Items.Add(Table_m.Rows(i)(1).ToString())
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

    Private Sub TestGubunCB_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TestGubunCB.SelectedIndexChanged
        Try
            'DA = New OleDbDataAdapter("SELECT REPLACE(Description, Chr(10), Chr(13) & Chr(10)) FROM Sheet1", vConn)
            'SELECT  REPLACE(Description, Chr(10), Chr(13) & Chr(10)) AS Description From Sheet1

            Dim Table_m As DataTable = DS_m.Tables(0)

            lstDep.Items.Clear()      ' Data Clear 
            FileName.Text = ""
            DetectedTxt_m.Text = ""            ' 설명 초기화 
            TCPurposeTxt_m.Text = ""
            PriTxt_m.Text = ""
            MDTxt_m.Text = ""

            For i As Integer = 0 To Table_m.Rows.Count - 1    ' Data table Row 만큼 반복 -1은 마지막행은 Null

                If GubunCB.Text = Table_m.Rows(i)(0).ToString() And TestGubunCB.Text = Table_m.Rows(i)(1).ToString() Then ' 선택 된 App과 Row, 필트(0)은 App, (1) 은 Feature
                    Try
                        If Not lstDep.Items.Contains(Table_m.Rows(i)(2).ToString()) Then  ' 중복 없이 Item 추가
                            lstDep.Items.Add(Table_m.Rows(i)(2).ToString())


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

    Private Sub lstDep_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstDep.SelectedIndexChanged
        Try
            Dim strSht_m As String = Nothing
            strSht_m = lstDep.Text    ' 조회 할 Table 명을 담음
            ' Query 작성 #############################################
            Dim vSQL_m As String = "Select * FROM [" & strSht_m & "$]"
            ' ########################################################

            vConn_m = New OleDbConnection(strCon_m)

            Dim DA_m As OleDbDataAdapter = New OleDbDataAdapter

            DA_m = New OleDbDataAdapter(vSQL_m, vConn_m)            ' Data Adapter 를 통해 DB 연결 


            Dim DS2 As New DataSet
            DS2 = New DataSet        ' Data를 담을 DataSet 생성
            DA_m.Fill(DS2, strSht_m)
            Dim Table_m As DataTable = DS2.Tables(0)


            For i As Integer = 3 To Table_m.Rows.Count - 1

                Dim strTextCom = Table_m.Rows(i)(2).ToString()
                strTextCom = Replace(strTextCom, Chr(10), Chr(13) & Chr(10))

                If i = 3 Then
                    'TCnameTxt.Text = strTextCom
                ElseIf i = 4 Then
                    TCPurposeTxt_m.Text = strTextCom
                ElseIf i = 5 Then
                    DetectedTxt_m.Text = strTextCom
                ElseIf i = 6 Then
                    MDTxt_m.Text = strTextCom
                ElseIf i = 7 Then
                    PriTxt_m.Text = strTextCom
                End If
            Next i

            '파일 이름 보여주기
            strSht_m = "Summary"

            ' Query 작성 #############################################
            vSQL_m = "Select * FROM [" & strSht_m & "$]"
            'Dim infoSQL As String = "Select * FROM [" & strInfo & "$]"
            ' ########################################################

            DA = New OleDbDataAdapter(vSQL_m, vConn_m)            ' Data Adapter 를 통해 DB 연결 

            DA.Fill(DS_m, strSht)
            Dim Table As DataTable = DS_m.Tables(0)

            FileName.Text = ""

            Dim strMasterTC As String

            For i As Integer = 0 To Table.Rows.Count - 1    ' Data table Row 만큼 반복 -1은 마지막행은 Null

                If GubunCB.Text = Table.Rows(i)(0).ToString() And TestGubunCB.Text = Table.Rows(i)(1).ToString() _
                    And lstDep.Text = Table.Rows(i)(2).ToString() Then ' 선택 된 App과 Row, 필트(0)은 App, (1) 은 Feature

                    Try 'Chr(10), Chr(13) & Chr(10)

                        strMasterTC = Table.Rows(i)(3).ToString()
                        If strMasterTC = "-" Or strMasterTC = "" Then
                            FileName.Text = "파일이 없습니다." ' 파일 없을 때
                        Else
                            FileName.Text = Table.Rows(i)(2).ToString() ' 파일 이름 보여줌
                        End If

                    Catch ex As Exception
                        MsgBox(ex.Message)
                    End Try
                End If
            Next

        Catch ex As Exception
            MsgBox("해당 TC는 준비 중 입니다.")
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btn_file_m_Click(sender As Object, e As EventArgs) Handles btn_file_m.Click
        '## 파일 열기 #### Summary 시트 에서 열어야 함 
        Dim dirA As DirectoryInfo = New DirectoryInfo(strFilePath_m)    ' 디렉토리 지정
        Dim szFile As String = Nothing

        'strPathName = entry
        If InStr(FileName.Text, "없습니다") Then
            Exit Sub
        End If
        For Each dra In dirA.GetFiles()     ' For each를 통해 폴더 내의 파일을 찾음

            If InStr(dra.Name, lstDep.Text) Then
                'szPath_Temp = entry
                szFile = dra.Name
                Exit For
            End If
        Next
        'Next

        Dim szFullPath As String = strFilePath_m & "\" & szFile
        Try
            Diagnostics.Process.Start(szFullPath)
        Catch ex As Exception
            MsgBox(ex.Message & vbCrLf & "파일이름이 일치하는게 없습니다." & strFilePath_m & " <- 경로에 실제로 파일이 있는지 봐주세요.", , "lee.sunbae@lgepartner.com")
        End Try


    End Sub

    Private Sub TabPage1_Click_1(sender As Object, e As EventArgs) Handles TabPage1.Click

    End Sub

    Private Sub TabPage3_Click_1(sender As Object, e As EventArgs) Handles TabPage3.Click

    End Sub



#End Region




End Class