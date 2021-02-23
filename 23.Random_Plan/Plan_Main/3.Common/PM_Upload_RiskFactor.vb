Imports System.Drawing
Imports System.Windows.Forms
Imports System.Data
Imports System.Data.OleDb
Imports System.Diagnostics



Public Class PM_Upload_RiskFactor
    Public ModelInfo As DataSet = New DataSet

#Region "폼 처음 로드될 때"
    Private Sub PM_Upload_RiskFactor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Panel2.AllowDrop = True
        Icon = My.Resources.Qportal_Icon
        btnDBUp.Visible = False
        DataGridView1.Visible = False

        With la_DragOver
            .Font = New Font("맑은 고딕", 12, FontStyle.Bold)
            '.ForeColor = Color.Gray
            .ForeColor = Color.FromArgb(125, 125, 125)
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
            btnDBUp.Visible = True

        End If

        If blCheck = False Then
            MessageBox.Show("올바른 파일을 올려주세요.")
        End If

    End Sub

#End Region

#Region "★ 엑셀 to DataGridView 함수"
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
        dt = vConn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, New Object() {Nothing, Nothing, Nothing, "TABLE"})

        Dim table_name As String = Nothing

        Try '# Sheet명 꺼내기
            table_name = dt.Rows(1).Item("Table_Name")
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
        proCmd = New System.Data.OleDb.OleDbDataAdapter("Select * FROM [" & table_name & "B4:F5]", vConn)

        Try
            DS = New DataSet
            myCmd.Fill(DS)      '# DataSet에 엑셀에 있는 내용 모두 담음(조회 된 Query)
            proCmd.Fill(ModelInfo)

            '# DataGridView에 Dataset Table 내용을 바인딩하여 넣음
            DataGridView1.DataSource = DS.Tables(0)
            Excel_File_to_DataGridView = True

        Catch ex As Exception
            System.Diagnostics.Debug.Print(ex.Message)
        Finally
            vConn.Close()
        End Try

        Return Excel_File_to_DataGridView

    End Function
#End Region

