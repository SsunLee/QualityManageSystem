Imports System.Windows.Forms
Imports System.Xml
Imports System.IO
Imports System
Imports System.Drawing

Public Class Qportal_Settings
    Public xml As New XML
    Public Default_serverAddress As String = "\\10.169.88.40\Q-Portal"

    Private Sub createNode(ByVal pName As String, ByVal pPath As String, ByVal writer As XmlTextWriter)
        'Element 생성
        writer.WriteStartElement(pPath)

        '노드안의 내용 저장
        writer.WriteString(pName)
        writer.WriteEndElement()
    End Sub

#Region "설정 창 로드"
    Private Sub Qportal_Settings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Icon = My.Resources.Qportal_Icon

        ' 만약 로드했을 때 10.169.88.40 이면 ! 미리 Check 하기
        Dim vCon As String = Nothing
        vCon_Call(vCon)

        Dim checkString As String = vCon_String("Main_Server")

        Select Case checkString
            Case "\\10.169.88.40\Q-Portal"
                rdOnline.Checked = True
                Label5.Text = "현재 온라인 용으로 적용 되어있습니다."
            Case Else
                rdOffline.Checked = True
                Label5.Text = "현재 오프라인 용으로 적용 되어있습니다."
        End Select

        Dim blchk As Boolean
        Dim szFileName As String
        Dim dirA As DirectoryInfo = New DirectoryInfo(Application.StartupPath)    ' 디렉토리 지정
        For Each dra In dirA.GetFiles()     ' For each를 통해 폴더 내의 파일을 찾음
            Dim szTemp As String = dra.Name
            If "Settings_Value.xml" = dra.Name Then  ' Consumer TC와 Kernel TC / Framework TC의 파일 Naming이 다름
                szFileName = dra.Name
                blchk = True
                Exit For
            End If
        Next

    End Sub
#End Region

#Region "설적 적용 버튼 "
    Private Sub btnApply_Click(sender As Object, e As EventArgs) Handles btnApply.Click

        '# Resource에 있는 파일 특정 경로에 붙여 넣기 or 빼내기
        IO.File.WriteAllBytes(Application.StartupPath & "\QportalDB.accdb", My.Resources.QPortalDB)

        If rdOffline.Checked = True Then
            inputConnection_String(False)
            Label5.Text = "현재 오프라인 용으로 적용 되어있습니다."

        ElseIf rdOnline.Checked = True Then
            inputConnection_String(True)

            Label5.Text = "현재 온라인 용으로 적용 되어있습니다."
        Else
            MsgBox("선택해주세요.")
            Exit Sub
        End If

    End Sub
#End Region

#Region "XML 생성 및 저장"
    '# XML 변경 후 Save
    Function inputConnection_String(ByRef blChk As Boolean)
        ' Dim writer As New XmlTextWriter(Application.StartupPath + "\QPortal_Path.xml", System.Text.Encoding.UTF8)
        Dim doc As XmlDocument = New XmlDocument()
        doc.Load(Application.StartupPath + "\QPortal_Path.xml")

        If blChk = True Then    ' 만약 온라인 이면

            Dim root As XmlNode = doc.DocumentElement("Main")

            root.FirstChild.InnerText = "\\10.169.88.40\Q-Portal"

            Dim nProvider As XmlNode = doc.DocumentElement("vCon_Data")
            nProvider.Item("Provider").InnerText = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source="
            nProvider.Item("QPortalDB").InnerText = "\QPortalDB.accdb;Jet OLEDB:Database Password = lge1234;"

            Dim nMain As XmlNode = doc.DocumentElement("Main")
            nMain.Item("AccessDB").InnerText = "\0.AccessDB"

            doc.Save(Application.StartupPath + "\QPortal_Path.xml")

        Else                        ' 만약 오프라인 이면

            Dim root As XmlNode = doc.DocumentElement("Main")
            root.FirstChild.InnerText = ""

            Dim nProvider As XmlNode = doc.DocumentElement("vCon_Data")
            nProvider.Item("Provider").InnerText = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source="
            nProvider.Item("QPortalDB").InnerText = "QPortalDB.accdb;Jet OLEDB:Database Password = lge1234;"

            Dim nMain As XmlNode = doc.DocumentElement("Main")
            nMain.Item("AccessDB").InnerText = ""

            doc.Save(Application.StartupPath + "\QPortal_Path.xml")

        End If


    End Function
