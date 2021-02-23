Imports System.Data
Imports System.Data.OleDb
Imports System.Windows.Forms
Imports Microsoft.Office.Interop

Public Class OtherTC_Edit
    Private DS As DataSet = New DataSet
    Private DA As OleDbDataAdapter = New OleDbDataAdapter()
    Public ordAdapter As OleDbDataAdapter = New OleDbDataAdapter()
    Private strSQL As String
    Private vConn As OleDbConnection
    Public strSht As String = "Other_TC"
    Public strFile As String = Nothing
    Public strFileName As String = Nothing
    Public strFilePath As String = Nothing '"\\10.174.51.33\Q-Portal\별도TC,자체TC_통합"

    ' 목적T/C (자체 T/C)
    Public szPath_CNS As String = Nothing '"\\10.174.51.33\Q-Portal\자산_Device_수평전개_Guide\자체관리 TC\CNS"
    Public szPath_INFINIQ As String = Nothing '"\\10.174.51.33\Q-Portal\자산_Device_수평전개_Guide\자체관리 TC\인피닉"
    Public szPath_MSTech As String = Nothing '"\\10.174.51.33\Q-Portal\자산_Device_수평전개_Guide\자체관리 TC\엠스텍"

    ' Public Main_Form As New Main_Form
    Public strOpenPath As String = Nothing
    ' Public strFile As String = Nothing

    Private Sub Other_TC_Load(sender As Object, e As EventArgs) Handles MyBase.Load, btnRe.Click


        'DaeCB.Text = "여기를 선택 해주세요"

        '#### 쿼리 작성 #########################################################
        Dim vSQL As String = "SELECT * " & " "
        vSQL = vSQL + "FROM [" & strSht & "]" & " order by [ID] asc"
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

            '★ DATA GRID VIEW 에 데이터 그려주는 부분 =============================================================
            DataGridView1.DataSource = Nothing


            ' Dim Table As DataTable = DS.Tables(0)

            If Table_Word.Rows.Count = 0 Then
                MsgBox("조회할 내용이 없습니다.",, "lee.sunbae@lgepartner.com")
                Exit Sub
            End If

            DataGridView1.DataSource = DS.Tables(0)


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


        ' 기본 값과 셋팅 설정
        With DataGridView1
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .MultiSelect = False
            ' .AutoResizeColumns()
            '.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells ' Column size Auto
            '.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells       ' Row Size Auto
            .DefaultCellStyle.WrapMode = DataGridViewTriState.True  ' Data Grid View Multi Line

            .AllowUserToResizeColumns = True
            .AllowUserToResizeRows = True
        End With

        szPath_CNS = strFilePath + "\목적 TC\CNS"
        szPath_INFINIQ = strFilePath + "\목적 TC\인피닉"
        szPath_MSTech = strFilePath + "\목적 TC\엠스텍"

    End Sub

    Private Sub TCName_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Mid_CB.SelectedIndexChanged
        DataGridView1.ClearSelection()
        Dim DS As New DataSet
        DA.Fill(DS, strSht)
        Dim Table As DataTable = DS.Tables(0)

        Min_CB.Items.Clear()
        Min_CB.Text = ""

        'TCnameTxt.Text = ""      ' TC명 
        'TCPurposeTxt.Text = ""   ' 목적
        'DetectedTxt.Text = ""    ' 검증 항목
        'PriTxt.Text = ""         ' 등급 별 진행 기준
        'MDTxt.Text = ""          ' 투입 MD


        For i As Integer = 0 To Table.Rows.Count - 1            ' Data table Row 만큼 반복 -1은 마지막행은 Null
            If DaeCB.Text = Table.Rows(i)(1).ToString() And Mid_CB.Text = Table.Rows(i)(2).ToString() Then
                If Not Min_CB.Items.Contains(Table.Rows(i)(3).ToString()) Then  ' 중복 없이 Item 추가
                    Min_CB.Items.Add(Table.Rows(i)(3).ToString())
                End If
            End If
        Next

    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim TC_Path As New TC_Path

        TC_Path.Default_Path.Text = strFilePath

        TC_Path.CNS_txt.Text = szPath_CNS
        TC_Path.INFINIQ_txt.Text = szPath_INFINIQ
        TC_Path.MSTech_txt.Text = szPath_MSTech

        TC_Path.Show()

    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click, btnRe.Click

        Dim a As Control
        For Each a In Me.Controls
            If TypeOf a Is TextBox Then
                a.Text = ""
            ElseIf TypeOf a Is ComboBox Then
                a.Text = ""
            End If
        Next

        'DaeCB.Text = ""
        'Mid_CB.Text = ""
        'Min_CB.Text = ""
        'TCnameTxt.Text = ""
        'TCPurposeTxt.Text = ""
        'DetectedTxt.Text = ""
        'PriTxt.Text = ""
        'MDTxt.Text = ""
        'txtFileName.Text = ""

    End Sub

    Private Sub Gubun_CB_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DaeCB.SelectedIndexChanged
        DataGridView1.ClearSelection()
        Mid_CB.Text = ""
        Min_CB.Text = ""

        'ComboBox Clear
        Min_CB.Items.Clear()
        Try
            Dim DS As New DataSet
            DA.Fill(DS, strSht)
            Dim Table As DataTable = DS.Tables(0)

            'DaeCB
            Mid_CB.Items.Clear()     ' 중분류
            Min_CB.Items.Clear()     ' 소분류

            'TCnameTxt.Text = ""      ' TC명 
            'TCPurposeTxt.Text = ""   ' 목적
            'DetectedTxt.Text = ""    ' 검증 항목
            'PriTxt.Text = ""         ' 등급 별 진행 기준
            'MDTxt.Text = ""          ' 투입 MD

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
    Private Sub Button2_Click(sender As Object, e As EventArgs)
        Dim strPath_Open As String = Nothing
        Try
            ' 파일의 경로 지정
            strSht = "Work_Noti"

            If Mid_CB.Text = "CNS" Then
                strFilePath = szPath_CNS
            ElseIf Mid_CB.Text = "엠스텍" Then
                strFilePath = szPath_INFINIQ
            ElseIf Mid_CB.Text = "인피닉" Then
                strFilePath = szPath_MSTech
            End If


            Dim strFileName As String = strFilePath & "\" & strFile

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
                MsgBox("열려는 파일이 없습니다." & vbCrLf & strFilePath & "에서 " & strFile & "(이)가 있는지 확인 해보세요.")
                Exit Sub
            End If

        Catch ex As Exception
            MsgBox(ex.Message, "열려는 파일이 없습니다." & vbCrLf & strPath_Open & "에서 확인 해보세요.")
        End Try


    End Sub

    Private Sub DataGridView1_Click(sender As Object, e As EventArgs) Handles DataGridView1.Click
        ' 선택 된 Row의 ID를 가져와 저장하는 변수
        Dim rowCount As Integer = DataGridView1.CurrentRow.Index

        ' 선택한 아이템을 빈칸에 넣어주는 작업
        If IsDBNull(DataGridView1.Item(1, rowCount).Value) = False Then DaeCB.Text = DataGridView1.Item(1, rowCount).Value Else DaeCB.Text = ""
        If IsDBNull(DataGridView1.Item(2, rowCount).Value) = False Then Mid_CB.Text = DataGridView1.Item(2, rowCount).Value Else Mid_CB.Text = ""
        If IsDBNull(DataGridView1.Item(3, rowCount).Value) = False Then Min_CB.Text = DataGridView1.Item(3, rowCount).Value Else Min_CB.Text = ""
        If IsDBNull(DataGridView1.Item(4, rowCount).Value) = False Then TCnameTxt.Text = DataGridView1.Item(4, rowCount).Value Else TCnameTxt.Text = ""
        If IsDBNull(DataGridView1.Item(5, rowCount).Value) = False Then
            Dim strTextCom = DataGridView1.Item(5, rowCount).Value
            strTextCom = Replace(strTextCom, Chr(10), Chr(13) & Chr(10))
            TCPurposeTxt.Text = strTextCom
        Else
            TCPurposeTxt.Text = ""
        End If
        If IsDBNull(DataGridView1.Item(6, rowCount).Value) = False Then
            Dim strTextCom = DataGridView1.Item(6, rowCount).Value
            strTextCom = Replace(strTextCom, Chr(10), Chr(13) & Chr(10))
            DetectedTxt.Text = strTextCom
        Else
            DetectedTxt.Text = ""
        End If
        If IsDBNull(DataGridView1.Item(7, rowCount).Value) = False Then
            Dim strTextCom = DataGridView1.Item(7, rowCount).Value
            strTextCom = Replace(strTextCom, Chr(10), Chr(13) & Chr(10))
            PriTxt.Text = strTextCom
        Else
            PriTxt.Text = ""
        End If
        If IsDBNull(DataGridView1.Item(8, rowCount).Value) = False Then MDTxt.Text = DataGridView1.Item(8, rowCount).Value Else MDTxt.Text = ""
        If IsDBNull(DataGridView1.Item(9, rowCount).Value) = False Then txtFileName.Text = DataGridView1.Item(9, rowCount).Value Else txtFileName.Text = ""

    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim vSQL As String
        Dim vSQL_Dae As String
        Dim vSQL_Mid As String
        Dim vSQL_Min As String

        ' 미입력 된 부분 확인 하는 코드
        Dim a As Control
        For Each a In Me.Controls
            If TypeOf a Is TextBox Then
                If a.Text = "" Then
                    MsgBox(a.Tag + "가 입력되지 않았습니다.")
                    Exit Sub
                End If
            ElseIf TypeOf a Is ComboBox Then
                If a.Text = "" Then
                    MsgBox(a.Tag + "가 입력되지 않았습니다.")
                    Exit Sub
                End If
            End If
        Next

        vSQL_Dae = " And 대분류 = '" & DaeCB.Text & "'"
        vSQL_Mid = " And 중분류 = '" & Mid_CB.Text & "'"
        vSQL_Min = " And 소분류 = '" & Mid_CB.Text & "'"

        vSQL = "Select * from [" & strSht & "] where TC명 = '" & TCnameTxt.Text & "' " & vSQL_Dae & vSQL_Mid & vSQL_Min


        DS.Clear()
        DA = New OleDbDataAdapter(vSQL, vConn)
        DA.Fill(DS, strSht)

        Dim Table As DataTable = DS.Tables(strSht)

        ' select문 결과 0 즉, 없을 경우 추가
        If Table.Rows.Count = 0 Then

            '조회할SQL을 만들어서 String변수에 넣는다.

            vSQL = "INSERT INTO [" & strSht & "]([대분류], [중분류], [소분류], [TC명],[목적],[검증항목],[등급별진행기준],[투입MD],[파일명]) "
            vSQL = vSQL + "VALUES ('" & DaeCB.Text & "','" & Mid_CB.Text & "','" & Min_CB.Text & "','" & TCnameTxt.Text & "','"
            vSQL = vSQL + TCPurposeTxt.Text & "','" & DetectedTxt.Text & "','" & PriTxt.Text & "','" & MDTxt.Text & "','" & txtFileName.Text & "');"
            DA = New OleDbDataAdapter(vSQL, vConn)

            ' history 추가하는 부분
            'If addFea.Text = "" Then
            '    Add_History("App", "추가", addApp.Text, addApp.Text + "추가", txtName.Text)
            'Else
            '    Add_History("App & Feature", "추가", addApp.Text + " / " + addFea.Text, "App : " + addApp.Text + " / Feature : " + addFea.Text + " 추가", txtName.Text)
            'End If

            DA = New OleDbDataAdapter(vSQL, vConn)
            DA.Fill(DS, strSht)

            'Form_Refresh()
            MsgBox(TCnameTxt.Text & " 이(가) 성공적으로 추가 되었습니다.")
            Call Other_TC_Load(sender, e)
        Else
            MsgBox(TCnameTxt.Text & " 이(가) 이미 있습니다.")
        End If
    End Sub

    Private Sub btnMod_Click(sender As Object, e As EventArgs) Handles btnMod.Click
        Dim vSQL As String

        ' 미입력 된 부분 확인 하는 코드
        Dim a As Control
        For Each a In Me.Controls
            If TypeOf a Is TextBox Then
                If a.Text = "" Then
                    MsgBox(a.Tag + "가 입력되지 않았습니다.")
                    Exit Sub
                End If
            ElseIf TypeOf a Is ComboBox Then
                If a.Text = "" Then
                    MsgBox(a.Tag + "가 입력되지 않았습니다.")
                    Exit Sub
                End If
            End If
        Next

        ' 선택 된 Row의 ID를 가져와 저장하는 변수
        Dim rowCount As Integer = DataGridView1.CurrentRow.Index

        vSQL = "UPDATE [" & strSht & "] "
        vSQL = vSQL + "SET [대분류] ='" & DaeCB.Text & "',[중분류] = '" & Mid_CB.Text & "',[소분류] = '" & Min_CB.Text & "',[TC명] ='" & TCnameTxt.Text
        vSQL = vSQL + "',[목적] = '" & TCPurposeTxt.Text & "',[검증항목] = '" & DetectedTxt.Text & "',[등급별진행기준] = '" & PriTxt.Text
        vSQL = vSQL + "',[투입MD] = '" & MDTxt.Text & "',[파일명] = '" & txtFileName.Text & "'"
        vSQL = vSQL + "Where [ID] = " & DataGridView1.Item(0, rowCount).Value

        Try
            Dim DA = New OleDbDataAdapter(vSQL, vConn)
            DA.Fill(DS, strSht)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        MsgBox(TCnameTxt.Text & "이(가) 수정되었습니다.")
        Call Other_TC_Load(sender, e)


    End Sub

    Private Sub btnDel_Click(sender As Object, e As EventArgs) Handles btnDel.Click
        Dim iQuestion As String
        ' 선택 된 Row의 ID를 가져와 저장하는 변수
        Dim rowCount As Integer = DataGridView1.CurrentRow.Index

        iQuestion = MsgBox(TCnameTxt.Text & " 을 선택하셨습니다." & vbCrLf &
           "정말 삭제 하시겠습니까?", vbYesNo, "lee.sunbae@lgepartner.com")
        If iQuestion = 6 Then

            DA = New OleDbDataAdapter("Delete from [" & strSht & "]  WHERE ID= " & DataGridView1.Item(0, rowCount).Value, vConn)
            DA.Fill(DS, strSht)
            MsgBox(DataGridView1.Item(4, rowCount).Value & " 이(가) 삭제되었습니다.")

            Call Other_TC_Load(sender, e)

        Else
            Exit Sub
        End If
    End Sub

    Private Sub Min_CB_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Min_CB.SelectedIndexChanged

        Dim strDae As String = Nothing
        Dim strMid As String = Nothing
        Dim strMin As String = Nothing
        Dim DA_Search As OleDbDataAdapter = New OleDbDataAdapter()

        strDae = DaeCB.Text
        strMid = Mid_CB.Text
        strMin = Min_CB.Text

        '#### 쿼리 작성 #########################################################
        Dim vSQL As String = "SELECT * " & " "
        vSQL = vSQL + "FROM [" & strSht & "]" & " where [대분류] = '" & strDae & "' and [중분류] = '" & strMid & "' and [소분류] = '" & strMin & "' order by [ID] asc"
        '#######################################################################

        Try
            DA_Search = New OleDbDataAdapter(vSQL, vConn)

            Dim DS_Search As New DataSet
            DA_Search.Fill(DS_Search, strSht)

            Dim Table_Search As DataTable = DS_Search.Tables(0)

            If Table_Search.Rows.Count = 0 Then
                MsgBox("조회할 내용이 없습니다.",, "lee.sunbae@lgepartner.com")
                Exit Sub
            End If

            For i = 0 To DataGridView1.RowCount - 1
                If Table_Search.Rows(0)(0).ToString = DataGridView1.Item(0, i).Value Then
                    DataGridView1.Rows(i).Cells(0).Selected = True
                    DataGridView1.BeginEdit(True) ' 포커스 이동
                End If
            Next i


            DaeCB.Text = Table_Search.Rows(0)(1).ToString
            Mid_CB.Text = Table_Search.Rows(0)(2).ToString
            Min_CB.Text = Table_Search.Rows(0)(3).ToString
            TCnameTxt.Text = Table_Search.Rows(0)(4).ToString

            If IsDBNull(Table_Search.Rows(0)(5).ToString) = False Then
                Dim strTextCom = Table_Search.Rows(0)(5).ToString
                strTextCom = Replace(strTextCom, Chr(10), Chr(13) & Chr(10))
                TCPurposeTxt.Text = strTextCom
            Else
                TCPurposeTxt.Text = ""
            End If

            If IsDBNull(Table_Search.Rows(0)(6).ToString) = False Then
                Dim strTextCom = Table_Search.Rows(0)(6).ToString
                strTextCom = Replace(strTextCom, Chr(10), Chr(13) & Chr(10))
                DetectedTxt.Text = strTextCom
            Else
                DetectedTxt.Text = ""
            End If
            If IsDBNull(Table_Search.Rows(0)(7).ToString) = False Then
                Dim strTextCom = Table_Search.Rows(0)(7).ToString
                strTextCom = Replace(strTextCom, Chr(10), Chr(13) & Chr(10))
                PriTxt.Text = strTextCom
            Else
                PriTxt.Text = ""
            End If
            MDTxt.Text = Table_Search.Rows(0)(8).ToString
            txtFileName.Text = Table_Search.Rows(0)(9).ToString

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

End Class