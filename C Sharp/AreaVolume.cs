using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Killercodes.Numbers.AreaVolume
{
	public partial class Area
	{
		#region COde Folding
		// Constants
		internal const double PI = 3.14159265358979;

		///<summary>Returns the area of a circle</summary>
		///<param name="Radius">radius of circle</param>
		///<returns>Area of Circle</returns>
		public double AreaOfCircle(double Radius)
		{
			return (PI * Math.Pow(Radius, 2));
		}

		///<summary>Returns the area of a rectangle</summary>
		///<param name="Length">length of rectangle</param>
		///<param name="Width">Width of the rectangle</param>
		///<remarks>IndiLogix</remarks>
		public double AreaOfRectangle(double Length, double Width)
		{
			return (Length * Width);
		}

		/// <summary>Returns the area of a ring</summary>
		/// <param name="InnerRadius">inner radius of the ring</param>
		/// <param name="OuterRadius">outer radius of the ring</param>
		/// <returns>Area of Ring</returns>
		public double AreaOfRing(double InnerRadius,double OuterRadius)
		{
			return (AreaOfCircle(OuterRadius) - AreaOfCircle(InnerRadius));
		}

		/// <summary>Returns the area of a sphere</summary>
		/// <param name="Radius">radius of the sphere</param>
		/// <returns>Area of Sphere</returns>
		public double AreaOfSphere(double Radius)
		{
			return (4 * PI * Math.Pow(Radius, 2));
		}

		/// <summary>Returns the area of a square</summary>
		/// <param name="Side">length of a side of the square</param>
		/// <returns>Area of Square</returns>
		public double AreaOfSquare(double Side)
		{
			return Math.Pow(Side, 2);
		}

		/// <summary> Returns the area of a square Digonal</summary>
		/// <param name="Diagonal">length of the square's diagonal</param>
		/// <returns>Area of Square</returns>
		public double AreaOfSquareDiag(double Diagonal)
		{
			return (Math.Pow(Diagonal, 2) / 2);
		}

		///<summary>Returns the area of a trapezoid</summary>
		/// <param name="Height">Height</param>
		/// <param name="Length1">length of first side</param>
		/// <param name="Length2">length of second side</param>
		/// <returns>Area</returns>
		public double AreaOfTrapezoid(double Height, double Length1, double Length2)
		{
			return (Height * (Length1 + Length2) / 2);
		}

		/// <summary>returns the area of a triangle</summary>
		/// <param name="Length">length of a side</param>
		/// <param name="Height">perpendicular height</param>
		/// <returns>Area of Triangle</returns>
		public double AreaOfTriangle(double Length, double Height)
		{
			return (Length * Height / 2);
		}

		/// <summary>Returns the area of a triangle</summary>
		/// <param name="SideA">length of first side</param>
		/// <param name="SideB">length of second side</param>
		/// <param name="SideC">length of third side</param>
		/// <returns>Area of Triangle</returns>
		public double AreaOfTriangle(double SideA, double SideB, double SideC)
		{
			double dblCosine,res;
			dblCosine = (SideA + SideB + SideC) / 2;

			res = Math.Sqrt(dblCosine * (dblCosine - SideA) * (dblCosine - SideB) * (dblCosine - SideC));
			return res;
		}

		/// <summary>Returns the length of the diagonal of a rectangle</summary>
		/// <param name="Length">length of rectangle</param>
		/// <param name="Width">width of rectangle</param>
		/// <returns></returns>
		public double LenOfRectangleDiagonal(double Length, double Width)
		{
			return Math.Sqrt(Math.Pow(Width, 2) + Math.Pow(Length, 2));
		}

		/// <summary>Returns the length of the diagonal of a square</summary>
		/// <param name="Length">length of square</param>
		/// <returns>length of diagonal</returns>
		public double LenOfSquareDiagonal(double Length)
		{
			return (Length * Math.Sqrt(2));
		}

	}
	public partial class Volume
	{
		/// <summary>Returns the volume of a cone</summary>
		/// <param name="Height">height of cone</param>
		/// <param name="Radius">radius of cone base</param>
		/// <returns>Volume</returns>
		public double VolOfCone(double Height, double Radius)
		{
			return (Height * Math.Pow(Radius, 2) * PI / 3);
		}
		
			
		/// <summary>
		/// Returns the volume of a cylinder
		/// </summary>
		/// <param name="Height">height of cylinder</param>
		/// <param name="Radius">radius of cylinder</param>
		/// <returns></returns>
		public double VolOfCylinder(double Height, double Radius)
		{
			  double tempVolOfCylinder = 0;
			  
			  tempVolOfCylinder = PI * Height * (Math.Pow(dblRadius, 2));
			  return tempVolOfCylinder;
		}
		

		
		/// <summary>
		/// Returns the volume of a pipe
		/// </summary>
		/// <param name="Height">height of pipe</param>
		/// <param name="OuterRadius">outer radius of pipe</param>
		/// <param name="InnerRadius">inner radius of pipe</param>
		/// <returns>Volume</returns>
		public double VolOfPipe(double Height, double OuterRadius, double InnerRadius)
		{
			  double tempVolOfPipe = 0;

			  tempVolOfPipe = VolOfCylinder(Height, OuterRadius) - VolOfCylinder(Height, InnerRadius);
			  return tempVolOfPipe;
		}

		/// <summary>
		/// Returns the volume of a pyramid or cone
		/// </summary>
		/// <param name="Height">height of pyramid</param>
		/// <param name="BaseArea">area of the base</param>
		/// <returns>Volume</returns>
		public double VolOfPyramid(double Height, double BaseArea)
		{
			  double tempVolOfPyramid = 0;
		
			  tempVolOfPyramid = Height * BaseArea / 3;
			  return tempVolOfPyramid;
		}

		/// <summary>
		/// Returns the volume of a sphere
		/// </summary>
		/// <param name="Radius">radius of the sphere</param>
		/// <returns>volume</returns>
		public double VolOfSphere(double Radius)
		{
			  double tempVolOfSphere = 0;

			  tempVolOfSphere = PI * ((Math.Pow(Radius, 3))) * 4 / 3.0;
			  return tempVolOfSphere;
		}

		/// <summary>
		/// Returns the volume of a truncated pyramid
		/// </summary>
		/// <param name="Height">height of pyramid</param>
		/// <param name="Area1">area of base</param>
		/// <param name="Area2">area of top</param>
		/// <returns>Volume</returns>
		public double VolOfTruncPyramid(double Height, double Area1, double Area2)
		{
			  double tempVolOfTruncPyramid = 0;
			  tempVolOfTruncPyramid = Height * (Area1 + Area2 + Math.Sqrt(Area1) * Math.Sqrt(dblArea2)) / 3;
			  return tempVolOfTruncPyramid;
		}
	}
	
}

