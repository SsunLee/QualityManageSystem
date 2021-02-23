Imports System.Data
Imports System.Data.OleDb

Public Class Tip_Request_GM
    Public DS As DataSet = New DataSet
    Public DA As OleDbDataAdapter = New OleDbDataAdapter()
    Public strSQL As String = Nothing
    Public vConn As OleDbConnection
    'Public Main_Form As New Main_Form
    Private strSht As String = Nothing
    Dim ReturnOP As String = Nothing
    Dim vCon As String = Nothing

    Private Sub Tip_Request_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '####  업무 가이드 최초 Load 될 때 ####

        strSht = "Tip"
        Dim xml As New XML
        ' 요청자 이름을 받아옴
        For Each v In System.Windows.Forms.Application.OpenForms
            If v.Name = "Main_Form" Then
                Requester.Text = v.strUserName
                Requester.ReadOnly = True
                Exit For
            End If
        Next

        Default_txt.Select()

        '#### 쿼리 작성 #############################################################
        Dim vSQL As String = "Select * FROM [" & strSht & "] Where [App] > ''"
        '##########################################################################

        Try

            ' vcon가져오는 함수
            xml.vCon_Call(vCon)
            ' Connect 연결
            vConn = New OleDbConnection(vCon)

            Dim DA = New OleDbDataAdapter(vSQL, vConn)

            DA.Fill(DS, strSht)

            Dim Table_Word As DataTable = DS.Tables(0)

            If Table_Word.Rows.Count = 0 Then
                MsgBox("검색결과가 없습니다.")
            End If

            For i As Integer = 0 To Table_Word.Rows.Count - 1    ' Data table Row 만큼 반복 -1은 마지막행은 Null
                Try
                    If Not AppCB.Items.Contains(Table_Word.Rows(i)(1).ToString()) Then  ' 중복 없이 Item 추가
                        AppCB.Items.Add(Table_Word.Rows(i)(1).ToString())
                    End If

                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            Next

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub AppCB_SelectedIndexChanged(sender As Object, e As EventArgs) Handles AppCB.SelectedIndexChanged
        Try
            'Dim DS As New DataSet
            'DA.Fill(DS, strSht)
            Dim Table As DataTable = DS.Tables(0)

            FeaCB.Items.Clear()
            TypeCB.Items.Clear()

            'TestGubunCB.Text = ""
            'TestGubunCB.Items.Clear()      ' Data Clear
            'lstDep.Items.Clear()           ' Data Clear 
            'txtDes.Text = ""               ' 설명 초기화 

            For i As Integer = 0 To Table.Rows.Count - 1            ' Data table Row 만큼 반복 -1은 마지막행은 Null
                If AppCB.Text = Table.Rows(i)(1).ToString() Then  ' 선택 된 App과 Row, 필트(0)은 App, (1) 은 Feature
                    Try
                        If Not FeaCB.Items.Contains(Table.Rows(i)(2).ToString()) Then  ' 중복 없이 Item 추가
                            FeaCB.Items.Add(Table.Rows(i)(2).ToString())
                        End If

                    Catch ex As Exception
                        MsgBox(ex.Message)
                    End Try
                End If
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub FeaCB_SelectedIndexChanged(sender As Object, e As EventArgs) Handles FeaCB.SelectedIndexChanged
        Try
            'Dim DS As New DataSet
            'DA.Fill(DS, strSht)
            Dim Table As DataTable = DS.Tables(0)

            TypeCB.Items.Clear()

            'lstDep.Items.Clear()      ' Data Clear 
            'FileName.Text = ""
            'txtDes.Text = ""            ' 설명 초기화 

            For i As Integer = 0 To Table.Rows.Count - 1    ' Data table Row 만큼 반복 -1은 마지막행은 Null

                If AppCB.Text = Table.Rows(i)(1).ToString() And FeaCB.Text = Table.Rows(i)(2).ToString() Then ' 선택 된 App과 Row, 필트(1)은 App, (2) 은 Feature
                    Try
                        If Not TypeCB.Items.Contains(Table.Rows(i)(3).ToString()) Then  ' 중복 없이 Item 추가
                            TypeCB.Items.Add(Table.Rows(i)(4).ToString())

                        End If
                    Catch ex As Exception
                        MsgBox(ex.Message)
                    End Try
                End If
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    ' ### Basic Button 클릭 했을 때 ######
    Private Sub opBasic_Click(sender As Object, e As EventArgs) Handles opBasic.Click
        ReturnOP = "Y_Basic"

    End Sub
    ' ### Full Button 클릭 했을 때 ######
    Private Sub opFull_Click(sender As Object, e As EventArgs) Handles opFull.Click
        ReturnOP = "Y_Full"

    End Sub
    ' ### Sanity Button 클릭 했을 때 ######
    Private Sub opSanity_Click(sender As Object, e As EventArgs) Handles opSanity.Click
        ReturnOP = "Y_Sanity"

    End Sub
    Private Sub Submit_btn_Click(sender As Object, e As EventArgs) Handles Submit_btn.Click

        '예외 처리 
        If AppCB.Text = "" Or FeaCB.Text = "" Or TypeCB.Text = "" _
        Or Default_txt.Text = "" Or Around_txt.Text = "" Then
            MsgBox("입력 안된 항목이 있습니다.")
            Exit Sub
        End If

        If Requester.Text = "" Then
            MsgBox("요청자 입력 후 시도하세요")
            Exit Sub
        End If

        '요청 DB 날짜를 저장하는 부분
        Dim strDate = Now() ' Format(Now(), "DDD MMM DD")

        strSht = "Request_Tip"


        ' 미리 열어서 중복 되지 않게 
        Dim chSQL = "Select * from [" & strsht & "] where app = '" & AppCB.Text & "' and feature = '" & FeaCB.Text & "' and [Description_Test Type] = '" & Default_txt.Text & "';"

        '####### 쿼리 작성 ####################################
        strSQL = "INSERT INTO [" & strsht & "] ([App],[Feature],[Test Type], [Import], [Description_Test Type], [Around], [상태], [선정기준], [요청자], [요청날짜]) " & ""
        strSQL = strSQL + "VALUES ('" & AppCB.Text & "','" & FeaCB.Text & "','" & TypeCB.Text & "','" & "Y','" & Default_txt.Text & "','" & Around_txt.Text & "','" & "Assigned" & "','" & ReturnOP & "','" & Requester.Text & "','" & strDate & "'); "
        '######################################################
        Try
            Dim xml As New XML
            ' vcon가져오는 함수
            xml.vCon_Admin_Call(vCon)
            ' Connect 연결
            vConn = New OleDbConnection(vCon)

            DA = New OleDbDataAdapter(strSQL, vConn)
            DA.Fill(DS, strSht)

            MsgBox("성공적으로 요청 완료 했습니다",, "lee.sunbae@lgepartner.com")

        Catch ex As Exception
            MsgBox(ex.Message, "요청에 실패 하였습니다")
        End Try

    End Sub

End Class