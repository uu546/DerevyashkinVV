/// <summary>
/// Класс теста In-Order обхода дерева.
/// </summary>
public class TreeTraversalInOrderTest
{
    [Fact]
    public void TraversalInOrderTest()
    {
        BinarySearchTree bst = new BinarySearchTree();

        bst.Insert(10);
        bst.Insert(5);
        bst.Insert(11);
        bst.Insert(3);
        bst.Insert(7);
        bst.Insert(23);
        bst.Insert(4);
        bst.Insert(12);

        TreeTraversal.InOrderRecursive(bst.Root!);
    }
}