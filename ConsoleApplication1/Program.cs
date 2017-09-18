using MergerModule.DataModel;
using MergerModule.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MergerModule.App
{
    class Program
    {
        static void Main(string[] args)
        {
            IList<string> stringList = new List<string>();
            stringList.Add("My name is Mahen Senthivel");
            stringList.Add("ame is M");
            stringList.Add("Senthivel and");
            stringList.Add("and my age");
            stringList.Add("y age is 34");


            // convert the string list into list of Segment objects
            IList<Segment> segmentList = new List<Segment>();
            foreach (string s in stringList)
            {
                segmentList.Add(new Segment { value = s });
            }


            // find the matching strings     
            while (segmentList.Count > 1)
            {
                for (int i = 0; i < segmentList.Count; i++)
                {
                    if (i < segmentList.Count - 1)
                    {

                        Console.WriteLine("First String : " + segmentList[i].value);
                        Console.WriteLine("Second String : " + segmentList[i + 1].value);
                        string matchingText = new StringUtility().ComapareString(segmentList[i].value, segmentList[i + 1].value);
                        if (matchingText.Length > 1)
                        {
                            if (segmentList[i].matchingSegment == null ||
                                (!string.IsNullOrEmpty(segmentList[i].matchingText) && segmentList[i].matchingText.Length < matchingText.Length))
                            {
                                segmentList[i].matchingSegment = segmentList[i + 1];
                                segmentList[i].matchingText = matchingText;
                            }
                        }

                    }
                }

                // merge the highest matching segment
                Segment highestSeg = segmentList.Where(x=> x.matchingSegment != null).OrderByDescending(x => x.matchingText.Length).First();
                highestSeg.value = new StringUtility().MergeString(highestSeg.value, highestSeg.matchingSegment.value, highestSeg.matchingText);
                segmentList.Remove(highestSeg.matchingSegment);

                segmentList.ToList().ForEach(c => c.matchingSegment = null);
                segmentList.ToList().ForEach(c => c.matchingText = null);
            }

            Console.WriteLine("Final String : " + segmentList.First().value);

            Console.Read();
           
        }

        
    }
}
