
Public Function AreaOfCircle(ByVal dblRadius As Double) As Double
  ' Comments  : Returns the area of a circle
  ' Parameters: dblRadius - radius of circle
  ' Returns   : area (Double)
  ' Source    : Total VB SourceBook 6
  '
  Const PI = 3.14159265358979
  
  On Error GoTo PROC_ERR
    
  AreaOfCircle = PI * dblRadius ^ 2
  
PROC_EXIT:
  Exit Function
  
PROC_ERR:
  MsgBox "Error: " & Err.Number & ". " & Err.Description, , _
    "AreaOfCircle"
  Resume PROC_EXIT
  
End Function

Public Function AreaOfRectangle( _
  ByVal dblLength As Double, _
  ByVal dblWidth As Double) _
  As Double
  ' Comments  : Returns the area of a rectangle
  ' Parameters: dblLength - length of rectangle
  '             dblWidth  - width of rectangle
  ' Returns   : area
  ' Source    : Total VB SourceBook 6
  '
  On Error GoTo PROC_ERR
  
  AreaOfRectangle = dblLength * dblWidth
  
PROC_EXIT:
  Exit Function
  
PROC_ERR:
  MsgBox "Error: " & Err.Number & ". " & Err.Description, , _
    "AreaOfRectangle"
  Resume PROC_EXIT
  
End Function

Public Function AreaOfRing( _
  ByVal dblInnerRadius As Double, _
  ByVal dblOuterRadius As Double) _
  As Double
  ' Comments  : Returns the area of a ring
  ' Parameters: dblInnerRadius - inner radius of the ring
  '             dblOuterRadius - outer radius of the ring
  ' Returns   : area
  ' Source    : Total VB SourceBook 6
  '
  On Error GoTo PROC_ERR
  
  AreaOfRing = AreaOfCircle(dblOuterRadius) - _
    AreaOfCircle(dblInnerRadius)
    
PROC_EXIT:
  Exit Function
  
PROC_ERR:
  MsgBox "Error: " & Err.Number & ". " & Err.Description, , _
    "AreaOfRing"
  Resume PROC_EXIT
  
End Function

Public Function AreaOfSphere(ByVal dblRadius As Double) As Double
  ' Comments  : Returns the area of a sphere
  ' Parameters: dblRadius - radius of the sphere
  ' Returns   : area
  ' Source    : Total VB SourceBook 6
  '
  Const cdblPI As Double = 3.14159265358979

  On Error GoTo PROC_ERR

  AreaOfSphere = 4 * cdblPI * dblRadius ^ 2
  
PROC_EXIT:
  Exit Function
  
PROC_ERR:
  MsgBox "Error: " & Err.Number & ". " & Err.Description, , _
    "AreaOfSphere"
  Resume PROC_EXIT
  
End Function

Public Function AreaOfSquare(ByVal dblSide As Double) As Double
  ' Comments  : Returns the area of a square
  ' Parameters: dblSide - length of a side of the square
  ' Returns   : area
  ' Source    : Total VB SourceBook 6
  '
  On Error GoTo PROC_ERR
  
  AreaOfSquare = dblSide ^ 2
  
PROC_EXIT:
  Exit Function
  
PROC_ERR:
  MsgBox "Error: " & Err.Number & ". " & Err.Description, , _
    "AreaOfSquare"
  Resume PROC_EXIT
  
End Function

Public Function AreaOfSquareDiag(ByVal dblDiag As Double) As Double
  ' Comments  : Returns the area of a square
  ' Parameters: dblDiag - length of the square's diagonal
  ' Returns   : area
  ' Source    : Total VB SourceBook 6
  '
  On Error GoTo PROC_ERR
  
  AreaOfSquareDiag = (dblDiag ^ 2) / 2
  
PROC_EXIT:
  Exit Function
  
PROC_ERR:
  MsgBox "Error: " & Err.Number & ". " & Err.Description, , _
    "AreaOfSquareDiag"
  Resume PROC_EXIT
  
End Function

