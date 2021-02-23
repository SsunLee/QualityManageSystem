Imports System.Windows.Forms
Imports System.Data
Imports System.Data.OleDb
Public Class Tip_Admin_GM

    Dim itemSta As String
    Private DS As DataSet = New DataSet
    Private DA As OleDbDataAdapter = New OleDbDataAdapter()
    Public ordAdapter As OleDbDataAdapter = New OleDbDataAdapter()
    Private strSQL As String
    Private vConn As OleDbConnection
    Private vConn2 As OleDbConnection
    Dim strSht As String = "Request_Tip"
    Dim strSht2 As String = "Tip"

    Public Sub Form_Refresh()
        '###### 데이터그리드뷰 띄어줘 관리/소통 하는 시스템######

        ' 초기화 해주는 코드
        DataGridView1.DataSource = Nothing
        DS.Clear()


        DA = New OleDbDataAdapter("Select ID, App, Feature,[Test Type], Import, [Description_Test Type] as 기본검증, Around, 상태, 선정기준, 요청자, 담당자, 요청날짜, 최종수정날짜 from [" & strSht & "] order by [ID] asc", vConn)
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
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Form_Refresh()
    End Sub

    Private Sub Request_Tip_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try
            Dim XML As New XML
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
        ' Status Combox 값 넣어 주기
        With cbSta.Items
            .Add("Open")
            .Add("Closed")
        End With

        ' Priority Combobox 값 넣어 주기
        With PriTxt.Items
            .Add("Y_Sanity")
            .Add("Y_Basic")
            .Add("Y_Full")
        End With

        ' Y/N Combox 값 넣어 주기
        With ImportV.Items
            .Add("Y")
            .Add("N")
        End With

        Form_Refresh()
    End Sub
    Private Sub DataGridView1_Click(sender As Object, e As EventArgs) Handles DataGridView1.Click
        ' 선택 된 Row의 ID를 가져와 저장하는 변수
        Dim rowCount As Integer = DataGridView1.CurrentRow.Index
        Dim vSQL As String = Nothing

        ' 리스트를 클릭 마다 초기화 해주기 위함.
        AppTxt.Text = ""
        FeaTxt.Text = ""
        txtFeaDes.Text = ""
        TypeTxt.Text = ""
        Default_Test.Text = ""
        AroundTest.Text = ""
        PriTxt.Text = ""
        ImportV.Text = ""


        ' 각 각 폼에 List Box 및 개체들에게 값을 넣어주기 위함.
        If IsDBNull(DataGridView1.Item(1, rowCount).Value) = False Then AppTxt.Text = DataGridView1.Item(1, rowCount).Value Else AppTxt.Text = ""
        If IsDBNull(DataGridView1.Item(2, rowCount).Value) = False Then FeaTxt.Text = DataGridView1.Item(2, rowCount).Value Else FeaTxt.Text = ""
        If IsDBNull(DataGridView1.Item(3, rowCount).Value) = False Then TypeTxt.Text = DataGridView1.Item(3, rowCount).Value Else TypeTxt.Text = ""
        If IsDBNull(DataGridView1.Item(5, rowCount).Value) = False Then Default_Test.Text = DataGridView1.Item(5, rowCount).Value Else Default_Test.Text = ""
        If IsDBNull(DataGridView1.Item(6, rowCount).Value) = False Then AroundTest.Text = DataGridView1.Item(6, rowCount).Value Else AroundTest.Text = ""
        If IsDBNull(DataGridView1.Item(8, rowCount).Value) = False Then PriTxt.Text = DataGridView1.Item(8, rowCount).Value Else PriTxt.Text = ""
        If IsDBNull(DataGridView1.Item(4, rowCount).Value) = False Then ImportV.Text = DataGridView1.Item(4, rowCount).Value Else ImportV.Text = ""
        If IsDBNull(DataGridView1.Item(10, rowCount).Value) = False Then txtName.Text = DataGridView1.Item(10, rowCount).Value Else txtName.Text = ""
        If IsDBNull(DataGridView1.Item(7, rowCount).Value) = False Then cbSta.Text = DataGridView1.Item(7, rowCount).Value Else cbSta.Text = ""

        ' Tip(기본검증) DB에 이미 저장된 항목인지 검사하는 쿼리
        vSQL = "Select [Feature_Description] from [" & strSht2 & "] where [App] ='" & AppTxt.Text & "'and [Feature] ='" & FeaTxt.Text & "'and [Test Type]='" & TypeTxt.Text & "'"
        Dim DS2 As DataSet = New DataSet
        Dim Table As DataTable = Nothing
        DS2.Clear()
        Try
            Dim DA = New OleDbDataAdapter(vSQL, vConn2)
            DA.Fill(DS2, strSht2)
            Table = DS2.Tables(strSht2)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        If Table.Rows.Count > 0 Then
            txtFeaDes.Text = Table.Rows(0)(0).ToString
            'MsgBox("현재 이미 등록 된 항목 입니다.")
            Exit Sub
        Else
            txtFeaDes.Text = "Feature 에 설명이 없습니다."
            Exit Sub
        End If


    End Sub

    Private Sub btnMod_Click(sender As Object, e As EventArgs) Handles btnMod.Click
        Dim vSQL, strDate As String
        Dim itemSta As String

        '요청 DB 날짜를 저장하는 부분
        strDate = Now()

        ' 선택 된 Row의 ID를 가져와 저장하는 변수
        Dim rowCount As Integer = DataGridView1.CurrentRow.Index

        If AppTxt.Text = "" Or FeaTxt.Text = "" Or TypeTxt.Text = "" Or Default_Test.Text = "" Or Default_Test.Text = "" Then
            MsgBox("항목이 선택되지 않았습니다. 더블클릭하여 재시도 하세요.")
            Exit Sub
        End If

        ' Tip(기본검증) DB에 이미 저장된 항목인지 검사하는 쿼리
        vSQL = "Select * from [" & strSht2 & "] where [App] ='" & AppTxt.Text & "'and [Feature] ='" & FeaTxt.Text & "'and [Test Type]='" & TypeTxt.Text & "'and  [Import]='" & ImportV.Text
        'vSQL = vSQL + "'and  [기본검증]='" & Default_Test.Text & "'and  [Around]='" & AroundTest.Text & "'and  [선정기준]='" & PriTxt.Text & "'"
        vSQL = vSQL + "'and  [선정기준]='" & PriTxt.Text & "'"
        Dim Table As DataTable
        Try
            Dim DA = New OleDbDataAdapter(vSQL, vConn2)
            Dim iQuestion As String = Nothing

            DA.Fill(DS, strSht2)
            Table = DS.Tables(strSht2)

            If Table.Rows.Count > 0 Then
                iQuestion = MsgBox("현재 이미 등록 된 항목 입니다." & vbCr &
               "요청리스트에서 삭제 해 주시고 기본검증 '추가, 수정, 삭제' 메뉴에서 수정 해 주시기 바랍니다." & vbCr &
               "'추가, 수정 삭제' 메뉴를 열겠습니까?", vbYesNo, "lee.sunbae@lgepartner.com")
                If iQuestion = 6 Then
                    Dim Tip_Edit_GM As New Tip_Edit_GM

                    Tip_Edit_GM.Show()
                    Tip_Edit_GM.SearchApp.Text = AppTxt.Text
                    Tip_Edit_GM.SearchFea.Text = FeaTxt.Text
                    Tip_Edit_GM.SearchType.Text = TypeTxt.Text
                    Tip_Edit_GM.SearchY.Text = PriTxt.Text
                    Tip_Edit_GM.txtName.Text = txtName.Text

                Else
                    Exit Sub
                End If
                'MsgBox("현재 이미 등록 된 항목 입니다. 요청리스트에서 삭제 해 주시고 기본검증 '추가, 수정, 삭제' 메뉴에서 수정 해 주시기 바랍니다.")
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try




        '상태가 open, closed, 일
        If cbSta.Text = "Assigned" Then
            MsgBox("상태를 변경해 주세요")
            Exit Sub
        ElseIf cbSta.Text = "Open" Then ' 상태가 open일때 상태와 담당자만 변경
            If txtName.Text = " " Then
                MsgBox("담당자 이름을 써주세요")
                Exit Sub
            Else
                '요청 DB의 상태와 담당자 변경
                Try
                    DA = New OleDbDataAdapter("UPDATE [" & strSht & "] SET [상태]='" & cbSta.Text & "',[담당자]='" & txtName.Text & "',[최종수정날짜]='" & strDate & "' " &
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
            If AppTxt.Text = "" Or FeaTxt.Text = "" Or TypeTxt.Text = "" Or Default_Test.Text = "" Or Default_Test.Text = "" Or ImportV.Text = "" Or PriTxt.Text = "" Then
                MsgBox("입력 및 선택이 되지 않은 항목이 있습니다. 다시 확인해 주세요")
                Exit Sub
            End If
            itemSta = DataGridView1.Item(1, rowCount).Value

            '요청 DB의 상태와 담당자 변경
            Try
                DA = New OleDbDataAdapter("UPDATE [" & strSht & "] SET [상태]='" & cbSta.Text & "',[담당자]='" & txtName.Text & "',[최종수정날짜]='" & strDate & "' " &
                  "WHERE [ID]= " & DataGridView1.Item(0, rowCount).Value, vConn)

                DA.Fill(DS, strSht)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

            vSQL = "INSERT INTO [" & strSht2 & "] ([App],[Feature],[Feature_Description],[Test Type], [Import], [기본검증], [Around], [선정기준]) " & ""
            vSQL = vSQL + "VALUES ('" & AppTxt.Text & "','" & FeaTxt.Text & "','" & txtFeaDes.Text & "','" & TypeTxt.Text & "','" & ImportV.Text & "','" & Default_Test.Text & "','" & AroundTest.Text & "','" & PriTxt.Text & "')"

            Try
                Dim DA = New OleDbDataAdapter(vSQL, vConn2)
                DA.Fill(DS, strSht2)
                MsgBox(AppTxt.Text & "이(가) 추가되었습니다.")
                Form_Refresh()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Private Sub btnDel_Click(sender As Object, e As EventArgs) Handles btnDel.Click
        Dim iQuestion As String

        ' 선택 된 Row의 ID를 가져와 저장하는 변수
        Dim rowCount As Integer = DataGridView1.CurrentRow.Index
        If txtName.Text = " " Then
            MsgBox("담당자 이름을 써주세요")
            Exit Sub
        End If

        iQuestion = MsgBox(DataGridView1.Item(2, rowCount).Value & " 을 선택하셨습니다." & vbCrLf &
           "정말 삭제 하시겠습니까?", vbYesNo, "lee.sunbae@lgepartner.com")
        If iQuestion = 6 Then

            DA = New OleDbDataAdapter("Delete from [" & strSht & "]  WHERE ID= " & DataGridView1.Item(0, rowCount).Value, vConn)
            DA.Fill(DS, strSht)
            MsgBox(DataGridView1.Item(2, rowCount).Value & " 을(를) 삭제되었습니다.")
            Form_Refresh()
        Else
            Exit Sub
        End If
    End Sub
End Class