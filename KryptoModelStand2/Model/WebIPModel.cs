using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KryptoInterface.Interface;
using KryptoInterface.MyModel;


namespace KryptoModel.Model
{
    class WebIPModel: WebIP
    {
        public override int Id { get => base.Id; }
        public WebIPModel(IWebIP date): base(date)
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
