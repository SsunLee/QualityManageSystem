<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class One_Time_Page
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(One_Time_Page))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Random_Search_txt = New System.Windows.Forms.TextBox()
        Me.lnk_onetime = New System.Windows.Forms.LinkLabel()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.requestBtn = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.btn_ppt = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.btn_Search = New System.Windows.Forms.Button()
        Me.btn_PathChk = New System.Windows.Forms.Button()
        Me.btn_Write = New System.Windows.Forms.Button()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Malgun Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.DimGray
        Me.Label1.Location = New System.Drawing.Point(12, 275)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(73, 17)
        Me.Label1.TabIndex = 37
        Me.Label1.Text = "경로 확인 :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Malgun Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.DimGray
        Me.Label3.Location = New System.Drawing.Point(35, 106)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(106, 17)
        Me.Label3.TabIndex = 37
        Me.Label3.Text = "재현 결과 [조회]"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Malgun Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.DimGray
        Me.Label4.Location = New System.Drawing.Point(35, 162)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(74, 17)
        Me.Label4.TabIndex = 37
        Me.Label4.Text = "ART Script"
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.Color.DimGray
        Me.Label15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label15.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.White
        Me.Label15.Location = New System.Drawing.Point(13, 106)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(16, 17)
        Me.Label15.TabIndex = 55
        Me.Label15.Text = "1"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Malgun Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.DimGray
        Me.Label5.Location = New System.Drawing.Point(206, 4)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(154, 20)
        Me.Label5.TabIndex = 54
        Me.Label5.Text = "검증 현황_1회성 분석"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.DimGray
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label2.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(13, 162)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(16, 17)
        Me.Label2.TabIndex = 55
        Me.Label2.Text = "2"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Malgun Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.DimGray
        Me.Label6.Location = New System.Drawing.Point(138, 384)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(39, 17)
        Me.Label6.TabIndex = 56
        Me.Label6.Text = "Excel"
        Me.Label6.Visible = False
        '
        'Random_Search_txt
        '
        Me.Random_Search_txt.Location = New System.Drawing.Point(20, 417)
        Me.Random_Search_txt.Multiline = True
        Me.Random_Search_txt.Name = "Random_Search_txt"
        Me.Random_Search_txt.Size = New System.Drawing.Size(459, 52)
        Me.Random_Search_txt.TabIndex = 60
        Me.Random_Search_txt.Visible = False
        '
        'lnk_onetime
        '
        Me.lnk_onetime.AutoSize = True
        Me.lnk_onetime.Font = New System.Drawing.Font("Malgun Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.lnk_onetime.Location = New System.Drawing.Point(91, 275)
        Me.lnk_onetime.Name = "lnk_onetime"
        Me.lnk_onetime.Size = New System.Drawing.Size(260, 17)
        Me.lnk_onetime.TabIndex = 62
        Me.lnk_onetime.TabStop = True
        Me.lnk_onetime.Text = "\\10.174.51.33\Q-Portal\1회성_재현전담"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Malgun Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.DimGray
        Me.Label9.Location = New System.Drawing.Point(35, 213)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(184, 17)
        Me.Label9.TabIndex = 37
        Me.Label9.Text = "1회성 Issue 재현 표준 매뉴얼"
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.DimGray
        Me.Label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label10.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(13, 213)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(16, 17)
        Me.Label10.TabIndex = 55
        Me.Label10.Text = "3"
        '
        'requestBtn
        '
        Me.requestBtn.BackColor = System.Drawing.Color.Transparent
        Me.requestBtn.BackgroundImage = CType(resources.GetObject("requestBtn.BackgroundImage"), System.Drawing.Image)
        Me.requestBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.requestBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.requestBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.requestBtn.Font = New System.Drawing.Font("Malgun Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.requestBtn.ForeColor = System.Drawing.Color.Black
        Me.requestBtn.Location = New System.Drawing.Point(400, 4)
        Me.requestBtn.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.requestBtn.Name = "requestBtn"
        Me.requestBtn.Size = New System.Drawing.Size(69, 62)
        Me.requestBtn.TabIndex = 141
        Me.requestBtn.Text = "제안하기"
        Me.requestBtn.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.requestBtn.UseVisualStyleBackColor = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImage = CType(resources.GetObject("PictureBox1.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.InitialImage = CType(resources.GetObject("PictureBox1.InitialImage"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(0, 4)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(200, 25)
        Me.PictureBox1.TabIndex = 61
        Me.PictureBox1.TabStop = False
        '
        'btn_ppt
        '
        Me.btn_ppt.BackgroundImage = My.Resources.Resources.ms_powerpoint_logo1600
        Me.btn_ppt.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btn_ppt.FlatAppearance.BorderSize = 0
        Me.btn_ppt.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_ppt.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.btn_ppt.ForeColor = System.Drawing.Color.Black
        Me.btn_ppt.Location = New System.Drawing.Point(315, 202)
        Me.btn_ppt.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btn_ppt.Name = "btn_ppt"
        Me.btn_ppt.Size = New System.Drawing.Size(70, 55)
        Me.btn_ppt.TabIndex = 40
        Me.btn_ppt.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.BackgroundImage = CType(resources.GetObject("Button1.BackgroundImage"), System.Drawing.Image)
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.Black
        Me.Button1.Location = New System.Drawing.Point(319, 148)
        Me.Button1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(58, 46)
        Me.Button1.TabIndex = 40
        Me.Button1.UseVisualStyleBackColor = True
        '
        'btn_Search
        '
        Me.btn_Search.BackColor = System.Drawing.Color.White
        Me.btn_Search.BackgroundImage = CType(resources.GetObject("btn_Search.BackgroundImage"), System.Drawing.Image)
        Me.btn_Search.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btn_Search.FlatAppearance.BorderSize = 0
        Me.btn_Search.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Search.Font = New System.Drawing.Font("Malgun Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.btn_Search.ForeColor = System.Drawing.Color.Black
        Me.btn_Search.Location = New System.Drawing.Point(323, 96)
        Me.btn_Search.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btn_Search.Name = "btn_Search"
        Me.btn_Search.Size = New System.Drawing.Size(50, 35)
        Me.btn_Search.TabIndex = 39
        Me.btn_Search.UseVisualStyleBackColor = False
        '
        'btn_PathChk
        '
        Me.btn_PathChk.BackColor = System.Drawing.Color.Transparent
        Me.btn_PathChk.BackgroundImage = CType(resources.GetObject("btn_PathChk.BackgroundImage"), System.Drawing.Image)
        Me.btn_PathChk.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btn_PathChk.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_PathChk.FlatAppearance.BorderSize = 0
        Me.btn_PathChk.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_PathChk.Font = New System.Drawing.Font("Malgun Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.btn_PathChk.ForeColor = System.Drawing.Color.DimGray
        Me.btn_PathChk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_PathChk.Location = New System.Drawing.Point(12, 376)
        Me.btn_PathChk.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btn_PathChk.Name = "btn_PathChk"
        Me.btn_PathChk.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btn_PathChk.Size = New System.Drawing.Size(71, 34)
        Me.btn_PathChk.TabIndex = 39
        Me.btn_PathChk.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_PathChk.UseVisualStyleBackColor = False
        Me.btn_PathChk.Visible = False
        '
        'btn_Write
        '
        Me.btn_Write.BackColor = System.Drawing.Color.White
        Me.btn_Write.BackgroundImage = CType(resources.GetObject("btn_Write.BackgroundImage"), System.Drawing.Image)
        Me.btn_Write.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btn_Write.FlatAppearance.BorderSize = 0
        Me.btn_Write.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Write.Font = New System.Drawing.Font("Malgun Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.btn_Write.ForeColor = System.Drawing.Color.Black
        Me.btn_Write.Location = New System.Drawing.Point(82, 378)
        Me.btn_Write.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btn_Write.Name = "btn_Write"
        Me.btn_Write.Size = New System.Drawing.Size(50, 30)
        Me.btn_Write.TabIndex = 39
        Me.btn_Write.UseVisualStyleBackColor = False
        Me.btn_Write.Visible = False
        '
        'One_Time_Page
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(491, 662)
        Me.Controls.Add(Me.requestBtn)
        Me.Controls.Add(Me.lnk_onetime)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Random_Search_txt)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.btn_ppt)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.btn_Search)
        Me.Controls.Add(Me.btn_PathChk)
        Me.Controls.Add(Me.btn_Write)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Malgun Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.ForeColor = System.Drawing.Color.Blue
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "One_Time_Page"
        Me.Text = "1회성 결함 분석 결과 조회하기"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents btn_Write As Windows.Forms.Button
    Friend WithEvents Label3 As Windows.Forms.Label
    Friend WithEvents btn_Search As Windows.Forms.Button
    Friend WithEvents btn_PathChk As Windows.Forms.Button
    Friend WithEvents Label4 As Windows.Forms.Label
    Friend WithEvents Button1 As Windows.Forms.Button
    Friend WithEvents Label15 As Windows.Forms.Label
    Friend WithEvents Label5 As Windows.Forms.Label
    Friend WithEvents Label2 As Windows.Forms.Label
    Friend WithEvents Label6 As Windows.Forms.Label
    Friend WithEvents Random_Search_txt As Windows.Forms.TextBox
    Friend WithEvents PictureBox1 As Windows.Forms.PictureBox
    Friend WithEvents lnk_onetime As Windows.Forms.LinkLabel
    Friend WithEvents requestBtn As Windows.Forms.Button
    Friend WithEvents Label9 As Windows.Forms.Label
    Friend WithEvents btn_ppt As Windows.Forms.Button
    Friend WithEvents Label10 As Windows.Forms.Label
End Class