Public Function AreaOfTrapezoid( _
  ByVal dblHeight As Double, _
  ByVal dblLength1 As Double, _
  ByVal dblLength2 As Double) _
  As Double
  ' Comments  : Returns the area of a trapezoid
  ' Parameters: dblHeight - height
  '             dblLength1 - length of first side
  '             dblLength2 - length of second side
  ' Returns   : area
  ' Source    : Total VB SourceBook 6
  '
  On Error GoTo PROC_ERR
  
  AreaOfTrapezoid = dblHeight * (dblLength1 + dblLength2) / 2
  
PROC_EXIT:
  Exit Function
  
PROC_ERR:
  MsgBox "Error: " & Err.Number & ". " & Err.Description, , _
    "AreaOfTrapezoid"
  Resume PROC_EXIT
  
End Function

Public Function AreaOfTriangle( _
  ByVal dblLength As Double, _
  ByVal dblHeight As Double) _
  As Double
  ' Comments  : returns the area of a triangle
  ' Parameters: dblLength - length of a side
  '             dblHeight - perpendicular height
  ' Returns   : area
  ' Source    : Total VB SourceBook 6
  '
  On Error GoTo PROC_ERR
  
  AreaOfTriangle = dblLength * dblHeight / 2
  
PROC_EXIT:
  Exit Function
  
PROC_ERR:
  MsgBox "Error: " & Err.Number & ". " & Err.Description, , _
    "AreaOfTriangle"
  Resume PROC_EXIT
  
End Function

Public Function AreaOfTriangle2( _
  ByVal dblSideA As Double, _
  ByVal dblSideB As Double, _
  ByVal dblSideC As Double) As Double
  ' Comments  : Returns the area of a triangle
  ' Parameters: dblSideA - length of first side
  '             dblSideB - length of second side
  '             dblSideC - length of third side
  ' Returns   : area
  ' Source    : Total VB SourceBook 6
  '
  Dim dblCosine As Double
  
  On Error GoTo PROC_ERR
  
  dblCosine = (dblSideA + dblSideB + dblSideC) / 2
  
  AreaOfTriangle2 = Sqr(dblCosine * (dblCosine - dblSideA) * _
    (dblCosine - dblSideB) * _
    (dblCosine - dblSideC))
    
PROC_EXIT:
  Exit Function
  
PROC_ERR:
  MsgBox "Error: " & Err.Number & ". " & Err.Description, , _
    "AreaOfTriangle2"
  Resume PROC_EXIT
  
End Function

Public Function LenOfRectangleDiagonal( _
  ByVal dblLength As Double, _
  ByVal dblWidth As Double) _
  As Double
  ' Comments  : Returns the length of the diagonal of a rectangle
  ' Parameters: dblLength - length of rectangle
  '             dblWidth - width of rectangle
  ' Returns   : Length of diagonal
  ' Source    : Total VB SourceBook 6
  '
  On Error GoTo PROC_ERR
  
  LenOfRectangleDiagonal = Sqr(dblWidth ^ 2 + dblLength ^ 2)
  
PROC_EXIT:
  Exit Function
  
PROC_ERR:
  MsgBox "Error: " & Err.Number & ". " & Err.Description, , _
    "LenOfRectangleDiagonal"
  Resume PROC_EXIT
  
End Function

Public Function LenOfSquareDiagonal(ByVal dblLength As Double) As Double
  ' Comments  : Returns the length of the diagonal of a square
  ' Parameters: dblLength - length of square
  ' Returns   : length of diagonal
  ' Source    : Total VB SourceBook 6
  '
  On Error GoTo PROC_ERR
  
  LenOfSquareDiagonal = dblLength * Sqr(2)
  
PROC_EXIT:
  Exit Function
  
PROC_ERR:
  MsgBox "Error: " & Err.Number & ". " & Err.Description, , _
    "LenOfSquareDiagonal"
  Resume PROC_EXIT
  
End Function

Public Function VolOfCone( _
  ByVal dblHeight As Double, _
  ByVal dblRadius As Double) _
  As Double
  ' Comments  : Returns the volume of a cone
  ' Parameters: dblHeight - height of cone
  '             dblRadius - radius of cone base
  ' Returns   : volume
  ' Source    : Total VB SourceBook 6
  '
  Const cdblPI As Double = 3.14159265358979

  On Error GoTo PROC_ERR

  VolOfCone = dblHeight * (dblRadius ^ 2) * cdblPI / 3
  
