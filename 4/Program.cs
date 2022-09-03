// Задача 60. ...Сформируйте трёхмерный массив из неповторяющихся двузначных чисел. Напишите программу, которая будет построчно выводить массив, добавляя индексы каждого элемента.
// Массив размером 2 x 2 x 2
// 66(0,0,0) 25(0,1,0)
// 34(1,0,0) 41(1,1,0)
// 27(0,0,1) 90(0,1,1)
// 26(1,0,1) 55(1,1,1)
bool RepeatCheck(int value, int[,,] array)
{

    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            for (int k = 0; k < array.GetLength(2); k++)
            {
                if (array[i, j, k] == value)
                    return true;
            }
        }
    }
    return false;
}

Console.WriteLine("Введите размерность 1");
int dimension1 = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Введите размерность 2");
int dimension2 = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Введите размерность 3");
int dimension3 = Convert.ToInt32(Console.ReadLine());
int[,,] resultArray = new int[dimension1, dimension2, dimension3];
for (int i = 0; i < resultArray.GetLength(0); i++)
{
    for (int j = 0; j < resultArray.GetLength(1); j++)
    {
        for (int k = 0; k < resultArray.GetLength(2); k++)
        {
            int value = new Random().Next(dimension1 * dimension2 * dimension3 * 10);
            while (RepeatCheck(value, resultArray))
                value = new Random().Next(dimension1 * dimension2 * dimension3 * 10);
            resultArray[i, j, k] = value; 
            Console.Write($"{value} ({i}, {j}, {k})\t");
        }
        Console.WriteLine();
    }
}