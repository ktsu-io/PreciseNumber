// Ignore Spelling: Commonized

namespace ktsu.io.PreciseNumber.Tests;

using System.Globalization;
using System.Numerics;

[TestClass]
public class PreciseNumberTests
{
	[TestMethod]
	public void TestPreciseAdd()
	{
		var left = new PreciseNumber(2, new BigInteger(100)); // 1.00 x 10^2
		var right = new PreciseNumber(2, new BigInteger(50)); // 0.50 x 10^2
		var result = PreciseNumber.PreciseAdd(left, right);
		var expected = new PreciseNumber(2, new BigInteger(150)); // 1.50 x 10^2
		Assert.AreEqual(expected, result);
	}

	[TestMethod]
	public void TestPreciseSubtract()
	{
		var left = new PreciseNumber(2, new BigInteger(100)); // 1.00 x 10^2
		var right = new PreciseNumber(2, new BigInteger(50)); // 0.50 x 10^2
		var result = PreciseNumber.PreciseSubtract(left, right);
		var expected = new PreciseNumber(2, new BigInteger(50)); // 0.50 x 10^2
		Assert.AreEqual(expected, result);
	}

	[TestMethod]
	public void TestPreciseMultiply()
	{
		var left = new PreciseNumber(2, new BigInteger(2)); // 2.00 x 10^2
		var right = new PreciseNumber(1, new BigInteger(3)); // 3.00 x 10^1
		var result = PreciseNumber.PreciseMultiply(left, right);
		var expected = new PreciseNumber(3, new BigInteger(6)); // 6.00 x 10^3
		Assert.AreEqual(expected, result);
	}

	[TestMethod]
	public void TestPreciseDivide()
	{
		var left = new PreciseNumber(2, new BigInteger(200)); // 2.00 x 10^2
		var right = new PreciseNumber(1, new BigInteger(5)); // 5.00 x 10^1
		var result = PreciseNumber.PreciseDivide(left, right);
		var expected = new PreciseNumber(1, new BigInteger(40)); // 4.00 x 10^1
		Assert.AreEqual(expected, result);
	}

	[TestMethod]
	public void TestPreciseNumberPow()
	{
		var baseNumber = new PreciseNumber(0, new BigInteger(2)); // 2
		var power = new PreciseNumber(0, new BigInteger(3)); // 3
		var result = baseNumber.Pow(power);
		var expected = new PreciseNumber(0, new BigInteger(8)); // 2^3 = 8
		Assert.AreEqual(expected, result);
	}

	[TestMethod]
	public void TestPreciseNumberExp()
	{
		var power = new PreciseNumber(0, new BigInteger(1)); // 1
		var result = PreciseNumber.Exp(power);
		var expected = PreciseNumber.E; // e^1 = e
		Assert.AreEqual(expected, result);
	}

	[TestMethod]
	public void TestPreciseNumberExpNegativePower()
	{
		var power = new PreciseNumber(0, new BigInteger(-1)); // -1
		var result = PreciseNumber.Exp(power);
		var expected = PreciseNumber.One / PreciseNumber.E; // e^-1 = 1/e
		Assert.AreEqual(expected, result);
	}

	[TestMethod]
	public void TestZeroCheck()
	{
		var zero = new PreciseNumber(0, BigInteger.Zero);
		Assert.IsTrue(PreciseNumber.IsZero(zero));
	}

	[TestMethod]
	public void TestOneCheck()
	{
		var one = new PreciseNumber(0, BigInteger.One);
		Assert.AreEqual(PreciseNumber.One, one);
	}

	[TestMethod]
	public void TestNegativeOneCheck()
	{
		var negativeOne = new PreciseNumber(0, BigInteger.MinusOne);
		Assert.AreEqual(PreciseNumber.NegativeOne, negativeOne);
	}

	[TestMethod]
	public void TestAbs()
	{
		var negative = new PreciseNumber(2, new BigInteger(-12345));
		var positive = PreciseNumber.Abs(negative);
		Assert.AreEqual(new PreciseNumber(2, new BigInteger(12345)), positive);
	}

	[TestMethod]
	public void TestMax()
	{
		var left = new PreciseNumber(2, new BigInteger(200));
		var right = new PreciseNumber(1, new BigInteger(50));
		var result = PreciseNumber.Max(left, right);
		Assert.AreEqual(left, result);
	}

	[TestMethod]
	public void TestMin()
	{
		var left = new PreciseNumber(2, new BigInteger(200));
		var right = new PreciseNumber(1, new BigInteger(50));
		var result = PreciseNumber.Min(left, right);
		Assert.AreEqual(right, result);
	}

	[TestMethod]
	public void TestRound()
	{
		var value = 123.456.ToPreciseNumber();
		var result = value.Round(2);
		var expected = 123.46.ToPreciseNumber();
		Assert.AreEqual(expected, result);
	}

	[TestMethod]
	public void TestClamp()
	{
		var value = new PreciseNumber(0, new BigInteger(5));
		var min = new PreciseNumber(0, new BigInteger(3));
		var max = new PreciseNumber(0, new BigInteger(7));
		var result = PreciseNumber.Clamp(value, min, max);
		Assert.AreEqual(value, result);
	}

	[TestMethod]
	public void TestClampLower()
	{
		var value = new PreciseNumber(0, new BigInteger(2));
		var min = new PreciseNumber(0, new BigInteger(3));
		var max = new PreciseNumber(0, new BigInteger(7));
		var result = PreciseNumber.Clamp(value, min, max);
		Assert.AreEqual(min, result);
	}

	[TestMethod]
	public void TestClampUpper()
	{
		var value = new PreciseNumber(0, new BigInteger(8));
		var min = new PreciseNumber(0, new BigInteger(3));
		var max = new PreciseNumber(0, new BigInteger(7));
		var result = PreciseNumber.Clamp(value, min, max);
		Assert.AreEqual(max, result);
	}

	[TestMethod]
	public void TestSquared()
	{
		var value = new PreciseNumber(0, new BigInteger(3));
		var result = value.Squared();
		var expected = new PreciseNumber(0, new BigInteger(9));
		Assert.AreEqual(expected, result);
	}

	[TestMethod]
	public void TestCubed()
	{
		var value = new PreciseNumber(0, new BigInteger(2));
		var result = value.Cubed();
		var expected = new PreciseNumber(0, new BigInteger(8));
		Assert.AreEqual(expected, result);
	}

	[TestMethod]
	public void TestNegate()
	{
		var value = new PreciseNumber(0, new BigInteger(10));
		var result = PreciseNumber.Negate(value);
		var expected = new PreciseNumber(0, new BigInteger(-10));
		Assert.AreEqual(expected, result);
	}

	[TestMethod]
	public void TestSignificantDigits()
	{
		var value = new PreciseNumber(0, new BigInteger(12345));
		Assert.AreEqual(5, value.SignificantDigits);
	}

	[TestMethod]
	public void TestCountDecimalDigits()
	{
		var value = new PreciseNumber(-3, new BigInteger(123));
		Assert.AreEqual(3, value.CountDecimalDigits());
	}

	[TestMethod]
	public void TestPreciseAddWithCommonizedExponent()
	{
		var left = 1000.ToPreciseNumber();
		var right = 5.ToPreciseNumber();
		var result = PreciseNumber.PreciseAdd(left, right);
		var expected = 1005.ToPreciseNumber();
		Assert.AreEqual(expected, result);
	}

	[TestMethod]
	public void TestPreciseSubtractWithCommonizedExponent()
	{
		var left = 1000.ToPreciseNumber();
		var right = 5.ToPreciseNumber();
		var result = PreciseNumber.PreciseSubtract(left, right);
		var expected = 995.ToPreciseNumber();
		Assert.AreEqual(expected, result);
	}

	[TestMethod]
	public void TestPreciseMultiplyWithCommonizedExponent()
	{
		var left = 2000.ToPreciseNumber();
		var right = 30.ToPreciseNumber();
		var result = PreciseNumber.PreciseMultiply(left, right);
		var expected = 60000.ToPreciseNumber();
		Assert.AreEqual(expected, result);
	}

	[TestMethod]
	public void TestPreciseDivideWithCommonizedExponent()
	{
		var left = 20000.ToPreciseNumber();
		var right = 40.ToPreciseNumber();
		var result = PreciseNumber.PreciseDivide(left, right);
		var expected = 500.ToPreciseNumber();
		Assert.AreEqual(expected, result);
	}

