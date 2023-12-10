using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent2023.Day10
{
    public class Logic
    {
        private static bool FillOutside(Grid g, int x, int y)
        {
            var curr = g.Get(x, y);
            if (curr.PipeDirection != PipeDirection.Ground)
                return false;

            // we are on a ground... check if there are any open points next to us.
            for (int x2 = curr.X - 1; x2 <= curr.X + 1; x2++)
            {
                for (int y2 = curr.Y - 1; y2 <= curr.Y + 1; y2++)
                {
                    var neighbour = g.Get(x2, y2);
                    if (neighbour.PipeDirection == PipeDirection.Outside)
                    {
                        g.Set(x, y, PipeDirection.Outside);
                        return true;
                    }
                }
            }
            return false;
        }


        private static int CalculateStep2(List<Coordinate> previousSteps)
        {
            // Create a new grid, just consisting of the main pipe!
            var g = new Grid()
            {
                Cells = new List<Coordinate>()
            };

            foreach (var step in previousSteps)
            {
                g.Set(step.X, step.Y, step.PipeDirection);
            }

            // Print out the map.
            Debugging.DumpToPipesText(g);


            g.Set(0, 0, PipeDirection.Outside);
            // Now, manually find a start coordinate and the first coordinate to check.
            // Make sure that if you move from start to first, the starboard side of should be pointed to the outside of the pipe.. logic is to
            // mark all ground-coordinates to the starboard as being outside...
            // NOTE!! In the Walk-method, you also need to find how the S mark works like. I have simply hard-coded in my
            // test data that is is a 7, west-south... really ugly solution though!

            // Test data:
            //g.Set(0, 1, PipeDirection.Outside);
            //var start = g.Get(1, 1);
            //var first = g.Get(1, 2);

            // My real data:
            g.Set(2, 43, PipeDirection.Outside);
            var start = g.Get(3, 43);
            var first = g.Get(3, 44);

            Walk(g, first, new List<Coordinate> { start }, true);

            // When Walk returns, all adjecent ground coordinates are marked with Outside that are to the starboard side...
            // final thing (not soo pretty), just loop through all coordinates that are ground - if those ground coordinates
            // have an adjacent Outside-coordinate - then the ground coordinate is actually also an Outside coordinate.

            g.Set(0, 0, PipeDirection.Outside);

            Debugging.DumpToPipesText(g);

            var hasChanged = true;
            while (hasChanged)
            {
                hasChanged = false;
                for (int y = 0; y < 140; y++)
                {
                    for (int x = 0; x < 140; x++)
                    {
                        if (FillOutside(g, x, y))
                            hasChanged = true;
                    }
                }
                Debugging.DumpToPipesText(g);
            }

            // Now we just count number of ground coordinates...
            var numGrounds = 0;
            for (int y = 0; y < 140; y++)
            {
                for (int x = 0; x < 140; x++)
                {
                    if (g.Get(x, y).PipeDirection == PipeDirection.Ground)
                        numGrounds++;
                }
            }

            return numGrounds;
        }

        private static void Walk(Grid g, Coordinate currentCoordinateRef, List<Coordinate> previousSteps, bool markOutside)
        {
            var currentCoordinate = currentCoordinateRef;
            var stopNode = previousSteps.First();

            while (true)
            {
                var previousStep = previousSteps.Last();
                previousSteps.Add(currentCoordinate);

                if (markOutside && currentCoordinate == stopNode)
                {
                    return;
                }


                if (currentCoordinate.PipeDirection == PipeDirection.Start)
                {
                    if (!markOutside)
                    {
                        return;
                    }
                }

                if (currentCoordinate.PipeDirection == PipeDirection.Ground)
                {
                    throw new Exception("We hit ground!");
                }


                if (currentCoordinate.PipeDirection == PipeDirection.NorthWest)
                {
                    if (previousStep.X == currentCoordinate.X - 1)
                    {
                        // We come from the left... we do a left turn...
                        if (markOutside)
                        {
                            g.SetOutside(currentCoordinate.X + 1, currentCoordinate.Y); // To the right
                            g.SetOutside(currentCoordinate.X, currentCoordinate.Y + 1); // To the bottom
                        }
                        currentCoordinate = g.Get(currentCoordinate.X, currentCoordinate.Y - 1);
                    }
                    else
                    {
                        // coming from the top and doing a right turn. Stareboard side does not have points to be marked Outside
                        currentCoordinate = g.Get(currentCoordinate.X - 1, currentCoordinate.Y);
                    }
                    continue;
                }

                if (currentCoordinate.PipeDirection == PipeDirection.SouthEast)
                {
                    if (previousStep.X == currentCoordinate.X + 1)
                    {
                        // We come from the right... doing a left turn downward...
                        if (markOutside)
                        {
                            g.SetOutside(currentCoordinate.X - 1, currentCoordinate.Y); // To the left
                            g.SetOutside(currentCoordinate.X, currentCoordinate.Y - 1); // To the top
                        }
                        currentCoordinate = g.Get(currentCoordinate.X, currentCoordinate.Y + 1);
                    }
                    else
                    {
                        // we come from bottom, doing a right turn... nothing to be marked as Outside!
                        currentCoordinate = g.Get(currentCoordinate.X + 1, currentCoordinate.Y);
                    }
                    continue;
                }

                if (currentCoordinate.PipeDirection == PipeDirection.SouthWest || currentCoordinate.PipeDirection == PipeDirection.Start)
                {
                    if (previousStep.X == currentCoordinate.X - 1)
                    {
                        // We come from the left... doing a right turn... nothing to mark
                        currentCoordinate = g.Get(currentCoordinate.X, currentCoordinate.Y + 1);
                    }
                    else
                    {
                        // We come from bottom, doing a left turn to the west...
                        if (markOutside)
                        {
                            g.SetOutside(currentCoordinate.X + 1, currentCoordinate.Y); // To the right
                            g.SetOutside(currentCoordinate.X, currentCoordinate.Y - 1); // To the top
                        }
                        currentCoordinate = g.Get(currentCoordinate.X - 1, currentCoordinate.Y);
                    }
                    continue;
                }

                if (currentCoordinate.PipeDirection == PipeDirection.NorthSouth)
                {
                    if (previousStep.Y == currentCoordinate.Y - 1)
                    {
                        // We come from the top...
                        if (markOutside)
                        {
                            g.SetOutside(currentCoordinate.X - 1, currentCoordinate.Y); // Stareboard side is always Outside! If we're going south, it's on the left.
                        }
                        currentCoordinate = g.Get(currentCoordinate.X, currentCoordinate.Y + 1);
                    }
                    else
                    {
                        if (markOutside)
                        {
                            g.SetOutside(currentCoordinate.X + 1, currentCoordinate.Y); // Stareboard side is always Outside! If we're going north, it's on the right.
                        }
                        currentCoordinate = g.Get(currentCoordinate.X, currentCoordinate.Y - 1);
                    }
                    continue;
                }

                if (currentCoordinate.PipeDirection == PipeDirection.NorthEast)
                {
                    if (previousStep.Y == currentCoordinate.Y - 1)
                    {
                        // We come from the top, we do a left turn (port side), and both coordinates to the left and bottom can be marked Outside.
                        if (markOutside)
                        {
                            g.SetOutside(currentCoordinate.X - 1, currentCoordinate.Y); // To the left
                            g.SetOutside(currentCoordinate.X, currentCoordinate.Y + 1); // To the bottom
                        }
                        currentCoordinate = g.Get(currentCoordinate.X + 1, currentCoordinate.Y);
                    }
                    else
                    {
                        // Coming from right, we do a right turn (stareboard), and no open coordinate will be set.
                        currentCoordinate = g.Get(currentCoordinate.X, currentCoordinate.Y - 1);
                    }
                    continue;
                }

                if (currentCoordinate.PipeDirection == PipeDirection.EastWest)
                {
                    if (previousStep.X == currentCoordinate.X - 1)
                    {
                        // We come from the left...
                        if (markOutside)
                        {
                            g.SetOutside(currentCoordinate.X, currentCoordinate.Y + 1); // below
                        }
                        currentCoordinate = g.Get(currentCoordinate.X + 1, currentCoordinate.Y);
                    }
                    else
                    {
                        if (markOutside)
                        {
                            g.SetOutside(currentCoordinate.X, currentCoordinate.Y - 1); // Above
                        }
                        currentCoordinate = g.Get(currentCoordinate.X - 1, currentCoordinate.Y);
                    }
                    continue;
                }
            }

        }


        public static string Run()
        {
            var model = Model.Parse();

            long sum = 0;

            var start = model.Grid.Cells.Where(p => p.PipeDirection == PipeDirection.Start).Single();

            var previousSteps = new List<Coordinate> { start };

            // Check straight up.
            var directionsForUp = new List<PipeDirection> { PipeDirection.NorthSouth, PipeDirection.SouthEast, PipeDirection.SouthWest };
            if (directionsForUp.Contains(model.Grid.Get(start.X, start.Y - 1).PipeDirection))
            {
                Walk(model.Grid, model.Grid.Get(start.X, start.Y-1), previousSteps, false);
            }

            // Check to right
            var directionsForRight = new List<PipeDirection> { PipeDirection.EastWest, PipeDirection.NorthWest, PipeDirection.SouthWest };
            if (directionsForRight.Contains(model.Grid.Get(start.X + 1, start.Y).PipeDirection))
            {
                Walk(model.Grid, model.Grid.Get(start.X + 1, start.Y), previousSteps, false);
            }

            var directionsForDown = new List<PipeDirection> { PipeDirection.NorthSouth, PipeDirection.SouthWest, PipeDirection.SouthEast };
            if (directionsForDown.Contains(model.Grid.Get(start.X + 1, start.Y).PipeDirection))
            {
                Walk(model.Grid, model.Grid.Get(start.X, start.Y + 1), previousSteps, false);
            }

            // Step 1, count is pasted onto AoC!
            var count = previousSteps.Count / 2;
            var step2 = CalculateStep2(previousSteps);

            return step2.ToString();
        }
    }
}
