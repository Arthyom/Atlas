using Atlas.Core.Entities;
using Core.DTOs.Categoria;
using Core.Services.Interfaces.Base;

namespace Core.Services.Interfaces;

public interface ICategoriaMixedService : IAtlasBaseServiceMixed<Categoria, DtoCategoriaRequest, DtoCategoriaResponse>
{

}