#End Region

#Region "XML Read"
    '# Connection String Read
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

    '# Main Server Address Read
    Function vCon_String(ByRef strText As String) As String
        'XML에서 값을 읽어와서 Vcon에 저장하는 부분
        Dim strServer As String = Nothing
        Dim strProvider As String = Nothing
        Dim strQPortalDB As String = Nothing
        Dim strAccess As String = Nothing

        'Application.StartupPath : 프로그램이 설치된 파일 Path

        Dim xmlReader = New XmlTextReader(Application.StartupPath + "\QPortal_Path.XML")
        Do While xmlReader.Read() ' XML 파일 한줄씩 읽어옴
            'Node이름을 비교하여 맞으면 각 변수에 저장
            If xmlReader.NodeType = XmlNodeType.Element AndAlso xmlReader.Name = strText Then
                strServer = xmlReader.ReadElementContentAsString ' 해당 Element의 String값을 읽어옴
            End If

        Loop
        xmlReader.Close() ' XML Reader 닫음

        vCon_String = strServer
        Return vCon_String


    End Function

    '# (미사용)  Settings Value Read
    Function getSettingsValue(ByRef strText As String) As String
        'XML에서 값을 읽어와서 Vcon에 저장하는 부분
        Dim strServer As String = Nothing
        Dim strProvider As String = Nothing
        Dim strQPortalDB As String = Nothing
        Dim strAccess As String = Nothing

        'Application.StartupPath : 프로그램이 설치된 파일 Path

        Dim xmlReader = New XmlTextReader(Application.StartupPath + "\Settings_Value.XML")
        Do While xmlReader.Read() ' XML 파일 한줄씩 읽어옴
            'Node이름을 비교하여 맞으면 각 변수에 저장
            If xmlReader.NodeType = XmlNodeType.Element AndAlso xmlReader.Name = strText Then
                strServer = xmlReader.ReadElementContentAsString ' 해당 Element의 String값을 읽어옴
            End If

        Loop
        xmlReader.Close() ' XML Reader 닫음

        getSettingsValue = strServer
        Return getSettingsValue

    End Function

#End Region

#Region "XML 폰트 설정"
    ' Font Save 버튼
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' xml 생성하는 함수 호출
        Dim blchk As Boolean = False
        makeXML_settings(blchk)

    End Sub
    '글꼴 설정
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ' Set font 
        FontDialog1.ShowColor = True        ' Color 설정할 수 있게

        FontDialog1.Font = TextBox1.Font
        FontDialog1.Color = TextBox1.ForeColor

        If FontDialog1.ShowDialog = DialogResult.OK Then
            TextBox1.Font = FontDialog1.Font
            TextBox1.ForeColor = FontDialog1.Color

            la_font.Text = FontDialog1.Font.Name
            la_Size.Text = FontDialog1.Font.Size
            Dim v = FontDialog1.ToString

            la_font.Text = v

        End If

    End Sub

    Function makeXML_settings(ByRef blchk As Boolean)

        Try
            If blchk = False Then    ' 파일이 없으면
                Dim writer As New XmlTextWriter(Application.StartupPath + "\Settings_Value.xml", System.Text.Encoding.UTF8)

                writer.WriteStartDocument(True)
                writer.Formatting = Formatting.Indented
                writer.Indentation = 2

                'Settings 부분 
                writer.WriteStartElement("Setting")
                'Font
                createNode(FontDialog1.Font.Name, "Font", writer)
                'ForeColor
                createNode(FontDialog1.Color.Name, "ForeColor", writer)

                'FontDialog1.Font.Size
                createNode(FontDialog1.Font.Size, "FontSize", writer)

                writer.WriteEndElement()
                writer.WriteEndDocument()
                writer.Close()

            Else     ' 이미 파일이 있다면 기존 수정
                Dim doc As XmlDocument = New XmlDocument()

                doc.Load(Application.StartupPath + "\Settings_Value.xml")

                Dim nProvider As XmlNode = doc.DocumentElement("Setting")
                nProvider.Item("Font").InnerText = FontDialog1.Font.Name
                nProvider.Item("ForeColor").InnerText = FontDialog1.Color.Name
                nProvider.Item("FontSize").InnerText = FontDialog1.Font.Size

                doc.Save(Application.StartupPath + "\Settings_Value.xml")

            End If

        Catch ex As Exception

        End Try

    End Function
