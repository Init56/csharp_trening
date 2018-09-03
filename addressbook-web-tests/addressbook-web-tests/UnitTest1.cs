using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace addressbook_web_tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethodSquare()
        {
            Square s1 = new Square(10);
            Square s2 = new Square(20);
            Square s3 = s1;
            Assert.AreEqual(s1.Size, 10);
            Assert.AreEqual(s2.Size, 20);
            Assert.AreEqual(s3.Size, s1.Size);
            s3.Size = 30;
            Assert.AreEqual(s3.Size, 30);
            s2.Colored = true;
        }
        [TestMethod]
        public void TestMethodCircle()
        {
            Circle s1 = new Circle(10);
            Circle s2 = new Circle(20);
            Circle s3 = s1;
            Assert.AreEqual(s1.Radius, 10);
            Assert.AreEqual(s2.Radius, 20);
            Assert.AreEqual(s3.Radius, s1.Radius);
            s3.Radius = 30;
            Assert.AreEqual(s3.Radius, 30);
            s2.Colored = true;
        }
    }
}
