
Public Function Factorial(ByVal intIn As Integer) As Double
  ' Comments  : Returns the factorial of a given number
  ' Parameters: intIn - Value to get the factorial for (max = 170)
  ' Returns   : Factorial as a double
  ' Source    : Total VB SourceBook 6
  '
  Dim intCounter As Integer
  Dim dblTmp As Double

  On Error GoTo PROC_ERR
  
  If intIn < 0 Or intIn > 170 Then
    dblTmp = 0
  Else
    dblTmp = 1
    For intCounter = 2 To intIn
      dblTmp = dblTmp * intCounter
    Next intCounter
  End If

  Factorial = dblTmp

PROC_EXIT:
  Exit Function
  
PROC_ERR:
  MsgBox "Error: " & Err.Number & ". " & Err.Description, , _
    "Factorial"
  Resume PROC_EXIT

End Function

Public Function FactorialRecursive(ByVal intIn As Integer) As Double
  ' Comments  : Returns the recursive factorial of a given number
  ' Parameters: intIn - Value to get the factorial for (max = 170)
  ' Returns   : Factorial as a double
  ' Source    : Total VB SourceBook 6
  '
  On Error GoTo PROC_ERR
  
  If intIn < 0 Or intIn > 170 Then
    FactorialRecursive = 0
  Else
    If intIn = 0 Then
      FactorialRecursive = 1
    Else
      FactorialRecursive = intIn * FactorialRecursive(intIn - 1)
    End If
  End If

PROC_EXIT:
  Exit Function
  
PROC_ERR:
  MsgBox "Error: " & Err.Number & ". " & Err.Description, , _
    "FactorialRecursive"
  Resume PROC_EXIT
  
End Function

Public Function GetArrayMean(adblIn() As Double) As Double
  ' Comments  : Returns the mean of the elements in the supplied array
  ' Parameters: adblIn - Array of doubles
  ' Returns   : Mean as a double
  ' Source    : Total VB SourceBook 6
  '
  Dim intCounter As Integer
  Dim intN As Integer
  Dim dblSum As Double
  Dim dblMean As Double
  
  On Error GoTo PROC_ERR
  
  intN = 0
  
  For intCounter = LBound(adblIn) To UBound(adblIn)
    intN = intN + 1
    dblSum = dblSum + adblIn(intCounter)
  Next intCounter

  If intN > 0 Then
    dblMean = dblSum / intN
  Else
    dblMean = 0
  End If

  GetArrayMean = dblMean
  
PROC_EXIT:
  Exit Function
  
PROC_ERR:
  MsgBox "Error: " & Err.Number & ". " & Err.Description, , _
    "GetArrayMean"
  Resume PROC_EXIT
  
End Function

Public Function GetArrayMedian(adblIn() As Double, fSort As Boolean) As Double
  ' Comments  : Returns the median of the elements in the supplied array
  ' Parameters: adblIn - Array of double
  '             fSort - True to sort the array (faster)
  '                     False to sort a copy of the array
  '                     (does not modify the original array)
  ' Returns   : Median as a double
  ' Source    : Total VB SourceBook 6
  '
  Dim adblTmp() As Double
  Dim intCounter As Integer
  Dim dblMedian As Double
  Dim intElements As Integer
  Dim intIndex As Integer
  Dim fInterpolate As Boolean
  Dim dblTemp As Double
  
  On Error GoTo PROC_ERR

  intElements = UBound(adblIn) - LBound(adblIn) + 1
  If intElements = 1 Then
    dblMedian = adblIn(LBound(adblIn))
  Else
    dblTemp = (intElements + 1) / 2
    intIndex = Int(dblTemp)
    fInterpolate = (intElements Mod 2 = 0)
  
    If fSort Then
      ' Sort the array
      QuickSortStatArray adblIn(), LBound(adblIn), UBound(adblIn)
  
      ' Calculate the median (interpolate if necessary)
      If fInterpolate Then
        dblMedian = (adblIn(intIndex) + adblIn(intIndex + 1)) / 2
      Else
        dblMedian = adblIn(intIndex)
      End If
    Else
      ' Copy the array
      ReDim adblTmp(LBound(adblIn) To UBound(adblIn))
      For intCounter = LBound(adblIn) To UBound(adblIn)
        adblTmp(intCounter) = adblIn(intCounter)
      Next intCounter
  
      ' Sort the array
      QuickSortStatArray adblTmp(), LBound(adblIn), UBound(adblIn)
  
      ' Calculate the median (interpolate if necessary)
      If fInterpolate Then
        dblMedian = (adblTmp(intIndex) + adblTmp(intIndex + 1)) / 2
      Else
        dblMedian = adblTmp(intIndex)
      End If
    End If
  End If

  GetArrayMedian = dblMedian
  
