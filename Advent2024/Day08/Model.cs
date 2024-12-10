using Advent2024.Day06;
using AdventUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent2024.Day08
{

    public class Grid : GridBase<string>
    {
        public required Dictionary<string, bool> Antinodes { get; set; }

        public void AddAntiNode(Coord coord)
        {
            if (!Antinodes.ContainsKey(coord.ToString()))
            {
                Antinodes.Add(coord.ToString(), true);
            }
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
                    Antinodes = new Dictionary<string, bool>()
                }
            };

            var y = 0;
            foreach (var lx in Data.InputData.Split("\n"))
            {
                var l = lx.Trim();

                if (string.IsNullOrEmpty(l))
                    continue;

                var arr = l.ToCharArray();
                for (var i = 0; i < arr.Length; i++)
                {
                    var c = arr[i];
                    retObj.Grid.SetValue(Coord.Create(i, y), c.ToString());
                }
                y++;
            }

            return retObj;
        }
    }
}
