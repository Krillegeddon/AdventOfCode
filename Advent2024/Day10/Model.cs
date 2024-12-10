using AdventUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent2024.Day10
{
    public class Grid : GridBase<int>
    {

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
                    retObj.Grid.SetValue(Coord.Create(i, y), int.Parse(c.ToString()));
                }
                y++;
            }

            return retObj;
        }
    }
}
