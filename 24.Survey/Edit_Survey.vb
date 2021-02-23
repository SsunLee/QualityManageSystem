Imports System.Collections.Generic
Imports System.Data
Imports System.Data.OleDb
Imports System.Drawing
Imports System.Windows.Forms

Public Class Edit_Survey

    Public DS As DataSet = New DataSet
    Public DA As OleDbDataAdapter

    Private Survey As New Survey

    Public vCon_Local As String = Survey.vCon_Local
    Public vCon As String
    Public vConn As OleDbConnection

    Public Text_Radio As New List(Of String)()
    Public cnt As Integer = 1
    Public cnt_page As Integer = 2

    Public hide_Question As New List(Of String)

    Public hide_Q As New List(Of String)
    Public hide_Radio As New List(Of String)

    Public chkSubmit As Boolean = False

    Public chktxt As Boolean
    Public dbchk As Boolean
    Public chkOK As Boolean = False






    Public Sub Edit_Survey_Load(sender As Object, e As EventArgs) Handles Me.Load

        'Title 이름 관련부분(각 질문Page Title 이름 동일하게)
        For Each Ctrl In Me.Controls

            If Ctrl.GetType() Is GetType(TabControl) Then

                For Each tpage In Ctrl.Controls

                    If tpage.GetType() Is GetType(TabPage) Then

                        For Each title In tpage.Controls

                            If title.GetType() Is GetType(Label) Then

                                If InStr(title.Name, "nameSurvey") Then

                                    title.Text = nameSurvey.Text

                                End If
                            End If
                        Next
                    End If
                Next
            End If
        Next



        Dim Survey As New Survey

        chkSubmit = False


        lbName = Survey.lbName
        lbCompName = Survey.lbCompName

        chkOK = False

        Label4.Text = cnt & " / " & Question.TabCount - cnt_page

        Dim XML As New XML
        XML.vCon_Admin_Call(vCon)
        vConn = New OleDbConnection(vCon_Local)

        Dim SQL = "SELECT * FROM Survey ORDER BY [ID] ASC"

        Dim cmd As OleDbCommand = New OleDbCommand(SQL, vConn)
        DA = New OleDbDataAdapter(cmd)
        DA.Fill(DS, "Question")

        If DS.Tables("Question").Rows.Count = 0 Then

            dbchk = False

        Else

            dbchk = True

        End If

        'hide_Question 변수 초기화
        hide_Question.Clear()

        '################################ RdioButton, TextBox ################################

        ' RadioButton 이름 없애기
        For Each tCont In Me.Controls

            If tCont.GetType() Is GetType(TabControl) Then

                For Each tPage In tCont.Controls

                    If tPage.GetType() Is GetType(TabPage) Then

                        For Each pnl In tPage.Controls

                            If pnl.GetType() Is GetType(Panel) And pnl.Tag <> "Age" And pnl.Tag <> "Fm" Then

                                For Each rdo In pnl.Controls

                                    If rdo.GetType() Is GetType(RadioButton) Then

                                        rdo.Text = ""
                                        rdo.Enabled = False

                                    ElseIf rdo.GetType() Is GetType(TextBox) Then

                                        rdo.ForeColor = Color.Gray
                                        If rdo.tag = "title" Then
                                            rdo.Text = "제목을 입력해주세요."

                                        Else

                                            rdo.Text = "옵션" & rdo.Tag
                                        End If

                                    End If

                                Next

                            End If

                            If pnl.GetType() Is GetType(TextBox) And pnl.Tag = "group" Then
                                pnl.ForeColor = Color.Gray
                                pnl.Text = "그룹 제목을 입력해주세요"
                            End If
                        Next

                    End If

                Next

            End If

        Next
        '####################################################################################



    End Sub
    Private Sub btEdit_Click(sender As Object, e As EventArgs)


        '입력하지 않은 TextBox가 있을 경우
        For Each Textbox In Me.Controls

            If Textbox.GetType() Is GetType(TextBox) Then

                If Textbox.Visible = True And Textbox.Text = "" Then

                    MsgBox("입력하지 않은 항목이 있습니다. 입력 후 재시도 해주세요") : Exit Sub

                End If

            End If

        Next


        Dim ctrl As Control
        Dim Edit_Survey As New Edit_Survey
        Dim SQL As String
        Dim SQL_Select As String
        Dim cmd As OleDbCommand


        If MsgBox("위 내용으로 설정하시겟습니까?", vbYesNo) = vbNo Then
            chkOK = False
            Exit Sub
        Else
            chkOK = True
            SQL_Select = "UPDATE Survey Set "

            'DB에 Data가 있을 경우
            If dbchk = True Then

                For Each ctrl In Me.Controls

                    If (ctrl.GetType() Is GetType(TextBox)) Then

                        SQL = "UPDATE Survey SET Question = '" & Replace(ctrl.Text, "'", "''") & "' WHERE ID = " & ctrl.Tag
                        cmd = New OleDbCommand(SQL, vConn)
                        DA = New OleDbDataAdapter(cmd)
                        DA.Fill(DS)

                    ElseIf ctrl.GetType() Is GetType(Panel) Then

                        For Each a In ctrl.Controls

                            If a.GetType() Is GetType(RadioButton) Then

                                SQL_Select = SQL_Select & "Select" & a.Tag & " = '" & a.text & "', "

                            End If

                        Next

                        SQL_Select = Strings.Left(SQL_Select, SQL_Select.Length - 3) & "' WHERE ID = " & ctrl.Tag
                        cmd = New OleDbCommand(SQL_Select, vConn)
                        DA = New OleDbDataAdapter(cmd)
                        DA.Fill(DS)

                        SQL_Select = "UPDATE Survey Set "


                    End If

                Next

                'DB에 Data가 없을 경우
            ElseIf dbchk = False Then

                For Each ctrl In Me.Controls

                    If (ctrl.GetType() Is GetType(TextBox)) Then

                        SQL = "INSERT INTO Survey (ID, Question) Values ('" & ctrl.Tag & "', '" & Replace(ctrl.Text, "'", "''") & "');"
                        cmd = New OleDbCommand(SQL, vConn)
                        DA = New OleDbDataAdapter(cmd)
                        DA.Fill(DS, "Survey")

                    End If

                Next

            End If

            Me.Close()

        End If

    End Sub

    '##############################구분1 질문 추가/삭제 부분##############################
    'Private Sub btAdd1_Click(sender As Object, e As EventArgs)

    '    If btDel1_5.Visible = True Then
    '        MsgBox("더이상 질문을 추가 할 수 없습니다.(최대5개)")
    '        Exit Sub
    '    End If

    '    If lbDiv1_2.Visible = False Then

    '        lbDiv1_2.Visible = True
    '        Panel2.Visible = True
    '        txtQ2.Visible = True
    '        btDel1_2.Visible = True
    '        Exit Sub
    '    End If

    '    If lbDiv1_3.Visible = False And btDel1_2.Visible = True Then

    '        lbDiv1_3.Visible = True
    '        Panel3.Visible = True
    '        txtQ3.Visible = True
    '        btDel1_3.Visible = True

    '        btDel1_2.Visible = False

    '        Exit Sub
    '    End If

    '    If lbDiv1_4.Visible = False And btDel1_3.Visible = True Then

    '        lbDiv1_4.Visible = True
    '        Panel4.Visible = True
    '        txtQ4.Visible = True
    '        btDel1_4.Visible = True

    '        btDel1_3.Visible = False
    '        Exit Sub
    '    End If

    '    If lbDiv1_5.Visible = False And btDel1_4.Visible = True Then

    '        lbDiv1_5.Visible = True
    '        Panel5.Visible = True
    '        txtQ5.Visible = True
    '        btDel1_5.Visible = True

    '        btDel1_4.Visible = False
    '        Exit Sub
    '    End If

    'End Sub

    'Private Sub btDel1_5_Click(sender As Object, e As EventArgs)
    '    lbDiv1_5.Visible = False
    '    Panel5.Visible = False
    '    txtQ5.Visible = False
    '    txtQ5.Text = ""

    '    btDel1_5.Visible = False
    '    btDel1_4.Visible = True
    'End Sub

    'Private Sub btDel1_4_Click(sender As Object, e As EventArgs)
    '    lbDiv1_4.Visible = False
    '    Panel4.Visible = False
    '    txtQ4.Visible = False
    '    txtQ4.Text = ""

    '    btDel1_4.Visible = False
    '    btDel1_3.Visible = True
    'End Sub

    'Private Sub btDel1_3_Click(sender As Object, e As EventArgs)
    '    lbDiv1_3.Visible = False
    '    Panel3.Visible = False
    '    txtQ3.Visible = False
    '    txtQ3.Text = ""

    '    btDel1_3.Visible = False
    '    btDel1_2.Visible = True
    'End Sub

    'Private Sub btDel1_2_Click(sender As Object, e As EventArgs)
    '    lbDiv1_2.Visible = False
    '    Panel2.Visible = False
    '    txtQ2.Visible = False
    '    txtQ2.Text = ""

    '    btDel1_2.Visible = False
    'End Sub
    ''#####################################################################################


    ''##############################구분2 질문 추가/삭제 부분##############################
    'Private Sub Button1_Click(sender As Object, e As EventArgs)
    '    If btDel2_5.Visible = True Then
    '        MsgBox("더이상 질문을 추가 할 수 없습니다.(최대5개)")
    '        Exit Sub
    '    End If

    '    If lbDiv2_2.Visible = False Then

    '        lbDiv2_2.Visible = True
    '        Panel7.Visible = True
    '        txtQ7.Visible = True
    '        btDel2_2.Visible = True
    '        Exit Sub
    '    End If

    '    If lbDiv2_3.Visible = False And btDel2_2.Visible = True Then

    '        lbDiv2_3.Visible = True
    '        Panel8.Visible = True
    '        txtQ8.Visible = True
    '        btDel2_3.Visible = True

    '        btDel2_2.Visible = False

    '        Exit Sub
    '    End If

    '    If lbDiv2_4.Visible = False And btDel2_3.Visible = True Then

    '        lbDiv2_4.Visible = True
    '        Panel9.Visible = True
    '        txtQ9.Visible = True
    '        btDel2_4.Visible = True

    '        btDel2_3.Visible = False
    '        Exit Sub
    '    End If

    '    If lbDiv2_5.Visible = False And btDel2_4.Visible = True Then

    '        lbDiv2_5.Visible = True
    '        Panel10.Visible = True
    '        txtQ10.Visible = True
    '        btDel2_5.Visible = True

    '        btDel2_4.Visible = False
    '        Exit Sub
    '    End If
    'End Sub


    'Private Sub btDel2_5_Click(sender As Object, e As EventArgs)
    '    lbDiv2_5.Visible = False
    '    Panel10.Visible = False
    '    txtQ10.Visible = False
    '    txtQ10.Text = ""

    '    btDel2_5.Visible = False
    '    btDel2_4.Visible = True
    'End Sub

    'Private Sub btDel2_4_Click(sender As Object, e As EventArgs)
    '    lbDiv2_4.Visible = False
    '    Panel9.Visible = False
    '    txtQ9.Visible = False
    '    txtQ9.Text = ""

    '    btDel2_4.Visible = False
    '    btDel2_3.Visible = True
    'End Sub

    'Private Sub btDel2_3_Click(sender As Object, e As EventArgs)
    '    lbDiv2_3.Visible = False
    '    Panel8.Visible = False
    '    txtQ8.Visible = False
    '    txtQ8.Text = ""

    '    btDel2_3.Visible = False
    '    btDel2_2.Visible = True
    'End Sub
    'Private Sub btDel2_2_Click(sender As Object, e As EventArgs)
    '    lbDiv2_2.Visible = False
    '    Panel7.Visible = False
    '    txtQ7.Visible = False
    '    txtQ7.Text = ""

    '    btDel2_2.Visible = False

    'End Sub
    ''#####################################################################################

    ''##############################구분3 질문 추가/삭제 부분##############################
    'Private Sub btAdd3_Click(sender As Object, e As EventArgs)
    '    If btDel3_5.Visible = True Then
    '        MsgBox("더이상 질문을 추가 할 수 없습니다.(최대5개)")
    '        Exit Sub
    '    End If

    '    If lbDiv3_2.Visible = False Then

    '        lbDiv3_2.Visible = True
    '        Panel12.Visible = True
    '        txtQ12.Visible = True
    '        btDel3_2.Visible = True
    '        Exit Sub
    '    End If

    '    If lbDiv3_3.Visible = False And btDel3_2.Visible = True Then

    '        lbDiv3_3.Visible = True
    '        Panel13.Visible = True
    '        txtQ13.Visible = True
    '        btDel3_3.Visible = True

    '        btDel3_2.Visible = False

    '        Exit Sub
    '    End If

    '    If lbDiv3_4.Visible = False And btDel3_3.Visible = True Then

    '        lbDiv3_4.Visible = True
    '        Panel14.Visible = True
    '        txtQ14.Visible = True
    '        btDel3_4.Visible = True

    '        btDel3_3.Visible = False
    '        Exit Sub
    '    End If

    '    If lbDiv3_5.Visible = False And btDel3_4.Visible = True Then

    '        lbDiv3_5.Visible = True
    '        Panel15.Visible = True
    '        txtQ15.Visible = True
    '        btDel3_5.Visible = True

    '        btDel3_4.Visible = False
    '        Exit Sub
    '    End If
    'End Sub

    'Private Sub btDel3_5_Click(sender As Object, e As EventArgs)
    '    lbDiv3_5.Visible = False
    '    Panel15.Visible = False
    '    txtQ15.Visible = False
    '    txtQ15.Text = ""

    '    btDel3_5.Visible = False
    '    btDel3_4.Visible = True
    'End Sub

    'Private Sub bt_Click(sender As Object, e As EventArgs)
    '    lbDiv3_4.Visible = False
    '    Panel14.Visible = False
    '    txtQ14.Visible = False
    '    txtQ14.Text = ""

    '    btDel3_4.Visible = False
    '    btDel3_3.Visible = True
    'End Sub

    'Private Sub btDel3_3_Click(sender As Object, e As EventArgs)
    '    lbDiv3_3.Visible = False
    '    Panel13.Visible = False
    '    txtQ13.Visible = False
    '    txtQ13.Text = ""

    '    btDel3_3.Visible = False
    '    btDel3_2.Visible = True
    'End Sub

    'Private Sub btDel3_2_Click(sender As Object, e As EventArgs)
    '    lbDiv3_2.Visible = False
    '    Panel12.Visible = False
    '    txtQ12.Visible = False
    '    txtQ12.Text = ""

    '    btDel3_2.Visible = False
    'End Sub
    ''#####################################################################################


    ''##############################구분4 질문 추가/삭제 부분##############################
    'Private Sub btAdd4_Click(sender As Object, e As EventArgs)

    '    If btDel4_5.Visible = True Then
    '        MsgBox("더이상 질문을 추가 할 수 없습니다.(최대5개)")
    '        Exit Sub
    '    End If

    '    If lbDiv4_2.Visible = False Then

    '        lbDiv4_2.Visible = True
    '        Panel17.Visible = True
    '        txtQ17.Visible = True
    '        btDel4_2.Visible = True
    '        Exit Sub
    '    End If

    '    If lbDiv4_3.Visible = False And btDel4_2.Visible = True Then

    '        lbDiv4_3.Visible = True
    '        Panel18.Visible = True
    '        txtQ18.Visible = True
    '        btDel4_3.Visible = True

    '        btDel4_2.Visible = False

    '        Exit Sub
    '    End If

    '    If lbDiv4_4.Visible = False And btDel4_3.Visible = True Then

    '        lbDiv4_4.Visible = True
    '        Panel19.Visible = True
    '        txtQ19.Visible = True
    '        btDel4_4.Visible = True

    '        btDel4_3.Visible = False
    '        Exit Sub
    '    End If

    '    If lbDiv4_5.Visible = False And btDel4_4.Visible = True Then

    '        lbDiv4_5.Visible = True
    '        Panel20.Visible = True
    '        txtQ20.Visible = True
    '        btDel4_5.Visible = True

    '        btDel4_4.Visible = False
    '        Exit Sub
    '    End If


    'End Sub

    'Private Sub btDel4_5_Click(sender As Object, e As EventArgs)
    '    lbDiv4_5.Visible = False
    '    Panel20.Visible = False
    '    txtQ20.Visible = False
    '    txtQ20.Text = ""

    '    btDel4_5.Visible = False
    '    btDel4_4.Visible = True
    'End Sub

    'Private Sub btDel4_4_Click(sender As Object, e As EventArgs)
    '    lbDiv4_4.Visible = False
    '    Panel19.Visible = False
    '    txtQ19.Visible = False
    '    txtQ19.Text = ""

    '    btDel4_4.Visible = False
    '    btDel4_3.Visible = True
    'End Sub

    'Private Sub btDel4_3_Click(sender As Object, e As EventArgs)
    '    lbDiv4_3.Visible = False
    '    Panel18.Visible = False
    '    txtQ18.Visible = False
    '    txtQ18.Text = ""

    '    btDel4_3.Visible = False
    '    btDel4_2.Visible = True
    'End Sub

    'Private Sub btDel4_2_Click(sender As Object, e As EventArgs)
    '    lbDiv4_2.Visible = False
    '    Panel17.Visible = False
    '    txtQ17.Visible = False
    '    txtQ17.Text = ""

    '    btDel4_2.Visible = False
    'End Sub

    '다음 버튼 누를 때
    Private Sub Next1_Click(sender As Object, e As EventArgs) Handles Next9.Click, Next8.Click, Next7.Click, Next6.Click, Next5.Click, Next4.Click, Next3.Click, Next2.Click, Next1.Click


        cnt += 1
        Dim tabIndex As Integer
        tabIndex = Question.SelectedIndex

        For i As Integer = 0 To Question.TabCount - 1

            If tabIndex = i And tabIndex <> Question.TabCount - 1 Then

                Question.SelectTab(i + 1)
                Exit For

            End If

        Next

        'Page 표시
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

    '이전 버튼 누를 때
    Private Sub Prev1_Click(sender As Object, e As EventArgs) Handles Prev8.Click, Prev9.Click, Prev7.Click, Prev6.Click, Prev5.Click, Prev4.Click, Prev3.Click, Prev2.Click, Prev1.Click

        cnt -= 1
        Dim tabIndex As Integer
        tabIndex = Question.SelectedIndex

        For i As Integer = 0 To Question.TabCount - 1

            If tabIndex = i And tabIndex <> 0 Then

                Question.SelectTab(i - 1)
                Exit For

            End If

        Next

        'Page 표시
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


    Private Sub txtTitle1_GotFocus(sender As Object, e As EventArgs) Handles txtTitle1.GotFocus, txtTitle2.GotFocus, txtTitle3.GotFocus, txtTitle4.GotFocus, txtTitle5.GotFocus,
                                                                             txtTitle6.GotFocus, txtTitle7.GotFocus, txtTitle8.GotFocus, txtTitle9.GotFocus, txtTitle10.GotFocus,
                                                                             txtTitle11.GotFocus, txtTitle12.GotFocus, txtTitle13.GotFocus, txtTitle14.GotFocus, txtTitle15.GotFocus,
                                                                             txtTitle16.GotFocus, txtTitle17.GotFocus, txtTitle18.GotFocus, txtTitle19.GotFocus, txtTitle20.GotFocus,
                                                                             txtTitle21.GotFocus, txtTitle22.GotFocus, txtTitle23.GotFocus, txtTitle24.GotFocus, txtTitle25.GotFocus,
                                                                             txtOption1_1.GotFocus, txtOption1_2.GotFocus, txtOption1_3.GotFocus, txtOption1_4.GotFocus, txtOption1_5.GotFocus,
                                                                             txtOption2_1.GotFocus, txtOption2_2.GotFocus, txtOption2_3.GotFocus, txtOption2_4.GotFocus, txtOption2_5.GotFocus,
                                                                             txtOption3_1.GotFocus, txtOption3_2.GotFocus, txtOption3_3.GotFocus, txtOption3_4.GotFocus, txtOption3_5.GotFocus,
                                                                             txtOption4_1.GotFocus, txtOption4_2.GotFocus, txtOption4_3.GotFocus, txtOption4_4.GotFocus, txtOption4_5.GotFocus,
                                                                             txtOption5_1.GotFocus, txtOption5_2.GotFocus, txtOption5_3.GotFocus, txtOption5_4.GotFocus, txtOption5_5.GotFocus,
                                                                             txtOption6_1.GotFocus, txtOption6_2.GotFocus, txtOption6_3.GotFocus, txtOption6_4.GotFocus, txtOption6_5.GotFocus,
                                                                             txtOption7_1.GotFocus, txtOption7_2.GotFocus, txtOption7_3.GotFocus, txtOption7_4.GotFocus, txtOption7_5.GotFocus,
                                                                             txtOption8_1.GotFocus, txtOption8_2.GotFocus, txtOption8_3.GotFocus, txtOption8_4.GotFocus, txtOption8_5.GotFocus,
                                                                             txtOption9_1.GotFocus, txtOption9_2.GotFocus, txtOption9_3.GotFocus, txtOption9_4.GotFocus, txtOption9_5.GotFocus,
                                                                             txtOption10_1.GotFocus, txtOption10_2.GotFocus, txtOption10_3.GotFocus, txtOption10_4.GotFocus, txtOption10_5.GotFocus,
                                                                             txtOption11_1.GotFocus, txtOption11_2.GotFocus, txtOption11_3.GotFocus, txtOption11_4.GotFocus, txtOption11_5.GotFocus,
                                                                             txtOption12_1.GotFocus, txtOption12_2.GotFocus, txtOption12_3.GotFocus, txtOption12_4.GotFocus, txtOption12_5.GotFocus,
                                                                             txtOption13_1.GotFocus, txtOption13_2.GotFocus, txtOption13_3.GotFocus, txtOption13_4.GotFocus, txtOption13_5.GotFocus,
                                                                             txtOption14_1.GotFocus, txtOption14_2.GotFocus, txtOption14_3.GotFocus, txtOption14_4.GotFocus, txtOption14_5.GotFocus,
                                                                             txtOption15_1.GotFocus, txtOption15_2.GotFocus, txtOption15_3.GotFocus, txtOption15_4.GotFocus, txtOption15_5.GotFocus,
                                                                             txtOption16_1.GotFocus, txtOption16_2.GotFocus, txtOption16_3.GotFocus, txtOption16_4.GotFocus, txtOption16_5.GotFocus,
                                                                             txtOption17_1.GotFocus, txtOption17_2.GotFocus, txtOption17_3.GotFocus, txtOption17_4.GotFocus, txtOption17_5.GotFocus,
                                                                             txtOption18_1.GotFocus, txtOption18_2.GotFocus, txtOption18_3.GotFocus, txtOption18_4.GotFocus, txtOption18_5.GotFocus,
                                                                             txtOption19_1.GotFocus, txtOption19_2.GotFocus, txtOption19_3.GotFocus, txtOption19_4.GotFocus, txtOption19_5.GotFocus,
                                                                             txtOption20_1.GotFocus, txtOption20_2.GotFocus, txtOption20_3.GotFocus, txtOption20_4.GotFocus, txtOption20_5.GotFocus,
                                                                             txtOption21_1.GotFocus, txtOption21_2.GotFocus, txtOption21_3.GotFocus, txtOption21_4.GotFocus, txtOption21_5.GotFocus,
                                                                             txtOption22_1.GotFocus, txtOption22_2.GotFocus, txtOption22_3.GotFocus, txtOption22_4.GotFocus, txtOption22_5.GotFocus,
                                                                             txtOption23_1.GotFocus, txtOption23_2.GotFocus, txtOption23_3.GotFocus, txtOption23_4.GotFocus, txtOption23_5.GotFocus,
                                                                             txtOption24_1.GotFocus, txtOption24_2.GotFocus, txtOption24_3.GotFocus, txtOption24_4.GotFocus, txtOption24_5.GotFocus,
                                                                             txtOption25_1.GotFocus, txtOption25_2.GotFocus, txtOption25_3.GotFocus, txtOption25_4.GotFocus, txtOption25_5.GotFocus,
                                                                             txtGroup1.GotFocus, txtGroup2.GotFocus, txtGroup3.GotFocus, txtGroup4.GotFocus, txtGroup5.GotFocus,
                                                                             txtTitle_add1.GotFocus, txtOption1_add1.GotFocus, txtOption2_add1.GotFocus, txtOption3_add1.GotFocus, txtOption4_add1.GotFocus, txtOption5_add1.GotFocus,
                                                                             txtTitle_add2.GotFocus, txtOption1_add2.GotFocus, txtOption2_add2.GotFocus, txtOption3_add2.GotFocus, txtOption4_add2.GotFocus, txtOption5_add2.GotFocus,
                                                                             txtTitle_add3.GotFocus, txtOption1_add3.GotFocus, txtOption2_add3.GotFocus, txtOption3_add3.GotFocus, txtOption4_add3.GotFocus, txtOption5_add3.GotFocus,
                                                                             txtTitle_add4.GotFocus, txtOption1_add4.GotFocus, txtOption2_add4.GotFocus, txtOption3_add4.GotFocus, txtOption4_add4.GotFocus, txtOption5_add4.GotFocus,
                                                                             txtTitle_add5.GotFocus, txtOption1_add5.GotFocus, txtOption2_add5.GotFocus, txtOption3_add5.GotFocus, txtOption4_add5.GotFocus, txtOption5_add5.GotFocus

        ActiveControl.ForeColor = Color.Black

        If InStr(ActiveControl.Text, "제목을 입력") Or InStr(ActiveControl.Text, "옵션") Then

            ActiveControl.Text = ""

        End If


    End Sub

    Private Sub txtTitle1_lostFocus(sender As Object, e As EventArgs) Handles txtTitle1.LostFocus, txtTitle2.LostFocus, txtTitle3.LostFocus, txtTitle4.LostFocus, txtTitle5.LostFocus,
                                                                             txtTitle6.LostFocus, txtTitle7.LostFocus, txtTitle8.LostFocus, txtTitle9.LostFocus, txtTitle10.LostFocus,
                                                                             txtTitle11.LostFocus, txtTitle12.LostFocus, txtTitle13.LostFocus, txtTitle14.LostFocus, txtTitle15.LostFocus,
                                                                             txtTitle16.LostFocus, txtTitle17.LostFocus, txtTitle18.LostFocus, txtTitle19.LostFocus, txtTitle20.LostFocus,
                                                                             txtTitle21.LostFocus, txtTitle22.LostFocus, txtTitle23.LostFocus, txtTitle24.LostFocus, txtTitle25.LostFocus,
                                                                             txtOption1_1.LostFocus, txtOption1_2.LostFocus, txtOption1_3.LostFocus, txtOption1_4.LostFocus, txtOption1_5.LostFocus,
                                                                             txtOption2_1.LostFocus, txtOption2_2.LostFocus, txtOption2_3.LostFocus, txtOption2_4.LostFocus, txtOption2_5.LostFocus,
                                                                             txtOption3_1.LostFocus, txtOption3_2.LostFocus, txtOption3_3.LostFocus, txtOption3_4.LostFocus, txtOption3_5.LostFocus,
                                                                             txtOption4_1.LostFocus, txtOption4_2.LostFocus, txtOption4_3.LostFocus, txtOption4_4.LostFocus, txtOption4_5.LostFocus,
                                                                             txtOption5_1.LostFocus, txtOption5_2.LostFocus, txtOption5_3.LostFocus, txtOption5_4.LostFocus, txtOption5_5.LostFocus,
                                                                             txtOption6_1.LostFocus, txtOption6_2.LostFocus, txtOption6_3.LostFocus, txtOption6_4.LostFocus, txtOption6_5.LostFocus,
                                                                             txtOption7_1.LostFocus, txtOption7_2.LostFocus, txtOption7_3.LostFocus, txtOption7_4.LostFocus, txtOption7_5.LostFocus,
                                                                             txtOption8_1.LostFocus, txtOption8_2.LostFocus, txtOption8_3.LostFocus, txtOption8_4.LostFocus, txtOption8_5.LostFocus,
                                                                             txtOption9_1.LostFocus, txtOption9_2.LostFocus, txtOption9_3.LostFocus, txtOption9_4.LostFocus, txtOption9_5.LostFocus,
                                                                             txtOption10_1.LostFocus, txtOption10_2.LostFocus, txtOption10_3.LostFocus, txtOption10_4.LostFocus, txtOption10_5.LostFocus,
                                                                             txtOption11_1.LostFocus, txtOption11_2.LostFocus, txtOption11_3.LostFocus, txtOption11_4.LostFocus, txtOption11_5.LostFocus,
                                                                             txtOption12_1.LostFocus, txtOption12_2.LostFocus, txtOption12_3.LostFocus, txtOption12_4.LostFocus, txtOption12_5.LostFocus,
                                                                             txtOption13_1.LostFocus, txtOption13_2.LostFocus, txtOption13_3.LostFocus, txtOption13_4.LostFocus, txtOption13_5.LostFocus,
                                                                             txtOption14_1.LostFocus, txtOption14_2.LostFocus, txtOption14_3.LostFocus, txtOption14_4.LostFocus, txtOption14_5.LostFocus,
                                                                             txtOption15_1.LostFocus, txtOption15_2.LostFocus, txtOption15_3.LostFocus, txtOption15_4.LostFocus, txtOption15_5.LostFocus,
                                                                             txtOption16_1.LostFocus, txtOption16_2.LostFocus, txtOption16_3.LostFocus, txtOption16_4.LostFocus, txtOption16_5.LostFocus,
                                                                             txtOption17_1.LostFocus, txtOption17_2.LostFocus, txtOption17_3.LostFocus, txtOption17_4.LostFocus, txtOption17_5.LostFocus,
                                                                             txtOption18_1.LostFocus, txtOption18_2.LostFocus, txtOption18_3.LostFocus, txtOption18_4.LostFocus, txtOption18_5.LostFocus,
                                                                             txtOption19_1.LostFocus, txtOption19_2.LostFocus, txtOption19_3.LostFocus, txtOption19_4.LostFocus, txtOption19_5.LostFocus,
                                                                             txtOption20_1.LostFocus, txtOption20_2.LostFocus, txtOption20_3.LostFocus, txtOption20_4.LostFocus, txtOption20_5.LostFocus,
                                                                             txtOption21_1.LostFocus, txtOption21_2.LostFocus, txtOption21_3.LostFocus, txtOption21_4.LostFocus, txtOption21_5.LostFocus,
                                                                             txtOption22_1.LostFocus, txtOption22_2.LostFocus, txtOption22_3.LostFocus, txtOption22_4.LostFocus, txtOption22_5.LostFocus,
                                                                             txtOption23_1.LostFocus, txtOption23_2.LostFocus, txtOption23_3.LostFocus, txtOption23_4.LostFocus, txtOption23_5.LostFocus,
                                                                             txtOption24_1.LostFocus, txtOption24_2.LostFocus, txtOption24_3.LostFocus, txtOption24_4.LostFocus, txtOption24_5.LostFocus,
                                                                             txtOption25_1.LostFocus, txtOption25_2.LostFocus, txtOption25_3.LostFocus, txtOption25_4.LostFocus, txtOption25_5.LostFocus,
                                                                             txtGroup1.LostFocus, txtGroup2.LostFocus, txtGroup3.LostFocus, txtGroup4.LostFocus, txtGroup5.LostFocus,
                                                                             txtTitle_add1.LostFocus, txtOption1_add1.LostFocus, txtOption2_add1.LostFocus, txtOption3_add1.LostFocus, txtOption4_add1.LostFocus, txtOption5_add1.LostFocus,
                                                                             txtTitle_add2.LostFocus, txtOption1_add2.LostFocus, txtOption2_add2.LostFocus, txtOption3_add2.LostFocus, txtOption4_add2.LostFocus, txtOption5_add2.LostFocus,
                                                                             txtTitle_add3.LostFocus, txtOption1_add3.LostFocus, txtOption2_add3.LostFocus, txtOption3_add3.LostFocus, txtOption4_add3.LostFocus, txtOption5_add3.LostFocus,
                                                                             txtTitle_add4.LostFocus, txtOption1_add4.LostFocus, txtOption2_add4.LostFocus, txtOption3_add4.LostFocus, txtOption4_add4.LostFocus, txtOption5_add4.LostFocus,
                                                                             txtTitle_add5.LostFocus, txtOption1_add5.LostFocus, txtOption2_add5.LostFocus, txtOption3_add5.LostFocus, txtOption4_add5.LostFocus, txtOption5_add5.LostFocus

        If ActiveControl.Text = "" Or InStr(ActiveControl.Text, " ") = 1 Then

            ActiveControl.ForeColor = Color.Gray

            If ActiveControl.Tag = "title" Then

                ActiveControl.Text = "제목을 입력해주세요."

            ElseIf ActiveControl.Tag = "group" Then

                ActiveControl.Text = "그룹 제목을 입력해주세요."

            Else

                ActiveControl.Text = "옵션" & ActiveControl.Tag

            End If

        End If

    End Sub

    Private Sub txtTitle1_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles txtTitle1.PreviewKeyDown, txtTitle2.PreviewKeyDown, txtTitle3.PreviewKeyDown, txtTitle4.PreviewKeyDown, txtTitle5.PreviewKeyDown,
                                                                             txtTitle6.PreviewKeyDown, txtTitle7.PreviewKeyDown, txtTitle8.PreviewKeyDown, txtTitle9.PreviewKeyDown, txtTitle10.PreviewKeyDown,
                                                                             txtTitle11.PreviewKeyDown, txtTitle12.PreviewKeyDown, txtTitle13.PreviewKeyDown, txtTitle14.PreviewKeyDown, txtTitle15.PreviewKeyDown,
                                                                             txtTitle16.PreviewKeyDown, txtTitle17.PreviewKeyDown, txtTitle18.PreviewKeyDown, txtTitle19.PreviewKeyDown, txtTitle20.PreviewKeyDown,
                                                                             txtTitle21.PreviewKeyDown, txtTitle22.PreviewKeyDown, txtTitle23.PreviewKeyDown, txtTitle24.PreviewKeyDown, txtTitle25.PreviewKeyDown,
                                                                             txtOption1_1.PreviewKeyDown, txtOption1_2.PreviewKeyDown, txtOption1_3.PreviewKeyDown, txtOption1_4.PreviewKeyDown, txtOption1_5.PreviewKeyDown,
                                                                             txtOption2_1.PreviewKeyDown, txtOption2_2.PreviewKeyDown, txtOption2_3.PreviewKeyDown, txtOption2_4.PreviewKeyDown, txtOption2_5.PreviewKeyDown,
                                                                             txtOption3_1.PreviewKeyDown, txtOption3_2.PreviewKeyDown, txtOption3_3.PreviewKeyDown, txtOption3_4.PreviewKeyDown, txtOption3_5.PreviewKeyDown,
                                                                             txtOption4_1.PreviewKeyDown, txtOption4_2.PreviewKeyDown, txtOption4_3.PreviewKeyDown, txtOption4_4.PreviewKeyDown, txtOption4_5.PreviewKeyDown,
                                                                             txtOption5_1.PreviewKeyDown, txtOption5_2.PreviewKeyDown, txtOption5_3.PreviewKeyDown, txtOption5_4.PreviewKeyDown, txtOption5_5.PreviewKeyDown,
                                                                             txtOption6_1.PreviewKeyDown, txtOption6_2.PreviewKeyDown, txtOption6_3.PreviewKeyDown, txtOption6_4.PreviewKeyDown, txtOption6_5.PreviewKeyDown,
                                                                             txtOption7_1.PreviewKeyDown, txtOption7_2.PreviewKeyDown, txtOption7_3.PreviewKeyDown, txtOption7_4.PreviewKeyDown, txtOption7_5.PreviewKeyDown,
                                                                             txtOption8_1.PreviewKeyDown, txtOption8_2.PreviewKeyDown, txtOption8_3.PreviewKeyDown, txtOption8_4.PreviewKeyDown, txtOption8_5.PreviewKeyDown,
                                                                             txtOption9_1.PreviewKeyDown, txtOption9_2.PreviewKeyDown, txtOption9_3.PreviewKeyDown, txtOption9_4.PreviewKeyDown, txtOption9_5.PreviewKeyDown,
                                                                             txtOption10_1.PreviewKeyDown, txtOption10_2.PreviewKeyDown, txtOption10_3.PreviewKeyDown, txtOption10_4.PreviewKeyDown, txtOption10_5.PreviewKeyDown,
                                                                             txtOption11_1.PreviewKeyDown, txtOption11_2.PreviewKeyDown, txtOption11_3.PreviewKeyDown, txtOption11_4.PreviewKeyDown, txtOption11_5.PreviewKeyDown,
                                                                             txtOption12_1.PreviewKeyDown, txtOption12_2.PreviewKeyDown, txtOption12_3.PreviewKeyDown, txtOption12_4.PreviewKeyDown, txtOption12_5.PreviewKeyDown,
                                                                             txtOption13_1.PreviewKeyDown, txtOption13_2.PreviewKeyDown, txtOption13_3.PreviewKeyDown, txtOption13_4.PreviewKeyDown, txtOption13_5.PreviewKeyDown,
                                                                             txtOption14_1.PreviewKeyDown, txtOption14_2.PreviewKeyDown, txtOption14_3.PreviewKeyDown, txtOption14_4.PreviewKeyDown, txtOption14_5.PreviewKeyDown,
                                                                             txtOption15_1.PreviewKeyDown, txtOption15_2.PreviewKeyDown, txtOption15_3.PreviewKeyDown, txtOption15_4.PreviewKeyDown, txtOption15_5.PreviewKeyDown,
                                                                             txtOption16_1.PreviewKeyDown, txtOption16_2.PreviewKeyDown, txtOption16_3.PreviewKeyDown, txtOption16_4.PreviewKeyDown, txtOption16_5.PreviewKeyDown,
                                                                             txtOption17_1.PreviewKeyDown, txtOption17_2.PreviewKeyDown, txtOption17_3.PreviewKeyDown, txtOption17_4.PreviewKeyDown, txtOption17_5.PreviewKeyDown,
                                                                             txtOption18_1.PreviewKeyDown, txtOption18_2.PreviewKeyDown, txtOption18_3.PreviewKeyDown, txtOption18_4.PreviewKeyDown, txtOption18_5.PreviewKeyDown,
                                                                             txtOption19_1.PreviewKeyDown, txtOption19_2.PreviewKeyDown, txtOption19_3.PreviewKeyDown, txtOption19_4.PreviewKeyDown, txtOption19_5.PreviewKeyDown,
                                                                             txtOption20_1.PreviewKeyDown, txtOption20_2.PreviewKeyDown, txtOption20_3.PreviewKeyDown, txtOption20_4.PreviewKeyDown, txtOption20_5.PreviewKeyDown,
                                                                             txtOption21_1.PreviewKeyDown, txtOption21_2.PreviewKeyDown, txtOption21_3.PreviewKeyDown, txtOption21_4.PreviewKeyDown, txtOption21_5.PreviewKeyDown,
                                                                             txtOption22_1.PreviewKeyDown, txtOption22_2.PreviewKeyDown, txtOption22_3.PreviewKeyDown, txtOption22_4.PreviewKeyDown, txtOption22_5.PreviewKeyDown,
                                                                             txtOption23_1.PreviewKeyDown, txtOption23_2.PreviewKeyDown, txtOption23_3.PreviewKeyDown, txtOption23_4.PreviewKeyDown, txtOption23_5.PreviewKeyDown,
                                                                             txtOption24_1.PreviewKeyDown, txtOption24_2.PreviewKeyDown, txtOption24_3.PreviewKeyDown, txtOption24_4.PreviewKeyDown, txtOption24_5.PreviewKeyDown,
                                                                             txtOption25_1.PreviewKeyDown, txtOption25_2.PreviewKeyDown, txtOption25_3.PreviewKeyDown, txtOption25_4.PreviewKeyDown, txtOption25_5.PreviewKeyDown,
                                                                             txtGroup1.PreviewKeyDown, txtGroup2.PreviewKeyDown, txtGroup3.PreviewKeyDown, txtGroup4.PreviewKeyDown, txtGroup5.PreviewKeyDown,
                                                                             txtTitle_add1.PreviewKeyDown, txtOption1_add1.PreviewKeyDown, txtOption2_add1.PreviewKeyDown, txtOption3_add1.PreviewKeyDown, txtOption4_add1.PreviewKeyDown, txtOption5_add1.PreviewKeyDown,
                                                                             txtTitle_add2.PreviewKeyDown, txtOption1_add2.PreviewKeyDown, txtOption2_add2.PreviewKeyDown, txtOption3_add2.PreviewKeyDown, txtOption4_add2.PreviewKeyDown, txtOption5_add2.PreviewKeyDown,
                                                                             txtTitle_add3.PreviewKeyDown, txtOption1_add3.PreviewKeyDown, txtOption2_add3.PreviewKeyDown, txtOption3_add3.PreviewKeyDown, txtOption4_add3.PreviewKeyDown, txtOption5_add3.PreviewKeyDown,
                                                                             txtTitle_add4.PreviewKeyDown, txtOption1_add4.PreviewKeyDown, txtOption2_add4.PreviewKeyDown, txtOption3_add4.PreviewKeyDown, txtOption4_add4.PreviewKeyDown, txtOption5_add4.PreviewKeyDown,
                                                                             txtTitle_add5.PreviewKeyDown, txtOption1_add5.PreviewKeyDown, txtOption2_add5.PreviewKeyDown, txtOption3_add5.PreviewKeyDown, txtOption4_add5.PreviewKeyDown, txtOption5_add5.PreviewKeyDown
        If e.KeyCode = Keys.Tab Then

            If ActiveControl.Text = "" Or InStr(ActiveControl.Text, " ") = 1 Then

                ActiveControl.ForeColor = Color.Gray


                If ActiveControl.Tag = "title" Then

                    ActiveControl.Text = "제목을 입력해주세요."

                ElseIf ActiveControl.Tag = "group" Then

                    ActiveControl.Text = "그룹 제목을 입력해주세요."

                Else

                    ActiveControl.Text = "옵션" & ActiveControl.Tag

                End If

            End If

        Else

            ActiveControl.ForeColor = Color.Black

        End If


    End Sub


    '##################### Survey Save 부분 ##################### 
    Private Sub btSave_Click(sender As Object, e As EventArgs) Handles btSave.Click, btSave2.Click

        chkSubmit = True

        vConn = New OleDbConnection(vCon_Local)

        'Dim arr_select(23, 4) As String
        Dim SQL As String = "UPDATE Survey Set "
        Dim title As String = Nothing
        Dim group As New List(Of String)


        '질문 제목 DB에 저장
        For Each Ctrl In Me.Controls

            If Ctrl.GetType() Is GetType(TabControl) Then

                For Each tpage In Ctrl.Controls

                    If tpage.GetType() Is GetType(TabPage) Then

                        For Each pnl In tpage.Controls

                            If pnl.GetType() Is GetType(Panel) Then

                                For Each txt In pnl.Controls

                                    If txt.GetType() Is GetType(TextBox) And txt.Tag <> "title" Then

                                        If txt.foreColor = Color.Gray Then
                                            txt.Text = ""
                                        End If

                                        SQL = SQL & "[Select" & txt.Tag & "] = '" & txt.Text & "', "
                                        'arr_select(pnl.Tag - 1, txt.Tag - 1) = txt.Text

                                    ElseIf txt.GetType() Is GetType(TextBox) And txt.tag = "title" Then

                                        If txt.ForeColor = Color.Gray Then
                                            txt.Text = ""
                                        End If
                                        title = "[Question] = '" & txt.Text & "'"

                                    End If

                                Next

                                If pnl.Tag <> "Fm" And pnl.Tag <> "Age" Then

                                    SQL = SQL & title & " WHERE ID = " & pnl.Tag

                                    Dim cmd As OleDbCommand = New OleDbCommand(SQL, vConn)
                                    DA = New OleDbDataAdapter(cmd)
                                    DA.Fill(DS)

                                    SQL = "UPDATE Survey Set "

                                End If
                            End If
                        Next
                    End If
                Next
            End If
        Next

        '그룹 제목 List에 담기
        For Each tCtrl In Me.Controls

            If tCtrl.GetType() Is GetType(TabControl) Then

                For Each tpage In tCtrl.Controls

                    If tpage.GetType() Is GetType(TabPage) Then

                        For Each grp In tpage.Controls

                            If grp.GetType() Is GetType(TextBox) And grp.Tag = "group" Then

                                If grp.ForeColor = Color.Gray Then
                                    grp.Text = ""
                                End If

                                group.Add(grp.Text)

                            End If
                        Next
                    End If
                Next
            End If
        Next

        Dim SQL_group As String = "SELECT * FROM Survey ORDER BY [ID] ASC"
        Dim cmd_group As OleDbCommand = New OleDbCommand(SQL_group, vConn)
        DA = New OleDbDataAdapter(cmd_group)
        DA.Fill(DS, "Survey")

        Dim DS_group As DataTable = DS.Tables("Survey")

        Dim division As String = Nothing
        For i As Integer = 1 To DS_group.Rows.Count

            'Dim grp As String = Nothing

            'If i <= 6 Then

            '    grp = group(0)

            'ElseIf 7 < i <= 12 Then

            '    grp = group(1)

            'ElseIf 13 < i <= 18 Then

            '    grp = group(2)

            'ElseIf 19 < i <= 24 Then

            '    grp = group(3)
            'End If

            Select Case i

                Case <= 6
                    division = group(0)
                Case <= 12
                    division = group(1)
                Case <= 18
                    division = group(2)
                Case <= 24
                    division = group(3)

            End Select

            Dim SQL_grp As String = "UPDATE Survey Set [Title] = '" & nameSurvey.Text & "', [Group] = '" & division & "' WHERE [ID] = " & i
            Dim cmd_grp As OleDbCommand = New OleDbCommand(SQL_grp, vConn)
            DA = New OleDbDataAdapter(cmd_grp)
            DA.Fill(DS, "Survey")

        Next

        Me.Close()
    End Sub

    '##################### 질문 추가/삭제 부분 ##################### 
    Private Sub btDel1_6_Click(sender As Object, e As EventArgs) Handles btDel1_4.Click, btDel1_5.Click, btDel1_6.Click,
                                                                         btDel2_4.Click, btDel2_5.Click, btDel2_6.Click,
                                                                         btDel3_4.Click, btDel3_5.Click, btDel3_6.Click,
                                                                         btDel4_4.Click, btDel4_5.Click, btDel4_6.Click,
                                                                         btDel5_4.Click, btDel5_5.Click, btDel5_6.Click

        Dim bt_Tag As Integer = ActiveControl.Tag

        ActiveControl.Parent.Visible = False

        For Each pnl In ActiveControl.Parent.Parent.Controls

            If pnl.GetType() Is GetType(Panel) Then

                For Each bt In pnl.Controls

                    If bt.GetType() Is GetType(Button) And InStr(bt.Tag, "r") = 0 Then

                        If bt.Tag = bt_Tag - 1 Then

                            bt.Visible = True

                        End If
                    ElseIf bt.GetType() Is GetType(TextBox) And bt.Tag = "title" Then

                        bt.ForeColor = Color.Gray
                        bt.text = "제목을 입력해주세요"

                    End If

                Next
            End If
        Next

    End Sub

    Private Sub btAdd1_Click(sender As Object, e As EventArgs) Handles btAdd1.Click, btAdd2.Click, btAdd3.Click, btAdd4.Click

        ' Visible 값이 False로 된 질문 List에 담기
        Dim list_survey As New List(Of String)

        For Each pnl In ActiveControl.Parent.Controls

            If pnl.GetType() Is GetType(Panel) Then

                If pnl.Visible = False Then

                    list_survey.Add(pnl.Name)

                End If
            End If
        Next


        If DirectCast(sender, Control).Name = "btAdd4" Then

            If Panel24.Visible = True Then

                If MsgBox("설문 페이지를 추가 하시겠습니까?", vbYesNo) = vbYes Then

                    cnt_page = 0
                    Next8.Visible = True
                    btSave.Visible = False
                    Call Next1_Click(sender, e)
                    Exit Sub

                Else
                    Exit Sub
                End If
            End If

        End If



        ' List에 담긴 질문 중 가장 최상단 질문 추가
        If list_survey.Count <> 0 Then

            For Each Q In ActiveControl.Parent.Controls

                If Q.GetType() Is GetType(Panel) Then

                    If Q.Name = list_survey(list_survey.Count - 1) Then

                        Q.Visible = True
                        hide_Question.Remove(Q.Tag)
                        Exit For

                    End If

                End If

            Next

        Else
            MsgBox("더이상 질문을 추가 할 수 없습니다. (최대 6개)") : Exit Sub
        End If

    End Sub

    Private Sub btDel_Page_Click(sender As Object, e As EventArgs) Handles btDel_Page.Click

        If MsgBox("이 설문 Page를 삭제하시겠습니까?", vbYesNo) = vbYes Then

            Next8.Visible = False
            btSave.Visible = True
            cnt_page = 2
            txtTitle21.ForeColor = Color.Gray
            txtTitle21.Text = "제목을 입력해주세요"
            Call Prev1_Click(sender, e)

        Else

            Exit Sub

        End If

    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub Button84_Click(sender As Object, e As EventArgs) Handles Button84.Click

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click, Button2.Click, Button3.Click, Button4.Click, Button5.Click, Button6.Click, Button7.Click, Button8.Click, Button9.Click, Button10.Click,
                                                                        Button11.Click, Button12.Click, Button13.Click, Button14.Click, Button15.Click, Button16.Click, Button17.Click, Button18.Click, Button19.Click, Button20.Click,
                                                                        Button21.Click, Button22.Click, Button23.Click, Button24.Click, Button25.Click, Button26.Click, Button27.Click, Button28.Click, Button29.Click, Button30.Click,
                                                                        Button31.Click, Button32.Click, Button33.Click, Button34.Click, Button35.Click, Button36.Click, Button37.Click, Button38.Click, Button39.Click, Button40.Click,
                                                                        Button41.Click, Button42.Click, Button43.Click, Button44.Click, Button45.Click, Button46.Click, Button47.Click, Button48.Click, Button49.Click, Button50.Click,
                                                                        Button51.Click, Button52.Click, Button53.Click, Button54.Click, Button55.Click, Button56.Click, Button57.Click, Button58.Click, Button59.Click, Button60.Click,
                                                                        Button61.Click, Button62.Click, Button63.Click, Button64.Click, Button65.Click, Button66.Click, Button67.Click, Button68.Click, Button69.Click, Button70.Click,
                                                                        Button71.Click, Button72.Click, Button73.Click, Button74.Click, Button75.Click, Button76.Click, Button77.Click, Button78.Click, Button79.Click, Button80.Click,
                                                                        Button81.Click, Button82.Click, Button83.Click, Button84.Click, Button85.Click, Button86.Click, Button87.Click, Button88.Click, Button89.Click, Button90.Click



        Dim bt_Tag As Integer = Replace(ActiveControl.Tag, "r", "")

        For Each bt In ActiveControl.Parent.Controls

            If bt.GetType() Is GetType(TextBox) Then

                If bt.tag <> "title" Then

                    If bt.Tag = bt_Tag Then

                        bt.Text = ""
                        bt.Visible = False

                    ElseIf bt.Tag = bt_Tag + 1 Then

                        bt.Select

                    End If

                End If

            ElseIf bt.GetType() Is GetType(RadioButton) Then

                If bt.Tag = bt_Tag Then

                    hide_Q.Add(bt.parent.Tag)
                    hide_Radio.Add(bt.Tag)
                    bt.visible = False

                End If


            ElseIf bt.GetType() Is GetType(Button) And InStr(bt.Tag, "r") Then

                If Replace(bt.Tag, "r", "") = bt_Tag + 1 Then

                    bt.Visible = True

                ElseIf Replace(bt.Tag, "r", "") = bt_Tag Then

                    bt.visible = False
                End If

            End If

        Next

    End Sub

    Private Sub Button93_Click(sender As Object, e As EventArgs) Handles Button91.Click, Button92.Click, Button93.Click, Button94.Click, Button95.Click, Button96.Click, Button97.Click, Button98.Click, Button99.Click, Button100.Click,
                                                                         Button101.Click, Button102.Click, Button103.Click, Button104.Click, Button105.Click, Button106.Click, Button107.Click, Button108.Click, Button109.Click, Button110.Click,
                                                                         Button111.Click, Button112.Click, Button113.Click, Button114.Click, Button115.Click, Button116.Click, Button117.Click, Button118.Click, Button119.Click, Button120.Click,
                                                                         Button121.Click, Button122.Click, Button123.Click, Button124.Click, Button125.Click, Button126.Click, Button127.Click, Button128.Click, Button129.Click, Button130.Click,
                                                                         Button131.Click, Button132.Click, Button133.Click, Button134.Click, Button135.Click, Button136.Click, Button137.Click, Button138.Click, Button139.Click, Button140.Click,
                                                                         Button141.Click, Button142.Click, Button143.Click, Button144.Click, Button145.Click, Button146.Click, Button147.Click, Button148.Click, Button149.Click, Button150.Click,
                                                                         Button151.Click, Button152.Click, Button153.Click, Button154.Click, Button155.Click, Button156.Click, Button157.Click, Button158.Click, Button159.Click, Button160.Click,
                                                                         Button161.Click, Button162.Click, Button163.Click, Button164.Click, Button165.Click, Button166.Click, Button167.Click, Button168.Click, Button169.Click, Button170.Click,
                                                                         Button171.Click, Button172.Click, Button173.Click, Button174.Click, Button175.Click, Button176.Click, Button177.Click, Button178.Click, Button179.Click, Button180.Click

        Dim bt_Tag As Integer = Replace(ActiveControl.Tag, "r", "")

        For Each bt In ActiveControl.Parent.Controls

            If bt.GetType() Is GetType(TextBox) Then

                If bt.tag <> "title" Then

                    If bt.Tag = bt_Tag - 1 Then

                        bt.Visible = True
                        bt.Select

                    End If

                End If

            ElseIf bt.GetType() Is GetType(RadioButton) Then

                If bt.Tag = bt_Tag + -1 Then

                    hide_Q.Remove(bt.Parent.Tag)
                    hide_Radio.Remove(bt.Tag)
                    bt.visible = True

                End If


            ElseIf bt.GetType() Is GetType(Button) And InStr(bt.Tag, "r") Then

                If Replace(bt.Tag, "r", "") = bt_Tag - 1 Then

                    bt.Visible = True

                ElseIf Replace(bt.Tag, "r", "") = bt_Tag Then

                    bt.visible = False

                End If

            End If

        Next



    End Sub

    Private Sub Edit_Survey_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        If chkSubmit = False Then
            hide_Q.Clear()
            hide_Radio.Clear()
            nameSurvey.Text = ""
        End If
    End Sub



    '#####################################################################################

    'Private Sub btEdit_Radio1_Click(sender As Object, e As EventArgs) Handles 
    '        btEdit_Radio10.Click, btEdit_Radio11.Click, btEdit_Radio12.Click, btEdit_Radio13.Click, btEdit_Radio14.Click, btEdit_Radio15.Click,
    '        btEdit_Radio16.Click, btEdit_Radio17.Click, btEdit_Radio18.Click, btEdit_Radio19.Click

    '    Dim Survey_Select As New Survey_Select

    '    If DirectCast(sender, Control).Name = "btEdit_Radio1" Then
    '        Survey_Select.strSelect = 1
    '    ElseIf DirectCast(sender, Control).Name = "btEdit_Radio2" Then
    '        Survey_Select.strSelect = 2
    '    ElseIf DirectCast(sender, Control).Name = "btEdit_Radio3" Then
    '        Survey_Select.strSelect = 3
    '    ElseIf DirectCast(sender, Control).Name = "btEdit_Radio4" Then
    '        Survey_Select.strSelect = 4
    '    ElseIf DirectCast(sender, Control).Name = "btEdit_Radio5" Then
    '        Survey_Select.strSelect = 5

    '    ElseIf DirectCast(sender, Control).Name = "btEdit_Radio6" Then
    '        Survey_Select.strSelect = 6
    '    ElseIf DirectCast(sender, Control).Name = "btEdit_Radio7" Then
    '        Survey_Select.strSelect = 7
    '    ElseIf DirectCast(sender, Control).Name = "btEdit_Radio8" Then
    '        Survey_Select.strSelect = 8
    '    ElseIf DirectCast(sender, Control).Name = "btEdit_Radio9" Then
    '        Survey_Select.strSelect = 9
    '    ElseIf DirectCast(sender, Control).Name = "btEdit_Radio10" Then
    '        Survey_Select.strSelect = 10

    '    ElseIf DirectCast(sender, Control).Name = "btEdit_Radio11" Then
    '        Survey_Select.strSelect = 11
    '    ElseIf DirectCast(sender, Control).Name = "btEdit_Radio12" Then
    '        Survey_Select.strSelect = 12
    '    ElseIf DirectCast(sender, Control).Name = "btEdit_Radio13" Then
    '        Survey_Select.strSelect = 13
    '    ElseIf DirectCast(sender, Control).Name = "btEdit_Radio14" Then
    '        Survey_Select.strSelect = 14
    '    ElseIf DirectCast(sender, Control).Name = "btEdit_Radio15" Then
    '        Survey_Select.strSelect = 15

    '    ElseIf DirectCast(sender, Control).Name = "btEdit_Radio16" Then
    '        Survey_Select.strSelect = 16
    '    ElseIf DirectCast(sender, Control).Name = "btEdit_Radio17" Then
    '        Survey_Select.strSelect = 17
    '    ElseIf DirectCast(sender, Control).Name = "btEdit_Radio18" Then
    '        Survey_Select.strSelect = 18
    '    ElseIf DirectCast(sender, Control).Name = "btEdit_Radio19" Then
    '        Survey_Select.strSelect = 19
    '    ElseIf DirectCast(sender, Control).Name = "btEdit_Radio20" Then
    '        Survey_Select.strSelect = 20

    '    End If

    '    Survey_Select.ShowDialog()
    '    If Survey_Select.chktxt = True Then

    '        For Each Ctrl In Me.Controls

    '            If Ctrl.GetType() Is GetType(Panel) Then

    '                If Ctrl.Tag = Survey_Select.strSelect Then

    '                    For Each Radio In Ctrl.Controls

    '                        If Radio.GetType() Is GetType(RadioButton) Then

    '                            Radio.Text = Survey_Select.Selection(Radio.Tag - 1)

    '                        End If

    '                    Next

    '                End If

    '            End If

    '        Next

    '    End If

    'End Sub



End Class