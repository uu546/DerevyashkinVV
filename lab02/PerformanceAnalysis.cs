using System.Diagnostics;

/// <summary>
/// Класс замеряет время выполнения методов.
/// </summary>
public static class PerformanceAnalysis
{
    /// <summary>
    /// Метод замеряет время выполнения действий.
    /// </summary>
    /// <param name="action">Делегат.</param>
    /// <param name="iterations">Количество итераций.</param>
    /// <returns>Среднее время выполнения одной итерации.</returns>
    private static double Measure(Action action, int iterations = 1000)
    {
        double totalTime = 0;

        Stopwatch sw = new Stopwatch();

        for (int i = 0; i < iterations; i++)
        {
            sw.Restart();
            action();
            sw.Stop();

            totalTime += sw.Elapsed.TotalNanoseconds;
        }

        double result = totalTime / iterations;

        return result;
    }

    public static void Run()
    {
        double[] sizes = { 1000, 4000 };

        List<double> listInsertTimes = new(sizes.Length);
        List<double> linkedInsertTimes = new(sizes.Length);

        List<double> listRemoveTimes = new(sizes.Length);
        List<double> queueDequeueTimes = new(sizes.Length);

        foreach (int size in sizes)
        {
            // Вставка в начало: List vs LinkedList.
            double listInsertTime = Measure(() =>
            {
                List<int> listInsert = new();

                for (int i = 0; i < size; i++)
                {
                    listInsert.Insert(0, i); // O(N)
                }
            });

            double linkedInsertTime = Measure(() =>
            {
                LinkedList linkedList = new();

                for (int i = 0; i < size; i++)
                {
                    linkedList.InsertAtStart(i); // O(1)
                }
            });

            listInsertTimes.Add(listInsertTime);
            linkedInsertTimes.Add(linkedInsertTime);

            // Удаления из начала: List vs Queue.
            double listRemoveTime = Measure(() =>
            {
                List<int> listRemove = Enumerable.Range(0, size).ToList();

                for (int i = 0; i < size; i++)
                {
                    listRemove.RemoveAt(0); // O(N)
                }
            });

            double queueDequeueTime = Measure(() =>
            {
                Queue<int> queue = new Queue<int>(Enumerable.Range(0, size));

                for (int i = 0; i < size; i++)
                {
                    queue.Dequeue(); // O(1)
                }
            });

            listRemoveTimes.Add(listRemoveTime);
            queueDequeueTimes.Add(queueDequeueTime);
        }
    }
}

