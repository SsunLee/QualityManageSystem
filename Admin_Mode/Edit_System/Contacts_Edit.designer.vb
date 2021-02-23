<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Contacts_Edit
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Contacts_Edit))
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cbName = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.txtNum = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnMod = New System.Windows.Forms.Button()
        Me.btnDel = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.addCom = New System.Windows.Forms.ComboBox()
        Me.cb2 = New System.Windows.Forms.ComboBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.GroupBox2.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Malgun Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.DimGray
        Me.Label9.Location = New System.Drawing.Point(316, 27)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(227, 21)
        Me.Label9.TabIndex = 150
        Me.Label9.Text = "※ 업체명은 필수 선택 입니다."
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Malgun Gothic", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.DimGray
        Me.Label3.Location = New System.Drawing.Point(185, 18)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(99, 30)
        Me.Label3.TabIndex = 149
        Me.Label3.Text = "Contacts"
        '
        'cbName
        '
        Me.cbName.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbName.Font = New System.Drawing.Font("Malgun Gothic", 9.0!)
        Me.cbName.FormattingEnabled = True
        Me.cbName.Location = New System.Drawing.Point(382, 55)
        Me.cbName.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cbName.Name = "cbName"
        Me.cbName.Size = New System.Drawing.Size(149, 23)
        Me.cbName.TabIndex = 3
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Gray
        Me.Label8.Location = New System.Drawing.Point(379, 32)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(31, 15)
        Me.Label8.TabIndex = 157
        Me.Label8.Text = "이름"
        '
        'btnAdd
        '
        Me.btnAdd.BackColor = System.Drawing.Color.DodgerBlue
        Me.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAdd.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.btnAdd.ForeColor = System.Drawing.Color.White
        Me.btnAdd.Location = New System.Drawing.Point(740, 27)
        Me.btnAdd.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(75, 25)
        Me.btnAdd.TabIndex = 10
        Me.btnAdd.Text = "추가"
        Me.btnAdd.UseVisualStyleBackColor = False
        '
        'txtNum
        '
        Me.txtNum.Font = New System.Drawing.Font("Malgun Gothic", 9.0!)
        Me.txtNum.Location = New System.Drawing.Point(551, 53)
        Me.txtNum.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtNum.Multiline = True
        Me.txtNum.Name = "txtNum"
        Me.txtNum.Size = New System.Drawing.Size(171, 25)
        Me.txtNum.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Gray
        Me.Label1.Location = New System.Drawing.Point(548, 34)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(55, 15)
        Me.Label1.TabIndex = 158
        Me.Label1.Text = "전화번호"
        '
        'btnMod
        '
        Me.btnMod.BackColor = System.Drawing.Color.DodgerBlue
        Me.btnMod.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnMod.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.btnMod.ForeColor = System.Drawing.Color.White
        Me.btnMod.Location = New System.Drawing.Point(740, 51)
        Me.btnMod.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnMod.Name = "btnMod"
        Me.btnMod.Size = New System.Drawing.Size(75, 25)
        Me.btnMod.TabIndex = 11
        Me.btnMod.Text = "수정"
        Me.btnMod.UseVisualStyleBackColor = False
        '
        'btnDel
        '
        Me.btnDel.BackColor = System.Drawing.Color.DodgerBlue
        Me.btnDel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDel.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.btnDel.ForeColor = System.Drawing.Color.White
        Me.btnDel.Location = New System.Drawing.Point(740, 75)
        Me.btnDel.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnDel.Name = "btnDel"
        Me.btnDel.Size = New System.Drawing.Size(75, 25)
        Me.btnDel.TabIndex = 12
        Me.btnDel.Text = "삭제"
        Me.btnDel.UseVisualStyleBackColor = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtNum)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.btnDel)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.cbName)
        Me.GroupBox2.Controls.Add(Me.addCom)
        Me.GroupBox2.Controls.Add(Me.btnMod)
        Me.GroupBox2.Controls.Add(Me.cb2)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.btnAdd)
        Me.GroupBox2.Font = New System.Drawing.Font("Malgun Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(12, 78)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(849, 118)
        Me.GroupBox2.TabIndex = 159
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "추가, 수정, 삭제"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Gray
        Me.Label6.Location = New System.Drawing.Point(22, 32)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(43, 15)
        Me.Label6.TabIndex = 157
        Me.Label6.Text = "업체명"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Gray
        Me.Label10.Location = New System.Drawing.Point(198, 32)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(31, 15)
        Me.Label10.TabIndex = 157
        Me.Label10.Text = "직급"
        '
        'addCom
        '
        Me.addCom.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.addCom.Font = New System.Drawing.Font("Malgun Gothic", 9.0!)
        Me.addCom.FormattingEnabled = True
        Me.addCom.Location = New System.Drawing.Point(25, 53)
        Me.addCom.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.addCom.Name = "addCom"
        Me.addCom.Size = New System.Drawing.Size(149, 23)
        Me.addCom.TabIndex = 1
        '
        'cb2
        '
        Me.cb2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cb2.Font = New System.Drawing.Font("Malgun Gothic", 9.0!)
        Me.cb2.FormattingEnabled = True
        Me.cb2.Location = New System.Drawing.Point(201, 55)
        Me.cb2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cb2.Name = "cb2"
        Me.cb2.Size = New System.Drawing.Size(149, 23)
        Me.cb2.TabIndex = 2
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(12, 11)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(149, 51)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 148
        Me.PictureBox1.TabStop = False
        '
        'Contacts_Edit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(878, 209)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.PictureBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Contacts_Edit"
        Me.Text = "Contacts"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label9 As Windows.Forms.Label
    Friend WithEvents Label3 As Windows.Forms.Label
    Friend WithEvents PictureBox1 As Windows.Forms.PictureBox
    Friend WithEvents cbName As Windows.Forms.ComboBox
    Friend WithEvents Label8 As Windows.Forms.Label
    Friend WithEvents btnAdd As Windows.Forms.Button
    Friend WithEvents txtNum As Windows.Forms.TextBox
    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents btnMod As Windows.Forms.Button
    Friend WithEvents btnDel As Windows.Forms.Button
    Friend WithEvents GroupBox2 As Windows.Forms.GroupBox
    Friend WithEvents Label6 As Windows.Forms.Label
    Friend WithEvents addCom As Windows.Forms.ComboBox
    Friend WithEvents Label10 As Windows.Forms.Label
    Friend WithEvents cb2 As Windows.Forms.ComboBox
End Class
