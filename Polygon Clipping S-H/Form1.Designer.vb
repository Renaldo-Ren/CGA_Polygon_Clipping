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
        CType(Me.pbCanvas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pbCanvas
        '
        Me.pbCanvas.Location = New System.Drawing.Point(12, 12)
        Me.pbCanvas.Name = "pbCanvas"
        Me.pbCanvas.Size = New System.Drawing.Size(809, 469)
        Me.pbCanvas.TabIndex = 0
        Me.pbCanvas.TabStop = False
        '
        'btnPoly
        '
        Me.btnPoly.Location = New System.Drawing.Point(902, 70)
        Me.btnPoly.Name = "btnPoly"
        Me.btnPoly.Size = New System.Drawing.Size(188, 60)
        Me.btnPoly.TabIndex = 1
        Me.btnPoly.Text = "Polygon"
        Me.btnPoly.UseVisualStyleBackColor = True
        '
        'btnRect
        '
        Me.btnRect.Location = New System.Drawing.Point(902, 160)
        Me.btnRect.Name = "btnRect"
        Me.btnRect.Size = New System.Drawing.Size(188, 60)
        Me.btnRect.TabIndex = 1
        Me.btnRect.Text = "Rectangle"
        Me.btnRect.UseVisualStyleBackColor = True
        '
        'btnDelClip
        '
        Me.btnDelClip.Location = New System.Drawing.Point(904, 250)
        Me.btnDelClip.Name = "btnDelClip"
        Me.btnDelClip.Size = New System.Drawing.Size(185, 56)
        Me.btnDelClip.TabIndex = 2
        Me.btnDelClip.Text = "Delete Clip Window"
        Me.btnDelClip.UseVisualStyleBackColor = True
        '
        'btnClear
        '
        Me.btnClear.Location = New System.Drawing.Point(905, 425)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(185, 56)
        Me.btnClear.TabIndex = 3
        Me.btnClear.Text = "Clear Screen"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'btnDelPoly
        '
        Me.btnDelPoly.Location = New System.Drawing.Point(904, 338)
        Me.btnDelPoly.Name = "btnDelPoly"
        Me.btnDelPoly.Size = New System.Drawing.Size(185, 56)
        Me.btnDelPoly.TabIndex = 4
        Me.btnDelPoly.Text = "Delete Polygon"
        Me.btnDelPoly.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1173, 571)
        Me.Controls.Add(Me.btnDelPoly)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.btnDelClip)
        Me.Controls.Add(Me.btnRect)
        Me.Controls.Add(Me.btnPoly)
        Me.Controls.Add(Me.pbCanvas)
        Me.Name = "Form1"
        Me.Text = "Form1"
        CType(Me.pbCanvas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pbCanvas As PictureBox
    Friend WithEvents btnPoly As Button
    Friend WithEvents btnRect As Button
    Friend WithEvents btnDelClip As Button
    Friend WithEvents btnClear As Button
    Friend WithEvents btnDelPoly As Button
End Class
