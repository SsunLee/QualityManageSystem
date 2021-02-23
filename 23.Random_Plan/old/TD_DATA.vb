Imports System.Data
Imports System.Data.OleDb
Imports System.IO
Imports System.Windows.Forms

Public Class TD_DATA
    Private DS As DataSet = New DataSet
    Private DA As OleDbDataAdapter = New OleDbDataAdapter()
    Private vConn As OleDbConnection



    Private Sub TD_DATA_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        '[디렉토리 정보] Local 주소 Root 변수에 담아야 함.
        Dim blChk As Boolean = False
        Dim szFileName As String = Nothing
        Dim szRoot As String = Path.GetPathRoot(Application.StartupPath)
        szRoot = szRoot & "\" & "Upload_TD"

        If Not Directory.Exists(szRoot) Then    ' 경로에 폴더가 없으면? 생성
            Directory.CreateDirectory(szRoot)
        End If

        'TD 파일 찾기
        Dim dirA As DirectoryInfo = New DirectoryInfo(szRoot)    ' 디렉토리 지정

        For Each dra In dirA.GetFiles()     ' For each를 통해 폴더 내의 파일을 찾음
            Dim szTemp As String = dra.Name
            'If InStrRev(Trim(dra.Name), RTrim(txt_Model.Text)) And Strings.Left(szTemp, 2) <> "~$" Then  ' Consumer TC와 Kernel TC / Framework TC의 파일 Naming이 다름
            If InStrRev(Trim(dra.Name), RTrim("G600L")) And Strings.Left(szTemp, 2) <> "~$" Then  ' Consumer TC와 Kernel TC / Framework TC의 파일 Naming이 다름
                szFileName = dra.Name
                blChk = True
            End If

        Next

        '파일 못찾았을 때 예외처리 
        If blChk = False Then
            MsgBox(szRoot & " <-- 경로에 TD엑셀파일이 없는 것 같습니다. 파일명을 모델명과 맞추고 올려주세요.")
            Exit Sub
        End If

        Dim strOpenPath As String = szRoot & "\" & szFileName
        Dim strSht As String

        Try
            Dim szXl As String = "Provider=Microsoft.Ace.OLEDB.12.0;Data Source=" & strOpenPath & ";Extended Properties=""Excel 12.0;HDR=YES;"""
            strSht = "Sheet1"

            Dim szSQL As String = "SELECT [Defect ID],[Summary],[Description],[Group Name] FROM [" & strSht & "$A1:ZZ50000]" & " order by [Defect ID] asc"

            DS.Clear()

            vConn = New OleDbConnection(szXl)

            DA = New OleDbDataAdapter(szSQL, vConn)
            DA.Fill(DS, strSht)
            Dim table As DataTable = DS.Tables(0)

            DataGridView1.DataSource = Nothing
            If table.Rows.Count = 0 Then
                MsgBox("조회할 내용이 없습니다.",, "lee.sunbae@lgepartner.com")
                Exit Sub
            End If

            'Dim i, j As Integer

            'Data Grid View 초기 모드 해제
            DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None

            DataGridView1.DataSource = table

            DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill


            ' 기본 값과 셋팅 설정
            With DataGridView1
                .SelectionMode = DataGridViewSelectionMode.FullRowSelect
                .MultiSelect = False
                '.AutoResizeColumns()
                '.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells ' Column size Auto
                '.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells       ' Row Size Auto
                '.DefaultCellStyle.WrapMode = DataGridViewTriState.True  ' Data Grid View Multi Line

                '.AllowUserToResizeColumns = True
                '.AllowUserToResizeRows = True
            End With



        Catch ex As Exception
            MsgBox(ex.Message)
        End Try



    End Sub

    Private Sub Panel4_Paint(sender As Object, e As PaintEventArgs)

    End Sub
End Class