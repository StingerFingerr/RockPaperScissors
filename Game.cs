using System;
using System.Collections.Generic;

namespace RockPaperScissors
{
    class Game
    {
        private GameUI _gameUI = new GameUI();
        private Random _random = new Random();

        private List<string> _moves;

        private int _computerChoice;
        private string _cryptoKey;

        public bool InitGame(string[] args, out string answer)
        {
            if(args.Length is 0)
            {
                answer = "--------- Can't start game without parameters ---------";
                return false;
            }
            if (args.Length < 3)
            {
                answer = "--------- Too few parameters to start the game ---------";
                return false;
            }
            if(args.Length % 2 is 0)
            {
                answer = "--------- The game requires an odd number of parameters ---------";
                return false;
            }

            _moves = new List<string>(args);

            if (_moves.ContainSameElements())
            {
                answer = "--------- The game cannot have the same parameters ---------";
                return false;
            }

            answer = string.Empty;
            return true;
        }

        public bool PlayRound()
        {
            _cryptoKey = KeyGenerator.GenerateKey();
            _computerChoice = _random.Next(_moves.Count);

            Console.WriteLine();
            Console.WriteLine("The computer made a move");
            Console.WriteLine($"His HMAC-256: {HMAC.ComputeHMAC256(_moves[_computerChoice], _cryptoKey)}");


            int playerChoice = PlayerMove();

            if (playerChoice is 0)
                return false;
            else
            {
                GameOver(_computerChoice, playerChoice - 1);
                _gameUI.PressAnyKeyToContinue();              
                return true;
            }
        }

        private int PlayerMove()
        {
            _gameUI.ShowMoves(_moves);
            int choice;
            do
            {
                Console.WriteLine("Yor choice: ");
                choice = ReadPlayerChoice();
            } while (choice < 0 || choice > _moves.Count);
            return choice;
        }

        private int ReadPlayerChoice()
        {
            string answer = Console.ReadLine();
            int choice;

            if (answer.Equals("?"))
            {
                _gameUI.ShowHelpTable(_moves);
                return -1;
            }

            if (int.TryParse(answer, out choice))
                return choice;

            return -1;
        }

        private void GameOver(int firstMove, int secondMove)
        {
            string winner = PickWinner(firstMove, secondMove, _moves);

            _gameUI.ShowWinnerPanel(firstMove == _moves.IndexOf(winner), _moves[_computerChoice], _cryptoKey);

        }

        public static string PickWinner(int firstMove, int secondMove, List<string> moves)
        {
            if (firstMove == secondMove)
                return "Draw";
            

            bool firstMoveIsWinner;

            int halfLenth = moves.Count / 2;

            int after = moves.Count - 1 - firstMove >= halfLenth ?
               halfLenth :
               moves.Count - 1 - firstMove;

            int befor = halfLenth - after;

            if (secondMove >= 0 && secondMove < befor ||
                secondMove > firstMove && secondMove <= firstMove + after)
                firstMoveIsWinner = true;
            else firstMoveIsWinner = false;

            return firstMoveIsWinner ? moves[firstMove] : moves[secondMove];
        }
    }
}
