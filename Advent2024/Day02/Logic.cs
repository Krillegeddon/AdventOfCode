using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent2024.Day02
{
    public class Logic
    {
        private static bool IsSafe(List<int> numbers, out int errorIndex)
        {
            errorIndex = 0;
            var masterSign = 0;
            for (int i = 0; i<numbers.Count-1; i++)
            {
                var n1 = numbers[i];
                var n2 = numbers[i + 1];

                var sign = Math.Sign(n2 - n1);

                if (masterSign == 0)
                    masterSign = sign;

                if (masterSign != sign)
                {
                    errorIndex = i+1;
                    return false;
                }

                var diff = Math.Abs(n2 - n1);
                if (diff == 0)
                {
                    errorIndex = i+1;
                    return false;
                }
                if (diff > 3)
                {
                    errorIndex = i+1;
                    return false;
                }
            }

            return true;
        }

        public static string Run()
        {
            var model = Model.Parse();

            long sum = 0;

            foreach (var r in model.Reports)
            {
                int errorIndex = 0;
                if (IsSafe(r.Levels, out errorIndex))
                {
                    sum++;
                    continue;
                }

                for (int i = 0; i < r.Levels.Count; i++)
                {
                    var levels = r.Levels.ToList();
                    levels.RemoveAt(i);
                    if (IsSafe(levels, out errorIndex))
                    {
                        sum++;
                        break;
                    }
                }
            }
            //527 too low.. 530 too low... 536 too high
            return sum.ToString();
        }
    }
}
