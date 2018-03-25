using KryptoInterface;
using KryptoInterface.Interface;
using KryptoInterface.Model;
using KryptoRepositoryLayer.Interface;
using KryptoRepositoryLayer.Modules;
using KryptoRepositoryLayer.Ninject_Modules;
using Ninject;
using Ninject.Modules;
using Ninject.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KryptoRepositoryLayer
{
    public interface IRepositoryLayer
    {

    }


    public class KryptoRepository : ModulInject, IRepositoryLayer
    {           
        public KryptoRepository(String file = "Krypto") : base(null)
        {
            Ninject();
           // kernelТекущая.Get<IContextRepository>(GetConstructorArgument("file", file), GetConstructorArgument("modul", null));
           // RequestInsideModul = (IModul)kernelТекущая.Get<IСacheModul>();


            IModul modul = (IModul)kernelТекущая.Get<IContextRepository>(GetConstructorArgument("file", file), GetConstructorArgument("modul", null));
            IModul modul2 = (IModul)kernelТекущая.Get<ITrackingСhangesModul>(GetConstructorArgument("modul", modul));
            RequestInsideModul = (IModul)kernelТекущая.Get<IСacheModul>(GetConstructorArgument("modul", modul2));

        }
        public KryptoRepository(IModul repository) : base(repository)
        {
            Ninject();
        }
        void Ninject()
        {
            ДобавитьКомпановку(кореньКомпановки(new MainModule()));
        }
    }
}
