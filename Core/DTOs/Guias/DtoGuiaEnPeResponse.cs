using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.DTOs.Base;

namespace Core.DTOs.Guia
{
    public class DtoGuiaEnPeResponse : AtlasBaseDto
    {
        public string pdf { get; set; } = null!;

    }
}