namespace IndiLogix.Numbers.General
{
	public partial class General
	{
		/// <summary>
		/// Calculate the wind chill for exposed human skin.
		/// </summary>
		/// <param name="Farenheit">The temperature in degrees Fahrenheit</param>
		/// <param name="WindMPH">The wind speed in Miles per Hour</param>
		/// <returns>The wind chill in degrees Fahrenheit</returns>
		public double ComputeWindChillEnglish(double Farenheit, double WindMPH)
		{
			  double tempComputeWindChillEnglish = 0;

			  if (WindMPH < 4)
			  {
				tempComputeWindChillEnglish = Farenheit;
			  }
			  else
			  {
				// CDec function used to handle subtraction accuracy bug in VB
				tempComputeWindChillEnglish = 0.0817 * (Convert.ToDecimal(3.71 * Math.Sqrt(WindMPH) + 5.81) - Convert.ToDecimal(dblWindMPH / 4)) * (Convert.ToDecimal(Farenheit) - Convert.ToDecimal(91.4)) + 91.4;
			  }
		return tempComputeWindChillEnglish;
		}

		/// <summary>
		/// Calculate the wind chill for exposed human skin.
		/// </summary>
		/// <param name="Celsius">The tempurature in degrees Celsius</param>
		/// <param name="WindKPH">The wind speed in Kilometers per Hour</param>
		/// <returns>The wind chill in degrees Celsius</returns>
		public double ComputeWindChillMetric(double Celsius, double WindKPH)
		{
			  double tempComputeWindChillMetric = 0;

			  if (WindKPH < 4)
			  {
				tempComputeWindChillMetric = dblCelsius;
			  }
			  else
			  {
				tempComputeWindChillMetric = 0.045 * (Convert.ToDecimal(5.27 * Math.Sqrt(WindKPH) + 10.45) - Convert.ToDecimal(0.28 * WindKPH)) * (Convert.ToDecimal(Celsius) - Convert.ToDecimal(33)) + 33;
			  }
		return tempComputeWindChillMetric;
		}