PROC_EXIT:
  Exit Function
  
PROC_ERR:
  MsgBox "Error: " & Err.Number & ". " & Err.Description, , _
    "GetArrayMedian"
  Resume PROC_EXIT
  
End Function

Public Function GetArrayMode(adblIn() As Double, fSort As Boolean) As Double
  ' Comments  : Returns the mode (most common value) of the supplied array.
  '             If there is a tie, the smallest number is the mode.
  ' Parameters: adblIn - Array of numbers to analyze
  '             fSort - True to sort the array (faster)
  '                     False to sort a copy of the array
  '             (does not modify the original array)
  ' Returns   : Mode of the array as a double
  ' Source    : Total VB SourceBook 6
  '
  Dim intCounter As Integer
  Dim adblTmp() As Double
  Dim intModeCount As Integer
  Dim intCurrentCount As Integer
  Dim dblModeValue As Double
  Dim dblCurrentValue As Double
  Dim dblData As Double

  On Error GoTo PROC_ERR
  
  intModeCount = 0
  
  If fSort Then
    ' Sort the array
    QuickSortStatArray adblIn(), LBound(adblIn), UBound(adblIn)
    dblCurrentValue = adblIn(LBound(adblIn))
  Else
    ' Copy the array
    ReDim adblTmp(LBound(adblIn) To UBound(adblIn))
    For intCounter = LBound(adblIn) To UBound(adblIn)
      adblTmp(intCounter) = adblIn(intCounter)
    Next intCounter

    ' Sort the temporary array
    QuickSortStatArray adblTmp(), LBound(adblIn), UBound(adblIn)
    dblCurrentValue = adblTmp(LBound(adblIn))
  End If

  ' Calculate mode
  For intCounter = LBound(adblIn) To UBound(adblIn)
    If fSort Then
      dblData = adblIn(intCounter)
    Else
      dblData = adblTmp(intCounter)
    End If
    If dblData = dblCurrentValue Then
      intCurrentCount = intCurrentCount + 1
    Else
      If intCurrentCount > intModeCount Then
        dblModeValue = dblCurrentValue
        intModeCount = intCurrentCount
      End If
      intCurrentCount = 1
      dblCurrentValue = dblData
    End If
  Next intCounter
  If intCurrentCount > intModeCount Then
    dblModeValue = dblCurrentValue
    intModeCount = intCurrentCount
  End If

  GetArrayMode = dblModeValue

PROC_EXIT:
  Exit Function
  
PROC_ERR:
  MsgBox "Error: " & Err.Number & ". " & Err.Description, , _
    "GetArrayMode"
  Resume PROC_EXIT
  
End Function

Public Sub GetArrayStatistics( _
  adblIn() As Double, _
  lngN As Long, _
  dblMean As Double, _
  dblSumX As Double, _
  dblSumX2 As Double, _
  dblVar As Double, _
  dblStdDev As Double)
  ' Comments  : Calculates descriptive statistics of an array using
  '             N-1 method
  '             Values are set through the passes parameters
  ' Input     : adblIn - array of doubles to analyze
  ' Sets      : lngN       - number of non-null array elements
  '             dblMean    - mean of the array elements
  '             dblSumX    - sum of the array elements
  '             dblSumX2   - sum of the square of each array element
  '             dblVar     - variance of the array
  '             dblStdDev  - standard deviation of the array
  ' Returns   : Nothing
  ' Source    : Total VB SourceBook 6
  '
  Dim intCounter As Integer

  On Error GoTo PROC_ERR
  
  lngN = 0
  dblMean = 0
  dblSumX = 0
  dblSumX2 = 0
  
  For intCounter = LBound(adblIn) To UBound(adblIn)
    If Not IsNull(adblIn(intCounter)) Then
      lngN = lngN + 1
      dblSumX = dblSumX + adblIn(intCounter)
      dblSumX2 = dblSumX2 + adblIn(intCounter) ^ 2
    End If
  Next intCounter

  dblVar = 0
  dblStdDev = 0
  If lngN > 0 Then
    dblMean = dblSumX / lngN
    ' For N method, the "-1" is removed.
    dblVar = (lngN * dblSumX2 - dblSumX ^ 2) / (lngN * (lngN - 1))
    If dblVar > 0 Then
      dblStdDev = Sqr(dblVar)
      ' You can also calculate:
      '   Coefficient of Variance = dblStdDev * lngN / dblSumX
      '   (make sure dblSumX <> 0)
      '   Standard Error = dblStdDev / Sqr(lngN)
    End If
  End If

