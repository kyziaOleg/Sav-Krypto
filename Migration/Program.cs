using KryptoInterface.MyModel;
using KryptoRepositoryLayer.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using UnitTestProject1;

namespace Migration
{
    class Program
    {
        static void Main(string[] args)
        {
            /* using (MainContext var = new MainContext("Krypto"))
             {
                // var.Database.Migrate();
                 List<User> enetable = var.UserDates.ToList();
                 List<WebIP> webIPs = var.WebIPes.ToList();
             }*/
            StartTest();
        }
        public static void StartTest()
        {
            //  TestСacheModul testСacheModul = new TestСacheModul();
            //  testСacheModul.CreatСacheModul();

            TestUser testUser = new TestUser();
            testUser.User_isNotNull();
        }


    }

}
