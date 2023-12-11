using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent2023.Day11
{
    public class Logic
    {
        public static string Run()
        {
            var model = Model.Parse();

            var pairs = model.Grid.GetGalaxyPairs(); // 93528

            long sum = 0;

            foreach (var pair in pairs)
            {
                var xDist = Math.Abs(pair.Galaxy1.X - pair.Galaxy2.X);
                var yDist = Math.Abs(pair.Galaxy1.Y - pair.Galaxy2.Y);
                sum += (xDist + yDist);
            }


            return sum.ToString();
                
            // 685038871866 <--- too high!
        }
    }
}
