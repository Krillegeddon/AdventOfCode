using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent2023.Day17;

public class Dijkstra
{
    public static void Main()
    {
        // Exempel på användning
        Dictionary<char, Dictionary<char, int>> exampleGraph = new Dictionary<char, Dictionary<char, int>>
        {
            {'A', new Dictionary<char, int> { {'B', 1 }, {'C', 4 } } },
            {'B', new Dictionary<char, int> { {'A', 1 }, {'C', 2 }, {'D', 5 } } },
            {'C', new Dictionary<char, int> { {'A', 4 }, {'B', 2 }, {'D', 1 } } },
            {'D', new Dictionary<char, int> { {'B', 5 }, {'C', 1 } } }
        };

        char startNode = 'A';
        Dictionary<char, int> result = DijkstraAlgorithm(exampleGraph, startNode);

        Console.WriteLine($"Kortaste avstånd från nod {startNode}:");
        foreach (var entry in result)
        {
            Console.WriteLine($"{entry.Key}: {entry.Value}");
        }
    }

    static Dictionary<T, int> DijkstraAlgorithm<T>(Dictionary<T, Dictionary<T, int>> graph, T start)
    {
        Dictionary<T, int> distances = graph.Keys.ToDictionary(node => node, _ => int.MaxValue);
        distances[start] = 0;

        HashSet<T> visited = new HashSet<T>();

        while (true)
        {
            T currentNode = GetClosestNode(distances, visited);
            if (currentNode == null)
                break;

            visited.Add(currentNode);

            foreach (var neighbor in graph[currentNode])
            {
                int distance = distances[currentNode] + neighbor.Value;
                if (distance < distances[neighbor.Key])
                {
                    distances[neighbor.Key] = distance;
                }
            }
        }

        return distances;
    }

    static T GetClosestNode<T>(Dictionary<T, int> distances, HashSet<T> visited)
    {
        return distances.Where(kvp => !visited.Contains(kvp.Key)).OrderBy(kvp => kvp.Value).Select(kvp => kvp.Key).FirstOrDefault();
    }
}














public class Logic
{
    private static List<List<Block>> _blocks;
    private static Dictionary<string, bool> _alreadyWalked = new Dictionary<string, bool>();

    public static long Walk(int x, int y, long totalHeatloss, int dx, int dy, int countSameDirection, bool isFirst, int width, int height)
    {
        // Check if we are done!
        if (x == width - 1 && y == height - 1)
        {
            return totalHeatloss;
        }



        //var walkKey = $"{x}_{y}_{dx}_{dy}";
        //if (!isFirst)
        //{
        //    if (_alreadyWalked.ContainsKey(walkKey))
        //        return -1;
        //    _alreadyWalked.Add(walkKey, true);
        //}

        if (x < 0) return -1;
        if (x > width - 1) return -1;
        if (y < 0) return -1;
        if (y > height - 1) return -1;

        var currentBlock = _blocks[y][x];


        var currentHeatLoss = currentBlock.HeatLoss;
        if (isFirst)
        {
            currentHeatLoss = 0;
        }

        var distances = new List<long>();
        if (countSameDirection != 3)
        {
            // First try to walk in the same direction.
            distances.Add(Walk(x + dx, y + dy, totalHeatloss + currentHeatLoss, dx, dy, countSameDirection + 1, false, width, height));
        }
        // If we're going from side to side, then test going up and down, note that we stay on same x/y, but only change
        // dx/dy...so don't add currentHeatLoss again.
        if (dx != 0)
        {
            distances.Add(Walk(x, y, totalHeatloss, 1, 0, 0, false, width, height));
            distances.Add(Walk(y, y, totalHeatloss, -1, 0, 0, false, width, height));
        }
        else
        {
            distances.Add(Walk(x, y, totalHeatloss, 0, 1, 0, false, width, height));
            distances.Add(Walk(x, y, totalHeatloss, 0, -1, 0, false, width, height));
        }

        var positiveDistances = distances.Where(p => p >= 0);
        if (!positiveDistances.Any())
        {
            return -1;
        }

        return positiveDistances.OrderBy(p => p).First();
    }


    public static string Run()
    {
        Dijkstra.Main();


        var model = Model.Parse();

        _blocks = model.Blocks;

        var height = model.Blocks.Count;
        var width = model.Blocks.First().Count;

        var dist1 = Walk(0, 0, 0, 1, 0, 0, true, width, height);
        var dist2 = Walk(0, 0, 0, 0, 1, 0, true, width, height);


        long sum = 0;

        return sum.ToString();
    }
}
