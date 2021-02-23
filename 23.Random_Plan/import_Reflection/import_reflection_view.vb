Imports System.Data
Imports System.Data.OleDb
Imports System.Windows.Forms

Public Class Import_reflection_view
    Public strApp As String
    Public strPro As String
    Public strMod As String

    Public vConn As OleDbConnection
    Public ChangeAddTree As New Change_Add_Tree

    Public StrPath As String = "\\10.169.88.40\Q-Portal\2.검증현황\VP검증현황\Relection_DB.xlsx"

    Public ConnectionString As String = "Provider=Microsoft.Ace.OLEDB.12.0;Data Source=" & StrPath & ";Extended Properties=""Excel 12.0;HDR=YES;"""

#Region "최초 Base Form Load - Change_Add_Tree 정보 이용 해 Load 함."
    Private Sub Import_reflection_view_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '# Hard Coding 되어 있음.


        Dim result As DataTable = New DataTable
        Dim Sql As String
        Sql = "Select [App], [목적], [Type], [Reflection] FROM [Reflection_DB$]"
        Sql = Sql & " where [App] = '" & strApp & "' And [Project] = '" & strPro & "' And [Model] = '" & strMod & "' "

        Try
            Dim ds As DataSet = New DataSet     '# DataSet 생성
            ds = ImportDB(Sql, ConnectionString)    '# 만들어 둔 함수에 인자 값 넣어 실행

            DataGrid_Refelction.DataSource = ds.Tables(0)    '# Return 결과 물인 Dataset을 DataGrid View에 Binding함
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
#End Region

#Region "검색 해서 조회 하기 "
    Private Sub Btn_Search_Click(sender As Object, e As EventArgs) Handles Btn_Search.Click

        ' 검색하기
        Dim result As DataTable = New DataTable
        Dim Sql As String
        Dim Sql_App As String
        Dim Sql_Pro As String
        Dim Sql_Mod As String

        Sql_App = IIf(txt_App.Text = "", "", " And [App] LIKE '%" & Replace(txt_App.Text, "''", "") & "%'")
        Sql_Pro = IIf(txt_Project.Text = "", "", "And [Project] LIKE '%" & Replace(txt_Project.Text, "''", "") & "%'")
        Sql_Mod = IIf(txt_Model.Text = "", "", "And [Model] LIKE '%" & Replace(txt_App.Text, "''", "") & "%'")


        Sql = "Select [App], [목적], [Type], [Reflection],[Project], [Model], [Step] FROM [Reflection_DB$]"
        Sql = Sql & " where [App] <> '' " & Sql_App & Sql_Pro & Sql_Mod

        Dim ds As DataSet = New DataSet     '# DataSet 생성
        ds = ImportDB(Sql, ConnectionString)    '# 만들어 둔 함수에 인자 값 넣어 실행

        Dim chk As Boolean = False
        chk = ChkResult(ds)

        If chk = False Then
            Message_Response("검색 결과가 없습니다")
        End If

        DataGrid_Refelction.DataSource = ds.Tables(0)    '# Return 결과 물인 Dataset을 DataGrid View에 Binding함







    End Sub

#End Region

#Region "검색 결과 없음 Count"
    Private Function ChkResult(ByRef ds As DataSet) As Boolean
        Dim ch_bool As Boolean = False

        If ds.Tables(0).Rows.Count <= 0 Then
            ch_bool = False
        Else
            ch_bool = True
        End If

        ChkResult = ch_bool

    End Function

#End Region

#Region "엔터 키 쳤을 때 동작 하도록"
    Private Sub PressEnterKey(sender As Object, e As KeyPressEventArgs) Handles txt_Project.KeyPress, txt_Model.KeyPress, txt_App.KeyPress

        If e.KeyChar = Convert.ToChar(13) Then  ' ToChar <-- 13번 값은 Enter 임.
            Call Btn_Search_Click(sender, e)   ' 다른 프로시져 호출
        End If

    End Sub
#End Region

#Region "함수들"
    ' 쿼리로 DB 조회 후 DataSet에 담기
    Private Function ImportDB(ByRef sql As String, ByRef ConnectionString As String) As DataSet

        Dim vConn = New OleDbConnection(ConnectionString)   '# Connection
        Dim DS_return As DataSet = New DataSet                     '# Return 할 DataSet 
        Dim DS As DataSet

        Try
            Dim cmd As OleDbDataAdapter = New OleDbDataAdapter(sql, vConn)  '# 인자 값으로 받아온 sql과 , Connection String 
            DS = New DataSet    '# DataSet 생성
            cmd.Fill(DS)             '# DataAdapter로 Data Fill
            DS_return = DS        '# Data

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

        ImportDB = DS_return    '# 값 Return

    End Function

    Private Sub Message_Response(ByRef strKey As String)
        MessageBox.Show(strKey)
    End Sub



#End Region

End Class