using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent2023.Day09
{
    public class Logic
    {
        public static long ExtrapolateLine(List<long> line)
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
                return line[line.Count - 1];
            }

            var ex = ExtrapolateLine(arr);
            var lastVal = line[line.Count - 1];
            return lastVal + ex;
        }


        public static string Run()
        {
            var model = Model.Parse();

            long sum = 0;

            foreach (var line in model.Lines)
            {
                var e = ExtrapolateLine(line.Numbers);
                sum += e;
            }


            return sum.ToString();
        }
    }
}
