<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Tip_Request_GM
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Tip_Request_GM))
        Me.Requester = New System.Windows.Forms.TextBox()
        Me.Submit_btn = New System.Windows.Forms.Button()
        Me.opFull = New System.Windows.Forms.RadioButton()
        Me.opBasic = New System.Windows.Forms.RadioButton()
        Me.opSanity = New System.Windows.Forms.RadioButton()
        Me.Around_txt = New System.Windows.Forms.TextBox()
        Me.Default_txt = New System.Windows.Forms.TextBox()
        Me.TypeCB = New System.Windows.Forms.ComboBox()
        Me.FeaCB = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.AppCB = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Requester
        '
        Me.Requester.BackColor = System.Drawing.SystemColors.Info
        Me.Requester.Location = New System.Drawing.Point(330, 55)
        Me.Requester.Name = "Requester"
        Me.Requester.Size = New System.Drawing.Size(151, 21)
        Me.Requester.TabIndex = 44
        '
        'Submit_btn
        '
        Me.Submit_btn.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Submit_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Submit_btn.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Submit_btn.ForeColor = System.Drawing.Color.White
        Me.Submit_btn.Location = New System.Drawing.Point(161, 443)
        Me.Submit_btn.Name = "Submit_btn"
        Me.Submit_btn.Size = New System.Drawing.Size(149, 23)
        Me.Submit_btn.TabIndex = 43
        Me.Submit_btn.Text = "Submit"
        Me.Submit_btn.UseVisualStyleBackColor = False
        '
        'opFull
        '
        Me.opFull.AutoSize = True
        Me.opFull.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.opFull.ForeColor = System.Drawing.Color.DimGray
        Me.opFull.Location = New System.Drawing.Point(245, 402)
        Me.opFull.Name = "opFull"
        Me.opFull.Size = New System.Drawing.Size(44, 19)
        Me.opFull.TabIndex = 42
        Me.opFull.TabStop = True
        Me.opFull.Text = "Full"
        Me.opFull.UseVisualStyleBackColor = True
        '
        'opBasic
        '
        Me.opBasic.AutoSize = True
        Me.opBasic.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.opBasic.ForeColor = System.Drawing.Color.DimGray
        Me.opBasic.Location = New System.Drawing.Point(176, 402)
        Me.opBasic.Name = "opBasic"
        Me.opBasic.Size = New System.Drawing.Size(55, 19)
        Me.opBasic.TabIndex = 41
        Me.opBasic.TabStop = True
        Me.opBasic.Text = "Basic"
        Me.opBasic.UseVisualStyleBackColor = True
        '
        'opSanity
        '
        Me.opSanity.AutoSize = True
        Me.opSanity.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.opSanity.ForeColor = System.Drawing.Color.DimGray
        Me.opSanity.Location = New System.Drawing.Point(104, 402)
        Me.opSanity.Name = "opSanity"
        Me.opSanity.Size = New System.Drawing.Size(60, 19)
        Me.opSanity.TabIndex = 40
        Me.opSanity.TabStop = True
        Me.opSanity.Text = "Sanity"
        Me.opSanity.UseVisualStyleBackColor = True
        '
        'Around_txt
        '
        Me.Around_txt.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Around_txt.Location = New System.Drawing.Point(104, 273)
        Me.Around_txt.Multiline = True
        Me.Around_txt.Name = "Around_txt"
        Me.Around_txt.Size = New System.Drawing.Size(377, 110)
        Me.Around_txt.TabIndex = 39
        '
        'Default_txt
        '
        Me.Default_txt.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Default_txt.Location = New System.Drawing.Point(104, 157)
        Me.Default_txt.Multiline = True
        Me.Default_txt.Name = "Default_txt"
        Me.Default_txt.Size = New System.Drawing.Size(377, 110)
        Me.Default_txt.TabIndex = 38
        '
        'TypeCB
        '
        Me.TypeCB.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.TypeCB.ForeColor = System.Drawing.Color.DimGray
        Me.TypeCB.FormattingEnabled = True
        Me.TypeCB.Location = New System.Drawing.Point(104, 120)
        Me.TypeCB.Name = "TypeCB"
        Me.TypeCB.Size = New System.Drawing.Size(148, 23)
        Me.TypeCB.TabIndex = 35
        '
        'FeaCB
        '
        Me.FeaCB.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.FeaCB.ForeColor = System.Drawing.Color.DimGray
        Me.FeaCB.FormattingEnabled = True
        Me.FeaCB.Location = New System.Drawing.Point(104, 88)
        Me.FeaCB.Name = "FeaCB"
        Me.FeaCB.Size = New System.Drawing.Size(148, 23)
        Me.FeaCB.TabIndex = 37
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.DimGray
        Me.Label7.Location = New System.Drawing.Point(17, 402)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(66, 15)
        Me.Label7.TabIndex = 34
        Me.Label7.Text = "등급 산정 :"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.DimGray
        Me.Label6.Location = New System.Drawing.Point(27, 273)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(56, 15)
        Me.Label6.TabIndex = 33
        Me.Label6.Text = "Around :"
        '
        'AppCB
        '
        Me.AppCB.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.AppCB.ForeColor = System.Drawing.Color.DimGray
        Me.AppCB.FormattingEnabled = True
        Me.AppCB.Location = New System.Drawing.Point(104, 55)
        Me.AppCB.Name = "AppCB"
        Me.AppCB.Size = New System.Drawing.Size(148, 23)
        Me.AppCB.TabIndex = 36
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.DimGray
        Me.Label5.Location = New System.Drawing.Point(24, 157)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(59, 15)
        Me.Label5.TabIndex = 32
        Me.Label5.Text = "기본 검증"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.DimGray
        Me.Label4.Location = New System.Drawing.Point(12, 123)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(71, 15)
        Me.Label4.TabIndex = 31
        Me.Label4.Text = "Test Type :"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.DimGray
        Me.Label8.Location = New System.Drawing.Point(273, 57)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(50, 15)
        Me.Label8.TabIndex = 30
        Me.Label8.Text = "요청자 :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.DimGray
        Me.Label3.Location = New System.Drawing.Point(25, 91)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(58, 15)
        Me.Label3.TabIndex = 29
        Me.Label3.Text = "Feature :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.DimGray
        Me.Label2.Location = New System.Drawing.Point(6, 58)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(77, 15)
        Me.Label2.TabIndex = 28
        Me.Label2.Text = "App Name :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Malgun Gothic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.DimGray
        Me.Label1.Location = New System.Drawing.Point(99, 7)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(230, 25)
        Me.Label1.TabIndex = 27
        Me.Label1.Text = "기본 검증 내용 추가 요청"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(8, 7)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(85, 27)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 26
        Me.PictureBox1.TabStop = False
        '
        'Tip_Request_GM
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(494, 481)
        Me.Controls.Add(Me.Requester)
        Me.Controls.Add(Me.Submit_btn)
        Me.Controls.Add(Me.opFull)
        Me.Controls.Add(Me.opBasic)
        Me.Controls.Add(Me.opSanity)
        Me.Controls.Add(Me.Around_txt)
        Me.Controls.Add(Me.Default_txt)
        Me.Controls.Add(Me.TypeCB)
        Me.Controls.Add(Me.FeaCB)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.AppCB)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Name = "Tip_Request_GM"
        Me.Text = "Tip_Request_GM"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Requester As Windows.Forms.TextBox
    Friend WithEvents Submit_btn As Windows.Forms.Button
    Friend WithEvents opFull As Windows.Forms.RadioButton
    Friend WithEvents opBasic As Windows.Forms.RadioButton
    Friend WithEvents opSanity As Windows.Forms.RadioButton
    Friend WithEvents Around_txt As Windows.Forms.TextBox
    Friend WithEvents Default_txt As Windows.Forms.TextBox
    Friend WithEvents TypeCB As Windows.Forms.ComboBox
    Friend WithEvents FeaCB As Windows.Forms.ComboBox
    Friend WithEvents Label7 As Windows.Forms.Label
    Friend WithEvents Label6 As Windows.Forms.Label
    Friend WithEvents AppCB As Windows.Forms.ComboBox
    Friend WithEvents Label5 As Windows.Forms.Label
    Friend WithEvents Label4 As Windows.Forms.Label
    Friend WithEvents Label8 As Windows.Forms.Label
    Friend WithEvents Label3 As Windows.Forms.Label
    Friend WithEvents Label2 As Windows.Forms.Label
    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents PictureBox1 As Windows.Forms.PictureBox
End Class
