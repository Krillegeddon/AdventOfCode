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

        private static Dictionary<string, long> _memo;

        private static long RunRecursive(char[] row, string groupLenghts)
        {
            var memoKey = new string(row) + "_" + groupLenghts;

            if (_memo.ContainsKey(memoKey))
            {
                return _memo[memoKey];
            }

            if (string.IsNullOrEmpty(groupLenghts))
            {
                _memo.Add(memoKey, 0);
                return 0;
            }
            var lenghts = groupLenghts.Split(",").Select(p => int.Parse(p)).ToList();

            if (row.Length == 0 && groupLenghts.Length > 0)
            {
                _memo.Add(memoKey, 0);
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

            // Count number of straight #:s in the beginning...
            var numWrecks = 0;
            for (var i = 0; i < row.Length && row[i] == '#' ; i++)
            {
                numWrecks++;
            }

            if (numWrecks > lenghts.First())
            {
                // If we have more wrecks in a row than we've got in first lenghts, then we're bust!
                _memo.Add(memoKey, 0);
                return 0;
            }

            if (numWrecks < lenghts.First())
            {
                if (row.Length == numWrecks || row[numWrecks] == '.')
                {
                    // If we got fewer wrecks and then an okay spring, then we're bust as well!
                    _memo.Add(memoKey, 0);
                    return 0;
                }
                else
                {
                    // If we got fewer wrecks, but the next char is a ?, then we will check if it checks out if that ? is a #...
                    var nextStr = Copy(row);
                    var nextLenghts = lenghts.ToList();
                    nextStr[numWrecks] = '#'; // It must be a # if next run checks out!
                    var delta = RunRecursive(nextStr, string.Join(',', nextLenghts));

                    // ... and then if ? is a .
                    var nextStr2 = Copy(row);
                    var nextLenghts2 = lenghts.ToList();
                    nextStr2[numWrecks] = '.'; // It must be a # if next run checks out!
                    var delta2 = RunRecursive(nextStr2, string.Join(',', nextLenghts2));

                    // Return the sum of the both alternatives
                    _memo.Add(memoKey, delta + delta2);
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
                    _memo.Add(memoKey, 1);
                    return 1;
                }

                // If there are more lenghts, but no more string, then we're bust.
                if (nextStr.Length == 0)
                {
                    _memo.Add(memoKey, 0);
                    return 0;
                }

                // We have more lengths to check for, so then we need to force the next char to be a . ... it could already be a . or a ?,
                // but never a # - that would have failed since we were counting of wrecks!
                nextStr[0] = '.';
                return RunRecursive(nextStr, string.Join(',', nextLenghts));
            }

            // Should never happen!
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
                    var l = "";
                    for (int i = 0; i < 5; i++)
                    {
                        if (s != "")
                        {
                            s += "?";
                            l += ",";
                        }
                        s += sr.SpringString;
                        l += sr.GroupLenghts;
                    }
                    sr.SpringString = s;
                    sr.GroupLenghts = l;
                }
            }

            _memo = new Dictionary<string, long>();
            long sum = 0;
            foreach (var sr in model.SpringRows)
            {
                var num = RunRecursive(sr.SpringString.ToCharArray(), string.Join(',', sr.GroupLenghts));
                sum += num;
            }

            return sum.ToString();
        }
    }
}
