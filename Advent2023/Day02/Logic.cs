using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent2023.Day02
{
    public class Logic
    {
        private static bool IsOkaySet(GameSet set)
        {
            if (set.NumRed > 12) return false;
            if (set.NumGreen > 13) return false;
            if (set.NumBlue > 14) return false;
            return true;
        }

        private static bool IsOkayGame(Game g)
        {
            foreach (var set in g.GameSets)
            {
                if (!IsOkaySet(set)) return false;
            }
            return true;
        }

        private static GameSet GetMaximumSet(Game g)
        {
            var retObj = new GameSet();

            foreach (var set in g.GameSets)
            {
                if (set.NumRed > retObj.NumRed)
                    retObj.NumRed = set.NumRed;
                if (set.NumGreen > retObj.NumGreen)
                    retObj.NumGreen = set.NumGreen;
                if (set.NumBlue > retObj.NumBlue)
                    retObj.NumBlue = set.NumBlue;
            }
            return retObj;
        }

        public static string Run()
        {
            var model = Model.Parse(2);

            int sum = 0;

            foreach (var game in model.Games)
            {
                if (IsOkayGame(game))
                {
                    sum += game.Id;
                }
            }

            sum = 0;

            foreach (var game in model.Games)
            {
                var maxSet = GetMaximumSet(game);
                var pow = maxSet.NumRed * maxSet.NumGreen * maxSet.NumBlue;
                sum += pow;
            }



            return sum.ToString();
        }
    }
}
