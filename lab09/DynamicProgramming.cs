/// <summary>
/// Класс реализует алгоритмы динамического программирования.
/// </summary>
public static class DynamicProgramming
{
    /// <summary>
    /// Наивная рекурсия для вычисления числа Фибоначчи.
    /// </summary>
    /// <param name="n">Индекс числа Фибоначчи.</param>
    /// <returns>Число Фибоначчи.</returns>    
    public static long FibonacciNaive(int n)
    {
        if (n <= 1)
        {
            return n;
        }

        long fibMinus1 = FibonacciNaive(n - 1);
        long fibMinus2 = FibonacciNaive(n - 2);

        return fibMinus1 + fibMinus2;

        // Временная сложность: O(2^n) - экспоненциальная из-за перекрывающихся(повторы) подзадач.
        // Пространственная сложность: O(n) - глубина рекурсии.
    }

    /// <summary>
    /// Рекурсия с мемоизацией (нисходящее ДП) для числа Фибоначчи.
    /// </summary>
    /// <param name="n">Индекс числа Фибоначчи.</param>
    /// <returns>Число Фибоначчи.</returns>
    public static long FibonacciMemo(int n)
    {
        long[] memo = new long[n + 1];

        Array.Fill(memo, -1);

        return FibonacciMemoHelper(n, memo);

        // Временная сложность: O(n) - каждая подзадача решается один раз.
        // Пространственная сложность: O(n) - выделение массива для мемоизации и рекурсия.
    }

    private static long FibonacciMemoHelper(int n, long[] memo)
    {
        if (n <= 1)
        {
            return n;
        }

        if (memo[n] != -1)
        {
            return memo[n];
        }

        long fibMinus1 = FibonacciMemoHelper(n - 1, memo);
        long fibMinus2 = FibonacciMemoHelper(n - 2, memo);

        // Один раз вычисляем число.
        memo[n] = fibMinus1 + fibMinus2;

        return memo[n];
    }

    /// <summary>
    /// Итеративное табличное решение (восходящее ДП) для числа Фибоначчи.
    /// </summary>
    /// <param name="n">Индекс числа Фибоначчи.</param>
    /// <returns>Число Фибоначчи.</returns>
    public static long FibonacciIterative(int n)
    {
        if (n <= 1)
        {
            return n;
        }

        long[] dp = new long[n + 1];

        dp[0] = 0;
        dp[1] = 1;

        for (int i = 2; i <= n; i++)
        {
            dp[i] = dp[i - 1] + dp[i - 2];
        }

        return dp[n];

        // Временная сложность: O(n) - линейный проход.
        // Пространственная сложность: O(n) - таблица.
    }

    /// <summary>
    /// Динамическое программирование для задачи 0-1 рюкзака (восходящее).
    /// </summary>
    /// <param name="weights">Веса предметов.</param>
    /// <param name="values">Ценности предметов.</param>
    /// <param name="capacity">Вместимость рюкзака.</param>
    /// <returns>Максимальная ценность и список выбранных индексов предметов.</returns>
    public static (int maxValue, List<int> selectedItems) Knapsack01(int[] weights, int[] values, int capacity)
    {
        int n = weights.Length;
        int[,] dp = new int[n + 1, capacity + 1];

        for (int i = 1; i <= n; i++)
        {
            for (int w = 0; w <= capacity; w++)
            {
                dp[i, w] = dp[i - 1, w];
                if (w >= weights[i - 1])
                {
                    dp[i, w] = Math.Max(dp[i, w], dp[i - 1, w - weights[i - 1]] + values[i - 1]);
                }
            }
        }

        // Восстановление решения.
        List<int> selected = new List<int>();

        int res = dp[n, capacity];

        int remaining = capacity;

        for (int i = n; i > 0; i--)
        {
            if (dp[i, remaining] != dp[i - 1, remaining])
            {
                selected.Add(i - 1);  // Индекс предмета
                remaining -= weights[i - 1];
            }
        }

        selected.Reverse();

        (int, List<int>) result = (res, selected);

        return result;

        // Временная сложность: O(n * capacity) — заполнение таблицы.
        // Пространственная сложность: O(n * capacity) — 2D таблица.
    }

    /// <summary>
    /// Наибольшая общая подпоследовательность (LCS) — восходящее ДП.
    /// </summary>
    /// <param name="s1">Первая строка.</param>
    /// <param name="s2">Вторая строка.</param>
    /// <returns>Длина LCS и сама подпоследовательность.</returns>
    public static (int length, string subsequence) LongestCommonSubsequence(string s1, string s2)
    {
        int m = s1.Length;
        int n = s2.Length;

        int[,] dp = new int[m + 1, n + 1];

        for (int i = 1; i <= m; i++)
        {
            for (int j = 1; j <= n; j++)
            {
                if (s1[i - 1] == s2[j - 1])
                {
                    dp[i, j] = dp[i - 1, j - 1] + 1;
                }
                else
                {
                    dp[i, j] = Math.Max(dp[i - 1, j], dp[i, j - 1]);
                }
            }
        }

        // Восстановление LCS.
        string lcs = "";
        int ii = m;
        int jj = n;

        while (ii > 0 && jj > 0)
        {
            if (s1[ii - 1] == s2[jj - 1])
            {
                lcs = s1[ii - 1] + lcs;
                ii--; jj--;
            }

            else if (dp[ii - 1, jj] > dp[ii, jj - 1])
            {
                ii--;
            }

            else
            {
                jj--;
            }
        }

        (int, string) result = (dp[m, n], lcs);

        return result;

        // Временная сложность: O(m * n) — заполнение таблицы.
        // Пространственная сложность: O(m * n) — таблица.
    }
}