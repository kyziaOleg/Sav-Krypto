using KryptoInterface.Interface;
using KryptoInterface.Model;
using KryptoInterface.MyModel;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KryptoModel.Model
{

    class UserModel : User
    {
        public UserModel(IUser date) : base(date)
        {
            if (date == null)
            {
                throw new ArgumentNullException(nameof(date));
            }
        }

    }
}
