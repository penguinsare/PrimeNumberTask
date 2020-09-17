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
        public void IsPrimeNumber_NumberSmallerThanOne_ThrowArgumentOutOfRangeException(int number)
        {
            var exceptionMessage = "Since a prime number (or a prime) is defined as a natural number " +
            "greater than 1, only numbers greater than 1 are accepted. (Parameter 'number')";
            Action action = () => PrimeNumberHelper.IsPrimeNumber(number);

            Exception ex = Record.Exception(action);

            Assert.NotNull(ex);
            Assert.IsType<ArgumentOutOfRangeException>(ex);
            Assert.Equal(exceptionMessage, ((ArgumentOutOfRangeException)ex).Message);
        }

        [Theory]
        [MemberData(nameof(IsPrimeNumberDataTestData))]
        public void IsPrimeNumber_NumberIsPrimeAndBiggerThanOne_True(int number, bool expected)
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
            yield return new object[] { 2147483647, true };            
        }

        [Theory]
        [InlineData(-11)]
        [InlineData(-1)]
        public void FindNextPrimeNumberBiggerOrEqual_NumberSmallerThanZero_ThrowArgumentOutOfRangeException(int number)
        {
            var exceptionMessage = "Since a prime number (or a prime) is defined as a natural number " +
            "greater than 1, only numbers greater than 1 are accepted. (Parameter 'number')";
            Action action = () => PrimeNumberHelper.FindNextPrimeNumberBiggerOrEqual(number);

            Exception ex = Record.Exception(action);

            Assert.NotNull(ex);
            Assert.IsType<ArgumentOutOfRangeException>(ex);
            Assert.Equal(exceptionMessage, ((ArgumentOutOfRangeException)ex).Message);
        }

        [Theory]
        [MemberData(nameof(FindNextPrimeNumberTestData))]
        public void FindNextPrimeNumberBiggerOrEqual_NumberBiggerThanOne_TheNextBiggerPrimeNumber(int number, int expectedPrimeNumber)
        {
            var stopwatch = Stopwatch.StartNew();

            int primeNumber = PrimeNumberHelper.FindNextPrimeNumberBiggerOrEqual(number);
            stopwatch.Stop();

            Assert.Equal(expectedPrimeNumber, primeNumber);
        }

        public static IEnumerable<object[]> FindNextPrimeNumberTestData()
        {            
            yield return new object[] { 2, 2 };
            yield return new object[] { 3, 3 };
            yield return new object[] { 4, 5 };
            yield return new object[] { 5, 5 };
            yield return new object[] { 6, 7 };
            yield return new object[] { 7, 7 };
            yield return new object[] { 10, 11 };
            yield return new object[] { 11, 11 }; 
            yield return new object[] { 104724, 104729 };
            yield return new object[] { 10009730, 10009777 };
            yield return new object[] { 2000010924, 2000010949 };
            yield return new object[] { 2147483630, 2147483647 };
        }
    }
}
