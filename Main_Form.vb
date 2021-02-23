Imports System.Data
Imports System.Data.OleDb
Imports System.Windows.Forms
Imports Microsoft.Office.Interop
Imports Excel = Microsoft.Office.Interop.Excel
Imports Microsoft.Win32
Imports System.IO
Imports System.Xml
Imports System.Deployment
Imports System.Threading

Public Class Main_Form
    Dim bCreated As Boolean
    Dim mtx As New Threading.Mutex(True, "MyMutex", bCreated) 'MyMutex 라는 이름으로 뮤텍스 생성
    Public Notification_Message As New Notification_Message
    Public DS As DataSet = New DataSet
    Public DA As OleDbDataAdapter = New OleDbDataAdapter()
    Public strSQL As String
    Public vConn As OleDbConnection
    Public Password As String = "lge1234"
    Public strCon As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=QPortalDB.accdb;Jet OLEDB:Database Password = lge1234;"
    Public strCon_Kernel As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=\\10.174.51.33\Q-Portal\Kernel_DB.accdb;Jet OLEDB:Database Password = lge1234;"
    Public strModel_Comparing As String
    Public strPre_Condition As String
    Public strDes As String
    Public strUserName As String

    'XML 파일을 생성 해줌
    Public Sub Make_XML(sender As Object, e As EventArgs)
        Dim PathForm As New PathForm
        PathForm.btnDefault_Click(sender, e)
        PathForm.btnXML_Click(sender, e)
        PathForm = Nothing
    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles btn_summary_next.Click
        'Summary Form 띄우기

        Dim Summary_NEXT As New Summary_NEXT
        Summary_NEXT.Show()

    End Sub
    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click

        Dim TD_DATA_FORM As New pl_updown
        TD_DATA_FORM.Show()


    End Sub
    '#Region "웹페이지 접속"

    '    Private Function Delay(MS As Integer) As DateTime
    '        '## <Summary> 
    '        '## Make : SunBae

    '        Dim NowTime As DateTime = DateTime.Now  '# Now time
    '        Dim TSDuration As TimeSpan = New TimeSpan(0, 0, 0, 0, MS)   ' make Span
    '        Dim NextTime As DateTime = NowTime.Add(TSDuration)  ' add time duration

    '        While NextTime >= NowTime   ' is now time arrive to Next time
    '            System.Windows.Forms.Application.DoEvents()
    '            NowTime = DateTime.Now
    '        End While

    '        Return DateTime.Now

    '    End Function
    '    '# 반복적으로 Webbrowser를 호출
    '    Private Sub LoopAction()
    '        Dim UrlZips() As String = {"https://blog.naver.com/tnsqo1126/221362586663", "https://blog.naver.com/bluedrugs/221369637899"}
    '        For Each s As String In UrlZips
    '            Thread.Sleep(10000)
    '            WebLoop(WebBrowser1, s)
    '        Next

    '        DelControl(WebBrowser1, "삭제")
    '        WebBrowser1 = Nothing
    '        GC.Collect()

    '    End Sub
    '    Private trd As Thread
    '    Private Delegate Sub LoopDelegate(wc As Control, url As String)
    '    Private Sub WebLoop(webBro As WebBrowser, ByVal url As String)
    '        '## <Summary> 
    '        '## Make : SunBae
    '        Dim blChk As Boolean = False
    '        If (webBro.InvokeRequired = True) Then  '# 해당 컨트롤이 이 쓰레드에 존재 하는지 확인
    '            '# True면 해당 쓰레드가 아니므로 Invoke를 통해서 콜백
    '            webBro.Invoke(New LoopDelegate(AddressOf WebLoop), New Object() {WebBrowser1, url})
    '        Else
    '            '# 해당 컨트롤이 이 쓰레드 이므로 접근 가능한 상태
    '            webBro.Show()               ' Hide Control
    '            webBro.GoHome()
    '            webBro.Navigate(url)      ' Go to Url 
    '        End If
    '    End Sub
    '    Private Delegate Sub DeleteControl(wc As Control, s As String)
    '    Private Sub DelControl(wc As Control, CheckValue As String)
    '        Select Case CheckValue
    '            Case "추가"
    '                Dim w As WebBrowser = New WebBrowser
    '                Controls.Add(w)
    '                w.Name = "WebBrowser1"
    '                w.Dispose()
    '            Case "삭제"
    '                For Each ctrl As Control In Controls
    '                    If (ctrl.GetType() Is GetType(WebBrowser)) Then    '# 해당 컨트롤이 WebBrowser 라면
    '                        If ctrl.InvokeRequired Then
    '                            ctrl.Invoke(New DeleteControl(AddressOf DelControl), New Object() {WebBrowser1, "삭제"})
    '                        Else
    '                            Controls.Remove(ctrl)
    '                            ctrl = Nothing
    '                        End If
    '                        Exit For
    '                    End If
    '                Next
    '        End Select
    '    End Sub

    '#End Region
    Public Sub Main_Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If Not bCreated Then '뮤텍스가 정상적으로 생성되지 않았으면 같은 이름의 뮤텍스가 있는것으로 판단
            MessageBox.Show("프로그램이 실행 중입니다.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Application.ExitThread()
        End If

        'WebBrowser1.ScriptErrorsSuppressed = True



        'trd = New Thread(AddressOf LoopAction)
        'trd.Start()





        Icon = My.Resources.Qportal_Icon


        '   ReadFileInfoXml(Application.StartupPath & "\Config.xml")
        ' 해당 파일이 있는지 찾는 로직
        Dim strFilePath As String = Application.StartupPath
        Dim strFile As String = "QPortal_Path"
        Dim dirA As DirectoryInfo = New DirectoryInfo(strFilePath)    ' 디렉토리 지정
        Dim szTemp As String = Nothing
        Dim szFileName As String = Nothing
        Dim blchk As Boolean = False
        Dim version As String = Nothing

        '현재 버전을 찾아서 변수에 넣어줌
        If System.Deployment.Application.ApplicationDeployment.IsNetworkDeployed Then
            With System.Deployment.Application.ApplicationDeployment.CurrentDeployment.CurrentVersion
                version = "V" & .Major & "." & .Minor & "." & .Build
                Label2.Text = "Version : " & .Major & "." & .Minor & "." & .Build
            End With
        End If

        'Label2.Text = "Version : " & Application.ProductVersion
        ' XML 파일이 존재하는지 확인함
        For Each dra In dirA.GetFiles()     ' For each를 통해 폴더 내의 파일을 찾음
            szTemp = dra.Name
            If InStr(Trim(dra.Name), RTrim(strFile)) And Strings.Left(szTemp, 2) <> "~$" Then  ' Consumer TC와 Kernel TC / Framework TC의 파일 Naming이 다름
                szFileName = dra.Name
                blchk = True
                Exit For
            End If
        Next

        'XML 
        If blchk Then
            '파일 있을시 
            'XML에서 버전을 읽어와서 비교하는 부분
            Dim strVer As String = Nothing
            Dim xmlReader = New XmlTextReader(Application.StartupPath + "\QPortal_Path.XML")
            Do While xmlReader.Read() ' XML 파일 한줄씩 읽어옴
                If xmlReader.NodeType = XmlNodeType.Element AndAlso xmlReader.Name = "Version" Then ' NodeType가 Element고 Name이 Address일 경우
                    strVer = xmlReader.ReadElementContentAsString ' 해당 Element의 String값을 읽어옴
                End If
            Loop
            xmlReader.Close() ' XML Reader 닫음
            'Debug버전에서 사용하는 부분 실제로는 주석 필요
            '  version = Application.ProductVersion
            ' 만약 현재버전과 XML파일의 버전비교
            If version = strVer Then
                'Exit Sub
            Else
                Make_XML(sender, e)
            End If
        Else
            '파일 없을시
            Make_XML(sender, e)
        End If

        ' UserName(EP) 설정해줌
        Dim strEP As String = Nothing
        Dim strName As String = Nothing
        Dim xml As New XML

        xml.GetUserName(strEP, strName)
        xml = Nothing

        strUserName = strName + "(" + strEP + ")"
        laName.Text = strUserName

    End Sub


    Private Sub Dic_btn_Click(sender As Object, e As EventArgs) Handles Dic_btn.Click
        Dim Dictionary_GM As New Dictionary_GM
        Dictionary_GM.Show()
    End Sub

    Private Sub Main_Form_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        '   vConn.Close()   ' Program이 닫힐 때 DB Connection Close
    End Sub

    Private Sub Tips_btn_Click(sender As Object, e As EventArgs) Handles Tips_btn.Click
        Dim Tips As New Tips_GM
        Dim blChk As Boolean = False
        Tips.Show()
    End Sub

    Private Sub Consumer_btn_Click(sender As Object, e As EventArgs) Handles Consumer_btn.Click
        Dim Consumer As New Consumer
        Consumer.Show()
    End Sub

    Private Sub Work_btn_Click(sender As Object, e As EventArgs) Handles Work_btn.Click
        Dim Work_Guide As New Work_Guide
        Work_Guide.Show()
    End Sub

    Private Sub Main_Form_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        ' 해당 파일이 있는지 찾는 로직
        Dim strFilePath As String = Application.StartupPath
        Dim strFile As String = "Tips_DB"
        Dim dirA As DirectoryInfo = New DirectoryInfo(strFilePath)    ' 디렉토리 지정
        Dim szTemp As String = Nothing
        Dim szFileName As String = Nothing
        Dim blchk As Boolean = False


        For Each dra In dirA.GetFiles()     ' For each를 통해 폴더 내의 파일을 찾음
            szTemp = dra.Name
            If InStr(Trim(dra.Name), RTrim(strFile)) And Strings.Left(szTemp, 2) <> "~$" Then  ' Consumer TC와 Kernel TC / Framework TC의 파일 Naming이 다름
                szFileName = dra.Name
                blchk = True
                Exit For
            End If
        Next

        'XML 
        If blchk Then
            '파일 있을시 
            IO.File.Delete(Application.StartupPath + "\Tips_DB.xlsx")
        End If

        mtx.ReleaseMutex()

    End Sub

    Private Sub Master_btn_Click(sender As Object, e As EventArgs)
        Dim TestCase_GM As New TestCase_GM
        TestCase_GM.Show()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim DS As DataSet = New DataSet

        Dim xml As New XML
        Dim vCon As String = Nothing
        Dim table_aname As DataTable = Nothing
        Dim strEP As String = Nothing
        Dim strName As String = Nothing

        xml.GetUserName(strEP, strName)

        xml.vCon_Admin_Call(vCon)

        xml = Nothing
        strSQL = "Select A_NAME from Admin_Name"

        Try
            vConn = New OleDbConnection(vCon)   ' MainForm의 Connection String으로 DB Connect
            ' Looping 하여 Data Adapter 실행

            Dim DA = New OleDbDataAdapter(strSQL, vConn)
            DA.Fill(DS, "admin_name")

            table_aname = DS.Tables("admin_name")


            Dim chk As Boolean = False

            For Each a In table_aname.Rows

                If strUserName = a.item(0).ToString Then
                    chk = True
                    MsgBox(strName & " 관리자님 반갑습니다.")
                    Dim AdminMain As New AdminMain
                    AdminMain.Show()
                End If

            Next

            If chk = False Then
                Dim custom_msg As New custom_msgbox
                custom_msg.Label1.Text = "접근 할 수 있는 권한이 없습니다. " & vbLf & "문의하실 내용이 있으면 하단의 문의하기를 이용해 주세요."
                custom_msg.Show()
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        'Dim Login As New Login
        'Login.Show()

    End Sub

    Private Sub Knowledge_btn_Click(sender As Object, e As EventArgs) Handles Knowledge_btn.Click
        Dim Asset_Noti_etc As New Asset_Noti_etc

        Asset_Noti_etc.Show()
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        'Dim History As New History
        'History.Show()

        Dim History_test As New History_test        ' 20180416 15:31
        History_test.Show()


    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        ' Help 선택 시 pptx 파일 열어 주도록 
        If MsgBox("Help 파일 실행합니다." & "진행 하시겠습니까?", vbQuestion + vbYesNo, "lee.sunbae@lgepartner.com") = vbNo Then
            Exit Sub
        Else
            Try



            Catch ex As Exception
                'MsgBox(ex.Message, "열려는 파일이 없습니다." & vbCrLf &  "에서 확인 해보세요.")
            End Try
        End If


    End Sub

    ' What if press F1 Keys User
    Private Sub Main_Form_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Convert.ToChar(112) Then
            Call Button4_Click(sender, e)

        End If
    End Sub

    Private Sub Share_btn_Click(sender As Object, e As EventArgs)
        Dim Share_Info As New Share_Info
        Share_Info.Show()

    End Sub
    '★ 자체 TC 관련 업무
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btn_FrameworkTC.Click
        Dim Other_TC As New Other_TC
        Other_TC.Show()
    End Sub

    Private Shared Sub Get45or451FromRegistry()
        Using ndpKey As RegistryKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine,
                    RegistryView.Registry32).OpenSubKey("SOFTWARE\Microsoft\NET Framework Setup\NDP\v4\Full\")

            If ndpKey IsNot Nothing AndAlso ndpKey.GetValue("Release") IsNot Nothing Then
                Console.WriteLine("Version: " & CheckFor45DotVersion(CInt(ndpKey.GetValue("Release"))))
            Else
                Console.WriteLine("Version 4.5 or later is not detected.")
            End If
        End Using
    End Sub

    Private Shared Function CheckFor45DotVersion(releaseKey As Integer) As String
        If releaseKey >= 393295 Then
            Return "4.6 or later"
        End If
        If releaseKey >= 379893 Then
            Return "4.5.2 or later"
        End If
        If releaseKey >= 378675 Then
            Return "4.5.1 or later"
        End If
        If releaseKey >= 378389 Then
            Return "4.5 or later"
        End If
        ' This line should never execute. A non-null release key should mean
        ' that 4.5 or later is installed.
        Return "No 4.5 or later version detected"
    End Function

    Private Sub Self_TC_Btn_Click(sender As Object, e As EventArgs)
        If MsgBox("현황조회 엑셀 실행합니다." & "진행 하시겠습니까?", vbQuestion + vbYesNo, "lee.sunbae@lgepartner.com") = vbNo Then
            Exit Sub
        Else
            Dim strPath As String = "\\10.174.51.56\업무 공유\통합DB\자체TC"
            ' strSht = "Work_Noti"
            '
            Dim strMasterTC As String = "자체TC_현황조회문서.xlsm"
            Dim strFileName As String = strPath & "\" & strMasterTC

            Try
                If IO.File.Exists(strFileName) Then
                    Dim Proceed As Boolean = False
                    Dim xlApp As Excel.Application = Nothing
                    Dim xlWorkBooks As Excel.Workbooks = Nothing
                    Dim xlWorkBook As Excel.Workbook = Nothing
                    Dim xlWorkSheet As Excel.Worksheet = Nothing
                    Dim xlWorkSheets As Excel.Sheets = Nothing
                    Dim xlCells As Excel.Range = Nothing
                    xlApp = New Excel.Application
                    xlApp.DisplayAlerts = False
                    xlWorkBooks = xlApp.Workbooks
                    xlWorkBook = xlWorkBooks.Open(strFileName,, True)   ' Read Only Open

                    xlApp.Visible = True
                    xlWorkSheets = xlWorkBook.Sheets
                End If
            Catch ex As Exception
                MsgBox(ex.Message, "열려는 파일이 없습니다." & vbCrLf & strPath & "에서 확인 해보세요.")
            End Try
        End If
    End Sub

    Private Sub Self_TC_Btn_MouseEnter(sender As Object, e As EventArgs)

    End Sub

    Private Sub Self_TC_Btn_MouseMove(sender As Object, e As MouseEventArgs)
        Des_txt.Text = "업체별로 제작한 자체 TC진행 결과를 조회할 수 있습니다."
    End Sub

    Private Sub One_Time_Click(sender As Object, e As EventArgs) Handles One_Time.Click
        ' 랜덤 분석
        Dim One_Time_Page As New One_Time_Page
        One_Time_Page.Show()
    End Sub

    Private Sub Random_MD_Click(sender As Object, e As EventArgs)
        ' 랜덤 분석
        Dim Random_Analysis As New Random_Analysis
        Random_Analysis.Show()
    End Sub
    Private Sub VP_Report_Click(sender As Object, e As EventArgs) Handles VP_Report.Click
        ' VP Report 문서 
        Dim VP_Report_Page As New VP_Report_Page
        VP_Report_Page.Show()
    End Sub

    Private Sub btn_LNL_Click(sender As Object, e As EventArgs) Handles btn_LNL.Click
        ' Lesson ＆ Learn
        Dim Lesson As New Lesson
        Lesson.Show()
    End Sub

    Private Sub btn_Contents_Click(sender As Object, e As EventArgs) Handles btn_Contents.Click
        ' 검증 컨텐츠 / 검증 관련 Tools
        '  "\\10.174.51.33\Q-Portal\검증 컨텐츠, 검증 Tools"
        Dim Contents_form As New Contents_form
        Contents_form.Show()

    End Sub

    Private Sub btn_Study_Click(sender As Object, e As EventArgs)
        ' 교육 자료 연결 
        Dim Study_Contents As New Study_Contents
        Study_Contents.Show()

    End Sub

    Private Sub btn_Template_Click(sender As Object, e As EventArgs) Handles btn_Template.Click
        ' 최신 Template 추가
        Dim Recent_Template As New Recent_Template
        Recent_Template.Show()
    End Sub

    Private Sub GroupBox3_Enter(sender As Object, e As EventArgs) Handles GroupBox3.Enter

    End Sub

    Private Sub TOOL_Click(sender As Object, e As EventArgs) Handles btn_Tool.Click
        Dim TestTools As New TestTools
        TestTools.Show()

    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles btn_ChongSi.Click
        Dim Dictionary_GM2 As New Dictionary_GM2
        Dictionary_GM2.Show()

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles btn_Kernel.Click
        Dim kernel As New Kernel
        kernel.Show()

    End Sub

    '★ Delta 선택 시 Event ( 단, 현재는 기능 구현이 되어있지 않으므로 Unvisible)
    Private Sub btn_Delta_Click(sender As Object, e As EventArgs) Handles btn_3rdParty.Click, Button2.Click

        If DirectCast(sender, Control).Name = "btn_Delta" Or DirectCast(sender, Control).Name = "btn_function" Or DirectCast(sender, Control).Name = "btn_3rdParty" Or DirectCast(sender, Control).Name = "Button2" Then
            MsgBox("현재 기능 구현 중 입니다.")
        End If


    End Sub
    '★[설명 Delta]★
    Private Sub group_MouseMove(sender As Object, e As EventArgs) Handles GroupBox1.MouseMove, GroupBox2.MouseMove, GroupBox3.MouseMove, GroupBox4.MouseMove,
                                                                          GroupBox5.MouseMove, GroupBox6.MouseMove
        Des_txt.Text = "Q-Portal(Quality Portal System) 입니다." & vbCrLf & "환영 합니다."
    End Sub

    ' ☆★ [마우스 가져다 두었을 때 설명을 보여주는 부분] ★★
    Private Sub btn_ShowDescription(sender As Object, e As EventArgs) Handles Me.MouseMove, btn_Tool.MouseMove, btn_Contents.MouseMove,
                                                                              VP_Report.MouseMove, btn_LNL.MouseMove, Dic_btn.MouseMove,
                                                                              Tips_btn.MouseMove, Consumer_btn.MouseMove, Knowledge_btn.MouseMove, Work_btn.MouseMove,
                                                                              One_Time.MouseMove, btn_Template.MouseMove,
                                                                              btn_ChongSi.MouseMove, btn_Kernel.MouseMove, btn_FrameworkTC.MouseMove, Button2.MouseMove
        If DirectCast(sender, Control).Name = "btn_Study" Then   ' 만약 Event를 Click 한 Handler가 FUT라면
            Des_txt.Text = "신규인원 및 기존인원 교육 자료를 확인할 수 있습니다."

        ElseIf DirectCast(sender, Control).Name = "btn_Tool" Then
            Des_txt.Text = "검증에 필요한 Tool을 한 번에 확인할 수 있습니다.."

        ElseIf DirectCast(sender, Control).Name = "btn_Contents" Then
            Des_txt.Text = "검증에 필요한 컨텐츠를 확인하여 찾을 수 있습니다."

        ElseIf DirectCast(sender, Control).Name = "VP_Report" Then
            Des_txt.Text = "VP 검증 현황을 한 눈에 확인할 수 있습니다."

        ElseIf DirectCast(sender, Control).Name = "btn_function" Then
            Des_txt.Text = "기능 구현 중입니다."

        ElseIf DirectCast(sender, Control).Name = "btn_LNL" Then
            Des_txt.Text = "Leason & Learn 대책서를 조회할 수 있습니다. "

        ElseIf DirectCast(sender, Control).Name = "Dic_btn" Then
            Des_txt.Text = "모르는 용어를 검색할 수 있습니다."

        ElseIf DirectCast(sender, Control).Name = "Tips_btn" Then
            Des_txt.Text = "기본적인 검증 항목들을 가이드 해줍니다."

        ElseIf DirectCast(sender, Control).Name = "Consumer_btn" Then
            Des_txt.Text = "고객 입장에서 발생 할 수 있는 실 사용적인 조건들을 가이드 해줍니다."

        ElseIf DirectCast(sender, Control).Name = "Knowledge_btn" Then
            Des_txt.Text = "시료 현황 조회, 보유 자산 및 호환성 자산을 조회(ex, HBS-1100, 3/4극, SD Card, etc)"

        ElseIf DirectCast(sender, Control).Name = "Work_btn" Then
            Des_txt.Text = "기본적인 업무 가이드를 제공해주며, 검증원, 모델리더별 검증 전/중/후에 대해 가이드를 줍니다." & vbCrLf & "ex) 신입 업무가이드, OS UP가이드, 버전 다운로드 방법, etc."

        ElseIf DirectCast(sender, Control).Name = "Master_btn" Then
            Des_txt.Text = "Master T/C 를 열어서 확인 할 수 있으며, 설명을 확인할 수 있음"

        ElseIf DirectCast(sender, Control).Name = "One_Time" Then
            Des_txt.Text = "1회성 결함율 현황을 조회하고, 1회성 결함 전문 분석을 할 수 있습니다."

        ElseIf DirectCast(sender, Control).Name = "Random_MD" Then
            Des_txt.Text = "Random MD 사용이력, Random에 대해 계획 수립 확인을 할 수 있습니다."

        ElseIf DirectCast(sender, Control).Name = "btn_Template" Then
            Des_txt.Text = "각종 문서양식의 최종버전을 확인할 수 있습니다. ex) VP Report/Random계획서/Random Know-How/etc."

        ElseIf DirectCast(sender, Control).Name = "btn_ChongSi" Then
            Des_txt.Text = "총시를 기반으로 변경 된 사항을 분석 확인할 수 있습니다."

        ElseIf DirectCast(sender, Control).Name = "btn_Kernel" Then
            Des_txt.Text = "Kernel / Framework 에 대한 정보를 제공 합니다."

        ElseIf DirectCast(sender, Control).Name = "btn_Td" Then
            Des_txt.Text = "TD 및 SVMS로 Defect 등록 시 결함 작성을 도와줍니다."

        ElseIf DirectCast(sender, Control).Name = "btn_FrameworkTC" Then
            Des_txt.Text = "자체 T/C 및 Framework T/C의 현황 및 T/C 파일을 제공 합니다."

        ElseIf DirectCast(sender, Control).Name = "button2" Then
            Des_txt.Text = "각 사업자별 특성을 Check List화 하여 확인합니다."

        ElseIf DirectCast(sender, Control).Name = "Share_btn" Then
            Des_txt.Text = "Leakage 재발 방지하기 위하여 체크리스트화 하여 검증할 수 있습니다."
            'Share_btn
        ElseIf DirectCast(sender, Control).Name = "btn_Model_Plan" Then
            Des_txt.Text = "기존 모델들 검증 기획"
        Else
            Des_txt.Text = "Q-Portal(Quality Portal System) 입니다." & vbCrLf & "환영 합니다."
        End If

    End Sub

    Private Sub btn_ShowDescription(sender As Object, e As MouseEventArgs) Handles Work_btn.MouseMove, VP_Report.MouseMove, Tips_btn.MouseMove, One_Time.MouseMove, MyBase.MouseMove, Knowledge_btn.MouseMove, Dic_btn.MouseMove, Consumer_btn.MouseMove, btn_Tool.MouseMove, btn_Template.MouseMove, btn_LNL.MouseMove, btn_Kernel.MouseMove, btn_FrameworkTC.MouseMove, btn_Contents.MouseMove, btn_ChongSi.MouseMove, Button2.MouseMove, btn_summary_next.MouseMove, btn_Project_Plan.MouseMove, btn_Model_Plan.MouseMove

    End Sub



    Private Sub btn_Rnadom_Click(sender As Object, e As EventArgs)
        Dim Random_Plan_Page As New M_Random_Plan_Page
        Random_Plan_Page.Show()

    End Sub

    Private Sub btn_new_Click(sender As Object, e As EventArgs)
        Dim ddd As New Dictionary_GM
        ddd.Show()

    End Sub

    Private Sub btn_Td_Click(sender As Object, e As EventArgs)
        Dim Summary As New Summary_test
        Summary.Show()



    End Sub

    Private Sub Button5_Click_1(sender As Object, e As EventArgs) Handles Button5.Click
        Dim Qportal_Settings As New Qportal_Settings
        Qportal_Settings.ShowDialog()

    End Sub

    Public Sub ShowMyDialogBox()
        'Dim testDialog As New Form2()

        '' Show testDialog as a modal dialog and determine if DialogResult = OK.
        'If testDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK Then
        '    ' Read the contents of testDialog's TextBox.
        '    'txtResult.Text = testDialog.TextBox1.Text
        'Else
        '    'txtResult.Text = "Cancelled"
        'End If
        'testDialog.Dispose()
    End Sub 'ShowMyDialogBox

    Private Sub btnPlan_New_Click(sender As Object, e As EventArgs)
        ' 신규 Plan Page
        Dim New_RandomPlan_Page As New New_RandomPlan_Page
        New_RandomPlan_Page.Show()


    End Sub

    Private Sub Button6_Click_1(sender As Object, e As EventArgs) Handles Button6.Click
        Dim Survey As New Survey

        Survey.Show()

    End Sub

    '## Project 기획 눌렀을 때 
    Private Sub btn_Proejct_Click(sender As Object, e As EventArgs)
        Dim Product_of_Project As New Product_of_Project
        Product_of_Project.Show()
    End Sub
    '## Model 기획 눌렀을 때
    Private Sub btn_Model_Click(sender As Object, e As EventArgs)
        Dim Product_of_Model As New Product_of_Model
        Product_of_Model.Show()
    End Sub
    '## Tester 기획 눌렀을 때
    Private Sub btn_Tester_Click(sender As Object, e As EventArgs)
        Dim Product_of_Tester As New Product_of_Tester
        Product_of_Tester.Show()
    End Sub

    '# 시험 기획 20180912
    Private Sub btn_Plan_Click(sender As Object, e As EventArgs) Handles btn_Project_Plan.Click
        Dim RP_Project As New P_Random_Plan_Page
        RP_Project.Show()

    End Sub

    Private Sub btn_Model_Plan_Click(sender As Object, e As EventArgs) Handles btn_Model_Plan.Click
        Dim M_Random_Plan_Page As New M_Random_Plan_Page
        M_Random_Plan_Page.Show()
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Dim PN_2_0_MAIN As New pl_Export_Upload
        PN_2_0_MAIN.show()
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        Dim vs As New version_history
        vs.Show()
    End Sub
End Class