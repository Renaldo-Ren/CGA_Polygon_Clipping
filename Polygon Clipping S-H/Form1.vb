Public Class Form1
    Dim saveConfirm
    Dim _pen As Pen = New Pen(Color.Black, 3)
    Dim shape As String
    Dim Poly_Type As String
    Private Polygons As List(Of Point) = Nothing 'Declaration for Single Polygon
    Private ClippingWindow As List(Of Point) = Nothing 'Declaration for Clipping Window
    Private ClippedPoly As New List(Of Point) 'Declaration for Single Polygon that has been clipped 
    Private NewClippedPoly As New List(Of Point) 'Declaration for Temporary Clipped Polygon
    Private PolyPreview As List(Of Point) = Nothing 'Declaration for Unfinished Single Polygon
    Private ClippingWindowPreview As List(Of Point) = Nothing 'Declaration for Unfinished Clipping Window
    Private NewPoint As Point 'Declaration for new point in single polygon
    Private NewPointClip As Point 'Declaration for new point in clipping window
    Private NewPointMulti As Point 'Declaration for new point in multiple polygon(s)
    Dim Multi_Polygons As New List(Of List(Of Point)) 'Declaration for Multiple Polygon(s)
    Dim Multi_PolyVector As New List(Of Vector) 'Declaration for Multiple polygons edges as vector
    Dim Multi_PolyPreview As List(Of Point) = Nothing 'Declaration for Unfinished Multiple Polygon(s)
    Dim Multi_ClippedPoly As New List(Of List(Of Point)) 'Declaration for Multiple Polygon(s) that has/have been clipped
    Dim Multi_ClipPolyVector As New List(Of Vector) 'Declaration for Multiple Polygon(s) edges that have been clipped as vector
    Dim PolyVector = New Vector 'Declaration for Single Polygon edges as vector
    Dim ClipPolyVector = New Vector 'Declaration for Single Polygon edges that have been clipped as vector
    Dim PolyVectorMulti = New Vector 'Declaration for one of the multiple polygon edges as vector
    Dim ClipVector = New Vector 'Declaration for Clipping window edges as vector
    Dim NormalClipVector = New Vector 'Declaration for normal vector of clipping window edges
    Dim point_indicator As New List(Of Integer) 'Declaration for indicator whether a point outside/inside an edge

    Structure Vector 'Declaration for our vector structure
        Dim i() As Double
        Dim j() As Double
        Dim n As Integer
        Public Sub init() 'Initialization
            n = 0
            ReDim i(n - 1)
            ReDim j(n - 1)
        End Sub

        Public Sub Add(ByVal dx As Double, ByVal dy As Double) 'Sub for adding new vector/edge
            n += 1
            ReDim Preserve i(n - 1)
            i(n - 1) = dx
            ReDim Preserve j(n - 1)
            j(n - 1) = dy
        End Sub
    End Structure

    Private Function Create_PolyVector(ByRef LPoints As List(Of Point)) 'Declaration of a function to create the vector from polygon edges
        Dim Temp_Vector As New Vector
        For i As Integer = 0 To LPoints.Count - 1 'Looping as many as the point in the polygon
            If i = LPoints.Count - 1 Then
                Temp_Vector.Add(LPoints(0).X - LPoints(i).X, LPoints(0).Y - LPoints(i).Y) 'Condition for checking the vector from last point to the first point
            Else
                Temp_Vector.Add(LPoints(i + 1).X - LPoints(i).X, LPoints(i + 1).Y - LPoints(i).Y) 'Otherwise we check the vector from a point with its next point
            End If
        Next
        Create_PolyVector = Temp_Vector 'return the vector result'
    End Function

    Private Function Dot_product(x1 As Double, x2 As Double, y1 As Double, y2 As Double) 'Declaration of a function to do a dot product for simple numbers
        Dot_product = x1 * x2 + y1 * y2
    End Function

    Private Function Dot_product_vector(v1 As Vector, v2 As Vector, index1 As Integer, index2 As Integer) 'Declaration of a function to do a dot product of 2 vectors with different indexes
        Dot_product_vector = v1.i(index1) * v2.i(index2) + v1.j(index1) * v2.j(index2)
    End Function

    Private Function Find_Intersection(Poly As List(Of Point), Vect As Vector, pivot As Point, index1 As Integer, index2 As Integer, count As Integer)
        Dim temp_vector As New Vector
        temp_vector.Add(Poly(index1).X - pivot.X, Poly(index1).Y - pivot.Y) 'adding a temp vector from the pivot to the one of the point on the polygon line
        Dim t = Math.Abs(Dot_product_vector(temp_vector, NormalClipVector, 0, count) / Dot_product_vector(Vect, NormalClipVector, index1, count)) 'finding the t to know where the intersection point is. We use abs to make the negative value of t to be positive. The cause is because the y+ is going down not up.
        Dim temp_x = Poly(index1).X + t * (Poly(index2).X - Poly(index1).X) 'Finding the x of the intersection point with parametric equation
        Dim temp_y = Poly(index1).Y + t * (Poly(index2).Y - Poly(index1).Y) 'Finding the y of the interesection point with parametric equation
        Dim temp = New Point(temp_x, temp_y) 'Create a point
        Find_Intersection = temp
    End Function

    Private Sub Sutherland_Hodgman(Poly As List(Of Point), Vect As Vector, pivot As Point, index1 As Integer, index2 As Integer, count As Integer) 'Declaration of function to implement the Sutherland-Hodgman algorithm
        Dim temp_point As New Point
        'Case 1 : when both the start point and the end point are inside the clipping window. we add the end point to the clipped polygon
        If (point_indicator(index1) = 0 And point_indicator(index2) = 0) Then
            NewClippedPoly.Add(Poly(index2))
            'Case x : when the start point is inside the clipping window and the end point is outside the clipping window. We need to find the intersection
            'point of the polygon line with the windows edge, then add that point to the clipped polygon
        ElseIf (point_indicator(index1) = 0 And point_indicator(index2) = 1) Then

            temp_point = Find_Intersection(Poly, Vect, pivot, index1, index2, count) 'Call the function to find the intersection point at the clipping window
            NewClippedPoly.Add(temp_point)
            'Case x : when the start point is inside the clipping window and the end point is outside the clipping window. We need to find the intersection
            'point of the polygon line with the windows edge, then add that point to the clipped polygon
        ElseIf (point_indicator(index1) = 1 And point_indicator(index2) = 0) Then
            temp_point = Find_Intersection(Poly, Vect, pivot, index1, index2, count) 'Call the function to find the intersection point at the clipping window
            NewClippedPoly.Add(temp_point)
            NewClippedPoly.Add(Poly(index2))
            'Case x :  when both the start point and the end point are Outside the clipping window. we dont add anything to the new clipped window
        End If

    End Sub
    Private Sub Clip_step(ByRef Poly As List(Of Point), ByRef Vect As Vector, count As Integer) 'Declaration of function to clip the polygon
        Dim temp_vector As New Vector 'Declaration for the vector to find the intersection point
        Dim Temp_index As Integer = 0 'Declaration to know how many temporary vectors are
        point_indicator = New List(Of Integer) 'This line is for reseting the point_indicator from previous polygon
        Dim pivot = ClippingWindow(count) 'Declaration of a point that we are going to use for the point in the window edge
        Dim normal_i = NormalClipVector.i(count) 'Taking the i value of the normal vector of the clipping window
        Dim normal_j = NormalClipVector.j(count) 'Taking the j value of the normal vector of the clipping window
        For Each p As Point In Poly 'Looping for as many point in the polygon'
            Dim Temp_Vector_i = p.X - pivot.X
            Dim Temp_Vector_j = p.Y - pivot.Y
            Dim Dot = Dot_product(Temp_Vector_i, normal_i, Temp_Vector_j, normal_j) 'Calculating the dot product'
            If Dot >= 0 Then
                point_indicator.Add(0) 'If the result is bigger or equal than zero it means the point is inside or on the windows edge and we mark it as 0
            Else
                point_indicator.Add(1) 'If the result is smaller than zero it means the point is outside the windows edge and we mark it as 1
            End If
        Next

        For i As Integer = 0 To point_indicator.Count - 1 'Looping for how many point in the polygons
            'implementation of Sutherland-Hodgman algorithm
            If i = point_indicator.Count - 1 Then 'condition when the start point is the last point of the polygon and the end point is the first point of the polygon
                Sutherland_Hodgman(Poly, Vect, pivot, i, 0, count)
            Else 'condition when the start point is any point of the polygon and the end point is the next point of the polygon
                Sutherland_Hodgman(Poly, Vect, pivot, i, i + 1, count)
            End If
        Next
    End Sub

    Private Sub Multi_Clipping(ByRef Poly As List(Of List(Of Point)), ByRef ClipPoly As List(Of List(Of Point)), ByRef Vect As List(Of Vector), ByRef ClipVect As List(Of Vector)) 'declaration of function for clipping multiple polygons
        Try
            For List_index As Integer = 0 To Poly.Count - 1 'Looping for each polygon
                For count As Integer = 0 To NormalClipVector.n - 1 'looping for each clipping window edge
                    If count = 0 Then 'Condition for the first edge / first clipping
                        Clip_step(Poly(List_index), Vect(List_index), count) 'Call the function to clip the polygon with the first window edge
                    Else 'Condition for second until last edge
                        Clip_step(ClipPoly(List_index), ClipVect(List_index), count) 'Call the function to clip the clipped polygon with the next window edge until finished
                    End If
                    Try 'Condition for second until last edge
                        ClipPoly(List_index) = NewClippedPoly 'Replace the clipped pollygon with the newest one
                    Catch ex As Exception 'Condition for the first edge / first clipping
                        ClipPoly.Add(NewClippedPoly) 'Create new clipped polygon
                    End Try
                    Try 'Condition for second until last edge
                        ClipVect(List_index) = Create_PolyVector(ClipPoly(List_index)) 'Calling the function to create the vector from our newest clipped polygons and replace the old one
                    Catch ex As Exception 'Condition for the first edge / first clipping
                        ClipVect.Add(Create_PolyVector(ClipPoly(List_index))) 'Calling the function to create the vector from our newest clipped polygons and add it to the list
                    End Try
                    NewClippedPoly = New List(Of Point) 'Reset the temporary newest clipped polygon
                Next
            Next
        Catch ex As Exception
        End Try

    End Sub

    Private Sub Clipping(ByRef Poly As List(Of Point), ByRef ClipPoly As List(Of Point), ByRef Vect As Vector, ByRef ClipVect As Vector) 'declaration of function for clipping single polygon
        Dim temp_vector As New Vector
        Try
            For count As Integer = 0 To NormalClipVector.n - 1
                If count = 0 Then
                    Clip_step(Poly, Vect, count)
                Else
                    Clip_step(ClipPoly, ClipVect, count)
                End If
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
        ElseIf (shape = "ClippingPoly") Then
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
        ElseIf (shape = "ClippingPoly") Then
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
        ElseIf (shape = "ClippingPoly") Then

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

    Private Sub radSingle_CheckedChanged(sender As Object, e As EventArgs) Handles radSingle.CheckedChanged
        shape = "Polygon"
        Poly_Type = "Polygon"
        pbCanvas.Refresh()
    End Sub

    Private Sub radMulti_CheckedChanged(sender As Object, e As EventArgs) Handles radMulti.CheckedChanged
        shape = "Multi"
        Poly_Type = "Multi"
        pbCanvas.Refresh()
    End Sub

    Private Sub btnRect_MouseClick(sender As Object, e As MouseEventArgs) Handles btnRect.MouseClick
        shape = "ClippingPoly"
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
        Delete_Multi()
        Me.pbCanvas.Image = New Bitmap(Me.pbCanvas.Width, Me.pbCanvas.Height)
        ClippedPoly.Clear()
        Multi_Polygons.Clear()
        Multi_ClippedPoly.Clear()
        pbCanvas.Refresh()
    End Sub

    Private Sub btnClearMulti_Click(sender As Object, e As EventArgs) Handles btnClearMulti.Click
        Delete_Multi()
        pbCanvas.Refresh()
        Multi_ClippedPoly.Clear()
    End Sub
    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        Delete_Clip()
        ClippedPoly.Clear()
        Multi_ClippedPoly.Clear()
        pbCanvas.Refresh()
    End Sub

    Private Sub btnRect_Click(sender As Object, e As EventArgs) Handles btnRect.Click
        If (radMulti.Checked = True) Then
            radMulti.Checked = False
        ElseIf (radSingle.Checked = True) Then
            radSingle.Checked = False
        End If
    End Sub
End Class