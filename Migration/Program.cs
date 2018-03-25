
using KryptoInterface.Interface;
using KryptoInterface.MyModel;
using KryptoRepositoryLayer.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

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

               foreach(ITable table in  var.GetTable())
                {
                    Console.WriteLine($"Tаблица {table.TypeEntity}");
                    IEnumerable<IMyEntity> myEntities = var.GetEntity(table.TypeEntity);
                    foreach(IMyEntity entity in myEntities )
                    {
                        Console.WriteLine($"     id={entity.Id}  {entity.ToString()}.");
                    }
                }

             }
            
            Console.ReadKey();
        }




    }

}
