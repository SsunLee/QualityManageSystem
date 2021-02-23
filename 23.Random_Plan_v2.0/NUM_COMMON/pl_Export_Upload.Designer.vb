<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class pl_Export_Upload
    Inherits System.Windows.Forms.Form

    'Form은 Dispose를 재정의하여 구성 요소 목록을 정리합니다.
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

    'Windows Form 디자이너에 필요합니다.
    Private components As System.ComponentModel.IContainer

    '참고: 다음 프로시저는 Windows Form 디자이너에 필요합니다.
    '수정하려면 Windows Form 디자이너를 사용하십시오.  
    '코드 편집기에서는 수정하지 마세요.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(pl_Export_Upload))
        Me.txtPro = New System.Windows.Forms.TextBox()
        Me.txtMod = New System.Windows.Forms.TextBox()
        Me.txtStep = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btn_Stop = New System.Windows.Forms.Button()
        Me.txtSuf = New System.Windows.Forms.TextBox()
        Me.txtCompany = New System.Windows.Forms.TextBox()
        Me.btn_Search = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.PicUpload = New System.Windows.Forms.PictureBox()
        Me.picExport = New System.Windows.Forms.PictureBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.GroupBox1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.PicUpload, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picExport, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtPro
        '
        Me.txtPro.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtPro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPro.Location = New System.Drawing.Point(90, 36)
        Me.txtPro.Name = "txtPro"
        Me.txtPro.Size = New System.Drawing.Size(146, 27)
        Me.txtPro.TabIndex = 0
        '
        'txtMod
        '
        Me.txtMod.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMod.Location = New System.Drawing.Point(90, 72)
        Me.txtMod.Name = "txtMod"
        Me.txtMod.Size = New System.Drawing.Size(146, 27)
        Me.txtMod.TabIndex = 0
        '
        'txtStep
        '
        Me.txtStep.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtStep.Location = New System.Drawing.Point(90, 108)
        Me.txtStep.Name = "txtStep"
        Me.txtStep.Size = New System.Drawing.Size(146, 27)
        Me.txtStep.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label1.ForeColor = System.Drawing.Color.Gray
        Me.Label1.Location = New System.Drawing.Point(23, 36)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(58, 20)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Project"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btn_Stop)
        Me.GroupBox1.Controls.Add(Me.txtSuf)
        Me.GroupBox1.Controls.Add(Me.txtCompany)
        Me.GroupBox1.Controls.Add(Me.btn_Search)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtPro)
        Me.GroupBox1.Controls.Add(Me.txtStep)
        Me.GroupBox1.Controls.Add(Me.txtMod)
        Me.GroupBox1.Font = New System.Drawing.Font("맑은 고딕", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.DimGray
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(571, 151)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "검색할 모델 정보를 입력하세요."
        '
        'btn_Stop
        '
        Me.btn_Stop.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Stop.Location = New System.Drawing.Point(490, 79)
        Me.btn_Stop.Name = "btn_Stop"
        Me.btn_Stop.Size = New System.Drawing.Size(74, 31)
        Me.btn_Stop.TabIndex = 8
        Me.btn_Stop.Text = "취소"
        Me.btn_Stop.UseVisualStyleBackColor = True
        '
        'txtSuf
        '
        Me.txtSuf.Location = New System.Drawing.Point(331, 76)
        Me.txtSuf.Name = "txtSuf"
        Me.txtSuf.Size = New System.Drawing.Size(121, 27)
        Me.txtSuf.TabIndex = 7
        '
        'txtCompany
        '
        Me.txtCompany.Location = New System.Drawing.Point(331, 35)
        Me.txtCompany.Name = "txtCompany"
        Me.txtCompany.Size = New System.Drawing.Size(121, 27)
        Me.txtCompany.TabIndex = 6
        '
        'btn_Search
        '
        Me.btn_Search.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Search.Location = New System.Drawing.Point(490, 35)
        Me.btn_Search.Name = "btn_Search"
        Me.btn_Search.Size = New System.Drawing.Size(75, 32)
        Me.btn_Search.TabIndex = 2
        Me.btn_Search.Text = "검색"
        Me.btn_Search.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label3.ForeColor = System.Drawing.Color.Gray
        Me.Label3.Location = New System.Drawing.Point(41, 110)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(40, 20)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Step"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label2.ForeColor = System.Drawing.Color.Gray
        Me.Label2.Location = New System.Drawing.Point(28, 73)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 20)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Model"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label5.ForeColor = System.Drawing.Color.Gray
        Me.Label5.Location = New System.Drawing.Point(271, 79)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(50, 20)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "Suffix"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label6.ForeColor = System.Drawing.Color.Gray
        Me.Label6.Location = New System.Drawing.Point(271, 38)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(54, 20)
        Me.Label6.TabIndex = 1
        Me.Label6.Text = "업체명"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.PicUpload)
        Me.Panel1.Controls.Add(Me.picExport)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(595, 285)
        Me.Panel1.TabIndex = 3
        '
        'PicUpload
        '
        Me.PicUpload.Image = CType(resources.GetObject("PicUpload.Image"), System.Drawing.Image)
        Me.PicUpload.Location = New System.Drawing.Point(338, 242)
        Me.PicUpload.Name = "PicUpload"
        Me.PicUpload.Size = New System.Drawing.Size(109, 29)
        Me.PicUpload.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PicUpload.TabIndex = 11
        Me.PicUpload.TabStop = False
        '
        'picExport
        '
        Me.picExport.Cursor = System.Windows.Forms.Cursors.Hand
        Me.picExport.Image = CType(resources.GetObject("picExport.Image"), System.Drawing.Image)
        Me.picExport.Location = New System.Drawing.Point(15, 242)
        Me.picExport.Name = "picExport"
        Me.picExport.Size = New System.Drawing.Size(151, 29)
        Me.picExport.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picExport.TabIndex = 10
        Me.picExport.TabStop = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("맑은 고딕", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label8.Location = New System.Drawing.Point(192, 251)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(49, 17)
        Me.Label8.TabIndex = 9
        Me.Label8.Text = "Label8"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Maroon
        Me.Label7.Location = New System.Drawing.Point(335, 178)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(250, 45)
        Me.Label7.TabIndex = 3
        Me.Label7.Text = "※ Upload GUIDE " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & " 1) Export에서 작성한 파일을 드래그 합니다." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & " 2) 올립니다." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Maroon
        Me.Label4.Location = New System.Drawing.Point(12, 166)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(296, 60)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "※ Export GUIDE " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & " 1) Risk Factor를 작성 할 모델을 검색 합니다." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & " 2) ' Export' 를 눌러 엑셀을 아무 경로에" &
    " 저장 합니다." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & " 3) 내용 작성 합니다." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.ListView1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 285)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(595, 248)
        Me.Panel2.TabIndex = 4
        '
        'ListView1
        '
        Me.ListView1.BackColor = System.Drawing.Color.White
        Me.ListView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ListView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.ListView1.Location = New System.Drawing.Point(0, 0)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(595, 248)
        Me.ListView1.Sorting = System.Windows.Forms.SortOrder.Ascending
        Me.ListView1.TabIndex = 0
        Me.ListView1.UseCompatibleStateImageBehavior = False
        '
        'pl_Export_Upload
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(595, 533)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "pl_Export_Upload"
        Me.Text = "Risk Factor 작성"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PicUpload, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picExport, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents txtPro As Windows.Forms.TextBox
    Friend WithEvents txtMod As Windows.Forms.TextBox
    Friend WithEvents txtStep As Windows.Forms.TextBox
    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents GroupBox1 As Windows.Forms.GroupBox
    Friend WithEvents Label3 As Windows.Forms.Label
    Friend WithEvents Label2 As Windows.Forms.Label
    Friend WithEvents btn_Search As Windows.Forms.Button
    Friend WithEvents Panel1 As Windows.Forms.Panel
    Friend WithEvents Panel2 As Windows.Forms.Panel
    Friend WithEvents ListView1 As Windows.Forms.ListView
    Friend WithEvents txtCompany As Windows.Forms.TextBox
    Friend WithEvents Label6 As Windows.Forms.Label
    Friend WithEvents Label7 As Windows.Forms.Label
    Friend WithEvents Label4 As Windows.Forms.Label
    Friend WithEvents txtSuf As Windows.Forms.TextBox
    Friend WithEvents Label5 As Windows.Forms.Label
    Friend WithEvents btn_Stop As Windows.Forms.Button
    Friend WithEvents Label8 As Windows.Forms.Label
    Friend WithEvents picExport As Windows.Forms.PictureBox
    Friend WithEvents PicUpload As Windows.Forms.PictureBox
End Class
