using KryptoInterface.Interface;
using KryptoInterface.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KryptoInterface.MyModel
{
    public class WebIP : MyEntity, IWebIP
    {
        public WebIP(IWebIP data) : base(data)
        {

        }
        public WebIP() : base(null)
        {

        }

        string name;
        public virtual string Name
        {
            get => name;
            set
            {
                value = TryChangProperty(value, name, nameof(Name));
                if (name != value)
                {
                    name = value;
                    OnChangedEntity(nameof(Name));
                }
            }
        }

        int limitPerMinute;
        public virtual int LimitPerMinute
        {
            get => limitPerMinute;
            set
            {
                value = TryChangProperty(value, limitPerMinute, nameof(LimitPerMinute));
                if (limitPerMinute != value)
                {
                    limitPerMinute = value;
                    OnChangedEntity(nameof(LimitPerMinute));
                }
            }
        }

        int valuePerMinute;
        public virtual int ValuePerMinute
        {
            get => valuePerMinute;
            set
            {
                value = TryChangProperty(value, valuePerMinute, nameof(ValuePerMinute));
                if (valuePerMinute != value)
                {
                    valuePerMinute = value;
                    OnChangedEntity(nameof(ValuePerMinute));
                }
            }
        }


    }
}
