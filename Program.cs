/*
Write a program in C# Sharp for addition of two Matrices of same size.

Test Data :
    Input the size of the square matrix (less than 5): 2
    Input elements in the first matrix :
        element - [0],[0] : 1
        element - [0],[1] : 2
        element - [1],[0] : 3
        element - [1],[1] : 4

    Input elements in the second matrix :
        element - [0],[0] : 5
        element - [0],[1] : 6
        element - [1],[0] : 7
        element - [1],[1] : 8

Expected Output:
    The First matrix is:
        1 2
        3 4

    The Second matrix is :
        5 6
        7 8

    The Addition of two matrix is :
        6 8
        10 12
*/

using System.Text;

namespace Assignment_3._2._2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int maxMatrixSize = 5;
            int matrixSize = 0;

            // Get square matrix size
            Console.Write("Input the size of the square matrix (less than 5): ");
            matrixSize = GetUserInput(maxMatrixSize);

            // Initialize matrices
            Console.WriteLine("\nInput elements in the first matrix:");
            int[,] firstMatrix = PopulateMatrix(matrixSize);

            Console.WriteLine("\nInput elements in the second matrix:");
            int[,] secondMatrix = PopulateMatrix(matrixSize);

            int[,] sumMatrix = AddMatrices(firstMatrix, secondMatrix, matrixSize);


            Console.WriteLine("\nThe first matrix is:");
            PrintMatrix(firstMatrix);

            Console.WriteLine("\nThe second matrix is:");
            PrintMatrix(secondMatrix);

            Console.WriteLine("\nThe addition of the two matrices is:");
            PrintMatrix(sumMatrix);

        }

        static int GetUserInput()
        {
            int userInput = 0;
            while (true)
            {
                if (int.TryParse(Console.ReadLine().Trim(), out userInput))
                    return userInput;
                else
                    Console.Write("Enter a valid integer: ");
            }
        }

        static int GetUserInput(int maxSize)
        {
            int userInput = 0;
            while (true)
            {
                if (int.TryParse(Console.ReadLine().Trim(), out userInput))
                {
                    if (userInput < maxSize)
                        return userInput;
                    else
                        Console.Write($"Size of square matrix must be less than {maxSize}: ");
                }
                else
                    Console.Write($"Enter a valid integer less than {maxSize}: ");
            }
        }

        static int[,] PopulateMatrix(int matrixSize)
        {
            int[,] matrix = new int[matrixSize, matrixSize];

            //Input elements in the first matrix:
            //  element - [0],[0] : 1
            //  element - [0],[1] : 2
            //  element - [1],[0] : 3
            //  element - [1],[1] : 4

            for (int r = 0; r < matrixSize; r++)
            {
                for (int c = 0; c < matrixSize; c++)
                {
                    Console.Write($"\t Element [{r}],[{c}]: ");
                    matrix[r,c] = GetUserInput();
                }
            }
            return matrix;
        }

        static int[,] AddMatrices(int[,] firstMatrix, int[,] secondMatrix, int matrixSize)
        {
            int[,] sumMatrix = new int[matrixSize, matrixSize];

            for (int r = 0; r < matrixSize; r++)
            {
                for (int c = 0; c < matrixSize; c++)
                {
                    sumMatrix[r, c] = firstMatrix[r, c] + secondMatrix[r, c];
                }
            }

            return sumMatrix;
        }

        static void PrintMatrix(int[,] array)
        {
            StringBuilder sb = new();

            // Find the largest number in the array
            // Cast to IEnumerable<int> and then use Max() (( from Google ))
            int max = array.Cast<int>().Max();

            // Using Foreach
            //int max = 0;
            //foreach (int i in array)
            //{
            //    if (i > max)
            //        max = i;
            //}

            // Get length of largest number
            int maxLength = max.ToString().Length;


            //print rows
            for (int r = 0; r < array.GetLength(0); r++)
            {
                sb.Clear(); // reset string for new row
                sb.Append("|");

                // print columns for each row
                for (int c = 0; c < array.GetLength(1); c++)
                {
                    //Console.Write(c + " ");
                    sb.Append($" {array[r, c].ToString().PadLeft(maxLength)} |");
                }

                Console.WriteLine(sb);
            }
        }
    }
}
