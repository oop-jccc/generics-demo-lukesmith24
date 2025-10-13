using System;
using NUnit.Framework;
// ReSharper disable StringCompareToIsCultureSpecific

namespace GenericsTests
{
    [TestFixture]
    public class TypeConstraintsTests
    {
        private static T Max<T>(T a, T b) where T : IComparable<T> // Self-referencing interface constraint
        {
            return a.CompareTo(b) > 0 ? a : b;
        }

        [Test]
        public void MaxTest()
        {
            var maxInt = Max(5, 10); // 10
            var maxAnimal = Max("ant", "zebra"); // zoo

            Assert.AreEqual(10, maxInt);
            Assert.AreEqual("zebra", maxAnimal);
        }

        [Test]
        public void MaxPersonTest()
        {
            var person1 = new Person {FirstName = "John", LastName = "Williams"};
            var person2 = new Person {FirstName = "Neo", LastName = "Anderson"};

            var maxPerson = Max(person1, person2);

            Assert.AreEqual(person1, maxPerson);
        }

        private class Person : IComparable<Person>
        {
            public string FirstName { get; init; }
            public string LastName { get; init; }

            public int CompareTo(Person otherPerson)
            {
                return LastName.CompareTo(otherPerson.LastName);
            }
        }
    }
}
