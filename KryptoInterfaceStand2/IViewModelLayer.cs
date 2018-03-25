using KryptoInterface.Interface;
using KryptoInterfaceStand2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KryptoInterface
{
   public interface IViewModelLayer : IModulComand
    {
        IEnumerable<IMyEntity> GetAndRefreshEntity(Type type);



       // IEnumerable<IUser> UserView { get; }//индивидуально для всех сущностей чтобы вызывал xaml код напрямую  !!!Нужно подумать как изменить это что бы вызывался униврсальный GetEntity<T>()!!!
    }
}
