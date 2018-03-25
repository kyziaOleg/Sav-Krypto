using System;
using KryptoInterface.MyModel;
using KryptoRepositoryLayer.Context;
using NUnit.Framework;

namespace UnitTestProject1
{

    [TestFixture]
    public class TestUser
    {
        [Test]
        public void User_isNotNull()
        {
            User user = new User();          
            Assert.IsNotNull(user);
        }
    }
}
