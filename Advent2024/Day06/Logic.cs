using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent2024.Day06
{
    public class Logic
    {
        public static string Run()
        {
            var model = Model.Parse();

            var grid = model.Grid;

            long sum = 0;
            while (grid.IsInside())
            {
                while (grid.IsObstacleAhead())
                {
                    grid.RotateGuardClockwise();
                }
                grid.MoveGuard();
            }

            sum = grid.VisitedSquares.Count();
            return sum.ToString();
        }
    }
}
