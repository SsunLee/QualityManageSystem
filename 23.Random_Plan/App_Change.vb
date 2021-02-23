Imports System.Data
Imports System.Data.OleDb
Imports System.Diagnostics
Imports System.IO
Imports System.Windows.Forms

Public Class App_Change
    Public DS As DataSet = New DataSet
    Public DA As OleDbDataAdapter = New OleDbDataAdapter()
    Public strSQL As String
    Public InfoConn As OleDbConnection
    Public vConn As OleDbConnection
    Public dtGrid As DataTable = New DataTable()
    Dim table_Merge As New DataTable("table_Merge")
    Dim index As Integer
    Public xml As New XML
    Dim vcon As String = Nothing
    'Public strCon As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\WorkSpace\01. Work\2018\02. February\0213\QPortalDB.accdb;Jet OLEDB:Database Password = lge1234;"
    'Public strCon As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=\\10.169.88.40\Q-Portal\0.AccessDB\QPortalDB.accdb;Jet OLEDB:Database Password = lge1234;"
    'Public strCon As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=\\10.169.88.40\Q-Portal\4.etc\QPortalDB.accdb;Jet OLEDB:Database Password = lge1234;"
    ' 변경점이 정리 된 항목을 DB처럼 가져와서 Tree View에 뿌려주는 작업
    Private Sub btn_Search_Click(sender As Object, e As EventArgs) Handles btn_Search.Click


        Try
            Dim Change_Add_Tree As New Change_Add_Tree
            Dim strSht As String = "변경점_DB"
            xml.vCon_Call(vcon)
            InfoConn = New OleDbConnection(Change_Add_Tree.strCon)

            '#### 쿼리 작성 #########################################################
            Dim szModel As String = Nothing
            Dim szPro As String = Nothing

            ' Model 조회 관련 
            If txt_model.Text = "" Then
                szModel = ""
            Else
                szModel = "AND m.[Model] LIKE '%" & Replace(txt_model.Text, "'", "''") & "%'"
            End If

            ' Project 조회 관련 
            If txt_Project.Text = "" Then
                szPro = ""
            Else
                szPro = "AND m.[Project] LIKE '%" & Replace(txt_Project.Text, "'", "''") & "%'"
            End If


            Dim vSQL As String = "SELECT [Project], [Model], [App Name], [Version], [변경점], [변경점 내용] " & " "
            vSQL = vSQL + "FROM [" & strSht & "] as m" & " Where ID > 0 " & szModel & szPro

            Dim sSQL = "SELECT * FROM [" & "AppList" & "] as m Where ID > 0 "

            DA = New OleDbDataAdapter(vSQL, InfoConn)
            DA.Fill(DS, strSht)

            DA = New OleDbDataAdapter(sSQL, InfoConn)
            DA.Fill(DS, "AppList")

            Dim Table As DataTable = DS.Tables(0)
            Dim aTable As DataTable = DS.Tables(1)

            ' 모델 프로젝트
            ' Call BuildTree(Table, TreeView1, expandAll:=False)
            'Tree View에 모델 프로젝트
            Call BuildTree_Multi(Table, TreeView1, 0, 1, expandAll:=False)
            'Tree View에 App만 보여주기
            Call BuildTree_Multi(aTable, treeView_App, 1, 2, expandAll:=False)
            'Call BuildTree_App(aTable, treeView_App, expandAll:=False)

        Catch ex As Exception
            MsgBox(ex.Message)
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



    Public Sub BuildTree(ByVal dt As DataTable, ByVal trv As TreeView, ByVal expandAll As [Boolean])
        ' Clear the TreeView if there are another datas in this TreeView
        trv.Nodes.Clear()
        Dim node As TreeNode
        Dim subNode As TreeNode
        'Dim trdNode As TreeNode
        dt = dt.DefaultView.ToTable(True, New String("Project"), New String("Model"))
        For Each row As DataRow In dt.Rows
            'search in the treeview if any country is already present
            node = Searchnode(row.Item(0).ToString(), trv)
            If node IsNot Nothing Then
                'Country is already present

                'trdNode = New TreeNode(row.Item(2).ToString())
                'Add cities to country


                subNode = Searchnode_sub(row.Item(0).ToString(), node)
                If subNode IsNot Nothing Then

                Else
                    subNode = New TreeNode(row.Item(1).ToString())
                    node.Nodes.Add(subNode) '기존에 있는 값이면
                End If
                'node.Nodes.Add(trdNode)
            Else    ' 완전 새로 
                node = New TreeNode(row.Item(0).ToString())
                subNode = New TreeNode(row.Item(1).ToString())
                'trdNode = New TreeNode(row.Item(2).ToString())
                'Add cities to country
                'node.Nodes.Add(trdNode)
                node.Nodes.Add(subNode)
                trv.Nodes.Add(node)
            End If
        Next
        If expandAll Then
            trv.ExpandAll()              ' Expand the TreeView
        End If
    End Sub
    Public Sub BuildTree_App(ByVal dt As DataTable, ByVal trv As TreeView, ByVal expandAll As [Boolean])
        ' Clear the TreeView if there are another datas in this TreeView
        trv.Nodes.Clear()
        Dim node As TreeNode
        'Dim subNode As TreeNode
        'Dim trdNode As TreeNode

        For Each row As DataRow In dt.Rows
            node = New TreeNode(row.Item(1).ToString())
            trv.Nodes.Add(node)
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

    ' When Tree View double click
    Private Sub TreeView1_DoubleClick(sender As Object, e As EventArgs) Handles TreeView1.DoubleClick
        ' -------------------------------------------------------------------------------
        ' 내용 : 모델명(트리뷰) 더블 클릭 시 데이타 그리드뷰에 뿌려주는 거
        '-------------------------------------------------------------------------------

        Dim sNode As String
        Dim pNode As String
        Dim Table As DataTable = DS.Tables(0)
        ' Project를 더블클릭시 발생하는 에러 수정 0119
        If TreeView1.SelectedNode.Parent IsNot Nothing Then
            pNode = TreeView1.SelectedNode.Parent.Text
            sNode = TreeView1.SelectedNode.Text

            Dim dv = New DataView(Table, "[Model] = '" & sNode & "'", "Model asc", DataViewRowState.CurrentRows)
            Dim dt = dv.ToTable
            dt = dt.DefaultView.ToTable(True, New String("App Name"), New String("Version"), New String("변경점"), New String("변경점 내용"))
            DataGridView1.DataSource = ""
            DataGridView1.DataSource = dt
        Else
            pNode = TreeView1.SelectedNode.Text
            sNode = ""
            DataGridView1.Columns.Clear()
            DataGridView1.DataSource = ""
            DataGridView1.DataSource = Table
        End If

        txt_pro_in.Text = pNode
        txt_model_in.Text = sNode




    End Sub

    ' Form Load 될 때 
    Private Sub App_Change_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Get Information of Company at My Computer System Name 
        ' -------------------------------------------------------------------------------
        ' 내용 : 처음 App 변경점 맵핑할 때
        '-------------------------------------------------------------------------------

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

        Try
            XML.vCon_Call(vcon)
            Dim Change_Add_Tree As New Change_Add_Tree
            vConn = New OleDbConnection(Change_Add_Tree.strCon)   ' MainForm의 Connection String으로 DB Connect


            'vConn = New OleDbConnection(vCon)   ' 테스트

            ' Looping 하여 Data Adapter 실행
            For Each a As String In szQuery
                'DA = New OleDbDataAdapter(a, vCon)     ' 테스트
                DA = New OleDbDataAdapter(a, vCon)
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
        For nZ As Integer = 0 To 2      ' 0~2 까지가 업체테이블임
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
        ' create table

        Dim strcolumns = {"AppName", "Version", "변경점내용"}        ' Data Grid View에 들어갈 Column명 지정

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

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' -------------------------------------------------------------------------------
        ' 내용 : DataGridView에 있는 자료를 DB에 올리는 것
        '-------------------------------------------------------------------------------
        Dim XML As New XML
        Dim strFileName As String = "검계DB"
        Dim strFilePath As String = Nothing
        Dim vCon As String = Nothing
        'Dim szTemp, szFileName, szMerge As String
        Dim myCmd As OleDbCommand
        '디렉토리검색 부터 검색해서 없으면 생성, 있으면 그폴더에 파일 저장
        Dim Change As New Change
        Dim check As Integer = 0

        If txt_step_in.Text = "" Then
            MsgBox("차수를 입력하지 않았습니다.")
            Exit Sub
        ElseIf txt_suffix_in.Text = "" Then
            MsgBox("사업자를를 입력하지 않았습니다.")
            Exit Sub
        End If

        Try

            'vConn = New OleDbConnection(vCon) 테스트
            Dim nCnt_update As Integer = 0
            Dim nCnt_insert As Integer = 0

            XML.vCon_Call(vCon)
            Dim Change_Add_Tree As New Change_Add_Tree
            vConn = New OleDbConnection(Change_Add_Tree.strCon)
            vConn.Open()
            '  ▼▼▼  DataGrid View에 있는 Data들을 Data Table에 한꺼번에 담음.
            Dim dt As New DataTable()
            dt = TryCast(DataGridView1.DataSource, DataTable)

            'New String("App Name"), New String("Version"), New String("변경점 내용"))
            For value As Integer = 0 To dt.Rows.Count - 1

                ' String 변수에 담음
                Dim sz1 As String = Convert.ToString(dt.Rows(value).ItemArray.GetValue(0))  '// APP Name 
                Dim sz2 As String = "App"                                                  '// Feature
                Dim sz3 As String = Convert.ToString(dt.Rows(value).ItemArray.GetValue(2))  '// 변경점
                Dim sz4 As String = Convert.ToString(dt.Rows(value).ItemArray.GetValue(3))  '// 변경점 내용

                If Not Convert.ToString(dt.Rows(value).ItemArray.GetValue(1)) = " " Then
                    sz4 = "v" & Convert.ToString(dt.Rows(value).ItemArray.GetValue(1)) & vbCrLf & sz4
                End If

                Dim sz5 As String = txt_pro_in.Text                                         '// Project
                Dim sz6 As String = txt_model_in.Text                                       '// Model
                Dim sz7 As String = txt_step_in.Text                                        '// Step
                Dim sz8 As String = txt_suffix_in.Text                                      '// Suffix
                Dim sz9 As String = txt_Comp.Text                                           '// Compnay

                sz1 = Replace(sz1, "'", "")
                sz2 = Replace(sz2, "'", "")
                sz2 = sz2 & "_" & txt_step_in.Text

                sz3 = Replace(sz3, "'", "")
                Dim sTemp As String = sz3
                ' 와일드 카드 문자들 모두 제거 후 비교
                sTemp = Replace(sTemp, "[", "")
                sTemp = Replace(sTemp, "]", "")
                sTemp = Replace(sTemp, "/", "")
                sTemp = Replace(sTemp, "*", "")
                sTemp = Replace(sTemp, ":", "")
                sTemp = Replace(sTemp, "&", "")
                sTemp = Replace(sTemp, "-", "")
                sTemp = Replace(sTemp, "?", "")
                sTemp = Replace(sTemp, "=", "")

                'Dim sz
                'sz = Split(sTemp, "-")
                'sTemp = ""
                'For Each s As String In sz
                '    sTemp = sTemp & " " & s
                'Next

                sz4 = Replace(sz4, "'", "")
                sz5 = Replace(sz5, "'", "")
                sz6 = Replace(sz6, "'", "")
                sz7 = Replace(sz7, "'", "")
                sz8 = Replace(sz8, "'", "")

                If sz1 = "" Then sz1 = " "
                If sz2 = "" Then sz1 = " "
                If sz3 = "" Then sz3 = " "
                If sz4 = "" Then sz4 = " "
                If sz5 = "" Then sz5 = " "
                If sz6 = "" Then sz6 = " "
                If sz7 = "" Then sz7 = " "
                If sz8 = "" Then sz8 = " "

                Dim vSQL1 As String, vSQL2 As String, vSQL3 As String, vSQL4 As String, vSQL5 As String, vSQL6 As String
                Dim vSQL7 As String, vSQL8 As String

                ' 기존 Data 있는지 Check 하기 위한 Query 작성
                vSQL1 = "[App Name] LIKE '%" & Replace(sz1, "'", "''") & "%'"
                vSQL2 = " AND [Feature] LIKE '%" & Replace(sz2, "'", "''") & "%'"
                vSQL3 = " AND [변경점] LIKE '%[" & Replace(sTemp, "'", "''") & "]%'"
                vSQL4 = " AND [Project] LIKE '%" & Replace(sz5, "'", "''") & "%'"
                vSQL5 = " AND [Model] LIKE '%" & Replace(sz6, "'", "''") & "%'"
                vSQL6 = " AND [차수] LIKE '%" & Replace(sz7, "'", "''") & "%'"
                vSQL7 = " AND [사업자] LIKE '%" & Replace(sz8, "'", "''") & "%'"
                vSQL8 = " AND [업체명] LIKE '%" & Replace(sz9, "'", "''") & "%'"

                '    ▼▼ 이미 DB에 있는 것 인지? Check 함
                Dim sSQL As String = "SELECT ID, [App Name], Feature, 변경점, Project, Model, 차수, 사업자, 업체명 FROM 검계_DB"
                sSQL = sSQL & " WHERE " & vSQL1 & vSQL2 & vSQL3 & vSQL4 & vSQL5 & vSQL6 & vSQL7 & vSQL8

                Dim cmd As OleDbCommand = New OleDbCommand(sSQL, vConn)

                '   ▼▼ Data Adapter를 사용해 Data Table을 만들고 Query 된 Result를 Count 하여 기존 Data가 있는지 Check 
                Dim adapter As OleDbDataAdapter = New OleDbDataAdapter()
                'Dim result As DataSet = insertUpdateAccess(sSQL, vCon)
                Dim result As DataSet = insertUpdateAccess(sSQL, Change_Add_Tree.strCon)

                check = 0
                '    ▼▼  만약 조회가 안 됐다면 ?  새 항목
                If result Is Nothing Then
                    ' is it insert
                    Dim Sql As String

                    Sql = "INSERT INTO 검계_DB ([App Name], Feature, 변경점, [변경점 내용], Project, Model, 차수, 사업자, 업체명, 파일명) " &
                        "values('" & sz1 & "','" + sz2 + "','" + sz3 + "','" + sz4 + "','" + sz5 + "','" + sz6 + "','" + sz7 + "','" + sz8 + "','" + sz9 + "','" + "Qportal_System" + "');"

                    myCmd = New OleDbCommand(Sql, vConn)
                    check = myCmd.ExecuteNonQuery()
                    nCnt_insert += 1

                Else '◀◀ 기존 데이터와 덮어쓰기 해야 한다면
                    Dim nNum As Integer = result.Tables(0).Rows(0)(0)
                    Dim sql As String

                    sql = "UPDATE 검계_DB SET [App Name] ='" & sz1 & "', Feature ='" & sz2 & "', 변경점 ='" & sz3 & "', [변경점 내용] ='" & sz4 & "', Project ='" & sz5 & "', Model ='" & sz6 & "', 차수 ='" & sz7 & "', 사업자 ='" & sz8 & "', 업체명 ='" & sz9 & "'"
                    sql = sql & " WHERE ID = " & nNum
                    myCmd = New OleDbCommand(sql, vConn)
                    check = myCmd.ExecuteNonQuery()
                    nCnt_update += 1

                End If

            Next

            'Connect 해제
            vConn.Close()
            vConn = Nothing

            'MessageBox.Show("App Mapping이 완료 되었습니다.")
            CreateObject("WScript.Shell").Popup("업데이트 : " & nCnt_update & "완료되었습니다.", 1, "Q-Portal")
            CreateObject("WScript.Shell").Popup("새로추가 : " & nCnt_insert & "완료되었습니다.", 1, "Q-Portal")
            '                                        팝업       , Timer,  Title
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Function insertUpdateAccess(ByRef szSQL As String, Conn As String) As DataSet
        '----------------------------------------
        ' 제작 : Devil's
        ' 날짜 : 2018-02-07
        ' 내용 : VB.NET ADODB 함수
        '----------------------------------------
        Dim rs As New ADODB.Recordset()
        Dim MyCn As New ADODB.Connection()
        Dim myDS As DataSet
        'MyCn.Open(Conn)

        Dim strCon As String = Nothing
        Dim nID As Integer = Nothing

        rs.Open(szSQL, Conn, CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockOptimistic)

        If rs.RecordCount = 0 Then
            rs = Nothing
            Exit Function
        Else
            Dim myDA As OleDbDataAdapter = New OleDbDataAdapter()
            myDS = New DataSet()
            myDA.Fill(myDS, rs, "Table Name")
            insertUpdateAccess = myDS
            rs = Nothing

            Exit Function
        End If

    End Function



    Private Sub treeView_App_DoubleClick(sender As Object, e As EventArgs) Handles treeView_App.DoubleClick


        DataGridView1.ClearSelection()

        '------------------------------------------------------
        ' Check Duplication items using loop
        '------------------------------------------------------
        Dim szApp As String = treeView_App.SelectedNode.Text
        ' Dim szFea As String = "기능"
        ' Dim szChange As String = lst_Change.SelectedItem
        '  Dim szChange_Result As String = txt_Change_result.Text
        'Dim szPro As String = txt_pro_in.Text
        'Dim szMod As String = txt_model_in.Text
        'Dim szStep As String = txt_step_in.Text
        'Dim szSuffix As String = txt_suffix_in.Text
        'Dim szComp As String = txt_Comp.Text

        ' check duplicate 
        ' text sum =   App &  변경점  & 
        Dim strSum = szApp

        ' text sum on DataGridView Values
        Dim strGridSum = Nothing
        Dim Num As Integer = 1
        Dim i As Integer = 1
        Dim j As Integer = 1


        Try

            index = DataGridView1.RowCount

            For i = 0 To DataGridView1.RowCount - 1
                strGridSum = ""
                For j = 0 To DataGridView1.ColumnCount - 1 ' 

                    If j = 0 Then

                        Dim dt = DataGridView1.DataSource
                        strGridSum = strGridSum & DataGridView1.Item(j, i).Value
                        'strGridSum = strGridSum & DataGridView1.Rows(i).Cells(j).Value.ToString()
                        'strGridSum = strGridSum & DataGridView1.Rows(i)
                    End If

                    If strSum = strGridSum Then
                        MsgBox("같은 내용이 중복됩니다. 다른 항목을 추가 해주세요.")
                        Exit Sub
                    End If
                Next

            Next
            index += 1

            Dim dt2 As DataTable = DataGridView1.DataSource
            Dim dr As DataRow = dt2.NewRow
            dr.Item("App Name") = szApp

            dt2.Rows.Add(dr)
            DataGridView1.DataSource = dt2
            ' DataGridView1.Rows.Add({szApp, "", ""})



        Catch ex As Exception
            MsgBox(ex.Message)
        End Try



    End Sub


End Class


