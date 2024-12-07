using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent2024.Day05
{
    public class Rule
    {
        public int Before { get; set; }
        public int After { get; set; }

        public override string ToString()
        {
            return $"{Before} | {After}";
        }
    }

    public class Print
    {
        public List<int> Pages { get; set; }
        public override string ToString()
        {
            return string.Join(", ", Pages);
        }
    }

    public class Model
    {
        public required List<Rule> Rules { get; set; }
        public required List<Print> Prints { get; set; }

        public static Model Parse()
        {
            var retObj = new Model
            {
                Rules = new List<Rule>(),
                Prints = new List<Print>()
            };

            foreach (var lx in Data.InputData.Split("\n"))
            {
                var l = lx.Trim();

                if (string.IsNullOrEmpty(l))
                    continue;

                if (l.Contains("|"))
                {
                    var rarr = l.Split('|');
                    var rule = new Rule()
                    {
                        Before = int.Parse(rarr[0]),
                        After = int.Parse(rarr[1])
                    };
                    retObj.Rules.Add(rule);
                }

                if (l.Contains(","))
                {
                    var parr = l.Split(",");
                    var print = new Print()
                    {
                        Pages = new List<int>()
                    };
                    foreach (var p in parr)
                    {
                        print.Pages.Add(int.Parse(p));
                    }
                    retObj.Prints.Add(print);
                }
            }

            return retObj;
        }
    }
}
