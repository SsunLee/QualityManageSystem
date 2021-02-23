Imports System.Data
Imports System.Data.OleDb
Imports System.Diagnostics
Imports System.IO

Public Class Contents_form
    Private DS As DataSet = New DataSet
    Private DA As OleDbDataAdapter = New OleDbDataAdapter()
    Public ordAdapter As OleDbDataAdapter = New OleDbDataAdapter()
    Private strSQL As String
    'Public szFilePath As String = Nothing
    Public strFilePath As String = Nothing
    Private vConn As OleDbConnection
    Public strFile As String = Nothing
    Private szBack As String = Nothing
    Private szNext As String = Nothing

    '★ 처음 폼 load될 때
    Private Sub Contents_form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lst_Contents.Items.Clear()                                        ' 기존 내용 삭제

        Dim XML As New XML
        XML.Folder_Path("Contents", strFilePath)                          ' xml.vb에서 경로 가져옴 ex) 10.174.51.33\검증컨텐츠
        XML = Nothing

        For Each entry As String In Directory.GetDirectories(strFilePath) ' GetDirectories(Path) <- 해당 Path에 있는 Folder 및 Files 찾음
            Dim dirA As DirectoryInfo = New DirectoryInfo(entry)          ' 디렉토리 지정
            lst_Contents.Items.Add(dirA.Name)                             ' ListBox에 아이템 추가 
        Next

    End Sub

    Private Sub btn_Write_Click(sender As Object, e As EventArgs) Handles btn_oContents.Click
        ' 폴더 선택 시 지정 된 경로로 열어 주기 열기
        Process.Start("C:\Windows\explorer.exe ", String.Format("/n, /e, {0}", strFilePath))
    End Sub

    '★★ 컨텐츠 구분 선택 시 하위 폴더 보여주는 부분
    Private Sub lst_Contents_Click(sender As Object, e As EventArgs) Handles lst_Contents.Click
        ' Openling Explorer When Double Click 
        Dim blchk As Boolean = True
        Dim szFile As String = Nothing
        Dim szFnd_Name As String = Nothing

        lst_submenu.Items.Clear()   ' 기존 List Init
        For Each entry_Two As String In Directory.GetDirectories(strFilePath & "\" & lst_Contents.Text)   ' 지정경로 + 선택한 폴더 내의 폴더명 뿌려주기 위함.
            Dim dirB As DirectoryInfo = New DirectoryInfo(entry_Two)    ' 디렉토리 지정
            lst_submenu.Items.Add(dirB.Name)                            ' ListBox에 아이템 추가
        Next
    End Sub
    '★ 하위 ListBox의 아이템 더블 클릭 시 경로에 있는 폴더 열어줌.
    Private Sub lst_submenu_DoubleClick(sender As Object, e As EventArgs) Handles lst_submenu.DoubleClick

        Dim szOpenPath As String = strFilePath & "\" & lst_Contents.Text & "\" & lst_submenu.Text
        '                            경로         +      상위 폴더명         +   마지막 폴더 명
        Process.Start("C:\Windows\explorer.exe ", String.Format("/n, /e, {0}", szOpenPath))
        'Process.Start("C:\Windows\explorer.exe", "/select," + String.Format("/n, /e, {0}", szOpenPath))

    End Sub

    Private Sub requestBtn_Click(sender As Object, e As EventArgs) Handles requestBtn.Click

    End Sub
End Class