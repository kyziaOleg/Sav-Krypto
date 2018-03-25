using KryptoInterface.Interface;
using KryptoInterface.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KryptoRepositoryLayer.Model
{
    public class User : MyEntity, IUser
    {

        public User() : base(null)
        {
        }
        public User(IUser user) : base(user)
        {
            if (user != null)
            {
                name = user.Name;
                password = user.Password;
                Id = user.Id;
            }
        }

        string name;
        public virtual string Name
        {
            get => name;
            set
            {
                value = TryChangProperty(value, name, nameof(Name));
                if (name != value)                
                    name = value;                                 
                OnChangedEntity(nameof(Name));
            }
        }

        string password;
        public virtual string Password
        {
            get => password;
            set
            {
                value = TryChangProperty(value, password, nameof(Password));
                if (password != value)                
                    password = value;                                 
                OnChangedEntity(nameof(Password));
            }
        }


    }
}
