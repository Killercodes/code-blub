
Public Function ArcCoSecant(ByVal dblIn As Double) As Double
  ' Comments  : Returns the inverse cosecant of the supplied number
  ' Parameters: dblIn - Value to calculate
  ' Returns   : Inverse cosecant as a double
  ' Source    : Total VB SourceBook 6
  '
  Const cdblPI As Double = 3.14159265358979
  
  On Error GoTo PROC_ERR
  
  ArcCoSecant = Atn(dblIn / Sqr(dblIn * dblIn - 1)) + _
    (Sgn(dblIn) - 1) * cdblPI / 2

PROC_EXIT:
  Exit Function
  
PROC_ERR:
  MsgBox "Error: " & Err.Number & ". " & Err.Description, , _
    "ArcCoSecant"
  Resume PROC_EXIT
  
End Function

Public Function ArcCosine(ByVal dblIn As Double) As Double
  ' Comments  : Returns the arc cosine of the supplied number
  ' Parameters: dblIn - Number to run on
  ' Returns   : Arc cosine  as a double
  ' Source    : Total VB SourceBook 6
  '
  Const cdblPI As Double = 3.14159265358979
  
  On Error GoTo PROC_ERR

  Select Case dblIn
    Case 1
      ArcCosine = 0
      
    Case -1
      ArcCosine = -cdblPI
      
    Case Else
      ArcCosine = Atn(dblIn / Sqr(-dblIn * dblIn + 1)) + cdblPI / 2
      
  End Select
  
PROC_EXIT:
  Exit Function
  
PROC_ERR:
  MsgBox "Error: " & Err.Number & ". " & Err.Description, , _
    "ArcCosine"
  Resume PROC_EXIT
  
End Function

Public Function ArcCotangent(ByVal dblIn As Double) As Double
  ' Comments  : Returns the inverse cotangent of the supplied number
  ' Parameters: dblIn - Value to calculate
  ' Returns   : Inverse cotangent  as a double
  ' Source    : Total VB SourceBook 6
  '
  Const cdblPI As Double = 3.14159265358979
  
  On Error GoTo PROC_ERR

  ArcCotangent = Atn(dblIn) + cdblPI / 2
  
PROC_EXIT:
  Exit Function
  
PROC_ERR:
  MsgBox "Error: " & Err.Number & ". " & Err.Description, , _
    "ArcCotangent"
  Resume PROC_EXIT
  
End Function

Public Function ArcSecant(ByVal dblIn As Double) As Double
  ' Comments  : Returns the inverse secant of the supplied number
  ' Parameters: dblIn - Value to calculate
  ' Returns   : Inverse secant  as a double
  ' Source    : Total VB SourceBook 6
  '
  Const cdblPI As Double = 3.14159265358979
  
  On Error GoTo PROC_ERR

  ArcSecant = Atn(dblIn / Sqr(dblIn * dblIn - 1)) + _
    Sgn(Sgn(dblIn) - 1) * cdblPI / 2

PROC_EXIT:
  Exit Function
  
PROC_ERR:
  MsgBox "Error: " & Err.Number & ". " & Err.Description, , _
    "ArcSecant"
  Resume PROC_EXIT
  
End Function

Public Function ArcSine(ByVal dblIn As Double) As Double
  ' Comments  : Returns the inverse sine of the supplied number
  ' Parameters: dblIn - Value to calculate
  ' Returns   : Inverse sine  as a double
  ' Source    : Total VB SourceBook 6
  '
  Const cdblPI As Double = 3.14159265358979
  
  On Error GoTo PROC_ERR

  Select Case dblIn
  
    Case 1
      ArcSine = cdblPI / 2
      
    Case -1
      ArcSine = -cdblPI / 2
    
    Case Else
      ArcSine = Atn(dblIn / Sqr(-dblIn ^ 2 + 1))
      
  End Select

PROC_EXIT:
  Exit Function
  
PROC_ERR:
  MsgBox "Error: " & Err.Number & ". " & Err.Description, , _
    "ArcSine"
  Resume PROC_EXIT
  
End Function

