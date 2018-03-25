using KryptoInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KryptoInterface.Interface;
using System.Collections.ObjectModel;
using KryptoInterface.Model;
using KryptoRepositoryLayer.Ninject_Modules;
using Ninject;
using Windows.ApplicationModel.Core;
using KryptoInterfaceStand2.Model;

namespace Saving_Krypto.ViewModel
{
    public class ViewModelLayer : ModulComand, IViewModelLayer
    {
        IConversionModul conversionModul;
        public ViewModelLayer(IModul modeLayer ): base(modeLayer)
        {
            if (modeLayer == null)
            {
                throw new ArgumentNullException(nameof(modeLayer));
            }
            Ninject();

            
        }

        void Ninject()
        {
            ДобавитьКомпановку(кореньКомпановки(new ViewInject()));
            conversionModul = kernelТекущая.Get<IConversionModul>(GetConstructorArgument("modul", null));
            AnswerInsideModul = (IModul)conversionModul;
             
        }
        public IEnumerable<IMyEntity> GetAndRefreshEntity(Type type) 
        {
            Task<IEnumerable<IMyEntity>> task =  GetEntityAsync(type);
            IComondModul<IMyEntity> comond = comondModul.GetComond(type, TypeComond.Get, null);
            return conversionModul.GetObserCollection(comond.TypeModel);
        }




    }
}
