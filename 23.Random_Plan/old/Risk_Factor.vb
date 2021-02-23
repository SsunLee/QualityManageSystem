Imports System.Data
Imports System.Data.OleDb
Imports System.Windows.Forms

Public Class Risk_Factor
    Public strProject As String = Nothing
    Public strModel As String = Nothing
    Public strChasu As String = Nothing
    Public szMerge As String = Nothing
    Public Table_Tip As DataTable = Nothing
    Public dt_search As DataTable = Nothing

    '콤보박스에 중복을 제거하고 아이템을 추가 해주는 함수
    Sub Combo_Add_Items(ByVal cbName As ComboBox, ByVal num As Integer, ByVal i As Integer, ByVal dt As DataTable)
        If Not cbName.Items.Contains(Trim(dt.Rows(i)(num).ToString())) _
                        And Trim(dt.Rows(i)(num).ToString()) <> "" And Trim(dt.Rows(i)(num).ToString()) <> "-" Then  ' 중복 없이 Item 추가
            cbName.Items.Add(Trim(dt.Rows(i)(num).ToString()))
        End If
    End Sub
    Private Sub Risk_Factor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label2.Text = strProject & "/" & strModel & "/" & strChasu
        Icon = My.Resources.Qportal_Icon
        '기본검증에서 App만 가져옴
        Dim dt_App As DataTable = Table_Tip.DefaultView.ToTable(True, New String("App"))
        For i As Integer = 0 To dt_App.Rows.Count - 1
            Combo_Add_Items(cbApp, 0, i, dt_App)
        Next

        '변경점 리스트에 추가
        For i As Integer = 0 To dt_search.Rows.Count - 1    ' Data table Row 만큼 반복 -1은 마지막행은 Null
            Try
                '중복없이 리스트 추가
                If Not lst1.Items.Contains(dt_search.Rows(i)(0).ToString()) AndAlso LTrim(dt_search.Rows(i)(0).ToString()) <> "" AndAlso LTrim(dt_search.Rows(i)(0).ToString()) <> "-" Then
                    lst1.Items.Add(LTrim(dt_search.Rows(i)(0).ToString()))
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Next
    End Sub


    Private Sub lst1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lst1.SelectedIndexChanged
        Try
            Dim nCnt As Integer = 0

            txt1.Text = ""

            'Table_Word.Rows(i)(6).ToString()
            For i As Integer = 0 To dt_search.Rows.Count - 1    ' Data table Row 만큼 반복 -1은 마지막행은 Null

                If lst1.Text = Trim(dt_search.Rows(i)(0).ToString()) Then ' 내가 선택한 앱명과 같은 DB의 앱 이라면
                    Try
                        Dim strTextCom = dt_search.Rows(i)(1).ToString()
                        txt1.Text = Replace(strTextCom, Chr(10), Chr(13) & Chr(10))
                        'risk factor
                        'strTextCom = dt_search.Rows(i)(2).ToString()
                        'strRisk = Replace(strTextCom, Chr(10), Chr(13) & Chr(10))

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
        If txtRisk.Text <> "" Then
            txtRisk.Text = txtRisk.Text & vbCrLf
        End If
        txtRisk.Text = txtRisk.Text & "[" & lst1.Text & "]" & vbCrLf
    End Sub

    Private Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click


        '선택 되지 않은 항목이 없다면 실행
        '디렉토리검색 부터 검색해서 없으면 생성, 있으면 그폴더에 파일 저장
        Dim Change As New Change
        Dim strFilePath As String = Nothing

        Dim XML As New XML
        XML.Folder_Path("Random_Change", strFilePath)
        XML = Nothing
        '  blchk = False


        btnExport.Text = "Please Wait..."
        btnExport.Enabled = False

        Application.DoEvents()
        Dim SaveFile As New SaveFileDialog
        SaveFile.Filter = "Excel 매크로 통합 문서 files (*.xlsm)|*.xlsm|All files (*.*)|*.*"

        MsgBox("파일명을 바꾸지 마세요. " & vbCrLf & "파일명 변경시 서버업로드 하지말고 로컬에서만 사용 해 주세요.")
        SaveFile.FileName = strModel & "_" & strChasu + ".xlsm"
        'SaveFile.ShowDialog()
        ' SaveFile.


        If SaveFile.ShowDialog = DialogResult.OK Then
            Try
                Dim szFile = "Template.xlsm"
                Dim strFileName = strFilePath & "\" & szFile

                ' Copy the file to a new folder and rename it.
                IO.File.Copy(strFileName, SaveFile.FileName, True)

                'data 저장해줌
                szMerge = IO.Path.GetDirectoryName(SaveFile.FileName)

                InsertData(szMerge, "Local")
            Catch ex As Exception
                MsgBox(ex.Message, "열려는 파일이 없습니다." & vbCrLf & strFilePath & "에서 확인 해보세요.")
            End Try
        Else


        End If
        btnExport.Text = "App Risk Export"
        btnExport.Enabled = True


    End Sub
    ' 미리보기의 값을 엑셀에 넣어줌
    Sub InsertData(szMerge As String, strClickButton As String)

        '/////////////////////////////////////////////////////////////////
        'SQL Insert 방법으로 하는것 ID입력 관련 수정 후 적용 171019
        '템플릿 엑셀 파일의 A2셀에 숫자 형식으로 설정 후 2번행 숨김 처리후 사용(이렇게 하지 않으면 ID가 추가될 떄 10이상 나오지않음)

        'Dim vSQL As String = Nothing
        'Dim strSht As String = "Sheet1"
        'Dim DS3 As DataSet = New DataSet
        'Dim DA3 As OleDbDataAdapter = New OleDbDataAdapter
        'Dim vCon As String = Nothing
        'Dim vConn3 As OleDbConnection
        'Dim Table_selectData As DataTable
        'Dim nID As Integer = Nothing
        'Dim strExcelFileName As String = Nothing
        'Dim ColumnName() As String = {"Model", "차수", "변경점", "변경점내용", "Risk_Factor", "기본검증", "검증방법", "구분", "AppName", "Feature", "Feature_Des", "TestAction", "검증유형", "등록자"}

        'If strClickButton = "Server" Then
        '    strExcelFileName = szMerge + "\" + strModel + ".xlsm"
        'Else
        '    strExcelFileName = szMerge + "\" + strModel + "_" + strChasu + ".xlsm"
        'End If

        'Try
        '    '171023
        '    ' Connect 연결
        '    vCon = "Provider=Microsoft.Ace.OLEDB.12.0;Data Source=" & strExcelFileName & ";Extended Properties=""Excel 12.0;HDR=YES;"""
        '    vConn3 = New OleDbConnection(vCon)
        '    vConn3.Open()

        '    vSQL = "Select ID FROM [" & strSht & "$] order by ID desc"
        '    'select문 실행
        '    DA3 = New OleDbDataAdapter(vSQL, vConn3)
        '    DA3.Fill(DS3, "searchID")
        '    Table_selectData = DS3.Tables("searchID")

        '    If Table_selectData.Rows.Count <> 0 And Table_selectData.Rows(0)(0).ToString <> "" Then
        '        nID = Table_selectData.Rows(0)(0).ToString
        '        nID = nID + 1
        '    Else
        '        nID = 1
        '    End If

        '    Table_selectData.Clear()

        '    'Connect 해제
        '    vConn3.Close()
        '    vConn3 = Nothing

        '    For i As Integer = 0 To DataGridView1.RowCount - 1
        '        ' Connect 연결
        '        vCon = "Provider=Microsoft.Ace.OLEDB.12.0;Data Source=" & strExcelFileName & ";Extended Properties=""Excel 12.0;HDR=YES;"""
        '        vConn3 = New OleDbConnection(vCon)
        '        vConn3.Open()


        '        'Select문 을 위한 조건 (원하는 조건이 있는지 검색)
        '        vSQL = "Select * FROM [" & strSht & "$] where Project ='" & DataGridView1.Item(1, i).Value & "' "
        '        For x As Integer = 1 To 14
        '            If x = 5 Or x = 6 Or x = 7 Then
        '            Else
        '                vSQL = vSQL & "and " & ColumnName(x - 1) & "= '" & DataGridView1.Item(x + 1, i).Value & "'"
        '            End If
        '        Next

        '        DS3.Clear()
        '        'select문 실행
        '        DA3 = New OleDbDataAdapter(vSQL, vConn3)
        '        DA3.Fill(DS3, "selectData")
        '        Table_selectData = DS3.Tables("selectData")

        '        ' 원하는 조건이 없을 시 추가
        '        If Table_selectData.Rows.Count = 0 Then

        '            '추가
        '            'vSQL = "Select * FROM [" & strSht & "$] order by ID desc "
        '            'DS3.Clear()
        '            ''select문 실행
        '            'DA3 = New OleDbDataAdapter(vSQL, vConn3)
        '            'DA3.Fill(DS3, "selectData")
        '            'Table_selectData = DS3.Tables("selectData")

        '            'nID = Table_selectData.Rows(0)(0) + 1

        '            vSQL = "INSERT INTO [" & strSht & "$] ( ID, Project, Model, 차수, 변경점, 변경점내용, Risk_Factor, 기본검증, 검증방법, 구분, AppName, Feature, Feature_Des, TestAction, 검증유형, 등록자, 등록시간) " & "VALUES ( " & nID & ", '"
        '            For j As Integer = 1 To 15
        '                vSQL = vSQL + Replace(DataGridView1.Item(j, i).Value, "'", "''") & "','"
        '            Next
        '            vSQL = vSQL + Replace(DataGridView1.Item(16, i).Value, "'", "''") & "');"

        '            DA2 = New OleDbDataAdapter(vSQL, vConn3)
        '            DA2.Fill(DS3)

        '            'Connect 해제
        '            vConn3.Close()
        '            vConn3 = Nothing

        '            nID = nID + 1
        '            ' 원하는 조건이 있으면 업데이트 여부를 물은 후 업데이트 or 넘어감
        '        ElseIf Table_selectData.Rows.Count = 1 Then
        '            '수정ㅣ
        '            If MessageBox.Show(DataGridView1.Item(0, i).Value & "번의 내용이 이미 엑셀 파일에 있습니다. Risk_Factor, 기본검증, 검증방법을 새로 Update 하시겠습니까?", "Title", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then

        '                vSQL = "UPDATE [" & strSht & "$] Set  [등록시간] = '" & Replace(DataGridView1.Item(16, i).Value, "'", "''") & "' , [Risk_Factor] = '" & Replace(DataGridView1.Item(6, i).Value, "'", "''") &
        '                    "',[기본검증] = '" & Replace(DataGridView1.Item(7, i).Value, "'", "''") & "',[검증방법] = '" & Replace(DataGridView1.Item(8, i).Value, "'", "''") & "'"
        '                vSQL = vSQL & " where id = " & Table_selectData.Rows(0)(0).ToString

        '                DA2 = New OleDbDataAdapter(vSQL, vConn3)
        '                DA2.Fill(DS3)

        '                'Connect 해제
        '                vConn3.Close()
        '                vConn3 = Nothing
        '            Else
        '                'Exit Sub
        '            End If
        '        End If
        '    Next

        '    MsgBox("끝")

        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try
    End Sub
End Class