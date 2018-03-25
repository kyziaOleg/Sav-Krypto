using KryptoInterface.Interface;
using KryptoInterface.Model;
using KryptoInterface.MyModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace RepositoryStandard2
{
    public class MainContext2 : DbContext
    {
        public String filename = "крипта";
        readonly IEnumerable<IQueryable<IMyEntity>> ВсеТаблици = new List<IQueryable<IMyEntity>>();

        public MainContext2()
        {
            Database.EnsureCreated();




        }
        public MainContext2(String filename)
        {
            this.filename = filename ?? throw new ArgumentException(nameof(filename));
            Database.EnsureCreated();

            // Database.EnsureDeleted();
            // Database.EnsureCreated();

            ((IList<IQueryable<IMyEntity>>)ВсеТаблици).Add(UserDates);
            IComondModul<IUser> comond1 = new ComondMudul<IUser>();

            ((IList<IQueryable<IMyEntity>>)ВсеТаблици).Add(WebIPes);
            IComondModul<IWebIP> comond2 = new ComondMudul<IWebIP>();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Filename={filename}.db");

        }

        public DbSet<User> UserDates { get; set; }

        public DbSet<WebIP> WebIPes { get; set; }

        public IEnumerable<ITable> GetTable()
        {
            IEnumerable<ITable> table = new List<ITable>();
            foreach (IQueryable<IMyEntity> очер in ВсеТаблици)
            {
                ITable tab = new Table() { TypeEntity = очер.ElementType, };
                ((IList<ITable>)table).Add(tab);
            }
            return table;
        }


        private (IQueryable<IMyEntity> DbSet, MethodInfo Удалить, MethodInfo добавить, Type type) Таблица(Type type)
        {
            foreach (IQueryable<IMyEntity> очер in ВсеТаблици)
            {
                Type type2 = очер.ElementType;
                if (type2.GetInterfaces().Contains(type) || type2 == type)
                {

                    Type whatIwant = typeof(DbSet<>).MakeGenericType(type2);

                    MethodInfo methodInfo = whatIwant.GetMethod("Remove");
                    MethodInfo добавить = whatIwant.GetMethod("Add");


                    return (очер, methodInfo, добавить, type2);
                }
            }
            throw new Exception("Такой таблици не найдено");
        }

        public void AddEntity(IMyEntity date)
        {
            ValueTuple<IQueryable<IMyEntity>, MethodInfo, MethodInfo, Type> тюпл = Таблица(date.GetType());
            IEnumerable<IMyEntity> контекст = тюпл.Item1;
            MethodInfo добавить = тюпл.Item3;

            object[] вр = new object[1];
            вр[0] = date;

            добавить.Invoke(контекст, вр);
            //((DbSet<IMyEntity>)Таблица<T>().DbSet).Add(date);                                       
        }
        public void RemoveEntity(IEnumerable<IMyEntity> date)
        {
            ValueTuple<IQueryable<IMyEntity>, MethodInfo, MethodInfo, Type> тюпл = Таблица(date.First().GetType());

            IEnumerable<IMyEntity> вр = тюпл.Item1;
            MethodInfo методУдалить = тюпл.Item2;
            foreach (IMyEntity iter in date)
            {
                object[] dh = new object[1];
                dh[0] = iter;
                методУдалить.Invoke(вр, dh);
            }
        }
        public IEnumerable<IMyEntity> GetEntity(Type type)
        {
            IEnumerable<IMyEntity> врем = Таблица(type).DbSet.ToList();
            return врем;
        }
        public IMyEntity CreatEntity(Type type)
        {
            ValueTuple<IQueryable<IMyEntity>, MethodInfo, MethodInfo, Type> тюпл = Таблица(type);
            ConstructorInfo ci = тюпл.Item4.GetConstructor(new Type[] { });
            object создали = ci.Invoke(new object[] { });
            if (создали is IMyEntity новый)
            {
                AddEntity(новый);
                return новый;
            }
            throw new Exception("Создоваемый объект не неаследует IMyEntity");
        }


    }
}
