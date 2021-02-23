Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Data.OleDb
Imports System.Drawing
Imports System.IO
Imports System.Windows.Forms
Imports System.Xml

Public Class Search_App

    Public DS_trvApp As DataSet = New DataSet
    Public DA As OleDbDataAdapter = New OleDbDataAdapter()
    Public DS As DataSet = New DataSet
    Dim strtrvApp As String = "TD_AF_DS"
    Dim vCon As String = Nothing
    Public vConn As OleDbConnection
    Public XML As New XML
    Public Findnode As TreeNode
    'Public strCon As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\신창하\업무\Task\Test_db\20180305_QPortalDB.accdb;Jet OLEDB:Database Password = lge1234;"

    Public chkSearchOK As Boolean
    Public chkSearch As Boolean
    Public chkSubmit As Boolean



    Public Sub SearchApp_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        chkSearch = False
        chkSubmit = False
        nodeCount = 0

        txtApp.Select()

        '###### 트리뷰 노드 모두 접기 ######
        trvApp.SelectedNode = Nothing
        trvApp.CollapseAll()
        '###################################
    End Sub

    '################## 노드 검색하는 부분###################
    Public nodeCount As Integer = 0
    Public NodesThatMatch As New List(Of TreeNode)

    Public Sub btSearch_Click(sender As Object, e As EventArgs) Handles btSearch.Click
        chkSearch = True

        If txtApp.Text = "" Then
            MsgBox("검색 할 App이름을 입력하세요") : Exit Sub
        Else
            If SearchTheTreeView(trvApp, txtApp.Text) Is Nothing Then
                chkSearchOK = False
                MessageBox.Show("검색이 끝났습니다")
                trvApp.Select()
                chkSearch = False

            Else
                chkSearchOK = True
                trvApp.SelectedNode = SearchTheTreeView(trvApp, txtApp.Text)
                trvApp.Select()
                nodeCount += 1

            End If

        End If
    End Sub

    Public Function SearchTheTreeView(ByVal TV As TreeView, ByVal TextToFind As String) As TreeNode
        '  Empty previous
        Dim return_node As TreeNode = Nothing
        NodesThatMatch.Clear()
        ' Keep calling RecursiveSearch
        For Each TN As TreeNode In TV.Nodes
            If UCase(TN.Text) Like UCase(TextToFind) & "*" Then
                NodesThatMatch.Add(TN)
            End If

            RecursiveSearch(TN, TextToFind)
        Next

        If NodesThatMatch.Count > nodeCount Then
            return_node = NodesThatMatch(nodeCount)
        ElseIf nodeCount > NodesThatMatch.Count Or nodeCount = NodesThatMatch.Count Then
            nodeCount = 0
        Else
            'Return Nothing
        End If

        Return return_node

    End Function

    Public Sub RecursiveSearch(ByVal treeNode As TreeNode, ByVal TextToFind As String)

        ' Keep calling the test recursively.
        For Each TN As TreeNode In treeNode.Nodes
            If UCase(TN.Text) Like UCase(TextToFind) & "*" Then
                NodesThatMatch.Add(TN)
            End If

            RecursiveSearch(TN, TextToFind)
        Next
    End Sub
    '################################################################

    Public Sub btSummit_Click(sender As Object, e As EventArgs) Handles btSummit.Click
        If trvApp.SelectedNode Is Nothing Then
            chkSubmit = False
        Else
            chkSubmit = True

        End If

        Me.Hide()


    End Sub



    Private Sub txtApp_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtApp.KeyPress, trvApp.KeyPress
        If e.KeyChar = Convert.ToChar(13) Then  ' ToChar <-- 13번 값은 Enter 임.
            Call btSearch_Click(sender, e)   ' 다른 프로시져 호출
        End If
    End Sub
End Class