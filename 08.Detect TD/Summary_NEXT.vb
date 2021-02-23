Imports System.Collections.Generic
Imports System.Data
Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports System.Drawing
Imports System.IO
Imports System.Windows.Forms
Imports System.Xml
Imports MySql.Data
Imports MySql.Data.MySqlClient

Public Class Summary_NEXT
    Public DS_trvApp As DataSet = New DataSet
    Public chkNode As String = Nothing
    Public chkNode_Action As String = Nothing
    Public chkNodeWapp As String = Nothing
    Public chkNodeWaction As String = Nothing
    Public DS As DataSet = New DataSet
    Public DS_FUT As DataSet = New DataSet
    Public DS_Wear As DataSet = New DataSet
    Public columnDs As DataSet = New DataSet
    Public strSQL As String = Nothing
    Public vCon As String = Nothing
    Public vConn As OleDbConnection
    Public Class1 As New Class1
    Public XML As New XML
    Private strFilePath As String = Application.StartupPath


#Region "MySQL 용"
    Public strSQLCon As String = "Server=59.16.241.6;Uid=rs_user;Pwd=lge1234;Database=td_defect"
    Private mySQLCon As New MySqlConnection(strSQLCon)
    Private mainTable As String = "td_defect"
    Public tb As New Table_class '// Table Name Class
    Public da As New MySqlDataAdapter
#End Region
    Public strApp_list As String = tb.getTable("td_apps_list")
    Public str_action As String = tb.getTable("td_action")
    Public strConC As String = tb.getTable("contacts_c")
    Public strConI As String = tb.getTable("contacts_i")
    Public strCon As String = tb.getTable("contacts_m")
    Public strTA As String = tb.getTable("td_ta")
    Public strSym As String = tb.getTable("td_sym")

    Dim Search_App As New Search_App

#Region "이슈 등록 칸 사이즈 늘리기/줄이기"
    '★ Form Size가 변할 때 
    Public Sub form_resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        ' TextBox Size를 창 Size에 맞게 
        Dim sizeHeight As Integer = Size.Height ' From의 Size를 Get하여 담음
        txtResult.Location = New Point(9, 387)  ' TextBox의 위치를 좌9, 높이 387
        txtResult.Size = New Point(776, sizeHeight - 387 - 100)
        '   TextBox의 넓이, TextBox의 높이 지정하는데, 마지막라인 = 전체 넓이 - 100
    End Sub
#End Region

#Region "처음 폼 로드될 때"
    Public Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Icon = My.Resources.Qportal_Icon
        TabPage2.Visible = False
        TabPage3.Visible = False


        Dim setForm As New set_Form
        '# 배경이미지 정보
        '# Load 시 XML에서 배경 정보 가져오기 
        If File.Exists(Application.StartupPath + "\Wallpapers.xml") Then    '# 파일이 있는지 여부 파악

            '# 만들어 둔 함수로 xml에 node 값 불러오기
            Dim Fuck As String = setForm.ReadfileName(Application.StartupPath + "\Wallpapers.xml")

            If Fuck = "NotImage" Then                             '# 배경 정보가 없다면.
                TabPage1.BackgroundImage = Nothing
            Else
                Dim bkg As Image = Image.FromFile(Fuck)     '# 불러온 정보를 이미지로 변환
                TabPage1.BackgroundImage = bkg               '# 배경 적용
            End If
        End If

        Dim strFile As String = "TD_SaveData"
        Dim dirA As DirectoryInfo = New DirectoryInfo(strFilePath)    ' 디렉토리 지정
        Dim szTemp As String = Nothing
        Dim szFileName As String = Nothing
        Dim blchk As Boolean = False
        Dim xmlReader As XmlTextReader

#Region "xml파일에서 정보 들어있는 부분"
        '★ xml파일이 있는지?, 없는지? 체크 함.
        For Each dra In dirA.GetFiles()     ' For each를 통해 폴더 내의 파일을 찾음
            szTemp = dra.Name
            If InStr(Trim(dra.Name), RTrim(strFile)) And Strings.Left(szTemp, 2) <> "~$" Then
                szFileName = dra.Name
                blchk = True
                Exit For
            End If
        Next

        '★ 만약! 이미 TD_SaveData라는 xml파일이 있다면?  (이미 한번 열은 것임, )
        If blchk Then
            ' XML에서 정보를 읽어옴
            Dim strCompany As String = Nothing
            Dim strTester As String = Nothing
            Dim strML As String = Nothing
            Dim strAdmin As String = Nothing
            Dim strPre As String = Nothing
            Dim strModel As String = Nothing
            Dim strResult As String = Nothing
            Dim strTitle As String = Nothing

            '★ TD_SaveData 의 값 읽어옴. 
            '★ 기존에 입력 했던 검증원 정보, 모델리더 이름, 관리자이름, Pre-Condition등 등을 xml에 저장해서 다음에 켜도 불러올 수 있도록.
            xmlReader = New XmlTextReader(Application.StartupPath + "\TD_SaveData.xml")
            Do While xmlReader.Read() ' XML 파일 한줄씩 읽어옴
                If xmlReader.NodeType = XmlNodeType.Element AndAlso xmlReader.Name = "Company" Then ' NodeType가 Element고 Name이 Address일 경우
                    strCompany = xmlReader.ReadElementContentAsString ' 해당 Element의 String값을 읽어옴
                End If
                If xmlReader.NodeType = XmlNodeType.Element AndAlso xmlReader.Name = "Tester" Then
                    strTester = xmlReader.ReadElementContentAsString
                End If
                If xmlReader.NodeType = XmlNodeType.Element AndAlso xmlReader.Name = "Model_Leader" Then
                    strML = xmlReader.ReadElementContentAsString
                End If
                If xmlReader.NodeType = XmlNodeType.Element AndAlso xmlReader.Name = "Administrator" Then
                    strAdmin = xmlReader.ReadElementContentAsString
                End If
                If xmlReader.NodeType = XmlNodeType.Element AndAlso xmlReader.Name = "Pre_Condition" Then
                    strPre = xmlReader.ReadElementContentAsString
                End If
                If xmlReader.NodeType = XmlNodeType.Element AndAlso xmlReader.Name = "Model_Comparing" Then
                    strModel = xmlReader.ReadElementContentAsString
                End If
                If xmlReader.NodeType = XmlNodeType.Element AndAlso xmlReader.Name = "TD_Contents" Then
                    strResult = xmlReader.ReadElementContentAsString
                End If
                If xmlReader.NodeType = XmlNodeType.Element AndAlso xmlReader.Name = "TD_Title" Then
                    strTitle = xmlReader.ReadElementContentAsString
                End If

            Loop

            xmlReader.Close() ' XML Reader 닫음

