using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KryptoInterface.Interface;
using Ninject.Modules;
using Ninject.Parameters;

namespace KryptoInterface
{
   public class ModulForConstructor : NinjectModule 
    {
        public IConstructorArgument GetConstructorArgument(string name, object value)
        {
            return new ConstructorArgument(name, value);
        }

        public override void Load()
        {

        }
    }
}
