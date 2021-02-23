<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Import_reflection_view
    Inherits System.Windows.Forms.Form

    'Form은 Dispose를 재정의하여 구성 요소 목록을 정리합니다.
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

    'Windows Form 디자이너에 필요합니다.
    Private components As System.ComponentModel.IContainer

    '참고: 다음 프로시저는 Windows Form 디자이너에 필요합니다.
    '수정하려면 Windows Form 디자이너를 사용하십시오.  
    '코드 편집기에서는 수정하지 마세요.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Import_reflection_view))
        Me.backPanel = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.DataGrid_Refelction = New System.Windows.Forms.DataGridView()
        Me.Splitter1 = New System.Windows.Forms.Splitter()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Btn_Search = New System.Windows.Forms.Button()
        Me.txt_Model = New System.Windows.Forms.TextBox()
        Me.txt_Project = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.txt_App = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.backPanel.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.DataGrid_Refelction, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'backPanel
        '
        Me.backPanel.Controls.Add(Me.Panel2)
        Me.backPanel.Controls.Add(Me.Splitter1)
        Me.backPanel.Controls.Add(Me.Panel1)
        Me.backPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.backPanel.Location = New System.Drawing.Point(0, 0)
        Me.backPanel.Name = "backPanel"
        Me.backPanel.Size = New System.Drawing.Size(800, 450)
        Me.backPanel.TabIndex = 0
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.DataGrid_Refelction)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(172, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(628, 450)
        Me.Panel2.TabIndex = 2
        '
        'DataGrid_Refelction
        '
        Me.DataGrid_Refelction.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGrid_Refelction.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGrid_Refelction.Location = New System.Drawing.Point(0, 0)
        Me.DataGrid_Refelction.Name = "DataGrid_Refelction"
        Me.DataGrid_Refelction.RowTemplate.Height = 23
        Me.DataGrid_Refelction.Size = New System.Drawing.Size(628, 450)
        Me.DataGrid_Refelction.TabIndex = 0
        '
        'Splitter1
        '
        Me.Splitter1.Location = New System.Drawing.Point(169, 0)
        Me.Splitter1.Name = "Splitter1"
        Me.Splitter1.Size = New System.Drawing.Size(3, 450)
        Me.Splitter1.TabIndex = 1
        Me.Splitter1.TabStop = False
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.txt_App)
        Me.Panel1.Controls.Add(Me.Btn_Search)
        Me.Panel1.Controls.Add(Me.txt_Model)
        Me.Panel1.Controls.Add(Me.txt_Project)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.PictureBox2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(169, 450)
        Me.Panel1.TabIndex = 0
        '
        'Btn_Search
        '
        Me.Btn_Search.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Btn_Search.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Btn_Search.Location = New System.Drawing.Point(52, 251)
        Me.Btn_Search.Name = "Btn_Search"
        Me.Btn_Search.Size = New System.Drawing.Size(75, 23)
        Me.Btn_Search.TabIndex = 228
        Me.Btn_Search.Text = "Search"
        Me.Btn_Search.UseVisualStyleBackColor = True
        '
        'txt_Model
        '
        Me.txt_Model.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_Model.Location = New System.Drawing.Point(5, 121)
        Me.txt_Model.Name = "txt_Model"
        Me.txt_Model.Size = New System.Drawing.Size(122, 21)
        Me.txt_Model.TabIndex = 227
        '
        'txt_Project
        '
        Me.txt_Project.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_Project.Location = New System.Drawing.Point(5, 66)
        Me.txt_Project.Name = "txt_Project"
        Me.txt_Project.Size = New System.Drawing.Size(122, 21)
        Me.txt_Project.TabIndex = 227
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(3, 51)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 12)
        Me.Label2.TabIndex = 226
        Me.Label2.Text = "프로젝트"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 106)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(29, 12)
        Me.Label1.TabIndex = 226
        Me.Label1.Text = "모델"
        '
        'PictureBox2
        '
        Me.PictureBox2.BackgroundImage = CType(resources.GetObject("PictureBox2.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox2.Location = New System.Drawing.Point(3, 3)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(151, 25)
        Me.PictureBox2.TabIndex = 225
        Me.PictureBox2.TabStop = False
        '
        'txt_App
        '
        Me.txt_App.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_App.Location = New System.Drawing.Point(5, 184)
        Me.txt_App.Name = "txt_App"
        Me.txt_App.Size = New System.Drawing.Size(117, 21)
        Me.txt_App.TabIndex = 229
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(3, 169)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(33, 12)
        Me.Label3.TabIndex = 226
        Me.Label3.Text = "앱 명"
        '
        'Import_reflection_view
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.backPanel)
        Me.Name = "Import_reflection_view"
        Me.Text = "import_reflection_view"
        Me.backPanel.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        CType(Me.DataGrid_Refelction, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents backPanel As Windows.Forms.Panel
    Friend WithEvents Panel2 As Windows.Forms.Panel
    Friend WithEvents Splitter1 As Windows.Forms.Splitter
    Friend WithEvents Panel1 As Windows.Forms.Panel
    Friend WithEvents PictureBox2 As Windows.Forms.PictureBox
    Friend WithEvents txt_Model As Windows.Forms.TextBox
    Friend WithEvents txt_Project As Windows.Forms.TextBox
    Friend WithEvents Label2 As Windows.Forms.Label
    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents DataGrid_Refelction As Windows.Forms.DataGridView
    Friend WithEvents Btn_Search As Windows.Forms.Button
    Friend WithEvents txt_App As Windows.Forms.TextBox
    Friend WithEvents Label3 As Windows.Forms.Label
End Class
