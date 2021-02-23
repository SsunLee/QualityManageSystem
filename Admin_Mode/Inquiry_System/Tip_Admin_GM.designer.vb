<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Tip_Admin_GM
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Tip_Admin_GM))
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.TypeTxt = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.FeaTxt = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.btnDel = New System.Windows.Forms.Button()
        Me.btnMod = New System.Windows.Forms.Button()
        Me.cbSta = New System.Windows.Forms.ComboBox()
        Me.PriTxt = New System.Windows.Forms.ComboBox()
        Me.ImportV = New System.Windows.Forms.ComboBox()
        Me.AppTxt = New System.Windows.Forms.TextBox()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.AroundTest = New System.Windows.Forms.TextBox()
        Me.Default_Test = New System.Windows.Forms.TextBox()
        Me.txtFeaDes = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
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
        Me.DataGridView1.Location = New System.Drawing.Point(12, 67)
        Me.DataGridView1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowTemplate.Height = 23
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(1012, 287)
        Me.DataGridView1.TabIndex = 140
        '
        'TypeTxt
        '
        Me.TypeTxt.Location = New System.Drawing.Point(331, 364)
        Me.TypeTxt.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TypeTxt.Multiline = True
        Me.TypeTxt.Name = "TypeTxt"
        Me.TypeTxt.Size = New System.Drawing.Size(333, 25)
        Me.TypeTxt.TabIndex = 120
        Me.TypeTxt.Tag = "Test Type"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Gray
        Me.Label5.Location = New System.Drawing.Point(269, 364)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(57, 15)
        Me.Label5.TabIndex = 139
        Me.Label5.Text = "Test Type"
        '
        'FeaTxt
        '
        Me.FeaTxt.Location = New System.Drawing.Point(82, 406)
        Me.FeaTxt.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.FeaTxt.Multiline = True
        Me.FeaTxt.Name = "FeaTxt"
        Me.FeaTxt.Size = New System.Drawing.Size(160, 25)
        Me.FeaTxt.TabIndex = 119
        Me.FeaTxt.Tag = "Feature"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Gray
        Me.Label2.Location = New System.Drawing.Point(20, 406)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(46, 15)
        Me.Label2.TabIndex = 138
        Me.Label2.Text = "Feature"
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.White
        Me.Button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.ForeColor = System.Drawing.Color.DimGray
        Me.Button3.Location = New System.Drawing.Point(167, 31)
        Me.Button3.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(75, 29)
        Me.Button3.TabIndex = 129
        Me.Button3.Text = "Refresh"
        Me.Button3.UseVisualStyleBackColor = False
        '
        'btnDel
        '
        Me.btnDel.BackColor = System.Drawing.Color.White
        Me.btnDel.Location = New System.Drawing.Point(932, 398)
        Me.btnDel.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnDel.Name = "btnDel"
        Me.btnDel.Size = New System.Drawing.Size(75, 29)
        Me.btnDel.TabIndex = 128
        Me.btnDel.Text = "Delete"
        Me.btnDel.UseVisualStyleBackColor = False
        '
        'btnMod
        '
        Me.btnMod.BackColor = System.Drawing.Color.White
        Me.btnMod.Location = New System.Drawing.Point(932, 362)
        Me.btnMod.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnMod.Name = "btnMod"
        Me.btnMod.Size = New System.Drawing.Size(75, 29)
        Me.btnMod.TabIndex = 127
        Me.btnMod.Text = "Modify"
        Me.btnMod.UseVisualStyleBackColor = False
        '
        'cbSta
        '
        Me.cbSta.FormattingEnabled = True
        Me.cbSta.Location = New System.Drawing.Point(771, 484)
        Me.cbSta.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cbSta.Name = "cbSta"
        Me.cbSta.Size = New System.Drawing.Size(121, 20)
        Me.cbSta.TabIndex = 126
        Me.cbSta.Tag = "Status"
        '
        'PriTxt
        '
        Me.PriTxt.FormattingEnabled = True
        Me.PriTxt.Location = New System.Drawing.Point(771, 446)
        Me.PriTxt.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.PriTxt.Name = "PriTxt"
        Me.PriTxt.Size = New System.Drawing.Size(121, 20)
        Me.PriTxt.TabIndex = 125
        Me.PriTxt.Tag = "Priority"
        '
        'ImportV
        '
        Me.ImportV.DisplayMember = "Import"
        Me.ImportV.FormattingEnabled = True
        Me.ImportV.Location = New System.Drawing.Point(771, 406)
        Me.ImportV.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ImportV.Name = "ImportV"
        Me.ImportV.Size = New System.Drawing.Size(121, 20)
        Me.ImportV.TabIndex = 124
        Me.ImportV.ValueMember = "Import"
        '
        'AppTxt
        '
        Me.AppTxt.Location = New System.Drawing.Point(83, 365)
        Me.AppTxt.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.AppTxt.Multiline = True
        Me.AppTxt.Name = "AppTxt"
        Me.AppTxt.Size = New System.Drawing.Size(160, 25)
        Me.AppTxt.TabIndex = 118
        Me.AppTxt.Tag = "App"
        '
        'txtName
        '
        Me.txtName.Location = New System.Drawing.Point(773, 367)
        Me.txtName.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtName.Multiline = True
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(119, 25)
        Me.txtName.TabIndex = 123
        Me.txtName.Tag = "담당자"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Gray
        Me.Label8.Location = New System.Drawing.Point(21, 365)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(29, 15)
        Me.Label8.TabIndex = 137
        Me.Label8.Text = "App"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Gray
        Me.Label7.Location = New System.Drawing.Point(717, 368)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(43, 15)
        Me.Label7.TabIndex = 136
        Me.Label7.Text = "담당자"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Gray
        Me.Label6.Location = New System.Drawing.Point(266, 513)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(47, 15)
        Me.Label6.TabIndex = 134
        Me.Label6.Text = "Around"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Gray
        Me.Label4.Location = New System.Drawing.Point(266, 438)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(59, 15)
        Me.Label4.TabIndex = 135
        Me.Label4.Text = "기본 검증"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Gray
        Me.Label10.Location = New System.Drawing.Point(720, 486)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(40, 15)
        Me.Label10.TabIndex = 131
        Me.Label10.Text = "Status"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Gray
        Me.Label9.Location = New System.Drawing.Point(715, 447)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(45, 15)
        Me.Label9.TabIndex = 132
        Me.Label9.Text = "Priority"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Gray
        Me.Label3.Location = New System.Drawing.Point(692, 410)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(68, 15)
        Me.Label3.TabIndex = 133
        Me.Label3.Text = "Import Y/N"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(12, 8)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(149, 51)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 130
        Me.PictureBox1.TabStop = False
        '
        'AroundTest
        '
        Me.AroundTest.Location = New System.Drawing.Point(331, 486)
        Me.AroundTest.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.AroundTest.Multiline = True
        Me.AroundTest.Name = "AroundTest"
        Me.AroundTest.Size = New System.Drawing.Size(333, 75)
        Me.AroundTest.TabIndex = 122
        Me.AroundTest.Tag = "Around"
        '
        'Default_Test
        '
        Me.Default_Test.Location = New System.Drawing.Point(331, 412)
        Me.Default_Test.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Default_Test.Multiline = True
        Me.Default_Test.Name = "Default_Test"
        Me.Default_Test.Size = New System.Drawing.Size(333, 66)
        Me.Default_Test.TabIndex = 121
        Me.Default_Test.Tag = "기본검증"
        '
        'txtFeaDes
        '
        Me.txtFeaDes.Location = New System.Drawing.Point(82, 446)
        Me.txtFeaDes.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtFeaDes.Multiline = True
        Me.txtFeaDes.Name = "txtFeaDes"
        Me.txtFeaDes.Size = New System.Drawing.Size(160, 115)
        Me.txtFeaDes.TabIndex = 122
        Me.txtFeaDes.Tag = "Feature_Description"
        '
        'Label1
        '
        Me.Label1.AutoEllipsis = True
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Gray
        Me.Label1.Location = New System.Drawing.Point(12, 461)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(68, 30)
        Me.Label1.TabIndex = 134
        Me.Label1.Text = "Feature" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Description"
        '
        'Tip_Admin_GM
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1062, 585)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.TypeTxt)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.FeaTxt)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.btnDel)
        Me.Controls.Add(Me.btnMod)
        Me.Controls.Add(Me.cbSta)
        Me.Controls.Add(Me.PriTxt)
        Me.Controls.Add(Me.ImportV)
        Me.Controls.Add(Me.AppTxt)
        Me.Controls.Add(Me.txtName)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.txtFeaDes)
        Me.Controls.Add(Me.AroundTest)
        Me.Controls.Add(Me.Default_Test)
        Me.Name = "Tip_Admin_GM"
        Me.Text = "Tip_Admin_GM"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents DataGridView1 As Windows.Forms.DataGridView
    Friend WithEvents TypeTxt As Windows.Forms.TextBox
    Friend WithEvents Label5 As Windows.Forms.Label
    Friend WithEvents FeaTxt As Windows.Forms.TextBox
    Friend WithEvents Label2 As Windows.Forms.Label
    Friend WithEvents Button3 As Windows.Forms.Button
    Friend WithEvents btnDel As Windows.Forms.Button
    Friend WithEvents btnMod As Windows.Forms.Button
    Friend WithEvents cbSta As Windows.Forms.ComboBox
    Friend WithEvents PriTxt As Windows.Forms.ComboBox
    Friend WithEvents ImportV As Windows.Forms.ComboBox
    Friend WithEvents AppTxt As Windows.Forms.TextBox
    Friend WithEvents txtName As Windows.Forms.TextBox
    Friend WithEvents Label8 As Windows.Forms.Label
    Friend WithEvents Label7 As Windows.Forms.Label
    Friend WithEvents Label6 As Windows.Forms.Label
    Friend WithEvents Label4 As Windows.Forms.Label
    Friend WithEvents Label10 As Windows.Forms.Label
    Friend WithEvents Label9 As Windows.Forms.Label
    Friend WithEvents Label3 As Windows.Forms.Label
    Friend WithEvents PictureBox1 As Windows.Forms.PictureBox
    Friend WithEvents AroundTest As Windows.Forms.TextBox
    Friend WithEvents Default_Test As Windows.Forms.TextBox
    Friend WithEvents txtFeaDes As Windows.Forms.TextBox
    Friend WithEvents Label1 As Windows.Forms.Label
End Class
