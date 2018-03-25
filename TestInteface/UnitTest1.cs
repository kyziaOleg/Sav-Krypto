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
            ÑacheModul ñacheModul = new ÑacheModul(repository);          
            for (int i = 0; i < 5; i++)
            {
                IComondModul<IMyEntity> comondGet = ñacheModul.Ñommand(comondModul.GetComond(typeof(IUser), TypeComond.Get, null));
            }
            Assert.Equal(1, repository.amount(TypeComond.Get));
        }
    }
}
