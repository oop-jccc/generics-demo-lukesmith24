using NUnit.Framework;

namespace GenericsTests
{
    [TestFixture]
    public class MotivationGenericMethodsTests
    {
        private class ObjectStack
        {
            private int _position;
            private readonly object[] _data;

            public ObjectStack(int max = 10)
            {
                _data = new object[max];
            }

            public void Push(object obj) => _data[_position++] = obj;
            public object Pop() => _data[--_position];
        }

        [Test]
        public void InvalidCastExceptionTest()
        {
            // Now suppose we want a stack that stores just integers:
            var intStack = new ObjectStack();

            // It's easy to make mistakes:
            intStack.Push("s"); // Wrong type, but no error!

            Assert.Throws<System.InvalidCastException>(() =>
            {
                _ = (int) intStack.Pop(); // Downcast - runtime error!
            });
        }
    }
}
