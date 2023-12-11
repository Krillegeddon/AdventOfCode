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
        public int X;
        public int Y;
    }

    public class GalaxyPair
    {
        public GalaxyCoordinate Galaxy1;
        public GalaxyCoordinate Galaxy2;
    }

    public class Grid
    {
        public List<GalaxyCoordinate> Cells;

        public int Height;
        public int Width;

        public void CheckBoundraries(int x, int y)
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
            cell.Id = id;
        }

        public GalaxyCoordinate Get(int x, int y)
        {
            var coordinate = Cells.Where(p => p.X == x && p.Y == y).FirstOrDefault();

            if (coordinate == null)
            {
                coordinate = new GalaxyCoordinate { X = x, Y = y, Id = -1 };
                Cells.Add(coordinate);
            }

            return coordinate;
        }


        private bool IsColumnGalaxyFree(int x)
        {
            for (int y = 0; y < Height; y++)
            {
                var c = Get(x, y);
                if (c.Id >= 0)
                    return false;
            }
            return true;
        }

        private void ExpandColumn(int x)
        {
            foreach (var c in Cells.Where(p => p.X > x).ToList())
            {
                c.X++;
                CheckBoundraries(c.X, c.Y);
            }
        }

        private bool IsRowGalaxyFree(int y)
        {
            for (int x = 0; x < Width; x++)
            {
                var c = Get(x, y);
                if (c.Id >= 0)
                    return false;
            }
            return true;
        }

        private void ExpandRow(int y)
        {
            foreach (var c in Cells.Where(p => p.Y > y).ToList())
            {
                c.Y++;
                CheckBoundraries(c.X, c.Y);
            }
        }

        public void Expand()
        {
            for (var x = 0; x < Width; x++)
            {
                if (IsColumnGalaxyFree(x))
                {
                    ExpandColumn(x);
                    x++;
                }
            }

            for (var y = 0; y < Height; y++)
            {
                if (IsRowGalaxyFree(y))
                {
                    ExpandRow(y);
                    y++;
                }
            }
        }

        public void DebugWrite()
        {
            var sb = new StringBuilder("");
            for (int y = 0; y <= Height; y++)
            {
                for (int x = 0; x <= Width; x++)
                {
                    var c = Get(x, y);
                    if (c.Id >= 0)
                        sb.Append(c.Id);
                    else
                        sb.Append(".");
                }
                sb.Append('\n');
            }
            File.WriteAllText("c:\\Temp\\galaxies.txt", sb.ToString());
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
            retObj.Grid.Expand();
            retObj.Grid.DebugWrite();

            return retObj;
        }
    }
}
