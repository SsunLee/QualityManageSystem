
Imports System.Data
Imports System.Data.OleDb
Imports System.Windows.Forms

Public Class TD_DATA_FORM
    Public Change_Add_Tree As New Change_Add_Tree

#Region "★[처음 로드 될 때]★"
    Private Sub TD_dataLoad(sender As Object, e As EventArgs) Handles MyBase.Load
        Panel2.AllowDrop = True
        Icon = My.Resources.Qportal_Icon

        DataGridView1.Visible = False

        With la_DragOver
            .Font = New System.Drawing.Font("맑은 고딕", 12, System.Drawing.FontStyle.Bold)
            '.ForeColor = Color.Gray
            .ForeColor = System.Drawing.Color.FromArgb(125, 125, 125)
            .Text = "Attach File with drag and drop in anywhere" & Environment.NewLine & "이곳에 파일을 드래그 하세요."
        End With
    End Sub
#End Region

#Region "  [엑셀 업로드 기능]"

    '# 폼에 마우스 가져다 댔을 때
    Private Sub UploadExcel_DragEnter(sender As Object, e As System.Windows.Forms.DragEventArgs) Handles Panel2.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then ' 만약 갖다대는게 파일일 경우
            e.Effect = DragDropEffects.Copy
        End If
    End Sub
    Private Sub UploadExcel_DragDrop(sender As Object, e As System.Windows.Forms.DragEventArgs) Handles Panel2.DragDrop

        DataGridView1.Visible = True
        Dim blCheck As Boolean = False
        '# DragDrop 시 DragEventArgs를 통해 Data를 받아 온다. 
        Dim files() As String = e.Data.GetData(DataFormats.FileDrop)
        '# Array 형식으로 저장 된 것을 난 파일 하나만 허용 할 거기 때문에 
        Dim path As String = files(0)

        Dim strExtension As String = Nothing
        Dim fi As New IO.FileInfo(path)

        '# 확장자 알아내기
        strExtension = fi.Extension

        If strExtension <> ".xlsx" Then
            MessageBox.Show("확장자가 ""xlsx"" 인 엑셀 파일만 올려주세요. ", "lee.sunbae@lgepartner.com", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        '# 2. [Excel File to DataGridView]
        blCheck = Excel_File_to_DataGridView(path)

        If DialogResult.Yes = MessageBox.Show("바로 결과를 올리시겠습니까?" &
                                              Environment.NewLine & "바로 DB에 올리려면 ""예""" &
                                              Environment.NewLine & "확인 하고 올리려면 ""아니오""를 누르세요.",
                                              "lee.sunbae@lgepartner.com", MessageBoxButtons.YesNo, MessageBoxIcon.Information) Then

            '# 만약 '예'를 눌렀다면 (만약 바로 올릴거면)
            'Console.WriteLine(Environment.MachineName)

            Dim dt As New DataTable()
            dt = TryCast(DataGridView1.DataSource, DataTable)   ' DataGridView에 있는 자료를 Datatable로 옮김 

            Dim PassResult As String = Nothing

            PassResult = Database_Update(dt)
            MessageBox.Show(PassResult,
                                        "lee.sunbae@lgepartner.com",
                                                MessageBoxButtons.OK, MessageBoxIcon.Information)
            Close()
        Else

        End If

        If blCheck = False Then
            MessageBox.Show("올바른 파일을 올려주세요.")
        End If

    End Sub

#End Region

#Region "# 2. [File to DataGridView]"

    Private Function Excel_File_to_DataGridView(ByRef path As String) As Boolean

        Dim vConn As OleDbConnection = New OleDbConnection
        Dim DS As DataSet = New DataSet
        Dim myCmd As OleDbDataAdapter = New OleDbDataAdapter

        '# Excel 을 Database로 인식하도록 Connection String 생성
        vConn = New OleDbConnection("Provider=Microsoft.Ace.OLEDB.12.0;Data Source=" & path & ";Extended Properties=""Excel 12.0;HDR=YES;""")
        vConn.Open()
        '# Connection 
        Dim dt As DataTable = New DataTable
        '# Get Sheet Name 
        dt = vConn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, New Object() {Nothing, Nothing, Nothing, "TABLE"})

        Dim table_name As String = Nothing

        Try '# Sheet명 꺼내기
            table_name = dt.Rows(0).Item("Table_Name")
        Catch ex As Exception
            MessageBox.Show(ex.Message, "(Sunbae) - 시트가 없습니다.", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        '# DB 연결할 때 
        Try
            myCmd = New OleDbDataAdapter("Select * FROM [" & table_name & "]", vConn)
        Catch ex As Exception
            MessageBox.Show(ex.Message & Environment.NewLine & "시트명 및 DB연결 문제", "lee.sunbae@lgepartner.com", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Try
            DS = New DataSet
            myCmd.Fill(DS)      '# DataSet에 엑셀에 있는 내용 모두 담음(조회 된 Query)

            '# DataGridView에 Dataset Table 내용을 바인딩하여 넣음
            DataGridView1.DataSource = DS.Tables(0)
            Excel_File_to_DataGridView = True

        Catch ex As Exception
            Diagnostics.Debug.Print(ex.Message)
        Finally
            vConn.Close()
        End Try

        Return Excel_File_to_DataGridView

    End Function

#End Region
#Region "# 3. [DataGridView To Database]"
    Private Function Database_Update(ByRef dt As DataTable) As String

        Dim sGubun As String = Nothing : Dim sMajorChange As String = Nothing
        Dim sChangeContents As String = Nothing : Dim sRisk As String = Nothing
        Dim sTestType As String = Nothing : Dim sTestTypeContents As String = Nothing
        Dim sProject As String = Nothing : Dim sModel As String = Nothing
        Dim sCompany As String = Nothing : Dim sRequester As String = Nothing
        Dim sTCCheckbox As String = Nothing : Dim sTCName As String = Nothing

        ' 기존 Data 있는지 Check 하기 위한 Query 작성
        Dim vSQL As String = Nothing

        Dim nCnt_insert As Integer = 0
        Dim nCnt_update As Integer = 0

        Dim DA As OleDbDataAdapter = New OleDbDataAdapter
        Dim vConn = New OleDbConnection(Change_Add_Tree.strCon)   ' MainForm의 Connection String으로 DB Connect

        '# DB Open
        Try
            vConn.Open()
        Catch ex As Exception
            MessageBox.Show(ex.Message & Environment.NewLine & "(Sunbae) - DB Open 에러", "lee.sunbae@lgepartner.com", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        '# Connection 
        Dim dt_temp As DataTable = New DataTable
        '# Get Sheet Name 
        dt_temp = vConn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, New Object() {Nothing, Nothing, Nothing, "TABLE"})

        Dim table_name As String = Nothing

        Try '# Sheet명 꺼내기
            'table_name = dt_temp.Rows(0).Item("Table_Name")
            table_name = "TD_Data"
        Catch ex As Exception
            MessageBox.Show(ex.Message, "(Sunbae) - 시트가 없습니다.", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Try

            For i As Integer = 0 To dt.Rows.Count - 1

                '# 내용 DBNull 처리
                Dim strData As String(,) = Nothing

                ReDim strData(dt.Rows.Count, dt.Columns.Count)

                'Diagnostics.Debug.Print(dt.Rows(i).Item(1))
                For rr As Integer = 0 To dt.Columns.Count - 1
                    System.Diagnostics.Debug.Print(dt.Rows(i).Item(rr))
                    strData(i, rr) = IIf(IsDBNull(dt.Rows(i).Item(rr)), " ", dt.Rows(i).Item(rr))
                    strData(i, rr) = Replace(dt.Rows(i).Item(rr), "'", "")
                    strData(i, rr) = LTrim(dt.Rows(i).Item(rr))
                Next
            Next
            '    '# 만들어 둔 함수를 통해서 회사이름과 개인 컴퓨터 이름 가져옴
            '    Dim v As String = getUserName() : Dim c As String = getCompany(v)
            '    sCompany = c : sRequester = v
            '    sCompany = LTrim(sCompany) : sRequester = LTrim(sRequester)

            '    '# 쿼리로 업체명과 사용자 이름이 있는지 없는지 중복인지 아닌지 체크;; 근데 안쓸 듯;;
            '    Dim vName As String = " AND [등록자] = '" & Replace(sRequester, "'", "''") & "'"
            '    Dim vComp As String = " AND [업체명] = '" & Replace(sCompany, "'", "''") & "'"

            '    Dim longDID As String = dt.Rows(i).Item(0)   '# defect id
            '    Dim vSQL_DID As String = " [Defect_ID] = '" & Replace(longDID, "'", "''") & "'"

            '    'Diagnostics.Debug.Print(vSQL_DID)

            '    Dim sql As String = Nothing
            '    sql = "SELECT Defect_ID "
            '    sql = sql & "FROM [" & table_name & "] "
            '    sql = sql & "where" & vSQL_DID

            '    ' Diagnostics.Debug.Print(sql)

            '    Dim myCmd As OleDbCommand
            '    Dim check As Integer

            '    Dim result As DataTable = New DataTable
            '    Dim cmd As OleDbCommand = New OleDbCommand(sql, vConn)
            '    '     ▼▼ Data Adapter를 사용해 Data Table을 만들고 Query 된 Result를 Count 하여 기존 Data가 있는지 Check 
            '    Dim adapter As OleDbDataAdapter = New OleDbDataAdapter(cmd)
            '    adapter.Fill(result)

            '    '  ▼▼  만약 조회가 안 됐다면 ?  새 항목
            '    If result.Rows.Count = 0 Then
            '        ' is it insert
            '        sql = "INSERT INTO TD_Data "
            '        sql = sql & " (Defect_ID, Detailed_Function, Detailed_Symptom, Model, Detected_in_Version, "
            '        sql = sql & " Detected_in_Step, Detected_on_Date, Priority_TD, Reproducible, Summary,"
            '        sql = sql & " Status_TD, Detected_FullName, TE_Function, Issue_Definition, App_Name, "
            '        sql = sql & " Defect_Category, Group_Name, Run_Test, DEV_Function, DEV_Defect_Category,"
            '        sql = sql & " QM_Function, TC_ID, Description_TD, 등록자" & ") "
            '        sql = sql & "values('"
            '        sql = sql & longDID + "','" + dt.Rows(i).Item(1) + "','" + dt.Rows(i).Item(2) + "','" + dt.Rows(i).Item(3) + "','" + dt.Rows(i).Item(4) + "','"
            '        sql = sql & dt.Rows(i).Item(5) + "','" + dt.Rows(i).Item(6) + "','" + dt.Rows(i).Item(7) + "','" + dt.Rows(i).Item(8) + "','" + dt.Rows(i).Item(9) + "','"
            '        sql = sql & dt.Rows(i).Item(10) + "','" + dt.Rows(i).Item(11) + "','" + dt.Rows(i).Item(12) + "','" + dt.Rows(i).Item(13) + "','" + dt.Rows(i).Item(14) + "','"
            '        sql = sql & dt.Rows(i).Item(15) + "','" + dt.Rows(i).Item(16) + "','" + dt.Rows(i).Item(17) + "','" + dt.Rows(i).Item(18) + "','" + dt.Rows(i).Item(19) + "','"
            '        sql = sql & dt.Rows(i).Item(20) + "','" + dt.Rows(i).Item(21) + "','" + dt.Rows(i).Item(22) + "','" + sRequester + "');"


            '        Diagnostics.Debug.Print(sql)
            '        myCmd = New OleDbCommand(sql, vConn)
            '        check = myCmd.ExecuteNonQuery()
            '        nCnt_insert += 1

            '    Else '◀◀ 기존 데이터와 덮어쓰기 해야 한다면

            '        sql = "UPDATE SW_Validation_Result SET "
            '        sql = sql & "[구분] ='" & sGubun & "', "
            '        sql = sql & "주요변경점 ='" & sMajorChange & "', "
            '        sql = sql & "변경점내용 ='" & sChangeContents & "', "
            '        sql = sql & "Risk ='" & sRisk & "', "
            '        sql = sql & "검증유형 ='" & sTestType & "', "
            '        sql = sql & "검증유형내용 ='" & sTestType & "', "
            '        sql = sql & "TC진행여부 ='" & sTCCheckbox & "', "
            '        sql = sql & "TC명 ='" & sTCName & "', "
            '        sql = sql & "업체명 ='" & sCompany & "', "
            '        sql = sql & "등록자 ='" & sRequester & "' "
            '        sql = sql & " WHERE ID = " & result.Rows(0)(0).ToString()
            '        'Debug.Print(sql)

            '        myCmd = New OleDbCommand(sql, vConn)
            '        check = myCmd.ExecuteNonQuery()
            '        nCnt_update += 1
            '    End If

            'Next

        Catch ex As Exception
            Database_Update = True
            Diagnostics.Debug.Print(ex.Message)
        Finally
            'Diagnostics.Debug.Print("업체명 : " & sCompany)
            'Diagnostics.Debug.Print("작성자 : " & sRequester)

        End Try

        vConn.Close()

        Database_Update =
            "총 : " & nCnt_insert + nCnt_update & Environment.NewLine &
            "추가 됨 : " & nCnt_insert & Environment.NewLine &
            "수정 됨 : " & nCnt_update


        Return Database_Update
    End Function

#End Region


#Region "★ get User Name ★"
    Private Function getUserName() As String

        Dim strCom As String = "."
        Dim strName As String = Nothing
        Dim obj = GetObject("winmgmts:{impersonationLevel=impersonate}!\\" & strCom & "\root\cimv2").ExecQuery("Select * FROM Win32_OperatingSystem")
        For Each Obj2 In obj
            strName = Obj2.Description
        Next
        getUserName = Strings.Split(strName, "/")(0)

        Return getUserName

    End Function

    Private Function getCompany(ByRef User As String) As String
        Dim FindCompany As String = Nothing
        Dim vConn As OleDbConnection = New OleDbConnection
        Dim DS As DataSet = New DataSet
        'Dim myCmd As OleDbDataAdapter = New OleDbDataAdapter

        Dim strCNS As String = "Contacts_C"                         ' 업체 
        Dim strINFINIQ As String = "Contacts_I"
        Dim strMSTech As String = "Contacts_M"

        Dim szConC As String = "Select * FROM [" + strCNS + "]"
        Dim szConI As String = "Select * FROM [" + strINFINIQ + "]"
        Dim szConM As String = "Select * FROM [" + strMSTech + "]"

        Dim szQuery As String() = New String() {szConC, szConI, szConM}
        Dim loopSht As String() = New String() {strCNS, strINFINIQ, strMSTech}

        vConn = New OleDbConnection(Change_Add_Tree.strCon)

        Dim nCnt As Integer = 0
        For Each a As String In szQuery
            Dim DA = New OleDbDataAdapter(a, vConn)
            DA.Fill(DS, loopSht(nCnt))
            nCnt += 1
        Next

        Dim blcp As Boolean = True
        For nZ As Integer = 0 To 2       ' 0~2 까지가 업체테이블임
            For nW = 1 To DS.Tables(nZ).Rows.Count - 1
                If DS.Tables(nZ).Rows(nW)(2).ToString() = User Then

                    If DS.Tables(nZ).Rows(nW)(4).ToString() = "CNS" Then    ' CNS의 경우에 LG CNS로 보여주기 위해 Custom
                        FindCompany = "LG " & DS.Tables(nZ).Rows(nW)(4).ToString()
                    Else
                        FindCompany = DS.Tables(nZ).Rows(nW)(4).ToString()
                    End If

                    ' 회사 콤보박스 값 = 테이블에 (nZ)(4) 위치에 업체명 넣어줌.
                    blcp = False  ' Exit For가 한번만 나가면 또 다른 테이블 검색하기 때문에 Chk Boolean
                    Exit For
                End If
            Next
            If blcp = False Then  ' 이미 회사이름을 찾은 경우라면!
                Exit For
            End If
        Next

        If blcp = True Then
            getCompany = "미등록 사용자"
        Else
            getCompany = FindCompany
        End If




    End Function

#End Region
End Class


