<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Term_Edit_GM
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Term_Edit_GM))
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtDes = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.SearchTerm = New System.Windows.Forms.ComboBox()
        Me.btnDel = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.btnMod = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cbD = New System.Windows.Forms.ComboBox()
        Me.txtCom = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.GroupBox2.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtDes)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.SearchTerm)
        Me.GroupBox2.Controls.Add(Me.txtName)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.btnDel)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.Button1)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.btnMod)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.cbD)
        Me.GroupBox2.Controls.Add(Me.txtCom)
        Me.GroupBox2.Font = New System.Drawing.Font("Malgun Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(20, 91)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(598, 288)
        Me.GroupBox2.TabIndex = 156
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "추가, 수정, 삭제"
        '
        'txtDes
        '
        Me.txtDes.Font = New System.Drawing.Font("Malgun Gothic", 9.0!)
        Me.txtDes.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtDes.Location = New System.Drawing.Point(11, 136)
        Me.txtDes.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtDes.Multiline = True
        Me.txtDes.Name = "txtDes"
        Me.txtDes.Size = New System.Drawing.Size(427, 135)
        Me.txtDes.TabIndex = 10
        Me.txtDes.Tag = "용어설명"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Gray
        Me.Label2.Location = New System.Drawing.Point(6, 30)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(43, 15)
        Me.Label2.TabIndex = 99
        Me.Label2.Text = "대분류"
        '
        'SearchTerm
        '
        Me.SearchTerm.Font = New System.Drawing.Font("Malgun Gothic", 9.0!)
        Me.SearchTerm.FormattingEnabled = True
        Me.SearchTerm.Location = New System.Drawing.Point(358, 27)
        Me.SearchTerm.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.SearchTerm.Name = "SearchTerm"
        Me.SearchTerm.Size = New System.Drawing.Size(223, 23)
        Me.SearchTerm.TabIndex = 3
        Me.SearchTerm.Tag = "용어"
        '
        'btnDel
        '
        Me.btnDel.BackColor = System.Drawing.Color.White
        Me.btnDel.Font = New System.Drawing.Font("Malgun Gothic", 9.0!)
        Me.btnDel.Location = New System.Drawing.Point(462, 223)
        Me.btnDel.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnDel.Name = "btnDel"
        Me.btnDel.Size = New System.Drawing.Size(119, 29)
        Me.btnDel.TabIndex = 13
        Me.btnDel.Text = "Delete"
        Me.btnDel.UseVisualStyleBackColor = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Gray
        Me.Label6.Location = New System.Drawing.Point(8, 73)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(43, 15)
        Me.Label6.TabIndex = 102
        Me.Label6.Text = "업체명"
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.White
        Me.Button1.Font = New System.Drawing.Font("Malgun Gothic", 9.0!)
        Me.Button1.Location = New System.Drawing.Point(462, 149)
        Me.Button1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(119, 29)
        Me.Button1.TabIndex = 11
        Me.Button1.Text = "Add"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Gray
        Me.Label10.Location = New System.Drawing.Point(10, 113)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(55, 15)
        Me.Label10.TabIndex = 101
        Me.Label10.Text = "용어설명"
        '
        'btnMod
        '
        Me.btnMod.BackColor = System.Drawing.Color.White
        Me.btnMod.Font = New System.Drawing.Font("Malgun Gothic", 9.0!)
        Me.btnMod.Location = New System.Drawing.Point(462, 186)
        Me.btnMod.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnMod.Name = "btnMod"
        Me.btnMod.Size = New System.Drawing.Size(119, 29)
        Me.btnMod.TabIndex = 12
        Me.btnMod.Text = "Modify"
        Me.btnMod.UseVisualStyleBackColor = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Gray
        Me.Label5.Location = New System.Drawing.Point(309, 27)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(31, 15)
        Me.Label5.TabIndex = 103
        Me.Label5.Text = "용어"
        '
        'cbD
        '
        Me.cbD.Font = New System.Drawing.Font("Malgun Gothic", 9.0!)
        Me.cbD.FormattingEnabled = True
        Me.cbD.Location = New System.Drawing.Point(69, 27)
        Me.cbD.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cbD.Name = "cbD"
        Me.cbD.Size = New System.Drawing.Size(201, 23)
        Me.cbD.TabIndex = 5
        Me.cbD.Tag = "대분류"
        '
        'txtCom
        '
        Me.txtCom.Font = New System.Drawing.Font("Malgun Gothic", 9.0!)
        Me.txtCom.Location = New System.Drawing.Point(69, 73)
        Me.txtCom.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtCom.Multiline = True
        Me.txtCom.Name = "txtCom"
        Me.txtCom.Size = New System.Drawing.Size(201, 25)
        Me.txtCom.TabIndex = 9
        Me.txtCom.Tag = "업체명"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Malgun Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.DimGray
        Me.Label9.Location = New System.Drawing.Point(261, 38)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(197, 21)
        Me.Label9.TabIndex = 155
        Me.Label9.Text = "※ 검색 후 사용 해 주세요"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(12, 13)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(149, 51)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 152
        Me.PictureBox1.TabStop = False
        '
        'txtName
        '
        Me.txtName.Location = New System.Drawing.Point(358, 75)
        Me.txtName.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtName.Multiline = True
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(223, 25)
        Me.txtName.TabIndex = 151
        Me.txtName.Tag = "담당자"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Gray
        Me.Label7.Location = New System.Drawing.Point(309, 75)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(43, 15)
        Me.Label7.TabIndex = 153
        Me.Label7.Text = "담당자"
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.White
        Me.Button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.ForeColor = System.Drawing.Color.DimGray
        Me.Button3.Location = New System.Drawing.Point(167, 35)
        Me.Button3.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(75, 29)
        Me.Button3.TabIndex = 154
        Me.Button3.Text = "Refresh"
        Me.Button3.UseVisualStyleBackColor = False
        '
        'Term_Edit_GM
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(635, 392)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Button3)
        Me.Name = "Term_Edit_GM"
        Me.Text = "Term_Edit_GM"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GroupBox2 As Windows.Forms.GroupBox
    Friend WithEvents txtDes As Windows.Forms.TextBox
    Friend WithEvents Label2 As Windows.Forms.Label
    Friend WithEvents SearchTerm As Windows.Forms.ComboBox
    Friend WithEvents btnDel As Windows.Forms.Button
    Friend WithEvents Label6 As Windows.Forms.Label
    Friend WithEvents Button1 As Windows.Forms.Button
    Friend WithEvents Label10 As Windows.Forms.Label
    Friend WithEvents btnMod As Windows.Forms.Button
    Friend WithEvents Label5 As Windows.Forms.Label
    Friend WithEvents cbD As Windows.Forms.ComboBox
    Friend WithEvents txtCom As Windows.Forms.TextBox
    Friend WithEvents Label9 As Windows.Forms.Label
    Friend WithEvents PictureBox1 As Windows.Forms.PictureBox
    Friend WithEvents txtName As Windows.Forms.TextBox
    Friend WithEvents Label7 As Windows.Forms.Label
    Friend WithEvents Button3 As Windows.Forms.Button
End Class
