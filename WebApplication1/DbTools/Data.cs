using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.DbTools
{
    public class Data:DbContext
    {
        public DbSet<User> Users { get; set; }
    }
}
