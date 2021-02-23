<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Term_Admin_GM
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Term_Admin_GM))
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.btnDel = New System.Windows.Forms.Button()
        Me.btnMod = New System.Windows.Forms.Button()
        Me.cbStatus = New System.Windows.Forms.ComboBox()
        Me.txtDes = New System.Windows.Forms.TextBox()
        Me.txtWord = New System.Windows.Forms.TextBox()
        Me.lbWord = New System.Windows.Forms.Label()
        Me.lbDesreq = New System.Windows.Forms.Label()
        Me.lbManager = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.lbRequester = New System.Windows.Forms.Label()
        Me.txtRequester = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cbManager = New System.Windows.Forms.ComboBox()
        Me.txtUser = New System.Windows.Forms.Label()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.txtWord_T2 = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.btSearch_T2 = New System.Windows.Forms.Button()
        Me.txtDivision_T2 = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtDes_T2 = New System.Windows.Forms.TextBox()
        Me.btModify = New System.Windows.Forms.Button()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btAdd = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btDelete = New System.Windows.Forms.Button()
        Me.txtAddWord = New System.Windows.Forms.TextBox()
        Me.txtAddDiv = New System.Windows.Forms.TextBox()
        Me.cbAddComp = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtAddDes = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cbDivision = New System.Windows.Forms.ComboBox()
        Me.gridDictionary = New System.Windows.Forms.DataGridView()
        Me.btRefresh = New System.Windows.Forms.Button()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.gridDictionary, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonFace
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(6, 45)
        Me.DataGridView1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowTemplate.Height = 23
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(1018, 270)
        Me.DataGridView1.TabIndex = 113
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.White
        Me.Button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.ForeColor = System.Drawing.Color.DimGray
        Me.Button3.Location = New System.Drawing.Point(130, 7)
        Me.Button3.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(75, 30)
        Me.Button3.TabIndex = 112
        Me.Button3.Text = "Refresh"
        Me.Button3.UseVisualStyleBackColor = False
        '
        'btnDel
        '
        Me.btnDel.BackColor = System.Drawing.Color.White
        Me.btnDel.Font = New System.Drawing.Font("맑은 고딕", 9.0!)
        Me.btnDel.Location = New System.Drawing.Point(419, 190)
        Me.btnDel.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnDel.Name = "btnDel"
        Me.btnDel.Size = New System.Drawing.Size(75, 23)
        Me.btnDel.TabIndex = 111
        Me.btnDel.Text = "삭제"
        Me.btnDel.UseVisualStyleBackColor = False
        '
        'btnMod
        '
        Me.btnMod.BackColor = System.Drawing.Color.White
        Me.btnMod.Font = New System.Drawing.Font("맑은 고딕", 9.0!)
        Me.btnMod.Location = New System.Drawing.Point(338, 190)
        Me.btnMod.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnMod.Name = "btnMod"
        Me.btnMod.Size = New System.Drawing.Size(75, 23)
        Me.btnMod.TabIndex = 110
        Me.btnMod.Text = "수정"
        Me.btnMod.UseVisualStyleBackColor = False
        '
        'cbStatus
        '
        Me.cbStatus.FormattingEnabled = True
        Me.cbStatus.Location = New System.Drawing.Point(379, 57)
        Me.cbStatus.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cbStatus.Name = "cbStatus"
        Me.cbStatus.Size = New System.Drawing.Size(114, 21)
        Me.cbStatus.TabIndex = 108
        Me.cbStatus.Tag = "상태"
        '
        'txtDes
        '
        Me.txtDes.Location = New System.Drawing.Point(15, 109)
        Me.txtDes.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtDes.Multiline = True
        Me.txtDes.Name = "txtDes"
        Me.txtDes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtDes.Size = New System.Drawing.Size(479, 73)
        Me.txtDes.TabIndex = 109
        Me.txtDes.Tag = "용어설명"
        '
        'txtWord
        '
        Me.txtWord.Location = New System.Drawing.Point(58, 57)
        Me.txtWord.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtWord.Multiline = True
        Me.txtWord.Name = "txtWord"
        Me.txtWord.Size = New System.Drawing.Size(114, 20)
        Me.txtWord.TabIndex = 104
        Me.txtWord.Tag = "용어"
        '
        'lbWord
        '
        Me.lbWord.AutoSize = True
        Me.lbWord.Font = New System.Drawing.Font("맑은 고딕", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.lbWord.ForeColor = System.Drawing.Color.Gray
        Me.lbWord.Location = New System.Drawing.Point(12, 60)
        Me.lbWord.Name = "lbWord"
        Me.lbWord.Size = New System.Drawing.Size(29, 13)
        Me.lbWord.TabIndex = 103
        Me.lbWord.Text = "용어"
        '
        'lbDesreq
        '
        Me.lbDesreq.AutoSize = True
        Me.lbDesreq.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.lbDesreq.ForeColor = System.Drawing.Color.Gray
        Me.lbDesreq.Location = New System.Drawing.Point(12, 90)
        Me.lbDesreq.Name = "lbDesreq"
        Me.lbDesreq.Size = New System.Drawing.Size(55, 15)
        Me.lbDesreq.TabIndex = 101
        Me.lbDesreq.Text = "요청내용"
        '
        'lbManager
        '
        Me.lbManager.AutoSize = True
        Me.lbManager.Font = New System.Drawing.Font("맑은 고딕", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.lbManager.ForeColor = System.Drawing.Color.Gray
        Me.lbManager.Location = New System.Drawing.Point(178, 60)
        Me.lbManager.Name = "lbManager"
        Me.lbManager.Size = New System.Drawing.Size(40, 13)
        Me.lbManager.TabIndex = 102
        Me.lbManager.Text = "담당자"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("맑은 고딕", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Gray
        Me.Label3.Location = New System.Drawing.Point(344, 60)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(29, 13)
        Me.Label3.TabIndex = 98
        Me.Label3.Text = "상태"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(6, 7)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(118, 30)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 97
        Me.PictureBox1.TabStop = False
        '
        'lbRequester
        '
        Me.lbRequester.AutoSize = True
        Me.lbRequester.Font = New System.Drawing.Font("맑은 고딕", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.lbRequester.ForeColor = System.Drawing.Color.Gray
        Me.lbRequester.Location = New System.Drawing.Point(12, 28)
        Me.lbRequester.Name = "lbRequester"
        Me.lbRequester.Size = New System.Drawing.Size(40, 13)
        Me.lbRequester.TabIndex = 103
        Me.lbRequester.Text = "요청자"
        '
        'txtRequester
        '
        Me.txtRequester.Location = New System.Drawing.Point(58, 25)
        Me.txtRequester.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtRequester.Multiline = True
        Me.txtRequester.Name = "txtRequester"
        Me.txtRequester.Size = New System.Drawing.Size(114, 20)
        Me.txtRequester.TabIndex = 104
        Me.txtRequester.Tag = "업체명"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cbManager)
        Me.GroupBox1.Controls.Add(Me.lbWord)
        Me.GroupBox1.Controls.Add(Me.lbRequester)
        Me.GroupBox1.Controls.Add(Me.btnDel)
        Me.GroupBox1.Controls.Add(Me.txtWord)
        Me.GroupBox1.Controls.Add(Me.txtRequester)
        Me.GroupBox1.Controls.Add(Me.btnMod)
        Me.GroupBox1.Controls.Add(Me.lbManager)
        Me.GroupBox1.Controls.Add(Me.cbStatus)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtDes)
        Me.GroupBox1.Controls.Add(Me.lbDesreq)
        Me.GroupBox1.Font = New System.Drawing.Font("맑은 고딕", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.GroupBox1.Location = New System.Drawing.Point(521, 322)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(503, 227)
        Me.GroupBox1.TabIndex = 114
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "요청사항"
        '
        'cbManager
        '
        Me.cbManager.FormattingEnabled = True
        Me.cbManager.Location = New System.Drawing.Point(224, 57)
        Me.cbManager.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cbManager.Name = "cbManager"
        Me.cbManager.Size = New System.Drawing.Size(114, 21)
        Me.cbManager.TabIndex = 110
        Me.cbManager.Tag = "상태"
        '
        'txtUser
        '
        Me.txtUser.AutoSize = True
        Me.txtUser.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.txtUser.ForeColor = System.Drawing.Color.Gray
        Me.txtUser.Location = New System.Drawing.Point(269, 22)
        Me.txtUser.Name = "txtUser"
        Me.txtUser.Size = New System.Drawing.Size(30, 15)
        Me.txtUser.TabIndex = 115
        Me.txtUser.Text = "User"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1044, 583)
        Me.TabControl1.TabIndex = 116
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.Button3)
        Me.TabPage1.Controls.Add(Me.txtUser)
        Me.TabPage1.Controls.Add(Me.PictureBox1)
        Me.TabPage1.Controls.Add(Me.GroupBox1)
        Me.TabPage1.Controls.Add(Me.DataGridView1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1036, 557)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Dictionary"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("굴림", 12.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Firebrick
        Me.Label2.Location = New System.Drawing.Point(6, 332)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(509, 217)
        Me.Label2.TabIndex = 116
        Me.Label2.Text = "1. Dictionary 요청내역 Page 입니다" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "2. 현재 Page에서는 요청내역 수정 삭제만 가능합니다" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "3 .신기능 및 용어 추가/" &
    "삭제 는 Manage Tab 에서 가능합니다"
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.GroupBox3)
        Me.TabPage2.Controls.Add(Me.GroupBox2)
        Me.TabPage2.Controls.Add(Me.Label1)
        Me.TabPage2.Controls.Add(Me.cbDivision)
        Me.TabPage2.Controls.Add(Me.gridDictionary)
        Me.TabPage2.Controls.Add(Me.btRefresh)
        Me.TabPage2.Controls.Add(Me.PictureBox2)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(1036, 557)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Manage"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.txtWord_T2)
        Me.GroupBox3.Controls.Add(Me.Label9)
        Me.GroupBox3.Controls.Add(Me.btSearch_T2)
        Me.GroupBox3.Controls.Add(Me.txtDivision_T2)
        Me.GroupBox3.Controls.Add(Me.Label11)
        Me.GroupBox3.Controls.Add(Me.txtDes_T2)
        Me.GroupBox3.Controls.Add(Me.btModify)
        Me.GroupBox3.Controls.Add(Me.Label13)
        Me.GroupBox3.Font = New System.Drawing.Font("맑은 고딕", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.GroupBox3.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.GroupBox3.Location = New System.Drawing.Point(6, 322)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(503, 227)
        Me.GroupBox3.TabIndex = 119
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "검색"
        '
        'txtWord_T2
        '
        Me.txtWord_T2.Location = New System.Drawing.Point(225, 25)
        Me.txtWord_T2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtWord_T2.Multiline = True
        Me.txtWord_T2.Name = "txtWord_T2"
        Me.txtWord_T2.Size = New System.Drawing.Size(114, 20)
        Me.txtWord_T2.TabIndex = 112
        Me.txtWord_T2.Tag = "용어"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("맑은 고딕", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Gray
        Me.Label9.Location = New System.Drawing.Point(12, 28)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(40, 13)
        Me.Label9.TabIndex = 103
        Me.Label9.Text = "대분류"
        '
        'btSearch_T2
        '
        Me.btSearch_T2.BackColor = System.Drawing.Color.White
        Me.btSearch_T2.Font = New System.Drawing.Font("맑은 고딕", 9.0!)
        Me.btSearch_T2.Location = New System.Drawing.Point(338, 190)
        Me.btSearch_T2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btSearch_T2.Name = "btSearch_T2"
        Me.btSearch_T2.Size = New System.Drawing.Size(75, 23)
        Me.btSearch_T2.TabIndex = 111
        Me.btSearch_T2.Text = "검색"
        Me.btSearch_T2.UseVisualStyleBackColor = False
        '
        'txtDivision_T2
        '
        Me.txtDivision_T2.Location = New System.Drawing.Point(58, 25)
        Me.txtDivision_T2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtDivision_T2.Multiline = True
        Me.txtDivision_T2.Name = "txtDivision_T2"
        Me.txtDivision_T2.Size = New System.Drawing.Size(114, 20)
        Me.txtDivision_T2.TabIndex = 104
        Me.txtDivision_T2.Tag = ""
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("맑은 고딕", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Gray
        Me.Label11.Location = New System.Drawing.Point(190, 28)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(29, 13)
        Me.Label11.TabIndex = 102
        Me.Label11.Text = "용어"
        '
        'txtDes_T2
        '
        Me.txtDes_T2.Location = New System.Drawing.Point(15, 82)
        Me.txtDes_T2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtDes_T2.Multiline = True
        Me.txtDes_T2.Name = "txtDes_T2"
        Me.txtDes_T2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtDes_T2.Size = New System.Drawing.Size(479, 100)
        Me.txtDes_T2.TabIndex = 109
        Me.txtDes_T2.Tag = "용어설명"
        '
        'btModify
        '
        Me.btModify.BackColor = System.Drawing.Color.White
        Me.btModify.Font = New System.Drawing.Font("맑은 고딕", 9.0!)
        Me.btModify.Location = New System.Drawing.Point(419, 190)
        Me.btModify.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btModify.Name = "btModify"
        Me.btModify.Size = New System.Drawing.Size(75, 23)
        Me.btModify.TabIndex = 110
        Me.btModify.Text = "수정"
        Me.btModify.UseVisualStyleBackColor = False
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Gray
        Me.Label13.Location = New System.Drawing.Point(12, 63)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(31, 15)
        Me.Label13.TabIndex = 101
        Me.Label13.Text = "설명"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btAdd)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.btDelete)
        Me.GroupBox2.Controls.Add(Me.txtAddWord)
        Me.GroupBox2.Controls.Add(Me.txtAddDiv)
        Me.GroupBox2.Controls.Add(Me.cbAddComp)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.txtAddDes)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Font = New System.Drawing.Font("맑은 고딕", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.GroupBox2.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.GroupBox2.Location = New System.Drawing.Point(521, 322)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(503, 227)
        Me.GroupBox2.TabIndex = 118
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "추가 및 삭제"
        '
        'btAdd
        '
        Me.btAdd.BackColor = System.Drawing.Color.White
        Me.btAdd.Font = New System.Drawing.Font("맑은 고딕", 9.0!)
        Me.btAdd.Location = New System.Drawing.Point(337, 190)
        Me.btAdd.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btAdd.Name = "btAdd"
        Me.btAdd.Size = New System.Drawing.Size(75, 23)
        Me.btAdd.TabIndex = 1004
        Me.btAdd.Text = "추가"
        Me.btAdd.UseVisualStyleBackColor = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("맑은 고딕", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Gray
        Me.Label4.Location = New System.Drawing.Point(180, 28)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(29, 13)
        Me.Label4.TabIndex = 103
        Me.Label4.Text = "용어"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("맑은 고딕", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Gray
        Me.Label5.Location = New System.Drawing.Point(12, 28)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(40, 13)
        Me.Label5.TabIndex = 103
        Me.Label5.Text = "대분류"
        '
        'btDelete
        '
        Me.btDelete.BackColor = System.Drawing.Color.White
        Me.btDelete.Font = New System.Drawing.Font("맑은 고딕", 9.0!)
        Me.btDelete.Location = New System.Drawing.Point(419, 190)
        Me.btDelete.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btDelete.Name = "btDelete"
        Me.btDelete.Size = New System.Drawing.Size(75, 23)
        Me.btDelete.TabIndex = 1005
        Me.btDelete.Text = "삭제"
        Me.btDelete.UseVisualStyleBackColor = False
        '
        'txtAddWord
        '
        Me.txtAddWord.Location = New System.Drawing.Point(215, 25)
        Me.txtAddWord.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtAddWord.Multiline = True
        Me.txtAddWord.Name = "txtAddWord"
        Me.txtAddWord.Size = New System.Drawing.Size(114, 20)
        Me.txtAddWord.TabIndex = 1001
        Me.txtAddWord.Tag = "용어"
        '
        'txtAddDiv
        '
        Me.txtAddDiv.Location = New System.Drawing.Point(58, 25)
        Me.txtAddDiv.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtAddDiv.Multiline = True
        Me.txtAddDiv.Name = "txtAddDiv"
        Me.txtAddDiv.Size = New System.Drawing.Size(114, 20)
        Me.txtAddDiv.TabIndex = 1000
        Me.txtAddDiv.Tag = "업체명"
        '
        'cbAddComp
        '
        Me.cbAddComp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbAddComp.FormattingEnabled = True
        Me.cbAddComp.Location = New System.Drawing.Point(380, 25)
        Me.cbAddComp.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cbAddComp.Name = "cbAddComp"
        Me.cbAddComp.Size = New System.Drawing.Size(114, 21)
        Me.cbAddComp.TabIndex = 1002
        Me.cbAddComp.Tag = "상태"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("맑은 고딕", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Gray
        Me.Label7.Location = New System.Drawing.Point(334, 28)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(40, 13)
        Me.Label7.TabIndex = 98
        Me.Label7.Text = "업체명"
        '
        'txtAddDes
        '
        Me.txtAddDes.Location = New System.Drawing.Point(15, 82)
        Me.txtAddDes.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtAddDes.Multiline = True
        Me.txtAddDes.Name = "txtAddDes"
        Me.txtAddDes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtAddDes.Size = New System.Drawing.Size(479, 100)
        Me.txtAddDes.TabIndex = 1003
        Me.txtAddDes.Tag = "용어설명"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Gray
        Me.Label8.Location = New System.Drawing.Point(12, 63)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(31, 15)
        Me.Label8.TabIndex = 101
        Me.Label8.Text = "설명"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Gray
        Me.Label1.Location = New System.Drawing.Point(818, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 15)
        Me.Label1.TabIndex = 116
        Me.Label1.Text = "대분류"
        '
        'cbDivision
        '
        Me.cbDivision.FormattingEnabled = True
        Me.cbDivision.Location = New System.Drawing.Point(867, 17)
        Me.cbDivision.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cbDivision.Name = "cbDivision"
        Me.cbDivision.Size = New System.Drawing.Size(157, 20)
        Me.cbDivision.TabIndex = 117
        Me.cbDivision.Tag = ""
        '
        'gridDictionary
        '
        Me.gridDictionary.AllowUserToAddRows = False
        Me.gridDictionary.AllowUserToDeleteRows = False
        Me.gridDictionary.BackgroundColor = System.Drawing.SystemColors.ButtonFace
        Me.gridDictionary.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridDictionary.Location = New System.Drawing.Point(6, 45)
        Me.gridDictionary.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.gridDictionary.Name = "gridDictionary"
        Me.gridDictionary.ReadOnly = True
        Me.gridDictionary.RowTemplate.Height = 23
        Me.gridDictionary.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gridDictionary.Size = New System.Drawing.Size(1018, 270)
        Me.gridDictionary.TabIndex = 115
        '
        'btRefresh
        '
        Me.btRefresh.BackColor = System.Drawing.Color.White
        Me.btRefresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btRefresh.ForeColor = System.Drawing.Color.DimGray
        Me.btRefresh.Location = New System.Drawing.Point(130, 7)
        Me.btRefresh.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btRefresh.Name = "btRefresh"
        Me.btRefresh.Size = New System.Drawing.Size(75, 30)
        Me.btRefresh.TabIndex = 114
        Me.btRefresh.Text = "Refresh"
        Me.btRefresh.UseVisualStyleBackColor = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(6, 7)
        Me.PictureBox2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(118, 30)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 113
        Me.PictureBox2.TabStop = False
        '
        'Term_Admin_GM
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1044, 583)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "Term_Admin_GM"
        Me.Text = "Term_Admin_GM"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.gridDictionary, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents DataGridView1 As Windows.Forms.DataGridView
    Friend WithEvents Button3 As Windows.Forms.Button
    Friend WithEvents btnDel As Windows.Forms.Button
    Friend WithEvents btnMod As Windows.Forms.Button
    Friend WithEvents cbStatus As Windows.Forms.ComboBox
    Friend WithEvents txtDes As Windows.Forms.TextBox
    Friend WithEvents txtWord As Windows.Forms.TextBox
    Friend WithEvents lbWord As Windows.Forms.Label
    Friend WithEvents lbDesreq As Windows.Forms.Label
    Friend WithEvents lbManager As Windows.Forms.Label
    Friend WithEvents Label3 As Windows.Forms.Label
    Friend WithEvents PictureBox1 As Windows.Forms.PictureBox
    Friend WithEvents lbRequester As Windows.Forms.Label
    Friend WithEvents txtRequester As Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As Windows.Forms.GroupBox
    Friend WithEvents cbManager As Windows.Forms.ComboBox
    Friend WithEvents txtUser As Windows.Forms.Label
    Friend WithEvents TabControl1 As Windows.Forms.TabControl
    Friend WithEvents TabPage1 As Windows.Forms.TabPage
    Friend WithEvents TabPage2 As Windows.Forms.TabPage
    Friend WithEvents Label2 As Windows.Forms.Label
    Friend WithEvents GroupBox2 As Windows.Forms.GroupBox
    Friend WithEvents Label4 As Windows.Forms.Label
    Friend WithEvents Label5 As Windows.Forms.Label
    Friend WithEvents btDelete As Windows.Forms.Button
    Friend WithEvents txtAddWord As Windows.Forms.TextBox
    Friend WithEvents txtAddDiv As Windows.Forms.TextBox
    Friend WithEvents btModify As Windows.Forms.Button
    Friend WithEvents cbAddComp As Windows.Forms.ComboBox
    Friend WithEvents Label7 As Windows.Forms.Label
    Friend WithEvents txtAddDes As Windows.Forms.TextBox
    Friend WithEvents Label8 As Windows.Forms.Label
    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents cbDivision As Windows.Forms.ComboBox
    Friend WithEvents gridDictionary As Windows.Forms.DataGridView
    Friend WithEvents btRefresh As Windows.Forms.Button
    Friend WithEvents PictureBox2 As Windows.Forms.PictureBox
    Friend WithEvents GroupBox3 As Windows.Forms.GroupBox
    Friend WithEvents Label9 As Windows.Forms.Label
    Friend WithEvents btSearch_T2 As Windows.Forms.Button
    Friend WithEvents txtDivision_T2 As Windows.Forms.TextBox
    Friend WithEvents Label11 As Windows.Forms.Label
    Friend WithEvents txtDes_T2 As Windows.Forms.TextBox
    Friend WithEvents Label13 As Windows.Forms.Label
    Friend WithEvents txtWord_T2 As Windows.Forms.TextBox
    Friend WithEvents btAdd As Windows.Forms.Button
End Class
