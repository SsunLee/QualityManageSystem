<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Product_of_Tester
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Product_of_Tester))
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.lnkPath = New System.Windows.Forms.LinkLabel()
        Me.requestBtn = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.Gray
        Me.Label14.Location = New System.Drawing.Point(58, 141)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(118, 15)
        Me.Label14.TabIndex = 218
        Me.Label14.Text = "1)  시험기획서(검증)"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label24.ForeColor = System.Drawing.Color.Gray
        Me.Label24.Location = New System.Drawing.Point(501, 141)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(43, 15)
        Me.Label24.TabIndex = 217
        Me.Label24.Text = "검증원"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.Gray
        Me.Label19.Location = New System.Drawing.Point(276, 141)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(99, 15)
        Me.Label19.TabIndex = 216
        Me.Label19.Text = "(Excel) 시험 검증"
        '
        'lnkPath
        '
        Me.lnkPath.AutoSize = True
        Me.lnkPath.Location = New System.Drawing.Point(657, 141)
        Me.lnkPath.Name = "lnkPath"
        Me.lnkPath.Size = New System.Drawing.Size(80, 12)
        Me.lnkPath.TabIndex = 215
        Me.lnkPath.TabStop = True
        Me.lnkPath.Text = "1) 시험기획서"
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
        Me.requestBtn.Location = New System.Drawing.Point(719, 13)
        Me.requestBtn.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.requestBtn.Name = "requestBtn"
        Me.requestBtn.Size = New System.Drawing.Size(69, 62)
        Me.requestBtn.TabIndex = 221
        Me.requestBtn.Text = "제안하기"
        Me.requestBtn.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.requestBtn.UseVisualStyleBackColor = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImage = CType(resources.GetObject("PictureBox1.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.InitialImage = CType(resources.GetObject("PictureBox1.InitialImage"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(12, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(200, 25)
        Me.PictureBox1.TabIndex = 220
        Me.PictureBox1.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("맑은 고딕", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.DimGray
        Me.Label2.Location = New System.Drawing.Point(286, 42)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(195, 30)
        Me.Label2.TabIndex = 219
        Me.Label2.Text = "검증원 실사용 기획"
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Font = New System.Drawing.Font("맑은 고딕", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label31.ForeColor = System.Drawing.Color.Gray
        Me.Label31.Location = New System.Drawing.Point(655, 105)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(64, 21)
        Me.Label31.TabIndex = 224
        Me.Label31.Text = "Output"
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Font = New System.Drawing.Font("맑은 고딕", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label30.ForeColor = System.Drawing.Color.Gray
        Me.Label30.Location = New System.Drawing.Point(500, 105)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(42, 21)
        Me.Label30.TabIndex = 225
        Me.Label30.Text = "담당"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("맑은 고딕", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Gray
        Me.Label1.Location = New System.Drawing.Point(298, 105)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(67, 21)
        Me.Label1.TabIndex = 226
        Me.Label1.Text = "Activity"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("맑은 고딕", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label28.ForeColor = System.Drawing.Color.DimGray
        Me.Label28.Location = New System.Drawing.Point(67, 102)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(118, 20)
        Me.Label28.TabIndex = 222
        Me.Label28.Text = "Model 시험기획"
        '
        'Product_of_Tester
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(800, 200)
        Me.Controls.Add(Me.Label31)
        Me.Controls.Add(Me.Label30)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label28)
        Me.Controls.Add(Me.requestBtn)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.lnkPath)
        Me.Name = "Product_of_Tester"
        Me.Text = "Product_of_Tester"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label14 As Windows.Forms.Label
    Friend WithEvents Label24 As Windows.Forms.Label
    Friend WithEvents Label19 As Windows.Forms.Label
    Friend WithEvents lnkPath As Windows.Forms.LinkLabel
    Friend WithEvents requestBtn As Windows.Forms.Button
    Friend WithEvents PictureBox1 As Windows.Forms.PictureBox
    Friend WithEvents Label2 As Windows.Forms.Label
    Friend WithEvents Label31 As Windows.Forms.Label
    Friend WithEvents Label30 As Windows.Forms.Label
    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents Label28 As Windows.Forms.Label
End Class
