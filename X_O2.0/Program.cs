using System.Data;
using System.Data.Common;
using System.Net.Http.Headers;
using System.Numerics;
using System.Threading.Channels;

namespace X_O2._0
{


    internal class Program
    {


        
        static char[,] board = new char[3, 3];

        
        static char currentPlayer = 'X';

        static void Main(string[] args)
        {
            InitializeBoard();
            bool gameOver = false;

            while (!gameOver)
            {
                DisplayBoard();
                PlayerMove();
                gameOver = CheckForWin() || CheckForDraw();

                if (!gameOver)
                    SwitchPlayer();
            }

            DisplayBoard();
            Console.WriteLine("Игра окончена!");
        }

        
        static void InitializeBoard()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    board[i, j] = ' ';
                }
            }
        }

        
        static void DisplayBoard()
        {
            Console.WriteLine("  0 1 2");
            for (int i = 0; i < 3; i++)
            {
                Console.Write(i + " ");
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(board[i, j] + "|");
                }
                Console.WriteLine();
            }
        }

        
        static void PlayerMove()
        {
            bool validMove = false;

            while (!validMove)
            {
                Console.WriteLine($"Игрок {currentPlayer}, введите строку и столбец (например, 0 1):");
                string[] input = Console.ReadLine().Split(' ');
                int row = int.Parse(input[0]);
                int col = int.Parse(input[1]);

                if (row >= 0 && row < 3 && col >= 0 && col < 3 && board[row, col] == ' ')
                {
                    board[row, col] = currentPlayer;
                    validMove = true;
                }
                else
                {
                    Console.WriteLine("Некорректный ход. Попробуйте снова.");
                }
            }
        }

        
        static bool CheckForWin()
        {
            
            for (int i = 0; i < 3; i++)
            {
                if (board[i, 0] != ' ' && board[i, 0] == board[i, 1] && board[i, 1] == board[i, 2])
                {
                    Console.WriteLine($"Игрок {currentPlayer} выиграл!");
                    return true;
                }

                if (board[0, i] != ' ' && board[0, i] == board[1, i] && board[1, i] == board[2, i])
                {
                    Console.WriteLine($"Игрок {currentPlayer} выиграл!");
                    return true;
                }
            }

            // Проверка диагоналей
            if (board[0, 0] != ' ' && board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2])
            {
                Console.WriteLine($"Игрок {currentPlayer} выиграл!");
                return true;
            }

            if (board[0, 2] != ' ' && board[0, 2] == board[1, 1] && board[1, 1] == board[2, 0])
            {
                Console.WriteLine($"Игрок {currentPlayer} выиграл!");
                return true;
            }

            return false;
        }

        
        static bool CheckForDraw()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (board[i, j] == ' ')
                    {
                        return false;
                    }
                }
            }

            Console.WriteLine("Ничья!");
            return true;
        }

        // Как определять и выбирать какой игрок я не понял,можете объяснить(часть не вся,которая про выбор игрока и т д,чуть написана chat gpt)
        static void SwitchPlayer()
        {
            currentPlayer = (currentPlayer == 'X') ? 'O' : 'X';
        }
    }
}












