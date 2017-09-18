using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergerModule.DataModel
{
    public class Segment
    {
        public string name { get; set; }
        public string value { get; set; }
        public Segment matchingSegment { get; set; }
        public string matchingText { get; set; }
    }
}
