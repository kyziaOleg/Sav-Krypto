using KryptoInterface;
using KryptoInterface.Interface;
using KryptoModel;
using KryptoRepositoryLayer;
using Ninject;
using Saving_Krypto.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Saving_Krypto.Inteface
{

    public class ModulInjectMain : ModulForConstructor
    {
        public int KryptoRepository { get; private set; }

        public override void Load()
        {
         
            Bind<IRepositoryLayer>().To<KryptoRepository>().InSingletonScope().WithConstructorArgument("file", "Krypto");
            Bind<IModeLayer>().To<ModeLayer>().InSingletonScope().WithConstructorArgument("modul", Kernel.Get<IRepositoryLayer>());
            Bind<IViewModelLayer>().To<ViewModelLayer>().InSingletonScope().WithConstructorArgument("modeLayer", Kernel.Get<IModeLayer>());
            
        }
    }
}