Public Function ArcTangent( _
  ByVal dblIn As Double, _
  ByVal dblIn2 As Double) _
  As Double
  ' Comments  : Returns the inverse tangent of the supplied numbers.
  '             Note that both values cannot be zero.
  ' Parameters: dblIn  - First value
  '             dblIn2 - Second value
  ' Returns   : Inverse tangent as a double
  ' Source    : Total VB SourceBook 6
  '
  Const cdblPI As Double = 3.14159265358979
  
  On Error GoTo PROC_ERR

  Select Case dblIn
    
    Case 0
    
      Select Case dblIn2
        Case 0
          ' Undefined
          ArcTangent = Null
        Case Is > 0
          ArcTangent = cdblPI / 2
        Case Else
          ArcTangent = -cdblPI / 2
      End Select
      
    Case Is > 0
      If dblIn2 = 0 Then
        ArcTangent = 0
      Else
        ArcTangent = Atn(dblIn2 / dblIn)
      End If
    Case Else
      If dblIn2 = 0 Then
        ArcTangent = cdblPI
      Else
        ArcTangent = (cdblPI - Atn(Abs(dblIn2 / dblIn))) * Sgn(dblIn2)
      End If
  End Select

PROC_EXIT:
  Exit Function
  
PROC_ERR:
  MsgBox "Error: " & Err.Number & ". " & Err.Description, , _
    "ArcTangent"
  Resume PROC_EXIT
  
End Function

Public Function CoSecant(ByVal dblIn As Double) As Double
  ' Comments  : Returns the CoSecant of the supplied number.
  '             Note that sin(dblIn) cannot equal zero.  This can
  '             happen if dblIn is a multiple of cdblPI.
  ' Parameters: dblIn - Value to calculate
  ' Returns   : CoSecant as a double
  ' Source    : Total VB SourceBook 6
  '
  On Error GoTo PROC_ERR
  
  If Sin(dblIn) = 0 Then
    CoSecant = Null
  Else
    CoSecant = 1 / Sin(dblIn)
  End If
  
PROC_EXIT:
  Exit Function
  
PROC_ERR:
  MsgBox "Error: " & Err.Number & ". " & Err.Description, , _
    "CoSecant"
  Resume PROC_EXIT

End Function

Public Function Cotangent(ByVal dblIn As Double) As Double
  ' Comments  : Returns the Cotangent of the supplied number
  '             Function is undefined if input value is a multiple of cdblPI.
  ' Parameters: dblIn - Value to calculate
  ' Returns   : Cotangent as a double
  ' Source    : Total VB SourceBook 6
  '
  On Error GoTo PROC_ERR
  
  If Tan(dblIn) = 0 Then
    Cotangent = Null
  Else
    Cotangent = 1 / Tan(dblIn)
  End If
  
PROC_EXIT:
  Exit Function
  
PROC_ERR:
  MsgBox "Error: " & Err.Number & ". " & Err.Description, , _
    "Cotangent"
  Resume PROC_EXIT
  
End Function

Public Function HyperbolicArcCosecant(ByVal dblIn As Double) As Double
  ' Comments  : Returns the Inverse Hyperbolic Cosecant of the
  '             supplied number
  ' Parameters: dblIn - Value to calculate
  ' Returns   : Hyperbolic inverse cosecant as a double
  ' Source    : Total VB SourceBook 6
  '
  On Error GoTo PROC_ERR
  
  HyperbolicArcCosecant = Log((Sgn(dblIn) * _
    Sqr(dblIn * dblIn + 1) + 1) / dblIn)

PROC_EXIT:
  Exit Function
  
PROC_ERR:
  MsgBox "Error: " & Err.Number & ". " & Err.Description, , _
    "HyperbolicArcCosecant"
  Resume PROC_EXIT
  
End Function

Public Function HyperbolicArcCosine(ByVal dblIn As Double) As Double
  ' Comments  : Returns the Inverse Hyperbolic Cosine of the
  '             supplied number
  ' Parameters: dblIn - Value to calculate
  ' Returns   : Inverse hyperbolic cosine as a double
  ' Source    : Total VB SourceBook 6
  '
  On Error GoTo PROC_ERR
  
  HyperbolicArcCosine = Log(dblIn + Sqr(dblIn * dblIn - 1))

PROC_EXIT:
  Exit Function
  
PROC_ERR:
  MsgBox "Error: " & Err.Number & ". " & Err.Description, , _
    "HyperbolicArcCosine"
  Resume PROC_EXIT
  
End Function

Public Function HyperbolicArcCotangent(ByVal dblIn As Double) As Double
  ' Comments  : Returns the Inverse Hyperbolic Tangent of the
  '             supplied number. Undefined if dblIn is 1
  ' Parameters: dblIn - Value to calculate
  ' Returns   : Inverse hyperbolic tangent as a double
  ' Source    : Total VB SourceBook 6
  '
  On Error GoTo PROC_ERR
  
  HyperbolicArcCotangent = Log((dblIn + 1) / (dblIn - 1)) / 2

PROC_EXIT:
  Exit Function
  
PROC_ERR:
  MsgBox "Error: " & Err.Number & ". " & Err.Description, , _
    "HyperbolicArcCotangent"
  Resume PROC_EXIT
  
