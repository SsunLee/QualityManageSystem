Imports System.Net
Imports System.Windows.Forms
Imports System.IO
Imports System.Drawing

Public Class GotoURLMAn

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        WebBrowser1.Document.GetElementById("email").SetAttribute("value", "ddfdfdf")
        WebBrowser1.Document.GetElementById("pass").SetAttribute("value", "ddfdfdf")

        While WebBrowser1.ReadyState <> WebBrowserReadyState.Complete
            Application.DoEvents()
        End While

    End Sub

    Private Sub GotoURLMAn_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        WebBrowser1.ScriptErrorsSuppressed = True
        Dim url As String = "https://blog.naver.com/tnsqo1126/221362586663"
        WebBrowser1.Hide()
        WebBrowser1.Navigate(url)
        While WebBrowser1.ReadyState <> WebBrowserReadyState.Complete
            Application.DoEvents()
        End While
        WebBrowser1.Show()
    End Sub
End Class