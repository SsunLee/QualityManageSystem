<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Summary_Add
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Summary_Add))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Submit = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.lbApp = New System.Windows.Forms.Label()
        Me.lbFeature = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lbDes = New System.Windows.Forms.Label()
        Me.AppTxt = New System.Windows.Forms.TextBox()
        Me.FeaTxt = New System.Windows.Forms.TextBox()
        Me.DesTxt = New System.Windows.Forms.TextBox()
        Me.Requester = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cbReqtype = New System.Windows.Forms.ComboBox()
        Me.lbType = New System.Windows.Forms.Label()
        Me.txtTA = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.radioTA = New System.Windows.Forms.RadioButton()
        Me.radioApp = New System.Windows.Forms.RadioButton()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtTypeTA = New System.Windows.Forms.TextBox()
        Me.lbTypeTA = New System.Windows.Forms.Label()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("맑은 고딕", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.DimGray
        Me.Label1.Location = New System.Drawing.Point(134, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(186, 37)
        Me.Label1.TabIndex = 18
        Me.Label1.Text = "App & Feature"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(12, 14)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(114, 32)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 17
        Me.PictureBox1.TabStop = False
        '
        'Submit
        '
        Me.Submit.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Submit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Submit.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Submit.ForeColor = System.Drawing.Color.White
        Me.Submit.Location = New System.Drawing.Point(512, 404)
        Me.Submit.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Submit.Name = "Submit"
        Me.Submit.Size = New System.Drawing.Size(135, 26)
        Me.Submit.TabIndex = 1005
        Me.Submit.Text = "Submit"
        Me.Submit.UseVisualStyleBackColor = False
        '
        'Button2
        '
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Button2.ForeColor = System.Drawing.Color.DimGray
        Me.Button2.Location = New System.Drawing.Point(26, 238)
        Me.Button2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(63, 26)
        Me.Button2.TabIndex = 19
        Me.Button2.Text = "Reset"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'lbApp
        '
        Me.lbApp.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbApp.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.lbApp.ForeColor = System.Drawing.Color.DimGray
        Me.lbApp.Location = New System.Drawing.Point(3, 90)
        Me.lbApp.Name = "lbApp"
        Me.lbApp.Size = New System.Drawing.Size(86, 15)
        Me.lbApp.TabIndex = 20
        Me.lbApp.Text = "App :"
        Me.lbApp.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lbFeature
        '
        Me.lbFeature.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbFeature.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.lbFeature.ForeColor = System.Drawing.Color.DimGray
        Me.lbFeature.Location = New System.Drawing.Point(6, 121)
        Me.lbFeature.Name = "lbFeature"
        Me.lbFeature.Size = New System.Drawing.Size(83, 15)
        Me.lbFeature.TabIndex = 20
        Me.lbFeature.Text = "Feature :"
        Me.lbFeature.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.DimGray
        Me.Label4.Location = New System.Drawing.Point(439, 26)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(50, 15)
        Me.Label4.TabIndex = 20
        Me.Label4.Text = "요청자 :"
        '
        'lbDes
        '
        Me.lbDes.AutoSize = True
        Me.lbDes.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.lbDes.ForeColor = System.Drawing.Color.DimGray
        Me.lbDes.Location = New System.Drawing.Point(23, 173)
        Me.lbDes.Name = "lbDes"
        Me.lbDes.Size = New System.Drawing.Size(66, 15)
        Me.lbDes.TabIndex = 20
        Me.lbDes.Text = "상세 설명 :"
        '
        'AppTxt
        '
        Me.AppTxt.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.AppTxt.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.AppTxt.Location = New System.Drawing.Point(97, 87)
        Me.AppTxt.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.AppTxt.Name = "AppTxt"
        Me.AppTxt.Size = New System.Drawing.Size(132, 23)
        Me.AppTxt.TabIndex = 1002
        '
        'FeaTxt
        '
        Me.FeaTxt.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.FeaTxt.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.FeaTxt.Location = New System.Drawing.Point(97, 118)
        Me.FeaTxt.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.FeaTxt.Name = "FeaTxt"
        Me.FeaTxt.Size = New System.Drawing.Size(132, 23)
        Me.FeaTxt.TabIndex = 1003
        '
        'DesTxt
        '
        Me.DesTxt.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.DesTxt.Location = New System.Drawing.Point(95, 173)
        Me.DesTxt.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.DesTxt.Multiline = True
        Me.DesTxt.Name = "DesTxt"
        Me.DesTxt.Size = New System.Drawing.Size(516, 91)
        Me.DesTxt.TabIndex = 1004
        '
        'Requester
        '
        Me.Requester.BackColor = System.Drawing.SystemColors.Info
        Me.Requester.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Requester.ForeColor = System.Drawing.Color.Black
        Me.Requester.Location = New System.Drawing.Point(495, 23)
        Me.Requester.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Requester.Name = "Requester"
        Me.Requester.Size = New System.Drawing.Size(152, 23)
        Me.Requester.TabIndex = 1
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.DimGray
        Me.Label6.Location = New System.Drawing.Point(235, 57)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(370, 75)
        Me.Label6.TabIndex = 21
        Me.Label6.Text = "1. Summary 작성 중 없는 앱이나, 기능을 추가 요청 할 수 있습니다" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "2. 요청사항이 무엇인지 추가 요청 목록에서 선택 해주세요" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "3. 추가 되어야 하는 이유를 상세 설명에 작성 해주세요"
        '
        'cbReqtype
        '
        Me.cbReqtype.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cbReqtype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbReqtype.FormattingEnabled = True
        Me.cbReqtype.Location = New System.Drawing.Point(97, 57)
        Me.cbReqtype.Name = "cbReqtype"
        Me.cbReqtype.Size = New System.Drawing.Size(121, 23)
        Me.cbReqtype.TabIndex = 22
        '
        'lbType
        '
        Me.lbType.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.lbType.ForeColor = System.Drawing.Color.DimGray
        Me.lbType.Location = New System.Drawing.Point(9, 60)
        Me.lbType.Name = "lbType"
        Me.lbType.Size = New System.Drawing.Size(80, 15)
        Me.lbType.TabIndex = 23
        Me.lbType.Text = "Type :"
        Me.lbType.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'txtTA
        '
        Me.txtTA.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtTA.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.txtTA.Location = New System.Drawing.Point(97, 57)
        Me.txtTA.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtTA.Name = "txtTA"
        Me.txtTA.Size = New System.Drawing.Size(132, 23)
        Me.txtTA.TabIndex = 1001
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.radioTA)
        Me.GroupBox1.Controls.Add(Me.radioApp)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 54)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(635, 53)
        Me.GroupBox1.TabIndex = 25
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "추가 요청"
        '
        'radioTA
        '
        Me.radioTA.AutoSize = True
        Me.radioTA.Location = New System.Drawing.Point(100, 22)
        Me.radioTA.Name = "radioTA"
        Me.radioTA.Size = New System.Drawing.Size(85, 19)
        Me.radioTA.TabIndex = 1007
        Me.radioTA.TabStop = True
        Me.radioTA.Text = "Test Action"
        Me.radioTA.UseVisualStyleBackColor = True
        '
        'radioApp
        '
        Me.radioApp.AutoSize = True
        Me.radioApp.Location = New System.Drawing.Point(18, 22)
        Me.radioApp.Name = "radioApp"
        Me.radioApp.Size = New System.Drawing.Size(47, 19)
        Me.radioApp.TabIndex = 1006
        Me.radioApp.TabStop = True
        Me.radioApp.Text = "App"
        Me.radioApp.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("맑은 고딕", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.DimGray
        Me.Label2.Location = New System.Drawing.Point(320, 14)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(71, 37)
        Me.Label2.TabIndex = 26
        Me.Label2.Text = "요청"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtTypeTA)
        Me.GroupBox2.Controls.Add(Me.lbTypeTA)
        Me.GroupBox2.Controls.Add(Me.lbType)
        Me.GroupBox2.Controls.Add(Me.lbApp)
        Me.GroupBox2.Controls.Add(Me.cbReqtype)
        Me.GroupBox2.Controls.Add(Me.txtTA)
        Me.GroupBox2.Controls.Add(Me.Button2)
        Me.GroupBox2.Controls.Add(Me.lbFeature)
        Me.GroupBox2.Controls.Add(Me.lbDes)
        Me.GroupBox2.Controls.Add(Me.AppTxt)
        Me.GroupBox2.Controls.Add(Me.FeaTxt)
        Me.GroupBox2.Controls.Add(Me.DesTxt)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 113)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(635, 284)
        Me.GroupBox2.TabIndex = 27
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "요청내용"
        '
        'txtTypeTA
        '
        Me.txtTypeTA.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtTypeTA.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.txtTypeTA.Location = New System.Drawing.Point(97, 26)
        Me.txtTypeTA.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtTypeTA.Name = "txtTypeTA"
        Me.txtTypeTA.Size = New System.Drawing.Size(132, 23)
        Me.txtTypeTA.TabIndex = 1000
        '
        'lbTypeTA
        '
        Me.lbTypeTA.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbTypeTA.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.lbTypeTA.ForeColor = System.Drawing.Color.DimGray
        Me.lbTypeTA.Location = New System.Drawing.Point(6, 29)
        Me.lbTypeTA.Name = "lbTypeTA"
        Me.lbTypeTA.Size = New System.Drawing.Size(83, 15)
        Me.lbTypeTA.TabIndex = 25
        Me.lbTypeTA.Text = "Type :"
        Me.lbTypeTA.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Summary_Add
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(672, 443)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Requester)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Submit)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "Summary_Add"
        Me.Text = "Summary_Add"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents PictureBox1 As Windows.Forms.PictureBox
    Friend WithEvents Submit As Windows.Forms.Button
    Friend WithEvents Button2 As Windows.Forms.Button
    Friend WithEvents lbApp As Windows.Forms.Label
    Friend WithEvents lbFeature As Windows.Forms.Label
    Friend WithEvents Label4 As Windows.Forms.Label
    Friend WithEvents lbDes As Windows.Forms.Label
    Friend WithEvents AppTxt As Windows.Forms.TextBox
    Friend WithEvents FeaTxt As Windows.Forms.TextBox
    Friend WithEvents DesTxt As Windows.Forms.TextBox
    Friend WithEvents Requester As Windows.Forms.TextBox
    Friend WithEvents Label6 As Windows.Forms.Label
    Friend WithEvents cbReqtype As Windows.Forms.ComboBox
    Friend WithEvents lbType As Windows.Forms.Label
    Friend WithEvents txtTA As Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As Windows.Forms.GroupBox
    Friend WithEvents radioTA As Windows.Forms.RadioButton
    Friend WithEvents radioApp As Windows.Forms.RadioButton
    Friend WithEvents Label2 As Windows.Forms.Label
    Friend WithEvents GroupBox2 As Windows.Forms.GroupBox
    Friend WithEvents txtTypeTA As Windows.Forms.TextBox
    Friend WithEvents lbTypeTA As Windows.Forms.Label
End Class
