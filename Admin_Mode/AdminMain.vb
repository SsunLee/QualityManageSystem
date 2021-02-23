Imports System.Data.OleDb
Imports System.Windows.Forms

Public Class AdminMain
    Public vConn As OleDbConnection
    'Public strCon As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=\\10.174.51.56\업무 공유\통합DB\accDB\QPortalDB.accdb; Persist Security Info=False;"
    ' "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=\\10.174.51.56\업무 공유\통합DB\accDB\QPortalDB.accdb; Persist Security Info=False;"
    ' "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Administrator\Desktop\0.TASK\통합DB\QPortalDB.accdb; Persist Security Info=False;"

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' Consumer 폼 열기
        Dim ConsumerForm = New Consumer_Admin
        ConsumerForm.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ' App Feature 관리자 폼 열기
        'Dim AFForm = New AppFeature_Admin
        'AFForm.Show()

        Dim App_Feature As New App_Feature
        App_Feature.Show()


    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        ' 용어 관리자 폼 열기
        Dim Term_Admin_GM = New Term_Admin_GM
        Term_Admin_GM.Show()
    End Sub
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        ' 기본 검증 폼 열기
        Dim TipForm = New Tip_Admin_GM
        TipForm.Show()
    End Sub
    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        '  ?????
        Dim AppFeatureForm = New AppFeature_Edit
        AppFeatureForm.Show()
    End Sub
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        ' Test Type 및 Symptom 수정
        Dim TypeSymptomForm = New TypeSymptom_Edit
        TypeSymptomForm.Show()
    End Sub
    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        ' 용어 추가 삭제 관리 폼 열기
        Dim Term_Edit_GM = New Term_Edit_GM
        Term_Edit_GM.Show()
    End Sub
    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click, Button11.Click

        Dim TipForm = New Tip_Edit_GM
        TipForm.Show()
    End Sub
    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Dim ContactForm = New Contacts_Edit
        ContactForm.Show()
    End Sub

    Private Sub AdminMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btn_TC_Click(sender As Object, e As EventArgs) Handles btn_TC.Click
        Dim OtherTC_Edit As New OtherTC_Edit
        OtherTC_Edit.Show()

    End Sub


    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        Dim PathForm As New PathForm
        PathForm.Show()
    End Sub

    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        Dim Admin_Add As New Admin_Add
        Admin_Add.Show()

    End Sub

    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles Button14.Click
        Dim SunAppName As New SunAppName
        SunAppName.Show()

    End Sub

    Private Sub Button15_Click(sender As Object, e As EventArgs) Handles Button15.Click
        Dim Survey_Result As New Survey_Select
        Survey_Result.Show()

    End Sub
End Class