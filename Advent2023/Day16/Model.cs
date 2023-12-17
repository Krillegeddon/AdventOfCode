using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent2023.Day16
{
    public class Coordinate
    {
        public int X;
        public int Y;
        public char Type;
        public bool IsEnergized;

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

        public void Set(int x, int y, char type)
        {
            if (Coordinates == null)
            {
                Coordinates = new Dictionary<string, Coordinate>();
            }

            var key = Coordinate.GetKey(x, y);
            if (Coordinates.ContainsKey(key))
            {
                Coordinates[key].Type = type;
            }
            else
            {
                Coordinates.Add(key, new Coordinate { X = x, Y = y, Type = type });
            }
        }


        public void SetEnergized(int x, int y)
        {
            if (Coordinates == null)
            {
                Coordinates = new Dictionary<string, Coordinate>();
            }

            var key = Coordinate.GetKey(x, y);
            if (Coordinates.ContainsKey(key))
            {
                Coordinates[key].IsEnergized = true ;
            }
            else
            {
                Coordinates.Add(key, new Coordinate { X = x, Y = y, Type = '.', IsEnergized = true });
            }
        }


        public void Remove(int x, int y)
        {
            var key = Coordinate.GetKey(x, y);
            if (Coordinates.ContainsKey(key))
            {
                Coordinates.Remove(key);
            }
        }

        public string GetAsString()
        {
            var sb = new StringBuilder("");
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    var c = Get(x, y);
                    if (c != null && c.IsEnergized)
                    {
                        sb.Append("#");
                    }
                    else
                    {
                        sb.Append(".");
                    }
                }
                sb.Append('\n');
            }
            return sb.ToString();
        }

        public void DebugWrite()
        {
            var s = GetAsString();
            File.WriteAllText("c:\\Temp\\energized.txt", s);
        }


    }
    public class Model
    {
        public required Grid Grid { get; set; }

        public static Model Parse()
        {
            var retObj = new Model
            {
                Grid = new Grid()
            };

            int y = 0;
            foreach (var lx in Data.InputData.Split("\n"))
            {
                var l = lx.Trim();

                if (string.IsNullOrEmpty(l))
                    continue;

                var arr = l.ToCharArray();
                for (int x = 0; x < arr.Length; x++)
                {
                    retObj.Grid.Verify(x, y);
                    if (arr[x] == '/' || arr[x] == '\\' || arr[x] == '|' || arr[x] == '-')
                        retObj.Grid.Set(x, y, arr[x]);
                }

                y++;
            }

            return retObj;
        }
    }
}
