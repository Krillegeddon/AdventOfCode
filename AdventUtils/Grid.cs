using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace AdventUtils
{
    public record Coord
    {
        public int X { get; set; }
        public int Y { get; set; }

        public static Coord Create(int x, int y)
        {
            return new Coord {X = x, Y = y};
        }

        public override string ToString()
        {
            return X + "," + Y;
        }
    }

    public class GridBase
    {
        public int Height { get; set; }
        public int Width { get; set; }

        private Dictionary<Coord, string> _grid = new Dictionary<Coord, string>();

        public bool IsWithin(Coord coord)
        {
            if (coord.X < 0 || coord.Y < 0)
                return false;

            if (coord.Y >= Height)
                return false;
            if (coord.X >= Width)
                return false;

            return true;
        }

        public string GetChar(Coord coord)
        {
            if (!IsWithin(coord))
                return "";

            if (!_grid.ContainsKey(coord))
                return "";

            return _grid[coord];
        }

        public void SetChar(Coord coord, string value)
        {
            if (coord.X >= Width)
                Width = coord.X + 1;
            if (coord.Y >= Height)
                Height = coord.Y + 1;
            _grid[coord] = value;
        }
    }
}