End Function

Public Function HyperbolicArcSecant(ByVal dblIn As Double) As Double
  ' Comments  : Returns the Inverse Hyperbolic Secant of the
  '             supplied number
  ' Parameters: dblIn - Value to calculate
  ' Returns   : Inverse hyperbolic secant as a double
  ' Source    : Total VB SourceBook 6
  '
  On Error GoTo PROC_ERR
  
  HyperbolicArcSecant = Log((Sqr(-dblIn ^ 2 + 1) + 1) / dblIn)

PROC_EXIT:
  Exit Function
  
PROC_ERR:
  MsgBox "Error: " & Err.Number & ". " & Err.Description, , _
    "HyperbolicArcSecant"
  Resume PROC_EXIT
  
End Function

Public Function HyperbolicArcSine(ByVal dblIn As Double) As Double
  ' Comments  : Returns the Inverse Hyperbolic Sine of the supplied number
  ' Parameters: dblIn - Value to calculate
  ' Returns   : Inverse hyperbolic sine  as a double
  ' Source    : Total VB SourceBook 6
  '
  On Error GoTo PROC_ERR
  
  HyperbolicArcSine = Log(dblIn + Sqr(dblIn ^ 2 + 1))

PROC_EXIT:
  Exit Function
  
PROC_ERR:
  MsgBox "Error: " & Err.Number & ". " & Err.Description, , _
    "HyperbolicArcSine"
  Resume PROC_EXIT
  
End Function

Public Function HyperbolicArctan(ByVal dblIn As Double) As Double
  ' Comments  : Returns the Inverse Hyperbolic Tangent of the
  '             supplied number. The return value is undefined if
  '             input value is 1.
  ' Parameters: dblIn - Value to calculate
  ' Returns   : Inverse hyperbolic tangent as a double
  ' Source    : Total VB SourceBook 6
  '
  HyperbolicArctan = Log((1 + dblIn) / (1 - dblIn)) / 2

PROC_EXIT:
  Exit Function
  
PROC_ERR:
  MsgBox "Error: " & Err.Number & ". " & Err.Description, , _
    "HyperbolicArctan"
  Resume PROC_EXIT
  
End Function

Public Function HyperbolicCosecant(ByVal dblIn As Double) As Double
  ' Comments  : Returns the Hyperbolic Cosecant of the supplied number
  ' Parameters: dblIn - Value to calculate
  ' Returns   : Hyperbolic cosecant as a double
  ' Source    : Total VB SourceBook 6
  '
  On Error GoTo PROC_ERR
  
  HyperbolicCosecant = 2 / (Exp(dblIn) - Exp(-dblIn))

PROC_EXIT:
  Exit Function
  
PROC_ERR:
  MsgBox "Error: " & Err.Number & ". " & Err.Description, , _
    "HyperbolicCosecant"
  Resume PROC_EXIT
  
End Function

Public Function HyperbolicCosine(ByVal dblIn As Double) As Double
  ' Comments  : Returns the Hyperbolic Cosine of the supplied number
  ' Parameters: dblIn - Value to calculate
  ' Returns   : Hyperbolic cosine as a double
  ' Source    : Total VB SourceBook 6
  '
  On Error GoTo PROC_ERR
  
  HyperbolicCosine = (Exp(dblIn) + Exp(-dblIn)) / 2

PROC_EXIT:
  Exit Function
  
PROC_ERR:
  MsgBox "Error: " & Err.Number & ". " & Err.Description, , _
    "HyperbolicCosine"
  Resume PROC_EXIT
  
End Function

Public Function HyperbolicCotangent(ByVal dblIn As Double) As Double
  ' Comments  : Returns the Hyperbolic CoTangent of the supplied number
  ' Parameters: dblIn - Value to calculate
  ' Returns   : Hyperbolic cotangent as a double
  ' Source    : Total VB SourceBook 6
  '
  On Error GoTo PROC_ERR
  
  HyperbolicCotangent = (Exp(dblIn) + Exp(-dblIn)) / _
    (Exp(dblIn) - Exp(-dblIn))

PROC_EXIT:
  Exit Function
  
PROC_ERR:
  MsgBox "Error: " & Err.Number & ". " & Err.Description, , _
    "HyperbolicCotangent"
  Resume PROC_EXIT
  
End Function

Public Function HyperbolicSecant(ByVal dblIn As Double) As Double
  ' Comments  : Returns the Hyperbolic Secant of the supplied number
  ' Parameters: dblIn - Value to calculate
  ' Returns   : Hyperbolic Secant as a double
  ' Source    : Total VB SourceBook 6
  '
  On Error GoTo PROC_ERR
  
  HyperbolicSecant = 2 / (Exp(dblIn) + Exp(-dblIn))

