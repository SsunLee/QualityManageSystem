<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Kernel
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Kernel))
        Me.txtHistory = New System.Windows.Forms.TextBox()
        Me.txtDev = New System.Windows.Forms.TextBox()
        Me.txtKey = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtStep = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Des_Txt = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ListBox3 = New System.Windows.Forms.ListBox()
        Me.ListBox2 = New System.Windows.Forms.ListBox()
        Me.ListBox4 = New System.Windows.Forms.ListBox()
        Me.Search_Result = New System.Windows.Forms.ListBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtMD = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtTD = New System.Windows.Forms.TextBox()
        Me.lb_SW = New System.Windows.Forms.Label()
        Me.btn_VPSearch = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.requestBtn = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtHistory
        '
        Me.txtHistory.BackColor = System.Drawing.Color.White
        Me.txtHistory.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.txtHistory.Location = New System.Drawing.Point(625, 547)
        Me.txtHistory.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.txtHistory.Multiline = True
        Me.txtHistory.Name = "txtHistory"
        Me.txtHistory.ReadOnly = True
        Me.txtHistory.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtHistory.Size = New System.Drawing.Size(608, 124)
        Me.txtHistory.TabIndex = 70
        '
        'txtDev
        '
        Me.txtDev.BackColor = System.Drawing.Color.White
        Me.txtDev.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.txtDev.Location = New System.Drawing.Point(9, 380)
        Me.txtDev.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.txtDev.Multiline = True
        Me.txtDev.Name = "txtDev"
        Me.txtDev.ReadOnly = True
        Me.txtDev.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtDev.Size = New System.Drawing.Size(608, 124)
        Me.txtDev.TabIndex = 69
        '
        'txtKey
        '
        Me.txtKey.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtKey.Font = New System.Drawing.Font("Malgun Gothic", 8.0!)
        Me.txtKey.Location = New System.Drawing.Point(958, 80)
        Me.txtKey.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.txtKey.Multiline = True
        Me.txtKey.Name = "txtKey"
        Me.txtKey.ReadOnly = True
        Me.txtKey.Size = New System.Drawing.Size(270, 28)
        Me.txtKey.TabIndex = 68
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Gulim", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Gray
        Me.Label10.Location = New System.Drawing.Point(887, 522)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(57, 13)
        Me.Label10.TabIndex = 57
        Me.Label10.Text = "History"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Gulim", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Gray
        Me.Label9.Location = New System.Drawing.Point(214, 356)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(135, 13)
        Me.Label9.TabIndex = 59
        Me.Label9.Text = "Dev_Function 설명"
        '
        'txtStep
        '
        Me.txtStep.BackColor = System.Drawing.Color.White
        Me.txtStep.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.txtStep.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.txtStep.Location = New System.Drawing.Point(625, 380)
        Me.txtStep.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.txtStep.Multiline = True
        Me.txtStep.Name = "txtStep"
        Me.txtStep.ReadOnly = True
        Me.txtStep.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtStep.Size = New System.Drawing.Size(608, 124)
        Me.txtStep.TabIndex = 71
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Gray
        Me.Label4.Location = New System.Drawing.Point(795, 131)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(31, 15)
        Me.Label4.TabIndex = 61
        Me.Label4.Text = "App"
        '
        'Des_Txt
        '
        Me.Des_Txt.BackColor = System.Drawing.Color.White
        Me.Des_Txt.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Des_Txt.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Des_Txt.Location = New System.Drawing.Point(8, 385)
        Me.Des_Txt.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.Des_Txt.Multiline = True
        Me.Des_Txt.Name = "Des_Txt"
        Me.Des_Txt.ReadOnly = True
        Me.Des_Txt.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.Des_Txt.Size = New System.Drawing.Size(608, 59)
        Me.Des_Txt.TabIndex = 67
        Me.Des_Txt.Visible = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Gulim", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Gray
        Me.Label8.Location = New System.Drawing.Point(876, 80)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(68, 13)
        Me.Label8.TabIndex = 62
        Me.Label8.Text = "Keyword"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Gray
        Me.Label1.Location = New System.Drawing.Point(18, 83)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 15)
        Me.Label1.TabIndex = 60
        Me.Label1.Text = "TC검색"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Gulim", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Gray
        Me.Label2.Location = New System.Drawing.Point(881, 356)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(63, 13)
        Me.Label2.TabIndex = 58
        Me.Label2.Text = "검증방법"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Gray
        Me.Label13.Location = New System.Drawing.Point(1036, 131)
        Me.Label13.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(78, 15)
        Me.Label13.TabIndex = 63
        Me.Label13.Text = "APP_Feature"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Gray
        Me.Label12.Location = New System.Drawing.Point(352, 131)
        Me.Label12.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(83, 15)
        Me.Label12.TabIndex = 65
        Me.Label12.Text = "DEV_Function"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Gray
        Me.Label5.Location = New System.Drawing.Point(77, 131)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(31, 15)
        Me.Label5.TabIndex = 66
        Me.Label5.Text = "구분"
        '
        'ListBox3
        '
        Me.ListBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ListBox3.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.ListBox3.FormattingEnabled = True
        Me.ListBox3.HorizontalScrollbar = True
        Me.ListBox3.ItemHeight = 15
        Me.ListBox3.Location = New System.Drawing.Point(684, 160)
        Me.ListBox3.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.ListBox3.Name = "ListBox3"
        Me.ListBox3.Size = New System.Drawing.Size(253, 167)
        Me.ListBox3.TabIndex = 53
        '
        'ListBox2
        '
        Me.ListBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ListBox2.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.ListBox2.FormattingEnabled = True
        Me.ListBox2.HorizontalScrollbar = True
        Me.ListBox2.ItemHeight = 15
        Me.ListBox2.Location = New System.Drawing.Point(212, 160)
        Me.ListBox2.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.ListBox2.Name = "ListBox2"
        Me.ListBox2.Size = New System.Drawing.Size(464, 167)
        Me.ListBox2.TabIndex = 51
        '
        'ListBox4
        '
        Me.ListBox4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ListBox4.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.ListBox4.FormattingEnabled = True
        Me.ListBox4.HorizontalScrollbar = True
        Me.ListBox4.ItemHeight = 15
        Me.ListBox4.Location = New System.Drawing.Point(953, 160)
        Me.ListBox4.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.ListBox4.Name = "ListBox4"
        Me.ListBox4.Size = New System.Drawing.Size(276, 167)
        Me.ListBox4.TabIndex = 54
        '
        'Search_Result
        '
        Me.Search_Result.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Search_Result.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Search_Result.FormattingEnabled = True
        Me.Search_Result.HorizontalScrollbar = True
        Me.Search_Result.ItemHeight = 15
        Me.Search_Result.Location = New System.Drawing.Point(8, 160)
        Me.Search_Result.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.Search_Result.Name = "Search_Result"
        Me.Search_Result.Size = New System.Drawing.Size(196, 167)
        Me.Search_Result.TabIndex = 49
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TextBox1.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(81, 83)
        Me.TextBox1.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(255, 23)
        Me.TextBox1.TabIndex = 48
        '
        'Button1
        '
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.Gray
        Me.Button1.Location = New System.Drawing.Point(467, 83)
        Me.Button1.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(112, 25)
        Me.Button1.TabIndex = 100
        Me.Button1.Text = "초기화"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Button2.ForeColor = System.Drawing.Color.Gray
        Me.Button2.Location = New System.Drawing.Point(347, 82)
        Me.Button2.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(112, 25)
        Me.Button2.TabIndex = 100
        Me.Button2.Text = "Search"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Gray
        Me.Label7.Location = New System.Drawing.Point(393, 47)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(56, 15)
        Me.Label7.TabIndex = 62
        Me.Label7.Text = "투입 MD"
        Me.Label7.Visible = False
        '
        'txtMD
        '
        Me.txtMD.BackColor = System.Drawing.Color.White
        Me.txtMD.Font = New System.Drawing.Font("Malgun Gothic", 8.0!)
        Me.txtMD.Location = New System.Drawing.Point(480, 47)
        Me.txtMD.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.txtMD.Multiline = True
        Me.txtMD.Name = "txtMD"
        Me.txtMD.ReadOnly = True
        Me.txtMD.Size = New System.Drawing.Size(235, 19)
        Me.txtMD.TabIndex = 68
        Me.txtMD.Visible = False
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.Gray
        Me.Label14.Location = New System.Drawing.Point(413, 22)
        Me.Label14.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(23, 15)
        Me.Label14.TabIndex = 62
        Me.Label14.Text = "TD"
        Me.Label14.Visible = False
        '
        'txtTD
        '
        Me.txtTD.BackColor = System.Drawing.Color.White
        Me.txtTD.Font = New System.Drawing.Font("Malgun Gothic", 8.0!)
        Me.txtTD.Location = New System.Drawing.Point(478, 22)
        Me.txtTD.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.txtTD.Multiline = True
        Me.txtTD.Name = "txtTD"
        Me.txtTD.ReadOnly = True
        Me.txtTD.Size = New System.Drawing.Size(235, 19)
        Me.txtTD.TabIndex = 68
        Me.txtTD.Visible = False
        '
        'lb_SW
        '
        Me.lb_SW.AutoSize = True
        Me.lb_SW.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lb_SW.Font = New System.Drawing.Font("Malgun Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.lb_SW.ForeColor = System.Drawing.Color.DimGray
        Me.lb_SW.Location = New System.Drawing.Point(1036, 24)
        Me.lb_SW.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lb_SW.Name = "lb_SW"
        Me.lb_SW.Size = New System.Drawing.Size(39, 17)
        Me.lb_SW.TabIndex = 105
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
        Me.btn_VPSearch.Location = New System.Drawing.Point(964, 18)
        Me.btn_VPSearch.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.btn_VPSearch.Name = "btn_VPSearch"
        Me.btn_VPSearch.Size = New System.Drawing.Size(73, 33)
        Me.btn_VPSearch.TabIndex = 104
        Me.btn_VPSearch.UseVisualStyleBackColor = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImage = CType(resources.GetObject("PictureBox1.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.InitialImage = CType(resources.GetObject("PictureBox1.InitialImage"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(22, 14)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(290, 27)
        Me.PictureBox1.TabIndex = 107
        Me.PictureBox1.TabStop = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Malgun Gothic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.DimGray
        Me.Label6.Location = New System.Drawing.Point(368, 15)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(198, 25)
        Me.Label6.TabIndex = 106
        Me.Label6.Text = "Random_신뢰성 검증"
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
        Me.requestBtn.Location = New System.Drawing.Point(1150, 9)
        Me.requestBtn.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.requestBtn.Name = "requestBtn"
        Me.requestBtn.Size = New System.Drawing.Size(78, 58)
        Me.requestBtn.TabIndex = 143
        Me.requestBtn.Text = "제안하기"
        Me.requestBtn.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.requestBtn.UseVisualStyleBackColor = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Gulim", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Gray
        Me.Label3.Location = New System.Drawing.Point(235, 522)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(58, 13)
        Me.Label3.TabIndex = 58
        Me.Label3.Text = "Around"
        '
        'TextBox2
        '
        Me.TextBox2.BackColor = System.Drawing.Color.White
        Me.TextBox2.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.TextBox2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.TextBox2.Location = New System.Drawing.Point(8, 547)
        Me.TextBox2.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.TextBox2.Multiline = True
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.ReadOnly = True
        Me.TextBox2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TextBox2.Size = New System.Drawing.Size(604, 124)
        Me.TextBox2.TabIndex = 71
        '
        'Kernel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1250, 683)
        Me.Controls.Add(Me.requestBtn)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.lb_SW)
        Me.Controls.Add(Me.btn_VPSearch)
        Me.Controls.Add(Me.txtHistory)
        Me.Controls.Add(Me.txtDev)
        Me.Controls.Add(Me.txtTD)
        Me.Controls.Add(Me.txtMD)
        Me.Controls.Add(Me.txtKey)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.txtStep)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Des_Txt)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.ListBox3)
        Me.Controls.Add(Me.ListBox2)
        Me.Controls.Add(Me.ListBox4)
        Me.Controls.Add(Me.Search_Result)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Button2)
        Me.Font = New System.Drawing.Font("Gulim", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.Name = "Kernel"
        Me.Text = "Kernel"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtHistory As Windows.Forms.TextBox
    Friend WithEvents txtDev As Windows.Forms.TextBox
    Friend WithEvents txtKey As Windows.Forms.TextBox
    Friend WithEvents Label10 As Windows.Forms.Label
    Friend WithEvents Label9 As Windows.Forms.Label
    Friend WithEvents txtStep As Windows.Forms.TextBox
    Friend WithEvents Label4 As Windows.Forms.Label
    Friend WithEvents Des_Txt As Windows.Forms.TextBox
    Friend WithEvents Label8 As Windows.Forms.Label
    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents Label2 As Windows.Forms.Label
    Friend WithEvents Label13 As Windows.Forms.Label
    Friend WithEvents Label12 As Windows.Forms.Label
    Friend WithEvents Label5 As Windows.Forms.Label
    Friend WithEvents ListBox3 As Windows.Forms.ListBox
    Friend WithEvents ListBox2 As Windows.Forms.ListBox
    Friend WithEvents ListBox4 As Windows.Forms.ListBox
    Friend WithEvents Search_Result As Windows.Forms.ListBox
    Friend WithEvents ToolTip1 As Windows.Forms.ToolTip
    Friend WithEvents TextBox1 As Windows.Forms.TextBox
    Friend WithEvents Button1 As Windows.Forms.Button
    Friend WithEvents Button2 As Windows.Forms.Button
    Friend WithEvents Label7 As Windows.Forms.Label
    Friend WithEvents txtMD As Windows.Forms.TextBox
    Friend WithEvents Label14 As Windows.Forms.Label
    Friend WithEvents txtTD As Windows.Forms.TextBox
    Friend WithEvents lb_SW As Windows.Forms.Label
    Friend WithEvents btn_VPSearch As Windows.Forms.Button
    Friend WithEvents PictureBox1 As Windows.Forms.PictureBox
    Friend WithEvents Label6 As Windows.Forms.Label
    Friend WithEvents requestBtn As Windows.Forms.Button
    Friend WithEvents Label3 As Windows.Forms.Label
    Friend WithEvents TextBox2 As Windows.Forms.TextBox
End Class
