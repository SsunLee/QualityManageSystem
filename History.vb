Imports System.Windows.Forms
Imports System.Data
Imports System.Data.OleDb
Public Class History
    Dim itemSta As String
    Private DS As DataSet = New DataSet
    Private DS2 As DataSet = New DataSet
    Private DS3 As DataSet = New DataSet
    Private DS4 As DataSet = New DataSet
    Private DS5 As DataSet = New DataSet
    Private DA As OleDbDataAdapter = New OleDbDataAdapter()
    Public ordAdapter As OleDbDataAdapter = New OleDbDataAdapter()
    Private strSQL As String
    Private vConn As OleDbConnection
    Dim strSht As String
    Dim strDate As String = Now()

    'Dim DA = New OleDbDataAdapter("Select * FROM [" & strSht & "] Where [App] > ''", vConn)
    'Dim TypeDA = New OleDbDataAdapter("Select * FROM [" & strSht2 & "]", vConn)
    'Dim DES_DA = New OleDbDataAdapter("Select * FROM [" & strSht4 & "]", vConn)
    'Dim Contact_C = New OleDbDataAdapter("Select * FROM [" & strCNS & "]", vConn)
    'Dim Contact_I = New OleDbDataAdapter("Select * FROM [" & strINFINIQ & "]", vConn)
    'Dim Contact_M = New OleDbDataAdapter("Select * FROM [" & strMSTech & "]", vConn)


    '        DA.Fill(DS, strSht)
    '        TypeDA.Fill(DS, strSht2)
    '        DES_DA.Fill(DS, strSht4)
    '        Contact_C.Fill(DS, strCNS)
    '        Contact_I.Fill(DS, strINFINIQ)
    '        Contact_M.Fill(DS, strMSTech)

    Private Sub TabControl1_Click(sender As Object, e As EventArgs) Handles TabControl1.Click
        strSht = TabControl1.SelectedTab.Text
        If strSht = "History_Main" Then
            DataGridView1.DataSource = DS.Tables(0)
        ElseIf strSht = "History_FUT" Then
            DataGridView2.DataSource = DS2.Tables(0)
        ElseIf strSht = "History_AFTS" Then
            DataGridView3.DataSource = DS3.Tables(0)
        ElseIf strSht = "History_Term" Then
            DataGridView4.DataSource = DS4.Tables(0)
        ElseIf strSht = "History_Tip" Then
            DataGridView5.DataSource = DS5.Tables(0)
        End If
    End Sub

    Private Sub History_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim xml As New XML
            Dim vCon As String = Nothing
            ' vcon가져오는 함수
            xml.vCon_Admin_Call(vCon)
            ' Connect 연결
            vConn = New OleDbConnection(vCon)
            vConn.Open()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "DB Open에러")
            Exit Sub
        End Try
        ' 기본 값과 셋팅 설정
        With DataGridView1
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            .AllowUserToResizeColumns = True
            .AllowUserToResizeRows = True
            .MultiSelect = False
        End With
        With DataGridView2
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            .AllowUserToResizeColumns = True
            .AllowUserToResizeRows = True
            .MultiSelect = False
        End With
        With DataGridView3
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            .AllowUserToResizeColumns = True
            .AllowUserToResizeRows = True
            .MultiSelect = False
        End With
        With DataGridView4
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            .AllowUserToResizeColumns = True
            .AllowUserToResizeRows = True
            .MultiSelect = False
        End With
        With DataGridView5
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            .AllowUserToResizeColumns = True
            .AllowUserToResizeRows = True
            .MultiSelect = False
        End With
        strSht = TabControl1.SelectedTab.Text

        Dim rngSht(5) As String
        rngSht(0) = "History_QPortal"
        rngSht(1) = "History_FUT"
        rngSht(2) = "History_AFTS"
        rngSht(3) = "History_Term"
        rngSht(4) = "History_Tip"
        Dim vSQL(5) As String


        For i As Integer = 0 To 4
            vSQL(i) = "Select * from [" & rngSht(i) & "] order by [ID] asc"
        Next

        Dim Main_DA = New OleDbDataAdapter(vSQL(0), vConn)
        Dim FUT_DA = New OleDbDataAdapter(vSQL(1), vConn)
        Dim AFTS_DA = New OleDbDataAdapter(vSQL(2), vConn)
        Dim Term_DA = New OleDbDataAdapter(vSQL(3), vConn)
        Dim Tip_DA = New OleDbDataAdapter(vSQL(4), vConn)

        Main_DA.Fill(DS, strSht)
        FUT_DA.Fill(DS2, strSht)
        AFTS_DA.Fill(DS3, strSht)
        Term_DA.Fill(DS4, strSht)
        Tip_DA.Fill(DS5, strSht)

        DataGridView1.DataSource = DS.Tables(0)

    End Sub
End Class