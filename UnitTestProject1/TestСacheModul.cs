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
    public class TestСacheModul
    {
        [Test]
        public void CreatСacheModul()
        {
            СacheModul сacheModul = new СacheModul(null);

            сacheModul.GetEntity();

        //    IComondModul<IUser> comond1 = new ComondMudul<IUser>();
        //   IComondModul<IMyEntity> comondModul= сacheModul.GetComondModul(typeof(User), TypeComond.Get, null);

            //  IComondModul<IMyEntity> comond = сacheModul.Сommand(comondModul);

        }
    }
}
