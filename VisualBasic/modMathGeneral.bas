
Public Function ComputeWindChillEnglish( _
  ByVal dblFarenheit As Double, _
  ByVal dblWindMPH As Double) _
  As Double
  ' Comments  : Calculate the wind chill for exposed human skin.
  ' Parameters: dblFarenheit - The temperature in degrees Fahrenheit
  '             dblWindMPH - The wind speed in Miles per Hour
  ' Returns   : The wind chill in degrees Fahrenheit
  ' Source    : Total VB SourceBook 6
  '
  On Error GoTo PROC_ERR

  If (dblWindMPH < 4) Then
    ComputeWindChillEnglish = dblFarenheit
  Else
    ' CDec function used to handle subtraction accuracy bug in VB
    ComputeWindChillEnglish = 0.0817 * (CDec(3.71 * Sqr(dblWindMPH) +
5.81) - _
      CDec(dblWindMPH / 4)) * (CDec(dblFarenheit) - CDec(91.4)) + 91.4
  End If

PROC_EXIT:
  Exit Function

PROC_ERR:
  MsgBox "Error: " & Err.Number & ". " & Err.Description, , _
    "ComputeWindChillEnglish"
  Resume PROC_EXIT

End Function

Public Function ComputeWindChillMetric( _
  ByVal dblCelsius As Double, _
  ByVal dblWindKPH As Double) _
  As Double
  ' Comments  : Calculate the wind chill for exposed human skin.
  ' Parameters: dblCelcius - The tempurature in degrees Celsius
  '             dblWindKPH - The wind speed in Kilometers per Hour
  ' Returns   : The wind chill in degrees Celsius
  ' Source    : Total VB SourceBook 6
  '
  On Error GoTo PROC_ERR

  If (dblWindKPH < 4) Then
    ComputeWindChillMetric = dblCelsius
  Else
    ' CDec function used to handle subtraction accuracy bug in VB
    ComputeWindChillMetric = 0.045 * (CDec(5.27 * Sqr(dblWindKPH) +
10.45) - _
      CDec(0.28 * dblWindKPH)) * (CDec(dblCelsius) - CDec(33)) + 33
  End If

PROC_EXIT:
  Exit Function

PROC_ERR:
  MsgBox "Error: " & Err.Number & ". " & Err.Description, , _
    "ComputeWindChillMetric"
  Resume PROC_EXIT

End Function

Public Function GetGCF(ByVal lngInX As Long, ByVal lngInY As Long) As Long
  ' Comments  : Returns the greatest common factor (largest number
  '             that evenly divides into two numbers)
  ' Parameters: lngInX - first value
  '             lngInY - second value
  ' Returns   : greatest common factor
  ' Source    : Total VB SourceBook 6
  '
  Dim lngTmp As Long
  Dim lngX As Long
  Dim lngY As Long
  
  On Error GoTo PROC_ERR

  lngX = lngInX
  lngY = lngInY

  lngX = Abs(lngX)
  lngY = Abs(lngY)

  lngTmp = lngX Mod lngY

  Do While lngTmp > 0
    lngX = lngY
    lngY = lngTmp
    lngTmp = lngX Mod lngY
  Loop

  GetGCF = lngY

PROC_EXIT:
  Exit Function
  
PROC_ERR:
  MsgBox "Error: " & Err.Number & ". " & Err.Description, , _
    "GetGCF"
  Resume PROC_EXIT

End Function

Public Function GetRandomInt( _
  lngLowRange As Long, _
  lngHighRange As Long) _
  As Long
  ' Comments  : Returns a random integer value between the
  '             range specified in the arguments, inclusive
  ' Parameters: lngLowRange - Lower bound of the range of integers
  '             lngHighRange - Upper bound of the range of integers
  ' Returns   : The random number
  ' Source    : Total VB SourceBook 6
  '
  Dim lngResult As Long
  
  On Error GoTo PROC_ERR
  
  ' change the random number generator "seed"
  Randomize Timer
  
  ' Scale the output of the rnd function so that it returns
  ' an integer in the correct range instead of a floating
  ' point value
  lngResult = _
    Int((lngHighRange - lngLowRange + 1) * Rnd + lngLowRange)
  
  GetRandomInt = lngResult
  
PROC_EXIT:
  Exit Function

