using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KryptoInterface.Interface
{
    public interface ITable
    {
        String Name { get; set; }
        Type TypeEntity { get; set; }
    }
}
