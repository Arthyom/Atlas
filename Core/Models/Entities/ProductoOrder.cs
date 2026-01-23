using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Atlas.Core.Entities;
using Core.Models.Entities.Base;

namespace Core.Models.Entities
{
    public class ProductoOrder :BaseEntity
    {
        public int ProductoId { get; set; }

        public int OrderId { get; set; }

        [ForeignKey("ProductoId")]
    
        [InverseProperty("ProductoOrder")]
    
        public virtual Producto Producto { get; set; } = null!;



        [ForeignKey("OrderId")]
    
        [InverseProperty("ProductoOrder")]
    
        public virtual Order Order { get; set; } = null!;

    }
}