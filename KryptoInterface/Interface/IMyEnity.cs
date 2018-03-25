using KryptoInterface.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KryptoInterface.Interface
{
    public interface IMyEntity
    {
        int Id { get; }
        IMyEntity Date { get; }
        event PropertyChangedEventHandler PropertyChanged;
    }
}
