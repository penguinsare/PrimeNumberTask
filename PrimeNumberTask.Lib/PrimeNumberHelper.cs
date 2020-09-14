using System;

namespace PrimeNumberTask.Lib
{
    public class PrimeNumberHelper
    {
        public static bool IsPrimeNumber(int number)
        {
            if (number < 2)
                throw new ArgumentOutOfRangeException(
                    "Since a prime number (or a prime) is defined as a natural number "+ 
                    "greater than 1, only numbers greater than 1 are accepted.");
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
            if (number < 0)
                throw new ArgumentOutOfRangeException(
                    "Since a prime number (or a prime) is defined as a natural number " +
                    "greater than 1, only numbers greater than or equal zero are accepted.");
            if ((number == 0) ||
                (number == 1))
                return 2;

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
