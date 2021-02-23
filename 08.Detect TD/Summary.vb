Imports System.Data
Imports System.Data.OleDb
Imports System.Drawing
Imports System.IO
Imports System.Windows.Forms
Imports System.Xml

Public Class Summary_test
    Public DS As DataSet = New DataSet
    Public DS_FUT As DataSet = New DataSet
    Public DS_Wear As DataSet = New DataSet

    Public DA As OleDbDataAdapter = New OleDbDataAdapter()
    Public strSQL As String = Nothing
    Public vCon As String = Nothing
    Public vConn As OleDbConnection
    Public Class1 As New Class1
    Public XML As New XML
    Private strFilePath As String = Application.StartupPath

    Dim strwApp As String = "TD_Wearable"
    Dim strApp As String = "TD_AF_Des"                    ' DB 테이블명 지정
    Dim strType As String = "TD_TS_Des"                   ' DB 테이블명 지정
    Dim strDes As String = "TD_Description"
    Dim strCNS As String = "Contacts_C"                         ' 업체 
    Dim strINFINIQ As String = "Contacts_I"
    Dim strMSTech As String = "Contacts_M"
    Dim strFUT As String = "TD_FUT_Data"
    Public strCon As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=\\10.169.88.43\이순배\wear\QPortalDB.accdb;Jet OLEDB:Database Password = lge1234;"

    '★ Form Size가 변할 때 
    Public Sub form_resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        ' TextBox Size를 창 Size에 맞게 
        Dim sizeHeight As Integer = Size.Height ' From의 Size를 Get하여 담음
        txtResult.Location = New Point(9, 387)  ' TextBox의 위치를 좌9, 높이 387
        txtResult.Size = New Point(776, sizeHeight - 387 - 100)
        '   TextBox의 넓이, TextBox의 높이 지정하는데, 마지막라인 = 전체 넓이 - 100

        ' Wearable Tap의 TextBox Size를 창 Size에 맞게 
        Dim sizeHeight_Wearalbe As Integer = Size.Height ' From의 Size를 Get하여 담음
        ResultTxt_t.Location = New Point(9, 387)  ' TextBox의 위치를 좌9, 높이 387
        ResultTxt_t.Size = New Point(776, sizeHeight - 387 - 100)
        '   TextBox의 넓이, TextBox의 높이 지정하는데, 마지막라인 = 전체 넓이 - 100

    End Sub

    Public Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim strFile As String = "TD_SaveData"
        Dim dirA As DirectoryInfo = New DirectoryInfo(strFilePath)    ' 디렉토리 지정
        Dim szTemp As String = Nothing
        Dim szFileName As String = Nothing
        Dim blchk As Boolean = False
        Dim xmlReader As XmlTextReader


        ComboBox1.Items.Add("Default")
        ComboBox1.Items.Add("DDT_Black_Theme")


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
            Loop

            xmlReader.Close() ' XML Reader 닫음

            '★ xml에서 가져온 기존 정보들을 다시 각 각의 위치에 값 넣어줌.
            CompanyCB.Text = strCompany
            txtTester.Text = strTester
            txtML.Text = strML
            txtAdmin.Text = strAdmin
            txtPre.Text = strPre
            txtModel.Text = strModel

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
        toolTip1.InitialDelay = 500
        toolTip1.AutoPopDelay = 1000
        toolTip1.ReshowDelay = 500


        Try
            ' Connecting String xml.vb에서 가져옴.

            XML.vCon_Call(vCon)
            '\\10.169.88.43\이순배
            ' 쿼리문 작성
            Dim szSQL As String = "SELECT * FROM [" + strApp + "] WHERE [App] > '' Order by App,Feature"
            Dim szSQL_Type As String = "SELECT * FROM [" + strType + "] WHERE [Test Type] > '' Order by [Test Type],[Detailed Symptom]"
            Dim szSht_TD As String = "SELECT * FROM [" + strDes + "]"
            Dim szConC As String = "SELECT * FROM [" + strCNS + "]"
            Dim szConI As String = "SELECT * FROM [" + strINFINIQ + "]"
            Dim szConM As String = "SELECT * FROM [" + strMSTech + "]"

            ' String변수에 테이블명과 쿼리문 순차적으로 담음.
            Dim szQuery As String() = New String() {szSQL, szSQL_Type, szSht_TD, szConC, szConI, szConM}
            Dim loopSht As String() = New String() {strApp, strType, strDes, strCNS, strINFINIQ, strMSTech}
            Dim nCnt As Integer = 0

            Try
                vConn = New OleDbConnection(vCon)   ' MainForm의 Connection String으로 DB Connect

                ' Looping 하여 Data Adapter 실행
                For Each a As String In szQuery
                    Dim DA = New OleDbDataAdapter(a, vConn)
                    DA.Fill(DS, loopSht(nCnt))
                    nCnt += 1
                Next

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            'XML = Nothing
            vConn = Nothing

        Catch ex As Exception
            MsgBox(ex.Message)
            Exit Sub
        End Try


        Dim strEP As String = Nothing
        Dim strName As String = Nothing
        Dim nW As Integer = 0
        Dim blcp As Boolean = True

        ' Dim xml As New XML
        XML.GetUserName(strEP, strName) ' xml 에 작성 된 함수를 통해 이름 가져옴.
        XML = Nothing

        '★ 큐포탈 사용자 이름으로 업체명 넣어주기

        txtTester.Text = strName        ' 일단 이름 받아옴
        For nZ As Integer = 3 To 5      ' 3 to 5 하는 이유는 (3)~(5) 까지가 업체테이블임
            For nW = 1 To DS.Tables(nZ).Rows.Count - 1
                If DS.Tables(nZ).Rows(nW)(2).ToString() = strName Then
                    CompanyCB.Text = DS.Tables(nZ).Rows(nW)(4).ToString()
                    ' 회사 콤보박스 값 = 테이블에 (nZ)(4) 위치에 업체명 넣어줌.
                    blcp = False  ' Exit For가 한번만 나가면 또 다른 테이블 검색하기 때문에 Chk Boolean
                    Exit For
                End If
            Next
            If blcp = False Then  ' 이미 회사이름을 찾은 경우라면!
                Exit For
            End If
        Next



        'vConn.Close()
        Dim Table As DataTable = DS.Tables(0)

        'For i As Integer = 0 To Table.Rows.Count - 1
        '    If Not lstApp.Items.Contains(Table.Rows(i)(0).ToString()) Then  ' 중복 없이 Item 추가
        '        lstApp.Items.Add(Table.Rows(i)(0).ToString())
        '    End If
        'Next

        '' [App] ListBox에 값 넣기.
        Table = Table.DefaultView.ToTable(True, "App")  ' (true, <-- 중복제거하는 옵션)
        lstApp.DataSource = Table
        With lstApp
            .DisplayMember = "App"
            .ValueMember = "App"
        End With

        '=[Feature및 다른항목 불러오기]======
        Dim Table_Type As DataTable = DS.Tables(1)
        Table_Type = Table_Type.DefaultView.ToTable(True, "Test Type") ' (true, <-- 중복제거하는 옵션)
        With lstType
            .DataSource = Table_Type
            .DisplayMember = "Test Type"
            .ValueMember = "Test Type"
        End With

        '=[Test Condition 불러오기]
        Dim Table_Condition As DataTable = DS.Tables(2)
        Table_Condition = Table_Condition.DefaultView.ToTable(True, "Test Condition") ' (true, <-- 중복제거하는 옵션)
        With lstCon
            .DataSource = Table_Condition
            .DisplayMember = "Test Condition"
            .ValueMember = "Test Condition"
        End With

        '=[RP RA]
        Dim Table_RP As DataTable = DS.Tables(2)
        Table_RP = Table_RP.DefaultView.ToTable(True, "RP_RA") ' (true, <-- 중복제거하는 옵션)
        With lstRP
            .DataSource = Table_RP
            .DisplayMember = "RP_RA"
            .ValueMember = "RP_RA"
        End With

        '=[Frequency Rate 불러오기]
        Dim Table_FrequencyRate As DataTable = DS.Tables(2)
        Table_FrequencyRate = Table_FrequencyRate.DefaultView.ToTable(True, "Frequency Rate") ' (true, <-- 중복제거하는 옵션)
        With lstFre
            .DataSource = Table_FrequencyRate
            .DisplayMember = "Frequency Rate"
            .ValueMember = "Frequency Rate"
        End With

        ' 업체명 ComboBox 추가 
        With CompanyCB.Items
            .Add("CNS")
            .Add("엠스텍")
            .Add("인피닉")
        End With

        ' Load 시 Summary에 Description
        Summ.Text = "ex) Camera 촬영 안 됨"
        Summ.ForeColor = Color.Gray

        txtRP.Enabled = False
        txtRP.Text = "Number Or AppName"



    End Sub
    '########## Load 버튼 ###############
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click, loadBt_t.Click

        If DirectCast(sender, Control).Name = "loadBt_t" Then
            If InStr(txtFeat_t.Text, "여기에") Then
                MsgBox("앱 이름을 입력하고 재시도 해주세요.") : Exit Sub
            End If
        End If

        If DirectCast(sender, Control).Name = "Button1" Then
            If InStr(txtFea.Text, "여기에") Then
                MsgBox("앱 이름을 입력하고 재시도 해주세요.")
            End If
        End If


        ' === 선택되지 않은 항목이 있을때 메세지 보여줌
        If DirectCast(sender, Control).Name = "Button1" Then
            If lstApp.Text = "" Then MsgBox("App이 선택되지 않았습니다. 선택 후 재시도 해주세요") : Exit Sub
            If lstType.Text = "" Then MsgBox("Test_Type이 선택되지 않았습니다. 선택 후 재시도 해주세요") : Exit Sub
            If lstSym.Text = "" Then MsgBox("Detailed_Symptom이 선택되지 않았습니다. 선택 후 재시도 해주세요") : Exit Sub
            If lstCon.Text = "" Then MsgBox("Test_Condition이 선택되지 않았습니다. 선택 후 재시도 해주세요") : Exit Sub
            If lstRP.Text = "" Then MsgBox("RP or RA가 선택되지 않았습니다. 선택 후 재시도 해주세요.") : Exit Sub
            If lstFre.Text = "" Then MsgBox("Frequency Rate가 선택되지 않았습니다. 선택 후 재시도 해주세요") : Exit Sub
            If lstRP.Text <> "RP_XX" And txtRP.Text = "" Then MsgBox("[RP] or [RA] 의 Number 나 AppName을 작성해 주세요") : Exit Sub
            If CompanyCB.Text = "" Then MsgBox("업체를 선택 후 시도해주세요") : Exit Sub
            If txtAdmin.Text = "" Then MsgBox("관리자 이름이 입력되지 않았습니다.") : Exit Sub
            If txtTester.Text = "" Then MsgBox("검증원 이름이 입력되지 않았습니다.") : Exit Sub
            If txtML.Text = "" Then MsgBox("모델리더 이름이 입력되지 않았습니다.") : Exit Sub
        End If

        If DirectCast(sender, Control).Name = "loadBt_t" Then
            If LstApp_t.Text = "" Then MsgBox("App이 선택되지 않았습니다. 선택 후 재시도 해주세요") : Exit Sub
            If LstType_t.Text = "" Then MsgBox("Test_Type이 선택되지 않았습니다. 선택 후 재시도 해주세요") : Exit Sub
            If LstSym_t.Text = "" Then MsgBox("Detailed_Symptom이 선택되지 않았습니다. 선택 후 재시도 해주세요") : Exit Sub
            If LstCon_t.Text = "" Then MsgBox("Test_Conditi n이 선택되지 않았습니다. 선택 후 재시도 해주세요") : Exit Sub
            If LstRP_t.Text = "" Then MsgBox("RP or RA가 선택되지 않았습니다. 선택 후 재시도 해주세요.") : Exit Sub
            If LstFre_t.Text = "" Then MsgBox("Frequency Rate가 선택되지 않았습니다. 선택 후 재시도 해주세요") : Exit Sub
            If LstRP_t.Text <> "RP_XX" And txtRP_t.Text = "" Then MsgBox("[RP] or [RA] 의 Number 나 AppName을 작성해 주세요") : Exit Sub
            If CompanyCB_t.Text = "" Then MsgBox("업체를 선택 후 시도해주세요") : Exit Sub
            If txtAdmin_t.Text = "" Then MsgBox("관리자 이름이 입력되지 않았습니다.") : Exit Sub
            If txtTester_t.Text = "" Then MsgBox("검증원 이름이 입력되지 않았습니다.") : Exit Sub
            If txtML_t.Text = "" Then MsgBox("모델리더 이름이 입력되지 않았습니다.") : Exit Sub
        End If
        ' ★결함 Summary 내용 입력 했으면
        If DirectCast(sender, Control).Name = "Button1" Then
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

                ' RP 텍스트를 String에 담기
                Dim txtRPText As String = txtRP.Text

                ' rp, ra 가 비활성화 일때
                If txtRP.Enabled = False Then
                    txtRPText = ""
                End If
                Dim DesDT As DataTable = DS.Tables(2)       ' TD Des

                ' ### 3rd Party 앱은 마켓앱 전용 양식으로 불러올 수 있도록 #####
                If lstApp.Text = "3rd Party" Then                               '  ★★  3rd Party 앱을 선택 한 경우 !! ( 3rd Party는 양식이 다름 )
                    For i As Integer = 0 To 29
                        Try
                            strString(i) = DesDT.Rows(i)(6).ToString()
                        Catch ex As Exception
                            MsgBox(ex.Message)
                        End Try
                    Next i

                Else   ' ### 일반적인 경우 ####                                      ★★ 3rd Party제외 일반 앱

                    For i As Integer = 0 To 29
                        Try
                            strString(i) = DesDT.Rows(i)(5).ToString()      ' (9)는 일반 (10)은 Market App
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
                If InStr(Summ.Text, "//") Then
                    ' 서머리 양식 만들기
                    If MsgBox("새로 불러 옵니다. " & "진행 하시겠습니까?", vbQuestion + vbYesNo, "lee.sunbabe@lgepartner.com") = vbNo Then
                        Exit Sub
                    Else
                        Summ.Text = Strings.Left(Summ.Text, InStr(Summ.Text, "//") - 3)
                        If lstFea.Text = "" Then 'Feature가 선택되지 않았을때
                            If txtFea.Text = "" Then
                                strSum = " //" & "[" & lstApp.Text & "]" & "[" & lstType.Text & "]" & "[" & lstSym.Text & "]" & "[" & lstCon.Text & "]" & "[" & lstRP.Text & txtRPText & "]"
                            Else
                                strSum = " //" & "[" & lstApp.Text & "_" & txtFea.Text & "]" & "[" & lstType.Text & "]" & "[" & lstSym.Text & "]" & "[" & lstCon.Text & "]" & "[" & lstRP.Text & txtRPText & "]"
                            End If
                        Else
                            strSum = " //" & "[" & lstApp.Text & "_" & lstFea.Text & "]" & "[" & lstType.Text & "]" & "[" & lstSym.Text & "]" & "[" & lstCon.Text & "]" & "[" & lstRP.Text & txtRPText & "]"
                        End If
                        'Summary title 부분 추가
                        Summ.Text = Summ.Text + " " + strSum
                        ' 서머리 양식 만들기
                        strString(0) = strString(0) + Summ.Text
                        '               1. Title :      + Call 안됨  +  //[Voice Call_OutgoingCall........]
                    End If

                Else

                    If lstFea.Text = "" Then 'Feature가 선택되지 않았을때
                        If txtFea.Text = "" Then
                            strSum = " //" + "[" + lstApp.Text + "]" + "[" + lstType.Text + "]" + "[" + lstSym.Text + "]" + "[" + lstCon.Text + "]" + "[" + lstRP.Text + txtRPText + "]"
                        Else
                            strSum = " //" + "[" + lstApp.Text + "_" + txtFea.Text + "]" + "[" + lstType.Text + "]" + "[" + lstSym.Text + "]" + "[" + lstCon.Text + "]" + "[" + lstRP.Text + txtRPText + "]"
                        End If
                    Else
                        strSum = " //" + "[" + lstApp.Text + "_" + lstFea.Text + "]" + "[" + lstType.Text + "]" + "[" + lstSym.Text + "]" + "[" + lstCon.Text + "]" + "[" + lstRP.Text + txtRPText + "]"
                    End If

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
                    If lstApp.Text = "3rd Party" Then

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


            '[Wearable] Tap에서 load 버튼 클릭할 때
        ElseIf DirectCast(sender, Control).Name = "loadBt_t" Then
            If Summtxt_t.Text <> "" And Strings.Left(Summtxt_t.Text, 3) <> "ex)" Then   ' 서머리 부분에 내용이 있다면 진행

                ' ★결함을 한글로 작성 했는지, 영문으로 작성 했는지 파악
                Dim blHan As Boolean
                For Each ch As Char In Summtxt_t.Text
                    If ch.IsHangul() Then
                        blHan = True
                    Else
                        blHan = False
                    End If
                Next


                ' ★업체에 따라 선택할 수 있도록
                Dim strSht3 As String

                If CompanyCB_t.Text = "CNS" Then
                    strSht3 = "Contacts_C"
                ElseIf CompanyCB_t.Text = "인피닉" Then
                    strSht3 = "Contacts_I"
                ElseIf CompanyCB_t.Text = "엠스텍" Then
                    strSht3 = "Contacts_M"
                End If

                Dim ConTable As DataTable = Nothing

                Dim strRank As String
                Dim strName As String
                Dim strNum As String
                Dim strCom As String

                ' 업체 별 Tel 변경
                Dim intFnd As Integer = 2
                If CompanyCB_t.Text = "CNS" Then
                    strRank = "직급_C"
                    strName = "이름_C"
                    strNum = "휴대폰_C"
                    strCom = "업체_C"
                    'intFnd = 2
                    ConTable = DS_Wear.Tables(3)

                ElseIf CompanyCB_t.Text = "인피닉" Then
                    strRank = "직급_I"
                    strName = "이름_I"
                    strNum = "휴대폰_I"
                    strCom = "업체_I"
                    'intFnd = 6
                    ConTable = DS_Wear.Tables(4)
                ElseIf CompanyCB_t.Text = "엠스텍" Then
                    strRank = "직급_M"
                    strName = "이름_M"
                    strNum = "휴대폰_M"
                    strCom = "업체_M"
                    'intFnd = 10
                    ConTable = DS_Wear.Tables(5)
                End If

                ' Description 담는 배열 
                Dim strString(100)
                Dim chBox(6) As String  ' 첨부 파일 담는 배열

                ' RP 텍스트를 String에 담기
                Dim txtRPText As String = txtRP_t.Text

                ' rp, ra 가 비활성화 일때
                If txtRP_t.Enabled = False Then
                    txtRPText = ""
                End If
                Dim DesDT As DataTable = DS_Wear.Tables(2)       ' TD Des

                ' ### 3rd Party 앱은 마켓앱 전용 양식으로 불러올 수 있도록 #####
                If LstApp_t.Text = "3rd Party" Then                               '  ★★  3rd Party 앱을 선택 한 경우 !! ( 3rd Party는 양식이 다름 )
                    For i As Integer = 0 To 29
                        Try
                            strString(i) = DesDT.Rows(i)(6).ToString()
                        Catch ex As Exception
                            MsgBox(ex.Message)
                        End Try
                    Next i

                Else   ' ### 일반적인 경우 ####                                      ★★ 3rd Party제외 일반 앱

                    For i As Integer = 0 To 29
                        Try
                            strString(i) = DesDT.Rows(i)(5).ToString()      ' (9)는 일반 (10)은 Market App
                        Catch ex As Exception
                            MsgBox(ex.Message)
                        End Try
                    Next i

                    'Frequency rate 입력 및 one-time symptom 입력
                    strString(7) = strString(7) + LstFre_t.Text
                    If LstFre_t.Text = "One-Time" Then
                        strString(8) = strString(8) + "Y"
                        strString(12) = strString(12) + "N"
                    Else
                        strString(8) = strString(8) + "N"
                        strString(12) = strString(12) + "Y"
                    End If
                End If

                ' 첨부파일 Y/N 판별해주는 부분
                If logCk_t.Checked = True Then    ' Log
                    chBox(0) = "Y (문제발생시간:    ,로그추출시간:     )"
                Else
                    chBox(0) = "N"
                End If

                If contentsCk_t.Checked = True Then    ' Test Contents
                    chBox(1) = "Y"
                Else
                    chBox(1) = "N"
                End If

                If videoCk_t.Checked = True Then    ' Video File
                    chBox(2) = "Y"
                Else
                    chBox(2) = "N"
                End If

                If imageCk_t.Checked = True Then    ' Image File
                    chBox(3) = "Y"
                Else
                    chBox(3) = "N"
                End If

                If backupCk_t.Checked = True Then    'LG Backup File
                    chBox(4) = "Y"
                Else
                    chBox(4) = "N"
                End If

                If recordCk_t.Checked = True Then    'Voice Record File
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
                Dim strML As String = txtML_t.Text
                Dim strTester As String = txtTester_t.Text
                Dim strAdmin As String = txtAdmin_t.Text

                Dim ECheck_tester As Boolean = False
                Dim ECheck_ml As Boolean = False
                Dim ECheck_admin As Boolean = False

                For i As Integer = 0 To ConTable.Rows.Count - 1                ' Data table Row 만큼 반복 -1은 마지막행은 Null
                    ' If txtTester.Text = ConTable.Rows(i)(intFnd - 1).ToString() Then     ' 선택 된 App과 Row, 필트(0)은 App, (1) 은 Feature
                    Dim strComName As String = ConTable.Rows(i)(intFnd).ToString()
                    Try
                        ' 모델리더 / 테스터 / 관리자 핸드폰 번호 DB에서 찾아 넣는 구간

                        If strTester = strComName Then
                            strString(23) = strString(23) + strTester + " " + ConTable.Rows(i)(intFnd - 1).ToString() + " " + ConTable.Rows(i)(intFnd + 1).ToString()
                            ECheck_tester = True
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

                        If ECheck_tester = True And ECheck_admin = True And ECheck_ml = True Then
                            Exit For
                        End If

                    Catch ex As Exception
                        MsgBox(ex.Message)
                    End Try

                Next

                ' 이름이 없는 경우 / 맞지 않은 경우
                If ECheck_tester = False Or ECheck_ml = False Or ECheck_admin = False Then
                    MsgBox("업체가 안맞거나, 없는 이름입니다. 관리자에게 문의해주세요", , "lee.sunbae@lgepartner.com")
                    Exit Sub
                End If


                Dim strSum As String
                ' ################################# Summary Text 만들기 ###################################################
                If InStr(Summtxt_t.Text, "//") Then
                    ' 서머리 양식 만들기
                    If MsgBox("새로 불러 옵니다. " & "진행 하시겠습니까?", vbQuestion + vbYesNo, "lee.sunbabe@lgepartner.com") = vbNo Then
                        Exit Sub
                    Else
                        Summtxt_t.Text = Strings.Left(Summtxt_t.Text, InStr(Summtxt_t.Text, "//") - 3)
                        If LstFeat_t.Text = "" Then 'Feature가 선택되지 않았을때
                            If txtFeat_t.Text = "" Then
                                strSum = " //" & "[" & LstApp_t.Text & "]" & "[" & LstType_t.Text & "]" & "[" & LstSym_t.Text & "]" & "[" & LstCon_t.Text & "]" & "[" & LstRP_t.Text & txtRPText & "]"
                            Else
                                strSum = " //" & "[" & lstApp.Text & "_" & txtFea.Text & "]" & "[" & lstType.Text & "]" & "[" & lstSym.Text & "]" & "[" & lstCon.Text & "]" & "[" & lstRP.Text & txtRPText & "]"
                            End If
                        Else
                            strSum = " //" & "[" & lstApp.Text & "_" & lstFea.Text & "]" & "[" & lstType.Text & "]" & "[" & lstSym.Text & "]" & "[" & lstCon.Text & "]" & "[" & lstRP.Text & txtRPText & "]"
                        End If
                        'Summary title 부분 추가
                        Summtxt_t.Text = Summtxt_t.Text + " " + strSum
                        ' 서머리 양식 만들기
                        strString(0) = strString(0) + Summtxt_t.Text
                        '               1. Title :      + Call 안됨  +  //[Voice Call_OutgoingCall........]
                    End If

                Else

                    If LstFeat_t.Text = "" Then 'Feature가 선택되지 않았을때
                        If txtFeat_t.Text = "" Then
                            strSum = " //" + "[" + LstApp_t.Text + "]" + "[" + LstType_t.Text + "]" + "[" + LstSym_t.Text + "]" + "[" + LstCon_t.Text + "]" + "[" + LstRP_t.Text + txtRPText + "]"
                        Else
                            strSum = " //" + "[" + LstApp_t.Text + "_" + txtFeat_t.Text + "]" + "[" + LstType_t.Text + "]" + "[" + LstSym_t.Text + "]" + "[" + LstCon_t.Text + "]" + "[" + LstRP_t.Text + txtRPText + "]"
                        End If
                    Else
                        strSum = " //" + "[" + LstApp_t.Text + "_" + LstFeat_t.Text + "]" + "[" + LstType_t.Text + "]" + "[" + LstSym_t.Text + "]" + "[" + LstCon_t.Text + "]" + "[" + LstRP_t.Text + txtRPText + "]"
                    End If

                    'Summary title 부분 추가
                    Summtxt_t.Text = Summtxt_t.Text + " " + strSum
                    ' 서머리 양식 만들기
                    strString(0) = strString(0) + Summtxt_t.Text
                    '1. Title :      + Call 안됨  +  //[Voice Call_OutgoingCall........]

                End If


                Dim strCompareTemp As String = ResultTxt_t.Text

                ResultTxt_t.Text = ""

                For i = 0 To 29

                    ' 3rd Party 인경우만 !!!!!
                    If LstApp_t.Text = "3rd Party" Then

                        If i = 5 Then ' 프리컨디션 추가 부분
                            ResultTxt_t.Text = ResultTxt_t.Text & strString(i) & vbCrLf & "  " & txtPre_t.Text & vbCrLf
                            i = i + 1
                        End If

                        ResultTxt_t.Text = ResultTxt_t.Text & strString(i) & vbCrLf


                    Else   ' 일반적인 Summary Description 작성 부분


                        If i = 1 Then ' 프리컨디션 추가부분
                            ResultTxt_t.Text = ResultTxt_t.Text & strString(i) & vbCrLf & "  " & txtPre_t.Text & vbCrLf
                            i = i + 1
                        End If

                        If blHan = False Then ' 영어면 
                            If i = 3 Then ' 디테일심텀 추가부분   17.04.21 이순배 [영어]
                                ResultTxt_t.Text = ResultTxt_t.Text & strString(i) & vbCrLf & "  " & Strings.Left(Summtxt_t.Text, InStr(Summtxt_t.Text, "//") - 1) & vbCrLf
                                i = i + 1
                            End If
                        ElseIf blHan = True Then
                            If i = 4 Then ' 디테일심텀 추가부분   17.04.21 이순배 [한글]
                                ResultTxt_t.Text = ResultTxt_t.Text & strString(i) & vbCrLf & "  " & Strings.Left(Summtxt_t.Text, InStr(Summtxt_t.Text, "//") - 1) & vbCrLf
                                i = i + 1
                            End If

                        End If


                        If i = 10 Then ' 비교시료 추가부분
                            If Strings.Left(txtModel_t.Text, 3) = "ex)" Then
                                ResultTxt_t.Text = ResultTxt_t.Text & strString(i) & vbCrLf
                            Else
                                'Enter(Chr(10)) 키 입력시 Split하여 앞에 공간 추가 하여 결과 보여줌

                                Dim arrVal = Split(txtModel_t.Text, Chr(10))
                                ResultTxt_t.Text = ResultTxt_t.Text & strString(i) & vbCrLf
                                'txtResult.Text = txtResult.Text & strString(i) & vbCrLf & "  " & txtModel.Text & vbCrLf
                                For z = 0 To UBound(arrVal)
                                    If z = UBound(arrVal) Then
                                        ResultTxt_t.Text = ResultTxt_t.Text & "    " & arrVal(z) '& Chr(10)
                                    Else
                                        ResultTxt_t.Text = ResultTxt_t.Text & "    " & arrVal(z) & Chr(10)
                                    End If
                                Next z
                                ResultTxt_t.Text = ResultTxt_t.Text & vbCrLf
                            End If

                            i = i + 1
                        End If

                        '최종
                        ResultTxt_t.Text = ResultTxt_t.Text & strString(i) & vbCrLf

                    End If
                Next i

            ElseIf Summtxt_t.Text = "" Or Strings.Left(Summtxt_t.Text, 3) = "ex)" Then
                MsgBox("Summary Title 을 입력한 후 Load를 다시 해주세요",, "lee.sunbae@lgepartner.com")
                Exit Sub
            End If
        End If


        Dim strGeneral As String = "GENERAL Defect Description"
        If desoptionCk_t.Checked = True Then
            ResultTxt_t.Text = strGeneral & vbCrLf & ResultTxt_t.Text
        Else

        End If


        'txtResult.SelectedText = "GENERAL Defect Description"
        'txtResult.SelectionFont = New Font("맑은 고딕", 10, FontStyle.Bold)

    End Sub
    Private Sub lstRP_MouseDown(sender As Object, e As MouseEventArgs) Handles lstRP.MouseDown, LstRP_t.MouseDown

        If DirectCast(sender, Control).Name = "lstRP" Then
            txtRP.Text = ""
        End If

        If DirectCast(sender, Control).Name = "LstRP_t" Then
            txtRP_t.Text = ""
        End If

    End Sub
    Private Sub Summ_MouseClick(sender As Object, e As MouseEventArgs) Handles Summ.MouseClick, Summ_FUT.MouseClick, Summtxt_t.MouseClick
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

        If Strings.Left(Summtxt_t.Text, 3) = "ex)" Then
            Summtxt_t.Text = ""
            Summtxt_t.Font = New Font("맑은 고딕", 9)
            Summtxt_t.ForeColor = Color.Black
        End If


    End Sub
    '### RP Or RA 를 선택 시 RP_XX 선택 하면 App 이름을 쓸 필요가 없기 때문에 Disable ############################
    Private Sub lstRP_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstRP.SelectedIndexChanged, LstRP_t.SelectedIndexChanged
        Dim Table_Type As DataTable = DS.Tables(2)

        DesTxt.Text = ""

        For i As Integer = 0 To Table_Type.Rows.Count - 1                ' Data table Row 만큼 반복 -1은 마지막행은 Null
            If lstRP.Text = Table_Type.Rows(i)(2).ToString() Then     ' 선택 된 App과 Row, 필트(0)은 App, (1) 은 Feature
                Try
                    DesTxt.Text = Table_Type.Rows(i)(3).ToString()
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try

            End If
        Next

        'labDes.Caption = "Description"
        If DirectCast(sender, Control).Name = "lstRP" Then

            If lstRP.Text = "RP_" Or lstRP.Text = "RA_" Then
                txtRP.Enabled = True
            Else
                txtRP.Enabled = False
                txtRP.Text = "Number Or AppName"
            End If
        End If

        If DirectCast(sender, Control).Name = "LstRP_t" Then
            If LstRP_t.Text = "RP_" Or LstRP_t.Text = "RA_" Then
                txtRP_t.Enabled = True
            Else
                txtRP_t.Enabled = False
                txtRP_t.Text = "Number Or AppName"
            End If
        End If



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
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click, Button12.Click, sumcopyBt_t.click
        Try

            If DirectCast(sender, Control).Name = "Button12" Then
                Clipboard.SetText(Summ_FUT.Text)           '클립보드에 텍스트 설정 합니다.
                MsgBox("복사 되었습니다",, "lee.sunbae@lgepartner.com")
            ElseIf DirectCast(sender, Control).Name = "sumcopyBt_t" Then
                Clipboard.SetText(Summtxt_t.Text)           '클립보드에 텍스트 설정 합니다.
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
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click, bodyCpy_FUT.Click, bodycopyBt_t.Click
        Try

            If DirectCast(sender, Control).Name = "bodyCpy_FUT" Then
                Clipboard.SetText(txtResult_FUT.Text)       '클립보드에 텍스트 설정 합니다.
                MsgBox("복사 되었습니다",, "lee.sunbae@lgepartner.com")
            ElseIf DirectCast(sender, Control).Name = "bodycopyBt_t" Then
                Clipboard.SetText(ResultTxt_t.Text)       '클립보드에 텍스트 설정 합니다.
                MsgBox("복사 되었습니다",, "lee.sunbae@lgepartner.com")
            Else
                Clipboard.SetText(txtResult.Text)           '클립보드에 텍스트 설정 합니다.
                MsgBox("복사 되었습니다",, "lee.sunbae@lgepartner.com")
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub lstApp_KeyDown(sender As Object, e As KeyEventArgs) Handles lstApp.KeyDown
        If e.KeyCode = Keys.Escape Then
            Close()
        End If
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click, Del_FUT.Click, Button11.Click
        Summ.Text = ""
        Summ.Font = New Font("맑은 고딕", 9)
        Summ.ForeColor = Color.Black

        Summ_FUT.Text = ""
        Summ_FUT.Font = New Font("맑은 고딕", 9)
        Summ_FUT.ForeColor = Color.Black

        Summtxt_t.Text = ""
        Summtxt_t.Font = New Font("맑은 고딕", 9)
        Summtxt_t.ForeColor = Color.Black

    End Sub

    Private Sub CompanyCB_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CompanyCB.SelectedIndexChanged, CompanyCB_FUT.SelectedIndexChanged, CompanyCB_t.SelectedIndexChanged

        If CompanyCB.Text = "CNS" Then
            txtAdmin.Text = "배재우"
        Else
            txtAdmin.Text = ""
        End If

        If CompanyCB_t.Text = "CNS" Then
            txtAdmin_t.Text = "배재우"
        Else
            txtAdmin_t.Text = ""
        End If

        If CompanyCB_FUT.Text = "CNS" Then
            txtAdmin_FUT.Text = "배재우"
        Else
            txtAdmin_FUT.Text = ""
        End If

    End Sub

    Private Sub lstApp_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstApp.SelectedIndexChanged
        ' App Click 시 Feature에 맞도록
        Dim Table As DataTable = DS.Tables(0)


        Table.DefaultView.Sort = "Feature ASC"
        lstFea.Items.Clear()      ' Data Clear 
        DesTxt.Text = ""            ' 설명 초기화 

        For i As Integer = 0 To Table.Rows.Count - 1    ' Data table Row 만큼 반복 -1은 마지막행은 Null
            If lstApp.Text = Table.Rows(i)(0).ToString() Then ' 선택 된 App과 Row, 필트(0)은 App, (1) 은 Feature
                Try
                    If Not lstFea.Items.Contains(Table.Rows(i)(1).ToString()) Then  ' 중복 없이 Item 추가
                        lstFea.Items.Add(Table.Rows(i)(1).ToString())
                    End If
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            End If
        Next

        If lstApp.Text = "3rd Party" Then
            With txtFea
                .Text = "여기에 앱이름 작성"
                .Multiline = False
                .ForeColor = Color.Gray
            End With
        ElseIf lstApp.Text = "Buyer App" Then
            With txtFea
                .Text = "여기에 앱이름 작성"
                .Multiline = False
                .ForeColor = Color.Gray
            End With
        Else
            If InStr(Summ.Text, "ex)") Then
            Else
                'Summ.Text = ""
                With txtFea
                    .Text = ""
                    .Font = New Font("맑은 고딕", 9)
                    .ForeColor = Color.Black
                End With
            End If

            txtFea.Text = ""
            txtFea.ForeColor = Color.Black

        End If

    End Sub

    Private Sub txtFea_Click(sender As Object, e As EventArgs) Handles txtFea.Click, txtFea_FUT.Click
        If Strings.Left(txtFea.Text, 3) = "여기에" Then
            txtFea.Text = ""
            txtFea.Font = New Font("맑은 고딕", 9)
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
    ' #### [ Feature 선택 시 ] #####
    Private Sub lstType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstType.SelectedIndexChanged
        ' App Click 시 Feature에 맞도록
        Dim Table_Type As DataTable = DS.Tables(1)

        lstSym.Items.Clear()      ' Data Clear 
        DesTxt.Text = ""

        For i As Integer = 0 To Table_Type.Rows.Count - 1    ' Data table Row 만큼 반복 -1은 마지막행은 Null
            If lstType.Text = Table_Type.Rows(i)(0).ToString() Then ' 선택 된 App과 Row, 필트(0)은 App, (1) 은 Feature
                Try
                    lstSym.Items.Add(Table_Type.Rows(i)(2).ToString())
                    DesTxt.Text = Table_Type.Rows(i)(1).ToString()
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try

            End If
        Next
    End Sub
    ' #### Detailed SYmptom 선택 시 ######
    Private Sub lstSym_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstSym.SelectedIndexChanged
        ' App Click 시 Feature에 맞도록
        Dim Table_Type As DataTable = DS.Tables(1)

        'ListBox4.Items.Clear()      ' Data Clear 
        DesTxt.Text = ""

        For i As Integer = 0 To Table_Type.Rows.Count - 1    ' Data table Row 만큼 반복 -1은 마지막행은 Null
            If lstType.Text = Table_Type.Rows(i)(0).ToString() And lstSym.Text = Table_Type.Rows(i)(2).ToString() Then ' 선택 된 App과 Row, 필트(0)은 App, (1) 은 Feature
                Try
                    'ListBox4.Items.Add(Table_Type.Rows(i)(2).ToString())
                    DesTxt.Text = Table_Type.Rows(i)(3).ToString()
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try

            End If
        Next
    End Sub
    ' ##### Feature선택 시 설명 설명 #######
    Private Sub lstFea_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstFea.SelectedIndexChanged

        Dim Table As DataTable = DS.Tables(0)

        'ListBox4.Items.Clear()      ' Data Clear 
        DesTxt.Text = ""

        For i As Integer = 0 To Table.Rows.Count - 1    ' Data table Row 만큼 반복 -1은 마지막행은 Null
            If lstApp.Text = Table.Rows(i)(0).ToString() And lstFea.Text = Table.Rows(i)(1).ToString() Then ' 선택 된 App과 Row, 필트(0)은 App, (1) 은 Feature
                Try
                    'ListBox4.Items.Add(Table_Type.Rows(i)(2).ToString())
                    DesTxt.Text = Table.Rows(i)(2).ToString()
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try

            End If
        Next
    End Sub
    ' ########### Test Condition 선택 시 설명 나오게 하는 부분 ##############
    Private Sub lstCon_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstCon.SelectedIndexChanged
        Dim Table_Type As DataTable = DS.Tables(2)

        DesTxt.Text = ""

        For i As Integer = 0 To Table_Type.Rows.Count - 1    ' Data table Row 만큼 반복 -1은 마지막행은 Null
            If lstCon.Text = Table_Type.Rows(i)(0).ToString() Then ' 선택 된 App과 Row, 필트(0)은 App, (1) 은 Feature
                Try
                    DesTxt.Text = Table_Type.Rows(i)(1).ToString()
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try

            End If
        Next
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles requestBtn.Click, requestBt_t.Click
        Dim Summary_Add As New Summary_Add
        Summary_Add.Show()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click, Button10.Click, resetBt_t.Click   ' 리셋 버튼

        If MsgBox("내용이 모두 사라집니다." & "정말 진행 하시겠습니까?" & vbCrLf & "지우지 않고, 원하는 항목 선택 후 재 Load 하셔도 됩니다.", vbQuestion + vbYesNo, "lee.sunbabe@lgepartner.com") = vbNo Then
            Exit Sub
        Else
            If DirectCast(sender, Control).Name = "Button10" Then
                txtResult_FUT.Text = ""
                Summ.Text = ""
            ElseIf DirectCast(sender, Control).Name = "Button3" Then
                txtResult.Text = ""
                Summ_FUT.Text = ""
            ElseIf DirectCast(sender, Control).Name = "resetBt_t" Then
                ResultTxt_t.Text = ""
                Summtxt_t.Text = ""
            End If

        End If
    End Sub
    '#### FUT Summary Tool #####
    Private Sub TabPage2_Enter(sender As Object, e As EventArgs) Handles TabPage2.Enter

        'txtAdmin_FUT.Text = My.Settings.strAdmin
        'txtTester_FUT.Text = My.Settings.strTester
        'txtML_FUT.Text = My.Settings.strModelLeader
        'CompanyCB_FUT.Text = My.Settings.strCompanys


        Dim toolTip1 As New ToolTip()
        toolTip1.SetToolTip(requestBtn, "Q-Portal에 없는 앱이나 기능을 추가할 수 있습니다 ")
        toolTip1.InitialDelay = 500
        toolTip1.AutoPopDelay = 1000
        toolTip1.ReshowDelay = 500

        'Dim strSht As String = "App_Feature_Des"  ' DB 시트 이름 지정
        'Dim strSht2 As String = "TestType_Detailed Symptom_Des"

        'Dim strCNS As String = "Contacts_C"
        'Dim strMSTech As String = "Contacts_M"
        'Dim strINFINIQ As String = "Contacts_I"

        'Dim strSht4 As String = "TD_Des"


        Try
            Dim XML As New XML
            XML.vCon_Call(vCon)
            vConn = New OleDbConnection(vCon)

            ' 쿼리문 작성
            Dim szSQL As String = "Select * FROM [" + strApp + "] Where [App] > '' Order by App,Feature"
            Dim szSQL_Type As String = "Select * FROM [" + strType + "] Where [Test Type] > '' Order by [Test Type],[Detailed Symptom]"
            Dim szSht_TD As String = "Select * FROM [" + strDes + "]"
            Dim szConC As String = "Select * FROM [" + strCNS + "]"
            Dim szConI As String = "Select * FROM [" + strINFINIQ + "]"
            Dim szConM As String = "Select * FROM [" + strMSTech + "]"
            Dim szFUT As String = "Select * FROM [" & strFUT & "]"


            Dim szQuery As String() = New String() {szSQL, szSQL_Type, szSht_TD, szConC, szConI, szConM, szFUT}
            Dim loopSht As String() = New String() {strApp, strType, strDes, strCNS, strINFINIQ, strMSTech, strFUT}
            Dim nCnt As Integer = 0

            Try
                vConn = New OleDbConnection(vCon)   ' MainForm의 Connection String으로 DB Connect
                ' Looping 하여 Data Adapter 실행
                For Each a As String In szQuery
                    Dim DA = New OleDbDataAdapter(a, vConn)
                    DA.Fill(DS_FUT, loopSht(nCnt))
                    nCnt += 1
                Next
                'DS.WriteXml(Application.StartupPath & "\Sunbae.XML")

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try


            XML = Nothing
            vConn = Nothing
        Catch ex As Exception
            MsgBox(ex.Message)
            Exit Sub
        End Try

        'vConn.Close()
        Dim Table As DataTable = DS_FUT.Tables(0)

        Table = Table.DefaultView.ToTable(True, "App")
        lstApp_FUT.DataSource = Table
        With lstApp_FUT
            .DisplayMember = "App"
            .ValueMember = "App"
        End With

        '=[Feature및 다른항목 불러오기]======
        Dim Table_Type As DataTable = DS_FUT.Tables(1)
        Table_Type = Table_Type.DefaultView.ToTable(True, "Test Type")
        With lstType_FUT
            .DataSource = Table_Type
            .DisplayMember = "Test Type"
            .ValueMember = "Test Type"
        End With

        '=[Test Condition 불러오기]
        Dim Table_Condition As DataTable = DS_FUT.Tables(6)
        Table_Condition = Table_Condition.DefaultView.ToTable(True, "대분류")
        With lstDae_FUT
            .DataSource = Table_Condition
            .DisplayMember = "대분류"
            .ValueMember = "대분류"
        End With

        '=[Test Condition 불러오기]
        Dim Table_Rate As DataTable = DS_FUT.Tables(2)
        Table_Rate = Table_Rate.DefaultView.ToTable(True, "Frequency Rate")
        With lstFre_FUT
            .DataSource = Table_Rate
            .DisplayMember = "Frequency Rate"
            .ValueMember = "Frequency Rate"
        End With

        ' Pre-Condition 넣어 주기 
        With txtPre_FUT
            .Text = "1) Board D/L ()"
            .Multiline = True
        End With

        ' 비교모델 관련
        With txtModel_FUT
            .Text = "ex) H960TR : 재현 안됨 "
            .Multiline = True
            .ForeColor = Color.Gray
        End With

        ' 업체명 ComboBox 추가 
        If CompanyCB_FUT.Items.Count = 0 Then

            With CompanyCB_FUT.Items
                .Add("CNS")
                .Add("엠스텍")
                .Add("인피닉")
            End With

        End If

        ' Load 시 Summary에 Description
        Summ_FUT.Text = "ex) Camera 촬영 안 됨"
        Summ_FUT.ForeColor = Color.Gray

    End Sub




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
    ' #### FUT Type 선택 시 ####
    Private Sub lstType_FUT_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstType_FUT.SelectedIndexChanged
        Dim intTable As Integer = 1
        Dim strSht As String = "TestType_Detailed Symptom_Des"
        'TwoLST(lstApp_FUT, lstType_FUT, lstSym_FUT, strSht, intTable, DS_FUT, intColOne:=0, intColTwo:=1, intColThree:=2)
        OneLST(lstType_FUT, lstSym_FUT, strSht, intTable, DS_FUT, intColOne:=0, intColTwo:=2)

        ' 설명 보여주는 부분 
        Dim Table As DataTable = DS_FUT.Tables(1)

        DesTxt_FUT.Text = ""

        For i As Integer = 0 To Table.Rows.Count - 1                ' Data table Row 만큼 반복 -1은 마지막행은 Null
            If lstType_FUT.Text = Table.Rows(i)(0).ToString() Then     ' 선택 된 App과 Row, 필트(0)은 App, (1) 은 Feature
                Try
                    DesTxt_FUT.Text = Table.Rows(i)(1).ToString()
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
        If lstType_FUT.Text = "" Then MsgBox("Test_Type이 선택되지 않았습니다. 선택 후 재시도 해주세요") : Exit Sub
        If lstSym_FUT.Text = "" Then MsgBox("Detailed_Symptom이 선택되지 않았습니다. 선택 후 재시도 해주세요") : Exit Sub
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

            Dim DesDT As DataTable = DS_FUT.Tables(2)       ' TD Des

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
                            strSum = " //" & "[" & lstApp_FUT.Text & "]" & "[" & lstApp_FUT.Text & "]" & "[" & lstSym_FUT.Text & "]" & "[" & lstDae_FUT.Text & "_" & lstJoong_FUT.Text & "]" & "[" & lstSo_FUT.Text & "]"
                        Else
                            strSum = " //" & "[" & lstApp_FUT.Text & "_" & txtFea_FUT.Text & "]" & "[" & lstType_FUT.Text & "]" & "[" & lstSym_FUT.Text & "]" & "[" & lstDae_FUT.Text & "_" & lstJoong_FUT.Text & "]" & "[" & lstSo_FUT.Text & "]"
                        End If
                    Else
                        strSum = " //" & "[" & lstApp_FUT.Text & "_" & lstFea_FUT.Text & "]" & "[" & lstType_FUT.Text & "]" & "[" & lstSym_FUT.Text & "]" & "[" & lstDae_FUT.Text & "_" & lstJoong_FUT.Text & "]" & "[" & lstSo_FUT.Text & "]"
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
                        strSum = " //" & "[" & lstApp_FUT.Text & "]" & "[" & lstApp_FUT.Text & "]" & "[" & lstSym_FUT.Text & "]" & "[" & lstDae_FUT.Text & "_" & lstJoong_FUT.Text & "]" & "[" & lstSo_FUT.Text & "]"
                    Else
                        strSum = " //" & "[" & lstApp_FUT.Text & "_" & txtFea_FUT.Text & "]" & "[" & lstType_FUT.Text & "]" & "[" & lstSym_FUT.Text & "]" & "[" & lstDae_FUT.Text & "_" & lstJoong_FUT.Text & "]" & "[" & lstSo_FUT.Text & "]"
                    End If
                Else
                    strSum = " //" & "[" & lstApp_FUT.Text & "_" & lstFea_FUT.Text & "]" & "[" & lstType_FUT.Text & "]" & "[" & lstSym_FUT.Text & "]" & "[" & lstDae_FUT.Text & "_" & lstJoong_FUT.Text & "]" & "[" & lstSo_FUT.Text & "]"
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

    Private Sub lstSym_FUT_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstSym_FUT.SelectedIndexChanged

        ' 설명 보여주는 부분 
        Dim Table As DataTable = DS_FUT.Tables(1)

        DesTxt_FUT.Text = ""

        For i As Integer = 0 To Table.Rows.Count - 1                ' Data table Row 만큼 반복 -1은 마지막행은 Null
            If lstType_FUT.Text = Table.Rows(i)(0).ToString() And lstSym_FUT.Text = Table.Rows(i)(2).ToString() Then     ' 선택 된 App과 Row, 필트(0)은 App, (1) 은 Feature
                Try
                    DesTxt_FUT.Text = Table.Rows(i)(3).ToString()
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

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Dim ctrl As Control






        If ComboBox1.Text = "DDT_Black_Theme" Then

            ' UserName(EP) 설정해줌
            Dim strEP As String = Nothing
            Dim strName As String = Nothing
            Dim xml As New XML

            xml.GetUserName(strEP, strName)
            xml = Nothing

            ' strUserName = strName + "(" + strEP + ")"

            '  If Not strName = "김병준" Or Not strName = "이순배" Then
            '   MsgBox("기능 구현중 입니다.")
            '  Exit Sub
            'End If


            TabPage1.BackColor = Color.FromArgb(50, 50, 50)
            BackColor = Color.FromArgb(50, 50, 50)
            ' Opacity = 90%
            lstApp.BackColor = Color.FromArgb(50, 50, 50)
            lstApp.ForeColor = Color.White



            For Each ctrl In TabControl1.SelectedTab.Controls
                ' List Box 형식으로 된 애들 하얀색 처리
                If (ctrl.GetType() Is GetType(ListBox)) Then
                    ctrl.BackColor = Color.FromArgb(50, 50, 50)
                    ctrl.ForeColor = Color.White
                End If
                ' Text Box로 된 애들 하얀색 처리
                If (ctrl.GetType() Is GetType(TextBox)) Then
                    ctrl.BackColor = Color.FromArgb(50, 50, 50)
                    ctrl.ForeColor = Color.White
                End If
                ' 서머리 밑에 텍스트 하얀색 처리
                If (ctrl.GetType() Is GetType(RichTextBox)) Then
                    ctrl.BackColor = Color.FromArgb(50, 50, 50)
                    ctrl.ForeColor = Color.White
                End If

                If (ctrl.GetType() Is GetType(Label)) Then
                    ' ctrl.BackColor = Color.FromArgb(50, 50, 50)
                    ctrl.ForeColor = Color.White
                End If

                If (ctrl.GetType() Is GetType(GroupBox)) Then
                    ctrl.ForeColor = Color.White
                    For Each ct As Control In GroupBox1.Controls
                        ct.ForeColor = Color.White
                    Next
                End If

            Next


        Else
            TabPage1.BackColor = Color.FromArgb(255, 255, 255)
            BackColor = Color.FromArgb(255, 255, 255)
            Opacity = 90%
            lstApp.BackColor = Color.FromArgb(255, 255, 255)
            lstApp.ForeColor = Color.Black

            For Each ctrl In TabControl1.SelectedTab.Controls
                If (ctrl.GetType() Is GetType(ListBox)) Then
                    ctrl.BackColor = Color.FromArgb(255, 255, 255)
                    ctrl.ForeColor = Color.Black
                End If

                If (ctrl.GetType() Is GetType(TextBox)) Then
                    ctrl.BackColor = Color.FromArgb(255, 255, 255)
                    ctrl.ForeColor = Color.Black
                End If
                If (ctrl.GetType() Is GetType(RichTextBox)) Then
                    ctrl.BackColor = Color.FromArgb(255, 255, 255)
                    ctrl.ForeColor = Color.Black
                End If

                If (ctrl.GetType() Is GetType(Label)) Then
                    ' ctrl.BackColor = Color.FromArgb(50, 50, 50)
                    ctrl.ForeColor = Color.Black
                End If

                If (ctrl.GetType() Is GetType(GroupBox)) Then
                    ctrl.ForeColor = Color.Black
                    For Each ct As Control In GroupBox1.Controls
                        ct.ForeColor = Color.Black
                    Next
                End If

            Next

        End If

    End Sub


    '### Wearable Tap ###
    Private Sub TabPage3_Enter(sender As Object, e As EventArgs) Handles TabPage3.Enter

        'txtAdmin_FUT.Text = My.Settings.strAdmin
        'txtTester_FUT.Text = My.Settings.strTester
        'txtML_FUT.Text = My.Settings.strModelLeader
        'CompanyCB_FUT.Text = My.Settings.strCompanys


        Dim toolTip1 As New ToolTip()
        toolTip1.SetToolTip(requestBtn, "Q-Portal에 없는 앱이나 기능을 추가할 수 있습니다 ")
        toolTip1.InitialDelay = 500
        toolTip1.AutoPopDelay = 1000
        toolTip1.ReshowDelay = 500

        'Dim strSht As String = "App_Feature_Des"  ' DB 시트 이름 지정
        'Dim strSht2 As String = "TestType_Detailed Symptom_Des"

        'Dim strCNS As String = "Contacts_C"
        'Dim strMSTech As String = "Contacts_M"
        'Dim strINFINIQ As String = "Contacts_I"

        'Dim strSht4 As String = "TD_Des"


        Try
            'Dim XML As New XML
            'xml.vCon_Call(vCon)
            'vConn = New OleDbConnection(vCon)

            ' 쿼리문 작성
            'lstApp.Items.Clear()

            Dim szSQL As String = "SELECT * FROM [" + strApp + "] WHERE [App] > '' Order by App, Feature"
            Dim szSQL_Type As String = "SELECT * FROM [" + strType + "] WHERE [Test Type] > '' Order by [Test Type],[Detailed Symptom]"
            Dim szSht_TD As String = "SELECT * FROM [" + strDes + "]"
            Dim szConC As String = "SELECT * FROM [" + strCNS + "]"
            Dim szConI As String = "SELECT * FROM [" + strINFINIQ + "]"
            Dim szConM As String = "SELECT * FROM [" + strMSTech + "]"
            Dim szWear As String = "Select * FROM [" & strwApp & "]"


            ' String변수에 테이블명과 쿼리문 순차적으로 담음.
            Dim szQuery As String() = New String() {szSQL, szSQL_Type, szSht_TD, szConC, szConI, szConM, szWear}
            Dim loopSht As String() = New String() {strApp, strType, strDes, strCNS, strINFINIQ, strMSTech, strwApp}
            Dim nCnt As Integer = 0


            Try
                vConn = New OleDbConnection(vCon)   ' MainForm의 Connection String으로 DB Connect

                ' Looping 하여 Data Adapter 실행
                For Each a As String In szQuery
                    Dim DA = New OleDbDataAdapter(a, vConn)
                    DA.Fill(DS_Wear, loopSht(nCnt))
                    nCnt += 1
                Next

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            'XML = Nothing
            vConn = Nothing

        Catch ex As Exception
            MsgBox(ex.Message)
            Exit Sub
        End Try

        '사용자 이름 불러오기
        Dim strName As String = Nothing
        Dim strEP As String = Nothing
        Dim xml As New XML

        xml.GetUserName(strEP, strName)
        XML = Nothing

        txtTester_t.Text = strName
        ' Result TextBox 값 저장하고 초기화

        ' [App] ListBox에 값 넣기
        Dim Table As DataTable = DS_Wear.Tables(6)

        For i As Integer = 0 To Table.Rows.Count - 1
            If Not LstApp_t.Items.Contains(Table.Rows(i)(1).ToString()) Then  ' 중복 없이 Item 추가
                LstApp_t.Items.Add(Table.Rows(i)(1).ToString())
            End If
        Next

        ' [Test Type] ListBox에 값 넣기
        Dim Table_Type As DataTable = DS_Wear.Tables(1)

        For i As Integer = 0 To Table_Type.Rows.Count - 1
            If Not LstType_t.Items.Contains(Table_Type.Rows(i)(0).ToString()) Then
                LstType_t.Items.Add(Table_Type.Rows(i)(0).ToString())
            End If
        Next

        '[Test Condition] ListBox에 값 넣기
        Dim Table_Condition As DataTable = DS_Wear.Tables(2)

        For i As Integer = 0 To Table_Condition.Rows.Count - 1
            If Not LstCon_t.Items.Contains(Table_Condition.Rows(i)(0).ToString()) Then
                LstCon_t.Items.Add(Table_Condition.Rows(i)(0).ToString())
            End If

        Next

        '[RP or RA] ListBox에 값 넣기
        Dim Table_RP As DataTable = DS_Wear.Tables(2)

        For i As Integer = 0 To Table_RP.Rows.Count - 1
            If Not LstRP_t.Items.Contains(Table_RP.Rows(i)(2).ToString()) Then
                LstRP_t.Items.Add(Table_RP.Rows(i)(2).ToString())
            End If
        Next

        '[Frequency Rate] ListBox에 값 넣기
        Dim Table_Frequency As DataTable = DS_Wear.Tables(2)

        For i As Integer = 0 To Table_Frequency.Rows.Count - 1
            If Not LstFre_t.Items.Contains(Table_Frequency.Rows(i)(4).ToString()) Then
                LstFre_t.Items.Add(Table_Frequency.Rows(i)(4).ToString())
            End If
        Next

        '[업체명] ComboBox에 값 넣기
        If CompanyCB_t.Items.Count = 0 Then
            With CompanyCB_t.Items
                .Add("CNS")
                .Add("엠스텍")
                .Add("인피닉")
            End With
        End If


        Summtxt_t.Text = "ex) Camera 촬영 안 됨"
        Summtxt_t.ForeColor = Color.Gray

        txtRP_t.Enabled = False
        txtRP_t.Text = "Number Or AppName"

        'Table = Table.DefaultView.ToTable(True, "App")  ' (true, <-- 중복제거하는 옵션)
        'LstApp_t.DataSource = Table
        'With LstApp_t
        '    .DisplayMember = "App"
        '    .ValueMember = "App"
        'End With


    End Sub

    Private Sub LstApp_t_SelectedIndexChanged(sender As Object, e As EventArgs) Handles LstApp_t.SelectedIndexChanged
        ' App Click 시 Feature에 맞도록
        Dim Table As DataTable = DS_Wear.Tables(6)


        Table.DefaultView.Sort = "Feature ASC"
        LstFeat_t.Items.Clear()      ' Data Clear 
        DesTxt.Text = ""            ' 설명 초기화 

        For i As Integer = 0 To Table.Rows.Count - 1    ' Data table Row 만큼 반복 -1은 마지막행은 Null
            If LstApp_t.Text = Table.Rows(i)(1).ToString() Then ' 선택 된 App과 Row, 필트(0)은 App, (1) 은 Feature
                Try
                    If Not LstFeat_t.Items.Contains(Table.Rows(i)(2).ToString()) Then  ' 중복 없이 Item 추가
                        LstFeat_t.Items.Add(Table.Rows(i)(2).ToString())
                    End If
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            End If
        Next

        If InStr(Summ.Text, "ex)") Then
        Else
            'Summ.Text = ""
            With txtFea
                .Text = ""
                .Font = New Font("맑은 고딕", 9)
                .ForeColor = Color.Black
            End With
        End If

        txtFea.Text = ""
        txtFea.ForeColor = Color.Black

    End Sub

    Private Sub LstType_t_SelectedIndexChanged(sender As Object, e As EventArgs) Handles LstType_t.SelectedIndexChanged
        Dim Table As DataTable = DS_Wear.Tables(1)

        Table.DefaultView.Sort = "Detailed Symptom ASC"
        DesTxt_t.Text = ""
        LstSym_t.Items.Clear()

        For i As Integer = 0 To Table.Rows.Count - 1
            If LstType_t.Text = Table.Rows(i)(0).ToString Then
                Try
                    DesTxt_t.Text = Table.Rows(i)(1).ToString()
                    If Not LstSym_t.Items.Contains(Table.Rows(i)(2).ToString()) Then
                        LstSym_t.Items.Add(Table.Rows(i)(2).ToString())
                    End If
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            End If
        Next
    End Sub

    Private Sub LstFeat_t_SelectedIndexChanged(sender As Object, e As EventArgs) Handles LstFeat_t.SelectedIndexChanged
        Dim Table As DataTable = DS_Wear.Tables(6)

        DesTxt_t.Text = ""

        For i As Integer = 0 To Table.Rows.Count - 1
            If LstApp_t.Text = Table.Rows(i)(1) And LstFeat_t.Text = Table.Rows(i)(2).ToString Then
                Try
                    DesTxt_t.Text = Table.Rows(i)(3).ToString()
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            End If
        Next
    End Sub

    Private Sub LstSym_t_SelectedIndexChanged(sender As Object, e As EventArgs) Handles LstSym_t.SelectedIndexChanged
        Dim table As DataTable = DS_Wear.Tables(1)

        DesTxt_t.Text = ""

        For i As Integer = 0 To Table.Rows.Count - 1
            If LstType_t.Text = table.Rows(i)(0) And LstSym_t.Text = table.Rows(i)(2).ToString Then
                Try
                    DesTxt_t.Text = table.Rows(i)(3).ToString()
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            End If
        Next
    End Sub

    Private Sub LstCon_t_SelectedIndexChanged(sender As Object, e As EventArgs) Handles LstCon_t.SelectedIndexChanged
        Dim table As DataTable = DS_Wear.Tables(2)

        DesTxt_t.Text = ""

        For i As Integer = 0 To table.Rows.Count - 1
            If LstCon_t.Text = table.Rows(i)(0).ToString Then
                Try
                    DesTxt_t.Text = table.Rows(i)(1).ToString()
                Catch ex As Exception

                End Try
            End If
        Next
    End Sub

    Private Sub LstRP_t_SelectedIndexChanged(sender As Object, e As EventArgs) Handles LstRP_t.SelectedIndexChanged
        Dim table As DataTable = DS_Wear.Tables(2)

        DesTxt_t.Text = ""

        For i As Integer = 0 To table.Rows.Count - 1
            If LstRP_t.Text = table.Rows(i)(2).ToString Then
                Try
                    DesTxt_t.Text = table.Rows(i)(3).ToString()
                Catch ex As Exception

                End Try
            End If
        Next
    End Sub


End Class

