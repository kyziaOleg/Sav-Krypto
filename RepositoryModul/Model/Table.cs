using KryptoInterface.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KryptoRepositoryLayer.Model
{

   public class Table: ITable
    {
      public String Name { get; set; }
      public  Type TypeEntity { get; set; }
    }
}
