Imports System.Xml
Imports System.Windows.Forms

Public Class XML
    ' 노드생성하는 함수
    Public Sub createNode(ByVal pName As String, ByVal pPath As String, ByVal writer As XmlTextWriter)
        writer.WriteStartElement(pPath)
        writer.WriteString(pName)
        writer.WriteEndElement()
    End Sub

    ' AccessDB인 QPortal DB의 Connection String 생성
    Public Sub vCon_Call(ByRef vCon As String)
        'XML에서 값을 읽어와서 Vcon에 저장하는 부분
        Dim strServer As String = Nothing
        Dim strProvider As String = Nothing
        Dim strQPortalDB As String = Nothing
        Dim strAccess As String = Nothing

        'Application.StartupPath : 프로그램이 설치된 파일 Path

        Dim xmlReader = New XmlTextReader(Application.StartupPath + "\QPortal_Path.XML")
        Do While xmlReader.Read() ' XML 파일 한줄씩 읽어옴
            'Node이름을 비교하여 맞으면 각 변수에 저장
            If xmlReader.NodeType = XmlNodeType.Element AndAlso xmlReader.Name = "Main_Server" Then
                strServer = xmlReader.ReadElementContentAsString ' 해당 Element의 String값을 읽어옴
            End If
            If xmlReader.NodeType = XmlNodeType.Element AndAlso xmlReader.Name = "AccessDB" Then
                strAccess = xmlReader.ReadElementContentAsString ' 해당 Element의 String값을 읽어옴
            End If
            If xmlReader.NodeType = XmlNodeType.Element AndAlso xmlReader.Name = "Provider" Then
                strProvider = xmlReader.ReadElementContentAsString
            End If
            If xmlReader.NodeType = XmlNodeType.Element AndAlso xmlReader.Name = "QPortalDB" Then
                strQPortalDB = xmlReader.ReadElementContentAsString
            End If
        Loop


        vCon = strProvider + strServer + strAccess + strQPortalDB


        xmlReader.Close() ' XML Reader 닫음
    End Sub

    ' AccessDB인 Admin DB의 Connection String 생성
    Public Sub vCon_Admin_Call(ByRef vCon As String)
        'XML에서 값을 읽어와서 Vcon에 저장하는 부분
        Dim strServer As String = Nothing
        Dim strProvider As String = Nothing
        Dim strQPortalDB As String = Nothing
        Dim strAccess As String = Nothing

        Dim xmlReader = New XmlTextReader(Application.StartupPath + "\QPortal_Path.XML")
        Do While xmlReader.Read() ' XML 파일 한줄씩 읽어옴
            'Node이름을 비교하여 맞으면 각 변수에 저장
            If xmlReader.NodeType = XmlNodeType.Element AndAlso xmlReader.Name = "Main_Server" Then
                strServer = xmlReader.ReadElementContentAsString ' 해당 Element의 String값을 읽어옴
            End If
            If xmlReader.NodeType = XmlNodeType.Element AndAlso xmlReader.Name = "AdminDB" Then
                strAccess = xmlReader.ReadElementContentAsString ' 해당 Element의 String값을 읽어옴
            End If
            If xmlReader.NodeType = XmlNodeType.Element AndAlso xmlReader.Name = "Provider" Then
                strProvider = xmlReader.ReadElementContentAsString
            End If
            If xmlReader.NodeType = XmlNodeType.Element AndAlso xmlReader.Name = "QPortalDB_Admin" Then
                strQPortalDB = xmlReader.ReadElementContentAsString
            End If
        Loop
        vCon = strProvider + strServer + strAccess + strQPortalDB
        xmlReader.Close() ' XML Reader 닫음
    End Sub

    ' AccessDB인 Kernel DB의 Connection String 생성
    Public Sub vCon_Kernel_Call(ByRef vCon As String)
        'XML에서 값을 읽어와서 Vcon에 저장하는 부분
        Dim strServer As String = Nothing
        Dim strProvider As String = Nothing
        Dim strQPortalDB As String = Nothing
        Dim strAccess As String = Nothing

        Dim xmlReader = New XmlTextReader(Application.StartupPath + "\QPortal_Path.XML")
        Do While xmlReader.Read() ' XML 파일 한줄씩 읽어옴
            'Node이름을 비교하여 맞으면 각 변수에 저장
            If xmlReader.NodeType = XmlNodeType.Element AndAlso xmlReader.Name = "Main_Server" Then
                strServer = xmlReader.ReadElementContentAsString ' 해당 Element의 String값을 읽어옴
            End If
            If xmlReader.NodeType = XmlNodeType.Element AndAlso xmlReader.Name = "Kernel" Then
                strAccess = xmlReader.ReadElementContentAsString ' 해당 Element의 String값을 읽어옴
            End If
            If xmlReader.NodeType = XmlNodeType.Element AndAlso xmlReader.Name = "Provider" Then
                strProvider = xmlReader.ReadElementContentAsString
            End If
            If xmlReader.NodeType = XmlNodeType.Element AndAlso xmlReader.Name = "KernelDB" Then
                strQPortalDB = xmlReader.ReadElementContentAsString
            End If
        Loop
        vCon = strProvider + strServer + strAccess + strQPortalDB
        xmlReader.Close() ' XML Reader 닫음
    End Sub

    ' Xml 파일을 읽어서 폴더 위치를 리턴해주는 함수
    Public Sub Folder_Path(ByVal strFolderPath As String, ByRef strFilePath As String)
        'XML에서 값을 읽어와서 Vcon에 저장하는 부분
        Dim strServer As String = Nothing
        Dim strFolder As String = Nothing
        Dim strQPortalDB As String = Nothing

        Dim xmlReader = New XmlTextReader(Application.StartupPath + "\QPortal_Path.XML")
        Do While xmlReader.Read() ' XML 파일 한줄씩 읽어옴
            'Node이름을 비교하여 맞으면 각 변수에 저장
            If xmlReader.NodeType = XmlNodeType.Element AndAlso xmlReader.Name = "Main_Server" Then
                strServer = xmlReader.ReadElementContentAsString ' 해당 Element의 String값을 읽어옴
            End If
            If xmlReader.NodeType = XmlNodeType.Element AndAlso xmlReader.Name = strFolderPath Then
                strFolder = xmlReader.ReadElementContentAsString
            End If
        Loop
        strFilePath = strServer + strFolder
        xmlReader.Close() ' XML Reader 닫음
    End Sub

    '유저네임을 리턴해주는 함수
    Public Sub GetUserName(ByRef strEP As String, ByRef strUserName As String)
        'XML에서 UserName 가져옴

        Dim xmlReader = New XmlTextReader(Application.StartupPath + "\QPortal_Path.XML")
        Do While xmlReader.Read() ' XML 파일 한줄씩 읽어옴
            If xmlReader.NodeType = XmlNodeType.Element AndAlso xmlReader.Name = "UserName" Then ' NodeType가 Element고 Name이 UserName인 경우
                strUserName = xmlReader.ReadElementContentAsString ' 해당 Element의 String값을 읽어옴
            End If
            If xmlReader.NodeType = XmlNodeType.Element AndAlso xmlReader.Name = "EP" Then ' NodeType가 Element고 Name이 EP 경우
                strEP = xmlReader.ReadElementContentAsString ' 해당 Element의 String값을 읽어옴
            End If
        Loop
        xmlReader.Close() ' XML Reader 닫음
    End Sub
End Class
