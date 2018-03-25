using KryptoInterface.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KryptoInterface
{
   public interface IViewModelLayer
    {
        IEnumerable<IMyEntity> GetAndRefreshEntity(Type type);
        Task<IEnumerable<IMyEntity>> GetEntityAsync(Type type);
        IEnumerable<IMyEntity> GetEntity(Type type);
        Task<IEnumerable<IMyEntity>> RemoveEntityAsync(IMyEntity Entity);
        IEnumerable<IMyEntity> RemoveEntity(IMyEntity Entity);
        Task<IEnumerable<IMyEntity>> CreatNewEntityAsync(Type type);
        IEnumerable<IMyEntity> CreatNewEntity(Type type);

        IEnumerable<ITable> GetTable();
       // IEnumerable<IUser> UserView { get; }//индивидуально для всех сущностей чтобы вызывал xaml код напрямую  !!!Нужно подумать как изменить это что бы вызывался униврсальный GetEntity<T>()!!!
    }
}
