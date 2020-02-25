using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Anexinet.Core.Interfaces
{
    public interface IAnexinetTest
    {
        /// <summary>
        /// Determines if the year is a leap year given a valid date string
        /// </summary>
        /// <param name="date">A string representing a date</param>
        /// <param name="cultures">Cultures supported by the function</param>
        /// <returns></returns>
        bool IsLeapYear(string dateº , IFormatProvider culture);

        /// <summary>
        /// Gets repeated characters between two different strings
        /// </summary>
        /// <param name="firstString">The first string to be compared</param>
        /// <param name="secondString">The second string to be compared</param>
        /// <returns></returns>
        string GeRepeatedCharacters(string firstString, string secondString);


        /// <summary>
        /// Compresses a string using a basic compresion algorithm
        /// </summary>
        /// <param name="stringToCompress"></param>
        /// <returns></returns>
        string CompressString(string stringToCompress);

        /// <summary>
        /// Given a string that contains brackets, it determines if the brackets are properly closed. 
        /// </summary>
        /// <param name="testString"></param>
        /// <returns></returns>
        bool BracketsAreComplete(string testString);

        Double GetSmallestBoundingBoxArea(Point[] points);
    }
}
