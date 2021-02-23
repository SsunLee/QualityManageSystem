Imports System.Data
Imports System.Data.OleDb
Imports System.Xml
Imports System.Windows.Forms

Public Class Summary_Add
    Public DS As DataSet = New DataSet
    Public DA As OleDbDataAdapter = New OleDbDataAdapter()
    Public strSQL As String
    Public vConn As OleDbConnection
    Public txttype, txtapp, txtfeat As String
    Private strReq As String = "Request_App"
    Private strReqTA As String = "Request_TestAction"
    Public szADName As String
    Public strCon As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\신창하\업무\Task\Test_db\admin\QPortalDB_Admin.accdb;Jet OLEDB:Database Password = lge1234;"


    Private Sub Submit_Click(sender As Object, e As EventArgs) Handles Submit.Click

        'vConn.ConnectionString = Main_Form.strCon
        ' XML에서 Admin vCon 가져옴
        Dim xml As New XML
        Dim vCon As String = Nothing
        xml.vCon_Admin_Call(vCon)
        xml = Nothing

        vConn = New OleDbConnection(vCon) 'strcon

        If radioApp.Checked = True Then

            If AppTxt.Text = "" Or FeaTxt.Text = "" Or DesTxt.Text = "" Then
                MsgBox("입력되지 않은 항목이 있습니다.")
                Exit Sub
            End If

            'If Requester.Text = "" Then
            '    MsgBox("요청자 입력 후 시도하세요")
            '    Exit Sub
            'End If

            '요청 DB 날짜를 저장하는 부분
            'Dim strDate = Now() ' Format(Now(), "DDD MMM DD")

            '========== 쿼리 작성 ============
            strSQL = "INSERT INTO [" & strReq & "] ([Type],[AppName],[Feature],[Description],[Requester],[Manager],[Status]) "
            strSQL = strSQL + "VALUES ('" & cbReqtype.Text & "','" & AppTxt.Text & "','" & FeaTxt.Text & "','" & DesTxt.Text & "','" & Requester.Text & "','" & "신창하" & "','" & "New" & "')"
            '=================================


            Try

                DA = New OleDbDataAdapter(strSQL, vConn)
                DA.Fill(DS, strReq)


                Dim xmlReader = New XmlTextReader(Application.StartupPath + "\QPortal_Path.XML")
                Do While xmlReader.Read() ' XML 파일 한줄씩 읽어옴
                    If xmlReader.NodeType = XmlNodeType.Element AndAlso xmlReader.Name = "AD_Name" Then ' NodeType가 Element고 Name이 Address일 경우
                        szADName = xmlReader.ReadElementContentAsString ' 해당 Element의 String값을 읽어옴
                    End If
                Loop
                xmlReader.Close() ' XML Reader 닫음

                '2018_03_13 신창하 기능제안 요청자 확인하기
                Dim strRequester As String = Nothing
                strRequester = Requester.Text
                strRequester = Mid(strRequester, InStr(strRequester, "(") + 1)
                strRequester = Replace(strRequester, ")", vbNullString)

                Dim Outl As Object
                Outl = CreateObject("Outlook.Application")
                If Outl IsNot Nothing Then
                    Dim omsg As Object
                    omsg = Outl.CreateItem(0)
                    omsg.To = "changha.shin@lgepartner.com" & ";" & "lee.sunbae@lgepartner.com"
                    'omsg.bcc = "kim.byungjun@lgepartner.com"
                    omsg.subject = "[안내] 제안하기 요청 안내 메일"
                    omsg.body = "LGE Internal Use only" & vbCrLf & vbCrLf & "요청 내용" & vbCrLf & lbType.Text & " " & cbReqtype.Text & vbCrLf & lbApp.Text & " " & AppTxt.Text &
                    vbCrLf & lbFeature.Text & " " & FeaTxt.Text & vbCrLf & lbDes.Text & " " & DesTxt.Text & vbCrLf & vbCrLf & "위 내용의 App추가 요청이 있습니다." & vbCrLf & "요청자 : " & Requester.Text
                    'omsg.Attachments.Add("c:\HP\opcserver.txt")
                    'set message properties here...'
                    ' omsg.Display(True) 'will display message to user
                    omsg.Send()

                    '2018_03_13 신창하 기능제안 요청자에게 확인안내 메일 가도록 추가
                    Dim qmsg As Object
                    qmsg = Outl.createitem(0)
                    qmsg.To = strRequester & "@lgepartner.com;"
                    qmsg.subject = "[안내] 제안하기 완료 안내 메일"
                    qmsg.body = "LGE Internal Use only" & vbCrLf & vbCrLf & "요청 내용" & vbCrLf & lbType.Text & " " & cbReqtype.Text & vbCrLf & lbApp.Text & " " & AppTxt.Text & vbCrLf & lbFeature.Text & " " & FeaTxt.Text & vbCrLf & lbDes.Text & " " & DesTxt.Text & vbCrLf & vbCrLf &
                    "담당자에게 전달이 완료 되었습니다." & vbCrLf & "요청자 : " & Requester.Text
                    qmsg.send()

                End If

                MsgBox("성공적으로 요청 완료 했습니다",, "Changha.shin@lgepartner.com")

            Catch ex As Exception
                MsgBox(ex.Message, "요청에 실패 하였습니다")
            End Try

            '################# Detailed Symptom 요청 시 #####################
        ElseIf radioTA.Checked = True Then

            If AppTxt.Text = "" Or FeaTxt.Text = "" Or DesTxt.Text = "" Then
                MsgBox("입력되지 않은 항목이 있습니다.")
                Exit Sub
            End If

            'If Requester.Text = "" Then
            '    MsgBox("요청자 입력 후 시도하세요")
            '    Exit Sub
            'End If

            '요청 DB 날짜를 저장하는 부분
            'Dim strDate = Now() ' Format(Now(), "DDD MMM DD")

            '========== 쿼리 작성 ============
            strSQL = "INSERT INTO [" & strReqTA & "] ([TestAction_Type],[TestAction],[Detailed_Symptom1],[Detailed_Symptom2],[Description],[Requester],[Manager],[Status]) "
            strSQL = strSQL + "VALUES ('" & txtTypeTA.Text & "', '" & txtTA.Text & "', '" & AppTxt.Text & "', '" & FeaTxt.Text & "', '" & DesTxt.Text & "', '" & Requester.Text & "', '" & "신창하" & "', '" & "New" & "')"
            '=================================

            Try
                'vConn.ConnectionString = Main_Form.strCon

                DA = New OleDbDataAdapter(strSQL, vConn)
                DA.Fill(DS, strReqTA)


                Dim xmlReader = New XmlTextReader(Application.StartupPath + "\QPortal_Path.XML")
                Do While xmlReader.Read() ' XML 파일 한줄씩 읽어옴
                    If xmlReader.NodeType = XmlNodeType.Element AndAlso xmlReader.Name = "AD_Name" Then ' NodeType가 Element고 Name이 Address일 경우
                        szADName = xmlReader.ReadElementContentAsString ' 해당 Element의 String값을 읽어옴
                    End If
                Loop
                xmlReader.Close() ' XML Reader 닫음

                '2018_03_13 신창하 기능제안 요청자 확인하기
                Dim strRequester As String = Nothing
                strRequester = Requester.Text
                strRequester = Mid(strRequester, InStr(strRequester, "(") + 1)
                strRequester = Replace(strRequester, ")", vbNullString)

                Dim Outl As Object
                Outl = CreateObject("Outlook.Application")
                If Outl IsNot Nothing Then
                    Dim omsg As Object
                    omsg = Outl.CreateItem(0)
                    omsg.To = "changha.shin@lgepartner" & ";" '& "lee.sunbae@lgepartner.com"
                    'omsg.bcc = "kim.byungjun@lgepartner.com"
                    omsg.subject = "[안내] 제안하기 요청 안내 메일"
                    omsg.body = "LGE Internal Use only" & vbCrLf & vbCrLf & "요청 내용" & vbCrLf & lbTypeTA.Text & " " & txtTypeTA.Text & lbType.Text & " " & txtTA.Text & vbCrLf & lbApp.Text & " " & AppTxt.Text &
                    vbCrLf & lbFeature.Text & " " & FeaTxt.Text & vbCrLf & lbDes.Text & " " & DesTxt.Text & vbCrLf & vbCrLf & "위 내용의 Test Action 추가 요청이 있습니다." & vbCrLf & "요청자 : " & Requester.Text
                    'omsg.Attachments.Add("c:\HP\opcserver.txt")
                    'set message properties here...'
                    ' omsg.Display(True) 'will display message to user
                    omsg.Send()

                    '2018_03_13 신창하 기능제안 요청자에게 확인안내 메일 가도록 추가
                    Dim qmsg As Object
                    qmsg = Outl.createitem(0)
                    qmsg.To = strRequester & "@lgepartner.com;"
                    qmsg.subject = "[안내] 제안하기 완료 안내 메일"
                    qmsg.body = "LGE Internal Use only" & vbCrLf & vbCrLf & "요청 내용" & vbCrLf & lbTypeTA.Text & " " & txtTypeTA.Text & lbType.Text & " " & txtTA.Text & vbCrLf & lbApp.Text & " " & AppTxt.Text & vbCrLf & lbFeature.Text & " " & FeaTxt.Text & vbCrLf & lbDes.Text & " " & DesTxt.Text & vbCrLf & vbCrLf &
                    "담당자에게 전달이 완료 되었습니다." & vbCrLf & "요청자 : " & Requester.Text
                    qmsg.send()

                End If
                MsgBox("성공적으로 요청 완료 했습니다",, "Changha.shin@lgepartner.com")
            Catch ex As Exception
                MsgBox(ex.Message, "요청에 실패하였습니다")
            End Try
        End If

        '예외 처리 

    End Sub

    Private Sub Summary_Add_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '  Requester.Text = My.Settings.strTester
        txttype = "Type :"
        txtapp = "App :"
        txtfeat = "Feature :"
        For Each v In System.Windows.Forms.Application.OpenForms
            If v.Name = "Main_Form" Then
                Requester.Text = v.strUserName
                Requester.ReadOnly = True
                Exit For
            End If
        Next

        DesTxt.Select()
        With cbReqtype
            .Items.Add("LG")
            .Items.Add("GMS")
            .Items.Add("Operator")
            .Text = cbReqtype.Items(0)
        End With

        radioApp.Checked = True
        txtTA.Visible = False

        Call radioApp_Click(sender, e)

    End Sub

    Private Sub cbReqtype_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbReqtype.SelectedIndexChanged
        If cbReqtype.Text = "Operator" Then
            lbApp.Text = "사업자명 :"
            lbFeature.Text = "App :"
            'lbApp.Location = New Drawing.Point(33, 68)
            'lbFeature.Location = New Drawing.Point(71, 123)
        Else
            lbApp.Text = "App :"
            lbFeature.Text = "Feature :"
            'lbApp.Location = New Drawing.Point(71, 92)
            'lbFeature.Location = New Drawing.Point(12, 123)
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        If MsgBox("작성한 내용을 전부 초기화 하시겠습니까?", vbYesNo) = vbYes Then
            AppTxt.Text = ""
            FeaTxt.Text = ""
            DesTxt.Text = ""
            txtTA.Text = ""
            cbReqtype.Text = cbReqtype.Items(0)
        Else

        End If

    End Sub

    Private Sub radioApp_Click(sender As Object, e As EventArgs) Handles radioApp.Click

        txtTA.Visible = False
        cbReqtype.Visible = True
        Label1.Text = "App_Feature"
        lbType.Text = txttype
        lbApp.Text = txtapp
        lbFeature.Text = txtfeat
        lbTypeTA.Visible = False
        txtTypeTA.Visible = False


    End Sub

    Private Sub radioTA_CheckedChanged(sender As Object, e As EventArgs) Handles radioTA.Click

        txtTA.Visible = True
        cbReqtype.Visible = False

        txttype = lbType.Text
        txtapp = lbApp.Text
        txtfeat = lbFeature.Text

        Label1.Text = "Test Action"
        lbType.Text = "Test Action :"
        lbApp.Text = "Symptom1 :"
        lbFeature.Text = "Symptom2 :"

        lbTypeTA.Visible = True
        txtTypeTA.Visible = True

    End Sub
End Class