PROC_ERR:
  MsgBox "Error: " & Err.Number & ". " & Err.Description, , _
    "GetRandomInt"
  Resume PROC_EXIT

End Function

Public Function IsNumberPrime(ByVal lngNumber As Long) As Boolean
  ' Comments  : Determines if a number is a prime number
  ' Parameters: lngNumber - number to check
  ' Returns   : True - number is prime, False - number is not prime
  ' Source    : Total VB SourceBook 6
  '
  Dim intCounter As Integer
  Dim lngTest As Long
  Dim fIsPrime As Boolean
  
  On Error GoTo PROC_ERR

  ' Convert to positive values only
  lngTest = Abs(lngNumber)          ' Convert to positive values only

  Select Case lngTest
    Case 0, 1
      fIsPrime = False
      
    Case 2
      fIsPrime = True
      
    Case Else
      If lngTest Mod 2 = 0 Then
        ' Divisible by 2
        fIsPrime = False
      Else
        ' Test if an odd number divides into the test value
        ' without a remainder
        fIsPrime = True
        For intCounter = 3 To Int(lngTest / 2) Step 2
          If lngTest Mod intCounter = 0 Then
            ' Number is not prime
            fIsPrime = False
            Exit For
          End If
        Next intCounter
      End If
  End Select

  IsNumberPrime = fIsPrime
  
PROC_EXIT:
  Exit Function
  
PROC_ERR:
  MsgBox "Error: " & Err.Number & ". " & Err.Description, , _
    "IsNumberPrime"
  Resume PROC_EXIT
  
End Function

Public Function MaxOfThree( _
  varValue1 As Variant, _
  varValue2 As Variant, _
  varValue3 As Variant) _
  As Variant
  ' Comments  : Returns the greater of three values (null values are ignored)
  ' Parameters: varValue1 - first value
  '             varValue2 - second value
  '             varValue3 - third value
  ' Returns   : Maximum value (null if all three input values are null)
  ' Source    : Total VB SourceBook 6
  '
  Dim varReturn As Variant

  On Error GoTo PROC_ERR
  
  If Not IsNull(varValue1) And _
    Not IsNull(varValue2) And _
    Not IsNull(varValue3) Then
    If varValue1 > varValue2 Then
      varReturn = IIf(varValue1 > varValue3, varValue1, varValue3)
    Else
      varReturn = IIf(varValue2 > varValue3, varValue2, varValue3)
    End If
  ElseIf IsNull(varValue1) And IsNull(varValue2) And IsNull(varValue3) Then
    varReturn = Null
    ' 1 is null, but 2 & 3 may or may not be null
  ElseIf IsNull(varValue1) Then
    If IsNull(varValue2) Then
      varReturn = varValue3
    ElseIf IsNull(varValue3) Then
      varReturn = varValue2
    Else
      varReturn = IIf(varValue2 > varValue3, varValue2, varValue3)
    End If
  ElseIf IsNull(varValue2) Then
    ' 1 is not null
    If IsNull(varValue3) Then
      varReturn = varValue1
    Else
      varReturn = IIf(varValue1 > varValue3, varValue1, varValue3)
    End If
  ' 1 and 2 are not null
  ElseIf IsNull(varValue3) Then
    varReturn = IIf(varValue1 > varValue2, varValue1, varValue2)
  End If

  MaxOfThree = varReturn

PROC_EXIT:
  Exit Function
  
PROC_ERR:
  MsgBox "Error: " & Err.Number & ". " & Err.Description, , _
    "MaxOfThree"
  Resume PROC_EXIT
  
End Function

Public Function MaxOfTwo(varValue1 As Variant, varValue2 As Variant) As Variant
  ' Comments  : returns the greater of two values (null values are ignored)
  ' Parameters: varValue1 - first value
  '             varValue2 - second value
  ' Returns   : Maximum value (null if both input values are null)
  ' Source    : Total VB SourceBook 6
  '
  Dim varReturn As Variant

  On Error GoTo PROC_ERR
  
  If Not IsNull(varValue1) And Not IsNull(varValue2) Then
    varReturn = IIf(varValue1 > varValue2, varValue1, varValue2)
  ElseIf IsNull(varValue1) Then
    If IsNull(varValue2) Then
      varReturn = Null
    Else
      varReturn = varValue2
    End If
  ElseIf IsNull(varValue2) Then
    varReturn = varValue1
  End If

  MaxOfTwo = varReturn

