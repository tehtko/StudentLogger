using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentLoggerLibrary
{
    public class Branches
    {
        public static List<string> branchesList = new();
        public Branches()
        {
            branchesList.Add("");
            branchesList.Add("Computer Science");
            branchesList.Add("Mathematics");
            branchesList.Add("Biology");
            branchesList.Add("Quantum Physics");
        }
    }
}
