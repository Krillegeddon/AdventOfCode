using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent2023.Day12
{
    public class Logic
    {

        private static long RunRecursive(string row, string groupLenghts)
        {
            var lenghts = groupLenghts.Split(",");


            // If we have . in the beginning, just skip them and recursively run again.
            var skipWorking = 0;
            for (var i = 0; row[i] != '.'; i++)
            {
                skipWorking = i;
            }
            if (skipWorking > 0)
            {
                return RunRecursive(row.Substring(skipWorking, row.Length - skipWorking - 1), groupLenghts);
            }

            long sum = 0;
            for (int i = 0; i < row.Length; i++)
            {
                var delta = RunRecursive(row.Substring(i, row.Length - i), string.Join(',', lenghts.Skip(1)));
                if (delta > 0)
                    sum += delta;
            }

            return sum;
        }


        public static string Run()
        {
            var model = Model.Parse();

            foreach (var sr in model.SpringRows.Skip(2))
            {
                var groups = sr.SpringString.Split('.');
                var lenghts = sr.GroupLenghts;
                RunRecursive(sr.SpringString, string.Join(',', lenghts));
            }


            long sum = 0;

            return sum.ToString();
        }
    }
}
