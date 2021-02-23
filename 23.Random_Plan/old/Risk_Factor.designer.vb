<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Risk_Factor
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Risk_Factor))
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lst1 = New System.Windows.Forms.ListBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.btnExport = New System.Windows.Forms.Button()
        Me.txt1 = New System.Windows.Forms.RichTextBox()
        Me.txtRisk = New System.Windows.Forms.RichTextBox()
        Me.cbApp = New System.Windows.Forms.ComboBox()
        Me.Label15 = New System.Windows.Forms.Label()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PictureBox2
        '
        Me.PictureBox2.BackgroundImage = CType(resources.GetObject("PictureBox2.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox2.Location = New System.Drawing.Point(8, 8)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(216, 25)
        Me.PictureBox2.TabIndex = 64
        Me.PictureBox2.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Malgun Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.DimGray
        Me.Label1.Location = New System.Drawing.Point(230, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(135, 20)
        Me.Label1.TabIndex = 63
        Me.Label1.Text = "검증계획서_담당자"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Malgun Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.DimGray
        Me.Label2.Location = New System.Drawing.Point(10, 40)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 20)
        Me.Label2.TabIndex = 63
        Me.Label2.Text = "P/M/C"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Malgun Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Gray
        Me.Label7.Location = New System.Drawing.Point(10, 128)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(54, 20)
        Me.Label7.TabIndex = 24
        Me.Label7.Text = "변경점"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Malgun Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Gray
        Me.Label3.Location = New System.Drawing.Point(11, 396)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(89, 20)
        Me.Label3.TabIndex = 24
        Me.Label3.Text = "변경점 내용"
        '
        'lst1
        '
        Me.lst1.AllowDrop = True
        Me.lst1.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.lst1.FormattingEnabled = True
        Me.lst1.HorizontalScrollbar = True
        Me.lst1.ItemHeight = 15
        Me.lst1.Location = New System.Drawing.Point(12, 153)
        Me.lst1.Name = "lst1"
        Me.lst1.ScrollAlwaysVisible = True
        Me.lst1.Size = New System.Drawing.Size(426, 229)
        Me.lst1.Sorted = True
        Me.lst1.TabIndex = 11
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Malgun Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.Gray
        Me.Label16.Location = New System.Drawing.Point(449, 127)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(117, 20)
        Me.Label16.TabIndex = 24
        Me.Label16.Text = "RiskFactor 작성"
        '
        'Button1
        '
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Malgun Gothic", 8.0!)
        Me.Button1.ForeColor = System.Drawing.Color.Black
        Me.Button1.Location = New System.Drawing.Point(364, 120)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(71, 27)
        Me.Button1.TabIndex = 12
        Me.Button1.Text = "추출 btn"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'btnExport
        '
        Me.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExport.Font = New System.Drawing.Font("Malgun Gothic", 8.0!)
        Me.btnExport.ForeColor = System.Drawing.Color.Black
        Me.btnExport.Location = New System.Drawing.Point(717, 23)
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Size = New System.Drawing.Size(106, 43)
        Me.btnExport.TabIndex = 12
        Me.btnExport.Text = "App Risk Export"
        Me.btnExport.UseVisualStyleBackColor = True
        '
        'txt1
        '
        Me.txt1.BackColor = System.Drawing.Color.White
        Me.txt1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt1.Font = New System.Drawing.Font("Malgun Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.txt1.Location = New System.Drawing.Point(12, 419)
        Me.txt1.Name = "txt1"
        Me.txt1.ReadOnly = True
        Me.txt1.Size = New System.Drawing.Size(426, 146)
        Me.txt1.TabIndex = 148
        Me.txt1.Text = ""
        '
        'txtRisk
        '
        Me.txtRisk.BackColor = System.Drawing.Color.White
        Me.txtRisk.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRisk.Font = New System.Drawing.Font("Malgun Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.txtRisk.Location = New System.Drawing.Point(449, 153)
        Me.txtRisk.Name = "txtRisk"
        Me.txtRisk.Size = New System.Drawing.Size(374, 412)
        Me.txtRisk.TabIndex = 148
        Me.txtRisk.Text = ""
        '
        'cbApp
        '
        Me.cbApp.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cbApp.Font = New System.Drawing.Font("Malgun Gothic", 9.0!)
        Me.cbApp.FormattingEnabled = True
        Me.cbApp.Location = New System.Drawing.Point(64, 82)
        Me.cbApp.Name = "cbApp"
        Me.cbApp.Size = New System.Drawing.Size(170, 23)
        Me.cbApp.Sorted = True
        Me.cbApp.TabIndex = 149
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Malgun Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.Gray
        Me.Label15.Location = New System.Drawing.Point(10, 81)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(38, 20)
        Me.Label15.TabIndex = 150
        Me.Label15.Text = "App"
        '
        'Risk_Factor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(840, 578)
        Me.Controls.Add(Me.cbApp)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtRisk)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lst1)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.btnExport)
        Me.Controls.Add(Me.txt1)
        Me.Name = "Risk_Factor"
        Me.Text = "Risk_Factor"
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PictureBox2 As Windows.Forms.PictureBox
    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents Label2 As Windows.Forms.Label
    Friend WithEvents Label7 As Windows.Forms.Label
    Friend WithEvents Label3 As Windows.Forms.Label
    Friend WithEvents lst1 As Windows.Forms.ListBox
    Friend WithEvents Label16 As Windows.Forms.Label
    Friend WithEvents Button1 As Windows.Forms.Button
    Friend WithEvents btnExport As Windows.Forms.Button
    Friend WithEvents txt1 As Windows.Forms.RichTextBox
    Friend WithEvents txtRisk As Windows.Forms.RichTextBox
    Friend WithEvents cbApp As Windows.Forms.ComboBox
    Friend WithEvents Label15 As Windows.Forms.Label
End Class
