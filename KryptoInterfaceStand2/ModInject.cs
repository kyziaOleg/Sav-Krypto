using KryptoInterface.Interface;
using KryptoInterface.Model;
using Ninject;
using Ninject.Modules;
using Ninject.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KryptoInterface
{

    public abstract class ModulInject :Modul
    {

        protected IKernel kernelТекущая;
        protected IEnumerable<IKernel> Компановки = new List<IKernel>();

        public ModulInject(IModul modul):base(modul)
        {

        }

        protected void ДобавитьКомпановку(IKernel новая)
        {
            if (kernelТекущая == null)
            {
                kernelТекущая = новая;
            }
          ((IList<IKernel>)Компановки).Add(новая);

        }
        protected IKernel кореньКомпановки(INinjectModule ninjectModule)
        {
            IKernel kernel = new StandardKernel(ninjectModule);
            return kernel;
        }
       protected  IConstructorArgument GetConstructorArgument(string name, object value)
        {

            INinjectModule первый = kernelТекущая.GetModules().FirstOrDefault();
            if (первый != null && первый is ModulForConstructor нужный)
            {
                return нужный.GetConstructorArgument(name, value);
            }

            throw new ArgumentException("Не найден модуль для конструктора Аргументов");
        }

        protected override IComondModul<IMyEntity> СommandEndEternalModul(IComondModul<IMyEntity> comond) 
        {
            
            comond=base.СommandEndEternalModul(comond);
            if (comond.Answer != null && kernelТекущая!=null)
            {
                comond.Dress(kernelТекущая, GetConstructorArgument);
                
            }
            return comond;
        }
        protected override IComondModul<IMyEntity> СommandStartEternalModul(IComondModul<IMyEntity> comond)
        {
            comond =   base.СommandStartEternalModul(comond);
            if (comond.Data != null && kernelТекущая != null)
            {
                IList<IMyEntity> раскр = new List<IMyEntity> ();

                foreach (IMyEntity iter in comond.Data)
                {
                    раскр.Add(iter.Date);

                }

              comond.SetData( раскр);
            }
            return comond;
        }

    }
}
