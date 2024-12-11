using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Advent2024.Day11
{
    public class ListInfo
    {
        public int Count { get; set; }
        public List<long> List { get; set; }
    }

    public class Logic
    {
        // Dictionary for blinking one... Dictionary as value. Key on THAT dictionary is number of blinks.
        private static Dictionary<long, Dictionary<int, long>> _cache = new Dictionary<long, Dictionary<int, long>>();

        private static void StoreCache(long number, int numBlinks, long numbers)
        {
            if (!_cache.ContainsKey(number))
            {
                _cache.Add(number, new Dictionary<int, long>());
            }
            var l = _cache[number];
            l.Add(numBlinks, numbers);
        }

        private static long GetFromCache(long number, int numBlinks)
        {
            if (!_cache.ContainsKey(number))
            {
                return -1;
            }
            var l = _cache[number];
            if (!l.ContainsKey(numBlinks))
                return -1;
            return l[numBlinks];
        }

        private static List<long> BlinkOnce(long num)
        {
            if (num == 0)
                return new List<long>() { 1 };

            if (num.ToString().Length % 2 == 0)
            {
                var middleLength = num.ToString().Length / 2;
                var s1 = num.ToString().Substring(0, middleLength);
                var s2 = num.ToString().Substring(middleLength);
                return new List<long> { long.Parse(s1), long.Parse(s2) };
            }

            return new List<long>() { num * 2024 };
        }

        private static long Blink(List<long> numbers, int numBlinks, int targetBlinks)
        {
            long retListsCount = 0;

            // If we are about to do final blink... just do the algorithm and return 1 or 2.
            if (numBlinks == targetBlinks-1)
            {
                foreach (var num in numbers)
                {
                    var l = GetFromCache(num, numBlinks);
                    if (l >= 0)
                    {
                        retListsCount += l;
                        continue;
                    }
                    var bo = BlinkOnce(num);
                    StoreCache(num, numBlinks, bo.Count);
                    retListsCount += bo.Count;
                }
                return retListsCount;
            }

            foreach (var number in numbers)
            {
                long numberListCount = 0;
                var l = GetFromCache(number, numBlinks);

                if (l >= 0)
                {
                    retListsCount += l;
                    continue;
                }

                var derNumbers = BlinkOnce(number);

                foreach (var derNumber in derNumbers)
                {
                    l = Blink(new List<long> { derNumber }, numBlinks + 1, targetBlinks);
                    numberListCount += l;
                }
                
                StoreCache(number, numBlinks, numberListCount);

                retListsCount += numberListCount;
            }

            return retListsCount;
        }


        public static string Run()
        {
            var model = Model.Parse();

            _cache = new Dictionary<long, Dictionary<int, long>>();

            var sw = new Stopwatch();
            sw.Start();
           
            var tot = Blink(model.Numbers, 0, 75);

            sw.Stop();
            var exectime = sw.ElapsedMilliseconds;

            return tot.ToString();
        }
    }
}
