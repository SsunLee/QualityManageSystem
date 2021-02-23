<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ModifyInfo
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
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.btn_Modify = New System.Windows.Forms.Button()
        Me.btn_Delete = New System.Windows.Forms.Button()
        Me.col_check = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.col_check})
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Left
        Me.DataGridView1.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowTemplate.Height = 23
        Me.DataGridView1.Size = New System.Drawing.Size(613, 448)
        Me.DataGridView1.TabIndex = 0
        '
        'btn_Modify
        '
        Me.btn_Modify.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Modify.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.btn_Modify.Location = New System.Drawing.Point(642, 26)
        Me.btn_Modify.Name = "btn_Modify"
        Me.btn_Modify.Size = New System.Drawing.Size(111, 32)
        Me.btn_Modify.TabIndex = 1
        Me.btn_Modify.Text = "수정"
        Me.btn_Modify.UseVisualStyleBackColor = True
        '
        'btn_Delete
        '
        Me.btn_Delete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Delete.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.btn_Delete.Location = New System.Drawing.Point(642, 74)
        Me.btn_Delete.Name = "btn_Delete"
        Me.btn_Delete.Size = New System.Drawing.Size(111, 32)
        Me.btn_Delete.TabIndex = 1
        Me.btn_Delete.Text = "삭제"
        Me.btn_Delete.UseVisualStyleBackColor = True
        '
        'col_check
        '
        Me.col_check.HeaderText = "Check"
        Me.col_check.Name = "col_check"
        '
        'ModifyInfo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(765, 448)
        Me.Controls.Add(Me.btn_Delete)
        Me.Controls.Add(Me.btn_Modify)
        Me.Controls.Add(Me.DataGridView1)
        Me.Name = "ModifyInfo"
        Me.Text = "ModifyInfo"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents DataGridView1 As Windows.Forms.DataGridView
    Friend WithEvents btn_Modify As Windows.Forms.Button
    Friend WithEvents btn_Delete As Windows.Forms.Button
    Friend WithEvents col_check As Windows.Forms.DataGridViewCheckBoxColumn
End Class
