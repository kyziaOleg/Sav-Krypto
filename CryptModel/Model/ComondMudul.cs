using KryptoInterface.Interface;
using Ninject;
using Ninject.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KryptoInterface.Model
{
    public interface IComondModul<out T> where T: IMyEntity
    {
        TypeComond Action { get; }
        Type TypeModel { get; }
        IEnumerable<T> Answer { get;}
        IEnumerable<T> Data { get; }

        IEnumerable<ITable> Metadata { get; set; }
        TypeVisit Visit { get; set; }

        IComondModul<IMyEntity> Clone(TypeComond action, IEnumerable<IMyEntity> date);

        void SetAnswer(IEnumerable<IMyEntity> myEntity);
        void SetData(IEnumerable<IMyEntity> myEntity);

        void Dress(IKernel kernel, Func<string, object, IConstructorArgument> GetConstructorArgument);

    }
    public interface IComondModulWrite<in T> where T : IMyEntity
    {
        TypeComond Action { get; }
        Type TypeModel { get; }
        IEnumerable<T> Answer { set; }
        IEnumerable<T> Data { set; }

        IEnumerable<ITable> Metadata { get; set; }
        TypeVisit Visit { get; set; }

        void SetAnswer(IEnumerable<IMyEntity> myEntity);
        void SetData(IEnumerable<IMyEntity> myEntity);

        void Dress(IKernel kernel, Func<string, object, IConstructorArgument> GetConstructorArgument);





    }
    public enum TypeComond { Сreate, Get , Remove, Save, GetTable};
    public enum TypeVisit {All, FirstAnswer };


    public class ComondMudul
    {
      protected  static IList<IComondModul<IMyEntity>> comond = new List<IComondModul<IMyEntity>>();

    }


    public class ComondMudul<T> : ComondMudul,  IComondModul<T>, IComondModulWrite<T> where T : IMyEntity
    {
        
        public ComondMudul(TypeComond action, IEnumerable<T> date)
        {
            Action = action;
            Data = date;
        }
        public ComondMudul()
        {
            comond.Add((IComondModul<IMyEntity>)this);
        }
        public TypeComond Action { get;  }
        public Type TypeModel => typeof(T);
        public IEnumerable<T> Answer { get; set; }
        public void SetAnswer(IEnumerable<IMyEntity> myEntity) 
        {
            Answer = myEntity.OfType<T>();
        }
        public void SetData(IEnumerable<IMyEntity> myEntity)
        {
            Data = myEntity.OfType<T>();
        }
        public void Dress(IKernel kernel, Func<string, object,IConstructorArgument> GetConstructorArgument)
        {
            IEnumerable<T> user = Answer.Select(r => kernel.Get<T>(GetConstructorArgument("date", r))).ToList();
            Answer = user;


        }


        public IEnumerable<T> Data { get; set; }
        public TypeVisit Visit { get; set; } = TypeVisit.FirstAnswer;
        public IEnumerable<ITable> Metadata { get; set; }


        public static IComondModul<IMyEntity> GetComond(Type type, TypeComond action, IEnumerable<IMyEntity> date)
        {




            IComondModul<IMyEntity> como = comond.Where(r => type.GetInterfaces().Contains(r.TypeModel) || r.TypeModel == type).FirstOrDefault();

            if(como == null && typeof(IMyEntity)== type)
            {

                como = comond.First();
            }


            if (como != null)
            {
                return como.Clone(action, date);
            }
            throw new Exception($"Тип {type.Name} не зарегистрирован для команд");
        }

        public IComondModul<IMyEntity> Clone(TypeComond action, IEnumerable<IMyEntity> date)
        {
            IEnumerable<T> date2=null;
            if (date!=null)
            {
                date2 = date.OfType<T>();
            }

          return  (IComondModul<IMyEntity>)new ComondMudul<T>(action, date2);
        }

    }
}
