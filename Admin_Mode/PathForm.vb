Imports System.Xml
Imports System.Windows.Forms

Public Class PathForm
    Public Recent_Template As New Recent_Template
    Public Sub btnXML_Click(sender As Object, e As EventArgs) Handles btnXML.Click
        Dim writer As New XmlTextWriter(Application.StartupPath + "\QPortal_Path.xml", System.Text.Encoding.UTF8)
        Dim version As String = Nothing

        writer.WriteStartDocument(True)
        writer.Formatting = Formatting.Indented
        writer.Indentation = 2

        '현재 Q-Portal 버전을 찾아서 변수에 넣어줌
        If System.Deployment.Application.ApplicationDeployment.IsNetworkDeployed Then
            With System.Deployment.Application.ApplicationDeployment.CurrentDeployment.CurrentVersion
                version = "V" & .Major & "." & .Minor & "." & .Build
            End With
        End If

        'UserName을 저장해 줌
        '사용자명 가져오는 부분
        Dim strName As String = Nothing
        Dim strEP As String = Nothing

        ' 유저네임 가져옴(EP계정)
        strEP = Environment.UserName

        ' 시스템의 컴퓨터 설명을 가져온다 ex)염경민/협력사 사원/MC SW인정1팀_외주지원반(gyeongmin.yeom@lgepartner.com)
        Dim strComputer As String
        strComputer = "."
        Dim Obj = GetObject("winmgmts:{impersonationLevel=impersonate}!\\" & strComputer & "\root\cimv2").ExecQuery("Select * FROM Win32_OperatingSystem")
        For Each Obj2 In Obj
            strName = Obj2.Description
        Next

        ' 가져온 컴퓨터설명을 Split를 사용하여 만들어진 배열의 의 첫번째 한글이름 만 저장
        strName = Strings.Split(strName, "/")(0)

        ' Path Element 열기 <Path>
        writer.WriteStartElement("Path")
        '현재 버전과 유저네임을 넣을 Element생성
        writer.WriteStartElement("QPortal_Version")
        createNode(txtVersion.Text, "Version", writer)
        createNode(strEP, "EP", writer)
        createNode(strName, "UserName", writer)
        writer.WriteEndElement()
        'XML File 위치 저장
        writer.WriteStartElement("XML_File")
        createNode(Application.StartupPath, "XML_FilePath", writer)
        writer.WriteEndElement()
        ' OleDbConnection에 필요한 Data저장
        writer.WriteStartElement("vCon_Data")
        createNode("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=", "Provider", writer)
        createNode("\QPortalDB.accdb;Jet OLEDB:Database Password = lge1234;", "QPortalDB", writer)
        createNode("\QPortalDB_Admin.accdb;Jet OLEDB:Database Password = lge1234;", "QPortalDB_Admin", writer)
        createNode("\Kernel_DB.accdb;Jet OLEDB:Database Password = lge1234;", "KernelDB", writer)
        'createNode("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=", "Provider", writer)
        'createNode("\QPortalDB.accdb; Persist Security Info=False;", "QPortalDB", writer)
        'createNode("\QPortalDB_Admin.accdb;Persist Security Info=False;", "QPortalDB_Admin", writer)
        'createNode("\Kernel_DB.accdb;Persist Security Info=False;", "KernelDB", writer)
        writer.WriteEndElement()

        'Main 부분 
        writer.WriteStartElement("Main")
        '메인서버위치
        createNode(txtServer.Text, "Main_Server", writer)
        '관리자DB
        createNode(txtAdmin.Text, "AdminDB", writer)
        'AccessDB
        createNode(txtAccess.Text, "AccessDB", writer)
        writer.WriteEndElement()

        '검증정보 부분 
        writer.WriteStartElement("검증정보")
        '교육자료
        createNode(txtEdu.Text, "Study_Contents", writer)
        '업무가이드
        createNode(txtGuide.Text, "Guide", writer)
        '시료,장비조회
        createNode(txtAsset.Text, "Asset", writer)
        '검증 Tool
        createNode(txtTool.Text, "Tool", writer)
        '검증 컨텐츠
        createNode(txtContent.Text, "Contents", writer)
        'Template
        createNode(txtTemplate.Text, "Template", writer)
        writer.WriteEndElement()

        '검증현황 부분 
        writer.WriteStartElement("검증현황")
        'VP검증현황
        createNode(txtVP.Text, "VP", writer)
        'Defect분석
        createNode(txtDefect.Text, "Defect", writer)
        '1회성분석
        createNode(txtOneTime.Text, "OneTime", writer)
        writer.WriteEndElement()


        'Test Case 부분 
        writer.WriteStartElement("TestCase")
        '목적TC
        createNode(txtTC.Text, "TC", writer)
        'MasterTC(Non)
        createNode(txtNonTC.Text, "MasterNonTC", writer)
        'MasterTC(Func)
        createNode(txtFuncTC.Text, "MasterFuncTC", writer)
        writer.WriteEndElement()

        'Check-List 부분
        writer.WriteStartElement("Check-List")
        '기본검증
        createNode(txtTip.Text, "Tip", writer)
        'L&L대책서
        createNode(txtLL.Text, "LL", writer)
        '재발방지(수평전개)
        createNode(txtShare.Text, "Share", writer)
        'Delta
        createNode("DB정보없음", "Delta", writer)

        writer.WriteEndElement()
        'Random 부분 
        writer.WriteStartElement("Random")
        '변경점검증
        createNode(txtCheck.Text, "Check", writer)
        'Consumer
        createNode(txtConsumer.Text, "Consumer", writer)
        '신뢰성검증
        createNode(txtKernel.Text, "Kernel", writer)
        '3rd Party
        createNode(txt3rd.Text, "Operator", writer)
        '검증계획서
        createNode(txtRandom.Text, "Random_Change", writer)

        writer.WriteEndElement()

        'Path Element 닫음 >
        writer.WriteEndElement()
        writer.WriteEndDocument()
        writer.Close()

        For Each v In Application.OpenForms
            If v.Name = "PathForm" Then
                MsgBox("XML 업로드 완료")
            End If
        Next


    End Sub
    Private Sub createNode(ByVal pName As String, ByVal pPath As String, ByVal writer As XmlTextWriter)
        'Element 생성
        writer.WriteStartElement(pPath)
        '노드안의 내용 저장
        writer.WriteString(pName)
        writer.WriteEndElement()
    End Sub
    Public Sub clear()
        For Each a In Me.Controls
            ' 컨트롤을 돌면서 그룹박스에 속해있지않은 Text박스를 찾는 조건
            If TypeOf a Is TextBox Then
                a.text = ""
            End If
            'GroupBox안에 있는 TextBox의 Tag를 찾아서 비교하는 조건
            If TypeOf a Is GroupBox Then
                For Each b In a.Controls
                    If TypeOf b Is TextBox Then
                        b.text = ""
                    End If
                Next
            End If
        Next
    End Sub

    Public Sub PathForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        clear()
        Dim xmlReader As New XmlTextReader(Application.StartupPath + "\QPortal_Path.xml")
        Do While xmlReader.Read()
            For Each a In Me.Controls
                ' 컨트롤을 돌면서 그룹박스에 속해있지않은 Text박스를 찾는 조건
                If TypeOf a Is TextBox Then
                    If xmlReader.NodeType = XmlNodeType.Element AndAlso xmlReader.Name = a.tag Then
                        a.text = xmlReader.ReadElementContentAsString
                    End If
                End If
                'GroupBox안에 있는 TextBox의 Tag를 찾아서 비교하는 조건
                If TypeOf a Is GroupBox Then
                    For Each b In a.Controls
                        If TypeOf b Is TextBox Then
                            '미리 TextBox에 들어가야할 내용의 Node Name을 TextBox의 Tag에 저장해놓고 
                            '컨트롤을 돌면서 Node와 Tag이름이 같으면 텍스트 박스에 입력 해줌
                            If xmlReader.NodeType = XmlNodeType.Element AndAlso xmlReader.Name = b.tag Then
                                b.text = xmlReader.ReadElementContentAsString
                            End If
                        End If
                    Next
                End If
            Next
        Loop

        xmlReader.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        PathForm_Load(sender, e)
    End Sub

    '제일 기본으로 들어가야할 TextBox내용들
    Public Sub btnDefault_Click(sender As Object, e As EventArgs) Handles btnDefault.Click
        clear()
        '버전 알려주는 위치
        Dim version As String = Nothing
        '지금 해당 버전을 찾아서 변수에 넣어줌
        If System.Deployment.Application.ApplicationDeployment.IsNetworkDeployed Then
            With System.Deployment.Application.ApplicationDeployment.CurrentDeployment.CurrentVersion
                version = "V" & .Major & "." & .Minor & "." & .Build
            End With
        End If
        ' version = Application.ProductVersion

        txtVersion.Text = version
        'XML File 위치
        txtXMLFile.Text = Application.StartupPath
        'Main 부분 
        '메인서버위치
        txtServer.Text = "\\10.169.88.40\Q-Portal"
        'txtServer.Text = "\\sw2doc\SW Documents Server\00. Q-Portal"

        '관리자DB
        txtAdmin.Text = "\5.Admin(AccessDB)"
        'AccessDB
        txtAccess.Text = "\0.AccessDB"

        '검증정보 부분 
        '교육자료
        txtEdu.Text = "\1.검증정보\교육자료"
        '업무가이드
        txtGuide.Text = "\1.검증정보\업무Guide"
        '시료,장비조회
        txtAsset.Text = "\1.검증정보\호환성,시료,자산조회"
        '검증 Tool
        txtTool.Text = "\1.검증정보\검증Tool"
        '검증 컨텐츠
        txtContent.Text = "\1.검증정보\검증컨텐츠"
        'Template
        txtTemplate.Text = "\1.검증정보\최신Template"

        '검증현황 부분 
        'VP검증현황
        txtVP.Text = "\2.검증현황\VP검증현황"
        'Defect분석
        txtDefect.Text = "\2.검증현황\Defect 분석"
        '1회성분석
        txtOneTime.Text = "\2.검증현황\1회성 분석"

        'Test Case 부분 
        '목적TC
        txtTC.Text = "\3.검증Coverage\TestCase\목적TC(AccessDB-SelfTCMerge)"
        'MasterTC(Non)
        txtNonTC.Text = "\3.검증Coverage\TestCase\MasterTC(Non-Func)"
        'MasterTC(Func)
        txtFuncTC.Text = "\3.검증Coverage\TestCase\MasterTC(Func)"

        'Check-List 부분
        '기본검증
        txtTip.Text = "\3.검증Coverage\Check-List\기본검증"
        'L&L대책서
        txtLL.Text = "\3.검증Coverage\Check-List\L&L대책서"
        '재발방지(수평전개)
        txtShare.Text = "\3.검증Coverage\Check-List\재발방지"
        'Delta
        TextBox7.Text = "DB정보없음"

        'Random 부분 
        '변경점검증
        txtCheck.Text = "\3.검증Coverage\Random\변경점검증"
        'Consumer
        txtConsumer.Text = "AccessDB사용"
        '신뢰성검증
        txtKernel.Text = "\3.검증Coverage\Random\신뢰성검증"
        '3rd Party
        txt3rd.Text = "\3.검증Coverage\Random\3rdParty"
        '검증계획서
        txtRandom.Text = "\3.검증Coverage\Random\검증계획서"
    End Sub
End Class