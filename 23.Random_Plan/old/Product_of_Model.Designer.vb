<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Product_of_Model
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Product_of_Model))
        Me.requestBtn = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.lnkPlan = New System.Windows.Forms.LinkLabel()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.lnkExpert = New System.Windows.Forms.LinkLabel()
        Me.lnkModel = New System.Windows.Forms.LinkLabel()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.lnk_AppMapp = New System.Windows.Forms.LinkLabel()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'requestBtn
        '
        Me.requestBtn.BackColor = System.Drawing.Color.Transparent
        Me.requestBtn.BackgroundImage = CType(resources.GetObject("requestBtn.BackgroundImage"), System.Drawing.Image)
        Me.requestBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.requestBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.requestBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.requestBtn.Font = New System.Drawing.Font("맑은 고딕", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.requestBtn.ForeColor = System.Drawing.Color.Black
        Me.requestBtn.Location = New System.Drawing.Point(849, 11)
        Me.requestBtn.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.requestBtn.Name = "requestBtn"
        Me.requestBtn.Size = New System.Drawing.Size(79, 78)
        Me.requestBtn.TabIndex = 233
        Me.requestBtn.Text = "제안하기"
        Me.requestBtn.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.requestBtn.UseVisualStyleBackColor = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImage = CType(resources.GetObject("PictureBox1.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.InitialImage = CType(resources.GetObject("PictureBox1.InitialImage"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(14, 11)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(229, 31)
        Me.PictureBox1.TabIndex = 231
        Me.PictureBox1.TabStop = False
        '
        'lnkPlan
        '
        Me.lnkPlan.AutoSize = True
        Me.lnkPlan.Location = New System.Drawing.Point(658, 226)
        Me.lnkPlan.Name = "lnkPlan"
        Me.lnkPlan.Size = New System.Drawing.Size(101, 15)
        Me.lnkPlan.TabIndex = 261
        Me.lnkPlan.TabStop = True
        Me.lnkPlan.Text = "2) 시험기획서"
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Font = New System.Drawing.Font("맑은 고딕", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label31.ForeColor = System.Drawing.Color.Gray
        Me.Label31.Location = New System.Drawing.Point(656, 126)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(81, 28)
        Me.Label31.TabIndex = 253
        Me.Label31.Text = "Output"
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Font = New System.Drawing.Font("맑은 고딕", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label30.ForeColor = System.Drawing.Color.Gray
        Me.Label30.Location = New System.Drawing.Point(538, 126)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(52, 28)
        Me.Label30.TabIndex = 254
        Me.Label30.Text = "담당"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("맑은 고딕", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Gray
        Me.Label1.Location = New System.Drawing.Point(307, 126)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(84, 28)
        Me.Label1.TabIndex = 255
        Me.Label1.Text = "Activity"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Gray
        Me.Label13.Location = New System.Drawing.Point(274, 226)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(271, 20)
        Me.Label13.TabIndex = 257
        Me.Label13.Text = "(Excel) Risk Factor ML 작성 후 DB-UP"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label23.ForeColor = System.Drawing.Color.Gray
        Me.Label23.Location = New System.Drawing.Point(541, 272)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(74, 20)
        Me.Label23.TabIndex = 258
        Me.Label23.Text = "전담 인원"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label22.ForeColor = System.Drawing.Color.Gray
        Me.Label22.Location = New System.Drawing.Point(539, 226)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(74, 20)
        Me.Label22.TabIndex = 259
        Me.Label22.Text = "모델 리더"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.Gray
        Me.Label21.Location = New System.Drawing.Point(539, 180)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(74, 20)
        Me.Label21.TabIndex = 260
        Me.Label21.Text = "모델 리더"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.Gray
        Me.Label16.Location = New System.Drawing.Point(275, 272)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(179, 20)
        Me.Label16.TabIndex = 256
        Me.Label16.Text = "(Q-Portal) 검증방법 작성"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.Gray
        Me.Label15.Location = New System.Drawing.Point(27, 272)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(213, 20)
        Me.Label15.TabIndex = 252
        Me.Label15.Text = "3)  Expert 인원 검증방법 작성"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Gray
        Me.Label10.Location = New System.Drawing.Point(26, 226)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(146, 20)
        Me.Label10.TabIndex = 249
        Me.Label10.Text = "2)  Risk Factor 작성"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Gray
        Me.Label9.Location = New System.Drawing.Point(26, 180)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(144, 20)
        Me.Label9.TabIndex = 251
        Me.Label9.Text = "1)  기능변경점_맵핑"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Gray
        Me.Label12.Location = New System.Drawing.Point(274, 180)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(235, 20)
        Me.Label12.TabIndex = 250
        Me.Label12.Text = "(Q-Portal) App/기능 변경점 맵핑"
        '
        'lnkExpert
        '
        Me.lnkExpert.AutoSize = True
        Me.lnkExpert.Location = New System.Drawing.Point(658, 272)
        Me.lnkExpert.Name = "lnkExpert"
        Me.lnkExpert.Size = New System.Drawing.Size(213, 15)
        Me.lnkExpert.TabIndex = 248
        Me.lnkExpert.TabStop = True
        Me.lnkExpert.Text = "3) 검증방법_작성(Expert 인원)"
        '
        'lnkModel
        '
        Me.lnkModel.AutoSize = True
        Me.lnkModel.Location = New System.Drawing.Point(658, 180)
        Me.lnkModel.Name = "lnkModel"
        Me.lnkModel.Size = New System.Drawing.Size(156, 15)
        Me.lnkModel.TabIndex = 247
        Me.lnkModel.TabStop = True
        Me.lnkModel.Text = "1) 모델 시험기획 매핑"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("맑은 고딕", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label28.ForeColor = System.Drawing.Color.DimGray
        Me.Label28.Location = New System.Drawing.Point(43, 122)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(152, 25)
        Me.Label28.TabIndex = 245
        Me.Label28.Text = "Model 시험기획"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("맑은 고딕", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.DimGray
        Me.Label3.Location = New System.Drawing.Point(339, 51)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(162, 37)
        Me.Label3.TabIndex = 262
        Me.Label3.Text = "Model 기획"
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Location = New System.Drawing.Point(937, 180)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(72, 15)
        Me.LinkLabel1.TabIndex = 263
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "기존 매핑"
        '
        'lnk_AppMapp
        '
        Me.lnk_AppMapp.AutoSize = True
        Me.lnk_AppMapp.Location = New System.Drawing.Point(846, 180)
        Me.lnk_AppMapp.Name = "lnk_AppMapp"
        Me.lnk_AppMapp.Size = New System.Drawing.Size(67, 15)
        Me.lnk_AppMapp.TabIndex = 263
        Me.lnk_AppMapp.TabStop = True
        Me.lnk_AppMapp.Text = "App 매핑"
        '
        'Product_of_Model
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1021, 331)
        Me.Controls.Add(Me.lnk_AppMapp)
        Me.Controls.Add(Me.LinkLabel1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lnkPlan)
        Me.Controls.Add(Me.Label31)
        Me.Controls.Add(Me.Label30)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.lnkExpert)
        Me.Controls.Add(Me.lnkModel)
        Me.Controls.Add(Me.Label28)
        Me.Controls.Add(Me.requestBtn)
        Me.Controls.Add(Me.PictureBox1)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "Product_of_Model"
        Me.Text = "Product_of_Model"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents requestBtn As Windows.Forms.Button
    Friend WithEvents PictureBox1 As Windows.Forms.PictureBox
    Friend WithEvents lnkPlan As Windows.Forms.LinkLabel
    Friend WithEvents Label31 As Windows.Forms.Label
    Friend WithEvents Label30 As Windows.Forms.Label
    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents Label13 As Windows.Forms.Label
    Friend WithEvents Label23 As Windows.Forms.Label
    Friend WithEvents Label22 As Windows.Forms.Label
    Friend WithEvents Label21 As Windows.Forms.Label
    Friend WithEvents Label16 As Windows.Forms.Label
    Friend WithEvents Label15 As Windows.Forms.Label
    Friend WithEvents Label10 As Windows.Forms.Label
    Friend WithEvents Label9 As Windows.Forms.Label
    Friend WithEvents Label12 As Windows.Forms.Label
    Friend WithEvents lnkExpert As Windows.Forms.LinkLabel
    Friend WithEvents lnkModel As Windows.Forms.LinkLabel
    Friend WithEvents Label28 As Windows.Forms.Label
    Friend WithEvents Label3 As Windows.Forms.Label
    Friend WithEvents LinkLabel1 As Windows.Forms.LinkLabel
    Friend WithEvents lnk_AppMapp As Windows.Forms.LinkLabel
End Class
