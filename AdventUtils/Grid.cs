using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace AdventUtils
{
    public record Coord
    {
        public long X { get; set; }
        public long Y { get; set; }

        [DebuggerHidden]
        public Coord Copy()
        {
            return Coord.Create(X, Y);
        }
        [DebuggerHidden]
        public static Coord Create(int x, int y)
        {
            return new Coord {X = x, Y = y};
        }
        [DebuggerHidden]
        public static Coord Create(long x, long y)
        {
            return new Coord { X = x, Y = y };
        }

        [DebuggerHidden]
        public override string ToString()
        {
            return X + "," + Y;
        }
    }

    public class GridBase<T>
    {
        public long Height { get; set; }
        public long Width { get; set; }

        private Dictionary<Coord, T> _grid = new Dictionary<Coord, T>();

        public bool IsInside(Coord coord)
        {
            return IsWithin(coord);
        }

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

        public T GetValue(Coord coord)
        {
            if (!IsWithin(coord))
                return default;

            if (!_grid.ContainsKey(coord))
                return default;

            return _grid[coord];
        }

        public void SetValue(Coord coord, T value)
        {
            if (coord.X >= Width)
                Width = coord.X + 1;
            if (coord.Y >= Height)
                Height = coord.Y + 1;
            _grid[coord] = value;
        }
    }
}
