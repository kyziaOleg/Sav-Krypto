using KryptoInterface.Model;
using KryptoInterface.MyModel;
using KryptoRepositoryLayer.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KryptoRepositoryLayer.Interface
{
    interface IMainContext
    {
        DbSet<User> UserDates { get; set; }

    }
}
