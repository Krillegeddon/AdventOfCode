using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent2023.Day09
{
    public class Line
    {
        public List<long> Numbers;
    }

    public class Model
    {
        public required List<Line> Lines { get; set; }

        public static Model Parse()
        {
            var retObj = new Model
            {
                Lines = new List<Line>()
            };

            foreach (var lx in Data.InputData.Split("\n"))
            {
                var l = lx.Trim();

                if (string.IsNullOrEmpty(l))
                    continue;

                var line = new Line()
                {
                    Numbers = l.Split(" ").ToList().Select(x => long.Parse(x)).ToList()
                };
                retObj.Lines.Add(line);
            }

            return retObj;
        }
    }
}
