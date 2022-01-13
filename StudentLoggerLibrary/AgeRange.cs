using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentLoggerLibrary
{
    public class AgeRange
    {
        public static List<int> ageRangeList = new();
        public AgeRange()
        {
            for(int x = 18; x < 41; x++)
            {
                ageRangeList.Add(x);
            }
        }
    }
}
