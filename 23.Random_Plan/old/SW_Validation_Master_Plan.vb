Imports System.Data
Imports System.Data.OleDb
Imports System.Diagnostics
Imports System.Drawing
Imports System.Windows.Forms

Public Class SW_Validation_Master_Plan

    Public strCon As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\WorkSpace\01. Work\2018\04. April\0409\QPortalDB.accdb;Jet OLEDB:Database Password = lge1234;"
    Public DS As DataSet = New DataSet
    Public DA As OleDbDataAdapter = New OleDbDataAdapter()
    Public vConn As OleDbConnection = New OleDbConnection
    Public Change_Add_Tree As New Change_Add_Tree
    Public Table As DataTable = New DataTable
    Public dtGrid As DataTable = New DataTable
    '
    'Public Change_Add_Tree As New Change_Add_Tree
    Public dataGridView_form As New dataGridView_form
    Public blchk As Boolean
    Dim WithEvents ti As New Timer

#Region "[폼 로드]"
    Private Sub SW_Validation_Master_Plan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '-----------------------------------------------------
        ' 내 용 : Load할 때 TreeView에 기본? TC? 이런 거 넣기 위함
        '----------------------------------------------------
        'Icon = My.Resources.Qportal_Icon
        Dim toolTip1 As New ToolTip()
        toolTip1.SetToolTip(txtCheckbox, "ex) NEO <- 어디서 진행을 했었다를 적으면 됩니다.")
        ' toolTip1.SetToolTip(ComboBox2, "대분류 카테고리를 선택할 수 있습니다. * 선택하지 않아도 됩니다.")
        ' toolTip1.SetToolTip(TextBox1, "검색어를 입력하세요.")
        'toolTip1.SetToolTip(Button2, "Search")
        toolTip1.InitialDelay = 100
        toolTip1.AutoPopDelay = 1000
        toolTip1.ReshowDelay = 500

        blchk = True

        txtCheckbox.Visible = False

        Dim dt As DataTable = New DataTable
        Dim dRow As DataRow = Nothing
        Dim dCol As DataColumn = Nothing

        ' Data tabel 의 컬럼 생성
        dCol = New DataColumn()
        dCol.DataType = System.Type.GetType("System.String")
        dCol.ColumnName = "Type"
        dt.Columns.Add(dCol)

        dCol = New DataColumn()
        dCol.DataType = System.Type.GetType("System.String")
        dCol.ColumnName = "Result"
        dt.Columns.Add(dCol)

        dt.Rows.Add("Random", "Random_기본")
        dt.Rows.Add("Random", "Random_변경점")

        dt.Rows.Add("목적", "신규시험법개발")
        dt.Rows.Add("목적", "시나리오(FMT)")

        dt.Rows.Add("목적", "MATRIX")
        dt.Rows.Add("목적", "반복")

        dt.Rows.Add("자동화", "기능")
        dt.Rows.Add("자동화", "신뢰성")


        'Tree View에 총합시험기획서의 분류 항목들 보여주는 부분
        Call builed_Treenode(dt, trv_Fundation, 0, 1, 0)
        '-----------------------------------------------W
        txtDescription.Text = "ex) 이전 차수에서 발생했던 것을 참고하여 목적 T/C를 통해 Coverage 확보를 할 것"
        txtDescription.ForeColor = Color.Gray
        ProgressBar1.Visible = False


        Dim XML As New XML
        ' txtRequester 가져오기 (사용자 이름) -----------------------------------------------------------------------------------------------------------------------------------------
        Dim strComputer As String = Nothing
        Dim strName As String = Nothing
        Dim strUser As String = Nothing
        strComputer = "."
        Dim Obj = GetObject("winmgmts:{impersonationLevel=impersonate}!\\" & strComputer & "\root\cimv2").ExecQuery("Select * FROM Win32_OperatingSystem")
        For Each Obj2 In Obj
            strName = Obj2.Description
        Next
        strUser = Strings.Split(strName, "/")(0)       ' 가져온 컴퓨터설명을 Split를 사용하여 만들어진 배열의 의 첫번째 한글이름 만 저장
        txtRequester.Text = strUser    ' 등록자 Textbox에 넣음


        ' txtCompany 가져오기 (업체명)--------------------------------------------------------------------------------------
        Dim strCNS As String = "Contacts_C"                         ' 업체 
        Dim strINFINIQ As String = "Contacts_I"
        Dim strMSTech As String = "Contacts_M"

        Dim szConC As String = "SELECT * FROM [" + strCNS + "]"
        Dim szConI As String = "SELECT * FROM [" + strINFINIQ + "]"
        Dim szConM As String = "SELECT * FROM [" + strMSTech + "]"

        ' String변수에 테이블명과 쿼리문 순차적으로 담음.
        Dim szQuery As String() = New String() {szConC, szConI, szConM}
        Dim loopSht As String() = New String() {strCNS, strINFINIQ, strMSTech}

        Dim nCnt As Integer = 0
        Dim getContact As DataSet = New DataSet

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

        Dim blcp As Boolean = True
        For nZ As Integer = 0 To 2       ' 0~2 까지가 업체테이블임
            For nW = 1 To getContact.Tables(nZ).Rows.Count - 1
                If getContact.Tables(nZ).Rows(nW)(2).ToString() = strUser Then

                    If getContact.Tables(nZ).Rows(nW)(4).ToString() = "CNS" Then    ' CNS의 경우에 LG CNS로 보여주기 위해 Custom
                        txtCompany.Text = "LG " & getContact.Tables(nZ).Rows(nW)(4).ToString()
                    Else
                        txtCompany.Text = getContact.Tables(nZ).Rows(nW)(4).ToString()
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
        '-----------------------------------------------------------------------------------------------------------------------------------------
        ' Add할 때 넘길 데이터를 담을 Datatable 세팅
        ' Data tabel 의 컬럼 생성
        'Dim dtGrid As DataTable = New DataTable
        '# 타이틀 넣어주기
        Dim strColumns As String() = New String() _
        {"구분", "주요변경점", "변경점 내용", "Risk",
        "검증유형", "검증유형내용",
        "Project", "Model", "업체명", "등록자", "TC진행여부", "TC명"}

        For Each a As String In strColumns
            dCol = New DataColumn()
            dCol.DataType = System.Type.GetType("System.String")
            dCol.ColumnName = a
            dtGrid.Columns.Add(dCol)
        Next

    End Sub
