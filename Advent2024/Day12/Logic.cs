using AdventUtils;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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


        public class EdgeInfo
        {
            public bool HasTop { get; set; }
            public bool HasBottom { get; set; }
            public bool HasLeft { get; set; }
            public bool HasRight { get; set; }

            public int NumTop { get; set; }
            public int NumBottom { get; set; }
            public int NumLeft { get; set; }
            public int NumRight { get; set; }

            public EdgeInfo(bool hasTop, bool hasBottom, bool hasLeft, bool hasRight)
            {
                if (hasTop)
                {
                    HasTop = hasTop;
                    NumTop = 1;
                }
                if (hasBottom)
                {
                    HasBottom = hasBottom;
                    NumBottom = 1;
                }
                if (hasLeft)
                {
                    HasLeft = hasLeft;
                    NumLeft = 1;
                }
                if (hasRight)
                {
                    HasRight = hasRight;
                    NumRight = 1;
                }
            }
        }


        private static Dictionary<Coord, EdgeInfo> _edges = new Dictionary<Coord, EdgeInfo>();

        private static bool IsSameArea(Coord coord, AreaId areaId)
        {
            if (!_grid.IsInside(coord))
                return false;
            if (_coords[coord] != areaId) return false;
            return true;
        }

        private static void TraverseEdge(Coord coord)
        {
            // If we have already visited my location, then just return.
            if (_edges.ContainsKey(coord))
                return;

            var visistedNeighbours = GetNeighbourAreas(coord)
                .Where(p => _edges.ContainsKey(p) && _coords[p] == _coords[coord])
                .ToList();

            var areaId = _coords[coord];

            var hasFenceUp = !IsSameArea(coord.Up(), areaId);
            var hasFenceDown = !IsSameArea(coord.Down(), areaId);
            var hasFenceLeft = !IsSameArea(coord.Left(), areaId);
            var hasFenceRight = !IsSameArea(coord.Right(), areaId);
            var edgeInfo = new EdgeInfo(hasFenceUp, hasFenceDown, hasFenceLeft, hasFenceRight);

            foreach (var n in visistedNeighbours)
            {
                // Let's see if a neighbour already has counted my same edge, if so don't count my edge!
                if (_edges[n].HasTop)
                    edgeInfo.NumTop--;
                if (_edges[n].HasBottom)
                    edgeInfo.NumBottom--;
                if (_edges[n].HasLeft)
                    edgeInfo.NumLeft--;
                if (_edges[n].HasRight)
                    edgeInfo.NumRight--;
            }

            _edges.Add(coord, edgeInfo);

            var unVisistedNeighbours = GetNeighbourAreas(coord)
                .Where(p => !_edges.ContainsKey(p) && _grid.IsInside(p) && _coords[p] == _coords[coord])
                .ToList();

            foreach (var n in unVisistedNeighbours)
            {
                TraverseEdge(n);
            }

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
                
                foreach (var coord in coordsInArea)
                {
                    if (_edges.ContainsKey(coord))
                        continue;

                    var fences = CountFences(coord);
                    if (fences == 0)
                        continue;

                    // Okay, we are now at a random coordinate within an area. This guy will have the number
                    // of fences that is counted!
                    TraverseEdge(coord);

                    // Start with a random edge. He will get the number of his total number of fences.
                    // top/bottom/right/left will be marked on him along with 1 on each.
                    // Recursively go through "all" adjacent edges. Let's go with one... if he
                    // shares an edge with the previous, remove 1 from that edge...
                    // When no more adjacent edges can be found, pick another random edge that has not yet been
                    // visited...
                }

                // We have gone through all edges of this area, let's count to see how many edges there are...
                foreach (var coord in coordsInArea)
                {
                    if (!_edges.ContainsKey(coord))
                        continue;
                    numFences += _edges[coord].NumTop > 0 ? 1 : 0;
                    numFences += _edges[coord].NumBottom > 0 ? 1 : 0;
                    numFences += _edges[coord].NumLeft > 0 ? 1 : 0;
                    numFences += _edges[coord].NumRight> 0 ? 1 : 0;
                }


                sum += numFences * coordsInArea.Count;
            }

            //883041 - too high.

            return sum.ToString();
        }
    }
}
