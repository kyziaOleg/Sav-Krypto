﻿using KryptoInterface.MyModel;
using KryptoRepositoryLayer.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Migration
{
    class Program
    {
        static void Main(string[] args)
        {
            using (MainContext var = new MainContext("Krypto"))
            {
               // var.Database.Migrate();
                List<User> enetable = var.UserDates.ToList();
                List<WebIP> webIPs = var.WebIPes.ToList();
            }
            
        }


    }

}