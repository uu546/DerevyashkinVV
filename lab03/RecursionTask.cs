/// <summary>
/// Класс реализует методы с использованием рекурсии.
/// </summary>
public static class RecursionTask
{
    /// <summary>
    /// Реализация рекурсивного бинарного поиска.
    /// </summary>
    /// <param name="arr">Массив.</param>
    /// <param name="target">Число.</param>
    /// <param name="left">Указатель начала.</param>
    /// <param name="right">Указатель конца.</param>
    /// <returns>Индекс числа.</returns>
    public static int BinarySearchRecursive(int[] arr, int target, int left, int right)
    {
        if (left > right)
        {
            return -1;
        }

        int mid = left + (right - left) / 2;

        if (arr[mid] == target)
        {
            return mid;
        }

        if (arr[mid] > target)
        {
            return BinarySearchRecursive(arr, target, left, mid - 1);
        }

        else
        {
            return BinarySearchRecursive(arr, target, mid + 1, right);
        }

        // Сложность: O(log n)
        // Глубина рекурсии: O(log n)
    }

    /// <summary>
    /// Метод решает задачу "Ханойские башни".
    /// </summary>
    /// <param name="n">Количество дисков которые нужно переместить.</param>
    /// <param name="from">Стержень с которого перекладываем диски.</param>
    /// <param name="to">Стержень на который нужно переложить.</param>
    /// <param name="temp">Временный стержень.</param>
    public static void HanoiTowers(int n, char from, char to, char temp)
    {
        if (n == 1)
        {
            Console.WriteLine($"Переместить диск 1 с {from} на {to}");

            return;
        }

        HanoiTowers(n - 1, from, temp, to);

        Console.WriteLine($"Переместить диск {n} с {from} на {to}");

        HanoiTowers(n - 1, temp, to, from);

        // Сложность: O(2^n)
        // Глубина рекурсии: O(n)
    }
}
