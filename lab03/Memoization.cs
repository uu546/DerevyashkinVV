using System.Diagnostics;

/// <summary>
/// Класс реализует оптимизированные методы с использованием ресурсии и мемоизации.
/// </summary>
public static class Memoization
{
    /// <summary>
    /// Метод с использованием мемоизации вычиялет числа Фабиначчи.
    /// </summary>
    /// <param name="n">Число.</param>
    /// <param name="memo">Словарь для хранения чисел.</param>
    /// <returns>Число фибоначчи.</returns>
    public static long FibonacciMemo(int n, Dictionary<int, long>? memo = null)
    {
        memo ??= new Dictionary<int, long>();

        if (memo.ContainsKey(n))
        {
            return memo[n];
        }

        if (n <= 1)
        {
            return n;
        }

        long result = FibonacciMemo(n - 1, memo) + FibonacciMemo(n - 2, memo);
        memo[n] = result;

        return result;

        // Сложность: O(n)
        // Глубина рекурсии: O(n)
    }

    /// <summary>
    /// Метод сравнивает наивную и мемоизированную версии вычисления чисел Фибоначчи.
    /// </summary>
    /// <param name="n">Число.</param>
    public static void CompareFibonacci(int n = 35)
    {
        Stopwatch sw = Stopwatch.StartNew();
        long resultNaive = Recursion.FibonacciNaive(n);
        sw.Stop();

        double timeNaive = sw.Elapsed.TotalMilliseconds;

        sw.Restart();
        long resultMemo = FibonacciMemo(n);
        sw.Stop();

        double timeMemo = sw.Elapsed.TotalMilliseconds;

        Console.WriteLine($"n = {n}");
        Console.WriteLine($"Наивная версия: результат вычисления {resultNaive} за {timeNaive:F2} мс");
        Console.WriteLine($"Мемоизация: результат вычисления {resultMemo} за {timeMemo:F2} мс");
        Console.WriteLine($"Ускорение: {timeNaive / timeMemo:F0}x");
    }
}