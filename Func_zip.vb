'###### Excel 버전 체크하여 버전에 맞는 코드 실행 함수 #########
Imports Microsoft.Office.Interop.Excel
Imports Microsoft.Win32.Registry
Public Class SUN

End Class

Module HangulCharSupport
    <Runtime.CompilerServices.Extension()>
    Public Function IsHangul(ByVal c As Char) As Boolean
        If (c >= "가" And c <= "힣") Then
            Return True
        End If
        Return False
    End Function

End Module

Module Module_Registry

    '레지스트리에서 데이터를 조회한다.
    Public Function ReadRegKey(ByVal KeyString As String, ByVal KeyName As String, ByVal DefaultValue As Object) As Object

        Try
            '서브키를 오픈한 후 데이터를 조회한다.
            ReadRegKey = LocalMachine.CreateSubKey(KeyString).GetValue(KeyName)
            If ReadRegKey Is Nothing Then
                '서브키가 없다면, 서브키를 생성한 후 데이터를 기록한다.
                LocalMachine.CreateSubKey(KeyString).SetValue(KeyName, DefaultValue)
                ReadRegKey = DefaultValue
            End If
            '조회한 서브키를 닫는다.
            LocalMachine.Close()
        Catch
            Return ""
        End Try

    End Function

    '레지스트리에 데이터를 기록한다.
    Public Function WriteRegKey(ByVal KeyString As String, ByVal KeyName As String, ByVal KeyValue As Object) As Boolean

        Try
            '서브키를 생성한 후 데이터를 기록한다.
            LocalMachine.CreateSubKey(KeyString).SetValue(KeyName, KeyValue)
            '조회한 서브키를 닫는다.
            LocalMachine.Close()
            Return True
        Catch
            Return False
        End Try
    End Function

    '레지스트리에 데이터를 삭제한다.
    Public Function DeleteRegKey(ByVal KeyString As String, ByVal KeyName As String) As Boolean

        Try
            '서브키를 오픈한 후 데이터를 삭제한다.
            LocalMachine.OpenSubKey(KeyString, True).DeleteValue(KeyName)
            '조회한 서브키를 닫는다.
            LocalMachine.Close()
            Return True
        Catch
            Return False
        End Try

    End Function




    Public ConsumerSave As New Consumer_Add
    Public Consumer1 As New Consumer

    Public Sub test()

        ConsumerSave.Gubun_Txt.Text = Consumer1.GubunCb.Text

    End Sub







End Module