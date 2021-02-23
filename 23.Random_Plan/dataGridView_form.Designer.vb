<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class dataGridView_form
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(dataGridView_form))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.txt_Comp = New System.Windows.Forms.TextBox()
        Me.txt_pro_in = New System.Windows.Forms.TextBox()
        Me.txt_model_in = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Splitter1 = New System.Windows.Forms.Splitter()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtCompnay_in = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtRequest_in = New System.Windows.Forms.TextBox()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Button3)
        Me.Panel1.Controls.Add(Me.Button2)
        Me.Panel1.Controls.Add(Me.PictureBox2)
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Controls.Add(Me.txt_Comp)
        Me.Panel1.Controls.Add(Me.txt_pro_in)
        Me.Panel1.Controls.Add(Me.txtRequest_in)
        Me.Panel1.Controls.Add(Me.txtCompnay_in)
        Me.Panel1.Controls.Add(Me.txt_model_in)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(996, 90)
        Me.Panel1.TabIndex = 0
        '
        'Button2
        '
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("맑은 고딕", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Button2.Location = New System.Drawing.Point(767, 12)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(76, 37)
        Me.Button2.TabIndex = 186
        Me.Button2.Text = "엑셀" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "가져오기"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'PictureBox2
        '
        Me.PictureBox2.BackgroundImage = CType(resources.GetObject("PictureBox2.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox2.InitialImage = CType(resources.GetObject("PictureBox2.InitialImage"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(12, 10)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(131, 23)
        Me.PictureBox2.TabIndex = 185
        Me.PictureBox2.TabStop = False
        '
        'Button1
        '
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Button1.Location = New System.Drawing.Point(924, 12)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(63, 37)
        Me.Button1.TabIndex = 28
        Me.Button1.Text = "DB_UP"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'txt_Comp
        '
        Me.txt_Comp.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txt_Comp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_Comp.Location = New System.Drawing.Point(168, 12)
        Me.txt_Comp.Name = "txt_Comp"
        Me.txt_Comp.Size = New System.Drawing.Size(102, 21)
        Me.txt_Comp.TabIndex = 27
        '
        'txt_pro_in
        '
        Me.txt_pro_in.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_pro_in.Location = New System.Drawing.Point(344, 13)
        Me.txt_pro_in.Name = "txt_pro_in"
        Me.txt_pro_in.Size = New System.Drawing.Size(100, 21)
        Me.txt_pro_in.TabIndex = 24
        '
        'txt_model_in
        '
        Me.txt_model_in.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_model_in.Location = New System.Drawing.Point(344, 46)
        Me.txt_model_in.Name = "txt_model_in"
        Me.txt_model_in.Size = New System.Drawing.Size(100, 21)
        Me.txt_model_in.TabIndex = 23
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(285, 15)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(53, 12)
        Me.Label4.TabIndex = 21
        Me.Label4.Text = "프로젝트"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(309, 48)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(29, 12)
        Me.Label3.TabIndex = 22
        Me.Label3.Text = "모델"
        '
        'Splitter1
        '
        Me.Splitter1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Splitter1.Location = New System.Drawing.Point(0, 90)
        Me.Splitter1.Name = "Splitter1"
        Me.Splitter1.Size = New System.Drawing.Size(996, 3)
        Me.Splitter1.TabIndex = 1
        Me.Splitter1.TabStop = False
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.DataGridView1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 93)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(996, 505)
        Me.Panel2.TabIndex = 2
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowTemplate.Height = 23
        Me.DataGridView1.Size = New System.Drawing.Size(996, 505)
        Me.DataGridView1.TabIndex = 0
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'Button3
        '
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Button3.Location = New System.Drawing.Point(849, 12)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(69, 37)
        Me.Button3.TabIndex = 187
        Me.Button3.Text = "DB확인"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(475, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 12)
        Me.Label1.TabIndex = 22
        Me.Label1.Text = "업체명"
        '
        'txtCompnay_in
        '
        Me.txtCompnay_in.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCompnay_in.Location = New System.Drawing.Point(522, 13)
        Me.txtCompnay_in.Name = "txtCompnay_in"
        Me.txtCompnay_in.Size = New System.Drawing.Size(100, 21)
        Me.txtCompnay_in.TabIndex = 23
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(475, 46)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 12)
        Me.Label2.TabIndex = 22
        Me.Label2.Text = "등록자"
        '
        'txtRequest_in
        '
        Me.txtRequest_in.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRequest_in.Location = New System.Drawing.Point(522, 46)
        Me.txtRequest_in.Name = "txtRequest_in"
        Me.txtRequest_in.Size = New System.Drawing.Size(100, 21)
        Me.txtRequest_in.TabIndex = 23
        '
        'dataGridView_form
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(996, 598)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Splitter1)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "dataGridView_form"
        Me.Text = "dataGridView"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Windows.Forms.Panel
    Friend WithEvents Splitter1 As Windows.Forms.Splitter
    Friend WithEvents Panel2 As Windows.Forms.Panel
    Friend WithEvents DataGridView1 As Windows.Forms.DataGridView
    Friend WithEvents Button1 As Windows.Forms.Button
    Friend WithEvents txt_Comp As Windows.Forms.TextBox
    Friend WithEvents txt_pro_in As Windows.Forms.TextBox
    Friend WithEvents txt_model_in As Windows.Forms.TextBox
    Friend WithEvents Label4 As Windows.Forms.Label
    Friend WithEvents Label3 As Windows.Forms.Label
    Friend WithEvents PictureBox2 As Windows.Forms.PictureBox
    Friend WithEvents Button2 As Windows.Forms.Button
    Friend WithEvents OpenFileDialog1 As Windows.Forms.OpenFileDialog
    Friend WithEvents Button3 As Windows.Forms.Button
    Friend WithEvents txtRequest_in As Windows.Forms.TextBox
    Friend WithEvents txtCompnay_in As Windows.Forms.TextBox
    Friend WithEvents Label2 As Windows.Forms.Label
    Friend WithEvents Label1 As Windows.Forms.Label
End Class
