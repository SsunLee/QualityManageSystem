Imports MySql.Data.MySqlClient

Public Class plan_class
    Private chkValue As Boolean
    Private mainTable As String = "td_defect"
    Public strSQLCon As String = "Server=10.169.88.40;Uid=rs_user;Pwd=lge1234;Database=td_defect"
    Private mySQLCon As New MySqlConnection(strSQLCon)
    Private name As String
    Public dt_table As Data.DataTable

    Public Sub New()
    End Sub
    Public Sub New(ByVal ch As Boolean)
        chkValue = ch
    End Sub

    Property _setChk As Boolean
        Get
            Return Me.chkValue
        End Get
        Set(value As Boolean)
            chkValue = value
        End Set
    End Property

    Property _dt_tables As Data.DataTable
        Get
            Return Me.dt_table
        End Get
        Set(value As Data.DataTable)
            dt_table = value
        End Set
    End Property


    Public Function setChk(ch As Boolean) As Boolean
        Me.chkValue = ch
        Return ch
    End Function
    Public Function getChk() As Boolean
        Return chkValue
    End Function
    Public Function getTableName() As String
        Return Me.mainTable
    End Function

#Region "★ get User Name ★"
    Public Function getUserName() As String
        Dim strCom As String = "."
        Dim strName As String = Nothing
        Dim obj = GetObject("winmgmts:{impersonationLevel=impersonate}!\\" & strCom & "\root\cimv2").ExecQuery("Select * FROM Win32_OperatingSystem")
        For Each Obj2 In obj
            strName = Obj2.Description
        Next
        strName = Strings.Split(strName, "/")(0)
        Me.name = strName
        getUserName = strName

        Return getUserName

    End Function

#End Region

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




End Class
