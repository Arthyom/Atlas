using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Core.Models.Entities.Base;

namespace Core.Models.Entities
{
    public class Paquete : BaseEntity
    {
        public string Type { get; set; } = null!;

        public string Depth { get; set; } = null!;
        public string Width { get; set; } = null!;
        public string Height { get; set; } = null!;
        public string Weight { get; set; } = null!;

        public string Description { get; set; } = null!;

    }
}