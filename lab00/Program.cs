using System.Diagnostics;

// Метод считает сумму двух введенных чисел.
void CalculateSum()
{
    Console.WriteLine("Введите а: ");            // O(1) 
    int a = Convert.ToInt32(Console.ReadLine()); // O(1)

    Console.WriteLine("Введите b: ");            // O(1)
    int b = Convert.ToInt32(Console.ReadLine()); // O(1)

    int result = a + b;                          // O(1)

    Console.WriteLine($"Сумма: {result}");       // O(1)

    // Общая сложность O(1);
}

// Усложненная задача.
// Метод считает сумму N чисел в массиве.
long SumArray(int[] arr)
{
    long total = 0;          // O(1)

    foreach (int num in arr) // O(N) - N - количество элементов в массиве, цикл по всем элементам массива. 
    {
        total += num;        // O(1)
    }

    return total;            // O(1)

    // Общая сложность O(N);
}

// Метод измеряет время выполнения.
double MeasureTime(Func<int[], long> func, int[] data, int iteration = 10)
{
    double totalTime = 0;

    for (int i = 0; i < iteration; i++)            // O(N)
    {                                              
        Stopwatch sw = Stopwatch.StartNew();       // O(1)
        func(data);                                // O(N)
        sw.Stop();                                 // O(1)

        totalTime += sw.Elapsed.TotalMilliseconds; // O(1)
    }

    return totalTime / iteration;                  // O(1)
}

// ======= ХАРАКТЕРИСТИКИ ПК =======
Console.WriteLine("Характеристики ПК для тестирования:");
Console.WriteLine("- Процессор: Intel Core i7-12750H @ 2.30GHz");
Console.WriteLine("- Оперативная память: 16 GB DDR4");
Console.WriteLine("- ОС: Windows 11");
Console.WriteLine("- C# 13\n");

// ======= ВЫПОЛНЕНИЕ ОСНОВНОГО ЭКСПЕРИМЕНТА =======
int[] sizes = { 1000, 5000, 10000, 50000, 100000, 500000 };
List<double> times = new List<double>();

Console.WriteLine("Размер (N)\t Время (мс)\t Время/N (мкс)");
Random rnd = new Random();

foreach (int size in sizes)
{
    int[] data = new int[size];
    for (int i = 0; i < data.Length; i++)   // O(N)
        data[i] = rnd.Next(1, 1000);        // O(1)
    
    // Среднее время выполнения 1 итерации, с массивом на size элементов.
    double executionTime = MeasureTime(SumArray, data, 10); 
    times.Add(executionTime);

    // Время выполнения одного элемента(массива size) в микросекундах.
    double timePerElem = (executionTime * 1000) / size;
    Console.WriteLine($"{size, 12} | {executionTime, 15:F4} | {timePerElem, 15:F4}");
}