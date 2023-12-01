
using System.Diagnostics;

var sw1 = new Stopwatch();
sw1.Start();

for (int i = 0; i < 100000; i++)
{
    Advent2022.Day01.Logic.Run();
}
sw1.Stop();

Console.WriteLine("Elapsed 1: " + sw1.ElapsedMilliseconds);

sw1 = new Stopwatch();
sw1.Start();

for (int i = 0; i < 100000; i++)
{
    Advent2022.Day01.Logic.RunOnlyParse();
}
sw1.Stop();

Console.WriteLine("Elapsed 1 (only parse): " + sw1.ElapsedMilliseconds);


var sw2 = new Stopwatch();
sw2.Start();
for (int i = 0; i < 100000; i++)
{
    Advent2022.Day01.Optimized.Run();
}
sw2.Stop();

Console.WriteLine("Elapsed 2: " + sw2.ElapsedMilliseconds);
