/// <summary>
/// Класс реализует жадные алгоритмы.
/// </summary>
public static class GreedyAlgorithm
{
    /// <summary>
    /// Метод реализует задачу о выборе заявок.
    /// </summary>
    /// <param name="intervals">Массив с интервалами(начало, конец).</param>
    /// <returns>Список непересекающихся интервалов.</returns>
    public static int[][] ActivitySelection(int[][] intervals)
    {
        if (intervals is null || !intervals.Any())
        {
            return [];
        }

        // Сортировка по значениям окончания интервала.
        int[][] sorted = intervals.OrderBy(x => x[1]) // O(n log n)
            .ToArray();

        List<int[]> result = new List<int[]>();

        result.Add(sorted[0]);

        // Значение конца интервала.
        int last = sorted[0][1];

        for (int i = 1; i < sorted.Length; i++) // O(n)
        {
            // Начало следующего интервала >= конца прошлого.
            if (sorted[i][0] >= last)
            {
                result.Add(sorted[i]);
                last = sorted[i][1];
            }
        }

        return result.ToArray();

        // Сложность: O(n log n) - из-за сортировки.
    }

    /// <summary>
    /// Метод реализует непрерывный рюкзак.
    /// </summary>
    /// <param name="weights">Массив весов предметов.</param>
    /// <param name="values">Массив стоимости предметов.</param>
    /// <param name="capacity">Вместимость рюкзака.</param>
    /// <returns>Максимальная возможная стоимость предметов.</returns>
    public static double FractionalKnapsack(int[] weights, int[] values, int capacity)
    {
        if (weights is null || values is null || weights.Length != values.Length)
        {
            throw new InvalidOperationException("Ошибка");
        }

        var items = new (double ratio, int weight, int value)[weights.Length];

        for (int i = 0; i < weights.Length; i++)
        {
            // Заполняем массив кортежей.
            items[i] = ((double)values[i] / weights[i], weights[i], values[i]);
        }

        // O(n log n) - сортировка удельной стоимости по убыванию.
        Array.Sort(items, (a, b) => b.ratio.CompareTo(a.ratio));

        double totalValue = 0;
        int currentCapacity = capacity;

        foreach (var item in items) // O(n) - заполнение рюкзака предметами.
        {
            if (currentCapacity <= 0)
            {
                break;
            }

            // Если вес предмета полностью помещается в рюкзак.
            if (item.weight <= currentCapacity)
            {
                // Добавляем цену предмета.
                totalValue += item.value;

                currentCapacity -= item.weight;
            }

            else
            {
                // Берем дробную часть, для заполнения рюкзака.
                totalValue += item.ratio * currentCapacity;
                currentCapacity = 0;
            }
        }

        return totalValue;

        // Сложность: O(n log n) - из-за сортировки.
    }

    /// <summary>
    /// Метод реализует алгоритм Хаффмана.
    /// </summary>
    /// <param name="frequencies">Словарь частот символов.</param>
    /// <returns>Словарь (символ, код).</returns>
    public static Dictionary<char, string> HuffmanCoding(Dictionary<char, int> frequencies)
    {
        PriorityQueue<HuffmanNode, int> heap = new PriorityQueue<HuffmanNode, int>();

        foreach (var kvp in frequencies) // O(n) - добавление обьектов в очередь.
        {
            heap.Enqueue(new HuffmanNode // O(log n) - вставка в очередь.
            {
                Symbol = kvp.Key,
                Frequency = kvp.Value
            }, kvp.Value);
        }

        while (heap.Count > 1)
        {
            // Удаляем приоритетные элементы.
            var left = heap.Dequeue();
            var right = heap.Dequeue();

            var parent = new HuffmanNode
            {
                // Суммируем частоты.
                Frequency = left.Frequency + right.Frequency,
                Left = left,
                Right = right
            };

            // Добавляем элемент с левым и правым узлом в очередь.
            heap.Enqueue(parent, parent.Frequency);
        }

        HuffmanNode root = heap.Dequeue();
        Dictionary<char, string> codes = new Dictionary<char, string>();

        BuildCodes(root, "");

        return codes;

        void BuildCodes(HuffmanNode node, string code)
        {
            if (node is null)
            {
                return;
            }

            if (node.Symbol != '\0')
            {
                codes[node.Symbol] = code;
            }

            BuildCodes(node.Left!, code + "0");
            BuildCodes(node.Right!, code + "1");
        }

        // Сложность: O(n log n).
    }

    /// <summary>
    /// Метод решает задачу о минимальном количестве монет для выдачи сдачи. 
    /// </summary>
    /// <param name="coins">Массив доступных монет.</param>
    /// <param name="amount">Сумма для выдачи.</param>
    /// <returns>Количество монет.</returns>
    public static int GetMinCountCoins(int[] coins, int amount)
    {
        if (amount < 0)
        {
            return -1;
        }

        if (amount == 0)
        {
            return 0;
        }

        Array.Sort(coins);
        Array.Reverse(coins);

        int count = 0;

        for (int i = 0; i < coins.Length; i++)
        {
            if (amount == 0)
            {
                break;
            }

            while (amount >= coins[i])
            {
                amount -= coins[i];
                count++;
            }
        }

        int result = amount == 0 ? count : -1;

        return result;
    }

    /// <summary>
    /// Класс узла алгоритма Хаффмана.
    /// </summary>
    private class HuffmanNode
    {
        /// <summary>
        /// Символ.
        /// </summary>
        public char Symbol { get; set; }

        /// <summary>
        /// Частота (повторение символа).
        /// </summary>
        public int Frequency { get; set; }

        /// <summary>
        /// Левый узел.
        /// </summary>
        public HuffmanNode? Left { get; set; }

        /// <summary>
        /// Правый узел.
        /// </summary>
        public HuffmanNode? Right { get; set; }
    }
}