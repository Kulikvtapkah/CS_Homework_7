// Задача 2. Напишите программу, которая на вход принимает позиции элемента 
// в двумерном массиве, и возвращает значение этого элемента или же указание, 
// что такого элемента нет.
// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4

// Ряд > 1
// Колонка > 7
// 1, 7 -> такого числа в массиве нет
// 1, 2 -> 4


int EnterSmth(string request)
{
    System.Console.Write($" {request} >> ");
    int response = Convert.ToInt32(Console.ReadLine());
    return (response);
}

int[] EnterBorders()
{
    int[] borders = { 0, 0 };
    int min = 0;
    int max = 0;
    bool rightInput = false;
    while (rightInput == false)
    {
        System.Console.WriteLine(" Введите границы диапазона: ");
        min = EnterSmth("нижняя ");
        max = EnterSmth("верхняя ");

        if (max >= min)
        {
            borders[0] = min;
            borders[1] = max;
            rightInput = true;
        }
        else { System.Console.WriteLine("Все с ног на голову! Попробуйте еще раз."); }
    }
    return (borders);
}

int[,] RandMatrix(int Rmin, int Rmax)
{
    Random rnd = new Random();

    int ColumnsNum = rnd.Next(1, 15);
    int RowsNum = rnd.Next(1, 15);
    //решила рандомить размеры матрицы. 
    //Иначе промахиваться мимо границ, которые сам ввел как-то странно

    int[,] RandMatrix = new int[RowsNum, ColumnsNum];
    string Result = ("");
    System.Console.WriteLine();
    System.Console.WriteLine($"Случайная матрица: ");

    for (int i = 0; i < RowsNum; i++)
    {
        Result = ("");
        for (int j = 0; j < ColumnsNum; j++)
        {
            Random Rnd = new Random();

            RandMatrix[i, j] = Rnd.Next(Rmin, Rmax);
            Result = Result + RandMatrix[i, j] + "   ";
        }

        System.Console.WriteLine(Result);
    }
    return (RandMatrix);
}

int[,] GeneratedMatrix()
{
    System.Console.WriteLine("Генерируем случайную матрицу. Поехали!");

    int[] Borders = EnterBorders();
    int[,] Array = RandMatrix(Borders[0], Borders[1]);
    return (Array);
}

void GetDataByPosition(int[,] SomeMatrix, int[] Position)
{
    if (Position[0] <= 0 || Position[0] > SomeMatrix.GetLength(0) || Position[1] <= 0 || Position[1] > SomeMatrix.GetLength(1))
        System.Console.WriteLine($"Элемента с позицией [{Position[0]} , {Position[1]}] в массиве нет(");

    else
        System.Console.WriteLine($"Элемент с позицией [{Position[0]} , {Position[1]}] => {SomeMatrix[Position[0]-1, Position[1]-1]} ");
}

int[,] SomeMatrix = GeneratedMatrix();
System.Console.WriteLine("Укажите позицию элемента, который нужно найти: ");

int[] Position = { EnterSmth("ряд"), EnterSmth("столбец") };

GetDataByPosition(SomeMatrix, Position);
