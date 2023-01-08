using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class Game
    {
        char[] boxStates = new char[] { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' };

        public Game() 
        {
            while (!GameOver())
            {
                Turn('x');
                if (GameOver())
                {
                    break;
                }
                Turn('o');
            }

            Console.Clear();

            DrawBox();
            Console.WriteLine("");
            Console.WriteLine("Game Over");

        }

        void DrawBox()
        {
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine(boxStates[i * 3] + "|" + boxStates[i * 3 + 1] + "|" + boxStates[i * 3 + 2]);
            }
        }

        bool GameOver()
        {
            for (int i = 0; i < 2; i++)
            {
                char target = ' ';
                if (i == 0) target = 'x';
                else target = 'o';

                //rows
                for (int r = 0; r < 3; r++)
                {
                    if (boxStates[r * 3] == target && boxStates[r * 3 + 1] == target && boxStates[r * 3 + 2] == target)
                    {
                        return true;
                    }
                }

                //columns
                for (int c = 0; c < 3; c++)
                {
                    if (boxStates[c] == target && boxStates[c + 3] == target && boxStates[c + 6] == target)
                    {
                        return true;
                    }
                }

                //diagnols

                if (boxStates[0] == target && boxStates[4] == target && boxStates[8] == target)
                {
                    return true;
                }

                if (boxStates[2] == target && boxStates[4] == target && boxStates[6] == target)
                {
                    return true;
                }
            }

            //full board, no win
            if (!Array.Exists(boxStates, box => box == ' ')) return true;

            return false;
        }

        void Turn(char player)
        {
            if (GameOver()) return;

            try
            {
                Console.Clear();

                int row = -1;
                int column = -1;

                DrawBox();

                Console.WriteLine("player " + player + "'s turn");
                Console.Write("Which row would you like to place in? (1-3) : ");
                row = Convert.ToInt32(Console.ReadLine());
                Console.Write("Which column would you like to place in? (1-3) : ");
                column = Convert.ToInt32(Console.ReadLine());

                if (ValidSpot(row, column))
                {
                    boxStates[FindPosition(row, column)] = player;
                }
                else
                {
                    Console.Clear();
                    Retry(player);
                }

                Console.Clear();
                DrawBox();
            }
            catch (Exception e)
            {
                Console.Clear();
                Console.WriteLine(e.Message);
                Retry(player);
            }

        }

        void Retry(char player)
        {
            Console.WriteLine("Not a valid position. Press enter to continue");

            Console.ReadLine();

            Turn(player);
        }

        bool ValidSpot(int row, int column)
        {
            if (row < 1 || column < 1) return false;
            if (row > 3 || column > 3) return false;

            else
            {
                if (boxStates[FindPosition(row, column)] == ' ')
                {
                    return true;
                }
                else return false;
            }
        }

        int FindPosition(int row, int column)
        {
            int position = (row - 1) * 3 + (column - 1);

            return position;
        }
    }
}
