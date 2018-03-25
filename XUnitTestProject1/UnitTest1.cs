using KryptoInterface.MyModel;
using System;
using Xunit;

namespace XUnitTestProject1
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            User user = new User();
            Assert.NotNull(user);
        }
    }
}
