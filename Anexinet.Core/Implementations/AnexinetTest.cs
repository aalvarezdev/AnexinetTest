using Anexinet.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Anexinet.Core.Implementations
{
    public class AnexinetTest : IAnexinetTest
    {
        public bool BracketsAreComplete(string testString)
        {

            // I _know_ this can be done with a dictionary, but I wanted to show you another approach. 

            string[] brackets = new string[3] { "()", "[]", "{}" }; 
            //We use a LIFO collection 
            Stack<char> stack = new Stack<char>();
            try
            {
                foreach (char letter in testString)
                {

                    //not a bracket symbol
                    if (!brackets.Select(x => x.ToCharArray()).Any(x => x.Contains(letter))) continue;



                    if (brackets.Single(x => x.Contains(letter)).First() == letter)    //for every opening bracket push the item to the stack.
                    {
                        stack.Push(letter);
                    }

                    else if (brackets.Any(x => x.Last() == letter)) //Is a closing bracket
                    {
                        //Does it match the last opening symbol added  to te stack?
                        if (letter == brackets.Single(x => x.Contains(letter)).Last())
                        {
                            stack.Pop();                            
                        }
                        //Does not match
                        else return false;
                    }
                  
                }
            }
            catch (Exception ex)
            {

                return false;
            }

            return stack.Count == 0;




        }

        public string CompressString(string stringToCompress)
        {
            //Basic check to avoid calculations and memory allocation  if the string has only one character.
            //In the real world we often check if data to be evaluated is valid, before submitting it to further computations.  
            if (stringToCompress.Length == 1) return stringToCompress;


            //String builder is more efficient when concatenating strings
            StringBuilder stringbuilder = new StringBuilder();
            int currentOcurrence = 1;
            int arraySize = stringToCompress.Length;
            //iterate over all chars
            for (int i = 0; i < arraySize; i++)
            {
                if (i == 0) continue; //first item needs not to be evaluated

                //Is the last item and is equal to the preceding character
                if (i == arraySize - 1 && stringToCompress[i - 1] == stringToCompress[i])
                {
                    stringbuilder.Append(stringToCompress[i].ToString() + currentOcurrence++);
                    break;
                }
                //is the last item and unequal to the preceding character.
                else if (i == arraySize - 1 && stringToCompress[i - 1] != stringToCompress[i])
                {
                    stringbuilder.Append(stringToCompress[i].ToString() + currentOcurrence);
                    stringbuilder.Append(stringToCompress[i - 1].ToString() + 1);
                    break;
                }
                //unequal to the preceding character.
                else if (stringToCompress[i] != stringToCompress[i - 1])
                {
                    stringbuilder.Append(stringToCompress[i-1].ToString() + currentOcurrence);
                    currentOcurrence = 1;
                }
                else //Is the same character
                {
                    currentOcurrence++;
                }
            }

            string result = stringbuilder.ToString();
            return result.Length > stringToCompress.Length ? stringToCompress : result;


        }

        public string GeRepeatedCharacters(string firstString, string secondString)
        {
            if (firstString == secondString) throw (new Exception("First string cannot be equal to second one"));
            var result = string.Join("", firstString.ToCharArray().Intersect(secondString.ToCharArray()).ToList());
            return result;

        }

        

        public bool IsLeapYear(string strDate, IFormatProvider culture)
        {
            DateTime date = DateTime.Now;
            bool dateIsValid = DateTime.TryParse(strDate, culture, System.Globalization.DateTimeStyles.None, out date);

            if (!dateIsValid)
                throw new FormatException("Invalid date format. Expected format is  " + DateTimeFormatInfo.GetInstance(culture).ShortDatePattern);

            bool isLeapYear = date.Year % 4 == 0 && (date.Year % 100 != 0 || date.Year % 400 == 0);

            return isLeapYear;
        }

        public double GetSmallestBoundingBoxArea(Point[] points)
        {
            if (points.Length < 2) throw new Exception("At least two points are needed to caculate the smallest bounding box. ");
            //I did a little research in order to solve this problem.  
            var X_MaxPoint = points.Max(p => p.X);
            var X_MinPoint = points.Min(p => p.X);

            var Y_MaxPoint = points.Max(p => p.Y);
            var Y_MinPoint = points.Min(p => p.Y);

            var boxHeight = Math.Abs(X_MaxPoint - X_MinPoint);
            var boxWidth = Math.Abs(Y_MaxPoint - Y_MinPoint);

            //A box without height is not a box. I'ts a rect. 
            if (boxHeight == 0) throw new Exception("At least 2 different X axis points must be specified.  ");
            if (boxWidth == 0) throw new Exception("At least 2 different Y axis points must be specified.  ");

            return boxHeight * boxWidth;

            

        }
    }
}
