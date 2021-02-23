Imports System.Windows.Forms
Imports System.Data
Imports System.Data.OleDb

Public Class AppFeature_Admin

    Private DS As DataSet = New DataSet
    Private DA As OleDbDataAdapter = New OleDbDataAdapter()
    Public ordAdapter As OleDbDataAdapter = New OleDbDataAdapter()
    Private vConn As OleDbConnection
    Private vCon As String = Nothing
    Dim strSht As String = "Request_App,Feature"

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Form_Refresh()
    End Sub
    Public Sub Form_Refresh()
        '###### 데이터그리드뷰 띄어줘 관리/소통 하는 시스템######

        ' 초기화 해주는 코드
        DataGridView1.DataSource = Nothing
        DS.Clear()

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
            xml.vCon_Admin_Call(vCon)
            ' Connect 연결
            vConn = New OleDbConnection(vCon)
            vConn.Open()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "DB Open에러")
            Exit Sub
        End Try

        DA = New OleDbDataAdapter("Select ID, 앱명, Feature명, 상세설명, 요청자, 담당자, 상태, 날짜, 상태변경날짜 from [" & strSht & "]  order by [ID] asc", vConn)
        DA.Fill(DS, strSht)

        Dim Table As DataTable = DS.Tables(strSht)

        If Table.Rows.Count = 0 Then
            MsgBox("조회할 내용이 없습니다.",, "lee.sunbae@lgepartner.com")
            Exit Sub
        End If

        DataGridView1.DataSource = DS.Tables(0)
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
                        b.Text = ""
                    ElseIf TypeOf b Is ComboBox Then
                        b.text = ""
                    End If
                Next
            End If
        Next

    End Sub

    Private Sub Form5_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' 기본 값과 셋팅 설정
        With DataGridView1
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            .AllowUserToResizeColumns = True
            .AllowUserToResizeRows = True
            .MultiSelect = False
        End With
        With cbSta.Items
            .Add("Assigned")
            .Add("Open")
            .Add("Closed")
        End With

        Form_Refresh()
    End Sub

    Private Sub btnMod_Click(sender As Object, e As EventArgs) Handles btnMod.Click
        Dim strDate As String
        'Dim strSht As String = "App,Feature_DB"  ' DB 시트 이름 지정
        Dim strSht2 As String = "TD_AF_Des"  ' DB 시트 이름 지정
        Dim Table As DataTable = Nothing

        '요청 DB 날짜를 저장하는 부분
        strDate = Now()

        ' 선택 된 Row의 ID를 가져와 저장하는 변수
        Dim rowCount As Integer = DataGridView1.CurrentRow.Index




        '상태가 open, closed, 일
        If cbSta.Text = "Assigned" Then
            MsgBox("상태를 변경해 주세요")
            Exit Sub
        ElseIf cbSta.Text = "Open" Then ' 상태가 open일때 상태와 담당자만 변경
            If txtName.Text = "" Then
                MsgBox("담당자 이름을 써주세요")
                Exit Sub
            Else
                '/****************************************************
                Try
                    DA = New OleDbDataAdapter("UPDATE [" & strSht & "] SET [상태]='" & cbSta.Text & "',[담당자]='" & txtName.Text & "',[상태변경날짜]='" & strDate & "' " &
                "WHERE [ID]= " & DataGridView1.Item(0, rowCount).Value, vConn)

                    DA.Fill(DS, strSht)

                    MsgBox("상태와 담당자 이(가) 수정되었습니다.")
                    Form_Refresh()
                Catch ex As Exception
                    MsgBox(ex.Message)

                End Try
                Exit Sub
            End If
        ElseIf cbSta.Text = "Closed" Then '  상태가 Closed일때
            Dim xml As New XML
            Dim vCon As String = Nothing
            Dim vConn2 As OleDbConnection
            ' vcon가져오는 함수
            xml.vCon_Call(vCon)
            ' Connect 연결
            vConn2 = New OleDbConnection(vCon)
            vConn2.Open()

            ' 입력되지 않은 부분이 있을때의 예외처리
            If txtApp.Text = "" Or txtName.Text = "" Or cbSta.Text = "" Or txtDes.Text = "" Then
                MsgBox("입력 및 선택이 되지 않은 항목이 있습니다. 다시 확인해 주세요")
                Exit Sub
            End If

            '요청 DB의 상태와 담당자 변경
            Try
                DA = New OleDbDataAdapter("UPDATE [" & strSht & "] SET [상태]='" & cbSta.Text & "',[담당자]='" & txtName.Text & "',[상태변경날짜]='" & strDate & "' " &
                  "WHERE [ID]= " & DataGridView1.Item(0, rowCount).Value, vConn)

                DA.Fill(DS, strSht)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

            ' app만 추가할 경우
            If txtFea.Text = "" Then

                Try
                    DA = New OleDbDataAdapter("Select * from [" & strSht2 & "] where app = '" & txtApp.Text & "'", vConn2)
                    DA.Fill(DS, strSht2)
                    Table = DS.Tables(strSht2)

                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try

                ' select문 결과 0 즉, 없을 경우 추가
                If Table.Rows.Count = 0 Then
                    '조회할SQL을 만들어서 String변수에 넣는다.
                    Try
                        DA = New OleDbDataAdapter("INSERT INTO [" & strSht2 & "] ([App]) " & "VALUES ('" & txtApp.Text & "');", vConn2)
                        DA.Fill(DS, strSht2)
                    Catch ex As Exception
                        MsgBox(ex.Message)
                    End Try
                    ' Recrdset Open 하는 부분
                    MsgBox(txtApp.Text & " App이 추가되었습니다.")
                    Form_Refresh()
                    Exit Sub
                Else
                    MsgBox(txtApp.Text & " App이(가) 이미 있습니다.")
                End If
            Else
                Try
                    DA = New OleDbDataAdapter("Select * from [" & strSht2 & "] where app = '" & txtApp.Text & "' and feature = '" & txtFea.Text & "';", vConn2)
                    DA.Fill(DS, strSht2)
                    Table = DS.Tables(strSht2)

                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try

                ' select문 결과 0 즉, 없을 경우 추가
                If Table.Rows.Count = 0 Then
                    Try
                        DA = New OleDbDataAdapter("INSERT INTO [" & strSht2 & "] ([App],[Feature],[Description_Feature]) " & "VALUES ('" & txtApp.Text & "','" & txtFea.Text & "','" & txtDes.Text & "');", vConn2)
                        DA.Fill(DS, strSht2)

                    Catch ex As Exception
                        MsgBox(ex.Message)
                    End Try
                    MsgBox(txtApp.Text & " App과 " & txtFea.Text & " 이(가) 추가되었습니다.")
                    Form_Refresh()

                    Exit Sub
                Else
                    MsgBox(txtApp.Text & " App과 " & txtFea.Text & " 이(가) 이미 있습니다.")
                End If
            End If
        End If
    End Sub

    Private Sub DataGridView1_Click(sender As Object, e As EventArgs) Handles DataGridView1.Click
        ' depth = DataGridView1.Columns(4).ToString
        'itemSta = ListView1.FocusedItem.SubItems(1).Text

        ' 선택 된 Row의 ID를 가져와 저장하는 변수
        Dim rowCount As Integer = DataGridView1.CurrentRow.Index

        ' 선택한 아이템을 빈칸에 넣어주는 작업
        If IsDBNull(DataGridView1.Item(1, rowCount).Value) = False Then txtApp.Text = DataGridView1.Item(1, rowCount).Value Else txtApp.Text = ""
        If IsDBNull(DataGridView1.Item(2, rowCount).Value) = False Then txtFea.Text = DataGridView1.Item(2, rowCount).Value Else txtFea.Text = ""
        If IsDBNull(DataGridView1.Item(3, rowCount).Value) = False Then txtActivity.Text = DataGridView1.Item(3, rowCount).Value Else txtActivity.Text = ""
        If IsDBNull(DataGridView1.Item(5, rowCount).Value) = False Then txtName.Text = DataGridView1.Item(5, rowCount).Value Else txtName.Text = ""
        If IsDBNull(DataGridView1.Item(6, rowCount).Value) = False Then cbSta.Text = DataGridView1.Item(6, rowCount).Value Else cbSta.Text = ""
        Label10.Text = "상세내용"
    End Sub

    Private Sub btnDel_Click(sender As Object, e As EventArgs) Handles btnDel.Click

        Dim iQuestion As String

        ' 선택 된 Row의 ID를 가져와 저장하는 변수
        Dim rowCount As Integer = DataGridView1.CurrentRow.Index

        iQuestion = MsgBox(txtApp.Text & " 을 선택하셨습니다." & vbCrLf &
           "정말 삭제 하시겠습니까?", vbYesNo, "lee.sunbae@lgepartner.com")
        If iQuestion = 6 Then

            DA = New OleDbDataAdapter("Delete from [" & strSht & "]  WHERE ID= " & DataGridView1.Item(0, rowCount).Value, vConn)
            DA.Fill(DS, strSht)
            MsgBox(DataGridView1.Item(1, rowCount).Value & " App과 " & DataGridView1.Item(2, rowCount).Value & " 이(가) 삭제되었습니다.")
            Form_Refresh()

        Else
            Exit Sub
        End If
    End Sub

End Class