using AdventUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent2024.Day08
{
    public class Logic
    {
        private static Dictionary<string, List<Coord>> _antennas;
        private static Grid _grid;

        public static void CreateAntinodesForPair(Coord first, Coord second)
        {
            var dx = first.X - second.X;
            var dy = first.Y - second.Y;

            // Only change for Part2 was to add this, note from 0 since even the antenna positions should be considered
            // as antinodes.
            for (int i = 0; true; i++)
            {
                var a = new Coord { X = first.X + dx * i, Y = first.Y + dy * i };
                var b = new Coord { X = second.X - dx * i, Y = second.Y - dy * i };

                int numAdded = 0;
                if (_grid.IsWithin(a))
                {
                    _grid.AddAntiNode(a);
                    numAdded++;
                }
                if (_grid.IsWithin(b))
                {
                    _grid.AddAntiNode(b);
                    numAdded++;
                }
                // Both a and b are out of bounds, nothing more to add.
                if (numAdded == 0)
                    return;
            }
        }

        public static void AddAntinodesForId(string id)
        {
            var coords = _antennas[id];

            for (int i = 0; i < coords.Count - 1; i++)
            {
                for (int j = i + 1; j < coords.Count; j++)
                {
                    CreateAntinodesForPair(coords[i], coords[j]);
                }
            }
        }

        public static string Run()
        {
            var model = Model.Parse();
            _grid = model.Grid;
            _antennas = new Dictionary<string, List<Coord>>();

            long sum = 0;

            for (int x = 0; x < model.Grid.Width; x++)
            {
                for (int y = 0; y < model.Grid.Height; y++)
                {
                    var coord = new Coord { X = x, Y = y };
                    var id = _grid.GetChar(coord);
                    if (id != ".")
                    {
                        if (!_antennas.ContainsKey(id))
                        {
                            _antennas.Add(id, new List<Coord>());
                        }
                        _antennas[id].Add(coord);
                    }
                }
            }

            foreach (var kvp in _antennas)
            {
                AddAntinodesForId(kvp.Key);
            }

            sum = _grid.Antinodes.Count();

            return sum.ToString();
        }
    }
}
