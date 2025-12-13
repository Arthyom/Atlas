using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Models.Entities.Base;

namespace Core.Models.Entities
{
    public class ProductoOrder :BaseEntity
    {
        public int ProductoId { get; set; }

        public int OrderId { get; set; }


    }
}