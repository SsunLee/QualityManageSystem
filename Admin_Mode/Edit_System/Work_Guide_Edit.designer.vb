<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Work_Guide_Edit
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Work_Guide_Edit))
        Me.btnDel = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.btnMod = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.btnRe = New System.Windows.Forms.Button()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.btnFileLoad = New System.Windows.Forms.Button()
        Me.GubunCB = New System.Windows.Forms.ComboBox()
        Me.TestGubunCB = New System.Windows.Forms.ComboBox()
        Me.txtDes = New System.Windows.Forms.TextBox()
        Me.txtFileName = New System.Windows.Forms.TextBox()
        Me.txtTitle = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.txtDepth2 = New System.Windows.Forms.TextBox()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnDel
        '
        Me.btnDel.BackColor = System.Drawing.Color.White
        Me.btnDel.Font = New System.Drawing.Font("Malgun Gothic", 9.0!)
        Me.btnDel.Location = New System.Drawing.Point(978, 521)
        Me.btnDel.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnDel.Name = "btnDel"
        Me.btnDel.Size = New System.Drawing.Size(75, 29)
        Me.btnDel.TabIndex = 73
        Me.btnDel.Text = "Delete"
        Me.btnDel.UseVisualStyleBackColor = False
        '
        'btnAdd
        '
        Me.btnAdd.BackColor = System.Drawing.Color.White
        Me.btnAdd.Font = New System.Drawing.Font("Malgun Gothic", 9.0!)
        Me.btnAdd.Location = New System.Drawing.Point(816, 521)
        Me.btnAdd.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(75, 29)
        Me.btnAdd.TabIndex = 71
        Me.btnAdd.Text = "Add"
        Me.btnAdd.UseVisualStyleBackColor = False
        '
        'btnMod
        '
        Me.btnMod.BackColor = System.Drawing.Color.White
        Me.btnMod.Font = New System.Drawing.Font("Malgun Gothic", 9.0!)
        Me.btnMod.Location = New System.Drawing.Point(897, 521)
        Me.btnMod.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnMod.Name = "btnMod"
        Me.btnMod.Size = New System.Drawing.Size(75, 29)
        Me.btnMod.TabIndex = 72
        Me.btnMod.Text = "Modify"
        Me.btnMod.UseVisualStyleBackColor = False
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonFace
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(8, 43)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowTemplate.Height = 23
        Me.DataGridView1.Size = New System.Drawing.Size(1045, 296)
        Me.DataGridView1.TabIndex = 61
        '
        'btnRe
        '
        Me.btnRe.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRe.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.btnRe.Location = New System.Drawing.Point(943, 8)
        Me.btnRe.Name = "btnRe"
        Me.btnRe.Size = New System.Drawing.Size(106, 29)
        Me.btnRe.TabIndex = 74
        Me.btnRe.Text = "List Refresh"
        Me.btnRe.UseVisualStyleBackColor = True
        '
        'btnClear
        '
        Me.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClear.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.btnClear.Location = New System.Drawing.Point(697, 521)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(75, 29)
        Me.btnClear.TabIndex = 75
        Me.btnClear.Text = "Clear"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'btnFileLoad
        '
        Me.btnFileLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFileLoad.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.btnFileLoad.Location = New System.Drawing.Point(828, 8)
        Me.btnFileLoad.Name = "btnFileLoad"
        Me.btnFileLoad.Size = New System.Drawing.Size(109, 29)
        Me.btnFileLoad.TabIndex = 76
        Me.btnFileLoad.Text = "파일 경로확인"
        Me.btnFileLoad.UseVisualStyleBackColor = True
        '
        'GubunCB
        '
        Me.GubunCB.BackColor = System.Drawing.SystemColors.Info
        Me.GubunCB.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.GubunCB.ForeColor = System.Drawing.Color.DimGray
        Me.GubunCB.FormattingEnabled = True
        Me.GubunCB.Location = New System.Drawing.Point(8, 377)
        Me.GubunCB.Name = "GubunCB"
        Me.GubunCB.Size = New System.Drawing.Size(199, 23)
        Me.GubunCB.TabIndex = 62
        Me.GubunCB.Tag = "구분"
        '
        'TestGubunCB
        '
        Me.TestGubunCB.BackColor = System.Drawing.SystemColors.Info
        Me.TestGubunCB.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.TestGubunCB.ForeColor = System.Drawing.Color.DimGray
        Me.TestGubunCB.FormattingEnabled = True
        Me.TestGubunCB.Location = New System.Drawing.Point(213, 377)
        Me.TestGubunCB.Name = "TestGubunCB"
        Me.TestGubunCB.Size = New System.Drawing.Size(162, 23)
        Me.TestGubunCB.TabIndex = 63
        Me.TestGubunCB.Tag = "검증구분"
        '
        'txtDes
        '
        Me.txtDes.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.txtDes.ForeColor = System.Drawing.Color.DimGray
        Me.txtDes.Location = New System.Drawing.Point(8, 431)
        Me.txtDes.Multiline = True
        Me.txtDes.Name = "txtDes"
        Me.txtDes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtDes.Size = New System.Drawing.Size(679, 178)
        Me.txtDes.TabIndex = 67
        Me.txtDes.Tag = "Description"
        '
        'txtFileName
        '
        Me.txtFileName.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.txtFileName.ForeColor = System.Drawing.Color.DimGray
        Me.txtFileName.Location = New System.Drawing.Point(697, 431)
        Me.txtFileName.Name = "txtFileName"
        Me.txtFileName.Size = New System.Drawing.Size(356, 23)
        Me.txtFileName.TabIndex = 70
        Me.txtFileName.Tag = "파일명"
        '
        'txtTitle
        '
        Me.txtTitle.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.txtTitle.ForeColor = System.Drawing.Color.DimGray
        Me.txtTitle.Location = New System.Drawing.Point(697, 377)
        Me.txtTitle.Name = "txtTitle"
        Me.txtTitle.Size = New System.Drawing.Size(356, 23)
        Me.txtTitle.TabIndex = 65
        Me.txtTitle.Tag = "상세 분류"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.DimGray
        Me.Label4.Location = New System.Drawing.Point(5, 413)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(73, 15)
        Me.Label4.TabIndex = 85
        Me.Label4.Text = "Description"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.DimGray
        Me.Label8.Location = New System.Drawing.Point(378, 359)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(87, 15)
        Me.Label8.TabIndex = 83
        Me.Label8.Text = "상세 검증 구분"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.DimGray
        Me.Label9.Location = New System.Drawing.Point(6, 359)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(31, 15)
        Me.Label9.TabIndex = 82
        Me.Label9.Text = "구분"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.DimGray
        Me.Label5.Location = New System.Drawing.Point(694, 413)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(43, 15)
        Me.Label5.TabIndex = 79
        Me.Label5.Text = "파일명"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.DimGray
        Me.Label7.Location = New System.Drawing.Point(211, 359)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(59, 15)
        Me.Label7.TabIndex = 81
        Me.Label7.Text = "검증 구분"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.DimGray
        Me.Label1.Location = New System.Drawing.Point(694, 354)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(59, 15)
        Me.Label1.TabIndex = 80
        Me.Label1.Text = "상세 분류"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Malgun Gothic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.DimGray
        Me.Label2.Location = New System.Drawing.Point(112, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(107, 25)
        Me.Label2.TabIndex = 78
        Me.Label2.Text = "업무가이드"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(5, 9)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(101, 28)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 77
        Me.PictureBox1.TabStop = False
        '
        'txtDepth2
        '
        Me.txtDepth2.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.txtDepth2.ForeColor = System.Drawing.Color.DimGray
        Me.txtDepth2.Location = New System.Drawing.Point(381, 377)
        Me.txtDepth2.Name = "txtDepth2"
        Me.txtDepth2.Size = New System.Drawing.Size(306, 23)
        Me.txtDepth2.TabIndex = 65
        Me.txtDepth2.Tag = "상세검증구분"
        '
        'Work_Guide_Edit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1073, 621)
        Me.Controls.Add(Me.btnDel)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.btnMod)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.btnRe)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.btnFileLoad)
        Me.Controls.Add(Me.GubunCB)
        Me.Controls.Add(Me.TestGubunCB)
        Me.Controls.Add(Me.txtDes)
        Me.Controls.Add(Me.txtFileName)
        Me.Controls.Add(Me.txtDepth2)
        Me.Controls.Add(Me.txtTitle)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.PictureBox1)
        Me.Name = "Work_Guide_Edit"
        Me.Text = "Work_Guide_Edit"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnDel As Windows.Forms.Button
    Friend WithEvents btnAdd As Windows.Forms.Button
    Friend WithEvents btnMod As Windows.Forms.Button
    Friend WithEvents DataGridView1 As Windows.Forms.DataGridView
    Friend WithEvents btnRe As Windows.Forms.Button
    Friend WithEvents btnClear As Windows.Forms.Button
    Friend WithEvents btnFileLoad As Windows.Forms.Button
    Friend WithEvents GubunCB As Windows.Forms.ComboBox
    Friend WithEvents TestGubunCB As Windows.Forms.ComboBox
    Friend WithEvents txtDes As Windows.Forms.TextBox
    Friend WithEvents txtFileName As Windows.Forms.TextBox
    Friend WithEvents txtTitle As Windows.Forms.TextBox
    Friend WithEvents Label4 As Windows.Forms.Label
    Friend WithEvents Label8 As Windows.Forms.Label
    Friend WithEvents Label9 As Windows.Forms.Label
    Friend WithEvents Label5 As Windows.Forms.Label
    Friend WithEvents Label7 As Windows.Forms.Label
    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents Label2 As Windows.Forms.Label
    Friend WithEvents PictureBox1 As Windows.Forms.PictureBox
    Friend WithEvents txtDepth2 As Windows.Forms.TextBox
End Class
