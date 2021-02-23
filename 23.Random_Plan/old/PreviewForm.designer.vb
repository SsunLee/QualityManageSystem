Imports System.Windows.Forms

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class PreviewForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)

        '지금까지의 미리보기를 닫을 것인지 정해주는 구문
        If MessageBox.Show("지금까지 저장된 미리보기 값이 다 없어집니다. 그래도 닫으시겠습니까?", "Title", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            Try
                If disposing AndAlso components IsNot Nothing Then
                    components.Dispose()
                End If
            Finally
                MyBase.Dispose(disposing)
            End Try
        End If
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PreviewForm))
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.btnLoad = New System.Windows.Forms.Button()
        Me.btnLocal = New System.Windows.Forms.Button()
        Me.btnServer = New System.Windows.Forms.Button()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.chkView = New System.Windows.Forms.CheckBox()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView1.BackgroundColor = System.Drawing.Color.LightGray
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(12, 58)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowTemplate.Height = 23
        Me.DataGridView1.Size = New System.Drawing.Size(1198, 605)
        Me.DataGridView1.TabIndex = 0
        '
        'PictureBox2
        '
        Me.PictureBox2.BackgroundImage = CType(resources.GetObject("PictureBox2.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox2.Location = New System.Drawing.Point(12, 12)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(216, 25)
        Me.PictureBox2.TabIndex = 64
        Me.PictureBox2.TabStop = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Malgun Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.DimGray
        Me.Label8.Location = New System.Drawing.Point(234, 12)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(150, 20)
        Me.Label8.TabIndex = 63
        Me.Label8.Text = "검증계획서_미리보기"
        '
        'btnClear
        '
        Me.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClear.Font = New System.Drawing.Font("Malgun Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.btnClear.ForeColor = System.Drawing.Color.Gray
        Me.btnClear.Location = New System.Drawing.Point(416, 12)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(89, 25)
        Me.btnClear.TabIndex = 155
        Me.btnClear.Text = "Clear"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'btnLoad
        '
        Me.btnLoad.BackColor = System.Drawing.Color.Transparent
        Me.btnLoad.BackgroundImage = CType(resources.GetObject("btnLoad.BackgroundImage"), System.Drawing.Image)
        Me.btnLoad.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnLoad.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLoad.Font = New System.Drawing.Font("Malgun Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.btnLoad.ForeColor = System.Drawing.Color.White
        Me.btnLoad.Location = New System.Drawing.Point(1010, 8)
        Me.btnLoad.Name = "btnLoad"
        Me.btnLoad.Size = New System.Drawing.Size(52, 32)
        Me.btnLoad.TabIndex = 194
        Me.btnLoad.UseVisualStyleBackColor = False
        Me.btnLoad.Visible = False
        '
        'btnLocal
        '
        Me.btnLocal.BackColor = System.Drawing.Color.Transparent
        Me.btnLocal.BackgroundImage = CType(resources.GetObject("btnLocal.BackgroundImage"), System.Drawing.Image)
        Me.btnLocal.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnLocal.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnLocal.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLocal.Font = New System.Drawing.Font("Malgun Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.btnLocal.ForeColor = System.Drawing.Color.White
        Me.btnLocal.Location = New System.Drawing.Point(851, 9)
        Me.btnLocal.Name = "btnLocal"
        Me.btnLocal.Size = New System.Drawing.Size(52, 32)
        Me.btnLocal.TabIndex = 193
        Me.btnLocal.UseVisualStyleBackColor = False
        Me.btnLocal.Visible = False
        '
        'btnServer
        '
        Me.btnServer.BackColor = System.Drawing.Color.Transparent
        Me.btnServer.BackgroundImage = CType(resources.GetObject("btnServer.BackgroundImage"), System.Drawing.Image)
        Me.btnServer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnServer.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnServer.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnServer.Font = New System.Drawing.Font("Malgun Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.btnServer.ForeColor = System.Drawing.Color.White
        Me.btnServer.Location = New System.Drawing.Point(682, 9)
        Me.btnServer.Name = "btnServer"
        Me.btnServer.Size = New System.Drawing.Size(52, 32)
        Me.btnServer.TabIndex = 192
        Me.btnServer.UseVisualStyleBackColor = False
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label13.ForeColor = System.Drawing.Color.Gray
        Me.Label13.Location = New System.Drawing.Point(1068, 19)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(107, 15)
        Me.Label13.TabIndex = 191
        Me.Label13.Text = "백업내용 가져오기"
        Me.Label13.Visible = False
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Malgun Gothic", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label12.ForeColor = System.Drawing.Color.Gray
        Me.Label12.Location = New System.Drawing.Point(900, 16)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(84, 19)
        Me.Label12.TabIndex = 189
        Me.Label12.Text = "로컬에 백업"
        Me.Label12.Visible = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Malgun Gothic", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label11.ForeColor = System.Drawing.Color.Gray
        Me.Label11.Location = New System.Drawing.Point(731, 16)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(84, 19)
        Me.Label11.TabIndex = 190
        Me.Label11.Text = "서버에 저장"
        '
        'chkView
        '
        Me.chkView.AutoSize = True
        Me.chkView.Font = New System.Drawing.Font("Malgun Gothic", 9.75!, System.Drawing.FontStyle.Bold)
        Me.chkView.ForeColor = System.Drawing.Color.DimGray
        Me.chkView.Location = New System.Drawing.Point(556, 16)
        Me.chkView.Name = "chkView"
        Me.chkView.Size = New System.Drawing.Size(105, 21)
        Me.chkView.TabIndex = 195
        Me.chkView.Text = "내용수정모드"
        Me.chkView.UseVisualStyleBackColor = True
        Me.chkView.Visible = False
        '
        'PreviewForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1222, 675)
        Me.Controls.Add(Me.chkView)
        Me.Controls.Add(Me.btnLoad)
        Me.Controls.Add(Me.btnLocal)
        Me.Controls.Add(Me.btnServer)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.DataGridView1)
        Me.Name = "PreviewForm"
        Me.Text = "Preview"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PictureBox2 As Windows.Forms.PictureBox
    Friend WithEvents Label8 As Windows.Forms.Label
    Friend WithEvents btnClear As Windows.Forms.Button
    Public WithEvents DataGridView1 As Windows.Forms.DataGridView
    Friend WithEvents btnLoad As Button
    Friend WithEvents btnLocal As Button
    Friend WithEvents btnServer As Button
    Friend WithEvents Label13 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents chkView As CheckBox
End Class
