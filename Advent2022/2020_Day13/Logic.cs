using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent2022._2020_Day13
{
    public class Day13Handler
    {
        private Day13Vm _vm;

        private long CalculateMinutesUntilNextDeparture(long busId)
        {
            var minutesSinceLastDeparture = _vm.DepartTimestamp % busId;
            var minutesUntilNextDeparture = busId - minutesSinceLastDeparture;
            return minutesUntilNextDeparture;
        }

        /*
3  5  7  0
-  -  -
-  -  -
3  -  -
-  -  -
-  5  -
3  -  -
-  -  7
-  -  -
3  -  -  9 (3/5 connects here!)
-  5  -  10
-  -  -
3  -  -
-  -  -
-  -  7
3  5  -
-  -  -
-  -  -
3  -  -
-  -  -
-  5  -  20
3  -  7
-  -  -
-  -  -
3  -  -
-  5  -
-  -  -
3  -  -
-  -  7
-  -  -
3  5  -  30
-  -  -
-  -  -
3  -  -
-  -  -
-  5  7
3  -  -
-  -  -
-  -  -
3  -  -
-  5  -  40
-  -  -
3  -  7
-  -  -
-  -  -
3  5  -
-  -  -
-  -  -
3  -  -
-  -  7
-  5  -  50
3  -  -
-  -  -
-  -  -
3  -  -  54 (3, 5 and 7 connects here!)
-  5  -
-  -  7
3  -  -
-  -  -
-  -  -
3  5  -  60
-  -  -
-  -  -
3  -  7
-  -  -
-  5  -
3  -  -
-  -  -
-  -  -
3  -  -
-  5  7  70
-  -  -
3  -  -
-  -  -
-  -  -
3  5  -
-  -  -
-  -  7
3  -  -
-  -  -
-  5  -  80
3  -  -
-  -  -
-  -  -
3  -  7
-  5  -
-  -  -
3  -  -
-  -  -
-  -  -
3  5  -  90
-  -  7
-  -  -
3  -  -
-  -  -
-  5  -
3  -  -
-  -  -
-  -  7
3  -  -
-  5  -  100
-  -  -
3  -  -
-  -  -
-  -  -
3  5  7
-  -  -
-  -  -
3  -  -
-  -  -
         */

        private long CalculateFirstMatch(Day13Bus b1, Day13Bus b2)
        {
            for (long i = b1.BusID - b1.Offset; ; i += b1.BusID)
            {
                if ((i + b2.Offset) % b2.BusID == 0)
                {
                    return i;
                }
            }
        }

        private Day13Bus CombineTwoBussesIntoOne(Day13Bus b1, Day13Bus b2)
        {
            var firstMatch = CalculateFirstMatch(b1, b2);
            return new Day13Bus
            {
                BusID = b1.BusID * b2.BusID,
                Offset = firstMatch * -1
            };
        }

        // Strategy is to loop through all timestamps and check if we've got a hit. This would take approx 4 hours (tried it first, stopped and calculated
        // how long it would have taken to finish after I got the result using below code).
        // So, starting from the two leftmost busses and calculate the first time they will run on specified time... Take the result of this and create a new
        // bus out of them. E.g. if they have ids 3 and 5 the new ID will be 15. If the two busses match on let's say timestamp 9, the offset will be set to -9.
        // Then calculate a new bus out of the currentBus plus the third bus, and so on.
        // When done, we have one bus which offset is negated and is then the answer.
        private string SolveStep2()
        {
            var currentBus = _vm.Buses[0];
            for (int bi = 1; bi < _vm.Buses.Count; bi++)
            {
                currentBus = CombineTwoBussesIntoOne(currentBus, _vm.Buses[bi]);
            }

            return (currentBus.Offset * -1).ToString();
        }


        public static string Process(VmBase vmInput, int questionNumber)
        {
            _vm = vmInput as Day13Vm;

            if (questionNumber == 1)
            {
                long minimumDepartureTime = int.MaxValue;
                long bestBusId = -1;
                foreach (var bus in _vm.Buses)
                {
                    var departureTime = CalculateMinutesUntilNextDeparture(bus.BusID);
                    if (departureTime < minimumDepartureTime)
                    {
                        minimumDepartureTime = departureTime;
                        bestBusId = bus.BusID;
                    }
                }
                return (bestBusId * minimumDepartureTime).ToString();
            }
            if (questionNumber == 2)
            {
                return SolveStep2();
            }

            return "";

        }
    }
}
