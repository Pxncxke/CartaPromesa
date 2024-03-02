using CartaPromesa.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartaPromesa.Persistence.DataBaseContext
{
    public class CartaPromesaDbContext : DbContext
    {
        public CartaPromesaDbContext(DbContextOptions<CartaPromesaDbContext> options) : base(options)
        {
            
        }

        public DbSet<Solicitud> Solicitudes { get; set; }
    }
}
