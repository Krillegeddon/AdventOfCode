using AdventUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent2024.Day12
{
    public class Logic
    {
        private static Dictionary<Coord, bool> _visitedAreas = new Dictionary<Coord, bool>();
        private static Dictionary<int, List<Coord>> _areas = new Dictionary<int, List<Coord>>();
        private static Grid _grid;
        private static int currentId = 0;

        private static void Traverse(Coord coord, string wantedId, bool traverseFull)
        {
            if (!_visitedAreas.ContainsKey(coord))
                return;
            _visitedAreas.Add(coord, true);

            if (!_areas.ContainsKey(currentId))
                _areas.Add(currentId, new List<Coord>());

            var buddies = new List<Coord>
            {
                Coord.Create(coord.X - 1, coord.Y),
                Coord.Create(coord.X + 1, coord.Y),
                Coord.Create(coord.X, coord.Y - 1),
                Coord.Create(coord.X, coord.Y + 1)
            }.Where(p => _grid.IsInside(p) && _grid.GetValue(p) == wantedId && !_visitedAreas.ContainsKey(p)).ToList();

            var enemies = new List<Coord>
            {
                Coord.Create(coord.X - 1, coord.Y),
                Coord.Create(coord.X + 1, coord.Y),
                Coord.Create(coord.X, coord.Y - 1),
                Coord.Create(coord.X, coord.Y + 1)
            }.Where(p => _grid.IsInside(p) && _grid.GetValue(p) != wantedId && !_visitedAreas.ContainsKey(p)).ToList();

            foreach (var buddy in buddies)
            {
                Traverse(buddy, wantedId, true);
            }

            if (!traverseFull)
            {
                // Don't traverse enemies if traversing full!
                return;
            }

            foreach (var enemy in enemies)
            {
                var enemyValue = 
            }
        }


        public static string Run()
        {
            var model = Model.Parse();
            _grid = model.Grid;
            long sum = 0;

            var startValue = model.Grid.GetValue(Coord.Create(0, 0));
            Traverse(Coord.Create(0, 0), startValue);

            return sum.ToString();
        }
    }
}
