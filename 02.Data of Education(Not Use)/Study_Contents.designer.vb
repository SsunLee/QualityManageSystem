<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Study_Contents
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Study_Contents))
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btn_Open = New System.Windows.Forms.Button()
        Me.txt_FileName = New System.Windows.Forms.TextBox()
        Me.txt_Des = New System.Windows.Forms.TextBox()
        Me.cb_Step = New System.Windows.Forms.ComboBox()
        Me.cb_Target = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lst_Title = New System.Windows.Forms.ListBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.requestBtn = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.DimGray
        Me.Label6.Location = New System.Drawing.Point(70, 130)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(264, 15)
        Me.Label6.TabIndex = 30
        Me.Label6.Text = "※ 교육 자료를 List 를 통해 확인할 수 있습니다."
        '
        'btn_Open
        '
        Me.btn_Open.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btn_Open.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Open.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.btn_Open.ForeColor = System.Drawing.Color.White
        Me.btn_Open.Location = New System.Drawing.Point(360, 160)
        Me.btn_Open.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btn_Open.Name = "btn_Open"
        Me.btn_Open.Size = New System.Drawing.Size(75, 29)
        Me.btn_Open.TabIndex = 29
        Me.btn_Open.Text = "파일 열기"
        Me.btn_Open.UseVisualStyleBackColor = False
        '
        'txt_FileName
        '
        Me.txt_FileName.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txt_FileName.ForeColor = System.Drawing.Color.DimGray
        Me.txt_FileName.Location = New System.Drawing.Point(102, 164)
        Me.txt_FileName.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txt_FileName.Name = "txt_FileName"
        Me.txt_FileName.ReadOnly = True
        Me.txt_FileName.Size = New System.Drawing.Size(252, 21)
        Me.txt_FileName.TabIndex = 28
        '
        'txt_Des
        '
        Me.txt_Des.BackColor = System.Drawing.Color.White
        Me.txt_Des.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.txt_Des.ForeColor = System.Drawing.Color.DimGray
        Me.txt_Des.Location = New System.Drawing.Point(128, 284)
        Me.txt_Des.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txt_Des.Multiline = True
        Me.txt_Des.Name = "txt_Des"
        Me.txt_Des.ReadOnly = True
        Me.txt_Des.Size = New System.Drawing.Size(681, 271)
        Me.txt_Des.TabIndex = 27
        '
        'cb_Step
        '
        Me.cb_Step.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cb_Step.ForeColor = System.Drawing.Color.DimGray
        Me.cb_Step.FormattingEnabled = True
        Me.cb_Step.Location = New System.Drawing.Point(104, 77)
        Me.cb_Step.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cb_Step.Name = "cb_Step"
        Me.cb_Step.Size = New System.Drawing.Size(185, 20)
        Me.cb_Step.TabIndex = 24
        '
        'cb_Target
        '
        Me.cb_Target.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cb_Target.ForeColor = System.Drawing.Color.DimGray
        Me.cb_Target.FormattingEnabled = True
        Me.cb_Target.Location = New System.Drawing.Point(104, 36)
        Me.cb_Target.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cb_Target.Name = "cb_Target"
        Me.cb_Target.Size = New System.Drawing.Size(185, 20)
        Me.cb_Target.TabIndex = 25
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.DimGray
        Me.Label5.Location = New System.Drawing.Point(18, 167)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(65, 15)
        Me.Label5.TabIndex = 19
        Me.Label5.Text = "File Name"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.DimGray
        Me.Label7.Location = New System.Drawing.Point(381, 38)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(39, 15)
        Me.Label7.TabIndex = 20
        Me.Label7.Text = "Title :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.DimGray
        Me.Label4.Location = New System.Drawing.Point(19, 284)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(80, 15)
        Me.Label4.TabIndex = 21
        Me.Label4.Text = "Description :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.DimGray
        Me.Label3.Location = New System.Drawing.Point(43, 78)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(38, 15)
        Me.Label3.TabIndex = 22
        Me.Label3.Text = "단계 :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.DimGray
        Me.Label2.Location = New System.Drawing.Point(43, 38)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(42, 15)
        Me.Label2.TabIndex = 23
        Me.Label2.Text = "대상 : "
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Malgun Gothic", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.DimGray
        Me.Label1.Location = New System.Drawing.Point(292, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(209, 37)
        Me.Label1.TabIndex = 18
        Me.Label1.Text = "교육 자료 공유 "
        '
        'lst_Title
        '
        Me.lst_Title.FormattingEnabled = True
        Me.lst_Title.ItemHeight = 12
        Me.lst_Title.Location = New System.Drawing.Point(458, 41)
        Me.lst_Title.Name = "lst_Title"
        Me.lst_Title.Size = New System.Drawing.Size(329, 148)
        Me.lst_Title.TabIndex = 32
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lst_Title)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.btn_Open)
        Me.GroupBox1.Controls.Add(Me.txt_FileName)
        Me.GroupBox1.Controls.Add(Me.cb_Step)
        Me.GroupBox1.Controls.Add(Me.cb_Target)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Location = New System.Drawing.Point(16, 72)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(793, 205)
        Me.GroupBox1.TabIndex = 33
        Me.GroupBox1.TabStop = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.DimGray
        Me.Label8.Location = New System.Drawing.Point(25, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(238, 15)
        Me.Label8.TabIndex = 30
        Me.Label8.Text = "[List 를 선택하여 원하는 것을 찾아보세요.]"
        '
        'PictureBox1
        '

        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.Location = New System.Drawing.Point(12, 9)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(200, 25)
        Me.PictureBox1.TabIndex = 52
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
        Me.requestBtn.Location = New System.Drawing.Point(748, 13)
        Me.requestBtn.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.requestBtn.Name = "requestBtn"
        Me.requestBtn.Size = New System.Drawing.Size(61, 53)
        Me.requestBtn.TabIndex = 142
        Me.requestBtn.Text = "제안하기"
        Me.requestBtn.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.requestBtn.UseVisualStyleBackColor = False
        '
        'Study_Contents
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(825, 562)
        Me.Controls.Add(Me.requestBtn)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.txt_Des)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label1)
        Me.Name = "Study_Contents"
        Me.Text = "Study_Contents"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label6 As Windows.Forms.Label
    Friend WithEvents btn_Open As Windows.Forms.Button
    Friend WithEvents txt_FileName As Windows.Forms.TextBox
    Friend WithEvents txt_Des As Windows.Forms.TextBox
    Friend WithEvents cb_Step As Windows.Forms.ComboBox
    Friend WithEvents cb_Target As Windows.Forms.ComboBox
    Friend WithEvents Label5 As Windows.Forms.Label
    Friend WithEvents Label7 As Windows.Forms.Label
    Friend WithEvents Label4 As Windows.Forms.Label
    Friend WithEvents Label3 As Windows.Forms.Label
    Friend WithEvents Label2 As Windows.Forms.Label
    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents lst_Title As Windows.Forms.ListBox
    Friend WithEvents GroupBox1 As Windows.Forms.GroupBox
    Friend WithEvents Label8 As Windows.Forms.Label
    Friend WithEvents PictureBox1 As Windows.Forms.PictureBox
    Friend WithEvents requestBtn As Windows.Forms.Button
End Class
