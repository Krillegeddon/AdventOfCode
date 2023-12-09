using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent2023.Day09
{
    public class Logic
    {
        public static long ExtrapolateLine(List<long> line, int part)
        {
            var arr = new List<long>();

            for (var i = 1; i < line.Count; i++)
            {
                var diff = line[i] - line[i - 1];
                arr.Add(diff);
            }

            var allZeroes = true;
            foreach (var i in arr)
            {
                if (i != 0)
                {
                    allZeroes = false;
                    break;
                }
            }

            if (allZeroes)
            {
                if (part == 1)
                {
                    return line[line.Count - 1];
                }
                else
                {
                    return line[0];
                }
            }

            var ex = ExtrapolateLine(arr, part);
            if (part == 1)
            {
                var lastVal = line[line.Count - 1];
                return lastVal + ex;
            }
            else
            {
                var firstVal = line[0];
                return firstVal - ex;
            }
        }


        public static string Run()
        {
            var model = Model.Parse();

            long sum = 0;

            foreach (var line in model.Lines)
            {
                var e = ExtrapolateLine(line.Numbers, 2);
                sum += e;
            }


            return sum.ToString();
        }
    }
}
