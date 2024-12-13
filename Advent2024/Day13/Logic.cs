using AdventUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent2024.Day13
{
    public class Logic
    {
        //A*x + B*y = C
        //D*x + E*y = F

        // Where x = pushes on A-button
        // y = pushes on B-button

        // A = A.X
        // B = B.X
        // C = Prize.X
        // D = A.Y
        // E = B.Y
        // F = Prize.Z
        private static long CalcX(long A, long B, long C, long D, long E, long F)
        {
            return (B * F - E * C) / (B * D - E * A);
        }

        private static long CalcY(long A, long B, long C, long x)
        {
            return (C - A * x) / B;
        }

        public static long RunOneMachine(Machine machine)
        {
            var algX = CalcX(machine.A.X, machine.B.X, machine.Prize.X, machine.A.Y, machine.B.Y, machine.Prize.Y);
            var algY = CalcY(machine.A.Y, machine.B.Y, machine.Prize.Y, algX);

            var resX = algX * machine.A.X + algY * machine.B.X;
            var resY = algX * machine.A.Y + algY * machine.B.Y;

            if (resX == machine.Prize.X && resY == machine.Prize.Y)
            {
                return algX * 3 + algY;
            }
            return 0;
        }


        public static string Run()
        {
            var model = Model.Parse();

            long sum = 0;

            foreach (var machine in model.Machines)
            {
                sum += RunOneMachine(machine);
            }

            return sum.ToString();
        }
    }
}
