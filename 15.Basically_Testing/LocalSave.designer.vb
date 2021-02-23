<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class LocalSave
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
        Me.lstApp = New System.Windows.Forms.ListBox()
        Me.addApp = New System.Windows.Forms.ListBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lstApp
        '
        Me.lstApp.FormattingEnabled = True
        Me.lstApp.ItemHeight = 12
        Me.lstApp.Location = New System.Drawing.Point(7, 52)
        Me.lstApp.Name = "lstApp"
        Me.lstApp.Size = New System.Drawing.Size(236, 400)
        Me.lstApp.Sorted = True
        Me.lstApp.TabIndex = 0
        '
        'addApp
        '
        Me.addApp.FormattingEnabled = True
        Me.addApp.ItemHeight = 12
        Me.addApp.Location = New System.Drawing.Point(320, 52)
        Me.addApp.Name = "addApp"
        Me.addApp.Size = New System.Drawing.Size(236, 400)
        Me.addApp.Sorted = True
        Me.addApp.TabIndex = 0
        '
        'Button1
        '
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Location = New System.Drawing.Point(260, 159)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(47, 40)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = ">"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Location = New System.Drawing.Point(260, 227)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(47, 40)
        Me.Button2.TabIndex = 1
        Me.Button2.Text = "<"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Malgun Gothic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label1.Location = New System.Drawing.Point(72, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(87, 25)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "APP List"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Malgun Gothic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label2.Location = New System.Drawing.Point(381, 14)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(113, 25)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "선택한 APP"
        '
        'Button3
        '
        Me.Button3.Font = New System.Drawing.Font("Malgun Gothic", 14.25!, System.Drawing.FontStyle.Bold)
        Me.Button3.Location = New System.Drawing.Point(416, 476)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(140, 53)
        Me.Button3.TabIndex = 3
        Me.Button3.Text = "추출하기!"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(922, 49)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowTemplate.Height = 23
        Me.DataGridView1.Size = New System.Drawing.Size(361, 387)
        Me.DataGridView1.TabIndex = 4
        '
        'LocalSave
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(577, 541)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.addApp)
        Me.Controls.Add(Me.lstApp)
        Me.Name = "LocalSave"
        Me.Text = "LocalSave"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lstApp As Windows.Forms.ListBox
    Friend WithEvents addApp As Windows.Forms.ListBox
    Friend WithEvents Button1 As Windows.Forms.Button
    Friend WithEvents Button2 As Windows.Forms.Button
    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents Label2 As Windows.Forms.Label
    Friend WithEvents Button3 As Windows.Forms.Button
    Friend WithEvents DataGridView1 As Windows.Forms.DataGridView
End Class
