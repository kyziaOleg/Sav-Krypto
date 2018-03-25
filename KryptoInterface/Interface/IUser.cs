using KryptoInterface.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KryptoInterface.Interface
{
    public interface IUser : IMyEntity
    {   
        String Name { get; set; }

        String Password { get; set; }
    }


}
