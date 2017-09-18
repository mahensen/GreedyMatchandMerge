using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergerModule.Utilities
{
    public class StringUtility
    {
        public  string ComapareString(string fullText, string matchingText)
        {
            if (matchingText == null)
                throw new ArgumentNullException("matchingText");

            if (fullText == null)
                throw new ArgumentNullException("fullText");

            for (int i = 0; i < matchingText.Length; i++)
            {
                for (int j = matchingText.Length; j > i; j--)
                {
                    if (fullText.IndexOf(matchingText.Substring(i, j-i)) > 0)
                    {
                        Console.WriteLine("Match Found : " + matchingText.Substring(i, j-i));
                        return matchingText.Substring(i, j-i);
                    }
                }
            }

            return "";
        }

        public string MergeString(string firstString, string secondString, string matchingText)
        {
            if (firstString == null)
                throw new ArgumentNullException("firstString");

            if (secondString == null)
                throw new ArgumentNullException("secondString");

            if (matchingText == null)
                throw new ArgumentNullException("matchingText");

            if (secondString == matchingText)
                return firstString;

            return firstString +  secondString.Replace(matchingText,"");

            
        }
    }
}
