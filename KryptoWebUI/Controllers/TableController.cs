using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KryptoInterface.Interface;
using Microsoft.AspNetCore.Mvc;
using KryptoModel.Model;
using System.Reflection;

namespace KryptoWebUI.Controllers
{
    public class TableController : Controller
    {
        IModeLayer ModeLayer;
        public TableController(IModeLayer modeLayer)
        {
            ModeLayer = modeLayer;
        }

        public IActionResult Entity(String type, String Id)
        {
            IEnumerable<ITable> tables = ModeLayer.GetTable();
            if (type == null)
            {
                return View("List", tables);
            }
            Type typeModel=null;
            Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
            foreach (Assembly ass in assemblies)
            {
                typeModel = ass.GetType(type);
                if(typeModel!=null)
                {
                    break;
                }

            }
            if (typeModel != null)
            {
                ITable table = tables.Where(r => typeModel.IsSubclassOf(r.TypeEntity) || typeModel== r.TypeEntity).FirstOrDefault();
                IMyEntity myEntities = ModeLayer.GetEntity(table.TypeEntity).Where(r=>r.Id.ToString()== Id).FirstOrDefault();
                if (myEntities != null)
                {
                    return View(myEntities);
                }
            }
            return View("List", tables);
        }
    }
}