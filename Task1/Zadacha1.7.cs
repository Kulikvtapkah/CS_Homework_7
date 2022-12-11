// Задача 1. Задайте двумерный массив размером m×n, 
// заполненный случайными вещественными числами.

// m = 3, n = 4.
// 0,5 7 -2 -0,2
// 1 -3,3 8 -9,9
// 8 7,8 -7,1 9


int EnterSmth(string request)
{
    System.Console.Write($" {request} >> ");
    int response = Convert.ToInt32(Console.ReadLine());
    return (response);
}

int EnterSize(string request)
{
    int response = 0;
    bool rightInput = false;
    while (rightInput == false)
    {
        response = EnterSmth($"{request} ");

        if (response > 0)
        {
            rightInput = true;
        }
        else { System.Console.WriteLine("Нужен хотя бы один элемент! Попробуйте еще раз."); }
    }
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

double[,] RandMatrix(int ColumnsNum, int RowsNum, int Rmin, int Rmax)
{
    double[,] RandMatrix = new double[RowsNum, ColumnsNum];
    string Result = ("");
    System.Console.WriteLine();
    System.Console.WriteLine($"Случайная матрица {RowsNum}x{ColumnsNum}: ");

    for (int i = 0; i < RowsNum; i++)
    {
        Result = ("");
        for (int j = 0; j < ColumnsNum; j++)
        {
            Random rnd = new Random();

            RandMatrix[i, j] = Math.Round((rnd.NextDouble() * (Rmax - Rmin) + Rmin), 2, MidpointRounding.ToEven);
            Result = Result + RandMatrix[i, j] + "   ";
        }

        System.Console.WriteLine(Result);
    }
    return (RandMatrix);
}


System.Console.WriteLine("Генерируем случайную матрицу. Поехали!");

int[] Borders = EnterBorders();
double[,] Array = RandMatrix(EnterSize("Введите число столбцов"), EnterSize("Введите число строк"), Borders[0], Borders[1]);