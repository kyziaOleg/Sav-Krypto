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
            KryptoInterface.MyModel.User user = new KryptoInterface.MyModel.User();          
            Assert.IsNotNull(user);
        }
    }
}
