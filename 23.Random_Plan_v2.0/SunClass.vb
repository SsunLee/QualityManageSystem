Imports System.Windows.Forms
Public Class SunClass
    Public _strPath As String
    Public _strKey As String
    Public _FileName As String
    Public _goFind_result_filename As String
    Public _oPath As String
    Public _modelinfo As Collections.Generic.List(Of String)


    Public Sub New() : End Sub

    Public Sub New(_strPath As String, _strKey As String) '# Method Overloading
        Me._strPath = _strPath
        Me._strKey = _strKey
    End Sub
    Public Sub New(_oPath As String) '# Method Overloading
        Me._oPath = _oPath
    End Sub
    Public Sub New(_modelinfo As Collections.Generic.List(Of String)) '# Method Overloading
        Me._modelinfo = _modelinfo
    End Sub

    Property _getset_modelInfo() As Collections.Generic.List(Of String)
        Get
            Return Me._modelinfo
        End Get
        Set(value As Collections.Generic.List(Of String))
            Me._modelinfo = value
        End Set
    End Property

    Property _NowPath As String
        Get
            Return Me._oPath
        End Get
        Set(value As String)
            Me._oPath = value
        End Set
    End Property

    Property _Path As String
        Get
            Return Me._strPath
        End Get
        Set(strPath As String)
            Me._strPath = strPath
        End Set
    End Property

    Property _Key As String
        Get
            Return Me._strKey
        End Get
        Set(strKey As String)
            Me._strKey = strKey
        End Set
    End Property

    Property _Name As String
        Get
            Return Me._FileName
        End Get
        Set(value As String)
            Me._FileName = value
        End Set
    End Property
    Property _getset_gofind_result As String
        Get
            Return Me._GoFind_result_filename
        End Get
        Set(value As String)
            Me._GoFind_result_filename = value
        End Set
    End Property

    Public Sub FileMovetoTarget(nPath As String)
        Dim line As String = "--------------------------------------------------------------"
        Dim bytesRead As Integer
        Dim buffer(4096) As Byte
        Try  ' oldPath  = 현재 위치 파일 
            Using inFile As New System.IO.FileStream(Me._oPath, IO.FileMode.Open, IO.FileAccess.Read)
                Using outFile As New System.IO.FileStream(nPath, IO.FileMode.Create, IO.FileAccess.Write)
                    Do
                        bytesRead = inFile.Read(buffer, 0, buffer.Length)
                        If bytesRead > 0 Then
                            outFile.Write(buffer, 0, bytesRead)
                        End If
                    Loop While bytesRead > 0
                End Using
            End Using
        Catch ex As System.IO.IOException
            Console.WriteLine("Exception Message : {0}", ex.Message) : Console.WriteLine("oldPath : {0}", Me._oPath) : Console.WriteLine("newPath : {0}", nPath)
            MessageBox.Show("파일을 닫고 다시 올려주세요." & vbCrLf & line & ex.Message & vbCrLf & line, "(Sunbae)", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Public Function File_is_Open(_Path As String) As Boolean
        Dim chk As Boolean = False
        Dim line As String = "--------------------------------------------------------------"
        Dim filename As String = Nothing

        Dim temp() As String = Split(_Path, "\")
        For Each a As String In temp
            Console.WriteLine("temp : {0}", a)
        Next
        Dim findex As Integer = Len(temp(temp.Length - 1)) : filename = Right(_Path, findex)
        Console.WriteLine("파일이름 완성! : {0}", filename)

        Try
            Dim fOpen As IO.FileStream = IO.File.Open(_Path, IO.FileMode.Open, IO.FileAccess.Read, IO.FileShare.None)
            fOpen.Close() : fOpen.Dispose() : fOpen = Nothing
        Catch ex As System.IO.IOException
            MessageBox.Show("파일을 닫고 다시 올려주세요." & vbCrLf & line & vbCrLf & filename & "올릴 파일이 열려있습니다." & vbCrLf & line, "(Sunbae)", MessageBoxButtons.OK, MessageBoxIcon.Error)
            chk = True
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            chk = True
        End Try

        Return chk

    End Function

    Public Function GoFind() As Boolean
        Dim di As IO.DirectoryInfo : Dim files As IO.FileInfo()
        Dim chk As Boolean = False : Dim temp As Date, strFileOut As String = Nothing, strFile_name As String = Nothing
        Try
            di = New IO.DirectoryInfo(_strPath & "\")
            _strKey = _strKey & "*"
            files = di.GetFiles(_strKey, IO.SearchOption.AllDirectories)

            If files.Length < 0 Then
                chk = False
            Else
                chk = True
                For Each a As IO.FileInfo In files
                    Dim lastModif As Date = a.LastWriteTime
                    If lastModif > temp Then
                        temp = lastModif
                        strFileOut = a.FullName
                        strFile_name = a.Name
                    End If
                Next
                _FileName = strFileOut
                _goFind_result_filename = strFile_name
            End If

        Catch ex As Exception
        End Try
        Return chk
    End Function
End Class
