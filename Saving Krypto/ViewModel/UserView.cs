using KryptoInterface.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using KryptoInterface.Model;
using KryptoModel.Model;

using KryptoInterface.MyModel;

namespace Saving_Krypto.ViewModel
{
    class UserView : User,INotifyPropertyChanged
    {       
        public override int Id{ get =>base.Id;}

        public override string ToString()// переопределяю для коректного отображения в таблицах
        {
            return Name ?? "Пусто";
        }
        public UserView(IUser date) :base(date)
        {
            if (date == null)
            {
                throw new ArgumentNullException(nameof(date));
            }
        }



    }
}