PROC_EXIT:
  Exit Function
  
PROC_ERR:
  MsgBox "Error: " & Err.Number & ". " & Err.Description, , _
    "MaxOfTwo"
  Resume PROC_EXIT
  
End Function

Public Function MinOfThree( _
  varValue1 As Variant, _
  varValue2 As Variant, _
  varValue3 As Variant) _
  As Variant
  ' Comments  : Returns the smallest of three values (null values
  '             are ignored)
  ' Parameters: varValue1 - first value
  '             varValue2 - second value
  '             varValue3 - third value
  ' Returns   : Minimum value (null if all three input values are null)
  ' Source    : Total VB SourceBook 6
  '
  Dim varReturn As Variant

  On Error GoTo PROC_ERR
  
  If Not IsNull(varValue1) And _
    Not IsNull(varValue2) And _
    Not IsNull(varValue3) Then
    If varValue1 < varValue2 Then
      varReturn = IIf(varValue1 < varValue3, varValue1, varValue3)
    Else
      varReturn = IIf(varValue2 < varValue3, varValue2, varValue3)
    End If
  ElseIf IsNull(varValue1) And IsNull(varValue2) And IsNull(varValue3) Then
    varReturn = Null
    ' 1 is null, but 2 & 3 may or may not be null
  ElseIf IsNull(varValue1) Then
    If IsNull(varValue2) Then
      varReturn = varValue3
    ElseIf IsNull(varValue3) Then
      varReturn = varValue2
    Else
      varReturn = IIf(varValue2 < varValue3, varValue2, varValue3)
    End If
  ElseIf IsNull(varValue2) Then
    ' 1 is not null
    If IsNull(varValue3) Then
      varReturn = varValue1
    Else
      varReturn = IIf(varValue1 < varValue3, varValue1, varValue3)
    End If
  ElseIf IsNull(varValue3) Then
    ' 1 and 2 are not null
    varReturn = IIf(varValue1 < varValue2, varValue1, varValue2)
  End If

  MinOfThree = varReturn

PROC_EXIT:
  Exit Function
  
PROC_ERR:
  MsgBox "Error: " & Err.Number & ". " & Err.Description, , _
    "MinOfThree"
  Resume PROC_EXIT
  
End Function

Public Function MinOfTwo(varValue1 As Variant, varValue2 As Variant) As Variant
  ' Comments  : Returns the lesser of two values (null values are ignored)
  ' Parameters: varValue1 - first value
  '             varValue2 - second value
  ' Returns   : Minimum value (null if both input values are null)
  ' Source    : Total VB SourceBook 6
  '
  Dim varReturn As Variant

  On Error GoTo PROC_ERR
  
  If Not IsNull(varValue1) And Not IsNull(varValue2) Then
    varReturn = IIf(varValue1 < varValue2, varValue1, varValue2)
  ElseIf IsNull(varValue1) Then
    If IsNull(varValue2) Then
      varReturn = Null
    Else
      varReturn = varValue2
    End If
  ElseIf IsNull(varValue2) Then
    varReturn = varValue1
  End If

  MinOfTwo = varReturn

PROC_EXIT:
  Exit Function
  
PROC_ERR:
  MsgBox "Error: " & Err.Number & ". " & Err.Description, , _
    "MinOfTwo"
  Resume PROC_EXIT
  
End Function

