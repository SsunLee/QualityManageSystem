Imports System.Collections.Generic
Imports System.Data
Imports System.Data.OleDb
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Xml

Public Class Survey
    Private DS As DataSet = New DataSet
    Public DS_Comp As DataSet = New DataSet
    Private DA As OleDbDataAdapter
    Private DS_Participant As DataSet = New DataSet

    Public XML As New XML

    Public Survey_Fm As String
    Public Survey_Age As Integer

    Public cnt As Integer = 1
    Public cnt_page As Integer = 0
    Public ne_page As Integer = 0

    Public vCon_Local2 As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=\\10.169.88.40\Q-Portal\0.AccessDB\QPortalDB.accdb;Jet OLEDB:Database Password = lge1234;"
    Public vCon_Local As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=\\10.169.88.40\Q-Portal\5.Admin(AccessDB)\QPortalDB_Admin.accdb;Jet OLEDB:Database Password = lge1234;"
    'Public vCon_Local As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\신창하\업무\Task\Test_db\admin\QPortalDB_Admin.accdb;Jet OLEDB:Database Password = lge1234;"
    Public vCon As String
    Public vConn As OleDbConnection
    Public vConn2 As OleDbConnection

    Public Survey_Title As String




    Public Sub Survey_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        Survey_Refresh()

        Label4.Text = cnt & " / " & Question.TabCount - cnt_page - ne_page
        '###############설문지 설S문내용 DB에서 불러오기################
        'Survey DB Query문
        'Dim SQL = "SELECT * FROM Survey ORDER BY ID ASC"

        'Dim XML As New XML
        'XML.vCon_Admin_Call(vCon)

        ''DB연결
        'vConn = New OleDbConnection(vCon_Local)

        ''Query 문 실행
        'Dim cmd As OleDbCommand = New OleDbCommand(SQL, vConn)
        'DA = New OleDbDataAdapter(cmd)
        'DA.Fill(DS, "Survey")

        'Dim Table As DataTable = DS.Tables("Survey")

        'For Each Ctrl In Me.Controls

        '    'Form안의 Control 중Type이 Panel 일 때
        '    If Ctrl.GetType() Is GetType(Panel) Then

        '        'Panel 안의 Control 중
        '        For Each a In Ctrl.Controls

        '            'Control Type이 Label 일 때
        '            If a.GetType() Is GetType(Label) Then

        '                For i As Integer = 0 To Table.Rows.Count - 1

        '                    If a.tag = Table.Rows(i)(0).ToString Then

        '                        a.text = Table.Rows(i)(1).ToString
        '                        Exit For

        '                    End If
        '                Next
        '            End If
        '        Next
        '    End If
        'Next

        '###############################################################

        '======================= 설문 참여 여부 확인부분 =======================
        'Query문 작성
        'Dim SQL_chkParticipant As String = "SELECT * FROM Survey_Participant WHERE 참여자 = '" & lbName.Text & "'"

        ''DB 연결
        'vConn = New OleDbConnection(vCon_Local)
        'Dim Cmd_chkParticipant As New OleDbCommand(SQL_chkParticipant, vConn)

        ''Query문 DB에 적용
        'DA = New OleDbDataAdapter(Cmd_chkParticipant)
        'DA.Fill(DS_Participant, "참여자")

        'Dim Table As DataTable = DS_Participant.Tables("참여자")

        ''설문(평가)에 1번만 참여할 수 있도록 예외처리


        'If Table.Rows.Count <> 0 Then

        '    MsgBox("이미 설문(평가)에 참여하셨습니다.") : Me.Close()

        '    Exit Sub

        'End If
        ''=======================================================================

        '' 이름을 받아옴
        'Dim UserName As String = Nothing
        'For Each v In System.Windows.Forms.Application.OpenForms
        '    If v.Name = "Main_Form" Then
        '        UserName = v.strUserName
        '        Exit For
        '    End If
        'Next

        'lbName.Text = UserName

        'Survey_Refresh()

        'Dim SQL_Admin As String = "SELECT * FROM Admin_Name ORDER BY ID ASC"

        'Dim Cmd_Admin As OleDbCommand = New OleDbCommand(SQL_Admin, vConn)
        'DA = New OleDbDataAdapter(Cmd_Admin)
        'DA.Fill(DS, "Admin")

        'Dim Table_Admin As DataTable = DS.Tables("Admin")

        'For i As Integer = 0 To Table_Admin.Rows.Count - 1

        '    If lbName.Text = Table_Admin.Rows(i)(1).ToString() Then

        '        lbComp.Visible = True
        '        lbCompName.Visible = True
        '        lbUser.Visible = True
        '        lbName.Visible = True

        '        btEdit.Visible = True
        '        Exit For

        '    Else

        '        lbComp.Visible = False
        '        lbCompName.Visible = False
        '        lbUser.Visible = False
        '        lbName.Visible = False

        '        btEdit.Visible = False

        '    End If

        'Next


        ' UserName(EP) 설정해줌
        Dim strEP As String = Nothing
        Dim strName As String = Nothing
        Dim xml As New XML
        Dim strUserName As String
        xml.GetUserName(strEP, strName)
        xml = Nothing

        strUserName = strName + "(" + strEP + ")"
        lbName.Text = strUserName

        'DB 연결
        vConn2 = New OleDbConnection(vCon_Local2)

        'Query문 실행

        Dim sqlCNS = "SELECT * FROM Contacts_C"
        Dim sqlInf = "SELECT * FROM Contacts_I"
        Dim sqlMst = "SELECT * From Contacts_M"


        Dim query_list As String() = New String() {sqlCNS, sqlInf, sqlMst}
        Dim loopsht As String() = New String() {"CNS", "인피닉", "MSTech"}

        Dim ncnt As Integer = 0
        Try


            For Each a As String In query_list

                Dim da = New OleDbDataAdapter(a, vConn2)
                da.Fill(DS_Comp, loopsht(ncnt))
                ncnt += 1

            Next
        Catch ex As Exception
            MsgBox(ex.Message)

        End Try
        vConn2 = Nothing


        Dim nW As Integer = 0
        Dim blcp As Boolean = True
        For nZ As Integer = 0 To 2      ' 
            For nW = 0 To DS_Comp.Tables(nZ).Rows.Count - 1
                If DS_Comp.Tables(nZ).Rows(nW)(2).ToString() = strName Then
                    lbCompName.Text = DS_Comp.Tables(nZ).Rows(nW)(4).ToString()
                    ' 회사 콤보박스 값 = 테이블에 (nZ)(4) 위치에 업체명 넣어줌.
                    blcp = False  ' Exit For가 한번만 나가면 또 다른 테이블 검색하기 때문에 Chk Boolean
                    Exit For
                End If
            Next
            If blcp = False Then  ' 이미 회사이름을 찾은 경우라면!
                Exit For
            End If
        Next

        '관리자 확인
        Dim sql_Admin As String = "SELECT * FROM Admin_Name"

        Dim cmd_admin As OleDbCommand = New OleDbCommand(sql_Admin, vConn)
        DA = New OleDbDataAdapter(cmd_admin)
        DA.Fill(DS, "Admin")

        For i As Integer = 0 To DS.Tables("Admin").Rows.Count - 1

            If strUserName <> DS.Tables("Admin").Rows(i)(1).ToString Then

                btEdit1.Visible = False
                btEdit2.Visible = False
                btEdit3.Visible = False
                btEdit4.Visible = False
                btEdit5.Visible = False
                btEdit6.Visible = False
                btEdit7.Visible = False
                btEdit8.Visible = False



            Else

                btEdit1.Visible = True
                btEdit2.Visible = True
                btEdit3.Visible = True
                btEdit4.Visible = True
                btEdit5.Visible = True
                btEdit6.Visible = True
                btEdit7.Visible = True
                btEdit8.Visible = True
                Exit For
            End If

        Next
    End Sub

    Private Sub Survey_Refresh()



        DS.Tables.Clear()
        Dim NE_Question As New List(Of String)
        Dim E_Question As New List(Of String)

        '    If Not DS.Tables.Count = 0 Then
        '        DS.Tables("Survey").Clear()
        '    End If
        '    '###############설문지 설문내용 DB에서 불러오기################

        '    Dim XML As New XML
        '    XML.vCon_Admin_Call(vCon)

        'Survey DB Query문
        Dim SQL = "SELECT * FROM Survey ORDER BY ID ASC"
        'DB연결
        vConn = New OleDbConnection(vCon_Local)

        'Query 문 실행
        Dim cmd As OleDbCommand = New OleDbCommand(SQL, vConn)
        DA = New OleDbDataAdapter(cmd)
        DA.Fill(DS, "Survey")

        Dim Table As DataTable = DS.Tables("Survey")

        '설문지 Title 넣기
        For Each Ctrl In Me.Controls

            If Ctrl.GetType() Is GetType(TabControl) Then

                For Each tpage In Ctrl.Controls

                    If tpage.GetType() Is GetType(TabPage) Then

                        For Each lb In tpage.Controls

                            If lb.GetType() Is GetType(Label) And lb.Tag = "nameSurvey" Then

                                lb.Text = Table.Rows(0)(1).ToString

                            End If
                        Next
                    End If
                Next
            End If
        Next

        '비어있는 질문 찾기
        For i As Integer = 0 To Table.Rows.Count - 1

            If Table.Rows(i)(3).ToString = "" Or Table.Rows(i)(3).ToString Is Nothing Then

                NE_Question.Add(Table.Rows(i)(0).ToString)

                '비어있지 않은 질문 찾기
            ElseIf Table.Rows(i)(3).ToString <> "" Or Table.Rows(i)(3).ToString IsNot Nothing Then

                E_Question.Add(Table.Rows(i)(0).ToString)

            End If
        Next





        For Each Ctrl In Me.Controls

            If Ctrl.GetType() Is GetType(TabControl) Then

                For Each tpage In Ctrl.Controls

                    If tpage.GetType() Is GetType(TabPage) Then

                        For Each pnl In tpage.Controls

                            If pnl.GetType() Is GetType(Panel) And pnl.Tag <> "fm" And pnl.Tag <> "age" Then

                                '데이터가 없는 DB 설문항목 삭제 부분
                                For i As Integer = 0 To NE_Question.Count - 1

                                    If NE_Question.Item(i).ToString = pnl.Tag Then

                                        pnl.Visible = False
                                        Exit For

                                    ElseIf ne_question.Item(i).ToString = "25" Then

                                        Next8.Visible = False
                                        btSubmit1.Visible = True
                                        cnt_page = 2

                                    End If
                                Next

                                For i As Integer = 0 To E_Question.Count - 1

                                    If E_Question.Item(i).ToString = pnl.Tag Then

                                        pnl.visible = True
                                        Exit For

                                    End If

                                Next

                                'DB의 설문 Data 뿌리기
                                For Each radio In pnl.Controls

                                    If radio.GetType() Is GetType(RadioButton) Then

                                        Dim row As Integer = pnl.Tag
                                        Dim col As Integer = radio.Tag
                                        radio.Text = Table.Rows(row - 1)(col + 3).ToString

                                    ElseIf radio.GetType() Is GetType(Label) And radio.Tag <> "" Then

                                        Dim Q_num As Integer = pnl.Tag
                                        radio.text = Table.Rows(Q_num - 1)(3).ToString

                                    End If
                                Next
                            End If
                        Next
                    End If
                Next
            End If
        Next

        ''총 Page 수 관련부분
        'For i As Integer = 1 To 4

        '    If Table.Rows((6 * i) - 2)(2).ToString = "" Or Table.Rows((6 * i) - 2)(2).ToString Is Nothing Then

        '        ne_page += 1

        '    End If

        'Next
        '    For Each Ctrl In Me.Controls

        '        'Form안의 Control 중Type이 Panel 일 때
        '        If Ctrl.GetType() Is GetType(Panel) Then

        '            'Panel 안의 Control 중
        '            For Each a In Ctrl.Controls

        '                'Control Type이 Label 일 때
        '                If a.GetType() Is GetType(Label) Then

        '                    For i As Integer = 0 To Table.Rows.Count - 1

        '                        If a.tag = Table.Rows(i)(0).ToString Then

        '                            a.text = Table.Rows(i)(1).ToString
        '                            Exit For

        '                        End If
        '                    Next


        '                ElseIf a.GetType() Is GetType(RadioButton) Then

        '                    For i As Integer = 0 To Table.Rows.Count - 1

        '                        If Ctrl.Tag = Table.Rows(i)(0).ToString Then
        '                            Dim k As Integer
        '                            k = a.Tag
        '                            a.text = Table.Rows(i)(k + 1).ToString()
        '                            Exit For

        '                        End If
        '                    Next
        '                End If
        '            Next
        '        End If
        '    Next

        '    '질문 내용이 있는 Panel만 표시해주기
        '    For Each Panel In Me.Controls

        '        If Panel.GetType() Is GetType(Panel) Then

        '            For Each Label In Panel.Controls

        '                If Not Label.Tag = "" Then

        '                    '질문내용이 없으면 해당 Panel은 보이지 않게
        '                    If Label.Text = "" Then

        '                        Panel.Visible = False
        '                        '질문내용이 있으면 해당 Panel은 보이게
        '                    ElseIf Label.Text <> "" Then

        '                        Panel.Visible = True

        '                    End If
        '                End If
        '            Next
        '        End If
        '    Next
    End Sub



    'Private Sub btEdit_Click(sender As Object, e As EventArgs)

    '    Dim Edit_Survey As New Edit_Survey

    '    Edit_Survey.lbName.Text = lbName.Text



    '    Dim ListQ As New List(Of String)()
    '    Dim Count As Integer = 0

    '    'Survey 설문내용 가져오기
    '    For Each Ctrl In Me.Controls

    '        If Ctrl.GetType() Is GetType(Panel) Then

    '            For Each a In Ctrl.controls

    '                If a.GetType() Is GetType(Label) Then

    '                    If Not a.tag = "" Then

    '                        ListQ.Add(a.text)

    '                    End If


    '                    'Survey Form의 질문내용에 맞게 Edit Form으로 가져오는 부분
    '                    'If a.Text = "" Then

    '                    '    For Each Edit_Survey In Edit_Survey.Controls

    '                    '        If Edit_Survey.GetType() Is GetType(Button) Then

    '                    '            If a.Tag = Edit_Survey.Tag Then



    '                    '            End If

    '                    '        End If

    '                    '    Next
    '                    'End If

    '                End If

    '            Next

    '        End If

    '    Next

    '    'Edit_Survey Form에 뿌리기
    '    For Each Edit_Ctrl In Edit_Survey.Controls

    '        If Edit_Ctrl.GetType() Is GetType(TextBox) Then

    '            If Not Edit_Ctrl.tag = "" Then

    '                Edit_Ctrl.text = ListQ(Count)
    '                Count += 1

    '            End If

    '        End If

    '    Next

    '    Count = 0

    '    For Each Edit_Ctrl In Edit_Survey.Controls

    '        If Edit_Ctrl.GetType() Is GetType(Panel) Then 'Survey Form의 Panel

    '            For Each Edit_Radio In Edit_Ctrl.Controls

    '                If Edit_Radio.GetType() Is GetType(RadioButton) Then 'Survey Form의 RadioButton

    '                    For Each Survey_Ctrl In Me.Controls

    '                        If Survey_Ctrl.GetType() Is GetType(Panel) Then 'Edit_Survey Form의 Panel

    '                            If Edit_Ctrl.Tag = Survey_Ctrl.Tag Then

    '                                For Each Survey_Radio In Survey_Ctrl.Controls

    '                                    If Survey_Radio.GetType() Is GetType(RadioButton) Then 'Survey Form의 Radiobutton

    '                                        If Edit_Radio.Tag = Survey_Radio.Tag Then

    '                                            Edit_Radio.Text = Survey_Radio.Text
    '                                            Exit For

    '                                        End If
    '                                    End If
    '                                Next

    '                                Exit For

    '                            End If
    '                        End If
    '                    Next
    '                End If
    '            Next
    '        End If
    '    Next

    '    Edit_Survey.ShowDialog()

    '    'Edit_Survey Form 설정 후
    '    If Edit_Survey.chkOK = True Then
    '        Survey_Refresh()
    '    End If

    '    ''질문내용 없는 Label 보이지 않도록 수정
    '    'For Each Edit_Ctrl In Edit_Survey.Controls

    '    '    If Edit_Ctrl.GetType() Is GetType(TextBox) Then

    '    '        If Not Edit_Ctrl.Text = "" Then

    '    '            For Each Ctrl In Me.Controls

    '    '                If Ctrl.GetType() Is GetType(Panel) Then

    '    '                    If Ctrl.Tag = Edit_Ctrl.Tag Then

    '    '                        Ctrl.Visible = True

    '    '                    End If

    '    '                End If
    '    '            Next

    '    '        ElseIf Edit_Ctrl.Text = "" Then

    '    '            For Each Ctrl In Me.Controls

    '    '                If Ctrl.GetType() Is GetType(Panel) Then

    '    '                    If Ctrl.Tag = Edit_Ctrl.Tag Then

    '    '                        Ctrl.Visible = False

    '    '                    End If

    '    '                End If

    '    '            Next
    '    '        End If
    '    '    End If
    '    'Next


    'End Sub

    'Private Sub btSubmit_Click(sender As Object, e As EventArgs)

    '    Dim Check_Survey As Boolean = False
    '    Dim SQL As String = Nothing

    '    Dim Result_Question As New List(Of String)()
    '    Dim Result_DesQuestion As New List(Of String)()

    '    '체크 된 Radio Button Data 담는 부분
    '    For Each Ctrl In Me.Controls
    '        'Panel Control
    '        If Ctrl.GetType() Is GetType(Panel) Then

    '            '질문내용이 있는 패널만
    '            If Ctrl.Visible = True Then

    '                For Each a In Ctrl.Controls
    '                    'RadioButton Control
    '                    If a.GetType() Is GetType(RadioButton) Then
    '                        If a.Checked = True Then

    '                            Check_Survey = True
    '                            Result_Question.Add(a.Tag)
    '                            Exit For

    '                        End If
    '                    End If

    '                Next
    '                If Check_Survey = False Then
    '                    MsgBox("질문에 응하지 않은 항목이 있습니다. 확인 후 재시도 해주세요")
    '                    Exit Sub
    '                End If

    '            ElseIf Ctrl.Visible = False Then

    '                Result_Question.Add("0")

    '            End If
    '        End If
    '        Check_Survey = False
    '    Next


    '    '추가내용 Text Data 담는 부분
    '    For Each Ctrl In Me.Controls
    '        'Panel Control
    '        If Ctrl.GetType() Is GetType(Panel) Then
    '            For Each a In Ctrl.Controls
    '                'Text Box Control
    '                If a.GetType() Is GetType(TextBox) Then

    '                    Result_DesQuestion.Add(a.Text)
    '                    Exit For

    '                End If
    '            Next
    '        End If
    '    Next

    '    'DB Query문 작성
    '    SQL = "INSERT INTO Survey_Result (업체명"

    '    For i As Integer = 1 To Result_Question.Count
    '        SQL = SQL & ", Q" & i & ", Q" & i & "_Description"
    '    Next

    '    SQL = SQL & ", Opinion) "

    '    SQL = SQL & "VALUES ('" & lbCompName.Text
    '    For i As Integer = 1 To Result_Question.Count
    '        SQL = SQL & "', '" & Result_Question(Result_Question.Count - i) & "', '" & Replace(Result_DesQuestion(Result_DesQuestion.Count - i), "'", "''")
    '    Next

    '    SQL = SQL & "', '" & Replace(txtOpinion.Text, "'", "''") & "');"

    '    'DB 연결
    '    AvConn = New OleDbConnection(vCon_Local)
    '    Dim cmd As OleDbCommand = New OleDbCommand(SQL, vConn)
    '    'Query문 적용
    '    DA = New OleDbDataAdapter(cmd)
    '    DA.Fill(DS)


    '    Dim SQL_Participant As String = Nothing
    '    Dim Cmd_Participant As New OleDbCommand

    '    If MsgBox("평가가 완료되었습니다.", vbOKOnly) = vbOK Then

    '        'Query문 작성
    '        SQL_Participant = "INSERT INTO Survey_Participant (참여자) VALUES ('" & lbName.Text & "');"

    '        'QUery문 DB에 적용
    '        Cmd_Participant = New OleDbCommand(SQL_Participant, vConn)
    '        DA = New OleDbDataAdapter(Cmd_Participant)
    '        DA.Fill(DS)

    '        Me.Close()

    '    End If





    'End Sub

    '########################## 다음 Page ##########################
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Next1.Click, Next2.Click, Next3.Click, Next4.Click,
                                                                        Next5.Click, Next6.Click, Next7.Click, Next8.Click, Next9.Click



        '질문사항 선택하지 않았을 때 다음 Page 접근하지 못하도록 하는 부분

        Dim chklist As New List(Of String)
        Dim chkpnl As New List(Of String)

        For Each Ctrl In ActiveControl.Parent.Controls

            If Ctrl.GetType() Is GetType(Panel) And Ctrl.Tag <> "age" And Ctrl.Tag <> "fm" Then

                '질문 갯수 확인(Visible 되어 있는 Panel 확인)
                If Ctrl.Visible = True Then

                    chkpnl.Add(Ctrl.Name)

                End If

                For Each radio In Ctrl.Controls

                    If radio.GetType() Is GetType(RadioButton) Then

                        If radio.Checked = True Then

                            chklist.Add(radio.Tag)

                        End If
                    End If
                Next
            End If
        Next

        Dim chkage As Boolean = False
        Dim chkfm As Boolean = False

        '성별 체크 확인
        For Each radio In fmPanel.Controls

            If radio.GetType() Is GetType(RadioButton) Then

                If radio.Checked = True Then

                    Survey_Fm = radio.Text
                    chkfm = True
                    Exit For

                End If
            End If
        Next

        '연령대 체크 확인
        For Each radio In agePanel.Controls

            If radio.GetType() Is GetType(RadioButton) Then

                If radio.Checked = True Then

                    Survey_Age = radio.Tag
                    chkage = True
                    Exit For

                End If
            End If
        Next

        If DirectCast(sender, Control).Name = "Next1" Then

            If chkpnl.Count <> chklist.Count Then
                MsgBox("선택하지 않은 질문이 있습니다. 선택 후 재시도 해주세요") : Exit Sub

            Else

                If chkfm = False Then
                    MsgBox("성별을 선택해주세요") : Exit Sub
                ElseIf chkage = False Then
                    MsgBox("연령대를 선택해주세요") : Exit Sub
                Else

                    '해당 페이지 체크항목 확인 초기화
                    chklist.Clear()
                    chkpnl.Clear()

                End If

            End If

        Else

            '성별 입력페이지 제외한 나머지 페이지관련
            If chkpnl.Count <> chklist.Count Then

                MsgBox("선택하지 않은 질문이 있습니다. 선택 후 재시도 해주세요") : Exit Sub

            Else

                chklist.Clear()
                chkpnl.Clear()

            End If

        End If

        cnt += 1
        Dim tabIndex As Integer
        tabIndex = Question.SelectedIndex

        For i As Integer = 0 To Question.TabCount - 1

            If tabIndex = i And tabIndex <> Question.TabCount - 1 Then

                Question.SelectTab(i + 1)
                Exit For

            End If

        Next

        '################### Page 표시 ###################
        For Each tCont In Me.Controls

            If tCont.GetType() Is GetType(TabControl) Then

                For Each tPage In tCont.Controls

                    If tPage.GetType() Is GetType(TabPage) Then

                        For Each lb In tPage.Controls

                            If lb.GetType() Is GetType(Label) And lb.Tag = "page" Then

                                lb.Text = cnt & " / " & Question.TabCount - cnt_page

                            End If

                        Next

                    End If

                Next

            End If

        Next
        '#################################################

        'If DirectCast(sender, Control).Name = "txtModel_FUT" Then   ' 만약 Event를 Click 한 Handler가 FUT라면
        '    If InStr(Me.txtModel_FUT.Text, "ex") > 0 Then
        '        Me.txtModel_FUT.Text = ""
        '        Me.txtModel_FUT.ForeColor = Color.Black
        '    End If
        'Else
        '    If InStr(Me.txtModel.Text, "ex") > 0 Then
        '        Me.txtModel.Text = ""
        '        Me.txtModel.ForeColor = Color.Black
        '    End If
        'End If
    End Sub

    '########################## 이전 Page ##########################
    Private Sub Prev1_Click(sender As Object, e As EventArgs) Handles Prev1.Click, Prev2.Click, Prev3.Click, Prev4.Click,
                                                                      Prev5.Click, Prev6.Click, Prev7.Click, Prev8.Click, Prev9.Click

        cnt -= 1
        Dim tabIndex As Integer
        tabIndex = Question.SelectedIndex

        For i As Integer = 0 To Question.TabCount - 1

            If tabIndex = i And tabIndex <> 0 Then

                Question.SelectTab(i - 1)
                Exit For

            End If

        Next

        For Each tCont In Me.Controls

            If tCont.GetType() Is GetType(TabControl) Then

                For Each tPage In tCont.Controls

                    If tPage.GetType() Is GetType(TabPage) Then

                        For Each lb In tPage.Controls

                            If lb.GetType() Is GetType(Label) And lb.Tag = "page" Then

                                lb.Text = cnt & " / " & Question.TabCount - cnt_page

                            End If

                        Next

                    End If

                Next

            End If

        Next
    End Sub

    Public Sub btEdit1_Click(sender As Object, e As EventArgs) Handles btEdit1.Click, btEdit2.Click, btEdit3.Click, btEdit4.Click,
                                                                        btEdit5.Click, btEdit6.Click, btEdit7.Click, btEdit8.Click


        Dim Edit_Survey As New Edit_Survey

        If MsgBox("설문지를 새로 작성하시겠습니까?", vbYesNo) = vbYes Then


            Survey_Title = InputBox("새로운 설문의 Title을 입력하세요")

            If Survey_Title = "" Then

                Exit Sub

            Else
                Edit_Survey.nameSurvey.Text = Survey_Title
                Edit_Survey.ShowDialog()

                '새로운 설문 작성 Title 가져오는 부분
                If Edit_Survey.nameSurvey.Text <> "" Then

                    nameSurvey.Text = Edit_Survey.nameSurvey.Text

                End If

                Survey_Refresh()


                'Edit_Survey(설문지 수정) 에서 질문에 맞는 RadioButton 갯수 Survey에 적용
                For i As Integer = 0 To Edit_Survey.hide_Radio.Count - 1

                    For Each tCont In Me.Controls

                        If tCont.GetType() Is GetType(TabControl) Then

                            For Each tPage In tCont.Controls

                                If tPage.GetType() Is GetType(TabPage) Then

                                    For Each pnl In tPage.Controls

                                        If pnl.GetType() Is GetType(Panel) Then

                                            For Each radio In pnl.Controls

                                                If radio.GetType() Is GetType(RadioButton) Then

                                                    If radio.Tag = Edit_Survey.hide_Radio(i) And pnl.Tag = Edit_Survey.hide_Q(i) Then

                                                        radio.Visible = False

                                                    End If
                                                End If
                                            Next
                                        End If
                                    Next
                                End If
                            Next
                        End If
                    Next
                Next
            End If

        Else

            Exit Sub

        End If



    End Sub

    Private Sub btSubmit1_Click(sender As Object, e As EventArgs) Handles btSubmit1.Click, btSubmit2.Click

        Dim chkradio As Boolean = False

        Dim Result_QuestionNum As New List(Of String)
        Dim Result_Question As New List(Of String)
        Dim Result_QuestionDes As New List(Of String)

        '종합 결과 확인
        For Each Ctrl In Me.Controls

            If Ctrl.GetType() Is GetType(TabControl) Then

                For Each tPage In Ctrl.Controls

                    If tPage.GetType() Is GetType(TabPage) Then

                        For Each pnl In tPage.controls

                            If pnl.GetType() Is GetType(Panel) And pnl.Tag <> "age" And pnl.Tag <> "fm" Then

                                Result_QuestionNum.Add(pnl.Tag)

                                For Each radio In pnl.Controls

                                    If radio.GetType() Is GetType(RadioButton) Then

                                        If radio.Checked = True Then

                                            chkradio = True
                                            Result_Question.Add(radio.Tag)

                                        End If

                                    ElseIf radio.GetType() Is GetType(TextBox) Then

                                        Result_QuestionDes.Add(radio.Text)

                                    End If

                                Next

                                If chkradio = False Then

                                    Result_Question.Add("0")

                                End If

                                chkradio = False

                            End If
                        Next
                    End If
                Next
            End If
        Next

        '================== SQL Query 문 작성 부분 ==================


        '질문내용 담기
        Dim table As DataTable = DS.Tables("Survey")

        Dim SQL As String = "INSERT INTO Survey_Result (타이틀, 업체명, 성별, 연령대, Group1, Group2, Group3, Group4, 질문"


        For i As Integer = 0 To table.Rows.Count - 1
            If i <> table.Rows.Count - 1 Then
                SQL = SQL & i + 1 & ", 질문"

            Else
                SQL = SQL & i + 1 & ", "
            End If
        Next

        For i As Integer = 0 To Result_QuestionNum.Count - 1

            If i < Result_Question.Count - 1 Then

                SQL = SQL & "Q" & Result_QuestionNum(i) & ", Q" & Result_QuestionNum(i) & "_Description, "

            Else

                SQL = SQL & "Q" & Result_QuestionNum(i) & ", Q" & Result_QuestionNum(i) & "_Description) "
            End If

        Next

        SQL = SQL & "VALUES ('" & nameSurvey.Text & "', '" & lbCompName.Text & "', '" & Survey_Fm & "', '" & Survey_Age & "', '"

        For k As Integer = 0 To 23 Step 6

            SQL = SQL & table.Rows(k)(2).ToString & "', '"

        Next

        For x As Integer = 0 To table.Rows.Count - 1

            If x <> table.Rows.Count - 1 Then

                SQL = SQL & table.Rows(x)(3).ToString & "', '"

            Else

                SQL = SQL & table.Rows(x)(3).ToString & "', '"

            End If

        Next

        For i As Integer = 0 To Result_Question.Count - 1

            If i < Result_Question.Count - 1 Then

                SQL = SQL & Result_Question(i) & "', '" & Result_QuestionDes(i) & "', '"

            Else

                SQL = SQL & Result_Question(i) & "', '" & Result_QuestionDes(i) & "')"
            End If


        Next
        '================================================================

        'DB 연결
        vConn = New OleDbConnection(vCon_Local)
        Dim cmd As OleDbCommand = New OleDbCommand(SQL, vConn)
        'Query문 적용
        DA = New OleDbDataAdapter(cmd)
        DA.Fill(DS)


        Dim SQL_Participant As String = Nothing
        Dim Cmd_Participant As New OleDbCommand

        If MsgBox("평가가 완료되었습니다.", vbOKOnly) = vbOK Then

            'Query문 작성
            SQL_Participant = "INSERT INTO Survey_Participant (참여자) VALUES ('" & lbName.Text & "');"

            'QUery문 DB에 적용
            Cmd_Participant = New OleDbCommand(SQL_Participant, vConn)
            DA = New OleDbDataAdapter(Cmd_Participant)
            DA.Fill(DS)

            Me.Close()

        End If




        '    Dim SQL As String = Nothing

        '    Dim Result_Question As New List(Of String)()
        '    Dim Result_DesQuestion As New List(Of String)()

        '    '체크 된 Radio Button Data 담는 부분
        '    For Each Ctrl In Me.Controls
        '        'Panel Control
        '        If Ctrl.GetType() Is GetType(Panel) Then

        '            '질문내용이 있는 패널만
        '            If Ctrl.Visible = True Then

        '                For Each a In Ctrl.Controls
        '                    'RadioButton Control
        '                    If a.GetType() Is GetType(RadioButton) Then
        '                        If a.Checked = True Then

        '                            Check_Survey = True
        '                            Result_Question.Add(a.Tag)
        '                            Exit For

        '                        End If
        '                    End If

        '                Next
        '                If Check_Survey = False Then
        '                    MsgBox("질문에 응하지 않은 항목이 있습니다. 확인 후 재시도 해주세요")
        '                    Exit Sub
        '                End If

        '            ElseIf Ctrl.Visible = False Then

        '                Result_Question.Add("0")

        '            End If
        '        End If
        '        Check_Survey = False
        '    Next


        '    '추가내용 Text Data 담는 부분
        '    For Each Ctrl In Me.Controls
        '        'Panel Control
        '        If Ctrl.GetType() Is GetType(Panel) Then
        '            For Each a In Ctrl.Controls
        '                'Text Box Control
        '                If a.GetType() Is GetType(TextBox) Then

        '                    Result_DesQuestion.Add(a.Text)
        '                    Exit For

        '                End If
        '            Next
        '        End If
        '    Next

        '    'DB Query문 작성
        '    SQL = "INSERT INTO Survey_Result (업체명"

        '    For i As Integer = 1 To Result_Question.Count
        '        SQL = SQL & ", Q" & i & ", Q" & i & "_Description"
        '    Next

        '    SQL = SQL & ", Opinion) "

        '    SQL = SQL & "VALUES ('" & lbCompName.Text
        '    For i As Integer = 1 To Result_Question.Count
        '        SQL = SQL & "', '" & Result_Question(Result_Question.Count - i) & "', '" & Replace(Result_DesQuestion(Result_DesQuestion.Count - i), "'", "''")
        '    Next

        '    SQL = SQL & "', '" & Replace(txtOpinion.Text, "'", "''") & "');"

        '    'DB 연결
        '    AvConn = New OleDbConnection(vCon_Local)
        '    Dim cmd As OleDbCommand = New OleDbCommand(SQL, vConn)
        '    'Query문 적용
        '    DA = New OleDbDataAdapter(cmd)
        '    DA.Fill(DS)


        '    Dim SQL_Participant As String = Nothing
        '    Dim Cmd_Participant As New OleDbCommand

        '    If MsgBox("평가가 완료되었습니다.", vbOKOnly) = vbOK Then

        '        'Query문 작성
        '        SQL_Participant = "INSERT INTO Survey_Participant (참여자) VALUES ('" & lbName.Text & "');"

        '        'QUery문 DB에 적용
        '        Cmd_Participant = New OleDbCommand(SQL_Participant, vConn)
        '        DA = New OleDbDataAdapter(Cmd_Participant)
        '        DA.Fill(DS)

        '        Me.Close()

        '    End If



    End Sub

End Class