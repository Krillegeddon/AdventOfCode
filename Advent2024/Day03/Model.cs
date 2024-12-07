using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent2024.Day03
{
    public class Model
    {

        private static bool FindMatch(string pattern, string total, int index)
        {
            for (int i = 0; i < pattern.Length; i++)
            {
                if (pattern[i] != total[index + i])
                    return false;
            }

            return true;
        }

        private static bool FindMul(string total, int index, out long value, out string debug)
        {
            value = 0;
            debug = "";
            if (!FindMatch("mul(", total, index))
                return false;

            var val1str = "";
            var val2str = "";
            var stage = 0;
            for (int i = 0; i < total.Length; i++)
            {
                // Looking for first number
                if (stage == 0)
                {
                    int num;
                    var c = total[i + 4 + index].ToString();
                    if (int.TryParse(c, out num))
                    {
                        val1str += num.ToString();
                        continue;
                    }
                    if (c == ",")
                    {
                        stage = 1;
                        continue;
                    }
                }

                // Looking for second number
                if (stage == 1)
                {
                    int num;
                    var c = total[i + 4 + index].ToString();
                    if (int.TryParse(c, out num))
                    {
                        val2str += num.ToString();
                        continue;
                    }
                    if (c == ")")
                    {
                        var val1 = long.Parse(val1str);
                        var val2 = long.Parse(val2str);
                        value = val1 * val2;
                        debug = "mul(" + val1str + "," + val2str + ")";
                        return true;
                    }
                }

                return false;
            }


            return true;
        }

        public required List<int> Obj { get; set; }

        public static Model Parse()
        {
            var retObj = new Model
            {
                Obj = new List<int>()
            };


            // Part 2:
            var doActive = true;

            long sum = 0;

            for (int i = 0; i < Data.InputData.Length; i++)
            {
                if (FindMatch("do()", Data.InputData, i))
                {
                    doActive = true;
                }
                if (FindMatch("don't()", Data.InputData, i))
                {
                    doActive = false;
                }

                long value;
                string debug;
                if (FindMul(Data.InputData, i, out value, out debug))
                {
                    if (doActive)
                    {
                        sum += value;
                    }
                }
            }

            // Part 2, the sum above is the answer!


            foreach (var lx in Data.InputData.Split("\n"))
            {
                var l = lx.Trim();

                if (string.IsNullOrEmpty(l))
                    continue;

                // 12681697, too low
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
