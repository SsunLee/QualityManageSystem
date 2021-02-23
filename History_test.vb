Imports System.Data
Imports System.Data.OleDb
Imports System.Windows.Forms

Public Class History_test
    Private SQL_App As String
    Private DS_App As DataSet = New DataSet
    Private DA_App As OleDbDataAdapter = New OleDbDataAdapter()
    Private vConnApp As OleDbConnection = New OleDbConnection

    'Private Local_Admin As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\신창하\업무\Task\Test_db\admin\QPortalDB_Admin.accdb;Jet OLEDB:Database Password = lge1234;"
    Private Local_Admin As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=\\10.169.88.40\Q-Portal\5.Admin(AccessDB)\QPortalDB_Admin.accdb;Jet OLEDB:Database Password = lge1234;"

    Private HistoryApp As String = "History_App"







    Private Sub History_test_Load(sender As Object, e As EventArgs) Handles MyBase.Load



    End Sub

    Private Sub gridApp_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles gridApp.CellContentClick

    End Sub

    Private Sub TabPage1_Enter(sender As Object, e As EventArgs) Handles TabPage1.Enter


        'DataGridView 속성값 설정
        With gridApp
            .ReadOnly = True
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            .AllowUserToResizeColumns = True
            .AllowUserToResizeRows = True
            .MultiSelect = False
        End With

        'History App DB Query 문
        SQL_App = "Select * From [" & HistoryApp & "]" & "Order By [ID] ASC"
        If gridApp.Rows.Count = 0 Then
            DS_App.Clear()

            Try

                vConnApp = New OleDbConnection(Local_Admin)
                DA_App = New OleDbDataAdapter(SQL_App, vConnApp)
                DA_App.Fill(DS_App, HistoryApp)

                Dim Table As DataTable = DS_App.Tables(HistoryApp)
                gridApp.DataSource = Table
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub
End Class