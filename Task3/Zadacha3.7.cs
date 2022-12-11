// Задача 3. Задайте двумерный массив из целых чисел. 
// Найдите среднее арифметическое элементов в каждом столбце.

// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// Среднее арифметическое каждого столбца: 4,6; 5,6; 3,6; 3.


int EnterSmth(string request)
{
    System.Console.Write($" {request} >> ");
    int response = Convert.ToInt32(Console.ReadLine());
    return (response);
}

int[,] RandMatrix(int ColumnsNum, int RowsNum, int Rmin, int Rmax)
{
    int[,] RandMatrix = new int[RowsNum, ColumnsNum];
    string Result = ("");
    System.Console.WriteLine();
    System.Console.WriteLine("Случайная матрица: ");

    for (int i = 0; i < RowsNum; i++)
    {
        Result = ("");
        for (int j = 0; j < ColumnsNum; j++)
        {
            Random rnd = new Random();

            RandMatrix[i, j] = rnd.Next(Rmin, Rmax);
            Result = Result + RandMatrix[i, j] + "   ";
        }

        System.Console.WriteLine(Result);
    }
    return (RandMatrix);
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

double[] ClmAverage(int[,] Array)
{
    double[] AllClmAverages = new double[Array.GetLength(1)];
    int ClmSum = 0;

    for (int i = 0; i < Array.GetLength(1); i++)
    {
        ClmSum = Array[0, i];
        for (int j = 1; j < Array.GetLength(0); j++)
        {
            ClmSum = ClmSum + Array[j, i];
        }
        double ClmAverage = (double)ClmSum / Array.GetLength(0);
        AllClmAverages[i] = ClmAverage;
    }

    return (AllClmAverages);
}

void ArrayOutput(double[] Array)
{
    string Result = ("");

    for (int i = 0; i < Array.Length; i++)
    {
        Result = Result + Math.Round(Array[i], 2, MidpointRounding.ToEven) + "; ";
    }
    Result = Result.TrimEnd(';', ' ') + ".";
    System.Console.WriteLine("");
    System.Console.WriteLine("Средние арифметические значения по столбцам: ");
    System.Console.WriteLine(Result);
}



System.Console.WriteLine("Генерируем случайную матрицу. Поехали!");

int[] Borders = EnterBorders();
int[,] Array = RandMatrix(EnterSize("Введите число столбцов"), EnterSize("Введите число строк"), Borders[0], Borders[1]);

ArrayOutput(ClmAverage(Array));
