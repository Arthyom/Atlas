using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Core.Models.Entities.Base;

namespace Core.Models.Entities
{
    public class Origen : BaseEntity
    {
        public int DireccionId { get; set; }
        // [InverseProperty("Origin")]
        // public virtual ICollection<Envio> Envios { get; set; } = new List<Envio>();

        [ForeignKey("DireccionId")]
        public virtual Direccion Direccion { get; set; } = null!;

    }
}