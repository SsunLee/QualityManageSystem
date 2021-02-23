Imports System.Windows.Forms
Imports System.Xml



Public Class Noti

    Dim drag As Boolean
    Dim mouseX As Integer
    Dim mouseY As Integer


    Private Sub Noti_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        BringToFront()
        Activate()


    End Sub
    '★ 창 드래그 했을 때
    Private Sub Noti_MouseMove(sender As Object, e As MouseEventArgs) Handles MyBase.MouseMove
        If drag Then
            Top = Cursor.Position.Y - mouseY
            Left = Cursor.Position.X - mouseX
        End If
    End Sub
    '★ 창 드래그 했을 때
    Private Sub Noti_MouseDown(sender As Object, e As MouseEventArgs) Handles MyBase.MouseDown
        drag = True
        mouseX = Cursor.Position.X - Left
        mouseY = Cursor.Position.Y - Top
    End Sub
    '★ 창 드래그 했을 때
    Private Sub Noti_MouseUp(sender As Object, e As MouseEventArgs) Handles MyBase.MouseUp
        drag = False
    End Sub
    '★ 최소화 버튼
    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click
        WindowState = FormWindowState.Minimized
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
        Close()

    End Sub

    Private Sub Noti_Closed(sender As Object, e As EventArgs) Handles Me.Closed

        '★ xml 추가하기 위함.

        Dim SaveDirectory As String = Application.StartupPath
        Dim SavePath As String = IO.Path.Combine(SaveDirectory, "mDialog.XML") 'combines the saveDirectory and the filename to get a fully qualified path.

        If IO.File.Exists(SavePath) Then
            'The file exists
            ' xml 에 Value 넣어줌.
            Dim MyXML As New XmlDocument()

            MyXML.Load(Application.StartupPath & "\mDialog.xml")

            Dim MyXMLNode As XmlNode = MyXML.SelectSingleNode("XML_File")

            'If we have the node let's change the text
            If MyXMLNode IsNot Nothing Then

                If CheckBox1.Checked Then   ' if don't show again
                    MyXMLNode.ChildNodes(0).InnerText = True
                Else
                    MyXMLNode.ChildNodes(0).InnerText = False
                End If

            Else


            End If

            'Save the XML now
            MyXML.Save(Application.StartupPath & "\mDialog.xml")
        Else
        End If

    End Sub

    Private Sub createNode(ByVal pName As String, ByVal pPath As String, ByVal writer As XmlTextWriter)
        'Element 생성
        writer.WriteStartElement(pPath)
        '노드안의 내용 저장
        writer.WriteString(pName)
        writer.WriteEndElement()
    End Sub

    Private Sub Noti_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

    End Sub
End Class