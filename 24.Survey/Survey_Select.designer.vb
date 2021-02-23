<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Survey_Select
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
        Me.btOK = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.cbTitle = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cbComp = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cbFm = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cbAge = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'btOK
        '
        Me.btOK.BackColor = System.Drawing.Color.SteelBlue
        Me.btOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btOK.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.btOK.ForeColor = System.Drawing.Color.White
        Me.btOK.Location = New System.Drawing.Point(261, 195)
        Me.btOK.Name = "btOK"
        Me.btOK.Size = New System.Drawing.Size(75, 23)
        Me.btOK.TabIndex = 1204
        Me.btOK.Text = "결과보기"
        Me.btOK.UseVisualStyleBackColor = False
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.SteelBlue
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Button2.ForeColor = System.Drawing.Color.White
        Me.Button2.Location = New System.Drawing.Point(342, 195)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 1205
        Me.Button2.Text = "취소"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'cbTitle
        '
        Me.cbTitle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbTitle.FormattingEnabled = True
        Me.cbTitle.Location = New System.Drawing.Point(111, 22)
        Me.cbTitle.Name = "cbTitle"
        Me.cbTitle.Size = New System.Drawing.Size(279, 20)
        Me.cbTitle.TabIndex = 1206
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label1.Location = New System.Drawing.Point(23, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(82, 12)
        Me.Label1.TabIndex = 1207
        Me.Label1.Text = "제목(Title) :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(45, 73)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(49, 12)
        Me.Label2.TabIndex = 1209
        Me.Label2.Text = "업체명 :"
        '
        'cbComp
        '
        Me.cbComp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbComp.FormattingEnabled = True
        Me.cbComp.Location = New System.Drawing.Point(111, 70)
        Me.cbComp.Name = "cbComp"
        Me.cbComp.Size = New System.Drawing.Size(116, 20)
        Me.cbComp.TabIndex = 1208
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(57, 114)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(37, 12)
        Me.Label3.TabIndex = 1211
        Me.Label3.Text = "성별 :"
        '
        'cbFm
        '
        Me.cbFm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbFm.FormattingEnabled = True
        Me.cbFm.Location = New System.Drawing.Point(111, 111)
        Me.cbFm.Name = "cbFm"
        Me.cbFm.Size = New System.Drawing.Size(116, 20)
        Me.cbFm.TabIndex = 1210
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(45, 157)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(49, 12)
        Me.Label4.TabIndex = 1213
        Me.Label4.Text = "연령대 :"
        '
        'cbAge
        '
        Me.cbAge.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbAge.FormattingEnabled = True
        Me.cbAge.Location = New System.Drawing.Point(111, 154)
        Me.cbAge.Name = "cbAge"
        Me.cbAge.Size = New System.Drawing.Size(116, 20)
        Me.cbAge.TabIndex = 1212
        '
        'Survey_Select
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(429, 230)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cbAge)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cbFm)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cbComp)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cbTitle)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.btOK)
        Me.Name = "Survey_Select"
        Me.Text = "설문조사 선택"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btOK As Windows.Forms.Button
    Friend WithEvents Button2 As Windows.Forms.Button
    Friend WithEvents cbTitle As Windows.Forms.ComboBox
    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents Label2 As Windows.Forms.Label
    Friend WithEvents cbComp As Windows.Forms.ComboBox
    Friend WithEvents Label3 As Windows.Forms.Label
    Friend WithEvents cbFm As Windows.Forms.ComboBox
    Friend WithEvents Label4 As Windows.Forms.Label
    Friend WithEvents cbAge As Windows.Forms.ComboBox
End Class
