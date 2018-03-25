using KryptoInterface.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 

namespace KryptoInterface
{
    public interface IRepository
    {
        IEnumerable<IUser> GetUsers();
        IUser СreateUserDate();
        void Remove(IUser user);

        void Save();
    }


}