Public Sub PrimeFactors(ByVal lngNumber As Long, alngNumbers() As Long)
  ' Comments  : This procedure calculates the prime factors of a number
  ' Parameters: lngNumber - The number to compute the prime factors for
  '             alngNumbers - An array of numbers containing the prime
  '             factors. This array is modified by the procedure.
  ' Returns   : Nothing
  ' Source    : Total VB SourceBook 6
  '
  Dim lngDenominator As Long
  Dim intCount As Integer
  Dim intCounter As Long
  Dim lngTempNumber As Long
  
  On Error GoTo PROC_ERR
  
  ' Reserve space for one number
  ReDim Preserve alngNumbers(0)
  
  lngTempNumber = lngNumber
  
  ' If the number is less than two, then it cannot be factored
  If (lngTempNumber < 2) Then
    alngNumbers(0) = lngTempNumber
  ElseIf (lngTempNumber > 2) Then
    ' Factor the number
    lngDenominator = 2
    intCount = 0
    ' While the number is divisible by two
    Do While (lngTempNumber Mod lngDenominator) = 0
      lngTempNumber = lngTempNumber / lngDenominator
      intCount = intCount + 1
    Loop
    
    ' If the number was divided at least once, store the result
    If (intCount > 0) Then
      ' create space for the numbers
      ReDim Preserve alngNumbers(UBound(alngNumbers) + intCount)
      ' For each division
      For intCounter = 0 To intCount - 1
        ' Store the denomiator (in this case 2) in the array
        alngNumbers(UBound(alngNumbers) - intCounter) = lngDenominator
      Next intCounter
    End If
  
    lngDenominator = 3
    ' While the denominator is less than half the number
    Do While lngDenominator * 2 <= lngTempNumber
      intCount = 0
      ' While the number is evenly divisible by the denominator
      Do While (lngTempNumber Mod lngDenominator = 0)
        lngTempNumber = lngTempNumber / lngDenominator
        intCount = intCount + 1
      Loop
      
      ' If the number was divided at least once, store the result
      If intCount > 0 Then
        ' Create space for the numbers
        ReDim Preserve alngNumbers(UBound(alngNumbers) + intCount)
        ' For each division
        For intCounter = 0 To intCount - 1
          ' Store the denomiator in the array
          alngNumbers(UBound(alngNumbers) - intCounter) = _
            lngDenominator
        Next intCounter
      End If
      ' The denominator can only be odd at this point, so increment by two
      lngDenominator = lngDenominator + 2
    Loop
  End If
  
  If (lngTempNumber > 1) Then
    ' If something has been assigned to the array before, store the last value
    ' of the number. Otherwise it is a prime number
    If UBound(alngNumbers) > 0 Then
      ReDim Preserve alngNumbers(UBound(alngNumbers) + 1)
    End If
    alngNumbers(UBound(alngNumbers)) = lngTempNumber
  End If

PROC_EXIT:
  Exit Sub

PROC_ERR:
  MsgBox "Error: " & Err.Number & ". " & Err.Description, , _
    "PrimeFactors"
  Resume PROC_EXIT
      
End Sub

Public Function Round( _
  ByVal dblNumber As Double, _
  ByVal intDecimals As Integer) _
  As Double
  ' Comments  : This procedure is a placeholder for the obsolete
  '             Round function from Total VB SourceBook 5. Use
  '             the RoundExt function in Total VB SourceBook 6
  '             instead of Round.
  ' Parameters: dblNumber - not used
  '             intDecimals - not used
  ' Returns   : Nothing
  ' Source    : Total VB SourceBook 6
  '
  
End Function

Public Function RoundBankers( _
  ByVal dblNumber As Double, _
  ByVal intDecimals As Integer) _
  As Double
  ' Comments  : Banker's rounding to specified decimal places.
  '             Banker's Rounding rounds a 5 digit to the nearest even
  '             number. (eg. 100.045 goes to 100.04, and 100.055 goes
  '             to 100.06). Regular rounding always rounds *.5 up.
  ' Parameters: dblNumber - number to round
  '             intDecimals - number of decimals to round (2 for cents)
  '             (negative rounds to left of decimal)
  ' Returns   : Number rounded using banker's rounding
  ' Source    : Total VB SourceBook 6
  '
  Dim dblFactor As Double
  Dim dblRoundDown As Double
  Dim dblDiff As Double
  Dim dblResult As Double
  Dim dblTemp As Double 
  Dim dblCheck As Double
  Dim fIsOdd As Boolean
  
  On Error GoTo PROC_ERR

  dblFactor = 10 ^ intDecimals

  dblTemp = dblNumber * dblFactor
  dblCheck = Int(CDec(dblTemp))
  dblRoundDown = dblCheck / dblFactor
  fIsOdd = (((dblCheck / 2) - Int(dblCheck / 2)) > 0)

  dblDiff = CDec(dblNumber) - CDec(dblRoundDown)
  dblTemp = dblDiff * 10 * dblFactor + 0.5
  dblDiff = Int(CDec(dblTemp)) / (10 * dblFactor)

  dblResult = dblRoundDown
  
  ' If *.5, round to nearest even number:
  If (dblDiff = (0.5 / dblFactor)) And fIsOdd Then
    dblResult = dblRoundDown + 1 / dblFactor
  ElseIf dblDiff > (0.5 / dblFactor) Then
    dblResult = dblRoundDown + 1 / dblFactor
  End If

  RoundBankers = dblResult
  
