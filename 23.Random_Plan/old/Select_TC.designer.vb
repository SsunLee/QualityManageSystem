<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Select_TC
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Select_TC))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TCnameTxt = New System.Windows.Forms.TextBox()
        Me.TCPurposeTxt = New System.Windows.Forms.TextBox()
        Me.DetectedTxt_ = New System.Windows.Forms.TextBox()
        Me.PriTxt = New System.Windows.Forms.TextBox()
        Me.MDTxt = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Mid_CB = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Min_CB = New System.Windows.Forms.ComboBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.DaeCB = New System.Windows.Forms.ComboBox()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.requestBtn = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.DimGray
        Me.Label1.Location = New System.Drawing.Point(29, 149)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(38, 15)
        Me.Label1.TabIndex = 29
        Me.Label1.Text = "TC 명"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.DimGray
        Me.Label3.Location = New System.Drawing.Point(36, 197)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(31, 15)
        Me.Label3.TabIndex = 29
        Me.Label3.Text = "목적"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.DimGray
        Me.Label4.Location = New System.Drawing.Point(12, 235)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(55, 15)
        Me.Label4.TabIndex = 29
        Me.Label4.Text = "검증항목"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.DimGray
        Me.Label5.Location = New System.Drawing.Point(12, 357)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(55, 30)
        Me.Label5.TabIndex = 29
        Me.Label5.Text = "등급별 " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "진행기준"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.DimGray
        Me.Label6.Location = New System.Drawing.Point(11, 447)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(56, 15)
        Me.Label6.TabIndex = 29
        Me.Label6.Text = "투입 MD"
        '
        'TCnameTxt
        '
        Me.TCnameTxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TCnameTxt.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.TCnameTxt.ForeColor = System.Drawing.Color.DimGray
        Me.TCnameTxt.Location = New System.Drawing.Point(79, 148)
        Me.TCnameTxt.Multiline = True
        Me.TCnameTxt.Name = "TCnameTxt"
        Me.TCnameTxt.Size = New System.Drawing.Size(427, 27)
        Me.TCnameTxt.TabIndex = 30
        '
        'TCPurposeTxt
        '
        Me.TCPurposeTxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TCPurposeTxt.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.TCPurposeTxt.ForeColor = System.Drawing.Color.DimGray
        Me.TCPurposeTxt.Location = New System.Drawing.Point(79, 193)
        Me.TCPurposeTxt.Name = "TCPurposeTxt"
        Me.TCPurposeTxt.Size = New System.Drawing.Size(427, 23)
        Me.TCPurposeTxt.TabIndex = 30
        '
        'DetectedTxt_
        '
        Me.DetectedTxt_.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.DetectedTxt_.ForeColor = System.Drawing.Color.DimGray
        Me.DetectedTxt_.Location = New System.Drawing.Point(79, 233)
        Me.DetectedTxt_.Multiline = True
        Me.DetectedTxt_.Name = "DetectedTxt_"
        Me.DetectedTxt_.Size = New System.Drawing.Size(427, 111)
        Me.DetectedTxt_.TabIndex = 30
        '
        'PriTxt
        '
        Me.PriTxt.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.PriTxt.ForeColor = System.Drawing.Color.DimGray
        Me.PriTxt.Location = New System.Drawing.Point(79, 353)
        Me.PriTxt.Multiline = True
        Me.PriTxt.Name = "PriTxt"
        Me.PriTxt.Size = New System.Drawing.Size(427, 82)
        Me.PriTxt.TabIndex = 30
        '
        'MDTxt
        '
        Me.MDTxt.BackColor = System.Drawing.Color.PeachPuff
        Me.MDTxt.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.MDTxt.ForeColor = System.Drawing.Color.DimGray
        Me.MDTxt.Location = New System.Drawing.Point(79, 444)
        Me.MDTxt.Name = "MDTxt"
        Me.MDTxt.Size = New System.Drawing.Size(145, 23)
        Me.MDTxt.TabIndex = 30
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.DimGray
        Me.Label7.Location = New System.Drawing.Point(24, 81)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(43, 15)
        Me.Label7.TabIndex = 29
        Me.Label7.Text = "중분류"
        '
        'Mid_CB
        '
        Me.Mid_CB.BackColor = System.Drawing.SystemColors.Info
        Me.Mid_CB.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Mid_CB.ForeColor = System.Drawing.Color.DimGray
        Me.Mid_CB.FormattingEnabled = True
        Me.Mid_CB.Location = New System.Drawing.Point(79, 78)
        Me.Mid_CB.Name = "Mid_CB"
        Me.Mid_CB.Size = New System.Drawing.Size(222, 23)
        Me.Mid_CB.TabIndex = 31
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.DimGray
        Me.Label8.Location = New System.Drawing.Point(24, 110)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(43, 15)
        Me.Label8.TabIndex = 29
        Me.Label8.Text = "소분류"
        '
        'Min_CB
        '
        Me.Min_CB.BackColor = System.Drawing.SystemColors.Info
        Me.Min_CB.Font = New System.Drawing.Font("맑은 고딕", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Min_CB.ForeColor = System.Drawing.Color.DimGray
        Me.Min_CB.FormattingEnabled = True
        Me.Min_CB.Location = New System.Drawing.Point(79, 107)
        Me.Min_CB.Name = "Min_CB"
        Me.Min_CB.Size = New System.Drawing.Size(427, 21)
        Me.Min_CB.TabIndex = 31
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Transparent
        Me.Button1.BackgroundImage = My.Resources.Resources._20151012_561bae9e3bd57
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Button1.Location = New System.Drawing.Point(509, 4)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(63, 42)
        Me.Button1.TabIndex = 32
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Button2.ForeColor = System.Drawing.Color.White
        Me.Button2.Location = New System.Drawing.Point(15, 486)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(137, 27)
        Me.Button2.TabIndex = 32
        Me.Button2.Text = "TC 열기"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.DimGray
        Me.Label9.Location = New System.Drawing.Point(24, 51)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(43, 15)
        Me.Label9.TabIndex = 29
        Me.Label9.Text = "대분류"
        '
        'DaeCB
        '
        Me.DaeCB.BackColor = System.Drawing.SystemColors.Info
        Me.DaeCB.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.DaeCB.ForeColor = System.Drawing.Color.DimGray
        Me.DaeCB.FormattingEnabled = True
        Me.DaeCB.Location = New System.Drawing.Point(79, 48)
        Me.DaeCB.Name = "DaeCB"
        Me.DaeCB.Size = New System.Drawing.Size(222, 23)
        Me.DaeCB.TabIndex = 31
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(520, 139)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowTemplate.Height = 23
        Me.DataGridView1.Size = New System.Drawing.Size(688, 296)
        Me.DataGridView1.TabIndex = 33
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("맑은 고딕", 18.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label10.Location = New System.Drawing.Point(722, 81)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(288, 32)
        Me.Label10.TabIndex = 34
        Me.Label10.Text = "■ History Management"
        '
        'PictureBox2
        '
        Me.PictureBox2.BackgroundImage = CType(resources.GetObject("PictureBox2.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox2.Location = New System.Drawing.Point(8, 4)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(216, 25)
        Me.PictureBox2.TabIndex = 65
        Me.PictureBox2.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("맑은 고딕", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.DimGray
        Me.Label2.Location = New System.Drawing.Point(230, 4)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(144, 20)
        Me.Label2.TabIndex = 64
        Me.Label2.Text = "Check-List_목적T/C"
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
        Me.requestBtn.Location = New System.Drawing.Point(436, 4)
        Me.requestBtn.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.requestBtn.Name = "requestBtn"
        Me.requestBtn.Size = New System.Drawing.Size(67, 62)
        Me.requestBtn.TabIndex = 143
        Me.requestBtn.Text = "제안하기"
        Me.requestBtn.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.requestBtn.UseVisualStyleBackColor = False
        '
        'Button3
        '
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Button3.Location = New System.Drawing.Point(177, 485)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(197, 28)
        Me.Button3.TabIndex = 144
        Me.Button3.Text = "이 TC로 선택하기"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button4.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Button4.Location = New System.Drawing.Point(392, 485)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(105, 27)
        Me.Button4.TabIndex = 145
        Me.Button4.Text = "직접 작성하기"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Select_TC
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1220, 525)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.requestBtn)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Min_CB)
        Me.Controls.Add(Me.DaeCB)
        Me.Controls.Add(Me.Mid_CB)
        Me.Controls.Add(Me.PriTxt)
        Me.Controls.Add(Me.DetectedTxt_)
        Me.Controls.Add(Me.MDTxt)
        Me.Controls.Add(Me.TCPurposeTxt)
        Me.Controls.Add(Me.TCnameTxt)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Select_TC"
        Me.Text = "목적 T/C"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents Label3 As Windows.Forms.Label
    Friend WithEvents Label4 As Windows.Forms.Label
    Friend WithEvents Label5 As Windows.Forms.Label
    Friend WithEvents Label6 As Windows.Forms.Label
    Friend WithEvents TCnameTxt As Windows.Forms.TextBox
    Friend WithEvents TCPurposeTxt As Windows.Forms.TextBox
    Friend WithEvents DetectedTxt_ As Windows.Forms.TextBox
    Friend WithEvents PriTxt As Windows.Forms.TextBox
    Friend WithEvents MDTxt As Windows.Forms.TextBox
    Friend WithEvents Label7 As Windows.Forms.Label
    Friend WithEvents Mid_CB As Windows.Forms.ComboBox
    Friend WithEvents Label8 As Windows.Forms.Label
    Friend WithEvents Min_CB As Windows.Forms.ComboBox
    Friend WithEvents Button1 As Windows.Forms.Button
    Friend WithEvents Button2 As Windows.Forms.Button
    Friend WithEvents Label9 As Windows.Forms.Label
    Friend WithEvents DaeCB As Windows.Forms.ComboBox
    Friend WithEvents DataGridView1 As Windows.Forms.DataGridView
    Friend WithEvents Label10 As Windows.Forms.Label
    Friend WithEvents PictureBox2 As Windows.Forms.PictureBox
    Friend WithEvents Label2 As Windows.Forms.Label
    Friend WithEvents requestBtn As Windows.Forms.Button
    Friend WithEvents Button3 As Windows.Forms.Button
    Friend WithEvents Button4 As Windows.Forms.Button
End Class
