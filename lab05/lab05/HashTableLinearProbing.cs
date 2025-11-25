/// <summary>
/// Класс реализует хеш-таблицу открытой адресации метод линейное пробирование.
/// </summary>
public class HashTableLinearProbing : IHashTable
{
    public int TableSize => _keys.Length;

    /// <summary>
    /// Ключи.
    /// </summary>
    private string[] _keys;

    /// <summary>
    /// Значения.
    /// </summary>
    private string[] _values;

    /// <summary>
    /// Количество добавленных элементов в таблицу.
    /// </summary>
    private int _count;

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="size">Размер таблицы.</param>
    public HashTableLinearProbing(int size)
    {
        _keys = new string[size];

        _values = new string[size];
    }

    /// <summary>
    /// Метод добавляет элементы в таблицу.
    /// </summary>
    /// <param name="key">Ключ.</param>
    /// <param name="value">Значение.</param>
    public void Add(string key, string value)
    {
        if ((double)_count / _keys.Length > 0.75)
        {
            Resize();
        }

        int index = HashFunction.SimpleHash(key, _keys.Length);

        // Если есть коллизия.
        while (_keys[index] is not null)
        {
            index = (index + 1) % _keys.Length;
        }

        _keys[index] = key;
        _values[index] = value;
        _count++;
    }

    /// <summary>
    /// Метод получает значение по ключу.
    /// </summary>
    /// <param name="key">Ключ.</param>
    /// <returns>Значение.</returns>
    public string? Get(string key)
    {
        int index = HashFunction.SimpleHash(key, _keys.Length);

        while (_keys[index] is not null)
        {

            if (_keys[index] == key)
            {
                return _values[index];
            }

            index = (index + 1) % _keys.Length;
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
        int index = HashFunction.SimpleHash(key, _keys.Length);

        while (_keys[index] is not null)
        {
            if (_keys[index] == key)
            {
                _keys[index] = null;
                _values[index] = null;

                _count--;

                return true;
            }

            index = (index + 1) % _keys.Length;
        }

        return false;
    }

    /// <summary>
    /// Метод увеличивает размер таблицы.
    /// </summary>
    private void Resize()
    {
        string[] oldKeys = _keys;
        string[] oldValues = _values;

        int newLength = _keys.Length * 2;

        _keys = new string[newLength];
        _values = new string[newLength];

        _count = 0;

        for (int i = 0; i < oldKeys.Length; i++)
        {
            if (oldKeys[i] is not null)
            {
                Add(oldKeys[i], oldValues[i]);
            }
        }
    }
}
