Imports System.Windows.Forms
Imports System.Data
Imports System.Data.OleDb
Public Class Consumer_Admin
    Dim itemSta As String
    Private DS As DataSet = New DataSet
    Private DA As OleDbDataAdapter = New OleDbDataAdapter()
    Public ordAdapter As OleDbDataAdapter = New OleDbDataAdapter()
    Private strSQL As String
    ' Private adminMainForm = New AdminMain
    'Private Main_Form As New Main_Form
    Private vConn As OleDbConnection
    Private vConn2 As OleDbConnection
    Dim strSht As String = "Request_Consumer"

    Private Sub Form4_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '관리자 이름 고정
        Dim strUserName As String = Nothing
        Dim XML As New XML

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
            XML.vCon_Call(vCon)
            ' Connect 연결
            vConn2 = New OleDbConnection(vCon)
            vConn2.Open()

            ' vcon가져오는 함수
            XML.vCon_Admin_Call(vCon)
            ' Connect 연결
            vConn = New OleDbConnection(vCon)
            vConn.Open()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "DB Open에러")
            Exit Sub
        End Try



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

        With cbCa.Items
            .Add("SW Interrupt_내부,외부")
            .Add("SW Interrupt_사용자Action")
            .Add("HW Interrupt")
            .Add("Environment(환경)")
            .Add("User Pattern")
        End With

        With cbY.Items
            .Add("Y_Sanity")
            .Add("Y_Basic")
            .Add("Y_Full")
        End With
        Form_Refresh()
    End Sub

    Private Sub show_Activity()
        ' 선택 된 Row의 ID를 가져와 저장하는 변수
        Dim rowCount As Integer = DataGridView1.CurrentRow.Index
        If txtDes.Text = DataGridView1.Item(6, rowCount).Value And DataGridView1.Item(1, rowCount).Value = "수정" Then

            Dim strSht As String = "용어"  ' DB 시트 이름 지정
            Dim vSQL As String
            Dim Table As DataTable = Nothing

            Dim vSQLdepth1, vSQLdepth2, vSQLdepth3, vSQLdepth4, vSQLdepth5 As String


            vSQLdepth1 = " [Interrupt type] LIKE '%" & txtType.Text & "%'"
            If txtModule.Text = "" Then
                vSQLdepth2 = ""
            Else
                vSQLdepth2 = " AND [Module] LIKE '%" & txtModule.Text & "%'"
            End If
            If txtSub.Text = "" Then
                vSQLdepth3 = ""
            Else
                vSQLdepth3 = " AND [Sub Module] LIKE '%" & txtSub.Text & "%'"
            End If
            If txtFea.Text = "" Then
                vSQLdepth4 = ""
            Else
                vSQLdepth4 = " AND [Test Feature] LIKE '%" & txtFea.Text & "%'"
            End If
            If txtUser.Text = "" Then
                vSQLdepth5 = ""
            Else
                vSQLdepth5 = " AND [User Condition] LIKE '%" & txtUser.Text & "%'"
            End If

            ' 요청DB에 요청한 용어가 있는지 확인하는 쿼리문
            vSQL = "Select Activity from [" & DataGridView1.Item(2, rowCount).Value & "] where " & vSQLdepth1 & vSQLdepth2 & vSQLdepth3 & vSQLdepth4 & vSQLdepth5

            Try
                DA = New OleDbDataAdapter(vSQL, vConn2)
                DA.Fill(DS, strSht)
                Table = DS.Tables(strSht)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

            txtActivity.Text = Table.Rows(0).Item(0).ToString
            Table.Clear()       ' Table에 값이 저장되어있는 것을 초기화 해줌
        Else
            Exit Sub
        End If
    End Sub

    Private Sub btnMod_Click(sender As Object, e As EventArgs) Handles btnMod.Click
        Dim strDate As String
        Dim vSQL As String
        Dim Table As DataTable = Nothing
        Dim ConsumerID As String
        Dim vSQLdepth1, vSQLdepth2, vSQLdepth3, vSQLdepth4, vSQLdepth5 As String

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
            ' 입력되지 않은 부분이 있을때의 예외처리
            If cbCa.Text = "" OrElse cbY.Text = "" OrElse txtName.Text = "" OrElse cbSta.Text = "" OrElse txtType.Text = "" OrElse txtDes.Text = "" Then
                MsgBox("입력 및 선택이 되지 않은 항목이 있습니다. 다시 확인해 주세요")
                Exit Sub
            End If

            If itemSta = "수정" Then ' 입력이 모두 다 되었을때 요청 DB, 용어 DB모두 업데이트 해줌

                '요청 DB의 상태와 담당자 변경
                Try
                    DA = New OleDbDataAdapter("UPDATE [" & strSht & "] SET [상태]='" & cbSta.Text & "',[담당자]='" & txtName.Text & "',[상태변경날짜]='" & strDate & "' " &
                  "WHERE [ID]= " & DataGridView1.Item(0, rowCount).Value, vConn)

                    DA.Fill(DS, strSht)
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try

                ' ConsumerDB의 해당 ID를 가져오기 위한 쿼리
                vSQLdepth1 = " [Interrupt type] LIKE '%" & txtType.Text & "%'"
                If txtModule.Text = "" Then
                    vSQLdepth2 = ""
                Else
                    vSQLdepth2 = " AND [Module] LIKE '%" & txtModule.Text & "%'"
                End If
                If txtSub.Text = "" Then
                    vSQLdepth3 = ""
                Else
                    vSQLdepth3 = " AND [Sub Module] LIKE '%" & txtSub.Text & "%'"
                End If
                If txtFea.Text = "" Then
                    vSQLdepth4 = ""
                Else
                    vSQLdepth4 = " AND [Test Feature] LIKE '%" & txtFea.Text & "%'"
                End If

                If txtUser.Text = "" Then
                    vSQLdepth5 = ""
                Else
                    vSQLdepth5 = " AND [User Condition] LIKE '%" & txtUser.Text & "%'"
                End If


                ' 요청DB에 요청한 용어가 있는지 확인하는 쿼리문
                vSQL = "Select [ID] from [" & cbCa.Text & "] where " & vSQLdepth1 & vSQLdepth2 & vSQLdepth3 & vSQLdepth4 & vSQLdepth5

                Try
                    DA = New OleDbDataAdapter(vSQL, vConn)
                    DA.Fill(DS, cbCa.Text)
                    Table = DS.Tables(cbCa.Text)
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try

                ConsumerID = Table.Rows(0).Item(0).ToString
                Table.Clear()       ' Table에 값이 저장되어있는 것을 초기화 해줌

                'Consumer DB 데이터 업데이트 해주는 부분

                If cbCa.Text <> "HW_고객행동패턴" Then
                    vSQL = "UPDATE [" & cbCa.Text & "] "
                    vSQL = vSQL + "SET [Interrupt type] = '" & txtType.Text & "',[Module] = '" & txtModule.Text & "',[Sub Module] = '" & txtSub.Text &
                           "',[Test Feature] = '" & txtFea.Text & "',[Activity] = '" & txtDes.Text & "',[선정기준] = '" & cbY.Text & "' "

                    vSQL = vSQL + "Where [ID] = " & ConsumerID

                    Try
                        DA = New OleDbDataAdapter(vSQL, vConn2)
                        DA.Fill(DS, cbCa.Text)
                        MsgBox("성공적으로 수정되었습니다.")
                    Catch ex As Exception
                        MsgBox(ex.Message)
                    End Try

                Else
                    vSQL = "UPDATE [" & cbCa.Text & "] "
                    vSQL = vSQL + "SET [Interrupt type] = '" & txtType.Text & "',[Module] = '" & txtModule.Text & "',[Sub Module] = '" & txtSub.Text &
                       "',[Test Feature] = '" & txtFea.Text & "',[User Condition] = '" & txtUser.Text & "',[Activity] = '" & txtDes.Text & "',[선정기준] = '" & cbY.Text & "' "
                    vSQL = vSQL + "Where [ID] = " & ConsumerID
                    Try
                        DA = New OleDbDataAdapter(vSQL, vConn2)
                        DA.Fill(DS, cbCa.Text)
                        MsgBox("성공적으로 수정되었습니다.")
                    Catch ex As Exception
                        MsgBox(ex.Message)
                    End Try
                End If
                Form_Refresh()

            ElseIf itemSta = "Depth 추가" Then

                If cbCa.Text <> "HW_고객행동패턴" Then
                    vSQL = "select * from [" & cbCa.Text & "] where [Interrupt type]='" & txtType.Text & "' and [Module]='" & txtModule.Text & "' and [Sub Module]='" & txtSub.Text &
                        "' and [Test Feature]='" & txtFea.Text & "' and [Activity]='" & txtDes.Text & "' and [선정기준]='" & cbY.Text & "' "
                    Try
                        DA = New OleDbDataAdapter(vSQL, vConn2)
                        DA.Fill(DS, cbCa.Text)
                        Table = DS.Tables(cbCa.Text)
                    Catch ex As Exception
                        MsgBox(ex.Message)
                    End Try
                Else
                    vSQL = "select * from [" & cbCa.Text & "] where [Interrupt type]='" & txtType.Text & "'and [Module]='" & txtModule.Text & "' and [Sub Module]='" & txtSub.Text &
                        "' and [Test Feature]='" & txtFea.Text & "' and [[User Condition]='" & txtUser.Text & "' and [Activity]='" & txtDes.Text & "' and [선정기준]='" & cbY.Text & "' "
                    Try
                        DA = New OleDbDataAdapter(vSQL, vConn2)
                        DA.Fill(DS, cbCa.Text)
                        Table = DS.Tables(cbCa.Text)
                    Catch ex As Exception
                        MsgBox(ex.Message)
                    End Try
                End If

                If Table.Rows.Count > 0 Then
                    MsgBox("이미 존재하는 항목 입니다.")
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

                '''''''''''''''''''''''''''
                'vSQL = "INSERT INTO [Request_Consumer$] ([App],[Feature],[Description_Feature]) " & "VALUES ('" & txtAddApp.Text & "','" & txtAddFea.Text & "','" & txtDesFea.Text & "');"
                If cbCa.Text <> "HW_고객행동패턴" Then
                    vSQL = "INSERT INTO [" & cbCa.Text & "] ([Interrupt type],[Module],[Sub Module],[Test Feature],[Activity],[선정기준]) "
                    vSQL = vSQL + "VALUES ('" & txtType.Text & "','" & txtModule.Text & "','" & txtSub.Text & "','" & txtFea.Text & "','" & txtDes.Text & "','" & cbY.Text & "'); "
                    Try
                        DA = New OleDbDataAdapter(vSQL, vConn2)
                        DA.Fill(DS, cbCa.Text)
                        MsgBox("성공적으로 추가되었습니다.")
                    Catch ex As Exception
                        MsgBox(ex.Message)
                    End Try
                Else
                    vSQL = "INSERT INTO [" & cbCa.Text & "] ([Interrupt type],[Module],[Sub Module],[Test Feature],[User Condition],[Activity],[선정기준]) "
                    vSQL = vSQL + "VALUES ('" & txtType.Text & "','" & txtModule.Text & "','" & txtSub.Text & "','" & txtFea.Text & "','" & txtUser.Text & "','" & txtDes.Text & "','" & cbY.Text & "'); "
                    Try
                        DA = New OleDbDataAdapter(vSQL, vConn2)
                        DA.Fill(DS, cbCa.Text)
                        MsgBox("성공적으로 추가되었습니다.")
                    Catch ex As Exception
                        MsgBox(ex.Message)
                    End Try
                End If
                Form_Refresh()

            End If
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Form_Refresh()
    End Sub

    Private Sub btnDel_Click(sender As Object, e As EventArgs) Handles btnDel.Click
        Dim iQuestion As String

        ' 선택 된 Row의 ID를 가져와 저장하는 변수
        Dim rowCount As Integer = DataGridView1.CurrentRow.Index

        iQuestion = MsgBox(DataGridView1.Item(4, rowCount).Value & " 을 선택하셨습니다." & vbCrLf &
           "정말 삭제 하시겠습니까?", vbYesNo, "lee.sunbae@lgepartner.com")
        If iQuestion = 6 Then
            DA = New OleDbDataAdapter("Delete from [" & strSht & "]  WHERE ID= " & DataGridView1.Item(0, rowCount).Value, vConn)
            DA.Fill(DS, strSht)
            MsgBox(DataGridView1.Item(4, rowCount).Value & " 을(를) 삭제되었습니다.")
            Form_Refresh()

        Else
            Exit Sub
        End If
    End Sub
    Public Sub Form_Refresh()
        '###### 데이터그리드뷰 띄어줘 관리/소통 하는 시스템######


        ' 초기화 해주는 코드
        DataGridView1.DataSource = Nothing
        DS.Clear()

        DA = New OleDbDataAdapter("Select * from [" & strSht & "] Where [Depth] > '' order by [ID] asc", vConn)
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

    Private Sub DataGridView1_Click(sender As Object, e As EventArgs) Handles DataGridView1.Click
        Dim depth As String
        Dim Depth1 As String = Nothing
        Dim depth2 As String = Nothing
        Dim depth3 As String = Nothing
        Dim depth4 As String = Nothing
        Dim depth5 As String = Nothing
        Dim strTemp5 As String

        ' 선택 된 Row의 ID를 가져와 저장하는 변수
        Dim rowCount As Integer = DataGridView1.CurrentRow.Index

        ' 기존 값 초기화
        cbCa.Text = ""
        txtName.Text = ""
        cbSta.Text = ""
        txtDes.Text = ""
        cbY.Text = ""
        txtType.Text = ""
        txtModule.Text = ""
        txtSub.Text = ""
        txtFea.Text = ""
        txtUser.Text = ""

        depth = DataGridView1.Item(4, rowCount).Value
        itemSta = DataGridView1.Item(1, rowCount).Value

        ' Depth 를 > 기준으로 나누어 각자 저장 해줌
        If InStr(depth, ">") > 0 Then

            strTemp5 = depth

            Depth1 = Microsoft.VisualBasic.Left(strTemp5, InStr(strTemp5, ">") - 1)             'Type
            strTemp5 = Mid(strTemp5, InStr(strTemp5, ">") + 1)
            If InStr(strTemp5, ">") Then
                depth2 = Microsoft.VisualBasic.Left(strTemp5, InStr(strTemp5, ">") - 1)         'Module
                strTemp5 = Mid(strTemp5, InStr(strTemp5, ">") + 1)
                If InStr(strTemp5, ">") Then
                    depth3 = Microsoft.VisualBasic.Left(strTemp5, InStr(strTemp5, ">") - 1)     'Sub Module
                    strTemp5 = Mid(strTemp5, InStr(strTemp5, ">") + 1)
                    If InStr(strTemp5, ">") Then
                        depth4 = Microsoft.VisualBasic.Left(strTemp5, InStr(strTemp5, ">") - 1) 'Test Feature
                        depth5 = Mid(strTemp5, InStr(strTemp5, ">") + 1)                        'User Condition
                    Else
                        depth4 = strTemp5
                        depth5 = ""
                    End If
                Else
                    depth3 = strTemp5
                    depth4 = ""
                    depth5 = ""
                End If
            Else
                depth2 = strTemp5
                depth3 = ""
                depth4 = ""
                depth5 = ""
            End If
        Else
            Depth1 = depth
        End If


        ' 각 각 폼에 List Box 및 개체들에게 값을 넣어주기 위함.
        If IsDBNull(DataGridView1.Item(2, rowCount).Value) = False Then cbCa.Text = DataGridView1.Item(2, rowCount).Value Else cbCa.Text = ""
        If IsDBNull(DataGridView1.Item(8, rowCount).Value) = False Then txtName.Text = DataGridView1.Item(8, rowCount).Value Else txtName.Text = ""
        If IsDBNull(DataGridView1.Item(9, rowCount).Value) = False Then cbSta.Text = DataGridView1.Item(9, rowCount).Value Else cbSta.Text = ""
        If IsDBNull(DataGridView1.Item(6, rowCount).Value) = False Then txtDes.Text = DataGridView1.Item(6, rowCount).Value Else txtDes.Text = ""
        If IsDBNull(DataGridView1.Item(3, rowCount).Value) = False Then cbY.Text = DataGridView1.Item(3, rowCount).Value Else cbY.Text = ""
        txtType.Text = Depth1
        txtModule.Text = depth2
        txtSub.Text = depth3
        txtFea.Text = depth4
        txtUser.Text = depth5

        Label10.Text = "상세내용"

        If txtType.Text = "HW_고객행동패턴" Then
            txtUser.Enabled = True
        Else
            txtUser.Enabled = False
        End If
        show_Activity()
    End Sub

End Class