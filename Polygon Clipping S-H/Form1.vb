Public Class Form1
    Dim saveConfirm
    Dim _pen As Pen = New Pen(Color.Black, 3)
    Dim shape As String
    Dim Poly_Type As String
    Private Polygons As List(Of Point) = Nothing
    Private ClippingWindow As List(Of Point) = Nothing
    Private ClippedPoly As New List(Of Point)
    Private NewClippedPoly As New List(Of Point)
    Private PolyPreview As List(Of Point) = Nothing
    Private ClippingWindowPreview As List(Of Point) = Nothing
    Private NewPoint As Point
    Private NewPointClip As Point
    Private NewPointMulti As Point
    Dim Multi_Polygons As New List(Of List(Of Point))
    Dim Multi_PolyVector As New List(Of Vector)
    Dim Multi_PolyPreview As List(Of Point) = Nothing
    Dim Multi_ClippedPoly As New List(Of List(Of Point))
    Dim Multi_ClipPolyVector As New List(Of Vector)
    Dim PolyVector = New Vector
    Dim ClipPolyVector = New Vector
    Dim PolyVectorMulti = New Vector
    Dim ClipVector = New Vector
    Dim NormalClipVector = New Vector
    Dim point_indicator As New List(Of Integer)

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

    Private Function Create_PolyVector(ByRef LPoints As List(Of Point))
        Dim Temp_Vector As New Vector
        For i As Integer = 0 To LPoints.Count - 1
            If i = LPoints.Count - 1 Then
                Temp_Vector.Add(LPoints(0).X - LPoints(i).X, LPoints(0).Y - LPoints(i).Y)
            Else
                Temp_Vector.Add(LPoints(i + 1).X - LPoints(i).X, LPoints(i + 1).Y - LPoints(i).Y)
            End If
        Next
        Create_PolyVector = Temp_Vector
    End Function

    Private Function Dot_product(x1 As Double, x2 As Double, y1 As Double, y2 As Double)
        Dot_product = x1 * x2 + y1 * y2
    End Function

    Private Function Dot_product_vector(v1 As Vector, v2 As Vector, index As Integer)
        Dot_product_vector = v1.i(index) * v2.i(index) + v1.j(index) * v2.j(index)
    End Function

    Private Function Dot_product_vector_diff(v1 As Vector, v2 As Vector, index1 As Integer, index2 As Integer)
        Dot_product_vector_diff = v1.i(index1) * v2.i(index2) + v1.j(index1) * v2.j(index2)
    End Function

    Private Sub Clip_step(ByRef Poly As List(Of Point), ByRef ClipPoly As List(Of Point), ByRef Vect As Vector, ByRef ClipVect As Vector, count As Integer)
        Dim temp_vector As New Vector
        Dim Temp_index As Integer = 0
        point_indicator = New List(Of Integer)
        Dim pivot = ClippingWindow(count)
        Dim normal_i = NormalClipVector.i(count)
        Dim normal_j = NormalClipVector.j(count)
        Dim Temp_LPoints As List(Of Point)
        Dim Temp_PVector As Vector
        If count = 0 Then
            Temp_LPoints = Poly
            Temp_PVector = Vect
        Else
            Temp_LPoints = ClipPoly
            Temp_PVector = ClipVect
        End If
        For Each p As Point In Temp_LPoints
            Dim Temp_Vector_i = p.X - pivot.X
            Dim Temp_Vector_j = p.Y - pivot.Y
            Dim Dot = Dot_product(Temp_Vector_i, normal_i, Temp_Vector_j, normal_j)
            If Dot >= 0 Then
                point_indicator.Add(0)
            Else
                point_indicator.Add(1)
            End If
        Next

        For i As Integer = 0 To point_indicator.Count - 1
            If i = point_indicator.Count - 1 Then
                If (point_indicator(i) = 0 And point_indicator(0) = 0) Then
                    NewClippedPoly.Add(Temp_LPoints(0))
                ElseIf (point_indicator(i) = 0 And point_indicator(0) = 1) Then
                    temp_vector.Add(Temp_LPoints(i).X - ClippingWindow(count).X, Temp_LPoints(i).Y - ClippingWindow(count).Y)
                    Dim t = Dot_product_vector_diff(temp_vector, NormalClipVector, Temp_index, count) / Dot_product_vector_diff(Temp_PVector, NormalClipVector, i, count)
                    If (t < 0) Then
                        t *= -1
                    End If
                    Dim temp_x = Temp_LPoints(i).X + t * (Temp_LPoints(0).X - Temp_LPoints(i).X)
                    Dim temp_y = Temp_LPoints(i).Y + t * (Temp_LPoints(0).Y - Temp_LPoints(i).Y)
                    Dim temp = New Point(temp_x, temp_y)
                    NewClippedPoly.Add(temp)
                    Temp_index += 1
                ElseIf (point_indicator(i) = 1 And point_indicator(0) = 0) Then
                    temp_vector.Add(Temp_LPoints(i).X - ClippingWindow(count).X, Temp_LPoints(i).Y - ClippingWindow(count).Y)
                    Dim t = Dot_product_vector_diff(temp_vector, NormalClipVector, Temp_index, count) / Dot_product_vector_diff(Temp_PVector, NormalClipVector, i, count)
                    If (t < 0) Then
                        t *= -1
                    End If
                    Dim temp_x = Temp_LPoints(i).X + t * (Temp_LPoints(0).X - Temp_LPoints(i).X)
                    Dim temp_y = Temp_LPoints(i).Y + t * (Temp_LPoints(0).Y - Temp_LPoints(i).Y)
                    Dim temp = New Point(temp_x, temp_y)
                    NewClippedPoly.Add(temp)
                    NewClippedPoly.Add(Temp_LPoints(0))
                    Temp_index += 1
                End If

            Else
                If (point_indicator(i) = 0 And point_indicator(i + 1) = 0) Then
                    NewClippedPoly.Add(Temp_LPoints(i + 1))
                ElseIf (point_indicator(i) = 0 And point_indicator(i + 1) = 1) Then
                    temp_vector.Add(Temp_LPoints(i).X - ClippingWindow(count).X, Temp_LPoints(i).Y - ClippingWindow(count).Y)
                    Dim t = Dot_product_vector_diff(temp_vector, NormalClipVector, Temp_index, count) / Dot_product_vector_diff(Temp_PVector, NormalClipVector, i, count)
                    If (t < 0) Then
                        t *= -1
                    End If
                    Dim temp_x = Temp_LPoints(i).X + t * (Temp_LPoints(i + 1).X - Temp_LPoints(i).X)
                    Dim temp_y = Temp_LPoints(i).Y + t * (Temp_LPoints(i + 1).Y - Temp_LPoints(i).Y)
                    Dim temp = New Point(temp_x, temp_y)
                    NewClippedPoly.Add(temp)
                    Temp_index += 1
                ElseIf (point_indicator(i) = 1 And point_indicator(i + 1) = 0) Then
                    temp_vector.Add(Temp_LPoints(i).X - ClippingWindow(count).X, Temp_LPoints(i).Y - ClippingWindow(count).Y)
                    Dim t = Dot_product_vector_diff(temp_vector, NormalClipVector, Temp_index, count) / Dot_product_vector_diff(Temp_PVector, NormalClipVector, i, count)
                    If (t < 0) Then
                        t *= -1
                    End If
                    Dim temp_x = Temp_LPoints(i).X + t * (Temp_LPoints(i + 1).X - Temp_LPoints(i).X)
                    Dim temp_y = Temp_LPoints(i).Y + t * (Temp_LPoints(i + 1).Y - Temp_LPoints(i).Y)
                    Dim temp = New Point(temp_x, temp_y)
                    NewClippedPoly.Add(temp)
                    NewClippedPoly.Add(Temp_LPoints(i + 1))
                    Temp_index += 1
                End If
            End If
        Next
    End Sub

    Private Sub Multi_Clipping(ByRef Poly As List(Of List(Of Point)), ByRef ClipPoly As List(Of List(Of Point)), ByRef Vect As List(Of Vector), ByRef ClipVect As List(Of Vector))
        Dim temp_vector As New Vector
        Try
            For List_index As Integer = 0 To Poly.Count - 1
                For count As Integer = 0 To NormalClipVector.n - 1
                    Try
                        Clip_step(Poly(List_index), ClipPoly(List_index), Vect(List_index), ClipVect(List_index), count)
                    Catch ex As Exception
                        Clip_step(Poly(List_index), Poly(List_index), Vect(List_index), Vect(List_index), count)
                    End Try
                    Try
                        ClipPoly(List_index) = NewClippedPoly
                    Catch ex As Exception
                        ClipPoly.Add(NewClippedPoly)
                    End Try
                    Try
                        ClipVect(List_index) = Create_PolyVector(ClipPoly(List_index))
                    Catch ex As Exception
                        ClipVect.Add(Create_PolyVector(ClipPoly(List_index)))
                    End Try
                    NewClippedPoly = New List(Of Point)
                Next
            Next
        Catch ex As Exception

        End Try

    End Sub

    Private Sub Clipping(ByRef Poly As List(Of Point), ByRef ClipPoly As List(Of Point), ByRef Vect As Vector, ByRef ClipVect As Vector)
        Dim temp_vector As New Vector
        Try
            For count As Integer = 0 To NormalClipVector.n - 1
                Clip_step(Poly, ClipPoly, Vect, ClipVect, count)
                ClipPoly = NewClippedPoly
                ClipVect = Create_PolyVector(ClipPoly)
                NewClippedPoly = New List(Of Point)
            Next
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Find_Normal(indicator As Integer)
        For count As Integer = 0 To ClipVector.n - 1
            Dim i = ClipVector.i(count)
            Dim j = ClipVector.j(count)
            If indicator = 0 Then
                NormalClipVector.Add(j, -i)
            ElseIf indicator = 1 Then
                NormalClipVector.Add(-j, i)
            End If
        Next
    End Sub

    Private Function Check_convex(LPoint As List(Of Point))
        Dim indicator As Integer
        Dim x1 As Double = LPoint(0).X
        Dim y1 As Double = LPoint(0).Y
        Dim x2 As Double = LPoint(1).X
        Dim y2 As Double = LPoint(1).Y
        Dim x3 As Double = LPoint(2).X
        Dim y3 As Double = LPoint(2).Y
        Dim dx1 As Double = x2 - x1
        Dim dx2 As Double = x3 - x2
        Dim dy1 As Double = y2 - y1
        Dim dy2 As Double = y3 - y2

        Dim Result As Double = (dx1 * dy2 - dy1 * dx2) * -1
        If Result > 0 Then 'Counter-Clockwise
            indicator = 0
        ElseIf Result < 0 Then 'Clockwise
            indicator = 1
        End If
        ClipVector.Add(dx1, dy1)
        ClipVector.Add(dx2, dy2)

        For count As Integer = 2 To LPoint.Count - 1
            Dim xa As Double = LPoint(count).X
            Dim ya As Double = LPoint(count).Y
            Dim xb As Double
            Dim yb As Double
            If count = LPoint.Count - 1 Then
                xb = LPoint(0).X
                yb = LPoint(0).Y
            Else
                xb = LPoint(count + 1).X
                yb = LPoint(count + 1).Y
            End If
            Dim dx As Double = xb - xa
            Dim dy As Double = yb - ya

            Dim Res = (ClipVector.i(count - 1) * dy - ClipVector.j(count - 1) * dx) * -1
            If (indicator = 0 And Res < 0) Or (indicator = 1 And Res > 0) Then
                Check_convex = 2
                Exit Function
            End If
            ClipVector.Add(dx, dy)
        Next
        Dim Final_res = -1 * (ClipVector.i(ClipVector.n - 1) * ClipVector.j(0) - ClipVector.j(ClipVector.n - 1) * ClipVector.i(0))
        If (indicator = 0 And Final_res < 0) Or (indicator = 1 And Final_res > 0) Then
            Check_convex = 2
            Exit Function
        End If
        Find_Normal(indicator)
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
                        PolyVector = New Vector
                        PolyVector = Create_PolyVector(Polygons)
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
                        ClipVector = New Vector
                        NormalClipVector = New Vector
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
        ElseIf shape = "Multi" Then
            If (Multi_PolyPreview IsNot Nothing) Then
                ' We are already drawing a polygon.
                ' If it's the right mouse button, finish this
                ' polygon.
                If (e.Button = MouseButtons.Right) Then
                    ' Finish this polygon.
                    If (Multi_PolyPreview.Count > 2) Then _
                        Multi_Polygons.Add(Multi_PolyPreview)
                    PolyVectorMulti = New Vector
                    PolyVectorMulti = Create_PolyVector(Multi_PolyPreview)
                    Multi_PolyVector.Add(PolyVectorMulti)
                    Multi_PolyPreview = Nothing
                Else
                    ' Add a point to this polygon.
                    If (Multi_PolyPreview(Multi_PolyPreview.Count - 1) <>
                        e.Location) Then
                        Multi_PolyPreview.Add(e.Location)
                    End If
                End If
            Else
                ' Start a new polygon.
                Multi_PolyPreview = New List(Of Point)()
                NewPointMulti = e.Location
                Multi_PolyPreview.Add(e.Location)
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
        ElseIf (shape = "Multi") Then
            If (Multi_PolyPreview Is Nothing) Then Exit Sub
            NewPointMulti = e.Location
        End If
        pbCanvas.Invalidate()
    End Sub

    Private Sub pbCanvas_Paint(sender As Object, e As PaintEventArgs) Handles pbCanvas.Paint
        'e.Graphics.SmoothingMode = SmoothingMode.AntiAlias
        Try
            Clipping(Polygons, ClippedPoly, PolyVector, ClipPolyVector)
        Catch ex As Exception

        End Try
        Try
            Multi_Clipping(Multi_Polygons, Multi_ClippedPoly, Multi_PolyVector, Multi_ClipPolyVector)
        Catch ex As Exception

        End Try
        If (ClippingWindow IsNot Nothing) Then
            For i As Integer = 0 To ClippingWindow.Count - 1
                If i = ClippingWindow.Count - 1 Then
                    e.Graphics.DrawLine(Pens.Black, ClippingWindow(i), ClippingWindow(0))
                Else
                    e.Graphics.DrawLine(Pens.Black, ClippingWindow(i), ClippingWindow(i + 1))
                End If
            Next
        End If

        If (shape = "Polygon") Then
            If (Polygons IsNot Nothing) Then
                For i As Integer = 0 To Polygons.Count - 1
                    If i = Polygons.Count - 1 Then
                        e.Graphics.DrawLine(Pens.Blue, Polygons(i), Polygons(0))
                    Else
                        e.Graphics.DrawLine(Pens.Blue, Polygons(i), Polygons(i + 1))
                    End If
                Next
            End If
            Try
                For i As Integer = 0 To ClippedPoly.Count - 1
                    If i = ClippedPoly.Count - 1 Then
                        e.Graphics.DrawLine(Pens.Red, ClippedPoly(i), ClippedPoly(0))
                    Else
                        e.Graphics.DrawLine(Pens.Red, ClippedPoly(i), ClippedPoly(i + 1))
                    End If
                Next
            Catch ex As Exception
            End Try
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

            If Poly_Type = "Polygon" Then
                If (Polygons IsNot Nothing) Then
                    For i As Integer = 0 To Polygons.Count - 1
                        If i = Polygons.Count - 1 Then
                            e.Graphics.DrawLine(Pens.Blue, Polygons(i), Polygons(0))
                        Else
                            e.Graphics.DrawLine(Pens.Blue, Polygons(i), Polygons(i + 1))
                        End If
                    Next
                End If
                Try
                    For i As Integer = 0 To ClippedPoly.Count - 1
                        If i = ClippedPoly.Count - 1 Then
                            e.Graphics.DrawLine(Pens.Red, ClippedPoly(i), ClippedPoly(0))
                        Else
                            e.Graphics.DrawLine(Pens.Red, ClippedPoly(i), ClippedPoly(i + 1))
                        End If
                    Next
                Catch ex As Exception
                End Try
            Else
                Try
                    For Each Poly In Multi_Polygons
                        For i As Integer = 0 To Poly.Count - 1
                            If i = Poly.Count - 1 Then
                                e.Graphics.DrawLine(Pens.Purple, Poly(i), Poly(0))
                            Else
                                e.Graphics.DrawLine(Pens.Purple, Poly(i), Poly(i + 1))
                            End If
                        Next
                    Next
                Catch ex As Exception

                End Try
                Try
                    For Each ClipPoly In Multi_ClippedPoly
                        Try
                            For i As Integer = 0 To ClipPoly.Count - 1
                                If i = ClipPoly.Count - 1 Then
                                    e.Graphics.DrawLine(Pens.Orange, ClipPoly(i), ClipPoly(0))
                                Else
                                    e.Graphics.DrawLine(Pens.Orange, ClipPoly(i), ClipPoly(i + 1))
                                End If
                            Next
                        Catch ex As Exception
                        End Try
                    Next
                Catch ex As Exception
                End Try
            End If
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
        ElseIf (shape = "Multi") Then
            Try
                For Each Poly In Multi_Polygons
                    For i As Integer = 0 To Poly.Count - 1
                        If i = Poly.Count - 1 Then
                            e.Graphics.DrawLine(Pens.Purple, Poly(i), Poly(0))
                        Else
                            e.Graphics.DrawLine(Pens.Purple, Poly(i), Poly(i + 1))
                        End If
                    Next
                Next
            Catch ex As Exception

            End Try
            Try
                For Each ClipPoly In Multi_ClippedPoly
                    Try
                        For i As Integer = 0 To ClipPoly.Count - 1
                            If i = ClipPoly.Count - 1 Then
                                e.Graphics.DrawLine(Pens.Orange, ClipPoly(i), ClipPoly(0))
                            Else
                                e.Graphics.DrawLine(Pens.Orange, ClipPoly(i), ClipPoly(i + 1))
                            End If
                        Next
                    Catch ex As Exception

                    End Try
                Next
            Catch ex As Exception
            End Try
            ' Draw the new polygon.
            If (Multi_PolyPreview IsNot Nothing) Then
                ' Draw the new polygon.
                If (Multi_PolyPreview.Count > 1) Then
                    e.Graphics.DrawLines(Pens.Green,
                        Multi_PolyPreview.ToArray())
                End If

                ' Draw the newest edge.
                If (Multi_PolyPreview.Count > 0) Then
                    Using dashed_pen As New Pen(Color.Green)
                        dashed_pen.DashPattern = New Single() {3, 3}
                        e.Graphics.DrawLine(dashed_pen,
                            Multi_PolyPreview(Multi_PolyPreview.Count - 1),
                            NewPointMulti)
                    End Using
                End If
            End If
        End If
    End Sub

    Private Sub btnPoly_MouseClick(sender As Object, e As MouseEventArgs) Handles btnPoly.MouseClick
        shape = "Polygon"
        Poly_Type = "Polygon"
        pbCanvas.Refresh()
    End Sub

    Private Sub btnRect_MouseClick(sender As Object, e As MouseEventArgs) Handles btnRect.MouseClick
        shape = "Rectangle"
        pbCanvas.Refresh()
    End Sub

    Private Sub Delete_Clip()
        ClippingWindow = Nothing
    End Sub

    Private Sub Delete_Poly()
        Polygons = Nothing
    End Sub

    Private Sub Delete_Multi()
        Multi_Polygons.Clear()
        Multi_PolyVector.Clear()
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
        Me.pbCanvas.Image = New Bitmap(Me.pbCanvas.Width, Me.pbCanvas.Height)
        ClippedPoly.Clear()
        Multi_ClippedPoly.Clear()
        pbCanvas.Refresh()
    End Sub

    Private Sub btnMulti_Click(sender As Object, e As EventArgs) Handles btnMulti.Click
        shape = "Multi"
        Poly_Type = "Multi"
        pbCanvas.Refresh()
    End Sub

    Private Sub btnClearMulti_Click(sender As Object, e As EventArgs) Handles btnClearMulti.Click
        Delete_Multi()
        pbCanvas.Refresh()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Me.pbCanvas.Image = New Bitmap(Me.pbCanvas.Width, Me.pbCanvas.Height)
        saveConfirm = "Hokhai"
        Dim g As Graphics = Graphics.FromImage(pbCanvas.Image)
        If (saveConfirm) = "Hokhai" Then
            If (shape = "Polygon") Then
                For i As Integer = 0 To Polygons.Count - 1
                    If i = Polygons.Count - 1 Then
                        g.DrawLine(Pens.Blue, Polygons(i), Polygons(0))
                    Else
                        g.DrawLine(Pens.Blue, Polygons(i), Polygons(i + 1))
                    End If
                Next
                For i As Integer = 0 To ClippingWindow.Count - 1
                    If i = ClippingWindow.Count - 1 Then
                        g.DrawLine(Pens.Black, ClippingWindow(i), ClippingWindow(0))
                    Else
                        g.DrawLine(Pens.Black, ClippingWindow(i), ClippingWindow(i + 1))
                    End If
                Next
                For i As Integer = 0 To ClippedPoly.Count - 1
                    If i = ClippedPoly.Count - 1 Then
                        g.DrawLine(Pens.Red, ClippedPoly(i), ClippedPoly(0))
                    Else
                        g.DrawLine(Pens.Red, ClippedPoly(i), ClippedPoly(i + 1))
                    End If
                Next
            ElseIf (shape = "Multi") Then
                For i As Integer = 0 To ClippingWindow.Count - 1
                    If i = ClippingWindow.Count - 1 Then
                        g.DrawLine(Pens.Black, ClippingWindow(i), ClippingWindow(0))
                    Else
                        g.DrawLine(Pens.Black, ClippingWindow(i), ClippingWindow(i + 1))
                    End If
                Next
                For Each ClipPoly In Multi_ClippedPoly
                    Try
                        For i As Integer = 0 To ClipPoly.Count - 1
                            If i = ClipPoly.Count - 1 Then
                                g.DrawLine(Pens.Orange, ClipPoly(i), ClipPoly(0))
                            Else
                                g.DrawLine(Pens.Orange, ClipPoly(i), ClipPoly(i + 1))
                            End If
                        Next
                    Catch ex As Exception
                    End Try
                Next
                Try
                    For Each Poly In Multi_Polygons
                        For i As Integer = 0 To Poly.Count - 1
                            If i = Poly.Count - 1 Then
                                g.DrawLine(Pens.Purple, Poly(i), Poly(0))
                            Else
                                g.DrawLine(Pens.Purple, Poly(i), Poly(i + 1))
                            End If
                        Next
                    Next
                Catch ex As Exception
                End Try
            End If
        End If

        Dim savePic As New SaveFileDialog()
        Dim defPath As String = "D:\Picture\"
        Dim Directory As String = System.IO.Path.GetDirectoryName(defPath)

        Try
            With savePic
                .Title = "Save Image As"
                .Filter = "PNG Image|*.png|Jpg, Jpeg Images|*.jpg;*.jpeg|BMP Image|*.bmp"
                .AddExtension = True
                .DefaultExt = ".png"
                .FileName = "picture.png"
                .ValidateNames = True
                .OverwritePrompt = True
                .InitialDirectory = Directory
                .RestoreDirectory = True

                If .ShowDialog = DialogResult.OK Then
                    If .FilterIndex = 1 Then
                        pbCanvas.Image.Save(savePic.FileName, Imaging.ImageFormat.Png)
                    ElseIf .FilterIndex = 2 Then
                        pbCanvas.Image.Save(savePic.FileName, Imaging.ImageFormat.Jpeg)
                    ElseIf .FilterIndex = 3 Then
                        pbCanvas.Image.Save(savePic.FileName, Imaging.ImageFormat.Bmp)
                    End If
                Else
                    Return
                End If
            End With
        Catch ex As Exception
            MsgBox("Error to save the image : " & ex.Message.ToString())
        Finally
            savePic.Dispose()
        End Try
        saveConfirm = "nope"
    End Sub
    Public Sub LoadImage(ByVal pcBox As PictureBox)
        Dim loadDia As New OpenFileDialog
        loadDia.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyPictures
        loadDia.Filter = "Jpg, Jpeg Images|*.jpg;*.jpeg|PNG Image|*.png|BMP Image|*.bmp"
        Dim result As DialogResult = loadDia.ShowDialog
        If Not (pcBox) Is Nothing And loadDia.FileName <> String.Empty Then
            pcBox.Image = Image.FromFile(loadDia.FileName)
        End If
    End Sub

    Private Sub btnLoad_Click(sender As Object, e As EventArgs) Handles btnLoad.Click
        LoadImage(pbCanvas)
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        Delete_Clip()
        ClippedPoly.Clear()
        Multi_ClippedPoly.Clear()
        pbCanvas.Refresh()
    End Sub
End Class