using System;
using Atlas.Core.Entities;
using Core.DTOs.Base;
using Core.Services.Implementations.Base;
using Core.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Core.Services.Implementations;

public class ProductoService : BaseService<Producto>, IProductoService
{
    public ProductoService(IUnitOfWork UoW) : base(UoW)
    {
    }

    new public async Task<List<Producto>> GetAll()
    {
       var s = new AtlasMixedResponse<Producto>();
       
       var cr = UoW.GetRepo<Categoria>();
       var pr = UoW.GetRepo<Producto>();

       var allPr = await pr.DbSet.ToListAsync();

       var allC = cr.DbSet.ToList();
       

       s.MainResourceCollection = allPr;

       s.Extras = new  { categorias = allC };

       
       return allPr;
    }
}
