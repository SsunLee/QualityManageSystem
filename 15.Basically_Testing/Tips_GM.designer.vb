<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Tips_GM
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Tips_GM))
        Me.Button1 = New System.Windows.Forms.Button()
        Me.txtAround = New System.Windows.Forms.TextBox()
        Me.txtDefault = New System.Windows.Forms.TextBox()
        Me.lstType = New System.Windows.Forms.ListBox()
        Me.lstFea = New System.Windows.Forms.ListBox()
        Me.lstApp = New System.Windows.Forms.ListBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.SanityRD = New System.Windows.Forms.RadioButton()
        Me.FullRD = New System.Windows.Forms.RadioButton()
        Me.txt_Cnt = New System.Windows.Forms.TextBox()
        Me.BasicRD = New System.Windows.Forms.RadioButton()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.DesTxt = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txt_Type = New System.Windows.Forms.TextBox()
        Me.txt_Fea = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.btnOpen = New System.Windows.Forms.Button()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txt_History = New System.Windows.Forms.TextBox()
        Me.btnExportTC = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Transparent
        Me.Button1.BackgroundImage = My.Resources.Resources.business_ideas
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.Black
        Me.Button1.Location = New System.Drawing.Point(690, 12)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(76, 57)
        Me.Button1.TabIndex = 27
        Me.Button1.Text = "문의하기"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button1.UseVisualStyleBackColor = False
        '
        'txtAround
        '
        Me.txtAround.BackColor = System.Drawing.Color.White
        Me.txtAround.Location = New System.Drawing.Point(418, 491)
        Me.txtAround.Multiline = True
        Me.txtAround.Name = "txtAround"
        Me.txtAround.ReadOnly = True
        Me.txtAround.Size = New System.Drawing.Size(348, 126)
        Me.txtAround.TabIndex = 26
        '
        'txtDefault
        '
        Me.txtDefault.BackColor = System.Drawing.Color.White
        Me.txtDefault.Location = New System.Drawing.Point(12, 490)
        Me.txtDefault.Multiline = True
        Me.txtDefault.Name = "txtDefault"
        Me.txtDefault.ReadOnly = True
        Me.txtDefault.Size = New System.Drawing.Size(399, 127)
        Me.txtDefault.TabIndex = 25
        '
        'lstType
        '
        Me.lstType.FormattingEnabled = True
        Me.lstType.HorizontalScrollbar = True
        Me.lstType.ItemHeight = 12
        Me.lstType.Location = New System.Drawing.Point(488, 171)
        Me.lstType.Name = "lstType"
        Me.lstType.Size = New System.Drawing.Size(274, 172)
        Me.lstType.Sorted = True
        Me.lstType.TabIndex = 23
        '
        'lstFea
        '
        Me.lstFea.FormattingEnabled = True
        Me.lstFea.HorizontalScrollbar = True
        Me.lstFea.ItemHeight = 12
        Me.lstFea.Location = New System.Drawing.Point(228, 171)
        Me.lstFea.Name = "lstFea"
        Me.lstFea.Size = New System.Drawing.Size(242, 172)
        Me.lstFea.Sorted = True
        Me.lstFea.TabIndex = 22
        '
        'lstApp
        '
        Me.lstApp.FormattingEnabled = True
        Me.lstApp.HorizontalScrollbar = True
        Me.lstApp.ItemHeight = 12
        Me.lstApp.Location = New System.Drawing.Point(12, 171)
        Me.lstApp.Name = "lstApp"
        Me.lstApp.Size = New System.Drawing.Size(199, 172)
        Me.lstApp.Sorted = True
        Me.lstApp.TabIndex = 21
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("맑은 고딕", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Gray
        Me.Label4.Location = New System.Drawing.Point(581, 149)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(90, 20)
        Me.Label4.TabIndex = 20
        Me.Label4.Text = "Test Action"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("맑은 고딕", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Gray
        Me.Label3.Location = New System.Drawing.Point(316, 148)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(62, 20)
        Me.Label3.TabIndex = 19
        Me.Label3.Text = "Feature"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("맑은 고딕", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Gray
        Me.Label7.Location = New System.Drawing.Point(421, 467)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(97, 20)
        Me.Label7.TabIndex = 18
        Me.Label7.Text = "Around 확인"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("맑은 고딕", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Gray
        Me.Label6.Location = New System.Drawing.Point(12, 467)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(74, 20)
        Me.Label6.TabIndex = 17
        Me.Label6.Text = "기본 검증"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("맑은 고딕", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Gray
        Me.Label5.Location = New System.Drawing.Point(12, 349)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(39, 20)
        Me.Label5.TabIndex = 16
        Me.Label5.Text = "설명"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("맑은 고딕", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Gray
        Me.Label2.Location = New System.Drawing.Point(60, 148)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(85, 20)
        Me.Label2.TabIndex = 15
        Me.Label2.Text = "App Name"
        '
        'SanityRD
        '
        Me.SanityRD.AutoSize = True
        Me.SanityRD.Font = New System.Drawing.Font("맑은 고딕", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.SanityRD.ForeColor = System.Drawing.Color.DimGray
        Me.SanityRD.Location = New System.Drawing.Point(8, 20)
        Me.SanityRD.Name = "SanityRD"
        Me.SanityRD.Size = New System.Drawing.Size(61, 21)
        Me.SanityRD.TabIndex = 32
        Me.SanityRD.TabStop = True
        Me.SanityRD.Text = "Sanity"
        Me.SanityRD.UseVisualStyleBackColor = True
        '
        'FullRD
        '
        Me.FullRD.AutoSize = True
        Me.FullRD.Font = New System.Drawing.Font("맑은 고딕", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.FullRD.ForeColor = System.Drawing.Color.DimGray
        Me.FullRD.Location = New System.Drawing.Point(155, 20)
        Me.FullRD.Name = "FullRD"
        Me.FullRD.Size = New System.Drawing.Size(46, 21)
        Me.FullRD.TabIndex = 31
        Me.FullRD.TabStop = True
        Me.FullRD.Text = "Full"
        Me.FullRD.UseVisualStyleBackColor = True
        '
        'txt_Cnt
        '
        Me.txt_Cnt.BackColor = System.Drawing.SystemColors.Info
        Me.txt_Cnt.Location = New System.Drawing.Point(54, 47)
        Me.txt_Cnt.Name = "txt_Cnt"
        Me.txt_Cnt.Size = New System.Drawing.Size(95, 21)
        Me.txt_Cnt.TabIndex = 34
        '
        'BasicRD
        '
        Me.BasicRD.AutoSize = True
        Me.BasicRD.Font = New System.Drawing.Font("맑은 고딕", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.BasicRD.ForeColor = System.Drawing.Color.DimGray
        Me.BasicRD.Location = New System.Drawing.Point(86, 20)
        Me.BasicRD.Name = "BasicRD"
        Me.BasicRD.Size = New System.Drawing.Size(56, 21)
        Me.BasicRD.TabIndex = 30
        Me.BasicRD.TabStop = True
        Me.BasicRD.Text = "Basic"
        Me.BasicRD.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Gray
        Me.Label11.Location = New System.Drawing.Point(10, 51)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(38, 15)
        Me.Label11.TabIndex = 33
        Me.Label11.Text = "App :"
        '
        'DesTxt
        '
        Me.DesTxt.BackColor = System.Drawing.Color.White
        Me.DesTxt.Location = New System.Drawing.Point(12, 372)
        Me.DesTxt.Multiline = True
        Me.DesTxt.Name = "DesTxt"
        Me.DesTxt.ReadOnly = True
        Me.DesTxt.Size = New System.Drawing.Size(399, 91)
        Me.DesTxt.TabIndex = 24
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.SanityRD)
        Me.GroupBox1.Controls.Add(Me.FullRD)
        Me.GroupBox1.Controls.Add(Me.txt_Type)
        Me.GroupBox1.Controls.Add(Me.txt_Fea)
        Me.GroupBox1.Controls.Add(Me.txt_Cnt)
        Me.GroupBox1.Controls.Add(Me.BasicRD)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Location = New System.Drawing.Point(10, 47)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(602, 82)
        Me.GroupBox1.TabIndex = 35
        Me.GroupBox1.TabStop = False
        '
        'txt_Type
        '
        Me.txt_Type.BackColor = System.Drawing.SystemColors.Info
        Me.txt_Type.Location = New System.Drawing.Point(431, 47)
        Me.txt_Type.Name = "txt_Type"
        Me.txt_Type.Size = New System.Drawing.Size(95, 21)
        Me.txt_Type.TabIndex = 34
        '
        'txt_Fea
        '
        Me.txt_Fea.BackColor = System.Drawing.SystemColors.Info
        Me.txt_Fea.Location = New System.Drawing.Point(237, 47)
        Me.txt_Fea.Name = "txt_Fea"
        Me.txt_Fea.Size = New System.Drawing.Size(95, 21)
        Me.txt_Fea.TabIndex = 34
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.DimGray
        Me.Label8.Location = New System.Drawing.Point(6, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(83, 15)
        Me.Label8.TabIndex = 11
        Me.Label8.Text = "[■ 기준 설정]"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Gray
        Me.Label10.Location = New System.Drawing.Point(347, 51)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(71, 15)
        Me.Label10.TabIndex = 33
        Me.Label10.Text = "Test Type :"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Gray
        Me.Label9.Location = New System.Drawing.Point(170, 51)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(58, 15)
        Me.Label9.TabIndex = 33
        Me.Label9.Text = "Feature :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("맑은 고딕", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.DimGray
        Me.Label1.Location = New System.Drawing.Point(234, 6)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(143, 20)
        Me.Label1.TabIndex = 53
        Me.Label1.Text = "Test Case_기본검증"
        '
        'PictureBox2
        '
        Me.PictureBox2.BackgroundImage = CType(resources.GetObject("PictureBox2.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox2.Location = New System.Drawing.Point(12, 6)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(216, 25)
        Me.PictureBox2.TabIndex = 62
        Me.PictureBox2.TabStop = False
        '
        'btnOpen
        '
        Me.btnOpen.BackColor = System.Drawing.Color.Transparent
        Me.btnOpen.BackgroundImage = CType(resources.GetObject("btnOpen.BackgroundImage"), System.Drawing.Image)
        Me.btnOpen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnOpen.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnOpen.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOpen.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.btnOpen.ForeColor = System.Drawing.Color.White
        Me.btnOpen.Location = New System.Drawing.Point(639, 12)
        Me.btnOpen.Name = "btnOpen"
        Me.btnOpen.Size = New System.Drawing.Size(45, 26)
        Me.btnOpen.TabIndex = 28
        Me.btnOpen.UseVisualStyleBackColor = False
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("맑은 고딕", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Gray
        Me.Label12.Location = New System.Drawing.Point(421, 349)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(61, 20)
        Me.Label12.TabIndex = 16
        Me.Label12.Text = "History"
        '
        'txt_History
        '
        Me.txt_History.BackColor = System.Drawing.Color.White
        Me.txt_History.Location = New System.Drawing.Point(425, 372)
        Me.txt_History.Multiline = True
        Me.txt_History.Name = "txt_History"
        Me.txt_History.ReadOnly = True
        Me.txt_History.Size = New System.Drawing.Size(337, 91)
        Me.txt_History.TabIndex = 26
        '
        'btnExportTC
        '
        Me.btnExportTC.BackColor = System.Drawing.Color.Lavender
        Me.btnExportTC.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExportTC.Font = New System.Drawing.Font("맑은 고딕", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnExportTC.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.btnExportTC.Location = New System.Drawing.Point(668, 83)
        Me.btnExportTC.Name = "btnExportTC"
        Me.btnExportTC.Size = New System.Drawing.Size(94, 38)
        Me.btnExportTC.TabIndex = 153
        Me.btnExportTC.Text = "TC 추출"
        Me.btnExportTC.UseVisualStyleBackColor = False
        '
        'Tips_GM
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(786, 632)
        Me.Controls.Add(Me.btnExportTC)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnOpen)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.txt_History)
        Me.Controls.Add(Me.txtAround)
        Me.Controls.Add(Me.txtDefault)
        Me.Controls.Add(Me.DesTxt)
        Me.Controls.Add(Me.lstType)
        Me.Controls.Add(Me.lstFea)
        Me.Controls.Add(Me.lstApp)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label2)
        Me.Name = "Tips_GM"
        Me.Text = "Tips_GM"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Button1 As Windows.Forms.Button
    Friend WithEvents txtAround As Windows.Forms.TextBox
    Friend WithEvents txtDefault As Windows.Forms.TextBox
    Friend WithEvents lstType As Windows.Forms.ListBox
    Friend WithEvents lstFea As Windows.Forms.ListBox
    Friend WithEvents lstApp As Windows.Forms.ListBox
    Friend WithEvents Label4 As Windows.Forms.Label
    Friend WithEvents Label3 As Windows.Forms.Label
    Friend WithEvents Label7 As Windows.Forms.Label
    Friend WithEvents Label6 As Windows.Forms.Label
    Friend WithEvents Label5 As Windows.Forms.Label
    Friend WithEvents Label2 As Windows.Forms.Label
    Friend WithEvents btnOpen As Windows.Forms.Button
    Friend WithEvents SanityRD As Windows.Forms.RadioButton
    Friend WithEvents FullRD As Windows.Forms.RadioButton
    Friend WithEvents txt_Cnt As Windows.Forms.TextBox
    Friend WithEvents BasicRD As Windows.Forms.RadioButton
    Friend WithEvents Label11 As Windows.Forms.Label
    Friend WithEvents DesTxt As Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As Windows.Forms.GroupBox
    Friend WithEvents Label8 As Windows.Forms.Label
    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents PictureBox2 As Windows.Forms.PictureBox
    Friend WithEvents Label9 As Windows.Forms.Label
    Friend WithEvents txt_Type As Windows.Forms.TextBox
    Friend WithEvents txt_Fea As Windows.Forms.TextBox
    Friend WithEvents Label10 As Windows.Forms.Label
    Friend WithEvents Label12 As Windows.Forms.Label
    Friend WithEvents txt_History As Windows.Forms.TextBox
    Friend WithEvents btnExportTC As Windows.Forms.Button
End Class
