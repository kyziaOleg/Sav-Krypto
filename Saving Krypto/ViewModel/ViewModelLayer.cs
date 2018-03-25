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

namespace Saving_Krypto.ViewModel
{
    public class ViewModelLayer : ModulInject, IViewModelLayer
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
            IComondModul<IMyEntity> comond = GetComondModul(type, TypeComond.Get, null);
            return conversionModul.GetObserCollection(comond.TypeModel);
        }
       /* public IEnumerable<IMyEntity> GetEntity(Type type)
        {
            IComondModul<IMyEntity> comond = GetComondModul(type,TypeComond.Get, null);
            IEnumerable<IMyEntity> врем = Сommand(comond).Answer;
            return врем;
        }*/
        public async Task<IEnumerable<IMyEntity>> GetEntityAsync(Type type) => await Task<IEnumerable<IMyEntity>>.Factory.StartNew(() => GetEntity(type));
        public IEnumerable<IMyEntity> CreatNewEntity(Type type)
        {
            IComondModul<IMyEntity> comond = GetComondModul(type,TypeComond.Сreate, null);
            IEnumerable<IMyEntity> ответ = Сommand(comond).Answer;
            return ответ;
        }
        public async Task<IEnumerable<IMyEntity>> CreatNewEntityAsync(Type type) 
        {
            return await Task<IEnumerable<IMyEntity>>.Factory.StartNew(() => CreatNewEntity(type));                                
        }
        public IEnumerable<IMyEntity> RemoveEntity(IMyEntity Entity)
        {
            IList<IMyEntity> Listuser = new List<IMyEntity>() { Entity };
            IComondModul<IMyEntity> comond = GetComondModul(Entity.GetType(), TypeComond.Remove, Listuser);
            IEnumerable<IMyEntity> врем = Сommand(comond).Answer;
            return врем;
        }
        public async Task<IEnumerable<IMyEntity>> RemoveEntityAsync(IMyEntity Entity)  => await Task<IEnumerable<IMyEntity>>.Factory.StartNew(() => RemoveEntity(Entity));


       /* public IEnumerable<ITable> GetTable()
        {
            
            IComondModul<IMyEntity> comond = GetComondModul(typeof(IMyEntity),TypeComond.GetTable, null);
            IEnumerable<ITable> врем = Сommand(comond).Metadata;
            return врем;
        }*/




    }
}
