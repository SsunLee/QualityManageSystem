Imports System.Windows.Forms
Imports System.Data
Imports System.Data.OleDb

Public Class App_Feature
    Private DS As DataSet = New DataSet
    Private DS_App As DataSet = New DataSet
    Private DS_Search As DataSet = New DataSet
    Private DA As OleDbDataAdapter = New OleDbDataAdapter()
    Private DA_Admin As OleDbDataAdapter = New OleDbDataAdapter()
    Public ordAdapter As OleDbDataAdapter = New OleDbDataAdapter()
    Private vConn As OleDbConnection
    Private vConn2 As OleDbConnection
    Private vCon As String = Nothing
    Dim strSht As String = "Request_App"
    Dim strsht2 As String = "TD_AF_DS"
    Dim strAdmin As String = "Admin_Name"

    Dim chkBtsearch As Integer
    Dim chkSearch As Boolean

    Public strCont As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\신창하\업무\Task\Test_db\admin\QPortalDB_Admin.accdb;Jet OLEDB:Database Password = lge1234;"
    Public strCont2 As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\신창하\업무\Task\Test_db\20180328_QPortalDB.accdb;Jet OLEDB:Database Password = lge1234;"
    Public vCont As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=\\10.169.88.40\Q-Portal\0.AccessDB\QPortalDB.accdb;Jet OLEDB:Database Password = lge1234;"




    ' ================ GridView Data 출력하기 ==================
    Public Sub Form_Refresh()

        '------------- GridView 초기화------------
        gridRequest.DataSource = Nothing
        If DS.Tables.Count > 1 Then
            DS.Tables(0).Clear()
        End If

        '관리자 이름 고정
        Dim strUserName As String = Nothing
        Dim xml As New XML

        ' 이름을 받아옴
        For Each v In System.Windows.Forms.Application.OpenForms
            If v.Name = "Main_Form" Then
                'txtName.Text = v.strUserName
                Exit For
            End If
        Next


        Try
            Dim vCon As String = Nothing
            ' vcon가져오는 함수
            xml.vCon_Admin_Call(vCon)
            ' Connect 연결
            vConn = New OleDbConnection(vCon)
            vConn.Open()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "DB Open에러")
            Exit Sub
        End Try

        DA = New OleDbDataAdapter("Select ID, Type, AppName, Feature, Description, Requester, Manager, Status from [" & strSht & "]  order by [ID] asc", vConn)
        DA.Fill(DS, strSht)

        Dim table As DataTable = DS.Tables(strSht)

        If table.Rows.Count = 0 Then
            MsgBox("조회할 내용이 없습니다",, "changha.shin@lgepartner.com")
            Exit Sub
        End If

        gridRequest.DataSource = DS.Tables(0)


    End Sub
    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'GridView 데이터 출력되는 설정값
        With gridRequest
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            .AllowUserToResizeColumns = True
            .AllowUserToResizeRows = True
            .MultiSelect = False
        End With


        'Status ComboBox Item 추가
        With cbStat
            .Items.Add("New")
            .Items.Add("Assigned")
            .Items.Add("Closed")
        End With

        'Type ComboBox Item 추가
        With cbType
            .Items.Add("LG")
            .Items.Add("GMS")
            .Items.Add("Operator")
            .Text = cbType.Items(0)
        End With

        Form_Refresh()

        Try
            Dim XML As New XML
            ' vcon가져오는 함수
            XML.vCon_Admin_Call(vCon)
            vConn = New OleDbConnection(vCon) 'strcont
            vConn.Open()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        DA = New OleDbDataAdapter("Select A_NAME From [" & strAdmin & "] order by [ID] asc", vConn)
        DA.Fill(DS, strAdmin)

        ' 담당자 DB에 있는 값을 이름만 잘라내어 ComboBox에 추가
        Dim Admin As String() = Nothing
        For i As Integer = 0 To DS.Tables(1).Rows.Count - 1
            Dim a = DS.Tables(1).Rows(i)(0).ToString
            a = Strings.Left(a, InStr(a, "(") - 1)
            cbManager.Items.Add(a)
        Next

    End Sub

    Private Sub gridRequest_Click(sender As Object, e As EventArgs) Handles gridRequest.Click
        Dim rowCount As Integer = gridRequest.CurrentRow.Index

        ' 선택한 아이템을 빈칸에 넣어주는 작업
        If IsDBNull(gridRequest.Item(1, rowCount).Value) = False Then txtType.Text = gridRequest.Item(1, rowCount).Value Else txtApp.Text = ""
        If IsDBNull(gridRequest.Item(2, rowCount).Value) = False Then txtApp.Text = gridRequest.Item(2, rowCount).Value Else txtApp.Text = ""
        If IsDBNull(gridRequest.Item(3, rowCount).Value) = False Then txtFeat.Text = gridRequest.Item(3, rowCount).Value Else txtFeat.Text = ""
        If IsDBNull(gridRequest.Item(4, rowCount).Value) = False Then txtDes.Text = gridRequest.Item(4, rowCount).Value Else txtDes.Text = ""
        If IsDBNull(gridRequest.Item(6, rowCount).Value) = False Then cbManager.Text = gridRequest.Item(6, rowCount).Value Else cbManager.Text = ""
        If IsDBNull(gridRequest.Item(7, rowCount).Value) = False Then cbStat.Text = gridRequest.Item(7, rowCount).Value Else cbStat.Text = ""
    End Sub

    Private Sub btMod_Click(sender As Object, e As EventArgs) Handles btMod.Click
        'Datagrid에 선택된 Row의 Index 저장
        Dim rowCount As Integer = gridRequest.CurrentRow.Index

        '입력하지 않은 값이 있는지 확인
        If txtType.Text = "" Or txtApp.Text = "" Or txtFeat.Text = "" Or cbManager.Text = "" Or cbStat.Text = "" Then
            MsgBox("입력하지 않은 정보가 있습니다. 입력 후 재시도 하세요")
            Exit Sub
        Else
            'DB 수정 Query문
            Try
                DA = New OleDbDataAdapter("UPDATE " & strSht & " SET Type = '" & txtType.Text & "', Status = '" & cbStat.Text & "', Manager = '" & cbManager.Text &
                "' WHERE ID = " & gridRequest.Item(0, rowCount).Value, vConn)

                DA.Fill(DS, strSht)
                MsgBox("수정되었습니다")
                Form_Refresh()
                '수정하기 전 마지막으로 선택한 포커스 유지
                gridRequest.Rows(rowCount).Selected = True
                gridRequest.CurrentCell = gridRequest.Rows(rowCount).Cells(0)



            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim rowCount As Integer = gridRequest.CurrentRow.Index

        If MsgBox("선택한 행의 데이터를 정말로 삭제하시겠습니까?", vbYesNo, "changha.lgepartner.com") = vbNo Then
            Exit Sub
        Else
            'DB 삭제 Query 문
            Try
                DA = New OleDbDataAdapter("Delete from " & strSht & " Where ID = " & gridRequest.Item(0, rowCount).Value, vConn)

                DA.Fill(DS, strSht)

                MsgBox("정상적으로 삭제되었습니다.")
                Form_Refresh()

            Catch ex As Exception
                MsgBox(ex.Message)

            End Try

        End If




    End Sub


    Private Sub btSearch_Click(sender As Object, e As EventArgs) Handles btSearch.Click
        DS_Search.Clear()
        'Feature만 검색하지 못하게 예외처리
        If addApp.Text = "" And addFeat.Text <> "" Then
            MsgBox("추가할 App 이름을 입력하세요")
            Exit Sub
        ElseIf addApp.Text = "" And addFeat.Text = "" Then
            MsgBox("추가할 App 이름과 Feature 이름을 입력하세요")
            Exit Sub
        End If

        Dim strSearch As String
        '검색 Select Query 문
        strSearch = "Select * from " & strsht2 & " where Type = '" & cbType.Text & "' "
        If addApp.Text <> "" Then
            If addFeat.Text <> "" Then
                strSearch = strSearch & "and AppName = '" & addApp.Text & "' and Feature = '" & addFeat.Text & "'"

            Else
                strSearch = strSearch & "and AppName = '" & addApp.Text & "'"
            End If

        End If


        Try
            ' TD_AF_DS 테이블이 있는 DB에 연결
            Dim xml As New XML
            xml.vCon_Call(vCon)
            vConn = New OleDbConnection(vCon) 'strcont2
            vConn.Open()

            DA = New OleDbDataAdapter(strSearch, vConn)
            DA.Fill(DS_Search, strsht2)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Dim searchTable As DataTable = DS_Search.Tables(strsht2)

        '추가하려는 type, app, feature 이 존재하는지 확인
        chkBtsearch = searchTable.Rows.Count

        '검색 버튼을 눌렀는지 확인
        chkSearch = True

        If searchTable.Rows.Count = 0 Then
            MsgBox("======= 검색결과 =======" & vbCrLf & "Type : " & cbType.Text & vbCrLf & "App : " & addApp.Text & vbCrLf & "Feature : " & addFeat.Text & vbCrLf & "=====================" & vbCrLf & "위 항목이 존재하지 않습니다.")
        Else
            MsgBox("======= 검색결과 =======" & vbCrLf & "Type : " & cbType.Text & vbCrLf & "App : " & addApp.Text & vbCrLf & "Feature : " & addFeat.Text & vbCrLf & "=====================" & vbCrLf & "위 항목과 동일한 항목이 존재합니다.")
            '존재한다면 Table을 초기화 시키기
            DS_Search.Clear()

        End If
    End Sub

    Private Sub btRefresh_Click(sender As Object, e As EventArgs) Handles btRefresh.Click
        Form_Refresh()
    End Sub

    Private Sub btAdd_Click(sender As Object, e As EventArgs) Handles btAdd.Click
        'Type, App, Feature 검색 전 추가버튼 눌렀을 때 예외처리
        If chkSearch = False Then
            MsgBox("추가하려는 Type, App, Feature 이(가) 존재하는지 검색하세요")
            Exit Sub
            '추가하려는 Type, App, Feature 존재 하였을 때 예외 처리
        End If
        Dim addSQL As String

        '추가할 Type, App, Feature, Description Query 작성
        addSQL = "Insert Into " & strsht2 & " (Type, AppName, Feature, Description) Values ('" & cbType.Text & "'"
        If addDes.Text = "" And addFeat.Text = "" Then
            addSQL = addSQL & ", '" & addApp.Text & "', '', '');"
        ElseIf adddes.Text = "" And addfeat.Text <> "" Then
            addSQL = addSQL & ", '" & addApp.Text & "', '" & addFeat.Text & "', '');"
        Else
            addSQL = addSQL & ", '" & addApp.Text & "', '" & addFeat.Text & "', '" & addDes.Text & "');"
        End If

        If MsgBox("Type : " & cbType.Text & vbCrLf & "App : " & addApp.Text & vbCrLf & "Feature : " & addFeat.Text & vbCrLf & "추가 하시겠습니까?", vbQuestion + vbYesNo) = vbNo Then
            Exit Sub
        Else
            If chkBtsearch <> 0 Then
                MsgBox("추가하려는 Type, App, Feature 이(가) 이미 존재합니다")
                Exit Sub
            Else

                'TD_AF_DS DB 연결
                Try
                    Dim xml As New XML
                    xml.vCon_Call(vCon)
                    vConn = New OleDbConnection(vCon) 'strcont2
                    vConn.Open()

                    ' TD_AF_DS DB 추가
                    DA = New OleDbDataAdapter(addSQL, vConn)
                    DA.Fill(DS_Search, strsht2)

                Catch ex As Exception

                End Try

                MsgBox("정상적으로 추가되었습니다")
            End If
        End If

    End Sub

    Private Sub addApp_TextChanged(sender As Object, e As EventArgs) Handles addApp.TextChanged
        chkSearch = False
    End Sub
    Private Sub addFeat_TextChanged(sender As Object, e As EventArgs) Handles addFeat.TextChanged
        chkSearch = False
    End Sub

    Private Sub TabPage2_Enter(sender As Object, e As EventArgs) Handles TabPage2.Enter

        With gridApp
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader
            .AllowUserToResizeColumns = True
            .AllowUserToResizeRows = True
            .MultiSelect = False
        End With

        gridApp_Refresh()

        Try
            Dim xml As New XML
            xml.vCon_Call(vCon)
            vConn = New OleDbConnection(vCon) 'strcont2
            vConn.Open()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        DA = New OleDbDataAdapter("Select Type From [" & strsht2 & "] order by [Type] asc", vConn)
        DA.Fill(DS_App, "Type")
        ' 담당자 DB에 있는 값을 이름만 잘라내어 ComboBox에 추가
        Dim Admin As String() = Nothing
        Dim Type As DataTable = DS_App.Tables(1)
        For i As Integer = 0 To Type.Rows.Count - 1
            If Not cbTypeT2.Items.Contains(Type.Rows(i)(0).ToString()) Then
                cbTypeT2.Items.Add(Type.Rows(i)(0).ToString())
            End If

            'Dim a = DS.Tables(1).Rows(i)(0).ToString
            'a = Strings.Left(a, InStr(a, "(") - 1)
            'cbTypeT2.Items.Add(a)
        Next
        With cbTypeT2
            .Text = cbTypeT2.Items(0)
        End With
    End Sub
    ' ================ GridView Data 출력하기 ==================
    Public Sub gridApp_Refresh()

        '------------- GridView 초기화------------
        gridApp.DataSource = Nothing
        DS_App.Clear()

        '관리자 이름 고정
        Dim strUserName As String = Nothing
        Dim xml As New XML

        ' 이름을 받아옴
        For Each v In System.Windows.Forms.Application.OpenForms
            If v.Name = "Main_Form" Then
                'txtName.Text = v.strUserName
                Exit For
            End If
        Next


        Try
            Dim vCon As String = Nothing
            ' vcon가져오는 함수
            xml.vCon_Call(vCon)
            ' Connect 연결
            vConn = New OleDbConnection(vCon) 'strcont2
            vConn.Open()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "DB Open에러")
            Exit Sub
        End Try

        DA = New OleDbDataAdapter("Select ID, Type, AppName, Feature, Description from [" & strsht2 & "]  order by [ID] ASC", vConn)
        DA.Fill(DS_App, strsht2)

        Dim table As DataTable = DS_App.Tables(strsht2)

        If table.Rows.Count = 0 Then
            MsgBox("조회할 내용이 없습니다",, "changha.shin@lgepartner.com")
            Exit Sub
        End If

        gridApp.DataSource = DS_App.Tables(0)

    End Sub

    Private Sub btApprefresh_Click(sender As Object, e As EventArgs) Handles btApprefresh.Click
        gridApp_Refresh()
    End Sub

    Private Sub gridApp_Click(sender As Object, e As EventArgs) Handles gridApp.Click
        Dim rowCount = gridApp.CurrentRow.Index

        If IsDBNull(gridApp.Item(1, rowCount).Value) = False Then cbTypeT2.Text = gridApp.Item(1, rowCount).Value Else cbTypeT2.Text = ""
        If IsDBNull(gridApp.Item(2, rowCount).Value) = False Then txtAppT2.Text = gridApp.Item(2, rowCount).Value Else txtAppT2.Text = ""
        If IsDBNull(gridApp.Item(3, rowCount).Value) = False Then txtFeatT2.Text = gridApp.Item(3, rowCount).Value Else txtFeatT2.Text = ""
        If IsDBNull(gridApp.Item(4, rowCount).Value) = False Then txtDesT2.Text = gridApp.Item(4, rowCount).Value Else txtDesT2.Text = ""
    End Sub


    Private Sub btSearchT2_Click(sender As Object, e As EventArgs) Handles btSearchT2.Click

        DS_Search.Clear()

        If txtAppT2.Text = "" And txtFeatT2.Text <> "" Then
            MsgBox("검색할 App 이름을 입력하세요")
            Exit Sub
        ElseIf txtAppT2.Text = "" And txtFeatT2.Text = "" Then
            MsgBox("검색할 App 이름과 Feature 이름을 입력하세요")
            Exit Sub
        End If

        Dim strSearch As String
        strSearch = "Select * from " & strsht2 & " Where Type = '" & cbTypeT2.Text & "' "
        If txtAppT2.Text <> "" Then
            If txtFeatT2.Text <> "" Then
                strSearch = strSearch & "and AppName = '" & txtAppT2.Text & "' and Feature = '" & txtFeatT2.Text & "'"

            Else
                strSearch = strSearch & "and AppName = '" & txtAppT2.Text & "'"
            End If

        End If


        Try
            ' TD_AF_DS 테이블이 있는 DB에 연결
            Dim xml As New XML
            xml.vCon_Call(vCon)
            vConn = New OleDbConnection(vCon) 'strcont2
            vConn.Open()

            DA = New OleDbDataAdapter(strSearch, vConn)
            DA.Fill(DS_Search, "Search")

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        If DS_Search.Tables("Search").Rows.Count = 0 Then
            MsgBox("App과 Feature를 찾을 수 없습니다.")
            Exit Sub
        End If
        gridApp.DataSource = DS_Search.Tables("Search")
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub btModT2_Click(sender As Object, e As EventArgs) Handles btModT2.Click
        'Datagrid에 선택된 Row의 Index 저장
        Dim rowCount As Integer = gridApp.CurrentRow.Index

        '입력하지 않은 값이 있는지 확인
        If cbTypeT2.Text = "" Or txtAppT2.Text = "" Or txtFeatT2.Text = "" Then
            MsgBox("입력하지 않은 정보가 있습니다. 입력 후 재시도 하세요")
            Exit Sub
        Else
            'DB 수정 Query문
            Try
                DA = New OleDbDataAdapter("UPDATE " & strsht2 & " SET Type = '" & cbTypeT2.Text & "', AppName = '" & txtAppT2.Text & "', Feature = '" & txtFeatT2.Text & "', Description = '" & txtDesT2.Text &
                "' WHERE ID = " & gridApp.Item(0, rowCount).Value, vConn)

                DA.Fill(DS_App, strsht2)
                MsgBox("수정되었습니다")
                gridApp_Refresh()
                '수정하기 전 마지막으로 선택한 포커스 유지
                gridApp.Rows(rowCount).Selected = True
                gridApp.CurrentCell = gridApp.Rows(rowCount).Cells(0)
                'gridApp.Select()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Private Sub btDeleteT2_Click(sender As Object, e As EventArgs) Handles btDeleteT2.Click

        Dim rowCount As Integer = gridApp.CurrentRow.Index
        If MsgBox("선택한 행의 데이터를 정말로 삭제하시겠습니까?", vbYesNo, "changha.lgepartner.com") = vbNo Then
            Exit Sub
        Else
            'DB 삭제 Query 문
            Try
                Dim xml As New XML
                xml.vCon_Call(vCon)

                vConn = New OleDbConnection(vCon)
                'vConn.Open()

                DA = New OleDbDataAdapter("Delete from " & strsht2 & " Where ID = " & gridApp.Item(0, rowCount).Value, vConn)
                DA.Fill(DS_App, strsht2)

                MsgBox("정상적으로 삭제되었습니다.")
                gridApp_Refresh()

            Catch ex As Exception
                MsgBox(ex.Message)

            End Try

        End If

    End Sub
End Class