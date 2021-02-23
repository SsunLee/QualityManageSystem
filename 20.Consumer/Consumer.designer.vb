<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Consumer
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Consumer))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.GubunCb = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnLoad = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.opSan = New System.Windows.Forms.CheckBox()
        Me.opBasic = New System.Windows.Forms.CheckBox()
        Me.opFull = New System.Windows.Forms.CheckBox()
        Me.op5 = New System.Windows.Forms.CheckBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lstType = New System.Windows.Forms.ListBox()
        Me.lstModule = New System.Windows.Forms.ListBox()
        Me.lstSub = New System.Windows.Forms.ListBox()
        Me.lstFea = New System.Windows.Forms.ListBox()
        Me.UserCondition = New System.Windows.Forms.ListBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtDes = New System.Windows.Forms.TextBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Malgun Gothic", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.DimGray
        Me.Label1.Location = New System.Drawing.Point(152, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(146, 37)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Consumer"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(12, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(134, 41)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 5
        Me.PictureBox1.TabStop = False
        '
        'GubunCb
        '
        Me.GubunCb.FormattingEnabled = True
        Me.GubunCb.Location = New System.Drawing.Point(82, 72)
        Me.GubunCb.Name = "GubunCb"
        Me.GubunCb.Size = New System.Drawing.Size(173, 20)
        Me.GubunCb.TabIndex = 7
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(35, 75)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 12)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "구분 : "
        '
        'btnLoad
        '
        Me.btnLoad.Location = New System.Drawing.Point(273, 69)
        Me.btnLoad.Name = "btnLoad"
        Me.btnLoad.Size = New System.Drawing.Size(75, 23)
        Me.btnLoad.TabIndex = 9
        Me.btnLoad.Text = "Search"
        Me.btnLoad.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(11, 109)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 12)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "선정기준 : "
        '
        'opSan
        '
        Me.opSan.AutoSize = True
        Me.opSan.Location = New System.Drawing.Point(89, 105)
        Me.opSan.Name = "opSan"
        Me.opSan.Size = New System.Drawing.Size(73, 16)
        Me.opSan.TabIndex = 10
        Me.opSan.Text = "Y_Sanity"
        Me.opSan.UseVisualStyleBackColor = True
        '
        'opBasic
        '
        Me.opBasic.AutoSize = True
        Me.opBasic.Location = New System.Drawing.Point(181, 105)
        Me.opBasic.Name = "opBasic"
        Me.opBasic.Size = New System.Drawing.Size(70, 16)
        Me.opBasic.TabIndex = 10
        Me.opBasic.Text = "Y_Basic"
        Me.opBasic.UseVisualStyleBackColor = True
        '
        'opFull
        '
        Me.opFull.AutoSize = True
        Me.opFull.Location = New System.Drawing.Point(273, 105)
        Me.opFull.Name = "opFull"
        Me.opFull.Size = New System.Drawing.Size(58, 16)
        Me.opFull.TabIndex = 10
        Me.opFull.Text = "Y_Full"
        Me.opFull.UseVisualStyleBackColor = True
        '
        'op5
        '
        Me.op5.AutoSize = True
        Me.op5.Location = New System.Drawing.Point(365, 105)
        Me.op5.Name = "op5"
        Me.op5.Size = New System.Drawing.Size(80, 16)
        Me.op5.TabIndex = 10
        Me.op5.Text = "Y_5대기능"
        Me.op5.UseVisualStyleBackColor = True
        Me.op5.Visible = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Location = New System.Drawing.Point(13, 135)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(440, 68)
        Me.GroupBox1.TabIndex = 11
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Tool Tip"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(13, 40)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(333, 12)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "2. 선정기준 중 [5대 기능] <-- 고객 행통 패턴만 가능합니다."
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(13, 21)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(289, 12)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "1. 선정기준을 비워두고 조회 하면 All 조회가 됩니다."
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(50, 209)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(34, 12)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = "Type"
        '
        'lstType
        '
        Me.lstType.FormattingEnabled = True
        Me.lstType.ItemHeight = 12
        Me.lstType.Location = New System.Drawing.Point(13, 225)
        Me.lstType.Name = "lstType"
        Me.lstType.Size = New System.Drawing.Size(143, 196)
        Me.lstType.TabIndex = 12
        '
        'lstModule
        '
        Me.lstModule.FormattingEnabled = True
        Me.lstModule.ItemHeight = 12
        Me.lstModule.Location = New System.Drawing.Point(162, 225)
        Me.lstModule.Name = "lstModule"
        Me.lstModule.Size = New System.Drawing.Size(178, 196)
        Me.lstModule.TabIndex = 12
        '
        'lstSub
        '
        Me.lstSub.FormattingEnabled = True
        Me.lstSub.ItemHeight = 12
        Me.lstSub.Location = New System.Drawing.Point(346, 225)
        Me.lstSub.Name = "lstSub"
        Me.lstSub.Size = New System.Drawing.Size(145, 196)
        Me.lstSub.TabIndex = 12
        '
        'lstFea
        '
        Me.lstFea.FormattingEnabled = True
        Me.lstFea.ItemHeight = 12
        Me.lstFea.Location = New System.Drawing.Point(497, 225)
        Me.lstFea.Name = "lstFea"
        Me.lstFea.Size = New System.Drawing.Size(145, 196)
        Me.lstFea.TabIndex = 12
        '
        'UserCondition
        '
        Me.UserCondition.FormattingEnabled = True
        Me.UserCondition.ItemHeight = 12
        Me.UserCondition.Location = New System.Drawing.Point(648, 225)
        Me.UserCondition.Name = "UserCondition"
        Me.UserCondition.Size = New System.Drawing.Size(145, 196)
        Me.UserCondition.TabIndex = 12
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(237, 209)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(47, 12)
        Me.Label7.TabIndex = 8
        Me.Label7.Text = "Module"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(390, 209)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(73, 12)
        Me.Label8.TabIndex = 8
        Me.Label8.Text = "Sub Module"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(532, 209)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(76, 12)
        Me.Label9.TabIndex = 8
        Me.Label9.Text = "Test Feature"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(675, 209)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(88, 12)
        Me.Label10.TabIndex = 8
        Me.Label10.Text = "User Condition"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(10, 433)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(113, 12)
        Me.Label11.TabIndex = 8
        Me.Label11.Text = "테스트 방법 및 절차"
        '
        'txtDes
        '
        Me.txtDes.Location = New System.Drawing.Point(13, 449)
        Me.txtDes.Multiline = True
        Me.txtDes.Name = "txtDes"
        Me.txtDes.Size = New System.Drawing.Size(629, 96)
        Me.txtDes.TabIndex = 13
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(648, 522)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 14
        Me.Button2.Text = "추가 요청"
        Me.Button2.UseVisualStyleBackColor = True
        Me.Button2.Visible = False
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(729, 522)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(75, 23)
        Me.Button3.TabIndex = 14
        Me.Button3.Text = "수정 요청"
        Me.Button3.UseVisualStyleBackColor = True
        Me.Button3.Visible = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Transparent
        Me.Button1.BackgroundImage = My.Resources.Resources.business_ideas
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Button1.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.Black
        Me.Button1.Location = New System.Drawing.Point(716, 12)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(77, 61)
        Me.Button1.TabIndex = 26
        Me.Button1.Text = "제안하기"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Consumer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(814, 570)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.txtDes)
        Me.Controls.Add(Me.UserCondition)
        Me.Controls.Add(Me.lstFea)
        Me.Controls.Add(Me.lstSub)
        Me.Controls.Add(Me.lstModule)
        Me.Controls.Add(Me.lstType)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.op5)
        Me.Controls.Add(Me.opFull)
        Me.Controls.Add(Me.opBasic)
        Me.Controls.Add(Me.opSan)
        Me.Controls.Add(Me.btnLoad)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.GubunCb)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Consumer"
        Me.Text = "Consumer"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents PictureBox1 As Windows.Forms.PictureBox
    Friend WithEvents GubunCb As Windows.Forms.ComboBox
    Friend WithEvents Label2 As Windows.Forms.Label
    Friend WithEvents btnLoad As Windows.Forms.Button
    Friend WithEvents Label3 As Windows.Forms.Label
    Friend WithEvents opSan As Windows.Forms.CheckBox
    Friend WithEvents opBasic As Windows.Forms.CheckBox
    Friend WithEvents opFull As Windows.Forms.CheckBox
    Friend WithEvents op5 As Windows.Forms.CheckBox
    Friend WithEvents GroupBox1 As Windows.Forms.GroupBox
    Friend WithEvents Label5 As Windows.Forms.Label
    Friend WithEvents Label4 As Windows.Forms.Label
    Friend WithEvents Label6 As Windows.Forms.Label
    Friend WithEvents lstType As Windows.Forms.ListBox
    Friend WithEvents lstModule As Windows.Forms.ListBox
    Friend WithEvents lstSub As Windows.Forms.ListBox
    Friend WithEvents lstFea As Windows.Forms.ListBox
    Friend WithEvents UserCondition As Windows.Forms.ListBox
    Friend WithEvents Label7 As Windows.Forms.Label
    Friend WithEvents Label8 As Windows.Forms.Label
    Friend WithEvents Label9 As Windows.Forms.Label
    Friend WithEvents Label10 As Windows.Forms.Label
    Friend WithEvents Label11 As Windows.Forms.Label
    Friend WithEvents txtDes As Windows.Forms.TextBox
    Friend WithEvents Button2 As Windows.Forms.Button
    Friend WithEvents Button3 As Windows.Forms.Button
    Friend WithEvents Button1 As Windows.Forms.Button
End Class