PROC_EXIT:
  Exit Function
  
PROC_ERR:
  MsgBox "Error: " & Err.Number & ". " & Err.Description, , _
    "VolOfCone"
  Resume PROC_EXIT
  
End Function

Public Function VolOfCylinder( _
  ByVal dblHeight As Double, _
  ByVal dblRadius As Double) As Double
  ' Comments  : Returns the volume of a cylinder
  ' Parameters: dblHeight - height of cylinder
  '             dblRadius - radius of cylinder
  ' Returns   : volume
  ' Source    : Total VB SourceBook 6
  '
  Const cdblPI As Double = 3.14159265358979
  
  On Error GoTo PROC_ERR

  VolOfCylinder = cdblPI * dblHeight * dblRadius ^ 2
  
PROC_EXIT:
  Exit Function
  
PROC_ERR:
  MsgBox "Error: " & Err.Number & ". " & Err.Description, , _
    "VolOfCylinder"
  Resume PROC_EXIT
  
End Function

Public Function VolOfPipe( _
  ByVal dblHeight As Double, _
  ByVal dblOuterRadius As Double, _
  ByVal dblInnerRadius As Double) _
  As Double
  ' Comments  : Returns the volume of a pipe
  ' Parameters: dblHeight - height of pipe
  '             dblOuterRadius - outer radius of pipe
  '             dblInnerRadius - inner radius of pipe
  ' Returns   : volume
  ' Source    : Total VB SourceBook 6
  '
  On Error GoTo PROC_ERR
  
  VolOfPipe = VolOfCylinder(dblHeight, dblOuterRadius) - _
    VolOfCylinder(dblHeight, dblInnerRadius)
  
PROC_EXIT:
  Exit Function
  
PROC_ERR:
  MsgBox "Error: " & Err.Number & ". " & Err.Description, , _
    "VolOfPipe"
  Resume PROC_EXIT
  
End Function

Public Function VolOfPyramid( _
  ByVal dblHeight As Double, _
  ByVal dblBaseArea As Double) As Double
  ' Comments  : Returns the volume of a pyramid or cone
  ' Parameters: dblHeight - height of pyramid
  '             dblBaseArea - area of the base
  ' Returns   : volume
  ' Source    : Total VB SourceBook 6
  '
  On Error GoTo PROC_ERR
  
  VolOfPyramid = dblHeight * dblBaseArea / 3
  
PROC_EXIT:
  Exit Function
  
PROC_ERR:
  MsgBox "Error: " & Err.Number & ". " & Err.Description, , _
    "VolOfPyramid"
  Resume PROC_EXIT
  
End Function

Public Function VolOfSphere(ByVal dblRadius As Double) As Double
  ' Comments  : Returns the volume of a sphere
  ' Parameters: dblRadius  - radius of the sphere
  ' Returns   : volume
  ' Source    : Total VB SourceBook 6
  '
  Const cdblPI As Double = 3.14159265358979

  On Error GoTo PROC_ERR

  VolOfSphere = cdblPI * (dblRadius ^ 3) * 4 / 3
  
PROC_EXIT:
  Exit Function
  
PROC_ERR:
  MsgBox "Error: " & Err.Number & ". " & Err.Description, , _
    "VolOfSphere"
  Resume PROC_EXIT
  
End Function

Public Function VolOfTruncPyramid( _
  ByVal dblHeight As Double, _
  ByVal dblArea1 As Double, _
  ByVal dblArea2 As Double) _
  As Double
  ' Comments  : Returns the volume of a truncated pyramid
  ' Parameters: dblHeight - height of pyramid
  '             dblArea1 - area of base
  '             dblArea2 - area of top
  ' Returns   : volume
  ' Source    : Total VB SourceBook 6
  '
  On Error GoTo PROC_ERR
  
  VolOfTruncPyramid = dblHeight * (dblArea1 + dblArea2 + Sqr(dblArea1) * _
    Sqr(dblArea2)) / 3
  
PROC_EXIT:
  Exit Function
  
PROC_ERR:
  MsgBox "Error: " & Err.Number & ". " & Err.Description, , _
    "VolOfTruncPyramid"
  Resume PROC_EXIT
  
End Function

