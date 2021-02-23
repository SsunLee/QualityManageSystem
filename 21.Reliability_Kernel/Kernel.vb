Imports System.Data
Imports System.Data.OleDb
Imports System.Windows.Forms
Imports System.Drawing
Imports System.IO
Imports System.Xml

Public Class Kernel
    Private DS As DataSet = New DataSet
    Private DS2 As DataSet = New DataSet
    Private DA As OleDbDataAdapter = New OleDbDataAdapter()
    Public ordAdapter As OleDbDataAdapter = New OleDbDataAdapter()
    Private strSQL As String
    Private vConn As OleDbConnection
    Private InfoConn As OleDbConnection
    Private strFilePath As String = Nothing '"\\10.174.51.33\Q-Portal\Snowbird 총시 용어분석"
    Private szFileName As String = Nothing
    Private szMerge As String = Nothing
    Private Table_Word As DataTable
    Private szPri As String = Nothing
    Private blchk As Boolean = False
    Private szTemp As String = Nothing
    Dim strSht As String = "Kernel"
    Dim strFile As String = "재발방지_KernelFramework TC정리"

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        TextBox1.Text = ""
        Call Button2_Click(sender, e)
    End Sub

    ' ### 용어 검색 시 호출 되는 Event
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim strSearch As String = Nothing
        Dim strDae As String = Nothing     ' 대분류 
        Dim strMid As String = Nothing     ' 중분류


        Try

            If Table_Word.Rows.Count = 0 Then
                MsgBox("검색결과가 없습니다.")
                Exit Sub
            End If

            Search_Result.Items.Clear()
            '  ListBox1.Items.Clear()  '용어 초기화
            ListBox2.Items.Clear()      ' App 초기화
            ListBox3.Items.Clear()         ' feature 초기화
            ListBox4.Items.Clear()
            txtStep.Text = ""
            txtHistory.Text = ""
            txtKey.Text = ""
            Des_Txt.Text = ""
            txtMD.Text = ""
            txtTD.Text = ""
            txtDev.Text = ""

            '검색어가 없을 시 
            If TextBox1.Text = "" Then
                For i As Integer = 0 To Table_Word.Rows.Count - 1    ' Data table Row 만큼 반복 -1은 마지막행은 Null
                    Try
                        If Not Search_Result.Items.Contains(LTrim(Table_Word.Rows(i)(0).ToString())) Then  ' 중복 없이 Item 추가
                            'If Strings.Left(LTrim(Table_Word.Rows(i)(0).ToString()), InStr(LTrim(Table_Word.Rows(i)(0).ToString()), " ") Then

                            'End If
                            Search_Result.Items.Add(LTrim(Table_Word.Rows(i)(0).ToString()))
                        End If
                    Catch ex As Exception
                        MsgBox(ex.Message)
                    End Try
                Next
            Else ' 검색어가 있을 시 
                Dim checknum As Integer
                checknum = 0
                For i As Integer = 0 To Table_Word.Rows.Count - 1    ' Data table Row 만큼 반복 -1은 마지막행은 Null
                    Try
                        If Not Search_Result.Items.Contains(LTrim(Table_Word.Rows(i)(0).ToString())) And InStr(UCase(LTrim(Table_Word.Rows(i)(3))), UCase(TextBox1.Text)) Then  ' 중복 없이 Item 추가
                            Search_Result.Items.Add(LTrim(Table_Word.Rows(i)(0).ToString()))

                        End If
                        If Not ListBox2.Items.Contains(LTrim(Table_Word.Rows(i)(3).ToString())) And InStr(UCase(LTrim(Table_Word.Rows(i)(3))), UCase(TextBox1.Text)) Then  ' 중복 없이 Item 추가
                            ListBox2.Items.Add(LTrim(Table_Word.Rows(i)(3).ToString()))
                            checknum = checknum + 1
                        End If
                    Catch ex As Exception
                        MsgBox(ex.Message)
                    End Try
                Next
                If checknum = 0 Then
                    MsgBox("검색 결과가 없습니다.")
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    ' ### Main Form 호출 됐을 때 처음 DataTable에 담음
    Private Sub Dictionary_Sub_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        Call listup(sender, e)
        Call Button2_Click(sender, e)


    End Sub
    Sub listup(sender As Object, e As EventArgs)

        Dim strSQLWord As String = Nothing
        blchk = True
        Try
            Dim XML As New XML
            Dim vCon As String = Nothing
            'XML.Folder_Path("Kernel", strFilePath)
            '' vcon가져오는 함수
            'XML.vCon_Kernel_Call(vCon)
            '' Connect 연결
            'InfoConn = New OleDbConnection(vCon)
            'XML = Nothing

            'strFilePath
            XML.Folder_Path("Kernel", strFilePath)
            XML = Nothing


            Dim dirA As DirectoryInfo = New DirectoryInfo(strFilePath)    ' 디렉토리 지정
            For Each dra In dirA.GetFiles()     ' For each를 통해 폴더 내의 파일을 찾음
                szTemp = dra.Name
                If InStr(Trim(dra.Name), RTrim(strFile)) And Strings.Left(szTemp, 2) <> "~$" Then  ' Consumer TC와 Kernel TC / Framework TC의 파일 Naming이 다름
                    szFileName = dra.Name
                    blchk = True
                    Exit For
                End If
            Next

            If blchk Then
                szMerge = strFilePath & "\" & szFileName
            Else
                MsgBox(strFile & " 파일이 없는 것 같습니다. " & strFilePath & " <-- 경로에 파일이 있는지, '재발방지체크리스트' 파일명도 확인해주세요 ")
            End If

            Dim strExcel As String = "Provider=Microsoft.Ace.OLEDB.12.0;Data Source=" & szMerge & ";Extended Properties=""Excel 12.0;HDR=YES;"""
            InfoConn = New OleDbConnection(strExcel)

            Dim strSht As String = "Sheet1 (2)"

            Dim vSQL As String = "SELECT [구분],[설명],[TC 명],[DEV_Function],[DEV_설명],[App],[App_feature],[검증방법],[Histrory],[Keyword],[투입 MD],[TD]" & " "
            vSQL = vSQL + "FROM [" & strSht & "$B3:N5000]" & " "  'DB범위 지정해줌
            '   vSQL = vSQL + "Where " '& vSQLtyp & vSQLTerm '& strSQLWord
            vSQL = vSQL + "Where [구분] > '' " '& strSQLWord
            vSQL = vSQL + "Order by [구분] asc , [TC 명] asc , [DEV_Function] asc , [App] asc, [App_feature] asc"

            'vConn = New OleDbConnection(Main_Form.strCon)   ' MainForm의 Connection String으로 DB Connect

            DA = New OleDbDataAdapter(vSQL, InfoConn)
            DA.Fill(DS, strSht)

            Table_Word = DS.Tables(0)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


    End Sub


    Private Sub Dictionary_Sub_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        'vConn.Close()
    End Sub

    ' ### Enter 쳤을 때 Event ##############
    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        If e.KeyChar = Convert.ToChar(13) Then
            Call Button2_Click(sender, e)   ' 다른 프로시져 호출
        End If

        If e.KeyChar = Convert.ToChar(27) Then
            Hide()
        End If

    End Sub

    ' ### 검색 된 용어를 선택해서 볼 때 
    Private Sub Serach_Result_Click(sender As Object, e As EventArgs) Handles Search_Result.SelectedIndexChanged

        If TextBox1.Text <> "" Then
            Exit Sub
        End If

        Try
            ' ListBox1.Items.Clear()  '용어 초기화
            ListBox2.Items.Clear()      ' App 초기화
            ListBox3.Items.Clear()         ' feature 초기화
            'txtDefault.Text = ""  
            ListBox4.Items.Clear()
            txtStep.Text = ""
            txtHistory.Text = ""
            txtKey.Text = ""
            txtMD.Text = ""
            txtTD.Text = ""
            Des_Txt.Text = ""
            txtDev.Text = ""

            For i As Integer = 0 To Table_Word.Rows.Count - 1    ' Data table Row 만큼 반복 -1은 마지막행은 Null

                If Search_Result.Text = LTrim(Table_Word.Rows(i)(0).ToString()) Then ' 선택 된 App과 Row, 필트(0)은 App, (1) 은 Feature
                    Try
                        If Not ListBox2.Items.Contains(LTrim(Table_Word.Rows(i)(3).ToString())) Then  ' 중복 없이 Item 추가
                            'nCnt = nCnt + 1
                            If LTrim(Table_Word.Rows(i)(3).ToString()) = "-" Then

                            Else
                                ListBox2.Items.Add(LTrim(Table_Word.Rows(i)(3).ToString()))
                            End If
                        End If

                    Catch ex As Exception
                        MsgBox(ex.Message)
                    End Try
                End If
            Next

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        ' 설명 추가하는 부분
        For i As Integer = 0 To Table_Word.Rows.Count - 1       ' 선택한 Item과 똑같은 Item 찾기

            If Search_Result.Text = LTrim(Table_Word.Rows(i)(0).ToString()) Then
                Dim strTxtDes = LTrim(Table_Word.Rows(i)(1).ToString())
                ' Access DB의 문제점으로 Alt+Enter가 없어진 것을 Replace하여 보여줌
                Des_Txt.Text = Replace(strTxtDes, Chr(10), Chr(13) & Chr(10))
                Exit For
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
    Private Sub Button3_Click(sender As Object, e As EventArgs)
        Dim Terms_Request As New Terms_Request
        With Terms_Request
            .strWord.Text = Search_Result.Text  ' 문의 할 내용을 문의창 컨트롤에 값 넘겨주기.
            .DesTxt.Text = Des_Txt.Text
            .Type_CB.Text = "수정"
            .Show()
        End With

    End Sub

    'Private Sub ListBox1_Click(sender As Object, e As EventArgs)

    '    'Test Type Combobox 입력 부분
    '    ' ListBox1.Items.Clear()      ' App 초기화
    '    ListBox2.Items.Clear()      ' App 초기화
    '    ListBox3.Items.Clear()         ' feature 초기화
    '    ListBox4.Items.Clear()         ' feature 초기화
    '    txtStep.Text = ""
    '    txtHistory.Text = ""
    '    txtKey.Text = ""
    '    txtMD.Text = ""
    '    txtTD.Text = ""
    '    txtDev.Text = ""


    '    ' 검색어와 일치하는 설명 붙여 넣깅
    '    If TextBox1.Text <> "" Then
    '        Try
    '            For i As Integer = 0 To Table_Word.Rows.Count - 1    ' Data table Row 만큼 반복 -1은 마지막행은 Null
    '                If ListBox1.Text = LTrim(Table_Word.Rows(i)(2) Then
    '                    ' 구분을 선택 해줌
    '                    Search_Result.SelectedItem = LTrim(Table_Word.Rows(i)(0).ToString())
    '                    '구분의 설명을 보여줌
    '                    Dim strTxtDes = LTrim(Table_Word.Rows(i)(1).ToString())
    '                    ' Access DB의 문제점으로 Alt+Enter가 없어진 것을 Replace하여 보여줌
    '                    Des_Txt.Text = Replace(strTxtDes, Chr(10), Chr(13) & Chr(10))
    '                    Exit For
    '                End If
    '            Next i
    '        Catch ex As Exception
    '            MsgBox(ex.Message)
    '        End Try
    '    End If
    '    Try
    '        For i As Integer = 0 To Table_Word.Rows.Count - 1    ' Data table Row 만큼 반복 -1은 마지막행은 Null

    '            If Search_Result.Text = LTrim(Table_Word.Rows(i)(0).ToString()) And ListBox1.Text = LTrim(Table_Word.Rows(i)(2).ToString()) Then ' 선택 된 App과 Row, 필트(0)은 App, (1) 은 Feature
    '                Try
    '                    ' DEV_Function 추가하는 부분
    '                    If Not ListBox2.Items.Contains(LTrim(Table_Word.Rows(i)(3).ToString())) Then  ' 중복 없이 Item 추가
    '                        If LTrim(Table_Word.Rows(i)(3).ToString()) = "-" Then
    '                            ListBox2.Items.Add("DEV_Function 없음")
    '                        Else
    '                            ListBox2.Items.Add(LTrim(Table_Word.Rows(i)(3).ToString()))
    '                        End If
    '                    End If
    '                Catch ex As Exception
    '                    MsgBox(ex.Message)
    '                End Try
    '            End If
    '            If Search_Result.Text = LTrim(Table_Word.Rows(i)(0).ToString()) And ListBox1.Text = LTrim(Table_Word.Rows(i)(2).ToString()) And
    '                 (LTrim(Table_Word.Rows(i)(3).ToString()) = "" Or LTrim(Table_Word.Rows(i)(3).ToString()) = "-") Then
    '                'ListBox2.Items.Add("DEV_Function 없음")
    '                ListBox3.Items.Add("App 없음")
    '                ListBox4.Items.Add("Feature 없음")
    '                If LTrim(Table_Word.Rows(i)(3).ToString()) = "-" Then
    '                    Dim strDev = LTrim(Table_Word.Rows(i)(4).ToString())
    '                    Dim strStep = LTrim(Table_Word.Rows(i)(7).ToString())
    '                    Dim strTxtHistory = LTrim(Table_Word.Rows(i)(8).ToString())
    '                    Dim strTxtKey = LTrim(Table_Word.Rows(i)(9).ToString())
    '                    Dim strMD = LTrim(Table_Word.Rows(i)(10).ToString())
    '                    Dim strTD = LTrim(Table_Word.Rows(i)(11).ToString())
    '                    txtStep.Text = Replace(strStep, Chr(10), Chr(13) & Chr(10))
    '                    txtHistory.Text = Replace(strTxtHistory, Chr(10), Chr(13) & Chr(10))
    '                    txtKey.Text = Replace(strTxtKey, Chr(10), Chr(13) & Chr(10))
    '                    txtMD.Text = Replace(strMD, Chr(10), Chr(13) & Chr(10))
    '                    txtTD.Text = Replace(strTD, Chr(10), Chr(13) & Chr(10))
    '                    txtDev.Text = Replace(strDev, Chr(10), Chr(13) & Chr(10))
    '                End If
    '                Exit For

    '            End If
    '        Next

    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    End Try





    'End Sub

    Private Sub ListBox4_Click(sender As Object, e As EventArgs) Handles ListBox4.SelectedIndexChanged
        If ListBox4.Text = "Feature 없음" Then
            Exit Sub
        End If

        ' ListBox4.Items.Clear()

        txtStep.Text = ""
        txtHistory.Text = ""
        txtKey.Text = ""
        txtMD.Text = ""
        txtTD.Text = ""


        ' 설명 추가하는 부분
        For i As Integer = 0 To Table_Word.Rows.Count - 1       ' 선택한 Item과 똑같은 Item 찾기
            ' 검색어와 일치하는 설명 붙여 넣깅
            If Search_Result.Text = LTrim(Table_Word.Rows(i)(0).ToString()) And
                ListBox2.Text = LTrim(Table_Word.Rows(i)(3).ToString()) And ListBox3.Text = LTrim(Table_Word.Rows(i)(5).ToString()) And ListBox4.Text = LTrim(Table_Word.Rows(i)(6).ToString()) Then

                Dim strStep = LTrim(Table_Word.Rows(i)(7).ToString())
                Dim strTxtHistory = LTrim(Table_Word.Rows(i)(8).ToString())
                Dim strTxtKey = LTrim(Table_Word.Rows(i)(9).ToString())
                Dim strMD = LTrim(Table_Word.Rows(i)(10).ToString())
                Dim strTD = LTrim(Table_Word.Rows(i)(11).ToString())
                ' Access DB의 문제점으로 Alt+Enter가 없어진 것을 Replace하여 보여줌
                If strStep = "" Then strStep = "-"
                If strTxtHistory = "" Then strTxtHistory = "-"
                If strTxtKey = "" Then strTxtKey = "-"
                If strMD = "" Then strMD = "-"
                If strTD = "" Then strTD = "-"
                txtStep.Text = Replace(strStep, Chr(10), Chr(13) & Chr(10))
                txtHistory.Text = Replace(strTxtHistory, Chr(10), Chr(13) & Chr(10))
                txtKey.Text = Replace(strTxtKey, Chr(10), Chr(13) & Chr(10))
                txtMD.Text = Replace(strMD, Chr(10), Chr(13) & Chr(10))
                txtTD.Text = Replace(strTD, Chr(10), Chr(13) & Chr(10))
                Exit For
            End If

        Next


    End Sub

    Private Sub ListBox2_Click(sender As Object, e As EventArgs) Handles ListBox2.SelectedIndexChanged
        If ListBox2.Text = "DEV_Function 없음" Then
            Exit Sub
        End If
        '  ListBox2.Items.Clear()         ' feature 초기화
        ListBox3.Items.Clear()         ' feature 초기화
        ListBox4.Items.Clear()         ' feature 초기화
        txtStep.Text = ""
        txtHistory.Text = ""
        txtKey.Text = ""
        txtMD.Text = ""
        txtTD.Text = ""
        txtDev.Text = ""

        '설명 추가 후 App List 보여주는 부분

        'txtDefault.Text = ""
        ' 검색어와 일치하는 설명 붙여 넣깅
        If TextBox1.Text <> "" Then
            Try
                For i As Integer = 0 To Table_Word.Rows.Count - 1    ' Data table Row 만큼 반복 -1은 마지막행은 Null
                    If ListBox2.Text = LTrim(Table_Word.Rows(i)(3).ToString()) Then
                        ' 구분을 선택 해줌
                        Search_Result.SelectedItem = LTrim(Table_Word.Rows(i)(0).ToString())
                        '구분의 설명을 보여줌
                        Dim strTxtDes = LTrim(Table_Word.Rows(i)(1).ToString())
                        ' Access DB의 문제점으로 Alt+Enter가 없어진 것을 Replace하여 보여줌
                        Des_Txt.Text = Replace(strTxtDes, Chr(10), Chr(13) & Chr(10))
                        Exit For
                    End If
                Next i
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If

        Try

            For i As Integer = 0 To Table_Word.Rows.Count - 1    ' Data table Row 만큼 반복 -1은 마지막행은 Null

                If Search_Result.Text = LTrim(Table_Word.Rows(i)(0).ToString()) And ListBox2.Text = LTrim(Table_Word.Rows(i)(3).ToString()) Then ' 선택 된 App과 Row, 필트(0)은 App, (1) 은 Feature
                    Try
                        'app추가
                        If Not ListBox3.Items.Contains(LTrim(Table_Word.Rows(i)(5).ToString())) And LTrim(Table_Word.Rows(i)(5).ToString()) <> "" And LTrim(Table_Word.Rows(i)(5).ToString()) <> "-" Then  ' 중복 없이 Item 추가
                            ListBox3.Items.Add(LTrim(Table_Word.Rows(i)(5).ToString()))
                        End If
                    Catch ex As Exception
                        MsgBox(ex.Message)
                    End Try
                End If
                ' dev다음에 App이 비어있느지 아닌지 확인

                If Search_Result.Text = LTrim(Table_Word.Rows(i)(0).ToString()) And ListBox2.Text = LTrim(Table_Word.Rows(i)(3).ToString()) And
                    (LTrim(Table_Word.Rows(i)(5).ToString()) = "" Or LTrim(Table_Word.Rows(i)(5).ToString()) = "-") Then
                    ListBox3.Items.Add("App 없음")
                    ListBox4.Items.Add("Feature 없음")
                    If LTrim(Table_Word.Rows(i)(7).ToString()) <> "" Then
                        Dim strStep = LTrim(Table_Word.Rows(i)(7).ToString())
                        Dim strTxtHistory = LTrim(Table_Word.Rows(i)(8).ToString())
                        Dim strTxtKey = LTrim(Table_Word.Rows(i)(9).ToString())
                        Dim strMD = LTrim(Table_Word.Rows(i)(10).ToString())
                        Dim strTD = LTrim(Table_Word.Rows(i)(11).ToString())
                        If strStep = "" Then strStep = "-"
                        If strTxtHistory = "" Then strTxtHistory = "-"
                        If strTxtKey = "" Then strTxtKey = "-"
                        If strMD = "" Then strMD = "-"
                        If strTD = "" Then strTD = "-"
                        txtStep.Text = Replace(strStep, Chr(10), Chr(13) & Chr(10))
                        txtHistory.Text = Replace(strTxtHistory, Chr(10), Chr(13) & Chr(10))
                        txtKey.Text = Replace(strTxtKey, Chr(10), Chr(13) & Chr(10))
                        txtMD.Text = Replace(strMD, Chr(10), Chr(13) & Chr(10))
                        txtTD.Text = Replace(strTD, Chr(10), Chr(13) & Chr(10))
                    End If
                    Exit For

                End If
            Next

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


        ' 설명 추가하는 부분
        For i As Integer = 0 To Table_Word.Rows.Count - 1       ' 선택한 Item과 똑같은 Item 찾기

            If Search_Result.Text = LTrim(Table_Word.Rows(i)(0).ToString()) And ListBox2.Text = LTrim(Table_Word.Rows(i)(3).ToString()) Then

                Dim strDev = LTrim(Table_Word.Rows(i)(4).ToString())

                ' Access DB의 문제점으로 Alt+Enter가 없어진 것을 Replace하여 보여줌

                txtDev.Text = Replace(strDev, Chr(10), Chr(13) & Chr(10))


                Exit For
            End If
        Next


    End Sub

    Private Sub ListBox3_Click(sender As Object, e As EventArgs) Handles ListBox3.SelectedIndexChanged

        If ListBox3.Text = "App 없음" Then
            Exit Sub
        End If

        '설명 추가 후 App List 보여주는 부분
        txtStep.Text = ""
        txtHistory.Text = ""
        txtKey.Text = ""
        txtMD.Text = ""
        txtTD.Text = ""
        '  ListBox3.Items.Clear()
        ListBox4.Items.Clear()

        Try
            For i As Integer = 0 To Table_Word.Rows.Count - 1    ' Data table Row 만큼 반복 -1은 마지막행은 Null

                If Search_Result.Text = LTrim(Table_Word.Rows(i)(0).ToString()) And ListBox2.Text = LTrim(Table_Word.Rows(i)(3).ToString()) And
                    ListBox3.Text = LTrim(Table_Word.Rows(i)(5).ToString()) Then
                    Try
                        If Not ListBox4.Items.Contains(LTrim(Table_Word.Rows(i)(6).ToString())) And LTrim(Table_Word.Rows(i)(6).ToString()) <> "" And LTrim(Table_Word.Rows(i)(6).ToString()) <> "-" Then  ' 중복 없이 Item 추가
                            'nCnt = nCnt + 1
                            ListBox4.Items.Add(LTrim(Table_Word.Rows(i)(6).ToString()))
                        End If

                    Catch ex As Exception
                        MsgBox(ex.Message)
                    End Try
                End If
                If Search_Result.Text = LTrim(Table_Word.Rows(i)(0).ToString()) And
                ListBox2.Text = LTrim(Table_Word.Rows(i)(3).ToString()) And ListBox3.Text = LTrim(Table_Word.Rows(i)(5).ToString()) And LTrim(Table_Word.Rows(i)(6).ToString()) = "" Then
                    ListBox4.Items.Add("Feature 없음")
                    Exit For
                End If
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


        ' 설명 추가하는 부분
        For i As Integer = 0 To Table_Word.Rows.Count - 1       ' 선택한 Item과 똑같은 Item 찾기
            ' 검색어와 일치하는 설명 붙여 넣깅
            If Search_Result.Text = LTrim(Table_Word.Rows(i)(0).ToString()) And
                ListBox2.Text = LTrim(Table_Word.Rows(i)(3).ToString()) And ListBox3.Text = LTrim(Table_Word.Rows(i)(5).ToString()) And LTrim(Table_Word.Rows(i)(6).ToString()) = "" Then

                Dim strStep = LTrim(Table_Word.Rows(i)(7).ToString())
                Dim strTxtHistory = LTrim(Table_Word.Rows(i)(8).ToString())
                Dim strTxtKey = LTrim(Table_Word.Rows(i)(9).ToString())
                Dim strMD = LTrim(Table_Word.Rows(i)(10).ToString())
                Dim strTD = LTrim(Table_Word.Rows(i)(11).ToString())
                ' Access DB의 문제점으로 Alt+Enter가 없어진 것을 Replace하여 보여줌
                If strStep = "" Then strStep = "-"
                If strTxtHistory = "" Then strTxtHistory = "-"
                If strTxtKey = "" Then strTxtKey = "-"
                If strMD = "" Then strMD = "-"
                If strTD = "" Then strTD = "-"

                txtStep.Text = Replace(strStep, Chr(10), Chr(13) & Chr(10))
                txtHistory.Text = Replace(strTxtHistory, Chr(10), Chr(13) & Chr(10))
                txtKey.Text = Replace(strTxtKey, Chr(10), Chr(13) & Chr(10))
                txtMD.Text = Replace(strMD, Chr(10), Chr(13) & Chr(10))
                txtTD.Text = Replace(strTD, Chr(10), Chr(13) & Chr(10))
                Exit For
            End If

        Next

    End Sub

    '★ 엑셀 여는 부분
    Private Sub btn_VPSearch_Click(sender As Object, e As EventArgs) Handles btn_VPSearch.Click
        '재발방지_KernelFramework TC정리


        ' Dim szFullPath As String = "\\10.174.51.33\Q-Portal\Kernel_Framework"

        Dim dirA As DirectoryInfo = New DirectoryInfo(strFilePath)    ' 디렉토리 지정
        For Each dra In dirA.GetFiles()     ' For each를 통해 폴더 내의 파일을 찾음
            szTemp = dra.Name
            If InStr(Trim(dra.Name), RTrim(strFile)) And Strings.Left(szTemp, 2) <> "~$" Then  ' Consumer TC와 Kernel TC / Framework TC의 파일 Naming이 다름
                szFileName = dra.Name
                blchk = True
                Exit For
            End If
        Next

        If blchk Then
            szMerge = strFilePath & "\" & szFileName
            Diagnostics.Process.Start(szMerge)

        Else
            MsgBox(strFile & " 파일이 없는 것 같습니다. " & strFilePath & " <-- 경로에 파일이 있는지, '재발방지체크리스트' 파일명도 확인해주세요 ")
        End If
    End Sub

    Private Sub requestBtn_Click(sender As Object, e As EventArgs) Handles requestBtn.Click


    End Sub
End Class