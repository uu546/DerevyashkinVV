/// <summary>
/// Класс связного списка.
/// </summary>
public class LinkedList
{
    private Node? head;

    /// <summary>
    /// Метод добавляет элемент в начало списка.
    /// </summary>
    public void InsertAtStart(int value)
    {
        Node newNode = new Node(value); // O(1)
        newNode.Next = head;            // O(1)
        head = newNode;                 // O(1)
    }

    /// <summary>
    /// Метод добавляет элмент в конец списка.
    /// </summary>
    public void InsertAtEnd(int value)
    {
        Node newNode = new Node(value);  // O(1)

        if (head is null)
        {
            head = newNode;              // O(1)
            return;
        }

        Node current = head;             // O(1)

        while (current.Next is not null) // O(N)
        {
            current = current.Next;      // O(1
        }

        current.Next = newNode;          // O(1)
    }

    /// <summary>
    /// Метод удаляет элемент из начала списка.
    /// </summary>
    public void DeleteFromStart()
    {
        if (head is not null)
        {
            head = head.Next;   // O(1)
        }
    }

    /// <summary>
    /// Метод обходит обьекты списка.
    /// </summary>
    public void Traverse()
    {
        Node? current = head;                    // O(1)

        while (current is not null)                  // O(N)
        {
            Console.Write($"{current.Value} ");
            current = current.Next;              // O(1)
        }

        Console.WriteLine();
    }
}
