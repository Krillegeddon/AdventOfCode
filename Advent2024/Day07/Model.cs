using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent2024.Day07
{
    public class Equation
    {
        public long Sum { get; set; }
        public List<long> Numbers { get; set; }
    }

    public class Model
    {
        public required List<Equation> Equations { get; set; }

        public static Model Parse()
        {
            var retObj = new Model
            {
                Equations = new List<Equation>()
            };

            foreach (var lx in Data.InputData.Split("\n"))
            {
                var l = lx.Trim();

                if (string.IsNullOrEmpty(l))
                    continue;

                var eq = new Equation();
                var arr1 = l.Split(":");
                eq.Sum = long.Parse(arr1[0].Trim());
                eq.Numbers = arr1[1].Trim().Split(" ").Select(p=>long.Parse(p)).ToList();
                retObj.Equations.Add(eq);
            }

            return retObj;
        }
    }
}
