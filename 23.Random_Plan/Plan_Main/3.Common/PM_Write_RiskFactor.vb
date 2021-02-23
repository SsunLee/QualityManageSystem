Imports System.Data
Imports System.Data.OleDb
Imports System.Diagnostics
Imports System.Windows.Forms
Imports Microsoft.Office.Interop

Public Class PM_Write_RiskFactor
    Public Change_Add_Tree As New Change_Add_Tree
    Public DS_FOR_RESULT As DataSet = New DataSet
    Public DS_FOR_EXCEL As DataSet = New DataSet
    Public vConn As OleDbConnection = New OleDbConnection

#Region "처음 로드 될 때"
    Private Sub PM_Write_RiskFactor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        With ListView1
            .View = View.Details
            .CheckBoxes = True
            .GridLines = True
            .FullRowSelect = True
            .HideSelection = False
            .MultiSelect = False

            .Columns.Add("Project")
            .Columns.Add("Model")
            .Columns.Add("차수")
            .Columns.Add("사업자")
            .Columns.Add("업체명")

        End With

        ListView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent)
        ListView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize)

    End Sub
#End Region

#Region "검색 버튼 눌렀을 때"
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        DS_FOR_RESULT.Clear()   '# 계속 담고 있을 DS
        ListView1.Items.Clear()

        'Dim sDate As DateTime = DateTimePicker1.Value.ToString("yyyy/MM/dd")
        ' Dim eDate As DateTime = DateTimePicker2.Value.ToString("yyyy/MM/dd")

        Dim DateSQL As String = Nothing

        'DateSQL = "And 날짜 between #" & sDate & "# and #" & eDate & "#"
        'DateSQL = "And 날짜 between #" & sDate & "# and #" & eDate & "#"
        'DateSQL = ""

        ' 빈 항목이면 조건에 들어가지 않도록
        Dim vSQLPro As String = Nothing : vSQLPro = IIf(txtPro.Text = "", "", "AND [Project] LIKE '%" & Replace(txtPro.Text, "'", "''") & "%'")
        Dim vSQLMod As String = Nothing : vSQLMod = IIf(txtMod.Text = "", "", "AND [Model] = '" & Replace(txtMod.Text, "'", "''") & "'")
        Dim vSQLStep As String = Nothing : vSQLStep = IIf(txtStep.Text = "", "", "AND [차수] = '" & Replace(txtStep.Text, "'", "''") & "'")
        Dim vSQLCompany As String = Nothing : vSQLCompany = IIf(txtCompany.Text = "", "", "AND [업체명] LIKE '%" & Replace(txtCompany.Text, "'", "''") & "%'")

        Dim sql As String = Nothing
        Dim sht As String = "검계_DB"

        Diagnostics.Debug.Print(vSQLPro & Environment.NewLine & vSQLMod)
        Diagnostics.Debug.Print(vSQLPro & Environment.NewLine & vSQLMod)

        ' SQL QUERY 작성   // 검색한 결과에 맞게 내용 가져와서 Type 에다가 자료 넣어줌
        sql = "SELECT Project, Model, 차수, 사업자, 업체명 "
        sql = sql & "FROM [" & sht & "] "
        sql = sql & "WHERE ID > 0 And Project is not null " & vSQLPro & vSQLMod & vSQLStep & vSQLCompany & DateSQL
        sql = sql & " order by Project asc , Model ASC, 차수 asc"

        Dim vConn As OleDbConnection = New OleDbConnection(Change_Add_Tree.strCon)   '// OledbConnection 사용하기 위해 선언 (Connection String 기준으로
        Dim DS As DataSet = New DataSet
        Dim dt As DataTable = New DataTable

        dt = FillDataOledb(vConn, sht, sql)
        dt = dt.DefaultView.ToTable(True, "Project", "Model", "차수", "사업자", "업체명")

        Dim itemcoll(100) As String
        If dt.Rows.Count <= 0 Then
            '# 없으면
            MessageBox.Show("검색결과가 없습니다. ", "lee.sunbae@lgepartner.com", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Else
            '# 검색 결과가 있으면
            For i = 0 To dt.Rows.Count - 1
                For j = 0 To dt.Columns.Count - 1
                    itemcoll(j) = dt.Rows(i)(j).ToString()
                Next

                Dim lvi As New ListViewItem(itemcoll)
                ListView1.Items.Add(lvi)
            Next

            ListView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent)
        End If




    End Sub
