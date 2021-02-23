Imports System.Collections.Generic
Imports System.Data
Imports System.Data.OleDb
Imports System.Diagnostics
Imports System.Drawing
Imports System.IO
Imports System.Windows.Forms


Public Class Change_Add_Tree
    Public dataApp As DataSet = New DataSet
    Public DS As DataSet = New DataSet
    Public DS2 As DataSet = New DataSet
    Public DA As OleDbDataAdapter = New OleDbDataAdapter()
    Public DA2 As OleDbDataAdapter = New OleDbDataAdapter()
    Private blchk As Boolean = False
    Private strSht As String = Nothing
    Private InfoConn As OleDbConnection
    Public vConn As OleDbConnection
    Private strFilePath As String = Nothing    '"\\10.174.51.33\Q-Portal\기본검증"
    Private szFileName As String = Nothing
    Private szFolderName As String = Nothing
    Private szMerge As String = Nothing
    Private szTemp As String = Nothing
    Private Table_App As DataTable
    Public Table_Select As DataTable
    Public Table_AppNext As DataTable
    Public Table_ActionNext As DataTable
    Private Table_Action As DataTable
    Public dt_Change As DataTable

    Public strApp As String = "TD_NEXT_AF_Des"                    ' DB 테이블명 지정
    Private strFile_sub As String = "Template_"

    'change폼에서 가져오는 값
    Public strProject As String
    Public strModel As String
    Public strChasu As String
    Public strFunc As String
    ' Public strFuncDes As String
    Public strFuncRisk As String
    Public strTip As String = Nothing
    Public strCom As String = Nothing
    Public pathFile As String = Nothing
    Public pathFile2 As String = Nothing
    Public chkLoad As Boolean = False
    Public strSht_sub As String = Nothing
    Public xml As New XML
    Public func = {"Function_Setting", "Function_Contents", "Function_Gesture"}
    Public strCon As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\WorkSpace\01. Work\2019\01. January\0116\QPortalDB.accdb;Jet OLEDB:Database Password = lge1234;"
    Public strAdCon As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=\\10.169.88.40\Q-Portal\5.Admin(AccessDB)\QPortalDB_Admin.accdb;Jet OLEDB:Database Password = lge1234;"
    'Public strCon As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=\\10.169.88.40\Q-Portal\0.AccessDB\QPortalDB.accdb;Jet OLEDB:Database Password = lge1234;"
    Public previewForm As PreviewForm '= New PreviewForm
    Public dtGrid As DataTable = New DataTable()

    Public ChangeTable As DataTable = New DataTable()


    Public feature_Node As String
    Public change_title_Node As String


    '파일이 켜져있는지 학인
    Private Function FileIsOpen(ByVal pathfile As String) As Boolean
        Try
            Dim fs As IO.FileStream = IO.File.Open(pathfile, IO.FileMode.Open, IO.FileAccess.Read, IO.FileShare.None)
            fs.Close()
            fs.Dispose()
            fs = Nothing
            Return False
        Catch ex As IO.IOException ' File open
            Return True
        Catch ex As Exception ' Unknown error
            Return True
        End Try
    End Function

    Public Function FindNode(ByRef list As List(Of TreeNode), ByRef parent As TreeNode) As List(Of TreeNode)
        If parent Is Nothing Then Return list
        list.Add(parent)
        For Each child As TreeNode In parent.Nodes
            FindNode(list, child)
        Next
        Return list
    End Function
    Private Sub Change_Add_Tree_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '-------------------------------------------------------------------------------
        ' 제 작 : 이순배
        ' 내 용 : Tree View에 넣을 App Name 가져오기
        '-------------------------------------------------------------------------------
        Icon = My.Resources.Qportal_Icon
        Dim strSht As String = "변경점_DB"
        Dim vcon As String = Nothing

        ' 버튼 비활성화 Default Setting
        btnAddGridView.Enabled = False
        btnAddGridView.BackColor = Color.FromArgb(229, 229, 229)

        'info 이미지 Default 가림
        PictureBox1.Visible = False

        xml.vCon_Call(vcon)
        InfoConn = New OleDbConnection(strCon)

        Dim sSQL = "SELECT * FROM [" & "AppList" & "] as m Where ID > 0 "
        DA = New OleDbDataAdapter(sSQL, InfoConn)
        DA.Fill(dataApp, "App_List")

        sSQL = "SELECT * FROM [" & "TD_NEXT_Action" & "] where ID > 0"

        DA = New OleDbDataAdapter(sSQL, InfoConn)
        DA.Fill(dataApp, "TD_NEXT_Action")


        Dim Table As DataTable = dataApp.Tables(0)
        Table_ActionNext = dataApp.Tables(1)

        Dim chk As Boolean = False

        'Tree View에 모델 프로젝트 가져오는 부분
        Call BuildTree_Multi(Table, appTree, 1, 2, expandAll:=True)

        ' 180131 - 순배 - 이 부분이 Test Action Access에서 가져오는 부분
        Call BuildTree_Action(Table_ActionNext, actionTree, expandAll:=False)

        lstChange.Items.Add("App을 클릭 해 주세요")

        '검증 유형 추가
        With lstGu.Items
            .Add("Random_변경점")
            .Add("Random_변경점X")
        End With

        ' ---------------------------------------------
        ' 제 작 : 이순배
        ' 내용 : 앱명 클릭 했을 때 변경점 비교해서 색칠하기
        ' ---------------------------------------------
        Dim Change As New Change

        Dim cPro As String = txtPro_in.Text
        Dim cMod As String = txtMod_in.Text
        Dim cStep As String = txtStep_in.Text
        Dim cSuffix As String = txtSuffix_in.Text
        Dim cComp As String = txtComp_in.Text

        'Dim cUname As String = Change.szUserName

        Dim sql As String
        Dim vSQL_pro As String = Nothing
        Dim vSQL_Mod As String = Nothing
        Dim vSQL_Step As String = Nothing
        Dim vSQL_Suffix As String = Nothing
        Dim vSQL_Company As String = Nothing

        Dim vConn = New OleDbConnection(strCon)
        vConn.Open()

        vSQL_pro = " AND [Project] = '" & Replace(cPro, "'", "''") & "'"
        vSQL_Mod = " AND [Model] = '" & Replace(cMod, "'", "''") & "'"
        vSQL_Step = " AND [차수] = '" & Replace(cStep, "'", "''") & "'"
        vSQL_Suffix = " AND [사업자] = '" & Replace(cSuffix, "'", "''") & "'"
        'vSQL_Company = " AND [업체명] LIKE '%" & Replace(cComp, "'", "''") & "%'"

        sql = "SELECT * "
        sql = sql & "FROM 검계_DB "
        sql = sql & "WHERE ID > 0 " & vSQL_pro & vSQL_Mod & vSQL_Step & vSQL_Suffix '& vSQL_Company


        Dim result As DataTable = New DataTable

        Dim cmd As OleDbCommand = New OleDbCommand(sql, vConn)
        '     ▼▼ Data Adapter를 사용해 Data Table을 만들고 Query 된 Result를 Count 하여 기존 Data가 있는지 Check 
        Dim adapter As OleDbDataAdapter = New OleDbDataAdapter(cmd)
        adapter.Fill(result)
        adapter.Fill(ChangeTable)

        Dim firstNode As String = Nothing
        Dim secondNode As String = Nothing

        Dim dtCheck As DataTable = New DataTable()
        Dim dtRow As DataRow
        Dim rowValues(1) As Object

        dtCheck.Clear()
        dtCheck.Columns.Add(New DataColumn("App"))
        dtCheck.Columns.Add(New DataColumn("Feature"))

        Dim blCheck_App As Boolean = False
        Dim blCheck_Fea As Boolean = False

        '  Node 값 받기
        Dim tn As TreeNode
        Dim child As TreeNode
        For Each tn In appTree.Nodes '< ---바꾸시려는 Node의 Parent Node 입니다....
            For Each child In tn.Nodes
                For i As Integer = 0 To result.Rows.Count - 1 '◀변경점테이블

                    If child.Text = result.Rows(i)(1).ToString() And Not result.Rows(i)(4).ToString() = "" And Not result.Rows(i)(4).ToString() = " " Then
                        rowValues(0) = result.Rows(i)(1).ToString()
                        rowValues(1) = result.Rows(i)(2).ToString()
                        dtRow = dtCheck.Rows.Add(rowValues)
                        dtCheck.AcceptChanges()
                        'Exit For
                    End If
                Next i

                '------------------------------------------------
                ' 제 작 : 이순배
                ' 내 용 : 기능 변경점 / 앱 변경점 파악해서 색칠하기
                '------------------------------------------------
                If dtCheck.Rows.Count <> 0 Then
                    blCheck_App = False
                    blCheck_Fea = False
                    For Each d As DataRow In dtCheck.Rows
                        If InStr(d.Item(1).ToString(), "App") Then
                            blCheck_App = True
                        ElseIf InStr(d.Item(1).ToString(), "기능") Then
                            blCheck_Fea = True
                        End If
                    Next

                    Select Case blCheck_App & blCheck_Fea
                        Case "TrueTrue"   ' App / 기능 둘 다 변경점 있을 때
                            child.ForeColor = Color.FromArgb(255, 255, 255)
                            child.BackColor = Color.FromArgb(192, 0, 0)        ' <-- 둘 다 있는 경우
                        Case "TrueFalse"
                            child.ForeColor = Color.FromArgb(255, 255, 255)
                            child.BackColor = Color.FromArgb(0, 176, 0)        ' <-- App만 있는 것(빨간색)
                        Case "FalseTrue"
                            child.ForeColor = Color.FromArgb(255, 255, 255)
                            child.BackColor = Color.FromArgb(0, 0, 255)        ' <-- 기능만 있는 것(파란색)
                    End Select

                End If

                dtCheck.Clear()

            Next

        Next

        '------------------------------------------------
        ' 제 작 : 이순배
        ' 내 용 : DataGridView에 컬럼명 생성 하기
        '------------------------------------------------
        Dim strcolumns = {"App Name", "Feature", "변경점", "변경점 내용", "Risk Factor", "변경점 검증방법", "검증유형", "Project", "Model", "차수", "사업자", "업체명"}

        ' Data Grid View에 들어갈 Column명 지정
        Try
            'For each문으로 배열을 만복하여 Data Table을 생성
            For Each a As String In strcolumns
                dtGrid.Columns.Add(New DataColumn(a))
            Next

            '만들어진 DataTable로 Binding
            DataGridView1.DataSource = dtGrid

        Catch ex As Exception
            MessageBox.Show(ex.Message)
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
    Private Function Searchnode_sub(ByVal nodetext As String, ByVal node As TreeNode) As TreeNode
        Dim keyNode As TreeNode
        For Each keyNode In node.Nodes
            If keyNode.Text = nodetext Then
                '일치하는 노드가 있을 시 반환
                Return keyNode
            End If
        Next
    End Function
    'Test Action
    Public Sub BuildTree_Action(ByVal dt As DataTable, ByVal trv As TreeView, ByVal expandAll As [Boolean])
        ' Clear the TreeView if there are another datas in this TreeView
        trv.Nodes.Clear()
        Dim node As TreeNode
        Dim keyNode As TreeNode
        Dim subNode As TreeNode
        For Each row As DataRow In dt.Rows
            'search in the treeview if any country is already present
            node = Searchnode(row.Item(2).ToString(), trv)

            If node IsNot Nothing Then
                keyNode = Searchnode_key(row.Item(3).ToString(), node)
                If keyNode IsNot Nothing Then
                    'Country is already present
                    subNode = New TreeNode(row.Item(4).ToString())
                    keyNode.Nodes.Add(subNode)
                Else
                    'Country is already present
                    subNode = New TreeNode(row.Item(4).ToString())
                    If row.Item(3).ToString() = "" Then
                        'keyNode = New TreeNode(row.Item(4).ToString())
                        node.Nodes.Add(subNode)
                    Else
                        keyNode = New TreeNode(row.Item(3).ToString())
                        keyNode.Nodes.Add(subNode)
                        node.Nodes.Add(keyNode)
                    End If

                End If
            Else
                node = New TreeNode(row.Item(2).ToString())
                subNode = New TreeNode(row.Item(4).ToString())
                If row.Item(3).ToString() = "" Then
                    'keyNode = New TreeNode(row.Item(4).ToString())
                    ' keyNode.Nodes.Add(subNode)
                    node.Nodes.Add(subNode)
                    trv.Nodes.Add(node)
                Else
                    keyNode = New TreeNode(row.Item(3).ToString())
                    keyNode.Nodes.Add(subNode)
                    node.Nodes.Add(keyNode)
                    trv.Nodes.Add(node)
                End If
                'keyNode = New TreeNode(row.Item(3).ToString())

                'Add cities to country
                'keyNode.Nodes.Add(subNode)
                'node.Nodes.Add(keyNode)
                'trv.Nodes.Add(node)
            End If
        Next
        If expandAll Then
            ' Expand the TreeView
            trv.ExpandAll()
        End If
    End Sub

    ' App Name
    Public Sub BuildTree(ByVal dt As DataTable, ByVal dt2 As DataTable, ByVal trv As TreeView, ByVal expandAll As [Boolean])
        ' Clear the TreeView if there are another datas in this TreeView
        trv.Nodes.Clear()
        Dim node As TreeNode
        Dim subNode As TreeNode
        Dim chkChange_Func As Boolean = False
        Dim chkChange_App As Boolean = False
        Dim chkChange_All As Boolean = False
        Dim strAppS As String = Nothing
        Dim strAppC As String = Nothing
        Dim strFea As String = Nothing
        Dim strChange As String = Nothing

        '  dt = dt.DefaultView.ToTable(True, New String("App"))
        'DB Row만큼 돌림
        For Each row As DataRow In dt.Rows
            chkChange_Func = False
            chkChange_App = False
            chkChange_All = False
            For Each row2 As DataRow In dt2.Rows

                strAppS = row.Item(0).ToString
                strAppC = row2.Item(4).ToString
                strFea = row2.Item(5).ToString
                strChange = row2.Item(6).ToString

                If strAppS = strAppC And strFea = "기능" And strChange <> "" Then
                    chkChange_Func = True
                    ' Exit For
                ElseIf strAppS = strAppC And strFea = "App" And strChange <> "" Then
                    chkChange_App = True
                    'Exit For
                End If
            Next

            If chkChange_App And chkChange_Func Then
                chkChange_All = True
            End If

            'search in the treeview if any country is already present
            node = Searchnode(row.Item(0).ToString(), trv)
            If node IsNot Nothing Then

                'Country is already present
                subNode = New TreeNode(row.Item(1).ToString())
                'Add cities to country
                node.Nodes.Add(subNode)
            Else

                If row.Item(0).ToString() = row.Item(1).ToString() Then
                    node = New TreeNode(row.Item(0).ToString())
                    'subNode = New TreeNode(row.Item(1).ToString())
                    'Add cities to country
                    'node.Nodes.Add()
                Else
                    node = New TreeNode(row.Item(0).ToString())
                    subNode = New TreeNode(row.Item(1).ToString())
                    'Add cities to country
                    node.Nodes.Add(subNode)
                End If
                'node = New TreeNode(row.Item(0).ToString())
                'subNode = New TreeNode(row.Item(1).ToString())
                ''Add cities to country
                'node.Nodes.Add(subNode)

                ' 변경ㄱ점 색 바꾸기
                If chkChange_All Then
                    node.ForeColor = Color.FromArgb(255, 255, 255)
                    node.BackColor = Color.FromArgb(192, 0, 0)        ' <-- 기능/App 변경점 둘 다 있는 경우
                ElseIf chkChange_Func Then
                    node.ForeColor = Color.FromArgb(255, 255, 255)
                    node.BackColor = Color.FromArgb(0, 0, 255)        ' <-- 기능 변경점만 있는 경우
                ElseIf chkChange_App Then
                    node.ForeColor = Color.FromArgb(255, 255, 255)
                    node.BackColor = Color.FromArgb(0, 128, 0)        ' <-- App 변경점만 있는 경우 
                Else
                    node.ForeColor = Color.FromArgb(0, 0, 0)            ' <-- 아예 없는 경우
                End If

                trv.Nodes.Add(node)
            End If
        Next
        If expandAll Then
            ' Expand the TreeView
            trv.ExpandAll()
        End If
    End Sub

    '해당 노드가 있는지 확인 함
    Private Function Searchnode(ByVal nodetext As String, ByVal trv As TreeView) As TreeNode
        For Each node As TreeNode In trv.Nodes
            If node.Text = nodetext Then
                '일치하는 노드가 있을 시 반환
                Return node
            End If
        Next
    End Function
    '해당 노드가 있는지 확인 함
    Private Function Searchnode_key(ByVal nodetext As String, ByVal node As TreeNode) As TreeNode
        For Each keyNode As TreeNode In node.Nodes
            If keyNode.Text = nodetext Then
                '일치하는 노드가 있을 시 반환
                Return keyNode
            End If
        Next
    End Function
    ' Excel Export
    '리스트에 아이템 축해줌
    Sub List_Add_Items(ByVal lstName As ListBox, ByVal num As Integer, ByVal i As Integer)
        If Not lstName.Items.Contains(Trim(Table_App.Rows(i)(num).ToString())) _
                        And Trim(Table_App.Rows(i)(num).ToString()) <> "" And Trim(Table_App.Rows(i)(num).ToString()) <> "-" Then  ' 중복 없이 Item 추가
            lstName.Items.Add(Trim(Table_App.Rows(i)(num).ToString()))
        End If
    End Sub

    Public appNode As String
    Public titleNode As String
    Private Sub appTree_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles appTree.AfterSelect
        txtApp.Text = ""
        txtAppRisk.Text = ""
        txtSelectedApp.Text = ""
        ' ---------------------------------------------------------
        ' 제 작 : 이순배
        ' 내 용 : 앱명 클릭 했을 때 변경점 List에 기능/App 생기게 해주기
        ' ----------------------------------------------------------

        vConn = New OleDbConnection(strCon)
        vConn.Open()

        Dim sSQL As String = "SELECT * FROM 검계_DB WHERE Project = '" & txtPro_in.Text & "' and Model = '" & txtMod_in.Text & "' and  차수 = '" & txtStep_in.Text & "' and 사업자 = '" & txtSuffix_in.Text & "'"

        Dim result As DataTable = New DataTable
        Dim cmd As OleDbCommand = New OleDbCommand(sSQL, vConn)
        '     ▼▼ Data Adapter를 사용해 Data Table을 만들고 Query 된 Result를 Count 하여 기존 Data가 있는지 Check 
        Dim adapter As OleDbDataAdapter = New OleDbDataAdapter(cmd)
        adapter.Fill(result)


        Dim nodePath As String = appTree.SelectedNode.FullPath
        Dim var() As String = Split(nodePath, "\")
        Dim firstNode As String = Nothing
        Dim secondNode As String = Nothing

        Dim dt As DataTable = New DataTable
        Dim dRow As DataRow = Nothing
        Dim dCol As DataColumn = Nothing

        ' Data table의 Column 생성 
        dCol = New DataColumn()
        dCol.DataType = System.Type.GetType("System.String")
        dCol.ColumnName = "COLUMN_ONE"
        dt.Columns.Add(dCol)

        ' Data table의 Column 생성
        dCol = New DataColumn()
        dCol.DataType = System.Type.GetType("System.String")
        dCol.ColumnName = "COLUMN_TWO"
        dt.Columns.Add(dCol)

        'ChangeTable

        Dim rowValues() As Object
        Dim temps As New List(Of String)        ' Case 밖에서 해주어야 함.

        Select Case var.Length
            Case 2
                firstNode = var(0)
                secondNode = var(1)

                titleNode = var(0)
                appNode = var(1)

                txtSelectedApp.Text = secondNode
                'Step 1) Tree View에 'App' 및 '기능' 추가
                'Tree View에 모델 프로젝트 가져오는 부분
                For i As Integer = 0 To ChangeTable.Rows.Count - 1
                    If ChangeTable.Rows(i)(1).ToString() = secondNode And Not ChangeTable.Rows(i)(4).ToString() = vbNullString And Not ChangeTable.Rows(i)(4).ToString() = " " Then

                        If Strings.InStr(ChangeTable.Rows(i)(2).ToString(), "App") Or Strings.InStr(ChangeTable.Rows(i)(2).ToString(), "기능") _
                             Then

                            ' ] 문자열 기준으로 Split 하여 Array에 담기
                            rowValues = Split(ChangeTable.Rows(i)(4).ToString(), "]")

                            For Each t As String In rowValues
                                If Not t = "" Then
                                    If Strings.InStr(t, "[") Then
                                        t = Strings.Mid(t, Strings.InStr(t, "[") - 1)
                                        t = LTrim(t)
                                        t = t & "]"
                                        temps.Add(t)
                                    Else    ' [ 문자가 없는 건 그냥 담음
                                        temps.Add(t)
                                    End If
                                End If

                                ' 가공 된 Text Array 반복하여 row에다가 담음
                                For j As Integer = 0 To temps.Count - 1
                                    dRow = dt.NewRow()
                                    dRow("COLUMN_ONE") = ChangeTable.Rows(i)(2).ToString()
                                    dRow("COLUMN_TWO") = temps(j)
                                Next j
                                dt.Rows.Add(dRow)   ' datatable에 반영
                            Next    ' Loop Split 한 변경점 내용 내에서 반복

                        End If

                        Call BuildTree_Multi(dt, lstTree, 0, 1, expandAll:=False)

                    End If

                Next i



                'For i As Integer = 0 To result.Rows.Count - 1
                '    If result.Rows(i)(1).ToString() = secondNode And Not result.Rows(i)(4).ToString() = vbNullString And Not result.Rows(i)(4).ToString() = " " Then

                '        If Strings.InStr(result.Rows(i)(2).ToString(), "App") Or Strings.InStr(result.Rows(i)(2).ToString(), "기능") _
                '             Then

                '            ' ] 문자열 기준으로 Split 하여 Array에 담기
                '            rowValues = Split(result.Rows(i)(4).ToString(), "]")

                '            For Each t As String In rowValues
                '                If Not t = "" Then
                '                    If Strings.InStr(t, "[") Then
                '                        t = Strings.Mid(t, Strings.InStr(t, "[") - 1)
                '                        t = LTrim(t)
                '                        t = t & "]"
                '                        temps.Add(t)
                '                    Else    ' [ 문자가 없는 건 그냥 담음
                '                        temps.Add(t)
                '                    End If
                '                End If

                '                ' 가공 된 Text Array 반복하여 row에다가 담음
                '                For j As Integer = 0 To temps.Count - 1
                '                    dRow = dt.NewRow()
                '                    dRow("COLUMN_ONE") = result.Rows(i)(2).ToString()
                '                    dRow("COLUMN_TWO") = temps(j)
                '                Next j
                '                dt.Rows.Add(dRow)   ' datatable에 반영
                '            Next    ' Loop Split 한 변경점 내용 내에서 반복

                '        End If

                '        Call BuildTree_Multi(dt, lstTree, 0, 1, expandAll:=False)

                '    End If

                'Next i

        End Select




    End Sub
    ' App Name
    Public Sub BuildTree_list(ByVal dt As DataTable, ByVal trv As TreeView, ByVal expandAll As [Boolean])
        ' Clear the TreeView if there are another datas in this TreeView
        trv.Nodes.Clear()
        Dim node As TreeNode
        Dim subNode As TreeNode
        Dim titleTemp As String = Nothing
        Dim num As Integer = Nothing
        Dim chkApp As Boolean = False
        Dim chkItem5 As Boolean = False 'true = Func, False = 기능

        For Each row As DataRow In dt.Rows
            'search in the treeview if any country is already present
            node = Searchnode(row.Item(5).ToString(), trv)
            If node IsNot Nothing Then
                chkApp = True
            Else
                chkApp = False
            End If
            titleTemp = row.Item(6).ToString

            num = 0
            If chkApp = False And dt.Rows.Count = 1 Then
                node = New TreeNode(row.Item(5).ToString())
                titleTemp = Split(titleTemp, "]")(0)
                '  titleTemp = Split(titleTemp, "[")(1)
                subNode = New TreeNode(titleTemp + "]")
                node.Nodes.Add(subNode)
                trv.Nodes.Add(node)
            ElseIf chkApp = False Then
                node = New TreeNode(row.Item(5).ToString())
                trv.Nodes.Add(node)
            ElseIf dt.Rows.Count > 1 Then
                titleTemp = Split(titleTemp, "]")(0)
                '  titleTemp = Split(titleTemp, "[")(1)
                subNode = New TreeNode(titleTemp + "]")
                node.Nodes.Add(subNode)
            End If
        Next

        If expandAll Then
            ' Expand the TreeView
            trv.ExpandAll()
        End If
    End Sub
    Private Sub actionTree_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles actionTree.AfterSelect
        txtExport.Clear()
        Dim szNode As String = Nothing
        ' -------------------------------------------------------------------------------
        ' 제작 : 이순배
        ' 날짜 : 2018-01-31
        ' 내용 : 트리뷰 선택 시 Export 부분인 변경점 검증 방법에 채워지는 거
        '-------------------------------------------------------------------------------
        Try
            Dim Table_ActionNext As DataTable = dataApp.Tables(1)
            Dim sNodes() As String = Nothing
            Dim node_First As String
            Dim node_Second As String
            Dim node_Third As String

            ' Full Path = ex) Function_Contents ADD(추가)\Contents_image\이미지_컨텐츠 추가
            sNodes = Split(actionTree.SelectedNode.FullPath, "\")

            Select Case sNodes.Length
                Case 1
                    node_First = sNodes(0)
                    For q As Integer = 0 To Table_ActionNext.Rows.Count - 1
                        If node_First = Table_ActionNext.Rows(q)(2).ToString() Then
                            '180131 순배
                            txtExport.Text = "[시험목적]"
                            txtExport.Text = txtExport.Text & vbCrLf & Table_ActionNext.Rows(q)(5).ToString() & vbCrLf   ' Purpose ex) 1.다양한 경로

                            txtExport.Text = txtExport.Text & "[시험방법]"
                            txtExport.Text = txtExport.Text & vbCrLf & Table_ActionNext.Rows(q)(6).ToString()
                            Exit Sub
                        End If

                    Next

                Case 2
                    node_First = sNodes(0)
                    node_Second = sNodes(1)
                    For q As Integer = 0 To Table_ActionNext.Rows.Count - 1
                        If node_First = Table_ActionNext.Rows(q)(2).ToString() And node_Second = Table_ActionNext.Rows(q)(3).ToString() Then
                            '180131 순배
                            txtExport.Text = "[시험목적]"
                            txtExport.Text = txtExport.Text & vbCrLf & Table_ActionNext.Rows(q)(5).ToString() & vbCrLf   ' Purpose ex) 1.다양한 경로

                            txtExport.Text = txtExport.Text & "[시험방법]"
                            txtExport.Text = txtExport.Text & vbCrLf & Table_ActionNext.Rows(q)(6).ToString()
                            Exit Sub
                        End If

                    Next
                Case 3
                    node_First = sNodes(0)
                    node_Second = sNodes(1)
                    node_Third = sNodes(2)
                    For q As Integer = 0 To Table_ActionNext.Rows.Count - 1
                        If node_First = Table_ActionNext.Rows(q)(2).ToString() And node_Second = Table_ActionNext.Rows(q)(3).ToString() And node_Third = Table_ActionNext.Rows(q)(4).ToString() Then
                            '180131 순배
                            txtExport.Text = "[시험목적]"
                            txtExport.Text = txtExport.Text & vbCrLf & Table_ActionNext.Rows(q)(5).ToString() & vbCrLf   ' Purpose ex) 1.다양한 경로

                            txtExport.Text = txtExport.Text & "[시험방법]"
                            txtExport.Text = txtExport.Text & vbCrLf & Table_ActionNext.Rows(q)(6).ToString()
                            Exit Sub
                        End If

                    Next

            End Select

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub lstTree_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles lstTree.AfterSelect
        '------------------------------------------------------------------------
        ' 제 작 : 이순배
        ' 내 용 : 기능 / App 클릭 했을 때 변경점과 Risk Factor가 보여지도록 하는 부분
        '------------------------------------------------------------------------
        txtApp.Text = ""
        txtAppRisk.Text = ""

        vConn = New OleDbConnection(strCon)
        vConn.Open()

        Dim sSQL As String = "SELECT * FROM 검계_DB"

        Dim result As DataTable = New DataTable
        Dim cmd As OleDbCommand = New OleDbCommand(sSQL, vConn)
        '     ▼▼ Data Adapter를 사용해 Data Table을 만들고 Query 된 Result를 Count 하여 기존 Data가 있는지 Check 
        Dim adapter As OleDbDataAdapter = New OleDbDataAdapter(cmd)
        adapter.Fill(result)

        Dim sNodes() As String = Nothing
        Dim node_First As String
        Dim node_Second As String
        Dim szAppName As String

        ' Full Path = ex) Function_Contents ADD(추가)\Contents_image\이미지_컨텐츠 추가
        sNodes = Split(lstTree.SelectedNode.FullPath, "\")

        If titleNode = "LGU+" Or titleNode = "KT" Or titleNode = "SKT" Then
            szAppName = titleNode & "_" & appNode
        Else
            szAppName = appNode
        End If

        Select Case sNodes.Length
            Case 2
                ' App Name
                node_First = sNodes(0)      ' App_OT01, 기능_OT01
                node_Second = sNodes(1)     ' 변경점

                feature_Node = sNodes(0)
                change_title_Node = sNodes(1)

                If Strings.InStr(node_First, "App") Then
                    ' 기능일 때 
                    For i As Integer = 0 To ChangeTable.Rows.Count - 1
                        If szAppName = ChangeTable.Rows(i)(1).ToString() _
                          And Strings.InStrRev(ChangeTable.Rows(i)(2).ToString(), node_First) Then

                            'Enter 처리 해야 함
                            Dim testtmp As String = ChangeTable.Rows(i)(4).ToString()


                            txtApp.Text = ChangeTable.Rows(i)(5).ToString()  ' App 변경점
                            If ChangeTable.Rows(i)(6).ToString() = "" Then   ' Risk Factor
                                txtAppRisk.Text = "작성 된 Risk Factor가 없습니다."
                            Else
                                txtAppRisk.Text = ChangeTable.Rows(i)(6).ToString()
                            End If
                        End If
                    Next

                Else
                    ' 기능일 때 
                    For i As Integer = 0 To ChangeTable.Rows.Count - 1
                        If szAppName = ChangeTable.Rows(i)(1).ToString() _
                          And Strings.InStrRev(ChangeTable.Rows(i)(2).ToString(), node_First) _
                          And Strings.InStrRev(ChangeTable.Rows(i)(4).ToString(), node_Second) Then

                            'Enter 처리 해야 함
                            txtApp.Text = ChangeTable.Rows(i)(5).ToString()  ' App 변경점
                            If ChangeTable.Rows(i)(6).ToString() = "" Then   ' Risk Factor
                                txtAppRisk.Text = "작성 된 Risk Factor가 없습니다."
                            Else
                                txtAppRisk.Text = ChangeTable.Rows(i)(6).ToString()
                            End If
                        End If
                    Next

                End If

        End Select




        'Select Case sNodes.Length
        '    Case 2
        '        ' App Name
        '        node_First = sNodes(0)      ' App_OT01, 기능_OT01
        '        node_Second = sNodes(1)     ' 변경점

        '        feature_Node = sNodes(0)
        '        change_title_Node = sNodes(1)

        '        If Strings.InStr(node_First, "App") Then
        '            ' 기능일 때 
        '            For i As Integer = 0 To result.Rows.Count - 1
        '                If szAppName = result.Rows(i)(1).ToString() _
        '                  And Strings.InStrRev(result.Rows(i)(2).ToString(), node_First) Then

        '                    'Enter 처리 해야 함
        '                    Dim testtmp As String = result.Rows(i)(4).ToString()


        '                    txtApp.Text = result.Rows(i)(5).ToString()  ' App 변경점
        '                    If result.Rows(i)(6).ToString() = "" Then   ' Risk Factor
        '                        txtAppRisk.Text = "작성 된 Risk Factor가 없습니다."
        '                    Else
        '                        txtAppRisk.Text = result.Rows(i)(6).ToString()
        '                    End If
        '                End If
        '            Next

        '        Else
        '            ' 기능일 때 
        '            For i As Integer = 0 To result.Rows.Count - 1
        '                If szAppName = result.Rows(i)(1).ToString() _
        '                  And Strings.InStrRev(result.Rows(i)(2).ToString(), node_First) _
        '                  And Strings.InStrRev(result.Rows(i)(4).ToString(), node_Second) Then

        '                    'Enter 처리 해야 함
        '                    txtApp.Text = result.Rows(i)(5).ToString()  ' App 변경점
        '                    If result.Rows(i)(6).ToString() = "" Then   ' Risk Factor
        '                        txtAppRisk.Text = "작성 된 Risk Factor가 없습니다."
        '                    Else
        '                        txtAppRisk.Text = result.Rows(i)(6).ToString()
        '                    End If
        '                End If
        '            Next

        '        End If

        'End Select

    End Sub

    Private Sub btnAddGridView_Click_1(sender As Object, e As EventArgs) Handles btnAddGridView.Click
        '------------------------------------------------------------------------
        ' 제 작 : 이순배
        ' 내 용 : Datagridview에 내용추가 하기
        '------------------------------------------------------------------------

        Dim szApp As String = appNode
        Dim szFea As String = feature_Node
        Dim szChange As String = change_title_Node


        vConn = New OleDbConnection(strCon)
        vConn.Open()


        Dim sql As String = Nothing
        Dim vSQL_pro As String = Nothing
        Dim vSQL_Mod As String = Nothing
        Dim vSQL_Step As String = Nothing
        Dim vSQL_Suffix As String = Nothing
        Dim vSQL_Company As String = Nothing

        Dim vSQL_Change As String = Nothing
        Dim vSQL_App As String = Nothing
        Dim vSQL_Fea As String = Nothing


        Dim Change As New Change

        Dim cPro As String = txtPro_in.Text
        Dim cMod As String = txtMod_in.Text
        Dim cStep As String = txtStep_in.Text
        Dim cSuffix As String = txtSuffix_in.Text
        Dim cComp As String = txtComp_in.Text

        szChange = Replace(szChange, "-", "")

        vSQL_App = " AND [App Name] LIKE '%" & Replace(appNode, "'", "''") & "%'"
        vSQL_Fea = " AND [Feature] LIKE '%" & Replace(feature_Node, "'", "''") & "%'"
        vSQL_Change = " AND [변경점] LIKE '%" & Replace(szChange, "'", "''") & "%'"

        vSQL_pro = " AND [Project] LIKE '%" & Replace(cPro, "'", "''") & "%'"
        vSQL_Mod = " AND [Model] LIKE '%" & Replace(cMod, "'", "''") & "%'"
        vSQL_Step = " AND [차수] LIKE '%" & Replace(cStep, "'", "''") & "%'"
        vSQL_Suffix = " AND [사업자] LIKE '%" & Replace(cSuffix, "'", "''") & "%'"
        vSQL_Company = " AND [업체명] LIKE '%" & Replace(cComp, "'", "''") & "%'"

        sql = "SELECT * "
        sql = sql & "FROM 검계_DB "
        sql = sql & "WHERE ID > 0 " & vSQL_pro & vSQL_Mod & vSQL_Step & vSQL_Suffix & vSQL_Company & vSQL_App & vSQL_Fea & vSQL_Change

        Dim result As DataTable = New DataTable
        Dim cmd As OleDbCommand = New OleDbCommand(sql, vConn)
        '     ▼▼ Data Adapter를 사용해 Data Table을 만들고 Query 된 Result를 Count 하여 기존 Data가 있는지 Check 
        Dim adapter As OleDbDataAdapter = New OleDbDataAdapter(cmd)
        adapter.Fill(result)

        vConn.Close()

        If Not result.Rows.Count = 0 Then
            szChange = result.Rows(0)(4).ToString() ' 원래 변경점
        End If

        Dim change_Result As String = txtApp.Text
        Dim risk_Factor As String = txtAppRisk.Text
        Dim test_howto As String = txtExport.Text
        Dim test_Type As String = lstGu.Text

        ' 중복 체크를 위해 단어 합침.
        Dim strSum = appNode & feature_Node & szChange & change_Result & risk_Factor & test_howto & test_Type & cPro & cMod & cStep & cSuffix & cComp

        'text sum on DataGridView Values
        'Dim dtGridtable As DataTable = New DataTable
        '        Dim strcolumns = {"App Name", "Feature", "변경점", "변경점 내용", "Risk Factor", "변경점 검증방법", "검증유형", "Project", "Model", "차수", "사업자", "업체명"}
        Dim strGridSum = Nothing
        Dim blTrue As Boolean = True
        Try
            Dim strcheck As String
            dtGrid.AcceptChanges() ' refresh the data table

            ' check duplicate datatable rows
            For Each dtrow As DataRow In dtGrid.Rows
                blTrue = False
                strcheck = dtrow("App Name") & dtrow("Feature") & dtrow("변경점") & dtrow("변경점 내용") & dtrow("Risk Factor") & dtrow("변경점 검증방법") & dtrow("검증유형") & dtrow("Project") & dtrow("Model") & dtrow("차수") & dtrow("사업자") & dtrow("업체명")
                If strSum = strcheck Then
                    'is it dupl
                    MessageBox.Show("이미 추가 된 항목 입니다.")
                    Exit Sub
                End If
            Next

            'appNode & feature_Node & szChange & change_Result & risk_Factor & test_howto & test_Type & cPro & cMod & cStep & cSuffix & cComp
            ' adding vlaues [object 에
            Dim rowvalues(11) As Object
            rowvalues(0) = appNode
            rowvalues(1) = feature_Node
            rowvalues(2) = szChange
            rowvalues(3) = change_Result
            rowvalues(4) = risk_Factor
            rowvalues(5) = test_howto
            rowvalues(6) = test_Type
            rowvalues(7) = cPro
            rowvalues(8) = cMod
            rowvalues(9) = cStep
            rowvalues(10) = cSuffix
            rowvalues(11) = cComp

            Dim drow As DataRow
            drow = dtGrid.Rows.Add(rowvalues)
            dtGrid.AcceptChanges()

            'datasource bind
            DataGridView1.DataSource = dtGrid

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub txtExport_GotFocus(sender As Object, e As EventArgs) Handles txtExport.GotFocus
        '-------------------------------------------------
        ' 제 작 : 이순배
        ' 내 용 : 마우스 가져다 대었을 때 이미지 보여지는 부분
        '--------------------------------------------------
        btnAddGridView.Enabled = True
        btnAddGridView.BackColor = Color.White
    End Sub

    Private Sub la_Help_MouseLeave(sender As Object, e As EventArgs) Handles la_Help.MouseLeave
        '-------------------------------------------------
        ' 제 작 : 이순배
        ' 내 용 : 마우스 Focus 잃었을 때 이미지 사라지는 부분
        '--------------------------------------------------
        PictureBox1.Visible = False

    End Sub

    Private Sub la_Help_MouseMove(sender As Object, e As MouseEventArgs) Handles la_Help.MouseMove
        '-------------------------------------------------
        ' 제 작 : 이순배
        ' 내 용 : 마우스 가져다 대었을 때 이미지 보여지는 부분
        '--------------------------------------------------
        PictureBox1.Visible = True

    End Sub

    Private Sub btn_DBUP_Click(sender As Object, e As EventArgs) Handles btn_DBUP.Click
        '-------------------------------------------------
        ' 제 작 : 이순배
        ' 내 용 : DataGridView에 있는 내용 DB에 올리기
        '--------------------------------------------------

        Dim sql As String = Nothing
        Dim vSQL_pro As String = Nothing
        Dim vSQL_Mod As String = Nothing
        Dim vSQL_Step As String = Nothing
        Dim vSQL_Suffix As String = Nothing
        Dim vSQL_Company As String = Nothing

        Dim vSQL_Change As String = Nothing
        Dim vSQL_App As String = Nothing
        Dim vSQL_Fea As String = Nothing

        Dim nCnt_update As Integer = 0

        '  ▼▼▼  DataGrid View에 있는 Data들을 Data Table에 한꺼번에 담음.
        Dim dt As New DataTable()
        dt = TryCast(DataGridView1.DataSource, DataTable)

        'Step 1) DataGridView의 내용을 변수에 하나씩 담음
        For value As Integer = 0 To dt.Rows.Count - 1
            ' String 변수에 담음
            Dim sz1 As String = Convert.ToString(dt.Rows(value).ItemArray.GetValue(0))  '// APP Name 
            Dim sz2 As String = Convert.ToString(dt.Rows(value).ItemArray.GetValue(1))  '// Feature

            Dim sz3 As String = Convert.ToString(dt.Rows(value).ItemArray.GetValue(2))  '// 변경점
            Dim sz4 As String = Convert.ToString(dt.Rows(value).ItemArray.GetValue(3))  '// 변경점 내용

            Dim sz5 As String = Convert.ToString(dt.Rows(value).ItemArray.GetValue(4))  '// Risk Factor
            Dim sz6 As String = Convert.ToString(dt.Rows(value).ItemArray.GetValue(5))  '// 변경점 검증방법

            Dim sz7 As String = Convert.ToString(dt.Rows(value).ItemArray.GetValue(6))  '// 검증유형
            Dim sz8 As String = Convert.ToString(dt.Rows(value).ItemArray.GetValue(7))  '// Project

            Dim sz9 As String = Convert.ToString(dt.Rows(value).ItemArray.GetValue(8))  '// Model
            Dim sz10 As String = Convert.ToString(dt.Rows(value).ItemArray.GetValue(9)) '// Step

            Dim sz11 As String = Convert.ToString(dt.Rows(value).ItemArray.GetValue(10)) '// 사업자
            Dim sz12 As String = Convert.ToString(dt.Rows(value).ItemArray.GetValue(11)) '// 업체명

            'update 절
            sql = "UPDATE 검계_DB SET "
            sql = sql & "[App Name] ='" & sz1 & "', "
            sql = sql & "[Feature] ='" & sz2 & "', "
            sql = sql & "[변경점] ='" & sz3 & "', "
            sql = sql & "[변경점 내용] ='" & sz4 & "', "
            sql = sql & "[Risk Factor] ='" & sz5 & "', "
            sql = sql & "[변경점 검증방법] ='" & sz6 & "', "
            sql = sql & "[검증유형] ='" & sz7 & "', "
            sql = sql & "[Project] ='" & sz8 & "', "
            sql = sql & "[Model] ='" & sz9 & "', "
            sql = sql & "[차수] ='" & sz10 & "', "
            sql = sql & "[사업자] ='" & sz11 & "', "
            sql = sql & "[업체명] ='" & sz12 & "'"

            'where 절
            sql = sql & " WHERE "
            sql = sql & "[App Name] = '" & sz1 & "' And Feature = '" & sz2 & "' And 변경점 = '" & sz3 & "' And "
            sql = sql & "Project = '" & sz8 & "' And Model = '" & sz9 & "' And "
            sql = sql & "차수 = '" & sz10 & "' And 사업자 = '" & sz11 & "'"

            Dim Change_Add_Tree As New Change_Add_Tree
            vConn = New OleDbConnection(Change_Add_Tree.strCon)
            vConn.Open()

            Dim myCmd = New OleDbCommand(sql, vConn)
            Dim check = myCmd.ExecuteNonQuery()
            nCnt_update += 1

            vConn.Close()
            'MessageBox.Show("App Mapping이 완료 되었습니다.")
            CreateObject("WScript.Shell").Popup("업데이트 : " & nCnt_update & "완료되었습니다.", 1, "Q-Portal")

        Next

    End Sub

    Private Sub Change_Add_Tree_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        ' Form이 꺼질 때 다시 띄워줌
        Dim Change As New Change
        Change.Show()

    End Sub

    Private Sub btn_Reflection_Click(sender As Object, e As EventArgs) Handles btn_Reflection.Click
        '# Button 클릭 시 Reflection Form에 변수 넘겨주기.
        '# Reflection View Dialog 형식으로 Open
        Dim reflection_view As New Import_reflection_view With {
            .strApp = txtSelectedApp.Text,            '# 선택 한 App 이름 넘기기
            .strPro = txtPro_in.Text,                     '# 프로젝트 명
            .strMod = txtMod_in.Text                 '# 모델 명
            }

        reflection_view.ShowDialog()
    End Sub
End Class