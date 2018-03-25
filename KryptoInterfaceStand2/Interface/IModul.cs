using KryptoInterface.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KryptoInterface.Interface;

namespace KryptoInterface.Interface
{
    public interface IModul
    {
        IComondModul<IMyEntity> Сommand(IComondModul<IMyEntity> comond); 
    }
}
