Imports System.Drawing
Imports System.Windows.Forms
Imports System.Data
Imports System.Data.OleDb
Imports System.Diagnostics

Public Class P_Project_Upload

    Public Change_Add_Tree As New Change_Add_Tree

#Region "★[처음 로드 될 때]★"
    Private Sub M_Model_Plan_U_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Panel2.AllowDrop = True
        Icon = My.Resources.Qportal_Icon

        DataGridView1.Visible = False

        With la_DragOver
            .Font = New Font("맑은 고딕", 12, FontStyle.Bold)
            '.ForeColor = Color.Gray
            .ForeColor = Color.FromArgb(125, 125, 125)
            .Text = "Attach File with drag and drop in anywhere" & Environment.NewLine & "이곳에 파일을 드래그 하세요."
        End With
    End Sub

#End Region

#Region "★[엑셀 다운로드 버튼 클릭]★"
    Private Sub Pic_Excel_down_Click(sender As Object, e As EventArgs) Handles Pic_Excel_down.Click
        ' 바로 Download 관련 Process 하도록
        Dim strPath As String = DownExcel("\\10.169.88.40\Q-Portal\2.검증현황\시험기획", "PJT_시험기획.xlsx")

        Try
            If Not strPath Is Nothing Then
                Diagnostics.Process.Start(strPath)
            End If
        Catch ex As Exception
            System.Diagnostics.Debug.Print(strPath & " 값 ")
        End Try


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
            PassResult = Database_Update_Change_note(dt)
            MessageBox.Show(PassResult,
                                        "lee.sunbae@lgepartner.com",
                                                MessageBoxButtons.OK, MessageBoxIcon.Information)

            Close()


        Else
            'btnDBUp.Visible = True

        End If

        If blCheck = False Then
            MessageBox.Show("올바른 파일을 올려주세요.")
        End If

    End Sub

#End Region

