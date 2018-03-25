
using KryptoInterface;
using KryptoInterface.Interface;
using KryptoInterface.Model;
using KryptoRepositoryLayer.Context;
using KryptoRepositoryLayer.Interface;
using KryptoRepositoryLayer.Model;
using KryptoRepositoryLayer.Modules;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace KryptoRepositoryLayer.Ninject_Modules
{
    class MainModule : ModulForConstructor
    {
        public override void Load()
        {
            this.Kernel.Load(Assembly.GetExecutingAssembly());

            Bind<IContextRepository>().To<ContextRepository>().When(r => r.Parameters.Where(r2=>r2.Name== "file").Count() == 1).InSingletonScope();
            

            Bind<IСacheModul>().To<СacheModul>();

            Bind<ITrackingСhangesModul>().To<TrackingСhangesModul>();




        }

    }
}
