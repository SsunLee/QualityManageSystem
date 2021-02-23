Imports System.Collections.Generic
Imports System.Data
Imports System.Data.OleDb
Imports System.Windows.Forms

Public Class Survey_Select

    'Edit_Survey에서 어느 Button이 눌렸는지 담는 변수
    Public strSelect As String
    Public Selection As New List(Of String)()

    Public vConn As OleDbConnection
    Public DS As DataSet = New DataSet
    Public DA As OleDbDataAdapter = New OleDbDataAdapter()


    Public vCon_Local As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=\\10.169.88.40\Q-Portal\5.Admin(AccessDB)\QPortalDB_Admin.accdb;Jet OLEDB:Database Password = lge1234;"

    Private Sub Survey_Select_Load(sender As Object, e As EventArgs) Handles Me.Load

        'DB에서 제목 불러오기
        Dim SQL_title As String = "SELECT [타이틀] From Survey_Result GROUP BY 타이틀"

        'DB 연결
        vConn = New OleDbConnection(vCon_Local)

        'DB Query 실행
        DA = New OleDbDataAdapter(SQL_title, vConn)
        DA.Fill(DS, "Title")

        'Title ComboBox에 담기
        Dim table As DataTable = DS.Tables("Title")

        If table.Rows.Count = 0 Then
            MsgBox("조회할 설문조사가 없습니다.") : Exit Sub
        Else

            For i As Integer = 0 To table.Rows.Count - 1

                cbTitle.Items.Add(table.Rows(i)(0).ToString)

            Next

        End If

        '업체명
        With cbComp.Items
            .Add("전체")
            .Add("CNS")
            .Add("MSTech")
            .Add("인피닉")
        End With


        '성별
        With cbFm.Items
            .Add("전체")
            .Add("남")
            .Add("여")
        End With

        '연령대
        With cbAge.Items
            .Add("전체")
            .Add("20대")
            .Add("30대")
            .Add("40대")
            .Add("50대 이상")
        End With

        cbComp.SelectedIndex() = 0
        cbFm.SelectedIndex() = 0
        cbAge.SelectedIndex() = 0


    End Sub

    Public chktxt As Boolean

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim Edit_Survey As New Edit_Survey
        chktxt = False
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btOK.Click

        Dim Survey_Result As New Survey_Result

        If cbTitle.SelectedItem Is Nothing Then
            MsgBox("조회할 설문조사의 Title을 선택해주세요.") : Exit Sub
        Else
            Survey_Result.Survey_Title = "AND [타이틀] = '" & cbTitle.SelectedItem().ToString & "' "

        End If

        If cbComp.SelectedItem.ToString = "전체" Then
            Survey_Result.Survey_Comp = ""
        Else
            Survey_Result.Survey_Comp = "AND [업체명] = '" & cbComp.SelectedItem().ToString & "' "
        End If

        If cbFm.SelectedItem.ToString = "전체" Then
            Survey_Result.Survey_Fm = ""
        Else
            Survey_Result.Survey_Fm = "AND [성별] = '" & cbFm.SelectedItem().ToString & "' "
        End If

        If cbAge.SelectedItem.ToString = "전체" Then
            Survey_Result.Survey_Age = ""
        Else
            Survey_Result.Survey_Age = "AND [연령대] = " & Strings.Left(cbAge.SelectedItem().ToString, InStr(cbAge.SelectedItem().ToString, "대") - 1) & " "
        End If


        Survey_Result.ShowDialog()




        'Dim Edit_Survey As New Edit_Survey


        'For Each Ctrl In Me.Controls

        '    If Ctrl.GetType() Is GetType(Panel) Then

        '        For Each txt In Ctrl.Controls

        '            If txt.GetType() Is GetType(TextBox) Then

        '                If txt.Text = "" Then

        '                    MsgBox("입력하지 않은 항목이 있습니다. 확인 후 재시도 해주세요.") : Exit Sub

        '                End If

        '            End If
        '            chktxt = True
        '        Next

        '    End If

        'Next



        'Edit_Survey.RadioButton1.Text = txtSelect1.Text

        ''TextBox 내용 List에 담는 부분
        'For Each Ctrl In Me.Controls

        '    If Ctrl.GetType() Is GetType(Panel) Then 'panel 찾기

        '        For Each TextBox In Ctrl.Controls

        '            If TextBox.GetType() Is GetType(TextBox) Then

        '                Selection.Add(TextBox.text) 'List에 TextBox 내용 담기

        '            End If

        '        Next

        '    End If

        'Next

        'Edit_Survey Form에 뿌리기
        'For cnt As Integer = 0 To Selection.Count - 1

        '    Edit_Survey.Text_Radio.Add(Selection(cnt))

        'Next

        'For Each Ctrl In Edit_Survey.Controls

        '    If Ctrl.GetType() Is GetType(Panel) Then

        '        If Ctrl.Tag = strSelect Then

        '            For Each Radio In Ctrl.Controls

        '                If Radio.GetType() Is GetType(RadioButton) Then

        '                    Radio.text = Selection(Radio.Tag - 1)

        '                End If
        '            Next
        '        End If
        '    End If

        'Next
    End Sub

End Class