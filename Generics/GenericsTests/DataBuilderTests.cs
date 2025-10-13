using NUnit.Framework;

namespace GenericsTests
{
    public class Data<T>
    {
        private T _value;

        public void SetData(T value)
        {
            _value = value;
        }

        public T GetData()
        {
            T ret = _value;
            return ret;
        }
    }

    public static class DataBuilder<T>
    {
        public static Data<T> BuildData()
        {
            return new Data<T>();
        }
    }

    [TestFixture]
    public class TestClassTest
    {
        [Test]
        public void Test()
        {
            var test = DataBuilder<int>.BuildData();
            test.SetData(5);

            Assert.AreEqual(5, test.GetData());
        }
    }
}
