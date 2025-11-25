public class ChainingGetTest
{
    [Fact]
    public void GetTest()
    {
        HashTableChaining hashTableChaining = new HashTableChaining(2);

        hashTableChaining.Add("key1", "value1");
        hashTableChaining.Add("key2", "value2");
        hashTableChaining.Add("key3", "value3");

        Assert.Equal("value3", hashTableChaining.Get("key3"));
    }

    [Fact]
    public void GetNotEqualTest()
    {
        HashTableChaining hashTableChaining = new HashTableChaining(2);

        hashTableChaining.Add("key1", "value1");
        hashTableChaining.Add("key2", "value2");
        hashTableChaining.Add("key3", "value3");

        Assert.NotEqual("value1", hashTableChaining.Get("key3"));
    }
}