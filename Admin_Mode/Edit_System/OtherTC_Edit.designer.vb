<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class OtherTC_Edit
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(OtherTC_Edit))
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Min_CB = New System.Windows.Forms.ComboBox()
        Me.DaeCB = New System.Windows.Forms.ComboBox()
        Me.Mid_CB = New System.Windows.Forms.ComboBox()
        Me.PriTxt = New System.Windows.Forms.TextBox()
        Me.DetectedTxt = New System.Windows.Forms.TextBox()
        Me.MDTxt = New System.Windows.Forms.TextBox()
        Me.TCPurposeTxt = New System.Windows.Forms.TextBox()
        Me.TCnameTxt = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.btnDel = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.btnMod = New System.Windows.Forms.Button()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtFileName = New System.Windows.Forms.TextBox()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.btnRe = New System.Windows.Forms.Button()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonFace
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(12, 41)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowTemplate.Height = 23
        Me.DataGridView1.Size = New System.Drawing.Size(1045, 262)
        Me.DataGridView1.TabIndex = 1
        '
        'Button1
        '
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Button1.Location = New System.Drawing.Point(832, 6)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(109, 29)
        Me.Button1.TabIndex = 15
        Me.Button1.Text = "파일 경로확인"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Min_CB
        '
        Me.Min_CB.BackColor = System.Drawing.SystemColors.Info
        Me.Min_CB.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Min_CB.ForeColor = System.Drawing.Color.DimGray
        Me.Min_CB.FormattingEnabled = True
        Me.Min_CB.Location = New System.Drawing.Point(470, 338)
        Me.Min_CB.Name = "Min_CB"
        Me.Min_CB.Size = New System.Drawing.Size(223, 23)
        Me.Min_CB.TabIndex = 4
        Me.Min_CB.Tag = "소분류"
        '
        'DaeCB
        '
        Me.DaeCB.BackColor = System.Drawing.SystemColors.Info
        Me.DaeCB.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.DaeCB.ForeColor = System.Drawing.Color.DimGray
        Me.DaeCB.FormattingEnabled = True
        Me.DaeCB.Location = New System.Drawing.Point(14, 338)
        Me.DaeCB.Name = "DaeCB"
        Me.DaeCB.Size = New System.Drawing.Size(222, 23)
        Me.DaeCB.TabIndex = 2
        Me.DaeCB.Tag = "대분류"
        '
        'Mid_CB
        '
        Me.Mid_CB.BackColor = System.Drawing.SystemColors.Info
        Me.Mid_CB.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Mid_CB.ForeColor = System.Drawing.Color.DimGray
        Me.Mid_CB.FormattingEnabled = True
        Me.Mid_CB.Location = New System.Drawing.Point(242, 338)
        Me.Mid_CB.Name = "Mid_CB"
        Me.Mid_CB.Size = New System.Drawing.Size(222, 23)
        Me.Mid_CB.TabIndex = 3
        Me.Mid_CB.Tag = "중분류"
        '
        'PriTxt
        '
        Me.PriTxt.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.PriTxt.ForeColor = System.Drawing.Color.DimGray
        Me.PriTxt.Location = New System.Drawing.Point(703, 392)
        Me.PriTxt.Multiline = True
        Me.PriTxt.Name = "PriTxt"
        Me.PriTxt.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.PriTxt.Size = New System.Drawing.Size(356, 91)
        Me.PriTxt.TabIndex = 8
        Me.PriTxt.Tag = "등급별 진행기준"
        '
        'DetectedTxt
        '
        Me.DetectedTxt.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.DetectedTxt.ForeColor = System.Drawing.Color.DimGray
        Me.DetectedTxt.Location = New System.Drawing.Point(243, 391)
        Me.DetectedTxt.Multiline = True
        Me.DetectedTxt.Name = "DetectedTxt"
        Me.DetectedTxt.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.DetectedTxt.Size = New System.Drawing.Size(450, 92)
        Me.DetectedTxt.TabIndex = 7
        Me.DetectedTxt.Tag = "검증항목"
        '
        'MDTxt
        '
        Me.MDTxt.BackColor = System.Drawing.Color.PeachPuff
        Me.MDTxt.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.MDTxt.ForeColor = System.Drawing.Color.DimGray
        Me.MDTxt.Location = New System.Drawing.Point(15, 515)
        Me.MDTxt.Name = "MDTxt"
        Me.MDTxt.Size = New System.Drawing.Size(221, 23)
        Me.MDTxt.TabIndex = 9
        Me.MDTxt.Tag = "투입 MD"
        '
        'TCPurposeTxt
        '
        Me.TCPurposeTxt.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.TCPurposeTxt.ForeColor = System.Drawing.Color.DimGray
        Me.TCPurposeTxt.Location = New System.Drawing.Point(15, 392)
        Me.TCPurposeTxt.Multiline = True
        Me.TCPurposeTxt.Name = "TCPurposeTxt"
        Me.TCPurposeTxt.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TCPurposeTxt.Size = New System.Drawing.Size(221, 91)
        Me.TCPurposeTxt.TabIndex = 6
        Me.TCPurposeTxt.Tag = "목적"
        '
        'TCnameTxt
        '
        Me.TCnameTxt.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.TCnameTxt.ForeColor = System.Drawing.Color.DimGray
        Me.TCnameTxt.Location = New System.Drawing.Point(703, 333)
        Me.TCnameTxt.Multiline = True
        Me.TCnameTxt.Name = "TCnameTxt"
        Me.TCnameTxt.Size = New System.Drawing.Size(356, 28)
        Me.TCnameTxt.TabIndex = 5
        Me.TCnameTxt.Tag = "TC명"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.DimGray
        Me.Label6.Location = New System.Drawing.Point(12, 497)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(56, 15)
        Me.Label6.TabIndex = 43
        Me.Label6.Text = "투입 MD"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.DimGray
        Me.Label4.Location = New System.Drawing.Point(240, 373)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(55, 15)
        Me.Label4.TabIndex = 42
        Me.Label4.Text = "검증항목"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.DimGray
        Me.Label3.Location = New System.Drawing.Point(12, 373)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(31, 15)
        Me.Label3.TabIndex = 41
        Me.Label3.Text = "목적"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.DimGray
        Me.Label8.Location = New System.Drawing.Point(468, 320)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(43, 15)
        Me.Label8.TabIndex = 40
        Me.Label8.Text = "소분류"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.DimGray
        Me.Label9.Location = New System.Drawing.Point(12, 320)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(43, 15)
        Me.Label9.TabIndex = 39
        Me.Label9.Text = "대분류"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.DimGray
        Me.Label7.Location = New System.Drawing.Point(240, 320)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(43, 15)
        Me.Label7.TabIndex = 38
        Me.Label7.Text = "중분류"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.DimGray
        Me.Label1.Location = New System.Drawing.Point(700, 315)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(38, 15)
        Me.Label1.TabIndex = 37
        Me.Label1.Text = "TC 명"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Malgun Gothic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.DimGray
        Me.Label2.Location = New System.Drawing.Point(116, 7)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(84, 25)
        Me.Label2.TabIndex = 36
        Me.Label2.Text = "TC Info."
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(9, 7)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(101, 28)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 35
        Me.PictureBox1.TabStop = False
        '
        'btnDel
        '
        Me.btnDel.BackColor = System.Drawing.Color.White
        Me.btnDel.Font = New System.Drawing.Font("Malgun Gothic", 9.0!)
        Me.btnDel.Location = New System.Drawing.Point(980, 515)
        Me.btnDel.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnDel.Name = "btnDel"
        Me.btnDel.Size = New System.Drawing.Size(75, 29)
        Me.btnDel.TabIndex = 13
        Me.btnDel.Text = "Delete"
        Me.btnDel.UseVisualStyleBackColor = False
        '
        'btnAdd
        '
        Me.btnAdd.BackColor = System.Drawing.Color.White
        Me.btnAdd.Font = New System.Drawing.Font("Malgun Gothic", 9.0!)
        Me.btnAdd.Location = New System.Drawing.Point(818, 515)
        Me.btnAdd.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(75, 29)
        Me.btnAdd.TabIndex = 11
        Me.btnAdd.Text = "Add"
        Me.btnAdd.UseVisualStyleBackColor = False
        '
        'btnMod
        '
        Me.btnMod.BackColor = System.Drawing.Color.White
        Me.btnMod.Font = New System.Drawing.Font("Malgun Gothic", 9.0!)
        Me.btnMod.Location = New System.Drawing.Point(899, 515)
        Me.btnMod.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnMod.Name = "btnMod"
        Me.btnMod.Size = New System.Drawing.Size(75, 29)
        Me.btnMod.TabIndex = 12
        Me.btnMod.Text = "Modify"
        Me.btnMod.UseVisualStyleBackColor = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.DimGray
        Me.Label10.Location = New System.Drawing.Point(700, 364)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(95, 15)
        Me.Label10.TabIndex = 60
        Me.Label10.Text = "등급별 진행기준"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.DimGray
        Me.Label5.Location = New System.Drawing.Point(240, 497)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(43, 15)
        Me.Label5.TabIndex = 37
        Me.Label5.Text = "파일명"
        '
        'txtFileName
        '
        Me.txtFileName.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.txtFileName.ForeColor = System.Drawing.Color.DimGray
        Me.txtFileName.Location = New System.Drawing.Point(243, 515)
        Me.txtFileName.Multiline = True
        Me.txtFileName.Name = "txtFileName"
        Me.txtFileName.Size = New System.Drawing.Size(450, 23)
        Me.txtFileName.TabIndex = 10
        Me.txtFileName.Tag = "파일명"
        '
        'btnClear
        '
        Me.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClear.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.btnClear.Location = New System.Drawing.Point(720, 515)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(75, 29)
        Me.btnClear.TabIndex = 14
        Me.btnClear.Text = "Clear"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'btnRe
        '
        Me.btnRe.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRe.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.btnRe.Location = New System.Drawing.Point(947, 6)
        Me.btnRe.Name = "btnRe"
        Me.btnRe.Size = New System.Drawing.Size(106, 29)
        Me.btnRe.TabIndex = 14
        Me.btnRe.Text = "List Refresh"
        Me.btnRe.UseVisualStyleBackColor = True
        '
        'OtherTC_Edit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1076, 561)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.btnDel)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.btnMod)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.btnRe)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Min_CB)
        Me.Controls.Add(Me.DaeCB)
        Me.Controls.Add(Me.Mid_CB)
        Me.Controls.Add(Me.PriTxt)
        Me.Controls.Add(Me.DetectedTxt)
        Me.Controls.Add(Me.MDTxt)
        Me.Controls.Add(Me.TCPurposeTxt)
        Me.Controls.Add(Me.txtFileName)
        Me.Controls.Add(Me.TCnameTxt)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.PictureBox1)
        Me.Name = "OtherTC_Edit"
        Me.Text = " "
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataGridView1 As Windows.Forms.DataGridView
    Friend WithEvents Button1 As Windows.Forms.Button
    Friend WithEvents Min_CB As Windows.Forms.ComboBox
    Friend WithEvents DaeCB As Windows.Forms.ComboBox
    Friend WithEvents Mid_CB As Windows.Forms.ComboBox
    Friend WithEvents PriTxt As Windows.Forms.TextBox
    Friend WithEvents DetectedTxt As Windows.Forms.TextBox
    Friend WithEvents MDTxt As Windows.Forms.TextBox
    Friend WithEvents TCPurposeTxt As Windows.Forms.TextBox
    Friend WithEvents TCnameTxt As Windows.Forms.TextBox
    Friend WithEvents Label6 As Windows.Forms.Label
    Friend WithEvents Label4 As Windows.Forms.Label
    Friend WithEvents Label3 As Windows.Forms.Label
    Friend WithEvents Label8 As Windows.Forms.Label
    Friend WithEvents Label9 As Windows.Forms.Label
    Friend WithEvents Label7 As Windows.Forms.Label
    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents Label2 As Windows.Forms.Label
    Friend WithEvents PictureBox1 As Windows.Forms.PictureBox
    Friend WithEvents btnDel As Windows.Forms.Button
    Friend WithEvents btnAdd As Windows.Forms.Button
    Friend WithEvents btnMod As Windows.Forms.Button
    Friend WithEvents Label10 As Windows.Forms.Label
    Friend WithEvents Label5 As Windows.Forms.Label
    Friend WithEvents txtFileName As Windows.Forms.TextBox
    Friend WithEvents btnClear As Windows.Forms.Button
    Friend WithEvents btnRe As Windows.Forms.Button
End Class
