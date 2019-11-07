using System;

namespace PirateShips
{
    class Startup
    {
        static void Main(string[] args)
        {
            string[,] array = GenerateArray();
            while (true)
            {
                PrintArray(array);
                if (PositionChecker(array) == false)
                {
                    break;
                }

                MovePlayerShip(array);
                MoveEnemyShips(array);
            }
        }

        public static string[,] GenerateArray()
        {
            Console.WriteLine("Please enter number of array rows: ");
            int inputRow = int.Parse(Console.ReadLine());

            Console.WriteLine("Please enter number of array columns: ");
            int inputColumn = int.Parse(Console.ReadLine());

            string[,] array = new string[inputRow, inputColumn];

            for (int i = 0; i < inputRow; i++)
            {
                for (int j = 0; j < inputColumn; j++)
                {
                    array[i, j] = Console.ReadLine();
                }
            }
            return array;
        }

        public static void PrintArray(string[,] array)
        {
            int row = array.GetLength(0);
            int column = array.GetLength(1);

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    Console.Write($"{array[i, j]} ");
                }
                Console.Write(Environment.NewLine + Environment.NewLine);
            }
            Console.ReadLine();
        }

        public static bool PositionChecker(string[,] array)
        {
            int row = array.GetLength(0);
            int column = array.GetLength(1);
            string playerShip = "X";
            string enemyShip = "N";

            for (int i = 0; i < row - 1; i++)
            {
                for (int j = 0; j < column - 1; j++)
                {
                    if (array[i, j] == enemyShip)
                    {
                        if (i != 0 && j != 0)
                        {
                            if (array[i - 1, j] == playerShip || array[i + 1, j] == playerShip
                            || array[i, j - 1] == playerShip || array[i, j + 1] == playerShip
                            || array[i - 1, j - 1] == playerShip || array[i - 1, j + 1] == playerShip
                            || array[i + 1, j - 1] == playerShip || array[i + 1, j + 1] == playerShip)
                            {
                                Console.WriteLine("false");
                                return false;
                            }
                        }
                        else
                        {
                            continue;
                        }
                    }
                    if (array[i, j] == playerShip && i == column)
                    {
                        Console.WriteLine("true");
                        return true;
                    }
                }
            }
            return true;
        }

        public static string[,] MoveEnemyShips(string[,] array)
        {
            int row = array.GetLength(0);
            int column = array.GetLength(1);
            string enemyShip = "N";
            string emptyWater = "0";
            string playerShip = "X";
            int currentPlayerShipLocation = 0;
            int currentEnemyShipIndex = 0;

            for (int k = 0; k < row; k++)
            {
                for (int n = 0; n < column; n++)
                {
                    if (array[k, n] == "X")
                    {
                        currentPlayerShipLocation = n;
                    }
                }
            }

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    if (array[i, j] == enemyShip)
                    {
                        if (i == 0)
                        {
                            array[i + 1, j] = enemyShip;
                            array[i, j] = emptyWater;
                            currentEnemyShipIndex = i + 1;
                        }
                       
                        else if (i == row - 1)
                        {
                            array[i - 1, j] = enemyShip;
                            array[i, j] = emptyWater;
                        }

                        if (i < row - 1 && i != 0 && array[i + 1, j] != playerShip && array[i - 1, j] != playerShip)
                        {
                            if (i != currentPlayerShipLocation && i != currentEnemyShipIndex
                                && i < row - 1 && i > 0 && i < column - 1 + i && i < currentPlayerShipLocation)
                            {
                                if (true)
                                {
                                    array[i + 1, j] = enemyShip;
                                    array[i, j] = emptyWater;
                                }
                            }
                            else if (i != currentPlayerShipLocation && i != currentEnemyShipIndex
                                && i < row - 1 && i > 0 && i < column - 1 - i )
                            {
                                if (true)
                                {
                                    array[i - 1, j] = enemyShip;
                                    array[i, j] = emptyWater;
                                }
                            }
                        }
                    }
                }
            }
            return array;
        }

        public static string[,] MovePlayerShip(string[,] array)
        {
            int row = array.GetLength(0);
            int column = array.GetLength(1);
            string playerShip = "X";
            string emptyWater = "0";

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column - 1; j++)
                {
                    if (array[i, j] == playerShip)
                    {
                        array[i, j + 1] = playerShip;
                        array[i, j] = emptyWater;
                        break;
                    }
                }
            }
            return array;
        }
    }
}