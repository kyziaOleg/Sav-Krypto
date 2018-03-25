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
            FaceRepository repository = new FaceRepository();
            СacheModul сacheModul = new СacheModul(repository);

            

            for (int i = 0; i < 5; i++)
            {
                IComondModul<IMyEntity> comondGet = сacheModul.Сommand(comondModul.GetComond(typeof(IUser), TypeComond.Get, null));

            }


            Assert.AreEqual(1, repository.amount(TypeComond.Get));

        }
    }
}
