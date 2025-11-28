/// <summary>
/// Класс теста поиска максимального значения дерева.
/// </summary>
public class BinaryTreeFindMaxTest
{
    [Fact]
    public void FindMaxTest()
    {
        BinarySearchTree bst = new BinarySearchTree();

        bst.Insert(10);
        bst.Insert(5);
        bst.Insert(15);
        bst.Insert(20);

        TreeNode? result = bst.FindMax(bst.Root!);

        Assert.NotNull(result);
        Assert.True(result.Value > 0);
        Assert.Equal(20, result.Value);
    }
}