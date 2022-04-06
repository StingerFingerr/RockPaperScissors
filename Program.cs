using System;

namespace RockPaperScissors
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();

            if(game.InitGame(args, out string answer))
            {
                while (game.PlayRound())
                {

                }
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine(answer);
            }            
        }
    }
}
