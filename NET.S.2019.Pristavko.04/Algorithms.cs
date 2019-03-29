using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.S._2019.Pristavko._04
{
    class Algorithms
    {
        /// <summary>
        /// Find GCD of 2 numbers by Euclidean algorithm
        /// </summary>
        /// <param name="a">
        /// The first number
        /// </param>
        /// <param name="b">
        /// The second number
        /// </param>
        /// <returns>
        /// Return GCD
        /// </returns>
        public static int GcdEuclidian(int a, int b)
        {
            a = Math.Abs(a);
            b = Math.Abs(b);
            if (a == b)
                return a;
            if (a == 0)
                return b;
            if (b == 0)
                return a;
            while (a != b)
            {
                if (a > b)
                {
                    a = a - b;
                }
                else
                {
                    b = b - a;
                }
            }
            return a;
        }
        /// <summary>
        /// Find GCD of 3 or more numbers using the Euclidean algorithm
        /// </summary>
        public static int GcdEuclidian(params int[] arrayNumbers)
        {
            if (arrayNumbers == null)
            {
                throw new ArgumentNullException("Value cannot be null");
            }
            if(arrayNumbers.Length <= 1)
            {
                throw new ArgumentOutOfRangeException("The method must have at least two values.");
            }
            int result = arrayNumbers[0];
            foreach (var second in arrayNumbers)
            {
                result = GcdEuclidian(result, second);
            }
            return result;
        }
        /// <summary>
        /// Find time for GCD numbers using the Euclidean algorithm
        /// </summary>
        public static long GcdEuclidianTime(params int[] arrayNumbers)
        {
            Stopwatch time = new Stopwatch();
            time.Start();
            GcdEuclidian(arrayNumbers);
            time.Stop();
            return time.ElapsedMilliseconds;
        }

        /// <summary>
        /// Find GCD of 2 numbers by Stein's algorithm 
        /// </summary>
        /// <param name="a">
        /// The first number
        /// </param>
        /// <param name="b">
        /// The second number
        /// </param>
        /// <returns>
        /// Return GCD
        /// </returns>
        public static int GcdBinary(int a, int b)
        {
            a = Math.Abs(a);
            b = Math.Abs(b);
            if (a == b)
                return a;
            if (a == 0)
                return b;
            if (b == 0)
                return a;
            if ((~a & 1) != 0)
            {
                if ((b & 1) != 0)
                    return GcdBinary(a >> 1, b);
                else
                    return GcdBinary(a >> 1, b >> 1) << 1;
            }
            if ((~b & 1) != 0)
                return GcdBinary(a, b >> 1);
            if (a > b)
                return GcdBinary((a - b) >> 1, b);
            return GcdBinary((b - a) >> 1, a);
        }

        /// <summary>
        /// Find GCD of 3 or more numbers using the Stein's algorithm 
        /// </summary>
        public static int GcdBinary(params int[] arrayNumbers)
        {
            if (arrayNumbers == null)
            {
                throw new ArgumentNullException("Value cannot be null");
            }
            if (arrayNumbers.Length <= 1)
            {
                throw new ArgumentOutOfRangeException("The method must have at least two values.");
            }
            int result = arrayNumbers[0];
            foreach (var second in arrayNumbers)
            {
                result = GcdBinary(result, second);
            }
            return result;
        }

        /// <summary>
        /// Find time for GCD numbers using the Stein's algorithm
        /// </summary>
        public static long GcdBinaryTime(params int[] arrayNumbers)
        {
            Stopwatch time = new Stopwatch();
            time.Start();
            GcdBinary(arrayNumbers);
            time.Stop();
            return time.ElapsedMilliseconds;
        }
    }

}
