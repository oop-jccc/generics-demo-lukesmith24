using System;
using NUnit.Framework;

namespace GenericsTests
{
    public static class Helpers
    {
        public static object VerifyArgumentNotNull(this object obj, string message = null)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(message);
            }

            return obj;
        }

        public static T VerifyArgumentNotNull<T>(this T obj, string message = null)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(message);
            }

            return obj;
        }
    }

    public class GameObject
    {
        private readonly Location2D _location2D;

        // public GameObject(Location2D location2D)
        // {
        //     _location2D = location2D;
        // }

        public GameObject(Location2D location2D)
        {
            location2D.VerifyArgumentNotNull(nameof(location2D));
            _location2D = location2D;
        }

        // other data and methods
        public void Display()
        {
            Console.WriteLine($"{_location2D.X}, {_location2D.Y}");
        }
    }

    public class Location2D
    {
        public int X { get; set; }

        public int Y { get; set; }

        // other data and methods
    }

    [TestFixture]
    public class VerifyArgumentNotNullTests
    {
        [Test]
        public void AssertNullReferenceException()
        {
            var gameObject = new GameObject(null);

            Assert.Throws<NullReferenceException>(() => gameObject.Display());
        }

        [Test]
        public void AssertArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => _ = new GameObject(null));
        }
    }
}
