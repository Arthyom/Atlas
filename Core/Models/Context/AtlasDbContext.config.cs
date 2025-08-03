using System;
using Microsoft.EntityFrameworkCore;

namespace Core.Models.Context;

public partial class AtlasDbContext : DbContext
{

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=localhost;Database=Atlas_s1;User Id=sa;Password=2010_F?!;TrustServerCertificate=true");

    
}
