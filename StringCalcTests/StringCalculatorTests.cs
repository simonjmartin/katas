using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace StringCalcTests
{
    [TestFixture]
    public class StringCalculatorTests
    {
        private StringCalculator _stringCalculator;

        [SetUp]
        public void Setup()
        {
            _stringCalculator = new StringCalculator();
        }

        [Test]
        public void AddZeroNumbers()
        {
            var result = _stringCalculator.Add(String.Empty);

            Assert.AreEqual(0, result);
        }

        [Test]
        public void AddOneNumber()
        {
            var result = _stringCalculator.Add("1");

            Assert.AreEqual(1, result);
        }

        [Test]
        public void AddOneDifferentNumber()
        {
            var result = _stringCalculator.Add("2");

            Assert.AreEqual(2, result);
        }

        [Test]
        public void AddDoubleDigitNumber()
        {
            var result = _stringCalculator.Add("10");

            Assert.AreEqual(10, result);
        }

        [Test]
        public void AddNegativeNumber()
        {
            // Is this checking I'm throwing a negative number exception or just an exception?
            Assert.Throws<ArgumentException>(() => _stringCalculator.Add("-1"));
        }

        [Test]
        public void AddNonNumber()
        {
            // Is this checking I'm throwing an exception because I'm passing a non-int value and not a negative number exception?
            Assert.Throws<ArgumentException>(() => _stringCalculator.Add("Simon"));
        }

        [Test]
        public void AddTwoNumbersInString()
        {
            var actual = _stringCalculator.Add("1,2");

            Assert.AreEqual(3, actual);
        }

        [Test]
        public void AddTwoOtherNumbersInString()
        {
            var actual = _stringCalculator.Add("2,4");

            Assert.AreEqual(6, actual);
        }

        [Test]
        public void AddOneNumberOneNegative()
        {
            // How about this, am I throwing an exception, a negative number exception (I think it should be) or a not a number exception?
            Assert.Throws<ArgumentException>(() => _stringCalculator.Add("1, -2"));
        }

        [Test]
        public void AddThreeNumbers()
        {
            var actual = _stringCalculator.Add("1,2,3");
            Assert.AreEqual(6, actual);
        }

        [Test]
        public void AddFiveNumbers()
        {
            var actual = _stringCalculator.Add("1,2,3,4,5");

            Assert.AreEqual(15, actual);
        }

        [Test]
        public void AddTwoNumbersOneNegative()
        {
            // Again is this passing for the right reasons?
            Assert.Throws<ArgumentException>(() => _stringCalculator.Add("1,2,-4"));
        }

        [Test]
        public void AddTwoNumbersNewLineDelimiter()
        {
            var actual = _stringCalculator.Add("1\n2,3");

            Assert.AreEqual(6, actual);
        }

        [Test]
        public void AddTwoNumbersAllNewLineDelimiter()
        {
            var actual = _stringCalculator.Add("1\n2\n3");

            Assert.AreEqual(6, actual);
        }

        [Test]
        public void AddMultipleDelimitersThrowsError()
        {
            Assert.Throws<ArgumentException>(()=>_stringCalculator.Add("1,,2"));
        }

        [Test]
        public void AddSuppliedDelimiterTwoNumbers()
        {
            var actual = _stringCalculator.Add("//;\n1;2");

            Assert.AreEqual(3, actual);
        }
    }
}