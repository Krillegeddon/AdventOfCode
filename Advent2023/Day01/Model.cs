using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent2023.Day01
{
    public class Model
    {
        public required List<List<int>> Lines { get; set; }

        public static Model Parse(int part)
        {
            var retObj = new Model
            {
                Lines = new List<List<int>>(),
            };

            foreach (var lx in Data.InputData.Split("\n"))
            {
                var l = lx.Trim();

                if (string.IsNullOrEmpty(l))
                    continue;

                if (part == 2)
                {
                    l = l.Replace("one", "o1e");
                    l = l.Replace("two", "t2o");
                    l = l.Replace("three", "t3e");
                    l = l.Replace("four", "f4r");
                    l = l.Replace("five", "f5e");
                    l = l.Replace("six", "s6x");
                    l = l.Replace("seven", "s7n");
                    l = l.Replace("eight", "e8t");
                    l = l.Replace("nine", "n9e");
                    l = l.Replace("zero", "z0o");
                }
                var arr = l.ToCharArray();

                var currentArr = new List<int>();

                foreach (var i in arr)
                {
                    if (i < '0') continue;
                    if (i > '9') continue;
                    var ix = int.Parse(i.ToString());
                    currentArr.Add(ix);
                }
                retObj.Lines.Add(currentArr);
            }
            return retObj;

        }
    }
}
