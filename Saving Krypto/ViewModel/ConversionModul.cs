using KryptoInterface.Interface;
using KryptoInterface.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Core;
using Windows.UI.Core;
using Windows.UI.Xaml;

namespace Saving_Krypto.ViewModel
{
     
   
    public interface IConversionModul
    {
        IEnumerable<IMyEntity> GetObserCollection(Type type);
    }
    public class ConversionModul : Modul, IConversionModul
    {

        IDictionary<Type, IEnumerable<IMyEntity>> dictionaryobservable = new Dictionary<Type, IEnumerable<IMyEntity>>();
       // IEnumerable<IMyEntity> observable;

        public ConversionModul(IModul modul) : base(modul)
        {
            

        }
        public IEnumerable<IMyEntity> GetObserCollection(Type type)
        {
            if (!dictionaryobservable.ContainsKey(type))//Припервом заходе создаётся обсёрвел колекция для определёного типа если её небыло
            {
                CreatObservable(type);
            }
            return dictionaryobservable[type];
        }
        void CreatObservable(Type type)
        {
            IEnumerable<IMyEntity> observable = (IEnumerable<IMyEntity>)new ObservableCollection<IMyEntity>();
            dictionaryobservable.Add(type, observable);
        }

       async void СhangeObservable<T>(ICollection<T> observable, IEnumerable<T> Добавить, IEnumerable<T> Удалить)
        {
            if (observable == null)
            {
                throw new ArgumentNullException(nameof(observable));
            }
            if((Добавить == null|| Добавить.Count()==0) && (Удалить==null|| Удалить.Count()==0))
            {
                return;
            }
            
          await  CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal,   () =>
            {               
                if (Удалить != null)
                {
                    foreach (T iter in Удалить)
                    {
                        observable.Remove(iter);
                    }
                }
                if (Добавить != null)
                {
                    foreach (T iter in Добавить)
                    {
                        observable.Add(iter);
                    }
                }
            });



        }

        protected override IComondModul<IMyEntity> СommandEnd(IComondModul<IMyEntity> comond) 
        {
            
               
            if (comond.Action == TypeComond.Get)
            {
                IEnumerable<IMyEntity> врем = (IEnumerable<IMyEntity>)comond.Answer;

                ICollection<IMyEntity> observable = (ICollection<IMyEntity>)GetObserCollection(comond.TypeModel);
                IEnumerable<IMyEntity> Удалить = observable.ToList().Where(r => врем.Where(r2 => r2.Id == r.Id).Count() == 0).ToList();
                IEnumerable<IMyEntity> Добавить = врем.Where(r => observable.Where(r2 => r2.Id == r.Id).Count() == 0).ToList();
                СhangeObservable(observable, Добавить, Удалить);
                comond.SetAnswer(observable);
                dictionaryobservable[comond.TypeModel] = observable;
            }
            else if (comond.Action == TypeComond.Remove)
            {
                ICollection<IMyEntity> observable = (ICollection<IMyEntity>)GetObserCollection(comond.TypeModel);
                IEnumerable<IMyEntity> врем = comond.Answer;
                IEnumerable<IMyEntity> Удалить = observable.ToList().Where(r => врем.Where(r2 => r2.Id == r.Id).Count() != 0).ToList();
                СhangeObservable(observable, null, Удалить);
                comond.SetAnswer (Удалить);
            }
            else if (comond.Action == TypeComond.Сreate)
            {
                ICollection<IMyEntity> observable = (ICollection<IMyEntity>)GetObserCollection(comond.TypeModel);
                IEnumerable<IMyEntity> врем = comond.Answer;
                IEnumerable<IMyEntity> Добавить = врем.Where(r => observable.Where(r2 => r2.Id == r.Id).Count() == 0).ToList();
                СhangeObservable(observable, Добавить, null);
                comond.SetAnswer( Добавить);
            }

            return base.СommandEnd(comond);
        }
    }
}
