using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Models.Entities.Base;

namespace Core.Models.Entities
{
    public class Guide : BaseEntity
    {
        public string ApiId { get; set; } = null!;

        public string Estatus { get; set; } = null!;

        public byte[] Info { get; set; } = null!;


        public virtual Order? Order {get; set;}
    }
}