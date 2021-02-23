<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Change_Add_Tree
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Change_Add_Tree))
        Me.lstChange = New System.Windows.Forms.ListBox()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Splitter1 = New System.Windows.Forms.Splitter()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txtSelectedApp = New System.Windows.Forms.TextBox()
        Me.btn_DBUP = New System.Windows.Forms.Button()
        Me.la_Help = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.txtComp_in = New System.Windows.Forms.TextBox()
        Me.txtSuffix_in = New System.Windows.Forms.TextBox()
        Me.txtStep_in = New System.Windows.Forms.TextBox()
        Me.txtMod_in = New System.Windows.Forms.TextBox()
        Me.txtPro_in = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lstTree = New System.Windows.Forms.TreeView()
        Me.actionTree = New System.Windows.Forms.TreeView()
        Me.appTree = New System.Windows.Forms.TreeView()
        Me.lstGu = New System.Windows.Forms.ListBox()
        Me.btnAddGridView = New System.Windows.Forms.Button()
        Me.txtExport = New System.Windows.Forms.RichTextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtAppRisk = New System.Windows.Forms.RichTextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtApp = New System.Windows.Forms.RichTextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btn_Reflection = New System.Windows.Forms.Button()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lstChange
        '
        Me.lstChange.Font = New System.Drawing.Font("맑은 고딕", 8.0!)
        Me.lstChange.FormattingEnabled = True
        Me.lstChange.HorizontalScrollbar = True
        Me.lstChange.Location = New System.Drawing.Point(30, 801)
        Me.lstChange.Name = "lstChange"
        Me.lstChange.Size = New System.Drawing.Size(287, 160)
        Me.lstChange.TabIndex = 197
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowTemplate.Height = 23
        Me.DataGridView1.Size = New System.Drawing.Size(1123, 100)
        Me.DataGridView1.TabIndex = 215
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.DataGridView1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 593)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1123, 100)
        Me.Panel2.TabIndex = 217
        '
        'Splitter1
        '
        Me.Splitter1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Splitter1.Location = New System.Drawing.Point(0, 590)
        Me.Splitter1.Name = "Splitter1"
        Me.Splitter1.Size = New System.Drawing.Size(1123, 3)
        Me.Splitter1.TabIndex = 218
        Me.Splitter1.TabStop = False
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btn_Reflection)
        Me.Panel1.Controls.Add(Me.txtSelectedApp)
        Me.Panel1.Controls.Add(Me.btn_DBUP)
        Me.Panel1.Controls.Add(Me.la_Help)
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Controls.Add(Me.txtComp_in)
        Me.Panel1.Controls.Add(Me.txtSuffix_in)
        Me.Panel1.Controls.Add(Me.txtStep_in)
        Me.Panel1.Controls.Add(Me.txtMod_in)
        Me.Panel1.Controls.Add(Me.txtPro_in)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.lstTree)
        Me.Panel1.Controls.Add(Me.actionTree)
        Me.Panel1.Controls.Add(Me.appTree)
        Me.Panel1.Controls.Add(Me.lstGu)
        Me.Panel1.Controls.Add(Me.btnAddGridView)
        Me.Panel1.Controls.Add(Me.txtExport)
        Me.Panel1.Controls.Add(Me.Label17)
        Me.Panel1.Controls.Add(Me.txtAppRisk)
        Me.Panel1.Controls.Add(Me.Label10)
        Me.Panel1.Controls.Add(Me.PictureBox2)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.txtApp)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1123, 590)
        Me.Panel1.TabIndex = 219
        '
        'txtSelectedApp
        '
        Me.txtSelectedApp.BackColor = System.Drawing.SystemColors.Info
        Me.txtSelectedApp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSelectedApp.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.txtSelectedApp.Location = New System.Drawing.Point(815, 197)
        Me.txtSelectedApp.Multiline = True
        Me.txtSelectedApp.Name = "txtSelectedApp"
        Me.txtSelectedApp.Size = New System.Drawing.Size(141, 37)
        Me.txtSelectedApp.TabIndex = 241
        Me.txtSelectedApp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btn_DBUP
        '
        Me.btn_DBUP.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_DBUP.Font = New System.Drawing.Font("맑은 고딕", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.btn_DBUP.Location = New System.Drawing.Point(964, 150)
        Me.btn_DBUP.Name = "btn_DBUP"
        Me.btn_DBUP.Size = New System.Drawing.Size(144, 84)
        Me.btn_DBUP.TabIndex = 240
        Me.btn_DBUP.Text = "Server DB up"
        Me.btn_DBUP.UseVisualStyleBackColor = True
        '
        'la_Help
        '
        Me.la_Help.AutoSize = True
        Me.la_Help.BackColor = System.Drawing.Color.Transparent
        Me.la_Help.Font = New System.Drawing.Font("맑은 고딕", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.la_Help.ForeColor = System.Drawing.Color.RoyalBlue
        Me.la_Help.Location = New System.Drawing.Point(140, 39)
        Me.la_Help.Name = "la_Help"
        Me.la_Help.Size = New System.Drawing.Size(34, 30)
        Me.la_Help.TabIndex = 239
        Me.la_Help.Text = "ⓘ"
        '
        'PictureBox1
        '
        Me.PictureBox1.Cursor = System.Windows.Forms.Cursors.Default
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(169, 65)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(419, 169)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 238
        Me.PictureBox1.TabStop = False
        '
        'txtComp_in
        '
        Me.txtComp_in.BackColor = System.Drawing.SystemColors.Info
        Me.txtComp_in.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtComp_in.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.txtComp_in.ForeColor = System.Drawing.Color.Gray
        Me.txtComp_in.Location = New System.Drawing.Point(1020, 6)
        Me.txtComp_in.Name = "txtComp_in"
        Me.txtComp_in.Size = New System.Drawing.Size(100, 23)
        Me.txtComp_in.TabIndex = 237
        '
        'txtSuffix_in
        '
        Me.txtSuffix_in.BackColor = System.Drawing.SystemColors.Info
        Me.txtSuffix_in.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSuffix_in.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.txtSuffix_in.ForeColor = System.Drawing.Color.Gray
        Me.txtSuffix_in.Location = New System.Drawing.Point(914, 6)
        Me.txtSuffix_in.Name = "txtSuffix_in"
        Me.txtSuffix_in.Size = New System.Drawing.Size(100, 23)
        Me.txtSuffix_in.TabIndex = 237
        '
        'txtStep_in
        '
        Me.txtStep_in.BackColor = System.Drawing.SystemColors.Info
        Me.txtStep_in.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtStep_in.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.txtStep_in.ForeColor = System.Drawing.Color.Gray
        Me.txtStep_in.Location = New System.Drawing.Point(808, 6)
        Me.txtStep_in.Name = "txtStep_in"
        Me.txtStep_in.Size = New System.Drawing.Size(100, 23)
        Me.txtStep_in.TabIndex = 237
        '
        'txtMod_in
        '
        Me.txtMod_in.BackColor = System.Drawing.SystemColors.Info
        Me.txtMod_in.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMod_in.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.txtMod_in.ForeColor = System.Drawing.Color.Gray
        Me.txtMod_in.Location = New System.Drawing.Point(704, 6)
        Me.txtMod_in.Name = "txtMod_in"
        Me.txtMod_in.Size = New System.Drawing.Size(100, 23)
        Me.txtMod_in.TabIndex = 237
        '
        'txtPro_in
        '
        Me.txtPro_in.BackColor = System.Drawing.SystemColors.Info
        Me.txtPro_in.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPro_in.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.txtPro_in.ForeColor = System.Drawing.Color.Gray
        Me.txtPro_in.Location = New System.Drawing.Point(598, 6)
        Me.txtPro_in.Name = "txtPro_in"
        Me.txtPro_in.Size = New System.Drawing.Size(100, 23)
        Me.txtPro_in.TabIndex = 237
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("맑은 고딕", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Gray
        Me.Label3.Location = New System.Drawing.Point(295, 50)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(84, 20)
        Me.Label3.TabIndex = 233
        Me.Label3.Text = "변경점 List"
        '
        'lstTree
        '
        Me.lstTree.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lstTree.Font = New System.Drawing.Font("맑은 고딕", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.lstTree.Location = New System.Drawing.Point(196, 76)
        Me.lstTree.Name = "lstTree"
        Me.lstTree.Size = New System.Drawing.Size(287, 200)
        Me.lstTree.TabIndex = 230
        '
        'actionTree
        '
        Me.actionTree.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.actionTree.Font = New System.Drawing.Font("맑은 고딕", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.actionTree.Location = New System.Drawing.Point(196, 299)
        Me.actionTree.Name = "actionTree"
        Me.actionTree.Size = New System.Drawing.Size(287, 287)
        Me.actionTree.TabIndex = 231
        '
        'appTree
        '
        Me.appTree.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.appTree.Font = New System.Drawing.Font("맑은 고딕", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.appTree.Location = New System.Drawing.Point(13, 76)
        Me.appTree.Name = "appTree"
        Me.appTree.Size = New System.Drawing.Size(180, 510)
        Me.appTree.TabIndex = 229
        '
        'lstGu
        '
        Me.lstGu.Font = New System.Drawing.Font("맑은 고딕", 8.0!)
        Me.lstGu.FormattingEnabled = True
        Me.lstGu.HorizontalScrollbar = True
        Me.lstGu.Location = New System.Drawing.Point(815, 75)
        Me.lstGu.Name = "lstGu"
        Me.lstGu.Size = New System.Drawing.Size(142, 69)
        Me.lstGu.TabIndex = 228
        '
        'btnAddGridView
        '
        Me.btnAddGridView.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAddGridView.Font = New System.Drawing.Font("맑은 고딕", 11.0!, System.Drawing.FontStyle.Bold)
        Me.btnAddGridView.ForeColor = System.Drawing.Color.Gray
        Me.btnAddGridView.Location = New System.Drawing.Point(964, 75)
        Me.btnAddGridView.Name = "btnAddGridView"
        Me.btnAddGridView.Size = New System.Drawing.Size(143, 69)
        Me.btnAddGridView.TabIndex = 218
        Me.btnAddGridView.Text = "Add"
        Me.btnAddGridView.UseVisualStyleBackColor = True
        '
        'txtExport
        '
        Me.txtExport.BackColor = System.Drawing.Color.White
        Me.txtExport.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtExport.Font = New System.Drawing.Font("맑은 고딕", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.txtExport.Location = New System.Drawing.Point(814, 347)
        Me.txtExport.Name = "txtExport"
        Me.txtExport.Size = New System.Drawing.Size(291, 235)
        Me.txtExport.TabIndex = 215
        Me.txtExport.Text = ""
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("맑은 고딕", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.Gray
        Me.Label17.Location = New System.Drawing.Point(810, 324)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(209, 20)
        Me.Label17.TabIndex = 225
        Me.Label17.Text = "변경점 검증방법(Expert 인원)"
        '
        'txtAppRisk
        '
        Me.txtAppRisk.BackColor = System.Drawing.Color.White
        Me.txtAppRisk.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAppRisk.Font = New System.Drawing.Font("맑은 고딕", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.txtAppRisk.Location = New System.Drawing.Point(489, 347)
        Me.txtAppRisk.Name = "txtAppRisk"
        Me.txtAppRisk.Size = New System.Drawing.Size(319, 235)
        Me.txtAppRisk.TabIndex = 216
        Me.txtAppRisk.Text = "                           "
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("맑은 고딕", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Gray
        Me.Label10.Location = New System.Drawing.Point(489, 324)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(87, 20)
        Me.Label10.TabIndex = 226
        Me.Label10.Text = "Risk Factor"
        '
        'PictureBox2
        '
        Me.PictureBox2.BackgroundImage = CType(resources.GetObject("PictureBox2.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox2.Location = New System.Drawing.Point(13, 5)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(216, 25)
        Me.PictureBox2.TabIndex = 224
        Me.PictureBox2.TabStop = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("맑은 고딕", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.DimGray
        Me.Label8.Location = New System.Drawing.Point(228, 5)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(150, 20)
        Me.Label8.TabIndex = 223
        Me.Label8.Text = "검증계획서_검증방법"
        '
        'txtApp
        '
        Me.txtApp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtApp.Font = New System.Drawing.Font("맑은 고딕", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.txtApp.Location = New System.Drawing.Point(490, 75)
        Me.txtApp.Name = "txtApp"
        Me.txtApp.Size = New System.Drawing.Size(318, 241)
        Me.txtApp.TabIndex = 217
        Me.txtApp.Tag = "아"
        Me.txtApp.Text = ""
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("맑은 고딕", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Gray
        Me.Label7.Location = New System.Drawing.Point(489, 49)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(54, 20)
        Me.Label7.TabIndex = 221
        Me.Label7.Text = "변경점"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("맑은 고딕", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Gray
        Me.Label1.Location = New System.Drawing.Point(819, 174)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(128, 20)
        Me.Label1.TabIndex = 220
        Me.Label1.Text = "현재 선택 된 App"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("맑은 고딕", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Gray
        Me.Label5.Location = New System.Drawing.Point(814, 52)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(69, 20)
        Me.Label5.TabIndex = 220
        Me.Label5.Text = "검증유형"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("맑은 고딕", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Gray
        Me.Label4.Location = New System.Drawing.Point(295, 276)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(90, 20)
        Me.Label4.TabIndex = 222
        Me.Label4.Text = "Test Action"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("맑은 고딕", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Gray
        Me.Label2.Location = New System.Drawing.Point(34, 52)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 20)
        Me.Label2.TabIndex = 219
        Me.Label2.Text = "App, Feature"
        '
        'btn_Reflection
        '
        Me.btn_Reflection.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Reflection.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.btn_Reflection.Location = New System.Drawing.Point(964, 240)
        Me.btn_Reflection.Name = "btn_Reflection"
        Me.btn_Reflection.Size = New System.Drawing.Size(144, 36)
        Me.btn_Reflection.TabIndex = 242
        Me.btn_Reflection.Text = "Reflection"
        Me.btn_Reflection.UseVisualStyleBackColor = True
        '
        'Change_Add_Tree
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1123, 693)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Splitter1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.lstChange)
        Me.Name = "Change_Add_Tree"
        Me.Text = "Change_Add_Tree"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lstChange As Windows.Forms.ListBox
    Friend WithEvents DataGridView1 As Windows.Forms.DataGridView
    Friend WithEvents Panel2 As Windows.Forms.Panel
    Friend WithEvents Splitter1 As Windows.Forms.Splitter
    Friend WithEvents Panel1 As Windows.Forms.Panel
    Friend WithEvents Label3 As Windows.Forms.Label
    Friend WithEvents lstTree As Windows.Forms.TreeView
    Friend WithEvents actionTree As Windows.Forms.TreeView
    Friend WithEvents appTree As Windows.Forms.TreeView
    Friend WithEvents lstGu As Windows.Forms.ListBox
    Friend WithEvents btnAddGridView As Windows.Forms.Button
    Friend WithEvents txtExport As Windows.Forms.RichTextBox
    Friend WithEvents Label17 As Windows.Forms.Label
    Friend WithEvents txtAppRisk As Windows.Forms.RichTextBox
    Friend WithEvents Label10 As Windows.Forms.Label
    Friend WithEvents PictureBox2 As Windows.Forms.PictureBox
    Friend WithEvents Label8 As Windows.Forms.Label
    Friend WithEvents txtApp As Windows.Forms.RichTextBox
    Friend WithEvents Label7 As Windows.Forms.Label
    Friend WithEvents Label5 As Windows.Forms.Label
    Friend WithEvents Label4 As Windows.Forms.Label
    Friend WithEvents Label2 As Windows.Forms.Label
    Friend WithEvents txtSuffix_in As Windows.Forms.TextBox
    Friend WithEvents txtStep_in As Windows.Forms.TextBox
    Friend WithEvents txtMod_in As Windows.Forms.TextBox
    Friend WithEvents txtPro_in As Windows.Forms.TextBox
    Friend WithEvents txtComp_in As Windows.Forms.TextBox
    Friend WithEvents la_Help As Windows.Forms.Label
    Friend WithEvents PictureBox1 As Windows.Forms.PictureBox
    Friend WithEvents btn_DBUP As Windows.Forms.Button
    Friend WithEvents txtSelectedApp As Windows.Forms.TextBox
    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents btn_Reflection As Windows.Forms.Button
End Class
