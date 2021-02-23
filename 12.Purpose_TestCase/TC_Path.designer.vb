<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TC_Path
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TC_Path))
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Default_Path = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.CNS_txt = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.INFINIQ_txt = New System.Windows.Forms.TextBox()
        Me.MSTech_txt = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Infiniq_btn = New System.Windows.Forms.Button()
        Me.Mstech_btn = New System.Windows.Forms.Button()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(3, 2)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(101, 28)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 4
        Me.PictureBox1.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Malgun Gothic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.DimGray
        Me.Label2.Location = New System.Drawing.Point(110, 2)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(84, 25)
        Me.Label2.TabIndex = 29
        Me.Label2.Text = "TC Info."
        '
        'Default_Path
        '
        Me.Default_Path.BackColor = System.Drawing.SystemColors.Info
        Me.Default_Path.Location = New System.Drawing.Point(96, 40)
        Me.Default_Path.Multiline = True
        Me.Default_Path.Name = "Default_Path"
        Me.Default_Path.Size = New System.Drawing.Size(573, 27)
        Me.Default_Path.TabIndex = 31
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(23, 43)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 12)
        Me.Label1.TabIndex = 32
        Me.Label1.Text = "현재 경로"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(41, 84)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(489, 12)
        Me.Label4.TabIndex = 33
        Me.Label4.Text = "※ 만약 경로에 이상이 있거나, 프로그램 오류가 발생 한다면 ""현재 경로""를 확인 해주세요."
        '
        'CNS_txt
        '
        Me.CNS_txt.BackColor = System.Drawing.Color.White
        Me.CNS_txt.Location = New System.Drawing.Point(151, 116)
        Me.CNS_txt.Multiline = True
        Me.CNS_txt.Name = "CNS_txt"
        Me.CNS_txt.Size = New System.Drawing.Size(518, 27)
        Me.CNS_txt.TabIndex = 31
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(23, 119)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(110, 12)
        Me.Label3.TabIndex = 32
        Me.Label3.Text = "목적TC 경로(CNS)"
        '
        'INFINIQ_txt
        '
        Me.INFINIQ_txt.BackColor = System.Drawing.Color.White
        Me.INFINIQ_txt.Location = New System.Drawing.Point(151, 149)
        Me.INFINIQ_txt.Multiline = True
        Me.INFINIQ_txt.Name = "INFINIQ_txt"
        Me.INFINIQ_txt.Size = New System.Drawing.Size(518, 27)
        Me.INFINIQ_txt.TabIndex = 31
        '
        'MSTech_txt
        '
        Me.MSTech_txt.BackColor = System.Drawing.Color.White
        Me.MSTech_txt.Location = New System.Drawing.Point(151, 182)
        Me.MSTech_txt.Multiline = True
        Me.MSTech_txt.Name = "MSTech_txt"
        Me.MSTech_txt.Size = New System.Drawing.Size(518, 27)
        Me.MSTech_txt.TabIndex = 31
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(23, 151)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(120, 12)
        Me.Label5.TabIndex = 32
        Me.Label5.Text = "목적TC 경로(인피닉)"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(23, 182)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(120, 12)
        Me.Label6.TabIndex = 32
        Me.Label6.Text = "목적TC 경로(엠스텍)"
        '
        'Button1
        '
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Button1.Location = New System.Drawing.Point(690, 116)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 27)
        Me.Button1.TabIndex = 34
        Me.Button1.Text = "폴더 열기"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Infiniq_btn
        '
        Me.Infiniq_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Infiniq_btn.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Infiniq_btn.Location = New System.Drawing.Point(690, 149)
        Me.Infiniq_btn.Name = "Infiniq_btn"
        Me.Infiniq_btn.Size = New System.Drawing.Size(75, 27)
        Me.Infiniq_btn.TabIndex = 34
        Me.Infiniq_btn.Text = "폴더 열기"
        Me.Infiniq_btn.UseVisualStyleBackColor = True
        '
        'Mstech_btn
        '
        Me.Mstech_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Mstech_btn.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Mstech_btn.Location = New System.Drawing.Point(690, 182)
        Me.Mstech_btn.Name = "Mstech_btn"
        Me.Mstech_btn.Size = New System.Drawing.Size(75, 27)
        Me.Mstech_btn.TabIndex = 34
        Me.Mstech_btn.Text = "폴더 열기"
        Me.Mstech_btn.UseVisualStyleBackColor = True
        '
        'TC_Path
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(777, 282)
        Me.Controls.Add(Me.Mstech_btn)
        Me.Controls.Add(Me.Infiniq_btn)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.MSTech_txt)
        Me.Controls.Add(Me.INFINIQ_txt)
        Me.Controls.Add(Me.CNS_txt)
        Me.Controls.Add(Me.Default_Path)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.PictureBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "TC_Path"
        Me.Text = "TC_Path"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PictureBox1 As Windows.Forms.PictureBox
    Friend WithEvents Label2 As Windows.Forms.Label
    Friend WithEvents Default_Path As Windows.Forms.TextBox
    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents Label4 As Windows.Forms.Label
    Friend WithEvents CNS_txt As Windows.Forms.TextBox
    Friend WithEvents Label3 As Windows.Forms.Label
    Friend WithEvents INFINIQ_txt As Windows.Forms.TextBox
    Friend WithEvents MSTech_txt As Windows.Forms.TextBox
    Friend WithEvents Label5 As Windows.Forms.Label
    Friend WithEvents Label6 As Windows.Forms.Label
    Friend WithEvents Button1 As Windows.Forms.Button
    Friend WithEvents Infiniq_btn As Windows.Forms.Button
    Friend WithEvents Mstech_btn As Windows.Forms.Button
End Class
