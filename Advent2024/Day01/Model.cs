using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent2024.Day01
{
    public class Model
    {
        public required List<int> List1 { get; set; }
        public required List<int> List2 { get; set; }

        public static Model Parse()
        {
            var retObj = new Model
            {
                List1 = new List<int>(),
                List2 = new List<int>(),
            };

            foreach (var lx in Data.InputData.Split("\n"))
            {
                var l = lx.Trim();
                l = l.Replace("  ", " ");
                l = l.Replace("  ", " ");
                l = l.Replace("  ", " ");
                l = l.Replace("  ", " ");
                l = l.Replace("  ", " ");

                if (string.IsNullOrEmpty(l))
                    continue;

                var arr = l.Split(' ');
                retObj.List1.Add(int.Parse(arr[0]));
                retObj.List2.Add(int.Parse(arr[1]));
            }

            retObj.List1 = retObj.List1.OrderBy(p => p).ToList();
            retObj.List2 = retObj.List2.OrderBy(p => p).ToList();

            return retObj;
        }
    }
}
