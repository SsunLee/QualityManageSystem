Imports System.Data
Imports System.Data.OleDb

Public Class Consumer_Add
    Public DS As DataSet = New DataSet
    Public DA As OleDbDataAdapter = New OleDbDataAdapter()
    Public strSQL As String
    Public vConn As OleDbConnection
    Private strSht As String
    ' 유형 관련 
    Public Sub Consumer_Add_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'Dim strCheck As String

        'Gubun_Txt.Text = Consumer1.GubunCb.Text

        'Dim strTest As String = Consumer.GubunCb.Text

        'If Consumer.opSan.Checked = True Then
        '    strCheck = "Y_Sanity"
        'ElseIf Consumer.opBasic.Checked = True Then
        '    strCheck = "Y_Basic"
        'ElseIf Consumer.opFull.Checked = True Then
        '    strCheck = "Y_Full"
        'ElseIf Consumer.op5.Checked = True Then
        '    strCheck = "Y_5대 기능"
        'End If

        'Priority_Txt.Text = strCheck

        'Type_CB.Items.Add("Depth 추가")

        'Interrupt_Txt.Text = Consumer.lstType.Text
        'Module_Txt.Text = Consumer.lstModule.Text
        'Sub_Txt.Text = Consumer.lstFea.Text
        'Condition_Txt.Text = Consumer.UserCondition.Text

        'Module_Txt.Text = Consumer.lstFea.Text


        For Each v In System.Windows.Forms.Application.OpenForms
            If v.Name = "Main_Form" Then
                Requester.Text = v.strUserName
                Requester.ReadOnly = True
                Exit For
            End If
        Next


        Default_Txt.Select()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        '요청 DB 날짜를 저장하는 부분
        Dim strDate = Now() ' Format(Now(), "DDD MMM DD")
        'Dim ReturnOP As String = Nothing
        Dim strsht = "Request_Consumer"


        ' 미리 열어서 중복 되지 않게 
        'Dim chSQL = "Select * from [" & strsht & "] where app = '" & AppCB.Text & "' and feature = '" & FeaCB.Text & "' and [Description_Test Type] = '" & Default_Txt.Text & "';"
        Dim strMerge As String

        If Condition_Txt.Text = "" Then
            strMerge = Interrupt_Txt.Text & ">" & Module_Txt.Text & ">" & Sub_Txt.Text & ">" & Feature_Txt.Text
        Else
            strMerge = Interrupt_Txt.Text & ">" & Module_Txt.Text & ">" & Sub_Txt.Text & ">" & Feature_Txt.Text & ">" & Condition_Txt.Text
        End If

        Dim strMaster As String = "염경민"

        '####### 쿼리 작성 ####################################
        strSQL = "INSERT INTO [" & strsht & "] ([유형],[구분],[선정기준], [Depth], [요청내용], [요청상세내용], [요청자], [담당자], [상태], [요청날짜]) " & ""
        strSQL = strSQL + "VALUES ('" & Type_CB.Text & "','" & Gubun_Txt.Text & "','" & Priority_Txt.Text & "','" & strMerge & "','" & Type_CB.Text & "','" & Default_Txt.Text & "','" & Requester.Text & "','" & strMaster & "','" & "Assigned" & "','" & strDate & "')"
        'strSQL = strSQL + "VALUES ('추가','[" & Gubun_Txt.Text & "]','[" & Priority_Txt.Text & "]','[" & strMerge & "]','[" & Type_CB.Text & "]','[" & Default_Txt.Text & "]','[" & Requester.Text & "]','[" & strMaster & "','" & "Assigned" & "','" & strDate & "')"
        '######################################################
        Try
            Dim xml As New XML
            Dim vCon As String = Nothing
            ' vcon가져오는 함수
            xml.vCon_Admin_Call(vCon)
            xml = Nothing

            ' Connect 연결
            vConn = New OleDbConnection(vCon)

            DA = New OleDbDataAdapter(strSQL, vConn)
            DA.Fill(DS, strsht)

            MsgBox("성공적으로 요청 완료 했습니다",, "lee.sunbae@lgepartner.com")

        Catch ex As Exception
            MsgBox(ex.Message, "요청에 실패 하였습니다")
        End Try
    End Sub

End Class