using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent2024.Day01
{
    public class Logic
    {
        public static string Run()
        {
            var model = Model.Parse();
            long sum = 0;
            for (var i = 0; i < model.List1.Count; i++)
            {
                var diff = Math.Abs(model.List1[i] - model.List2[i]);
                sum += diff;
            }


            sum = 0;
            for (var i = 0; i < model.List1.Count; i++)
            {
                var num = model.List1[i];
                var numOcc = model.List2.Where(p => p == num).Count();
                sum += model.List1[i] * numOcc;
            }

            return sum.ToString();
        }
    }
}
