Imports System.Data
Imports System.Data.OleDb
Imports System.Windows.Forms

Public Class Work_Guide_Edit
    Private DS As DataSet = New DataSet
    Private DA As OleDbDataAdapter = New OleDbDataAdapter()
    Public ordAdapter As OleDbDataAdapter = New OleDbDataAdapter()
    Private strSQL As String
    Private vConn As OleDbConnection
    Public strSht As String
    Public strFile As String = Nothing
    Public strFileName As String = Nothing
    Public strFilePath As String = "\\10.174.51.33\Q-Portal\업무관련Guide"
    Dim Main_Form As New Main_Form

    ' 업무가이드 경로
    Public szPath_Guide As String = "\\10.174.51.33\Q-Portal\업무관련Guide"

    Public strOpenPath As String = Nothing
    ' Public strFile As String = Nothing

    Private Sub Other_TC_Load(sender As Object, e As EventArgs) Handles MyBase.Load, btnRe.Click

        'GubunCB.Text = "여기를 선택 해주세요"
        strSht = "Sheet1_GM"

        '#### 쿼리 작성 ######################################################### 
        Dim vSQL As String = "SELECT [ID], [Assign] as 구분 , [Depth1] as 검증구분 , [Depth2] as 상세검증구분 , [Title] as 상세분류 ,[Description] ,[Detail Guide] as 파일명 " & " "
        vSQL = vSQL + "FROM [" & strSht & "]" & " order by [ID] asc"
        '#######################################################################

        Try
            vConn = New OleDbConnection(Main_Form.strCon)
            DA = New OleDbDataAdapter(vSQL, vConn)

            Dim DS As New DataSet
            DA.Fill(DS, strSht)

            Dim Table_Word As DataTable = DS.Tables(0)


            If Table_Word.Rows.Count = 0 Then
                MsgBox("검색결과가 없습니다.")
            End If

            For i As Integer = 0 To Table_Word.Rows.Count - 1            ' Data table Row 만큼 반복 -1은 마지막행은 Null
                If Not GubunCB.Items.Contains(Table_Word.Rows(i)(1).ToString()) Then  ' 중복 없이 Item 추가
                    GubunCB.Items.Add(Table_Word.Rows(i)(1).ToString())
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
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells ' Column size Auto
            .AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells       ' Row Size Auto
            .DefaultCellStyle.WrapMode = DataGridViewTriState.True  ' Data Grid View Multi Line

            .AllowUserToResizeColumns = True
            .AllowUserToResizeRows = True
        End With
    End Sub

    Private Sub TestGubunCB_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TestGubunCB.SelectedIndexChanged

        Dim DS As New DataSet
        DA.Fill(DS, strSht)
        Dim Table As DataTable = DS.Tables(0)


        'txtTitle.Text = ""      ' Title 
        'TCPurposeTxt.Text = ""   ' 목적
        'txtDes.Text = ""    ' 검증 항목
        'PriTxt.Text = ""         ' 등급 별 진행 기준
        'MDTxt.Text = ""          ' 투입 MD


        For i As Integer = 0 To Table.Rows.Count - 1            ' Data table Row 만큼 반복 -1은 마지막행은 Null
            If GubunCB.Text = Table.Rows(i)(1).ToString() And TestGubunCB.Text = Table.Rows(i)(2).ToString() Then
                ' If Not Min_CB.Items.Contains(Table.Rows(i)(3).ToString()) Then  ' 중복 없이 Item 추가
                'Min_CB.Items.Add(Table.Rows(i)(3).ToString())
                'End If
            End If
        Next

    End Sub

    Private Sub btnFileLoad_Click(sender As Object, e As EventArgs) Handles btnFileLoad.Click
        Dim TC_Path_GM As New TC_Path_GM

        TC_Path_GM.Default_Path.Text = strFilePath

        TC_Path_GM.txtGuide.Text = szPath_Guide

        TC_Path_GM.Show()

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

        'GubunCB.Text = ""
        'TestGubunCB.Text = ""
        'Min_CB.Text = ""
        'txtTitle.Text = ""
        'TCPurposeTxt.Text = ""
        'txtDes.Text = ""
        'PriTxt.Text = ""
        'MDTxt.Text = ""
        'txtFileName.Text = ""

    End Sub

    Private Sub Gubun_CB_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GubunCB.SelectedIndexChanged

        TestGubunCB.Text = ""

        Try
            Dim DS As New DataSet
            DA.Fill(DS, strSht)
            Dim Table As DataTable = DS.Tables(0)

            'GubunCB
            TestGubunCB.Items.Clear()     ' 중분류

            'txtTitle.Text = ""      ' Title 
            'TCPurposeTxt.Text = ""   ' 목적
            'txtDes.Text = ""    ' 검증 항목
            'PriTxt.Text = ""         ' 등급 별 진행 기준
            'MDTxt.Text = ""          ' 투입 MD

            For i As Integer = 0 To Table.Rows.Count - 1            ' Data table Row 만큼 반복 -1은 마지막행은 Null
                If GubunCB.Text = Table.Rows(i)(1).ToString() Then  ' 선택 된 App과 Row, 필트(0)은 App, (1) 은 Feature
                    Try
                        If Not TestGubunCB.Items.Contains(Table.Rows(i)(2).ToString()) Then  ' 중복 없이 Item 추가
                            TestGubunCB.Items.Add(Table.Rows(i)(2).ToString())
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

    Private Sub DataGridView1_Click(sender As Object, e As EventArgs) Handles DataGridView1.Click
        ' 선택 된 Row의 ID를 가져와 저장하는 변수
        Dim rowCount As Integer = DataGridView1.CurrentRow.Index

        ' 선택한 아이템을 빈칸에 넣어주는 작업
        If IsDBNull(DataGridView1.Item(1, rowCount).Value) = False Then GubunCB.Text = DataGridView1.Item(1, rowCount).Value Else GubunCB.Text = ""
        If IsDBNull(DataGridView1.Item(2, rowCount).Value) = False Then TestGubunCB.Text = DataGridView1.Item(2, rowCount).Value Else TestGubunCB.Text = ""
        If IsDBNull(DataGridView1.Item(3, rowCount).Value) = False Then txtDepth2.Text = DataGridView1.Item(3, rowCount).Value Else txtDepth2.Text = ""
        If IsDBNull(DataGridView1.Item(4, rowCount).Value) = False Then txtTitle.Text = DataGridView1.Item(4, rowCount).Value Else txtTitle.Text = ""

        If IsDBNull(DataGridView1.Item(5, rowCount).Value) = False Then
            Dim strTextCom = DataGridView1.Item(5, rowCount).Value
            strTextCom = Replace(strTextCom, Chr(10), Chr(13) & Chr(10))
            txtDes.Text = strTextCom
        Else
            txtDes.Text = ""
        End If

        If IsDBNull(DataGridView1.Item(6, rowCount).Value) = False Then txtFileName.Text = DataGridView1.Item(6, rowCount).Value Else txtFileName.Text = ""

    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
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

        vSQL = "Select * from [" & strSht & "] where Title = '" & txtTitle.Text & "' "


        DS.Clear()
        DA = New OleDbDataAdapter(vSQL, vConn)
        DA.Fill(DS, strSht)

        Dim Table As DataTable = DS.Tables(strSht)

        ' select문 결과 0 즉, 없을 경우 추가
        If Table.Rows.Count = 0 Then

            '조회할SQL을 만들어서 String변수에 넣는다.

            vSQL = "INSERT INTO [" & strSht & "]([Depth1], [Depth2], [Assign], [Title],[Description],[Detail Guide]) "
            vSQL = vSQL + "VALUES ('" & TestGubunCB.Text & "','" & txtDepth2.Text & "','" & GubunCB.Text & "','" & txtTitle.Text & "','"
            vSQL = vSQL + txtDes.Text & "','" & txtFileName.Text & "');"
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
            MsgBox(txtTitle.Text & " 이(가) 성공적으로 추가 되었습니다.")
            Call Other_TC_Load(sender, e)
        Else
            MsgBox(txtTitle.Text & " 이(가) 이미 있습니다.")
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
        vSQL = vSQL + "SET [Depth1] ='" & TestGubunCB.Text & "',[Depth2] = '" & txtDepth2.Text & "',[Assign] = '" & GubunCB.Text & "',[Title] ='" & txtTitle.Text
        vSQL = vSQL + "',[Description] = '" & txtDes.Text & "',[Detail Guide] = '" & txtFileName.Text & "'"
        vSQL = vSQL + "Where [ID] = " & DataGridView1.Item(0, rowCount).Value

        Try
            Dim DA = New OleDbDataAdapter(vSQL, vConn)
            DA.Fill(DS, strSht)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        MsgBox(txtTitle.Text & "이(가) 수정되었습니다.")
        Call Other_TC_Load(sender, e)


    End Sub

    Private Sub btnDel_Click(sender As Object, e As EventArgs) Handles btnDel.Click
        Dim iQuestion As String
        ' 선택 된 Row의 ID를 가져와 저장하는 변수
        Dim rowCount As Integer = DataGridView1.CurrentRow.Index

        iQuestion = MsgBox(txtTitle.Text & " 을 선택하셨습니다." & vbCrLf &
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

End Class