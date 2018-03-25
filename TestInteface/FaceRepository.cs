using KryptoInterface.Interface;
using KryptoInterface.Model;
using KryptoInterface.MyModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject1
{
    class FaceRepository : Modul
    {
        IDictionary<Type, IEnumerable<IMyEntity>> data = new Dictionary<Type, IEnumerable<IMyEntity>>();
        IDictionary<TypeComond, int> dataInt = new Dictionary<TypeComond, int>();

        public FaceRepository() : base(null)
        {
            IList<IMyEntity> AllUser = new List<IMyEntity>();
            AllUser.Add(new User() { Id=0, Name="Admin", Password="123" });
            AllUser.Add(new User() { Id = 1, Name = "Олег", Password = "123" });
            AllUser.Add(new User() { Id = 2, Name = "Аня", Password = "123" });
            AllUser.Add(new User() { Id = 3, Name = "Никита", Password = "123" });
            AllUser.Add(new User() { Id = 4, Name = "Костя", Password = "123" });


            data.Add(typeof(IUser), AllUser);
            dataInt.Add(TypeComond.Get, 0);
            dataInt.Add(TypeComond.Remove, 0);
            dataInt.Add(TypeComond.Save, 0);
            dataInt.Add(TypeComond.Сreate, 0);
        }
        public int amount(TypeComond typeComond)
        {
            if (dataInt.ContainsKey(typeComond))
            {
                return dataInt[typeComond];
            }
            return 0;
        }
       

        protected override IComondModul<IMyEntity> СommandStart(IComondModul<IMyEntity> comond)
        {
            if (comond.Action == TypeComond.Get)
            {
                if(data.ContainsKey(comond.TypeModel))
                {
                   comond.SetAnswer(data[comond.TypeModel].ToList());
                }
            }
            else if(comond.Action == TypeComond.Сreate)
            {
               
                ConstructorInfo ci = comond.TypeModel.GetConstructor(new Type[] { });
                object создали = ci.Invoke(new object[] { });
                if (создали is IMyEntity новый)
                {
                    IList<IMyEntity> myEntities = new List<IMyEntity> { новый };
                    comond.SetAnswer(myEntities);
                    if (data.ContainsKey(comond.TypeModel))
                    {
                        ((IList<IMyEntity>)data[comond.TypeModel]).Add(новый);
                    }
                    else
                    {
                        IDictionary<Type, IEnumerable<IMyEntity>> newData = data.ToDictionary(r=>r.Key,r2=>r2.Value);
                        newData.Add(comond.TypeModel, myEntities);
                        data = newData;                      
                    }

                }


                throw new Exception("Создоваемый объект не неаследует IMyEntity");
            }
            else if(comond.Action == TypeComond.Remove)
            {
                if (data.ContainsKey(comond.TypeModel))
                {
                    foreach (IMyEntity entity in comond.Data)
                    {
                        if (((IList<IMyEntity>)data[comond.TypeModel]).Contains(entity))
                        {
                            ((IList<IMyEntity>)data[comond.TypeModel]).Remove(entity);
                        }
                    }
                }

                comond.SetAnswer(comond.Data.ToList());
            }

            if (dataInt.ContainsKey(comond.Action))
            {
                dataInt[comond.Action] = dataInt[comond.Action] + 1;
            }
            else
            {
                dataInt.Add(comond.Action, 1);
            }

            return comond;
        }

    }
}
