using AdventUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent2024.Day10
{
    public class Logic
    {
        private static Grid _grid;

        private static List<Coord> GetAdjacentCoords(Coord start, int neededValue)
        {
            var retList = new List<Coord>
            {
                Coord.Create(start.X - 1, start.Y),
                Coord.Create(start.X + 1, start.Y),
                Coord.Create(start.X, start.Y - 1),
                Coord.Create(start.X, start.Y + 1)
            };

            return retList.Where(p => _grid.IsInside(p) && _grid.GetValue(p) == neededValue).ToList();
        }

        private static int CalcScore(Coord start, Dictionary<Coord, bool> foundTops)
        {
            int numTops = 0;
            var value = _grid.GetValue(start);
            
            // Yey, we found a top. That's one more!
            if (value == 9)
            {
                // LOL, part 2 was basically to comment out these three lines! :-)
                //if (foundTops.ContainsKey(start))
                //    return 0;
                //foundTops.Add(start, true);
                return 1;
            }

            var adjacentCoords = GetAdjacentCoords(start, value + 1);
            
            // If there are no adjacent coords with wanted value, then no top here...
            if (adjacentCoords.Count == 0)
                return 0;

            foreach (var coord in adjacentCoords)
            {
                numTops += CalcScore(coord, foundTops);
            }

            return numTops;
        }


        public static string Run()
        {
            var model = Model.Parse();
            _grid = model.Grid;
            long sum = 0;

            for (int x = 0; x < model.Grid.Width; x++)
            {
                for (int y = 0; y < model.Grid.Height; y++)
                {
                    var coord = Coord.Create(x, y);
                    if (_grid.GetValue(coord) == 0)
                    {
                        var foundTops = new Dictionary<Coord, bool>();
                        sum += CalcScore(coord, foundTops);
                        //sum += foundTops.Count; // This was part 1.
                    }
                }
            }

            return sum.ToString();
        }
    }
}
