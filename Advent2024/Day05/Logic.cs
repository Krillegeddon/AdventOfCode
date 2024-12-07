using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent2024.Day05
{
    public class Logic
    {
        private static List<Rule> GetRules(List<Rule> rules, int num)
        {
            return rules.Where(p => p.After == num || p.Before == num).ToList();
        }

        private static int GetPosition(Print print, int num)
        {
            for (int i = 0; i < print.Pages.Count; i++)
            {
                if (print.Pages[i] == num)
                    return i;
            }
            return -1;
        }

        private static bool IsPrintCorrect(List<Rule> rulesModel, Print print)
        {
            for (var i = 0; i<print.Pages.Count; i++)
            {
                var num = print.Pages[i];
                var rules = GetRules(rulesModel, num);

                foreach (var rule in rules)
                {
                    if (rule.After == num)
                    {
                        var otherPos = GetPosition(print, rule.Before);
                        if (otherPos == -1)
                            continue;
                        if (otherPos > i)
                            return false;
                    }
                    else
                    {
                        var otherPos = GetPosition(print, rule.After);
                        if (otherPos == -1)
                            continue;
                        if (otherPos < i)
                            return false;
                    }
                }
            }

            return true;
        }

        public static string Run()
        {
            var model = Model.Parse();

            long sum = 0;

            var tt = GetRules(model.Rules, 97);

            foreach (var p in model.Prints)
            {
                if (!IsPrintCorrect(model.Rules, p))
                {
                    continue;
                }

                var middleNum = p.Pages[p.Pages.Count / 2];
                sum += middleNum;
            }

            return sum.ToString();
        }
    }
}
