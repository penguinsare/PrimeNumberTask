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

        public static int FindNextBiggerPrimeNumberAfter(int number)
        {

            return 1;
        }
    }
}