#End Region

            '★ xml에서 가져온 기존 정보들을 다시 각 각의 위치에 값 넣어줌.
            CompanyCB.Text = strCompany : txtTester.Text = strTester : txtML.Text = strML
            txtAdmin.Text = strAdmin : txtPre.Text = strPre : txtModel.Text = strModel : txtResult.Text = strResult
            Summ.Text = strTitle

        Else    ' ★★★★최초 이면★★★★!!!

            ' Pre-Condition 넣어 주기 
            With txtPre
                .Text = "1) Board D/L ()"
                .Multiline = True
            End With

            ' 비교모델 관련
            With txtModel
                .Text = "ex) H960TR : 재현 안됨 "
                .Multiline = True
                .ForeColor = Color.Gray
            End With
        End If

        ' ToolTip
        Dim toolTip1 As New ToolTip()
        toolTip1.SetToolTip(requestBtn, "Q-Portal에 없는 앱이나 기능을 추가할 수 있습니다 ")
        toolTip1.SetToolTip(Button5, "아직 구현중이므로, 폰트가 계속유지 되지는 않습니다.")
        toolTip1.InitialDelay = 500
        toolTip1.AutoPopDelay = 1000
        toolTip1.ReshowDelay = 500

        Try

            Try
                mySQLCon.Open()
            Catch ex As Exception
                MessageBox.Show(ex.Message, "(Sunbae) - DB Open 에러", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

            ' 쿼리문 작성   
            Dim szSQL As String = "Select * FROM " + strApp_list + " Where AppName is not Null Order by AppName,Feature"
            Dim szSQL_Action As String = "Select * FROM " + str_action
            Dim szSQL_lstTa As String = "SELECT * FROM " + strTA + " WHERE TestAction_Type IS NOT NULL ORDER BY TestAction_Type,TestAction"
            Dim szsql_lstSym As String = "Select * From " + strSym

            ' String변수에 테이블명과 쿼리문 순차적으로 담음.
            Dim szQuery As String() = New String() {szSQL, szSQL_Action, szSQL_lstTa, szsql_lstSym}
            Dim loopSht As String() = New String() {strApp_list, str_action, strTA, strSym}
            Dim nCnt As Integer = 0

            Try
                ' Looping 하여 Data Adapter 실행
                For Each a As String In szQuery
                    'Dim DA = New MySqlDataAdapter(a, mySQLCon)
                    DA = New MySqlDataAdapter(a, mySQLCon)
                    DA.Fill(DS, loopSht(nCnt))
                    nCnt += 1
                Next

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            vConn = Nothing

        Catch ex As Exception
            MsgBox(ex.Message)
            Exit Sub
        End Try

        Dim strEP As String = Nothing
        Dim strName As String = Nothing

        Try
            tb.setUserName()
            strName = tb.getUserName
        Catch ex As Exception
            Diagnostics.Debug.Print(ex.Message & Environment.NewLine & "유저이름 가져오기 오류")
        End Try
        txtTester.Text = strName        ' 일단 이름 받아옴

        Try
            tb.setCompany(strName)
            strEP = tb.getCompnay
        Catch ex As Exception
            Diagnostics.Debug.Print(ex.Message & Environment.NewLine & "회사이름 가져오기 오류")
        End Try
        CompanyCB.Text = strEP        ' 일단 이름 받아옴

        ' Dataview에 원하는 조건(itemSelect) 에 맞는 데이터를 정렬 후 저장 
        Dim dv As DataView
        Dim dt_Temp As DataTable
        Dim Table_Detailed1 As DataTable  ' = DS.Tables(1)
        dv = New DataView(DS.Tables(strSym), "DetailedSymptom_Type > '' ", "DetailedSymptom_Type Asc", DataViewRowState.CurrentRows)
        dt_Temp = dv.ToTable
        Table_Detailed1 = dt_Temp.DefaultView.ToTable(True, "DetailedSymptom_Type")


        ' 업체명 ComboBox 추가 
        With CompanyCB
            .Items.Add("CNS")
            .Items.Add("엠스텍")
            .Items.Add("인피닉")
            ' .Text = CompanyCB.Items(0)

        End With

        ' 검증유형 ComboBox 추가 
        With lstCa.Items
            .Add("Random_변경점")
            .Add("Random_변경점X")
            '.Add("목적T/C_변경점")
            '.Add("목적T/C_기본")
            '.Add("문의")
        End With

        ' 검증계획서 ComboBox 추가 
        With lstPlan.Items
            .Add("Plan")
            .Add("Not Plan")
        End With

        '# 180810
        '# 재현율 내용 추가 
        With lstFre.Items
            .Add("100% (10/10)")
            .Add("1% ~ 50%")
            .Add("51% ~ 99%")
            .Add("One-Time")
            .Add("Specific HW")
        End With

        ' Load 시 Summary에 Description
        Summ.Text = "ex) Camera 촬영 안 됨"
        Summ.ForeColor = Color.Gray


        Dim columnSym As DataTable = DS.Tables(strSym)   '// Symptom


        tb.setListView(lstSym)
        tb.setField("DetailedSymptom_Type")

        tb.getFieldText()

        tb.setListItem(lstSym, DS.Tables(strSym))



        If trvApp.Nodes.Count = 0 Then  '// App List

            Dim dt_table As DataTable = DS.Tables(0)
            Call BuildTree(dt_table, trvApp, expandAll:=False)
            trvApp.Sort()

        End If

        If trvAction.Nodes.Count = 0 Then
            Dim dt_tableAction As DataTable = DS.Tables(1)  '// Action
            Call BuildTree_Action(dt_tableAction, trvAction, expandAll:=False)
        End If

        trvAction.Sort()

        txtApp.ReadOnly = True
        txtFea.ReadOnly = True
        txtAction.ReadOnly = True
        txtActiontype.ReadOnly = True
    End Sub
#End Region

#Region "앱 검색 버튼 눌렀을 때"
    Private Sub btSearchApp_Click(sender As Object, e As EventArgs) Handles btSearchApp.Click


        'Serach_App 폼에 Treeview 복사하기

        If Search_App.trvApp.Nodes.Count = 0 Then

            For Each newNode As TreeNode In trvApp.Nodes
                Dim cloneNode As New TreeNode
                cloneNode = newNode.Clone()
                Search_App.trvApp.Nodes.Add(cloneNode)
            Next
        Else

        End If


        'If SearchTheTreeView(trvApp, txtApp.Text) Is Nothing Then
        '    MessageBox.Show("No Match Found")
        'Else
        '    trvApp.SelectedNode = SearchTheTreeView(trvApp, txtApp.Text)
        'End If
        Search_App.ShowDialog()

        Dim FindApp As TreeNode

        'TextBox1.Text = Search_App.trvApp.SelectedNode.Text

        '########### 검색된 App이름 선택되어지는 부분 ############
        If Search_App.chkSubmit = True Then
            If Search_App.chkSearch = True Then
                'nodecount = Search_App.nodeCount - 1
                FindApp = SearchTheTreeView(trvApp, Search_App.trvApp.SelectedNode.Text)
                FindApp = Search_App.trvApp.SelectedNode

                For i = 0 To NodesThatMatch.Count - 1
                    If NodesThatMatch(i).Parent Is Nothing Then
                        If Search_App.trvApp.SelectedNode.Parent Is Nothing Then
                            FindApp = NodesThatMatch(nodecount)
                            Exit For
                        End If

                    Else
                        If NodesThatMatch(i).Parent.Text = Search_App.trvApp.SelectedNode.Parent.Text Then
                            FindApp = NodesThatMatch(i)

                        End If
                    End If

                Next

                trvApp.CollapseAll()
                trvApp.SelectedNode = FindApp
                trvApp.Select()
            Else
                '######## App이름 검색하지 않고 직접 찾아서 선택 했을 때 ########
                FindApp = SearchTheTreeView(trvApp, Search_App.trvApp.SelectedNode.Text)
                FindApp = Search_App.trvApp.SelectedNode

                For i = 0 To NodesThatMatch.Count - 1
                    If NodesThatMatch(i).Parent Is Nothing Then
                        FindApp = NodesThatMatch(nodecount)
                    ElseIf FindApp.Parent IsNot Nothing Then

                        If NodesThatMatch(i).Parent.Text = FindApp.Parent.Text Then
                            FindApp = NodesThatMatch(i)
                        End If
                    End If
                Next
                trvApp.CollapseAll()
                trvApp.SelectedNode = FindApp
                trvApp.Select()
            End If

        Else

        End If

        If Search_App.chkSearch = False Then

        End If

        'Search_App.Close()




        'Me.trvApp.SelectedNode = Search_App.trvApp.SelectedNode
        'trvApp.Select()



    End Sub
#End Region

#Region "트리뷰 관련"
    Dim nodecount As Integer = Search_App.nodeCount
    Dim NodesThatMatch As New List(Of TreeNode)
    Private Function SearchTheTreeView(ByVal TV As TreeView, ByVal TextToFind As String) As TreeNode
        '  Empty previous
        NodesThatMatch.Clear()

        ' Keep calling RecursiveSearch
        For Each TN As TreeNode In TV.Nodes
            If TN.Text = TextToFind Then
                NodesThatMatch.Add(TN)
            End If

            RecursiveSearch(TN, TextToFind)
        Next

        If NodesThatMatch.Count > nodecount Then
            Return NodesThatMatch(nodecount)
        Else

        End If

    End Function

    Private Sub RecursiveSearch(ByVal treeNode As TreeNode, ByVal TextToFind As String)

        ' Keep calling the test recursively.
        For Each TN As TreeNode In treeNode.Nodes
            If TN.Text = TextToFind Then
                NodesThatMatch.Add(TN)
            End If

            RecursiveSearch(TN, TextToFind)
        Next
    End Sub
#End Region

#Region "Normal 로드버튼 눌렀을 때"
    '########## Load 버튼 ###############
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        ' === 선택되지 않은 항목이 있을때 메세지 보여줌
        'If lstApp.Text = "" Then MsgBox("App이 선택되지 않았습니다. 선택 후 재시도 해주세요") : Exit Sub

        If chkNode <= 2 And txtApp.Text <> "3rd Party" And txtApp.Text <> "Buyer App" Or trvApp.SelectedNode Is Nothing Then
            MsgBox("App이 선택되지 않았거나, Feature가 선택되지 않았습니다." + vbCrLf + "선택 후 재시도 해주세요") : Exit Sub
        End If

        'If lstAction.Text = "" Then MsgBox("Test_Action이 선택되지 않았습니다. 선택 후 재시도 해주세요") : Exit Sub
        If chkNode_Action < 2 Or trvAction.SelectedNode Is Nothing Then
            MsgBox("TestAction이 선택되지 않았거나, 첫번째 노드를 선택했습니다." + vbCrLf + "재선택 후 재시도 해주세요") : Exit Sub
        End If

        If txtFea.ReadOnly = False And txtFea.Text = "" Or InStr(txtFea.Text, "여기에 앱") Then
            MsgBox("App.이 선택되지 않았거나, Feature가 입력되지 않았습니다." + vbCrLf + "선택 후 재시도 해주세요") : Exit Sub
        End If
        If lstSym.Text = "" Then MsgBox("Detailed_Symptom1이 선택되지 않았습니다. 선택 후 재시도 해주세요") : Exit Sub
        If lstSym2.Text = "" Then MsgBox("Detailed_Symptom2이 선택되지 않았습니다. 선택 후 재시도 해주세요") : Exit Sub
        If lstFre.Text = "" Then MsgBox("Frequency Rate가 선택되지 않았습니다. 선택 후 재시도 해주세요") : Exit Sub
        If lstCa.Text = "" Then MsgBox("검증유형이 선택되지 않았습니다. 선택 후 재시도 해주세요") : Exit Sub
        If lstPlan.Text = "" Then MsgBox("검증계획서가 선택되지 않았습니다. 선택 후 재시도 해주세요") : Exit Sub
        If CompanyCB.Text = "" Then MsgBox("업체를 선택 후 시도해주세요") : Exit Sub
        If txtAdmin.Text = "" Then MsgBox("관리자 이름이 입력되지 않았습니다.") : Exit Sub
        If txtTester.Text = "" Then MsgBox("검증원 이름이 입력되지 않았습니다.") : Exit Sub
        If txtML.Text = "" Then MsgBox("모델리더 이름이 입력되지 않았습니다.") : Exit Sub

        tb.setUserName()
        tb.setCompany(tb.getUserName)
        tb.setTel(tb.getUserName)

        If CompanyCB.Text <> tb.getCompnay Then
            MsgBox("업체가 안맞습니다. 관리자에게 문의해주세요", , "lee.sunbae@lgepartner.com")
            Exit Sub
        ElseIf tb.getUserName() = "미등록 사용자" Then
            MsgBox("등록되지 않은 사용자입니다. 관리자에게 문의해주세요", , "lee.sunbae@lgepartner.com")
            Exit Sub
        End If

        ' ★결함 Summary 내용 입력 했으면
        If Summ.Text <> "" And Strings.Left(Summ.Text, 3) <> "ex)" Then   ' 서머리 부분에 내용이 있다면 진행

            ' ★결함을 한글로 작성 했는지, 영문으로 작성 했는지 파악
            Dim blHan As Boolean
            For Each ch As Char In Summ.Text
                If ch.IsHangul() Then
                    blHan = True
                Else
                    blHan = False
                End If
            Next

            ' ★업체에 따라 선택할 수 있도록
            Dim strSht3 As String

            If CompanyCB.Text = "CNS" Then
                strSht3 = "Contacts_C"
            ElseIf CompanyCB.Text = "인피닉" Then
                strSht3 = "Contacts_I"
            ElseIf CompanyCB.Text = "엠스텍" Then
                strSht3 = "Contacts_M"
            End If

            Dim ConTable As DataTable = Nothing

            Dim strRank As String
            Dim strName As String
            Dim strNum As String
            Dim strCom As String

            ' 업체 별 Tel 변경
            Dim intFnd As Integer = 2
            If CompanyCB.Text = "CNS" Then
                strRank = "직급_C"
                strName = "이름_C"
                strNum = "휴대폰_C"
                strCom = "업체_C"
                'intFnd = 2
                ConTable = DS.Tables(3)

            ElseIf CompanyCB.Text = "인피닉" Then
                strRank = "직급_I"
                strName = "이름_I"
                strNum = "휴대폰_I"
                strCom = "업체_I"
                'intFnd = 6
                ConTable = DS.Tables(4)

            ElseIf CompanyCB.Text = "엠스텍" Then
                strRank = "직급_M"
                strName = "이름_M"
                strNum = "휴대폰_M"
                strCom = "업체_M"
                'intFnd = 10
                ConTable = DS.Tables(5)
            End If

            ' Description 담는 배열 
            Dim strString(100)
            Dim chBox(6) As String  ' 첨부 파일 담는 배열

            '# 테이블 제작 하기 
            Dim DesDT As DataTable = Nothing
            Dim dRow As DataRow = Nothing
            Dim dCol As DataColumn = Nothing
            DesDT = New DataTable()

            dCol = New DataColumn()     '# DataColumn 생성
            dCol.DataType = System.Type.GetType("System.String")
            dCol.ColumnName = "Description"

            DesDT.Columns.Add(dCol)        '# Column 추가

            dCol = New DataColumn()     '# DataColumn 생성
            dCol.DataType = System.Type.GetType("System.String")
            dCol.ColumnName = "MarketApp"

            DesDT.Columns.Add(dCol)        '# Column 추가

            '# 수정 시간 : 180810
            '# 임시로 데이터 테이블을 만들어서 제작 합니다.
            '# 원래는 xml 또는 ini 을 이용하여 하여야 하지만 시간상.... 
            With DesDT.Rows
                .Add("1. Title : ", "1.Title : ")
                .Add("2. Precondition : ", "2. App Name : ")
                .Add("3. Tester`s Action : ", "3. Vendor : ")
                .Add("4. Detailed Symptom (ENG.) : ", "4. Version : ")
                .Add("5. Detailed Symptom (KOR.) : ", "5. Download Rating : ")
                .Add("6. Expected : ", "6. Precondition : ")
                .Add("7. Reproducibility : ", "7. Step to reproduce : ")
                .Add("  1) Frequency Rate : ", "  1) ")
                .Add("  2) One-Time Symptom : ", "  2) ")
                .Add("8. Comparison Results : ", "8. Actual result : ")
                .Add("  1) Model Comparing : ", "9. Expect result : ")
                .Add("  2) UI Scenario Comparing : N", "10. LG Reference models behavior : ")
                .Add("  3) Reboot 후 재현여부 : ", "11. Competitor models behavior : ")
                .Add("9. Attached files : ", "12. Attached files : ")
                .Add("  1) Log : ", "  1) Log : ")
                .Add("  2) Test Contents : ", "  2) Test Contents : ")
                .Add("  3) Video file : ", "  3) Video file : ")
                .Add("  4) Image file : ", "  4) Image file : ")
                .Add("  5) LG Backup file : ", "  5)LG Backup file : ")
                .Add("  6) Voice Record file : ", "  6)Voice Record file : ")
                .Add("10. Peer Review : ", "13. Peer Review : ")
                .Add("11. Additional App : N", "14. Additional App : N ")
                .Add("12. Tel : ", "15. Tel : ")
                .Add("  1) Tester : ", "  1) Tester : ")
                .Add("  2) Model leader : ", "  2) Model leader : ")
                .Add("  3) Administrator : ", "  3) Administrator : ")
                .Add("13. 문제사유 : ", "16. 문제사유 : ")
                .Add("14. 내용 : ", "17. 내용 : ")
            End With


            'Dim DesDT As DataTable = DS.Tables(2)       ' TD Des

            ' ### 3rd Party 앱은 마켓앱 전용 양식으로 불러올 수 있도록 #####
            If txtApp.Text = "3rd Party" Or txtApp.Text = "Buyer App" Then                               '  ★★  3rd Party 앱을 선택 한 경우 !! ( 3rd Party는 양식이 다름 )
                For i As Integer = 0 To 27
                    Try
                        'strString(i) = DesDT.Rows(i)(6).ToString()   6 to 1  / 5 to 0
                        strString(i) = DesDT.Rows(i)(1).ToString()
                    Catch ex As Exception
                        MsgBox(ex.Message)
                    End Try
                Next i

            Else   ' ### 일반적인 경우 ####                                      ★★ 3rd Party제외 일반 앱

                For i As Integer = 0 To 27
                    Try
                        strString(i) = DesDT.Rows(i)(0).ToString()      ' (9)는 일반 (10)은 Market App
                    Catch ex As Exception
                        MsgBox(ex.Message)
                    End Try
                Next i

                'Frequency rate 입력 및 one-time symptom 입력
                strString(7) = strString(7) + lstFre.Text
                If lstFre.Text = "One-Time" Then
                    strString(8) = strString(8) + "Y"
                    strString(12) = strString(12) + "N"
                Else
                    strString(8) = strString(8) + "N"
                    strString(12) = strString(12) + "Y"
                End If
            End If

            ' 첨부파일 Y/N 판별해주는 부분
            If CheckBox1.Checked = True Then    ' Log
                chBox(0) = "Y (문제발생시간:    ,로그추출시간:     )"
            Else
                chBox(0) = "N"
            End If

            If CheckBox2.Checked = True Then    ' Test Contents
                chBox(1) = "Y"
            Else
                chBox(1) = "N"
            End If

            If CheckBox3.Checked = True Then    ' Video File
                chBox(2) = "Y"
            Else
                chBox(2) = "N"
            End If

            If CheckBox4.Checked = True Then    ' Image File
                chBox(3) = "Y"
            Else
                chBox(3) = "N"
            End If

            If CheckBox5.Checked = True Then    'LG Backup File
                chBox(4) = "Y"
            Else
                chBox(4) = "N"
            End If

            If CheckBox6.Checked = True Then    'Voice Record File
                chBox(5) = "Y"
            Else
                chBox(5) = "N"
            End If

            ' 첨부파일 값 넣어주기 
            Dim j As Integer = 0
            For i = 14 To 19
                strString(i) = strString(i) + chBox(j)
                j = j + 1
            Next i

            ' 모델리더, 테스터, 관리자 자동으로 입력해주는 부분
            Dim strML As String = txtML.Text
            Dim strTester As String = txtTester.Text
            Dim strAdmin As String = txtAdmin.Text

            strString(23) += strTester & " " & tb.getTel()
            tb.setTel(strML)
            strString(24) += strML & " " & tb.getTel()
            strString(20) += strML & " " & tb.getTel()
            tb.setTel(strAdmin)
            strString(25) += strAdmin & " " & tb.getTel()


            Dim strSum As String
            ' ################################# Summary Text 만들기 ###################################################
            If InStr(Summ.Text, "//") Then
                ' 서머리 양식 만들기
                If MsgBox("새로 불러 옵니다. " & "진행 하시겠습니까?", vbQuestion + vbYesNo, "lee.sunbabe@lgepartner.com") = vbNo Then
                    Exit Sub
                Else
                    Summ.Text = Strings.Left(Summ.Text, InStr(Summ.Text, "//") - 1)

                    If txtFea.Text = "" Or InStr(txtFea.Text, "여기에 앱") Then
                        strSum = " //" & "[" & txtApp.Text & "]" & "[" & trvAction.SelectedNode.Parent.Text & "_" & txtAction.Text & "]" & "[" & lstSym.Text + "_" + lstSym2.Text & "]" & "[" & lstPlan.Text & "]" & "[" & lstCa.Text & "]"
                    Else
                        strSum = " //" & "[" & txtApp.Text & "_" & txtFea.Text & "]" & "[" & trvAction.SelectedNode.Parent.Text & "_" & txtAction.Text & "]" & "[" & lstSym.Text + "_" + lstSym2.Text & "]" & "[" & lstPlan.Text & "]" & "[" & lstCa.Text & "]"
                    End If

                    'Summary title 부분 추가
                    Summ.Text = Summ.Text + " " + strSum
                    ' 서머리 양식 만들기
                    strString(0) = strString(0) + Summ.Text
                    '               1. Title :      + Call 안됨  +  //[Voice Call_OutgoingCall........]
                End If

            Else

                '              If lstFea.Text = "" Then 'Feature가 선택되지 않았을때
                If txtFea.Text = "" Or InStr(txtFea.Text, "여기에 앱") Then
                    strSum = " //" + "[" & txtApp.Text & "_" & "]" + "[" + trvAction.SelectedNode.Parent.Text & "_" & txtAction.Text + "]" + "[" + lstSym.Text + "_" + lstSym2.Text + "]" + "[" + lstPlan.Text + "]" + "[" + lstCa.Text + "]"
                Else
                    strSum = " //" + "[" & txtApp.Text & "_" & txtFea.Text & "]" + "[" + trvAction.SelectedNode.Parent.Text & "_" & txtAction.Text + "]" + "[" + lstSym.Text + "_" + lstSym2.Text + "]" + "[" + lstPlan.Text + "]" + "[" + lstCa.Text + "]"
                End If
                '               Else
                'strSum = " //" + "[" + txtApp.Text + "_" + txtFea.Text + "]" + "[" + trvAction.SelectedNode.Parent.Text & "_" & txtAction.Text + "]" + "[" + lstSym.Text + "_" + lstSym2.Text + "]" + "[" + lstPlan.Text + "]" + "[" + lstCa.Text + "]"
                '               End If

                'Summary title 부분 추가
                Summ.Text = Summ.Text + " " + strSum
                ' 서머리 양식 만들기
                strString(0) = strString(0) + Summ.Text
                '1. Title :      + Call 안됨  +  //[Voice Call_OutgoingCall........]

            End If


            Dim strCompareTemp As String = txtResult.Text

            txtResult.Text = ""

            For i = 0 To 29

                ' 3rd Party 인경우만 !!!!!
                If txtApp.Text = "3rd Party" Or txtApp.Text = "Buyer App" Then

                    If i = 5 Then ' 프리컨디션 추가 부분
                        txtResult.Text = txtResult.Text & strString(i) & vbCrLf & "  " & txtPre.Text & vbCrLf
                        i = i + 1
                    End If

                    txtResult.Text = txtResult.Text & strString(i) & vbCrLf


                Else   ' 일반적인 Summary Description 작성 부분


                    If i = 1 Then ' 프리컨디션 추가부분
                        txtResult.Text = txtResult.Text & strString(i) & vbCrLf & "  " & txtPre.Text & vbCrLf
                        i = i + 1
                    End If

                    If blHan = False Then ' 영어면 
                        If i = 3 Then ' 디테일심텀 추가부분   17.04.21 이순배 [영어]
                            txtResult.Text = txtResult.Text & strString(i) & vbCrLf & "  " & Strings.Left(Summ.Text, InStr(Summ.Text, "//") - 1) & vbCrLf
                            i = i + 1
                        End If
                    ElseIf blHan = True Then
                        If i = 4 Then ' 디테일심텀 추가부분   17.04.21 이순배 [한글]
                            txtResult.Text = txtResult.Text & strString(i) & vbCrLf & "  " & Strings.Left(Summ.Text, InStr(Summ.Text, "//") - 1) & vbCrLf
                            i = i + 1
                        End If

                    End If


                    If i = 10 Then ' 비교시료 추가부분
                        If Strings.Left(txtModel.Text, 3) = "ex)" Then
                            txtResult.Text = txtResult.Text & strString(i) & vbCrLf
                        Else
                            'Enter(Chr(10)) 키 입력시 Split하여 앞에 공간 추가 하여 결과 보여줌

                            Dim arrVal = Split(txtModel.Text, Chr(10))
                            txtResult.Text = txtResult.Text & strString(i) & vbCrLf
                            'txtResult.Text = txtResult.Text & strString(i) & vbCrLf & "  " & txtModel.Text & vbCrLf
                            For z = 0 To UBound(arrVal)
                                If z = UBound(arrVal) Then
                                    txtResult.Text = txtResult.Text & "    " & arrVal(z) '& Chr(10)
                                Else
                                    txtResult.Text = txtResult.Text & "    " & arrVal(z) & Chr(10)
                                End If
                            Next z
                            txtResult.Text = txtResult.Text & vbCrLf
                        End If

                        i = i + 1
                    End If

                    '최종
                    txtResult.Text = txtResult.Text & strString(i) & vbCrLf

                End If
            Next i

        ElseIf Summ.Text = "" Or Strings.Left(Summ.Text, 3) = "ex)" Then
            MsgBox("Summary Title 을 입력한 후 Load를 다시 해주세요",, "lee.sunbae@lgepartner.com")
            Exit Sub
        End If

        Dim strGeneral As String = "GENERAL Defect Description"
        If CheckBox7.Checked = True Then
            txtResult.Text = strGeneral & vbCrLf & txtResult.Text
        Else

        End If

        '// load버튼 눌렀을 때 mySetting에 저장하는 코드 (RS) 에 값 넘기도록
        'My.Settings.strRS_App = txtApp.Text
        'My.Settings.strRS_Fea = txtFea.Text
        'My.Settings.strRS_Sym1 = lstSym.Text
        'My.Settings.strRS_Sym2 = lstSym2.Text


        'txtResult.SelectedText = "GENERAL Defect Description"
        'txtResult.SelectionFont = New Font("맑은 고딕", 10, FontStyle.Bold)

    End Sub
#End Region

#Region "Summary 입력 창 선택 했을 때 "
    Private Sub Summ_MouseClick(sender As Object, e As MouseEventArgs) Handles Summ.MouseClick, Summ_FUT.MouseClick
        ' 마우스 클릭 했을 때 ex) 가 남아있는 Text 라면 
        If Strings.Left(Summ.Text, 3) = "ex)" Then
            Summ.Text = ""
            Summ.Font = New Font("맑은 고딕", 9)
            Summ.ForeColor = Color.Black
        End If

        If Strings.Left(Summ_FUT.Text, 3) = "ex)" Then
            Summ_FUT.Text = ""
            Summ_FUT.Font = New Font("맑은 고딕", 9)
            Summ_FUT.ForeColor = Color.Black
        End If


    End Sub

#End Region

    '### RP Or RA 를 선택 시 RP_XX 선택 하면 App 이름을 쓸 필요가 없기 때문에 Disable ############################
    Private Sub lstRP_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstCa.SelectedIndexChanged, lstPlan.SelectedIndexChanged
        Dim Table_Action As DataTable = DS.Tables(2)

        DesTxt.Text = ""

        For i As Integer = 0 To Table_Action.Rows.Count - 1                ' Data table Row 만큼 반복 -1은 마지막행은 Null
            If lstCa.Text = Table_Action.Rows(i)(2).ToString() Then     ' 선택 된 App과 Row, 필트(0)은 App, (1) 은 Feature
                Try
                    DesTxt.Text = Table_Action.Rows(i)(3).ToString()
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            End If
        Next
    End Sub
    ' ### Model Comparing 입력 하고자 할 때  ########################################################
    Private Sub txtModel_MouseDown(sender As Object, e As MouseEventArgs) Handles txtModel.MouseDown, txtModel_FUT.MouseDown

        If DirectCast(sender, Control).Name = "txtModel_FUT" Then   ' 만약 Event를 Click 한 Handler가 FUT라면
            If InStr(Me.txtModel_FUT.Text, "ex") > 0 Then
                Me.txtModel_FUT.Text = ""
                Me.txtModel_FUT.ForeColor = Color.Black
            End If
        Else
            If InStr(Me.txtModel.Text, "ex") > 0 Then
                Me.txtModel.Text = ""
                Me.txtModel.ForeColor = Color.Black
            End If
        End If

    End Sub
    ' ### 마지막 사용자가 저장한 내용을 다시 읽어 오기 위해 System Setting에 저장 ###################
    Private Sub Form1_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed

        ' XML 에 파일 저장하는 부분
        Dim writer As New XmlTextWriter(Application.StartupPath + "\TD_SaveData.xml", System.Text.Encoding.UTF8)
        writer.WriteStartDocument(True)
        writer.Formatting = Formatting.Indented
        writer.Indentation = 2
        ' Path Element 열기 <
        writer.WriteStartElement("TD")
        ' 업체명 저장
        createNode(CompanyCB.Text, "Company", writer)
        ' 검증원 저장
        createNode(txtTester.Text, "Tester", writer)
        ' 모델리더 저장
        createNode(txtML.Text, "Model_Leader", writer)
        ' 관리자 저장
        createNode(txtAdmin.Text, "Administrator", writer)
        ' 사전조건 저장
        createNode(txtPre.Text, "Pre_Condition", writer)
        ' 비교시료 저장
        createNode(txtModel.Text, "Model_Comparing", writer)

        ' TD Contents 안 사라지게.
        createNode(txtResult.Text, "TD_Contents", writer)
        createNode(Summ.Text, "TD_Title", writer)

        'Path Element 닫음 >
        writer.WriteEndElement()
        writer.WriteEndDocument()
        writer.Close()

    End Sub
    '★ XML에 내용 입력하는 함수 ( 저장할 문자, 저장한 문자 감싸는 노드명,  입력기)
    Private Sub createNode(ByVal pName As String, ByVal pPath As String, ByVal writer As XmlTextWriter)
        writer.WriteStartElement(pPath) ' <pPath>            </pPath>
        writer.WriteString(pName)       ' <pPath>    pName   </pPath>
        writer.WriteEndElement()
    End Sub

    ' ### Summary Title Copy 하는 부분 ###########################################
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click, Button12.Click
        Try
            If DirectCast(sender, Control).Name = "Button12" Then
                Clipboard.SetText(Summ_FUT.Text)           '클립보드에 텍스트 설정 합니다.
                MsgBox("복사 되었습니다",, "lee.sunbae@lgepartner.com")
            Else
                Clipboard.SetText(Summ.Text)           '클립보드에 텍스트 설정 합니다.
                MsgBox("복사 되었습니다",, "lee.sunbae@lgepartner.com")
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    ' ###Description 내용을 Copy 하는 부분 ###########################################
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click, bodyCpy_FUT.Click
        Try
            If DirectCast(sender, Control).Name = "bodyCpy_FUT" Then
                Clipboard.SetText(txtResult_FUT.Text)       '클립보드에 텍스트 설정 합니다.
                MsgBox("복사 되었습니다",, "lee.sunbae@lgepartner.com")
            Else
                Clipboard.SetText(txtResult.Text)           '클립보드에 텍스트 설정 합니다.
                MsgBox("복사 되었습니다",, "lee.sunbae@lgepartner.com")
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub lstApp_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Escape Then
            Close()
        End If
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click, Del_FUT.Click
        Summ.Text = ""
        Summ.Font = New Font("맑은 고딕", 9)
        Summ.ForeColor = Color.Black

        Summ_FUT.Text = ""
        Summ_FUT.Font = New Font("맑은 고딕", 9)
        Summ_FUT.ForeColor = Color.Black

    End Sub

    Private Sub CompanyCB_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CompanyCB.SelectedIndexChanged, CompanyCB_FUT.SelectedIndexChanged
        If CompanyCB.Text = "CNS" Then
            txtAdmin.Text = "최진원"
        Else
            txtAdmin.Text = ""
        End If

    End Sub

    Private Sub txtFea_Click(sender As Object, e As EventArgs) Handles txtFea.Click, txtFea_FUT.Click
        If Strings.Left(txtFea.Text, 3) = "여기에" Then
            txtFea.Text = ""
            txtFea.Font = New Font("맑은 고딕", 8.25)
            txtFea.ForeColor = Color.Black
        End If

        If DirectCast(sender, Control).Name = "txtFea_FUT" Then
            ' FUT 전용 ###########################################
            If Strings.Left(txtFea_FUT.Text, 3) = "여기에" Then
                txtFea_FUT.Text = ""
                txtFea_FUT.Font = New Font("맑은 고딕", 9)
                txtFea_FUT.ForeColor = Color.Black
            End If
            ' ###################################################
        End If

    End Sub

    Private Sub txtFea_MouseCaptureChanged(sender As Object, e As EventArgs) Handles txtFea.MouseCaptureChanged, txtFea_FUT.MouseCaptureChanged
        Dim toolTip1 As New ToolTip()
        toolTip1.SetToolTip(txtFea, "앱 이름을 입력만 한 상태로 Load 하면 됩니다. ")
        toolTip1.SetToolTip(txtFea_FUT, "앱 이름을 입력만 한 상태로 Load 하면 됩니다. ")
        'toolTip1.SetToolTip(ComboBox2, "대분류 카테고리를 선택할 수 있습니다. * 선택하지 않아도 됩니다.")
        'toolTip1.SetToolTip(TextBox1, "검색어를 입력하세요.")
        'toolTip1.SetToolTip(Button2, "Search")
        toolTip1.InitialDelay = 100
        toolTip1.AutoPopDelay = 3000    ' 사용자가 마우스를 올려서 보여지는 시간
        toolTip1.ReshowDelay = 500
    End Sub

#Region "Symptom 선택 했을 때 ex) GUI"
    '########### Detailed Symptom1 선택 시 설명 나오게 하는 부분 ##############
    Private Sub lstSym_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstSym.Click

        Dim Table_Action As DataTable = DS.Tables(strSym)



        DesTxt.Text = ""

        For i As Integer = 0 To Table_Action.Rows.Count - 1    ' Data table Row 만큼 반복 -1은 마지막행은 Null
            If lstSym.Text = Table_Action.Rows(i)(2).ToString() Then ' 선택 된 App과 Row, 필트(0)은 App, (1) 은 Feature
                Try
                    DesTxt.Text = Table_Action.Rows(i)(4).ToString()
                    Exit Sub
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try

            End If
        Next
    End Sub
#End Region

#Region "Symptom2 눌렀을 때 설명보여주게"
    ' ########### Detailed Symptom2 선택 시 설명 나오게 하는 부분 ##############
    Private Sub lstSym2_SelectedIndexChanged(sender As Object, e As EventArgs)

        Dim Table_Action As DataTable = DS.Tables(6)

        DesTxt.Text = ""

        For i As Integer = 0 To Table_Action.Rows.Count - 1    ' Data table Row 만큼 반복 -1은 마지막행은 Null
            If lstSym2.Text = Table_Action.Rows(i)(5).ToString() Then ' 선택 된 App과 Row, 필트(0)은 App, (1) 은 Feature
                Try
                    DesTxt.Text = Table_Action.Rows(i)(6).ToString()
                    Exit Sub
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try

            End If
        Next
    End Sub
#End Region


    Private Sub requestBtn_Click(sender As Object, e As EventArgs) Handles requestBtn.Click
        Dim Summary_Add As New Summary_Add
        Summary_Add.Show()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click, Button10.Click  ' 리셋 버튼

        If MsgBox("내용이 모두 사라집니다." & "정말 진행 하시겠습니까?" & vbCrLf & "지우지 않고, 원하는 항목 선택 후 재 Load 하셔도 됩니다.", vbQuestion + vbYesNo, "lee.sunbabe@lgepartner.com") = vbNo Then
            Exit Sub
        Else
            If DirectCast(sender, Control).Name = "Button10" Then
                txtResult_FUT.Text = ""
                Summ_FUT.Text = ""
            Else
                txtResult.Text = ""
                Summ.Text = "ex) Camera 촬영 안 됨"
                Summ.ForeColor = Color.Gray

            End If

        End If
    End Sub

    '#### FUT Summary Tool #####
#Region "FUT 탭 부분 로드할 때"
    'Private Sub TabPage2_Enter(sender As Object, e As EventArgs) Handles TabPage2.Enter


    '    'txtAdmin_FUT.Text = My.Settings.strAdmin
    '    'txtTester_FUT.Text = My.Settings.strTester
    '    'txtML_FUT.Text = My.Settings.strModelLeader
    '    'CompanyCB_FUT.Text = My.Settings.strCompanys


    '    Dim toolTip1 As New ToolTip()
    '    toolTip1.SetToolTip(requestBtn, "Q-Portal에 없는 앱이나 기능을 추가할 수 있습니다 ")
    '    toolTip1.InitialDelay = 500
    '    toolTip1.AutoPopDelay = 1000
    '    toolTip1.ReshowDelay = 500

    '    'Dim strSht As String = "App_Feature_Des"  ' DB 시트 이름 지정
    '    'Dim strSht2 As String = "TestType_Detailed Symptom_Des"

    '    'Dim strCNS As String = "Contacts_C"
    '    'Dim strMSTech As String = "Contacts_M"
    '    'Dim strINFINIQ As String = "Contacts_I"

    '    'Dim strSht4 As String = "TD_Des"

    '    Try
    '        'Dim XML As New XML
    '        'XML.vCon_Call(vCon)
    '        'vConn = New OleDbConnection(vCon)

    '        ' 쿼리문 작성
    '        Dim szSQL As String = "Select * FROM [" + strApp + "] Where [App] > '' Order by App,Feature"
    '        Dim szSQL_Action As String = "Select * FROM [" + strAction + "] Where [Test Action] > '' Order by [Test Action],[Detailed Symptom_1],[Detailed Symptom_2]"
    '        Dim szSht_TD As String = "Select * FROM [" + strDes + "]"
    '        Dim szConC As String = "Select * FROM [" + strCNS + "]"
    '        Dim szConI As String = "Select * FROM [" + strINFINIQ + "]"
    '        Dim szConM As String = "Select * FROM [" + strMSTech + "]"
    '        Dim szFUT As String = "Select * FROM [" & strFUT & "]"


    '        Dim szQuery As String() = New String() {szSQL, szSQL_Action, szSht_TD, szConC, szConI, szConM, szFUT}
    '        Dim loopSht As String() = New String() {strApp, strAction, strDes, strCNS, strINFINIQ, strMSTech, strFUT}
    '        Dim nCnt As Integer = 0

    '        Try
    '            vConn = New OleDbConnection(vCon)   ' MainForm의 Connection String으로 DB Connect
    '            ' Looping 하여 Data Adapter 실행
    '            For Each a As String In szQuery
    '                Dim DA = New OleDbDataAdapter(a, vConn)
    '                DA.Fill(DS_FUT, loopSht(nCnt))
    '                nCnt += 1
    '            Next
    '            'DS.WriteXml(Application.StartupPath & "\Sunbae.XML")

    '        Catch ex As Exception
    '            MsgBox(ex.Message)
    '        End Try


    '        XML = Nothing
    '        vConn = Nothing
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '        Exit Sub
    '    End Try

    '    'vConn.Close()
    '    Dim Table As DataTable = DS_FUT.Tables(0)

    '    Table = Table.DefaultView.ToTable(True, "App")
    '    lstApp_FUT.DataSource = Table
    '    With lstApp_FUT
    '        .DisplayMember = "App"
    '        .ValueMember = "App"
    '    End With

    '    '=[Test Action 불러오기]======
    '    Dim Table_Action As DataTable = DS_FUT.Tables(1)
    '    Table_Action = Table_Action.DefaultView.ToTable(True, "Test Action")
    '    With lstAction_FUT
    '        .DataSource = Table_Action
    '        .DisplayMember = "Test Action"
    '        .ValueMember = "Test Action"
    '    End With
    '    '=[Detailed Symptom1 불러오기]======

    '    Dim dv As DataView
    '    Dim dt_Temp As DataTable
    '    Dim Table_Symptom1 As DataTable  ' = DS.Tables(1)
    '    dv = New DataView(DS.Tables(1), "[Detailed Symptom_1] > '' ", "[Detailed Symptom_1] Asc", DataViewRowState.CurrentRows)
    '    dt_Temp = dv.ToTable
    '    Table_Symptom1 = dt_Temp.DefaultView.ToTable(True, "Detailed Symptom_1")

    '    With lstSym1_FUT
    '        .DataSource = Table_Symptom1
    '        .DisplayMember = "Detailed Symptom_1"
    '        .ValueMember = "Detailed Symptom_1"
    '    End With
    '    '=[Detailed Symptom2 불러오기]======

    '    Dim Table_Symptom2 As DataTable = DS_FUT.Tables(1)
    '    dv = New DataView(DS.Tables(1), "[Detailed Symptom_2] > '' ", "[Detailed Symptom_2] Asc", DataViewRowState.CurrentRows)
    '    dt_Temp = dv.ToTable

    '    Table_Symptom2 = dt_Temp.DefaultView.ToTable(True, "Detailed Symptom_2")
    '    With lstSym2_FUT
    '        .DataSource = Table_Symptom2
    '        .DisplayMember = "Detailed Symptom_2"
    '        .ValueMember = "Detailed Symptom_2"
    '    End With

    '    '=[대분류 불러오기]
    '    Dim Table_Condition As DataTable = DS_FUT.Tables(6)
    '    Table_Condition = Table_Condition.DefaultView.ToTable(True, "대분류")
    '    With lstDae_FUT
    '        .DataSource = Table_Condition
    '        .DisplayMember = "대분류"
    '        .ValueMember = "대분류"
    '    End With

    '    '=[Frequency Rate 불러오기]
    '    Dim Table_Rate As DataTable = DS_FUT.Tables(2)
    '    Table_Rate = Table_Rate.DefaultView.ToTable(True, "Frequency Rate")
    '    With lstFre_FUT
    '        .DataSource = Table_Rate
    '        .DisplayMember = "Frequency Rate"
    '        .ValueMember = "Frequency Rate"
    '    End With

    '    ' Pre-Condition 넣어 주기 
    '    With txtPre_FUT
    '        .Text = "1) Board D/L ()"
    '        .Multiline = True
    '    End With

    '    ' 비교모델 관련
    '    With txtModel_FUT
    '        .Text = "ex) H960TR : 재현 안됨 "
    '        .Multiline = True
    '        .ForeColor = Color.Gray
    '    End With

    '    ' 업체명 ComboBox 추가 
    '    With CompanyCB_FUT.Items
    '        .Add("CNS")
    '        .Add("엠스텍")
    '        .Add("인피닉")
    '    End With

    '    ' Load 시 Summary에 Description
    '    Summ_FUT.Text = "ex) Camera 촬영 안 됨"
    '    Summ_FUT.ForeColor = Color.Gray

    'End Sub
#End Region




    '###################함수 구현 #########################
    '##### 첫번 째 리스트박스
    Private Sub OneLST(ByVal lstOne As ListBox, ByVal lstNext As ListBox, ByVal strSht As String, ByRef intTable As Integer, ByVal DS_NAME As DataSet, ByVal intColOne As Integer, ByVal intColTwo As Integer)
        Try
            ' App Click 시 Feature에 맞도록
            Dim Table As DataTable = DS_NAME.Tables(intTable)
            lstNext.Items.Clear()
            DesTxt_FUT.Text = ""            ' 설명 초기화 
            For i As Integer = 0 To Table.Rows.Count - 1    ' Data table Row 만큼 반복 -1은 마지막행은 Null

                If lstOne.Text = Table.Rows(i)(intColOne).ToString() Then ' 선택 된 App과 Row, 필트(0)은 App, (1) 은 Feature
                    Try
                        If Not lstNext.Items.Contains(Table.Rows(i)(intColTwo).ToString()) Then  ' 중복 없이 Item 추가
                            lstNext.Items.Add(Table.Rows(i)(intColTwo).ToString())
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

    '##### 두번 째 리스트박스
    Private Sub TwoLST(ByVal lstOne As ListBox, ByVal lstNext As ListBox, ByVal lstThird As ListBox, ByVal strSht As String, ByRef intTable As Integer, ByVal DS_NAME As DataSet, ByVal intColOne As Integer, ByVal intColTwo As Integer, ByVal intColThree As Integer)
        Try
            ' App Click 시 Feature에 맞도록
            Dim Table As DataTable = DS_NAME.Tables(intTable)
            lstThird.Items.Clear()
            DesTxt_FUT.Text = ""            ' 설명 초기화 
            For i As Integer = 0 To Table.Rows.Count - 1    ' Data table Row 만큼 반복 -1은 마지막행은 Null

                If lstOne.Text = Table.Rows(i)(intColOne).ToString() And lstNext.Text = Table.Rows(i)(intColTwo).ToString() Then ' 선택 된 App과 Row, 필트(0)은 App, (1) 은 Feature
                    Try
                        If Not lstThird.Items.Contains(Table.Rows(i)(intColThree).ToString()) Then  ' 중복 없이 Item 추가
                            lstThird.Items.Add(Table.Rows(i)(intColThree).ToString())
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

    ' #### FUT APP 선택 시 ####
    Private Sub lstApp_FUT_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstApp_FUT.SelectedIndexChanged
        Dim intTable As Integer = 0
        Dim strSht As String = "App_Feature_Des"
        Dim intColOne As Integer = 0
        Dim intColTwo As Integer = 1

        OneLST(lstApp_FUT, lstFea_FUT, strSht, intTable, DS_FUT, intColOne, intColTwo)


        If lstApp_FUT.Text = "3rd Party" Then
            With txtFea_FUT
                .Text = "여기에 앱이름 작성"
                .Multiline = False
                .ForeColor = Color.Gray
            End With
        ElseIf lstApp_FUT.Text = "Buyer App" Then
            With txtFea_FUT
                .Text = "여기에 앱이름 작성"
                .Multiline = False
                .ForeColor = Color.Gray
            End With
        Else

            'Summ.Text = ""
            With txtFea_FUT
                .Text = ""
                .Font = New Font("맑은 고딕", 9)
                .ForeColor = Color.Black
            End With

        End If



    End Sub
    ' #### FUT Action 선택 시 ####
    Private Sub lstAction_FUT_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstAction_FUT.SelectedIndexChanged
        Dim intTable As Integer = 1
        Dim strSht As String = "TD_NEXT_AD_Des"
        'TwoLST(lstApp_FUT, lstType_FUT, lstSym_FUT, strSht, intTable, DS_FUT, intColOne:=0, intColTwo:=1, intColThree:=2)
        '   OneLST(lstAction_FUT, lstSym1_FUT, strSht, intTable, DS_FUT, intColOne:=0, intColTwo:=2)

        ' 설명 보여주는 부분 
        Dim Table As DataTable = DS_FUT.Tables(1)

        DesTxt_FUT.Text = ""

        For i As Integer = 0 To Table.Rows.Count - 1                ' Data table Row 만큼 반복 -1은 마지막행은 Null
            If lstAction_FUT.Text = Table.Rows(i)(1).ToString() Then     ' 선택 된 App과 Row, 필트(0)은 App, (1) 은 Feature
                Try
                    DesTxt_FUT.Text = Table.Rows(i)(2).ToString()
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try

            End If
        Next
    End Sub
    ' #### FUT 대분류 선택 시 ####
    Private Sub lstDae_FUT_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstDae_FUT.SelectedIndexChanged
        Dim intTable As Integer = 6                 ' 테이블 넘버 ex) App,Feature_DB, App_Feature_Des etc ... 
        Dim strSht As String = "FUT_Data"    ' 나타낼 Table 지정

        lstSo_FUT.Items.Clear()


        OneLST(lstDae_FUT, lstJoong_FUT, strSht, intTable, DS_FUT, intColOne:=1, intColTwo:=2)

        '' 설명 보여주는 부분 
        'Dim Table As DataTable = DS_FUT.Tables(6)

        'DesTxt_FUT.Text = ""

        'For i As Integer = 0 To Table.Rows.Count - 1                ' Data table Row 만큼 반복 -1은 마지막행은 Null
        '    If lstDae_FUT.Text = Table.Rows(i)(1).ToString() Then     ' 선택 된 App과 Row, 필트(0)은 App, (1) 은 Feature
        '        Try
        '            DesTxt_FUT.Text = Table.Rows(i)(4).ToString()
        '        Catch ex As Exception
        '            MsgBox(ex.Message)
        '        End Try

        '    End If
        'Next

    End Sub

    Private Sub lstJoong_FUT_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstJoong_FUT.SelectedIndexChanged
        Dim intTable As Integer = 6                 ' 테이블 넘버 ex) App,Feature_DB, App_Feature_Des etc ... 
        Dim strSht As String = "FUT_Data"    ' 나타낼 Table 지정

        TwoLST(lstDae_FUT, lstJoong_FUT, lstSo_FUT, strSht, intTable, DS_FUT, intColOne:=1, intColTwo:=2, intColThree:=3)


        '' 설명 보여주는 부분 
        'Dim Table As DataTable = DS_FUT.Tables(6)

        'DesTxt_FUT.Text = ""

        'For i As Integer = 0 To Table.Rows.Count - 1                ' Data table Row 만큼 반복 -1은 마지막행은 Null
        '    If lstJoong_FUT.Text = Table.Rows(i)(2).ToString() Then     ' 선택 된 App과 Row, 필트(0)은 App, (1) 은 Feature
        '        Try
        '            DesTxt_FUT.Text = Table.Rows(i)(4).ToString()
        '        Catch ex As Exception
        '            MsgBox(ex.Message)
        '        End Try

        '    End If
        'Next

    End Sub
    Private Sub lstSo_FUT_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstSo_FUT.SelectedIndexChanged
        ' 설명 보여주는 부분 
        Dim Table As DataTable = DS_FUT.Tables(6)

        DesTxt_FUT.Text = ""

        For i As Integer = 0 To Table.Rows.Count - 1                ' Data table Row 만큼 반복 -1은 마지막행은 Null
            If lstSo_FUT.Text = Table.Rows(i)(3).ToString() Then     ' 선택 된 App과 Row, 필트(0)은 App, (1) 은 Feature
                Try
                    DesTxt_FUT.Text = lstDae_FUT.Text & "> " & lstJoong_FUT.Text & " ==>> " & Table.Rows(i)(4).ToString()
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try

            End If
        Next

    End Sub
    ' ######## FUT Load 하는 부분 ##########

    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        ' === 선택되지 않은 항목이 있을때 메세지 보여줌
        If lstApp_FUT.Text = "" Then MsgBox("App이 선택되지 않았습니다. 선택 후 재시도 해주세요") : Exit Sub
        If lstAction_FUT.Text = "" Then MsgBox("Test_Action이 선택되지 않았습니다. 선택 후 재시도 해주세요") : Exit Sub
        If lstSym1_FUT.Text = "" Then MsgBox("Detailed_Symptom1이 선택되지 않았습니다. 선택 후 재시도 해주세요") : Exit Sub
        If lstSym2_FUT.Text = "" Then MsgBox("Detailed_Symptom2이 선택되지 않았습니다. 선택 후 재시도 해주세요") : Exit Sub
        If lstDae_FUT.Text = "" Then MsgBox("대분류가 선택되지 않았습니다. 선택 후 재시도 해주세요") : Exit Sub
        If lstJoong_FUT.Text = "" Then MsgBox("중분류가 선택되지 않았습니다. 선택 후 재시도 해주세요.") : Exit Sub
        If lstFre_FUT.Text = "" Then MsgBox("Frequency Rate가 선택되지 않았습니다. 선택 후 재시도 해주세요") : Exit Sub
        If lstSo_FUT.Text = "" Then MsgBox("소분류가 선택되지 않았습니다. 선택 후 재시도 해주세요") : Exit Sub
        If CompanyCB_FUT.Text = "" Then MsgBox("업체를 선택 후 시도해주세요") : Exit Sub
        If txtAdmin_FUT.Text = "" Then MsgBox("관리자 이름이 입력되지 않았습니다.") : Exit Sub
        If txtTester_FUT.Text = "" Then MsgBox("검증원 이름이 입력되지 않았습니다.") : Exit Sub
        If txtML_FUT.Text = "" Then MsgBox("모델리더 이름이 입력되지 않았습니다.") : Exit Sub



        If Summ_FUT.Text <> "" And Strings.Left(Summ_FUT.Text, 3) <> "ex)" Then   ' 서머리 부분에 내용이 있다면 진행

            Dim blHan As Boolean
            For Each ch As Char In Summ_FUT.Text
                If ch.IsHangul() Then
                    blHan = True
                Else
                    blHan = False
                End If
            Next

            ' 업체에 따라 선택할 수 있도록
            Dim strSht3 As String

            If CompanyCB_FUT.Text = "CNS" Then
                strSht3 = "Contacts_C"
            ElseIf CompanyCB_FUT.Text = "인피닉" Then
                strSht3 = "Contacts_I"
            ElseIf CompanyCB_FUT.Text = "엠스텍" Then
                strSht3 = "Contacts_M"
            End If

            Dim ConTable As DataTable = Nothing

            Dim strRank As String
            Dim strName As String
            Dim strNum As String
            Dim strCom As String

            ' 업체 별 Tel 변경
            Dim intFnd As Integer = 2
            If CompanyCB_FUT.Text = "CNS" Then
                strRank = "직급_C"
                strName = "이름_C"
                strNum = "휴대폰_C"
                strCom = "업체_C"
                'intFnd = 2
                ConTable = DS_FUT.Tables(3)

            ElseIf CompanyCB_FUT.Text = "인피닉" Then
                strRank = "직급_I"
                strName = "이름_I"
                strNum = "휴대폰_I"
                strCom = "업체_I"
                'intFnd = 6
                ConTable = DS_FUT.Tables(4)
            ElseIf CompanyCB_FUT.Text = "엠스텍" Then
                strRank = "직급_M"
                strName = "이름_M"
                strNum = "휴대폰_M"
                strCom = "업체_M"
                'intFnd = 10
                ConTable = DS_FUT.Tables(5)
            End If

            Dim strString(100)      ' Description 담는 배열 
            Dim chBox(6) As String  ' 첨부 파일 담는 배열


            '# 테이블 제작 하기 
            Dim DesDT As DataTable = Nothing
            Dim dRow As DataRow = Nothing
            Dim dCol As DataColumn = Nothing
            DesDT = New DataTable()

            dCol = New DataColumn()     '# DataColumn 생성
            dCol.DataType = System.Type.GetType("System.String")
            dCol.ColumnName = "Description"

            DesDT.Columns.Add(dCol)        '# Column 추가

            dCol = New DataColumn()     '# DataColumn 생성
            dCol.DataType = System.Type.GetType("System.String")
            dCol.ColumnName = "MarketApp"

            DesDT.Columns.Add(dCol)        '# Column 추가

            '# 수정 시간 : 180810
            '# 임시로 데이터 테이블을 만들어서 제작 합니다.
            '# 원래는 xml 또는 ini 을 이용하여 하여야 하지만 시간상.... 
            With DesDT.Rows
                .Add("1. Title : ", "1.Title : ")
                .Add("2. Precondition : ", "2. App Name : ")
                .Add("3. Tester`s Action : ", "3. Vendor : ")
                .Add("4. Detailed Symptom (ENG.) : ", "4. Version : ")
                .Add("5. Detailed Symptom (KOR.) : ", "5. Download Rating : ")
                .Add("6. Expected : ", "6. Precondition : ")
                .Add("7. Reproducibility : ", "7. Step to reproduce : ")
                .Add("  1) Frequency Rate : ", "  1) ")
                .Add("  2) One-Time Symptom : ", "  2) ")
                .Add("8. Comparison Results : ", "8. Actual result : ")
                .Add("  1) Model Comparing : ", "9. Expect result : ")
                .Add("  2) UI Scenario Comparing : N", "10. LG Reference models behavior : ")
                .Add("  3) Reboot 후 재현여부 : ", "11. Competitor models behavior : ")
                .Add("9. Attached files : ", "12. Attached files : ")
                .Add("  1) Log : ", "  1) Log : ")
                .Add("  2) Test Contents : ", "  2) Test Contents : ")
                .Add("  3) Video file : ", "  3) Video file : ")
                .Add("  4) Image file : ", "  4) Image file : ")
                .Add("  5) LG Backup file : ", "  5)LG Backup file : ")
                .Add("  6) Voice Record file : ", "  6)Voice Record file : ")
                .Add("10. Peer Review : ", "13. Peer Review : ")
                .Add("11. Additional App : N", "14. Additional App : N ")
                .Add("12. Tel : ", "15. Tel : ")
                .Add("  1) Tester : ", "  1) Tester : ")
                .Add("  2) Model leader : ", "  2) Model leader : ")
                .Add("  3) Administrator : ", "  3) Administrator : ")
                .Add("13. 문제사유 : ", "16. 문제사유 : ")
                .Add("14. 내용 : ", "17. 내용 : ")
            End With


            ' ### 3rd Party 앱은 마켓앱 전용 양식으로 불러올 수 있도록 #####
            If lstApp_FUT.Text = "3rd Party" Then
                For i As Integer = 0 To 29
                    Try
                        strString(i) = DesDT.Rows(i)(6).ToString()
                    Catch ex As Exception
                        MsgBox(ex.Message)
                    End Try
                Next i

            Else   ' ### 일반적인 경우 ####


                For i As Integer = 0 To 29
                    Try
                        strString(i) = DesDT.Rows(i)(5).ToString()      ' (9)는 일반 (10)은 Market App
                    Catch ex As Exception
                        MsgBox(ex.Message)
                    End Try
                Next i

                'Frequency rate 입력 및 one-time symptom 입력
                strString(7) = strString(7) + lstFre.Text
                If lstFre_FUT.Text = "One-Time" Then
                    strString(8) = strString(8) + "Y"
                Else
                    strString(8) = strString(8) + "N"
                End If
            End If

            ' 첨부파일 Y/N 판별해주는 부분
            If CheckBox1_FUT.Checked = True Then
                chBox(0) = "Y (문제발생시간:    ,로그추출시간:     )"
            Else
                chBox(0) = "N"
            End If

            If CheckBox2_FUT.Checked = True Then
                chBox(1) = "Y"
            Else
                chBox(1) = "N"
            End If

            If CheckBox3_FUT.Checked = True Then
                chBox(2) = "Y"
            Else
                chBox(2) = "N"
            End If

            If CheckBox4_FUT.Checked = True Then
                chBox(3) = "Y"
            Else
                chBox(3) = "N"
            End If

            If CheckBox5_FUT.Checked = True Then
                chBox(4) = "Y"
            Else
                chBox(4) = "N"
            End If

            If CheckBox6_FUT.Checked = True Then
                chBox(5) = "Y"
            Else
                chBox(5) = "N"
            End If

            ' 첨부파일 값 넣어주기 
            Dim j As Integer = 0
            For i = 14 To 19
                strString(i) = strString(i) + chBox(j)
                j = j + 1
            Next i

            ' 모델리더, 테스터, 관리자 자동으로 입력해주는 부분
            Dim strML As String = txtML_FUT.Text
            Dim strTester As String = txtTester_FUT.Text
            Dim strAdmin As String = txtAdmin_FUT.Text

            Dim ECheck As Boolean = False
            Dim ECheck_ml As Boolean = False
            Dim ECheck_admin As Boolean = False

            If CompanyCB.Text = tb.getCompnay Then
                MsgBox("업체가 안맞습니다. 관리자에게 문의해주세요", , "lee.sunbae@lgepartner.com")
                Exit Sub
            ElseIf tb.getUserName() = "미등록 사용자" Then
                MsgBox("등록되지 않은 사용자입니다. 관리자에게 문의해주세요", , "lee.sunbae@lgepartner.com")
                Exit Sub
            End If




            For i As Integer = 0 To ConTable.Rows.Count - 1                ' Data table Row 만큼 반복 -1은 마지막행은 Null
                ' If txtTester.Text = ConTable.Rows(i)(intFnd - 1).ToString() Then     ' 선택 된 App과 Row, 필트(0)은 App, (1) 은 Feature
                Dim strComName As String = ConTable.Rows(i)(intFnd).ToString()
                Try
                    ' 모델리더 / 테스터 / 관리자 핸드폰 번호 DB에서 찾아 넣는 구간

                    If strTester = strComName Then
                        strString(23) = strString(23) + strTester + " " + ConTable.Rows(i)(intFnd - 1).ToString() + " " + ConTable.Rows(i)(intFnd + 1).ToString()
                        ECheck = True
                    End If

                    If strML = strComName Then
                        strString(24) = strString(24) + strML + " " + ConTable.Rows(i)(intFnd - 1).ToString() + " " + ConTable.Rows(i)(intFnd + 1).ToString()
                        strString(20) = strString(20) + strML + " " + ConTable.Rows(i)(intFnd - 1).ToString()
                        ECheck_ml = True
                    End If

                    If strAdmin = strComName Then
                        strString(25) = strString(25) + strAdmin + " " + ConTable.Rows(i)(intFnd - 1).ToString() + " " + ConTable.Rows(i)(intFnd + 1).ToString()
                        ECheck_admin = True
                    End If

                    If ECheck = True And ECheck_admin = True And ECheck_ml = True Then
                        Exit For
                    End If

                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try

            Next

            ' 이름이 없는 경우 / 맞지 않은 경우
            If ECheck = False Or ECheck_ml = False Or ECheck_admin = False Then
                MsgBox("업체가 안맞거나, 없는 이름입니다. 관리자에게 문의해주세요", , "lee.sunbae@lgepartner.com")
                Exit Sub
            End If


            Dim strSum As String
            ' ################################# Summary Text 만들기 ###################################################
            If InStr(Summ_FUT.Text, "//") Then  ' 이미 작성 한게 있을 때!
                ' 서머리 양식 만들기
                If MsgBox("새로 불러 옵니다. " & "진행 하시겠습니까?", vbQuestion + vbYesNo, "lee.sunbabe@lgepartner.com") = vbNo Then
                    Exit Sub
                Else
                    Summ_FUT.Text = Strings.Left(Summ_FUT.Text, InStr(Summ_FUT.Text, "//") - 3)
                    If lstFea_FUT.Text = "" Then 'Feature가 선택되지 않았을때
                        If txtFea_FUT.Text = "" Then
                            strSum = " //" & "[" & lstApp_FUT.Text & "]" & "[" & lstAction_FUT.Text & "]" & "[" & lstSym1_FUT.Text & "__" & lstSym2_FUT.Text & "]" & "[" & lstDae_FUT.Text & "_" & lstJoong_FUT.Text & "]" & "[" & lstSo_FUT.Text & "]"
                        Else
                            strSum = " //" & "[" & lstApp_FUT.Text & "_" & txtFea_FUT.Text & "]" & "[" & lstAction_FUT.Text & "]" & "[" & lstSym1_FUT.Text & "__" & lstSym2_FUT.Text & "]" & "[" & lstDae_FUT.Text & "_" & lstJoong_FUT.Text & "]" & "[" & lstSo_FUT.Text & "]"
                        End If
                    Else
                        strSum = " //" & "[" & lstApp_FUT.Text & "_" & lstFea_FUT.Text & "]" & "[" & lstAction_FUT.Text & "]" & "[" & lstSym1_FUT.Text & "__" & lstSym2_FUT.Text & "]" & "[" & lstDae_FUT.Text & "_" & lstJoong_FUT.Text & "]" & "[" & lstSo_FUT.Text & "]"
                    End If
                    'Summary title 부분 추가
                    Summ_FUT.Text = Summ_FUT.Text + " " + strSum
                    ' 서머리 양식 만들기
                    strString(0) = strString(0) + Summ_FUT.Text
                    '               1. Title :      + Call 안됨  +  //[Voice Call_OutgoingCall........]
                End If

            Else    ' 만약에 서머리에 // 이게 없다면 새로 쓰는 거 !  즉, 새로 작성 할 때

                If lstFea_FUT.Text = "" Then 'Feature가 선택되지 않았을때
                    If txtFea_FUT.Text = "" Then
                        strSum = " //" & "[" & lstApp_FUT.Text & "]" & "[" & lstAction_FUT.Text & "]" & "[" & lstSym1_FUT.Text & "__" & lstSym2_FUT.Text & "]" & "[" & lstDae_FUT.Text & "_" & lstJoong_FUT.Text & "]" & "[" & lstSo_FUT.Text & "]"
                    Else
                        strSum = " //" & "[" & lstApp_FUT.Text & "_" & txtFea_FUT.Text & "]" & "[" & lstAction_FUT.Text & "]" & "[" & lstSym1_FUT.Text & "__" & lstSym2_FUT.Text & "]" & "[" & lstDae_FUT.Text & "_" & lstJoong_FUT.Text & "]" & "[" & lstSo_FUT.Text & "]"
                    End If
                Else
                    strSum = " //" & "[" & lstApp_FUT.Text & "_" & lstFea_FUT.Text & "]" & "[" & lstAction_FUT.Text & "]" & "[" & lstSym1_FUT.Text & "__" & lstSym2_FUT.Text & "]" & "[" & lstDae_FUT.Text & "_" & lstJoong_FUT.Text & "]" & "[" & lstSo_FUT.Text & "]"
                End If

                'Summary title 부분 추가
                Summ_FUT.Text = Summ_FUT.Text + " " + strSum
                ' 서머리 양식 만들기
                strString(0) = strString(0) + Summ_FUT.Text
                '1. Title :      + Call 안됨  +  //[Voice Call_OutgoingCall........]

            End If


            Dim strCompareTemp As String = txtResult_FUT.Text

            txtResult_FUT.Text = ""

            For i = 0 To 29

                ' 3rd Party 인경우만 !!!!!
                If lstApp_FUT.Text = "3rd Party" Then

                    If i = 5 Then ' 프리컨디션 추가 부분
                        txtResult_FUT.Text = txtResult_FUT.Text & strString(i) & vbCrLf & "  " & txtPre_FUT.Text & vbCrLf
                        i = i + 1
                    End If

                    txtResult_FUT.Text = txtResult_FUT.Text & strString(i) & vbCrLf


                Else   ' 일반적인 Summary Description 작성 부분


                    If i = 1 Then ' 프리컨디션 추가부분
                        txtResult_FUT.Text = txtResult_FUT.Text & strString(i) & vbCrLf & "  " & txtPre_FUT.Text & vbCrLf
                        i = i + 1
                    End If

                    If blHan = False Then ' 영어면 
                        If i = 3 Then ' 디테일심텀 추가부분   17.04.21 이순배 [영어]
                            txtResult_FUT.Text = txtResult_FUT.Text & strString(i) & vbCrLf & "  " & Strings.Left(Summ_FUT.Text, InStr(Summ_FUT.Text, "//") - 1) & vbCrLf
                            i = i + 1
                        End If
                    ElseIf blHan = True Then
                        If i = 4 Then ' 디테일심텀 추가부분   17.04.21 이순배 [한글]
                            txtResult_FUT.Text = txtResult_FUT.Text & strString(i) & vbCrLf & "  " & Strings.Left(Summ_FUT.Text, InStr(Summ_FUT.Text, "//") - 1) & vbCrLf
                            i = i + 1
                        End If

                    End If


                    If i = 10 Then ' 비교시료 추가부분
                        If Strings.Left(txtModel_FUT.Text, 3) = "ex)" Then
                            txtResult_FUT.Text = txtResult_FUT.Text & strString(i) & vbCrLf
                        Else
                            'Enter(Chr(10)) 키 입력시 Split하여 앞에 공간 추가 하여 결과 보여줌

                            Dim arrVal = Split(txtModel_FUT.Text, Chr(10))
                            txtResult_FUT.Text = txtResult_FUT.Text & strString(i) & vbCrLf
                            'txtResult.Text = txtResult.Text & strString(i) & vbCrLf & "  " & txtModel.Text & vbCrLf
                            For z = 0 To UBound(arrVal)
                                If z = UBound(arrVal) Then
                                    txtResult_FUT.Text = txtResult_FUT.Text & "    " & arrVal(z) '& Chr(10)
                                Else
                                    txtResult_FUT.Text = txtResult_FUT.Text & "    " & arrVal(z) & Chr(10)
                                End If
                            Next z
                            txtResult_FUT.Text = txtResult_FUT.Text & vbCrLf
                        End If

                        i = i + 1
                    End If

                    '최종
                    txtResult_FUT.Text = txtResult_FUT.Text & strString(i) & vbCrLf

                End If
            Next i

        ElseIf Summ_FUT.Text = "" Or Strings.Left(Summ_FUT.Text, 3) = "ex)" Then
            MsgBox("Summary Title 을 입력한 후 Load를 다시 해주세요",, "lee.sunbae@lgepartner.com")
            Exit Sub
        End If

        Dim strGeneral As String = "GENERAL Defect Description"
        If CheckBox7_FUT.Checked = True Then
            txtResult_FUT.Text = strGeneral & vbCrLf & txtResult_FUT.Text
        Else

        End If

    End Sub

    Private Sub lstSym1_FUT_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstSym1_FUT.SelectedIndexChanged
        ' 설명 보여주는 부분 
        Dim Table As DataTable = DS_FUT.Tables(1)

        DesTxt_FUT.Text = ""

        For i As Integer = 0 To Table.Rows.Count - 1                ' Data table Row 만큼 반복 -1은 마지막행은 Null
            If lstSym1_FUT.Text = Table.Rows(i)(3).ToString() Then     ' 선택 된 App과 Row, 필트(0)은 App, (1) 은 Feature
                Try
                    DesTxt_FUT.Text = Table.Rows(i)(4).ToString()
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try

            End If
        Next


    End Sub
    Private Sub lstSym2_FUT_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstSym2_FUT.SelectedIndexChanged

        ' 설명 보여주는 부분 
        Dim Table As DataTable = DS_FUT.Tables(1)

        DesTxt_FUT.Text = ""

        For i As Integer = 0 To Table.Rows.Count - 1                ' Data table Row 만큼 반복 -1은 마지막행은 Null
            If lstSym2_FUT.Text = Table.Rows(i)(5).ToString() Then     ' 선택 된 App과 Row, 필트(0)은 App, (1) 은 Feature
                Try
                    DesTxt_FUT.Text = Table.Rows(i)(6).ToString()
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try

            End If
        Next


    End Sub

    Private Sub txtModel_TextChanged(sender As Object, e As EventArgs) Handles txtModel.TextChanged
        If InStr(txtModel.Text, "ex)") Then
            With txtModel
                .ForeColor = Color.Gray
            End With
        Else
            'Summ.Text = ""
            With txtModel
                .ForeColor = Color.Black
            End With
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs)
        'Dim Form2 As New Form2
        'If lstApp.Text = "" Then
        '    MsgBox("App을 선택한 후 사용 해 주세요.")
        '    Exit Sub
        'End If
        'Form2.strTDApp = lstApp.Text
        'Form2.Show()

    End Sub

    Private Sub lstSym_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles lstSym.SelectedIndexChanged
        ' App Click 시 Feature에 맞도록
        lstSym2.Items.Clear()
        'Dim Table As DataTable = DS.Tables(8)
        Dim columnSym As DataTable = DS.Tables(strSym)


        'Table.DefaultView.Sort = "Detailed_Symptom_1_1 ASC"
        'lstSym2.Items.Clear()      ' Data Clear 
        'DesTxt.Text = ""            ' 설명 초기화 

        For i As Integer = 0 To columnSym.Rows.Count - 1    ' Data table Row 만큼 반복 -1은 마지막행은 Null
            If lstSym.Text = columnSym.Rows(i)(1).ToString() Then ' 선택 된 App과 Row, 필트(0)은 App, (1) 은 Feature
                Try
                    If Not lstSym2.Items.Contains(columnSym.Rows(i)(2).ToString()) Then  ' 중복 없이 Item 추가
                        lstSym2.Items.Add(columnSym.Rows(i)(2).ToString())
                    End If
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            End If
        Next
    End Sub




    ' App Name
    Public Sub BuildTree(ByVal dt As DataTable, ByVal trv As TreeView, ByVal expandAll As [Boolean])
        ' Clear the TreeView if there are another datas in this TreeView
        trv.Nodes.Clear()
        Dim node As TreeNode
        Dim subNode As TreeNode
        Dim trdNode As TreeNode


        For Each row As DataRow In dt.Rows
            'search in the treeview if any country is already present
            node = Searchnode(row.Item(1).ToString(), trv)


            If node IsNot Nothing Then
                subNode = New TreeNode(row.Item(2).ToString())
                trdNode = New TreeNode(row.Item(3).ToString())

                If node.LastNode.Text <> row.Item(2).ToString() Then
                    node.Nodes.Add(subNode)
                    If trdNode.Text = "" Then

                    Else
                        subNode.Nodes.Add(trdNode)
                    End If
                ElseIf node.LastNode.Text = row.Item(2).ToString() Then

                    node.LastNode.Nodes.Add(trdNode)


                End If
            Else
                node = New TreeNode(row.Item(1).ToString())
                subNode = New TreeNode(row.Item(2).ToString())
                trdNode = New TreeNode(row.Item(3).ToString())

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

    Public Sub BuildTree_Action(ByVal dt As DataTable, ByVal trv As TreeView, ByVal expandAll As [Boolean])
        ' Clear the TreeView if there are another datas in this TreeView
        trv.Nodes.Clear()
        Dim node As TreeNode
        Dim subNode As TreeNode
        'Dim trdNode As TreeNode


        For Each row As DataRow In dt.Rows
            'search in the treeview if any country is already present
            node = Searchnode(row.Item(1).ToString(), trv)


            If node IsNot Nothing Then
                subNode = New TreeNode(row.Item(2).ToString())
                'trdNode = New TreeNode(row.Item(3).ToString())

                If node.LastNode.Text <> row.Item(2).ToString() Then
                    node.Nodes.Add(subNode)
                    'If trdNode.Text = "" Then

                    'Else
                    'subNode.Nodes.Add(trdNode)
                    'End If
                    'ElseIf node.LastNode.Text = row.Item(2).ToString() Then

                    'node.LastNode.Nodes.Add(trdNode)


                End If
            Else
                node = New TreeNode(row.Item(1).ToString())
                subNode = New TreeNode(row.Item(2).ToString())
                'trdNode = New TreeNode(row.Item(3).ToString())

                trv.Nodes.Add(node)

                If subNode.Text = "" Then

                Else
                    node.Nodes.Add(subNode)

                    'If trdNode.Text = "" Then

                    ' Else
                    'subNode.Nodes.Add(trdNode)
                    'End If
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

