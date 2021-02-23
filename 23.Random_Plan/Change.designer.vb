<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Change
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Change))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.lstChange = New System.Windows.Forms.ListBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.btnAdmin = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.txtChange = New System.Windows.Forms.RichTextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtMod = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.ChangeRisk = New System.Windows.Forms.RichTextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.laUserName = New System.Windows.Forms.Label()
        Me.btn_Search = New System.Windows.Forms.Button()
        Me.txtStep = New System.Windows.Forms.TextBox()
        Me.Label_Name = New System.Windows.Forms.Label()
        Me.txtComp = New System.Windows.Forms.TextBox()
        Me.txtPro = New System.Windows.Forms.TextBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.trv1 = New System.Windows.Forms.TreeView()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.lstComp = New System.Windows.Forms.ListBox()
        Me.lstSuf = New System.Windows.Forms.ListBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.trv2 = New System.Windows.Forms.TreeView()
        Me.dgv_info = New System.Windows.Forms.DataGridView()
        Me.Splitter1 = New System.Windows.Forms.Splitter()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.dgv_info, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lstChange
        '
        Me.lstChange.AllowDrop = True
        Me.lstChange.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.lstChange.FormattingEnabled = True
        Me.lstChange.HorizontalScrollbar = True
        Me.lstChange.ItemHeight = 15
        Me.lstChange.Location = New System.Drawing.Point(20, 219)
        Me.lstChange.Name = "lstChange"
        Me.lstChange.ScrollAlwaysVisible = True
        Me.lstChange.Size = New System.Drawing.Size(426, 349)
        Me.lstChange.Sorted = True
        Me.lstChange.TabIndex = 11
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("맑은 고딕", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Gray
        Me.Label2.Location = New System.Drawing.Point(452, 196)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(89, 20)
        Me.Label2.TabIndex = 24
        Me.Label2.Text = "변경점 내용"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("맑은 고딕", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.DimGray
        Me.Label8.Location = New System.Drawing.Point(228, 3)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(135, 20)
        Me.Label8.TabIndex = 53
        Me.Label8.Text = "검증계획서_변경점"
        '
        'btnAdmin
        '
        Me.btnAdmin.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAdmin.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.btnAdmin.ForeColor = System.Drawing.Color.Gray
        Me.btnAdmin.Location = New System.Drawing.Point(1136, 318)
        Me.btnAdmin.Name = "btnAdmin"
        Me.btnAdmin.Size = New System.Drawing.Size(114, 29)
        Me.btnAdmin.TabIndex = 5
        Me.btnAdmin.Text = "담당자 전용"
        Me.btnAdmin.UseVisualStyleBackColor = True
        Me.btnAdmin.Visible = False
        '
        'Button2
        '
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Button2.ForeColor = System.Drawing.Color.Gray
        Me.Button2.Location = New System.Drawing.Point(555, 12)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(152, 41)
        Me.Button2.TabIndex = 12
        Me.Button2.Text = "검증방법 작성" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(Export 전용)"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'txtChange
        '
        Me.txtChange.BackColor = System.Drawing.Color.White
        Me.txtChange.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtChange.Font = New System.Drawing.Font("맑은 고딕", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.txtChange.Location = New System.Drawing.Point(452, 219)
        Me.txtChange.Name = "txtChange"
        Me.txtChange.ReadOnly = True
        Me.txtChange.Size = New System.Drawing.Size(356, 349)
        Me.txtChange.TabIndex = 148
        Me.txtChange.Text = ""
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("맑은 고딕", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Gray
        Me.Label7.Location = New System.Drawing.Point(16, 194)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(89, 20)
        Me.Label7.TabIndex = 24
        Me.Label7.Text = "주요 변경점"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("맑은 고딕", 10.25!, System.Drawing.FontStyle.Bold)
        Me.Label14.ForeColor = System.Drawing.Color.DarkRed
        Me.Label14.Location = New System.Drawing.Point(16, 83)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(219, 19)
        Me.Label14.TabIndex = 153
        Me.Label14.Text = "※ Model 검색 후 사용해 주세요."
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.Gray
        Me.Label17.Location = New System.Drawing.Point(17, 150)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(51, 15)
        Me.Label17.TabIndex = 35
        Me.Label17.Text = "Model :"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.Gray
        Me.Label18.Location = New System.Drawing.Point(14, 113)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(54, 15)
        Me.Label18.TabIndex = 36
        Me.Label18.Text = "Project :"
        '
        'txtMod
        '
        Me.txtMod.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMod.Location = New System.Drawing.Point(74, 151)
        Me.txtMod.Name = "txtMod"
        Me.txtMod.Size = New System.Drawing.Size(106, 21)
        Me.txtMod.TabIndex = 154
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.Gray
        Me.Label19.Location = New System.Drawing.Point(30, 187)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(38, 15)
        Me.Label19.TabIndex = 36
        Me.Label19.Text = "차수 :"
        '
        'ChangeRisk
        '
        Me.ChangeRisk.BackColor = System.Drawing.Color.White
        Me.ChangeRisk.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ChangeRisk.Font = New System.Drawing.Font("맑은 고딕", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.ChangeRisk.Location = New System.Drawing.Point(814, 219)
        Me.ChangeRisk.Name = "ChangeRisk"
        Me.ChangeRisk.ReadOnly = True
        Me.ChangeRisk.Size = New System.Drawing.Size(316, 349)
        Me.ChangeRisk.TabIndex = 158
        Me.ChangeRisk.Text = ""
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("맑은 고딕", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Gray
        Me.Label1.Location = New System.Drawing.Point(814, 187)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(133, 20)
        Me.Label1.TabIndex = 157
        Me.Label1.Text = "변경점_RiskFactor"
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.laUserName)
        Me.Panel1.Controls.Add(Me.btn_Search)
        Me.Panel1.Controls.Add(Me.txtStep)
        Me.Panel1.Controls.Add(Me.Label_Name)
        Me.Panel1.Controls.Add(Me.txtComp)
        Me.Panel1.Controls.Add(Me.txtPro)
        Me.Panel1.Controls.Add(Me.txtMod)
        Me.Panel1.Controls.Add(Me.Label14)
        Me.Panel1.Controls.Add(Me.Label17)
        Me.Panel1.Controls.Add(Me.Label18)
        Me.Panel1.Controls.Add(Me.Label19)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(245, 321)
        Me.Panel1.TabIndex = 159
        '
        'laUserName
        '
        Me.laUserName.AutoSize = True
        Me.laUserName.Location = New System.Drawing.Point(191, 15)
        Me.laUserName.Name = "laUserName"
        Me.laUserName.Size = New System.Drawing.Size(9, 12)
        Me.laUserName.TabIndex = 158
        Me.laUserName.Text = " "
        '
        'btn_Search
        '
        Me.btn_Search.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Search.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.btn_Search.Location = New System.Drawing.Point(105, 219)
        Me.btn_Search.Name = "btn_Search"
        Me.btn_Search.Size = New System.Drawing.Size(75, 23)
        Me.btn_Search.TabIndex = 157
        Me.btn_Search.Text = "Search"
        Me.btn_Search.UseVisualStyleBackColor = True
        '
        'txtStep
        '
        Me.txtStep.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtStep.Location = New System.Drawing.Point(74, 189)
        Me.txtStep.Name = "txtStep"
        Me.txtStep.Size = New System.Drawing.Size(108, 21)
        Me.txtStep.TabIndex = 156
        '
        'Label_Name
        '
        Me.Label_Name.AutoSize = True
        Me.Label_Name.Location = New System.Drawing.Point(110, 16)
        Me.Label_Name.Name = "Label_Name"
        Me.Label_Name.Size = New System.Drawing.Size(53, 12)
        Me.Label_Name.TabIndex = 64
        Me.Label_Name.Text = "작성자 : "
        '
        'txtComp
        '
        Me.txtComp.BackColor = System.Drawing.Color.LightCoral
        Me.txtComp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtComp.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.txtComp.ForeColor = System.Drawing.Color.White
        Me.txtComp.Location = New System.Drawing.Point(16, 12)
        Me.txtComp.Name = "txtComp"
        Me.txtComp.Size = New System.Drawing.Size(88, 23)
        Me.txtComp.TabIndex = 63
        '
        'txtPro
        '
        Me.txtPro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPro.Location = New System.Drawing.Point(74, 113)
        Me.txtPro.Name = "txtPro"
        Me.txtPro.Size = New System.Drawing.Size(104, 21)
        Me.txtPro.TabIndex = 155
        '
        'PictureBox2
        '
        Me.PictureBox2.BackgroundImage = CType(resources.GetObject("PictureBox2.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox2.Location = New System.Drawing.Point(6, 3)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(216, 25)
        Me.PictureBox2.TabIndex = 62
        Me.PictureBox2.TabStop = False
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.trv1)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.Button1)
        Me.Panel2.Controls.Add(Me.lstComp)
        Me.Panel2.Controls.Add(Me.lstSuf)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.trv2)
        Me.Panel2.Controls.Add(Me.dgv_info)
        Me.Panel2.Controls.Add(Me.Button2)
        Me.Panel2.Controls.Add(Me.Label8)
        Me.Panel2.Controls.Add(Me.PictureBox2)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(245, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(719, 321)
        Me.Panel2.TabIndex = 160
        '
        'trv1
        '
        Me.trv1.Location = New System.Drawing.Point(6, 84)
        Me.trv1.Name = "trv1"
        Me.trv1.Size = New System.Drawing.Size(240, 232)
        Me.trv1.TabIndex = 65
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("맑은 고딕", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Red
        Me.Label5.Location = New System.Drawing.Point(6, 66)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(43, 13)
        Me.Label5.TabIndex = 109
        Me.Label5.Text = "Project"
        '
        'Button1
        '
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("맑은 고딕", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Button1.Location = New System.Drawing.Point(420, 14)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(94, 38)
        Me.Button1.TabIndex = 64
        Me.Button1.Text = "Mapping" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "정보수정"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'lstComp
        '
        Me.lstComp.FormattingEnabled = True
        Me.lstComp.ItemHeight = 12
        Me.lstComp.Location = New System.Drawing.Point(519, 84)
        Me.lstComp.Name = "lstComp"
        Me.lstComp.Size = New System.Drawing.Size(154, 232)
        Me.lstComp.TabIndex = 68
        '
        'lstSuf
        '
        Me.lstSuf.FormattingEnabled = True
        Me.lstSuf.ItemHeight = 12
        Me.lstSuf.Location = New System.Drawing.Point(302, 84)
        Me.lstSuf.Name = "lstSuf"
        Me.lstSuf.Size = New System.Drawing.Size(161, 232)
        Me.lstSuf.TabIndex = 67
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("맑은 고딕", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Red
        Me.Label4.Location = New System.Drawing.Point(516, 66)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(40, 13)
        Me.Label4.TabIndex = 108
        Me.Label4.Text = "업체명"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("맑은 고딕", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Red
        Me.Label3.Location = New System.Drawing.Point(299, 66)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(40, 13)
        Me.Label3.TabIndex = 107
        Me.Label3.Text = "사업자"
        '
        'trv2
        '
        Me.trv2.Location = New System.Drawing.Point(608, 60)
        Me.trv2.Name = "trv2"
        Me.trv2.Size = New System.Drawing.Size(299, 240)
        Me.trv2.TabIndex = 66
        Me.trv2.Visible = False
        '
        'dgv_info
        '
        Me.dgv_info.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_info.Cursor = System.Windows.Forms.Cursors.Default
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("맑은 고딕", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgv_info.DefaultCellStyle = DataGridViewCellStyle1
        Me.dgv_info.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.dgv_info.Location = New System.Drawing.Point(0, 59)
        Me.dgv_info.MultiSelect = False
        Me.dgv_info.Name = "dgv_info"
        Me.dgv_info.RowTemplate.Height = 23
        Me.dgv_info.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_info.Size = New System.Drawing.Size(719, 262)
        Me.dgv_info.TabIndex = 63
        Me.dgv_info.Visible = False
        '
        'Splitter1
        '
        Me.Splitter1.Location = New System.Drawing.Point(245, 0)
        Me.Splitter1.Name = "Splitter1"
        Me.Splitter1.Size = New System.Drawing.Size(3, 321)
        Me.Splitter1.TabIndex = 161
        Me.Splitter1.TabStop = False
        '
        'Change
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(964, 321)
        Me.Controls.Add(Me.Splitter1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.ChangeRisk)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnAdmin)
        Me.Controls.Add(Me.txtChange)
        Me.Controls.Add(Me.lstChange)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label7)
        Me.Name = "Change"
        Me.Text = "Change"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.dgv_info, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lstChange As Windows.Forms.ListBox
    Friend WithEvents Label2 As Windows.Forms.Label
    Friend WithEvents Label8 As Windows.Forms.Label
    Friend WithEvents btnAdmin As Windows.Forms.Button
    Friend WithEvents Button2 As Windows.Forms.Button
    Friend WithEvents txtChange As Windows.Forms.RichTextBox
    Friend WithEvents Label7 As Windows.Forms.Label
    Friend WithEvents Label14 As Windows.Forms.Label
    Friend WithEvents Label17 As Windows.Forms.Label
    Friend WithEvents Label18 As Windows.Forms.Label
    Friend WithEvents txtMod As Windows.Forms.TextBox
    Friend WithEvents Label19 As Windows.Forms.Label
    Friend WithEvents ChangeRisk As Windows.Forms.RichTextBox
    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents Panel1 As Windows.Forms.Panel
    Friend WithEvents txtPro As Windows.Forms.TextBox
    Friend WithEvents PictureBox2 As Windows.Forms.PictureBox
    Friend WithEvents Panel2 As Windows.Forms.Panel
    Friend WithEvents Splitter1 As Windows.Forms.Splitter
    Friend WithEvents txtStep As Windows.Forms.TextBox
    Friend WithEvents Label_Name As Windows.Forms.Label
    Friend WithEvents txtComp As Windows.Forms.TextBox
    Friend WithEvents btn_Search As Windows.Forms.Button
    Friend WithEvents dgv_info As Windows.Forms.DataGridView
    Friend WithEvents laUserName As Windows.Forms.Label
    Friend WithEvents Button1 As Windows.Forms.Button
    Friend WithEvents trv1 As Windows.Forms.TreeView
    Friend WithEvents trv2 As Windows.Forms.TreeView
    Friend WithEvents lstComp As Windows.Forms.ListBox
    Friend WithEvents lstSuf As Windows.Forms.ListBox
    Friend WithEvents Label4 As Windows.Forms.Label
    Friend WithEvents Label3 As Windows.Forms.Label
    Friend WithEvents Label5 As Windows.Forms.Label
End Class
