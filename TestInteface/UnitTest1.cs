using KryptoInterface.Interface;
using KryptoInterface.Model;
using System;
using UnitTestProject1;
using Xunit;

namespace TestInteface
{
    public class TestKryptoInterface
    {
        [Fact]
        public void CachModul()
        {
            FaceRepository repository = new FaceRepository();
            �acheModul �acheModul = new �acheModul(repository);          
            for (int i = 0; i < 5; i++)
            {
                IComondModul<IMyEntity> comondGet = �acheModul.�ommand(comondModul.GetComond(typeof(IUser), TypeComond.Get, null));
            }
            Assert.Equal(1, repository.amount(TypeComond.Get));
        }
    }
}
