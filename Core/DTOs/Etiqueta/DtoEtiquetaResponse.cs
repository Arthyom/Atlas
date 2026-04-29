using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.DTOs.Base;

namespace Core.DTOs.Etiqueta
{
    public class DtoEtiquetaResponse: AtlasBaseDto 
    {

        public string Nombre { get; set; } = null!;


        public string Descripcion { get; set; } = null!;

        public decimal PrecioUnitario { get; set; }

        public decimal PrecioMayoreo { get; set; }

        public byte Existencia { get; set; }


        public byte ExistenciaMinima { get; set; }

        public byte ExistenciaMaxima { get; set; }

        public int? EtiquetaId { get; set; }

        public ICollection<DtoEtiquetaResponse>? EtiquetasRelacionadas { get; set; } 

    }
}