	[TestMethod]
	public void TestTryCreateWithInvalidType()
	{
		Assert.IsFalse(PreciseNumberExtensions.TryCreate(3.ToPreciseNumber(), out var _));
	}

	[TestMethod]
	public void Test_Zero()
	{
		var zero = PreciseNumber.Zero;
		Assert.AreEqual(0, zero.Significand);
		Assert.AreEqual(0, zero.Exponent);
	}

	[TestMethod]
	public void Test_One()
	{
		var one = PreciseNumber.One;
		Assert.AreEqual(1, one.Significand);
		Assert.AreEqual(0, one.Exponent);
	}

	[TestMethod]
	public void Test_NegativeOne()
	{
		var negativeOne = PreciseNumber.NegativeOne;
		Assert.AreEqual(-1, negativeOne.Significand);
		Assert.AreEqual(0, negativeOne.Exponent);
	}

	[TestMethod]
	public void Test_Add()
	{
		var one = PreciseNumber.One;
		var result = one + one;
		Assert.AreEqual(2.ToPreciseNumber(), result);
	}

	[TestMethod]
	public void Test_Subtract()
	{
		var one = PreciseNumber.One;
		var result = one - one;
		Assert.AreEqual(PreciseNumber.Zero, result);
	}

	[TestMethod]
	public void Test_Multiply()
	{
		var one = PreciseNumber.One;
		var result = one * one;
		Assert.AreEqual(PreciseNumber.One, result);
	}

	[TestMethod]
	public void Test_Divide()
	{
		var one = PreciseNumber.One;
		var result = one / one;
		Assert.AreEqual(PreciseNumber.One, result);
	}

	[TestMethod]
	public void Test_Round()
	{
		var number = 1.2345.ToPreciseNumber();
		var rounded = number.Round(2);
		Assert.AreEqual(1.24.ToPreciseNumber(), rounded);
	}

	[TestMethod]
	public void Test_Abs()
	{
		var negative = PreciseNumber.NegativeOne;
		var positive = negative.Abs();
		Assert.AreEqual(PreciseNumber.One, positive);
	}

	[TestMethod]
	public void Test_Clamp()
	{
		var value = 5.ToPreciseNumber();
		var min = 3.ToPreciseNumber();
		var max = 7.ToPreciseNumber();
		var clamped = value.Clamp(min, max);
		Assert.AreEqual(value, clamped);

		clamped = 2.ToPreciseNumber().Clamp(min, max);
		Assert.AreEqual(min, clamped);

		clamped = 8.ToPreciseNumber().Clamp(min, max);
		Assert.AreEqual(max, clamped);
	}

	[TestMethod]
	public void Test_ToString()
	{
		var number = 0.0123.ToPreciseNumber();
		string str = number.ToString();
		Assert.AreEqual("0.0123", str);
	}

	[TestMethod]
	public void Test_Equals()
	{
		var one = PreciseNumber.One;
		Assert.IsTrue(one.Equals(PreciseNumber.One));
		Assert.IsFalse(one.Equals(PreciseNumber.Zero));
	}

	[TestMethod]
	public void Test_CompareTo()
	{
		var one = PreciseNumber.One;
		var zero = PreciseNumber.Zero;
		Assert.IsTrue(one.CompareTo(zero) > 0);
		Assert.IsTrue(zero.CompareTo(one) < 0);
		Assert.IsTrue(one.CompareTo(PreciseNumber.One) == 0);
	}

	// Tests for comparison operators
	[TestMethod]
	public void Test_GreaterThan()
	{
		var one = PreciseNumber.One;
		var zero = PreciseNumber.Zero;
		Assert.IsTrue(one > zero);
		Assert.IsFalse(zero > one);
	}

	[TestMethod]
	public void Test_GreaterThanOrEqual()
	{
		var one = PreciseNumber.One;
		var zero = PreciseNumber.Zero;
		Assert.IsTrue(one >= zero);
		Assert.IsTrue(one >= PreciseNumber.One);
		Assert.IsFalse(zero >= one);
	}

	[TestMethod]
	public void Test_LessThan()
	{
		var one = PreciseNumber.One;
		var zero = PreciseNumber.Zero;
		Assert.IsTrue(zero < one);
		Assert.IsFalse(one < zero);
	}

	[TestMethod]
	public void Test_LessThanOrEqual()
	{
		var one = PreciseNumber.One;
		var zero = PreciseNumber.Zero;
		Assert.IsTrue(zero <= one);
		Assert.IsTrue(one <= PreciseNumber.One);
		Assert.IsFalse(one <= zero);
	}

	[TestMethod]
	public void Test_Equality()
	{
		var one = PreciseNumber.One;
		var anotherOne = 1.ToPreciseNumber();
		var zero = PreciseNumber.Zero;
		Assert.IsTrue(one == anotherOne);
		Assert.IsFalse(one == zero);
	}

	[TestMethod]
	public void Test_Inequality()
	{
		var one = PreciseNumber.One;
		var anotherOne = 1.ToPreciseNumber();
		var zero = PreciseNumber.Zero;
		Assert.IsTrue(one != zero);
		Assert.IsFalse(one != anotherOne);
	}

	// Tests for unsupported operators
	[TestMethod]
	public void Test_Modulus()
	{
		var one = PreciseNumber.One;
		Assert.ThrowsException<NotSupportedException>(() => one % one);
	}

	[TestMethod]
	public void Test_Decrement()
	{
		var one = PreciseNumber.One;
		Assert.ThrowsException<NotSupportedException>(() => --one);
	}

	[TestMethod]
	public void Test_Increment()
	{
		var one = PreciseNumber.One;
		Assert.ThrowsException<NotSupportedException>(() => ++one);
	}

	// Test for unary + operator
	[TestMethod]
	public void Test_UnaryPlus()
	{
		var one = PreciseNumber.One;
		var result = +one;
		Assert.AreEqual(PreciseNumber.One, result);
	}

	// Tests for static methods of unary operators
	[TestMethod]
	public void Test_StaticUnaryPlus()
	{
		var one = PreciseNumber.One;
		var result = PreciseNumber.Plus(one);
		Assert.AreEqual(PreciseNumber.One, result);
	}

	[TestMethod]
	public void Test_StaticUnaryNegate()
	{
		var one = PreciseNumber.One;
		var result = PreciseNumber.Negate(one);
		Assert.AreEqual(PreciseNumber.NegativeOne, result);
	}

	// Tests for static methods of binary operators
	[TestMethod]
	public void Test_StaticAdd()
	{
		var one = PreciseNumber.One;
		var result = PreciseNumber.Add(one, one);
		Assert.AreEqual(2.ToPreciseNumber(), result);
	}

	[TestMethod]
	public void Test_StaticSubtract()
	{
		var one = PreciseNumber.One;
		var result = PreciseNumber.Subtract(one, one);
		Assert.AreEqual(PreciseNumber.Zero, result);
	}

	[TestMethod]
	public void Test_StaticMultiply()
	{
		var one = PreciseNumber.One;
		var result = PreciseNumber.Multiply(one, one);
		Assert.AreEqual(PreciseNumber.One, result);
	}

	[TestMethod]
	public void Test_StaticDivide()
	{
		var one = PreciseNumber.One;
		var result = PreciseNumber.Divide(one, one);
		Assert.AreEqual(PreciseNumber.One, result);
	}

	[TestMethod]
	public void Test_StaticModulus()
	{
		var one = PreciseNumber.One;
		Assert.ThrowsException<NotSupportedException>(() => PreciseNumber.Mod(one, one));
	}

	// Test for static increment method
	[TestMethod]
	public void Test_StaticIncrement()
	{
		var one = PreciseNumber.One;
		Assert.ThrowsException<NotSupportedException>(() => PreciseNumber.Increment(one));
	}

	// Test for static decrement method
	[TestMethod]
	public void Test_StaticDecrement()
	{
		var one = PreciseNumber.One;
		Assert.ThrowsException<NotSupportedException>(() => PreciseNumber.Decrement(one));
	}

	[TestMethod]
	public void Test_StaticGreaterThan()
	{
		var one = PreciseNumber.One;
		var zero = PreciseNumber.Zero;
		Assert.IsTrue(PreciseNumber.GreaterThan(one, zero));
		Assert.IsFalse(PreciseNumber.GreaterThan(zero, one));
	}

