Imports System.Data
Imports System.Data.OleDb

Public Class ModifyInfo

    Public vConn As OleDbConnection


    Private Sub ModifyInfo_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        '-----------------------------------------------------------
        ' set Default Table
        '-----------------------------------------------------------
        Dim dtgrid As DataTable = New DataTable
        Dim strcolumns = {"Project", "Model", "차수", "사업자", "업체명"}
        Dim rowPosition As Integer = DataGridView1.Rows.Count

        For Each a As String In strcolumns
            dtgrid.Columns.Add(New DataColumn(a))
        Next
        DataGridView1.DataSource = dtgrid



        Dim Change_Add_Tree As New Change_Add_Tree
        vConn = New OleDbConnection(Change_Add_Tree.strCon)
        vConn.Open()

        Dim sql As String = Nothing
        Dim vSQL_pro As String = Nothing
        Dim vSQL_Mod As String = Nothing
        Dim vSQL_Step As String = Nothing

        'IIf(txtPro.Text = "", vSQL_pro = " AND [Project] LIKE '%" & Replace(txtPro.Text, "'", "''") & "%'", vSQL_pro = "")
        'IIf(txtMod.Text = "", vSQL_Mod = " AND [Model] LIKE '%" & Replace(txtPro.Text, "'", "''") & "%'", vSQL_Mod = "")
        'IIf(txtStep.Text = "", vSQL_Step = " AND [차수] LIKE '%" & Replace(txtPro.Text, "'", "''") & "%'", vSQL_Step = "")

        sql = "SELECT Project, Model, 차수, 사업자, 업체명 "
        sql = sql & "FROM 검계_DB "
        sql = sql & "WHERE ID > 0 " ' & vSQL_pro & vSQL_Mod & vSQL_Step


        Dim result As DataTable = New DataTable
        Dim cmd As OleDbCommand = New OleDbCommand(sql, vConn)
        '     ▼▼ Data Adapter를 사용해 Data Table을 만들고 Query 된 Result를 Count 하여 기존 Data가 있는지 Check 
        Dim adapter As OleDbDataAdapter = New OleDbDataAdapter(cmd)
        adapter.Fill(result)

        ' Datatable 중복제거 
        Dim dt_new As DataTable = New DataTable
        '{"Project", "Model", "차수", "사업자", "업체명"}  
        dt_new = result.DefaultView.ToTable(True, "Project", "Model", "차수", "사업자", "업체명")
        'dt_new = result.DefaultView.ToTable()
        DataGridView1.DataSource = dt_new










    End Sub
End Class