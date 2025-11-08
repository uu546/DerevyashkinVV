using System.Diagnostics;

/// <summary>
/// Класс для анализа производительности различных алгоритмов.
/// </summary>
public static class PerformanceAnalysis
{
    /// <summary>
    /// Метод измеряет время выполнения переданного метода..
    /// </summary>
    /// <param name="action">Делегат.</param>
    /// <param name="value">Число для вычислений.</param>
    /// <returns></returns>
    private static double MeasurePerformance(Action<int> action, int value)
    {
        Stopwatch sw = Stopwatch.StartNew();
        action(value);
        sw.Stop();

        double time = sw.Elapsed.TotalMilliseconds;

        return time;
    }

   /// <summary>
   /// Метод сравнивает производительность наивной и мемоизированной версий числа Фибоначчи.
   /// </summary>
    public static void FibonacciTest()
    {
        double[] sizes = [10, 15, 20, 25, 30, 35, 40];

        List<double> naiveTimes = new List<double>();
        List<double> memoTimes = new List<double>();

        foreach (int size in sizes)
        {
            double nativeTime = MeasurePerformance(x =>
            {
                Recursion.FibonacciNaive(x);
            }, size);

            double memoTime = MeasurePerformance(x =>
            {
                Memoization.FibonacciMemo(x);
            }, size);

            naiveTimes.Add(nativeTime);
            memoTimes.Add(memoTime);

            Console.WriteLine($"n={size}: naive={nativeTime:F3}ms, memo={memoTime:F3}ms");
        }
    }
}
