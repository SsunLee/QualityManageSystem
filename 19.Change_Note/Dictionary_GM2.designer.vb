<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Dictionary_GM2
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Dictionary_GM2))
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtHistory = New System.Windows.Forms.TextBox()
        Me.txtRisk = New System.Windows.Forms.TextBox()
        Me.txtKey = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtStep = New System.Windows.Forms.TextBox()
        Me.Des_Txt = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Search_Result = New System.Windows.Forms.ListBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.ListBox2 = New System.Windows.Forms.ListBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.ListBox3 = New System.Windows.Forms.ListBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ListBox4 = New System.Windows.Forms.ListBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.lb_SW = New System.Windows.Forms.Label()
        Me.btn_VPSearch = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.requestBtn = New System.Windows.Forms.Button()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Malgun Gothic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.DimGray
        Me.Label6.Location = New System.Drawing.Point(283, 9)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(198, 25)
        Me.Label6.TabIndex = 47
        Me.Label6.Text = "Random_변경점 검증"
        '
        'txtHistory
        '
        Me.txtHistory.BackColor = System.Drawing.Color.White
        Me.txtHistory.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.txtHistory.Location = New System.Drawing.Point(615, 526)
        Me.txtHistory.Multiline = True
        Me.txtHistory.Name = "txtHistory"
        Me.txtHistory.ReadOnly = True
        Me.txtHistory.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtHistory.Size = New System.Drawing.Size(593, 119)
        Me.txtHistory.TabIndex = 43
        '
        'txtRisk
        '
        Me.txtRisk.BackColor = System.Drawing.Color.White
        Me.txtRisk.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.txtRisk.Location = New System.Drawing.Point(614, 355)
        Me.txtRisk.Multiline = True
        Me.txtRisk.Name = "txtRisk"
        Me.txtRisk.ReadOnly = True
        Me.txtRisk.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtRisk.Size = New System.Drawing.Size(593, 119)
        Me.txtRisk.TabIndex = 42
        '
        'txtKey
        '
        Me.txtKey.BackColor = System.Drawing.Color.White
        Me.txtKey.Font = New System.Drawing.Font("Malgun Gothic", 8.0!)
        Me.txtKey.Location = New System.Drawing.Point(1021, 78)
        Me.txtKey.Multiline = True
        Me.txtKey.Name = "txtKey"
        Me.txtKey.ReadOnly = True
        Me.txtKey.Size = New System.Drawing.Size(175, 18)
        Me.txtKey.TabIndex = 41
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Gulim", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Gray
        Me.Label10.Location = New System.Drawing.Point(887, 507)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(51, 12)
        Me.Label10.TabIndex = 32
        Me.Label10.Text = "History"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Gulim", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Gray
        Me.Label9.Location = New System.Drawing.Point(871, 338)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(79, 12)
        Me.Label9.TabIndex = 34
        Me.Label9.Text = "Risk Factor"
        '
        'txtStep
        '
        Me.txtStep.BackColor = System.Drawing.Color.White
        Me.txtStep.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.txtStep.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.txtStep.Location = New System.Drawing.Point(14, 526)
        Me.txtStep.Multiline = True
        Me.txtStep.Name = "txtStep"
        Me.txtStep.ReadOnly = True
        Me.txtStep.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtStep.Size = New System.Drawing.Size(594, 119)
        Me.txtStep.TabIndex = 44
        '
        'Des_Txt
        '
        Me.Des_Txt.BackColor = System.Drawing.Color.White
        Me.Des_Txt.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Des_Txt.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Des_Txt.Location = New System.Drawing.Point(13, 355)
        Me.Des_Txt.Multiline = True
        Me.Des_Txt.Name = "Des_Txt"
        Me.Des_Txt.ReadOnly = True
        Me.Des_Txt.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.Des_Txt.Size = New System.Drawing.Size(593, 119)
        Me.Des_Txt.TabIndex = 39
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Gray
        Me.Label8.Location = New System.Drawing.Point(936, 78)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(58, 15)
        Me.Label8.TabIndex = 36
        Me.Label8.Text = "Keyword"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Gulim", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Gray
        Me.Label2.Location = New System.Drawing.Point(241, 507)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(57, 12)
        Me.Label2.TabIndex = 33
        Me.Label2.Text = "검증방법"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Gray
        Me.Label5.Location = New System.Drawing.Point(125, 128)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(31, 15)
        Me.Label5.TabIndex = 38
        Me.Label5.Text = "분류"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Gulim", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Gray
        Me.Label3.Location = New System.Drawing.Point(249, 338)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(31, 12)
        Me.Label3.TabIndex = 31
        Me.Label3.Text = "설명"
        '
        'Search_Result
        '
        Me.Search_Result.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Search_Result.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Search_Result.FormattingEnabled = True
        Me.Search_Result.ItemHeight = 15
        Me.Search_Result.Location = New System.Drawing.Point(13, 152)
        Me.Search_Result.Name = "Search_Result"
        Me.Search_Result.Size = New System.Drawing.Size(292, 152)
        Me.Search_Result.TabIndex = 27
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TextBox1.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(78, 73)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(227, 23)
        Me.TextBox1.TabIndex = 26
        '
        'Button2
        '
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Button2.ForeColor = System.Drawing.Color.Gray
        Me.Button2.Location = New System.Drawing.Point(314, 73)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(99, 23)
        Me.Button2.TabIndex = 100
        Me.Button2.Text = "Search"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Gray
        Me.Label1.Location = New System.Drawing.Point(22, 77)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 15)
        Me.Label1.TabIndex = 35
        Me.Label1.Text = "검색어"
        '
        'ListBox1
        '
        Me.ListBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ListBox1.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.ItemHeight = 15
        Me.ListBox1.Location = New System.Drawing.Point(313, 152)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(292, 152)
        Me.ListBox1.TabIndex = 28
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Gray
        Me.Label11.Location = New System.Drawing.Point(450, 128)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(31, 15)
        Me.Label11.TabIndex = 38
        Me.Label11.Text = "용어"
        '
        'ListBox2
        '
        Me.ListBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ListBox2.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.ListBox2.FormattingEnabled = True
        Me.ListBox2.ItemHeight = 15
        Me.ListBox2.Location = New System.Drawing.Point(808, 152)
        Me.ListBox2.Name = "ListBox2"
        Me.ListBox2.Size = New System.Drawing.Size(205, 152)
        Me.ListBox2.TabIndex = 30
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Gray
        Me.Label12.Location = New System.Drawing.Point(895, 128)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(29, 15)
        Me.Label12.TabIndex = 38
        Me.Label12.Text = "APP"
        '
        'ListBox3
        '
        Me.ListBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ListBox3.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.ListBox3.FormattingEnabled = True
        Me.ListBox3.ItemHeight = 15
        Me.ListBox3.Location = New System.Drawing.Point(1021, 152)
        Me.ListBox3.Name = "ListBox3"
        Me.ListBox3.Size = New System.Drawing.Size(186, 152)
        Me.ListBox3.TabIndex = 31
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Gray
        Me.Label13.Location = New System.Drawing.Point(1084, 128)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(78, 15)
        Me.Label13.TabIndex = 38
        Me.Label13.Text = "APP_Feature"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Gray
        Me.Label4.Location = New System.Drawing.Point(674, 128)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(64, 15)
        Me.Label4.TabIndex = 36
        Me.Label4.Text = "Test Type"
        '
        'ListBox4
        '
        Me.ListBox4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ListBox4.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.ListBox4.FormattingEnabled = True
        Me.ListBox4.ItemHeight = 15
        Me.ListBox4.Location = New System.Drawing.Point(613, 152)
        Me.ListBox4.Name = "ListBox4"
        Me.ListBox4.Size = New System.Drawing.Size(187, 152)
        Me.ListBox4.TabIndex = 29
        '
        'Button1
        '
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.Gray
        Me.Button1.Location = New System.Drawing.Point(421, 73)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(99, 23)
        Me.Button1.TabIndex = 100
        Me.Button1.Text = "초기화"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'lb_SW
        '
        Me.lb_SW.AutoSize = True
        Me.lb_SW.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lb_SW.Font = New System.Drawing.Font("Malgun Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.lb_SW.ForeColor = System.Drawing.Color.DimGray
        Me.lb_SW.Location = New System.Drawing.Point(1045, 17)
        Me.lb_SW.Name = "lb_SW"
        Me.lb_SW.Size = New System.Drawing.Size(39, 17)
        Me.lb_SW.TabIndex = 103
        Me.lb_SW.Text = "Excel"
        '
        'btn_VPSearch
        '
        Me.btn_VPSearch.BackColor = System.Drawing.Color.Transparent
        Me.btn_VPSearch.BackgroundImage = CType(resources.GetObject("btn_VPSearch.BackgroundImage"), System.Drawing.Image)
        Me.btn_VPSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btn_VPSearch.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_VPSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_VPSearch.Font = New System.Drawing.Font("Malgun Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.btn_VPSearch.ForeColor = System.Drawing.Color.White
        Me.btn_VPSearch.Location = New System.Drawing.Point(989, 11)
        Me.btn_VPSearch.Name = "btn_VPSearch"
        Me.btn_VPSearch.Size = New System.Drawing.Size(57, 30)
        Me.btn_VPSearch.TabIndex = 102
        Me.btn_VPSearch.UseVisualStyleBackColor = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImage = CType(resources.GetObject("PictureBox1.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.InitialImage = CType(resources.GetObject("PictureBox1.InitialImage"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(14, 8)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(247, 25)
        Me.PictureBox1.TabIndex = 101
        Me.PictureBox1.TabStop = False
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
        Me.requestBtn.Location = New System.Drawing.Point(1118, 8)
        Me.requestBtn.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.requestBtn.Name = "requestBtn"
        Me.requestBtn.Size = New System.Drawing.Size(78, 58)
        Me.requestBtn.TabIndex = 143
        Me.requestBtn.Text = "제안하기"
        Me.requestBtn.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.requestBtn.UseVisualStyleBackColor = False
        '
        'Dictionary_GM2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1218, 661)
        Me.Controls.Add(Me.requestBtn)
        Me.Controls.Add(Me.lb_SW)
        Me.Controls.Add(Me.btn_VPSearch)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtHistory)
        Me.Controls.Add(Me.txtRisk)
        Me.Controls.Add(Me.txtKey)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtStep)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Des_Txt)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.ListBox3)
        Me.Controls.Add(Me.ListBox2)
        Me.Controls.Add(Me.ListBox4)
        Me.Controls.Add(Me.ListBox1)
        Me.Controls.Add(Me.Search_Result)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Button2)
        Me.Font = New System.Drawing.Font("Gulim", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Name = "Dictionary_GM2"
        Me.Text = "변경점 검증"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label6 As Windows.Forms.Label
    Friend WithEvents txtHistory As Windows.Forms.TextBox
    Friend WithEvents txtRisk As Windows.Forms.TextBox
    Friend WithEvents txtKey As Windows.Forms.TextBox
    Friend WithEvents Label10 As Windows.Forms.Label
    Friend WithEvents Label9 As Windows.Forms.Label
    Friend WithEvents txtStep As Windows.Forms.TextBox
    Friend WithEvents Des_Txt As Windows.Forms.TextBox
    Friend WithEvents Label8 As Windows.Forms.Label
    Friend WithEvents Label2 As Windows.Forms.Label
    Friend WithEvents Label5 As Windows.Forms.Label
    Friend WithEvents Label3 As Windows.Forms.Label
    Friend WithEvents Search_Result As Windows.Forms.ListBox
    Friend WithEvents TextBox1 As Windows.Forms.TextBox
    Friend WithEvents ToolTip1 As Windows.Forms.ToolTip
    Friend WithEvents Button2 As Windows.Forms.Button
    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents ListBox1 As Windows.Forms.ListBox
    Friend WithEvents Label11 As Windows.Forms.Label
    Friend WithEvents ListBox2 As Windows.Forms.ListBox
    Friend WithEvents Label12 As Windows.Forms.Label
    Friend WithEvents ListBox3 As Windows.Forms.ListBox
    Friend WithEvents Label13 As Windows.Forms.Label
    Friend WithEvents Label4 As Windows.Forms.Label
    Friend WithEvents ListBox4 As Windows.Forms.ListBox
    Friend WithEvents Button1 As Windows.Forms.Button
    Friend WithEvents PictureBox1 As Windows.Forms.PictureBox
    Friend WithEvents lb_SW As Windows.Forms.Label
    Friend WithEvents btn_VPSearch As Windows.Forms.Button
    Friend WithEvents requestBtn As Windows.Forms.Button
End Class
