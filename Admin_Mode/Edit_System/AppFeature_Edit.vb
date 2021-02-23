
Imports System.Windows.Forms
Imports System.Data
Imports System.Data.OleDb
Public Class AppFeature_Edit
    Dim itemSta As String
    Private DS As DataSet = New DataSet
    Private DS2 As DataSet = New DataSet
    Private DA As OleDbDataAdapter = New OleDbDataAdapter()
    Public ordAdapter As OleDbDataAdapter = New OleDbDataAdapter()
    Private strSQL As String
    ' Private adminMainForm = New AdminMain
    'Private Main_Form As New Main_Form
    Private vConn As OleDbConnection
    Dim strSht As String = "TD_AF_Des"
    Dim strDate As String = Now()
    Private Sub AppFeature_Load(sender As Object, e As EventArgs) Handles MyBase.Load

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


        ' 초기화 해주는 코드
        If cbApp.DataSource Is DBNull.Value Or delApp.DataSource Is DBNull.Value Then
        Else
            cbApp.DataSource = Nothing
            delApp.DataSource = Nothing
            delApp.Text = ""
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

        Form_Refresh()

    End Sub
    Public Sub Form_Refresh()
        DS.Clear()
        DA = New OleDbDataAdapter("Select * from [" & strSht & "] order by [App] asc", vConn)
        DA.Fill(DS, strSht)

        Dim Table As DataTable = DS.Tables(strSht)
        Dim Table2 As DataTable

        If Table.Rows.Count = 0 Then
            MsgBox("조회할 내용이 없습니다.",, "lee.sunbae@lgepartner.com")
            Exit Sub
        End If

        Table = Table.DefaultView.ToTable(True, "App") ' 중복 제거하고 Table저장
        Table2 = Table.DefaultView.ToTable(True, "App") ' 중복 제거하고 Table저장


        With cbApp
            .DataSource = Table
            .DisplayMember = "App"
            .ValueMember = "App"
        End With
        With delApp
            .DataSource = Table2
            .DisplayMember = "App"
            .ValueMember = "App"
            .Text = ""
        End With

        'For Each a In Me.Controls
        '    If TypeOf a Is TextBox Then
        '        If a.Name <> "txtName" Then
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

    Private Sub cbApp_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbApp.SelectedIndexChanged
        ' App Click 시 Feature에 맞도록
        Dim Table As DataTable = DS.Tables(0)

        cbFea.Items.Clear()      ' Data Clear 
        cbFea.Text = ""
        txtResult.Text = ""            ' 설명 초기화 

        For i As Integer = 0 To Table.Rows.Count - 1    ' Data table Row 만큼 반복 -1은 마지막행은 Null
            If cbApp.Text = Table.Rows(i)(0).ToString() Then ' 선택 된 App과 Row, 필트(0)은 App, (1) 은 Feature
                Try
                    cbFea.Items.Add(Table.Rows(i)(1).ToString())
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            End If
        Next
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click, cbFea.SelectedIndexChanged

        Dim vSQL As String
        ' app과 feature가 있는지 검색하는 부분



        vSQL = "Select * from [" & strSht & "] where App = '" & cbApp.Text & "' "

        If cbFea.Text <> "" Then
            vSQL = vSQL & "and Feature = '" & cbFea.Text & "'"
        End If

        DA = New OleDbDataAdapter(vSQL, vConn)
        DA.Fill(DS2, strSht)

        Dim Table As DataTable = DS2.Tables(strSht)

        If Table.Rows.Count = 0 Then
            txtResult.Text = "검색결과 " & cbApp.Text & " 와 " & cbFea.Text & " 가 없습니다."
            Exit Sub
        End If

        Dim txtApp As String = cbApp.Text
        Dim txtFea As String = cbFea.Text
        Dim txtDes As String = Table.Rows(0).Item(2).ToString

        ' 앱과 피쳐가 모두 같다면 이미 피쳐가 존재 하는 것이니
        txtResult.Text = "검색결과 " & txtApp & " 와 " & txtFea & " 가 있습니다."
        modApp.Text = txtApp
        modFea.Text = txtFea
        modDes.Text = txtDes
        delApp.Text = txtApp
        delFea.Text = txtFea
        addApp.Text = txtApp
        addFea.Text = txtFea
        addDes.Text = txtDes

        DS2.Clear()

    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click

        Dim vSQL As String

        ' 미입력 된 부분 확인 하는 코드
        If addApp.Text = "" Or addFea.Text = "" And addDes.Text = "" Then
            MsgBox("입력 되지 않은 부분이 있습니다. 확인 후 다시 시도해 주세요. ")
            Exit Sub
        End If

        If txtName.Text = "" Then
            MsgBox("담당자가 입력 되지 않았습니다. ")
            Exit Sub
        End If

        vSQL = "Select * from [" & strSht & "] where App = '" & addApp.Text & "' "

        If addFea.Text <> "" Then
            vSQL = vSQL & "and Feature = '" & addFea.Text & "'"
        End If
        DS2.Clear()
        DA = New OleDbDataAdapter(vSQL, vConn)
        DA.Fill(DS2, strSht)

        Dim Table As DataTable = DS2.Tables(strSht)

        ' select문 결과 0 즉, 없을 경우 추가
        If Table.Rows.Count = 0 Then

            '조회할SQL을 만들어서 String변수에 넣는다.

            vSQL = "INSERT INTO [" & strSht & "]([App], [Feature], [Description_Feature]) " & "VALUES ('" & addApp.Text & "','" & addFea.Text & "','" & addDes.Text & "');"
            DA = New OleDbDataAdapter(vSQL, vConn)

            If addFea.Text = "" Then
                MsgBox(addApp.Text & "App 이(가) 추가되었습니다.")
            Else
                MsgBox(addApp.Text & "App 과 " & addFea.Text & "Feature 이(가) 추가되었습니다.")
            End If

            ' history 추가하는 부분
            If addFea.Text = "" Then
                Add_History("App", "추가", addApp.Text, addApp.Text + "추가", txtName.Text)
            Else
                Add_History("App & Feature", "추가", addApp.Text + " / " + addFea.Text, "App : " + addApp.Text + " / Feature : " + addFea.Text + " 추가", txtName.Text)
            End If

            DA = New OleDbDataAdapter(vSQL, vConn)
            DA.Fill(DS2, strSht)

            Form_Refresh()

        Else
            MsgBox(addApp.Text & " App이(가) 이미 있습니다.")
        End If
    End Sub

    Private Sub delApp_SelectedIndexChanged(sender As Object, e As EventArgs) Handles delApp.SelectedIndexChanged
        ' App Click 시 Feature에 맞도록
        Dim Table As DataTable = DS.Tables(0)

        delFea.Items.Clear()      ' Data Clear 
        delFea.Text = ""

        For i As Integer = 0 To Table.Rows.Count - 1    ' Data table Row 만큼 반복 -1은 마지막행은 Null
            If delApp.Text = Table.Rows(i)(0).ToString() Then ' 선택 된 App과 Row, 필트(0)은 App, (1) 은 Feature
                Try
                    delFea.Items.Add(Table.Rows(i)(1).ToString())
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            End If
        Next
    End Sub

    Private Sub btnMod_Click(sender As Object, e As EventArgs) Handles btnMod.Click

        Dim vSQL As String

        ' 미입력 된 부분 확인 하는 코드
        If modApp.Text = "" Or modFea.Text = "" And modDes.Text = "" Then
            MsgBox("입력 되지 않은 부분이 있습니다. 확인 후 다시 시도해 주세요. ")
            Exit Sub
        End If

        If txtName.Text = "" Then
            MsgBox("담당자가 입력 되지 않았습니다. ")
            Exit Sub
        End If

        vSQL = "Select * from [" & strSht & "] where App = '" & cbApp.Text & "' "

        If modFea.Text <> "" Then
            vSQL = vSQL & "and Feature = '" & cbFea.Text & "'"
        End If
        DS2.Clear()
        DA = New OleDbDataAdapter(vSQL, vConn)
        DA.Fill(DS2, strSht)

        Dim Table As DataTable = DS2.Tables(strSht)

        ' select문 결과가 있을 시 수정 수행
        If Table.Rows.Count <> 0 Then

            '조회할SQL을 만들어서 String변수에 넣는다.
            vSQL = "UPDATE [" & strSht & "]SET "
            If modApp.Text <> cbApp.Text And modFea.Text = cbFea.Text Then
                vSQL = vSQL & "[App]='" & modApp.Text & "' " & "WHERE [App]='" & cbApp.Text & "'"
                Add_History("App", "수정", modApp.Text, cbApp.Text + " > " + modApp.Text + " 으로 수정", txtName.Text)
            ElseIf modFea.Text <> cbFea.Text And modApp.Text = cbApp.Text Then
                vSQL = vSQL & "[Feature]='" & modFea.Text & "' " & "WHERE [Feature]='" & cbFea.Text & "'"
                Add_History("Feature", "수정", modFea.Text, cbFea.Text + " > " + modFea.Text + " 으로 수정", txtName.Text)
            ElseIf modDes.Text <> addDes.Text Then
                vSQL = vSQL & "[App]='" & modApp.Text & "', [Feature]='" & modFea.Text & "', [Description_Feature]='" & modDes.Text & "' WHERE [App]='" & cbApp.Text & "'and [Feature]='" & cbFea.Text & "'"
                Add_History("Feature", "수정", modFea.Text + " Description수정", addDes.Text + " > " + modDes.Text + " 으로 수정", txtName.Text)
            End If

            DA = New OleDbDataAdapter(vSQL, vConn)
            DA.Fill(DS2, strSht)

            If modFea.Text = "" Then
                MsgBox(modApp.Text & "App 이(가) 수정되었습니다.")
            Else
                MsgBox(modApp.Text & "App 과 " & modFea.Text & "Feature 이(가) 수정되었습니다.")
            End If

            Form_Refresh()
        Else
            MsgBox("해당 App과 Feature가 이미 있습니다. 다시 확인 후 시도 해 주세요 ")
        End If
    End Sub
    'Summary작성_Tools_DB_원본 파일 History_AFTS$에 History 추가 하는 함수
    'ca = 구분, ca2 = 변경구분, strTxt = 변경내용, strTxt2 = 상세 변경내용, strtxtName = 담당
    Sub Add_History(ca As String, ca2 As String, strTxt As String, strTxt2 As String, strtxtName As String)
        Dim vSQL As String

        Dim strSht As String

        strSht = "History_AFTS"

        Dim xml As New XML
        Dim vCon As String = Nothing
        Dim vConn2 As OleDbConnection
        ' vcon가져오는 함수
        xml.vCon_Admin_Call(vCon)
        ' Connect 연결
        vConn2 = New OleDbConnection(vCon)
        vConn2.Open()

        vSQL = "INSERT INTO [" & strSht & "] ([날짜],[구분],[변경구분],[변경 내용],[상세변경내용],[담당]) " &
           "VALUES ( '" & strDate & "','" & ca & "','" & ca2 & "','" & strTxt & "','" & strTxt2 & "','" & strtxtName & "');"
        DA = New OleDbDataAdapter(vSQL, vConn2)
        DA.Fill(DS2, strSht)

    End Sub

    Private Sub btnDel_Click(sender As Object, e As EventArgs) Handles btnDel.Click
        Dim iQuestion As String

        If txtName.Text = "" Then
            MsgBox("담당자가 입력 되지 않았습니다. ")
            Exit Sub
        End If
        If delApp.Text = "" And delFea.Text = "" Then ' app과 fea 둘 중 하나라도 선택되지 않은 경우
            MsgBox("선택 후 이용해 주세요")

        ElseIf delApp.Text <> "" And delFea.Text = "" Then
            ' App 전체 삭제 추가 예정
            iQuestion = MsgBox("App : " & delApp.Text & "의 Feature 전체를 삭제하시겠습니까?" + vbCr +
               "정말 삭제하시겠습니까?", vbYesNo, "gyeongmin.yeom@lgepartner.com")
            If iQuestion = 6 Then
                DA = New OleDbDataAdapter("Delete from [" & strSht & "]  WHERE App= '" & delApp.Text & "'", vConn)
                DA.Fill(DS2, strSht)
            Else
                Exit Sub
            End If
            MsgBox("성공적으로 삭제 하였습니다.")
            'History에 저장하는 부분
            Add_History("App & Feature", "삭제", delApp.Text + " 삭제", delApp.Text + " 의 전체 Feature 및 해당 앱 삭제 ", txtName.Text)
            Form_Refresh()
        Else

            iQuestion = MsgBox("App : " & delApp.Text & "와 " & "Feature : " & delFea.Text & "를" & vbCr &
                "정말 삭제하시겠습니까?", vbYesNo, "gyeongmin.yeom@lgepartner.com")
            If iQuestion = 6 Then
                DA = New OleDbDataAdapter("Delete from [" & strSht & "]  WHERE App= '" & delApp.Text & "' and Feature = '" & delFea.Text & "'", vConn)
                DA.Fill(DS2, strSht)
            Else
                Exit Sub
            End If
            MsgBox("성공적으로 삭제 하였습니다.")
            'History에 저장하는 부분
            Add_History("App & Feature", "삭제", delApp.Text + " / " + delFea.Text, delApp.Text + " / " + delFea.Text + "삭제", txtName.Text)

            Form_Refresh()
        End If
    End Sub

End Class