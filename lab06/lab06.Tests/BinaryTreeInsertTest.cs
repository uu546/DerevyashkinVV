/// <summary>
/// Класс теста добавления узла дерева.
/// </summary>
public class BinaryTreeInsertTest
{
    [Fact]
    public void InsertTest()
    {
        BinarySearchTree bst = new BinarySearchTree();

        bst.Insert(10);
        bst.Insert(5);
        bst.Insert(11);
        bst.Insert(3);
    }
}
