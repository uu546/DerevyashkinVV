
/// <summary>
/// Класс теста удаления узла дерева.
/// </summary>
public class BinaryTreeDeleteTest
{
    [Fact]
    public void DeleteTest()
    {
        BinarySearchTree bst = new BinarySearchTree();

        bst.Insert(10);
        bst.Insert(5);

        bst.Delete(5);
    }
}
