/// <summary>
/// Класс узла связного списка.
/// </summary>
public class Node
{
    public int Value;         // O(1)

    public Node? Next;    // O(1)

    public Node(int value)   
    {
        Value = value;      // O(1)
        Next = null;        // O(1)
    }
}