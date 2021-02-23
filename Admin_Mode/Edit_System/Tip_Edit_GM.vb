Imports System.Windows.Forms
Imports System.Data
Imports System.Data.OleDb
Imports System.Data.SqlClient
Public Class Tip_Edit_GM
    Dim itemSta As String
    Private DS As DataSet = New DataSet
    Private DS2 As DataSet = New DataSet
    Private DA As OleDbDataAdapter = New OleDbDataAdapter()
    Public ordAdapter As OleDbDataAdapter = New OleDbDataAdapter()
    Private strSQL As String
    Private vConn As OleDbConnection
    ' Private adminMainForm As New AdminMain
    'Private Main_Form As New Main_Form
    Dim strSht As String = "Tip"
    Dim strDate As String = Now()

    Public Sub Form_Refresh()

        DS.Clear()
        'DA = New OleDbDataAdapter("Select * from [" & strSht & "] where Import = 'Y' and app is not null order by [App] asc", vConn)
        DA = New OleDbDataAdapter("Select * from [" & strSht & "] where app is not null order by [App] asc", vConn)
        DA.Fill(DS, strSht)

        Dim Table As DataTable = DS.Tables(strSht)
        Dim Table2 As DataTable = DS.Tables(strSht)
        Dim Table3 As DataTable = DS.Tables(strSht)
        Dim Table4 As DataTable = DS.Tables(strSht)

        If Table.Rows.Count = 0 Then
            MsgBox("조회할 내용이 없습니다.",, "lee.sunbae@lgepartner.com")
            Exit Sub
        End If

        Table = Table.DefaultView.ToTable(True, "App") ' 중복 제거하고 Table저장
        Table2 = Table.DefaultView.ToTable(True, "App") ' 중복 제거하고 Table저장

        With SearchApp
            .DataSource = Table
            .DisplayMember = "App"
            .ValueMember = "App"
        End With

        With cbApp
            .DataSource = Table2
            .DisplayMember = "App"
            .ValueMember = "App"
        End With


        Dim a As Control

        For Each a In Me.Controls
            If TypeOf a Is TextBox Then
                If a.Name <> "txtName" Then
                    a.Text = ""
                End If
            ElseIf TypeOf a Is ComboBox Then
                a.Text = ""
            End If
            If TypeOf a Is GroupBox Then
                For Each b In a.Controls
                    If TypeOf b Is TextBox Then
                        If b.Name <> "txtName" Then
                            b.Text = ""
                        End If
                    ElseIf TypeOf b Is ComboBox Then
                        b.text = ""
                    End If
                Next
            End If
        Next
        SearchY.Enabled = True

    End Sub
    Sub Add_History(ca As String, strTxt As String, strTxt2 As String)
        Dim vSQL As String
        Dim strSht As String

        strSht = "History_Tip"
        Dim xml As New XML
        Dim vCon As String = Nothing
        Dim vConn2 As OleDbConnection
        ' vcon가져오는 함수
        xml.vCon_Admin_Call(vCon)
        ' Connect 연결
        vConn2 = New OleDbConnection(vCon)
        vConn2.Open()

        vSQL = "INSERT INTO [" & strSht & "]([구분],[바뀐내용],[담당자],[날짜])  " &
           "VALUES ( '" & ca & "','" & strTxt & "','" & strTxt2 & "','" & strDate & "');"
        DA = New OleDbDataAdapter(vSQL, vConn2)
        DA.Fill(DS2, strSht)

    End Sub
    Private Sub Tip_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        '관리자 이름 고정
        Dim strUserName As String = Nothing
        Dim xml As New XML

        ' 이름을 받아옴
        For Each v In System.Windows.Forms.Application.OpenForms
            If v.Name = "Main_Form" Then
                txtName.Text = v.strUserName
                Exit For
            End If
        Next
        'txtName.ReadOnly = True

        Try
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

        ' Y/N Combox 값 넣어 주기
        cbImport.Items.Add("Y")
        cbImport.Items.Add("N")

        ' Priority Combobox 값 넣어 주기
        With cbY.Items
            .Add("Y_Sanity")
            .Add("Y_Basic")
            .Add("Y_Full")
        End With

        'With SearchY.Items
        '    .Add("Y_Sanity")
        '    .Add("Y_Basic")
        '    .Add("Y_Full")
        'End With

        Form_Refresh()
    End Sub
    Private Sub SearchApp_SelectedIndexChanged(sender As Object, e As EventArgs) Handles SearchApp.SelectedIndexChanged
        ' 대분류 Click 시 중분류에 맞도록
        Dim Table As DataTable = DS.Tables(strSht)

        SearchFea.Items.Clear()      ' Data Clear 
        SearchFea.Text = ""
        ' SearchType.Items.Clear()
        ' SearchType.Text = ""            ' 설명 초기화 

        For i As Integer = 0 To Table.Rows.Count - 1    ' Data table Row 만큼 반복 -1은 마지막행은 Null
            If SearchApp.Text = Table.Rows(i)(1).ToString() Then ' 선택 된 App과 Row, 필트(1)은 App, (2) 은 Feature
                Try
                    SearchFea.Items.Add(Table.Rows(i)(2).ToString())
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            End If
        Next

        SearchFea.Sorted = True

        'ComboBox1.Items 중복 삭제
        For i As Integer = SearchFea.Items.Count - 1 To 1 Step -1
            If (SearchFea.Items(i - 1) = SearchFea.Items(i)) Then
                SearchFea.Items.RemoveAt(i)
            End If
        Next
    End Sub
    Private Sub SearchFea_SelectedIndexChanged(sender As Object, e As EventArgs) Handles SearchFea.SelectedIndexChanged
        ' 대분류 Click 시 중분류에 맞도록
        Dim Table As DataTable = DS.Tables(strSht)

        SearchType.Items.Clear()      ' Data Clear 
        SearchType.Text = ""

        For i As Integer = 0 To Table.Rows.Count - 1    ' Data table Row 만큼 반복 -1은 마지막행은 Null
            If SearchFea.Text = Table.Rows(i)(2).ToString() Then ' 선택 된 App과 Row, 필트(0)은 App, (1) 은 Feature
                Try
                    SearchType.Items.Add(Table.Rows(i)(4).ToString())
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            End If
        Next

        SearchType.Sorted = True

        'ComboBox1.Items 중복 삭제
        For i As Integer = SearchType.Items.Count - 1 To 1 Step -1
            If (SearchType.Items(i - 1) = SearchType.Items(i)) Then
                SearchType.Items.RemoveAt(i)
            End If
        Next
    End Sub
    Private Sub cbApp_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbApp.SelectedIndexChanged
        ' 대분류 Click 시 중분류에 맞도록
        Dim Table As DataTable = DS.Tables(strSht)

        cbFea.Items.Clear()      ' Data Clear 
        cbFea.Text = ""
        cbType.Text = ""            ' 설명 초기화 

        For i As Integer = 0 To Table.Rows.Count - 1    ' Data table Row 만큼 반복 -1은 마지막행은 Null
            If cbApp.Text = Table.Rows(i)(1).ToString() Then ' 선택 된 App과 Row, 필트(1)은 App, (2) 은 Feature
                Try
                    cbFea.Items.Add(Table.Rows(i)(2).ToString())
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            End If
        Next

        cbFea.Sorted = True

        'ComboBox1.Items 중복 삭제
        For i As Integer = cbFea.Items.Count - 1 To 1 Step -1
            If (cbFea.Items(i - 1) = cbFea.Items(i)) Then
                cbFea.Items.RemoveAt(i)
            End If
        Next
    End Sub
    Private Sub cbFea_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbFea.SelectedIndexChanged
        ' 대분류 Click 시 중분류에 맞도록
        Dim Table As DataTable = DS.Tables(strSht)

        cbType.Items.Clear()      ' Data Clear 
        cbType.Text = ""

        For i As Integer = 0 To Table.Rows.Count - 1    ' Data table Row 만큼 반복 -1은 마지막행은 Null
            If cbFea.Text = Table.Rows(i)(2).ToString() Then ' 선택 된 App과 Row, 필트(0)은 App, (1) 은 Feature
                Try
                    cbType.Items.Add(Table.Rows(i)(4).ToString())
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            End If
        Next

        cbType.Sorted = True

        'ComboBox1.Items 중복 삭제
        For i As Integer = cbType.Items.Count - 1 To 1 Step -1
            If (cbType.Items(i - 1) = cbType.Items(i)) Then
                cbType.Items.RemoveAt(i)
            End If
        Next
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles Add.Click
        Dim vSQL As String

        ' 미입력 된 부분 확인 하는 코드
        Dim a As Control
        For Each a In Me.Controls
            If TypeOf a Is GroupBox Then
                For Each b In a.Controls
                    If TypeOf b Is TextBox Then
                        If b.Text = "" Then
                            MsgBox(b.Tag + "가 입력되지 않았습니다.")
                            Exit Sub
                        End If
                    ElseIf TypeOf b Is ComboBox Then
                        If b.Text = "" And b.Enabled = True Then
                            MsgBox(b.Tag + "가 입력되지 않았습니다.")
                            Exit Sub
                        End If
                    End If
                Next
            End If
        Next

        vSQL = "Select * from [" & strSht & "] where [App] = '" & cbApp.Text & "' and [Feature] = '" & cbFea.Text &
            "'and [Test Type] = '" & cbType.Text & "'" 'and [Import] = 'N'"

        DS2.Clear()
        DA = New OleDbDataAdapter(vSQL, vConn)
        DA.Fill(DS2, strSht)

        Dim Table As DataTable = DS2.Tables(strSht)


        ' select문 결과 1 즉, Type가 있고 import가 N인 경우 
        If Table.Rows.Count = 1 And Table.Rows(0)(5).ToString = "N" Then
            '조회할SQL을 만들어서 String변수에 넣는다.
            vSQL = " UPDATE [" & strSht & "]SET [App] = '" & cbApp.Text & "',[Feature] = '" & cbFea.Text & "',[Feature_Description] = '" & txtFeaDes.Text & "',[Test Type] = '" & cbType.Text &
                "',[Import] = '" & cbImport.Text & "',[기본검증] = '" & txtTest.Text & "',[Around] = '" & txtAround.Text & "',[선정기준] = '" & cbY.Text & "'"
            ' vSQL = vSQL + "where [App] = '" & cbApp.Text & "' and [Feature] = '" & cbFea.Text & "'and [Test Type] = '" & cbType.Text & "'"
            vSQL = vSQL + "where [ID] = " & Table.Rows(0)(0).ToString

            'vSQL = "INSERT INTO [" & strSht & "]([App],[Feature],[Feature_Description],[Test Type],[기본검증],[Import],Around,선정기준) "
            'vSQL = vSQL + "VALUES ('" & cbApp.Text & "','" & cbFea.Text & "','" & txtFeaDes.Text & "','" & cbType.Text & "','" _
            '& txtTest.Text & "','" & cbImport.Text & "','" & txtAround.Text & "','" & cbY.Text & "');"
            DA = New OleDbDataAdapter(vSQL, vConn)
            DA.Fill(DS, strSht)

            MsgBox(cbApp.Text + ">" + cbFea.Text + ">" + cbType.Text + " 이(가) 추가되었습니다.")
            Add_History("추가", cbApp.Text + ">" + cbFea.Text + ">" + cbType.Text + "를 추가", txtName.Text)

            Form_Refresh()
        ElseIf Table.Rows.Count >= 1 And Table.Rows(0)(5).ToString = "Y" Then
            vSQL = "Select * from [" & strSht & "] where [App] = '" & cbApp.Text & "' and [Feature] = '" & cbFea.Text &
           "'and [Test Type] = '" & cbType.Text & "' and [Import] = 'Y'" & "and [선정기준] = '" & cbY.Text & "'"

            DS2.Clear()
            DA = New OleDbDataAdapter(vSQL, vConn)
            DA.Fill(DS2, strSht)

            Table = DS2.Tables(strSht)
            If Table.Rows.Count = 0 Then

                '조회할SQL을 만들어서 String변수에 넣는다.
                vSQL = "INSERT INTO [" & strSht & "]([App],[Feature],[Feature_Description],[Test Type],[기본검증],[Import],Around,선정기준) "
                vSQL = vSQL + "VALUES ('" & cbApp.Text & "','" & cbFea.Text & "','" & txtFeaDes.Text & "','" & cbType.Text & "','" _
                    & txtTest.Text & "','" & cbImport.Text & "','" & txtAround.Text & "','" & cbY.Text & "');"
                DA = New OleDbDataAdapter(vSQL, vConn)
                DA.Fill(DS, strSht)

                MsgBox(cbApp.Text + ">" + cbFea.Text + ">" + cbType.Text + " 이(가) 추가되었습니다.")
                Add_History("추가", cbApp.Text + ">" + cbFea.Text + ">" + cbType.Text + "를 추가", txtName.Text)

                Form_Refresh()

            Else
                MsgBox(cbApp.Text + ">" + cbFea.Text + ">" + cbType.Text + " [" + cbY.Text + "] 는 이미 있습니다.")

            End If

        ElseIf Table.Rows.Count = 0 Then
            '조회할SQL을 만들어서 String변수에 넣는다.
            vSQL = "INSERT INTO [" & strSht & "]([App],[Feature],[Feature_Description],[Test Type],[기본검증],[Import],Around,선정기준) "
            vSQL = vSQL + "VALUES ('" & cbApp.Text & "','" & cbFea.Text & "','" & txtFeaDes.Text & "','" & cbType.Text & "','" _
                & txtTest.Text & "','" & cbImport.Text & "','" & txtAround.Text & "','" & cbY.Text & "');"
            DA = New OleDbDataAdapter(vSQL, vConn)
            DA.Fill(DS, strSht)

            MsgBox(cbApp.Text + ">" + cbFea.Text + ">" + cbType.Text + " 이(가) 추가되었습니다.")
            Add_History("추가", cbApp.Text + ">" + cbFea.Text + ">" + cbType.Text + "를 추가", txtName.Text)

            Form_Refresh()
        End If

        '' select문 결과 0 즉, 없을 경우 추가
        'If Table.Rows.Count = 0 Then

        '    '조회할SQL을 만들어서 String변수에 넣는다.
        '    vSQL = "INSERT INTO [" & strSht & "]([App],[Feature],[Feature_Description],[Test Type],[기본검증],[Import],Around,선정기준) "
        '    vSQL = vSQL + "VALUES ('" & cbApp.Text & "','" & cbFea.Text & "','" & txtFeaDes.Text & "','" & cbType.Text & "','" _
        '        & txtTest.Text & "','" & cbImport.Text & "','" & txtAround.Text & "','" & cbY.Text & "');"
        '    DA = New OleDbDataAdapter(vSQL, vConn)
        '    DA.Fill(DS, strSht)

        '    MsgBox(cbApp.Text + ">" + cbFea.Text + ">" + cbType.Text + " 이(가) 추가되었습니다.")
        '    Add_History("추가", cbApp.Text + ">" + cbFea.Text + ">" + cbType.Text + "를 추가", txtName.Text)

        '    Form_Refresh()

        'Else
        '    MsgBox(cbApp.Text + ">" + cbFea.Text + ">" + cbType.Text + "는 이미 있습니다.")
        'End If
    End Sub
    Private Sub btnMod_Click(sender As Object, e As EventArgs) Handles btnMod.Click
        Dim vSQL As String

        ' 미입력 된 부분 확인 하는 코드
        Dim a As Control
        For Each a In Me.Controls
            If TypeOf a Is GroupBox Then
                For Each b In a.Controls
                    If TypeOf b Is TextBox Then
                        If b.Text = "" Then
                            MsgBox(b.Tag + "가 입력되지 않았습니다.")
                            Exit Sub
                        End If
                    ElseIf TypeOf b Is ComboBox Then
                        If b.Text = "" And b.Enabled = True Then
                            MsgBox(b.Tag + "가 입력되지 않았습니다.")
                            Exit Sub
                        End If
                    End If
                Next
            End If
        Next

        vSQL = "Select * from [" & strSht & "] where [App] = '" & cbApp.Text & "' and [Feature] = '" & cbFea.Text & "'and [Test Type] = '" & cbType.Text & "'and [선정기준] = '" & cbY.Text & "'"

        DS2.Clear()
        DA = New OleDbDataAdapter(vSQL, vConn)
        DA.Fill(DS2, strSht)

        Dim Table As DataTable = DS2.Tables(strSht)

        ' select문 결과 0 즉, 없을 경우 추가
        If Table.Rows.Count <> 0 Then

            '조회할SQL을 만들어서 String변수에 넣는다.
            vSQL = " UPDATE [" & strSht & "]SET [App] = '" & cbApp.Text & "',[Feature] = '" & cbFea.Text & "',[Feature_Description] = '" & txtFeaDes.Text & "',[Test Type] = '" & cbType.Text &
                "',[Import] = '" & cbImport.Text & "',[기본검증] = '" & txtTest.Text & "',[Around] = '" & txtAround.Text & "',[선정기준] = '" & cbY.Text & "'"
            vSQL = vSQL + "where [ID] = " & Table.Rows(0)(0).ToString

            DA = New OleDbDataAdapter(vSQL, vConn)
            DA.Fill(DS, strSht)

            MsgBox(cbApp.Text + ">" + cbFea.Text + ">" + cbType.Text & " 이(가) 수정되었습니다.")
            Add_History("수정", cbApp.Text + ">" + cbFea.Text + ">" + cbType.Text + "을 수정", txtName.Text)

            Form_Refresh()

        Else
            MsgBox(cbApp.Text + ">" + cbFea.Text + ">" + cbType.Text & "는 존재하지 않아 수정 할 수 없습니다. ")
        End If
    End Sub
    Private Sub btnDel_Click(sender As Object, e As EventArgs) Handles btnDel.Click
        Dim vSQL As String
        Dim iQuestion As String
        ' 미입력 된 부분 확인 하는 코드
        Dim a As Control
        For Each a In Me.Controls
            If TypeOf a Is GroupBox Then
                For Each b In a.Controls
                    If TypeOf b Is TextBox Then
                        If b.Text = "" Then
                            MsgBox(b.Tag + "가 입력되지 않았습니다.")
                            Exit Sub
                        End If
                    ElseIf TypeOf b Is ComboBox Then
                        If b.Text = "" And b.Enabled = True Then
                            MsgBox(b.Tag + "가 입력되지 않았습니다.")
                            Exit Sub
                        End If
                    End If
                Next
            End If
        Next

        vSQL = "Select * from [" & strSht & "] where [App] = '" & cbApp.Text & "' and [Feature] = '" & cbFea.Text & "'and [Test Type] = '" & cbType.Text & "'and [선정기준] = '" & cbY.Text & "'"

        DS2.Clear()
        DA = New OleDbDataAdapter(vSQL, vConn)
        DA.Fill(DS2, strSht)

        Dim Table As DataTable = DS2.Tables(strSht)

        Dim strText As String = SearchApp.Text + ">" + SearchFea.Text + ">" + SearchType.Text
        Dim strDelText As String = cbApp.Text + ">" + cbFea.Text + ">" + cbType.Text

        ' select문 결과 0 즉, 없을 경우 추가
        If strText = strDelText Then
            ' 삭제 하는 쿼리
            iQuestion = MsgBox(strText & "를 정말 삭제하시겠습니까?", vbYesNo, "gyeongmin.yeom@lgepartner.com")
            If iQuestion = 6 Then
                DA = New OleDbDataAdapter("Delete from [" & strSht & "]  WHERE [ID] = " & Table.Rows(0)(0).ToString, vConn)
                DA.Fill(DS2, strSht)
            Else
                Exit Sub
            End If
            MsgBox("성공적으로 삭제 하였습니다.")


            DA = New OleDbDataAdapter(vSQL, vConn)
            DA.Fill(DS, strSht)

            Add_History("삭제", cbApp.Text + ">" + cbFea.Text + ">" + cbType.Text + "을 삭제", txtName.Text)

            Form_Refresh()

        Else
            MsgBox("검색 후 수정 하지 말고 삭제를 진행 해 주세요.")
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Form_Refresh()
    End Sub

    Private Sub SearchY_SelectedIndexChanged(sender As Object, e As EventArgs) Handles SearchY.SelectedIndexChanged
        Dim vSQL As String
        ' app과 feature가 있는지 검색하는 부분

        vSQL = "Select * from [" & strSht & "] where [App] = '" & SearchApp.Text & "' and [Feature] = '" & SearchFea.Text &
            "'and [Test Type] = '" & SearchType.Text & "'and [선정기준] = '" & SearchY.Text & "'"
        DS2.Clear()
        DA = New OleDbDataAdapter(vSQL, vConn)
        DA.Fill(DS2, strSht)

        Dim Table As DataTable = DS2.Tables(strSht)

        If Table.Rows.Count = 0 Then
            If Table.Rows(0)(8).ToString = "" Then
                vSQL = "Select * from [" & strSht & "] where [App] = '" & SearchApp.Text & "' and [Feature] = '" & SearchFea.Text &
            "'and [Test Type] = '" & SearchType.Text & "'and [Import] = 'N'"
                DS2.Clear()
                DA = New OleDbDataAdapter(vSQL, vConn)
                DA.Fill(DS2, strSht)

                If Table.Rows.Count = 0 Then
                    MsgBox("검색결과가 없습니다. 추가가 가능합니다.")
                    Exit Sub
                Else
                    MsgBox("수정, 삭제가 가능합니다.")
                End If
            End If
        End If

        cbApp.Text = SearchApp.Text
        cbFea.Text = SearchFea.Text
        cbType.Text = SearchType.Text
        cbY.Text = Table.Rows(0)(8).ToString
        cbImport.Text = Table.Rows(0)(5).ToString
        txtFeaDes.Text = Table.Rows(0)(3).ToString
        txtTest.Text = Table.Rows(0)(6).ToString
        txtAround.Text = Table.Rows(0)(7).ToString
    End Sub

    Private Sub SearchType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles SearchType.SelectedIndexChanged
        Dim vSQL As String
        ' app과 feature가 있는지 검색하는 부분

        vSQL = "Select * from [" & strSht & "] where [App] = '" & SearchApp.Text & "' and [Feature] = '" & SearchFea.Text &
            "'and [Test Type] = '" & SearchType.Text & "'"
        DS2.Clear()
        DA = New OleDbDataAdapter(vSQL, vConn)
        DA.Fill(DS2, strSht)

        Dim Table As DataTable = DS2.Tables(strSht)

        If Table.Rows.Count = 1 And Table.Rows(0)(5).ToString = "N" Then
            cbApp.Text = SearchApp.Text
            cbFea.Text = SearchFea.Text
            cbType.Text = SearchType.Text
            cbY.Text = Table.Rows(0)(8).ToString
            cbImport.Text = Table.Rows(0)(5).ToString
            txtFeaDes.Text = Table.Rows(0)(3).ToString
            txtTest.Text = Table.Rows(0)(6).ToString
            txtAround.Text = Table.Rows(0)(7).ToString

            SearchY.Enabled = False

            MsgBox("수정, 삭제가 가능합니다.")
        ElseIf Table.Rows(0)(5).ToString() = "Y" Then
            vSQL = "Select * from [" & strSht & "] where [App] = '" & SearchApp.Text & "' and [Feature] = '" & SearchFea.Text &
                        "'and [Test Type] = '" & SearchType.Text & "'" 'and [Import] = 'N'"

            DS2.Clear()
            DA = New OleDbDataAdapter(vSQL, vConn)
            DA.Fill(DS2, strSht)

            Table = DS2.Tables(strSht)
            SearchY.Enabled = True
            SearchY.Items.Clear()
            SearchY.Text = ""

            For i As Integer = 0 To Table.Rows.Count - 1            ' Data table Row 만큼 반복 -1은 마지막행은 Null

                Try
                    If Not SearchY.Items.Contains(Table.Rows(i)(8).ToString()) And Table.Rows(i)(8).ToString() <> "" Then  ' 중복 없이 Item 추가
                        SearchY.Items.Add(Table.Rows(i)(8).ToString())
                    End If

                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try

            Next

        End If
    End Sub

    Private Sub cbImport_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbImport.SelectedIndexChanged
        If cbImport.Text = "N" Then
            cbY.Enabled = False
            txtTest.Enabled = False
            txtAround.Enabled = False
        ElseIf cbImport.Text = "Y" Then
            cbY.Enabled = True
            txtTest.Enabled = True
            txtAround.Enabled = True
        End If
    End Sub

    Private Sub Search_Click(sender As Object, e As EventArgs) Handles Search.Click

    End Sub
End Class