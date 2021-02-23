Imports System.Drawing
Imports System.Windows.Forms
Imports System.Data
Imports System.Data.OleDb
Imports System.Diagnostics
Imports System.Text.RegularExpressions
Imports MySql.Data.MySqlClient
Imports System.Collections.Generic

Public Class pl_updown

    Public Change_Add_Tree As New Change_Add_Tree
    Public pl As plan_class = New plan_class()

#Region "처음 로드될 때"
    Private Sub PN_2_0_NUM1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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

#Region "첫번째 엑셀 다운버튼 눌렀을 때"
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

#Region "두번째 엑셀 다운버튼 눌렀을 때"
    Private Sub Pic_down_excel_Button_two(sender As Object, e As EventArgs) Handles pic_down_excel2.Click
        ' 바로 Download 관련 Process 하도록
        Dim strPath As String = DownExcel("\\10.169.88.40\Q-Portal\2.검증현황\시험기획", "앱매핑_1.0.xlsx")

        Try
            If Not strPath Is Nothing Then
                Diagnostics.Process.Start(strPath)
            End If
        Catch ex As Exception
            System.Diagnostics.Debug.Print(strPath & " 값 ")
        End Try

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
        Try
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
        Catch ex As Exception
            MessageBox.Show(ex.Message, "(Sunbae) - 원본 파일이 열려 있습니다.", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try



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

#Region "드래그 해서  [엑셀 업로드 기능]"

    '# 폼에 마우스 가져다 댔을 때
    Private Sub UploadExcel_DragEnter(sender As Object, e As System.Windows.Forms.DragEventArgs) Handles Panel2.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then ' 만약 갖다대는게 파일일 경우
            e.Effect = DragDropEffects.Copy
        End If
    End Sub

    Private Sub UploadExcel_DragDrop(sender As Object, e As System.Windows.Forms.DragEventArgs) Handles Panel2.DragDrop

        Dim pl As plan_class = New plan_class()

        Dim pl_select As New pl_select
        pl_select.ShowDialog()
        Debug.Print(pl_select.getResult)
        Dim name As String = pl.getUserName()
        Dim cp As String = pl.getCompany(name)


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
            If pl_select.rdo_pln.Checked = True Then
                'PassResult = Database_Update(dt)    '# 이부분이 실제 Database 올리는 부분
                PassResult = Database_Update_Func(dt)    '# 이부분이 실제 Database 올리는 부분
            ElseIf pl_select.rdo_app.Checked = True Then

            Else
                MessageBox.Show("항목 선택 후 다시 시도 해주세요.", "lee.sunbae@lgepartner.com", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            'PassResult = Database_Update(dt)    '# 이부분이 실제 Database 올리는 부분

            'PassResult = Database_Update_Change_note(dt)
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
            'table_name = dt.Rows(0).Item("Table_Name")
            table_name = "작성"
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

#Region "Pjt_시험기획 용"
    Private Function Database_Update(ByRef dt As DataTable) As String

        Dim nCnt_insert As Integer = 0 : Dim nCnt_update As Integer = 0
        Dim upchk As Boolean = False
        Dim reader As MySqlDataReader = Nothing
        Dim cmd As MySqlCommand = New MySqlCommand()
        Dim sql As String = Nothing
        Dim myCon As MySqlConnection = New MySqlConnection(pl.strSQLCon)    ' connection open
        Dim update_sql As String, sum_sql As String = ""
        Dim insert_sql As String


        Dim name As String = pl.getUserName()
        Dim cp As String = pl.getCompany(name)

        Try '// Open mySQL Connection Databe 
            myCon.Open()
            cmd.Connection = myCon
        Catch ex As Exception
            MessageBox.Show(ex.Message, "(Sunbae) - DB Open 에러", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Dim tbl As String = pl.getTableName() & "." & "pjt_plan_db" '# MySQL Table명 지정
        Dim num As Long = 0
        Dim chg_gubun As String, gubun As String, ch As String, chC As String, Risk As String, test_type As String, appname As String, test_type_c, pro As String, model As String, tcRun As String, tcname As String
        Dim a As String, b As String, c As String
        Try
            For i As Integer = 0 To dt.Rows.Count - 1
                '# data 저장
                '# 변경점구분 구분 주요변경점 변경점내용 Risk 검증유형 AppName 검증유형내용 Project Model TC진행여부 TC명
                'INSERT INTO pjt_plan_db (변경점구분) VALUES (IFNULL(변경점구분, 'a'))

                chg_gubun = IIf(IsDBNull(dt.Rows(i).Item("변경점구분")), "정보없음", dt.Rows(i).Item("변경점구분"))
                gubun = IIf(IsDBNull(dt.Rows(i).Item("구분")), "정보없음", dt.Rows(i).Item("구분"))
                ch = IIf(IsDBNull(dt.Rows(i).Item("주요변경점")), "정보없음", dt.Rows(i).Item("주요변경점"))
                chC = IIf(IsDBNull(dt.Rows(i).Item("변경점내용")), "정보없음", dt.Rows(i).Item("변경점내용"))
                Risk = IIf(IsDBNull(dt.Rows(i).Item("Risk")), "정보없음", dt.Rows(i).Item("Risk"))
                test_type = IIf(IsDBNull(dt.Rows(i).Item("검증유형")), "정보없음", dt.Rows(i).Item("검증유형"))
                appname = IIf(IsDBNull(dt.Rows(i).Item("AppName")), "정보없음", dt.Rows(i).Item("AppName"))
                test_type_c = IIf(IsDBNull(dt.Rows(i).Item("검증유형내용")), "정보없음", dt.Rows(i).Item("검증유형내용"))
                pro = IIf(IsDBNull(dt.Rows(i).Item("Project")), "정보없음", dt.Rows(i).Item("Project"))
                model = IIf(IsDBNull(dt.Rows(i).Item("Model")), "정보없음", dt.Rows(i).Item("Model"))
                tcRun = IIf(IsDBNull(dt.Rows(i).Item("TC진행여부")), "정보없음", dt.Rows(i).Item("TC진행여부"))
                tcname = IIf(IsDBNull(dt.Rows(i).Item("TC명")), "정보없음", dt.Rows(i).Item("TC명"))

                'Dim txtarr = {chg_gubun, gubun, ch, chC, Risk, test_type, appname, test_type_c, tcname}
                chg_gubun = remove_colon(chg_gubun)
                gubun = remove_colon(chg_gubun)
                ch = remove_colon(ch)
                chC = remove_colon(chC)
                Risk = remove_colon(Risk)
                test_type = remove_colon(test_type)
                appname = remove_colon(appname)
                test_type_c = remove_colon(test_type_c)
                tcname = remove_colon(tcname)


#Region "MySQL 기존 쿼리 조회"

                a = " AND 구분 = '" & Replace(gubun, "'", "''") & "'"
                b = " AND Project = '" & Replace(pro, "'", "''") & "'"
                c = " AND Model = '" & Replace(model, "'", "''") & "'"
                sql = "select ID from " & tbl & " where ID > 0 " & a & b & c

                Dim rcmd As MySqlCommand = New MySqlCommand(sql, myCon)

                Try
                    reader = rcmd.ExecuteReader()
                    While reader.Read
                        num = reader(0)
                    End While
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "(Sunbae) - DB 기존 쿼리 조회 에러 ", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Finally
                    reader.Close()
                End Try
#End Region

#Region "업데이트 하기"
                Try
                    If num > 0 Then
                        update_sql = "UPDATE  " & tbl & " set 
                                변경점구분 = '" & chg_gubun & "'" &
                                 ", 주요변경점 = '" & ch & "'" &
                                 ", 변경점내용 = '" & chC & "'" &
                                 " , Risk = '" & Risk & "'" &
                                 ", 검증유형 = '" & test_type & "'" &
                                 ", AppName = '" & appname & "'" &
                                 ", 검증유형내용 = '" & test_type_c & "'" &
                                 ", TC진행여부 = '" & tcRun & "'" &
                                 ", TC명 = '" & tcname & "'" &
                                " WHERE ID = " & num
                        cmd.CommandText = update_sql
                        cmd.ExecuteNonQuery()
                        nCnt_update += 1
                    End If

                Catch ex As Exception
                    MessageBox.Show(ex.Message, "(Sunbae) - DB 업데이트 기능 에러 ", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Function
                End Try

#End Region

#Region "추가 하기(Insert into)"
                If num = 0 Then
                    sum_sql = sum_sql & "('" & chg_gubun & "','" & gubun & "','" & ch & "','" & chC & "','" & Risk & "','" & test_type & "','" & appname & "','" & test_type_c & "','" & pro & "','" & model & "','" & tcRun & "','" & tcname & "'),"
                    upchk = True
                    nCnt_insert += 1
                End If


            Next i

            If upchk = True Then
                sum_sql = sum_sql.Substring(0, Len(sum_sql) - 1)
                insert_sql = "INSERT INTO " & tbl & " (변경점구분, 구분, 주요변경점, 변경점내용, Risk, 검증유형, AppName, 검증유형내용, Project, Model, TC진행여부, TC명, Company, insert_date) 
                         VALUES " & sum_sql
                cmd.CommandText = insert_sql
                cmd.ExecuteNonQuery()   '// Insert into

            End If
#End Region


        Catch ex As Exception
            Database_Update = True
            MessageBox.Show(ex.Message, "(Sunbae) - DB 올리기 에러", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally
            myCon.Close()
        End Try


        Database_Update =
            "총 : " & nCnt_insert + nCnt_update & Environment.NewLine &
            "추가 됨 : " & nCnt_insert & Environment.NewLine &
            "수정 됨 : " & nCnt_update


        Return Database_Update
    End Function
#End Region

#Region "기능 변경점 전용"
    '# 시간상 어쩔 수 없이 비효율적으로 두 개 만듬.;
    Private Function Database_Update_Func(ByRef dt As DataTable) As String

        Dim nCnt_insert As Integer = 0 : Dim nCnt_update As Integer = 0
        Dim upchk As Boolean = False
        Dim reader As MySqlDataReader = Nothing
        Dim cmd As MySqlCommand = New MySqlCommand()
        Dim sql As String = Nothing
        Dim myCon As MySqlConnection = New MySqlConnection(pl.strSQLCon)    ' connection open
        Dim update_sql As String, sum_sql As String = ""
        Dim insert_sql As String

        Try '// Open mySQL Connection Databe 
            myCon.Open()
            cmd.Connection = myCon
        Catch ex As Exception
            MessageBox.Show(ex.Message, "(Sunbae) - DB Open 에러", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Debug.Print(pl.getUserName)
        'Debug.Print(tb.getUserName())

        Dim name As String = pl.getUserName()
        Dim cp As String = pl.getCompany(name)


        'SELECT 변경점, 변경점내용, Project, OSU, Suffix, Model, Step FROM func_mapping_db
        Dim tbl As String = pl.getTableName() & "." & "func_mapping_db" '# MySQL Table명 지정
        Dim num As Long = 0
        Dim ch As String, chC As String, pro As String, osu As String, suffix As String, model As String, sstep As String
        Dim a As String, b As String, c As String, d As String, e As String, f As String, g As String
        Try
            For i As Integer = 0 To dt.Rows.Count - 1
                '# data 저장
                '# 변경점구분 구분 주요변경점 변경점내용 Risk 검증유형 AppName 검증유형내용 Project Model TC진행여부 TC명
                'INSERT INTO pjt_plan_db (변경점구분) VALUES (IFNULL(변경점구분, 'a'))

                ch = IIf(IsDBNull(dt.Rows(i).Item("주요변경점")), "정보없음", dt.Rows(i).Item("주요변경점"))
                chC = IIf(IsDBNull(dt.Rows(i).Item("변경점내용")), "정보없음", dt.Rows(i).Item("변경점내용"))

                pro = IIf(IsDBNull(dt.Rows(i).Item("Project")), "정보없음", dt.Rows(i).Item("Project"))
                osu = IIf(IsDBNull(dt.Rows(i).Item("OSU")), "정보없음", dt.Rows(i).Item("OSU"))
                suffix = IIf(IsDBNull(dt.Rows(i).Item("SUFFIX")), "정보없음", dt.Rows(i).Item("SUFFIX"))
                model = IIf(IsDBNull(dt.Rows(i).Item("Model")), "정보없음", dt.Rows(i).Item("Model"))
                sstep = IIf(IsDBNull(dt.Rows(i).Item("STEP")), "정보없음", dt.Rows(i).Item("STEP"))

                'Dim txtarr = {chg_gubun, gubun, ch, chC, Risk, test_type, appname, test_type_c, tcname}
                ch = remove_colon(ch)
                chC = remove_colon(chC)
                pro = remove_colon(pro)
                osu = remove_colon(osu)
                suffix = remove_colon(suffix)
                model = remove_colon(model)
                sstep = remove_colon(sstep)


#Region "MySQL 기존 쿼리 조회"

                a = " AND Project = '" & Replace(pro, "'", "''") & "'"
                b = " AND OSU = '" & Replace(osu, "'", "''") & "'"
                c = " AND Suffix = '" & Replace(suffix, "'", "''") & "'"
                d = " AND Model = '" & Replace(model, "'", "''") & "'"
                e = " AND Step = '" & Replace(sstep, "'", "''") & "'"
                f = " AND 변경점 = '" & Replace(ch, "'", "''") & "'"
                g = " AND Company = '" & Replace(cp, "'", "''") & "'"

                sql = "select ID from " & tbl & " where ID > 0 " & a & b & c & d & e & f & g

                Dim rcmd As MySqlCommand = New MySqlCommand(sql, myCon)

                Try
                    reader = rcmd.ExecuteReader()
                    While reader.Read
                        num = reader(0)
                    End While
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "(Sunbae) - DB 기존 쿼리 조회 에러 ", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Finally
                    reader.Close()
                End Try
#End Region

#Region "업데이트 하기"
                Try
                    If num > 0 Then
                        update_sql = "UPDATE  " & tbl & " set 
                                  변경점 = '" & ch & "'" &
                                 ", 변경점내용 = '" & chC & "'" &
                                " WHERE ID = " & num
                        cmd.CommandText = update_sql
                        cmd.ExecuteNonQuery()
                        nCnt_update += 1
                    End If

                Catch ex As Exception
                    MessageBox.Show(ex.Message, "(Sunbae) - DB 업데이트 기능 에러 ", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Function
                End Try

#End Region

#Region "추가 하기(Insert into)"
                If num = 0 Then
                    sum_sql = sum_sql & "('" & ch & "','" & chC & "','" & pro & "','" & osu & "','" & suffix & "','" & model & "','" & sstep & "','" & cp & "',#" & Now() & "#),"
                    upchk = True
                    nCnt_insert += 1
                End If

            Next i

            If upchk = True Then
                sum_sql = sum_sql.Substring(0, Len(sum_sql) - 1)
                insert_sql = "INSERT INTO " & tbl & " (변경점, 변경점내용, Project, OSU, Suffix, Model, Step, Company, insert_date) 
                         VALUES " & sum_sql
                cmd.CommandText = insert_sql
                cmd.ExecuteNonQuery()   '// Insert into

            End If
#End Region


        Catch ex As Exception
            Database_Update_Func = True
            MessageBox.Show(ex.Message, "(Sunbae) - DB 올리기 에러", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally
            myCon.Close()
        End Try


        Database_Update_Func =
            "총 : " & nCnt_insert + nCnt_update & Environment.NewLine &
            "추가 됨 : " & nCnt_insert & Environment.NewLine &
            "수정 됨 : " & nCnt_update


        Return Database_Update_Func
    End Function
#End Region

#End Region
    Private Function remove_colon(ByVal s As String) As String
        Dim t As String
        t = Replace(s, "'", "")
        't = Replace(t, "*", "")
        s = t
        Return s
    End Function

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
        Dim frmPlan_Search As New pl_data_modify
        frmPlan_Search.Show()
    End Sub


#End Region
End Class