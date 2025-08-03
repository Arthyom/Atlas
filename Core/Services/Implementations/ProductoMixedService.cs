using System;
using System.Diagnostics;
using System.IO.Pipelines;
using Atlas.Core.Entities;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Core.DTOs;
using Core.DTOs.Base;
using Core.Services.Implementations.Base;
using Core.Services.Interfaces;
using IronBarCode;
using Microsoft.EntityFrameworkCore;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using PdfSharp.UniversalAccessibility;

namespace Core.Services.Implementations;

public class ProductoMixedService : AtlasBaseServiceMixed<Producto, DtoProductoRequst, DtoProductoResponse>, IProductoMixedService
{
    public ProductoMixedService(IUnitOfWork UoW, IMapper mapper) : base(UoW, mapper)
    {
    }



    public override async Task<AtlasMixedResponse<DtoProductoResponse>> GetAll()
    {
        var t = new Stopwatch();

        t.Start();
        var mainResourceCollection = await UoW.GetRepo<Producto>()
        .DbSet
    //     .Include(x => x.ImagenProductos)
    //     .ThenInclude(x => x.Imagen)

    //     .Select(x => new Producto()
    //     {
    //         Categoria = x.Categoria,
    //         ImagenProductos = x.ImagenProductos

    //         .Select(

    //     z => new ImagenProducto(){Imagen = new Imagen(){Identificador = z.Imagen.Identificador}}

    //     ).ToList()
    // })
        
        .ProjectTo<DtoProductoResponse>(_Mapper.ConfigurationProvider)

        .ToListAsync();
        t.Stop();
        Console.WriteLine($"-------------------- Total time {t.Elapsed.TotalMilliseconds} ms");

        var c = await UoW.GetRepo<Categoria>().DbSet.Select(x => new Categoria() { Id = x.Id, Nombre = x.Nombre }).ToListAsync();



        AtlasMixedResponse<DtoProductoResponse> response = new AtlasMixedResponse<DtoProductoResponse>();

        // var s =  //_Mapper.Map<List<DtoProductoResponse>>(mainResourceCollection);
        // response.MainResourceCollection = mainResourceCollection;

        response.Extras = new { categorias = c };
        response.MainResourceCollection = mainResourceCollection;

        return response;
    }

    public override async Task<AtlasMixedResponse<DtoProductoResponse>> GetById(int id)
    {
        AtlasMixedResponse<DtoProductoResponse> response = new AtlasMixedResponse<DtoProductoResponse>();

        var mainItem = await UoW.GetRepo<Producto>()
        .DbSet
        .Where(x => x.Id == id)
        .ProjectTo<DtoProductoResponse>(_Mapper.ConfigurationProvider)
        .FirstOrDefaultAsync()
        ?? throw new Exception("");
        ;

        var c = await UoW.GetRepo<Categoria>()
        .DbSet
        .ProjectTo<DtoCategoriaResponse>(_Mapper.ConfigurationProvider)
        .ToListAsync();

        response.MainResource = mainItem;
        response.Extras = new {editable = false, categorias = c};

        return response;
    }



    public override async Task<AtlasMixedResponse<DtoProductoRequst>> Store(DtoProductoRequst dto)
    {
        List<Imagen> imagenes = new List<Imagen>();
        List<ImagenProducto> impg = new List<ImagenProducto>();
        Producto np = new Producto()
        {
            CategoriaId = dto.CategoriaId,
            Descripcion = dto.Descripcion,
            Existencia = dto.Existencia,
            ExistenciaMaxima = dto.ExistenciaMaxima,
            ExistenciaMinima = dto.ExistenciaMaxima,
            Nombre = dto.Nombre,
            PrecioMayoreo = dto.PrecioMayoreo,
            PrecioUnitario = dto.PrecioUnitario,

            Talla = dto.Talla,
            Color = dto.Color,
            Genero = dto.Genero
        };

        if (dto.imagenes != null)
        {

            foreach (var x in dto.imagenes.Files)
            {
                using (MemoryStream m = new MemoryStream())
                {
                    string extention = Path.GetExtension(x.FileName);
                    string Identificador = $"{Guid.NewGuid()}${extention}";
                    await x.OpenReadStream().CopyToAsync(m);

                    Imagen img = new Imagen() { Identificador = Identificador, Info = m.ToArray() };
                    impg.Add(new ImagenProducto() { Imagen = img, Producto = np });
                }
            }

        }

        np.ImagenProductos = impg;

        repo.Insert(np);

        await UoW.SaveChangesAsync();

        return new AtlasMixedResponse<DtoProductoRequst>();
    }

