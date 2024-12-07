using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent2024.Day03
{
    public class Logic
    {
        public static string Run()
        {
            var model = Model.Parse();

            long sum = 0;

            foreach (var i in model.Obj)
            {
                sum += i;
            }

            return sum.ToString();
        }
    }
}
