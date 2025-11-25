public class DoubleHashingGetTest
{
    [Fact]
    public void GetTest()
    {
        HashTableDoubleHashing hashTableDoubleHashing = new HashTableDoubleHashing(2);

        hashTableDoubleHashing.Add("key1", "value1");
        hashTableDoubleHashing.Add("key2", "value2");
        hashTableDoubleHashing.Add("key3", "value3");

        Assert.Equal("value3", hashTableDoubleHashing.Get("key3"));
    }

    [Fact]
    public void GetNotEqualTest()
    {
        HashTableDoubleHashing hashTableDoubleHashing = new HashTableDoubleHashing(2);

        hashTableDoubleHashing.Add("key1", "value1");
        hashTableDoubleHashing.Add("key2", "value2");
        hashTableDoubleHashing.Add("key3", "value3");

        Assert.NotEqual("value1", hashTableDoubleHashing.Get("key3"));
    }
}