	[TestMethod]
	public void Test_StaticGreaterThanOrEqual()
	{
		var one = PreciseNumber.One;
		var zero = PreciseNumber.Zero;
		Assert.IsTrue(PreciseNumber.GreaterThanOrEqual(one, zero));
		Assert.IsTrue(PreciseNumber.GreaterThanOrEqual(one, PreciseNumber.One));
		Assert.IsFalse(PreciseNumber.GreaterThanOrEqual(zero, one));
	}

	[TestMethod]
	public void Test_StaticLessThan()
	{
		var one = PreciseNumber.One;
		var zero = PreciseNumber.Zero;
		Assert.IsTrue(PreciseNumber.LessThan(zero, one));
		Assert.IsFalse(PreciseNumber.LessThan(one, zero));
	}

	[TestMethod]
	public void Test_StaticLessThanOrEqual()
	{
		var one = PreciseNumber.One;
		var zero = PreciseNumber.Zero;
		Assert.IsTrue(PreciseNumber.LessThanOrEqual(zero, one));
		Assert.IsTrue(PreciseNumber.LessThanOrEqual(one, PreciseNumber.One));
		Assert.IsFalse(PreciseNumber.LessThanOrEqual(one, zero));
	}

	[TestMethod]
	public void Test_StaticEqual()
	{
		var one = PreciseNumber.One;
		var anotherOne = 1.ToPreciseNumber();
		var zero = PreciseNumber.Zero;
		Assert.IsTrue(PreciseNumber.Equal(one, anotherOne));
		Assert.IsFalse(PreciseNumber.Equal(one, zero));
	}

	[TestMethod]
	public void Test_StaticNotEqual()
	{
		var one = PreciseNumber.One;
		var anotherOne = 1.ToPreciseNumber();
		var zero = PreciseNumber.Zero;
		Assert.IsTrue(PreciseNumber.NotEqual(one, zero));
		Assert.IsFalse(PreciseNumber.NotEqual(one, anotherOne));
	}

	// Test for static Max method
	[TestMethod]
	public void Test_StaticMax()
	{
		var one = PreciseNumber.One;
		var zero = PreciseNumber.Zero;
		var result = PreciseNumber.Max(one, zero);
		Assert.AreEqual(one, result);
	}

	// Test for static Min method
	[TestMethod]
	public void Test_StaticMin()
	{
		var one = PreciseNumber.One;
		var zero = PreciseNumber.Zero;
		var result = PreciseNumber.Min(one, zero);
		Assert.AreEqual(zero, result);
	}

	// Test for static Clamp method
	[TestMethod]
	public void Test_StaticClamp()
	{
		var value = 5.ToPreciseNumber();
		var min = 3.ToPreciseNumber();
		var max = 7.ToPreciseNumber();

		var result = PreciseNumber.Clamp(value, min, max);
		Assert.AreEqual(value, result);

		result = PreciseNumber.Clamp(2.ToPreciseNumber(), min, max);
		Assert.AreEqual(min, result);

		result = PreciseNumber.Clamp(8.ToPreciseNumber(), min, max);
		Assert.AreEqual(max, result);
	}

	// Test for static Round method
	[TestMethod]
	public void Test_StaticRound()
	{
		var number = 1.2345.ToPreciseNumber();
		var result = PreciseNumber.Round(number, 2);
		Assert.AreEqual(1.24.ToPreciseNumber(), result);
	}

	[TestMethod]
	public void Test_TryConvertFromChecked()
	{
		var one = PreciseNumber.One;
		Assert.ThrowsException<NotSupportedException>(() => PreciseNumber.TryConvertFromChecked(one, out var result));
	}

	[TestMethod]
	public void Test_TryConvertFromSaturating()
	{
		var one = PreciseNumber.One;
		Assert.ThrowsException<NotSupportedException>(() => PreciseNumber.TryConvertFromSaturating(one, out var result));
	}

	[TestMethod]
	public void Test_TryConvertFromTruncating()
	{
		var one = PreciseNumber.One;
		Assert.ThrowsException<NotSupportedException>(() => PreciseNumber.TryConvertFromTruncating(one, out var result));
	}

	[TestMethod]
	public void Test_TryConvertToChecked()
	{
		var one = PreciseNumber.One;
		Assert.ThrowsException<NotSupportedException>(() => PreciseNumber.TryConvertToChecked(one, out PreciseNumber result));
	}

	[TestMethod]
	public void Test_TryConvertToSaturating()
	{
		var one = PreciseNumber.One;
		Assert.ThrowsException<NotSupportedException>(() => PreciseNumber.TryConvertToSaturating(one, out PreciseNumber result));
	}

	[TestMethod]
	public void Test_TryConvertToTruncating()
	{
		var one = PreciseNumber.One;
		Assert.ThrowsException<NotSupportedException>(() => PreciseNumber.TryConvertToTruncating(one, out PreciseNumber result));
	}

	[TestMethod]
	public void Test_IsCanonical()
	{
		var one = PreciseNumber.One;
		Assert.IsTrue(PreciseNumber.IsCanonical(one));
	}

	[TestMethod]
	public void Test_IsComplexNumber()
	{
		var one = PreciseNumber.One;
		Assert.IsFalse(PreciseNumber.IsComplexNumber(one));
	}

	[TestMethod]
	public void Test_IsEvenInteger()
	{
		var two = 2.ToPreciseNumber();
		Assert.IsTrue(PreciseNumber.IsEvenInteger(two));

		var one = PreciseNumber.One;
		Assert.IsFalse(PreciseNumber.IsEvenInteger(one));
	}

	[TestMethod]
	public void Test_IsFinite()
	{
		var one = PreciseNumber.One;
		Assert.IsTrue(PreciseNumber.IsFinite(one));
	}

	[TestMethod]
	public void Test_IsImaginaryNumber()
	{
		var one = PreciseNumber.One;
		Assert.IsFalse(PreciseNumber.IsImaginaryNumber(one));
	}

	[TestMethod]
	public void Test_IsInfinity()
	{
		var one = PreciseNumber.One;
		Assert.IsFalse(PreciseNumber.IsInfinity(one));
	}

	[TestMethod]
	public void Test_IsInteger()
	{
		var one = PreciseNumber.One;
		Assert.IsTrue(PreciseNumber.IsInteger(one));
	}

	[TestMethod]
	public void Test_IsNaN()
	{
		var one = PreciseNumber.One;
		Assert.IsFalse(PreciseNumber.IsNaN(one));
	}

	[TestMethod]
	public void Test_IsNegative()
	{
		var negativeOne = PreciseNumber.NegativeOne;
		Assert.IsTrue(PreciseNumber.IsNegative(negativeOne));

		var one = PreciseNumber.One;
		Assert.IsFalse(PreciseNumber.IsNegative(one));
	}

	[TestMethod]
	public void Test_IsNegativeInfinity()
	{
		var negativeOne = PreciseNumber.NegativeOne;
		Assert.IsFalse(PreciseNumber.IsNegativeInfinity(negativeOne));
	}

	[TestMethod]
	public void Test_IsNormal()
	{
		var one = PreciseNumber.One;
		Assert.IsTrue(PreciseNumber.IsNormal(one));
	}

	[TestMethod]
	public void Test_IsOddInteger()
	{
		var one = PreciseNumber.One;
		Assert.IsTrue(PreciseNumber.IsOddInteger(one));

		var two = 2.ToPreciseNumber();
		Assert.IsFalse(PreciseNumber.IsOddInteger(two));
	}

	[TestMethod]
	public void Test_IsPositive()
	{
		var one = PreciseNumber.One;
		Assert.IsTrue(PreciseNumber.IsPositive(one));

		var negativeOne = PreciseNumber.NegativeOne;
		Assert.IsFalse(PreciseNumber.IsPositive(negativeOne));
	}

	[TestMethod]
	public void Test_IsPositiveInfinity()
	{
		var one = PreciseNumber.One;
		Assert.IsFalse(PreciseNumber.IsPositiveInfinity(one));
	}

	[TestMethod]
	public void Test_IsRealNumber()
	{
		var one = PreciseNumber.One;
		Assert.IsTrue(PreciseNumber.IsRealNumber(one));
	}

	[TestMethod]
	public void Test_IsSubnormal()
	{
		var one = PreciseNumber.One;
		Assert.IsFalse(PreciseNumber.IsSubnormal(one));
	}

