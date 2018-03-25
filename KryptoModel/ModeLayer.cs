using KryptoInterface;
using KryptoInterface.Interface;
using KryptoModel.Model;
using KryptoModel.NinjectModules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using KryptoInterface.Model;

namespace KryptoModel
{
    public class ModeLayer : ModulInject , IModeLayer
    {
       // IModul modul;
        public ModeLayer(IModul  modul):base(modul)
        {
            Ninject();

        }
        void Ninject()
        {
            ДобавитьКомпановку(кореньКомпановки(new ModelModulNinject()));
        }

       /* public IUser CreatNewUser()
        {

            IUser userModel= kernelТекущая.Get<IUser>(GetConstructorArgument("date", NextEternalModul.СreateUserDate()));
            userModel.ChangedEntity += ModeLayer_ChangedUser;
            NextEternalModul.Save();

            return userModel;
        }*/

        private void ModeLayer_ChangedUser(object sender, EventArgs e)
        {
           // NextEternalModul.Save();
        }
       /* public bool DeleteUser(IUser userMod)
        {
            NextEternalModul.Remove((IUser)userMod.Date);
            userMod.ChangedEntity -= ModeLayer_ChangedUser;
            return true;
        }*/
    }
}
