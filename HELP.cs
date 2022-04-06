using System;
using System.Collections.Generic;

namespace RockPaperScissors
{
    class HELP
    {
        public static void ShowHelpTable(List<string> moves)
        {
            Console.WriteLine("--------- Help table ---------");
            Console.WriteLine();

            int maxLenth = 4;
            foreach (string s in moves)
                if (s.Length > maxLenth)
                    maxLenth = s.Length;

            WriteNameInCell(string.Empty, maxLenth);
            foreach (string s in moves)
                WriteNameInCell(s, maxLenth);

            Console.WriteLine();
            for (int i = 0; i < (moves.Count + 2) * maxLenth; i++)
                Console.Write("-");
            Console.WriteLine();

            foreach (string s in moves)
            {
                WriteNameInCell(s, maxLenth);

                for (int i = 0; i < moves.Count; i++)
                {
                    string winner = WhoWillWon(moves.IndexOf(s), i, moves);
                    WriteNameInCell(winner, maxLenth);
                }

                Console.WriteLine();
                for (int i = 0; i < (moves.Count + 2) * maxLenth; i++)
                    Console.Write("-");
                Console.WriteLine();
            }

            Console.WriteLine();
        }

        private static void WriteNameInCell(string name, int maxCellLenth)
        {
            int count = maxCellLenth - name.Length;
            for (int i = 0; i < count; i++)
                Console.Write(" ");
            Console.Write(name);
            Console.Write("|");
        }
        private static string WhoWillWon(int m1, int m2, List<string> moves)
        {
            return Game.PickWinner(m1,m2,moves);
        }
    }
}