	[TestMethod]
	public void Test_IsZero()
	{
		var zero = PreciseNumber.Zero;
		Assert.IsTrue(PreciseNumber.IsZero(zero));

		var one = PreciseNumber.One;
		Assert.IsFalse(PreciseNumber.IsZero(one));
	}

	[TestMethod]
	public void Test_TryParse_ReadOnlySpan()
	{
		Assert.ThrowsException<NotSupportedException>(() => PreciseNumber.TryParse("1.23e2".AsSpan(), NumberStyles.Float, CultureInfo.InvariantCulture, out var result));
	}

	[TestMethod]
	public void Test_TryParse_String_Style_Provider()
	{
		string input = "1.23e2";
		Assert.ThrowsException<NotSupportedException>(() => PreciseNumber.TryParse(input, NumberStyles.Float, CultureInfo.InvariantCulture, out var result));
	}

	[TestMethod]
	public void Test_TryParse_String_Provider()
	{
		string input = "1.23e2";
		Assert.ThrowsException<NotSupportedException>(() => PreciseNumber.TryParse(input, CultureInfo.InvariantCulture, out var result));
	}

	[TestMethod]
	public void Test_TryParse_ReadOnlySpan_Provider()
	{
		Assert.ThrowsException<NotSupportedException>(() => PreciseNumber.TryParse("1.23e2".AsSpan(), CultureInfo.InvariantCulture, out var result));
	}

	[TestMethod]
	public void Test_Parse_ReadOnlySpan_Style_Provider()
	{
		Assert.ThrowsException<NotSupportedException>(() => PreciseNumber.Parse("1.23e2".AsSpan(), NumberStyles.Float, CultureInfo.InvariantCulture));
	}

	[TestMethod]
	public void Test_Parse_String_Style_Provider()
	{
		string input = "1.23e2";
		Assert.ThrowsException<NotSupportedException>(() => PreciseNumber.Parse(input, NumberStyles.Float, CultureInfo.InvariantCulture));
	}

	[TestMethod]
	public void Test_Parse_String_Provider()
	{
		string input = "1.23e2";
		Assert.ThrowsException<NotSupportedException>(() => PreciseNumber.Parse(input, CultureInfo.InvariantCulture));
	}

	[TestMethod]
	public void Test_Parse_ReadOnlySpan_Provider()
	{
		Assert.ThrowsException<NotSupportedException>(() => PreciseNumber.Parse("1.23e2".AsSpan(), CultureInfo.InvariantCulture));
	}

	[TestMethod]
	public void Test_StaticMaxMagnitude()
	{
		var one = PreciseNumber.One;
		var negativeOne = PreciseNumber.NegativeOne;
		var result = PreciseNumber.MaxMagnitude(one, negativeOne);
		Assert.AreEqual(one, result);
	}

	[TestMethod]
	public void Test_StaticMaxMagnitudeNumber()
	{
		var one = PreciseNumber.One;
		var negativeOne = PreciseNumber.NegativeOne;
		var result = PreciseNumber.MaxMagnitudeNumber(one, negativeOne);
		Assert.AreEqual(one, result);
	}

	[TestMethod]
	public void Test_StaticMinMagnitude()
	{
		var one = PreciseNumber.One;
		var negativeOne = PreciseNumber.NegativeOne;
		var result = PreciseNumber.MinMagnitude(one, negativeOne);
		Assert.AreEqual(one, result);
	}

	[TestMethod]
	public void Test_StaticMinMagnitudeNumber()
	{
		var one = PreciseNumber.One;
		var negativeOne = PreciseNumber.NegativeOne;
		var result = PreciseNumber.MinMagnitudeNumber(one, negativeOne);
		Assert.AreEqual(one, result);
	}

	[TestMethod]
	public void Test_CompareTo_Object()
	{
		var one = PreciseNumber.One;
		var zero = PreciseNumber.Zero;
		object oneObject = PreciseNumber.One;
		object zeroObject = PreciseNumber.Zero;
		object intObject = 1;
		Assert.IsTrue(one.CompareTo(oneObject) == 0);
		Assert.IsTrue(one.CompareTo(zeroObject) > 0);
		Assert.IsTrue(zero.CompareTo(oneObject) < 0);
		Assert.ThrowsException<NotSupportedException>(() => one.CompareTo(intObject));
	}

	[TestMethod]
	public void Test_CompareTo_PreciseNumber()
	{
		var one = PreciseNumber.One;
		var zero = PreciseNumber.Zero;
		var anotherOne = PreciseNumber.One;

		Assert.IsTrue(one.CompareTo(zero) > 0);
		Assert.IsTrue(zero.CompareTo(one) < 0);
		Assert.IsTrue(one.CompareTo(anotherOne) == 0);
	}

	[TestMethod]
	public void Test_CompareTo_INumber()
	{
		var one = PreciseNumber.One;
		var zero = PreciseNumber.Zero;
		var anotherOne = PreciseNumber.One;

		Assert.IsTrue(one.CompareTo<PreciseNumber>(zero) > 0);
		Assert.IsTrue(zero.CompareTo<PreciseNumber>(one) < 0);
		Assert.IsTrue(one.CompareTo<PreciseNumber>(anotherOne) == 0);

		Assert.IsTrue(one.CompareTo(0) > 0);
		Assert.IsTrue(zero.CompareTo(1) < 0);
		Assert.IsTrue(one.CompareTo(1) == 0);

		Assert.IsTrue(one.CompareTo(0.0) > 0);
		Assert.IsTrue(zero.CompareTo(1.0) < 0);
		Assert.IsTrue(one.CompareTo(1.0) == 0);
	}

	[TestMethod]
	public void Test_Constructor_PositiveNumber()
	{
		var number = new PreciseNumber(2, 123);
		Assert.AreEqual(123, number.Significand);
		Assert.AreEqual(2, number.Exponent);
		Assert.AreEqual(3, number.SignificantDigits);
	}

	[TestMethod]
	public void Test_Constructor_NegativeNumber()
	{
		var number = new PreciseNumber(2, -123);
		Assert.AreEqual(-123, number.Significand);
		Assert.AreEqual(2, number.Exponent);
		Assert.AreEqual(3, number.SignificantDigits);
	}

	[TestMethod]
	public void Test_Constructor_Zero()
	{
		var number = new PreciseNumber(2, 0);
		Assert.AreEqual(0, number.Significand);
		Assert.AreEqual(0, number.Exponent);
		Assert.AreEqual(0, number.SignificantDigits);
	}

	[TestMethod]
	public void Test_Constructor_SanitizeTrue()
	{
		var number = new PreciseNumber(2, 12300, true);
		Assert.AreEqual(123, number.Significand);
		Assert.AreEqual(4, number.Exponent);
		Assert.AreEqual(3, number.SignificantDigits);
	}

	[TestMethod]
	public void Test_Constructor_SanitizeFalse()
	{
		var number = new PreciseNumber(2, 12300, false);
		Assert.AreEqual(12300, number.Significand);
		Assert.AreEqual(2, number.Exponent);
		Assert.AreEqual(5, number.SignificantDigits);
	}

	[TestMethod]
	public void Test_CreateFromFloatingPoint_PositiveNumber()
	{
		var number = PreciseNumber.CreateFromFloatingPoint(123000.45);
		Assert.AreEqual(12300045, number.Significand);
		Assert.AreEqual(-2, number.Exponent);
		Assert.AreEqual(8, number.SignificantDigits);

		var input = (Half)1000.0;
		number = PreciseNumber.CreateFromFloatingPoint(input);
		Assert.AreEqual(1, number.Significand);
		Assert.AreEqual(3, number.Exponent);
		Assert.AreEqual(1, number.SignificantDigits);
	}

	[TestMethod]
	public void Test_CreateFromFloatingPoint_NegativeNumber()
	{
		var number = PreciseNumber.CreateFromFloatingPoint(-123000.45);
		Assert.AreEqual(-12300045, number.Significand);
		Assert.AreEqual(-2, number.Exponent);
		Assert.AreEqual(8, number.SignificantDigits);
	}

	[TestMethod]
	public void Test_CreateFromFloatingPoint_One()
	{
		var number = PreciseNumber.CreateFromFloatingPoint(1.0);
		Assert.AreEqual(1, number.Significand);
		Assert.AreEqual(0, number.Exponent);
		Assert.AreEqual(1, number.SignificantDigits);
	}

	[TestMethod]
	public void Test_CreateFromFloatingPoint_NegativeOne()
	{
		var number = PreciseNumber.CreateFromFloatingPoint(-1.0);
		Assert.AreEqual(-1, number.Significand);
		Assert.AreEqual(0, number.Exponent);
		Assert.AreEqual(1, number.SignificantDigits);
	}