#Region "★엑셀 다운로드 함수★"

    Private Function DownExcel(ByRef strPath As String, ByRef strFindFile As String) As String

        '# 지정경로 안에서 '시험기획서_Access_v1.3' 찾기 후 파일 Copy
        Dim strFolder As String = Nothing
        Dim dir As System.IO.DirectoryInfo = New System.IO.DirectoryInfo(strPath)
        Dim strRealFile As String = Nothing : Dim strFile As String
        Dim strFullPath As String = Nothing

        '// 실행 중인 tmp 파일을 제외 한 copy할 파일을 찾는다.
        For Each dr In dir.GetFiles()
            strFile = dr.Name   '# file name
            If InStr(strFile, strFindFile) And Strings.Left(strFile, 2) <> "~$" Then
                strRealFile = dr.Name
                strFullPath = dr.FullName
                Exit For
            End If
        Next

        '// Buffer byte선언
        Dim bytesRead As Integer
        Dim buffer(4096) As Byte

        '# ByteStream 으로 Application Setpup Folder에 File 저장
        Using inFile As New System.IO.FileStream(strFullPath, IO.FileMode.Open, IO.FileAccess.Read) ' 여기에 있는 파일을
            Using outFile As New System.IO.FileStream(System.Windows.Forms.Application.StartupPath + strRealFile, IO.FileMode.Create, IO.FileAccess.Write)   '# 원하는 경로로 
                Do
                    bytesRead = inFile.Read(buffer, 0, buffer.Length)
                    If bytesRead > 0 Then
                        outFile.Write(buffer, 0, bytesRead)
                    End If
                Loop While bytesRead > 0
            End Using
        End Using

        '# saveFileDialog 생성
        Dim dlg As New System.Windows.Forms.SaveFileDialog With {
            .FileName = strFindFile,
            .DefaultExt = ".xlsx",
            .Filter = "Excel File|*.xlsx",
            .Title = "엑셀 저장하기 | lee.sunbae@lgepartner.com"
        }

        Try
            If dlg.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                Dim openFileName As String = Nothing

                '# Save the files
                System.IO.File.Copy(System.Windows.Forms.Application.StartupPath + strRealFile, dlg.FileName, True)

                Dim strTemp() As String : strTemp = Split(dlg.FileName, "\")
                '# saveFileDialog 에서 받아오는 String은 최종 파일 명까지 가져오기 때문에
                '# 폴더를 열어주기 위해 실제 경로만 담기 위해서 
                Array.Resize(strTemp, strTemp.Length - 1)
                strFolder = String.Join("\", strTemp)

                DownExcel = strFolder

            Else
                System.Diagnostics.Debug.Print("닫았다")

            End If
        Catch ex As Exception
            System.Diagnostics.Debug.Print("닫혔다 --> Exception으로" & ex.Message)
            'Finally
            '    DownExcel = strFolder
        End Try

        '# Return 해야 할 것은 최종 Local Path 
        DownExcel = strFolder
        Return DownExcel

    End Function
#End Region


#Region "# 2. [File to DataGridView]"

    Private Function Excel_File_to_DataGridView(ByRef path As String) As Boolean

        Dim vConn As System.Data.OleDb.OleDbConnection
        Dim DS As DataSet
        Dim myCmd As System.Data.OleDb.OleDbDataAdapter

        '# Excel 을 Database로 인식하도록 Connection String 생성
        vConn = New System.Data.OleDb.OleDbConnection("Provider=Microsoft.Ace.OLEDB.12.0;Data Source=" & path & ";Extended Properties=""Excel 12.0;HDR=YES;""")

        Try
            vConn.Open()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "(Sunbae) - DB Open 에러", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

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

        Try '# Conn Close
            vConn.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "(Sunbae) - DB Close 에러", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        '# Excel 을 Database로 인식하도록 Connection String 생성
        vConn = New OleDbConnection("Provider=Microsoft.Ace.OLEDB.12.0;Data Source=" & path & ";Extended Properties=""Excel 12.0;HDR=YES;""")
        myCmd = New OleDbDataAdapter("Select * FROM [" & table_name & "]", vConn)

        Try
            DS = New DataSet
            myCmd.Fill(DS)      '# DataSet에 엑셀에 있는 내용 모두 담음(조회 된 Query)

            '# DataGridView에 Dataset Table 내용을 바인딩하여 넣음
            DataGridView1.DataSource = DS.Tables(0)
            Excel_File_to_DataGridView = True

        Catch ex As Exception
            Debug.Print(ex.Message)
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
        Dim vSQL_field As String = Nothing, vSQL_Type As String = Nothing
        Dim vSQL2_Major As String = Nothing, vSQL2_Func As String = Nothing
        Dim vSQL_Pro As String = Nothing, vSQL_Mod As String = Nothing
        Dim vSQL_TestType As String = Nothing, vSQL_TestType_Contents As String = Nothing

        Dim nCnt_insert As Integer = 0
        Dim nCnt_update As Integer = 0

        Dim DA As OleDbDataAdapter = New OleDbDataAdapter
        Dim vConn = New OleDbConnection(Change_Add_Tree.strCon)   ' MainForm의 Connection String으로 DB Connect
        vConn.Open()
        Try

            For i As Integer = 0 To dt.Rows.Count - 1
                sGubun = IIf(IsDBNull(dt.Rows(i).Item("구분")), " ", dt.Rows(i).Item("구분"))
                sGubun = Replace(sGubun, "'", "")
                sGubun = LTrim(sGubun)

                sMajorChange = IIf(IsDBNull(dt.Rows(i).Item("주요변경점")), " ", dt.Rows(i).Item("주요변경점"))
                sMajorChange = Replace(sMajorChange, "'", "")
                sMajorChange = LTrim(sMajorChange)

                sChangeContents = IIf(IsDBNull(dt.Rows(i).Item("변경점내용")), " ", dt.Rows(i).Item("변경점내용"))
                sChangeContents = Replace(sChangeContents, "'", "")
                sChangeContents = LTrim(sChangeContents)

                sRisk = IIf(IsDBNull(dt.Rows(i).Item("Risk")), " ", dt.Rows(i).Item("Risk"))
                sRisk = Replace(sRisk, "'", "")
                sRisk = LTrim(sRisk)

                sTestType = IIf(IsDBNull(dt.Rows(i).Item("검증유형")), " ", dt.Rows(i).Item("검증유형"))
                sTestType = Replace(sTestType, "'", "")
                sTestType = LTrim(sTestType)

                sTestTypeContents = IIf(IsDBNull(dt.Rows(i).Item("검증유형내용")), " ", dt.Rows(i).Item("검증유형내용"))
                sTestTypeContents = Replace(sTestTypeContents, "'", "")
                sTestTypeContents = LTrim(sTestTypeContents)

                sProject = IIf(IsDBNull(dt.Rows(i).Item("Project")), " ", dt.Rows(i).Item("Project"))
                sProject = Replace(sProject, "'", "")
                sProject = LTrim(sProject)

                sModel = IIf(IsDBNull(dt.Rows(i).Item("Model")), " ", dt.Rows(i).Item("Model"))
                sModel = Replace(sModel, "'", "")
                sModel = LTrim(sModel)

                sTCCheckbox = IIf(IsDBNull(dt.Rows(i).Item("TC진행여부")), " ", dt.Rows(i).Item("TC진행여부"))
                sTCCheckbox = Replace(sTCCheckbox, "'", "")
                sTCCheckbox = LTrim(sTCCheckbox)

                sTCName = IIf(IsDBNull(dt.Rows(i).Item("TC명")), " ", dt.Rows(i).Item("TC명"))
                sTCName = Replace(sTCName, "'", "")
                sTCName = LTrim(sTCName)


                Dim v As String = getUserName() : Dim c As String = getCompany(v)

                sCompany = c : sRequester = v
                sCompany = LTrim(sCompany) : sRequester = LTrim(sRequester)

                vSQL_Type = "[구분] = '" & Replace(sGubun, "'", "''") & "'"                                    ' Field가 비어있으면 
                vSQL2_Major = " AND [주요변경점] = '" & Replace(sMajorChange, "'", "''") & "'"
                vSQL_TestType = " AND [검증유형] = '" & Replace(sTestType, "'", "''") & "'"

                vSQL_Pro = " AND [Project] = '" & Replace(sProject, "'", "''") & "'"
                vSQL_Mod = " AND [Model] = '" & Replace(sModel, "'", "''") & "'"

                Dim vName As String = " AND [등록자] = '" & Replace(sRequester, "'", "''") & "'"
                Dim vComp As String = " AND [업체명] = '" & Replace(sCompany, "'", "''") & "'"

                'vSQL_field = " And [" & "검증유형" & "] Like '%" & Replace(sTestType, "'", "''") & "%'"           ' 타이틀 체크

                Dim sql As String = Nothing
                sql = "SELECT * "
                sql = sql & "FROM [SW_Validation_Result] "
                sql = sql & "WHERE ID > 0 And " & vSQL_Type & vSQL2_Major & vSQL_Pro & vSQL_Mod & vSQL_TestType & vName & vComp '&' vSQL_TestType_Contents


                Dim myCmd As OleDbCommand
                Dim check As Integer

                Dim result As DataTable = New DataTable
                Dim cmd As OleDbCommand = New OleDbCommand(sql, vConn)
                '     ▼▼ Data Adapter를 사용해 Data Table을 만들고 Query 된 Result를 Count 하여 기존 Data가 있는지 Check 
                Dim adapter As OleDbDataAdapter = New OleDbDataAdapter(cmd)
                adapter.Fill(result)

                '    ▼▼  만약 조회가 안 됐다면 ?  새 항목
                If result.Rows.Count = 0 Then
                    ' is it insert
                    sql = "INSERT INTO SW_Validation_Result (구분, 주요변경점, 변경점내용, Risk, 검증유형, 검증유형내용, Project, Model, 업체명, 등록자, TC진행여부, TC명) " &
                    "values('" & sGubun & "','" + sMajorChange + "','" + sChangeContents + "','" + sRisk + "','" + sTestType + "','" + sTestTypeContents + "','" + sProject + "','" + sModel + "','" + sCompany + "','" + sRequester + "','" + sTCCheckbox + "','" + sTCName + "');"

                    'Debug.Print(sql)
                    myCmd = New OleDbCommand(sql, vConn)
                    check = myCmd.ExecuteNonQuery()
                    nCnt_insert += 1

                Else '◀◀ 기존 데이터와 덮어쓰기 해야 한다면

                    sql = "UPDATE SW_Validation_Result SET "
                    sql = sql & "[구분] ='" & sGubun & "', "
                    sql = sql & "주요변경점 ='" & sMajorChange & "', "
                    sql = sql & "변경점내용 ='" & sChangeContents & "', "
                    sql = sql & "Risk ='" & sRisk & "', "
                    sql = sql & "검증유형 ='" & sTestType & "', "
                    sql = sql & "검증유형내용 ='" & sTestType & "', "
                    sql = sql & "TC진행여부 ='" & sTCCheckbox & "', "
                    sql = sql & "TC명 ='" & sTCName & "', "
                    sql = sql & "업체명 ='" & sCompany & "', "
                    sql = sql & "등록자 ='" & sRequester & "' "
                    sql = sql & " WHERE ID = " & result.Rows(0)(0).ToString()
                    'Debug.Print(sql)

                    myCmd = New OleDbCommand(sql, vConn)
                    check = myCmd.ExecuteNonQuery()
                    nCnt_update += 1
                End If

            Next

        Catch ex As Exception
            Database_Update = True
            Debug.Print(ex.Message)
            Debug.Print("구분 : " & sGubun)
            Debug.Print("주요변경점 : " & sMajorChange)
            Debug.Print("변경점내용 : " & sChangeContents)
            Debug.Print("Risk : " & sRisk)
            Debug.Print("검증유형 : " & sTestType)
            Debug.Print("검증유형내용 : " & sTestTypeContents)
            Debug.Print("Project : " & sProject)
            Debug.Print("Model : " & sModel)
            Debug.Print("TC진행여부 : " & sTCCheckbox)
            Debug.Print("TC명 : " & sTCName)
        Finally

            Debug.Print("업체명 : " & sCompany)
            Debug.Print("작성자 : " & sRequester)

        End Try

        vConn.Close()

        Database_Update =
            "총 : " & nCnt_insert + nCnt_update & Environment.NewLine &
            "추가 됨 : " & nCnt_insert & Environment.NewLine &
            "수정 됨 : " & nCnt_update


        Return Database_Update
    End Function

#End Region

#Region "★ DataGridView to DB 함수 for 기능변경점_DB"
    Private Function Database_Update_Change_note(ByRef dt As DataTable) As String
        Dim Con As New Change_Add_Tree
        Dim sGubun As String = Nothing : Dim sMajorChange As String = Nothing
        Dim sChangeContents As String = Nothing : Dim sRisk As String = Nothing
        Dim sTestType As String = Nothing : Dim sTestTypeContents As String = Nothing
        Dim sProject As String = Nothing : Dim sModel As String = Nothing
        Dim sCompany As String = Nothing : Dim sRequester As String = Nothing
        Dim sTCCheckbox As String = Nothing : Dim sTCName As String = Nothing
        Dim sStep As String = Nothing

        ' 기존 Data 있는지 Check 하기 위한 Query 작성
        Dim vSQL_field As String = Nothing, vSQL_Type As String = Nothing
        Dim vSQL2_Major As String = Nothing, vSQL2_Func As String = Nothing
        Dim vSQL_Pro As String = Nothing, vSQL_Mod As String = Nothing
        Dim vSQL_TestType As String = Nothing, vSQL_Change_Contents As String = Nothing
        Dim vSQL_Step As String = Nothing

        Dim nCnt_insert As Integer = 0
        Dim nCnt_update As Integer = 0

        Dim DA As System.Data.OleDb.OleDbDataAdapter = New System.Data.OleDb.OleDbDataAdapter
        Dim vConn = New System.Data.OleDb.OleDbConnection(Con.strCon)   ' MainForm의 Connection String으로 DB Connect
        vConn.Open()
        Try

            For i As Integer = 0 To dt.Rows.Count - 1

                sMajorChange = IIf(IsDBNull(dt.Rows(i).Item("주요변경점")), " ", dt.Rows(i).Item("주요변경점"))
                sMajorChange = Replace(sMajorChange, "'", "")
                sMajorChange = LTrim(sMajorChange)

                sChangeContents = IIf(IsDBNull(dt.Rows(i).Item("변경점내용")), " ", dt.Rows(i).Item("변경점내용"))
                sChangeContents = Replace(sChangeContents, "'", "")
                sChangeContents = LTrim(sChangeContents)

                sProject = IIf(IsDBNull(dt.Rows(i).Item("Project")), " ", dt.Rows(i).Item("Project"))
                sProject = Replace(sProject, "'", "")
                sProject = LTrim(sProject)

                sModel = IIf(IsDBNull(dt.Rows(i).Item("Model")), " ", dt.Rows(i).Item("Model"))
                sModel = Replace(sModel, "'", "")
                sModel = LTrim(sModel)

                'sStep = IIf(IsDBNull(dt.Rows(i).Item("Step")), " ", dt.Rows(i).Item("Step"))
                'sStep = Replace(sStep, "'", "")
                'sStep = LTrim(sStep)

                Dim v As String = getUserName() : Dim c As String = getCompany(v)

                sCompany = c : sRequester = v
                sCompany = LTrim(sCompany) : sRequester = LTrim(sRequester)

                vSQL2_Major = " AND [변경점] = '" & Replace(sMajorChange, "'", "''") & "'"
                vSQL_Pro = " AND [Project] = '" & Replace(sProject, "'", "''") & "'"
                vSQL_Mod = " AND [Model] = '" & Replace(sModel, "'", "''") & "'"
                'vSQL_Step = " AND [Step] = '" & Replace(sStep, "'", "''") & "'"

                Dim vComp As String = " AND [업체명] = '" & Replace(sCompany, "'", "''") & "'"


                Dim sql As String = Nothing
                sql = "SELECT * "
                sql = sql & "FROM [기능변경점_DB] "
                sql = sql & "WHERE ID > 0  " & vSQL2_Major & vSQL_Pro & vSQL_Mod & vComp '& vSQL_Step & vComp ' & vSQL_Change_Contents '&' vSQL_TestType_Contents

                Dim myCmd As OleDbCommand
                Dim check As Integer

                Dim result As DataTable = New DataTable
                Dim cmd As OleDbCommand = New OleDbCommand(sql, vConn)
                '     ▼▼ Data Adapter를 사용해 Data Table을 만들고 Query 된 Result를 Count 하여 기존 Data가 있는지 Check 
                Dim adapter As OleDbDataAdapter = New OleDbDataAdapter(cmd)
                adapter.Fill(result)

                '    ▼▼  만약 조회가 안 됐다면 ?  새 항목
                If result.Rows.Count = 0 Then
                    ' is it insert
                    'sql = "INSERT INTO 기능변경점_DB (변경점, [변경점 내용], Project, Model, Step, 업체명, 파일명 ) " &
                    '"values('" & sMajorChange & "','" + sChangeContents + "','" + sProject + "','" + sModel + "','" + sStep + "','" + sCompany + "','" + "QPortal_System" + "');"

                    sql = "INSERT INTO 기능변경점_DB (변경점, [변경점 내용], Project, Model, 업체명, 파일명 ) " &
                    "values('" & sMajorChange & "','" + sChangeContents + "','" + sProject + "','" + sModel + "','" + sCompany + "','" + "QPortal_System" + "');"

                    'Debug.Print(sql)
                    myCmd = New OleDbCommand(sql, vConn)
                    check = myCmd.ExecuteNonQuery()
                    nCnt_insert += 1

                Else '◀◀ 기존 데이터와 덮어쓰기 해야 한다면

                    sql = "UPDATE 기능변경점_DB SET "
                    sql = sql & "변경점 ='" & sMajorChange & "', "
                    sql = sql & "[변경점 내용] ='" & sChangeContents & "', "
                    sql = sql & "Project ='" & sProject & "', "
                    sql = sql & "Model ='" & sModel & "', "
                    sql = sql & "업체명 ='" & sCompany & "', "
                    sql = sql & "파일명 ='" & "QPortal_System" & "' "
                    sql = sql & " WHERE ID = " & result.Rows(0)(0).ToString()
                    Debug.Print(sql)

                    myCmd = New OleDbCommand(sql, vConn)
                    check = myCmd.ExecuteNonQuery()
                    nCnt_update += 1
                End If



            Next

        Catch ex As Exception
            ' Database_Update_Change_note = True
            Debug.Print(ex.Message)
            'Debug.Print("쿼리 : " & Sql)


            'Debug.Print("구분 : " & sGubun)
            'Debug.Print("주요변경점 : " & sMajorChange)
            'Debug.Print("변경점내용 : " & sChangeContents)
            'Debug.Print("Risk : " & sRisk)
            'Debug.Print("검증유형 : " & sTestType)
            'Debug.Print("검증유형내용 : " & sTestTypeContents)
            'Debug.Print("Project : " & sProject)
            'Debug.Print("Model : " & sModel)
            'Debug.Print("TC진행여부 : " & sTCCheckbox)
            'Debug.Print("TC명 : " & sTCName)
            'Debug.Print("업체명 : " & sCompany)
            'Debug.Print("작성자 : " & sRequester)

        End Try

        vConn.Close()

        Database_Update_Change_note =
            "총 : " & nCnt_insert + nCnt_update & Environment.NewLine &
            "추가 됨 : " & nCnt_insert & Environment.NewLine &
            "수정 됨 : " & nCnt_update


        Return Database_Update_Change_note
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

    Private Sub btn_search_Click(sender As Object, e As EventArgs) Handles btn_search.Click
        Dim frmPlan_Search As New P_Project_Plan
        frmPlan_Search.Show()
    End Sub


#End Region


End Class