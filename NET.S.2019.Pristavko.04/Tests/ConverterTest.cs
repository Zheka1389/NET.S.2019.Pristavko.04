﻿namespace NET.S._2019.Pristavko._04.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public static class ConverterTest
    {
        [TestCase(-2.255, ExpectedResult = "1100000000000010000010100011110101110000101000111101011100001010")]
        [TestCase(255.255, ExpectedResult = "0100000001101111111010000010100011110101110000101000111101011100")]
        [TestCase(42949672.0, ExpectedResult = "0100000110000100011110101110000101000000000000000000000000000000")]
        [TestCase(4294967295.0, ExpectedResult = "0100000111101111111111111111111111111111111000000000000000000000")]
        [TestCase(double.MinValue, ExpectedResult = "1111111111101111111111111111111111111111111111111111111111111111")]
        [TestCase(double.MaxValue, ExpectedResult = "0111111111101111111111111111111111111111111111111111111111111111")]
        [TestCase(double.Epsilon, ExpectedResult = "0000000000000000000000000000000000000000000000000000000000000001")]
        [TestCase(double.NaN, ExpectedResult = "1111111111111000000000000000000000000000000000000000000000000000")]
        [TestCase(double.NegativeInfinity, ExpectedResult = "1111111111110000000000000000000000000000000000000000000000000000")]
        [TestCase(double.PositiveInfinity, ExpectedResult = "0111111111110000000000000000000000000000000000000000000000000000")]
        [TestCase(-0.0, ExpectedResult = "1000000000000000000000000000000000000000000000000000000000000000")]
        [TestCase(0.0, ExpectedResult = "0000000000000000000000000000000000000000000000000000000000000000")]
        [TestCase(-255.255, ExpectedResult = "1100000001101111111010000010100011110101110000101000111101011100")]
        [TestCase(12894.365478, ExpectedResult = "0100000011001001001011110010111011000111111110111010110010110100")]
        [TestCase(1E-46, ExpectedResult = "0011011001100010010001001100111000100100001011000101010101100001")]
        public static string ConvertToString(this double number)
            => Converter.DoubleToBinaryString(number);
    }
}
