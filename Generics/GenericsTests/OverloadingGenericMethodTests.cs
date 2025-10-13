using NUnit.Framework;

namespace GenericsTests
{
    [TestFixture]
    public class OverloadingGenericMethodTests
    {
        private static string GetData<T>(T obj)
        {
            return $"INSIDE GetData<T>,{obj.GetType().Name}";
        }

        private static string GetData<T, U>(T obj1, U obj2)
        {
            return $"INSIDE GetData<T, U>, {obj1.GetType().Name} {obj2.GetType().Name}";
        }

        private static string GetData(int x)
        {
            return $"INSIDE GetData{x.GetType().Name}";
        }

        [Test]
        public void TestMethod1()
        {
            Assert.AreEqual("INSIDE GetDataInt32", GetData(1));
            Assert.AreEqual("INSIDE GetData<T>,String", GetData("hello"));
            Assert.AreEqual("INSIDE GetData<T, U>, Int32 String", GetData(1, "hello"));
        }
    }
}
