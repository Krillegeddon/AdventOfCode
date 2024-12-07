using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent2024.Day07
{
    public class Logic
    {
        private static long Conc(long v1, long v2)
        {
            return long.Parse(v1.ToString() + v2.ToString());
        }

        public static bool TraverseRecursive(List<long> list, long runningSum, int index, long wantedSum)
        {
            if (index == list.Count - 1)
            {
                if (runningSum + list[index] == wantedSum)
                    return true;
                if (runningSum * list[index] == wantedSum)
                    return true;
                if (Conc(runningSum, list[index]) == wantedSum)
                    return true;
                return false;
            }

            var res1 = TraverseRecursive(list, runningSum + list[index], index+1, wantedSum);
            if (res1)
                return true;
            var res2 = TraverseRecursive(list, runningSum * list[index], index+1, wantedSum);
            if (res2)
                return true;
            var res3 = TraverseRecursive(list, Conc(runningSum, list[index]), index + 1, wantedSum);
            if (res3)
                return true;

            return false;
        }

        private static bool IsEquationCorrect(Equation eq)
        {
            return TraverseRecursive(eq.Numbers, eq.Numbers[0], 1, eq.Sum);
        }

        public static string Run()
        {
            var model = Model.Parse();

            long sum = 0;

            foreach (var eq in model.Equations)
            {
                if (IsEquationCorrect(eq))
                    sum += eq.Sum;
            }

            return sum.ToString();
        }
    }
}
