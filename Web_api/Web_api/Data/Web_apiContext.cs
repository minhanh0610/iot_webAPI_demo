using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Web_api.Models;

namespace Web_api.Data
{
    public class Web_apiContext : DbContext
    {
        public Web_apiContext (DbContextOptions<Web_apiContext> options)
            : base(options)
        {
        }

        public DbSet<SensorData> SensorData { get; set; }
    }
}
