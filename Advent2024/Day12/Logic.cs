using AdventUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent2024.Day12
{
    public record AreaId
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return Name + " (" + ID + ")";
        }
    }

    public class Logic
    {
        private static Dictionary<Coord, bool> _visitedAreas = new Dictionary<Coord, bool>();
        private static Dictionary<AreaId, List<Coord>> _areas = new Dictionary<AreaId, List<Coord>>();
        private static Dictionary<Coord, AreaId> _coords = new Dictionary<Coord, AreaId>();
        private static Grid _grid;


        private static List<Coord> GetNeighbourAreas(Coord coord)
        {
            // FFS! Spent an hour on thinking it would suffice if being connected diagonally
            // also, but of course it cannot!!
            //var retList = new List<Coord>();
            //for (int x = -1; x < 2; x++)
            //{
            //    for (int y = -1; y < 2; y++)
            //    {
            //        if (x == 0 && y == 0)
            //            continue;
            //        var c = Coord.Create(coord.X + x, coord.Y + y);
            //        retList.Add(c);
            //    }

            //}
            var neighbours = new List<Coord>()
            {
                Coord.Create(coord.X, coord.Y - 1),
                Coord.Create(coord.X, coord.Y + 1),
                Coord.Create(coord.X - 1, coord.Y),
                Coord.Create(coord.X + 1, coord.Y),
            };


            return neighbours;
        }


        private static void Traverse(Coord coord, string wantedId, int currentId)
        {
            if (_visitedAreas.ContainsKey(coord))
                return;
            _visitedAreas.Add(coord, true);

            var myValue = _grid.GetValue(coord);

            var myAreaId = new AreaId { ID = currentId, Name = myValue };

            if (wantedId == myValue)
            {
                if (!_areas.ContainsKey(myAreaId))
                    _areas.Add(myAreaId, new List<Coord>());
                _areas[myAreaId].Add(coord);
                _coords.Add(coord, myAreaId);
            }

            var buddies = GetNeighbourAreas(coord)
                .Where(p => _grid.GetValue(p) == wantedId &&
                            _grid.IsInside(p) &&
                        !_visitedAreas.ContainsKey(p))
                .ToList();

            foreach (var buddy in buddies)
            {
                Traverse(buddy, wantedId, currentId);
            }
        }

        public static int CountFences(Coord coord)
        {
            var retVal = 0;
            var neighbours = new List<Coord>()
            {
                Coord.Create(coord.X, coord.Y - 1),
                Coord.Create(coord.X, coord.Y + 1),
                Coord.Create(coord.X - 1, coord.Y),
                Coord.Create(coord.X + 1, coord.Y),
            };
            foreach (var n in neighbours)
            {
                if (!_grid.IsInside(n))
                {
                    retVal++;
                    continue;
                }
                if (_coords[n] != _coords[coord])
                {
                    retVal++;
                    continue;
                }
            }
            return retVal;
        }


        public static string Run()
        {
            var model = Model.Parse();
            _grid = model.Grid;
            long sum = 0;

            var areaIndex = 0;
            for (int x = 0; x < _grid.Width; x++)
            {
                for (int y = 0; y < _grid.Height; y++)
                {
                    var coord = Coord.Create(x, y);
                    if (_coords.ContainsKey(coord))
                        continue;
                    var startValue = model.Grid.GetValue(coord);

                    areaIndex++;
                    Traverse(coord, startValue, areaIndex);

                }
            }

            var h = _grid.Height;
            var w = _grid.Width;
            var cc = _coords.Count();

            var areaIds = _areas.Keys.ToList();
            foreach (var areaId in areaIds)
            {
                var coordsInArea = _areas[areaId];
                var numFences = 0;
                var edges = new List<Coord>();
                
                foreach (var coord in coordsInArea)
                {
                    var fences = CountFences(coord);
                    numFences += fences;
                    if (fences > 0)
                        edges.Add(coord);

                    // Start with a random edge. He will get the number of his total number of fences.
                    // top/bottom/right/left will be marked on him along with 1 on each.
                    // Recursively go through "all" adjacent edges. Let's go with one... if he
                    // shares an edge with the previous, remove 1 from that edge...
                    // When no more adjacent edges can be found, pick another random edge that has not yet been
                    // visited...
                }
                sum += numFences * coordsInArea.Count;
            }

            return sum.ToString();
        }
    }
}
