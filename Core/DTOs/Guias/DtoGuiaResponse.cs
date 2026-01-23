using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.DTOs.Base;

namespace Core.DTOs.Guias
{
    public class DtoGuiaResponse : AtlasBaseDtoFile
    {

        public string ApiId { get; set; } = null!;

        public string Estatus { get; set; } = null!;

    }
}