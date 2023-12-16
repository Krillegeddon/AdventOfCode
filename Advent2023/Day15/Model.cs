using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent2023.Day15
{
    public class Lens
    {
        public string Code;
        public char Operator;
        public int Value;
    }

    public class Model
    {
        public required List<Lens> Lenses { get; set; }

        public static Model Parse()
        {
            var retObj = new Model
            {
                Lenses = new List<Lens>()
            };

            foreach (var lx in Data.InputData.Split("\n"))
            {
                var l = lx.Trim();

                if (string.IsNullOrEmpty(l))
                    continue;

                var arr = l.Split(',');
                foreach (var lensString in arr)
                {
                    var lens = new Lens();
                    if (lensString.Contains("-"))
                    {
                        lens.Operator = '-';
                        lens.Code = lensString.Replace("-", "");
                    }
                    else
                    {
                        var arr2 = lensString.Split("=");
                        lens.Code = arr2[0];
                        lens.Operator = '=';
                        lens.Value = int.Parse(arr2[1]);
                    }
                    retObj.Lenses.Add(lens);
                }
            }

            return retObj;
        }
    }
}
