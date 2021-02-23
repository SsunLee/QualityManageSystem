Imports System.Collections.Generic
Imports System.Data
Imports System.Data.OleDb
Imports System.Diagnostics
Imports System.IO
Imports System.Windows.Forms
Imports System.Reflection
Imports Microsoft.Office.Interop
Imports Microsoft.Office.Interop.Excel
Imports DataTable = System.Data.DataTable
Imports OleDbConnection = System.Data.OleDb.OleDbConnection
Imports Application = System.Windows.Forms.Application

Public Class M_Model_Plan_Mapp
    Public DS As DataSet = New DataSet
    Public DA As OleDbDataAdapter = New OleDbDataAdapter()
    Public strSQL As String
    Public InfoConn As OleDb.OleDbConnection

    Dim table_Merge As New Data.DataTable("table_Merge")
    Dim index As Integer = 1
    Dim increment As Integer = 0
    Public dtGrid As Data.DataTable = New Data.DataTable()
    'Public strCon As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\WorkSpace\01. Work\2018\02. February\0213\QPortalDB.accdb;Jet OLEDB:Database Password = lge1234;"
    Public XML As New XML
    Dim p As New SaveTable

#Region "모델정보 입력 후 검색할 때"
    Private Sub btn_Search_Click(sender As Object, e As EventArgs) Handles btn_Search.Click

        ' -------------------------------------------------------------------------------
        ' 제작 : 이순배
        ' 날짜 : 2018-01-31
        ' 내용 : 엑셀에 있는 모델 및 변경점 정보를 가져와서 뿌리는 거
        '-------------------------------------------------------------------------------

        Try

            Dim strSht As String = "기능변경점_DB"
            Dim vCon As String = Nothing
            XML.vCon_Call(vCon)
            'vConn = New OleDbConnection(vCon)
            Dim Change_Add_Tree As New Change_Add_Tree

            InfoConn = New OleDb.OleDbConnection(Change_Add_Tree.strCon)

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

            Dim vSQL As String = "SELECT [Project], [Model], [변경점], [변경점 내용], [분류]" & " "
            vSQL = vSQL + "FROM [" & strSht & "] as m" & " Where ID > 0 " & szModel & szPro

            Dim sSQL = "SELECT * FROM [" & "AppList" & "] as m Where ID > 0 "

            DS.Clear()

            '# Project 와 Model 정보만 가져오는 용도의 Dataset 
            DA = New OleDbDataAdapter(vSQL, InfoConn)

            Dim ds_ModelInfo As DataSet = New DataSet()
            DA.Fill(ds_ModelInfo, strSht)      '# Fill Option 으로 
            Dim modTable As DataTable = New DataTable
            modTable = ds_ModelInfo.Tables(0)

            DA = New OleDbDataAdapter(vSQL, InfoConn)
            DA.Fill(DS, strSht)

            DA = New OleDbDataAdapter(sSQL, InfoConn)

            DA.Fill(DS, "App_List")

            Dim Table As Data.DataTable = DS.Tables(0)


            Dim aTable As DataTable = DS.Tables(1)

            'Tree View에 모델 프로젝트
            Call BuildTree_Multi(modTable, trvInfo, 0, 1, expandAll:=False)

            'Tree View에 App만 보여주기
            Call BuildTree_Multi(aTable, treeView_App, 1, 2, expandAll:=False)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
#End Region


#Region "[노드찾기함수_1]"
    Private Function Searchnode(ByVal nodetext As String, ByVal trv As TreeView) As TreeNode
        For Each node As TreeNode In trv.Nodes
            If node.Text = nodetext Then
                Return node
            End If
        Next
    End Function
#End Region
#Region "[노드찾기함수_2]"
    Private Function Searchnode_sub(ByVal nodetext As String, ByVal node As TreeNode) As TreeNode
        Dim trReturn As TreeNode = Nothing
        For Each keyNode As TreeNode In node.Nodes
            If keyNode.Text = nodetext Then
                '일치하는 노드가 있을 시 반환
                trReturn = keyNode
                Exit For
            End If
        Next
        Return trReturn
    End Function
