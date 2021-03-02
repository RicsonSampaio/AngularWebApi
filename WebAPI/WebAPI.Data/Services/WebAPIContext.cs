using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Domain.Models;

namespace WebAPI.Data.Services
{
    public class WebAPIContext : DbContext
    {
        public WebAPIContext() : base("WebAPIConnectionString")
        {
        }
        public DbSet<Product> Products { get; set; }
    }
}
