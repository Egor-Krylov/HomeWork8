// Задача 56: Задайте прямоугольный двумерный массив. Напишите программу, которая будет находить строку с наименьшей суммой элементов.

// Например, задан массив:

// 1 4 7 2

// 5 9 2 3

// 8 4 2 4

// 5 2 6 7

// Программа считает сумму элементов в каждой строке и выдаёт номер строки с наименьшей суммой элементов: 1 строка

int[,] GetArray(int m, int n)
{
    int[,] matrix = new int[m, n];
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            matrix[i, j] = new Random().Next(101);
        }
    }
    return matrix;
}

void PrintArray(int[,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            Console.Write(matrix[i, j] + "\t");
        }
        Console.WriteLine();
    }
}

int GetRowSum(int rowIndex, int[,] array)
{
    int sum = 0;
    for (int i = 0; i < array.GetLength(1); i++)
    {
        sum += array[rowIndex, i];
    }
    return sum;
}


Console.WriteLine("Введите количество строк");
int rows = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Введите количество столбцов");
int columns = Convert.ToInt32(Console.ReadLine());
int[,] resultArray = GetArray(rows, columns);
PrintArray(resultArray);

int minimumSumIndex = 0;
int minimumSum = GetRowSum(minimumSumIndex, resultArray);

for (int i = 1; i < resultArray.GetLength(0); i++)
{
    int currentSum = GetRowSum(i, resultArray);
    if (minimumSum > currentSum)
    {
        minimumSumIndex = i;
        minimumSum = currentSum;
    }
}


Console.WriteLine($"Строка с минимальной суммой элементов: {minimumSumIndex}.");
