Imports System.Data.OleDb
Imports System.Drawing
Imports System.Windows.Forms
Imports Excel = Microsoft.Office.Interop.Excel
Imports Microsoft.Office
Imports System.Data
Imports System.IO

Public Class TestCase_GM
    Public DS As DataSet = New DataSet
    Public DA As OleDbDataAdapter = New OleDbDataAdapter()
    Public strSQL As String
    Public vConn As OleDbConnection
    Public Main_Form As New Main_Form
    Private strSht As String = "Summary"
    Private strMasterTC As String
    Public strFilePath, strFileName, szFilePath As String
    Private szFile As String = Nothing
    Private strOpenPath As String = Nothing
    Private strCon As String = Nothing

    Private Sub TestCase_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '####  업무 가이드 최초 Load 될 때 ####

        strSht = "Summary"
        '#### 쿼리 작성 #############################################################
        Dim vSQL As String = "SELECT * " & " "
        vSQL = vSQL + "FROM [" & strSht & "$]" & " "
        vSQL = vSQL + "Where [구분] > '' "
        '##########################################################################

        Try
            ' XML에서 Admin vCon 가져옴
            Dim xml As New XML
            Dim vCon As String = Nothing
            'xml.vCon_Call(vCon)
            xml.Folder_Path("MasterNonTC", strFilePath)
            xml = Nothing

            szFilePath = strFilePath + "\DB"
            strFileName = "NonFunction 가이드.xlsx"

            strOpenPath = szFilePath + "\" + strFileName
            strCon = "Provider=Microsoft.Ace.OLEDB.12.0;Data Source=" & strOpenPath & ";Extended Properties=""Excel 12.0;HDR=YES;"""
            vConn = New OleDbConnection(strCon)

            DA = New OleDbDataAdapter(vSQL, vConn)

            Dim DS As New DataSet

            DA.Fill(DS, strSht)

            Dim Table_Word As DataTable = DS.Tables(0)

            If Table_Word.Rows.Count = 0 Then
                MsgBox("검색결과가 없습니다.")
            End If

            Table_Word = Table_Word.DefaultView.ToTable(True, "구분")
            GubunCB.DataSource = Table_Word
            With GubunCB
                .DisplayMember = "구분"
                .ValueMember = "구분"
            End With

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub GubunCB_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GubunCB.SelectedIndexChanged
        Try
            Dim DS As New DataSet
            DA.Fill(DS, strSht)
            Dim Table As DataTable = DS.Tables(0)

            TestGubunCB.Text = ""
            TestGubunCB.Items.Clear()      ' Data Clear
            lstDep.Items.Clear()           ' Data Clear 
            DetectedTxt.Text = ""               ' 설명 초기화 
            TCPurposeTxt.Text = ""
            PriTxt.Text = ""
            MDTxt.Text = ""


            For i As Integer = 0 To Table.Rows.Count - 1            ' Data table Row 만큼 반복 -1은 마지막행은 Null
                If GubunCB.Text = Table.Rows(i)(0).ToString() Then  ' 선택 된 App과 Row, 필트(0)은 App, (1) 은 Feature
                    Try
                        If Not TestGubunCB.Items.Contains(Table.Rows(i)(1).ToString()) Then  ' 중복 없이 Item 추가
                            TestGubunCB.Items.Add(Table.Rows(i)(1).ToString())
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

    Private Sub TestGubunCB_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TestGubunCB.SelectedIndexChanged
        Try
            'DA = New OleDbDataAdapter("SELECT REPLACE(Description, Chr(10), Chr(13) & Chr(10)) FROM Sheet1", vConn)
            'SELECT  REPLACE(Description, Chr(10), Chr(13) & Chr(10)) AS Description From Sheet1
            Dim DS As New DataSet
            DA.Fill(DS, strSht)
            Dim Table As DataTable = DS.Tables(0)

            lstDep.Items.Clear()      ' Data Clear 
            FileName.Text = ""
            DetectedTxt.Text = ""            ' 설명 초기화 
            TCPurposeTxt.Text = ""
            PriTxt.Text = ""
            MDTxt.Text = ""

            For i As Integer = 0 To Table.Rows.Count - 1    ' Data table Row 만큼 반복 -1은 마지막행은 Null

                If GubunCB.Text = Table.Rows(i)(0).ToString() And TestGubunCB.Text = Table.Rows(i)(1).ToString() Then ' 선택 된 App과 Row, 필트(0)은 App, (1) 은 Feature
                    Try
                        If Not lstDep.Items.Contains(Table.Rows(i)(2).ToString()) Then  ' 중복 없이 Item 추가
                            lstDep.Items.Add(Table.Rows(i)(2).ToString())


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

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim dirA As DirectoryInfo = New DirectoryInfo(strFilePath)    ' 디렉토리 지정
        'strPathName = entry
        If InStr(FileName.Text, "없습니다") Then
            Exit Sub
        End If
        For Each dra In dirA.GetFiles()     ' For each를 통해 폴더 내의 파일을 찾음

            If InStr(dra.Name, lstDep.Text) Then
                'szPath_Temp = entry
                szFile = dra.Name
                Exit For
            End If
        Next
        'Next

        Dim szFullPath As String = strFilePath & "\" & szFile
        Try
            Diagnostics.Process.Start(szFullPath)
        Catch ex As Exception
            MsgBox(ex.Message & vbCrLf & "파일이름이 일치하는게 없습니다." & strFilePath & " <- 경로에 실제로 파일이 있는지 봐주세요.", , "lee.sunbae@lgepartner.com")
        End Try
    End Sub

    Private Sub requestBtn_Click(sender As Object, e As EventArgs) Handles requestBtn.Click
        '제안하기 폼

    End Sub

    Private Sub lstDep_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstDep.SelectedIndexChanged
        Try

            strSht = lstDep.Text    ' 조회 할 Table 명을 담음
            ' Query 작성 #############################################
            Dim vSQL As String = "Select * FROM [" & strSht & "$]"
            ' ########################################################

            DA = New OleDbDataAdapter(vSQL, vConn)            ' Data Adapter 를 통해 DB 연결 


            Dim DS2 As New DataSet
            DS2 = New DataSet        ' Data를 담을 DataSet 생성
            DA.Fill(DS2, strSht)
            Dim Table As DataTable = DS2.Tables(0)


            For i As Integer = 3 To Table.Rows.Count - 1

                Dim strTextCom = Table.Rows(i)(2).ToString()
                strTextCom = Replace(strTextCom, Chr(10), Chr(13) & Chr(10))

                If i = 3 Then
                    'TCnameTxt.Text = strTextCom
                ElseIf i = 4 Then
                    TCPurposeTxt.Text = strTextCom
                ElseIf i = 5 Then
                    DetectedTxt.Text = strTextCom
                ElseIf i = 6 Then
                    MDTxt.Text = strTextCom
                ElseIf i = 7 Then
                    PriTxt.Text = strTextCom
                End If
            Next i

            '파일 이름 보여주기


            strSht = "Summary"
            ' Query 작성 #############################################
            vSQL = "Select * FROM [" & strSht & "$]"
            'Dim infoSQL As String = "Select * FROM [" & strInfo & "$]"
            ' ########################################################

            DA = New OleDbDataAdapter(vSQL, vConn)            ' Data Adapter 를 통해 DB 연결 

            DA.Fill(DS, strSht)
            Table = DS.Tables(0)


            FileName.Text = ""


            For i As Integer = 0 To Table.Rows.Count - 1    ' Data table Row 만큼 반복 -1은 마지막행은 Null

                If GubunCB.Text = Table.Rows(i)(0).ToString() And TestGubunCB.Text = Table.Rows(i)(1).ToString() _
                    And lstDep.Text = Table.Rows(i)(2).ToString() Then ' 선택 된 App과 Row, 필트(0)은 App, (1) 은 Feature

                    Try 'Chr(10), Chr(13) & Chr(10)

                        strMasterTC = Table.Rows(i)(3).ToString()
                        If strMasterTC = "-" Or strMasterTC = "" Then
                            FileName.Text = "파일이 없습니다." ' 파일 없을 때
                        Else
                            FileName.Text = Table.Rows(i)(2).ToString() ' 파일 이름 보여줌
                        End If


                    Catch ex As Exception
                        MsgBox(ex.Message)
                    End Try
                End If
            Next
        Catch ex As Exception
            MsgBox("해당 TC는 준비 중 입니다.")
            'MsgBox(ex.Message)
        End Try
    End Sub
End Class