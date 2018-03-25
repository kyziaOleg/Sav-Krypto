using KryptoInterface;
using KryptoInterface.Interface;
using KryptoInterface.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KryptoInterfaceStand2.Model
{
    public interface IModulComand : IModul
    {
        IEnumerable<ITable> GetTable();
        Task<IEnumerable<ITable>> GetTableAsync();
        IEnumerable<IMyEntity> GetEntity(Type type);
        Task<IEnumerable<IMyEntity>> GetEntityAsync(Type type);     
        IEnumerable<IMyEntity> RemoveEntity(IMyEntity Entity);
        Task<IEnumerable<IMyEntity>> RemoveEntityAsync(IMyEntity Entity);       
        IEnumerable<IMyEntity> CreatNewEntity(Type type);
        Task<IEnumerable<IMyEntity>> CreatNewEntityAsync(Type type);
    }


  public  class ModulComand :ModulInject
    {
        public ModulComand(IModul modul) : base(modul)
        {

        }
        public async Task<IEnumerable<ITable>> GetTableAsync() => await Task<IEnumerable<ITable>>.Factory.StartNew(() => GetTable());
        public IEnumerable<ITable> GetTable()
        {
            IComondModul<IMyEntity> comond = comondModul.GetComond(typeof(IMyEntity), TypeComond.GetTable, null);
            IEnumerable<ITable> врем = Сommand(comond).Metadata;
            return врем;
        }
        public IEnumerable<IMyEntity> GetEntity(Type type)
        {
            IComondModul<IMyEntity> comond = comondModul.GetComond(type, TypeComond.Get, null);
            IEnumerable<IMyEntity> врем = Сommand(comond).Answer;
            return врем;
        }

        public async Task<IEnumerable<IMyEntity>> GetEntityAsync(Type type) => await Task<IEnumerable<IMyEntity>>.Factory.StartNew(() => GetEntity(type));
        public IEnumerable<IMyEntity> CreatNewEntity(Type type)
        {
            IComondModul<IMyEntity> comond = comondModul.GetComond(type, TypeComond.Сreate, null);
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
            IComondModul<IMyEntity> comond = comondModul.GetComond(Entity.GetType(), TypeComond.Remove, Listuser);
            IEnumerable<IMyEntity> врем = Сommand(comond).Answer;
            return врем;
        }
        public async Task<IEnumerable<IMyEntity>> RemoveEntityAsync(IMyEntity Entity) => await Task<IEnumerable<IMyEntity>>.Factory.StartNew(() => RemoveEntity(Entity));
    }
}
