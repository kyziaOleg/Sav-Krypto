using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KryptoInterface.Interface;
using Microsoft.AspNetCore.Mvc;

namespace KryptoWebUI.Controllers
{
    public class MainController : Controller
    {
        
        public MainController(IModeLayer modeLayer)
        {
            
            
        }
        public IActionResult List()
        {         
            return View();
        }
    }
}