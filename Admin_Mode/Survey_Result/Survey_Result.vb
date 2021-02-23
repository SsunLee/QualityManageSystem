Imports System.Data
Imports System.Data.OleDb
Imports System.Drawing
Imports System.IO
Imports System.Windows.Forms
Imports Microsoft.Office.Interop

Public Class Survey_Result

    Dim vConn As OleDbConnection
    Dim DS As New DataSet
    Dim DS_Avg As New DataSet
    Dim Ds_Quetion As New DataSet

    Dim DA As OleDbDataAdapter

    Public Survey_Title As String
    Public Survey_Comp As String
    Public Survey_Fm As String
    Public Survey_Age As String


    Public strFilePath As String = "\\10.169.88.40\Q-Portal\2.검증현황\감성평가"
    Public szKnowHow As String = Nothing 'strFilePath & "\Survey_Result"
    Public szKnowHow_byModel As String = Nothing '

    Public vCon_Local As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=\\10.169.88.40\Q-Portal\5.Admin(AccessDB)\QPortalDB_Admin.accdb;Jet OLEDB:Database Password = lge1234;"
    'Public vCon_Local As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\신창하\업무\TASK\TEST_DB\admin\QPortalDB_Admin.accdb;Jet OLEDB:Database Password = lge1234;"



    'Public Sub DrawPolygonPoint(ByVal e As PaintEventArgs)

    '    ' Create pen.
    '    Dim blackPen As New Pen(Color.Black, 3)

    '    ' Create points that define polygon.
    '    Dim point1 As New Point(50, 50)
    '    Dim point2 As New Point(100, 25)
    '    Dim point3 As New Point(200, 5)
    '    Dim point4 As New Point(250, 50)
    '    Dim point5 As New Point(300, 100)
    '    Dim point6 As New Point(350, 200)
    '    Dim point7 As New Point(250, 250)
    '    Dim curvePoints As Point() = {point1, point2, point3, point4,
    '        point5, point6, point7}

    '    ' Draw polygon to screen.
    '    e.Graphics.DrawPolygon(blackPen, curvePoints)
    'End Sub

    Private Sub Survey_Result_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '#################################################################################
        '######################## 설문조사내용 평가 '★' 나타내기 ########################
        '#################################################################################
        'SQL Query문 작성
        Dim SQL As String = "SELECT ROUND(AVG(Q"
        Dim tmpsql As String = "SELECT Q"
        For i As Integer = 1 To 24
            If i <> 24 Then
                SQL = SQL & i & ")) as AVG" & i & ", ROUND(AVG(Q"
                tmpsql = tmpsql & i & ", Q"
            Else
                SQL = SQL & i & ")) as AVG" & i
                tmpsql = tmpsql & i
            End If
        Next


        SQL = SQL & " FROM Survey_Result WHERE [ID] > 0 "
        SQL = SQL & Survey_Title & Survey_Comp & Survey_Fm & Survey_Age

        tmpsql = tmpsql & " FROM Survey_Result WHERE [ID] > 0 "
        tmpsql = tmpsql & Survey_Title & Survey_Comp & Survey_Fm & Survey_Age

        'DB 연결
        vConn = New OleDbConnection(vCon_Local)
        Dim SQL_Cmd As New OleDbCommand(SQL, vConn)
        Dim sql_tmp As New OleDbCommand(tmpsql, vConn)

        'DB 적용
        DA = New OleDbDataAdapter(SQL_Cmd)
        DA.Fill(DS, "Survey_Result")

        DA = New OleDbDataAdapter(sql_tmp)
        DA.Fill(DS, "Survey_Result_tmp")
        '결과값이 없을 때 출력되어지는 부분

        Dim Table As DataTable = DS.Tables("Survey_Result")

        If Table.Rows.Count = 1 Then
            For i As Integer = 0 To Table.Columns.Count - 1
                If Table.Rows(0)(i).ToString = "" Then

                    MsgBox("조회 결과가 없습니다.") : Me.Close()
                    Exit Sub
                End If
            Next
        End If

        Dim tmp As String = ""
        For Each Ctrl In Me.Controls

            If Ctrl.GetType() Is GetType(TableLayoutPanel) Then

                For Each a In Ctrl.Controls

                    If a.GetType() Is GetType(Label) And a.Tag IsNot "" Then

                        For i As Integer = 0 To Table.Columns.Count - 1

                            If a.Tag = i + 1 Then

                                For k As Integer = 1 To 5

                                    Dim resultScore As Integer
                                    resultScore = Table.Rows(0)(i).ToString
                                    If k <= resultScore Then
                                        tmp = tmp & "★"
                                    Else
                                        tmp = tmp & "☆"
                                    End If

                                Next

                                a.text = tmp
                                tmp = ""
                            End If
                        Next
                    End If
                Next
            End If
        Next

        '#################################################################################
        '#################################################################################
        '#################################################################################




        '////////// 질문 가져오기 //////////

        Dim SQL_Question = "SELECT 질문"
        For i As Integer = 1 To 30
            If i <> 30 Then
                SQL_Question = SQL_Question & i & ", 질문"
            Else
                SQL_Question = SQL_Question & i
            End If
        Next

        SQL_Question = SQL_Question & " From Survey_Result WHERE [ID] > 0 "
        SQL_Question = SQL_Question & Survey_Title & Survey_Comp & Survey_Fm & Survey_Age

        Dim cmd_Survey As New OleDbCommand(SQL_Question, vConn)

        'DB 적용
        DA = New OleDbDataAdapter(cmd_Survey)
        DA.Fill(DS, "Question")

        Dim Table_Question As DataTable = DS.Tables("Question")


        For Each Ctrl In Me.Controls

            If Ctrl.GetType() Is GetType(TableLayoutPanel) Then

                For Each a In Ctrl.Controls

                    If a.GetType() Is GetType(Label) And a.Tag = "" Then

                        For i As Integer = 0 To Table_Question.Columns.Count - 1

                            If a.name = "Q" & i + 1 Then

                                a.text = " " & Table_Question.Rows(0)(i).ToString

                            End If
                        Next
                    End If
                Next
            End If
        Next



        '############################## 설문조사 총점 부분 ##############################

        Dim Total1, Total2, Total3, Total4 As Integer

        For i As Integer = 0 To Table.Columns.Count - 1

            Select Case i

                Case 0 To 5
                    Total1 = Total1 + Table.Rows(0)(i).ToString
                Case 6 To 11
                    Total2 = Total2 + Table.Rows(0)(i).ToString
                Case 12 To 17
                    Total3 = Total3 + Table.Rows(0)(i).ToString
                Case 18 To 23
                    Total4 = Total4 + Table.Rows(0)(i).ToString

            End Select

        Next

        Dim qCnt1 As Integer = 0
        Dim qCnt2 As Integer = 0
        Dim qCnt3 As Integer = 0
        Dim qCnt4 As Integer = 0

        For Each Ctrl In resultdivPanel1.Controls
            If Ctrl.GetType() Is GetType(Label) And Ctrl.Tag = "" Then

                If Ctrl.Text <> " " Then
                    qCnt1 += 5

                Else

                    For Each a In resultdivPanel1.Controls
                        If a.GetType() Is GetType(Label) And a.tag <> "" Then

                            If a.Tag = Replace(Ctrl.Name, "Q", "") Then
                                a.Text = ""
                            End If
                        End If
                    Next

                End If

            End If
        Next

        For Each Ctrl In resultdivPanel2.Controls
            If Ctrl.GetType() Is GetType(Label) And Ctrl.Tag = "" Then

                If Ctrl.Text <> " " Then
                    qCnt2 += 5

                Else

                    For Each a In resultdivPanel2.Controls
                        If a.GetType() Is GetType(Label) And a.tag <> "" Then

                            If a.Tag = Replace(Ctrl.Name, "Q", "") Then
                                a.Text = ""
                            End If
                        End If
                    Next

                End If
            End If
        Next

        For Each Ctrl In resultdivPanel3.Controls
            If Ctrl.GetType() Is GetType(Label) And Ctrl.Tag = "" Then

                If Ctrl.Text <> " " Then
                    qCnt3 += 5

                Else

                    For Each a In resultdivPanel3.Controls
                        If a.GetType() Is GetType(Label) And a.tag <> "" Then

                            If a.Tag = Replace(Ctrl.Name, "Q", "") Then
                                a.Text = ""
                            End If
                        End If
                    Next

                End If
            End If
        Next

        For Each Ctrl In resultdivPanel4.Controls
            If Ctrl.GetType() Is GetType(Label) And Ctrl.Tag = "" Then

                If Ctrl.Text <> " " Then
                    qCnt4 += 5
                Else

                    For Each a In resultdivPanel4.Controls
                        If a.GetType() Is GetType(Label) And a.tag <> "" Then

                            If a.Tag = Replace(Ctrl.Name, "Q", "") Then
                                a.Text = ""
                            End If
                        End If
                    Next

                End If
            End If
        Next
        sumLb1.Text = Math.Round(Total1 * (25 / qCnt1))
        sumLb2.Text = Math.Round(Total2 * (25 / qCnt2))
        sumLb3.Text = Math.Round(Total3 * (25 / qCnt3))
        sumLb4.Text = Math.Round(Total4 * (25 / qCnt4))
        sumLb5.Text = Total1 + Total2 + Total3 + Total4

        '##################################################################################




    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click




        ' 감정평가결과 열기
        szKnowHow = strFilePath
        Dim szFile As String = "Survey_Result.xlsm"
        Call OpenExcelFile(szKnowHow, szFile)


    End Sub


    Sub OpenExcelFile(ByVal szFilePath As String, ByVal szFile As String)
        Dim strFileName As String = Nothing
        Dim class1 As New Class1


        Try
            ' 찾은 경로로 진입 하여 그 안의 파일명을 찾는다.
            Dim dirA As DirectoryInfo = New DirectoryInfo(szFilePath)    ' 디렉토리 지정
            For Each dra In dirA.GetFiles()     ' For each를 통해 폴더 내의 파일을 찾음
                If InStr(dra.Name, szFile) Then  ' Consumer TC와 Kernel TC / Framework TC의 파일 Naming이 다름
                    szFile = dra.Name
                    Exit For
                End If
            Next

            strFileName = szFilePath & "\" & szFile

            ' 파일이 켜져있는지 확인
            If class1.isFileOpen(strFileName) Then
                'MsgBox("파일이 열려있습니다.")   '파일을 복사하여 파일 저장 위치를 바꿔줌
                File.Copy(szFilePath, Application.StartupPath + szFile, True)
                strFilePath = Application.StartupPath
            End If



            If IO.File.Exists(strFileName) Then
                'If InStr(strFile, ".xlsx") Then       ' 만약 엑셀 파일 이라면
                Dim Proceed As Boolean = False
                Dim xlApp As Excel.Application = Nothing
                Dim xlWorkBooks As Excel.Workbooks = Nothing
                Dim xlWorkBook As Excel.Workbook = Nothing
                Dim xlWorkSheet As Excel.Worksheet = Nothing
                Dim xlWorkSheets As Excel.Sheets = Nothing
                Dim xlCells As Excel.Range = Nothing
                xlApp = New Excel.Application
                xlApp.DisplayAlerts = False
                xlWorkBooks = xlApp.Workbooks
                xlWorkBook = xlWorkBooks.Open(strFileName,, True)   ' Read Only Open
                xlApp.Visible = True
                xlWorkSheets = xlWorkBook.Sheets

                xlWorkBook = Nothing
                xlApp = Nothing

            Else
                MsgBox("열려는 파일이 없습니다." & vbCrLf & szFilePath & "에서 " & szFile & "(이)가 있는지 확인 해보세요.")
                Exit Sub
            End If

        Catch ex As Exception
            MsgBox(ex.Message, "열려는 파일이 없습니다." & vbCrLf & strFileName & "에서 확인 해보세요.")
        End Try
    End Sub

    Private Sub Panel2_GotFocus(sender As Object, e As EventArgs) Handles Panel2.GotFocus

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click


        'Create pen. !!!!!채우기 할 때는 Brush 사용!!!!!
        Dim purplePen As New Pen(Color.FromArgb(170, 150, 180), 3)
        Dim shadowPen As New Pen(Color.FromArgb(230, 220, 235), 2)
        Dim myPen As New Pen(Color.Silver, 1)

        Dim Graphics As Graphics

        '어디에 그림을 표시할 지 영역 지정
        Graphics = Graphics.FromHwnd(hwnd:=Panel2.Handle)

        '총점가져오기
        Dim Performance As Integer = sumLb1.Text
        Dim Field As Integer = sumLb2.Text
        Dim UIfunc As Integer = sumLb3.Text
        Dim Reliability As Integer = sumLb4.Text

        ' 다각형 좌표
        Dim x As Integer = 85
        Dim y As Integer = 85
        Dim point1 As New Point(x + 1, y - (UIfunc * 3.4) + 1)
        Dim point2 As New Point(x + (Performance * 3.4) + 1, y + 1)
        Dim point3 As New Point(x + 1, y + (Field * 3.4) + 1)
        Dim point4 As New Point(x - (Reliability * 3.4) + 1, y + 1)

        Dim shadow1 As New Point(x + 4, y - (UIfunc * 3.4) + 1) 'UI & Function 을 나타내는 좌표
        Dim shadow2 As New Point(x - (Reliability * 3.4) + 4, y + 1) '신뢰성을 나타내는 좌표
        Dim shadow3 As New Point(x + 4, y + (Field * 3.4) + 2) '필드(망 연동) 를 나타내는 좌표
        Dim shadow4 As New Point(x + (Performance * 3.4) + 4, y + 2) '성능을 나타내는 좌표

        'Dim point5 As New Point(300, 100)
        'Dim point6 As New Point(350, 200)
        'Dim point7 As New Point(250, 250)

        '도형그리기 좌표모음
        Dim curvePoints As Point() = {point1, point2, point3, point4}
        Dim curveShadows As Point() = {shadow1, shadow2, shadow3, shadow4}

        '구분 선 좌표모음
        Dim line1 As New Point(x - x + 1, y + 1)
        Dim line1_1 As New Point((x * 2) + 1, y + 1)
        Dim line2 As New Point(x + 1, y - y + 1)
        Dim line2_1 As New Point(x + 1, (y * 2) + 1)
        'Draw polygon to scre1en.

        '구분선 그리기
        Graphics.DrawLine(myPen, line1, line1_1)
        Graphics.DrawLine(myPen, line2, line2_1)

        '그림자 그리기
        Graphics.DrawLine(shadowPen, shadow1, shadow2)
        Graphics.DrawLine(shadowPen, shadow2, shadow3)
        Graphics.DrawLine(shadowPen, shadow3, shadow4)

        '도형 그리기
        Graphics.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
        Graphics.DrawPolygon(purplePen, curvePoints)

    End Sub
End Class
