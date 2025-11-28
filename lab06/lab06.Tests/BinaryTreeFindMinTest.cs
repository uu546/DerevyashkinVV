/// <summary>
/// Класс теста поиска минимального значения дерева.
/// </summary>
public class BinaryTreeFindMinTest
{
    [Fact]
    public void FindMinTest()
    {
        BinarySearchTree bst = new BinarySearchTree();

        bst.Insert(10);
        bst.Insert(5);
        bst.Insert(3);
        bst.Insert(15);
        bst.Insert(20);

        TreeNode? result = bst.FindMin(bst.Root!);

        Assert.NotNull(result);
        Assert.True(result.Value > 0);
        Assert.Equal(3, result.Value);
    }
}