		/// <summary>
		/// Returns the greatest common factor (largest number that evenly divides into two numbers)
		/// </summary>
		/// <param name="FirstVal">first value</param>
		/// <param name="SecondVal">second value</param>
		/// <returns>greatest common factor</returns>
		public long GetGCF(long FirstVal, long SecondVal)
		{
			  long tempGetGCF = 0;

			  long lngTmp = 0;
			  long lngX = 0;
			  long lngY = 0;


			  lngX = FirstVal;
			  lngY = SecondVal;

			  lngX = Abs(lngX);
			  lngY = Abs(lngY);

			  lngTmp = lngX % lngY;

			  while (lngTmp > 0)
			  {
				lngX = lngY;
				lngY = lngTmp;
				lngTmp = lngX % lngY;
			  }

			  tempGetGCF = lngY;

		return tempGetGCF;
		}

		/// <summary>
		/// Returns a random integer value between the range specified in the arguments, inclusive
		/// </summary>
		/// <param name="LowRange">Lower bound of the range of integers</param>
		/// <param name="HighRange">Upper bound of the range of integers</param>
		/// <returns>The random number</returns>
		public long GetRandomInt(long LowRange, long HighRange)
		{
			  long tempGetRandomInt = 0;

			  long lngResult = 0;

			  Random Rnd = new Random();
			
			  //// change the random number generator "seed"
			  //Randomize Timer;

			  //// Scale the output of the rnd function so that it returns
			  //// an integer in the correct range instead of a floating
			  //// point value
			  //lngResult = (int)Math.Floor((HighRange - LowRange + 1) * Rnd + LowRange);
			  //tempGetRandomInt = lngResult;
			  return Rnd.Next(LowRange,HighRange);
		 }
		  
		/// <summary>
		/// Determines if a number is a prime number
		/// </summary>
		/// <param name="Number"> number to check</param>
		/// <returns>True - number is prime, False - number is not prime</returns>
		public bool IsNumberPrime(long Number)
		{
			  bool tempIsNumberPrime = false;
			  int intCounter = 0;
			  long lngTest = 0;
			  bool fIsPrime = false;

			  // Convert to positive values only
			  lngTest = Math.Abs(Number); // Convert to positive values only

			  switch (lngTest)
			  {
				case 0:
				case 1:
				  fIsPrime = false;

				  break;
				case 2:
				  fIsPrime = true;

				  break;
				default:
				  if (lngTest % 2 == 0)
				  {
					// Divisible by 2
					fIsPrime = false;
				  }
				  else
				  {
					// Test if an odd number divides into the test value
					// without a remainder
					fIsPrime = true;
					for (intCounter = 3; intCounter <= (int)Math.Floor(lngTest / 2.0); intCounter += 2)
					{
					  if (lngTest % intCounter == 0)
					  {
						// Number is not prime
						fIsPrime = false;
						break;
					  }
					}
				  }
				  break;
			  }

			  tempIsNumberPrime = fIsPrime;
			  return tempIsNumberPrime;
		}

		
		//public Variant MaxOfThree(Variant varValue1, Variant varValue2, Variant varValue3)
		//{
		//      Variant tempMaxOfThree = null;
		//  try
		//  {
		//      // Comments  : Returns the greater of three values (null values are ignored)
		//      // Parameters: varValue1 - first value
		//      //             varValue2 - second value
		//      //             varValue3 - third value
		//      // Returns   : Maximum value (null if all three input values are null)
		//      // Source    : Total VB SourceBook 6
		//      //
		//      Variant varReturn = null;


