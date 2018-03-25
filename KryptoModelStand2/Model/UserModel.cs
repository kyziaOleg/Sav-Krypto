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
        public override int Id { get => base.Id; }
        public UserModel(IUser date) : base(date)
        {
            if (date == null)
            {
                throw new ArgumentNullException(nameof(date));
            }
        }
        public override string ToString()
        {
            return Name;
        }

    }
}
