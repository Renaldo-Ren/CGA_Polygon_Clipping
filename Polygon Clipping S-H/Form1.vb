Public Class Form1
    Dim ClipRect As Rectangle = New Rectangle()
    Dim _pen As Pen = New Pen(Color.Black, 3)
    Dim shape As String
    ' Each polygon is represented by a List(Of Point).
    Private Polygons As List(Of Point) = Nothing

    ' Points for the new polygon.
    Private PolyPreview As List(Of Point) = Nothing

    ' The current mouse position while drawing a new polygon.
    Private NewPoint As Point
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load

        pbCanvas.BackColor = Color.White

    End Sub

    Private Sub pbCanvas_MouseDown(sender As Object, e As MouseEventArgs) Handles pbCanvas.MouseDown
        If (shape = "Polygon") Then
            ' See if we are already drawing a polygon.
            If (PolyPreview IsNot Nothing) Then
                ' We are already drawing a polygon.
                ' If it's the right mouse button, finish this
                ' polygon.
                If (e.Button = MouseButtons.Right) Then
                    ' Finish this polygon.
                    If (PolyPreview.Count > 2) Then
                        Polygons = PolyPreview
                        PolyPreview = Nothing
                    End If
                Else
                    ' Add a point to this polygon.
                    If (PolyPreview(PolyPreview.Count - 1) <>
            e.Location) Then
                        PolyPreview.Add(e.Location)
                    End If
                End If
            Else
                ' Start a new polygon.
                PolyPreview = New List(Of Point)()
                NewPoint = e.Location
                PolyPreview.Add(e.Location)
            End If
        Else
            ClipRect.Location = e.Location
            ClipRect.Size = New Size(0, 0)
        End If
        ' Redraw.
        pbCanvas.Invalidate()
    End Sub

    Private Sub pbCanvas_MouseMove(sender As Object, e As MouseEventArgs) Handles pbCanvas.MouseMove
        If (shape = "Polygon") Then
            If (PolyPreview Is Nothing) Then Exit Sub
            NewPoint = e.Location

        Else
            If (e.Button = MouseButtons.Left) Then

                ClipRect.Width = e.X - ClipRect.X
                ClipRect.Height = e.Y - ClipRect.Y

            End If
        End If
        pbCanvas.Invalidate()
    End Sub

    Private Function Clipping(Poly As Array) As List(Of Point)
        Try
            Dim top = ClipRect.Top
            Dim bottom = ClipRect.Bottom
            Dim right = ClipRect.Right
            Dim left = ClipRect.Left
            Dim Clipped As New List(Of Point)
            Dim NewClipped As New List(Of Point)
            Dim counter = 0
            For count As Integer = 0 To Poly.Length - 2
                'Top Clipping'
                If ((Poly(count).Y <= top And Poly(count + 1).Y >= top) Or (Poly(count).Y >= top And Poly(count + 1).Y <= top)) Then
                    Dim dx = Poly(count + 1).X - Poly(count).X
                    Dim dy = Poly(count + 1).Y - Poly(count).Y
                    Dim x = Poly(count).X + dx * (top - Poly(count).Y) / dy
                    Dim y = top
                    Dim p As New Point(x, y)
                    If (Poly(count).Y <= top And Poly(count + 1).Y >= top) Then
                        Clipped.Add(p)
                        Clipped.Add(Poly(count + 1))
                    Else
                        Clipped.Add(p)
                    End If
                ElseIf (Poly(count).Y >= top And Poly(count + 1).Y >= top) Then
                    Clipped.Add(Poly(count + 1))
                End If
            Next

            If ((Poly(Poly.Length - 1).Y >= top And Poly(0).Y <= top) Or (Poly(Poly.Length - 1).Y <= top And Poly(0).Y >= top)) Then
                Dim dx = Poly(0).X - Poly(Poly.Length - 1).X
                Dim dy = Poly(0).Y - Poly(Poly.Length - 1).Y
                Dim x = Poly(Poly.Length - 1).X + dx * (top - Poly(Poly.Length - 1).Y) / dy
                Dim y = top
                Dim p As New Point(x, y)
                If (Poly(Poly.Length - 1).Y <= top And Poly(0).Y >= top) Then
                    Clipped.Add(p)
                    Clipped.Add(Poly(0))
                Else
                    Clipped.Add(p)
                End If
            ElseIf (Poly(Poly.Length - 1).Y >= top And Poly(0).Y >= top) Then
                Clipped.Add(Poly(0))
            End If

            For count As Integer = 0 To Clipped.ToArray.Length - 2
                'Bottom Clipping'
                If ((Clipped(count).Y <= bottom And Clipped(count + 1).Y >= bottom) Or (Clipped(count).Y >= bottom And Clipped(count + 1).Y <= bottom)) Then
                    Dim dx = Clipped(count + 1).X - Clipped(count).X
                    Dim dy = Clipped(count + 1).Y - Clipped(count).Y
                    Dim x = Clipped(count).X + dx * (bottom - Clipped(count).Y) / dy
                    Dim y = bottom
                    Dim p As New Point(x, y)
                    If (Clipped(count).Y >= bottom And Clipped(count + 1).Y <= bottom) Then
                        NewClipped.Add(p)
                        NewClipped.Add(Clipped(count + 1))
                    Else
                        NewClipped.Add(p)
                    End If
                ElseIf (Clipped(count).Y <= bottom And Clipped(count + 1).Y <= bottom) Then
                    NewClipped.Add(Clipped(count + 1))
                End If
            Next

            If ((Clipped(Clipped.ToArray.Length - 1).Y >= bottom And Clipped(0).Y <= bottom) Or (Clipped(Clipped.ToArray.Length - 1).Y <= bottom And Clipped(0).Y >= bottom)) Then
                Dim dx = Clipped(0).X - Clipped(Clipped.ToArray.Length - 1).X
                Dim dy = Clipped(0).Y - Clipped(Clipped.ToArray.Length - 1).Y
                Dim x = Clipped(Clipped.ToArray.Length - 1).X + dx * (bottom - Clipped(Clipped.ToArray.Length - 1).Y) / dy
                Dim y = bottom
                Dim p As New Point(x, y)
                If (Clipped(Clipped.ToArray.Length - 1).Y >= bottom And Clipped(0).Y <= bottom) Then
                    NewClipped.Add(p)
                    NewClipped.Add(Clipped(0))
                Else
                    NewClipped.Add(p)
                End If
            ElseIf (Clipped(Clipped.ToArray.Length - 1).Y <= bottom And Clipped(0).Y <= bottom) Then
                NewClipped.Add(Clipped(0))
            End If
            Clipped = NewClipped
            NewClipped = New List(Of Point)

            For count As Integer = 0 To Clipped.ToArray.Length - 2
                'right Clipping'
                If ((Clipped(count).X <= right And Clipped(count + 1).X >= right) Or (Clipped(count).X >= right And Clipped(count + 1).X <= right)) Then
                    Dim dx = Clipped(count + 1).X - Clipped(count).X
                    Dim dy = Clipped(count + 1).Y - Clipped(count).Y
                    Dim x = right
                    Dim y = Clipped(count).Y + dy * (right - Clipped(count).X) / dx
                    Dim p As New Point(x, y)
                    If (Clipped(count).X >= right And Clipped(count + 1).X <= right) Then
                        NewClipped.Add(p)
                        NewClipped.Add(Clipped(count + 1))
                    Else
                        NewClipped.Add(p)
                    End If
                ElseIf (Clipped(count).X <= right And Clipped(count + 1).X <= right) Then
                    NewClipped.Add(Clipped(count + 1))
                End If
            Next

            If ((Clipped(Clipped.ToArray.Length - 1).X >= right And Clipped(0).X <= right) Or (Clipped(Clipped.ToArray.Length - 1).X <= right And Clipped(0).X >= right)) Then
                Dim dx = Clipped(0).X - Clipped(Clipped.ToArray.Length - 1).X
                Dim dy = Clipped(0).Y - Clipped(Clipped.ToArray.Length - 1).Y
                Dim y = Clipped(Clipped.ToArray.Length - 1).Y + dy * (right - Clipped(Clipped.ToArray.Length - 1).X) / dx
                Dim x = right
                Dim p As New Point(x, y)
                If (Clipped(Clipped.ToArray.Length - 1).X >= right And Clipped(0).X <= right) Then
                    NewClipped.Add(p)
                    NewClipped.Add(Clipped(0))
                Else
                    NewClipped.Add(p)
                End If
            ElseIf (Clipped(Clipped.ToArray.Length - 1).X <= right And Clipped(0).X <= right) Then
                NewClipped.Add(Clipped(0))
            End If

            Clipped = NewClipped
            NewClipped = New List(Of Point)

            For count As Integer = 0 To Clipped.ToArray.Length - 2
                'Left Clipping'
                If ((Clipped(count).X <= left And Clipped(count + 1).X >= left) Or (Clipped(count).X >= left And Clipped(count + 1).X <= left)) Then
                    Dim dx = Clipped(count + 1).X - Clipped(count).X
                    Dim dy = Clipped(count + 1).Y - Clipped(count).Y
                    Dim x = left
                    Dim y = Clipped(count).Y + dy * (left - Clipped(count).X) / dx
                    Dim p As New Point(x, y)
                    If (Clipped(count).X <= left And Clipped(count + 1).X >= left) Then
                        NewClipped.Add(p)
                        NewClipped.Add(Clipped(count + 1))
                    Else
                        NewClipped.Add(p)
                    End If
                ElseIf (Clipped(count).X >= left And Clipped(count + 1).X >= left) Then
                    NewClipped.Add(Clipped(count + 1))
                End If
            Next

            If ((Clipped(Clipped.ToArray.Length - 1).X >= left And Clipped(0).X <= left) Or (Clipped(Clipped.ToArray.Length - 1).X <= left And Clipped(0).X >= left)) Then
                Dim dx = Clipped(0).X - Clipped(Clipped.ToArray.Length - 1).X
                Dim dy = Clipped(0).Y - Clipped(Clipped.ToArray.Length - 1).Y
                Dim y = Clipped(Clipped.ToArray.Length - 1).Y + dy * (left - Clipped(Clipped.ToArray.Length - 1).X) / dx
                Dim x = left
                Dim p As New Point(x, y)
                If (Clipped(Clipped.ToArray.Length - 1).X <= left And Clipped(0).X >= left) Then
                    NewClipped.Add(p)
                    NewClipped.Add(Clipped(0))
                Else
                    NewClipped.Add(p)
                End If
            ElseIf (Clipped(Clipped.ToArray.Length - 1).X >= left And Clipped(0).X >= left) Then
                NewClipped.Add(Clipped(0))
            End If

            Clipped = NewClipped
            NewClipped = New List(Of Point)
            Clipping = Clipped
        Catch ex As Exception
        End Try
    End Function

    Private Sub pbCanvas_Paint(sender As Object, e As PaintEventArgs) Handles pbCanvas.Paint
        'e.Graphics.SmoothingMode = SmoothingMode.AntiAlias
        If (Polygons IsNot Nothing) Then
            e.Graphics.DrawPolygon(Pens.Blue, Polygons.ToArray())
        End If
        e.Graphics.DrawRectangle(_pen, ClipRect)
        If (shape = "Polygon") Then
            ' Draw the new polygon.
            If (PolyPreview IsNot Nothing) Then
                ' Draw the new polygon.
                If (PolyPreview.Count > 1) Then
                    e.Graphics.DrawLines(Pens.Green,
                        PolyPreview.ToArray())
                End If

                ' Draw the newest edge.
                If (PolyPreview.Count > 0) Then
                    Using dashed_pen As New Pen(Color.Green)
                        dashed_pen.DashPattern = New Single() {3, 3}
                        e.Graphics.DrawLine(dashed_pen,
                            PolyPreview(PolyPreview.Count - 1),
                            NewPoint)
                    End Using
                End If
            End If
        End If
        Try
            Dim Clipped As List(Of Point) = Clipping(Polygons.ToArray())
            e.Graphics.DrawPolygon(Pens.Red, Clipped.ToArray())
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnPoly_MouseClick(sender As Object, e As MouseEventArgs) Handles btnPoly.MouseClick
        shape = "Polygon"
    End Sub

    Private Sub btnRect_MouseClick(sender As Object, e As MouseEventArgs) Handles btnRect.MouseClick
        shape = "Rectangle"
    End Sub

    Private Sub pbCanvas_MouseUp(sender As Object, e As MouseEventArgs) Handles pbCanvas.MouseUp
        If (shape = "Rectangle") Then
            If (e.Y < ClipRect.Y) Then
                ClipRect.Location = If(ClipRect.Location.X > e.X, New Point(e.X, e.Y), New Point(ClipRect.X, e.Y))
                ClipRect.Size = New Size(Math.Abs(ClipRect.Width), Math.Abs(ClipRect.Height))
            Else
                If ClipRect.Location.X > ClipRect.Right Then
                    ClipRect.Location = New Point(e.X, ClipRect.Y)
                    ClipRect.Size = New Size(Math.Abs(ClipRect.Width), Math.Abs(ClipRect.Height))
                End If
            End If
        End If
        pbCanvas.Invalidate()
    End Sub

    Private Sub Delete_Clip()
        ClipRect = Nothing
    End Sub

    Private Sub Delete_Poly()
        Polygons = Nothing
    End Sub

    Private Sub btnDelClip_Click(sender As Object, e As EventArgs) Handles btnDelClip.Click
        Delete_Clip()
        pbCanvas.Refresh()
    End Sub

    Private Sub btnDelPoly_Click(sender As Object, e As EventArgs) Handles btnDelPoly.Click
        Delete_Poly()
        pbCanvas.Refresh()
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        Delete_Clip()
        Delete_Poly()
        pbCanvas.Refresh()
    End Sub
End Class