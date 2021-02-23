Imports System.Drawing
Imports System.Diagnostics
Imports System.Data.OleDb
Imports System.Data
Imports System.Windows.Forms
Imports Microsoft.Office.Interop

Public Class P_Project_Plan
    Public Change_Add_Tree As New Change_Add_Tree
    Public DS_FOR_RESULT As DataSet = New DataSet
    Public vConn As OleDbConnection = New OleDbConnection
    'Public DS As DataSet = New DataSet

#Region "  Main Form 최초 Load 시 "
    Private Sub FormLoad_Event(sender As Object, e As EventArgs) Handles MyBase.Load
        trvInfo.CheckBoxes = False
        btnDelete.Visible = False
        btnDown.Visible = False
        'getAdmin("이순배")

    End Sub
#End Region

    Private Sub EnterEventSens(sender As Object, e As KeyPressEventArgs) Handles txtPro.KeyPress, txtMod.KeyPress
        If e.KeyChar = Convert.ToChar(13) Then 'enter키를 눌렀을 때 동작
            btnSearch_Click(sender, e)
        End If
    End Sub


#Region "1. [Project 및 Model 검색하기]"
    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click

        DS_FOR_RESULT.Clear()

        ' 빈 항목이면 조건에 들어가지 않도록
        Dim vSQLPro As String = Nothing : vSQLPro = IIf(txtPro.Text = "", "", "AND [Project] LIKE '%" & Replace(txtPro.Text, "'", "''") & "%'")
        Dim vSQLMod As String = Nothing : vSQLMod = IIf(txtMod.Text = "", "", "AND [Model] LIKE '%" & Replace(txtMod.Text, "'", "''") & "%'")
        Dim sql As String = Nothing
        'Dim sht As String = "기능변경점_DB"
        Dim sht As String = "SW_Validation_Result"

        Debug.Print(vSQLPro & Environment.NewLine & vSQLMod)
        Debug.Print(vSQLPro & Environment.NewLine & vSQLMod)

        ' SQL QUERY 작성   // 검색한 결과에 맞게 내용 가져와서 Type 에다가 자료 넣어줌
        sql = "SELECT * "
        sql = sql & "FROM [" & sht & "] "
        sql = sql & "WHERE ID > 0 And Project is not null " & vSQLPro & vSQLMod

        Dim vConn As OleDbConnection = New OleDbConnection(Change_Add_Tree.strCon)   '// OledbConnection 사용하기 위해 선언 (Connection String 기준으로
        Dim DA As OleDbDataAdapter = New OleDbDataAdapter(sql, vConn)
        Dim DS As DataSet = New DataSet
        DA.Fill(DS, sht)
        Debug.Print(sql)

        Dim modTable As DataTable = New DataTable
        modTable = DS.Tables(0)

        If modTable.Rows.Count = 0 Then

            MessageBox.Show("조회 된 결과가 없습니다.")
            trvInfo.Nodes.Clear()

        Else
            DS_FOR_RESULT = DS
            trvInfo.Nodes.Clear()

            '# 직접 제작한 함수로 Tree View 노드 추가
            Call builed_Treenode(modTable, trvInfo, 7, 8, 0) ' Project / Model 위치
            trvInfo.Sort()

        End If


    End Sub

#End Region

