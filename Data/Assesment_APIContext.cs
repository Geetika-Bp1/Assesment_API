using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Assesment_API.Data;

namespace Assesment_API.Data
{
    public class Assesment_APIContext : DbContext
    {
        public Assesment_APIContext (DbContextOptions<Assesment_APIContext> options)
            : base(options)
        {

        }

        public DbSet<Assesment_API.Data.Department> Department { get; set; }

    }
}

