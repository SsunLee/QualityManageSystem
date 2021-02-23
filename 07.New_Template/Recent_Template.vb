Imports System.Data.OleDb
Imports System.Diagnostics
Imports System.IO
Public Class Recent_Template
    Public strFilePath As String = Nothing ' "\\10.174.51.33\Q-Portal\최신Template"
    Private vConn As OleDbConnection
    Public strFile As String = Nothing
    Public XML As New XML

    Private Sub Recent_Template_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Icon = My.Resources.Qportal_Icon
        lst_List.Items.Clear()                                           ' Load 될 때 ListBox 초기화

        XML.Folder_Path("Template", strFilePath)
        XML = Nothing

        '★ 리스트에 폴더명 뿌려줌.
        For Each entry As String In Directory.GetDirectories(strFilePath) ' GetDirectories(Path) <- 해당 Path에 있는 Folder 및 Files 찾음
            Dim dirA As DirectoryInfo = New DirectoryInfo(entry)          ' 디렉토리 지정
            lst_List.Items.Add(dirA.Name)                                 ' dirA.name 은 폴더명 
        Next

    End Sub
    Private Sub lst_List_DoubleClick(sender As Object, e As EventArgs) Handles lst_List.DoubleClick
        ' Openling Explorer When Double Click 
        Dim szFile As String = strFilePath & "\" & lst_List.Text
        Process.Start("C:\Windows\explorer.exe ", String.Format("/n, /e, {0}", szFile))

    End Sub

    Private Sub btn_oContents_Click(sender As Object, e As EventArgs) Handles btn_oContents.Click
        '★ 폴더 아이콘 선택 시 경로 열어줌
        Process.Start("C:\Windows\explorer.exe ", String.Format("/n, /e, {0}", strFilePath))
    End Sub

    Private Sub requestBtn_Click(sender As Object, e As EventArgs) Handles requestBtn.Click

    End Sub
End Class