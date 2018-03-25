using KryptoInterface.Interface;
using KryptoInterface.MyModel;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saving_Krypto.ViewModel
{
    class WebIPView : WebIP, INotifyPropertyChanged
    {
        public override int Id { get => base.Id; }
        public WebIPView(IWebIP date) : base(date)
        {
            if (date == null)
            {
                throw new ArgumentNullException(nameof(date));
            }
        }


    }
}
