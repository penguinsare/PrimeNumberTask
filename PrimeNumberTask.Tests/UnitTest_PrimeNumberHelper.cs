using PrimeNumberTask.Lib;
using System;
using System.Collections.Generic;
using Xunit;

namespace PrimeNumberTask.Tests
{
    public class UnitTest_PrimeNumberHelper
    {

        [Theory]
        [MemberData(nameof(IsPrimeNumberDataTestData))]
        public void ShouldReturnTrueIfANumberIsAPrimeNumber(int number, bool expected)
        {

            Assert.Equal(expected, PrimeNumberHelper.IsPrimeNumber(number));
        }

        public static IEnumerable<object[]> IsPrimeNumberDataTestData()
        {
            yield return new object[] { -1, false };
            yield return new object[] { 0, false };
            yield return new object[] { 1, false };
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


        }
    }
}