	[TestMethod]
	public void Test_CreateFromFloatingPoint_Zero()
	{
		var number = PreciseNumber.CreateFromFloatingPoint(0000.0);
		Assert.AreEqual(0, number.Significand);
		Assert.AreEqual(0, number.Exponent);
		Assert.AreEqual(0, number.SignificantDigits);
	}

	[TestMethod]
	public void Test_CreateFromInteger_PositiveNumber()
	{
		var number = PreciseNumber.CreateFromInteger(123000);
		Assert.AreEqual(123, number.Significand);
		Assert.AreEqual(3, number.Exponent);
		Assert.AreEqual(3, number.SignificantDigits);
	}

	[TestMethod]
	public void Test_CreateFromInteger_NegativeNumber()
	{
		var number = PreciseNumber.CreateFromInteger(-123000);
		Assert.AreEqual(-123, number.Significand);
		Assert.AreEqual(3, number.Exponent);
		Assert.AreEqual(3, number.SignificantDigits);
	}

	[TestMethod]
	public void Test_CreateFromInteger_One()
	{
		var number = PreciseNumber.CreateFromInteger(1);
		Assert.AreEqual(1, number.Significand);
		Assert.AreEqual(0, number.Exponent);
		Assert.AreEqual(1, number.SignificantDigits);
	}

	[TestMethod]
	public void Test_CreateFromInteger_NegativeOne()
	{
		var number = PreciseNumber.CreateFromInteger(-1);
		Assert.AreEqual(-1, number.Significand);
		Assert.AreEqual(0, number.Exponent);
		Assert.AreEqual(1, number.SignificantDigits);
	}

	[TestMethod]
	public void Test_CreateFromInteger_Zero()
	{
		var number = PreciseNumber.CreateFromInteger(0000);
		Assert.AreEqual(0, number.Significand);
		Assert.AreEqual(0, number.Exponent);
		Assert.AreEqual(0, number.SignificantDigits);
	}

	[TestMethod]
	public void Test_MaximumBigInteger()
	{
		var maxBigInt = BigInteger.Parse("79228162514264337593543950335"); // Decimal.MaxValue
		var number = new PreciseNumber(0, maxBigInt);
		Assert.AreEqual(maxBigInt, number.Significand);
	}

	[TestMethod]
	public void Test_MinimumBigInteger()
	{
		var minBigInt = BigInteger.Parse("-79228162514264337593543950335"); // Decimal.MinValue
		var number = new PreciseNumber(0, minBigInt);
		Assert.AreEqual(minBigInt, number.Significand);
	}

	[TestMethod]
	public void Test_NegativeExponent()
	{
		var number = new PreciseNumber(-5, 12345);
		Assert.AreEqual(12345, number.Significand);
		Assert.AreEqual(-5, number.Exponent);
	}

	[TestMethod]
	public void Test_TrailingZerosBoundary()
	{
		var number = new PreciseNumber(2, 123000, true);
		Assert.AreEqual(123, number.Significand);
		Assert.AreEqual(5, number.Exponent);
	}

	[TestMethod]
	public void Test_ToString_WithFormat()
	{
		var number = new PreciseNumber(2, 12345);
		string str = number.ToString("G");
		Assert.AreEqual("1234500", str);
	}

	[TestMethod]
	public void Test_ToString_WithDifferentCulture()
	{
		var number = new PreciseNumber(-2, 12345);
		string str = number.ToString(CultureInfo.GetCultureInfo("fr-FR"));
		Assert.AreEqual("123,45", str);
	}

	[TestMethod]
	public void Test_Parse_WithDifferentCulture()
	{
		string str = "123,45";
		var culture = CultureInfo.GetCultureInfo("fr-FR");
		Assert.ThrowsException<NotSupportedException>(() => PreciseNumber.Parse(str.AsSpan(), culture));
	}

	[TestMethod]
	public void Test_Addition_WithLargeNumbers()
	{
		var largeNum1 = PreciseNumber.CreateFromInteger(BigInteger.Parse("79228162514264337593543950335"));
		var largeNum2 = PreciseNumber.CreateFromInteger(BigInteger.Parse("79228162514264337593543950335"));
		var result = largeNum1 + largeNum2;
		Assert.AreEqual(BigInteger.Parse("15845632502852867518708790067"), result.Significand);
		Assert.AreEqual(1, result.Exponent);
	}

	[TestMethod]
	public void Test_Subtraction_WithLargeNumbers()
	{
		var largeNum1 = PreciseNumber.CreateFromInteger(BigInteger.Parse("79228162514264337593543950335"));
		var largeNum2 = PreciseNumber.CreateFromInteger(BigInteger.Parse("39228162514264337593543950335"));
		var result = largeNum1 - largeNum2;
		Assert.AreEqual(4, result.Significand);
		Assert.AreEqual(28, result.Exponent);
	}

	[TestMethod]
	public void Test_Multiplication_WithSmallNumbers()
	{
		var smallNum1 = PreciseNumber.CreateFromFloatingPoint(0.00001);
		var smallNum2 = PreciseNumber.CreateFromFloatingPoint(0.00002);
		var result = smallNum1 * smallNum2;
		Assert.AreEqual(2, result.Significand);
		Assert.AreEqual(-10, result.Exponent);
	}

	[TestMethod]
	public void Test_Division_WithSmallNumbers()
	{
		var smallNum1 = PreciseNumber.CreateFromFloatingPoint(0.00002);
		var smallNum2 = PreciseNumber.CreateFromFloatingPoint(0.00001);
		var result = smallNum1 / smallNum2;
		Assert.AreEqual(2, result.Significand);
		Assert.AreEqual(0, result.Exponent);
	}

	[TestMethod]
	public void Test_Radix()
	{
		Assert.AreEqual(2, PreciseNumber.Radix);
	}

	[TestMethod]
	public void Test_AdditiveIdentity()
	{
		var additiveIdentity = PreciseNumber.AdditiveIdentity;
		Assert.AreEqual(PreciseNumber.Zero, additiveIdentity);
	}

	[TestMethod]
	public void Test_MultiplicativeIdentity()
	{
		var multiplicativeIdentity = PreciseNumber.MultiplicativeIdentity;
		Assert.AreEqual(PreciseNumber.One, multiplicativeIdentity);
	}

	[TestMethod]
	public void Test_CreateRepeatingDigits()
	{
		var result = PreciseNumber.CreateRepeatingDigits(5, 3);
		Assert.AreEqual(new BigInteger(555), result);

		result = PreciseNumber.CreateRepeatingDigits(7, 0);
		Assert.AreEqual(new BigInteger(0), result);
	}

	[TestMethod]
	public void Test_HasInfinitePrecision()
	{
		var number = PreciseNumber.One;
		Assert.IsTrue(number.HasInfinitePrecision);

		number = new PreciseNumber(0, new BigInteger(2));
		Assert.IsFalse(number.HasInfinitePrecision);
	}

	[TestMethod]
	public void Test_LowestDecimalDigits()
	{
		var number1 = new PreciseNumber(-2, 12345);
		var number2 = new PreciseNumber(-3, 678);
		int result = PreciseNumber.LowestDecimalDigits(number1, number2);
		Assert.AreEqual(2, result);
	}

	[TestMethod]
	public void Test_LowestSignificantDigits()
	{
		var number1 = new PreciseNumber(0, 12345);
		var number2 = new PreciseNumber(0, 678);
		int result = PreciseNumber.LowestSignificantDigits(number1, number2);
		Assert.AreEqual(3, result);
	}

	[TestMethod]
	public void Test_CountDecimalDigits()
	{
		var number = new PreciseNumber(-2, 12345);
		int result = number.CountDecimalDigits();
		Assert.AreEqual(2, result);
	}

	[TestMethod]
	public void Test_ReduceSignificance()
	{
		var number = new PreciseNumber(0, 12345);
		var result = number.ReduceSignificance(3);
		Assert.AreEqual(124, result.Significand);
		Assert.AreEqual(2, result.Exponent);
		Assert.AreEqual(number, number.ReduceSignificance(5));
	}

