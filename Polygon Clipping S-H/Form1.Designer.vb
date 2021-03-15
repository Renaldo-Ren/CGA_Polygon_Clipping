<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.pbCanvas = New System.Windows.Forms.PictureBox()
        Me.btnPoly = New System.Windows.Forms.Button()
        Me.btnRect = New System.Windows.Forms.Button()
        Me.btnDelClip = New System.Windows.Forms.Button()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.btnDelPoly = New System.Windows.Forms.Button()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnLoad = New System.Windows.Forms.Button()
        Me.btnMulti = New System.Windows.Forms.Button()
        Me.btnClearMulti = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.radMulti = New System.Windows.Forms.RadioButton()
        Me.radSingle = New System.Windows.Forms.RadioButton()
        Me.Panel2 = New System.Windows.Forms.Panel()
        CType(Me.pbCanvas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel8.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel7.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'pbCanvas
        '
        Me.pbCanvas.Location = New System.Drawing.Point(327, 14)
        Me.pbCanvas.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.pbCanvas.Name = "pbCanvas"
        Me.pbCanvas.Size = New System.Drawing.Size(837, 540)
        Me.pbCanvas.TabIndex = 0
        Me.pbCanvas.TabStop = False
        '
        'btnPoly
        '
        Me.btnPoly.Location = New System.Drawing.Point(327, 80)
        Me.btnPoly.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnPoly.Name = "btnPoly"
        Me.btnPoly.Size = New System.Drawing.Size(167, 62)
        Me.btnPoly.TabIndex = 1
        Me.btnPoly.Text = "Single Polygon"
        Me.btnPoly.UseVisualStyleBackColor = True
        Me.btnPoly.Visible = False
        '
        'btnRect
        '
        Me.btnRect.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(166, Byte), Integer), CType(CType(158, Byte), Integer))
        Me.btnRect.FlatAppearance.BorderSize = 0
        Me.btnRect.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRect.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnRect.Location = New System.Drawing.Point(7, 31)
        Me.btnRect.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnRect.Name = "btnRect"
        Me.btnRect.Size = New System.Drawing.Size(293, 62)
        Me.btnRect.TabIndex = 1
        Me.btnRect.Text = "Clip Window"
        Me.btnRect.UseVisualStyleBackColor = False
        '
        'btnDelClip
        '
        Me.btnDelClip.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(166, Byte), Integer), CType(CType(158, Byte), Integer))
        Me.btnDelClip.FlatAppearance.BorderSize = 0
        Me.btnDelClip.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDelClip.Location = New System.Drawing.Point(7, 66)
        Me.btnDelClip.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnDelClip.Name = "btnDelClip"
        Me.btnDelClip.Size = New System.Drawing.Size(140, 55)
        Me.btnDelClip.TabIndex = 2
        Me.btnDelClip.Text = "Delete Clip Window"
        Me.btnDelClip.UseVisualStyleBackColor = False
        '
        'btnClear
        '
        Me.btnClear.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(166, Byte), Integer), CType(CType(158, Byte), Integer))
        Me.btnClear.FlatAppearance.BorderSize = 0
        Me.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClear.Location = New System.Drawing.Point(7, 6)
        Me.btnClear.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(293, 62)
        Me.btnClear.TabIndex = 3
        Me.btnClear.Text = "Clear Screen"
        Me.btnClear.UseVisualStyleBackColor = False
        '
        'btnDelPoly
        '
        Me.btnDelPoly.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(166, Byte), Integer), CType(CType(158, Byte), Integer))
        Me.btnDelPoly.FlatAppearance.BorderSize = 0
        Me.btnDelPoly.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDelPoly.Location = New System.Drawing.Point(7, 6)
        Me.btnDelPoly.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnDelPoly.Name = "btnDelPoly"
        Me.btnDelPoly.Size = New System.Drawing.Size(140, 55)
        Me.btnDelPoly.TabIndex = 4
        Me.btnDelPoly.Text = "Delete Polygon"
        Me.btnDelPoly.UseVisualStyleBackColor = False
        '
        'btnRefresh
        '
        Me.btnRefresh.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(166, Byte), Integer), CType(CType(158, Byte), Integer))
        Me.btnRefresh.FlatAppearance.BorderSize = 0
        Me.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRefresh.Location = New System.Drawing.Point(7, 66)
        Me.btnRefresh.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(140, 55)
        Me.btnRefresh.TabIndex = 5
        Me.btnRefresh.Text = "Refresh"
        Me.btnRefresh.UseVisualStyleBackColor = False
        '
        'btnSave
        '
        Me.btnSave.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(166, Byte), Integer), CType(CType(158, Byte), Integer))
        Me.btnSave.FlatAppearance.BorderSize = 0
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSave.Location = New System.Drawing.Point(7, 33)
        Me.btnSave.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(140, 55)
        Me.btnSave.TabIndex = 6
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'btnLoad
        '
        Me.btnLoad.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(166, Byte), Integer), CType(CType(158, Byte), Integer))
        Me.btnLoad.FlatAppearance.BorderSize = 0
        Me.btnLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLoad.Location = New System.Drawing.Point(160, 33)
        Me.btnLoad.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnLoad.Name = "btnLoad"
        Me.btnLoad.Size = New System.Drawing.Size(140, 55)
        Me.btnLoad.TabIndex = 7
        Me.btnLoad.Text = "Load"
        Me.btnLoad.UseVisualStyleBackColor = False
        '
        'btnMulti
        '
        Me.btnMulti.Location = New System.Drawing.Point(327, 14)
        Me.btnMulti.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnMulti.Name = "btnMulti"
        Me.btnMulti.Size = New System.Drawing.Size(167, 62)
        Me.btnMulti.TabIndex = 8
        Me.btnMulti.Text = "Multi Polyon"
        Me.btnMulti.UseVisualStyleBackColor = True
        Me.btnMulti.Visible = False
        '
        'btnClearMulti
        '
        Me.btnClearMulti.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(166, Byte), Integer), CType(CType(158, Byte), Integer))
        Me.btnClearMulti.FlatAppearance.BorderSize = 0
        Me.btnClearMulti.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClearMulti.Location = New System.Drawing.Point(7, 6)
        Me.btnClearMulti.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnClearMulti.Name = "btnClearMulti"
        Me.btnClearMulti.Size = New System.Drawing.Size(140, 55)
        Me.btnClearMulti.TabIndex = 9
        Me.btnClearMulti.Text = "Delete Multi"
        Me.btnClearMulti.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Panel8)
        Me.Panel1.Controls.Add(Me.Panel5)
        Me.Panel1.Controls.Add(Me.Panel4)
        Me.Panel1.Controls.Add(Me.Panel3)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(307, 567)
        Me.Panel1.TabIndex = 11
        '
        'Panel8
        '
        Me.Panel8.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(107, Byte), Integer))
        Me.Panel8.Controls.Add(Me.Label1)
        Me.Panel8.Controls.Add(Me.btnSave)
        Me.Panel8.Controls.Add(Me.btnLoad)
        Me.Panel8.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel8.Location = New System.Drawing.Point(0, 465)
        Me.Panel8.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(307, 102)
        Me.Panel8.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label1.Location = New System.Drawing.Point(99, 4)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(104, 17)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Save and Load"
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(107, Byte), Integer))
        Me.Panel5.Controls.Add(Me.btnClear)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel5.Location = New System.Drawing.Point(0, 391)
        Me.Panel5.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(307, 74)
        Me.Panel5.TabIndex = 3
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.Panel7)
        Me.Panel4.Controls.Add(Me.Panel6)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(0, 264)
        Me.Panel4.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(307, 127)
        Me.Panel4.TabIndex = 3
        '
        'Panel7
        '
        Me.Panel7.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(107, Byte), Integer))
        Me.Panel7.Controls.Add(Me.btnDelClip)
        Me.Panel7.Controls.Add(Me.btnClearMulti)
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel7.Location = New System.Drawing.Point(153, 0)
        Me.Panel7.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(153, 127)
        Me.Panel7.TabIndex = 0
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(107, Byte), Integer))
        Me.Panel6.Controls.Add(Me.btnDelPoly)
        Me.Panel6.Controls.Add(Me.btnRefresh)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel6.Location = New System.Drawing.Point(0, 0)
        Me.Panel6.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(153, 127)
        Me.Panel6.TabIndex = 0
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(107, Byte), Integer))
        Me.Panel3.Controls.Add(Me.btnRect)
        Me.Panel3.Controls.Add(Me.radMulti)
        Me.Panel3.Controls.Add(Me.radSingle)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 167)
        Me.Panel3.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(307, 97)
        Me.Panel3.TabIndex = 2
        '
        'radMulti
        '
        Me.radMulti.AutoSize = True
        Me.radMulti.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.radMulti.Location = New System.Drawing.Point(173, 7)
        Me.radMulti.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.radMulti.Name = "radMulti"
        Me.radMulti.Size = New System.Drawing.Size(113, 21)
        Me.radMulti.TabIndex = 1
        Me.radMulti.TabStop = True
        Me.radMulti.Text = "Multi Polygon"
        Me.radMulti.UseVisualStyleBackColor = True
        '
        'radSingle
        '
        Me.radSingle.AutoSize = True
        Me.radSingle.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.radSingle.Location = New System.Drawing.Point(16, 7)
        Me.radSingle.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.radSingle.Name = "radSingle"
        Me.radSingle.Size = New System.Drawing.Size(123, 21)
        Me.radSingle.TabIndex = 1
        Me.radSingle.TabStop = True
        Me.radSingle.Text = "Single Polygon"
        Me.radSingle.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(107, Byte), Integer))
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(307, 167)
        Me.Panel2.TabIndex = 0
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(107, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1179, 567)
        Me.Controls.Add(Me.btnPoly)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.btnMulti)
        Me.Controls.Add(Me.pbCanvas)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "Form1"
        Me.Text = "Sutherland-Hodgman Clipping by FJR"
        CType(Me.pbCanvas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel8.ResumeLayout(False)
        Me.Panel8.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel7.ResumeLayout(False)
        Me.Panel6.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pbCanvas As PictureBox
    Friend WithEvents btnPoly As Button
    Friend WithEvents btnRect As Button
    Friend WithEvents btnDelClip As Button
    Friend WithEvents btnClear As Button
    Friend WithEvents btnDelPoly As Button
    Friend WithEvents btnRefresh As Button
    Friend WithEvents btnSave As Button
    Friend WithEvents btnLoad As Button
    Friend WithEvents btnMulti As Button
    Friend WithEvents btnClearMulti As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents radMulti As RadioButton
    Friend WithEvents radSingle As RadioButton
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel8 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Panel7 As Panel
    Friend WithEvents Panel6 As Panel
End Class
