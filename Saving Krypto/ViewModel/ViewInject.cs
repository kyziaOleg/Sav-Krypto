using KryptoInterface;
using KryptoInterface.Interface;
using KryptoInterface.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Saving_Krypto.ViewModel
{

    class ViewInject : ModulForConstructor
    {
        public override void Load()
        {
            Bind<IUser>().To<UserView>();
            Bind<IWebIP>().To<WebIPView>();
            Bind<IConversionModul>().To<ConversionModul>();
        }

    }
}