		//      if (! (IsNull(varValue1)) & ! (IsNull(varValue2)) & ! (IsNull(varValue3)))
		//      {
		//        if (varValue1 > varValue2)
		//        {
		//          varReturn = ((varValue1 > varValue3) ? varValue1 : varValue3);
		//        }
		//        else
		//        {
		//          varReturn = ((varValue2 > varValue3) ? varValue2 : varValue3);
		//        }
		//      }
		//      else if (IsNull(varValue1) & IsNull(varValue2) & IsNull(varValue3))
		//      {
		//        varReturn = Null;
		//        // 1 is null, but 2 & 3 may or may not be null
		//      }
		//      else if (IsNull(varValue1))
		//      {
		//        if (IsNull(varValue2))
		//        {
		//          varReturn = varValue3;
		//        }
		//        else if (IsNull(varValue3))
		//        {
		//          varReturn = varValue2;
		//        }
		//        else
		//        {
		//          varReturn = ((varValue2 > varValue3) ? varValue2 : varValue3);
		//        }
		//      }
		//      else if (IsNull(varValue2))
		//      {
		//        // 1 is not null
		//        if (IsNull(varValue3))
		//        {
		//          varReturn = varValue1;
		//        }
		//        else
		//        {
		//          varReturn = ((varValue1 > varValue3) ? varValue1 : varValue3);
		//        }
		//      // 1 and 2 are not null
		//      }
		//      else if (IsNull(varValue3))
		//      {
		//        varReturn = ((varValue1 > varValue2) ? varValue1 : varValue2);
		//      }

		//      tempMaxOfThree = varReturn;

		//    PROC_EXIT:
		//      return tempMaxOfThree;

		//  }
		//  catch
		//  {
		//      goto PROC_ERR;
		//  }
		//PROC_ERR:
		////INSTANT C# TODO TASK: Calls to the VB 'Err' object are not converted by Instant C#:
		//  MsgBox "Error: " + Err.Number + ". " + Err.Description,, "MaxOfThree";
		//  goto PROC_EXIT;

		//  return tempMaxOfThree;
		//}

		public Variant MaxOfTwo(Variant varValue1, Variant varValue2)
		{
			  Variant tempMaxOfTwo = null;
		  try
		  {
			  // Comments  : returns the greater of two values (null values are ignored)
			  // Parameters: varValue1 - first value
			  //             varValue2 - second value
			  // Returns   : Maximum value (null if both input values are null)
			  // Source    : Total VB SourceBook 6
			  //
			  Variant varReturn = null;


			  if (! (IsNull(varValue1)) & ! (IsNull(varValue2)))
			  {
				varReturn = ((varValue1 > varValue2) ? varValue1 : varValue2);
			  }
			  else if (IsNull(varValue1))
			  {
				if (IsNull(varValue2))
				{
				  varReturn = Null;
				}
				else
				{
				  varReturn = varValue2;
				}
			  }
			  else if (IsNull(varValue2))
			  {
				varReturn = varValue1;
			  }

			  tempMaxOfTwo = varReturn;

			PROC_EXIT:
			  return tempMaxOfTwo;

		  }
		  catch
		  {
			  goto PROC_ERR;
		  }
		PROC_ERR:
		//INSTANT C# TODO TASK: Calls to the VB 'Err' object are not converted by Instant C#:
		  MsgBox "Error: " + Err.Number + ". " + Err.Description,, "MaxOfTwo";
		  goto PROC_EXIT;

		  return tempMaxOfTwo;
		}

		public Variant MinOfThree(Variant varValue1, Variant varValue2, Variant varValue3)
		{
			  Variant tempMinOfThree = null;
		  try
		  {
			  // Comments  : Returns the smallest of three values (null values
			  //             are ignored)
			  // Parameters: varValue1 - first value
			  //             varValue2 - second value
			  //             varValue3 - third value
			  // Returns   : Minimum value (null if all three input values are null)
			  // Source    : Total VB SourceBook 6
			  //
			  Variant varReturn = null;


			  if (! (IsNull(varValue1)) & ! (IsNull(varValue2)) & ! (IsNull(varValue3)))
			  {
				if (varValue1 < varValue2)
				{
				  varReturn = ((varValue1 < varValue3) ? varValue1 : varValue3);
				}
				else
				{
				  varReturn = ((varValue2 < varValue3) ? varValue2 : varValue3);
				}
			  }
			  else if (IsNull(varValue1) & IsNull(varValue2) & IsNull(varValue3))
			  {
				varReturn = Null;
				// 1 is null, but 2 & 3 may or may not be null
			  }
			  else if (IsNull(varValue1))
			  {
				if (IsNull(varValue2))
				{
				  varReturn = varValue3;
				}
				else if (IsNull(varValue3))
				{
				  varReturn = varValue2;
				}
				else
				{
				  varReturn = ((varValue2 < varValue3) ? varValue2 : varValue3);
				}
			  }
			  else if (IsNull(varValue2))
			  {
				// 1 is not null
				if (IsNull(varValue3))
				{
				  varReturn = varValue1;
				}
				else
				{
				  varReturn = ((varValue1 < varValue3) ? varValue1 : varValue3);
				}
			  }
			  else if (IsNull(varValue3))
			  {
				// 1 and 2 are not null
				varReturn = ((varValue1 < varValue2) ? varValue1 : varValue2);
			  }

			  tempMinOfThree = varReturn;

			PROC_EXIT:
			  return tempMinOfThree;

		  }
		  catch
		  {
			  goto PROC_ERR;
		  }
		PROC_ERR:
		//INSTANT C# TODO TASK: Calls to the VB 'Err' object are not converted by Instant C#:
		  MsgBox "Error: " + Err.Number + ". " + Err.Description,, "MinOfThree";
		  goto PROC_EXIT;

		  return tempMinOfThree;
		}

