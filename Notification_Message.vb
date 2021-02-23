Imports System.Xml
Imports System.Windows.Forms

Public Class Notification_Message
    Sub push_message(ByRef szMSG As String)

        Dim MyXML As New XmlDocument()
        MyXML.Load(Application.StartupPath & "\mDialog.xml")
        Dim MyXMLNode As XmlNode = MyXML.SelectSingleNode("Message")
        'If we have the node let's change the text
        MyXMLNode.ChildNodes(0).InnerText = szMSG

        'Save the XML now
        MyXML.Save(Application.StartupPath & "\mDialog.xml")
    End Sub



End Class
