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
        Me.components = New System.ComponentModel.Container()
        Me.pbCanvas = New System.Windows.Forms.PictureBox()
        Me.btnRect = New System.Windows.Forms.Button()
        Me.btnDelClip = New System.Windows.Forms.Button()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.btnDelPoly = New System.Windows.Forms.Button()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnLoad = New System.Windows.Forms.Button()
        Me.btnClearMulti = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.radMulti = New System.Windows.Forms.RadioButton()
        Me.radSingle = New System.Windows.Forms.RadioButton()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.FJR = New System.Windows.Forms.Label()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        CType(Me.pbCanvas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'pbCanvas
        '
        Me.pbCanvas.Location = New System.Drawing.Point(298, 11)
        Me.pbCanvas.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.pbCanvas.Name = "pbCanvas"
        Me.pbCanvas.Size = New System.Drawing.Size(575, 439)
        Me.pbCanvas.TabIndex = 0
        Me.pbCanvas.TabStop = False
        '
        'btnRect
        '
        Me.btnRect.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(44, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.btnRect.FlatAppearance.BorderSize = 0
        Me.btnRect.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRect.Font = New System.Drawing.Font("Helvetica", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRect.ForeColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.btnRect.Location = New System.Drawing.Point(26, 27)
        Me.btnRect.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.btnRect.Name = "btnRect"
        Me.btnRect.Size = New System.Drawing.Size(223, 50)
        Me.btnRect.TabIndex = 1
        Me.btnRect.Text = "Clipping Window"
        Me.ToolTip1.SetToolTip(Me.btnRect, "Click this to start drawing the clipping window")
        Me.btnRect.UseVisualStyleBackColor = False
        '
        'btnDelClip
        '
        Me.btnDelClip.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(44, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.btnDelClip.FlatAppearance.BorderSize = 0
        Me.btnDelClip.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDelClip.Font = New System.Drawing.Font("Helvetica", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelClip.ForeColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.btnDelClip.Location = New System.Drawing.Point(144, 56)
        Me.btnDelClip.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.btnDelClip.Name = "btnDelClip"
        Me.btnDelClip.Size = New System.Drawing.Size(105, 45)
        Me.btnDelClip.TabIndex = 2
        Me.btnDelClip.Text = "Delete Clipping Window"
        Me.ToolTip1.SetToolTip(Me.btnDelClip, "Click this to remove the clipping window")
        Me.btnDelClip.UseVisualStyleBackColor = False
        '
        'btnClear
        '
        Me.btnClear.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(44, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.btnClear.FlatAppearance.BorderSize = 0
        Me.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClear.Font = New System.Drawing.Font("Helvetica", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClear.ForeColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.btnClear.Location = New System.Drawing.Point(26, 296)
        Me.btnClear.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(223, 50)
        Me.btnClear.TabIndex = 3
        Me.btnClear.Text = "Clear Screen"
        Me.ToolTip1.SetToolTip(Me.btnClear, "Click this to reset the canvas")
        Me.btnClear.UseVisualStyleBackColor = False
        '
        'btnDelPoly
        '
        Me.btnDelPoly.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(44, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.btnDelPoly.FlatAppearance.BorderSize = 0
        Me.btnDelPoly.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDelPoly.Font = New System.Drawing.Font("Helvetica", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelPoly.ForeColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.btnDelPoly.Location = New System.Drawing.Point(26, 5)
        Me.btnDelPoly.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.btnDelPoly.Name = "btnDelPoly"
        Me.btnDelPoly.Size = New System.Drawing.Size(105, 45)
        Me.btnDelPoly.TabIndex = 4
        Me.btnDelPoly.Text = "Delete Single Polygon"
        Me.ToolTip1.SetToolTip(Me.btnDelPoly, "Click this to remove the single polygon lines outside the clipping window")
        Me.btnDelPoly.UseVisualStyleBackColor = False
        '
        'btnRefresh
        '
        Me.btnRefresh.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(44, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.btnRefresh.FlatAppearance.BorderSize = 0
        Me.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRefresh.Font = New System.Drawing.Font("Helvetica", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRefresh.ForeColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.btnRefresh.Location = New System.Drawing.Point(26, 56)
        Me.btnRefresh.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(105, 45)
        Me.btnRefresh.TabIndex = 5
        Me.btnRefresh.Text = "Refresh"
        Me.ToolTip1.SetToolTip(Me.btnRefresh, "Click this to remove the clipping window and the clipped polygon(s)")
        Me.btnRefresh.UseVisualStyleBackColor = False
        '
        'btnSave
        '
        Me.btnSave.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(44, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.btnSave.FlatAppearance.BorderSize = 0
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSave.Font = New System.Drawing.Font("Helvetica", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.ForeColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.btnSave.Location = New System.Drawing.Point(26, 401)
        Me.btnSave.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(105, 45)
        Me.btnSave.TabIndex = 6
        Me.btnSave.Text = "Save"
        Me.ToolTip1.SetToolTip(Me.btnSave, "Click this to save the canvas")
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'btnLoad
        '
        Me.btnLoad.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(44, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.btnLoad.FlatAppearance.BorderSize = 0
        Me.btnLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLoad.Font = New System.Drawing.Font("Helvetica", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLoad.ForeColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.btnLoad.Location = New System.Drawing.Point(144, 401)
        Me.btnLoad.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.btnLoad.Name = "btnLoad"
        Me.btnLoad.Size = New System.Drawing.Size(105, 45)
        Me.btnLoad.TabIndex = 7
        Me.btnLoad.Text = "Load"
        Me.ToolTip1.SetToolTip(Me.btnLoad, "Click this to load existing picture")
        Me.btnLoad.UseVisualStyleBackColor = False
        '
        'btnClearMulti
        '
        Me.btnClearMulti.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(44, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.btnClearMulti.FlatAppearance.BorderSize = 0
        Me.btnClearMulti.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClearMulti.Font = New System.Drawing.Font("Helvetica", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClearMulti.ForeColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.btnClearMulti.Location = New System.Drawing.Point(144, 5)
        Me.btnClearMulti.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.btnClearMulti.Name = "btnClearMulti"
        Me.btnClearMulti.Size = New System.Drawing.Size(105, 45)
        Me.btnClearMulti.TabIndex = 9
        Me.btnClearMulti.Text = "Delete Multi Polygon"
        Me.ToolTip1.SetToolTip(Me.btnClearMulti, "Click this to remove the multiple polygon(s) lines outside the clipping window")
        Me.btnClearMulti.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.btnClear)
        Me.Panel1.Controls.Add(Me.Panel4)
        Me.Panel1.Controls.Add(Me.btnSave)
        Me.Panel1.Controls.Add(Me.btnLoad)
        Me.Panel1.Controls.Add(Me.Panel3)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(270, 461)
        Me.Panel1.TabIndex = 11
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Helvetica", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(44, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(92, 372)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(87, 14)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Save and Load"
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.btnDelPoly)
        Me.Panel4.Controls.Add(Me.btnRefresh)
        Me.Panel4.Controls.Add(Me.btnDelClip)
        Me.Panel4.Controls.Add(Me.btnClearMulti)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(0, 188)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(270, 103)
        Me.Panel4.TabIndex = 3
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.Panel3.Controls.Add(Me.btnRect)
        Me.Panel3.Controls.Add(Me.radMulti)
        Me.Panel3.Controls.Add(Me.radSingle)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 109)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(270, 79)
        Me.Panel3.TabIndex = 2
        '
        'radMulti
        '
        Me.radMulti.AutoSize = True
        Me.radMulti.Font = New System.Drawing.Font("Helvetica", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.radMulti.ForeColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(44, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.radMulti.Location = New System.Drawing.Point(158, 6)
        Me.radMulti.Name = "radMulti"
        Me.radMulti.Size = New System.Drawing.Size(99, 18)
        Me.radMulti.TabIndex = 1
        Me.radMulti.TabStop = True
        Me.radMulti.Text = "Multi Polygon"
        Me.ToolTip1.SetToolTip(Me.radMulti, "Click this to start drawing multiple polygon")
        Me.radMulti.UseVisualStyleBackColor = True
        '
        'radSingle
        '
        Me.radSingle.AutoSize = True
        Me.radSingle.Font = New System.Drawing.Font("Helvetica", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.radSingle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(44, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.radSingle.Location = New System.Drawing.Point(26, 6)
        Me.radSingle.Name = "radSingle"
        Me.radSingle.Size = New System.Drawing.Size(107, 18)
        Me.radSingle.TabIndex = 1
        Me.radSingle.TabStop = True
        Me.radSingle.Text = "Single Polygon"
        Me.ToolTip1.SetToolTip(Me.radSingle, "Click this to start drawing single polygon")
        Me.radSingle.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.FJR)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(270, 109)
        Me.Panel2.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Helvetica", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(44, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(101, 69)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(51, 15)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "By FJR"
        '
        'FJR
        '
        Me.FJR.AutoSize = True
        Me.FJR.Font = New System.Drawing.Font("Pacifico", 26.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FJR.ForeColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(44, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.FJR.Location = New System.Drawing.Point(37, 11)
        Me.FJR.Name = "FJR"
        Me.FJR.Size = New System.Drawing.Size(209, 65)
        Me.FJR.TabIndex = 0
        Me.FJR.Text = "SH-Clipper"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(884, 461)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.pbCanvas)
        Me.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Name = "Form1"
        Me.Text = "Sutherland-Hodgman Clipping by FJR"
        CType(Me.pbCanvas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pbCanvas As PictureBox
    Friend WithEvents btnRect As Button
    Friend WithEvents btnDelClip As Button
    Friend WithEvents btnClear As Button
    Friend WithEvents btnDelPoly As Button
    Friend WithEvents btnRefresh As Button
    Friend WithEvents btnSave As Button
    Friend WithEvents btnLoad As Button
    Friend WithEvents btnClearMulti As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents radMulti As RadioButton
    Friend WithEvents radSingle As RadioButton
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel4 As Panel
    Friend WithEvents FJR As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents ToolTip1 As ToolTip
End Class
