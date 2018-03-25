using KryptoInterface.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KryptoInterface.Model
{
    public interface IWebIPModul
    {

    }

    public class WebIPModul : Modul, IWebIPModul
    {
        IWebIP Option { get;  set; }
        public WebIPModul(IWebIP otion, IModul modul) : base(modul)
        {
            Option = otion;
        }
    }
}
