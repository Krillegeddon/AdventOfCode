using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent2024.Day04
{
    public class Grid
    {
        public int Height { get; set; }
        public int Width { get; set; }


        public required List<List<string>> Arr { get; set; }

        public string GetChar(int x, int y)
        {
            if (x < 0 || y < 0)
                return "";
                
            if (y >= Arr.Count)
                return "";
            if (x >= Arr[y].Count)
                return "";
            return Arr[y][x];
        }
    }

    public class Model
    {
        public Grid Grid { get; set; }

        public static Model Parse()
        {
            var retObj = new Model
            {
                Grid = new Grid()
                {
                    Arr = new List<List<string>>()
                }
            };

            foreach (var lx in Data.InputData.Split("\n"))
            {
                var l = lx.Trim();

                if (string.IsNullOrEmpty(l))
                    continue;

                var row = new List<string>();
                var arr = l.ToCharArray();
                foreach (var c in arr)
                {
                    row.Add(c.ToString());
                }
                retObj.Grid.Arr.Add(row);
                retObj.Grid.Height++;
                if (row.Count > retObj.Grid.Width)
                {
                    retObj.Grid.Width = row.Count;
                }
            }

            return retObj;
        }
    }
}
