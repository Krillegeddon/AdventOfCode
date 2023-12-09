using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;

namespace Advent2022._2020_Day13
{
    public class Utils
    {
        public static List<string> SimpleSplit(string input, char c)
        {
            return input.Split(new char[] { c }, StringSplitOptions.None).ToList();
        }

        public static List<string> SimpleSplit(string input, string c)
        {
            return input.Split(new string[] { c }, StringSplitOptions.None).ToList();
        }

        public static int CountOccurances(string input, char c)
        {
            int counter = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == c)
                    counter++;
            }
            return counter;
        }

        public static List<T> ReverseList<T>(List<T> list)
        {
            var retList = new List<T>();

            for (int i = list.Count - 1; i >= 0; i--)
            {
                retList.Add(list[i]);
            }

            return retList;
        }
    }

    public class Bits
    {
        private bool[] _bits;
        public Bits(int numBits, long value)
        {
            _bits = new bool[numBits];

            int mask = 1;
            for (int i = 0; i < _bits.Length; i++)
            {
                if ((value & mask) > 0) _bits[i] = true;
                mask = mask << 1;
            }
        }

        public Bits(List<bool> bools)
        {
            _bits = new bool[bools.Count];
            for (int i = 0; i < bools.Count; i++)
            {
                _bits[i] = bools[i];
            }
        }

        public void SetBitValue(int index, bool value)
        {
            _bits[index] = value;
        }

        public bool GetBitValue(int index)
        {
            return _bits[index];
        }

        public long GetValue()
        {
            long mask = 1;
            long ret = 0;
            for (int i = 0; i < _bits.Length; i++)
            {
                if (_bits[i])
                    ret += mask;
                mask = mask << 1;
            }

            return ret;
        }
    }

    public abstract class ParserBase
    {
        public virtual VmBase Parse(string input)
        {
            return null;
        }
    }

    public abstract class VmBase
    {
    }

    public class Day13Bus
    {
        public long BusID { get; set; }
        public long Offset { get; set; }
    }

    public class Day13Vm : VmBase
    {
        public int DepartTimestamp { get; set; }
        public List<Day13Bus> Buses { get; set; }
    }

    public class Day13Parser : ParserBase
    {
        public override VmBase Parse(string input)
        {
            var retObj = new Day13Vm
            {
                Buses = new List<Day13Bus>()
            };

            int lineNum = 0;
            var inputStripped = input.Replace("\r", "");
            foreach (var line in Utils.SimpleSplit(inputStripped, "\n").ToList())
            {
                if (lineNum == 0)
                {
                    retObj.DepartTimestamp = int.Parse(line);
                }

                if (lineNum == 1)
                {
                    int offset = 0;
                    var busList = Utils.SimpleSplit(line, ',');
                    foreach (var busId in busList)
                    {
                        if (busId == "x")
                        {
                            offset++;
                            continue;
                        }
                        var bus = new Day13Bus
                        {
                            BusID = int.Parse(busId),
                            Offset = offset
                        };
                        retObj.Buses.Add(bus);
                        offset++;
                    }
                }

                lineNum++;
            }
            return retObj;
        }
    }
}