#Region "앱 리스트 클릭 했을 때"
    Private Sub trvApp_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles trvApp.AfterSelect
        Dim szNode() As String
        Dim Table_app As DataTable = DS.Tables(0)
        szNode = Split(trvApp.SelectedNode.FullPath, "\")
        chkNode = szNode.Length

        If trvApp.SelectedNode.Text = "3rd Party" Then
            txtApp.Text = trvApp.SelectedNode.Text
            txtFea.ReadOnly = False
            With txtFea
                .Text = "여기에 앱이름 작성"
                .Multiline = False
                .ForeColor = Color.Gray
            End With
        ElseIf trvApp.SelectedNode.Text = "Buyer App" Then
            txtApp.Text = trvApp.SelectedNode.Text
            txtFea.ReadOnly = False
            With txtFea
                .Text = "여기에 앱이름 작성"
                .Multiline = False
                .ForeColor = Color.Gray
            End With

        ElseIf chkNode = 1 And trvApp.SelectedNode.Text <> "3rd Party" And trvApp.SelectedNode.Text <> "Buyer App" Then
            txtApp.ReadOnly = True
            txtFea.ReadOnly = True
            txtApp.Text = trvApp.SelectedNode.Text
            txtFea.Text = ""

        ElseIf chkNode = 2 Then
            txtFea.ReadOnly = True
            txtApp.Text = trvApp.SelectedNode.Text
            txtFea.Text = ""
        ElseIf chkNode = 3 Then
            txtFea.ReadOnly = True
            txtApp.Text = trvApp.SelectedNode.Parent.Text
            txtFea.Text = trvApp.SelectedNode.Text

            'Summ.Text = ""
            'With txtFea
            '    .Text = ""
            '    .Font = New Font("맑은 고딕", 9)
            '    .ForeColor = Color.Black
            'End With
        End If


        DesTxt.Text = ""

        For i As Integer = 0 To Table_app.Rows.Count - 1
            Diagnostics.Debug.Print(Table_app.Rows(i)(2).ToString())
            If txtApp.Text = Table_app.Rows(i)(2).ToString() And txtFea.Text = Table_app.Rows(i)(3).ToString() Then
                Try
                    DesTxt.Text = Table_app.Rows(i)(4).ToString()
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            End If

        Next

    End Sub
#End Region

#Region "Test Action 선택 했을 때 "
    Private Sub trvAction_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles trvAction.AfterSelect
        Dim szNode() As String
        szNode = Split(trvAction.SelectedNode.FullPath, "\")
        chkNode_Action = szNode.Length


        Dim Table_Action As DataTable = DS.Tables(str_action)

        'Table_Action.DefaultView.Sort = "Detailed_Symptom_1 ASC"
        'lstSym.Items.Clear()
        'lstSym2.Items.Clear()
        If chkNode_Action < 2 Then
            txtActiontype.Text = trvAction.SelectedNode.Text
            txtAction.Text = ""

        Else
            txtActiontype.Text = trvAction.SelectedNode.Parent.Text
            txtAction.Text = trvAction.SelectedNode.Text
            'Actiontype TextBox에 값 넣기
        End If
        DesTxt.Text = ""

        For i As Integer = 0 To Table_Action.Rows.Count - 1                ' Data table Row 만큼 반복 -1은 마지막행은 Null
            If txtAction.Text = Table_Action.Rows(i)(2).ToString() Then     ' 선택 된 App과 Row, 필트(0)은 App, (1) 은 Feature
                Try
                    DesTxt.Text = Table_Action.Rows(i)(3).ToString()
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            End If
        Next

    End Sub
#End Region


    '// Wearable
#Region "Wearable 탭 부분 로드할 때"
    'Private Sub TabPage3_Enter(sender As Object, e As EventArgs) Handles TabPage3.Enter
    '    '################### Tap Page3 Wearable ###################
    '    Dim toolTip1 As New ToolTip()
    '    toolTip1.SetToolTip(requestBtn, "Q-Portal에 없는 앱이나 기능을 추가할 수 있습니다 ")
    '    toolTip1.InitialDelay = 500
    '    toolTip1.AutoPopDelay = 1000
    '    toolTip1.ReshowDelay = 500

    '    Try
    '        'Dim XML As New XML
    '        'XML.vCon_Call(vCon)
    '        'vConn = New OleDbConnection(vCon)

    '        ' 쿼리문 작성
    '        Dim szSQL As String = "Select * FROM [" + strWearapp + "] Where [AppName] > '' Order by AppName,Feature"
    '        Dim szSQL_Action As String = "Select * FROM [" + strTA + "]" ' Where [TestAction] > '' Order by TestAction,Detailed_Symptom_1,Detailed_Symptom_1_1"
    '        Dim szSht_TD As String = "Select * FROM [" + strDes + "]"
    '        Dim szConC As String = "Select * FROM [" + strCNS + "]"
    '        Dim szConI As String = "Select * FROM [" + strINFINIQ + "]"
    '        Dim szConM As String = "Select * FROM [" + strMSTech + "]"
    '        Dim szSQL_Sym As String = "Select * from [" + strSymp + "]"


    '        Dim szQuery As String() = New String() {szSQL, szSQL_Action, szSht_TD, szConC, szConI, szConM, szSQL_Sym}
    '        Dim loopSht As String() = New String() {strWearapp, strTA, strDes, strCNS, strINFINIQ, strMSTech, "Symptom12"}
    '        Dim nCnt As Integer = 0

    '        Try
    '            vConn = New OleDbConnection(vCon)   ' MainForm의 Connection String으로 DB Connect
    '            ' Looping 하여 Data Adapter 실행
    '            For Each a As String In szQuery
    '                Dim DA = New OleDbDataAdapter(a, vConn)
    '                DA.Fill(DS_Wear, loopSht(nCnt))
    '                nCnt += 1
    '            Next
    '            'DS.WriteXml(Application.StartupPath & "\Sunbae.XML")

    '        Catch ex As Exception
    '            MsgBox(ex.Message)
    '        End Try


    '        'XML = Nothing
    '        vConn = Nothing
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '        Exit Sub
    '    End Try

    '    ' Wearable AppName,Feature TreeView에 값 넣기
    '    If trvWapp.Nodes.Count = 0 Then
    '        Dim dt_tableWapp As DataTable = DS_Wear.Tables(0)
    '        Call BuildTree_Action(dt_tableWapp, trvWapp, False)

    '    End If

    '    ' TestAction TreeView에 값 넣기
    '    If trvWaction.Nodes.Count = 0 Then
    '        Dim dt_tableWaction As DataTable = DS_Wear.Tables(1)
    '        Call BuildTree_Action(dt_tableWaction, trvWaction, expandAll:=False)
    '        trvWaction.Sort()
    '    End If

    '    Dim columnsym As DataTable = DS_Wear.Tables(6)

    '    For i As Integer = 0 To columnsym.Rows.Count - 1   ' Data table Row 만큼 반복 -1은 마지막행은 Null
    '        If Not lstWsym.Items.Contains(columnsym.Rows(i)(1).ToString()) Then
    '            lstWsym.Items.Add(columnsym.Rows(i)(1).ToString())
    '        End If

    '    Next

    '    ' Frequency Rate List
    '    Dim Table_FrequencyRate As DataTable = DS.Tables(2)
    '    Table_FrequencyRate = Table_FrequencyRate.DefaultView.ToTable(True, "Frequency Rate") ' (true, <-- 중복제거하는 옵션)
    '    With lstWfre.Items
    '        .Add("100% (10/10)")
    '        .Add("1% ~ 50%")
    '        .Add("51% ~ 99%")
    '        .Add("One-Time")
    '        .Add("Specific HW")
    '    End With

    '    ' 검증유형 List
    '    If lstWca.Items.Count = 0 Then
    '        With lstWca.Items
    '            .Add("Random_변경점")
    '            .Add("Random_변경점X")
    '        End With
    '    End If

    '    ' 검증계획서 List
    '    If lstWplan.Items.Count = 0 Then
    '        With lstWplan.Items
    '            .Add("Plan")
    '            .Add("Not Plan")
    '        End With
    '    End If

    '    ' Pre-Condition 넣어 주기 
    '    With txtWpre
    '        .Text = "1) Board D/L ()"
    '        .Multiline = True
    '    End With

    '    ' 비교모델 관련
    '    With txtWmodel
    '        .Text = "ex) H960TR : 재현 안됨"
    '        .Multiline = True
    '        .ForeColor = Color.Gray
    '    End With

    '    If cbWcompany.Items.Count = 0 Then
    '        With cbWcompany.Items
    '            .Add("CNS")
    '            .Add("엠스텍")
    '            .Add("인피닉")
    '        End With
    '    End If
    '    cbWcompany.Text = cbWcompany.Items(0)
    '    '사용자 이름 불러오기
    '    Dim strName As String = Nothing
    '    Dim strEP As String = Nothing
    '    Dim xml As New XML

    '    xml.GetUserName(strEP, strName)
    '    xml = Nothing

    '    txtWtester.Text = strName

    '    ' Text Box 편집관련
    '    txtWapp.ReadOnly = True
    '    txtWfea.ReadOnly = True
    '    txtWaction.ReadOnly = True
    '    txtWactiontype.ReadOnly = True

    'End Sub

    Private Sub trvWapp_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles trvWapp.AfterSelect
        Dim szNode() As String
        Dim Table_Wapp As DataTable = DS_Wear.Tables(0)
        szNode = Split(trvWapp.SelectedNode.FullPath, "\")
        chkNodeWapp = szNode.Length

        If chkNodeWapp < 2 Then
            txtWapp.Text = trvWapp.SelectedNode.Text
            txtWfea.Text = ""
        Else
            txtWapp.Text = trvWapp.SelectedNode.Parent.Text
            txtWfea.Text = trvWapp.SelectedNode.Text
        End If

        For i As Integer = 0 To Table_Wapp.Rows.Count - 1
            If trvWapp.SelectedNode.Text = Table_Wapp.Rows(i)(2).ToString() Then
                txtWdes.Text = Table_Wapp.Rows(i)(3).ToString()
            End If
        Next


    End Sub

    Private Sub trvWaction_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles trvWaction.AfterSelect
        Dim szNode() As String
        Dim Table_Waction As DataTable = DS_Wear.Tables(1)
        szNode = Split(trvWaction.SelectedNode.FullPath, "\")
        chkNodeWaction = szNode.Length

        If chkNodeWaction < 2 Then
            txtWactiontype.Text = trvWaction.SelectedNode.Text
            txtWaction.Text = ""
        Else
            txtWactiontype.Text = trvWaction.SelectedNode.Parent.Text
            txtWaction.Text = trvWaction.SelectedNode.Text
        End If

        For i As Integer = 0 To Table_Waction.Rows.Count - 1
            If trvWaction.SelectedNode.Text = Table_Waction.Rows(i)(2).ToString() Then
                txtWdes.Text = Table_Waction.Rows(i)(3).ToString()
            End If
        Next
    End Sub

    Private Sub lstWsym_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstWsym.SelectedIndexChanged
        Dim columnsym As DataTable = DS_Wear.Tables(6)
        lstWsym2.Items.Clear()

        For i As Integer = 0 To columnsym.Rows.Count - 1
            If lstWsym.Text = columnsym.Rows(i)(1).ToString() Then
                If Not lstWsym2.Items.Contains(columnsym.Rows(i)(2).ToString()) Then
                    lstWsym2.Items.Add(columnsym.Rows(i)(2).ToString())
                End If
            End If
        Next

    End Sub
#End Region







#Region "Wearable"
    '# (Wearable) Load 버튼 눌었을 때 
    Private Sub btWload_Click(sender As Object, e As EventArgs) Handles btWload.Click
        If chkNodeWapp < 2 Or trvWapp.SelectedNode Is Nothing Then
            MsgBox("App이 선택되지 않았거나, 첫번째 노드를 선택하였습니다." & vbCrLf & "선택 후 재시도 해주세요")
            Exit Sub
        End If
        If chkNodeWaction < 2 Or trvWaction.SelectedNode Is Nothing Then
            MsgBox("Test Action이 선택되지 않았거나, 첫번째 노드를 선택하였습니다" & vbCrLf & "선택 후 재시도 해주세요")
            Exit Sub
        End If
        If lstWsym.Text = "" Then MsgBox("Detailed_Symptom1이 선택되지 않았습니다. 선택 후 재시도 해주세요") : Exit Sub
        If lstWsym2.Text = "" Then MsgBox("Detailed_Symptom2이 선택되지 않았습니다. 선택 후 재시도 해주세요") : Exit Sub
        If lstWfre.Text = "" Then MsgBox("Frequency Rate가 선택되지 않았습니다. 선택 후 재시도 해주세요") : Exit Sub
        If lstWca.Text = "" Then MsgBox("검증유형이 선택되지 않았습니다. 선택 후 재시도 해주세요") : Exit Sub
        If lstWplan.Text = "" Then MsgBox("검증계획서가 선택되지 않았습니다. 선택 후 재시도 해주세요") : Exit Sub
        If cbWcompany.Text = "" Then MsgBox("업체를 선택 후 시도해주세요") : Exit Sub
        If txtWadmin.Text = "" Then MsgBox("관리자 이름이 입력되지 않았습니다.") : Exit Sub
        If txtWtester.Text = "" Then MsgBox("검증원 이름이 입력되지 않았습니다.") : Exit Sub
        If txtWml.Text = "" Then MsgBox("모델리더 이름이 입력되지 않았습니다.") : Exit Sub


        ' === 선택되지 않은 항목이 있을때 메세지 보여줌
        'If lstApp_FUT.Text = "" Then MsgBox("App이 선택되지 않았습니다. 선택 후 재시도 해주세요") : Exit Sub
        '    If lstAction_FUT.Text = "" Then MsgBox("Test_Action이 선택되지 않았습니다. 선택 후 재시도 해주세요") : Exit Sub

        If txtWsumm.Text <> "" And Strings.Left(txtWsumm.Text, 3) <> "ex)" Then   ' 서머리 부분에 내용이 있다면 진행

            Dim blHan As Boolean
            For Each ch As Char In Summ_FUT.Text
                If ch.IsHangul() Then
                    blHan = True
                Else
                    blHan = False
                End If
            Next

            ' 업체에 따라 선택할 수 있도록
            Dim strSht3 As String

            If cbWcompany.Text = "CNS" Then
                strSht3 = "Contacts_C"
            ElseIf cbWcompany.Text = "인피닉" Then
                strSht3 = "Contacts_I"
            ElseIf cbWcompany.Text = "엠스텍" Then
                strSht3 = "Contacts_M"
            End If

            Dim ConTable As DataTable = Nothing

            Dim strRank As String
            Dim strName As String
            Dim strNum As String
            Dim strCom As String

            ' 업체 별 Tel 변경
            Dim intFnd As Integer = 2
            If cbWcompany.Text = "CNS" Then
                strRank = "직급_C"
                strName = "이름_C"
                strNum = "휴대폰_C"
                strCom = "업체_C"
                'intFnd = 2
                ConTable = DS_Wear.Tables(3)

            ElseIf cbWcompany.Text = "인피닉" Then
                strRank = "직급_I"
                strName = "이름_I"
                strNum = "휴대폰_I"
                strCom = "업체_I"
                'intFnd = 6
                ConTable = DS_Wear.Tables(4)
            ElseIf cbWcompany.Text = "엠스텍" Then
                strRank = "직급_M"
                strName = "이름_M"
                strNum = "휴대폰_M"
                strCom = "업체_M"
                'intFnd = 10
                ConTable = DS_Wear.Tables(5)
            End If

            Dim strString(100)      ' Description 담는 배열 
            Dim chBox(6) As String  ' 첨부 파일 담는 배열

            '# 테이블 제작 하기 
            Dim WdesDT As DataTable = Nothing
            Dim dRow As DataRow = Nothing
            Dim dCol As DataColumn = Nothing
            WdesDT = New DataTable()

            dCol = New DataColumn()     '# DataColumn 생성
            dCol.DataType = System.Type.GetType("System.String")
            dCol.ColumnName = "Description"

            WdesDT.Columns.Add(dCol)        '# Column 추가

            dCol = New DataColumn()     '# DataColumn 생성
            dCol.DataType = System.Type.GetType("System.String")
            dCol.ColumnName = "MarketApp"

            WdesDT.Columns.Add(dCol)        '# Column 추가

            '# 수정 시간 : 180810
            '# 임시로 데이터 테이블을 만들어서 제작 합니다.
            '# 원래는 xml 또는 ini 을 이용하여 하여야 하지만 시간상.... 
            With WdesDT.Rows
                .Add("1. Title : ", "1.Title : ")
                .Add("2. Precondition : ", "2. App Name : ")
                .Add("3. Tester`s Action : ", "3. Vendor : ")
                .Add("4. Detailed Symptom (ENG.) : ", "4. Version : ")
                .Add("5. Detailed Symptom (KOR.) : ", "5. Download Rating : ")
                .Add("6. Expected : ", "6. Precondition : ")
                .Add("7. Reproducibility : ", "7. Step to reproduce : ")
                .Add("  1) Frequency Rate : ", "  1) ")
                .Add("  2) One-Time Symptom : ", "  2) ")
                .Add("8. Comparison Results : ", "8. Actual result : ")
                .Add("  1) Model Comparing : ", "9. Expect result : ")
                .Add("  2) UI Scenario Comparing : N", "10. LG Reference models behavior : ")
                .Add("  3) Reboot 후 재현여부 : ", "11. Competitor models behavior : ")
                .Add("9. Attached files : ", "12. Attached files : ")
                .Add("  1) Log : ", "  1) Log : ")
                .Add("  2) Test Contents : ", "  2) Test Contents : ")
                .Add("  3) Video file : ", "  3) Video file : ")
                .Add("  4) Image file : ", "  4) Image file : ")
                .Add("  5) LG Backup file : ", "  5)LG Backup file : ")
                .Add("  6) Voice Record file : ", "  6)Voice Record file : ")
                .Add("10. Peer Review : ", "13. Peer Review : ")
                .Add("11. Additional App : N", "14. Additional App : N ")
                .Add("12. Tel : ", "15. Tel : ")
                .Add("  1) Tester : ", "  1) Tester : ")
                .Add("  2) Model leader : ", "  2) Model leader : ")
                .Add("  3) Administrator : ", "  3) Administrator : ")
                .Add("13. 문제사유 : ", "16. 문제사유 : ")
                .Add("14. 내용 : ", "17. 내용 : ")
            End With
            ' ### 3rd Party 앱은 마켓앱 전용 양식으로 불러올 수 있도록 #####

            If trvWapp.SelectedNode.Text = "3rd Party" Then
                For i As Integer = 0 To 27
                    Try
                        strString(i) = WdesDT.Rows(i)(1).ToString()
                    Catch ex As Exception
                        MsgBox(ex.Message)
                    End Try
                Next i

            Else   ' ### 일반적인 경우 ####

                For i As Integer = 0 To 27
                    Try
                        strString(i) = WdesDT.Rows(i)(0).ToString()      ' (9)는 일반 (10)은 Market App
                    Catch ex As Exception
                        MsgBox(ex.Message)
                    End Try
                Next i

                'Frequency rate 입력 및 one-time symptom 입력
                strString(7) = strString(7) + lstWfre.Text
                If lstWfre.Text = "One-Time" Then
                    strString(8) = strString(8) + "Y"
                Else
                    strString(8) = strString(8) + "N"
                End If
            End If

            ' 첨부파일 Y/N 판별해주는 부분
            If chkWlog.Checked = True Then
                chBox(0) = "Y (문제발생시간:    ,로그추출시간:     )"
            Else
                chBox(0) = "N"
            End If

            If chkWcontents.Checked = True Then
                chBox(1) = "Y"
            Else
                chBox(1) = "N"
            End If

            If chkWvideo.Checked = True Then
                chBox(2) = "Y"
            Else
                chBox(2) = "N"
            End If

            If chkWimage.Checked = True Then
                chBox(3) = "Y"
            Else
                chBox(3) = "N"
            End If

            If chkWbackup.Checked = True Then
                chBox(4) = "Y"
            Else
                chBox(4) = "N"
            End If

            If chkWrecord.Checked = True Then
                chBox(5) = "Y"
            Else
                chBox(5) = "N"
            End If

            ' 첨부파일 값 넣어주기 
            Dim j As Integer = 0
            For i = 14 To 19
                strString(i) = strString(i) + chBox(j)
                j = j + 1
            Next i

            ' 모델리더, 테스터, 관리자 자동으로 입력해주는 부분
            Dim strML As String = txtWml.Text
            Dim strTester As String = txtWtester.Text
            Dim strAdmin As String = txtWadmin.Text

            Dim ECheck As Boolean = False
            Dim ECheck_ml As Boolean = False
            Dim ECheck_admin As Boolean = False

            For i As Integer = 0 To ConTable.Rows.Count - 1                ' Data table Row 만큼 반복 -1은 마지막행은 Null
                ' If txtTester.Text = ConTable.Rows(i)(intFnd - 1).ToString() Then     ' 선택 된 App과 Row, 필트(0)은 App, (1) 은 Feature
                Dim strComName As String = ConTable.Rows(i)(intFnd).ToString()
                Try
                    ' 모델리더 / 테스터 / 관리자 핸드폰 번호 DB에서 찾아 넣는 구간

                    If strTester = strComName Then
                        strString(23) = strString(23) + strTester + " " + ConTable.Rows(i)(intFnd - 1).ToString() + " " + ConTable.Rows(i)(intFnd + 1).ToString()
                        ECheck = True
                    End If

                    If strML = strComName Then
                        strString(24) = strString(24) + strML + " " + ConTable.Rows(i)(intFnd - 1).ToString() + " " + ConTable.Rows(i)(intFnd + 1).ToString()
                        strString(20) = strString(20) + strML + " " + ConTable.Rows(i)(intFnd - 1).ToString()
                        ECheck_ml = True
                    End If

                    If strAdmin = strComName Then
                        strString(25) = strString(25) + strAdmin + " " + ConTable.Rows(i)(intFnd - 1).ToString() + " " + ConTable.Rows(i)(intFnd + 1).ToString()
                        ECheck_admin = True
                    End If

                    If ECheck = True And ECheck_admin = True And ECheck_ml = True Then
                        Exit For
                    End If

                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try

            Next

            ' 이름이 없는 경우 / 맞지 않은 경우
            If ECheck = False Or ECheck_ml = False Or ECheck_admin = False Then
                MsgBox("업체가 안맞거나, 없는 이름입니다. 관리자에게 문의해주세요", , "lee.sunbae@lgepartner.com")
                Exit Sub
            End If


            Dim strSum As String
            ' ################################# Summary Text 만들기 ###################################################
            If InStr(txtWsumm.Text, "//") Then  ' 이미 작성 한게 있을 때!
                ' 서머리 양식 만들기
                If MsgBox("새로 불러 옵니다. " & "진행 하시겠습니까?", vbQuestion + vbYesNo, "lee.sunbabe@lgepartner.com") = vbNo Then
                    Exit Sub
                Else
                    txtWsumm.Text = Strings.Left(txtWsumm.Text, InStr(txtWsumm.Text, "//") - 3)
                    If txtWfea.Text = "" Then 'Feature가 선택되지 않았을때
                        If txtWfea.Text = "" Then
                            strSum = " //" & "[" & txtWapp.Text & "]" & "[" & txtWactiontype.Text & "_" & txtWaction.Text & "]" & "[" & lstWsym.Text & "_" & lstWsym2.Text & "]" & "[" & lstWplan.Text & "]" & "[" & lstWca.Text & "]"
                        Else
                            strSum = " //" & "[" & txtWapp.Text & "_" & txtWfea.Text & "]" & "[" & txtWactiontype.Text & "_" & txtWaction.Text & "]" & "[" & lstWsym.Text & "_" & lstWsym2.Text & "]" & "[" & lstWplan.Text & "]" & "[" & lstWca.Text & "]"
                        End If
                    Else
                        strSum = " //" & "[" & txtWapp.Text & "_" & txtWfea.Text & "]" & "[" & txtWactiontype.Text & "_" & txtWaction.Text & "]" & "[" & lstWsym.Text & "_" & lstWsym2.Text & "]" & "[" & lstWplan.Text & "]" & "[" & lstWca.Text & "]"
                    End If
                    'Summary title 부분 추가
                    txtWsumm.Text = txtWsumm.Text + " " + strSum
                    ' 서머리 양식 만들기
                    strString(0) = strString(0) + txtWsumm.Text
                    '               1. Title :      + Call 안됨  +  //[Voice Call_OutgoingCall........]
                End If

            Else    ' 만약에 서머리에 // 이게 없다면 새로 쓰는 거 !  즉, 새로 작성 할 때

                If txtWfea.Text = "" Then 'Feature가 선택되지 않았을때
                    If txtWfea.Text = "" Then
                        strSum = " //" & "[" & txtWapp.Text & "]" & "[" & txtWactiontype.Text & "_" & txtWaction.Text & "]" & "[" & lstWsym.Text & "_" & lstWsym2.Text & "]" & "[" & lstWplan.Text & "]" & "[" & lstWca.Text & "]"
                    Else
                        strSum = " //" & "[" & txtWapp.Text & "_" & txtWfea.Text & "]" & "[" & txtWactiontype.Text & "_" & txtWaction.Text & "]" & "[" & lstWsym.Text & "_" & lstWsym2.Text & "]" & "[" & lstWplan.Text & "]" & "[" & lstWca.Text & "]"
                    End If
                Else
                    strSum = " //" & "[" & txtWapp.Text & "_" & txtWfea.Text & "]" & "[" & txtWactiontype.Text & "_" & txtWaction.Text & "]" & "[" & lstWsym.Text & "_" & lstWsym2.Text & "]" & "[" & lstWplan.Text & "]" & "[" & lstWca.Text & "]"
                End If

                'Summary title 부분 추가
                txtWsumm.Text = txtWsumm.Text + " " + strSum
                ' 서머리 양식 만들기
                strString(0) = strString(0) + txtWsumm.Text
                '1. Title :      + Call 안됨  +  //[Voice Call_OutgoingCall........]

            End If


            Dim strCompareTemp As String = txtWresult.Text

            txtWresult.Text = ""

            For i = 0 To 29

                ' 3rd Party 인경우만 !!!!!
                If txtWapp.Text = "3rd Party" Then

                    If i = 5 Then ' 프리컨디션 추가 부분
                        txtWresult.Text = txtWresult.Text & strString(i) & vbCrLf & "  " & txtWpre.Text & vbCrLf
                        i = i + 1
                    End If

                    txtWresult.Text = txtWresult.Text & strString(i) & vbCrLf


                Else   ' 일반적인 Summary Description 작성 부분


                    If i = 1 Then ' 프리컨디션 추가부분
                        txtWresult.Text = txtWresult.Text & strString(i) & vbCrLf & "  " & txtWpre.Text & vbCrLf
                        i = i + 1
                    End If

                    If blHan = False Then ' 영어면 
                        If i = 3 Then ' 디테일심텀 추가부분   17.04.21 이순배 [영어]
                            txtWresult.Text = txtWresult.Text & strString(i) & vbCrLf & "  " & Strings.Left(txtWresult.Text, InStr(txtWresult.Text, "//") - 1) & vbCrLf
                            i = i + 1
                        End If
                    ElseIf blHan = True Then
                        If i = 4 Then ' 디테일심텀 추가부분   17.04.21 이순배 [한글]
                            txtWresult.Text = txtWresult.Text & strString(i) & vbCrLf & "  " & Strings.Left(txtWresult.Text, InStr(txtWresult.Text, "//") - 1) & vbCrLf
                            i = i + 1
                        End If

                    End If


                    If i = 10 Then ' 비교시료 추가부분
                        If Strings.Left(txtWmodel.Text, 3) = "ex)" Then
                            txtWresult.Text = txtWresult.Text & strString(i) & vbCrLf
                        Else
                            'Enter(Chr(10)) 키 입력시 Split하여 앞에 공간 추가 하여 결과 보여줌

                            Dim arrVal = Split(txtWmodel.Text, Chr(10))
                            txtWresult.Text = txtWresult.Text & strString(i) & vbCrLf
                            'txtResult.Text = txtResult.Text & strString(i) & vbCrLf & "  " & txtModel.Text & vbCrLf
                            For z = 0 To UBound(arrVal)
                                If z = UBound(arrVal) Then
                                    txtWresult.Text = txtWresult.Text & "    " & arrVal(z) '& Chr(10)
                                Else
                                    txtWresult.Text = txtWresult.Text & "    " & arrVal(z) & Chr(10)
                                End If
                            Next z
                            txtWresult.Text = txtWresult.Text & vbCrLf
                        End If

                        i = i + 1
                    End If

                    '최종
                    txtWresult.Text = txtWresult.Text & strString(i) & vbCrLf

                End If
            Next i

        ElseIf txtWsumm.Text = "" Or Strings.Left(txtWsumm.Text, 3) = "ex)" Then
            MsgBox("Summary Title 을 입력한 후 Load를 다시 해주세요",, "lee.sunbae@lgepartner.com")
            Exit Sub
        End If
        Dim strGeneral As String = "GENERAL Defect Description"
        If chkWgeneral.Checked = True Then
            txtWresult.Text = strGeneral & vbCrLf & txtWresult.Text
        Else

        End If
    End Sub


    '# (Wearable) 비교 모델 쓰는 곳
    Private Sub txtWmodel_leave(sender As Object, e As EventArgs) Handles txtWmodel.Leave
        If txtWmodel.Text = "" Then
            With txtWmodel
                .Text = "ex) H960TR : 재현 안됨"
                .ForeColor = Color.Gray
            End With
        End If
    End Sub

    '# (Wearable) 비교 모델 클릭했을 때 색상 지정
    Private Sub txtWmodel_GotFocus(sender As Object, e As EventArgs) Handles txtWmodel.GotFocus
        If InStr(txtWmodel.Text, "ex)") Then
            With txtWmodel
                .Text = ""
                .ForeColor = Color.Black
            End With
        End If
    End Sub

    '# (Wearable) Reset 버튼  눌렀을 때
    Private Sub Btn_Reset_Wear_Click(sender As Object, e As EventArgs) Handles Btn_Reset_Wear.Click
        If MsgBox("내용이 모두 사라집니다." & "정말 진행 하시겠습니까?" & vbCrLf & "지우지 않고, 원하는 항목 선택 후 재 Load 하셔도 됩니다.", vbQuestion + vbYesNo, "lee.sunbae@lgepartner.com") = vbNo Then
            Exit Sub
        Else
            txtResult.Text = ""
            txtWsumm.Text = "ex) Camera 촬영 안됨"
            txtWsumm.ForeColor = Color.Gray
        End If

    End Sub

    '# (Wearable) CNS 일 경우 관리자 이름 넣어줌
    Private Sub cbWcompany_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbWcompany.SelectedIndexChanged
        If cbWcompany.Text = "CNS" Then
            txtWadmin.Text = "배재우"
        Else
            txtWadmin.Text = ""
        End If
    End Sub
#End Region

#Region "Copy & Copy All"
    Private Sub btWcopysumm_Click(sender As Object, e As EventArgs) Handles btWcopysumm.Click
        Clipboard.SetText(txtWsumm.Text)           '클립보드에 텍스트 설정 합니다.
        MsgBox("복사 되었습니다",, "lee.sunbae@lgepartner.com")
    End Sub

    Private Sub btWcopyresult_Click(sender As Object, e As EventArgs) Handles btWcopyresult.Click
        Clipboard.SetText(txtWresult.Text)           '클립보드에 텍스트 설정 합니다.
        MsgBox("복사 되었습니다",, "lee.sunbae@lgepartner.com")
    End Sub
#End Region

#Region "기능 요청(Request)"
    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles btWopinion.Click
        Dim Summary_Add As New Summary_Add
        Summary_Add.Show()
    End Sub
#End Region

#Region "폰트 설정"

    Private Sub Button5_Click_1(sender As Object, e As EventArgs) Handles Button5.Click
        ' Set font 
        FontDialog1.ShowColor = True        ' Color 설정할 수 있게

        With FontDialog1
            .Font = trvApp.Font : .Color = trvApp.ForeColor
            .Font = trvAction.Font : .Color = trvAction.ForeColor
            .Font = lstSym.Font : .Color = lstSym.ForeColor
            .Font = lstSym2.Font : .Color = lstSym2.ForeColor
            .Font = lstCa.Font : .Color = lstCa.ForeColor
            .Font = lstPlan.Font : .Color = lstPlan.ForeColor
            .Font = lstFre.Font : .Color = lstFre.ForeColor
            .Font = txtPre.Font : .Color = txtPre.ForeColor
            .Font = txtModel.Font : .Color = txtModel.ForeColor
            .Font = Summ.Font : .Color = Summ.ForeColor
            .Font = txtResult.Font : .Color = txtResult.ForeColor
        End With

        If FontDialog1.ShowDialog = DialogResult.OK Then
            With FontDialog1
                trvApp.Font = .Font : trvApp.ForeColor = .Color
                trvAction.Font = .Font : trvAction.ForeColor = .Color
                lstSym.Font = .Font : lstSym.ForeColor = .Color
                lstSym2.Font = .Font : lstSym2.ForeColor = .Color
                lstCa.Font = .Font : lstCa.ForeColor = .Color
                lstPlan.Font = .Font : lstPlan.ForeColor = .Color
                lstFre.Font = .Font : lstFre.ForeColor = .Color
                txtModel.Font = .Font : txtModel.ForeColor = .Color
                Summ.Font = .Font : Summ.ForeColor = .Color
                txtResult.Font = .Font : txtResult.ForeColor = .Color
            End With
        End If

    End Sub

    Private Sub txtResult_KeyDown(sender As Object, e As KeyEventArgs) Handles txtResult.KeyDown
        If (e.KeyCode And Not Keys.Modifiers) = Keys.B AndAlso e.Modifiers = Keys.Control Then      ' Ctrl + B 했을 때
            Dim currentFont As System.Drawing.Font = txtResult.SelectionFont
            Dim newFontStyle As System.Drawing.FontStyle

            If txtResult.SelectionFont.Bold = True Then
                newFontStyle = FontStyle.Regular
            Else
                newFontStyle = FontStyle.Bold
            End If

            txtResult.SelectionFont = New Font(currentFont.FontFamily, currentFont.Size, newFontStyle)

        End If
    End Sub

    Private Sub Button8_Click_1(sender As Object, e As EventArgs) Handles Button8.Click

        Dim nFrm As New set_Form()
        nFrm.Owner = Me
        nFrm.ShowDialog()

    End Sub

#End Region


End Class




