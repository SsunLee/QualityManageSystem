<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class P_Project_Plan
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(P_Project_Plan))
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.trvInfo = New System.Windows.Forms.TreeView()
        Me.Splitter3 = New System.Windows.Forms.Splitter()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.btnDown = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnEdit = New System.Windows.Forms.Button()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.txtPro = New System.Windows.Forms.TextBox()
        Me.txtMod = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Splitter1 = New System.Windows.Forms.Splitter()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.Panel10 = New System.Windows.Forms.Panel()
        Me.Panel12 = New System.Windows.Forms.Panel()
        Me.Panel14 = New System.Windows.Forms.Panel()
        Me.txtTypeResult = New System.Windows.Forms.TextBox()
        Me.Splitter6 = New System.Windows.Forms.Splitter()
        Me.Panel13 = New System.Windows.Forms.Panel()
        Me.txtChange_result = New System.Windows.Forms.TextBox()
        Me.Panel11 = New System.Windows.Forms.Panel()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Splitter5 = New System.Windows.Forms.Splitter()
        Me.Panel9 = New System.Windows.Forms.Panel()
        Me.Panel16 = New System.Windows.Forms.Panel()
        Me.Panel18 = New System.Windows.Forms.Panel()
        Me.txtRisk = New System.Windows.Forms.TextBox()
        Me.Splitter7 = New System.Windows.Forms.Splitter()
        Me.Panel17 = New System.Windows.Forms.Panel()
        Me.trvChange = New System.Windows.Forms.TreeView()
        Me.Panel15 = New System.Windows.Forms.Panel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Panel2.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel8.SuspendLayout()
        Me.Panel10.SuspendLayout()
        Me.Panel12.SuspendLayout()
        Me.Panel14.SuspendLayout()
        Me.Panel13.SuspendLayout()
        Me.Panel11.SuspendLayout()
        Me.Panel9.SuspendLayout()
        Me.Panel16.SuspendLayout()
        Me.Panel18.SuspendLayout()
        Me.Panel17.SuspendLayout()
        Me.Panel15.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Panel6)
        Me.Panel2.Controls.Add(Me.Splitter3)
        Me.Panel2.Controls.Add(Me.Panel5)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(200, 562)
        Me.Panel2.TabIndex = 0
        '
        'Panel6
        '
        Me.Panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel6.Controls.Add(Me.trvInfo)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel6.Location = New System.Drawing.Point(0, 189)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(200, 373)
        Me.Panel6.TabIndex = 2
        '
        'trvInfo
        '
        Me.trvInfo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.trvInfo.Location = New System.Drawing.Point(0, 0)
        Me.trvInfo.Name = "trvInfo"
        Me.trvInfo.Size = New System.Drawing.Size(198, 371)
        Me.trvInfo.TabIndex = 0
        '
        'Splitter3
        '
        Me.Splitter3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Splitter3.Location = New System.Drawing.Point(0, 186)
        Me.Splitter3.Name = "Splitter3"
        Me.Splitter3.Size = New System.Drawing.Size(200, 3)
        Me.Splitter3.TabIndex = 1
        Me.Splitter3.TabStop = False
        '
        'Panel5
        '
        Me.Panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel5.Controls.Add(Me.GroupBox1)
        Me.Panel5.Controls.Add(Me.btnSearch)
        Me.Panel5.Controls.Add(Me.txtPro)
        Me.Panel5.Controls.Add(Me.txtMod)
        Me.Panel5.Controls.Add(Me.Label2)
        Me.Panel5.Controls.Add(Me.Label1)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel5.Location = New System.Drawing.Point(0, 0)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(200, 186)
        Me.Panel5.TabIndex = 0
        '
        'btnDown
        '
        Me.btnDown.BackColor = System.Drawing.Color.Green
        Me.btnDown.BackgroundImage = CType(resources.GetObject("btnDown.BackgroundImage"), System.Drawing.Image)
        Me.btnDown.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnDown.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.btnDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDown.Location = New System.Drawing.Point(86, 20)
        Me.btnDown.Name = "btnDown"
        Me.btnDown.Size = New System.Drawing.Size(31, 23)
        Me.btnDown.TabIndex = 9
        Me.btnDown.UseVisualStyleBackColor = False
        '
        'btnDelete
        '
        Me.btnDelete.BackColor = System.Drawing.Color.Transparent
        Me.btnDelete.BackgroundImage = CType(resources.GetObject("btnDelete.BackgroundImage"), System.Drawing.Image)
        Me.btnDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnDelete.FlatAppearance.BorderSize = 0
        Me.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDelete.Location = New System.Drawing.Point(123, 18)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(49, 26)
        Me.btnDelete.TabIndex = 8
        Me.btnDelete.UseVisualStyleBackColor = False
        '
        'btnEdit
        '
        Me.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEdit.Location = New System.Drawing.Point(15, 20)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(57, 23)
        Me.btnEdit.TabIndex = 8
        Me.btnEdit.Text = "Edit"
        Me.btnEdit.UseVisualStyleBackColor = True
        '
        'btnSearch
        '
        Me.btnSearch.BackColor = System.Drawing.SystemColors.MenuHighlight
        Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSearch.Font = New System.Drawing.Font("맑은 고딕", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.btnSearch.ForeColor = System.Drawing.Color.White
        Me.btnSearch.Location = New System.Drawing.Point(100, 83)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(95, 27)
        Me.btnSearch.TabIndex = 7
        Me.btnSearch.Text = "Search"
        Me.btnSearch.UseVisualStyleBackColor = False
        '
        'txtPro
        '
        Me.txtPro.Location = New System.Drawing.Point(74, 23)
        Me.txtPro.Name = "txtPro"
        Me.txtPro.Size = New System.Drawing.Size(120, 21)
        Me.txtPro.TabIndex = 6
        '
        'txtMod
        '
        Me.txtMod.Location = New System.Drawing.Point(74, 56)
        Me.txtMod.Name = "txtMod"
        Me.txtMod.Size = New System.Drawing.Size(120, 21)
        Me.txtMod.TabIndex = 6
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 29)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 12)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "프로젝트"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 56)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(29, 12)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "모델"
        '
        'Splitter1
        '
        Me.Splitter1.Location = New System.Drawing.Point(200, 0)
        Me.Splitter1.Name = "Splitter1"
        Me.Splitter1.Size = New System.Drawing.Size(3, 562)
        Me.Splitter1.TabIndex = 1
        Me.Splitter1.TabStop = False
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.Panel8)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(203, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(521, 562)
        Me.Panel3.TabIndex = 2
        '
        'Panel8
        '
        Me.Panel8.Controls.Add(Me.Panel10)
        Me.Panel8.Controls.Add(Me.Splitter5)
        Me.Panel8.Controls.Add(Me.Panel9)
        Me.Panel8.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel8.Location = New System.Drawing.Point(0, 0)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(521, 562)
        Me.Panel8.TabIndex = 0
        '
        'Panel10
        '
        Me.Panel10.Controls.Add(Me.Panel12)
        Me.Panel10.Controls.Add(Me.Panel11)
        Me.Panel10.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel10.Location = New System.Drawing.Point(0, 268)
        Me.Panel10.Name = "Panel10"
        Me.Panel10.Size = New System.Drawing.Size(521, 294)
        Me.Panel10.TabIndex = 2
        '
        'Panel12
        '
        Me.Panel12.Controls.Add(Me.Panel14)
        Me.Panel12.Controls.Add(Me.Splitter6)
        Me.Panel12.Controls.Add(Me.Panel13)
        Me.Panel12.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel12.Location = New System.Drawing.Point(0, 37)
        Me.Panel12.Name = "Panel12"
        Me.Panel12.Size = New System.Drawing.Size(521, 257)
        Me.Panel12.TabIndex = 1
        '
        'Panel14
        '
        Me.Panel14.Controls.Add(Me.txtTypeResult)
        Me.Panel14.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel14.Location = New System.Drawing.Point(203, 0)
        Me.Panel14.Name = "Panel14"
        Me.Panel14.Size = New System.Drawing.Size(318, 257)
        Me.Panel14.TabIndex = 2
        '
        'txtTypeResult
        '
        Me.txtTypeResult.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTypeResult.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtTypeResult.Location = New System.Drawing.Point(0, 0)
        Me.txtTypeResult.Multiline = True
        Me.txtTypeResult.Name = "txtTypeResult"
        Me.txtTypeResult.Size = New System.Drawing.Size(318, 257)
        Me.txtTypeResult.TabIndex = 0
        '
        'Splitter6
        '
        Me.Splitter6.Location = New System.Drawing.Point(200, 0)
        Me.Splitter6.Name = "Splitter6"
        Me.Splitter6.Size = New System.Drawing.Size(3, 257)
        Me.Splitter6.TabIndex = 1
        Me.Splitter6.TabStop = False
        '
        'Panel13
        '
        Me.Panel13.Controls.Add(Me.txtChange_result)
        Me.Panel13.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel13.Location = New System.Drawing.Point(0, 0)
        Me.Panel13.Name = "Panel13"
        Me.Panel13.Size = New System.Drawing.Size(200, 257)
        Me.Panel13.TabIndex = 0
        '
        'txtChange_result
        '
        Me.txtChange_result.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtChange_result.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtChange_result.Location = New System.Drawing.Point(0, 0)
        Me.txtChange_result.Multiline = True
        Me.txtChange_result.Name = "txtChange_result"
        Me.txtChange_result.Size = New System.Drawing.Size(200, 257)
        Me.txtChange_result.TabIndex = 0
        '
        'Panel11
        '
        Me.Panel11.Controls.Add(Me.Label7)
        Me.Panel11.Controls.Add(Me.Label6)
        Me.Panel11.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel11.Location = New System.Drawing.Point(0, 0)
        Me.Panel11.Name = "Panel11"
        Me.Panel11.Size = New System.Drawing.Size(521, 37)
        Me.Panel11.TabIndex = 0
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("맑은 고딕", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Gray
        Me.Label7.Location = New System.Drawing.Point(244, 9)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(99, 20)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "검증유형내용"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("맑은 고딕", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Gray
        Me.Label6.Location = New System.Drawing.Point(38, 9)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(119, 20)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "변경점 상세내용"
        '
        'Splitter5
        '
        Me.Splitter5.Dock = System.Windows.Forms.DockStyle.Top
        Me.Splitter5.Location = New System.Drawing.Point(0, 265)
        Me.Splitter5.Name = "Splitter5"
        Me.Splitter5.Size = New System.Drawing.Size(521, 3)
        Me.Splitter5.TabIndex = 1
        Me.Splitter5.TabStop = False
        '
        'Panel9
        '
        Me.Panel9.Controls.Add(Me.Panel16)
        Me.Panel9.Controls.Add(Me.Panel15)
        Me.Panel9.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel9.Location = New System.Drawing.Point(0, 0)
        Me.Panel9.Name = "Panel9"
        Me.Panel9.Size = New System.Drawing.Size(521, 265)
        Me.Panel9.TabIndex = 0
        '
        'Panel16
        '
        Me.Panel16.Controls.Add(Me.Panel18)
        Me.Panel16.Controls.Add(Me.Splitter7)
        Me.Panel16.Controls.Add(Me.Panel17)
        Me.Panel16.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel16.Location = New System.Drawing.Point(0, 41)
        Me.Panel16.Name = "Panel16"
        Me.Panel16.Size = New System.Drawing.Size(521, 224)
        Me.Panel16.TabIndex = 1
        '
        'Panel18
        '
        Me.Panel18.Controls.Add(Me.txtRisk)
        Me.Panel18.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel18.Location = New System.Drawing.Point(203, 0)
        Me.Panel18.Name = "Panel18"
        Me.Panel18.Size = New System.Drawing.Size(318, 224)
        Me.Panel18.TabIndex = 2
        '
        'txtRisk
        '
        Me.txtRisk.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRisk.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtRisk.Location = New System.Drawing.Point(0, 0)
        Me.txtRisk.Multiline = True
        Me.txtRisk.Name = "txtRisk"
        Me.txtRisk.Size = New System.Drawing.Size(318, 224)
        Me.txtRisk.TabIndex = 0
        '
        'Splitter7
        '
        Me.Splitter7.Location = New System.Drawing.Point(200, 0)
        Me.Splitter7.Name = "Splitter7"
        Me.Splitter7.Size = New System.Drawing.Size(3, 224)
        Me.Splitter7.TabIndex = 1
        Me.Splitter7.TabStop = False
        '
        'Panel17
        '
        Me.Panel17.Controls.Add(Me.trvChange)
        Me.Panel17.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel17.Location = New System.Drawing.Point(0, 0)
        Me.Panel17.Name = "Panel17"
        Me.Panel17.Size = New System.Drawing.Size(200, 224)
        Me.Panel17.TabIndex = 0
        '
        'trvChange
        '
        Me.trvChange.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.trvChange.Dock = System.Windows.Forms.DockStyle.Fill
        Me.trvChange.Location = New System.Drawing.Point(0, 0)
        Me.trvChange.Name = "trvChange"
        Me.trvChange.Size = New System.Drawing.Size(200, 224)
        Me.trvChange.TabIndex = 0
        '
        'Panel15
        '
        Me.Panel15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel15.Controls.Add(Me.Label5)
        Me.Panel15.Controls.Add(Me.Label4)
        Me.Panel15.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel15.Location = New System.Drawing.Point(0, 0)
        Me.Panel15.Name = "Panel15"
        Me.Panel15.Size = New System.Drawing.Size(521, 41)
        Me.Panel15.TabIndex = 0
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("맑은 고딕", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Gray
        Me.Label5.Location = New System.Drawing.Point(278, 9)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(38, 20)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Risk"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("맑은 고딕", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Gray
        Me.Label4.Location = New System.Drawing.Point(49, 9)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(89, 20)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "주요 변경점"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Panel3)
        Me.Panel1.Controls.Add(Me.Splitter1)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(724, 562)
        Me.Panel1.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnEdit)
        Me.GroupBox1.Controls.Add(Me.btnDelete)
        Me.GroupBox1.Controls.Add(Me.btnDown)
        Me.GroupBox1.Location = New System.Drawing.Point(14, 116)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(178, 55)
        Me.GroupBox1.TabIndex = 10
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "다운로드/삭제"
        '
        'P_Project_Plan
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(724, 562)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "P_Project_Plan"
        Me.Text = "Project 기획 단계"
        Me.Panel2.ResumeLayout(False)
        Me.Panel6.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel8.ResumeLayout(False)
        Me.Panel10.ResumeLayout(False)
        Me.Panel12.ResumeLayout(False)
        Me.Panel14.ResumeLayout(False)
        Me.Panel14.PerformLayout()
        Me.Panel13.ResumeLayout(False)
        Me.Panel13.PerformLayout()
        Me.Panel11.ResumeLayout(False)
        Me.Panel11.PerformLayout()
        Me.Panel9.ResumeLayout(False)
        Me.Panel16.ResumeLayout(False)
        Me.Panel18.ResumeLayout(False)
        Me.Panel18.PerformLayout()
        Me.Panel17.ResumeLayout(False)
        Me.Panel15.ResumeLayout(False)
        Me.Panel15.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel2 As Windows.Forms.Panel
    Friend WithEvents Panel6 As Windows.Forms.Panel
    Friend WithEvents trvInfo As Windows.Forms.TreeView
    Friend WithEvents Splitter3 As Windows.Forms.Splitter
    Friend WithEvents Panel5 As Windows.Forms.Panel
    Friend WithEvents btnSearch As Windows.Forms.Button
    Friend WithEvents txtPro As Windows.Forms.TextBox
    Friend WithEvents txtMod As Windows.Forms.TextBox
    Friend WithEvents Label2 As Windows.Forms.Label
    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents Splitter1 As Windows.Forms.Splitter
    Friend WithEvents Panel3 As Windows.Forms.Panel
    Friend WithEvents Panel8 As Windows.Forms.Panel
    Friend WithEvents Panel10 As Windows.Forms.Panel
    Friend WithEvents Panel12 As Windows.Forms.Panel
    Friend WithEvents Panel14 As Windows.Forms.Panel
    Friend WithEvents txtTypeResult As Windows.Forms.TextBox
    Friend WithEvents Splitter6 As Windows.Forms.Splitter
    Friend WithEvents Panel13 As Windows.Forms.Panel
    Friend WithEvents txtChange_result As Windows.Forms.TextBox
    Friend WithEvents Panel11 As Windows.Forms.Panel
    Friend WithEvents Label7 As Windows.Forms.Label
    Friend WithEvents Label6 As Windows.Forms.Label
    Friend WithEvents Splitter5 As Windows.Forms.Splitter
    Friend WithEvents Panel9 As Windows.Forms.Panel
    Friend WithEvents Panel16 As Windows.Forms.Panel
    Friend WithEvents Panel18 As Windows.Forms.Panel
    Friend WithEvents txtRisk As Windows.Forms.TextBox
    Friend WithEvents Splitter7 As Windows.Forms.Splitter
    Friend WithEvents Panel17 As Windows.Forms.Panel
    Friend WithEvents trvChange As Windows.Forms.TreeView
    Friend WithEvents Panel15 As Windows.Forms.Panel
    Friend WithEvents Label5 As Windows.Forms.Label
    Friend WithEvents Label4 As Windows.Forms.Label
    Friend WithEvents Panel1 As Windows.Forms.Panel
    Friend WithEvents btnEdit As Windows.Forms.Button
    Friend WithEvents btnDelete As Windows.Forms.Button
    Friend WithEvents btnDown As Windows.Forms.Button
    Friend WithEvents GroupBox1 As Windows.Forms.GroupBox
End Class
