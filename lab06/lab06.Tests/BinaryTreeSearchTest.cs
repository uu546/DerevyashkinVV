/// <summary>
/// Класс теста поиска значений дерева.
/// </summary>
public class BinaryTreeSearchTest
{
    /// <summary>
    /// Метод ищет существующее значение.
    /// </summary>
    [Fact]
    public void SearchTest()
    {
        BinarySearchTree bst = new BinarySearchTree();

        bst.Insert(10);
        bst.Insert(5);
        bst.Insert(15);
        bst.Insert(20);

        bool result = bst.Search(bst.Root!, 20);

        Assert.True(result);
    }

    /// <summary>
    /// Метод ищет несуществующее значение. 
    /// Результат выполнения ожидается = false.
    /// </summary>
    [Fact]
    public void SearchNotExistValueTest()
    {
        BinarySearchTree bst = new BinarySearchTree();

        bst.Insert(10);
        bst.Insert(5);
        bst.Insert(15);
        bst.Insert(20);

        bool result = bst.Search(bst.Root!, 30);

        Assert.False(result);
    }
}