#End Region

#Region "엔터키 쳤을 때도 검색하게"
    Private Sub txt_model_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_model.KeyPress, txt_Project.KeyPress
        If e.KeyChar = Convert.ToChar(13) Then  ' ToChar <-- 13번 값은 Enter 임.
            Call btn_Search_Click(sender, e)   ' 다른 프로시져 호출
        End If
    End Sub
#End Region

#Region "좌측 모델 클릭 시 변경점 보여주기"
    Private Sub TreeView1_DoubleClick(sender As Object, e As EventArgs) Handles trvInfo.AfterSelect
        ' -------------------------------------------------------------------------------
        ' 내용 : 프로젝트 모델 더블 클릭 시 리스트박스에 변경점 보여주는 거
        '-------------------------------------------------------------------------------
        Dim sNode As String
        Dim pNode As String
        Dim stemp As String : Dim var() As String
        Try
            stemp = trvInfo.SelectedNode.FullPath
            var = Split(stemp, "\")
        Catch ex As Exception
            Debug.Print(ex.Message)
            Debug.Print(ex.HelpLink)
            Debug.Print(ex.GetHashCode)
            Exit Sub

        End Try


        Select Case var.Length
            Case 2

                pNode = var(0)
                sNode = var(1)

                txt_pro_in.Text = pNode
                txt_model_in.Text = sNode

                Dim Table As DataTable = DS.Tables(0)

                Dim dv As DataView = Table.DefaultView
                dv.RowFilter = "Project = '" & txt_pro_in.Text & "' and Model = '" & txt_model_in.Text & "'"

                Table = dv.ToTable

                p.SaveTable(Table)

                Call BuildTree_Multi(Table, TreeView1, 4, 2, expandAll:=False)

        End Select


    End Sub
#End Region

#Region "(미사용)변경점 눌렀을 때"
    Private Sub lst_Change_SelectedIndexChanged(sender As Object, e As EventArgs)
        ' -------------------------------------------------------------------------------
        ' 내용 : 변경점 클릭 했을 때 변경점의 내용 보여주는 부분
        '-------------------------------------------------------------------------------

        Dim Table As DataTable = DS.Tables(0)
        Dim szResult As String = Nothing
        Dim nodePath As String = TreeView1.SelectedNode.FullPath


        txt_Change_result.Text = ""

        For i As Integer = 0 To Table.Rows.Count - 1    ' Data table Row 만큼 반복 -1은 마지막행은 Null
            'If txt_pro_in.Text = Table.Rows(i)(0).ToString() And txt_model_in.Text = Table.Rows(i)(1).ToString() And lst_Change.Text = Table.Rows(i)(2).ToString() Then
            If txt_pro_in.Text = Table.Rows(i)(0).ToString() And txt_model_in.Text = Table.Rows(i)(1).ToString() And TreeView1.SelectedNode.Text = Table.Rows(i)(2).ToString() Then
                Try
                    ' ▼▼ 상세 내용 
                    szResult = Table.Rows(i)(3).ToString()
                    txt_Change_result.Text = Replace(szResult, Chr(10), Chr(13) & Chr(10))


                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try

            End If
        Next
    End Sub
#End Region

#Region "처음 로드될 때"
    Private Sub Func_Change_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' -------------------------------------------------------------------------------
        ' 내용 : 처음 기능 변경점 매핑 눌렀을 때 
        '-------------------------------------------------------------------------------
        ' Get Information of Company at My Computer System Name 
        Icon = My.Resources.Qportal_Icon
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
        Dim strcolumns = {"AppName", "Feature", "변경점", "변경점 내용", "Project", "Model", "차수", "사업자", "업체명"}
        Dim rowPosition As Integer = DataGridView1.Rows.Count

        For Each a As String In strcolumns
            dtGrid.Columns.Add(New DataColumn(a))
        Next

        DataGridView1.DataSource = dtGrid



    End Sub
#End Region

#Region "실제 앱 맵핑할 때"
    Private Sub treeView_App_DoubleClick(sender As Object, e As EventArgs) Handles treeView_App.DoubleClick

        ' -------------------------------------------------------------------------------
        ' 제작 : 이순배
        ' 날짜 : 2018-01-31
        ' 내용 : 더블 클릭 시 데이터 그리드뷰에 내용 추가 하기
        '-------------------------------------------------------------------------------

        If txt_step_in.Text = "" Or txt_suffix_in.Text = "" Then
            MsgBox("차수 와 사업자를 입력 후 다시 시도 해주세요.")
            Exit Sub
        End If

        '------------------------------------------------------
        ' Check Duplication items using loop
        '------------------------------------------------------
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

        Dim szApp As String = Nothing

        ' 만약 선택 한 앱이 사업자별 앱이면 ex) U+_UBox
        Select Case node_First
            Case "KT", "SKT", "U+"
                szApp = node_First & "_" & node_Second
            Case "LG"
                szApp = node_Second
            Case Else
                szApp = node_Second
        End Select

        Dim szFea As String = "기능" & "_" & txt_step_in.Text
        'Dim szChange As String = lst_Change.SelectedItem
        Dim szChange As String = TreeView1.SelectedNode.Text
        Dim szChange_Result As String = txt_Change_result.Text
        Dim szPro As String = txt_pro_in.Text
        Dim szMod As String = txt_model_in.Text
        Dim szStep As String = txt_step_in.Text
        Dim szSuffix As String = txt_suffix_in.Text
        Dim szComp As String = txt_Comp.Text

        'szChange = "[" & szChange & "]" & vbCrLf & szChange_Result

        Dim strSum = szApp & szFea & szChange & szPro & szMod & szStep & szSuffix & szComp

        ' text sum on DataGridView Values
        Dim strGridSum = Nothing
        Dim Num As Integer = 1
        Dim i As Integer = 1
        Dim j As Integer = 1
        Dim blTrue As Boolean = True
        ' Dim szQuery As String() = New String() {szSQL, szSQL_Type, szSht_TD, szConC, szConI, szConM}
        Try
            Dim strCheck As String
            dtGrid.AcceptChanges() ' Refresh the data Table

            ' Check Duplicate DataTable Rows
            For Each dtRow As DataRow In dtGrid.Rows
                blTrue = False
                strCheck = dtRow("AppName") & dtRow("Feature") & dtRow("변경점") & dtRow("Project") & dtRow("Model") & dtRow("차수") & dtRow("사업자") & dtRow("업체명")
                If strSum = strCheck Then
                    'is it dupl
                    MessageBox.Show("이미 추가 된 항목 입니다.")
                    Exit Sub
                End If
            Next

            ' if when datatable rows Zero then 
            If dtGrid.Rows.Count = 0 Then
                index = 1
            Else
                index = dtGrid.Rows.Count + 1
            End If

            ' Adding Vlaues [Object 에
            Dim rowValues(8) As Object
            rowValues(0) = szApp
            rowValues(1) = szFea
            rowValues(2) = szChange
            rowValues(3) = szChange_Result
            rowValues(4) = szPro
            rowValues(5) = szMod
            rowValues(6) = szStep
            rowValues(7) = szSuffix
            rowValues(8) = szComp


            Dim dRow As DataRow
            dRow = dtGrid.Rows.Add(rowValues)
            dtGrid.AcceptChanges()

            'datasource Bind
            DataGridView1.DataSource = dtGrid

            'Call SetDoubleBuffered(DataGridView1, True)


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


    End Sub
#End Region

#Region "데이터그리드뷰에서 DB로 올릴 때"
    Sub InsertData(sender As Object, e As EventArgs) Handles Button1.Click
        ' -------------------------------------------------------------------------------
        ' 내용 : DataGridView에 있는 자료를 DB에 올리는 것
        '-------------------------------------------------------------------------------

        Dim vSQL As String = Nothing
        Dim strSht As String = "Sheet1"
        Dim DS As DataSet = New DataSet
        Dim DA As OleDbDataAdapter = New OleDbDataAdapter
        Dim vCon As String = Nothing
        Dim vConn As OleDbConnection
        Dim nID As Integer = Nothing
        Dim strExcelFileName As String = Nothing
        Dim XML As New XML

        Try
            'Dim strCon As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\WorkSpace\01. Work\2018\02. February\0201\QPortalDB.accdb;Jet OLEDB:Database Password = lge1234;"
            'Dim strCon As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=\\10.169.88.40\Q-Portal\4.etc\QPortalDB.accdb;Jet OLEDB:Database Password = lge1234;"
            Dim nCnt_update As Integer = 0
            Dim nCnt_insert As Integer = 0

            XML.vCon_Call(vCon)
            Dim Change_Add_Tree As New Change_Add_Tree
            vConn = New OleDbConnection(Change_Add_Tree.strCon)   ' MainForm의 Connection String으로 DB Connect

            'vConn = New OleDbConnection(strCon)
            vConn.Open()

            '  ▼▼▼  DataGrid View에 있는 Data들을 Data Table에 한꺼번에 담음.
            Dim dt As New DataTable()
            dt = TryCast(DataGridView1.DataSource, DataTable)
            ' Table Name = "검계_DB"
            Try

                For value As Integer = 0 To dt.Rows.Count - 1

                    ' String 변수에 담음
                    Dim sz1 As String = Convert.ToString(dt.Rows(value).ItemArray.GetValue(0))  '// APP Name 
                    Dim sz2 As String = Convert.ToString(dt.Rows(value).ItemArray.GetValue(1))    '// Feature
                    Dim sz3 As String = Convert.ToString(dt.Rows(value).ItemArray.GetValue(2))  '// 변경점
                    Dim SZ4 As String = Convert.ToString(dt.Rows(value).ItemArray.GetValue(3))  '// 변경점 내용
                    Dim sz5 As String = txt_pro_in.Text                                         '// Project
                    Dim sz6 As String = txt_model_in.Text                                       '// Model
                    Dim sz7 As String = txt_step_in.Text                                        '// Step
                    Dim sz8 As String = txt_suffix_in.Text                                      '// Suffix
                    Dim sz9 As String = txt_Comp.Text                                           '// Compnay

                    sz1 = Replace(sz1, "'", "") ' App
                    sz2 = Replace(sz2, "'", "") ' Feature


                    sz3 = Replace(sz3, "'", "")
                    Dim sTemp As String = sz3
                    sTemp = Replace(sTemp, "[", "")


                    Dim sz
                    sz = Split(sTemp, "-")
                    sTemp = ""
                    For Each s As String In sz
                        sTemp = sTemp & " " & s
                    Next

                    sTemp = LTrim(sTemp)

                    SZ4 = Replace(SZ4, "'", "")
                    sz5 = Replace(sz5, "'", "")
                    sz6 = Replace(sz6, "'", "")
                    sz7 = Replace(sz7, "'", "")
                    sz8 = Replace(sz8, "'", "")


                    Dim vSQL1 As String, vSQL2 As String, vSQL4 As String, vSQL5 As String, vSQL6 As String
                    Dim vSQL7 As String, vSQL3 As String
                    Dim temp1 As String = Nothing, temp2 As String = Nothing
                    ' 기존 Data 있는지 Check 하기 위한 Query 작성
                    vSQL1 = "[App Name] = '" & Replace(sz1, "'", "''") & "'"
                    vSQL2 = " AND [Feature] = '" & Replace(sz2, "'", "''") & "'"
                    vSQL3 = " AND [변경점] = '" & Replace(sTemp, "'", "''") & "'"
                    vSQL4 = " AND [Project] = '" & Replace(sz5, "'", "''") & "'"
                    vSQL5 = " AND [Model] = '" & Replace(sz6, "'", "''") & "'"
                    vSQL6 = " AND [차수] = '" & Replace(sz7, "'", "''") & "'"
                    vSQL7 = " AND [사업자] = '" & Replace(sz8, "'", "''") & "'"
                    'vSQL8 = " AND [업체명] LIKE '%" & Replace(sz9, "'", "''") & "%'"

                    '    ▼▼ 이미 DB에 있는 것 인지? Check 함
                    Dim sSQL As String = "SELECT ID, [App Name], Feature, 변경점, Project, Model, 차수, 사업자, 업체명 FROM 검계_DB"
                    sSQL = sSQL & " WHERE " & vSQL1 & vSQL2 & vSQL3 & vSQL4 & vSQL5 & vSQL6 & vSQL7 '& vSQL8


                    Dim result As DataTable = New DataTable
                    Dim myCmd As OleDbCommand
                    Dim check As Integer
                    Dim cmd As OleDbCommand = New OleDbCommand(sSQL, vConn)
                    '     ▼▼ Data Adapter를 사용해 Data Table을 만들고 Query 된 Result를 Count 하여 기존 Data가 있는지 Check 
                    Dim adapter As OleDbDataAdapter = New OleDbDataAdapter(cmd)
                    adapter.Fill(result)

                    '    ▼▼  만약 조회가 안 됐다면 ?  새 항목
                    If result.Rows.Count = 0 Then
                        ' is it insert
                        Dim Sql As String = "INSERT INTO 검계_DB ([App Name], Feature, 변경점, [변경점 내용], Project, Model, 차수, 사업자, 업체명, 파일명) " &
                        "values('" & sz1 & "','" + sz2 + "','" + sz3 + "','" + SZ4 + "','" + sz5 + "','" + sz6 + "','" + sz7 + "','" + sz8 + "','" + sz9 + "','" + "Qportal_System" + "');"
                        myCmd = New OleDbCommand(Sql, vConn)
                        check = myCmd.ExecuteNonQuery()
                        nCnt_insert += 1

                    Else '◀◀ 기존 데이터와 덮어쓰기 해야 한다면

                        Dim sql As String = "UPDATE 검계_DB SET [App Name] ='" & sz1 & "', Feature ='" & sz2 & "', 변경점 ='" & sz3 & "', [변경점 내용] ='" & SZ4 & "', Project ='" & sz5 & "', Model ='" & sz6 & "', 차수 ='" & sz7 & "', 사업자 ='" & sz8 & "', 업체명 ='" & sz9 & "'"
                        sql = sql & " WHERE ID = " & result.Rows(0)(0).ToString()
                        myCmd = New OleDbCommand(sql, vConn)
                        check = myCmd.ExecuteNonQuery()
                        nCnt_update += 1
                    End If

                Next


            Catch ex As Exception
                MessageBox.Show(ex.ToString())
            End Try

            'Connect 해제
            vConn.Close()
            vConn = Nothing

            CreateObject("WScript.Shell").Popup("업데이트 : " & nCnt_update & " ◀완료되었습니다.", 1, "Q-Portal")
            CreateObject("WScript.Shell").Popup("새로추가 : " & nCnt_insert & " ◀완료되었습니다.", 1, "Q-Portal")

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Function SQLText(ByVal ST As String) As String
        SQLText = "'" & Replace(ST, "'", "''") & "'"
    End Function

#End Region

#Region "트리뷰 노드제작 관련 함수"
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
#End Region

    Private Sub Func_Change_copy_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        ' Form이 꺼질 때 다시 띄워줌
        Dim pp As New M_Random_Plan_Page
        pp.Show()

    End Sub

    Private Sub releaseObject(ByVal obj As Object)
        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
            obj = Nothing
        Catch ex As Exception
            obj = Nothing
        Finally
            GC.Collect()
        End Try
    End Sub

#Region "[엑셀 파일을 생성 후 조회 값넣고 VBA 하기]"
    Private Sub btn_Excel_Click(sender As Object, e As EventArgs) Handles btn_Excel.Click
        Dim blChk As Boolean = False
        '# Resource에 있는 Excel File 실행 > 입력 칸에 값 넣고 > 코드 실행 > 다른 이름으로 저장 하기 팝업

        '# 지정경로 안에서 '시험기획서_Access_v1.3' 찾기 후 파일 Copy
        Dim dir As DirectoryInfo = New DirectoryInfo("\\10.169.88.40\Q-Portal\2.검증현황\Defect 분석\검증계획서\시험기획서")
        Dim strFile As String = Nothing : Dim strRealFile As String = Nothing
        Dim strFullPath As String = Nothing
        For Each dr In dir.GetFiles()
            strFile = dr.Name   '# file name
            If InStr(strFile, "시험기획서") And Strings.Left(strFile, 2) <> "~$" Then
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

        'File.Copy(strFullPath, Application.StartupPath + strRealFile, True)   '# 파일 붙여 넣기

        '# File saveFileDialog()
        Dim dlg As New SaveFileDialog()
        dlg.FileName = "시험기획서"
        dlg.DefaultExt = ".xlsm"
        dlg.Filter = ""
        dlg.Filter = "Excel File|*.xlsm"
        dlg.Title = "Save an Excel File"

        '# Dialog 화면
        Dim result As Boolean = dlg.ShowDialog()

        If result = True Then
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

        End If

    End Sub

    Public Sub saveExcelFile(ByVal strFileName As String, ByVal FileName As String)
        Dim excel As Excel.Application = New Excel.Application
        Dim m As Workbook = Nothing
        Dim ms As Excel.Worksheet = Nothing

        Try

            m = excel.Workbooks.Open(strFileName,, 2)
            ms = m.Sheets(8)

            excel.Visible = True

            ms.Cells(5, "c") = txt_pro_in.Text          '# Project 정보 입력
            ms.Cells(5, "d") = txt_model_in.Text      '# Model 정보 입력
            ms.Cells(5, "e") = txt_step_in.Text         '# Step 정보 입력
            ms.Cells(5, "f") = txt_suffix_in.Text        '# Suffix 정보 입력

            ms.Cells(5, "c") = "NEO_OOS"
            ms.Cells(5, "d") = " "
            ms.Cells(5, "e") = txt_step_in.Text         '# Step 정보 입력
            ms.Cells(5, "f") = txt_suffix_in.Text        '# Suffix 정보 입력


            Dim runMacro As String = "LoadMan"

            Debug.Print(runMacro)

            excel.Run(runMacro)

            m.SaveAs(FileName)

            m.Close()
            excel.Quit()

            releaseObject(excel)
            releaseObject(m)
        Catch ex As Exception
            releaseObject(Excel)
            releaseObject(m)
        End Try

    End Sub

    Private Sub TreeView1_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles trvInfo.AfterSelect

    End Sub


#Region "변경점 클릭 했을 때 옆에 보여주기"
    Private Sub TreeView1_AfterSelect_1(sender As Object, e As TreeViewEventArgs) Handles TreeView1.AfterSelect

        Dim Table As DataTable = p.getTable()

        If Table Is Nothing Then
            Debug.Print("Table Nothing 반환")
            Exit Sub
        End If


        Dim stemp As String = TreeView1.SelectedNode.FullPath
        Dim var() As String = Split(stemp, "\")

        Dim strOne As String

        Select Case var.Length

            Case 2
                strOne = var(1)     ' 분류
                Try
                    txt_Change_result.Text = "" ' 초기화
                    For i As Integer = 0 To Table.Rows.Count - 1
                        If strOne = Table.Rows(i)("변경점").ToString() Then
                            Dim strText As String = LTrim(Table.Rows(i)("변경점 내용").ToString())
                            txt_Change_result.Text = Replace(strText, Chr(10), Chr(13) & Chr(10))
                        End If
                    Next
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "(Sunbae) - 데이터 오류", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try

        End Select

    End Sub

#End Region


#End Region

End Class


Class SaveTable

    Public tb As DataTable
    Private table As DataTable

    Public Sub SaveTable(tb As DataTable)
        Me.tb = tb
    End Sub

    Public Function getTable() As DataTable
        Return tb
    End Function



End Class