using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.DTOs.Base;

namespace Core.DTOs
{
    public class DtoUsuarioResponse : AtlasBaseDto
    {
        public string ZipCode { get; set; } = null!;
        
        public string Nombre { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Country { get; set; } = null!;

        public string State { get; set; } = null!;

        public string CountryCode { get; set; } = null!;

        public string StateCode { get; set; }   = null!;

        public string References { get; set; } = null!;

        public string Phone { get; set; } = null!;

        public int InteriorNumber { get; set; } 

        public int OutdoorNumber { get; set; }

        public string Neighborhood { get; set; } = null!;

        public string Company { get; set; } = null!;

        public string Rol { get; set; } = null!;

    }
}