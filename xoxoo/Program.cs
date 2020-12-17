using System;
using System.Threading;
namespace X0
{
    class Program
    {
        static int player = 1;
        static int choice;
        static char[] arr = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        static int flag = 0;
        static void Main(string[] args)
        {
            do
            {
                Console.Clear();
                Console.WriteLine("Player1:X and Player2:0");
                Console.WriteLine();

                if (player % 2 == 0)
                {
                    Console.WriteLine("Player2 time");
                }
                else
                {
                    Console.WriteLine("Player1 time");
                }

                Board();

                try
                {
                    choice = int.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid character, try again");
                    Console.ReadLine();
                    continue;
                    throw;
                }

                if (arr[choice] != 'X' && arr[choice] != '0')
                {
                    if (player % 2 == 0)
                    {
                        arr[choice] = '0';
                        player++;
                    }
                    else
                    {
                        arr[choice] = 'X';
                        player++;
                    }
                }
                else
                {
                    Console.WriteLine("Sorry the row {0} is already marked with {1}", choice, arr[choice]);
                    Console.WriteLine("Please wait 2 second, board is loading again...");
                    Thread.Sleep(2000);

                }
                flag = checkWin();
            } while (flag != 1 && flag != -1);

            Console.Clear();
            Board();

            if (flag == 1)
            {
                Console.WriteLine("Player {0} has won", (player % 2) + 1);
            }
            else
            {
                Console.WriteLine("Draw");
            }
            Console.ReadLine();

             static void Board()
            {
                Console.WriteLine("_________________");
                Console.WriteLine("     |     |     |  ");
                Console.WriteLine("  {0}  |  {1}  |  {2}", arr[1], arr[2], arr[3]);
                Console.WriteLine("_____|_____|_____|");
                Console.WriteLine("     |     |     | ");
                Console.WriteLine("  {0}  |  {1}  |  {2}", arr[4], arr[5], arr[6]);
                Console.WriteLine("_____|_____|_____|");
                Console.WriteLine("     |     |     |  ");
                Console.WriteLine("  {0}  |  {1}  |  {2}", arr[7], arr[8], arr[9]);
                Console.WriteLine("_____|_____|_____|  ");


            }
             static int checkWin()
            {
                #region Horisontal Winning Condition
                if (arr[1] == arr[2] && arr[2] == arr[3])
                {
                    return 1;
                }
                else if (arr[4] == arr[5] && arr[5] == arr[6])
                {
                    return 1;
                }
                else if (arr[6] == arr[7] && arr[7] == arr[8])
                {
                    return 1;
                }
                #endregion

                #region Vertical Winning Contidion

                else if (arr[1] == arr[4] && arr[4] == arr[7])
                {
                    return 1;
                }
                else if (arr[2] == arr[5] && arr[5] == arr[8])
                {
                    return 1;
                }
                else if (arr[3] == arr[6] && arr[6] == arr[9])
                {
                    return 1;
                }
                #endregion

                #region Diagonal Winning Condiotion

                else if (arr[1] == arr[5] && arr[5] == arr[9])
                {
                    return 1;
                }
                else if (arr[3] == arr[5] && arr[5] == arr[7])
                {
                    return 1;
                }
                #endregion

                #region Checking for draw
                else if (arr[1] != '1' && arr[2] != '2' && arr[3] != '3' && arr[4] != '4' && arr[5] != '5' && arr[6] != '6' && arr[7] != '7' && arr[8] != '8' && arr[9] != '9')
                {
                    return -1;
                }
                #endregion

                else
                {
                    return 0;
                }
            }
        }
    }
    }
