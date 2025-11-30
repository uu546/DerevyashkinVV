/// <summary>
/// Класс бинарной кучи min-heap.
/// </summary>
public class Heap
{
    /// <summary>
    /// Массив элементов.
    /// </summary>
    private int[] _array;

    /// <summary>
    /// Количество элементов в куче.
    /// </summary>
    public int Count { get; set; }

    /// <summary>
    /// Конструктор.
    /// </summary>
    public Heap(int capacity = 16)
    {
        _array = new int[capacity];
        Count = 0;
    }

    /// <summary>
    /// Метод просеивания вверх - поднимает элемент до восстановления свойства кучи.
    /// </summary>
    /// <param name="index">Индекс элемента.</param>
    private void SiftUp(int index)
    {
        while (index > 0)
        {
            int parent = (index - 1) / 2;

            if (_array[parent] <= _array[index])
                break;

            int temp = _array[parent];
            _array[parent] = _array[index];
            _array[index] = temp;

            index = parent;
        }

        // Сложность: O(log n)
    }


    /// <summary>
    /// Метод просеивания вниз - восстанавливает свойство кучи после удаления корня.
    /// </summary>
    /// <param name="index">Индекс элемента.</param>
    private void SiftDown(int index)
    {
        while (true)
        {
            int left = index * 2 + 1;
            int right = index * 2 + 2;
            int smallest = index;

            if (left < Count && _array[left] < _array[smallest])
                smallest = left;

            if (right < Count && _array[right] < _array[smallest])
                smallest = right;

            if (smallest == index)
                break;

            int temp = _array[index];
            _array[index] = _array[smallest];
            _array[smallest] = temp;

            index = smallest;
        }

        // Сложность: O(log n)
    }

    /// <summary>
    /// Метод вставляет элемент в кучу.
    /// </summary>
    /// <param name="value">Значение.</param>
    public void Insert(int value)
    {
        _array[Count] = value;

        SiftUp(Count);
        Count++;

        // Сложность: O(log n)
    }

    /// <summary>
    /// Метод извлекает корень.    
    /// </summary>
    public int Peek()
    {
        if (Count == 0)
            throw new InvalidOperationException("Heap is empty.");

        return _array[0];

        // Сложность: O(1).
    }

    /// <summary>
    /// Метод извлекает минимальный элемент из кучи.
    /// </summary>
    /// <returns>Максимальный элемент.</returns>
    public int Extract()
    {
        if (Count == 0)
            throw new InvalidOperationException("Heap is empty.");

        int root = _array[0];
        Count--;

        _array[0] = _array[Count];
        SiftDown(0);

        return root;

        // Сложность: O(log n).
    }

    /// <summary>
    /// Метод построения кучи из произвольного массива.
    /// </summary>
    /// <param name="array">Массив.</param>
    public void BuildHeap(int[] array)
    {
        _array = array;
        Count = array.Length;

        for (int i = Count / 2 - 1; i >= 0; i--)
            SiftDown(i);

        // Сложность: O(n).
    }

    /// <summary>
    /// Метод сортировки HeapSort.    
    /// </summary>
    public static int[] HeapSort(int[] array)
    {
        Heap heap = new Heap(array.Length);

        heap.BuildHeap(array);

        int[] result = new int[array.Length];

        for (int i = 0; i < result.Length; i++)
        {
            result[i] = heap.Extract();
        }

        return result;

        // Сложность: O(n log n).
    }

    /// <summary>
    /// In-place HeapSort - сортирует массив без выделения памяти.
    /// </summary>
    /// <param name="array">Массив.</param>
    public static void HeapSortInPlace(int[] array)
    {
        int n = array.Length;

        for (int i = n / 2 - 1; i >= 0; i--)
        {
            SiftDownStatic(array, n, i);
        }

        for (int i = n - 1; i > 0; i--)
        {
            int temp = array[0];
            array[0] = array[i];
            array[i] = temp;

            SiftDownStatic(array, i, 0);
        }

        Array.Reverse(array);

        //Сложность: O(n log n).
    }

    /// <summary>
    /// Метод просеивания вниз для массива при сортировке.
    /// </summary>
    private static void SiftDownStatic(int[] array, int size, int index)
    {
        while (true)
        {
            int left = index * 2 + 1;
            int right = index * 2 + 2;
            int smallest = index;

            if (left < size && array[left] < array[smallest])
                smallest = left;

            if (right < size && array[right] < array[smallest])
                smallest = right;

            if (smallest == index)
                break;

            int temp = array[index];
            array[index] = array[smallest];
            array[smallest] = temp;

            index = smallest;
        }

    }
}
