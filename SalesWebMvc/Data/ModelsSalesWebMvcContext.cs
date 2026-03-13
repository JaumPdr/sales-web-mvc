using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SalesWebMvc.Models;

namespace SalesWebMvc
{
    public class ModelsSalesWebMvcContext : DbContext
    {
        public ModelsSalesWebMvcContext (DbContextOptions<ModelsSalesWebMvcContext> options)
            : base(options)
        {
        }

        public DbSet<SalesWebMvc.Models.Department> Department { get; set; }
    }
}
