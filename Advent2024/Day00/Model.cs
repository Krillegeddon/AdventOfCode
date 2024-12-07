using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent2024.Day00
{
    public class Model
    {
        public required List<object> Obj { get; set; }

        public static Model Parse()
        {
            var retObj = new Model
            {
                Obj = new List<object>()
            };

            foreach (var lx in Data.InputData.Split("\n"))
            {
                var l = lx.Trim();

                if (string.IsNullOrEmpty(l))
                    continue;
            }

            return retObj;
        }
    }
}
