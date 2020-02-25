using Anexinet.Core.Implementations;
using Anexinet.Core.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Drawing;
using System.Globalization;
using System.Linq;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        IAnexinetTest test = new AnexinetTest();

        /// <summary>
        /// Gets the bounding box are of 4 given points
        /// </summary>
        [TestMethod]
        public void GetSmallestBoundingBox()
        {
            var points = new Point[4]
            {
                new Point(1,1)
                , new Point(1,-1)
                ,new Point(-1,1)
                ,new Point(-1,-1)
            };

            double area = test.GetSmallestBoundingBoxArea(points);
            Assert.AreEqual(area, 4); //a 2x2 square


        }

        /// <summary>
        /// Gets the bounding box are of N given points on an irregular polygon
        /// </summary>
        [TestMethod]
        public void GetSmallestBoundingBoxV2()
        {
            var points = new Point[4]
            {
                new Point(2,2)
                , new Point(2,-8)
                ,new Point(-2,21)
                ,new Point(-2,-40)
            };

            double area = test.GetSmallestBoundingBoxArea(points);
            Assert.AreEqual(area, 244); //an irregular polygon. Is NOT the area of the poly. Is the area of the Bounding Box
        }

        /// <summary>
        /// Calculates if a given string date is a Leap year, using an especific es-Mx culture
        /// </summary>
        [TestMethod]
        public void IsLeapYear_SpanishFormat()
        {
            string date = "28/02/2004";
            bool IsLeapYear = test.IsLeapYear(date, new CultureInfo("es-MX"));
            Assert.IsTrue(IsLeapYear);
        }

        /// <summary>
        /// Calculates if a given string date is a Leap year, using an especific en-EN culture
        /// </summary>
        [TestMethod]
        public void IsLeapYear_EnglishFormat()
        {

            string date = "02/28/2004";
            bool IsLeapYear = test.IsLeapYear(date, new CultureInfo("en-EN"));
            Assert.IsTrue(IsLeapYear);
        }


        /// <summary>
        /// Calculates if a given string date is a Leap year, using an invalid date and the machine culture
        /// Throws and exceptions wich describes the expected format
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void IsLeapYear_InvalidDate()
        {
            string date = "32/01/2004";
            bool IsLeapYear = test.IsLeapYear(date, CultureInfo.CurrentCulture);

        }

        /// <summary>
        /// Iterates over a given set of truly leap years, to evaluate if they are  leap years according to the function
        /// </summary>
           [TestMethod]
        public void IsLeapYear_FirstHalfCenturyYears()
        {
            int[] firstCenturyLeapYears = new int[] { 2000, 2004, 2008, 2012, 2016, 2020, 2024, 2028, 2032, 2036, 2040, 2044, 2048 };
            bool result = true;
            var culture = new CultureInfo("es-MX");
            for (int i = 2000; i <= 2048; i++)
            {
                string date = new DateTime(i, 1, 1).ToString("dd/MM/yyyy");

                if (firstCenturyLeapYears.Contains(i) != test.IsLeapYear(date, culture)) //Misscalculation by the function ocurred
                {
                    result = false;
                    break;
                }

            }

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GetRepeatedCharacters_ManyFound()
        {
            string first = "keyboard";
            string second = "whiteboard ";

            var repeatedCharacters = test.GeRepeatedCharacters(first, second);

            Assert.IsTrue(
                repeatedCharacters.Contains("b") &&
                repeatedCharacters.Contains("o") &&
                repeatedCharacters.Contains("a") &&
                repeatedCharacters.Contains("r") &&
                repeatedCharacters.Contains("d")

                );
        }


        /// <summary>
        /// Evaluates repeated characters in two given strings. Throws and exception if both strings are equal
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void GetRepeatedCharacters_EqualStrings()
        {
            string first = "keyboard";
            string second = "keyboard";

            var repeatedCharacters = test.GeRepeatedCharacters(first, second);
          
        }


        /// <summary>
        /// Evaluates repeated characters in two given strings
        /// </summary>
        [TestMethod]
        public void GetRepeatedCharacters_OneFound()
        {
            string first = "keyboard";
            string second = "institute ";

            var repeatedCharacters = test.GeRepeatedCharacters(first, second);
            //only the "e" letter repeats 
            Assert.IsTrue(
                repeatedCharacters.Length == 1 && repeatedCharacters[0] == 'e'

                );
        }

        /// <summary>
        /// Evaluates if a set of brackets are properly closed in a string
        /// </summary>
        [TestMethod]
        public void BracketsAreComplete()
        {
            var complete_noCombined = " Sum of (6+4) equals 10 [ 6+4 =10]";
            var complete_combined = " Array of cartesian points ([{1,1},{2,2}])";

            var incorrect = "Sum of (6+4 equals 10";

            var complete_noCombined_test = test.BracketsAreComplete(complete_noCombined);
            var complete_combined_test = test.BracketsAreComplete(complete_combined);
            var incorrect_test = test.BracketsAreComplete(incorrect);

            Assert.IsTrue(

                complete_noCombined_test == true &&
                complete_combined_test == true &&
                incorrect_test == false

                );
        }


        /// <summary>
        /// Compreses a string if a given string has repeating characters. Returns the original string if the compressed one
        /// is larger.
        /// </summary>
        [TestMethod]
        public void CompressString()
        {

            string testString = "aaabbcccrrrraaaaa";
            var compresion = test.CompressString(testString);
            Assert.AreEqual(compresion, "a3b2c3r4a4");
        }


    }
}
