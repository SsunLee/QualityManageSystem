Imports System.Windows.Forms
Imports System.Data
Imports System.Data.OleDb
Public Class Contacts_Edit
    Dim itemSta As String
    Private DS As DataSet = New DataSet
    Private DS2 As DataSet = New DataSet
    Private DA As OleDbDataAdapter = New OleDbDataAdapter()
    Public ordAdapter As OleDbDataAdapter = New OleDbDataAdapter()
    Private strSQL As String
    ' Private adminMainForm = New AdminMain
    'Private Main_Form As New Main_Form
    Private vConn As OleDbConnection
    Dim strSht As String
    Dim intIDNUm As Integer


    Private Sub Contacts_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        ' 초기화 해주는 코드
        If addCom.DataSource Is DBNull.Value Or addCom.DataSource Is DBNull.Value Then
        Else
            addCom.DataSource = Nothing
            addCom.Text = ""
            'cbFea.Items.Clear()
        End If

        Dim a As Control
        For Each a In Me.Controls
            If TypeOf a Is GroupBox Then
                For Each b In a.Controls
                    If TypeOf b Is TextBox Then
                        b.Text = ""
                    ElseIf TypeOf b Is ComboBox Then
                        b.Items.Clear()
                        b.text = ""
                    End If
                Next
            End If
        Next

        Try
            Dim xml As New XML
            Dim vCon As String = Nothing
            ' vcon가져오는 함수
            xml.vCon_Call(vCon)
            ' Connect 연결
            vConn = New OleDbConnection(vCon)
            vConn.Open()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "DB Open에러")
            Exit Sub
        End Try

        With addCom.Items
            .Add("CNS")
            .Add("인피닉")
            .Add("엠스텍")
        End With
        ' Form_Refresh()
        txtNum.Multiline = False
    End Sub
    Public Sub Form_Refresh()

        'For Each a In Me.Controls
        '    If TypeOf a Is TextBox Then
        '        If a.Name <> "cbNameㅇ" Then
        '            a.Text = ""
        '        End If
        '    ElseIf TypeOf a Is ComboBox Then
        '        a.Text = ""
        '    End If
        '    If TypeOf a Is GroupBox Then
        '        For Each b In a.Controls
        '            If TypeOf b Is TextBox Then
        '                b.Text = ""
        '            ElseIf TypeOf b Is ComboBox Then
        '                b.text = ""
        '            End If
        '        Next
        '    End If
        'Next
    End Sub

    Private Sub cbName_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbName.SelectedIndexChanged
        ' 대분류 Click 시 중분류에 맞도록
        Dim Table As DataTable = DS.Tables(strSht)

        txtNum.Text = ""

        For i As Integer = 0 To Table.Rows.Count - 1    ' Data table Row 만큼 반복 -1은 마지막행은 Null
            If cbName.Text = Table.Rows(i)(2).ToString() Then ' 선택 된 App과 Row, 필트(0)은 App, (1) 은 Feature
                Try
                    txtNum.Text = Table.Rows(i)(3).ToString()
                    intIDNUm = Table.Rows(i)(0).ToString()

                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            End If
        Next
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim vSQL As String

        ' 미입력 된 부분 확인 하는 코드
        If addCom.Text = "" Or cb2.Text = "" Or txtNum.Text = "" Then
            MsgBox("입력 되지 않은 부분이 있습니다. 확인 후 다시 시도해 주세요. ")
            Exit Sub
        End If

        'If cbName.Text = "" Then
        '    MsgBox("담당자가 입력 되지 않았습니다. ")
        '    Exit Sub
        'End If

        ' 중복된 전화번호 입력 예방 예외코드
        vSQL = "Select * from [" & strSht & "] where [휴대폰] = '" & txtNum.Text & "'"

        DS2.Clear()
        DA = New OleDbDataAdapter(vSQL, vConn)
        DA.Fill(DS2, strSht)

        Dim Table As DataTable = DS2.Tables(strSht)
        If Table.Rows.Count > 0 Then
            MsgBox("현재 중복된 전화번호가 있습니다. 다시 확인 후 추가 해 주세요")
            Exit Sub
        End If

        ' 중복된 이름 입력 예방 예외코드
        vSQL = "Select * from [" & strSht & "] where [이름] = '" & cbName.Text & " And [업체] = ''" & addCom.Text & "'"

        DS2.Clear()
        DA = New OleDbDataAdapter(vSQL, vConn)
        DA.Fill(DS2, strSht)

        Table = DS2.Tables(strSht)
        If Table.Rows.Count > 0 Then
            MsgBox("현재 중복된 이름이 있습니다. 다시 확인 후 추가 해 주세요")
            Exit Sub
        End If

        ' 해당 인원이 있는지 확인 함
        vSQL = "Select * from [" & strSht & "] where [이름] = '" & cbName.Text & "' and [휴대폰] = '" & txtNum.Text & "'and [직급] = '" & cb2.Text & " and [업체] = ''" & addCom.Text & "'"

        DS2.Clear()
        DA = New OleDbDataAdapter(vSQL, vConn)
        DA.Fill(DS2, strSht)

        Table = DS2.Tables(strSht)


        ' select문 결과 0 즉, 없을 경우 추가
        If Table.Rows.Count = 0 Then

            '조회할SQL을 만들어서 String변수에 넣는다.
            vSQL = "INSERT INTO [" & strSht & "]([직급],[이름],[휴대폰],[업체]) "
            vSQL = vSQL + "VALUES ('" & cb2.Text & "','" & cbName.Text & "','" & txtNum.Text & "','" & addCom.Text & "');"
            DA = New OleDbDataAdapter(vSQL, vConn)
            DA.Fill(DS, strSht)

            MsgBox(addCom.Text + " " + cbName.Text + " " + cb2.Text + " 이(가) 추가되었습니다.")

            Form_Refresh()

        Else
            MsgBox(addCom.Text + " " + cbName.Text + " " + cb2.Text + "은(는) 이미 있습니다.")
        End If
    End Sub
    ' ### 수정하기 ####
    Private Sub btnMod_Click(sender As Object, e As EventArgs) Handles btnMod.Click
        Dim vSQL As String
        ' 미입력 된 부분 확인 하는 코드
        If addCom.Text = "" Or cb2.Text = "" Or cbName.Text = "" Or txtNum.Text = "" Then
            MsgBox("입력 되지 않은 부분이 있습니다. 확인 후 다시 시도해 주세요. ")
            Exit Sub
        End If

        'If cbName.Text = "" Then
        '    MsgBox("담당자가 입력 되지 않았습니다. ")
        '    Exit Sub
        'End If

        'vSQL = "Select * from [" & strSht & "] where [이름] = '" & cbName.Text & "' and [직급] = '" & cb2.Text & "'"
        vSQL = "Select * from [" & strSht & "] where [이름] = '" & cbName.Text & "'"

        DS2.Clear()
        DA = New OleDbDataAdapter(vSQL, vConn)
        DA.Fill(DS2, strSht)

        Dim Table As DataTable = DS2.Tables(strSht)

        'intIDNUm

        ' select문 결과 0이 아닐시 즉, 있을 경우 수정
        If Table.Rows.Count = 1 Then

            '조회할SQL을 만들어서 String변수에 넣는다.
            vSQL = " UPDATE [" & strSht & "]SET [직급] = '" & cb2.Text & "',[이름] = '" & cbName.Text & "',[휴대폰] = '" & txtNum.Text & "'"
            'vSQL = vSQL + "where [ID] = " & Table.Rows(0)(0).ToString
            vSQL = vSQL + "where [ID] = " & intIDNUm

            DA = New OleDbDataAdapter(vSQL, vConn)
            DA.Fill(DS, strSht)

            MsgBox(addCom.Text + " " + cbName.Text + " " + cb2.Text + " 이(가) 수정되었습니다.")

            Form_Refresh()
        ElseIf Table.Rows.Count > 1 Then
            MsgBox("중복된 값이 있습니다. 수정이 필요합니다.")
        Else
            MsgBox(addCom.Text + " " + cbName.Text + " " + cb2.Text + "는 존재하지 않아 수정 할 수 없습니다. ")
        End If
    End Sub

    Private Sub btnDel_Click(sender As Object, e As EventArgs) Handles btnDel.Click
        Dim vSQL As String
        Dim iQuestion As String
        ' 미입력 된 부분 확인 하는 코드
        If addCom.Text = "" Then
            MsgBox("업체명을 선택 후 다시 시도해 주세요")
            Exit Sub
        End If
        If cbName.Text = "" And txtNum.Text = "" Then
            MsgBox("이름이나 전화번호를 입력 후 다시 시도해 주세요")
            Exit Sub
        End If

        'If cbName.Text = "" Then
        '    MsgBox("담당자가 입력 되지 않았습니다. ")
        '    Exit Sub
        'End If
        Dim vSQLNum, vSQLName As String

        If txtNum.Text = "" Then
            vSQLNum = ""
        Else
            vSQLNum = " AND [휴대폰] LIKE '%" & txtNum.Text & "%'"
        End If

        If cbName.Text = "" Then
            vSQLName = ""
        Else
            vSQLName = " AND [이름] LIKE '%" & cbName.Text & "%'"
        End If

        ' 번호나 이름으로 해당 검증원이 있는지 확인

        vSQL = "Select * from [" & strSht & "] where ID <> null " & vSQLName & vSQLNum

        DS2.Clear()
        DA = New OleDbDataAdapter(vSQL, vConn)
        DA.Fill(DS2, strSht)

        Dim Table As DataTable = DS2.Tables(strSht)

        ' select문 결과 0이 아닐시 즉, 있을 경우 삭제
        If Table.Rows.Count = 1 Then
            ' 삭제 하는 쿼리
            iQuestion = MsgBox(addCom.Text + " " + cbName.Text + " " + cb2.Text + "를 정말 삭제하시겠습니까?", vbYesNo, "gyeongmin.yeom@lgepartner.com")
            If iQuestion = 6 Then
                DA = New OleDbDataAdapter("Delete from [" & strSht & "]  where [ID] = " & Table.Rows(0)(0).ToString, vConn)
                DA.Fill(DS2, strSht)
            Else
                Exit Sub
            End If
            MsgBox("성공적으로 삭제 하였습니다.")


            DA = New OleDbDataAdapter(vSQL, vConn)
            DA.Fill(DS, strSht)

            Form_Refresh()

        Else
            MsgBox(addCom.Text + " " + cbName.Text + " " + cb2.Text + "는 존재하지 않아 삭제 할 수 없습니다. ")
        End If
    End Sub

    Private Sub addCom_SelectedIndexChanged(sender As Object, e As EventArgs) Handles addCom.SelectedIndexChanged
        strSht = addCom.SelectedItem.ToString

        If strSht = "CNS" Then
            strSht = "Contacts_C"
        ElseIf strSht = "인피닉" Then
            strSht = "Contacts_I"
        ElseIf strSht = "엠스텍" Then
            strSht = "Contacts_M"
        Else
            Exit Sub
        End If

        DS.Clear()
        DA = New OleDbDataAdapter("Select * from [" & strSht & "] order by [직급] asc ,[이름] asc", vConn)
        DA.Fill(DS, strSht)

        Dim Table As DataTable = DS.Tables(strSht)

        If Table.Rows.Count = 0 Then
            MsgBox("조회할 내용이 없습니다.",, "lee.sunbae@lgepartner.com")
            Exit Sub
        End If

        Table = Table.DefaultView.ToTable(True, "직급") ' 중복 제거하고 Table저장

        With cb2
            .DataSource = Table
            .DisplayMember = "직급"
            .ValueMember = "직급"
        End With
        cb2.Text = ""
    End Sub

    Private Sub cb2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cb2.SelectedIndexChanged
        ' 대분류 Click 시 중분류에 맞도록
        Dim Table As DataTable = DS.Tables(strSht)

        cbName.Items.Clear()
        cbName.Text = ""
        txtNum.Text = ""

        For i As Integer = 0 To Table.Rows.Count - 1    ' Data table Row 만큼 반복 -1은 마지막행은 Null
            If cb2.Text = Table.Rows(i)(1).ToString() Then ' 선택 된 App과 Row, 필트(0)은 App, (1) 은 Feature
                Try
                    cbName.Items.Add(Table.Rows(i)(2).ToString())
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            End If
        Next

        cbName.Sorted = True
    End Sub
    Private Sub cbName_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cbName.KeyPress

        Dim vSQL As String

        If e.KeyChar = Convert.ToChar(13) Then
            If addCom.Text = "" Then
                MsgBox("업체명을 먼저 선택 후 사용해 주세요")
                Exit Sub
            End If

            ' 대분류 Click 시 중분류에 맞도록
            vSQL = "Select * from [" & strSht & "] where [이름] = '" & cbName.Text & "'"

            DS2.Clear()
            DA = New OleDbDataAdapter(vSQL, vConn)
            DA.Fill(DS2, strSht)
            Dim Table As DataTable = DS2.Tables(strSht)

            If Table.Rows.Count = 0 Then
                cb2.Text = ""
                txtNum.Text = ""
                MsgBox("해당 검증원은 없습니다.")
                Exit Sub
            End If

            For i As Integer = 0 To Table.Rows.Count - 1    ' Data table Row 만큼 반복 -1은 마지막행은 Null
                If cbName.Text = Table.Rows(i)(2).ToString() Then ' 선택 된 App과 Row, 필트(0)은 App, (1) 은 Feature
                    Try
                        cb2.Text = Table.Rows(i)(1).ToString
                        cbName.Text = Table.Rows(i)(2).ToString()
                        txtNum.Text = Table.Rows(i)(3).ToString()
                    Catch ex As Exception
                        MsgBox(ex.Message)
                    End Try
                End If
            Next
        End If

        If e.KeyChar = Convert.ToChar(27) Then
            Hide()
        End If
    End Sub
    Private Sub txtNum_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNum.KeyPress
        Dim vSQL As String

        If e.KeyChar = Convert.ToChar(13) Then
            If addCom.Text = "" Then
                MsgBox("업체명을 먼저 선택 후 사용해 주세요")
                Exit Sub
            End If

            ' 대분류 Click 시 중분류에 맞도록
            vSQL = "Select * from [" & strSht & "] where [휴대폰] = '" & txtNum.Text & "'"

            DS2.Clear()
            DA = New OleDbDataAdapter(vSQL, vConn)
            DA.Fill(DS2, strSht)
            Dim Table As DataTable = DS2.Tables(strSht)

            If Table.Rows.Count = 0 Then
                cb2.Text = ""
                cbName.Text = ""
                MsgBox("해당 전화번호는 없습니다.")
                Exit Sub
            End If

            For i As Integer = 0 To Table.Rows.Count - 1    ' Data table Row 만큼 반복 -1은 마지막행은 Null
                If txtNum.Text = Table.Rows(i)(3).ToString() Then ' 선택 된 App과 Row, 필트(0)은 App, (1) 은 Feature
                    Try
                        cb2.Text = Table.Rows(i)(1).ToString
                        cbName.Text = Table.Rows(i)(2).ToString()

                    Catch ex As Exception
                        MsgBox(ex.Message)
                    End Try
                End If
            Next
        End If

        If e.KeyChar = Convert.ToChar(27) Then
            Hide()
        End If
    End Sub
End Class