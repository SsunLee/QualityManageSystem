Imports System.Collections.Generic
Imports System.Data
Imports System.Data.OleDb
Imports System.Drawing
Imports System.IO
Imports System.Windows.Forms

Public Class Change
    Public DS As DataSet = New DataSet '맨처음 Load할 때 TipsDB 내용 저장하는 DataSet
    Private blchk As Boolean = False '파일 존재 유무 확인 변수

    Private vConn As OleDbConnection 'Connection 연결을 위한 변수

    Private Table_Select As DataTable
    Private Table_AppNext As DataTable
    Private Table_ActionNext As DataTable
    Private dt_select As DataTable
    Private dt_search As DataTable
    '  Private Table_Tip As DataTable
    Private strFile As String = "검계DB"
    Private strSht As String = "Sheet1" '  Table명을 저장하는 변수

    Public strApp As String = "TD_NEXT_AF_Des"                    ' DB 테이블명 지정
    Public strAction As String = "TD_NEXT_Action"                    ' DB 테이블명 지정
    Public strRisk As String = Nothing
    'Public ChangeAddTree As Change_Add '= New Change_Add
    Public ChangeAddTree As Change_Add_Tree '= New Change_Add
    Public strPjt As String = Nothing
    Public strModel As String = Nothing
    Public strChasu As String = Nothing
    Public strCom As String = Nothing
    Public strCompany As String = Nothing

    Public dtGrid As DataTable = New DataTable

    Public szProject As String
    Public szModel As String
    Public szStep As String
    Public szSuffix As String
    Public szComp As String
    Public szUserName As String

    Public valProject As String
    Public valModel As String
    Public valStep As String
    Public valSuffix As String
    Public valComp As String



    Public chkcol As Integer

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        '------------------------------------------------
        ' 제 작 : 이순배
        ' 내 용 : 검증방법 작성 하기 버튼 클릭 시 
        '------------------------------------------------
        '------------------------------------------------
        ' 제 작 : 이순배
        ' 내 용 : 프로젝트 / 모델 / 차수 넘기기 
        '------------------------------------------------
        Dim tmpStr() As String

        If lstSuf.SelectedItem Is Nothing Or lstComp.SelectedItem Is Nothing Then
            MsgBox("사업자 또는 업체명을 선택하지 않았습니다. 확인 후 재시도 해주세요") : Exit Sub
        End If

        tmpStr = Split(trv1.SelectedNode.FullPath, "\")
        If tmpStr.length <> 3 Then
            MsgBox("Project를 차수까지 선택 해주세요")
            Exit Sub
        End If

        valProject = tmpStr(0)
        valModel = tmpStr(1)
        valStep = tmpStr(2)
        valSuffix = lstSuf.SelectedItem

        szComp = txtComp.Text
        szUserName = laUserName.Text

        Dim Change_Add_Tree As New Change_Add_Tree
        Change_Add_Tree.txtPro_in.Text = valProject
        Change_Add_Tree.txtMod_in.Text = valModel
        Change_Add_Tree.txtStep_in.Text = valStep
        Change_Add_Tree.txtSuffix_in.Text = valSuffix
        Change_Add_Tree.txtComp_in.Text = szComp


        Change_Add_Tree.Show()
        Hide()



    End Sub

    Private Sub Change_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '------------------------------------------------
        ' 제 작 : 이순배
        ' 내 용 : 처음 불러올 때 이름, 회사명 가져오기
        '------------------------------------------------
        'Icon = Me.Resources.Qportal_Icon
        Button2.Enabled = False
        Button2.BackColor = Color.FromArgb(229, 229, 229)

        Dim strCNS As String = "Contacts_C"                         ' 업체 
        Dim strINFINIQ As String = "Contacts_I"
        Dim strMSTech As String = "Contacts_M"
        Dim strName As String = Nothing

        Dim getContact As DataSet = New DataSet
        Dim blcp As Boolean = True

        Dim XML As New XML
        'Dim vCon As String = Nothing
        Dim vConn As OleDbConnection
        Dim szConC As String = "SELECT * FROM [" + strCNS + "]"
        Dim szConI As String = "SELECT * FROM [" + strINFINIQ + "]"
        Dim szConM As String = "SELECT * FROM [" + strMSTech + "]"

        ' String변수에 테이블명과 쿼리문 순차적으로 담음.
        Dim szQuery As String() = New String() {szConC, szConI, szConM}
        Dim loopSht As String() = New String() {strCNS, strINFINIQ, strMSTech}
        Dim nCnt As Integer = 0
        Dim vcon As String = Nothing

        Try

            XML.vCon_Call(vcon)
            Dim Change_Add_Tree As New Change_Add_Tree
            Dim DA As OleDbDataAdapter = New OleDbDataAdapter
            vConn = New OleDbConnection(Change_Add_Tree.strCon)   ' MainForm의 Connection String으로 DB Connect

            ' Looping 하여 Data Adapter 실행
            For Each a As String In szQuery
                Dim cmd As OleDbCommand = New OleDbCommand(a, vConn)
                Dim adapter As OleDbDataAdapter = New OleDbDataAdapter(cmd)

                adapter.Fill(getContact, loopSht(nCnt))
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
        laUserName.Text = strName

        '★ 큐포탈 사용자 이름으로 업체명 넣어주기
        'txtTester.Text = strName        ' 일단 이름 받아옴
        For nZ As Integer = 0 To 2      ' 0~2 까지가 업체테이블임
            For nW = 1 To getContact.Tables(nZ).Rows.Count - 1
                If getContact.Tables(nZ).Rows(nW)(2).ToString() = strName Then
                    '0119 CNS는 LG를 붙여야겟어여 죄송
                    If getContact.Tables(nZ).Rows(nW)(4).ToString() = "CNS" Then
                        txtComp.Text = "LG " & getContact.Tables(nZ).Rows(nW)(4).ToString()
                    Else
                        txtComp.Text = getContact.Tables(nZ).Rows(nW)(4).ToString()
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

        Dim strcolumns = {"Project", "Model", "차수", "사업자", "업체명"}        ' Data Grid View에 들어갈 Column명 지정

        Try
            'For each문으로 배열을 만복하여 Data Table을 생성
            For Each a As String In strcolumns
                dtGrid.Columns.Add(New DataColumn(a))
            Next

            '만들어진 DataTable로 Binding
            dgv_info.DataSource = dtGrid


        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try



    End Sub

    Private Sub btn_Search_Click(sender As Object, e As EventArgs) Handles btn_Search.Click
        '------------------------------------------------
        ' 제 작 : 이순배
        ' 내 용 : 검색 했을 때 DataGridView에 뿌려주기
        '------------------------------------------------
        Dim Change_Add_Tree As New Change_Add_Tree
        vConn = New OleDbConnection(Change_Add_Tree.strCon)
        vConn.Open()

        Dim sql As String = Nothing
        Dim vSQL_pro As String = Nothing
        Dim vSQL_Mod As String = Nothing
        Dim vSQL_Step As String = Nothing

        IIf(txtPro.Text = "", vSQL_pro = " AND [Project] LIKE '%" & Replace(txtPro.Text, "'", "''") & "%'", vSQL_pro = "")
        IIf(txtMod.Text = "", vSQL_Mod = " AND [Model] LIKE '%" & Replace(txtPro.Text, "'", "''") & "%'", vSQL_Mod = "")
        IIf(txtStep.Text = "", vSQL_Step = " AND [차수] LIKE '%" & Replace(txtPro.Text, "'", "''") & "%'", vSQL_Step = "")

        sql = "SELECT Project, Model, 차수, 사업자, 업체명 "
        sql = sql & "FROM 검계_DB "
        sql = sql & "WHERE ID > 0 " & vSQL_pro & vSQL_Mod & vSQL_Step _
        & " GROUP BY Project, Model, 차수, 사업자, 업체명 ORDER BY Model" 'DATA 중복제거


        Dim result As DataTable = New DataTable
        Dim cmd As OleDbCommand = New OleDbCommand(sql, vConn)
        '     ▼▼ Data Adapter를 사용해 Data Table을 만들고 Query 된 Result를 Count 하여 기존 Data가 있는지 Check 
        Dim adapter As OleDbDataAdapter = New OleDbDataAdapter(cmd)
        adapter.Fill(result)

        ' Datatable 중복제거 
        Dim dt_new As DataTable = New DataTable
        '{"Project", "Model", "차수", "사업자", "업체명"}  
        dt_new = result.DefaultView.ToTable(True, "Project", "Model", "차수", "사업자", "업체명")
        'dt_new = result.DefaultView.ToTable()
        dgv_info.DataSource = dt_new


        Button2.Enabled = True
        Button2.BackColor = Color.White

        'Dim test As Object = dt_new.Rows(0)

        'For i As Integer = 0 To dt_new.Columns.Count - 1
        '    SearchTheTreeView(trv1, test(i))
        'Next
        If trv2.Nodes.Count = 0 Then

            SearchTheTreeView(trv2, dt_new)

        End If


        If trv1.Nodes.Count = 0 Then

            Dim dt_table As DataTable = dt_new
            Call BuildTree(dt_table, trv1, expandAll:=False)
            trv1.Sort()

        End If

    End Sub
    Private Function SearchTheTreeView(ByVal TV As TreeView, ByVal DT As DataTable) As TreeNode
        '  Empty previous
        'NodesThatMatch.Clear()

        TV.Nodes.Clear()
        Dim node As TreeNode
        Dim subnode As TreeNode
        Dim trdnode As TreeNode

        'TreeView 출력할 DataTable 지정
        For Each row As DataRow In DT.Rows

            ' 최상단 노드가 존재하는지 유무 확인---------
            node = Searchnode(row.Item(0).ToString, TV)
            '--------------------------------------------

            subnode = New TreeNode(row.Item(1))
            trdnode = New TreeNode(row.Item(2))

            '동일한 최상단 노드가 없을 경우
            If node Is Nothing Then

                node = New TreeNode(row.Item(0))

                TV.Nodes.Add(node)
                node.Nodes.Add(subnode)
                subnode.Nodes.Add(trdnode)


            Else '동일한 최상단 노드가 있을 경우

                Dim chksubnode As Boolean = False
                Dim chktrdnode As Boolean = False

                '다음 레벨의 동일노드 확인
                For Each chksub In node.Nodes

                    '동일한 노드가 있다면
                    If chksub.text = subnode.Text Then
                        chksubnode = True
                    End If

                    '그다음 노드 동일한지 확인s
                    For Each chktrd In subnode.Nodes

                        If chktrd.text = trdnode.Text Then
                            chktrdnode = True
                            Exit For
                        End If

                    Next

                Next
                If chksubnode = False Then

                    '동일하지 않으면 하위 노드 모두 추가
                    node.Nodes.Add(subnode)
                    subnode.Nodes.Add(trdnode)

                ElseIf chksubnode = True And chktrdnode = False Then

                    '동일하지 않으면 노드 추가
                    subnode.Nodes.Add(trdnode)

                End If


            End If



        Next


    End Function

    Private Sub RecursiveSearch(ByVal treeNode As TreeNode, ByVal TextToFind As String)

        ' Keep calling the test recursively.
        For Each TN As TreeNode In treeNode.Nodes
            If TN.Text = TextToFind Then

            Else
                If chkcol = TN.Level Then
                    treeNode.Nodes.Add(TextToFind)
                Else
                    RecursiveSearch(TN, TextToFind)

                End If
            End If

        Next
    End Sub
    Public Sub BuildTree(ByVal dt As DataTable, ByVal trv As TreeView, ByVal expandAll As [Boolean])
        ' Clear the TreeView if there are another datas in this TreeView
        trv.Nodes.Clear()
        Dim node As TreeNode
        Dim subNode As TreeNode
        Dim trdNode As TreeNode


        For Each row As DataRow In dt.Rows
            'search in the treeview if any country is already present
            node = Searchnode(row.Item(0).ToString(), trv)


            If node IsNot Nothing Then
                subNode = New TreeNode(row.Item(1).ToString())
                trdNode = New TreeNode(row.Item(2).ToString())

                If node.LastNode.Text <> row.Item(1).ToString() Then
                    node.Nodes.Add(subNode)
                    If trdNode.Text = "" Then

                    Else
                        subNode.Nodes.Add(trdNode)
                    End If
                ElseIf node.LastNode.Text = row.Item(1).ToString() Then

                    Dim chknode As Boolean = False

                    For Each a In node.LastNode.Nodes
                        If a.text = row.Item(2).ToString() Then
                            chknode = True
                        End If

                    Next
                    If chknode = True Then

                    Else
                        node.LastNode.Nodes.Add(trdNode)
                    End If


                End If
            Else
                node = New TreeNode(row.Item(0).ToString())
                subNode = New TreeNode(row.Item(1).ToString())
                trdNode = New TreeNode(row.Item(2).ToString())

                If node.Text = "ETC" Then
                    trv.Nodes.Add(subNode)
                Else
                    trv.Nodes.Add(node)

                    If subNode.Text = "" Then

                    Else
                        node.Nodes.Add(subNode)

                        If trdNode.Text = "" Then

                        Else
                            subNode.Nodes.Add(trdNode)
                        End If
                    End If
                End If

            End If
        Next
        If expandAll Then
            ' Expand the TreeView
            trv.ExpandAll()
        End If
    End Sub
    Private Function Searchnode(ByVal nodetext As String, ByVal trv As TreeView) As TreeNode
        For Each node As TreeNode In trv.Nodes
            If node.Text = nodetext Then
                Return node
            End If
        Next
    End Function
    Private Sub txtStep_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPro.KeyPress, txtMod.KeyPress, txtStep.KeyPress
        ' 엔터쳤을 때 
        If e.KeyChar = Convert.ToChar(13) Then  ' ToChar <-- 13번 값은 Enter 임.
            Call btn_Search_Click(sender, e)   ' 다른 프로시져 호출
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        '-----------------------------------
        '내 용 : 맵핑 된 자료를 수정할 수 있음
        '-----------------------------------
        'Dim ModifyInfo As New ModifyInfo
        'ModifyInfo.Show()


    End Sub

    Private Sub trv1_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles trv1.AfterSelect

        Dim change_Add As New Change_Add_Tree
        vConn = New OleDbConnection(change_Add.strCon)
        Dim project As String
        Dim Model As String
        Dim steps As String
        Dim node() As String

        project = ""
        Model = ""
        steps = ""

        lstSuf.Items.Clear()
        lstComp.Items.Clear()

        node = Split(trv1.SelectedNode.FullPath, "\")

        If node.length = 3 Then
            project = "AND [Project] LIKE '" & node(0) & "'"
            Model = "AND [Model] LIKE '" & node(1) & "'"
            steps = "AND [차수] LIKE '" & node(2) & "'"
        ElseIf node.length = 2 Then
            project = "AND [Project] LIKE '" & node(0) & "'"
            Model = "AND [Model] LIKE '" & node(1) & "'"
        ElseIf node.length = 1 Then
            'project = "AND [Project] LIKE '%" & node(0) & "%'"
            project = "AND [Project] LIKE '" & node(0) & "'"
        End If

        Dim SQL As String

        SQL = "SELECT Project, Model, 차수, 사업자, 업체명 "
        SQL = SQL & "FROM 검계_DB "
        SQL = SQL & "WHERE ID > 0 " & project & Model & steps _
        & " GROUP BY Project, Model, 차수, 사업자, 업체명 ORDER BY Model" 'DATA 중복제거

        Dim result As DataTable = New DataTable
        Dim cmd As OleDbCommand = New OleDbCommand(SQL, vConn)

        Dim DA As OleDbDataAdapter = New OleDbDataAdapter(cmd)
        DA.Fill(result)

        Dim DT_Suf As DataTable = New DataTable
        Dim DT_Comp As DataTable = New DataTable

        DT_Suf = result.DefaultView.ToTable(True, "사업자")
        DT_Comp = result.DefaultView.ToTable(True, "업체명")

        For i = 0 To DT_Suf.Rows.Count - 1
            lstSuf.Items.Add(DT_Suf.Rows(i)(0))
        Next

        For i = 0 To DT_Comp.Rows.Count - 1
            lstComp.Items.Add(DT_Comp.Rows(i)(0))
        Next
    End Sub
End Class