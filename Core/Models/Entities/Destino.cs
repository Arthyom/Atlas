using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Atlas.Core.Entities;
using Core.Models.Entities.Base;

namespace Core.Models.Entities
{
    public class Destino: BaseEntity
    {
        public int DireccionId { get; set; }


         [ForeignKey("DireccionId")]
        public virtual Direccion Direccion { get; set; } = null!;        
    }
}