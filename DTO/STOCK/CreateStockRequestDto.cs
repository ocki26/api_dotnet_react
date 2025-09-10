using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWeb.DTO.STOCK
{
    public class CreateStockRequestDto
    {
        public string Symbol { get; set; } = string.Empty;
        public string MyCompanyName { get; set; } = string.Empty;
       
        public decimal Purchase { get; set; }
       
        public decimal LastDiv { get; set; }
        public string Industry { get; set; } = string.Empty;
        public long Marketcap { get; set; }

    }
}