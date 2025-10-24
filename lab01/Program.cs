using System.Diagnostics;

/// <summary>
/// Метод поиска элемента в массиве.
/// </summary>
/// <param name="arr">Массив.</param>
/// <param name="targetValue">Число для поиска.</param>
/// <returns>Индекс найденного элемента.</returns>
int LinearSearch(int[] arr, int targetValue)
{
    for (int i = 0; i < arr.Length; i++)
    {
        if (arr[i] == targetValue)
        {
            return i;
        }
    }

    return -1;

    // Общая сложность O(n).
}

/// <summary>
/// Метод бинарного поиска (только для отсортированных массивов).
/// </summary>
/// <param name="arr">Массив.</param>
/// <param name="targetValue">Число для поиска.</param>
/// <returns>Индекс найденного элемента.</returns>
int BinarySearch(int[] arr, int target)
{
    int left = 0;
    int right = arr.Length - 1;

    while (left <= right)
    {
        int mid = left + (right - left) / 2;

        if (arr[mid] == target)
        {
            return mid;
        }

        else if (arr[mid] < target)
        {
            left = mid + 1;
        }

        else
        {
            right = mid - 1;
        }
    }

    return -1;

    // Общая сложность O(log n)
}

/// <summary>   
/// Метод вычисляет среднее время выполнения алгоритма.
/// </summary>
/// <param name="func">Метод.</param>
/// <param name="arr">Массив.</param>
/// <param name="target">Число для поиска..</param>
/// <param name="iterations">Количество итераций.</param>
/// <returns>Среднее время выполнения алгоритма.</returns>
double MeasureTime(Func<int[], int, int> func, int[] arr, int target, int iterations = 100)
{
    double totalTime = 0;

    Stopwatch sw = Stopwatch.StartNew();

    for (int i = 0; i < iterations; i++)
    {
        sw.Restart();
        func(arr, target);
        sw.Stop();

        totalTime += sw.Elapsed.TotalNanoseconds;
    }

    return totalTime / iterations;
}

/// <summary>
/// Метод генерирует отсортированный массив.
/// </summary>
/// <param name="size">Количество элементов массива.</param>
/// <returns>Массив.</returns>
int[] GenerateSortedArray(int size)
{
    int[] result = new int[size];

    for (int i = 0; i < size; i++)
    {
        result[i] = i;
    }

    return result;
}

int[] arrSizes = new int[] { 1_000, 5_000, 10_000, 100_000, 500_000, 1_000_000, 10_000_000 };

double[] sizes = new double[arrSizes.Length];
double[] linearTimes = new double[arrSizes.Length];
double[] binaryTimes = new double[arrSizes.Length];

/// <summary>
/// Метод выполняет анализ алгоритмов.
/// </summary>
void ExecuteTest()
{    
    for (int i = 0; i < arrSizes.Length; i++)
    {
        int[] arr = GenerateSortedArray(arrSizes[i]);

        // Поиск последнего элемента, для полного выполнения алгоритма.
        int target = arr[arr.Length - 1];

        double linearTime = MeasureTime(LinearSearch, arr, target);
        double binaryTime = MeasureTime(BinarySearch, arr, target);

        sizes[i] = arrSizes[i];
        linearTimes[i] = linearTime;
        binaryTimes[i] = binaryTime;

        Console.WriteLine($"Array.Length: {arrSizes[i], 10} | Linear: {linearTime,12:F2} ns |" +
            $" Binary: {binaryTime,12:F2} ns");

    }
}

ExecuteTest();
