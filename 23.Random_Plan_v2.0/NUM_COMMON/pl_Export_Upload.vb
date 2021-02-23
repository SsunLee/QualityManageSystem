Imports System.Data
Imports System.Diagnostics
Imports System.Drawing
Imports System.Threading
Imports System.Windows.Forms
Imports Microsoft.Office.Interop
Imports MySql.Data.MySqlClient

Public Class pl_Export_Upload
    Public pl As plan_class = New plan_class
    Public sc As SunClass = New SunClass()
    Public rs_type As String = "td_defect"
    Public rss As String = "td_defect"
    Public trd_list As Collections.Generic.List(Of Thread) = New Collections.Generic.List(Of Thread)
    Private Delegate Sub SearchDel()
    Public thd_list As Collections.Generic.List(Of Threading.Thread) = New Collections.Generic.List(Of Threading.Thread)
    Public trd1 As Thread = New Thread(AddressOf Go_Search)
    Public isDone As Boolean = False
#Region "처음 로드 될 때"
    Private Sub Export_Upload_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Icon = My.Resources.Qportal_Icon
        Label8.Text = ""
        With ListView1
            .View = View.Details
            .CheckBoxes = True : .GridLines = True : .FullRowSelect = True
            .HideSelection = False : .MultiSelect = False
            .Columns.Add("Project") : .Columns.Add("OSU")
            .Columns.Add("Suffix") : .Columns.Add("Model") : .Columns.Add("Step") : .Columns.Add("업체명")
        End With
        ListView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent)
        ListView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize)

        'ListView1.OwnerDraw = True
        'ListView1.View = View.Details

        '# thread 1 - import model info 
        AddHandler btn_Search.Click, AddressOf Search_and_export
        '# thread 2 - import model info 
        AddHandler picExport.Click, AddressOf Search_and_export
    End Sub
#End Region

