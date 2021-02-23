<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class App_Feature
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(App_Feature))
        Me.btRefresh = New System.Windows.Forms.Button()
        Me.gridRequest = New System.Windows.Forms.DataGridView()
        Me.cbStat = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.btSearch = New System.Windows.Forms.Button()
        Me.addDes = New System.Windows.Forms.TextBox()
        Me.cbType = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.btAdd = New System.Windows.Forms.Button()
        Me.addApp = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.addFeat = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cbManager = New System.Windows.Forms.ComboBox()
        Me.btMod = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtDes = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtType = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtFeat = New System.Windows.Forms.TextBox()
        Me.txtApp = New System.Windows.Forms.TextBox()
        Me.TapControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.btModT2 = New System.Windows.Forms.Button()
        Me.btSearchT2 = New System.Windows.Forms.Button()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtDesT2 = New System.Windows.Forms.TextBox()
        Me.cbTypeT2 = New System.Windows.Forms.ComboBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.btDeleteT2 = New System.Windows.Forms.Button()
        Me.btApprefresh = New System.Windows.Forms.Button()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.gridApp = New System.Windows.Forms.DataGridView()
        Me.txtAppT2 = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtFeatT2 = New System.Windows.Forms.TextBox()
        CType(Me.gridRequest, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.TapControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridApp, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btRefresh
        '
        Me.btRefresh.BackColor = System.Drawing.Color.White
        Me.btRefresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btRefresh.ForeColor = System.Drawing.Color.DimGray
        Me.btRefresh.Location = New System.Drawing.Point(132, 10)
        Me.btRefresh.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btRefresh.Name = "btRefresh"
        Me.btRefresh.Size = New System.Drawing.Size(56, 25)
        Me.btRefresh.TabIndex = 78
        Me.btRefresh.Text = "Refresh"
        Me.btRefresh.UseVisualStyleBackColor = False
        '
        'gridRequest
        '
        Me.gridRequest.AllowUserToAddRows = False
        Me.gridRequest.AllowUserToDeleteRows = False
        Me.gridRequest.BackgroundColor = System.Drawing.SystemColors.ButtonFace
        Me.gridRequest.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridRequest.Location = New System.Drawing.Point(8, 43)
        Me.gridRequest.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.gridRequest.Name = "gridRequest"
        Me.gridRequest.ReadOnly = True
        Me.gridRequest.RowTemplate.Height = 23
        Me.gridRequest.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gridRequest.Size = New System.Drawing.Size(1012, 269)
        Me.gridRequest.TabIndex = 82
        '
        'cbStat
        '
        Me.cbStat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbStat.Font = New System.Drawing.Font("맑은 고딕", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.cbStat.FormattingEnabled = True
        Me.cbStat.Location = New System.Drawing.Point(370, 50)
        Me.cbStat.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cbStat.Name = "cbStat"
        Me.cbStat.Size = New System.Drawing.Size(126, 21)
        Me.cbStat.TabIndex = 84
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("맑은 고딕", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Gray
        Me.Label3.Location = New System.Drawing.Point(333, 53)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(29, 13)
        Me.Label3.TabIndex = 83
        Me.Label3.Text = "상태"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("맑은 고딕", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Gray
        Me.Label7.Location = New System.Drawing.Point(123, 53)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(40, 13)
        Me.Label7.TabIndex = 85
        Me.Label7.Text = "담당자"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.btSearch)
        Me.GroupBox3.Controls.Add(Me.addDes)
        Me.GroupBox3.Controls.Add(Me.cbType)
        Me.GroupBox3.Controls.Add(Me.Label8)
        Me.GroupBox3.Controls.Add(Me.Label14)
        Me.GroupBox3.Controls.Add(Me.btAdd)
        Me.GroupBox3.Controls.Add(Me.addApp)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Controls.Add(Me.addFeat)
        Me.GroupBox3.Controls.Add(Me.Label11)
        Me.GroupBox3.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.GroupBox3.Location = New System.Drawing.Point(518, 320)
        Me.GroupBox3.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox3.Size = New System.Drawing.Size(502, 220)
        Me.GroupBox3.TabIndex = 145
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "추가"
        '
        'btSearch
        '
        Me.btSearch.BackColor = System.Drawing.Color.DodgerBlue
        Me.btSearch.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btSearch.Font = New System.Drawing.Font("맑은 고딕", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.btSearch.ForeColor = System.Drawing.Color.White
        Me.btSearch.Location = New System.Drawing.Point(421, 83)
        Me.btSearch.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btSearch.Name = "btSearch"
        Me.btSearch.Size = New System.Drawing.Size(75, 47)
        Me.btSearch.TabIndex = 156
        Me.btSearch.Text = "검색"
        Me.btSearch.UseVisualStyleBackColor = False
        '
        'addDes
        '
        Me.addDes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.addDes.Font = New System.Drawing.Font("맑은 고딕", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.addDes.Location = New System.Drawing.Point(9, 83)
        Me.addDes.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.addDes.Multiline = True
        Me.addDes.Name = "addDes"
        Me.addDes.Size = New System.Drawing.Size(406, 98)
        Me.addDes.TabIndex = 155
        '
        'cbType
        '
        Me.cbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbType.Font = New System.Drawing.Font("맑은 고딕", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.cbType.FormattingEnabled = True
        Me.cbType.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.cbType.Location = New System.Drawing.Point(43, 21)
        Me.cbType.Name = "cbType"
        Me.cbType.Size = New System.Drawing.Size(71, 21)
        Me.cbType.TabIndex = 147
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("맑은 고딕", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Gray
        Me.Label8.Location = New System.Drawing.Point(6, 24)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(31, 13)
        Me.Label8.TabIndex = 146
        Me.Label8.Text = "Type"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("맑은 고딕", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.Gray
        Me.Label14.Location = New System.Drawing.Point(6, 65)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(107, 13)
        Me.Label14.TabIndex = 144
        Me.Label14.Text = "Feature_Description"
        '
        'btAdd
        '
        Me.btAdd.BackColor = System.Drawing.Color.DodgerBlue
        Me.btAdd.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btAdd.Font = New System.Drawing.Font("맑은 고딕", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.btAdd.ForeColor = System.Drawing.Color.White
        Me.btAdd.Location = New System.Drawing.Point(421, 134)
        Me.btAdd.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btAdd.Name = "btAdd"
        Me.btAdd.Size = New System.Drawing.Size(75, 47)
        Me.btAdd.TabIndex = 8
        Me.btAdd.Text = "추가"
        Me.btAdd.UseVisualStyleBackColor = False
        '
        'addApp
        '
        Me.addApp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.addApp.Font = New System.Drawing.Font("맑은 고딕", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.addApp.Location = New System.Drawing.Point(160, 21)
        Me.addApp.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.addApp.Multiline = True
        Me.addApp.Name = "addApp"
        Me.addApp.Size = New System.Drawing.Size(160, 20)
        Me.addApp.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("맑은 고딕", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Gray
        Me.Label1.Location = New System.Drawing.Point(126, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(28, 13)
        Me.Label1.TabIndex = 125
        Me.Label1.Text = "App"
        '
        'addFeat
        '
        Me.addFeat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.addFeat.Font = New System.Drawing.Font("맑은 고딕", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.addFeat.Location = New System.Drawing.Point(382, 21)
        Me.addFeat.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.addFeat.Multiline = True
        Me.addFeat.Name = "addFeat"
        Me.addFeat.Size = New System.Drawing.Size(112, 20)
        Me.addFeat.TabIndex = 6
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("맑은 고딕", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Gray
        Me.Label11.Location = New System.Drawing.Point(332, 24)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(44, 13)
        Me.Label11.TabIndex = 137
        Me.Label11.Text = "Feature"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cbManager)
        Me.GroupBox1.Controls.Add(Me.btMod)
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.txtDes)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txtType)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtFeat)
        Me.GroupBox1.Controls.Add(Me.txtApp)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.cbStat)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Font = New System.Drawing.Font("맑은 고딕", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.GroupBox1.Location = New System.Drawing.Point(8, 320)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox1.Size = New System.Drawing.Size(502, 220)
        Me.GroupBox1.TabIndex = 146
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "요청사항"
        '
        'cbManager
        '
        Me.cbManager.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbManager.FormattingEnabled = True
        Me.cbManager.Location = New System.Drawing.Point(172, 50)
        Me.cbManager.Name = "cbManager"
        Me.cbManager.Size = New System.Drawing.Size(126, 21)
        Me.cbManager.TabIndex = 98
        '
        'btMod
        '
        Me.btMod.BackColor = System.Drawing.Color.Transparent
        Me.btMod.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btMod.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.btMod.Location = New System.Drawing.Point(340, 188)
        Me.btMod.Name = "btMod"
        Me.btMod.Size = New System.Drawing.Size(75, 23)
        Me.btMod.TabIndex = 96
        Me.btMod.Text = "수정"
        Me.btMod.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Button1.Location = New System.Drawing.Point(421, 188)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 95
        Me.Button1.Text = "삭제"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("맑은 고딕", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Gray
        Me.Label6.Location = New System.Drawing.Point(6, 83)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(65, 13)
        Me.Label6.TabIndex = 94
        Me.Label6.Text = "Description"
        '
        'txtDes
        '
        Me.txtDes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDes.Font = New System.Drawing.Font("맑은 고딕", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.txtDes.Location = New System.Drawing.Point(77, 83)
        Me.txtDes.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtDes.Multiline = True
        Me.txtDes.Name = "txtDes"
        Me.txtDes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtDes.Size = New System.Drawing.Size(419, 98)
        Me.txtDes.TabIndex = 93
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("맑은 고딕", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Gray
        Me.Label5.Location = New System.Drawing.Point(6, 24)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(31, 13)
        Me.Label5.TabIndex = 92
        Me.Label5.Text = "Type"
        '
        'txtType
        '
        Me.txtType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtType.Font = New System.Drawing.Font("맑은 고딕", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.txtType.Location = New System.Drawing.Point(44, 21)
        Me.txtType.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtType.Multiline = True
        Me.txtType.Name = "txtType"
        Me.txtType.Size = New System.Drawing.Size(74, 20)
        Me.txtType.TabIndex = 91
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("맑은 고딕", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Gray
        Me.Label4.Location = New System.Drawing.Point(137, 24)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(28, 13)
        Me.Label4.TabIndex = 90
        Me.Label4.Text = "App"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("맑은 고딕", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Gray
        Me.Label2.Location = New System.Drawing.Point(318, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(44, 13)
        Me.Label2.TabIndex = 89
        Me.Label2.Text = "Feature"
        '
        'txtFeat
        '
        Me.txtFeat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFeat.Font = New System.Drawing.Font("맑은 고딕", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.txtFeat.Location = New System.Drawing.Point(370, 21)
        Me.txtFeat.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtFeat.Multiline = True
        Me.txtFeat.Name = "txtFeat"
        Me.txtFeat.Size = New System.Drawing.Size(126, 20)
        Me.txtFeat.TabIndex = 88
        '
        'txtApp
        '
        Me.txtApp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtApp.Font = New System.Drawing.Font("맑은 고딕", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.txtApp.Location = New System.Drawing.Point(172, 21)
        Me.txtApp.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtApp.Multiline = True
        Me.txtApp.Name = "txtApp"
        Me.txtApp.Size = New System.Drawing.Size(126, 20)
        Me.txtApp.TabIndex = 87
        '
        'TapControl1
        '
        Me.TapControl1.Controls.Add(Me.TabPage1)
        Me.TapControl1.Controls.Add(Me.TabPage2)
        Me.TapControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TapControl1.Location = New System.Drawing.Point(0, 0)
        Me.TapControl1.Name = "TapControl1"
        Me.TapControl1.SelectedIndex = 0
        Me.TapControl1.Size = New System.Drawing.Size(1040, 567)
        Me.TapControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.White
        Me.TabPage1.Controls.Add(Me.GroupBox1)
        Me.TabPage1.Controls.Add(Me.btRefresh)
        Me.TabPage1.Controls.Add(Me.GroupBox3)
        Me.TabPage1.Controls.Add(Me.PictureBox1)
        Me.TabPage1.Controls.Add(Me.gridRequest)
        Me.TabPage1.Location = New System.Drawing.Point(4, 24)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1032, 539)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "요청내역"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(8, 7)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(118, 30)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 77
        Me.PictureBox1.TabStop = False
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.btModT2)
        Me.TabPage2.Controls.Add(Me.btSearchT2)
        Me.TabPage2.Controls.Add(Me.Label13)
        Me.TabPage2.Controls.Add(Me.txtDesT2)
        Me.TabPage2.Controls.Add(Me.cbTypeT2)
        Me.TabPage2.Controls.Add(Me.Label12)
        Me.TabPage2.Controls.Add(Me.btDeleteT2)
        Me.TabPage2.Controls.Add(Me.btApprefresh)
        Me.TabPage2.Controls.Add(Me.Label10)
        Me.TabPage2.Controls.Add(Me.PictureBox2)
        Me.TabPage2.Controls.Add(Me.gridApp)
        Me.TabPage2.Controls.Add(Me.txtAppT2)
        Me.TabPage2.Controls.Add(Me.Label9)
        Me.TabPage2.Controls.Add(Me.txtFeatT2)
        Me.TabPage2.Location = New System.Drawing.Point(4, 24)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(1032, 539)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "App List"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'btModT2
        '
        Me.btModT2.BackColor = System.Drawing.Color.White
        Me.btModT2.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btModT2.Font = New System.Drawing.Font("맑은 고딕", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.btModT2.Location = New System.Drawing.Point(864, 505)
        Me.btModT2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btModT2.Name = "btModT2"
        Me.btModT2.Size = New System.Drawing.Size(75, 25)
        Me.btModT2.TabIndex = 164
        Me.btModT2.Text = "수정"
        Me.btModT2.UseVisualStyleBackColor = False
        '
        'btSearchT2
        '
        Me.btSearchT2.BackColor = System.Drawing.Color.White
        Me.btSearchT2.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btSearchT2.Font = New System.Drawing.Font("맑은 고딕", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.btSearchT2.Location = New System.Drawing.Point(597, 505)
        Me.btSearchT2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btSearchT2.Name = "btSearchT2"
        Me.btSearchT2.Size = New System.Drawing.Size(75, 25)
        Me.btSearchT2.TabIndex = 163
        Me.btSearchT2.Text = "검색"
        Me.btSearchT2.UseVisualStyleBackColor = False
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("맑은 고딕", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Gray
        Me.Label13.Location = New System.Drawing.Point(484, 438)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(107, 13)
        Me.Label13.TabIndex = 162
        Me.Label13.Text = "Feature_Description"
        '
        'txtDesT2
        '
        Me.txtDesT2.Font = New System.Drawing.Font("맑은 고딕", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.txtDesT2.Location = New System.Drawing.Point(597, 435)
        Me.txtDesT2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtDesT2.Multiline = True
        Me.txtDesT2.Name = "txtDesT2"
        Me.txtDesT2.Size = New System.Drawing.Size(423, 62)
        Me.txtDesT2.TabIndex = 161
        '
        'cbTypeT2
        '
        Me.cbTypeT2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbTypeT2.Font = New System.Drawing.Font("맑은 고딕", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.cbTypeT2.FormattingEnabled = True
        Me.cbTypeT2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.cbTypeT2.Location = New System.Drawing.Point(55, 435)
        Me.cbTypeT2.Name = "cbTypeT2"
        Me.cbTypeT2.Size = New System.Drawing.Size(71, 21)
        Me.cbTypeT2.TabIndex = 160
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("맑은 고딕", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Gray
        Me.Label12.Location = New System.Drawing.Point(18, 438)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(31, 13)
        Me.Label12.TabIndex = 159
        Me.Label12.Text = "Type"
        '
        'btDeleteT2
        '
        Me.btDeleteT2.BackColor = System.Drawing.Color.White
        Me.btDeleteT2.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btDeleteT2.Font = New System.Drawing.Font("맑은 고딕", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.btDeleteT2.Location = New System.Drawing.Point(945, 505)
        Me.btDeleteT2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btDeleteT2.Name = "btDeleteT2"
        Me.btDeleteT2.Size = New System.Drawing.Size(75, 25)
        Me.btDeleteT2.TabIndex = 157
        Me.btDeleteT2.Text = "삭제"
        Me.btDeleteT2.UseVisualStyleBackColor = False
        '
        'btApprefresh
        '
        Me.btApprefresh.BackColor = System.Drawing.Color.White
        Me.btApprefresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btApprefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btApprefresh.ForeColor = System.Drawing.Color.DimGray
        Me.btApprefresh.Location = New System.Drawing.Point(132, 10)
        Me.btApprefresh.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btApprefresh.Name = "btApprefresh"
        Me.btApprefresh.Size = New System.Drawing.Size(56, 25)
        Me.btApprefresh.TabIndex = 84
        Me.btApprefresh.Text = "Refresh"
        Me.btApprefresh.UseVisualStyleBackColor = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("맑은 고딕", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Gray
        Me.Label10.Location = New System.Drawing.Point(293, 438)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(44, 13)
        Me.Label10.TabIndex = 93
        Me.Label10.Text = "Feature"
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(8, 7)
        Me.PictureBox2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(118, 30)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 83
        Me.PictureBox2.TabStop = False
        '
        'gridApp
        '
        Me.gridApp.AllowUserToAddRows = False
        Me.gridApp.AllowUserToDeleteRows = False
        Me.gridApp.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader
        Me.gridApp.BackgroundColor = System.Drawing.SystemColors.ButtonFace
        Me.gridApp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridApp.Location = New System.Drawing.Point(8, 43)
        Me.gridApp.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.gridApp.Name = "gridApp"
        Me.gridApp.ReadOnly = True
        Me.gridApp.RowTemplate.Height = 23
        Me.gridApp.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gridApp.Size = New System.Drawing.Size(1012, 374)
        Me.gridApp.TabIndex = 85
        '
        'txtAppT2
        '
        Me.txtAppT2.Font = New System.Drawing.Font("맑은 고딕", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.txtAppT2.Location = New System.Drawing.Point(173, 435)
        Me.txtAppT2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtAppT2.Multiline = True
        Me.txtAppT2.Name = "txtAppT2"
        Me.txtAppT2.Size = New System.Drawing.Size(108, 20)
        Me.txtAppT2.TabIndex = 91
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("맑은 고딕", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Gray
        Me.Label9.Location = New System.Drawing.Point(139, 439)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(28, 13)
        Me.Label9.TabIndex = 94
        Me.Label9.Text = "App"
        '
        'txtFeatT2
        '
        Me.txtFeatT2.Font = New System.Drawing.Font("맑은 고딕", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.txtFeatT2.Location = New System.Drawing.Point(343, 436)
        Me.txtFeatT2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtFeatT2.Multiline = True
        Me.txtFeatT2.Name = "txtFeatT2"
        Me.txtFeatT2.Size = New System.Drawing.Size(126, 20)
        Me.txtFeatT2.TabIndex = 92
        '
        'App_Feature
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1040, 567)
        Me.Controls.Add(Me.TapControl1)
        Me.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "App_Feature"
        Me.Text = "Request List"
        CType(Me.gridRequest, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.TapControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridApp, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btRefresh As Windows.Forms.Button
    Friend WithEvents gridRequest As Windows.Forms.DataGridView
    Friend WithEvents cbStat As Windows.Forms.ComboBox
    Friend WithEvents Label3 As Windows.Forms.Label
    Friend WithEvents Label7 As Windows.Forms.Label
    Friend WithEvents GroupBox3 As Windows.Forms.GroupBox
    Friend WithEvents Label14 As Windows.Forms.Label
    Friend WithEvents addDes As Windows.Forms.TextBox
    Friend WithEvents btAdd As Windows.Forms.Button
    Friend WithEvents addApp As Windows.Forms.TextBox
    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents addFeat As Windows.Forms.TextBox
    Friend WithEvents Label11 As Windows.Forms.Label
    Friend WithEvents GroupBox1 As Windows.Forms.GroupBox
    Friend WithEvents Label4 As Windows.Forms.Label
    Friend WithEvents Label2 As Windows.Forms.Label
    Friend WithEvents txtFeat As Windows.Forms.TextBox
    Friend WithEvents txtApp As Windows.Forms.TextBox
    Friend WithEvents Label5 As Windows.Forms.Label
    Friend WithEvents txtType As Windows.Forms.TextBox
    Friend WithEvents Label6 As Windows.Forms.Label
    Friend WithEvents txtDes As Windows.Forms.TextBox
    Friend WithEvents cbType As Windows.Forms.ComboBox
    Friend WithEvents Label8 As Windows.Forms.Label
    Friend WithEvents Button1 As Windows.Forms.Button
    Friend WithEvents btMod As Windows.Forms.Button
    Friend WithEvents btSearch As Windows.Forms.Button
    Friend WithEvents TapControl1 As Windows.Forms.TabControl
    Friend WithEvents TabPage1 As Windows.Forms.TabPage
    Friend WithEvents TabPage2 As Windows.Forms.TabPage
    Friend WithEvents PictureBox1 As Windows.Forms.PictureBox
    Friend WithEvents cbManager As Windows.Forms.ComboBox
    Friend WithEvents btApprefresh As Windows.Forms.Button
    Friend WithEvents PictureBox2 As Windows.Forms.PictureBox
    Friend WithEvents gridApp As Windows.Forms.DataGridView
    Friend WithEvents cbTypeT2 As Windows.Forms.ComboBox
    Friend WithEvents Label12 As Windows.Forms.Label
    Friend WithEvents btDeleteT2 As Windows.Forms.Button
    Friend WithEvents Label10 As Windows.Forms.Label
    Friend WithEvents txtAppT2 As Windows.Forms.TextBox
    Friend WithEvents Label9 As Windows.Forms.Label
    Friend WithEvents txtFeatT2 As Windows.Forms.TextBox
    Friend WithEvents Label13 As Windows.Forms.Label
    Friend WithEvents txtDesT2 As Windows.Forms.TextBox
    Friend WithEvents btModT2 As Windows.Forms.Button
    Friend WithEvents btSearchT2 As Windows.Forms.Button
End Class
