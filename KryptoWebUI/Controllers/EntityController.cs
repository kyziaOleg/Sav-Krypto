using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KryptoInterface.Interface;
using Microsoft.AspNetCore.Mvc;

namespace KryptoWebUI.Controllers
{
    public class EntityController : Controller
    {
        IModeLayer ModeLayer;
        public EntityController(IModeLayer modeLayer)
        {
            ModeLayer = modeLayer;
        }
        public IActionResult List(String Entity)
        {
           // ModeLayer.GetEntity()

            return View();
        }
    }
}