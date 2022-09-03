// Задача 54: Задайте двумерный массив. Напишите программу, которая упорядочит по убыванию элементы каждой строки двумерного массива.
// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// В итоге получается вот такой массив:
// 7 4 2 1
// 9 5 3 2
// 8 4 4 2

void SortRow(int rowIndex, int[,] array)
{
    for (int i = 0; i < array.GetLength(1); i++)
    {
        for (int j = 0; j < array.GetLength(1) - i - 1; j++)
        {
            if (array[rowIndex, j] > array[rowIndex, j + 1])
            {
                int temp = array[rowIndex, j];
                array[rowIndex, j] = array[rowIndex, j + 1];
                array[rowIndex, j + 1] = temp;
            }
        }
    }
}

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
Console.WriteLine("Введите количество строк");
int rows = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Введите количество столбцов");
int columns = Convert.ToInt32(Console.ReadLine());
int[,] resultArray = GetArray(rows, columns);
PrintArray(resultArray);

for (int i = 0; i < resultArray.GetLength(0); i++)
{
    SortRow(i, resultArray);
}

Console.WriteLine("Результат: ");
PrintArray(resultArray);


