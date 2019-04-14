namespace NET.S._2019.Pristavko._04
{
    using System;
    using System.Diagnostics;

    internal class Algorithms
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
            {
                return a;
            }

            if (a == 0)
            {
                return b;
            }

            if (b == 0)
            {
                return a;
            }

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
            return GcdEuclidianD(GcdEuclidian, arrayNumbers);
        }

        /// <summary>
        /// Find time for GCD numbers using the Euclidean algorithm
        /// </summary>
        public static int GcdEuclidianTime(out TimeSpan time, params int[] arrayNumbers)
        {
            return GcdEuclidianTimeD(GcdEuclidian, out time, arrayNumbers);
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
            {
                return a;
            }

            if (a == 0)
            {
                return b;
            }

            if (b == 0)
            {
                return a;
            }

            if ((~a & 1) != 0)
            {
                if ((b & 1) != 0)
                {
                    return GcdBinary(a >> 1, b);
                }
                else
                {
                    return GcdBinary(a >> 1, b >> 1) << 1;
                }
            }

            if ((~b & 1) != 0)
            {
                return GcdBinary(a, b >> 1);
            }

            if (a > b)
            {
                return GcdBinary((a - b) >> 1, b);
            }

            return GcdBinary((b - a) >> 1, a);
        }

        /// <summary>
        /// Find GCD of 3 or more numbers using the Stein's algorithm 
        /// </summary>
        public static int GcdBinary(params int[] arrayNumbers)
        {
            return GcdBinaryD(GcdBinary, arrayNumbers);
        }

        /// <summary>
        /// Find time for GCD numbers using the Stein's algorithm
        /// </summary>
        public static long GcdBinaryTime(out TimeSpan time, params int[] arrayNumbers)
        {
            return GcdBinaryTimeD(GcdBinary, out time, arrayNumbers);
        }

        /// <summary>
        /// Find GCD of 3 or more numbers using the Euclidean algorithm
        /// </summary>
        private static int GcdEuclidianD(Func<int, int, int> algorithm, params int[] arrayNumbers)
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
                result = algorithm(result, second);
            }

            return result;
        }   

        /// <summary>
        /// Find time for GCD numbers using the Euclidean algorithm
        /// </summary>
        private static int GcdEuclidianTimeD(Func<int, int, int> algorithm, out TimeSpan time, params int[] arrayNumbers)
        {
            Stopwatch temp = new Stopwatch();
            temp.Start();
            int result = GcdEuclidianD(algorithm, arrayNumbers);
            temp.Stop();
            time = temp.Elapsed;
            return result;
        }

        /// <summary>
        /// Find GCD of 3 or more numbers using the Stein's algorithm 
        /// </summary>
        private static int GcdBinaryD(Func<int, int, int> algorithm, params int[] arrayNumbers)
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
                result = algorithm(result, second);
            }

            return result;
        }

        /// <summary>
        /// Find time for GCD numbers using the Stein's algorithm
        /// </summary>
        private static int GcdBinaryTimeD(Func<int, int, int> algorithm, out TimeSpan time, params int[] arrayNumbers)
        {
            Stopwatch temp = new Stopwatch();
            temp.Start();
            int result = GcdBinaryD(algorithm, arrayNumbers);
            temp.Stop();
            time = temp.Elapsed;
            return result;
        }
    }
}
