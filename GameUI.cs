using System;
using System.Collections.Generic;

namespace RockPaperScissors
{
    class GameUI
    {
        public void ShowHelpTable(List<string> moves)
        {
            HELP.ShowHelpTable(moves);

            PressAnyKeyToContinue();
        }

        public void ShowMoves(List<string> moves)
        {
            Console.WriteLine("Your next step:");
            for (int i = 0; i < moves.Count; i++)
            {
                Console.WriteLine($"{i + 1}. - {moves[i]}");
            }
            Console.WriteLine($"0. - Exit");
            Console.WriteLine($"?. - Help");
        }

        public void ShowDrawPanel(string computerChoice, string key)
        {
            Console.WriteLine();
            Console.WriteLine("-------------------------");
            Console.WriteLine("Draw! you chose the same moves");
            Console.WriteLine($"Computer chose: {computerChoice}");
            Console.WriteLine($"The key was like this: {key}");
            Console.WriteLine("-------------------------");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
        }
        public void ShowWinnerPanel(bool computerWin, string computerChoice, string key)
        {
            Console.WriteLine();
            Console.WriteLine("-------------------------");
            Console.WriteLine(computerWin? "You lose(" : "You Won!");
            Console.WriteLine($"Computer chose: {computerChoice}");
            Console.WriteLine($"The key was like this: {key}");
            Console.WriteLine("-------------------------");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
        }

        public void PressAnyKeyToContinue()
        {
            Console.WriteLine("press any key to continue...");
            Console.ReadKey();
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
