using System;
using Atlas.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Core.Models.Context;

public partial class AtlasDbContext : DbContext
{

protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Categoria>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Categoria_PK");

            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<Imagen>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Imagen_PK");
        });

        modelBuilder.Entity<ImagenProducto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("ImagenProducto_PK");

            entity.HasOne(d => d.Imagen).WithMany(p => p.ImagenProductos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("ImagenProducto_Imagen_FK");

            entity.HasOne(d => d.Producto).WithMany(p => p.ImagenProductos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("ImagenProducto_Producto_FK");
        });

        modelBuilder.Entity<Permiso>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Permiso_PK");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Producto_PK");

            entity.HasOne(d => d.Categoria).WithMany(p => p.Productos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Producto_Categoria_FK");
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("NewTable_PK");
        });

        modelBuilder.Entity<RolPermiso>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("RolPermiso_PK");

            entity.HasOne(d => d.Permiso).WithMany(p => p.RolPermisos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("RolPermiso_Permiso_FK");

            entity.HasOne(d => d.Rol).WithMany(p => p.RolPermisos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("RolPermiso_Rol_FK");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Usuario_PK");

            entity.HasOne(d => d.Rol).WithMany(p => p.Usuarios)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Usuario_Rol_FK");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
