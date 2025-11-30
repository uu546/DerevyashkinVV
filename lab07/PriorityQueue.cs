/// <summary>
/// Класс очередь с приоритетом.
/// </summary>
public class PriorityQueue
{
    /// <summary>
    /// Куча где хранятся пары (приоритет, значение)
    /// </summary>
    private int[] _priority;
    private int[] _values;
    private int _size;

    public int Count => _size;

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="count">Размер кучи.</param>
    public PriorityQueue(int count = 16)
    {
        _priority = new int[count];
        _values = new int[count];
        _size = 0;
    }

    /// <summary>
    /// Метод вставляет элемент с приоритетом.
    /// </summary>
    public void Enqueue(int value, int priority)
    {
        _values[_size] = value;
        _priority[_size] = priority;

        SiftUp(_size);
        _size++;

        // Сложность: O(log n).
    }

    private void SiftUp(int i)
    {
        while (i > 0)
        {
            int parent = (i - 1) / 2;

            if (_priority[parent] <= _priority[i])
                break;

            Swap(parent, i);

            i = parent;
        }
    }

    /// <summary>
    /// Метод удаляет и возвращает элемент с максимальным приоритетом.
    /// </summary>
    public int Dequeue()
    {
        if (_size == 0)
            throw new InvalidOperationException("Queue is empty.");

        int result = _values[0];

        _size--;

        _values[0] = _values[_size];
        _priority[0] = _priority[_size];

        SiftDown(0);

        return result;

        // Сложность: O(log n).
    }

    private void SiftDown(int i)
    {
        while (true)
        {
            int left = i * 2 + 1;
            int right = i * 2 + 2;
            int smallest = i;

            if (left < _size && _priority[left] < _priority[smallest])
                smallest = left;

            if (right < _size && _priority[right] < _priority[smallest])
                smallest = right;

            if (smallest == i)
                break;

            Swap(i, smallest);

            i = smallest;
        }
    }

    private void Swap(int i, int j)
    {
        int tempValue = _values[i];
        _values[i] = _values[j];
        _values[j] = tempValue;

        int tempPr = _priority[i];
        _priority[i] = _priority[j];
        _priority[j] = tempPr;
    }
}
