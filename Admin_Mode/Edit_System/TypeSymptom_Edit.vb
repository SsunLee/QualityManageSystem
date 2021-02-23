Imports System.Windows.Forms
Imports System.Data
Imports System.Data.OleDb
Public Class TypeSymptom_Edit
    Dim itemSta As String
    Private DS As DataSet = New DataSet
    Private DS2 As DataSet = New DataSet
    Private DA As OleDbDataAdapter = New OleDbDataAdapter()
    Public ordAdapter As OleDbDataAdapter = New OleDbDataAdapter()
    Private strSQL As String
    Private vConn As OleDbConnection
    Dim strSht As String = "TD_TS_Des"
    Dim strDate As String = Now()

    Private Sub TypeSymptom_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ' 초기화 해주는 코드
        If cbType.DataSource Is DBNull.Value Or delType.DataSource Is DBNull.Value Then
        Else
            cbType.DataSource = Nothing
            delType.DataSource = Nothing
            delType.Text = ""
            'cbSym.Items.Clear()
        End If

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
        DA = New OleDbDataAdapter("Select * from [" & strSht & "] order by [Test Type] asc", vConn)
        DA.Fill(DS, strSht)

        Dim Table As DataTable = DS.Tables(strSht)
        Dim Table2 As DataTable

        If Table.Rows.Count = 0 Then
            MsgBox("조회할 내용이 없습니다.",, "lee.sunbae@lgepartner.com")
            Exit Sub
        End If

        Table = Table.DefaultView.ToTable(True, "Test Type") ' 중복 제거하고 Table저장
        Table2 = Table.DefaultView.ToTable(True, "Test Type") ' 중복 제거하고 Table저장

        With cbType
            .DataSource = Table
            .DisplayMember = "Test Type"
            .ValueMember = "Test Type"
        End With

        With delType
            .DataSource = Table2
            .DisplayMember = "Test Type"
            .ValueMember = "Test Type"
            .Text = ""
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
                        b.Text = ""
                    ElseIf TypeOf b Is ComboBox Then
                        b.text = ""
                    End If
                Next
            End If
        Next

    End Sub

    Private Sub cbType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbType.SelectedIndexChanged
        ' Type Click 시 Symptom에 맞도록
        Dim Table As DataTable = DS.Tables(0)

        cbSym.Items.Clear()      ' Data Clear 
        cbSym.Text = ""
        txtResult.Text = ""            ' 설명 초기화 

        For i As Integer = 0 To Table.Rows.Count - 1    ' Data table Row 만큼 반복 -1은 마지막행은 Null
            If cbType.Text = Table.Rows(i)(0).ToString() Then ' 선택 된 App과 Row, 필트(0)은 App, (1) 은 Feature
                Try
                    cbSym.Items.Add(Table.Rows(i)(2).ToString())
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            End If
        Next
    End Sub

    Private Sub delType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles delType.SelectedIndexChanged
        ' Type Click 시 Symptom에 맞도록
        Dim Table As DataTable = DS.Tables(0)

        delSym.Items.Clear()      ' Data Clear 
        delSym.Text = ""
        txtResult.Text = ""            ' 설명 초기화 

        For i As Integer = 0 To Table.Rows.Count - 1    ' Data table Row 만큼 반복 -1은 마지막행은 Null
            If delType.Text = Table.Rows(i)(0).ToString() Then ' 선택 된 App과 Row, 필트(0)은 App, (1) 은 Feature
                Try
                    delSym.Items.Add(Table.Rows(i)(2).ToString())
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            End If
        Next
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click, cbSym.SelectedIndexChanged

        Dim vSQL As String
        ' app과 feature가 있는지 검색하는 부분

        vSQL = "Select * from [" & strSht & "] where [Test Type] = '" & cbType.Text & "' "

        If cbSym.Text <> "" Then
            vSQL = vSQL & "and [Detailed Symptom] = '" & cbSym.Text & "'"
        End If

        DA = New OleDbDataAdapter(vSQL, vConn)
        DA.Fill(DS2, strSht)

        Dim Table As DataTable = DS2.Tables(strSht)

        If Table.Rows.Count = 0 Then
            txtResult.Text = "검색결과 " & cbType.Text & " 와 " & cbSym.Text & " 가 없습니다."
            Exit Sub
        End If

        Dim txtType As String = cbType.Text
        Dim txtSym As String = cbSym.Text
        Dim txtTDes As String = Table.Rows(0).Item(1).ToString
        Dim txtSDes As String = Table.Rows(0).Item(3).ToString

        ' 앱과 피쳐가 모두 같다면 이미 피쳐가 존재 하는 것이니
        txtResult.Text = "검색결과 " & txtType & " 와 " & txtSym & " 가 있습니다."
        modType.Text = txtType
        modSym.Text = txtSym
        modTDes.Text = txtTDes
        modSDes.Text = txtSDes
        delType.Text = txtType
        delSym.Text = txtSym
        addType.Text = txtType
        addSym.Text = txtSym
        addTDes.Text = txtTDes
        addSDes.Text = txtSDes

        DS2.Clear()
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click

        Dim vSQL As String

        ' 미입력 된 부분 확인 하는 코드
        If addType.Text = "" Or addSym.Text = "" And addTDes.Text = "" And addSDes.Text = "" Then
            MsgBox("입력 되지 않은 부분이 있습니다. 확인 후 다시 시도해 주세요. ")
            Exit Sub
        End If

        If txtName.Text = "" Then
            MsgBox("담당자가 입력 되지 않았습니다. ")
            Exit Sub
        End If

        vSQL = "Select * from [" & strSht & "] where [Test Type] = '" & addType.Text & "' "

        If addSym.Text <> "" Then
            vSQL = vSQL & "and [Detailed Symptom] = '" & addSym.Text & "'"
        End If

        DS2.Clear()
        DA = New OleDbDataAdapter(vSQL, vConn)
        DA.Fill(DS2, strSht)

        Dim Table As DataTable = DS2.Tables(strSht)

        ' select문 결과 0 즉, 없을 경우 추가
        If Table.Rows.Count = 0 Then

            '조회할SQL을 만들어서 String변수에 넣는다.
            vSQL = "INSERT INTO [" & strSht & "]([Test Type],[Test Type_Description],[Detailed Symptom],[Description_Detailed Symptom]) "
            vSQL = vSQL + "VALUES ('" & addType.Text & "','" & addTDes.Text & "','" & addSym.Text & "','" & addSDes.Text & "');"
            DA = New OleDbDataAdapter(vSQL, vConn)


            If addSym.Text = "" Then
                MsgBox(addType.Text & "Type 이(가) 추가되었습니다.")
            Else
                MsgBox(addType.Text & "Type 과 " & addSym.Text & "Symptom 이(가) 추가되었습니다.")
            End If

            ' history 추가하는 부분
            If addSym.Text = "" Then
                Add_History("Type", "추가", addType.Text, addType.Text + "추가", txtName.Text)
            Else
                Add_History("Type & Symptom", "추가", addType.Text + " / " + addSym.Text, "Type : " + addType.Text + " / Symptom : " + addSym.Text + " 추가", txtName.Text)
            End If

            DA = New OleDbDataAdapter(vSQL, vConn)
            DA.Fill(DS2, strSht)

            Form_Refresh()

        Else
            MsgBox(addType.Text & " Type이(가) 이미 있습니다.")
        End If
    End Sub

    Private Sub btnMod_Click(sender As Object, e As EventArgs) Handles btnMod.Click

        Try
            ' 수정하기 
            Dim vSQL As String

            ' 미입력 된 부분 확인 하는 코드
            If modType.Text = "" Or modSym.Text = "" And modTDes.Text = "" And modSDes.Text = "" Then
                MsgBox("입력 되지 않은 부분이 있습니다. 확인 후 다시 시도해 주세요. ")
                Exit Sub
            End If

            If txtName.Text = "" Then
                MsgBox("담당자가 입력 되지 않았습니다. ")
                Exit Sub
            End If

            vSQL = "Select * from [" & strSht & "] where [Test Type] = '" & cbType.Text & "' "

            If modSym.Text <> "" Then
                vSQL = vSQL & "and [Detailed Symptom] = '" & cbSym.Text & "'"
            End If
            DS2.Clear()
            DA = New OleDbDataAdapter(vSQL, vConn)
            DA.Fill(DS2, strSht)

            Dim Table As DataTable = DS2.Tables(strSht)

            ' select문 결과가 있을 시 수정 수행
            If Table.Rows.Count <> 0 Then

                '조회할SQL을 만들어서 String변수에 넣는다.
                vSQL = "UPDATE [" & strSht & "]SET "
                ' Type만 수정 할 경우
                If modType.Text <> cbType.Text And modSym.Text = cbSym.Text Then
                    vSQL = vSQL & "[Test Type]='" & modType.Text & "', [Test Type_Description]='" & modTDes.Text & "' " & "WHERE [Test Type]='" & cbType.Text & "';"
                    Add_History("App", "수정", modType.Text, cbType.Text + " > " + modType.Text + " 으로 수정", txtName.Text)

                    'Symptom 만 수정할 경우
                ElseIf modType.Text = cbType.Text And modSym.Text <> cbSym.Text Then
                    vSQL = vSQL & "[Detailed Symptom]='" & modSym.Text & "', [Description_Detailed Symptom]='" & modSDes.Text & "'WHERE [Test Type]='" & cbType.Text & "' and [Detailed Symptom]='" & cbSym.Text & "';"
                    Add_History("Feature", "수정", modSym.Text, cbSym.Text + " > " + modSym.Text + " 으로 수정", txtName.Text)

                    'Type_Description, Symptom_Description  수정할 경우
                ElseIf modTDes.Text <> addTDes.Text Or modSDes.Text <> addSDes.Text Then
                    vSQL = vSQL & "[Description_Detailed Symptom]='" & modSDes.Text & "', [Test Type_Description]='" & modTDes.Text & "' " &
                "WHERE [Test Type]='" & cbType.Text & "' and [Detailed Symptom]='" & cbSym.Text & "';"
                    Add_History("Feature", "수정", modSym.Text + " Description수정", addTDes.Text + " > " + modTDes.Text + " 으로 수정", txtName.Text)

                    ' Type, Symptom 둘 다 수정할 경우/ Symptom 먼저 수정 후 Type 수정함 > 추후 나중에 다른방법 있을 시 수정
                ElseIf modType.Text <> cbType.Text And modSym.Text <> cbSym.Text Then
                    Dim vSQL2 As String = vSQL & "[Test Type]='" & modType.Text & "', [Test Type_Description]='" & modTDes.Text & "' " &
                "WHERE [Test Type]='" & cbType.Text & "'"
                    vSQL = vSQL & "[Detailed Symptom]='" & modSym.Text & "', [Description_Detailed Symptom]='" & modSDes.Text & "' " &
                "WHERE [Test Type]='" & cbType.Text & "' and [Detailed Symptom]='" & cbSym.Text & "'"
                    DA = New OleDbDataAdapter(vSQL2, vConn)
                    DA.Fill(DS2, strSht)
                    Add_History("Type & Symptom", "수정", modType.Text + " / " + modSym.Text, "Type : " + cbType.Text + " > " + modType.Text + " / Symptom : " + cbSym.Text + " > " + modSym.Text + " 으로 수정", txtName.Text)
                End If

                DA = New OleDbDataAdapter(vSQL, vConn)
                DA.Fill(DS2, strSht)

                If modSym.Text = "" Then
                    MsgBox(modType.Text & "Type 이(가) 수정되었습니다.")
                Else
                    MsgBox(modType.Text & "Type 과 " & modSym.Text & "Symptom 이(가) 수정되었습니다.")
                End If

                Form_Refresh()
            Else
                MsgBox("해당 Type과 Symptom가 이미 있습니다. 다시 확인 후 시도 해 주세요 ")
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try



    End Sub

    Private Sub btnDel_Click(sender As Object, e As EventArgs) Handles btnDel.Click
        Dim iQuestion As String

        If txtName.Text = "" Then
            MsgBox("담당자가 입력 되지 않았습니다. ")
            Exit Sub
        End If
        If delType.Text = "" And delSym.Text = "" Then ' app과 fea 둘 중 하나라도 선택되지 않은 경우
            MsgBox("선택 후 이용해 주세요")

        ElseIf delType.Text <> "" And delSym.Text = "" Then
            ' Type 전체 삭제 추가 예정
            iQuestion = MsgBox("Type : " & delType.Text & "의 Symptom 전체를 삭제하시겠습니까?" + vbCr +
               "정말 삭제하시겠습니까?", vbYesNo, "gyeongmin.yeom@lgepartner.com")
            If iQuestion = 6 Then
                DA = New OleDbDataAdapter("Delete from [" & strSht & "]  WHERE [Test Type]= '" & delType.Text & "'", vConn)
                DA.Fill(DS2, strSht)
            Else
                Exit Sub
            End If
            MsgBox("성공적으로 삭제 하였습니다.")
            'History에 저장하는 부분
            Add_History("Type & Symptom", "삭제", delType.Text + " 삭제", delSym.Text + " 의 전체 Symptom 및 해당 Type 삭제 ", txtName.Text)
            Form_Refresh()
        Else

            iQuestion = MsgBox("App : " & delType.Text & "와 " & "Feature : " & delSym.Text & "를" & vbCr &
                "정말 삭제하시겠습니까?", vbYesNo, "gyeongmin.yeom@lgepartner.com")
            If iQuestion = 6 Then
                DA = New OleDbDataAdapter("Delete from [" & strSht & "]  WHERE [Test Type]= '" & delType.Text & "' and [Detailed Symptom] = '" & delSym.Text & "'", vConn)
                DA.Fill(DS2, strSht)
            Else
                Exit Sub
            End If
            MsgBox("성공적으로 삭제 하였습니다.")
            'History에 저장하는 부분
            Add_History("Type & Symptom", "삭제", delType.Text + " / " + delSym.Text, addTDes.Text + " / " + addSDes.Text + "삭제", txtName.Text)

            Form_Refresh()
        End If
    End Sub
    'Summary작성_Tools_DB_원본 파일 History_AFTS$에 History 추가 하는 함수
    'ca = 구분, ca2 = 변경구분, strTxt = 변경내용, strTxt2 = 상세 변경내용, strtxtName = 담당
    Sub Add_History(ca As String, ca2 As String, strTxt As String, strTxt2 As String, strtxtName As String)
        Dim vSQL As String
        Dim strDate As String
        Dim strSht As String

        '요청 DB 날짜를 저장하는 부분
        strDate = Now()

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
End Class