PROC_EXIT:
  Exit Function
  
PROC_ERR:
  MsgBox "Error: " & Err.Number & ". " & Err.Description, , _
    "RoundBankers"
  Resume PROC_EXIT
  
End Function

Public Function RoundDown( _
  ByVal dblNumber As Double, _
  ByVal intRound As Integer) _
  As Double
  ' Comments  : Rounds the passed number to specified number of
  '             decimal places with 0.5 rounded down.
  ' Parameters: dblNumber - number to round
  '             intRound - number of digits to round to
  '             (positive for right of decimal, negative for left)
  ' Returns   : rounded number
  ' Source    : Total VB SourceBook 6
  '
  Dim dblFactor As Double
  Dim dblTemp As Double
  Dim dblRound As Double

  On Error GoTo PROC_ERR
  
  dblFactor = 10 ^ intRound

  dblTemp = dblNumber * dblFactor
  dblRound = Int(CDec(dblTemp)) / dblFactor

  ' Must use special subtraction function to prevent rounding
  ' errors with subtraction.
  If Subtract(dblNumber, dblRound) > 0.5 / dblFactor Then
    dblRound = dblRound + 1 / dblFactor
  End If

  RoundDown = dblRound
  
PROC_EXIT:
  Exit Function
  
PROC_ERR:
  MsgBox "Error: " & Err.Number & ". " & Err.Description, , _
    "RoundDown"
  Resume PROC_EXIT
  
End Function

Public Function RoundExt( _
  ByVal dblNumber As Double, _
  ByVal intDecimals As Integer) _
  As Double
  ' Comments  : Rounds a number to a specified number of decimal
  '             places (0.5 is rounded up). Unlike the VB 6 Round
  '             function, this one works correctly.
  ' Parameters: dblNumber - number to round
  '             intDecimals - number of decimal places to round to
  '             (positive for right of decimal, negative for left)
  ' Returns   : Rounded number
  ' Source    : Total VB SourceBook 6
  '
  Dim dblFactor As Double
  Dim dblTemp As Double 
  
  On Error GoTo PROC_ERR

  dblFactor = 10 ^ intDecimals
  dblTemp = dblNumber * dblFactor + 0.5
  RoundExt = Int(CDec(dblTemp)) / dblFactor

PROC_EXIT:
  Exit Function
  
PROC_ERR:
  MsgBox "Error: " & Err.Number & ". " & Err.Description, , _
    "RoundExt"
  Resume PROC_EXIT
  
End Function

Public Function ScalePercent(dblCurrent As Double, dblMax As Double) As Integer
  ' Comments  : Scales a value to a range between 0 and 100 (number could
  '             be less than 0 or greater than 100 if the 'current' value is
  '             less than 0 or greater than the 'max' value
  ' Parameters: dblCurrent - Value to test
  '             dblMax - The maximum value
  ' Returns   : An integer value scaled to a percentage
  ' Source    : Total VB SourceBook 6
  '
  On Error GoTo PROC_ERR

  ScalePercent = Int(100 * dblCurrent / dblMax)

PROC_EXIT:
  Exit Function

PROC_ERR:
  MsgBox "Error: " & Err.Number & ". " & Err.Description, , _
    "ScalePercent"
  Resume PROC_EXIT

End Function

Public Function Subtract(dblValue1 As Double, dblValue2 As Double) As Double
  ' Comments  : Subtract two numbers with decimals correctly
  '             In certain situations, VB does not subtract numbers
  '             with decimal places correctly.
  '             (eg. 100.8 - 100.7 = 0.099999999999943)
  '             This procedure corrects the problem by rounding the
  '             numbers correctly. The result cannot have more decimal
  '             places than the maximum of the inputs.
  ' Parameters: dblValue1 - first value
  '             dblValue2 - second value (subtracted from dblValue1)
  ' Returns   : Difference between two values (dblValue1 - dblValue2)
  ' Source    : Total VB SourceBook 6
  '
  
  On Error GoTo PROC_ERR
  
  Subtract = CDec(dblValue1) - CDec(dblValue2)

PROC_EXIT:
  Exit Function
  
PROC_ERR:
  MsgBox "Error: " & Err.Number & ". " & Err.Description, , _
    "Subtract"
  Resume PROC_EXIT
  
End Function

