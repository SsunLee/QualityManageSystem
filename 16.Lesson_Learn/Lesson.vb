Imports System.Data
Imports System.Data.OleDb
Imports System.IO

Public Class Lesson
    Private DS As DataSet = New DataSet
    Private DA As OleDbDataAdapter = New OleDbDataAdapter()
    Public ordAdapter As OleDbDataAdapter = New OleDbDataAdapter()
    Private strSQL As String
    Public strFilePath As String = Nothing '"\\10.174.51.33\Q-Portal\대책서"
    Public szFilePath As String = Nothing
    Private vConn As OleDbConnection
    Public strFile As String = Nothing

    Private Sub Contents_form_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        lst_Year.Items.Clear()
        lst_box.Items.Clear()
        lst_App.Items.Clear()

        Dim XML As New XML
        XML.Folder_Path("LL", strFilePath)
        XML = Nothing


        For Each entry As String In Directory.GetDirectories(strFilePath)
            ' GetDirectories(Path) <- 해당 Path에 있는 Folder 및 Files 찾음
            Dim dirA As DirectoryInfo = New DirectoryInfo(entry)    ' 디렉토리 지정
            lst_Year.Items.Add(dirA.Name)
        Next


    End Sub

    Private Sub btn_Write_Click(sender As Object, e As EventArgs)
        ' 폴더 열기
        Try

            Dim szFile As String = Nothing

            For Each entry As String In Directory.GetDirectories(strFilePath)        ' GetDirectories(Path) <- 해당 Path에 있는 Folder 및 Files 찾음
                ' 지정 한 경로를 반복 하면서 경로와 '구분'명과 일치하는 폴더를 찾음.
                ' 찾은 경로로 진입 하여 그 안의 파일명을 찾는다.
                Dim dirA As DirectoryInfo = New DirectoryInfo(entry)    ' 디렉토리 지정
                If dirA.Name = "컨텐츠" Then
                    szFile = entry
                    Exit For
                End If
            Next

            Shell("C:\Windows\explorer.exe " & szFile, AppWinStyle.NormalFocus)

        Catch ex As Exception
            MsgBox(ex.Message) ' "lee.sunbae@lgepartner.com")
        End Try
    End Sub

    '제안하기 뒤에 숨어있음
    Private Sub btn_Search_Click(sender As Object, e As EventArgs) Handles btn_oTool.Click
        ' 폴더 열기

        Try
            Dim szFileT As String = Nothing
            'For Each entry As String In Directory.GetDirectories(strFilePath)        ' GetDirectories(Path) <- 해당 Path에 있는 Folder 및 Files 찾음
            '    ' 지정 한 경로를 반복 하면서 경로와 '구분'명과 일치하는 폴더를 찾음.
            '    ' 찾은 경로로 진입 하여 그 안의 파일명을 찾는다.
            '    Dim dirA As DirectoryInfo = New DirectoryInfo(entry)    ' 디렉토리 지정
            '    If dirA.Name = lst_Year.Text Then
            '        szFileT = entry
            '        Exit For
            '    End If
            'Next

            Shell("C:\Windows\explorer.exe " & strFilePath, AppWinStyle.NormalFocus)
        Catch ex As Exception
            MsgBox(ex.Message, "lee.sunbae@lgepartner.com")
        End Try

    End Sub

    Private Sub lst_Year_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lst_Year.SelectedIndexChanged
        lst_box.Items.Clear()
        lst_App.Items.Clear()
        'lst_Fea.Items.Clear()
        szFilePath = strFilePath & "\" & lst_Year.Text
        For Each entry As String In Directory.GetDirectories(szFilePath)
            ' GetDirectories(Path) <- 해당 Path에 있는 Folder 및 Files 찾음
            Dim dirA As DirectoryInfo = New DirectoryInfo(entry)    ' 디렉토리 지정
            lst_box.Items.Add(dirA.Name)
        Next
    End Sub

    Private Sub lst_box_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lst_box.SelectedIndexChanged
        lst_App.Items.Clear()
        'lst_Fea.Items.Clear()
        szFilePath = strFilePath & "\" & lst_Year.Text & "\" & lst_box.Text
        For Each entry As String In Directory.GetDirectories(szFilePath)
            ' GetDirectories(Path) <- 해당 Path에 있는 Folder 및 Files 찾음
            Dim dirA As DirectoryInfo = New DirectoryInfo(entry)    ' 디렉토리 지정
            lst_App.Items.Add(dirA.Name)
        Next
    End Sub

    Private Sub lst_App_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lst_App.SelectedIndexChanged
        'lst_Fea.Items.Clear()
        szFilePath = strFilePath & "\" & lst_Year.Text & "\" & lst_box.Text & "\" & lst_App.Text
        For Each entry As String In Directory.GetDirectories(szFilePath)
            ' GetDirectories(Path) <- 해당 Path에 있는 Folder 및 Files 찾음
            Dim dirA As DirectoryInfo = New DirectoryInfo(entry)    ' 디렉토리 지정
            'lst_Fea.Items.Add(dirA.Name)
        Next
    End Sub

    Private Sub lst_Year_DoubleClick(sender As Object, e As EventArgs) Handles lst_Year.DoubleClick
        ' 폴더 열기
        Try
            Dim szFileT As String = Nothing
            For Each entry As String In Directory.GetDirectories(strFilePath)        ' GetDirectories(Path) <- 해당 Path에 있는 Folder 및 Files 찾음
                ' 지정 한 경로를 반복 하면서 경로와 '구분'명과 일치하는 폴더를 찾음.
                ' 찾은 경로로 진입 하여 그 안의 파일명을 찾는다.
                Dim dirA As DirectoryInfo = New DirectoryInfo(entry)    ' 디렉토리 지정
                If dirA.Name = lst_Year.Text Then
                    szFileT = entry
                    Exit For
                End If
            Next

            Shell("C:\Windows\explorer.exe " & szFileT, AppWinStyle.NormalFocus)
        Catch ex As Exception
            MsgBox(ex.Message, "lee.sunbae@lgepartner.com")
        End Try
    End Sub

    Private Sub lst_box_DoubleClick(sender As Object, e As EventArgs) Handles lst_box.DoubleClick
        ' 폴더 열기
        Try
            Dim szFileT As String = Nothing
            szFilePath = strFilePath & "\" & lst_Year.Text
            For Each entry As String In Directory.GetDirectories(szFilePath)        ' GetDirectories(Path) <- 해당 Path에 있는 Folder 및 Files 찾음
                ' 지정 한 경로를 반복 하면서 경로와 '구분'명과 일치하는 폴더를 찾음.
                ' 찾은 경로로 진입 하여 그 안의 파일명을 찾는다.
                Dim dirA As DirectoryInfo = New DirectoryInfo(entry)    ' 디렉토리 지정
                If dirA.Name = lst_box.Text Then
                    szFileT = entry
                    Exit For
                End If
            Next

            Shell("C:\Windows\explorer.exe " & szFileT, AppWinStyle.NormalFocus)
        Catch ex As Exception
            MsgBox(ex.Message, "lee.sunbae@lgepartner.com")
        End Try
    End Sub

    Private Sub lst_App_DoubleClick(sender As Object, e As EventArgs) Handles lst_App.DoubleClick
        ' 폴더 열기
        Try
            Dim szFileT As String = Nothing
            szFilePath = strFilePath & "\" & lst_Year.Text & "\" & lst_box.Text
            For Each entry As String In Directory.GetDirectories(szFilePath)        ' GetDirectories(Path) <- 해당 Path에 있는 Folder 및 Files 찾음
                ' 지정 한 경로를 반복 하면서 경로와 '구분'명과 일치하는 폴더를 찾음.
                ' 찾은 경로로 진입 하여 그 안의 파일명을 찾는다.
                Dim dirA As DirectoryInfo = New DirectoryInfo(entry)    ' 디렉토리 지정
                If dirA.Name = lst_App.Text Then
                    szFileT = entry
                    Exit For
                End If
            Next

            Shell("C:\Windows\explorer.exe " & szFileT, AppWinStyle.NormalFocus)
        Catch ex As Exception
            MsgBox(ex.Message, "lee.sunbae@lgepartner.com")
        End Try
    End Sub

    Private Sub requestBtn_Click(sender As Object, e As EventArgs) Handles requestBtn.Click
        '제안하기 폼

    End Sub
End Class