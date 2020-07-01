namespace Snake
{
    using System;

    class Program
    {

        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[,] matrix = new char[size,size];
            int snakeX = -1;
            int snakeY = -1;
            int food = 0;
            bool gameOver = false;

            for (int i = 0; i < size; i++)
            {
                var currentRow = Console.ReadLine();
                for (int j = 0; j < size; j++)
                {
                    matrix[i, j] = currentRow[j];
                    if (currentRow[j] == 'S')
                    {
                        snakeX = i;
                        snakeY = j;
                    }
                }
            }

            while (food < 10)
            {
                string action = Console.ReadLine();
                if (action == "left")
                {
                    LeavPosition(matrix, snakeX, snakeY);
                    int newPosition = snakeY - 1;
                    if (!CanMove(matrix, snakeX, newPosition))
                    {
                        gameOver = true;
                        break;
                    }

                    if (matrix[snakeX, newPosition] == 'B')
                    {
                        var getPosition = GetBurrowOut(matrix, snakeX, newPosition);
                        LeavPosition(matrix, snakeX, newPosition);
                        snakeX = getPosition[0];
                        snakeY = getPosition[1];
                        matrix[snakeX, snakeY] = 'S';
                    }
                    else if (matrix[snakeX, newPosition] == '*')
                    {
                        food++;
                        matrix[snakeX, newPosition] = 'S';
                        snakeY = newPosition;
                    }
                    else
                    {
                        matrix[snakeX, newPosition] = 'S';
                        snakeY = newPosition;
                    }
                }
                else if (action == "right")
                {
                    LeavPosition(matrix, snakeX, snakeY);
                    int newPosition = snakeY + 1;
                    if (!CanMove(matrix, snakeX, newPosition))
                    {
                        gameOver = true;
                        break;
                    }

                    if (matrix[snakeX, newPosition] == 'B')
                    {
                        var getPosition = GetBurrowOut(matrix, snakeX, newPosition);
                        LeavPosition(matrix, snakeX, newPosition);
                        snakeX = getPosition[0];
                        snakeY = getPosition[1];
                        matrix[snakeX, snakeY] = 'S';
                    }
                    else if (matrix[snakeX, newPosition] == '*')
                    {
                        food++;
                        matrix[snakeX, newPosition] = 'S';
                        snakeY = newPosition;
                    }
                    else
                    {
                        matrix[snakeX, newPosition] = 'S';
                        snakeY = newPosition;
                    }
                }
                else if (action == "down")
                {
                    LeavPosition(matrix, snakeX, snakeY);
                    int newPosition = snakeX + 1;
                    if (!CanMove(matrix, newPosition, snakeY))
                    {
                        gameOver = true;
                        break;
                    }

                    if (matrix[newPosition, snakeY] == 'B')
                    {
                        var getPosition = GetBurrowOut(matrix, newPosition, snakeY);
                        LeavPosition(matrix, newPosition, snakeY);
                        snakeX = getPosition[0];
                        snakeY = getPosition[1];
                        matrix[snakeX, snakeY] = 'S';
                    }
                    else if (matrix[newPosition, snakeY] == '*')
                    {
                        food++;
                        matrix[newPosition, snakeY] = 'S';
                        snakeX = newPosition;
                    }
                    else
                    {
                        matrix[newPosition, snakeY] = 'S';
                        snakeX = newPosition;
                    }
                }
                else if (action == "up")
                {
                    LeavPosition(matrix, snakeX, snakeY);
                    int newPosition = snakeY - 1;
                    if (!CanMove(matrix, snakeX, newPosition))
                    {
                        gameOver = true;
                        break;
                    }

                    if (matrix[newPosition, snakeY] == 'B')
                    {
                        var getPosition = GetBurrowOut(matrix, newPosition, snakeY);
                        LeavPosition(matrix, newPosition, snakeY);
                        snakeX = getPosition[0];
                        snakeY = getPosition[1];
                        matrix[snakeX, snakeY] = 'S';
                    }
                    else if (matrix[newPosition, snakeY] == '*')
                    {
                        food++;
                        matrix[newPosition, snakeY] = 'S';
                        snakeX = newPosition;
                    }
                    else
                    {
                        matrix[newPosition, snakeY] = 'S';
                        snakeX = newPosition;
                    }
                }
            }

            if (gameOver)
            {
                Console.WriteLine("Game over!");
            }

            if (food >= 10)
            {
                Console.WriteLine("You won! You fed the snake.");
            }

            Console.WriteLine($"Food eaten: {food}");
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i,j]);
                }

                Console.WriteLine();
            }
        }

        static int[] GetBurrowOut(char[,] arr, int x, int y)
        {
            int[] result = new int[2];
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                bool breakCheck = false;
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    if(i == x && j == y)
                        continue;
                    if (arr[i, j] == 'B')
                    {
                        result[0] = i;
                        result[1] = j;
                        breakCheck = true;
                    }
                }

                if (breakCheck)
                    break;
            }

            return result;
        }

        static void LeavPosition(char[,] arr, int x, int y)
        {
            arr[x, y] = '.';
        }

        static bool CanMove(char[,] arr, int x, int y) =>
            x >= 0 && arr.GetLength(0) > x &&
            y >= 0 && arr.GetLength(1) > y;
    }
}
