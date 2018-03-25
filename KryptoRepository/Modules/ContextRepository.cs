using KryptoInterface;
using KryptoInterface.Interface;
using KryptoInterface.Model;
using KryptoRepositoryLayer.Context;
using KryptoRepositoryLayer.Interface;
using KryptoRepositoryLayer.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KryptoRepositoryLayer.Modules
{

    interface IContextRepository
    {

    }
    public class ContextRepository : Modul, IContextRepository
    {
        readonly MainContext mainContext;


        public ContextRepository(String file = "Krypto", IModul modul=null) : this(file)
        {

        }
        public ContextRepository(String file= "Krypto"):base(null)
        {
           /* using (MainContext mainContext = new MainContext(file))
            {
                mainContext.Database.Migrate();
            }*/

            mainContext = new MainContext(file);
            mainContext.Database.Migrate();
        }

        protected override IComondModul<IMyEntity> СommandStart(IComondModul<IMyEntity> comond)
        {
            if (comond.Action == TypeComond.Get)
            {
 
                IEnumerable<IMyEntity> user =mainContext.GetEntity(comond.TypeModel);

                comond.SetAnswer(user);


            }
            else if (comond.Action == TypeComond.Сreate)
            {
                IMyEntity ответ = mainContext.CreatEntity(comond.TypeModel);
                IList<IMyEntity> user = new List<IMyEntity> {ответ};
                comond.SetAnswer(user);
            }
            else if (comond.Action == TypeComond.Remove)
            {
                mainContext.RemoveEntity(comond.Data);
                comond.SetAnswer(comond.Data);
            }          
            else if (comond.Action == TypeComond.Save)
            {
                mainContext.SaveChangesAsync();
            }
            else if(comond.Action == TypeComond.GetTable)
            {
                comond.Metadata = mainContext.GetTable();
            }
            return comond;
        }
    }
}
