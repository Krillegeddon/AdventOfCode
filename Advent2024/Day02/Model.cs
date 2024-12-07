using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent2024.Day02
{

    public class Report
    {
        public List<int> Levels { get; set; }
    }

    public class Model
    {
        public required List<Report> Reports { get; set; }

        public static Model Parse()
        {
            var retObj = new Model
            {
                Reports = new List<Report>()
            };

            foreach (var lx in Data.InputData.Split("\n"))
            {
                var l = lx.Trim();

                if (string.IsNullOrEmpty(l))
                    continue;

                var r = new Report()
                {
                    Levels = new List<int>()
                };

                var arr = l.Split(" ");
                foreach (var x in arr)
                {
                    r.Levels.Add(int.Parse(x));
                }

                retObj.Reports.Add(r);
            }

            return retObj;
        }
    }
}
