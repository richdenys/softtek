using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using VentasSofttek.Models.GesVentas;
using VentasSofttek.Models.Login;
using VentasSofttek.Models.Response;

namespace VentasSofttek.DAL.DBContext
{
    public class VentasSofttekDBContext : DbContext
    {
        public VentasSofttekDBContext()
        {
        }

        public VentasSofttekDBContext(DbContextOptions options) : base(options)
        {

        }

        public virtual DbSet<AuthRequest> MUsers { get; set; } = null!;

        public virtual DbSet<Ventas> Ventas { get; set; } = null!;
        public virtual DbSet<Product> Prodcuts { get; set; } = null!;
        public virtual DbSet<Clients> Clients { get; set; } = null!;


    }
}
