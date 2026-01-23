using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.DTOs.Orden
{
    public class DtoApiEcartOrderTotalResponse
    {
        public double subtotal { get; set; }
        public double total { get; set; }

        public double tax { get; set; }

        public double financial_cost { get; set; }

        public double discount { get; set; }
        
        public double shipping { get; set; }
    }
}