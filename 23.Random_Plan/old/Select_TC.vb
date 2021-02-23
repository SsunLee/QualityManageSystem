Imports System.Data
Imports System.Data.OleDb
Imports System.IO
Imports System.Windows.Forms
Imports Microsoft.Office.Interop

Public Class Select_TC
    Private DS As DataSet = New DataSet
    Private DA As OleDbDataAdapter = New OleDbDataAdapter()
    Private DAUP As OleDbDataAdapter = New OleDbDataAdapter()
    Public ordAdapter As OleDbDataAdapter = New OleDbDataAdapter()
    Private strSQL As String
    Private vConn As OleDbConnection
    Public strFile As String = Nothing
    Public strFileName As String = Nothing '
    Public strFilePath As String = Nothing '"\\10.174.51.33\Q-Portal\별도TC,자체TC_통합"
    Public szFilePath_framework As String = Nothing '"\\10.174.51.33\Q-Portal\별도TC,자체TC_통합"
    Public strSht As String = "Other_TC"

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

            Dim DS As New DataSet
            DA.Fill(DS, strSht)

            Dim Table_Word As DataTable = DS.Tables(0)

            If Table_Word.Rows.Count = 0 Then
                MsgBox("검색결과가 없습니다.")
            End If

            For i As Integer = 0 To Table_Word.Rows.Count - 1            ' Data table Row 만큼 반복 -1은 마지막행은 Null
                If Not DaeCB.Items.Contains(Table_Word.Rows(i)(1).ToString()) Then  ' 중복 없이 Item 추가
                    DaeCB.Items.Add(Table_Word.Rows(i)(1).ToString())
                End If
            Next

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        szPath_CNS = strFilePath + "\목적 TC\CNS"
        szPath_INFINIQ = strFilePath + "\목적 TC\인피닉"
        szPath_MSTech = strFilePath + "\목적 TC\엠스텍"

    End Sub

    Private Sub TCName_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Mid_CB.SelectedIndexChanged

        Dim DS As New DataSet
        DA.Fill(DS, strSht)
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

        Dim DS As New DataSet
        DA.Fill(DS, strSht)
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
            MessageBox.Show(ex.Message, "Test Case에 History 시트가 없습니다. 추가해주세요 ")
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

        Mid_CB.Text = ""
        Min_CB.Text = ""

        ' Combobox Clear
        Min_CB.Items.Clear()
        Try
            Dim DS As New DataSet
            DA.Fill(DS, strSht)
            Dim Table As DataTable = DS.Tables(0)

            'DaeCB
            Mid_CB.Items.Clear()     ' 중분류
            Min_CB.Items.Clear()     ' 소분류

            TCnameTxt.Text = ""      ' TC명 
            TCPurposeTxt.Text = ""   ' 목적
            DetectedTxt_.Text = ""    ' 검증 항목
            PriTxt.Text = ""         ' 등급 별 진행 기준
            MDTxt.Text = ""          ' 투입 MD

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
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim strPath_Open As String = Nothing

        Try
            ' 파일의 경로 지정
            ' strSht = "Work_Noti"
            szFilePath = ""
            If Mid_CB.Text = "CNS" Or Mid_CB.Text = "엠스텍" Or Mid_CB.Text = "인피닉" Then
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

                'ElseIf InStr(FileName.Text, ".pptx") Then   ' 만약 PPT 파일 이라면!

                '    Dim oApp As PowerPoint.Application      ' Set Object for using PowerPoint
                '    Dim oPres As PowerPoint.Presentation    ' Set object for using Presentation Slide of PowerPoint
                '    Dim file As String = strFileName        ' get the File Name and Filepath

                '    oApp = CreateObject("PowerPoint.Application")   ' Create Object for PowerPoint
                '    oApp.Visible = True                             ' Visible Settting did create
                '    oPres = oApp.Presentations.Open(file,, True)
                'End If

            Else
                MsgBox("열려는 파일이 없습니다." & vbCrLf & szFilePath & "에서 " & strFile & "(이)가 있는지 확인 해보세요.")
                Exit Sub
            End If

        Catch ex As Exception
            MsgBox(ex.Message, "열려는 파일이 없습니다." & vbCrLf & szFilePath & "에서 확인 해보세요.")
        End Try
    End Sub

    Private Sub requestBtn_Click(sender As Object, e As EventArgs) Handles requestBtn.Click
        '제안하기 폼

    End Sub


    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        ' 선택한 TC로 보여지도록 
        'Dim sw_vali As New SW_Validation_Master_Plan
        ' Dim strValue As String = sw_vali.ShowDialog
        Button3.DialogResult() = DialogResult.OK


    End Sub
End Class