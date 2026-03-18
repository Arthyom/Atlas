using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.DTOs.Base;

namespace Core.DTOs.Auth
{
    public class DtoAuthRequest : AtlasBaseDto
    {
        public string Password { get; set; } = null!;
        public string User { get; set; } = null!;
    }
}