Imports System.Data
Imports System.Data.OleDb
Imports System.Diagnostics
Imports System.Drawing
Imports System.Windows.Forms
Imports MySql.Data.MySqlClient

Public Class pl_risk_upload
    Public Change_Add_Tree As New Change_Add_Tree
    Public ModelInfo As DataSet = New DataSet
    Public RS_App_DS As DataTable = New DataTable
    Public fl As SunClass = New SunClass()
    Public oldPath As String = Nothing
    Public li As Collections.Generic.List(Of String) = New Collections.Generic.List(Of String)
    Public pl_ex As New pl_Export_Upload
#Region "MySQL 용"
    Private mainTable As String = pl_ex.rs_type '## "rs2"
    Public strSQLCon As String = "Server=10.169.88.40;Uid=rs_user;Pwd=lge1234;Database=" & mainTable
    Private mySQLCon As New MySqlConnection(strSQLCon)

    Public tb As New Table_class '// Table Name Class
#End Region

#Region "처음 로드될 때"
    Private Sub PN_2_0_NUM3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Panel2.AllowDrop = True
        Icon = My.Resources.Qportal_Icon

        DataGridView1.Visible = False

        With la_DragOver
            .Font = New Font("맑은 고딕", 12, FontStyle.Bold)
            .ForeColor = Color.FromArgb(125, 125, 125)
            .Text = "Attach File with drag and drop in anywhere" & Environment.NewLine & "이곳에 파일을 드래그 하세요."
        End With

        Push_Data()

    End Sub
#End Region

