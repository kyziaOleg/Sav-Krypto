using KryptoInterface.MyModel;
using NUnit.Framework;
using System;

namespace TestKryptoInterfaceStand2
{
    [TestFixture]
    public class LogAnalyzerTests
    {
        [Test]
        public void IsValidFileName_BadExtension_ReturnsFalse()
        {
            User user = new User();
            Assert.IsNotNull(user);
            throw new Exception();
        }

        [Test]
        public void IsValidFileName_BadExtension_ReturnsFalse2()
        {
            User user = new User();
            Assert.IsNotNull(user);
            throw new Exception();
        }
    }
}