PROC_EXIT:
  Exit Function
  
PROC_ERR:
  MsgBox "Error: " & Err.Number & ". " & Err.Description, , _
    "HyperbolicSecant"
  Resume PROC_EXIT
  
End Function

Public Function HyperbolicSine(ByVal dblIn As Double) As Double
  ' Comments  : Returns the Hyperbolic Sine of the supplied number
  ' Parameters: dblIn - Value to calculate
  ' Returns   : Hyperbolic sine as a double
  ' Source    : Total VB SourceBook 6
  '
  On Error GoTo PROC_ERR
  
  HyperbolicSine = (Exp(dblIn) - Exp(-dblIn)) / 2

PROC_EXIT:
  Exit Function
  
PROC_ERR:
  MsgBox "Error: " & Err.Number & ". " & Err.Description, , _
    "HyperbolicSine"
  Resume PROC_EXIT
  
End Function

Public Function HyperbolicTangent(ByVal dblIn As Double) As Double
  ' Comments  : Returns the Hyperbolic Tangent of the supplied number
  ' Parameters: dblIn - Value to calculate
  ' Returns   : Hyperbolic Tangent as a double
  ' Source    : Total VB SourceBook 6
  '
  On Error GoTo PROC_ERR
  
  HyperbolicTangent = (Exp(dblIn) - Exp(-dblIn)) / _
    (Exp(dblIn) + Exp(-dblIn))
  
PROC_EXIT:
  Exit Function
  
PROC_ERR:
  MsgBox "Error: " & Err.Number & ". " & Err.Description, , _
    "HyperbolicTangent"
  Resume PROC_EXIT
  
End Function

Public Function Log10(ByVal dblDecimal As Double) As Double
  ' Comments  : Returns log base 10. The power 10 must be raised
  '             to equal a given number.
  '             Log Base 10 is defined as this:
  '                x = log(y) where y = 10 ^ x
  ' Parameters: dblDecimal - value to calculate (y)
  ' Returns   : Log Base 10 of the given value
  ' Source    : Total VB SourceBook 6
  '
  On Error GoTo PROC_ERR
  
  Log10 = Log(dblDecimal) / Log(10)

PROC_EXIT:
  Exit Function
  
PROC_ERR:
  MsgBox "Error: " & Err.Number & ". " & Err.Description, , _
    "Log10"
  Resume PROC_EXIT
  
End Function

Public Function Log2(ByVal dblDecimal As Double) As Double
  ' Comments  : Returns log base 2. The power 2 must be raised to equal
  '             a given number.
  '             Log base 2 is defined as this:
  '                x = log(y) where y = 2 ^ x
  ' Parameters: dblDecimal - value to calculate (y)
  ' Returns   : Log Base 2 of a given number
  ' Source    : Total VB SourceBook 6
  '
  On Error GoTo PROC_ERR
  
  Log2 = Log(dblDecimal) / Log(2)

PROC_EXIT:
  Exit Function
  
PROC_ERR:
  MsgBox "Error: " & Err.Number & ". " & Err.Description, , _
    "Log2"
  Resume PROC_EXIT
  
End Function

Public Function LogN( _
  ByVal dblDecimal As Double, _
  ByVal dblBaseN As Double) _
  As Double
  ' Comments  : Returns log base N. The power N must be raised to equal
  '             a given number.
  '             Log base N is defined as this:
  '                x = log(y) where y = N ^ x
  ' Parameters: dblDecimal - value to calculate (y)
  '             dblBaseN - base
  ' Returns   : Log Base N of a given number
  ' Source    : Total VB SourceBook 6
  '
  On Error GoTo PROC_ERR
  
  LogN = Log(dblDecimal) / Log(dblBaseN)

PROC_EXIT:
  Exit Function
  
PROC_ERR:
  MsgBox "Error: " & Err.Number & ". " & Err.Description, , _
    "LogN"
  Resume PROC_EXIT
  
End Function

Public Function Secant(ByVal dblIn As Double) As Double
  ' Comments  : Returns the secant of the supplied number
  ' Parameters: dblIn - Value to calculate
  ' Returns   : Secant as a double
  ' Source    : Total VB SourceBook 6
  '
  On Error GoTo PROC_ERR
  
  Secant = 1 / Cos(Secant)

PROC_EXIT:
  Exit Function
  
PROC_ERR:
  MsgBox "Error: " & Err.Number & ". " & Err.Description, , _
    "Secant"
  Resume PROC_EXIT
  
End Function