	[TestMethod]
	public void Test_MakeCommonizedAndGetExponent()
	{
		var number1 = new PreciseNumber(1, 123);
		var number2 = new PreciseNumber(3, 456);
		int result = PreciseNumber.MakeCommonizedAndGetExponent(ref number1, ref number2);
		Assert.AreEqual(1, result);
		Assert.AreEqual(123, number1.Significand);
		Assert.AreEqual(45600, number2.Significand);
	}

	[TestMethod]
	public void Test_Abs_Static()
	{
		var negative = PreciseNumber.NegativeOne;
		var result = PreciseNumber.Abs(negative);
		Assert.AreEqual(PreciseNumber.One, result);
	}

	[TestMethod]
	public void Test_AssertExponentsMatch()
	{
		var number1 = new PreciseNumber(1, 123);
		var number2 = new PreciseNumber(1, 456);
		PreciseNumber.AssertExponentsMatch(number1, number2);
		// No assertion needed, just ensure no exception is thrown
	}

	[TestMethod]
	public void Test_OperatorNegate()
	{
		var number = PreciseNumber.One;
		var result = -number;
		Assert.AreEqual(PreciseNumber.NegativeOne, result);
	}

	[TestMethod]
	public void Test_OperatorAdd()
	{
		var number1 = new PreciseNumber(-2, 12345);
		var number2 = new PreciseNumber(-3, 678);
		var result = number1 + number2;
		Assert.AreEqual(124128, result.Significand);
		Assert.AreEqual(-3, result.Exponent);
	}

	[TestMethod]
	public void Test_OperatorSubtract()
	{
		var number1 = new PreciseNumber(-2, 12345);
		var number2 = new PreciseNumber(-3, 678);
		var result = number1 - number2;
		Assert.AreEqual(122772, result.Significand);
		Assert.AreEqual(-3, result.Exponent);
	}

	[TestMethod]
	public void Test_OperatorMultiply()
	{
		var number1 = new PreciseNumber(-2, 12345);
		var number2 = new PreciseNumber(-3, 678);
		var result = number1 * number2;
		Assert.AreEqual(836991, result.Significand);
		Assert.AreEqual(-4, result.Exponent);
	}

	[TestMethod]
	public void Test_OperatorDivide()
	{
		var number1 = new PreciseNumber(-2, 12345);
		var number2 = new PreciseNumber(-3, 678);
		var result = number1 / number2;
		Assert.AreEqual(BigInteger.Parse("18207964601769911504"), result.Significand);
		Assert.AreEqual(-17, result.Exponent);
	}

	[TestMethod]
	public void Test_OperatorGreaterThan()
	{
		var number1 = new PreciseNumber(0, 12345);
		var number2 = new PreciseNumber(0, 678);
		Assert.IsTrue(number1 > number2);
	}

	[TestMethod]
	public void Test_OperatorLessThan()
	{
		var number1 = new PreciseNumber(0, 123);
		var number2 = new PreciseNumber(0, 678);
		Assert.IsTrue(number1 < number2);
	}

	[TestMethod]
	public void Test_OperatorGreaterThanOrEqual()
	{
		var number1 = new PreciseNumber(0, 12345);
		var number2 = new PreciseNumber(0, 12345);
		Assert.IsTrue(number1 >= number2);
	}

	[TestMethod]
	public void Test_OperatorLessThanOrEqual()
	{
		var number1 = new PreciseNumber(0, 123);
		var number2 = new PreciseNumber(0, 678);
		Assert.IsTrue(number1 <= number2);
	}

	[TestMethod]
	public void Test_OperatorEqual()
	{
		var number1 = new PreciseNumber(0, 12345);
		var number2 = new PreciseNumber(0, 12345);
		Assert.IsTrue(number1 == number2);
	}

	[TestMethod]
	public void Test_OperatorNotEqual()
	{
		var number1 = new PreciseNumber(0, 12345);
		var number2 = new PreciseNumber(0, 678);
		Assert.IsTrue(number1 != number2);
	}

	[TestMethod]
	public void Test_GetHashCode()
	{
		var number1 = new PreciseNumber(2, 12345);
		var number2 = new PreciseNumber(2, 12345);
		var number3 = new PreciseNumber(3, 12345);

		// Test if the same values produce the same hash code
		Assert.AreEqual(number1.GetHashCode(), number2.GetHashCode());

		// Test if different values produce different hash codes
		Assert.AreNotEqual(number1.GetHashCode(), number3.GetHashCode());

		// Additional edge cases
		var zero = PreciseNumber.Zero;
		var one = PreciseNumber.One;
		var negativeOne = PreciseNumber.NegativeOne;

		Assert.AreEqual(zero.GetHashCode(), PreciseNumber.Zero.GetHashCode());
		Assert.AreEqual(one.GetHashCode(), PreciseNumber.One.GetHashCode());
		Assert.AreEqual(negativeOne.GetHashCode(), PreciseNumber.NegativeOne.GetHashCode());
	}

	[TestMethod]
	public void Test_Equals_Object_SameInstance()
	{
		var number = PreciseNumber.One;
		Assert.IsTrue(number.Equals((object)number));
	}

	[TestMethod]
	public void Test_Equals_Object_EquivalentInstance()
	{
		var number1 = PreciseNumber.One;
		var number2 = new PreciseNumber(0, 1);
		Assert.IsTrue(number1.Equals((object)number2));
	}

	[TestMethod]
	public void Test_Equals_Object_DifferentInstance()
	{
		var number1 = PreciseNumber.One;
		var number2 = PreciseNumber.Zero;
		Assert.IsFalse(number1.Equals((object)number2));
	}

	[TestMethod]
	public void Test_Equals_Object_Null()
	{
		var number = PreciseNumber.One;
		Assert.IsFalse(number.Equals(null));
	}

	[TestMethod]
	public void Test_Equals_Object_DifferentType()
	{
		var number = PreciseNumber.One;
		string differentType = "1";
		Assert.IsFalse(number.Equals(differentType));
	}

	[TestMethod]
	public void Test_ToString_WithFormat_AndInvariantCulture()
	{
		var number = new PreciseNumber(-2, 12345);
		string result = number.ToString("G", CultureInfo.InvariantCulture);
		Assert.AreEqual("123.45", result);
	}

	[TestMethod]
	public void Test_ToString_WithFormat_AndSpecificCulture()
	{
		var number = new PreciseNumber(-2, 12345);
		string result = number.ToString("G", CultureInfo.GetCultureInfo("fr-FR"));
		Assert.AreEqual("123,45", result);
	}

	[TestMethod]
	public void Test_ToString_WithNullFormat_AndInvariantCulture()
	{
		var number = new PreciseNumber(3, 12345);
		string result = number.ToString(null, CultureInfo.InvariantCulture);
		Assert.AreEqual("12345000", result);
	}

	[TestMethod]
	public void Test_ToString_WithNullFormat_AndSpecificCulture()
	{
		var number = new PreciseNumber(3, 12345);
		string result = number.ToString(null, CultureInfo.GetCultureInfo("fr-FR"));
		Assert.AreEqual("12345000", result);
	}

	[TestMethod]
	public void Test_ToString_WithEmptyFormat_AndInvariantCulture()
	{
		var number = new PreciseNumber(-2, 12345);
		string result = number.ToString("", CultureInfo.InvariantCulture);
		Assert.AreEqual("123.45", result);
	}

	[TestMethod]
	public void Test_ToString_WithEmptyFormat_AndSpecificCulture()
	{
		var number = new PreciseNumber(-2, 12345);
		string result = number.ToString("", CultureInfo.GetCultureInfo("fr-FR"));
		Assert.AreEqual("123,45", result);
	}

	[TestMethod]
	public void Test_TryFormat_SufficientBuffer()
	{
		var number = new PreciseNumber(-2, 12345);
		Span<char> buffer = stackalloc char[50];
		string format = "G";
		bool result = number.TryFormat(buffer, out int charsWritten, format.AsSpan(), CultureInfo.InvariantCulture);

		Assert.IsTrue(result);
		Assert.AreEqual("123.45", buffer[..charsWritten].ToString());
	}

	[TestMethod]
	public void Test_TryFormat_InsufficientBuffer()
	{
		var number = new PreciseNumber(-2, 12345);
		Span<char> buffer = stackalloc char[4];
		string format = "G";
		bool result = number.TryFormat(buffer, out int charsWritten, format.AsSpan(), CultureInfo.InvariantCulture);

		Assert.IsFalse(result);
		Assert.AreEqual(0, charsWritten);
	}