#End Region

#Region "[프로젝트 모델 검색 버튼]"
    Private Sub btn_Search_Click_1(sender As Object, e As EventArgs) Handles btn_Search.Click
        '----------------------------------------------------
        '내 용 : 버튼 눌렀을 때 Progress Bar 세팅 해주고 Timer 켜기
        '----------------------------------------------------
        Dim Change_Add_Tree As New Change_Add_Tree

        With ProgressBar1
            .Style = ProgressBarStyle.Continuous
            .Minimum = 0
            .Maximum = 100000
            .Step = 1
            .Value = 0
        End With

        ti.Start()
        trvInfo.Nodes.Clear()

        ' 빈 항목이면 조건에 들어가지 않도록
        Dim vSQLPro As String = Nothing : vSQLPro = IIf(txt_Project.Text = "", "", "AND [Project] LIKE '%" & Replace(txt_Project.Text, "'", "''") & "%'")
        Dim vSQLMod As String = Nothing : vSQLMod = IIf(txt_model.Text = "", "", "AND [Model] LIKE '%" & Replace(txt_model.Text, "'", "''") & "%'")
        Dim sql As String = Nothing
        Dim sht As String = "기능변경점_DB"

        Debug.Print(vSQLPro & Environment.NewLine & vSQLMod)

        ' SQL QUERY 작성   // 검색한 결과에 맞게 내용 가져와서 Type 에다가 자료 넣어줌
        sql = "SELECT * "
        sql = sql & "FROM [" & sht & "] "
        sql = sql & "WHERE ID > 0 And Project is not null " & vSQLPro & vSQLMod

        Dim vCon As String = Nothing
        Dim xml As New XML

        xml.vCon_Call(Change_Add_Tree.strCon) ' xml에서 Connection String 가져옴

        vConn = New OleDbConnection(Change_Add_Tree.strCon)   '// OledbConnection 사용하기 위해 선언 (Connection String 기준으로
        'vConn = New OleDbConnection(strCon)   '// OledbConnection 사용하기 위해 선언 (Connection String 기준으로

        DS.Clear()
        DA = New OleDbDataAdapter(sql, vConn)   '// 모델 정보
        DA.Fill(DS, sht)

        DA = New OleDbDataAdapter(sql, vConn)   '// DataAdapter qsl Query문 기준으로 

        Debug.Print(sql)

        'DA.Fill(DS, sht)

        '# Project 와 Model 정보만 가져오는 용도의 Dataset 
        Dim ds_ModelInfo As DataSet = New DataSet()
        DA.Fill(ds_ModelInfo, sht)      '# Fill Option 으로 

        Dim modTable As DataTable = New DataTable
        modTable = ds_ModelInfo.Tables(0)

        If modTable.Rows.Count = 0 Then
            MessageBox.Show("조회 된 결과가 없습니다.")
        Else

            trvInfo.Nodes.Clear()

            '# 직접 제작한 함수로 Tree View 노드 추가
            Call builed_Treenode(modTable, trvInfo, 3, 4, 0) ' Project / Model 위치
            trvInfo.Sort()

        End If

    End Sub