    public override async Task<AtlasMixedResponse<DtoProductoResponse>> Edit(int id)
    {
        AtlasMixedResponse<DtoProductoResponse> response = new AtlasMixedResponse<DtoProductoResponse>();

        var mainItem = await UoW.GetRepo<Producto>()
        .DbSet
        .Where(x => x.Id == id)
        .ProjectTo<DtoProductoResponse>(_Mapper.ConfigurationProvider)
        .FirstOrDefaultAsync()
        ?? throw new Exception("");
        ;

        var c = await UoW.GetRepo<Categoria>()
        .DbSet
        .ProjectTo<DtoCategoriaResponse>(_Mapper.ConfigurationProvider)
        .ToListAsync();

        response.MainResource = mainItem;
        response.Extras = new {editable = true, categorias = c};

        return response;
    }

    public override async Task<AtlasMixedResponse<DtoProductoResponse>> Update(DtoProductoRequst dto, int id)
    {
         List<Imagen> imagenes = new List<Imagen>();
        List<ImagenProducto> impg = new List<ImagenProducto>();
        Producto np = new Producto()
        {
            CategoriaId = dto.CategoriaId,
            Descripcion = dto.Descripcion,
            Existencia = dto.Existencia,
            ExistenciaMaxima = dto.ExistenciaMaxima,
            ExistenciaMinima = dto.ExistenciaMaxima,
            Nombre = dto.Nombre,
            PrecioMayoreo = dto.PrecioMayoreo,
            PrecioUnitario = dto.PrecioUnitario,

            Talla = dto.Talla,
            Color = dto.Color,
            Genero = dto.Genero
        };

        if (dto.imagenes != null)
        {

            foreach (var x in dto.imagenes.Files)
            {
                using (MemoryStream m = new MemoryStream())
                {
                    string extention = Path.GetExtension(x.FileName);
                    string Identificador = $"{Guid.NewGuid()}${extention}";
                    await x.OpenReadStream().CopyToAsync(m);

                    Imagen img = new Imagen() { Identificador = Identificador, Info = m.ToArray() };
                    impg.Add(new ImagenProducto() { Imagen = img, Producto = np });
                }
            }

        }

        np.ImagenProductos = impg;

        repo.Update(np);

        await UoW.SaveChangesAsync();

        return new AtlasMixedResponse<DtoProductoResponse>();
    }



    public override async Task<AtlasMixedResponse<Producto>> Create()
    {
        var mainResourceCollection = await UoW.GetRepo<Producto>()
        .DbSet
        .Select(x => new Producto() { Categoria = x.Categoria, ImagenProductos = x.ImagenProductos })
        .ToListAsync();

        var c = await UoW.GetRepo<Categoria>().DbSet.Select(x => new Categoria() { Id = x.Id, Nombre = x.Nombre }).ToListAsync();



        AtlasMixedResponse<Producto> response = new AtlasMixedResponse<Producto>();

        response.MainResourceCollection = mainResourceCollection;

        response.Extras = new { editable = true, categorias = c };

        return response;
    }

    public async Task<byte[]> GetCodes(DtoProductoBarCodeRequest codes)
    {
        string code = Guid.NewGuid().ToString();
        var r = new Random().Next(1000000000, int.MaxValue);
        // var v = BarcodeWriter.CreateBarcode(r.ToString(), BarcodeEncoding.EAN13);
        var v = BarcodeWriter.CreateBarcode(code, BarcodeEncoding.Code128);


        var pdf = new PdfDocument();

    //     pdf.Info.Title = "cuyoooooosh";

    //     pdf.Info.Subject = "Cuyoooos pdf";


    // pdf.ViewerPreferences.FitWindow = true;
    //         pdf.PageLayout = PdfPageLayout.SinglePage;

        // var page = pdf.AddPage();

   
        var ua = UAManager.ForDocument(pdf);

        var xgf = XGraphics.FromPdfPage(pdf.AddPage());
        

        var sb = ua.StructureBuilder;


MemoryStream sms = new MemoryStream(v.ToPngBinaryData());
        var i = XImage.FromStream(  v.ToPdfStream() );



         sb.BeginElement(PdfIllustrationElementTag.Figure, "A BMW Z3 driving through a sandstone desert.", new XRect(5, 5, i.PointWidth, i.PointHeight));
                {
                    // Add the image as usual.
                    xgf.DrawImage(i, 5, 5);
                }
                sb.End();



             MemoryStream ms = new MemoryStream();

        pdf.Close();

        await pdf.SaveAsync(ms);


        return ms.ToArray();


        // return await Task.FromResult(v.ToBitmap().GetBytes());
    }


    #region private methods

    #endregion
}
