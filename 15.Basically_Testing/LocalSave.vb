Imports System.Data
Imports System.Data.OleDb
Imports System.Drawing
Imports System.Windows.Forms
Imports Microsoft.Office.Interop
Imports System.Collections
Imports System.Linq
Imports System.IO
Imports System.Diagnostics

Public Class LocalSave
    Public dt As DataTable = Nothing
    Public strColumns = {"Type", "App", "Feature", "Function_Description", "Test Action", "TestType_Description", "Import", "Validation method", "Around", "Defect History", "Priroty", "Result", "Comment"}
    Private Sub LocalSave_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '처음 로드 시 App List에 App을 뿌려주는 작업
        For i As Integer = 0 To dt.Rows.Count - 1    ' Data table Row 만큼 반복 -1은 마지막행은 Null
            Try
                If Not lstApp.Items.Contains(dt.Rows(i)(1).ToString()) Then  ' 중복 없이 Item 추가
                    lstApp.Items.Add(dt.Rows(i)(1).ToString())
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Next
    End Sub

    Private Sub lstApp_DoubleClick(sender As Object, e As EventArgs) Handles lstApp.DoubleClick, Button1.Click

        '아무것도 선택 되지 않았을 때 동작 
        If lstApp.Text = "" Then
            Exit Sub
        End If
        ' 중복없이 List에 Item추가 
        Try
            If Not addApp.Items.Contains(lstApp.Text) Then  ' 중복 없이 Item 추가
                addApp.Items.Add(lstApp.Text)

                lstApp.Items.RemoveAt(lstApp.SelectedIndex)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub addApp_DoubleClick(sender As Object, e As EventArgs) Handles addApp.DoubleClick, Button2.Click
        '아무 것도 선택 되지 않았을 때 동작
        If addApp.Text = "" Then
            Exit Sub
        End If
        ' 중복없이 List에 Item추가 
        Try
            If Not lstApp.Items.Contains(addApp.Text) Then  ' 중복 없이 Item 추가
                lstApp.Items.Add(addApp.Text)
                addApp.Items.RemoveAt(addApp.SelectedIndex)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Button3.Text = "Please Wait..."
        Button3.Enabled = False
        Application.DoEvents()
        Dim SaveFile As New SaveFileDialog
        SaveFile.Filter = "Excel 통합 문서 files (*.xlsx)|*.xlsx|All files (*.*)|*.*"
        'SaveFile.ShowDialog()
        If SaveFile.ShowDialog = DialogResult.OK Then
            ''Save your stuff
            MsgBox("저장하는데 오래 걸릴 수 있습니다.")

            Dim itemSelect As String = Nothing
            Dim chk As Boolean = True
            Dim fullPath = SaveFile.FileName

            '선택한 앱들을 Dataview에서 조건으로 쓸수 있게 String 변수에 넣어줌
            For Each x In addApp.Items
                Application.DoEvents()
                If chk Then
                    itemSelect = "app = '" + x.ToString
                    chk = False
                Else
                    itemSelect = itemSelect + "' or app = '"
                    itemSelect = itemSelect + x.ToString
                End If
            Next
            itemSelect = itemSelect + "' "

            ' Dataview에 원하는 조건(itemSelect) 에 맞는 데이터를 정렬 후 저장
            Dim dv As DataView
            Dim dt2 As DataTable
            dv = New DataView(dt, itemSelect, "App Asc", DataViewRowState.CurrentRows)
            ' DataTable에 Dataview의 테이블을 넣어준다
            dt2 = dv.ToTable


            DataGridView1.DataSource = dt2


            'Excel 파일 생성 해줌
            Dim Proceed As Boolean = False
            Dim xlApp As Excel.Application = Nothing
            Dim xlWorkBooks As Excel.Workbooks = Nothing
            Dim xlWorkBook As Excel.Workbook = Nothing
            Dim xlWorkSheet As Excel.Worksheet = Nothing
            Dim xlWorkSheet2 As Excel.Worksheet = Nothing
            Dim xlWorkSheets As Excel.Sheets = Nothing
            Dim xlCells As Excel.Range = Nothing
            Dim xlCells2 As Excel.Range = Nothing


            xlApp = New Excel.Application
            'xlApp.DisplayAlerts = False
            xlWorkBooks = xlApp.Workbooks

            xlWorkBook = xlWorkBooks.Add()
            ' xlApp.Visible = True      'Excel 파일 보여줌
            xlWorkSheets = xlWorkBook.Sheets
            xlWorkSheet = xlWorkSheets.Add
            xlWorkSheet.Name = "기본검증"

            Dim ms As Excel.Worksheets = Nothing

            'ms = xlWorkBooks(xlWorkBook.Name).Worksheets("기본검증")
            'ms.activate ''

            '  ms = xlWorkBooks(xlWorkBook.Name).Sheets("기본검증")

            'A1셀에 들어갈 내용
            xlWorkSheet.Cells(1, 1) = "LGE Internal Use Only"
            xlWorkSheet.Range("A1").Font.Color = Color.Red
            xlWorkSheet.Cells(1, 1).Font.Bold = True

            '중간 내용 들어갈 부분
            Dim strColumns = {"Type", "App", "Feature", "Function_Description", "Test Action", "TestAction_Description", "Import", "Validation method", "Around", "Defect History", "Priroty", "Result", "Comment"}
            Dim colSize = {10, 20, 20, 30, 20, 25, 6.5, 30, 30, 20, 8, 6, 13}
            Dim strResult = {"Total", "OK", "NG", "NT", "Progress"}
            Dim strResult2 = {"TC 사업자 불일치", "TC 오류", "Test 환경 미지원", "기능 미구현", "기타"}
            Dim i As Integer = 8
            Dim j As Integer = 0

            '결과값표 추가 해주는 부분
            For a As Integer = 2 To 6
                xlWorkSheet.Cells(a, "K") = strResult(a - 2)
            Next a
            For a As Integer = 2 To 6
                xlWorkSheet.Cells(a, "M") = strResult2(a - 2)
            Next a


            '테두리와 글자크기 조정
            xlCells = xlWorkSheet.Range("K2:N6")
            xlCells.Borders.LineStyle = "1"
            xlCells.Font.Size = "9"



            '결과표에 색입히기
            xlCells = xlWorkSheet.Range("K2:K6")
            xlCells.Interior.Color = Color.LightGray

            xlCells = xlWorkSheet.Range("M2:M6")
            xlCells.Interior.Color = Color.LightGray

            '저장
            xlWorkBook.SaveAs(fullPath)

            'column명 넣어주기


            xlWorkSheet2 = xlWorkSheets(2)
            'xlWorkSheet2.Name = "Sheet1"
            ' xlCells = xlWorkSheet.Range("A8:M8")
            Dim f As Integer = 0

            '컬럼명을 뿌려주는 작업
            For r As Integer = LBound(strColumns) To UBound(strColumns)
                Application.DoEvents()
                xlWorkSheet.Cells(8, r + 1) = strColumns(r)
                xlWorkSheet2.Cells(1, r + 1) = strColumns(r)
            Next r

            '컬럼 사이즈 조정 
            xlCells.ColumnWidth = colSize

            xlWorkBook.Save()
            'While j < strColumns.Length
            '    '    'xlWorkSheet.Cells(i, j + 1) = strColumns(j)
            'xlCells.Cells(i, j + 1) = strColumns(j)
            '    '    '   xlCells.ColumnWidth = colSize(j)
            '    j += 1
            'End While

            ' DataTable Row수 만큼 loop
            i = 0

            For Each x In dt2.Rows
                Application.DoEvents()
                j = 0
                ' DataTable column수 만큼 loop
                For Each dc In dt2.Columns
                    Application.DoEvents()
                    xlWorkSheet.Cells(i + 9, j + 1) = dt2.Rows.Item(i)(j).ToString
                    j += 1
                Next
                i += 1
            Next

            '  xlWorkSheet2.InsertDataTable(dt, True, 1, 1)

            'Dim _excel As New Excel.Application
            'Dim wBook As Excel.Workbook
            'Dim wSheet As Excel.Worksheet

            'wBook = _excel.Workbooks.Add()
            'wSheet = wBook.ActiveSheet()

            '''''''''''''''''''''''''''''''''''''
            'Dim dc As System.Data.DataColumn
            'Dim colIndex As Integer = 0
            'Dim rowIndex As Integer = 0
            ''Nombre de mesures
            'Dim Nbligne As Integer = dt.Rows.Count

            ''Ecriture des entêtes de colonne et des mesures
            ''(Write column headers and data)

            'For Each dc In dt.Columns
            '    Application.DoEvents()
            '    colIndex = colIndex + 1
            '    'Entête de colonnes (column headers)
            '    xlWorkSheet.Cells(8, colIndex) = dc.ColumnName
            '    'Données(data)
            '    'You can use CDbl instead of Cobj If your data is of type Double
            '    xlWorkSheet.Cells(9, colIndex).Resize(Nbligne, ).Value = xlApp.Application.transpose(dt.Rows.OfType(Of DataRow)().[Select](Function(k) CObj(k(dc.ColumnName))).ToArray())
            'Next
            ''''''''''''''''''''''''''''''''''''
            'Dim oxlA As Object

            'Dim owB As Object

            'oxlA = CType(CreateObject("Excel.Application"), Microsoft.Office.Interop.Excel.Application)

            'owB = oxlA.Workbooks.Add

            'Dim oSheet As Object = CType(owB.Worksheets(1), Microsoft.Office.Interop.Excel.Workbook)

            ''   With this the following did work And was quick
            'Dim sn

            'For i = 0 To dt.Rows.Count - 1

            '    For x = 0 To dt.Columns.Count - 1

            '        sn(i, x) = dt.Rows(i).Item(x).ToString

            '    Next

            'Next

            'xlWorkSheet.Range("A9", "M" & dt.Rows.Count() + 9).Value = sn




            xlWorkBook.Save()

            ' InsertData(fullPath)


            'xlCells2 = xlWorkSheet2.Range("A2:M" & dt.Rows.Count + 3)
            'Dim var()
            'var = xlCells2

            '  Dim xrange As Excel.Range
            xlCells2 = xlWorkSheet.Range("A9:M" & dt2.Rows.Count + 3)
            'Dim personArray As Array = xlCells2
            'Dim rng As Excel.Range = ws.Range("A1:A10")
            Dim MyArray As Object(,) = CType(xlCells2.Value, Object(,))
            ' Dim MyArray2 As Object(,) = CType(dt.DataSet, Object(,))
            'var = dv.ToTable

            'Dim rows As ArrayList = New ArrayList

            'For Each x In dt.Rows
            '    rows.Add(String.Join(";", DataRow.ItemArray.Select(item >= item.ToString())))
            'Next



            'For i = 1 To dt.Rows.Count
            '    xlWorkSheet.Cells(8 + i, 1) = var(i)(0)
            '    xlWorkSheet.Cells(8 + i, 2) = var(i)(1)
            '    xlWorkSheet.Cells(8 + i, 3) = var(i)(2)
            '    xlWorkSheet.Cells(8 + i, 4) = var(i)(3)
            '    xlWorkSheet.Cells(8 + i, 5) = var(i)(4)


            'Next i


            'xlCells = xlWorkSheet.Range("A9:M" & dt.Rows.Count + 3)
            'xlCells2.Copy(xlCells)
            '  xlWorkSheet.Paste()


            'Range설정 후 테두리, 글자 크기 조정, 텍스트 줄바꿈 
            xlCells = xlWorkSheet.Range("A8:M" & dt2.Rows.Count + 3)
            xlCells.Borders.LineStyle = "1"
            xlCells.Font.Size = "9"
            xlCells.WrapText = True

            xlCells = xlWorkSheet.Range("A8:M8")
            xlWorkSheet.Cells(1, 1).Font.Bold = True
            xlCells.Font.Size = "10"
            xlCells.Font.Bold = True



            xlWorkBook.Save()

            xlWorkBook.Close(True)
            xlApp.Quit()

            xlWorkBook = Nothing
            xlApp = Nothing
            Button3.Text = "추출하기!"
            Button3.Enabled = True
            MsgBox("끝_저장완료")
        End If
    End Sub


    Dim FlNm As String

    'Private Sub ExportToExcel(ByVal DGV As DataGridView)
    '    Dim fs As New StreamWriter(FlNm, False)
    '    With fs
    '        .WriteLine("<?xml version=""1.0""?>")
    '        .WriteLine("<?mso-application progid=""Excel.Sheet""?>")
    '        .WriteLine("<Workbook xmlns=""urn:schemas-microsoft-com:office:spreadsheet"">")
    '        .WriteLine("    <Styles>")
    '        .WriteLine("        <Style ss:ID=""hdr"">")
    '        .WriteLine("            <Alignment ss:Horizontal=""Center""/>")
    '        .WriteLine("            <Borders>")
    '        .WriteLine("                <Border ss:Position=""Left"" ss:LineStyle=""Continuous"" ss:Weight=""1""/>")
    '        .WriteLine("                <Border ss:Position=""Right"" ss:LineStyle=""Continuous"" ss:Weight=""1""/>")
    '        .WriteLine("                <Border ss:Position=""Top"" ss:LineStyle=""Continuous"" ss:Weight=""1""/>")
    '        .WriteLine("            </Borders>")
    '        .WriteLine("            <Font ss:FontName=""Calibri"" ss:Size=""11"" ss:Bold=""1""/>") 'SET FONT
    '        .WriteLine("        </Style>")
    '        .WriteLine("        <Style ss:ID=""ksg"">")
    '        .WriteLine("            <Alignment ss:Vertical=""Bottom""/>")
    '        .WriteLine("            <Borders/>")
    '        .WriteLine("            <Font ss:FontName=""Calibri""/>") 'SET FONT
    '        .WriteLine("        </Style>")
    '        .WriteLine("        <Style ss:ID=""isi"">")
    '        .WriteLine("            <Borders>")
    '        .WriteLine("                <Border ss:Position=""Bottom"" ss:LineStyle=""Continuous"" ss:Weight=""1""/>")
    '        .WriteLine("                <Border ss:Position=""Left"" ss:LineStyle=""Continuous"" ss:Weight=""1""/>")
    '        .WriteLine("                <Border ss:Position=""Right"" ss:LineStyle=""Continuous"" ss:Weight=""1""/>")
    '        .WriteLine("                <Border ss:Position=""Top"" ss:LineStyle=""Continuous"" ss:Weight=""1""/>")
    '        .WriteLine("            </Borders>")
    '        .WriteLine("            <Font ss:FontName=""Calibri"" ss:Size=""10""/>") 'SET FONT
    '        .WriteLine("        </Style>")
    '        .WriteLine("    </Styles>")
    '        If DGV.Name = "Student" Then
    '            .WriteLine("    <Worksheet ss:Name=""Student"">") 'SET NAMA SHEET
    '            .WriteLine("        <Table>")
    '            .WriteLine("            <Column ss:Width=""10""/>") 'No
    '            .WriteLine("            <Column ss:Width=""20""/>") 'NIK
    '            .WriteLine("            <Column ss:Width=""20""/>") 'Nama
    '            .WriteLine("            <Column ss:Width=""30""/>") 'Alamat
    '            .WriteLine("            <Column ss:Width=""20""/>") 'Telp
    '            .WriteLine("            <Column ss:Width=""25""/>") 'No
    '            .WriteLine("            <Column ss:Width=""6.5""/>") 'NIK
    '            .WriteLine("            <Column ss:Width=""30""/>") 'Nama
    '            .WriteLine("            <Column ss:Width=""30""/>") 'Alamat
    '            .WriteLine("            <Column ss:Width=""20""/>") 'Telp
    '            .WriteLine("            <Column ss:Width=""8""/>") 'No
    '            .WriteLine("            <Column ss:Width=""6""/>") 'NIK
    '            .WriteLine("            <Column ss:Width=""13""/>") 'Nama
    '        End If
    '        'AUTO SET HEADER
    '        .WriteLine("            <Row ss:StyleID=""ksg"">")
    '        For i As Integer = 0 To DGV.Columns.Count - 1 'SET HEADER
    '            Application.DoEvents()
    '            .WriteLine("            <Cell ss:StyleID=""hdr"">")
    '            .WriteLine("                <Data ss:Type=""String"">{0}</Data>", DGV.Columns.Item(i).HeaderText)
    '            .WriteLine("            </Cell>")
    '        Next
    '        .WriteLine("            </Row>")
    '        For intRow As Integer = 0 To DGV.RowCount - 2
    '            Application.DoEvents()
    '            .WriteLine("        <Row ss:StyleID=""ksg"" ss:utoFitHeight =""0"">")
    '            For intCol As Integer = 0 To DGV.Columns.Count - 1
    '                Application.DoEvents()
    '                .WriteLine("        <Cell ss:StyleID=""isi"">")
    '                .WriteLine("            <Data ss:Type=""String"">{0}</Data>", DGV.Item(intCol, intRow).Value.ToString)
    '                .WriteLine("        </Cell>")
    '            Next
    '            .WriteLine("        </Row>")
    '        Next
    '        .WriteLine("        </Table>")
    '        .WriteLine("    </Worksheet>")
    '        .WriteLine("</Workbook>")
    '        .Close()
    '    End With
    'End Sub

    'Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
    '    Dim SaveFile As New SaveFileDialog
    '    SaveFile.Filter = "Excel 통합 문서 files (*.xls)|*.xls|All files (*.*)|*.*"
    '    If SaveFile.ShowDialog = DialogResult.OK Then
    '        Dim fullPath = SaveFile.FileName

    '        DataGridView1.DataSource = dt
    '        If DataGridView1.RowCount = 0 Then Return

    '        Button3.Text = "Please Wait..."
    '        Button3.Enabled = False
    '        Application.DoEvents()

    '        Dim DGV As New DataGridView

    '        With DGV
    '            .AllowUserToAddRows = False
    '            .Name = "Student"
    '            .Visible = False
    '            .Columns.Clear()
    '            For r As Integer = LBound(strColumns) To UBound(strColumns)
    '                .Columns.Add(strColumns(r), strColumns(r))
    '            Next r
    '            '.Columns.Add("No", "No")
    '            '.Columns.Add("NIK", "NIK")
    '            '.Columns.Add("Nama", "Nama")
    '            '.Columns.Add("Alamat", "Alamat")
    '            '.Columns.Add("Telp", "Telp")
    '        End With
    '        With DataGridView1
    '            If .Rows.Count > 0 Then
    '                For i As Integer = 0 To .Rows.Count - 1
    '                    Application.DoEvents()
    '                    DGV.Rows.Add(IIf(i = 0, 1, i + 1),
    '                                 .Rows(i).Cells("Type").Value,
    '                                 .Rows(i).Cells("App").Value,
    '                                 .Rows(i).Cells("Feature").Value,
    '                                 .Rows(i).Cells("Function_Description").Value,
    '                                 .Rows(i).Cells("Test Action").Value,
    '                                 .Rows(i).Cells("TestType_Description").Value,
    '                                 .Rows(i).Cells("Import").Value,
    '                                 .Rows(i).Cells("Validation method").Value,
    '                                 .Rows(i).Cells("Around").Value,
    '                                 .Rows(i).Cells("Defect History").Value,
    '                                 .Rows(i).Cells("Priroty").Value,
    '                                 .Rows(i).Cells("Result").Value,
    '                                 .Rows(i).Cells("Comment").Value)
    '                Next
    '            End If
    '        End With

    '        FlNm = fullPath
    '        'FlNm = Application.StartupPath & "\Student " _
    '        '        & Now.Day & "-" & Now.Month & "-" & Now.Year & ".xls"
    '        If File.Exists(fullPath) Then File.Delete(fullPath)
    '        ExportToExcel(DGV)

    '        DGV.Dispose()
    '        DGV = Nothing

    '        '  Process.Start(fullPath)

    '        Button3.Text = "Export"
    '        Button3.Enabled = True
    '    End If
    'End Sub


    ' 미리보기의 값을 엑셀에 넣어줌
    Sub InsertData(strExcelFileName As String)

        '/////////////////////////////////////////////////////////////////
        'SQL Insert 방법으로 하는것 ID입력 관련 수정 후 적용 171019
        '템플릿 엑셀 파일의 A2셀에 숫자 형식으로 설정 후 2번행 숨김 처리후 사용(이렇게 하지 않으면 ID가 추가될 떄 10이상 나오지않음)

        Dim vSQL As String = Nothing
        Dim strSht As String = "Sheet1$"
        Dim DS As DataSet = New DataSet
        Dim DA As OleDbDataAdapter = New OleDbDataAdapter
        Dim vCon As String = Nothing
        Dim vConn As OleDbConnection
        '    Dim nID As Integer = Nothing
        ' Dim ColumnName() As String = {"Model", "차수", "변경점", "변경점내용", "Risk_Factor", "기본검증", "검증방법", "구분", "AppName", "Feature", "Feature_Des", "TestAction", "검증유형", "등록자"}

        Try
            '    vSQL = "Select ID FROM [" & strSht & "A8:M" & DataGridView1.RowCount & "] order by ID desc"

            For i As Integer = 0 To DataGridView1.RowCount - 1
                Application.DoEvents()
                ' Connect 연결
                vCon = "Provider=Microsoft.Ace.OLEDB.12.0;Data Source=" & strExcelFileName & ";Extended Properties=""Excel 12.0;HDR=YES;"""
                vConn = New OleDbConnection(vCon)
                vConn.Open()

                vSQL = "INSERT INTO [" & strSht & '"A8:M" & DataGridView1.RowCount &
                    "] ( [Type], [App], [Feature],[Function_Description], [Test Action], [TestAction_Description], [Import], [Validation method],[Around], [Defect History], [Priroty]) " &
                    "VALUES ( '"
                For j As Integer = 0 To 9
                    Application.DoEvents()
                    If Not IsDBNull(DataGridView1.Item(j, i).Value) Then
                        vSQL = vSQL + Replace(DataGridView1.Item(j, i).Value, "'", "''") & "','"
                    Else
                        vSQL = vSQL + "','"
                    End If
                Next
                If Not IsDBNull(DataGridView1.Item(10, i).Value) Then
                    vSQL = vSQL + Replace(DataGridView1.Item(10, i).Value, "'", "''") & "');"
                Else
                    vSQL = vSQL + "');"
                End If


                DA = New OleDbDataAdapter(vSQL, vConn)
                DA.Fill(DS)

                'Connect 해제
                vConn.Close()
                vConn = Nothing
            Next
            '   MsgBox("끝")

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs)
        Dim win As New Notification
        win.Show()

    End Sub
End Class