<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class pl_select
    Inherits System.Windows.Forms.Form

    'Form은 Dispose를 재정의하여 구성 요소 목록을 정리합니다.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.rdo_pln = New System.Windows.Forms.RadioButton()
        Me.rdo_app = New System.Windows.Forms.RadioButton()
        Me.btn_ok = New System.Windows.Forms.Button()
        Me.btn_cls = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'rdo_pln
        '
        Me.rdo_pln.AutoSize = True
        Me.rdo_pln.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.rdo_pln.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.rdo_pln.Location = New System.Drawing.Point(12, 32)
        Me.rdo_pln.Name = "rdo_pln"
        Me.rdo_pln.Size = New System.Drawing.Size(196, 19)
        Me.rdo_pln.TabIndex = 0
        Me.rdo_pln.TabStop = True
        Me.rdo_pln.Text = "Project 시험기획 or 기능변경점"
        Me.rdo_pln.UseVisualStyleBackColor = True
        '
        'rdo_app
        '
        Me.rdo_app.AutoSize = True
        Me.rdo_app.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.rdo_app.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.rdo_app.Location = New System.Drawing.Point(12, 66)
        Me.rdo_app.Name = "rdo_app"
        Me.rdo_app.Size = New System.Drawing.Size(116, 19)
        Me.rdo_app.TabIndex = 0
        Me.rdo_app.TabStop = True
        Me.rdo_app.Text = "App 변경점 등록"
        Me.rdo_app.UseVisualStyleBackColor = True
        '
        'btn_ok
        '
        Me.btn_ok.BackColor = System.Drawing.Color.IndianRed
        Me.btn_ok.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_ok.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.btn_ok.ForeColor = System.Drawing.Color.White
        Me.btn_ok.Location = New System.Drawing.Point(136, 112)
        Me.btn_ok.Name = "btn_ok"
        Me.btn_ok.Size = New System.Drawing.Size(62, 24)
        Me.btn_ok.TabIndex = 1
        Me.btn_ok.Text = "OK"
        Me.btn_ok.UseVisualStyleBackColor = False
        '
        'btn_cls
        '
        Me.btn_cls.BackColor = System.Drawing.Color.IndianRed
        Me.btn_cls.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_cls.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.btn_cls.ForeColor = System.Drawing.Color.White
        Me.btn_cls.Location = New System.Drawing.Point(204, 112)
        Me.btn_cls.Name = "btn_cls"
        Me.btn_cls.Size = New System.Drawing.Size(62, 24)
        Me.btn_cls.TabIndex = 1
        Me.btn_cls.Text = "Cancel"
        Me.btn_cls.UseVisualStyleBackColor = False
        '
        'pl_select
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(277, 157)
        Me.Controls.Add(Me.btn_cls)
        Me.Controls.Add(Me.btn_ok)
        Me.Controls.Add(Me.rdo_app)
        Me.Controls.Add(Me.rdo_pln)
        Me.Name = "pl_select"
        Me.Text = "pl_select"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents rdo_pln As Windows.Forms.RadioButton
    Friend WithEvents rdo_app As Windows.Forms.RadioButton
    Friend WithEvents btn_ok As Windows.Forms.Button
    Friend WithEvents btn_cls As Windows.Forms.Button
End Class
