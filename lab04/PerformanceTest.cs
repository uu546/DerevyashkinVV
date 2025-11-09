using System.Diagnostics;

/// <summary>
/// Класс для проведения тестов производительности.
/// </summary>
public static class PerformanceTest
{
    /// <summary>
    /// Словарь ссылок на алгоритмы сортировки.
    /// </summary>
    public static Dictionary<string, Action<int[]>> sortDict = new()
    {
        { "Bubble Sort", Sorts.BubbleSort },
        {"Selection Sort", Sorts.SelectionSort },
        {"Insertion Sort", Sorts.InsertionSort },
        {"Merge Sort", Sorts.MergeSort },
        {"Quick Sort", Sorts.QuickSort }
    };

    /// <summary>
    /// Метод запускает тесты производительности.
    /// </summary>
    /// <returns></returns>
    public static List<TestPerformanceResult> RunTests()
    {
        int[] sizes = [100, 1000, 5000, 10_000];
        string[] dataTypes = { "random", "sorted", "reversed", "almostSorted" };

        List<TestPerformanceResult> performanceResults = new();

        foreach (var size in sizes)
        {
            Console.WriteLine($"Тестирование размера: {size}");

            foreach (var type in dataTypes)
            {
                int[] arr = GetGenerateData(type, size);

                Console.WriteLine($"Тип данных: {type}");

                foreach (var algo in sortDict)
                {
                    double time = MeasureTime(algo.Value, arr);

                    //Console.WriteLine($"Алгоритм: {algo.Key} на данных: {type}: время: {time:F4}ms");

                    Console.WriteLine($"  {algo.Key}: {time:F4} мс");

                    performanceResults.Add(new TestPerformanceResult
                    {
                        Algorithm = algo.Key,
                        DataType = type,
                        Size = size,
                        TimeMs = time
                    });
                }
            }
        }

        return performanceResults;
    }

    /// <summary>
    /// Метод измеряет время выполнения алгоритма сортировки.
    /// </summary>
    /// <param name="algorithm">Делегат, ссылка на метод.</param>
    /// <param name="data">Массив.</param>
    /// <param name="iterations">Кол-во итераций.</param>
    /// <returns>Среднее время выполнения.</returns>
    /// <exception cref="InvalidOperationException"></exception>
    private static double MeasureTime(Action<int[]> algorithm, int[] data, int iterations = 10)
    {
        double totalTime = 0;

        Stopwatch sw = new Stopwatch();

        for (int i = 0; i < iterations; i++)
        {
            int[] arrCopy = (int[])data.Clone();

            sw.Start();
            algorithm(arrCopy);
            sw.Stop();

            if (!IsSorted(arrCopy))
            {
                throw new InvalidOperationException("Массив не отсортирован корректно.");
            }

            totalTime += sw.Elapsed.TotalMilliseconds;
        }

        double result = totalTime / iterations;

        return result;
    }

    /// <summary>
    /// Метод проверяет отсортирован ли массив.
    /// </summary>
    /// <param name="array">Массив.</param>
    /// <returns>Признак сортирвки.</returns>
    private static bool IsSorted(int[] array)
    {
        for (int i = 0; i < array.Length - 1; i++)
        {
            if (array[i] > array[i + 1])
            {
                return false;
            }
        }

        return true;
    }

}

