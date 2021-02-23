Imports System.Data
Imports System.Data.OleDb
Imports System.Windows.Forms
Imports System.Drawing

Public Class Dictionary_GM
    Public DS As DataSet = New DataSet                                 '★ Dataset 선언  
    Private DA As OleDbDataAdapter = New OleDbDataAdapter()
    Public ordAdapter As OleDbDataAdapter = New OleDbDataAdapter()
    Private strSQL As String
    Private vConn As OleDbConnection
    Public XML As New XML
    Dim strSht As String = "용어"  ' Excel로 된 Database Table명 지정 (엑셀에서는 Sheet명)
    Dim vcon As String = Nothing

    Public strCon As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\신창하\업무\Task\Test_db\20180328_QPortalDB.accdb;Jet OLEDB:Database Password = lge1234;"


    ' ### 용어 검색 시 호출 되는 Event
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim strSearch As String = Nothing
        Dim vSQL As String = Nothing
        Dim strDae As String = Nothing     ' 대분류 
        Dim strMid As String = Nothing     ' 중분류

        If TextBox1.Text = "" Or Strings.Left(TextBox1.Text, 3) = "ex)" Then            ' 처음 ex) 검색어 입력 후 엔터하세요. <-- 글자가 있으면 
            strSearch = ""                                                              ' 사용자가 검색어를 입력할 수 있게 ex)<- 글자 포함 되어있으면 검색어 내용 초기화
        Else
            strSearch = " AND 용어 LIKE '%" & Replace(TextBox1.Text, "'", "''") & "%'"    ' 사용자가 검색어 입력 시, 입력한 값과 DB의 값을 비교하여 일치하는 것 찾음.
        End If

        If ComboBox1.Text = "" Then ' 최초 진입 시 Combobox 내용 초기화
            strDae = ""
        Else
            strDae = " AND 대분류 LIKE '%" & Replace(ComboBox1.Text, "'", "''") & "%'"
        End If

        vSQL = "SELECT ID,용어,설명,[비고 (Update시 설명 누적]" & " "                      ' 쿼리 작성
        vSQL = vSQL + "FROM " & strSht & " "
        vSQL = vSQL + "Where 용어 > ''" & strSearch & strDae & strMid & ""               ' 위에서 작성한 검색어 쿼리와 일치하는 항목을 기반으로 쿼리 실행
        vSQL = vSQL + " ORDER BY 용어"

        Try
            vConn = New OleDbConnection(vcon)
            Dim DA = New OleDbDataAdapter(vSQL, vConn)  ' 작성한 Query문으로 조회       DA <-- db에 연결  ( vSQL, vConn)
            Dim DS As New DataSet                       ' Dataset 새로 생성                               쿼리문, db연결 문자

            DA.Fill(DS, strSht)                         ' DataSet에 쿼리조회 값 채우기 (db에서 가져온 내용을 작은 그릇에 담음)

            Dim Table_Word As DataTable = DS.Tables(0)  ' 작은 그릇의 내용을 Table로 선언 <- 쉽게 사용하기 위해.

            If Table_Word.Rows.Count = 0 Then           ' 만약 조회 된 Data가 없으면 메시지 띄워 주기.
                MsgBox("검색결과가 없습니다.")
                Des_Txt.Text = ""
                TextBox3.Text = ""
            End If

            Table_Word.DefaultView.Sort = "용어 ASC"     ' Table의 내용을 용어 기준으로 정렬 함. (A,B,C, 가,나,다 순)
            Table_Word = Table_Word.DefaultView.ToTable(True, "용어") ' 검색한 결과 중 "용어" 부분을 '검색결과리스트'에 보여줌. (TRUE, "용어") <-- True는 중복 제거 

            Search_Result.DataSource = Table_Word                     ' Data를 ListBox에 뿌려줌.
            With Search_Result
                .DisplayMember = "용어"
                .ValueMember = "용어"
            End With

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    ' ### Main Form 호출 됐을 때 처음 DataTable에 담음
    Private Sub Dictionary_Sub_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Icon = My.Resources.Qportal_Icon

        Dim toolTip1 As New ToolTip()
        toolTip1.SetToolTip(ComboBox1, "대분류 카테고리를 선택할 수 있습니다. * 선택하지 않아도 됩니다.")
        ' toolTip1.SetToolTip(ComboBox2, "대분류 카테고리를 선택할 수 있습니다. * 선택하지 않아도 됩니다.")
        toolTip1.SetToolTip(TextBox1, "검색어를 입력하세요.")
        toolTip1.SetToolTip(Button2, "Search")
        toolTip1.InitialDelay = 100
        toolTip1.AutoPopDelay = 1000
        toolTip1.ReshowDelay = 500

        Try
            ' vcon가져오는 함수  ( DB Connection String 가져옴 XML.vb <-- 파일에서 )
            XML.vCon_Call(vcon)
            ' Connect 연결
            vConn = New OleDbConnection(vcon)   ' DB 연결

            ' Query 실행
            Dim DA As OleDbDataAdapter = New OleDbDataAdapter("Select * FROM [" & strSht & "] Where [용어] > '' Order by [용어] ", vConn)

            ' Dataset에 값 넣기
            DA.Fill(DS, strSht)

            ' Dataset의 값을 Table에 담음
            Dim Table As DataTable = DS.Tables(0)

            XML = Nothing
            ' Table의 내용을 Combobox1에 넣음
            Table = Table.DefaultView.ToTable(True, "대분류")  ' 중복 제거
            ComboBox1.DataSource = Table
            With ComboBox1
                .DisplayMember = "대분류"
                .ValueMember = "대분류"
            End With

            ComboBox1.SelectedIndex = -1    ' 분류 내용 지워주기    index를 '-1' 해주게 되면 콤보박스에 보여지는 값의 포커스를 없애줌.

            Call Button2_Click(sender, e)   ' 처음 Load 될 때 기본 값으로 조회 된 Data를 보여주기 위함.

        Catch ex As Exception
            MsgBox(ex.Message)
            Exit Sub
        End Try

        With TextBox1                                ' TextBox의 속성값들을 지정 해줌. 
            .Text = "ex) 검색어 입력 후 엔터하세요."   ' 
            .Font = New Font("맑은 고딕", 10)
            .ForeColor = Color.Gray
        End With

    End Sub
    ' ### Enter 쳤을 때 Event ##############
    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        If e.KeyChar = Convert.ToChar(13) Then  ' ToChar <-- 13번 값은 Enter 임.
            Call Button2_Click(sender, e)   ' 다른 프로시져 호출
        End If

        If e.KeyChar = Convert.ToChar(27) Then  ' ToChar <-- 27번 값은 ESC 임
            Hide()
        End If

    End Sub

    ' ### 검색 된 용어를 선택해서 볼 때 
    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Search_Result.SelectedIndexChanged
        'DB새로 연결
        vConn = New OleDbConnection(vcon)
        'Query 실행
        Dim DA As OleDbDataAdapter = New OleDbDataAdapter("Select * FROM [" & strSht & "] Where [용어] > '' Order by [용어] ", vConn)


        ' Dataset에 값 넣기
        DA.Fill(DS, strSht)
        ' Dataset 객체 생성 
        Dim Table_Word As DataTable = DS.Tables(0)

        Des_Txt.Clear()         ' 용어 선택 시 이미 조회 된 결과 자료들은 초기화 해줌.
        TextBox3.Clear()

        For i As Integer = 0 To Table_Word.Rows.Count - 1       ' 선택한 Item과 똑같은 Item 찾기

            ' 검색어와 일치하는 설명 붙여 넣깅
            If Search_Result.Text = Table_Word.Rows(i)(2).ToString() Then
                Dim strTxtDef = Table_Word.Rows(i)(3).ToString()
                Dim strTxtAro = Table_Word.Rows(i)(4).ToString()

                ' Access DB의 문제점으로 Alt+Enter가 없어진 것을 Replace하여 보여줌
                Des_Txt.Text = Replace(strTxtDef, Chr(10), Chr(13) & Chr(10))
                TextBox3.Text = Replace(strTxtAro, Chr(10), Chr(13) & Chr(10))

            End If
        Next

    End Sub

    '용어 검색 창 클릭 했을 때
    Private Sub TextBox1_Click(sender As Object, e As EventArgs) Handles TextBox1.Click
        If InStr(TextBox1.Text, "검색어") Then
            With TextBox1
                .Text = ""
                .Font = New Font("맑은 고딕", 9)
                .ForeColor = Color.Black
            End With
        End If
    End Sub

    ' ### 용어 요청 하는 부분 
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim Terms_Request As New Terms_Request
        With Terms_Request
            .strWord.Text = Search_Result.Text  ' 문의 할 내용을 문의창 컨트롤에 값 넘겨주기.
            .selectItem = Search_Result.Text
            .DesTxt.Text = Des_Txt.Text
            .Type_CB.Text = "수정"
            .ShowDialog()
        End With
        Call Button2_Click(sender, e)

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub
End Class