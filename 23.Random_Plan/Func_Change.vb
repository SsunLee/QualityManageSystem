Imports System.Data
Imports System.Data.OleDb
Imports System.Windows.Forms

Public Class Func_Change
    Public DS As DataSet = New DataSet
    Public DA As OleDbDataAdapter = New OleDbDataAdapter()
    Public strSQL As String
    Public InfoConn As OleDbConnection
    Public vConn As OleDbConnection = New OleDbConnection
    Dim table_Merge As New DataTable("table_Merge")
    Dim index As Integer = 1
    Dim increment As Integer = 0
    Public dtGrid As DataTable = New DataTable()
    Public func_DataGridView_Form As New func_DataGridView_Form
    Public blchk As Boolean

    Public search_Table As DataTable = New DataTable

    Public Table As DataTable = New DataTable
    Public Change_Add_Tree As New Change_Add_Tree


    'Public strCon As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\WorkSpace\01. Work\2018\02. February\0213\QPortalDB.accdb;Jet OLEDB:Database Password = lge1234;"
    Public XML As New XML

    ' Form Load 될 때 
    Private Sub Func_Change_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' -------------------------------------------------------------------------------
        ' 내용 : 처음 기능 변경점 매핑 눌렀을 때 
        '-------------------------------------------------------------------------------
        ' Get Information of Company at My Computer System Name 
        Icon = My.Resources.Qportal_Icon
        blchk = True

        Dim strCNS As String = "Contacts_C"                         ' 업체 
        Dim strINFINIQ As String = "Contacts_I"
        Dim strMSTech As String = "Contacts_M"
        Dim strName As String = Nothing

        Dim getContact As DataSet = New DataSet
        Dim blcp As Boolean = True

        Dim XML As New XML
        Dim vCon As String = Nothing
        Dim vConn As OleDbConnection
        Dim szConC As String = "SELECT * FROM [" + strCNS + "]"
        Dim szConI As String = "SELECT * FROM [" + strINFINIQ + "]"
        Dim szConM As String = "SELECT * FROM [" + strMSTech + "]"

        ' String변수에 테이블명과 쿼리문 순차적으로 담음.
        Dim szQuery As String() = New String() {szConC, szConI, szConM}
        Dim loopSht As String() = New String() {strCNS, strINFINIQ, strMSTech}

        Dim nCnt As Integer = 0

        Try
            'XML.vCon_Call(vCon)
            Dim Change_Add_Tree As New Change_Add_Tree
            vConn = New OleDbConnection(Change_Add_Tree.strCon)

            ' Looping 하여 Data Adapter 실행
            For Each a As String In szQuery
                DA = New OleDbDataAdapter(a, Change_Add_Tree.strCon)
                DA.Fill(getContact, loopSht(nCnt))
                nCnt += 1
            Next

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        'XML = Nothing
        vConn = Nothing

        Dim strComputer As String
        strComputer = "."
        Dim Obj = GetObject("winmgmts:{impersonationLevel=impersonate}!\\" & strComputer & "\root\cimv2").ExecQuery("Select * FROM Win32_OperatingSystem")
        For Each Obj2 In Obj
            strName = Obj2.Description
        Next

        ' 가져온 컴퓨터설명을 Split를 사용하여 만들어진 배열의 의 첫번째 한글이름 만 저장
        strName = Strings.Split(strName, "/")(0)

        '★ 큐포탈 사용자 이름으로 업체명 넣어주기
        'txtTester.Text = strName        ' 일단 이름 받아옴
        For nZ As Integer = 0 To 2       ' 0~2 까지가 업체테이블임
            For nW = 1 To getContact.Tables(nZ).Rows.Count - 1
                If getContact.Tables(nZ).Rows(nW)(2).ToString() = strName Then
                    '0119 CNS는 LG를 붙여야겟어여 죄송
                    If getContact.Tables(nZ).Rows(nW)(4).ToString() = "CNS" Then
                        txt_Comp.Text = "LG " & getContact.Tables(nZ).Rows(nW)(4).ToString()
                    Else
                        txt_Comp.Text = getContact.Tables(nZ).Rows(nW)(4).ToString()
                    End If

                    ' 회사 콤보박스 값 = 테이블에 (nZ)(4) 위치에 업체명 넣어줌.
                    blcp = False  ' Exit For가 한번만 나가면 또 다른 테이블 검색하기 때문에 Chk Boolean
                    Exit For
                End If
            Next
            If blcp = False Then  ' 이미 회사이름을 찾은 경우라면!
                Exit For
            End If
        Next

        '-----------------------------------------------------------
        ' set Default Table
        '-----------------------------------------------------------
        'Dim strcolumns = {"AppName", "Feature", "변경점", "변경점 내용", "Project", "Model", "차수", "사업자", "업체명"}
        'Dim rowPosition As Integer = DataGridView1.Rows.Count

        'For Each a As String In strcolumns
        '    dtGrid.Columns.Add(New DataColumn(a))
        'Next

        'DataGridView1.DataSource = dtGrid
        Dim dCol As DataColumn = New DataColumn()
        Dim strColumns As String() = New String() _
       {"AppName", "Feature", "변경점", "변경점 내용", "Project", "Model", "차수", "사업자", "업체명"}

        For Each a As String In strColumns
            dCol = New DataColumn()
            dCol.DataType = System.Type.GetType("System.String")
            dCol.ColumnName = a
            dtGrid.Columns.Add(dCol)
        Next


    End Sub
    ' 변경점이 정리 된 항목을 DB처럼 가져와서 Tree View에 뿌려주는 작업
    Private Sub btn_Search_Click(sender As Object, e As EventArgs) Handles btn_Search.Click
        Dim Change_Add_Tree As New Change_Add_Tree
        ' -------------------------------------------------------------------------------
        ' 제작 : 이순배
        ' 날짜 : 2018-01-31
        ' 내용 : 엑셀에 있는 모델 및 변경점 정보를 가져와서 뿌리는 거
        '-------------------------------------------------------------------------------
        Dim vSQLPro As String = Nothing
        Dim vSQLMod As String = Nothing
        Dim vCon As String = Nothing
        Dim xml As New XML


        ' 빈 항목이면 조건에 들어가지 않도록
        vSQLPro = IIf(txt_Project.Text = "", "", "AND [Project] = '" & Replace(txt_Project.Text, "'", "''") & "'")
        vSQLMod = IIf(txt_model.Text = "", "", "AND [Model] = '" & Replace(txt_model.Text, "'", "''") & "'")

        Dim sql As String = Nothing
        Dim sht As String = "SW_Validation"

        ' SQL QUERY 작성   // 검색한 결과에 맞게 내용 가져와서 Type 에다가 자료 넣어줌
        sql = "SELECT * "
        sql = sql & "FROM [" & sht & "] "
        sql = sql & "WHERE ID > 0 And Project is not null " & vSQLPro & vSQLMod


        xml.vCon_Call(vCon) ' xml에서 Connection String 가져옴

        vConn = New OleDbConnection(Change_Add_Tree.strCon)   '// OledbConnection 사용하기 위해 선언 (Connection String 기준으로


        DA = New OleDbDataAdapter(sql, vConn)   '// DataAdapter qsl Query문 기준으로 
        DA.Fill(DS, sht)


        Dim sSQL = "SELECT * FROM [" & "AppList" & "] as m Where ID > 0 "
        DA = New OleDbDataAdapter(sSQL, vConn)   '// DataAdapter qsl Query문 기준으로 
        DA.Fill(DS, "App_List")

        Dim modTable As DataTable = New DataTable
        modTable = DS.Tables(0)
        Dim aTable As DataTable = DS.Tables(1)

        'Tree View에 App만 보여주기
        Call BuildTree_Multi(aTable, treeView_App, 1, 2, expandAll:=False)


        If modTable.Rows.Count = 0 Then
            MessageBox.Show("조회 된 결과가 없습니다.")
        Else


            TreeView1.Nodes.Clear()
            makeRegion(modTable, 14, 15, 20, TreeView1)
            TreeView1.Sort()


        End If





        'Try
        '    'Dim strExcel As String = "Provider=Microsoft.Ace.OLEDB.12.0;Data Source=" & szFullPath & ";Extended Properties=""Excel 12.0;HDR=YES;"""
        '    'Dim strSht As String = "기능변경점_DB"
        '    Dim strSht As String = "SW_Validation"
        '    Dim vCon As String = Nothing
        '    XML.vCon_Call(vCon)
        '    'vConn = New OleDbConnection(vCon)
        '    Dim Change_Add_Tree As New Change_Add_Tree

        '    InfoConn = New OleDbConnection(Change_Add_Tree.strCon)

        '    '#### 쿼리 작성 #########################################################
        '    Dim szModel As String = Nothing
        '    Dim szPro As String = Nothing
        '    'Dim szStep As String = Nothing
        '    'Dim szSuffix As String = Nothing


        '    ' 비어있는 항목이면  포함 하도록
        '    szPro = IIf(szPro = "", "", "AND [Project] LIKE '%" & Replace(txt_Project.Text, "'", "''") & "%'")
        '    szModel = IIf(szModel = "", "", "AND [Model] LIKE '%" & Replace(txt_model.Text, "'", "''") & "%'")

        '    Dim vSQL As String = "SELECT [Project], [Model], [Step], [Suffix], [Type], [분류], [연관기능], [상세내용], [Risk] " & " "
        '    vSQL = vSQL + "FROM [" & strSht & "] as m" & " Where ID > 0 And Project <> '' And Model <> '' " & szModel & szPro


        '    Dim sSQL = "SELECT * FROM [" & "AppList" & "] as m Where ID > 0 "

        '    DA = New OleDbDataAdapter(vSQL, InfoConn)
        '    DA.Fill(DS, strSht)

        '    DA = New OleDbDataAdapter(sSQL, InfoConn)
        '    DA.Fill(DS, "App_List")

        '    search_Table = DS.Tables(0)
        '    Dim aTable As DataTable = DS.Tables(1)

        '    'Tree View에 모델 프로젝트
        '    Call BuildTree_Multi(search_Table, TreeView1, 0, 1, expandAll:=False)

        '    'Tree View에 App만 보여주기
        '    Call BuildTree_Multi(aTable, treeView_App, 1, 2, expandAll:=False)

        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try
    End Sub
    Public strOne As String = Nothing
    Public strTwo As String = Nothing
    Public strThree As String = Nothing



    Private Sub trvType_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles trvType.AfterSelect
        '-----------------------------------------------------
        '내 용 :  변경점 부분 선택 시 설명 보여주는 부분
        '-----------------------------------------------------

        Dim stemp As String = trvType.SelectedNode.FullPath
        Dim var() As String = Split(stemp, "\")


        Select Case var.Length
            Case 3
                strOne = var(0)     ' Type
                strTwo = var(1)     ' 분류
                strThree = var(2)   ' 연관기능

                ' DataGridView에 뿌려주기 위해 합침.
                txt_Selected_Node.Text = strOne & "_" & strTwo & "_" & strThree


                For i As Integer = 0 To Table.Rows.Count - 1
                    If strOne = Table.Rows(i)(1).ToString() And strTwo = Table.Rows(i)(2).ToString() And strThree = Table.Rows(i)(3).ToString() Then
                        Dim strText As String = LTrim(Table.Rows(i)(4).ToString())
                        Dim strText_Risk As String = LTrim(Table.Rows(i)(5).ToString())

                        txt_Change_result.Text = Replace(strText, Chr(10), Chr(13) & Chr(10))
                        txtRisk.Text = Replace(strText_Risk, Chr(10), Chr(13) & Chr(10))

                    End If
                Next

        End Select

    End Sub


    Private Sub treeView_App_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles treeView_App.MouseDoubleClick
        '--------------------------------------------------------------------------
        '내용 :  App List 더블 클릭 시 DataGridView에 내용 채워지는 코드
        '--------------------------------------------------------------------------
        If txt_step_in.Text = "" Or txt_suffix_in.Text = "" Or txt_model_in.Text = "" Then
            MsgBox("모델, 차수 와 사업자를 입력 후 다시 시도 해주세요.")
            Exit Sub
        End If

        '------------------------------------------------------
        ' Check Duplication items using loop
        '------------------------------------------------------
        Try
            Dim sTemp As String = treeView_App.SelectedNode.FullPath    ' FullPath는 선택한 노드를 경로처럼 보여줌 ex) LG\Camera
            Dim var() As String = Split(sTemp, "\")                     ' \ 기준으로 Split 하여 문자열 배열에 담아줌
            Dim node_First As String = Nothing                           ' 최 상위 
            Dim node_Second As String = Nothing                 ' 선택한 거

            ' Node 선택 더블 클릭 했을 때 
            ' 맨 위에꺼 누른건지 
            ' 아래거 눌렀는지 파악
            Select Case var.Length
                Case 1  ' 최상위 눌렀으면 완전 다 누른거 아니니 Exit
                    node_First = var(0)
                    Exit Sub
                Case 2
                    node_First = var(0)
                    node_Second = var(1)
            End Select

            Dim strApp As String = Nothing

            ' 만약 선택 한 앱이 사업자별 앱이면 ex) U+_UBox
            Select Case node_First
                Case "KT", "SKT", "U+"
                    strApp = node_First & "_" & node_Second
                Case "LG"
                    strApp = node_Second
                Case Else
                    strApp = node_Second
            End Select


            Dim strFeature As String = "기능_" & txt_step_in.Text
            Dim strChange As String = txt_Selected_Node.Text
            Dim strChange_Result As String = txt_Change_result.Text
            Dim strProject As String = txt_pro_in.Text
            Dim strModel As String = txt_model_in.Text
            Dim strStep As String = txt_step_in.Text
            Dim strSuffix As String = txt_suffix_in.Text
            Dim strComp As String = txt_Comp.Text

            Dim strSum As String = strApp & strFeature & strChange & strProject & strModel & strStep & strSuffix & strComp

            Dim strCheck As String
            dtGrid.AcceptChanges() ' Refresh the data Table

            Dim dtCompare_table As New DataTable()
            dtCompare_table = TryCast(func_DataGridView_Form.DataGridView1.DataSource, DataTable)
            Dim blTrue As Boolean
            If Not IsNothing(dtCompare_table) Then
                ' Check Duplicate DataTable Rows
                For Each dtRow As DataRow In dtCompare_table.Rows
                    blTrue = False
                    strCheck = dtRow("AppName") & dtRow("Feature") & dtRow("변경점") & dtRow("Project") & dtRow("Model") & dtRow("차수") & dtRow("사업자") & dtRow("업체명")
                    If strSum = strCheck Then
                        'is it dupl
                        MessageBox.Show("이미 추가 된 항목 입니다.")
                        Exit Sub
                    End If
                Next

            End If

            Dim rowValues(8) As Object

            rowValues(0) = strApp                   ' App Name
            rowValues(1) = strFeature               ' Feautre ex) 기능_VP01
            rowValues(2) = strChange               ' 변경점 
            rowValues(3) = strChange_Result      ' 변경점 내용
            rowValues(4) = strProject                ' Project
            rowValues(5) = strModel                ' Model
            rowValues(6) = strStep                  ' Step
            rowValues(7) = strSuffix                 ' Suffix
            rowValues(8) = strComp                ' Company

            Dim dRow As DataRow
            dRow = dtGrid.Rows.Add(rowValues)   ' DataGridView에 넣을 Vutural DataTable 생성
            dtGrid.AcceptChanges()                    ' Datatable Update & Refresh

            func_DataGridView_Form.DataGridView1.DataSource = dtGrid    ' func_DataGridView_Form에 있는 DataGridView에 DataSource 넣어줌.
            func_DataGridView_Form.Show()

            MessageBox.Show("추가 됨")
            If blchk = True Then
                func_DataGridView_Form.Show()   ' DataGridView가 있는 Form 보여주기
                blchk = False
            Else
                ' func_DataGridView_Form.Visible = False   ' 처음에만 켜질 수 있도록 하고 그 이후에는 Visible Option만 
            End If

        Catch ex As Exception
            MsgBox("변경점 세부 항목을 선택해주세요.",, "lee.sunbae@lgepartner.com")

        End Try





    End Sub

    '해당 노드가 있는지 확인 함
    Private Function Searchnode_third(ByVal nodetext As String, ByVal node As TreeNode) As TreeNode
        For Each keyNode As TreeNode In node.Nodes
            If keyNode.Text = nodetext Then
                '일치하는 노드가 있을 시 반환
                Return keyNode
            End If
        Next
    End Function

    ' DataGrid View to Access Database 
    Sub InsertData(sender As Object, e As EventArgs) Handles Button1.Click
        ' -------------------------------------------------------------------------------
        ' 내용 : 선택 한 항목들을 DataGridView Form으로 보내는 것
        '-------------------------------------------------------------------------------

        func_DataGridView_Form.Visible = True


    End Sub
    Function SQLText(ByVal ST As String) As String
        SQLText = "'" & Replace(ST, "'", "''") & "'"
    End Function

    Private Sub treeView_App_AfterSelect(sender As Object, e As TreeViewEventArgs)

    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint

    End Sub

    Private Sub Func_Change_copy_Closed(sender As Object, e As EventArgs) Handles Me.Closed

        ' Form이 꺼질 때 다시 띄워줌
        Dim new_Plan As New New_RandomPlan_Page
        new_Plan.Show()



    End Sub

    Private Sub TreeView1_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles TreeView1.AfterSelect
        '----------------------------------------------------------------------------------
        ' 내 용 :  모델명 클릭 했을 때
        '----------------------------------------------------------------------------------

        trvType.Nodes.Clear()
        Table.Clear()
        txt_Change_result.Text = ""
        txtRisk.Text = ""


        Dim stemp As String = TreeView1.SelectedNode.FullPath
        Dim var() As String = Split(stemp, "\")

        Dim strProject As String = Nothing
        Dim strModel As String = Nothing

        Dim vSQLPro As String = Nothing
        Dim vSQLCom As String = Nothing
        Dim strCommon As String = Nothing

        Try
            Select Case var.Length
                Case 2
                    strProject = var(0)
                    strCommon = "Project"

                        vSQLPro = "AND [Project] = '" & Replace(strProject, "'", "''") & "'"
                        vSQLCom = " AND [공통] = '" & Replace(strCommon, "'", "''") & "'"

                        Dim sql As String = Nothing
                        Dim sht As String = "SW_Validation"

                        ' SQL QUERY 작성   // 검색한 결과에 맞게 내용 가져와서 Type 에다가 자료 넣어줌
                        sql = "SELECT * "
                        sql = sql & "FROM [" & sht & "] "
                        sql = sql & "WHERE ID > 0 " & vSQLPro & vSQLCom

                        Dim vCon As String = Nothing
                        Dim xml As New XML

                        xml.vCon_Call(vCon) ' xml에서 Connection String 가져옴

                        'vConn = New OleDbConnection(vCon)   '// OledbConnection 사용하기 위해 선언 (Connection String 기준으로
                        vConn = New OleDbConnection(Change_Add_Tree.strCon)   '// OledbConnection 사용하기 위해 선언 (Connection String 기준으로

                        'Dim Table As DataTable = New DataTable
                        Dim cmd As OleDbCommand = New OleDbCommand(sql, vConn)
                        '     ▼▼ Data Adapter를 사용해 Data Table을 만들고 Query 된 Result를 Count 하여 기존 Data가 있는지 Check 
                        Dim adapter As OleDbDataAdapter = New OleDbDataAdapter(cmd)
                        adapter.Fill(Table)

                        Call builed_Treenode(Table, trvType, 1, 2, 3)



            End Select
        Catch ex As Exception
            'MessageBox.Show("하위 항목을 선택 해주세요")
        End Try


    End Sub




    Public Sub BuildTree_Multi(ByVal dt As DataTable, ByVal trv As TreeView, ByVal nodeNum As Integer, ByVal subNodeNum As Integer, ByVal expandAll As [Boolean])
        ' Clear the TreeView if there are another datas in this TreeView
        trv.Nodes.Clear()
        Dim node As TreeNode
        Dim subNode As TreeNode
        'Dim trdNode As TreeNode

        For Each row As DataRow In dt.Rows
            'search in the treeview if any country is already present
            node = Searchnode(row.Item(nodeNum).ToString(), trv)
            If node IsNot Nothing Then

                '☆☆ Searchnode_Sub 사용해야함. 그래야 서브노드 중복확인
                subNode = Searchnode_sub(row.Item(subNodeNum).ToString(), node)

                If subNode IsNot Nothing Then

                Else
                    '노트 추가할때 New로 생성해야 함 .. 기존은 Searchnode_sub 함수사용한 윗라인에 있었음
                    subNode = New TreeNode(row.Item(subNodeNum).ToString())
                    node.Nodes.Add(subNode) '기존에 있는 값이면
                End If
            Else    ' 완전 새로 
                node = New TreeNode(row.Item(nodeNum).ToString())
                subNode = New TreeNode(row.Item(subNodeNum).ToString())
                node.Nodes.Add(subNode)
                trv.Nodes.Add(node)
            End If
        Next
        If expandAll Then
            trv.ExpandAll()              ' Expand the TreeView
        End If
    End Sub

    '해당 노드가 있는지 확인 함
    Private Function Searchnode(ByVal nodetext As String, ByVal trv As TreeView) As TreeNode
        For Each node As TreeNode In trv.Nodes
            If node.Text = nodetext Then
                Return node
            End If
        Next
    End Function
    '해당 노드가 있는지 확인 함
    Private Function Searchnode_sub(ByVal nodetext As String, ByVal node As TreeNode) As TreeNode
        For Each keyNode As TreeNode In node.Nodes
            If keyNode.Text = nodetext Then
                '일치하는 노드가 있을 시 반환
                Return keyNode
            End If
        Next
    End Function

    Private Sub txt_model_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_model.KeyPress, txt_Project.KeyPress
        If e.KeyChar = Convert.ToChar(13) Then  ' ToChar <-- 13번 값은 Enter 임.
            Call btn_Search_Click(sender, e)   ' 다른 프로시져 호출
        End If
    End Sub
    Public Sub builed_Treenode(ByVal dt As DataTable, ByVal trv As TreeView, ByVal dataOne As Integer, ByVal dataTwo As Integer, ByVal dataThree As Integer)
        '----------------------------------------------
        ' 내 용 : Tree View 3개일 때 2개 일 때 
        '----------------------------------------------

        trv.Nodes.Clear()
        Dim node As TreeNode
        Dim TwoNode As TreeNode
        Dim ThreeNode As TreeNode


        Select Case dataThree
            Case 0  ' 0 이면 두 개 추가할 때
                For Each row As DataRow In dt.Rows

                    node = Searchnode(row.Item(dataOne).ToString(), trv)
                    If node IsNot Nothing Then  ' 노드가 이미 있으면 덮어쓰기 해야 함
                        TwoNode = Searchnode_sub(row.Item(dataTwo).ToString(), node)    ' 이미 있는 노드에 추가로 붙이려면 중복 안된 거를 붙여야 함
                        If TwoNode Is Nothing Then
                            TwoNode = New TreeNode(row.Item(dataTwo).ToString())        ' level 2
                            node.Nodes.Add(TwoNode)                                     ' level 2에다가 level 3 붙임
                        End If

                    Else                        ' 노드가 없으면 
                        node = New TreeNode(row.Item(dataOne).ToString())           ' level 1
                        TwoNode = New TreeNode(row.Item(dataTwo).ToString())        ' level 2

                        ' level 2에다가 level 3 붙임
                        node.Nodes.Add(TwoNode)                                     ' level 1에다가 level 2 붙임
                        trv.Nodes.Add(node)                                         ' level 1 추가

                    End If

                Next

            Case Else   ' 3개 일 때 

                For Each row As DataRow In dt.Rows

                    node = Searchnode(row.Item(dataOne).ToString(), trv)
                    If node IsNot Nothing Then  ' 노드가 이미 있으면 덮어쓰기 해야 함
                        TwoNode = Searchnode_sub(row.Item(dataTwo).ToString(), node)    ' 이미 있는 노드에 추가로 붙이려면 중복 안된 거를 붙여야 함
                        If TwoNode Is Nothing Then
                            TwoNode = New TreeNode(row.Item(dataTwo).ToString())        ' level 2
                            node.Nodes.Add(TwoNode)                                     ' level 2에다가 level 3 붙임
                        End If

                        ThreeNode = Searchnode_third(row.Item(dataThree).ToString(), TwoNode)
                        If ThreeNode Is Nothing Then
                            ThreeNode = New TreeNode(row.Item(dataThree).ToString())        ' level 3
                            TwoNode.Nodes.Add(ThreeNode)
                        End If

                    Else                        ' 노드가 없으면 
                        node = New TreeNode(row.Item(dataOne).ToString())           ' level 1
                        TwoNode = New TreeNode(row.Item(dataTwo).ToString())        ' level 2
                        ThreeNode = New TreeNode(row.Item(dataThree).ToString())    ' level 3

                        TwoNode.Nodes.Add(ThreeNode)                                ' level 2에다가 level 3 붙임
                        node.Nodes.Add(TwoNode)                                     ' level 1에다가 level 2 붙임
                        trv.Nodes.Add(node)                                         ' level 1 추가

                    End If

                Next

        End Select

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        func_DataGridView_Form.Visible = True
    End Sub


    Public Sub makeRegion(ByRef modTable As DataTable, ByRef intProNum As Integer, ByRef intModNum As Integer, ByRef intRegionNum As Integer, ByRef trvInfo As TreeView)
        Dim TwoNode As TreeNode
        Dim ThreeNode As TreeNode
        Dim node As TreeNode

        trvInfo.Nodes.Clear()

        For i As Integer = 0 To modTable.Rows.Count - 1                             ' 검색 된 DB 전체를 반복

            node = Searchnode(modTable.Rows(i)(intProNum).ToString(), trvInfo)  ' 1 Level 프로젝트를 검색 기존에 없다면? 새로 추가해주고 / 기존에 있는 거면 밑에 항목 추가함.

            If node IsNot Nothing Then    'EMMA_OOS 위치 해 있는 상태
                'Two를 추가 해주어야 함.

                If modTable.Rows(i)(intRegionNum).ToString() <> "Project" And modTable.Rows(i)(intRegionNum).ToString() <> "Model" Then     ' Region에 해당하는 항목 이면 ( Region은 실제 유럽, 북미 이런식으로 들어가있어서 찾기위해 이렇게 조건을 줌)
                    TwoNode = Searchnode_sub("Region", node)
                ElseIf modTable.Rows(i)(intRegionNum).ToString() = "Project" Then       ' 만약 Project 라고 쓰여있다면 검색어를 Common으로 바꾸어주어 검색함
                    TwoNode = Searchnode_sub("Common", node)
                Else
                    TwoNode = Searchnode_sub(modTable.Rows(i)(intRegionNum), node)      ' 위에 조건이 아닐 경우에는 그냥 Model이기 때문에 Model <-- 이 항목이 있는지 체크
                End If

                If TwoNode IsNot Nothing Then       ' 위에 여러 조건중에 하나를 타서 들어왔겠고  마찬가지로 트리뷰에 Region 하위항목,  Model 하위 항목이 있는지 체크 후 추가해줌
                    ' Common 위치 해 있는 상태
                    If modTable.Rows(i)(intRegionNum).ToString() = "Model" Then                     ' db가 모델로 되어있다면 하위 항목에 모델을 추가 하기위해 검색
                        ThreeNode = Searchnode_third(modTable.Rows(i)(intModNum), TwoNode)

                        If ThreeNode Is Nothing Then    ' 검색 결과가 없으면 추가 / 있다면 이미 그 모델명이 추가되어있을 테니까
                            ThreeNode = New TreeNode(modTable.Rows(i)(intModNum).ToString())
                            TwoNode.Nodes.Add(ThreeNode)
                        End If

                    ElseIf modTable.Rows(i)(intRegionNum).ToString() <> "Project" And modTable.Rows(i)(intRegionNum).ToString() <> "Model" Then ' Region이라고 되어있는 놈의 하위항목 중복체크
                        ThreeNode = Searchnode_third(modTable.Rows(i)(intRegionNum), TwoNode)

                        If ThreeNode Is Nothing Then                ' 검색 결과가 없으면 추가 / 있다면 유럽, 북미 이런애가 이미 중복으로 들어가 있었을 테니
                            ThreeNode = New TreeNode(modTable.Rows(i)(intRegionNum).ToString())
                            TwoNode.Nodes.Add(ThreeNode)
                        End If

                    End If

                Else ' 기존에 Common과 다른 게 있으면 트리에 추가
                    If modTable.Rows(i)(intRegionNum).ToString() = "Project" Then
                        TwoNode = New TreeNode("Common")
                    ElseIf modTable.Rows(i)(intRegionNum).ToString() <> "Project" And modTable.Rows(i)(intRegionNum).ToString() <> "Model" Then
                        TwoNode = New TreeNode("Region")
                        ThreeNode = New TreeNode(modTable.Rows(i)(intRegionNum).ToString())
                        TwoNode.Nodes.Add(ThreeNode)
                    Else
                        TwoNode = New TreeNode(modTable.Rows(i)(intRegionNum).ToString())
                        ThreeNode = New TreeNode(modTable.Rows(i)(intModNum).ToString())
                        TwoNode.Nodes.Add(ThreeNode)
                    End If

                    node.Nodes.Add(TwoNode)

                End If

            Else
                ' 처음 추가하는 Project명 이라면
                node = New TreeNode(modTable.Rows(i)(intProNum))    ' Project ex) EMMA_OOS
                If modTable.Rows(i)(intRegionNum).ToString() = "Project" Then
                    TwoNode = New TreeNode("Common")
                ElseIf modTable.Rows(i)(3).ToString() <> "Project" And modTable.Rows(i)(intRegionNum).ToString() <> "Model" Then
                    TwoNode = New TreeNode("Region")
                    ThreeNode = New TreeNode(modTable.Rows(i)(intRegionNum).ToString())
                    TwoNode.Nodes.Add(ThreeNode)
                Else
                    TwoNode = New TreeNode(modTable.Rows(i)(intRegionNum).ToString())
                    ThreeNode = New TreeNode(modTable.Rows(i)(intModNum).ToString())
                    TwoNode.Nodes.Add(ThreeNode)
                End If


                node.Nodes.Add(TwoNode)
                trvInfo.Nodes.Add(node)


            End If


        Next
    End Sub

    Private Sub treeView_App_AfterSelect_1(sender As Object, e As TreeViewEventArgs) Handles treeView_App.AfterSelect

    End Sub
End Class