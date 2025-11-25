// Средняя сложность операций:
//  Insert: O(1)
//  Search: O(1)
//  Delete: O(1)
//
// Худший случай: когда пара(ключ, значение) попадает в один и тот же индекс(в одну корзину),
//                что образует длинный список(цепочку) коллизий. 
//  Insert: O(n)
//  Search: O(n)
//  Delete: O(n)

/// <summary>
/// Класс реализует хеш-таблицу метод цепочек.
/// </summary>
public class HashTableChaining : IHashTable
{
    public int TableSize => _table.Length;

    /// <summary>
    /// Таблица, обьект - список ключ значение.
    /// </summary>
    private List<KeyValuePair<string, string>>[] _table;

    /// <summary>
    /// Количество добавленных элементов в таблицу.
    /// </summary>
    private int _count;

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="size">Размер таблицы.</param>
    public HashTableChaining(int size)
    {
        _table = new List<KeyValuePair<string, string>>[size];

        for (int i = 0; i < size; i++)
        {
            _table[i] = new List<KeyValuePair<string, string>>();
        }
    }

    /// <summary>
    /// Метод добавляет добавляет значение.
    /// </summary>
    /// <param name="key">Ключ.</param>
    /// <param name="value">Значение.</param>
    public void Add(string key, string value)
    {
        int index = HashFunction.SimpleHash(key, _table.Length);

        // Если коллизия, то проверяем что ключи разные.
        foreach (var pair in _table[index])
        {
            if (pair.Key == key)
            {
                throw new Exception("Key существует.");
            }
        }

        _table[index].Add(new KeyValuePair<string, string>(key, value));
        _count++;

        // Проверка коэффициента загрузки.
        if ((double)_count / _table.Length > 0.75)
        {
            Resize();
        }
    }

    /// <summary>
    /// Метод получает значение по ключу.
    /// </summary>
    /// <param name="key">Ключ.</param>
    /// <returns>Значение.</returns>
    public string? Get(string key)
    {
        int index = HashFunction.SimpleHash(key, _table.Length);

        // Линейно ищем среди списка пар(ключ, значение), пару которая соответсвует переданному ключу.
        foreach (KeyValuePair<string, string> pair in _table[index])
        {
            if (pair.Key == key)
            {
                return pair.Value;
            }
        }

        return null;
    }

    /// <summary>
    /// Метод удаляет пару(ключ, значение) по ключу.
    /// </summary>
    /// <param name="key">Ключ.</param>
    /// <returns>Признак удаления.</returns>
    public bool Delete(string key)
    {
        int index = HashFunction.SimpleHash(key, _table.Length);

        for (int i = 0; i < _table[index].Count; i++)
        {
            if (_table[index][i].Key == key)
            {
                _table[index].RemoveAt(i);
                _count--;

                return true;
            }
        }

        return false;
    }

    /// <summary>
    /// Метод увеличивает размер таблицы.
    /// </summary>
    private void Resize()
    {
        List<KeyValuePair<string, string>>[] old = _table;

        int newLength = old.Length * 2;

        _table = new List<KeyValuePair<string, string>>[newLength];

        for (int i = 0; i < _table.Length; i++)
        {
            _table[i] = new List<KeyValuePair<string, string>>();
        }

        _count = 0;

        foreach (List<KeyValuePair<string, string>> bucket in old)
        {
            if (bucket.Any())
            {
                foreach (KeyValuePair<string, string> kv in bucket)
                {
                    Add(kv.Key, kv.Value);
                }
            }
        }
    }
}