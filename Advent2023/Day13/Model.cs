using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent2023.Day13
{
    public class Coordinate
    {
        public int X;
        public int Y;

        public string GetKey()
        {
            return GetKey(X, Y);
        }

        public static string GetKey(int x, int y)
        {
            return x + "_" + y;
        }
    }

    public class Grid
    {
        public Dictionary<string, Coordinate> Coordinates;
        public int Width = 0;
        public int Height = 0;
        public string AsString;
        public Coordinate Get(int x, int y)
        {
            var key = Coordinate.GetKey(x, y);
            if (Coordinates == null)
                return null;
            if (Coordinates.ContainsKey(key))
            {
                return Coordinates[key];
            }
            return null;
        }

        public void Verify(int x, int y)
        {
            if (x + 1 > Width)
            {
                Width = x + 1;
            }

            if (y + 1 > Height)
            {
                Height = y + 1;
            }
        }

        public void Set(int x, int y)
        {
            if (Coordinates == null)
            {
                Coordinates = new Dictionary<string, Coordinate>();
            }

            var key = Coordinate.GetKey(x, y);
            if (Coordinates.ContainsKey(key))
            {
            }
            else
            {
                Coordinates.Add(key, new Coordinate { X = x, Y = y });
            }

        }
    }

    public class Model
    {
        public required List<Grid> Grids { get; set; }

        public static Model Parse()
        {
            var retObj = new Model
            {
                Grids = new List<Grid>()
            };

            Grid currentGrid = null;
            int y = 0;
            foreach (var lx in Data.InputData.Split("\n"))
            {
                var l = lx.Trim();

                if (string.IsNullOrEmpty(l))
                {
                    if (currentGrid != null)
                        retObj.Grids.Add(currentGrid);

                    currentGrid = null;
                    continue;
                }

                if (currentGrid == null)
                {
                    y = 0;
                    currentGrid = new Grid();
                    currentGrid.AsString = "";
                }

                var arr = l.ToCharArray();
                currentGrid.AsString += l + "\n";
                for (int x = 0; x < arr.Length; x++)
                {
                    currentGrid.Verify(x, y);
                    if (arr[x] == '#')
                        currentGrid.Set(x, y);
                }

                y++;
            }

            return retObj;
        }
    }
}
