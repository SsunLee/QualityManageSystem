Public Class Table_class

    Private mainTable As String = "td_defect"
    Private save

    Private name As String
    Private compnay As String
    Private tel As String


    Public Sub Table_Class(mergeTable As String)
    End Sub

    Public Function getTable(mergeTable As String) As String
        getTable = mainTable + "." + mergeTable
        Return getTable
    End Function


#Region "★ get User Name ★"
    Public Function getUserName() As String
        Return name
    End Function
    Public Sub setUserName()
        Dim strCom As String = "."
        Dim strName As String = Nothing
        Dim obj = GetObject("winmgmts:{impersonationLevel=impersonate}!\\" & strCom & "\root\cimv2").ExecQuery("Select * FROM Win32_OperatingSystem")
        For Each Obj2 In obj
            strName = Obj2.Description
        Next
        name = Strings.Split(strName, "/")(0)

    End Sub

#End Region

#Region "업체명 구하기"
    Public Function getCompnay() As String
        Return compnay
    End Function
    Public Sub setCompany(ByRef User As String)
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
            Exit Sub
        End Try

        Try '// data reader 사용

            reader = mySQLCmd.ExecuteReader()
        Catch ex As Exception
            Diagnostics.Debug.Print(ex.Message & Environment.NewLine & "기존 DB조회 오류_reader 오류")
        End Try


        Try
            While reader.Read
                Diagnostics.Debug.Print(reader(2))
                FindCompany = reader(2)
                blcp = False
            End While
        Catch ex As Exception
            Diagnostics.Debug.Print(ex.Message & Environment.NewLine & "기존 DB조회 오류_reader 오류")
        Finally
            reader.Close()
        End Try


        If blcp = True Then
            compnay = "미등록 사용자"
        Else
            compnay = FindCompany
        End If

    End Sub
#End Region
#Region "휴대폰 번호"
    Public Function getTel() As String
        Return tel
    End Function
    Public Sub setTel(ByRef User As String)
        Dim FindNumber As String = Nothing

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
                SELECT 'A' AS table_name, 이름, 업체, 휴대폰 FROM td_defect.contacts_c
                UNION ALL
                SELECT 'B',이름, 업체, 휴대폰 FROM td_defect.contacts_i
                UNION ALL
                SELECT 'C',이름, 업체, 휴대폰 FROM td_defect.contacts_m
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
            Exit Sub
        End Try

        Try '// data reader 사용

            reader = mySQLCmd.ExecuteReader()
        Catch ex As Exception
            Diagnostics.Debug.Print(ex.Message & Environment.NewLine & "기존 DB조회 오류_reader 오류")
        End Try


        Try
            While reader.Read
                Diagnostics.Debug.Print(reader(3))
                FindNumber = reader(3)
                blcp = False
            End While
        Catch ex As Exception
            Diagnostics.Debug.Print(ex.Message & Environment.NewLine & "기존 DB조회 오류_reader 오류")
        Finally
            reader.Close()
        End Try


        If blcp = True Then
            tel = "미등록 사용자"
        Else
            tel = FindNumber
        End If

    End Sub
#End Region

    Private fieldName As String
    Private lst As System.Windows.Forms.ListBox
    Public Function setField(fieldName As String)
        Me.fieldName = fieldName
        Return fieldName
    End Function
    Public Function setListView(lst As System.Windows.Forms.ListBox)
        Me.lst = lst
        Return lst
    End Function
    Public Function getFieldText() As String
        Return Me.fieldName
    End Function

    Public Sub setListItem(lst As System.Windows.Forms.ListBox, dt As System.Data.DataTable)
        For i As Integer = 0 To dt.Rows.Count - 1
            If Not lst.Items.Contains(dt.Rows(i)(fieldName)) Then
                lst.Items.Add(dt.Rows(i)(fieldName))
            End If
        Next

    End Sub



End Class
