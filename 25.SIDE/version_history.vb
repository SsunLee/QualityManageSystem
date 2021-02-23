Imports System.Data
Imports System.Diagnostics
Imports System.Drawing
Imports System.Windows.Forms
Imports MySql.Data.MySqlClient

Public Class version_history
    Public pl As plan_class = New plan_class()
    Public ModelInfo As DataSet = New DataSet
    Public macro_path As String = Nothing

#Region "처음 로드될 때"
    Private Sub version_history_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Panel3.AllowDrop = True

        Icon = My.Resources.Qportal_Icon

        With la_DragOver
            .Font = New Font("맑은 고딕", 12, FontStyle.Bold)
            '.ForeColor = Color.Gray
            .ForeColor = Color.FromArgb(125, 125, 125)
            .Text = "Attach File with drag and drop in anywhere" & Environment.NewLine & "이곳에 파일을 드래그 하세요."
        End With
    End Sub
#End Region


#Region "드래그 해서  [엑셀 업로드 기능]"

    '# 폼에 마우스 가져다 댔을 때
    Private Sub UploadExcel_DragEnter(sender As Object, e As System.Windows.Forms.DragEventArgs) Handles Panel3.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then ' 만약 갖다대는게 파일일 경우
            e.Effect = DragDropEffects.Copy
        End If
    End Sub

    Private Sub UploadExcel_DragDrop(sender As Object, e As System.Windows.Forms.DragEventArgs) Handles Panel3.DragDrop

        Dim pl As plan_class = New plan_class()

        Dim pl_select As New pl_select
        pl_select.ShowDialog()
        Debug.Print(pl_select.getResult)
        Dim name As String = pl.getUserName()
        Dim cp As String = pl.getCompany(name)


        Dim blCheck As Boolean = False
        '# DragDrop 시 DragEventArgs를 통해 Data를 받아 온다. 
        Dim files() As String = e.Data.GetData(DataFormats.FileDrop)
        '# Array 형식으로 저장 된 것을 난 파일 하나만 허용 할 거기 때문에 
        Dim path As String = files(0)

        Dim strExtension As String = Nothing
        Dim fi As New IO.FileInfo(path)

        macro_path = fi.FullName
        '# 확장자 알아내기
        strExtension = fi.Extension

        If strExtension <> ".xlsm" Then
            MessageBox.Show("확장자가 ""xlsm"" 인 엑셀 파일만 올려주세요. ", "lee.sunbae@lgepartner.com", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        '# 2. [Excel File to DataGridView]
        'blCheck = Excel_File_to_DataGridView(path)

        If DialogResult.Yes = MessageBox.Show("바로 결과를 올리시겠습니까?" &
                                              Environment.NewLine & "바로 DB에 올리려면 ""예""" &
                                              Environment.NewLine & "확인 하고 올리려면 ""아니오""를 누르세요.",
                                              "lee.sunbae@lgepartner.com", MessageBoxButtons.YesNo, MessageBoxIcon.Information) Then


            Dim PassResult As String = Nothing
            If pl_select.rdo_pln.Checked = True Then
                getInfo(fi.FullName)
                Dim dt_table As DataTable = ModelInfo.Tables(0)
                PassResult = insert_db(dt_table)
                'PassResult = Database_Update(dt)    '# 이부분이 실제 Database 올리는 부분
                'PassResult = Database_Update_Func(dt)    '# 이부분이 실제 Database 올리는 부분


            ElseIf pl_select.rdo_app.Checked = True Then

            Else
                MessageBox.Show("항목 선택 후 다시 시도 해주세요.", "lee.sunbae@lgepartner.com", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            'PassResult = Database_Update(dt)    '# 이부분이 실제 Database 올리는 부분

            'PassResult = Database_Update_Change_note(dt)
            MessageBox.Show(PassResult,
                                        "lee.sunbae@lgepartner.com",
                                                MessageBoxButtons.OK, MessageBoxIcon.Information)
            Close()

        Else
            'btnDBUp.Visible = True

        End If



    End Sub

#End Region

    Private Sub getInfo(ByRef path As String)
        Dim vConn As System.Data.OleDb.OleDbConnection
        Dim DS As DataSet
        Dim proCmd As System.Data.OleDb.OleDbDataAdapter
        vConn = New System.Data.OleDb.OleDbConnection("Provider=Microsoft.Ace.OLEDB.12.0;Data Source=" & path & ";Extended Properties=""Excel 12.0;HDR=YES;""")

        Try
            vConn.Open()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "(Sunbae) - DB Open 에러", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Dim table_name As String = "랜덤_실사용 가이드$"

        proCmd = New System.Data.OleDb.OleDbDataAdapter("Select * FROM [" & table_name & "A3:G4]", vConn)

        Try
            DS = New DataSet
            proCmd.Fill(ModelInfo)
        Catch ex As Exception
            System.Diagnostics.Debug.Print(ex.Message)
        Finally
            vConn.Close()
        End Try

        Try
            vConn.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "(Sunbae) - DB Open 에러", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub


    Private Function insert_db(ByRef dt As DataTable) As String
        Dim reader As MySqlDataReader = Nothing
        Dim cmd As MySqlCommand = New MySqlCommand()
        Dim sql As String = Nothing
        Dim myCon As MySqlConnection = New MySqlConnection(pl.strSQLCon)    ' connection open
        Dim name As String = pl.getUserName()
        Dim cp As String = pl.getCompany(name)

        Try '// Open mySQL Connection Databe 
            myCon.Open()
            cmd.Connection = myCon
        Catch ex As Exception
            MessageBox.Show(ex.Message, "(Sunbae) - DB Open 에러", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Dim tbl As String = pl.getTableName() & "." & "rs_version" '# MySQL Table명 지정
        Dim num As Long = 0

        Dim pjt As String, osu As String, grp As String, suff As String, smod As String, steps As String, ver As String

        pjt = dt.Rows(0).Item("Project")
        osu = dt.Rows(0).Item("OSU")
        grp = dt.Rows(0).Item("Group")
        suff = dt.Rows(0).Item("Suffix")
        smod = dt.Rows(0).Item("Model")
        steps = dt.Rows(0).Item("Step")
        ver = dt.Rows(0).Item("Version")

        Dim sum_sql As String, insert_sql As String
        sum_sql = sum_sql & "('" & pjt & "','" & osu & "','" & grp & "','" & suff & "','" & smod & "','" & steps & "','" & ver & "','" & macro_path & "','" & CStr(Now()) & "')"
        insert_sql = "INSERT INTO " & tbl & " (pjt, osu, grp, suffix, model, step, ver, filename, insert_time) 
                         VALUES " & sum_sql



        Try
            cmd.CommandText = insert_sql
            cmd.ExecuteNonQuery()   '// Insert into
        Catch ex As Exception
            MessageBox.Show(ex.Message, "(Sunbae) - DB 올리기 에러", MessageBoxButtons.OK, MessageBoxIcon.Error)
            insert_db = True
            Exit Function
        Finally
            myCon.Close()
        End Try


        insert_db = "완료"


        Return insert_db






    End Function

#Region "특문몇개 제거"
    Private Function remove_colon(ByVal s As String) As String
        Dim t As String
        t = Replace(s, "'", "")
        't = Replace(t, "*", "")
        s = t
        Return s
    End Function
#End Region
End Class