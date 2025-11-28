/// <summary>
/// Класс бинарного дерева
/// </summary>
public class BinarySearchTree
{
    /// <summary>
    /// Корень дерева.
    /// </summary>
    public TreeNode? Root;

    /// <summary>
    /// Метод добавляет значение в дерево.
    /// </summary>
    /// <param name="value">Значение.</param>
    public void Insert(int value)
    {
        Root = Insert(Root!, value);

        // Средняя сложность: O(log n)
        // Худшая сложность: O(n) если дерево вырождено, длинная последовательная цепочка.
    }

    private TreeNode Insert(TreeNode node, int value)
    {
        if (node == null)
        {
            return new TreeNode(value);
        }

        if (value < node.Value)
        {
            node.Left = Insert(node.Left!, value);
        }

        else if (value > node.Value)
        {
            node.Right = Insert(node.Right!, value);
        }

        return node;
    }

    /// <summary>
    /// Метод проверяет наличие значения в дереве.
    /// </summary>
    /// <param name="node">Дерево.</param>
    /// <param name="value">Значение.</param>
    /// <returns>Признак проверки.</returns>
    public bool Search(TreeNode node, int value)
    {
        if (node is null || node.Value == value)
        {
            return node is not null;
        }

        if (value < node.Value)
        {
            return Search(node.Left!, value);
        }

        return Search(node.Right!, value);

        // Средняя сложность: O(log n)
        // Худшая: O(n)
    }

    /// <summary>
    /// Метод ищет значение минимума в дереве.
    /// </summary>
    /// <param name="node">Дерево.</param>
    /// <returns>Узел.</returns>
    public TreeNode? FindMin(TreeNode node)
    {
        if (node is null)
        {
            return null;
        }

        while (node.Left is not null)
        {
            node = node.Left;
        }

        return node;

        // Средняя: O(log n)
        // Худшая: O(n)
    }

    /// <summary>
    /// Метод ищет значение максимума в дереве.
    /// </summary>
    /// <param name="node">Дерево.</param>
    /// <returns>Узел.</returns>
    public TreeNode? FindMax(TreeNode node)
    {
        if (node is null)
        {
            return null;
        }

        while (node.Right is not null)
        {
            node = node.Right;
        }

        return node;

        // Средняя: O(log n)
        // Худшая: O(n)
    }

    /// <summary>
    /// Метод удаляет значение из дерева.
    /// </summary>
    /// <param name="value">Значение.</param>
    public void Delete(int value)
    {
        Root = Delete(Root!, value);

        // Средняя: O(log n)
        // Худшая: O(n)
    }

    private TreeNode? Delete(TreeNode node, int value)
    {
        if (node is null)
        {
            return null;
        }

        if (value < node.Value)
        {
            node.Left = Delete(node.Left!, value);
        }

        else if (value > node.Value)
        {
            node.Right = Delete(node.Right!, value);
        }

        else
        {
            // Если узел - лист(одно значение).
            if (node.Left is null && node.Right is null)
            {
                return null;
            }

            // Если у узла есть поддерево слева.
            if (node.Left is null)
            {
                return node.Right;
            }

            // Если у узла есть поддерево справа.
            if (node.Right is null)
            {
                return node.Left;
            }

            // Если у узла есть левое и правое поддерево.
            // Минимальное значение в правом поддереве.
            TreeNode minRight = FindMin(node.Right)!;

            // Замена значения узла на мин.значение из правого поддерева.
            node.Value = minRight.Value;

            // Удаление мин.значения из правого поддерева (значение уже в текущем узле).
            node.Right = Delete(node.Right, minRight.Value);
        }

        return node;
    }

    /// <summary>
    /// Метод вычисляет высоту дерева.
    /// </summary>
    /// <param name="node">Дерево.</param>
    /// <returns>Высота поддерева.</returns>
    public int Height(TreeNode node)
    {
        if (node is null)
        {
            return -1;
        }

        int left = Height(node.Left!);
        int right = Height(node.Right!);

        int result = Math.Max(left, right) + 1;

        return result;

        // Средняя: O(n)
        // Худшая: O(n)
    }

    /// <summary>
    /// Метод проверяет, является ли дерево корректным бинарным деревом поиска (BST).
    /// </summary>
    /// <returns>Признак проверки.</returns>
    public bool IsValidBst()
    {
        bool result = IsValidBst(Root!, int.MinValue, int.MaxValue);

        return result;

        // Средняя: O(n)
    }

    private bool IsValidBst(TreeNode node, int min, int max)
    {
        if (node is null)
        {
            return true;
        }

        if (node.Value <= min || node.Value >= max)
        {
            return false;
        }

        bool left = IsValidBst(node.Left!, min, node.Value);
        bool right = IsValidBst(node.Right!, node.Value, max);

        bool result = left && right;

        return result;
    }
}

/// <summary>
/// Класс узла бинарного дерева.
/// </summary>
public class TreeNode
{
    /// <summary>
    /// Значение узла.
    /// </summary>
    public int Value;

    /// <summary>
    /// Левое поддерево узла.
    /// </summary>
    public TreeNode? Left;

    /// <summary>
    /// Правое поддерево узла.
    /// </summary>
    public TreeNode? Right;

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="value">Значение.</param>
    public TreeNode(int value)
    {
        Value = value;
    }
}
