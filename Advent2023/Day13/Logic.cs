using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent2023.Day13
{
    public class Logic
    {
        private static bool IsMirrorColumn(Grid grid, int x1, int x2)
        {
            for (var y = 0; y < grid.Height; y++)
            {
                var c1 = grid.Get(x1, y);
                var c2 = grid.Get(x2, y);
            }

            return false;
        }

        public static string Run()
        {
            var model = Model.Parse();

            long sum = 0;

            var middleX = grid.Width / 2;
            if (grid.Width % 2 == 1)
            {
                middleX++;
            }


            foreach (var grid in model.Grids)
            {
                FindMiddleColumn(grid);
            }


            return sum.ToString();
        }
    }
}
