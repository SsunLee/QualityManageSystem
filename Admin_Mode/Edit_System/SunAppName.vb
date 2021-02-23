Imports System.Data
Imports System.Data.OleDb
Imports System.Windows.Forms

Public Class SunAppName
    Public DS As DataSet = New DataSet
    Public DA As OleDbDataAdapter = New OleDbDataAdapter()
    Public vConn As OleDbConnection = New OleDbConnection
    Public strCon As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\WorkSpace\01. Work\2018\03. March\0315\QPortalDB.accdb;Jet OLEDB:Database Password = lge1234;"

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click

        Dim xml As New XML
        Dim vCon As String = Nothing

        xml.vCon_Call(vCon)
        vConn = New OleDbConnection(vCon)

        vConn.Open()

        Dim sql As String = Nothing
        sql = "INSERT INTO TD_AF_DS (Type, AppName, Feature, Description ) " &
                    "values('" & cbAppType.Text & "','" + txtAppName.Text + "','" + txtFeature.Text + "','" + txtDescription.Text + "');"
        Dim myCmd As OleDbCommand = New OleDbCommand(sql, vConn)
        Dim check As Integer = myCmd.ExecuteNonQuery()

        vConn.Close()

        MessageBox.Show("추가 완료 되었습니다.")

        Dim vSQLType As String = IIf(cbAppType.Text = "", "", "AND [Type] LIKE '%" & Replace(cbAppType.Text, "'", "''") & "%'")
        Dim vSQLApp As String = IIf(txtAppName.Text = "", "", "AND [AppName] LIKE '%" & Replace(txtAppName.Text, "'", "''") & "%'")
        Dim vSQLFea As String = IIf(txtFeature.Text = "", "", "AND [Feature] LIKE '%" & Replace(txtFeature.Text, "'", "''") & "%'")

        ''    ▼▼ 이미 DB에 있는 것 인지? Check 함
        'Dim sql As String
        'sql = "SELECT ID, [Type], [AppName], Feature "
        'sql = sql & "FROM TD_AF_DS"
        'sql = sql & " WHERE ID > 0" & vSQLType & vSQLApp & vSQLFea

        'Dim result As DataTable = New DataTable
        'Dim cmd As OleDbCommand = New OleDbCommand(sql, vConn)
        ''     ▼▼ Data Adapter를 사용해 Data Table을 만들고 Query 된 Result를 Count 하여 기존 Data가 있는지 Check 
        'Dim adapter As OleDbDataAdapter = New OleDbDataAdapter(cmd)
        'adapter.Fill(result)

        ''    ▼▼  만약 조회가 안 됐다면 ?  새 항목
        'If result.Rows.Count = 0 Then
        '    ' is it insert
        '    sql = "INSERT INTO TD_AF_DS (Type, AppName, Feature, Description ) " &
        '                "values('" & cbAppType.Text & "','" + txtAppName.Text + "','" + txtFeature.Text + "','" + txtDescription.Text + "');"
        '    myCmd = New OleDbCommand(Sql, vConn)

        '    check = myCmd.ExecuteNonQuery()

        'Else
        '    MsgBox("이미 존재 하는 앱 과 기능입니다.")
        '    '◀◀ 기존 데이터와 덮어쓰기 해야 한다면
        '    'sql = "UPDATE TD_AF_DS SET [AAA] ='" & sz1 & "', BBB ='" & sz2 & "', CCC ='" & sz3 & "'"
        '    'myCmd = New OleDbCommand(sql, vConn)

        '    'check = myCmd.ExecuteNonQuery()
        'End If




    End Sub

    Private Sub SunAppName_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        cbAppType.Items.Add("LG")
        cbAppType.Items.Add("Operator")


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        '----------------------------------------------------
        '내 용 : Test Action 새로 추가하는 것
        '----------------------------------------------------

        Dim xml As New XML
        Dim vCon As String = Nothing

        xml.vCon_Call(vCon)
        vConn = New OleDbConnection(vCon)

        vConn.Open()

        Dim sql As String = Nothing
        sql = "INSERT INTO TD_TA (TestAction_Type, TestAction, Description ) " &
                    "values('" & txtTestAction_Type.Text & "','" + txtTestAction.Text + "','" + txtDescription.Text + "');"
        Dim myCmd As OleDbCommand = New OleDbCommand(sql, vConn)
        Dim check As Integer = myCmd.ExecuteNonQuery()

        vConn.Close()

        MessageBox.Show("추가 완료 되었습니다.")


    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        '----------------------------------------------------
        '내 용 : Detailed Symptom 새로 추가하는 것
        '----------------------------------------------------

        Dim xml As New XML
        Dim vCon As String = Nothing

        xml.vCon_Call(vCon)
        vConn = New OleDbConnection(vCon)

        vConn.Open()

        Dim sql As String = Nothing
        sql = "INSERT INTO TD_DS (DetailedSymptom_Type, DetailedSymptom) " &
                    "values('" & txtDetailed_Symptom.Text & "','" + txtDetailed_Symptom2.Text + "');"
        Dim myCmd As OleDbCommand = New OleDbCommand(sql, vConn)
        Dim check As Integer = myCmd.ExecuteNonQuery()

        vConn.Close()

        MessageBox.Show("추가 완료 되었습니다.")
    End Sub
End Class