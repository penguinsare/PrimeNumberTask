using PrimeNumberTask.Lib;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Xunit;
using Xunit.Abstractions;

namespace PrimeNumberTask.Tests
{
    public class UnitTest_PrimeNumberHelper
    {
        private readonly ITestOutputHelper _output;

        public UnitTest_PrimeNumberHelper(ITestOutputHelper output)
        {
            _output = output;
        }
        [Theory]
        [InlineData(-100)]
        [InlineData(-1)]
        [InlineData(0)]
        [InlineData(1)]
        public void ThrowsArgumentOutOfRangeExceptionWhenNumberSmallerThanOne(int number)
        {
            var exceptionMessage = "Since a prime number (or a prime) is defined as a natural number " +
                    "greater than 1, only numbers greater than 1 are accepted.";
            Action action = () => PrimeNumberHelper.IsPrimeNumber(number);
            Exception ex = Record.Exception(action);
            Assert.NotNull(ex);
            Assert.IsType<ArgumentOutOfRangeException>(ex);
            Assert.Equal(exceptionMessage, ((ArgumentOutOfRangeException)ex).ParamName);
        }

        [Theory]
        [MemberData(nameof(IsPrimeNumberDataTestData))]
        public void ReturnsTrueIfANumberIsAPrimeNumber(int number, bool expected)
        {
            var stopwatch = Stopwatch.StartNew();
            bool isPrimeResult = PrimeNumberHelper.IsPrimeNumber(number);
            stopwatch.Stop();
            _output.WriteLine($"Elapsed time for number {number} is {stopwatch.ElapsedMilliseconds} ms.");
            Assert.Equal(expected, isPrimeResult);
        }

        public static IEnumerable<object[]> IsPrimeNumberDataTestData()
        {
            yield return new object[] { 2, true };
            yield return new object[] { 3, true };
            yield return new object[] { 4, false };
            yield return new object[] { 5, true };
            yield return new object[] { 6, false };
            yield return new object[] { 7, true };
            yield return new object[] { 8, false };
            yield return new object[] { 9, false };
            yield return new object[] { 10, false };
            yield return new object[] { 11, true };
            yield return new object[] { 12, false };
            yield return new object[] { 13, true };
            yield return new object[] { 14, false };
            yield return new object[] { 15, false };
            yield return new object[] { 16, false };
            yield return new object[] { 17, true };
            yield return new object[] { 18, false };
            yield return new object[] { 19, true };
            yield return new object[] { 20, false };
            yield return new object[] { 21, false };
            yield return new object[] { 22, false };
            yield return new object[] { 23, true };
            yield return new object[] { 104728, false };
            yield return new object[] { 104729, true };
            yield return new object[] { 10009729, true };
            yield return new object[] { 2147483629, true };
        }
    }
}
