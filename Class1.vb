Imports Microsoft.Win32
Public Class Class1

    ' 파일이 열렸는지 Check 
    Public Function isFileOpen(ByVal pathfile As String) As Boolean
        Try
            Dim fs As IO.FileStream = IO.File.Open(pathfile, IO.FileMode.Open, IO.FileAccess.Read, IO.FileShare.None)
            fs.Close()
            fs.Dispose()
            fs = Nothing
            Return False
        Catch ex As IO.IOException ' File open
            Return True
        Catch ex As Exception ' Unknown error
            Return True
        End Try
    End Function



End Class



