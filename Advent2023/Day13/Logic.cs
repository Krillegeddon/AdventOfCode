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

                if (c1 == null && c2 != null || c1 != null && c2 == null)
                {
                    return false;
                }
            }

            if (x1 == 0 || x2 == grid.Width - 1)
            {
                // We have gotten to the end of either of the limits.. if we have gotten this far - it is a mirror!
                return true;
            }

            return IsMirrorColumn(grid, x1 - 1, x2 + 1);
        }


        private static bool IsMirrorRow(Grid grid, int y1, int y2)
        {
            for (var x = 0; x < grid.Width; x++)
            {
                var c1 = grid.Get(x, y1);
                var c2 = grid.Get(x, y2);

                if (c1 == null && c2 != null || c1 != null && c2 == null)
                {
                    return false;
                }
            }

            if (y1 == 0 || y2 == grid.Height - 1)
            {
                // We have gotten to the end of either of the limits.. if we have gotten this far - it is a mirror!
                return true;
            }

            return IsMirrorRow(grid, y1 - 1, y2 + 1);
        }



        public static string Run()
        {
            var model = Model.Parse();

            long sum = 0;

            foreach (var grid in model.Grids)
            {
                var width = grid.Width;
                var middleX = grid.Width / 2;
                if (grid.Width % 2 == 1)
                {
                    middleX++;
                }
                var height = grid.Height;
                var middleY = grid.Height / 2;
                if (grid.Height % 2 == 1)
                {
                    middleY++;
                }

                int numX = 0;
                for (int x = width - 1; x >= 0; x--)
                {
                    var isMirror = IsMirrorColumn(grid, x, x + 1);
                    if (isMirror)
                    {
                        var numColumnsToTheLeft = x + 1;
                        sum += numColumnsToTheLeft;
                        numX++;
                    }
                }

                int numY = 0;
                for (int y = height - 1; y >= 0; y--)
                {
                    var isMirror = IsMirrorRow(grid, y, y + 1);
                    if (isMirror)
                    {
                        var numColumnsToTheTop = y + 1;
                        sum += (numColumnsToTheTop * 100);
                        numY++;
                    }
                }
            }

            return sum.ToString();
        }
    }
}
