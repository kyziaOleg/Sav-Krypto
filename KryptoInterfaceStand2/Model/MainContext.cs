using KryptoInterface.Interface;
using KryptoInterface.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using KryptoInterface.MyModel;
using System.IO;
using static System.Net.Mime.MediaTypeNames;

namespace KryptoRepositoryLayer.Context
{
    public class MainContext : DbContext
    {
        public String filename = "Krypto";
        readonly IEnumerable<IQueryable<IMyEntity>> ВсеТаблици = new List<IQueryable<IMyEntity>>();

        public MainContext()
        {
            Database.EnsureCreated();
        }
        public MainContext(String filename)
        {
            this.filename = filename ?? throw new ArgumentException(nameof(filename));
           // Database.EnsureCreated();

           //  Database.EnsureDeleted();
            // Database.EnsureCreated();

            ((IList<IQueryable<IMyEntity>>)ВсеТаблици).Add(UserDates);
            IComondModul<IUser> comond1 = new ComondModul<IUser>();

            ((IList<IQueryable<IMyEntity>>)ВсеТаблици).Add(WebIPes);
            IComondModul<IWebIP> comond2 = new ComondModul<IWebIP>();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           // String положdll = Assembly.GetExecutingAssembly().Location;
          //  int полож = положdll.IndexOf("Saving Krypto");
          //  String положdll2 = положdll.Remove(полож + 14)+ @"LocalState\";

            string path =  @"F:\WpSystem\S-1-5-21-370286678-2946152013-3708458161-1000\AppData\Local\Packages\b6a529cb-95bd-4bb5-bf63-92996cdd3844_4veyfjz7wws78\LocalState\"+ filename + ".db";

          //  string path = положdll2 + filename + ".db";
            optionsBuilder.UseSqlite($"Filename={path}");
          //  optionsBuilder.UseSqlite($"Data Source={path}\\{filename}.db");

        }

        public DbSet<User> UserDates { get; set; }

        public DbSet<WebIP> WebIPes { get; set; }

        public IEnumerable<ITable> GetTable()
        {

            IEnumerable<ITable> table = new List<ITable>();
            foreach (IQueryable<IMyEntity> очер in ВсеТаблици.ToList())
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