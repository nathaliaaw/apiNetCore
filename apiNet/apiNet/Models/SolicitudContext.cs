using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace apiNet.Models
{
    public class SolicitudContext : DbContext
    {
        public SolicitudContext(DbContextOptions<SolicitudContext> options)
   : base(options)
        {
        }

        public DbSet<SolicitudesHogwarts> SolicitudesHogwarts { get; set; }
    }
}
