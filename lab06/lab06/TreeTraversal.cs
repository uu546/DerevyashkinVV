/// <summary>
/// Класс для обхода бинарного дерева.
/// </summary>
public class TreeTraversal
{
    /// <summary>
    /// Метод In-Order обхода дерева (left, node, right).
    /// </summary>
    /// <param name="node">Дерево.</param>
    public static void InOrderRecursive(TreeNode node)
    {
        if (node is null)
        {
            return;
        }

        InOrderRecursive(node.Left!);

        Console.Write(node.Value + " ");

        InOrderRecursive(node.Right!);

        // Сложность: O(n) - посещает каждый узел ровно один раз.
    }

    /// <summary>
    /// Метод Pre-Order обхода дерева (node, left, right).
    /// </summary>
    /// <param name="node">Дерево.</param>
    public static void PreOrderRecursive(TreeNode node)
    {
        if (node is null)
        {
            return;
        }

        Console.Write(node.Value + " ");

        PreOrderRecursive(node.Left!);

        PreOrderRecursive(node.Right!);

        // Сложность: O(n) - посещает каждый узел ровно один раз.
    }

    /// <summary>
    /// Метод Post-Order обхода дерева (left, right, node).
    /// </summary>
    /// <param name="node">Дерево.</param>
    public static void PostOrderRecursive(TreeNode node)
    {
        if (node is null)
        {
            return;
        }

        PostOrderRecursive(node.Left!);

        PostOrderRecursive(node.Right!);

        Console.Write(node.Value + " ");

        // Сложность: O(n) - посещает каждый узел ровно один раз.
    }

    /// <summary>
    /// Метод итеративного In-Order обхода дерева (left, node, right).
    /// </summary>
    /// <param name="root">Дерево.</param>
    public static void InOrderIterative(TreeNode root)
    {
        Stack<TreeNode> stack = new Stack<TreeNode>();

        TreeNode current = root;

        while (current is not null || stack.Count > 0)
        {
            // Достигаем самого левого узла, сохраняя пройденные узлы в стек.
            while (current is not null)
            {
                stack.Push(current);
                current = current.Left!;
            }

            // Извлекаем узел из стека и обрабатываем его.
            current = stack.Pop();

            Console.Write(current.Value + " ");

            // Переходим к правому поддереву.
            current = current.Right!;
        }

        // Сложность: O(n) - посещает каждый узел ровно один раз.
    }
}