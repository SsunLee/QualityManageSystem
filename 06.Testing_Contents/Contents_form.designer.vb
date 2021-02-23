<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Contents_form
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Contents_form))
        Me.btn_oContents = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lst_Contents = New System.Windows.Forms.ListBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lst_submenu = New System.Windows.Forms.ListBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.requestBtn = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btn_oContents
        '
        Me.btn_oContents.BackColor = System.Drawing.Color.Transparent
        Me.btn_oContents.BackgroundImage = CType(resources.GetObject("btn_oContents.BackgroundImage"), System.Drawing.Image)
        Me.btn_oContents.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btn_oContents.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_oContents.FlatAppearance.BorderSize = 0
        Me.btn_oContents.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_oContents.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.btn_oContents.ForeColor = System.Drawing.Color.White
        Me.btn_oContents.Location = New System.Drawing.Point(380, 20)
        Me.btn_oContents.Name = "btn_oContents"
        Me.btn_oContents.Size = New System.Drawing.Size(68, 38)
        Me.btn_oContents.TabIndex = 43
        Me.btn_oContents.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Malgun Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.DimGray
        Me.Label1.Location = New System.Drawing.Point(6, -2)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(168, 17)
        Me.Label1.TabIndex = 41
        Me.Label1.Text = "■  [검증에 필요한 컨텐츠]"
        '
        'lst_Contents
        '
        Me.lst_Contents.FormattingEnabled = True
        Me.lst_Contents.ItemHeight = 12
        Me.lst_Contents.Location = New System.Drawing.Point(20, 69)
        Me.lst_Contents.Name = "lst_Contents"
        Me.lst_Contents.Size = New System.Drawing.Size(428, 124)
        Me.lst_Contents.TabIndex = 44
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lst_submenu)
        Me.GroupBox1.Controls.Add(Me.lst_Contents)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.btn_oContents)
        Me.GroupBox1.Location = New System.Drawing.Point(21, 71)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(478, 466)
        Me.GroupBox1.TabIndex = 48
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "GroupBox1"
        '
        'lst_submenu
        '
        Me.lst_submenu.FormattingEnabled = True
        Me.lst_submenu.ItemHeight = 12
        Me.lst_submenu.Location = New System.Drawing.Point(20, 206)
        Me.lst_submenu.Name = "lst_submenu"
        Me.lst_submenu.Size = New System.Drawing.Size(428, 244)
        Me.lst_submenu.TabIndex = 46
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImage = CType(resources.GetObject("PictureBox1.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.InitialImage = CType(resources.GetObject("PictureBox1.InitialImage"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(12, 9)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(216, 25)
        Me.PictureBox1.TabIndex = 51
        Me.PictureBox1.TabStop = False
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
        Me.requestBtn.Location = New System.Drawing.Point(432, 9)
        Me.requestBtn.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.requestBtn.Name = "requestBtn"
        Me.requestBtn.Size = New System.Drawing.Size(67, 55)
        Me.requestBtn.TabIndex = 142
        Me.requestBtn.Text = "제안하기"
        Me.requestBtn.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.requestBtn.UseVisualStyleBackColor = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Malgun Gothic", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.DimGray
        Me.Label3.Location = New System.Drawing.Point(234, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(160, 20)
        Me.Label3.TabIndex = 143
        Me.Label3.Text = "검증 정보_검증 컨텐츠"
        '
        'Contents_form
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(522, 563)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.requestBtn)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "Contents_form"
        Me.Text = "Contents_form"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btn_oContents As Windows.Forms.Button
    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents lst_Contents As Windows.Forms.ListBox
    Friend WithEvents GroupBox1 As Windows.Forms.GroupBox
    Friend WithEvents PictureBox1 As Windows.Forms.PictureBox
    Friend WithEvents lst_submenu As Windows.Forms.ListBox
    Friend WithEvents requestBtn As Windows.Forms.Button
    Friend WithEvents Label3 As Windows.Forms.Label
End Class
