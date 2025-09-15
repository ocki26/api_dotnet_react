using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyWeb.DTO.STOCK
{
    public class CreateStockRequestDto
    {
        [Required]
        [MaxLength(10 ,ErrorMessage ="Symbol can not be over 10 character ")]
        public string Symbol { get; set; } = string.Empty;
        [Required]
        [MaxLength(10 ,ErrorMessage ="MyCompanyName can not be over 10 character ")]
        public string MyCompanyName { get; set; } = string.Empty;
        [Required]
        [Range(1,10000000)]
        public decimal Purchase { get; set; }
        [Required]
        [Range(00.1,100)]
        public decimal LastDiv { get; set; }
        [Required]
        [MaxLength(10,ErrorMessage ="Industry can not be over 10")]
        public string Industry { get; set; } = string.Empty;
        [Range(1,5000000000000)]
        public long Marketcap { get; set; }

    }
}