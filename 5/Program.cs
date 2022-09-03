// Задача 62. Напишите программу, которая заполнит спирально массив 4 на 4.
// Например, на выходе получается вот такой массив:
// 01 02 03 04
// 12 13 14 05
// 11 16 15 06
// 10 09 08 07

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

int[] GetNextMoveVector(int[] currentVector)
{
    int[] result = new int[2];
    if (currentVector[0] == 0 && currentVector[1] == 1)
    {
        result[0] = 1;
        result[1] = 0;
    }
    else if (currentVector[0] == 1 && currentVector[1] == 0)
    {
        result[0] = 0;
        result[1] = -1;
    }
    else if (currentVector[0] == 0 && currentVector[1] == -1)
    {
        result[0] = -1;
        result[1] = 0;
    }
    else if (currentVector[0] == -1 && currentVector[1] == 0)
    {
        result[0] = 0;
        result[1] = 1;
    }

    return result;
}

int[,] resultMatrix = new int[4, 4];
int[,] extentedMatrix = new int[6, 6];

for (int i = 0; i < extentedMatrix.GetLength(0); i++)
{
    extentedMatrix[i, 0] = 1;
    extentedMatrix[i, extentedMatrix.GetLength(1) - 1] = 1;
}

for (int i = 0; i < extentedMatrix.GetLength(1); i++)
{
    extentedMatrix[0, i] = 1;
    extentedMatrix[extentedMatrix.GetLength(0) - 1, i] = 1;
}
//PrintArray(temporalMatrix);
int[] nextStepVector = { 0, 1 };
int[] nextPositionCoordinate = { 1, 1 };
for (int i = 1; i < resultMatrix.GetLength(0) * resultMatrix.GetLength(1) + 1; i++)
{
    extentedMatrix[nextPositionCoordinate[0], nextPositionCoordinate[1]] = i;

    while (extentedMatrix[nextPositionCoordinate[0] + nextStepVector[0], nextPositionCoordinate[1] + nextStepVector[1]] > 0 && i != 16)
    {
        nextStepVector = GetNextMoveVector(nextStepVector);
        //Console.WriteLine(i);
    }
    nextPositionCoordinate[0] += nextStepVector[0];
    nextPositionCoordinate[1] += nextStepVector[1];
}

for (int i = 1; i < resultMatrix.GetLength(0) + 1; i++)
{
    for (int j = 1; j < resultMatrix.GetLength(1) + 1; j++)
    {
        resultMatrix[i - 1, j - 1] = extentedMatrix[i, j];
    }
}
PrintArray(resultMatrix);