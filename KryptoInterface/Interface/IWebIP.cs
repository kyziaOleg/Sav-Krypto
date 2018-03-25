using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KryptoInterface.Interface
{
    public interface IWebIP: IMyEntity
    {
        string Name { get; set; }
        int LimitPerMinute { get; set; }
        int ValuePerMinute { get; set; }
    }
}