#End Region

#Region "미사용 코드"
    Private Function GetFontByString(ByVal sFont As String) As Font

        Dim sTemp As String = Nothing

        sTemp = sFont
        sTemp = Strings.Mid(sTemp, InStr(sTemp, "{Font = {"))
        sFont = sTemp

        sFont = Replace(sFont, "}", "")
        sFont = Replace(sFont, "]", "")
        sFont = Replace(sFont, "[", "")

        sFont = sFont.Substring(1, sFont.Length - 2)
        sFont = Replace(sFont, ",", vbNullString)
        sFont = Replace(sFont, "Font:", vbNullString)
        Dim sElement() As String = Split(sFont, " ")
        Dim sSingle() As String = Nothing
        Dim sValue As String = Nothing
        Dim FontName As String = Nothing
        Dim FontSize As Single = Nothing
        Dim FontStyle As FontStyle = Drawing.FontStyle.Regular
        Dim FontUnit As GraphicsUnit = GraphicsUnit.Point
        Dim gdiCharSet As Byte = Nothing
        Dim gdiVerticalFont As Boolean = Nothing

        For Each sValue In sElement
            sValue = Trim(sValue)
            sSingle = Split(sValue, "=")
            If sSingle.GetUpperBound(0) > 0 Then
                If sSingle(0) = "Name" Then
                    FontName = sSingle(1)
                ElseIf sSingle(0) = "Size" Then
                    FontSize = CSng(sSingle(1))
                ElseIf sSingle(0) = "Units" Then
                    FontUnit = CInt(sSingle(1))
                ElseIf sSingle(0) = "GdiCharSet" Then
                    FontName = CByte(sSingle(1))
                ElseIf sSingle(0) = "GdiVerticalFont" Then
                    FontName = CBool(sSingle(1))
                End If
            End If
        Next
        Return New Font(FontName, FontSize, FontStyle, FontUnit, gdiCharSet, gdiVerticalFont)
    End Function
    Private Sub Button3_Click(sender As Object, e As EventArgs)

        'settings.설정
        Dim strFont As String = getSettingsValue("Font")
        Dim strForeColor As String = getSettingsValue("ForeColor")
        Dim intSize As Integer = getSettingsValue("FontSize")

        TextBox1.Text = FontDialog1.ToString
        Dim fontValue = FontDialog1.ToString

        'Dim FontString As String = "{Font = {[Font: Name=굴림, Size=11.25, Units=3, GdiCharSet=129, GdiVerticalFont=False]} Color = {Color [WindowText]}}"

        'Dim v() As String = Split(FontString, ",")

        'Dim sTemp As String = v(0)
        'Dim s(6) As String

        's(0) = Replace(v(0), "{Font = {[Font: Name=", "")
        's(1) = Replace(v(1), " Size=", "")
        's(2) = Replace(v(2), " Units=", "")
        's(3) = Replace(v(3), " GdiCharSet=", "")
        's(4) = Replace(v(4), "GdiVerticalFont=", "")
        's(4) = Replace(s(4), "]} Color = {Color [WindowText]}}", "")
        's(4) = LTrim(s(4))

        'Dim stringFont As String = s(0)
        'Dim singleFontSize As Single = s(1)
        'Dim integerUnits As GraphicsUnit = s(2)
        'Dim intGDICharSet As Byte = s(3)



        'TextBox1.Font = New Font(stringFont, singleFontSize,, integerUnits)
        'TextBox1.Font = New Font()

        'TextBox1.Text = New Font()

        ' TextBox1.Font = New Font(strFont, intSize)

        'TextBox1.Font = 
        '"맑은 고딕", 30)






    End Sub
    Dim settings As New My.MySettings
#End Region

End Class