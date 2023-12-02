using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent2023.Day02
{
    public class GameSet
    {
        public int NumRed { get; set; }
        public int NumGreen { get; set; }
        public int NumBlue { get; set; }
    }

    public class Game
    {
        public int Id { get; set; }
        public List<GameSet> GameSets { get; set; }
    }

    public class Model
    {

        public required List<Game> Games { get; set; }

        public static Model Parse(int part)
        {
            var retObj = new Model
            {
                Games = new List<Game>()
            };

            foreach (var lx in Data.InputData.Split("\n"))
            {
                var l = lx.Trim();

                if (string.IsNullOrEmpty(l))
                    continue;

                var game = new Game()
                {
                    GameSets = new List<GameSet>()
                };
                var arr1 = l.Split(":");
                game.Id = int.Parse(arr1[0].Replace("Game ", ""));

                var setArr = arr1[1].Split(";");
                foreach (var setSubArr in setArr)
                {
                    var gameSet = new GameSet();
                    var colArr = setSubArr.Split(",");

                    foreach (var colSubArr in colArr)
                    {
                        var numeric = colSubArr.Replace("red", "");
                        numeric = numeric.Replace("green", "");
                        numeric = numeric.Replace("blue", "");
                        numeric = numeric.Trim();

                        if (colSubArr.Contains("red")) gameSet.NumRed = int.Parse(numeric);
                        if (colSubArr.Contains("green")) gameSet.NumGreen = int.Parse(numeric);
                        if (colSubArr.Contains("blue")) gameSet.NumBlue = int.Parse(numeric);
                    }
                    game.GameSets.Add(gameSet);
                }

                retObj.Games.Add(game);
            }
            return retObj;

        }
    }
}
