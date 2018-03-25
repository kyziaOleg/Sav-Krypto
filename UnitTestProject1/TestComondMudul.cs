using KryptoInterface.Interface;
using KryptoInterface.Model;
using KryptoInterface.MyModel;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject1
{
    [TestFixture]
    public class TestComondMudul
    {
        [Test]
        public void Creat_ComondMudul()
        {
            IComondModul<IMyEntity> comondcPrototip= comondModul.GetComond(typeof(IUser), TypeComond.Save, null);
            IComondModul<IMyEntity> comondcPrototip2 = comondModul.GetComond(typeof(User), TypeComond.Save, null);
            Assert.AreEqual(comondcPrototip.TypeModel, typeof(IUser));
            Assert.AreEqual(comondcPrototip2.TypeModel, typeof(IUser));
        }
    }
}
