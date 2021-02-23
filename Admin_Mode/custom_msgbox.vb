Imports System.IO

Public Class custom_msgbox
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim Outl As Object
        Dim sFile As String
        Dim szTemp As String



        sFile = "C:\Users"

        Dim dirA As DirectoryInfo = New DirectoryInfo(sFile)    ' 디렉토리 지정
        'For Each dra In dirA.GetFiles()     ' For each를 통해 폴더 내의 파일을 찾음
        For Each dra In dirA.GetDirectories()     ' For each를 통해 폴더을 찾음
            szTemp = dra.Name
            If szTemp = "addc_Client" Or szTemp = "Default" Or szTemp = "공용" Then  ' Consumer TC와 Kernel TC / Framework TC의 파일 Naming이 다름
            Else
                sFile = sFile & "\" & szTemp
                Exit For
            End If
        Next


        Outl = CreateObject("Outlook.Application")
        If Outl IsNot Nothing Then
            Dim omsg As Object
            omsg = Outl.CreateItem(0) '=Outlook.OlItemType.olMailItem'
            omsg.To = "lee.sunbae@lgepartner.com, gyeongmin.yeom@lgepartner.com"
            'omsg.bcc = "yusuf@gmail.com"
            omsg.subject = "[문의] Q-Portal 관리자 접근"

            '     GetBoiler(sFile)

            ' omsg.body = sFile
            'omsg.Attachments.Add("c:\HP\opcserver.txt")
            'set message properties here...'
            'omsg.Display(True) 'will display message to user
            'set message properties here...'
            'omsg.body = "안뇽"

            omsg.Display(True) 'will display message to user

        End If
    End Sub

    Function GetBoiler(ByVal sFile As String) As String
        Dim fso As Object
        Dim ts As Object
        fso = CreateObject("Scripting.FileSystemObject")
        ts = fso.GetFile(sFile).OpenAsTextStream(1, -2)
        GetBoiler = ts.readall
        ts.Close
    End Function
End Class