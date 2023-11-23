using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using System.Reflection;

namespace Persistence.Data;

public partial class ApiFiltroContext : DbContext
{


    public virtual DbSet<Cliente> Clients { get; set; }

    public virtual DbSet<DetallePedido> DetallePedids { get; set; }

    public virtual DbSet<Empleado> Empleads { get; set; }

    public virtual DbSet<GamaProducto> GamaProducts { get; set; }

    public virtual DbSet<Oficina> Oficins { get; set; }

    public virtual DbSet<Pago> Pags { get; set; }

    public virtual DbSet<Pedido> Pedids { get; set; }

    public virtual DbSet<Producto> Products { get; set; }



    public ApiFiltroContext(DbContextOptions<ApiFiltroContext> options)
       : base(options)
    {
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

}
