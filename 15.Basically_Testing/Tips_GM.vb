'### 팁 부분 ######
Imports System.Data
Imports System.Data.OleDb
Imports Excel = Microsoft.Office.Interop.Excel
Imports System.Windows.Forms
Imports System.IO
'Imports Microsoft.Office.Interop
Imports Microsoft.Office
Imports System.Drawing
'Imports Microsoft.Office.Interop.Excel
'Imports Microsoft.Office.Interop.Excel

Public Class Tips_GM
    Public DS As DataSet = New DataSet
    Public DA As OleDbDataAdapter = New OleDbDataAdapter()
    'Public strSQL As String
    'Public vConn As OleDbConnection
    Private blchk As Boolean = False
    Private strSht As String
    Private InfoConn As OleDbConnection
    Private strFilePath As String = Nothing '"\\10.174.51.33\Q-Portal\기본검증"
    'Private strFilePath As String = "C:\WorkSpace\01. Work\2017\07. July\0724"
    Private szFileName As String = Nothing
    Private szMerge As String = Nothing
    Private szPri As String = Nothing
    Private szTemp As String = Nothing
    Private Table_Word As DataTable
    Private szPri_S As String = "Y_Sanity"
    Private szPri_B As String = "Y_Basic"
    Private szPri_F As String = "Y_Full"
    Private nCnt As Integer = 0
    Private nCnt_fea As Integer = 0
    Private nCnt_type As Integer = 0
    Dim strFile As String = "Tips_DB"

    '파일이 켜져있는지 학인
    Private Function FileIsOpen(ByVal pathfile As String) As Boolean
        Try
            Dim fs As IO.FileStream = IO.File.Open(pathfile, IO.FileMode.Open, IO.FileAccess.Read, IO.FileShare.None)
            fs.Close()
            fs.Dispose()
            fs = Nothing
            Return False
        Catch ex As IO.IOException ' File open
            Return True
        Catch ex As Exception ' Unknown error
            Return True
        End Try
    End Function
    '★ 폼이 처음 Load 했을 때
    Private Sub Tips_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        SanityRD.Checked = True ' Sanity Radio Button Check  즉, 처음 시작할 때 Sanity를 보여주기 위함.
        Dim pathFile As String = Nothing

        Dim XML As New XML
        XML.Folder_Path("Tip", strFilePath)
        XML = Nothing
        pathFile = strFilePath + "\" + strFile + ".xlsx"

        ' 파일이 켜져있는지 확인
        If FileIsOpen(pathFile) Then
            'MsgBox("파일이 열려있습니다.")
            '파일을 복사하여 파일 저장 위치를 바꿔줌
            IO.File.Copy(pathFile, Application.StartupPath + "\Tips_DB.xlsx", True)

            strFilePath = Application.StartupPath

            ' Exit Sub
        End If

        Call listup(sender, e)  ' 선택 한 

        Table_Word = DS.Tables(0)
        'lstApp.Items.Clear()

        txt_Cnt.Text = 0
        txt_Fea.Text = 0
        txt_Type.Text = 0

        nCnt = 0
        nCnt_fea = 0
        nCnt_type = 0

        For i As Integer = 0 To Table_Word.Rows.Count - 1    ' Data table Row 만큼 반복 -1은 마지막행은 Null
            Try
                If Not lstApp.Items.Contains(Table_Word.Rows(i)(0).ToString()) And Table_Word.Rows(i)(6).ToString() = "Y_Sanity" Then  ' 중복 없이 Item 추가
                    lstApp.Items.Add(Table_Word.Rows(i)(0).ToString())
                    nCnt = nCnt + 1
                End If

                If Table_Word.Rows(i)(6).ToString() = "Y_Sanity" Then
                    nCnt_fea = nCnt_fea + 1
                    nCnt_type = nCnt_type + 1
                End If

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Next

        'count 한 개수 대입
        txt_Cnt.Text = nCnt
        txt_Fea.Text = nCnt_fea
        txt_Type.Text = nCnt_type

    End Sub
    '★★ App을 선택 했을 때 
    Private Sub lstApp_Click(sender As Object, e As EventArgs) Handles lstApp.Click
        Try
            Dim nCnt As Integer = 0

            lstType.Items.Clear()
            lstFea.Items.Clear()        ' Data Clear 

            DesTxt.Text = ""            ' 설명 초기화 
            txtDefault.Text = ""
            txt_History.Text = ""
            txtAround.Text = ""

            If lstApp.SelectedItems.Count = 1 Then
                'Table_Word.Rows(i)(6).ToString()
                For i As Integer = 0 To Table_Word.Rows.Count - 1    ' Data table Row 만큼 반복 -1은 마지막행은 Null

                    If lstApp.Text = Table_Word.Rows(i)(0).ToString() Then ' 내가 선택한 앱명과 같은 DB의 앱 이라면
                        Try

                            If SanityRD.Checked = True Then ' 만약 Sanity 이라면
                                If Table_Word.Rows(i)(6).ToString() = szPri_S Then
                                    If Not lstFea.Items.Contains(Table_Word.Rows(i)(1).ToString()) Then  ' 중복 없이 Item 추가
                                        nCnt = nCnt + 1
                                        lstFea.Items.Add(Table_Word.Rows(i)(1).ToString())
                                    End If
                                End If
                            ElseIf BasicRD.Checked = True Then ' 만약 Basic 이라면
                                If Table_Word.Rows(i)(6).ToString() = szPri_S Or Table_Word.Rows(i)(6).ToString() = szPri_B Then
                                    If Not lstFea.Items.Contains(Table_Word.Rows(i)(1).ToString()) Then  ' 중복 없이 Item 추가
                                        nCnt = nCnt + 1
                                        lstFea.Items.Add(Table_Word.Rows(i)(1).ToString())
                                    End If
                                End If

                            ElseIf FullRD.Checked = True Then  ' 만약 Full 이라면
                                If Not lstFea.Items.Contains(Table_Word.Rows(i)(1).ToString()) Then  ' 중복 없이 Item 추가
                                    nCnt = nCnt + 1
                                    lstFea.Items.Add(Table_Word.Rows(i)(1).ToString())
                                End If

                            End If

                        Catch ex As Exception
                            MsgBox(ex.Message)
                        End Try
                    End If
                Next
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
    '★ 기본검증 Test Feature 선택 시 다음 Test Type 보여주는 부분
    Private Sub lstFea_Click(sender As Object, e As EventArgs) Handles lstFea.Click

        lstType.Items.Clear()      ' Data Clear 
        DesTxt.Text = ""            ' 설명 초기화 
        txtDefault.Text = ""
        txtAround.Text = ""
        txt_History.Text = ""

        For i As Integer = 0 To Table_Word.Rows.Count - 1    ' Data table Row 만큼 반복 -1은 마지막행은 Null

            If lstApp.Text = Table_Word.Rows(i)(0).ToString() And lstFea.Text = Table_Word.Rows(i)(1).ToString() Then ' 선택 된 App과 Row, 필트(0)은 App, (1) 은 Feature

                If SanityRD.Checked = True Then ' 만약 Sanity 이라면
                    If Not lstType.Items.Contains(Table_Word.Rows(i)(3).ToString()) And Table_Word.Rows(i)(6).ToString() = szPri_S Then  ' 중복 없이 Item 추가
                        lstType.Items.Add(Table_Word.Rows(i)(3).ToString())

                        Dim strTextCom = Table_Word.Rows(i)(2).ToString()
                        DesTxt.Text = Replace(strTextCom, Chr(10), Chr(13) & Chr(10))
                    End If

                ElseIf BasicRD.Checked = True Then ' 만약 Basic 이라면
                    If Not lstType.Items.Contains(Table_Word.Rows(i)(3).ToString()) And Table_Word.Rows(i)(6).ToString() = szPri_S Or Table_Word.Rows(i)(6).ToString() = szPri_B Then  ' 중복 없이 Item 추가
                        lstType.Items.Add(Table_Word.Rows(i)(3).ToString())

                        Dim strTextCom = Table_Word.Rows(i)(2).ToString()
                        DesTxt.Text = Replace(strTextCom, Chr(10), Chr(13) & Chr(10))
                    End If

                ElseIf FullRD.Checked = True Then ' 만약 Full 이라면
                    If Not lstType.Items.Contains(Table_Word.Rows(i)(3).ToString()) Then  ' 중복 없이 Item 추가
                        lstType.Items.Add(Table_Word.Rows(i)(3).ToString())

                        Dim strTextCom = Table_Word.Rows(i)(2).ToString()
                        DesTxt.Text = Replace(strTextCom, Chr(10), Chr(13) & Chr(10))
                    End If
                End If
            End If
        Next
    End Sub

    '★ 기본검증 Test Type 선택 했을 때 설명 보여주는 부분
    Private Sub lstType_Click(sender As Object, e As EventArgs) Handles lstType.Click

        txtAround.Text = ""
        txtDefault.Text = ""
        txt_History.Text = ""

        For i As Integer = 0 To Table_Word.Rows.Count - 1    ' Data table Row 만큼 반복 -1은 마지막행은 Null
            If lstApp.Text = Table_Word.Rows(i)(0).ToString() And lstFea.Text = Table_Word.Rows(i)(1).ToString() And lstType.Text = Table_Word.Rows(i)(3).ToString() Then ' 선택 된 App과 Row, 필트(0)은 App, (1) 은 Feature
                Try
                    If SanityRD.Checked = True Then
                        If Table_Word.Rows(i)(6).ToString() = szPri_S Then
                            Dim strTxtDef = Table_Word.Rows(i)(4).ToString()
                            Dim strTxtAro = Table_Word.Rows(i)(5).ToString()
                            Dim strTxtHis = Table_Word.Rows(i)(7).ToString()

                            txtDefault.Text = Replace(strTxtDef, Chr(10), Chr(13) & Chr(10))
                            txtAround.Text = Replace(strTxtAro, Chr(10), Chr(13) & Chr(10))
                            txt_History.Text = Replace(strTxtHis, Chr(10), Chr(13) & Chr(10))
                        End If

                    ElseIf BasicRD.Checked = True Then
                        If Table_Word.Rows(i)(6).ToString() = szPri_S Or Table_Word.Rows(i)(6).ToString() = szPri_B Then
                            Dim strTxtDef = Table_Word.Rows(i)(4).ToString()
                            Dim strTxtAro = Table_Word.Rows(i)(5).ToString()
                            Dim strTxtHis = Table_Word.Rows(i)(7).ToString()

                            txtDefault.Text = Replace(strTxtDef, Chr(10), Chr(13) & Chr(10))
                            txtAround.Text = Replace(strTxtAro, Chr(10), Chr(13) & Chr(10))
                            txt_History.Text = Replace(strTxtHis, Chr(10), Chr(13) & Chr(10))
                        End If

                    ElseIf FullRD.Checked = True Then
                        Dim strTxtDef = Table_Word.Rows(i)(4).ToString()
                        Dim strTxtAro = Table_Word.Rows(i)(5).ToString()
                        Dim strTxtHis = Table_Word.Rows(i)(7).ToString()

                        txtDefault.Text = Replace(strTxtDef, Chr(10), Chr(13) & Chr(10))
                        txtAround.Text = Replace(strTxtAro, Chr(10), Chr(13) & Chr(10))
                        txt_History.Text = Replace(strTxtHis, Chr(10), Chr(13) & Chr(10))
                    End If


                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            End If
        Next

    End Sub
    ' ### Basic Button 클릭 했을 때 ######
    Private Sub BasicRD_TabIndexChanged(sender As Object, e As EventArgs) Handles BasicRD.MouseClick

        ' Count 
        txt_Cnt.Text = 0
        txt_Fea.Text = 0
        txt_Type.Text = 0

        ' 버튼 선택 시 이미 조회 된 항목 Clear() 될 수 있도록 
        lstApp.Items.Clear()
        lstFea.Items.Clear()
        lstType.Items.Clear()
        DesTxt.Text = ""
        txtDefault.Text = ""
        txtAround.Text = ""

        Dim nCnt As Integer = 0
        nCnt_fea = 0
        nCnt_type = 0

        szPri = "Y_Basic"

        For i As Integer = 0 To Table_Word.Rows.Count - 1    ' Data table Row 만큼 반복 -1은 마지막행은 Null
            Try
                If Not lstApp.Items.Contains(Table_Word.Rows(i)(0).ToString()) Then  ' 중복 없이 Item 추가
                    If Table_Word.Rows(i)(6).ToString() = szPri_S Or Table_Word.Rows(i)(6).ToString() = szPri_B Then
                        lstApp.Items.Add(Table_Word.Rows(i)(0).ToString())
                        nCnt = nCnt + 1
                    End If
                End If

                If Table_Word.Rows(i)(6).ToString() = "Y_Sanity" Or Table_Word.Rows(i)(6).ToString() = "Y_Basic" Then
                    nCnt_fea = nCnt_fea + 1
                    nCnt_type = nCnt_type + 1
                End If

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Next

        'count 한 개수 대입
        txt_Cnt.Text = nCnt
        txt_Fea.Text = nCnt_fea
        txt_Type.Text = nCnt_type

    End Sub
    ' ### Full Button 클릭 했을 때 ######
    Private Sub FullRD_Click(sender As Object, e As EventArgs) Handles FullRD.MouseClick

        ' Count 
        txt_Cnt.Text = 0
        txt_Fea.Text = 0
        txt_Type.Text = 0

        ' 버튼 선택 시 이미 조회 된 항목 Clear() 될 수 있도록 
        lstApp.Items.Clear()
        lstFea.Items.Clear()
        lstType.Items.Clear()
        DesTxt.Text = ""
        txtDefault.Text = ""
        txtAround.Text = ""

        Dim nCnt As Integer = 0
        nCnt_fea = 0
        nCnt_type = 0


        szPri = "Y_Full"
        For i As Integer = 0 To Table_Word.Rows.Count - 1    ' Data table Row 만큼 반복 -1은 마지막행은 Null
            Try
                If Not lstApp.Items.Contains(Table_Word.Rows(i)(0).ToString()) Then  ' 중복 없이 Item 추가
                    lstApp.Items.Add(Table_Word.Rows(i)(0).ToString())
                    nCnt = nCnt + 1
                End If

                If Table_Word.Rows(i)(6).ToString() = "Y_Sanity" Or Table_Word.Rows(i)(6).ToString() = "Y_Basic" Or Table_Word.Rows(i)(6).ToString() = "Y_Full" Then
                    nCnt_fea = nCnt_fea + 1
                    nCnt_type = nCnt_type + 1
                End If

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Next

        'count 한 개수 대입
        txt_Cnt.Text = nCnt
        txt_Fea.Text = nCnt_fea
        txt_Type.Text = nCnt_type

    End Sub
    ' ### Sanity Button 클릭 했을 때 ######
    Private Sub SanityRD_Click(sender As Object, e As EventArgs) Handles SanityRD.MouseClick

        ' Count 
        txt_Cnt.Text = 0
        txt_Fea.Text = 0
        txt_Type.Text = 0

        ' 버튼 선택 시 이미 조회 된 항목 Clear() 될 수 있도록 
        lstApp.Items.Clear()
        lstFea.Items.Clear()
        lstType.Items.Clear()
        DesTxt.Text = ""
        txtDefault.Text = ""
        txtAround.Text = ""

        Dim nCnt As Integer = 0
        nCnt_fea = 0
        nCnt_type = 0


        Dim strPriority As String = "Y_Sanity"

        szPri = "Y_Sanity"
        For i As Integer = 0 To Table_Word.Rows.Count - 1    ' Data table Row 만큼 반복 -1은 마지막행은 Null
            Try
                If Not lstApp.Items.Contains(Table_Word.Rows(i)(0).ToString()) And Table_Word.Rows(i)(6).ToString() = szPri_S Then  ' 중복 없이 Item 추가
                    lstApp.Items.Add(Table_Word.Rows(i)(0).ToString())
                    nCnt = nCnt + 1
                End If

                If Table_Word.Rows(i)(6).ToString() = "Y_Sanity" Then
                    nCnt_fea = nCnt_fea + 1
                    nCnt_type = nCnt_type + 1
                End If

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Next

        'count 한 개수 대입
        txt_Cnt.Text = nCnt
        txt_Fea.Text = nCnt_fea
        txt_Type.Text = nCnt_type


    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim Tip_Request As New Tip_Request_GM
        Tip_Request.Show()
    End Sub

    Private Sub btnOpen_Click(sender As Object, e As EventArgs) Handles btnOpen.Click

        Dim szFile As String = "Tips_DB"
        Dim szPath_Report As String = strFilePath
        Call OpenExcelFile(szFile, szPath_Report)

    End Sub
    Sub listup(sender As Object, e As EventArgs)

        'SanityRD.Checked = True
        Dim strSQLWord As String = Nothing

        'If strPriority = "" Then
        '    strSQLWord = ""
        'Else
        '    strSQLWord = " AND 선정기준 LIKE '%" & Replace(strPriority, "'", "''") & "%'"
        'End If

        blchk = True

        Try
            'Dim XML As New XML
            'XML.Folder_Path("Tip", strFilePath)
            'XML = Nothing

            Dim dirA As DirectoryInfo = New DirectoryInfo(strFilePath)    ' 디렉토리 지정
            For Each dra In dirA.GetFiles()     ' For each를 통해 폴더 내의 파일을 찾음
                szTemp = dra.Name
                If InStr(Trim(dra.Name), RTrim(strFile)) And Strings.Left(szTemp, 2) <> "~$" Then  ' Consumer TC와 Kernel TC / Framework TC의 파일 Naming이 다름
                    szFileName = dra.Name
                    blchk = True
                    Exit For
                End If
            Next

            If blchk Then
                szMerge = strFilePath & "\" & szFileName
            Else
                MsgBox(strFile & " 파일이 없는 것 같습니다. " & strFilePath & " <-- 경로에 파일이 있는지, '재발방지체크리스트' 파일명도 확인해주세요 ")
            End If

            Dim strExcel As String = "Provider=Microsoft.Ace.OLEDB.12.0;Data Source=" & szMerge & ";Extended Properties=""Excel 12.0;HDR=YES;;"""

            InfoConn = New OleDbConnection(strExcel)

            strSht = "기본검증"

            Dim argTyp As String = "Y"
            Dim vSQLtyp As String = " AND [Import] LIKE '%" & Replace(argTyp, "'", "''") & "%'"

            '#### 쿼리 작성 #########################################################
            Dim vSQL As String = "SELECT [App],[Feature],[Function_Description],[Test Action],[Validation method],Around,Priroty,[Defect History] " & " "
            vSQL = vSQL + "FROM [" & strSht & "$A12:M500000]" & " "
            vSQL = vSQL + "Where [App] > '' " & vSQLtyp '& strSQLWord
            '#######################################################################

            DA = New OleDbDataAdapter(vSQL, InfoConn)
            DA.Fill(DS, strSht)


            Dim vSQL2 As String = "SELECT *FROM [" & strSht & "$A12:M500000] where Import = 'Y' order by Type asc "
            DA = New OleDbDataAdapter(vSQL2, InfoConn)
            DA.Fill(DS, "AllSelect")

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


    End Sub

    Sub OpenExcelFile(ByVal szFile As String, ByVal szPath As String)
        Dim strFileName As String = Nothing
        Dim szPath_Temp As String = Nothing
        Dim blChk As Boolean = False
        Dim szTemp As String = Nothing

        Try
            'For Each entry As String In Directory.GetDirectories(szPath)        ' GetDirectories(Path) <- 해당 Path에 있는 Folder 및 Files 찾음
            ' 지정 한 경로를 반복 하면서 경로와 '구분'명과 일치하는 폴더를 찾음.
            ' 찾은 경로로 진입 하여 그 안의 파일명을 찾는다.
            Dim dirA As DirectoryInfo = New DirectoryInfo(szPath)    ' 디렉토리 지정
            'strPathName = entry

            For Each dra In dirA.GetFiles()     ' For each를 통해 폴더 내의 파일을 찾음
                szTemp = dra.Name
                If InStr(dra.Name, szFile) And Strings.Left(szTemp, 2) <> "~$" Then  ' Consumer TC와 Kernel TC / Framework TC의 파일 Naming이 다름
                    'szPath_Temp = entry
                    szFile = dra.Name
                    Exit For
                End If
            Next
            ' Next

            strFileName = szPath & "\" & szFile

            If IO.File.Exists(strFileName) Then
                blChk = True
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
                MsgBox("파일을 열지 못했습니다.." & vbCrLf & szPath & "에서 " & szFile & "(이)가 있는지 확인 해보세요.")
                Exit Sub
            End If

            If blChk = False Then
                MsgBox("파일을 열지 못했습니다." & vbCrLf & szPath & "에서 " & szFile & "이 없거나, 권한이 없을 수 있습니다." _
                       & "권한을 요청 해주세요.")
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox(ex.Message, "열려는 파일이 없습니다." & vbCrLf & strFileName & "에서 확인 해보세요.")
        End Try
    End Sub

    Private Sub btnLocal_Click(sender As Object, e As EventArgs)
        'Dim itemSelect As String = Nothing
        'Dim chk As Boolean = True

        ''선택한 앱들을 Dataview에서 조건으로 쓸수 있게 String 변수에 넣어줌
        'For Each x In lstApp.SelectedItems
        '    If chk Then
        '        itemSelect = "app = '" + x.ToString
        '        chk = False
        '    Else
        '        itemSelect = itemSelect + "' or app = '"
        '        itemSelect = itemSelect + x.ToString
        '    End If
        'Next
        'itemSelect = itemSelect + "' "

        'Dim dv As DataView
        'dv = New DataView(DS.Tables(1), itemSelect, "App Asc", DataViewRowState.CurrentRows)
        'Dim dt As DataTable = Nothing
        'dt = dv.ToTable
        ''Excel 파일 생성 해줌

        'Dim Proceed As Boolean = False
        'Dim xlApp As Excel.Application = Nothing
        'Dim xlWorkBooks As Excel.Workbooks = Nothing
        'Dim xlWorkBook As Excel.Workbook = Nothing
        'Dim xlWorkSheet As Excel.Worksheet = Nothing
        'Dim xlWorkSheets As Excel.Sheets = Nothing
        'Dim xlCells As Excel.Range = Nothing
        'xlApp = New Excel.Application
        ''xlApp.DisplayAlerts = False
        'xlWorkBooks = xlApp.Workbooks

        'xlWorkBook = xlWorkBooks.Add()
        ''xlApp.Visible = True
        'xlWorkSheets = xlWorkBook.Sheets
        'xlWorkSheet = xlWorkSheets.Add
        'xlWorkSheet.Name = "기본검증"

        'Dim ms As Excel.Worksheets = Nothing

        ''ms = xlWorkBooks(xlWorkBook.Name).Worksheets("기본검증")
        ''ms.activate ''

        ''  ms = xlWorkBooks(xlWorkBook.Name).Sheets("기본검증")




        'xlWorkSheet.Cells(1, 1) = "LGE Internal Use Only"
        'xlWorkSheet.Range("A1").Font.Color = Color.Red
        'xlWorkSheet.Cells(1, 1).Font.Bold = True

        ''중간 내용 들어갈 부분
        'Dim strColumns = {"Type", "App", "Feature", "Function_Description", "Test Action", "TestAction_Description", "Import", "Validation method", "Around", "Defect History", "Priroty", "Result", "Comment"}
        'Dim colSize = {10, 20, 20, 30, 20, 25, 6.5, 30, 30, 20, 8, 6, 13}
        'Dim strResult = {"Total", "OK", "NG", "NT", "Progress"}
        'Dim strResult2 = {"TC 사업자 불일치", "TC 오류", "Test 환경 미지원", "기능 미구현", "기타"}
        'Dim i As Integer = 8
        'Dim j As Integer = 0

        ''결과값표 추가 해주는 부분
        'For a As Integer = 2 To 6
        '    xlWorkSheet.Cells(a, "K") = strResult(a - 2)
        'Next a
        'For a As Integer = 2 To 6
        '    xlWorkSheet.Cells(a, "M") = strResult2(a - 2)
        'Next a

        ''테두리와 글자크기 조정
        'xlCells = xlWorkSheet.Range("K2:N6")
        'xlCells.Borders.LineStyle = "1"
        'xlCells.Font.Size = "9"

        ''결과표에 색입히기
        'xlCells = xlWorkSheet.Range("K2:K6")
        'xlCells.Interior.Color = Color.LightGray

        'xlCells = xlWorkSheet.Range("M2:M6")
        'xlCells.Interior.Color = Color.LightGray


        ''column명 넣어주기
        ''xlCells = xlWorkSheet.Range("A3:M3")
        'xlCells = xlWorkSheet.Range("A8:M8")
        'xlCells.ColumnWidth = colSize
        '' xlWorkSheet.Cells(3, 1).Resize(1, UBound(strColumns)) = xlApp.WorksheetFunction.Transpose(strColumns)
        'Dim xlCells2 As Excel.Range = Nothing
        '' xlCells2 = xlWorkSheet.Range("A3")
        '' xlCells2 = xlApp.WorksheetFunction.Transpose(strColumns)

        'Dim f As Integer = 0
        'For r As Integer = LBound(strColumns) To UBound(strColumns)
        '    xlWorkSheet.Cells(8, r + 1) = strColumns(r)
        'Next r

        ''Dim varTemp()

        ''varTemp() = dv.ToTable()

        ''varTemp = rng



        ''While j < strColumns.Length
        ''    '    'xlWorkSheet.Cells(i, j + 1) = strColumns(j)
        ''xlCells.Cells(i, j + 1) = strColumns(j)
        ''    '    '   xlCells.ColumnWidth = colSize(j)
        ''    j += 1
        ''End While

        '' DataTable Row수 만큼 loop

        'i = 0
        'For Each x In dt.Rows
        '    j = 0
        '    ' DataTable column수 만큼 loop
        '    For Each dc In dt.Columns
        '        xlWorkSheet.Cells(i + 9, j + 1) = dt.Rows.Item(i)(j).ToString
        '        j += 1
        '    Next
        '    i += 1
        'Next
        ''Range설정 후 테두리, columns width설정
        ''   xlCells = xlWorkSheet.Range("A4")
        ''  xlCells = dv.ToTable
        'xlCells = xlWorkSheet.Range("A8:M" & dt.Rows.Count + 3)


        'xlCells.Borders.LineStyle = "1"
        'xlCells.Font.Size = "9"
        'xlCells.WrapText = True



        ''  xlCells.Columns.AutoFit()

        'xlCells = xlWorkSheet.Range("A8:M8")
        'xlWorkSheet.Cells(1, 1).Font.Bold = True
        'xlCells.Font.Size = "10"
        'xlCells.Font.Bold = True

        ''i = 0
        ''For Each x In dt.Rows
        ''    j = 0
        ''    ' DataTable column수 만큼 loop
        ''    For Each dc In dt.Columns
        ''        xlWorkSheet.Cells(i + 4, j + 1) = dt.Rows.Item(i)(j).ToString
        ''        j += 1
        ''    Next
        ''    i += 1
        ''Next

        ''rngCal.RowHeight = 20
        '' Column Range지정 후 Auto Fit

        ''For Each rngC In rngSet
        ''    rngC.Columns.ColumnWidth = 15
        ''Next


        'Dim SaveFile As New SaveFileDialog
        'SaveFile.Filter = "Excel 통합 문서 files (*.xlsx)|*.xlsx|All files (*.*)|*.*"
        'SaveFile.ShowDialog()
        'Dim fullPath = SaveFile.FileName

        'xlWorkBook.SaveAs(fullPath)

        'xlWorkBook.Close(True)
        'xlApp.Quit()

        'xlWorkBook = Nothing
        'xlApp = Nothing

        '' GC.Collect()
        ''MsgBox("업로드 완료")

        ''SaveFileDialog 띄워서 저장할 경로와 이름을 얻어서 저장 함



        ''MsgBox("ddddddd")

        ''Dim SaveFile As New SaveFileDialog
        ''SaveFile.Filter = "Excel 매크로 사용 통합 문서 files (*.xlsm)|*.xlsm|All files (*.*)|*.*"
        ''SaveFile.ShowDialog()
        '''   MsgBox(OpenFile.SafeFileName)
        '''   MsgBox(OpenFile.FileName               )
        ''Dim fullPath = SaveFile.FileName
        '''Dim fileName = SaveFile.
        '''Dim pathName = fullPathName.Substring(0, (fullPathName.Length - fileName.Length))
        '''If fullPathName = "" And fileName = "" Then
        '''    Exit Sub
        '''End If


        ''Dim filePath As String = Nothing
        ''If fullPath.Contains(".") Then
        ''    Dim intSearch = fullPath.LastIndexOf("\")
        ''    filePath = fullPath.Substring(0, intSearch)
        ''End If



        ''Dim vSQL As String = Nothing


        ''vSQL = "Select [Type],[App],[Feature],[test Action],[TestAction_Description],[Import],[Validation method],[Around],[Defect],[History],[Priroty],[Result],[Comment] from "
        ''vSQL = vSQL
        ''vSQL = vSQL
    End Sub

    Private Sub btnExportTC_Click(sender As Object, e As EventArgs) Handles btnExportTC.Click

        Dim saveForm As New LocalSave

        saveForm.dt = DS.Tables(1)
        '  saveForm.DS = DS
        saveForm.Show()

    End Sub

    Private Sub lstApp_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstApp.SelectedIndexChanged

    End Sub
End Class