using NUnit.Framework;

namespace GenericsTests
{
    [TestFixture]
    public class ClassOrStructConstraintsTest
    {
        [Test]
        public void OpEqualsClassTest()
        {
            bool OpEqualsClass<T>(T s, T t) where T : class // class means any reference type
            {
                return s == t;
            }

//            bool OpEqualsStructTest<T>(T s, T t) where T : struct //Not all value types overload ==
//            {
//                return s == t;
//            }

            var a = new object();
            var b = a;
            Assert.IsFalse(OpEqualsClass("Hello", "World"));
            Assert.IsFalse(OpEqualsClass(new object(), new object()));
            Assert.IsTrue(OpEqualsClass(a, b));

            //Assert.IsTrue(OpEqualsClass(5,5));
        }

        [Test]
        public void OpStringPlusStructTest()
        {
            string OpStringPlusStruct<T>(T s, T t) where T : struct // struct means any value type
            {
                return s + t.ToString(); // Everything is an object so everything implements ToString
                //Removing ToString is a compile error since not all value types implement +
            }

            Assert.AreEqual("12", OpStringPlusStruct(1, 2));
        }

        [Test]
        public void OpEqualsStructTest()
        {
            bool OpEqualsStruct<T>(T s, T t) where T : struct //Not all value types overload ==
            {
                //return s == t;
                return s.Equals(t);
            }

            Assert.IsTrue(OpEqualsStruct(5, 5));
            // Assert.IsTrue(OpEqualsStruct("s", "s")); // "s" is a reference type
        }
    }
}
