﻿using KryptoInterface;
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
using KryptoInterfaceStand2.Model;

namespace KryptoModel
{
    public class ModeLayer : ModulComand , IModeLayer
    {

        public ModeLayer(IModul  modul):base(modul)
        {
            Ninject();

        }
        void Ninject()
        {
            ДобавитьКомпановку(кореньКомпановки(new ModelModulNinject()));
        }



        private void ModeLayer_ChangedUser(object sender, EventArgs e)
        {
           
        }

        

    }
}