		public Variant MinOfTwo(Variant varValue1, Variant varValue2)
		{
			  Variant tempMinOfTwo = null;
		  try
		  {
			  // Comments  : Returns the lesser of two values (null values are ignored)
			  // Parameters: varValue1 - first value
			  //             varValue2 - second value
			  // Returns   : Minimum value (null if both input values are null)
			  // Source    : Total VB SourceBook 6
			  //
			  Variant varReturn = null;


			  if (! (IsNull(varValue1)) & ! (IsNull(varValue2)))
			  {
				varReturn = ((varValue1 < varValue2) ? varValue1 : varValue2);
			  }
			  else if (IsNull(varValue1))
			  {
				if (IsNull(varValue2))
				{
				  varReturn = Null;
				}
				else
				{
				  varReturn = varValue2;
				}
			  }
			  else if (IsNull(varValue2))
			  {
				varReturn = varValue1;
			  }

			  tempMinOfTwo = varReturn;

			PROC_EXIT:
			  return tempMinOfTwo;

		  }
		  catch
		  {
			  goto PROC_ERR;
		  }
		PROC_ERR:
		//INSTANT C# TODO TASK: Calls to the VB 'Err' object are not converted by Instant C#:
		  MsgBox "Error: " + Err.Number + ". " + Err.Description,, "MinOfTwo";
		  goto PROC_EXIT;

		  return tempMinOfTwo;
		}