#Region "검색 버튼 눌렀을 때  -- Go_Search() "
    Private Sub Go_Search()

        'Dim tbl As String = pl.getTableName() & "." & "random_plan" '# MySQL Table명 지정
        Dim tbl As String = rs_type & "." & "randomplandb" '# MySQL Table명 지정
        Dim sql As String
        Dim pjt As String, suff As String, sMod As String, sstep As String, sCom As String

        '# make Query
        pjt = IIf(txtPro.Text = "", "", " AND PROJECT = '" & Replace(txtPro.Text, "'", "''") & "'")
        suff = IIf(txtSuf.Text = "", "", " AND SUFFIX = '" & Replace(txtSuf.Text, "'", "''") & "'")
        sMod = IIf(txtMod.Text = "", "", " AND MODEL = '" & Replace(txtMod.Text, "'", "''") & "'")
        sstep = IIf(txtStep.Text = "", "", " AND STEP = '" & Replace(txtStep.Text, "'", "''") & "'")
        sCom = IIf(txtCompany.Text = "", "", " AND COMPANY = '" & Replace(txtCompany.Text, "'", "''") & "'")
        sql = "SELECT DISTINCT PROJECT, OSU, SUFFIX, MODEL, STEP, COMPANY FROM " & tbl & " WHERE ID > 0 " & pjt & suff & sMod & sstep & sCom

        Dim myCon As MySqlConnection = New MySqlConnection(pl.strSQLCon)    ' connection open
        Dim cmd As MySqlCommand = New MySqlCommand(sql, myCon)
        Dim myAdapt As MySqlDataAdapter = New MySqlDataAdapter()
        Dim ds As DataSet = New DataSet : Dim dt As DataTable = New DataTable

        ds = FillDataOledb(myCon, "Info", sql)
        dt = ds.Tables(0)
        Push_data_in_listview(dt)
        '# ListView에 값 넣기 

        If dt.Rows.Count <= 0 Then '# 없으면
            MessageBox.Show("검색결과가 없습니다. ", "lee.sunbae@lgepartner.com", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

    End Sub

#End Region

#Region "메인 동작"
    Private Sub Search_and_export(ByVal sender As Object, ByVal e As EventArgs)
        If DirectCast(sender, Control).Name = "btn_Search" Then
            ListView1.Items.Clear()
            Dim trd1 As Thread = New Thread(AddressOf Go_Search)
            btn_Search.Enabled = False
            trd1.Start()
            'Label8.Text = "검색 중......"
            btn_Search.Enabled = True

        ElseIf DirectCast(sender, Control).Name = "picExport" Then
            Ready_to_Export()
        End If

    End Sub
#End Region

#Region "엑셀 Export 하기  -- Export_excel()"
    '# 001 - 모델정보를 체크 후 버튼 눌렀을 때 
    Private Delegate Sub Export_excel_del()

    Private Overloads Sub Show(ByRef s As String, ByRef title As String, buttonOption1 As Integer, buttonIcon As Integer)
        Using form = New Form() With {.TopMost = True} ' 최상위로 포커스
            MessageBox.Show(form, s, title, buttonOption1, buttonIcon)
        End Using
    End Sub

    Private Sub Ready_to_Export() '#--- Step 1
        Dim model_list As Collections.Generic.List(Of String) = New Collections.Generic.List(Of String) '# model 정보를 담기 위함.
        Dim strPath As String = "\\10.169.88.40\Q-Portal\1.검증정보\최신Template\랜덤현황"
        Dim strPro As String = Nothing : Dim strMod As String = Nothing : Dim strStep As String = Nothing
        Dim strCompany As String = Nothing : Dim strSuffix As String = Nothing : Dim strOSU As String
        Dim strKey As String = strMod & "_" & strStep
        Dim textBody As String

        Dim chk_box As Boolean = False
        If ListView1.CheckedItems.Count > 1 Then
            Show("선택 오류!!" & vbCrLf & "1개만 선택하세요!", "(sun)", 0, 16)
            Exit Sub
        End If

        Dim findPath As String = "\\10.169.88.40\Q-Portal\1.검증정보\최신Template\랜덤현황\01.Master"
        Dim findFile As String = "최종_작성용.xlsx"
        Dim fs As SunClass = New SunClass(findPath, findFile) : fs.GoFind()
        Dim outFile As String = fs._Name

        If ListView1.InvokeRequired = True Then
            ListView1.Invoke(New Export_excel_del(AddressOf Ready_to_Export))
        Else
            If ListView1.Items.Count = 0 Or ListView1.CheckedItems.Count = 0 Then '# not Check
                chk_box = False : textBody = ""
                Show("아무 것도 조회하지 않고 Export 시도 했기 때문에 새로운 Template를 다운로드 합니다. ", "(lee.sunbae@lgepartner.com)", 0, 64)
                SaveFile(outFile)
                Exit Sub
            Else
                chk_box = True
            End If

            If chk_box = True Then
                Dim lstRow As Integer = ListView1.Items.IndexOf(ListView1.CheckedItems.Item(0))
                With ListView1.Items
                    strPro = .Item(lstRow).SubItems(0).Text : strOSU = .Item(lstRow).SubItems(1).Text
                    strSuffix = .Item(lstRow).SubItems(2).Text : strMod = .Item(lstRow).SubItems(3).Text : strStep = .Item(lstRow).SubItems(4).Text
                    strCompany = .Item(lstRow).SubItems(5).Text
                    model_list.Add(strPro)
                    model_list.Add(strOSU)
                    model_list.Add(strSuffix)
                    model_list.Add(strMod)
                    model_list.Add(strStep)
                    model_list.Add(strCompany)
                End With
            Else
                MessageBox.Show("Check된 항목 없음", "(Sunbae)", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

        End If

        sc._getset_modelInfo = model_list

        '# 여기서 db에서 가져와야 함.
        Dim tbl As String = rss & "." & "randomplandb" '# MySQL Table명 지정
        Dim Qrs As Collections.Generic.List(Of String) = New Collections.Generic.List(Of String)
        Qrs.Add(" PROJECT = '" & Replace(strPro, "'", "''") & "'") : Qrs.Add(" AND SUFFIX = '" & Replace(strSuffix, "'", "''") & "'")
        Qrs.Add(" AND MODEL = '" & Replace(strMod, "'", "''") & "'") : Qrs.Add(" AND STEP = '" & Replace(strStep, "'", "''") & "'")
        Qrs.Add(" AND COMPANY = '" & Replace(strCompany, "'", "''") & "'")

        Dim sql As String = "SELECT `App Name`, Feature, 검증원, 필요MD, 할당MD, '' AS a, 변경점, `변경점 내용`, `Risk Factor`, `변경점 검증방법`, 검증유형, 주요점검사항, 검증유형2, 주요점검사항2, LnL  FROM  " & tbl & " where "
        For Each s As String In Qrs : sql += s : Next

        Debug.Print(sql)
        Dim myCon As MySqlConnection = New MySqlConnection(pl.strSQLCon)    ' connection open
        Debug.Print("strSQLCon : {0}", pl.strSQLCon)
        Dim ds As DataSet = New DataSet : Dim dt As DataTable = New DataTable

        ds = FillDataOledb(myCon, "model_info", sql)
        dt = ds.Tables(0)
        pl._dt_tables = dt  '# pl Class에 table 넣기

        '# Save File Dialog Files.....Open File!!!
        Opendialog_SaveFile()

    End Sub
    Public sw As Boolean = False
    Private Sub Opendialog_SaveFile() '#--- Step 2
        Dim strTemp() As String, strFolder As String
        Dim findPath As String = "\\10.169.88.40\Q-Portal\1.검증정보\최신Template\랜덤현황\01.Master"
        Dim findFile As String = "최종_작성용.xlsx"
        Dim strFull_path As String = findPath & "\" & findFile
        Dim strOutfilename As String, strOutFullPath As String
        sc._Key = findFile
        sc._Path = findPath
        sc.GoFind()
        strOutfilename = sc._getset_gofind_result
        strOutFullPath = sc._FileName

        '# 파일이 열려있을 때 예외 처리
        If sc.File_is_Open(strFull_path) = True Then
            MessageBox.Show("파일이 열려있습니다." & vbCrLf & strFull_path, "(Sunbae)", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Else
            IO.File.Copy(strOutFullPath, Application.StartupPath & "\" & strOutfilename, True)
        End If

        Dim dlg As New SaveFileDialog()
        dlg.FileName = "최종_작성용"
        dlg.DefaultExt = ".xlsx"
        dlg.Filter = ""
        dlg.Filter = "Excel File|*.xlsx"
        dlg.Title = "Save an Excel File"
        Label.CheckForIllegalCrossThreadCalls = False

        If dlg.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            '# 여기서 엑셀을 열고 작업.
            sc._Path = dlg.FileName
            Dim trd2 As Thread = New Thread(AddressOf saveExcelFile)
            trd2.Start()
            sw = False
            Dim trd3 As Thread = New Thread(AddressOf run_label)
            trd3.Start()
            If sw = True Then
                Label8.Text = "완료!!"
            End If
        Else
            Diagnostics.Debug.Print("제대로 닫힘")
        End If

    End Sub
    Private Sub run_label()
        Dim dot As String
        'Label8.Visible = True
        While sw = False
            Dim s As String = "추출 중"
            'dot = "."
            For i As Integer = 0 To 2  ' 
                For j As Integer = 0 To i
                    dot += "."
                Next
                Thread.Sleep(150)
                Label8.Text = s & dot
                Console.WriteLine(s & dot)
            Next

            'Label8.Text = ""
            dot = ""
        End While

        Label8.Text = "완료!"

    End Sub

    Public Sub saveExcelFile() '#-- Step 3 Real Excel
        Dim thisLock As New Object
        SyncLock thisLock
            Dim datestart As Date = Date.Now

            Dim objExcel As Excel.Application
            Dim m As Excel.Workbook
            Dim ms As Excel.Worksheet
            Try
                objExcel = New Excel.Application()
            Catch ex As System.Runtime.InteropServices.COMException
                MessageBox.Show("Excel 파일 읽기가 실패하였습니다." & "일시적인 오류일 수 있습니다. " & vbCrLf & " 다시 시도해주세요.", "(Sunbae)", MessageBoxButtons.OK, MessageBoxIcon.Error)
                sw = True
                Exit Sub
            End Try
            Dim minfo As Collections.Generic.List(Of String) = New Collections.Generic.List(Of String)
            minfo = sc._getset_modelInfo()

            Dim strPro As String = minfo(0)
            Dim strOsu As String = minfo(1)
            Dim strSuffix As String = minfo(2)
            Dim strModel As String = minfo(3)
            Dim strStep As String = minfo(4)
            Dim strCompany As String = minfo(5)

            Dim findFile As String = sc._goFind_result_filename
            Dim strFullPath As String = sc._Path
            Debug.Print("찾은 파일 이름 : {0}", findFile)
            Debug.Print("SaveAs할 경로 : {0}", strFullPath)
            Try
                '# Excel Open
                m = objExcel.Workbooks.Open(Application.StartupPath & "\" & findFile,, 2)
                With objExcel
                    .ScreenUpdating = False    '# Option - Code 실행 되는 것 Animation 끄기.
                    .Calculation = Microsoft.Office.Interop.Excel.XlCalculation.xlCalculationManual '# Option - 수식 계산하는 Option OFF
                    '.Visible = True '# Excel 보여주기.
                End With
                Debug.Print("Open경로 : {0}", Application.StartupPath & "\" & findFile)

                ms = m.Sheets("작성") ' Sheet Object로 할당

                Dim dt_table As DataTable = New DataTable : dt_table = pl.dt_table

                Dim v As Object : ReDim v(0 To dt_table.Rows.Count, 0 To dt_table.Columns.Count)

                For i As Integer = 0 To UBound(v, 1) - 1 : For j As Integer = 0 To UBound(v, 2) - 1 : v(i, j) = dt_table.Rows(i)(j).ToString() : Next : Next
                ms.Range("b12").Resize(UBound(v, 1), UBound(v, 2)).Value = v

                ms.Cells(5, "b") = strPro : ms.Cells(5, "c") = strOsu : ms.Cells(5, "e") = strSuffix : ms.Cells(5, "f") = strModel : ms.Cells(5, "g") = strStep

                '# 테두리 설정
                ms.Range("B12:p" & ms.Cells(ms.Rows.Count, 2).end(3).row).Borders.LineStyle = 1

                Dim n As Integer
                n = ms.Cells(ms.Rows.Count, "B").End(3).row
                ms.Cells(10, "E") = "=SUM(E12:E" & n & ")"         ' 필요 M/D 계산
                ms.Cells(10, "F") = "=SUM(F12:F" & n & ")"         ' 할당 M/D 계산

                With objExcel
                    .ScreenUpdating = True    '# Option - Code 실행 되는 것 Animation 끄기.
                    .Calculation = Microsoft.Office.Interop.Excel.XlCalculation.xlCalculationAutomatic '# Option - 수식 계산하는 Option OFF
                End With

                Debug.Print("SaveAs 경로 : {0}", strFullPath)
                m.SaveAs(strFullPath)
                m.Close()
                objExcel.Application.Quit()
                objExcel.Quit()

                ms = Nothing : m = Nothing : objExcel = Nothing

            Catch ex As Exception
                Diagnostics.Debug.Print(ex.Message)
                Dim dateEnd As Date = Date.Now
                End_Excel_App(datestart, dateEnd)
            Finally
                Dim dateEnd As Date = Date.Now
                End_Excel_App(datestart, dateEnd) ' This closes excel proces
                Dim strTemp() As String, strFolder As String

                strTemp = Split(strFullPath, "\")
                Array.Resize(strTemp, strTemp.Length - 1)
                strFolder = String.Join("\", strTemp)

                Diagnostics.Process.Start(strFolder)        ' 폴더 열기 
                'MessageBox.Show("추출 완료")
                sw = True

                Label8.Text = "완료!"
            End Try
        End SyncLock

    End Sub

    Private Sub End_Excel_App(datestart As Date, dateEnd As Date)
        Try
            Dim comDate As Date
            Dim xlp() As Process = Process.GetProcessesByName("EXCEL")
            For Each Process As Process In xlp
                comDate = Process.StartTime
                If comDate >= datestart And comDate <= dateEnd Then
                    Process.Kill()
                    Exit For
                End If
            Next
        Catch ex As Exception
            Debug.Print(ex.Message & vbCrLf & "process cant'kill ")
        End Try
    End Sub

#End Region

#Region "ListView에 Additem 하는 거 #-- Push_data_in_listview()"
    Private trd As Threading.Thread
    Private Delegate Sub pushDel(ByRef dt As DataTable)
    Private Sub Push_data_in_listview(ByRef dt As DataTable)
        Dim itemcoll(100) As String
        '# 검색 결과가 있으면
        Try
            If ListView1.InvokeRequired = True Then
                ListView1.Invoke(New pushDel(AddressOf Push_data_in_listview), New Object() {dt})
            Else
                ListView1.Items.Clear()
                For i = 0 To dt.Rows.Count - 1
                    For j = 0 To dt.Columns.Count - 1 : itemcoll(j) = dt.Rows(i)(j).ToString() : Next
                    Dim lvi As New ListViewItem(itemcoll) : ListView1.Items.Add(lvi)
                Next i
                ListView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent)
            End If
            isDone = True

        Catch ex As Exception
        Finally
            'trd.Abort() '# Thread Stop
            btn_Search.Enabled = True
        End Try
    End Sub
    Private Sub btn_Stop_Click(sender As Object, e As EventArgs) Handles btn_Stop.Click
        btn_Search.Enabled = True
        Try
            'thd_list(0).Abort()
            trd.Abort()
        Catch ex As Exception
        End Try
    End Sub
#End Region

#Region "DB to Datatable - FUNCTION"
    '# DB접속 해서 Data Table에 담는 거
    Private Function FillDataOledb(ByRef vConn As MySql.Data.MySqlClient.MySqlConnection, ByRef sht As String, ByRef sql As String) As DataSet
        Dim cmd As MySql.Data.MySqlClient.MySqlCommand
        Dim DA As MySql.Data.MySqlClient.MySqlDataAdapter = New MySql.Data.MySqlClient.MySqlDataAdapter()
        Dim DS As DataSet = New DataSet
        Try
            cmd = New MySqlCommand(sql, vConn)
            DA = New MySqlDataAdapter(cmd)
            DA.Fill(DS, sht)
        Catch ex As Exception
            MessageBox.Show(ex.Message & Environment.NewLine & "ds.fill() Error", "(Sunbae)", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Diagnostics.Debug.Print(sql)
        End Try

        Return DS

    End Function


#End Region

#Region "엔터 키 쳤을 때도 동작하도록"
    Private Sub when_Enter(sender As Object, e As KeyPressEventArgs) Handles txtCompany.KeyPress, txtMod.KeyPress, txtPro.KeyPress, txtStep.KeyPress, txtSuf.KeyPress
        If e.KeyChar = Convert.ToChar(13) Then  ' ToChar <-- 13번 값은 Enter 임.
            ListView1.Items.Clear()
            Dim trd1 As Thread = New Thread(AddressOf Go_Search)
            btn_Search.Enabled = False
            trd1.Start()
            'Label8.Text = "검색 중......"
            btn_Search.Enabled = True
        End If
    End Sub
#End Region

#Region "단순 save as"
    Private Sub SaveFile(ByRef path As String)

        '# File saveFileDialog()
        Dim dlg As New SaveFileDialog()
        dlg.FileName = "최종_작성용"
        dlg.DefaultExt = ".xlsx"
        dlg.Filter = ""
        dlg.Filter = "Excel File|*.xlsx"
        dlg.Title = "Save an Excel File"

        If dlg.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            Dim openFileName As String = Nothing    '# if select Files
            Dim strTemp() As String, strFolder As String
            strTemp = Split(dlg.FileName, "\")
            Array.Resize(strTemp, strTemp.Length - 1)
            strFolder = String.Join("\", strTemp)

            Diagnostics.Process.Start(strFolder)        ' 폴더 열기 

            Dim bytesRead As Integer
            Dim buffer(4096) As Byte

            Try
                Using inFile As New System.IO.FileStream(path, IO.FileMode.Open, IO.FileAccess.Read)
                    Using outFile As New System.IO.FileStream(dlg.FileName, IO.FileMode.Create, IO.FileAccess.Write)
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

        End If

    End Sub
#End Region

#Region "업로드하는 Form 연결"
    Private Sub btnUp_Click(sender As Object, e As EventArgs) Handles PicUpload.Click
        Dim plrisk As New pl_risk_upload
        plrisk.Show()
    End Sub




#End Region

    'Private Sub ListView1_DrawColumnHeader(ByVal sender As Object, ByVal e As DrawListViewColumnHeaderEventArgs) Handles ListView1.DrawColumnHeader
    '    e.DrawBackground()
    '    Dim txtpos As Point = New Point(e.Bounds.X + 3, e.Bounds.Y + 2)
    '    If e.Header.Index = 0 Then
    '        e.Graphics.DrawString(e.Header.Text, e.Font, Brushes.Red, txtpos)
    '    ElseIf e.Header.Index = 1 Then
    '        e.Graphics.DrawString(e.Header.Text, e.Font, Brushes.Blue, txtpos)
    '    End If
    'End Sub

    'Private Sub ListView1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListView1.SelectedIndexChanged
    '    ListView1.OwnerDraw = True
    '    ListView1.View = View.Details
    '    'ListView1.HeaderStyle = ColumnHeaderStyle.Nonclickable
    'End Sub

    'Private Sub ListView1_DrawItem(ByVal sender As Object, ByVal e As System.Windows.Forms.DrawListViewItemEventArgs) Handles ListView1.DrawItem
    '    e.DrawDefault = True
    'End Sub

    'Private Sub lv1_DrawSubItem(ByVal sender As Object, ByVal e As DrawListViewSubItemEventArgs) Handles ListView1.DrawSubItem
    '    e.DrawDefault = True
    'End Sub

End Class

