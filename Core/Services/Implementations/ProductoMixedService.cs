using System;
using System.Diagnostics;
using System.Drawing;
using System.IO.Pipelines;
using System.Reflection.Metadata;
using Atlas.Core.Entities;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Core.DTOs;
using Core.DTOs.Base;
using Core.Helpers;
using Core.Services.Implementations.Base;
using Core.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using PdfSharp.UniversalAccessibility;

using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Png;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
using ZXing;
using ZXing.ImageSharp;

using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Tables;
using MigraDoc.Rendering;
using MigraDoc;
using PdfSharp.Fonts;
using Core.FontResolvers;


namespace Core.Services.Implementations;



public class ProductoMixedService : AtlasBaseServiceMixed<Producto, DtoProductoRequst, DtoProductoResponse>, IProductoMixedService
{
    private IFontResolver _fontResolver;

    public ProductoMixedService(IUnitOfWork UoW, IMapper mapper, IFontResolver fontResolver) : base(UoW, mapper)
    {

        _fontResolver = fontResolver;

        GlobalFontSettings.FontResolver = _fontResolver;

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

        var c = await UoW.GetRepo<Categoria>().DbSet.Select(x => new Categoria() { Id = x.Id, Nombre = x.Nombre, Color = x.Color }).ToListAsync();



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
        response.Extras = new { editable = false, categorias = c };

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
        response.Extras = new { editable = true, categorias = c };

        return response;
    }

    public override async Task<AtlasMixedResponse<DtoProductoResponse>> Update(DtoProductoRequst dto, int id)
    {
        List<Imagen> imagenes = new List<Imagen>();
        List<ImagenProducto> impg = new List<ImagenProducto>();
        // Producto np = new Producto()
        // {
        //     CategoriaId = dto.CategoriaId,
        //     Descripcion = dto.Descripcion,
        //     Existencia = dto.Existencia,
        //     ExistenciaMaxima = dto.ExistenciaMaxima,
        //     ExistenciaMinima = dto.ExistenciaMaxima,
        //     Nombre = dto.Nombre,
        //     PrecioMayoreo = dto.PrecioMayoreo,
        //     PrecioUnitario = dto.PrecioUnitario,

        //     Id = dto.Id,

        //     Talla = dto.Talla,
        //     Color = dto.Color,
        //     Genero = dto.Genero
        // };

        Producto np = _Mapper.Map<Producto>(dto);

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

    public async Task<byte[]> GetCodes(IEnumerable< DtoKeyValue > codes)
    {
        const string docMargin = "0.5cm", paragraphSpaceAfter = "0.2cm";
        const double cellWidth = 6.5, borderWidth = 0.3, imageSpaceBefore = 10;

        var doc = new MigraDoc.DocumentObjectModel.Document();

        var section = doc.AddSection();
        section.PageSetup.TopMargin = docMargin;
        section.PageSetup.LeftMargin = docMargin;
        section.PageSetup.BottomMargin = docMargin;

        Table table = section.AddTable();

        table.AddColumn(Unit.FromCentimeter(cellWidth));
        table.AddColumn(Unit.FromCentimeter(cellWidth));
        table.AddColumn(Unit.FromCentimeter(cellWidth));

        for (int j = 0; j < codes.Count(); j+=3)
        {
            var items = codes.Skip(j).Take(3);
            Row row = table.AddRow();

            for (int i = 0; i < items.Count(); i++)
            {
                var item = items.ElementAt(i);
                var id = item.Key.ToString("D7");
                string code =  $"C4P-05-{id[0]}-{id.Substring(1,3)}-{id.Substring(4,3)}";

                Cell cell = row.Cells[i];
                cell.Borders.Width = borderWidth;
                cell.Borders.Style = BorderStyle.DashLargeGap;

                var barCodeImage = AtlasHelperBarCode.GetCodeFromText(code);
                var imageAsText = "base64:" + Convert.ToBase64String(barCodeImage.ToArray());
                barCodeImage.Close();

                Paragraph mainParagraph = cell.AddParagraph();

                mainParagraph.Format.SpaceBefore = imageSpaceBefore;
                mainParagraph.AddImage(imageAsText);

                mainParagraph.AddText(code);
                mainParagraph.AddLineBreak();
                mainParagraph.AddText(item.Value);
                mainParagraph.Format.SpaceAfter = paragraphSpaceAfter;

                mainParagraph.Format.Alignment = ParagraphAlignment.Center;
            }
        }

        PdfDocumentRenderer renderDoc = new PdfDocumentRenderer();
        renderDoc.Document = doc;
        renderDoc.RenderDocument();

        MemoryStream ms = new MemoryStream();
        renderDoc.Save(ms, false);

        return await Task.FromResult(ms.ToArray());
    }


    #region private methods

    #endregion
}



