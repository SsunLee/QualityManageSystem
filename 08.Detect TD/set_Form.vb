Imports System.Diagnostics
Imports System.Drawing
Imports System.IO
Imports System.Windows.Forms
Imports System.Xml
Imports System.Xml.Linq

Public Class set_Form
    Public Summary As New Summary_NEXT



    Private Sub MakeTheme(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged, RadioButton2.CheckedChanged, RadioButton3.CheckedChanged, RadioButton4.CheckedChanged
        'Dim Summary As New Summary_NEXT
        Summary = Me.Owner

        If RadioButton1.Checked = True Then
            Summary.TabPage1.BackgroundImage = Nothing

        ElseIf RadioButton2.Checked = True Then
            Summary.TabPage1.BackgroundImage = My.Resources.Kakao_Friends_01
            'TabPage1.BackgroundImageLayout = ImageLayout.Stretch

        ElseIf RadioButton3.Checked = True Then
            Summary.TabPage1.BackgroundImage = My.Resources.KaKao_Friends_02
            'TabPage1.BackgroundImageLayout = ImageLayout.Stretch


        End If

        'txtResul
        'SetStyle(ControlStyles.SupportsTransparentBackColor, True)


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Summary = Me.Owner


        Dim cDialog As New ColorDialog()

        cDialog.Color = Summary.TabPage1.BackColor

        If (cDialog.ShowDialog() = DialogResult.OK) Then
            Summary.TabPage1.BackColor = cDialog.Color

            For Each ctrl In Summary.TabControl1.SelectedTab.Controls

                If (ctrl.GetType() Is GetType(ListBox)) Then    '# 해당 컨트롤이 ListBox 라면
                    With ctrl
                        .BackColor = cDialog.Color      '# 배경색
                    End With
                End If

                If (ctrl.GetType() Is GetType(TextBox)) Then
                    ctrl.BackColor = cDialog.Color
                    'ctrl.ForeColor = Color.Black
                End If

                If (ctrl.GetType() Is GetType(TreeView)) Then
                    ctrl.BackColor = cDialog.Color
                    'ctrl.ForeColor = Color.Black
                End If


                If (ctrl.GetType() Is GetType(RichTextBox)) Then
                    ctrl.BackColor = cDialog.Color
                    'ctrl.ForeColor = Color.Black
                End If

                If (ctrl.GetType() Is GetType(Label)) Then
                    ' ctrl.BackColor = Color.FromArgb(50, 50, 50)
                    ' ctrl.ForeColor = Color.Black
                End If

                If (ctrl.GetType() Is GetType(GroupBox)) Then
                    'ctrl.ForeColor = Color.Black
                    For Each ct As Control In GroupBox1.Controls
                        ct.BackColor = cDialog.Color
                        'ct.ForeColor = cDialog.Color
                    Next
                End If

            Next

        End If
    End Sub

    Private Sub set_Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RadioButton1.Checked = False
    End Sub

#Region "[XML READ/WRITE]"
    '# 파일 이름 불러오기
    Function ReadfileName(ByRef xPath As String) As String

        Dim doc As XDocument = XDocument.Load(xPath)
        ReadfileName = doc.<Main>.<Path>.Value & doc.<Main>.<file>.Value

    End Function
    '# 
    Function InputfileName(ByRef xPath As String, ByRef xText As String) As String
        ' Dim writer As New XmlTextWriter(Application.StartupPath + "\QPortal_Path.xml", System.Text.Encoding.UTF8)

        If (File.Exists(Application.StartupPath + "\Wallpapers.xml")) = True Then ' 있으면?

            Dim doc As XmlDocument = New XmlDocument()
            doc.Load(Application.StartupPath + "\Wallpapers.xml")

            Dim rootPath As XmlNode = doc.DocumentElement("Path")
            rootPath.InnerText = xPath

            Dim rootFile As XmlNode = doc.DocumentElement("file")
            rootFile.InnerText = xText

            doc.Save(Application.StartupPath + "\Wallpapers.xml")

        Else
            'Dim xdoc As XDocument = New XDocument
            'Dim element As XElement = New XElement("Main", xText)

            Dim xdoc As XDocument = New XDocument(
                New XDeclaration("1.0", "utf-8", "yes"),
                New XComment("This is a comment"),
                New XElement("Main",
                    New XElement("Path", xPath),
                    New XElement("file", xText)))

            xdoc.Save(Application.StartupPath + "\Wallpapers.xml")

        End If

        Return xText

    End Function

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click


        If RadioButton1.Checked = True Then
            Summary.TabPage1.BackgroundImage = Nothing
            InputfileName("Not", "Image") 'xml에 파일이름 넣기.

        ElseIf RadioButton2.Checked = True Then
            Summary.TabPage1.BackgroundImage = My.Resources.Kakao_Friends_01
            'TabPage1.BackgroundImageLayout = ImageLayout.Stretch

        ElseIf RadioButton3.Checked = True Then
            Summary.TabPage1.BackgroundImage = My.Resources.KaKao_Friends_02
            'TabPage1.BackgroundImageLayout = ImageLayout.Stretch
        ElseIf RadioButton4.Checked = True Then
            Summary = Me.Owner

            Dim opFile As New OpenFileDialog()
            Dim path As String = Nothing
            Dim filename As String = Nothing

            opFile.Title = "Selct Image file"
            opFile.Filter = "jpg files (*.jpg)|*.jpg|All files (*.*)|*.*"

            opFile.FilterIndex = 2
            opFile.RestoreDirectory = True

            If opFile.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                Try

                    '# 선택한 파일의 경로 및 이름 변수에 저장
                    path = opFile.FileName
                    filename = opFile.SafeFileName

                    Debug.Print("파일이름: " & Strings.Left(path, InStr(path, filename) - 1))

                    Dim strTemp As String = Strings.Left(path, InStr(path, filename) - 1)

                    'File.Copy(path, Application.StartupPath + filename, True)   '# 파일 붙여 넣기
                    InputfileName(strTemp, filename) 'xml에 파일이름 넣기.
                    'InputfileName("file", filename) 'xml에 파일이름 넣기.

                    'Fuck = ReadfileName(Application.StartupPath + "\Wallpapers.xml")

                    Dim Fuck As String = ReadfileName(Application.StartupPath + "\Wallpapers.xml")
                    Dim bkg As Image = Image.FromFile(Fuck)
                    Summary.TabPage1.BackgroundImage = bkg  '# 배경 적용


                Catch Ex As Exception
                    MessageBox.Show(Ex.Message)
                    Exit Sub
                End Try




            Else
                Exit Sub
            End If

        End If


        Close()


    End Sub
#End Region



End Class