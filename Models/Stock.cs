using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyWeb.Models
{
    public class Stock
    {
         public int Id { get; set; }
        public string Symbol { get; set; } = string.Empty;
        public string MyCompanyName { get; set; } = string.Empty;
        [Column(TypeName = "decimal(18,2)")]
        public decimal Purchase { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal LastDiv { get; set; }
        public string Industry { get; set; } = string.Empty;
        public long Marketcap { get; set; }
        public List<Comment> Comments { get; set; } = new List<Comment>();
    }
}