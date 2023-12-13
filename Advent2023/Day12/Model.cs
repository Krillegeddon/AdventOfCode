using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent2023.Day12
{
    public class SpringRow
    {
        public string SpringString;
        public string GroupLenghts;
    }

    public class Model
    {
        public required List<SpringRow> SpringRows { get; set; }

        public static Model Parse()
        {
            var retObj = new Model
            {
                SpringRows = new List<SpringRow>()
            };

            foreach (var lx in Data.InputData.Split("\n"))
            {
                var l = lx.Trim();

                if (string.IsNullOrEmpty(l))
                    continue;

                var arr = l.Split(' ');
                var sr = new SpringRow()
                {
                    SpringString = arr[0],
                    GroupLenghts = arr[1]
                };
                retObj.SpringRows.Add(sr);

            }

            return retObj;
        }
    }
}