#Region "드래그 해서  [엑셀 업로드 기능]"

    '# 폼에 마우스 가져다 댔을 때
    Private Sub UploadExcel_DragEnter(sender As Object, e As System.Windows.Forms.DragEventArgs) Handles Panel2.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then e.Effect = DragDropEffects.Copy        ' 만약 갖다대는게 파일일 경우
    End Sub
    Private Sub UploadExcel_DragDrop(sender As Object, e As System.Windows.Forms.DragEventArgs) Handles Panel2.DragDrop

        DataGridView1.Visible = True
        Dim blCheck As Boolean = False       '# DragDrop 시 DragEventArgs를 통해 Data를 받아 온다. 
        Dim files() As String = e.Data.GetData(DataFormats.FileDrop)      '# Array 형식으로 저장 된 것을 난 파일 하나만 허용 할 거기 때문에 
        Dim path As String = files(0)

        Dim strExtension As String = Nothing
        Dim fi As New IO.FileInfo(path) : strExtension = fi.Extension
        Console.WriteLine("현재 파일 Path : {0}", fi.FullName)
        oldPath = fi.FullName

        If fl.File_is_Open(oldPath) Then Exit Sub

        Console.WriteLine("Class Path : {0}", fl._NowPath)

        If strExtension <> ".xlsx" Then
            MessageBox.Show("확장자가 ""xlsx"" 인 엑셀 파일만 올려주세요. ", "lee.sunbae@lgepartner.com", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        '# 2. [Excel File to DataGridView]
        blCheck = Excel_File_to_DataGridView(path)

        If blCheck = False Then
            MessageBox.Show("올바른 파일을 올려주세요.")
            Exit Sub
        End If

        If DialogResult.Yes = MessageBox.Show("바로 결과를 올리시겠습니까?" &
                                              Environment.NewLine & "바로 DB에 올리려면 ""예""" &
                                              Environment.NewLine & "확인 하고 올리려면 ""아니오""를 누르세요.",
                                              "lee.sunbae@lgepartner.com", MessageBoxButtons.YesNo, MessageBoxIcon.Information) Then

            Dim dt As New DataTable()
            dt = TryCast(DataGridView1.DataSource, DataTable)   ' DataGridView에 있는 자료를 Datatable로 옮김 

            Dim PassResult As String = Nothing
            PassResult = Database_Update(dt)          'PassResult = Database_Update_Change_note(dt)
            MessageBox.Show(PassResult, "lee.sunbae@lgepartner.com", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Close()
            Set_path_name()
        Else
            btnDBUp.Visible = True
        End If

    End Sub

#End Region

#Region "# 2. [File to DataGridView]"

    Private Function Excel_File_to_DataGridView(ByRef path As String) As Boolean

        Dim vConn As System.Data.OleDb.OleDbConnection
        Dim DS As DataSet
        Dim myCmd As System.Data.OleDb.OleDbDataAdapter
        Dim proCmd As System.Data.OleDb.OleDbDataAdapter

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
        Try
            dt = vConn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, New Object() {Nothing, Nothing, Nothing, "TABLE"})
        Catch ex As Exception
            MessageBox.Show(ex.Message, "(Sunbae) - 업로드 하려는 엑셀파일이 열려있습니다." & Environment.NewLine & "문서를 닫고 다시 시도해주세요.", MessageBoxButtons.OK, MessageBoxIcon.Error)
            vConn.Close()
        Finally

        End Try

        Dim chk_db_sht As Boolean = False
        For i As Integer = 0 To dt.Rows.Count - 1
            If dt.Rows(i)("TABLE_NAME") Like "DB_시트*" Then
                chk_db_sht = True
                Exit For
            End If
        Next

        If chk_db_sht = False Then
            MessageBox.Show("[DB_시트]가 없는 문서 입니다. 최신 파일로 올려주세요." & vbCrLf & "최신파일은 Export 기능으로 받을 수 있습니다.", "(Sunbae)", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Excel_File_to_DataGridView = False
            Exit Function
        End If

        Dim table_name As String = Nothing

        Try '# Sheet명 꺼내기
            'table_name = dt.Rows(1).Item("Table_Name")
            table_name = "작성$"
        Catch ex As Exception
            MessageBox.Show(ex.Message, "(Sunbae) - 시트가 없습니다.", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


        Try '# Conn Close
            vConn.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "(Sunbae) - DB Close 에러", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        '# DB 연결하여 실행
        myCmd = New System.Data.OleDb.OleDbDataAdapter("Select * FROM [" & table_name & "B11:P3000]", vConn)
        proCmd = New System.Data.OleDb.OleDbDataAdapter("Select * FROM [" & table_name & "B4:G5]", vConn)

        Try
            DS = New DataSet
            myCmd.Fill(DS)      '# DataSet에 엑셀에 있는 내용 모두 담음(조회 된 Query)
            proCmd.Fill(ModelInfo)

            '# DataGridView에 Dataset Table 내용을 바인딩하여 넣음
            DataGridView1.DataSource = DS.Tables(0)
            Excel_File_to_DataGridView = True

        Catch ex As Exception
            System.Diagnostics.Debug.Print(ex.Message)
            Exit Function

        Finally
            vConn.Close()
        End Try

        Return Excel_File_to_DataGridView

    End Function

#End Region

#Region "# 3. [DataGridView To Database]"

    Private Function Database_Update(ByRef dt As DataTable) As String

        Dim sRsApp As String, sApp As String, sFea As String, sName As String, sPMD As Single, sHMD As Single
        Dim sCh As String, sChC As String, sRisk As String, sChHow As String
        Dim sRand1 As String = "Random_변경점", sRand2 As String = "Random_변경점x"
        Dim sRand1_cont As String, sRand2_cont As String

        Dim vSQL_PRO As String, vSQL_OSU As String, vSQL_SUFF As String, vSQL_MOD As String, vSQL_STEP As String
        Dim vSQL_COM As String, vSQL_sApp As String, vSQL_sCh As String

        Dim proTable As DataTable = New DataTable
        proTable = ModelInfo.Tables(0)
        Dim line As String = "--------------------------------------------------------------"


        li.Add("Project") : li.Add("OSU") : li.Add("Group") : li.Add("Suffix") : li.Add("Model") : li.Add("Step")

        Dim index As Integer
        Dim sw As Boolean = False
        For i As Integer = 0 To proTable.Columns.Count - 1
            index = li.FindIndex(Function(x As String) x.Contains(proTable.Columns(i).Caption))
            If index < 0 Then
                sw = True
            End If
        Next

        If sw = True Then
            MessageBox.Show(line & Environment.NewLine & "[Project]   [OSU]   [GROUP]   [Suffix]   [Model]   [Step]" & Environment.NewLine &
                           line & Environment.NewLine & " 위의 정보가 없습니다. 확인 후 다시 시도해주세요.", "(Sunbae)", MessageBoxButtons.OK, MessageBoxIcon.Error)
            _fileChk = True
            Exit Function
        End If

        Dim sPro As String = proTable.Rows(0).Item("Project")
        Dim sOSU As String = proTable.Rows(0).Item("OSU")
        Dim sGR As String = proTable.Rows(0).Item("Group")
        Dim sSuff As String = proTable.Rows(0).Item("Suffix")
        Dim sMod As String = proTable.Rows(0).Item("Model")
        Dim sStep As String = proTable.Rows(0).Item("Step")
        Dim sCompany As String = getCompany(getUserName())
        'Dim sCompany As String = getCompany("백지은")
        Debug.Print(sCompany)

        li.Clear() : li.Add(sPro) : li.Add(sOSU) : li.Add(sSuff) : li.Add(sMod) : li.Add(sStep)

        Dim nCnt_insert As Integer = 0 : Dim nCnt_update As Integer = 0
        Dim reader As MySql.Data.MySqlClient.MySqlDataReader
        Dim DA As MySqlDataAdapter = New MySqlDataAdapter
        Dim sql As String = Nothing
        Dim cmd As MySqlCommand = New MySqlCommand()

        cmd.Connection = mySQLCon

        Try
            mySQLCon.Open()    '// Open mySQL Connection Databe 
        Catch ex As Exception
            MessageBox.Show(ex.Message & Environment.NewLine & "mySQLCon.Open() error", "(Sunbae)", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Dim insert_sql As String, update_sql As String, sum_sql As String
        Dim tbc As Table_class = New Table_class()
        'Dim tbl As String = tbc.getTable("random_plan")
        Dim tbl As String = mainTable & "." & "randomplandb" '# MySQL Table명 지정
        Dim num As Long = 0
        Try
            For i As Integer = 0 To dt.Rows.Count - 1
                sApp = dt.Rows(i).Item("App Name")
                sRsApp = Get_rs_appname(sApp)
                Console.WriteLine("변환 전 App : {0}" & vbTab & vbTab & vbTab & " 변환 된 App {1}", sApp, sRsApp)
                sFea = IIf(IsDBNull(dt.Rows(i).Item("Feature")), "정보없음", dt.Rows(i).Item("Feature"))
                sName = IIf(IsDBNull(dt.Rows(i).Item("담당자")), "정보없음", dt.Rows(i).Item("담당자"))
                sPMD = IIf(IsDBNull(dt.Rows(i).Item(3)), 0.0, dt.Rows(i).Item(3))
                sHMD = IIf(IsDBNull(dt.Rows(i).Item(4)), 0.0, dt.Rows(i).Item(4))
                sCh = IIf(IsDBNull(dt.Rows(i).Item("변경점")), "정보없음", dt.Rows(i).Item("변경점"))
                sChC = IIf(IsDBNull(dt.Rows(i).Item("변경점 내용")), "정보없음", dt.Rows(i).Item("변경점 내용"))
                sRisk = IIf(IsDBNull(dt.Rows(i).Item("Risk Factor")), "정보없음", dt.Rows(i).Item("Risk Factor"))
                sChHow = IIf(IsDBNull(dt.Rows(i).Item("변경점 검증방법")), "정보없음", dt.Rows(i).Item("변경점 검증방법"))
                sRand1_cont = IIf(IsDBNull(dt.Rows(i).Item(11)), "정보없음", dt.Rows(i).Item(11))
                sRand2_cont = IIf(IsDBNull(dt.Rows(i).Item(13)), "정보없음", dt.Rows(i).Item(13))

                sCh = remove_colon(sCh) : sChC = remove_colon(sChC) : sRisk = remove_colon(sRisk)
                sChHow = remove_colon(sChHow) : sRand1_cont = remove_colon(sRand1_cont) : sRand2_cont = remove_colon(sRand2_cont)

#Region "MySQL 기존 쿼리 조회"
                vSQL_sApp = " AND `App Name` = '" & Replace(sApp, "'", "''") & "'"
                vSQL_sCh = " AND `변경점` = '" & Replace(sCh, "'", "''") & "'"
                vSQL_PRO = " AND `PROJECT` = '" & Replace(sPro, "'", "''") & "'"
                vSQL_OSU = " AND `OSU` = '" & Replace(sOSU, "'", "''") & "'"
                vSQL_SUFF = " AND `SUFFIX` = '" & Replace(sSuff, "'", "''") & "'"
                vSQL_MOD = " AND `MODEL` = '" & Replace(sMod, "'", "''") & "'"
                vSQL_STEP = " AND `STEP` = '" & Replace(sStep, "'", "''") & "'"
                vSQL_COM = " AND COMPANY = '" & Replace(sCompany, "'", "''") & "'"
                sql = "select ID from " & tbl & " where ID > 0 " & vSQL_sApp & vSQL_sCh & vSQL_PRO & vSQL_OSU & vSQL_SUFF & vSQL_MOD & vSQL_STEP & vSQL_COM

                Dim rcmd As MySqlCommand = New MySqlCommand(sql, mySQLCon)

                reader = rcmd.ExecuteReader()
                Try
                    While reader.Read
                        num = reader(0)
                    End While
                Catch ex As Exception
                    Console.WriteLine(ex.Message)
                Finally
                    reader.Close()
                End Try
#End Region

                If num = 0 Then
                    sum_sql = sum_sql & "('" & sPro & "','" & sOSU & "','" & sSuff & "','" & sMod & "','" & sStep & "','" & sRsApp & "','" & sApp & "','" & sFea & "','" & sName & "','" & sPMD & "','" & sHMD
                    sum_sql = sum_sql & "','" & sCh & "','" & sChC & "','" & sRisk & "','" & sChHow & "','" & sRand1 & "','" & sRand1_cont & "','" & sRand2 & "','" & sRand2_cont & "','" & sCompany & "'),"
                    nCnt_insert += 1
                Else
#Region "업데이트 하기"
                    Try
                        'UPDATE test_plan SET 검증원 = '정보없음', 필요MD = 13.5 WHERE ID = 1
                        update_sql = "UPDATE  " & tbl & " set 검증원 = '" & sName & "'" & ", 필요MD = " & sPMD & "" & ", 할당MD = " & sHMD & "" & " , 변경점 = '" & sCh & "'" &
                             ", `변경점 내용` = '" & sChC & "'" &
                             ", `Risk Factor` = '" & sRisk & "'" &
                             ", `변경점 검증방법` = '" & sChHow & "'" &
                             ", 주요점검사항 = '" & sRand1_cont & "'" &
                             ", 주요점검사항2 = '" & sRand2_cont & "'" &
                            "WHERE ID = " & num
                        cmd.CommandText = update_sql
                        cmd.ExecuteNonQuery()
                        nCnt_update += 1
                    Catch ex As Exception
                        Console.WriteLine(ex.Message)
                    End Try

#End Region
                End If
            Next i

            If nCnt_insert > 0 Then
                sum_sql = sum_sql.Substring(0, Len(sum_sql) - 1)
                insert_sql = "INSERT INTO " & tbl & " (PROJECT, OSU, SUFFIX, MODEL, STEP, RS_App_Name,`App Name`, Feature, 검증원, 필요MD,할당MD,  변경점, `변경점 내용`, `Risk Factor`, `변경점 검증방법`, 검증유형,주요점검사항, 검증유형2,주요점검사항2, COMPANY) 
                         VALUES " & sum_sql
                cmd.CommandText = insert_sql
                cmd.ExecuteNonQuery()   '// Insert into
            End If

        Catch ex As Exception
            Database_Update = True
            Debug.Print(ex.Message)
            MessageBox.Show(ex.Message, "(Sunbae)", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Console.WriteLine("App : {0} rs : {1} fea : {2} 담당자 : {3} 필요md : {4} 할당md : {5}", sApp, sRsApp, sFea, sName, sPMD, sHMD)
            Console.WriteLine("변경점 : {0} 변경내용 : {1} 리스크 : {2} 검증방법 : {3} 검증내용1 : {4} 검증내용2 : {5}", sCh, sChC, sRisk, sChHow, sRand1_cont, sRand2_cont)

        Finally
            mySQLCon.Close()
        End Try

        Database_Update =
            "총 : " & nCnt_insert + nCnt_update & Environment.NewLine &
            "추가 됨 : " & nCnt_insert & Environment.NewLine &
            "수정 됨 : " & nCnt_update

        Return Database_Update
    End Function
    Private Function remove_colon(ByVal s As String) As String
        Dim t As String
        t = Replace(s, "'", "") : s = t
        Return s
    End Function
#End Region

#Region "경로 및 파일명 제작 함수"
    Private Sub Set_path_name()
        Dim fl As SunClass = New SunClass()
        If Me._fileChk = True Then
            MessageBox.Show("DB Update가 올바르게 되지 않았습니다.", "(Sunbae)", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        Dim strPath As String = "\\10.169.88.40\Q-Portal\1.검증정보\최신Template\랜덤현황"
        Dim strFindPath As String = strPath & "\" & li(0) & "_" & li(1) & "\" & li(3) & "_" & li(2) & "\" & li(4)
        For i As Integer = 0 To li.Count - 1
            Console.WriteLine("li({0}) : {1}", i, li(i))
        Next

        Console.WriteLine("파일경로 : {0}", strFindPath)

        Dim strFindFile As String = li(3) & "_" & li(4) & "_" & CStr(DateTime.Now.ToString("yyyyMMdd_HHmmss")) & ".xlsx"
        Console.WriteLine("파일이름 : {0}", strFindFile)

        fl._NowPath = oldPath

        If (Not System.IO.Directory.Exists(strFindPath)) Then
            System.IO.Directory.CreateDirectory(strFindPath)
            Console.WriteLine("경로 생성 완료 : {0}", strFindPath)
            fl.FileMovetoTarget(strFindPath & "\" & strFindFile)
        Else
            fl.FileMovetoTarget(strFindPath & "\" & strFindFile)
        End If

    End Sub
    Private bl_chk As Boolean = False
    Property _fileChk As Boolean
        Get
            Return Me.bl_chk
        End Get
        Set(value As Boolean)
            Me.bl_chk = value
        End Set
    End Property

#End Region



#Region "get rs_name 함수"

    Private Function Get_rs_appname(ByRef app As String) As String
        Dim strFind As String = Nothing, sw As Boolean = False
        With RS_App_DS
            For i As Integer = 0 To .Rows.Count - 1
                If app = .Rows(i).Item("app") Then  '#compare to app name in mysql db
                    strFind = .Rows(i).Item("rs_app")
                    sw = True
                End If
            Next
            If sw = False Then strFind = "분류불가"
        End With
        Return strFind
    End Function

#End Region

#Region "rs AppName을 Datatable에 넣는 Code"
    Private Sub Push_Data()
        Dim sql As String = "SELECT app, rs_app FROM td_defect.plan_app_to_rsapp "
        Dim rs_dataset As DataSet
        rs_dataset = FillDataMysql(mySQLCon, "rs_app", sql)
        RS_App_DS = rs_dataset.Tables(0)
    End Sub
#End Region

#Region "MySQL을 Dataset에 담는 함수"
    Private Function FillDataMysql(ByRef vConn As MySql.Data.MySqlClient.MySqlConnection, ByRef tbl As String, ByRef sql As String) As DataSet
        Dim cmd As MySql.Data.MySqlClient.MySqlCommand
        Dim DA As MySql.Data.MySqlClient.MySqlDataAdapter = New MySql.Data.MySqlClient.MySqlDataAdapter()
        Dim DS As DataSet = New DataSet
        Try
            cmd = New MySqlCommand(sql, vConn)
            DA = New MySqlDataAdapter(cmd)
            DA.Fill(DS, tbl)
        Catch ex As Exception
            MessageBox.Show(ex.Message & Environment.NewLine & "ds.fill() Error", "(Sun)", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Diagnostics.Debug.Print(sql)
        End Try

        Return DS

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

#Region "업체명 구하기"
    Public Function getCompany(ByRef User As String) As String
        Dim FindCompany As String = Nothing
        'Dim vConn As OleDbConnection = New OleDbConnection
        Dim tb As New Table_class
        Dim vConn As MySql.Data.MySqlClient.MySqlConnection = New MySql.Data.MySqlClient.MySqlConnection
        Dim blcp As Boolean = True
        Dim strConC As String = tb.getTable("contacts_c")
        Dim strConI As String = tb.getTable("contacts_i")
        Dim strCon As String = tb.getTable("contacts_m")
        Dim strSQLCon As String = "Server=10.169.88.40;Uid=rs_user;Pwd=lge1234;Database=td_defect"
        Dim mySQLCon As New MySql.Data.MySqlClient.MySqlConnection(strSQLCon)
        Dim mySQLCmd As New MySql.Data.MySqlClient.MySqlCommand
        Dim reader As MySql.Data.MySqlClient.MySqlDataReader
        Try
            mySQLCon.Open()
        Catch ex As Exception
            Windows.Forms.MessageBox.Show(ex.Message, "(Sunbae) - DB Open 에러", Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Error)
        End Try


        Dim sql As String =
            "WITH all_tables AS
            (
                SELECT 'A' AS table_name, 이름, 업체 FROM td_defect.contacts_c
                UNION ALL
                SELECT 'B',이름, 업체 FROM td_defect.contacts_i
                UNION ALL
                SELECT 'C',이름, 업체 FROM td_defect.contacts_m
             )
            SELECT * 
            FROM all_tables
            WHERE 이름= '" & User & "';"

        'Dim sql = "select * from contacts_c;"

        Try '// 기존 data 조회
            mySQLCmd.Connection = mySQLCon
            mySQLCmd.CommandText = sql
        Catch ex As Exception
            Diagnostics.Debug.Print(ex.Message & Environment.NewLine & "기존 DB조회 오류")
            Exit Function
        End Try

        Try '// data reader 사용

            reader = mySQLCmd.ExecuteReader()
        Catch ex As Exception
            Diagnostics.Debug.Print(ex.Message & Environment.NewLine & "기존 DB조회 오류_reader 오류")
        End Try


        Try
            While reader.Read
                'Diagnostics.Debug.Print(reader(2))
                FindCompany = reader(2)
                blcp = False
            End While
        Catch ex As Exception
            Diagnostics.Debug.Print(ex.Message & Environment.NewLine & "기존 DB조회 오류_reader 오류")
        Finally
            reader.Close()
        End Try

        If blcp = True Then
            FindCompany = "미등록 사용자"
        Else
            FindCompany = FindCompany
        End If

        getCompany = FindCompany

        Return getCompany

    End Function
#End Region

    Private Sub btnDBUp_Click(sender As Object, e As EventArgs) Handles btnDBUp.Click

    End Sub


#End Region

End Class