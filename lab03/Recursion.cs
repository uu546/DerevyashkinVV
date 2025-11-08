/// <summary>
/// Класс реализует методы с использованием рекурсии.
/// </summary>
public static class Recursion
{
    /// <summary>
    /// Метод вычисляет факториал.
    /// </summary>
    /// <param name="n">Число.</param>
    /// <returns>Факториал.</returns>
    public static long Factorial(int n)
    {
        if (n < 0) throw new ArgumentException("n < 0");

        if (n <= 1) return 1;

        return n * Factorial(n - 1);

        // Сложность: O(n)
        // Глубина рекурсии: O(n)
    }

    /// <summary>
    /// Метод вычисляет n-го числа Фибоначчи (наивная версия).
    /// </summary>
    /// <param name="n">Число.</param>
    /// <returns>Число фибоначчи.</returns>
    public static long FibonacciNaive(int n)
    {
        if (n < 0) throw new ArgumentException("n < 0");

        if (n <= 1) return n;

        return FibonacciNaive(n - 1) + FibonacciNaive(n - 2);

        // Сложность: O(2^n)
        // Глубина рекурсии: O(n)
    }

    /// <summary>
    /// Метод возводит число в степень.
    /// </summary>
    /// <param name="a">Число.</param>
    /// <param name="n">Степень.</param>
    /// <returns>число в степени.</returns>
    public static double Power(double a, int n)
    {
        if (n < 0) return 1 / Power(a, -n);
        if (n == 0) return 1;
        if (n == 1) return a;

        if (n % 2 == 0)
        {
            double half = Power(a, n / 2);
            return half * half;
        }

        else
        {
            return a * Power(a, n - 1);
        }

        // Сложность: O(log n)
        // Глубина рекурсии: O(log n)
    }
}