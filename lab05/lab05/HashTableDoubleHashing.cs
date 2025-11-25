/// <summary>
/// Класс реализует хеш-таблицу открытой адресации метод двойного хеширования.
/// </summary>
public class HashTableDoubleHashing : IHashTable
{
    public int TableSize => _keys.Length;
    public int Count => _count;

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
    public HashTableDoubleHashing(int size)
    {
        _keys = new string[size];
        _values = new string[size];
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
    /// Метод второй хеш-функции.
    /// </summary>
    /// <param name="key">Ключ.</param>
    /// <returns>Хеш - представление ключа.</returns>
    private int SecondHash(string key)
    {
        int result = HashFunction.PolynomialHash(key, _keys.Length - 1) + 1;

        return result;
    }

    /// <summary>
    /// Метод добавляет пару(ключ, значение) в таблицу.
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
        int secondHash = SecondHash(key);

        // Если есть коллизия.
        while (_keys[index] is not null)
        {
            index = (index + secondHash) % _keys.Length;
        }

        _keys[index] = key;
        _values[index] = value;
        _count++;
    }

    /// <summary>
    /// Метод увеличивает размер таблицы.
    /// </summary>
    private void Resize()
    {
        var oldKeys = _keys;
        var oldValues = _values;

        _keys = new string[oldKeys.Length * 2];
        _values = new string[_keys.Length];

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