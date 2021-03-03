Public Class Form1
    Dim _pen As Pen = New Pen(Color.Black, 3)
    Dim shape As String
    ' Each polygon is represented by a List(Of Point).
    Private Polygons As List(Of Point) = Nothing
    Private ClippingWindow As List(Of Point) = Nothing
    ' Points for the new polygon.
    Private PolyPreview As List(Of Point) = Nothing
    Private ClippingWindowPreview As List(Of Point) = Nothing
    ' The current mouse position while drawing a new polygon.
    Private NewPoint As Point
    Private NewPointClip As Point
    Dim PolyVector = New Vector
    Dim NormalPolyVector = New Vector

    Structure Vector
        Dim i() As Double
        Dim j() As Double
        Dim n As Integer
        Public Sub init()
            n = 0
            ReDim i(n - 1)
            ReDim j(n - 1)
        End Sub

        Public Sub Add(ByVal dx As Double, ByVal dy As Double)
            n += 1
            ReDim Preserve i(n - 1)
            i(n - 1) = dx
            ReDim Preserve j(n - 1)
            j(n - 1) = dy
        End Sub
    End Structure

    'Private Function Clipping(Poly As Array) As List(Of Point)
    '    Try
    '        For count As Integer = 0 To NormalPolyVector.n - 1
    '            'Top Clipping'
    '            Dim pivot = ClippingWindow(count)
    '            For Each p As Point In Polygons

    '            Next

    '            If ((Poly(count).Y <= Top And Poly(count + 1).Y >= Top) Or (Poly(count).Y >= Top And Poly(count + 1).Y <= Top)) Then
    '                Dim dx = Poly(count + 1).X - Poly(count).X
    '                Dim dy = Poly(count + 1).Y - Poly(count).Y
    '                Dim x = Poly(count).X + dx * (Top - Poly(count).Y) / dy
    '                Dim y = Top
    '                Dim p As New Point(x, y)
    '                If (Poly(count).Y <= Top And Poly(count + 1).Y >= Top) Then
    '                    Clipped.Add(p)
    '                    Clipped.Add(Poly(count + 1))
    '                Else
    '                    Clipped.Add(p)
    '                End If
    '            ElseIf (Poly(count).Y >= Top And Poly(count + 1).Y >= Top) Then
    '                Clipped.Add(Poly(count + 1))
    '            End If
    '        Next

    '        If ((Poly(Poly.Length - 1).Y >= Top And Poly(0).Y <= Top) Or (Poly(Poly.Length - 1).Y <= Top And Poly(0).Y >= Top)) Then
    '            Dim dx = Poly(0).X - Poly(Poly.Length - 1).X
    '            Dim dy = Poly(0).Y - Poly(Poly.Length - 1).Y
    '            Dim x = Poly(Poly.Length - 1).X + dx * (Top - Poly(Poly.Length - 1).Y) / dy
    '            Dim y = Top
    '            Dim p As New Point(x, y)
    '            If (Poly(Poly.Length - 1).Y <= Top And Poly(0).Y >= Top) Then
    '                Clipped.Add(p)
    '                Clipped.Add(Poly(0))
    '            Else
    '                Clipped.Add(p)
    '            End If
    '        ElseIf (Poly(Poly.Length - 1).Y >= Top And Poly(0).Y >= Top) Then
    '            Clipped.Add(Poly(0))
    '        End If
    '    Catch
    '    End Try
    'End Function

    Private Sub Find_Normal(indicator As Integer)
        For count As Integer = 0 To PolyVector.n - 1
            Dim i = PolyVector.i(count)
            Dim j = PolyVector.j(count)
            If indicator = 0 Then
                NormalPolyVector.Add(-j, i)
            ElseIf indicator = 1 Then
                NormalPolyVector.Add(j, -i)
            End If
        Next
    End Sub

    Private Function Check_convex(LPoint As List(Of Point))
        Dim indicator As Integer
        Dim x1 As Double = LPoint(LPoint.Count - 2).X
        Dim y1 As Double = LPoint(LPoint.Count - 2).Y
        Dim x2 As Double = LPoint(LPoint.Count - 1).X
        Dim y2 As Double = LPoint(LPoint.Count - 1).Y
        Dim x3 As Double = LPoint(0).X
        Dim y3 As Double = LPoint(0).Y
        Dim dx1 As Double = x2 - x1
        Dim dx2 As Double = x3 - x2
        Dim dy1 As Double = y2 - y1
        Dim dy2 As Double = y3 - y2
        Dim PolyVector = New Vector

        Dim Result As Double = (dx1 * dy2 - dy1 * dx2) * -1
        If Result > 0 Then
            indicator = 0
        ElseIf Result < 0 Then
            indicator = 1
        End If
        PolyVector.Add(dx1, dy1)
        PolyVector.Add(dx2, dy2)

        If indicator = 0 Then
            For count As Integer = 0 To LPoint.Count - 2
                Dim xa As Double = LPoint(count).X
                Dim ya As Double = LPoint(count).Y
                Dim xb As Double = LPoint(count + 1).X
                Dim yb As Double = LPoint(count + 1).Y
                Dim dx As Double = xb - xa
                Dim dy As Double = yb - ya

                Dim Res = (PolyVector.i(count + 1) * dy - PolyVector.j(count + 1) * dx) * -1
                If Res < 0 Then
                    Check_convex = 2
                    Exit Function
                End If
                PolyVector.Add(dx, dy)
            Next
        ElseIf indicator = 1 Then
            For count As Integer = 0 To LPoint.Count - 2
                Dim xa As Double = LPoint(count).X
                Dim ya As Double = LPoint(count).Y
                Dim xb As Double = LPoint(count + 1).X
                Dim yb As Double = LPoint(count + 1).Y
                Dim dx As Double = xb - xa
                Dim dy As Double = yb - ya

                Dim Res = (PolyVector.i(count + 1) * dy - PolyVector.j(count + 1) * dx) * -1
                If Res > 0 Then
                    Check_convex = 2
                    Exit Function
                End If
                PolyVector.Add(dx, dy)
            Next
        End If
        Check_convex = indicator
    End Function

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
        ElseIf (shape = "Rectangle") Then
            If (ClippingWindowPreview IsNot Nothing) Then
                ' We are already drawing a polygon.
                ' If it's the right mouse button, finish this
                ' polygon.
                If (e.Button = MouseButtons.Right) Then
                    ' Finish this polygon.
                    If (ClippingWindowPreview.Count > 2) Then
                        Dim indicator As Integer = Check_convex(ClippingWindowPreview)
                        If (indicator = 0 Or indicator = 1) Then
                            ClippingWindow = ClippingWindowPreview
                            ClippingWindowPreview = Nothing
                        ElseIf (indicator = 2) Then
                            MsgBox("Error : Cliping window is not convex")
                            ClippingWindowPreview = Nothing
                        End If
                    End If
                Else
                    ' Add a point to this polygon.
                    If (ClippingWindowPreview(ClippingWindowPreview.Count - 1) <>
            e.Location) Then
                        ClippingWindowPreview.Add(e.Location)
                    End If
                End If
            Else
                ' Start a new polygon.
                ClippingWindowPreview = New List(Of Point)()
                NewPointClip = e.Location
                ClippingWindowPreview.Add(e.Location)
            End If
        End If
        ' Redraw.
        pbCanvas.Invalidate()
    End Sub

    Private Sub pbCanvas_MouseMove(sender As Object, e As MouseEventArgs) Handles pbCanvas.MouseMove
        If (shape = "Polygon") Then
            If (PolyPreview Is Nothing) Then Exit Sub
            NewPoint = e.Location
        ElseIf (shape = "Rectangle") Then
            If (ClippingWindowPreview Is Nothing) Then Exit Sub
            NewPointClip = e.Location
        End If
        pbCanvas.Invalidate()
    End Sub

    Private Sub pbCanvas_Paint(sender As Object, e As PaintEventArgs) Handles pbCanvas.Paint
        'e.Graphics.SmoothingMode = SmoothingMode.AntiAlias
        Try
            e.Graphics.DrawPolygon(Pens.Blue, Polygons.ToArray())
        Catch ex As Exception
        End Try
        Try
            e.Graphics.DrawPolygon(Pens.Black, ClippingWindow.ToArray())
        Catch ex As Exception

        End Try
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
        ElseIf (shape = "Rectangle") Then
            ' Draw the new polygon.
            If (ClippingWindowPreview IsNot Nothing) Then
                ' Draw the new polygon.
                If (ClippingWindowPreview.Count > 1) Then
                    e.Graphics.DrawLines(Pens.Gray,
                        ClippingWindowPreview.ToArray())
                End If

                ' Draw the newest edge.
                If (ClippingWindowPreview.Count > 0) Then
                    Using dashed_pen As New Pen(Color.Green)
                        dashed_pen.DashPattern = New Single() {3, 3}
                        e.Graphics.DrawLine(dashed_pen,
                            ClippingWindowPreview(ClippingWindowPreview.Count - 1),
                            NewPointClip)
                    End Using
                End If
            End If
        End If
    End Sub

    Private Sub btnPoly_MouseClick(sender As Object, e As MouseEventArgs) Handles btnPoly.MouseClick
        shape = "Polygon"
    End Sub

    Private Sub btnRect_MouseClick(sender As Object, e As MouseEventArgs) Handles btnRect.MouseClick
        shape = "Rectangle"
    End Sub

    Private Sub Delete_Clip()
        ClippingWindow = Nothing
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