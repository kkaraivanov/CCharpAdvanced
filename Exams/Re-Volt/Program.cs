namespace Re_Volt
{
    using System;
    using System.Text;

    class Program
    {
        private static char[,] matrix;
        private static int[] playerPosition = new int[2];
        private static bool complete = false;

        static char[,] NewMatrix(int size)
        {
            var tempMatrix = new char[size, size];
            for (int row = 0; row < size; row++)
            {
                string currentRow = ReadLine();
                for (int col = 0; col < size; col++)
                {
                    tempMatrix[row, col] = currentRow[col];
                }
            }

            return tempMatrix;
        }

        private static Func<int[], bool> CanMove = currentPosition =>
            currentPosition[0] >= 0 && matrix.GetLength(0) > currentPosition[0] &&
            currentPosition[1] >= 0 && matrix.GetLength(1) > currentPosition[1];

        static string ReadLine() => Console.ReadLine();

        static void Main()
        {
            int n = int.Parse(ReadLine());
            int countOfComands = int.Parse(ReadLine());
            matrix = NewMatrix(n);
            SetFirstPlayerPosition();

            for (int i = 0; i < countOfComands; i++)
            {
                string currentCommand = ReadLine();
                MoveDirection(currentCommand);

                if (complete)
                    break;
            }

            DisplayMatrix();
        }

        static void DisplayMatrix()
        {
            var sb = new StringBuilder();
            if (complete)
                sb.AppendLine("Player won!");
            else
                sb.AppendLine("Player lost!");

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    sb.Append(matrix[i, j]);
                }

                sb.AppendLine();
            }

            Console.WriteLine(sb);
        }

        static void MoveDirection(params string[] direction)
        {
            string param = direction[0];
            int currentRow = playerPosition[0];
            int currentCol = playerPosition[1];
            LeavPosition();

            if (param == "left")
            {
                var newPosition = new int[] { currentRow, currentCol - 1 };
                if (CanMove(newPosition))
                {
                    currentCol--;
                }
                else
                {
                    currentCol = matrix.GetLength(1) - 1;
                }

                playerPosition[1] = currentCol;
            }
            else if (param == "right")
            {
                var newPosition = new int[] { currentRow, currentCol + 1 };
                if (CanMove(newPosition))
                {
                    currentCol++;
                }
                else
                {
                    currentCol = 0;
                }

                playerPosition[1] = currentCol;
            }
            else if (param == "up")
            {
                var newPosition = new int[] { currentRow - 1, currentCol };
                if (CanMove(newPosition))
                {
                    currentRow--;
                }
                else
                {
                    currentRow = matrix.GetLength(0) - 1;
                }

                playerPosition[0] = currentRow;
            }
            else if (param == "down")
            {
                var newPosition = new int[] { currentRow + 1, currentCol };
                if (CanMove(newPosition))
                {
                    currentRow++;
                }
                else
                {
                    currentRow = 0;
                }

                playerPosition[0] = currentRow;
            }

            Move(currentRow, currentCol, direction);
            PlayerNewPosition();
        }

        static void Move(int currentRow, int currentCol, string[] direction)
        {
            string param = direction[0];
            if (matrix[currentRow, currentCol] == 'B')
            {
                switch (param)
                {
                    case "left":
                        MoveDirection("left");
                        break;
                    case "right":
                        MoveDirection("right");
                        break;
                    case "down":
                        MoveDirection(param);
                        break;
                    case "up":
                        MoveDirection(param);
                        break;
                }

                matrix[currentRow, currentCol] = 'B';
            }
            else if (matrix[currentRow, currentCol] == 'T')
            {
                switch (param)
                {
                    case "left":
                        MoveDirection("right");
                        break;
                    case "right":
                        MoveDirection("left");
                        break;
                    case "down":
                        MoveDirection("up");
                        break;
                    case "up":
                        MoveDirection("down");
                        break;
                }

                matrix[currentRow, currentCol] = 'T';
            }
            else if (matrix[currentRow, currentCol] == 'F')
                complete = true;
        }

        static void LeavPosition()
        {
            matrix[playerPosition[0], playerPosition[1]] = '-';
        }

        static void PlayerNewPosition()
        {
            matrix[playerPosition[0], playerPosition[1]] = 'f';
        }

        static void SetFirstPlayerPosition()
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == 'f')
                    {
                        playerPosition[0] = i;
                        playerPosition[1] = j;
                    }
                }
            }
        }
    }
}
