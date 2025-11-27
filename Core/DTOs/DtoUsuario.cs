using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.DTOs.Base;

namespace Core.DTOs
{
    public class DtoUsuario : AtlasBaseDto
    {
        public string Cp { get; set; } = null!;
    }
}