		public void PrimeFactors(long Number, long[] alngNumbers)
		{
		  try
		  {
			  // Comments  : This procedure calculates the prime factors of a number
			  // Parameters: lngNumber - The number to compute the prime factors for
			  //             alngNumbers - An array of numbers containing the prime
			  //             factors. This array is modified by the procedure.
			  // Returns   : Nothing
			  // Source    : Total VB SourceBook 6
			  //
			  long lngDenominator = 0;
			  int intCount = 0;
			  long intCounter = 0;
			  long lngTempNumber = 0;


			  // Reserve space for one number
			  Array.Resize(ref alngNumbers, 1);

			  lngTempNumber = Number;

			  // If the number is less than two, then it cannot be factored
			  if (lngTempNumber < 2)
			  {
				alngNumbers[0] = lngTempNumber;
			  }
			  else if (lngTempNumber > 2)
			  {
				// Factor the number
				lngDenominator = 2;
				intCount = 0;
				// While the number is divisible by two
				while ((lngTempNumber % lngDenominator) == 0)
				{
				  lngTempNumber = lngTempNumber / lngDenominator;
				  intCount = intCount + 1;
				}

				// If the number was divided at least once, store the result
				if (intCount > 0)
				{
				  // create space for the numbers
				  Array.Resize(ref alngNumbers, alngNumbers.GetUpperBound(0) + intCount + 1);
				  // For each division
				  for (intCounter = 0; intCounter < intCount; intCounter++)
				  {
					// Store the denomiator (in this case 2) in the array
					alngNumbers[alngNumbers.GetUpperBound(0) - intCounter] = lngDenominator;
				  }
				}

				lngDenominator = 3;
				// While the denominator is less than half the number
				while (lngDenominator * 2 <= lngTempNumber)
				{
				  intCount = 0;
				  // While the number is evenly divisible by the denominator
				  while (lngTempNumber % lngDenominator == 0)
				  {
					lngTempNumber = lngTempNumber / lngDenominator;
					intCount = intCount + 1;
				  }

				  // If the number was divided at least once, store the result
				  if (intCount > 0)
				  {
					// Create space for the numbers
					Array.Resize(ref alngNumbers, alngNumbers.GetUpperBound(0) + intCount + 1);
					// For each division
					for (intCounter = 0; intCounter < intCount; intCounter++)
					{
					  // Store the denomiator in the array
					  alngNumbers[alngNumbers.GetUpperBound(0) - intCounter] = lngDenominator;
					}
				  }
				  // The denominator can only be odd at this point, so increment by two
				  lngDenominator = lngDenominator + 2;
				}
			  }

			  if (lngTempNumber > 1)
			  {
				// If something has been assigned to the array before, store the last value
				// of the number. Otherwise it is a prime number
				if (alngNumbers.GetUpperBound(0) > 0)
				{
				  Array.Resize(ref alngNumbers, alngNumbers.GetUpperBound(0) + 2);
				}
				alngNumbers[alngNumbers.GetUpperBound(0)] = lngTempNumber;
			  }

			PROC_EXIT:
			  return;

		  }
		  catch
		  {
			  goto PROC_ERR;
		  }
		PROC_ERR:
		//INSTANT C# TODO TASK: Calls to the VB 'Err' object are not converted by Instant C#:
		  MsgBox "Error: " + Err.Number + ". " + Err.Description,, "PrimeFactors";
		  goto PROC_EXIT;

		}



public double RoundBankers(double dblNumber, int intDecimals)
{
	  double tempRoundBankers = 0;
  try
  {
	  // Comments  : Banker's rounding to specified decimal places.
	  //             Banker's Rounding rounds a 5 digit to the nearest even
	  //             number. (eg. 100.045 goes to 100.04, and 100.055 goes
	  //             to 100.06). Regular rounding always rounds *.5 up.
	  // Parameters: dblNumber - number to round
	  //             intDecimals - number of decimals to round (2 for cents)
	  //             (negative rounds to left of decimal)
	  // Returns   : Number rounded using banker's rounding
	  // Source    : Total VB SourceBook 6
	  //
	  double dblFactor = 0;
	  double dblRoundDown = 0;
	  double dblDiff = 0;
	  double dblResult = 0;
	  double dblTemp = 0;
	  double dblCheck = 0;
	  bool fIsOdd = false;


	  dblFactor = (Math.Pow(10, intDecimals));

	  dblTemp = dblNumber * dblFactor;
	  dblCheck = (int)Math.Floor(Convert.ToDecimal(dblTemp));
	  dblRoundDown = dblCheck / dblFactor;
	  fIsOdd = (((dblCheck / 2) - (int)Math.Floor(dblCheck / 2)) > 0);

	  dblDiff = Convert.ToDecimal(dblNumber) - Convert.ToDecimal(dblRoundDown);
	  dblTemp = dblDiff * 10 * dblFactor + 0.5;
	  dblDiff = (int)Math.Floor(Convert.ToDecimal(dblTemp)) / (10 * dblFactor);

	  dblResult = dblRoundDown;

	  // If *.5, round to nearest even number:
	  if ((dblDiff == (0.5 / dblFactor)) && fIsOdd)
	  {
		dblResult = dblRoundDown + 1 / dblFactor;
	  }
	  else if (dblDiff > (0.5 / dblFactor))
	  {
		dblResult = dblRoundDown + 1 / dblFactor;
	  }

	  tempRoundBankers = dblResult;

	PROC_EXIT:
	  return tempRoundBankers;

  }
  catch
  {
	  goto PROC_ERR;
  }
PROC_ERR:
//INSTANT C# TODO TASK: Calls to the VB 'Err' object are not converted by Instant C#:
  MsgBox "Error: " + Err.Number + ". " + Err.Description,, "RoundBankers";
  goto PROC_EXIT;

  return tempRoundBankers;
}

public double RoundDown(double dblNumber, int intRound)
{
	  double tempRoundDown = 0;
  try
  {
	  // Comments  : Rounds the passed number to specified number of
	  //             decimal places with 0.5 rounded down.
	  // Parameters: dblNumber - number to round
	  //             intRound - number of digits to round to
	  //             (positive for right of decimal, negative for left)
	  // Returns   : rounded number
	  // Source    : Total VB SourceBook 6
	  //
	  double dblFactor = 0;
	  double dblTemp = 0;
	  double dblRound = 0;


	  dblFactor = (Math.Pow(10, intRound));

	  dblTemp = dblNumber * dblFactor;
	  dblRound = (int)Math.Floor(Convert.ToDecimal(dblTemp)) / dblFactor;

	  // Must use special subtraction function to prevent rounding
	  // errors with subtraction.
	  if (Subtract(dblNumber, dblRound) > 0.5 / dblFactor)
	  {
		dblRound = dblRound + 1 / dblFactor;
	  }

	  tempRoundDown = dblRound;

	PROC_EXIT:
	  return tempRoundDown;

  }
  catch
  {
	  goto PROC_ERR;
  }
PROC_ERR:
//INSTANT C# TODO TASK: Calls to the VB 'Err' object are not converted by Instant C#:
  MsgBox "Error: " + Err.Number + ". " + Err.Description,, "RoundDown";
  goto PROC_EXIT;

  return tempRoundDown;
}

public double RoundExt(double dblNumber, int intDecimals)
{
	  double tempRoundExt = 0;
  try
  {
	  // Comments  : Rounds a number to a specified number of decimal
	  //             places (0.5 is rounded up). Unlike the VB 6 Round
	  //             function, this one works correctly.
	  // Parameters: dblNumber - number to round
	  //             intDecimals - number of decimal places to round to
	  //             (positive for right of decimal, negative for left)
	  // Returns   : Rounded number
	  // Source    : Total VB SourceBook 6
	  //
	  double dblFactor = 0;
	  double dblTemp = 0;


	  dblFactor = (Math.Pow(10, intDecimals));
	  dblTemp = dblNumber * dblFactor + 0.5;
	  tempRoundExt = (int)Math.Floor(Convert.ToDecimal(dblTemp)) / dblFactor;

	PROC_EXIT:
	  return tempRoundExt;

  }
  catch
  {
	  goto PROC_ERR;
  }
PROC_ERR:
//INSTANT C# TODO TASK: Calls to the VB 'Err' object are not converted by Instant C#:
  MsgBox "Error: " + Err.Number + ". " + Err.Description,, "RoundExt";
  goto PROC_EXIT;

  return tempRoundExt;
}

public int ScalePercent(double dblCurrent, double dblMax)
{
	  int tempScalePercent = 0;
  try
  {
	  // Comments  : Scales a value to a range between 0 and 100 (number could
	  //             be less than 0 or greater than 100 if the 'current' value is
	  //             less than 0 or greater than the 'max' value
	  // Parameters: dblCurrent - Value to test
	  //             dblMax - The maximum value
	  // Returns   : An integer value scaled to a percentage
	  // Source    : Total VB SourceBook 6
	  //

	  tempScalePercent = (int)Math.Floor(100 * dblCurrent / dblMax);

	PROC_EXIT:
	  return tempScalePercent;

  }
  catch
  {
	  goto PROC_ERR;
  }
PROC_ERR:
//INSTANT C# TODO TASK: Calls to the VB 'Err' object are not converted by Instant C#:
  MsgBox "Error: " + Err.Number + ". " + Err.Description,, "ScalePercent";
  goto PROC_EXIT;

  return tempScalePercent;
}

public double Subtract(double dblValue1, double dblValue2)
{
	  double tempSubtract = 0;
  try
  {
	  // Comments  : Subtract two numbers with decimals correctly
	  //             In certain situations, VB does not subtract numbers
	  //             with decimal places correctly.
	  //             (eg. 100.8 - 100.7 = 0.099999999999943)
	  //             This procedure corrects the problem by rounding the
	  //             numbers correctly. The result cannot have more decimal
	  //             places than the maximum of the inputs.
	  // Parameters: dblValue1 - first value
	  //             dblValue2 - second value (subtracted from dblValue1)
	  // Returns   : Difference between two values (dblValue1 - dblValue2)
	  // Source    : Total VB SourceBook 6
	  //


	  tempSubtract = Convert.ToDecimal(dblValue1) - Convert.ToDecimal(dblValue2);

	PROC_EXIT:
	  return tempSubtract;

  }
  catch
  {
	  goto PROC_ERR;
  }
PROC_ERR:
//INSTANT C# TODO TASK: Calls to the VB 'Err' object are not converted by Instant C#:
  MsgBox "Error: " + Err.Number + ". " + Err.Description,, "Subtract";
  goto PROC_EXIT;

  return tempSubtract;
}
	}
}

		#endregion
