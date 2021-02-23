Imports System.Data
Imports System.Data.OleDb
Imports System.Diagnostics
Imports System.IO
Imports System.Windows.Forms

Public Class PreviewForm
    Public strColumns = {"번호", "Project", "Model", "차수", "App", "Feature", "기능변경점", "기능_RiskFactor", "App변경점", "App_Risk_Factor",
                                     "변경점_검증방법", "TestAction", "SubAction", "검증유형", "등록자", "등록시간"}  '16
    Public func = {"Function_Setting", "Function_Contents", "Function_Gesture"}
    Public chkLoad As Boolean
    Public strData(16)
    Public strFilePath As String = Nothing
    Public strFileName As String = "검계DB"
    Public strProject As String = Nothing
    Public strModel As String = Nothing
    Public strChasu As String = Nothing
    Public szFolderName As String = Nothing
    Public szFileName As String = Nothing
    Public szMerge As String = Nothing
    Public szTemp As String = Nothing
    Public blchk As Boolean = False
    Public Change_AddTree As Change_Add_Tree


    Dim DS2 As DataSet = New DataSet
    Dim DA2 As OleDbDataAdapter = New OleDbDataAdapter
    Dim strFuncChange As String = Nothing
    Dim strFuncRisk As String = Nothing
    Dim strAppChange As String = Nothing
    Dim strAppRisk As String = Nothing
    Dim strDes As String = Nothing
    Dim strGu As String = Nothing
    Dim strCom As String = Nothing
    Dim strFileGu As String = "Q-Portal 검증계획서"
    Dim strApp As String = Nothing
    Dim strFea As String = Nothing
    Dim strP As String = Nothing
    Dim strM As String = Nothing
    Dim strC As String = Nothing
    Dim strSa As String = Nothing
    Dim strDate As String = Nothing
    Dim strAction As String = Nothing
    Dim strSubAction As String = Nothing
    Dim nID As Integer = Nothing



    '초기화버튼
    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        If MessageBox.Show("미리보기를 초기화 하시겠습니까?", "Title", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            If chkLoad Then
                DataGridView1.DataSource = Nothing
                '컬럼 재설정
                DataGridView1.ColumnCount = strColumns.Length
                Dim i As Integer = 0

                While i < strColumns.Length
                    DataGridView1.Columns(i).Name = strColumns(i)
                    i += 1
                End While
                chkLoad = False
            Else
                DataGridView1.Rows.Clear()
            End If
        End If
    End Sub

    Private Sub PreviewForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Davagridview에서 Columns추가 함
        Dim rowPosition As Integer = DataGridView1.Rows.Count

        If rowPosition = 0 Then
            DataGridView1.ColumnCount = strColumns.Length
            Dim i As Integer = 0

            While i < strColumns.Length
                DataGridView1.Columns(i).Name = strColumns(i)

                i += 1
            End While
        End If
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        ' add 창이 켜져있는지 확인
        'Dim chkPreview As Boolean = False
        'For Each v In System.Windows.Forms.Application.OpenForms
        '    If v.Name = "Change_Add_Tree" Then
        '        '켜져있으면 변수에 true값넣어줌

        '        chkPreview = True
        '        Exit For
        '    End If
        'Next

        'If chkPreview Then

        ' Change_AddTree = ParentForm

        'If Change_AddTree.chkView.Checked = True Then
        '    Dim rowNum As Integer = Nothing
        '    Dim lastRowNum As Integer = Nothing

        '    'rowNumber 
        '    rowNum = DataGridView1.CurrentRow.Index
        '    'LastRowNumber
        '    lastRowNum = DataGridView1.Rows.Count

        '    '총 갯수가 1이거나 마지막 로우와 같다면 종료
        '    If lastRowNum = 1 Or rowNum = lastRowNum Then
        '        Exit Sub
        '    End If

        '    'Change_AddTree.txtFunc.Text = DataGridView1.Item(6, rowNum).Value
        '    'Change_AddTree.txtFuncRisk.Text = DataGridView1.Item(7, rowNum).Value
        '    ' txtTip.Text = previewForm.DataGridView1.Item(6, rowNum).Value
        '    Change_AddTree.txtApp.Text = DataGridView1.Item(8, rowNum).Value
        '    Change_AddTree.txtAppRisk.Text = DataGridView1.Item(9, rowNum).Value
        '    Change_AddTree.txtExport.Text = DataGridView1.Item(10, rowNum).Value

        ' 지금말고 나중에 다시 작업 18.01.15 14:00 Action 유형 Function 분류작업 부터 진행 하면됨
        'Dim itemNum As Integer = 0
        'Dim strChangeName As String = Nothing

        ''리스트를 돌면서 아이템 찾기(App)
        'For Each a In Change_AddTree.lstApp.Items
        '    'lstApp 이름 값 받아오기
        '    If InStr(a, "_(변경점)") > 0 Then
        '        strChangeName = Strings.Split(a, "_(변경점)")(0)
        '    Else
        '        strChangeName = a
        '    End If

        '    If DataGridView1.Item(6, rowNum).Value = strChangeName Then
        '        Change_AddTree.lstApp.SelectedIndex = itemNum
        '        Exit For
        '    End If
        '    itemNum += 1
        'Next


        'itemNum = 0
        ''리스트를 돌면서 아이템 찾기(Feature)
        'For Each a In Change_AddTree.lstFea.Items

        '    If DataGridView1.Item(9, rowNum).Value = a Then
        '        Change_AddTree.lstFea.SelectedIndex = itemNum
        '        Exit For
        '    End If
        '    itemNum += 1
        'Next

        'itemNum = 0
        ''리스트를 돌면서 아이템 찾기(Action유형)
        'For Each a In Change_AddTree.lstActionCa.Items

        '    For Each b In func
        '        If InStr(Strings.Split(DataGridView1.Item(10, rowNum).Value, " > ")(0), b) > 0 Then

        '        End If
        '    Next
        '    strChangeName = Strings.Split(DataGridView1.Item(10, rowNum).Value, " > ")(0)
        '    strChangeName = Strings.Split(strChangeName, "_")(0)

        '    If strChangeName = a Then
        '        Change_AddTree.lstActionCa.SelectedIndex = itemNum
        '        Exit For
        '    End If
        '    itemNum += 1
        'Next

        'itemNum = 0
        ''리스트를 돌면서 아이템 찾기(Action)
        'For Each a In Change_AddTree.lstAction.Items

        '    strChangeName = Strings.Split(DataGridView1.Item(10, rowNum).Value, " > ")(0)
        '    strChangeName = Strings.Split(strChangeName, "_")(1)

        '    If strChangeName = a Then
        '        Change_AddTree.lstAction.SelectedIndex = itemNum
        '        Exit For
        '    End If
        '    itemNum += 1
        'Next

        'itemNum = 0
        ''리스트를 돌면서 아이템 찾기(sub action)
        'For Each a In Change_AddTree.lstKey.Items

        '    strChangeName = Strings.Split(DataGridView1.Item(10, rowNum).Value, " > ")(1)
        '    strChangeName = Strings.Split(strChangeName, vbLf)(0)

        '    ' 텍스트에 _ 가 여러개 일 경우에 사용 (현재FUnction에 관련된 내용없음 추가 필요)
        '    If Strings.Split(strChangeName, "_").Length > 2 Then
        '        strChangeName = Strings.Split(strChangeName, "_")(1) & "_" & Strings.Split(strChangeName, "_")(2)
        '    Else
        '        strChangeName = Strings.Split(strChangeName, "_")(1)
        '    End If

        '    If strChangeName = a Then
        '        Change_AddTree.lstAction.SelectedIndex = itemNum
        '        Exit For
        '    End If
        '    itemNum += 1
        'Next


        'End If
        'Else

        'End If
    End Sub

    Public Sub listSelectItem()

    End Sub

    ' Excel Export(server)
    Private Sub btnServer_Click(sender As Object, e As EventArgs) Handles btnServer.Click, Label11.Click





















        ''디렉토리검색 부터 검색해서 없으면 생성, 있으면 그폴더에 파일 저장
        'Dim Change As New Change

        '' xml 에서 검증계획서의 폴더경로를 받아와서 strFilePath에 저장
        'Dim XML As New XML
        ''XML.Folder_Path("Random_Change", strFilePath)
        'XML.Folder_Path("Defect", strFilePath)
        ''
        'XML = Nothing


        'blchk = False
        '' strFilePath = ""
        'Dim dirA As DirectoryInfo = New DirectoryInfo(strFilePath)    ' 디렉토리 지정

        ''엑셀 파일이 있는지 확인
        'For Each dra In dirA.GetFiles()     ' For each를 통해 폴더을 찾음
        '    szTemp = dra.Name
        '    If InStr(Trim(szTemp), Trim(strFileName)) And Strings.Left(szTemp, 2) <> "~$" Then  ' Consumer TC와 Kernel TC / Framework TC의 파일 Naming이 다름
        '        szFileName = dra.Name
        '        szMerge = strFilePath + "\" + szFileName
        '        '   InsertData(szMerge, "Server")
        '        'blchk = True
        '        Exit For
        '    End If
        'Next

        'Dim vSQL As String = Nothing
        'Dim strSht As String = "Sheet1"
        'Dim DS As DataSet = New DataSet
        'Dim DA As OleDbDataAdapter = New OleDbDataAdapter
        'Dim vCon As String = Nothing
        'Dim vConn As OleDbConnection
        'Dim Table_selectData As DataTable

        'Dim strExcelFileName As String = Nothing
        'Dim ColumnName() As String = {"ID", "[App Name]", "Feature", "[할당 M/D]", "변경점", "Risk Factor", "[변경점 검증방법]", "TestAction", "SubAction", "검증유형", "Project", "Model", "차수"}
        'Dim strColumns = {"번호", "Project", "Model", "차수", "[App Name]", "Feature", "기능변경점", "기능_RiskFactor", "App변경점", "App_Risk_Factor",
        '        "[변경점 검증방법]", "TestAction", "SubAction", "검증유형", "등록자", "등록시간"}  '16
        'Try
        '    '171023
        '    ' Connect 연결
        '    vCon = "Provider=Microsoft.Ace.OLEDB.12.0;Data Source=" & szMerge & ";Extended Properties=""Excel 12.0;HDR=YES;"""
        '    vConn = New OleDbConnection(vCon)
        '    vConn.Open()

        '    vSQL = "Select * FROM [" & strSht & "$] order by ID desc"

        '    'select문 실행
        '    DA = New OleDbDataAdapter(vSQL, vConn)
        '    DA.Fill(DS, "searchID")
        '    Table_selectData = DS.Tables("searchID")

        '    nID = Table_selectData.Rows.Count + 1

        '    Dim dv_Func As DataView
        '    Dim dv_App As DataView

        '    For i As Integer = 0 To DataGridView1.RowCount - 1


        '        strP = Replace(DataGridView1.Item(1, i).Value, "'", "`")
        '        strM = Replace(DataGridView1.Item(2, i).Value, "'", "`")
        '        strC = Replace(DataGridView1.Item(3, i).Value, "'", "`")
        '        strApp = Replace(DataGridView1.Item(4, i).Value, "'", "`")
        '        strFuncChange = Replace(DataGridView1.Item(6, i).Value, "'", "`")
        '        strFuncRisk = Replace(DataGridView1.Item(7, i).Value, "'", "`")
        '        strAppChange = Replace(DataGridView1.Item(8, i).Value, "'", "`")
        '        strAppRisk = Replace(DataGridView1.Item(9, i).Value, "'", "`")
        '        strDes = Replace(DataGridView1.Item(10, i).Value, "'", "`")
        '        strAction = Replace(DataGridView1.Item(11, i).Value, "'", "`")
        '        strSubAction = Replace(DataGridView1.Item(12, i).Value, "'", "`")
        '        strGu = Replace(DataGridView1.Item(13, i).Value, "'", "`")
        '        strSa = Replace(Split(DataGridView1.Item(2, i).Value, "_")(1), "'", "`")
        '        strCom = Replace(Split(DataGridView1.Item(15, i).Value, "_")(0), "'", "`")
        '        strDate = Replace(Split(DataGridView1.Item(15, i).Value, "_")(1), "'", "`")



        '        'strChange = Replace(strChange, vbLf, "")
        '        'Project, App, Model, 차수, 변경점 기준으로 있는지 확인
        '        dv_Func = New DataView(Table_selectData, "[App Name] ='" & strApp & "' and Project = '" & strP & "' and Model ='" & strM & "' and 차수 = '" & strC & "' and 변경점 = '" & strFuncChange & "'", "[App Name] Asc", DataViewRowState.CurrentRows)
        '        dv_App = New DataView(Table_selectData, "[App Name] ='" & strApp & "' and Project = '" & strP & "' and Model ='" & strM & "' and 차수 = '" & strC & "' and 변경점 = '" & strAppChange & "'", "[App Name] Asc", DataViewRowState.CurrentRows)

        '        '업데이트할 넘버
        '        Dim upNum_Func As Integer
        '        Dim upNum_App As Integer

        '        If dv_Func.Count + dv_App.Count = 0 Then '기능과 앱이 둘다 없을시 추가
        '            'Insert All
        '            InsertData(nID, "App", vConn)
        '            InsertData(nID, "기능", vConn)

        '        ElseIf dv_Func.Count + dv_App.Count = 1 Then
        '            '기능이1 일때 기능은 업데이트 App은 추가
        '            If dv_Func.Count = 1 Then
        '                InsertData(nID, "App", vConn)

        '                upNum_Func = dv_Func.Item(0)(0)
        '                UpdateData(upNum_Func, "기능", vConn)

        '            ElseIf dv_App.Count = 1 Then ' 위와 반대의 경우
        '                InsertData(nID, "기능", vConn)

        '                upNum_App = dv_App.Item(0)(0)
        '                UpdateData(upNum_App, "App", vConn)
        '            End If

        '        ElseIf dv_Func.Count + dv_App.Count = 2 Then        ' App과 기능이 둘다 있을경우 둘다 업데이트

        '            upNum_Func = dv_Func.Item(0)(0)
        '            upNum_App = dv_App.Item(0)(0)

        '            UpdateData(upNum_Func, "기능", vConn)
        '            UpdateData(upNum_App, "App", vConn)
        '        Else
        '            MsgBox("")

        '        End If
        '    Next i

        '    'Connect 해제
        '    vConn.Close()
        '    vConn = Nothing
        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try
        CreateObject("WScript.Shell").Popup("완료되었습니다.", 1, "Q-Portal")

        'Process.Start(strFilePath)
    End Sub

    ' Excel Export 로컬로 내보내기
    Private Sub btnLocal_Click(sender As Object, e As EventArgs) Handles btnLocal.Click, Label12.Click
        'Gridview에 있는 모델과 폼에서 직접 선택한 프로젝트, 모델, 차수가 같은 지 확인

        ' 현재켜져있는 폼중 CHange_Add 가 켜져있으면 그폼의 변수에 아래의 내용들을 보내준다
        'For Each v In Application.OpenForms
        '    If v.name = "Change" Then

        '        strProject = v.strPjt
        '        strModel = v.strModel
        '        strChasu = v.strChasu
        '        strCom = v.strCom
        '        Exit For
        '    End If
        'Next

        '미리보기를 돌면서 한 row의 내용을 붙여넣기
        'For i As Integer = 0 To previewForm.DataGridView1.RowCount - 1
        '    If strProject <> previewForm.DataGridView1.Item(1, i).Value Then
        '        MsgBox("미리보기의 Project와 검증계획의 Project명이 다릅니다. 다시 확인 해 주세요.")
        '        Exit Sub
        '    ElseIf strModel <> previewForm.DataGridView1.Item(2, i).Value Then
        '        MsgBox("미리보기의 Model과 검증계획의 Model이 다릅니다. 다시 확인 해 주세요.")
        '        Exit Sub
        '    ElseIf strChasu <> previewForm.DataGridView1.Item(3, i).Value Then
        '        MsgBox("미리보기의 차수와 검증계획의 차수가 다릅니다. 다시 확인 해 주세요.")
        '        Exit Sub
        '    End If
        'Next


        '선택 되지 않은 항목이 없다면 실행
        '디렉토리검색 부터 검색해서 없으면 생성, 있으면 그폴더에 파일 저장
        Dim Change As New Change

        Dim XML As New XML
        XML.Folder_Path("Random_Change", strFilePath)
        XML = Nothing
        blchk = False


        Label12.Text = "Please Wait..."
        Label12.Enabled = False
        Application.DoEvents()
        Dim SaveFile As New SaveFileDialog
        SaveFile.Filter = "Excel 매크로 통합 문서 files (*.xlsm)|*.xlsm|All files (*.*)|*.*"

        MsgBox("파일명을 바꾸지 마세요. 파일명 변경시 서버업로드 하지말고 로컬에서만 사용 해 주세요.")
        SaveFile.FileName = strModel & "_" & strChasu + ".xlsm"
        'SaveFile.ShowDialog()
        ' SaveFile.


        If SaveFile.ShowDialog = DialogResult.OK Then
            Try
                Dim szFile = "Change_Template.xlsm"
                Dim strFileName = strFilePath & "\" & szFile

                ' Copy the file to a new folder and rename it.
                IO.File.Copy(strFileName, SaveFile.FileName, True)

                'data 저장해줌
                szMerge = IO.Path.GetDirectoryName(SaveFile.FileName)

                ' InsertData(szMerge, "Local")
            Catch ex As Exception
                MsgBox(ex.Message, "열려는 파일이 없습니다." & vbCrLf & strFilePath & "에서 확인 해보세요.")
            End Try
        Else


        End If
        Label12.Text = "로컬로 내보내기"
        Label12.Enabled = True

    End Sub

    Private Sub InsertData(nID As Integer, strFeaChk As String, vConn As OleDbConnection)
        Dim vSQL As String = Nothing
        Dim strSht As String = "Sheet1"
        Dim strChange As String = Nothing
        Dim strRisk As String = Nothing

        '기능인지 앱인지 확인
        If strFeaChk = "기능" Then
            strChange = strFuncChange
            strRisk = strFuncRisk
        ElseIf strFeaChk = "App" Then
            strChange = strAppChange
            strRisk = strAppRisk
        End If

        vSQL = "INSERT INTO [" & strSht & "$] ( ID, [App Name], Feature, 변경점, [Risk Factor], [변경점 검증방법], TestAction, SubAction, 검증유형, Project, Model, 차수, 사업자, 업체명, 파일명, 날짜)" &
                       "VALUES ( " & nID & ", '" & strApp & "', '" & strFeaChk & "', '" & strChange & "', '" & strRisk & "', '" & strDes & "', '" & strAction & "', '" & strSubAction & "', '" & strGu & "', '" &
                          strP & "', '" & strM & "', '" & strC & "', '" & strSa & "', '" & strCom & "', '" & strFileGu & "', '" & strDate & "');"
        DA2 = New OleDbDataAdapter(vSQL, vConn)
        DA2.Fill(DS2)

        nID = nID + 1

    End Sub

    Private Sub UpdateData(nID As Integer, strFeaChk As String, vConn As OleDbConnection)
        Dim vSQL As String = Nothing
        Dim strSht As String = "Sheet1"
        Dim strChange As String = Nothing
        Dim strRisk As String = Nothing

        '앱인지 기능인지 확인하는 부분
        If strFeaChk = "기능" Then
            strChange = strFuncChange
            strRisk = strFuncRisk
        ElseIf strFeaChk = "App" Then
            strChange = strAppChange
            strRisk = strAppRisk
        End If

        vSQL = "UPDATE [" & strSht & "$] Set [날짜] = '" & Now() &
                                "', [변경점] = '" & strChange &
                                    "', [Risk Factor] = '" & strRisk &
                                    "', [변경점 검증방법] = '" & strDes &
                                    "', [TestAction] = '" & strAction &
                                    "', [SubAction] = '" & strSubAction &
                                    "', [검증유형] = '" & strGu &
                                    "', [업체명] = '" & strCom &
                                    "', [파일명] = '" & strFileGu & "'"
        vSQL = vSQL & " where id ='" & nID & "'"

        DA2 = New OleDbDataAdapter(vSQL, vConn)
        DA2.Fill(DS2)

    End Sub

    ' 미리보기의 값을 엑셀에 넣어줌
    'Sub InsertData(szMerge As String, strClickButton As String)

    '    '/////////////////////////////////////////////////////////////////
    '    'SQL Insert 방법으로 하는것 ID입력 관련 수정 후 적용 171019
    '    '템플릿 엑셀 파일의 A2셀에 숫자 형식으로 설정 후 2번행 숨김 처리후 사용(이렇게 하지 않으면 ID가 추가될 떄 10이상 나오지않음)

    '    Dim vSQL As String = Nothing
    '    Dim strSht As String = "Sheet1"
    '    Dim DS As DataSet = New DataSet
    '    Dim DA As OleDbDataAdapter = New OleDbDataAdapter
    '    Dim vCon As String = Nothing
    '    Dim vConn As OleDbConnection
    '    Dim Table_selectData As DataTable
    '    Dim nID As Integer = Nothing
    '    Dim strExcelFileName As String = Nothing
    '    '      Dim ColumnName() As String = {"번호", "Project", "Model", "차수", "[App Name]", "Feature", "변경점", "RiskFactor", "a", "a", "[변경점 검증방법]", "검증유형", "업체명", "등록자", "등록시간"}
    '    Dim strColumns = {"번호", "Project", "Model", "차수", "[App Name]", "Feature", "기능변경점", "기능_RiskFactor", "App변경점", "App_Risk_Factor",
    '            "[변경점 검증방법]", "TestAction", "SubAction", "검증유형", "등록자", "등록시간"}  '16
    '    Try
    '        '171023
    '        ' Connect 연결
    '        vCon = "Provider=Microsoft.Ace.OLEDB.12.0;Data Source=" & szMerge & ";Extended Properties=""Excel 12.0;HDR=YES;"""
    '        vConn = New OleDbConnection(vCon)
    '        vConn.Open()

    '        vSQL = "Select ID FROM [" & strSht & "$] order by ID desc"

    '        'select문 실행
    '        DA = New OleDbDataAdapter(vSQL, vConn)
    '        DA.Fill(DS, "searchID")
    '        Table_selectData = DS.Tables("searchID")

    '        If Table_selectData.Rows.Count <> 0 And Table_selectData.Rows(0)(0).ToString <> "" Then
    '            nID = Table_selectData.Rows(0)(0).ToString
    '            nID = nID + 1
    '        Else
    '            nID = 1
    '        End If

    '        Table_selectData.Clear()

    '        'Connect 해제
    '        vConn.Close()
    '        vConn = Nothing

    '        For i As Integer = 0 To DataGridView1.RowCount - 1
    '            ' Connect 연결
    '            'vCon = "Provider=Microsoft.Ace.OLEDB.12.0;Data Source=" & strExcelFileName & ";Extended Properties=""Excel 12.0;HDR=YES;"""
    '            vConn = New OleDbConnection(vCon)
    '            vConn.Open()

    '            'Select문 을 위한 조건 (원하는 조건이 있는지 검색)
    '            vSQL = "Select * FROM [" & strSht & "$] where Project ='" & DataGridView1.Item(1, i).Value & "' "
    '            For x As Integer = 2 To 12
    '                If x = 2 Or x = 3 Or x = 4 Or x = 10 Or x = 11 Or x = 12 Then
    '                    vSQL = vSQL & "and " & strColumns(x) & "= '" & DataGridView1.Item(x, i).Value & "' "
    '                    'ElseIf x = 13 Then
    '                    '  vSQL = vSQL & "and " & ColumnName(9) & "= '" & DataGridView1.Item(x, i).Value & "' "
    '                    'ElseIf x = 15 Then

    '                    '    Dim strTemp As String = DataGridView1.Item(x, i).Value
    '                    '    strTemp = Split(strTemp, "_")(0)
    '                    '    vSQL = vSQL & "and " & ColumnName(10) & "= '" & strTemp & "' "
    '                    'Else

    '                End If
    '            Next

    '            DS.Clear()
    '            'select문 실행
    '            DA = New OleDbDataAdapter(vSQL, vConn)
    '            DA.Fill(DS, "selectData")
    '            Table_selectData = DS.Tables("selectData")

    '            'Connect 해제
    '            vConn.Close()
    '            vConn = Nothing

    '            ' 원하는 조건이 없을 시 추가
    '            If Table_selectData.Rows.Count = 0 Then

    '                '추가
    '                'vSQL = "Select * FROM [" & strSht & "$] order by ID desc "
    '                'DS.Clear()
    '                ''select문 실행
    '                'DA = New OleDbDataAdapter(vSQL, vConn)
    '                'DA.Fill(DS, "selectData")
    '                'Table_selectData = DS.Tables("selectData")

    '                'nID = Table_selectData.Rows(0)(0) + 1
    '                'Dim strFuncChange As String = Nothing
    '                'Dim strFuncRisk As String = Nothing
    '                'Dim strAppChange As String = Nothing
    '                'Dim strAppRisk As String = Nothing
    '                'Dim strDes As String = Nothing
    '                'Dim strGu As String = Nothing
    '                'Dim strCom As String = Nothing
    '                'Dim strFileGu As String = "Q-Portal 검증계획서"
    '                'Dim strApp As String = Nothing
    '                'Dim strFea As String = Nothing
    '                'Dim strP, strM, strC As String
    '                'Dim strSa As String
    '                'Dim strDate As String
    '                'Dim strAction As String
    '                'Dim strSubAction As String

    '                'strP = Replace(DataGridView1.Item(1, i).Value, "'", "`")
    '                'strM = Replace(DataGridView1.Item(2, i).Value, "'", "`")
    '                'strC = Replace(DataGridView1.Item(3, i).Value, "'", "`")
    '                'strApp = Replace(DataGridView1.Item(4, i).Value, "'", "`")
    '                'strFuncChange = Replace(DataGridView1.Item(6, i).Value, "'", "`")
    '                'strFuncRisk = Replace(DataGridView1.Item(7, i).Value, "'", "`")
    '                'strAppChange = Replace(DataGridView1.Item(8, i).Value, "'", "`")
    '                'strAppRisk = Replace(DataGridView1.Item(9, i).Value, "'", "`")
    '                'strDes = Replace(DataGridView1.Item(10, i).Value, "'", "`")
    '                'strAction = Replace(DataGridView1.Item(11, i).Value, "'", "`")
    '                'strSubAction = Replace(DataGridView1.Item(12, i).Value, "'", "`")
    '                'strGu = Replace(DataGridView1.Item(13, i).Value, "'", "`")
    '                'strSa = Replace(Split(DataGridView1.Item(2, i).Value, "_")(1), "'", "`")
    '                'strCom = Replace(Split(DataGridView1.Item(15, i).Value, "_")(0), "'", "`")
    '                'strDate = Replace(Split(DataGridView1.Item(15, i).Value, "_")(1), "'", "`")
    '                vConn = New OleDbConnection(vCon)
    '                vConn.Open()

    '                For j As Integer = 0 To 1
    '                    If j = 0 Then
    '                        vSQL = "INSERT INTO [" & strSht & "$] ( ID, [App Name], Feature, 변경점, [Risk Factor], [변경점 검증방법], TestAction, SubAction, 검증유형, Project, Model, 차수, 사업자, 업체명, 파일명, 날짜)" &
    '                   "VALUES ( " & nID & ", '" & strApp & "', '" & "기능" & "', '" & strFuncChange & "', '" & strFuncRisk & "', '" & strDes & "', '" & strAction & "', '" & strSubAction & "', '" & strGu & "', '" &
    '                   strP & "', '" & strM & "', '" & strC & "', '" & strSa & "', '" & strCom & "', '" & strFileGu & "', '" & strDate & "');"
    '                    ElseIf j = 1 Then
    '                        vSQL = "INSERT INTO [" & strSht & "$] ( ID, [App Name], Feature, 변경점, [Risk Factor], [변경점 검증방법],TestAction, SubAction, 검증유형, Project, Model, 차수, 사업자, 업체명, 파일명, 날짜)" &
    '            "VALUES ( " & nID & ", '" & strApp & "', '" & "App" & "', '" & strAppChange & "', '" & strAppRisk & "', '" & strDes & "', '" & strAction & "', '" & strSubAction & "', '" & strGu & "', '" &
    '            strP & "', '" & strM & "', '" & strC & "', '" & strSa & "', '" & strCom & "', '" & strFileGu & "', '" & strDate & "');"
    '                    End If


    '                    Dim DA2 = New OleDbDataAdapter(vSQL, vConn)
    '                    DA2.Fill(DS)
    '                    nID = nID + 1
    '                Next

    '                'vSQL = "INSERT INTO [" & strSht & "$] ( ID, App Name, Feature, 변경점, [Risk Factor], [변경점 검증방법], 검증유형, Project, Model, 차수, 사업자, 업체명, 파일명, 날짜)" &
    '                '    "VALUES ( " & nID & ", '"


    '                'For j As Integer = 1 To 14
    '                '    vSQL = vSQL + Replace(DataGridView1.Item(j, i).Value, "'", "`") & "','"
    '                'Next
    '                'vSQL = vSQL + Replace(DataGridView1.Item(15, i).Value, "'", "`") & "');"



    '                'Connect 해제
    '                vConn.Close()
    '                vConn = Nothing


    '                ' 원하는 조건이 있으면 업데이트 여부를 물은 후 업데이트 or 넘어감
    '            ElseIf Table_selectData.Rows.Count >= 1 Then
    '                '수정ㅣ
    '                If MessageBox.Show(DataGridView1.Item(0, i).Value & "번의 내용이 이미 엑셀 파일에 있습니다. 기존의 내용을 새로 Update 하시겠습니까?", "Title", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
    '                    Dim num As Integer = 0
    '                    Dim strchange As String = Nothing
    '                    Dim strRisk As String = Nothing
    '                    Dim strDes As String = Nothing
    '                    Dim strGu As String = Nothing
    '                    Dim strCom As String = Nothing
    '                    Dim strAction As String = Nothing
    '                    Dim strSubAction As String = Nothing
    '                    Dim strFileGu As String = "Q-Portal 검증계획서"

    '                    vConn = New OleDbConnection(vCon)
    '                    vConn.Open()

    '                    For Each a In Table_selectData.Rows
    '                        If a.item(2).ToString = "기능" Then

    '                            strchange = Replace(DataGridView1.Item(6, i).Value, "'", "`")
    '                            strRisk = Replace(DataGridView1.Item(7, i).Value, "'", "`")
    '                            strDes = Replace(DataGridView1.Item(10, i).Value, "'", "`")
    '                            strAction = Replace(DataGridView1.Item(11, i).Value, "'", "`")
    '                            strSubAction = Replace(DataGridView1.Item(12, i).Value, "'", "`")
    '                            strGu = Replace(DataGridView1.Item(13, i).Value, "'", "`")
    '                            strCom = Replace(Split(DataGridView1.Item(15, i).Value, "_")(0), "'", "`")

    '                        ElseIf a.item(2).ToString = "App" Then
    '                            strchange = Replace(DataGridView1.Item(8, i).Value, "'", "`")
    '                            strRisk = Replace(DataGridView1.Item(9, i).Value, "'", "`")
    '                            strDes = Replace(DataGridView1.Item(10, i).Value, "'", "`")
    '                            strAction = Replace(DataGridView1.Item(11, i).Value, "'", "`")
    '                            strSubAction = Replace(DataGridView1.Item(12, i).Value, "'", "`")
    '                            strGu = Replace(DataGridView1.Item(13, i).Value, "'", "`")
    '                            strCom = Replace(Split(DataGridView1.Item(15, i).Value, "_")(0), "'", "`")

    '                        End If
    '                        vSQL = "UPDATE [" & strSht & "$] Set [날짜] = '" & Replace(Split(DataGridView1.Item(15, i).Value, "_")(1).ToString, "'", "`") &
    '                            "', [변경점] = '" & strchange &
    '                            "', [Risk Factor] = '" & strRisk &
    '                            "', [변경점 검증방법] = '" & strDes &
    '                            "', [TestAction] = '" & strAction &
    '                            "', [SubAction] = '" & strSubAction &
    '                            "', [검증유형] = '" & strGu &
    '                            "', [업체명] = '" & strCom &
    '                            "', [파일명] = '" & strFileGu & "'"
    '                        vSQL = vSQL & " where id ='" & Table_selectData.Rows(num)(0).ToString & "'"


    '                        Dim DA2 = New OleDbDataAdapter(vSQL, vConn)
    '                        DA2.Fill(DS)
    '                        num += 1
    '                    Next


    '                    'Connect 해제
    '                    vConn.Close()
    '                    vConn = Nothing
    '                Else
    '                    ''Connect 해제
    '                    'vConn.Close()
    '                    'vConn = Nothing
    '                    'Exit Sub
    '                End If
    '            End If
    '        Next

    '        CreateObject("WScript.Shell").Popup("완료되었습니다.", 1, "Q-Portal")

    '        Process.Start(strFilePath)
    '        ' MsgBox("끝")

    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    End Try
    'End Sub



    'Public Sub chkView_Click(sender As Object, e As EventArgs) Handles chkView.Click

    '    Change_AddTree.chkView_Click(sender, e)

    'End Sub

    'Public Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click, Label11.Click
    '    Change_AddTree.Button2_Click(sender, e)
    'End Sub

    'Public Sub btnLocal_Click(sender As Object, e As EventArgs) Handles btnLocal.Click, Label12.Click
    '    Change_AddTree.btnLocal_Click(sender, e)
    'End Sub

    'Public Sub btnLoad_Click_1(sender As Object, e As EventArgs) Handles btnLoad.Click, Label13.Click
    '    Change_AddTree.btnLocal_Click(sender, e)
    'End Sub



End Class