	[TestMethod]
	public void Test_TryFormat_EmptyFormat()
	{
		var number = new PreciseNumber(-2, 12345);
		Span<char> buffer = stackalloc char[50];
		string format = string.Empty;
		bool result = number.TryFormat(buffer, out int charsWritten, format.AsSpan(), CultureInfo.InvariantCulture);

		Assert.IsTrue(result);
		Assert.AreEqual("123.45", buffer[..charsWritten].ToString());
	}

	[TestMethod]
	public void Test_TryFormat_InvalidFormat()
	{
		var number = new PreciseNumber(-2, 12345);
		Assert.ThrowsException<FormatException>(() => number.TryFormat(stackalloc char[50], out int charsWritten, "e", CultureInfo.InvariantCulture));
	}

	[TestMethod]
	public void Test_TryFormat_NullFormatProvider()
	{
		var number = new PreciseNumber(-2, 12345);
		Span<char> buffer = stackalloc char[50];
		string format = "G";
		bool result = number.TryFormat(buffer, out int charsWritten, format.AsSpan(), null);

		Assert.IsTrue(result);
		Assert.AreEqual("123.45", buffer[..charsWritten].ToString());
	}

	[TestMethod]
	public void Test_TryFormat_SpecificCulture()
	{
		var number = new PreciseNumber(-2, 12345);
		Span<char> buffer = stackalloc char[50];
		string format = "G";
		bool result = number.TryFormat(buffer, out int charsWritten, format.AsSpan(), CultureInfo.GetCultureInfo("fr-FR"));

		Assert.IsTrue(result);
		Assert.AreEqual("123,45", buffer[..charsWritten].ToString());
	}

	[TestMethod]
	public void Test_TryFormat_Zero()
	{
		var number = PreciseNumber.Zero;
		Span<char> buffer = stackalloc char[50];
		string format = "G";
		bool result = number.TryFormat(buffer, out int charsWritten, format.AsSpan(), CultureInfo.InvariantCulture);

		Assert.IsTrue(result);
		Assert.AreEqual("0", buffer[..charsWritten].ToString());
	}

	[TestMethod]
	public void Test_TryFormat_One()
	{
		var number = PreciseNumber.One;
		Span<char> buffer = stackalloc char[50];
		string format = "G";
		bool result = number.TryFormat(buffer, out int charsWritten, format.AsSpan(), CultureInfo.InvariantCulture);

		Assert.IsTrue(result);
		Assert.AreEqual("1", buffer[..charsWritten].ToString());
	}

	[TestMethod]
	public void Test_TryFormat_NegativeOne()
	{
		var number = PreciseNumber.NegativeOne;
		Span<char> buffer = stackalloc char[50];
		string format = "G";
		bool result = number.TryFormat(buffer, out int charsWritten, format.AsSpan(), CultureInfo.InvariantCulture);

		Assert.IsTrue(result);
		Assert.AreEqual("-1", buffer[..charsWritten].ToString());
	}

	[TestMethod]
	public void Test_TryFormat_Integer()
	{
		var number = 3.ToPreciseNumber();
		Span<char> buffer = stackalloc char[50];
		string format = "G";
		bool result = number.TryFormat(buffer, out int charsWritten, format.AsSpan(), CultureInfo.InvariantCulture);

		Assert.IsTrue(result);
		Assert.AreEqual("3", buffer[..charsWritten].ToString());
	}

	[TestMethod]
	public void Test_TryFormat_Float()
	{
		var number = 3.0.ToPreciseNumber();
		Span<char> buffer = stackalloc char[50];
		string format = "G";
		bool result = number.TryFormat(buffer, out int charsWritten, format.AsSpan(), CultureInfo.InvariantCulture);

		Assert.IsTrue(result);
		Assert.AreEqual("3", buffer[..charsWritten].ToString());
	}

	[TestMethod]
	public void Test_Add_LargeNumbers()
	{
		var largeNumber1 = new PreciseNumber(100, BigInteger.Parse("79228162514264337593543950335"));
		var largeNumber2 = new PreciseNumber(100, BigInteger.Parse("79228162514264337593543950335"));
		var result = largeNumber1 + largeNumber2;
		Assert.AreEqual(BigInteger.Parse("15845632502852867518708790067"), result.Significand);
		Assert.AreEqual(101, result.Exponent);
	}

	[TestMethod]
	public void Test_Subtract_LargeNumbers()
	{
		var largeNumber1 = new PreciseNumber(100, BigInteger.Parse("79228162514264337593543950335"));
		var largeNumber2 = new PreciseNumber(100, BigInteger.Parse("39228162514264337593543950335"));
		var result = largeNumber1 - largeNumber2;
		Assert.AreEqual(BigInteger.Parse("4"), result.Significand);
		Assert.AreEqual(128, result.Exponent);
	}

	[TestMethod]
	public void Test_Multiply_LargeNumbers()
	{
		var largeNumber1 = new PreciseNumber(50, BigInteger.Parse("79228162514264337593543950335"));
		var largeNumber2 = new PreciseNumber(50, BigInteger.Parse("2"));
		var result = largeNumber1 * largeNumber2;
		Assert.AreEqual(BigInteger.Parse("15845632502852867518708790067"), result.Significand);
		Assert.AreEqual(101, result.Exponent);
	}

	[TestMethod]
	public void Test_Divide_LargeNumbers()
	{
		var largeNumber1 = new PreciseNumber(100, BigInteger.Parse("79228162514264337593543950335"));
		var largeNumber2 = new PreciseNumber(1, BigInteger.Parse("2"));
		var result = largeNumber1 / largeNumber2;
		Assert.AreEqual(BigInteger.Parse("396140812571321687967719751675"), result.Significand);
		Assert.AreEqual(98, result.Exponent);
	}

	[TestMethod]
	public void Test_Add_Zero()
	{
		var zero = PreciseNumber.Zero;
		var one = PreciseNumber.One;
		var result = zero + one;
		Assert.AreEqual(one, result);
	}

	[TestMethod]
	public void Test_Subtract_Zero()
	{
		var zero = PreciseNumber.Zero;
		var one = PreciseNumber.One;
		var result = one - zero;
		Assert.AreEqual(one, result);
	}

	[TestMethod]
	public void Test_Multiply_Zero()
	{
		var zero = PreciseNumber.Zero;
		var one = PreciseNumber.One;
		var result = one * zero;
		Assert.AreEqual(zero, result);
	}

	[TestMethod]
	public void Test_Divide_Zero()
	{
		var zero = PreciseNumber.Zero;
		Assert.ThrowsException<DivideByZeroException>(() => zero / zero);
	}

	[TestMethod]
	public void Test_CreateFromFloatingPoint_SpecialValues()
	{
		Assert.ThrowsException<ArgumentOutOfRangeException>(() => PreciseNumber.CreateFromFloatingPoint(double.NaN));
		Assert.ThrowsException<ArgumentOutOfRangeException>(() => PreciseNumber.CreateFromFloatingPoint(double.PositiveInfinity));
		Assert.ThrowsException<ArgumentOutOfRangeException>(() => PreciseNumber.CreateFromFloatingPoint(double.NegativeInfinity));
	}

	[TestMethod]
	public void Test_CreateFromInteger_BoundaryValues()
	{
		var intMax = PreciseNumber.CreateFromInteger(int.MaxValue);
		Assert.AreEqual(BigInteger.Parse(int.MaxValue.ToString()), intMax.Significand);

		var intMin = PreciseNumber.CreateFromInteger(int.MinValue);
		Assert.AreEqual(BigInteger.Parse(int.MinValue.ToString()), intMin.Significand);

		var longMax = PreciseNumber.CreateFromInteger(long.MaxValue);
		Assert.AreEqual(BigInteger.Parse(long.MaxValue.ToString()), longMax.Significand);

		var longMin = PreciseNumber.CreateFromInteger(long.MinValue);
		Assert.AreEqual(BigInteger.Parse(long.MinValue.ToString()), longMin.Significand);
	}

	[TestMethod]
	public void Test_NegativeExponentHandling()
	{
		var number = new PreciseNumber(-3, 12345);
		Assert.AreEqual(12345, number.Significand);
		Assert.AreEqual(-3, number.Exponent);

		var result = number.Round(2);
		Assert.AreEqual(1235, result.Significand); // After rounding, check if the exponent and significand are adjusted correctly
		Assert.AreEqual(-2, result.Exponent);
	}

