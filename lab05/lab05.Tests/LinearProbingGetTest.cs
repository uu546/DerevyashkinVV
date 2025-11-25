public class LinearProbingGetTest
{
    [Fact]
    public void GetTest()
    {
        HashTableLinearProbing hashTableLinearProbing = new HashTableLinearProbing(2);

        hashTableLinearProbing.Add("key1", "value1");
        hashTableLinearProbing.Add("key2", "value2");
        hashTableLinearProbing.Add("key3", "value3");

        Assert.Equal("value3", hashTableLinearProbing.Get("key3"));
    }

    [Fact]
    public void GetNotEqualTest()
    {
        HashTableLinearProbing hashTableLinearProbing = new HashTableLinearProbing(2);

        hashTableLinearProbing.Add("key1", "value1");
        hashTableLinearProbing.Add("key2", "value2");
        hashTableLinearProbing.Add("key3", "value3");

        Assert.NotEqual("value1", hashTableLinearProbing.Get("key3"));
    }
}