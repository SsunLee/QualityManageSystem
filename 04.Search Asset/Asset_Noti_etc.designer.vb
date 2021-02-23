<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Asset_Noti_etc
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Asset_Noti_etc))
        Me.btn_Asset = New System.Windows.Forms.Button()
        Me.btn_PathChk = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btn_WorkNoti = New System.Windows.Forms.Button()
        Me.Sample_Search_txt = New System.Windows.Forms.TextBox()
        Me.Asset_Search_txt = New System.Windows.Forms.TextBox()
        Me.WorkNoti_Search_txt = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.lb_SW = New System.Windows.Forms.Label()
        Me.btn_Device = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.requestBtn = New System.Windows.Forms.Button()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btn_Asset
        '
        Me.btn_Asset.BackColor = System.Drawing.Color.Transparent
        Me.btn_Asset.BackgroundImage = CType(resources.GetObject("btn_Asset.BackgroundImage"), System.Drawing.Image)
        Me.btn_Asset.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btn_Asset.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_Asset.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Asset.Font = New System.Drawing.Font("Malgun Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.btn_Asset.ForeColor = System.Drawing.Color.White
        Me.btn_Asset.Location = New System.Drawing.Point(234, 185)
        Me.btn_Asset.Name = "btn_Asset"
        Me.btn_Asset.Size = New System.Drawing.Size(50, 30)
        Me.btn_Asset.TabIndex = 47
        Me.btn_Asset.UseVisualStyleBackColor = False
        '
        'btn_PathChk
        '
        Me.btn_PathChk.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_PathChk.Font = New System.Drawing.Font("Malgun Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.btn_PathChk.ForeColor = System.Drawing.Color.DimGray
        Me.btn_PathChk.Location = New System.Drawing.Point(14, 394)
        Me.btn_PathChk.Name = "btn_PathChk"
        Me.btn_PathChk.Size = New System.Drawing.Size(107, 24)
        Me.btn_PathChk.TabIndex = 48
        Me.btn_PathChk.Text = "경로보기"
        Me.btn_PathChk.UseVisualStyleBackColor = True
        Me.btn_PathChk.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Malgun Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.DimGray
        Me.Label3.Location = New System.Drawing.Point(29, 135)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(106, 17)
        Me.Label3.TabIndex = 45
        Me.Label3.Text = "[시료 현황 조회]"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Malgun Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.DimGray
        Me.Label1.Location = New System.Drawing.Point(28, 194)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(119, 17)
        Me.Label1.TabIndex = 46
        Me.Label1.Text = "[호환성 장비 조회]"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Malgun Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.DimGray
        Me.Label4.Location = New System.Drawing.Point(28, 250)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(106, 17)
        Me.Label4.TabIndex = 45
        Me.Label4.Text = "[업무 공지 현황]"
        '
        'btn_WorkNoti
        '
        Me.btn_WorkNoti.BackColor = System.Drawing.Color.Transparent
        Me.btn_WorkNoti.BackgroundImage = CType(resources.GetObject("btn_WorkNoti.BackgroundImage"), System.Drawing.Image)
        Me.btn_WorkNoti.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btn_WorkNoti.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_WorkNoti.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_WorkNoti.Font = New System.Drawing.Font("Malgun Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.btn_WorkNoti.ForeColor = System.Drawing.Color.White
        Me.btn_WorkNoti.Location = New System.Drawing.Point(233, 244)
        Me.btn_WorkNoti.Name = "btn_WorkNoti"
        Me.btn_WorkNoti.Size = New System.Drawing.Size(50, 30)
        Me.btn_WorkNoti.TabIndex = 47
        Me.btn_WorkNoti.UseVisualStyleBackColor = False
        '
        'Sample_Search_txt
        '
        Me.Sample_Search_txt.Location = New System.Drawing.Point(12, 424)
        Me.Sample_Search_txt.Multiline = True
        Me.Sample_Search_txt.Name = "Sample_Search_txt"
        Me.Sample_Search_txt.Size = New System.Drawing.Size(443, 65)
        Me.Sample_Search_txt.TabIndex = 50
        Me.Sample_Search_txt.Visible = False
        '
        'Asset_Search_txt
        '
        Me.Asset_Search_txt.Location = New System.Drawing.Point(14, 508)
        Me.Asset_Search_txt.Multiline = True
        Me.Asset_Search_txt.Name = "Asset_Search_txt"
        Me.Asset_Search_txt.Size = New System.Drawing.Size(441, 65)
        Me.Asset_Search_txt.TabIndex = 50
        Me.Asset_Search_txt.Visible = False
        '
        'WorkNoti_Search_txt
        '
        Me.WorkNoti_Search_txt.Location = New System.Drawing.Point(12, 579)
        Me.WorkNoti_Search_txt.Multiline = True
        Me.WorkNoti_Search_txt.Name = "WorkNoti_Search_txt"
        Me.WorkNoti_Search_txt.Size = New System.Drawing.Size(443, 65)
        Me.WorkNoti_Search_txt.TabIndex = 50
        Me.WorkNoti_Search_txt.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Malgun Gothic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.DimGray
        Me.Label2.Location = New System.Drawing.Point(229, 7)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(263, 25)
        Me.Label2.TabIndex = 51
        Me.Label2.Text = "검증 정보_시료조회/장비조회"
        '
        'Label18
        '
        Me.Label18.BackColor = System.Drawing.Color.DimGray
        Me.Label18.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label18.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.White
        Me.Label18.Location = New System.Drawing.Point(7, 135)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(16, 17)
        Me.Label18.TabIndex = 57
        Me.Label18.Text = "1"
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.DimGray
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label5.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(7, 191)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(16, 17)
        Me.Label5.TabIndex = 58
        Me.Label5.Text = "2"
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.DimGray
        Me.Label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label10.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(6, 250)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(16, 17)
        Me.Label10.TabIndex = 59
        Me.Label10.Text = "3"
        '
        'lb_SW
        '
        Me.lb_SW.AutoSize = True
        Me.lb_SW.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lb_SW.Font = New System.Drawing.Font("Malgun Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.lb_SW.ForeColor = System.Drawing.Color.DimGray
        Me.lb_SW.Location = New System.Drawing.Point(290, 135)
        Me.lb_SW.Name = "lb_SW"
        Me.lb_SW.Size = New System.Drawing.Size(39, 17)
        Me.lb_SW.TabIndex = 60
        Me.lb_SW.Text = "Excel"
        '
        'btn_Device
        '
        Me.btn_Device.BackColor = System.Drawing.Color.Transparent
        Me.btn_Device.BackgroundImage = CType(resources.GetObject("btn_Device.BackgroundImage"), System.Drawing.Image)
        Me.btn_Device.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btn_Device.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Device.Font = New System.Drawing.Font("Malgun Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.btn_Device.ForeColor = System.Drawing.Color.White
        Me.btn_Device.Location = New System.Drawing.Point(234, 129)
        Me.btn_Device.Name = "btn_Device"
        Me.btn_Device.Size = New System.Drawing.Size(50, 30)
        Me.btn_Device.TabIndex = 49
        Me.btn_Device.UseVisualStyleBackColor = False
        '
        'PictureBox1
        '

        Me.PictureBox1.Location = New System.Drawing.Point(7, 7)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(216, 25)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 41
        Me.PictureBox1.TabStop = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Label6.Font = New System.Drawing.Font("Malgun Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.DimGray
        Me.Label6.Location = New System.Drawing.Point(290, 197)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(39, 17)
        Me.Label6.TabIndex = 60
        Me.Label6.Text = "Excel"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Label7.Font = New System.Drawing.Font("Malgun Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.DimGray
        Me.Label7.Location = New System.Drawing.Point(289, 250)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(39, 17)
        Me.Label7.TabIndex = 60
        Me.Label7.Text = "Excel"
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
        Me.requestBtn.Location = New System.Drawing.Point(418, 36)
        Me.requestBtn.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.requestBtn.Name = "requestBtn"
        Me.requestBtn.Size = New System.Drawing.Size(61, 53)
        Me.requestBtn.TabIndex = 143
        Me.requestBtn.Text = "제안하기"
        Me.requestBtn.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.requestBtn.UseVisualStyleBackColor = False
        '
        'Asset_Noti_etc
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(491, 662)
        Me.Controls.Add(Me.requestBtn)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.lb_SW)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.WorkNoti_Search_txt)
        Me.Controls.Add(Me.Asset_Search_txt)
        Me.Controls.Add(Me.Sample_Search_txt)
        Me.Controls.Add(Me.btn_WorkNoti)
        Me.Controls.Add(Me.btn_Asset)
        Me.Controls.Add(Me.btn_PathChk)
        Me.Controls.Add(Me.btn_Device)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Name = "Asset_Noti_etc"
        Me.Text = "Asset_Noti_etc"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btn_Asset As Windows.Forms.Button
    Friend WithEvents btn_PathChk As Windows.Forms.Button
    Friend WithEvents btn_Device As Windows.Forms.Button
    Friend WithEvents Label3 As Windows.Forms.Label
    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents Label4 As Windows.Forms.Label
    Friend WithEvents btn_WorkNoti As Windows.Forms.Button
    Friend WithEvents Sample_Search_txt As Windows.Forms.TextBox
    Friend WithEvents Asset_Search_txt As Windows.Forms.TextBox
    Friend WithEvents WorkNoti_Search_txt As Windows.Forms.TextBox
    Friend WithEvents PictureBox1 As Windows.Forms.PictureBox
    Friend WithEvents Label2 As Windows.Forms.Label
    Friend WithEvents Label18 As Windows.Forms.Label
    Friend WithEvents Label5 As Windows.Forms.Label
    Friend WithEvents Label10 As Windows.Forms.Label
    Friend WithEvents lb_SW As Windows.Forms.Label
    Friend WithEvents Label6 As Windows.Forms.Label
    Friend WithEvents Label7 As Windows.Forms.Label
    Friend WithEvents requestBtn As Windows.Forms.Button
End Class