PROC_EXIT:
  Exit Sub
  
PROC_ERR:
  MsgBox "Error: " & Err.Number & ". " & Err.Description, , _
    "GetArrayStatistics"
  Resume PROC_EXIT
  
End Sub

Public Function GetArrayStdDev(adblIn() As Double) As Double
  ' Comments  : Returns the standard deviation of the supplied array
  '             using N-1 method
  ' Parameters: adblIn - Array of doubles
  ' Returns   : Standard deviation as a double
  ' Source    : Total VB SourceBook 6
  '
  Dim lngN As Long
  Dim dblMean As Double
  Dim dblSumX As Double
  Dim dblSumX2 As Double
  Dim dblVar As Double
  Dim dblStdDev As Double
  
  On Error GoTo PROC_ERR
  
  GetArrayStatistics adblIn(), _
    lngN, _
    dblMean, _
    dblSumX, _
    dblSumX2, _
    dblVar, _
    dblStdDev
  
  GetArrayStdDev = dblStdDev
  
PROC_EXIT:
  Exit Function
  
PROC_ERR:
  MsgBox "Error: " & Err.Number & ". " & Err.Description, , _
    "GetArrayStdDev"
  Resume PROC_EXIT
  
End Function

Public Function GetNumberCombinations( _
  ByVal intPool As Integer, _
  ByVal intItems As Integer) _
  As Double
  ' Comments   : Returns the number of combinations of items that can be
  '              derived from a population (order does not matter)
  ' Parameters : intPool - Pool (population)
  '              intItems - Items to pick
  ' Returns    : Number of combinations as a double
  ' Source    : Total VB SourceBook 6
  '
  On Error GoTo PROC_ERR
  
  GetNumberCombinations = (Factorial(intPool) / _
    Factorial(intItems)) / _
    Factorial(intPool - intItems)

PROC_EXIT:
  Exit Function
  
PROC_ERR:
  MsgBox "Error: " & Err.Number & ". " & Err.Description, , _
    "GetNumberCombinations"
  Resume PROC_EXIT
  
End Function

Public Function GetNumberPermutations( _
  ByVal intPool As Integer, _
  ByVal intItems As Integer) _
  As Double
  ' Comments   : Returns the number of combinations of intItems that
  '              can occur from intPool (order matters)
  ' Parameters : intPool - Pool (population)
  '              intItems - Number of items
  ' Returns    : Number of permutations as a double
  ' Source    : Total VB SourceBook 6
  '
  On Error GoTo PROC_ERR
  
  GetNumberPermutations = Factorial(intPool) / _
    Factorial(intPool - intItems)

PROC_EXIT:
  Exit Function
  
PROC_ERR:
  MsgBox "Error: " & Err.Number & ". " & Err.Description, , _
    "GetNumberPermutations"
  Resume PROC_EXIT
  
End Function

Public Function GetTableMedian( _
  strDatabase As String, _
  strTable As String, _
  strField As String) _
  As Double
  ' Comments  : Returns the median of the named field in the
  '             specified Jet database
  ' Parameters: strDatabase - Name of the database to look in
  '             strTable - Nname of the table to analyze
  '             strField - Name of the field to analyze
  ' Returns   : Median of the field as a double
  ' Source    : Total VB SourceBook 6
  '
  Dim dbsTemp As DAO.Database
  Dim rstTemp As DAO.Recordset
  Dim strSQL As String
  Dim lngElements As Long
  Dim lngIndex As Long
  Dim fInterpolate As Boolean
  Dim dblMedian As Double

  On Error GoTo PROC_ERR
  
  Set dbsTemp = DAO.DBEngine.Workspaces(0).OpenDatabase(strDatabase)

  strSQL = "SELECT DISTINCTROW [" & strField & "] " & _
            "FROM [" & strTable & "] " & _
            "WHERE ([" & strField & "] Is Not Null) " & _
            "ORDER BY [" & strField & "];"

  Set rstTemp = dbsTemp.OpenRecordset(strSQL)
  
  If Not rstTemp.EOF Then
    rstTemp.MoveLast
    lngElements = rstTemp.RecordCount
    If lngElements = 1 Then
      dblMedian = rstTemp(strField)
    Else
      lngIndex = Int((lngElements + 1) / 2)
      fInterpolate = (lngElements Mod 2 = 0)
      rstTemp.MoveFirst
      rstTemp.Move (lngIndex - 1)

      ' Calculate the median (interpolate if necessary)
      dblMedian = rstTemp(strField)
      If fInterpolate Then
        rstTemp.MoveNext
        dblMedian = (dblMedian + rstTemp(strField)) / 2
      End If
    End If
  Else
    dblMedian = 0
  End If
  
  rstTemp.Close
  dbsTemp.Close

  GetTableMedian = dblMedian

