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
    public class TableListController : Controller
    {
        IModeLayer ModeLayer;
        public TableListController(IModeLayer modeLayer)
        {
            ModeLayer = modeLayer;
        }
       /* public IActionResult List()
        {
          IEnumerable<ITable> tables=  ModeLayer.GetTable();
            return View(tables);
        }*/
        public IActionResult List()
        {
           
                IEnumerable<ITable> tables = ModeLayer.GetTable();
                return View(tables);
            

        }
        public IActionResult Table(String type)
        {
            IEnumerable<ITable> tables = ModeLayer.GetTable();
            if (type == null)
            {
                return View("List", tables);
            }            
            IEnumerable<ITable> table = tables.Where(r => r.TypeEntity.Name == type);


            if (table.Count() == 1)
            {
               IEnumerable<IMyEntity> myEntities= ModeLayer.GetEntity(table.FirstOrDefault().TypeEntity);
                IMyEntity myEntity = myEntities.FirstOrDefault();




                return View(myEntities);
            }
            else
            {
                return View("List", tables);
            }


        }

    }
}