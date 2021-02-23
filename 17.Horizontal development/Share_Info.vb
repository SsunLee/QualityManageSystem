Imports System.Data
Imports System.Data.OleDb
Imports System.IO
Imports System.Windows.Forms
Imports Microsoft.Office.Interop

Public Class Share_Info
    Private DSS As DataSet = New DataSet
    Private DAA As OleDbDataAdapter = New OleDbDataAdapter()
    Public ordAdapter As OleDbDataAdapter = New OleDbDataAdapter()
    Private InfoConn As OleDbConnection
    Public strSht As String = Nothing
    Private szMerge As String = Nothing
    Public strFilePath As String = Nothing ' "\\10.174.51.33\Q-Portal\자산_Device_수평전개_Guide\재발방지체크리스트"

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' 재발방지체크리스트 열기
        Dim strFileName As String = Nothing
        Try
            ' szFile = "재발방지체크리스트"
            'strFileName = strFilePath & "\" & szFile

            If File.Exists(szMerge) Then
                'If InStr(strFile, ".xlsx") Then       ' 만약 엑셀 파일 이라면
                Dim Proceed As Boolean = False
                Dim xlApp As Excel.Application = Nothing
                Dim xlWorkBooks As Excel.Workbooks = Nothing
                Dim xlWorkBook As Excel.Workbook = Nothing
                Dim xlWorkSheet As Excel.Worksheet = Nothing
                Dim xlWorkSheets As Excel.Sheets = Nothing
                Dim xlCells As Excel.Range = Nothing
                xlApp = New Excel.Application
                xlApp.DisplayAlerts = False
                xlWorkBooks = xlApp.Workbooks
                xlWorkBook = xlWorkBooks.Open(szMerge,, True)   ' Read Only Open
                xlApp.Visible = True
                xlWorkSheets = xlWorkBook.Sheets

            Else
                MsgBox("열려는 파일이 없습니다." & vbCrLf & strFilePath & "에서 " & szMerge & "(이)가 있는지 확인 해보세요.")
                Exit Sub
            End If

        Catch ex As Exception
            MsgBox(ex.Message, "열려는 파일이 없습니다." & vbCrLf & szMerge & "에서 확인 해보세요.")
        End Try


    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)
        MsgBox("기능 개발 중입니다. 현재는 파일 열기만 가능합니다.",, "lee.sunbae@lgepartner.com")
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs)
        MsgBox("기능 개발 중입니다. 현재는 파일 열기만 가능합니다.",, "lee.sunbae@lgepartner.com")
    End Sub

    Private Sub Share_Info_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim szFileName As String = Nothing
        Dim blChk As Boolean = False
        Dim strFile As String = "재발방지체크리스트"

        Try
            Dim XML As New XML
            XML.Folder_Path("Share", strFilePath)
            XML = Nothing

            ' 지정 한 경로를 반복 하면서 경로와 '구분'명과 일치하는 폴더를 찾음.
            ' 찾은 경로로 진입 하여 그 안의 파일명을 찾는다.
            Dim dirA As DirectoryInfo = New DirectoryInfo(strFilePath)    ' 디렉토리 지정
            For Each dra In dirA.GetFiles()     ' For each를 통해 폴더 내의 파일을 찾음
                If InStr(Trim(dra.Name), RTrim(strFile)) Then  ' Consumer TC와 Kernel TC / Framework TC의 파일 Naming이 다름
                    szFileName = dra.Name
                    blChk = True
                End If
            Next

            If blChk Then
                szMerge = strFilePath & "\" & szFileName
            Else
                MsgBox(strFile & " 파일이 없는 것 같습니다. " & strFilePath & " <-- 경로에 파일이 있는지, '재발방지체크리스트' 파일명도 확인해주세요 ")
            End If

            Dim strExcel As String = "Provider=Microsoft.Ace.OLEDB.12.0;Data Source=" & szMerge & ";Extended Properties=""Excel 12.0;HDR=YES;"""
            InfoConn = New OleDbConnection(strExcel)
            strSht = "TC Info"

            '#### 쿼리 작성 #########################################################
            Dim vSQL As String = "SELECT * " & " "
            vSQL = vSQL + "FROM [" & strSht & "$]" & " "
            '#######################################################################

            DAA = New OleDbDataAdapter(vSQL, InfoConn)
            DAA.Fill(DSS, strSht)

            Dim Table As DataTable = DSS.Tables(0)
            strFile = Nothing

            Dim szTCName As String = Table.Rows(0)(1).ToString()
            Dim szPur As String = Table.Rows(1)(1).ToString()
            Dim szDetect As String = Table.Rows(2)(1).ToString()
            Dim szBase As String = Table.Rows(4)(1).ToString()
            Dim szSemi As String = Table.Rows(4)(2).ToString()
            Dim szCA As String = Table.Rows(4)(3).ToString()
            Dim szMD As String = Table.Rows(5)(1).ToString()

            ' Des_Txt.Text = Replace(strTxtDef, Chr(10), Chr(13) & Chr(10))

            TCnameTxt.Text = Replace(szTCName, Chr(10), Chr(13) & Chr(10))
            TCPurposeTxt.Text = Replace(szPur, Chr(10), Chr(13) & Chr(10))
            DetectedTxt.Text = Replace(szDetect, Chr(10), Chr(13) & Chr(10))

            txt_Base.Text = Replace(szBase, Chr(10), Chr(13) & Chr(10))
            Txt_Semi.Text = Replace(szSemi, Chr(10), Chr(13) & Chr(10))
            Txt_CA.Text = Replace(szCA, Chr(10), Chr(13) & Chr(10))

            MDTxt.Text = Replace(szMD, Chr(10), Chr(13) & Chr(10))

        Catch ex As Exception
            MessageBox.Show(ex.Message, "lee.sunbae@lgepartner.com")
        End Try

    End Sub

    Private Sub requestBtn_Click(sender As Object, e As EventArgs) Handles requestBtn.Click

    End Sub
End Class