PROC_EXIT:
  Exit Function
  
PROC_ERR:
  MsgBox "Error: " & Err.Number & ". " & Err.Description, , _
    "GetTableMedian"
  Resume PROC_EXIT
  
End Function

Public Function GetTableMode( _
  strDatabase As String, _
  strTable As String, _
  strField As String) _
  As Double
  ' Comments  : Returns the mode (most common value) of the named field
  '             in the specified Jet database.
  ' Parameters: strDatabase - Name of the database to look in
  '             strTable - Name of the table to analyze
  '             strField - Nname of the field to analyze
  ' Returns   : Mode (if there are ties, the smallest value is the mode)
  ' Source    : Total VB SourceBook 6
  '
  Dim dbsTemp As DAO.Database
  Dim rstTemp As DAO.Recordset
  Dim strSQL As String
  Dim dblMode As Double

  On Error GoTo PROC_ERR
  
  Set dbsTemp = DAO.DBEngine.Workspaces(0).OpenDatabase(strDatabase)

  strSQL = "SELECT DISTINCTROW [" & strField & "] " & _
            "FROM [" & strTable & "] " & _
            "GROUP BY [" & strField & "] " & _
            "HAVING ([" & strField & "] Is Not Null) " & _
            "ORDER BY Count([" & strField & "]) DESC, [" & strField & "];"

  Set rstTemp = dbsTemp.OpenRecordset(strSQL)
  If Not rstTemp.EOF Then
    dblMode = rstTemp(strField)
  Else
    dblMode = 0
  End If
  
  rstTemp.Close
  dbsTemp.Close

  GetTableMode = dblMode

PROC_EXIT:
  Exit Function
  
PROC_ERR:
  MsgBox "Error: " & Err.Number & ". " & Err.Description, , _
    "GetTableMode"
  Resume PROC_EXIT
  
End Function

Public Function QuickSortStatArray( _
  adblIn() As Double, _
  ByVal intLowBound As Integer, _
  ByVal intHighBound As Integer) _
  As Boolean
  ' Comments  : Sort the passed array of doubles (quicksort algorithm)
  ' Parameters: adblIn() - Array of double that gets sorted
  '             intLowBounds - Low bound of array
  '             intHighBound - High bound of array
  ' Returns   : True if successful
  ' Source    : Total VB SourceBook 6
  '
  Dim intX As Integer
  Dim intY As Integer
  Dim dblMidBound As Double
  Dim dblTmp As Double
  Dim fOK As Boolean
  
  On Error GoTo PROC_ERR

  If intHighBound > intLowBound Then
    dblMidBound = adblIn((intLowBound + intHighBound) \ 2)
    intX = intLowBound
    intY = intHighBound
    
    Do While intX <= intY
      If adblIn(intX) >= dblMidBound And adblIn(intY) <= dblMidBound Then
        dblTmp = adblIn(intX)
        adblIn(intX) = adblIn(intY)
        adblIn(intY) = dblTmp
        intX = intX + 1
        intY = intY - 1
      Else
        If adblIn(intX) < dblMidBound Then
          intX = intX + 1
        End If
        If adblIn(intY) > dblMidBound Then
          intY = intY - 1
        End If
      End If
    Loop
  
    fOK = QuickSortStatArray(adblIn(), intLowBound, intY)
    fOK = QuickSortStatArray(adblIn(), intX, intHighBound)
  End If

QuickSortStatArray = True

PROC_EXIT:
  Exit Function
  
PROC_ERR:
  MsgBox "Error: " & Err.Number & ". " & Err.Description, , _
    "QuickSortStatArray"
  Resume PROC_EXIT
  
End Function

