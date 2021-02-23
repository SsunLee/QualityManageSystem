Imports System.Diagnostics
Imports System.IO

Public Class TestTools
    Public strFilePath As String = Nothing
    Private szFile As String = Nothing

    Private Sub TestTools_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Icon = My.Resources.Qportal_Icon
        lst_Contents.Items.Clear()                  ' Contents 기존에 보여지던 ListBox 아이템 삭제 

        Dim XML As New XML
        XML.Folder_Path("Tool", strFilePath)        ' xml.vb에 담겨있는 Tool이라고 작성되어있는 Node 내용 가져오기 (경로 가져옴)
        XML = Nothing

        For Each entry As String In Directory.GetDirectories(strFilePath) ' 경로안을 for each문으로 반복
            ' GetDirectories(Path) <- 해당 Path에 있는 Folder 및 Files 찾음
            Dim dirA As DirectoryInfo = New DirectoryInfo(entry)          ' 디렉토리 지정
            lst_Contents.Items.Add(dirA.Name)                             ' ListBox에 내용 담음.
        Next
    End Sub

    '★ Folder Icon 선택 시 경로대로 파일탐색기 열어줌.
    Private Sub btn_oContents_Click(sender As Object, e As EventArgs) Handles btn_oContents.Click
        Process.Start("C:\Windows\explorer.exe ", String.Format("/n, /e, {0}", strFilePath))
    End Sub

    '★ Contents 부분 더블클릭 시 
    Private Sub lst_Contents_DoubleClick(sender As Object, e As EventArgs) Handles lst_Contents.DoubleClick
        For Each entry_Two As String In Directory.GetDirectories(strFilePath)

            Dim dirB As DirectoryInfo = New DirectoryInfo(strFilePath)          ' 디렉토리 지정

            For Each dra In dirB.GetDirectories()                               ' 지정한 디렉토리 내에서 반복
                If dra.Name = lst_Contents.Text Then  '                         ' List Box에 선택한 아이템 이름과 실제 경로의 폴더가 같으면 탐색기 실행
                    szFile = dirB.FullName & "\" & dra.Name
                    Process.Start("C:\Windows\explorer.exe ", String.Format("/n, /e, {0}", szFile))
                    Exit Sub
                End If
            Next
        Next

    End Sub

    Private Sub requestBtn_Click(sender As Object, e As EventArgs) Handles requestBtn.Click

    End Sub
End Class