namespace NET.S._2019.Pristavko._04
{
    using System;
    using System.Text;

    public static class Converter
    {
        /// <summary>
        /// static extention method DoubleHelper for Double
        /// </summary>
        /// <param name="doubleNumber"></param>
        /// <returns>double to string</returns>
        public static string DoubleToBinaryString(this double doubleNumber)
        {
            StringBuilder sb = new StringBuilder();
            byte[] doubleByte = BitConverter.GetBytes(doubleNumber);
            foreach (byte b in doubleByte)
            {
                for (int i = 0; i < 8; i++)
                {
                    Console.Write(b + " ");
                    sb.Insert(0, ((b >> i) & 1) == 1 ? "1" : "0");
                }
            }

            return sb.ToString();
        }
    }
}