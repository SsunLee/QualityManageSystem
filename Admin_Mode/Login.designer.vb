<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Login
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Login))
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.password = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.request_pw = New System.Windows.Forms.LinkLabel()
        Me.ChkLabel = New System.Windows.Forms.Label()
        Me.ID = New System.Windows.Forms.TextBox()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(12, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(100, 28)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 3
        Me.PictureBox1.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Gray
        Me.Label1.Location = New System.Drawing.Point(118, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(162, 15)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "관리자용 암호를 입력하세요."
        '
        'password
        '
        Me.password.BackColor = System.Drawing.SystemColors.Info
        Me.password.Location = New System.Drawing.Point(12, 80)
        Me.password.Name = "password"
        Me.password.Size = New System.Drawing.Size(169, 21)
        Me.password.TabIndex = 5
        '
        'Button1
        '
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.Gray
        Me.Button1.Location = New System.Drawing.Point(198, 53)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(100, 25)
        Me.Button1.TabIndex = 6
        Me.Button1.Text = "Login"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'request_pw
        '
        Me.request_pw.AutoSize = True
        Me.request_pw.Location = New System.Drawing.Point(11, 149)
        Me.request_pw.Name = "request_pw"
        Me.request_pw.Size = New System.Drawing.Size(81, 12)
        Me.request_pw.TabIndex = 7
        Me.request_pw.TabStop = True
        Me.request_pw.Text = "암호 문의하기"
        '
        'ChkLabel
        '
        Me.ChkLabel.AutoSize = True
        Me.ChkLabel.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.ChkLabel.ForeColor = System.Drawing.Color.Gray
        Me.ChkLabel.Location = New System.Drawing.Point(10, 104)
        Me.ChkLabel.Name = "ChkLabel"
        Me.ChkLabel.Size = New System.Drawing.Size(0, 15)
        Me.ChkLabel.TabIndex = 4
        '
        'ID
        '
        Me.ID.BackColor = System.Drawing.SystemColors.Info
        Me.ID.Location = New System.Drawing.Point(12, 53)
        Me.ID.Name = "ID"
        Me.ID.Size = New System.Drawing.Size(169, 21)
        Me.ID.TabIndex = 5
        '
        'Login
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(430, 170)
        Me.Controls.Add(Me.request_pw)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.ID)
        Me.Controls.Add(Me.password)
        Me.Controls.Add(Me.ChkLabel)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Login"
        Me.Text = "Login"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PictureBox1 As Windows.Forms.PictureBox
    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents password As Windows.Forms.TextBox
    Friend WithEvents Button1 As Windows.Forms.Button
    Friend WithEvents request_pw As Windows.Forms.LinkLabel
    Friend WithEvents ChkLabel As Windows.Forms.Label
    Friend WithEvents ID As Windows.Forms.TextBox
End Class