#Region "★ DataGridView to DB 함수"
    Private Function Database_Update(ByRef dt As DataTable) As String
        Dim Con As New Change_Add_Tree

        Dim sApp As String, sFea As String, sName As String, sPMD As String, sHMD As String
        Dim sCh As String, sChC As String, sRisk As String, sChHow As String, sRand1 As String, sRand1_cont As String
        Dim sRand2 As String, sRand2_cont As String, sComment As String
        Dim sPro As String, sMod As String, sStep As String, sBuyer As String, sCompany As String

        Dim proTable As DataTable = New DataTable

        '# 모델 정보 
        proTable = ModelInfo.Tables(0)
        sPro = proTable.Rows(0).Item("Project")
        sMod = proTable.Rows(0).Item("Model")
        sStep = proTable.Rows(0).Item("차수")
        sBuyer = proTable.Rows(0).Item("사업자")
        sCompany = proTable.Rows(0).Item("업체명")


        Dim nCnt_insert As Integer = 0
        Dim nCnt_update As Integer = 0

        Dim DA As System.Data.OleDb.OleDbDataAdapter = New System.Data.OleDb.OleDbDataAdapter
        Dim vConn = New System.Data.OleDb.OleDbConnection(Con.strCon)   ' MainForm의 Connection String으로 DB Connect
        vConn.Open()
        Try
            For i As Integer = 0 To dt.Rows.Count - 1

                'sMajorChange = IIf(IsDBNull(dt.Rows(i).Item("변경점")), " ", dt.Rows(i).Item("변경점"))
                'sMajorChange = Replace(sMajorChange, "'", "")
                'sMajorChange = LTrim(sMajorChange)

                sApp = IIf(IsDBNull(dt.Rows(i).Item("App Name")), "앱 없음", dt.Rows(i).Item("App Name"))
                sFea = IIf(IsDBNull(dt.Rows(i).Item("Feature")), "정보없음", dt.Rows(i).Item("Feature"))
                sName = IIf(IsDBNull(dt.Rows(i).Item("담당자")), "정보없음", dt.Rows(i).Item("담당자"))
                sPMD = IIf(IsDBNull(dt.Rows(i).Item("필요 M/D")), "정보없음", dt.Rows(i).Item("필요 M/D"))
                sHMD = IIf(IsDBNull(dt.Rows(i).Item("할당 M/D")), "정보없음", dt.Rows(i).Item("할당 M/D"))

                '# 변경점
                'sCh = dt.Rows(i).Item("변경점")
                sCh = IIf(IsDBNull(dt.Rows(i).Item("변경점")), "변경점 없음", dt.Rows(i).Item("변경점"))
                sCh = LTrim(sCh)
                sCh = Replace(sCh, "'", "")
                sCh = Replace(sCh, """", "")

                'sChC = dt.Rows(i).Item("변경점 내용")
                sChC = IIf(IsDBNull(dt.Rows(i).Item("변경점 내용")), "변경점내용 없음", dt.Rows(i).Item("변경점 내용"))
                sChC = Replace(sChC, "'", "")
                sChC = Replace(sChC, """", "")
                sChC = LTrim(sChC)

                'sRisk = dt.Rows(i).Item("Risk Factor")
                sRisk = IIf(IsDBNull(dt.Rows(i).Item("Risk Factor")), "작성 된 Risk Factor 없음", dt.Rows(i).Item("Risk Factor"))
                sRisk = LTrim(sRisk)
                sRisk = Replace(sRisk, "'", "")
                sRisk = Replace(sRisk, """", "")

                ' sChHow = dt.Rows(i).Item("변경점 검증방법")
                sChHow = IIf(IsDBNull(dt.Rows(i).Item("변경점 검증방법")), "작성 된 변경점 검증방법 없음", dt.Rows(i).Item("변경점 검증방법"))
                sChHow = LTrim(sChHow)
                sChHow = Replace(sChHow, "'", "")
                sChHow = Replace(sChHow, """", "")

                sRand1 = "Random_변경점"

                'sRand1_cont = dt.Rows(i).Item("주요 점검 사항(검증원)")
                sRand1_cont = IIf(IsDBNull(dt.Rows(i).Item("주요 점검 사항(검증원)")), "점검내용 없음", dt.Rows(i).Item("주요 점검 사항(검증원)"))
                sRand1_cont = Replace(sRand1_cont, "'", "")
                sRand1_cont = Replace(sRand1_cont, """", "")
                sRand1_cont = LTrim(sRand1_cont)

                sRand2 = "Random_변경점x"

                ' sRand2_cont = dt.Rows(i).Item("주요 점검 사항(검증원)1")
                sRand2_cont = IIf(IsDBNull(dt.Rows(i).Item("주요 점검 사항(검증원)1")), "점검내용 없음", dt.Rows(i).Item("주요 점검 사항(검증원)1"))
                sRand2_cont = LTrim(sRand2_cont)
                sRand2_cont = Replace(sRand2_cont, "'", "")
                sRand2_cont = Replace(sRand2_cont, """", "")


                'sComment = dt.Rows(i).Item("Lesson Learn(추가 검증 필요 사항)")
                sComment = IIf(IsDBNull(dt.Rows(i).Item("Lesson Learn(추가 검증 필요 사항)")), "없음", dt.Rows(i).Item("Lesson Learn(추가 검증 필요 사항)"))
                sComment = LTrim(sComment)
                sComment = Replace(sComment, "'", "")
                sComment = Replace(sComment, """", "")

                sPro = LTrim(sPro)
                sMod = LTrim(sMod)
                sStep = LTrim(sStep)
                sBuyer = LTrim(sBuyer)

                ' 기존 Data 있는지 Check 하기 위한 Query 작성
                Dim vSQL_App As String = Nothing, vSQL_Feature As String = Nothing
                Dim vSQL2_Change As String = Nothing
                Dim vSQL_Pro As String = Nothing, vSQL_Mod As String = Nothing
                Dim vSQL_TestType As String = Nothing, vSQL_Buyer As String = Nothing

                ' 기존 Data 있는지 Check 하기 위한 Query 작성
                vSQL_App = " [App Name] = '" & Replace(sApp, "'", "''") & "'"
                vSQL_Feature = " AND [Feature] = '" & sFea & "'"
                vSQL2_Change = " AND [변경점] = '" & Replace(sCh, "'", "''") & "'"

                vSQL_Pro = " AND [Project] = '" & sPro & "'"
                vSQL_Mod = " AND [Model] = '" & sMod & "'"
                vSQL_TestType = " AND [차수] = '" & sStep & "'"
                vSQL_Buyer = " AND [사업자] = '" & sBuyer & "'"

                '이미 DB에 있는 것 인지? Check 함
                Dim sSQL As String
                sSQL = "SELECT * "
                sSQL = sSQL & "FROM 검계_DB "
                sSQL = sSQL & "WHERE " & vSQL_App & vSQL_Feature & vSQL2_Change & vSQL_Pro & vSQL_Mod & vSQL_TestType & vSQL_Buyer

                Dim sql As String = Nothing

                Dim myCmd As OleDbCommand
                Dim check As Integer

                Dim result As DataTable = New DataTable
                Dim cmd As OleDbCommand = New OleDbCommand(sSQL, vConn)
                '     ▼▼ Data Adapter를 사용해 Data Table을 만들고 Query 된 Result를 Count 하여 기존 Data가 있는지 Check 
                Dim adapter As OleDbDataAdapter = New OleDbDataAdapter(cmd)
                adapter.Fill(result)

                '    ▼▼  만약 조회가 안 됐다면 ?  새 항목
                If result.Rows.Count = 0 Then
                    ' is it insert
                    sql = "INSERT INTO 검계_DB ("
                    sql = sql & "[App Name],  Feature, 검증원, 필요MD, [할당 M/D], 변경점, [변경점 내용], [Risk Factor],"
                    sql = sql & " [변경점 검증방법], 검증유형, 주요점검사항, 검증유형2, 주요점검사항2, LessonLearn, Project, Model, 차수, 사업자, 업체명, 파일명"
                    sql = sql & ") values("
                    sql = sql & "'" & sApp & "','" + sFea + "','" + sName + "','" + sPMD + "','" + sHMD + "','" + sCh + "','" + sChC + "','" + sRisk + "','" + sChHow
                    sql = sql & "','" & sRand1 + "','" + sRand1_cont + "','" + sRand2 + "','" + sRand2_cont + "','" + sComment + "','" + sPro + "','" + sMod + "','" + sStep + "','" + sBuyer + "','" + sCompany + "','" + "큐포탈" + "');"

                    'Debug.Print(sql)
                    myCmd = New OleDbCommand(sql, vConn)
                    check = myCmd.ExecuteNonQuery()
                    nCnt_insert += 1

                Else '◀◀ 기존 데이터와 덮어쓰기 해야 한다면

                    sql = "UPDATE 검계_DB SET "
                    sql = sql & "[App Name] ='" & sApp & "', "
                    sql = sql & "[Feature] ='" & sFea & "', "
                    sql = sql & "[검증원] ='" & sName & "', "
                    sql = sql & "[필요MD] ='" & sPMD & "', "
                    sql = sql & "[할당 M/D] ='" & sHMD & "', "
                    sql = sql & "[변경점] ='" & sCh & "', "
                    sql = sql & "[변경점 내용] ='" & sChC & "', "
                    sql = sql & "[Risk Factor] ='" & sRisk & "', "
                    sql = sql & "[변경점 검증방법] ='" & sChHow & "', "
                    sql = sql & "[검증유형] ='" & sRand1 & "', "
                    sql = sql & "[주요점검사항] ='" & sRand1_cont & "', "

                    sql = sql & "[검증유형2] ='" & sRand2 & "', "
                    sql = sql & "[주요점검사항2] ='" & sRand2_cont & "', "

                    sql = sql & "[LessonLearn] ='" & sComment & "', "

                    sql = sql & "[Project] ='" & sPro & "', "
                    sql = sql & "[Model] ='" & sMod & "', "
                    sql = sql & "[차수] ='" & sStep & "', "
                    sql = sql & "[사업자] ='" & sBuyer & "', "
                    sql = sql & "[업체명] ='" & sCompany & "'"

                    sql = sql & " WHERE [App Name] = '" & sApp & "' And Feature = '" & sFea & "' And 변경점 = '" & sCh & "' And Project = '" & sPro & "' And Model = '" & sMod & "' And 차수 = '" & sStep & "' And 사업자 = '" & sBuyer & "'"
                    Debug.Print(sql)
                    myCmd = New OleDbCommand(sql, vConn)
                    check = myCmd.ExecuteNonQuery()
                    nCnt_update += 1
                End If



            Next

        Catch ex As Exception
            Database_Update = True
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
        Dim Con As New Change_Add_Tree
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

        vConn = New OleDbConnection(Con.strCon)

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