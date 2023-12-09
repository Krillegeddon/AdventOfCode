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

        public static string Run()
        {
            var model = Model.Parse();

            long sum = 0;

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

                while (knownInteral == 0)
                {
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
            foreach (var thread in threads)
            {
                sum *= thread.Interval;
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


            return sum.ToString();
        }
    }
}
