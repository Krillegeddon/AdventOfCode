using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent2023.Day08
{
    public class Logic
    {
        public class NodeThread
        {
            public Node Node;
            public long Interval;

            public void Move(Model model, char dir)
            {
                if (dir == 'L')
                {
                    Node = model.Nodes[Node.Left];
                }
                else
                {
                    Node = model.Nodes[Node.Right];
                }
            }

            public bool IsOnZ()
            {
                return Node.Code.EndsWith("Z");
            }
        }

        private static bool IsAllThreadsOnZ(List<NodeThread> threads)
        {
            foreach (var thread in threads)
            {
                if (!thread.IsOnZ())
                    return false;
            }
            return true;
        }

        static decimal GCD(decimal a, decimal b)
        {
            while (b != 0)
            {
                decimal temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }

        // Funktion för att beräkna LCM (minsta gemensamma multipel)
        static decimal LCM(decimal a, decimal b)
        {
            return (a * b) / GCD(a, b);
        }



        public static string Run()
        {
            var model = Model.Parse();

            decimal sum = 0;
            long suml = 0;
            ulong sumu = 0;

            var threads = new List<NodeThread>();

            var nodes = model.Nodes.Where(p => p.Key.EndsWith("A")).Select(p => p.Value).ToList();
            foreach (var node in nodes)
            {
                var thread = new NodeThread()
                {
                    Node = node
                };
                threads.Add(thread);

                var endNodes = new Dictionary<string, bool>();

                var firstCode = thread.Node.Code;
                var numSinceLast = 0;
                var knownInteral = 0;
                var numRuns = 0;

                while (knownInteral == 0)
                {
                    numRuns++;
                    int num = 0;
                    foreach (var dir in model.Path)
                    {
                        thread.Move(model, dir);
                        numSinceLast++;
                        if (thread.Node.Code == firstCode)
                        {
                            int bb = 9;
                        }
                        if (thread.IsOnZ())
                        {
                            int bb = 9;
                            knownInteral = numSinceLast;
                            thread.Interval = knownInteral;
                            numSinceLast = 0;
                            if (!endNodes.ContainsKey(thread.Node.Code))
                                endNodes.Add(thread.Node.Code, true);
                        }
                        sum++;
                        num++;
                    }
                }

                int zz = 9;
                zz++;
            }

            sum = 1;
            suml = 1;
            sumu = 1;
            var xx = ulong.MaxValue;
            var prevSum = sumu;

            foreach (var thread in threads)
            {
                sum = LCM(sum, thread.Interval);

                //sum *= (thread.Interval);         // 21838660345787142275147567M

                var c = sum / thread.Interval;

                suml *= (thread.Interval);        // 2758780173146203951
                sumu *= (ulong)(thread.Interval); // 2758780173146203951
                // chat gpt:                         878695453606833773671 (asked ChatGPT to calculate power of all my values - totally wrong, though!!)
                // maxvalue (ulong):                 18446744073709551615
                // LCM:                              12030780859469 (Correct answer!)
                if (c == prevSum)
                {
                    int bb = 0;
                }
                prevSum = sumu;
            }


            //var currentNode = model.Nodes["AAA"];
            //while (true)
            //{
            //    foreach (var dir in model.Path)
            //    {
            //        if (dir == 'L')
            //        {
            //            currentNode = model.Nodes[currentNode.Left];
            //        }
            //        else
            //        {
            //            currentNode = model.Nodes[currentNode.Right];
            //        }
            //        sum++;
            //        if (currentNode.Code == "ZZZ")
            //        {
            //            int bb = 9;
            //        }
            //    }
            //}


            // 21838660345787142275147567M
            // 878695453606833773671

            return sum.ToString();

            //21838660345787142275147567M
        }
    }
}
