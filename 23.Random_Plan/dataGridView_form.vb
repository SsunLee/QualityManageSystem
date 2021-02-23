Imports System.ComponentModel
Imports System.Data
Imports System.Data.OleDb
Imports System.Windows.Forms


Public Class dataGridView_form

    Public vConn As OleDbConnection
    Public myCmd As OleDbCommand


    Private Sub dataGridView_form_Closing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        ' User가 Close 했을 때 실제 Close 되지 않고 Hide할 수 있게
        If e.CloseReason = CloseReason.UserClosing Then
            e.Cancel = True ' Event Cancel
            Hide()
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        '--------------------------------------------------------------------------------------
        ' 내 용 : DataGridView에 올라와 있는 내용을 DB에 UPDATE TABLE SET  한다.
        '---------------------------------------------------------------------------------------
        Dim DS As DataSet = New DataSet
        Dim DA As OleDbDataAdapter = New OleDbDataAdapter
        Dim check As Integer = 0

        Dim vCon As String = Nothing
        Dim XML As New XML
        XML.vCon_Call(vCon)

        Dim nCnt_update As Integer = 0
        Dim nCnt_insert As Integer = 0

        Dim dt As New DataTable()
        dt = TryCast(DataGridView1.DataSource, DataTable)   ' DataGridView에 있는 자료를 Datatable로 옮김 

        Try
            For value As Integer = 0 To dt.Rows.Count - 1       ' 옮겨 담은 자료를 반복하여 Query 할 예정
                ' String 변수에 담음
                Dim sGubun As String = Convert.ToString(dt.Rows(value).ItemArray.GetValue(0))                     '// 구분            체크
                Dim sMajorChange As String = Convert.ToString(dt.Rows(value).ItemArray.GetValue(1))            '// 주요 변경점    체크
                Dim sChangeContents As String = Convert.ToString(dt.Rows(value).ItemArray.GetValue(2))        '// 변경점 내용    
                Dim sRisk As String = Convert.ToString(dt.Rows(value).ItemArray.GetValue(3))                        '// Risk
                Dim sTestType As String = Convert.ToString(dt.Rows(value).ItemArray.GetValue(4))                  '// 검증유형 ★★ 얘가 filed 영역   
                Dim sTestTypeContents As String = Convert.ToString(dt.Rows(value).ItemArray.GetValue(5))      '// 검증유형 내용  ★★얘가         체크
                Dim sProject As String = Convert.ToString(dt.Rows(value).ItemArray.GetValue(6))                    '// Project                              체크
                Dim sModel As String = Convert.ToString(dt.Rows(value).ItemArray.GetValue(7))                     '// Model                             체크

                sMajorChange = Replace(sMajorChange, "'", "")
                sMajorChange = LTrim(sMajorChange)

                sChangeContents = Replace(sChangeContents, "'", "")
                sChangeContents = LTrim(sChangeContents)

                sRisk = Replace(sRisk, "'", "")
                sRisk = LTrim(sRisk)

                sTestTypeContents = Replace(sTestTypeContents, "'", "")
                sTestTypeContents = LTrim(sTestTypeContents)

                Dim sCompany As String = Convert.ToString(dt.Rows(value).ItemArray.GetValue(8))                     '// 등록자                             체크
                Dim sRequester As String = Convert.ToString(dt.Rows(value).ItemArray.GetValue(9))                     '// 등록자                             체크

                Dim sTCCheckbox As String = Convert.ToString(dt.Rows(value).ItemArray.GetValue(10))                '// TC진행 여부 Neo..                           
                Dim sTCName As String = Convert.ToString(dt.Rows(value).ItemArray.GetValue(11))                     '// T/C Name

                ' 기존 Data 있는지 Check 하기 위한 Query 작성
                Dim vSQL_field As String = Nothing, vSQL_Type As String = Nothing
                Dim vSQL2_Major As String = Nothing, vSQL2_Func As String = Nothing
                Dim vSQL_Pro As String = Nothing, vSQL_Mod As String = Nothing
                Dim vSQL_TestType As String = Nothing, vSQL_TestType_Contents As String = Nothing

                vSQL_Type = "[구분] LIKE '%" & Replace(sGubun, "'", "''") & "%'"                                    ' Field가 비어있으면 
                vSQL2_Major = " AND [주요변경점] LIKE '%" & Replace(sMajorChange, "'", "''") & "%'"
                vSQL_TestType = " AND [검증유형] LIKE '%" & Replace(sTestType, "'", "''") & "%'"
                'vSQL_TestType_Contents = " AND [검증유형내용] LIKE '%" & Replace(sChangeContents, "'", "''") & "%'"

                vSQL_Pro = " AND [Project] LIKE '%" & Replace(sProject, "'", "''") & "%'"
                vSQL_Mod = " AND [Model] LIKE '%" & Replace(sModel, "'", "''") & "%'"

                'vSQL_field = " And [" & "검증유형" & "] Like '%" & Replace(sTestType, "'", "''") & "%'"           ' 타이틀 체크

                Dim sql As String = Nothing
                sql = "SELECT * "
                sql = sql & "FROM [SW_Validation_Result] "
                sql = sql & "WHERE ID > 0 And " & vSQL_Type & vSQL2_Major & vSQL_Pro & vSQL_Mod & vSQL_TestType '&' vSQL_TestType_Contents

                vConn = New OleDbConnection(vCon)   ' MainForm의 Connection String으로 DB Connect
                vConn.Open()

                Dim result As DataTable = New DataTable
                Dim cmd As OleDbCommand = New OleDbCommand(sql, vConn)
                '     ▼▼ Data Adapter를 사용해 Data Table을 만들고 Query 된 Result를 Count 하여 기존 Data가 있는지 Check 
                Dim adapter As OleDbDataAdapter = New OleDbDataAdapter(cmd)
                adapter.Fill(result)

                '    ▼▼  만약 조회가 안 됐다면 ?  새 항목
                If result.Rows.Count = 0 Then
                    ' is it insert
                    sql = "INSERT INTO SW_Validation_Result (구분, 주요변경점, 변경점내용, Risk, 검증유형, 검증유형내용, Project, Model, 업체명, 등록자, TC진행여부, TC명) " &
                    "values('" & sGubun & "','" + sMajorChange + "','" + sChangeContents + "','" + sRisk + "','" + sTestType + "','" + sTestTypeContents + "','" + sProject + "','" + sModel + "','" + sCompany + "','" + sRequester + "','" + sTCCheckbox + "','" + sTCName + "');"
                    myCmd = New OleDbCommand(Sql, vConn)
                    check = myCmd.ExecuteNonQuery()
                    nCnt_insert += 1

                Else '◀◀ 기존 데이터와 덮어쓰기 해야 한다면

                    sql = "UPDATE SW_Validation_Result SET "
                    sql = sql & "[구분] ='" & sGubun & "', "
                    sql = sql & "주요변경점 ='" & sMajorChange & "', "
                    sql = sql & "변경점내용 ='" & sChangeContents & "', "
                    sql = sql & "Risk ='" & sRisk & "', "
                    sql = sql & "검증유형 ='" & sTestType & "', "
                    sql = sql & "검증유형내용 ='" & sTestType & "', "
                    sql = sql & "TC진행여부 ='" & sTCCheckbox & "', "
                    sql = sql & "TC명 ='" & sTCName & "' "
                    sql = sql & " WHERE ID = " & result.Rows(0)(0).ToString()
                    myCmd = New OleDbCommand(sql, vConn)
                    check = myCmd.ExecuteNonQuery()
                    nCnt_update += 1
                End If


                vConn.Close()
            Next

            MsgBox("완료")


        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try


    End Sub

    Private Sub dataGridView_form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Icon = My.Resources.Qportal_Icon
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ' IMPORT 하기
        Dim path As String = Nothing
        Dim myStream As Stream = Nothing
        Dim openFileDialog1 As New OpenFileDialog()

        openFileDialog1.InitialDirectory = "c:\"
        openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*"
        openFileDialog1.FilterIndex = 2
        openFileDialog1.RestoreDirectory = True

        If openFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            Try
                path = openFileDialog1.FileName
            Catch Ex As Exception
                MessageBox.Show("엑셀 파일이 없습니다." & Ex.Message)
            End Try

        Else
            Exit Sub

        End If


        Dim vConn As OleDbConnection
        Dim DS As DataSet
        Dim myCmd As OleDbDataAdapter


        vConn = New OleDbConnection("Provider=Microsoft.Ace.OLEDB.12.0;Data Source=" & path & ";Extended Properties=""Excel 12.0;HDR=YES;""")
        myCmd = New OleDbDataAdapter("Select * FROM [Sheet1$]", vConn)

        'Provider=Microsoft.Ace.OLEDB.12.0;Data Source=" & path & ";Extended Properties=""Excel 12.0;HDR=YES;"""

        DS = New DataSet
        myCmd.Fill(DS)

        DataGridView1.DataSource = DS.Tables(0)

        vConn.Close()



    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs)
        '-----------------
        '내용 : 불러오기
        '----------------

        '' Create an instance of the class that imports Excel files
        'Dim workbook As ExcelDocument = New ExcelDocument()

        '' Import Excel file to DataSet
        'Dim ds As DataSet =
        '        workbook.easy_ReadXLSActiveSheet_AsDataSet("C:\\Samples\\Excel to DataGridView.xls")

        '' Get the DataTable of the DataSet
        'Dim dataTable As DataTable = ds.Tables(0)

        '' Extract the first Excel row as header
        'Dim header As Object() = dataTable.Rows(0).ItemArray
        'dataTable.Rows.RemoveAt(0)

        '' Set the data source of the DataGridView
        'DataGridView.DataSource = dataTable

        '' Set DataGridView header data from the first Excel row
        'For column As Integer = 0 To dataTable.Columns.Count - 1
        '    DataGridView.Columns(column).HeaderText = header(column)
        'Next



    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub Button3_Click_1(sender As Object, e As EventArgs) Handles Button3.Click
        '미리보기 시 DB Load해서 본인이 업데이트 한게 재대로 되었는지 확인할 수 있도록.
        'Dim Check_Data As New Check_Data

        'Check_Data.strProject = txt_pro_in.Text
        'Check_Data.strModel = txt_model_in.Text

        'Check_Data.strCompany = txtCompnay_in.Text
        'Check_Data.strRequester = txtRequest_in.Text


        'Check_Data.Show()

    End Sub
End Class