#End Region


    '# DB접속 해서 Data Table에 담는 거
    Private Function FillDataOledb(ByRef vConn As OleDb.OleDbConnection, ByRef sht As String, ByRef sql As String) As DataTable

        Dim DA As OleDbDataAdapter = New OleDbDataAdapter(sql, vConn)
        Dim DS As DataSet = New DataSet
        Dim DT As DataTable = New DataTable

        DA.Fill(DS, sht)
        Diagnostics.Debug.Print(sql)

        DT = DS.Tables(0)

        DA.Fill(DS_FOR_RESULT, sht)

        FillDataOledb = DT

        Return FillDataOledb

    End Function

    '# Excel Export
    Private Sub btnExcel_Click(sender As Object, e As EventArgs) Handles btnExcel.Click

        Dim strPro As String = Nothing
        Dim strMod As String = Nothing
        Dim strStep As String = Nothing
        Dim strCompany As String = Nothing
        Dim strBuyer As String = Nothing
        If ListView1.CheckedItems.Count > 0 Then
            '# Check 1

            Dim lstRow As Integer = ListView1.Items.IndexOf(ListView1.CheckedItems.Item(0))

            strPro = ListView1.Items.Item(lstRow).SubItems(0).Text  '# Project
            strMod = ListView1.Items.Item(lstRow).SubItems(1).Text '# model
            strStep = ListView1.Items.Item(lstRow).SubItems(2).Text '# Step
            strBuyer = ListView1.Items.Item(lstRow).SubItems(3).Text    '# Buyer
            strCompany = ListView1.Items.Item(lstRow).SubItems(4).Text  '# Company

            Dim vSQLPro As String = Nothing : vSQLPro = IIf(strPro = "", "", "AND [Project] = '" & Replace(strPro, "'", "''") & "'")
            Dim vSQLMod As String = Nothing : vSQLMod = IIf(strMod = "", "", "AND [Model] = '" & Replace(strMod, "'", "''") & "'")
            Dim vSQLStep As String = Nothing : vSQLStep = IIf(strStep = "", "", "AND [차수] = '" & Replace(strStep, "'", "''") & "'")
            Dim vSQLCompany As String = Nothing : vSQLCompany = IIf(strCompany = "", "", "AND [업체명] = '" & Replace(strCompany, "'", "''") & "'")

            '# 엑셀용으로 DS하나 생성
            ' SQL QUERY 작성   // 검색한 결과에 맞게 내용 가져와서 Type 에다가 자료 넣어줌
            Dim sql As String
            Dim sht As String = "검계_DB"
            sql = "SELECT [App Name], Feature, 검증원 as 담당자, 필요MD, [할당 M/D], 변경점, [변경점 내용], [Risk Factor],[변경점 검증방법], 검증유형, 주요점검사항, 검증유형2, 주요점검사항2, LessonLearn "
            sql = sql & "FROM [" & sht & "] "
            sql = sql & "WHERE ID > 0 And Project is not null " & vSQLPro & vSQLMod & vSQLStep & vSQLCompany
            sql = sql & " order by Project asc , Model ASC, 차수 asc"

            Dim vConn As OleDbConnection = New OleDbConnection(Change_Add_Tree.strCon)   '// OledbConnection 사용하기 위해 선언 (Connection String 기준으로
            Dim DS As DataSet = New DataSet
            Dim DA As OleDbDataAdapter = New OleDbDataAdapter(sql, vConn)

            DS_FOR_EXCEL.Clear()
            DA.Fill(DS_FOR_EXCEL, sht)

            btn_Excel_Click(sender, e)

        End If



    End Sub

