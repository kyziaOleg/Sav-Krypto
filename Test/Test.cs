
using KryptoInterface.Interface;
using KryptoInterface.Model;
using System;
using System.Collections.Generic;
using System.Text;
using UnitTestProject1;

namespace Test
{
    class TestInteface
    {
        public void CachModul()
        {
            FaceRepository repository = new FaceRepository();
            СacheModul сacheModul = new СacheModul(repository);
            for (int i = 0; i < 5; i++)
            {
                IComondModul<IMyEntity> comondGet = сacheModul.Сommand(comondModul.GetComond(typeof(IUser), TypeComond.Get, null));
            }
            if(repository.amount(TypeComond.Get)!=1)
            {
                throw new Exception("CachModul отпровляет много запросов get вместо одного");
            }

        }
    }
}
