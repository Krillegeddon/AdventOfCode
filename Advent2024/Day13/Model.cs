using AdventUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent2024.Day13
{
    public class Machine
    {
        public Coord A { get; set; }
        public Coord B { get; set; }
        public Coord Prize {get; set; }
    }

    public class Model
    {
        public required List<Machine> Machines { get; set; }

        private static Coord ParseCoord(string l)
        {
            var arr = l.Split(":");
            var arr2 = arr[1].Split(",");
            var xStr = arr2[0].Replace("X+", "").Replace("X=", "").Trim();
            var yStr = arr2[1].Replace("Y+", "").Replace("Y=", "").Trim();
            
            return Coord.Create(int.Parse(xStr), int.Parse(yStr));
        }

        public static Model Parse()
        {
            var retObj = new Model
            {
                Machines = new List<Machine>()
            };

            Machine currentMachine = null;

            foreach (var lx in Data.InputData.Split("\n"))
            {
                var l = lx.Trim();

                if (l.StartsWith("Button A:"))
                {
                    currentMachine = new Machine();
                    currentMachine.A = ParseCoord(l);
                }

                if (l.StartsWith("Button B:") && currentMachine != null)
                {
                    currentMachine.B = ParseCoord(l);
                }

                if (l.StartsWith("Prize:") && currentMachine != null)
                {
                    currentMachine.Prize = ParseCoord(l);
                    currentMachine.Prize.X += 10000000000000;
                    currentMachine.Prize.Y += 10000000000000;
                }

                if (string.IsNullOrEmpty(l))
                {
                    retObj.Machines.Add(currentMachine);
                    currentMachine = null;
                }
            }
            retObj.Machines.Add(currentMachine);
            currentMachine = null;

            return retObj;
        }
    }
}