	[TestMethod]
	public void Test_HandlingTrailingZeros()
	{
		var number = new PreciseNumber(2, 123000, true);
		Assert.AreEqual(123, number.Significand);
		Assert.AreEqual(5, number.Exponent); // Ensure trailing zeros are removed and exponent is adjusted correctly

		number = new PreciseNumber(-2, 123000, true);
		Assert.AreEqual(123, number.Significand);
		Assert.AreEqual(1, number.Exponent);
	}

	[TestMethod]
	public void Test_ToString_VariousFormats()
	{
		var number = new PreciseNumber(-2, 12345);
		Assert.ThrowsException<FormatException>(() => number.ToString("E2", CultureInfo.InvariantCulture));
		Assert.ThrowsException<FormatException>(() => number.ToString("F2", CultureInfo.InvariantCulture));
		Assert.ThrowsException<FormatException>(() => number.ToString("N2", CultureInfo.InvariantCulture));
	}

	[TestMethod]
	public void Test_TryFormat_VariousFormats()
	{
		var number = new PreciseNumber(-2, 12345);
		Assert.ThrowsException<FormatException>(() => number.TryFormat(stackalloc char[50], out int charsWritten, "E2".AsSpan(), CultureInfo.InvariantCulture));
		Assert.ThrowsException<FormatException>(() => number.TryFormat(stackalloc char[50], out int charsWritten, "F2".AsSpan(), CultureInfo.InvariantCulture));
		Assert.ThrowsException<FormatException>(() => number.TryFormat(stackalloc char[50], out int charsWritten, "N2".AsSpan(), CultureInfo.InvariantCulture));
	}

	[TestMethod]
	public void To_Double()
	{
		var preciseNumber = new PreciseNumber(3, 12345); // 12345e3
		double result = preciseNumber.To<double>();
		Assert.AreEqual(12345e3, result);
	}

	[TestMethod]
	public void To_Float()
	{
		var preciseNumber = new PreciseNumber(2, 12345); // 12345e2
		float result = preciseNumber.To<float>();
		Assert.AreEqual(12345e2f, result);
	}

	[TestMethod]
	public void To_Decimal()
	{
		var preciseNumber = new PreciseNumber(1, 12345); // 12345e1
		decimal result = preciseNumber.To<decimal>();
		Assert.AreEqual(12345e1m, result);
	}

	[TestMethod]
	public void To_Int()
	{
		var preciseNumber = new PreciseNumber(0, 12345); // 12345e0
		int result = preciseNumber.To<int>();
		Assert.AreEqual(12345, result);
	}

	[TestMethod]
	public void To_Long()
	{
		var preciseNumber = new PreciseNumber(0, 123456789012345); // 123456789012345e0
		long result = preciseNumber.To<long>();
		Assert.AreEqual(123456789012345L, result);
	}

	[TestMethod]
	public void To_BigInteger()
	{
		var preciseNumber = new PreciseNumber(5, 12345); // 12345e5
		var result = preciseNumber.To<BigInteger>();
		Assert.AreEqual(BigInteger.Parse("1234500000"), result);
	}

	[TestMethod]
	public void To_Overflow()
	{
		var preciseNumber = new PreciseNumber(1000, 12345); // This is a very large number
		Assert.ThrowsException<OverflowException>(() => preciseNumber.To<int>()); // This should throw an exception
	}

	[TestMethod]
	public void Squared_ShouldReturnCorrectValue()
	{
		// Arrange
		var number = 3.ToPreciseNumber();
		var expected = 9.ToPreciseNumber();

		// Act
		var result = number.Squared();

		// Assert
		Assert.AreEqual(expected, result);
	}

	[TestMethod]
	public void Cubed_ShouldReturnCorrectValue()
	{
		// Arrange
		var number = 3.ToPreciseNumber();
		var expected = 27.ToPreciseNumber();

		// Act
		var result = number.Cubed();

		// Assert
		Assert.AreEqual(expected, result);
	}

	[TestMethod]
	public void Pow_ShouldReturnCorrectValue()
	{
		// Arrange
		var number = 2.ToPreciseNumber();
		var expected = 8.ToPreciseNumber();

		// Act
		var result = number.Pow(3.ToPreciseNumber());

		// Assert
		Assert.AreEqual(expected, result);

		Assert.AreEqual(PreciseNumber.One, PreciseNumber.One.Pow(10.ToPreciseNumber()));
		Assert.AreEqual(PreciseNumber.Zero, PreciseNumber.Zero.Pow(10.ToPreciseNumber()));

		result = number.Pow(2.5.ToPreciseNumber());
		expected = 5.656854249492381.ToPreciseNumber();
		Assert.AreEqual(expected, result);
	}

	[TestMethod]
	public void Pow_ZeroPower_ShouldReturnOne()
	{
		// Arrange
		var number = 5.ToPreciseNumber();
		var expected = PreciseNumber.One;

		// Act
		var result = number.Pow(0.ToPreciseNumber());

		// Assert
		Assert.AreEqual(expected, result);
	}

	[TestMethod]
	public void Pow_NegativePower_ShouldReturnCorrectValue()
	{
		// Arrange
		var number = 2.ToPreciseNumber();
		var expected = 0.125.ToPreciseNumber();

		// Act
		var result = number.Pow(-3.ToPreciseNumber());

		// Assert
		Assert.AreEqual(expected, result);
	}

	[TestMethod]
	public void TestExpWithZeroPower()
	{
		var result = PreciseNumber.Exp(0.ToPreciseNumber());
		var expected = PreciseNumber.One; // e^0 = 1
		Assert.AreEqual(expected, result);
	}

	[TestMethod]
	public void TestExpWithPositivePower()
	{
		var result = PreciseNumber.Exp(1.ToPreciseNumber());
		var expected = PreciseNumber.E; // e^1 = e
		Assert.AreEqual(expected, result);
	}

	[TestMethod]
	public void TestExpWithNegativePower()
	{
		var result = PreciseNumber.Exp(-1.ToPreciseNumber());
		var expected = PreciseNumber.One / PreciseNumber.E; // e^-1 = 1/e
		Assert.AreEqual(expected, result);
	}

	[TestMethod]
	public void TestExpWithLargePositivePower()
	{
		var result = PreciseNumber.Exp(5.ToPreciseNumber());
		var expected = 148.4131591025766m.ToPreciseNumber();
		Assert.AreEqual(expected, result);
	}

	[TestMethod]
	public void TestExpWithLargeNegativePower()
	{
		var result = PreciseNumber.Exp(-5.ToPreciseNumber());
		var expected = 0.006737946999085467m.ToPreciseNumber();
		Assert.AreEqual(expected, result);
	}

	[TestMethod]
	public void TestRoundWithSamePrecision()
	{
		var number = 1234.5.ToPreciseNumber();
		var result = number.Round(1);
		Assert.AreEqual(number, result);
	}

	[TestMethod]
	public void TestDivideByZero()
	{
		var number = 1234.5.ToPreciseNumber();
		Assert.ThrowsException<DivideByZeroException>(() => number / PreciseNumber.Zero);
		Assert.ThrowsException<DivideByZeroException>(() => PreciseNumber.PreciseDivide(number, PreciseNumber.Zero));
	}

	[TestMethod]
	public void TestDivideBySelf()
	{
		var number = 1234.5.ToPreciseNumber();
		var result = number / number;
		Assert.AreEqual(PreciseNumber.One, result);
		Assert.AreEqual(PreciseNumber.One, PreciseNumber.PreciseDivide(number, number));
	}

	[TestMethod]
	public void TestEasyMultiplies()
	{
		var two = 2.ToPreciseNumber();
		Assert.AreEqual(two, PreciseNumber.One * two);
		Assert.AreEqual(two, two * PreciseNumber.One);
		Assert.AreEqual(PreciseNumber.Zero, PreciseNumber.Zero * PreciseNumber.One);
		Assert.AreEqual(PreciseNumber.Zero, PreciseNumber.One * PreciseNumber.Zero);

		Assert.AreEqual(two, PreciseNumber.PreciseMultiply(PreciseNumber.One, two));
		Assert.AreEqual(two, PreciseNumber.PreciseMultiply(two, PreciseNumber.One));
		Assert.AreEqual(PreciseNumber.Zero, PreciseNumber.PreciseMultiply(PreciseNumber.Zero, PreciseNumber.One));
		Assert.AreEqual(PreciseNumber.Zero, PreciseNumber.PreciseMultiply(PreciseNumber.One, PreciseNumber.Zero));
	}
}
