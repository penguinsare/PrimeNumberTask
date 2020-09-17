using PrimeNumberTask.Lib.Constants;
using System;

namespace PrimeNumberTask.Lib
{
    public class PrimeNumberHelper
    {
        public static bool IsPrimeNumber(int number)
        {
            if (number < 2)
                throw new ArgumentOutOfRangeException(
                    "number",
                    ErrorMessages.IsPrimeNumber_NumberConstaints);

            bool isPrime = true;
            for (int divisor = 2; divisor < number; divisor++)
            {
                if (number % divisor == 0)
                {
                    isPrime = false;
                    break;
                }                    
            }
            return isPrime;
        }

        public static int FindNextPrimeNumberBiggerOrEqual(int number)
        {
            if (number < 2)
                throw new ArgumentOutOfRangeException(
                    "number",
                    ErrorMessages.IsPrimeNumber_NumberConstaints);

            // As of August 2018 the largest known maximal prime gap has length 1550.
            // It occurs after the prime 18361375334787046697.
            for (int add = 0 ; add <= 1550; add++)
            {
                if (IsPrimeNumber(number + add))
                    return number + add;
            }
            return 1;
        }
    }
}
