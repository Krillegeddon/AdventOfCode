using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent2023.Day14
{
    public class Logic
    {
        public static bool RollLine(Grid grid, int y, int direction)
        {
            if (y == 0 && direction == 1)
                return false;
            if (y == grid.Height-1 && direction == -1)
                return false;

            bool anythingChanged = false;
            var coordsOnRow = grid.Coordinates.Values.Where(p => p.Y == y).ToList();
            foreach (var c in coordsOnRow)
            {
                if (c.Type == '#')
                {
                    // Cubes cannot roll...
                    continue;
                }

                var cellAbove = grid.Get(c.X, y - 1 * direction);
                if (cellAbove == null)
                {
                    anythingChanged = true;
                    grid.Set(c.X, y - 1 * direction, c.Type);
                    grid.Remove(c.X, y);
                }
            }
            return anythingChanged;
        }

        public static bool RollColumn(Grid grid, int x, int direction)
        {
            if (x == 0 && direction == 1)
                return false;
            if (x == grid.Width - 1 && direction == -1)
                return false;

            bool anythingChanged = false;
            var coordsOnCol = grid.Coordinates.Values.Where(p => p.X == x).ToList();
            foreach (var c in coordsOnCol)
            {
                if (c.Type == '#')
                {
                    // Cubes cannot roll...
                    continue;
                }

                var cellToTheRight = grid.Get(x - 1 * direction, c.Y);
                if (cellToTheRight == null)
                {
                    anythingChanged = true;
                    grid.Set(x - 1 * direction, c.Y, c.Type);
                    grid.Remove(x, c.Y);
                }
            }
            return anythingChanged;
        }



        private static void RollGrid(Grid grid, int dx, int dy)
        {
            bool anythingChanged = true;
            while (anythingChanged)
            {
                anythingChanged = false;
                for (int y = 0; y < grid.Height; y++)
                {
                    if (dx == 0)
                    {
                        if (RollLine(grid, y, dy))
                            anythingChanged = true;
                    }
                    else
                    {
                        if (RollColumn(grid, y, dx))
                            anythingChanged = true;
                    }
                }
            }

            grid.DebugWrite();
        }

        private static void RunCycle(Grid grid)
        {
            RollGrid(grid, 0, 1);
            RollGrid(grid, 1, 0);
            RollGrid(grid, 0, -1);
            RollGrid(grid, -1, 0);
        }

        public static string Run()
        {
            var model = Model.Parse();

            long sum = 0;

            var dict = new Dictionary<string, string>();
            var gridsInLoop = new List<string>();

            var sgrid = model.Grid.GetAsString();

            // 34 i loopen
            // i = 161
            // x = 1000000000 - 161 = 999999839
            // loops = x / 34 = 29411759,97058824
            // fulla loopar = 29411759
            // antal steg efter fulla loopar = 29411759*34
            // 999999806
            // index i loopen: 999999839 - 999999806 = 33... den sista, alltså?


            for (int i = 0; i < 1000000000; i++)
            {
                if (dict.ContainsKey(sgrid))
                {
                    if (gridsInLoop == null)
                        gridsInLoop = new List<string>();

                    if (!gridsInLoop.Contains(sgrid))
                    {
                        gridsInLoop.Add(sgrid);
                    }
                    else
                    {
                        int bbb = 9;
                        goto xdone;
                    }

                    sgrid = dict[sgrid];
                    int bb = 9;
                }
                else
                {
                    var grid = Model.ParseGrid(sgrid);

                    RunCycle(grid);
                    var n = grid.GetAsString();
                    dict.Add(sgrid, n);
                    sgrid = n;
                }
            }

            xdone:

            model.Grid.DebugWrite();

            var grid2 = Model.ParseGrid(gridsInLoop[33]);

            sum = 0;
            var height = grid2.Height;
            foreach (var c in grid2.Coordinates.Values)
            {
                if (c.Type == '#')
                    continue;

                sum += (height - c.Y);

            }
            // 224933 too high!


            return sum.ToString();
        }
    }
}
