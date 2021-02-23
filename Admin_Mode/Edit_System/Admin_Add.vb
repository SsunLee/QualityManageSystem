Imports System.Data
Imports System.Data.OleDb
Imports System.Windows.Forms

Public Class Admin_Add


    Private Sub Admin_Add_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '-------------------------------------------------------
        ' 제 작 : 이순배
        ' 내 용 : DB 연결하여 DataGridView에 넣기 with Bind
        '-------------------------------------------------------

        'STEP 1) Connection String 가져오기
        Dim vCon As String = Nothing
        Dim xml As New XML

        ' 하드코딩 #1
        'dim vCon As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=\\10.169.88.40\Q-Portal\0.AccessDB\QPortalDB.accdb;Jet OLEDB:Database Password = lge1234;"

        ' XML 에서 가져옴 #2
        xml.vCon_Admin_Call(vCon)

        'STEP 2) 쿼리 작성 하기
        Dim sSQL As String = "SELECT ID, A_NAME FROM Admin_Name"
        sSQL = sSQL & " WHERE [ID] > 0 "


        'STEP 3) 연결 할 DB의 Connection 선언 
        Dim vConn As OleDbConnection = New OleDbConnection
        vConn = New OleDbConnection(vCon)


        Dim cmd As OleDbCommand = New OleDbCommand(sSQL, vConn)
        Dim result As DataTable = New DataTable
        Dim adapter As OleDbDataAdapter = New OleDbDataAdapter(cmd)
        adapter.Fill(result)     ' 새로운 Datatable에 조회 된 값 채움 만약 비어 있으면 New, 채워져 있다면 기존에 있는 것

        DataGridView1.DataSource = result


    End Sub
    Private Sub reload_DataGridView(sender As Object, e As EventArgs)
        '-------------------------------------------------------
        ' 제 작 : 이순배
        ' 내 용 : DB 연결하여 DataGridView에 넣기 with Bind
        '-------------------------------------------------------

        'STEP 1) Connection String 가져오기
        Dim vCon As String = Nothing
        Dim xml As New XML

        ' 하드코딩 #1
        'dim vCon As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=\\10.169.88.40\Q-Portal\0.AccessDB\QPortalDB.accdb;Jet OLEDB:Database Password = lge1234;"

        ' XML 에서 가져옴 #2
        xml.vCon_Admin_Call(vCon)

        'STEP 2) 쿼리 작성 하기
        Dim sSQL As String = "SELECT ID, A_NAME FROM Admin_Name"
        sSQL = sSQL & " WHERE [ID] > 0 "


        'STEP 3) 연결 할 DB의 Connection 선언 
        Dim vConn As OleDbConnection = New OleDbConnection
        vConn = New OleDbConnection(vCon)
        vConn.Open()

        Dim cmd As OleDbCommand = New OleDbCommand(sSQL, vConn)
        Dim result As DataTable = New DataTable
        Dim adapter As OleDbDataAdapter = New OleDbDataAdapter(cmd)
        adapter.Fill(result)     ' 새로운 Datatable에 조회 된 값 채움 만약 비어 있으면 New, 채워져 있다면 기존에 있는 것

        vConn.Close()

        Dim reload_Table As DataTable = New DataTable
        reload_Table.Rows.Clear()
        reload_Table.Columns.Clear()
        DataGridView1.DataSource = reload_Table

        DataGridView1.DataSource = result




    End Sub


    Private Sub DataGridView1_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentDoubleClick
        '-------------------------------------------------------
        ' 제 작 : 이순배
        ' 내 용 : DataGridView 클릭 시 TextBox에 주소 뿌려주기
        '-------------------------------------------------------

        '■ STEP 1) 기본 값 지우기
        txtID.Text = ""
        txtAddress_Del.Text = ""

        '■ STEP 2) 현재 선택 한 값 가져오기
        txtID.Text = DataGridView1.SelectedCells(0).Value
        txtAddress_Del.Text = DataGridView1.SelectedCells(1).Value

    End Sub

    Private Sub btnDel_Click(sender As Object, e As EventArgs) Handles btnDel.Click
        '-------------------------------------------------------
        ' 제 작 : 이순배
        ' 내 용 : "삭제" 눌렀을 때 삭제 되도록 !
        '-------------------------------------------------------

        Try
            '■ STEP 1) Connection String 가져오기
            Dim vCon As String = Nothing
            Dim xml As New XML

            ' 하드코딩 #1
            'dim vCon As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=\\10.169.88.40\Q-Portal\0.AccessDB\QPortalDB.accdb;Jet OLEDB:Database Password = lge1234;"

            ' XML 에서 가져옴 #2
            xml.vCon_Admin_Call(vCon)


            '■ STEP 2) 쿼리 작성 하기
            Dim Sql As String = "DELETE "
            Sql = Sql & "FROM Admin_Name "
            Sql = Sql & "WHERE ID = " & CInt(txtID.Text)


            '■ STEP 3) 연결 할 DB의 Connection 선언 
            Dim vConn As OleDbConnection = New OleDbConnection
            vConn = New OleDbConnection(vCon)
            vConn.Open()

            '■ STEP 4) 쿼리 실행
            Dim myCmd As OleDbCommand = New OleDbCommand(Sql, vConn)
            Dim check As Integer = myCmd.ExecuteNonQuery()
            vConn.Close()

            Call reload_DataGridView(sender, e)


            CreateObject("WScript.Shell").Popup("삭제 완료 하였습니다." & vbCrLf & txtAddress_Del.Text & " 님", 1, "lee.sunbae@lgepartner.com")

            '삭제 한 내용 지우기
            txtAddress_Del.Text = ""
            txtID.Text = ""

        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try




    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        '-------------------------------------------------------
        ' 제 작 : 이순배
        ' 내 용 : "추가" 눌렀을 때 동작 되도록 !
        '-------------------------------------------------------

        Try
            '■ STEP 1) Connection String 가져오기
            Dim vCon As String = Nothing
            Dim xml As New XML

            ' 하드코딩 #1
            'dim vCon As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=\\10.169.88.40\Q-Portal\0.AccessDB\QPortalDB.accdb;Jet OLEDB:Database Password = lge1234;"

            ' XML 에서 가져옴 #2
            xml.vCon_Admin_Call(vCon)

            '■ STEP 2) 쿼리 작성 하기
            Dim Sql As String = "INSERT INTO Admin_Name (A_NAME) "
            Sql = Sql & "VALUES('" & txtAddress_Add.Text & "');"

            '■ STEP 3) 연결 할 DB의 Connection 선언 
            Dim vConn As OleDbConnection = New OleDbConnection
            vConn = New OleDbConnection(vCon)
            vConn.Open()

            '■ STEP 4) 쿼리 실행
            Dim myCmd As OleDbCommand = New OleDbCommand(Sql, vConn)
            Dim check As Integer = myCmd.ExecuteNonQuery()
            vConn.Close()

            Call reload_DataGridView(sender, e)

            CreateObject("WScript.Shell").Popup("추가 완료 하였습니다." & vbCrLf & txtAddress_Add.Text & " 님", 1, "lee.sunbae@lgepartner.com")

            '동작 한 내용 지우기
            txtAddress_Add.Text = ""
            txtID.Text = ""


        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try

    End Sub


End Class