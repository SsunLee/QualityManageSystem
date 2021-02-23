Imports System.Windows.Forms
Imports System.Data
Imports System.Data.OleDb
Imports System.Data.SqlClient

Public Class Term_Admin_GM

    Private DS As DataSet = New DataSet
    Private DS_Admin As DataSet = New DataSet
    Private DA As OleDbDataAdapter = New OleDbDataAdapter()
    Private DA_Admin As OleDbDataAdapter = New OleDbDataAdapter()

    'Tap Page2
    Private DS_Dictionary As DataSet = New DataSet
    Private DA_Dictionary As OleDbDataAdapter = New OleDbDataAdapter()
    Private DS_Search As DataSet = New DataSet
    Private DA_Search As OleDbDataAdapter = New OleDbDataAdapter()



    Public ordAdapter As OleDbDataAdapter = New OleDbDataAdapter()
    Private strSQL As String
    Private vConn As OleDbConnection
    Private vConn2 As OleDbConnection
    Dim strSht As String = "Request_Dictionary"
    Dim strSht2 As String = "용어"
    Dim strDate As String = Now()

    Public prevWord As String

    Public strCont_Admin As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\신창하\업무\Task\Test_db\admin\QPortalDB_Admin.accdb;Jet OLEDB:Database Password = lge1234;"
    Public strCont As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\신창하\업무\Task\Test_db\20180328_QPortalDB.accdb;Jet OLEDB:Database Password = lge1234;"
    Private sender As Object

    Public Sub Form_Refresh()
        '###### 데이터그리드뷰 띄어줘 관리/소통 하는 시스템######

        ' 초기화 해주는 코드
        DataGridView1.DataSource = Nothing
        DS.Clear()

        'DB 연결
        Dim XML As New XML
        Try
            Dim vCon As String = Nothing
            ' vcon가져오는 함수
            XML.vCon_Call(vCon)
            ' Connect 연결
            vConn2 = New OleDbConnection(vCon) 'strcont
            vConn2.Open()

            ' vcon가져오는 함수
            XML.vCon_Admin_Call(vCon)
            ' Connect 연결
            vConn = New OleDbConnection(vCon) 'strCont_Admin
            vConn.Open()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "DB Open에러")
            Exit Sub
        End Try

        'Request_Dictionary DB Query문
        DA = New OleDbDataAdapter("Select * from [" & strSht & "] Where [용어] > '' order by [ID] asc", vConn)
        DA.Fill(DS, strSht)

        Dim Table As DataTable = DS.Tables(strSht)

        '요청내용 없을 때
        If Table.Rows.Count = 0 Then
            MsgBox("조회할 내용이 없습니다.",, "lee.sunbae@lgepartner.com")
            Exit Sub
        End If

        DataGridView1.DataSource = DS.Tables(strSht)
        Dim e As EventArgs = Nothing
        DataGridView1_Click(sender, e)

    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Form_Refresh()
    End Sub
    Private Sub Form6_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim XML As New XML
        Try
            Dim vCon As String = Nothing
            ' vcon가져오는 함수
            XML.vCon_Call(vCon)
            ' Connect 연결
            vConn2 = New OleDbConnection(vCon) 'strcont
            vConn2.Open()

            ' vcon가져오는 함수
            XML.vCon_Admin_Call(vCon)
            ' Connect 연결
            vConn = New OleDbConnection(vCon) 'strCont_Admin
            vConn.Open()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "DB Open에러")
            Exit Sub
        End Try

        Dim toolTip1 As New ToolTip()
        ' toolTip1.SetToolTip(txtModule, "ex) BSP, Audio, Kernel, BT, Camera, Common, Network ")
        'toolTip1.SetToolTip(txtRisk, "앱 이름을 입력만 한 상태로 Load 하면 됩니다. ")
        'toolTip1.SetToolTip(ComboBox2, "대분류 카테고리를 선택할 수 있습니다. * 선택하지 않아도 됩니다.")
        'toolTip1.SetToolTip(TextBox1, "검색어를 입력하세요.")
        'toolTip1.SetToolTip(Button2, "Search")
        toolTip1.InitialDelay = 100
        toolTip1.AutoPopDelay = 3000    ' 사용자가 마우스를 올려서 보여지는 시간
        toolTip1.ReshowDelay = 500

        '관리자 이름 고정
        Dim strUserName As String = Nothing

        ' 이름을 받아옴
        For Each v In System.Windows.Forms.Application.OpenForms
            If v.Name = "Main_Form" Then
                txtUser.Text = v.strUserName
                Exit For
            End If
        Next

        ' 기본 값과 셋팅 설정
        With DataGridView1
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            .AllowUserToResizeColumns = True
            .AllowUserToResizeRows = True
            .MultiSelect = False
        End With

        DA_Admin = New OleDbDataAdapter("Select A_NAME From Admin_Name order by [ID] ASC", vConn)
        DA_Admin.Fill(DS_Admin, "Admin")

        Dim Table As DataTable = DS_Admin.Tables("Admin")

        For i As Integer = 0 To Table.Rows.Count - 1
            Dim a As String = Table.Rows(i)(0).ToString()
            a = Strings.Left(a, InStr(a, "(") - 1)
            cbManager.Items.Add(a)
        Next

        With cbStatus.Items
            .Add("Assigned")
            .Add("Open")
            .Add("Closed")
        End With

        txtRequester.ReadOnly = True
        txtWord.ReadOnly = True


        Form_Refresh()
    End Sub

    Private Sub btnMod_Click(sender As Object, e As EventArgs) Handles btnMod.Click

        ' 선택 된 Row의 ID를 가져와 저장하는 변수
        Dim rowCount As Integer = DataGridView1.CurrentRow.Index

        If txtRequester.Text = "" Or txtWord.Text = "" Or cbManager.Text = "" Or cbStatus.Text = "" Then
            MsgBox("수정 할 내용의 정보가 입력 되었는지 확인하세요")
            Exit Sub
        Else
            Try
                DA = New OleDbDataAdapter("UPDATE " & strSht & " Set 담당자 = '" & cbManager.Text & "', 상태 = '" & cbStatus.Text & "', 상태변경날짜 = '" & Now & "'" &
                    "WHERE ID = " & DataGridView1.Item(0, rowCount).Value, vConn)
                DA.Fill(DS, strSht)
                MsgBox("수정 되었습니다")
                Form_Refresh()


            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If

    End Sub

    Private Sub DataGridView1_Click(sender As Object, e As EventArgs) Handles DataGridView1.Click
        Dim Table As DataTable = Nothing

        Dim strDes As String = Nothing
        Dim strCom As String = Nothing
        Dim strPDes As String = Nothing

        ' 선택 된 Row의 ID를 가져와 저장하는 변수
        Dim rowCount As Integer
        If DataGridView1.Rows.Count <> 0 Then
            rowCount = DataGridView1.CurrentRow.Index
            ' 각 각 폼에 List Box 및 개체들에게 값을 넣어주기 위함.
            If IsDBNull(DataGridView1.Item(1, rowCount).Value) = False Then txtWord.Text = DataGridView1.Item(1, rowCount).Value Else txtWord.Text = ""
            If IsDBNull(DataGridView1.Item(3, rowCount).Value) = False Then txtDes.Text = DataGridView1.Item(3, rowCount).Value Else txtDes.Text = ""
            If IsDBNull(DataGridView1.Item(4, rowCount).Value) = False Then txtRequester.Text = DataGridView1.Item(4, rowCount).Value Else txtRequester.Text = ""
            If IsDBNull(DataGridView1.Item(6, rowCount).Value) = False Then cbManager.Text = DataGridView1.Item(6, rowCount).Value Else cbManager.Text = ""
            If IsDBNull(DataGridView1.Item(7, rowCount).Value) = False Then cbStatus.Text = DataGridView1.Item(7, rowCount).Value Else cbStatus.Text = ""

        End If



        'If txtDes.Text = DataGridView1.Item(6, rowCount).Value And DataGridView1.Item(5, rowCount).Value = "수정" Then
        '    ' 기존 용어DB에서 값을 가져옴
        '    vSQL = "Select * from [" & strSht2 & "] where 용어 = '" & DataGridView1.Item(1, rowCount).Value & "'"

        '    Try
        '        DA = New OleDbDataAdapter(vSQL, vConn2)
        '        DA.Fill(DS, strSht2)
        '        Table = DS.Tables(strSht2)
        '    Catch ex As Exception
        '        MsgBox(ex.Message)
        '    End Try
        '    If Table.Rows.Count = 0 Then
        '        MsgBox("수정 할 수 없습니다. 해당 용어는 없습니다. 요청리스트에서 삭제 해주세요.")
        '        Exit Sub
        '    End If
        '    cbD.Text = Table.Rows(0)(1).ToString()
        '    txtWord.Text = Table.Rows(0)(2).ToString()

        '    If Table.Rows(0)(4).ToString = "-" Then
        '        strPDes = ""
        '    Else
        '        strPDes = Table.Rows(0)(4).ToString
        '    End If

        '    strDes = Table.Rows(0)(3).ToString + vbCrLf + strPDes
        '    strCom = Table.Rows(0)(5).ToString
        '    'strCa = Table.Rows(0)(6).ToString
        '    'strModule = Table.Rows(0)(7).ToString
        '    'strRisk = Table.Rows(0)(8).ToString
        '    'StrTip = Table.Rows(0)(9).ToString
        '    'StrStep = Table.Rows(0)(10).ToString

        '    txtDes.Text = Replace(strDes, Chr(10), Chr(13) & Chr(10))
        '    txtRequester.Text = Replace(strCom, Chr(10), Chr(13) & Chr(10))
        '    'cbCa.Text = Replace(strCa, Chr(10), Chr(13) & Chr(10))
        '    'txtModule.Text = Replace(strModule, Chr(10), Chr(13) & Chr(10))
        '    'txtRisk.Text = Replace(strRisk, Chr(10), Chr(13) & Chr(10))
        '    'txtTip.Text = Replace(StrTip, Chr(10), Chr(13) & Chr(10))
        '    'txtStep.Text = Replace(StrStep, Chr(10), Chr(13) & Chr(10))

        '    Table.Clear()       ' Table에 값이 저장되어있는 것을 초기화 해줌

        'End If
    End Sub

    Private Sub txtDes_Enter(sender As Object, e As EventArgs) Handles txtDes.Enter
        ' 선택 된 Row의 ID를 가져와 저장하는 변수
        Dim rowCount As Integer = DataGridView1.CurrentRow.Index
        If txtDes.Text = DataGridView1.Item(6, rowCount).Value And DataGridView1.Item(5, rowCount).Value = "수정" Then

            Dim vSQL As String
            Dim Table As DataTable = Nothing

            ' 요청DB에 요청한 용어가 있는지 확인하는 쿼리문
            vSQL = "Select [설명], [비고 (Update시 설명 누적] from [" & strSht2 & "] where [용어] = '" & DataGridView1.Item(1, rowCount).Value & "'"

            Try
                DA = New OleDbDataAdapter(vSQL, vConn2)
                DA.Fill(DS, strSht2)
                Table = DS.Tables(strSht2)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

            txtDes.Text = Table.Rows(0).Item(0).ToString + vbCrLf + Table.Rows(0).Item(1).ToString
            Table.Clear()       ' Table에 값이 저장되어있는 것을 초기화 해줌
            lbDesreq.Text = "설명"

        ElseIf txtDes.Text = DataGridView1.Item(6, rowCount).Value Then
            txtDes.Text = ""
            lbDesreq.Text = "설명"
        Else
            Exit Sub
        End If
    End Sub

    Private Sub btnDel_Click(sender As Object, e As EventArgs) Handles btnDel.Click

        ' 선택 된 Row의 ID를 가져와 저장하는 변수
        Dim rowCount As Integer = DataGridView1.CurrentRow.Index

        If MsgBox("선택한 정보를 삭제하시겠습니까?", vbYesNo) = vbNo Then
            Exit Sub
        Else

            Try
                DA = New OleDbDataAdapter("Delete from [" & strSht & "]  WHERE ID= " & DataGridView1.Item(0, rowCount).Value, vConn)
                DA.Fill(DS, strSht)
                MsgBox("정상적으로 삭제되었습니다.")
                Form_Refresh()

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try


            Exit Sub
        End If
    End Sub
    '/////////////////////////////////////////////////////////////////////////////////
    '############################### Manage Tab ######################################
    '/////////////////////////////////////////////////////////////////////////////////
    Private Sub TabPage2_Enter(sender As Object, e As EventArgs) Handles TabPage2.Enter
        If cbDivision.Items.Count = 0 Then
            With cbDivision
                .Items.Add("용어")
                .Items.Add("신기능")
                .Items.Add("총합시험 기획서")
                .Text = cbDivision.Items(0)
            End With
        End If

        With gridDictionary
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            .AllowUserToResizeColumns = True
            .AllowUserToResizeRows = True
            .MultiSelect = False
        End With

        If cbAddComp.Items.Count = 0 Then
            With cbAddComp
                .Items.Add("CNS")
                .Items.Add("엠스텍")
                .Items.Add("인피닉")
                .Text = cbAddComp.Items(0)
            End With
        End If

        txtDivision_T2.ReadOnly = True

        Dictionary_Refresh()

    End Sub

    Public Sub Dictionary_Refresh()
        '###### 데이터그리드뷰 띄어줘 관리/소통 하는 시스템######

        ' 초기화 해주는 코드
        gridDictionary.DataSource = Nothing
        DS_Dictionary.Clear()

        'DB 연결
        Dim XML As New XML
        Try
            Dim vCon As String = Nothing
            ' vcon가져오는 함수
            XML.vCon_Call(vCon)
            ' Connect 연결
            vConn2 = New OleDbConnection(vCon) 'strcont
            vConn2.Open()

            ' vcon가져오는 함수
            XML.vCon_Admin_Call(vCon)
            ' Connect 연결
            vConn = New OleDbConnection(vCon) 'strCont_Admin
            vConn.Open()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "DB Open에러")
            Exit Sub
        End Try

        '용어 DB Query문
        Dim tmpSQL As String = "Select [ID], [대분류], [용어], [설명], [업체 이름] from [" & strSht2 & "] Where [용어] > '' "
        Dim wordSQL As String = tmpSQL & "AND [대분류] = '용어' ORDER BY [ID] ASC"
        Dim newSQL As String = tmpSQL & " AND [대분류] = '신기능' ORDER BY [ID] ASC"
        Dim planSQL As String = tmpSQL & "AND [대분류] = '총합시험 기획서' ORDER BY [ID] ASC"

        Dim SQL As String = Nothing

        If cbDivision.Text = cbDivision.Items(0) Then
            SQL = wordSQL
        ElseIf cbdivision.Text = cbdivision.Items(1) Then
            SQL = newSQL
        ElseIf cbdivision.Text = cbdivision.Items(2) Then
            SQL = planSQL
        End If


        'Request_Dictionary DB Query문
        DA_Dictionary = New OleDbDataAdapter(SQL, vConn2)
        DA_Dictionary.Fill(DS_Dictionary, strSht2)

        Dim Table As DataTable = DS_Dictionary.Tables(strSht2)

        '요청내용 없을 때
        If Table.Rows.Count = 0 Then
            MsgBox("조회할 내용이 없습니다.",, "lee.sunbae@lgepartner.com")
            Exit Sub
        End If

        gridDictionary.DataSource = DS_Dictionary.Tables(strSht2)
        'gridDictionary_Click(sender, e)

    End Sub

    Private Sub btRefresh_Click(sender As Object, e As EventArgs) Handles btRefresh.Click
        Dictionary_Refresh()

    End Sub

    Private Sub cbDivision_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbDivision.SelectedIndexChanged
        Dictionary_Refresh()
        txtDivision_T2.Text = cbDivision.Text
        'Call gridDictionary_Click(sender, e)

    End Sub

    Private Sub gridDictionary_Click(sender As Object, e As EventArgs) Handles gridDictionary.Click

        Dim rowCount As Integer
        If gridDictionary.Rows.Count <> 0 Then
            rowCount = gridDictionary.CurrentRow.Index
            ' 선택 된 Row의 ID를 가져와 저장하는 변수
            ' 각 각 폼에 List Box 및 개체들에게 값을 넣어주기 위함.
            'If IsDBNull(gridDictionary.Item(1, rowCount).Value) = False Then txtDivision_T2.Text = gridDictionary.Item(1, rowCount).Value Else txtDivision_T2.Text = ""
            If IsDBNull(gridDictionary.Item(2, rowCount).Value) = False Then txtWord_T2.Text = gridDictionary.Item(2, rowCount).Value Else txtWord_T2.Text = ""
            If IsDBNull(gridDictionary.Item(3, rowCount).Value) = False Then txtDes_T2.Text = gridDictionary.Item(3, rowCount).Value Else txtDes_T2.Text = ""

            prevWord = gridDictionary.Item(2, rowCount).Value
        End If

    End Sub

    Private Sub btSearch_T2_Click(sender As Object, e As EventArgs) Handles btSearch_T2.Click
        Dim XML As New XML
        Try
            Dim vCon As String = Nothing
            ' vcon가져오는 함수
            XML.vCon_Call(vCon)
            ' Connect 연결
            vConn2 = New OleDbConnection(vCon) 'strcont
            vConn2.Open()

            ' vcon가져오는 함수
            XML.vCon_Admin_Call(vCon)
            ' Connect 연결
            vConn = New OleDbConnection(vCon) 'strCont_Admin
            vConn.Open()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "DB Open에러")
            Exit Sub
        End Try

        Dim tmpSQL As String = Nothing
        Dim wordSQL As String = Nothing
        Dim newSQL As String = Nothing
        Dim planSQL As String = Nothing

        tmpSQL = "Select [ID], [대분류], [용어], [설명], [업체 이름] from [" & strSht2 & "] Where [용어] > '' "
        wordSQL = tmpSQL & "AND [대분류] = '" & txtDivision_T2.Text & "' AND [용어] = '" & txtWord_T2.Text & "'"
        newSQL = tmpSQL & "AND [대분류] = '" & txtDivision_T2.Text & "' And [용어] = '" & txtWord_T2.Text & "'"
        planSQL = tmpSQL & "AND [대분류] = '" & txtDivision_T2.Text & "' AND [용어] = '" & txtWord_T2.Text & "'"

        '검색할 용어가 공백일 경우 예외처리
        If txtWord_T2.Text = "" Then
            MsgBox("검색할 용어를 입력해 주세요")
            Exit Sub
        End If

        '대분류에 따라 다른 쿼리문 작성
        Dim SQL As String = Nothing

        If cbDivision.Text = cbDivision.Items(0) Then
            SQL = wordSQL
        ElseIf cbDivision.Text = cbDivision.Items(1) Then
            SQL = newSQL
        ElseIf cbDivision.Text = cbDivision.Items(2) Then
            SQL = planSQL
        End If

        DA_Search = New OleDbDataAdapter(SQL, vConn2)
        DA_Search.Fill(DS_Search, "Search")

        Dim Table As DataTable = DS_Search.Tables("Search")

        If DS_Search.Tables("Search").Rows.Count = 0 Then
            MsgBox("App과 Feature를 찾을 수 없습니다.")
            Exit Sub
        End If
        gridDictionary.DataSource = DS_Search.Tables("Search")

    End Sub

    Private Sub btModify_Click(sender As Object, e As EventArgs) Handles btModify.Click

        Dim rowCount As Integer = gridDictionary.CurrentRow.Index

        If txtDivision_T2.Text = "" Or txtWord_T2.Text = "" Or txtDes_T2.Text = "" Then
            MsgBox("수정 할 내용의 정보가 입력 되었는지 확인하세요")
            Exit Sub
        Else
            Try
                DS_Dictionary.Tables.Clear()
                DA_Dictionary = New OleDbDataAdapter("UPDATE " & strSht2 & " Set 대분류 = '" & txtDivision_T2.Text & "', 용어 = '" & txtWord_T2.Text & "', 설명 = '" & txtDes_T2.Text & "'" &
                    "WHERE ID = " & gridDictionary.Item(0, rowCount).Value, vConn2)
                DA_Dictionary.Fill(DS_Dictionary, strSht2)
                MsgBox("수정 되었습니다")
                Dictionary_Refresh()

                '수정하기 전 마지막 포커스위치 유지
                gridDictionary.Rows(rowCount).Selected = True
                gridDictionary.CurrentCell = gridDictionary.Rows(rowCount).Cells(0)

                ' History DB 추가
                Dim tmp As String = Nothing
                Dim UserName As String = Nothing

                ' 이름을 받아옴
                For Each v In System.Windows.Forms.Application.OpenForms
                    If v.Name = "Main_Form" Then
                        UserName = v.strUserName
                        Exit For
                    End If
                Next


                ' History DB 추가 Query문

                Dim History As String
                History = "INSERT INTO History_Dictionary (대분류, 용어, 내용, 구분, 담당자, 변경날짜) VALUES ('" & txtDivision_T2.Text & "', '" & prevWord & "', '" & txtWord_T2.Text & " / " & txtDes_T2.Text & "', '" & btModify.Text & "', '" & UserName & "', '" & Now & "');"

                Dim cmd As OleDbCommand = New OleDbCommand(History, vConn)
                Dim DA_History As OleDbDataAdapter = New OleDbDataAdapter(cmd)
                DA_History.Fill(DS_Dictionary)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btAdd.Click
        If txtAddDiv.Text = "" Or txtAddWord.Text = "" Or txtAddDes.Text = "" Then
            MsgBox("추가 할 내용의 정보가 입력 되었는지 확인하세요")
            Exit Sub

        End If

        Dim tmpSQL As String = "INSERT INTO " & strSht2 & " (대분류, 용어, 설명, [업체 이름]) VALUES ('" &
            txtAddDiv.Text & "', '" & txtAddWord.Text & "', '" & txtAddDes.Text & "', '" & cbAddComp.Text & "_" & Now & "');"

        Dim chkDictionary As String = "Select [대분류], [용어], [설명], [업체 이름] From [" & strSht2 & "] " &
            "WHERE [대분류] = '" & txtAddDiv.Text & "' AND [용어] = '" & txtAddWord.Text & "'"

        If MsgBox("대분류 : " & txtAddDiv.Text & vbCrLf & "용어   : " & txtAddWord.Text & vbCrLf & "위 내용을 추가 하시겠습니까?", vbYesNo) = vbNo Then
            Exit Sub
        Else
            DA_Dictionary = New OleDbDataAdapter(chkDictionary, vConn2)
            DA_Dictionary.Fill(DS_Dictionary, "Check_Dictionary")

            Dim chkDictionary_Count As DataTable = DS_Dictionary.Tables("Check_Dictionary")
            If chkDictionary_Count.Rows.Count <> 0 Then
                MsgBox("추가하려는 항목이 이미 존재합니다")
                Exit Sub
            Else

                DA_Dictionary = New OleDbDataAdapter(tmpSQL, vConn2)
                DA_Dictionary.Fill(DS_Dictionary, "Add")

                MsgBox("정상적으로 추가 되었습니다")
                Dictionary_Refresh()

                ' History DB 추가
                Dim tmp As String = Nothing
                Dim UserName As String = Nothing

                ' 이름을 받아옴
                For Each v In System.Windows.Forms.Application.OpenForms
                    If v.Name = "Main_Form" Then
                        UserName = v.strUserName
                        Exit For
                    End If
                Next


                ' History DB 추가 Query문

                Dim History As String
                History = "INSERT INTO History_Dictionary (대분류, 용어, 내용, 구분, 담당자, 변경날짜) VALUES ('" & txtAddDiv.Text & "', '" & txtAddWord.Text & "', '" & txtAddWord.Text & " / " & txtAddDes.Text & "', '" & btAdd.Text & "', '" & UserName & "', '" & Now & "');"

                Dim cmd As OleDbCommand = New OleDbCommand(History, vConn)
                Dim DA_History = New OleDbDataAdapter(cmd)
                DA_History.Fill(DS_Dictionary)
            End If


        End If




    End Sub

    Private Sub btDelete_Click(sender As Object, e As EventArgs) Handles btDelete.Click
        'DB 삭제 Query 문
        Dim rowCount As Integer = gridDictionary.CurrentRow.Index

        If MsgBox("선택한 행의 정보를 정말 삭제하시겠습니까?", vbYesNo) = vbNo Then
            Exit Sub
        Else

            Try
                DA_Dictionary = New OleDbDataAdapter("Delete from " & strSht2 & " WHERE ID = " & gridDictionary.Item(0, rowCount).Value, vConn2)
                DA_Dictionary.Fill(DS_Dictionary)

                MsgBox("정상적으로 삭제되었습니다.")
                Dictionary_Refresh()

                ' History DB 추가
                Dim UserName As String = Nothing

                ' 이름을 받아옴
                For Each v In System.Windows.Forms.Application.OpenForms
                    If v.Name = "Main_Form" Then
                        UserName = v.strUserName
                        Exit For
                    End If
                Next


                ' History DB 추가 Query문

                Dim History As String
                History = "INSERT INTO History_Dictionary (대분류, 용어, 내용, 구분, 담당자, 변경날짜) VALUES ('" & txtAddDiv.Text & "', '" & txtAddWord.Text & "', '" & txtAddWord.Text & " / " & txtAddDes.Text & "', '" & btDelete.Text & "', '" & UserName & "', '" & Now & "');"

                Dim cmd As OleDbCommand = New OleDbCommand(History, vConn)
                Dim DA_History = New OleDbDataAdapter(cmd)
                DA_History.Fill(DS_Dictionary)
            Catch ex As Exception
                MsgBox(ex.Message)

            End Try

        End If
    End Sub
End Class