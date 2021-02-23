<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AppFeature_Edit
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AppFeature_Edit))
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cbFea = New System.Windows.Forms.ComboBox()
        Me.txtResult = New System.Windows.Forms.TextBox()
        Me.cbApp = New System.Windows.Forms.ComboBox()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.addDes = New System.Windows.Forms.TextBox()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.addApp = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.addFea = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.modDes = New System.Windows.Forms.TextBox()
        Me.btnMod = New System.Windows.Forms.Button()
        Me.modApp = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.modFea = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.btnDel = New System.Windows.Forms.Button()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.delFea = New System.Windows.Forms.ComboBox()
        Me.delApp = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Gray
        Me.Label2.Location = New System.Drawing.Point(203, 28)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(46, 15)
        Me.Label2.TabIndex = 137
        Me.Label2.Text = "Feature"
        '
        'txtName
        '
        Me.txtName.Font = New System.Drawing.Font("Malgun Gothic", 9.0!)
        Me.txtName.Location = New System.Drawing.Point(778, 41)
        Me.txtName.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtName.Multiline = True
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(169, 25)
        Me.txtName.TabIndex = 16
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Gray
        Me.Label8.Location = New System.Drawing.Point(8, 28)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(29, 15)
        Me.Label8.TabIndex = 125
        Me.Label8.Text = "App"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Gray
        Me.Label7.Location = New System.Drawing.Point(729, 41)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(43, 15)
        Me.Label7.TabIndex = 124
        Me.Label7.Text = "담당자"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(7, 10)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(149, 51)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 118
        Me.PictureBox1.TabStop = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cbFea)
        Me.GroupBox1.Controls.Add(Me.txtResult)
        Me.GroupBox1.Controls.Add(Me.cbApp)
        Me.GroupBox1.Controls.Add(Me.btnSearch)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.GroupBox1.Location = New System.Drawing.Point(7, 85)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox1.Size = New System.Drawing.Size(471, 172)
        Me.GroupBox1.TabIndex = 141
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "검색"
        '
        'cbFea
        '
        Me.cbFea.Font = New System.Drawing.Font("Malgun Gothic", 9.0!)
        Me.cbFea.FormattingEnabled = True
        Me.cbFea.Location = New System.Drawing.Point(206, 51)
        Me.cbFea.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cbFea.Name = "cbFea"
        Me.cbFea.Size = New System.Drawing.Size(160, 23)
        Me.cbFea.TabIndex = 2
        '
        'txtResult
        '
        Me.txtResult.Font = New System.Drawing.Font("Malgun Gothic", 9.0!)
        Me.txtResult.Location = New System.Drawing.Point(11, 84)
        Me.txtResult.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtResult.Multiline = True
        Me.txtResult.Name = "txtResult"
        Me.txtResult.Size = New System.Drawing.Size(355, 66)
        Me.txtResult.TabIndex = 3
        '
        'cbApp
        '
        Me.cbApp.Font = New System.Drawing.Font("Malgun Gothic", 9.0!)
        Me.cbApp.FormattingEnabled = True
        Me.cbApp.Location = New System.Drawing.Point(11, 51)
        Me.cbApp.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cbApp.Name = "cbApp"
        Me.cbApp.Size = New System.Drawing.Size(160, 23)
        Me.cbApp.TabIndex = 1
        '
        'btnSearch
        '
        Me.btnSearch.BackColor = System.Drawing.Color.White
        Me.btnSearch.Location = New System.Drawing.Point(383, 50)
        Me.btnSearch.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(75, 101)
        Me.btnSearch.TabIndex = 4
        Me.btnSearch.Text = "검색"
        Me.btnSearch.UseVisualStyleBackColor = False
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label14)
        Me.GroupBox3.Controls.Add(Me.addDes)
        Me.GroupBox3.Controls.Add(Me.btnAdd)
        Me.GroupBox3.Controls.Add(Me.addApp)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Controls.Add(Me.addFea)
        Me.GroupBox3.Controls.Add(Me.Label11)
        Me.GroupBox3.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.GroupBox3.Location = New System.Drawing.Point(7, 265)
        Me.GroupBox3.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox3.Size = New System.Drawing.Size(471, 210)
        Me.GroupBox3.TabIndex = 144
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "추가"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.Gray
        Me.Label14.Location = New System.Drawing.Point(8, 85)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(112, 15)
        Me.Label14.TabIndex = 144
        Me.Label14.Text = "Feature_Description"
        '
        'addDes
        '
        Me.addDes.Font = New System.Drawing.Font("Malgun Gothic", 9.0!)
        Me.addDes.Location = New System.Drawing.Point(11, 119)
        Me.addDes.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.addDes.Multiline = True
        Me.addDes.Name = "addDes"
        Me.addDes.Size = New System.Drawing.Size(355, 80)
        Me.addDes.TabIndex = 7
        '
        'btnAdd
        '
        Me.btnAdd.BackColor = System.Drawing.Color.White
        Me.btnAdd.Location = New System.Drawing.Point(383, 50)
        Me.btnAdd.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(75, 139)
        Me.btnAdd.TabIndex = 8
        Me.btnAdd.Text = "추가"
        Me.btnAdd.UseVisualStyleBackColor = False
        '
        'addApp
        '
        Me.addApp.Font = New System.Drawing.Font("Malgun Gothic", 9.0!)
        Me.addApp.Location = New System.Drawing.Point(11, 55)
        Me.addApp.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.addApp.Multiline = True
        Me.addApp.Name = "addApp"
        Me.addApp.Size = New System.Drawing.Size(160, 25)
        Me.addApp.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Gray
        Me.Label1.Location = New System.Drawing.Point(8, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(29, 15)
        Me.Label1.TabIndex = 125
        Me.Label1.Text = "App"
        '
        'addFea
        '
        Me.addFea.Font = New System.Drawing.Font("Malgun Gothic", 9.0!)
        Me.addFea.Location = New System.Drawing.Point(206, 55)
        Me.addFea.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.addFea.Multiline = True
        Me.addFea.Name = "addFea"
        Me.addFea.Size = New System.Drawing.Size(160, 25)
        Me.addFea.TabIndex = 6
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Gray
        Me.Label11.Location = New System.Drawing.Point(203, 28)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(46, 15)
        Me.Label11.TabIndex = 137
        Me.Label11.Text = "Feature"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.modDes)
        Me.GroupBox2.Controls.Add(Me.btnMod)
        Me.GroupBox2.Controls.Add(Me.modApp)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.modFea)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.GroupBox2.Location = New System.Drawing.Point(484, 85)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox2.Size = New System.Drawing.Size(470, 210)
        Me.GroupBox2.TabIndex = 145
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "수정"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Gray
        Me.Label4.Location = New System.Drawing.Point(8, 85)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(112, 15)
        Me.Label4.TabIndex = 144
        Me.Label4.Text = "Feature_Description"
        '
        'modDes
        '
        Me.modDes.Font = New System.Drawing.Font("Malgun Gothic", 9.0!)
        Me.modDes.Location = New System.Drawing.Point(11, 121)
        Me.modDes.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.modDes.Multiline = True
        Me.modDes.Name = "modDes"
        Me.modDes.Size = New System.Drawing.Size(355, 80)
        Me.modDes.TabIndex = 11
        '
        'btnMod
        '
        Me.btnMod.BackColor = System.Drawing.Color.White
        Me.btnMod.Location = New System.Drawing.Point(383, 50)
        Me.btnMod.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnMod.Name = "btnMod"
        Me.btnMod.Size = New System.Drawing.Size(75, 139)
        Me.btnMod.TabIndex = 12
        Me.btnMod.Text = "수정"
        Me.btnMod.UseVisualStyleBackColor = False
        '
        'modApp
        '
        Me.modApp.Font = New System.Drawing.Font("Malgun Gothic", 9.0!)
        Me.modApp.Location = New System.Drawing.Point(11, 55)
        Me.modApp.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.modApp.Multiline = True
        Me.modApp.Name = "modApp"
        Me.modApp.Size = New System.Drawing.Size(160, 25)
        Me.modApp.TabIndex = 9
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Gray
        Me.Label5.Location = New System.Drawing.Point(8, 28)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(29, 15)
        Me.Label5.TabIndex = 125
        Me.Label5.Text = "App"
        '
        'modFea
        '
        Me.modFea.Font = New System.Drawing.Font("Malgun Gothic", 9.0!)
        Me.modFea.Location = New System.Drawing.Point(206, 55)
        Me.modFea.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.modFea.Multiline = True
        Me.modFea.Name = "modFea"
        Me.modFea.Size = New System.Drawing.Size(160, 25)
        Me.modFea.TabIndex = 10
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Gray
        Me.Label6.Location = New System.Drawing.Point(203, 28)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(46, 15)
        Me.Label6.TabIndex = 137
        Me.Label6.Text = "Feature"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.btnDel)
        Me.GroupBox4.Controls.Add(Me.Label13)
        Me.GroupBox4.Controls.Add(Me.Label15)
        Me.GroupBox4.Controls.Add(Me.delFea)
        Me.GroupBox4.Controls.Add(Me.delApp)
        Me.GroupBox4.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.GroupBox4.Location = New System.Drawing.Point(484, 326)
        Me.GroupBox4.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox4.Size = New System.Drawing.Size(470, 110)
        Me.GroupBox4.TabIndex = 146
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "삭제"
        '
        'btnDel
        '
        Me.btnDel.BackColor = System.Drawing.Color.White
        Me.btnDel.Location = New System.Drawing.Point(383, 50)
        Me.btnDel.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnDel.Name = "btnDel"
        Me.btnDel.Size = New System.Drawing.Size(75, 38)
        Me.btnDel.TabIndex = 15
        Me.btnDel.Text = "삭제"
        Me.btnDel.UseVisualStyleBackColor = False
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Gray
        Me.Label13.Location = New System.Drawing.Point(8, 28)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(29, 15)
        Me.Label13.TabIndex = 125
        Me.Label13.Text = "App"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.Gray
        Me.Label15.Location = New System.Drawing.Point(203, 28)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(46, 15)
        Me.Label15.TabIndex = 137
        Me.Label15.Text = "Feature"
        '
        'delFea
        '
        Me.delFea.Font = New System.Drawing.Font("Malgun Gothic", 9.0!)
        Me.delFea.FormattingEnabled = True
        Me.delFea.Location = New System.Drawing.Point(206, 58)
        Me.delFea.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.delFea.Name = "delFea"
        Me.delFea.Size = New System.Drawing.Size(160, 23)
        Me.delFea.TabIndex = 14
        '
        'delApp
        '
        Me.delApp.Font = New System.Drawing.Font("Malgun Gothic", 9.0!)
        Me.delApp.FormattingEnabled = True
        Me.delApp.Location = New System.Drawing.Point(11, 58)
        Me.delApp.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.delApp.Name = "delApp"
        Me.delApp.Size = New System.Drawing.Size(160, 23)
        Me.delApp.TabIndex = 13
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Malgun Gothic", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.DimGray
        Me.Label3.Location = New System.Drawing.Point(162, 10)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(143, 30)
        Me.Label3.TabIndex = 145
        Me.Label3.Text = "App & Feature"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Malgun Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.DimGray
        Me.Label9.Location = New System.Drawing.Point(162, 55)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(197, 21)
        Me.Label9.TabIndex = 147
        Me.Label9.Text = "※ 검색 후 사용 해 주세요"
        '
        'AppFeature_Edit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(967, 492)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.txtName)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.PictureBox1)
        Me.Font = New System.Drawing.Font("Malgun Gothic", 9.0!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "AppFeature_Edit"
        Me.Text = "AppFeature"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label2 As Windows.Forms.Label
    Friend WithEvents txtName As Windows.Forms.TextBox
    Friend WithEvents Label8 As Windows.Forms.Label
    Friend WithEvents Label7 As Windows.Forms.Label
    Friend WithEvents PictureBox1 As Windows.Forms.PictureBox
    Friend WithEvents GroupBox1 As Windows.Forms.GroupBox
    Friend WithEvents txtResult As Windows.Forms.TextBox
    Friend WithEvents btnSearch As Windows.Forms.Button
    Friend WithEvents GroupBox3 As Windows.Forms.GroupBox
    Friend WithEvents Label14 As Windows.Forms.Label
    Friend WithEvents addDes As Windows.Forms.TextBox
    Friend WithEvents btnAdd As Windows.Forms.Button
    Friend WithEvents addApp As Windows.Forms.TextBox
    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents addFea As Windows.Forms.TextBox
    Friend WithEvents Label11 As Windows.Forms.Label
    Friend WithEvents GroupBox2 As Windows.Forms.GroupBox
    Friend WithEvents Label4 As Windows.Forms.Label
    Friend WithEvents modDes As Windows.Forms.TextBox
    Friend WithEvents btnMod As Windows.Forms.Button
    Friend WithEvents modApp As Windows.Forms.TextBox
    Friend WithEvents Label5 As Windows.Forms.Label
    Friend WithEvents modFea As Windows.Forms.TextBox
    Friend WithEvents Label6 As Windows.Forms.Label
    Friend WithEvents GroupBox4 As Windows.Forms.GroupBox
    Friend WithEvents btnDel As Windows.Forms.Button
    Friend WithEvents Label13 As Windows.Forms.Label
    Friend WithEvents Label15 As Windows.Forms.Label
    Friend WithEvents delFea As Windows.Forms.ComboBox
    Friend WithEvents delApp As Windows.Forms.ComboBox
    Friend WithEvents Label3 As Windows.Forms.Label
    Friend WithEvents cbFea As Windows.Forms.ComboBox
    Friend WithEvents cbApp As Windows.Forms.ComboBox
    Friend WithEvents Label9 As Windows.Forms.Label
End Class
