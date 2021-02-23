Imports System.Data
Imports System.Data.OleDb

Public Class Terms_Request
    Public DS As DataSet = New DataSet
    Public DS_Admin As DataSet = New DataSet
    Public DA As OleDbDataAdapter = New OleDbDataAdapter()
    Public strSQL As String
    Public vConn As OleDbConnection
    Public XML As New XML
    Private strSht As String = "Request_Dictionary"
    Private strDictionary = "History_Dictionary"
    Public vCon As String = Nothing
    Public selectItem As String

    Public prevWord As String

    Public strCon As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\신창하\업무\Task\Test_db\20180328_QPortalDB.accdb;Jet OLEDB:Database Password = lge1234;"
    Public strConadmin As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\신창하\업무\Task\Test_db\admin\QPortalDB_Admin.accdb;Jet OLEDB:Database Password = lge1234;"




    Private Sub Terms_Request_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Type_CB.Items.Add("수정")
        Type_CB.Items.Add("추가")

        For Each v In System.Windows.Forms.Application.OpenForms
            If v.Name = "Main_Form" Then
                Requester.Text = v.strUserName
                Requester.ReadOnly = True
                Exit For
            End If
        Next

        DesTxt.Select()

        prevWord = strWord.Text

    End Sub

    Private Sub Submit_Click(sender As Object, e As EventArgs) Handles Submit.Click

        '예외 처리 
        If Type_CB.Text = "" Or strWord.Text = "" Or DesTxt.Text = "" Then
            MsgBox("입력 안된 항목이 있습니다.")
            Exit Sub
        End If

        If Requester.Text = "" Then
            MsgBox("요청자 입력 후 시도하세요")
            Exit Sub
        End If


        '요청 DB 날짜를 저장하는 부분
        Dim strDate = Now() ' Format(Now(), "DDD MMM DD")

        ' 미리 열어서 중복 되지 않게 
        'Dim chSQL = "Select * from [" & strsht & "] where app = '" & AppCB.Text & "' and feature = '" & FeaCB.Text & "' and [Description_Test Type] = '" & Default_txt.Text & "';"




        Dim strMaster As String = "신창하"
        Dim strStatus As String = "Assigned"
        Dim strSQL As String

        '####### 쿼리 작성 ####################################
        strSQL = "INSERT INTO [" & strSht & "] ([용어],[유형],[요청내용], [요청자], [요청날짜], [담당자], [상태]) " & ""
        strSQL = strSQL + "VALUES ('" & strWord.Text & "','" & Type_CB.Text & "','" & addDes.Text & "','" & Requester.Text & "','" & strDate & "','" & strMaster & "','" & strStatus & "'); "
        'strSQL = strSQL + "VALUES ('[" & strWord.Text & "]','[" & Requester.Text & "]','[" & strMaster & "]','[" & strStatus & "]','[" & Type_CB.Text & "]','[" & addDes.Text & "]','[" & strDate & "]'); "
        '######################################################
        Try


            ' vcon가져오는 함수
            XML.vCon_Admin_Call(vCon)
            ' DB Connect 연결
            vConn = New OleDbConnection(vCon) 'strcon_admin

            DA = New OleDbDataAdapter("Select A_Name From Admin_Name", vConn)
            DA.Fill(DS_Admin, "관리자")

            Dim Admin As DataTable
            Dim chkAdmin As Boolean
            Admin = DS_Admin.Tables(0)


            For Each a In Admin.Rows
                If a(0) = Requester.Text Then
                    chkAdmin = True
                End If
            Next


            If chkAdmin = True Then

                Dim updateDic As String = "용어"
                Dim Dictionary_GM As New Dictionary_GM

                Try
                    XML.vCon_Call(vCon)
                    vConn = New OleDbConnection(vCon) 'strocn
                    DA = New OleDbDataAdapter("UPDATE " & updateDic & " SET 용어 = '" & strWord.Text & "', 설명 = '" & DesTxt.Text & "' " &
                                              "WHERE 용어 = '" & selectItem & "'", vConn)

                    DA.Fill(DS, updateDic)
                    MsgBox("수정 되었습니다")
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try

                'History 기록
                Dim UserName As String = Nothing
                ' 이름을 받아옴
                For Each v In System.Windows.Forms.Application.OpenForms
                    If v.Name = "Main_Form" Then
                        UserName = v.strUserName
                        Exit For
                    End If
                Next

                'Admin DB 연결
                XML.vCon_Admin_Call(vCon)
                vConn = New OleDbConnection(vCon) 'strcon_admin
                Try

                    DA = New OleDbDataAdapter("INSERT INTO " & strDictionary & "(대분류, 용어, 내용, 구분, 담당자, 변경날짜) VALUES ('[요청 Page]', '" & prevWord & "', '" & strWord.Text & " / " & DesTxt.Text & "', '" & "수정" & "', '" & UserName & "', '" & Now & "');", vConn)
                    DA.Fill(DS, strDictionary)

                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try




            Else
                XML.vCon_Call(vCon)
                vConn = New OleDbConnection(vCon) 'strcon
                DA = New OleDbDataAdapter(strSQL, vConn)
                DA.Fill(DS, strSht)

                MsgBox("성공적으로 요청 완료 했습니다",, "lee.sunbae@lgepartner.com")

                Dim Outl As Object
                Outl = CreateObject("Outlook.Application")
                If Outl IsNot Nothing Then
                    Dim omsg As Object
                    omsg = Outl.CreateItem(0)
                    omsg.To = "lee.sunbae@lgepartner.com" & ";" & "changha.shin@lgepartner.com"
                    'omsg.bcc = "kim.byungjun@lgepartner.com"
                    omsg.subject = "[안내] 제안하기 완료 안내 메일"
                    omsg.body = "LGE Internal Use Only" & vbCrLf & vbCrLf & "요청 내용 : " & addDes.Text & vbCrLf & "담당자에게 전달이 완료 되었습니다."
                    'omsg.Attachments.Add("c:\HP\opcserver.txt")
                    'set message properties here...'
                    ' omsg.Display(True) 'will display message to user
                    omsg.Send()
                End If
            End If




        Catch ex As Exception
            MsgBox(ex.Message, "요청에 실패 하였습니다")
        End Try



    End Sub

    Private Sub Type_CB_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Type_CB.SelectedIndexChanged

        If Type_CB.Text = "추가" Then
            strWord.Text = ""
            DesTxt.Text = ""
            addDes.Text = ""
        End If

    End Sub

    Private Sub Type_CB_Click(sender As Object, e As EventArgs) Handles Type_CB.Click
        If InStr(DesTxt.Text, "ex)") Then
            DesTxt.Text = ""

        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

    End Sub
End Class