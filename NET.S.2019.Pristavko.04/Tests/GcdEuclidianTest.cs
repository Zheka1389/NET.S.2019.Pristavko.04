using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.S._2019.Pristavko._04.Tests
{
    [TestFixture]
    class GcdEuclidianTest
    {
        [TestCase(25, 50, ExpectedResult = 25)]
        [TestCase(50, 25, 0, ExpectedResult = 25)]
        [TestCase(-5, 1, 0, 1, ExpectedResult = 1)]
        [TestCase(1, -655, -43563, 14530, ExpectedResult = 1)]
        [TestCase(-25, 50, 2050, 2525, ExpectedResult = 25)]
        [TestCase(17, 0, 0, 0, ExpectedResult = 17)]
        [TestCase(12, 0, -50, 27, 5230, 653, ExpectedResult = 1)]
        [TestCase(0, 0, 0, 0, 0, 0, ExpectedResult = 0)]
        [TestCase(77, 77, 77, 77, 77, ExpectedResult = 77)]
        [TestCase(0, 15, ExpectedResult = 15)] 
        public static int GcdEuclidian(params int[] arrayNumbers)
        {
            return Algorithms.GcdEuclidian(arrayNumbers);
        }

        [TestCase(0)]
        [TestCase()]
        public void GcdEuclidian_Exception(params int[] arrayNumbers) =>
            Assert.Throws<ArgumentOutOfRangeException>(() => Algorithms.GcdEuclidian(arrayNumbers));
    }
}
