using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyWeb.DTO.Comment
{
    public class CreateCommentRequestDto
    {
        [Required]
        [MinLength(5, ErrorMessage = "Title must be 5 character")]
        [MaxLength(280,ErrorMessage = "Title must be over 280 character")]
        public string Title { get; set; } = string.Empty;
        [Required]
        [MinLength(5, ErrorMessage = "content must be 5 character")]
        [MaxLength(280,ErrorMessage = "content must be over 280 character")]
        public string Content { get; set; } = string.Empty;
    }
}