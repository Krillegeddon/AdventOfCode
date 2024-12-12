using AdventUtils;
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
            var c1 = Coord.Create(10, 11);
            var c2 = Coord.Create(10, 11);

            if (c1 == c2)
            {
                Console.WriteLine("Same");
            }



            var model = Model.Parse();

            var grid = model.Grid;

            //var origX = grid.GuardX;
            //var origY = grid.GuardY;
            //var origDir = grid.Direction;

            long sum = 0;
            //grid.GuardX = origX;
            //grid.GuardY = origY;
            //grid.Direction = origDir;
            long sum2 = 0;
            while (grid.IsInside())
            {
                while (grid.IsObstacleAhead())
                {
                    grid.RotateGuardClockwise();
                }
                grid.MoveGuard();
                if (grid.CanEnterLoop())
                {
                    sum2++;
                }
            }

            //417, too low

            sum = grid.VisitedSquares.Count();
            return sum.ToString();
        }
    }
}
