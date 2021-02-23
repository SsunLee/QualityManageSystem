Imports System.ComponentModel
Imports System.Data
Imports System.Data.OleDb
Imports System.Windows.Forms

Public Class func_DataGridView_Form

    Private Sub func_DataGridView_Form_Closing(sender As Object, e As FormClosingEventArgs) Handles Me.Closing
        ' User가 Close 했을 때 실제 Close 되지 않고 Hide할 수 있게
        If e.CloseReason = CloseReason.UserClosing Then
            e.Cancel = True ' Event Cancel
            Visible = False

        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        '------------------------------------------------------------------
        '내용 : DataGridView에 있는 내용 DB에 올리기!
        '------------------------------------------------------------------
        Dim XML As New XML
        Dim DS As DataSet = New DataSet
        Dim DA As OleDbDataAdapter = New OleDbDataAdapter
        Dim vConn As OleDbConnection = New OleDbConnection
        Dim vCon As String = Nothing

        Dim nCnt_update As Integer = 0      ' Update or Add 할 때 Count 하기 위함.
        Dim nCnt_insert As Integer = 0

        XML.vCon_Call(vCon)                     ' xml 에서 Connection String 가져오기.

        Dim Change_Add_Tree As New Change_Add_Tree

        Dim dt As New DataTable()
        dt = TryCast(DataGridView1.DataSource, DataTable)   ' DataGridView에 담겨진 데이터를 DataTable에 담음.
        dt.AcceptChanges()

        vConn = New OleDbConnection(Change_Add_Tree.strCon)
        vConn.Open()
        ' 담겨있는 Table을 반복하면서 db에 추가하기 위함.
        For value As Integer = 0 To dt.Rows.Count - 1
            Dim sz0 As String = Convert.ToString(dt.Rows(value).ItemArray.GetValue(0))    '// APP Name 
            Dim sz1 As String = Convert.ToString(dt.Rows(value).ItemArray.GetValue(1))    '// Feature
            Dim sz2 As String = Convert.ToString(dt.Rows(value).ItemArray.GetValue(2))    '// 변경점
            Dim sz3 As String = Convert.ToString(dt.Rows(value).ItemArray.GetValue(3))    '// 변경점 내용
            Dim sz4 As String = Convert.ToString(dt.Rows(value).ItemArray.GetValue(4))    '// Project
            Dim sz5 As String = Convert.ToString(dt.Rows(value).ItemArray.GetValue(5))    '// Model
            Dim sz6 As String = Convert.ToString(dt.Rows(value).ItemArray.GetValue(6))    '// 차수
            Dim sz7 As String = Convert.ToString(dt.Rows(value).ItemArray.GetValue(7))    '// 사업자
            Dim sz8 As String = Convert.ToString(dt.Rows(value).ItemArray.GetValue(8))    '// 업체명

            sz2 = Replace(sz2, "'", "")     ' 주석 예약어인 ' 를 제거하기 위함.
            sz2 = LTrim(sz2)                ' 좌쪽 공백제거,  좌측에 공백이 있을 경우 Query 시 인식못할 수 있음

            ' 기존 Data 있는지 Check 하기 위한 Query 작성
            Dim vSQL_Pro As String = Nothing, vSQL_Mod As String = Nothing
            Dim vSQL_Change As String = Nothing, VSQL_Step As String = Nothing
            Dim vSQL_Suffix As String = Nothing, vSQL_App As String = Nothing
            Dim vSQL_Feature As String = Nothing

            vSQL_App = " AND [App Name] = '" & Replace(sz0, "'", "''") & "'"  ' APP Name 
            vSQL_Feature = " AND [Feature] = '" & Replace(sz1, "'", "''") & "'"  ' Feature
            vSQL_Change = " AND [변경점] = '" & Replace(sz2, "'", "''") & "'"  ' 변경점 

            vSQL_Pro = " AND [Project] = '" & Replace(sz4, "'", "''") & "'"             ' Project
            vSQL_Mod = " AND [Model] = '" & Replace(sz5, "'", "''") & "'"            ' Model
            VSQL_Step = " AND [차수] = '" & Replace(sz6, "'", "''") & "'"              ' 차수
            vSQL_Suffix = " AND [사업자] = '" & Replace(sz7, "'", "''") & "'"              ' 차수

            Dim sSQL As String = "SELECT ID, [App Name], Feature, 변경점, Project, Model, 차수, 사업자, 업체명 FROM 검계_DB"
            sSQL = sSQL & " WHERE ID > 0 " & vSQL_App & vSQL_Feature & vSQL_Pro & vSQL_Mod & VSQL_Step & vSQL_Suffix & vSQL_Change

            Dim result As DataTable = New DataTable
            Dim cmd As OleDbCommand = New OleDbCommand(sSQL, vConn)
            '     ▼▼ Data Adapter를 사용해 Data Table을 만들고 Query 된 Result를 Count 하여 기존 Data가 있는지 Check 
            Dim adapter As OleDbDataAdapter = New OleDbDataAdapter(cmd)
            adapter.Fill(result)

            ' Push the Query
            '    ▼▼  만약 조회가 안 됐다면 ?  새 항목
            If result.Rows.Count = 0 Then
                ' is it insert
                Dim Sql As String = "INSERT INTO 검계_DB ([App Name], Feature, 변경점, [변경점 내용], Project, Model, 차수, 사업자, 업체명, 파일명) " &
                        "values('" & sz0 & "','" + sz1 + "','" + sz2 + "','" + sz3 + "','" + sz4 + "','" + sz5 + "','" + sz6 + "','" + sz7 + "','" + sz8 + "','" + "Qportal_System" + "');"
                Dim myCmd As OleDbCommand = New OleDbCommand(Sql, vConn)
                Dim check As Integer = myCmd.ExecuteNonQuery()
                nCnt_insert += 1

            Else '◀◀ 기존 데이터와 덮어쓰기 해야 한다면

                Dim sql As String
                sql = "UPDATE 검계_DB SET "
                sql = sql & "[App Name] ='" & sz0 & "', "
                sql = sql & "Feature ='" & sz1 & "', "
                sql = sql & "변경점 ='" & sz2 & "', "
                sql = sql & "[변경점 내용] ='" & sz3 & "', "
                sql = sql & "Project ='" & sz4 & "', "
                sql = sql & "Model ='" & sz5 & "', "
                sql = sql & "차수 ='" & sz6 & "', "
                sql = sql & "사업자 ='" & sz7 & "', "
                sql = sql & "업체명 ='" & sz8 & "' "
                sql = sql & " WHERE ID = " & result.Rows(0)(0).ToString() & " And [App Name] = '" & sz0 & "' And Feature = '" & sz1 & "' And 변경점 = '" & sz2 & "'"
                Dim myCmd As OleDbCommand = New OleDbCommand(sql, vConn)
                Dim check As Integer = myCmd.ExecuteNonQuery()
                nCnt_update += 1

            End If

        Next

        vConn.Close()
        CreateObject("WScript.Shell").Popup("업데이트 : " & nCnt_update & " ◀완료되었습니다.", 1, "Q-Portal")
        CreateObject("WScript.Shell").Popup("새로추가 : " & nCnt_insert & " ◀완료되었습니다.", 1, "Q-Portal")


    End Sub

    Private Sub func_DataGridView_Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Icon = My.Resources.Qportal_Icon
    End Sub
End Class