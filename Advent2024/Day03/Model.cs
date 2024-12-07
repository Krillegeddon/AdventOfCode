using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent2024.Day03
{
    public class Model
    {
        public required List<int> Obj { get; set; }

        public static Model Parse()
        {
            var retObj = new Model
            {
                Obj = new List<int>()
            };

            foreach (var lx in Data.InputData.Split("\n"))
            {
                var l = lx.Trim();

                if (string.IsNullOrEmpty(l))
                    continue;

                var arr = l.Split("mul(");
                foreach (var a in arr)
                {
                    // a is now what is between mul( and the next mul(
                    var arr2 = a.Split(")");
                    if (arr2.Length == 1)
                        continue;

                    // arr2[0] is now everything between mul( and the first ).
                    var arr3 = arr2[0].Split(",");

                    // arr3 should now consist of two integers!
                    if (arr3.Length != 2)
                        continue;

                    int val1, val2;
                    if (!int.TryParse(arr3[0], out val1))
                        continue;
                    if (!int.TryParse(arr3[1], out val2))
                        continue;

                    retObj.Obj.Add(val1 * val2);
                }
            }

            return retObj;
        }
    }
}
