/// <summary>
/// Класс реализует хеш-функции.
/// </summary>
public static class HashFunction
{
    /// <summary>
    /// Метод реализует хеш-функцию, сумма кодов символов.
    /// </summary>
    /// <param name="key">Ключ.</param>
    /// <param name="tableSize">Размер таблицы.</param>
    /// <returns>Хеш - представление ключа.</returns>
    public static int SimpleHash(string key, int tableSize)
    {
        int sum = 0;

        foreach (char c in key)
        {
            sum += c;
        }

        int result = sum % tableSize;

        return result;

        // O(n) по длине строки.
        // Хеш зависит от суммы символов -> строки с одинаковой суммой будут давать одинаковый хеш.
        // Плохое распределение -> большая вероятность коллизий.
    }

    /// <summary>
    /// Метод реализует полиномиальную хеш-функцию.
    /// </summary>
    /// <param name="key">Ключ.</param>
    /// <param name="tableSize">Размер таблицы.</param>
    /// <param name="p">База(Основание полинома).</param>
    /// <returns>Хеш - представление ключа.</returns>
    public static int PolynomialHash(string key, int tableSize, int p = 31)
    {
        long hash = 0;
        long pPow = 1;

        foreach (char c in key)
        {
            hash = (hash + (c * pPow)) % tableSize;
            pPow = (pPow * p) % tableSize;
        }

        return (int)hash;

        // O(n) по длине строки.
        // Хорошее распределение.
        // Чувстительно к параметру p(основание поолинома).
        // Оптимальна для строк, особенно при большой загрузке таблицы.
    }

    /// <summary>
    /// Метод реализует DJB2 хеш-функцию.
    /// </summary>
    /// <param name="key">Ключ.</param>
    /// <param name="tableSize">Размер таблицы.</param>
    /// <returns></returns>
    public static int Djb2Hash(string key, int tableSize)
    {
        ulong hash = 5381;

        foreach (char c in key)
        {
            hash = (hash << 5) + hash + c;
        }

        return (int)(hash % (ulong)tableSize);

        // O(n) по длине строки.
        // Одно из лучших распределений.
        // Малое число коллизий.
    }
}