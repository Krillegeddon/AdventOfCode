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
                        {
                            return false;
                        }
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


        private static List<int> Organize(List<Rule> rulesModel, Print print)
        {
            var retList = new List<int>();

            foreach (var num in print.Pages)
            {
                if (retList.Count == 0)
                {
                    retList.Add(num);
                    continue;
                }
                bool wasInserted = false;
                for (int i = 0; i < retList.Count; i++)
                {
                    var curr = retList[i];
                    var rule = rulesModel.Where(p => p.Before == num && p.After == curr).SingleOrDefault();
                    if (rule != null)
                    {
                        // Rule says the new value should be inserted before the current one..
                        retList.Insert(i, num);
                        wasInserted = true;
                        break;
                    }
                }
                // Okay, it was not inserted before anything, then add it to the end.
                if (!wasInserted)
                    retList.Add(num);
                
            }

            return retList;
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
                    var correct = Organize(model.Rules, p);
                    var middleNum2 = correct[correct.Count / 2];
                    sum += middleNum2;
                    continue;
                }

                // Part 1 logic:
                //var middleNum = p.Pages[p.Pages.Count / 2];
                //sum += middleNum;
            }

            return sum.ToString();
        }
    }
}
