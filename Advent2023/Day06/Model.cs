using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent2023.Day06
{
    public class Race
    {
        public long Time;
        public long RecordDistance;
    }

    public class Model
    {
        public required List<Race> Races { get; set; }

        public static Model Parse()
        {
            var retObj = new Model
            {
                Races = new List<Race>()
            };

            List<string> timeArr = null;
            List<string> distArr = null;

            foreach (var lx in Data.InputData.Split("\n"))
            {
                var l = lx.Trim();

                if (string.IsNullOrEmpty(l))
                    continue;

                l = l.Replace("  ", " ");
                l = l.Replace("  ", " ");
                l = l.Replace("  ", " ");
                l = l.Replace("  ", " ");
                l = l.Replace("  ", " ");
                l = l.Replace("  ", " ");

                if (l.StartsWith("Time:"))
                    timeArr = l.Split(" ", StringSplitOptions.None).ToList();
                else
                    distArr = l.Split(" ", StringSplitOptions.None).ToList();
            }

            for (int i = 0; i < timeArr.Count; i++)
            {
                long t;
                if (long.TryParse(timeArr[i], out t))
                {
                    long d = long.Parse(distArr[i]);

                    var race = new Race()
                    {
                        Time = t,
                        RecordDistance = d
                    };

                    retObj.Races.Add(race);
                }
            }

            return retObj;
        }
    }
}
