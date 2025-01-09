using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product_Management_System.Models.Models
{
    public class Product : BaseEntity
    {
       
        [StringLength(100)]
        public string Name { get; set; }
        [StringLength(500)]
        public string? Description { get; set; }

        [Range(0.01, double.MaxValue)]
        public decimal Price { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
