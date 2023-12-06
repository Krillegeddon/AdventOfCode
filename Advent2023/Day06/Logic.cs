using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent2023.Day06
{
    public class Logic
    {
        public static long CalcDist(long speed, long time)
        {
            return speed * time;
        }

        public static List<int> CalcWaysToWin(Race race)
        {
            var retList = new List<int>();
            for (int secToHoldButton = 0; secToHoldButton < race.Time; secToHoldButton++)
            {
                var runningTime = race.Time - secToHoldButton;
                var speed = secToHoldButton;
                var dist = CalcDist(speed, runningTime);
                if (dist > race.RecordDistance)
                    retList.Add(secToHoldButton);
            }

            return retList;
        }

        public static string Run()
        {
            var model = Model.Parse();

            long sum = 1;

            foreach (var race in model.Races)
            {
                var waysToWin = CalcWaysToWin(race);

                var numWays = waysToWin.Count;
                sum *= numWays;
            }

            return sum.ToString();
        }
    }
}
