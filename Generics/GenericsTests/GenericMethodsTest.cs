using NUnit.Framework;

namespace GenericsTests
{
    [TestFixture]
    public class GenericMethodsTest
    {
        /// <summary>
        /// Follows the OCP
        /// Is an example of dynamic or runtime polymorphism
        /// </summary>
        private static void Swap(ref object a, ref object b)
        {
            var temp = a;
            a = b;
            b = temp;
        }

        /// <summary>
        /// Follows the OCP
        /// Is an example of static or compile polymorphism
        /// </summary>
        private static void Swap<T>(ref T a, ref T b)
        {
            var temp = a;
            a = b;
            b = temp;
        }

        [Test]
        public void SwapGenericTest()
        {
            int a = 5;
            int b = 10;
            Swap<int>(ref a, ref b);

            Assert.AreEqual(10, a);
            Assert.AreEqual(5, b);
        }

        [Test]
        public void SwapObjectTest()
        {
            object a = "5";
            object b = 10;
            Swap(ref a, ref b);

            Assert.AreEqual(10, a);
            Assert.AreEqual("5", b);
        }
    }
}
