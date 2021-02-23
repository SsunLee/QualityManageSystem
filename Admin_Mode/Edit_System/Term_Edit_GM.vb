Imports System.Windows.Forms
Imports System.Data
Imports System.Data.OleDb
Imports System.Drawing

Public Class Term_Edit_GM
    Dim itemSta As String
    Private DS As DataSet = New DataSet
    Private DS2 As DataSet = New DataSet
    Private DS3 As DataSet = New DataSet
    Private DA As OleDbDataAdapter = New OleDbDataAdapter()
    Public ordAdapter As OleDbDataAdapter = New OleDbDataAdapter()
    Private strSQL As String
    Private vConn As OleDbConnection
    Private adminMainForm As New AdminMain
    ' Private Main_Form As New Main_Form
    Dim strSht As String = "용어"
    Dim strDate As String = Now()

    Public Sub Form_Refresh()

        DS.Clear()
        DA = New OleDbDataAdapter("Select ID, 대분류, 용어, 설명, [비고 (Update시 설명 누적], [업체 이름]  from [" & strSht & "] order by [대분류] asc, [용어] asc", vConn)
        DA.Fill(DS, strSht)

        Dim Table As DataTable = DS.Tables(strSht)

        If Table.Rows.Count = 0 Then
            MsgBox("조회할 내용이 없습니다.",, "lee.sunbae@lgepartner.com")
            Exit Sub
        End If


        For i As Integer = 0 To Table.Rows.Count - 1            ' Data table Row 만큼 반복 -1은 마지막행은 Null

            Try
                If Not cbD.Items.Contains(Table.Rows(i)(1).ToString()) And Table.Rows(i)(1).ToString() <> "" Then  ' 중복 없이 Item 추가
                    cbD.Items.Add(Table.Rows(i)(1).ToString())
                End If

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

        Next

        SearchTerm.Text = ""
        'cbCa.Text = ""
        'txtModule.Text = ""
        txtCom.Text = ""
        txtDes.Text = ""
        'txtRisk.Text = ""
        'txtTip.Text = ""
        'txtStep.Text = ""



    End Sub

    'Summary작성_Tools_DB_원본 파일 History_AFTS$에 History 추가 하는 함수
    'ca = 구분, ca2 = 변경구분, strTxt = 변경내용, strTxt2 = 상세 변경내용, strtxtName = 담당
    Sub Add_History(ca As String, ca2 As String, strTxt As String, strTxt2 As String)
        Dim vSQL As String
        Dim strSht As String

        strSht = "History_Term"
        Dim xml As New XML
        Dim vCon As String = Nothing
        Dim vConn2 As OleDbConnection
        ' vcon가져오는 함수
        xml.vCon_Admin_Call(vCon)
        ' Connect 연결
        vConn2 = New OleDbConnection(vCon)
        vConn2.Open()
        vSQL = "INSERT INTO [" & strSht & "] (구분,용어,바뀐내용,담당자,[날짜]) VALUES ('" & ca & "','" & ca2 & "','" & strTxt & "','" & strTxt2 & "','" & strDate & "')"
        DA = New OleDbDataAdapter(vSQL, vConn2)
        DA.Fill(DS3, strSht)

    End Sub

    Private Sub Term_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
        Form_Refresh()
        Dim toolTip1 As New ToolTip()
        'toolTip1.SetToolTip(txtModule, "ex) BSP, Audio, Kernel, BT, Camera, Common, Network ")
        'toolTip1.SetToolTip(txtRisk, "앱 이름을 입력만 한 상태로 Load 하면 됩니다. ")
        'toolTip1.SetToolTip(ComboBox2, "대분류 카테고리를 선택할 수 있습니다. * 선택하지 않아도 됩니다.")
        'toolTip1.SetToolTip(TextBox1, "검색어를 입력하세요.")
        'toolTip1.SetToolTip(Button2, "Search")
        toolTip1.InitialDelay = 100
        toolTip1.AutoPopDelay = 3000    ' 사용자가 마우스를 올려서 보여지는 시간
        toolTip1.ReshowDelay = 500

        txtDes.Text = "ex) 휴대폰에 내장된 3.5mm의 단자로 이어폰이나 헤드셋,셀카봉 단자에 장착하여 사용할 수 있다."
        '        txtRisk.Text = "ex) 3.5pi 단자와 연결된 각종 액세서리와 호환성 검증 필요"
        '        txtTip.Text = "ex) 셀카봉, Ear-jack, AUX Cable등 3.5 pi 호환 액세서리 장착 후 음악,동영상,통화 동작하여 볼륨 확인"
        '        txtStep.Text = "ex) [Know-how]
        '3.5pi 단자와 연결 가능한 액세서리 사용중 BT/MTP로 파일 전송시 오작동 발생하는지 확인

        '[Defect 기반]
        '셀카봉 장착/탈착 후 Ear-jack 장착하여 카메라 촬영시 촬영 동작되지 않음."

        txtDes.ForeColor = Color.DarkGray
        'txtRisk.ForeColor = Color.DarkGray
        'txtTip.ForeColor = Color.DarkGray
        'txtStep.ForeColor = Color.DarkGray

    End Sub

    Private Sub cbD_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbD.SelectedIndexChanged
        ' 대분류 Click 시 중분류에 맞도록
        Dim Table As DataTable = DS.Tables(0)

        'cbM.Items.Clear()      ' Data Clear 
        'cbM.Text = ""
        'cbCa.Items.Clear()
        'cbCa.Text = ""
        SearchTerm.Text = ""            ' 설명 초기화 



        'For i As Integer = 0 To Table.Rows.Count - 1            ' Data table Row 만큼 반복 -1은 마지막행은 Null

        '    Try
        '        If Not cbCa.Items.Contains(Table.Rows(i)(6).ToString()) And Table.Rows(i)(6).ToString() <> "" Then  ' 중복 없이 Item 추가
        '            cbCa.Items.Add(Table.Rows(i)(6).ToString())
        '        End If

        '    Catch ex As Exception
        '        MsgBox(ex.Message)
        '    End Try

        'Next

        '  cbCa.Sorted = True

        ' 중분류 Click 시 용어에 맞도록
        ' Dim Table As DataTable = DS.Tables(0)

        SearchTerm.Items.Clear()      ' Data Clear 
        SearchTerm.Text = ""

        For i As Integer = 0 To Table.Rows.Count - 1    ' Data table Row 만큼 반복 -1은 마지막행은 Null
            If cbD.Text = Table.Rows(i)(1).ToString() Then ' 선택 된 App과 Row, 필트(0)은 App, (1) 은 Feature
                Try
                    SearchTerm.Items.Add(Table.Rows(i)(2).ToString())
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            End If
        Next



    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Form_Refresh()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim vSQL As String

        ' 미입력 된 부분 확인 하는 코드
        Dim a As Control
        For Each a In Me.Controls
            If TypeOf a Is TextBox Then
                If a.Text = "" Then
                    MsgBox(a.Tag + "가 입력되지 않았습니다.")
                    Exit Sub
                End If
            ElseIf TypeOf a Is ComboBox Then
                If a.Text = "" Then
                    MsgBox(a.Tag + "가 입력되지 않았습니다.")
                    Exit Sub
                End If
            End If
        Next


        vSQL = "Select * from [" & strSht & "] where [용어] = '" & SearchTerm.Text & "' "

        DS2.Clear()
        DA = New OleDbDataAdapter(vSQL, vConn)
        DA.Fill(DS2, strSht)

        Dim Table As DataTable = DS2.Tables(strSht)

        ' select문 결과 0 즉, 없을 경우 추가
        If Table.Rows.Count = 0 Then

            '조회할SQL을 만들어서 String변수에 넣는다.
            vSQL = "INSERT INTO [" & strSht & "]([대분류],[용어],[설명],[업체 이름])" '[검증 분류],[관련 Module],[Risk Factor],[Tip],[검증방법]) "
            vSQL = vSQL + "VALUES ('" & cbD.Text & "','" & SearchTerm.Text & "','" & txtDes.Text & "','" & txtCom.Text & "_" + Now() & "')"
            'vSQL = vSQL + cbCa.Text & "','" & txtModule.Text & "','" & txtRisk.Text & "','" & txtTip.Text & "','" & txtStep.Text & "');"
            DA = New OleDbDataAdapter(vSQL, vConn)
            DA.Fill(DS, strSht)

            MsgBox(SearchTerm.Text & " 이(가) 추가되었습니다.")
            Add_History("추가", SearchTerm.Text, SearchTerm.Text + "를 추가", txtName.Text)

            Form_Refresh()

        Else
            MsgBox(SearchTerm.Text & " 해당 용어는 이미 있습니다.")
        End If
    End Sub
    Private Sub btnMod_Click(sender As Object, e As EventArgs) Handles btnMod.Click
        Dim vSQL As String

        ' 미입력 된 부분 확인 하는 코드
        Dim a As Control
        For Each a In Me.Controls
            If TypeOf a Is TextBox Then
                If a.Text = "" Then
                    MsgBox(a.Tag + "가 입력되지 않았습니다.")
                    Exit Sub
                End If
            ElseIf TypeOf a Is ComboBox Then
                If a.Text = "" Then
                    MsgBox(a.Tag + "가 입력되지 않았습니다.")
                    Exit Sub
                End If
            End If
        Next

        vSQL = "Select [ID] from [" & strSht & "] where [용어] = '" & SearchTerm.Text & "' "

        DS2.Clear()
        DA = New OleDbDataAdapter(vSQL, vConn)
        DA.Fill(DS2, strSht)

        Dim Table As DataTable = DS2.Tables(strSht)

        ' select문 결과 0 즉, 없을 경우 추가
        If Table.Rows.Count <> 0 Then

            '조회할SQL을 만들어서 String변수에 넣는다.
            vSQL = " UPDATE [" & strSht & "]SET [대분류] = '" & cbD.Text & "',[용어] = '" & SearchTerm.Text & "',[설명] = '" & txtDes.Text & "',[업체 이름] = '" & txtCom.Text & "_" + Now() & "'"
            'vSQL = vSQL + ",[검증 분류] = '" & cbCa.Text & "',[관련 Module] = '" & txtModule.Text & "',[Risk Factor] = '" & txtRisk.Text & "',[Tip] = '" & txtTip.Text & "',[검증방법] = '" & txtStep.Text & "' "
            vSQL = vSQL + "where [ID] = " & Table.Rows(0)(0).ToString

            DA = New OleDbDataAdapter(vSQL, vConn)
            DA.Fill(DS, strSht)

            MsgBox(SearchTerm.Text & " 이(가) 수정되었습니다.")
            Add_History("수정", SearchTerm.Text, SearchTerm.Text + "을 수정", txtName.Text)

            Form_Refresh()

        Else
            MsgBox(SearchTerm.Text & " 해당 용어는 수정 할 수 없습니다. 존재하지 않습니다.")
        End If
    End Sub

    Private Sub btnDel_Click(sender As Object, e As EventArgs) Handles btnDel.Click
        Dim vSQL As String
        Dim iQuestion As String

        ' 미입력 된 부분 확인 하는 코드
        If cbD.Text = "" And SearchTerm.Text = "" And txtDes.Text = "" Then 'And cbCa.Text = "" And txtModule.Text = "" And txtRisk.Text = "" And txtTip.Text = "" Then
            MsgBox("입력 되지 않은 부분이 있습니다. 확인 후 다시 시도해 주세요.")
            Exit Sub
        End If

        If txtName.Text = "" Then
            MsgBox("담당자가 입력 되지 않았습니다. ")
            Exit Sub
        End If

        vSQL = "Select * from [" & strSht & "] where [용어] = '" & SearchTerm.Text & "' "

        DS2.Clear()
        DA = New OleDbDataAdapter(vSQL, vConn)
        DA.Fill(DS2, strSht)

        Dim Table As DataTable = DS2.Tables(strSht)



        ' select문 결과 0 즉, 없을 경우 추가
        If SearchTerm.Text = SearchTerm.Text Then
            ' 삭제 하는 쿼리
            iQuestion = MsgBox("용어 : " & SearchTerm.Text & "를 정말 삭제하시겠습니까?", vbYesNo, "gyeongmin.yeom@lgepartner.com")
            If iQuestion = 6 Then
                DA = New OleDbDataAdapter("Delete from [" & strSht & "]  WHERE [ID] = " & Table.Rows(0)(0).ToString, vConn)
                DA.Fill(DS2, strSht)
            Else
                Exit Sub
            End If
            MsgBox("성공적으로 삭제 하였습니다.")


            DA = New OleDbDataAdapter(vSQL, vConn)
            DA.Fill(DS, strSht)

            Add_History("삭제", SearchTerm.Text, SearchTerm.Text + "을 삭제", txtName.Text)

            Form_Refresh()

        Else
            MsgBox("용어 검색 후 용어를 수정 하지 말고 삭제를 진행 해 주세요.")
        End If
    End Sub


    Private Sub SearchTerm_SelectedIndexChanged(sender As Object, e As EventArgs) Handles SearchTerm.SelectedIndexChanged
        Dim vSQL As String
        Dim strDes As String = Nothing
        Dim strCom As String = Nothing
        Dim strPDes As String = Nothing

        txtDes.ForeColor = Color.Black
        'txtRisk.ForeColor = Color.Black
        'txtTip.ForeColor = Color.Black
        'txtStep.ForeColor = Color.Black

        ' app과 feature가 있는지 검색하는 부분

        vSQL = "Select * from [" & strSht & "] where [용어] = '" & SearchTerm.Text & "' "

        DA = New OleDbDataAdapter(vSQL, vConn)
        DA.Fill(DS2, strSht)

        Dim Table As DataTable = DS2.Tables(strSht)

        If SearchTerm.Text = "" Then
            Exit Sub
        Else
            If Table.Rows.Count = 0 Then
                MsgBox("검색결과 " & SearchTerm.Text & " 가 없습니다.")
                Exit Sub
            End If

        End If

        If Table.Rows(0)(4).ToString = "-" Then
            strPDes = ""
        Else
            strPDes = Table.Rows(0)(4).ToString
        End If


        strDes = Table.Rows(0)(3).ToString + vbCrLf + strPDes
        strCom = Table.Rows(0)(5).ToString
        'strCa = Table.Rows(0)(6).ToString
        'strModule = Table.Rows(0)(7).ToString
        'strRisk = Table.Rows(0)(8).ToString
        'StrTip = Table.Rows(0)(9).ToString
        'StrStep = Table.Rows(0)(10).ToString

        txtDes.Text = Replace(strDes, Chr(10), Chr(13) & Chr(10))
        txtCom.Text = Replace(strCom, Chr(10), Chr(13) & Chr(10))
        'cbCa.Text = Replace(strCa, Chr(10), Chr(13) & Chr(10))
        'txtModule.Text = Replace(strModule, Chr(10), Chr(13) & Chr(10))
        'txtRisk.Text = Replace(strRisk, Chr(10), Chr(13) & Chr(10))
        'txtTip.Text = Replace(StrTip, Chr(10), Chr(13) & Chr(10))
        'txtStep.Text = Replace(StrStep, Chr(10), Chr(13) & Chr(10))

        DS2.Clear()
    End Sub

    Private Sub txtDes_TextChanged(sender As Object, e As EventArgs) Handles txtDes.MouseClick
        If Strings.Left(txtDes.Text, 3) = "ex)" Then
            txtDes.ForeColor = Color.Black
            txtDes.Text = ""
        End If


    End Sub

    'Private Sub txtRisk_TextChanged(sender As Object, e As EventArgs) Handles txtRisk.MouseClick
    '    If Strings.Left(txtRisk.Text, 3) = "ex)" Then
    '        txtRisk.ForeColor = Color.DarkGray
    '        txtRisk.Text = ""
    '    End If


    'End Sub

    'Private Sub txtTip_TextChanged(sender As Object, e As EventArgs) Handles txtTip.MouseClick
    '    If Strings.Left(txtTip.Text, 3) = "ex)" Then
    '        txtTip.ForeColor = Color.DarkGray
    '        txtTip.Text = ""
    '    End If
    'End Sub

    'Private Sub txtStep_TextChanged(sender As Object, e As EventArgs) Handles txtStep.MouseClick
    '    If Strings.Left(txtStep.Text, 3) = "ex)" Then
    '        txtStep.ForeColor = Color.DarkGray
    '        txtStep.Text = ""
    '    End If
    'End Sub

End Class