using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI.Domain.Models
{
    public class Product
    {
        [Required]
        public int Id { get; set; }
        public string Description { get; set; }
        
        [Required]
        public decimal Price { get; set; }

        [Required]
        public string ProductCode { get; set; }

        [Required]
        public string ProductName { get; set; }

        [Required]
        public string ReleaseDate { get; set; }
    }
}
