/// <summary>
/// Класс для генерации данных.
/// </summary>
public class GenerateData
{
    private static Random _rnd = new Random();

    /// <summary>
    /// Метод генерирует массив случайных чисел.
    /// </summary>
    /// <param name="size">Размер массива.</param>
    /// <returns>Массив.</returns>
    public static int[] GenerateRandomArray(int size)
    {
        int[] arr = new int[size];

        for (int i = 0; i < size; i++)
        {
            arr[i] = _rnd.Next(0, size * 10);
        }

        return arr;
    }

    /// <summary>
    /// Метод генерирует отсортированный массив чисел.
    /// </summary>
    /// <param name="size">Размер массива.</param>
    /// <returns>Массив.</returns>
    public static int[] GenerateSorted(int size)
    {
        int[] arr = new int[size];

        for (int i = 0; i < size; i++)
        {
            arr[i] = i;
        }

        return arr;
    }

    /// <summary>
    /// Метод генерирует массив чисел, отсортированных в обратном порядке.
    /// </summary>
    /// <param name="size">Размер массива.</param>
    /// <returns>Массив.</returns>
    public static int[] GenerateReversed(int size)
    {
        int[] arr = new int[size];

        for (int i = 0; i < size; i++)
        {
            arr[i] = size - i;
        }

        return arr;
    }

    /// <summary>
    /// Метод генерирует почти отсортированный массив чисел.
    /// </summary>
    /// <param name="size">Размер массива.</param>
    /// <param name="sortedRatio">Процент упорядочивания.</param>
    /// <returns>Массив.</returns>
    public static int[] GenerateAlmostSorted(int size, double sortedRatio = 0.95)
    {
        int[] arr = GenerateSorted(size);

        int swaps = (int)(size * (1 - sortedRatio));

        for (int i = 0; i < swaps; i++)
        {
            int idx1 = _rnd.Next(0, size);
            int idx2 = _rnd.Next(0, size);

            arr[idx1] = arr[idx2];
            arr[idx2] = arr[idx1];
        }

        return arr;
    }
}