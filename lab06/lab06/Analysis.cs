using System.Diagnostics;

/// <summary>
///  Класс замеряет выремя выполнения методов бинарного дерева.
/// </summary>
public class Analysis
{
    /// <summary>
    /// Класс генерации случайных чисел.
    /// </summary>
    private Random _rnd = new Random();

    /// <summary>
    /// Количетсво узлов в дереве.
    /// </summary>
    private int[] _countNodes = [5, 10, 100, 500, 1000, 5000, 10_000];

    /// <summary>
    /// Список времени поиска сбалансированного дерева.
    /// </summary>
    private List<double>? _balancedTreeTimes;

    /// <summary>
    /// Список времени поиска вырожденного дерева.
    /// </summary>
    private List<double>? _noBalancedTreeTimes;

    /// <summary>
    /// Метод выполняет тест производительности метода поиска.
    /// </summary>
    /// <returns></returns>
    public void RunPerformanceTest()
    {
        Console.WriteLine("SIZE\tBalanceTree(ns)\tNoBalanceTree(ns)\tHeightBalanceTree\tHeightNonBalanceTree");

        int[] arr = GenerateArray();

        _balancedTreeTimes = new List<double>(_countNodes.Length);
        _noBalancedTreeTimes = new List<double>(_countNodes.Length);

        foreach (int count in _countNodes)
        {
            BinarySearchTree balanced = GetRandomBalanceTree(count);
            BinarySearchTree noBalance = GetRandomNoBalanceTree(count);

            double balancedTree = MeasureSearch(balanced, arr).TotalNs;
            double noBalancedTree = MeasureSearch(noBalance, arr).TotalNs;

            int h1 = balanced.Height(balanced.Root!);
            int h2 = noBalance.Height(noBalance.Root!);

            _balancedTreeTimes.Add(balancedTree);
            _noBalancedTreeTimes.Add(noBalancedTree);

            Console.WriteLine($"{count}\t{balancedTree}\t\t{noBalancedTree}\t\t\t{h1}\t\t\t{h2}");
        }

        Graph();
    }

    /// <summary>
    /// Метод строит график зависимости времени.
    /// </summary>
    private void Graph()
    {
        ScottPlot.Plot plot = new ScottPlot.Plot(800, 600);

        plot.AddScatter(_countNodes.Select(i => (double)i).ToArray(),
            _balancedTreeTimes!.ToArray(),
            label: "Balanced Tree");

        plot.AddScatter(_countNodes.Select(i => (double)i).ToArray(),
            _noBalancedTreeTimes!.ToArray(),
            label: "No balanced Tree");

        plot.Title("График зависимости времени операций поиска от количества элементов");
        plot.XLabel("Количество элементов");
        plot.YLabel("Время (нс)");
        plot.Legend();
        plot.Grid(true);
        plot.SaveFig("binary_tree10_000.png");
    }

    /// <summary>
    /// Метод возвращает сбалансированное дерево.
    /// </summary>
    /// <param name="countNode">Количество узлов дерева.</param>
    /// <returns>Сбалансированное дерево.</returns>
    private BinarySearchTree GetRandomBalanceTree(int countNode)
    {
        BinarySearchTree tree = new BinarySearchTree();

        for (int i = 0; i < countNode; i++)
        {
            int value = _rnd.Next(1_000_000);

            tree.Insert(value);
        }

        return tree;
    }

    /// <summary>
    /// Метод возвращает вырожденое дерево.
    /// </summary>
    /// <param name="countNode">Количество узлов дерева.</param>
    /// <returns>Вырожденное дерево.</returns>
    private BinarySearchTree GetRandomNoBalanceTree(int countNode)
    {
        BinarySearchTree tree = new BinarySearchTree();

        for (int i = 0; i < countNode; i++)
        {
            tree.Insert(i);
        }

        return tree;
    }

    /// <summary>
    /// Метод выполняет замер поиска значения в дереве.
    /// </summary>
    /// <param name="tree">Дерево.</param>
    /// <param name="values">Массив значений для поиска в дереве.</param>
    /// <returns>Время выполнения.</returns>
    private MeasureTimeNsOutput MeasureSearch(BinarySearchTree tree, int[] values)
    {
        Stopwatch sw = new Stopwatch();

        double totalTime = 0;

        for (int i = 0; i < values.Length; i++)
        {
            sw.Restart();
            tree.Search(tree.Root!, values[i]);
            sw.Stop();

            totalTime += sw.Elapsed.TotalNanoseconds;
        }

        double avgTime = totalTime / values.Length;

        MeasureTimeNsOutput result = new()
        {
            AvgNs = avgTime,
            TotalNs = sw.Elapsed.TotalNanoseconds
        };

        return result;
    }

    /// <summary>
    /// Метод генерирует массив случайных чисел.
    /// </summary>
    /// <returns>Массив.</returns>
    private int[] GenerateArray()
    {
        int[] array = new int[1000];

        for (int i = 0; i < array.Length; i++)
        {
            array[i] = _rnd.Next(1_000_000);
        }

        return array;
    }

    /// <summary>
    /// Метод визуализирует дерево.
    /// </summary>
    /// <param name="node">Дерево.</param>
    public string PrintTree(TreeNode node)
    {
        if (node is null)
        {
            return "null";
        }

        string left = $"{node.Value}({PrintTree(node.Left!)}";
        string right = $", {PrintTree(node.Right!)})";

        string result = string.Concat(left, right);

        return result;
    }
}

/// <summary>
/// Класс выходной модели измерения нс.
/// </summary>
public class MeasureTimeNsOutput
{
    /// <summary>
    /// Среднее время одной операции в нс.
    /// </summary>
    public double AvgNs { get; set; }

    /// <summary>
    /// Общее время всех операций в нс.
    /// </summary>
    public double TotalNs { get; set; }
}