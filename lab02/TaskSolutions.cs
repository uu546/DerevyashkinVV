public static class TaskSolutions
{
    // Проверка сбалансированности скобок с помощью стека.
    public static bool IsBracketsBalanced(string input)
    {
        Stack<char> stack = new();

        foreach (char c in input)
        {
            if ("({[".Contains(c))
            {
                stack.Push(c);
            }

            else if (")}]".Contains(c))
            {
                if (stack.Count == 0)
                {
                    return false;
                }

                char open = stack.Pop();

                bool isNotValid = (open == '(' && c == ')') ||
                                  (open == '[' && c == ']') ||
                                  (open == '{' && c == '}');

                if (!isNotValid)
                {
                    return false;
                }
            }
        }

        bool isBalanced = stack.Count == 0;

        return isBalanced;

        // Сложность O(N)
    }

    // Симуляция очереди печати.
    public static void PrintQueueSimulation()
    {
        Queue<string> printQueue = new();
        printQueue.Enqueue("Документ 1");
        printQueue.Enqueue("Документ 2");
        printQueue.Enqueue("Документ 3");

        while (printQueue.Count > 0)
        {
            string dequeuedDocument = printQueue.Dequeue();

            Console.WriteLine($"Печатается: {dequeuedDocument}");
        }

        // Сложность O(N)
    }

    // Проверка палиндрома через deque.
    public static bool IsPalindrome(string text)
    {
        LinkedList<char> deque = new LinkedList<char>();

        foreach (char c in text)
        {
            deque.AddLast(c);
        }

        while (deque.Count > 1)
        {
            // Сравниваем первый и последний элементы.
            if (deque.First!.Value != deque.Last!.Value)
            {
                return false;
            }

            // Удаляем первый и последний элементы, так как они уже проверены.
            deque.RemoveFirst();
            deque.RemoveLast();
        }

        return true;
    }
}