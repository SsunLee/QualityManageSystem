<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TestCase_GM
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TestCase_GM))
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.FileName = New System.Windows.Forms.TextBox()
        Me.lstDep = New System.Windows.Forms.ListBox()
        Me.TestGubunCB = New System.Windows.Forms.ComboBox()
        Me.GubunCB = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.PriTxt = New System.Windows.Forms.TextBox()
        Me.DetectedTxt = New System.Windows.Forms.TextBox()
        Me.MDTxt = New System.Windows.Forms.TextBox()
        Me.TCPurposeTxt = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.requestBtn = New System.Windows.Forms.Button()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.DimGray
        Me.Label6.Location = New System.Drawing.Point(260, 56)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(232, 30)
        Me.Label6.TabIndex = 40
        Me.Label6.Text = "1) TC 카테고리 별로 확인 할 수 있습니다." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "2) 선택 한 Master TC를 열 수 있습니다."
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.Location = New System.Drawing.Point(625, 448)
        Me.Button1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 29)
        Me.Button1.TabIndex = 39
        Me.Button1.Text = "파일열기"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'FileName
        '
        Me.FileName.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.FileName.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.FileName.ForeColor = System.Drawing.Color.DimGray
        Me.FileName.Location = New System.Drawing.Point(408, 450)
        Me.FileName.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.FileName.Name = "FileName"
        Me.FileName.Size = New System.Drawing.Size(211, 23)
        Me.FileName.TabIndex = 38
        '
        'lstDep
        '
        Me.lstDep.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.lstDep.ForeColor = System.Drawing.Color.DimGray
        Me.lstDep.FormattingEnabled = True
        Me.lstDep.ItemHeight = 15
        Me.lstDep.Location = New System.Drawing.Point(88, 130)
        Me.lstDep.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.lstDep.Name = "lstDep"
        Me.lstDep.Size = New System.Drawing.Size(223, 349)
        Me.lstDep.TabIndex = 36
        '
        'TestGubunCB
        '
        Me.TestGubunCB.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TestGubunCB.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.TestGubunCB.ForeColor = System.Drawing.Color.DimGray
        Me.TestGubunCB.FormattingEnabled = True
        Me.TestGubunCB.Location = New System.Drawing.Point(88, 93)
        Me.TestGubunCB.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TestGubunCB.Name = "TestGubunCB"
        Me.TestGubunCB.Size = New System.Drawing.Size(141, 23)
        Me.TestGubunCB.TabIndex = 34
        '
        'GubunCB
        '
        Me.GubunCB.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GubunCB.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.GubunCB.ForeColor = System.Drawing.Color.DimGray
        Me.GubunCB.FormattingEnabled = True
        Me.GubunCB.Location = New System.Drawing.Point(88, 53)
        Me.GubunCB.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GubunCB.Name = "GubunCB"
        Me.GubunCB.Size = New System.Drawing.Size(141, 23)
        Me.GubunCB.TabIndex = 35
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.DimGray
        Me.Label5.Location = New System.Drawing.Point(331, 453)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(65, 15)
        Me.Label5.TabIndex = 30
        Me.Label5.Text = "File Name"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.DimGray
        Me.Label4.Location = New System.Drawing.Point(8, 130)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(66, 15)
        Me.Label4.TabIndex = 31
        Me.Label4.Text = "상세 분류 :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.DimGray
        Me.Label3.Location = New System.Drawing.Point(8, 93)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(66, 15)
        Me.Label3.TabIndex = 32
        Me.Label3.Text = "검증 구분 :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.DimGray
        Me.Label2.Location = New System.Drawing.Point(32, 53)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(42, 15)
        Me.Label2.TabIndex = 33
        Me.Label2.Text = "구분 : "
        '
        'PriTxt
        '
        Me.PriTxt.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.PriTxt.ForeColor = System.Drawing.Color.DimGray
        Me.PriTxt.Location = New System.Drawing.Point(408, 314)
        Me.PriTxt.Multiline = True
        Me.PriTxt.Name = "PriTxt"
        Me.PriTxt.Size = New System.Drawing.Size(427, 82)
        Me.PriTxt.TabIndex = 46
        '
        'DetectedTxt
        '
        Me.DetectedTxt.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.DetectedTxt.ForeColor = System.Drawing.Color.DimGray
        Me.DetectedTxt.Location = New System.Drawing.Point(408, 194)
        Me.DetectedTxt.Multiline = True
        Me.DetectedTxt.Name = "DetectedTxt"
        Me.DetectedTxt.Size = New System.Drawing.Size(427, 111)
        Me.DetectedTxt.TabIndex = 47
        '
        'MDTxt
        '
        Me.MDTxt.BackColor = System.Drawing.Color.PeachPuff
        Me.MDTxt.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.MDTxt.ForeColor = System.Drawing.Color.DimGray
        Me.MDTxt.Location = New System.Drawing.Point(408, 405)
        Me.MDTxt.Name = "MDTxt"
        Me.MDTxt.Size = New System.Drawing.Size(145, 23)
        Me.MDTxt.TabIndex = 48
        '
        'TCPurposeTxt
        '
        Me.TCPurposeTxt.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.TCPurposeTxt.ForeColor = System.Drawing.Color.DimGray
        Me.TCPurposeTxt.Location = New System.Drawing.Point(408, 130)
        Me.TCPurposeTxt.Multiline = True
        Me.TCPurposeTxt.Name = "TCPurposeTxt"
        Me.TCPurposeTxt.Size = New System.Drawing.Size(427, 45)
        Me.TCPurposeTxt.TabIndex = 49
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.DimGray
        Me.Label7.Location = New System.Drawing.Point(365, 314)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(31, 15)
        Me.Label7.TabIndex = 41
        Me.Label7.Text = "비고"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.DimGray
        Me.Label8.Location = New System.Drawing.Point(340, 408)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(56, 15)
        Me.Label8.TabIndex = 42
        Me.Label8.Text = "투입 MD"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.DimGray
        Me.Label9.Location = New System.Drawing.Point(341, 196)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(55, 15)
        Me.Label9.TabIndex = 43
        Me.Label9.Text = "검증항목"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.DimGray
        Me.Label10.Location = New System.Drawing.Point(365, 133)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(31, 15)
        Me.Label10.TabIndex = 44
        Me.Label10.Text = "목적"
        '
        'PictureBox2
        '
        Me.PictureBox2.BackgroundImage = CType(resources.GetObject("PictureBox2.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox2.Location = New System.Drawing.Point(12, 3)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(216, 25)
        Me.PictureBox2.TabIndex = 63
        Me.PictureBox2.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Malgun Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.DimGray
        Me.Label1.Location = New System.Drawing.Point(234, 3)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(247, 20)
        Me.Label1.TabIndex = 62
        Me.Label1.Text = "Test Case_Master T/C (Non-Func)"
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
        Me.requestBtn.Location = New System.Drawing.Point(764, 9)
        Me.requestBtn.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.requestBtn.Name = "requestBtn"
        Me.requestBtn.Size = New System.Drawing.Size(71, 59)
        Me.requestBtn.TabIndex = 143
        Me.requestBtn.Text = "제안하기"
        Me.requestBtn.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.requestBtn.UseVisualStyleBackColor = False
        '
        'TestCase_GM
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(852, 499)
        Me.Controls.Add(Me.requestBtn)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PriTxt)
        Me.Controls.Add(Me.DetectedTxt)
        Me.Controls.Add(Me.MDTxt)
        Me.Controls.Add(Me.TCPurposeTxt)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.FileName)
        Me.Controls.Add(Me.lstDep)
        Me.Controls.Add(Me.TestGubunCB)
        Me.Controls.Add(Me.GubunCB)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Name = "TestCase_GM"
        Me.Text = "TestCase_GM"
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label6 As Windows.Forms.Label
    Friend WithEvents Button1 As Windows.Forms.Button
    Friend WithEvents FileName As Windows.Forms.TextBox
    Friend WithEvents lstDep As Windows.Forms.ListBox
    Friend WithEvents TestGubunCB As Windows.Forms.ComboBox
    Friend WithEvents GubunCB As Windows.Forms.ComboBox
    Friend WithEvents Label5 As Windows.Forms.Label
    Friend WithEvents Label4 As Windows.Forms.Label
    Friend WithEvents Label3 As Windows.Forms.Label
    Friend WithEvents Label2 As Windows.Forms.Label
    Friend WithEvents PriTxt As Windows.Forms.TextBox
    Friend WithEvents DetectedTxt As Windows.Forms.TextBox
    Friend WithEvents MDTxt As Windows.Forms.TextBox
    Friend WithEvents TCPurposeTxt As Windows.Forms.TextBox
    Friend WithEvents Label7 As Windows.Forms.Label
    Friend WithEvents Label8 As Windows.Forms.Label
    Friend WithEvents Label9 As Windows.Forms.Label
    Friend WithEvents Label10 As Windows.Forms.Label
    Friend WithEvents PictureBox2 As Windows.Forms.PictureBox
    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents requestBtn As Windows.Forms.Button
End Class