#Region "2. [Model 선택 시 내용 보여주기]"


    Private Sub trvInfo_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles trvInfo.AfterSelect

        Debug.Print(trvInfo.SelectedNode.FullPath)  '# 선택한 Node의 값을 확인 하기 위해.

        Dim stemp As String = trvInfo.SelectedNode.FullPath
        Dim var() As String = Split(stemp, "\")

        Select Case var.Length

            Case 2
                Debug.Print(var(0) & " and " & var(1))
                Dim strPro As String = var(0)       '# Project 
                Dim strMod As String = var(1)     '# Model
                Dim Table As DataTable = DS_FOR_RESULT.Tables(0)

                trvChange.Nodes.Clear()

                '# 직접 제작한 함수로 Tree View 노드 추가
                Call builed_Treenode(Table, trvChange, 1, 2, 0) ' Project / Model 위치



        End Select


    End Sub

#End Region

#Region "2-1. [내용 선택 시 Textbox에 내용 보여주기]"
    Private Sub trvChange_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles trvChange.AfterSelect
        Dim stemp As String = trvInfo.SelectedNode.FullPath
        Dim stemp_list As String = trvChange.SelectedNode.FullPath
        Dim var() As String = Split(stemp, "\")
        Dim varList() As String = Split(stemp_list, "\")
        Debug.Print(trvInfo.SelectedNode.FullPath)
        Debug.Print(trvInfo.SelectedNode.FullPath)


        Dim strPro As String = Nothing : Dim strMod As String = Nothing : Dim strChange As String = Nothing
        Dim strChange_1 As String = Nothing

        Dim strRisk As String : Dim strChange_Result As String : Dim strTypeREsult As String

        Dim Table As DataTable = DS_FOR_RESULT.Tables(0)

        Select Case varList.Length
            Case 2

                txtRisk.Text = ""
                txtChange_result.Text = ""
                txtTypeResult.Text = ""

                strPro = LTrim(var(0))     ' 선택 한 노드의 값들을 저장
                strMod = LTrim(var(1))

                strChange = varList(0)
                strChange_1 = varList(1)

                For i As Integer = 0 To Table.Rows.Count - 1
                    If strPro = LTrim(Table.Rows(i)(7)) And
                        strMod = LTrim(Table.Rows(i)(8)) And
                        strChange = LTrim(Table.Rows(i)(1)) And
                        strChange_1 = LTrim(Table.Rows(i)(2)) Then

                        strRisk = LTrim(Table.Rows(i)(4))
                        strChange_Result = LTrim(Table.Rows(i)(3))
                        strTypeREsult = LTrim(Table.Rows(i)(6))

                        txtRisk.Text = Replace(strRisk, Chr(10), Chr(13) & Chr(10))
                        txtChange_result.Text = Replace(strChange_Result, Chr(10), Chr(13) & Chr(10))
                        txtTypeResult.Text = Replace(strTypeREsult, Chr(10), Chr(13) & Chr(10))


                    End If
                Next



        End Select



        Try
            strPro = LTrim(var(0))     ' 선택 한 노드의 값들을 저장
            strMod = LTrim(var(1))
            'strChange = trvChange.SelectedItem.ToString()
            'For i As Integer = 0 To Table.Rows.Count - 1
            '    If strPro = LTrim(Table.Rows(i)(3).ToString()) And strMod = LTrim(Table.Rows(i)(4).ToString()) And strChange = LTrim(Table.Rows(i)(1).ToString()) Then
            '        ' Dim strText As String = LTrim(Table.Rows(i)(1).ToString())
            '        Dim strText_Risk As String = LTrim(Table.Rows(i)(2).ToString())
            '        txtDes.Text = Replace(strText_Risk, Chr(10), Chr(13) & Chr(10))
            '        'txtRisk.Text = Replace(strText_Risk, Chr(10), Chr(13) & Chr(10))
            '    End If
            'Next

        Catch ex As Exception
            Debug.Print("Prject : " & LTrim(var(0)))
            Debug.Print("Model : " & LTrim(var(1)))
            Debug.Print("변경점 내용 : " & strChange)


        End Try
    End Sub
#End Region

#Region "[Edit] 클릭 시 프로젝트 모델 삭제 할 수 있도록 "
    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        If trvInfo.CheckBoxes = True Then   '# Checkbox 모드 일 때 ㅎ
            trvInfo.CheckBoxes = False
            btnDelete.Visible = False
            btnDown.Visible = False

        Else                                          '# Checkbox 모드가 아닐 때
            trvInfo.CheckBoxes = True
            btnDelete.Visible = True
            btnDown.Visible = True
        End If

    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        '# 삭제 할 때 
        Dim node As TreeNode
        Dim child As TreeNode
        Dim sql As String = Nothing
        Dim result As DataTable = New DataTable

        Dim UserName As String = getUserName()
        Dim adminUser As Boolean = getAdmin(UserName)
        Dim CompanyName As String = getCompany(UserName)

        If CompanyName = vbNullString Then
            MessageBox.Show("등록되지 않은 사원 입니다. 관리자에게 문의 해주세요.", "lee.sunbae@lgepartner.com", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub

        End If

        For Each node In trvInfo.Nodes ' TreeView 이름
            For Each child In node.Nodes

                If child.Checked = True Then    'check 한 항목이면

                    vConn = New OleDbConnection(Change_Add_Tree.strCon)
                    vConn.Open()

                    sql = "select * from SW_Validation_Result "
                    sql = sql & "where Project = '" & node.Text & "'" & " and Model = '" & child.Text & "'"

                    Dim cmd As OleDbCommand = New OleDbCommand(sql, vConn)
                    Dim adapter As OleDbDataAdapter = New OleDbDataAdapter(cmd)
                    adapter.Fill(result)

                    'result.Rows(i).Item("등록자")
                    Dim usChk As Boolean = False
                    Dim realUser As String = Nothing
                    For i As Integer = 0 To result.Rows.Count - 1
                        If result.Rows(i).Item("등록자") = UserName Then
                            'realUser += UserName & Environment.NewLine
                            usChk = True
                            Exit For
                        Else
                            realUser = result.Rows(i).Item("등록자")
                        End If
                    Next

                    If usChk = True Or adminUser = True Then    '# 삭제하려는 대상이 있으면
                        '# 실제 등록한 사람만 지우게

                        '# Query 작성 부분 
                        If adminUser = True Then    ' 관리자면
                            sql = "Delete from SW_Validation_Result "
                            sql = sql & "where Project = '" & node.Text & "'" & " and Model = '" & child.Text & "'"

                        Else
                            sql = "Delete from SW_Validation_Result "
                            sql = sql & "where Project = '" & node.Text & "'" & " and Model = '" & child.Text & "'"
                            sql = sql & " and 등록자 = '" & getUserName() & "'"
                        End If

                        Debug.Print(sql)

                        '# 삭제 하기 전 파일을 생성해야 함.
                        Dim DelSQL As String = Nothing

                        'DelSQL = "Select * from SW_Validation_Result "
                        'DelSQL = DelSQL + "where Project = '" + node.Text + "'" + " and Model = '" + child.Text + "'"



                        'WhenDeleteExcelFile("\\10.169.88.40\Q-Portal\2.검증현황\시험기획삭제_이력", "프로젝트+모델+날짜.xlsx")
                        Dim strNewPath As String = "\\10.169.88.40\Q-Portal\2.검증현황\시험기획삭제_이력"
                        Dim strNewName As String = "(" + node.Text + ")_" + child.Text + "_" + Date.Now.ToString("yyyy_MM_dd_hh_mm_ss") + ".xlsx"

                        WhenDeleteExcelFile(result, strNewPath, strNewName)

                        '# 실제 삭제 
                        Dim myCmd As OleDbCommand = New OleDbCommand(sql, vConn)
                        myCmd.ExecuteNonQuery()


                        Dim sql_history As String = Nothing
                        sql_history = "insert into D_History "
                        sql_history = sql_history + "(Project, Model, 업체명, 이름) "
                        sql_history = sql_history + "Values ('" & node.Text & "', '" & child.Text & "', '" & CompanyName & "', '" & UserName & "');"

                        'Debug.Print(sql_history)
                        'Debug.Print(Environment.NewLine & UserName)

                        myCmd = New OleDbCommand(sql_history, vConn)
                        myCmd.ExecuteNonQuery()

                        Debug.Print("삭제 히스토리 완료 " & Environment.NewLine &
                                    "업체명 : " & CompanyName & Environment.NewLine &
                                    "이름 : " & UserName)

                        vConn.Close()
                    Else
                        MessageBox.Show("삭제는 등록한 사람만 할 수 있습니다. " & Environment.NewLine & "------정보------" & Environment.NewLine _
                                       & Environment.NewLine & "등록자 : " & realUser)
                        Exit Sub

                    End If




                End If

            Next
        Next

        btnSearch_Click(sender, e)

    End Sub

    Private Sub trvInfo_Click(sender As Object, e As TreeViewEventArgs) Handles trvInfo.AfterCheck

        Dim node As TreeNode = e.Node

        CheckSelectAll(e.Node, e.Node.Checked)



    End Sub

    Private Sub CheckSelectAll(node As TreeNode, chkValue As Boolean)
        '# node 선택한 노드
        '# chkValue Bool 변수

        If chkValue = True Then '# 체크 했을 때
            If node.Parent Is Nothing = True Then   '가장 최 상위 노드인경우
                For Each subNode As TreeNode In node.Nodes  ' 반복하며 하위 항목 모두 체크
                    subNode.Checked = True
                Next
            End If

        ElseIf chkValue = False Then    '# 체크 해제 했을 때


            Debug.Print("현재 노드 : " & node.Text)
            For Each subNode As TreeNode In node.Nodes

                If node.Parent Is Nothing = True Then   '가장 최 상위 노드인경우
                    subNode.Checked = False

                End If
            Next
        End If

        'UnCheckList(node, node.Level)

    End Sub

    Private Function UnCheckList(node As TreeNode, chkValue As Integer)
        '# UnCheck 한 SelectedNode가 SubNode이면 
        '# 상위 노드를 UnCheck 한다.
        Dim blExit As Boolean = False
        If chkValue = 1 Then
            If node.Parent Is Nothing = False And
            node.Parent.Checked = True Then ' 선택한게 SubNode이고 체크해제했을 때 
                '# Parent 가 Check 되어 있을 때만
                blExit = True
            End If
        End If

        UnCheckList = blExit

        If UnCheckList = True Then
            node.Parent.Checked = False
            Exit Function
        End If


    End Function

#End Region

#Region "★ get User Name ★"
    Private Function getUserName() As String

        Dim strCom As String = "."
        Dim strName As String = Nothing
        Dim obj = GetObject("winmgmts:{impersonationLevel=impersonate}!\\" & strCom & "\root\cimv2").ExecQuery("Select * FROM Win32_OperatingSystem")
        For Each Obj2 In obj
            strName = Obj2.Description
        Next
        getUserName = Strings.Split(strName, "/")(0)



        Return getUserName

    End Function

    Private Function getAdmin(ByRef User As String) As Boolean
        Dim FindCompany As String = Nothing
        Dim vConn As OleDbConnection = New OleDbConnection
        Dim DS As DataSet = New DataSet
        'Dim myCmd As OleDbDataAdapter = New OleDbDataAdapter

        Dim sql As String = "Select * FROM [" + "Admin_Name" + "]"


        vConn = New OleDbConnection(Change_Add_Tree.strAdCon)

        Dim nCnt As Integer = 0
        Dim DA = New OleDbDataAdapter(sql, vConn)

        DA.Fill(DS, "Admin_Name")

        Dim result As DataTable = DS.Tables(0)
        Dim blcp As Boolean = False

        For i = 1 To result.Rows.Count - 1

            Dim strDBName As String = Nothing

            strDBName = result.Rows(i).Item("A_Name")
            strDBName = Strings.Left(strDBName, InStr(strDBName, "(") - 1)

            If strDBName = User Then
                blcp = True
                Exit For
            End If

            If blcp = True Then  ' 이미 이름을 찾은 경우라면!
                Exit For
            End If

        Next


        If blcp = True Then
            getAdmin = False    '# False면 못찾은거
        Else
            getAdmin = True '# True면 찾은 거
        End If

    End Function

    Private Function getCompany(ByRef User As String) As String
        Dim FindCompany As String = Nothing
        Dim vConn As OleDbConnection = New OleDbConnection
        Dim DS As DataSet = New DataSet
        'Dim myCmd As OleDbDataAdapter = New OleDbDataAdapter

        Dim strCNS As String = "Contacts_C"                         ' 업체 
        Dim strINFINIQ As String = "Contacts_I"
        Dim strMSTech As String = "Contacts_M"

        Dim szConC As String = "Select * FROM [" + strCNS + "]"
        Dim szConI As String = "Select * FROM [" + strINFINIQ + "]"
        Dim szConM As String = "Select * FROM [" + strMSTech + "]"

        Dim szQuery As String() = New String() {szConC, szConI, szConM}
        Dim loopSht As String() = New String() {strCNS, strINFINIQ, strMSTech}

        vConn = New OleDbConnection(Change_Add_Tree.strCon)

        Dim nCnt As Integer = 0
        For Each a As String In szQuery
            Dim DA = New OleDbDataAdapter(a, vConn)
            DA.Fill(DS, loopSht(nCnt))
            nCnt += 1
        Next

        Dim blcp As Boolean = True
        For nZ As Integer = 0 To 2       ' 0~2 까지가 업체테이블임
            For nW = 1 To DS.Tables(nZ).Rows.Count - 1
                If DS.Tables(nZ).Rows(nW)(2).ToString() = User Then

                    If DS.Tables(nZ).Rows(nW)(4).ToString() = "CNS" Then    ' CNS의 경우에 LG CNS로 보여주기 위해 Custom
                        FindCompany = "LG " & DS.Tables(nZ).Rows(nW)(4).ToString()
                    Else
                        FindCompany = DS.Tables(nZ).Rows(nW)(4).ToString()
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

        If blcp = True Then
            getCompany = "미등록 사용자"
        Else
            getCompany = FindCompany
        End If




    End Function


#End Region

#Region "# Tree View 함수들 #"
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
                        TwoNode = Searchnode_sub(Trim(row.Item(dataTwo).ToString()), node)    ' 이미 있는 노드에 추가로 붙이려면 중복 안된 거를 붙여야 함
                        If TwoNode Is Nothing Then
                            TwoNode = New TreeNode(Trim(row.Item(dataTwo).ToString()))        ' level 2
                            node.Nodes.Add(TwoNode)                                     ' level 2에다가 level 3 붙임
                        End If

                    Else                        ' 노드가 없으면 
                        node = New TreeNode(Trim(row.Item(dataOne).ToString()))           ' level 1
                        TwoNode = New TreeNode(Trim(row.Item(dataTwo).ToString()))        ' level 2

                        ' level 2에다가 level 3 붙임
                        node.Nodes.Add(TwoNode)                                     ' level 1에다가 level 2 붙임
                        trv.Nodes.Add(node)                                         ' level 1 추가

                    End If

                Next

            Case Else   ' 3개 일 때 

                For Each row As DataRow In dt.Rows

                    node = Searchnode(Trim(row.Item(dataOne).ToString()), trv)
                    If node IsNot Nothing Then  ' 노드가 이미 있으면 덮어쓰기 해야 함
                        TwoNode = Searchnode_sub(Trim(row.Item(dataTwo).ToString()), node)    ' 이미 있는 노드에 추가로 붙이려면 중복 안된 거를 붙여야 함
                        If TwoNode Is Nothing Then
                            TwoNode = New TreeNode(Trim(row.Item(dataTwo).ToString()))        ' level 2
                            node.Nodes.Add(TwoNode)                                     ' level 2에다가 level 3 붙임
                        End If

                        ThreeNode = Searchnode_third(Trim(row.Item(dataThree).ToString()), TwoNode)
                        If ThreeNode Is Nothing Then
                            ThreeNode = New TreeNode(Trim(row.Item(dataThree).ToString()))        ' level 3
                            TwoNode.Nodes.Add(ThreeNode)
                        End If

                    Else                        ' 노드가 없으면 
                        node = New TreeNode(Trim(row.Item(dataOne).ToString()))           ' level 1
                        TwoNode = New TreeNode(Trim(row.Item(dataTwo).ToString()))        ' level 2
                        ThreeNode = New TreeNode(Trim(row.Item(dataThree).ToString()))    ' level 3

                        TwoNode.Nodes.Add(ThreeNode)                                ' level 2에다가 level 3 붙임
                        node.Nodes.Add(TwoNode)                                     ' level 1에다가 level 2 붙임
                        trv.Nodes.Add(node)                                         ' level 1 추가

                    End If

                Next

        End Select

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
        Dim return_Node As TreeNode = Nothing
        For Each node As TreeNode In trv.Nodes
            If node.Text = nodetext Then
                return_Node = node
                Exit For
            End If
        Next
        Return return_Node
    End Function
    '해당 노드가 있는지 확인 함
    Private Function Searchnode_sub(ByVal nodetext As String, ByVal node As TreeNode) As TreeNode
        Dim return_Node As TreeNode = Nothing
        For Each keyNode As TreeNode In node.Nodes
            If keyNode.Text = nodetext Then
                '일치하는 노드가 있을 시 반환
                return_Node = keyNode
                Exit For
            End If
        Next
        Return return_Node
    End Function

    '해당 노드가 있는지 확인 함
    Private Function Searchnode_third(ByVal nodetext As String, ByVal node As TreeNode) As TreeNode
        Dim return_Node As TreeNode = Nothing
        For Each keyNode As TreeNode In node.Nodes
            If keyNode.Text = nodetext Then
                '일치하는 노드가 있을 시 반환
                return_Node = keyNode
                Exit For
            End If
        Next

        Return return_Node

    End Function




#End Region

#Region " [글자크기 조정하는 함수]"
    Private Function CalSize(ByRef i As Integer) As Integer

        Dim s As Integer = 0

        If i >= 2500 Then
            s = 25
        ElseIf i >= 2000 Then
            s = 20
        ElseIf i >= 1000 Then
            s = 16
        ElseIf i < 1000 And i >= 800 Then
            s = 14
        ElseIf i < 800 And i >= 600 Then
            s = 12
        ElseIf i < 600 And i >= 400 Then
            s = 10
        ElseIf i < 400 And i >= 200 Then
            s = 9
        ElseIf i < 200 And i >= 100 Then
            s = 8
        End If

        Return s

    End Function



#End Region

    Public dt_new As DataTable = New DataTable
    Public result As DataTable = New DataTable
#Region "타모델꺼 가져오기"
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnDown.Click

        '# 다운 받을 때
        Dim node As TreeNode
        Dim child As TreeNode
        Dim sql As String = Nothing

        result.Clear()
        For Each node In trvInfo.Nodes ' TreeView 이름

            For Each child In node.Nodes

                If child.Checked = True Then    'check 한 항목이면
                    vConn = New OleDbConnection(Change_Add_Tree.strCon)
                    vConn.Open()

                    sql = "SELECT 변경점구분, 구분, 주요변경점, 변경점내용, Risk, 검증유형, AppName, 검증유형내용, Project, Model, TC진행여부, TC명 from SW_Validation_Result "
                    sql = sql & "where Project = '" & node.Text & "'" & " and Model = '" & child.Text & "'"

                    Dim cmd As OleDbCommand = New OleDbCommand(sql, vConn)
                    Dim adapter As OleDbDataAdapter = New OleDbDataAdapter(cmd)

                    adapter.Fill(result)

                    vConn.Close()



                End If
            Next

        Next

        Dim strInfos As String = Nothing
        dt_new.Clear()
        dt_new = result.DefaultView.ToTable(True, "Project", "Model")

        For i As Integer = 0 To dt_new.Rows.Count - 1

            If dt_new.Rows.Count > 0 Then
                strInfos = strInfos + "-------------------" + Environment.NewLine +
                             "Project : " + dt_new.Rows(i).Item("Project").ToString() + Environment.NewLine +
                             "Model : " + dt_new.Rows(i).Item("Model").ToString() + Environment.NewLine +
                             "-------------------" + Environment.NewLine
            End If
            Debug.Print(strInfos)

        Next

        If MessageBox.Show(strInfos + Environment.NewLine + "다운 받으시겠습니까?", "lee.sunbae@lgepartner.com", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
            Exit Sub
        End If

        btn_Excel_Click(sender, e)


    End Sub

#End Region

#Region "[엑셀 파일을 생성 후 조회 값넣고 VBA 하기]"
    Private Sub btn_Excel_Click(sender As Object, e As EventArgs)
        Dim blChk As Boolean = False
        '# Resource에 있는 Excel File 실행 > 입력 칸에 값 넣고 > 코드 실행 > 다른 이름으로 저장 하기 팝업

        '# 지정경로 안에서 '시험기획서_Access_v1.3' 찾기 후 파일 Copy
        Dim dir As System.IO.DirectoryInfo = New System.IO.DirectoryInfo("\\10.169.88.40\Q-Portal\2.검증현황\시험기획")
        Dim strFile As String = Nothing : Dim strRealFile As String = Nothing
        Dim strFullPath As String = Nothing
        For Each dr In dir.GetFiles()
            strFile = dr.Name   '# file name
            If strFile = "PJT_시험기획.xlsx" And Strings.Left(strFile, 2) <> "~$" Then
                strRealFile = dr.Name
                strFullPath = dr.FullName
                blChk = True
                Exit For
            End If
        Next

        'Using stream As New FileStream(strFullPath, , FileAccess.Read)
        ' End Using
        Dim bytesRead As Integer
        Dim buffer(4096) As Byte

        Try
            Using inFile As New System.IO.FileStream(strFullPath, IO.FileMode.Open, IO.FileAccess.Read)
                Using outFile As New System.IO.FileStream(Application.StartupPath + strRealFile, IO.FileMode.Create, IO.FileAccess.Write)
                    Do
                        bytesRead = inFile.Read(buffer, 0, buffer.Length)
                        If bytesRead > 0 Then
                            outFile.Write(buffer, 0, bytesRead)
                        End If
                    Loop While bytesRead > 0
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message, "(Sunbae) - 서버 파일이 이미 열려있습니다.", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try



        'File.Copy(strFullPath, Application.StartupPath + strRealFile, True)   '# 파일 붙여 넣기

        '# File saveFileDialog()
        Dim dlg As New SaveFileDialog()
        dlg.FileName = "원하는 파일명 작성하세요."
        dlg.DefaultExt = ".xlsx"
        dlg.Filter = ""
        dlg.Filter = "Excel File|*.xlsx"
        dlg.Title = "Save an Excel File"

        '# Dialog 화면
        'Dim result As Boolean = dlg.ShowDialog()

        If dlg.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            Dim openFileName As String = Nothing    '# if select Files

            'Save the files
            Try
                saveExcelFile(Application.StartupPath + strRealFile, dlg.FileName)

                Dim strFolder As String = Nothing
                Dim strTemp() As String

                strTemp = Split(dlg.FileName, "\")
                Array.Resize(strTemp, strTemp.Length - 1)
                strFolder = String.Join("\", strTemp)

                Diagnostics.Process.Start(strFolder)        ' 폴더 열기 
                MessageBox.Show("추출 완료")

            Catch ex As Exception
                MessageBox.Show(ex.Message)

            End Try
        Else
            Diagnostics.Debug.Print("그냥 껐다.")
        End If



    End Sub

    Public Sub saveExcelFile(ByVal strFileName As String, ByVal FileName As String)
        Dim datestart As Date = Date.Now
        Dim excel As Excel.Application = New Excel.Application
        Dim m As Excel.Workbook = Nothing
        Dim ms As Excel.Worksheet = Nothing

        Try
            '# Excel Open
            m = excel.Workbooks.Open(strFileName,, 2)

            With excel
                .ScreenUpdating = False    '# Option - Code 실행 되는 것 Animation 끄기.
                .Calculation = Microsoft.Office.Interop.Excel.XlCalculation.xlCalculationManual '# Option - 수식 계산하는 Option OFF
                .Visible = False '# Excel 보여주기.
            End With

            ms = m.Sheets(1)    '# Sheet Object로 할당

            Dim dt_table As DataTable = New DataTable
            dt_table = result

            Dim r As Integer = 2
            Dim c As Integer = 1

            For i As Integer = 0 To dt_table.Rows.Count - 1
                For j As Integer = 0 To dt_table.Columns.Count - 1
                    ms.Cells(r, c) = dt_table.Rows(i)(j).ToString()
                    c = c + 1
                Next
                r = r + 1   ' init 
                c = 1
            Next

            'ms.Cells(5, "b") = strPro
            'ms.Cells(5, "c") = strMod
            'ms.Cells(5, "d") = strStep
            'ms.Cells(5, "e") = strBuyer
            'ms.Cells(5, "f") = strCompany

            '# 테두리 설정
            ms.Range("A2:L" & ms.Cells(ms.Rows.Count, 2).end(3).row).Borders.LineStyle = 1

            Dim n As Integer
            n = ms.Cells(ms.Rows.Count, "B").End(3).row
            'ms.Cells(12, "E") = "=SUM(E13:E" & n & ")"         ' 필요 M/D 계산
            'ms.Cells(12, "F") = "=SUM(F13:F" & n & ")"         ' 할당 M/D 계산

            With excel
                .ScreenUpdating = True    '# Option - Code 실행 되는 것 Animation 끄기.
                .Calculation = Microsoft.Office.Interop.Excel.XlCalculation.xlCalculationAutomatic '# Option - 수식 계산하는 Option OFF
            End With

            m.SaveAs(FileName)

            m.Close()
            excel.Quit()

            Dim dateEnd As Date = Date.Now
            End_Excel_App(datestart, dateEnd) ' This closes excel proces

        Catch ex As Exception
            Diagnostics.Debug.Print(ex.Message)

        Finally


        End Try

    End Sub

    Private Sub End_Excel_App(datestart As Date, dateEnd As Date)
        Dim xlp() As Process = Process.GetProcessesByName("EXCEL")
        Try
            For Each Process As Process In xlp
                If Process.StartTime >= datestart And Process.StartTime <= dateEnd Then
                    Process.Kill()
                    Exit For
                End If
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

#End Region

#Region "실제 삭제 시 엑셀 파일로 저장하기"
    Public Sub WhenDeleteExcelFile(ByVal SaveTable As DataTable, ByRef strSavePath As String, ByRef strSaveFileName As String)
        Dim datestart As Date = Date.Now
        Dim excel As Excel.Application
        Dim m As Excel.Workbook = Nothing
        Dim ms As Excel.Worksheet = Nothing
        Try
            excel = New Excel.Application

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try


        Try
            '# Excel Open
            'm = excel.Workbooks.Open(strFileName,, 2)
            m = excel.Workbooks.Add
            ms = m.Sheets("Sheet1")


            With excel
                .ScreenUpdating = False    '# Option - Code 실행 되는 것 Animation 끄기.
                .Calculation = Microsoft.Office.Interop.Excel.XlCalculation.xlCalculationManual '# Option - 수식 계산하는 Option OFF
                .Visible = False '# Excel 보여주기.
            End With

            'ms = m.Sheets(1)    '# Sheet Object로 할당

            Dim dt_table As DataTable = New DataTable
            dt_table = SaveTable

            '# 엑셀 컬럼 헤더 작성
            Dim c As Integer = 1
            For j As Integer = 0 To dt_table.Columns.Count - 1
                ms.Cells(1, c) = dt_table.Columns(j).ColumnName
                c = c + 1
            Next j

            '# 엑셀 데이터 작성
            Dim r As Integer = 2
            c = 1
            For i As Integer = 0 To dt_table.Rows.Count - 1
                For j As Integer = 0 To dt_table.Columns.Count - 1
                    ms.Cells(r, c) = dt_table.Rows(i)(j).ToString()
                    c = c + 1
                Next
                r = r + 1   ' init 
                c = 1
            Next

            '# 테두리 설정
            ms.Range("A2:L" & ms.Cells(ms.Rows.Count, 2).end(3).row).Borders.LineStyle = 1

            Dim n As Integer
            n = ms.Cells(ms.Rows.Count, "B").End(3).row
            'ms.Cells(12, "E") = "=SUM(E13:E" & n & ")"         ' 필요 M/D 계산
            'ms.Cells(12, "F") = "=SUM(F13:F" & n & ")"         ' 할당 M/D 계산

            With excel
                .ScreenUpdating = True    '# Option - Code 실행 되는 것 Animation 끄기.
                .Calculation = Microsoft.Office.Interop.Excel.XlCalculation.xlCalculationAutomatic '# Option - 수식 계산하는 Option OFF
            End With

            '# 폴더이름 잘라내기
            '1) 프로젝트 이름 가져오기
            Dim strTemp As String = Nothing
            Dim strCut() As String = Nothing
            Dim strFolder As String = Nothing
            Dim intLoc As Integer = 0
            strTemp = strSaveFileName                   '# 파일이름 임시로 저장 왜냐하면, (NEO_OOS)_이런식으로 파일명되어있기 때문
            intLoc = strTemp.LastIndexOf(")")            '# Integer 변수에 ")" 까지의 Length 저장
            strFolder = strTemp.Substring(0, intLoc)    '# strFolder 이름에다가 )까지의 내용 저장 즉, NEO_OOS 가 됨.
            strFolder = strFolder.Replace("(", "")

            strTemp = strSavePath + "\" + strFolder



            If (Not System.IO.Directory.Exists(strTemp)) Then   '# 경로가 있으면 ?
                System.IO.Directory.CreateDirectory(strTemp)
                m.SaveAs(strTemp & "\" & strSaveFileName)
            Else
                m.SaveAs(strTemp & "\" & strSaveFileName)
            End If



            m.Close()
            excel.Quit()

            Dim dateEnd As Date = Date.Now
            'End_Excel_App(datestart, dateEnd) ' This closes excel proces

        Catch ex As Exception
            Diagnostics.Debug.Print(ex.Message)

        Finally
            Dim dateEnd As Date = Date.Now
            'End_Excel_App(datestart, dateEnd) ' This closes excel proces

        End Try

    End Sub
#End Region



End Class