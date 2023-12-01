using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent2023.Day01
{
    public class Logic
    {
        public static string Run()
        {
            var model = Model.Parse(2);

            long sum = 0;

            foreach (var arr in model.Lines)
            {
                var d1 = arr[0];
                var d2 = arr[arr.Count - 1];
                var val = d1 * 10 + d2;
                sum += (long)val;
            }

            return sum.ToString();
        }
    }
}
