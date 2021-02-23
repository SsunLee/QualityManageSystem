Public Class pl_select

    Public chk_result As Boolean

    Private Sub btn_ok_Click(sender As Object, e As EventArgs) Handles btn_ok.Click

        Dim chk_bool As Boolean
        If rdo_app.Checked = True Then
            chk_bool = True
        Else
            chk_bool = False
        End If
        chk_result = chk_bool

        Close()

    End Sub

    Public Function getResult() As Boolean
        Return chk_result
    End Function

    Private Sub pl_select_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        rdo_pln.Checked = False
        rdo_app.Checked = False
    End Sub
End Class