#End Region


#Region "[Common 등의 Node 함수]"
    Public Sub makeRegion(ByRef modTable As DataTable, ByRef intProNum As Integer, ByRef intModNum As Integer, ByRef intRegionNum As Integer, ByRef trvInfo As TreeView)
        Dim TwoNode As TreeNode
        Dim ThreeNode As TreeNode
        Dim node As TreeNode

        'nodeCommon = New TreeNode("Common", 0, 0)
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
#End Region

    '# Tick Event
    Private Sub btn_Search_Click(sender As Object, e As EventArgs) Handles ti.Tick
        '----------------------------------------------------
        '내 용 : Timer 이벤트가 발생하면 이곳으로 들어와서 Max값 까지 Progress Bar 올려줌
        '----------------------------------------------------
        ProgressBar1.Visible = True
        ti.Enabled = False
        ti.Dispose()

        Dim myMax As Integer = 100000

        For i As Integer = 0 To myMax
            If i Mod 100 = 0 Then
                ProgressBar1.Value = i
                If ProgressBar1.Value > 0 Then ProgressBar1.Value -= 1
            End If
        Next

        ProgressBar1.Value = myMax
        ProgressBar1.Visible = False

    End Sub

#Region "TreeView - [모델 > 변경점] "
    Private Sub Project_to_ChangeNote(sender As Object, e As TreeViewEventArgs) Handles trvInfo.AfterSelect

        '# 기존 Items Clear
        lstChangeNote.Items.Clear()

        Debug.Print(trvInfo.SelectedNode.FullPath)  '# 선택한 Node의 값을 확인 하기 위해.

        Dim stemp As String = trvInfo.SelectedNode.FullPath
        Dim var() As String = Split(stemp, "\")
        Select Case var.Length
            Case 2
                Debug.Print(var(0) & " and " & var(1))
                Dim strPro As String = var(0)       '# Project 
                Dim strMod As String = var(1)     '# Model

                Dim Table As DataTable = DS.Tables(0)

                For i As Integer = 0 To Table.Rows.Count - 1    ' Data table Row 만큼 반복 -1은 마지막행은 Null

                    If strPro = Table.Rows(i)(3).ToString() And strMod = Table.Rows(i)(4).ToString() Then
                        Try
                            Debug.Print("Project : " & Table.Rows(i)(3).ToString())    '# DataTable - Project
                            Debug.Print("Model : " & Table.Rows(i)(4).ToString())    '# DataTable - Project

                            ' ▼▼ 중복 제거 후 변경점 담기
                            If Not lstChangeNote.Items.Contains(Table.Rows(i)(1).ToString()) Then
                                lstChangeNote.Items.Add(Table.Rows(i)(1).ToString())
                            End If

                        Catch ex As Exception
                            MsgBox(ex.Message)
                        End Try

                    End If
                Next



        End Select




    End Sub
#End Region



#Region "[타입]-> 텍스트"
    'Private Sub trv_Type_AfterSelect(sender As Object, e As TreeViewEventArgs)
    '    '--------------------------------------------
    '    ' 내 용 : 키워드 선택 시 상세 설명 보여주는 것
    '    '--------------------------------------------
    '    Dim stemp As String = trv_Type.SelectedNode.FullPath
    '    Dim var() As String = Split(stemp, "\")

    '    Dim strOne As String = Nothing
    '    Dim strTwo As String = Nothing
    '    Dim strThree As String = Nothing

    '    ' 기존 데이터 클리어
    '    txtRisk.Text = ""
    '    txtDes.Text = ""

    '    Select Case var.Length
    '        Case 3

    '            strOne = LTrim(var(0))     ' 선택 한 노드의 값들을 저장
    '            strTwo = LTrim(var(1))
    '            strThree = LTrim(var(2))

    '            txtType.Text = strOne
    '            txtType2.Text = strTwo
    '            txtType3.Text = strThree

    '            For i As Integer = 0 To Table.Rows.Count - 1
    '                If strOne = LTrim(Table.Rows(i)(1).ToString()) And strTwo = LTrim(Table.Rows(i)(2).ToString()) And strThree = LTrim(Table.Rows(i)(3).ToString()) Then
    '                    Dim strText As String = LTrim(Table.Rows(i)(4).ToString())
    '                    Dim strText_Risk As String = LTrim(Table.Rows(i)(5).ToString())

    '                    txtDes.Text = Replace(strText, Chr(10), Chr(13) & Chr(10))
    '                    txtRisk.Text = Replace(strText_Risk, Chr(10), Chr(13) & Chr(10))

    '                End If
    '            Next

    '    End Select


    'End Sub
#End Region

    Private Sub btn_add_Click(sender As Object, e As EventArgs) Handles btn_add.Click
        '-------------------------------------------------------
        ' 내 용 :  "등록" 버튼 눌렀을 때 Event
        '-------------------------------------------------------

        ' 채워지지 않은 내용이 있는 경우 예외처리
        Dim message As String = "선택하지 않은 항목이 있습니다. 다시 확인 해주세요."
        Dim caption As String = "lee.sunbae@lgepartner.com"


        If txtSelected.Text = "" Or txtType.Text = "" Or txtType2.Text = "" Or txtType3.Text = "" Or txtProject.Text = "" Or txtModel.Text = "" Or txtCheckbox.Text = "" Or txtTCName.Text = "" Then
            MessageBox.Show(message, caption)
            Exit Sub
        End If

        Dim rowValues(11) As Object
        rowValues(0) = txtType.Text                                     ' 구분 ex) O-OS 변경점
        rowValues(1) = txtType2.Text & "_" & txtType3.Text    ' 주요변경점 Notification_Launcher_Home

        rowValues(2) = txtDes.Text                                      ' 변경점 내용
        rowValues(3) = txtRisk.Text                                     ' 리스크

        rowValues(4) = txtSelected.Text                               ' 검증유형 부분에 Random_기본 뭐 이런 값
        rowValues(5) = txtDescription.Text                           ' 기획방안내용 작성

        rowValues(6) = txtProject.Text                                  ' Project
        rowValues(7) = txtModel.Text                                   ' Model

        rowValues(8) = txtCompany.Text                              '업체명
        rowValues(9) = txtRequester.Text                            ' 등록자

        rowValues(10) = txtCheckbox.Text                            ' T/C 진행 여부 
        rowValues(11) = txtTCName.Text                             ' T/C Name

        'Dim dataGridTable As DataTable = New DataTable
        Dim dRow As DataRow
        dRow = dtGrid.Rows.Add(rowValues)   ' DataRow를 통해 Array 값 넣어주고 DataTable Row에 값 대입
        dtGrid.AcceptChanges()                    ' Datatable Update
        dataGridView_form.DataGridView1.DataSource = dtGrid     ' 넘길 Form의 DataGridView에 자료 넘기기

        dataGridView_form.txt_Comp.Text = txtCompany.Text        ' 넘길 Form의 TextBox에 자료 넘기기 (업체명)
        dataGridView_form.txt_pro_in.Text = txtProject.Text           ' 넘길 Form의 TextBox에 자료 넘기기 (Project)
        dataGridView_form.txt_model_in.Text = txtModel.Text        ' 넘길 Form의 TextBox에 자료 넘기기 (Model)

        dataGridView_form.txtCompnay_in.Text = txtCompany.Text        ' 넘길 Form의 TextBox에 자료 넘기기 (Model)
        dataGridView_form.txtRequest_in.Text = txtRequester.Text        ' 넘길 Form의 TextBox에 자료 넘기기 (Model)



        MessageBox.Show("추가 됨")
        If blchk = True Then
            dataGridView_form.Show()   ' DataGridView가 있는 Form 보여주기
            blchk = False
        Else
            dataGridView_form.Visible = False   ' 처음에만 켜질 수 있도록 하고 그 이후에는 Visible Option만 
        End If

    End Sub

    Private Sub trv_Fundation_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles trv_Fundation.AfterSelect
        '--------------------------------------------
        ' 내 용 : 시험 기획 타겟 선택 시 텍스트 박스에 뿌려주기
        '--------------------------------------------
        Dim stemp As String = trv_Fundation.SelectedNode.FullPath
        Dim var() As String = Split(stemp, "\")

        Dim strSelect As String = Nothing

        Select Case var.Length
            Case 2
                strSelect = var(1)
                txtSelected.Text = strSelect
        End Select
    End Sub




#Region "[미사용-TreeView]"
    'Private Sub trvInfo_AfterSelect(sender As Object, e As TreeViewEventArgs)
    '    '-----------------------------------------------------
    '    ' 내 용 : 모델 정보 눌렀을 때 Type 내용 나오도록 
    '    '-----------------------------------------------------

    '    'Tree View [Type] 에 총합시험기획서의 분류 항목들 보여주는 부분
    '    ' 이건 그냥 보여주는 것 
    '    '기존 TreeView Clear
    '    trv_Type.Nodes.Clear()
    '    Table.Clear()
    '    txtDes.Text = ""
    '    txtRisk.Text = ""

    '    'Call builed_Treenode(Table, TreeView2, 1, 2, 3)
    '    Dim stemp As String = trvInfo.SelectedNode.FullPath
    '    Dim var() As String = Split(stemp, "\")

    '    Dim strProject As String = Nothing
    '    Dim strModel As String = Nothing

    '    Dim vSQLPro As String = Nothing
    '    Dim vSQLCom As String = Nothing

    '    Try
    '        Select Case var.Length
    '            Case Else
    '                If var(1) = "Common" Then '--------------------------------------------------------------------------------------------------------
    '                    strProject = var(0)
    '                    strCommon = "Project"

    '                    vSQLPro = "AND [Project] = '" & Replace(strProject, "'", "''") & "'"
    '                    vSQLCom = " AND [공통] = '" & Replace(strCommon, "'", "''") & "'"

    '                    Dim sql As String = Nothing
    '                    Dim sht As String = "SW_Validation"

    '                    ' SQL QUERY 작성   // 검색한 결과에 맞게 내용 가져와서 Type 에다가 자료 넣어줌
    '                    sql = "SELECT * "
    '                    sql = sql & "FROM [" & sht & "] "
    '                    sql = sql & "WHERE ID > 0 " & vSQLPro & vSQLCom

    '                    Dim vCon As String = Nothing
    '                    Dim xml As New XML

    '                    xml.vCon_Call(vCon) ' xml에서 Connection String 가져옴

    '                    vConn = New OleDbConnection(Change_Add_Tree.strCon)   '// OledbConnection 사용하기 위해 선언 (Connection String 기준으로
    '                    'vConn = New OleDbConnection(strCon)   '// OledbConnection 사용하기 위해 선언 (Connection String 기준으로

    '                    'Dim Table As DataTable = New DataTable
    '                    Dim cmd As OleDbCommand = New OleDbCommand(sql, vConn)
    '                    '     ▼▼ Data Adapter를 사용해 Data Table을 만들고 Query 된 Result를 Count 하여 기존 Data가 있는지 Check 
    '                    Dim adapter As OleDbDataAdapter = New OleDbDataAdapter(cmd)
    '                    adapter.Fill(Table)

    '                    Call builed_Treenode(Table, trv_Type, 1, 2, 3)

    '                ElseIf var(1) = "Region" Then '--------------------------------------------------------------------------------------------------------
    '                    strProject = var(0)
    '                    strCommon = "Project"
    '                    strModel = "Model"

    '                    strRegion = var(2)

    '                    vSQLPro = "AND [Project] = '" & Replace(strProject, "'", "''") & "'"
    '                    vSQLCom = " AND [공통] <> '" & Replace(strCommon, "'", "''") & "'"
    '                    vSQLMod = " AND [공통] <> '" & Replace(strModel, "'", "''") & "'"
    '                    vSQLRegion = " AND [공통] = '" & Replace(strRegion, "'", "''") & "'"

    '                    Dim sql As String = Nothing
    '                    Dim sht As String = "SW_Validation"

    '                    ' SQL QUERY 작성   // 검색한 결과에 맞게 내용 가져와서 Type 에다가 자료 넣어줌
    '                    sql = "SELECT * "
    '                    sql = sql & "FROM [" & sht & "] "
    '                    sql = sql & "WHERE ID > 0 " & vSQLPro & vSQLCom & vSQLMod & vSQLRegion

    '                    Dim vCon As String = Nothing
    '                    Dim xml As New XML

    '                    xml.vCon_Call(vCon) ' xml에서 Connection String 가져옴

    '                    'vConn = New OleDbConnection(vCon)   '// OledbConnection 사용하기 위해 선언 (Connection String 기준으로
    '                    vConn = New OleDbConnection(Change_Add_Tree.strCon)   '// OledbConnection 사용하기 위해 선언 (Connection String 기준으로

    '                    'Dim Table As DataTable = New DataTable
    '                    Dim cmd As OleDbCommand = New OleDbCommand(sql, vConn)
    '                    '     ▼▼ Data Adapter를 사용해 Data Table을 만들고 Query 된 Result를 Count 하여 기존 Data가 있는지 Check 
    '                    Dim adapter As OleDbDataAdapter = New OleDbDataAdapter(cmd)
    '                    adapter.Fill(Table)

    '                    Call builed_Treenode(Table, trv_Type, 1, 2, 3)

    '                ElseIf var(1) = "Model" Then '--------------------------------------------------------------------------------------------------------

    '                    strProject = var(0)
    '                    strCommon = "Project"
    '                    strModel = var(2)

    '                    strRegion = "Model"

    '                    vSQLPro = "AND [Project] = '" & Replace(strProject, "'", "''") & "'"
    '                    vSQLMod = " AND [Model] = '" & Replace(strModel, "'", "''") & "'"
    '                    vSQLRegion = " AND [공통] = '" & Replace(strRegion, "'", "''") & "'"

    '                    Dim sql As String = Nothing
    '                    Dim sht As String = "SW_Validation"

    '                    ' SQL QUERY 작성   // 검색한 결과에 맞게 내용 가져와서 Type 에다가 자료 넣어줌
    '                    sql = "SELECT * "
    '                    sql = sql & "FROM [" & sht & "] "
    '                    sql = sql & "WHERE ID > 0 " & vSQLPro & vSQLCom & vSQLMod & vSQLRegion

    '                    Dim vCon As String = Nothing
    '                    Dim xml As New XML

    '                    xml.vCon_Call(vCon) ' xml에서 Connection String 가져옴

    '                    'vConn = New OleDbConnection(vCon)   '// OledbConnection 사용하기 위해 선언 (Connection String 기준으로
    '                    vConn = New OleDbConnection(Change_Add_Tree.strCon)   '// OledbConnection 사용하기 위해 선언 (Connection String 기준으로

    '                    'Dim Table As DataTable = New DataTable
    '                    Dim cmd As OleDbCommand = New OleDbCommand(sql, vConn)
    '                    '     ▼▼ Data Adapter를 사용해 Data Table을 만들고 Query 된 Result를 Count 하여 기존 Data가 있는지 Check 
    '                    Dim adapter As OleDbDataAdapter = New OleDbDataAdapter(cmd)
    '                    adapter.Fill(Table)

    '                    Call builed_Treenode(Table, trv_Type, 1, 2, 3)

    '                End If

    '        End Select
    '    Catch ex As Exception
    '        'MessageBox.Show("하위 항목을 선택 해주세요")
    '    End Try

    'End Sub
#End Region


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        dataGridView_form.Visible = True        ' User Form 미리보기 버튼을 눌렀을 때 Visible Option만 True 해줌.

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
    '해당 노드가 있는지 확인 함
    Private Function Searchnode_third(ByVal nodetext As String, ByVal node As TreeNode) As TreeNode
        For Each keyNode As TreeNode In node.Nodes
            If keyNode.Text = nodetext Then
                '일치하는 노드가 있을 시 반환
                Return keyNode
            End If
        Next
    End Function

    Private Sub txtDescription_TextChanged(sender As Object, e As EventArgs) Handles txtDescription.TextChanged
        ' 기존 내용 눌렀을 때 예제 지워지게 
        If InStr(txtDescription.Text, "ex)") Then
            txtDescription.ForeColor = Color.Black
        End If



    End Sub

    Private Sub txtDescription_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDescription.KeyPress
        If e.KeyChar = Convert.ToChar(13) Then  ' ToChar <-- 13번 값은 Enter 임.
            Call btn_add_Click(sender, e)   ' 다른 프로시져 호출
        End If

    End Sub

    Private Sub chkExcute_CheckedChanged(sender As Object, e As EventArgs) Handles chkExcute.CheckedChanged
        ' T/C 진행 여부를 체크 하면 어디 모델에서 진행 했는지 쓸 수 있는 박스 생성
        If chkExcute.Checked Then           ' TC 진행 했을 때 
            txtCheckbox.Visible = True

        Else
            txtCheckbox.Visible = False
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ' 링크 버튼을 눌렀을 때
        'Dim Other_TC As New Select_TC

        Dim form1 As New Select_TC

        If form1.ShowDialog = DialogResult.OK Then

            If form1.TCnameTxt.Text = "" Then
                MsgBox("내용 입력 후 눌러주세요.")
                Exit Sub
            Else
                txtTCName.Text = form1.TCnameTxt.Text
            End If

        End If

    End Sub

    Private Sub trvInfo_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles trvInfo.AfterSelect

    End Sub

#Region "ListView [변경점 > 변경점 내용]"
    Private Sub lstChangeNote_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstChangeNote.SelectedIndexChanged

    End Sub
#End Region

End Class