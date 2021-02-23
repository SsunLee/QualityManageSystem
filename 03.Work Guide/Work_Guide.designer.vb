<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Work_Guide
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Work_Guide))
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.requestBtn = New System.Windows.Forms.Button()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.txtDepth2 = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.FileName = New System.Windows.Forms.TextBox()
        Me.txtDes = New System.Windows.Forms.TextBox()
        Me.lstDep = New System.Windows.Forms.ListBox()
        Me.TestGubunCB = New System.Windows.Forms.ComboBox()
        Me.GubunCB = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.btn_Request_Tab2 = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lst_Title = New System.Windows.Forms.ListBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.btn_Open = New System.Windows.Forms.Button()
        Me.txt_FileName = New System.Windows.Forms.TextBox()
        Me.cb_Step = New System.Windows.Forms.ComboBox()
        Me.cb_Target = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txt_Des = New System.Windows.Forms.TextBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(828, 622)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.White
        Me.TabPage1.Controls.Add(Me.requestBtn)
        Me.TabPage1.Controls.Add(Me.PictureBox2)
        Me.TabPage1.Controls.Add(Me.txtDepth2)
        Me.TabPage1.Controls.Add(Me.Label6)
        Me.TabPage1.Controls.Add(Me.Button2)
        Me.TabPage1.Controls.Add(Me.FileName)
        Me.TabPage1.Controls.Add(Me.txtDes)
        Me.TabPage1.Controls.Add(Me.lstDep)
        Me.TabPage1.Controls.Add(Me.TestGubunCB)
        Me.TabPage1.Controls.Add(Me.GubunCB)
        Me.TabPage1.Controls.Add(Me.Label5)
        Me.TabPage1.Controls.Add(Me.Label7)
        Me.TabPage1.Controls.Add(Me.Label4)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.ForeColor = System.Drawing.Color.White
        Me.TabPage1.Location = New System.Drawing.Point(4, 24)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(820, 594)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "검증가이드"
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
        Me.requestBtn.Location = New System.Drawing.Point(737, 16)
        Me.requestBtn.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.requestBtn.Name = "requestBtn"
        Me.requestBtn.Size = New System.Drawing.Size(75, 57)
        Me.requestBtn.TabIndex = 159
        Me.requestBtn.Text = "제안하기"
        Me.requestBtn.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.requestBtn.UseVisualStyleBackColor = False
        '
        'PictureBox2
        '
        Me.PictureBox2.BackgroundImage = CType(resources.GetObject("PictureBox2.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox2.Location = New System.Drawing.Point(8, 6)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(216, 25)
        Me.PictureBox2.TabIndex = 158
        Me.PictureBox2.TabStop = False
        '
        'txtDepth2
        '
        Me.txtDepth2.BackColor = System.Drawing.Color.White
        Me.txtDepth2.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.txtDepth2.ForeColor = System.Drawing.Color.DimGray
        Me.txtDepth2.Location = New System.Drawing.Point(102, 178)
        Me.txtDepth2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtDepth2.Multiline = True
        Me.txtDepth2.Name = "txtDepth2"
        Me.txtDepth2.ReadOnly = True
        Me.txtDepth2.Size = New System.Drawing.Size(223, 26)
        Me.txtDepth2.TabIndex = 157
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.DimGray
        Me.Label6.Location = New System.Drawing.Point(282, 108)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(335, 45)
        Me.Label6.TabIndex = 156
        Me.Label6.Text = "1) 검증원 / 모델리더 의 업무를 선택해서 가이드 볼 수 있음." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "2) 검증 전 / 검증 중 / 검증 후에 해야할 일을 선택할 수 있음." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "3)" &
    " 자세한 가이드를 파일로 열어서 확인할 수 있음."
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Button2.ForeColor = System.Drawing.Color.White
        Me.Button2.Location = New System.Drawing.Point(729, 175)
        Me.Button2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 29)
        Me.Button2.TabIndex = 155
        Me.Button2.Text = "파일 열기"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'FileName
        '
        Me.FileName.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.FileName.ForeColor = System.Drawing.Color.DimGray
        Me.FileName.Location = New System.Drawing.Point(421, 179)
        Me.FileName.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.FileName.Name = "FileName"
        Me.FileName.ReadOnly = True
        Me.FileName.Size = New System.Drawing.Size(302, 23)
        Me.FileName.TabIndex = 154
        '
        'txtDes
        '
        Me.txtDes.BackColor = System.Drawing.Color.White
        Me.txtDes.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.txtDes.ForeColor = System.Drawing.Color.DimGray
        Me.txtDes.Location = New System.Drawing.Point(331, 218)
        Me.txtDes.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtDes.Multiline = True
        Me.txtDes.Name = "txtDes"
        Me.txtDes.ReadOnly = True
        Me.txtDes.Size = New System.Drawing.Size(473, 351)
        Me.txtDes.TabIndex = 153
        '
        'lstDep
        '
        Me.lstDep.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.lstDep.ForeColor = System.Drawing.Color.DimGray
        Me.lstDep.FormattingEnabled = True
        Me.lstDep.HorizontalScrollbar = True
        Me.lstDep.ItemHeight = 15
        Me.lstDep.Location = New System.Drawing.Point(102, 218)
        Me.lstDep.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.lstDep.Name = "lstDep"
        Me.lstDep.Size = New System.Drawing.Size(223, 349)
        Me.lstDep.TabIndex = 152
        '
        'TestGubunCB
        '
        Me.TestGubunCB.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TestGubunCB.ForeColor = System.Drawing.Color.DimGray
        Me.TestGubunCB.FormattingEnabled = True
        Me.TestGubunCB.Location = New System.Drawing.Point(102, 136)
        Me.TestGubunCB.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TestGubunCB.Name = "TestGubunCB"
        Me.TestGubunCB.Size = New System.Drawing.Size(141, 23)
        Me.TestGubunCB.TabIndex = 150
        '
        'GubunCB
        '
        Me.GubunCB.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GubunCB.ForeColor = System.Drawing.Color.DimGray
        Me.GubunCB.FormattingEnabled = True
        Me.GubunCB.Location = New System.Drawing.Point(102, 96)
        Me.GubunCB.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GubunCB.Name = "GubunCB"
        Me.GubunCB.Size = New System.Drawing.Size(141, 23)
        Me.GubunCB.TabIndex = 151
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.DimGray
        Me.Label5.Location = New System.Drawing.Point(350, 183)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(65, 15)
        Me.Label5.TabIndex = 145
        Me.Label5.Text = "File Name"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.DimGray
        Me.Label7.Location = New System.Drawing.Point(2, 183)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(94, 15)
        Me.Label7.TabIndex = 146
        Me.Label7.Text = "상세 검증 구분 :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.DimGray
        Me.Label4.Location = New System.Drawing.Point(30, 221)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(66, 15)
        Me.Label4.TabIndex = 147
        Me.Label4.Text = "상세 분류 :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.DimGray
        Me.Label3.Location = New System.Drawing.Point(30, 138)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(66, 15)
        Me.Label3.TabIndex = 148
        Me.Label3.Text = "검증 구분 :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.DimGray
        Me.Label2.Location = New System.Drawing.Point(54, 98)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(42, 15)
        Me.Label2.TabIndex = 149
        Me.Label2.Text = "구분 : "
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("맑은 고딕", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.DimGray
        Me.Label1.Location = New System.Drawing.Point(280, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(191, 25)
        Me.Label1.TabIndex = 144
        Me.Label1.Text = "검증정보_업무가이드"
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.Color.White
        Me.TabPage2.Controls.Add(Me.btn_Request_Tab2)
        Me.TabPage2.Controls.Add(Me.GroupBox1)
        Me.TabPage2.Controls.Add(Me.txt_Des)
        Me.TabPage2.Controls.Add(Me.PictureBox1)
        Me.TabPage2.Controls.Add(Me.Label14)
        Me.TabPage2.Controls.Add(Me.Label15)
        Me.TabPage2.ForeColor = System.Drawing.Color.White
        Me.TabPage2.Location = New System.Drawing.Point(4, 24)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(820, 594)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "교육 자료"
        '
        'btn_Request_Tab2
        '
        Me.btn_Request_Tab2.BackColor = System.Drawing.Color.Transparent
        Me.btn_Request_Tab2.BackgroundImage = CType(resources.GetObject("btn_Request_Tab2.BackgroundImage"), System.Drawing.Image)
        Me.btn_Request_Tab2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btn_Request_Tab2.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.btn_Request_Tab2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Request_Tab2.Font = New System.Drawing.Font("맑은 고딕", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.btn_Request_Tab2.ForeColor = System.Drawing.Color.Black
        Me.btn_Request_Tab2.Location = New System.Drawing.Point(748, 28)
        Me.btn_Request_Tab2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btn_Request_Tab2.Name = "btn_Request_Tab2"
        Me.btn_Request_Tab2.Size = New System.Drawing.Size(61, 53)
        Me.btn_Request_Tab2.TabIndex = 148
        Me.btn_Request_Tab2.Text = "제안하기"
        Me.btn_Request_Tab2.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_Request_Tab2.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lst_Title)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.btn_Open)
        Me.GroupBox1.Controls.Add(Me.txt_FileName)
        Me.GroupBox1.Controls.Add(Me.cb_Step)
        Me.GroupBox1.Controls.Add(Me.cb_Target)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Location = New System.Drawing.Point(16, 87)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(793, 205)
        Me.GroupBox1.TabIndex = 146
        Me.GroupBox1.TabStop = False
        '
        'lst_Title
        '
        Me.lst_Title.FormattingEnabled = True
        Me.lst_Title.ItemHeight = 15
        Me.lst_Title.Location = New System.Drawing.Point(458, 41)
        Me.lst_Title.Name = "lst_Title"
        Me.lst_Title.Size = New System.Drawing.Size(329, 139)
        Me.lst_Title.TabIndex = 32
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.DimGray
        Me.Label8.Location = New System.Drawing.Point(25, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(238, 15)
        Me.Label8.TabIndex = 30
        Me.Label8.Text = "[List 를 선택하여 원하는 것을 찾아보세요.]"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.DimGray
        Me.Label9.Location = New System.Drawing.Point(70, 130)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(264, 15)
        Me.Label9.TabIndex = 30
        Me.Label9.Text = "※ 교육 자료를 List 를 통해 확인할 수 있습니다."
        '
        'btn_Open
        '
        Me.btn_Open.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btn_Open.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Open.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
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
        Me.txt_FileName.Size = New System.Drawing.Size(252, 23)
        Me.txt_FileName.TabIndex = 28
        '
        'cb_Step
        '
        Me.cb_Step.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cb_Step.ForeColor = System.Drawing.Color.DimGray
        Me.cb_Step.FormattingEnabled = True
        Me.cb_Step.Location = New System.Drawing.Point(104, 77)
        Me.cb_Step.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cb_Step.Name = "cb_Step"
        Me.cb_Step.Size = New System.Drawing.Size(185, 23)
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
        Me.cb_Target.Size = New System.Drawing.Size(185, 23)
        Me.cb_Target.TabIndex = 25
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.DimGray
        Me.Label10.Location = New System.Drawing.Point(18, 167)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(65, 15)
        Me.Label10.TabIndex = 19
        Me.Label10.Text = "File Name"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.DimGray
        Me.Label11.Location = New System.Drawing.Point(381, 38)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(39, 15)
        Me.Label11.TabIndex = 20
        Me.Label11.Text = "Title :"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.DimGray
        Me.Label12.Location = New System.Drawing.Point(43, 78)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(38, 15)
        Me.Label12.TabIndex = 22
        Me.Label12.Text = "단계 :"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.DimGray
        Me.Label13.Location = New System.Drawing.Point(43, 38)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(42, 15)
        Me.Label13.TabIndex = 23
        Me.Label13.Text = "대상 : "
        '
        'txt_Des
        '
        Me.txt_Des.BackColor = System.Drawing.Color.White
        Me.txt_Des.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.txt_Des.ForeColor = System.Drawing.Color.DimGray
        Me.txt_Des.Location = New System.Drawing.Point(128, 299)
        Me.txt_Des.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txt_Des.Multiline = True
        Me.txt_Des.Name = "txt_Des"
        Me.txt_Des.ReadOnly = True
        Me.txt_Des.Size = New System.Drawing.Size(681, 271)
        Me.txt_Des.TabIndex = 145
        '
        'PictureBox1
        '

        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.Location = New System.Drawing.Point(12, 24)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(200, 25)
        Me.PictureBox1.TabIndex = 147
        Me.PictureBox1.TabStop = False
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.DimGray
        Me.Label14.Location = New System.Drawing.Point(19, 299)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(80, 15)
        Me.Label14.TabIndex = 144
        Me.Label14.Text = "Description :"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("맑은 고딕", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.DimGray
        Me.Label15.Location = New System.Drawing.Point(292, 24)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(206, 37)
        Me.Label15.TabIndex = 143
        Me.Label15.Text = "교육 자료 공유 "
        '
        'Work_Guide
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(828, 622)
        Me.Controls.Add(Me.TabControl1)
        Me.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.ForeColor = System.Drawing.Color.White
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "Work_Guide"
        Me.Text = "Work_Guide"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TabControl1 As Windows.Forms.TabControl
    Friend WithEvents TabPage1 As Windows.Forms.TabPage
    Friend WithEvents requestBtn As Windows.Forms.Button
    Friend WithEvents PictureBox2 As Windows.Forms.PictureBox
    Friend WithEvents txtDepth2 As Windows.Forms.TextBox
    Friend WithEvents Label6 As Windows.Forms.Label
    Friend WithEvents Button2 As Windows.Forms.Button
    Friend WithEvents FileName As Windows.Forms.TextBox
    Friend WithEvents txtDes As Windows.Forms.TextBox
    Friend WithEvents lstDep As Windows.Forms.ListBox
    Friend WithEvents TestGubunCB As Windows.Forms.ComboBox
    Friend WithEvents GubunCB As Windows.Forms.ComboBox
    Friend WithEvents Label5 As Windows.Forms.Label
    Friend WithEvents Label7 As Windows.Forms.Label
    Friend WithEvents Label4 As Windows.Forms.Label
    Friend WithEvents Label3 As Windows.Forms.Label
    Friend WithEvents Label2 As Windows.Forms.Label
    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents TabPage2 As Windows.Forms.TabPage
    Friend WithEvents btn_Request_Tab2 As Windows.Forms.Button
    Friend WithEvents GroupBox1 As Windows.Forms.GroupBox
    Friend WithEvents lst_Title As Windows.Forms.ListBox
    Friend WithEvents Label8 As Windows.Forms.Label
    Friend WithEvents Label9 As Windows.Forms.Label
    Friend WithEvents btn_Open As Windows.Forms.Button
    Friend WithEvents txt_FileName As Windows.Forms.TextBox
    Friend WithEvents cb_Step As Windows.Forms.ComboBox
    Friend WithEvents cb_Target As Windows.Forms.ComboBox
    Friend WithEvents Label10 As Windows.Forms.Label
    Friend WithEvents Label11 As Windows.Forms.Label
    Friend WithEvents Label12 As Windows.Forms.Label
    Friend WithEvents Label13 As Windows.Forms.Label
    Friend WithEvents txt_Des As Windows.Forms.TextBox
    Friend WithEvents PictureBox1 As Windows.Forms.PictureBox
    Friend WithEvents Label14 As Windows.Forms.Label
    Friend WithEvents Label15 As Windows.Forms.Label
End Class
