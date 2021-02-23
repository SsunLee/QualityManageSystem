Imports System.Data
Imports System.Data.OleDb

Public Class Consumer
    Public DS As DataSet = New DataSet
    Public DA As OleDbDataAdapter = New OleDbDataAdapter()
    Public vConn As OleDbConnection
    Private strSht As String

    Private Sub Consumer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        With GubunCb.Items
            .Add("SW Interrupt_내부,외부")
            .Add("SW Interrupt_사용자Action")
            .Add("HW Interrupt")
            .Add("Environment(환경)")
            .Add("SW_고객행동패턴")
            .Add("HW_고객행동패턴")
        End With
    End Sub

    Private Sub btnLoad_Click(sender As Object, e As EventArgs) Handles btnLoad.Click
        ' Load Button을 눌렀을 때 
        Dim argWord As String = Nothing
        lstType.Items.Clear()
        lstModule.Items.Clear()
        lstSub.Items.Clear()
        lstFea.Items.Clear()
        UserCondition.Text = ""
        txtDes.Text = ""

        strSht = GubunCb.Text
        ' Option Button을 어떤 것을 선택 했는지 파악 
        If opSan.Checked = True Then
            argWord = opSan.Text
        ElseIf opBasic.Checked = True Then
            argWord = opBasic.Text
        ElseIf opFull.Checked = True Then
            argWord = opFull.Text
            'Else
            'MsgBox("선정 기준을 선택 후 다시 시도해주세요.",, "lee.sunbae@lgepartner.com")
        End If

        Dim vSQLmod As String = Nothing
        Dim vSQL5Dae As String = Nothing
        Dim arg5Dae As String = Nothing


        If argWord = "" Then
            vSQLmod = ""       ' 용어
        Else
            vSQLmod = "And [선정기준] LIKE '%" & Replace(argWord, "'", "''") & "%'"
        End If

        vSQL5Dae = " Or [선정기준] LIKE '%" & Replace("Y_5대기능", " '", "''") & "%'"

        '#### 쿼리 작성 #############################################################
        Dim vSQL As String = "SELECT * " & " "
        vSQL = vSQL + "FROM [" & strSht & "] as m " & " "
        vSQL = vSQL + "Where [선정기준] > '' " & vSQLmod & vSQL5Dae
        '##########################################################################
        Try
            Dim xml As New XML
            Dim vCon As String = Nothing
            ' vcon가져오는 함수
            xml.vCon_Call(vCon)
            xml = Nothing

            ' Connect 연결
            vConn = New OleDbConnection(vcon)

            'Dim DA = New OleDbDataAdapter(vSQL, vConn)
            DA = New OleDbDataAdapter(vSQL, vConn)
            'DS.Clear()
            Dim DS As New DataSet

            DA.Fill(DS, strSht)

            Dim Table_Word As DataTable = DS.Tables(0)

            If Table_Word.Rows.Count = 0 Then
                MsgBox("검색결과가 없습니다.")
            End If

            For i As Integer = 0 To Table_Word.Rows.Count - 1    ' Data table Row 만큼 반복 -1은 마지막행은 Null
                Try
                    If Not lstType.Items.Contains(Table_Word.Rows(i)(1).ToString()) Then  ' 중복 없이 Item 추가
                        lstType.Items.Add(Table_Word.Rows(i)(1).ToString())
                    End If

                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            Next

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


    End Sub
    ' #### [ Type 선택 시 ex. 외부 인터럽트, 내부 인터럽트, etc ] #####################
    Private Sub lstType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstType.SelectedIndexChanged
        Try
            Dim DS As New DataSet
            DA.Fill(DS, strSht)
            Dim Table As DataTable = DS.Tables(0)

            lstModule.Items.Clear()      ' Data Clear
            lstSub.Items.Clear()      ' Data Clear 
            lstFea.Items.Clear()
            UserCondition.Items.Clear()
            txtDes.Text = ""            ' 설명 초기화 

            For i As Integer = 0 To Table.Rows.Count - 1    ' Data table Row 만큼 반복 -1은 마지막행은 Null

                If lstType.Text = Table.Rows(i)(1).ToString() Then ' 선택 된 App과 Row, 필트(0)은 App, (1) 은 Feature
                    Try
                        If Not lstModule.Items.Contains(Table.Rows(i)(2).ToString()) Then  ' 중복 없이 Item 추가
                            lstModule.Items.Add(Table.Rows(i)(2).ToString())
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
    ' #### [ Module 선택 시 ex. 3rd Party, Alarm, Calendar, etc ] #####################
    Private Sub lstModule_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstModule.SelectedIndexChanged
        Try
            Dim DS As New DataSet
            DA.Fill(DS, strSht)
            Dim Table As DataTable = DS.Tables(0)

            lstSub.Items.Clear()      ' Data Clear 
            lstFea.Items.Clear()
            UserCondition.Items.Clear()
            txtDes.Text = ""            ' 설명 초기화 

            For i As Integer = 0 To Table.Rows.Count - 1    ' Data table Row 만큼 반복 -1은 마지막행은 Null

                If lstType.Text = Table.Rows(i)(1).ToString() And lstModule.Text = Table.Rows(i)(2).ToString() Then ' 선택 된 App과 Row, 필트(0)은 App, (1) 은 Feature
                    Try
                        If Not lstSub.Items.Contains(Table.Rows(i)(3).ToString()) Then  ' 중복 없이 Item 추가
                            lstSub.Items.Add(Table.Rows(i)(3).ToString())
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
    ' #### [ Sub 선택 시 ex. 추가, 삭제, 중지, etc ] #####################
    Private Sub lstSub_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstSub.SelectedIndexChanged
        Try
            Dim DS As New DataSet
            DA.Fill(DS, strSht)
            Dim Table As DataTable = DS.Tables(0)


            lstFea.Items.Clear()      ' Data Clear 
            UserCondition.Items.Clear()
            txtDes.Text = ""            ' 설명 초기화 

            For i As Integer = 0 To Table.Rows.Count - 1    ' Data table Row 만큼 반복 -1은 마지막행은 Null

                If lstType.Text = Table.Rows(i)(1).ToString() And lstModule.Text = Table.Rows(i)(2).ToString() And lstSub.Text = Table.Rows(i)(3).ToString() Then ' 선택 된 App과 Row, 필트(0)은 App, (1) 은 Feature
                    Try
                        If Table.Rows(i)(4).ToString() = "" Then
                            Dim strTextCom = Table.Rows(i)(5).ToString()
                            strTextCom = Replace(strTextCom, Chr(10), Chr(13) & Chr(10))
                            txtDes.Text = strTextCom
                        Else
                            If Not lstFea.Items.Contains(Table.Rows(i)(4).ToString()) Then  ' 중복 없이 Item 추가
                                lstFea.Items.Add(Table.Rows(i)(4).ToString())
                            End If
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

    Private Sub lstFea_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstFea.SelectedIndexChanged
        Try
            Dim DS As New DataSet
            DA.Fill(DS, strSht)
            Dim Table As DataTable = DS.Tables(0)

            txtDes.Text = ""            ' 설명 초기화 
            UserCondition.Items.Clear()
            For i As Integer = 0 To Table.Rows.Count - 1    ' Data table Row 만큼 반복 -1은 마지막행은 Null
                If lstType.Text = Table.Rows(i)(1).ToString() And
                 lstModule.Text = Table.Rows(i)(2).ToString() And
                    lstSub.Text = Table.Rows(i)(3).ToString() And
                    lstFea.Text = Table.Rows(i)(4).ToString() Then ' 선택 된 App과 Row, 필트(0)은 App, (1) 은 Feature
                    Try
                        If GubunCb.Text = "HW_고객행동패턴" Then
                            If Not UserCondition.Items.Contains(Table.Rows(i)(5).ToString()) Then  ' 중복 없이 Item 추가
                                UserCondition.Items.Add(Table.Rows(i)(5).ToString())
                            End If
                            'txtDes.Text = Table.Rows(i)(6).ToString()
                        Else
                            Dim strTextCom = Table.Rows(i)(5).ToString()
                            strTextCom = Replace(strTextCom, Chr(10), Chr(13) & Chr(10))
                            txtDes.Text = strTextCom
                        End If
                        'If Not lstFea.Items.Contains(Table.Rows(i)(4).ToString()) Then  ' 중복 없이 Item 추가

                        ' End If
                    Catch ex As Exception
                        MsgBox(ex.Message)
                    End Try
                End If
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub UserCondition_SelectedIndexChanged(sender As Object, e As EventArgs) Handles UserCondition.SelectedIndexChanged
        Try
            Dim DS As New DataSet
            DA.Fill(DS, strSht)
            Dim Table As DataTable = DS.Tables(0)

            txtDes.Text = ""            ' 설명 초기화 

            For i As Integer = 0 To Table.Rows.Count - 1    ' Data table Row 만큼 반복 -1은 마지막행은 Null
                If lstType.Text = Table.Rows(i)(1).ToString() And
                 lstModule.Text = Table.Rows(i)(2).ToString() And
                    lstSub.Text = Table.Rows(i)(3).ToString() And
                    lstFea.Text = Table.Rows(i)(4).ToString() And
                    UserCondition.Text = Table.Rows(i)(5).ToString() Then ' 선택 된 App과 Row, 필트(0)은 App, (1) 은 Feature
                    Try
                        If GubunCb.Text = "HW_고객행동패턴" Then
                            Dim strTextCom = Table.Rows(i)(6).ToString()
                            strTextCom = Replace(strTextCom, Chr(10), Chr(13) & Chr(10))
                            txtDes.Text = strTextCom
                        Else

                        End If
                        'If Not lstFea.Items.Contains(Table.Rows(i)(4).ToString()) Then  ' 중복 없이 Item 추가

                        ' End If
                    Catch ex As Exception
                        MsgBox(ex.Message)
                    End Try
                End If
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub GubunCb_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GubunCb.SelectedIndexChanged
        If GubunCb.Text <> "HW_고객행동패턴" Then
            UserCondition.Text = ""
            txtDes.Text = ""
        End If

        lstType.Items.Clear()
        lstModule.Items.Clear()
        lstSub.Items.Clear()
        lstFea.Items.Clear()
        UserCondition.Items.Clear()

    End Sub

    Public Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim strCheck As String = Nothing
        Dim Consumer_Add As New Consumer_Add
        Consumer_Add.Gubun_Txt.Text = GubunCb.Text

        If opSan.Checked = True Then
            strCheck = "Y_Sanity"
        ElseIf opBasic.Checked = True Then
            strCheck = "Y_Basic"
        ElseIf opFull.Checked = True Then
            strCheck = "Y_Full"
        ElseIf op5.Checked = True Then
            strCheck = "Y_5대 기능"
        End If

        Consumer_Add.Priority_Txt.Text = strCheck
        Consumer_Add.Type_CB.Items.Add("Depth 추가")
        Consumer_Add.Type_CB.Items.Add("수정")

        Consumer_Add.Interrupt_Txt.Text = lstType.Text
        Consumer_Add.Module_Txt.Text = lstModule.Text
        Consumer_Add.Sub_Txt.Text = lstSub.Text
        Consumer_Add.Feature_Txt.Text = lstFea.Text
        Consumer_Add.Condition_Txt.Text = UserCondition.Text

        Consumer_Add.Show()

    End Sub
End Class