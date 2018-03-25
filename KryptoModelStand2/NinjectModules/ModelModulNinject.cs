using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using KryptoInterface;
using KryptoInterface.Interface;
using KryptoModel.Model;

namespace KryptoModel.NinjectModules
{

    class ModelModulNinject : ModulForConstructor
    {
        public override void Load()
        {
            this.Kernel.Load(Assembly.GetExecutingAssembly());


            Bind<IUser>().To<UserModel>();
            Bind<IWebIP>().To<WebIPModel>();


        }

    }
}
