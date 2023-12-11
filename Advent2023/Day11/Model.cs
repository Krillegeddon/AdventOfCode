using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent2023.Day11
{
    public class GalaxyCoordinate
    {
        public int Id;
        public long X;
        public long Y;
    }

    public class GalaxyPair
    {
        public GalaxyCoordinate Galaxy1;
        public GalaxyCoordinate Galaxy2;
    }

    public class Grid
    {
        public List<GalaxyCoordinate> Cells;

        public long Height;
        public long Width;

        public void CheckBoundraries(long x, long y)
        {
            if ((x + 1) >= Width)
                Width = x + 1;
            if ((y + 1) >= Height)
                Height = y + 1;
        }

        public void Set(int x, int y, int id)
        {
            CheckBoundraries(x, y);
            var cell = Get(x, y);

            if (cell == null)
            {
                cell = new GalaxyCoordinate { X = x, Y = y, Id = id };
                Cells.Add(cell);
            }
            cell.Id = id;
        }

        public GalaxyCoordinate Get(int x, int y)
        {
            var coordinate = Cells.Where(p => p.X == x && p.Y == y).FirstOrDefault();

            if (coordinate == null)
            {
                return null;
                //return new GalaxyCoordinate { X = x, Y = y, Id = -1 };
            }

            return coordinate;
        }


        private bool IsColumnGalaxyFree(long x)
        {
            var cellsInColumn = Cells.Where(p => p.X == x).ToList();
            if (cellsInColumn.Count == 0)
                return true;
            return false;
        }

        private void ExpandColumn(long x, int expansion)
        {
            foreach (var c in Cells.Where(p => p.X > x).ToList())
            {
                c.X+= expansion;
                CheckBoundraries(c.X, c.Y);
            }
        }

        private bool IsRowGalaxyFree(int y)
        {
            var cellsInRow = Cells.Where(p => p.Y == y).ToList();
            if (cellsInRow.Count == 0)
                return true;
            return false;
        }

        private void ExpandRow(int y, int expansion)
        {
            foreach (var c in Cells.Where(p => p.Y > y).ToList())
            {
                c.Y+= expansion;
                CheckBoundraries(c.X, c.Y);
            }
        }

        public void Expand(int expansion)
        {
            for (var x = 0; x < Width; x++)
            {
                if (IsColumnGalaxyFree(x))
                {
                    ExpandColumn(x, expansion);
                    x += expansion;
                }
            }

            for (var y = 0; y < Height; y++)
            {
                if (IsRowGalaxyFree(y))
                {
                    ExpandRow(y, expansion);
                    y+= expansion;
                }
            }
        }

        public void DebugWrite()
        {
            //var sb = new StringBuilder("");
            //for (int y = 0; y <= Height; y++)
            //{
            //    for (int x = 0; x <= Width; x++)
            //    {
            //        var c = Get(x, y);
            //        if (c?.Id >= 0)
            //            sb.Append(c.Id);
            //        else
            //            sb.Append(".");
            //    }
            //    sb.Append('\n');
            //}
            //File.WriteAllText("c:\\Temp\\galaxies.txt", sb.ToString());
        }

        public List<GalaxyPair> GetGalaxyPairs()
        {
            var allGalaxies = new Dictionary<int, GalaxyCoordinate>();

            foreach (var c in Cells)
            {
                if (c.Id >= 0)
                    allGalaxies.Add(c.Id, c);
            }

            var numGalaxies = allGalaxies.Count();

            var retList = new List<GalaxyPair>();

            for (int i = 0; i < numGalaxies; i++)
            {
                for (int j = i + 1; j < numGalaxies; j++)
                {
                    if (i == j)
                        continue;
                    retList.Add(new GalaxyPair()
                    {
                        Galaxy1 = allGalaxies[i],
                        Galaxy2 = allGalaxies[j],
                    }) ;
                }
            }

            return retList;
        }
    }

    public class Model
    {
        public required Grid Grid { get; set; }

        public static Model Parse()
        {
            var retObj = new Model
            {
                Grid = new Grid
                {
                    Cells = new List<GalaxyCoordinate>()
                }
            };

            var y = 0;
            int id = 0;
            foreach (var lx in Data.InputData.Split("\n"))
            {
                var l = lx.Trim();

                if (string.IsNullOrEmpty(l))
                    continue;

                var arr = l.ToCharArray();
                for (int x = 0; x < arr.Length; x++)
                {
                    if (arr[x] != '#')
                        continue;

                    retObj.Grid.Set(x, y, id);
                    id++;
                }
                y++;
            }

            retObj.Grid.DebugWrite();
            retObj.Grid.Expand(1000000-1); // Step 2, tricky... took a few minutes before I realized to expand with 999.999 lines instead of 1.000.000! :-)
            //retObj.Grid.Expand(1); // Step 1
            retObj.Grid.DebugWrite();

            return retObj;
        }
    }
}
