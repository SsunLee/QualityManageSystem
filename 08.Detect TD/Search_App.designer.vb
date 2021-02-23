<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Search_App
    Inherits System.Windows.Forms.Form

    'Form은 Dispose를 재정의하여 구성 요소 목록을 정리합니다.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows Form 디자이너에 필요합니다.
    Private components As System.ComponentModel.IContainer

    '참고: 다음 프로시저는 Windows Form 디자이너에 필요합니다.
    '수정하려면 Windows Form 디자이너를 사용하십시오.  
    '코드 편집기에서는 수정하지 마세요.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.trvApp = New System.Windows.Forms.TreeView()
        Me.btSearch = New System.Windows.Forms.Button()
        Me.txtApp = New System.Windows.Forms.TextBox()
        Me.btSummit = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'trvApp
        '
        Me.trvApp.Font = New System.Drawing.Font("맑은 고딕", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.trvApp.Location = New System.Drawing.Point(12, 42)
        Me.trvApp.Name = "trvApp"
        Me.trvApp.Size = New System.Drawing.Size(260, 208)
        Me.trvApp.TabIndex = 1003
        '
        'btSearch
        '
        Me.btSearch.Location = New System.Drawing.Point(204, 11)
        Me.btSearch.Name = "btSearch"
        Me.btSearch.Size = New System.Drawing.Size(68, 22)
        Me.btSearch.TabIndex = 1002
        Me.btSearch.Text = "찾기"
        Me.btSearch.UseVisualStyleBackColor = True
        '
        'txtApp
        '
        Me.txtApp.Font = New System.Drawing.Font("맑은 고딕", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.txtApp.Location = New System.Drawing.Point(12, 13)
        Me.txtApp.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtApp.Name = "txtApp"
        Me.txtApp.Size = New System.Drawing.Size(143, 22)
        Me.txtApp.TabIndex = 1001
        '
        'btSummit
        '
        Me.btSummit.Location = New System.Drawing.Point(204, 256)
        Me.btSummit.Name = "btSummit"
        Me.btSummit.Size = New System.Drawing.Size(68, 22)
        Me.btSummit.TabIndex = 1004
        Me.btSummit.Text = "확인"
        Me.btSummit.UseVisualStyleBackColor = True
        '
        'Search_App
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 281)
        Me.Controls.Add(Me.btSummit)
        Me.Controls.Add(Me.btSearch)
        Me.Controls.Add(Me.txtApp)
        Me.Controls.Add(Me.trvApp)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximumSize = New System.Drawing.Size(300, 320)
        Me.MinimumSize = New System.Drawing.Size(300, 320)
        Me.Name = "Search_App"
        Me.Text = "SearchApp"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btSearch As Windows.Forms.Button
    Public WithEvents trvApp As Windows.Forms.TreeView
    Public WithEvents txtApp As Windows.Forms.TextBox
    Friend WithEvents btSummit As Windows.Forms.Button
End Class
