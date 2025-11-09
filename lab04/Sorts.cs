/// <summary>
/// Класс реализует алгоритмы сортировки.
/// </summary>
public class Sorts
{
    /// <summary>
    /// Метод реализует алгоритм пузырьковой сортировки.
    /// </summary>
    /// <param name="array">Массив.</param>
    public static void BubbleSort(int[] array)
    {
        for (int i = 0; i < array.Length - 1; i++)
        {
            for (int j = 0; j < array.Length - i - 1; j++)
            {
                if (array[j] > array[j + 1])
                {
                    int temp = array[j];
                    array[j] = array[j + 1];
                    array[j + 1] = temp;
                }
            }
        }

        // Сложность алгоритма: O(n^2)
        // Пространственная сложность: O(1)
    }

    /// <summary>
    /// Метод реализует алгоритм сортировка выбором (Selection Sort).
    /// </summary>
    /// <param name="array">Массив.</param>
    public static void SelectionSort(int[] array)
    {
        int n = array.Length;

        for (int i = 0; i < n - 1; i++)
        {
            int minIndex = i;

            for (int j = i + 1; j < n; j++)
            {
                if (array[j] < array[minIndex])
                {
                    minIndex = j;
                }
            }

            // Обмен минимального элемента с текущим
            array[i] = array[minIndex];
            array[minIndex] = array[i];
        }

        // Сложность алгоритма: O(n^2)
        // Пространственная сложность: O(1)
    }

    /// <summary>
    /// Метод реализует алгоритм сортировка вставками (Insertion Sort).
    /// </summary>
    /// <param name="array">Массив.</param>
    public static void InsertionSort(int[] array)
    {
        int n = array.Length;

        for (int i = 1; i < n; i++)
        {
            int key = array[i];
            int j = i - 1;

            // Сдвигаем элементы больше key вправо
            while (j >= 0 && array[j] > key)
            {
                array[j + 1] = array[j];
                j--;
            }

            array[j + 1] = key;
        }

        // Сложность алгоритма: O(n^2)
        // Пространственная сложность: O(1)
    }

    /// <summary>
    /// Метод реализует алгоритм сортировка слиянием (Merge Sort) - рекурсия.
    /// </summary>
    /// <param name="array">Массив.</param>
    public static void MergeSort(int[] array)
    {
        if (array.Length <= 1) return;
        MergeSort(array, 0, array.Length - 1);

        // Сложность алгоритма:: O(n log n)
        // Пространственная сложность: O(n) 
    }

    private static void MergeSort(int[] array, int left, int right)
    {
        if (left < right)
        {
            int mid = left + (right - left) / 2;

            // Рекурсивно сортируем левую и правую части
            MergeSort(array, left, mid);
            MergeSort(array, mid + 1, right);

            // Сливаем отсортированные части
            Merge(array, left, mid, right);
        }
    }

    private static void Merge(int[] array, int left, int mid, int right)
    {
        int n1 = mid - left + 1;
        int n2 = right - mid;

        // Временные массивы
        int[] leftArr = new int[n1];
        int[] rightArr = new int[n2];

        Array.Copy(array, left, leftArr, 0, n1);
        Array.Copy(array, mid + 1, rightArr, 0, n2);

        int i = 0, j = 0, k = left;

        // Сливаем временные массивы обратно в arr
        while (i < n1 && j < n2)
        {
            if (leftArr[i] <= rightArr[j])
            {
                array[k] = leftArr[i];
                i++;
            }
            else
            {
                array[k] = rightArr[j];
                j++;
            }
            k++;
        }

        // Копируем оставшиеся элементы
        while (i < n1)
        {
            array[k] = leftArr[i];
            i++;
            k++;
        }

        while (j < n2)
        {
            array[k] = rightArr[j];
            j++;
            k++;
        }
    }

    /// <summary>
    /// Метод реализует алгоритм быстрая сортировка (Quick Sort) - рекурсия.
    /// </summary>
    /// <param name="array">Массив.</param>
    public static void QuickSort(int[] array)
    {
        if (array.Length <= 1) return;
        QuickSort(array, 0, array.Length - 1);

        // Сложность алгоритма: O(n log n) - средний, O(n^2) - худший
        // Пространственная сложность: O(log n) - средний, O(n) - худший
    }

    private static void QuickSort(int[] array, int low, int high)
    {
        if (low < high)
        {
            // Разделение массива и получение индекса опорного элемента
            int pivotIndex = Partition(array, low, high);

            // Рекурсивно сортируем элементы до и после опорного
            QuickSort(array, low, pivotIndex - 1);
            QuickSort(array, pivotIndex + 1, high);
        }
    }

    private static int Partition(int[] array, int low, int high)
    {
        // Опорный элемент (последний)
        int pivot = array[high];
        int i = low - 1;

        for (int j = low; j < high; j++)
        {
            if (array[j] <= pivot)
            {
                i++;
                (array[i], array[j]) = (array[j], array[i]);
            }
        }

        // Помещаем опорный элемент на правильную позицию
        (array[i + 1], array[high]) = (array[high], array[i + 1]);
        return i + 1;
    }
}