#Region "[엑셀 파일을 생성 후 조회 값넣고 VBA 하기]"
    Private Sub btn_Excel_Click(sender As Object, e As EventArgs)
        Dim blChk As Boolean = False
        '# Resource에 있는 Excel File 실행 > 입력 칸에 값 넣고 > 코드 실행 > 다른 이름으로 저장 하기 팝업

        '# 지정경로 안에서 '시험기획서_Access_v1.3' 찾기 후 파일 Copy
        Dim dir As System.IO.DirectoryInfo = New System.IO.DirectoryInfo("\\10.169.88.40\Q-Portal\2.검증현황\시험기획")
        Dim strFile As String = Nothing : Dim strRealFile As String = Nothing
        Dim strFullPath As String = Nothing
        For Each dr In dir.GetFiles()
            strFile = dr.Name   '# file name
            If strFile = "최종_작성용.xlsx" And Strings.Left(strFile, 2) <> "~$" Then
                strRealFile = dr.Name
                strFullPath = dr.FullName
                blChk = True
                Exit For
            End If
        Next

        'Using stream As New FileStream(strFullPath, , FileAccess.Read)
        ' End Using
        Dim bytesRead As Integer
        Dim buffer(4096) As Byte

        Try
            Using inFile As New System.IO.FileStream(strFullPath, IO.FileMode.Open, IO.FileAccess.Read)
                Using outFile As New System.IO.FileStream(Application.StartupPath + strRealFile, IO.FileMode.Create, IO.FileAccess.Write)
                    Do
                        bytesRead = inFile.Read(buffer, 0, buffer.Length)
                        If bytesRead > 0 Then
                            outFile.Write(buffer, 0, bytesRead)
                        End If
                    Loop While bytesRead > 0
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message, "(Sunbae) - 서버 파일이 이미 열려있습니다.", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try



        'File.Copy(strFullPath, Application.StartupPath + strRealFile, True)   '# 파일 붙여 넣기

        '# File saveFileDialog()
        Dim dlg As New SaveFileDialog()
        dlg.FileName = "최종_작성용"
        dlg.DefaultExt = ".xlsx"
        dlg.Filter = ""
        dlg.Filter = "Excel File|*.xlsx"
        dlg.Title = "Save an Excel File"

        '# Dialog 화면
        'Dim result As Boolean = dlg.ShowDialog()

        If dlg.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            Dim openFileName As String = Nothing    '# if select Files

            'Save the files
            Try
                saveExcelFile(Application.StartupPath + strRealFile, dlg.FileName)

                Dim strFolder As String = Nothing
                Dim strTemp() As String

                strTemp = Split(dlg.FileName, "\")
                Array.Resize(strTemp, strTemp.Length - 1)
                strFolder = String.Join("\", strTemp)

                Diagnostics.Process.Start(strFolder)        ' 폴더 열기 
                MessageBox.Show("추출 완료")

            Catch ex As Exception
                MessageBox.Show(ex.Message)

            End Try
        Else
            Diagnostics.Debug.Print("그냥 껐다.")
        End If



    End Sub

    Public Sub saveExcelFile(ByVal strFileName As String, ByVal FileName As String)
        Dim datestart As Date = Date.Now
        Dim excel As Excel.Application = New Excel.Application
        Dim m As Excel.Workbook
        Dim ms As Excel.Worksheet

        Dim lstRow As Integer = ListView1.Items.IndexOf(ListView1.CheckedItems.Item(0))

        Dim strPro = ListView1.Items.Item(lstRow).SubItems(0).Text
        Dim strMod = ListView1.Items.Item(lstRow).SubItems(1).Text
        Dim strStep = ListView1.Items.Item(lstRow).SubItems(2).Text
        Dim strBuyer = ListView1.Items.Item(lstRow).SubItems(3).Text
        Dim strCompany = ListView1.Items.Item(lstRow).SubItems(4).Text

        Try
            '# Excel Open
            m = excel.Workbooks.Open(strFileName,, 2)

            '# 재 확인 필요 
            With excel
                .ScreenUpdating = False    '# Option - Code 실행 되는 것 Animation 끄기.
                .Calculation = Microsoft.Office.Interop.Excel.XlCalculation.xlCalculationManual '# Option - 수식 계산하는 Option OFF
                .Visible = True '# Excel 보여주기.
            End With

            ms = m.Sheets(1)    '# Sheet Object로 할당

            Dim dt_table As DataTable = New DataTable
            dt_table = DS_FOR_EXCEL.Tables(0)

            Dim r As Integer = 12
            Dim c As Integer = 2

            For i As Integer = 0 To dt_table.Rows.Count - 1
                For j As Integer = 0 To dt_table.Columns.Count - 1
                    ms.Cells(r, c) = dt_table.Rows(i)(j).ToString()
                    c = c + 1
                Next
                r = r + 1   ' init 
                c = 2
            Next

            ms.Cells(5, "b") = strPro
            ms.Cells(5, "c") = strMod
            ms.Cells(5, "d") = strStep
            ms.Cells(5, "e") = strBuyer
            ms.Cells(5, "f") = strCompany

            '# 테두리 설정
            ms.Range("B12:O" & ms.Cells(ms.Rows.Count, 2).end(3).row).Borders.LineStyle = 1

            Dim n As Integer
            n = ms.Cells(ms.Rows.Count, "B").End(3).row
            ms.Cells(10, "E") = "=SUM(E12:E" & n & ")"         ' 필요 M/D 계산
            ms.Cells(10, "F") = "=SUM(F12:F" & n & ")"         ' 할당 M/D 계산

            With excel
                .ScreenUpdating = True    '# Option - Code 실행 되는 것 Animation 끄기.
                .Calculation = Microsoft.Office.Interop.Excel.XlCalculation.xlCalculationAutomatic '# Option - 수식 계산하는 Option OFF
            End With

            m.SaveAs(FileName)

            m.Close()
            excel.Quit()

            Dim dateEnd As Date = Date.Now
            End_Excel_App(datestart, dateEnd) ' This closes excel proces

        Catch ex As Exception
            Diagnostics.Debug.Print(ex.Message)

        Finally


        End Try

    End Sub

    Private Sub End_Excel_App(datestart As Date, dateEnd As Date)
        Dim xlp() As Process = Process.GetProcessesByName("EXCEL")
        For Each Process As Process In xlp
            If Process.StartTime >= datestart And Process.StartTime <= dateEnd Then
                Process.Kill()
                Exit For
            End If
        Next
    End Sub

#End Region
    Private Sub btnUp_Click(sender As Object, e As EventArgs) Handles btnUp.Click
        Dim PM_Upload_RiskFactor As New PM_Upload_RiskFactor
        PM_Upload_RiskFactor.Show()

    End Sub


End Class