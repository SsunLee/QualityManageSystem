<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Random_Analysis
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Random_Analysis))
        Me.btn_PathChk = New System.Windows.Forms.Button()
        Me.Random_Search_txt = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.btn_Model = New System.Windows.Forms.Button()
        Me.btn_Open_QMTT = New System.Windows.Forms.Button()
        Me.btn_Random = New System.Windows.Forms.Button()
        Me.requestBtn = New System.Windows.Forms.Button()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btn_PathChk
        '
        Me.btn_PathChk.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_PathChk.Font = New System.Drawing.Font("Malgun Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.btn_PathChk.ForeColor = System.Drawing.Color.DimGray
        Me.btn_PathChk.Location = New System.Drawing.Point(820, 12)
        Me.btn_PathChk.Name = "btn_PathChk"
        Me.btn_PathChk.Size = New System.Drawing.Size(123, 24)
        Me.btn_PathChk.TabIndex = 42
        Me.btn_PathChk.Text = "경로보기"
        Me.btn_PathChk.UseVisualStyleBackColor = True
        '
        'Random_Search_txt
        '
        Me.Random_Search_txt.Location = New System.Drawing.Point(12, 388)
        Me.Random_Search_txt.Multiline = True
        Me.Random_Search_txt.Name = "Random_Search_txt"
        Me.Random_Search_txt.Size = New System.Drawing.Size(459, 52)
        Me.Random_Search_txt.TabIndex = 59
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Malgun Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.DimGray
        Me.Label3.Location = New System.Drawing.Point(44, 158)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(133, 17)
        Me.Label3.TabIndex = 52
        Me.Label3.Text = "Defect 분석 [모델별]"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Malgun Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.DimGray
        Me.Label1.Location = New System.Drawing.Point(44, 226)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(89, 17)
        Me.Label1.TabIndex = 52
        Me.Label1.Text = "Leakage 분석"
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.Color.DimGray
        Me.Label15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label15.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.White
        Me.Label15.Location = New System.Drawing.Point(20, 90)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(16, 17)
        Me.Label15.TabIndex = 52
        Me.Label15.Text = "1"
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.Color.DimGray
        Me.Label16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label16.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.White
        Me.Label16.Location = New System.Drawing.Point(20, 226)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(16, 17)
        Me.Label16.TabIndex = 52
        Me.Label16.Text = "3"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Malgun Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.DimGray
        Me.Label12.Location = New System.Drawing.Point(44, 90)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(200, 17)
        Me.Label12.TabIndex = 52
        Me.Label12.Text = "변경점 조회 [검증계획/투입MD]"
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.Color.DimGray
        Me.Label17.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label17.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.White
        Me.Label17.Location = New System.Drawing.Point(20, 158)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(16, 17)
        Me.Label17.TabIndex = 52
        Me.Label17.Text = "2"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Malgun Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.DimGray
        Me.Label2.Location = New System.Drawing.Point(234, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(161, 20)
        Me.Label2.TabIndex = 41
        Me.Label2.Text = "검증 현황_Defect 분석"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Malgun Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.DimGray
        Me.Label13.Location = New System.Drawing.Point(12, 368)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(79, 17)
        Me.Label13.TabIndex = 52
        Me.Label13.Text = "Description"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Malgun Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.DimGray
        Me.Label6.Location = New System.Drawing.Point(412, 96)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(39, 17)
        Me.Label6.TabIndex = 52
        Me.Label6.Text = "Excel"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Malgun Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.DimGray
        Me.Label19.Location = New System.Drawing.Point(410, 158)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(47, 17)
        Me.Label19.TabIndex = 52
        Me.Label19.Text = "Folder"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Malgun Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.DimGray
        Me.Label18.Location = New System.Drawing.Point(410, 226)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(39, 17)
        Me.Label18.TabIndex = 52
        Me.Label18.Text = "Excel"
        '
        'PictureBox2
        '
        Me.PictureBox2.BackgroundImage = CType(resources.GetObject("PictureBox2.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox2.Location = New System.Drawing.Point(12, 4)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(216, 25)
        Me.PictureBox2.TabIndex = 61
        Me.PictureBox2.TabStop = False
        '
        'btn_Model
        '
        Me.btn_Model.BackgroundImage = CType(resources.GetObject("btn_Model.BackgroundImage"), System.Drawing.Image)
        Me.btn_Model.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btn_Model.FlatAppearance.BorderSize = 0
        Me.btn_Model.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Model.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.btn_Model.ForeColor = System.Drawing.Color.DimGray
        Me.btn_Model.Location = New System.Drawing.Point(350, 147)
        Me.btn_Model.Name = "btn_Model"
        Me.btn_Model.Size = New System.Drawing.Size(58, 38)
        Me.btn_Model.TabIndex = 60
        Me.btn_Model.UseVisualStyleBackColor = True
        '
        'btn_Open_QMTT
        '
        Me.btn_Open_QMTT.BackgroundImage = CType(resources.GetObject("btn_Open_QMTT.BackgroundImage"), System.Drawing.Image)
        Me.btn_Open_QMTT.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btn_Open_QMTT.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_Open_QMTT.FlatAppearance.BorderSize = 0
        Me.btn_Open_QMTT.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Open_QMTT.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.btn_Open_QMTT.ForeColor = System.Drawing.Color.DimGray
        Me.btn_Open_QMTT.Location = New System.Drawing.Point(356, 219)
        Me.btn_Open_QMTT.Name = "btn_Open_QMTT"
        Me.btn_Open_QMTT.Size = New System.Drawing.Size(50, 30)
        Me.btn_Open_QMTT.TabIndex = 60
        Me.btn_Open_QMTT.UseVisualStyleBackColor = True
        '
        'btn_Random
        '
        Me.btn_Random.BackColor = System.Drawing.Color.White
        Me.btn_Random.BackgroundImage = CType(resources.GetObject("btn_Random.BackgroundImage"), System.Drawing.Image)
        Me.btn_Random.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btn_Random.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_Random.FlatAppearance.BorderSize = 0
        Me.btn_Random.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Random.Font = New System.Drawing.Font("Malgun Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.btn_Random.ForeColor = System.Drawing.Color.DimGray
        Me.btn_Random.Location = New System.Drawing.Point(356, 90)
        Me.btn_Random.Name = "btn_Random"
        Me.btn_Random.Size = New System.Drawing.Size(50, 30)
        Me.btn_Random.TabIndex = 56
        Me.btn_Random.UseVisualStyleBackColor = False
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
        Me.requestBtn.Location = New System.Drawing.Point(406, 9)
        Me.requestBtn.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.requestBtn.Name = "requestBtn"
        Me.requestBtn.Size = New System.Drawing.Size(65, 61)
        Me.requestBtn.TabIndex = 142
        Me.requestBtn.Text = "제안하기"
        Me.requestBtn.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.requestBtn.UseVisualStyleBackColor = False
        '
        'Random_Analysis
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(491, 569)
        Me.Controls.Add(Me.requestBtn)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.btn_Model)
        Me.Controls.Add(Me.btn_Open_QMTT)
        Me.Controls.Add(Me.Random_Search_txt)
        Me.Controls.Add(Me.btn_Random)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.btn_PathChk)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.Label6)
        Me.Name = "Random_Analysis"
        Me.Text = "Random_Analysis"
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btn_PathChk As Windows.Forms.Button
    Friend WithEvents Random_Search_txt As Windows.Forms.TextBox
    Friend WithEvents btn_Random As Windows.Forms.Button
    Friend WithEvents Label3 As Windows.Forms.Label
    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents btn_Open_QMTT As Windows.Forms.Button
    Friend WithEvents btn_Model As Windows.Forms.Button
    Friend WithEvents Label15 As Windows.Forms.Label
    Friend WithEvents Label16 As Windows.Forms.Label
    Friend WithEvents Label12 As Windows.Forms.Label
    Friend WithEvents Label17 As Windows.Forms.Label
    Friend WithEvents Label2 As Windows.Forms.Label
    Friend WithEvents Label13 As Windows.Forms.Label
    Friend WithEvents Label6 As Windows.Forms.Label
    Friend WithEvents Label19 As Windows.Forms.Label
    Friend WithEvents Label18 As Windows.Forms.Label
    Friend WithEvents PictureBox2 As Windows.Forms.PictureBox
    Friend WithEvents requestBtn As Windows.Forms.Button
End Class
