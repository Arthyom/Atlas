using System;
using System.Collections.Generic;
using Atlas.Core.Entities;
using Core.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Core.Models.Context;
//dotnet ef dbcontext scaffold 'Server=localhost;Database=Atlas;User Id=sa;Password=2010_F?!;TrustServerCertificate=true' "Microsoft.EntityFrameworkCore.SqlServer" --output-dir "Models/Entities" --context "AtlasDbContext" --project "Core" --context-dir "Models/Context" --namespace "Atlas.Core.Entities" --force --use-database-names --data-annotations 
public partial class AtlasDbContext : DbContext
{
    public AtlasDbContext()
    {
    }

    public AtlasDbContext(DbContextOptions<AtlasDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Etiqueta> Etiqueta { get; set; }


    public virtual DbSet<Guide> Guide { get; set; }

    public virtual DbSet<Modelo> Modelo { get; set; }

    public virtual DbSet<ImagenModelo> ImagenModelo { get; set; }



    public virtual DbSet<ProductoOrder> ProductoOrder { get; set; }

    public virtual DbSet<Paquete> Paquete { get; set; }

    public virtual DbSet<Envio> Envio { get; set; }

    public virtual DbSet<Direccion> Direccion { get; set; }

    public virtual DbSet<Origen> Origen { get; set; }

    public virtual DbSet<Destino> Destino { get; set; }






    public virtual DbSet<Order> Order { get; set; }


    public virtual DbSet<ProductoVenta> ProductoVenta { get; set; }

    public virtual DbSet<Venta> Venta { get; set; }

    public virtual DbSet<Categoria> Categoria { get; set; }

    public virtual DbSet<Imagen> Imagens { get; set; }

    public virtual DbSet<ImagenProducto> ImagenProductos { get; set; }

    public virtual DbSet<Permiso> Permisos { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<Rol> Rols { get; set; }

    public virtual DbSet<RolPermiso> RolPermisos { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }
}
