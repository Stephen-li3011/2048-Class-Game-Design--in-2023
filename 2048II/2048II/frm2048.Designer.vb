<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frm2048
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
        Me.rollbackCount = New System.Windows.Forms.Label()
        Me.RestartKey = New System.Windows.Forms.Button()
        Me.KeyDown = New System.Windows.Forms.Button()
        Me.KeyRight = New System.Windows.Forms.Button()
        Me.KeyUp = New System.Windows.Forms.Button()
        Me.KeyLeft = New System.Windows.Forms.Button()
        Me.highScore = New System.Windows.Forms.Label()
        Me.Score = New System.Windows.Forms.Label()
        Me.GamePanel = New System.Windows.Forms.TableLayoutPanel()
        Me.RollbackKey = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'rollbackCount
        '
        Me.rollbackCount.Font = New System.Drawing.Font("Times New Roman", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rollbackCount.Location = New System.Drawing.Point(1062, 322)
        Me.rollbackCount.Name = "rollbackCount"
        Me.rollbackCount.Size = New System.Drawing.Size(379, 50)
        Me.rollbackCount.TabIndex = 16
        '
        'RestartKey
        '
        Me.RestartKey.BackColor = System.Drawing.SystemColors.ControlLight
        Me.RestartKey.Font = New System.Drawing.Font("Times New Roman", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RestartKey.Location = New System.Drawing.Point(1021, 797)
        Me.RestartKey.Name = "RestartKey"
        Me.RestartKey.Size = New System.Drawing.Size(183, 125)
        Me.RestartKey.TabIndex = 15
        Me.RestartKey.Text = "Restart"
        Me.RestartKey.UseVisualStyleBackColor = False
        '
        'KeyDown
        '
        Me.KeyDown.Location = New System.Drawing.Point(1139, 622)
        Me.KeyDown.Name = "KeyDown"
        Me.KeyDown.Size = New System.Drawing.Size(100, 100)
        Me.KeyDown.TabIndex = 14
        Me.KeyDown.Text = "DOWN"
        Me.KeyDown.UseVisualStyleBackColor = True
        '
        'KeyRight
        '
        Me.KeyRight.Location = New System.Drawing.Point(1258, 622)
        Me.KeyRight.Name = "KeyRight"
        Me.KeyRight.Size = New System.Drawing.Size(100, 100)
        Me.KeyRight.TabIndex = 13
        Me.KeyRight.Text = "RIGHT"
        Me.KeyRight.UseVisualStyleBackColor = True
        '
        'KeyUp
        '
        Me.KeyUp.Location = New System.Drawing.Point(1139, 504)
        Me.KeyUp.Name = "KeyUp"
        Me.KeyUp.Size = New System.Drawing.Size(100, 100)
        Me.KeyUp.TabIndex = 12
        Me.KeyUp.Text = "UP"
        Me.KeyUp.UseVisualStyleBackColor = True
        '
        'KeyLeft
        '
        Me.KeyLeft.Location = New System.Drawing.Point(1021, 622)
        Me.KeyLeft.Name = "KeyLeft"
        Me.KeyLeft.Size = New System.Drawing.Size(100, 100)
        Me.KeyLeft.TabIndex = 11
        Me.KeyLeft.Text = "LEFT"
        Me.KeyLeft.UseVisualStyleBackColor = True
        '
        'highScore
        '
        Me.highScore.Font = New System.Drawing.Font("Times New Roman", 15.85714!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.highScore.Location = New System.Drawing.Point(1062, 222)
        Me.highScore.Name = "highScore"
        Me.highScore.Size = New System.Drawing.Size(379, 50)
        Me.highScore.TabIndex = 10
        '
        'Score
        '
        Me.Score.Font = New System.Drawing.Font("Times New Roman", 15.85714!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Score.Location = New System.Drawing.Point(1062, 122)
        Me.Score.Name = "Score"
        Me.Score.Size = New System.Drawing.Size(379, 50)
        Me.Score.TabIndex = 8
        '
        'GamePanel
        '
        Me.GamePanel.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.GamePanel.ColumnCount = 4
        Me.GamePanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.GamePanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.GamePanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.GamePanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.GamePanel.Location = New System.Drawing.Point(162, 122)
        Me.GamePanel.Name = "GamePanel"
        Me.GamePanel.RowCount = 4
        Me.GamePanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.GamePanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.GamePanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.GamePanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.GamePanel.Size = New System.Drawing.Size(800, 800)
        Me.GamePanel.TabIndex = 9
        '
        'RollbackKey
        '
        Me.RollbackKey.BackColor = System.Drawing.SystemColors.ControlLight
        Me.RollbackKey.Font = New System.Drawing.Font("Times New Roman", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RollbackKey.Location = New System.Drawing.Point(1242, 802)
        Me.RollbackKey.Name = "RollbackKey"
        Me.RollbackKey.Size = New System.Drawing.Size(216, 120)
        Me.RollbackKey.TabIndex = 17
        Me.RollbackKey.Text = "Rollback"
        Me.RollbackKey.UseVisualStyleBackColor = False
        '
        'frm2048
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(11.0!, 21.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1776, 1236)
        Me.Controls.Add(Me.RollbackKey)
        Me.Controls.Add(Me.rollbackCount)
        Me.Controls.Add(Me.RestartKey)
        Me.Controls.Add(Me.KeyDown)
        Me.Controls.Add(Me.KeyRight)
        Me.Controls.Add(Me.KeyUp)
        Me.Controls.Add(Me.KeyLeft)
        Me.Controls.Add(Me.highScore)
        Me.Controls.Add(Me.Score)
        Me.Controls.Add(Me.GamePanel)
        Me.KeyPreview = True
        Me.Name = "frm2048"
        Me.Text = "frm2048"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents rollbackCount As Label
    Friend WithEvents RestartKey As Button
    Friend WithEvents KeyDown As Button
    Friend WithEvents KeyRight As Button
    Friend WithEvents KeyUp As Button
    Friend WithEvents KeyLeft As Button
    Friend WithEvents highScore As Label
    Friend WithEvents Score As Label
    Friend WithEvents GamePanel As TableLayoutPanel
    Friend WithEvents RollbackKey As Button
End Class
