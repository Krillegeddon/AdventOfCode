using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent2023.Day12
{
    public class Logic
    {
        [DebuggerHidden]
        private static char[] Copy(char[] source)
        {
            var retObj = new char[source.Length];
            for (int i = 0; i < source.Length; i++)
            {
                retObj[i] = source[i];
            }
            return retObj;
        }

        [DebuggerHidden]
        private static char[] Copy(char[] source, int skipNum)
        {
            var retObj = new char[source.Length - skipNum];
            for (int i = skipNum; i < source.Length; i++)
            {
                retObj[i - skipNum] = source[i];
            }
            return retObj;
        }

        private static Dictionary<string, long> Memo;

        private static long RunRecursive(char[] row, string groupLenghts)
        {
            var memoKey = new string(row) + "_" + groupLenghts;

            if (Memo.ContainsKey(memoKey))
            {
                return Memo[memoKey];
            }

            if (string.IsNullOrEmpty(groupLenghts))
            {
                Memo.Add(memoKey, 0);
                return 0;
            }
            List<int> lenghts = null;
            try
            {
                lenghts = groupLenghts.Split(",").Select(p => int.Parse(p)).ToList();
            }
            catch (Exception e)
            {
                int bbb = 9;
            }

            if (row.Length == 0 && groupLenghts.Length > 0)
            {
                Memo.Add(memoKey, 0);
                return 0;
            }

            // If we have . in the beginning, just skip them and recursively run again.
            var skipWorking = 0;
            for (var i = 0; i<row.Length && row[i] == '.'; i++)
            {
                skipWorking++;
            }
            if (skipWorking > 0)
            {
                return RunRecursive(Copy(row, skipWorking), groupLenghts);
            }

            // Count number of straight #:s in the beginning... se if they match the first groupLength!
            var numWrecks = 0;
            for (var i = 0; i < row.Length && row[i] == '#' ; i++)
            {
                numWrecks++;
            }

            if (numWrecks > lenghts.First())
            {
                // If we have more wrecks in a row than we've got in first lenghts, then we're bust!
                Memo.Add(memoKey, 0);
                return 0;
            }

            if (numWrecks < lenghts.First())
            {
                if (row.Length == numWrecks || row[numWrecks] == '.')
                {
                    // If we got fewer wrecks and then an okay spring, then we're bust as well!
                    Memo.Add(memoKey, 0);
                    return 0;
                }
                else
                {
                    // If the next char is a ?, then we will check if it checks out if that one is a #. If so,
                    var nextStr = Copy(row);
                    var nextLenghts = lenghts.ToList();
                    nextStr[numWrecks] = '#'; // It must be a # if next run checks out!
                    var delta = RunRecursive(nextStr, string.Join(',', nextLenghts));

                    var nextStr2 = Copy(row);
                    var nextLenghts2 = lenghts.ToList();
                    nextStr2[numWrecks] = '.'; // It must be a # if next run checks out!
                    var delta2 = RunRecursive(nextStr2, string.Join(',', nextLenghts2));

                    Memo.Add(memoKey, delta + delta2);
                    return delta + delta2;
                }
            }

            if (numWrecks == lenghts.First())
            {
                // Hey, we've got a possible match!

                var nextStr = Copy(row, numWrecks);
                var nextLenghts = lenghts.Skip(1).ToList();

                // If we are done - then there are no nextLenghts, and no more # in the string!
                if (nextLenghts.Count == 0 && nextStr.Where(p => p == '#').ToList().Count == 0)
                {
                    Memo.Add(memoKey, 1);
                    return 1;
                }

                if (nextStr.Length == 0)
                {
                    Memo.Add(memoKey, 0);
                    return 0;
                }

                nextStr[0] = '.'; // In case the next recursive run works, then next char is a ., and "next char" is at index 0
                return RunRecursive(nextStr, string.Join(',', nextLenghts));
            }

            return 0;

        }


        public static string Run()
        {
            var model = Model.Parse();

            // Part 2:
            if (true)
            {
                foreach (var sr in model.SpringRows)
                {
                    var s = "";
                    var cc = "";
                    for (int i = 0; i < 5; i++)
                    {
                        if (s != "")
                        {
                            s += "?";
                            cc += ",";
                        }
                        s += sr.SpringString;
                        cc += string.Join(',', sr.GroupLenghts);
                    }
                    sr.SpringString = s;
                    sr.GroupLenghts = cc.Split(',').Select(p => int.Parse(p)).ToList();
                }
            }

            Memo = new Dictionary<string, long>();
            long sum = 0;
            int r = 0;
            foreach (var sr in model.SpringRows)
            {
                var groups = sr.SpringString.Split('.');
                var lenghts = sr.GroupLenghts;
                var num = RunRecursive(sr.SpringString.ToCharArray(), string.Join(',', lenghts));
                sum += num;
                int bbb = 9;
                r++;
                Console.WriteLine(r);
            }

            return sum.ToString();
        }
    }
}
